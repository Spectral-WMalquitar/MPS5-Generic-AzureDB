Imports Utilities
Imports MPS4

Public Class InfoSheetOFW
    Public MainReport As New rptInfoSheetOFW

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM rpt_InfoSheet "

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

        BindData(MainReport.celLName, "Text", Nothing, "LName")
        BindData(MainReport.celFName, "Text", Nothing, "FName")
        BindData(MainReport.celNameExt, "Text", Nothing, "NameExt")
        BindData(MainReport.celMName, "Text", Nothing, "MName")

        BindData(MainReport.celHouseNo, "Text", Nothing, "HouseNo")
        BindData(MainReport.celLot, "Text", Nothing, "Lot")
        BindData(MainReport.celStreet, "Text", Nothing, "Street")
        BindData(MainReport.celSubdivision, "Text", Nothing, "Subdivision")
        BindData(MainReport.celBrgy, "Text", Nothing, "Brgy")
        BindData(MainReport.celCity, "Text", Nothing, "City")
        BindData(MainReport.celProvince, "Text", Nothing, "Province")
        BindData(MainReport.celZipcode, "Text", Nothing, "Zipcode")
        BindData(MainReport.celContactNo, "Text", Nothing, "ContactNo")
        BindData(MainReport.celEmail, "Text", Nothing, "Email")
        BindData(MainReport.celPassport, "Text", Nothing, "Passport")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celSex, "Text", Nothing, "Sex")
        BindData(MainReport.celReligion, "Text", Nothing, "Religion")
        BindData(MainReport.celCivilStat, "Text", Nothing, "CivilStat")
        BindData(MainReport.celEduc, "Text", Nothing, "Educ")
        BindData(MainReport.celCourse, "Text", Nothing, "Course")

        BindData(MainReport.celEmployer, "Text", Nothing, "Employer")
        BindData(MainReport.celAddr, "Text", Nothing, "Addr")
        BindData(MainReport.celTelNo, "Text", Nothing, "TelNo")
        BindData(MainReport.celSiteCountry, "Text", Nothing, "SiteCountry")
        BindData(MainReport.celPosition, "Text", Nothing, "Position")
        BindData(MainReport.celSalary, "Text", Nothing, "Salary")
        BindData(MainReport.celLOC, "Text", Nothing, "LOC")
        MainReport.celAgency.Text = MPSDB.GetConfig("NAME").ToUpper

        BindData(MainReport.celAllottee, "Text", Nothing, "AllotteeName")
        BindData(MainReport.celAllotRel, "Text", Nothing, "RelationshipToAllottee")
        BindData(MainReport.celAllotDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celAllotAddr, "Text", Nothing, "Addr")
        BindData(MainReport.celAllotContact, "Text", Nothing, "AllotContact")

        LoadDetailReport(MainReport.DetailReport, "SELECT *, Phone + '/' + Email AllotContact FROM Rpt_CrewNextOfKin_All")

        Dim strDate As String = REPORT_DETAIL.FilterOption.GetFilterValue("Date")
        If strDate.Length <> 0 Then
            MainReport.celDate.Text = Format(CDate(strDate), "dd-MMM-yyyy").ToUpper
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub SetDetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand).FilterString = "FKeyIDNbr='" & MainReport.GetCurrentColumnValue("IDNbr").ToString & "' AND rn <= 3"
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
