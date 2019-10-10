Imports Reports
Imports KPI
Imports Utilities
Imports System.Net.Mail
Imports System.Security.AccessControl

Public Class ReportAutoEmail
    Private Shared DB As SQLDB

    Private Shared exportFolder As String = "MPS_ExportedReport"
    Private Shared exportBase As String = Application.StartupPath 'Application.StartupPath ' FileIO.SpecialDirectories.ProgramFiles & "\Spectral Technologies INC\MPS"
    Private Shared exportDirectory As String = exportBase & "\" & exportFolder

    Public Shared Function InitConnection() As Boolean
        Dim cSQLServer = GetIni("SERVER", True)
        Dim cSQLID = GetIni("USERID", True)
        Dim cSQLPW = GetIni("PASSWORD", True)
        Dim str As String = "Data Source=" & cSQLServer & ";Persist Security Info=True;User ID=" & cSQLID & ";Password=" & cSQLPW & ";Initial Catalog=MPS;"
        DB = New SQLDB(str)
        If DB.CheckConnection = False Then
            LogErrors("ReportAutoEmail.InitConnection() : connection not established." & vbNewLine &
                      "connStr : " & str)
            Return False
        End If
        Return True
    End Function

    Public Shared Sub Init()
        USER_ID = 99999 'as admin
        MPSDB = DB
        SelectedTab = ""
    End Sub

    Public Shared Sub StartAutoSendingEmail(Optional showMsg As Boolean = False, Optional manualSend As Boolean = False, Optional profileKey As String = "")
        Try
            'Dim mailer As New oEmail()
            Dim dtProfile As DataTable
            Dim dtConfig As DataTable
            Dim query As String
            Dim success As Boolean = True
            Dim addMsg As String = ""
            Dim subFolder As String = ""

            If showMsg Then
                ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Sending Email . . .")
            End If
            If manualSend And profileKey <> "" Then
                query = "SELECT * FROM [MPS].[dbo].[tblUserEmailProfile] " & _
                        " WHERE EnableProfile <> 0 AND PKey = '" & profileKey & "'"
            Else
                query = "SELECT * FROM [MPS].[dbo].[tblUserEmailProfile] " & _
                        " WHERE EnableProfile <> 0 AND " & _
                        " CAST((FORMAT(ISNULL(DateNextSend, GETDATE()), 'yyyyMMdd') + FORMAT(ExecTime, 'HHmmss')) AS bigint) " & _
                        " <= CAST((FORMAT(GETDATE(), 'yyyyMMdd') + FORMAT(ExecTime, 'HHmmss')) AS bigint)"
            End If

            If IsNothing(DB) And Not IsNothing(MPSDB) Then
                DB = MPSDB
            ElseIf IsNothing(DB) And IsNothing(MPSDB) Then
                InitConnection()
            End If
            dtProfile = DB.CreateTable(query)

            If dtProfile.Rows.Count >= 1 Then
                For cnt As Integer = 0 To dtProfile.Rows.Count - 1
                    'create export directory
                    subFolder = "EmailAttachment_" & dtProfile.Rows(cnt).Item("PKey")
                    If CreateExportDirectory(subFolder, showMsg) Then
                        'export reports
                        ExportEmailProfileReportsToPDF(exportDirectory & "\" & subFolder, dtProfile.Rows(cnt).Item("PKey"))
                        'get the SMTP config of the sender
                        dtConfig = DB.CreateTable("SELECT TOP 1 * FROM [MPS].[dbo].[tblAdmSMTPConfig] aSMTP INNER JOIN [MPS].[dbo].[tblUserEmailConfig] uEmail ON aSMTP.PKey = uEmail.FKeySMTPAcct WHERE uEmail.PKey='" & dtProfile.Rows(cnt).Item("FKeyEmailAdd") & "'")
                        'sends then deletes the export folder
                        success = SendMailByCK(dtConfig.Rows(0).Item("SMTPHost"), CInt(dtConfig.Rows(0).Item("SMTPPort")), CBool(dtConfig.Rows(0).Item("UseSSL")), CBool(dtConfig.Rows(0).Item("UseTLS")), dtConfig.Rows(0).Item("SMTPUsername"), dtConfig.Rows(0).Item("SMTPPassword"), _
                                           dtProfile.Rows(cnt).Item("EmailFrom"), dtProfile.Rows(cnt).Item("EmailTo"), dtProfile.Rows(cnt).Item("EmailSubject"), dtProfile.Rows(cnt).Item("EmailMsg"), exportDirectory & "\" & subFolder, _
                                           dtProfile.Rows(cnt).Item("EmailCc"), dtProfile.Rows(cnt).Item("EmailBcc"), , addMsg)

                        If showMsg Then
                            CloseCustomLoadScreen()
                        End If
                        ShowMailMsg(success, showMsg, addMsg)

                        If success And Not manualSend And profileKey = "" Then
                            DB.RunSql("UPDATE [MPS].[dbo].[tblUserEmailProfile] SET " & _
                                         " [DateLastSent]=" & ChangeToSQLDate(Date.Now) & _
                                         ",[DateNextSend]=" & ChangeToSQLDate(ReportAutoEmail.GetDateNextSend(dtProfile.Rows(cnt).Item("ExecType"), dtProfile.Rows(cnt).Item("Intervals"), dtProfile.Rows(cnt).Item("DateNextSend"), True)) & _
                                         ",[LastDateFrom]=" & ChangeToSQLDate(ReportAutoEmail.GetDateCoverage(dtProfile.Rows(cnt).Item("ExecType"), dtProfile.Rows(cnt).Item("Intervals"), dtProfile.Rows(cnt).Item("LastDateFrom"), dtProfile.Rows(cnt).Item("LastDateTo"), True)("FROM")) & _
                                         ",[LastDateTo]= " & ChangeToSQLDate(ReportAutoEmail.GetDateCoverage(dtProfile.Rows(cnt).Item("ExecType"), dtProfile.Rows(cnt).Item("Intervals"), dtProfile.Rows(cnt).Item("LastDateFrom"), dtProfile.Rows(cnt).Item("LastDateTo"), True)("TO")) & _
                                         " WHERE PKey='" & dtProfile.Rows(cnt).Item("PKey") & "'")
                        End If

                    Else
                        'log error
                    End If
                Next
                DeleteExportDirectory(showMsg)
            End If
        Catch ex As Exception
            If showMsg Then
                MsgBox("ReportAutoEmail.StartAutoSendingEmail() error : " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GetAppName)
                CloseCustomLoadScreen()
            End If
            LogErrors("ReportAutoEmail.StartAutoSendingEmail() error : " & ex.Message)
        End Try
    End Sub

    Public Shared Function GetDateCoverage(execType As Integer, intervals As String, lastFrom As Date, lastTo As Date, nextDate As Boolean) As Dictionary(Of String, Date)
        Dim range As New Dictionary(Of String, Date)
        Dim tempDate As Date = lastFrom
        Dim fromDate As Date = lastFrom
        Dim toDate As Date = lastTo

        Dim vals As String()
        vals = intervals.Split(";")

        Select Case execType
            Case 1, 2 'DAILY AND WEEKLY
                Dim nextDay As Integer = IIf(nextDate, 1, 0)
                Dim day As Integer = toDate.DayOfWeek + 1 + IIf(nextDate, 1, 0) 'check next day

                Do Until (vals.Contains(CStr(day))) 'check succeeding days if within intervals
                    nextDay += 1 'add day
                    If day = 7 Or day > 7 Then
                        day = 1 'return to sunday
                    Else
                        day += 1 'check next day
                    End If
                Loop
                toDate = toDate.AddDays(nextDay)
                If execType = 1 Then
                    fromDate = toDate
                Else
                    fromDate = toDate.AddDays(-6)
                End If
            Case 3 'MONTHLY
                fromDate = CDate(Format(fromDate, "yyyy-MMM-") & "01").AddMonths(IIf(nextDate, 1, 0))
                toDate = CDate(Format(fromDate, "yyyy-MMM-") & GetEOMONTH(fromDate.Year, fromDate.Month, -1))
                fromDate = IIf(vals(1) = 1, fromDate, fromDate.AddMonths(-1))
                toDate = IIf(vals(1) = 1, toDate, toDate.AddMonths(-1))
                toDate = CDate(Format(toDate, "yyyy-MMM-") & GetEOMONTH(toDate.Year, toDate.Month, -1))
            Case 4 'QUARTERLY
                fromDate = CDate(Format(fromDate, "yyyy-") & "01-01")
                toDate = CDate(Format(fromDate, "yyyy-") & "03-" & GetEOMONTH(tempDate.Year, 3, -1))
                Select Case CInt(DateToQCode(tempDate).ToString.Substring(4))
                    Case 2
                        fromDate = fromDate.AddMonths(3)
                        toDate = toDate.AddMonths(3)
                    Case 3
                        fromDate = fromDate.AddMonths(6)
                        toDate = toDate.AddMonths(6)
                    Case 4
                        fromDate = fromDate.AddMonths(9)
                        toDate = toDate.AddMonths(9)
                End Select
                If nextDate Then
                    fromDate = fromDate.AddMonths(3)
                    toDate = toDate.AddMonths(3)
                End If
                toDate = CDate(Format(toDate, "yyyy-MMM-") & GetEOMONTH(toDate.Year, toDate.Month, -1))
            Case 5 'SEMI-ANNUAL
                tempDate = CDate(Format(tempDate, "yyyy-") & vals(2) & "-01")
                If Date.Now < tempDate.AddMonths(6) Then
                    fromDate = tempDate
                Else
                    fromDate = tempDate.AddMonths(6)
                End If
                toDate = fromDate.AddMonths(5)
                If nextDate Then
                    fromDate = fromDate.AddMonths(6)
                    toDate = toDate.AddMonths(6)
                End If
                toDate = CDate(Format(toDate, "yyyy-MMM-") & GetEOMONTH(toDate.Year, toDate.Month, -1))
            Case 6 'ANNUALLY
                fromDate = CDate(Format(Date.Now, "yyyy-") & vals(2) & "-01").AddMonths(IIf(nextDate, 12, 0))
                toDate = fromDate.AddMonths(11)
                toDate = CDate(Format(toDate, "yyyy-MMM-") & GetEOMONTH(toDate.Year, toDate.Month, -1))
        End Select

        range.Add("FROM", fromDate)
        range.Add("TO", toDate)
        Return range
    End Function

    Public Shared Function GetDateNextSend(execType As Integer, intervals As String, currentSendDate As Date, nextDate As Boolean) As Date
        Dim retVal As Date = currentSendDate
        Dim tempDate As Date = currentSendDate
        Dim vals As String()
        vals = intervals.Split(";")

        Select Case execType
            Case 1, 2 'DAILY AND WEEKLY
                Dim nextDay As Integer = IIf(nextDate, 1, 0)
                Dim day As Integer = tempDate.DayOfWeek + 1 + IIf(nextDate, 1, 0) 'check next day

                Do Until (vals.Contains(CStr(day))) 'check succeeding days if within intervals
                    nextDay += 1 'add day
                    If day = 7 Or day > 7 Then
                        day = 1 'return to sunday
                    Else
                        day += 1 'check next day
                    End If
                Loop
                retVal = retVal.AddDays(nextDay)
            Case 3 'MONTHLY
                tempDate = tempDate.AddMonths(IIf(nextDate, 1, 0))
                retVal = CDate(Format(tempDate, "yyyy-MMM-") & GetEOMONTH(tempDate.Year, tempDate.Month, vals(0)))
            Case 4 'QUARTERLY
                Dim quarterPart As Integer = CInt(DateToQCode(tempDate).ToString.Substring(4, 2))
                quarterPart = quarterPart + IIf(nextDate, IIf(quarterPart = 4, -3, 1), 0)
                Dim qCode As Integer = CInt(tempDate.Year.ToString & Format(quarterPart, "00"))
                tempDate = QCodeToDate(qCode, vals(1), 1)
                retVal = CDate(Format(tempDate, "yyyy-MMM") & "-" & GetEOMONTH(tempDate.Year, tempDate.Month, vals(0)))
            Case 5 'SEMI-ANNUAL
                tempDate = CDate(Format(tempDate, "yyyy-") & vals(1) & "-" & GetEOMONTH(tempDate.Year, vals(1), vals(0)))
                If tempDate < tempDate.AddMonths(6) Then
                    retVal = tempDate.AddMonths(IIf(nextDate, 6, 0))
                Else
                    retVal = tempDate.AddMonths(6 + IIf(nextDate, 6, 0))
                End If
            Case 6 'ANNUALLY
                tempDate = CDate(Format(tempDate, "yyyy-") & vals(1) & "-" & GetEOMONTH(tempDate.Year, vals(1), vals(0)))
                retVal = tempDate.AddMonths(IIf(nextDate, 12, 0))
        End Select

        Return retVal
    End Function

    Public Shared Function GetEOMONTH(Year As Integer, Month As Integer, Day As Integer) As Integer
        Dim dDay As Integer = Day
        Dim tempDay As Integer = Date.DaysInMonth(Year, Month)

        If dDay > tempDay Or dDay <= 0 Then
            Return tempDay
        Else
            Return dDay
        End If
    End Function

    Public Shared Function GetExportDirectory() As String
        Return exportDirectory
    End Function

    Public Shared Function GetBaseDirectory() As String
        Return exportBase
    End Function

    'CREATES THE TEMPORARY FOLDER
    Public Shared Function CreateExportDirectory(subFolder As String, Optional showMsg As Boolean = False) As Boolean
        Dim errMsg As String = ""
        Try
            If IO.Directory.Exists(exportBase) Then
                Dim dirInfo As New IO.DirectoryInfo(exportBase)
                Dim dirSec As DirectorySecurity = dirInfo.GetAccessControl
                '<!-- commented out by tony20171009 : no need to by pass folder permission rights. Client should be the one who make necessary access assignments
                'dirSec.AddAccessRule(New FileSystemAccessRule(Environment.UserDomainName & "\Administrator", FileSystemRights.FullControl, AccessControlType.Allow))
                'dirInfo.SetAccessControl(dirSec)
                '-->
                IO.Directory.CreateDirectory(exportDirectory)
                IO.Directory.CreateDirectory(exportDirectory & "\" & subFolder)
                Return True
            Else
                errMsg = "CreateExportDirectory() encountered a problem" & vbNewLine & "Base directory not found"
                LogErrors(errMsg)
                If showMsg Then
                    MsgBox(errMsg, MsgBoxStyle.Critical, GetAppName)
                End If
                Return False
            End If
        Catch ex As Exception
            errMsg = "CreateExportDirectory() encountered an error" & vbNewLine & ex.Message
            LogErrors(errMsg)
            If showMsg Then
                MsgBox(errMsg, MsgBoxStyle.Critical, GetAppName)
            End If
            'log error
            Return False
        End Try
    End Function

    'DELETES THE TEMPORARY FOLDER AND FILES
    Public Shared Function DeleteExportDirectory(Optional showMsg As Boolean = False) As Boolean
        Dim errMsg As String
        Try
            If IO.Directory.Exists(exportDirectory) Then
                IO.Directory.Delete(exportDirectory, True)
                Return True
            Else
                errMsg = "DeleteExportDirectory() encountered a problem" & vbNewLine & "Base directory not found"
                LogErrors(errMsg)
                If showMsg Then
                    MsgBox(errMsg, MsgBoxStyle.Critical, GetAppName)
                End If
                Return False
            End If
        Catch ex As Exception
            errMsg = "DeleteExportDirectory() encountered an error" & vbNewLine & ex.Message
            LogErrors(errMsg)
            If showMsg Then
                MsgBox(errMsg, MsgBoxStyle.Critical, GetAppName)
            End If
            'log error
            Return False
        End Try
    End Function

    'EXPORT REPORTS OF AN EMAIL PROFILE
    Private Shared Sub ExportEmailProfileReportsToPDF(exportPath As String, FKeyUserEmailProfile As String)
        Dim reportsList As DataTable
        Dim rptObjs As List(Of DevExpress.XtraReports.UI.XtraReport)

        reportsList = DB.CreateTable("SELECT sub.*, main.LastDateFrom, main.LastDateTo FROM [MPS].[dbo].[tblUserEmailProfileReports] sub INNER JOIN [MPS].[dbo].[tblUserEmailProfile] main ON sub.FKeyEmailProfile = main.PKey WHERE FKeyEmailProfile = '" & FKeyUserEmailProfile & "' AND FKeyOptTemplate IS NOT NULL AND FKeyOptTemplate <> ''")
        rptObjs = GenerateReportFromTemplate(reportsList)

        Dim cnt As Integer = 1
        For Each rpt As DevExpress.XtraReports.UI.XtraReport In rptObjs
            If Not IsNothing(rpt) Then
                rpt.ExportToPdf(exportPath & "\" & rpt.Name & ".pdf") 'exportDirectory & "\" & rpt.Name & ".pdf"
            End If
            cnt += 1
        Next
    End Sub

#Region "MAILING"

    Private Shared bSuccess As Boolean
    Private Shared showMsgs As Boolean
    Public Shared MAIL_TEST_SUBJECT As String = GetAppName() & " Report Email Automation Test Message #" & Format(DateTime.Now, "yyyyMMddHHmmss")
    Public Shared MAIL_TEST_MSG As String = "This is a test message sent from " & GetAppName() & " Report Email Automation by " & USER_NAME

    Public Shared Function SendMailByCK(host As String, port As Integer, useSSL As Boolean, useTLS As Boolean, usr As String, pwd As String, _
                                        sentFrom As String, sendTo As String, subject As String, msgBody As String, attachFolderDir As String, _
                                        Optional sendCc As String = "", Optional sendBcc As String = "", Optional recipientDelimiter As String = ";", Optional ByRef cErr As String = "") As Boolean
        Dim mailman As New Chilkat.MailMan()
        Dim email As New Chilkat.Email()
        Dim success As Boolean

        '  Any string argument automatically begins the 30-day trial.
        success = mailman.UnlockComponent("SPCTASMAILQ_8962DBBgnC9s")

        If (success <> True) Then
            cErr = "Component unlock failed"
            Return False
            Exit Function
        End If

        'emain config
        mailman.SmtpHost = host
        mailman.SmtpUsername = usr
        mailman.SmtpPassword = pwd
        mailman.SmtpPort = port
        If useSSL Then
            mailman.SmtpSsl = useSSL
        End If
        If useTLS Then
            mailman.StartTLS = useTLS
        End If


        'email sender
        email.From = sentFrom

        Dim emailAdd As String = ""
        'email TO
        For cnt As Integer = 1 To CountItemDelimited(sendTo, recipientDelimiter)
            emailAdd = GetItemDelimited(sendTo, cnt, recipientDelimiter)
            email.AddTo(emailAdd, emailAdd)
        Next
        'email CC
        If sendCc.Length <> 0 Then
            For cnt As Integer = 1 To CountItemDelimited(sendCc, recipientDelimiter)
                emailAdd = GetItemDelimited(sendCc, cnt, recipientDelimiter)
                email.AddCC(emailAdd, emailAdd)
            Next
        End If
        'email BCC
        If sendBcc.Length <> 0 Then
            For cnt As Integer = 1 To CountItemDelimited(sendBcc, recipientDelimiter)
                emailAdd = GetItemDelimited(sendBcc, cnt, recipientDelimiter)
                email.AddBcc(emailAdd, emailAdd)
            Next
        End If

        'email content
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
            LogErrors(cErr)
            Return False
        Else
            LogEvent("Email was sent successfully by " & USER_NAME & " using " & sentFrom)
            Return True
        End If
    End Function

#Region ".Net Emailing"
    Private Shared smtp As SmtpClient
    Private Shared email As MailMessage

    Public Shared Function SendMailByNetMail(host As String, port As Integer, useSSL As Boolean, useTLS As Boolean, usr As String, pwd As String, _
                                        sentFrom As String, sendTo As String, subject As String, msgBody As String, attachFolderDir As String, _
                                        Optional sendCc As String = "", Optional sendBcc As String = "", Optional recipientDelimiter As String = ";", Optional ByRef addMsg As String = "", _
                                        Optional showMsg As Boolean = True) As Boolean
        showMsgs = showMsg
        Dim emailAdd As String = ""

        smtp = New SmtpClient(host, port)
        email = New MailMessage

        Try
            With email
                .From = New MailAddress(sentFrom)
                'TO
                For cnt As Integer = 1 To CountItemDelimited(sendTo, recipientDelimiter)
                    emailAdd = GetItemDelimited(sendTo, cnt, recipientDelimiter)
                    .To.Add(emailAdd)
                Next
                'CC
                For cnt As Integer = 1 To CountItemDelimited(sendCc, recipientDelimiter)
                    emailAdd = GetItemDelimited(sendCc, cnt, recipientDelimiter)
                    .To.Add(emailAdd)
                Next
                'BCC
                For cnt As Integer = 1 To CountItemDelimited(sendBcc, recipientDelimiter)
                    emailAdd = GetItemDelimited(sendBcc, cnt, recipientDelimiter)
                    .To.Add(emailAdd)
                Next

                .Subject = subject
                .Body = msgBody

                'ATTACHMENTS
                If attachFolderDir.Length <> 0 Then
                    Dim dir As New IO.DirectoryInfo(attachFolderDir)
                    If dir.Exists Then
                        For Each fInfo As IO.FileInfo In dir.GetFiles()
                            .Attachments.Add(New Attachment(fInfo.FullName))
                        Next
                    End If
                End If

            End With

            With smtp
                .UseDefaultCredentials = False
                .Credentials = New Net.NetworkCredential(usr, pwd)
                .EnableSsl = useSSL

                AddHandler .SendCompleted, AddressOf SendCompletedCallback
                Dim userState As String = "Send Email"
                .SendAsync(email, userState)
                '.Send(email)
            End With

        Catch ex As Exception
            smtp.Dispose()
            email.Dispose()
            addMsg = ex.Message
            ShowMailMsg(False, showMsgs, addMsg)
            'log error
            bSuccess = False
        End Try

        Return bSuccess
    End Function

    Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim token As String = CStr(e.UserState)
        If e.Error IsNot Nothing Then
            'log error
            ShowMailMsg(False, showMsgs, token & vbNewLine & e.Error.ToString())
            bSuccess = False
        Else
            ShowMailMsg(True, showMsgs)
            bSuccess = True
        End If

        smtp.Dispose()
        email.Dispose()
        'delete export directory
        DeleteExportDirectory(showMsgs)
    End Sub
#End Region

    Public Shared Sub ShowMailMsg(status As Boolean, Optional showMsg As Boolean = False, Optional addMsg As String = "")
        If showMsg Then
            If status Then
                MsgBox("Message sent", MsgBoxStyle.Information, GetAppName)
            Else
                MsgBox("Message not sent" & vbNewLine & "Encountered an error" & vbNewLine & addMsg, MsgBoxStyle.Critical, GetAppName)
            End If
        End If
    End Sub

#End Region



    Public Shared Sub UpdateDLLs()
        Try
            Dim cCurVersion As String
            Dim cCurVersionDate As String
            Dim nCurDBVersion As String
            Dim nCurDBVersionDate As String

            'Get Current Version
            cCurVersion = IIf(Trim(CType(GetIni("VERSION"), String)) = "" Or IsNothing(Trim(CType(GetIni("VERSION"), String))), "", Trim(CType(GetIni("VERSION"), String)))
            cCurVersionDate = IIf(Trim(CType(GetIni("VERSIONDATE"), String)) = "" Or IsNothing(Trim(CType(GetIni("VERSIONDATE"), String))), "", Trim(CType(GetIni("VERSIONDATE"), String)))
            'Get Latest Version
            nCurDBVersion = CType(DB.DLookUp("AppVersion", "[STIAPPVERSIONS].[dbo].[MPSVersion]", "", "1=1 ORDER BY AppVersion DESC"), String)
            nCurDBVersionDate = CType(DB.DLookUp("VersionDate", "[STIAPPVERSIONS].[dbo].[MPSVersion]", "", "1=1 ORDER BY AppVersion DESC"), String)

            Dim cAppFolder As String = APP_PATH
            Dim cUpdatesFolder As String = DB.DLookUp("TextValue", "[MPS].[dbo].[tblConfig]", "", "Code='UpdatesFolder'")

            Dim NewVersion() As String = Split(nCurDBVersion, "."c)
            Dim OldVersion() As String = Split(cCurVersion, "."c)

            'check if has new version
            If CInt(OldVersion(0)) < CInt(NewVersion(0)) Or
                 CInt(OldVersion(1)) < CInt(NewVersion(1)) Or
                 CInt(OldVersion(2)) < CInt(NewVersion(2)) Then

                If cUpdatesFolder.Length <> 0 Then
                    cUpdatesFolder += IIf(Microsoft.VisualBasic.Right(cUpdatesFolder, 1) = "\", "", "\")

                    Do Until cCurVersion = nCurDBVersion

                        If CInt(OldVersion(2)) = 99 Then
                            OldVersion(2) = 0 '#.##.00
                            If CInt(OldVersion(1)) = 99 Then
                                OldVersion(1) = 0 '#.00.##
                                OldVersion(0) = CInt(OldVersion(0)) + 1 '0.##.##
                            Else
                                OldVersion(1) = CInt(OldVersion(1)) + 1
                            End If
                        Else
                            OldVersion(2) = CInt(OldVersion(2)) + 1
                        End If

                        cCurVersion = ConstructVersion(OldVersion)

                        If System.IO.Directory.Exists(cUpdatesFolder & cCurVersion) Then
                            Try
                                Dim filesDlls As String() = System.IO.Directory.GetFiles(cUpdatesFolder & cCurVersion, "*.dll", IO.SearchOption.TopDirectoryOnly)
                                Dim filesExes As String() = System.IO.Directory.GetFiles(cUpdatesFolder & cCurVersion, "*.exe", IO.SearchOption.TopDirectoryOnly)
                                Dim files As New List(Of String)
                                files.AddRange(filesDlls)
                                files.AddRange(filesExes)

                                For Each file In files
                                    Try
                                        System.IO.File.Copy(file, cAppFolder & "\" & New System.IO.FileInfo(file).Name, True)
                                    Catch ex As Exception
                                        LogErrors("ReportAutoEmail.UpdateDLLs() Copy Error : " & ex.Message)
                                    End Try
                                Next
                            Catch ex As Exception
                                LogErrors("ReportAutoEmail.UpdateDLLs() GetFiles error : " & ex.Message)
                            End Try
                        End If

                    Loop
                    WriteIni("VERSION", cCurVersion)
                    WriteIni("VERSIONDATE", Format(CDate(nCurDBVersionDate), "yyyy-MM-dd"))
                End If
            End If

        Catch ex As Exception
            LogErrors("ReportAutoEmail.UpdateDLLs() error : " & ex.Message)
        End Try
    End Sub

    Private Shared Function ConstructVersion(version() As String) As String
        Return String.Format("{0}.{1}.{2}", Format(CInt(version(0)), "0"), Format(CInt(version(1)), "00"), Format(CInt(version(2)), "00"))
    End Function

End Class
