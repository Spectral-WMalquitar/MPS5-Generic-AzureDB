﻿Imports MPS4
Imports Utilities

Public Class CrewWithoutSpecificMedical

    Private MainReport As New rptCrewWithoutASpecificMedical

    Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
        Dim cSQL As String
        'Dim cSQL_AllCrewAllMedical As String

        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))

        Dim strDocExpDays As String = GetUserSetting("DocExpDays")

        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        'Dim cFilter As String = ""
        'cFilter = IIf(WhereList.Length > 0, "FKeyMedical IN " & WhereList, "")

        'Select Case REPORT_DETAIL.FilterOption.GetFilterValue("Medical Status")
        '    Case "Planned"
        '        cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & " MedicalStatus = 1 "
        '    Case "Required"
        '        cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & " MedicalStatus = 2 "
        '    Case "Completed"
        '        cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & " MedicalStatus = 3 "
        'End Select

        'cSQL_AllCrewAllMedical = "" & _
        '        "SELECT         admcor.name AS Medicalname, " & _
        '        "               admcor.pkey as Medicalcode, " & _
        '        "               crew.* " & _
        '        "FROM		    dbo.Rpt_BioInfo AS crew, " & _
        '        "               dbo.tbladmMedical as admcor " & _
        '        "WHERE          admcor.pkey IN " & WhereList

        'cSQL = "SELECT          q.* " & _
        '       "FROM            (" & cSQL_AllCrewAllMedical & ") q LEFT OUTER JOIN " & _
        '       "                dbo.Rpt_CrewTraining as cc ON q.idnbr = cc.idnbr AND q.Medicalcode = cc.fkeyMedical " & _
        '       "WHERE           cc.pkey is null AND ActivityType = 'ASHORE' " & _
        '                        IIf(MainReportFilter.Length > 0, " AND " & MainReportFilter, "")

        cSQL = "Select * from Rpt_CrewWithoutDocRpt where FKeyDocGroup = 'SYSMEDCERT' and " & IIf(MainReportFilter.Length > 0, MainReportFilter, "")

        If (REPORT_DETAIL.FilterOption.GetFilterValue("Expired")) <> "" Or (REPORT_DETAIL.FilterOption.GetFilterValue("Expiring")) <> "" Then
            cSQL = cSQL & " and ("
        End If
        Dim ExpiringSelected As Boolean
        If REPORT_DETAIL.FilterOption.GetFilterValue("Expiring") = "1" Then
            cSQL = cSQL & "  (daystoexpire > 0 and daystoexpire <= " & CType(IIf(strDocExpDays.Equals(""), "0", strDocExpDays), Integer) & ")"
            ExpiringSelected = True
        ElseIf REPORT_DETAIL.FilterOption.GetFilterValue("Expiring") = "0" Then
            cSQL = cSQL & "  (daystoexpire <= 0 or daystoexpire > " & CType(IIf(strDocExpDays.Equals(""), "0", strDocExpDays), Integer) & ")"
            ExpiringSelected = True
        End If

        If REPORT_DETAIL.FilterOption.GetFilterValue("Expired") = "1" Then
            If ExpiringSelected Then
                cSQL = cSQL & " or "
            Else
                'cSQL = cSQL & " and "
            End If
            cSQL = cSQL & " ExpiredNa = 1 "
        ElseIf REPORT_DETAIL.FilterOption.GetFilterValue("Expired") = "0" Then
            If ExpiringSelected Then
                cSQL = cSQL & " or "
            Else
                'cSQL = cSQL & " and "
            End If
            cSQL = cSQL & " ExpiredNa = 0 "
        End If

        If (REPORT_DETAIL.FilterOption.GetFilterValue("Expired")) <> "" Or (REPORT_DETAIL.FilterOption.GetFilterValue("Expiring")) <> "" Then
            cSQL = cSQL & "  )"
        End If
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
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_CertDocName, "CertDocName", REPORT_DETAIL.SortOption.GetSortValueCode("CertDocName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
