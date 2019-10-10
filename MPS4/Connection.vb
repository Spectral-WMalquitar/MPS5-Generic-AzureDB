Public Class Connection

    Dim clsAudit As New clsAudit

    Private Sub txtServer_EditValueChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub LabelControl2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Connection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '<!-- tony20171108 : changed saving of database connection. use ini instead of registry
        'Me.txtServer.Text = IfNull(GetReg("SERVER"), String.Empty)
        Me.txtServer.Text = IfNull(GetIni("SERVER", True), String.Empty)
        '-->
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        If MsgBox("Do you want to restart MPS and reset the connection?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then

            Dim auditlogid As Long 'neil
            clsAudit.propSQLConnStr = MPSDB.GetConnectionString 'neil
            clsAudit.saveAuditLog("User Reset MPS Connection", USER_NAME, auditlogid, System.Environment.MachineName, 0, , , , , , "MPS Crewing") 'neil

            '<!-- tony20171108 : changed saving of database connection. use ini instead of registry
            'WriteReg("Server", "")
            'WriteReg("USERID", "")
            'WriteReg("PASSWORD", "")
            WriteIni("Server", "", True)
            WriteIni("USERID", "", True)
            WriteIni("PASSWORD", "", True)
            '-->
            

            'Application.Exit()
            'For i As Integer = 0 To Application.OpenForms.Count - 1
            '    If Application.OpenForms(i).Name <> Me.Name And Application.OpenForms(i).Name <> "frmCrewMain" Then
            '        Application.OpenForms(i).Dispose()
            '    End If
            'Next
            'For Each f As Form In Application.OpenForms
            '    If f.Name <> Me.Name And f.Name <> "frmCrewmanin" Then
            '        'f.Close()
            '        f = Nothing
            '    End If
            'Next


            'Application.Exit()
            'Process.Start(Application.ExecutablePath)
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox("You are running in DEBUG mode. The connection has been reset but the program will not be able to restart properly." & vbNewLine & vbNewLine & "The program will close. Just re-open it manually.", MsgBoxStyle.Information)
                Application.Exit()
            Else
                Application.Restart()
            End If


            'Parent.Visible = False
            'Dim logfrm As New frmLogin("CREWING")

            'CloseCustomLoadScreen()

            'logfrm.ShowDialog(Me)
        End If
    End Sub
End Class
