Imports Microsoft.VisualBasic

Public Module Licensing

    Public LICENSEDB As New SQLDB(GetConnectionString(False))

    Public Sub CheckLicense(ByVal cApp As Working_App, ByRef xStatus As MyLicenseStatus)
        Dim bSuccess As Boolean = True

        Dim strLicType As String = ""
        Dim Mylicense As New MPSLicense
        Dim MyLicenseStatus As New MyLicenseStatus

        strLicType = LicensingGetConfig("LTYPE", cApp)
        strLicType = sysMpsUserPassword("DECRYPT", strLicType)

        If strLicType = "" Then
            strLicType = "NO"
        End If

        MyLicenseStatus = xValidateLicense(cApp, strLicType, Mylicense)
        If MyLicenseStatus.StrLicenseMsg <> "DATETIME TAMPERED ERROR" Then
            EvaluateMyLicense(cApp.App_DbName, cApp.App_BackRegGPeriod, Mylicense, MyLicenseStatus)
        End If

        Dim remarks As String = ""
        Dim strStat As String = ""

        If MyLicenseStatus.StrLicenseMsg <> "" Then
            strStat = "INVALID"
        Else
            strStat = "VALID"
        End If

        If MyLicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR" Then
            'expdays is = to num of runs
            If MyLicenseStatus.ExpDays <= 0 Then
                remarks = "Your license has been locked. Please contact System Administrator"
                'Me.cmdOk.Text = "Close"
            Else
                remarks = " You only have " & MyLicenseStatus.ExpDays & " runs left. Please see date/time settings."
            End If
        Else
            If MyLicenseStatus.ExpDays <= 60 Then
                If MyLicenseStatus.ExpDays <= 0 Then
                    remarks = IIf(MyLicenseStatus.StrLicenseMsg = "", " Your license has expired.", MyLicenseStatus.StrLicenseMsg)
                    If MyLicenseStatus.StrLicenseMsg = "" Then
                        strStat = "EXPIRED"
                    End If
                Else
                    remarks = MyLicenseStatus.StrLicenseMsg & " You only have " & MyLicenseStatus.ExpDays & " days left. Please apply for a new License to continue using this application"
                End If
            Else
                remarks = MyLicenseStatus.StrLicenseMsg & " You still have " & MyLicenseStatus.ExpDays & " days using this application."
            End If
        End If


        'create log
        If MyLicenseStatus.StrLicenseMsg.ToString <> "" Then
            Log_AppendLicensing(cApp, MyLicenseStatus.StrLicenseMsg.PadRight(25) & MyLicenseStatus.ErrMsg, "", True, True)
        ElseIf MyLicenseStatus.ExpDays = 0 Then
            Log_AppendLicensing(cApp, "License has expired.".PadRight(25) & MyLicenseStatus.ErrMsg, , , True)
        End If

        'set return
        xStatus.LicenseType = strLicType & " LICENSE"
        xStatus.StrLicenseMsg = remarks
        xStatus.ErrMsg = strStat

    End Sub

    Public Function isLicenseNeedstoValidate(ByVal cApp As Working_App) As Boolean
        Dim r As Boolean = False
        Try
            Dim strLicenseType As String = LicensingGetConfig("LTYPE", cApp)
            strLicenseType = sysMpsUserPassword("DECRYPT", strLicenseType)
            If strLicenseType = "MPSLICENSE" Then
                Dim cLastUpdated As String = LICENSEDB.DLookUp("REPLACE(CONVERT(varchar(10),[DateUpdated],120),'-','') AS [DateUpdated]", "[" & cApp.App_DbName & "].[dbo].[tblSTI]", "0", "")
                If cLastUpdated <> "0" Then
                    If Not (getServerDate() - CInt(cLastUpdated) = 0) Then
                        r = True
                    End If
                End If
            End If
        Catch ex As Exception
            r = False
        End Try
        Return r
    End Function

#Region "Utils"


    'RETURNS : Application Folder
    Public Function GetAppFolder() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As String) As String
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, String)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Integer) As Integer
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Integer)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Boolean) As Boolean
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Boolean)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Date) As Date
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Date)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Double) As Double
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Double)
        End If
    End Function


#End Region

#Region "Configs"

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function LicensingGetConfig(ByVal cCode As String, ByVal cApp As Working_App) As String
        Return LICENSEDB.DLookUp(cApp.App_ConfigValue, cApp.App_ConfigSchema, "", cApp.App_ConfigCode & "='" & cCode & "'")
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub LicensingSaveConfig(ByVal cCode As String, ByVal cValue As String, ByVal cApp As Working_App)
        Dim has_rec As Boolean = False
        LICENSEDB.BeginReader("Select " & cApp.App_ConfigValue & " from " & cApp.App_ConfigSchema & " Where " & cApp.App_ConfigCode & "='" & cCode & "'")
        has_rec = LICENSEDB.HasRows
        LICENSEDB.CloseReader()
        If has_rec Then
            LICENSEDB.RunSql("Update " & cApp.App_ConfigSchema & " SET " & cApp.App_ConfigValue & "='" & cValue & "' Where " & cApp.App_ConfigCode & "='" & cCode & "'")
        Else
            LICENSEDB.RunSql("Insert into " & cApp.App_ConfigSchema & " (" & cApp.App_ConfigCode & "," & cApp.App_ConfigValue & ") Values('" & cCode & "','" & cValue & "')")
        End If
    End Sub
#End Region

End Module
