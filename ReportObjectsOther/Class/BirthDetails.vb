Public Class BirthDetails
    Public MainReport As New rptBirthDetails

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.ConditionString
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'ARRANGE DATE COVERAGE FILTER
        Dim DateCoverageFilter As String = ""
        If Not GetDateCondition(REPORT_DETAIL, DateCoverageFilter) Then Exit Sub

        'CONSTRUCT REPORT DATA SOURCE
        'cSQL = "SELECT * FROM rpt_BirthDetails "
        cSQL = "SELECT	crew.*, " & _
               "        ss.*, " & _
               "        ss.FKeyPrinCode AS FKeyPrin, " & _
               "		ss.FKeyAgentCode AS FKeyAgent, " & _
               "		[rank].SortCode AS RankSortCode, " & _
               "		[rank].Abbrv AS Rank, " & _
               "		ss.statname, " & _
               "		ss.VslName, " & _
               "		cinfo.DOB, " & _
               "		[dbo].[FN_GetAgeOnSpecificDate](cinfo.dob, " & GetDateToCompareSQL(REPORT_DETAIL.FilterOption) & ")  as Age, " & _
               "		addr.Addr, " & _
               "		addr.Addr, 		cinfo.Phone + ' / ' + cinfo.TeleFax AS ContactNo, cinfo.DOB AS dDate " & _
               "FROM	(SELECT IDNbr, Crew, Nationality, Rank FROM dbo.Rpt_BioInfo) AS crew INNER JOIN " & _
               "		dbo.tblcrewinfo cinfo ON crew.IDNbr = cinfo.PKey LEFT OUTER JOIN " & _
               "		(SELECT rn = ROW_NUMBER() OVER(PARTITION BY idnbr, fkeyagentcode ORDER BY datestart desc), * FROM dbo.Rpt_CrewActAll " & _
                            IIf(DateCoverageFilter.Length > 0, "WHERE " & DateCoverageFilter & " ", "") & ") ss ON crew.IDNbr = ss.IDNbr LEFT OUTER JOIN " & _
               "		dbo.tbladmrank [rank] ON ss.FKeyRankCode = [rank].PKey LEFT OUTER JOIN " & _
               "		dbo.CrewAddrList addr ON ss.IDNbr = addr.FKeyIDNbr "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " " & _
                   " AND ss.rn = 1"
        Else
            cSQL = cSQL & " WHERE ss.rn = 1"
        End If

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        BindData(MainReport.celCrew, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "Rank")
        BindData(MainReport.celStat, "Text", Nothing, "Stat")
        BindData(MainReport.celVsl, "Text", Nothing, "VslName")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celAge, "Text", Nothing, "Age")
        BindData(MainReport.celAddr, "Text", Nothing, "Addr")
        BindData(MainReport.celContactNo, "Text", Nothing, "ContactNo")

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
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
        REPORT_DETAIL.RetrieveFilterDate("Date From", "Date To", DateFrom, DateTo)
        tmpDateFrom = IIf(IsNothing(DateFrom), "", ChangeToSQLDate(CDate(DateFrom)))
        tmpDateTo = IIf(IsNothing(DateTo), "", ChangeToSQLDate(CDate(DateTo)))

        'strSubTitle = changeDateRangeToSubTitle(tmpDateFrom, tmpDateTo)

        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
            'WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(datestart is not null AND datestart BETWEEN [FROM] AND [TO])", "[FROM]", "[TO]", DateFrom, DateTo)
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("dbo.DateIsInRange([FROM],[TO], datestart,dateend) = 1", "[FROM]", "[TO]", DateFrom, DateTo)
        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
            'WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(datestart is not null AND datestart BETWEEN [FROM] AND getdate())", "[FROM]", "", DateFrom, Nothing)
            'WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(datestart is not null AND datestart >= [FROM])", "[FROM]", "", DateFrom, Nothing)
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("dbo.DateIsInRange([FROM],getdate(), datestart,dateend) = 1", "[FROM]", "", DateFrom, Nothing)
        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("(datestart is not null AND datestart <= [TO])", "", "[TO]", Nothing, DateTo)
        End If

        
RETURN_AND_EXIT:
        Return ReturnValue
    End Function

    Private Function GetDateToCompareSQL(FilterOption As BaseFilterOption) As String
        Dim tmpDateTo As Object = Nothing
        Dim dateto As Date = Nothing
        tmpDateTo = FilterOption.GetFilterValue("Date To")

        If IsDate(tmpDateTo) Then
            dateto = Convert.ToDateTime(tmpDateTo)
        End If

        If Not IsNothing(dateto) And dateto <> #12:00:00 AM# Then
            Return Format(dateto, "'yyyy-MM-dd'")
        Else
            Return "getdate()"
        End If
    End Function
End Class
