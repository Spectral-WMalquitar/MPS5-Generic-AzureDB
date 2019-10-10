
Public Class rptPayHACrew
    Public MainReport As New rptPayHAReportCrew
    Public SubRep_Earn As New rptPayHAReportCrew_sub_earn
    Public SubRep_Ded As New rptPayHAReportCrew_sub_ded
    Public SubRep_TotEarn As New rptPayHAReportCrew_sub_totsum_earn
    Public SubRep_TotDed As New rptPayHAReportCrew_sub_totsum_ded
    Public SubRep_NetSum As New rptPayHAReportCrew_sub_netSum
    Public frmfilter As New frmPayHACrewPS

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList

        frmfilter.cboPeriodFrom.EditValue = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        frmfilter.cboPeriodTo.EditValue = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        'frmfilter.CboCrew.EditValue = MPS4.FKeyVslCode




        frmfilter.ShowDialog()
        If Not frmfilter.NoIssue Then
            Exit Sub
        End If




        Dim dt As DataTable, dtearn As DataTable, dtDed As DataTable, dttotEarn As DataTable, dttotDed As DataTable
        Dim dtNetSum As DataTable
        Dim cSQL As String


        'neil20161208 Dim Period As Integer = REPORT_DETAIL.FilterOption.GetFilterValue("Period")

        Dim FKeyPrinCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Principal")
        Dim FKeyVslCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel")
        Dim RefNo As String = REPORT_DETAIL.FilterOption.GetFilterValue("RefNo")


        Dim finalstr As String = "", periodfr As String, periodto As String
        Dim kwitan As Boolean = False

        If frmfilter.cboPeriodFrom.EditValue <> Nothing Then
            finalstr = "@PeriodFrom = " & frmfilter.cboPeriodFrom.EditValue
            kwitan = True

            periodfr = MonthName(frmfilter.cboPeriodFrom.EditValue - ((frmfilter.cboPeriodFrom.EditValue \ 100) * 100)) & _
                         " " & frmfilter.cboPeriodFrom.EditValue \ 100
        Else
            periodfr = "First"
        End If

        If frmfilter.cboPeriodTo.EditValue <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@PeriodTo = " & frmfilter.cboPeriodTo.EditValue
            kwitan = True

            periodto = MonthName(frmfilter.cboPeriodTo.EditValue - ((frmfilter.cboPeriodTo.EditValue \ 100) * 100)) & _
                         " " & frmfilter.cboPeriodTo.EditValue \ 100

        Else
            periodto = "Latest"
            'kwitan = False
        End If

        If frmfilter.CboCrew.EditValue <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@CrewIDNbr = '" & frmfilter.CboCrew.EditValue & "'"
        End If

        If RefNo <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@RefNo = '" & RefNo & "'"
        End If

        If FKeyPrinCode <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@princode = '" & FKeyPrinCode & "'"
        End If

        If FKeyVslCode <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            'finalstr = finalstr & "@vslcode = '" & Replace(FKeyVslCode, ",", "','") & "'"
            finalstr = finalstr & "@vslcode = '" & FKeyVslCode & "'"
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "EXEC sp_pay_HomeAllot_report_m " & finalstr
        '& frmfilter.cboPeriodFrom.EditValue & _
        '"," & frmfilter.cboPeriodTo.EditValue & _
        '",'" & frmfilter.cboVsl.EditValue & "'"

        'If MainReportFilter.Length > 0 Then
        '    cSQL = cSQL & " WHERE " & MainReportFilter & " "
        'End If

        'If Sorting.Length > 0 Then
        '    cSQL = cSQL & " ORDER BY " & Sorting & " "
        'End If

        dt = MPSDB.CreateTable(cSQL)

        cSQL = "EXEC sp_pay_HomeAllot_report_netSum " & finalstr
        dtNetSum = MPSDB.CreateTable(cSQL)

        If finalstr <> "" Then
            finalstr = finalstr & ","
        End If

        cSQL = "EXEC sp_pay_HomeAllot_report_sub " & finalstr & "@wageType = 1"
        dtearn = MPSDB.CreateTable(cSQL)

        cSQL = "EXEC sp_pay_HomeAllot_report_sub " & finalstr & "@wageType = 2"
        dtDed = MPSDB.CreateTable(cSQL)

        cSQL = "EXEC sp_pay_HomeAllot_report_sum " & finalstr & "@wageType = 1"
        dttotEarn = MPSDB.CreateTable(cSQL)

        cSQL = "EXEC sp_pay_HomeAllot_report_sum " & finalstr & "@wageType = 2"
        dttotDed = MPSDB.CreateTable(cSQL)

        If frmfilter.chkSelectedCrew.Checked And WhereList.Length <> 0 Then
            If dt.Select("FKeyIDNbr IN " & WhereList).Count = 0 Then
                dt = Nothing
                MsgBox("No crew selected", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Utilities.Util.GetAppPath)
                Exit Sub
            Else
                dt = dt.Select("FKeyIDNbr IN " & WhereList).CopyToDataTable
            End If
        End If


        'dt = dt.Select("FKeyIDNbr IN " & WhereList).CopyToDataTable
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        'Dim dv = New DataView(dt)
        'dv.RowFilter = "FKeyIDNbr IN " & WhereList
        'MainReport.DataSource = dv
        MainReport.DataSource = dt
        'MainReport.Name = REPORT_DETAIL.ReportObjectID
        Dim periodtemp As String = ""

        If frmfilter.cboPeriodFrom.Text = Nothing And frmfilter.cboPeriodTo.Text = Nothing Then
            periodtemp = " All "
        Else
            If frmfilter.cboPeriodFrom.Text <> Nothing Then
                periodtemp = "From " & frmfilter.cboPeriodFrom.Text
            End If
            If frmfilter.cboPeriodTo.Text <> Nothing Then
                periodtemp = periodtemp & " To " & frmfilter.cboPeriodTo.Text

            End If
        End If

        MainReport.txtCompany.Text = MPSDB.GetConfig("NAME")
        MainReport.txtCoyAdd.Text = MPSDB.GetConfig("ADDR")
        MainReport.txtPeriod.Text = periodtemp

        MainReport.txtSignName.Text = REPORT_DETAIL.PreparedBy.Name.ToUpper
        MainReport.txtSignPos.Text = REPORT_DETAIL.PreparedBy.Position.ToUpper

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

End Class
