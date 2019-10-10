Imports Reports

Public Class CrewList_wNotify
    Public MainReport As New rptCrewList_wNotify

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim dt_sub As DataTable
        Dim cSQL As String
        Dim cSQL_sub As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT VslName, RankName, RankSortCode, AgentName, Crew, COUNT(Allottee) AS crewAllot FROM rpt_CrewList_wNotify "
        cSQL_sub = "SELECT * FROM rpt_CrewList_wNotify "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
            cSQL_sub = cSQL_sub & " WHERE " & MainReportFilter & " "
        End If
        cSQL = cSQL & " GROUP BY VslName, RankName, RankSortCode, AgentName, Crew "
        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
            cSQL_sub = cSQL_sub & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)
        dt_sub = MPSDB.CreateTable(cSQL_sub)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        AddHandler MainReport.DetailReport.BeforePrint, AddressOf DetailReport_BeforePrint
        'MainReport.DetailReport.DataMember = "Crew"
        MainReport.Detail1.SortFields.Add(New GroupField("Allottee", XRColumnSortOrder.Ascending))

        MainReport.DataSource = dt
        MainReport.DetailReport.DataSource = dt_sub
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindData(MainReport.lblVessel, "Text", Nothing, "VslName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celAgent, "Text", Nothing, "AgentName")
        BindData(MainReport.celToNotify, "Text", Nothing, "Allottee")
        BindData(MainReport.celRelation, "Text", Nothing, "Relation")
        BindData(MainReport.celAddr, "Text", Nothing, "Addr")
        BindData(MainReport.celCntry, "Text", Nothing, "Cntry")
        BindData(MainReport.celTel, "Text", Nothing, "Tel")
        BindData(MainReport.celTotalContacts, "Text", Nothing, "crewAllot")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub DetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        MainReport.DetailReport.FilterString = "Crew='" & MainReport.GetCurrentColumnValue("Crew").ToString & "'"
        If IsDBNull(MainReport.DetailReport.GetCurrentColumnValue("Allottee")) Then
            MainReport.DetailReport.Visible = False
        Else
            MainReport.DetailReport.Visible = True
        End If
    End Sub
End Class
