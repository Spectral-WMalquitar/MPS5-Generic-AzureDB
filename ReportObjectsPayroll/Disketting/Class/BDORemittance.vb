Imports Utilities
Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Text

Public Class BDORemittance

    Public MainReport As New rptBDORemittance

    Dim _config As New Config("Code IN (" & _
                              "'" & BDO.BDOInfoFields.TieUpCode & "', " & _
                              "'" & BDO.BDOInfoFields.BatchNo & "', " & _
                              "'" & BDO.BDOInfoFields.LocatorCode & "')")

    Dim BDOExportFieldsList As List(Of String)

    Private Const MonthAlphabet As String = "ABCDEFGHIJKL"
    Private Shared BDOFile As BDOFileClass

#Region "Classes"
    Private Class BDOFileClass
        Public TieUpCode As String = ""
        Public LocatorCode As String = ""
        Public BatchNo As String = ""
        Public FileName As String = ""
        Public Path As String = ""
        Public Password As String = ""

        'Public ExportFile As String = ""
        'Public ZipFile As String = ""
        'Public SumFile As String = ""
        'Public RptFile As String = ""
        'Public XlsFile As String = ""

        Public ReadOnly Property ExportFile(Optional ConcatenatePath As Boolean = False)
            Get
                Return IIf(ConcatenatePath, Path, "") & FileName & ".txt"
            End Get
        End Property

        Public ReadOnly Property ZipFile(Optional ConcatenatePath As Boolean = False)
            Get
                Return IIf(ConcatenatePath, Path, "") & FileName & "." & LocatorCode
            End Get
        End Property

        Public ReadOnly Property SumFile(Optional ConcatenatePath As Boolean = False)
            Get
                Return IIf(ConcatenatePath, Path, "") & FileName & "." & LocatorCode & ".SUM"
            End Get
        End Property

        Public ReadOnly Property RptFile(Optional ConcatenatePath As Boolean = False)
            Get
                Return IIf(ConcatenatePath, Path, "") & FileName & ".Rpt"
            End Get
        End Property

        Public ReadOnly Property XlsFile(Optional ConcatenatePath As Boolean = False)
            Get
                Return IIf(ConcatenatePath, Path, "") & FileName & ".xls"
            End Get
        End Property


        Public Function CheckIfFileExists(cOutputPath As String, Optional ShowMessage As Boolean = True) As Boolean
            Dim _result As New StringBuilder

            If Right(cOutputPath, 1) <> "\" Then cOutputPath = cOutputPath & "\"

            'Export File
            If My.Computer.FileSystem.FileExists(cOutputPath & ExportFile) Then
                If _result.Length > 0 Then _result.Append(vbNewLine)
                _result.Append("- " & ExportFile)
            End If

            'Zip Code
            If My.Computer.FileSystem.FileExists(cOutputPath & ZipFile) Then
                If _result.Length > 0 Then _result.Append(vbNewLine)
                _result.Append("- " & ZipFile)
            End If

            'Sum File
            If My.Computer.FileSystem.FileExists(cOutputPath & SumFile) Then
                If _result.Length > 0 Then _result.Append(vbNewLine)
                _result.Append("- " & SumFile)
            End If

            'Xls File
            If My.Computer.FileSystem.FileExists(cOutputPath & XlsFile) Then
                If _result.Length > 0 Then _result.Append(vbNewLine)
                _result.Append("- " & XlsFile)
            End If

            'Rpt File
            If My.Computer.FileSystem.FileExists(cOutputPath & RptFile) Then
                If _result.Length > 0 Then _result.Append(vbNewLine)
                _result.Append("- " & RptFile)
            End If

            If _result.Length > 0 Then
                If ShowMessage Then
                    MsgBox("Cannot proceed with export. The following BDO files already exists in the specified folder [" & cOutputPath & "]:" & vbNewLine & vbNewLine & _
                           _result.ToString, MsgBoxStyle.Exclamation)
                End If
                Return True
            Else
                Return False
            End If
        End Function
    End Class
#End Region

#Region "Main Report"
    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        'Dim dt As DataTable
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE MANDATORY REFERENCE FIELDS
        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Period"), "").Equals("") Then
            If REPORT_DETAIL.ShowMsgBox Then MsgBox("Please enter the Period.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Ref. No."), "").Equals("") Then
            If REPORT_DETAIL.ShowMsgBox Then MsgBox("Please enter a Ref. No.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Transaction Date"), "").Equals("") Then
            If REPORT_DETAIL.ShowMsgBox Then MsgBox("Please enter the Transaction Date", MsgBoxStyle.Information)
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        Dim sp As StoredProcedureCommand = CreateSP(REPORT_DETAIL)
        'dt = sp.Execute(StoredProcedureCommand.ReturnType.Table, REPORT_DETAIL.ShowMsgBox)

        Dim ds As New DataSet
        ds = sp.Execute(StoredProcedureCommand.ReturnType.DataSet, REPORT_DETAIL.ShowMsgBox)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        'If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        If Not validateReportDataSource(ds.Tables(0), REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------
        'MainReport.DataSource = dt
        MainReport.DataSource = ds.Tables(0)
        MainReport.Name = REPORT_DETAIL.ReportObjectID
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        MainReport.celCompany.Text = MPSDB.GetConfig("Name")
        MainReport.celMoYr.Text = "for the month of: " & Format(NumCodeToDate(REPORT_DETAIL.FilterOption.GetFilterValue("Period"), 1), "MMM-yyyy")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celCrewName, "Text", Nothing, "SenderName")
        BindData(MainReport.celAllotteeName, "Text", Nothing, "ReceiverName")
        BindData(MainReport.celAllotteeDOB, "Text", Nothing, "ReceiverDOB")
        BindData(MainReport.celReceiverAddr, "Text", Nothing, "ReceiverAddr1")
        BindData(MainReport.celReceiverAddr, "Text", Nothing, "ReceiverAddr1")
        BindData(MainReport.celAllotBank, "Text", Nothing, "ReceiverPhone")
        BindData(MainReport.celAllotBank, "Text", Nothing, "AllotBank")
        BindData(MainReport.celAcctNo, "Text", Nothing, "AcctNo")
        BindData(MainReport.celLandedCurrency, "Text", Nothing, "LandedCurrency")
        BindData(MainReport.celLandedAmount, "Text", Nothing, "LandedAmount")
        BindData(MainReport.celValidation, "Text", Nothing, "Validation")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader_Vsl, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------

        If REPORT_DETAIL.Output.Mode = ReportOutputMode.Export Then
            CreateBDOExportFile(ds)

            REPORT_DETAIL.Output.Mode = ReportOutputMode.None   'set to none so it won't generate an output from the reportselection form
        End If
    End Sub
#End Region

#Region "Exporting"
    Sub InitBDOExportFieldsList()
        BDOExportFieldsList = New List(Of String)

        With BDOExportFieldsList
            .Add(BDO.BDOExportFields.ReferenceNo)
            .Add(BDO.BDOExportFields.TranDate)
            .Add(BDO.BDOExportFields.SenderName)
            .Add(BDO.BDOExportFields.SenderAddr1)
            .Add(BDO.BDOExportFields.SenderAddr2)
            .Add(BDO.BDOExportFields.SenderPhone)
            .Add(BDO.BDOExportFields.ReceiverName)
            .Add(BDO.BDOExportFields.ReceiverAddr1)
            .Add(BDO.BDOExportFields.ReceiverAddr2)
            .Add(BDO.BDOExportFields.ReceiverPhone)
            .Add(BDO.BDOExportFields.ReceiverGender)
            .Add(BDO.BDOExportFields.ReceiverDOB)
            .Add(BDO.BDOExportFields.TransactionType)
            .Add(BDO.BDOExportFields.PayableCode)
            .Add(BDO.BDOExportFields.BankCode)
            .Add(BDO.BDOExportFields.BranchName)
            .Add(BDO.BDOExportFields.AcctNo)
            .Add(BDO.BDOExportFields.LandedCurrency)
            .Add(BDO.BDOExportFields.LandedAmount)
            .Add(BDO.BDOExportFields.InstructionToBDO)
            .Add(BDO.BDOExportFields.InstructionToJbee)
        End With
    End Sub

    Private Function CreateSP(REPORT_DETAIL As ReportDetail) As StoredProcedureCommand
        Dim sp As New StoredProcedureCommand("BDO_GenerateData")
        With sp.Parameters
            .Add(New StoredProcedureCommand.SPParameter("PrintSelection", REPORT_DETAIL.PresentRecord.Table))
            .Add(New StoredProcedureCommand.SPParameter("RefNo", REPORT_DETAIL.FilterOption.GetFilterValue("Ref. No.")))
            .Add(New StoredProcedureCommand.SPParameter("TransDate", REPORT_DETAIL.FilterOption.GetFilterValue("Transaction Date")))
            .Add(New StoredProcedureCommand.SPParameter("MCode", REPORT_DETAIL.FilterOption.GetFilterValue("Period")))
            If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Agent"), "").Equals("") Then
                .Add(New StoredProcedureCommand.SPParameter("AgentCode", System.DBNull.Value))
            Else
                .Add(New StoredProcedureCommand.SPParameter("AgentCode", REPORT_DETAIL.FilterOption.GetFilterValue("Agent")))
            End If

            If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Principal"), "").Equals("") Then
                .Add(New StoredProcedureCommand.SPParameter("PrinCode", System.DBNull.Value))
            Else
                .Add(New StoredProcedureCommand.SPParameter("PrinCode", REPORT_DETAIL.FilterOption.GetFilterValue("Principal")))
            End If

            If IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Fleet"), "").Equals("") Then
                .Add(New StoredProcedureCommand.SPParameter("FltCode", System.DBNull.Value))
            Else
                .Add(New StoredProcedureCommand.SPParameter("FltCode", REPORT_DETAIL.FilterOption.GetFilterValue("Fleet")))
            End If
        End With

        Return sp
    End Function


    Sub CreateBDOExportFile(ds As DataSet)
        Dim cOutputFile As String = ""   '"C:\Users\Owner\Documents\test2.txt"
        Dim cOutputPath As String
        Dim sw As StreamWriter

        If ds.Tables.Count <> 3 Then
            LogErrors("BDO Remittance System (Export) - Report Dataset has incorrect number of expected tables")
            MsgBox("Unable to proceed with export. Report has invalid data. Please consult your system administrator for assistance.", MsgBoxStyle.Exclamation, "BDO Remittance System (Export)")
            Exit Sub
        End If

        'ASSIGN DATASET TABLES TO SPECIFIC DATA TABLES
        Dim detailsDT As DataTable '= ds.Tables(0)
        Dim sumDT As DataTable '= ds.Tables(1)
        Dim dv As DataView = New DataView(ds.Tables(0))

        dv.RowFilter = "Valid <> 0"
        detailsDT = dv.ToTable
        
        If detailsDT.Rows.Count = 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox("No data to export. Data has been generated but there are no valid entries to export." & vbNewLine & vbNewLine & "Click View Report to review the data generated for this export.", MsgBoxStyle.Information)
            Else
                MsgBox("No data to export.", MsgBoxStyle.Information)
            End If
            Exit Sub
        End If

        If Not Validate() Then Exit Sub

        'get password and export path
        Dim f As New frmBDOParam
        f.txtPassword.Focus()
        f.ShowDialog()
        If f.Canceled Then Exit Sub
        cOutputPath = f._ExportPath
        If Right(cOutputPath, 1) <> "\" Then cOutputPath = cOutputPath & "\"


        BDOFile = New BDOFileClass
        BDOFile.Path = cOutputPath
        BDOFile.Password = f._Password

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Update FileName
        GenerateBDOFileName()
        If BDOFile.CheckIfFileExists(cOutputPath) Then Exit Sub
        '---------------------------------------------------------

        cOutputFile = BDOFile.ExportFile(True)

        sw = New StreamWriter(cOutputFile)
        Dim lineEntry As StringBuilder

        InitBDOExportFieldsList()

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Write details export file
        For i As Integer = 0 To detailsDT.Rows.Count - 1
            lineEntry = New System.Text.StringBuilder

            For Each fld As String In BDOExportFieldsList
                lineEntry.Append("""" & detailsDT.Rows(i)(fld) & """")
                lineEntry.Append(", ")
            Next

            sw.WriteLine(lineEntry.ToString)
        Next


        sw.Close()

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Write sum export file
        sumDT = ds.Tables(1)
        cOutputFile = BDOFile.SumFile(True)
        sw = New StreamWriter(cOutputFile)
        sw.WriteLine("TIEUPCODE=" & BDOFile.TieUpCode)
        sw.WriteLine("TIEUPBATCHID=" & BDOFile.FileName)
        If sumDT.Rows.Count > 0 Then
            sw.WriteLine("TOTALPHP=" & sumDT.Rows(0)("PHPLandedAmount"))
            sw.WriteLine("TOTALUSD=" & sumDT.Rows(0)("USDLandedAmount"))
            sw.WriteLine("PHPCOUNT=" & sumDT.Rows(0)("PHPRecCount"))
            sw.WriteLine("USDCOUNT=" & sumDT.Rows(0)("USDRecCount"))
        Else
            sw.WriteLine("TOTALPHP=")
            sw.WriteLine("TOTALUSD=")
            sw.WriteLine("PHPCOUNT=")
            sw.WriteLine("USDCOUNT=")
        End If

        sw.Close()

        Dim bSuccess As Boolean = BDO7Zip(BDOFile.ExportFile(True), BDOFile.ZipFile(True), BDOFile.Password)

        If Not bSuccess Then
            Rollback(BDOFile)
            Exit Sub
        End If

        If Not My.Computer.FileSystem.FileExists(BDOFile.ZipFile(True)) Then GoTo EXPORT_FAILED
        If Not My.Computer.FileSystem.FileExists(BDOFile.SumFile(True)) Then GoTo EXPORT_FAILED
        If Not My.Computer.FileSystem.FileExists(BDOFile.ExportFile(True)) Then GoTo EXPORT_FAILED

        Dim dtPayLog As DataTable = ds.Tables(2)
        For Each r As DataRow In dtPayLog.Rows
            MPSDB.SavePayrollLog(r("PayID"), _
                                 r("MCode"), _
                                 r("PayRefNo"), _
                                 r("PayType"), _
                                 r("PrincipalName"), _
                                 r("VslName"), _
                                 USER_ID, DateTime.Now,
                                 LockType.BDOBankExport, _
                                 My.Computer.Name, "")
        Next
        

        MsgBox("Successfully exported BDO Files to [" & BDOFile.Path & "]:" & _
                vbNewLine & "   - " & BDOFile.ZipFile & _
                vbNewLine & "   - " & BDOFile.SumFile & _
                vbNewLine & "   - " & BDOFile.ExportFile, _
                MsgBoxStyle.Information)
        Exit Sub

EXPORT_FAILED:
        Rollback(BDOFile)
        MsgBox("Export file generate failed.", MsgBoxStyle.Exclamation)

    End Sub

    Sub GenerateBDOFileName()
        Dim filename As New StringBuilder
        Dim currentDate As DateTime = DateTime.Now
        _config.Refresh()

        'BDOFile = New BDOFileClass
        With BDOFile
            .LocatorCode = GetBDOInfo(BDO.BDOInfo.LocatorCode)
            .TieUpCode = GetBDOInfo(BDO.BDOInfo.TieUpCode)
            .BatchNo = GetNextBDOBatchNo()
        End With


        With filename
            .Append(BDOFile.TieUpCode)                                      'tie-up short code that will be assigned by BDO
            .Append(Year(System.DateTime.Now()))                            'exact/current year (e.g. 08 for 2008) 
            .Append(Mid(MonthAlphabet, currentDate.Month, 1))               'exact/current month (A for Jan, B for Feb...L for Dec) 
            .Append(Format(currentDate.Day, "00"))                          'exact/current day padded with zero (01 for 1, 02 for 2) 
            .Append(BDOFile.BatchNo)                                        'sequential batch number (01,02…99 or combination of alpha and numeric e.g. AA,A1,BA,B9…ZZ,Z9)  
        End With

        BDOFile.FileName = filename.ToString
    End Sub


#Region "Batch No"

    Function GetNextBDOBatchNo() As String
        Dim CurrentBatchNo As Integer

        Dim CurrentValue As String = _config.GetValue("BDO_NEXTBATCHNO")
        If IfNull(CurrentValue, "").Equals("") Then CurrentValue = 0

        If Not IsNumeric(CurrentValue) Then CurrentValue = 0
        If CurrentValue > BDO.BatchNoChars.Length * BDO.BatchNoChars.Length + BDO.BatchNoChars.Length Then CurrentValue = 0

        CurrentBatchNo = CInt(CurrentValue) + 1
        _config.SaveValue("BDO_NEXTBATCHNO", CurrentBatchNo)

        Return BDO.ChangeNumToBatchNo(CurrentBatchNo)

    End Function

    
#End Region

    Private Function GetBDOInfo(_getwhat As BDO.BDOInfo) As String
        Dim ReturnValue As String = ""
        Select Case _getwhat
            Case BDO.BDOInfo.TieUpCode
                ReturnValue = _config.GetValue(BDO.BDOInfoFields.TieUpCode)

            Case BDO.BDOInfo.LocatorCode
                ReturnValue = _config.GetValue(BDO.BDOInfoFields.LocatorCode)

            Case BDO.BDOInfo.CurrentBatchNo
                ReturnValue = _config.GetValue(BDO.BDOInfoFields.BatchNo)

            Case BDO.BDOInfo.NextBatchNo
                ReturnValue = GetNextBDOBatchNo()

        End Select

        Return ReturnValue
    End Function

    Function Validate() As Boolean
        If Not ValidateBDOInfo() Then
            Return False
            Exit Function
        End If

        If Not My.Computer.FileSystem.FileExists(GetFileCompressorLocation(Compressor._7z)) Then
            MsgBox("Encryptor/Compression application file does not exist in the application folder. Please contact your system administrator for assistance.", MsgBoxStyle.Information)
            Return False
            Exit Function
        End If
        Return True
    End Function

    Function ValidateBDOInfo(Optional ShowMessage As Boolean = True) As Boolean
        If IfNull(GetBDOInfo(BDO.BDOInfo.TieUpCode), "").Equals("") Then
            If ShowMessage Then MsgBox("BDO Tie-up Short Code is not set. Please contact your system administrator for assistance.", MsgBoxStyle.Exclamation)
            Return False
            Exit Function
        End If

        If IfNull(GetBDOInfo(BDO.BDOInfo.LocatorCode), "").Equals("") Then
            If ShowMessage Then MsgBox("BDO Locaotr Code is not set. Please contact your system administrator for assistance.", MsgBoxStyle.Exclamation)
            Return False
            Exit Function
        End If

        Return True
    End Function

    Function BDO7Zip(cOriginalFile As String, cZipFile As String, cPassword As String, Optional ShowErrorMessage As Boolean = False) As Boolean
        Dim cCommand As String

        'Command Line Sample:   
        '       "~\7z.exe" a -p<password> -tzip "<zip file>" "<original file>"
        Try
            If Not My.Computer.FileSystem.FileExists(GetFileCompressorLocation(Compressor._7z)) Then
                If ShowErrorMessage Then MsgBox("7z compressor file does not exist.", MsgBoxStyle.Exclamation)
                Return False
                Exit Function
            End If

            cCommand = """" & GetFileCompressorLocation(Compressor._7z) & """ a -p" & IfNull(cPassword, "") & " -tzip """ & cZipFile & """ """ & cOriginalFile & """"
            Shell(cCommand, AppWinStyle.Hide, True, 1000)
        Catch ex As Exception
            If ShowErrorMessage Then MsgBox("Failed to compress file.", MsgBoxStyle.Exclamation)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Public Enum Compressor
        _7z = 1
    End Enum

    Function GetFileCompressorLocation(_encryptor As Compressor) As String
        Select Case _encryptor
            Case Compressor._7z
                Return Application.StartupPath & "\Resources\7z.exe"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub Rollback(_bdofile As BDOFileClass)
        If My.Computer.FileSystem.FileExists(_bdofile.ExportFile) Then File.Delete(_bdofile.ExportFile)
        If My.Computer.FileSystem.FileExists(_bdofile.SumFile) Then File.Delete(_bdofile.SumFile)
        If My.Computer.FileSystem.FileExists(_bdofile.ZipFile) Then File.Delete(_bdofile.ZipFile)
        If My.Computer.FileSystem.FileExists(_bdofile.RptFile) Then File.Delete(_bdofile.RptFile)
    End Sub
#End Region

End Class

