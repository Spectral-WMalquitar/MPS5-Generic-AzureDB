Imports MPS4
Imports Utilities
Imports Reports

Public Class CrewHis_SeaServ
    Public MainReport As New rptCrewHis_SeaServ

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        Dim dt As DataTable
        Dim cSQL As String
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        Dim DateToSort As String
        Dim ServFilter As String

        If REPORT_DETAIL.ReportObjectID.ToUpper = "rptCrewHis_SeaServ_Dep".ToUpper Then
            DateToSort = "DateDep"
            MainReport.lblTitle.Text = "DEPARTURE CREW LIST"
            ServFilter = " rpt_CrewHis_SeaServ.rn = (SELECT MAX(rn) FROM Crewlist_Activities_All AS actall WHERE (ActGrpID = rpt_CrewHis_SeaServ.ActGrpID)) "
        Else
            DateToSort = "DateArr"
            MainReport.lblTitle.Text = "ARRIVAL CREW LIST"
            ServFilter = " rpt_CrewHis_SeaServ.rn = (SELECT MIN(rn) FROM Crewlist_Activities_All AS actall WHERE (ActGrpID = rpt_CrewHis_SeaServ.ActGrpID)) AND DateArr IS NOT NULL "
        End If


        cSQL = "SELECT *, " & DateToSort & " DateSort, SUBSTRING(CONVERT(varchar," & DateToSort & ",112),1,6) YYYYMM, DATENAME(MONTH," & DateToSort & ") MMM, DATENAME(YEAR," & DateToSort & ") YYYY, DATENAME(DAY," & DateToSort & ") DD  FROM rpt_CrewHis_SeaServ "

        Dim dateCondition As String = ""
        Dim DateFrom As Object = Nothing, DateTo As Object = Nothing
        Dim excemptFilter As New List(Of String)
        If REPORT_DETAIL.AutoEmail.Enabled Then
            excemptFilter.Add(IIf(DateToSort = "DateDep", "Date Depart From", "Date Arrive From"))
            excemptFilter.Add(IIf(DateToSort = "DateDep", "Date Depart To", "Date Arrive To"))
            REPORT_DETAIL.RetrieveFilterDate("", "", DateFrom, DateTo)
            dateCondition = REPORT_DETAIL.ConstructCoverageCondition("(" & DateToSort & " >= [FROM] AND " & DateToSort & " <= [TO])", "[FROM]", "[TO]", DateFrom, DateTo)
        End If

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"), excemptFilter)

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " AND " & ServFilter & IIf(dateCondition.Length <> 0, " AND " & dateCondition, "") & " "
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
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celStatus, "Text", Nothing, "Status")
        BindData(MainReport.celMonth, "Text", Nothing, "MMM")
        BindData(MainReport.celYear, "Text", Nothing, "YYYY")
        BindData(MainReport.celDay, "Text", Nothing, "DD")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "YYYYMM", REPORT_DETAIL.SortOption.GetSortValueCode("DateSort"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
