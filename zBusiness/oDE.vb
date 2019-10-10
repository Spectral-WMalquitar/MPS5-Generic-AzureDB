Imports zBusiness
Imports zUtil
Imports zDataLayer
Imports System.Security.Principal
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks
Imports System.ComponentModel
Imports System.Windows.Forms

Public Enum LEDCallingModule
    None = 0
    Init = 1
    Finish = 2
End Enum

Public Class oDE

    '================================================================================================================================================================
    '================================================================================================================================================================
    '
    '   XXX       XXX
    '     XXX   XXX     
    '       XXXXX         
    '        XXX         DATAEXCHANGE CLASS
    '      XXX  XXX
    '    XXX      XXX
    '   XXX        XXX
    '
    '================================================================================================================================================================
    '================================================================================================================================================================


    'to be deleted
    Private cTmpFolder As String
    Private cFullTmpFolder As String
    Private LogFirstLine As String
    'end

    Private oDLApp As zDataLayer.DataLayer
    Private oDLSQLServer As zDataLayer.DataLayer

    'restore variables
    Private cSharedFolder As String
    Private cPhysicalpath As String
    Private nTotUpdated As Long
    Private nTotInserted As Long

    'backup varibales
    Private oProfileAndSchedule As TransferNexus
    Private oProfile As oProfile
    Private oSched As oSched
    Private oTransfer As oTransfer

    'common variables
    Private bShowProgressBar As Boolean = False
    Private dStartTime As Date = Nothing
    Private bStoreInFTP As Boolean = True

    Private sbLog As New StringBuilder("")
    'HashDocuments() file list (HD)
    Private sbHD_FULL As New StringBuilder("") 'full list of warnings from HashDocuments()
    'HashedDocumentsCompare() file list (HDC)
    Private sbHDC_FULL As New StringBuilder("") 'full list of warnings from HashDocuments()
    Private sbLOGTR_FULL As New StringBuilder("") 'full list of warnings from HashDocuments()
    Private sbLOGDEL_FULL As New StringBuilder("") 'full list of warnings from HashDocuments()
    Private cHD_ShortCode As String = "[xxxHDxxx]"
    Private cHDC_ShortCode As String = "[xxxHDCxxx]"
    Private cLOGTR_ShortCode As String = "[xxxLOGTRxxx]"
    Private cLOGDEL_ShortCode As String = "[xxxLOGDELxxx]"
    Private cCallingModuleDesc As String = ""

    Private nMaxWarnings As Integer = 100 ' Maximum number of files to show on HD or HDC section of log
    Private nMaxSubLogLen As Integer = 5000 'Maximum number of characters allowed for sub logs

    Private oActionType As ActionType = ActionType.Backup
    Private cFullDataFileName As String
    Private bCriticalError As Boolean = False

    'log file columns
    Private nColRecCount As Integer = 10
    Private nColObjectName As Integer = 30
    Private nTotalObjects As Long = 0
    Private nTotalObjectsMove As Long = 0
    Private nFilesWarn As Long = 0
    Private nColStandard As Integer = 20
    Private nColDBWidth As Integer = 20
    Private cUploadsFolder As String = ""

    'RESTORE
    '==========
    Public Sub New(zDLApp As zDataLayer.DataLayer, zDLServer As zDataLayer.DataLayer, ByRef cDataFile As String, Optional ByVal bShowProgress As Boolean = False)

        oActionType = ActionType.Restore
        dStartTime = Now
        bShowProgressBar = bShowProgress
        cFullDataFileName = cDataFile

        oDLApp = zDLApp
        oDLSQLServer = zDLServer

        cSharedFolder = GetConfig(oDLApp, "SERVER_SHARED_PATH", "")
        cPhysicalpath = GetConfig(oDLApp, "SERVER_PHYSICAL_PATH", "")

        Log_Append(StrDup(100, "*"))
        UpdateStatus(0, "Creating Log File ", "Log File", bShowProgressBar)

        cTmpFolder = GetAutoCode()

        If Not bCriticalError Then
            Log_Init(IIf(Not oTransfer Is Nothing, sbLog.ToString, ""))
        End If

    End Sub


    'BACKUP
    '==========
    Public Sub New(zDLApp As zDataLayer.DataLayer, zDLServer As zDataLayer.DataLayer, ByRef oProfAndSched As TransferNexus, Optional ByVal bShowProgress As Boolean = False, Optional ByRef cExportFileName As String = "")
        Dim cCreateSQL As String = ""

        oActionType = ActionType.Backup
        dStartTime = Now

        oDLApp = zDLApp
        oDLSQLServer = zDLServer

        cSharedFolder = GetConfig(oDLApp, "SERVER_SHARED_PATH", "")
        cPhysicalpath = GetConfig(oDLApp, "SERVER_PHYSICAL_PATH", "")

        oProfileAndSchedule = oProfAndSched
        oProfile = oProfAndSched.oProf
        oTransfer = oProfAndSched.oTransfer
        oSched = oProfAndSched.oSched
        Try
            bStoreInFTP = oSched.SCHED_IncludePics
        Catch ex As Exception
            bStoreInFTP = False
        End Try

        bShowProgressBar = bShowProgress


        'remove temporary files (CSV & LOG files)
        ClearTempFiles()

        'assemble file name
        cFullDataFileName = CleanPath(oProfile.ExpFolder) & RemoveIllegalCharacters(oProfile.Name) & "-" & Format$(Now(), "yyyyMMdd.") & Format(dStartTime, "HHmmss") & IIf(NullToString(oProfile.Comment) = "", "_Backup database(Service)", "_" & oProfile.Comment.Replace("'", "").Replace("\", "")) & ".ZIP"
        cExportFileName = cFullDataFileName

        Log_Init()
    End Sub

    'EXPORT DATA
    '==========
    Public Sub New(zDLApp As zDataLayer.DataLayer, zDLServer As zDataLayer.DataLayer, ByRef oProfAndSched As TransferNexus, ByVal AppName As String, Optional ByVal bShowProgress As Boolean = False, Optional ByRef cExportFileName As String = "")
        Dim cCreateSQL As String = ""

        oActionType = ActionType.ExportData
        dStartTime = Now

        oDLApp = zDLApp
        oDLSQLServer = zDLServer

        oProfileAndSchedule = oProfAndSched
        oProfile = oProfAndSched.oProf
        oTransfer = oProfAndSched.oTransfer
        oSched = oProfAndSched.oSched
        Try
            bStoreInFTP = oSched.SCHED_IncludePics
        Catch ex As Exception
            bStoreInFTP = False
        End Try

        bShowProgressBar = bShowProgress


        'assemble file name
        cFullDataFileName = CleanPath(oProfile.ExpFolder) & RemoveIllegalCharacters(oProfile.Name) & "-" & Format$(Now(), "yyyyMMdd-") & Format(dStartTime, "HHmmss") & ".ZIP"
        cExportFileName = cFullDataFileName

        Log_Init()
    End Sub

    Public ReadOnly Property HasCriticalErrors() As Boolean
        Get
            Return bCriticalError
        End Get
    End Property

    Public Function CopyFile(ByVal xSourcePath As String) As Boolean
        Dim r As Boolean = False
        Dim zErr As String = ""
        Dim tempFilename As String = ExtractFileNameOnly(xSourcePath)
        'create tempfolder
        cFullTmpFolder = CleanPath(cSharedFolder) & cTmpFolder

        If Not Directory.Exists(cFullTmpFolder) Then
            Directory.CreateDirectory(cFullTmpFolder)
        End If

        Dim zmsg As String = "Copying file [" & tempFilename & "] to " & cFullTmpFolder & " .. "
        Try
            UpdateStatus(0, zmsg, bShowProgressBar)
            File.Copy(xSourcePath, cFullTmpFolder & "\" & tempFilename, True)
            r = True
        Catch ex As Exception
            zErr = ex.Message
            r = False
        End Try
        Log_Append(StrDup(100, "-"))
        Log_Append((zmsg & ":").PadRight(nColObjectName) & " " & GetResult(r, zErr))
        Return r
    End Function

    Public Function RestoreDatabase(ByVal xSourcePath As String) As Boolean
        Dim r As Boolean = False
        Dim zErr As String = ""
        Dim tempFilename As String = ExtractFileNameOnly(xSourcePath)
        Dim zcurrentFile As String = CleanPath(cFullTmpFolder) & tempFilename
        Dim zmsg As String = "Checking file if exists [" & zcurrentFile & "]"
        Dim zSchema As String = ""
        Try
            UpdateStatus(0, zmsg, bShowProgressBar)
            r = FileExists(zcurrentFile)
            Log_Append((zmsg & ":").PadRight(nColObjectName) & " " & GetResult(r, zErr))
            Log_Append(StrDup(100, "-"))

            If r Then
                'check
                UpdateStatus(0, "Checking File for restore", bShowProgressBar)
                zSchema = GetSchemaByFilename(tempFilename)
                If zSchema = "" Then
                    Log_Append(("STATUS:").PadRight(nColStandard) & " " & "Invalid schema. Please check the file.")
                    Log_Append(("RESTORE RESULT:").PadRight(nColStandard) & " " & "FAILED")
                    r = False
                Else
                    If oDLSQLServer.DLookUp("SchemaName", "[STIAPPVERSIONS].[dbo].[tblSTIService_Schema]", "SchemaName='" & zSchema & "' AND AllowRestore=1").ToString() <> "" Then
                        Log_Append("SCHEMA TO RESTORE: ".PadRight(nColStandard) & zSchema)
                        UpdateStatus(0, "Restoring Database:" & " [ " & tempFilename & " ] ..", "Restoring", bShowProgressBar)
                        r = oDLSQLServer.ExecuteNonQuery("RESTORE DATABASE " & zSchema & " FROM DISK='" & CleanPath(cFullTmpFolder) & "\" & tempFilename & "'", zErr)
                        Log_Append(("RESTORE RESULT:").PadRight(nColStandard) & GetResult(r, zErr))
                    Else
                        Log_Append(("STATUS:").PadRight(nColStandard) & "Cannot proceed. Please check the file.")
                        Log_Append(("RESTORE RESULT:").PadRight(nColStandard) & "FAILED")
                        r = False
                    End If
                End If
            End If
        Catch ex As Exception
            r = False
        End Try
        Return r
    End Function

    Public Function BackupDatabase(ByVal Schema As String) As Boolean
        Dim r As Boolean = False
        Dim zObjectFile As String = ""
        Dim concatFilename As String = "-" & Format(Now(), "yyyyMMdd.") & Format(dStartTime, "HHmmss") & IIf(NullToString(oProfile.Comment) = "", "_Backup database(Service)", "_" & oProfile.Comment.Replace("'", "").Replace("\", "")) & ".bak"
        zObjectFile = Schema & concatFilename
        Dim zErr As String = ""
        Try
            UpdateStatus(0, "Backup Database:" & " [ " & Schema & " ] ..", "Backup", bShowProgressBar)
            r = oDLSQLServer.ExecuteNonQuery("BACKUP DATABASE " & Schema & " TO DISK='" & CleanPath(cSharedFolder) & zObjectFile & "'", zErr)
            Log_Append(("BACKUP " & Schema & " :").PadRight(nColStandard) & GetResult(r, zErr))

            If r Then
                nTotalObjects = nTotalObjects + 1
                'copying files
                Try
                    File.Move(CleanPath(cSharedFolder) & zObjectFile, CleanPath(oProfile.ExpFolder) & zObjectFile)
                    nTotalObjectsMove = nTotalObjectsMove + 1
                    r = True
                Catch ex As Exception
                    r = False
                    nFilesWarn = nFilesWarn + 1
                End Try
            End If
        Catch ex As Exception
            r = False
        End Try
        Return r
    End Function

    Public Function GetTotalObjects() As Integer
        Return nTotalObjects
    End Function

    Public Function GetTotalObjectsMove() As Integer
        Return nTotalObjectsMove
    End Function

    Private Function GetSchemaByFilename(ByVal xFilename As String) As String
        Dim r As String = ""
        Try
            Dim ztempArr() As String = xFilename.Split("-"c)
            r = ztempArr(0)
        Catch ex As Exception
            r = ""
        End Try
        Return r
    End Function

    'RETURNS: Temp folder where the files have been extracted
    Public Function ExtractDataFile(Optional ByRef cRetTmpFolder As String = "", Optional ByRef cRetLogFirstLine As String = "") As Boolean
        Dim cErr As String = ""
        Dim nFileCount As Integer = 0
        Dim bSuccess As Boolean = True

        'extract files into temp folder
        If oActionType = ActionType.Restore Then
            UpdateStatus(0, "Extracting Data File to " & cTmpFolder, "Extracting", bShowProgressBar)
            bSuccess = bSuccess And ZipExtract(cFullDataFileName, cTmpFolder, cErr, nFileCount)
            Log_Append()
            Log_Append()
            Log_Append("Extracting to " & cTmpFolder)
            Log_Append(StrDup(100, "-"))
            Log_Append("File: " & cFullDataFileName & " ... " & GetResult(bSuccess, cErr))

            'get log file first line w/c contains info about the export file
            LogFirstLine = ReadLogFirstLine(CleanPath(cTmpFolder) & "log.txt")
            Log_Append()
            Log_Append("Log Info: ".PadRight(nColStandard) & LogFirstLine)


            'return values
            cRetTmpFolder = cTmpFolder
            cRetLogFirstLine = Trim(GetItemDelimited(LogFirstLine, 2, "|")) 'remove tme stamp
        End If

        Return bSuccess
    End Function

    Private Function ReadLogFirstLine(ByVal cLogFile As String) As String
        Dim sFileReader As System.IO.StreamReader
        Dim sInputLine As String = ""

        If oActionType = ActionType.Restore Then
            If FileExists(cLogFile) Then
                sFileReader = System.IO.File.OpenText(cLogFile)
                sInputLine = sFileReader.ReadLine()
                'Do Until sInputLine Is Nothing
                '    sInputLine = sFileReader.ReadLine()
                'Loop
                sFileReader.Close()
            End If
        End If

        Return sInputLine
    End Function

    Private Sub Log_Init(Optional ByVal cInitLog As String = "")
        Dim cLastUpdate As String = ""
        sbLog.Clear()
        sbLog.Append(cInitLog)

        'Assemble Log Description
        Select Case oProfileAndSchedule.oCallingModule
            Case CallingModule.BRS_INTERFACE
                cCallingModuleDesc = "(" & oApp.UserName & ") MANUAL Run "
            Case CallingModule.BRS_SERVICE
                cCallingModuleDesc = "AUTO "
        End Select
        Select Case oActionType
            Case ActionType.Backup
                cCallingModuleDesc = cCallingModuleDesc & "Backup"
            Case ActionType.Restore
                cCallingModuleDesc = cCallingModuleDesc & "Restore"
            Case ActionType.ExportData
                cCallingModuleDesc = cCallingModuleDesc & "Export WRH Data"
        End Select
        If Not oProfileAndSchedule.oSched Is Nothing Then
            cCallingModuleDesc = cCallingModuleDesc & " SCHEDULE [" & oProfileAndSchedule.oSched.SCHED_Name & "]"
        End If

        'Initialize Log
        Select Case oActionType
            Case ActionType.Backup
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Backup Database")
                Log_Append(StrDup(100, "*"))
                Log_Append()
                Log_Append()
                Log_Append(oApp.GetAppName & " Export Log")
                Log_Append(StrDup(100, "="))
                Log_Append("MPS Service Version: ".PadRight(nColStandard) & Application.ProductVersion)
                Log_Append("Log Description: ".PadRight(nColStandard) & cCallingModuleDesc)
                Try
                    Log_Append("Create Backup in FTP: ".PadRight(nColStandard) & IIf(oSched.SCHED_IncludePics, "Yes", "No"))
                Catch ex As Exception
                    Log_Append("Create Backup in FTP: ".PadRight(nColStandard) & "No")
                End Try
                Log_Append("Backup File: ".PadRight(nColStandard) & cFullDataFileName)
                Log_Append("Backup Date: ".PadRight(nColStandard) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))
                Log_Append("Server Instance: ".PadRight(nColStandard) & GetConfig(oDLApp, "SERVER_INSTANCE", ""))
                Log_Append("Authentication: ".PadRight(nColStandard) & GetAuthDesc(GetConfig(oDLApp, "SERVER_AUTH", "")))
                Log_Append("User Name: ".PadRight(nColStandard) & GetConfig(oDLApp, "SERVER_USER", ""))
                Log_Append()
                Log_Append()
                Log_Append(StrDup(100, "="))
                Log_Append()
                Log_Append()
                Log_Append("Profile Info")
                Log_Append(StrDup(100, "-"))
                Log_Append("Profile Name: ".PadRight(nColStandard) & oProfile.Name)
                Log_Append("Backup Folder: ".PadRight(nColStandard) & oProfile.ExpFolder)
                Log_Append("Comments: ".PadRight(nColStandard) & oProfile.Comment)
                Log_Append()
                Log_Append()

            Case ActionType.Restore
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Restoring Database")
                Log_Append(StrDup(100, "*"))
                Log_Append(oApp.GetAppName & " Restore Log")
                Log_Append(StrDup(100, "="))
                Log_Append("MPS Service Version: ".PadRight(nColStandard) & Application.ProductVersion)
                Log_Append("Log Description: ".PadRight(nColStandard) & cCallingModuleDesc)
                Log_Append()
                Log_Append("Server Instance: ".PadRight(nColStandard) & GetConfig(oDLApp, "SERVER_INSTANCE", ""))
                Log_Append("Authentication: ".PadRight(nColStandard) & GetAuthDesc(GetConfig(oDLApp, "SERVER_AUTH", "")))
                Log_Append("User Name: ".PadRight(nColStandard) & GetConfig(oDLApp, "SERVER_USER", ""))
                Log_Append("Restore Date: ".PadRight(nColStandard) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))

            Case ActionType.ExportData
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Export Data")
                Log_Append(StrDup(100, "*"))
                Log_Append(oApp.GetAppName & " Export Data Log")
                Log_Append(StrDup(100, "="))
                Log_Append("MPS Service Version: ".PadRight(nColStandard) & Application.ProductVersion)
                Log_Append("Log Description: ".PadRight(nColStandard) & cCallingModuleDesc)
                Log_Append()
                Log_Append("Server Instance: ".PadRight(nColStandard) & GetConfig(oDLApp, "SERVER_INSTANCE", ""))
                Log_Append("Authentication: ".PadRight(nColStandard) & GetAuthDesc(GetConfig(oDLApp, "SERVER_AUTH", "")))
                Log_Append("User Name: ".PadRight(nColStandard) & GetConfig(oDLApp, "SERVER_USER", ""))
                Log_Append("Export Data Date: ".PadRight(nColStandard) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))

        End Select
    End Sub

    Public Function GetDataFileName() As String
        Return cFullDataFileName
    End Function

    'function:
    'trims <sbLog> according to nMaxWarningsLength
    Private Function TrimSubLog(ByVal sbSubLog As StringBuilder) As String
        Dim cRetVal As String = ""
        Dim bTrimmed As Boolean = False

        If sbSubLog.Length > 0 Then
            If sbSubLog.ToString.Length > nMaxSubLogLen Then
                cRetVal = Left(sbSubLog.ToString, nMaxSubLogLen)
                bTrimmed = True
            Else
                cRetVal = sbSubLog.ToString
            End If
            cRetVal = Left(cRetVal, cRetVal.LastIndexOf(vbCrLf)) 'get whole lines only
            If bTrimmed Then
                cRetVal = cRetVal & vbCrLf & vbCrLf & Format(Now, "hh:mm:ss tt | ") & "*** This list has been truncated because it contains too many characters (" & sbSubLog.Length & "). View the full list in " & Log_SiteLogs_FileName() & " ***" & vbCrLf & vbCrLf
            End If
        End If
        Return cRetVal
    End Function

    Public Function GetLog(Optional ByVal bFullLog As Boolean = True) As StringBuilder
        Dim sbTemp As New StringBuilder(sbLog.ToString)
        If bFullLog Then
            sbTemp.Replace(cHD_ShortCode, sbHD_FULL.ToString)
            sbTemp.Replace(cHDC_ShortCode, sbHDC_FULL.ToString)
            sbTemp.Replace(cLOGTR_ShortCode, sbLOGTR_FULL.ToString)
            sbTemp.Replace(cLOGDEL_ShortCode, sbLOGDEL_FULL.ToString)
        Else
            sbTemp.Replace(cHD_ShortCode, TrimSubLog(sbHD_FULL))
            sbTemp.Replace(cHDC_ShortCode, TrimSubLog(sbHDC_FULL))
            sbTemp.Replace(cLOGTR_ShortCode, TrimSubLog(sbLOGTR_FULL))
            sbTemp.Replace(cLOGDEL_ShortCode, TrimSubLog(sbLOGDEL_FULL))
        End If
        Return sbTemp
    End Function

    Public Sub Log_Append(Optional ByVal cLine As String = "")
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & cLine & vbCrLf)
    End Sub

    Public Sub Log_Append(ByVal sbTmpLog As StringBuilder)
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & sbTmpLog.ToString & vbCrLf)
    End Sub


    Private Function Log_SiteLogs_FileName() As String
        Dim cInstallFolder As String = CleanPath(My.Application.Info.DirectoryPath)
        Dim cBackupLogFolder As String = CleanPath(cInstallFolder & "logs\backup")
        Dim cImportLogFolder As String = CleanPath(cInstallFolder & "logs\restore")
        Dim cExportLogFolder As String = CleanPath(cInstallFolder & "logs\exports")
        Dim cCopyLogFile As String = ""
        Dim cRetVal As String = ""

        Select Case oActionType
            Case ActionType.Backup
                cCopyLogFile = Format(Now, "yyyyMMddHHmmss") & "-" & ExtractFileNameOnly(GetDataFileName()) & ".txt"
            Case ActionType.Restore
                cCopyLogFile = Format(Now, "yyyyMMddHHmmss") & "-" & ExtractFileNameOnly(GetDataFileName()) & ".txt"
            Case ActionType.Restore
                cCopyLogFile = Format(Now, "yyyyMMddHHmmss") & "-" & ExtractFileNameOnly(GetDataFileName()) & ".txt"
        End Select

        If Not System.IO.Directory.Exists(cBackupLogFolder) Then
            System.IO.Directory.CreateDirectory(cBackupLogFolder)
        End If
        If Not System.IO.Directory.Exists(cImportLogFolder) Then
            System.IO.Directory.CreateDirectory(cImportLogFolder)
        End If

        If Not System.IO.Directory.Exists(cExportLogFolder) Then
            System.IO.Directory.CreateDirectory(cExportLogFolder)
        End If

        Select Case oActionType
            Case ActionType.Backup
                cRetVal = cBackupLogFolder & cCopyLogFile
            Case ActionType.Restore
                cRetVal = cImportLogFolder & cCopyLogFile
            Case ActionType.ExportData
                cRetVal = cExportLogFolder & cCopyLogFile
        End Select

        Return cRetVal
    End Function

    Private Sub Log_Write()
        Dim oTableList As TableList = Nothing
        Dim cOrigLogFile As String = ""

        Select Case oActionType
            Case ActionType.Backup
                cOrigLogFile = CleanPath(oProfile.ExpFolder) & "log.txt"
            Case ActionType.Restore
                cOrigLogFile = Log_SiteLogs_FileName()
            Case ActionType.ExportData
                cOrigLogFile = CleanPath(oProfile.ExpFolder) & "exportlog.txt"
        End Select

        'write log.txt
        System.IO.File.WriteAllText(cOrigLogFile, GetLog(True).ToString)

        Select Case oActionType
            Case ActionType.Backup
                'copy log file to export/import log directory
                'check if folder exists, if it doesn't then create it
                'CAN CREATE MULTIPLE NESTED FOLDERS!!! e.g. if neither folder "a" nor "b" exists in "c:\a\b", then
                'this will create both nested folders.
                System.IO.File.Copy(cOrigLogFile, Log_SiteLogs_FileName(), True)
            Case ActionType.Restore
                'do nothing. the log file was written DIRECTLY to the logs folder, so there is nothing to move or copy
        End Select

    End Sub

    'RETURNS : hh:mm:ss from input string <nSeconds>
    Private Function TimeElapsed(ByVal nSecond As Double) As String
        Dim tSpan As TimeSpan = TimeSpan.FromSeconds(nSecond)
        Dim cRetVal As String = ""

        If tSpan.Hours > 0 Then
            cRetVal = cRetVal & IIf(cRetVal.Length > 0, " ", "") & tSpan.Hours & " hour" & IIf(tSpan.Hours > 1, "s", "")
        End If
        If tSpan.Minutes > 0 Then
            cRetVal = cRetVal & IIf(cRetVal.Length > 0, " ", "") & tSpan.Minutes & " minute" & IIf(tSpan.Minutes > 1, "s", "")
        End If
        If tSpan.Seconds > 0 Then
            cRetVal = cRetVal & IIf(cRetVal.Length > 0, " ", "") & tSpan.Seconds & " second" & IIf(tSpan.Seconds > 1, "s", "")
        End If
        If cRetVal = "" Then
            cRetVal = "0 second"
        End If

        Return cRetVal
    End Function

    'FUNCTION : unzip files in [cZipFile] and extract to folder [cExtractTo]
    Private Function ZipExtract(ByVal cZipFile As String, ByVal cExtractTo As String, Optional ByRef cErr As String = "", Optional ByRef nFileCount As Integer = 0) As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()

        If oActionType = ActionType.Restore Then
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
        End If

        Return bSuccess

    End Function


    'FUNCTION : zip files given by cFileSpec (a semi-colon delimited list of masks)
    '           ex: cFileSpec = "*.csv;*log.txt"
    Private Function ZipFiles(ByVal cZipFile As String, ByVal cFileSpec As String, Optional ByRef cErr As String = "") As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()
        Dim nCtr As Integer

        If oActionType = ActionType.Backup Then
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
        End If

        Return bSuccess
    End Function

    'abort import/export and clean up database
    Private Sub Abort()
        Select Case oActionType
            Case ActionType.Backup
                If Not oTransfer Is Nothing Then
                    'delete transfer record
                    oTransfer.Delete()
                End If

            Case ActionType.Restore
                If Not oTransfer Is Nothing Then
                    'delete transfer record
                    oTransfer.Delete()
                End If
        End Select
    End Sub

    'RETURNS: TRUE if there were no problems finishing up, else FALSE
    'FUNCTION: For exports, calling this zips the file and releases variables
    '          
    Public Function Finish(Optional ByVal cErr As String = "", Optional ByVal HasError As Boolean = False) As Boolean
        Dim oTable As TableList = Nothing
        Dim nCtr As Integer = 0
        Dim dEndTime As Date
        Dim bSuccess As Boolean = True
        Dim bTmpSuccess As Boolean = True
        Dim cZipFiles As String = ""
        Dim cLogErr As String = ""
        Dim cAlertEmail As String = GetEmailReceivers(oDLSQLServer, True)
        Dim cSuccessEmail As String = GetEmailReceivers(oDLSQLServer, False)
        Dim cINET_Code As String = NullToString(GetConfig(oDLSQLServer, "BRS_ALERT_SMTP"))

        If Not bCriticalError Then
            'record end time. DO NOT PERFORM ANY LONG RUNNING OPERATION AFTER THIS LINE!!!
            dEndTime = Now

            Select Case oActionType
                Case ActionType.Backup
                    'place total records exported
                    Log_Append(StrDup(100, "="))
                    Log_Append("Total Objects Created: ".PadRight(25) & nTotalObjects)
                    Log_Append("Total Objects Moved for Compressed: ".PadRight(25) & nTotalObjectsMove)
                    Log_Append("Total Objects Not Moved for Compressed: ".PadRight(25) & nFilesWarn)

                    If nFilesWarn > 0 Then
                        Log_Append("Please check permission of the Shared folder.")
                    End If

                    If bStoreInFTP Then
                        UpdateStatus(0, "Processing files to upload...", "Processing", bShowProgressBar)
                    End If

                    Log_Append("Save to disk")
                    Log_Append(StrDup(100, "-"))


                    'write log file
                    dEndTime = Now
                    Log_Append()
                    Log_Append("Total Time Taken")
                    Log_Append(StrDup(100, "-"))
                    Log_Append("Start Time: ".PadRight(25) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))
                    Log_Append("End Time: ".PadRight(25) & Format(dEndTime, "yyyy-MM-dd hh:mm:ss"))
                    Log_Append("Elapsed time: ".PadRight(25) & TimeElapsed(DateDiff(DateInterval.Second, dStartTime, dEndTime)))
                    Log_Append()
                    Log_Append("*** END ***")
                    Log_Write()

                    'zip all files
                    cZipFiles = CleanPath(oProfile.ExpFolder) & "*.bak"
                    cZipFiles = cZipFiles & ";" & CleanPath(oProfile.ExpFolder) & "log.txt"
                    bTmpSuccess = ZipFiles(cFullDataFileName, cZipFiles, cErr)
                    bSuccess = bSuccess And bTmpSuccess

                    Log_Append()
                    Log_Append("Compressing")
                    Log_Append(StrDup(100, "-"))
                    Log_Append("File: " & cFullDataFileName & " ... " & GetResult(bTmpSuccess, cErr))
                    Log_Append(StrDup(100, "-"))


                    If Not oTransfer Is Nothing AndAlso bSuccess AndAlso bStoreInFTP Then
                        If Not HasError Then
                            'presence of a transfer object means that this is an automated task
                            'so the items that needs to be transferred needs to be reflected in the transfer record
                            'NOTE: the transfer is NOT VALID UNITIL [NEXTRUN] gets a value that is <=NOW()
                            oTransfer.NextRun = Nothing   'to be filled up later 
                            oTransfer.DataFile = GetDataFileName()
                            oTransfer.MainLog = GetLog(False)
                            oTransfer.TransferStatus = 0 'for processing (ie. datafile yet to be sent via FTP)
                            oTransfer.LastStatus = "Queued"
                            oTransfer.SendOrReceive = ActionType.Backup
                            oTransfer.Save()

                            Log_Append()
                            Log_Append()
                            Log_Append("Upload File via FTP")
                            Log_Append(StrDup(100, "-"))
                            'start transfer
                            oTransfer.Transfer_Async()

                            'wait for the upload of DATA FILE to complete (wait for ONLY the data file --not including pics/docs)
                            Do While oTransfer.TransferStatus = 0 AndAlso Transfer_IsRunning(oTransfer)
                                Application.DoEvents()
                            Loop

                            If oTransfer.TransferStatus = 0 Then
                                'export file sending failed.
                                bSuccess = False
                                'cErr = "Export file upload failed. Will retry in " & oTransfer.RetrySeconds & " seconds."
                                cErr = "Backup file failed to upload. Will try again in next schedule run."
                            End If

                            Log_Append("File Upload: " & ExtractFileNameOnly(cFullDataFileName) & " --> FTP Folder [" & oTransfer.RemoteFolder & "] ... " & GetResult(bSuccess, cErr))
                            Log_Append()
                            Log_Append(StrDup(100, "-"))
                            oTransfer.Delete()
                        End If
                    End If
                Case ActionType.Restore, ActionType.ExportData

                    dEndTime = Now
                    Log_Append()
                    Log_Append("Total Time Taken")
                    Log_Append(StrDup(100, "-"))
                    Log_Append("Start Time: ".PadRight(25) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))
                    Log_Append("End Time: ".PadRight(25) & Format(dEndTime, "yyyy-MM-dd hh:mm:ss"))
                    Log_Append("Elapsed time: ".PadRight(25) & TimeElapsed(DateDiff(DateInterval.Second, dStartTime, dEndTime)))

                    Log_Append()
                    Log_Append("*** END ***")
                    Log_Write()

            End Select
        Else
            Abort()
        End If


        bSuccess = bSuccess And Not HasError

        'log the event
        '******************************************************************************************************************
        '******************************************************************************************************************
        'check reason for critical error

        Dim nSendImportWarning As Boolean = False
        Dim cEmailErrLog As String = ""

        If bCriticalError Then
            Select Case oActionType
                Case ActionType.Backup
                Case ActionType.Restore
                    If oProfileAndSchedule.GetFileErr = GetFileErr.Missing_File Then
                        'MISSING IMPORT FILE FROM FTP SERVER
                        'do not treat this as critical error
                        'IF exporting site failed, they will get a CRITICAL error warning from THEIR MPSDE
                        bCriticalError = False
                        nSendImportWarning = True
                    End If
            End Select
        End If

        Dim oEventLog As New oEventLog

        If bSuccess And (Not bCriticalError) Then
            'no errors
            oEventLog.bError = False 'no error
        Else
            'problems encountered
            oEventLog.bError = True 'failed
        End If

        oEventLog.LogDesc = cCallingModuleDesc
        oEventLog.Logentry = GetLog(False) 'get partial log only
        oEventLog.Save(cLogErr)

        'RSA2014/10/20 - Feature requested by Spectral to have "special" email for non critical errors
        'When "MPSDE_STIALERT" is present in tblConfig AND an SMTP profile has been set up in DE, then sysMpsUserPassword() 
        'is used to DECRYPT the email address and send ANY AND ALL ERRORS to the decrypted email address
        '
        Dim cCompanyName As String = GetConfig(oDLSQLServer, "NAME", "")

        If oEventLog.bError Then
            'send email alert
            If cINET_Code <> "" And cAlertEmail <> "" Then
                UpdateStatus(0, "Send error Notification...", "Send Email", bShowProgressBar)
                Dim oSMTP As New oEMAIL
                Dim cLog As String = ""
                Dim bSendMailSuccess As Boolean = True
                oSMTP.cMsg_To = cAlertEmail
                oSMTP.cmsg_To_FriendlyName = ""

                'assemble subject
                oSMTP.cMsg_Subj = oApp.GetAppName & " ERROR"
                Select Case oActionType
                    Case ActionType.Backup
                        oSMTP.cMsg_Subj = oSMTP.cMsg_Subj & " Backup Notification " & IIf(cLogErr = "", "", "+ Log Failed To Save") & " (" & cCompanyName & ")"
                    Case ActionType.Restore
                        oSMTP.cMsg_Subj = oSMTP.cMsg_Subj & " Restore Notification" & IIf(cLogErr = "", "", "+ Log Failed To Save") & " (" & cCompanyName & ")"
                End Select

                oSMTP.cMsg_Body = "This error notification is sent from " & oApp.GetAppName & vbCrLf

                If cLogErr <> "" Then
                    oSMTP.cMsg_Body = oSMTP.cMsg_Body & "Log file failed to save:" & vbCrLf & "=============================" & vbCrLf
                    oSMTP.cMsg_Body = oSMTP.cMsg_Body & cLogErr & vbCrLf & vbCrLf
                End If

                oSMTP.cMsg_Body = oSMTP.cMsg_Body & "Log Description: " & cCallingModuleDesc & vbCrLf & vbCrLf
                oSMTP.cMsg_Body = oSMTP.cMsg_Body & "Log file contents:" & vbCrLf & "=============================" & vbCrLf
                oSMTP.cMsg_Body = oSMTP.cMsg_Body & GetLog(False).ToString

                oSMTP.INET_Code = cINET_Code
                bSendMailSuccess = oSMTP.SendMail(cEmailErrLog)
                If oApp.DebugHas("WORKLOAD") Then
                    ServiceDebug("Send Email..." & GetResult(bSendMailSuccess, cEmailErrLog), "workload", True)
                End If
            End If

        Else

            'send success email alert
            If cINET_Code <> "" And cSuccessEmail <> "" Then
                UpdateStatus(0, "Send success Notification...", "Send Email", bShowProgressBar)
                Dim oSMTP As New oEMAIL
                Dim cLog As String = ""
                Dim bSendMailSuccess As Boolean = True
                oSMTP.cMsg_To = cSuccessEmail
                oSMTP.cmsg_To_FriendlyName = ""

                'assemble subject
                oSMTP.cMsg_Subj = oApp.GetAppName & " SUCCESSFUL"
                Select Case oActionType
                    Case ActionType.Backup
                        oSMTP.cMsg_Subj = oSMTP.cMsg_Subj & " Backup Notification (" & cCompanyName & ")"
                    Case ActionType.Restore
                        oSMTP.cMsg_Subj = oSMTP.cMsg_Subj & " Restore Notification (" & cCompanyName & ")"
                End Select

                oSMTP.cMsg_Body = "This success notification is sent from " & oApp.GetAppName & vbCrLf

                If cLogErr <> "" Then
                    oSMTP.cMsg_Body = oSMTP.cMsg_Body & "Log file failed to save:" & vbCrLf & "=============================" & vbCrLf
                    oSMTP.cMsg_Body = oSMTP.cMsg_Body & cLogErr & vbCrLf & vbCrLf
                End If

                oSMTP.cMsg_Body = oSMTP.cMsg_Body & "Log Description: " & cCallingModuleDesc & vbCrLf & vbCrLf
                oSMTP.cMsg_Body = oSMTP.cMsg_Body & "Log file contents:" & vbCrLf & "=============================" & vbCrLf
                oSMTP.cMsg_Body = oSMTP.cMsg_Body & GetLog(False).ToString

                oSMTP.INET_Code = cINET_Code
                bSendMailSuccess = oSMTP.SendMail(cEmailErrLog)
                If oApp.DebugHas("WORKLOAD") Then
                    ServiceDebug("Send Email..." & GetResult(bSendMailSuccess, cEmailErrLog), "workload", True)
                End If
            End If
        End If

        '******************************************************************************************************************
        '******************************************************************************************************************

        'remove temporary folder
        'remove temporary files
        ClearTempFiles()

        Return bSuccess
    End Function


    Public Sub ClearTempFiles()
        Select Case oActionType
            Case ActionType.Backup
                Try
                    'CSV files
                    For Each FileFound As String In Directory.GetFiles(CleanPath(oProfile.ExpFolder), "*.bak")
                        File.Delete(FileFound)
                    Next
                    'LOG files
                    For Each FileFound As String In Directory.GetFiles(CleanPath(oProfile.ExpFolder), "log.txt")
                        File.Delete(FileFound)
                    Next
                Catch ex As Exception
                End Try

            Case ActionType.Restore
                Try
                    For Each FileFound As String In Directory.GetFiles(cFullTmpFolder, "*.*")
                        File.Delete(FileFound)
                    Next
                    System.IO.Directory.Delete(cFullTmpFolder)
                Catch ex As Exception
                End Try

        End Select
    End Sub


    'FUNCTION : converts <dDate> to a MYSQL compatible date
    '           returns NULL if dDate is not a date
    Private Function MySQL_Date(ByVal dDate As Date) As String
        Dim cRetVal As String = ""
        If IsDate(dDate) Then
            cRetVal = "STR_TO_DATE('" & dDate.ToString("yyyy-MM-dd HH:mm:ss") & "', '%Y-%m-%d %H:%i:%s')"
        Else
            cRetVal = "null"
        End If
        Return cRetVal
    End Function

    Private Function GetResult(ByVal bSuccess As Boolean, ByVal cErr As String, Optional ByVal cAltOKText As String = "OK", Optional ByVal cAltFAILEDText As String = "FAILED") As String
        Return IIf(bSuccess, cAltOKText, cAltFAILEDText) & IIf(cErr.Length > 0, " (" & cErr & ")", "")
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
