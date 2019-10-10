
Public Class CrewWithHigherLicense

    Private MainReport As New rptCrewHigherLicense

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
        
        If Len(Trim(MCode)) > 0 Then
            strRange = MonthName(CDate(dateEnd).Month) & " " & GetDaysOfMonth(dateEnd).ToString & ", " & CDate(dateEnd).Year
        End If
        Dim AgentName As String = MPSDB.DLookUp("Name", "ManAgentList", "", "PKey='" & AgentCode & "'")
        '---------------------------------------------------------------------------------------------------------------------------------------

        cSQL = "EXEC dbo.SP_CrewWithHigherLicense  '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',1"
        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        With MainReport
            .CrewHL.DataSource = dt
            .celDesc.Text = "THE TABLE SHOWS THE NUMBER OF CREW WHO HAS HIGHER LICENSE AS OF " & strRange.ToUpper & "."
            .celRankDept.DataBindings.Add("Text", Nothing, "RankDept")
            .celCrewName.DataBindings.Add("Text", Nothing, "CrewName")
            .celVslName.DataBindings.Add("Text", Nothing, "VslName")
            .celRank.DataBindings.Add("Text", Nothing, "CurrRank")
            .celHLRank.DataBindings.Add("Text", Nothing, "HLRank")
            .celStat.DataBindings.Add("Text", Nothing, "Stat")
            .celRemarks.DataBindings.Add("Text", Nothing, "Remarks")

            .grpRankDept.GroupFields.Add(New GroupField("RankDeptSort")) 'add Rank Dept
        End With


        'Summary Crew With Higher License
        With MainReport
            .CrewHLSummary.DataSource = MPSDB.CreateTable("EXEC dbo.SP_CrewWithHigherLicense  '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',2")
            .celRankDesc.DataBindings.Add("Text", Nothing, "RankDesc")
            .celCrewCount.DataBindings.Add("Text", Nothing, "CrewCount")

            '==Total==
            .celTCrewCount.DataBindings.Add("Text", Nothing, "CrewCount")

        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub


End Class
