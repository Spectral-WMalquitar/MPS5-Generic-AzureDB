Imports System.Security.Permissions
Imports System.Security.AccessControl
Imports System.Security

Public Module MPS4BasicFunctions
    Public Const DEFAULT_VERSION As String = "1.10.33"
    Public Const DEFAULT_VERSION_DATE As String = "2019-08-12"

    Public CONTENTTYPE As String = ""
    Public MPSVersion As String = " - (v0.0)"
    Public VERSION_DATE As Date
    Public MPSDB As SQLDB
    Public SQLServer As String
    Public SQLID As String
    Public SQLPW As String
    Public VERSION As Double
    Public HDD_ID As String
    Public Const DEMO_SERIALKEY As String = "MPSDEVSERIAL" ' If <> '' Then MPS App is for Demo purposes only 'Default value: MPSDEVSERIAL
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Dim path As String = "HKEY_CURRENT_USER\Software\MPS4" 'Path of the Registry
    Public REFRESHRATE As String = "Automatic"
    'the Connection String for your Solution
    Public Function GetConnectionString()
        Return "Data Source=" & SQLServer & ";Database=MPS;Persist Security Info=True;User ID=" & SQLID & ";Password=" & SQLPW & ";"
        'Return "Data Source=DEVELOPERONE-PC\STISQLServer;Database=MPS;Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS"
    End Function

    Public oLogDeletion As New LogDeletion

    Public Function CreateConnectionString(cHost As String, cUID As String, cPwd As String)
        Return "Data Source=" & cHost & ";Database=MPS;Persist Security Info=True;User ID=" & cUID & ";Password=" & cPwd & ";"
    End Function

    'the Connection String for your Solution
    Public Function GetConnectionString(DataBaseName As String)
        Return "Data Source=" & SQLServer & ";Database=" & DataBaseName & ";Persist Security Info=True;User ID=" & SQLID & ";Password=" & SQLPW & ";"
        'Return "Data Source=DEVELOPERONE-PC\STISQLServer;Database=MPS;Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS"
    End Function


    'Public Const IniFilePath As String = GetAppPath() & "\settings.ini"
    Private _IniFilePath As String = System.Windows.Forms.Application.StartupPath & "\setting.ini"
    Public ReadOnly Property IniFilePath() As String
        Get
            Return _IniFilePath
        End Get
    End Property

    'geting Values or item/s in settings.ini file
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetIni(ByVal cKey As String, Optional isEncrypted As Boolean = False) As String
        Dim retval As New System.Text.StringBuilder(300)
        GetPrivateProfileString("APP", cKey, "", retval, 300, IniFilePath)
        Return IIf(isEncrypted, usrCryptography("DECRYPT", retval.ToString), retval.ToString)
    End Function

    Public Sub initDefaultIniFile()
        Dim strDir As String = IniFilePath
        Try

            If Not System.IO.File.Exists(IniFilePath) Then
                Dim fs As System.IO.FileStream = System.IO.File.Create(IniFilePath)
                fs.Close()
            End If

            '<!-- commented out by tony20171009 : no need to by pass folder permission rights. Client should be the one who make necessary access assignments
            'Dim dirinfo As New System.IO.FileInfo(strDir)
            'Dim dirsec As System.Security.AccessControl.FileSecurity = dirinfo.GetAccessControl
            'dirsec.AddAccessRule(New System.Security.AccessControl.FileSystemAccessRule(Environment.UserDomainName & "\Administrator", FileSystemRights.FullControl, AccessControlType.Allow))
            'System.IO.File.SetAccessControl(strDir, dirsec)
            '-->
            InitIniValues()
        Catch ex As Exception
            MsgBox(ex.Message, , GetAppName)
            Application.Exit()
        End Try
    End Sub

    Private Sub InitIniValues()
        'Default Values for INI
        If System.IO.File.Exists(IniFilePath) Then
            'WriteIni("VERSION", IfNull(GetIni("VERSION"), "1.00"))
            'WriteIni("VERSIONDATE", IfNull(GetIni("VERSIONDATE"), "2010-01-01"))

            If Not GetIni("VERSION").Trim.Length > 0 Then
                'tony20170927 WriteIni("VERSION", "1.00")
                WriteIni("VERSION", DEFAULT_VERSION)
            End If

            If Not GetIni("VERSIONDATE").Trim.Length > 0 Then
                'tony20170927 WriteIni("VERSIONDATE", "2010-01-01")
                WriteIni("VERSIONDATE", DEFAULT_VERSION_DATE)
            End If
        Else
            'tony20170927 WriteIni("VERSION", "1.00")
            'WriteIni("VERSIONDATE", "2010-01-01")
            WriteIni("VERSION", DEFAULT_VERSION)
            WriteIni("VERSIONDATE", DEFAULT_VERSION_DATE)

        End If
    End Sub


    'write or modify the value of an item in settings.ini
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Sub WriteIni(ByVal ckey As String, ByVal cVal As String, Optional isEncrypted As Boolean = False)
        WritePrivateProfileString("APP", ckey, IIf(isEncrypted, usrCryptography("ENCRYPT", cVal), cVal), IniFilePath)
    End Sub

    'Write the data and the value
    Public Sub WriteReg(ByVal ckey As String, ByVal cVal As String)
        Try
            'If My.Computer.Registry.GetValue(path, ckey, Nothing) Then
            My.Computer.Registry.SetValue(path, ckey, AES_Encrypt(cVal, "MPS4"))
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'get the Data from the Registry
    Public Function GetReg(ByVal ckey As String) As String
        'Dim path As String = "HKEY_CURRENT_USER\Software\MPS4"
        Dim data As String
        Dim decData As String
        data = My.Computer.Registry.GetValue(path, ckey, Nothing)
        If data <> "" Or data <> Nothing Then
            decData = AES_Decrypt(data, "MPS4")
            Return decData
        Else
            decData = ""
        End If
        Return decData

        'Dim data As String
        'Dim decData As String
        'data = GetIni(ckey)
        'If data <> "" Or data <> Nothing Then
        '    decData = usrCryptography("DECRYPT", data)
        '    Return decData
        'Else
        '    decData = ""
        'End If
        'Return decData

    End Function

    Public Class INIFile
        Public FilePath As String

        Public Sub New()

        End Sub

        Public Sub New(cFilePath As String)
            FilePath = cFilePath
        End Sub

        Public Function GetValue(ByVal cApp As String, ByVal cKey As String) As String
            Dim retval As New System.Text.StringBuilder()
            GetPrivateProfileString(cApp, cKey, "", retval, 500, FilePath)
            Return retval.ToString
        End Function

        Public Sub WriteValue(ByVal cApp As String, ByVal ckey As String, ByVal cVal As String)
            WritePrivateProfileString(cApp, ckey, cVal, FilePath)
        End Sub
    End Class

    'Generic Inputbox for MPS
    Public Function MPSInputDialog(ByVal _Title As String, Optional ByVal _OKbutton As String = "Ok")
        Dim str As String = ""
        Dim frm As New MPSInputBox
        frm.setLabel(_Title)
        frm.setOkBtnCaption(_OKbutton)
        'frm.setValue(_Value)
        frm.ShowDialog()
        str = frm.getValue()
        Return str
    End Function

    Public Function CheckFolderPermission(_filePath As String) As Boolean
        Dim retVal As Boolean = False
        Dim writeAllow = False
        Dim writeDeny = False
        Try
            Dim accessControlList = IO.Directory.GetAccessControl(_filePath)
            If accessControlList Is Nothing Then

                retVal = False
            End If
            Dim accessRules = accessControlList.GetAccessRules(True, True, GetType(System.Security.Principal.SecurityIdentifier))
            If accessRules Is Nothing Then
                retVal = False
            End If

            For Each rule As FileSystemAccessRule In accessRules
                If (FileSystemRights.Write And rule.FileSystemRights) <> FileSystemRights.Write Then
                    Continue For
                End If

                If rule.AccessControlType = AccessControlType.Allow Then
                    writeAllow = True
                    'ElseIf rule.AccessControlType = AccessControlType.Deny Then
                    '    writeDeny = True
                End If
            Next
            retVal = writeAllow AndAlso Not writeDeny

        Catch ex As Exception
            retVal = False
        End Try
        Return retVal
    End Function

    Public Sub AddUnboundColumn(View As DevExpress.XtraGrid.Views.Grid.GridView, Grid As DevExpress.XtraGrid.GridControl, FieldName As String, Caption As String, Optional visible As Boolean = True, Optional width As Integer = 150)
        Grid.ForceInitialize()
        Dim newCol As DevExpress.XtraGrid.Columns.GridColumn = View.Columns.AddField(FieldName)
        newCol.VisibleIndex() = View.Columns.Count + 1
        newCol.UnboundType = DevExpress.Data.UnboundColumnType.String
        newCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
        'newCol.ColumnEdit = repBtnEditTravelDoc
        newCol.Caption = Caption
        'visibility
        If visible Then
            newCol.Visible = True
            newCol.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True
        Else
            newCol.Visible = False
            newCol.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        End If
        'newCol.OptionsColumn.ReadOnly = True
        'newCol.OptionsColumn.AllowFocus = False
        'View.VisibleColumns(1).Width = width

    End Sub

    Public Function NumberToOrdinal(num As Long) As String
        Dim retVal As String = num.ToString & "th"
        retVal = IIf(num.ToString.EndsWith("1"), num.ToString & "st", retVal)
        retVal = IIf(num.ToString.EndsWith("2"), num.ToString & "nd", retVal)
        retVal = IIf(num.ToString.EndsWith("3"), num.ToString & "rd", retVal)
        retVal = IIf(num.ToString.EndsWith("11"), num.ToString & "th", retVal)
        retVal = IIf(num.ToString.EndsWith("12"), num.ToString & "th", retVal)
        retVal = IIf(num.ToString.EndsWith("13"), num.ToString & "th", retVal)
        Return retVal
    End Function

    Public Function GetLogo() As Image
        Dim retVal As String = MPSDB.DLookUp("TextValue", "tblConfig", "", "Code='LOGOPATH'")
        If IO.File.Exists(retVal) Then
            Try
                Return Image.FromFile(retVal)
            Catch ex As Exception
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Public Function GetDateExpiry(DocumentCode As String, DateIssue As Date, Optional CntryCode As String = "NULL")
        Dim retval As Object = System.DBNull.Value
        Dim strValidity() As String
        Dim xYear As Integer = 0
        Dim xMonth As Integer = 0
        Dim xWeek As Integer = 0
        Dim xDays As Integer = 0
        Dim val As String = 0

        val = MPSDB.DLookUp("Validity", "DocValidityMap", "", "PKey='" & DocumentCode & "' AND FKeyCntry=" & IIf(Not CntryCode.Equals("NULL"), "'" & CntryCode & "'", CntryCode) & "")

        If Not Trim(val).Equals("") Then
            strValidity = val.Split(".")

            '<!-- edited by tony20170918
            If strValidity.GetUpperBound(0) >= 0 Then
                xYear = CInt(IIf(strValidity(0).Equals(""), "0", strValidity(0)))
            Else
                xYear = 0
            End If

            If strValidity.GetUpperBound(0) >= 1 Then
                xMonth = CInt(IIf(strValidity(1).Equals(""), "0", strValidity(1)))
            Else
                xMonth = 0
            End If

            If strValidity.GetUpperBound(0) >= 2 Then
                xDays = CInt(IIf(strValidity(2).Equals(""), "0", strValidity(2)))
            Else
                xDays = 0
            End If

            'xYear = CInt(IIf(strValidity(0).Equals(""), "0", strValidity(0)))
            'xMonth = CInt(IIf(strValidity(1).Equals(""), "0", strValidity(1)))
            'xDays = CInt(IIf(strValidity(2).Equals(""), "0", strValidity(2)))
            '-->

            '--edited by fords 20171116
            If xYear = 0 And xMonth = 0 And xDays = 0 Then
                retval = Nothing
            Else
                DateIssue = DateIssue.AddYears(xYear)
                DateIssue = DateIssue.AddMonths(xMonth)
                DateIssue = DateIssue.AddDays(xDays)
                retval = DateIssue
            End If
            '--end 20171116
        End If
        Return retval
    End Function

    Public Function GetDateExpiryNoCountry(DocumentCode As String, DateIssue As Date)
        Dim retval As Object = System.DBNull.Value
        Dim strValidity() As String
        Dim xYear As Integer = 0
        Dim xMonth As Integer = 0
        Dim xWeek As Integer = 0
        Dim xDays As Integer = 0
        Dim val As String = 0

        val = MPSDB.DLookUp("Validity", "DocValidityMap", "", "PKey='" & DocumentCode & "'")

        If Not Trim(val).Equals("") Then
            strValidity = val.Split(".")

            '<!-- edited by tony20170918
            If strValidity.GetUpperBound(0) >= 0 Then
                xYear = CInt(IIf(strValidity(0).Equals(""), "0", strValidity(0)))
            Else
                xYear = 0
            End If

            If strValidity.GetUpperBound(0) >= 1 Then
                xMonth = CInt(IIf(strValidity(1).Equals(""), "0", strValidity(1)))
            Else
                xMonth = 0
            End If

            If strValidity.GetUpperBound(0) >= 2 Then
                xDays = CInt(IIf(strValidity(2).Equals(""), "0", strValidity(2)))
            Else
                xDays = 0
            End If

            'xYear = CInt(IIf(strValidity(0).Equals(""), "0", strValidity(0)))
            'xMonth = CInt(IIf(strValidity(1).Equals(""), "0", strValidity(1)))
            'xDays = CInt(IIf(strValidity(2).Equals(""), "0", strValidity(2)))
            '-->
            DateIssue = DateIssue.AddYears(xYear)
            DateIssue = DateIssue.AddMonths(xMonth)
            DateIssue = DateIssue.AddDays(xDays)
            retval = DateIssue
        End If
        Return retval
    End Function

    '************** Versioning And Licensing Purposes ******************
    Public Sub CheckAppVersion(ByVal cCallingModule As String, ByVal cSQLServer As String, ByVal cSQLID As String, ByVal cSQLPW As String, Optional ByRef cErr As String = "", Optional isProgramOpen As Boolean = False)
        Try
            Dim str As String = "Data Source=" & cSQLServer & ";Persist Security Info=True;User ID=" & cSQLID & ";Password=" & cSQLPW & ";"
            Dim cCurVersion As String
            Dim nCurDBVersion As String = ""
            Dim cCurVersionDate As String
            Dim oAppVersion As New clsVersioning(str)

            cCurVersion = IIf(Trim(CType(GetIni("VERSION"), String)) = "" Or IsNothing(Trim(CType(GetIni("VERSION"), String))), "", Trim(CType(GetIni("VERSION"), String)))
            cCurVersionDate = IIf(Trim(CType(GetIni("VERSIONDATE"), String)) = "" Or IsNothing(Trim(CType(GetIni("VERSIONDATE"), String))), "", Trim(CType(GetIni("VERSIONDATE"), String)))

            If oAppVersion.IsInitialized(cCurVersion) Then

                If oAppVersion.IsVersionUpdated(cCurVersion, nCurDBVersion) Then
                    MPSVersion = " - ( v " & cCurVersion & " )"
                    Try
                        If cCurVersionDate <> "" Then
                            VERSION_DATE = DateSerial(cCurVersionDate.Substring(0, 4), cCurVersionDate.Substring(5, 2), cCurVersionDate.Substring(8, 2))
                        Else
                            VERSION_DATE = Date.Now
                        End If
                    Catch ex As Exception
                        VERSION_DATE = Date.Now
                    End Try
                Else
                    If oAppVersion.IsNewVersion(nCurDBVersion, cCurVersion) Then
                        Dim cMsg As String = ""
                        If isProgramOpen Then
                            cMsg = "A new version of application is available!" & vbNewLine & vbNewLine &
                                   "Latest Version: " & nCurDBVersion.ToString & vbNewLine &
                                   "Your Version: " & cCurVersion & vbNewLine & vbNewLine &
                                   "Please save all your changes before proceeding, updating will close MPS Program." & vbNewLine & vbNewLine &
                                   "Do you wish to update?"
                        Else
                            cMsg = "A new version of application is available!" & vbNewLine & vbNewLine &
                                   "Latest Version: " & nCurDBVersion.ToString & vbNewLine &
                                   "Your Version: " & cCurVersion & vbNewLine & vbNewLine &
                                   "Do you wish to update?"
                        End If
                        If MsgBox(cMsg, MsgBoxStyle.Information + MsgBoxStyle.YesNo + vbDefaultButton2, "Version not sync.") = MsgBoxResult.Yes Then

                            Dim nCrewingInstance As Integer = 0
                            Dim nAdminInstance As Integer = 0
                            nCrewingInstance = System.Diagnostics.Process.GetProcessesByName("Crewing").Count
                            nAdminInstance = System.Diagnostics.Process.GetProcessesByName("Admin").Count

                            If cCallingModule = "ADMIN" Then
                                If nCrewingInstance > 0 Then
                                    MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "An instance of MPS Crewing detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                                    Exit Sub
                                End If

                                If nAdminInstance > 1 Then
                                    MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "Another instance of MPS Admin detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                                    Exit Sub
                                End If
                            ElseIf cCallingModule = "CREWING" Then
                                If nAdminInstance > 0 Then
                                    MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "An instance of MPS Admin detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                                    Exit Sub
                                End If

                                If nCrewingInstance > 1 Then
                                    MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "Another instance of MPS Crewing detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                                    Exit Sub
                                End If
                            End If

                            MPSVersion = " - ( v " & cCurVersion & " )"

                            Dim strArgs As String = "UPDATE " & cCurVersion & " """ & SQLServer & """ """ & SQLID & """ """ & SQLPW & """"

                            If System.Environment.OSVersion.Version.Major < 6 Then ' Windows XP
                                Try
                                    Shell("UpdateManager.exe " & strArgs, AppWinStyle.NormalFocus)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                                End Try
                                'stop application
                                Process.GetCurrentProcess.Kill()

                            Else ' Higher OS Versions

                                Dim pUpdater As New ProcessStartInfo
                                pUpdater.FileName = "UpdateManager.exe"
                                'defining arguments should be : [ACTIONTYPE] [CURRENT_INTERFACE_VERSION] [SQLSERVERINSTANCE] [USERNAME] [PASWRD]
                                'param ACTIONTYPE: [UPDATE or LOAD]
                                pUpdater.Arguments = strArgs
                                pUpdater.UseShellExecute = True
                                pUpdater.WindowStyle = ProcessWindowStyle.Normal
                                Try
                                    Dim proc As Process = Process.Start(pUpdater)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                                End Try
                                'stop application
                                Process.GetCurrentProcess.Kill()
                            End If

                        Else
                            If Not isProgramOpen Then
                                'stop application
                                Process.GetCurrentProcess.Kill()
                            End If
                        End If
                    ElseIf Not oAppVersion.IsNewVersion(nCurDBVersion, cCurVersion) And Not isProgramOpen Then
                        If MsgBox("You are trying to connect to an older version of database." & vbNewLine & vbNewLine &
                                  "This might lead to any database concerned error(s)." & vbNewLine & vbNewLine &
                                  "Database Version: " & nCurDBVersion.ToString & vbNewLine &
                                  "Interface Version: " & cCurVersion & vbNewLine & vbNewLine &
                                  "Continue Anyway?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + vbDefaultButton2, "Database not sync.") = MsgBoxResult.Yes Then
                            MPSVersion = " - ( v " & cCurVersion & " )"
                            Try
                                If cCurVersionDate <> "" Then
                                    VERSION_DATE = DateSerial(cCurVersionDate.Substring(0, 4), cCurVersionDate.Substring(5, 2), cCurVersionDate.Substring(8, 2))
                                Else
                                    VERSION_DATE = Date.Now
                                End If
                            Catch ex As Exception
                                VERSION_DATE = Date.Now
                            End Try
                        Else
                            'stop application
                            Process.GetCurrentProcess.Kill()
                        End If
                    End If
                End If
            Else
                'Application Version not initialized
            End If
        Catch ex As Exception
            MsgBox("An error occurred checking Application Version!", MsgBoxStyle.Exclamation)
            Process.GetCurrentProcess.Kill()
        End Try
    End Sub

    'Public Sub CheckMPSLicense(Optional ByRef cErr As String = "")
    '    Dim MyLicense As New MPSLicense
    '    Dim MylicenseStatus As New MPSLicenseStatus
    '    Dim bSuccess As Boolean = False

    '    bSuccess = MyLicense.GetLicenseFromServer(MPSDB, cErr)
    '    MylicenseStatus = MyLicense.ValidateLicense(MPSDB, cErr)

    '    MPS_LicenseStatus = MylicenseStatus

    '    If MylicenseStatus.StrLicenseMsg <> "" Then
    '        Dim xfrm As New frmActivate(True, MyLicense, MylicenseStatus)
    '        xfrm.ShowDialog()
    '    End If
    '    MyLicense.Dispose()
    '    MylicenseStatus.Dispose()
    'End Sub
    Public Sub CheckMPSLicense(Optional ByRef cErr As String = "")
        'Added by elmer
        Dim strLicType As String = ""

        Dim MyLicense As New MPSLicense
        Dim MyLicenseStatus As New MyLicenseStatus

        If IsInDebugMode() Then
            'edited by tony20171006 - do not show any message. 
            'MsgBox("MPS5 is running in debug mode. Skipping MPS License Check.", MsgBoxStyle.Information, "MPS License Check")
            Exit Sub
        End If

        strLicType = LicensingGetConfig("LTYPE", mps5_app)
        strLicType = sysMpsUserPassword("DECRYPT", strLicType)

        If strLicType = "" Then
            strLicType = "NO"
        End If

        MyLicenseStatus = xValidateLicense(mps5_app, strLicType, MyLicense)
        If MyLicenseStatus.ErrMsg <> "NETWORK LICENSE COMPROMISED" And MyLicenseStatus.StrLicenseMsg <> "DATETIME TAMPERED ERROR" Then
            EvaluateMyLicense(mps5_app.App_DbName, mps5_app.App_BackRegGPeriod, MyLicense, MyLicenseStatus)
        End If

        '*************************************************************
        MPS_LicenseStatus = MyLicenseStatus 'set MPS License Status
        '*************************************************************

        If MyLicenseStatus.ExpDays <= 30 Then
            Dim frm As New frmActivate(strLicType, MyLicense, MyLicenseStatus)
            frm.ShowDialog()
        End If
        MyLicense.Dispose()
        MyLicenseStatus.Dispose()
        'End elmer
    End Sub

    ' ''' <summary>
    ' ''' Shows the loading screen specified
    ' ''' </summary>
    ' ''' <param name="type">Type of the loading screen. Use GetType function on parameter</param>
    ' ''' <remarks>Always use built-in function GetType() on parameter : ShowCustomLoadScreen(GetType(SampleSplashScreenClass))</remarks>
    'Public Sub ShowCustomLoadScreen(type As System.Type, Optional caption As String = "Please Wait", Optional desc As String = "")
    '    Try
    '        'IF added by calvhin 20170118
    '        If DevExpress.XtraSplashScreen.SplashScreenManager.Default Is Nothing Then
    '            'DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(type, True, True)
    '            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(Application.OpenForms("frmCrewMain"), type, True, True, DevExpress.XtraSplashScreen.ParentFormState.Locked)
    '            If type.BaseType.Name.ToUpper = "WaitForm".ToUpper Then
    '                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption(caption)
    '                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription(desc)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        'MsgBox("Splash Screen Open : " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GetAppName())
    '        LogErrors("Splash Screen Open : " & ex.Message)
    '    End Try
    'End Sub

    'Public Sub CloseCustomLoadScreen()
    '    Try
    '        'if added by calvhin 20170118
    '        If DevExpress.XtraSplashScreen.SplashScreenManager.Default IsNot Nothing Then
    '            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
    '        End If
    '    Catch ex As Exception
    '        'MsgBox("Splash Screen Close : " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GetAppName())
    '        LogErrors("Splash Screen Close : " & ex.Message)
    '    End Try
    'End Sub

    '************** End Versioning And Licensing Purposes ******************
    Public Function IsInDebugMode() As Boolean
        Try
            Return System.Diagnostics.Debugger.IsAttached
        Catch ex As Exception
            Return False
        End Try
    End Function

#Region "Grid-related functions/procedures"
    Public Sub ShowRecordCountOnGridBand(ByRef gview As DevExpress.XtraGrid.Views.Grid.GridView, gband As DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim reccount As Integer = 0

        Try
            Dim advgview As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = TryCast(gview, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
            advgview.OptionsView.ShowBands = True
        Catch ex As Exception
            Debug.Print(ex.Message)

        End Try
        
        If Not gview.GridControl.DataSource Is Nothing Then
            Try
                'reccount = TryCast(gview.GridControl.DataSource, DataTable).Rows.Count
                reccount = gview.DataRowCount
            Catch
                reccount = 0
            End Try
        End If

        Try
            gband.Caption = "Record Count: " & reccount
        Catch
            gband.Caption = ""
        End Try

    End Sub

    Public Sub InitGridBandForRecordCount(gband As DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Try
            With gband.OptionsBand
                .AllowMove = False
                .AllowPress = False
                .AllowSize = False
            End With
        Catch ex As Exception
            LogErrors("Failed to initialize gridband. Error : " & ex.Message)
        End Try

        Try
            With gband.AppearanceHeader
                .Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
                .Options.UseFont = True
            End With
        Catch ex As Exception
            LogErrors("Failed to initialize gridband font. Error : " & ex.Message)
        End Try

        gband.Caption = ""
    End Sub

#End Region

#Region "Log Deletion"

    Public Class LogDeletion : Implements IDisposable
        Public listLogEntry As New List(Of RecordStructure)

        Public Sub New()

        End Sub

        Public Sub New(pCallingApp As CallingApp, pCallingForm As String, pDLL As String, pTableName As String, pWhereCond As String, pRecordDesc As String, pDelType As DeletionType, pDelDesc As String, pLastUpdatedBy As String, Optional pDatabaseName As String = "MPS", Optional pSchemaName As String = "dbo")
            CreateLogEntry(pCallingApp, pCallingForm, pDLL, pTableName, pWhereCond, pRecordDesc, pDelType, pDelDesc, pLastUpdatedBy)
        End Sub

        Public Sub Init()
            listLogEntry = New List(Of RecordStructure)
        End Sub

        'Public Sub New(pLogEntry As RecordStructure)
        '    CurrentLogEntry = pLogEntry
        'End Sub
        Public Sub CreateLogEntry(pCallingApp As CallingApp, pCallingForm As String, pDLL As String, pTableName As String, pWhereCond As String, pRecordDesc As String, pDelType As DeletionType, pDelDesc As String, pLastUpdatedBy As String, Optional pDatabaseName As String = "MPS", Optional pSchemaName As String = "dbo")
            Dim _logentry As New RecordStructure
            Try
                With _logentry
                    .CallingApp = pCallingApp
                    .CallingForm = pCallingForm
                    .DLL = pDLL
                    .TableName = pTableName
                    .WhereCond = pWhereCond
                    .RecordDesc = pRecordDesc
                    .DelType = pDelType
                    .DelDesc = pDelDesc
                    .LastUpdatedBy = pLastUpdatedBy
                    .UserInfo = pLastUpdatedBy
                    .DatabaseName = pDatabaseName
                    .SchemaName = pSchemaName
                End With
            Catch ex As Exception
                _logentry = Nothing
            End Try

            If Not IsNothing(_logentry) Then
                listLogEntry.Add(_logentry)
            End If
        End Sub

        Public Enum CallingApp
            Crewing = 1
            Admin = 2
            Database = 3
        End Enum

        Private ReadOnly Property GetCallingAppName(pCallingApp As CallingApp) As String
            Get
                Select Case pCallingApp
                    Case CallingApp.Admin
                        Return "ADMIN"
                    Case CallingApp.Crewing
                        Return "CREWING"
                    Case CallingApp.Database
                        Return "DATABASE"

                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property

        Public Enum DeletionType
            Manual = 0
            Automatic = 1
        End Enum


        Public Class RecordStructure
            Public CallingApp As CallingApp
            Public CallingForm As String
            Public DLL As String
            Public UserInfo As String
            Public DatabaseName As String
            Public SchemaName As String
            Public TableName As String
            Public WhereCond As String
            Public RecordDesc As String
            Public DelType As DeletionType
            Public DelDesc As String
            Public LastUpdatedBy As String

            Public Sub New()

            End Sub

            Public Sub New(pCallingApp As CallingApp, pCallingForm As String, pDLL As String, pTableName As String, pWhereCond As String, pRecordDesc As String, pDelType As DeletionType, pDelDesc As String, pLastUpdatedBy As String, Optional pDatabaseName As String = "MPS", Optional pSchemaName As String = "dbo")
                CallingApp = pCallingApp
                CallingForm = pCallingForm
                DLL = pDLL
                UserInfo = pLastUpdatedBy
                TableName = pTableName
                WhereCond = pWhereCond
                RecordDesc = pRecordDesc
                DelType = pDelType
                DelDesc = pDelDesc
                LastUpdatedBy = pLastUpdatedBy
                DatabaseName = pDatabaseName
                SchemaName = pSchemaName
            End Sub
        End Class

        Public Sub AddLogEntryToDatabase()
            If Not IsNothing(listLogEntry) Then
                For Each obj As RecordStructure In listLogEntry
                    Try
                        AddLogEntryToDatabase(obj)
                    Catch ex As Exception
                        LogErrors("Add Log Deletion : [" & obj.TableName & "] " & obj.RecordDesc & " | " & obj.WhereCond)
                    End Try
                Next

            End If
            listLogEntry.Clear()
            Me.Dispose()
        End Sub

        Private Sub AddLogEntryToDatabase(pLogEntry As RecordStructure)
            Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(MPSDB.GetConnectionString())
            Dim sqlTran As SqlClient.SqlTransaction = Nothing
            Dim da As New System.Data.SqlClient.SqlDataAdapter

            Try
                sqlConn.Open()
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = "AddDeletionLog"
                    cmd.CommandType = CommandType.StoredProcedure
                    With cmd.Parameters
                        .AddWithValue("@CallingApp", GetCallingAppName(pLogEntry.CallingApp))
                        .AddWithValue("@CallingForm", pLogEntry.CallingForm)
                        .AddWithValue("@DLL", pLogEntry.DLL)
                        .AddWithValue("@UserInfo", pLogEntry.UserInfo)
                        .AddWithValue("@TableName", pLogEntry.TableName)
                        .AddWithValue("@WhereCond", pLogEntry.WhereCond)
                        .AddWithValue("@RecordDesc", pLogEntry.RecordDesc)
                        .AddWithValue("@DelType", pLogEntry.DelType)
                        .AddWithValue("@DelDesc", pLogEntry.DelDesc)
                        .AddWithValue("@LastUpdatedBy", pLogEntry.LastUpdatedBy)
                        .AddWithValue("@DatabaseName", pLogEntry.DatabaseName)
                        .AddWithValue("@SchemaName", pLogEntry.SchemaName)
                    End With
                    Dim d As New DataTable
                    da.SelectCommand = cmd
                    cmd.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                sqlConn.Close()

            Finally
                sqlConn.Close()
            End Try
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
                listLogEntry = Nothing
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
#End Region

End Module
