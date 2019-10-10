Imports MPS4
Imports Utilities
Imports Reports

Public Class FirstVoyage

    Private MainReport As New rptFirstVoyage
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
        Dim cFilter As String = "firstvoyage.vslname is not null AND firstvoyage.dateson is not null"

        If MainReportFilter.Length > 0 Then
            cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & MainReportFilter
        End If

        If DateCoverageFilter.Length > 0 Then
            cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & DateCoverageFilter
        End If

        cSQL = "SELECT		crew.*, " & _
               "            firstvoyage.*, " & _
               "            app.DateApplied " & _
               "FROM		(SELECT IDNbr, Crew, Nationality, Rank FROM dbo.Rpt_BioInfo) AS crew  LEFT OUTER JOIN  " & _
               "            dbo.rpt_CrewActFirstVoyage firstvoyage ON crew.idnbr = firstvoyage.idnbr LEFT OUTER JOIN " & _
               "			(SELECT idnbr, datestart as DateApplied FROM dbo.rpt_CrewActApplicant) app ON firstvoyage.idnbr = app.idnbr LEFT OUTER JOIN " & _
               "            dbo.tbladmrank as rank ON firstvoyage.fkeyrankcode = rank.pkey LEFT OUTER JOIN  " & _
               "			dbo.tbladmdept as dept ON rank.deptcode = dept.pkey   " & _
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
            .txtDateApplied.DataBindings.Add("Text", Nothing, "DateApplied", "{0:dd-MMM-yyyy}")
            .txtDateFirstVoyage.DataBindings.Add("Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
            .txtDateSOff.DataBindings.Add("Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
            .DataSource = dt
            .Name = REPORT_DETAIL.ReportObjectID
            BindReportControls(MainReport)
            AddFieldsToGroupHeaderBand(.GroupHeader_VslName, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
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
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(firstvoyage.dateson is not null AND firstvoyage.dateson BETWEEN [FROM] AND [TO])", "[FROM]", "[TO]", DateFrom, DateTo)
        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(firstvoyage.dateson is not null AND firstvoyage.dateson >= [FROM])", "[FROM]", "", DateFrom, Nothing)
        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(firstvoyage.dateson is not null AND firstvoyage.dateson <= [TO])", "", "[TO]", Nothing, DateTo)
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim DateAppliedFrom As Object = Nothing
        Dim DateAppliedTo As Object = Nothing
        Dim tmpDateAppliedFrom As String = ""
        Dim tmpDateAppliedTo As String = ""

        REPORT_DETAIL.RetrieveFilterDate("Date Applied From", "Date Applied To", DateAppliedFrom, DateAppliedTo)

        tmpDateAppliedFrom = IIf(IsNothing(DateAppliedFrom), "", ChangeToSQLDate(CDate(DateAppliedFrom)))
        tmpDateAppliedTo = IIf(IsNothing(DateAppliedTo), "", ChangeToSQLDate(CDate(DateAppliedTo)))


        If tmpDateAppliedFrom.Length > 0 And tmpDateAppliedTo.Length > 0 Then
            WhereConditionString = WhereConditionString & IIf(WhereConditionString.Length > 0, " AND ", "") & REPORT_DETAIL.ConstructCoverageCondition("(app.dateapplied is not null AND app.dateapplied BETWEEN [FROM] AND [TO])", "[FROM]", "[TO]", DateAppliedFrom, DateAppliedTo)
        ElseIf tmpDateAppliedFrom.Length > 0 And tmpDateAppliedTo.Length = 0 Then
            WhereConditionString = WhereConditionString & IIf(WhereConditionString.Length > 0, " AND ", "") & REPORT_DETAIL.ConstructCoverageCondition("(app.dateapplied is not null AND app.dateapplied >= [FROM])", "[FROM]", "", DateAppliedFrom, Nothing)
        ElseIf tmpDateAppliedFrom.Length = 0 And tmpDateAppliedTo.Length > 0 Then
            WhereConditionString = WhereConditionString & IIf(WhereConditionString.Length > 0, " AND ", "") & REPORT_DETAIL.ConstructCoverageCondition("(app.dateapplied is not null AND app.dateapplied <= [TO])", "", "[TO]", Nothing, DateAppliedTo)
        End If

RETURN_AND_EXIT:
        Return ReturnValue
    End Function
End Class