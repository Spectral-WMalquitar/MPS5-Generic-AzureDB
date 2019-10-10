
Public Class DocExpiry
    Public MainReport As New rptDocExpiry

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim dtsub As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM Rpt_CrewDocExp "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dtsub = MPSDB.CreateTable(cSQL)
        dt = dtsub.Copy
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------
        dt.Columns.Remove("FKeyDocGroup")
        dt.Columns.Remove("DocGroup")
        dt.Columns.Remove("FKeyDocument")
        dt.Columns.Remove("DocName")
        dt.Columns.Remove("DateExpiry")
        dt = dt.DefaultView.ToTable(True, {"RankSortCode", "Crew", "RankName", "StatName", "VslName", "DateDue", "FormerVsl"})

        MainReport.DataSource = dt
        MainReport.DetailReport.DataSource = dtsub
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        AddHandler MainReport.DetailReport.BeforePrint, AddressOf DetailReport_BeforePrint

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        BindData(MainReport.celCrew, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celStat, "Text", Nothing, "StatName")
        BindData(MainReport.celVsl, "Text", Nothing, "VslName")
        BindData(MainReport.celDateDue, "Text", Nothing, "DateDue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celFormerVsl, "Text", Nothing, "FormerVsl")

        BindData(MainReport.celDocName, "Text", Nothing, "DocName")
        BindData(MainReport.celDateIssue, "Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateExp, "Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        MainReport.Detail1.SortFields.Add(New GroupField("DateExpiry", XRColumnSortOrder.Ascending))

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub DetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        MainReport.DetailReport.FilterString = "Crew='" & MainReport.GetCurrentColumnValue("Crew").ToString & "'"
        If IsDBNull(MainReport.DetailReport.GetCurrentColumnValue("DocName")) Then
            MainReport.DetailReport.Visible = False
        Else
            MainReport.DetailReport.Visible = True
        End If
    End Sub
End Class
