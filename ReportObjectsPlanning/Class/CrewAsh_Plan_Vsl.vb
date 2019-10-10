
Public Class CrewAsh_Plan_Vsl
    Public MainReport As New rptCrewAsh_Plan_Vsl

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_CrewAsh_Plan "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

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
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindData(MainReport.celPlanVsl, "Text", Nothing, "PlanVsl")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celCurrRank, "Text", Nothing, "RankName")
        BindData(MainReport.celDateSOff, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celFormerVsl, "Text", Nothing, "FormerVsl")
        BindData(MainReport.celPlanRank, "Text", Nothing, "PlanRank")
        BindData(MainReport.celPlanJoinDate, "Text", Nothing, "PlannedDateSON", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celToRelieve, "Text", Nothing, "ToRelieve")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "PlanVsl", FieldSortOrder.Ascending)

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
