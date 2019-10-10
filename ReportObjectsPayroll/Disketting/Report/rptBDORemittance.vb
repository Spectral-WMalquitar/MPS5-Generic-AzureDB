Imports Utilities

Public Class rptBDORemittance

    Private Sub celValidation_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)
        'If IfNull(Me.GetCurrentColumnValue("Validation"), "").Equals("") Then
        '    celValidation.Text = "VALID"
        'End If
    End Sub
End Class