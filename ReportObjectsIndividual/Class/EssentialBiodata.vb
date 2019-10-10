Imports MPS4
Imports Utilities
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.Parameters
Imports Reports.BaseReportBuilder

Public Class EssentialBiodata

    Private MainReport As New rptEssentialBiodata
    Private SubReport_Cert As New rptEssentialBiodatasub_Cert
    Private SubReport_Training As New rptEssentialBiodatasub_Training
    Private SubReport_SeaServ As New rptEssentialBiodatasub_SeaServ

    Public Sub New(ByVal db As SQLDB, ByVal ReportName As String, ByVal argsFilter As Object())
        Dim cSQL As String

        Dim MainReportFilter As String = argsFilter(0)
        Dim WhereList As String = argsFilter(1)
        Dim Sorting As String = argsFilter(2)
        Dim FilterDT As DataTable = argsFilter(3)
        Dim SortDT As DataTable = argsFilter(4)

        MainReport.Name = ReportName
        SetDefaultReportLabels(MainReport, db)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Main Report 
        cSQL = "SELECT		crew.IDNbr, " & _
               "            crew.COIDNo as CoIDNbr, " & _
               "            crew.Crew, " & _
               "            crew.LName, " & _
               "            crew.FName, " & _
               "            crew.MName, " & _
               "            crew.Nationality, " & _
               "            Null as DateApplied, " & _
               "            crew.DOB, " & _
               "            crew.Age, " & _
               "            crew.POB, " & _
               "            crew.RankSort, " & _
               "            crew_sbk.Number as SBK_Number, " & _
               "            cntry_sbk.name as SBK_Country, " & _
               "            crew_sbk.DateExpiry as SBK_DateExpiry, " & _
               "            crew_pp.Number as Passport_Number, " & _
               "            cntry_pp.name as Passport_Country, " & _
               "            crew_pp.DateExpiry as Passport_DateExpiry " & _
               "FROM        Rpt_BioInfo crew LEFT OUTER JOIN " & _
               "            Rpt_CrewSBK crew_sbk ON crew.idnbr = crew_sbk.fkeyidnbr LEFT OUTER JOIN " & _
               "            tbladmcntry cntry_sbk ON crew_sbk.fkeycntry = cntry_sbk.pkey LEFT OUTER JOIN " & _
               "            RptCrewPassport crew_pp ON crew.idnbr = crew_pp.fkeyidnbr LEFT OUTER JOIN " & _
               "            tbladmcntry cntry_pp ON crew_pp.fkeycntry = cntry_pp.pkey "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & "WHERE " & MainReportFilter & " "
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Note: Sorting should be applied from the report bands, not on source
        If Sorting.Length > 0 Then
            cSQL = cSQL & "ORDER BY " & Sorting & " "
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        If dt Is Nothing Then
            MsgBox("Unable to generate report source.", vbExclamation)
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------
        'EXIT IF REPORT HAS NO DATA
        If Not ReportHasData(dt, True) Then Exit Sub

        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Certificate Sub 
        cSQL = "SELECT     * " & _
               "FROM       dbo.Rpt_CrewDocument " & _
               "WHERE      FKeyDocGroup = 'SYSLICCERT' AND " & _
               "           IDNbr IN " & WhereList & " " & _
               "ORDER BY   DocName, DateIssue Desc;"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Cert.DataSource = dt

        'Add a parameter for filtering
        SubReport_Cert.Parameters.Add(New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty})
        SubReport_Cert.FilterString = "[IDNbr]==?IDNbr"

        MainReport.subrpt_cert.ReportSource = SubReport_Cert

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Training Sub 
        cSQL = "SELECT     PKey,IDNbr, CourseName, CourseInstName, DateIssue, DateExpiry " & _
               "FROM       dbo.Rpt_CrewTraining " & _
               "WHERE      IDNbr IN " & WhereList & " " & _
               "ORDER BY   DateIssue Desc;"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Training.DataSource = dt

        'Add a parameter for filtering
        SubReport_Training.Parameters.Add(New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty})
        SubReport_Training.FilterString = "[IDNbr]==?IDNbr"

        MainReport.subrpt_training.ReportSource = SubReport_Training

        'Arrange Data Source : Sea Service Sub 
        cSQL = "SELECT     * " & _
               "FROM       dbo.Rpt_CrewActAll " & _
               "WHERE      IDNbr IN " & WhereList & ";"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_SeaServ.DataSource = dt
        MainReport.subrpt_services.ReportSource = SubReport_SeaServ

        'Add a parameter for filtering
        Dim param_ss As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_SeaServ.Parameters.Add(param_ss)
        SubReport_SeaServ.FilterString = "[IDNbr]==?IDNbr"

        SubReport_SeaServ.txtDateStart.DataBindings.Add("Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
        SubReport_SeaServ.txtDateEnd.DataBindings.Add("Text", Nothing, "DateEnd", "{0:dd-MMM-yyyy}")
        '---------------------------------------------------------------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)
        BindReportControls(SubReport_Cert)
        BindReportControls(SubReport_Training)
        BindReportControls(SubReport_SeaServ)

        MainReport.txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        SubReport_Cert.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_Cert.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
        SubReport_Training.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_Training.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "Crew", GetFieldSortCodeFromDT(SortDT, "Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, SortDT, "Crew")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Handle the Subreport.BeforePrint event for filtering details dynamically
        AddHandler SubReport_Cert.BeforePrint, AddressOf subreportCert_BeforePrint
        AddHandler SubReport_Training.BeforePrint, AddressOf subreportTraining_BeforePrint
        AddHandler SubReport_SeaServ.BeforePrint, AddressOf subreportSeaServ_BeforePrint
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Preview Report
        MainReport.ShowPreviewDialog()
    End Sub

    Private Sub subreportCert_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub subreportTraining_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub subreportSeaServ_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub
End Class
