
Public Class SenOfcPlan
    Public MainReport As New rptSenOfcPlan

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "EXEC dbo.GetSenOfcPlan '" + WhereList.Replace("'", "''") + "','" + MainReportFilter.Replace("'", "''") + "'"

        dt = MPSDB.CreateTable(cSQL)
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        AddHandler MainReport.Detail.BeforePrint, AddressOf Detail_BeforePrint

        BindData(MainReport.celVslName, "Text", Nothing, "VslName")

        If REPORT_DETAIL.ReportObjectID.ToUpper = "RptSenOfcPlan_Prin".ToUpper Then
            BindData(MainReport.celGrp, "Text", Nothing, "PrinName")
        Else
            BindData(MainReport.celGrp, "Text", Nothing, "Flt")
        End If

        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        BindData(MainReport.celMSTR, "Text", Nothing, "Onb_MSTR")
        BindData(MainReport.celCO, "Text", Nothing, "Onb_CO")
        BindData(MainReport.celCE, "Text", Nothing, "Onb_CE")
        BindData(MainReport.cel2E, "Text", Nothing, "Onb_2E")
        BindData(MainReport.celETOEL, "Text", Nothing, "Onb_ETOEL")

        BindData(MainReport.celMSTR_plan, "Text", Nothing, "Plan_MSTR")
        BindData(MainReport.celCO_plan, "Text", Nothing, "Plan_CO")
        BindData(MainReport.celCE_plan, "Text", Nothing, "Plan_CE")
        BindData(MainReport.cel2E_plan, "Text", Nothing, "Plan_2E")
        BindData(MainReport.celETOEL_plan, "Text", Nothing, "Plan_ETOEL")

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub Detail_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        If Len(MainReport.GetCurrentColumnValue("Plan_MSTR").ToString) = 0 _
            And Len(MainReport.GetCurrentColumnValue("Plan_CO").ToString) = 0 _
            And Len(MainReport.GetCurrentColumnValue("Plan_CE").ToString) = 0 _
            And Len(MainReport.GetCurrentColumnValue("Plan_2E").ToString) = 0 _
            And Len(MainReport.GetCurrentColumnValue("Plan_ETOEL").ToString) = 0 Then
            MainReport.celMSTR_det.Text = ""
            MainReport.celCO_det.Text = ""
            MainReport.celCE_det.Text = ""
            MainReport.cel2E_det.Text = ""
            MainReport.celETOEL_det.Text = ""
            'MainReport.rowDet.Visible = False
            'MainReport.rowPlan.Visible = False
        Else
            MainReport.celMSTR_det.Text = IIf(Len(MainReport.GetCurrentColumnValue("Plan_MSTR").ToString) = 0, "", "to be relieved by")
            MainReport.celCO_det.Text = IIf(Len(MainReport.GetCurrentColumnValue("Plan_CO").ToString) = 0, "", "to be relieved by")
            MainReport.celCE_det.Text = IIf(Len(MainReport.GetCurrentColumnValue("Plan_CE").ToString) = 0, "", "to be relieved by")
            MainReport.cel2E_det.Text = IIf(Len(MainReport.GetCurrentColumnValue("Plan_2E").ToString) = 0, "", "to be relieved by")
            MainReport.celETOEL_det.Text = IIf(Len(MainReport.GetCurrentColumnValue("Plan_ETOEL").ToString) = 0, "", "to be relieved by")
        End If
    End Sub

End Class
