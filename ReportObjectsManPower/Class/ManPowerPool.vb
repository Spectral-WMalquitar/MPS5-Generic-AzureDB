Imports Utilities
Imports MPS4

Public Class ManPowerPool

    Private MainReport As New rptManPower

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim isYearStart As Boolean = False, AgentCode As String = "", FltCode As String = "", MCode As String = "", strRange As String = ""
        Dim dateStart As String, dateEnd As String

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Get Filter Value
        AgentCode = IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Agent"), "")
        FltCode = IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Fleet"), "")
        MCode = IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Period"), "")
        If REPORT_DETAIL.FilterOption.GetFilterValue("Year Start (Period)").ToString.Length = 0 Then
            isYearStart = False
        Else
            isYearStart = IIf(REPORT_DETAIL.FilterOption.GetFilterValue("Year Start (Period)") <> 0, True, False)
        End If

        If AgentCode = "" Then
            MsgBox("Please select Agent.", MsgBoxStyle.Critical, GetAppName)
            Exit Sub
        End If
        If FltCode = "" Then
            MsgBox("Please select Fleet.", MsgBoxStyle.Critical, GetAppName)
            Exit Sub
        End If
        If MCode = "" Then
            MsgBox("Please select Period.", MsgBoxStyle.Critical, GetAppName)
            Exit Sub
        End If

        If isYearStart Then
            dateStart = MCode.Substring(0, 4) & "-01-01"
        Else
            dateStart = MCode.Substring(0, 4) & "-" & MCode.Substring(4, 2) & "-01"
        End If
        dateEnd = MCode.Substring(0, 4) & "-" & MCode.Substring(4, 2) & "-" & Date.DaysInMonth(MCode.Substring(0, 4), MCode.Substring(4, 2))

        '---------------------------------------------------------------------------------------------------------------------------------------
        cSQL = "EXEC dbo.SP_ManPowerPool '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',1"
        '---------------------------------------------------------------------------------------------------------------------------------------
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls

        If Len(Trim(MCode)) > 0 Then
            strRange = MonthName(CDate(dateEnd).Month) & " " & GetDaysOfMonth(dateEnd).ToString & ", " & CDate(dateEnd).Year
        End If
        Dim AgentName As String = MPSDB.DLookUp("Name", "ManAgentList", "", "PKey='" & AgentCode & "'")

        'BindReportControls(MainReport)
        With MainReport
            .ManPower.DataSource = dt
            .celAgentCode.Text = AgentName
            .celRange.Text = "As of " & strRange
            .celVslGrpDesc.Text = "THE TABLE SHOWS THE PROFILE OF THE STATED POSITIONS OF FILIPINO CREW ONBOARD AS OF " & strRange.ToUpper
            .celRankName.DataBindings.Add("Text", Nothing, "RankName")
            .celOnbExCrew.DataBindings.Add("Text", Nothing, "rehiredCrew")
            .celOnbNewCrew.DataBindings.Add("Text", Nothing, "newCrew")
            .celAsh.DataBindings.Add("Text", Nothing, "ashCrew")
            .celAvailApp.DataBindings.Add("Text", Nothing, "appCrew")
            .celTotalPool.DataBindings.Add("Text", Nothing, "TotalPool")
            .celReserv.DataBindings.Add("Text", Nothing, "ReservedPool")
            .celVar.DataBindings.Add("Text", Nothing, "Variance")

            '== Total ==
            .tExCrew.DataBindings.Add("Text", Nothing, "rehiredCrew")
            .tNewCrew.DataBindings.Add("Text", Nothing, "newCrew")
            .tAsh.DataBindings.Add("Text", Nothing, "ashCrew")
            .tApp.DataBindings.Add("Text", Nothing, "appCrew")
            .tPool.DataBindings.Add("Text", Nothing, "TotalPool")
            .tResrv.DataBindings.Add("Text", Nothing, "ReservedPool")
            .tVar.DataBindings.Add("Text", Nothing, "Variance")
            .tExNew.DataBindings.Add("Text", Nothing, "TotalOnb")

            '== tTotal
            '.ttAsh.DataBindings.Add("Text", Nothing, "ASHCREW")
            '.ttApp.DataBindings.Add("Text", Nothing, "APPCREW")
            '.ttTpool.DataBindings.Add("Text", Nothing, "TOTALPOOL")
            '.ttResv.DataBindings.Add("Text", Nothing, "RESVPOOL")
            '.ttVar.DataBindings.Add("Text", Nothing, "VARIANCE")

        End With

        '2nd Part of the Report
        cSQL = "EXEC dbo.SP_ManPowerPool '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',2"
        dt = MPSDB.CreateTable(cSQL)
        With MainReport
            .ManPoolVSL.DataSource = dt
            .celVslName.DataBindings.Add("Text", Nothing, "VslName")
            .celExCrew.DataBindings.Add("Text", Nothing, "rehiredCrew")
            .celNewCrew.DataBindings.Add("Text", Nothing, "newCrew")
            .celTotal.DataBindings.Add("Text", Nothing, "TotalOnb")

            '=== TOTAL ===
            .celTExCrew.DataBindings.Add("Text", Nothing, "rehiredCrew")
            .celTNewCrew.DataBindings.Add("Text", Nothing, "newCrew")
            .celTTotal.DataBindings.Add("Text", Nothing, "TotalOnb")
        End With

        MainReport.celNote.Text = IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Note"), "")


        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub

End Class
