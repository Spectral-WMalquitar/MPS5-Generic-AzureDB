Imports Utilities
Imports MPS4

Public Class Medical

    Private MainReport As New rptMedical
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
               "            doc.DocName," & _
               "            doc.Capacity," & _
               "            doc.Regulation," & _
               "            doc.Country," & _
               "            doc.Nbr," & _
               "            doc.DateIssue," & _
               "            doc.DateExpiry, " & _
               "            doc.IssuedPlace, " & _
               "            doc.IssuedBy, " & _
               "            doc.Remarks, " & _
               "            crew.DateApplied, " & _
               "            crew_sbk.number as sbk_nbr, " & _
               "            crew_sbk.country as sbk_country, " & _
               "            crew_sbk.dateexpiry as sbk_dateexpiry, " & _
               "            crew_pp.number as pp_nbr, " & _
               "            crew_pp.country as pp_country, " & _
               "            crew_pp.dateexpiry as pp_dateexpiry " & _
               "FROM 		dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "            (SELECT 		IDNbr as IDNbrSub, DocName, Capacity, Regulation, Country, Nbr, DateIssue, DateExpiry, IssuedPlace, IssuedBy, Remarks " & _
               "                            FROM dbo.Rpt_CrewDocument" & sArc & " " & _
               "             WHERE          (FKeyDocGroup = dbo.GetRptDataMapCodeValue('DOCGRP_MEDCERT'))) AS doc ON crew.IDNbr = doc.IDNbrSub LEFT OUTER JOIN " & _
               "            (SELECT doc.FKeyIDNbr, doc.Number, cntry.Name as country, doc.DateExpiry FROM dbo.Rpt_CrewSBK" & sArc & " doc LEFT JOIN dbo.tbladmcntry cntry ON doc.FKeyCntry " & IIf(IfNull(sArc, "").Length > 0, " COLLATE DATABASE_DEFAULT", "") & " = cntry.PKey) crew_sbk ON crew.idnbr = crew_sbk.fkeyidnbr LEFT OUTER JOIN " & _
               "            (SELECT doc.FKeyIDNbr, doc.Number, cntry.Name as country, doc.DateExpiry FROM dbo.Rpt_CrewPassport" & sArc & " doc LEFT JOIN dbo.tbladmcntry cntry ON doc.FKeyCntry " & IIf(IfNull(sArc, "").Length > 0, " COLLATE DATABASE_DEFAULT", "") & " = cntry.PKey) crew_pp ON crew.idnbr  = crew_pp.fkeyidnbr " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        With MainReport
            .subHeader.ReportSource = New Reports.rptHeader(MainReport)
            .txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
            .txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
            .txtDateApplied.DataBindings.Add("Text", Nothing, "DateApplied", "{0:dd-MMM-yyyy}")
            .txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
            .txtppdateexpiry.DataBindings.Add("Text", Nothing, "pp_dateexpiry", "{0:dd-MMM-yyyy}")
            .txtsbkdateexpiry.DataBindings.Add("Text", Nothing, "sbk_dateexpiry", "{0:dd-MMM-yyyy}")
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
