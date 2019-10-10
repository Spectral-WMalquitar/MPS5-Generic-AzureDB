Imports System.Configuration
Imports System.Security.AccessControl
Imports System.DirectoryServices

Public Module mdLicense
    'initializations
    Public mps5_app As New Working_App("MPS", "STIAPPVERSIONS", GetAppFolder() & "License Logs\MPS", GetAppFolder() & "STI_MPSLic.lic", "sys_mps", "sys_mps_g_p", "Code", "Value", "STIAPPVERSIONS.dbo.tblSTIService_config")
    'Public sas_app As New Working_App("SAS", "sas_tbl", GetAppFolder() & "License Logs\SAS4", GetAppFolder() & "STI_SLic.lic", "sys_s_g_p")
    'Public wrh5_app As New Working_App("WRH", "wrh_db", GetAppFolder() & "License Logs\WRH5", GetAppFolder() & "STI_W5Lic.lic", "sys_wrh5", "sys_w5_g_p", "Code", "Value", "sti_sys.dbo.tblWRH5Config")
    'Public wrhsm5_app As New Working_App("WRHSM5", "sm5_db", GetAppFolder() & "License Logs\WRHSM5", GetAppFolder() & "STI_WSM5Lic.lic", "sys_wrhsm5", "sys_wsm5_g_p", "Code", "Value", "sti_sys.dbo.tblSM5Config")

#Region "Base Functions"

    'validate physical License file
    Public Function xValidateLicense(ByVal cApp As Working_App, ByVal ServerLicenseType As String, ByRef returnLicense As MPSLicense, Optional ByVal strLogFile As String = "", Optional createLog As Boolean = False) As MyLicenseStatus
        Dim returnLicenseStatus As New MyLicenseStatus
        Dim bSuccess As Boolean = True

        Dim dbName As String = cApp.App_DbName
        Dim MyLicenseFilePath As String = cApp.App_LicensePath

        Dim ComputerInfo As New mdComputerInfo
        Dim myHID As String = ComputerInfo.GetHardwareID
        Dim current_date As Integer = getServerDate()

        returnLicenseStatus.LicenseType = ServerLicenseType

        Log_AppendLicensing(cApp, "********************* Start *********************" & vbNewLine, strLogFile, createLog)

        Select Case ServerLicenseType

            Case "TRIAL"

                Log_AppendLicensing(cApp, "LICENSE TYPE: TRIAL LICENSE", strLogFile, createLog)
                Log_AppendLicensing(cApp, "MPS SERVICE : This Service is not designed to evaluate TRIAL LICENSE", strLogFile, createLog)
                Log_AppendLicensing(cApp, "VALID LICENSE TYPE should be ( MPSLICENSE )", strLogFile, createLog)

            Case "MPSLICENSE"
                Log_AppendLicensing(cApp, "LICENSE TYPE: MPS LICENSE", strLogFile, createLog)

                bSuccess = xReadLicenseFile(MyLicenseFilePath, returnLicense, True, returnLicenseStatus.ErrMsg)

                If bSuccess And returnLicenseStatus.ErrMsg = "" Then 'success reading the local file
                    Log_AppendLicensing(cApp, "READING LICENSE FILE -- OK", strLogFile, createLog)
                    'get Local File Serial Key
                    Dim strLocalSKey As String = returnLicense.LicenseSKey
                    'get Local File HID 
                    Dim strLocalHID As String = returnLicense.LicenseHID

                    'fetch license from server
                    bSuccess = xGetLicenseFromServer(dbName, returnLicense, "LSKey='" & strLocalSKey & "'", returnLicenseStatus.ErrMsg)
                    Log_AppendLicensing(cApp, "MATCHING LICENSE DETAILS FROM THE SERVER -- " & IIf(bSuccess, "OK", "NO MATCH"), strLogFile, createLog)
                    If Not bSuccess Then
                        returnLicenseStatus.StrLicenseMsg = "You do not have valid license in the server."
                        returnLicenseStatus.ExpDays = 0
                        GoTo ReturnLine
                    End If

                    'check datetime if tampered
                    bSuccess = isDateTimeTampered(cApp, returnLicense, returnLicenseStatus)
                    If bSuccess Then
                        GoTo ReturnLine
                    End If

                    'compare HIDS
                    'first: DatabasedHID to LocalFileHID
                    If isMatch(returnLicense.LicenseHID, strLocalHID) Then
                        'second: DatabasedHID to CurrentHID
                        If Not isMatch(returnLicense.LicenseHID, myHID) Then
                            returnLicenseStatus.StrLicenseMsg = "Hardware ID changed."
                            Log_AppendLicensing(cApp, "MATCHING HARDWARE ID: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                            GoTo ReturnLine
                        Else
                            Log_AppendLicensing(cApp, "MATCHING HARDWARE ID: -- OK", strLogFile, createLog)
                        End If
                    Else
                        returnLicenseStatus.StrLicenseMsg = "Hardware ID doesn't match."
                        Log_AppendLicensing(cApp, "MATCHING HARDWARE ID: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                        GoTo ReturnLine
                    End If

                    'evaluate license status
                    If Not (returnLicense.LicenseStat = "VALID" Or returnLicense.LicenseStat = "EXPIRED") Then
                        returnLicenseStatus.StrLicenseMsg = "Cannot Evaluate License Status."
                        Log_AppendLicensing(cApp, "EVALUATING LICENSE STATUS: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                        GoTo ReturnLine
                    ElseIf returnLicense.LicenseStat = "EXPIRED" Then
                        returnLicenseStatus.ExpDays = 0
                        Log_AppendLicensing(cApp, "EVALUATING LICENSE STATUS: -- EXPIRED", strLogFile, createLog)
                        GoTo ReturnLine
                    End If

                    'check date effectivity
                    If Trim(returnLicense.LicenseExp) = "" Then
                        returnLicenseStatus.StrLicenseMsg = "Cannot Evaluate License Expiry."
                        Log_AppendLicensing(cApp, "EVALUATING LICENSE EXPIRY: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                        GoTo ReturnLine
                    Else
                        'check expDays
                        Dim DExp As String

                        Try
                            DExp = returnLicense.LicenseExp
                            Log_AppendLicensing(cApp, "EVALUATING LICENSE EXPIRY: -- " & returnLicense.LicenseExp, strLogFile, createLog)
                        Catch ex As Exception
                            returnLicenseStatus.StrLicenseMsg = "Invalid License Expiry."
                            Log_AppendLicensing(cApp, "EVALUATING LICENSE EXPIRY: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                            GoTo ReturnLine
                        End Try

                        returnLicenseStatus.ExpDays = ServerDateDiff(DExp)
                        If returnLicenseStatus.ExpDays <= 0 Then
                            returnLicenseStatus.ExpDays = 0
                        End If
                    End If

                    'get no. of users allowed
                    If returnLicense.LicenseNoOfUsers <> "" Then
                        Try
                            returnLicenseStatus.NoOfUsers = CInt(returnLicense.LicenseNoOfUsers)
                            Log_AppendLicensing(cApp, "NO OF CONCURRENT USERS: -- " & returnLicense.LicenseNoOfUsers, strLogFile, createLog)
                        Catch ex As Exception
                            returnLicenseStatus.StrLicenseMsg = "Invalid No. of concurrent users.( " & ex.Message & " )"
                            Log_AppendLicensing(cApp, "NO OF CONCURRENT USERS: -- INVALID ( " & returnLicense.LicenseNoOfUsers & " )" & ex.Message, strLogFile, createLog)
                        End Try
                    Else
                        returnLicenseStatus.NoOfUsers = 0
                        returnLicenseStatus.StrLicenseMsg = "Invalid No. of concurrent users. ( Cannot be empty )"
                        Log_AppendLicensing(cApp, "NO OF CONCURRENT USERS: -- INVALID ( Cannot be empty )", strLogFile, createLog)
                    End If

                Else
                    'no local license file
                    Log_AppendLicensing(cApp, "READING LICENSE FILE -- Unable to read license file." & returnLicenseStatus.ErrMsg, strLogFile, createLog)
                    returnLicenseStatus.StrLicenseMsg = "Unable to read license file."
                End If

            Case Else
                returnLicenseStatus.LicenseType = "NO LICENSE"
                returnLicenseStatus.StrLicenseMsg = "Unable to evaluate License Type."
        End Select

ReturnLine:
        Log_AppendLicensing(cApp, "", strLogFile, createLog)
        Log_AppendLicensing(cApp, "********************* End *********************", strLogFile, createLog)

        Return returnLicenseStatus
    End Function

    'evaluate License status
    Public Sub EvaluateMyLicense(ByVal dbName As String, ByVal bak_gPeriod As String, ByRef Mylicense As MPSLicense, ByRef MyLicenseStatus As MyLicenseStatus)
        Dim bSuccess As Boolean = True

        If MyLicenseStatus.StrLicenseMsg <> "" Then ' there's something went wrong upon validation
            Dim gPeriod As Integer = GetGPeriod(dbName, Mylicense, bak_gPeriod)

            MyLicenseStatus.ExpDays = ServerDateDiff(gPeriod.ToString)

            If MyLicenseStatus.ExpDays > 10 Then
                MyLicenseStatus.ExpDays = 0
                MyLicenseStatus.StrLicenseMsg = "LICENSE FORCED TO EXPIRED."
                MyLicenseStatus.ErrMsg = "Grace Period exceeded in 10 days."
            End If
        Else ' valid license
            'a valid license expired
            If MyLicenseStatus.ExpDays <= 0 Then
                bSuccess = UpdateLicense(dbName, Mylicense.LicenseID, "[LStat]", "EXPIRED")
            Else
                bSuccess = UpdateLicense(dbName, Mylicense.LicenseID, "[LValid]", getServerDateTime.ToString)
            End If
        End If

        'Update License Row

        If Mylicense.LicenseID = "" Then
            bSuccess = xGetLicenseFromServer(dbName, Mylicense, "LType='MPSLICENSE'")
        End If

        Dim xCol As String = ""
        Dim xColVal As String = ""

        xCol = "[LStat],[LMsg]"
        xColVal = IIf(MyLicenseStatus.ExpDays > 0, "VALID", "EXPIRED")
        xColVal = xColVal & "," & IIf(MyLicenseStatus.StrLicenseMsg <> "", MyLicenseStatus.StrLicenseMsg, "LICENSE IS VALID")
        bSuccess = UpdateLicense(dbName, Mylicense.LicenseID, xCol, xColVal)

    End Sub

    'get Grace Period
    Public Function GetGPeriod(ByVal dbName As String, ByVal Mylicense As MPSLicense, ByVal BackUpReg As String) As Integer
        Dim r As Integer
        Dim strGPeriod As String = ""
        Try
            If Mylicense.LicenseGPeriod = "10" Then 'not yet set, first encouter of error
                strGPeriod = ServerAddDays(10).ToString
                UpdateLicense(dbName, Mylicense.LicenseID, "[LGPeriod]", strGPeriod)
                WriteReg(BackUpReg, strGPeriod, True)
            Else ' set
                Try
                    strGPeriod = Mylicense.LicenseGPeriod
                    r = CInt(strGPeriod)
                    If Not isNumDate(r) Then
                        strGPeriod = getServerDate.ToString()
                    End If
                Catch ex As Exception
                    strGPeriod = GetReg(BackUpReg, True)
                    If strGPeriod = "" Then ' no backupreg
                        strGPeriod = getServerDate().ToString ' set to current date
                        r = CInt(strGPeriod)
                    ElseIf strGPeriod = "10" Then
                        strGPeriod = ServerAddDays(10).ToString
                        WriteReg(BackUpReg, strGPeriod, True)
                    Else
                        Try
                            r = CInt(strGPeriod)
                            If Not isNumDate(r) Then
                                strGPeriod = getServerDate.ToString()
                            End If
                        Catch exs As Exception
                            strGPeriod = getServerDate.ToString()
                        End Try
                    End If
                End Try
            End If
        Catch ex As Exception
            'on error return current_date
            strGPeriod = getServerDate.ToString()
        End Try

        r = CInt(strGPeriod)

        Return r
    End Function

    'read physical license file
    Public Function xReadLicenseFile(ByVal xPath As String, ByRef outputLicense As MPSLicense, Optional ByVal DecryptValues As Boolean = True, Optional ByRef ErrMsg As String = "") As Boolean
        Dim lst As New List(Of String)
        Dim r As Boolean
        Try

            If Not System.IO.File.Exists(xPath) Then
                r = False
                ErrMsg = "No License File Found."
                Return r
                Exit Function
            End If

            Using sw As System.IO.StreamReader = New System.IO.StreamReader(xPath)
                Dim line As String = ""

                line = sw.ReadLine

                ' Loop over each line in file, While list is Not Nothing.
                Do While (Not line Is Nothing)
                    ' Add this line to list.
                    If DecryptValues Then
                        lst.Add(sysMpsUserPassword("DECRYPT", line))
                    Else
                        lst.Add(line)
                    End If

                    ' Read in the next line.
                    line = sw.ReadLine
                Loop

            End Using

            'convert List of string into License
            If lst.Count = 14 Then
                outputLicense.LicenseID = ""
                outputLicense.LicenseAppName = lst(0)
                outputLicense.LicenseType = lst(1)
                outputLicense.LicenseNoOfUsers = lst(2)
                outputLicense.LicenseExp = lst(3)
                outputLicense.LicenseHID = lst(4)
                outputLicense.LicenseLocID = lst(5)
                outputLicense.LicenseSKey = lst(6)
                outputLicense.LicenseGPeriod = lst(7)
                outputLicense.LicenseNum = lst(8)
                outputLicense.LicenseValid = lst(9)
                outputLicense.LicenseGen = lst(10)
                outputLicense.LicenseStat = lst(11)
                outputLicense.LicenseMsg = lst(12)
                outputLicense.LicenseRem = lst(13)
                outputLicense.LPath = xPath
                r = True
            Else
                ErrMsg = "Invalid License File." & vbNewLine & vbNewLine & "Please check format."
                r = False
            End If

        Catch ex As Exception
            ErrMsg = "An error occurred reading the license file." & vbNewLine & vbNewLine & ex.Message
            r = False
        End Try
        Return r
    End Function

    'search for a license
    Public Function xGetLicenseFromServer(ByVal dbName As String, ByRef xLicense As MPSLicense, Optional ByVal cWhere As String = "", Optional ByRef ErrMsg As String = "") As Boolean
        Dim r As Boolean = False
        Dim dt As New DataTable
        Try
            dt = xLicensesToDatatable(dbName, ErrMsg)
            For Each rw As DataRow In dt.Select(cWhere)
                xLicense.LicenseID = rw("LID")
                xLicense.LicenseAppName = rw("LAppName")
                xLicense.LicenseType = rw("LType")
                xLicense.LicenseNoOfUsers = rw("LNoUsers")
                xLicense.LicenseExp = rw("LExp")
                xLicense.LicenseHID = rw("LHID")
                xLicense.LicenseLocID = rw("LLocID")
                xLicense.LicenseSKey = rw("LSKey")
                xLicense.LicenseGPeriod = rw("LGPeriod")
                xLicense.LicenseNum = rw("LNum")
                xLicense.LicenseValid = rw("LValid")
                xLicense.LicenseGen = rw("LGen")
                xLicense.LicenseStat = rw("LStat")
                xLicense.LicenseMsg = rw("LMsg")
                xLicense.LicenseRem = rw("LRem")
                xLicense.LicenseDateUpdated = rw("DateUpdated")
                r = True
                Exit For
            Next
        Catch ex As Exception
            r = False
            ErrMsg = ex.Message
        End Try
        Return r
    End Function

    'get all licenses in the server pass to datatable
    Public Function xLicensesToDatatable(ByVal dbName As String, Optional ByVal ErrMsg As String = "", Optional ByVal cWhere As String = "") As DataTable
        Dim dt As New DataTable

        Try
            dt = LICENSEDB.CreateTable("SELECT * FROM " & dbName & ".dbo.tblSTI")
            For Each row As DataRow In dt.Rows
                For Each col As DataColumn In dt.Columns
                    If col.ColumnName = "LID" Or col.ColumnName = "DateUpdated" Then

                    Else
                        Try
                            row(col.ColumnName) = sysMpsUserPassword("DECRYPT", row(col.ColumnName))
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Next
            Return dt
        Catch ex As Exception
            Return dt
            ErrMsg = ex.Message
        End Try
    End Function

    'Save License details to database
    Public Function xSaveLicenseToDB(ByVal app As Working_App, ByVal License As MPSLicense, ByVal backReg_gp As String, ByRef msg As String) As Boolean
        xSaveLicenseToDB = False
        Dim strBuilder As New System.Text.StringBuilder
        Dim curr_strLicType As String
        Dim new_strLicType As String = sysMpsUserPassword("DECRYPT", License.LicenseType)
        Dim bSuccess As Boolean = True
        msg = ""

        Try
            Dim fetchLicense As New MPSLicense

            curr_strLicType = LicensingGetConfig("LTYPE", app)
            curr_strLicType = sysMpsUserPassword("DECRYPT", curr_strLicType)

            If curr_strLicType = "TRIAL" And new_strLicType = "TRIAL" Then

                'check if Existing SKey

                'fetch license from server

                bSuccess = xGetLicenseFromServer(app.App_DbName, fetchLicense, "LSKey='" & sysMpsUserPassword("DECRYPT", License.LicenseSKey) & "'")

                If bSuccess And fetchLicense.LicenseID <> "" Then
                    'cannot load license with same serial key
                    bSuccess = False
                    xSaveLicenseToDB = False
                    msg = "Cannot load license." & vbNewLine & vbNewLine & "License file already loaded!"
                Else
                    'insert
                    bSuccess = True
                    bSuccess = bSuccess And LICENSEDB.RunSql("INSERT INTO " & app.App_DbName & ".dbo.tblSTI (" & _
                                                    "[LAppName],[LType],[LNoUsers],[LExp],[LHID],[LLocID],[LSKey],[LGPeriod],[LNum],[LValid],[LGen],[LStat],[LMsg],[LRem],[DateUpdated]) VALUES(" & _
                                                    "'" & License.LicenseAppName & "','" & License.LicenseType & "','" & License.LicenseNoOfUsers & "','" & License.LicenseExp & "','" & License.LicenseHID & "','" & License.LicenseLocID & "','" & License.LicenseSKey & "','" & License.LicenseGPeriod & "','" & License.LicenseNum & "','" & sysMpsUserPassword("ENCRYPT", getServerDateTime.ToString) & "','" & License.LicenseGen & "','" & License.LicenseStat & "','" & License.LicenseMsg & "','" & License.LicenseRem & "',GETDATE()" & _
                                                    ")")

                End If

                If bSuccess Then
                    bSuccess = True
                    bSuccess = CreateReg()
                    WriteReg(backReg_gp, "10")
                    xSaveLicenseToDB = True
                Else
                    xSaveLicenseToDB = False
                    If msg = "" Then
                        msg = "An error occurred loading the license file."
                    End If
                End If

            Else
                bSuccess = xGetLicenseFromServer(app.App_DbName, fetchLicense, "LSKey='" & sysMpsUserPassword("DECRYPT", License.LicenseSKey) & "'")

                If bSuccess And fetchLicense.LicenseID <> "" Then
                    bSuccess = False
                    msg = "Cannot load license." & vbNewLine & vbNewLine & "License file already loaded!"
                    xSaveLicenseToDB = False
                Else
                    strBuilder.Append("This will overwrite your license from " & curr_strLicType & " to " & new_strLicType & " license.")
                    strBuilder.AppendLine(vbNewLine & "Continue?")

                    If MsgBox(strBuilder.ToString, 36) = MsgBoxResult.Yes Then
                        bSuccess = True
                        bSuccess = bSuccess And LICENSEDB.RunSql("DELETE FROM " & app.App_DbName & ".dbo.tblSTI")
                        bSuccess = bSuccess And LICENSEDB.RunSql("INSERT INTO " & app.App_DbName & ".dbo.tblSTI (" & _
                                                    "[LAppName],[LType],[LNoUsers],[LExp],[LHID],[LLocID],[LSKey],[LGPeriod],[LNum],[LValid],[LGen],[LStat],[LMsg],[LRem],[DateUpdated]) VALUES(" & _
                                                    "'" & License.LicenseAppName & "','" & License.LicenseType & "','" & License.LicenseNoOfUsers & "','" & License.LicenseExp & "','" & License.LicenseHID & "','" & License.LicenseLocID & "','" & License.LicenseSKey & "','" & License.LicenseGPeriod & "','" & License.LicenseNum & "','" & sysMpsUserPassword("ENCRYPT", getServerDateTime.ToString) & "','" & License.LicenseGen & "','" & License.LicenseStat & "','" & License.LicenseMsg & "','" & License.LicenseRem & "',GETDATE()" & _
                                                    ")")
                        If bSuccess Then
                            LicensingSaveConfig("LTYPE", sysMpsUserPassword("ENCRYPT", new_strLicType), app)
                            bSuccess = True
                            bSuccess = CreateReg()
                            WriteReg(backReg_gp, "10")
                            xSaveLicenseToDB = True
                        Else
                            msg = "An error occurred loading the license file."
                            xSaveLicenseToDB = False
                        End If
                    Else
                        msg = "Save Cancelled!"
                    End If
                End If
            End If
        Catch ex As Exception
            msg = ex.Message
            xSaveLicenseToDB = False
        End Try
    End Function

    'check DateTime if altered
    Public Function isDateTimeTampered(ByVal cApp As Working_App, ByVal License As MPSLicense, ByRef LicenseStatus As MyLicenseStatus) As Boolean
        Dim r As Boolean = False
        Dim bSuccess As Boolean = False
        Dim curr_datetime As String
        Dim last_successval As String
        Dim LNUM As String
        Dim dbName As String = cApp.App_DbName
        Try
            LNUM = License.LicenseNum

            'try to convert Last valid date to Datetime
            Try
                curr_datetime = getServerDateTime()
                last_successval = CStr(License.LicenseValid)
            Catch ex As Exception
                LicenseStatus.StrLicenseMsg = "Error reading the last date success validated."
                GoTo ReturnL
            End Try

            If curr_datetime < last_successval Then
                'validate No of runs
                Log_AppendLicensing(cApp, cApp.App_Name & " App status: Date Tampered Error: Last success license validated: " & last_successval.ToString, , , True)
                LicenseStatus.ExpDays = "0"
                LicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR"
                r = True
            Else
                'date/time is ok
                bSuccess = UpdateLicense(dbName, License.LicenseID, "[LNum]", "NULL")
            End If
        Catch ex As Exception
            r = False
        End Try

ReturnL:
        Return r
    End Function

#End Region

#Region "Utils"

    Public Function getServerDate() As Integer
        Try
            LICENSEDB.BeginReader("SELECT REPLACE(CONVERT(varchar(10),GETDATE(),120),'-','') AS ServerDateTime")
            If LICENSEDB.Read() Then
                getServerDate = CInt(LICENSEDB.ReaderItem("ServerDateTime"))
            Else
                getServerDate = Nothing
            End If
            LICENSEDB.CloseReader()
        Catch ex As Exception
            LICENSEDB.CloseReader()
            getServerDate = Nothing
            LogErrors("ErrorgetServerDate: " & ex.Message)
        End Try

    End Function

    Public Function ServerAddDays(ByVal noDays As Integer) As Integer
        Try
            LICENSEDB.BeginReader("SELECT REPLACE(CONVERT(VARCHAR(10),DATEADD(day, " & noDays.ToString & ", GETDATE()),120),'-','') AS ServerDateTime")
            If LICENSEDB.Read() Then
                ServerAddDays = CInt(LICENSEDB.ReaderItem("ServerDateTime"))
            Else
                ServerAddDays = Nothing
            End If
            LICENSEDB.CloseReader()
        Catch ex As Exception
            LICENSEDB.CloseReader()
            ServerAddDays = Nothing
            LogErrors("ErrorServerAddDays: " & ex.Message)
        End Try
    End Function

    Public Function ServerDateDiff(ByVal nStart As String) As Integer
        Dim nRet As Integer = 0
        LICENSEDB.BeginReader("SELECT DATEDIFF(DAY, GETDATE(),'" & nStart & "' ) AS ServerDateTime")
        If LICENSEDB.Read() Then
            nRet = CType(LICENSEDB.ReaderItem("ServerDateTime"), Integer)
        Else
            nRet = 0
        End If
        LICENSEDB.CloseReader()
        Return nRet
    End Function

    Public Function getServerDateTime(Optional ByRef ErrMsg As String = "") As String
        Try
            LICENSEDB.BeginReader("SELECT REPLACE(CONVERT(varchar(10),GETDATE(),120),'-','') + REPLACE(SUBSTRING(CONVERT(VARCHAR, GETDATE(),108),1,8),':','') AS ServerDateTime")
            If LICENSEDB.Read() Then
                getServerDateTime = CStr(LICENSEDB.ReaderItem("ServerDateTime"))
            Else
                getServerDateTime = Nothing
            End If
            LICENSEDB.CloseReader()
        Catch ex As Exception
            LICENSEDB.CloseReader()
            ErrMsg = ex.Message
            getServerDateTime = Nothing
        End Try
    End Function

    Public Function DateToNum(ByVal paramDate As Date) As Integer
        Dim nRet As Integer = 0
        nRet = CInt(paramDate.Year.ToString("0000") & paramDate.Month.ToString("00") & paramDate.Day.ToString("00"))
        Return nRet
    End Function

    Public Function isNumDate(ByVal paramNum As Integer) As Boolean
        Dim bRet As Boolean = False
        Dim paramStr As String = ""
        If paramNum.ToString.Length = 8 Then
            paramStr = paramNum.ToString
            Try
                Dim newDate As New Date(CInt(paramStr.Substring(0, 4)), CInt(paramStr.Substring(4, 2)), CInt(paramStr.Substring(6, 2)))
                bRet = True
            Catch ex As Exception
                bRet = False
            End Try
        Else
            bRet = False
        End If
        Return bRet
    End Function

    'Compare HID
    Public Function isMatch(ByVal str1 As String, ByVal str2 As String) As Boolean
        If String.Compare(str1, str2, False) = 0 Then
            isMatch = True
        Else
            isMatch = False
        End If
    End Function

    'update License
    Public Function UpdateLicense(ByVal dbName As String, ByVal LID As String, ByVal columns As String, ByVal colValues As String) As Boolean
        Dim ret As Boolean = True
        Dim cols() As String = columns.Split(",")
        Dim colval() As String = colValues.Split(",")

        Dim strbuilder As New System.Text.StringBuilder
        Dim i As Integer = 0
        Try
            For i = 0 To cols.Length - 1
                If cols.Length - 1 = i Then
                    strbuilder.Append(cols(i) & "='" & sysMpsUserPassword("ENCRYPT", colval(i)) & "'")
                Else
                    strbuilder.Append(cols(i) & "='" & sysMpsUserPassword("ENCRYPT", colval(i)) & "',")
                End If
            Next

            ret = LICENSEDB.RunSql("UPDATE " & dbName & ".dbo.tblSTI SET " & strbuilder.ToString & ",DateUpdated=GETDATE() WHERE LID='" & LID & "'")
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Public Function BackupLicenseReg(ByVal strAction As String, ByVal App_Name As String, ByVal AppRegKey As String, ByRef xLicense As MPSLicense) As Boolean
        Dim r As Boolean = False
        Try
            Select Case strAction

                Case "GET"
                    xLicense.LicenseAppName = GetReg(AppRegKey & "lappname", False)
                    xLicense.LicenseType = GetReg(AppRegKey & "ltype", False)
                    xLicense.LicenseNoOfUsers = GetReg(AppRegKey & "lnousers", False)
                    xLicense.LicenseExp = GetReg(AppRegKey & "lexp", False)
                    xLicense.LicenseHID = GetReg(AppRegKey & "lhid", False)
                    xLicense.LicenseLocID = GetReg(AppRegKey & "llocid", False)
                    xLicense.LicenseSKey = GetReg(AppRegKey & "lskey", False)
                    xLicense.LicenseGPeriod = GetReg(AppRegKey & "lgperiod", False)
                    xLicense.LicenseNum = GetReg(AppRegKey & "lnum", False)
                    xLicense.LicenseValid = GetReg(AppRegKey & "lvalid", False)
                    xLicense.LicenseGen = GetReg(AppRegKey & "lgen", False)
                    xLicense.LicenseStat = GetReg(AppRegKey & "lstat", False)
                    xLicense.LicenseMsg = GetReg(AppRegKey & "lmsg", False)
                    xLicense.LicenseRem = GetReg(AppRegKey & "lrem", False)
                    r = True

                Case "SET"
                    WriteReg(AppRegKey & "lappname", xLicense.LicenseAppName, False)
                    WriteReg(AppRegKey & "ltype", xLicense.LicenseType, False)
                    WriteReg(AppRegKey & "lexp", xLicense.LicenseExp, False)
                    WriteReg(AppRegKey & "lnousers", xLicense.LicenseExp, False)
                    WriteReg(AppRegKey & "lhid", xLicense.LicenseHID, False)
                    WriteReg(AppRegKey & "llocid", xLicense.LicenseLocID, False)
                    WriteReg(AppRegKey & "lskey", xLicense.LicenseSKey, False)
                    WriteReg(AppRegKey & "lgperiod", xLicense.LicenseGPeriod, False)
                    WriteReg(AppRegKey & "lnum", xLicense.LicenseNum, False)
                    WriteReg(AppRegKey & "lvalid", xLicense.LicenseValid, False)
                    WriteReg(AppRegKey & "lgen", xLicense.LicenseGen, False)
                    WriteReg(AppRegKey & "lstat", xLicense.LicenseStat, False)
                    WriteReg(AppRegKey & "lmsg", xLicense.LicenseMsg, False)
                    WriteReg(AppRegKey & "lrem", xLicense.LicenseRem, False)
                    r = True
            End Select
        Catch ex As Exception
            r = False
        End Try

        Return r

    End Function


    'simple Checking of License
    Public Function isValidLicense(ByVal user_license As MPSLicense) As Boolean
        Dim r As Boolean = False
        'check if all Properties have values
        If user_license.LicenseType <> "" And _
            user_license.LicenseNoOfUsers <> "" And _
            user_license.LicenseExp <> "" And _
            user_license.LicenseHID <> "" And _
            user_license.LicenseLocID <> "" And _
            user_license.LicenseSKey <> "" And _
            user_license.LicenseGPeriod <> "" And _
            user_license.LicenseNum <> "" And _
            user_license.LicenseValid <> "" And _
            user_license.LicenseGen <> "" And _
            user_license.LicenseStat <> "" And _
            user_license.LicenseMsg <> "" And _
            user_license.LicenseRem <> "" Then

            r = True
        End If

        Return r
    End Function


    Public Function isValidDate(ByVal strDate As String) As Boolean
        Try
            'try converting string to date value
            Dim D As Date = DateValue(strDate)
            isValidDate = True
        Catch ex As Exception
            isValidDate = False
        End Try
    End Function

    'create physical license file
    Public Function CreateLicenseFile(ByVal cpath As String, ByVal cLicense As MPSLicense) As Boolean
        Dim r As Boolean = False
        Try
            Using sw As System.IO.StreamWriter = System.IO.File.CreateText(cpath)
                sw.WriteLine(cLicense.LicenseAppName)
                sw.WriteLine(cLicense.LicenseType)
                sw.WriteLine(cLicense.LicenseNoOfUsers)
                sw.WriteLine(cLicense.LicenseExp)
                sw.WriteLine(cLicense.LicenseHID)
                sw.WriteLine(cLicense.LicenseLocID)
                sw.WriteLine(cLicense.LicenseSKey)
                sw.WriteLine(cLicense.LicenseGPeriod)
                sw.WriteLine(cLicense.LicenseNum)
                sw.WriteLine(cLicense.LicenseValid)
                sw.WriteLine(cLicense.LicenseGen)
                sw.WriteLine(cLicense.LicenseStat)
                sw.WriteLine(cLicense.LicenseMsg)
                sw.WriteLine(cLicense.LicenseRem)
            End Using
            r = True
        Catch ex As Exception
            r = False
        End Try
        Return r
    End Function

    Public Sub SaveStatus(ByVal cApp As Working_App, Optional ByVal msg As String = "", Optional ByVal dtime As Date = Nothing)
        Dim b As Boolean = True
        Dim comp As New mdComputerInfo
        Try
            Dim logBy As String = GetAppName() & " in " & My.Computer.Name
            Dim cHid As String = comp.GetHardwareID
            b = LICENSEDB.RunSql("INSERT INTO " & cApp.App_DbName & ".dbo.tblSTILog ([LogMsg],[LoggedBy],[LogHID],[LoggedDateTime],[App_Name]) VALUES (" & _
                                 "'" & msg.Replace("'", "''") & "'," & _
                                 "'" & logBy & "'," & _
                                 "'" & cHid & "'," & _
                                 "'" & dtime.ToString & "'," & _
                                 "'" & cApp.App_Name & "')")
        Catch ex As Exception
            LogErrors("SaveStatus Error: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Logs"

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub Log_AppendLicensing(ByVal cApp As Working_App, ByVal strStatus As String, Optional ByVal strFileName As String = "", Optional ByVal createLog As Boolean = True, Optional ByVal savetodb As Boolean = False)

        If Not createLog Then
            Exit Sub
        End If

        Dim StrDirectory As String

        StrDirectory = cApp.App_LogFolder

        If strFileName = "" Then
            strFileName = getServerDate.ToString("dd-MMM-yyyy") & ".txt"
        End If

        If Not System.IO.Directory.Exists(StrDirectory) Then
            System.IO.Directory.CreateDirectory(StrDirectory)
        End If
        Using sw As New System.IO.StreamWriter(StrDirectory & "\" & strFileName, True)
            If strStatus = "" Then
                sw.WriteLine("")
            Else
                Dim dtime As DateTime = Date.Now
                sw.WriteLine(String.Format("{0} {1}", dtime.ToString("dd-MMM-yyyy hh:mm:ss"), strStatus))

                If savetodb Then
                    SaveStatus(cApp, strStatus, dtime)
                End If

            End If

        End Using
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub AnErrorOccured(ByVal cApp As Working_App, ByVal ErrMsg As String, Optional ByVal Logged As Boolean = False, Optional ByVal savetodb As Boolean = False)
        If Logged Then
            MsgBox(ErrMsg, MsgBoxStyle.Critical)
            'log error
            Log_AppendLicensing(cApp, ErrMsg, , , savetodb)
        Else
            MsgBox(ErrMsg, MsgBoxStyle.Critical)
        End If
    End Sub

#End Region

#Region "Troubleshooting"

    'try to get License Information
    Public Sub RunLicenseStatusInfo(ByVal cApp As Working_App, ByVal StrLogFile As String)
        Dim bSuccess As Boolean = True

        Dim strLicType As String = ""
        Dim Mylicense As New MPSLicense
        Dim MyLicenseStatus As New MyLicenseStatus

        strLicType = LicensingGetConfig("LTYPE", cApp)
        strLicType = sysMpsUserPassword("DECRYPT", strLicType)

        If strLicType = "" Then
            strLicType = "NO"
        End If

        MyLicenseStatus = xValidateLicense(cApp, strLicType, Mylicense, StrLogFile, True)

    End Sub

    'try to restore physical license file
    Public Sub RestoreMyLicenseFile(ByVal cApp As Working_App, ByVal StrLogFile As String)
        Dim bSuccess As Boolean = True
        Dim MyLicenseFromRegistry As New MPSLicense
        Dim curr_date As Integer = getServerDate()

        Log_AppendLicensing(cApp, "********************* Start *********************" & vbNewLine, StrLogFile)

        Log_AppendLicensing(cApp, "ACTION: TRYING TO RESTORE LICENSE FILE", StrLogFile)
        bSuccess = BackupLicenseReg("GET", cApp.App_Name, cApp.App_RegKey, MyLicenseFromRegistry)
        Log_AppendLicensing(cApp, "GETTING BACKUP LICENSE -- " & IIf(bSuccess, "OK", "ERROR").ToString.PadLeft(2), StrLogFile)

        If bSuccess Then
            'try create license File
            bSuccess = isValidLicense(MyLicenseFromRegistry)
            Log_AppendLicensing(cApp, "LICENSE STATUS -- " & IIf(bSuccess, "OK", "NO LICENSE/ INVALID"), StrLogFile)

            If bSuccess Then
                Dim expDate As String = sysMpsUserPassword("DECRYPT", MyLicenseFromRegistry.LicenseExp)
                If isNumDate(CInt(expDate)) Then

                    If ServerDateDiff(expDate) > 0 Then
                        Log_AppendLicensing(cApp, "LICENSE EXPIRY: " & expDate & " -- VALID", StrLogFile)
                        If MsgBox("Restore License File?", 36) = MsgBoxResult.Yes Then
                            bSuccess = CreateLicenseFile(cApp.App_LicensePath, MyLicenseFromRegistry)
                            Log_AppendLicensing(cApp, "RESTORING LICENSE FILE -- " & IIf(bSuccess, "OK", "ERROR"), StrLogFile)
                            If bSuccess Then
                                'update reg
                                WriteReg(cApp.App_BackRegGPeriod, "10")
                            End If
                        Else
                            Log_AppendLicensing(cApp, "RESTORING LICENSE FILE -- CANCELLED", StrLogFile)
                        End If
                    Else
                        Log_AppendLicensing(cApp, "LICENSE EXPIRY: -- EXPIRED", StrLogFile)
                    End If

                Else
                    Log_AppendLicensing(cApp, "LICENSE EXPIRY -- CORRUPTED", StrLogFile)
                End If
            Else
                'cannot create License File

            End If

        End If

        Log_AppendLicensing(cApp, "", StrLogFile)
        Log_AppendLicensing(cApp, "********************* End *********************", StrLogFile)
    End Sub

    'generate License report
    Public Function GenerateLicenseReport(ByVal cApp As Working_App, ByVal StrLogFile As String, ByVal StrInfile As String) As Boolean
        Dim r As Boolean = True
        Dim dt As DataTable
        Dim strBuilder As New System.Text.StringBuilder
        dt = LICENSEDB.CreateTable("SELECT * FROM " & cApp.App_DbName & ".dbo.tblSTILog")
        Dim xmsg As String

        For Each dr As DataRow In dt.Rows
            xmsg = dr("LogMsg")
            xmsg = xmsg.Replace("'", "''")
            strBuilder.AppendLine("INSERT INTO dbo.tblSTILog ([LogId]," & _
                                            "[LogMsg]" & _
                                            ",[LoggedBy]" & _
                                            ",[LogHID]" & _
                                            ",[LoggedDateTime]" & _
                                            ",[DateCreated]" & _
                                            ",[App_Name])" & _
                                            " VALUES (" & dr("LogId") & "," & _
                                            "'" & xmsg & "'," & _
                                            "'" & dr("LoggedBy") & "'," & _
                                            "'" & dr("LogHID") & "'," & _
                                            "'" & dr("LoggedDateTime") & "'," & _
                                            "'" & dr("DateCreated") & "'," & _
                                            "'" & dr("App_Name") & "'" & _
                                            ")")
        Next

        'attach license info
        Dim dtLInfo As DataTable
        dtLInfo = LICENSEDB.CreateTable("SELECT * FROM " & cApp.App_DbName & ".dbo.tblSTI")

        For Each drinfo As DataRow In dtLInfo.Rows
            strBuilder.AppendLine("INSERT INTO [LICENSEAPP].[dbo].[tblLicenseLoaded] " & _
                                               "([RecId]" & _
                                               ",[LType]" & _
                                               ",[LExp]" & _
                                               ",[LHID]" & _
                                               ",[LImo]" & _
                                               ",[LSKey]" & _
                                               ",[LGPeriod]" & _
                                               ",[LNum]" & _
                                               ",[LValid]" & _
                                               ",[LGen]" & _
                                               ",[LStat]" & _
                                               ",[LMsg]" & _
                                               ",[LRem]" & _
                                               ",[DateUpdated]) " & _
                                               "VALUES(" & _
                                               "" & drinfo("LID") & "," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LType")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LExp")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LHID")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LImo")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LSKey")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LGPeriod")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LNum")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LValid")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LGen")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LStat")) & "'," & _
                                               "'" & EscapeNewLine(sysMpsUserPassword("DECRYPT", drinfo("LMsg"))) & "'," & _
                                               "'" & EscapeNewLine(sysMpsUserPassword("DECRYPT", drinfo("LRem"))) & "'," & _
                                               "'" & drinfo("DateUpdated") & "')")
        Next

        Using sw As New System.IO.StreamWriter(StrInfile, True, System.Text.Encoding.Unicode)
            sw.Write(strBuilder.ToString)
        End Using

        Dim strLogFileF As String = GetFileDir(StrLogFile) & GetFileNameWithoutExtension(StrLogFile) & ".logf"

        If ZipFile(StrInfile, strLogFileF) Then
            Kill(StrInfile)
            r = True
        Else
            r = False
        End If

        Return r

    End Function

#End Region

    Public Function EscapeNewLine(ByVal str As String) As String
        str = str.Replace("'", "''")
        str = str.Replace(vbLf, " ")
        str = str.Replace(vbCr, " ")
        str = str.Replace(vbTab, " ")
        str = str.Replace(vbNewLine, " ")
        Return str
    End Function


End Module
