Imports Utilities
Imports MPS4

Public Class Amosup
    Public MainReport As New rptAMOSUP

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM rpt_AMOSUP_CONTRACT "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
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


        BindData(MainReport.txtSurname, "Text", Nothing, "surname")
        BindData(MainReport.txtFName, "Text", Nothing, "givenname")
        BindData(MainReport.txtMName, "Text", Nothing, "middlename")
        BindData(MainReport.txtHomeAddress, "Text", Nothing, "addr")
        BindData(MainReport.txtPosition, "Text", Nothing, "Rank")
        '!!!!!! BindData(MainReport.txtMedCertIssueOn, "Text", Nothing, "???????")
        BindData(MainReport.txtEstimatedTime, "Text", Nothing, "LOC")
        '!!!!!! BindData(MainReport.txtPortTaken, "Text", Nothing, "?????")
        BindData(MainReport.txtNationality, "Text", Nothing, "Nat")
        BindData(MainReport.txtPassportNo, "Text", Nothing, "Passport")
        BindData(MainReport.txtSeamansBookNo, "Text", Nothing, "SIRBNo")
        BindData(MainReport.txtShippingCompany, "Text", Nothing, "PrinName")
        BindData(MainReport.txtShippingCoyAddress, "Text", Nothing, "PrinAddr")
        BindData(MainReport.txtVessel, "Text", Nothing, "VslName")
        BindData(MainReport.txtOfficialNo, "Text", Nothing, "IMONo")
        BindData(MainReport.txtFlag, "Text", Nothing, "Flag")
        '!!!!!! BindData(MainReport.txtTermsContractAnd, "Text", Nothing, "?????")
        '!!!!!! BindData(MainReport.txtTermsContractDated, "Text", Nothing, "?????")
        BindData(MainReport.txtEmployPeriod, "Text", Nothing, "LOC")
        BindData(MainReport.txtBasic, "Text", Nothing, "Basic")
        '!!!!!! BindData(MainReport.txtWagesFromAndIncluding, "Text", Nothing, "?????")
        BindData(MainReport.txtHoursOfWork, "Text", Nothing, "WorkHours")
        BindData(MainReport.txtWeekDayOTRate, "Text", Nothing, "OT")
        '!!!!!! BindData(MainReport.txtHolidayOTRate, "Text", Nothing, "?????")
        BindData(MainReport.txtLeave, "Text", Nothing, "LeavePay")
        '!!!!!! BindData(MainReport.txtDailyLeavePay, "Text", Nothing, "?????")
        '!!!!!! BindData(MainReport.txtDailySubsAllowOnLeave, "Text", Nothing, "?????")
        '!!!!!! BindData(MainReport.txtOtherTerms, "Text", Nothing, "?????")
        BindData(MainReport.txtLeave, "Text", Nothing, "CrewSign")

        REPORT_DETAIL.MainReport = MainReport
    End Sub

End Class
