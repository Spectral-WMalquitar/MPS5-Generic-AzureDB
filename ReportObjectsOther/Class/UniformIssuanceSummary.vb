Imports MPS4
Imports Utilities

Public Class UniformIssuanceSummary

    Public MainReport As New rptUniformIssuanceSummary

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = "" 'not applicable = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim startDate As String = ""
        Dim endDate As String = ""

        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Period From"), "").Length = 0 Then
            MsgBox("Please select the period from.", MsgBoxStyle.Information)
            Exit Sub
        ElseIf IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Period To"), "").Length = 0 Then
            MsgBox("Please select the period to.", MsgBoxStyle.Information)
            Exit Sub
        End If

        startDate = NumCodeToDate(REPORT_DETAIL.FilterOption.GetFilterValue("Period From").ToString, 1)
        endDate = NumCodeToDate(REPORT_DETAIL.FilterOption.GetFilterValue("Period To").ToString, GetDaysOfMonth(NumCodeToDate(REPORT_DETAIL.FilterOption.GetFilterValue("Period To").ToString, 1)))

        If startDate.Length <> 0 And endDate.Length <> 0 Then
            startDate = Format(CDate(startDate), "yyyy-MM-dd")
            endDate = Format(CDate(endDate), "yyyy-MM-dd")
            MainReport.celDates.Text = "from [FromDate] to [ToDate]"
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[FromDate]", Format(CDate(startDate), "dd-MMM-yyyy"))
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[ToDate]", Format(CDate(endDate), "dd-MMM-yyyy"))

        ElseIf startDate.Length <> 0 And endDate.Length = 0 Then
            startDate = Format(CDate(startDate), "yyyy-MM-dd")
            MainReport.celDates.Text = "from [FromDate]"
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[FromDate]", Format(CDate(startDate), "dd-MMM-yyyy"))
        Else
            If endDate.Length = 0 Then
                endDate = Format(Date.Now, "yyyy-MM-dd")
            Else
                endDate = Format(CDate(endDate), "yyyy-MM-dd")
            End If
            MainReport.celDates.Text = "as of [ToDate]"
            MainReport.celDates.Text = MainReport.celDates.Text.Replace("[ToDate]", Format(CDate(endDate), "dd-MMM-yyyy"))
        End If

        MainReportFilter = "FKeyGarment IN " & WhereList & " "
        MainReportFilter = IIf(MainReportFilter.Length <> 0, MainReportFilter & " AND ", "") & _
            IIf(startDate.Length <> 0, " DateIssue >= '" & startDate & "'" & IIf(endDate.Length <> 0, " AND ", ""), "") & _
            IIf(endDate.Length <> 0, " DateIssue <= '" & endDate & "'", "")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT format(ui.DateIssue, 'MMM-yyyy') Period, dbo.ChangeDateToMCode(ui.dateissue) MCode, ui.DateIssue, g.Name Garment, ui.Quantity FROM dbo.tblUniformIssuance ui INNER JOIN dbo.tblAdmGarment g ON ui.FKeyGarment = g.PKey " & _
               "WHERE(UI.DateIssue Is Not null) " & _
               IIf(MainReportFilter.Length > 0, "AND " & MainReportFilter, "")


        '"ORDER BY cast(format(ui.DateIssue, 'yyyyMM') as int) desc, g.Name"

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        With MainReport
            BindData(.celPeriod, "Text", Nothing, "Period")
            BindData(.celGarment, "Text", Nothing, "Garment")
            BindData(.celQuantity, "Text", Nothing, "Quantity")
            BindData(.celQuantityTotal, "Text", Nothing, "Quantity")
        End With

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "MCode", FieldSortOrder.Descending)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, "Garment", FieldSortOrder.Ascending)
        'AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
