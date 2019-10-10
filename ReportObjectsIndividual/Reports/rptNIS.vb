Public Class rptNIS

    Private Sub XrTableCell13_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)

    End Sub

    Private Sub txtFirstNMiddleName_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtFirstNMiddleName.BeforePrint
        Me.txtFirstNMiddleName.Text = Me.txtFirstname.Text & ", " & Me.txtMiddleName.Text
    End Sub

    Private Sub chkMale_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkMale.BeforePrint
        If Me.txtSexCode.Text = "1" Then
            Me.chkMale.Checked = True
        Else
            Me.chkMale.Checked = False
        End If
    End Sub

    Private Sub chkFemale_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkFemale.BeforePrint
        If Me.txtSexCode.Text = "0" Then
            Me.chkFemale.Checked = True
        Else
            Me.chkFemale.Checked = False
        End If
    End Sub

    Private Sub chkSingle_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkSingle.BeforePrint
        If Me.txtMaritalStat.Text = "SYSCSSINGLE" Then
            Me.chkSimplifiedReg.Checked = True
        Else
            Me.chkSimplifiedReg.Checked = False
        End If
    End Sub

    Private Sub chkMarried_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkMarried.BeforePrint
        If Me.txtMaritalStat.Text = "SYSCSMARRIED" Then
            Me.chkMarried.Checked = True
        Else
            Me.chkMarried.Checked = False
        End If
    End Sub

    Private Sub chckSeperated_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chckSeperated.BeforePrint
        If Me.txtMaritalStat.Text = "SYSCSSEPARATED" Then
            Me.chckSeperated.Checked = True
        Else
            Me.chckSeperated.Checked = False
        End If
    End Sub

    Private Sub chkDivorced_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkDivorced.BeforePrint
        If Me.txtMaritalStat.Text = "SYSCSDIVORCE" Then
            Me.chkDivorced.Checked = True
        Else
            Me.chkDivorced.Checked = False
        End If
    End Sub

    Private Sub chkWidower_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkWidower.BeforePrint
        If Me.txtMaritalStat.Text = "SYSCSWIDOW" Then
            Me.chkWidower.Checked = True
        Else
            Me.chkWidower.Checked = False
        End If
    End Sub
End Class