Public Class rptPaySASummaryCrew_2
    Public MainReport As New rptPaySASummaryReportCrew
    'Public frmfilter As New frmPaySASummaryCrewPS
    'Public Sub New(ByRef REPORT_DETAIL As ReportDetail)
    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        'Reports.OpenReportWaitForm()
        'INSERTS FILTER BASED ON USER-DATA FILTER ASSIGNMENT TO MAIN REPORT FILTER
        'REPORT_DETAIL.addUserDataFilterToMainReportFilter(, "FKeyAgent", "FKeyPrin", "FKeyFlt")
        '--------------------------------------------------------------------------------------------------------------------------------------

        Dim Period_From As String = REPORT_DETAIL.FilterOption.GetFilterValue("Period From")
        Dim Period_To As String = REPORT_DETAIL.FilterOption.GetFilterValue("Period To")
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList

        'Period_From = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        'Period_To = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        'wherelist = MPS4.FKeyVslCode

        'frmfilter.ShowDialog()
        'If Not frmfilter.NoIssue Then
        '    Exit Sub
        'End If

        'MsgBox(Period_From)
        'MsgBox(frmfilter.cboVsl.EditValue)

        Dim dt As DataTable
        Dim cSQL As String
        'neil20161208 Dim Period As Integer = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        Dim FKeyPrinCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Principal")
        'Dim FKeyVslCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel")
        Dim RefNo As String = REPORT_DETAIL.FilterOption.GetFilterValue("RefNo")


        Dim finalstr As String = "", periodfr As String, periodto As String
        Dim kwitan As Boolean = False

        If Period_From <> Nothing Then
            finalstr = "@PeriodFrom = " & Period_From
            kwitan = True

            periodfr = MonthName(Period_From - ((Period_From \ 100) * 100)) & _
                         " " & Period_From \ 100
        Else
            periodfr = "First"
        End If

        If Period_To <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@PeriodTo = " & Period_To
            kwitan = True

            periodto = MonthName(Period_To - ((Period_To \ 100) * 100)) & _
                         " " & Period_To \ 100

        Else
            periodto = "Latest"
            'kwitan = False
        End If

        If WhereList <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@CrewIDNbr = '" & Replace(WhereList, "'", "") & "'"
        End If

        If RefNo <> Nothing Then
            If kwitan Then
                finalstr = finalstr & ","
            End If
            finalstr = finalstr & "@RefNo = '" & RefNo & "'"
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "EXEC SP_PAY_MPOSummaryCrew " & finalstr
        '& Period_From & _
        '"," & Period_To & _
        '",'" & frmfilter.cboVsl.EditValue & "'"

        'If MainReportFilter.Length > 0 Then
        '    cSQL = cSQL & " WHERE " & MainReportFilter & " "
        'End If

        'If Sorting.Length > 0 Then
        '    cSQL = cSQL & " ORDER BY " & Sorting & " "
        'End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        'MainReport.Name = REPORT_DETAIL.ReportName
        Dim periodtemp As String = ""

        'If Period_From = Nothing And Period_To = Nothing Then
        '    periodtemp = " All "
        'Else
        '    If Period_From <> Nothing Then
        '        periodtemp = "From " & MonthName(Right(Period_From, 2)) & "-" & Left(Period_From, 4)
        '    End If
        '    If Period_To <> Nothing Then
        '        periodtemp = periodtemp & " To " & MonthName(Right(Period_To, 2)) & "-" & Left(Period_To, 4)

        '    End If
        'End If


        MainReport.txtCompany.Text = MPSDB.GetConfig("NAME")
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        'MainReport.txtCrewName.Text = periodtemp

        With MainReport

            BindData(.txtVesselName, "Text", Nothing, "VslName")
            'neil BindData(.txtRefName, "Text", Nothing, "RefNo")
            BindData(.colPeriod, "Text", Nothing, "MCode")
            'neil  BindData(.colAllottee, "Text", Nothing, "AllotName")
            BindData(.colBank, "Text", Nothing, "Bank")
            BindData(.colAcctName, "Text", Nothing, "AcctName")
            BindData(.colAcctNo, "Text", Nothing, "AcctNbr")
            'neil BindData(.colCurr, "Text", Nothing, "Currency")
            'neil BindData(.colExRate, "Text", Nothing, "ExRate", "{0:n2}")
            'neil BindData(.colEarn, "Text", Nothing, "TcEarn", "{0:n2}")
            'neil BindData(.colDed, "Text", Nothing, "TcDed", "{0:n2}")
            BindData(.colTotal, "Text", Nothing, "TotalMPOcAmt", "{0:n2}")
            'neil BindData(.colTEarn, "Text", Nothing, "TcEarn", "{0:n2}")
            'neil BindData(.colTDed, "Text", Nothing, "TcDed", "{0:n2}")
            BindData(.colTotalMPO, "Text", Nothing, "TotalMPOcAmt", "{0:n2}")

            BindData(.txtGrpCurrency, "Text", Nothing, "Currency")
            ''BindData(.txtCrew, "Text", Nothing, "MCodeStr", )
            BindData(.txtCrewName, "Text", Nothing, "CrewName", )

            'BindData(.colCrewName, "Text", Nothing, "AgentName")
            'BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
            'BindData(MainReport.celPlanRank, "Text", Nothing, "PlanRankName")z
            'BindData(MainReport.celDateAccepted, "Text", Nothing, "DateAccepted", "{0:dd-MMM-yyyy}")
            'BindData(MainReport.celPlanVsl, "Text", Nothing, "PlanVslName")
            'BindData(MainReport.celPlanJoinDate, "Text", Nothing, "PlanJoinDate", "{0:dd-MMM-yyyy}")
            'BindData(MainReport.celAgentCnt, "Text", Nothing, "Crew")
            'BindData(MainReport.celAgentBot, "Text", Nothing, "AgentName")

            AddFieldsToGroupHeaderBand(MainReport.CurrGroup, "Currency", 1)
            AddFieldsToGroupHeaderBand(MainReport.VslGroup, "VslCode", 1)
            AddFieldsToGroupHeaderBand(MainReport.CrewGroup, "CrewName", FieldSortOrder.Ascending)
            ''AddFieldsToGroupHeaderBand(MainReport.CrewGroup, "MCode", FieldSortOrder.Descending)
            'AddFieldsToGroupHeaderBand(MainReport.CurrGroup, "FKeyCurr")
        End With

        'PREVIEW REPORTcolCurr
        'Reports.CloseReportWaitForm()
        MainReport.ShowPreviewDialog()
    End Sub
End Class
