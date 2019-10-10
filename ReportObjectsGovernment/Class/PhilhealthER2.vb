Public Class PhilhealthER2
    Public MainReport As New rptPhilhealthER2

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM Rpt_MCR_Er2 "

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

        Dim bInit As String, bSubseq As String

        bInit = REPORT_DETAIL.FilterOption.GetFilterValue("INITIAL LIST")
        bSubseq = REPORT_DETAIL.FilterOption.GetFilterValue("SUBSEQUENT")

        MainReport.chkInitial.Checked = IIf(bInit = "", False, bInit)
        MainReport.chkSubSeq.Checked = IIf(bSubseq = "", False, bSubseq)

        MainReport.celSignatory.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory")
        BindData(MainReport.celPHno, "Text", Nothing, "MCRSSSno")
        BindData(MainReport.celEmployee, "Text", Nothing, "crew")
        BindData(MainReport.celPosition, "Text", Nothing, "RankName")
        BindData(MainReport.celSalary, "Text", Nothing, "Basic", "{0:c2}")
        BindData(MainReport.celDateEmploy, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celTotalNoPage, "Text", Nothing, "crew")

        'AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
