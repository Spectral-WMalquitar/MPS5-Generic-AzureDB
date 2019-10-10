'License Class
Public Class MPSLicense : Implements IDisposable
    Private _LicenseID As String
    Private _LicenseAppName As String
    Private _LicenseType As String
    Private _LicenseNoOfUsers As String
    Private _LicenseExp As String
    Private _LicenseHID As String
    Private _LicenseLocID As String
    Private _LicenseSKey As String
    Private _LicenseGPeriod As String
    Private _LicenseNum As String
    Private _LicenseValid As String
    Private _LicenseGen As String
    Private _LicenseStat As String
    Private _LicenseMsg As String
    Private _LicenseRem As String
    Private _LicenseDateUpdated As String
    Private _LicensePath As String

#Region "Properties"

    Public Property LicenseID() As String
        Get
            Return _LicenseID
        End Get
        Set(ByVal value As String)
            If (Me._LicenseID <> value) Then
                Me._LicenseID = value
            End If
        End Set
    End Property

    Public Property LicenseAppName() As String
        Get
            Return _LicenseAppName
        End Get
        Set(ByVal value As String)
            If (Me._LicenseAppName <> value) Then
                Me._LicenseAppName = value
            End If
        End Set
    End Property

    Public Property LicenseType() As String
        Get
            Return _LicenseType
        End Get
        Set(ByVal value As String)
            If (Me._LicenseType <> value) Then
                Me._LicenseType = value
            End If
        End Set
    End Property

    Public Property LicenseNoOfUsers() As String
        Get
            Return _LicenseNoOfUsers
        End Get
        Set(ByVal value As String)
            If (Me._LicenseNoOfUsers <> value) Then
                Me._LicenseNoOfUsers = value
            End If
        End Set
    End Property

    Public Property LicenseExp() As String
        Get
            Return _LicenseExp
        End Get
        Set(ByVal value As String)
            If (Me._LicenseExp <> value) Then
                Me._LicenseExp = value
            End If
        End Set
    End Property

    Public Property LicenseHID() As String
        Get
            Return _LicenseHID
        End Get
        Set(ByVal value As String)
            If (Me._LicenseHID <> value) Then
                Me._LicenseHID = value
            End If
        End Set
    End Property

    Public Property LicenseLocID() As String
        Get
            Return _LicenseLocID
        End Get
        Set(ByVal value As String)
            If (Me._LicenseLocID <> value) Then
                Me._LicenseLocID = value
            End If
        End Set
    End Property


    Public Property LicenseSKey() As String
        Get
            Return _LicenseSKey
        End Get
        Set(ByVal value As String)
            If (Me._LicenseSKey <> value) Then
                Me._LicenseSKey = value
            End If
        End Set
    End Property

    Public Property LicenseGPeriod() As String
        Get
            Return _LicenseGPeriod
        End Get
        Set(ByVal value As String)
            If (Me._LicenseGPeriod <> value) Then
                Me._LicenseGPeriod = value
            End If
        End Set
    End Property

    Public Property LicenseNum() As String
        Get
            Return _LicenseNum
        End Get
        Set(ByVal value As String)
            If (Me._LicenseNum <> value) Then
                Me._LicenseNum = value
            End If
        End Set
    End Property

    Public Property LicenseValid() As String
        Get
            Return _LicenseValid
        End Get
        Set(ByVal value As String)
            If (Me._LicenseValid <> value) Then
                Me._LicenseValid = value
            End If
        End Set
    End Property

    Public Property LicenseGen() As String
        Get
            Return _LicenseGen
        End Get
        Set(ByVal value As String)
            If (Me._LicenseGen <> value) Then
                Me._LicenseGen = value
            End If
        End Set
    End Property

    Public Property LicenseStat() As String
        Get
            Return _LicenseStat
        End Get
        Set(ByVal value As String)
            If (Me._LicenseStat <> value) Then
                Me._LicenseStat = value
            End If
        End Set
    End Property

    Public Property LicenseMsg() As String
        Get
            Return _LicenseMsg
        End Get
        Set(ByVal value As String)
            If (Me._LicenseMsg <> value) Then
                Me._LicenseMsg = value
            End If
        End Set
    End Property

    Public Property LicenseRem() As String
        Get
            Return _LicenseRem
        End Get
        Set(ByVal value As String)
            If (Me._LicenseRem <> value) Then
                Me._LicenseRem = value
            End If
        End Set
    End Property

    Public Property LicenseDateUpdated() As String
        Get
            Return _LicenseDateUpdated
        End Get
        Set(ByVal value As String)
            If (Me._LicenseDateUpdated <> value) Then
                Me._LicenseDateUpdated = value
            End If
        End Set
    End Property

    Public Property LPath() As String
        Get
            Return _LicensePath
        End Get
        Set(ByVal value As String)
            If (Me._LicensePath <> value) Then
                Me._LicensePath = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New(Optional ByVal xLicenseID As String = "", Optional ByVal xLicenseAppName As String = "", Optional ByVal xLicenseType As String = "", Optional ByVal xLicenseNoOfUsers As String = "", Optional ByVal xLicenseExp As String = "", Optional ByVal xLicenseHID As String = "", Optional ByVal xLicenseLocID As String = "", Optional ByVal xLicenseSKey As String = "", Optional ByVal xLicenseGPeriod As String = "", Optional ByVal xLicenseNum As String = "", Optional ByVal xLicenseValid As String = "", Optional ByVal xLicenseGen As String = "", Optional ByVal xLicenseStat As String = "", Optional ByVal xLicenseMsg As String = "", Optional ByVal xLicenseDateUpdated As String = "", Optional ByVal xLicensePath As String = "", Optional ByVal isValuesEncrypted As Boolean = True)

        If isValuesEncrypted Then 'decrypt the values before setting it to its respective variable.
            Me._LicenseID = xLicenseID
            Me._LicenseAppName = sysMpsUserPassword("DECRYPT", xLicenseAppName)
            Me._LicenseType = sysMpsUserPassword("DECRYPT", xLicenseType)
            Me._LicenseNoOfUsers = sysMpsUserPassword("DECRYPT", xLicenseNoOfUsers)
            Me._LicenseExp = sysMpsUserPassword("DECRYPT", xLicenseExp)
            Me._LicenseHID = sysMpsUserPassword("DECRYPT", xLicenseHID)
            Me._LicenseLocID = sysMpsUserPassword("DECRYPT", xLicenseLocID)
            Me._LicenseSKey = sysMpsUserPassword("DECRYPT", xLicenseSKey)
            Me._LicenseGPeriod = sysMpsUserPassword("DECRYPT", xLicenseGPeriod)
            Me._LicenseNum = sysMpsUserPassword("DECRYPT", xLicenseNum)
            Me._LicenseValid = sysMpsUserPassword("DECRYPT", xLicenseValid)
            Me._LicenseGen = sysMpsUserPassword("DECRYPT", xLicenseGen)
            Me._LicenseStat = sysMpsUserPassword("DECRYPT", xLicenseStat)
            Me._LicenseMsg = sysMpsUserPassword("DECRYPT", xLicenseMsg)
            Me._LicenseDateUpdated = xLicenseDateUpdated
            Me._LicensePath = xLicensePath
        Else
            Me._LicenseID = xLicenseID
            Me._LicenseAppName = xLicenseAppName
            Me._LicenseType = xLicenseType
            Me._LicenseNoOfUsers = xLicenseNoOfUsers
            Me._LicenseExp = xLicenseExp
            Me._LicenseHID = xLicenseHID
            Me._LicenseLocID = xLicenseLocID
            Me._LicenseSKey = xLicenseSKey
            Me._LicenseGPeriod = xLicenseGPeriod
            Me._LicenseNum = xLicenseNum
            Me._LicenseValid = xLicenseValid
            Me._LicenseGen = xLicenseGen
            Me._LicenseStat = xLicenseStat
            Me._LicenseMsg = xLicenseMsg
            Me._LicenseDateUpdated = xLicenseDateUpdated
            Me._LicensePath = xLicensePath
        End If

    End Sub

#End Region

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

'License Status Class
Public Class MyLicenseStatus : Implements IDisposable
    Private _LicenseType As String
    Private _ExpDays As Integer
    Private _NoUsers As Integer
    Private _StrLicenseMsg As String
    Private _ErrMsg As String

#Region "Properties"

    Public Property LicenseType()
        Get
            Return Me._LicenseType
        End Get
        Set(ByVal value)
            If (Me._LicenseType <> value) Then
                Me._LicenseType = value
            End If
        End Set
    End Property

    Public Property ExpDays()
        Get
            Return Me._ExpDays
        End Get
        Set(ByVal value)
            If (Me._ExpDays <> value) Then
                Me._ExpDays = value
            End If
        End Set
    End Property

    Public Property NoOfUsers()
        Get
            Return Me._NoUsers
        End Get
        Set(ByVal value)
            If (Me._NoUsers <> value) Then
                Me._NoUsers = value
            End If
        End Set
    End Property

    Public Property StrLicenseMsg()
        Get
            Return Me._StrLicenseMsg
        End Get
        Set(ByVal value)
            If (Me._StrLicenseMsg <> value) Then
                Me._StrLicenseMsg = value
            End If
        End Set
    End Property

    Public Property ErrMsg()
        Get
            Return Me._ErrMsg
        End Get
        Set(ByVal value)
            If (Me._ErrMsg <> value) Then
                Me._ErrMsg = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New(Optional ByVal xLicenseType As String = "", Optional ByVal xExpDays As Integer = 0, Optional ByVal xNoUsers As Integer = 0, Optional ByVal xStrLicenseMsg As String = "", Optional ByVal xErrMsg As String = "")
        Me._LicenseType = xLicenseType
        Me._ExpDays = xExpDays
        Me._NoUsers = xNoUsers
        Me._StrLicenseMsg = xStrLicenseMsg
        Me._ErrMsg = xErrMsg
    End Sub

#End Region

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


'=============================App Class======================================
Public Class Working_App
    Private _App_Name As String
    Private _App_DbName As String
    Private _App_LogFolder As String
    Private _App_LicensePath As String
    Private _App_RegKey As String
    Private _App_BackRegGPeriod As String
    Private _App_ConfigSchema As String
    Private _App_ConfigCode As String
    Private _App_ConfigValue As String

#Region "App_Properties"
    Public Property App_Name()
        Get
            Return Me._App_Name
        End Get
        Set(ByVal value)
            If (Me._App_Name <> value) Then
                Me._App_Name = value
            End If
        End Set
    End Property

    Public Property App_DbName()
        Get
            Return Me._App_DbName
        End Get
        Set(ByVal value)
            If (Me._App_DbName <> value) Then
                Me._App_DbName = value
            End If
        End Set
    End Property

    Public Property App_LogFolder()
        Get
            Return Me._App_LogFolder
        End Get
        Set(ByVal value)
            If (Me._App_LogFolder <> value) Then
                Me._App_LogFolder = value
            End If
        End Set
    End Property

    Public Property App_LicensePath()
        Get
            Return Me._App_LicensePath
        End Get
        Set(ByVal value)
            If (Me._App_LicensePath <> value) Then
                Me._App_LicensePath = value
            End If
        End Set
    End Property

    Public Property App_RegKey()
        Get
            Return Me._App_RegKey
        End Get
        Set(ByVal value)
            If (Me._App_RegKey <> value) Then
                Me._App_RegKey = value
            End If
        End Set
    End Property

    Public Property App_BackRegGPeriod()
        Get
            Return Me._App_BackRegGPeriod
        End Get
        Set(ByVal value)
            If (Me._App_BackRegGPeriod <> value) Then
                Me._App_BackRegGPeriod = value
            End If
        End Set
    End Property

    Public Property App_ConfigSchema()
        Get
            Return Me._App_ConfigSchema
        End Get
        Set(ByVal value)
            If (Me._App_ConfigSchema <> value) Then
                Me._App_ConfigSchema = value
            End If
        End Set
    End Property

    Public Property App_ConfigCode()
        Get
            Return Me._App_ConfigCode
        End Get
        Set(ByVal value)
            If (Me._App_ConfigCode <> value) Then
                Me._App_ConfigCode = value
            End If
        End Set
    End Property

    Public Property App_ConfigValue()
        Get
            Return Me._App_ConfigValue
        End Get
        Set(ByVal value)
            If (Me._App_ConfigValue <> value) Then
                Me._App_ConfigValue = value
            End If
        End Set
    End Property

#End Region

#Region "App_Methods"

    Public Sub New(Optional ByVal xApp_Name As String = "", Optional ByVal xApp_DbName As String = "", Optional ByVal xApp_LogFolder As String = "", Optional ByVal xApp_LicensePath As String = "", Optional ByVal xApp_RegKey As String = "", Optional ByVal xApp_BackRegGPeriod As String = "", Optional ByVal xApp_ConfigCode As String = "Code", Optional ByVal xApp_ConfigValue As String = "Value", Optional ByVal xApp_ConfigSchema As String = "")
        Me._App_Name = xApp_Name
        Me._App_DbName = xApp_DbName
        Me._App_LogFolder = xApp_LogFolder
        Me._App_LicensePath = xApp_LicensePath
        Me._App_RegKey = xApp_RegKey
        Me._App_BackRegGPeriod = xApp_BackRegGPeriod
        Me._App_ConfigCode = xApp_ConfigCode
        Me._App_ConfigValue = xApp_ConfigValue
        Me.App_ConfigSchema = xApp_ConfigSchema
    End Sub

#End Region

End Class


'Session Class
Public Class MPSSession

    Private cPKey As String
    Private cUserID As Integer
    Private cUserName As String
    Private cToken As String
    Private cModuleName As String

#Region "Properties"

    Public Property PKey() As String
        Get
            Return cPKey
        End Get
        Set(ByVal value As String)
            cPKey = value
        End Set
    End Property

    Public Property UserID() As Integer
        Get
            Return cUserID
        End Get
        Set(ByVal value As Integer)
            cUserID = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return cUserName
        End Get
        Set(ByVal value As String)
            cUserName = value
        End Set
    End Property

    Public Property Token() As String
        Get
            Return cToken
        End Get
        Set(ByVal value As String)
            cToken = value
        End Set
    End Property

    Public Property ModuleName() As String
        Get
            Return cModuleName
        End Get
        Set(ByVal value As String)
            cModuleName = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Function IsReadyToProceed(ByVal oDB As SQLDB, Optional ByRef ErrMsg As String = Nothing) As Boolean
        Dim bSuccess As Boolean = False
        Dim cCompName As String
        Try
            cCompName = oDB.DLookUp("CompName", "dbo.MSysSec_Users_Log", "", "(NOT (UserToken IS NULL)) AND (NOT (CompName IS NULL)) AND (ModuleName ='" & cModuleName & "') AND (NOT (LastCheck IS NULL)) AND (NOT (UserName IS NULL))" & _
                                   " AND (LastCheck > DATEADD(minute, - " & oDB.DLookUp("TextValue", "tblConfig", "", "CODE = 'REFRESH_RATE'") & ", GETDATE()))" & _
                                   " AND (FKeyUserID = " & cUserID.ToString & ")")
            If cCompName <> "" Then
                If (UCase(cCompName) = UCase(My.Computer.Name.Replace("'", "''"))) Then
                    bSuccess = True
                Else
                    'not equal: Means(another computer has been connected)
                    bSuccess = False
                    ErrMsg = cUserName & " is currently logged on from: ( " & UCase(cCompName) & " - " & cModuleName & " MODULE )"
                End If
            Else
                bSuccess = True
            End If

        Catch ex As Exception
            bSuccess = False
            ErrMsg = "An error occured validating your user session!"
        End Try
        Return bSuccess
    End Function

    Public Function AddUserSession(ByVal oDB As SQLDB, Optional ByRef ErrMsg As String = Nothing) As Boolean
        Dim bSuccess As Boolean = False
        Try
            '<!-- edited by tony20171005
            If UserName = "Administrator" Or UserName = "Spectral" Then
                bSuccess = oDB.RunSql("DELETE FROM dbo.MSysSec_Users_Log WHERE ModuleName='" & cModuleName & "' AND FKeyUserID=" & cUserID.ToString & " AND CompName = '" & My.Computer.Name.Replace("'", "''") & "'")
            Else
                bSuccess = oDB.RunSql("DELETE FROM dbo.MSysSec_Users_Log WHERE ModuleName='" & cModuleName & "' AND FKeyUserID=" & cUserID.ToString & "")
            End If
            '-->
            bSuccess = oDB.RunSql("INSERT INTO dbo.MSysSec_Users_Log ([PKey],[FKeyUserID],[UserName],[UserToken],[LastCheck],[CompName],[ModuleName])" & _
                                  " VALUES('" & cPKey & "'," & cUserID & ",'" & cUserName.Replace("'", "''") & "','" & cToken & "',GETDATE(),'" & My.Computer.Name.Replace("'", "''") & "','" & cModuleName & "')")
            bSuccess = True
        Catch ex As Exception
            bSuccess = False
        End Try

        If Not bSuccess Then
            ErrMsg = "An error occurred inserting session!"
        End If
        Return bSuccess
    End Function

    Public Function UpdateSession(ByVal oDB As SQLDB, Optional ByVal cValue As Integer = 1) As Boolean
        Dim bSuccess As Boolean = False
        Try
            bSuccess = oDB.RunSql("UPDATE dbo.MSysSec_Users_Log SET CompName='" & My.Computer.Name.Replace("'", "''") & "',UserToken='" & cToken & "',ModuleName='" & cModuleName & "',LastCheck=GETDATE() WHERE PKey='" & cPKey & "' And FKeyUserID=" & cUserID.ToString & "")
            bSuccess = True
        Catch ex As Exception
            bSuccess = False
        End Try
        Return bSuccess
    End Function

    Public Function Dispose(ByVal oDB As SQLDB) As Boolean
        Dim bSuccess As Boolean = False
        Try
            bSuccess = oDB.RunSql("DELETE FROM dbo.MSysSec_Users_Log WHERE PKey='" & cPKey & "'")
            bSuccess = oDB.RunSql("DELETE FROM dbo.MSysSec_Users_Log WHERE LastCheck < DATEADD(minute, - " & oDB.DLookUp("TextValue", "tblConfig", "", "CODE = 'REFRESH_RATE'") & ", GETDATE())")
            bSuccess = True
        Catch ex As Exception
            MsgBox("An error occurred disposing the user session.", MsgBoxStyle.Exclamation, GetAppName)
            bSuccess = False
        End Try
        Return bSuccess
    End Function

    Public Function IsUserLoggedIn(ByVal oDB As SQLDB, Optional ByRef ErrMsg As String = Nothing) As Boolean
        Dim bSuccess As Boolean = False
        Dim cDBToken As String
        Try
            cDBToken = oDB.DLookUp("UserToken", "dbo.MSysSec_Users_Log", "", "(NOT (UserToken IS NULL)) AND (NOT (CompName IS NULL)) AND (ModuleName ='" & cModuleName & "') AND (NOT (LastCheck IS NULL)) AND (NOT (UserName IS NULL))" & _
                                   " AND (LastCheck > DATEADD(minute, - 5, GETDATE())) AND (PKey ='" & cPKey & "')" & _
                                   " AND (FKeyUserID = " & cUserID.ToString & ")")
            If (UCase(cDBToken) = UCase(cToken)) Then
                bSuccess = True
            Else
                'not equal (session expired)
                bSuccess = False
                ErrMsg = "Session expired!"
            End If
        Catch ex As Exception
            bSuccess = False
        End Try
        Return bSuccess
    End Function

    Public Sub New()

    End Sub

#End Region

End Class

'User Slots
Public Class MPSUserSlots
    Private cMaxSlots As Integer
    Private cFreeSlots As Integer
    Private cErr As String

    Public Property MaxSlots() As Integer
        Get
            Return cMaxSlots
        End Get
        Set(ByVal value As Integer)
            cMaxSlots = value
        End Set
    End Property

    Public Property FreeSlots() As Integer
        Get
            Return cFreeSlots
        End Get
        Set(ByVal value As Integer)
            cFreeSlots = value
        End Set
    End Property

    Public Property ErrMsg() As String
        Get
            Return cErr
        End Get
        Set(ByVal value As String)
            cErr = value
        End Set
    End Property

End Class