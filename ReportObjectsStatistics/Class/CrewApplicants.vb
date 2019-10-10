Imports MPS4
Imports Utilities

Public Class CrewApplicants
    Private MainReport As New rptCrewApplicants

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String = ""
        
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FkeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        '---------------------------------------------------------------------------------------------------------------------------------------
        ''Arrange Date Condition
        Dim DateFrom As Object = Nothing
        Dim DateTo As Object = Nothing
        Dim tmpDateFrom As String
        Dim tmpDateTo As String

        'Get Date Parameters
        tmpDateFrom = REPORT_DETAIL.FilterOption.GetFilterValue("From")
        If tmpDateFrom.Length > 0 Then
            Try
                DateFrom = CDate(tmpDateFrom)
                tmpDateFrom = ChangeToSQLDate(DateFrom)
            Catch ex As Exception
                tmpDateFrom = ""
            End Try
        Else
            tmpDateFrom = ""
        End If

        tmpDateTo = REPORT_DETAIL.FilterOption.GetFilterValue("To")
        If tmpDateTo.Length > 0 Then
            Try
                DateTo = CDate(tmpDateTo)
                tmpDateTo = ChangeToSQLDate(DateTo)
            Catch ex As Exception
                tmpDateTo = ""
            End Try
        Else
            tmpDateTo = ""
        End If


        'Validate Dates 
        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            If DateTo < DateFrom Then
                MsgBox("Ending date must be later than the starting date", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        MainReport.lblSubTitle.Text = CreateDateRangeSubTitle(DateFrom, DateTo)

        'Get date filter
        Dim DateCoverageFilter As String = ""
        'DateCoverageFilter = "dbo.DateIsInRange(" & IIf(tmpDateFrom.Length > 0, tmpDateFrom, "Null") & ", " & IIf(tmpDateTo.Length > 0, tmpDateTo, "Null") & ", ss.datestart,ss.dateend) = 1"
        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            DateCoverageFilter = "a.actdatestart BETWEEN " & ChangeToSQLDate(DateFrom) & " AND " & ChangeToSQLDate(DateTo)
        ElseIf IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            DateCoverageFilter = "a.actdatestart <= " & ChangeToSQLDate(DateTo)
        ElseIf Not IsNothing(DateFrom) And IsNothing(DateTo) Then
            DateCoverageFilter = "a.actdatestart >= " & ChangeToSQLDate(DateFrom)
        End If

        MainReportFilter = MainReportFilter & IIf(MainReportFilter.Length > 0 And DateCoverageFilter.Length > 0, " AND ", "") & DateCoverageFilter

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Main Report 
        Select Case REPORT_DETAIL.ReportObjectID
            Case "rptCrewApplicantsByAgent"
                cSQL = "SELECT		agent.name as GroupName, " & _
                       "            agent.Name as GroupHeader, " & _
                       "            CASE WHEN rnk.PKey is null THEN '(NO RANK)' ELSE rnk.Abbrv END as SubName, " & _
                       "            CASE WHEN rnk.PKey is null THEN 0 ELSE rnk.SortCode END as [RankSort], " & _
                       "            count(a.pkey) as CrewCount " & _
                       "FROM		dbo.tblActivity a INNER JOIN " & _
                       "            dbo.tblAdmCompany agent ON a.FKeyAgentCode = agent.PKey LEFT JOIN " & _
                       "			dbo.tbladmrank rnk ON a.FKeyRankCode = rnk.PKey " & _
                       "WHERE		a.FKeyStatCode = 'SYSAPP' " & _
                                    IIf(MainReportFilter.Length > 0, " AND " & MainReportFilter & " ", "") & _
                       "GROUP BY	agent.Name, " & _
                       "            rnk.abbrv, " & _
                       "            rnk.PKey, " & _
                       "            rnk.SortCode " & _
                       "ORDER BY	agent.Name, " & _
                       "CASE WHEN rnk.PKey is null THEN 0 ELSE rnk.SortCode END "
                With MainReport
                    .xrTitle.Text = "CREW APPLICANTS BY AGENT"
                    .celGroupNameHeader.Text = "Agent"
                    .celSubNameHeader.Text = "Rank"
                End With


            Case "rptCrewApplicantsByRank"
                cSQL = "SELECT		rnk.Abbrv as GroupName, " & _
                       "            rnk.sortcode as GroupHeader, " & _
                       "            CASE WHEN agent.PKey is null THEN '(NO AGENT)' ELSE agent.Name END as SubName, " & _
                       "			count(a.pkey) as CrewCount " & _
                       "FROM		dbo.tblActivity a INNER JOIN " & _
                       "            dbo.tbladmrank rnk ON a.FKeyRankCode = rnk.PKey LEFT JOIN " & _
                       "            dbo.tblAdmCompany agent ON a.FKeyAgentCode = agent.PKey " & _
                       "WHERE		a.FKeyStatCode = 'SYSAPP' " & _
                                    IIf(MainReportFilter.Length > 0, " AND " & MainReportFilter & " ", "") & _
                       "GROUP BY	agent.pkey, " & _
                       "            agent.Name, " & _
                       "            rnk.abbrv, " & _
                       "            rnk.SortCode " & _
                       "ORDER BY	rnk.sortcode"
                With MainReport
                    .xrTitle.Text = "CREW APPLICANTS BY RANK"
                    .celGroupNameHeader.Text = "Rank"
                    .celSubNameHeader.Text = "Agent"
                End With
        End Select


        '---------------------------------------------------------------------------------------------------------------------------------------
        If cSQL.Length = 0 Then
            MsgBox("Report cannot be generated because the object [" & REPORT_DETAIL.ReportObjectID & "] does not have a corresponding data source.", MsgBoxStyle.Exclamation)
            Exit Sub
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

        'Running Number - Sum
        MainReport.celTotalCrews.Summary.Running = SummaryRunning.Group
        MainReport.celTotalCrews.Summary.Func = SummaryFunc.Sum
        MainReport.celTotalCrews.Summary.FormatString = "{0}"

        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_GroupName, "GroupHeader", REPORT_DETAIL.SortOption.GetSortValueCode("GroupHeader"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
