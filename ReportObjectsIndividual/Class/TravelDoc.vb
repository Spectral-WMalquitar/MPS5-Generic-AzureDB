Imports Utilities
Imports MPS4

Public Class TravelDoc

    Private MainReport As New rptTravelDoc
    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Main Report 
        cSQL = "SELECT 		crew.*, " & _
               "            doc.docname, " & _
               "            doc.nbr, " & _
               "            doc.country, " & _
               "            doc.dateissue, " & _
               "            doc.dateexpiry, " & _
               "            doc.IssuedPlace, " & _
               "            doc.IssuedBy " & _
               "FROM 		dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "            (SELECT 		IDNbr as IDNbrSub, DocName, Nbr, Country, DateIssue, DateExpiry, IssuedBy,IssuedPlace " & _
               "                            FROM dbo.Rpt_CrewDocument" & sArc & " " & _
               "             WHERE          (FKeyDocGroup = dbo.GetRptDataMapCodeValue('DOCGRP_TRAVELDOC'))) AS doc ON crew.IDNbr = doc.IDNbrSub " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")

        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        With MainReport
            .DataSource = dt

            .subHeader.ReportSource = New Reports.rptHeader(MainReport)

            .txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
            .txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
        End With
        

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, REPORT_DETAIL.SortOption.SortDataSource)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class