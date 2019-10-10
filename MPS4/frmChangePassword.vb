Public Class frmChangePassword 
    Public is_saved As Boolean = False
    Public is_forgot As Boolean = False
    Dim question As String = MPSDB.DLookUp("SecQuestion", "MSysSec_Users", "", "ID='" & USER_ID & "'")
    Public Sub New(parentForm As Form)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Icon = parentForm.Icon
    End Sub
    'save button
    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click

        ' Dim neil ans = MPSDB.DLookUp("SecAnswer", "MSysSec_Users", "", "ID='" & USER_ID & "'")
        Dim ans = sysMpsUserPassword("decrypt", MPSDB.DLookUp("SecAnswer", "MSysSec_Users", "", "ID='" & USER_ID & "'"))

        If is_forgot Then
            question = MPSDB.DLookUp("SecQuestion", "MSysSec_Users", "", "ID='" & USER_ID & "'")
            'neil ans = MPSDB.DLookUp("SecAnswer", "MSysSec_Users", "", "ID='" & USER_ID & "'")
            ans = sysMpsUserPassword("decrypt", MPSDB.DLookUp("SecAnswer", "MSysSec_Users", "", "ID='" & USER_ID & "'"))
        Else
            'neil question = MPSDB.DLookUp("SecQuestion", "MSysSec_Users", "", "ID='" & USER_ID & "'")
            'neil ans = MPSDB.DLookUp("SecAnswer", "MSysSec_Users", "", "ID='" & USER_ID & "'")
        End If

        If Me.txtSecAnswer.Text = "" Then 'Edited by calvhin 20170203, Before: If Me.cboSecQuestion.EditValue Is Nothing Then
            MsgBox("Please input answer for security question.", MsgBoxStyle.Critical, GetAppName)
        Else
            If is_forgot Then
                If lcgNewPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
                    If ans.Equals(Me.txtSecAnswer.Text) And question.Equals(cboSecQuestion.EditValue) Then
                        'Added By calvhin 20170203
                        lcgNewPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        lcgQuestion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        txtOldPassword.Text = DEFAULT_PASSWORD
                        USER_PASSWORD = DEFAULT_PASSWORD
                        LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

                        'Commented by calvhin 20170203
                        'If MsgBox("Are you sure you want to reset your password?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
                        '    MPSDB.RunSql("Update dbo.MSysSec_Users set Password='" & DEFAULT_PASSWORD & "'  WHERE  ID=" & USER_ID)
                        '    'MPSDB.RunSql("Update dbo.MSysSec_Users set Password='" & DEFAULT_PASSWORD & "' , SecQuestion='" & cboSecQuestion.EditValue & "', SecAnswer='" & txtSecAnswer.Text & "'  WHERE  ID=" & USER_ID)
                        '    'MPSDB.RunSql("Update dbo.MSysSec_Users set Password='" & DEFAULT_PASSWORD & "'   WHERE  ID=" & USER_ID)
                        MsgBox("Your password is : " & sysMpsUserPassword("decrypt", MPSDB.DLookUp("Password", "MSysSec_Users", "", "ID='" & USER_ID & "'")), vbInformation)
                        is_saved = True 'uncommented out neil
                        '    MsgBox("Password Changed.", MsgBoxStyle.Information, GetAppName)
                        Me.Close() 'uncommented out neil
                        'End If
                        'end calvhin
                    Else
                        MsgBox("Invalid Question or Answer.", MsgBoxStyle.Critical, GetAppName)
                    End If
                Else 'Else part added by calvhin 20170203
                    GoTo GoHereForgotPass
                End If
            Else
                'neil commented out
                'If USER_PASSWORD <> DEFAULT_PASSWORD Then

                'If (question <> Me.cboSecQuestion.EditValue) Or (ans <> Me.txtSecAnswer.Text) Then
                '    MsgBox("The question or the answer is incorrect", MsgBoxStyle.Critical, GetAppName)
                'Else
                '    If Me.txtOldPassword.Text <> USER_PASSWORD Then
                '        MsgBox("The current password you entered is invalid.", MsgBoxStyle.Critical, GetAppName)
                '    ElseIf Me.txtNewPass.Text = Me.txtOldPassword.Text Then
                '        MsgBox("The new password should not be the same as the old password.", MsgBoxStyle.Critical, GetAppName)
                '    ElseIf Me.txtNewPass.Text <> Me.txtConfirmPassword.Text Then
                '        MsgBox("The new and confirm passwords do not match.", MsgBoxStyle.Critical, GetAppName)
                '    ElseIf Me.txtNewPass.Text.Length < 4 Then
                '        MsgBox("The new password should be at least 4 characters.", MsgBoxStyle.Critical, GetAppName)
                '    Else
                '        MPSDB.RunSql("Update dbo.MSysSec_Users set Password='" & sysMpsUserPassword("encrypt", Me.txtNewPass.Text) & "'   WHERE  ID=" & USER_ID)
                '        USER_PASSWORD = txtNewPass.Text
                '        is_saved = True
                '        MsgBox("Password Changed", MsgBoxStyle.Information, GetAppName)
                '        Me.Close()
                '    End If
                'End If
                'Else
GoHereForgotPass:  'Added by calvhin 20170203
                If Me.txtOldPassword.Text <> USER_PASSWORD Then
                    MsgBox("The current password you entered is invalid.", MsgBoxStyle.Critical, GetAppName)
                ElseIf Me.txtNewPass.Text = Me.txtOldPassword.Text Then
                    MsgBox("The new password should not be the same as the old password.", MsgBoxStyle.Critical, GetAppName)
                ElseIf Me.txtNewPass.Text <> Me.txtConfirmPassword.Text Then
                    MsgBox("The new and confirm passwords do not match.", MsgBoxStyle.Critical, GetAppName)
                ElseIf Me.txtNewPass.Text.Length < 4 Then
                    MsgBox("The new password should be at least 4 characters.", MsgBoxStyle.Critical, GetAppName)
                Else
                    'MPSDB.RunSql("Update dbo.MSysSec_Users set Password='" & sysMpsUserPassword("encrypt", Me.txtNewPass.Text) & "'  WHERE  ID=" & USER_ID)
                    'neil MPSDB.RunSql("Update dbo.MSysSec_Users set Password='" & sysMpsUserPassword("encrypt", Me.txtNewPass.Text) & "' , SecQuestion='" & cboSecQuestion.EditValue & "', SecAnswer='" & txtSecAnswer.Text & "'  WHERE  ID=" & USER_ID)
                    MPSDB.RunSql("Update dbo.MSysSec_Users set Password='" & sysMpsUserPassword("encrypt", Me.txtNewPass.Text) & "' , SecQuestion='" & cboSecQuestion.EditValue & "', SecAnswer='" & sysMpsUserPassword("encrypt", txtSecAnswer.Text) & "'  WHERE  ID=" & USER_ID)

                    USER_PASSWORD = txtNewPass.Text
                    is_saved = True
                    MsgBox("Password Changed", MsgBoxStyle.Information, GetAppName)
                    Me.Close()
                End If
            End If
        End If
        'End If

    End Sub

    'Cancel button
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
        'If Not is_forgot Then
        '    Me.Close()
        'Else
        '    Application.Exit()
        'End If
    End Sub

    'Load
    Private Sub frmChangePassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.LayoutControl1.AllowCustomization = False
        If is_forgot Then
            Me.Text = "Reset Password"
            Me.lcgNewPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            lcgQuestion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.cmdSave.Text = "OK"
            Me.lciSQ.Text = "Password Recovery Question"
        Else
            lcgNewPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            lcgQuestion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.cmdSave.Text = "Save"
            Me.lciSQ.Text = "Setup Password Recovery Question"
        End If

        Me.cboSecQuestion.Properties.DataSource = SecQuestion()
        Me.cboSecQuestion.EditValue = MPSDB.DLookUp("SecQuestion", "MSysSec_Users", "1", "ID =" & USER_ID)
        If USER_PASSWORD = DEFAULT_PASSWORD Then
            Me.txtOldPassword.Text = USER_PASSWORD
        End If
    End Sub

    'Confirm textbox KeyPress Enter
    Private Sub txtConfirmPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtConfirmPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtSecAnswer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSecAnswer.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub cboSecQuestion_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles cboSecQuestion.ParseEditValue
        Try
            Try
                e.Value = Convert.ToString(e.Value)
                e.Handled = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboSecQuestion_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboSecQuestion.QueryPopUp
        If is_forgot Then
            e.Cancel = True
        Else

        End If
    End Sub
End Class