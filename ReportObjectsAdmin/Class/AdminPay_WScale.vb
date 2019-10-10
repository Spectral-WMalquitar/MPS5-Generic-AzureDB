Public Class AdminPay_WScale
    Public MainReport As New rptAdminPay_WScale

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT	ws.PKey WScalePKey, " & _
               "        ws.Name WScaleName, " & _
               "        ws.Abbrv WScaleAbbrv, " & _
               "        ws.FKeyCurr,  " & _
               "        curr.Name Curr,  " & _
               "        ws.RateType, " & _
               "		CASE WHEN RateType = 1 THEN 'Monthly' ELSE CASE WHEN RateType = 2 THEN 'Daily' ELSE '' END END RateTypeDesc,  " & _
               "		DateAct DateInactive, " & _
               "        wsrank.FKeyRank, " & _
               "		[rank].Name as RankName, " & _
               "        [rank].SortCode RankSort, " & _
               "		CASE WHEN len(isnull(wsrank.LOC,'')) > 0 THEN concat(wsrank.LOC, ' months') ELSE '' END  " & _
               "			+ CASE WHEN len(isnull(wsrank.LOC,'')) > 0 AND len(isnull(wsrank.LOCDays,'')) > 0 THEN ' ' ELSE '' END " & _
               "			+ CASE WHEN len(isnull(wsrank.LOCDays,'')) > 0 THEN concat(wsrank.LOCDays, ' days') ELSE '' END ContractPeriod, " & _
               "		isnull(basicwage.Amt,0) [Basic], " & _
               "		ISNULL(workhours.Int,0) [WorkingHours], " & _
               "		ISNULL(leavedays.Int,0) [LeaveDays], " & _
               "		ISNULL(leavepay.Amt,0) [LeavePay], " & _
               "		ISNULL(othours.Int,0) [OTHours], " & _
               "		ISNULL(otrate.Int,0) [OTRate], " & _
               "        ISNULL(othours.Int,0) * ISNULL(otrate.Int,0) [OT], " & _
               "        ws.Remarks " & _
               " " & _
               "FROM	dbo.tblAdmWscale ws INNER JOIN  " & _
               "		dbo.tblAdmWscaleRank wsrank ON wsrank.FKeyWScale = ws.PKey LEFT JOIN  " & _
               "		dbo.tblAdmCurr curr ON ws.FKeyCurr = curr.PKey LEFT JOIN " & _
               "		dbo.tbladmrank [rank] ON [rank].PKey = wsrank.FKeyRank LEFT JOIN " & _
               "		(SELECT * FROM dbo.tblAdmWscaleOnb WHERE FKeyWageOnb = dbo.GetRptDataMapCodeValue('WAGEONB_BASIC')) basicwage ON basicwage.FKeyWScaleRank = wsrank.PKey LEFT JOIN " & _
               "		(SELECT * FROM dbo.tblAdmWScaleInfo WHERE FKeyWageInfo = dbo.GetRptDataMapCodeValue('WAGEINFO_WORKHOURS')) workhours ON workhours.FKeyWScaleRank = wsrank.PKey LEFT JOIN " & _
               "		(SELECT * FROM dbo.tblAdmWScaleInfo WHERE FKeyWageInfo = dbo.GetRptDataMapCodeValue('WAGEINFO_LEAVEDAYS')) leavedays ON leavedays.FKeyWScaleRank = wsrank.PKey LEFT JOIN " & _
               "		(SELECT * FROM dbo.tblAdmWscaleOnb WHERE FKeyWageOnb = dbo.GetRptDataMapCodeValue('WAGEONB_LP')) leavepay ON leavepay.FKeyWScaleRank = wsrank.PKey LEFT JOIN " & _
               "		(SELECT * FROM dbo.tblAdmWScaleInfo WHERE FKeyWageInfo = dbo.GetRptDataMapCodeValue('WAGEINFO_OTHOURS')) othours ON othours.FKeyWScaleRank = wsrank.PKey LEFT JOIN " & _
               "		(SELECT * FROM dbo.tblAdmWScaleInfo WHERE FKeyWageInfo = dbo.GetRptDataMapCodeValue('WAGEINFO_OTRATE')) otrate ON otrate.FKeyWScaleRank = wsrank.PKey"

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
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
        BindData(MainReport.celWScale, "Text", Nothing, "WScaleName")
        BindData(MainReport.celAbbrv, "Text", Nothing, "WScaleAbbrv")
        BindData(MainReport.celCurrency, "Text", Nothing, "Curr")
        BindData(MainReport.celRateType, "Text", Nothing, "RateTypeDesc")
        BindData(MainReport.celDateInactive, "Text", Nothing, "DateInactive", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celContractPeriod, "Text", Nothing, "ContractPeriod")
        BindData(MainReport.celBasic, "Text", Nothing, "Basic", "{0:#,###.00}")
        BindData(MainReport.celWorkingHours, "Text", Nothing, "WorkingHours", "{0:#,##0.00}")
        BindData(MainReport.celLeaveDays, "Text", Nothing, "LeaveDays", "{0:#,##0.00}")
        BindData(MainReport.celLeavePay, "Text", Nothing, "LeavePay", "{0:#,##0.00}")
        BindData(MainReport.celOTHours, "Text", Nothing, "OTHours", "{0:#,##0.00}")
        BindData(MainReport.celOTRate, "Text", Nothing, "OTRate", "{0:#,##0.00}")
        BindData(MainReport.celOT, "Text", Nothing, "OT", "{0:#,##0.00}")
        BindData(MainReport.celTotalBasic, "Text", Nothing, "Basic")
        BindData(MainReport.celTotalLeavePay, "Text", Nothing, "LeavePay")
        BindData(MainReport.celTotalOT, "Text", Nothing, "OT")
        BindData(MainReport.celRemarks, "Text", Nothing, "Remarks")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_WScale, "WScaleName", REPORT_DETAIL.SortOption.GetSortValueCode("WScaleName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
