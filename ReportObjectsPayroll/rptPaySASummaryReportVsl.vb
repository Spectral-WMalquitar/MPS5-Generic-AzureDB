Public Class rptPaySASummaryReportVsl

    Private Sub MCodeGroup_AfterPrint(sender As Object, e As System.EventArgs) Handles MCodeGroup.AfterPrint
       
    End Sub

    Private Sub MCodeGroup_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles MCodeGroup.BeforePrint
        'If Me.txtPeriod.Text <> "Period" Then
        '    Me.txtPeriodCopy.Text = DateSerial(txtPeriod.Text.Substring(0, 4), txtPeriod.Text.Substring(4, 2), 0)
        'End If
        'If Me.txtPeriod.Text <> "Period" Then
        '    Dim strDate As New DateTime(1, Me.txtPeriod.Text.Substring(4, 2), 1)
        '    Me.txtPeriodCopy.Text = strDate.ToString("MMMM") & Me.txtPeriod.Text.Substring(0, 4)
        'End If
    End Sub

    Private Sub rptPaySASummaryReportVsl_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

    End Sub
End Class