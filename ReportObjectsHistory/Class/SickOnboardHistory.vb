Imports MPS4
Imports Utilities
Imports Reports

Public Class SickOnboardHistory

    Private MainReport As New rptSickOnboardHistory

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"), {"From", "To"}.ToList())
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Get Date Parameters
        Dim tmpDateFrom As String, tmpDateTo As String
        Dim DateFrom As Object = Nothing, DateTo As Object = Nothing

        REPORT_DETAIL.RetrieveFilterDate("From", "To", DateFrom, DateTo)
        tmpDateFrom = IIf(IsNothing(DateFrom), "", ChangeToSQLDate(CDate(DateFrom)))
        tmpDateTo = IIf(IsNothing(DateTo), "", ChangeToSQLDate(CDate(DateTo)))


        'Get date filter
        Dim DateCoverageFilter As String = ""
        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
            DateCoverageFilter = REPORT_DETAIL.ConstructCoverageCondition("actdatestart is not null AND actdatestart BETWEEN [FROM] AND [TO]", "[FROM]", "[TO]", DateFrom, DateTo)
        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
            DateCoverageFilter = REPORT_DETAIL.ConstructCoverageCondition("actdatestart is not null AND actdatestart >= [FROM]", "[FROM]", "", DateFrom, Nothing)
        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
            DateCoverageFilter = REPORT_DETAIL.ConstructCoverageCondition("actdatestart is not null AND actdatestart <= [TO]", "", "[TO]", Nothing, DateTo)
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT FILTER CONDITION
        Dim MainFilter As String = ""
        If MainReportFilter.Length > 0 Then MainFilter = MainFilter & IIf(MainFilter.Length > 0, " AND ", "") & MainReportFilter
        If DateCoverageFilter.Length > 0 Then MainFilter = MainFilter & IIf(MainFilter.Length > 0, " AND ", "") & DateCoverageFilter
        MainFilter = IIf(MainFilter.Length > 0, "WHERE ", "") & MainFilter

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_SickOnboardHistory "

        'Append Condition and Sorting in SQL statement
        cSQL = cSQL & MainFilter & " "

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindReportControls(MainReport)
        BindData(MainReport.txtDateStart, "Text", Nothing, "ActDateStart", "{0:dd-MMM-yyyy}")
        BindData(MainReport.txtDateEnd, "Text", Nothing, "ActDateEnd", "{0:dd-MMM-yyyy}")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_VslName, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
