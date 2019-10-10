Public Class AdminPay_WagesOnboard
    Public MainReport As New rptAdminPay_WagesOnboard

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM (SELECT *, CASE WHEN DateType = 1 THEN 'Date Departed / Date Arrived' ELSE CASE WHEN DateType = 2 THEN 'Date Signed On / Off' ELSE '' END END as StartEndDate, CASE WHEN WageType = 1 THEN 'Earnings' ELSE CASE WHEN WageType = 2 THEN 'Deductions' ELSE '' END END as WageTypeDesc, CASE WHEN isnull(Prorata,0) = 1 THEN 'YES' ELSE 'NO' END as isProrata FROM dbo.tblAdmWageOnb) t "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.celCompanyName.Text = REPORT_DETAIL.DB.GetConfig("Name")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        BindData(MainReport.celWageType, "Text", Nothing, "WageTypeDesc")
        BindData(MainReport.celName, "Text", Nothing, "Name")
        BindData(MainReport.celSortCode, "Text", Nothing, "SortCode")
        BindData(MainReport.celStartEndDate, "Text", Nothing, "StartEndDate")
        BindData(MainReport.celProrata, "Text", Nothing, "isProrata")
        BindData(MainReport.celAccountingCode, "Text", Nothing, "AcctCode")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_WageType, "WageType", FieldSortOrder.Ascending)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
