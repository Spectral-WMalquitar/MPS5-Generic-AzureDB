Imports Utilities
Imports MPS4
Imports DevExpress.XtraReports.Parameters

Public Class clsCrewListAll_agent
    Private MainReport As New rptCrewListAll_agent

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        '--------------------------------------------------------------------------------------------------------------------------------------
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM Rpt_CrewListAll " '& sArc & " "

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
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        BindData(MainReport.celCrew, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "Abbrv")
        BindData(MainReport.celNationality, "Text", Nothing, "Nat")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateSON, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateSOFF, "Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celStatus, "Text", Nothing, "StatName")
        BindData(MainReport.celSOFFReason, "Text", Nothing, "SoffStat")
        BindData(MainReport.celVessel, "Text", Nothing, "VslName")
        BindData(MainReport.celPrincipal, "Text", Nothing, "PrinName")
        BindData(MainReport.celAgent, "Text", Nothing, "AgentName")
        BindData(MainReport.celRecStatus, "Text", Nothing, "recstatus")

        BindData(MainReport.celgrpagent, "Text", Nothing, "AgentName")


        AddFieldsToGroupHeaderBand(MainReport.grphead, "AgentName", FieldSortOrder.None)
        REPORT_DETAIL.MainReport = MainReport

    End Sub
End Class
