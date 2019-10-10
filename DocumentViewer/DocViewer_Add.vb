Imports System.Drawing
Imports System.IO
Public Class DocViewer_Add
    Dim filepath As String = ""
    Public uploadDone As Boolean = False
    Public replaceMode As Boolean = False
    Public selectedCrew, dateIssue, docID, filename As String

    'Browse Button
    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.Filter = "Valid Files(*.tif;*.png;*.jpg;*.docx;*.doc;*.pdf)|*.tif;*.png;*.jpg;*.docx;*.doc;*.pdf"
        OpenFileDialog1.ShowDialog()
        filepath = OpenFileDialog1.FileName
        lblFilePath.ToolTip = filepath
        If Not filepath Is Nothing And filepath <> "OpenFileDialog1" Then displayThumbnail(filepath)
        lblFileName.Text = filename
    End Sub

    Private Sub DocViewer_Add_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        If files.Count <> 0 Then
            If files.Count > 1 Then
                MsgBox("Just select a single file.", MsgBoxStyle.Information, GetAppName)
            Else
                displayThumbnail(files(0))
            End If
        End If
    End Sub

    Private Sub displayThumbnail(ByVal filepath As String)
        Try
            If filepath.Contains(GetAppPath()) Then
                MsgBox("Please select another folder, this folder and sub folders are reserved for " & GetAppName() & ".", MsgBoxStyle.Information, GetAppName)
                cmdLink.Enabled = False
                Exit Sub
            Else
                If filepath <> Nothing Then
                    lblFilePath.Text = filepath
                    Using Strm As Stream = File.OpenRead(filepath)
                        picThumbnail.Image = Image.FromStream(Strm)
                    End Using
                    cmdLink.Enabled = True
                End If  
            End If
        Catch ex As ArgumentException 'Kapag hindi image yung file.
            'Dim filext As String = ""
            'filext = System.IO.Path.GetExtension(filepath)
            'Select Case filext
            '    Case ".pdf"
            '        picThumbnail.Image = Image.FromFile(GetDefaultImagesPath() & "pdf.png")
            '    Case ".docx"
            '        picThumbnail.Image = Image.FromFile(GetDefaultImagesPath() & "word.png")
            '    Case Else
            '        picThumbnail.Image = Image.FromFile(GetDefaultImagesPath() & "defaulticon.ico")
            'End Select
            cmdLink.Enabled = True
        Catch ex As EvaluateException
            picThumbnail.Image = Image.FromFile(GetDefaultImagesPath() & "defaulticon.ico")
            cmdLink.Enabled = False
        End Try
    End Sub

    Private Sub DocViewer_Add_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    'Link button
    Private Sub cmdLink_Click(sender As System.Object, e As System.EventArgs) Handles cmdLink.Click
        Try
            Dim param() As String = filename.Split("_")
            If replaceMode = True Then
                If MsgBox("Are you sure you want to replace this file?", MsgBoxStyle.YesNo, "File Link.") = MsgBoxResult.Yes Then
                    replaceCrewDocToPdf(filename, filepath)
                    lblFileName.Text = filename
                Else
                    Exit Sub
                End If
            Else
                ExportCrewDocToPdf(filepath, param(0), param(1), param(2))
            End If
            MsgBox("Upload successful!", MsgBoxStyle.Information, GetAppName)
            uploadDone = True
            Me.Refresh()
        Catch ex As Exception
            MsgBox(GetAppName() & " Error:" & ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try
    End Sub

    Private Sub DocViewer_Add_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        picThumbnail.Image = Nothing
        'lblIssueDate.Text = lblIssueDate.Text.Replace(":", ":" & Environment.NewLine)
        lblIssueDate.Text = dateIssue
        cmdLink.Enabled = False
        lblFileName.Text = filename
    End Sub
End Class