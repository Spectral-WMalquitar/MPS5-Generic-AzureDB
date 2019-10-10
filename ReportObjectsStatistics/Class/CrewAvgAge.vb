Imports MPS4
Imports Utilities

Public Class CrewAvgAge
    Public MainReport As New rptCrewAvgAge

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim startDate As String = ""
        Dim endDate As String = ""
        Dim groupBy As String = ""

        Select Case REPORT_DETAIL.ReportObjectID
            Case "rptCrewAvgAge_Vsl"
                groupBy = "Vessel"

            Case "rptCrewAvgAge_Rank"
                groupBy = "Rank"
            Case Else
                groupBy = ""
        End Select

        startDate = REPORT_DETAIL.FilterOption.GetFilterValue("From").ToString
        endDate = REPORT_DETAIL.FilterOption.GetFilterValue("To").ToString

        If startDate.Length <> 0 And endDate.Length <> 0 Then
            startDate = Format(CDate(startDate), "yyyy-MM-dd")
            endDate = Format(CDate(endDate), "yyyy-MM-dd")
            MainReport.celDates.Text = "from [FromDate] to [ToDate]"
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[FromDate]", Format(CDate(startDate), "dd-MMM-yyyy"))
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[ToDate]", Format(CDate(endDate), "dd-MMM-yyyy"))

        ElseIf startDate.Length <> 0 And endDate.Length = 0 Then
            startDate = Format(CDate(startDate), "yyyy-MM-dd")
            MainReport.celDates.Text = "from [FromDate]"
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[FromDate]", Format(CDate(startDate), "dd-MMM-yyyy"))
        Else
            If endDate.Length = 0 Then
                endDate = Format(Date.Now, "yyyy-MM-dd")
            Else
                endDate = Format(CDate(endDate), "yyyy-MM-dd")
            End If
            MainReport.celDates.Text = "as of [ToDate]"
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[ToDate]", Format(CDate(endDate), "dd-MMM-yyyy"))
        End If

        MainReportFilter = IIf(MainReportFilter.Length <> 0, MainReportFilter & " AND ", "") & _
            IIf(startDate.Length <> 0, " DateStarted >= '" & startDate & "'" & IIf(endDate.Length <> 0, " AND ", ""), "") & _
            IIf(endDate.Length <> 0, " DateStarted <= '" & endDate & "'", "")

        Dim whereClause As String = ""
        If MainReportFilter.Length > 0 Then
            whereClause = " WHERE " & MainReportFilter & " "
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT " & groupBy & IIf(groupBy = "Rank", ", RankSort", "") & ", COUNT(IDNbr) AS CrewCnt, " & _
                    "SUM(CASE WHEN ServCnt <= 1 THEN 1 ELSE 0 END) AS AppCnt, " & _
                    "AVG(Age) AS AvgAge FROM " & _
                    "(SELECT *, ROW_NUMBER() OVER (PARTITION BY IDNbr ORDER BY DateStarted DESC) AS rn " & _
                    " FROM Rpt_CrewAvgAge_All " & whereClause & ") crewMain WHERE rn = 1 "

        'If MainReportFilter.Length > 0 Then
        '    cSQL = cSQL & " WHERE " & MainReportFilter & " "
        'End If

        cSQL = cSQL & " GROUP BY " & groupBy & IIf(groupBy = "Rank", ", RankSort", "")

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        With MainReport
            .celTitle.Text = .celTitle.Text.Replace("[Group]", groupBy.ToUpper)
            .celHead.Text = groupBy

            BindData(.celItem, "Text", Nothing, groupBy)
            BindData(.celCrewCnt, "Text", Nothing, "CrewCnt")
            BindData(.celAppCnt, "Text", Nothing, "AppCnt")
            BindData(.celAvgAge, "Text", Nothing, "AvgAge")
        End With

        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        'AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, IIf(groupBy = "Rank", "RankSort", groupBy), REPORT_DETAIL.SortOption.GetSortValueCode(IIf(groupBy = "Rank", "RankSort", groupBy)))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
