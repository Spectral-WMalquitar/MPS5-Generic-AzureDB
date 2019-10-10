Public Class rptPaySASummaryVsl
    Public MainReport As New rptPaySASummaryReportVsl
    Public frmfilter As New frmPaySASummaryVslPS

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        frmfilter.cboPeriodFrom.EditValue = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        frmfilter.cboPeriodTo.EditValue = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        frmfilter.cboVsl.EditValue = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel")

        frmfilter.ShowDialog()
        If Not frmfilter.NoIssue Then
            Exit Sub
        End If



        'MsgBox(frmfilter.cboPeriodFrom.EditValue)
        'MsgBox(frmfilter.cboVsl.EditValue)

        Dim dt As DataTable
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

        If frmfilter.cboVsl.EditValue <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@vslcode = '" & frmfilter.cboVsl.EditValue & "'"
        End If

        If RefNo <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@RefNo = '" & RefNo & "'"
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "EXEC SP_PAY_MPOSummaryVsl " & finalstr
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

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

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
        MainReport.txtPayPeriod.Text = periodtemp
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        With MainReport

            BindData(.txtVesselName, "Text", Nothing, "VslName")
            'neil BindData(.txtRefName, "Text", Nothing, "RefNo")
            BindData(.colCrewName, "Text", Nothing, "CrewName")
            'neil  BindData(.colAllottee, "Text", Nothing, "AllotName")
            BindData(.colBank, "Text", Nothing, "Bank")
            BindData(.colAcctName, "Text", Nothing, "AcctName")
            BindData(.colAcctNo, "Text", Nothing, "AcctNbr")
            'neil BindData(.colCurr, "Text", Nothing, "Currency")
            'neil BindData(.colExRate, "Text", Nothing, "ExRate", "{0:n2}")
            'neil BindData(.colEarn, "Text", Nothing, "TcEarn", "{0:n2}")
            'neil BindData(.colDed, "Text", Nothing, "TcDed", "{0:n2}")
            BindData(.colTotal, "Text", Nothing, "TotalMPOcAmt", "{0:n2}")
            'neil BindData(.colTEarn, "Text", Nothing, "TcEarn", "{0:n2}")
            'neil BindData(.colTDed, "Text", Nothing, "TcDed", "{0:n2}")
            BindData(.colTotalMPO, "Text", Nothing, "TotalMPOcAmt", "{0:n2}")

            BindData(.txtGrpCurrency, "Text", Nothing, "Currency")
            BindData(.txtPeriod, "Text", Nothing, "MCodeStr", )

            'BindData(.colCrewName, "Text", Nothing, "AgentName")
            'BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
            'BindData(MainReport.celPlanRank, "Text", Nothing, "PlanRankName")z
            'BindData(MainReport.celDateAccepted, "Text", Nothing, "DateAccepted", "{0:dd-MMM-yyyy}")
            'BindData(MainReport.celPlanVsl, "Text", Nothing, "PlanVslName")
            'BindData(MainReport.celPlanJoinDate, "Text", Nothing, "PlanJoinDate", "{0:dd-MMM-yyyy}")
            'BindData(MainReport.celAgentCnt, "Text", Nothing, "Crew")
            'BindData(MainReport.celAgentBot, "Text", Nothing, "AgentName")

            AddFieldsToGroupHeaderBand(MainReport.CurrGroup, "Currency", 1)
            AddFieldsToGroupHeaderBand(MainReport.VslGroup, "VslCode", 1)
            AddFieldsToGroupHeaderBand(MainReport.MCodeGroup, "MCode", FieldSortOrder.Descending)
            'AddFieldsToGroupHeaderBand(MainReport.CurrGroup, "FKeyCurr")
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
