Public Class rptPOEAEmbark

    Private Sub txtMonthOf_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtMonthOf.BeforePrint
        If Me.txtPeriod.Text.Length <> 0 Then
            Me.txtMonthOf.Text = "For The Month of " & Me.txtPeriod.Text
        End If
    End Sub

    Private Sub XrLabel13_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabel13.BeforePrint
        Me.XrLabel13.Text = "Name of Agent: " & Me.txtAgent.Text
    End Sub

    Private Sub celTotalNoSeamanDeployed_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles celTotalNoSeamanDeployed.BeforePrint
        Me.celTotalNoSeamanDeployed.Text = Me.txtTotalCrew.Summary.GetResult
    End Sub

    Private Sub celEngReEng_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles celEngReEng.BeforePrint
        If Me.txtHireStatCode.Text <> 1 Then
            Me.celEngReEng.Text = "Engaged"
        Else
            Me.celEngReEng.Text = "Re-engaged"
        End If
    End Sub
End Class