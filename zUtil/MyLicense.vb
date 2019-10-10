''============================ License Object ================================
'Public Class MyLicense
'    Private _LID As String
'    Private _LAppName As String
'    Private _LType As String
'    Private _LExp As String
'    Private _LHID As String
'    Private _LImo As String
'    Private _LSKey As String
'    Private _LGPeriod As String
'    Private _LNum As String
'    Private _LValid As String
'    Private _LGen As String
'    Private _LStat As String
'    Private _LMsg As String
'    Private _LRem As String
'    Private _LDateUpdated As String
'    Private _LPath As String

'#Region "Properties"

'    Public Property LID() As String
'        Get
'            Return _LID
'        End Get
'        Set(ByVal value As String)
'            If (Me._LID <> value) Then
'                Me._LID = value
'            End If
'        End Set
'    End Property

'    Public Property LAppName() As String
'        Get
'            Return _LAppName
'        End Get
'        Set(ByVal value As String)
'            If (Me._LAppName <> value) Then
'                Me._LAppName = value
'            End If
'        End Set
'    End Property

'    Public Property LType() As String
'        Get
'            Return _LType
'        End Get
'        Set(ByVal value As String)
'            If (Me._LType <> value) Then
'                Me._LType = value
'            End If
'        End Set
'    End Property

'    Public Property LExp() As String
'        Get
'            Return _LExp
'        End Get
'        Set(ByVal value As String)
'            If (Me._LExp <> value) Then
'                Me._LExp = value
'            End If
'        End Set
'    End Property

'    Public Property LHID() As String
'        Get
'            Return _LHID
'        End Get
'        Set(ByVal value As String)
'            If (Me._LHID <> value) Then
'                Me._LHID = value
'            End If
'        End Set
'    End Property

'    Public Property LImo() As String
'        Get
'            Return _LImo
'        End Get
'        Set(ByVal value As String)
'            If (Me._LImo <> value) Then
'                Me._LImo = value
'            End If
'        End Set
'    End Property


'    Public Property LSKey() As String
'        Get
'            Return _LSKey
'        End Get
'        Set(ByVal value As String)
'            If (Me._LSKey <> value) Then
'                Me._LSKey = value
'            End If
'        End Set
'    End Property

'    Public Property LGPeriod() As String
'        Get
'            Return _LGPeriod
'        End Get
'        Set(ByVal value As String)
'            If (Me._LGPeriod <> value) Then
'                Me._LGPeriod = value
'            End If
'        End Set
'    End Property

'    Public Property LNum() As String
'        Get
'            Return _LNum
'        End Get
'        Set(ByVal value As String)
'            If (Me._LNum <> value) Then
'                Me._LNum = value
'            End If
'        End Set
'    End Property

'    Public Property LValid() As String
'        Get
'            Return _LValid
'        End Get
'        Set(ByVal value As String)
'            If (Me._LValid <> value) Then
'                Me._LValid = value
'            End If
'        End Set
'    End Property

'    Public Property LGen() As String
'        Get
'            Return _LGen
'        End Get
'        Set(ByVal value As String)
'            If (Me._LGen <> value) Then
'                Me._LGen = value
'            End If
'        End Set
'    End Property

'    Public Property LStat() As String
'        Get
'            Return _LStat
'        End Get
'        Set(ByVal value As String)
'            If (Me._LStat <> value) Then
'                Me._LStat = value
'            End If
'        End Set
'    End Property

'    Public Property LMsg() As String
'        Get
'            Return _LMsg
'        End Get
'        Set(ByVal value As String)
'            If (Me._LMsg <> value) Then
'                Me._LMsg = value
'            End If
'        End Set
'    End Property

'    Public Property LRem() As String
'        Get
'            Return _LRem
'        End Get
'        Set(ByVal value As String)
'            If (Me._LRem <> value) Then
'                Me._LRem = value
'            End If
'        End Set
'    End Property

'    Public Property LDateUpdated() As String
'        Get
'            Return _LDateUpdated
'        End Get
'        Set(ByVal value As String)
'            If (Me._LDateUpdated <> value) Then
'                Me._LDateUpdated = value
'            End If
'        End Set
'    End Property

'    Public Property LPath() As String
'        Get
'            Return _LPath
'        End Get
'        Set(ByVal value As String)
'            If (Me._LPath <> value) Then
'                Me._LPath = value
'            End If
'        End Set
'    End Property

'#End Region

'#Region "Methods"

'    Public Sub New(Optional ByVal xLID As String = "", Optional ByVal xLAppName As String = "", Optional ByVal xLType As String = "", Optional ByVal xLExp As String = "", Optional ByVal xLHID As String = "", Optional ByVal xLImo As String = "", Optional ByVal xLSKey As String = "", Optional ByVal xLGPeriod As String = "", Optional ByVal xLNum As String = "", Optional ByVal xLValid As String = "", Optional ByVal xLGen As String = "", Optional ByVal xLStat As String = "", Optional ByVal xLMsg As String = "", Optional ByVal xLRem As String = "", Optional ByVal xLDateUpdated As String = "", Optional ByVal xLPath As String = "", Optional ByVal isValuesEncrypted As Boolean = True)

'        If isValuesEncrypted Then 'decrypt the values before setting it to its respective variable.
'            Me._LID = xLID
'            Me._LAppName = sysMpsUserPassword("DECRYPT", xLAppName)
'            Me._LType = sysMpsUserPassword("DECRYPT", xLType)
'            Me._LExp = sysMpsUserPassword("DECRYPT", xLExp)
'            Me._LHID = sysMpsUserPassword("DECRYPT", xLHID)
'            Me._LImo = sysMpsUserPassword("DECRYPT", xLImo)
'            Me._LSKey = sysMpsUserPassword("DECRYPT", xLSKey)
'            Me._LGPeriod = sysMpsUserPassword("DECRYPT", xLGPeriod)
'            Me._LNum = sysMpsUserPassword("DECRYPT", xLNum)
'            Me._LValid = sysMpsUserPassword("DECRYPT", xLValid)
'            Me._LGen = sysMpsUserPassword("DECRYPT", xLGen)
'            Me._LStat = sysMpsUserPassword("DECRYPT", xLStat)
'            Me._LMsg = sysMpsUserPassword("DECRYPT", xLMsg)
'            Me._LRem = sysMpsUserPassword("DECRYPT", xLRem)
'            Me._LDateUpdated = xLDateUpdated
'            Me._LPath = xLPath
'        Else
'            Me._LID = xLID
'            Me._LAppName = xLAppName
'            Me._LType = xLType
'            Me._LExp = xLExp
'            Me._LHID = xLHID
'            Me._LImo = xLImo
'            Me._LSKey = xLSKey
'            Me._LGPeriod = xLGPeriod
'            Me._LNum = xLNum
'            Me._LValid = xLValid
'            Me._LGen = xLGen
'            Me._LStat = xLStat
'            Me._LMsg = xLMsg
'            Me._LRem = xLRem
'            Me._LDateUpdated = xLDateUpdated
'            Me._LPath = xLPath
'        End If

'    End Sub

'#End Region

'End Class

'============================ MPS License Object ================================
Public Class MPSLicense
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

End Class


'=============================License Status Class======================================
Public Class MyLicenseStatus
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

    Public Sub New(Optional ByVal xLicenseType As String = "", Optional ByVal xExpDays As Integer = 0, Optional ByVal xStrLicenseMsg As String = "", Optional ByVal xErrMsg As String = "")
        Me._LicenseType = xLicenseType
        Me._ExpDays = xExpDays
        Me._StrLicenseMsg = xStrLicenseMsg
        Me._ErrMsg = xErrMsg
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
