Imports System.ComponentModel
Imports System.Text
Public Class frmUpdate

    Private Const cTable_config As String = "[MPS].[dbo].[tblConfig]"

    Dim cServerName As String
    Dim cServerUser As String
    Dim cServerPwd As String

    Dim tmr As Integer = 0
    Dim cActionType As String
    Dim cCurVersion As String
    Dim cUsername As String
    Dim cObxPath As String
    Dim oDb As clsDB

    Dim sbLog As New StringBuilder("") 'stores log for whole update process
    Dim sbVersionLog As New StringBuilder("") 'stores log for every version update process
    Private nColStandard As Integer = 50
    Dim cErr As String = ""

    Dim nFilesUpdated As Integer = 0
    Dim nFilesError As Integer = 0
    Dim nFilesInvalid As Integer = 0

    Dim cUpdatesFolder As String
    Dim cTemp_Folder As String

    Private Sub _timer_Tick(sender As System.Object, e As System.EventArgs) Handles _timer.Tick
        tmr += 10
        If tmr = 100 Then
            _timer.Enabled = False
            Try
                UpdateProgram()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Public Sub New()
        InitializeComponent()

        Dim args() As String = Environment.GetCommandLineArgs()
        'Dim args() As String = {"APP.exe", "UPDATE", "1.00", "localhost\SQLEXPRESS", "sa", "stiteam"} 'test update
        'Dim args() As String = {"APP.exe", "LOAD", "1.00", "C:\Spectral\Update.obx", "Administrator", "localhost\SQLEXPRESS", "sa", "stiteam"} 'test load

        If args.Count = 6 Then
            'Update Version
            'sample: {"APP.exe", "UPDATE", "1.00", "localhost\SQLEXPRESS", "sa", "stiteam"}
            cActionType = args(1)
            cCurVersion = args(2)
            cServerName = args(3)
            cServerUser = args(4)
            cServerPwd = args(5)
            Dim oparamClsDb As New clsDB(ConstructConnString())
            oDb = oparamClsDb
        ElseIf args.Count = 8 Then
            'Load Version
            'sample: {"APP.exe", "LOAD","C:\update.obx", "1.00", "localhost\SQLEXPRESS", "sa", "stiteam"}
            cActionType = args(1)
            cCurVersion = args(2)
            cObxPath = args(3)
            cUsername = args(4)
            cServerName = args(5)
            cServerUser = args(6)
            cServerPwd = args(7)
            Dim oparamClsDb As New clsDB(ConstructConnString())
            oDb = oparamClsDb
        End If
    End Sub

    Sub UpdateProgram()
        '******** Shared Parameters *******
        Dim bSuccess As Boolean = False

        Dim cVersion As String
        Dim cVersionDate As String = ""
        Dim cDesc As String = ""
        Dim cBuilderDesc As New StringBuilder("")
        Dim cFolder As String
        Dim cFullBak_folder As String = ""
        Dim cBak_folder As String = ""

        Dim dStart As DateTime
        dStart = oDb.MSSql_GetServerTime()

        '******** End Parameters **********

        Select Case UCase(cActionType)

            Case "UPDATE" ' check latest version and try to update

                Init("UPDATE", bSuccess)

                If bSuccess Then
                    Log_Append(StrDup(100, "-"))
                    Log_Append("Getting update versions")
                    Log_Append(StrDup(100, "-"))

                    'get latest versions
                    Dim dtVersions As DataTable = oDb.oGetLatestVersions(cCurVersion)

                    If dtVersions.Rows.Count > 0 Then
                        Dim dr As DataRow
                        For Each dr In dtVersions.Rows

                            cVersion = IfNull(dr("AppVersion").ToString, "")
                            cVersionDate = IfNull(CType(dr("VersionDate"), DateTime).ToString("yyyy-MM-dd"), "")
                            cDesc = IfNull(dr("VersionDesc").ToString, "")
                            cFolder = IfNull(dr("ObjectPath").ToString, "")

                            If cVersion <> "" And UCase(cDesc) <> "BASE VERSION" Then

                                If Not bSuccess Then Exit For

                                'reset files var
                                nFilesUpdated = 0
                                nFilesError = 0
                                nFilesInvalid = 0

                                sbVersionLog.Clear()
                                Log_Append(sbVersionLog, "")
                                Log_Append(sbVersionLog, "Update Version to : ".PadRight(nColStandard) & cVersion)

                                'create temp folder
                                SetStatus("Creating temp_update folder ..")
                                cTemp_Folder = CleanPath(GetAppFolder) & "temp_update"
                                bSuccess = CreateUpdateFolder(cTemp_Folder)

                                Log_Append(sbVersionLog, "Create temp_folder :".PadRight(nColStandard) & GetResult(bSuccess, ""))

                                'collect updates
                                If bSuccess Then
                                    Log_Append(sbVersionLog, "Collecting required files from version: ".PadRight(nColStandard) & cVersion)
                                    SetStatus("Collecting required files from version: " & cVersion)
                                    Dim cFullUpdatesFolder As String = CleanPath(cUpdatesFolder) & cFolder
                                    If IsPathExist(cFullUpdatesFolder, True) Then
                                        If HasFolderPermission(cFullUpdatesFolder) Then
                                            Try
                                                Application.DoEvents()
                                                My.Computer.FileSystem.CopyDirectory(cFullUpdatesFolder, cTemp_Folder, True)
                                                Application.DoEvents()
                                                bSuccess = True
                                            Catch ex As Exception
                                                cErr = "Error occurred copying files."
                                                bSuccess = False
                                            End Try
                                        Else
                                            cErr = "No permission on Update folder :" & cFullUpdatesFolder
                                            bSuccess = False
                                        End If
                                    Else
                                        cErr = "Cannot locate Update folder :" & cFullUpdatesFolder
                                        bSuccess = False
                                    End If
                                End If
                                Log_Append(sbVersionLog, "Collection Status :".PadRight(nColStandard) & GetResult(bSuccess, cErr))


                                'clean temp_update folder
                                SetStatus("Cleaning temp update folder..")
                                CleanFolder(cTemp_Folder, "*.obx", IO.SearchOption.TopDirectoryOnly)

                                Log_Append(StrDup(100, "="))

                                'perform updates
                                cBak_folder = "Update_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & "_Version_" & cCurVersion & " - " & cVersion
                                cFullBak_folder = CleanPath(GetAppFolder() & "\obj_bak\" & cBak_folder)

                                If bSuccess Then
                                    PerformObjectUpdates(cBak_folder, dStart)
                                End If

                                Log_Write(cFullBak_folder & cBak_folder & ".txt", sbVersionLog)

                                If nFilesUpdated > 0 Then
                                    'zip files
                                    'zip all files
                                    Dim bTmpSuccess As Boolean
                                    Dim cZipFiles As String
                                    Dim cObjectsBakFile As String = cFullBak_folder & cBak_folder & ".obxbak"
                                    cZipFiles = cFullBak_folder & "*.*"
                                    bTmpSuccess = ZipFiles(cObjectsBakFile, cZipFiles, cErr)
                                    bSuccess = bSuccess And bTmpSuccess

                                    'deletes files
                                    If bTmpSuccess Then
                                        CleanFolder(cFullBak_folder, "*.dll|*.DLL|*.exe|*.EXE|*.txt", IO.SearchOption.TopDirectoryOnly)
                                    End If

                                    Log_Append(sbVersionLog, "Compressing backup")
                                    Log_Append(sbVersionLog, StrDup(100, "-"))
                                    Log_Append(sbVersionLog, "File: " & cObjectsBakFile & " ... " & GetResult(bTmpSuccess, cErr))
                                    Log_Append(sbVersionLog, StrDup(100, "-"))
                                End If

                                If bSuccess Then
                                    bSuccess = WriteSettingsIni("VERSION", cVersion, cErr)
                                    bSuccess = bSuccess And WriteSettingsIni("VERSIONDATE", cVersionDate, cErr)
                                    Log_Append(sbVersionLog, StrDup(100, "-"))
                                    Log_Append(sbVersionLog, "Update Version INI File :".PadRight(nColStandard) & GetResult(bSuccess, cErr))

                                    If bSuccess Then cCurVersion = cVersion 'update current version

                                End If
                                Log_Append(sbLog, sbVersionLog)

                            End If
                        Next
                    Else
                        Log_Append(StrDup(100, "-"))
                        Log_Append("No Valid Version Available")
                        Log_Append(StrDup(100, "-"))
                        Log_Append()
                    End If

                End If

            Case "LOAD" 'load update from obx file

                Init("LOAD", bSuccess)

                If Not bSuccess Then Exit Select

                sbVersionLog.Clear()
                Dim nServerVersion As String = oDb.oGetServerVersion()
                Log_Append(StrDup(100, "-"))
                Log_Append("Getting latest version :".PadRight(nColStandard) & nServerVersion)
                Log_Append(StrDup(100, "-"))

                'create temp folder
                SetStatus("Creating temp_update folder ..")
                cTemp_Folder = CleanPath(GetAppFolder) & "temp_update"
                bSuccess = CreateUpdateFolder(cTemp_Folder)
                Log_Append(sbVersionLog, "Create temp_folder :".PadRight(nColStandard) & GetResult(bSuccess, ""))

                If Not bSuccess Then Exit Select

                'extract update file to temp folder
                SetStatus("Extracting Files..")
                bSuccess = ZipExtract(cObxPath, cTemp_Folder, cErr)
                Log_Append(sbVersionLog, "Extract Update File :".PadRight(nColStandard) & GetResult(bSuccess, cErr))

                If Not bSuccess Then Exit Select

                'locate Update.txt
                SetStatus("Locating [ Update.txt ] ..")
                If IsPathExist(CleanPath(cTemp_Folder) & "Update.txt", False) Then
                    bSuccess = True
                Else
                    bSuccess = False
                    cErr = "Unable to find [ Update.txt ]"
                End If
                Log_Append(sbVersionLog, "Locate [ Update.txt ] :".PadRight(nColStandard) & GetResult(bSuccess, cErr))

                If Not bSuccess Then Exit Select

                'read [ Update.txt ]
                Dim cLine As String, cMode As String = ""
                cVersion = ""
                Using sw As New System.IO.StreamReader(CleanPath(cTemp_Folder) & "Update.txt")
                    Try
                        While Not sw.EndOfStream

                            If Not bSuccess Then Exit While

                            cLine = sw.ReadLine()
                            If Trim(cLine) <> "" Then
                                If cLine = "[UPDATEOBJECTS]" Then
                                    PerformObjectUpdates(cBak_folder, dStart)
                                ElseIf cLine.Substring(0, 1) = "[" Then
                                    cMode = cLine
                                    Select Case UCase(cLine)
                                        Case "[VERSION]"
                                        Case "[/VERSIONDESC]"
                                            cDesc = cBuilderDesc.ToString
                                        Case "[SQLS]"
                                            Log_Append(sbVersionLog, StrDup(100, "-"))
                                            Log_Append(sbVersionLog, "Running Script(s)")
                                            Log_Append(sbVersionLog, StrDup(100, "-"))
                                            Log_Append(sbVersionLog, "Run Script".PadRight(nColStandard) & "Status")
                                            Try
                                                Dim bTemp As Boolean = False
                                                bTemp = oDb.oVersionRunSql("IF NOT EXISTS (SELECT * FROM MPS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='MSysScripts_Loaded')" & _
                                                        "CREATE TABLE [MPS].[dbo].[MSysScripts_Loaded]([ID] [int] IDENTITY(1,1) NOT NULL,[ScriptFile] [varchar](200) NULL,[RunFrom] [varchar](200) NULL,[DateRun] [datetime] NULL, CONSTRAINT [PK_MSysScripts_Loaded] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]")
                                            Catch ex As Exception
                                            End Try
                                    End Select
                                ElseIf cLine.Substring(0, 1) <> "'" Then
                                    If cMode = "[VERSION]" Then
                                        Try
                                            If CType(cLine, String) = nServerVersion Or oDb.IsNewVersion(cLine, nServerVersion) Then
                                                Log_Append(sbVersionLog, "Object Update Version :".PadRight(nColStandard) & cLine)
                                                cVersion = cLine
                                                cBak_folder = "Load_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & "_Version_" & cLine
                                                cFullBak_folder = CleanPath(GetAppFolder() & "\obj_bak\" & cBak_folder)
                                                bSuccess = True
                                            Else
                                                Log_Append(sbVersionLog, "Status :".PadRight(nColStandard) & "Cannot proceed. Trying to load older version.")
                                                bSuccess = False
                                            End If
                                        Catch ex As Exception
                                            Log_Append(sbVersionLog, "Status :".PadRight(nColStandard) & "Error occured validating object update version.")
                                            bSuccess = False
                                        End Try
                                    ElseIf cMode = "[VERSIONDATE]" Then
                                        cVersionDate = cLine
                                    ElseIf cMode = "[VERSIONDESC]" Then
                                        cBuilderDesc.Append(cLine & vbCrLf)
                                    ElseIf cMode = "[SQLS]" Then
                                        If cLine <> "" Then
                                            RunScript(cLine, cErr)
                                        End If
                                    ElseIf cMode = "[TEMPLATES]" Then

                                    End If
                                End If
                            End If
                        End While
                    Catch ex As Exception
                        cErr = ex.Message
                        bSuccess = False
                    End Try
                End Using

                If Not bSuccess Then Exit Select

                If cVersion <> "" Then
                    'put files in updates folder
                    Try
                        My.Computer.FileSystem.CopyDirectory(cTemp_Folder, CleanPath(cUpdatesFolder) & cVersion, True)
                        bSuccess = True
                        cErr = ""
                    Catch ex As Exception
                        cErr = ex.Message
                        bSuccess = False
                    End Try
                    Log_Append(sbVersionLog, "Put Files in Updates Folder :".PadRight(nColStandard) & GetResult(bSuccess, cErr))

                    If Not bSuccess Then Exit Select

                    'insert to update table
                    cUsername = cUsername & " - ( " & My.Computer.Name & " )"
                    cUsername = cUsername.Replace("'", "''")
                    bSuccess = oDb.UpdateServerVersion(cVersion, cVersionDate, cDesc.Replace("'", "''"), cUsername, cErr)
                    Log_Append(sbVersionLog, "Update Server Version :".PadRight(nColStandard) & GetResult(bSuccess, cErr))

                    'bakup files in local
                    If nFilesUpdated > 0 Then
                        'zip files
                        'zip all files
                        Dim bTmpSuccess As Boolean
                        Dim cZipFiles As String
                        Dim cObjectsBakFile As String = cFullBak_folder & cBak_folder & ".obxbak"
                        cZipFiles = cFullBak_folder & "*.*"
                        bTmpSuccess = ZipFiles(cObjectsBakFile, cZipFiles, cErr)
                        bSuccess = bSuccess And bTmpSuccess

                        'deletes files
                        If bTmpSuccess Then
                            CleanFolder(cFullBak_folder, "*.dll|*.DLL|*.exe|*.EXE|*.txt", IO.SearchOption.TopDirectoryOnly)
                        End If

                        Log_Append(sbVersionLog, "Compressing backup")
                        Log_Append(sbVersionLog, StrDup(100, "-"))
                        Log_Append(sbVersionLog, "File: " & cObjectsBakFile & " ... " & GetResult(bTmpSuccess, cErr))
                        Log_Append(sbVersionLog, StrDup(100, "-"))
                    End If

                    'evaluate process
                    If bSuccess Then
                        If cVersion <> "" Then
                            bSuccess = WriteSettingsIni("VERSION", cVersion, cErr)
                            bSuccess = bSuccess And WriteSettingsIni("VERSIONDATE", cVersionDate, cErr)
                            Log_Append(sbVersionLog, "Update Version INI File :".PadRight(nColStandard) & GetResult(bSuccess, cErr))
                        End If
                    End If
                End If

        End Select

        Select Case UCase(cActionType)
            Case "UPDATE"
                Finish("UPDATE", "Version Update_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & ".txt") ' finish process
            Case "LOAD"
                Log_Append(sbLog, sbVersionLog)
                Finish("LOAD", "Load Version_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & ".txt") 'finish process
        End Select
    End Sub

#Region "Main Methods/Functions"
    Private Sub Init(ByVal cActionType As String, ByRef bSuccess As Boolean)

        Select Case UCase(cActionType)
            Case "UPDATE"
                sbLog.Clear()
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Update Version")
                Log_Append(StrDup(100, "*"))

            Case "LOAD"
                sbLog.Clear()
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Load Version")
                Log_Append(StrDup(100, "*"))

        End Select

        Log_Append()
        Log_Append()
        Log_Append("Update Log")
        Log_Append("Gathering Information from the server..")

        SetStatus("Gathering Information from the server..")
        cUpdatesFolder = oDb.oVersionDLookUp("TextValue", cTable_config, "", "Code='UpdatesFolder'")

        Log_Append("Checking updates folder: ".PadRight(nColStandard) & cUpdatesFolder)
        SetStatus("Checking updates folder: " & cUpdatesFolder)
        If cUpdatesFolder <> "" Then
            bSuccess = IsPathExist(cUpdatesFolder, True)
            If bSuccess Then
                bSuccess = HasFolderPermission(cUpdatesFolder)
                If Not bSuccess Then
                    cErr = "No Read and Write Permission"
                End If
            Else
                cErr = "Path does not exists"
            End If
        Else
            cErr = "Path cannot be empty"
        End If
        Log_Append("Updates folder Status: ".PadRight(nColStandard) & " " & GetResult(bSuccess, cErr))

    End Sub

    Private Sub Finish(ByVal cActionType As String, ByVal cFileName As String)
        SetStatus("Update Done.")
        MarqueeProgressBarControl1.Enabled = False
        EndProcess()

        Select Case UCase(cActionType)
            Case "UPDATE"
                Log_Write(CleanPath(GetAppFolder() & "\logs\update") & cFileName, sbLog)
                ShowLog(sbLog.ToString)
                Me.Close()
            Case "LOAD"
                Log_Write(CleanPath(GetAppFolder() & "\logs\update") & cFileName, sbLog)
                ShowLog(sbLog.ToString)
                Me.Close()
        End Select
    End Sub

    Private Sub EndProcess()
        Log_Append(StrDup(100, "*"))
        Log_Append("END")
        Log_Append(StrDup(100, "*"))
    End Sub

    Public Sub PerformObjectUpdates(ByVal cBak_folder As String, ByVal dStart As DateTime)
        SetStatus("Performing updates..")
        Log_Append(sbVersionLog, StrDup(100, "-"))
        Log_Append(sbVersionLog, "Performing updates ..")
        Log_Append(sbVersionLog, StrDup(100, "-"))
        Log_Append(sbVersionLog, "OBJECT NAME".PadRight(nColStandard) & "STATUS".PadRight(30) & "CREATE BACKUP")

        Dim arrProgramFiles() As String = UCase(oDb.oVersionDLookUp("TextValue", cTable_config, "", "Code='PROGRAMFILES'").ToString).Split(";"c)

        Dim arrUpdateFiles() As String = getFiles(cTemp_Folder, "*.*", IO.SearchOption.TopDirectoryOnly)
        Dim updatefile As String
        For Each updatefile In arrUpdateFiles
            Dim cFile As String = GetFile(updatefile)
            If cFile <> "Update.txt" Then
                If arrProgramFiles.Contains(UCase(cFile)) Then
                    'update program objects
                    SetStatus("Updating Object [ " & cFile & " ] ..")
                    Dim cErr() As String = {"", ""}
                    Dim bCopiedUpdated() As Boolean = UpdateObjectFile(cFile, cBak_folder, cTemp_Folder, dStart, cErr)
                    Log_Append(sbVersionLog, cFile.PadRight(nColStandard) & GetResult(bCopiedUpdated(1), cErr(1)).PadRight(30) & GetResult(bCopiedUpdated(0), cErr(0)))
                Else
                    'other objects
                    SetStatus("Updating Other Object [ " & cFile & " ] ..")
                    Dim cErr() As String = {"", ""}
                    Dim bCopiedUpdated() As Boolean = UpdateOtherObjects(cFile, cBak_folder, cTemp_Folder, dStart, cErr)
                    Log_Append(sbVersionLog, cFile.PadRight(nColStandard) & GetResult(bCopiedUpdated(1), cErr(1)).PadRight(30) & GetResult(bCopiedUpdated(0), cErr(0)))
                End If
            End If
        Next
        Log_Append(sbVersionLog, StrDup(100, "-"))
        Log_Append(sbVersionLog, "Files Updated :".PadRight(nColStandard) & nFilesUpdated.ToString)
        Log_Append(sbVersionLog, "Files Error :".PadRight(nColStandard) & nFilesError.ToString)
        Log_Append(sbVersionLog, "Invalid Files :".PadRight(nColStandard) & nFilesInvalid.ToString)
        Log_Append(sbVersionLog, StrDup(100, "-"))
    End Sub

    Private Sub RunScript(ByVal cLine As String, Optional ByRef cErr As String = "")
        Dim bSuccess As Boolean = False, strsql As String = "", isSQLFile As Boolean = False
        Dim cLineClean As String = Trim(cLine)
        If cLineClean.Substring(cLineClean.Length - 4, 4).ToLower = ".sql" Then 'Run a scripts saved on a .sql file.
            isSQLFile = True
            'check if not on the script logs
            If oDb.oVersionDLookUp("[ScriptFile]", "[MPS].[dbo].[MSysScripts_Loaded]", "", "[ScriptFile]='" & cLineClean & "'") = "" Then

                Dim oSchema As String() = cLineClean.Split("_"c)
                If oSchema(0) <> "" Then
                    Dim oDBScript As New clsDB(ConstructConnString(oSchema(0).ToString))
                    bSuccess = oDBScript.TesTConn(cErr)
                    If bSuccess Then
                        Try
                            Using sqlw As New System.IO.StreamReader(CleanPath(cTemp_Folder) & Trim(cLineClean))
                                strsql = sqlw.ReadToEnd()
                            End Using
                            bSuccess = oDBScript.oVersionRunSql(strsql, cErr, False)
                        Catch ex As Exception
                            bSuccess = False
                            cErr = "Error Reading SQL File."
                        End Try

                        Application.DoEvents()
                        Try
                            Kill(CleanPath(cTemp_Folder) & Trim(cLineClean))
                        Catch ex As Exception
                        End Try
                    Else
                        bSuccess = False
                        cErr = "Invalid SQL File Format." & oSchema(0) & " is not a valid Schema." & "Error Msg:" & cErr
                    End If
                Else
                    'invalid file format {sample Valid: "MPS_view.sql"}
                    bSuccess = False
                    cErr = "Invalid SQL File Format."
                End If

            Else
                'already on script log
                bSuccess = False
                cErr = "Script File already loaded."
            End If

        Else 'Run script written on the Update.txt
            isSQLFile = False
            Application.DoEvents()
            bSuccess = oDb.oVersionRunSql(cLineClean, cErr, False)
        End If


        'construct Log
        Dim cDisplayLine As String = ""
        If cLineClean.Length >= 40 Then
            cDisplayLine = cLineClean.Substring(0, 40) & " .. "
        Else
            cDisplayLine = cLineClean & " .. "
        End If
        Log_Append(sbVersionLog, cDisplayLine.PadRight(nColStandard) & GetResult(bSuccess, cErr))

        'log SQL file
        If isSQLFile Then
            If bSuccess Then
                bSuccess = oDb.oVersionRunSql("INSERT INTO [MPS].[dbo].[MSysScripts_Loaded]([ScriptFile],[RunFrom],[DateRun]) VALUES ('" & cLineClean & "','" & My.Computer.Name.Replace("'", "") & "',GETDATE())")
            End If
        End If

    End Sub

#End Region

#Region "Private Functions"

    Public Function ConstructConnString(Optional ByVal DBName As String = "") As String
        Dim strRet As String = ""
        strRet = "Data Source=" & cServerName & IIf(DBName.Length > 0, ";Database=" & DBName, "") & ";Persist Security Info=True;User ID=" & cServerUser & ";Password=" & cServerPwd & ";"
        Return strRet
    End Function

    Private Sub SetStatus(ByVal cMsg As String)
        txtStatus.Text = "Status: " & cMsg
        txtStatus.Update()
    End Sub

    'this will delete filtered files from given directory
    Private Sub CleanFolder(ByVal cPath As String, ByVal Filter As String, ByVal searchOption As System.IO.SearchOption)
        Dim arrFiles() As String = getFiles(cPath, Filter, searchOption)
        Dim arrFile As String
        For Each arrFile In arrFiles
            Try
                Application.DoEvents()
                My.Computer.FileSystem.DeleteFile(arrFile)
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
    End Sub

    'update object files (DLLs and EXEs)
    Private Function UpdateObjectFile(ByVal cFileName As String, ByVal cFolderName As String, ByVal cTemp_UpdateFolder As String, ByVal dStart As DateTime, ByRef cErr() As String) As Boolean()
        Dim bReturn() As Boolean = {False, False}
        cErr = {"", ""}
        Try
            If cFileName <> "" Then
                'create a backup file
                Dim nFile As String = GetAppFolder() & "\" & cFileName
                If System.IO.File.Exists(nFile) Then
                    Try
                        My.Computer.FileSystem.CopyFile(nFile, GetAppFolder() & "\obj_bak\" & cFolderName & "\" & GetFileWithoutExtension(nFile) & "_" & dStart.ToString("yyyyMMddHHmmss") & GetFileExtension(nFile))
                        bReturn(0) = True
                    Catch ex As Exception
                        cErr(0) = ex.Message
                        bReturn(0) = False
                    End Try
                Else
                    cErr(0) = "Not Exist"
                    bReturn(0) = False
                End If

                'update object file
                Try
                    Application.DoEvents()
                    My.Computer.FileSystem.CopyFile(CleanPath(cTemp_UpdateFolder) & GetFile(nFile), nFile, True)
                    nFilesUpdated += 1
                    bReturn(1) = True
                Catch ex As Exception
                    nFilesError += 1
                    cErr(1) = ex.Message
                    bReturn(1) = True
                End Try

            End If
        Catch ex As Exception
            'cErr = ex.Message
            bReturn(0) = False
            bReturn(1) = False
        End Try
        Return bReturn
    End Function

    'update other objects that follow certain filename format
    Private Function UpdateOtherObjects(ByVal cFileName As String, ByVal cFolderName As String, ByVal cTemp_UpdateFolder As String, ByVal dStart As DateTime, ByRef cErr() As String) As Boolean()
        Dim bReturn() As Boolean = {False, False}
        Dim arrFileDesc() As String = cFileName.Split(";"c)

        Dim cTag As String
        Dim cPasteType As String
        Dim cSubfolder As String
        Dim cFile As String
        If arrFileDesc.Count = 3 Then

            'other objects to be paste in top directory
            cTag = UCase(arrFileDesc(0))
            cPasteType = UCase(arrFileDesc(1))
            cSubfolder = ""
            cFile = arrFileDesc(2)

            If cTag = "MUSTHAVE" Then
                If cPasteType = "TOPDIR" Then
                    Try
                        Dim nUpFile As String = GetAppFolder() & "\" & cFile
                        If System.IO.File.Exists(nUpFile) Then
                            Try
                                Application.DoEvents()
                                My.Computer.FileSystem.CopyFile(nUpFile, GetAppFolder() & "\obj_bak\" & cFolderName & "\" & GetFileWithoutExtension(nUpFile) & "_" & dStart.ToString("yyyyMMddHHmmss") & GetFileExtension(nUpFile))
                                bReturn(0) = True
                            Catch ex As Exception
                                cErr(0) = ex.Message
                                bReturn(0) = False
                            End Try
                        Else
                            cErr(0) = "Not Exist"
                            bReturn(0) = False
                        End If

                        'update
                        Try
                            Application.DoEvents()
                            My.Computer.FileSystem.CopyFile(CleanPath(cTemp_UpdateFolder) & GetFile(cFileName), nUpFile, True)
                            nFilesUpdated += 1
                            bReturn(1) = True
                        Catch ex As Exception
                            nFilesError += 1
                            cErr(1) = ex.Message
                            bReturn(1) = False
                        End Try
                    Catch ex As Exception
                        'cErr = ex.Message
                        bReturn = {False, False}
                    End Try
                End If
            End If

        ElseIf arrFileDesc.Count = 4 Then
            'other objects to be paste in sub folder
            cTag = UCase(arrFileDesc(0))
            cPasteType = UCase(arrFileDesc(1))
            cSubfolder = arrFileDesc(2)
            cSubfolder = cSubfolder.Replace("-", "\")
            cFile = arrFileDesc(3)

            If cTag = "MUSTHAVE" Then
                If cPasteType = "SUBDIR" Then
                    Try
                        Dim nUpFile As String = CleanPath(GetAppFolder()) & cSubfolder & "\" & cFile
                        If System.IO.File.Exists(nUpFile) Then
                            Try
                                Application.DoEvents()
                                My.Computer.FileSystem.CopyFile(nUpFile, GetAppFolder() & "\obj_bak\" & cFolderName & "\" & GetFileWithoutExtension(nUpFile) & "_" & Now.ToString("yyyyMMddHHmmss") & GetFileExtension(nUpFile))
                                bReturn(0) = True
                            Catch ex As Exception
                                cErr(0) = ex.Message
                                bReturn(0) = False
                            End Try
                        Else
                            cErr(0) = "Not Exist"
                            bReturn(0) = False
                        End If
                        'update
                        Try
                            Application.DoEvents()
                            'My.Computer.FileSystem.CopyFile(CleanPath(cTemp_UpdateFolder) & cSubfolder & "\" & GetFile(cFileName), nUpFile, True)
                            My.Computer.FileSystem.CopyFile(CleanPath(cTemp_UpdateFolder) & GetFile(cFileName), nUpFile, True)
                            nFilesUpdated += 1
                            bReturn(1) = True
                        Catch ex As Exception
                            nFilesError += 1
                            cErr(1) = ex.Message
                            bReturn(1) = False
                        End Try

                    Catch ex As Exception
                        cErr = {"", ""}
                        bReturn = {False, False}
                    End Try
                End If
            End If

        Else
            nFilesInvalid += 1
            'no action.. doesnt meet the filename requirements.
            cErr = {"INVALID FILE", "INVALID FILE"}
        End If
        Return bReturn
    End Function

    Public Sub ShowLog(ByVal cLog As String)
        Dim frmLogViewer As New frmLogViewer
        frmLogViewer.txtLogText.Text = cLog
        frmLogViewer.ShowDialog()
    End Sub

    Public Sub Log_Append(ByRef sbLog As StringBuilder, ByVal cLine As String)
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & cLine & vbCrLf)
    End Sub

    Public Sub Log_Append(ByRef sbLog As StringBuilder, ByVal sbLine As StringBuilder)
        If sbLine Is Nothing Then
            sbLine = New StringBuilder("")
        End If
        sbLog.Append(sbLine.ToString)
        sbLog.Append(vbCrLf)
    End Sub

    Public Sub Log_Append(Optional ByVal cLine As String = "")
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & cLine & vbCrLf)
    End Sub

    Public Sub Log_Append(ByVal sbTmpLog As StringBuilder)
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & sbTmpLog.ToString & vbCrLf)
    End Sub

    Private Sub Log_Write(ByVal cPath As String, ByVal cLog As StringBuilder)
        Dim cDir As String
        cDir = GetFileDirectory(cPath)
        Try
            'write log.txt
            If Not IsPathExist(cDir, True) Then
                System.IO.Directory.CreateDirectory(cDir)
            End If
            System.IO.File.WriteAllText(cPath, cLog.ToString)
        Catch ex As Exception
            MsgBox("An error occurred writing log!", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function Log_FileName(ByVal clog_filename As String) As String
        Dim cInstallFolder As String = CleanPath(GetAppFolder)
        Dim cUpdateLogFolder As String = CleanPath(cInstallFolder & "logs\updates")
        Dim cCopyLogFile As String = ""
        Dim cRetVal As String = ""


        cCopyLogFile = Format(Now, "yyyyMMddHHmmss") & "-" & clog_filename & ".txt"

        If Not IsPathExist(cUpdateLogFolder, True) Then
            System.IO.Directory.CreateDirectory(cUpdateLogFolder)
        End If

        cRetVal = cUpdateLogFolder & cCopyLogFile

        Return cRetVal
    End Function

    Private Function GetResult(ByVal bSuccess As Boolean, ByVal cErr As String, Optional ByVal cAltOKText As String = "OK", Optional ByVal cAltFAILEDText As String = "FAILED") As String
        Return IIf(bSuccess, cAltOKText, cAltFAILEDText) & IIf(cErr.Length > 0, " (" & cErr & ")", "")
    End Function


#End Region

#Region "ChilKat"
    'FUNCTION : zip files given by cFileSpec (a semi-colon delimited list of masks)
    '           ex: cFileSpec = "*.csv;*log.txt"
    Private Function ZipFiles(ByVal cZipFile As String, ByVal cFileSpec As String, Optional ByRef cErr As String = "") As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()
        Dim nCtr As Integer

        '  Any string unlocks the component for the 1st 30-days.
        If bSuccess Then
            bSuccess = zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            If Not bSuccess Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            bSuccess = zip.NewZip(cZipFile)
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        '  Append a directory tree.  The call to AppendFiles does
        '  not read the file contents or append them to the zip
        '  object in memory.  It simply appends references
        '  to the files so that when WriteZip or WriteZipAndClose
        '  is called, the referenced files are streamed and compressed
        '  into the .zip output file.

        If bSuccess Then
            Dim recurse As Boolean
            recurse = False
            For nCtr = 1 To CountItemDelimited(cFileSpec, ";")
                bSuccess = bSuccess And zip.AppendFiles(GetItemDelimited(cFileSpec, nCtr, ";"), recurse)
                If (bSuccess <> True) Then
                    cErr = cErr & IIf(cErr.Length > 0, vbCrLf, "") & zip.LastErrorText
                End If
            Next
        End If

        If bSuccess Then
            bSuccess = zip.WriteZipAndClose()
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        Return bSuccess
    End Function

    'FUNCTION : unzip files in [cZipFile] and extract to folder [cExtractTo]
    Private Function ZipExtract(ByVal cZipFile As String, ByVal cExtractTo As String, Optional ByRef cErr As String = "", Optional ByRef nFileCount As Integer = 0) As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()

        '  Any string unlocks the component for the 1st 30-days.
        If bSuccess Then
            bSuccess = zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            bSuccess = zip.OpenZip(cZipFile)
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            nFileCount = zip.Unzip(cExtractTo)
            If nFileCount = -1 Then
                cErr = zip.LastErrorText
            End If
        End If

        Return bSuccess

    End Function
#End Region
End Class