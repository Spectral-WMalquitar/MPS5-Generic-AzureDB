Public Class frmCopyBookingDetails
    Public CopyButtonClicked As Boolean = False
    Public CancelButtonClicked As Boolean = False

    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        If cboCrew.EditValue Is Nothing Then
            MsgBox("Please select a crew.", MsgBoxStyle.Information)
            cboCrew.Focus()
        ElseIf IfNull(cboCrew.EditValue, "") = "" Then
            MsgBox("Please select a crew.", MsgBoxStyle.Information)
            cboCrew.Focus()
        End If

        CopyButtonClicked = True
        Me.Close()
    End Sub


    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        CancelButtonClicked = True
        Me.Close()
    End Sub
End Class