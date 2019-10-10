Imports MPS4
Imports Utilities
Imports Reports

Public Class SOffDueToSpecificReason

    Private MainReport As New rptSOffDueToSpecificReason
    Dim strSubTitle As String

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim cSQL As String

        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        'CREATES A LIST OF FILTER OPTION ITEMS THAT ARE TO BE EXCEMPTED, IF THE REPORT IS BEING CREATED BY AutoEmail
        Dim ListOfExcemptedFilterOptionsByCaption As New List(Of String)
        If REPORT_DETAIL.AutoEmail.Enabled Then
            ListOfExcemptedFilterOptionsByCaption.Add("From")
            ListOfExcemptedFilterOptionsByCaption.Add("To")
        End If
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(, ListOfExcemptedFilterOptionsByCaption)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE

        'ARRANGE DATE COVERAGE FILTER
        Dim DateCoverageFilter As String = ""
        If Not GetDateCondition(REPORT_DETAIL, DateCoverageFilter) Then Exit Sub

        '---------------------------------------------------------------------------------------------------------------------------------------
        'MANDATORY FILTER
        Dim cFilter As String = ""
        cFilter = "(ss.VslName IN " & WhereList & " OR ss.VslNameAdm IN " & WhereList & " ) "

        cFilter = cFilter & " AND " & _
                          "(ss.SOFFStat = dbo.GetRptDataMapCodeValue('STAT_FINISHEDCONTRACT') " & _
                          "     OR ss.soffstat = dbo.GetRptDataMapCodeValue('STAT_COMPASSIONATE') " & _
                          "     OR ss.soffstat = dbo.GetRptDataMapCodeValue('STAT_DISCIPLINARY') " & _
                          "     OR ss.soffstat = dbo.GetRptDataMapCodeValue('STAT_EMERGENCYLEAVE') " & _
                          "     OR ss.soffstat = dbo.GetRptDataMapCodeValue('STAT_BUSINESSRSN') " & _
                          ") " & _
                          "AND stat.PKey is not null " & _
                          "AND ss.DateStart is not null " & _
                          "AND rn_SignOff = 1 " & _
                          "AND ss.acttype = 'SEA' "

        If MainReportFilter.Length > 0 Then
            cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & MainReportFilter
        End If

        If DateCoverageFilter.Length > 0 Then
            cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & DateCoverageFilter
        End If

        'cSQL = "SELECT		    crew.*, dept.name as RankDept, ss.* " & _
        '       "FROM		    (SELECT IDNbr, Crew, Nationality, Rank FROM dbo.Rpt_BioInfo) AS crew LEFT OUTER JOIN " & _
        '       "                (SELECT    dbo.Rpt_CrewActAll.*, dbo.tblAdmVsl.Name AS VslNameAdm, " & _
        '       "                            rn_SignOn = ROW_NUMBER() OVER (PARTITION BY dbo.Rpt_CrewActAll.actgrpid " & _
        '       "                            ORDER BY dbo.Rpt_CrewActAll.DateStart), " & _
        '       "                            rn_SignOff = ROW_NUMBER() OVER (PARTITION BY dbo.Rpt_CrewActAll.actgrpid " & _
        '       "                            ORDER BY dbo.Rpt_CrewActAll.DateEnd desc)" & _
        '       "                    FROM       dbo.Rpt_CrewActAll LEFT OUTER JOIN " & _
        '       "                               dbo.tblAdmVsl ON dbo.Rpt_CrewActAll.actgrpid = dbo.tblAdmVsl.PKey) AS ss ON crew.IDNbr = ss.IDNbr LEFT OUTER JOIN " & _
        '       "                dbo.tbladmrank as rank ON ss.fkeyrankcode = rank.pkey LEFT OUTER JOIN " & _
        '       "                dbo.tbladmdept as dept ON rank.deptcode = dept.pkey LEFT OUTER JOIN " & _
        '       "                dbo.tbladmstat as stat ON ss.Soffstat = stat.pkey " & _
        'IIf(cFilter.Length > 0, " WHERE " & cFilter & " ", "")

        cSQL = "SELECT		crew.*, dept.Name as RankDept, ss.*, stat.Name as SOffReason, rank.Abbrv as RankAbbrv " & _
               "FROM		(SELECT IDNbr, Crew, Nationality, Rank FROM dbo.Rpt_BioInfo) AS crew LEFT OUTER JOIN " & _
               "            (SELECT    dbo.Rpt_CrewActAll.*, dbo.tblAdmVsl.Name AS VslNameAdm, " & _
               "            rn_SignOn = ROW_NUMBER() OVER (PARTITION BY dbo.Rpt_CrewActAll.actgrpid ORDER BY dbo.Rpt_CrewActAll.DateStart), " & _
               "            rn_SignOff = ROW_NUMBER() OVER (PARTITION BY dbo.Rpt_CrewActAll.actgrpid ORDER BY dbo.Rpt_CrewActAll.DateEnd desc) " & _
               "FROM        dbo.Rpt_CrewActAll LEFT OUTER JOIN " & _
               "            dbo.tblAdmVsl ON dbo.Rpt_CrewActAll.actgrpid = dbo.tblAdmVsl.PKey) AS ss ON crew.IDNbr = ss.IDNbr LEFT OUTER JOIN " & _
               "            dbo.tbladmrank as rank ON ss.fkeyrankcode = rank.pkey LEFT OUTER JOIN " & _
               "            dbo.tbladmdept as dept ON rank.deptcode = dept.pkey LEFT OUTER JOIN " & _
               "            dbo.tbladmstat as stat ON ss.Soffstat = stat.pkey " & _
               IIf(cFilter.Length > 0, " WHERE " & cFilter & " ", "")

        '---------------------------------------------------------------------------------------------------------------------------------------
        'Note: Sorting should be applied from the report bands, not on source
        If Sorting.Length > 0 Then
            cSQL = cSQL & "ORDER BY " & Sorting & " "
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim dt As DataTable
        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        '---------------------------------------------------------------------------------------------------------------------------------------
        With MainReport
            .txtDateSOn.DataBindings.Add("Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
            .txtDateSOff.DataBindings.Add("Text", Nothing, "DateSOff", "{0:dd-MMM-yyyy}")
            .DataSource = dt
            .Name = REPORT_DETAIL.ReportObjectID
            BindReportControls(MainReport)
            AddFieldsToGroupHeaderBand(.GroupHeader_VslName, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
            AddSortFieldsToDetailBandFromDT(.Detail, REPORT_DETAIL.SortOption.SortDataSource)
            SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

            .subHeader.ReportSource = New Reports.rptHeader(MainReport)
            .lblSubTitle.Text = strSubTitle
            '---------------------------------------------------------------------------------------------------------------------------------------
            REPORT_DETAIL.MainReport = MainReport
        End With


    End Sub

    Function GetDateCondition(REPORT_DETAIL As ReportDetail, ByRef WhereConditionString As String) As Boolean
        'RETURN FALSE IF DOES NOT PASS VALIDATION
        Dim ReturnValue As Boolean = True


        'Get date filter
        Dim DateFrom As Object = Nothing
        Dim DateTo As Object = Nothing
        Dim tmpDateFrom As String = ""
        Dim tmpDateTo As String = ""

        'Get Date Parameters
        REPORT_DETAIL.RetrieveFilterDate("From", "To", DateFrom, DateTo)
        tmpDateFrom = IIf(IsNothing(DateFrom), "", ChangeToSQLDate(CDate(DateFrom)))
        tmpDateTo = IIf(IsNothing(DateTo), "", ChangeToSQLDate(CDate(DateTo)))

        strSubTitle = changeDateRangeToSubTitle(tmpDateFrom, tmpDateTo)

        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.datesoff is not null AND ss.datesoff BETWEEN [FROM] AND [TO]", "[FROM]", "[TO]", DateFrom, DateTo)
        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.datesoff is not null AND ss.datesoff >= [FROM]", "[FROM]", "", DateFrom, Nothing)
        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.datesoff is not null AND ss.datesoff <= [TO]", "", "[TO]", Nothing, DateTo)
        End If

        'Select Case REPORT_DETAIL.ReportObjectID
        '    Case ReportType.Historical
        '        WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("dbo.DateIsInRange([FROM],[TO], ss.datestart,ss.dateend) = 1", "[FROM]", "[TO]", DateFrom, DateTo)

        '    Case ReportType.SignOffList

        '        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
        '            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.datesoff is not null AND ss.datesoff BETWEEN [FROM] AND [TO]", "[FROM]", "[TO]", DateFrom, DateTo)
        '        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
        '            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.datesoff is not null AND ss.datesoff >= [FROM]", "[FROM]", "", DateFrom, Nothing)
        '        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
        '            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.datesoff is not null AND ss.datesoff <= [TO]", "", "[TO]", Nothing, DateTo)
        '        End If

        '    Case ReportType.SignOnList

        '        If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
        '            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.dateson is not  null AND ss.dateson BETWEEN [FROM] AND [TO]", "[FROM]", "[TO]", DateFrom, DateTo)
        '        ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
        '            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.dateson is not null AND ss.dateson >= [FROM]", "[FROM]", "", DateFrom, Nothing)
        '        ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
        '            WhereConditionString = REPORT_DETAIL.ConstructCoverageCondition("ss.dateson is not null AND ss.dateson <= [TO]", "", "[TO]", Nothing, DateTo)
        '        End If
        'End Select

RETURN_AND_EXIT:
        Return ReturnValue
    End Function


    '    Function GetDateCondition_Normal(REPORT_DETAIL As ReportDetail, ByRef WhereConditionString As String) As Boolean
    '        'RETURN FALSE IF DOES NOT PASS VALIDATION
    '        Dim ReturnValue As Boolean = True

    '        Dim DateFrom As Object = Nothing
    '        Dim DateTo As Object = Nothing
    '        Dim tmpDateFrom As String
    '        Dim tmpDateTo As String

    '        'Get Date Parameters

    '        tmpDateFrom = REPORT_DETAIL.FilterOption.GetFilterValue("From")
    '        If tmpDateFrom.Length > 0 Then
    '            Try
    '                DateFrom = CDate(tmpDateFrom)
    '                tmpDateFrom = ChangeToSQLDate(DateFrom)
    '            Catch ex As Exception
    '                tmpDateFrom = ""
    '            End Try
    '        Else
    '            tmpDateFrom = ""
    '        End If

    '        tmpDateTo = REPORT_DETAIL.FilterOption.GetFilterValue("To")
    '        If tmpDateTo.Length > 0 Then
    '            Try
    '                DateTo = CDate(tmpDateTo)
    '                tmpDateTo = ChangeToSQLDate(DateTo)
    '            Catch ex As Exception
    '                tmpDateTo = ""
    '            End Try
    '        Else
    '            tmpDateTo = ""
    '        End If

    '        'Validate Dates 
    '        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
    '            If IsDate(DateFrom) And IsDate(DateTo) Then
    '                If DateTo < DateFrom Then
    '                    If REPORT_DETAIL.ShowMsgBox Then MsgBox("Ending date must be later than the starting date", MsgBoxStyle.Information)
    '                    ReturnValue = False
    '                    GoTo RETURN_AND_EXIT
    '                End If
    '            End If
    '        End If


    '        strSubTitle = changeDateRangeToSubTitle(tmpDateFrom, tmpDateTo)

    '        'Get date filter

    '        Select Case REPORT_DETAIL.ReportObjectID
    '            Case ReportType.Historical

    '                'WhereConditionString = "dbo.DateIsInRange(" & IIf(tmpDateFrom.Length > 0, tmpDateFrom, "Null") & ", " & IIf(tmpDateTo.Length > 0, tmpDateTo, "Null") & ", ss.datestart,ss.dateend) = 1"
    '                WhereConditionString = "dbo.DateIsInRange(" & IIf(tmpDateFrom.Length > 0, ChangeToSQLDate(DateFrom), "Null") & ", " & IIf(tmpDateTo.Length > 0, ChangeToSQLDate(DateTo), "Null") & ", ss.datestart,ss.dateend) = 1"

    '            Case ReportType.SignOffList

    '                'If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.datesoff is not null AND ss.datesoff BETWEEN " & tmpDateFrom & " AND " & tmpDateTo
    '                'ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
    '                '    WhereConditionString = "ss.datesoff is not null AND ss.datesoff >= " & tmpDateFrom
    '                'ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.datesoff is not null AND ss.datesoff <= " & tmpDateTo
    '                'End If
    '                If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.datesoff BETWEEN " & ChangeToSQLDate(DateFrom) & " AND " & ChangeToSQLDate(DateTo)
    '                ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.datesoff >= " & ChangeToSQLDate(DateFrom)
    '                ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.datesoff <= " & ChangeToSQLDate(DateTo)
    '                End If

    '            Case ReportType.SignOnList
    '                'If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.dateson is not  null AND ss.dateson BETWEEN " & tmpDateFrom & " AND " & tmpDateTo
    '                'ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
    '                '    WhereConditionString = "ss.dateson is not null AND ss.dateson >= " & tmpDateFrom
    '                'ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.dateson is not null AND ss.dateson <= " & tmpDateTo
    '                'End If

    '                If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
    '                    WhereConditionString = "ss.dateson is not  null AND ss.dateson BETWEEN " & ChangeToSQLDate(DateFrom) & " AND " & ChangeToSQLDate(DateTo)
    '                ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
    '                    WhereConditionString = "ss.dateson is not null AND ss.dateson >= " & ChangeToSQLDate(DateFrom)
    '                ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
    '                    WhereConditionString = "ss.dateson is not null AND ss.dateson <= " & ChangeToSQLDate(DateTo)
    '                End If
    '        End Select

    'RETURN_AND_EXIT:
    '        Return ReturnValue
    '    End Function

    '    Function GetDateCondition_AutoEmail(REPORT_DETAIL As ReportDetail, ByRef WhereConditionString As String) As Boolean
    '        'RETURN FALSE IF DOES NOT PASS VALIDATION
    '        Dim ReturnValue As Boolean = True

    '        Dim DateFrom As Object = Nothing
    '        Dim DateTo As Object = Nothing
    '        'Dim tmpDateFrom As String = ""
    '        'Dim tmpDateTo As String = ""

    '        'Get Date Parameters

    '        Try
    '            If Not IsNothing(REPORT_DETAIL.AutoEmail.DateRange.Values._From) Then
    '                If IsDate(REPORT_DETAIL.AutoEmail.DateRange.Values._From) Then
    '                    DateFrom = REPORT_DETAIL.AutoEmail.DateRange.Values._From
    '            '    Else
    '            '        tmpDateFrom = ""
    '                End If
    '                'Else
    '                '    tmpDateFrom = ""
    '            End If
    '        Catch ex As Exception
    '            'tmpDateFrom = ""
    '            DateFrom = Nothing
    '        End Try


    '        Try
    '            If Not IsNothing(REPORT_DETAIL.AutoEmail.DateRange.Values._To) Then
    '                If IsDate(REPORT_DETAIL.AutoEmail.DateRange.Values._To) Then
    '                    DateTo = REPORT_DETAIL.AutoEmail.DateRange.Values._To
    '                'Else
    '                '    tmpDateTo = ""
    '                End If
    '                'Else
    '                '    tmpDateTo = ""
    '            End If
    '        Catch ex As Exception
    '            DateTo = Nothing
    '            'tmpDateTo = ""
    '        End Try

    '        strSubTitle = changeDateRangeToSubTitle(DateFrom, DateTo)

    '        'Validate Dates 
    '        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
    '            If IsDate(DateFrom) And IsDate(DateTo) Then
    '                If DateTo < DateFrom Then
    '                    If REPORT_DETAIL.ShowMsgBox Then MsgBox("Ending date must be later than the starting date", MsgBoxStyle.Information)
    '                    ReturnValue = False
    '                    GoTo RETURN_AND_EXIT
    '                End If
    '            End If
    '        End If


    '        'Get date filter
    '        Dim tmpDateFrom As String = "Null", tmpDateTo As String = "Null"
    '        If Not IsNothing(DateFrom) Then
    '            If IsDate(DateFrom) Then tmpDateFrom = ChangeToSQLDate(DateFrom).ToString
    '        End If

    '        If Not IsNothing(DateTo) Then
    '            If IsDate(DateTo) Then tmpDateTo = ChangeToSQLDate(DateTo).ToString
    '        End If

    '        Select Case REPORT_DETAIL.ReportObjectID
    '            Case ReportType.Historical

    '                'WhereConditionString = "dbo.DateIsInRange(" & IIf(tmpDateFrom.Length > 0, ChangeToSQLDate(DateFrom), "Null") & ", " & IIf(tmpDateTo.Length > 0, ChangeToSQLDate(DateTo), "Null") & ", ss.datestart,ss.dateend) = 1"
    '                WhereConditionString = "dbo.DateIsInRange(" & tmpDateFrom & ", " & tmpDateTo & ", ss.datestart,ss.dateend) = 1"

    '            Case ReportType.SignOffList

    '                'If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.datesoff is not null AND ss.datesoff BETWEEN " & ChangeToSQLDate(DateFrom) & " AND " & ChangeToSQLDate(DateTo)
    '                'ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
    '                '    WhereConditionString = "ss.datesoff is not null AND ss.datesoff >= " & ChangeToSQLDate(DateFrom)
    '                'ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.datesoff is not null AND ss.datesoff <= " & ChangeToSQLDate(DateTo)
    '                'End If
    '                If Not tmpDateFrom.Equals("Null") And Not tmpDateTo.Equals("Null") Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.datesoff BETWEEN " & tmpDateFrom & " AND " & tmpDateTo
    '                ElseIf Not tmpDateFrom.Equals("Null") And tmpDateTo.Equals("Null") Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.datesoff >= " & tmpDateFrom
    '                ElseIf tmpDateFrom.Equals("Null") And Not tmpDateTo.Equals("Null") Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.datesoff <= " & tmpDateTo
    '                End If


    '            Case ReportType.SignOnList
    '                'If tmpDateFrom.Length > 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.dateson is not  null AND ss.dateson BETWEEN " & ChangeToSQLDate(DateFrom) & " AND " & ChangeToSQLDate(DateTo)
    '                'ElseIf tmpDateFrom.Length > 0 And tmpDateTo.Length = 0 Then
    '                '    WhereConditionString = "ss.dateson is not null AND ss.dateson >= " & ChangeToSQLDate(DateFrom)
    '                'ElseIf tmpDateFrom.Length = 0 And tmpDateTo.Length > 0 Then
    '                '    WhereConditionString = "ss.dateson is not null AND ss.dateson <= " & ChangeToSQLDate(DateTo)
    '                'End If

    '                If Not tmpDateFrom.Equals("Null") And Not tmpDateTo.Equals("Null") Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.dateson BETWEEN " & tmpDateFrom & " AND " & tmpDateTo
    '                ElseIf Not tmpDateFrom.Equals("Null") And tmpDateTo.Equals("Null") Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.dateson >= " & tmpDateFrom
    '                ElseIf tmpDateFrom.Equals("Null") And Not tmpDateTo.Equals("Null") Then
    '                    WhereConditionString = "ss.datesoff is not null AND ss.dateson <= " & tmpDateTo
    '                End If

    '        End Select

    'RETURN_AND_EXIT:
    '        Return ReturnValue
    '    End Function
End Class