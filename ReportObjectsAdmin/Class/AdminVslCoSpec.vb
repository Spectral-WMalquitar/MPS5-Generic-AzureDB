
Public Class AdminVslCoSpec
    Public MainReport As New rptAdminVslCoSpec

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM Rpt_AdminVslCoSpec "

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

        MainReport.celCompanyName.Text = REPORT_DETAIL.DB.GetConfig("Name")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        BindData(MainReport.celPrinName, "Text", Nothing, "PrinName")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celOwner, "Text", Nothing, "Owner")
        BindData(MainReport.celTechMg, "Text", Nothing, "TechMg")
        BindData(MainReport.celFleet, "Text", Nothing, "Fleet")
        BindData(MainReport.celCrewCompliment, "Text", Nothing, "CrewCompliment")
        BindData(MainReport.celSafeCrew, "Text", Nothing, "SafeCrew")
        BindData(MainReport.celVslCnt, "Text", Nothing, "VslName")
        BindData(MainReport.celVslCntTotal, "Text", Nothing, "VslName")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "PrinName", REPORT_DETAIL.SortOption.GetSortValueCode("PrinName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
