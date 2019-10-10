Public Class frmPopUpDeleteCrew
    Dim deleteCrew As Boolean
    Dim extractFiles As Boolean
    Private _PhotoPath As String
    Public Property PhotoaPath As String

        Get
            Return _PhotoPath
        End Get
        Set(value As String)

            If IfNull(value, "").Length > 0 Then
                If My.Computer.FileSystem.FileExists(value) Then
                    CrewPhoto.Image = ImageFromStream(value)
                Else
                    CrewPhoto.Image = Nothing
                End If
            End If
            _PhotoPath = IfNull(value, "")
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        deleteCrew = False
        extractFiles = False
    End Sub

    Public Function GoDeleteCrew() As Boolean
        Return deleteCrew
    End Function

    Public Function GoExtractFiles() As Boolean
        Return extractFiles
    End Function

    Private Sub cmdContinue_Click(sender As System.Object, e As System.EventArgs) Handles cmdContinue.Click
        deleteCrew = True
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        deleteCrew = False
        Me.Close()
    End Sub

    Private Sub chkExtractFiles_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles chkExtractFiles.EditValueChanged
        extractFiles = chkExtractFiles.EditValue
    End Sub
End Class