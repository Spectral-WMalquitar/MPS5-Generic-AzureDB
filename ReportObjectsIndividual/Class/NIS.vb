Imports Utilities
Imports MPS4

Public Class NIS
    Public MainReport As New rptNIS

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        'Dim WhereList As String = REPORT_DETAIL.SelectedRecordList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim AgentCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Agent", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        '"(IDNbr IN ('SPECT0000012154')) AND ((FKeyPrin is null OR FKeyPrin IN ('SPECT0000000002', 'SPECT0000000004', 'SPECT0000000005', 'SPECT0000000006', 'SPECT0000000012', 'SPECT0000000013', 'SPECT0000000015')))"
        'cSQL = "SELECT * FROM rpt_NIS where IDNbr in " & WhereList
        cSQL = "SELECT * FROM rpt_NIS "

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
            MainReport.chkCommencing.Checked = True
        ElseIf EmployStat = "2" Then
            MainReport.chkChange.Checked = True
        ElseIf EmployStat = "3" Then
            MainReport.chkTermination.Checked = True
        End If

        BindData(MainReport.txtDateBirthIdentityNo, "Text", Nothing, "NIS_No")
        BindData(MainReport.txtSurname, "Text", Nothing, "LNAME")
        BindData(MainReport.txtFirstname, "Text", Nothing, "FName")
        BindData(MainReport.txtMiddleName, "Text", Nothing, "MName")
        BindData(MainReport.txtCitizenship, "Text", Nothing, "Citizenship")
        BindData(MainReport.txtSexCode, "Text", Nothing, "SexCode")
        BindData(MainReport.txtMaritalStat, "Text", Nothing, "FKeyCivilStat")
        BindData(MainReport.txtCompleteAddress, "Text", Nothing, "Addr")
        BindData(MainReport.txtCntryDomicile, "Text", Nothing, "CntryDomicile")
        BindData(MainReport.txtNameEmployer, "Text", Nothing, "Employer")
        BindData(MainReport.txtAddressEmployer, "Text", Nothing, "EmployerAdd")
        BindData(MainReport.txtTelefaxEmployer, "Text", Nothing, "EmployerTelefax")
        '!!!!!! BindData(MainReport.txtMunicipalityEmployer, "Text", Nothing, "?????")
        '!!!!!! BindData(MainReport.txtOrgNumber, "Text", Nothing, "?????")

        BindData(MainReport.txtShipOwner, "Text", Nothing, "Shipowner")
        BindData(MainReport.txtShipOwnerAdd, "Text", Nothing, "ShipownerAdd")

        BindData(MainReport.txtNameVessel, "Text", Nothing, "VslName")
        '!!!!!! BindData(MainReport.txtSignalLetter, "Text", Nothing, "?????")
        '!!!!!! BindData(MainReport.txtInitialPayDate, "Text", Nothing, "?????")
        'BindData(MainReport.txtDateCommencing, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        'BindData(MainReport.txtPositionNewPos, "Text", Nothing, "RankName")
        'BindData(MainReport.txtDateChangePos, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        'BindData(MainReport.txtDateTerminateService, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        'BindData(MainReport.txtDateTerminateEmployment, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        '!!!!!! BindData(MainReport.txtCompensatory, "Text", Nothing, "?????")
        '!!!!!! BindData(MainReport.txtPlaceAndDateEmployer, "Text", Nothing, "?????")
        '!!!!!! BindData(MainReport.txtPlaceAndDateAuthority, "Text", Nothing, "?????")
        MainReport.txtOnBehalf.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper
        MainReport.txtOnBehalfPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()


        REPORT_DETAIL.MainReport = MainReport
    End Sub

End Class
