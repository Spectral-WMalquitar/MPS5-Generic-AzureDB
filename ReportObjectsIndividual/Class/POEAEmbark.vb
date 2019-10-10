﻿Imports Utilities
Imports MPS4

Public Class POEAEmbark
    Public MainReport As New rptPOEAEmbark

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        Dim period As String = REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString

        If period.Length = 0 Then
            MsgBox("Please select Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
            Exit Sub
        End If

        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = "Agent, DateSOn, Crew" 'REPORT_DETAIL.FieldSorting
        Dim AgentCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Agent", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        'cSQL = "SELECT * FROM rpt_POEAEmbark where FKeyVsl in " & WhereList
        cSQL = "SELECT * FROM rpt_POEAEmbark "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        If period.Length > 0 Then
            cSQL = cSQL & " and Period = '" & period & "' "
        End If

        If AgentCode.Length > 0 Then
            cSQL = cSQL & " and FKeyAgent = '" & AgentCode & "' "
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

        BindData(MainReport.txtPeriod, "Text", Nothing, "DateSOn", "{0:MMMM-yyyy}")
        BindData(MainReport.txtAgent, "Text", Nothing, "Agent")
        BindData(MainReport.celNameSeaman, "Text", Nothing, "Crew")
        BindData(MainReport.celPosition, "Text", Nothing, "RankName")
        BindData(MainReport.celOECno, "Text", Nothing, "OECNbr")
        BindData(MainReport.txtHireStatCode, "Text", Nothing, "HireStatCode")
        BindData(MainReport.celVessel, "Text", Nothing, "Vsl")
        BindData(MainReport.celDateDepart, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        'BindData(MainReport.celTotalNoSeamanDeployed, "Text", Nothing, "00000")
        BindData(MainReport.celOfficers, "Text", Nothing, "OffCnt")
        BindData(MainReport.celOfficersEngge, "Text", Nothing, "OffECnt")
        BindData(MainReport.celOfficersReEngge, "Text", Nothing, "OffRCnt")
        BindData(MainReport.celRatings, "Text", Nothing, "RatCnt")
        BindData(MainReport.celRatingsEngge, "Text", Nothing, "RatECnt")
        BindData(MainReport.celRatingsReEngge, "Text", Nothing, "RatRCnt")
        BindData(MainReport.celRepairSquad, "Text", Nothing, "RepCnt")
        BindData(MainReport.celRepairSquadEngge, "Text", Nothing, "RepECnt")
        BindData(MainReport.celRepairSquadReEngge, "Text", Nothing, "RepRCnt")

        BindData(MainReport.txtTotalCrew, "Text", Nothing, "Crew")

        AddFieldsToGroupHeaderBand(MainReport.GrpHeaderAgent, "Agent", FieldSortOrder.Ascending)

        MainReport.txtCertifiedCorrectBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper
        MainReport.txtCertifiedCorrectPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
