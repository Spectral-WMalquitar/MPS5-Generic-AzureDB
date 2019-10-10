Imports zUtil
Imports zBusiness
Public Class frmLicenseTroubleShooter
    Dim _app As New Working_App

    Sub New(ByVal _xapp As Working_App)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _app = _xapp
        cmbAction.Properties.DataSource = GetLicenseTroubleShooterActions()
    End Sub

    Private Sub btnProceed_Click(sender As System.Object, e As System.EventArgs) Handles btnProceed.Click
        Dim strLogFile As String = ""
        Dim cPath As String = ""
        If cmbAction.EditValue Is Nothing Then
            MsgBox("Please select action in order to proceed.", MsgBoxStyle.Information, GetAppName)
        Else
            Select Case cmbAction.EditValue
                Case "GEN_LIC_INFO"
                    strLogFile = "MyLicenseStatus_" & getServerDateTime() & ".txt"
                    cPath = _app.App_LogFolder & "\" & strLogFile
                    RunLicenseStatusInfo(_app, strLogFile)
                    If MsgBox("Would you like to view log?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                        If IO.File.Exists(cPath) Then
                            Dim cLog As String = IO.File.ReadAllText(cPath)
                            ShowLog(cLog)
                        End If
                    End If
                Case "REP_LIC"
                    strLogFile = "RepairMyLicense_" & getServerDateTime() & ".txt"
                    cPath = _app.App_LogFolder & "\" & strLogFile
                    RestoreMyLicenseFile(_app, strLogFile)
                    If MsgBox("Would you like to view log?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                        If IO.File.Exists(cPath) Then
                            Dim cLog As String = IO.File.ReadAllText(cPath)
                            ShowLog(cLog)
                        End If
                    End If
                Case "GEN_LIC_REP"
                    Dim bSuccess As Boolean = True
                    Dim strLogFileName As String = ""
                    strLogFileName = _app.App_Name & "_LogFile_" & getServerDateTime()
                    cPath = _app.App_LogFolder & "\Generated Report Logs"

                    If Not System.IO.Directory.Exists(cPath) Then
                        System.IO.Directory.CreateDirectory(cPath)
                    End If

                    strLogFile = cPath & "\" & strLogFileName & ".txt"

                    Dim strInfile As String = cPath & "\LicenseLogReport.txt"

                    bSuccess = GenerateLicenseReport(_app, strLogFile, strInfile)

                    If bSuccess Then
                        Dim odMain As New System.Windows.Forms.SaveFileDialog
                        odMain.Filter = "Log File (*.logf)|*.logf"
                        odMain.FileName = strLogFileName
                        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            Try
                                System.IO.File.Copy(GetFileDir(strLogFile) & GetFileNameWithoutExtension(strLogFile) & ".logf", odMain.FileName, True)
                                Log_AppendLicensing(_app, "License Log File file created in: " & odMain.FileName, , , True)
                                MsgBox("License Log file created in: " & odMain.FileName, MsgBoxStyle.Information)
                            Catch ex As Exception
                                AnErrorOccured(_app, ex.Message)
                            End Try
                        End If
                    Else
                        AnErrorOccured(_app, "An error occured creating an license report.", True, True) 'this will create a log and also save to db
                    End If

            End Select

            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class