Imports MPS4
Imports Utilities
Imports Reports

Public Class PromCadetToOff
    Public MainReport As New rptPromCadetToOff

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        Dim dateCondition As String = ""
        Dim DateFrom As Object = Nothing, DateTo As Object = Nothing
        Dim excemptFilter As New List(Of String)
        If REPORT_DETAIL.AutoEmail.Enabled Then
            excemptFilter.Add("Promote Date From")
            excemptFilter.Add("Promote Date To")
            REPORT_DETAIL.RetrieveFilterDate("", "", DateFrom, DateTo)
            dateCondition = REPORT_DETAIL.ConstructCoverageCondition("(DateStart >= [FROM] AND DateStart <= [TO])", "[FROM]", "[TO]", DateFrom, DateTo)
        End If

        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"), excemptFilter)
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        'cSQL = "SELECT * FROM rpt_CrewHis_Prom "
        cSQL = "SELECT		crew.*, " & _
               "            ss.*, " & _
               "            rank.sortcode as RankSortCode, " & _
               "            ss_prev.PrevRank, " & _
               "            ss_prev.PrevRankCode," & _
               "            dept.Name as Dept, " & _
               "            dept.PKey as DeptCode " & _
               "FROM		(SELECT IDNbr, Crew, Nationality, Rank FROM dbo.Rpt_BioInfo) AS crew  LEFT OUTER JOIN  " & _
               "            dbo.rpt_CrewActAll ss ON crew.idnbr = ss.idnbr LEFT OUTER JOIN " & _
               "            (SELECT IDNbr, actid as PrevRankActID, FKeyRankCode as PrevRankCode, RankName as PrevRank FROM Rpt_CrewActAll)  ss_prev ON ss.promfrom = ss_prev.PrevRankActID LEFT OUTER JOIN " & _
               "            dbo.tbladmrank as rank ON ss.fkeyrankcode = rank.pkey LEFT OUTER JOIN " & _
               "            dbo.tbladmdept as dept ON rank.deptcode = dept.pkey LEFT OUTER JOIN " & _
               "            dbo.tbladmrank as prev_rank ON ss_prev.PrevRankCode = prev_rank.pkey LEFT OUTER JOIN " & _
               "            dbo.tbladmdept as prev_dept ON prev_rank.deptcode = prev_dept.pkey " & _
               "WHERE       (ss.promfrom Is Not null) " & _
               "			AND " & _
               "			rank.FKeyRankType = dbo.GetRptDataMapCodeValue('RANKOFFICERS') " & _
               "			AND " & _
               "			prev_rank.FKeyRankType = dbo.GetRptDataMapCodeValue('RANKRATINGS') "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " AND " & MainReportFilter & IIf(dateCondition.Length <> 0, " AND " & dateCondition, "") & " "
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

        BindData(MainReport.celRankName, "Text", Nothing, "RankName")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celPrevRank, "Text", Nothing, "PrevRank")
        BindData(MainReport.celDept, "Text", Nothing, "Dept")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celAgent, "Text", Nothing, "AgentName")
        BindData(MainReport.celDateProm, "Text", Nothing, "DateStart", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateSOn, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateSOff, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celRankTotal, "Text", Nothing, "RankName")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "RankSortCode", REPORT_DETAIL.SortOption.GetSortValueCode("RankSortCode"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
