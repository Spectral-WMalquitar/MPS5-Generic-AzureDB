Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports Utilities.modExcel.ExportToExcel.Enumerables
Imports System.Windows.Forms

Public Module modExcel

    Public Const ExcelColumnLetters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Public Const xlNone = -4142
    Public Const xlContinuous = 1
    Public Const xlThin = 2
    Public Const xlDiagonalDown = 5
    Public Const xlDiagonalUp = 6
    Public Const xlEdgeLeft = 7
    Public Const xlEdgeTop = 8
    Public Const xlEdgeBottom = 9
    Public Const xlEdgeRight = 10
    Public Const xlInsideVertical = 11
    Public Const xlInsideHorizontal = 12
    Public Const xlAutomatic = -4105
    Public Const xlSolid = 1
    Public Const xlCenter = -4108
    Public Const xlBottom = -4107
    Public Const xlUnderlineStyleNone = -4142
    Public Const xlThemeColorLight1 = 2
    Public Const xlTop = -4160
    Public Const xlDown = -4121
    Public Const xlUp = -4162
    Public Const xlRight = -4152
    Public Const xlLeft = -4131

    Public Function NumToExcelCol(columnNo As Integer) As String
        Dim returnValue As String = ""

        If columnNo <= ExcelColumnLetters.Length Then
            returnValue = Mid(ExcelColumnLetters, columnNo, 1)

        Else
            'Dim part1 As String, part2 As String

            'part1 = Mid(ExcelColumnLetters, columnNo \ ExcelColumnLetters.Length, 1)
            'part2 = Mid(ExcelColumnLetters, IIf(columnNo Mod ExcelColumnLetters.Length = 0, ExcelColumnLetters.Count, columnNo Mod ExcelColumnLetters.Length), 1)

            Dim part1 As Integer = 0, part2 As Integer = 0

            part1 = columnNo \ ExcelColumnLetters.Length
            part2 = columnNo Mod ExcelColumnLetters.Length

            If part2 = 0 Then
                part1 = part1 - 1
                part2 = ExcelColumnLetters.Count
            End If

            returnValue = Mid(ExcelColumnLetters, part1, 1) & Mid(ExcelColumnLetters, part2, 1)
        End If

        Return returnValue
    End Function

    Public Class ExportToExcel
        'EXCEL RELATED OBJECTS
        Dim excelApp As New Excel.Application()
        Dim excelWBk As Excel.Workbook
        Dim excelSheet As Excel.Worksheet
        Dim excelRange As Excel.Range

        Public CurrentRow As Integer = 1
        '--------------------------------

        Public HasFile As Boolean = False
        Private _FileName As String
        Public Property Filename As String
            Set(value As String)
                _FileName = Filename
            End Set
            Get
                Return _FileName
            End Get
        End Property

        Public ReadOnly Property ExcelApplication As Excel.Application
            Get
                Return excelWBk
            End Get
        End Property

        Public ReadOnly Property CurrentWorkbook As Excel.Workbook
            Get
                Return excelWBk
            End Get
        End Property

        Public ReadOnly Property CurrentSheet As Excel.Worksheet
            Get
                Return excelSheet
            End Get
        End Property

        ''' <summary>
        ''' Creates a new instance of the ExportToExcel class from a new file.
        ''' </summary>
        Public Sub New()
            excelApp.DisplayAlerts = False
            excelWBk = excelApp.Workbooks.Add
            excelSheet = TryCast(excelWBk.ActiveSheet, Excel.Worksheet)

        End Sub

        ''' <summary>
        ''' Creates a new instance of the ExportToExcel class from an existing file.
        ''' </summary>
        ''' <param name="FileToOpen">Complete name and path of excel file to open.</param>
        ''' <param name="SheetName">[Optional] Name of sheet to be selected by default.</param>
        ''' <remarks>This is normally used for excel templates</remarks>
        Public Sub New(FileToOpen As String, Optional SheetName As String = "")
            excelApp.DisplayAlerts = False
            If Not File.Exists(IfNull(FileToOpen, "")) Then
                MsgBox("File [" & FileToOpen & "] does not exist.", MsgBoxStyle.Exclamation, "Export to Excel")
                HasFile = False
                Exit Sub
            End If

            excelWBk = excelApp.Workbooks.Open(FileToOpen)
            If IfNull(SheetName, "").Length > 0 Then
                excelSheet = TryCast(excelWBk.Sheets(SheetName), Excel.Worksheet)
            Else
                excelSheet = TryCast(excelWBk.ActiveSheet, Excel.Worksheet)
            End If

        End Sub

        'Public Sub SaveFile(SaveAs As Boolean, FilenameToSave As String, Optional PromptToReplaceIfExists As Boolean = False, Optional CloseAfterSave As Boolean = False)
        '    Try
        '        Dim isSave As Boolean = False
        '        If Not File.Exists(FilenameToSave) Then
        '            isSave = True
        '        Else
        '            If PromptToReplaceIfExists Then
        '                If MsgBox("File [" & FilenameToSave & "] exists. File will will be replaced." & vbNewLine & "Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Excel File") = MsgBoxResult.Yes Then
        '                    Kill(FilenameToSave)
        '                    isSave = True
        '                End If

        '            Else
        '                isSave = True

        '            End If
        '        End If

        '        If isSave Then
        '            If SaveAs Then
        '                excelWBk.SaveAs(FilenameToSave)
        '            Else
        '                excelWBk.Save()
        '            End If

        '        End If


        '        If CloseAfterSave Then CloseExcelFile(True)
        '    Catch ex As Exception
        '        MsgBox("Save Failed." & vbNewLine & "Error : " & ex.Message)
        '        LogErrors("<ExportToExcel><SaveFile>" & ex.Message)
        '    End Try

        'End Sub

        Public Function SaveFile(FilenameToSave As String) As Boolean
            Dim bSuccess As Boolean = False
            Try
                excelApp.DisplayAlerts = False
                excelWBk.SaveAs(FilenameToSave)
                bSuccess = True

            Catch ex As Exception
                MsgBox("Save Failed." & vbNewLine & "Error : " & ex.Message)
                LogErrors("<ExportToExcel><SaveFile>" & ex.Message)

            Finally
                CloseExcelFile()
            End Try

            Return bSuccess
        End Function

        Public Function SelectLocationAndSaveFile() As Boolean
            Dim bSuccess As Boolean = False

            Dim saveDialog As New System.Windows.Forms.SaveFileDialog()
            saveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls"
            saveDialog.Title = "Select file location"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                If Not saveDialog.FileName.Trim().Equals("") Then
                    bSuccess = SaveFile(saveDialog.FileName.Trim())
                End If
            End If

            Return bSuccess
        End Function


        'Public Sub SaveFileAs(NewFilename As String, Optional PromptToReplaceIfExists As Boolean = False, Optional CloseAfterSave As Boolean = False)
        '    Try
        '        Dim isSave As Boolean = False
        '        If Not File.Exists(NewFilename) Then
        '            isSave = True
        '        Else
        '            If PromptToReplaceIfExists Then
        '                If MsgBox("File [" & NewFilename & "] exists. File will will be replaced." & vbNewLine & "Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Excel File") = MsgBoxResult.Yes Then
        '                    Kill(NewFilename)
        '                    isSave = True
        '                End If

        '            Else
        '                isSave = True

        '            End If
        '        End If

        '        If isSave Then excelWBk.SaveAs(NewFilename)


        '        If CloseAfterSave Then CloseExcelFile(True)
        '    Catch ex As Exception
        '        MsgBox("Save Failed." & vbNewLine & "Error : " & ex.Message)
        '        LogErrors("<ExportToExcel><SaveFile>" & ex.Message)
        '    End Try

        'End Sub

        Public Sub CloseExcelFile(Optional ByVal nType As Boolean = True)
            Try
                'excelSheet = Nothing
                'excelWBk.Close()
                'excelWBk = Nothing
                'excelApp.Quit()
                'excelApp = Nothing

                excelApp.Workbooks.Close()
                excelApp.Quit()
            Catch ex As Exception
                LogErrors("<ExportToExcel><CloseExcelFile>" & ex.Message)
            End Try
        End Sub



#Region "Enumerables"
        Public Class Enumerables

            Public Enum MoveCopy
                Move = 1
                Copy = 2
            End Enum

            Public Enum BeforeAfter
                Before = 1
                After = 2
            End Enum

            Public Enum CopyCut
                Copy = 1
                cut = 2
            End Enum
        End Class
#End Region

#Region "Cell Actions"

        Public Sub SetRangeValue(Range As String, Value As Object)
            Try
                excelSheet.Range(Range).Value = Value
            Catch ex As Exception
                LogErrors("<ExportToExcel><SetRangeValue>" & ex.Message)
            End Try
        End Sub

        Public Function GetRangeValue(Range As String) As Object
            Try
                Return excelSheet.Range(Range).Value
            Catch ex As Exception
                LogErrors("<ExportToExcel><GetRangeValue>" & ex.Message)
                Return Nothing
            End Try
        End Function


        Public Sub MergeCells(ByVal Range As String, Optional HorizontalAlignment As Long = xlCenter, Optional VerticalAlignment As Long = xlBottom, Optional WrapText As Boolean = False)
            'or MERGE AND CENTER
            Try
                With excelSheet
                    .Range(Range).Merge()
                    .Range(Range).HorizontalAlignment = HorizontalAlignment
                    .Range(Range).VerticalAlignment = VerticalAlignment
                    .Range(Range).WrapText = WrapText
                End With
            Catch ex As Exception
                LogErrors("<ExportToExcel><MergeCells>" & ex.Message)
            End Try

        End Sub

        Public Sub BorderizeCell(ByVal Range As String, Optional Top As Boolean = False, Optional Right As Boolean = False, Optional Bottom As Boolean = False, Optional Left As Boolean = False)
            Try
                'TOP BORDER
                If Top Then
                    With excelSheet.Range(Range).Borders(xlEdgeTop)
                        .LineStyle = xlContinuous
                        .ColorIndex = 0
                        .TintAndShade = 0
                        .Weight = xlThin
                    End With
                End If
            Catch ex As Exception
                LogErrors("<ExportToExcel><BorderizeCell><Top>" & ex.Message)
            End Try

            Try
                'RIGHT BORDER
                If Right Then
                    With excelSheet.Range(Range).Borders(xlEdgeRight)
                        .LineStyle = xlContinuous
                        .ColorIndex = 0
                        .TintAndShade = 0
                        .Weight = xlThin
                    End With
                End If
            Catch ex As Exception
                LogErrors("<ExportToExcel><BorderizeCell><Right>" & ex.Message)
            End Try

            Try
                'BOTTOM BORDER
                If Bottom Then
                    With excelSheet.Range(Range).Borders(xlEdgeBottom)
                        .LineStyle = xlContinuous
                        .ColorIndex = 0
                        .TintAndShade = 0
                        .Weight = xlThin
                    End With
                End If
            Catch ex As Exception
                LogErrors("<ExportToExcel><BorderizeCell><Bottom>" & ex.Message)
            End Try

            Try
                'LEFT BORDER
                If Left Then
                    With excelSheet.Range(Range).Borders(xlEdgeLeft)
                        .LineStyle = xlContinuous
                        .ColorIndex = 0
                        .TintAndShade = 0
                        .Weight = xlThin
                    End With
                End If
            Catch ex As Exception
                LogErrors("<ExportToExcel><BorderizeCell><Left>" & ex.Message)
            End Try
        End Sub


        'Public Sub SurroundCellWithBorder(Range As String, Optional isSetLeft As Boolean = True, Optional isSetRight As Boolean = True, Optional isSetTop As Boolean = True, Optional isSetBottom As Boolean = True)
        '    On Error Resume Next

        '    excelSheet.Range(Range).Borders(xlDiagonalUp).LineStyle = xlNone
        '    If isSetLeft Then
        '        With excelSheet.Range(Range).Borders(xlEdgeLeft)
        '            .LineStyle = xlContinuous
        '            .ColorIndex = 0
        '            .TintAndShade = 0
        '            .Weight = xlThin
        '        End With
        '    End If

        '    If isSetTop Then
        '        With excelSheet.Range(Range).Borders(xlEdgeTop)
        '            .LineStyle = xlContinuous
        '            .ColorIndex = 0
        '            .TintAndShade = 0
        '            .Weight = xlThin
        '        End With
        '    End If

        '    If isSetBottom Then
        '        With excelSheet.Range(Range).Borders(xlEdgeBottom)
        '            .LineStyle = xlContinuous
        '            .ColorIndex = 0
        '            .TintAndShade = 0
        '            .Weight = xlThin
        '        End With
        '    End If

        '    If isSetRight Then
        '        With excelSheet.Range(Range).Borders(xlEdgeRight)
        '            .LineStyle = xlContinuous
        '            .ColorIndex = 0
        '            .TintAndShade = 0
        '            .Weight = xlThin
        '        End With
        '    End If

        '    'IF ALL BORDERS ARE SELECTED
        '    If isSetLeft And isSetRight And isSetTop And isSetBottom Then
        '        With excelSheet.Range(Range).Borders(xlInsideVertical)
        '            .LineStyle = xlContinuous
        '            .ColorIndex = 0
        '            .TintAndShade = 0
        '            .Weight = xlThin
        '        End With
        '        With excelSheet.Range(Range).Borders(xlInsideHorizontal)
        '            .LineStyle = xlContinuous
        '            .ColorIndex = 0
        '            .TintAndShade = 0
        '            .Weight = xlThin
        '        End With
        '    End If


        'End Sub
#End Region


#Region "Overall"
        Public Sub ChangeFont(Range As String, Optional Font As String = "", Optional Size As Integer = 11, Optional Bold As Boolean = False, Optional Italic As Boolean = False, Optional Strikethrough As Boolean = False, Optional Superscript As Boolean = False, Optional Subscript As Boolean = False, Optional OutlineFont As Boolean = False, Optional Shadow As Boolean = False, Optional Underline As Long = xlUnderlineStyleNone, Optional ThemeColor As Integer = xlThemeColorLight1, Optional TintAndShade As Integer = 0, Optional ThemeFont As Integer = 0, Optional Color As Long = 0)

            With excelSheet.Range(Range).Font
                If Len(Font) > 0 Then
                    .Name = "Century Gothic"
                End If
                .Size = Size
                .Strikethrough = Strikethrough
                .Superscript = Superscript
                .Subscript = Subscript
                .OutlineFont = OutlineFont
                .Shadow = Shadow
                .Underline = Underline
                .ThemeColor = ThemeColor
                .TintAndShade = TintAndShade
                .ThemeFont = ThemeFont
                If Color <> 0 Then
                    .Color = Color
                End If
            End With
        End Sub

        Public Sub SetBackColor(cRange As String, Optional Color As Long = 0, Optional ThemeColor As Integer = 0, Optional TintAndShade As Double = 0)
            On Error Resume Next
            With excelSheet.Range(cRange).Interior
                .Pattern = xlSolid
                .PatternColorIndex = xlAutomatic
                If Color <> 0 Then
                    .Color = Color
                End If
                If ThemeColor <> 0 Then
                    .ThemeColor = ThemeColor
                End If
                '.TintAndShade = TintAndShade
                If TintAndShade <> 0 Then
                    .TintAndShade = TintAndShade
                End If
                .PatternTintAndShade = 0
            End With
        End Sub
#End Region


#Region "Sheet actions"
        Public Sub SelectSheet(ByVal SheetName As String)
            Try
                TryCast(excelWBk.Sheets(SheetName), Excel.Worksheet).Select()
            Catch ex As Exception
                LogErrors("<ExportToExcel><SelectSheet>" & ex.Message)
            End Try
        End Sub

        Public Sub RenameSheet(ByVal OldName As String, NewName As String)
            Try
                excelWBk.Sheets(OldName).Name = NewName
            Catch ex As Exception
                LogErrors("<ExportToExcel><RenameSheet>" & ex.Message)
            End Try
        End Sub

        Public Sub DeleteSheet(ByVal SheetName As String)
            Try
                TryCast(excelWBk.Sheets(SheetName), Excel.Worksheet).Delete()
            Catch ex As Exception
                LogErrors("<ExportToExcel><DeleteSheet>" & ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Moves a sheet before or after another sheet
        ''' Or
        ''' Copies a sheet and moves it before or after another sheet
        ''' </summary>
        ''' <param name="SheetToMoveCopy">Name of worksheet to move or copy</param>
        ''' <param name="MoveOrCopy">Command whether to move or copy</param>
        ''' <param name="BeforeOrAfter">Location whether before or after another sheet</param>
        ''' <param name="BeforeOrAfterThisSheet">The selected sheet will be copied/moved to this sheet</param>
        ''' <param name="RenameSheetWith">[Optional] Rename the copied/moved sheet to this</param>
        ''' <remarks></remarks>
        Public Sub MoveCopySheet(ByVal SheetToMoveCopy As String, ByVal MoveOrCopy As Enumerables.MoveCopy, ByVal BeforeOrAfter As Enumerables.BeforeAfter, ByVal BeforeOrAfterThisSheet As String, Optional RenameSheetWith As String = "")
            With excelWBk
                .Sheets(SheetToMoveCopy).Select()
                Select Case UCase(MoveOrCopy)
                    Case "MOVE"
                        Select Case UCase(BeforeOrAfter)
                            Case "BEFORE"
                                .Sheets(SheetToMoveCopy).Move(Before:=.Sheets(BeforeOrAfterThisSheet))
                            Case "AFTER"
                                .Sheets(SheetToMoveCopy).Move(After:=.Sheets(BeforeOrAfterThisSheet))
                        End Select
                    Case "COPY"
                        Select Case UCase(BeforeOrAfter)
                            Case "BEFORE"
                                .Sheets(SheetToMoveCopy).Copy(Before:=.Sheets(BeforeOrAfterThisSheet))
                            Case "AFTER"
                                .Sheets(SheetToMoveCopy).Copy(After:=.Sheets(BeforeOrAfterThisSheet))
                        End Select
                End Select

                If Len(RenameSheetWith) > 0 Then
                    .Sheets(SheetToMoveCopy & " (2)").Name = RenameSheetWith
                End If
            End With

        End Sub


#End Region


#Region "Row Actions"
        Public Sub GotoNextRow()
            CurrentRow = CurrentRow + 1
        End Sub

        Public Sub GoToRow(RowNumber As Integer)
            CurrentRow = RowNumber
        End Sub

        Public Sub InsertExcelRow(Range As String)
            On Error Resume Next
            excelSheet.Range(Range).Insert(xlDown)
        End Sub

        Public Sub CopyRows(CopyOrCut As CopyCut, RowFrom As Integer, RowTo As Integer, PasteAtRow As Integer)
            If IfNull(RowFrom, 0) > 0 And IfNull(RowTo, 0) > 0 And IfNull(PasteAtRow, 0) > 0 Then
                TryCast(excelSheet.Rows(RowFrom & ":" & RowTo), Excel.Range).Copy()
                TryCast(excelSheet.Rows(PasteAtRow & ":" & PasteAtRow), Excel.Range).Select()
                TryCast(excelSheet, Excel.Worksheet).Paste()
            End If

        End Sub
#End Region



    End Class


End Module
