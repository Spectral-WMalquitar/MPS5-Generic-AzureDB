Public Class rptPOEADisembark

    Private Sub txtNameofAgent_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtNameofAgent.BeforePrint
        Me.txtNameofAgent.Text = "Name of Agent: " & Me.txtAgent.Text
    End Sub

    Private Sub txtMonthOf_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtMonthOf.BeforePrint
        If Me.txtPeriod.Text.Length <> 0 Then
            Me.txtMonthOf.Text = Me.txtPeriod.Text
        End If
    End Sub
End Class