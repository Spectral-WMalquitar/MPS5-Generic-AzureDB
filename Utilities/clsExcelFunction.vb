Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class clsExcelFunction

    Public xlApp As Excel.Application
    Public xlWB As Excel.Workbook
    Public xlWS As Excel.Worksheet

    Private _FilePath As String
    Public Property FilePath() As String
        Get
            Return _FilePath
        End Get
        Set(ByVal value As String)
            _FilePath = value
        End Set
    End Property

    Dim Letters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    Public Sub New()    'added by tony20170412
        xlApp = New Excel.Application
        xlApp.Workbooks.Add()
        xlWB = xlApp.Workbooks(1)
        xlWS = xlWB.Worksheets(1)
    End Sub

    Public Sub New(FilePathName As String, SheetName As String)
        xlApp = New Excel.Application
        xlWB = xlApp.Workbooks.Open(FilePathName)
        xlWS = xlWB.Worksheets(SheetName)
    End Sub

    Public Sub New(TemplateFilePath As String, FileName As String, SheetName As String)
        Dim SaveDialog As New SaveFileDialog
        SaveDialog.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls|All files|*.*"
        SaveDialog.FileName = FileName
        SaveDialog.ShowDialog()
        Dim strSaveFilePath As String = SaveDialog.FileName
        If Not SaveDialog.FileName.Equals(FileName) Then
            FilePath = SaveDialog.FileName
            If System.IO.File.Exists(strSaveFilePath) Then

                Kill(strSaveFilePath)
                System.IO.File.Copy(TemplateFilePath, strSaveFilePath)
            Else
                System.IO.File.Copy(TemplateFilePath, strSaveFilePath)
                xlApp = New Excel.Application
                xlWB = xlApp.Workbooks.Open(strSaveFilePath)
                xlWS = xlWB.Worksheets(SheetName)
            End If
        End If

    End Sub

    Public Function SaveExcelFile(Optional SaveAs As Boolean = False, Optional FileName As String = "", Optional DisplayAlerts As Boolean = True) As Boolean
        SaveExcelFile = True
        xlApp.DisplayAlerts = DisplayAlerts
        Try
            If SaveAs Then
                xlWB.SaveAs(FileName)
            Else
                xlWB.Save()
            End If
            CloseExcelFile()
        Catch ex As Exception
            SaveExcelFile = False
            MsgBox("Function SaveExcelFile() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
        'xlApp.DisplayAlerts = True
    End Function

    Public Function CloseExcelFile() As Boolean
        CloseExcelFile = True
        Try
            If Not xlApp Is Nothing Then
                xlApp.Quit()
                xlApp = Nothing
            End If
            If Not xlWB Is Nothing Then
                xlWB = Nothing
            End If
            If Not xlWS Is Nothing Then
                xlWS = Nothing
            End If
        Catch ex As Exception
            CloseExcelFile = False
            MsgBox("Function CloseExcelFile() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Function

    Public Function SelectSheet(SheetName As String) As Boolean
        SelectSheet = True
        Try
            xlWS = xlWB.Worksheets(SheetName)
        Catch ex As Exception
            SelectSheet = False
            MsgBox("Function SelectSheet() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Function

    Public Function SelectSheet(Index As Integer) As Boolean
        SelectSheet = True
        Try
            xlWS = xlWB.Worksheets(Index)
        Catch ex As Exception
            SelectSheet = False
            MsgBox("Function SelectSheet() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Function

    Public Function RenameSheet(ByVal OldName As String, NewName As String) As Boolean
        RenameSheet = True
        Try
            xlWB.Sheets(OldName).Name = NewName
        Catch ex As Exception
            RenameSheet = False
            MsgBox("Function RenameSheet() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Function

    Public Function DeleteSheet(SheetName As String) As Boolean
        DeleteSheet = True
        Try
            xlWB.Worksheets(SheetName).Delete()
        Catch ex As Exception
            DeleteSheet = False
            MsgBox("Function DeleteSheet() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Function

    Public Function SetExcelValue(Range As String, Value As Object, Optional SheetName As String = "") As Boolean
        SetExcelValue = True
        Try
            If SheetName.Length > 0 Then SelectSheet(SheetName)
            xlWS.Range(Range).Value = Value
        Catch ex As Exception
            SetExcelValue = False
            MsgBox("Function SetExcelValue() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Function

    Public Function SetRangeNumberFormat(Range As String, NumberFormat As Object, Optional SheetName As String = "") As Boolean
        SetRangeNumberFormat = True
        Try
            If SheetName.Length > 0 Then SelectSheet(SheetName)
            xlWS.Range(Range).NumberFormat = NumberFormat
        Catch ex As Exception
            SetRangeNumberFormat = False
            MsgBox("Function SetRangeNumberFormat() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Function

    Function InsertExcelRow(Range As String)
        InsertExcelRow = True
        Try
            xlWS.Range(Range).Insert(Shift:=1)
        Catch ex As Exception
            InsertExcelRow = False
            MsgBox("Function InsertExcelRow() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try

    End Function

    Public Sub ShowExcelFile(Optional FileName As String = "")
        Try
            If FileName.Length > 0 Then
                Process.Start(FileName)
            Else
                Process.Start(FilePath)
            End If
        Catch ex As Exception
            MsgBox("Function ShowExcelFile() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Sub

    Public Enum CopyMoveAction
        Copy = 1
        Move = 2
    End Enum

    Public Enum CopyMovePosition
        Before = 1
        After = 2
    End Enum

    Public Sub CopyMoveSheet(CopyMove As CopyMoveAction, WhatSheet As String, Position As CopyMovePosition, ToThisSheet As String, Optional RenameTheSheetTo As String = "")
        Try
            Dim oWhatSheet As Excel.Worksheet
            Dim oToThisSheet As Excel.Worksheet
            Select Case CopyMove
                Case CopyMoveAction.Copy
                    oWhatSheet = xlWB.Worksheets(WhatSheet)
                    If Not IsNothing(oWhatSheet) Then
                        oToThisSheet = xlWB.Worksheets(ToThisSheet)
                        If Not IsNothing(oToThisSheet) Then
                            If Position = CopyMovePosition.After Then oWhatSheet.Copy(, oToThisSheet)
                            If Position = CopyMovePosition.Before Then oWhatSheet.Copy(oToThisSheet)
                        End If

                    End If

                Case CopyMoveAction.Move
                    oWhatSheet = xlWB.Worksheets(WhatSheet)
                    If Not IsNothing(oWhatSheet) Then
                        oToThisSheet = xlWB.Worksheets(ToThisSheet)
                        If Not IsNothing(oToThisSheet) Then
                            If Position = CopyMovePosition.After Then oWhatSheet.Move(, oToThisSheet)
                            If Position = CopyMovePosition.Before Then oWhatSheet.Move(oToThisSheet)
                        End If

                    End If
            End Select
            
        Catch ex As Exception
            MsgBox("Function ShowExcelFile() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Sub

    Public Sub HideColumn(Range As String, Value As Boolean, SheetName As String)
        Try
            SelectSheet(SheetName)
            xlWS.Range(Range).EntireColumn.Hidden = Value
        Catch ex As Exception
            MsgBox("Function HideRange() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try
    End Sub

    Public Sub AddLookValidationDropDown(RangePost As String, NameofNames As String, SColumn As Char, SRow As Integer, EColumn As Char, ERow As Integer, SheetToName As String, DataSheetFromName As String)
        '!$A$1:$A$100
        Try
            Dim formatRange As String = "!$" & SColumn & "$" & SRow.ToString & ":$" & EColumn & "$" & ERow.ToString
            xlWB.Names.Add(Name:=NameofNames, RefersToLocal:="=" & DataSheetFromName & formatRange)

            SelectSheet(SheetToName)
            With xlWS.Range(RangePost).Validation
                .Add(Type:=Excel.XlDVType.xlValidateList, AlertStyle:=Excel.XlDVAlertStyle.xlValidAlertStop, [Operator]:=Excel.XlFormatConditionOperator.xlBetween, Formula1:="=" & NameofNames)
            End With
        Catch ex As Exception
            MsgBox("Function AddLookValidationDropDown() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)

        End Try


    End Sub

    Public Sub HideSheet(SheetName As String, Value As Excel.XlSheetVisibility)
        Try
            SelectSheet(SheetName)
            xlWS.Visible = Value
        Catch ex As Exception
            MsgBox("Function HideSheet() encountered a problem", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)

        End Try
    End Sub

    Private Function GetExcelConnectionString(strFilePath As String) As String
        Dim retVal As String = String.Empty
        Dim JetVersion As String = String.Empty
        Dim strExt As String = System.IO.Path.GetExtension(strFilePath).ToString
        If (UCase(strExt) = ".XLS") Then
            JetVersion = "4.0"
        ElseIf (UCase(strExt) = ".XLSX") Then
            JetVersion = "12.0"
        End If
        If JetVersion = "4.0" Then
            retVal = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                            "Data Source= " & strFilePath & _
                            ";Extended Properties=""Excel 8.0;"""

        ElseIf JetVersion = "12.0" Then

            retVal = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                            "Data Source= " & strFilePath & _
                            ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
        End If
        Return retVal
    End Function

    Public Sub AutoFitColumn(StartingColumn As String, EndingColumn As String)
        xlWS.Columns(StartingColumn & ":" & EndingColumn).EntireColumn.AutoFit()
    End Sub

    Public Sub AutoFitColumn(StartingColumn As Integer, EndingColumn As Integer)
        xlWS.Columns(ChangeNumToExcelColumn(StartingColumn) & ":" & ChangeNumToExcelColumn(EndingColumn)).EntireColumn.AutoFit()
    End Sub

    Public Function CreateTable(QueryString As String) As DataTable
        Dim retVal As New DataTable
        Dim sqlCon As New OleDb.OleDbConnection(GetExcelConnectionString(xlWB.FullName))
        Try
            sqlCon.Open()
            Using cmd As New OleDb.OleDbCommand
                cmd.CommandText = QueryString
                cmd.Connection = sqlCon
                Using adp As New OleDb.OleDbDataAdapter(cmd)
                    adp.Fill(retVal)
                End Using
            End Using
        Catch ex As Exception
        Finally
            If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
        End Try
        Return retVal
    End Function

    Public Function ReadRowCellValue(SheetName As String, RowIndex As Integer, ColumnIndex As Integer) As Object
        SelectSheet(SheetName)
        Return xlWS.Cells(RowIndex, ColumnIndex).value
    End Function

    Public Function ChangeNumToExcelColumn(RowNumber As Integer) As String
        Dim ReturnValue As String = ""

        Dim leftLetter As String = ""
        If (RowNumber \ Letters.Length) > 0 Then
            leftLetter = Mid(Letters, (RowNumber \ Letters.Length), 1)
        End If
        ReturnValue = leftLetter & Mid(Letters, (RowNumber Mod Letters.Length), 1)

        Return ReturnValue
    End Function

    Public Function ChangeExcelColumnToNum(ExcelColumn As String) As Integer
        Dim ReturnValue As Integer

        If ExcelColumn.Length <> 2 Then
            ReturnValue = 0
        Else
            ReturnValue = IIf(InStr(Letters, Left(ExcelColumn, 1), CompareMethod.Text) > 0, Letters.Length * (InStr(Letters, Left(ExcelColumn, 1), CompareMethod.Text) - 1), 0) + _
                        InStr(Letters, Right(ExcelColumn, 1), CompareMethod.Text)
        End If

        Return ReturnValue
    End Function

    Public Function Range(col As Integer, row As Integer) As String
        Return ChangeNumToExcelColumn(col) & row
    End Function

    Public Row As New clsColumnRow
    Public Column As New clsColumnRow

    Public Class clsColumnRow
        Public Number As Integer = 1
        'Public Type As ColumnRowType = ColumnRowType.Column

        'Public ReadOnly Property RangeValue
        '    Get
        '        If Type = ColumnRowType.Column Then

        '        End If
        '    End Get
        'End Property

        'Public Enum ColumnRowType
        '    Column = 1
        '    Row = 2
        'End Enum


        Public Sub Increment(Optional IncrementBy As Integer = 0)
            Number = Number + IIf(IncrementBy > 0, IncrementBy, 1)
        End Sub
    End Class
End Class
