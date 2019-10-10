Imports MPS4
Imports Utilities
Imports Reports

Public Class ApplicantList

    Private MainReport As New rptApplicantList
    Dim strSubTitle As String

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim cSQL As String

        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        'CREATES A LIST OF FILTER OPTION ITEMS THAT ARE TO BE EXCEMPTED, IF THE REPORT IS BEING CREATED BY AutoEmail
        Dim ListOfExcemptedFilterOptionsByCaption As New List(Of String)
        If REPORT_DETAIL.AutoEmail.Enabled Then
            ListOfExcemptedFilterOptionsByCaption.Add("From")
            ListOfExcemptedFilterOptionsByCaption.Add("To")
        End If
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(, ListOfExcemptedFilterOptionsByCaption)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE

        'ARRANGE DATE COVERAGE FILTER
        Dim DateCoverageFilter As String = ""
        If Not GetDateCondition(REPORT_DETAIL, DateCoverageFilter) Then Exit Sub

        '---------------------------------------------------------------------------------------------------------------------------------------
        'MANDATORY FILTER
        Dim cFilter As String = ""

        If MainReportFilter.Length > 0 Then
            cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & MainReportFilter
        End If

        If DateCoverageFilter.Length > 0 Then
            cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & DateCoverageFilter
        End If

        cSQL = "SELECT	crew.*, " & _
               "        app.*, " & _
               "        dept.name as RankDept, " & _
               "        firstvoyage.FirstVoyageDateSOn, " & _
               "        firstvoyage.FirstVoyageVslCode, " & _
               "        firstvoyage.FirstVoyagVslName " & _
               "FROM    (SELECT IDNbr, Crew, Nationality, Rank FROM dbo.Rpt_BioInfo) AS crew  LEFT OUTER JOIN " & _
               "        dbo.rpt_CrewActApplicant app ON crew.idnbr = app.idnbr LEFT OUTER JOIN " & _
               "        (SELECT idnbr, dateson as FirstVoyageDateSOn, Fkeyvslcode as FirstVoyageVslCode, vslname as FirstVoyagVslName FROM dbo.rpt_CrewActFirstVoyage) firstvoyage ON app.idnbr = firstvoyage.idnbr LEFT OUTER JOIN " & _
               "        dbo.tbladmrank as rank ON app.fkeyrankcode = rank.pkey LEFT OUTER JOIN " & _
               "        dbo.tbladmdept as dept ON rank.deptcode = dept.pkey " & _
               IIf(cFilter.Length > 0, " WHERE " & cFilter & " ", "")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Note: Sorting should be applied from the report bands, not on source
        If Sorting.Length > 0 Then
            cSQL = cSQL & "ORDER BY " & Sorting & " "
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------------------------------------------------------------
        With MainReport
            .txtDateApplied.DataBindings.Add("Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
            .txtDateFirstVoyage.DataBindings.Add("Text", Nothing, "FirstVoyageDateSOn", "{0:dd-MMM-yyyy}")
            .DataSource = dt
            .Name = REPORT_DETAIL.ReportObjectID
            BindReportControls(MainReport)
            AddFieldsToGroupHeaderBand(.GroupHeader_AgentName, "AgentName", REPORT_DETAIL.SortOption.GetSortValueCode("AgentName"))
            AddSortFieldsToDetailBandFromDT(.Detail, REPORT_DETAIL.SortOption.SortDataSource)
            SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

            .subHeader.ReportSource = New Reports.rptHeader(MainReport)
            .lblSubTitle.Text = strSubTitle
            '---------------------------------------------------------------------------------------------------------------------------------------
            REPORT_DETAIL.MainReport = MainReport
        End With


    End Sub

    Function GetDateCondition(REPORT_DETAIL As ReportDetail, ByRef WhereConditionString As String) As Boolean
        'RETURN FALSE IF DOES NOT PASS VALIDATION
        Dim ReturnValue As Boolean = True


        'Get date filter
        Dim DateFrom As Object = Nothing
        Dim DateTo As Object = Nothing
        Dim tmpDateFrom As String = ""
        Dim tmpDateTo As String = ""

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Get Date Parameters
        REPORT_DETAIL.RetrieveFilterDate("From", "To", DateFrom, DateTo)
        tmpDateFrom = IIf(IsNothing(DateFrom), "", ChangeToSQLDate(CDate(DateFrom)))
        tmpDateTo = IIf(IsNothing(DateTo), "", ChangeToSQLDate(CDate(DateTo)))

        strSubTitle = changeDateRangeToSubTitle(tmpDateFrom, tmpDateTo)

        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(app.datestart is not null AND app.datestart BETWEEN [FROM] AND [TO])", "[FROM]", "[TO]", DateFrom, DateTo)
        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(app.datestart is not null AND app.datestart >= [FROM])", "[FROM]", "", DateFrom, Nothing)
        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(app.datestart is not null AND app.datestart <= [TO])", "", "[TO]", Nothing, DateTo)
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim FirstVoyageFrom As Object = Nothing
        Dim FirstVoyageTo As Object = Nothing
        Dim tmpFirstVoyageFrom As String = ""
        Dim tmpFirstVoyageTo As String = ""

        REPORT_DETAIL.RetrieveFilterDate("First Voyage From", "First Voyage To", FirstVoyageFrom, FirstVoyageTo)

        tmpFirstVoyageFrom = IIf(IsNothing(FirstVoyageFrom), "", ChangeToSQLDate(CDate(FirstVoyageFrom)))
        tmpFirstVoyageTo = IIf(IsNothing(FirstVoyageTo), "", ChangeToSQLDate(CDate(FirstVoyageTo)))


        If tmpFirstVoyageFrom.Length > 0 And tmpFirstVoyageTo.Length > 0 Then
            WhereConditionString = WhereConditionString & IIf(WhereConditionString.Length > 0, " AND ", "") & REPORT_DETAIL.ConstructCoverageCondition("(firstvoyage.dateson is not null AND firstvoyage.dateson BETWEEN [FROM] AND [TO])", "[FROM]", "[TO]", FirstVoyageFrom, FirstVoyageTo)
        ElseIf tmpFirstVoyageFrom.Length > 0 And tmpFirstVoyageTo.Length = 0 Then
            WhereConditionString = WhereConditionString & IIf(WhereConditionString.Length > 0, " AND ", "") & REPORT_DETAIL.ConstructCoverageCondition("(firstvoyage.dateson is not null AND firstvoyage.dateson >= [FROM])", "[FROM]", "", FirstVoyageFrom, Nothing)
        ElseIf tmpFirstVoyageFrom.Length = 0 And tmpFirstVoyageTo.Length > 0 Then
            WhereConditionString = WhereConditionString & IIf(WhereConditionString.Length > 0, " AND ", "") & REPORT_DETAIL.ConstructCoverageCondition("(firstvoyage.dateson is not null AND firstvoyage.dateson <= [TO])", "", "[TO]", Nothing, FirstVoyageTo)
        End If

RETURN_AND_EXIT:
        Return ReturnValue
    End Function
End Class