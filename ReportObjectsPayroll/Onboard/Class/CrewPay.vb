
Public Class CrewPay
    Public MainReport As New rptCrewPay

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String

        Dim MainReportFilter As String = ""
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim Period As Integer = 0
        Dim Period_End As Integer = 0
        Dim FKeyPrin As String = ""
        Dim FKeyVslCode As String = ""
        Dim RefNo As String = ""

        If REPORT_DETAIL.ReportObjectID = "rptCrewPay_Ind" Then
            If (REPORT_DETAIL.FilterOption.GetFilterValue("Period From").ToString.Length = 0 Or _
                REPORT_DETAIL.FilterOption.GetFilterValue("Period To").ToString.Length = 0) Then
                MsgBox("Please select Period range to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
                Exit Sub
            End If
            Period = REPORT_DETAIL.FilterOption.GetFilterValue("Period From")
            Period_End = REPORT_DETAIL.FilterOption.GetFilterValue("Period To")
        ElseIf REPORT_DETAIL.ReportObjectID = "rptCrewPay_Vsl" Then
            If REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString.Length = 0 Then
                MsgBox("Please select a Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
                Exit Sub
            End If
            Period = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
            FKeyPrin = REPORT_DETAIL.FilterOption.GetFilterValue("Principal")
            FKeyVslCode = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel", BaseFilterOption.GetFilterReturnWhat.EditValue, True)
            RefNo = REPORT_DETAIL.FilterOption.GetFilterValue("RefNo", BaseFilterOption.GetFilterReturnWhat.EditValue, True)
        End If

        If InStr(REPORT_DETAIL.ReportInfo.ReportGroup, "(QUICK VIEW)") = 0 Then
            MainReportFilter = REPORT_DETAIL.GetMainReportFilter
        End If

        MainReportFilter = IIf(MainReportFilter.Length <> 0, MainReportFilter & " AND ", "") & _
            IIf(Period_End <> 0, " Period>=", " Period=") & "'" & Period & "'" & _
            IIf(Period_End <> 0, " AND Period<='" & Period_End & "'", "") & _
            IIf(FKeyPrin.Length <> 0, " AND FKeyPrin='" & FKeyPrin & "'", "") & _
            IIf(FKeyVslCode.Length <> 0, " AND FKeyVsl IN (" & FKeyVslCode & ")", "") & _
            IIf(RefNo.Length <> 0, " AND PayID IN(" & RefNo & ")", "")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE        
        cSQL = "SELECT *, " & _
            "(UPPER(FORMAT(dbo.ChangeMCodeToDate(Period, '1'), 'MMM-yyyy'))) AS PeriodName, " & _
            "(CAST(FORMAT(DateStart, 'dd-MMM-yyyy') AS varchar) + ' - ' + CAST(FORMAT(DateEnd, 'dd-MMM-yyyy') AS varchar)) AS PeriodDesc, " & _
            "(CAST(DATEPART(DAY, DateStart) AS varchar) + ' - ' + CAST(DATEPART(DAY, DateEnd) AS varchar)) AS PeriodDesc2 " & _
            "FROM Rpt_CrewPay "

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
        REPORT_DETAIL.dtMainSource = dt
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        If REPORT_DETAIL.ReportObjectID = "rptCrewPay_Ind" Then
            With MainReport
                .DetailReport_Vsl.Visible = False
                .DetailReport_Ind.DataSource = dt

                BindData(.celCrewName, "Text", Nothing, "Crew")
                BindData(.celVslName, "Text", Nothing, "VslName")
                BindData(.celPeriodDesc, "Text", Nothing, "PeriodDesc")
                BindData(.celRank, "Text", Nothing, "RankName")
                BindData(.celBasic, "Text", Nothing, "Basic", "{0:#,##0.00}")
                BindData(.celOT, "Text", Nothing, "OT", "{0:#,##0.00}")
                BindData(.celMaintBon, "Text", Nothing, "MaintBonus", "{0:#,##0.00}")
                BindData(.celSenBon, "Text", Nothing, "SenBon", "{0:#,##0.00}")
                BindData(.celEOT, "Text", Nothing, "EOT", "{0:#,##0.00}")
                BindData(.celLPay, "Text", Nothing, "LPay", "{0:#,##0.00}")
                BindData(.celPrevBal, "Text", Nothing, "PrevBal", "{0:#,##0.00}")
                BindData(.celOtherE, "Text", Nothing, "OtherEarn", "{0:#,##0.00}")
                BindData(.celTotalE, "Text", Nothing, "TotalEarn", "{0:#,##0.00}")
                BindData(.celAllot, "Text", Nothing, "Allotment", "{0:#,##0.00}")
                BindData(.celEAllot, "Text", Nothing, "ExtraAllot", "{0:#,##0.00}")
                BindData(.celCA, "Text", Nothing, "CashAdv", "{0:#,##0.00}")
                BindData(.celSlop, "Text", Nothing, "SlopChest", "{0:#,##0.00}")
                BindData(.celFPay, "Text", Nothing, "FPay", "{0:#,##0.00}")
                BindData(.celOrder, "Text", Nothing, "PvtOrder", "{0:#,##0.00}")
                BindData(.celOtherD, "Text", Nothing, "OtherDeduct", "{0:#,##0.00}")
                BindData(.celTotalD, "Text", Nothing, "TotalDeduct", "{0:#,##0.00}")
                BindData(.celNetAmt, "Text", Nothing, "NetPay", "{0:#,##0.00}")
                BindData(.celPrevLPay, "Text", Nothing, "PrevLPay", "{0:#,##0.00}")
                BindData(.celCurrLPay, "Text", Nothing, "CurrentLPay", "{0:#,##0.00}")
                BindData(.celFwLPay, "Text", Nothing, "FwdLPay", "{0:#,##0.00}")

                AddSortFieldsToDetailBandFromDT(.Detail_Ind, REPORT_DETAIL.SortOption.SortDataSource)
                AddFieldsToGroupHeaderBand(.GroupHeader_Ind, REPORT_DETAIL.SortOption.SortDataSource)
            End With

        ElseIf REPORT_DETAIL.ReportObjectID = "rptCrewPay_Vsl" Then

            With MainReport
                .DetailReport_Ind.Visible = False
                .DetailReport_Vsl.DataSource = dt

                BindData(.celPeriod, "Text", Nothing, "PeriodName")
                BindData(.celCrewName2, "Text", Nothing, "Crew")
                BindData(.celVslName2, "Text", Nothing, "VslName")
                BindData(.celPeriodDesc2, "Text", Nothing, "PeriodDesc2")
                BindData(.celRank2, "Text", Nothing, "RankName")
                BindData(.celBasic2, "Text", Nothing, "Basic", "{0:#,##0.00}")
                BindData(.celOT2, "Text", Nothing, "OT", "{0:#,##0.00}")
                BindData(.celMaintBon2, "Text", Nothing, "MaintBonus", "{0:#,##0.00}")
                BindData(.celSenBon2, "Text", Nothing, "SenBon", "{0:#,##0.00}")
                BindData(.celEOT2, "Text", Nothing, "EOT", "{0:#,##0.00}")
                BindData(.celLPay2, "Text", Nothing, "LPay", "{0:#,##0.00}")
                BindData(.celPrevBal2, "Text", Nothing, "PrevBal", "{0:#,##0.00}")
                BindData(.celOtherE2, "Text", Nothing, "OtherEarn", "{0:#,##0.00}")
                BindData(.celTotalE2, "Text", Nothing, "TotalEarn", "{0:#,##0.00}")
                BindData(.celAllot2, "Text", Nothing, "Allotment", "{0:#,##0.00}")
                BindData(.celEAllot2, "Text", Nothing, "ExtraAllot", "{0:#,##0.00}")
                BindData(.celCA2, "Text", Nothing, "CashAdv", "{0:#,##0.00}")
                BindData(.celSlop2, "Text", Nothing, "SlopChest", "{0:#,##0.00}")
                BindData(.celFPay2, "Text", Nothing, "FPay", "{0:#,##0.00}")
                BindData(.celOrder2, "Text", Nothing, "PvtOrder", "{0:#,##0.00}")
                BindData(.celOtherD2, "Text", Nothing, "OtherDeduct", "{0:#,##0.00}")
                BindData(.celTotalD2, "Text", Nothing, "TotalDeduct", "{0:#,##0.00}")
                BindData(.celNetAmt2, "Text", Nothing, "NetPay", "{0:#,##0.00}")
                BindData(.celPrevLPay2, "Text", Nothing, "PrevLPay", "{0:#,##0.00}")
                BindData(.celCurrLPay2, "Text", Nothing, "CurrentLPay", "{0:#,##0.00}")
                BindData(.celFwLPay2, "Text", Nothing, "FwdLPay", "{0:#,##0.00}")

                AddSortFieldsToDetailBandFromDT(.Detail_Vsl, REPORT_DETAIL.SortOption.SortDataSource)
                AddFieldsToGroupHeaderBand(.GroupHeader_Vsl, REPORT_DETAIL.SortOption.SortDataSource)
            End With

        Else
            MsgBox("Unable to preview report. Report not found.", vbCritical + vbOK, Utilities.Util.GetAppName())
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub

End Class
