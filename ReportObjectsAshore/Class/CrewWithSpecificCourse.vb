Imports MPS4
Imports Utilities

Public Class CrewWithSpecificCourse

    Private MainReport As New rptCrewWithSpecificCourse
    
    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
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

        cSQL = "SELECT          crew.*, doc.*,CASE WHEN DateSOff IS NULL THEN StatName ELSE SOffStat END AS Status " & _
               "FROM            dbo.Rpt_BioInfo as crew INNER JOIN" & _
               "                (SELECT * FROM dbo.Rpt_CrewTraining " & IIf(cFilter.Length > 0, "WHERE " & cFilter, "") & ") doc ON crew.idnbr = doc.idnbr " & _
                                " WHERE ActivityType = 'ASHORE'" & _
                                IIf(MainReportFilter.Length > 0, " AND " & MainReportFilter, "")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Note: Sorting should be applied from the report bands, not on source

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        MainReport.txtDateIssue.DataBindings.Add("Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        MainReport.txtDateExpiry.DataBindings.Add("Text", Nothing, "DateExpiry", "{0:dd-MMM-yyyy}")

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
