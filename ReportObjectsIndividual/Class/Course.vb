Imports MPS4
Imports Utilities

Public Class Course

    Private MainReport As New rptCourse

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        Dim FilterCourseStat As String = ""
        Dim nFilterCourseStat As Integer

        nFilterCourseStat = CInt(IIf(IsDBNull(REPORT_DETAIL.FilterOption.GetFilterValue("Course Status")) Or REPORT_DETAIL.FilterOption.GetFilterValue("Course Status").ToString.Length = 0, 0, REPORT_DETAIL.FilterOption.GetFilterValue("Course Status")))
        If nFilterCourseStat <> 0 Then
            FilterCourseStat = "WHERE CourseStatus = " & nFilterCourseStat & " "
        End If
        cSQL = "SELECT		    crew.*, doc.* " & _
               "FROM		    dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "                (SELECT         [PKey], [IDNbr] as IDNbrSub, [FKeyCourse], [CourseName], [FKeyCourseInst], [CourseInstName], [CourseInstAbbrv], [FKeyCntry], [Country], [CourseCertNo], [STCWRef], [DateIssue], [DateExpiry], [CourseStatus], [CourseTypeCode], CASE WHEN CourseStatus = 1 THEN 'Planned' ELSE CASE WHEN CourseStatus = 2 THEN 'Required' ELSE CASE WHEN CourseStatus = 3 THEN 'Completed' ELSE '' END END END AS CourseStatusValue " & _
               "                 FROM           MPS.dbo.Rpt_CrewTraining" & sArc & " " & FilterCourseStat & ") AS doc ON crew.IDNbr = doc.IDNbrSub " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")

        Dim dt As DataTable

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        With MainReport
            .DataSource = dt

            .subHeader.ReportSource = New Reports.rptHeader(MainReport)

            .txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
            .txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")
        End With
        
        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
