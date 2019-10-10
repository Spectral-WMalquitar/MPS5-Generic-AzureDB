Public Class fdlgAdmPayrollPass
    Private DB As SQLDB
    Dim cPass As String = String.Empty

    Public Sub New(_DB As SQLDB)

        ' This call is required by the designer.
        InitializeComponent()
        DB = _DB 'Setup Database

        ' Add any initialization after the InitializeComponent() call.
        'cPass = IfNull(DB.GetConfig(PAYROLL_UNLOCK_KEY), DEFAULT_PASSWORD)
        cPass = IIf(DB.GetConfig(PAYROLL_UNLOCK_KEY).Trim.Length > 0, DB.GetConfig(PAYROLL_UNLOCK_KEY), DEFAULT_PASSWORD)
        If cPass.Equals(DEFAULT_PASSWORD) Then
            LayoutControlItem1.Text = "Please enter old password [Default: " & DEFAULT_PASSWORD & "]:"
            txtOldPW.Text = DEFAULT_PASSWORD
            txtOldPW.ReadOnly = True
            txtNewPW.Focus()
        Else
            LayoutControlItem1.Text = "Please enter old password:"
            txtOldPW.ReadOnly = False
            txtOldPW.Focus()
        End If
    End Sub
    'Cancel
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub


    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        If SetPayrollPassword() Then
            If DB.SaveConfig(PAYROLL_UNLOCK_KEY, AES_Encrypt(txtNewPW.Text, PAYROLL_UNLOCK_KEY)) Then
                MsgBox("Password changed.", MsgBoxStyle.Information, GetAppName)
                Me.Close()
            End If
        End If
    End Sub

    Private Function SetPayrollPassword() As Boolean
        Dim info As Boolean = False
        If Len(IfNull(txtOldPW.Text, String.Empty).Trim) > 0 Or Len(IfNull(txtOldPW.Text, String.Empty).Trim) > 0 Or Len(IfNull(txtOldPW.Text, String.Empty).Trim) > 0 Then
            If cPass.Equals(DEFAULT_PASSWORD) Then
                If txtNewPW.Text.Equals(txtCPW.Text) Then
                    info = True
                Else
                    info = False
                    MsgBox("Password mismatch.", MsgBoxStyle.Exclamation, GetAppName)
                End If
            Else
                Dim decryptedPass As String = AES_Decrypt(cPass, PAYROLL_UNLOCK_KEY)
                If decryptedPass.Equals(txtOldPW.Text) Then
                    If txtNewPW.Text.Equals(txtCPW.Text) Then
                        If decryptedPass.Equals(txtNewPW.Text) Then
                            info = False
                            MsgBox("New password is the same with the old password.", MsgBoxStyle.Exclamation, GetAppName)
                        Else
                            info = True
                        End If
                    Else
                        info = False
                        MsgBox("Password mismatch.", MsgBoxStyle.Exclamation, GetAppName)
                    End If
                Else
                    info = False
                    MsgBox("Old password mismatch.", MsgBoxStyle.Exclamation, GetAppName)
                End If
            End If
        Else
            info = False
            MsgBox("Please enter correct values.", MsgBoxStyle.Exclamation, GetAppName)
        End If
        Return info
    End Function


End Class