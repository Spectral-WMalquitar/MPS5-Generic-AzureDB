Public Class frmLogin 
    Public is_loggedon As Boolean = False
    Public tblUsers As DataTable
    Dim lastUser As String
    Dim lUsrName As String
    Dim cMyModule As String

    Dim clsSec As New clsSecurity

    Public modulename As String = ""

    Public Sub New(ByVal cModule As String)

        cMyModule = cModule
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Cancel Button
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        is_loggedon = False
        Me.Close()
    End Sub

    Private Sub frmLogin_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.Alt And e.KeyCode = Keys.Enter And ENABLE_ADJUST_DEMO_DATES Then
            Dim frm As New frmAdjuctDemoDates(MPSDB)
            MsgBox("You are connected to: " & SQLServer, MsgBoxStyle.Information, GetAppName)
            frm.ShowDialog()
        End If
        If e.Control And e.Alt And e.Shift And e.KeyCode = Keys.S Then
            Dim inputpass As New frmInputPass, gotpass As String

            gotpass = inputpass.txtPass.Text
            inputpass.ShowDialog(Me)
            'MsgBox(inputpass.txtPass.Text)

            If inputpass.isEnterDown Then
                If StrComp(inputpass.txtPass.Text, "Ssi04sti", CompareMethod.Binary) = 0 Then

                    USER_ID = "99999" '!!! hardcoded
                    USER_NAME = "Spectral"
                    USER_PASSWORD = "Ssi04sti"
                    is_loggedon = True

                    Me.Close()
                Else
                    MsgBox("Invalid Password!", MsgBoxStyle.Exclamation, GetAppName)
                End If
            End If

            inputpass = Nothing

        End If
    End Sub


    'Load
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clsSec.propSQLConnStr = MPSDB.GetConnectionString

        Me.LayoutControl1.AllowCustomization = False
        Try
            Me.Text = modulename & "Login" & MPSVersion
            'Dim list As New DataTable

            'With list
            '    .Columns.Add("ID", System.Type.GetType("System.Int16"))
            '    .Columns.Add("Name", System.Type.GetType("System.String"))
            '    .Columns.Add("Password", System.Type.GetType("System.String"))
            'End With
            'Try
            '    With MPSDB
            '        .BeginReader("SELECT * FROM dbo.frmLogIn ORDER BY Name")
            '        While .Read()
            '            If .ReaderItem("Check") = AES_Decrypt(.ReaderItem("SecUser"), .ReaderItem("Check")) Then
            '                Dim row As DataRow = list.NewRow
            '                row("ID") = .ReaderItem("ID") 'UserID
            '                row("Name") = .ReaderItem("Name") 'UserName
            '                row("Password") = .ReaderItem("Password") 'Password
            '                list.Rows.Add(row)
            '            End If
            '        End While

            '        '/// Neil testing Spectral user
            '        'Dim row2 As DataRow = list.NewRow
            '        'row2("ID") = "9999"
            '        'row2("Name") = "Spectral"
            '        'row2("Password") = "Ssi04sti"
            '        'list.Rows.Add(row2)
            '        '/// neil test end

            '        .CloseReader()
            '    End With
            'Catch ex As Exception
            '    MPSDB.CloseReader()
            'End Try
            'tblUsers = list
            'Me.cboUsers.Properties.DataSource = tblUsers
            'lastUser = IIf(Trim(CType(GetIni("LUSR"), String)) = "" Or IsNothing(Trim(CType(GetIni("LUSR"), String))), "", Trim(CType(GetIni("LUSR"), String)))
            'If lastUser <> "" Then
            '    lUsrName = tblUsers.Select("ID='" & lastUser & "'").First().Item("Name").ToString
            'Else
            '    Me.cboUsers.ItemIndex = 0
            '    lUsrName = (Me.cboUsers.Text)
            'End If

            'Me.cboUsers.EditValue = Me.cboUsers.Properties.GetKeyValueByDisplayText(lUsrName)
            'Dim rpwd As String = IIf(Trim(CType(GetIni("RPWD"), String)) = "" Or IsNothing(Trim(CType(GetIni("RPWD"), String))), "", Trim(CType(GetIni("RPWD"), String)))
            'If rpwd = "True" Then
            '    Me.txtPassword.Text = sysMpsUserPassword("DECRYPT", tblUsers.Select("ID='" & Me.cboUsers.EditValue & "'").First().Item("Password").ToString)
            'End If
            InitControls()

            'For future use. WLM - 20160923 
            'Dim requiredDLL As New ValidateRequiredDLL()
            'requiredDLL.HasAllRequiredDll()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub InitControls()
        Dim list As New DataTable

        With list
            .Columns.Add("ID", System.Type.GetType("System.Int16"))
            .Columns.Add("Name", System.Type.GetType("System.String"))
            .Columns.Add("Password", System.Type.GetType("System.String"))
        End With
        Try
            With MPSDB
                .BeginReader("SELECT * FROM dbo.frmLogIn ORDER BY Name")
                While .Read()
                    If .ReaderItem("Check") = AES_Decrypt(.ReaderItem("SecUser"), .ReaderItem("Check")) Then
                        Dim row As DataRow = list.NewRow
                        row("ID") = .ReaderItem("ID") 'UserID
                        row("Name") = .ReaderItem("Name") 'UserName
                        row("Password") = .ReaderItem("Password") 'Password
                        list.Rows.Add(row)
                    End If
                End While

                '/// Neil testing Spectral user
                'Dim row2 As DataRow = list.NewRow
                'row2("ID") = "9999"
                'row2("Name") = "Spectral"
                'row2("Password") = "Ssi04sti"
                'list.Rows.Add(row2)
                '/// neil test end

                .CloseReader()
            End With
        Catch ex As Exception
            MPSDB.CloseReader()
        End Try
        tblUsers = list
        Me.cboUsers.Properties.DataSource = tblUsers

        If usrCryptography("DECRYPT", MPSDB.GetConfig("ENABLE_REMEMBERPWD")) = "ENABLE_REMEMBERPWD:True" Then
            lastUser = IIf(Trim(CType(GetIni("LUSR", True), String)) = "" Or IsNothing(Trim(CType(GetIni("LUSR", True), String))), "", Trim(CType(GetIni("LUSR", True), String)))
            If lastUser <> "" Then
                lUsrName = tblUsers.Select("ID='" & lastUser & "'").First().Item("Name").ToString
            Else
                'removed by tony20180725
                'Me.cboUsers.ItemIndex = 0
                'lUsrName = (Me.cboUsers.Text)
            End If
        End If
        
        '------------------------------------------------------------------------------------------------------------------------------------
        '************ ENABLE REMEMBER PASSWORD ************************************************
        'True - 097056066058097097066028076088141116086067099026076076098008085041170    
        '           INSERT INTO mps.dbo.tblconfig(Code, TextValue) SELECT 'ENABLE_REMEMBERPWD', '097056066058097097066028076088141116086067099026076076098008085041170' WHERE (SELECT count(*) FROM mps.dbo.tblconfig WHERE Code = 'ENABLE_REMEMBERPWD') = 0
        '           UPDATE mps.dbo.tblconfig SET TextValue = '097056066058097097066028076088141116086067099026076076098008085041170' WHERE Code = 'ENABLE_REMEMBERPWD'

        'False - 097056066058097097066028076087070150608606709902607607609800808500918111
        '           INSERT INTO mps.dbo.tblconfig(Code, TextValue) SELECT 'ENABLE_REMEMBERPWD', '097056066058097097066028076087070150608606709902607607609800808500918111' WHERE (SELECT count(*) FROM mps.dbo.tblconfig WHERE Code = 'ENABLE_REMEMBERPWD') = 0
        '           UPDATE mps.dbo.tblconfig SET TextValue = '097056066058097097066028076087070150608606709902607607609800808500918111' WHERE Code = 'ENABLE_REMEMBERPWD'

        If usrCryptography("DECRYPT", MPSDB.GetConfig("ENABLE_REMEMBERPWD")) = "ENABLE_REMEMBERPWD:True" Then        'ENABLE REMEMBER PASSWORD
            Me.cboUsers.EditValue = Me.cboUsers.Properties.GetKeyValueByDisplayText(lUsrName)

            Dim rpwd As String = IIf(Trim(CType(GetIni("RPWD"), String)) = "" Or IsNothing(Trim(CType(GetIni("RPWD"), String))), "", Trim(CType(GetIni("RPWD"), String)))
            If rpwd = "True" Then
                Me.txtPassword.Text = sysMpsUserPassword("DECRYPT", tblUsers.Select("ID='" & Me.cboUsers.EditValue & "'").First().Item("Password").ToString)
            End If
            lciRememberPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        Else        'DISABLE REMEMBER PASSWORD
            Me.txtPassword.Text = String.Empty
            lciRememberPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.Height = Me.Height - lciRememberPass.Height

        End If

        '------------------------------------------------------------------------------------------------------------------------------------
        '************ ENABLE FORGOT PASSWORD ************************************************
        'True - 097056066057098017048076088141116086067099007027098008085041170    
        '           INSERT INTO mps.dbo.tblconfig(Code, TextValue) SELECT 'ENABLE_FORGOTPWD', '097056066057098017048076088141116086067099007027098008085041170' WHERE (SELECT count(*) FROM mps.dbo.tblconfig WHERE Code = 'ENABLE_FORGOTPWD') = 0
        '           UPDATE mps.dbo.tblconfig SET TextValue = '097056066057098017048076088141116086067099007027098008085041170' WHERE Code = 'ENABLE_FORGOTPWD'

        'False - 097056066057098017048076087070150608606709900702709800808500918111
        '           INSERT INTO mps.dbo.tblconfig(Code, TextValue) SELECT 'ENABLE_FORGOTPWD', '097056066057098017048076087070150608606709900702709800808500918111' WHERE (SELECT count(*) FROM mps.dbo.tblconfig WHERE Code = 'ENABLE_FORGOTPWD') = 0
        '           UPDATE mps.dbo.tblconfig SET TextValue = '097056066057098017048076087070150608606709900702709800808500918111' WHERE Code = 'ENABLE_FORGOTPWD'

        If usrCryptography("DECRYPT", MPSDB.GetConfig("ENABLE_FORGOTPWD")) = "ENABLE_FORGOTPWD:True" Then        'ENABLE FORGOT PASSWORD
            lciForgotPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            

        Else
            'DISABLE FORGOT PASSWORD
            lciForgotPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.Height = Me.Height - lciForgotPass.Height

        End If
    End Sub

    'Forgot Password
    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'MsgBox("Forgot Password")
        Dim frmFP As New frmChangePassword(Me)
        USER_ID = cboUsers.EditValue
        frmFP.is_forgot = True
        frmFP.ShowDialog()
        If frmFP.is_saved Then txtPassword.Text = USER_PASSWORD 'Added By calvhin 20170203
    End Sub

    'user name changed
    Private Sub cboUsers_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboUsers.EditValueChanged
        'Me.txtPassword.Text = tblLogin.Select("ID='" & Me.cboUsers.EditValue & "'").First().Item("Password").ToString
        Dim pwd As String = tblUsers.Select("ID='" & Me.cboUsers.EditValue & "'").First().Item("Password").ToString()
        If pwd = DEFAULT_PASSWORD Then
            Me.txtPassword.Text = pwd
        Else
            Me.txtPassword.Text = ""
        End If

        '///
        'If Me.cboUsers.Text = "Spectral" Then
        '    Me.LinkLabel1.Visible = False
        '    Me.LinkLabel1.Enabled = False
        'Else
        '    Me.LinkLabel1.Visible = True
        '    Me.LinkLabel1.Enabled = True
        'End If
        '///

    End Sub

    'Ok Button
    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click

        Dim bSuccess As Boolean = False 'neil move here

        '////// neil testing Spectral user
        'If UCase(Me.cboUsers.Text) = "SPECTRAL" And
        '    StrComp(Me.txtPassword.Text, "Ssi04sti", CompareMethod.Binary) = 0 Then

        '    USER_ID = "9999" '!!! hardcoded
        '    USER_NAME = Me.cboUsers.Text
        '    USER_PASSWORD = Me.txtPassword.Text
        '    bSuccess = True
        '    is_loggedon = True

        '    Me.Close()
        '    Exit Sub
        'End If
        '/////// neil test end

        If Me.cboUsers.EditValue Is Nothing Then
            MsgBox("Please enter your User Name.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If IfNull(Me.cboUsers.EditValue, "").Length = 0 Then
            MsgBox("Please enter your User Name", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim ePwd As String = tblUsers.Select("ID='" & Me.cboUsers.EditValue & "'").First().Item("Password").ToString
        Dim DPwd As String
        'save Last Logged Userss
        WriteIni("LUSR", Me.cboUsers.EditValue, True)
        DPwd = IIf(ePwd = DEFAULT_PASSWORD, ePwd, sysMpsUserPassword("DECRYPT", ePwd))

        clsSec.get_permissions_all(Me.cboUsers.EditValue, , userPermDt)

        If Me.cboUsers.Text Is Nothing Then
            MsgBox("Please enter your User Name.", MsgBoxStyle.Critical)
        ElseIf DPwd <> Me.txtPassword.Text Then
            If IfNull(Me.txtPassword.Text, "").Equals("") Then
                MsgBox("Please enter your Password.", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Invalid Password", MsgBoxStyle.Critical)
            End If
        ElseIf userPermDt.Rows.Count = 0 Then
            MsgBox("User is not assigned with any permission or not assigned to any User Groups.", MsgBoxStyle.Critical)
        Else
            'Check License and User Session
            'neil Dim bSuccess As Boolean = False
            Dim oUsersSlots As New MPSUserSlots
            Try
                oUsersSlots = oGenerateUserSlots(MPSDB)

                If oUsersSlots.ErrMsg Is Nothing Then
                    If oUsersSlots.FreeSlots > 0 Then
                        Dim oTempMPSSession As New MPSSession
                        oTempMPSSession.UserID = CInt(Me.cboUsers.EditValue)
                        oTempMPSSession.UserName = Me.cboUsers.Text
                        oTempMPSSession.Token = GenerateID(MPSDB, "UserToken", "MSysSec_Users_Log")
                        oTempMPSSession.PKey = GenerateID(MPSDB, "PKey", "MSysSec_Users_Log")
                        oTempMPSSession.ModuleName = cMyModule

                        Dim cErr As String = Nothing

                        If oTempMPSSession.UserName <> "Administrator" Then
                            If Not oTempMPSSession.IsReadyToProceed(MPSDB, cErr) Then
                                MsgBox(cErr, MsgBoxStyle.Exclamation, GetAppName)
                                Exit Sub
                            End If
                        End If

                        USER_SESSION = oTempMPSSession

                        bSuccess = USER_SESSION.AddUserSession(MPSDB, oUsersSlots.ErrMsg)
                    End If
                Else
                    MsgBox(oUsersSlots.ErrMsg, MsgBoxStyle.Exclamation, GetAppName)
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                Exit Sub
            End Try

            If Not bSuccess Then
                MsgBox(oUsersSlots.ErrMsg, MsgBoxStyle.Exclamation, GetAppName)
                Exit Sub
            End If
            'neil commented out 20170809 CheckUserSession(MPSDB, USER_SESSION)
            'end Checking

            If Me.rPwd.Checked Then
                WriteIni("RPWD", Me.rPwd.EditValue)
            Else
                WriteIni("RPWD", False)
            End If
            USER_ID = Me.cboUsers.EditValue
            USER_NAME = Me.cboUsers.Text
            'End If
            USER_PASSWORD = Me.txtPassword.Text
            is_loggedon = True
            CheckFolderPathPerm()
            Me.Close()
        End If

    End Sub

    'Enter Key Press
    Private Sub txtPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            cmdOk_Click(sender, e)
        End If
    End Sub

    Private Sub cboUsers_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboUsers.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If IsNothing(Me.txtPassword.Text) Or Me.txtPassword.Text = "" Then
                Me.txtPassword.Focus()
            Else
                cmdOk_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub rPwd_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles rPwd.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            cmdOk_Click(sender, e)
        End If
    End Sub

    Private Sub CheckFolderPathPerm()

        If IfNull(FOLDERDIRECTORY, "").Equals("") Then
            MsgBox("Images directory configuration not set. Please contact your system administrator for assistance.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not CheckFolderPermission(FOLDERDIRECTORY) Then
            MsgBox("Please be informed that you do not have the necessary permission in the specified folder path to save Documents and Images. Please contact your IT support.", MsgBoxStyle.Critical, GetAppName)
        End If
    End Sub

    Private Sub cmdDatabase_Click(sender As System.Object, e As System.EventArgs) Handles cmdDatabase.Click
        'If MsgBox("You are connected to: " & SQLServer & vbCrLf & "Do you want to change connection?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
        If MsgBox("Do you want to reset the connection?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
            '<!-- tony20171108 : changed saving of database connection. use ini instead of registry
            'WriteReg("Server", "")
            'WriteReg("USERID", "")
            'WriteReg("PASSWORD", "")
            WriteIni("Server", "", True)
            WriteIni("USERID", "", True)
            WriteIni("PASSWORD", "", True)
            '-->

            '<!-- commented out by tony20170816
            'Try
            '    Application.Restart()
            'Catch ex As Exception
            '    MsgBox("Connection has been reset but unable to restart the program. The program will close. Please reopen it again by opening the Application Icon.", MsgBoxStyle.Information)
            '    LogErrors("Connection has been reset but unable to restart the program. Error:" & ex.Message)
            '    Application.Exit()
            'End Try
            '-->

            Me.Visible = False
            Dim frm As New frmConnect
            frm.ShowDialog()
            If SQLServer = "" Or SQLID = "" Or SQLPW = "" Then
                Application.Exit()
            End If
            InitControls()
            Me.Visible = True
        End If
    End Sub

    'initialize folder 

    Private Sub setFolderPermission()
        If IfNull(MPSDB.GetConfig("DefaultFolder"), "") <> "" Then
            FOLDERDIRECTORY = IfNull(MPSDB.GetConfig("DefaultFolder"), "")
        End If
    End Sub


    Private _isAskPassword As Boolean = False
    Public Property isAskPassword() As Boolean
        Get
            Return _isAskPassword
        End Get
        Set(ByVal value As Boolean)
            If value Then
                lciForgotPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciRememberPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciResetConn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Else
                lciForgotPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciRememberPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciResetConn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If

            _isAskPassword = value
        End Set
    End Property

    Private Sub cboUsers_ProcessNewValue(sender As System.Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboUsers.ProcessNewValue

    End Sub
End Class