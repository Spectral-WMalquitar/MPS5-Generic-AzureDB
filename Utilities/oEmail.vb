Public Class oEmail

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
    Public cMsg_Cc As String
    Public cMsg_Bcc As String
    Public cmsg_To_FriendlyName As String
    Public cMsg_Subj As String
    Public cMsg_Body As String


    'Public Property INET_Code As String
    '    Get
    '        Return cINET_Code
    '    End Get
    '    Set(value As String)
    '        cINET_Code = value
    '        Load()
    '    End Set
    'End Property

    'Public Function Save(ByVal cSaveAsProfName As String) As Boolean
    '    Dim cSQL As String = ""
    '    Dim bRetVal As Boolean = False
    '    Dim cOldID As String = ""
    '    cOldID = oDLSQLSERVER.DLookUp("INET_Code", "tblSTIService_internet_settings", "INET_ProfileName='" & RemoveInject(cSaveAsProfName) & "'")
    '    If cOldID <> "" Then
    '        'update
    '        cINET_Code = cOldID
    '        cSQL = "UPDATE tblSTIService_internet_settings SET"
    '        cSQL = cSQL & " INET_ProfileName='" & RemoveInject(cSaveAsProfName) & "',"
    '        cSQL = cSQL & " INET_User='" & RemoveInject(INET_User) & "',"
    '        cSQL = cSQL & " INET_Pwd='" & sysMpsUserPassword("ENCRYPT", RemoveInject(INET_Pwd)) & "',"
    '        cSQL = cSQL & " INET_Port=" & INET_Port & ","
    '        cSQL = cSQL & " SMTP_SenderEmail='" & RemoveInject(SMTP_SenderEmail) & "',"
    '        cSQL = cSQL & " INET_Host='" & RemoveInject(INET_Host) & "',"
    '        cSQL = cSQL & " INET_UseSSL=" & IIf(INET_UseSSL, 1, 0) & ","
    '        cSQL = cSQL & " INET_TLS=" & IIf(INET_TLS, 1, 0) & ","
    '        cSQL = cSQL & " INET_SPA=" & IIf(INET_SPA, 1, 0) & ","
    '        cSQL = cSQL & " EMAIL_TYPE=" & INET_EmailType
    '        cSQL = cSQL & " WHERE INET_Code='" & cINET_Code & "'"
    '    Else
    '        'insert
    '        Dim cNewCode = GenerateID(oDLSQLSERVER, "tblSTIService_internet_settings", "INET_Code")
    '        cSQL = "INSERT INTO tblSTIService_internet_settings (INET_Code,INET_ProfileName,INET_User,INET_Pwd,SMTP_SenderEmail,INET_Host,INET_Port,INET_Type,INET_UseSSL,INET_TLS,INET_SPA,EMAIL_TYPE)"
    '        cSQL = cSQL & " VALUES ("
    '        cSQL = cSQL & " '" & cNewCode & "',"
    '        cSQL = cSQL & " '" & RemoveInject(cSaveAsProfName) & "',"
    '        cSQL = cSQL & " '" & RemoveInject(INET_User) & "',"
    '        cSQL = cSQL & " '" & sysMpsUserPassword("ENCRYPT", RemoveInject(INET_Pwd)) & "',"
    '        cSQL = cSQL & " '" & RemoveInject(SMTP_SenderEmail) & "',"
    '        cSQL = cSQL & " '" & RemoveInject(INET_Host) & "',"
    '        cSQL = cSQL & " " & INET_Port & ","
    '        cSQL = cSQL & " " & INET_Type.SMTP & ","
    '        cSQL = cSQL & " " & IIf(INET_UseSSL, 1, 0) & ","
    '        cSQL = cSQL & " " & IIf(INET_TLS, 1, 0) & ","
    '        cSQL = cSQL & " " & IIf(INET_SPA, 1, 0) & ","
    '        cSQL = cSQL & " " & INET_EmailType
    '        cSQL = cSQL & ")"

    '        'refresh class properties
    '        cINET_Code = cNewCode
    '    End If
    '    bRetVal = oDLSQLSERVER.ExecuteNonQuery(cSQL)
    '    Return bRetVal
    'End Function

    'DELETE the profile given by <cProfCode>
    'IF No parameter is given and there is a valid profile loaded, then the currently loaded profile will be deleted.
    'Public Function Delete(Optional ByVal pINET_Code As String = "") As Boolean
    '    Dim bRetVal As Boolean = False
    '    If pINET_Code = "" Then
    '        pINET_Code = cINET_Code
    '    End If
    '    If pINET_Code <> "" Then
    '        bRetVal = oDLSQLSERVER.ExecuteNonQuery("DELETE FROM tblSTIService_internet_settings WHERE INET_Code='" & pINET_Code & "'")
    '    End If
    '    Return bRetVal
    'End Function

    'Private Function Load() As Boolean
    '    Dim dr As DataRow
    '    Dim dt As DataTable = GetDataTable("INET_MATCH", cINET_Code)
    '    Dim bRetVal As Boolean = False
    '    If Not IsNothing(dt) AndAlso dt.Rows.Count <> 0 Then
    '        dr = dt.Rows(0)
    '        'load profile   
    '        INET_ProfileName = NullToString(dr.Item("INET_ProfileName"))
    '        INET_User = NullToString(dr.Item("INET_User"))
    '        INET_Pwd = sysMpsUserPassword("DECRYPT", NullToString(dr.Item("INET_Pwd"))) 'use decrypted field
    '        INET_Host = NullToString(dr.Item("INET_Host"))
    '        INET_Port = NullToZero(dr.Item("INET_Port"))
    '        SMTP_SenderEmail = NullToString(dr.Item("SMTP_SenderEmail"))
    '        INET_UseSSL = NullToZero(dr.Item("INET_UseSSL"))
    '        INET_TLS = NullToZero(dr.Item("INET_TLS"))
    '        INET_SPA = NullToZero(dr.Item("INET_SPA"))
    '        INET_EmailType = NullToZero(dr.Item("EMAIL_TYPE"))
    '        bRetVal = True
    '    End If
    '    Return bRetVal
    'End Function

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

        Dim cToList As String = Replace(cMsg_To, "'", "''")
        Dim cNameList As String = Replace(cmsg_To_FriendlyName, "'", "''")
        Dim nCtr As Integer = 0
        Dim cEmail As String = ""
        Dim cName As String = ""
        For nCtr = 1 To CountItemDelimited(cToList, ",")
            cEmail = GetItemDelimited(cToList, nCtr, ",")
            cName = GetItemDelimited(cNameList, nCtr, ",")
            email.AddTo(IIf(IfNull(cName, "") = "", cEmail, cName), cEmail)
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

    Public Shared Function SendMail_v2(host As String, port As Integer, useSSL As Boolean, useTLS As Boolean, usr As String, pwd As String, _
                                        sentFrom As String, sendTo As String, subject As String, msgBody As String, attachFolderDir As String, _
                                        Optional sendCc As String = "", Optional sendBcc As String = "", Optional recipientDelimiter As String = ";", Optional ByRef cErr As String = "") As Boolean
        Dim bSuccess As Boolean = False
        Dim mailman As New Chilkat.MailMan()
        Dim email As New Chilkat.Email()
        Dim success As Boolean

        '  Any string argument automatically begins the 30-day trial.
        success = mailman.UnlockComponent("SPCTASMAILQ_8962DBBgnC9s")

        If (success <> True) Then
            cErr = "Component unlock failed"
            Return bSuccess
        End If

        'emain config
        mailman.SmtpHost = host
        mailman.SmtpPort = port
        mailman.SmtpSsl = useSSL
        mailman.StartTLS = useTLS
        mailman.SmtpUsername = usr
        mailman.SmtpPassword = pwd

        'email content
        email.From = sentFrom

        Dim emailAdd As String = ""
        'TO
        For cnt As Integer = 1 To CountItemDelimited(sendTo, recipientDelimiter)
            emailAdd = GetItemDelimited(sendTo, cnt, recipientDelimiter)
            email.AddTo(emailAdd, emailAdd)
        Next
        'CC
        If sendCc.Length <> 0 Then
            For cnt As Integer = 1 To CountItemDelimited(sendCc, recipientDelimiter)
                emailAdd = GetItemDelimited(sendCc, cnt, recipientDelimiter)
                email.AddCC(emailAdd, emailAdd)
            Next
        End If
        'BCC
        If sendBcc.Length <> 0 Then
            For cnt As Integer = 1 To CountItemDelimited(sendBcc, recipientDelimiter)
                emailAdd = GetItemDelimited(sendBcc, cnt, recipientDelimiter)
                email.AddBcc(emailAdd, emailAdd)
            Next
        End If

        email.Subject = subject
        email.Body = msgBody

        If attachFolderDir.Length <> 0 Then
            Dim dir As New IO.DirectoryInfo(attachFolderDir)
            If dir.Exists Then
                For Each fInfo As IO.FileInfo In dir.GetFiles()
                    email.AddFileAttachment(fInfo.FullName)
                Next
            End If
        End If

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
