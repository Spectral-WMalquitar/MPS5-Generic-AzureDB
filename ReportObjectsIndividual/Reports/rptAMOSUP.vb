Public Class rptAMOSUP

    Private Sub txtGivenName_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtGivenName.BeforePrint
        Me.txtGivenName.Text = Me.txtFName.Text & " " & Me.txtMName.Text
    End Sub
End Class