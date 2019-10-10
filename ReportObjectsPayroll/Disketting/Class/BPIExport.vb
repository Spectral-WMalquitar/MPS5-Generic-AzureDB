Imports System.Windows.Forms
Imports System.IO
Imports Utilities

Public Class BPIExport

    Dim MainReport As New rptBPIExport
#Region "Main Report"
    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        'Dim dt As DataTable
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE MANDATORY REFERENCE FIELDS
        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Period"), "").Equals("") Then
            If REPORT_DETAIL.ShowMsgBox Then MsgBox("Please enter the Period.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Ref. No."), "").Equals("") Then
            If REPORT_DETAIL.ShowMsgBox Then MsgBox("Please enter a Ref. No.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Transaction Date"), "").Equals("") Then
            If REPORT_DETAIL.ShowMsgBox Then MsgBox("Please enter the Transaction Date", MsgBoxStyle.Information)
            Exit Sub
        End If


        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        Dim sp As StoredProcedureCommand = CreateSP(REPORT_DETAIL)
        Dim ds As New DataSet
        ds = sp.Execute(StoredProcedureCommand.ReturnType.DataSet, REPORT_DETAIL.ShowMsgBox)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(ds.Tables(0), REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        If REPORT_DETAIL.Output.Mode = ReportOutputMode.Export Then
            Dim cExportFile As String = CreateBPIExportFile(ds.Tables(0))
            If cExportFile.Length > 0 Then

                For Each r As DataRow In ds.Tables(1).Rows
                    MPSDB.SavePayrollLog(r("PayID"), _
                                         r("MCode"), _
                                         r("PayRefNo"), _
                                         r("PayType"), _
                                         r("Principal"), _
                                         r("VslName"), _
                                         USER_ID, DateTime.Now,
                                         LockType.BPIBankExport, _
                                         My.Computer.Name, "")
                Next
                
                If MsgBox("Successfully created BPI export file [" & cExportFile & "]." & vbNewLine & vbNewLine & "Do you want to view the report?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
                    REPORT_DETAIL.Output.Mode = ReportOutputMode.None   'set to none so it won't generate an output from the reportselection form
                    Exit Sub
                Else
                    GoTo PREVIEW_REPORT
                End If
            Else
                MsgBox("There was a problem encountered when generating the BPI export file. Please try again or contact your system administrator for assistance.", MsgBoxStyle.Information)
                Exit Sub
            End If

        End If

        Exit Sub

PREVIEW_REPORT:

        REPORT_DETAIL.Output.Mode = ReportOutputMode.Preview
        MainReport.DataSource = ds.Tables(0)
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.celCompany.Text = MPSDB.GetConfig("Name")
        MainReport.celMoYr.Text = "for the month of: " & Format(NumCodeToDate(REPORT_DETAIL.FilterOption.GetFilterValue("Period"), 1), "MMM-yyyy")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        BindData(MainReport.celVessel, "Text", Nothing, "VslName")
        BindData(MainReport.celPrincipal, "Text", Nothing, "Principal")
        BindData(MainReport.celCurrency, "Text", Nothing, "FundingCurr")
        BindData(MainReport.celCrewName, "Text", Nothing, "CrewName")
        BindData(MainReport.celAllotteeName, "Text", Nothing, "AllotteeName")
        BindData(MainReport.celBankBranch, "Text", Nothing, "BankBranch")
        BindData(MainReport.celAccountNo, "Text", Nothing, "AccountNo")
        BindData(MainReport.celGrossPayable, "Text", Nothing, "GrossAmount", "{0:#,###.00}")
        BindData(MainReport.celGrossPayable_Group, "Text", Nothing, "GrossAmount")
        BindData(MainReport.celGrossPayable_Report, "Text", Nothing, "GrossAmount")
        BindData(MainReport.celNetPayable, "Text", Nothing, "GrossAmount", "{0:#,###.00}")
        BindData(MainReport.celNetPayable_Group, "Text", Nothing, "GrossAmount")
        BindData(MainReport.celNetPayable_Report, "Text", Nothing, "GrossAmount")
        BindData(MainReport.celTotalAllottee_Group, "Text", Nothing, "AllotteeName")
        BindData(MainReport.celTotalAllottee_Report, "Text", Nothing, "AllotteeName")


        'signatories
        MainReport.celPreparedBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Prepared By")
        MainReport.celVerifiedBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Verified By")
        MainReport.celCheckedBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Checked By")
        MainReport.celApprovedBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Approved By")

        '---------------------------------------------------------------------------------------------------------------------------------------

        BindData(MainReport.celGrandTotal, "Text", Nothing, "FundingCurr", "GRAND TOTAL ({0:0})")


        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Currency, "FundingCurr", FieldSortOrder.Ascending)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Vsl, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Vsl, "Principal", REPORT_DETAIL.SortOption.GetSortValueCode("Principal"))

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------

    End Sub
#End Region

#Region "Exporting"
    Private Function CreateSP(REPORT_DETAIL As ReportDetail) As StoredProcedureCommand
        Dim sp As New StoredProcedureCommand("BPI_GenerateData")
        With sp.Parameters
            .Add(New StoredProcedureCommand.SPParameter("PrintSelection", REPORT_DETAIL.PresentRecord.Table))
            .Add(New StoredProcedureCommand.SPParameter("RefNo", REPORT_DETAIL.FilterOption.GetFilterValue("Ref. No.")))
            .Add(New StoredProcedureCommand.SPParameter("TransDate", REPORT_DETAIL.FilterOption.GetFilterValue("Transaction Date")))
            .Add(New StoredProcedureCommand.SPParameter("MCode", REPORT_DETAIL.FilterOption.GetFilterValue("Period")))
            If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Agent"), "").Equals("") Then
                .Add(New StoredProcedureCommand.SPParameter("AgentCode", System.DBNull.Value))
            Else
                .Add(New StoredProcedureCommand.SPParameter("AgentCode", REPORT_DETAIL.FilterOption.GetFilterValue("Agent")))
            End If

            If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Principal"), "").Equals("") Then
                .Add(New StoredProcedureCommand.SPParameter("PrinCode", System.DBNull.Value))
            Else
                .Add(New StoredProcedureCommand.SPParameter("PrinCode", REPORT_DETAIL.FilterOption.GetFilterValue("Principal")))
            End If

            If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Fleet"), "").Equals("") Then
                .Add(New StoredProcedureCommand.SPParameter("FltCode", System.DBNull.Value))
            Else
                .Add(New StoredProcedureCommand.SPParameter("FltCode", REPORT_DETAIL.FilterOption.GetFilterValue("Fleet")))
            End If
        End With

        Return sp
    End Function

    Function CreateBPIExportFile(dt As DataTable) As String
        Dim cExportPath As String = ""
        Dim oFolderBrowserDialog As New FolderBrowserDialog
        MsgBox("Select the directory where the file will be saved.", MsgBoxStyle.Information)

        Dim nResult As Integer = oFolderBrowserDialog.ShowDialog()

        If nResult = DialogResult.OK Then
            cExportPath = oFolderBrowserDialog.SelectedPath
            If cExportPath.Length = 0 Then
                MsgBox("No directory selected.", MsgBoxStyle.Information)
                Return ""
                Exit Function
            End If
        ElseIf nResult = DialogResult.Cancel Then
            MsgBox("Canceled by user.", MsgBoxStyle.Information)
            Return ""
            Exit Function
        End If

        Dim xl As New clsExcelFunction
        Dim row As clsExcelFunction.clsColumnRow = xl.Row
        Dim col As clsExcelFunction.clsColumnRow = xl.Column

        '------------------------------------------------------------------------------------------------------------------------------------------------
        'SETUP COLUMNS
        xl.SetExcelValue(xl.Range(col.Number, row.Number), "ACCOUNT NUMBER")
        col.Increment()

        xl.SetExcelValue(xl.Range(col.Number, row.Number), "ALLOTTEE NAME")
        col.Increment()

        xl.SetExcelValue(xl.Range(col.Number, row.Number), "GROSAMT")
        col.Increment()

        xl.SetExcelValue(xl.Range(col.Number, row.Number), "FUNDING CURR")
        col.Increment()

        xl.SetExcelValue(xl.Range(col.Number, row.Number), "DATE")
        col.Increment()

        xl.SetExcelValue(xl.Range(col.Number, row.Number), "REMITTER")
        col.Increment()

        xl.SetExcelValue(xl.Range(col.Number, row.Number), "BANK CODE")
        col.Increment()

        xl.SetExcelValue(xl.Range(col.Number, row.Number), "BANK")
        col.Increment()


        '------------------------------------------------------------------------------------------------------------------------------------------------

        For Each r As DataRow In dt.Rows
            col.Number = 1
            row.Increment()

            xl.SetRangeNumberFormat(xl.Range(col.Number, row.Number), "@")
            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("AccountNo"))
            col.Increment()

            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("AllotteeName"))
            col.Increment()

            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("GrossAmount"))
            col.Increment()

            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("FundingCurr"))
            col.Increment()

            xl.SetRangeNumberFormat(xl.Range(col.Number, row.Number), "m/d/yyyy;@")
            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("TranDate"))
            col.Increment()

            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("Remitter"))
            col.Increment()

            xl.SetRangeNumberFormat(xl.Range(col.Number, row.Number), "@")
            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("BankCode"))
            col.Increment()

            xl.SetExcelValue(xl.Range(col.Number, row.Number), r("Bank"))
            col.Increment()

        Next

        xl.AutoFitColumn(1, col.Number - 1)

        Dim cExportFile As String = cExportPath & IIf(Right(cExportPath, 1) <> "\", "\", "") & Format(System.DateTime.Now(), "BPI_yyyyMMddhhmmss") & ".xlsx"
        xl.SaveExcelFile(True, cExportFile)

        Return cExportFile
    End Function
#End Region
End Class
