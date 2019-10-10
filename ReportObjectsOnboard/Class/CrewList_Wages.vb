Imports Reports

Public Class CrewList_Wages
    Public MainReport As New rptCrewList_Wages

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        
        cSQL = "SELECT * FROM rpt_CrewList_Wages "

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
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

        MainReport.lblCompanyName.Text = REPORT_DETAIL.DB.GetConfig("Name")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celWS, "Text", Nothing, "WS")
        BindData(MainReport.celBasic, "Text", Nothing, "Basic", "{0:#,##0.00}")
        BindData(MainReport.celShipPay, "Text", Nothing, "ShipPay", "{0:#,##0.00}")
        BindData(MainReport.celAllot, "Text", Nothing, "Allot", "{0:#,##0.00}")
        BindData(MainReport.celOT, "Text", Nothing, "OT", "{0:#,##0.00}")
        BindData(MainReport.celOTrate, "Text", Nothing, "OTRate", "{0:#,##0.00}")
        BindData(MainReport.celLPay, "Text", Nothing, "LPay", "{0:#,##0.00}")
        BindData(MainReport.celOtherPay, "Text", Nothing, "OtherPay", "{0:#,##0.00}")
        BindData(MainReport.celTotalWages, "Text", Nothing, "TotalWage", "{0:#,##0.00}")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
