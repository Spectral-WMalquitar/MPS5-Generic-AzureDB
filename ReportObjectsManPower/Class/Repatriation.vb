Imports Utilities
Imports MPS4

Public Class Repatriation

    Private MainReport As New rptRepatriation

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
        cSQL = "EXEC dbo.SP_REPATRIATION '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',1"
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        If Len(Trim(MCode)) > 0 Then
            strRange = MonthName(CDate(dateStart).Month) & " 01, " & CDate(dateStart).Year & _
                    " to " & MonthName(CDate(dateEnd).Month) & " " & GetDaysOfMonth(dateEnd).ToString & ", " & CDate(dateEnd).Year & "."
        End If
        Dim AgentName As String = MPSDB.DLookUp("Name", "ManAgentList", "", "PKey='" & AgentCode & "'")

        With MainReport
            .PreMatureRepat.DataSource = dt
            .celRangeDesc.Text = "THE TABLES SHOW THE DISTRIBUTION OF PRE-MATURE REPATRIATION FROM " & strRange.ToUpper
            .celSOFF.DataBindings.Add("Text", Nothing, "SOffReason")
            .celJAN.DataBindings.Add("Text", Nothing, "JAN")
            .celFEB.DataBindings.Add("Text", Nothing, "FEB")
            .celMAR.DataBindings.Add("Text", Nothing, "MAR")
            .celAPR.DataBindings.Add("Text", Nothing, "APR")
            .celMAY.DataBindings.Add("Text", Nothing, "MAY")
            .celJUN.DataBindings.Add("Text", Nothing, "JUN")
            .celJUL.DataBindings.Add("Text", Nothing, "JUL")
            .celAUG.DataBindings.Add("Text", Nothing, "AUG")
            .celSEPT.DataBindings.Add("Text", Nothing, "SEP")
            .celOCT.DataBindings.Add("Text", Nothing, "OCT")
            .celNOV.DataBindings.Add("Text", Nothing, "NOV")
            .celDEC.DataBindings.Add("Text", Nothing, "DEC")
            .celTOTAL.DataBindings.Add("Text", Nothing, "TOTAL")
            .celPer.DataBindings.Add("Text", Nothing, "PERCENTAGE")

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
            .tDEC.DataBindings.Add("Text", Nothing, "DEC")
            .tTotal.DataBindings.Add("Text", Nothing, "TOTAL")
            .tPER.DataBindings.Add("Text", Nothing, "PERCENTAGE")
        End With


        '=== Permature Repatriation ==
        strRange = MonthName(CDate(dateEnd).Month) & " " & GetDaysOfMonth(dateEnd).ToString & ", " & CDate(dateEnd).Year
        With MainReport
            .PreMatureCrew.DataSource = MPSDB.CreateTable("EXEC dbo.SP_REPATRIATION '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',2")
            .celCrewDesc.Text = "BELOW ARE THE DETAILS OF THE PRE-MATURE REPATRIATION AS OF " & strRange.ToUpper & "."
            .celSOffReason.DataBindings.Add("Text", Nothing, "SOffReason")
            .celCrewName.DataBindings.Add("Text", Nothing, "CrewName")
            .celRank.DataBindings.Add("Text", Nothing, "RankName")
            .celVsl.DataBindings.Add("Text", Nothing, "VslName")
            .celDateArr.DataBindings.Add("Text", Nothing, "DateArr", "{0:dd-MMM-yyyy}")
            .celRemarks.DataBindings.Add("Text", Nothing, "Remarks")

            'Group
            .SOFFReason.GroupFields.Add(New GroupField("SOffReason"))
        End With


        '== Contract Completion ==
        With MainReport
            .ContractCompletion.DataSource = MPSDB.CreateTable("EXEC dbo.SP_REPATRIATION '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "',3")
            .celCompDesc.Text = "THE TABLE SHOWS THE NUMBER OF CREW REPATRIATED DUE TO CONTRACT COMPLETION AS OF " & strRange.ToUpper & "."
            .celHireStat.DataBindings.Add("Text", Nothing, "HireStat")
            .ccJAN.DataBindings.Add("Text", Nothing, "JAN")
            .ccFEB.DataBindings.Add("Text", Nothing, "FEB")
            .ccMAR.DataBindings.Add("Text", Nothing, "MAR")
            .ccAPR.DataBindings.Add("Text", Nothing, "APR")
            .ccMAY.DataBindings.Add("Text", Nothing, "MAY")
            .ccJUN.DataBindings.Add("Text", Nothing, "JUN")
            .ccJUL.DataBindings.Add("Text", Nothing, "JUL")
            .ccAUG.DataBindings.Add("Text", Nothing, "AUG")
            .ccSEP.DataBindings.Add("Text", Nothing, "SEP")
            .ccOCT.DataBindings.Add("Text", Nothing, "OCT")
            .ccNOV.DataBindings.Add("Text", Nothing, "NOV")
            .ccDEC.DataBindings.Add("Text", Nothing, "DEC")
            .ccTOTAL.DataBindings.Add("Text", Nothing, "TOTAL")
            .ccPER.DataBindings.Add("Text", Nothing, "PERCENTAGE")

            '== TOTAL == 

            .ccTJAN.DataBindings.Add("Text", Nothing, "JAN")
            .ccTFEB.DataBindings.Add("Text", Nothing, "FEB")
            .ccTMAR.DataBindings.Add("Text", Nothing, "MAR")
            .ccTAPR.DataBindings.Add("Text", Nothing, "APR")
            .ccTMAY.DataBindings.Add("Text", Nothing, "MAY")
            .ccTJUN.DataBindings.Add("Text", Nothing, "JUN")
            .ccTJUL.DataBindings.Add("Text", Nothing, "JUL")
            .ccTAUG.DataBindings.Add("Text", Nothing, "AUG")
            .ccTSEP.DataBindings.Add("Text", Nothing, "SEP")
            .ccTOCT.DataBindings.Add("Text", Nothing, "OCT")
            .ccTNOV.DataBindings.Add("Text", Nothing, "NOV")
            .ccTDEC.DataBindings.Add("Text", Nothing, "DEC")
            .ccTTotal.DataBindings.Add("Text", Nothing, "TOTAL")
            .ccTPer.DataBindings.Add("Text", Nothing, "PERCENTAGE")

        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub


End Class
