
Public Class CrewWageAcct
    Public MainReport As New rptCrewWageAcct
    Public SubReport_Earn As New rptCrewWageAcct_Earn
    Public SubReport_Deduct As New rptCrewWageAcct_Deduct
    Public SubReport_Bal As New rptCrewWageAcct_Bal

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String

        Dim MainReportFilter As String = ""
        Dim Period As Integer = 0
        Dim Period_End As Integer = 0
        Dim FKeyPrin As String = ""
        Dim FKeyVslCode As String = ""
        Dim RefNo As String = ""

        If REPORT_DETAIL.ReportObjectID = "rptCrewWageAcct_Crew" Then
            If (REPORT_DETAIL.FilterOption.GetFilterValue("Period From").ToString.Length = 0 Or _
                REPORT_DETAIL.FilterOption.GetFilterValue("Period To").ToString.Length = 0) Then
                MsgBox("Please select Period range to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
                Exit Sub
            End If
            Period = REPORT_DETAIL.FilterOption.GetFilterValue("Period From")
            Period_End = REPORT_DETAIL.FilterOption.GetFilterValue("Period To")

        ElseIf REPORT_DETAIL.ReportObjectID = "rptCrewWageAcct_Vsl" Then
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

        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE        
        cSQL = "SELECT * FROM Rpt_CrewWageAcct "

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

        With MainReport
            .DataSource = dt

            .celCompany.Text = MPS4.MPSDB.GetConfig("Name").ToUpper

            BindData(.celVslName, "Text", Nothing, "VslName")
            BindData(.celCrewName, "Text", Nothing, "Crew")
            BindData(.celCrewName2, "Text", Nothing, "Crew")
            BindData(.celRankName, "Text", Nothing, "RankName")
            BindData(.celFromDate, "Text", Nothing, "PeriodStart", "{0:dd-MMM-yyyy}")
            BindData(.celToDate, "Text", Nothing, "PeriodEnd", "{0:dd-MMM-yyyy}")
            BindData(.celDays, "Text", Nothing, "Days")
            BindData(.celNetAmt, "Text", Nothing, "NetAmt")
            BindData(.celPrevBal, "Text", Nothing, "PrevBal")
            BindData(.celFwrdBal, "Text", Nothing, "FwrdBal")

            .rptCrewWageAcct_Earn.ReportSource = SubReport_Earn
            .rptCrewWageAcct_Deduct.ReportSource = SubReport_Deduct
            .rptCrewWageAcct_Bal.ReportSource = SubReport_Bal

            AddHandler .Detail.BeforePrint, AddressOf HandleBeforePrint
        End With

        With SubReport_Earn
            BindData(.celEarnItem, "Text", Nothing, "Item")
            BindData(.celEarnAmt, "Text", Nothing, "Amt")
            BindData(.celEarnTotal, "Text", Nothing, "Amt")
        End With

        With SubReport_Deduct
            BindData(.celDedItem, "Text", Nothing, "Item")
            BindData(.celDedAmt, "Text", Nothing, "Amt")
            BindData(.celDedTotal, "Text", Nothing, "Amt")
        End With

        With SubReport_Bal
            BindData(.celItem, "Text", Nothing, "Item")
            BindData(.celPeriod, "Text", Nothing, "Days")
            BindData(.celPrevBal, "Text", Nothing, "PrevBal")
            BindData(.celEarned, "Text", Nothing, "Amt")
            BindData(.celFwrdBal, "Text", Nothing, "FwrdBal")
        End With

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub

    Private Sub HandleBeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim dt As New DataTable
        Dim PKey As String = MainReport.GetCurrentColumnValue("PKey")

        dt = MPSDB.CreateTable("SELECT * FROM Rpt_CrewWageAcct_Items WHERE WageType=1 AND Accum=0 AND FKey='" & PKey & "'")
        SubReport_Earn.DataSource = dt

        dt = MPSDB.CreateTable("SELECT * FROM Rpt_CrewWageAcct_Items WHERE WageType=2 AND Accum=0 AND FKey='" & PKey & "'")
        SubReport_Deduct.DataSource = dt

        dt = MPSDB.CreateTable("SELECT * FROM Rpt_CrewWageAcct_Items WHERE Accum=1 AND FKey='" & PKey & "'")
        SubReport_Bal.DataSource = dt
    End Sub

End Class
