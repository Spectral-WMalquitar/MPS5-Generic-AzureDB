Public Class CrewAsh_AllCrew_Rem
    Public MainReport As New rptCrewAsh_AllCrew_Rem
    Dim dt As DataTable

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM rpt_CrewAsh_AllCrew_Rem "

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

        AddHandler MainReport.DetailReport.BeforePrint, AddressOf DetailReport_BeforePrint
        AddHandler MainReport.GroupFooter2.BeforePrint, AddressOf GroupFooter_BeforePrint
        MainReport.DetailReport.DataMember = "Crew"
        MainReport.Detail1.SortFields.Add(New GroupField("ComDate", XRColumnSortOrder.Descending))

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindData(MainReport.lblRank, "Text", Nothing, "RankName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celStatus, "Text", Nothing, "StatName")
        BindData(MainReport.celDateSOFF, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celFormerVsl, "Text", Nothing, "VslName")
        BindData(MainReport.celLeaveExp, "Text", Nothing, "LeaveExp", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celPlanJoinDate, "Text", Nothing, "PlanJoinDate", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celCommDate, "Text", Nothing, "ComDate", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celCommBy, "Text", Nothing, "ComBy")
        BindData(MainReport.celComment, "Text", Nothing, "Comment")
        BindData(MainReport.celRankBot, "Text", Nothing, "RankName")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader2, "RankSortCode", REPORT_DETAIL.SortOption.GetSortValueCode("RankSortCode"))
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub DetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        If IsDBNull(MainReport.GetCurrentColumnValue("ComDate")) Then
            MainReport.DetailReport.Visible = False
        Else
            MainReport.DetailReport.Visible = True
        End If
    End Sub

    Private Sub GroupFooter_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        MainReport.celRankCnt.Text = dt.Select("RankName='" & MainReport.lblRank.Text & "'").CopyToDataTable.DefaultView.ToTable(True, "Crew").Rows.Count
    End Sub
End Class
