Public Class CrewAsh_New
    Public MainReport As New rptCrewAsh_New

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_CrewAsh_New "

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

        BindData(MainReport.celAgent, "Text", Nothing, "AgentName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celPlanRank, "Text", Nothing, "PlanRankName")
        BindData(MainReport.celDateAccepted, "Text", Nothing, "DateAccepted", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celPlanVsl, "Text", Nothing, "PlanVslName")
        BindData(MainReport.celPlanJoinDate, "Text", Nothing, "PlanJoinDate", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celAgentCnt, "Text", Nothing, "Crew")
        BindData(MainReport.celAgentBot, "Text", Nothing, "AgentName")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "AgentName", REPORT_DETAIL.SortOption.GetSortValueCode("AgentName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
