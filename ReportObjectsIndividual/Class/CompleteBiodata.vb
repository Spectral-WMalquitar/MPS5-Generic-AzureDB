Imports MPS4
Imports Utilities
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.Parameters
Imports Reports.BaseReportBuilder

Public Class CompleteBiodata
    Public MainReport As New rptCompleteBiodata
    Public SubReport_Addr As New rptCompleteBiodatasub_Addr
    Public SubReport_TravelDoc As New rptCompleteBiodatasub_TravelDoc


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
        cSQL = "SELECT * FROM Rpt_BioInfo "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & "WHERE " & MainReportFilter & " "
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Note: Sorting should be applied from the report bands, not on source
        'If Sorting.Length > 0 Then
        'cSQL = cSQL & "ORDER BY " & Sorting & " "
        'End If
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        If dt Is Nothing Then
            MsgBox("Unable to generate report source.", vbExclamation)
            Exit Sub
        End If
        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Address Sub 
        cSQL = "SELECT     * " & _
               "FROM       dbo.Rpt_BioInfo_Addr " & _
               "WHERE      IDNbr IN " & WhereList & ";"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_Addr.DataSource = dt
        MainReport.subrpt_addr.ReportSource = SubReport_Addr

        'Add a parameter for filtering
        Dim param_addr As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_Addr.Parameters.Add(param_addr)
        SubReport_Addr.FilterString = "[IDNbr]==?IDNbr"

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Document Sub
        cSQL = "SELECT     DocKey, IDNbr, DocName, Nbr, DateIssue, DateExpiry, IssuedBy, Country " & _
               "FROM       dbo.Rpt_CrewDocument " & _
               "WHERE      FKeyDocGroup = 'SYSTRAVELDOC' AND " & _
               "           IDNbr IN " & WhereList & " " & _
               "ORDER BY   docname, dateissue desc;"
        dt = MPSDB.CreateTable(cSQL)

        SubReport_TravelDoc.DataSource = dt
        MainReport.subrpt_traveldoc.ReportSource = SubReport_TravelDoc

        'Add a parameter for filtering
        Dim param_traveldoc As New Parameter() With {.Name = "IDNbr", .Type = GetType(String), .Visible = False, .Value = String.Empty}

        SubReport_TravelDoc.Parameters.Add(param_traveldoc)
        SubReport_TravelDoc.FilterString = "[IDNbr]==?IDNbr"

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "Crew", GetFieldSortCodeFromDT(SortDT, "Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, SortDT, "Crew")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)
        BindReportControls(SubReport_Addr)
        BindReportControls(SubReport_TravelDoc)
        MainReport.txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        MainReport.txtDateSON.DataBindings.Add("Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        SubReport_TravelDoc.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        SubReport_TravelDoc.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Handle the Subreport.BeforePrint event for filtering details dynamically
        AddHandler SubReport_Addr.BeforePrint, AddressOf subreportAddr_BeforePrint
        AddHandler SubReport_TravelDoc.BeforePrint, AddressOf subreportTravelDOc_BeforePrint
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Preview Report
        MainReport.ShowPreviewDialog()
    End Sub

    Private Sub subreportAddr_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Dim subreport As XRSubreport = TryCast(sender, XRSubreport)
        
        'Obtain the current CustomerID value for filtering the detail report
        Dim IDNbr As String = MainReport.GetCurrentColumnValue("IDNbr").ToString()
        'subreport.ReportSource.Parameters("IDNbr").Value = currentCustID
        SubReport_Addr.Parameters("IDNbr").Value = IDNbr
    End Sub

    Private Sub subreportTravelDOc_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Dim subreport As XRSubreport = TryCast(sender, XRSubreport)
        
        'Obtain the current CustomerID value for filtering the detail report
        Dim IDNbr As String = MainReport.GetCurrentColumnValue("IDNbr").ToString()
        'subreport.ReportSource.Parameters("IDNbr").Value = currentCustID
        SubReport_TravelDoc.Parameters("IDNbr").Value = IDNbr
    End Sub

End Class
