
Public Class Training
    Private MainReport As New rptTraining
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

        cSQL = "EXEC dbo.SP_ManPoolTraining  '" & AgentCode & "','" & FltCode & "','" & dateStart & "','" & dateEnd & "'"
        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        With MainReport
            .DataSource = dt
            .celDesc.Text = "THE TABLE SHOWS THE NUMBER OF CREW WHO WERE TRAINED FROM " & strRange.ToUpper
            .celCourseType.DataBindings.Add("Text", Nothing, "CourseType")
            .celTraining.DataBindings.Add("Text", Nothing, "CourseName")
            .celDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")

            .celTotalCrewCount.DataBindings.Add("Text", Nothing, "DateIssue")
            .celCrewCount.DataBindings.Add("Text", Nothing, "DateIssue")
            .tTotal.DataBindings.Add("Text", Nothing, "DateIssue")
            .celTotalOverAll.DataBindings.Add("Text", Nothing, "DateIssue")

            'Grouping
            .grpCourseType.GroupFields.Add(New GroupField("CourseType")) 'group BY Course Type
            .grpTraining.GroupFields.Add(New GroupField("CourseName")) 'Group By Training Name
            .grpDateIss.GroupFields.Add(New GroupField("DateIssue")) 'Group By Date Issue
            .grpTraining.GroupFields("CourseName").SortOrder = XRColumnSortOrder.Ascending
            .grpDateIss.GroupFields("DateIssue").SortOrder = XRColumnSortOrder.Ascending

            AddHandler .grpTraining.BeforePrint, AddressOf Handle_BeforePrint
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub

    Private Sub Handle_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        If IsDBNull(MainReport.GetCurrentColumnValue("DateIssue")) Then
            MainReport.grpDateIss.Visible = False
        Else
            MainReport.grpDateIss.Visible = True
        End If
    End Sub




End Class
