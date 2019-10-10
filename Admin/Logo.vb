Public Class Logo
    Dim is_clicked As Boolean = False, photo_changed As Boolean = False, photo_path As String
    Dim clsAudit As New clsAudit 'neil
    Private Const AdminLogoAndHeaderFileName As String = "COMPANYLOGO"  'added by tony20180109

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        'commented out by tony20180109
        'MsgBox("NOTE: Image must be located in a Shared Folder Accesible by all users", MsgBoxStyle.Exclamation, GetAppName())

        If Not IfNull(txtLogoPath.Text, "").Equals("") Then
            If MsgBox("Do you want to replace the current logo?", vbYesNo + vbQuestion) = MsgBoxResult.No Then Exit Sub
        End If

        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "Image File (*.jpg)|*.jpg"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            photo_changed = True
            photo_path = odMain.FileName
            'commented out by tony20180109  'txtLogoPath.Text = photo_path
            txtLogoPath.Tag = 1
            Try
                picLogo.Image.Dispose()
            Catch ex As Exception
            End Try
            picLogo.Image = New System.Drawing.Bitmap(odMain.FileName)
            BRECORDUPDATEDs = True
            cmdDeletePhoto.Enabled = True
        End If
    End Sub

    Public Overrides Sub RefreshData()
        Me.LayoutControl1.AllowCustomization = False
        MyBase.RefreshData()
        clsAudit.propSQLConnStr = MPSDB.GetConnectionString

        SetPannelVisibility(Name, DevExpress.XtraEditors.SplitPanelVisibility.Panel2)
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        strRequiredFields = "txtName,txtAddr,txtPhoto_Path"
        Me.LayoutControl1.AllowCustomization = False
        Me.txtName.Text = Trim(DB.GetConfig("Name"))
        Me.txtAddr.Text = Trim(DB.GetConfig("ADDR"))
        Me.txtEmail.Text = Trim(DB.GetConfig("EMAIL"))
        Me.txtPhone.Text = Trim(DB.GetConfig("PHONE"))
        Me.txtTelefax.Text = Trim(DB.GetConfig("TELEFAX"))
        Me.txtSecNbr.Text = Trim(DB.GetConfig("SECNBR"))
        Me.txtTaxNbr.Text = Trim(DB.GetConfig("TAXNBR"))
        Me.txtHDMF.Text = Trim(DB.GetConfig("HDMF"))
        Me.txtLogoPath.Text = Trim(DB.GetConfig("LOGOPATH"))

        If IfNull(Me.txtLogoPath.Text, "") <> "" Then
            Try
                picLogo.Image = New System.Drawing.Bitmap(Me.txtLogoPath.Text)
            Catch ex As Exception
            End Try
            cmdDeletePhoto.Enabled = True
        Else
            cmdDeletePhoto.Enabled = False
            If Not picLogo.Image Is Nothing Then picLogo.Image = Nothing
        End If

        AddEditListener(Me.LayoutControl1.Root)
        MakeReadOnlyListener(Me.LayoutControl1.Root)

        Me.txtLogoPath.Enabled = False
        Me.cmdBrowse.Enabled = False
        Me.cmdDeletePhoto.Enabled = False
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        Me.txtName.Focus()
        AllowSaving(Name, True)
        Me.txtLogoPath.Enabled = False
        Me.cmdBrowse.Enabled = True
        Me.cmdDeletePhoto.Enabled = True
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
        End If

    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        Dim info As Boolean = False
        'edited by tony20170831 - SSS, Tax and HDMF Numbers should not be mandatory. Overseas clients may not have such information
        'If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAddr, txtSecNbr, txtTaxNbr, txtHDMF}) Then
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAddr}) Then
            Dim mpsconfig As New Config(New String() {"NAME", "ADDR", "EMAIL", "PHONE", "TELEFAX", "SECNBR", "TAXNBR", "LOGOPATH", "HDMF"})
            'IF tag = 1 then field is edited (Check AddEditListener for more info)
            '<!-- NAME -->
            If txtName.Tag = 1 Then
                SaveInAudit("Name", mpsconfig.GetValue("NAME"), txtName.Text)
                info = DB.SaveConfig("NAME", Trim(Me.txtName.Text))
            End If

            '<!-- ADDR -->
            If txtAddr.Tag = 1 Then
                SaveInAudit("Address", mpsconfig.GetValue("ADDR"), txtAddr.Text)
                info = DB.SaveConfig("ADDR", Trim(Me.txtAddr.Text))
            End If

            '<!-- EMAIL -->
            If txtEmail.Tag = 1 Then
                SaveInAudit("Email", mpsconfig.GetValue("EMAIL"), txtEmail.Text)
                info = DB.SaveConfig("EMAIL", Trim(Me.txtEmail.Text))
            End If

            '<!-- PHONE -->
            If txtPhone.Tag = 1 Then
                SaveInAudit("Phone", mpsconfig.GetValue("PHONE"), txtPhone.Text)
                info = DB.SaveConfig("PHONE", Trim(Me.txtPhone.Text))
            End If

            '<!-- TELEFAX -->
            If txtTelefax.Tag = 1 Then
                SaveInAudit("Telefax", mpsconfig.GetValue("TELEFAX"), txtTelefax.Text)
                info = DB.SaveConfig("TELEFAX", Trim(Me.txtTelefax.Text))
            End If

            '<!-- SECNBR -->
            If txtSecNbr.Tag = 1 Then
                SaveInAudit("Security ID Number", mpsconfig.GetValue("SECNBR"), txtSecNbr.Text)
                info = DB.SaveConfig("SECNBR", Trim(Me.txtSecNbr.Text))
            End If

            '<!-- TAXNBR -->
            If txtTaxNbr.Tag = 1 Then
                SaveInAudit("Tax Number", mpsconfig.GetValue("TAXNBR"), txtTaxNbr.Text)
                info = DB.SaveConfig("TAXNBR", Trim(Me.txtTaxNbr.Text))
            End If

            '<!-- LOGOPATH -->
            If txtLogoPath.Tag = 1 Then
                SaveInAudit("Logo Path", mpsconfig.GetValue("LOGOPATH"), txtLogoPath.Text)
                Dim newFileName As String = CopyLogoPhotoToAdmDir(photo_path)
                info = DB.SaveConfig("LOGOPATH", newFileName)
                'info = DB.SaveConfig("LOGOPATH", Trim(Me.txtLogoPath.Text))
            End If

            '<!-- HDMF -->
            If txtHDMF.Tag = 1 Then
                SaveInAudit("HDMF Number", mpsconfig.GetValue("HDMF"), txtHDMF.Text)
                info = DB.SaveConfig("HDMF", Trim(Me.txtHDMF.Text))
            End If

            RefreshData()
            If info Then
                MsgBox("Record Saved.", , GetAppName)
            End If
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            'If MainView.HasColumnErrors() Then
            '    flag = False
            '    ALLOWNEXTS = flag
            'Else
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAddr, txtSecNbr}, showMsg) Then
                If bAddMode Then
                    'If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                    '    flag = False
                    '    ALLOWNEXTS = flag
                    'Else
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData() '
                    'End If
                Else
                    'If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & strID & "'") Then
                    '    flag = False
                    '    ALLOWNEXTS = flag
                    'Else
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData() '
                    'End If
                End If
            Else
                flag = False
                ALLOWNEXTS = flag
            End If
            'End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function
    Private Sub cmdDeletePhoto_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeletePhoto.Click
        photo_changed = True
        photo_path = ""
        Me.txtLogoPath.Text = photo_path
        Try
            picLogo.Image.Dispose()
        Catch ex As Exception
        End Try
        picLogo.Image = Nothing
        BRECORDUPDATEDs = True
    End Sub

    Private Sub SaveInAudit(ConfigName As String, OldValue As Object, NewValue As Object)
        Dim auditlogid As Long
        clsAudit.saveAuditLog("Update Logo And Header Config", USER_NAME, auditlogid, System.Environment.MachineName, 0,
                           , , , , ConfigName & " : " & NewValue, "MPS Crewing", Date.Now) 'neil
        clsAudit.saveAuditDetails(auditlogid, "Value", NewValue, OldValue)
    End Sub

#Region "Copy Logo to Admin Directory"
    Public Function CopyLogoPhotoToAdmDir(ByVal srcFilePath As String) As String
        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""

        Dim ctr As Integer = 0
        Try
            strDir = GetAdminDir()

            fileExt = System.IO.Path.GetExtension(srcFilePath)

GENERATE_FILENAME:
            fileName = "COMPANYLOGO" & fileExt
            fileName = strDir & fileName

            If My.Computer.FileSystem.FileExists(fileName) Then Kill(fileName)

            My.Computer.FileSystem.CopyFile(srcFilePath, fileName, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        Catch ex As Exception
            'MsgBox("insert error message here:" & ex.Message, , GetAppName)
            MsgBox(ex.Message, , GetAppName)

        End Try
        Return fileName
    End Function
#End Region
End Class
