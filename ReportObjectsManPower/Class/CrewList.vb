Public Class CrewList


    Private MainReport As New rptCrewList

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
            strRange = MonthName(CDate(dateStart).Month) & " 01, " & CDate(dateStart).Year & _
                    " to " & MonthName(CDate(dateEnd).Month) & " " & GetDaysOfMonth(dateEnd).ToString & ", " & CDate(dateEnd).Year & "."
        End If
        Dim AgentName As String = MPSDB.DLookUp("Name", "ManAgentList", "", "PKey='" & AgentCode & "'")


        cSQL = "EXEC SP_CrewList '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "'"
        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------
        With MainReport
            .DataSource = dt
            .celDesc.Text = "THE TABLE SHOWS THE NUMBER OF CREWS ON-BOARD  FROM " & strRange.ToUpper
            .celVSL.DataBindings.Add("Text", Nothing, "VslName")
            .celCrewName.DataBindings.Add("Text", Nothing, "CrewName")
            .celRank.DataBindings.Add("Text", Nothing, "RankName")
            .celAge.DataBindings.Add("Text", Nothing, "Age")
            .celDateSON.DataBindings.Add("Text", Nothing, "DateSON", "{0:dd-MMM-yyyy}")
            .celDateSOFF.DataBindings.Add("Text", Nothing, "DateSOFF", "{0:dd-MMM-yyyy}")
            .celLOC.DataBindings.Add("Text", Nothing, "LOC") 'loc
            .celDL.DataBindings.Add("Text", Nothing, "DaysLeft") 'Days Left
            .celFormerVsl.DataBindings.Add("Text", Nothing, "FormerVsl")
            .celHireStat.DataBindings.Add("Text", Nothing, "HireStatus")
            .celAvailAp.DataBindings.Add("Text", Nothing, "Appraisal") 'Appraisal
            .celServPrin.DataBindings.Add("Text", Nothing, "ServPrin")
            .celServRank.DataBindings.Add("Text", Nothing, "ServRank")
            .celServTotal.DataBindings.Add("Text", Nothing, "ServTotal")

            .celRankGroup.DataBindings.Add("Text", Nothing, "RankGroup")

            '== Total == 
            .celTAgeAvg.DataBindings.Add("Text", Nothing, "Age")
            '== Group == 
            .grpVSL.GroupFields.Add(New GroupField("VslName")) 'Vessel Name
            .GroupHeader_RankGroup.GroupFields.Add(New GroupField("RankGroupSort")) 'add Rank Group
            .GroupHeader_RankGroup.GroupFields("RankGroupSort").SortOrder = XRColumnSortOrder.Ascending 'Sorting

        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub


End Class
