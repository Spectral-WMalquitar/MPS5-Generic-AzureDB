Imports System
Imports System.IO

Public Class ProgramSettings_Templates
    Public TemplatesFolder As String = ""

    Sub New(cFolder As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TemplatesFolder = cFolder

        GetFilesInTemplatesFolder()
    End Sub


    Public Sub GetFilesInTemplatesFolder()
        Dim dt As New DataTable
        Dim ccolumn As New DataColumn
        ccolumn.ColumnName = "Filename"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "NewItem"
        ccolumn.DataType = System.Type.GetType("System.Boolean")
        dt.Columns.Add(ccolumn)

        ' Make a reference to a directory.
        Dim di As New DirectoryInfo(TemplatesFolder)
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names of the files.
        Dim fri As FileInfo
        For Each fri In fiArr
            'Console.WriteLine(fri.Name)
            dt.Rows.Add(New Object() {fri.Name, False})
        Next fri

        MainGrid.DataSource = dt
        MainView.Columns("Filename").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
    End Sub 'GetFilesTest

    Private Sub BrowseFile()
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Multiselect = True


        ' Test result.
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            '' Get the file name.
            'Dim path As String = OpenFileDialog1.FileName
            'Try
            '    ' Read in text.
            '    Dim text As String = File.ReadAllText(path)

            '    ' For debugging.
            '    Me.Text = text.Length.ToString

            'Catch ex As Exception

            '    ' Report an error.
            '    Me.Text = "Error"

            'End Try



            Dim strFiles As String() = OpenFileDialog1.FileNames
            Dim files As New List(Of FileInfo)
            Dim existing As New System.Text.StringBuilder

            Dim dt As DataTable = TryCast(MainGrid.DataSource, DataTable)

            ''CHECK IF SELECTED FILES ALREADY EXISTS IN THE TEMPLATES FOLDER
            'For i As Integer = 0 To files.Count - 1
            '    If MainView.LocateByValue("Filename", files(i)) > 0 Then
            '        existing.AppendLine(files(i))
            '    End If

            'Next

            'If existing.Length > 0 Then
            '    MsgBox("The following files")
            'End If

            'ADD FILES TO THE TEMPLATES FOLDER
            Dim fileInTemplateFolder As String = ""
            For i As Integer = 0 To strFiles.Count - 1
                'If IO.File.Exists(files(i)
                'dt.Rows.Add(New Object() {strFiles(i), True})

                files.Add(New FileInfo(strFiles(i)))
            Next

            For Each _File As FileInfo In files
                fileInTemplateFolder = TemplatesFolder & IIf(Mid(IfNull(TemplatesFolder, ""), IfNull(TemplatesFolder, "").Length, 1) = "\", "", "\") & _
                               _File.Name
                If File.Exists(fileInTemplateFolder) Then
                    If MsgBox("File [" & _File.Name & "] already exists in the Templates Folder." & vbNewLine & _
                              vbNewLine & _
                              "Do you want to replace the existing file?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then

                        Try
                            Kill(fileInTemplateFolder)
                        Catch ex As Exception
                            MsgBox("Failed to removed file from Templates Folder." & vbNewLine & _
                                   "Error: " & ex.Message, MsgBoxStyle.Critical, GetAppName)
                        End Try

                        Try
                            FileCopy(_File.FullName, fileInTemplateFolder)
                        Catch ex As Exception
                            MsgBox("Failed to copy file to Templates Folder." & vbNewLine & _
                                   "Error: " & ex.Message, MsgBoxStyle.Critical, GetAppName)
                        End Try

                        If dt.Select("Filename = '" & _File.Name & "'").Count = 0 Then
                            dt.Rows.Add(New Object() {_File.Name, True})
                        End If

                    End If
                Else
                    Try
                        FileCopy(_File.FullName, fileInTemplateFolder)
                    Catch ex As Exception
                        MsgBox("Failed to copy file to Templates Folder." & vbNewLine & _
                               "Error: " & ex.Message, MsgBoxStyle.Critical, GetAppName)
                    End Try
                    dt.Rows.Add(New Object() {_File.Name, True})
                End If

            Next

            MainGrid.DataSource = dt

        End If
    End Sub

    Private Sub btnAddFile_Click(sender As System.Object, e As System.EventArgs) Handles btnAddFile.Click
        BrowseFile()
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
        Else
            If MainView.GetRowCellValue(e.RowHandle, "NewItem") Then
                e.Appearance.BackColor = Color.Yellow
            End If
        End If

        
    End Sub

    Private Sub repDelete_Click(sender As Object, e As System.EventArgs) Handles repDelete.Click
        If MsgBox("Are you sure you want to delete the file [" & MainView.GetFocusedRowCellValue("Filename") & "] from the Templates Folder?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then
            Dim cFile As String
            cFile = TemplatesFolder & IIf(Mid(IfNull(TemplatesFolder, ""), TemplatesFolder.Length, 1) = "\", "", "\") & _
                MainView.GetFocusedRowCellValue("Filename")

            If File.Exists(cFile) Then Kill(cFile)

            MainView.DeleteRow(MainView.FocusedRowHandle)
        End If

    End Sub

    Private Sub repOpenFile_Click(sender As Object, e As System.EventArgs) Handles repOpenFile.Click
        Dim cFile
        cFile = TemplatesFolder & IIf(Mid(IfNull(TemplatesFolder, ""), TemplatesFolder.Length, 1) = "\", "", "\") & _
                MainView.GetFocusedRowCellValue("Filename")

        If File.Exists(cFile) Then
            Process.Start(cFile)
        End If
    End Sub
End Class