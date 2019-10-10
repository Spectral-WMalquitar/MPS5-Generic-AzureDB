Public Class rptAppraisalSummary

    Private Sub celGrade_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles celGrade.BeforePrint
        Select Case celOverallScore.Text
            Case 1
                Me.celGrade.Text = "Very Poor"
            Case 2
                Me.celGrade.Text = "Below Average"
            Case 3
                Me.celGrade.Text = "Average"
            Case 4
                Me.celGrade.Text = "Good"
            Case 5
                Me.celGrade.Text = "Very Good"
            Case Else
                Me.celGrade.Text = ""
        End Select
    End Sub
End Class