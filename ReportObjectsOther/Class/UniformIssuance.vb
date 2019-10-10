Public Class UniformIssuance
    Public MainReport As New rptUniformIssuance

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        'setup labels and cells specific for each report
        If REPORT_DETAIL.ReportObjectID = "rptUniformIssuance_PerMonth" Then
            With MainReport
                .celTitle.Text = "Uniform Issuance Per Month"
                .celCaption.Text = "Month:"
                BindData(.celGroupName, "Text", Nothing, "Month")
                AddFieldsToGroupHeaderBand(.GroupHeader, "Month", REPORT_DETAIL.SortOption.GetSortValueCode("Month"))
                .lblMonthGarment.Text = "Garment"
                BindData(.celMonthGarment, "Text", Nothing, "Garment")
            End With

        ElseIf REPORT_DETAIL.ReportObjectID = "rptUniformIssuance_PerGarment" Then
            With MainReport
                .celTitle.Text = "Uniform Issuance Per Garment"
                .celCaption.Text = "Garment:"
                BindData(.celGroupName, "Text", Nothing, "Garment")
                AddFieldsToGroupHeaderBand(.GroupHeader, "Garment", REPORT_DETAIL.SortOption.GetSortValueCode("Garment"))
                .lblMonthGarment.Text = "Month"
                BindData(.celMonthGarment, "Text", Nothing, "Month")
            End With
        Else
            MsgBox("Unable to generate report. Please contact your system administrator for assistance.", MsgBoxStyle.Information)
            Exit Sub
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        'cSQL = "SELECT *  FROM dbo.view_UniformIssuance "
        cSQL = "SELECT dbo.AssembleName(ci.lname, ci.fname, ci.MName,1,1,0,0,0) Crew,  dbo.ChangeDateToMCode(ui.DateIssue), CASE WHEN len(isnull(ui.dateissue,'')) > 0 THEN format(ui.DateIssue, 'MMM-yyyy') ELSE NULL END [Month], g.Name Garment, ui.* FROM dbo.tblUniformIssuance ui INNER JOIN dbo.tblAdmGarment g ON ui.FKeyGarment = g.PKey INNER JOIN dbo.tblcrewinfo ci ON ui.fkeyidnbr = ci.pkey INNER JOIN dbo.Current_Activites ca ON ui.FKeyIDNbr = ca.FKeyIDNbr "

        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim DateFrom As Object = Nothing
        Dim DateTo As Object = Nothing
        Dim tmpDateFrom As String
        Dim tmpDateTo As String

        'Get Date Parameters
        tmpDateFrom = REPORT_DETAIL.FilterOption.GetFilterValue("From")
        If tmpDateFrom.Length > 0 Then
            Try
                DateFrom = CDate(tmpDateFrom)
                tmpDateFrom = ChangeToSQLDate(DateFrom)
            Catch ex As Exception
                tmpDateFrom = ""
            End Try
        Else
            tmpDateFrom = ""
        End If

        tmpDateTo = REPORT_DETAIL.FilterOption.GetFilterValue("To")
        If tmpDateTo.Length > 0 Then
            Try
                DateTo = CDate(tmpDateTo)
                tmpDateTo = ChangeToSQLDate(DateTo)
            Catch ex As Exception
                tmpDateTo = ""
            End Try
        Else
            tmpDateTo = ""
        End If


        'Validate Dates 
        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            If DateTo < DateFrom Then
                If REPORT_DETAIL.ShowMsgBox Then
                    MsgBox("Ending date must be later than the starting date", MsgBoxStyle.Information)
                End If
                Exit Sub
            End If
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Get date filter
        Dim DateCoverageFilter As String = ""
        Dim SubTitle_Date As String = ""

        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
            DateCoverageFilter = "DateIssue is not null AND DateIssue BETWEEN " & tmpDateFrom & " AND " & tmpDateTo
            SubTitle_Date = "from " & Format(DateFrom, "dd-MMM-yyyy") & " to " & Format(DateTo, "dd-MMM-yyyy")
        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
            DateCoverageFilter = "DateIssue is not null AND DateIssue >= " & tmpDateFrom
            SubTitle_Date = "since " & Format(DateFrom, "dd-MMM-yyyy")
        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
            DateCoverageFilter = "DateIssue is not null AND DateIssue <= " & tmpDateTo
            SubTitle_Date = "until " & Format(DateTo, "dd-MMM-yyyy")
        Else
            SubTitle_Date = "as of " & Format(DateTime.Now(), "dd-MMM-yyyy")
        End If

        'assemble Main Report Filter
        If DateCoverageFilter.Length > 0 Then
            MainReportFilter = MainReportFilter & IIf(MainReportFilter.Length > 0, " AND ", "") & DateCoverageFilter
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim x As New rptUniformIssuance_PerMonth
        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        MainReport.celToDate.Text = SubTitle_Date
        BindData(MainReport.celCrew, "Text", Nothing, "Crew")
        BindData(MainReport.celDateIssued, "Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celIssuedBy, "Text", Nothing, "IssuedBy")
        BindData(MainReport.celQuantity, "Text", Nothing, "Quantity", "{0:#,##0}")
        BindData(MainReport.celTotalQuantity, "Text", Nothing, "Quantity", "{0:#,##0}")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString

        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

End Class
