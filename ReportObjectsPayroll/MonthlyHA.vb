
Public Class MonthlyHA
    Public MainReport As New rptMonthlyHA
    Public SubReport_Detail As New rptMonthlyHA_Sub_Detail
    Public SubReport_Total As New rptMonthlyHA_Sub_Total

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString.Length = 0 Then
            MsgBox("Please select a Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
            Exit Sub
        End If
        Dim ds As New DataSet
        Dim dt As DataTable
        Dim cSQL As String

        Dim Period As Integer = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        Dim FKeyPrinCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Principal")
        Dim FKeyVslCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel", BaseFilterOption.GetFilterReturnWhat.EditValue, True)
        Dim RefNo As String = REPORT_DETAIL.FilterOption.GetFilterValue("RefNo", BaseFilterOption.GetFilterReturnWhat.EditValue, True)

        'Edited By Earlsan 20161125

        'Old Code
        'Dim MainReportFilter As String = " MCode='" & Period & "'" & _
        '    IIf(FKeyPrinCode.Length <> 0, " AND FKeyPrin='" & FKeyPrinCode & "'", "") & _
        '    IIf(FKeyVslCode.Length <> 0, " AND FKeyVsl='" & FKeyVslCode & "'", "") & _
        '    IIf(RefNo.Length <> 0, " AND RefNo='" & RefNo & "'", "")

        Dim MainReportFilter As String = " MCode='" & Period & "'" & _
            IIf(FKeyPrinCode.Length <> 0, " AND FKeyPrin='" & FKeyPrinCode & "'", "") & _
            IIf(FKeyVslCode.Length <> 0, " AND FKeyVsl IN (" & FKeyVslCode & ")", "") & _
        IIf(RefNo.Length <> 0, " AND PayID IN(" & RefNo & ")", "")
        'Edited By Earlsan 20161125

        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE        
        cSQL = "SELECT * FROM Rpt_MonthlyHA "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)
        dt.TableName = "Crew"
        ds.Tables.Add(dt)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        cSQL = "SELECT * FROM Rpt_MonthlyHA_Detail WHERE " & MainReportFilter
        dt = MPSDB.CreateTable(cSQL)
        dt.TableName = "Detail"
        ds.Tables.Add(dt)

        cSQL = "SELECT Curr, Item, SUM(AmtEE) AS AmtEE, SUM(AmtER) AS AmtER FROM (SELECT * FROM Rpt_MonthlyHA_GovtCont WHERE " & MainReportFilter & ") as xtemp GROUP BY Curr, Item"
        dt = MPSDB.CreateTable(cSQL)
        dt.TableName = "GovtCont"
        ds.Tables.Add(dt)

        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        With MainReport
            .DataSource = ds.Tables("Crew")

            .celCompany.Text = MPS4.MPSDB.GetConfig("Name").ToUpper
            .celMoYr.Text = .celMoYr.Text & ds.Tables("Crew").Rows(0).Item("Period").ToString

            BindData(.celVslName, "Text", Nothing, "VslName")
            BindData(.celForEx, "Text", Nothing, "ForEx")
            BindData(.celCurrency, "Text", Nothing, "AllotCurr")
            BindData(.celCrew, "Text", Nothing, "CrewName")
            BindData(.celRank, "Text", Nothing, "RankName")

            'BindData(.celAllotPHP, "Text", Nothing, "AllotPHP")

            BindData(.celAllottee, "Text", Nothing, "Allottee")
            BindData(.celBankDetail, "Text", Nothing, "BankDetail")
            BindData(.celAcctDetail, "Text", Nothing, "AcctDetail")
            BindData(.celAllotAmt, "Text", Nothing, "AllotAmt")
            BindData(.celOtherEarn, "Text", Nothing, "OtherEarn")
            BindData(.celDed, "Text", Nothing, "TotalDed")
            BindData(.celNetAmt, "Text", Nothing, "NetAmt")

            BindData(.celTotalAllotAmt, "Text", Nothing, "AllotAmt")
            BindData(.celTotalOtherEarn, "Text", Nothing, "OtherEarn")
            BindData(.celTotalDed, "Text", Nothing, "TotalDed")
            BindData(.celTotalNetAmt, "Text", Nothing, "NetAmt")

            .rptMonthlyHA_Sub_Detail.ReportSource = SubReport_Detail
            .rptMonthlyHA_Sub_Total.ReportSource = SubReport_Total

            AddFieldsToGroupHeaderBand(.GroupHeader_Vsl, "VslName", 1)
            AddFieldsToGroupHeaderBand(.GroupHeader_Curr, "AllotCurr", 1)
            AddFieldsToGroupHeaderBand(.GroupHeader_Crew, "CrewName", 1)
            
            AddHandler .celCrew.BeforePrint, AddressOf HandleBeforePrint
            AddHandler .celRank.BeforePrint, AddressOf HandleBeforePrint
            AddHandler .celAllotPHP.BeforePrint, AddressOf HandleBeforePrint
        End With

        With SubReport_Detail
            .DataSource = ds.Tables("Detail")

            BindData(.lblType, "Text", Nothing, "Type")
            BindData(.celItem, "Text", Nothing, "Item")
            BindData(.celAmt, "Text", Nothing, "Amt")

            .Detail.SortFields.Add(New GroupField("Item"))
            .Detail.SortFields("Item").SortOrder = XRColumnSortOrder.Ascending

            AddFieldsToGroupHeaderBand(.GroupHeader_Type, "WageType", 1)

            AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
        End With

        With SubReport_Total
            .DataSource = ds.Tables("GovtCont")
            
            BindData(.celCurr, "Text", Nothing, "Curr")
            BindData(.celItem, "Text", Nothing, "Item")
            BindData(.celTotalEE, "Text", Nothing, "AmtEE", "{0:#,##0.00}")
            BindData(.celTotalER, "Text", Nothing, "AmtER", "{0:#,##0.00}")

            .Detail.SortFields.Add(New GroupField("Item"))
            .Detail.SortFields("Item").SortOrder = XRColumnSortOrder.Ascending

            AddFieldsToGroupHeaderBand(.GroupHeader1, "Curr", 1)
        End With

        REPORT_DETAIL.MainReport = MainReport
        
    End Sub

    Private Sub SetDetailBand_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "PayAllotID='" & MainReport.GetCurrentColumnValue("PayAllotID").ToString & "'"
    End Sub

    Private Sub HandleBeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim dt As DataTable = CType(MainReport.DataSource, DataTable) '.Select("CrewName='' AND AllotCurr=''").CopyToDataTable
        Dim dRow_Curr As DataRowView
        Dim dRow_Prev As DataRowView

        dRow_Curr = CType(MainReport.GetCurrentRow, DataRowView)
        dRow_Prev = CType(MainReport.GetPreviousRow, DataRowView)

        'If InStr(dRow_Curr.Item("CrewName"), "omez") <> 0 Then
        '    MsgBox("")
        'End If
        MainReport.celAllotPHP.Text = Format(dt.Compute("SUM(Allotment)", "CrewName='" & dRow_Curr.Item("CrewName") & "' AND AllotCurr='" & dRow_Curr.Item("AllotCurr") & "'"), "#,##0.00")
        If MainReport.CurrentRowIndex <> 0 Then ' for next records checking
            If dRow_Curr.Item("CrewName") = dRow_Prev.Item("CrewName") And dRow_Curr.Item("AllotCurr") = dRow_Prev.Item("AllotCurr") Then 'if same crew name in currency group
                e.Cancel = True
            Else
                e.Cancel = False
                'MainReport.celAllotPHP.Text = Format(dt.Compute("SUM(Allotment)", "CrewName='" & dRow_Curr.Item("CrewName") & "' AND AllotCurr='" & dRow_Curr.Item("AllotCurr") & "'"), "#,##0.00")
            End If
        Else
            'MainReport.celAllotPHP.Text = Format(dt.Compute("SUM(Allotment)", "CrewName='" & dRow_Curr.Item("CrewName") & "' AND AllotCurr='" & dRow_Curr.Item("AllotCurr") & "'"), "#,##0.00")
        End If

    End Sub


End Class
