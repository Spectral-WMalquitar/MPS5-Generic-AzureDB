Imports DevExpress.XtraNavBar
Imports zBusiness
Imports zUtil
Imports System.Reflection
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports System.IO
Imports DevExpress.XtraSplashScreen

Public Class frmMain

    Dim oFTP As New oFTP
    Dim oEMAIL As New oEMAIL
    Dim oSched As New oSched
    Dim bInFunction As Boolean = False
    Dim frmStatus As frmProcessing
    Dim bInCode As Boolean = False
    Dim cLastServiceStat As String = ""
    Dim _tblEmailNotif As DataTable


#Region "Main Menu Navigation"

    Private Sub SimulateService(ByVal cMode As String, e As System.Windows.Forms.KeyEventArgs)
        If UCase(tabControl.SelectedTabPage.Name) = UCase("tabService") Then
            If e.KeyCode = Keys.ControlKey Then
                chkSimulateService.Visible = IIf(cMode = "DOWN", True And (ServiceStatus() <> ServiceProcess.ServiceControllerStatus.Running), False Or chkSimulateService.Checked)
            End If
        End If

        'helpfile
        If e.KeyCode = Keys.F1 Then
            Dim strHelpUrl As String = ""
            Select Case UCase(tabControl.SelectedTabPage.Name)

                Case UCase("tabLicensing")
                    strHelpUrl = "licensing_module.htm"

                Case UCase("tabBackup")
                    strHelpUrl = "configure_database_backup_prof.htm"

                Case UCase("tabRestore")
                    strHelpUrl = "execute_database_restore.htm"

                Case UCase("tabSched")
                    strHelpUrl = "configure_scheduled_database_b.htm"

                Case UCase("tabTransfers")
                    strHelpUrl = "event_logs.htm"

                Case UCase("tbalService")
                    strHelpUrl = "sub_chapter_2_1.htm"

                Case UCase("tabNotify")
                    strHelpUrl = "configure_notification_profile.htm"

                Case UCase("tabEmail")
                    strHelpUrl = "configuring_email_profile_smtp.htm"

                Case UCase("tabFTP")
                    strHelpUrl = "configure_ftp_profile.htm"

                Case UCase("tabSQLServerCon")
                    strHelpUrl = "configure_ms_sql_server_settin.htm"

                Case UCase("tabAbout")
                    strHelpUrl = "introduction.htm"

            End Select

            If strHelpUrl = "" Then strHelpUrl = "introduction.htm"

            System.Windows.Forms.Help.ShowHelp(Me, "SSA_Helpfile.chm", HelpNavigator.Topic, strHelpUrl)
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        SimulateService("DOWN", e)
    End Sub

    Private Sub frmMain_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        SimulateService("UP", e)
    End Sub

    'check if exist is string before appending
    Private Sub FilesForEmail(ByRef xfiles As String, ByVal xfilename As String)
        Try
            Dim arrTemp As String() = xfiles.Split("|")
            If Not arrTemp.Contains(xfilename) Then
                xfiles = xfiles & "|" & xfilename
            End If
        Catch ex As Exception
            xfiles = xfiles
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ChangeLoadingPicture()
        SetLiveStatus(ServiceCallingModule.None & "||")

        lblVersion.Text = "Version " & Application.ProductVersion
        lblVerTop.Text = lblVersion.Text

        tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        'ClickLink(navExport.Links(0)) 'click on export link
        lblTitle.Text = "About"
        tabControl.SelectedTabPage = tabAbout

        MPSService.MachineName = Environment.MachineName
        MPSService.ServiceName = cServiceName

        'initialize
        DateEdit_NextRun.EditValue = Now

        RefreshData()
        ServiceStatus()
        AboutTab_Load()
    End Sub

    Private Sub ClickLink(link As NavBarItemLink)
        Dim mi As MethodInfo = link.NavBar.[GetType]().GetMethod("RaiseLinkClicked", BindingFlags.Instance Or BindingFlags.NonPublic)
        If mi IsNot Nothing Then
            mi.Invoke(link.NavBar, New Object() {link})
        End If
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'End application
        Process.GetCurrentProcess.Kill()
    End Sub

    Private Sub NavBarMain_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarMain.LinkClicked
        Dim cGroup As String = e.Link.Group.Name
        Dim cItem As String = e.Link.Item.Name

        lblTitle.Text = e.Link.Item.Caption
        'TimerServiceStatus.Enabled = False

        Select Case UCase(cItem)

            Case UCase("navBackup")
                tabControl.SelectedTabPage = tabBackUp
                If cboExProfileName.EditValue Is Nothing Then
                    RefreshData()
                End If

            Case UCase("navService")
                If ServiceStatus() <> ServiceProcess.ServiceControllerStatus.Running Then
                    'clear serviceinfo
                    ClearServiceInfo()
                End If
                tabControl.SelectedTabPage = tabService
                TimerServiceStatus.Enabled = True

            Case UCase("navNotification")
                tabControl.SelectedTabPage = tabNotify
                RefreshNotificationTab()

            Case UCase("navFTP")
                tabControl.SelectedTabPage = tabFTP
                If cboFTP.EditValue Is Nothing Then
                    RefreshData()
                End If
            Case UCase("navEmail")
                tabControl.SelectedTabPage = tabEmail
                If cboEmail.EditValue Is Nothing Then
                    RefreshData()
                End If

            Case UCase("navRestore")
                tabControl.SelectedTabPage = tabRestore

            Case UCase("navSchedule")
                tabControl.SelectedTabPage = tabSched
                If cboSchedule.EditValue Is Nothing Then
                    RefreshData()
                End If

            Case UCase("navTransfers")
                tabControl.SelectedTabPage = tabTransfers
                RefreshData()

            Case UCase("navAbout")
                ServiceStatus()
                AboutTab_Load()
                tabControl.SelectedTabPage = tabAbout

            Case UCase("navServerConnections")
                tabControl.SelectedTabPage = tabSQLServerCon
                RefreshData()

            Case UCase("navLicensing")
                tabControl.SelectedTabPage = tabLicensing
                RefreshData()
        End Select
    End Sub

#End Region

#Region "Service Tab"
    Private Function ServiceStatus() As ServiceProcess.ServiceControllerStatus

        Try
            MPSService.Refresh()
            lblStatus.Text = MPSService.Status().ToString
            cmdStartStop.Enabled = True

            Select Case MPSService.Status()
                Case ServiceProcess.ServiceControllerStatus.Running
                    cmdStartStop.Text = "Stop Service"
                    cmdStartStop.Image = My.Resources.player_stop_16x16

                Case ServiceProcess.ServiceControllerStatus.Stopped
                    cmdStartStop.Text = "Start Service"
                    cmdStartStop.Image = My.Resources.player_play_16x16

                Case ServiceProcess.ServiceControllerStatus.Paused
                    cmdStartStop.Text = "Continue Service"
                    cmdStartStop.Image = My.Resources.player_play_16x16

            End Select

            cmdStartStop.Refresh()
        Catch ex As Exception
            'MsgBox(ex.Message)
            lblStatus.Text = "The MPS Service is not installed."
            lblStatus.ForeColor = Color.Red
            lblStatus.Update()
            cmdStartStop.Enabled = False
        End Try

        Try
            If Not isElevated() Then
                lblStatus.Text = lblStatus.Text & vbCrLf & "You need Administrator permissions to Start/Stop services."
                lblStatus.ForeColor = Color.Red
                lblStatus.Update()
            End If
        Catch ex As Exception
            lblStatus.Text = lblStatus.Text & vbCrLf & "You need Administrator permissions to Start/Stop services."
            lblStatus.ForeColor = Color.Red
            lblStatus.Update()
        End Try

        Try
            Return MPSService.Status()
        Catch ex As Exception
            Return -1 'not installed
        End Try

    End Function

    Private Function DisplayLog(ByVal cMsg As String, Optional ByVal bServiceWorkLoad As Boolean = False) As String
        txtLogMsg.Text = IIf(Not bServiceWorkLoad, Format(Now, "hh:mm:ss tt | "), "") & cMsg & vbCrLf & Mid$(txtLogMsg.Text, 1, 5000)
        Return txtLogMsg.Text
    End Function

    Private Sub cmdStartStop_Click(sender As System.Object, e As System.EventArgs) Handles cmdStartStop.Click
        Dim nCtr As Integer

        If Not isElevated() Then
            MsgBox("You need Administrator permissions to Start/Stop services")
            Exit Sub
        End If

        MarqueeProgressBarControl1.Visible = True
        MarqueeProgressBarControl1.Refresh()

        Try
            Select Case MPSService.Status()
                Case ServiceProcess.ServiceControllerStatus.Running
                    DisplayLog("Trying to stop the service...")
                    If MPSService.CanStop Then
                        MPSService.Stop()
                        MPSService.WaitForStatus(ServiceProcess.ServiceControllerStatus.Stopped)
                        DisplayLog("Service stopped.")
                    Else
                        DisplayLog("The service cannot be stopped at the moment. Try again later.")
                        MsgBox("The service cannot be stopped at the moment. Try again later.")
                    End If

                Case ServiceProcess.ServiceControllerStatus.Stopped
                    DisplayLog("Trying to start the service...")
                    MPSService.Start()
                    MPSService.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running)
                    DisplayLog("Service started.")

                Case ServiceProcess.ServiceControllerStatus.Paused
                    DisplayLog("Trying to pause the service...")
                    MPSService.Continue()
                    MPSService.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running)
                    DisplayLog("Service paused.")

            End Select
        Catch ex As Exception
        End Try

        'the service can be started/stopped quickly, too quick for the status marquee to show.
        'delay a couple of seconds after start/stop to let the status scroll to show some activity
        For nCtr = 1 To 100
            Application.DoEvents()
            Threading.Thread.Sleep(1)
        Next

        MarqueeProgressBarControl1.Visible = False
        ServiceStatus()
    End Sub
#End Region

#Region "Licensing Tab"

    Private Sub RefreshTabLicensing()
        ClearLicenseControls()
        SplashScreenManager.ShowForm(GetType(Waitform))
        Try
            Dim xStatusMPS5 As New MyLicenseStatus

            CheckLicense(mps5_app, xStatusMPS5)
            SetLicenseControls(xStatusMPS5)
             
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
        End Try


    End Sub

    Public Sub SetLicenseControls(ByRef xStatus As MyLicenseStatus)
        Dim clsCompInfo As New mdComputerInfo
        Dim strHid As String = clsCompInfo.GetHardwareID

        txtLicenseType.Text = xStatus.LicenseType
        txtHardWareID.Text = strHid
        txtLicenseRemarks.Text = IIf(xStatus.LicenseType = "TRIAL LICENSE", "N/A", xStatus.StrLicenseMsg)
        txtLicenseStatus.Text = IIf(xStatus.LicenseType = "TRIAL LICENSE", "N/A", xStatus.ErrMsg)
    End Sub

    Public Sub ClearLicenseControls()
        txtLicenseType.Text = ""
        txtHardWareID.Text = ""
        txtLicenseRemarks.Text = ""
        txtLicenseStatus.Text = ""
    End Sub

    Private Sub btnBrowseLicense_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowseLicense.Click

        If Not isElevated() Then
            MsgBox("You need to run MPS Service as an Administrator before loading license file.", MsgBoxStyle.Exclamation, GetAppName)
            Exit Sub
        End If

        Dim cApp As New Working_App
        Try

            cApp = mps5_app

            Dim back_reg_gp As String = cApp.App_BackRegGPeriod

            Dim lst As New List(Of String)
            Dim x As Integer = 0
            Dim bSuccess As Boolean = True
            Dim cls As New mdComputerInfo
            Dim odMain As New System.Windows.Forms.OpenFileDialog
            odMain.Filter = "MPS License Key File (*.license)|*.license"

            Dim dirName As String = GetAppFolder()

            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                If Not My.Computer.FileSystem.DirectoryExists(dirName) Then
                    My.Computer.FileSystem.CreateDirectory(dirName)
                End If

                Dim browsedLicense As New MPSLicense
                Dim ErrMsg As String = ""

                bSuccess = xReadLicenseFile(odMain.FileName, browsedLicense, False, ErrMsg)

                If bSuccess Then

                    'check AppName 
                    Dim LAppName As String = sysMpsUserPassword("DECRYPT", browsedLicense.LicenseAppName)
                    If Trim(UCase(LAppName)) <> Trim(UCase("MPS")) Then
                        AnErrorOccured(cApp, "Invalid License File." & vbNewLine & vbNewLine & "This license is not for MPS 5 Application.", True)
                        Exit Sub
                    End If

                    'check if same Hardware ID
                    Dim curr_HID As String = cls.GetHardwareID
                    Dim lic_HID As String = sysMpsUserPassword("DECRYPT", browsedLicense.LicenseHID)

                    If Not (curr_HID = lic_HID) Then
                        AnErrorOccured(cApp, "Invalid License File. Hardware id mismatch!", True)
                        Exit Sub
                    End If

                    'check Date Generated license if valid
                    Dim DLGen As String = sysMpsUserPassword("DECRYPT", browsedLicense.LicenseGen)
                    Dim DateGen As Integer
                    Try
                        DateGen = CInt(DLGen)
                    Catch ex As Exception
                        AnErrorOccured(cApp, "Cannot load license!. Please check date/time settings.", True)
                        Exit Sub
                    End Try

                    If DateGen > getServerDate() Then
                        'invalid datetime settings
                        AnErrorOccured(cApp, "Cannot load license!. Please check date/time settings.", True)
                        Exit Sub
                    End If

                    Dim strBuilder As New System.Text.StringBuilder
                    strBuilder.Append("Load License?")
                    strBuilder.AppendLine()
                    strBuilder.AppendLine()
                    strBuilder.AppendLine("LICENSE TYPE : " & sysMpsUserPassword("DECRYPT", browsedLicense.LicenseType))
                    strBuilder.AppendLine("DATE EXPIRY : " & sysMpsUserPassword("DECRYPT", browsedLicense.LicenseExp))
                    strBuilder.AppendLine("NO. OF CONCURRENT USERS : " & sysMpsUserPassword("DECRYPT", browsedLicense.LicenseNoOfUsers))

                    If MsgBox(strBuilder.ToString, 36) = MsgBoxResult.Yes Then
                        Dim msg As String = ""
                        bSuccess = xSaveLicenseToDB(cApp, browsedLicense, back_reg_gp, msg)
                        If Not bSuccess Then
                            If msg <> "" Then
                                AnErrorOccured(cApp, msg, True)
                                Exit Sub
                            End If
                        End If
                    Else
                        AnErrorOccured(cApp, "Activation cancelled!", True)
                        Exit Sub
                    End If

                Else
                    AnErrorOccured(cApp, ErrMsg, True)
                    Exit Sub
                End If

                Dim strbackupLicense As String = ""
                If cApp.App_Name = "MPS" Then
                    strbackupLicense = dirName & "obj_Wbak\STI_MPSLic_" & getServerDateTime() & ".lic"
                End If

                If My.Computer.FileSystem.FileExists(cApp.App_LicensePath) Then
                    My.Computer.FileSystem.CopyFile(cApp.App_LicensePath, strbackupLicense, True)
                End If

                'copy License File
                My.Computer.FileSystem.CopyFile(odMain.FileName, cApp.App_LicensePath, True)

                MsgBox("The license file has been successfuly loaded!")

                'create backup to registry
                bSuccess = BackupLicenseReg("SET", cApp.App_Name, cApp.App_RegKey, browsedLicense)


                Me.Close()
            End If
        Catch ex As Exception
            AnErrorOccured(cApp, ex.Message, True)
        End Try
    End Sub

    Private Sub btnSaveID_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveID.Click
        Dim LocId As String = oDLSQLSERVER.DLookUp("[TextValue]", "MPS.dbo.tblConfig", "Code='LOCATION_ID'", "", True)
        
        Dim mdCompInfo As New mdComputerInfo

        Dim odMain As New System.Windows.Forms.SaveFileDialog
        odMain.Filter = "Text Documents (*.txt)|*.txt"
        odMain.FileName = "HardwareID"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Using sw As System.IO.StreamWriter = System.IO.File.CreateText(odMain.FileName)
                sw.WriteLine(mdCompInfo.GetHardwareID)
                sw.WriteLine(LocId)
            End Using
            MsgBox("Text file created in: " & odMain.FileName, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnLicenseTroubleShooter_Click(sender As System.Object, e As System.EventArgs) Handles btnLicenseTroubleShooter.Click
        Dim param As New Working_App
        param = mps5_app

        Dim frm As New frmLicenseTroubleShooter(param)
        frm.ShowDialog()
    End Sub
#End Region

#Region "Backup Tab"
    Private Function ProfileFromForm() As oProfile
        Dim cSelected As String = ""
        Dim oProfile As New oProfile


        oProfile.Code = "<NONE>" 'RSA: always set to nothing for 2 reasons:
        '1. The user might have modified the form selection without saving
        '2. oProfile.Code is inaccurate unless it is directly loaded/returned from the DB via the oProfile.Load() or oProfile.Save() methods
        oProfile.Name = NullToString(cboExProfileName.Text)
        oProfile.ExpFolder = NullToString(txtExPath.Text)
        oProfile.Comment = NullToString(txtComments.Text)

        Return oProfile

    End Function


    Private Sub cboExProfileName_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboExProfileName.ButtonClick
        Dim cProfName As String = ""
        Dim oProfile As New oProfile

        Dim cErr As String = ""

        If e.Button.Kind <> DevExpress.XtraEditors.Controls.ButtonPredefines.Combo AndAlso ValidateEntries(cErr, True) Then
            Select Case UCase(e.Button.Caption)
                Case "CLEAR"
                    cboExProfileName.EditValue = Nothing
                    txtExPath.Text = ""
                    txtComments.Text = ""

                Case "ADD"
                    cProfName = cboExProfileName.Text
                    cProfName = InputBox("Enter a profile name to save. Existing profile with the same name will be overwritten.", "Save Profile", cProfName)
                    If cProfName = "" Then
                        MsgBox("Save cancelled.")
                    Else

                        oProfile = ProfileFromForm()
                        oProfile.Save(cProfName)

                        If cboExProfileName.EditValue <> oProfile.Code Then
                            RefreshData()
                            cboExProfileName.EditValue = oProfile.Code
                        End If

                        MsgBox("Profile '" & cProfName & "' saved.")

                    End If

                Case "DEL"
                    If NullToAny(cboExProfileName.EditValue) = "" Then
                        MsgBox("Select the profile to be deleted from the dropdown list and try again.")
                    Else
                        If MsgBox("Are you sure  you want to delete '" & cboExProfileName.Text & "'? This action cannot be undone.", vbYesNo + vbQuestion + vbDefaultButton2, "Delete Profile?") = vbYes Then
                            oProfile.Delete(NullToAny(cboExProfileName.EditValue))
                            RefreshData()
                            'clear all items on screen
                            txtExPath.Text = ""
                            txtComments.Text = ""
                        End If
                    End If

            End Select
        End If

    End Sub

    Private Sub cboExProfileName_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboExProfileName.EditValueChanged
        Dim oProfile As New oProfile
        Dim cProfCode As String = NullToString(cboExProfileName.EditValue)

        If Not cProfCode = "" Then
            'load profile from DB
            If oProfile.Load(NullToString(cboExProfileName.EditValue)) Then

                txtExPath.Text = oProfile.ExpFolder
                txtComments.Text = oProfile.Comment

            Else
                MsgBox("There was a problem loading the selected profile")
            End If
        End If
    End Sub

    Private Sub txtExPath_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtExPath.ButtonClick
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        ' Description that displays above the dialog box control. 

        MyFolderBrowser.Description = "Select the Export Folder"
        ' Sets the root folder where the browsing starts from 
        If NullToAny(txtExPath.Text) = "" Then
            MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Else
            MyFolderBrowser.SelectedPath = NullToAny(txtExPath.Text)
        End If

        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            txtExPath.Text = MyFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub cmdBackup_Click(sender As System.Object, e As System.EventArgs) Handles cmdBackup.Click
        Dim oProfileAndSched As TransferNexus
        Dim oProfile As New oProfile
        Dim cReturnFileName As String = "" 'will hold the path+file name of export file
        Dim cLog As String = ""
        Dim cMsg As String = ""
        Dim cErr As String = ""

        If chkSimulateService.Checked OrElse (ServiceStatus() = ServiceProcess.ServiceControllerStatus.Running) Then
            MsgBox("The Service/Simulated Service is currently RUNNING. It can interfere with manually initiated import/export. To prevent problems, please STOP the Service and try again.", MsgBoxStyle.Exclamation)
        Else
            'set class profile from current form values
            oProfile = ProfileFromForm()
            If ValidateEntries(cErr, True) Then
                'proceed with backup
                If MsgBox("Start backup now?", vbQuestion + vbYesNo + vbDefaultButton2) = vbYes Then
                    oProfileAndSched.oProf = oProfile
                    oProfileAndSched.oCallingModule = CallingModule.BRS_INTERFACE
                    oProfileAndSched.oSched = Nothing
                    oProfileAndSched.oTransfer = Nothing

                    Backup_Async(oDLSQLSERVER, oDLSQLSERVER, oProfileAndSched, cReturnFileName, True, cLog)
                End If
            End If
        End If

    End Sub

#End Region

#Region "Restore Tab"
    Private Sub BrowseRestoreFile()
        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Select file for restore"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Backup File (*.bak)|*.bak"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            cmdBrowseRestoreFile.Text = fd.FileName
        End If
    End Sub

    Private Sub cmdBrowseRestoreFile_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cmdBrowseRestoreFile.ButtonClick
        Select Case e.Button.Kind
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis
                BrowseRestoreFile()
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                cmdBrowseRestoreFile.Text = ""
        End Select
    End Sub

    Private Sub cmdBrowseRestoreFile_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowseRestoreFile.Click
        If NullToString(cmdBrowseRestoreFile.Text) = "" Then
            BrowseRestoreFile()
        End If
    End Sub

    Private Sub cmdRestore_Click(sender As System.Object, e As System.EventArgs) Handles cmdRestore.Click
        Dim oProfileAndSched As TransferNexus
        Dim oProfile As New oProfile
        Dim cLog As String = ""
        Dim cErr As String = ""

        If chkSimulateService.Checked OrElse (ServiceStatus() = ServiceProcess.ServiceControllerStatus.Running) Then
            MsgBox("The Service/Simulated Service is currently RUNNING. It can interfere with manually initiated backup/restore function. To prevent problems, please STOP the Service and try again.", MsgBoxStyle.Exclamation, GetAppName)
        Else
            If ValidateEntries(cErr, True) Then
                'proceed with export
                If MsgBox("Start restore now?", vbQuestion + vbYesNo + vbDefaultButton2) = vbYes Then
                    oProfileAndSched.oProf = Nothing
                    oProfileAndSched.oCallingModule = CallingModule.BRS_INTERFACE
                    oProfileAndSched.oSched = Nothing
                    oProfileAndSched.oTransfer = Nothing

                    Restore_Async(oDLSQLSERVER, oDLSQLSERVER, NullToString(cmdBrowseRestoreFile.Text), True, cLog)
                End If
            End If
        End If
    End Sub
#End Region

#Region "SQl Server Connection Tab"
    Private Sub btnTestSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnTestSettings.Click
        Dim bSuccess As Boolean
        bSuccess = PerformTestSQLServerSettings(True)
    End Sub

    Private Sub cboAuth_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAuth.EditValueChanged
        If cboAuth.EditValue = "SQLSERVER_AUTH" Then
            txtUser.Enabled = True
            txtPwd.Enabled = True
        Else
            txtUser.Text = ""
            txtPwd.Text = ""
            txtUser.Enabled = False
            txtPwd.Enabled = False
        End If
    End Sub

    Private Function PerformTestSQLServerSettings(Optional ByVal showMsg As Boolean = True) As Boolean
        Dim xODL As New zDataLayer.DataLayer
        Dim xoCCon As New zDataLayer.connDetails

        xoCCon.Server = txtServer.Text
        xoCCon.OtherOptions = cboAuth.EditValue
        xoCCon.User = txtUser.Text
        xoCCon.Pwd = txtPwd.Text

        'test SQL Server
        If oApp.Test_SQLServerConnections(xODL, xoCCon, False) Then
            If showMsg Then
                MsgBox("Test Success", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Test Connection Result")
            End If
            PerformTestSQLServerSettings = True
        Else
            If showMsg Then
                MsgBox("Test Failed" & vbCrLf, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Test Connection Result")
            End If
            PerformTestSQLServerSettings = False
        End If
    End Function

    Private Sub btnSaveConfigs_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveConfigs.Click
        Dim bSuccess As Boolean = False
        bSuccess = PerformTestSQLServerSettings(False)
        If Not bSuccess Then
            MsgBox("SQL Server connection settings failed. Cannot proceed.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Unable to proceed")
        Else
            'check if there's valid path
            If cmdBrowseSharedFolder.Text <> "" Then
                'save settings
                Dim zConn As New zDataLayer.connDetails
                zConn.Server = txtServer.Text
                zConn.OtherOptions = cboAuth.EditValue
                zConn.User = txtUser.Text
                zConn.Pwd = txtPwd.Text
                zConn.DBName = "STIAPPVERSIONS"
                bSuccess = oApp.SaveConfigFile(zConn)
                bSuccess = bSuccess And SetConfig(oDLSQLSERVER, "SERVER_SHARED_PATH", cmdBrowseSharedFolder.Text)
                If bSuccess Then
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, GetAppName)
                    Application.Restart()
                Else
                    MsgBox("Failed to save settings.", MsgBoxStyle.Exclamation, GetAppName)
                End If
            Else
                MsgBox("Please check folder path. Cannot proceed.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            End If
        End If
    End Sub

    Private Sub cmdBrowseSharedFolder_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cmdBrowseSharedFolder.ButtonClick
        Select Case e.Button.Kind
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis
                FolderPath()
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                cmdBrowseSharedFolder.Text = ""
        End Select
    End Sub

    Private Sub FolderPath()
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        ' Description that displays above the dialog box control. 

        MyFolderBrowser.Description = "Select the Shared Path"
        ' Sets the root folder where the browsing starts from 
        If NullToAny(cmdBrowseSharedFolder.Text) = "" Then
            MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Else
            MyFolderBrowser.SelectedPath = NullToAny(cmdBrowseSharedFolder.Text)
        End If

        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            cmdBrowseSharedFolder.Text = MyFolderBrowser.SelectedPath
        End If
    End Sub
#End Region

#Region "About Tab"
    Private Sub AboutTab_Load()
        lblAppName.Text = Application.ProductName
        lblAboutServiceStat.Text = lblStatus.Text
        lblAboutServiceStat.ForeColor = lblStatus.ForeColor
    End Sub
#End Region

#Region "FTP Tab"
    Private Sub chkFTP_UseSSL_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFTP_UseSSL.CheckedChanged
        SpinEdit_Port.Value = IIf(chkFTP_UseSSL.Checked, 990, 21)
    End Sub

    Private Sub chkFTP_AuthTLS_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFTP_AuthTLS.CheckedChanged
        SpinEdit_Port.Value = IIf(chkFTP_UseSSL.Checked, 990, 21)
    End Sub

    Private Sub cboFTP_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFTP.ButtonClick
        Dim oFTP As New oFTP
        Dim cProfName As String = ""
        Dim cErr As String = ""

        If e.Button.Kind <> DevExpress.XtraEditors.Controls.ButtonPredefines.Combo AndAlso ValidateEntries(cErr, True) Then
            Select Case UCase(e.Button.Caption)
                Case "CLEAR"
                    cboFTP.EditValue = Nothing
                    FTP_DisplayProfile(New oFTP)

                Case "ADD"
                    cProfName = cboFTP.Text
                    cProfName = InputBox("Enter FTP profile name to save. Existing FTP profile with the same name will be overwritten.", "Save FTP Profile", cProfName)
                    If cProfName = "" Then
                        MsgBox("Save cancelled.")
                    Else

                        oFTP.INET_TLS = chkFTP_AuthTLS.Checked
                        oFTP.FTP_AutoFeat = chkFTP_AutoFeat.Checked
                        oFTP.FTP_ConnectionTimeout = SpinEdit_FTPTimeout.Value
                        oFTP.INET_Host = txtFTP_Host.Text
                        oFTP.INET_Port = SpinEdit_Port.Value
                        oFTP.INET_Pwd = txtFTP_Pwd.Text
                        oFTP.FTP_UsePassive = chkFTP_UsePassive.Checked
                        oFTP.INET_User = txtFTP_User.Text
                        oFTP.INET_UseSSL = chkFTP_UseSSL.Checked
                        oFTP.INET_AutoRemoveFiles = chkFTP_AutoRemoveFiles.Checked
                        oFTP.INET_ProfileName = cProfName
                        oFTP.Save(cProfName)

                        If cboFTP.EditValue <> oFTP.INET_Code Then
                            RefreshData()
                            cboFTP.EditValue = oFTP.INET_Code
                        End If

                        MsgBox("FTP Profile '" & cProfName & "' saved.")

                    End If

                Case "DEL"
                    If NullToAny(cboFTP.EditValue) = "" Then
                        MsgBox("Select the FTP profile to be deleted from the dropdown list and try again.")
                    Else
                        If MsgBox("Are you sure  you want to delete '" & cboFTP.Text & "'? This action cannot be undone.", vbYesNo + vbQuestion + vbDefaultButton2, "Delete FTP Profile?") = vbYes Then
                            oFTP.Delete(cboFTP.EditValue)
                            RefreshData()
                            'clear form values
                            oFTP = New oFTP
                            FTP_DisplayProfile(oFTP)
                        End If
                    End If

            End Select
        End If
    End Sub


    Private Sub FTP_DisplayProfile(ByVal oFTP As oFTP)
        chkFTP_AuthTLS.Checked = oFTP.INET_TLS
        chkFTP_AutoFeat.Checked = oFTP.FTP_AutoFeat
        SpinEdit_FTPTimeout.Value = oFTP.FTP_ConnectionTimeout
        txtFTP_Host.Text = oFTP.INET_Host
        SpinEdit_Port.Value = oFTP.INET_Port
        txtFTP_Pwd.Text = oFTP.INET_Pwd
        chkFTP_UsePassive.Checked = oFTP.FTP_UsePassive
        txtFTP_User.Text = oFTP.INET_User
        chkFTP_UseSSL.Checked = oFTP.INET_UseSSL
        chkFTP_AutoRemoveFiles.Checked = oFTP.INET_AutoRemoveFiles
    End Sub

    Private Sub cboFTP_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboFTP.EditValueChanged
        oFTP.INET_Code = cboFTP.EditValue
        FTP_DisplayProfile(oFTP)
    End Sub

    Private Sub cmdFTP_TestSettings_Click(sender As System.Object, e As System.EventArgs) Handles cmdFTP_TestSettings.Click
        If ValidateEntries(, True) Then
            'load values
            oFTP.INET_TLS = chkFTP_AuthTLS.Checked
            oFTP.FTP_AutoFeat = chkFTP_AutoFeat.Checked
            oFTP.FTP_ConnectionTimeout = SpinEdit_FTPTimeout.Value
            oFTP.INET_Host = txtFTP_Host.Text
            oFTP.INET_Port = SpinEdit_Port.Value
            oFTP.INET_Pwd = txtFTP_Pwd.Text
            oFTP.FTP_UsePassive = chkFTP_UsePassive.Checked
            oFTP.INET_User = txtFTP_User.Text
            oFTP.INET_UseSSL = chkFTP_UseSSL.Checked
            oFTP.INET_AutoRemoveFiles = chkFTP_AutoRemoveFiles.Checked

            Dim frmFTP_Test As New frmFTP_Test(oFTP)
            frmFTP_Test.ShowDialog()
        End If
    End Sub
#End Region

#Region "Email Tab"

    Private Sub chkSMTP_SSL_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSMTP_SSL.CheckedChanged
        If Not bInFunction Then
            bInFunction = True
            If chkSMTP_SSL.Checked Then
                chkSMTP_TLS.Checked = False
            End If
            If chkSMTP_SSL.Checked Then
                SpinEditSMTP_Port.Value = 465
            Else
                SpinEditSMTP_Port.Value = 21
            End If
            bInFunction = False
        End If
    End Sub

    Private Sub chkSMTP_TLS_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSMTP_TLS.CheckedChanged
        If Not bInFunction Then
            bInFunction = True
            If chkSMTP_TLS.Checked Then
                chkSMTP_SSL.Checked = False
            End If
            If chkSMTP_SSL.Checked Then
                SpinEditSMTP_Port.Value = 465
            Else
                SpinEditSMTP_Port.Value = 21
            End If
            bInFunction = False
        End If
    End Sub

    Private Sub EmailAccountType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles EmailAccountType.EditValueChanged
        ChangeEmailTabLabels(IIf(EmailAccountType.Value = 0, "SMTP", "POP"))
    End Sub

    Private Sub ChangeEmailTabLabels(ByVal strValue As String)
        grpEmailConnection.Text = strValue & " Connection"
        lblEmailHost.Text = strValue & " Host"
        lblEmailUser.Text = strValue & " User"
        lblEmailPwd.Text = strValue & " Password"
        lblEmailPort.Text = strValue & " Port"

        Dim bool As Boolean = False
        If strValue = "SMTP" Then bool = True

        chkUseSPA.Enabled = Not bool
        chkSMTP_TLS.Enabled = bool
        chkSMTP_SSL.Enabled = True

        txtSMTP_Email.Enabled = bool
        txtSMTP_To.Enabled = bool
        cmdSMTP_TestEmail.Enabled = bool

    End Sub

    Private Sub cboEmail_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboEmail.ButtonClick
        Dim oEMAIL As New oEMAIL
        Dim cProfName As String = ""
        Dim cErr As String = ""

        If e.Button.Kind <> DevExpress.XtraEditors.Controls.ButtonPredefines.Combo AndAlso ValidateEntries(cErr, True) Then
            Select Case UCase(e.Button.Caption)
                Case "CLEAR"
                    cboEmail.EditValue = Nothing
                    EMAIL_DisplayProfile(New oEMAIL)

                Case "ADD"
                    cProfName = cboEmail.Text
                    cProfName = InputBox("Enter SMTP profile name to save. Existing EMAIL profile with the same name will be overwritten.", "Save EMAIL Profile", cProfName)
                    If cProfName = "" Then
                        MsgBox("Save cancelled.")
                    Else

                        oEMAIL.INET_Host = txtSMTP_Host.Text
                        oEMAIL.INET_Pwd = txtSMTP_Pwd.Text
                        oEMAIL.INET_User = txtSMTP_User.Text
                        oEMAIL.INET_ProfileName = cProfName
                        oEMAIL.SMTP_SenderEmail = txtSMTP_Email.Text
                        oEMAIL.INET_Port = SpinEditSMTP_Port.Value
                        oEMAIL.INET_UseSSL = chkSMTP_SSL.Checked
                        oEMAIL.INET_TLS = chkSMTP_TLS.Checked
                        oEMAIL.INET_SPA = chkUseSPA.Checked
                        oEMAIL.INET_EmailType = EmailAccountType.Value
                        oEMAIL.Save(cProfName)

                        If cboEmail.EditValue <> oEMAIL.INET_Code Then
                            RefreshData()
                            cboEmail.EditValue = oEMAIL.INET_Code
                        End If

                        MsgBox("EMAIL Profile '" & cProfName & "' saved.")

                    End If

                Case "DEL"
                    If NullToAny(cboEmail.EditValue) = "" Then
                        MsgBox("Select the EMAIL profile to be deleted from the dropdown list and try again.")
                    Else
                        If MsgBox("Are you sure  you want to delete '" & cboEmail.Text & "'? This action cannot be undone.", vbYesNo + vbQuestion + vbDefaultButton2, "Delete EMAIL Profile?") = vbYes Then
                            oEMAIL.Delete(cboEmail.EditValue)
                            RefreshData()
                            'clear form values
                            oEMAIL = New oEMAIL
                            EMAIL_DisplayProfile(oEMAIL)
                        End If
                    End If

            End Select
        End If
    End Sub

    Private Sub EMAIL_DisplayProfile(ByVal oEMAIL As oEMAIL)
        EmailAccountType.Value = oEMAIL.INET_EmailType
        txtSMTP_Host.Text = oEMAIL.INET_Host
        txtSMTP_Pwd.Text = oEMAIL.INET_Pwd
        txtSMTP_User.Text = oEMAIL.INET_User
        txtSMTP_Email.Text = oEMAIL.SMTP_SenderEmail
        chkSMTP_SSL.Checked = oEMAIL.INET_UseSSL
        chkSMTP_TLS.Checked = oEMAIL.INET_TLS
        chkUseSPA.Checked = oEMAIL.INET_SPA
        SpinEditSMTP_Port.Value = oEMAIL.INET_Port
    End Sub

    Private Sub cboEmail_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboEmail.EditValueChanged
        oEMAIL.INET_Code = cboEmail.EditValue
        EMAIL_DisplayProfile(oEMAIL)
    End Sub

    Private Sub cmdSMTP_TestEmail_Click(sender As System.Object, e As System.EventArgs) Handles cmdSMTP_TestEmail.Click
        If txtSMTP_To.Text = "" Then
            MsgBox("Test Email Recipient is required.")
        Else
            If ValidateEntries(, True) Then
                If MsgBox("Do you want to send a test message to " & txtSMTP_To.Text & "?", vbYesNo + vbQuestion + vbDefaultButton2) = vbYes Then
                    'load smtp settings
                    oEMAIL.INET_Host = txtSMTP_Host.Text
                    oEMAIL.INET_Pwd = txtSMTP_Pwd.Text
                    oEMAIL.INET_User = txtSMTP_User.Text
                    oEMAIL.SMTP_SenderEmail = txtSMTP_Email.Text
                    oEMAIL.INET_UseSSL = chkSMTP_SSL.Checked
                    oEMAIL.INET_TLS = chkSMTP_TLS.Checked
                    oEMAIL.INET_Port = SpinEditSMTP_Port.Value
                    'test email
                    oEMAIL.cMsg_To = txtSMTP_To.Text
                    oEMAIL.cmsg_To_FriendlyName = txtSMTP_To.Text
                    oEMAIL.cMsg_Subj = oApp.GetAppName & " Test Message #" & Format(Now(), "ddmmyyyyyhhmmss") & " (" & GetConfig(oDLSQLSERVER, "NAME", "") & ")"
                    oEMAIL.cMsg_Body = "This is a test message sent from " & oApp.GetAppName & " by " & oApp.UserName
                    TestEmail_Async()
                End If
            End If
        End If
    End Sub

    Private Sub TestEmail_Async()
        Dim bw As BackgroundWorker = New BackgroundWorker

        frmStatus = New frmProcessing("Sending test message... please wait...")
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        AddHandler bw.DoWork, AddressOf TestEmail_DoWork
        AddHandler bw.RunWorkerCompleted, AddressOf TestEmail_RunWorkerCompleted
        bw.RunWorkerAsync()
        frmStatus.ShowDialog()
    End Sub

    Private Sub TestEmail_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim cLog As String = ""
        Dim bSuccess As Boolean = False
        bSuccess = oEMAIL.SendMail(cLog)
        'return result
        e.Result = New Object() {bSuccess, cLog}
    End Sub

    Private Sub TestEmail_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        'obtain parameters
        Dim oParams As Object() = TryCast(e.Result, Object())
        Dim bSuccess As Boolean = oParams(0)
        Dim cLog As String = TryCast(oParams(1), String)

        frmStatus.Hide()
        frmStatus.Close()

        If e.Cancelled = True Then
            'Me.LabelControl3.Text = "Canceled!"
            MsgBox("Test cancelled.")
        ElseIf e.Error IsNot Nothing Then
            'Me.LabelControl3.Text = "Error: " & e.Error.Message
        Else
            If bSuccess Then
                MsgBox("Test message sent successfully.")
            Else
                If MsgBox("Test failed. Do you want to view the error log?", vbYesNo + vbCritical) = vbYes Then
                    ShowLog(cLog)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Notification Tab"
    Private Sub RefreshNotificationTab()
        Dim cAlertUsers As String = ""
        Dim cAlertEmail As String = ""
        Dim nCtr As Integer = 0
        Dim cItem As String = ""

        'load data into controls
        RefreshData()

        ''get saved values
        cboAlertSmtp.EditValue = NullToString(GetConfig(oDLSQLSERVER, "BRS_ALERT_SMTP"))

    End Sub

    Private Sub cmdAlertAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAlertAdd.Click
        If txtAlertEmail.Text = "" Then
            MsgBox("Please enter email address.", MsgBoxStyle.Information, GetAppName)
        Else
            Dim bDuplicated As Boolean = False
            Dim foundrow As DataRow = _tblEmailNotif.Rows.Find(txtAlertEmail.Text)
            If Not (foundrow Is Nothing) Then
                'duplicate
                MsgBox("Email already exists!", MsgBoxStyle.Exclamation, GetAppName)
            Else
                Dim xrow() As Object = {txtAlertEmail.Text, False}
                _tblEmailNotif.Rows.Add(xrow)
            End If
        End If
    End Sub

    Private Sub cmdAlertRemove_Click(sender As System.Object, e As System.EventArgs) Handles cmdAlertRemove.Click
        Try
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSaveAlerts_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveAlerts.Click
        Dim bSuc As Boolean = False
        bSuc = oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_email_notif")
        Dim a As Integer = 0
        Dim cEmail As String
        Dim cSuc_notif As Boolean
        For a = 0 To GridView1.RowCount - 1
            cEmail = GridView1.GetRowCellValue(a, "Email")
            cSuc_notif = GridView1.GetRowCellValue(a, "Notif_Success")

            bSuc = bSuc And oDLSQLSERVER.ExecuteNonQuery("INSERT INTO tblSTIService_email_notif (Email,Notif_Success) VALUES ('" & cEmail & "'," & IIf(cSuc_notif, -1, 0) & ")")

        Next a
        bSuc = bSuc And SetConfig(oDLSQLSERVER, "BRS_ALERT_SMTP", cboAlertSmtp.EditValue)

        If bSuc Then
            MsgBox("Notification settings saved.", MsgBoxStyle.Information, GetAppName)
            RefreshData()
        Else
            MsgBox("An error occurred saving the settings.", MsgBoxStyle.Critical, GetAppName)
        End If

    End Sub
#End Region

#Region "Scheduled Backups"
    Private Sub Sched_Days(ByVal cMode As String, ByRef nValue As Integer)
        Dim nCtr As Integer = 0
        Dim nRetVal As Integer = 0

        Select Case UCase(cMode)
            Case "GET"
                For nCtr = 0 To chkDays.Items.Count - 1
                    If chkDays.Items(nCtr).CheckState = CheckState.Checked Then
                        nRetVal = nRetVal + chkDays.Items(nCtr).Value
                    End If
                Next
                nValue = nRetVal

            Case "SET"
                bInCode = True
                For nCtr = 0 To chkDays.Items.Count - 1
                    chkDays.Items(nCtr).CheckState = CheckState.Unchecked
                    If (chkDays.Items(nCtr).Value And nValue) = chkDays.Items(nCtr).Value Then
                        chkDays.Items(nCtr).CheckState = CheckState.Checked
                    End If
                Next
                bInCode = False

        End Select
    End Sub

    Private Sub Sched_DisplayProfile(oSched As oSched)
        tbActive.Value = IIf(oSched.SCHED_Active, 1, 0)
        If oSched.SCHED_Type = ActionType.Backup Then
            cboBackupProfile.EditValue = oSched.SCHED_Action
            cboBackupProfile.Enabled = True
            chkBakFTP.Enabled = True
        Else
            cboBackupProfile.Enabled = False
            chkBakFTP.Enabled = False
        End If
        TimeEdit_StartTime.Time = NullToDate(oSched.SCHED_StartTime)
        DateEdit_NextRun.EditValue = NullToDate(oSched.SCHED_NextRun)
        txtOnStart.Text = oSched.SCHED_RunBefore
        txtOnEnd.Text = oSched.SCHED_RunAfter
        cboFTPProfile.EditValue = oSched.SCHED_Internet_FTP_Profile
        txtRemoteFolder.Text = oSched.SCHED_Internet_FTP_Folder
        Sched_Days("SET", oSched.SCHED_Days)
        chkBakFTP.Checked = oSched.SCHED_IncludePics
    End Sub

    Private Sub GetSchedFromForm(ByRef oSched As oSched)
        oSched.SCHED_Active = IIf(tbActive.Value, 1, 0)
        If oSched.SCHED_Type = ActionType.Backup Then
            oSched.SCHED_Action = cboBackupProfile.EditValue
        End If
        oSched.SCHED_StartTime = TimeEdit_StartTime.Time
        oSched.SCHED_NextRun = DateEdit_NextRun.EditValue
        oSched.SCHED_RunBefore = txtOnStart.Text
        oSched.SCHED_RunAfter = txtOnEnd.Text
        oSched.SCHED_Internet_FTP_Profile = cboFTPProfile.EditValue
        oSched.SCHED_Internet_FTP_Folder = txtRemoteFolder.Text
        oSched.SCHED_IncludePics = chkBakFTP.Checked
        Sched_Days("GET", oSched.SCHED_Days)
    End Sub

    Private Sub cboSchedule_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboSchedule.ButtonClick
        Dim cProfName As String = ""
        Dim cErr As String = ""
        Dim cMsg As String = ""

        ShowScheduleEditorButton("LAUNCH", False)

        bInCode = True
        If e.Button.Kind <> DevExpress.XtraEditors.Controls.ButtonPredefines.Combo AndAlso ValidateEntries(cErr, True) Then
            Select Case UCase(e.Button.Caption)
                Case "CLEAR"
                    cboSchedule.EditValue = Nothing
                    Sched_DisplayProfile(New oSched)

                Case "LAUNCH"
                    If chkSimulateService.Checked OrElse (ServiceStatus() = ServiceProcess.ServiceControllerStatus.Running) Then
                        MsgBox("The Service/Simulated Service is currently RUNNING. It can interfere with manually initiated import/export. To prevent problems, please STOP the Service and try again.", MsgBoxStyle.Exclamation)
                    Else
                        If NullToString(cboSchedule.EditValue) <> "" Then
                            cMsg = "WARNING: The following IRREVERSIBLE operations will be performed during the process:"
                            If NullToString(txtOnStart.Text) <> "" Then
                                'cMsg = cMsg & vbCrLf & vbCrLf & " - Launch the [On Start] application"
                            End If

                            cMsg = cMsg & vbCrLf & vbCrLf & " - Create Backup File"
                            cMsg = cMsg & vbCrLf & vbCrLf & " - Send Backup File to [Remote Folder] (may take a while) if necesarry"
                            cMsg = cMsg & vbCrLf & vbCrLf & " - WILL NOT update the schedule [Next Run] date"

                            If NullToString(txtOnStart.Text) <> "" Then
                                'cMsg = cMsg & vbCrLf & vbCrLf & " - Launch the [On End] application"
                            End If
                            cMsg = cMsg & vbCrLf & vbCrLf & "ARE YOU SURE YOU WANT TO PROCEED?"

                            If MsgBox(cMsg, MsgBoxStyle.Information + vbYesNo + vbDefaultButton2) = vbYes Then
                                'force save schedule
                                cProfName = oSched.SCHED_Name
                                GetSchedFromForm(oSched)
                                oSched.Save(cProfName)

                                'always refresh combobox because the DESCRIPTION could have changed
                                RefreshData()
                                'load saved schedule from DB
                                oSched.Launch(CallingModule.BRS_INTERFACE)
                            End If

                        Else
                            MsgBox("Save the schedule then try again.", MsgBoxStyle.Exclamation)
                        End If
                    End If

                Case "ADD"
                    cProfName = oSched.SCHED_Name
                    cProfName = InputBox("Enter Schedule Name to save. Existing Schedule with the same name will be overwritten.", "Save Schedule", cProfName)
                    If cProfName = "" Then
                        MsgBox("Save cancelled.")
                    Else

                        GetSchedFromForm(oSched)
                        oSched.Save(cProfName)

                        'always refresh combobox because the DESCRIPTION could have changed
                        RefreshData()
                        cboSchedule.EditValue = oSched.SCHED_Code

                        MsgBox("Schedule Profile '" & cProfName & "' saved.")

                    End If

                Case "DEL"
                    If NullToAny(cboSchedule.EditValue) = "" Then
                        MsgBox("Select the schedule to be deleted from the dropdown list and try again.")
                    Else
                        If MsgBox("Are you sure  you want to delete '" & cboSchedule.Text & "'? This action cannot be undone.", vbYesNo + vbQuestion + vbDefaultButton2, "Delete Schedule?") = vbYes Then
                            oSched.Delete(cboSchedule.EditValue)
                            RefreshData()
                            'clear form values
                            oSched = New oSched
                            Sched_DisplayProfile(oSched)
                        End If
                    End If

            End Select
        End If
        bInCode = False
    End Sub

    Private Sub cboSchedule_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboSchedule.EditValueChanged
        oSched.SCHED_Code = cboSchedule.EditValue
        Sched_DisplayProfile(oSched)
    End Sub


    Private Sub txtOnStart_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtOnStart.ButtonClick, ButtonEdit2.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Select Case e.Button.Kind
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis
                fd.Title = "OnStart Application"
                fd.InitialDirectory = "C:\"
                fd.Filter = "Applications (*.exe)|*.exe"
                fd.FilterIndex = 1
                fd.RestoreDirectory = True

                If fd.ShowDialog() = DialogResult.OK Then
                    txtOnStart.Text = fd.FileName
                End If
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                txtOnStart.Text = ""
        End Select

    End Sub

    Private Sub txtOnEnd_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtOnEnd.ButtonClick, ButtonEdit1.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Select Case e.Button.Kind
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis
                fd.Title = "OnStart Application"
                fd.InitialDirectory = "C:\"
                fd.Filter = "Applications (*.exe)|*.exe"
                fd.FilterIndex = 1
                fd.RestoreDirectory = True

                If fd.ShowDialog() = DialogResult.OK Then
                    txtOnEnd.Text = fd.FileName
                End If
            Case DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
                txtOnEnd.Text = ""
        End Select
    End Sub

    Private Sub chkDays_DrawItem(sender As Object, e As DevExpress.XtraEditors.ListBoxDrawItemEventArgs) Handles chkDays.DrawItem
        Dim control As DevExpress.XtraEditors.CheckedListBoxControl = DirectCast(sender, DevExpress.XtraEditors.CheckedListBoxControl)
        e.Appearance.BackColor = control.BackColor
        e.Appearance.ForeColor = control.ForeColor
    End Sub


    Private Sub chkDays_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles chkDays.ItemCheck
        Dim nDays As Integer = 0

        If Not bInCode Then
            Sched_Days("GET", nDays)
            DateEdit_NextRun.EditValue = FindEarliestDate(FindEarliestDay(nDays, Now), Now)
        End If

    End Sub

    Private Sub chkTestDir_Click(sender As System.Object, e As System.EventArgs) Handles chkTestDir.Click
        If ValidateEntries(, True) Then
            Dim oFTP As New oFTP
            oFTP.INET_Code = cboFTPProfile.EditValue
            Dim frmFTP_Test As New frmFTP_Test(oFTP, NullToString(txtRemoteFolder.Text))
            frmFTP_Test.ShowDialog()
        End If
    End Sub

    Private Sub ShowScheduleEditorButton(ByVal cCaption As String, Optional bShow As Boolean = True)
        For Each Button As DevExpress.XtraEditors.Controls.EditorButton In cboSchedule.Properties.Buttons()
            If Button.Caption = cCaption Then
                Button.Visible = bShow
            End If
        Next
    End Sub

    Private Sub cboSchedule_Enter(sender As Object, e As System.EventArgs) Handles cboSchedule.Enter

    End Sub

    Private Sub cboSchedule_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSchedule.KeyDown
        If e.KeyCode = Keys.ControlKey Then
            ShowScheduleEditorButton("LAUNCH")
        End If
    End Sub

    Private Sub cboSchedule_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSchedule.KeyUp
        If e.KeyCode = Keys.ControlKey Then
            ShowScheduleEditorButton("LAUNCH", False)
        End If
    End Sub

    Private Sub chkBakFTP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBakFTP.CheckedChanged
        If chkBakFTP.Checked Then
            cboFTPProfile.Enabled = True
            txtRemoteFolder.Enabled = True
            chkTestDir.Enabled = True
        Else
            cboFTPProfile.EditValue = Nothing
            cboFTPProfile.Enabled = False
            txtRemoteFolder.Text = ""
            txtRemoteFolder.Enabled = False
            chkTestDir.Enabled = False
        End If
    End Sub

    Private Sub cboBackupProfile_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboBackupProfile.EditValueChanged
        Dim oProfile As New oProfile
        Dim cProfCode As String = NullToString(cboBackupProfile.EditValue)

        If Not cProfCode = "" Then
            'load profile from DB
            If oProfile.Load(NullToString(cProfCode)) Then
                txtSchedBakDir.Text = oProfile.ExpFolder
            Else
                txtSchedBakDir.Text = ""
            End If
        Else
            txtSchedBakDir.Text = ""
        End If
    End Sub

#End Region

#Region "Mixed Functions"
    'RETURNS: TRUE, if required entries are valid
    Private Function ValidateEntries(Optional ByRef cErr As String = "", Optional ByVal bDisplayError As Boolean = False) As Boolean
        Dim bRetVal As Boolean = False
        cErr = ""

        Select Case UCase(tabControl.SelectedTabPage.Name)
            Case UCase("tabRestore")
                If NullToString(cmdBrowseRestoreFile.Text) = "" Then
                    AddErr(cErr, "[Backup File] must have a value")
                End If

            Case UCase("tabBackUp")
                If NullToString(txtExPath.Text) = "" Then
                    AddErr(cErr, "[Backup Folder] must have a value")
                End If

            Case UCase("tabFTP")
                If NullToString(txtFTP_Host.Text) = "" Then
                    AddErr(cErr, "[FTP Host] must have a value")
                End If
                If NullToString(txtFTP_User.Text) = "" Then
                    AddErr(cErr, "[FTP User] must have a value")
                End If

            Case UCase("tabEmail")
                If NullToString(txtSMTP_Host.Text) = "" Then
                    AddErr(cErr, "[SMTP Host] must have a value")
                End If
                If NullToString(txtSMTP_User.Text) = "" Then
                    AddErr(cErr, "[SMTP User] must have a value")
                End If
                If EmailAccountType.Value = 0 Then
                    If NullToString(txtSMTP_Email.Text) = "" Then
                        AddErr(cErr, "[Email Address] must have a value")
                    End If
                End If

            Case UCase("tabSched")
                Dim nDays As Integer = 0
                'If tbActive.EditValue = 1 Then
                'perform validation if user activated the schedule
                If NullToAny(cboBackupProfile.EditValue) Is Nothing Then
                    AddErr(cErr, "[Backup Profile] must have a value")
                End If

                Sched_Days("GET", nDays)
                If nDays = 0 Then
                    AddErr(cErr, "[Days] must have a value")
                End If

                If chkBakFTP.Checked Then
                    If NullToAny(cboFTPProfile.EditValue) Is Nothing Then
                        AddErr(cErr, "[FTP Profile] must have a value")
                    End If

                    If NullToString(txtRemoteFolder.Text) = "" Then
                        AddErr(cErr, "[Remote Folder] must have a value")
                    End If
                End If

                'End If
        End Select

        If cErr.Length = 0 Then
            bRetVal = True
        End If

        'display error message
        If Not bRetVal And bDisplayError Then
            MsgBox(cErr, , "Please correct the following")
        End If

        Return bRetVal
    End Function

    Private Sub RefreshData()

        'refresh datasource
        Select Case UCase(tabControl.SelectedTabPage.Name)
            Case UCase("tabBackup")
                cboExProfileName.Properties.DataSource = GetDataTable("PROFILE_LIST")

            Case UCase("tabFTP")
                cboFTP.Properties.DataSource = GetDataTable("INET_LIST", INET_Type.FTP)

            Case UCase("tabEmail")
                cboEmail.Properties.DataSource = GetDataTable("INET_LIST", INET_Type.SMTP)
                ChangeEmailTabLabels(IIf(EmailAccountType.Value = 0, "SMTP", "POP"))
            Case UCase("tabNotify")
                cboAlertSmtp.Properties.DataSource = GetDataTable("INET_LIST", INET_Type.SMTP)
                _tblEmailNotif = GetDataTable("EMAIL_NOTIF_LIST")
                Dim primaryKey(1) As DataColumn
                primaryKey(0) = _tblEmailNotif.Columns("Email")
                _tblEmailNotif.PrimaryKey = primaryKey
                GridControlEmailNotif.DataSource = _tblEmailNotif

            Case UCase("tabSched")
                cboSchedule.Properties.DataSource = GetDataTable("SCHED_LIST")
                cboFTPProfile.Properties.DataSource = GetDataTable("INET_LIST", INET_Type.FTP)
                cboBackupProfile.Properties.DataSource = GetDataTable("PROFILE_LIST")

            Case UCase("tabTransfers")
                'transfers
                RefreshEventLog()
                RefreshTransferLog()

            Case UCase("tabSQLServerCon")

                cboAuth.Properties.DataSource = GetAuth()
                lblDatabases.Text = UCase(INI_GetConfig(AppAcronym, "SERVER_DB_SCHEMAS", ""))
                txtServer.Text = INI_GetConfig(AppAcronym, "SERVER_INSTANCE")
                cboAuth.EditValue = INI_GetConfig(AppAcronym, "SERVER_AUTH")
                txtUser.Text = INI_GetConfig(AppAcronym, "SERVER_USER")
                txtPwd.Text = INI_GetConfig(AppAcronym, "SERVER_PWD")
                cmdBrowseSharedFolder.Text = GetConfig(oDLSQLSERVER, "SERVER_SHARED_PATH", "")

            Case UCase("tabLicensing")
                RefreshTabLicensing()

        End Select
    End Sub

#End Region

    Private Sub cmdCLearLog_Click(sender As System.Object, e As System.EventArgs) Handles cmdCLearLog.Click
        If MsgBox("Are you sure you want to clear the event log?", vbQuestion + vbYesNo + vbDefaultButton2, "Clear log") = MsgBoxResult.Yes Then
            Dim cSQL As String = "DELETE FROM tblSTIService_eventlog;"
            oDLSQLSERVER.ExecuteNonQuery(cSQL)
            RefreshEventLog()
        End If
    End Sub

    Private Sub cmdRefreshTransfers_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefreshTransfers.Click
        RefreshTransferLog()
    End Sub

    Private Sub cmdViewLog_Click(sender As System.Object, e As System.EventArgs) Handles cmdViewLog.Click
        Dim oTransfer As New oTransfer
        Dim cTransfer_Code As String = GridViewTransfers.GetFocusedRowCellValue("transfer_code")

        oTransfer.Transfer_Code = cTransfer_Code
        If oTransfer.MainLog.Length > 0 Then
            ShowLog(oTransfer.MainLog.ToString)
        Else
            MsgBox("The log is empty", vbInformation)
        End If

    End Sub

    Private Sub cmdDelTransfer_Click(sender As System.Object, e As System.EventArgs) Handles cmdDelTransfer.Click
        Dim oTransfer As New oTransfer
        Dim cTransfer_Code As String = GridViewTransfers.GetFocusedRowCellValue("transfer_code")
        Dim bConfirm As Boolean = False

        oTransfer.Transfer_Code = cTransfer_Code
        If oTransfer.SendOrReceive = ActionType.Restore And Control.ModifierKeys <> Keys.Control Then
            MsgBox("To preserve file synchronization integrity, Import based transfers are NOT allowed to be deleted. Items will remain in the queue UNTIL they are successfully received via FTP.", vbInformation, "Delete Transfer")
        Else
            If MsgBox("Are you sure you want to PERMANENTLY delete the selected transfer?", vbQuestion + vbYesNo + vbDefaultButton2, "Delete Transfer") = vbYes Then
                oTransfer.Delete()
                Call cmdRefreshTransfers_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub RepositoryItemButtonEdit_ViewLog_Click(sender As Object, e As System.EventArgs) Handles RepositoryItemButtonEdit_ViewLog.Click
        Dim GridViewFileSync As DevExpress.XtraGrid.Views.Grid.GridView = GridViewTransfers.GetDetailView(GridViewTransfers.FocusedRowHandle, 0)
        Dim cTransfer_Code As String = GridViewTransfers.GetFocusedRowCellValue("transfer_code")
        Dim cIDNbr As String = RemoveInject(GridViewFileSync.GetFocusedRowCellValue("idnbr").ToString())
        Dim cFileName As String = RemoveInject(GridViewFileSync.GetFocusedRowCellValue("filename").ToString())
        Dim cFileLog As String = ""

        cFileLog = oDLSQLSERVER.DLookUpSQL("LastStatus", "SELECT LastStatus FROM tbl_filesync t WHERE transfer_code='" & cTransfer_Code & "' and filename='" & cFileName & "' and idnbr='" & cIDNbr & "';")
        If cFileLog <> "" Then
            ShowLog(cFileLog)
        Else
            MsgBox("No further details", vbInformation)
        End If

    End Sub

    Private Sub cmdRefreshLog_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefreshLog.Click
        RefreshEventLog()
    End Sub

    Private Sub TimerServiceStatus_Tick(sender As System.Object, e As System.EventArgs) Handles TimerServiceStatus.Tick
        Dim cErr As String = ""
        Dim nAffected As Long = 0
        Dim cStat As String = GetServiceInfo()

        If chkSimulateService.Checked Then
            Service_DoWork(ServiceCallingModule.SimulatedService)
        End If

        Application.DoEvents()

        If cStat <> cLastServiceStat Then
            cLastServiceStat = cStat
            DisplayLog(cStat, True) 'display service workload
        End If

        'update time
        Dim dServerDate As DateTime = oDLSQLSERVER.MSSql_GetServerTime(cErr)
        If cErr = "" Then
            lblActiveTime.Text = dServerDate.ToString("hh:mm:ss tt") 'Now.ToString("hh:mm:ss tt")
            lblActiveDate.Text = dServerDate.ToString("yyyy-MM-dd") 'Now.ToString("yyyy-MM-dd")
        Else
            lblActiveTime.Text = "DBServer Err"
            lblActiveDate.Text = "Reconnecting..."

        End If

        'update LIVE STATUS
        UpdateLiveStats()

        Application.DoEvents()

    End Sub

    Private Sub UpdateLiveStats()
        Dim cSaveStatErr As String = ""
        Dim cLiveStats As String = ""
        Dim pServiceInitiator As ServiceCallingModule = GetLiveStatus(cLiveStats, cSaveStatErr)
        Dim cCaption As String = GetItemDelimited(cLiveStats, 2, "|")
        Dim cDesc As String = GetItemDelimited(cLiveStats, 3, "|")
        Dim cServiceType As String = ""


        'obtain the status the direct way
        If chkSimulateService.Checked Then
            pServiceInitiator = ServiceCallingModule.SimulatedService
        Else
            If ServiceStatus() = ServiceProcess.ServiceControllerStatus.Running Then
                pServiceInitiator = ServiceCallingModule.Service
            Else
                pServiceInitiator = ServiceCallingModule.None
            End If
        End If

        If cSaveStatErr <> "" Then
            cCaption = "MPS2_TBL Database Problem..."
            cDesc = cSaveStatErr
        End If

        If cCaption = "" Then
            cCaption = "Idle..."
            cDesc = "Waiting for status from service..."
        End If

        'update live stats display
        '-----------------------------------------------------------------------------------------
        Select Case pServiceInitiator
            Case ServiceCallingModule.Service, ServiceCallingModule.SimulatedService
                If cCaption <> "" Then
                    Select Case pServiceInitiator
                        Case ServiceCallingModule.Service
                            cServiceType = "(Service)"
                        Case ServiceCallingModule.SimulatedService
                            cServiceType = "(Simulated Service)"
                        Case Else
                            cServiceType = ""
                    End Select
                    ProgressPanel_Active.Visible = True
                    ProgressPanel_Active.Caption = cCaption & cServiceType
                    ProgressPanel_Active.Description = cDesc
                    ProgressPanel_Active.ShowDescription = IIf(cDesc <> "", True, False)
                Else
                    ProgressPanel_Active.Visible = False
                End If
            Case ServiceCallingModule.None
                ProgressPanel_Active.Visible = False
        End Select

    End Sub

    Private Sub ChangeLoadingPicture()
        Dim commonSkin As Skin = CommonSkins.GetSkin(UserLookAndFeel.[Default].ActiveLookAndFeel)
        Dim loadingBig As SkinElement = commonSkin("LoadingBig")
        loadingBig.Image.SetImage(ImageCollection1.Images(4), Color.Empty)
    End Sub

    Private Sub chkSimulateService_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSimulateService.CheckedChanged
        chkSimulateService.Visible = chkSimulateService.Checked
        If chkSimulateService.Checked Then
            SetLiveStatus(ServiceCallingModule.SimulatedService & "||")
        Else
            SetLiveStatus(ServiceCallingModule.None & "||")
        End If
    End Sub

    Private Sub cmdViewServiceSched_Click(sender As System.Object, e As System.EventArgs) Handles cmdViewServiceSched.Click
        Dim dt As DataTable = Nothing
        Dim dr As DataRow = Nothing
        Dim cHeader As String = ""
        Dim cSched As String = ""

        dt = GetDataTable("SCHED_QUEUE")

        cHeader = cHeader & "MS Sql Date: " & oDLSQLSERVER.MSSql_GetServerTime.ToLongDateString & vbCrLf & vbCrLf
        cHeader = cHeader & "Schedule Name".PadRight(50) & " " & "Next Run".PadRight(25) & " " & "Last Run".PadRight(25) & vbCrLf
        cHeader = cHeader & StrDup(100, "-") & vbCrLf

        If Not dt Is Nothing AndAlso dt.Rows.Count <> 0 Then
            dr = dt.Rows(0)
            For Each dr In dt.Rows
                cSched = cSched & NullToString(dr.Item("sname")).PadRight(50) & " " & NullToString(dr.Item("nextrun")).PadRight(25) & " " & NullToString(dr.Item("lastrun")).PadRight(25) & vbCrLf
            Next
        Else
            cSched = cSched & " *** No ACTIVE Schedule Found ***"
        End If

        ShowLog(cHeader & cSched)
    End Sub

    Private Sub RefreshEventLog()
        GridControlEventLog.DataSource = oDLSQLSERVER.ExecuteDataTable("SELECT * FROM tblSTIService_eventlog ORDER BY logtime DESC")
    End Sub

    Private Sub RefreshTransferLog()
        GridControlTransfers.DataSource = oDLSQLSERVER.ExecuteDataTable("SELECT tblSTIService_transfers.[Transfer_Code], tblSTIService_schedule.SCHED_Name, tblSTIService_transfers.DataFile, tblSTIService_transfers.LastStatus" & _
" FROM tblSTIService_transfers INNER JOIN tblSTIService_schedule ON tblSTIService_transfers.SCHED_Code = tblSTIService_schedule.SCHED_Code")
    End Sub

    
End Class