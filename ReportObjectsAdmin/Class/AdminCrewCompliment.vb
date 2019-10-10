
Public Class AdminCrewCompliment
    Public MainReport As New rptAdminCrewCompliment
    Public SubReport As New rptAdminCrewCompliment_sub

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM Rpt_AdminCrewCompliment"

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
        BindData(MainReport.celComplimentName, "Text", Nothing, "ComplimentName")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celRankCnt, "Text", Nothing, "RankCnt")
        BindData(MainReport.celRankCntTotal, "Text", Nothing, "RankCnt")
        'BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        'BindData(MainReport.celFlag, "Text", Nothing, "Flag")

        MainReport.XrSubreport1.ReportSource = SubReport
        AddHandler MainReport.GroupFooter1.BeforePrint, AddressOf SubDetail_BeforePrint

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "ComplimentName", REPORT_DETAIL.SortOption.GetSortValueCode("ComplimentName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Public Sub SubDetail_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim cSQL_sub As String
        Dim dt_sub As DataTable
        cSQL_sub = "SELECT     TOP (100) PERCENT dbo.tblAdmCrewCmpl.Name AS ComplimentName, dbo.tblAdmVsl.Name AS VslName, dbo.tblAdmCntry.Name AS Flag" & _
                " FROM         dbo.tblAdmCrewCmpl LEFT OUTER JOIN " & _
                " dbo.tblAdmVsl ON dbo.tblAdmCrewCmpl.PKey = dbo.tblAdmVsl.FKeyCrewCmpl LEFT OUTER JOIN " & _
                " dbo.tblAdmCntry ON dbo.tblAdmVsl.Flag = dbo.tblAdmCntry.PKey " & _
                " WHERE dbo.tblAdmCrewCmpl.Name = '" & MainReport.celComplimentName.Text & "'"

        dt_sub = MPSDB.CreateTable(cSQL_sub)
        SubReport.DataSource = dt_sub
        BindData(SubReport.celVslName, "Text", Nothing, "VslName")
        BindData(SubReport.celFlag, "Text", Nothing, "Flag")
    End Sub
End Class
