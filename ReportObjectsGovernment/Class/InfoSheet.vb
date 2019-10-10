Imports Utilities
Imports MPS4

Public Class InfoSheet
    Public MainReport As New rptInfoSheet

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT *, (HouseNo + ' ' + Street + ' ' + PartofCity + ' ' + City + ' ' + Province + ' ' + Country) AS CrewAddr FROM rpt_InfoSheet "

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

        BindData(MainReport.celSSS, "Text", Nothing, "SSS")
        BindData(MainReport.celSRC, "Text", Nothing, "SRC")
        BindData(MainReport.celPhilHealth, "Text", Nothing, "PhilHealth")

        BindData(MainReport.celLName, "Text", Nothing, "LName")
        BindData(MainReport.celFName, "Text", Nothing, "FName")
        BindData(MainReport.celMName, "Text", Nothing, "MName")
        BindData(MainReport.celCrewAddr, "Text", Nothing, "CrewAddr")
        BindData(MainReport.celCrewTel, "Text", Nothing, "CrewTel")
        BindData(MainReport.celCrewCel, "Text", Nothing, "ContactNo")
        BindData(MainReport.celCrewEmail, "Text", Nothing, "Email")
        BindData(MainReport.celCrewDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celCrewPOB, "Text", Nothing, "POB")
        BindData(MainReport.celCrewSIRB, "Text", Nothing, "SIRB")
        BindData(MainReport.celCrewEduc, "Text", Nothing, "Educ")
        BindData(MainReport.celCrewPP, "Text", Nothing, "Passport")
        BindData(MainReport.celCrewSpouse, "Text", Nothing, "Spouse")
        BindData(MainReport.celCrewMother, "Text", Nothing, "Mother")

        BindData(MainReport.celBenefName, "Text", Nothing, "AllotteeName")
        BindData(MainReport.celBenefRel, "Text", Nothing, "RelationshipToAllottee")
        BindData(MainReport.celBenefAddr, "Text", Nothing, "Addr")

        BindData(MainReport.celAllottee, "Text", Nothing, "Allottee")

        BindData(MainReport.celDepName, "Text", Nothing, "AllotteeName")
        BindData(MainReport.celDepSex, "Text", Nothing, "Sex")
        BindData(MainReport.celDepRel, "Text", Nothing, "RelationshipToAllottee")
        BindData(MainReport.celDepDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")

        BindData(MainReport.celPrinName, "Text", Nothing, "Employer")
        BindData(MainReport.celPrinAddr, "Text", Nothing, "Addr")
        BindData(MainReport.celPrinEmail, "Text", Nothing, "PrinEmail")
        BindData(MainReport.celCrewVsl, "Text", Nothing, "VslName")
        BindData(MainReport.celPrinTel, "Text", Nothing, "TelNo")
        BindData(MainReport.celCrewRank, "Text", Nothing, "Position")
        BindData(MainReport.celCrewLOC, "Text", Nothing, "LOC")
        BindData(MainReport.celCrewBasic, "Text", Nothing, "SalaryAmt")
        BindData(MainReport.celCrewBasicCurr, "Text", Nothing, "SalaryCurr")
        BindData(MainReport.celLastDateSOff, "Text", Nothing, "LastDateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateDep, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        MainReport.celCompany.Text = MPSDB.GetConfig("NAME").ToUpper

        BindData(MainReport.celCrewProper, "Text", Nothing, "CrewProper")

        AddHandler MainReport.GroupHeader1.BeforePrint, AddressOf SetGroupHeader_BeforePrint
        LoadDetailReport(MainReport.DetailReport, "SELECT * FROM Rpt_CrewNextOfKin_All WHERE rn <= 3")
        LoadDetailReport(MainReport.DetailReport1, "SELECT * FROM Rpt_Remittance WHERE WAllot = 1")
        LoadDetailReport(MainReport.DetailReport2, "SELECT *, (CASE WHEN SexCode = 1 THEN 'M' ELSE 'F' END) Sex FROM Rpt_CrewNextOfKin_All WHERE rn <= 3 and benef = 1")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew")) ' REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        
        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub SetGroupHeader_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Select Case CType(MainReport.GetCurrentColumnValue("SexCode").ToString, Integer)
            Case 1
                MainReport.chkM.Checked = True
                MainReport.chkF.Checked = False
            Case Else
                MainReport.chkM.Checked = False
                MainReport.chkF.Checked = True
        End Select

        Select Case MainReport.GetCurrentColumnValue("FKeyCivilStat").ToString.ToUpper
            Case "SYSCSSINGLE"
                MainReport.chkSingle.Checked = True
                MainReport.chkWidow.Checked = False
                MainReport.chkMarried.Checked = False
                MainReport.chkSeperated.Checked = False
            Case "SYSCSWIDOW"
                MainReport.chkSingle.Checked = False
                MainReport.chkWidow.Checked = True
                MainReport.chkMarried.Checked = False
                MainReport.chkSeperated.Checked = False
            Case "SYSCSMARRIED"
                MainReport.chkSingle.Checked = False
                MainReport.chkWidow.Checked = False
                MainReport.chkMarried.Checked = True
                MainReport.chkSeperated.Checked = False
            Case "SYSCSSEPARATED"
                MainReport.chkSingle.Checked = False
                MainReport.chkWidow.Checked = False
                MainReport.chkMarried.Checked = False
                MainReport.chkSeperated.Checked = True
            Case Else
                MainReport.chkSingle.Checked = False
                MainReport.chkWidow.Checked = False
                MainReport.chkMarried.Checked = False
                MainReport.chkSeperated.Checked = False
        End Select
    End Sub

    Private Sub SetDetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand).FilterString = "FKeyIDNbr='" & MainReport.GetCurrentColumnValue("IDNbr").ToString & "'"
        If TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand).RowCount = 0 Then
            'TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand).Visible = False
        End If
    End Sub

    Private Sub LoadDetailReport(sender As System.Object, sql As String)
        Dim detailReport As DetailReportBand
        Dim dt_sub As DataTable
        dt_sub = MPSDB.CreateTable(sql)
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.DataSource = dt_sub
        AddHandler detailReport.BeforePrint, AddressOf SetDetailReport_BeforePrint
    End Sub


End Class
