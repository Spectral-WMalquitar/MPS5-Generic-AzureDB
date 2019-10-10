Public Class CrewUniform

    Public MainReport As New rptCrewUniform

    Private Structure InUseLabel
        Const InUse = "Currently In Use"
        Const NotInUse = "Not In Use"
    End Structure


    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT dbo.AssembleName(ci.lname, ci.fname, ci.mname, 1, 1, 0, 0, 0) CrewName, ca.RankName, rnk.SortCode as RankSort, CASE WHEN u.InUse <> 0 THEN '" & InUseLabel.InUse & "' ELSE '" & InUseLabel.NotInUse & "' ENd InUseLabel, dbo.isUniformReissue(u.FKeyGarment, u.InUse, u.DateIssue, u.FKeyIDNbr, u.FKeyActID) NeedReIssue, g.Name Garment, issuetype.Name as IssueType, ss.Description as SeaService, u.* FROM dbo.tblCrewInfo ci LEFT JOIN dbo.Current_Activites ca ON ci.pkey = ca.FKeyIDNbr LEFT JOIN dbo.tbluniformissuance u ON ci.PKey = u.FKeyIDNbr LEFT JOIN dbo.tbladmrank rnk ON ca.FKeyRankCode = rnk.PKey LEFT JOIN dbo.tblAdmGarment g ON u.FKeyGarment = g.PKey LEFT JOIN dbo.tbladmuniformissuetype issuetype ON u.FKeyIssueType = issuetype.PKey LEFT JOIN dbo.view_SeaServiceSelection ss ON u.FKeyActID = ss.ActID "

        '---------------------------------------------------------------------------------------------------------------------------------------
        Dim DateFrom As Object = Nothing
        Dim DateTo As Object = Nothing
        Dim tmpDateFrom As String
        Dim tmpDateTo As String

        'Get Date Parameters
        tmpDateFrom = REPORT_DETAIL.FilterOption.GetFilterValue("Date Issue From")
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

        tmpDateTo = REPORT_DETAIL.FilterOption.GetFilterValue("Date Issue To")
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


        'validate dates 
        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            If DateTo < DateFrom Then
                If REPORT_DETAIL.ShowMsgBox Then
                    MsgBox("ending date must be later than the starting date", MsgBoxStyle.Information)
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
        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.celToDate.Text = SubTitle_Date
        BindData(MainReport.celCrewName, "Text", Nothing, "CrewName", "{0}")
        BindData(MainReport.celRankName, "Text", Nothing, "RankName", "{0}")
        BindData(MainReport.celDateIssue, "Text", Nothing, "DateIssue", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celGroupName, "Text", Nothing, "InUseLabel")
        BindData(MainReport.celGarment, "Text", Nothing, "Garment")
        BindData(MainReport.celIssueType, "Text", Nothing, "IssueType")
        BindData(MainReport.celPreferredSize, "Text", Nothing, "PreferredSize")
        BindData(MainReport.celNeedReIssue, "Text", Nothing, "NeedReIssue")
        BindData(MainReport.celSeaService, "Text", Nothing, "SeaService")
        BindData(MainReport.celRemarks, "Text", Nothing, "Remarks")
        BindData(MainReport.celIssuedBy, "Text", Nothing, "IssuedBy")
        BindData(MainReport.celQuantity, "Text", Nothing, "Quantity", "{0:#,##0}")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Crew, "CrewName", FieldSortOrder.Ascending)
        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Use, "InUseLabel", FieldSortOrder.Ascending)
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub


End Class
