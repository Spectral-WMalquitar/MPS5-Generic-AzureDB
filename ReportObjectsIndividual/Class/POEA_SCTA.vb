Imports Utilities
Imports MPS4

Public Class POEA_SCTA
    Public MainReport As New rptPOEA_SCTA

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        'Dim period As String = REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString

        'If period.Length = 0 Then
        '    MsgBox("Please select Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
        '    Exit Sub
        'End If

        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim AgentCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Agent", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        cSQL = "SELECT * FROM rpt_POEA_SCTA "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        'If period.Length > 0 Then
        '    cSQL = cSQL & " and Period = '" & period & "' "
        'End If

        'If AgentCode.Length > 0 Then
        '    cSQL = cSQL & " and FKeyAgent = '" & AgentCode & "' "
        'End If

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

        BindData(MainReport.txtSalutation, "Text", Nothing, "Salutation")
        BindData(MainReport.txtCrew, "Text", Nothing, "Crew")
        BindData(MainReport.txtDateOfBirth, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.txtPOB, "Text", Nothing, "POB")
        BindData(MainReport.txtAddressCadet, "Text", Nothing, "Address")
        BindData(MainReport.txtSIRBno, "Text", Nothing, "SBKno")
        BindData(MainReport.txtSRCno, "Text", Nothing, "SRCno")
        BindData(MainReport.txtNameAgent, "Text", Nothing, "Agent")
        BindData(MainReport.txtNameSponsorCompany, "Text", Nothing, "Employer")
        BindData(MainReport.txtAddressSponsorCompany, "Text", Nothing, "EmployerAddr")
        BindData(MainReport.txtNameVessel, "Text", Nothing, "Vessel")
        BindData(MainReport.txtIMOnoVessel, "Text", Nothing, "IMONo")
        BindData(MainReport.txtGRTvessel, "Text", Nothing, "GrossTon")
        BindData(MainReport.txtYearBuiltVessel, "Text", Nothing, "YrBuilt")
        BindData(MainReport.txtFlagVessel, "Text", Nothing, "Flag")
        BindData(MainReport.txtTypeVessel, "Text", Nothing, "VslType")

        '!!!!! BindData(MainReport.txtPeriod, "Text", Nothing, "00000")

        MainReport.txtDurationTraining.Text = REPORT_DETAIL.FilterOption.GetFilterValue("1.1 Duration of Training")
        MainReport.txtPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("1.2 Position")
        MainReport.txtMonthlyStipend.Text = REPORT_DETAIL.FilterOption.GetFilterValue("1.3 Monthly Stipend")
        MainReport.txtHoursTraining.Text = REPORT_DETAIL.FilterOption.GetFilterValue("1.4 Hours of Training")
        MainReport.txtPointsDeparture.Text = REPORT_DETAIL.FilterOption.GetFilterValue("1.5 Point of Departure")
        MainReport.txtCommecmentOfTraining.Text = REPORT_DETAIL.FilterOption.GetFilterValue("1.6 Commencement of Training")

        If REPORT_DETAIL.FilterOption.GetFilterValue("Contract Date") <> "" Then
            Dim daysss As Integer

            daysss = Day(REPORT_DETAIL.FilterOption.GetFilterValue("Contract Date"))

            MainReport.txtHandsThis.Text = daysss & GetSuffix(daysss)
            MainReport.txtDayOf.Text = MonthName(Month(REPORT_DETAIL.FilterOption.GetFilterValue("Contract Date")))
            MainReport.txt20.Text = Year(REPORT_DETAIL.FilterOption.GetFilterValue("Contract Date"))
        End If

        REPORT_DETAIL.MainReport = MainReport
    End Sub

    Private Function GetSuffix(day As String) As String
        Dim suffix As String = "th"

        If Integer.Parse(day) < 11 OrElse Integer.Parse(day) > 20 Then
            day = day.ToCharArray()(day.ToCharArray().Length - 1).ToString()
            Select Case day
                Case "1"
                    suffix = "st"
                    Exit Select
                Case "2"
                    suffix = "nd"
                    Exit Select
                Case "3"
                    suffix = "rd"
                    Exit Select
            End Select
        End If

        Return suffix
    End Function
End Class
