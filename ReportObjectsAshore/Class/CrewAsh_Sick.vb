
Public Class CrewAsh_Sick
    Public MainReport As New rptCrewAsh_Sick

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_CrewAsh_Sick "

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
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celVessel, "Text", Nothing, "VslName")
        BindData(MainReport.celDateAcq, "Text", Nothing, "DateAcq", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celJoinDate, "Text", Nothing, "DateSON", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateSOff, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.chkWorkRelated, "Text", Nothing, "WorkRel")
        BindData(MainReport.celVslOnb, "Text", Nothing, "VslOnb")
        BindData(MainReport.celRemarks, "Text", Nothing, "Remarks")
        BindData(MainReport.celAgentCnt, "Text", Nothing, "Crew")
        BindData(MainReport.celAgentBot, "Text", Nothing, "AgentName")
        BindData(MainReport.celPrincipal, "Text", Nothing, "PrinName")
        BindData(MainReport.celPrincipalCnt, "Text", Nothing, "PrinName")
        BindData(MainReport.celPrincipalBot, "Text", Nothing, "PrinName")

        If REPORT_DETAIL.ReportObjectID.ToUpper = "rptCrewAsh_Sick_Prin".ToUpper Then
            AddFieldsToGroupHeaderBand(MainReport.GroupHeader2, "PrinName", REPORT_DETAIL.SortOption.GetSortValueCode("PrinName"))
        Else
            MainReport.GroupHeader2.Visible = False
            MainReport.GroupFooter2.Visible = False
        End If
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "AgentName", REPORT_DETAIL.SortOption.GetSortValueCode("AgentName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
