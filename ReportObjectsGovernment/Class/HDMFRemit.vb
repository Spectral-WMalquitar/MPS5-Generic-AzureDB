Imports Excel = Microsoft.Office.Interop.Excel

Public Class HDMFRemit
    'Public MainReport As New rptSSSRemitCov
    'Public SubRep As New rptSSSRemitCov_sub
    Private sqlConn As New SqlClient.SqlConnection

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        If REPORT_DETAIL.FilterOption.GetFilterValue("Period").ToString.Length = 0 Then
            MsgBox("Please select a Period to view.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, Utilities.Util.GetAppName)
            Exit Sub
        End If

        Dim Period As Integer = REPORT_DETAIL.FilterOption.GetFilterValue("Period")
        Dim VslCode As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim SBRNo As String = REPORT_DETAIL.FilterOption.GetFilterValue("TR / SBR Number")
        Dim AmtPaid As String = REPORT_DETAIL.FilterOption.GetFilterValue("Amount Paid")

        Dim dt As New DataTable ', dtearn As DataTable, dtDed As DataTable, dttotEarn As DataTable, dttotDed As DataTable
        'Dim dtNetSum As DataTable
        'Dim cSQL As String
        'Dim sumEmpe As Double, sumEmpr As Double
        'Dim filename As String, 
        'Dim reversePeriod As String

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

                sqlComm.CommandText = "SP_pay_hdmf_cover"
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
        'If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
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
        'companyHDMFno = MPSDB.GetConfig("HDMF")


        Try
            If REPORT_DETAIL.Output.Mode = ReportOutputMode.Export Then

                Dim xlApp As New Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet
                Dim exppath As String, expfname As String

                'https://siddharthrout.wordpress.com/vb-net-and-excel/
                '~~> Opens an exisiting Workbook. Change path and filename as applicable
                '20170504 xlWorkBook = xlApp.Workbooks.Open(MPSDB.GetConfig("TEMPLATE_PATH") & "\PAG-IBIG FORM.XLS")
                'edited by tony20170704 
                Dim TemplateFileName As String = IfNull(MPSDB.GetConfig("TEMPLATE_FOLDER"), "") & "\PAG-IBIG FORM.XLS"
                'xlWorkBook = xlApp.Workbooks.Open(IfNull(MPSDB.GetConfig("TEMPLATE_FOLDER"), "") & "\PAG-IBIG FORM.XLS")
                If Not My.Computer.FileSystem.FileExists(TemplateFileName) Then
                    MsgBox("The exporting process cannot proceed because the excel template cannot be found. Please consult your Administrator regarding the setup of templates.", MsgBoxStyle.Information, "Export Pagibig Monthly Contribution")
                    Exit Sub
                End If
                xlWorkBook = xlApp.Workbooks.Open(TemplateFileName)
                'end tony

                '~~> Display Excel
                'xlApp.Visible = True

                xlWorkSheet = xlWorkBook.Sheets("PAG-IBIG")

                With xlWorkSheet
                    '~~> Directly type the values that we want
                    .Range("B5").Value = MPSDB.GetConfig("NAME")
                    .Range("B7").Value = MPSDB.GetConfig("ADDR")
                    .Range("G9").Value = MPSDB.GetConfig("HDMF")

                    For r = 0 To dt.Rows.Count - 1
                        .Range("A" & r + 15).Value = dt(r)("hdmfID")  'pagibig id
                        .Range("C" & r + 15).Value = dt(r)("LName")  'lastname
                        .Range("D" & r + 15).Value = dt(r)("FName")  'firstname
                        .Range("E" & r + 15).Value = dt(r)("MName")  'middlename
                        .Range("F" & r + 15).Value = dt(r)("CAmtEmpe")  'empe contri
                        .Range("G" & r + 15).Value = dt(r)("CAmtEmpr")  'empr contri
                        .Range("I" & r + 15).Value = Format(dt(r)("DOB"), "yyyyMMdd")  'bday
                        .Range("H" & r + 15).Value = dt(r)("TINnum")  'TIN Number
                    Next

                End With

                exppath = MPSDB.GetConfig("EXPORT_PATH")
                'edited by tony20170704
                'expfname = exppath & "\HDMF_" & Format(Now, "MMddHHmmss") & ".xls"
                MsgBox("Select the location where the export file will be saved.", MsgBoxStyle.Information)
                expfname = SaveAsDialog("HDMF_" & Format(Now, "MMddHHmmss") & ".xls", "Excel Workbook (*.xls)|*.xls")
                'end tony

                xlWorkBook.SaveAs(Filename:=expfname, FileFormat:=56)

                '~~> Close the File
                xlWorkBook.Close()

                '~~> Quit the Excel Application
                xlApp.Quit()

                '~~> Clean Up
                releaseObject(xlApp)
                releaseObject(xlWorkBook)

                'edited by tony20170704 MsgBox("File " & expfname & " successfully created.", vbInformation, Utilities.Util.GetAppName)
                MsgBox("File(s) successfully exported to [" & expfname & "].", vbInformation, Utilities.Util.GetAppName)
                REPORT_DETAIL.Output.Mode = ReportOutputMode.None
            End If

        Catch e As Exception
            MsgBox("Error encountered while exporting records. " & e.Message, vbExclamation, Utilities.Util.GetAppName)
            Exit Sub
        End Try

    End Sub

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
