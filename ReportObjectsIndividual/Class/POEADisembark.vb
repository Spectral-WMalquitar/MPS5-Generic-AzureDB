Imports Utilities
Imports MPS4

Public Class POEADisembark

    Public MainReport As New rptPOEADisembark

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
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim AgentCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Agent", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        'cSQL = "SELECT * FROM rpt_POEADisembark where FKeyVsl in " & WhereList
        cSQL = "SELECT * FROM rpt_POEADisembark "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        If period.Length > 0 Then
            cSQL = cSQL & " and Period = " & period & " "
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

        BindData(MainReport.txtAgent, "Text", Nothing, "Agent")
        BindData(MainReport.txtFullName, "Text", Nothing, "Crew")
        BindData(MainReport.txtPosition, "Text", Nothing, "RankName")
        BindData(MainReport.txtBasic, "Text", Nothing, "Basic")
        BindData(MainReport.txtAgentContractPart, "Text", Nothing, "Owner")
        BindData(MainReport.txtVessel, "Text", Nothing, "Vsl")
        BindData(MainReport.txtRegistry, "Text", Nothing, "PortofReg")
        BindData(MainReport.txtPeriod, "Text", Nothing, "DateSOn", "{0:MMMM-yyyy}")

        AddFieldsToGroupHeaderBand(MainReport.GrpHeaderPrin, "Prin", FieldSortOrder.Ascending)

        MainReport.txtCertifiedCorrectBy.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper
        MainReport.txtCertifiedCorrectPosition.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
