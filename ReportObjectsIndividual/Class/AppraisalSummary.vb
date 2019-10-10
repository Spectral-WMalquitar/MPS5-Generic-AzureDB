Imports Utilities
Imports MPS4

Public Class AppraisalSummary
    Public MainReport As New rptAppraisalSummary


    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        Dim dt As DataTable
        Dim cSQL As String
        'Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, , , ))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim AgentCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Agent", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper()

        cSQL = "SELECT * FROM Rpt_AppraisalIndi "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        'If period.Length > 0 Then
        '    cSQL = cSQL & " and Period = '" & period & "' "
        'End If

        'If AgentCode.Length > 0 Then
        '    cSQL = cSQL & " and FKeyAgent = '" & AgentCode & "' "
        'End If

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


        With MainReport
            .celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

            .txtPrincipal.Text = Trim(MPSDB.GetConfig("Name"))
            .txtPrinAdd.Text = Trim(MPSDB.GetConfig("ADDR"))

            BindData(.celCrew, "Text", Nothing, "Crew")
            BindData(.celRank, "Text", Nothing, "RankName")
            BindData(.celNationality, "Text", Nothing, "NatName")
            BindData(.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")

            BindData(.celAppraisalDate, "Text", Nothing, "AppraisalDate")
            BindData(.celService, "Text", Nothing, "Service")
            BindData(.celOccForReport, "Text", Nothing, "OccasionForReport")
            BindData(.celOverallAsses, "Text", Nothing, "OverallAssessment")
            BindData(.celOverallScore, "Text", Nothing, "OverallScore")
            BindData(.celOverallScoreAverage, "Text", Nothing, "OverallScore")

            AddFieldsToGroupHeaderBand(.grpCrew, "Crew", FieldSortOrder.Ascending)
        End With

        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
