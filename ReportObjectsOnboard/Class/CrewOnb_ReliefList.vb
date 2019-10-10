Imports Reports

Public Class CrewOnb_ReliefList
    Public MainReport As New rptCrewOnb_ReliefList

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT *, SUBSTRING(CONVERT(varchar,ReliefDate,112),1,6) ReliefYearMonth, DATENAME(MONTH,ReliefDate) ReliefMonth, DATENAME(DAY,ReliefDate) ReliefDay FROM rpt_CrewOnb_ReliefList "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
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
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.lblMonth, "Text", Nothing, "ReliefMonth")
        BindData(MainReport.celMonth, "Text", Nothing, "ReliefMonth")
        BindData(MainReport.celDay, "Text", Nothing, "ReliefDay")
        BindData(MainReport.celReliever, "Text", Nothing, "Reliever")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "ReliefYearMonth", REPORT_DETAIL.SortOption.GetSortValueCode("ReliefDate"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
