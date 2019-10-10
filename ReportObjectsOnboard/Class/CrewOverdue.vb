Imports Reports

Public Class CrewOverdue
    Public MainReport As New rptCrewOverdue

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
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
                If REPORT_DETAIL.ShowMsgBox Then
                    MsgBox("Ending date must be later than the starting date", MsgBoxStyle.Information)
                End If
                Exit Sub
            End If
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Get date filter
        Dim DateCoverageFilter As String = ""
        Dim SubTitle_Date As String = ""

        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
            DateCoverageFilter = "DateDue is not null AND DateDue BETWEEN " & tmpDateFrom & " AND " & tmpDateTo
            SubTitle_Date = "from " & Format(DateFrom, "dd-MMM-yyyy") & " to " & Format(DateTo, "dd-MMM-yyyy")
        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
            DateCoverageFilter = "DateDue is not null AND DateDue >= " & tmpDateFrom
            SubTitle_Date = "since " & Format(DateFrom, "dd-MMM-yyyy")
        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
            DateCoverageFilter = "DateDue is not null AND DateDue <= " & tmpDateTo
            SubTitle_Date = "until " & Format(DateTo, "dd-MMM-yyyy")
        Else
            SubTitle_Date = "as of " & Format(DateTime.Now(), "dd-MMM-yyyy")
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_CrewOverdue "

        'assemble Main Report Filter
        If DateCoverageFilter.Length > 0 Then
            MainReportFilter = MainReportFilter & IIf(MainReportFilter.Length > 0, " AND ", "") & DateCoverageFilter
        End If

        If REPORT_DETAIL.ReportObjectID = "rptCrewOverdue" Then
            MainReportFilter = MainReportFilter & IIf(MainReportFilter.Length > 0, " AND ", "") & "DateSOff is null "
        End If

        'Apply Main Report Filter to SQL Statement
        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        'If Sorting.Length > 0 Then
        '    cSQL = cSQL & " ORDER BY " & Sorting & " "
        'End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        'set sub title
        Dim strSubTitle As String = changeDateRangeToSubTitle(tmpDateFrom, tmpDateTo)
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        MainReport.celToDate.Text = SubTitle_Date

        BindData(MainReport.celVslName, "Text", Nothing, "AdmVslName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celRankName, "Text", Nothing, "AdmRankName")
        Select Case REPORT_DETAIL.ReportObjectID
            Case "rptCrewOverdue"
                MainReport.colHeader1.Text = "Date Departed"
                MainReport.colHeader2.Text = "Due Date"
                BindData(MainReport.celColumn1, "Text", Nothing, "DateDep", "{0:dd-MMM-yyyy}")
                BindData(MainReport.celColumn2, "Text", Nothing, "DateDue", "{0:dd-MMM-yyyy}")
            Case "rptCrewOverdue_History"
                MainReport.colHeader1.Text = "Due Date"
                MainReport.colHeader2.Text = "Date Signed Off"
                BindData(MainReport.celColumn1, "Text", Nothing, "DateDue", "{0:dd-MMM-yyyy}")
                BindData(MainReport.celColumn2, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        End Select
        BindData(MainReport.celDaysOverdue, "Text", Nothing, "DaysOverdue")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "AdmVslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
