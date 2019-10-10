Imports Reports

Public Class CrewList_IMO_Jap
    Public MainReport As New rptCrewList_IMO_Jap

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

        Try
            MainReport.celDate.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Date")
        Catch ex As Exception
            MainReport.celDate.Text = ""
        End Try
        MainReport.celMaster.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Master")
        MainReport.celPortArr.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Port of Arrival")
        Try
            MainReport.celDateArr.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Date of Arrival")
        Catch ex As Exception
            MainReport.celDateArr.Text = ""
        End Try

        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celVslFlag, "Text", Nothing, "vslFlag")
        BindData(MainReport.celVslOwner, "Text", Nothing, "VslOwner")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celNat, "Text", Nothing, "Nat")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDocNum, "Text", Nothing, "PPortSRBNbr")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celRemarks, "Text", Nothing, "Remarks")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
