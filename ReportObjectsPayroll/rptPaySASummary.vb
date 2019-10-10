
Public Class rptPaySASummary
    Public MainReport As New rptPaySASummaryReport

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString.Length = 0 Then
            MsgBox("Please select a Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
            Exit Sub
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("RefNo").ToString.Length = 0 Then
            MsgBox("Please select a RefNo to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
            Exit Sub
        End If
        Dim dt As DataTable
        Dim cSQL As String
        Dim Period As Integer = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        Dim FKeyPrinCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Principal")
        'Dim FKeyVslCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel", BaseFilterOption.GetFilterReturnWhat.EditValue, True)
        Dim RefNo As String = REPORT_DETAIL.FilterOption.GetFilterValue("RefNo")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "EXEC SP_PAY_MPOSummary " & Period & ",'" & RefNo & "'"

        'If MainReportFilter.Length > 0 Then
        '    cSQL = cSQL & " WHERE " & MainReportFilter & " "
        'End If

        'If Sorting.Length > 0 Then
        '    cSQL = cSQL & " ORDER BY " & Sorting & " "
        'End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        'MainReport.Name = REPORT_DETAIL.ReportObjectID
        With MainReport

            BindData(.txtVesselName, "Text", Nothing, "VslName")
            BindData(.txtRefName, "Text", Nothing, "RefNo")
            BindData(.colCrewName, "Text", Nothing, "CrewName")
            BindData(.colAllottee, "Text", Nothing, "AllotName")
            BindData(.colBank, "Text", Nothing, "Bank")
            BindData(.colAcctName, "Text", Nothing, "AcctName")
            BindData(.colAcctNo, "Text", Nothing, "AcctNbr")
            BindData(.colCurr, "Text", Nothing, "Currency")
            BindData(.colExRate, "Text", Nothing, "ExRate", "{0:n2}")
            BindData(.colEarn, "Text", Nothing, "TcEarn", "{0:n2}")
            BindData(.colDed, "Text", Nothing, "TcDed", "{0:n2}")
            BindData(.colTotal, "Text", Nothing, "TotalMPOcAmt", "{0:n2}")
            BindData(.colTEarn, "Text", Nothing, "TcEarn", "{0:n2}")
            BindData(.colTDed, "Text", Nothing, "TcDed", "{0:n2}")
            BindData(.colTotalMPO, "Text", Nothing, "TotalMPOcAmt", "{0:n2}")

            'BindData(.colCrewName, "Text", Nothing, "AgentName")
            'BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
            'BindData(MainReport.celPlanRank, "Text", Nothing, "PlanRankName")z
            'BindData(MainReport.celDateAccepted, "Text", Nothing, "DateAccepted", "{0:dd-MMM-yyyy}")
            'BindData(MainReport.celPlanVsl, "Text", Nothing, "PlanVslName")
            'BindData(MainReport.celPlanJoinDate, "Text", Nothing, "PlanJoinDate", "{0:dd-MMM-yyyy}")
            'BindData(MainReport.celAgentCnt, "Text", Nothing, "Crew")
            'BindData(MainReport.celAgentBot, "Text", Nothing, "AgentName")

            AddFieldsToGroupHeaderBand(MainReport.CurrGroup, "Currency", 1)
            AddFieldsToGroupHeaderBand(MainReport.VslGroup, "VslCode", 1)
            'AddFieldsToGroupHeaderBand(MainReport.CurrGroup, "FKeyCurr")
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
