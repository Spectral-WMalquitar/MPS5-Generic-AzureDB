Imports Utilities
Imports MPS4

Public Class AMOSUPCrewList
    Public MainReport As New rptAMOSUPCrewList

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim MCode As String

        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString.Length <> 0 Then
            MainReport.celPeriod.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToString.ToUpper
            MCode = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        Else
            MsgBox("Please specify the Period.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            Exit Sub
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM Rpt_AMOSUPCrewList WHERE ((EmbarkMCode='" & MCode & "') OR (DisembarkMCode='" & MCode & "'))"

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " AND " & MainReportFilter & " "
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

        MainReport.lblCompany.Text = MPS4.MPSDB.GetConfig("Name").ToUpper
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celLName, "Text", Nothing, "LName")
        BindData(MainReport.celFName, "Text", Nothing, "FName")
        BindData(MainReport.celMName, "Text", Nothing, "MName")
        BindData(MainReport.celRankName, "Text", Nothing, "RankName")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateSOn, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateSOff, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celCrewCnt, "Text", Nothing, "LName")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, REPORT_DETAIL.SortOption.SortDataSource)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
