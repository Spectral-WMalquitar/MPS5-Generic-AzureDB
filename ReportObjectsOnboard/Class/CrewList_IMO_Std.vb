Imports Reports

Public Class CrewList_IMO_Std
    Public MainReport As New rptCrewList_IMO_Std

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        
        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_CrewList_IMO "

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

        MainReport.pbLogo.Image = GetLogo()
        MainReport.celCompanyName.Text = REPORT_DETAIL.DB.GetConfig("Name")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        MainReport.celPortArr.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Port of Arrival")
        MainReport.celPortDep.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Port of Departure")
        MainReport.celPortArrFrom.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Port Arrived From")
        Try
            MainReport.celDateArr.Text = Format(CDate(REPORT_DETAIL.FilterOption.GetFilterValue("Date of Arrival")), "dd-MMM-yyyy")
        Catch ex As Exception
            MainReport.celDateArr.Text = ""
        End Try

        Try
            MainReport.celDateDep.Text = Format(CDate(REPORT_DETAIL.FilterOption.GetFilterValue("Date of Departure")), "dd-MMM-yyyy")
        Catch ex As Exception
            MainReport.celDateDep.Text = ""
        End Try

        BindData(MainReport.lblVessel, "Text", Nothing, "VslName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celNat, "Text", Nothing, "Nat")
        BindData(MainReport.celDateSON, "Text", Nothing, "DateDep", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDocNum, "Text", Nothing, "PPortNbr")
        BindData(MainReport.celDocExp, "Text", Nothing, "PPortExp", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celTotalOnb, "Text", Nothing, "Crew")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
