
Public Class Recruitment
    Private MainReport As New rptRecruitment

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

        '---------------------------------------------------------------------------------------------------------------------------------------

        cSQL = "EXEC SP_RECRUITMENT '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',1"
        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Recruitment
        With MainReport
            .celDesc1.Text = "THE NEXT TABLE SHOWS THE NUMBER OF NEW CREW, EX-CREW RECRUITED AND DEPLOYED PER MONTH INCLUDING NUMBER OF CREW WHO WHERE NOT DEPLOYED ON THE TIME FROM " & strRange.ToUpper

            Dim subRows As DataRow()
            Dim subDT As DataTable
            subRows = dt.Select("HireStat <> 'NON-DEPLOYED'")
            If subRows.Count() <> 0 Then
                subDT = subRows.CopyToDataTable()
                .Recruitment.DataSource = subDT
                .ccHireStat.DataBindings.Add("Text", Nothing, "HireStat")
                .celJAN.DataBindings.Add("Text", Nothing, "JAN")
                .celFEB.DataBindings.Add("Text", Nothing, "FEB")
                .celMAR.DataBindings.Add("Text", Nothing, "MAR")
                .celAPR.DataBindings.Add("Text", Nothing, "APR")
                .celMAY.DataBindings.Add("Text", Nothing, "MAY")
                .celJUN.DataBindings.Add("Text", Nothing, "JUN")
                .celJUL.DataBindings.Add("Text", Nothing, "JUL")
                .celAUG.DataBindings.Add("Text", Nothing, "AUG")
                .celSEP.DataBindings.Add("Text", Nothing, "SEP")
                .celOCT.DataBindings.Add("Text", Nothing, "OCT")
                .celNOV.DataBindings.Add("Text", Nothing, "NOV")
                .celDEC.DataBindings.Add("Text", Nothing, "DEC")
                .celTOTAL.DataBindings.Add("Text", Nothing, "TOTAL")
                .celPER.DataBindings.Add("Text", Nothing, "PERCENTAGE")

                '== TOTAL ==
                .tJAN.DataBindings.Add("Text", Nothing, "JAN")
                .tFEB.DataBindings.Add("Text", Nothing, "FEB")
                .tMAR.DataBindings.Add("Text", Nothing, "MAR")
                .tAPR.DataBindings.Add("Text", Nothing, "APR")
                .tMAY.DataBindings.Add("Text", Nothing, "MAY")
                .tJUN.DataBindings.Add("Text", Nothing, "JUN")
                .tJUL.DataBindings.Add("Text", Nothing, "JUL")
                .tAUG.DataBindings.Add("Text", Nothing, "AUG")
                .tSEP.DataBindings.Add("Text", Nothing, "SEP")
                .tOCT.DataBindings.Add("Text", Nothing, "OCT")
                .tNOV.DataBindings.Add("Text", Nothing, "NOV")
                .tDEC.DataBindings.Add("Text", Nothing, "DECE")
                .tTOTAL.DataBindings.Add("Text", Nothing, "TOTAL")
                .tPER.DataBindings.Add("Text", Nothing, "PERCENTAGE")

            End If

            subRows = dt.Select("HireStat = 'NON-DEPLOYED'")
            If subRows.Count() <> 0 Then
                subDT = subRows.CopyToDataTable()
                .NonDeployed.DataSource = subDT
                .celJAN_non.DataBindings.Add("Text", Nothing, "JAN")
                .celFEB_non.DataBindings.Add("Text", Nothing, "FEB")
                .celMAR_non.DataBindings.Add("Text", Nothing, "MAR")
                .celAPR_non.DataBindings.Add("Text", Nothing, "APR")
                .celMAY_non.DataBindings.Add("Text", Nothing, "MAY")
                .celJUN_non.DataBindings.Add("Text", Nothing, "JUN")
                .celJUL_non.DataBindings.Add("Text", Nothing, "JUL")
                .celAug_non.DataBindings.Add("Text", Nothing, "AUG")
                .celSEP_non.DataBindings.Add("Text", Nothing, "SEP")
                .celOCT_non.DataBindings.Add("Text", Nothing, "OCT")
                .celNOV_non.DataBindings.Add("Text", Nothing, "NOV")
                .celDEC_non.DataBindings.Add("Text", Nothing, "DEC")
                .celTOTAL_non.DataBindings.Add("Text", Nothing, "TOTAL")
                .celPER_non.DataBindings.Add("Text", Nothing, "PERCENTAGE")
            End If

        End With

        ''=== DEPLOYMENT ==
        With MainReport
            .Deployment.DataSource = MPSDB.CreateTable("EXEC SP_RECRUITMENT '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',2")
            .celDesc2.Text = "BELOW TABLE SHOWS THE DEPLOYMENT FROM " & strRange.ToUpper
            .celVSL.DataBindings.Add("Text", Nothing, "VslName")
            .celCrewName.DataBindings.Add("Text", Nothing, "CrewName")
            .celPORT.DataBindings.Add("Text", Nothing, "PlaceStart")
            .celDateDep.DataBindings.Add("Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
            .celCrewCount.DataBindings.Add("Text", Nothing, "CrewName")
            .celPOS.DataBindings.Add("Text", Nothing, "RankName")

            'Group
            .grpVSL.GroupFields.Add(New GroupField("VslName"))
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub



End Class
