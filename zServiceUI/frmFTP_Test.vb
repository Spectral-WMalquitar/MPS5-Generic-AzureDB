Imports System.Windows.Forms
Imports System.ComponentModel

Public Class frmFTP_Test
    Private bw As BackgroundWorker = New BackgroundWorker
    Private oFTP As zBusiness.oFTP
    Private nItemDescLen As Integer = 50
    Private bSuccess As Boolean = True
    Private cDefFolder As String = ""

    Public Sub New(ByVal pFTP As zBusiness.oFTP, Optional ByVal cDefaultFolder As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cDefFolder = cDefaultFolder
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted

        txtLogText.Text = ""
        ListBoxControl_FTP.Items.Clear()
        Me.Text = "Test FTP Settings (" & pFTP.INET_ProfileName & ")"
        lblCaption.Text = "Directtory listing for [" & IIf(cDefFolder.Length = 0, "root", cDefFolder) & "]"

        oFTP = pFTP
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        'Dim ix As Integer

        'For ix = 1 To 10
        '    If bw.CancellationPending = True Then
        '        e.Cancel = True
        '        Exit For
        '    Else
        '        ' Perform a time consuming operation and report progress.
        '        System.Threading.Thread.Sleep(500)
        '        bw.ReportProgress(ix * 10)
        '    End If
        'Next

        '==========================================================

        Dim cItem As String = ""
        Dim ftp As New Chilkat.Ftp2()
        Dim success As Boolean

        Log("Initiating test...")
        '  Any string unlocks the component for the 1st 30-days.
        success = ftp.UnlockComponent("SPCTASFTP_SacUFGpW7Dne")
        If (success <> True) Then
            Log(ftp.LastErrorText, True)
            Exit Sub
        End If
        If bw.CancellationPending = True Then
            Log("User cancelled test.")
            e.Cancel = True
            Exit Sub
        End If

        ftp.Hostname = oFTP.INET_Host
        ftp.Username = oFTP.INET_User
        ftp.Password = oFTP.INET_Pwd
        ftp.ConnectTimeout = oFTP.FTP_ConnectionTimeout
        ftp.Passive = oFTP.FTP_UsePassive
        ftp.AutoFeat = oFTP.FTP_AutoFeat
        ftp.Port = oFTP.INET_Port
        ftp.Ssl = oFTP.INET_UseSSL
        ftp.AuthTls = oFTP.INET_TLS

        '  Connect and login to the FTP server.
        Log("Connecting to " & oFTP.INET_Host & "...")
        success = ftp.Connect()
        If (success <> True) Then
            Log(ftp.LastErrorText, True)
            Exit Sub
        End If
        If bw.CancellationPending = True Then
            Log("User cancelled test.")
            e.Cancel = True
            Exit Sub
        End If

        '  Does the "temp" directory exist?
        If cDefFolder.Length > 0 Then
            Log("Changing directory to [" & cDefFolder & "]...")
            success = ftp.ChangeRemoteDir(cDefFolder)
            If (success <> True) Then
                Log(ftp.LastErrorText, True)
                Exit Sub
            End If
            If bw.CancellationPending = True Then
                Log("User cancelled test.")
                e.Cancel = True
                Exit Sub
            End If
        End If

        '  The ListPattern property is our directory listing filter.
        '  The default value is "*", which includes everything.
        Log("Requesting files and folders...")
        ftp.ListPattern = "*"
        If bw.CancellationPending = True Then
            Log("User cancelled test.")
            e.Cancel = True
            Exit Sub
        End If

        '  To get file and sub-directory information, simply
        '  loop from 0 to ftp.NumFilesAndDirs - 1
        Dim i As Long
        Dim n As Long

        Log("Getting file and directory count... ")
        n = ftp.NumFilesAndDirs
        If (n < 0) Then
            Log(ftp.LastErrorText, True)
            Exit Sub
        End If
        If bw.CancellationPending = True Then
            Log("User cancelled test.")
            e.Cancel = True
            Exit Sub
        End If

        Log("Listing files and folders... ")
        If (n > 0) Then
            For i = 0 To n - 1
                cItem = ftp.GetFilename(i).PadRight(nItemDescLen) & " " & ftp.GetSize(i).ToString.PadRight(10) & " "

                '  Is this a sub-directory?
                If (ftp.GetIsDirectory(i) = True) Then
                    cItem = cItem & "<DIR>"
                End If

                LogFileOrFolder(cItem)
                If bw.CancellationPending = True Then
                    Log("User cancelled test.")
                    e.Cancel = True
                    Exit Sub
                End If
            Next
        End If

        Log("Disconnecting... ")
        ftp.Disconnect()
        If bw.CancellationPending = True Then
            Log("User cancelled test.")
            e.Cancel = True
            Exit Sub
        End If
        Log("********** Test completed **********" & vbCrLf)
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        'Me.LabelControl3.Text = e.ProgressPercentage.ToString() & "%"
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        MarqueeProgressBarControl1.Visible = False
        lblInProgress.Visible = False

        If e.Cancelled = True Then
            'Me.LabelControl3.Text = "Canceled!"
            MsgBox("Test cancelled.")
        ElseIf e.Error IsNot Nothing Then
            'Me.LabelControl3.Text = "Error: " & e.Error.Message
        Else
            'Me.LabelControl3.Text = "Done!"
            If bSuccess Then
                MsgBox("Test completed without problems.")
            Else
                MsgBox("Test failed. See log for more information.")
            End If
        End If
    End Sub

    Private Delegate Sub LogFileOrFolderDelegate(ByVal cItem As String)
    Private Sub LogFileOrFolder(ByVal cItem As String)
        If Me.InvokeRequired Then
            Me.Invoke(New LogFileOrFolderDelegate(AddressOf LogFileOrFolder), cItem)
        Else
            ListBoxControl_FTP.Items.Add(cItem)
        End If
    End Sub

    Private Delegate Sub LogDelegate(ByVal cMsg As String, ByVal bFailed As Boolean)
    Private Sub Log(ByVal cMsg As String, Optional ByVal bFailed As Boolean = False)
        If Me.InvokeRequired Then
            Me.Invoke(New LogDelegate(AddressOf Log), cMsg, bFailed)
        Else
            txtLogText.Text = txtLogText.Text & Format(Now, "hh:mm:ss tt | ") & cMsg & vbCrLf
            If bFailed Then
                txtLogText.Text = txtLogText.Text & vbCrLf & vbCrLf & Format(Now, "hh:mm:ss tt | ") & "!!!!!!!!!! Test FAILED (more info above) !!!!!!!!!!"
            End If
            bSuccess = bSuccess And Not bFailed
        End If
    End Sub

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        If bw.WorkerSupportsCancellation = True Then
            bw.CancelAsync()
        End If
        Me.Close()
    End Sub

    Private Sub frmFTP_Test_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If Not bw.IsBusy = True Then
            bw.RunWorkerAsync()
        End If
    End Sub
End Class
