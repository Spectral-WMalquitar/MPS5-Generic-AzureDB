Public Class rptPaySASummaryReportCrew

    Private Sub MCodeGroup_AfterPrint(sender As Object, e As System.EventArgs) Handles CrewGroup.AfterPrint

    End Sub

    Private Sub MCodeGroup_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CrewGroup.BeforePrint
        'If Me.txtPeriod.Text <> "Period" Then
        '    Me.txtPeriodCopy.Text = DateSerial(txtPeriod.Text.Substring(0, 4), txtPeriod.Text.Substring(4, 2), 0)
        'End If
        'If Me.txtPeriod.Text <> "Period" Then
        '    Dim strDate As New DateTime(1, Me.txtPeriod.Text.Substring(4, 2), 1)
        '    Me.txtPeriodCopy.Text = strDate.ToString("MMMM") & Me.txtPeriod.Text.Substring(0, 4)
        'End If
    End Sub

    Private Sub rptPaySASummaryReportCrew_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

    End Sub
End Class