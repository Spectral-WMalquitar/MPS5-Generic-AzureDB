Public Class MPSInputBox 
    'set Label
    Public Sub setLabel(ByVal label As String)
        lblLabel.Text = label
    End Sub

    Public Sub setOkBtnCaption(Optional ByVal value As String = "Ok")
        cmdOk.Text = value
    End Sub

    Public Function getValue() As String
        Return Me.txtValue.Text
    End Function

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        getValue()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class