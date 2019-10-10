Public Class frmInputPass
    Public isEnterDown As Boolean = False

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub frmInputPass_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            isEnterDown = True
            Me.Close()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class