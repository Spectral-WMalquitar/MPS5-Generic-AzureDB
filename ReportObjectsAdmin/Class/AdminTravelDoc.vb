Public Class AdminTravelDoc
    Public MainReport As New rptAdminTravelDoc

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM Rpt_AdminTravelDoc "

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
        BindData(MainReport.celSortCode, "Text", Nothing, "SortCode")
        BindData(MainReport.celName, "Text", Nothing, "DocName")
        BindData(MainReport.celDMSFileCode, "Text", Nothing, "FileTag")

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
