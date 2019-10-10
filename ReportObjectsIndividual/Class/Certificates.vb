Imports Utilities
Imports MPS4

Public Class Certificates

    Private MainReport As New rptCertificates

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Main Report 
        cSQL = "SELECT 		IDNbr, " & _
               "            crew.Crew, " & _
               "            crew.LName, " & _
               "            crew.FName, " & _
               "            crew.DOB, " & _
               "            crew.Age," & _
               "            crew.FKeyNat," & _
               "            crew.Nationality," & _
               "            crew.POB," & _
               "            crew.FKeyRank," & _
               "            crew.RankSort, " & _
               "            crew.Rank," & _
               "            crew.FKeyPrinCode, " & _
               "            crew.PrinName, " & _
               "            crew.FKeyAgentCode, " & _
               "            crew.AgentName, " & _
               "            doc.DocName," & _
               "            doc.Capacity," & _
               "            doc.Regulation," & _
               "            doc.Country," & _
               "            doc.Nbr," & _
               "            doc.DateIssue," & _
               "            doc.DateExpiry " & _
               "FROM 		dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "            (SELECT 		IDNbr as IDNbrSub, DocName, Capacity, Regulation, Country, Nbr, DateIssue, DateExpiry " & _
               "                            FROM dbo.Rpt_CrewDocument" & sArc & " " & _
               "             WHERE          (FKeyDocGroup = dbo.GetRptDataMapCodeValue('DOCGRP_LICCERT'))) AS doc ON crew.IDNbr = doc.IDNbrSub " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")

        Dim dt As DataTable

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        BindReportControls(MainReport)
        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, REPORT_DETAIL.SortOption.SortDataSource)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        MainReport.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        MainReport.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
