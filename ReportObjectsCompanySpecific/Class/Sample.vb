Public Class Sample
    Public MainReport As New rptSample

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_CrewList "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindData(MainReport.lblVessel, "Text", Nothing, "VslName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celNationality, "Text", Nothing, "Nat")
        BindData(MainReport.celAge, "Text", Nothing, "Age")
        BindData(MainReport.celDepart, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDue, "Text", Nothing, "DueDate", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celLOC, "Text", Nothing, "LOC")
        BindData(MainReport.celDays, "Text", Nothing, "DaysLeft")
        BindData(MainReport.celHireStat, "Text", Nothing, "HireStat")
        BindData(MainReport.celTotalOnb, "Text", Nothing, "Crew")
        BindData(MainReport.celAvgAge, "Text", Nothing, "Age")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
