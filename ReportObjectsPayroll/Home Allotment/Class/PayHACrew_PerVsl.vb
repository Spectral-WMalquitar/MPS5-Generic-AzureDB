
Public Class PayHACrew_PerVsl
    Public MainReport As New rptPayHAReportCrew
    Public SubRep_Earn As New rptPayHAReportCrew_sub_earn
    Public SubRep_Ded As New rptPayHAReportCrew_sub_ded
    Public SubRep_TotEarn As New rptPayHAReportCrew_sub_totsum_earn
    Public SubRep_TotDed As New rptPayHAReportCrew_sub_totsum_ded
    Public SubRep_NetSum As New rptPayHAReportCrew_sub_netSum
    'Public frmfilter As New frmPayHACrewPS

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        'tonytest
        'If REPORT_DETAIL.FilterOption.GetFilterValue("Period From").ToString.Length = 0 Or _
        '    REPORT_DETAIL.FilterOption.GetFilterValue("Period To").ToString.Length = 0 Then
        '    MsgBox("Please select Period coverage to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
        '    Exit Sub
        'End If


        'period = MPS4.Period
        'period = MPS4.Period
        ''frmfilter.CboCrew.EditValue = MPS4.FKeyVslCode

        'frmfilter.ShowDialog()
        'If Not frmfilter.NoIssue Then
        '    Exit Sub
        'End If



        'MsgBox(period)
        'MsgBox(frmfilter.cboVsl.EditValue)

        Dim dt As DataTable, dtearn As DataTable, dtDed As DataTable, dttotEarn As DataTable, dttotDed As DataTable
        Dim dtNetSum As DataTable
        Dim cSQL As String
        'Dim Period As Integer = MPS4.Period
        'Dim FKeyPrinCode As String = MPS4.FKeyPrinCode
        'Dim FKeyVslCode As String = MPS4.FKeyVslCode
        'Dim RefNo As String = MPS4.RefNo

        'Dim Period_From As String = REPORT_DETAIL.FilterOption.GetFilterValue("Period From")
        'Dim Period_To As String = REPORT_DETAIL.FilterOption.GetFilterValue("Period To")
        'Dim FKeyPrinCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Principal")
        'Dim FKeyVslCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel")
        'Dim RefNo As String = REPORT_DETAIL.FilterOption.GetFilterValue("RefNo")
        'Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList

        'Dim finalstr As String = "", periodfr As String, periodto As String
        'Dim kwitan As Boolean = False

        'If Period_From <> Nothing Then
        '    finalstr = "@PeriodFrom = " & Period_From
        '    kwitan = True

        '    periodfr = MonthName(Period_From - ((Period_From \ 100) * 100)) & _
        '                 " " & Period_From \ 100
        'Else
        '    periodfr = "First"
        'End If

        'If Period_To <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@PeriodTo = " & Period_To
        '    kwitan = True

        '    periodto = MonthName(Period_To - ((Period_To \ 100) * 100)) & _
        '                 " " & Period_To \ 100

        'Else
        '    periodto = "Latest"
        '    'kwitan = False
        'End If

        ''If frmfilter.CboCrew.EditValue <> Nothing Then
        ''    If kwitan Then
        ''        finalstr = finalstr & ","
        ''    End If
        ''    finalstr = finalstr & "@CrewIDNbr = '" & frmfilter.CboCrew.EditValue & "'"
        ''End If

        'If RefNo <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@RefNo = '" & RefNo & "'"
        'End If

        'If FKeyPrinCode <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@princode = '" & FKeyPrinCode & "'"
        'End If

        'If FKeyVslCode <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@vslcode = '" & FKeyVslCode & "'"
        'End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        'cSQL = "EXEC sp_pay_HomeAllot_report_m " & finalstr
        cSQL = "EXEC sp_pay_HomeAllot_report_PerVsl_m " & REPORT_DETAIL.PresentRecord.SelectionList
        '& period & _
        '"," & period & _
        '",'" & frmfilter.cboVsl.EditValue & "'"

        'If MainReportFilter.Length > 0 Then
        '    cSQL = cSQL & " WHERE " & MainReportFilter & " "
        'End If

        'If Sorting.Length > 0 Then
        '    cSQL = cSQL & " ORDER BY " & Sorting & " "
        'End If


        Dim spMain As New StoredProcedureCommand("sp_pay_HomeAllot_report_PerVsl_m")
        spMain.Parameters.Add(New StoredProcedureCommand.SPParameter("@PrintSelection", REPORT_DETAIL.PresentRecord.Table))
        dt = spMain.Execute(StoredProcedureCommand.ReturnType.Table)

        'tonytest 
        'dt = MPSDB.CreateTable(cSQL)

        Dim spNetSum As New StoredProcedureCommand("sp_pay_HomeAllot_report_PerVsl_netSum")
        spNetSum.Parameters.Add(New StoredProcedureCommand.SPParameter("@PrintSelection", REPORT_DETAIL.PresentRecord.Table))
        dtNetSum = spNetSum.Execute(StoredProcedureCommand.ReturnType.Table)

        'cSQL = "EXEC sp_pay_HomeAllot_report_netSum " & finalstr
        'dtNetSum = MPSDB.CreateTable(cSQL)

        'If finalstr <> "" Then
        '    finalstr = finalstr & ","
        'End If

        'Earnings and Deductions
        Dim spEarnDed As New StoredProcedureCommand("sp_pay_HomeAllot_report_PerVsl_sub")
        spEarnDed.Parameters.Add(New StoredProcedureCommand.SPParameter("@PrintSelection", REPORT_DETAIL.PresentRecord.Table))
        Dim dsEarnDed As DataSet = spEarnDed.Execute(StoredProcedureCommand.ReturnType.DataSet)

        'cSQL = "EXEC sp_pay_HomeAllot_report_sub " & finalstr & "@wageType = 1"
        'dtearn = MPSDB.CreateTable(cSQL)
        dtearn = dsEarnDed.Tables(0)

        'cSQL = "EXEC sp_pay_HomeAllot_report_sub " & finalstr & "@wageType = 2"
        'dtDed = MPSDB.CreateTable(cSQL)
        dtDed = dsEarnDed.Tables(1)


        'Earnings and Deductions
        Dim spTotEarnDed As New StoredProcedureCommand("sp_pay_HomeAllot_report_PerVsl_sum")
        spTotEarnDed.Parameters.Add(New StoredProcedureCommand.SPParameter("@PrintSelection", REPORT_DETAIL.PresentRecord.Table))
        Dim dsTotEarnDed As DataSet = spTotEarnDed.Execute(StoredProcedureCommand.ReturnType.DataSet)

        'cSQL = "EXEC sp_pay_HomeAllot_report_sum " & finalstr & "@wageType = 1"
        'dttotEarn = MPSDB.CreateTable(cSQL)
        dttotEarn = dsTotEarnDed.Tables(0)

        'cSQL = "EXEC sp_pay_HomeAllot_report_sum " & finalstr & "@wageType = 2"
        'dttotDed = MPSDB.CreateTable(cSQL)
        dttotDed = dsTotEarnDed.Tables(1)

        'If WhereList.Length <> 0 Then
        '    If dt.Select("FKeyIDNbr IN " & WhereList).Count = 0 Then
        '        dt = Nothing
        '    Else
        '        dt = dt.Select("FKeyIDNbr IN " & WhereList).CopyToDataTable
        '    End If
        'End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        'MainReport.Name = REPORT_DETAIL.ReportObjectID
        'Dim periodtemp As String = ""

        'If Period_From = Nothing And Period_To = Nothing Then
        '    periodtemp = " All "
        'Else
        '    If Period_From <> Nothing Then
        '        periodtemp = "From " & periodfr
        '    End If
        '    If Period_To <> Nothing Then
        '        periodtemp = periodtemp & " To " & periodto

        '    End If
        'End If

        MainReport.txtCompany.Text = MPSDB.GetConfig("NAME")
        MainReport.txtCoyAdd.Text = MPSDB.GetConfig("ADDR")
        MainReport.txtPeriod.Text = "For the month of: " & MainReport.GetCurrentColumnValue("Period").ToString
        'MainReport.txtPeriod.Text = periodtemp

        'MainReport.txtSignName.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper
        'MainReport.txtSignPos.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper

        With MainReport


            BindData(.txtCrewName, "Text", Nothing, "CrewName", )
            BindData(.txtRank, "Text", Nothing, "RankName", )
            BindData(.txtAllottee, "Text", Nothing, "AllotName")
            BindData(.txtAllotteeAdd, "Text", Nothing, "allottee_add")
            BindData(.txtBank, "Text", Nothing, "banknbranch")
            BindData(.txtAcctNo, "Text", Nothing, "AcctNbr")
            BindData(.txtBankCurrency, "Text", Nothing, "allot_curr")
            BindData(.txtVesselName, "Text", Nothing, "vslname")
            BindData(.txtFleet, "Text", Nothing, "fltname")
            BindData(.txtAllotUSD, "Text", Nothing, "AllotmentAmt", "{0:#,##0.00}")
            BindData(.txtAllotPHP, "Text", Nothing, "CAmt", "{0:#,##0.00}")
            BindData(.txtExRate, "Text", Nothing, "ExRate", "{0:#,##0.00}")

            BindData(.txtAllotUSD_lbl, "Text", Nothing, "allot_curr", "ALLOTMENT {0}")
            BindData(.txtAllotPHP_lbl, "Text", Nothing, "conv_curr", "ALLOTMENT {0}")
            BindData(.txtExRate_lbl, "Text", Nothing, "allot_curr", "{0} Exchange Rate")

            AddFieldsToGroupHeaderBand(MainReport.mcodegroup, "MCode", FieldSortOrder.Descending)
            AddFieldsToGroupHeaderBand(MainReport.allotteegroup, "AllotteeID", FieldSortOrder.Ascending)

            .subREarn.ReportSource = SubRep_Earn
            .subRDed.ReportSource = SubRep_Ded
            .SubRTotEarn.ReportSource = SubRep_TotEarn
            .SubRTotDed.ReportSource = SubRep_TotDed
            .SubRNetSum.ReportSource = SubRep_NetSum
            AddHandler MainReport.Detail.BeforePrint, AddressOf MainReportDetailBand_BeforePrint
        End With

        With SubRep_Earn

            .DataSource = dtearn
            BindData(.txtEarnItem, "Text", Nothing, "WageName", "{0:#,##0.00}")
            BindData(.txtItemEarnAmt, "Text", Nothing, "CAmt", "{0:#,##0.00}")
            BindData(.txtItemEarnAmtSum, "Text", Nothing, "CAmt", "{0:#,##0.00}")
            .txtItemEarnAmtSum.Summary.Running = SummaryRunning.Report
            AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
        End With

        With SubRep_Ded

            .DataSource = dtDed
            BindData(.txtDedItem, "Text", Nothing, "WageName", "{0:#,##0.00}")
            BindData(.txtItemDedAmt, "Text", Nothing, "CAmt", "{0:#,##0.00}")
            BindData(.txtItemDedAmtSum, "Text", Nothing, "CAmt", "{0:#,##0.00}")
            .txtItemDedAmtSum.Summary.Running = SummaryRunning.Report
            AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
        End With

        With SubRep_TotEarn
            .DataSource = dttotEarn
            BindData(.txtTotalEarnAmtSum, "Text", Nothing, "totamt", "{0:#,##0.00}")
            AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
        End With

        With SubRep_TotDed
            .DataSource = dttotDed
            BindData(.txtTotalDedAmtSum, "Text", Nothing, "totamt", "{0:#,##0.00}")
            AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
        End With

        With SubRep_NetSum
            .DataSource = dtNetSum
            BindData(.txtNetAllot, "Text", Nothing, "NetSum", "{0:#,##0.00}")
            AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub

    Private Sub SetDetailBand_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "PKeyAllot='" & MainReport.GetCurrentColumnValue("PKeyAllot").ToString & "'"

        If TryCast(sender, DevExpress.XtraReports.UI.XtraReport).RowCount <= 0 Then
            TryCast(sender, DevExpress.XtraReports.UI.XtraReport).Visible = False
        Else
            TryCast(sender, DevExpress.XtraReports.UI.XtraReport).Visible = True
        End If
    End Sub

    Private Sub MainReportDetailBand_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        MainReport.txtPeriod.Text = "For the month of: " & MainReport.GetCurrentColumnValue("Period").ToString
    End Sub

    'Private Sub ExecuteSP(oReportDetail As Reports.ReportDetail)

    '    Dim sqlTrans As SqlClient.SqlTransaction = Nothing
    '    Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(MPSDB.GetConnectionString())
    '    Dim retVal As Boolean = False

    '    sqlTrans = sqlConn.BeginTransaction()

    '    Using command As New SqlClient.SqlCommand()
    '        command.Connection = sqlConn
    '        command.CommandTimeout = 5000
    '        command.Transaction = sqlTrans
    '        command.CommandText = "EXEC sp_pay_HomeAllot_report_PerVsl_m "

    '        'Add Parameters
    '        command.Parameters.AddWithValue("@PrintSelection", oReportDetail.PresentRecord.Table)

    '        command.ExecuteNonQuery()
    '    End Using
    'End Sub
End Class

