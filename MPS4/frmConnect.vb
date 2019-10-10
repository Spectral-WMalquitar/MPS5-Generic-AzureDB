Public Class frmConnect

    Public isCalledByStartup As Boolean = False
    Public bQuitApp As Boolean = False
    'Test Connection
    Private Sub cmdTestConn_Click(sender As System.Object, e As System.EventArgs) Handles cmdTestConn.Click
        'check if textServer is null
        Me.Cursor = Cursors.WaitCursor
        If Me.txtServer.Text = "" And Me.txtUser.Text = "" And Me.txtPwd.Text = "" Then
            MsgBox("Unable to test connection. Please complete the database credentials.", MsgBoxStyle.Information, GetAppName())
            If Me.txtServer.Text = "" Then
                Me.txtServer.Focus()
            ElseIf Me.txtUser.Text = "" Then
                Me.txtUser.Focus()
            ElseIf Me.txtPwd.Text = "" Then
                Me.txtPwd.Focus()
            End If
        Else
            SQLServer = Me.txtServer.Text
            SQLID = Me.txtUser.Text
            SQLPW = Me.txtPwd.Text

            MPSDB = New SQLDB(GetConnectionString())
            ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Testing Connection...")
            MPSDB.Connect()
            CloseCustomLoadScreen()

            'if MPSDB.Connect THen
            If MPSDB.Connected Then
                'edited by tony20170328
                'MsgBox("Connected to Database.", MsgBoxStyle.Information, GetAppName)
                MsgBox("Test Connection Successful!", MsgBoxStyle.Information, GetAppName)
            Else
                SQLServer = ""
                SQLPW = ""
                SQLID = ""
                'edited by tony20170328
                'MsgBox("Unable to connect to Database", MsgBoxStyle.Exclamation, GetAppName)
                Dim errMsg As String = MPSDB.GetLastErrorMessage()
                MsgBox("Test Connection Failed." & _
                       IIf(IfNull(errMsg, "").Equals(""), "", vbNewLine & vbNewLine & errMsg), MsgBoxStyle.Exclamation, GetAppName)
                If MPSDB.GetLastErrorMessage().ToString.Length > 0 Then LogErrors("(Login) Test Connection: " & MPSDB.GetLastErrorMessage())
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Me.Cursor = Cursors.WaitCursor
        ''check if null
        'If Me.txtServer.Text = "" And Me.txtUser.Text = "" And Me.txtPwd.Text = "" Then
        '    MsgBox("Please Enter Server or IP Address", MsgBoxStyle.Information, GetAppName())
        'Else
        '    SQLServer = Me.txtServer.Text
        '    SQLID = Me.txtUser.Text
        '    SQLPW = Me.txtPwd.Text
        '    MPSDB = New SQLDB(GetConnectionString())
        '    If MPSDB.Connect Then
        '        'WriteIni("SERVER", SQLServer)
        '        'WriteIni("USERID", SQLID)
        '        'WriteIni("PASSWORD", SQLPW)
        '        WriteReg("Server", SQLServer)
        '        WriteReg("USERID", SQLID)
        '        WriteReg("PASSWORD", SQLPW)
        '        Me.Close()
        '    Else
        '        SQLServer = ""
        '        SQLID = ""
        '        SQLPW = ""
        '        MsgBox("Unable to connect to Database", MsgBoxStyle.Information, GetAppName)
        '    End If
        'End If
        ''write LOCATION_ID in settings.ini
        ''WriteIni("LOCATION_ID", getLocationID())
        'Me.Cursor = Cursors.Default
        ConnectToDatabase(Me.txtServer.Text, Me.txtUser.Text, Me.txtPwd.Text, True)
    End Sub

    Private Sub ConnectToDatabase(cHost As String, cUID As String, cPWD As String, Optional ShowWaitForm As Boolean = False)
        Me.Cursor = Cursors.WaitCursor
        'check if null
        'If Me.txtServer.Text = "" And Me.txtUser.Text = "" And Me.txtPwd.Text = "" Then
        If cHost = "" And cUID = "" And cPWD = "" Then
            'MsgBox("Please Enter Server or IP Address", MsgBoxStyle.Information, GetAppName())
            MsgBox("Unable to connect. Please complete the database server credentials.", MsgBoxStyle.Information, GetAppName())
            If cHost = "" Then
                Me.txtServer.Focus()
            ElseIf cUID = "" Then
                Me.txtUser.Focus()
            ElseIf cPWD = "" Then
                Me.txtPwd.Focus()
            End If
        Else
            'SQLServer = Me.txtServer.Text
            'SQLID = Me.txtUser.Text
            'SQLPW = Me.txtPwd.Text
            SQLServer = cHost
            SQLID = cUID
            SQLPW = cPWD
            MPSDB = New SQLDB(GetConnectionString())
            If ShowWaitForm Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Connecting to database...")
            MPSDB.Connect()
            If MPSDB.Connected Then
                '<!-- tony20171108 : changed saving of database connection. use ini instead of registry
                WriteIni("SERVER", SQLServer, True)
                WriteIni("USERID", SQLID, True)
                WriteIni("PASSWORD", SQLPW, True)
                'WriteReg("Server", SQLServer)
                'WriteReg("USERID", SQLID)
                'WriteReg("PASSWORD", SQLPW)
                '-->
                Me.Close()
            Else
                If ShowWaitForm Then CloseCustomLoadScreen()
                SQLServer = ""
                SQLID = ""
                SQLPW = ""
                Dim errMsg As String = MPSDB.GetLastErrorMessage()
                MsgBox("Unable to connect to the database." & _
                       IIf(IfNull(errMsg, "").Equals(""), "", vbNewLine & vbNewLine & "Error: " & errMsg), MsgBoxStyle.Exclamation, GetAppName)
            End If
            If ShowWaitForm Then CloseCustomLoadScreen()
        End If
        'write LOCATION_ID in settings.ini
        'WriteIni("LOCATION_ID", getLocationID())
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ConnectToDatabase(ByVal dbconn As SQLDB.DBConnectionParameter)
        ConnectToDatabase(dbconn.Host, dbconn.UID, dbconn.Pwd)
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        If isCalledByStartup Then bQuitApp = True
        Application.Exit()
    End Sub

    'Loading
    Private Sub frmConnect_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CreateReg()
    End Sub


    'Create Registry File
    Private Sub CreateReg()
        Dim regFile As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\MPS4")
        If regFile Is Nothing Then 'check if the regFile Exist
            My.Computer.Registry.CurrentUser.CreateSubKey("Software\MPS4")
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(_isCalledByStartup As Boolean)
        InitializeComponent()

        isCalledByStartup = _isCalledByStartup
    End Sub

    Private Sub cmdConnectWFile_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnectWFile.Click
        Dim oOpenFileDialog As New OpenFileDialog
        'Dim dbconn As New 

        oOpenFileDialog.Filter = "MPS Database Connection|*.mdc"
        oOpenFileDialog.Title = "Open MPS Database Connection File"
        oOpenFileDialog.ShowDialog()

        If oOpenFileDialog.FileName <> "" Then
            Dim dbconn As SQLDB.DBConnectionParameter = Nothing
            Dim bSuccess As Boolean = SQLDB.ConvertMDCFileToDBConnectionOBJ(oOpenFileDialog.FileName, dbconn)

            If Not bSuccess Then Exit Sub

            ConnectToDatabase(dbconn.Host, dbconn.UID, dbconn.Pwd, True)

        End If
    End Sub

    Private Sub txtPwd_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtServer.Text <> "" Or Me.txtUser.Text <> "" Or Me.txtPwd.Text <> "" Then
                ConnectToDatabase(Me.txtServer.Text, Me.txtUser.Text, Me.txtPwd.Text)
            End If
        End If
    End Sub

End Class
