Imports MPS4
Imports Utilities

Public Class CrewCount
    Private MainReport As New rptCrewCount

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String = ""
        Dim ReportTitle As String = "CREW COUNT"

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
        Dim sp As New StoredProcedureCommand("RPT_CrewCount", MPSDB)

        Select Case REPORT_DETAIL.ReportInfo.ObjectID
            Case "rptCrewCount_Agent"
                sp.Parameters.Add(New StoredProcedureCommand.SPParameter("GroupBy", "AGENT"))
                ReportTitle = "CREW COUNT BY AGENT"
            Case "rptCrewCount_Prin"
                sp.Parameters.Add(New StoredProcedureCommand.SPParameter("GroupBy", "PRINCIPAL"))
                ReportTitle = "CREW COUNT BY PRINCIPAL"
            Case Else
                If REPORT_DETAIL.ShowMsgBox Then MsgBox("Report Grouping is not properly specified.", MsgBoxStyle.Information)
                Exit Sub
        End Select
        sp.Parameters.Add(New StoredProcedureCommand.SPParameter("Condition", MainReportFilter))

        Dim dt As New DataTable
        dt = sp.Execute(StoredProcedureCommand.ReturnType.Table, IIf(REPORT_DETAIL.AutoEmail.Enabled, False, True))

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Update Report Title
        MainReport.xrTitle.Text = ReportTitle
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls

        BindData(MainReport.celGroupName, "Text", Nothing, "GroupName")
        BindData(MainReport.celRankName, "Text", Nothing, "Rank")
        BindData(MainReport.celOnboard, "Text", Nothing, "Onboard", "{0:0}")
        BindData(MainReport.celTotalOnboard, "Text", Nothing, "Onboard", "{0:0}")
        BindData(MainReport.celOnVacation, "Text", Nothing, "Vacation", "{0:0}")
        BindData(MainReport.celTotalOnVacation, "Text", Nothing, "Vacation", "{0:0}")
        BindData(MainReport.celApplicant, "Text", Nothing, "Applicant", "{0:0}")
        BindData(MainReport.celTotalApplicant, "Text", Nothing, "Applicant", "{0:0}")
        BindData(MainReport.celNotToBeRehired, "Text", Nothing, "NotToBeRehired", "{0:0}")
        BindData(MainReport.celTotalNotToBeRehired, "Text", Nothing, "NotToBeRehired", "{0:0}")
        BindData(MainReport.celLeftEmployment, "Text", Nothing, "LeftEmployment", "{0:0}")
        BindData(MainReport.celTotalLeftEmployment, "Text", Nothing, "LeftEmployment", "{0:0}")
        BindData(MainReport.celCrewCount, "Text", Nothing, "CrewCount", "{0:0}")
        BindData(MainReport.celTotalCrewCount, "Text", Nothing, "CrewCount", "{0:0}")

        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Agent, "GroupName", REPORT_DETAIL.SortOption.GetSortValueCode("GroupName"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
