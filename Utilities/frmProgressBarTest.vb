Public Class frmProgressBarTest
    Dim pbar As MPS5ProgressBar

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If IfNull(TextEdit1.EditValue, 0) <= 0 Then
            Exit Sub
        End If

        pbar = New MPS5ProgressBar(TextEdit1.EditValue)
        pbar.Status = TextEdit2.Text
        pbar.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        pbar.Update()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextEdit1.EditValue = 15
        TextEdit2.EditValue = "Testing Progress Bar"
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        pbar.Finish()
    End Sub
End Class