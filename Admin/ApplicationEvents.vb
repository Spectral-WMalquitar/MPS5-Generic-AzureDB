Namespace My
    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            ShowCustomLoadScreen(GetType(MPS4.MPS4Splash_Admin))
            DevExpress.Skins.SkinManager.EnableFormSkins()
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin
            SetAppPath(System.Windows.Forms.Application.StartupPath)
            Update_UpdateManagerExe() ' check if theres an update for UpdateManager.exe

            '<!-- tony20171108 : changed saving of database connection. use ini instead of registry
            'SQLServer = GetIni("SERVER")
            'SQLID = GetIni("USERID")
            'SQLPW = GetIni("PASSWORD")
            SQLServer = GetIni("SERVER", True)
            SQLID = GetIni("USERID", True)
            SQLPW = GetIni("PASSWORD", True)
            'SQLServer = GetReg("SERVER")
            'SQLID = GetReg("USERID")
            'SQLPW = GetReg("PASSWORD")
            '-->
            If SQLServer <> "" And SQLID <> "" And SQLPW <> "" Then
                'DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(THEME_NAME) 'Theme
                MPSDB = New SQLDB(GetConnectionString(), GetConnectionString("MPS4A"))
                USER_SESSION = New MPSSession
                MPS_LicenseStatus = New MyLicenseStatus
                If Not MPSDB.Connect Then
                    SQLServer = ""
                    SQLID = ""
                    SQLPW = ""
                    '<!-- added by tony20170811
                    MsgBox("Unable to connect to the database. Please check your connection or consult your system administrator.", MsgBoxStyle.Critical, "Database Connection Failed")
                    Dim frm As New frmConnect
                    frm.ShowDialog()
                    If SQLServer = "" Or SQLID = "" Or SQLPW = "" Then
                        e.Cancel = True
                        Return
                    End If
                    '-->
                End If
            Else
                CloseCustomLoadScreen()
                'edited by tony20170223
                Dim bSuccess As Boolean = InitAppConnection()
                'Dim frmcon As New frmConnect(True)
                'frmcon.ShowDialog()
                If Not bSuccess Then
                    e.Cancel = True
                    Return
                    'Else
                    '    MyApplication_Startup(sender, e)
                End If
                'end tony

                ShowCustomLoadScreen(GetType(MPS4.MPS4_Splash))
            End If
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(THEME_NAME) 'Theme
            setFolderPermission()
        End Sub

        'initialize folder location
        Private Sub setFolderPermission()
            If IfNull(MPSDB.GetConfig("DefaultFolder"), "") <> "" Then
                FOLDERDIRECTORY = IfNull(MPSDB.GetConfig("DefaultFolder"), "")
            End If
        End Sub

        Private Sub Update_UpdateManagerExe()

            Dim strUpdateManager As String = "UpdateManager.exe"
            Dim strUpdate_UpdateManager As String = "Update_UpdateManager.exe"

            'check if theres an update for UpdateManager.exe
            If System.IO.File.Exists(CleanDirPath(GetAppPath) & strUpdate_UpdateManager) Then
                LogUpdate(StrDup(100, "*"))
                LogUpdate("Start Update: MPS UpdateManager.exe")
                If System.IO.File.Exists(CleanDirPath(GetAppPath) & strUpdateManager) Then
                    LogUpdate("Creating Backup : UpdateManager.exe")
                    'create a backup on UpdateManager.exe
                    Try
                        Application.DoEvents()
                        System.IO.File.Move(CleanDirPath(GetAppPath) & strUpdateManager, CleanDirPath(GetAppPath) & "UpdateManagerBackups\UpdateManager_" & Now.ToString("yyyyMMddmmss") & ".exe")
                        LogUpdate("Creating Backup : OK")
                    Catch ex As Exception
                        LogUpdate("Creating Backup : Failed (" & ex.Message & ")")
                    End Try

                End If

                LogUpdate("Performing Update : UpdateManager.exe")
                'perform update UpdateManager.exe
                Try
                    Application.DoEvents()
                    System.IO.File.Copy(CleanDirPath(GetAppPath) & strUpdate_UpdateManager, CleanDirPath(GetAppPath) & strUpdateManager, True)
                    System.IO.File.Delete(CleanDirPath(GetAppPath) & strUpdate_UpdateManager)
                    LogUpdate("Performing Update : OK")
                Catch ex As Exception
                    LogUpdate("Performing Update : Failed (" & ex.Message & ")")
                End Try
                LogUpdate(StrDup(100, "*"))
            End If

        End Sub

        Private Sub LogUpdate(ByVal strMsg As String)
            Dim strFileName As String
            If Not System.IO.Directory.Exists(GetAppPath() & "\UpdateManagerBackups") Then
                MkDir(GetAppPath() & "\UpdateManagerBackups")
            End If
            strFileName = GetAppPath() & "\UpdateManagerBackups" & "\UpdateManager_UpdateLog_" & Now.ToString("yyyyMMdd") & ".txt"
            Using sw As New System.IO.StreamWriter(strFileName, True)
                sw.WriteLine(Now.ToString("yyyy-MM-dd mm:ss") & " : " & strMsg)
            End Using
        End Sub

    End Class


End Namespace

