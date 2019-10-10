Imports MPS4
Imports Utilities

Public Class ServiceHistory

    Private MainReport As New rptServiceHistory

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

        If REPORT_DETAIL.ReportObjectID.ToLower = "rptServiceHistory".ToLower Then
            MainReport.lblReportHeader.Text = "SERVICE HISTORY"
            MainReport.celReportType.Text = "SERVICE HISTORY"

            cSQL = "SELECT		    crew.*, ss.*, dbo.formatRangeToWord(datestart,dateend,'') as Mos " & _
                   "FROM		    dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
                   "                (SELECT         IDNbr as IDNbrSub, CASE WHEN acttype = 'sea' AND len(isnull(SOFFStatName,'')) > 0 THEN SOFFStatName ELSE StatName END as SOFFStatName, DateStart, DateEnd " & _
                   "                 FROM           Rpt_CrewActAll WHERE idnbr IN " & WhereList & " AND acttype = dbo.GetRptDataMapCodeValue('ACTTYPE_SEA')) AS ss ON crew.IDNbr " & IIf(IfNull(sArc, "").Length > 0, " COLLATE DATABASE_DEFAULT ", "") & " = ss.IDNbrSub " & _
                   IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")
        Else
            MainReport.lblReportHeader.Text = "ACTIVITY HISTORY"
            MainReport.celReportType.Text = "ACTIVITY HISTORY"
            cSQL = "SELECT		    crew.*, ss.*, " & _
                   "(CASE WHEN ss.acttype = 'SEA' THEN dbo.formatRangeToWord(datestart,dateend,'') ELSE '' END) as Mos " & _
                   "FROM		    dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
                   "                (SELECT         IDNbr as IDNbrSub, CASE WHEN acttype = 'sea' AND len(isnull(SOFFStatName,'')) > 0 THEN SOFFStatName ELSE StatName END AS SOFFStatName, DateStart, DateEnd, acttype " & _
                   "                 FROM           Rpt_CrewActAll WHERE idnbr IN " & WhereList & ") AS ss ON crew.IDNbr " & IIf(IfNull(sArc, "").Length > 0, " COLLATE DATABASE_DEFAULT ", "") & " = ss.IDNbrSub " & _
                   IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")
        End If

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)

        With MainReport
            .subHeader.ReportSource = New Reports.rptHeader(MainReport)

            .txtStartDate.DataBindings.Add("Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
            .txtEndDate.DataBindings.Add("Text", Nothing, "DateEnd", "{0:dd-MMM-yyyy}")
            .txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
            .txtDateApplied.DataBindings.Add("Text", Nothing, "DateApplied", "{0:dd-MMM-yyyy}")
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
