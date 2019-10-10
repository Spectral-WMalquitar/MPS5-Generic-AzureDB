Public Class OngoingMedicalStatus
    Public MainReport As New rptOngoingMedicalStatus

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT	ci.LName, ci.fname, ci.MName, dbo.AssembleName(ci.lname, ci.fname, ci.mname, 1, 1, 0, 0, 0) CrewName, ca.RankName, ca.CurrentStatName, ca.FKeyRankCode, ca.fkeyagentcode, ca.FKeyPrinCode, ca.FKeyFlt, " & _
               "		m.*, v.name as VesselName, medstat.Name MedicalStatus " & _
               "FROM    dbo.tblMedHistory m INNER JOIN " & _
               "        dbo.tblCrewInfo ci ON ci.PKey = m.FKeyIDNbr INNER JOIN " & _
               "        dbo.Current_Activites ca ON m.FKeyIDNbr = ca.FKeyIDNbr LEFT JOIN " & _
               "        dbo.tblAdmVsl v ON v.PKey = m.FKeyVessel LEFT JOIN " & _
               "        dbo.tblAdmMedStat medstat ON m.FKeyMedStatus = medstat.PKey " & _
               "WHERE   FKeyMedStatus = 'SYSMEDONGOING' "


        Dim cFilterStatus As String = IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Current Status", BaseFilterOption.GetFilterReturnWhat.EditValue, False), "")
        If cFilterStatus.Length > 0 Then
            MainReportFilter = MainReportFilter & IIf(MainReportFilter.Length > 0, " AND ", "") & " CurrentStatName = '" & cFilterStatus & "'"
        End If

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " AND " & MainReportFilter & " "
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

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        BindData(MainReport.celCrew, "Text", Nothing, "CrewName")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celStatus, "Text", Nothing, "CurrentStatName")
        BindData(MainReport.celDiagnosis, "Text", Nothing, "Diagnosis")
        BindData(MainReport.celDateAcquired, "Text", Nothing, "DateAcq", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celVessel, "Text", Nothing, "VesselName")
        BindData(MainReport.celPlace, "Text", Nothing, "PlaceAcquired")
        BindData(MainReport.celPICaseRefNo, "Text", Nothing, "PICaseRefNo")
        BindData(MainReport.celMedicalStatus, "Text", Nothing, "MedicalStatus")
        BindData(MainReport.celLastStatusDate, "Text", Nothing, "DateStatus", "{0:dd-MMM-yyyy}")


        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
