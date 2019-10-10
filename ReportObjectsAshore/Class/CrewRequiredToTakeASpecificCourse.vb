Imports MPS4
Imports Utilities

Public Class CrewRequiredToTakeASpecificCourse

    Private MainReport As New rptCrewRequiredToTakeASpecificCourse
    
    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String

        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        Dim cFilter As String = ""
        cFilter = IIf(WhereList.Length > 0, "FKeyCourse IN " & WhereList, "")

        cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & " CourseStatus = 2 "


        cSQL = "SELECT          crew.*, doc.* " & _
               "FROM            dbo.Rpt_BioInfo as crew INNER JOIN" & _
               "                (SELECT * FROM dbo.Rpt_CrewTraining " & IIf(cFilter.Length > 0, "WHERE " & cFilter, "") & ") doc ON crew.idnbr = doc.idnbr " & _
                                IIf(MainReportFilter.Length > 0, " AND " & MainReportFilter, "") & _
                                " WHERE ActivityType = 'ASHORE'"

        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt

        MainReport.txtDateIssue.DataBindings.Add("Text", Nothing, "PlannedStart", "{0:dd-MMM-yyyy}")

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
