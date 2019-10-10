Public Class rptNISContract

    Private Sub txtFirstAndMiddleName_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtFirstAndMiddleName.BeforePrint
        Me.txtFirstAndMiddleName.Text = Me.txtFirstname.Text & ", " & Me.txtMiddleName.Text
    End Sub

    Private Sub txtBasic_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtBasic.BeforePrint

    End Sub

    Private Sub txtRankRating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtRankRating.BeforePrint
        Me.txtRankRating.Text = Me.txtRankRating.Text.ToUpper
    End Sub

    Private Sub txtForSpecifiedPeriod_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Me.txtForSpecifiedPeriod.Text = "ACTUAL DEPARTURE MANILA TO " & Me.txtLOC.Text & " MONTHS"
    End Sub
End Class