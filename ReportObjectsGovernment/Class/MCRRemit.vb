Imports Excel = Microsoft.Office.Interop.Excel

Public Class MCRRemit
    'Public MainReport As New rptSSSRemitCov
    'Public SubRep As New rptSSSRemitCov_sub
    Private sqlConn As New SqlClient.SqlConnection
    Dim Period As Integer
    Dim VslCode As String
    Dim SBRNo As String
    Dim AmtPaid As String
    Dim exppath As String, expfname As String

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)

        Dim filewereCreated As Boolean = False

        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString.Length = 0 Then
            MsgBox("Please select a Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
            Exit Sub
        End If

        Period = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        VslCode = REPORT_DETAIL.PresentRecord.SelectionList
        SBRNo = REPORT_DETAIL.FilterOption.GetFilterValue("TR / SBR Number")
        AmtPaid = REPORT_DETAIL.FilterOption.GetFilterValue("Amount Paid")
        'Dim DatePaid As Date

        'DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(WaitForm1))

        Dim dt As New DataTable ', dtearn As DataTable, dtDed As DataTable, dttotEarn As DataTable, dttotDed As DataTable
        'Dim dtNetSum As DataTable
        'Dim cSQL As String
        'Dim sumEmpe As Double, sumEmpr As Double
        'Dim filename As String, 
        'Dim reversePeriod As String
        'Dim companyMCRno As String

        Dim finalstr As String = "" ', periodfr As String ', periodto As String
        Dim kwitan As Boolean = False

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

                sqlComm.CommandText = "SP_pay_mcr_cover"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("Period", Period)
                sqlComm.Parameters.AddWithValue("vslcode", VslCode)
                'sqlComm.Parameters.Add("sumamte", SqlDbType.Money)
                'sqlComm.Parameters("sumamte").Direction = ParameterDirection.Output
                'sqlComm.Parameters.Add("sumamtr", SqlDbType.Money)
                'sqlComm.Parameters("sumamtr").Direction = ParameterDirection.Output


                Try
                    Dim ds As New DataSet
                    'sqlComm.ExecuteNonQuery()
                    da.SelectCommand = sqlComm
                    da.Fill(dt)
                    'MsgBox(sqlComm.Parameters("sumamte").Value)
                    'MsgBox(sqlComm.Parameters("sumamtr").Value)
                    'MsgBox(dt.Rows(0)(0))
                    'sumEmpe = sqlComm.Parameters("sumamte").Value
                    'sumEmpr = sqlComm.Parameters("sumamtr").Value
                    'returnKo = ""
                Catch SqlEx As SqlClient.SqlException
                    MsgBox("Error encountered while pulling records.", vbExclamation, Utilities.Util.GetAppName)
                    Exit Sub
                End Try

            End If

            sqlConn.Close()
        End Using

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
        ' MainReport.TxtCompany.Text = MPSDB.GetConfig("NAME")
        'companyMCRno = MPSDB.GetConfig("MCRNBR")

        Try
            If REPORT_DETAIL.Output.Mode = ReportOutputMode.Export Then
                'added by tony20170704 
                Dim TemplateFileName As String = IfNull(MPSDB.GetConfig("TEMPLATE_FOLDER"), "") & "\PHILHEALTH FORM.xls"
                If Not My.Computer.FileSystem.FileExists(TemplateFileName) Then
                    MsgBox("The exporting process cannot proceed because the excel template cannot be found. Please consult your Administrator regarding the setup of templates.", MsgBoxStyle.Information, "Export Pagibig Monthly Contribution")
                    Exit Sub
                End If
                'end tony

                Dim dt2() As DataRow
                For r = 0 To dt.Rows.Count - 1
                    If r = dt.Rows.Count - 1 Then
                        'If (dt(r)("ReceiptNumber") <> dt(r - 1)("ReceiptNumber")) Or _
                        '   (dt(r)("RefNo") <> dt(r - 1)("RefNo")) Then
                        dt2 = dt.Select("ReceiptNumber='" & dt(r)("ReceiptNumber") & "' and Refno='" & dt(r)("RefNo") & "'", "Refno", DataViewRowState.CurrentRows)
                        'dt2 = dt.Select("ReceiptNumber='' and Refno=''", "Refno", DataViewRowState.CurrentRows)
                        If exporttoexcel(dt2) Then
                            filewereCreated = True
                        End If
                        'End If
                    Else
                        If (dt(r)("ReceiptNumber") <> dt(r + 1)("ReceiptNumber")) Or _
                            (dt(r)("RefNo") <> dt(r + 1)("RefNo")) Then
                            dt2 = dt.Select("ReceiptNumber='" & dt(r)("ReceiptNumber") & "' and Refno='" & dt(r)("RefNo") & "'", "Refno", DataViewRowState.CurrentRows)
                            If exporttoexcel(dt2) Then
                                filewereCreated = True
                            End If
                        End If
                    End If
                Next

                If filewereCreated Then
                    'edited by tony20170704 MsgBox("File(s) successfully created in " & exppath & ".", vbInformation, Utilities.Util.GetAppName)
                    MsgBox("File(s) successfully exported to [" & expfname & "].", vbInformation, Utilities.Util.GetAppName)
                Else
                    MsgBox("No Data(s) for export.", vbInformation, Utilities.Util.GetAppName)
                End If

                REPORT_DETAIL.Output.Mode = ReportOutputMode.None

                '    Dim xlApp As New Excel.Application
                '    Dim xlWorkBook As Excel.Workbook
                '    Dim xlWorkSheet As Excel.Worksheet
                '    Dim exppath As String, expfname As String

                '    '~~> Opens an exisiting Workbook. Change path and filename as applicable
                '    xlWorkBook = xlApp.Workbooks.Open(MPSDB.GetConfig("TEMPLATE_PATH") & "\PHILHEALTH FORM.xls")

                '    '~~> Display Excel
                '    'xlApp.Visible = True

                '    xlWorkSheet = xlWorkBook.Sheets("DATA")

                '    With xlWorkSheet
                '        '~~> Directly type the values that we want
                '        .Range("B3").Value = MPSDB.GetConfig("NAME")    'coy name
                '        .Range("B4").Value = MPSDB.GetConfig("ADDR")    'add
                '        .Range("B6").Value = MPSDB.GetConfig("PHONE")    '
                '        .Range("F4").Value = MPSDB.GetConfig("SSSNBR")    '
                '        .Range("E6").Value = Left(Period, 4)    'year
                '        .Range("E7").Value = Convert.ToInt32(Right(Period, 2))    'month
                '        .Range("AX4").Value = dt(0)("ReceiptNumber")  '
                '        .Range("AX5").Value = dt(0)("CertAmtPaid")  '
                '        .Range("AX6").Value = dt(0)("Datepaid")  '

                '        For r = 0 To dt.Rows.Count - 1
                '            .Range("F" & r + 10).Value = dt(r)("MCRID")  'mcr id
                '            .Range("B" & r + 10).Value = dt(r)("LName")  'lastname
                '            .Range("D" & r + 10).Value = dt(r)("FName")  'firstname
                '            .Range("E" & r + 10).Value = dt(r)("MName")  'middlename
                '            .Range("AM" & r + 10).Value = dt(r)("CAmtEmpe")  'empe contri
                '            .Range("AN" & r + 10).Value = dt(r)("CAmtEmpr")  'empr contri
                '            .Range("G" & r + 10).Value = dt(r)("amtbasic")  'salary
                '            '.Range("I" & r + 10).Value = Format(dt(r)("DOB"), "yyyyMMdd")  'bday
                '        Next

                '    End With

                '    exppath = MPSDB.GetConfig("EXPORT_PATH")
                '    expfname = exppath & "\MCR_" & Format(Now, "MMddHHmmss") & ".xls"

                '    xlWorkBook.SaveAs(Filename:=expfname, FileFormat:=56)

                '    '~~> Close the File
                '    xlWorkBook.Close()

                '    '~~> Quit the Excel Application
                '    xlApp.Quit()

                '    '~~> Clean Up
                '    releaseObject(xlApp)
                '    releaseObject(xlWorkBook)

                '    MsgBox("File " & expfname & " successfully created.", vbInformation, Utilities.Util.GetAppName)
                'End If

            End If
        Catch e As Exception
            MsgBox("Error encountered while exporting records." & e.Message, vbExclamation, Utilities.Util.GetAppName)
            Exit Sub
        End Try
    End Sub

    Function exporttoexcel(dtrow() As DataRow) As Boolean
        Dim ret As Boolean = False
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        If dtrow.Count = 0 Then
            Return ret
        End If

        '~~> Opens an exisiting Workbook. Change path and filename as applicable
        '20170503 xlWorkBook = xlApp.Workbooks.Open(MPSDB.GetConfig("TEMPLATE_PATH") & "\PHILHEALTH FORM.xls")
        xlWorkBook = xlApp.Workbooks.Open(IfNull(MPSDB.GetConfig("TEMPLATE_FOLDER"), "") & "\PHILHEALTH FORM.xls")
        MsgBox("Select the location where the export file will be saved.", MsgBoxStyle.Information)
        expfname = SaveAsDialog("MCR_" & Format(Now, "MMddHHmmss") & ".xls", "Excel Workbook (*.xls)|*.xls")
        'expfname = exppath & "\MCR_" & Format(Now, "MMddHHmmss") & ".xls"

        '~~> Display Excel
        'xlApp.Visible = True

        xlWorkSheet = xlWorkBook.Sheets("DATA")

        With xlWorkSheet
            '~~> Directly type the values that we want
            .Range("B3").Value = MPSDB.GetConfig("NAME")    'coy name
            .Range("B4").Value = MPSDB.GetConfig("ADDR")    'add
            .Range("B6").Value = MPSDB.GetConfig("PHONE")    '
            .Range("F4").Value = MPSDB.GetConfig("SSSNBR")    '
            .Range("E6").Value = Left(Period, 4)    'year
            .Range("E7").Value = Convert.ToInt32(Right(Period, 2))    'month
            .Range("AX4").Value = dtrow(0)("ReceiptNumber")  '
            .Range("AX5").Value = dtrow(0)("CertAmtPaid")  '
            .Range("AX6").Value = dtrow(0)("Datepaid")  '

            For r = 0 To dtrow.Count - 1
                .Range("F" & r + 10).Value = dtrow(r)("MCRID")  'mcr id
                .Range("B" & r + 10).Value = dtrow(r)("LName")  'lastname
                .Range("D" & r + 10).Value = dtrow(r)("FName")  'firstname
                .Range("E" & r + 10).Value = dtrow(r)("MName")  'middlename
                .Range("AM" & r + 10).Value = dtrow(r)("CAmtEmpe")  'empe contri
                .Range("AN" & r + 10).Value = dtrow(r)("CAmtEmpr")  'empr contri
                .Range("G" & r + 10).Value = dtrow(r)("amtbasic")  'salary
                '.Range("I" & r + 10).Value = Format(dtrow(r)("DOB"), "yyyyMMdd")  'bday
            Next

        End With

        exppath = MPSDB.GetConfig("EXPORT_PATH")
        'removed by tony20170704 expfname = exppath & "\MCR_" & Format(Now, "MMddHHmmss") & ".xls"

        xlWorkBook.SaveAs(Filename:=expfname, FileFormat:=56)


        '~~> Close the File
        xlWorkBook.Close()

        '~~> Quit the Excel Application
        xlApp.Quit()

        '~~> Clean Up
        releaseObject(xlApp)
        releaseObject(xlWorkBook)

        'MsgBox("File " & expfname & " successfully created.", vbInformation, Utilities.Util.GetAppName)

        Return True
    End Function

    '~~> Release the objects
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class
