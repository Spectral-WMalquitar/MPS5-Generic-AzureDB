Imports MPS4
Imports Utilities

Public Class NatSOnSOffList
    Private MainReport As New rptNatSOnSOffList

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String = ""
        Dim ReportTitle As String = "NATIONALITY SIGN ON LIST"

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

        Select Case REPORT_DETAIL.ReportObjectID
            Case "rptNatSOnList_Agent", "rptNatSOnList_Prin"
                If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
                    DateCoverageFilter = "a.actdatestart BETWEEN " & ChangeToSQLDate(DateFrom) & " AND " & ChangeToSQLDate(DateTo)
                ElseIf IsNothing(DateFrom) And Not IsNothing(DateTo) Then
                    DateCoverageFilter = "a.actdatestart <= " & ChangeToSQLDate(DateTo)
                ElseIf Not IsNothing(DateFrom) And IsNothing(DateTo) Then
                    DateCoverageFilter = "a.actdatestart >= " & ChangeToSQLDate(DateFrom)
                End If

            Case "rptNatSOffList_Agent", "rptNatSOffList_Prin"
                If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
                    DateCoverageFilter = "a.actdateend BETWEEN " & ChangeToSQLDate(DateFrom) & " AND " & ChangeToSQLDate(DateTo)
                ElseIf IsNothing(DateFrom) And Not IsNothing(DateTo) Then
                    DateCoverageFilter = "a.actdateend <= " & ChangeToSQLDate(DateTo)
                ElseIf Not IsNothing(DateFrom) And IsNothing(DateTo) Then
                    DateCoverageFilter = "a.actdateend >= " & ChangeToSQLDate(DateFrom)
                End If
        End Select
        

        MainReportFilter = MainReportFilter & IIf(MainReportFilter.Length > 0 And DateCoverageFilter.Length > 0, " AND ", "") & DateCoverageFilter

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Arrange Data Source : Main Report 
        'Dim sp As New StoredProcedureCommand("RPT_NationalitySOnList", MPSDB)
        Dim sp As StoredProcedureCommand

        Dim cObjectID As String = REPORT_DETAIL.ReportInfo.ObjectID
        Select Case cObjectID
            '---------------------------------------------------------------------------------------------------------------------------------------

            Case "rptNatSOnList_Agent", "rptNatSOnList_Prin"
                '---------------------------------------------------------------------------------------------------------------------------------------
                sp = New StoredProcedureCommand("RPT_NationalitySOnList", MPSDB)

                If cObjectID = "rptNatSOnList_Agent" Then
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("GroupBy", "AGENT"))
                    ReportTitle = "NATIONALITY SIGN ON LIST BY AGENT"
                ElseIf cObjectID = "rptNatSOnList_Prin" Then
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("GroupBy", "PRINCIPAL"))
                    ReportTitle = "NATIONALITY SIGN ON LIST BY PRINCIPAL"
                Else
                    If REPORT_DETAIL.ShowMsgBox Then MsgBox("Report Grouping is not properly specified.", MsgBoxStyle.Information)
                    Exit Sub
                End If

            Case "rptNatSOffList_Agent", "rptNatSOffList_Prin"
                '---------------------------------------------------------------------------------------------------------------------------------------

                sp = New StoredProcedureCommand("RPT_NationalitySOffList", MPSDB)

                If cObjectID = "rptNatSOffList_Agent" Then
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("GroupBy", "AGENT"))
                    ReportTitle = "NATIONALITY SIGN OFF LIST BY AGENT"
                ElseIf cObjectID = "rptNatSOffList_Prin" Then
                    sp.Parameters.Add(New StoredProcedureCommand.SPParameter("GroupBy", "PRINCIPAL"))
                    ReportTitle = "NATIONALITY SIGN OFF LIST BY PRINCIPAL"
                Else
                    If REPORT_DETAIL.ShowMsgBox Then MsgBox("Report Grouping is not properly specified.", MsgBoxStyle.Information)
                    Exit Sub
                End If

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
        BindData(MainReport.celNationality, "Text", Nothing, "Nationality")
        BindData(MainReport.celRank, "Text", Nothing, "Rank")
        BindData(MainReport.celCrewCount, "Text", Nothing, "CrewCount", "{0:0}")
        BindData(MainReport.celGroupTotal, "Text", Nothing, "CrewCount", "{0:0}")
        BindData(MainReport.celGrandTotal, "Text", Nothing, "CrewCount", "{0:0}")

        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_GroupName, "GroupName", REPORT_DETAIL.SortOption.GetSortValueCode("GroupName"))
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Nationality, "Nationality", REPORT_DETAIL.SortOption.GetSortValueCode("Nationality"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
