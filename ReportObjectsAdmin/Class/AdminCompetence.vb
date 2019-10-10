
Public Class AdminCompetence
    Public MainReport As New rptAdminCompetence

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM Rpt_AdminCompetence "

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

        MainReport.celCompanyName.Text = REPORT_DETAIL.DB.GetConfig("Name")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        BindData(MainReport.celCompetence, "Text", Nothing, "Competence")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celCert, "Text", Nothing, "Cert")
        BindData(MainReport.celCertCapacity, "Text", Nothing, "CertCapacity")
        BindData(MainReport.celCertCntry, "Text", Nothing, "CertCntry")
        BindData(MainReport.celCourse, "Text", Nothing, "Course")
        BindData(MainReport.celTravDoc, "Text", Nothing, "TravDoc")
        BindData(MainReport.celTravDocCntry, "Text", Nothing, "TravDocCntry")
        BindData(MainReport.celMedCert, "Text", Nothing, "MedCert")
        BindData(MainReport.celNatInfo, "Text", Nothing, "NatInfo")
        BindData(MainReport.celNatInfoCntry, "Text", Nothing, "NatInfoCntry")
        BindData(MainReport.celVslType, "Text", Nothing, "VslType")
        BindData(MainReport.celYoS, "Text", Nothing, "Yos")

        LoadDetailReport(MainReport.DetailReport_Cert, "SELECT * FROM Rpt_AdminCompetence_Cert")
        LoadDetailReport(MainReport.DetailReport_Course, "SELECT * FROM Rpt_AdminCompetence_Course")
        LoadDetailReport(MainReport.DetailReport_TravDoc, "SELECT * FROM Rpt_AdminCompetence_TravDoc")
        LoadDetailReport(MainReport.DetailReport_MedCert, "SELECT * FROM Rpt_AdminCompetence_MedCert")
        LoadDetailReport(MainReport.DetailReport_NatInfo, "SELECT * FROM Rpt_AdminCompetence_NatInfo")
        LoadDetailReport(MainReport.DetailReport_SeaServ, "SELECT * FROM Rpt_AdminCompetence_SeaServ")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "Competence", REPORT_DETAIL.SortOption.GetSortValueCode("Competence"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub SetDetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand).FilterString = "FKeyCompRank='" & MainReport.GetCurrentColumnValue("FKeyCompRank").ToString & "'"
        If TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand).RowCount = 0 Then
            TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand).Visible = False
        End If
    End Sub

    Private Sub LoadDetailReport(sender As System.Object, sql As String)
        Dim detailReport As DetailReportBand
        Dim dt_sub As DataTable
        dt_sub = MPSDB.CreateTable(sql)
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.DataSource = dt_sub
        AddHandler detailReport.BeforePrint, AddressOf SetDetailReport_BeforePrint
    End Sub

End Class
