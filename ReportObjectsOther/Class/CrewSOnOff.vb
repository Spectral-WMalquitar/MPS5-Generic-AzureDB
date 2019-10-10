
Public Class CrewSOnOff
    Public MainReport As New rptCrewSOnOff
    Public SubReport_Onb As New rptCrewSOnOff_Sub
    Public SubReport_Ash As New rptCrewSOnOff_Sub

    Public dt As DataTable
    Public MCode As String

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").Length <> 0 Then
            MainReport.lblPeriod.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper
            MCode = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        Else
            If REPORT_DETAIL.ShowMsgBox Then
                MsgBox("Please specify the Period.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            End If
            Exit Sub
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------

        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM Rpt_CrewSOnOff WHERE ((EmbarkMCode='" & MCode & "') OR (DisembarkMCode='" & MCode & "'))"

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

        MainReport.DataSource = MPSDB.CreateTable("SELECT PKey AS FKeyVsl, Name AS VslName FROM tblAdmVsl WHERE (PKey IN " & WhereList & ")") 'Selected vessels
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        AddHandler MainReport.Detail.BeforePrint, AddressOf Detail_BeforePrint

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        AddSortFieldsToDetailBandFromDT(SubReport_Onb.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        AddSortFieldsToDetailBandFromDT(SubReport_Ash.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Public Sub Detail_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim dt_Onb As New DataView
        Dim dt_Ash As New DataView

        dt_Onb = dt.Copy.DefaultView
        dt_Ash = dt.Copy.DefaultView
        dt_Onb.RowFilter = "FKeyVsl = '" & MainReport.GetCurrentColumnValue("FKeyVsl") & "' AND EmbarkMCode = '" & MCode & "'"
        dt_Ash.RowFilter = "FKeyVsl = '" & MainReport.GetCurrentColumnValue("FKeyVsl") & "' AND DisembarkMCode = '" & MCode & "'"

        SubReport_Onb.DataSource = dt_Onb.ToTable
        SubReport_Ash.DataSource = dt_Ash.ToTable

        BindData(SubReport_Onb.celVsl, "Text", Nothing, "VslName")
        BindData(SubReport_Onb.celCrew, "Text", Nothing, "CrewName")
        BindData(SubReport_Onb.celDate, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        BindData(SubReport_Onb.celPort, "Text", Nothing, "PlaceSOn")
        BindData(SubReport_Onb.celStat, "Text", Nothing, "HireStat")

        BindData(SubReport_Ash.celVsl, "Text", Nothing, "VslName")
        BindData(SubReport_Ash.celCrew, "Text", Nothing, "CrewName")
        BindData(SubReport_Ash.celDate, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(SubReport_Ash.celPort, "Text", Nothing, "PlaceSOff")
        BindData(SubReport_Ash.celStat, "Text", Nothing, "StatName")

        MainReport.RptSub_Onb.ReportSource = SubReport_Onb
        MainReport.RptSub_Ash.ReportSource = SubReport_Ash

    End Sub
End Class
