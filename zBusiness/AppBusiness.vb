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
Imports System.Collections

Public Enum ServiceCallingModule
    None = 0
    Service = 1
    SimulatedService = 2
End Enum

Public Module BusinessLayer

    Public oDLTest As New zDataLayer.DataLayer

    'SQL SERVER connections
    Public oConnSQLServer As connDetails
    Public oDLSQLSERVER As New zDataLayer.DataLayer

    'Backup Restore application object
    Public oApp As New App
    Public frmStatus As frmProcessing
    Private cServiceWorkLoad As String
    Private bServiceIsBusy As Boolean = False
    Private cLiveStatErr As String = ""
    Private cLastConnectErr As String = ""


#Region "Security"
    'FUNCTION: Determines if the application is being RUN AS ADMINISTRATOR
    Public Function isElevated() As Boolean
        Dim bRetVal As Boolean = False
        Try
            Dim identity As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim principal As WindowsPrincipal = New WindowsPrincipal(identity)
            'check for ADMIN PRIVILEDGE
            bRetVal = principal.IsInRole(WindowsBuiltInRole.Administrator)
        Catch ex As Exception
        End Try
        Return bRetVal
    End Function
#End Region

#Region "Config"
    'Returns a unique ID for storing records
    Public Function GenerateID(oDL As zDataLayer.DataLayer, ByVal cTBL As String, cFieldName As String) As String
        Dim cUID As String = ""
        Dim cLOCID As String = GetConfig(oDL, "LOCATION_ID")
        cUID = cLOCID & GetAutoCode(10)
        Do While NullToString(oDL.DLookUp(cFieldName, cTBL, cFieldName & "='" & cUID & "'")) <> ""
            cUID = cLOCID & GetAutoCode(10)
        Loop
        Return cUID
    End Function

    'gets config value
    Public Function GetConfig(ByVal oDL As zDataLayer.DataLayer, ByVal Code As String, Optional ByVal cDefaultIfEmpty As String = "") As String
        Dim cRetVal As String

        cRetVal = NullToString(oDL.DLookUp("Value", "tblSTIService_config", "code='" & Code & "'"))
        If cDefaultIfEmpty.Length > 0 AndAlso cRetVal.Length = 0 Then
            If SetConfig(oDL, Code, cDefaultIfEmpty) Then
                cRetVal = cDefaultIfEmpty
            End If
        End If

        Return cRetVal
    End Function

    'sets the config value
    Public Function SetConfig(ByVal oDL As zDataLayer.DataLayer, ByVal Code As String, ByVal Value As String, Optional ByRef cErr As String = "", Optional ByRef nAffected As Long = 0) As Boolean
        Dim cSQL As String = ""
        Dim bExist As Boolean = False
        Dim bRetVal As Boolean = False

        If oDL.DLookUp("code", "tblSTIService_config", "code='" & Code & "'") = Code Then
            bExist = True
        End If

        If bExist Then
            cSQL = "UPDATE tblSTIService_config SET Value='" & Value & "' where code='" & Code & "'"
        Else
            cSQL = "INSERT INTO tblSTIService_config (code,Value) VALUES ('" & Code & "','" & Value & "');"
        End If

        bRetVal = oDL.ExecuteNonQuery(cSQL, cErr, nAffected)

        Return bRetVal
    End Function
#End Region

#Region "MPS Service"
    Public cLogName As String = "" '
    Public cLogSource As String = "MPSService"
    Public cServiceName As String = "MPS Service Application"
#End Region


    '================================================================================================================================================================
    '================================================================================================================================================================
    '
    '   XXXXXXXXXXXX
    '   XXX       XX
    '   XXX       XX
    '   XXXXXXXXXXXX RESTORE ROUTINE
    '   XXX   XXXX
    '   XXX    XXXX
    '   XXX     XXXX
    '
    '================================================================================================================================================================
    '================================================================================================================================================================


#Region "Restore Routines"

    Public Sub Restore_Async(oDLApp As zDataLayer.DataLayer, oDLServer As zDataLayer.DataLayer, ByVal cDataFile As String, ByVal bShowProgress As Boolean, Optional ByRef cLog As String = "", Optional ByVal bShowResults As Boolean = True)
        Dim bwRestore As BackgroundWorker = New BackgroundWorker
        bwRestore.WorkerSupportsCancellation = True
        bwRestore.WorkerReportsProgress = True
        'Assign UI events
        AddHandler bwRestore.DoWork, AddressOf bwRestore_DoWork
        AddHandler bwRestore.RunWorkerCompleted, AddressOf bwRestore_RunWorkerCompleted

        Dim bRetVal As Boolean = False
        Dim oParams As Object() = {oDLApp, oDLServer, cDataFile, bShowProgress, cLog, bShowResults}

        If Not bwRestore.IsBusy = True Then
            bwRestore.RunWorkerAsync(oParams)
        End If

        If bShowProgress Then
            frmStatus = New frmProcessing
            frmStatus.ShowDialog()
            frmStatus.Refresh()
        End If
    End Sub

    Private Sub bwRestore_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim cMsg As String = ""

        'obtain parameters
        Dim oParams As Object() = TryCast(e.Result, Object())
        Dim bSuccess As Boolean = oParams(0)
        Dim bShowProgressBar As Boolean = oParams(1)
        Dim cLog As String = TryCast(oParams(2), String)
        Dim bShowResults As Boolean = oParams(3)

        If oApp.DebugHas("WORKLOAD") Or oApp.DebugHas("IMEX") Then
            ServiceDebug(StrDup(200, "B"), "workload", True)
            ServiceDebug(StrDup(200, "B"), "imex", True)
        End If

        'If bShowProgressBar Then
        Try
            frmStatus.Hide()
            frmStatus.Close()

        Catch ex As Exception
        End Try
        'End If

        If e.Cancelled = True Then
            MsgBox("Test cancelled.")
        ElseIf e.Error IsNot Nothing Then
            'Me.LabelControl3.Text = "Error: " & e.Error.Message
        Else
            If bSuccess Then
                cMsg = "Restore completed successfully."
            Else
                cMsg = "Problems were encountered during restore."
            End If
            If bShowResults Then
                If MsgBox(cMsg & " Would you like to see the restore log?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                    ShowLog(cLog)
                End If
            End If
        End If
    End Sub

    Private Sub bwRestore_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)

        Dim oParams As Object() = TryCast(e.Argument, Object())

        'obtain parameters
        Dim oDLMyApp As zDataLayer.DataLayer = TryCast(oParams(0), zDataLayer.DataLayer)
        Dim oDLSQLServer As zDataLayer.DataLayer = TryCast(oParams(1), zDataLayer.DataLayer)
        Dim cDataFile As String = TryCast(oParams(2), String)
        Dim bShowProgress As Boolean = oParams(3)
        Dim sbLog As New StringBuilder(TryCast(oParams(4), String))
        Dim bShowResults As Boolean = oParams(5)

        'declare new import class
        Dim oRestore As oDE = Nothing
        Dim cLogFirstLine As String = ""
        Dim cDataFileType As String = ""
        Dim bSuccess As Boolean = True
        Dim cErr As String = ""

        If oApp.DebugHas("WORKLOAD") Or oApp.DebugHas("IMEX") Then
            ServiceDebug(StrDup(200, "A"), "workload", True)
            ServiceDebug(StrDup(200, "A"), "imex", True)
        End If

        If bSuccess Then
            'extract data file to temporary folder
            'initialize restore object
            oRestore = New oDE(oDLMyApp, oDLSQLServer, cDataFile, bShowProgress)

            If Not oRestore.HasCriticalErrors Then

                'move file to shared directory
                bSuccess = bSuccess And oRestore.CopyFile(cDataFile)

                'restore file to database
                bSuccess = bSuccess And oRestore.RestoreDatabase(cDataFile)

            End If

            bSuccess = bSuccess And oRestore.Finish(, Not bSuccess)
            bSuccess = bSuccess And (Not oRestore.HasCriticalErrors)

        End If

        If Not oRestore Is Nothing Then
            'get export log and append to own log
            Log_Append(sbLog, oRestore.GetLog(False))
        End If

        'return result
        e.Result = New Object() {bSuccess, bShowProgress, sbLog.ToString, bShowResults}

    End Sub
#End Region

    '================================================================================================================================================================
    '================================================================================================================================================================
    '
    '   XXXXXXXXXXXX 
    '   XXX       XX
    '   XXX       XX
    '   XXXXXXXXXXXX BACKUP ROUTINE                        
    '   XXX       XX
    '   XXX       XX
    '   XXXXXXXXXXXX
    '
    '================================================================================================================================================================
    '================================================================================================================================================================

#Region "Backup Routines"
    Public Sub Backup_Async(oDLApp As zDataLayer.DataLayer, oDLServer As zDataLayer.DataLayer, oProfileAndSchedule As TransferNexus, ByRef cReturnFileName As String, ByVal bShowProgress As Boolean, Optional ByRef cLog As String = "", Optional ByVal bShowResults As Boolean = True)
        Dim bwBackup As BackgroundWorker = New BackgroundWorker
        bwBackup.WorkerSupportsCancellation = True
        bwBackup.WorkerReportsProgress = True
        'Assign UI events
        AddHandler bwBackup.DoWork, AddressOf bwBackup_DoWork
        AddHandler bwBackup.RunWorkerCompleted, AddressOf bwBackup_RunWorkerCompleted

        Dim bRetVal As Boolean = False
        Dim oParams As Object() = {oDLApp, oDLServer, oProfileAndSchedule, cReturnFileName, bShowProgress, cLog, bShowResults}

        If Not bwBackup.IsBusy = True Then
            bwBackup.RunWorkerAsync(oParams)

            If bShowProgress Then
                frmStatus = New frmProcessing
                frmStatus.ShowDialog()
                frmStatus.Refresh()
            End If
        End If

    End Sub


    Private Sub bwBackup_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim cMsg As String = ""

        'obtain parameters
        Dim oParams As Object() = TryCast(e.Result, Object())
        Dim bSuccess As Boolean = oParams(0)
        Dim bShowProgressBar As Boolean = oParams(1)
        Dim cLog As String = TryCast(oParams(2), String)
        Dim bShowResults As Boolean = oParams(3)

        If oApp.DebugHas("WORKLOAD") Or oApp.DebugHas("IMEX") Then
            ServiceDebug(StrDup(200, "B"), "workload", True)
            ServiceDebug(StrDup(200, "B"), "imex", True)
        End If

        Try
            frmStatus.Dispose()

        Catch ex As Exception
        End Try

        If e.Cancelled = True Then
            'Me.LabelControl3.Text = "Canceled!"
            MsgBox("Test cancelled.")
        ElseIf e.Error IsNot Nothing Then
            'Me.LabelControl3.Text = "Error: " & e.Error.Message
        Else
            If bSuccess Then
                cMsg = "Backup completed successfully."
            Else
                cMsg = "Problems were encountered during backup."
            End If
            If bShowResults Then
                If MsgBox(cMsg & " Would you like to see the backup log?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                    ShowLog(cLog)
                End If
            End If
        End If
    End Sub

    Private Sub bwBackup_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim oParams As Object() = TryCast(e.Argument, Object())

        'obtain parameters
        Dim oDLMyApp As zDataLayer.DataLayer = TryCast(oParams(0), zDataLayer.DataLayer)
        Dim oDLSQLServer As zDataLayer.DataLayer = TryCast(oParams(1), zDataLayer.DataLayer)

        Dim oProfileAndSchedule As TransferNexus = DirectCast(oParams(2), TransferNexus)
        Dim oProfile As oProfile = oProfileAndSchedule.oProf
        Dim oTransfer As oTransfer = oProfileAndSchedule.oTransfer
        Dim oCallingModule As CallingModule = oProfileAndSchedule.oCallingModule

        Dim cReturnFileName As String = TryCast(oParams(3), String)
        Dim bShowProgress As Boolean = oParams(4)
        Dim sbLog As New StringBuilder(TryCast(oParams(5), String))
        Dim bShowResults As Boolean = oParams(6)

        Dim nCtr As Integer = 0
        Dim cCode As String = ""
        'declare new export class
        Dim oBackup As oDE = Nothing
        Dim bSuccess As Boolean = True
        Dim cErr As String = ""

        Dim zBackupShema As New DataTable

        Dim cSQL As String = ""
        Dim nNumFound As Long = 0
        Dim oTmpFolder As oTmpFolder = Nothing

        If oApp.DebugHas("WORKLOAD") Or oApp.DebugHas("IMEX") Then
            ServiceDebug(StrDup(200, "A"), "workload", True)
            ServiceDebug(StrDup(200, "A"), "imex", True)
        End If

        If Not oProfileAndSchedule.oSched Is Nothing Then
            Schedule_AddToRunning(oProfileAndSchedule.oSched)
        End If

        'show progress bar?
        Select Case oCallingModule
            Case CallingModule.BRS_INTERFACE
                bShowProgress = True
            Case CallingModule.BRS_SERVICE
                bShowProgress = False
        End Select

        'validate parameters
        If Not Directory.Exists(oProfile.ExpFolder) Then
            cErr = "Backup folder is invalid: """ & oProfile.ExpFolder & """"
            Log_Append(sbLog, cErr)
            bSuccess = False
        End If


        If bSuccess Then
            'initialize new object
            oBackup = New oDE(oDLMyApp, oDLSQLServer, oProfileAndSchedule, bShowProgress, cReturnFileName)

            zBackupShema = oDLSQLServer.ExecuteDataTable("SELECT * FROM tblSTIService_Schema ORDER BY AppName, SchemaName")
            If zBackupShema.Rows.Count > 0 Then
                Dim x As Integer = 0
                For x = 0 To zBackupShema.Rows.Count - 1
                    Dim SchemaName As String = zBackupShema(x)("SchemaName")
                    bSuccess = oBackup.BackupDatabase(SchemaName)
                Next

                If oBackup.GetTotalObjects > 0 And oBackup.GetTotalObjectsMove > 0 Then
                    bSuccess = True
                Else
                    bSuccess = False
                End If

            End If

            bSuccess = bSuccess And oBackup.Finish(, Not bSuccess)

        End If



        If Not oBackup Is Nothing Then
            bSuccess = bSuccess And (Not oBackup.HasCriticalErrors)
            'get export log and append to own log
            Log_Append(sbLog, oBackup.GetLog(False))
        Else
            bSuccess = False
            'delete transfer
            Try
            Catch ex As Exception
                oTransfer.Delete()
            End Try
        End If

        If Not oProfileAndSchedule.oSched Is Nothing Then
            Schedule_RemoveFromRunning(oProfileAndSchedule.oSched)
        End If

        'return result
        e.Result = New Object() {bSuccess, bShowProgress, sbLog.ToString, bShowResults}

    End Sub

#End Region

    '================================================================================================================================================================
    '================================================================================================================================================================
    '
    '   XXXXXXXXXXXX
    '   XXX       XXX
    '   XXX       XXX
    '   XXXXXXXXXXXX  GENERAL BUSINESS RULES
    '   XXX       XXX
    '   XXX       XXX
    '   XXXXXXXXXXXX
    '
    '================================================================================================================================================================
    '================================================================================================================================================================


#Region "Business Rules"

    Public Delegate Sub UpdateStatusDelegate(ByVal nNumCompleted As Integer, ByVal cCurrTask As String, ByVal cTitle As String, ByVal bShowProgressBar As Boolean)
    Public Sub UpdateStatus(ByVal nNumCompleted As Integer, ByVal cCurrTask As String, Optional ByVal cTitle As String = "Status", Optional ByVal bShowProgressBar As Boolean = True)
        If bShowProgressBar Then
            Try
                If frmStatus.InvokeRequired Then
                    frmStatus.Invoke(New UpdateStatusDelegate(AddressOf UpdateStatus), nNumCompleted, cCurrTask, cTitle, bShowProgressBar)
                Else
                    frmStatus.grpStatus.Text = cTitle
                    frmStatus.lblCompleted.Text = IIf(nNumCompleted = 0, "---", nNumCompleted)
                    frmStatus.lblCurr.Text = cCurrTask

                    'force refresh all
                    frmStatus.Refresh()
                    If oApp.DebugHas("WORKLOAD") Then
                        ServiceDebug(cTitle.PadRight(30) & " " & cCurrTask, "workload", True)
                    End If
                End If
            Catch ex As Exception
            End Try
        Else
            If oApp.DebugHas("WORKLOAD") Then
                ServiceDebug(cTitle.PadRight(30) & " " & cCurrTask, "workload", True)
            End If
        End If
    End Sub

    'RETURNS: DataTable object for requested source
    '         NO SQL should be found in 
    'PARAMETERS:
    '   <cSourceName> - Descriptive name of source to get, for example: "COUNTRY"
    '   <cParams> - Optional parameters (like where condition, etc)
    Public Function GetDataTable(ByVal cSourceName As String, Optional ByVal cParams As String = "") As DataTable
        Dim dt As DataTable = Nothing
        Dim dr As DataRow = Nothing
        Dim cSQL As String = ""
        Dim cErr As String = ""


        Select Case UCase(cSourceName)
            Case "SCHED_QUEUE"
                cSQL = "SELECT CONVERT(VARCHAR(20), GETDATE(), 100) AS mssqltime, t.SCHED_Code, t.SCHED_LastRun AS lastrun,"
                cSQL = cSQL & " CASE WHEN [t].[SCHED_Type]='0' THEN 'BACKUP' ELSE 'EXPORT' END + ': ' + [t].[sched_name] + CASE WHEN [t].[sched_active]=1 THEN '' ELSE '  (disabled)' END AS sname,"
                cSQL = cSQL & " CONVERT(VARCHAR(12),t.SCHED_NextRun,100) + ' ' + SUBSTRING( CONVERT(varchar, t.SCHED_StartTime,108),1,8) AS nextrun"
                cSQL = cSQL & " FROM tblSTISErvice_schedule AS t"
                cSQL = cSQL & " WHERE([t].[sched_active] <> 0)"
                cSQL = cSQL & " order by CONVERT(VARCHAR(12),t.SCHED_NextRun,100) + ' ' + SUBSTRING( CONVERT(varchar, t.SCHED_StartTime,108),1,8)"
                dt = oDLSQLSERVER.ExecuteDataTable(cSQL)

            Case "EVENT_LOG"
                cSQL = "SELECT * FROM tblSTIService_eventlog t WHERE t.logid='" & cParams & "';"
                dt = oDLSQLSERVER.ExecuteDataTable(cSQL)

            Case "TRANSFER"
                cSQL = "SELECT * FROM tblSTIService_transfers t WHERE t.Transfer_Code='" & cParams & "';"
                dt = oDLSQLSERVER.ExecuteDataTable(cSQL)

            Case "SCHED"
                cSQL = "SELECT * FROM tblSTIService_schedule t WHERE SCHED_Code='" & cParams & "';"
                dt = oDLSQLSERVER.ExecuteDataTable(cSQL)

            Case "SCHED_LIST"

                cSQL = "SELECT t.sched_code, CASE WHEN [t].[SCHED_Type]='0' THEN 'BACKUP' ELSE '' END + ': ' + [t].[sched_name] + CASE WHEN [t].[sched_active]=0 THEN '  (disabled)' ELSE '' END AS sname"
                cSQL = cSQL & " FROM tblSTIService_schedule AS t WHERE SCHED_Type<>'2' ORDER BY CASE WHEN [t].[SCHED_Type]='0' THEN 'BACKUP' ELSE '' END  + ': ' + [t].[sched_name] + CASE WHEN [t].[sched_active]=0 THEN ' (disabled)' ELSE '' END"

                dt = oDLSQLSERVER.ExecuteDataTable(cSQL)

            Case "SCHED_TYPE"
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT * FROM tblSTIService_imex_schedule_type t;")

            Case "PROFILE_LIST"
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT prof_code, prof_name FROM tblSTIService_profile")

            Case "PROFILE_MATCH"
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT * FROM tblSTIService_profile WHERE prof_code='" & cParams & "'")

            Case "INET_MATCH"
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT t.* FROM tblSTIService_internet_settings t WHERE t.INET_Code='" & cParams & "'")

            Case "INET_LIST"
                'list all ftp internet settings
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT INET_Code, INET_ProfileName FROM tblSTIService_internet_settings t WHERE INET_Type=" & cParams & " ORDER BY inet_profilename;")

            Case "INET_EMAIL_SMTP"
                'list all email smtp settings
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT INET_Code, INET_ProfileName FROM tblSTIService_internet_settings t WHERE INET_Type=" & cParams & " AND EMAIL_TYPE=0 ORDER BY inet_profilename;")

            Case "INET_EMAIL_POP"
                'list all email pop settings
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT INET_Code, INET_ProfileName FROM tblSTIService_internet_settings t WHERE INET_Type=" & cParams & " AND EMAIL_TYPE=1 ORDER BY inet_profilename;")

            Case "EMAIL_NOTIF_LIST"
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT * FROM tblSTIService_email_notif ORDER BY Email")

            Case "EMAIL_NOTIF_MATCH"
                dt = oDLSQLSERVER.ExecuteDataTable("SELECT * FROM tblSTIService_email_notif WHERE Notif_Success=" & cParams & "")

        End Select
        Return dt

    End Function

    

    'RETURNS: 
    '           TRUE - all configuration and data connection are valid
    '           FALSE - exit application immediately
    Public Function SpectralService_Init(Optional ByVal bShowConnectForm As Boolean = True, Optional ByRef cErr As String = "", Optional ByVal nRetryTimes As Integer = 10, Optional ByVal bReloadFromConfig As Boolean = True) As Boolean
        Dim bRetval As Boolean = False
        Dim nRetry As Integer = 0

        Try
            If Not oApp.Initialized OrElse bReloadFromConfig Then
                'Ask Businesslayer to read configuration settings from INI file
                '====================================================================================
                oApp.ReadConfigFile()
            End If

            If Not oApp.Initialized And Not bShowConnectForm Then
                bRetval = False
                cErr = "Run Interface to initialize database connection."
            Else

                bRetval = True

                If Not bRetval AndAlso cErr <> "" Then
                    If oApp.DebugHas("WORKLOAD") Then
                        ServiceDebug("OleDB Failed (Retried " & nRetryTimes & " times) : " & cErr, "workload", True)
                    End If
                    If oApp.DebugHas("IMEX") Then
                        ServiceDebug("OleDB Failed (Retried " & nRetryTimes & " times) : " & cErr, "imex", True)
                    End If
                End If

            End If

        Catch ex As Exception
            cErr = ex.Message
            MsgBox(ex.Message)
        End Try

        Return bRetval

    End Function

    Private Sub SetServiceInfo(ByVal cStatus As String)
        Dim cLine As String
        cLine = Format(Now, "hh:mm:ss tt | ") & cStatus & vbCrLf
        cServiceWorkLoad = cLine & cServiceWorkLoad
        cServiceWorkLoad = Mid$(cServiceWorkLoad, 1, 2000)
    End Sub

    Private Sub SaveServiceInfo()
        cServiceWorkLoad = cServiceWorkLoad & vbCrLf & GetServiceInfo()
        cServiceWorkLoad = Mid$(cServiceWorkLoad, 1, 2000)
        ServiceFile("SET", "ServiceStat.txt", cServiceWorkLoad)
        cServiceWorkLoad = ""
    End Sub

    Public Sub ClearServiceInfo()
        ServiceFile("SET", "ServiceStat.txt", "")
        cServiceWorkLoad = "" 'reset value so that it isnt displayed again
    End Sub

    Public Function GetServiceInfo() As String
        Return ServiceFile("GET", "ServiceStat.txt")
    End Function

    Public Function GetLiveStatus(Optional ByRef cLiveStat As String = "", Optional ByRef cSaveStatErr As String = "") As ServiceCallingModule
        cLiveStat = ServiceFile("GET", "ServiceLiveStat.txt")
        cSaveStatErr = cLiveStatErr
        Return CType(NullToZero(GetItemDelimited(cLiveStat, 1, "|")), ServiceCallingModule)
    End Function

    Public Sub SetLiveStatus(ByRef cLiveStat As String)
        Dim nAffected As Long = 0
        ServiceFile("SET", "ServiceLiveStat.txt", cLiveStat)
    End Sub

    Public Sub Service_DoWork(Optional ByVal pServiceInitiator As ServiceCallingModule = ServiceCallingModule.None)
        Dim cProcessCode As String = GetAutoCode(5)
        Dim cConnectErr As String = ""

        'run service and transfers
        If (Transfer_RunningCount() + Schedule_RunningCount()) = 0 Then
            SetServiceInfo("Enter work process " & cProcessCode)
            'bServiceIsBusy = True

            If SpectralService_Init(False, cConnectErr, , False) Then

                SetServiceInfo("DB Connection OK")
                'initialize data connections

                Dim oSched As New oSched
                Dim oTransfer As New oTransfer
                Dim cTransferCode As String = ""
                Dim cSchedCode As String
                Dim cSchedName As String = ""
                Dim cSQL As String = ""

                'get first transfer code that isnt running
                cTransferCode = oDLSQLSERVER.DLookUp("transfer_code", "tblSTIService_transfers", "nextrun<=GETDATE()")

                Dim dServerDate As DateTime = oDLSQLSERVER.MSSql_GetServerTime("")

                cSQL = "SELECT TOP 1  t.sched_code + '|' + t.sched_name AS retval FROM tblSTIService_schedule t"
                cSQL = cSQL & " WHERE (t.sched_active<>0) AND (REPLACE(CONVERT(VARCHAR(10),t.SCHED_NextRun,120),'-','') + REPLACE(SUBSTRING(CONVERT(VARCHAR, t.SCHED_StartTime,108),1,8),':','')<=REPLACE(CONVERT(VARCHAR(10),GETDATE(),120),'-','') + REPLACE(SUBSTRING(CONVERT(VARCHAR, GETDATE(),108),1,8),':',''))"

                cSchedCode = oDLSQLSERVER.DLookUpSQL("retval", cSQL)
                cSchedName = GetItemDelimited(cSchedCode, 2, "|")
                cSchedCode = GetItemDelimited(cSchedCode, 1, "|")

                If cSchedCode <> "" And Schedule_RunningCount() = 0 Then
                    If Not Schedule_IsRunning(cSchedCode) Then
                        If Transfer_RunningCount() <> 0 Then
                            'stop all transfers to give way to run the schedule
                            cTransferCode = ""
                            SetServiceInfo("Stopping all running transfer(s)...")
                            oTransfer.bCancelAll = True
                            Do While Transfer_RunningCount() <> 0
                                Application.DoEvents()
                            Loop
                        End If

                        SetServiceInfo("Run Schedule [" & cSchedCode & "] - '" & cSchedName & "'")
                        oSched.SCHED_Code = cSchedCode
                        oSched.SCHED_NextRun_Increment(True)
                        oSched.Launch(CallingModule.BRS_SERVICE)
                    End If
                ElseIf Schedule_RunningCount() > 0 Then
                    SetServiceInfo(Schedule_RunningCount() & " running schedule...")
                End If

                If cTransferCode <> "" AndAlso Schedule_RunningCount() = 0 Then
                    If Not Transfer_IsRunning(cTransferCode) Then
                        SetServiceInfo("Run Transfer [" & cTransferCode & "]. " & (Transfer_RunningCount() + 1) & " running transfer(s).")
                        oTransfer.Transfer_Code = cTransferCode
                        oTransfer.Transfer_Async(False)
                    Else
                        SetServiceInfo(Transfer_RunningCount() & " running transfer(s).")
                    End If
                ElseIf Transfer_RunningCount() > 0 Then
                    SetServiceInfo(Transfer_RunningCount() & " running transfer(s).")
                End If


                If Transfer_RunningCount() = 0 And Schedule_RunningCount() = 0 Then
                    SetServiceInfo("Idle...")
                    CheckLicensing() 'execute licensing concerns
                End If
            Else
                If oApp.Initialized Then
                    SetServiceInfo(Format(Now, "hh:mm:ss tt | ") & cConnectErr)
                Else
                    'when application has not been initialized do not log connection errors continously because tthe user has not yet
                    'logged into the MPSDE Interface to "attach" tables
                    If cLastConnectErr <> cConnectErr Then
                        SetServiceInfo(Format(Now, "hh:mm:ss tt | ") & cConnectErr)
                        cLastConnectErr = cConnectErr
                    End If
                End If
            End If

            SetServiceInfo("Exit work process " & cProcessCode)
        Else
            'update service log
            SetServiceInfo("Working... " & cProcessCode)
            SetServiceInfo(Transfer_RunningCount() & " running transfer(s). " & Schedule_RunningCount() & " running schedule(s). ")
        End If

        SaveServiceInfo()

        'update live status
        '-----------------------------------------------------------------------------------------
        Dim cLiveStat As String = pServiceInitiator

        If cConnectErr = "" Then
            If (Transfer_RunningCount() + Schedule_RunningCount()) = 0 Then
                cLiveStat = cLiveStat & "|Idle..."
            Else
                cLiveStat = cLiveStat & "|Working..."
            End If
        Else
            If oApp.Initialized Then
                cLiveStat = cLiveStat & "|MS SQL Connetion Failed. Attempting to reconnect..."
            Else
                cLiveStat = cLiveStat & "|Please run MPS Service Interface for the first time"
            End If

        End If

        cLiveStat = cLiveStat & "|"

        If cConnectErr = "" Then
            If (Transfer_RunningCount() + Schedule_RunningCount()) > 0 Then
                cLiveStat = cLiveStat & Transfer_RunningCount() & " running transfer(s)..." & Schedule_RunningCount() & " running schedule(s)..."
            Else
                cLiveStat = cLiveStat & ""
            End If
        Else
            cLiveStat = cLiveStat & cConnectErr
        End If

        SetLiveStatus(cLiveStat)

    End Sub

    Public Sub Service_RunAutoEmail(bRun As Boolean)
        Dim exePath As String = Directory.GetParent(Application.StartupPath).FullName
        exePath += IIf(Right(exePath, 1) = "\", "", "\")
        exePath += "ReportAutoEmail\ReportAutoEmail_exe.exe"
        If bRun Then
            If Not IsProcessRunning("ReportAutoEmail_exe") Then
                If IsProcessResponding() Then
                    Process.Start(exePath)
                End If
            End If
        Else
            Try
                Dim pList() As Process = Process.GetProcessesByName("ReportAutoEmail_exe")
                For Each p As Process In pList
                    p.Kill()
                Next
            Catch ex As Exception
                LogErrors("Service_AutoEmail() error : " & ex.Message)
            End Try
        End If
    End Sub

    Function IsProcessRunning(name As String)
        Return Process.GetProcessesByName(name).Length > 0
    End Function

    Function IsProcessResponding()
        Return True
    End Function

    Private Function ServiceFile(ByVal cMode As String, ByVal cFileName As String, Optional ByVal cValue As String = "") As String
        Dim cServiceFile As String = CleanPath(oApp.GetAppFolder) & cFileName
        Dim cRetval As String = ""
        Select Case UCase(cMode)
            Case "GET"
                Try
                    cRetval = File.ReadAllText(cServiceFile)
                Catch ex As Exception
                End Try

            Case "SET"
                File.WriteAllText(cServiceFile, cValue)
        End Select
        Return cRetval
    End Function

    Public Sub ServiceDebug(ByVal cLine As String, ByVal cFilePostFix As String, Optional ByVal bNewLine As Boolean = False)
        Dim cLocalFolder As String = CleanPath(oApp.GetAppFolder) & "logs\service\"
        Dim FILE_NAME As String = cLocalFolder & Format(Now(), "yyyyMMdd") & "_" & cFilePostFix & ".txt"

        Try
            If Not System.IO.Directory.Exists(cLocalFolder) Then
                Try
                    System.IO.Directory.CreateDirectory(cLocalFolder)
                Catch ex As Exception
                End Try
            End If

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            cLine = Format(Now, "hh:mm:ss tt | ") & cLine
            If bNewLine Then
                objWriter.WriteLine(cLine)
            Else
                objWriter.Write(cLine)
            End If
            objWriter.Close()
        Catch ex As Exception
        End Try

    End Sub

    Public Function GetEmailReceivers(ByVal oDL As zDataLayer.DataLayer, ByVal errornotif As Boolean) As String
        Dim r As String = ""
        Dim dtemail As DataTable
        Try
            If errornotif Then
                dtemail = GetDataTable("EMAIL_NOTIF_LIST")
            Else
                dtemail = GetDataTable("EMAIL_NOTIF_MATCH", "1")
            End If

            If dtemail.Rows.Count > 0 Then
                For Each drItem In dtemail.Rows
                    r = r & IIf(r.Length > 0, ",", "") & """" & drItem("Email") & """"
                Next
            End If
        Catch ex As Exception
            r = ""
        End Try
        Return r
    End Function

#End Region

    Public Sub ShowLog(ByVal cLog As String)
        Dim frmLogViewer As New frmLogViewer
        frmLogViewer.txtLogText.Text = cLog
        frmLogViewer.ShowDialog()
    End Sub


    Public Sub Log_Append(ByRef sbLog As StringBuilder, ByVal sbLine As StringBuilder)
        If sbLine Is Nothing Then
            sbLine = New StringBuilder("")
        End If
        sbLog.Append(sbLine.ToString)
        sbLog.Append(vbCrLf)
        If oApp.DebugHas("IMEX") Then
            ServiceDebug(sbLine.ToString, "imex", True)
        End If
    End Sub

    Public Sub Log_Append(ByRef sbLog As StringBuilder, ByVal cLine As String)
        sbLog.Append(cLine & vbCrLf)
        If oApp.DebugHas("IMEX") Then
            ServiceDebug(cLine, "imex", True)
        End If
    End Sub

#Region "Licensing"
    Public Sub CheckLicensing() ' service check licensing : MPSLICENSE  ONLY

        If isLicenseNeedstoValidate(mps5_app) Then
            Dim xyStatus As New MyLicenseStatus
            CheckLicense(mps5_app, xyStatus)
            SetServiceInfo("Evaluating MPS 5 Application MPS License")
        End If

    End Sub
#End Region


End Module
