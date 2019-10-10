Imports Utilities
Imports MPS4

Public Class MedHis
    Public MainReport As New rptMedHis

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM RptSel_CrewList" & sArc & " "

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

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        If REPORT_DETAIL.ReportObjectID = "rptMedHis" Then
            MainReport.lblHeader.Text = "MEDICAL HISTORY"
        ElseIf REPORT_DETAIL.ReportObjectID = "rptMedStat" Then
            MainReport.lblHeader.Text = "MEDICAL STATUS"
        ElseIf REPORT_DETAIL.ReportObjectID = "rptMedCost" Then
            MainReport.lblHeader.Text = "MEDICAL COST"
        Else
            MainReport.lblHeader.Text = ""
        End If

        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        BindData(MainReport.celCrew, "Text", Nothing, "Crew")
        BindData(MainReport.celRankName, "Text", Nothing, "Rank")

        BindData(MainReport.celDateAcq, "Text", Nothing, "DateAcq", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celWorkRel, "Text", Nothing, "IsWorkRel")
        BindData(MainReport.celDiag, "Text", Nothing, "Diagnosis")
        BindData(MainReport.celPlaceAcq, "Text", Nothing, "PlaceAcq")
        BindData(MainReport.celPICase, "Text", Nothing, "PICase")
        BindData(MainReport.celRefNo, "Text", Nothing, "RefNo")
        BindData(MainReport.celStat, "Text", Nothing, "Status")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celRemarksHis, "Text", Nothing, "Remarks")

        BindData(MainReport.celDateStat, "Text", Nothing, "DateEntry", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celMedStat, "Text", Nothing, "Status")
        BindData(MainReport.celRemarksStat, "Text", Nothing, "Remarks")

        BindData(MainReport.celDateCost, "Text", Nothing, "DateEntry", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celItem, "Text", Nothing, "Item")
        BindData(MainReport.celAmount, "Text", Nothing, "Cost")
        BindData(MainReport.celPlace, "Text", Nothing, "Place")
        BindData(MainReport.celChargeType, "Text", Nothing, "Charge")
        BindData(MainReport.celRemarksCost, "Text", Nothing, "Remarks")

        MainReport.Detail_MedHis.SortFields.Add(New GroupField("DateAcq", XRColumnSortOrder.Descending))
        MainReport.Detail_MedStat.SortFields.Add(New GroupField("DateEntry", XRColumnSortOrder.Descending))
        MainReport.Detail_MedCost.SortFields.Add(New GroupField("DateEntry", XRColumnSortOrder.Descending))

        Dim subFilter As String = ""
        Dim dFrom As String = REPORT_DETAIL.FilterOption.GetFilterValue("From").ToString
        Dim dTo As String = REPORT_DETAIL.FilterOption.GetFilterValue("To").ToString

        If dFrom.Length <> 0 And dTo.Length = 0 Then
            subFilter = subFilter & " WHERE DateAcq >= '" & dFrom & "'"
        ElseIf dFrom.Length = 0 And dTo.Length <> 0 Then
            subFilter = subFilter & " WHERE DateAcq <= '" & dTo & "'"
        ElseIf dFrom.Length <> 0 And dTo.Length <> 0 Then
            subFilter = subFilter & " WHERE DateAcq >= '" & dFrom & "'" & " AND DateAcq <= '" & dTo & "'"
        End If

        LoadDetailReport(MainReport.DetailReport_MedHis, "SELECT * FROM Rpt_MedHis" & sArc & " " & subFilter)
        LoadDetailReport(MainReport.DetailReport_MedStat, "SELECT * FROM Rpt_MedStat" & sArc & " ")
        LoadDetailReport(MainReport.DetailReport_MedCost, "SELECT * FROM Rpt_MedCost" & sArc & " ")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "RefNo", FieldSortOrder.None)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail_Crew, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub SetDetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim drb As New DevExpress.XtraReports.UI.DetailReportBand
        drb = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)

        Select Case drb.Name
            Case MainReport.DetailReport_MedHis.Name
                drb.FilterString = "FKeyIDNbr='" & MainReport.GetCurrentColumnValue("IDNbr").ToString & "'"
            Case Else
                Try
                    drb.FilterString = "FKeyMedHistory='" & MainReport.DetailReport_MedHis.GetCurrentColumnValue("PKey").ToString & "'"
                Catch ex As Exception
                    drb.FilterString = "FKeyMedHistory=''"
                End Try
        End Select

        MainReport.DetailReport_MedHis.Visible = (MainReport.DetailReport_MedHis.RowCount <> 0)

        If MainReport.Name = "rptMedStat" Then
            MainReport.DetailReport_MedCost.Visible = False
        ElseIf MainReport.Name = "rptMedCost" Then
            MainReport.DetailReport_MedStat.Visible = False
        Else
            drb.Visible = (drb.RowCount <> 0)
        End If
    End Sub

    Private Sub LoadDetailReport(sender As System.Object, sql As String)
        Dim detailReport As DetailReportBand
        Dim dt_sub As DataTable
        dt_sub = MPSDB.CreateTable(sql)
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.DataSource = dt_sub
        AddHandler detailReport.BeforePrint, AddressOf SetDetailReport_BeforePrint
    End Sub

End Class
