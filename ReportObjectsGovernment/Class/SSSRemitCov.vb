
Public Class SSSRemitCov
    Public MainReport As New rptSSSRemitCov
    Public SubRep As New rptSSSRemitCov_sub
    Private sqlConn As New SqlClient.SqlConnection
    'Public frmfilter As New frmPayHACrewPS
    Dim companySSSno As String
    Dim reversePeriod As String
    Dim tempNow As Date

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString.Length = 0 Then
            MsgBox("Please select a Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
            Exit Sub
        End If

        Dim Period As Integer = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        Dim VslCode As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim SBRNo As String '= REPORT_DETAIL.FilterOption.GetFilterValue("TR / SBR Number")
        Dim refNo As String
        Dim AmtPaid As String = "" '= REPORT_DETAIL.FilterOption.GetFilterValue("Amount Paid")
        Dim DatePaid As Date

        'frmfilter.cboPeriodFrom.EditValue = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        'frmfilter.cboPeriodTo.EditValue = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        ''frmfilter.CboCrew.EditValue = MPS4.FKeyVslCode

        'frmfilter.ShowDialog()
        'If Not frmfilter.NoIssue Then
        '    Exit Sub
        'End If



        'MsgBox(frmfilter.cboPeriodFrom.EditValue)
        'MsgBox(frmfilter.cboVsl.EditValue)

        Dim dt As New DataTable ', dtearn As DataTable, dtDed As DataTable, dttotEarn As DataTable, dttotDed As DataTable
        'Dim dtNetSum As DataTable
        'Dim cSQL As String
        Dim sumEmpe As Double, sumEmpr As Double
        Dim filename As String

        'Dim FKeyPrinCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Principal")
        'Dim FKeyVslCode As String = REPORT_DETAIL.FilterOption.GetFilterValue("Vessel")
        'Dim RefNo As String = REPORT_DETAIL.FilterOption.GetFilterValue("RefNo")

        Dim finalstr As String = "" ', periodfr As String ', periodto As String
        Dim kwitan As Boolean = False


        ' finalstr = "@period = " & Period & ", @sumamte =, @sumamtr = "
        'If frmfilter.cboPeriodFrom.EditValue <> Nothing Then
        '    finalstr = "@PeriodFrom = " & frmfilter.cboPeriodFrom.EditValue
        '    kwitan = True

        '    periodfr = MonthName(frmfilter.cboPeriodFrom.EditValue - ((frmfilter.cboPeriodFrom.EditValue \ 100) * 100)) & _
        '                 " " & frmfilter.cboPeriodFrom.EditValue \ 100
        'Else
        '    periodfr = "First"
        'End If

        'If frmfilter.cboPeriodTo.EditValue <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@PeriodTo = " & frmfilter.cboPeriodTo.EditValue
        '    kwitan = True

        '    periodto = MonthName(frmfilter.cboPeriodTo.EditValue - ((frmfilter.cboPeriodTo.EditValue \ 100) * 100)) & _
        '                 " " & frmfilter.cboPeriodTo.EditValue \ 100

        'Else
        '    periodto = "Latest"
        '    'kwitan = False
        'End If

        'If frmfilter.CboCrew.EditValue <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@CrewIDNbr = '" & frmfilter.CboCrew.EditValue & "'"
        'End If

        'If RefNo <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@RefNo = '" & RefNo & "'"
        'End If

        'If FKeyPrinCode <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    finalstr = finalstr & "@princode = '" & FKeyPrinCode & "'"
        'End If

        'If FKeyVslCode <> Nothing Then
        '    If kwitan Then
        '        finalstr = finalstr & ","
        '    End If
        '    'finalstr = finalstr & "@vslcode = '" & Replace(FKeyVslCode, ",", "','") & "'"
        '    finalstr = finalstr & "@vslcode = '" & FKeyVslCode & "'"
        'End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        'cSQL = "EXEC SP_pay_sss_cover " & finalstr

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                Exit Sub
            Else
                Dim sqlComm As New SqlClient.SqlCommand()
                Dim da As New SqlClient.SqlDataAdapter


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "SP_pay_sss_cover"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("Period", Period)
                sqlComm.Parameters.AddWithValue("vslcode", VslCode)
                sqlComm.Parameters.Add("sumamte", SqlDbType.Money)
                sqlComm.Parameters("sumamte").Direction = ParameterDirection.Output
                sqlComm.Parameters.Add("sumamtr", SqlDbType.Money)
                sqlComm.Parameters("sumamtr").Direction = ParameterDirection.Output


                Try
                    Dim ds As New DataSet
                    'sqlComm.ExecuteNonQuery()
                    da.SelectCommand = sqlComm
                    da.Fill(dt)
                    'MsgBox(sqlComm.Parameters("sumamte").Value)
                    'MsgBox(sqlComm.Parameters("sumamtr").Value)
                    'MsgBox(dt.Rows(0)(0))
                    sumEmpe = sqlComm.Parameters("sumamte").Value
                    sumEmpr = sqlComm.Parameters("sumamtr").Value
                    'returnKo = ""
                Catch SqlEx As SqlClient.SqlException
                    Exit Sub
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        '& frmfilter.cboPeriodFrom.EditValue & _
        '"," & frmfilter.cboPeriodTo.EditValue & _
        '",'" & frmfilter.cboVsl.EditValue & "'"

        'If MainReportFilter.Length > 0 Then
        '    cSQL = cSQL & " WHERE " & MainReportFilter & " "
        'End If

        'If Sorting.Length > 0 Then
        '    cSQL = cSQL & " ORDER BY " & Sorting & " "
        'End If

        'dt = MPSDB.CreateTable(cSQL)

        'cSQL = "EXEC sp_pay_HomeAllot_report_netSum " & finalstr
        'dtNetSum = MPSDB.CreateTable(cSQL)

        'If finalstr <> "" Then
        '    finalstr = finalstr & ","
        'End If

        'cSQL = "EXEC sp_pay_HomeAllot_report_sub " & finalstr & "@wageType = 1"
        'dtearn = MPSDB.CreateTable(cSQL)

        'cSQL = "EXEC sp_pay_HomeAllot_report_sub " & finalstr & "@wageType = 2"
        'dtDed = MPSDB.CreateTable(cSQL)

        'cSQL = "EXEC sp_pay_HomeAllot_report_sum " & finalstr & "@wageType = 1"
        'dttotEarn = MPSDB.CreateTable(cSQL)

        'cSQL = "EXEC sp_pay_HomeAllot_report_sum " & finalstr & "@wageType = 2"
        'dttotDed = MPSDB.CreateTable(cSQL)

        'If frmfilter.chkSelectedCrew.Checked And WhereList.Length <> 0 Then
        '    If dt.Select("FKeyIDNbr IN " & WhereList).Count = 0 Then
        '        dt = Nothing
        '        MsgBox("No crew selected", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Utilities.Util.GetAppPath)
        '        Exit Sub
        '    Else
        '        dt = dt.Select("FKeyIDNbr IN " & WhereList).CopyToDataTable
        '    End If
        'End If


        'dt = dt.Select("FKeyIDNbr IN " & WhereList).CopyToDataTable
        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        'If Not validateReportDataSource(dt) Then
        If Not dt Is Nothing Then
            If dt.Rows.Count = 0 Then
                MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
                Exit Sub
            End If
        Else
            MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
            Exit Sub
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------

        'Dim dv = New DataView(dt)
        'dv.RowFilter = "FKeyIDNbr IN " & WhereList
        'MainReport.DataSource = dv
        'MainReport.DataSource = dt
        'MainReport.Name = REPORT_DETAIL.ReportObjectID
        'Dim periodtemp As String = ""

        'If frmfilter.cboPeriodFrom.Text = Nothing And frmfilter.cboPeriodTo.Text = Nothing Then
        '    periodtemp = " All "
        'Else
        '    If frmfilter.cboPeriodFrom.Text <> Nothing Then
        '        periodtemp = "From " & frmfilter.cboPeriodFrom.Text
        '    End If
        '    If frmfilter.cboPeriodTo.Text <> Nothing Then
        '        periodtemp = periodtemp & " To " & frmfilter.cboPeriodTo.Text

        '    End If
        'End If

        MainReport.TxtCompany.Text = MPSDB.GetConfig("NAME")
        companySSSno = MPSDB.GetConfig("SSSno")
        If companySSSno <> "" Then
            MainReport.txtEmployerNo.Text = companySSSno
        Else
            MainReport.txtEmployerNo.Text = "0000000000"
            companySSSno = "0000000000"
        End If

        reversePeriod = Right(Period, 2) & Left(Period, 4)

        tempNow = Now

        filename = "R3" & companySSSno & reversePeriod & "." & Format(tempNow, "MMddHHmm")

        With MainReport
            'AddHandler .BeforePrint, AddressOf grpSBRNum_BeforePrint
            .DataSource = dt
            BindData(.txtSBRNo, "Text", Nothing, "ReceiptNumber")
            BindData(.txtPaymentDate, "Text", Nothing, "Datepaid", "{0:MMM dd,yyyy}")
            BindData(.txtAmtPaid, "Text", Nothing, "CertAmtPaid", "{0:#,##0.00}")
            BindData(.txtNoOfEmployees, "Text", Nothing, "idnbrcount")
            BindData(.txtNoOfEmployees_sub, "Text", Nothing, "idnbrcount")
            BindData(.txtEmpeAmtSum, "Text", Nothing, "CAmtEmpe_sum", "{0:#,##0.00}")
            BindData(.txtEmprAmtSum, "Text", Nothing, "CAmtEmpr_sum", "{0:#,##0.00}")
        End With

        MainReport.txtFileName.Text = filename
        'MainReport.txtSBRNo.Text = MainReport.txtSBRNo_grp.Text
        'SBRNo = MainReport.txtSBRNo_grp.Text
        'MainReport.txtPaymentDate.Text = Format(MainReport.txtPaymentDate_grp.Text, "{0:MMM dd,yyyy}")
        'DatePaid = Format(MainReport.txtPaymentDate_grp.Text, "MMM dd, yyyy")
        'If REPORT_DETAIL.FilterOption.GetFilterValue("Date of Payment").ToString.Length > 0 Then
        '    DatePaid = REPORT_DETAIL.FilterOption.GetFilterValue("Date of Payment")
        '    MainReport.txtPaymentDate.Text = Format(DatePaid, "MMM dd, yyyy")
        'End If
        'MainReport.txtAmtPaid.Text = MainReport.txtAmtPaid_grp.Text
        'AmtPaid = MainReport.txtAmtPaid_grp.Text
        'MainReport.txtEmpeAmtSum.Text = Format(sumEmpe, "#,##0.00")
        'MainReport.txtEmprAmtSum.Text = Format(sumEmpr, "#,##0.00")
        MainReport.txtTotalAmt.Text = MainReport.txtEmpeAmtSum.Text + MainReport.txtEmprAmtSum.Text 'Format(MainReport.txtEmpeAmtSum.Text + MainReport.txtEmprAmtSum.Text, "#,##0.00")

        MainReport.txtCompany_sub.Text = MPSDB.GetConfig("NAME")
        MainReport.txtFileName_sub.Text = "[" & filename & "]"
        'MainReport.txtCoyAdd.Text = MPSDB.GetConfig("ADDR")
        MainReport.txtPeriod.Text = reversePeriod

        'Dim rowxxx() As DataRow
        'If MainReport.GetCurrentColumnValue("ReceiptNumber").ToString <> "" Then
        '    rowxxx = MainReport.DataSource.Select("RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & _
        '                                          "' and ReceiptNumber ='" & MainReport.GetCurrentColumnValue("ReceiptNumber").ToString & "'")
        'Else
        '    rowxxx = MainReport.DataSource.Select("RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & _
        '                                         "'")
        'End If

        ''MainReport.txtNoOfEmployees.Text = ""
        'MainReport.txtNoOfEmployees.Text = rowxxx.GetUpperBound(0) + 1

        'MainReport.txtNoOfEmployees.Text = MainReport.GetCurrentColumnValue("ReceiptNumber").ToString()
        MainReport.txtNoOfEmployees_sub.Text = dt.Rows.Count

        AddFieldsToGroupHeaderBand(MainReport.grpSBRNum, "ReceiptNumber", FieldSortOrder.Ascending)
        AddFieldsToGroupHeaderBand(MainReport.grpRefNo, "RefNo", FieldSortOrder.Ascending)
        'With MainReport
        '    BindData(.txtCrewName, "Text", Nothing, "CrewName", )
        '    BindData(.txtRank, "Text", Nothing, "RankName", )
        '    BindData(.txtAllottee, "Text", Nothing, "AllotName")
        '    BindData(.txtAllotteeAdd, "Text", Nothing, "allottee_add")
        '    BindData(.txtBank, "Text", Nothing, "banknbranch")
        '    BindData(.txtAcctNo, "Text", Nothing, "AcctNbr")
        '    BindData(.txtVesselName, "Text", Nothing, "vslname")
        '    BindData(.txtFleet, "Text", Nothing, "fltname")
        '    BindData(.txtAllotUSD, "Text", Nothing, "AllotmentAmt", "{0:#,##0.00}")
        '    BindData(.txtAllotPHP, "Text", Nothing, "CAmt", "{0:#,##0.00}")
        '    BindData(.txtExRate, "Text", Nothing, "ExRate", "{0:#,##0.00}")

        '    BindData(.txtAllotUSD_lbl, "Text", Nothing, "allot_curr", "ALLOTMENT {0}")
        '    BindData(.txtAllotPHP_lbl, "Text", Nothing, "conv_curr", "ALLOTMENT {0}")
        '    BindData(.txtExRate_lbl, "Text", Nothing, "allot_curr", "{0} Exchange Rate")

        '    AddFieldsToGroupHeaderBand(MainReport.mcodegroup, "MCode", FieldSortOrder.Descending)
        '    AddFieldsToGroupHeaderBand(MainReport.allotteegroup, "AllotteeID", FieldSortOrder.Ascending)

        '    .subREarn.ReportSource = SubRep_Earn
        '    .subRDed.ReportSource = SubRep_Ded
        '    .SubRTotEarn.ReportSource = SubRep_TotEarn
        '    .SubRTotDed.ReportSource = SubRep_TotDed
        '    .SubRNetSum.ReportSource = SubRep_NetSum
        'End With
        If REPORT_DETAIL.Output.Mode = ReportOutputMode.Preview Then
            MainReport.SubReport.ReportSource = SubRep

            With SubRep

                .DataSource = dt
                BindData(.celFamName, "Text", Nothing, "LName", )
                BindData(.celGivName, "Text", Nothing, "FName")
                BindData(.celMI, "Text", Nothing, "MI")
                BindData(.celSSNo, "Text", Nothing, "SSSID")
                BindData(.celSS, "Text", Nothing, "CAmtEmpr", "{0:#,##0.00}")
                BindData(.celEC, "Text", Nothing, "CAmtEmpe", "{0:#,##0.00}")
                'BindData(.celRMRK, "Text", Nothing, "")
                BindData(.celSSNo, "Text", Nothing, "SSSID")
                AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
                AddHandler .BeforePrint, AddressOf grpSBRNumFooter_BeforePrint
                'AddHandler .AfterPrint, AddressOf grpSBRNumFooter_BeforePrint
                AddHandler .BeforePrint, AddressOf grpSBRNum_BeforePrint
                AddHandler .BeforePrint, AddressOf rptSSSRemitCov_BeforePrint
                AddHandler .AfterPrint, AddressOf grpRefNo_afterPrint
                AddHandler .BeforePrint, AddressOf txtFileName_BeforePrint
            End With


            'With SubRep_Ded

            '    .DataSource = dtDed
            '    BindData(.txtDedItem, "Text", Nothing, "WageName", "{0:#,##0.00}")
            '    BindData(.txtItemDedAmt, "Text", Nothing, "CAmt", "{0:#,##0.00}")
            '    BindData(.txtItemDedAmtSum, "Text", Nothing, "CAmt", "{0:#,##0.00}")
            '    .txtItemDedAmtSum.Summary.Running = SummaryRunning.Report
            '    AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
            'End With

            'With SubRep_TotEarn
            '    .DataSource = dttotEarn
            '    BindData(.txtTotalEarnAmtSum, "Text", Nothing, "totamt", "{0:#,##0.00}")
            '    AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
            'End With

            'With SubRep_TotDed
            '    .DataSource = dttotDed
            '    BindData(.txtTotalDedAmtSum, "Text", Nothing, "totamt", "{0:#,##0.00}")
            '    AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
            'End With

            'With SubRep_NetSum
            '    .DataSource = dtNetSum
            '    BindData(.txtNetAllot, "Text", Nothing, "NetSum", "{0:#,##0.00}")
            '    AddHandler .BeforePrint, AddressOf SetDetailBand_BeforePrint
            'End With

            '---------------------------------------------------------------------------------------------------------------------------------------
            REPORT_DETAIL.MainReport = MainReport

        ElseIf REPORT_DETAIL.Output.Mode = ReportOutputMode.Export Then
            Dim file As System.IO.StreamWriter
            Try
                Dim r As Integer, t As Integer = 1
                Dim newFile As Boolean = True

                file = Nothing
                SBRNo = "<start>"
                refNo = "<start>"
                tempNow = Now
                For r = 0 To dt.Rows.Count - 1

                    If Not dt(r)("Datepaid") Is DBNull.Value Then
                        DatePaid = dt(r)("Datepaid")
                    End If
                    If Not dt(r)("CertAmtPaid") Is DBNull.Value Then
                        AmtPaid = dt(r)("CertAmtPaid")
                    End If

                    If newFile Then
                        'edited by tony20170704 
                        'filename = "R3" & companySSSno & reversePeriod & "." & Format(DateAdd("n", t, tempNow), "MMddHHmm")
                        MsgBox("Select the location where the export file will be saved.", MsgBoxStyle.Information)
                        filename = SaveAsDialog("R3" & companySSSno & reversePeriod & "." & Format(DateAdd("n", t, tempNow), "MMddHHmm"), "Text File (*.txt)|*.txt")
                        'file = My.Computer.FileSystem.OpenTextFileWriter("c:\Spectral\" & filename & ".txt", True)
                        file = My.Computer.FileSystem.OpenTextFileWriter(filename, True)
                        'end tony

                        file.WriteLine("00" & gmmesmspace(30, UCase(MainReport.TxtCompany.Text)) & gmmesmspace(6, reversePeriod) & _
                                       gmmesmspace(10, Replace(companySSSno, "-", "")) & gmmesmspace(10, SBRNo) & gmmesmspace(8, Format(DatePaid, "MMddyyyy")) & _
                                       setAmtpaidstring(AmtPaid))
                        newFile = False
                    End If
                    'If refNo <> dt(r)("RefNo") Then
                    '    If refNo <> "<start>" Then
                    '        Call closefile(file, sumEmpr, sumEmpe)
                    '        sumEmpr = 0
                    '        sumEmpe = 0
                    '        refNo = "<start>"
                    '        SBRNo = "<start>"
                    '        t = t + 1
                    '    Else
                    '        refNo = dt(r)("RefNo")
                    '        If SBRNo <> dt(r)("ReceiptNumber") Then
                    '            If SBRNo <> "<start>" Then
                    '                Call closefile(file, sumEmpr, sumEmpe)
                    '                sumEmpr = 0
                    '                sumEmpe = 0
                    '                SBRNo = "<start>"
                    '                t = t + 1
                    '            End If
                    '            SBRNo = dt(r)("ReceiptNumber")

                    '            'If Not dt(r)("Datepaid") Is DBNull.Value Then
                    '            '    DatePaid = dt(r)("Datepaid")
                    '            'End If
                    '            'If Not dt(r)("CertAmtPaid") Is DBNull.Value Then
                    '            '    AmtPaid = dt(r)("CertAmtPaid")
                    '            'End If

                    '            'filename = "R3" & companySSSno & reversePeriod & "." & Format(DateAdd("n", t, tempNow), "MMddHHmm")
                    '            'file = My.Computer.FileSystem.OpenTextFileWriter("c:\Spectral\" & filename & ".txt", True)
                    '            'file.WriteLine("00" & gmmesmspace(30, UCase(MainReport.TxtCompany.Text)) & gmmesmspace(6, reversePeriod) & _
                    '            '               gmmesmspace(10, Replace(companySSSno, "-", "")) & gmmesmspace(10, SBRNo) & gmmesmspace(8, Format(DatePaid, "MMddyyyy")) & _
                    '            '               setAmtpaidstring(AmtPaid))
                    '        End If
                    '    End If
                    'End If
                    'For r = 0 To dt.Rows.Count - 1
                    file.WriteLine("20" & gmmesmspace(15, UCase(dt.Rows(r)("LName"))) & gmmesmspace(15, UCase(dt.Rows(r)("FName"))) & _
                    gmmesmspace(1, UCase(dt.Rows(r)("MI"))) & gmmesmspace(10, Replace(dt.Rows(r)("SSSID"), "-", "")) & _
                    gmmesmspace(8, Format(dt(r)("CAmtEmpr"), "###0.00")) & _
                    gmmesmspace(8, "0.00", 2) & _
                    gmmesmspace(8, "0.00", 2) & _
                    gmmesmspace(6, "0.00", 2) & _
                    gmmesmspace(6, "0.00", 2) & _
                    gmmesmspace(6, "0.00", 2) & _
                    gmmesmspace(6, Format(dt(r)("CAmtEmpe"), "###0.00"), 2) & _
                    gmmesmspace(6, "0.00", 2) & _
                    gmmesmspace(6, "0.00", 2) & _
                    gmmesmspace(8, "NO", 2)
                    )
                    sumEmpr = sumEmpr + dt(r)("CAmtEmpr")
                    sumEmpe = sumEmpe + dt(r)("CAmtEmpe")
                    System.Diagnostics.Debug.Print(UCase(dt.Rows(r)("LName")))


                    'If refNo <> dt(r)("RefNo") Then
                    'If refNo <> "<start>" Then
                    '    Call closefile(file, sumEmpr, sumEmpe)
                    '    sumEmpr = 0
                    '    sumEmpe = 0
                    '    refNo = "<start>"
                    '    SBRNo = "<start>"
                    '    t = t + 1
                    'Else
                    '    refNo = dt(r)("RefNo")
                    If r <> dt.Rows.Count - 1 Then
                        If (dt(r)("ReceiptNumber") <> dt(r + 1)("ReceiptNumber") And SBRNo <> "<start>") _
                            Or (dt(r)("RefNo") <> dt(r + 1)("RefNo") And refNo <> "<start>") Then
                            'If SBRNo <> "<start>" And refNo <> "<start>" Then
                            Call closefile(file, sumEmpr, sumEmpe)
                            sumEmpr = 0
                            sumEmpe = 0
                            t = t + 1
                            'End If
                            'SBRNo = dt(r)("ReceiptNumber")

                            'If Not dt(r)("Datepaid") Is DBNull.Value Then
                            '    DatePaid = dt(r)("Datepaid")
                            'End If
                            'If Not dt(r)("CertAmtPaid") Is DBNull.Value Then
                            '    AmtPaid = dt(r)("CertAmtPaid")
                            'End If

                            'filename = "R3" & companySSSno & reversePeriod & "." & Format(DateAdd("n", t, tempNow), "MMddHHmm")
                            'file = My.Computer.FileSystem.OpenTextFileWriter("c:\Spectral\" & filename & ".txt", True)
                            'file.WriteLine("00" & gmmesmspace(30, UCase(MainReport.TxtCompany.Text)) & gmmesmspace(6, reversePeriod) & _
                            '               gmmesmspace(10, Replace(companySSSno, "-", "")) & gmmesmspace(10, SBRNo) & gmmesmspace(8, Format(DatePaid, "MMddyyyy")) & _
                            '               setAmtpaidstring(AmtPaid))
                            'End If
                            'End If
                            newFile = True
                            'End If
                        End If
                    End If

                    refNo = dt(r)("RefNo")
                    SBRNo = dt(r)("ReceiptNumber")
                Next

                'file.WriteLine("99" & gmmesmspace(12, Format(sumEmpr, "###0.00"), 2) & _
                '                   gmmesmspace(12, "0.00", 2) & _
                '                   gmmesmspace(12, "0.00", 2) & _
                '                   gmmesmspace(10, "0.00", 2) & _
                '                   gmmesmspace(10, "0.00", 2) & _
                '                   gmmesmspace(10, "0.00", 2) & _
                '                   gmmesmspace(10, Format(sumEmpe, "###0.00"), 2) & _
                '                   gmmesmspace(10, "0.00", 2) & _
                '                   gmmesmspace(10, "0.00", 2)
                '                  )

                'file.Close()
                Call closefile(file, sumEmpr, sumEmpe)


                'MsgBox("File created (c:\Spectral\" & filename & ".txt) successfully created.", vbInformation, Utilities.Util.GetAppName)
                MsgBox("File(s) successfully exported to [" & filename & "].", vbInformation, Utilities.Util.GetAppName)
                REPORT_DETAIL.Output.Mode = ReportOutputMode.None
            Catch e As Exception
                MsgBox("Unable to create export file. " & e.Message, vbExclamation, Utilities.Util.GetAppName)
            End Try
        End If

    End Sub

    Sub closefile(ByRef file As System.IO.StreamWriter, sumEmpr As Double, sumEmpe As Double)
        file.WriteLine("99" & gmmesmspace(12, Format(sumEmpr, "###0.00"), 2) & _
                                  gmmesmspace(12, "0.00", 2) & _
                                  gmmesmspace(12, "0.00", 2) & _
                                  gmmesmspace(10, "0.00", 2) & _
                                  gmmesmspace(10, "0.00", 2) & _
                                  gmmesmspace(10, "0.00", 2) & _
                                  gmmesmspace(10, Format(sumEmpe, "###0.00"), 2) & _
                                  gmmesmspace(10, "0.00", 2) & _
                                  gmmesmspace(10, "0.00", 2)
                                 )

        file.Close()
    End Sub

    Private Sub SetDetailBand_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        'TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "FKeyPayID='" & MainReport.GetCurrentColumnValue("FKeyPayID").ToString & "'"
    End Sub

    Private Sub grpSBRNumFooter_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        'If MainReport.GetCurrentColumnValue("ReceiptNumber").ToString = "" Then
        TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & _
                                                                            "' and ReceiptNumber ='" & MainReport.GetCurrentColumnValue("ReceiptNumber").ToString & "'"

        'TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "ReceiptNumber ='" & MainReport.GetCurrentColumnValue("ReceiptNumber").ToString & "'"

        'Else
        ''    TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & "' "
        'MsgBox(TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString)
        'End If

        ' MainReport.txtNoOfEmployees.Text = "dsfas"
    End Sub

    Private Sub txtFileName_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim tempMin As Integer
        tempMin = Right(MainReport.txtFileName.Text, 2) + 1
        If tempMin = 61 Then
            tempMin = 0
        End If

        MainReport.txtFileName.Text = Left(MainReport.txtFileName.Text, Len(MainReport.txtFileName.Text) - 2) & Format(tempMin, "00")
    End Sub

    Private Sub rptSSSRemitCov_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        'MainReport.txtNoOfEmployees.Text = MainReport.txtSBRNo.Text
    End Sub
    Private Sub grpSBRNum_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        'Dim rowxxx() As DataRow
        'If MainReport.GetCurrentColumnValue("ReceiptNumber").ToString <> "" Then
        '    rowxxx = MainReport.DataSource.Select("RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & _
        '                                          "' and ReceiptNumber ='" & MainReport.GetCurrentColumnValue("ReceiptNumber").ToString & "'")
        'Else
        '    rowxxx = MainReport.DataSource.Select("RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & _
        '                                         "'")
        'End If

        ''MainReport.txtNoOfEmployees.Text = ""
        'MainReport.txtNoOfEmployees.Text = rowxxx.GetUpperBound(0) + 1
        'MainReport.txtNoOfEmployees.Text = MainReport.txtSBRNo.Text
    End Sub

    Private Sub grpRefNo_afterPrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        'Dim rowxxx() As DataRow
        'If MainReport.GetCurrentColumnValue("ReceiptNumber").ToString <> "" Then
        '    rowxxx = MainReport.DataSource.Select("RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & _
        '                                          "' and ReceiptNumber ='" & MainReport.GetCurrentColumnValue("ReceiptNumber").ToString & "'")
        'Else
        '    rowxxx = MainReport.DataSource.Select("RefNo='" & MainReport.GetCurrentColumnValue("RefNo").ToString & _
        '                                         "'")
        'End If


        ''MainReport.txtNoOfEmployees.Text = ""
        'MainReport.txtNoOfEmployees.Text = rowxxx.GetUpperBound(0) + 1
        'MainReport.txtNoOfEmployees.Text = MainReport.GetCurrentColumnValue("ReceiptNumber").ToString()
    End Sub

    'Private Sub grpSBRNumFooter_afterPrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
    '    MainReport.txtNoOfEmployees.Text = "444"
    'End Sub

    Function gmmesmspace(shdBDStrLength As Integer, Optional urString As String = "", Optional pos As Integer = 1) As String
        Dim ret As String

        If Len(urString) > shdBDStrLength Then
            ret = Left(urString, shdBDStrLength)
        Else
            If pos = 2 Then 'space left
                ret = Space(shdBDStrLength - Len(urString)) & urString
            ElseIf pos = 1 Then
                ret = urString & Space(shdBDStrLength - Len(urString))
            Else
                ret = ""
            End If
        End If
        Return ret
    End Function

    Function setAmtpaidstring(amt As String) As String
        Dim periodIndex As String, tempret As String, tempamt As String
        Dim lenresult As Integer = 9, amtlenWoutDecimal As Integer

        If IsNumeric(amt) Then
            tempamt = Replace(amt, ",", "")
            periodIndex = InStr(tempamt, ".")

            If periodIndex > 0 Then
                amtlenWoutDecimal = periodIndex - 1
                tempret = StrDup(9 - amtlenWoutDecimal, "0") & tempamt
            Else
                tempret = StrDup(9 - Len(tempamt), "0") & tempamt & ".00"
            End If
        Else
            tempret = "000000000.00"
        End If
        Return tempret
    End Function
End Class
