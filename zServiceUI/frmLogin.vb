Imports zBusiness
Imports zUtil

Public Class frmLogin

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        End
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Dim Criteria As String = "Name='" & RemoveInject(txtUsr.Text) & "'"
        'Dim nUserID = oDLSQLSERVER.DLookUp("ID", oApp.GetSchemaOne & ".dbo.MSysSec_Users", Criteria)
        'Dim cPass = oDLSQLSERVER.DLookUp("Password", oApp.GetSchemaOne & ".dbo.MSysSec_Users", Criteria)
        'Dim bIsHasPermission = IIf(oDLSQLSERVER.Get_Permissions(oApp.GetSchemaOne, CInt(nUserID), "BACKUPRESTORE") = "UADT" Or oDLSQLSERVER.isUserAdmin(oApp.SchemaOne, CInt(nUserID)), True, False)
        'cPass = sysMpsUserPassword("decrypt", cPass)

        'If cPass = RemoveInject(txtPwd.Text) And bIsHasPermission And NullToZero(nUserID) <> 0 Then
        '    Valid MPS User AND has Permission
        '    Me.Close()
        '    oApp.UserID = nUserID
        '    oApp.UserName = RemoveInject(txtUsr.Text)
        '    frmMain.Show()
        'Else
        '    If Not bIsHasPermission Then
        '        not an admin
        '        MsgBox("You do not have the proper permissions to use this application.", MsgBoxStyle.Critical, "Insufficient permissions")
        '    ElseIf nUserID = 0 Or (cPass <> RemoveInject(txtPwd.Text)) Then
        '        not a valid user
        '        MsgBox("Incorrect user name or password.", MsgBoxStyle.Critical, "Invalid log in")
        '    End If
        '    Wrong password or not an MPS admin
        '    txtUsr.Focus()
        'End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        PictureEditLogo.BackColor = Color.Transparent
        lblLoginVer.Text = "Version " & Application.ProductVersion
    End Sub

End Class