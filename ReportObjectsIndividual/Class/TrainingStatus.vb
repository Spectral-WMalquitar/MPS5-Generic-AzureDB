Imports MPS4
Imports Utilities
Imports DevExpress.XtraReports.Parameters

Public Class TrainingStatus

    Private MainReport As New rptTrainingStatus
    Private SubReport_compl As New rptTrainingStatus_Completed
    Private SubReport_req As New rptTrainingStatusSub_Required
    Private SubReport_plan As New rptTrainingStatusSub_Planned

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT		    crew.*, " & _
               "                crew_pp.number as pp_nbr, " & _
               "                crew_sbk.number as sbk_nbr " & _
               "FROM		    dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "                Rpt_CrewPassport" & sArc & " as crew_pp ON crew.idnbr = crew_pp.fkeyidnbr LEFT OUTER JOIN " & _
               "                Rpt_CrewSBK" & sArc & " as crew_sbk ON crew.idnbr = crew_sbk.fkeyidnbr " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Completed Course Sub 
        cSQL = "SELECT          cor .* " & _
               "FROM            dbo.Rpt_CrewTraining" & sArc & " cor " & _
               "WHERE           cor.coursestatus = dbo.getRptDataMapCodeValue('COURSECOMPL') AND cor.idnbr IN " & WhereList
        dt = MPSDB.CreateTable(cSQL)

        SubReport_compl.DataSource = dt
        MainReport.subrpt_compl.ReportSource = SubReport_compl

        'Add a parameter for filtering
        Dim param_compl As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_compl.Parameters.Add(param_compl)
        SubReport_compl.FilterString = "[IDNbr]==?IDNbr"

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Required Course Sub 
        cSQL = "SELECT          cor .* " & _
               "FROM            dbo.Rpt_CrewTraining" & sArc & " cor " & _
               "WHERE           cor.coursestatus = dbo.getRptDataMapCodeValue('COURSEREQ') AND cor.idnbr IN " & WhereList
        dt = MPSDB.CreateTable(cSQL)

        SubReport_req.DataSource = dt
        MainReport.subrpt_req.ReportSource = SubReport_req

        'Add a parameter for filtering
        Dim param_req As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_req.Parameters.Add(param_req)
        SubReport_req.FilterString = "[IDNbr]==?IDNbr"

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Planned Course Sub 
        cSQL = "SELECT          cor .*, ctype.name as CourseTypeValue " & _
               "FROM            dbo.Rpt_CrewTraining" & sArc & " cor LEFT OUTER JOIN " & _
               "                tbladmcoursetype as ctype ON cor.CourseTypeCode = ctype.pkey " & _
               "WHERE           cor.coursestatus = dbo.getRptDataMapCodeValue('COURSEPLANNED') AND cor.idnbr IN " & WhereList
        dt = MPSDB.CreateTable(cSQL)

        SubReport_plan.DataSource = dt
        MainReport.subrpt_plan.ReportSource = SubReport_plan

        'Add a parameter for filtering
        Dim param_plan As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_plan.Parameters.Add(param_compl)
        SubReport_plan.FilterString = "[IDNbr]==?IDNbr"

        '---------------------------------------------------------------------------------------------------------------------------------------
        AddHandler SubReport_compl.BeforePrint, AddressOf SubReport_Compl_BeforePrint
        AddHandler SubReport_req.BeforePrint, AddressOf SubReport_Req_BeforePrint
        AddHandler SubReport_plan.BeforePrint, AddressOf SubReport_Plan_BeforePrint

        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindReportControls(MainReport)
        BindReportControls(SubReport_compl)
        BindReportControls(SubReport_req)
        BindReportControls(SubReport_plan)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.txtDateApplied.DataBindings.Add("Text", Nothing, "DateApplied", "{0:dd-MMM-yyyy}")
        MainReport.txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        SubReport_req.txtDateStart.DataBindings.Add("Text", Nothing, "PlannedStart", "{0:dd-MMM-yyyy}")
        SubReport_compl.txtDateStart.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_compl.txtDateEnd.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
        SubReport_plan.txtDateStart.DataBindings.Add("Text", Nothing, "PlannedStart", "{0:dd-MMM-yyyy}")

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub SubReport_Compl_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_Req_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub

    Private Sub SubReport_Plan_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        AssignReportParameter(MainReport, TryCast(sender, XtraReport), "IDNbr", "IDNbr")
    End Sub
End Class
