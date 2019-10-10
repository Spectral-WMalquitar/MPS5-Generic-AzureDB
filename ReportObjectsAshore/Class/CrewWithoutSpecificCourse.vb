Imports MPS4
Imports Utilities

Public Class CrewWithoutSpecificCourse

    Private MainReport As New rptCrewWithoutASpecificCourse
    
    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim cSQL_AllCrewAllCourse As String

        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))

        
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        Dim cFilter As String = ""
        cFilter = IIf(WhereList.Length > 0, "FKeyCourse IN " & WhereList, "")

        Select Case REPORT_DETAIL.FilterOption.GetFilterValue("Course Status")
            Case "Planned"
                cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & " CourseStatus = 1 "
            Case "Required"
                cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & " CourseStatus = 2 "
            Case "Completed"
                cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & " CourseStatus = 3 "
        End Select

        cSQL_AllCrewAllCourse = "" & _
                "SELECT         admcor.name AS coursename, " & _
                "               admcor.pkey as coursecode, " & _
                "               crew.* " & _
                "FROM		    dbo.Rpt_BioInfo AS crew, " & _
                "               dbo.tbladmcourse as admcor " & _
                "WHERE          admcor.pkey IN " & WhereList

        cSQL = "SELECT          q.* " & _
               "FROM            (" & cSQL_AllCrewAllCourse & ") q LEFT OUTER JOIN " & _
               "                dbo.Rpt_CrewTraining as cc ON q.idnbr = cc.idnbr AND q.coursecode = cc.fkeycourse " & _
               "WHERE           cc.pkey is null AND ActivityType = 'ASHORE' " & _
                                IIf(MainReportFilter.Length > 0, " AND " & MainReportFilter, "")

        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Bind Controls
        BindReportControls(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Add field(s) and sorting to Group Header/Detail 
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Course, "CourseName", REPORT_DETAIL.SortOption.GetSortValueCode("CourseName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
