Public Class AdminBank
    Public MainReport As New rptAdminBank

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM dbo.tblAdmBank "

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
        BindData(MainReport.celBankName, "Text", Nothing, "Name")
        BindData(MainReport.celAbbrv, "Text", Nothing, "Abbrv")
        BindData(MainReport.celSortCode, "Text", Nothing, "SortCode")
        BindData(MainReport.celSwitfCode, "Text", Nothing, "SwiftCode")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Detail Report
        'BindData(MainReport.celBranchCount, "Text", Nothing, "BranchAddr")
        BindData(MainReport.celBranchAddr, "Text", Nothing, "BranchAddr")
        MainReport.Detail_Branches.SortFields.Add(New GroupField("BranchAddr", XRColumnSortOrder.Descending))

        LoadDataToDetailReport(MainReport.DetailReport_Branch, "SELECT *, dbo.AssembleAddress(Bldg, St, PartofCity, ct.Name, c.Name) as BranchAddr  FROM dbo.tblAdmBranch br LEFT JOIN dbo.tblAdmCity ct ON br.FKeyCity = ct.PKey LEFT JOIN dbo.tblAdmCntry c ON br.FKeyCntry = c.Name ")
        AddHandler MainReport.DetailReport_Branch.BeforePrint, AddressOf DetailReport_Branch_BeforePrint
        '---------------------------------------------------------------------------------------------------------------------------------------

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Main, "Name", FieldSortOrder.None)

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub DetailReport_Branch_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim drb As New DevExpress.XtraReports.UI.DetailReportBand
        drb = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)

        drb.FilterString = "FKeyBank='" & MainReport.GetCurrentColumnValue("PKey").ToString & "'"

    End Sub
End Class
