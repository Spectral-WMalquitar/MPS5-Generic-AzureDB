Public Class frmImagePreview

    Private PhotoPath As String = ""

    Sub New(_PhotoPath)
        InitializeComponent()
        PhotoPath = _PhotoPath
        LoadPhoto()
    End Sub

    Sub New(_PhotoPath, Caption)
        InitializeComponent()
        PhotoPath = _PhotoPath
        LoadPhoto()
        SetCaption(Caption)
    End Sub

    Private Sub frmImagePreview_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ImagePreview.Dispose()
    End Sub

    Sub LoadPhoto()
        Try
            ImagePreview.Image = ImageFromStream(PhotoPath)
        Catch ex As Exception
            ImagePreview.Image = Nothing
        End Try
    End Sub

    Sub SetCaption(cCaption As String)
        Dim _Caption As String = "Preview"
        If IfNull(cCaption, "").Length > 0 Then _Caption = _Caption & " - " & cCaption

        Me.Text = _Caption
    End Sub
End Class