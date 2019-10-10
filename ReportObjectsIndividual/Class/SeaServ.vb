Imports MPS4
Imports Utilities

Public Class SeaServ

    Private MainReport As New rptSeaServ

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "crew.FKeyAgentCode", "crew.FKeyPrinCode", "crew.FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        Dim FilterCourseStat As String = ""

        cSQL = "SELECT		    IDNbr, " & _
               "                crew.Crew, " & _
               "                crew.Rank, " & _
               "                ss.* " & _
               "FROM		    dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "                (SELECT         actid, IDNbr as IDNbrSub, VslName, RankName, DateStart, DateEnd, (dbo.formatRangeToWord(DateStart, DateEnd, 'nM')) Mos, LOC, VslTypeName, DeadWt, GrossTon, EngPower, PrinName, IIf(DateSOff IS NULL, StatName, SOFFStatName) AS Status " & _
               "                 FROM           Rpt_CrewActAll WHERE idnbr IN " & WhereList & " AND acttype = dbo.GetRptDataMapCodeValue('ACTTYPE_SEA')) AS ss ON crew.IDNbr " & IIf(IfNull(sArc, "").Length > 0, " COLLATE DATABASE_DEFAULT ", "") & " = ss.IDNbrSub " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")


        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        With MainReport
            .DataSource = dt

            .subHeader.ReportSource = New Reports.rptHeader(MainReport)

            .txtDateStart.DataBindings.Add("Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
            .txtDateEnd.DataBindings.Add("Text", Nothing, "DateEnd", "{0:dd-MMM-yyyy}")
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
