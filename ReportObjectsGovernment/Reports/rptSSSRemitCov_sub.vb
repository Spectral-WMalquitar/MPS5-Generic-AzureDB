Public Class rptSSSRemitCov_sub

    Private Sub celFamName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles celFamName.BeforePrint
        Me.celFamName.Text = UCase(Me.celFamName.Text)
    End Sub

    Private Sub celGivName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles celGivName.BeforePrint
        Me.celGivName.Text = UCase(Me.celGivName.Text)
    End Sub

    Private Sub celMI_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles celMI.BeforePrint
        Me.celMI.Text = UCase(Me.celMI.Text)
    End Sub
End Class