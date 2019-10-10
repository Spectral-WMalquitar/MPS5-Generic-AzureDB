Public Class rptSSSRemitCov

    Private Sub TxtCompany_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TxtCompany.BeforePrint
        Me.TxtCompany.Text = UCase(Me.TxtCompany.Text)
    End Sub

    Private Sub txtPaymentDate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtPaymentDate.BeforePrint
        'Me.txtPaymentDate.Text = Format(Me.txtPaymentDate.Text, "{MM DD, yyyy}")
    End Sub

    Private Sub rptSSSRemitCov_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

    End Sub

    Private Sub txtTotalAmt_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtTotalAmt.BeforePrint
        Me.txtTotalAmt.Text = Format(CDbl(IIf(Me.txtEmpeAmtSum.Text = "", 0, Me.txtEmpeAmtSum.Text)) + CDbl(IIf(Me.txtEmprAmtSum.Text = "", 0, Me.txtEmprAmtSum.Text)), "#,##0.00")
    End Sub
End Class