Public Class frmActivate

    Dim strLictype As String = Nothing
    Dim MyLicense As New MPSLicense
    Dim MyLicenseStatus As New MyLicenseStatus
    Public Sub New(Optional ByVal xStrLicenseType As String = Nothing, Optional ByVal xMylicense As MPSLicense = Nothing, Optional ByVal xMyLicenseStatus As MyLicenseStatus = Nothing)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If xStrLicenseType = Nothing Then
        Else
            strLictype = xStrLicenseType
            MyLicense = xMylicense
            MyLicenseStatus = xMyLicenseStatus
        End If

    End Sub

    Private Sub frmActivate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Added by Elmer
        Dim bSuccess As Boolean = True

        If strLictype = Nothing Then
            strLictype = LicensingGetConfig("LTYPE", mps5_app)
            strLictype = sysMpsUserPassword("DECRYPT", strLictype)

            If strLictype = "" Then
                strLictype = "NO"
            End If

            MyLicenseStatus = xValidateLicense(mps5_app, strLictype, MyLicense)
            If MyLicenseStatus.ErrMsg <> "NETWORK LICENSE COMPROMISED" And MyLicenseStatus.StrLicenseMsg <> "DATETIME TAMPERED ERROR" Then
                EvaluateMyLicense(mps5_app.App_DbName, mps5_app.App_BackRegGPeriod, MyLicense, MyLicenseStatus)
            End If

        End If

        Me.ControlGroupLicenseInfo.Text = "License Information - " & strLictype & " LICENSE"

        If MyLicenseStatus.ExpDays <= 60 Then
            If MyLicenseStatus.ExpDays <= 0 Then
                Me.captionLabel.Text = IIf(MyLicenseStatus.StrLicenseMsg = "", " Your license has expired.", MyLicenseStatus.StrLicenseMsg)
                Me.NoUserLabel.Text = "Number of allowed concurrent users: " & MyLicenseStatus.NoOfUsers.ToString
                Me.cmdOk.Text = "Close"
            Else
                Me.captionLabel.Text = MyLicenseStatus.StrLicenseMsg & " You only have " & MyLicenseStatus.ExpDays & " days left. Please apply for a new License to continue using this application"
                Me.NoUserLabel.Text = "Number of allowed concurrent users: " & MyLicenseStatus.NoOfUsers.ToString
            End If
        Else
            Me.captionLabel.Text = "You still have " & MyLicenseStatus.ExpDays & " days using this application."
            Me.NoUserLabel.Text = "Number of allowed concurrent users: " & MyLicenseStatus.NoOfUsers.ToString
        End If


        ''create log
        'If MyLicenseStatus.StrLicenseMsg <> "" Then
        '    Log_Append(wrh5_app, MyLicenseStatus.StrLicenseMsg.PadRight(25) & MyLicenseStatus.ErrMsg, , , True)
        'ElseIf MyLicenseStatus.ExpDays = 0 Then
        '    Log_Append(wrh5_app, "License has expired.".PadRight(25) & MyLicenseStatus.ErrMsg, , , True)
        'End If

        ''Set button access
        'If strLictype = "SINGLE" Or strLictype = "TRIAL" Then
        '    cmdOpentroubleshooter.Enabled = True
        'Else
        '    cmdOpentroubleshooter.Enabled = False
        'End If

        'If strLictype = "NETWORK" Then
        '    cmdBrowse.Enabled = False
        'Else
        '    cmdBrowse.Enabled = True
        'End If

        'If SQL_SERVER = "." Then
        '    lblServerName.Text = "LOCALHOST"
        'Else
        '    lblServerName.Text = SQL_SERVER
        'End If
        'End Elmer
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        If cmdOk.Text = "Close" Then
            Process.GetCurrentProcess.Kill()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmActivate_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.cmdOk.Text = "Close" Then
            'avoid inevitable crash
            Process.GetCurrentProcess.Kill()
        End If
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        'Try
        '    'Dim lst As New List(Of String)
        '    'Dim x As Integer = 0
        '    Dim bSuccess As Boolean = True
        '    Dim odMain As New System.Windows.Forms.OpenFileDialog
        '    odMain.Filter = "License Key File (*.license)|*.license"

        '    If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

        '        Dim browsedLicense As New MPSLicense
        '        Dim ErrMsg As String = ""

        '        bSuccess = browsedLicense.ReadLicenseFromFile(odMain.FileName, browsedLicense, ErrMsg, True)

        '        If bSuccess Then
        '            'check serial key
        '            Dim sKey As String = MPSDB.GetConfig("LSKEY")
        '            sKey = sysMpsUserPassword("DECRYPT", sKey)
        '            If sKey <> "" AndAlso sKey = browsedLicense.LicenseKey Then
        '                MsgBox("License Key already loaded.", MsgBoxStyle.Exclamation, GetAppName)
        '                Exit Sub
        '            End If

        '            'check Location ID
        '            Dim mLocID As String = MPSDB.GetConfig("LOCATION_ID")

        '            If Not (mLocID = browsedLicense.LocID) Then
        '                MsgBox("Invalid License File. Location ID mismatch!", MsgBoxStyle.Exclamation, GetAppName)
        '                Exit Sub
        '            End If

        '            ''check Date Generated license if valid
        '            'Dim DateGen As Date
        '            'Try
        '            '    DateGen = DateValue(browsedLicense.DateGen)
        '            'Catch ex As Exception
        '            '    MsgBox("Cannot load license!. Please check date/time settings.", MsgBoxStyle.Exclamation, GetAppName)
        '            '    Exit Sub
        '            'End Try

        '            'If DateGen > MPSDB.getServerDate() Then
        '            '    'invalid datetime settings
        '            '    MsgBox("Cannot load license!. Please check date/time settings.", MsgBoxStyle.Exclamation, GetAppName)
        '            '    Exit Sub
        '            'End If

        '            Dim strBuilder As New System.Text.StringBuilder
        '            strBuilder.Append("Load License?")
        '            strBuilder.AppendLine()
        '            strBuilder.AppendLine()
        '            strBuilder.AppendLine("ALLOWED NO. OF CONCURRENT USERS : " & browsedLicense.NoOfUsers.ToString)

        '            If MsgBox(strBuilder.ToString, 36) = MsgBoxResult.Yes Then
        '                bSuccess = browsedLicense.CheckLicense(ErrMsg)
        '                'save License
        '                If bSuccess Then
        '                    bSuccess = browsedLicense.LoadLicenseToServer(MPSDB, ErrMsg)
        '                End If
        '            Else
        '                MsgBox("Activation Cancelled.", MsgBoxStyle.Exclamation, GetAppName)
        '                Exit Sub
        '            End If
        '        End If

        '        'display Msgbox
        '        If bSuccess And ErrMsg = "" Then
        '            MsgBox("Successfully Loaded a License File!", MsgBoxStyle.Information, GetAppName)
        '            Me.Close()
        '        Else
        '            MsgBox(ErrMsg, MsgBoxStyle.Critical, GetAppName)
        '        End If

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub cmdSaveLocID_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveLocID.Click
        
        Dim LocID As String = MPSDB.GetConfig("LOCATION_ID")

        Dim odMain As New System.Windows.Forms.SaveFileDialog
        odMain.Filter = "Text Documents (*.txt)|*.txt"
        odMain.FileName = "LocationID"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Using sw As System.IO.StreamWriter = System.IO.File.CreateText(odMain.FileName)
                sw.WriteLine(LocID)
            End Using
            MsgBox("Text file created in: " & odMain.FileName, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub cmdCheckConn_Click(sender As System.Object, e As System.EventArgs) Handles cmdCheckConn.Click
        If MsgBox("You are connected to: " & SQLServer & vbCrLf & "Do you want to change connection?", MsgBoxStyle.Question + vbYesNo, GetAppName()) = MsgBoxResult.Yes Then
            '<!-- tony20171108 : changed saving of database connection. use ini instead of registry
            'WriteReg("Server", "")
            'WriteReg("USERID", "")
            'WriteReg("PASSWORD", "")
            WriteIni("Server", "", True)
            WriteIni("USERID", "", True)
            WriteIni("PASSWORD", "", True)
            '-->
            Application.Restart()
        End If
    End Sub
End Class