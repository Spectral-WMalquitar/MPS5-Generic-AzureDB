Imports zUtil
Imports zDataLayer
Imports System.ComponentModel
Imports System.Text

Public Module AppEEntities

    Public Structure TransferNexus
        Public oSched As oSched
        Public oProf As oProfile
        Public oTransfer As oTransfer
        Public oCallingModule As CallingModule
        Public GetFileErr As GetFileErr
    End Structure

    Public Structure TableList
        Public DBName As String
        Public TableName As String
        Public ExemptFields As String  'pipeline delimited list of export exempted fields (e.g. "`field1`|`field2`|`field3`")

        Private Sub FixExemptFields()
            Dim cFieldName As String = ""
            Dim nCtr As Integer = 0

            If ExemptFields.Length > 0 Then
                'fix exempt fields format
                For nCtr = 1 To CountItemDelimited(ExemptFields, "|")
                    cFieldName = GetItemDelimited(ExemptFields, nCtr, "|")
                    If Left(cFieldName, 1) <> "`" And Right(cFieldName, 1) <> "`" Then
                        cFieldName = "`" & Trim(cFieldName) & "`"
                        SaveItemDelimited(ExemptFields, nCtr, "|", cFieldName)
                    End If
                Next
            End If

        End Sub

        Public Sub New(ByVal cDBName As String, ByVal cTableName As String, Optional ByVal cExemptFields As String = "")
            DBName = cDBName
            TableName = cTableName
            ExemptFields = cExemptFields
            FixExemptFields()
        End Sub
    End Structure

    Public Structure App
        Public Initialized As Boolean
        Public ConnDetails As connDetails
        Public AES As String
        Private Debug As String

        'constants
        Private Const AppName As String = "MPS Service App"

        'current user account
        Public UserID As String
        Public UserName As String

        'Schemas
        Public SchemaOne As String
        Public SchemaTwo As String
        Public SchemaThree As String

        Public Function GetAppFolder() As String
            Return System.AppDomain.CurrentDomain.BaseDirectory()
        End Function

        Public Function GetAppName() As String
            Return AppName
        End Function

        Public Function GetAppAcronym() As String
            Return AppAcronym
        End Function

        'Returns: 
        'TRUE - if <cDebugItem> is in <Debug> property
        'FALSE, otherwise
        Public Function DebugHas(ByVal cDebugItem As String) As Boolean
            Dim bRetVal As Boolean = False
            If InStr(";" & Debug & ";", ";" & UCase(cDebugItem) & ";") > 0 Then
                bRetVal = True
            End If
            Return bRetVal
        End Function

        Public Sub ReadConfigFile()
            'Load settings to application object
            AES = INI_GetConfig(AppAcronym, "AES")
            Debug = UCase(NullToString(INI_GetConfig(AppAcronym, "Debug"))) 'semicolon delimited list of items for debugging

            ConnDetails.Server = INI_GetConfig(AppAcronym, "SERVER_INSTANCE")
            ConnDetails.OtherOptions = INI_GetConfig(AppAcronym, "SERVER_AUTH")
            ConnDetails.User = INI_GetConfig(AppAcronym, "SERVER_USER")
            ConnDetails.Pwd = INI_GetConfig(AppAcronym, "SERVER_PWD")
            ConnDetails.ConnStr = INI_GetConfig(AppAcronym, "connStr")
            ConnDetails.Type = NullToZero(INI_GetConfig(AppAcronym, "CONNTYPE"))

            Dim cErr As String = ""
            If Test_SQLServerConnections(oDLTest, ConnDetails, True, cErr) Then
                'initialized other configs

                SQL_SERVER = INI_GetConfig(AppAcronym, "SERVER_INSTANCE")
                SERVER_AUTH = INI_GetConfig(AppAcronym, "SERVER_AUTH")
                SQL_USER_NAME = INI_GetConfig(AppAcronym, "SERVER_USER")
                SQL_PASSWORD = INI_GetConfig(AppAcronym, "SERVER_PWD")

                SetDefaultSettings()
            End If
            ConnDetails.DBName = IIf(NullToString(INI_GetConfig(AppAcronym, "SERVER_DB")) = "", "STIAPPVERSIONS", INI_GetConfig(AppAcronym, "SERVER_DB"))
            Initialized = Test_SQLServerConnections(oDLSQLSERVER, ConnDetails, True, cErr)

        End Sub

        Public Function SaveConfigFile(ByVal oConDetails As connDetails) As Boolean
            'Load settings to application object
            INI_SaveConfig(AppAcronym, "AES", AES)
            INI_SaveConfig(AppAcronym, "SERVER_DB", oConDetails.DBName)
            INI_SaveConfig(AppAcronym, "SERVER_INSTANCE", oConDetails.Server)
            INI_SaveConfig(AppAcronym, "SERVER_AUTH", oConDetails.OtherOptions)
            INI_SaveConfig(AppAcronym, "SERVER_USER", oConDetails.User)
            INI_SaveConfig(AppAcronym, "SERVER_PWD", oConDetails.Pwd)
            INI_SaveConfig(AppAcronym, "connStr", oConDetails.ConnStr)
            INI_SaveConfig(AppAcronym, "CONNTYPE", oConDetails.Type)
            ConnDetails = oConDetails
            Return True
        End Function

        Public Function Test_SQLServerConnections(ByVal oDL As zDataLayer.DataLayer, ByVal oCCon As connDetails, Optional ByVal showForm As Boolean = True, Optional ByRef cErr As String = "", Optional ByVal nRetryTimes As Integer = 10) As Boolean
            Dim bRetval As Boolean = False
            Dim nRetry As Integer = 0
            Try
                oDL.Init(oCCon)
                bRetval = oDL.TestConn(cErr)

                oDL.Init(oCCon)

                If oDL.TestConn Then
                    bRetval = True
                Else
                    If showForm Then
                        Select Case oDL.ShowServerConnectionForm(oCCon)
                            Case 0 'failed
                                bRetval = False
                            Case 1 'success
                                'save tested connection to application object
                                bRetval = oApp.SaveConfigFile(oCCon)

                                'allow to go ahead to the program
                                bRetval = True

                            Case 2 'cancelled
                                bRetval = False
                        End Select
                    Else
                        'just test connections
                        bRetval = False
                    End If
                End If
            Catch ex As Exception
                bRetval = False
            End Try
            Return bRetval
        End Function

    End Structure

    Public Enum GetFileErr
        No_Error = 0
        No_Conection = 1
        Missing_File = 2
        Missing_File_Upload_Failed = 3
        Existing_File_Delete_Failed = 4
        File_Download_Failed = 5
        Hash_Mismatch = 6
        MissingFolder = 7
    End Enum

    Public Enum INET_Type
        FTP = 0
        SMTP = 1
    End Enum

    Public Enum ActionType
        Backup = 0
        Restore = 1
        ExportData = 2
    End Enum

    Public Enum CallingModule
        BRS_INTERFACE = 0  'MPS Data Exchange.EXE
        BRS_SERVICE = 1    'MPS Data Exchange Service.EXE
    End Enum

#Region "TempFolder Class"
    Public Class oTmpFolder
        Private cTmpFolderName As String = ""
        Private cTmpFolderFull As String = ""
        Private cBaseFolder As String = ""
        Private bIsReady As Boolean = False

        Public ReadOnly Property IsReady As Boolean
            Get
                Return bIsReady
            End Get
        End Property

        Public ReadOnly Property TempFolder As String
            Get
                Return CleanPath(cTmpFolderFull)
            End Get
        End Property

        Public ReadOnly Property BaseFolder As String
            Get
                Return cTmpFolderFull
            End Get
        End Property

        Public Sub New(ByVal cRootFolder As String, Optional ByVal nNameLength As Integer = 15, Optional ByVal cPrefix As String = "")
            cBaseFolder = cRootFolder
            cTmpFolderName = cPrefix & GetAutoCode(nNameLength)
            cTmpFolderFull = CleanPath(cRootFolder) & cTmpFolderName
            Try
                IO.Directory.CreateDirectory(cTmpFolderFull)
                bIsReady = True
            Catch ex As Exception
            End Try
        End Sub

        Public Sub NukeTemp()
            Try
                'DELETE ALL files
                For Each FileFound As String In System.IO.Directory.GetFiles(CleanPath(cTmpFolderFull), "*.*")
                    System.IO.File.Delete(FileFound)
                Next
                'DELETE TMP FOLDER
                System.IO.Directory.Delete(cTmpFolderFull)
            Catch ex As Exception
            End Try
        End Sub

    End Class
#End Region

#Region "Schedule Class"
    Public Class oSched
        Private cSCHED_Code As String = ""
        Public SCHED_Name As String = ""
        Public SCHED_Type As ActionType
        Public SCHED_Action As String = ""
        Public SCHED_LastRun As Date?
        Public SCHED_NextRun As Date?
        Public SCHED_StartTime As Date?
        Public SCHED_Days As Integer = 0
        Public SCHED_RunBefore As String = ""
        Public SCHED_RunAfter As String = ""
        Public SCHED_Active As Integer = 0
        Public SCHED_Internet_FTP_Profile As String = ""
        Public SCHED_Internet_FTP_Folder As String = ""
        Public SCHED_Internet_Email_Profile As String = ""
        Public SCHED_IncludePics As Integer = 1 'stored in FTP

        Public Property SCHED_Code As String
            Get
                Return cSCHED_Code
            End Get
            Set(value As String)
                cSCHED_Code = value
                Load()
            End Set
        End Property

        Public Sub Launch(ByVal oCallingModule As CallingModule)
            Dim cReturnFileName As String = ""
            Dim cLog As String = ""
            Dim oProfile As New oProfile
            Dim oProfileAndSchedule As TransferNexus
            Dim bSuccess As Boolean = True
            Dim bShowProgress As Boolean = False
            Dim bShowResults As Boolean = False
            Dim oTransfer As New oTransfer

            Select Case SCHED_Type
                Case ActionType.Backup
                    Select Case oCallingModule
                        Case CallingModule.BRS_INTERFACE
                            'this can only have been launched from the schedule form
                            bShowProgress = True
                            bShowResults = True
                        Case CallingModule.BRS_SERVICE
                            'launched by the service
                            bShowProgress = False
                            bShowResults = False
                    End Select

                    'SCHEDULE
                    oProfileAndSchedule.oSched = Me
                    'PROFILE
                    oProfile.Load(SCHED_Action) 'load export profile
                    oProfileAndSchedule.oProf = oProfile
                    'TRANSFER
                    oTransfer.SCHED_Code = oProfileAndSchedule.oSched.SCHED_Code
                    oTransfer.INET_Code = oProfileAndSchedule.oSched.SCHED_Internet_FTP_Profile
                    oTransfer.RemoteFolder = oProfileAndSchedule.oSched.SCHED_Internet_FTP_Folder
                    oTransfer.NextRun = DateAdd(DateInterval.Minute, 1, Now)
                    oTransfer.DataFile = GetAutoCode(45)  'to be filled up later by export, in the meantime fill up with a unique code
                    oTransfer.MainLog.Clear()   'to be filled up later by export
                    oTransfer.SendOrReceive = ActionType.Backup
                    oTransfer.Save()

                    oProfileAndSchedule.oTransfer = oTransfer
                    'CALLING MODULE
                    oProfileAndSchedule.oCallingModule = oCallingModule

                    'backup database schema
                    Backup_Async(oDLSQLSERVER, oDLSQLSERVER, oProfileAndSchedule, cReturnFileName, bShowProgress, cLog, bShowResults)

                Case ActionType.ExportData
                    Select Case oCallingModule
                        Case CallingModule.BRS_INTERFACE
                            'this can only have been launched from the schedule form
                            bShowProgress = True
                            bShowResults = True
                        Case CallingModule.BRS_SERVICE
                            'launched by the service
                            bShowProgress = False
                            bShowResults = False
                    End Select

                    'SCHEDULE
                    oProfileAndSchedule.oSched = Me
                    'PROFILE
                    oProfile.Load(SCHED_Action) 'load export profile
                    oProfileAndSchedule.oProf = oProfile
                    'TRANSFER
                    oTransfer.SCHED_Code = oProfileAndSchedule.oSched.SCHED_Code
                    oTransfer.INET_Code = oProfileAndSchedule.oSched.SCHED_Internet_FTP_Profile
                    oTransfer.RemoteFolder = oProfileAndSchedule.oSched.SCHED_Internet_FTP_Folder
                    oTransfer.NextRun = DateAdd(DateInterval.Minute, 1, Now)
                    oTransfer.DataFile = GetAutoCode(45)  'to be filled up later by import, in the meantime fill up with a unique code
                    oTransfer.MainLog.Clear() 'to be filled up later by export
                    oTransfer.SendOrReceive = ActionType.ExportData
                    'don't save until were ready to transfer all related images back from FTP site
                    'oTransfer.Save()

                    oProfileAndSchedule.oTransfer = oTransfer
                    'CALLING MODULE
                    oProfileAndSchedule.oCallingModule = oCallingModule

                    'export WRH data 
                    'ExportData_Async(oDLSQLSERVER, oDLSQLSERVER, oProfileAndSchedule, cReturnFileName, bShowProgress, cLog, bShowResults)
            End Select

        End Sub

        'increment next run then save
        Public Sub SCHED_NextRun_Increment(Optional ByVal bSave As Boolean = False)
            Dim dStartDate As Date = DateAdd(DateInterval.Day, 1, Now)
            SCHED_LastRun = SCHED_NextRun
            SCHED_NextRun = FindEarliestDate(FindEarliestDay(SCHED_Days, dStartDate), dStartDate)
            If cSCHED_Code <> "" And bSave Then
                Dim cSQL As String = ""
                cSQL = "UPDATE tblSTIService_schedule SET"
                cSQL = cSQL & " SCHED_LastRun=" & MySQLDateFormatNullable(SCHED_LastRun) & ","
                cSQL = cSQL & " SCHED_NextRun=" & MySQLDateFormatNullable(SCHED_NextRun)
                cSQL = cSQL & " WHERE SCHED_Code='" & cSCHED_Code & "'"
                oDLSQLSERVER.ExecuteNonQuery(cSQL)
            End If
        End Sub

        Public Function Save(Optional ByVal cSaveAsProfName As String = "") As Boolean
            Dim cSQL As String = ""
            Dim bRetVal As Boolean = False
            Dim cOldID As String = ""

            cOldID = oDLSQLSERVER.DLookUp("SCHED_Code", "tblSTIService_schedule", "SCHED_Name='" & RemoveInject(cSaveAsProfName) & "'")
            If cOldID <> "" Then
                'update
                cSCHED_Code = cOldID
                cSQL = "UPDATE tblSTIService_schedule SET"
                cSQL = cSQL & " SCHED_Name='" & RemoveInject(cSaveAsProfName) & "',"
                cSQL = cSQL & " SCHED_Type=" & SCHED_Type & ","
                cSQL = cSQL & " SCHED_Action='" & RemoveInject(SCHED_Action) & "',"
                cSQL = cSQL & " SCHED_LastRun=" & MySQLDateFormatNullable(SCHED_LastRun) & ","
                cSQL = cSQL & " SCHED_NextRun=" & MySQLDateFormatNullable(SCHED_NextRun) & ","
                cSQL = cSQL & " SCHED_StartTime=" & MySQLDateFormatNullable(SCHED_StartTime) & ","
                cSQL = cSQL & " SCHED_Days=" & SCHED_Days & ","
                cSQL = cSQL & " SCHED_RunBefore='" & RemoveInject(SCHED_RunBefore) & "',"
                cSQL = cSQL & " SCHED_RunAfter='" & RemoveInject(SCHED_RunAfter) & "',"
                cSQL = cSQL & " SCHED_Active=" & SCHED_Active & ","
                cSQL = cSQL & " SCHED_Internet_FTP_Profile='" & SCHED_Internet_FTP_Profile & "',"
                cSQL = cSQL & " SCHED_Internet_FTP_Folder='" & RemoveInject(SCHED_Internet_FTP_Folder) & "',"
                cSQL = cSQL & " SCHED_Internet_Email_Profile='" & RemoveInject(SCHED_Internet_Email_Profile) & "',"
                cSQL = cSQL & " SCHED_IncludePics=" & IIf(SCHED_IncludePics, 1, 0)
                cSQL = cSQL & " WHERE SCHED_Code='" & cSCHED_Code & "'"
            Else
                'insert
                Dim cNewCode = GenerateID(oDLSQLSERVER, "tblSTIService_schedule", "SCHED_Code")
                cSQL = "INSERT INTO tblSTIService_schedule (SCHED_Code,SCHED_Name,SCHED_Type,SCHED_Action,SCHED_LastRun,SCHED_NextRun,SCHED_StartTime,SCHED_Days,SCHED_RunBefore,SCHED_RunAfter,SCHED_Active,SCHED_Internet_FTP_Profile,SCHED_Internet_FTP_Folder,SCHED_Internet_Email_Profile,SCHED_IncludePics)"
                cSQL = cSQL & " VALUES ("
                cSQL = cSQL & " '" & cNewCode & "',"
                cSQL = cSQL & " '" & RemoveInject(cSaveAsProfName) & "',"
                cSQL = cSQL & " " & SCHED_Type & ","
                cSQL = cSQL & " '" & RemoveInject(SCHED_Action) & "',"
                cSQL = cSQL & " " & MySQLDateFormatNullable(SCHED_LastRun) & ","
                cSQL = cSQL & " " & MySQLDateFormatNullable(SCHED_NextRun) & ","
                cSQL = cSQL & " " & MySQLDateFormatNullable(SCHED_StartTime) & ","
                cSQL = cSQL & " " & SCHED_Days & ","
                cSQL = cSQL & " '" & RemoveInject(SCHED_RunBefore) & "',"
                cSQL = cSQL & " '" & RemoveInject(SCHED_RunAfter) & "',"
                cSQL = cSQL & " " & SCHED_Active & ","
                cSQL = cSQL & " '" & SCHED_Internet_FTP_Profile & "',"
                cSQL = cSQL & " '" & RemoveInject(SCHED_Internet_FTP_Folder) & "',"
                cSQL = cSQL & " '" & RemoveInject(SCHED_Internet_Email_Profile) & "',"
                cSQL = cSQL & " " & IIf(SCHED_IncludePics, 1, 0)
                cSQL = cSQL & ")"

                'refresh class properties
                cSCHED_Code = cNewCode
            End If
            bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL)
            Return bRetVal
        End Function

        'DELETE the profile given by <cProfCode>
        'IF No parameter is given and there is a valid profile loaded, then the currently loaded profile will be deleted.
        Public Function Delete(Optional ByVal pSCHED_Code As String = "") As Boolean
            Dim bRetVal As Boolean = False
            If pSCHED_Code = "" Then
                pSCHED_Code = cSCHED_Code
            End If
            If pSCHED_Code <> "" Then
                bRetVal = oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_schedule WHERE SCHED_Code='" & pSCHED_Code & "'")
            End If
            Return bRetVal
        End Function

        Private Function Load() As Boolean
            Dim dr As DataRow
            Dim dt As DataTable = GetDataTable("SCHED", cSCHED_Code)
            Dim bRetVal As Boolean = False
            If Not IsNothing(dt) AndAlso dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                'load profile
                SCHED_Name = NullToString(dr.Item("SCHED_Name"))
                SCHED_Type = NullToZero(dr.Item("SCHED_Type"))
                SCHED_Action = NullToString(dr.Item("SCHED_Action"))
                SCHED_LastRun = NullToDate(dr.Item("SCHED_LastRun"))
                SCHED_NextRun = NullToDate(dr.Item("SCHED_NextRun"))
                SCHED_StartTime = NullToDate(dr.Item("SCHED_StartTime"))
                SCHED_Days = NullToZero(dr.Item("SCHED_Days"))
                SCHED_RunBefore = NullToString(dr.Item("SCHED_RunBefore"))
                SCHED_RunAfter = NullToString(dr.Item("SCHED_RunAfter"))
                SCHED_Active = NullToZero(dr.Item("SCHED_Active"))
                SCHED_Internet_FTP_Profile = NullToString(dr.Item("SCHED_Internet_FTP_Profile"))
                SCHED_Internet_FTP_Folder = NullToString(dr.Item("SCHED_Internet_FTP_Folder"))
                SCHED_Internet_Email_Profile = NullToString(dr.Item("SCHED_Internet_Email_Profile"))
                SCHED_IncludePics = NullToZero(dr.Item("SCHED_IncludePics"))
                bRetVal = True
            End If
            Return bRetVal
        End Function
    End Class
#End Region

#Region "Profile Class"

    'Export Profile
    Public Class oProfile
        Public Code As String 'only used to returning the value for LOADED or SAVED profiles. DOES NOT DICTATE the record ID used in saving or loading.
        Public Name As String
        Public Comment As String
        Public ExpFolder As String


        'FUNCTION : Retrieves a profile record from the DB into the class instance
        Public Function Load(cProfCode As String) As Boolean
            Dim dr As DataRow
            Dim dt As DataTable = GetDataTable("PROFILE_MATCH", cProfCode)
            Dim bRetVal As Boolean = False
            If Not IsNothing(dt) AndAlso dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                'load profile
                Code = cProfCode
                Name = NullToString(dr.Item("prof_name"))
                ExpFolder = NullToString(dr.Item("prof_expfolder"))
                Comment = NullToString(dr.Item("prof_comment"))
                bRetVal = True
            End If
            Return bRetVal
        End Function


        'FUNCTION : Saves data stored in the class to a profile table in MPSDE
        'NOTE: THis method ALWAYS looks for the first matching NAME in the profile table and saves into that record. IF NO RECORD
        '      is found, then a NEW PROFILE RECORD is created and the [Code] value is updated accordingly
        Public Function Save(ByVal cSaveAsProfName As String) As Boolean
            Dim cSQL As String = ""
            Dim bRetVal As Boolean = False
            Dim cOldID As String = ""
            cOldID = oDLSQLSERVER.DLookUp("prof_code", "tblSTIService_profile", "prof_name='" & RemoveInject(cSaveAsProfName) & "'")
            If cOldID <> "" Then
                'update
                Code = cOldID
                cSQL = "UPDATE tblSTIService_profile SET"
                cSQL = cSQL & " prof_comment='" & RemoveInject(Comment) & "',"
                cSQL = cSQL & " prof_expfolder='" & ExpFolder & "'"
                cSQL = cSQL & " WHERE prof_code='" & RemoveInject(cOldID) & "'"
            Else
                'insert
                Dim cNewCode = GenerateID(oDLSQLSERVER, "tblSTIService_profile", "prof_code")
                cSQL = "INSERT INTO tblSTIService_profile (prof_code,prof_name,prof_comment,prof_expfolder)"
                cSQL = cSQL & " VALUES ("
                cSQL = cSQL & " '" & cNewCode & "',"
                cSQL = cSQL & " '" & RemoveInject(cSaveAsProfName) & "',"
                cSQL = cSQL & " '" & RemoveInject(Comment) & "',"
                cSQL = cSQL & " '" & ExpFolder & "'"
                cSQL = cSQL & ")"

                'refresh class properties
                Code = cNewCode
            End If
            bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL)
            Return bRetVal
        End Function

        'DELETE the profile given by <cProfCode>
        Public Function Delete(ByVal cProfCode As String) As Boolean
            Return oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_profile WHERE prof_code='" & NullToAny(cProfCode) & "'")
        End Function

    End Class
#End Region

#Region "Email Class (SMTP / POP3)"
    Public Class oEMAIL
        Private cINET_Code As String = ""
        Public INET_ProfileName As String = ""
        Public INET_User As String = ""
        Public INET_Pwd As String = ""
        Public INET_Host As String = "smtp.your-host.com"
        Public INET_Port As Integer = 25
        Public INET_UseSSL As Boolean = False
        Public INET_TLS As Boolean = False
        Public INET_SPA As Boolean = False
        Public INET_EmailType As Integer = 0 ' 0 for SMTP, 1 for POP3
        Public SMTP_SenderEmail As String = ""

        'message 
        Public cMsg_To As String
        Public cmsg_To_FriendlyName As String
        Public cMsg_Subj As String
        Public cMsg_Body As String


        Public Property INET_Code As String
            Get
                Return cINET_Code
            End Get
            Set(value As String)
                cINET_Code = value
                Load()
            End Set
        End Property

        Public Function Save(ByVal cSaveAsProfName As String) As Boolean
            Dim cSQL As String = ""
            Dim bRetVal As Boolean = False
            Dim cOldID As String = ""
            cOldID = oDLSQLSERVER.DLookUp("INET_Code", "tblSTIService_internet_settings", "INET_ProfileName='" & RemoveInject(cSaveAsProfName) & "'")
            If cOldID <> "" Then
                'update
                cINET_Code = cOldID
                cSQL = "UPDATE tblSTIService_internet_settings SET"
                cSQL = cSQL & " INET_ProfileName='" & RemoveInject(cSaveAsProfName) & "',"
                cSQL = cSQL & " INET_User='" & RemoveInject(INET_User) & "',"
                cSQL = cSQL & " INET_Pwd='" & sysMpsUserPassword("ENCRYPT", RemoveInject(INET_Pwd)) & "',"
                cSQL = cSQL & " INET_Port=" & INET_Port & ","
                cSQL = cSQL & " SMTP_SenderEmail='" & RemoveInject(SMTP_SenderEmail) & "',"
                cSQL = cSQL & " INET_Host='" & RemoveInject(INET_Host) & "',"
                cSQL = cSQL & " INET_UseSSL=" & IIf(INET_UseSSL, 1, 0) & ","
                cSQL = cSQL & " INET_TLS=" & IIf(INET_TLS, 1, 0) & ","
                cSQL = cSQL & " INET_SPA=" & IIf(INET_SPA, 1, 0) & ","
                cSQL = cSQL & " EMAIL_TYPE=" & INET_EmailType
                cSQL = cSQL & " WHERE INET_Code='" & cINET_Code & "'"
            Else
                'insert
                Dim cNewCode = GenerateID(oDLSQLSERVER, "tblSTIService_internet_settings", "INET_Code")
                cSQL = "INSERT INTO tblSTIService_internet_settings (INET_Code,INET_ProfileName,INET_User,INET_Pwd,SMTP_SenderEmail,INET_Host,INET_Port,INET_Type,INET_UseSSL,INET_TLS,INET_SPA,EMAIL_TYPE)"
                cSQL = cSQL & " VALUES ("
                cSQL = cSQL & " '" & cNewCode & "',"
                cSQL = cSQL & " '" & RemoveInject(cSaveAsProfName) & "',"
                cSQL = cSQL & " '" & RemoveInject(INET_User) & "',"
                cSQL = cSQL & " '" & sysMpsUserPassword("ENCRYPT", RemoveInject(INET_Pwd)) & "',"
                cSQL = cSQL & " '" & RemoveInject(SMTP_SenderEmail) & "',"
                cSQL = cSQL & " '" & RemoveInject(INET_Host) & "',"
                cSQL = cSQL & " " & INET_Port & ","
                cSQL = cSQL & " " & INET_Type.SMTP & ","
                cSQL = cSQL & " " & IIf(INET_UseSSL, 1, 0) & ","
                cSQL = cSQL & " " & IIf(INET_TLS, 1, 0) & ","
                cSQL = cSQL & " " & IIf(INET_SPA, 1, 0) & ","
                cSQL = cSQL & " " & INET_EmailType
                cSQL = cSQL & ")"

                'refresh class properties
                cINET_Code = cNewCode
            End If
            bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL)
            Return bRetVal
        End Function

        'DELETE the profile given by <cProfCode>
        'IF No parameter is given and there is a valid profile loaded, then the currently loaded profile will be deleted.
        Public Function Delete(Optional ByVal pINET_Code As String = "") As Boolean
            Dim bRetVal As Boolean = False
            If pINET_Code = "" Then
                pINET_Code = cINET_Code
            End If
            If pINET_Code <> "" Then
                bRetVal = oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_internet_settings WHERE INET_Code='" & pINET_Code & "'")
            End If
            Return bRetVal
        End Function

        Private Function Load() As Boolean
            Dim dr As DataRow
            Dim dt As DataTable = GetDataTable("INET_MATCH", cINET_Code)
            Dim bRetVal As Boolean = False
            If Not IsNothing(dt) AndAlso dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                'load profile   
                INET_ProfileName = NullToString(dr.Item("INET_ProfileName"))
                INET_User = NullToString(dr.Item("INET_User"))
                INET_Pwd = sysMpsUserPassword("DECRYPT", NullToString(dr.Item("INET_Pwd"))) 'use decrypted field
                INET_Host = NullToString(dr.Item("INET_Host"))
                INET_Port = NullToZero(dr.Item("INET_Port"))
                SMTP_SenderEmail = NullToString(dr.Item("SMTP_SenderEmail"))
                INET_UseSSL = NullToZero(dr.Item("INET_UseSSL"))
                INET_TLS = NullToZero(dr.Item("INET_TLS"))
                INET_SPA = NullToZero(dr.Item("INET_SPA"))
                INET_EmailType = NullToZero(dr.Item("EMAIL_TYPE"))
                bRetVal = True
            End If
            Return bRetVal
        End Function

        Public Function SendMail(Optional ByRef cErr As String = "") As Boolean
            Dim bSuccess As Boolean = False
            Dim mailman As New Chilkat.MailMan()
            '  Any string argument automatically begins the 30-day trial.
            Dim success As Boolean
            success = mailman.UnlockComponent("SPCTASMAILQ_8962DBBgnC9s")

            If (success <> True) Then
                cErr = "Component unlock failed"
                Return bSuccess
            End If

            '  Use the GMail SMTP server
            mailman.SmtpHost = INET_Host
            mailman.SmtpPort = INET_Port
            'mailman.SmtpSsl = True
            mailman.SmtpSsl = INET_UseSSL
            mailman.StartTLS = INET_TLS

            '  Set the SMTP login/password.
            mailman.SmtpUsername = INET_User
            mailman.SmtpPassword = INET_Pwd

            '  Create a new email object
            Dim email As New Chilkat.Email()

            email.Subject = cMsg_Subj
            email.Body = cMsg_Body
            email.From = SMTP_SenderEmail

            Dim cToList As String = RemoveQuotes(cMsg_To)
            Dim cNameList As String = RemoveQuotes(cmsg_To_FriendlyName)
            Dim nCtr As Integer = 0
            Dim cEmail As String = ""
            Dim cName As String = ""
            For nCtr = 1 To CountItemDelimited(cToList, ",")
                cEmail = GetItemDelimited(cToList, nCtr, ",")
                cName = GetItemDelimited(cNameList, nCtr, ",")
                email.AddTo(IIf(NullToString(cName) = "", cEmail, cName), cEmail)
            Next
            success = mailman.SendEmail(email)
            If (success <> True) Then
                cErr = mailman.LastErrorText
                Return bSuccess
            Else
                bSuccess = True
            End If

            Return bSuccess
        End Function

    End Class
#End Region

#Region "FTP CLass"
    Public Class oFTP
        Private cINET_Code As String = ""
        Public INET_ProfileName As String = ""
        Public INET_User As String = ""
        Public INET_Pwd As String = ""
        Public INET_Host As String = "ftp.your-host.com"
        Public INET_AutoRemoveFiles As Boolean = False
        Public FTP_ConnectionTimeout As Integer = 60
        Public FTP_UsePassive As Boolean = False
        Public FTP_AutoFeat As Boolean = True
        Public INET_Port As Integer = 21
        Public INET_UseSSL As Boolean = False
        Public INET_TLS As Boolean = False
        Private oChilkatFTP As New Chilkat.Ftp2()

        Public Property INET_Code As String
            Get
                Return cINET_Code
            End Get
            Set(value As String)
                cINET_Code = value
                Load()
            End Set
        End Property

        Public Function FTP_Connect(ByVal cRemoteFolder As String, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal nRetryTimes As Integer = 10) As Boolean
            Dim bSuccess As Boolean = False
            Dim nRetry As Integer = 0

            Do While Not bSuccess And nRetry < nRetryTimes
                cErr = ""
                nRetry = nRetry + 1
                Try
                    If oChilkatFTP.IsConnected Then
                        oChilkatFTP.Disconnect()
                    End If
                Catch ex As Exception
                End Try

                oChilkatFTP = New Chilkat.Ftp2()

                '  Any string unlocks the component for the 1st 30-days.
                bSuccess = oChilkatFTP.UnlockComponent("SPCTASFTP_SacUFGpW7Dne")
                If Not bSuccess Then
                    cErr = oChilkatFTP.LastErrorText
                End If

                UpdateStatus(0, "Connecting to [" & INET_Host & "] Attempt " & nRetry & "/" & nRetryTimes, "FTP", bShowProgressBar)
                If bSuccess Then
                    oChilkatFTP.Hostname = INET_Host
                    oChilkatFTP.Username = INET_User
                    oChilkatFTP.Password = INET_Pwd
                    oChilkatFTP.ConnectTimeout = FTP_ConnectionTimeout
                    oChilkatFTP.Passive = FTP_UsePassive
                    oChilkatFTP.AutoOptsUtf8 = True
                    oChilkatFTP.AutoFeat = FTP_AutoFeat
                    oChilkatFTP.Port = INET_Port
                    oChilkatFTP.Ssl = INET_UseSSL
                    oChilkatFTP.AuthTls = INET_TLS

                    '  Connect and login to the FTP server.
                    bSuccess = oChilkatFTP.Connect()
                    If Not bSuccess Then
                        cErr = oChilkatFTP.LastErrorText
                    End If
                End If
            Loop

            UpdateStatus(0, "Change Remote Dir to [" & cRemoteFolder & "]", "FTP", bShowProgressBar)
            If bSuccess Then
                '  Does the "temp" directory exist?
                If cRemoteFolder.Length > 0 Then
                    bSuccess = oChilkatFTP.ChangeRemoteDir(cRemoteFolder)
                    If Not bSuccess Then
                        cErr = oChilkatFTP.LastErrorText
                    End If
                End If
            End If

            Return bSuccess
        End Function

        Public Sub FTP_Disconnect()
            Try
                oChilkatFTP.Disconnect()
            Catch ex As Exception

            End Try
        End Sub

        Public Function FTP_CreateRemoteDir(ByVal cDirName As String, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal nRetryTimes As Integer = 10) As Boolean
            Dim bSuccess As Boolean = False
            Dim nRetry As Integer = 0

            If oChilkatFTP.IsConnected Then

                Do While Not bSuccess And nRetry < nRetryTimes
                    nRetry = nRetry + 1
                    UpdateStatus(0, "Creating Folder [" & cDirName & "] Attempt " & nRetry & "/" & nRetryTimes, "FTP", bShowProgressBar)
                    bSuccess = oChilkatFTP.CreateRemoteDir(cDirName)
                    If Not bSuccess Then
                        cErr = oChilkatFTP.LastErrorText
                    Else
                        cErr = ""
                    End If
                Loop

            Else
                cErr = "No connection"
            End If
            Return bSuccess
        End Function

        Public Function FTP_ChangeRemoteDir(ByVal cDirName As String, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal nRetryTimes As Integer = 10) As Boolean
            Dim bSuccess As Boolean = False
            Dim nRetry As Integer = 0

            If oChilkatFTP.IsConnected Then
                Do While Not bSuccess And nRetry < nRetryTimes
                    nRetry = nRetry + 1
                    UpdateStatus(0, "Changing Folder [" & cDirName & "] Attempt " & nRetry & "/" & nRetryTimes, "FTP", bShowProgressBar)
                    bSuccess = oChilkatFTP.ChangeRemoteDir(cDirName)
                    If Not bSuccess Then
                        cErr = oChilkatFTP.LastErrorText
                    Else
                        cErr = ""
                    End If
                Loop

            Else
                cErr = "No connection"
            End If
            Return bSuccess
        End Function

        Public Function FTP_PutFileFromTextData(ByVal cTextContents As String, ByVal cRemoteFileName As String, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal nRetryTimes As Integer = 10) As Boolean
            Dim bSuccess As Boolean = False
            Dim nRetry As Integer = 0

            If oChilkatFTP.IsConnected Then
                Do While Not bSuccess And nRetry < nRetryTimes
                    nRetry = nRetry + 1
                    UpdateStatus(0, "Uploading File [" & cRemoteFileName & "] Attempt " & nRetry & "/" & nRetryTimes, "FTP", bShowProgressBar)
                    bSuccess = oChilkatFTP.PutFileFromTextData(cRemoteFileName, cTextContents, "windows-1252")
                    If Not bSuccess Then
                        cErr = oChilkatFTP.LastErrorText
                    Else
                        cErr = ""
                    End If
                Loop

            Else
                cErr = "No connection"
            End If
            Return bSuccess
        End Function

        Public Function FTP_PutFile(ByVal cLocalFile As String, ByVal cRemoteFileName As String, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal nRetryTimes As Integer = 10) As Boolean
            Dim bSuccess As Boolean = False
            Dim nRetry As Integer = 0

            If oChilkatFTP.IsConnected Then

                Do While Not bSuccess And nRetry < nRetryTimes
                    nRetry = nRetry + 1
                    UpdateStatus(0, "Uploading File [" & cRemoteFileName & "] Attempt " & nRetry & "/" & nRetryTimes, "FTP", bShowProgressBar)
                    bSuccess = oChilkatFTP.PutFile(cLocalFile, cRemoteFileName)
                    If Not bSuccess Then
                        cErr = oChilkatFTP.LastErrorText
                    End If
                Loop

            Else
                cErr = "No connection"
            End If
            Return bSuccess
        End Function

        Public Function FTP_GetFileToTextData(ByRef cTextContents As String, ByVal cFileName As String, Optional ByVal cUploadContentIfMissing As String = "", Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True) As Boolean
            Dim cItem As String = ""
            Dim bSuccess As Boolean = True
            Dim nCtr As Integer

            If oChilkatFTP.IsConnected Then
                UpdateStatus(0, "Check File [" & cFileName & "]", "FTP", bShowProgressBar)
                oChilkatFTP.ListPattern = cFileName
                nCtr = oChilkatFTP.NumFilesAndDirs
                If (nCtr <= 0) Then
                    If NullToString(cUploadContentIfMissing) = "" Then
                        bSuccess = False
                        cErr = oChilkatFTP.LastErrorText
                    Else
                        'upload file 
                        UpdateStatus(0, "Uploading File [" & cFileName & "]", "FTP", bShowProgressBar)
                        If bSuccess Then
                            ' Upload file.
                            bSuccess = FTP_PutFileFromTextData(cFileName, cUploadContentIfMissing, cErr, bShowProgressBar)
                        End If
                    End If
                Else
                    UpdateStatus(0, "Get File [" & cFileName & "]", "FTP", bShowProgressBar)
                    If bSuccess Then
                        ' Download file to memory.
                        cTextContents = oChilkatFTP.GetRemoteFileTextData(cFileName)
                        If (cTextContents = vbNullString) Then
                            bSuccess = False
                            cErr = oChilkatFTP.LastErrorText
                        End If
                    End If
                End If
            Else
                bSuccess = False
                cErr = "No connection"
            End If

            Return bSuccess
        End Function

        'DOWNLOAD a <cFileName> to <cLocalFolder>
        ' <cFileName> can be a pattern (like *.zip), and when <bGetFirstPatternMatch> = TRUE, the FIRST FILE matching the pattern will be
        ' downloaded, and the filename will be returned via <cFileName>
        ' <nErrtype> - returns type of problem
        '
        'No_Error = 0
        'No_Conection = 1
        'Missing_File = 2
        'Missing_File_Upload_Failed = 3
        'Existing_File_Delete_Failed = 4
        'File_Download_Failed = 5
        'Hash_Mismatch = 6
        '   
        Public Function FTP_GetFile(ByVal cLocalFolder As String, ByRef cFileName As String, Optional ByVal cUploadFileIfMissing As String = "", Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal bGetFirstPatternMatch As Boolean = False, Optional ByRef nErrtype As GetFileErr = GetFileErr.No_Error, Optional ByVal CompareToHash As Byte() = Nothing) As Boolean
            Dim cItem As String = ""
            Dim bSuccess As Boolean = True
            Dim nCtr As Integer
            Dim cPattern As String = ""

            If oChilkatFTP.IsConnected Then
                UpdateStatus(0, "Check File [" & cFileName & "]", "FTP", bShowProgressBar)
                oChilkatFTP.ListPattern = cFileName
                nCtr = oChilkatFTP.NumFilesAndDirs
                If (nCtr <= 0) Then
                    nErrtype = GetFileErr.Missing_File
                    If NullToString(cUploadFileIfMissing) = "" Then
                        bSuccess = False
                        cErr = oChilkatFTP.LastErrorText
                    Else
                        'upload file 
                        UpdateStatus(0, "Uploading File [" & cFileName & "]", "FTP", bShowProgressBar)
                        If bSuccess Then
                            ' Upload file.
                            bSuccess = oChilkatFTP.PutFile(cUploadFileIfMissing, cFileName)
                            If Not bSuccess Then
                                nErrtype = GetFileErr.Missing_File_Upload_Failed
                                cErr = oChilkatFTP.LastErrorText
                            End If
                        End If
                    End If
                Else
                    UpdateStatus(0, "Get File [" & cFileName & "]", "FTP", bShowProgressBar)
                    If bSuccess Then
                        If bGetFirstPatternMatch Then
                            'get filename of first file match and download that
                            cPattern = cFileName
                            cFileName = oChilkatFTP.GetFilename(0)
                        End If

                        'check if folder exists, if it doesn't then create it
                        'CAN CREATE MULTIPLE NESTED FOLDERS!!! e.g. if neither folder "a" nor "b" exists in "c:\a\b", then
                        'this will create both nested folders.
                        Try
                            If Not System.IO.Directory.Exists(cLocalFolder) Then
                                Try
                                    System.IO.Directory.CreateDirectory(cLocalFolder)
                                Catch ex As Exception
                                    bSuccess = False
                                    nErrtype = GetFileErr.MissingFolder
                                    cErr = ex.Message & ". Error creating directory: '" & cLocalFolder & "'"
                                End Try
                            End If
                        Catch ex As Exception
                            bSuccess = False
                            nErrtype = GetFileErr.MissingFolder
                            cErr = ex.Message & ". Directory Inaccessible: '" & cLocalFolder & "'"
                        End Try

                        If bSuccess Then
                            'check if file exists
                            If FileExists(CleanPath(cLocalFolder) & cFileName) Then
                                Try
                                    System.IO.File.Delete(CleanPath(cLocalFolder) & cFileName)
                                Catch ex As Exception
                                    nErrtype = GetFileErr.Existing_File_Delete_Failed
                                End Try
                            End If

                            ' Download file.
                            Dim xcount As Integer = 1
                            For xcount = 1 To 10
                                bSuccess = oChilkatFTP.GetFile(cFileName, CleanPath(cLocalFolder) & cFileName)
                                If bSuccess Then
                                    Exit For
                                End If
                            Next



                            If Not bSuccess Then
                                nErrtype = GetFileErr.File_Download_Failed
                                cErr = oChilkatFTP.LastErrorText
                            Else
                                'comment out by elmer20150222 Reason. Do not check file hash.. just download the file
                                'check Hash 
                                'If Not (CompareToHash Is Nothing) Then
                                '    Dim oHash As Byte() = ComputeFileHash(CleanPath(cLocalFolder) & cFileName)
                                '    If Not (oHash.SequenceEqual(CompareToHash)) Then
                                '        bSuccess = False
                                '        nErrtype = GetFileErr.Hash_Mismatch
                                '        cErr = "Downloaded File Hash: [" & ByteArrayToHex(oHash) & "] <> Hash on Export File: [" & ByteArrayToHex(CompareToHash) & "]"
                                '    End If
                                'End If
                            End If
                        End If

                    End If
                End If
            Else
                nErrtype = GetFileErr.No_Conection
                bSuccess = False
                cErr = "No connection"
            End If

            If cErr <> "" Then
                cErr = LogDate(True) & " >> " & cErr
            End If
            Return bSuccess
        End Function

        'added by elmer
        Public Function FTP_DeleteOneFile(ByVal cFileName As String, Optional ByVal bShowProgressBar As Boolean = True, Optional ByRef cErr As String = "") As Boolean
            Dim cItem As String = ""
            Dim bSuccess As Boolean = True
            Dim cPattern As String = ""

            If oChilkatFTP.IsConnected Then
                UpdateStatus(0, "Deleting File [" & cFileName & "]", "FTP", bShowProgressBar)
                bSuccess = oChilkatFTP.DeleteRemoteFile(cFileName)
                If Not bSuccess Then
                    cErr = oChilkatFTP.LastErrorText
                End If
            Else
                bSuccess = False
                cErr = "No connection"
            End If

            If cErr <> "" Then
                cErr = LogDate(True) & " >> " & cErr
            End If
            Return bSuccess
        End Function

        Public Function FTP_GetCurrDir() As String
            Dim cRetVal As String = ""
            If oChilkatFTP.IsConnected Then
                cRetVal = oChilkatFTP.GetCurrentRemoteDir
            Else
                cRetVal = "No FTP connection"
            End If
            Return cRetVal
        End Function

        Public Function FTP_Dir(Optional ByVal cFileSpec As String = "*.*", Optional ByRef nNumFound As Long = 0, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal bIsFolder As Boolean = False) As Boolean
            Dim bSuccess As Boolean = True
            Dim bIsDir As Boolean = False
            Dim nCtr As Integer = 0

            If oChilkatFTP.IsConnected Then
                If Not bIsFolder Then
                    'look for file
                    UpdateStatus(0, "Check File Exist [" & cFileSpec & "]", "FTP", bShowProgressBar)
                    oChilkatFTP.ListPattern = cFileSpec
                    nNumFound = oChilkatFTP.NumFilesAndDirs
                    If (nNumFound < 0) Then
                        bSuccess = False
                        cErr = oChilkatFTP.LastErrorText
                    End If
                Else
                    'look for folder
                    UpdateStatus(0, "Check Folder Exist [" & cFileSpec & "]", "FTP", bShowProgressBar)
                    oChilkatFTP.ListPattern = "*" 'list all files/folders
                    nNumFound = oChilkatFTP.NumFilesAndDirs
                    If (nNumFound < 0) Then
                        bSuccess = False
                        cErr = oChilkatFTP.LastErrorText
                    Else
                        bSuccess = False
                        cErr = "No folders found matching '" & cFileSpec & "' on " & oChilkatFTP.GetCurrentRemoteDir
                        For nCtr = 0 To (nNumFound - 1)
                            If oChilkatFTP.GetIsDirectory(nCtr) Then
                                If UCase(cFileSpec) = UCase(oChilkatFTP.GetFilename(nCtr)) Then
                                    bSuccess = True
                                    cErr = ""
                                End If
                            End If
                        Next
                    End If
                End If

            Else
                bSuccess = False
                cErr = "No connection"
            End If

            Return bSuccess
        End Function

        Public Function FTP_DeleteFiles(Optional ByVal cFileSpec As String = "*.EX2", Optional ByRef nNumDeleted As Long = 0, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True) As Boolean
            Dim bSuccess As Boolean = True

            If oChilkatFTP.IsConnected Then
                '  Delete all files with filenames matching "ftp_*.asp"
                UpdateStatus(0, "Delete Files [" & cFileSpec & "]", "FTP", bShowProgressBar)
                nNumDeleted = oChilkatFTP.DeleteMatching(cFileSpec)
                If (nNumDeleted < 0) Then
                    cErr = oChilkatFTP.LastErrorText
                    bSuccess = False
                End If
            Else
                bSuccess = False
                cErr = "No connection"
            End If

            Return bSuccess
        End Function


        Public Function Save(ByVal cSaveAsProfName As String) As Boolean
            Dim cSQL As String = ""
            Dim bRetVal As Boolean = False
            Dim cOldID As String = ""
            cOldID = oDLSQLSERVER.DLookUp("INET_Code", "tblSTIService_internet_settings", "INET_ProfileName='" & RemoveInject(cSaveAsProfName) & "' AND INET_Type=" & INET_Type.FTP)
            If cOldID <> "" Then
                'update
                cINET_Code = cOldID
                cSQL = "UPDATE tblSTIService_internet_settings SET"
                cSQL = cSQL & " INET_ProfileName='" & RemoveInject(cSaveAsProfName) & "',"
                cSQL = cSQL & " INET_User='" & RemoveInject(INET_User) & "',"
                cSQL = cSQL & " INET_Pwd='" & sysMpsUserPassword("ENCRYPT", RemoveInject(INET_Pwd)) & "',"
                cSQL = cSQL & " INET_AutoRemoveFiles=" & IIf(INET_AutoRemoveFiles, 1, 0) & ","
                cSQL = cSQL & " FTP_ConnectionTimeout=" & FTP_ConnectionTimeout & ","
                cSQL = cSQL & " INET_Host='" & RemoveInject(INET_Host) & "',"
                cSQL = cSQL & " FTP_UsePassive=" & IIf(FTP_UsePassive, 1, 0) & ","
                cSQL = cSQL & " FTP_AutoFeat=" & IIf(FTP_AutoFeat, 1, 0) & ","
                cSQL = cSQL & " INET_Port=" & INET_Port & ","
                cSQL = cSQL & " INET_UseSSL=" & IIf(INET_UseSSL, 1, 0) & ","
                cSQL = cSQL & " INET_TLS=" & IIf(INET_TLS, 1, 0)
                cSQL = cSQL & " WHERE INET_Code='" & cINET_Code & "'"
            Else
                'insert
                Dim cNewCode = GenerateID(oDLSQLSERVER, "tblSTIService_internet_settings", "INET_Code")
                cSQL = "INSERT INTO tblSTIService_internet_settings (INET_Code,INET_ProfileName,INET_User,INET_Pwd,INET_AutoRemoveFiles,FTP_ConnectionTimeout,INET_Host,FTP_UsePassive,FTP_AutoFeat,INET_Port,INET_UseSSL,INET_Type,INET_TLS)"
                cSQL = cSQL & " VALUES ("
                cSQL = cSQL & " '" & cNewCode & "',"
                cSQL = cSQL & " '" & RemoveInject(cSaveAsProfName) & "',"
                cSQL = cSQL & " '" & RemoveInject(INET_User) & "',"
                cSQL = cSQL & " '" & sysMpsUserPassword("ENCRYPT", RemoveInject(INET_Pwd)) & "',"
                cSQL = cSQL & " " & IIf(INET_AutoRemoveFiles, 1, 0) & ","
                cSQL = cSQL & " " & FTP_ConnectionTimeout & ","
                cSQL = cSQL & " '" & RemoveInject(INET_Host) & "',"
                cSQL = cSQL & " " & IIf(FTP_UsePassive, 1, 0) & ","
                cSQL = cSQL & " " & IIf(FTP_AutoFeat, 1, 0) & ","
                cSQL = cSQL & " " & INET_Port & ","
                cSQL = cSQL & " " & IIf(INET_UseSSL, 1, 0) & ","
                cSQL = cSQL & " " & INET_Type.FTP & ","
                cSQL = cSQL & " " & IIf(INET_TLS, 1, 0)
                cSQL = cSQL & ")"

                'refresh class properties
                cINET_Code = cNewCode
            End If
            bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL)
            Return bRetVal
        End Function

        'DELETE the profile given by <cProfCode>
        'IF No parameter is given and there is a valid profile loaded, then the currently loaded profile will be deleted.
        Public Function Delete(Optional ByVal pINET_Code As String = "") As Boolean
            Dim bRetVal As Boolean = False
            If pINET_Code = "" Then
                pINET_Code = cINET_Code
            End If
            If pINET_Code <> "" Then
                bRetVal = oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_internet_settings WHERE INET_Code='" & pINET_Code & "'")
            End If
            Return bRetVal
        End Function

        Private Function Load() As Boolean
            Dim dr As DataRow
            Dim dt As DataTable = GetDataTable("INET_MATCH", cINET_Code)
            Dim bRetVal As Boolean = False
            If Not IsNothing(dt) AndAlso dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                'load profile
                INET_ProfileName = NullToString(dr.Item("INET_ProfileName"))
                INET_User = NullToString(dr.Item("INET_User"))
                INET_Pwd = sysMpsUserPassword("DECRYPT", NullToString(dr.Item("INET_Pwd"))) 'use decrypted field
                INET_Host = NullToString(dr.Item("INET_Host"))

                INET_AutoRemoveFiles = NullToZero(dr.Item("INET_AutoRemoveFiles"))
                FTP_ConnectionTimeout = NullToZero(dr.Item("FTP_ConnectionTimeout"))
                FTP_UsePassive = NullToZero(dr.Item("FTP_UsePassive"))

                FTP_AutoFeat = NullToZero(dr.Item("FTP_AutoFeat"))
                INET_Port = NullToZero(dr.Item("INET_Port"))
                INET_UseSSL = NullToZero(dr.Item("INET_UseSSL"))
                INET_TLS = NullToZero(dr.Item("INET_TLS"))
                bRetVal = True
            End If
            Return bRetVal
        End Function

    End Class
#End Region

#Region "Active Schedule"
    'RSA: Support functions for schedule class
    Public oActiveSchedules As New List(Of oSched)

    'ScheduleS ===============================================================
    Public Function Schedule_RunningCount() As Integer
        Dim nRet As Integer = 0
        Try
            nRet = oActiveSchedules.Count
        Catch ex As Exception
            nRet = 0
        End Try
        Return nRet
    End Function

    Public Sub Schedule_AddToRunning(oSched As oSched)
        Dim bExist As Boolean = False
        For Each oTmpSched In oActiveSchedules
            If oTmpSched.SCHED_Code = oSched.SCHED_Code Then
                'item already in the list
                bExist = True
                Exit For
            End If
        Next
        If Not bExist Then
            oActiveSchedules.Add(oSched)
        End If
    End Sub

    Public Sub Schedule_RemoveFromRunning(oSched As oSched)
        Try
            oActiveSchedules.Remove(oSched)
        Catch ex As Exception
        End Try
    End Sub

    Public Function Schedule_IsRunning(ByVal cSchedCode As String) As Boolean
        Dim bRetVal As Boolean = False
        If NullToString(cSchedCode) <> "" Then
            For Each oTmpSched In oActiveSchedules
                If oTmpSched.SCHED_Code = cSchedCode Then
                    bRetVal = True
                    Exit For
                End If
            Next
        End If
        Return bRetVal
    End Function

    Public Function Schedule_IsRunning(oSched As oSched) As Boolean
        Dim bRetVal As Boolean = False
        If NullToString(oSched.SCHED_Code) <> "" Then
            For Each oTmpSched In oActiveSchedules
                If oTmpSched.SCHED_Code = oSched.SCHED_Code Then
                    bRetVal = True
                    Exit For
                End If
            Next
        End If
        Return bRetVal
    End Function
#End Region

#Region "Active Transfer"
    'RSA: Support functions for transfer class
    Public oActiveTransfers As New List(Of oTransfer)

    'TRANSFERS ===============================================================
    Public Function Transfer_RunningCount() As Integer
        Dim nRet As Integer = 0
        Try
            nRet = oActiveTransfers.Count
        Catch ex As Exception
            nRet = 0
        End Try
        Return nRet
    End Function

    Public Sub Transfer_AddToRunning(oTr As oTransfer)
        Dim bExist As Boolean = False
        For Each oTmpTr In oActiveTransfers
            If oTmpTr.Transfer_Code = oTr.Transfer_Code Then
                'item already in the list
                bExist = True
                Exit For
            End If
        Next
        If Not bExist Then
            oActiveTransfers.Add(oTr)
        End If
    End Sub

    Public Sub Transfer_RemoveFromRunning(oTr As oTransfer)
        Try
            oActiveTransfers.Remove(oTr)
        Catch ex As Exception
        End Try
    End Sub

    Public Function Export_Transfer_Count(Optional ByVal bCountOnlyPrimaryFileUnSent As Boolean = True) As Integer
        Dim nRetVal As Integer = 0
        For Each oTmpTr In oActiveTransfers
            If oTmpTr.SendOrReceive = ActionType.Backup And IIf(bCountOnlyPrimaryFileUnSent, IIf(oTmpTr.TransferStatus = 0, True, False), True) Then
                nRetVal = nRetVal + 1
            End If
        Next
        Return nRetVal
    End Function

    Public Function Import_Transfer_Count() As Integer
        Dim nRetVal As Integer = 0
        For Each oTmpTr In oActiveTransfers
            If oTmpTr.SendOrReceive = ActionType.Restore Then
                nRetVal = nRetVal + 1
            End If
        Next
        Return nRetVal
    End Function

    Public Function Transfer_IsRunning(ByVal cTransferCode As String) As Boolean
        Dim bRetVal As Boolean = False
        If NullToString(cTransferCode) <> "" Then
            For Each oTmpTr In oActiveTransfers
                If oTmpTr.Transfer_Code = cTransferCode Then
                    bRetVal = True
                    Exit For
                End If
            Next
        End If
        Return bRetVal
    End Function

    Public Function Transfer_IsRunning(oTr As oTransfer) As Boolean
        Dim bRetVal As Boolean = False
        If NullToString(oTr.Transfer_Code) <> "" Then
            For Each oTmpTr In oActiveTransfers
                If oTmpTr.Transfer_Code = oTr.Transfer_Code Then
                    bRetVal = True
                    Exit For
                End If
            Next
        End If
        Return bRetVal
    End Function
#End Region

#Region "Transfer Class"
    Public Class oTransfer
        Public Shared bCancelAll As Boolean = False
        Private cTransfer_Code As String = ""
        Public RetrySeconds As Long = 60 'retry after 60 seconds. can be changed upon initiation of transfer class
        Public INET_Code As String = ""
        Public SCHED_Code As String = ""
        Public NextRun As Date? = Nothing
        Public SendOrReceive As ActionType
        Public RemoteFolder As String = ""
        Public MainLog As New StringBuilder("")
        Public TransferStatus As Integer = 0 '0-for processing, 1-main file sent/received, 2-main file and supplemental files (in tbl_filesync) have been sent
        Public LastStatus As String = ""
        Private cDataFile As String = ""
        Private cDataFileRelation As String = ""

        Public Property DataFile As String
            Get
                Return cDataFile
            End Get
            Set(value As String)
                cDataFile = value
                cDataFileRelation = ExtractFileNameOnly(cDataFile)
            End Set
        End Property

        Public ReadOnly Property DataFileRelation As String
            Get
                Return cDataFileRelation
            End Get
        End Property

        Public Property Transfer_Code As String
            Get
                Return cTransfer_Code
            End Get
            Set(value As String)
                cTransfer_Code = value
                Load()
            End Set
        End Property

        Public Function Save() As Boolean
            Dim cSQL As String = ""
            Dim cErr As String = ""
            Dim bRetVal As Boolean = False
            If NullToString(cTransfer_Code) <> "" Then
                'update
                cSQL = "UPDATE tblSTIService_transfers SET"
                cSQL = cSQL & " INET_Code='" & INET_Code & "',"
                cSQL = cSQL & " SCHED_Code='" & SCHED_Code & "',"
                cSQL = cSQL & " NextRun='" & MySQLDateValueNullable(NextRun) & "',"
                cSQL = cSQL & " SendOrReceive=" & SendOrReceive & ","
                cSQL = cSQL & " DataFile='" & RemoveQuotes(cDataFile) & "',"
                cSQL = cSQL & " MainLog='" & RemoveQuotes(MainLog.ToString) & "',"
                cSQL = cSQL & " DataFileRelation='" & cDataFileRelation & "',"
                cSQL = cSQL & " TransferStatus=" & TransferStatus & ","
                cSQL = cSQL & " LastStatus='" & LastStatus & "',"
                cSQL = cSQL & " RemoteFolder='" & RemoveQuotes(RemoteFolder) & "'"
                cSQL = cSQL & " WHERE Transfer_Code='" & cTransfer_Code & "'"

                bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL)
            Else
                'insert
                cTransfer_Code = GenerateID(oDLSQLSERVER, "tblSTIService_schedule", "SCHED_Code")
                cSQL = "INSERT INTO tblSTIService_transfers (Transfer_Code,INET_Code,SCHED_Code,NextRun,SendOrReceive,DataFile,MainLog,DataFileRelation,TransferStatus,LastStatus,RemoteFolder)"
                cSQL = cSQL & " VALUES ("
                cSQL = cSQL & "'" & cTransfer_Code & "',"
                cSQL = cSQL & "'" & INET_Code & "',"
                cSQL = cSQL & "'" & SCHED_Code & "',"
                cSQL = cSQL & "'" & MySQLDateValueNullable(NextRun) & "',"
                cSQL = cSQL & SendOrReceive & ","
                cSQL = cSQL & "'" & RemoveQuotes(cDataFile) & "',"
                cSQL = cSQL & "'" & RemoveQuotes(MainLog.ToString) & "',"
                cSQL = cSQL & "'" & RemoveQuotes(cDataFileRelation) & "',"
                cSQL = cSQL & TransferStatus & ","
                cSQL = cSQL & "'" & LastStatus & "',"
                cSQL = cSQL & "'" & RemoveQuotes(RemoteFolder) & "')"

                bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL)
            End If

            Return bRetVal
        End Function

        'DELETE the profile given by <cProfCode>
        'IF No parameter is given and there is a valid profile loaded, then the currently loaded profile will be deleted.
        Public Function Delete(Optional ByVal pTransfer_Code As String = "") As Boolean
            Dim bRetVal As Boolean = False
            Dim cDFileRelation As String = ""

            If pTransfer_Code = "" Then
                pTransfer_Code = cTransfer_Code
                cDFileRelation = cDataFileRelation
                Transfer_RemoveFromRunning(Me)
            Else
                Dim oTmpTransfer As New oTransfer
                oTmpTransfer.Transfer_Code = pTransfer_Code
                cDFileRelation = oTmpTransfer.DataFileRelation
            End If
            If pTransfer_Code <> "" Then
                bRetVal = oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_transfers WHERE Transfer_Code='" & pTransfer_Code & "'")
            End If
            Return bRetVal
        End Function

        Private Function Load() As Boolean
            Dim dr As DataRow
            Dim dt As DataTable = GetDataTable("TRANSFER", cTransfer_Code)
            Dim bRetVal As Boolean = False
            If Not IsNothing(dt) AndAlso dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                'load 
                INET_Code = NullToString(dr.Item("INET_Code"))
                SCHED_Code = NullToString(dr.Item("SCHED_Code"))
                NextRun = NullToDate(dr.Item("NextRun"))
                SendOrReceive = NullToZero(dr.Item("SendOrReceive"))
                DataFile = NullToString(dr.Item("DataFile"))
                MainLog.Clear()
                MainLog.Append(NullToString(dr.Item("MainLog")))
                RemoteFolder = NullToString(dr.Item("RemoteFolder"))
                bRetVal = True
            End If
            Return bRetVal
        End Function

        Public Sub Transfer_Async(Optional ByVal bShowProgress As Boolean = True)
            If Not Transfer_IsRunning(Me) And NullToString(Transfer_Code) <> "" Then
                'add to global running transfers
                Transfer_AddToRunning(Me)
                LastStatus = "In Process.."
                NextRun = DateAdd(DateInterval.Minute, 1, Now) 'add 1 minute to transfer time and save so that the service will not "discover" it again until 5 minutes have elapsed
                Save()

                Dim bwDoTransfer As BackgroundWorker = New BackgroundWorker
                bwDoTransfer.WorkerSupportsCancellation = True
                bwDoTransfer.WorkerReportsProgress = True
                'Assign UI events
                AddHandler bwDoTransfer.DoWork, AddressOf bwTransfer_DoWork
                AddHandler bwDoTransfer.RunWorkerCompleted, AddressOf bwTransfer_RunWorkerCompleted

                Dim bRetVal As Boolean = False
                Dim oParams As Object() = {bShowProgress}

                If Not bwDoTransfer.IsBusy = True Then
                    bwDoTransfer.RunWorkerAsync(oParams)
                End If
            End If
        End Sub

        Private Sub bwTransfer_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
            Transfer_RemoveFromRunning(Me)
        End Sub

        Private Sub bwTransfer_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
            Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
            Dim oParams As Object() = TryCast(e.Argument, Object())
            Dim bShowProgress As Boolean = oParams(0)

            Dim oFTP As New oFTP
            Dim cSQL As String = ""

            Dim oSched As New oSched
            Dim oProfile As New oProfile
            Dim cErr As String = ""
            Dim nFound As Long = 0
            Dim bSuccess As Boolean = True
            Dim nUploadCount As Long = 0
            Dim nDownloadCount As Long = 0
            Dim nCount As Long = 0

            ''get uploads folder
            'Dim cLocalUploadsFolder = CleanPath(GetConfig(oDLSQLSERVER, "ImagesPathDE", ""))
            'Dim cTmpLocalFolder As String = ""

            oSched.SCHED_Code = SCHED_Code
            oFTP.INET_Code = INET_Code

            'check for invalid transfer
            Select Case TransferStatus
                Case 0 'for processing
                    Select Case oSched.SCHED_Type
                        Case ActionType.Backup
                            'get export profile
                            oProfile.Load(oSched.SCHED_Action)
                            If Not FileExists(CleanPath(oProfile.ExpFolder) & cDataFileRelation) Then
                                Delete()
                                Exit Sub
                            End If
                    End Select
            End Select

            oFTP.FTP_Connect(oSched.SCHED_Internet_FTP_Folder, cErr, bShowProgress)
            

            '------------ PROCESS PRIMARY FILE -----------
            If Not bCancelAll Then
                Select Case TransferStatus
                    Case 0 'for processing
                        'transfer datafile
                        Select Case oSched.SCHED_Type
                            Case ActionType.Backup
                                'If TransferStatus = 0 Then
                                '    TransferStatus = 1
                                '    Save()
                                'End If
                                'upload export file
                                bSuccess = oFTP.FTP_PutFile(CleanPath(oProfile.ExpFolder) & cDataFileRelation, cDataFileRelation, cErr, bShowProgress)
                                If bSuccess Then
                                    LastStatus = "Backup File Uploaded"
                                    TransferStatus = 1
                                Else
                                    'schedule another run in 30 seconds
                                    LastStatus = "WAIT UL: Backup File"
                                    NextRun = DateAdd(DateInterval.Second, RetrySeconds, Now)
                                    LastStatus = cErr
                                End If
                                Save()

                            Case ActionType.Restore
                                'Import doesnt need this section
                                'import downloads its files during the initialization of oDE.new() for import.
                                If TransferStatus = 0 Then
                                    TransferStatus = 1
                                    Save()
                                End If
                        End Select

                    Case 1 'primary file (i.e. export file) processed

                    Case 2 'All transfers done

                End Select
            End If
            oFTP.FTP_Disconnect()
        End Sub

    End Class
#End Region

#Region "Event Log Class"
    Public Class oEventLog
        Private cLogID As String = ""
        Private dLogtime As Date = Now
        Public Logentry As New StringBuilder("")
        Public LogDesc As String = ""
        Public bError As Boolean = False

        Public ReadOnly Property LogTime As Date
            Get
                Return dLogtime
            End Get
        End Property

        Public Property LogID As String
            Get
                Return cLogID
            End Get
            Set(value As String)
                cLogID = value
                Load()
            End Set
        End Property


        Public Function Save(Optional ByRef cErr As String = "", Optional ByRef nAffected As Long = 0) As Boolean
            Dim cSQL As String = ""
            Dim bRetVal As Boolean = False
            Dim oParam() = oDLSQLSERVER.ParamObject(3) 'returns an Odbc.OdbcParameter object

            If NullToString(cLogID) <> "" Then
                'update

                cSQL = "UPDATE tblSTIService_eventlog SET"
                cSQL = cSQL & " logentry='" & RemoveQuotes(Logentry.ToString) & "',"
                cSQL = cSQL & " logdesc='" & RemoveInject(LogDesc) & "',"
                cSQL = cSQL & " logtime=GETDATE(),"
                cSQL = cSQL & " error=" & IIf(bError, 1, 0)
                cSQL = cSQL & " WHERE logid='" & cLogID & "'"

            Else
                'insert
                cLogID = GenerateID(oDLSQLSERVER, "tblSTIService_eventlog", "logid")

                cSQL = "INSERT INTO tblSTIService_eventlog (logid,logentry,logdesc,logtime,error)"
                cSQL = cSQL & " VALUES ('" & cLogID & "','" & RemoveQuotes(Logentry.ToString) & "','" & RemoveInject(LogDesc) & "',GETDATE()," & IIf(bError, 1, 0) & ")"

            End If
            bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL, cErr, nAffected)
            Return bRetVal
        End Function

        'IF No parameter is given and there is a valid profile loaded, then the currently loaded profile will be deleted.
        Public Function Delete(Optional ByVal pLogID As String = "") As Boolean
            Dim bRetVal As Boolean = False

            If pLogID = "" Then
                pLogID = cLogID
            End If
            If pLogID <> "" Then
                bRetVal = oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_eventlog WHERE logid='" & pLogID & "'")
            End If
            Return bRetVal
        End Function

        Private Function Load() As Boolean
            Dim dr As DataRow
            Dim dt As DataTable = GetDataTable("EVENT_LOG", cLogID)
            Dim bRetVal As Boolean = False
            If Not IsNothing(dt) AndAlso dt.Rows.Count <> 0 Then
                dr = dt.Rows(0)
                'load 
                cLogID = NullToString(dr.Item("logid"))
                dLogtime = NullToDate(dr.Item("logtime"))
                Logentry.Clear()
                Logentry.Append(NullToString(dr.Item("logentry")))
                bError = NullToZero(dr.Item("error"))
                bRetVal = True
            End If
            Return bRetVal
        End Function

    End Class
#End Region

End Module
