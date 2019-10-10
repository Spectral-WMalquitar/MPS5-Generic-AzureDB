Imports MPS4
Imports Utilities

Public Class SeaServCertification

    Private MainReport As New rptSeaServCertification

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "crew.FKeyAgentCode", "crew.FKeyPrinCode", "crew.FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        If REPORT_DETAIL.FilterOption.GetFilterValue("Do Not Include Onboard Service").Equals("YES") Then
            MainReportFilter = MainReportFilter & _
                                IIf(Not IfNull(MainReportFilter, "").Equals(""), " AND ", "") & _
                                "CASE WHEN rn = 1  THEN CASE WHEN DateEnd is null THEN 0 ELSE 1 END ELSE 1 END = 1"
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT		    crew.crew, crew.rank, crew.gender, ss.* " & _
               "FROM		    dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "                (SELECT         IDNbr as IDNbrSub, DateStart, DateEnd, VslName, GrossTon, EngPower, VslTypeName, RankName, rn = ROW_NUMBER() OVER (PARTITION BY IDNbr ORDER BY DateStart DESC)  " & _
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
        'Add report before print procedures
        AddHandler MainReport.GroupHeader_Crew.BeforePrint, AddressOf GroupHeader_Crew_BeforePrint
        AddHandler MainReport.GroupFooter1.BeforePrint, AddressOf GroupFooter1_BeforePrint

        MainReport.lblSignatory_CompanyName.Text = Trim(REPORT_DETAIL.DB.GetConfig("Name"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub GroupHeader_Crew_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)
        MainReport.lblCrewHeader.Text = Chr(9) & "This will certify that " & MainReport.GetCurrentRow().Row("Crew").ToString() & " has rendered service onboard our manned vessel as follows:"
    End Sub

    Private Sub GroupFooter1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)
        MainReport.lblCrewFooter.Text = Chr(9) & "This certification is being issued upon the request of " & IIf(MainReport.GetCurrentRow().row("Gender").ToString() = "Male", "Mr.", "Ms./Mrs.") & " " & MainReport.GetCurrentRow().Row("Crew").ToString() & " for record purposes."
    End Sub
End Class
