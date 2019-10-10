'// codes came from DocumentViewer\Document_Functions
'// this class is created to have a common code repository regarding documents


Imports System.IO
Imports System.Drawing

'Imports DevExpress.XtraSplashScreen

Public Class clsDocumentViewer_Functions

    Dim tempPdf As New pdfTemplate
    Dim wordToPdf As New DevExpress.XtraRichEdit.RichEditControl
    ' Dim waitFrm As New DMS_Waitform

    'Public Sub UpdateWaitForm(ByVal waitform As DevExpress.XtraWaitForm.ProgressPanel, ByVal cap As String, ByVal desc As String)
    '    Try
    '        With waitform
    '            .Caption = cap
    '            .Description = desc
    '        End With
    '        Threading.Thread.Sleep(2000)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Function ExportCrewDocToPdf(ByVal filePath As String, ByVal compID As String,
                                       ByVal DocType As String, ByVal issueDate As String,
                                       Optional ByVal wholeFileName As String = "", Optional ByRef ermsg As String = Nothing) As String
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
                        ermsg = ex.Message
                    End Try
            End Select
        Catch ex As Exception
            ermsg = ex.Message
        End Try
        Return fileName
    End Function

    Public Sub replaceCrewDocToPdf(ByVal fileName As String, ByVal filepath As String, Optional ByVal wholeFileName As String = "",
                                   Optional ByRef ermsg As String = Nothing)
        Dim files() As String
        Dim res As String = ""
        Try
            files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & fileName.Split("_").GetValue(0).ToString)
            For i As Integer = 0 To files.Count - 1
                'If files(i).Contains(fileName) Then
                If files(i) = fileName Then
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
            ermsg = ex.Message
            res = ""
        End Try
    End Sub

    Public Function ViewFile(filePath As String, Optional showErrMsg As Boolean = True,
                             Optional ByRef ermsg As String = Nothing) As Boolean
        Dim ret As Boolean = True
        Try
            If filePath.Length = 0 Then
                'MsgBox("No file name specified.", MsgBoxStyle.Critical, GetAppName)
                'Exit Function
                ret = False
            End If
            Process.Start(filePath)
        Catch ex As Exception
            If showErrMsg Then
                ermsg = ex.Message
                ret = False
            End If
        End Try

        Return ret
    End Function

    Public Function LinkDocument(_SourceFile As String, _IDNbr As String, _FileTag As String,
                              _DateIssue As String, Optional ByRef errmsg As String = "") As Boolean

        Dim ret As Boolean = True
        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""
        Dim fName As String = ""

        Try
            strDir = FOLDERDIRECTORY & "\" & _IDNbr & "\"
            fileExt = System.IO.Path.GetExtension(_SourceFile)
            fileName = _IDNbr & "_" & _FileTag & "_" & _DateIssue & fileExt
            fName = _IDNbr & "_" & _FileTag & "_" & _DateIssue

            If (Not System.IO.Directory.Exists(strDir)) Then
                System.IO.Directory.CreateDirectory(strDir)
            End If

            If (System.IO.File.Exists(strDir & "\" & fileName)) Then
                replaceCrewDoc(_SourceFile, fName)
            Else
                Dim fP As String = ""
                fP = GenerateCrewFilePath(fName)
                If System.IO.File.Exists(fP) Then
                    Kill(fP)
                End If
                ExportCrewDocToPdf(_SourceFile, _IDNbr, _FileTag, _DateIssue)
            End If
        Catch ex As Exception
            ret = False
            errmsg = ex.Message ' MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try

        Return ret
    End Function

End Class
