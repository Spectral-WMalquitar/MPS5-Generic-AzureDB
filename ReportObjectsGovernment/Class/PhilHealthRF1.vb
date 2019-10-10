Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Public Class PhilHealthRF1

    Dim DestFile As String = ""
    Dim DestPath As String = ""
    Dim ExcelFileName As String = ""

    Dim ProgressBar As MPS5ProgressBar

    Private MCode As Integer
    '    Private MCodeDesc As String
    '    Private ExRate As Double = 0

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Try
            ExportPhilHealthRF1(REPORT_DETAIL)
        Catch ex As Exception
            MsgBox("RF1 Export failed. Error: " & ex.Message, MsgBoxStyle.Critical, GetAppName() & " - Export Monthly RF1")
        End Try

    End Sub

    Private Sub ExportPhilHealthRF1(ByRef REPORT_DETAIL As ReportDetail)
        Dim dt As DataTable = Nothing
        '        Dim cSQL As String = ""
        '        Dim strExRate = REPORT_DETAIL.FilterOption.GetFilterValue("Php To USD Ex Rate", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False)

        If REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False) = "" Then
            MsgBox("Please select period.", MsgBoxStyle.OkOnly, GetAppName() & " - Export Monthly RF1")
            Exit Sub
        End If

        MCode = REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.EditValue, False)

        '        If IsNumeric(strExRate) Then
        '            ExRate = CDbl(strExRate)
        '        End If

        Dim cTemplateFile As String = ""
        cTemplateFile = IfNull(MPSDB.GetConfig("TEMPLATE_FOLDER"), "")
        cTemplateFile = cTemplateFile & IIf(Mid(IfNull(cTemplateFile, ""), IfNull(cTemplateFile, "").Length, 1) = "\", "", "\") & "MonthlyRF1_TEMPLATE.xls"
        'cTemplateFile = "E:\MonthlyRF1_TEMPLATE.xls"

        If Not System.IO.File.Exists(cTemplateFile) Then
            MsgBox("Cannot find Monthly RF1 Template file from the Templates folder.", MsgBoxStyle.Exclamation, GetAppName() & " - Export Monthly RF1")
            GoTo EXIT_SUB
            Exit Sub
        End If

        DestPath = Application.StartupPath & "\exports"
        If Not System.IO.Directory.Exists(DestPath) Then
            MkDir(DestPath)
        End If
        DestPath = DestPath & IIf(Mid(DestPath, DestPath.Length, 1) = "\", "", "\")
        DestFile = "MonthlyRF1_" & Format(NumCodeToDate(MCode, 1), "MMMyyyy")
        ExcelFileName = DestFile & ".xls"

        Dim isCopySuccess As Boolean = False

        Try
            If Not RemovesExistingFile() Then
                GoTo EXIT_SUB
            End If
            FileCopy(cTemplateFile, DestPath & ExcelFileName)
            isCopySuccess = True
        Catch ex As Exception
            isCopySuccess = False
        End Try

        If Not isCopySuccess Then
            'MsgBox("Failed to copy the template to MPS5 program directory. Please select another location where you want to save the file.", MsgBoxStyle.Information, GetAppName() & " - Export Monthly RF1")
            MsgBox("Please select a location where you want to save the export file.", MsgBoxStyle.Information, GetAppName() & " - Export Monthly RF1")

            Dim folderDialog As New FolderBrowserDialog
            Dim selectedNewFolder As String = ""

            While IfNull(selectedNewFolder, "").Length = 0
                If folderDialog.ShowDialog() = DialogResult.OK Then
                    selectedNewFolder = folderDialog.SelectedPath
                    If IfNull(selectedNewFolder, "").Length > 0 Then
                        DestPath = selectedNewFolder
                        DestPath = DestPath & IIf(Mid(DestPath, DestPath.Length, 1) = "\", "", "\")
                    End If
                Else
                    MsgBox("Folder selection canceled.", MsgBoxStyle.Information)
                    GoTo EXIT_SUB
                End If
            End While

            Try
                If Not RemovesExistingFile() Then
                    GoTo EXIT_SUB
                End If
                FileCopy(cTemplateFile, DestPath & ExcelFileName)
            Catch ex As Exception
                MsgBox("Export canceled. Unable to save a copy of the template to the selected path.", MsgBoxStyle.Information, GetAppName() & " - Export Monthly RF1")
                GoTo EXIT_SUB
            End Try
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE

        ShowCustomLoadScreen(GetType(MPS4.Waitform), "Building Data...")

        dt = GenerateReportDataSource(REPORT_DETAIL)

        CloseCustomLoadScreen()


        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then
            GoTo EXIT_SUB
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------

        Dim xl As clsExcelFunction

        'Dim xl As New clsExcelFunction(DestPath & ExcelFileName, "DATA")
        Try
            xl = New clsExcelFunction(DestPath & ExcelFileName, "DATA")
        Catch ex As Exception
            MsgBox("Invalid RF1 Template File format.", MsgBoxStyle.Exclamation, GetAppName() & " - Export Monthly RF1")
            GoTo EXIT_SUB
        End Try
        Dim rowCtr As Integer = 1

        ProgressBar = New MPS5ProgressBar(IfNull(dt.Rows.Count, 0) + 6, "Exporting RF1...")
        ProgressBar.Show()

        '<!-- HEADER -->
        xl.SetExcelValue("B1", MPSDB.GetConfig("NAME"))                             'EMPLOYER NAME
        xl.SetExcelValue("B2", MPSDB.GetConfig("ADDR"))                    'EMPLOYER ADDRESS
        xl.SetExcelValue("B3", MPSDB.GetConfig("MCRNBR"))                  'PEN
        xl.SetExcelValue("B4", MPSDB.GetConfig("PHONE"))                   'TEL #
        xl.SetExcelValue("E4", Format(NumCodeToDate(MCode, 1), "yyyy"))    'Year
        xl.SetExcelValue("E5", Month(NumCodeToDate(MCode, 1)))       'Month
        xl.SetExcelValue("E6", "R")                                        'Type of Report
        xl.SetExcelValue("E7", Format(getServerDateTime(), "M/dd/yyyy HH:mm"))       'Date Prepared
        xl.SetExcelValue("G1", MPSDB.GetConfig("SSSNBR"))                  'SSS Number
        xl.SetExcelValue("G2", MPSDB.GetConfig("TAXNBR"))                  'SSS Number
        'xl.xlWS.Range("B1").Value = MPSDB.GetConfig("NAME")                         'EMPLOYER NAME
        'xl.xlWS.Range("B2").Value = MPSDB.GetConfig("ADDR")                         'EMPLOYER ADDRESS
        'xl.xlWS.Range("B3").Value = MPSDB.GetConfig("MCRNBR")                       'PEN
        'xl.xlWS.Range("B4").Value = MPSDB.GetConfig("PHONE")                        'TEL #
        'xl.xlWS.Range("E4").Value = Format(NumCodeToDate(MCode, 1), "yyyy")         'Year
        'xl.xlWS.Range("E5").Value = Format(NumCodeToDate(MCode, 1), "M")            'Month
        'xl.xlWS.Range("E6").Value = "R"                                             'Type of Report
        'xl.xlWS.Range("E7").Value = Format(getServerDateTime(), "M/dd/yyyy hh:nn")  'Type of Report
        'xl.xlWS.Range("G1").Value = MPSDB.GetConfig("SSSNBR")                       'SSS Number
        'xl.xlWS.Range("G2").Value = MPSDB.GetConfig("TAXNBR")                       'TAX Number


        rowCtr = 9
        progressbar.Update()

        '<!-- DETAILS -->
        For Each row As DataRow In dt.Rows
            xl.SetExcelValue("B" & rowCtr, row("LName"))                            'Last Name
            xl.SetExcelValue("D" & rowCtr, row("FName"))                            'First Name
            xl.SetExcelValue("E" & rowCtr, row("MName"))                            'Middle Name
            xl.SetExcelValue("F" & rowCtr, row("MCRNo"))                            'Philhealth No
            xl.SetExcelValue("G" & rowCtr, row("DOB"))                              'Date of Birth
            If IsNumeric(row("SexCode")) Then
                If row("SexCode").Equals(1) Then
                    xl.SetExcelValue("H" & rowCtr, "M")                             'Sex
                Else
                    xl.SetExcelValue("H" & rowCtr, "F")                             'Sex
                End If
            End If

            If IfNull(row("BasicAmtUSD"), 0) > 0 Then
                xl.SetExcelValue("I" & rowCtr, row("BasicAmtUSD"))                  'Salary
            Else
                xl.SetExcelValue("BS" & rowCtr, "NE")                               'Remarks
            End If

            If IfNull(row("DateSOn"), "").Length > 0 Then
                If IsDate(row("DateSOn")) Then
                    xl.SetExcelValue("BT" & rowCtr, row("DateSOn"))                 'Date
                End If
            End If

            rowCtr = rowCtr + 1
            progressbar.Update()
        Next

        'xl.DisplayAlerts = False
        xl.xlApp.DisplayAlerts = False
        xl.xlWB.Worksheets("DATA").Select()
        Application.DoEvents()
        ProgressBar.Status = "Saving as DATA.prn..."
        ProgressBar.Update()
        Application.DoEvents()
        xl.xlWB.SaveAs(Filename:=DestPath & DestFile & "_DATA", FileFormat:=36)  '36 space delimited
        xl.xlWB.Worksheets("TXT").Select()
        ProgressBar.Update()
        Application.DoEvents()
        ProgressBar.Status = "Saving as TXT.prn..."
        Application.DoEvents()
        xl.xlWB.SaveAs(Filename:=DestPath & DestFile & "_TXT", FileFormat:=36)
        Application.DoEvents()
        xl.xlWB.Worksheets(1).select()
        ProgressBar.Status = "Saving RF1 Export File..."
        ProgressBar.Update()
        Application.DoEvents()
        xl.xlWB.SaveAs(Filename:=DestPath & ExcelFileName, FileFormat:=-4143)
        'xl.xlWB.Save()
        xl.CloseExcelFile()

        xl = New clsExcelFunction(DestPath & ExcelFileName, DestFile & "_DATA")
        xl.xlWB.Worksheets(1).name = "DATA"
        xl.xlWB.Worksheets(2).name = "TXT"
        ProgressBar.Status = "Finalizing exported RF1..."
        ProgressBar.Update()
        Application.DoEvents()
        xl.xlWB.Save()
        xl.CloseExcelFile()
        ProgressBar.Update()
        Application.DoEvents()

        progressbar.Finish()

        REPORT_DETAIL.Output.Mode = ReportOutputMode.None

        Dim ans
        ans = MsgBox("Export successful. " & vbNewLine & vbNewLine & _
                     "The ff. files are created on [" & DestPath & "]:" & vbNewLine & _
                     vbTab & DestFile & "_DATA.PRN" & vbNewLine & _
                     vbTab & DestFile & "_TXT.PRN" & vbNewLine & _
                     vbTab & DestFile & ".xls" & vbNewLine & vbNewLine & _
               "Would you like to view the excel file?", vbInformation + vbYesNo, GetAppName() & " - Export Monthly RF1")

        'DestPath & DestFile & "_DATA.PRN" & vbNewLine & _
        '             DestPath & DestFile & "_TXT.PRN" & vbNewLine & _
        '             DestPath & DestFile & ".xls" & vbNewLine & vbNewLine & _
        '       "Would you like to view the excel file?", vbInformation + vbYesNo, GetAppName() & " - Export Monthly RF1")
        If ans = vbYes Then
            Process.Start(DestPath & ExcelFileName)
        End If

EXIT_SUB:
        If Not IsNothing(ProgressBar) Then ProgressBar.Finish(False)
    End Sub

    Private Function RemovesExistingFile() As Boolean
        Dim ReturnValue As Boolean = True
        Dim files As New ArrayList
        files.Add(DestPath & ExcelFileName)
        files.Add(DestPath & DestFile & "_DATA.PRN")
        files.Add(DestPath & DestFile & "_TXT.PRN")

        For i As Integer = 0 To files.Count - 1
            If IsFileOpen(files(i)) Then
                MsgBox("Unable to start the export because a same file [" & DestFile & "] is open.", MsgBoxStyle.Critical, GetAppName() & " - Export Monthly RF1")
                Return False
            End If
            
        Next

        For i As Integer = 0 To files.Count - 1
            If File.Exists(files(i)) Then
                Kill(files(i))
            End If
        Next


        Return True
    End Function

#Region "Generate Data Source"
    Private Function GenerateReportDataSource(ByRef REPORT_DETAIL As Reports.ReportDetail) As DataTable
        Dim ReturnValue As DataTable = Nothing
        Dim sqlConn As New SqlClient.SqlConnection

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                MsgBox("Failed to build report data source." & vbNewLine & "Error: " & ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                MsgBox("Failed to build report data source.", MsgBoxStyle.Critical)
                Return Nothing
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "RPT_GenerateMonthlyRF1"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.CommandTimeout = 1000

                sqlComm.Parameters.AddWithValue("Period", MCode)
                sqlComm.Parameters.AddWithValue("PrintSelection", REPORT_DETAIL.PresentRecord.Table)

                da.SelectCommand = sqlComm

                Try
                    Dim dt As New DataTable
                    da.Fill(dt)

                    ReturnValue = dt

                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    Dim returnErr As String = ""
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next

                    MsgBox("Failed to build report data source." & vbNewLine & "Error: " & returnErr, MsgBoxStyle.Critical)
                    Return Nothing
                End Try

            End If
            sqlConn.Close()
        End Using
        Return ReturnValue

        Exit Function
    End Function

#End Region

    '    Private Function GetNumbersOnly(strval As String) As String
    '        Dim ReturnValue As String = ""

    '        Try
    '            Dim myChars() As Char = strval.ToCharArray()
    '            For Each ch As Char In myChars
    '                If Char.IsDigit(ch) Then
    '                    ReturnValue = ReturnValue & ch.ToString
    '                End If
    '            Next
    '        Catch ex As Exception
    '            ReturnValue = ""
    '        End Try


    '        Return ReturnValue
    '    End Function

    'Private Sub IsFileOpen(ByVal fileName As String)
    '    Dim file As FileInfo
    '    Dim stream As FileStream = Nothing


    '    Try
    '        stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
    '        stream.Close()
    '    Catch ex As Exception

    '        If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
    '            ' do something here, either close the file if you have a handle, show a msgbox, retry  or as a last resort terminate the process - which could cause corruption and lose data
    '        End If
    '    End Try
    'End Sub

    'Private Sub IsFileOpen(ByVal file As FileInfo)
    '    Dim stream As FileStream = Nothing
    '    Try
    '        stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
    '        stream.Close()
    '    Catch ex As Exception

    '        If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
    '            ' do something here, either close the file if you have a handle, show a msgbox, retry  or as a last resort terminate the process - which could cause corruption and lose data
    '        End If
    '    End Try
    'End Sub

    'Private Shared Function IsFileLocked(exception As Exception) As Boolean
    '    Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
    '    Return errorCode = 32 OrElse errorCode = 33
    'End Function

    Private Function IsFileOpen(cFileName As String) As Boolean
        Dim ReturnValue As Boolean = False
        Try
            If File.Exists(cFileName) Then
                Dim fOpen As FileStream = File.Open(cFileName, FileMode.Open, FileAccess.Read, FileShare.None)
                fOpen.Close()
                fOpen.Dispose()
                fOpen = Nothing
            End If

        Catch e1 As IOException
            'File Open by some one else..
            ReturnValue = True
        Catch e2 As Exception
        End Try

        Return ReturnValue
    End Function
End Class

