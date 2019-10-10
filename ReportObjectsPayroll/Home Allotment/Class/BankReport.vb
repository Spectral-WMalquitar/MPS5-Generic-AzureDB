Imports Reports

Public Class BankReport
    Public MainReport As New rptBankReport

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        '--------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATES IF A PERIOD IS SELECTED FROM THE FILTER OPTION IN THE REPORT SELECTION FORM
        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").Equals(Nothing) Then
            MsgBox("Please select a period.", MsgBoxStyle.Information)
            Exit Sub
        Else
            If REPORT_DETAIL.FilterOption.GetFilterValue("Period").Equals("") Then
                MsgBox("Please select a period.", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrincipal", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM dbo.RPT_Pay_BankReport "

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

        SetDefaultReportLabels(MainReport, MPSDB)

        MainReport.lblPeriod.Text = "for the period of: " & Format(Utilities.Util.NumCodeToDate(REPORT_DETAIL.FilterOption.GetFilterValue("Period"), 1), "MMMM-yyyy")

        If Not IsNothing(REPORT_DETAIL.FilterOption.GetFilterValue("Date Remitted")) Then
            If IsDate(REPORT_DETAIL.FilterOption.GetFilterValue("Date Remitted")) Then
                MainReport.celDateRemitted.Text = Format(CDate(REPORT_DETAIL.FilterOption.GetFilterValue("Date Remitted")), "dd-MMM-yyyy")
            End If
        End If

        BindData(MainReport.celPrincipal, "Text", Nothing, "PrinName")
        BindData(MainReport.celCurrency, "Text", Nothing, "Currency")
        BindData(MainReport.celExRate, "Text", Nothing, "CurrencyExRate", "{0:#,###.00}")

        BindData(MainReport.celBankBranch, "Text", Nothing, "BankName")
        BindData(MainReport.celAccountNumber, "Text", Nothing, "AcctNbr")
        BindData(MainReport.celAccountName, "Text", Nothing, "BenefAcctName")
        BindData(MainReport.celAmount, "Text", Nothing, "RemitAmount", "{0:#,###.00}")

        BindData(MainReport.celSubTotal, "Text", Nothing, "RemitAmount", "{0:#,###.00}")
        BindData(MainReport.celGrandTotal, "Text", Nothing, "RemitAmount", "{0:#,###.00}")


        If Not IsNothing(REPORT_DETAIL.FilterOption.GetFilterValue("Prepared By")) Then
            MainReport.celPreparedBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Prepared By")
        End If
        If Not IsNothing(REPORT_DETAIL.FilterOption.GetFilterValue("Verified By")) Then
            MainReport.celVerifiedBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Verified By")
        End If
        If Not IsNothing(REPORT_DETAIL.FilterOption.GetFilterValue("Approved By")) Then
            MainReport.celApprovedBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Approved By")
        End If

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Principal, "PrinName", REPORT_DETAIL.SortOption.GetSortValueCode("PrinName"))
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Currency, "CurrencySort", REPORT_DETAIL.SortOption.GetSortValueCode("Currency"))
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Currency, "Currency", FieldSortOrder.Ascending)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_BankBranch, "BankName", REPORT_DETAIL.SortOption.GetSortValueCode("Bank"))

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        AddHandler MainReport.GroupFooter2.BeforePrint, AddressOf GroupFooterGrandTotal_BeforePrint
        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub GroupFooterGrandTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)
        MainReport.lblGrandTotal.Text = "Grand Total (" & MainReport.GetCurrentColumnValue("Currency") & "):"
    End Sub
End Class
