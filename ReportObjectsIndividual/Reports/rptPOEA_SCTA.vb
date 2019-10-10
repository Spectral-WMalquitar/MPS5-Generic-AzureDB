Public Class rptPOEA_SCTA

    Private Sub txtNameCadet_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtNameCadet.BeforePrint
        Me.txtNameCadet.Text = Me.txtSalutation.Text & " " & txtCrew.Text
    End Sub

    Private Sub txtNameSignatureCadet_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtNameSignatureCadet.BeforePrint
        Me.txtNameSignatureCadet.Text = Me.txtSalutation.Text & " " & txtCrew.Text
    End Sub
End Class