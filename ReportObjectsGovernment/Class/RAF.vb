Imports Utilities
Imports MPS4

Public Class RAF
    Public MainReport As New rptRAF
    Dim dt As DataTable

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM rpt_RAF "

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
        If REPORT_DETAIL.FilterOption.GetFilterValue("Seafarer's Detail?").Length <> 0 Then
            MainReport.celOpt1.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Seafarer's Detail?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Position?").Length <> 0 Then
            MainReport.celOpt2.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Position?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Contract Duration?").Length <> 0 Then
            MainReport.celOpt3.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Contract Duration?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Contract Continuation?").Length <> 0 Then
            MainReport.celOpt4.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Contract Continuation?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Transfer of Vessel?").Length <> 0 Then
            MainReport.celOpt5.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Transfer of Vessel?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Salary?").Length <> 0 Then
            MainReport.celOpt6.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Salary?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Re-issuance?").Length <> 0 Then
            MainReport.celOpt7.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Re-issuance?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Change Principal?").Length <> 0 Then
            MainReport.celOpt8.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Change Principal?")) = 1, "X", "")
        End If
        If REPORT_DETAIL.FilterOption.GetFilterValue("Vessel Detail?").Length <> 0 Then
            MainReport.celOpt9.Text = IIf(CInt(REPORT_DETAIL.FilterOption.GetFilterValue("Vessel Detail?")) = 1, "X", "")
        End If
        MainReport.celAgency.Text = MPSDB.GetConfig("NAME").ToUpper
        BindData(MainReport.celPrincipal, "Text", Nothing, "PrinName")
        BindData(MainReport.celVessel, "Text", Nothing, "VslName")
        BindData(MainReport.celSRC, "Text", Nothing, "SRC")
        BindData(MainReport.celCrewName, "Text", Nothing, "CrewName")
        BindData(MainReport.celSIRB, "Text", Nothing, "SIRB")
        BindData(MainReport.celGender, "Text", Nothing, "Gender")
        BindData(MainReport.celPosition, "Text", Nothing, "Rank")
        BindData(MainReport.celSalary, "Text", Nothing, "Basic")
        BindData(MainReport.celLOC, "Text", Nothing, "LOC")

        MainReport.celSign1Name.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Submitted By", BaseFilterOption.GetFilterReturnWhat.DisplayValue)
        MainReport.celSign1Pos.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Submitted By")
        MainReport.celSign2Name.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Requesting Party", BaseFilterOption.GetFilterReturnWhat.DisplayValue)
        MainReport.celSign2Pos.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Requesting Party")


        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub

End Class
