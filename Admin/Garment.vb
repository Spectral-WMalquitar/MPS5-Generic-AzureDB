Public Class Garment

#Region "Easy Edit"
    Private FormName As String = "Admin Garment"
    Dim photo_changed As Boolean = False, photo_path As String, photo_toremove As Boolean = False
    Dim strPhotoPath As String = ""
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

#Region "Properties"
    Private ReadOnly Property GetLayoutControlGroups As DevExpress.XtraLayout.LayoutControlGroup()
        Get
            Return New DevExpress.XtraLayout.LayoutControlGroup() {Me.LayoutControl1.Root, Me.LayoutControlGroup_ReIssue}
        End Get
    End Property
#End Region


    Public Overrides Sub RefreshData()
        TableName = "tblAdmGarment"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Garment Details - " & strDesc)
        strRequiredFields = "txtName"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.cboFKeyGarmentType.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyGarmentType"), ""))
            Me.CheckEdit_None.Checked = (Not chkReIssueEverySignOn.Checked And Not chkReIssueEverySignOn.Checked)
            Me.chkReIssueEverySignOn.Checked = (IfNull(blList.GetFocusedRowData("ReIssueEverySignOn"), 0) <> 0)
            Me.chkReIssueEveryPeriod.Checked = (IfNull(blList.GetFocusedRowData("ReIssueEveryPeriod"), 0) <> 0)
            Me.txtReIssueEveryPeriodYr.EditValue = IfNull(blList.GetFocusedRowData("ReIssueEveryPeriodYr"), 0)
            Me.txtReIssueEveryPeriodMonth.EditValue = IfNull(blList.GetFocusedRowData("ReIssueEveryPeriodMonth"), 0)

            strPhotoPath = Trim(IfNull(blList.GetFocusedRowData("PhotoPath"), ""))
            GetGarmentPhoto(Me.GarmentPhoto, strID, strPhotoPath) 'Photo Path

            MakeReadOnlyListener(GetLayoutControlGroups)
            BRECORDUPDATEDs = False
        End If
        setButtonEdit(False)
        'RemoveEditListener(GetLayoutControlGroups)
        MakeReadOnlyListener(GetLayoutControlGroups)
        RemoveEditListener(CheckEdit_None, False)
        AddEditListener(GetLayoutControlGroups)
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(GetLayoutControlGroups)
        Else
            MakeReadOnlyListener(GetLayoutControlGroups)
        End If
        setButtonEdit(isEditdable)
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(GetLayoutControlGroups)
        setButtonEdit(True)
        GarmentPhoto.Image = Nothing
        setButtonEdit(True)
        'If Not bAddMode Then   '<-- commented out by tony20171025. to be honest, i don't get why this was used. not just here but overall
        RemoveEditListener(GetLayoutControlGroups)
        CheckEdit_None.Checked = True
        AddEditListener(GetLayoutControlGroups)
        ClearFields(GetLayoutControlGroups, False)
        AllowSaving(Name, True) 'Enable save button 
        AllowDeletion(Name, False) 'Disable Delete button
        bAddMode = True
        blList.HideSelection()
        strID = ""
        strDesc = "New Record"
        Me.header.Text = strDesc
        Me.txtName.Focus()
        Me.txtName.BackColor = SEL_COLOR
        'get the max SortCode
        Me.CheckEdit_None.Checked = True
        Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
        Me.txtReIssueEveryPeriodYr.EditValue = 0
        Me.txtReIssueEveryPeriodMonth.EditValue = 0
        CheckEdit_None.Tag = 0
        BRECORDUPDATEDs = False
        'AddEditListener(GetLayoutControlGroups)
        'End If     '<-- commented out by tony20171025. to be honest, i don't get why this was used. not just here but overall
    End Sub

    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.BaseEdit() {txtName, cboFKeyGarmentType}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil   'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Garment", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)

            If Not chkReIssueEveryPeriod.Checked Then
                txtReIssueEveryPeriodYr.EditValue = 0
                txtReIssueEveryPeriodMonth.EditValue = 0
            End If

            CheckEdit_None.Tag = 0
            If bAddMode Then

                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(GetLayoutControlGroups, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    If info Then
                        strID = DB.GetLastInsertedItem("PKey", Me.TableName)
                        If Not IfNull(strID, "").Equals("") Then
                            SaveGarmentPhoto(strID)
                        End If
                    End If
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
                    type = "Inserted"
                End If
            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(GetLayoutControlGroups, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & strID & "'"))
                    SaveGarmentPhoto(strID)
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    type = "Updated"
                End If
            End If
            bAddMode = False
            photo_changed = False
            photo_toremove = False
            RefreshData()
            If info Then
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
            End If
        End If
    End Sub

    Private Sub setButtonEdit(value As Boolean)
        cmdBrowse.Enabled = value
        cmdDeletePhoto.Enabled = value
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}, showMsg) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                End If
            Else
                flag = False
                ALLOWNEXTS = flag
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Garment", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    TableName, _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Admin Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    ClearFields(GetLayoutControlGroups, False)
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    blList.RefreshData()
                    RefreshData()
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub


    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False

        'GARMENT TYPE
        Dim dt As DataTable = DB.CreateTable("SELECT * FROM dbo.tbladmgarmenttype ORDER BY Name")
        cboFKeyGarmentType.Properties.DataSource = dt
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "Image File (*.jpg)|*.jpg|PNG File (*.png)|*.png"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            photo_changed = True
            photo_path = odMain.FileName
            Try
                GarmentPhoto.Image.Dispose()
            Catch ex As Exception
            End Try
            GarmentPhoto.Image = New System.Drawing.Bitmap(odMain.FileName)
            'AllowSaving(Name, (bPermission And 4) > 0)
            BRECORDUPDATEDs = True
            cmdDeletePhoto.Enabled = True
        End If
    End Sub

#Region "Photo"
    Private Sub cmdDeletePhoto_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeletePhoto.Click
        If Not IsNothing(GarmentPhoto.Image) Then
            If MsgBox("Are you sure you want to delete garment image?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
                Try
                    BRECORDUPDATEDs = True
                    photo_toremove = True
                    GarmentPhoto.Image = Nothing
                    'MsgBox("Image Deleted", MsgBoxStyle.Information, GetAppName())
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName())
                End Try
            End If
        End If
    End Sub

    Private Sub SaveGarmentPhoto(id As String)
        If photo_changed Then
            If Not IsNothing(photo_path) Then
                If Not photo_path.Equals("") Then
                    'Kill(photo_path)
                    Me.GarmentPhoto.Image = Nothing
                    Dim PhotoPath As String = IfNull(CopyAdmGarmentPhoto(photo_path, id), "")
                    DB.RunSql("UPDATE dbo.tbladmgarment SET PhotoPath='" & PhotoPath & "' WHERE PKey='" & id & "'")
                End If
            End If

        ElseIf photo_toremove Then
            Dim _path = GetGarmentPhotoPath(strID, strPhotoPath)
            If Not IsNothing(_path) Then
                Kill(_path)
            End If
            DB.RunSql("UPDATE dbo.tbladmgarment SET PhotoPath=NULL WHERE PKey='" & id & "'")

        End If
    End Sub

    Private Sub GetGarmentPhoto(_PictureEdit As DevExpress.XtraEditors.PictureEdit, PKey As String, FileName As String)
        Try
            'CrewPhoto.Image = New System.Drawing.Bitmap(Trim(IfNull(Items("PhotoPath"), "")))
            'Dim _path = GetCrewPhotoPath(_CrewIDNbr, strPhotoPath)
            photo_path = GetGarmentPhotoPath(PKey, strPhotoPath)
            _PictureEdit.Image = ImageFromStream(photo_path)
        Catch ex As Exception
            _PictureEdit.Image = Nothing
        End Try
    End Sub
#End Region

    
    Private Sub chkReIssueEveryPeriod_EditValueChanged(sender As Object, e As System.EventArgs) Handles chkReIssueEveryPeriod.EditValueChanged
        EnablePeriodFields(chkReIssueEveryPeriod.Checked)
    End Sub

    Private Sub EnablePeriodFields(enable As Boolean)
        txtReIssueEveryPeriodYr.Enabled = enable
        txtReIssueEveryPeriodMonth.Enabled = enable
    End Sub

    Private Sub chkReIssueEverySignOn_EditValueChanged(sender As Object, e As System.EventArgs) Handles chkReIssueEverySignOn.EditValueChanged
        EnablePeriodFields(chkReIssueEveryPeriod.Checked) 'EnablePeriodFields(Not chkReIssueEverySignOn.Checked)
    End Sub

    Private Sub CheckEdit_None_EditValueChanged(sender As Object, e As System.EventArgs) Handles CheckEdit_None.EditValueChanged
        EnablePeriodFields(chkReIssueEveryPeriod.Checked) 'EnablePeriodFields(Not CheckEdit_None.Checked)
        CheckEdit_None.Tag = 0
    End Sub
End Class
