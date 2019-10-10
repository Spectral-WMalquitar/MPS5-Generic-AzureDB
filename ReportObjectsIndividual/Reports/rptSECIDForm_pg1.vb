Public Class rptSECIDForm_pg1

    Private Sub txtBirthdayMM_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtBirthdayMM.BeforePrint
        Me.txtBirthdayMM.Text = Month(Me.txtBirthday.Text)
    End Sub

    Private Sub txtBirthdayDD_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtBirthdayDD.BeforePrint
        Me.txtBirthdayDD.Text = Day(Me.txtBirthday.Text)
    End Sub

    Private Sub txtBirthdayYYYY_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles txtBirthdayYYYY.BeforePrint
        Me.txtBirthdayYYYY.Text = Year(Me.txtBirthday.Text)
    End Sub

    Private Sub chkSexMale_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkSexMale.BeforePrint
        If Me.txtSex.Text = "1" Then
            chkSexMale.Checked = True
        Else
            chkSexMale.Checked = False
        End If
    End Sub

    Private Sub chkSexFemale_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkSexFemale.BeforePrint
        If Me.txtSex.Text = "0" Then
            chkSexFemale.Checked = True
        Else
            chkSexFemale.Checked = False
        End If
    End Sub



    Private Sub chkCivilStatMarried_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkCivilStatMarried.BeforePrint
        If Me.txtCivilStat.Text = "SYSCSMARRIED" Then
            chkCivilStatMarried.Checked = True
        Else
            chkCivilStatMarried.Checked = False
        End If
    End Sub

    Private Sub chkCivilStatSeperated_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkCivilStatSeperated.BeforePrint
        If Me.txtCivilStat.Text = "SYSCSSEPARATED" Then
            chkCivilStatSeperated.Checked = True
        Else
            chkCivilStatSeperated.Checked = False
        End If
    End Sub

    Private Sub chkCivilStatSingle_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkCivilStatSingle.BeforePrint
        If Me.txtCivilStat.Text = "SYSCSSINGLE" Then
            chkCivilStatSingle.Checked = True
        Else
            chkCivilStatSingle.Checked = False
        End If
    End Sub

    Private Sub chkCivilStatWidow_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles chkCivilStatWidow.BeforePrint
        If Me.txtCivilStat.Text = "SYSCSWIDOW" Then
            chkCivilStatWidow.Checked = True
        Else
            chkCivilStatWidow.Checked = False
        End If
    End Sub
End Class