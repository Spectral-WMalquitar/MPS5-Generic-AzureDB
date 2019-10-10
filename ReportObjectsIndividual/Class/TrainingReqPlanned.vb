Imports MPS4
Imports Utilities

Public Class TrainingReqPlanned

    Private MainReport As New XtraReport
    Private rptTrainingRequired As New rptTrainingRequired
    Private rptTrainingPlanned As New rptTrainingPlanned

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        Dim sArc As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "_Arc", "")
        Dim sPrefix As String = IIf(SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "")

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        Dim FilterCourseStat As String = ""

        Select Case REPORT_DETAIL.ReportObjectID
            Case "rptTrainingPlanned"
                FilterCourseStat = "WHERE CourseStatus = dbo.getRptDataMapCodeValue('COURSEPLANNED') "
            Case "rptTrainingRequired"
                FilterCourseStat = "WHERE CourseStatus = dbo.getRptDataMapCodeValue('COURSEREQ') "
            Case Else
                Exit Sub
        End Select
        cSQL = "SELECT		    crew.*, " & _
               "                crew_pp.number as pp_number, " & _
               "                crew_sbk.number as sbk_number, " & _
               "                doc.* " & _
               "FROM		    dbo.Rpt_BioInfo" & sArc & " AS crew LEFT OUTER JOIN " & _
               "                (SELECT         c.[PKey], [IDNbr] as IDNbrSub, [FKeyCourse], [CourseName], [FKeyCourseInst], [CourseInstName], [CourseInstAbbrv], [FKeyCntry], [Country], [CourseCertNo], [STCWRef], [DateIssue], [DateExpiry], [CourseStatus], [CourseTypeCode], CASE WHEN CourseStatus = 1 THEN 'Planned' ELSE CASE WHEN CourseStatus = 2 THEN 'Required' ELSE CASE WHEN CourseStatus = 3 THEN 'Completed' ELSE '' END END END AS CourseStatusValue, ctype.name as CourseTypeValue, PlannedStart  " & _
               "                 FROM           MPS.dbo.Rpt_CrewTraining" & sArc & " c LEFT OUTER JOIN " & _
               "                 [MPS].[dbo].[tbladmcoursetype] ctype ON c.CourseTypeCode = ctype.pkey " & _
                                FilterCourseStat & _
               "                ) AS doc ON crew.IDNbr = doc.IDNbrSub LEFT OUTER JOIN " & _
               "                Rpt_CrewPassport" & sArc & " as crew_pp ON crew.idnbr = crew_pp.fkeyidnbr LEFT OUTER JOIN " & _
               "                Rpt_CrewSBK" & sArc & " as crew_sbk ON crew.idnbr = crew_sbk.fkeyidnbr " & _
               IIf(MainReportFilter.Length > 0, " WHERE " & MainReportFilter & " ", "")

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        If REPORT_DETAIL.ReportObjectID = "rptTrainingPlanned" Then
            With rptTrainingPlanned
                .DataSource = dt
                AddFieldsToGroupHeaderBand(.GroupHeader_IDNbr, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
                AddSortFieldsToDetailBandFromDT(.Detail, REPORT_DETAIL.SortOption.SortDataSource)
                .txtDateStart.DataBindings.Add("Text", Nothing, "PlannedStart", "{0:dd-MMM-yyyy}")
                .txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
                .txtDateApplied.DataBindings.Add("Text", Nothing, "DateApplied", "{0:dd-MMM-yyyy}")

                .subHeader.ReportSource = New Reports.rptHeader(MainReport)

                BindReportControls(rptTrainingPlanned)
                .Name = REPORT_DETAIL.ReportObjectID
                SetDefaultReportLabels(rptTrainingPlanned, REPORT_DETAIL.DB)
                '---------------------------------------------------------------------------------------------------------------------------------------
                REPORT_DETAIL.MainReport = rptTrainingPlanned
            End With

        ElseIf REPORT_DETAIL.ReportObjectID = "rptTrainingRequired" Then
            With rptTrainingRequired
                .DataSource = dt
                AddFieldsToGroupHeaderBand(.GroupHeader_IDNbr, "Crew", REPORT_DETAIL.SortOption.GetSortValueCode("Crew"))
                AddSortFieldsToDetailBandFromDT(.Detail, REPORT_DETAIL.SortOption.SortDataSource)
                .txtDateStart.DataBindings.Add("Text", Nothing, "PlannedStart", "{0:dd-MMM-yyyy}")
                .txtDOB.DataBindings.Add("Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
                .txtDateApplied.DataBindings.Add("Text", Nothing, "DateApplied", "{0:dd-MMM-yyyy}")

                .subHeader.ReportSource = New Reports.rptHeader(MainReport)

                BindReportControls(rptTrainingRequired)
                .Name = REPORT_DETAIL.ReportObjectID
                SetDefaultReportLabels(rptTrainingRequired, REPORT_DETAIL.DB)
                '---------------------------------------------------------------------------------------------------------------------------------------
                REPORT_DETAIL.MainReport = rptTrainingRequired
            End With

        End If

        

    End Sub
End Class
