Imports System.Drawing
Imports System.IO
Imports DevExpress.XtraSplashScreen
Public Module DocumentViewer_Functions
    Dim tempPdf As New pdfTemplate
    Dim wordToPdf As New DevExpress.XtraRichEdit.RichEditControl
    Dim waitFrm As New DMS_Waitform
    Public Sub UpdateWaitForm(ByVal waitform As DevExpress.XtraWaitForm.ProgressPanel, ByVal cap As String, ByVal desc As String)
        Try
            With waitform
                .Caption = cap
                .Description = desc
            End With
            Threading.Thread.Sleep(2000)
        Catch ex As Exception

        End Try
    End Sub

    Public Function ExportCrewDocToPdf(ByVal filePath As String, ByVal compID As String, ByVal DocType As String, ByVal issueDate As String, Optional ByVal wholeFileName As String = "") As String
        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""
        Try
            'strDir = APP_PATH & "\Images\CrewDocs\" & compID & "\"
            strDir = FOLDERDIRECTORY & "\" & compID & "\"
            fileExt = System.IO.Path.GetExtension(filePath)
            If wholeFileName = "" Then
                fileName = compID & "_" & DocType & "_" & issueDate
            Else
                fileName = wholeFileName
            End If


            If (Not System.IO.Directory.Exists(strDir)) Then
                System.IO.Directory.CreateDirectory(strDir)
            End If

            Select Case fileExt
                Case ".docx", ".doc"
                    wordToPdf = New DevExpress.XtraRichEdit.RichEditControl
                    wordToPdf.LoadDocument(filePath)
                    wordToPdf.ExportToPdf(strDir & fileName & ".pdf")
                Case ".pdf"
                    My.Computer.FileSystem.CopyFile(filePath, strDir & fileName & ".pdf", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                Case Else
                    Try
                        Dim img As System.Drawing.Image
                        tempPdf = New pdfTemplate
                        Using Strm As Stream = File.OpenRead(filePath)
                            img = Image.FromStream(Strm)
                        End Using
                        tempPdf.imgFile.Image = img
                        tempPdf.ExportToPdf(strDir & fileName & ".pdf")
                    Catch ex As Exception
                        MessageBox.Show(GetAppName() & " - Invalid file type:" & ex.Message, GetAppName() & " - Document Management System")
                    End Try
            End Select
        Catch ex As Exception
            MessageBox.Show(GetAppName() & " - Can't link file:" & ex.Message, GetAppName() & " - Document Management System")
        End Try
        Return fileName
    End Function

    Public Sub replaceCrewDocToPdf(ByVal fileName As String, ByVal filepath As String, Optional ByVal wholeFileName As String = "")
        Dim files() As String
        Dim res As String = ""
        Try
            files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & fileName.Split("_").GetValue(0).ToString)
            For i As Integer = 0 To files.Count - 1
                If files(i).Contains(fileName) Then
                    Kill(files(i))
                    If wholeFileName = "" Then
                        ExportCrewDocToPdf(filepath, fileName.Split("_").GetValue(0).ToString, fileName.Split("_").GetValue(1).ToString, fileName.Split("_").GetValue(2).ToString)
                    Else
                        ExportCrewDocToPdf(filepath, fileName.Split("_").GetValue(0).ToString, fileName.Split("_").GetValue(1).ToString, fileName.Split("_").GetValue(2).ToString, wholeFileName)
                    End If
                    Exit Sub
                End If
            Next
        Catch ex As System.IO.DirectoryNotFoundException
            res = ""
        End Try
    End Sub

    Public Sub ViewFile(filePath As String, Optional showErrMsg As Boolean = True)
        Try
            If filePath.Length = 0 Then
                MsgBox("No file name specified.", MsgBoxStyle.Critical, GetAppName)
                Exit Sub
            End If
            Process.Start(filePath)
        Catch ex As Exception
            If showErrMsg Then
                MsgBox("Unable to open the file." & vbNewLine & "Exception : " & ex.Message, MsgBoxStyle.Critical, GetAppName)
            End If
        End Try
    End Sub

End Module
