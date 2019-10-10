Public Class ProgramSettings
    Dim _fldPath As String = ""
    Dim cUpdatesPath As String = ""
    Dim cTemplatePath As String = ""

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        _fldPath = IfNull(DB.GetConfig("DefaultFolder"), "")
        cUpdatesPath = IfNull(DB.GetConfig("UpdatesFolder"), "")
        cTemplatePath = IfNull(DB.GetConfig("TEMPLATE_FOLDER"), "")
        Me.txtFolderPath.Text = _fldPath
        Me.txtUpdateFolder.Text = cUpdatesPath
        Me.txtTemplateFolder.Text = cTemplatePath
        AllowFilePathBtn(txtFolderPath, False)
        AllowFilePathBtn(txtUpdateFolder, False)
        AllowFilePathBtn(txtTemplateFolder, False)

        chkOverrideExpDoc.EditValue = Nothing
        LoadOverrideSettings()
        MakeReadOnlyListener(lcgExpDoc)
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            AllowSaving(Name, True)
            txtFolderPath.ReadOnly = False
            AllowFilePathBtn(txtFolderPath, True)

            txtUpdateFolder.ReadOnly = False
            AllowFilePathBtn(txtUpdateFolder, True)

            txtTemplateFolder.ReadOnly = False
            AllowFilePathBtn(txtTemplateFolder, True)

            RemoveReadOnlyListener(lcgExpDoc)
        Else
            AllowSaving(Name, False)
            AllowFilePathBtn(txtFolderPath, False)
            txtFolderPath.ReadOnly = True

            AllowFilePathBtn(txtUpdateFolder, False)
            txtUpdateFolder.ReadOnly = True

            AllowFilePathBtn(txtTemplateFolder, False)
            txtTemplateFolder.ReadOnly = True

            MakeReadOnlyListener(lcgExpDoc)
        End If
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        Dim info As Boolean = False

        If txtFolderPath.Text = "" Then
            MsgBox("Please select default folder path", MsgBoxStyle.Exclamation, GetAppName())
            Exit Sub
        End If
        If txtUpdateFolder.Text = "" Then
            MsgBox("Please select updates folder path", MsgBoxStyle.Exclamation, GetAppName())
            Exit Sub
        End If
        If txtTemplateFolder.Text = "" Then
            MsgBox("Please select template folder path", MsgBoxStyle.Exclamation, GetAppName())
            Exit Sub
        End If


        If Not IO.Directory.Exists(txtFolderPath.Text) Then
            MsgBox("The folder for attachments you specified does not exist", MsgBoxStyle.Critical, GetAppName())
            Exit Sub
        End If
        If Not IO.Directory.Exists(txtUpdateFolder.Text) Then
            MsgBox("The folder for updates you specified does not exist", MsgBoxStyle.Critical, GetAppName())
            Exit Sub
        End If
        If Not IO.Directory.Exists(txtTemplateFolder.Text) Then
            MsgBox("The folder for templates you specified does not exist", MsgBoxStyle.Critical, GetAppName())
            Exit Sub
        End If


        If Not CheckFolderPermission(txtFolderPath.Text) Then
            MsgBox("You don't have the correct Read and Write Permission on the attachments folder", MsgBoxStyle.Critical, GetAppName())
            Exit Sub
        End If
        If Not CheckFolderPermission(txtUpdateFolder.Text) Then
            MsgBox("You don't have the correct Read and Write Permission on the updates folder", MsgBoxStyle.Critical, GetAppName())
            Exit Sub
        End If
        If Not CheckFolderPermission(txtTemplateFolder.Text) Then
            MsgBox("You don't have the correct Read and Write Permission on the templates folder", MsgBoxStyle.Critical, GetAppName())
            Exit Sub
        End If

        If DB.DLookUp("TextValue", "tblConfig", "", "Code='OVERRIDE_EXPDOC'") = "" Then
            DB.RunSql("INSERT INTO tblConfig (Code, TextValue) VALUES ('OVERRIDE_EXPDOC','" & chkOverrideExpDoc.EditValue & "')")
        Else
            DB.RunSql("UPDATE tblConfig SET TextValue = '" & chkOverrideExpDoc.EditValue & "' WHERE Code = 'OVERRIDE_EXPDOC'")
        End If

        If DB.DLookUp("TextValue", "tblConfig", "", "Code='EXPIRY_BUFFER'") = "" Then
            DB.RunSql("INSERT INTO tblConfig (Code, TextValue) VALUES ('EXPIRY_BUFFER','" & txtLOCDays.EditValue & "')")
        Else
            DB.RunSql("UPDATE tblConfig SET TextValue = '" & txtLOCDays.EditValue & "' WHERE Code = 'EXPIRY_BUFFER'")
        End If

        If chkOverrideExpDoc.EditValue <> 0 Then
            'update all user
            DB.RunSql("DELETE FROM dbo.tblUserConfig WHERE Code = 'DocExpDays'")
            DB.RunSql("DELETE FROM dbo.tblUserConfig WHERE Code = 'ExpDocsAlert'")
            DB.RunSql("INSERT INTO dbo.tblUserConfig (FKeyUserID, Code, Value) " & _
                      "(SELECT usr.ID, 'DocExpDays', '" & txtDays.EditValue & "' FROM MSysSec_Users usr)")
            DB.RunSql("INSERT INTO dbo.tblUserConfig (FKeyUserID, Code, Value) " & _
                      "(SELECT usr.ID, 'ExpDocsAlert', '" & chkExpDocAlert.EditValue & "' FROM MSysSec_Users usr)")
        Else
            SaveUserSetting("DocExpDays", txtDays.EditValue)
            SaveUserSetting("ExpDocsAlert", chkExpDocAlert.EditValue)
        End If

        info = DB.SaveConfig("DefaultFolder", txtFolderPath.Text)
        info = info And DB.SaveConfig("UpdatesFolder", txtUpdateFolder.Text)
        info = info And DB.SaveConfig("TEMPLATE_FOLDER", txtTemplateFolder.Text)

        MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)

        If info Then RefreshData()

    End Sub

    Private Sub txtFolderPath_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFolderPath.ButtonClick
        Dim btnEdit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            btnEdit.EditValue = Nothing
            _fldPath = ""
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            Dim odMain As New System.Windows.Forms.FolderBrowserDialog
            If _fldPath <> "" Then
                odMain.SelectedPath = _fldPath
                If odMain.ShowDialog() = DialogResult.OK Then
                    If CheckFolderPermission(odMain.SelectedPath) Then
                        _fldPath = odMain.SelectedPath
                        btnEdit.Text = _fldPath
                    Else
                        MsgBox("Read and Write Permission is Missing in the specified path", MsgBoxStyle.Critical, GetAppName)
                        RefreshData()
                    End If
                End If
            Else
                If odMain.ShowDialog() = DialogResult.OK Then
                    _fldPath = odMain.SelectedPath
                    btnEdit.Text = _fldPath
                End If
            End If
        End If
    End Sub

    Private Sub AllowFilePathBtn(btn As DevExpress.XtraEditors.ButtonEdit, Optional ByVal value As Boolean = True)
        For i As Integer = 0 To btn.Properties.Buttons.Count - 1
            btn.Properties.Buttons(i).Enabled = value
        Next
    End Sub

    Private Sub txtUpdateFolder_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtUpdateFolder.ButtonClick
        Dim btnEdit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            btnEdit.EditValue = Nothing
            cUpdatesPath = ""
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            Dim odMain As New System.Windows.Forms.FolderBrowserDialog
            If cUpdatesPath <> "" Then
                odMain.SelectedPath = cUpdatesPath
                If odMain.ShowDialog() = DialogResult.OK Then
                    If CheckFolderPermission(odMain.SelectedPath) Then
                        cUpdatesPath = odMain.SelectedPath
                        btnEdit.Text = cUpdatesPath
                    Else
                        MsgBox("Read and Write Permission is Missing in the specified path", MsgBoxStyle.Critical, GetAppName)
                        RefreshData()
                    End If
                End If
            Else
                If odMain.ShowDialog() = DialogResult.OK Then
                    cUpdatesPath = odMain.SelectedPath
                    btnEdit.Text = cUpdatesPath
                End If
            End If
        End If
    End Sub

    Private Sub txtTemplateFolder_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtTemplateFolder.ButtonClick
        Dim btnEdit As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            btnEdit.EditValue = Nothing
            cTemplatePath = ""
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            Dim odMain As New System.Windows.Forms.FolderBrowserDialog
            If cTemplatePath <> "" Then
                odMain.SelectedPath = cTemplatePath
                If odMain.ShowDialog() = DialogResult.OK Then
                    If CheckFolderPermission(odMain.SelectedPath) Then
                        cTemplatePath = odMain.SelectedPath
                        btnEdit.Text = cTemplatePath
                    Else
                        MsgBox("Read and Write Permission is Missing in the specified path", MsgBoxStyle.Critical, GetAppName)
                        RefreshData()
                    End If
                End If
            Else
                If odMain.ShowDialog() = DialogResult.OK Then
                    cTemplatePath = odMain.SelectedPath
                    btnEdit.Text = cTemplatePath
                End If
            End If
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            Dim f As New ProgramSettings_Templates(txtTemplateFolder.Text)
            f.ShowDialog()
        End If
    End Sub

    Private Sub chkOverrideExpDoc_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles chkOverrideExpDoc.EditValueChanged
        'Dim val As Boolean = CType(sender, DevExpress.XtraEditors.CheckEdit).EditValue
        LoadOverrideSettings_ExpDoc()
    End Sub

    Private Sub LoadOverrideSettings()
        Dim strOverrideExpDoc As String = DB.DLookUp("TextValue", "tblConfig", "", "Code='OVERRIDE_EXPDOC'")
        chkOverrideExpDoc.EditValue = CType(IIf(strOverrideExpDoc.Equals(""), "False", strOverrideExpDoc), Boolean)
    End Sub

    Private Sub LoadOverrideSettings_ExpDoc()
        Dim strDocExpDays As String = GetUserSetting("DocExpDays")
        Dim strLocPlusDays As String = DB.DLookUp("TextValue", "tblConfig", "", "Code='EXPIRY_BUFFER'")
        Dim strExpDocsAlert As String = GetUserSetting("ExpDocsAlert")

        txtDays.Text = CType(IIf(strDocExpDays.Equals(""), "0", strDocExpDays), Integer)
        txtLOCDays.Text = CType(IIf(strLocPlusDays.Equals(""), "0", strLocPlusDays), Integer)
        chkExpDocAlert.EditValue = CType(IIf(strExpDocsAlert.Equals(""), "False", strExpDocsAlert), Boolean)
    End Sub

End Class
