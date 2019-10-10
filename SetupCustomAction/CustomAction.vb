Imports System.ComponentModel
Imports System.Configuration.Install

Public Class CustomAction

#Region "Properties"
    Private ReadOnly Property FilesToDelete As String()
        Get
            Return New String() {"C:\Spectral\MPS5\setting.ini", _
                                 "C:\Spectral\MPS5\samplefile.tmp"}
        End Get
    End Property

    Private ReadOnly Property FoldersToDelete As String()
        Get
            Return New String() {"C:\Spectral\MPS5\Errors\", _
                                 "C:\Spectral\MPS5\Logs\", _
                                 "C:\Spectral\MPS5\temp_update\"}
        End Get
    End Property
#End Region

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent

    End Sub

    Private Sub CustomAction_AfterUninstall(sender As Object, e As System.Configuration.Install.InstallEventArgs) Handles Me.AfterUninstall
        RemoveFilesToDelete()

        RemoveFoldersToDelete()

        '<!-- tony20171108 : does not work yet
        'MsgBox("Remove Registry")
        'RemoveRegistry()
        '-->
    End Sub

    Private Sub RemoveRegistry()

        'Try
        '    Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\MPS4")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'Try
        '    Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\MPS5")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub RemoveFilesToDelete()
        Dim cFile As String
        For i As Integer = 0 To FilesToDelete.GetUpperBound(0)
            cFile = FilesToDelete(i)

            Try
                If System.IO.File.Exists(cFile) Then
                    Kill(cFile)
                End If
            Catch ex As Exception
                'do nothing
            End Try

        Next
    End Sub

    Private Sub RemoveFoldersToDelete()
        Dim cFolder As String
        For i As Integer = 0 To FoldersToDelete.GetUpperBound(0)
            cFolder = FoldersToDelete(i)

            Try
                If System.IO.Directory.Exists(cFolder) Then
                    System.IO.Directory.Delete(cFolder, True)
                End If
            Catch ex As Exception
                'do nothing
            End Try

        Next
    End Sub

End Class
