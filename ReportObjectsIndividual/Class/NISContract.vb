Imports Utilities
Imports MPS4

Public Class NISContract
    Public MainReport As New rptNISContract

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        'Dim WhereList As String = REPORT_DETAIL.SelectedRecordList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim AgentCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Agent", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        'cSQL = "SELECT * FROM rpt_NISContract where IDNbr in " & WhereList
        cSQL = "SELECT * FROM rpt_NISContract "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        If AgentCode.Length > 0 Then
            cSQL = cSQL & " and FKeyAgent = '" & AgentCode & "' "
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

        Dim EmployStat As String
        EmployStat = REPORT_DETAIL.FilterOption.GetFilterValue("Employment Status", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()
        If EmployStat = "1" Then
            MainReport.chkNew.Checked = True
        ElseIf EmployStat = "2" Then
            MainReport.chkAlteration.Checked = True
        End If

        BindData(MainReport.txtMiddleName, "Text", Nothing, "MName")
        BindData(MainReport.txtFirstname, "Text", Nothing, "FName")
        '!!!!! BindData(MainReport.txtDateEngage, "Text", Nothing, "00000")
        '!!!!! BindData(MainReport.txtAgreementDate, "Text", Nothing, "00000")
        BindData(MainReport.txtBirthNo, "Text", Nothing, "NIS_No")
        BindData(MainReport.txtSurname, "Text", Nothing, "LNAME")
        '!!!!! BindData(MainReport.txtFirstAndMiddleName, "Text", Nothing, "00000")
        'BindData(MainReport.txtNationality, "Text", Nothing, "Citizenship")
        BindData(MainReport.txtHomeAddress, "Text", Nothing, "Addr")
        BindData(MainReport.txtPhone, "Text", Nothing, "Crew_Phone")
        BindData(MainReport.txtNextofKinName, "Text", Nothing, "NextOfKin")
        BindData(MainReport.txtNextofKinAddress, "Text", Nothing, "KinAddr")
        BindData(MainReport.txtNextofKinPhone, "Text", Nothing, "KinPhone")
        BindData(MainReport.txtEmployerName, "Text", Nothing, "Employer")
        BindData(MainReport.txtEmployerAddress, "Text", Nothing, "EmployerAdd")
        BindData(MainReport.txtLOC, "Text", Nothing, "LOC")
        '!!!!! BindData(MainReport.txtEmployerRegNo, "Text", Nothing, "00000")

        'BindData(MainReport.txtBasic, "Text", Nothing, "Basic", "Basic : {0}")
        'BindData(MainReport.txtWorkHours, "Text", Nothing, "WorkHours", "Work Hours : {0}")
        'BindData(MainReport.txtOT, "Text", Nothing, "OT", "OT : {0}")
        'BindData(MainReport.txtLeavePay, "Text", Nothing, "LeavePay", "Leave Pay : {0}")
        'BindData(MainReport.txtOtherEarn, "Text", Nothing, "otherEarn", "Other Earnings : {0}")

        '!!!!! BindData(MainReport.txtSpecialCondition, "Text", Nothing, "00000")
        BindData(MainReport.txtRankRating, "Text", Nothing, "RankNameFull")
        '!!!!! BindData(MainReport.txtWagesFromAndIncl, "Text", Nothing, "00000")
        '!!!!! BindData(MainReport.txtPossiblePlaceTermi, "Text", Nothing, "00000")
        '!!!!! BindData(MainReport.txtProbaPeriod, "Text", Nothing, "00000")
        '!!!!! BindData(MainReport.txtMutualPeriodNotice, "Text", Nothing, "00000")
        BindData(MainReport.txtNameVessel, "Text", Nothing, "VslName")
        '!!!!! BindData(MainReport.txtForSpecifiedPeriod, "Text", Nothing, "00000")
        '!!!!! BindData(MainReport.txtOneSpecifiedVoyage, "Text", Nothing, "00000")
        BindData(MainReport.txtReliefFor, "Text", Nothing, "ReliefFor")
        '!!!!! BindData(MainReport.txtTempoEmployment, "Text", Nothing, "00000")
        BindData(MainReport.txtCrew, "Text", Nothing, "CrewSign")
        MainReport.txtOnBehalf.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper
        MainReport.txtOnBehalfPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()


        REPORT_DETAIL.MainReport = MainReport
    End Sub

End Class
