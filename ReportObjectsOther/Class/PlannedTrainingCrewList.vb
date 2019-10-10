Public Class PlannedTrainingCrewList

    Private MainReport As New rptPlannedTrainingCrewList

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT * FROM dbo.Rpt_PlannedCourse " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        With MainReport
            .DataSource = dt
            AddFieldsToGroupHeaderBand(.GroupHeader_Course, "CourseName", REPORT_DETAIL.SortOption.GetSortValueCode("CourseName"))
            AddSortFieldsToDetailBandFromDT(.Detail, REPORT_DETAIL.SortOption.SortDataSource)
            .txtDateStart.DataBindings.Add("Text", Nothing, "PlannedStart", "{0:dd-MMM-yyyy}")
            BindData(MainReport.celTotalOnb, "Text", Nothing, "Crew")

            .subHeader.ReportSource = New Reports.rptHeader(MainReport)

            BindReportControls(MainReport)
            .Name = REPORT_DETAIL.ReportObjectID
            SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)
            '---------------------------------------------------------------------------------------------------------------------------------------
            REPORT_DETAIL.MainReport = MainReport

        End With



    End Sub
End Class
