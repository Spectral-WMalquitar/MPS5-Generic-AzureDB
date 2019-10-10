Public Class Port
#Region "Easy Edit"
    Private FormName As String = "Admin Port"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region


    Public Overrides Sub RefreshData()
        TableName = "tbladmPort"

        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Port Details - " & strDesc)
        strRequiredFields = "txtName;cboFKeyCntry"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.cboFKeyCntry.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyCntry"), ""))
            Me.txtUNCode.Text = Trim(IfNull(blList.GetFocusedRowData("UNCode"), ""))
            Me.txtNZPortCode.Text = Trim(IfNull(blList.GetFocusedRowData("NZPortCode"), ""))
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            BRECORDUPDATEDs = False
        End If
    End Sub

    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyCntry}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil   'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Port", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
                    type = "Inserted"
                End If

            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    type = "Updated"
                End If
            End If
            bAddMode = False
            RefreshData()
            If info Then
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
            End If
        End If
    End Sub


    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyCntry}, showMsg) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyCntry}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyCntry}, "PKey<>'" & strID & "'") Then
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
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Port", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
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
                    ClearFields(Me.LayoutControl1.Root, False)
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
        Me.cboFKeyCntry.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC")
    End Sub

    Private Sub cboFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
