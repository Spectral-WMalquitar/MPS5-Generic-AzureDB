Imports Utilities
Imports MPS4

Public Class RPS
    Public MainReport As New rptRPS
    Dim dt As DataTable

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM rpt_RPS "

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
        'MainReport.celDateEffect.Text = "16 MAY 2012"
        If REPORT_DETAIL.FilterOption.GetFilterValue("Request Type").Length <> 0 Then
            MainReport.celMark1.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Request Type")) = 1, "X", "")
            MainReport.celMark2.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Request Type")) = 2, "X", "")
        End If
        MainReport.celAgentName.Text = MPSDB.GetConfig("NAME").ToUpper
        BindData(MainReport.celPrinName, "Text", Nothing, "PrinName")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        'Dim strContDate As String = REPORT_DETAIL.FilterOption.GetFilterValue("Date")
        'If strContDate.Length <> 0 Then
        '    MainReport.celDateApprove.Text = Format(CDate(strContDate), "dd MMMM yyyy").ToUpper
        'End If

        BindData(MainReport.celSRC, "Text", Nothing, "SRC")
        BindData(MainReport.celCrew, "Text", Nothing, "CrewName")
        BindData(MainReport.celSIRB, "Text", Nothing, "SIRB")
        BindData(MainReport.celGender, "Text", Nothing, "Gender")
        BindData(MainReport.celRank, "Text", Nothing, "Rank")
        BindData(MainReport.celBasic, "Text", Nothing, "Basic")
        BindData(MainReport.celLOC, "Text", Nothing, "LOC")

        MainReport.celSign1.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Submitted By", BaseFilterOption.GetFilterReturnWhat.DisplayValue)
        MainReport.celPosition1.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Submitted By")
        MainReport.celSign2.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Requesting Party", BaseFilterOption.GetFilterReturnWhat.DisplayValue)
        MainReport.celPosition2.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Requesting Party")


        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
