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

    Public Function FTP_ChangeRemoteDir(ByVal cDirName As String, Optional ByRef cErr As String = "", Optional ByVal bShowProgressBar As Boolean = True, Optional ByVal nRetryTimes As Integer = 10) As Boolean
        Dim bSuccess As Boolean = False
        Dim nRetry As Integer = 0

        If oChilkatFTP.IsConnected Then
            Do While Not bSuccess And nRetry < nRetryTimes
                nRetry = nRetry + 1
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
                oChilkatFTP.ListPattern = cFileSpec
                nNumFound = oChilkatFTP.NumFilesAndDirs
                If (nNumFound < 0) Then
                    bSuccess = False
                    cErr = oChilkatFTP.LastErrorText
                End If
            Else
                'look for folder
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

End Class
#End Region
