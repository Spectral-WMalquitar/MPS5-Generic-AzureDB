Public Class AdminStatus
    Public MainReport As New rptAdminStatus

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter()
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM Rpt_AdminStatus"

        '---------------------------------------------------------------------------------------------------------------------------------------
        'ARRANGE CONDITION
        Dim cCondition As String = ""
        If MainReportFilter.Length > 0 Then
            cCondition = cCondition & IIf(IfNull(cCondition, "").Equals(""), "", " AND ") & MainReportFilter & " "
        End If

        'Status Type
        If Not IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Status Type"), "").Equals("") Then
            cCondition = cCondition & IIf(IfNull(cCondition, "").Equals(""), "", " AND ") & "StatType = " & REPORT_DETAIL.FilterOption.GetFilterValue("Status Type") & " "
        End If

        'System Status
        Dim isSystemStatus = REPORT_DETAIL.FilterOption.GetFilterValue("System Status")
        If Not IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("System Status"), "").Equals("") Then
            If isSystemStatus = 1 Then
                cCondition = cCondition & IIf(IfNull(cCondition, "").Equals(""), "", " AND ") & "isSysRecord = 1 "
            ElseIf isSystemStatus = 2 Then
                cCondition = cCondition & IIf(IfNull(cCondition, "").Equals(""), "", " AND ") & "isSysRecord = 0 "
            End If
        End If

        If cCondition.Length > 0 Then
            cSQL = cSQL & " WHERE " & cCondition & " "
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------

        'BUILD DATA
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.celCompanyName.Text = REPORT_DETAIL.DB.GetConfig("Name")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        BindData(MainReport.celType, "Text", Nothing, "StatusType")
        BindData(MainReport.celSortCode, "Text", Nothing, "SortCode")
        BindData(MainReport.celStatusName, "Text", Nothing, "Name")
        BindData(MainReport.celSystemStatus, "Text", Nothing, "isSystemStatus")
        BindData(MainReport.celStatusTotal, "Text", Nothing, "Name")

        'AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "CourseType", REPORT_DETAIL.SortOption.GetSortValueCode("CourseType"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
