Public Class Email_Config

#Region "Easy Edit"
    Private FormName As String = "Email Configuration"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Dim info As Boolean = True

    Public Overrides Sub RefreshData()
        TableName = "tblUserEmailConfig"
        MyBase.RefreshData()

        isEditdable = False
        BRECORDUPDATEDs = False

        If Not bLoaded Then
            cboFKeySMTPAcct.Properties.DataSource = MPSDB.CreateTable("SELECT *  FROM tblAdmSMTPConfig")
            bLoaded = True
        End If
        ClearFields(LayoutControl1.Root, False)
        'ClearFields(LayoutControl3.Root, False)
        SetRibbonPageGroupVisibility(Name, "rpgReportEditOptions", False)
        SetRibbonPageGroupVisibility(Name, "rpgReportOptions", False)
        cboEmailAdds.Properties.DataSource = MPSDB.CreateTable("SELECT *  FROM " & TableName & " WHERE FKeyUserID='" & USER_ID & "'")
        'If strID <> "" Then
        cboEmailAdds.EditValue = strID
        'Else
        loadData()
        'End If
        cmdAdd.Text = "Add New Email"
        cmdEdit.Text = "Edit Email"
        MakeReadOnlyListener(Me.LayoutControl1.Root)
        cboEmailAdds.ReadOnly = False
        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdSave.Enabled = False
        txtTestReciever.ReadOnly = False
    End Sub

    Private Sub loadData()
        If (Not IsNothing(strID)) And (strID <> "") Then
            'Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            RemoveEditListener(Me.LayoutControl1.Root)

            Dim row As DataRowView = CType(cboEmailAdds.Properties.GetDataSourceRowByKeyValue(strID), DataRowView)
            'cboEmailAdds.EditValue = strID
            txtEmailAdd.Text = row("EmailAdd")
            cboFKeySMTPAcct.EditValue = row("FKeySMTPAcct")
        End If

        AddEditListener(Me.LayoutControl1.Root)
        'RemoveEditListener(cboEmailAdds, False)
        RemoveEditListener(txtTestReciever, False)

        BRECORDUPDATEDs = False
    End Sub

    Private Sub cboEmailAdds_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboEmailAdds.EditValueChanged
        strID = cboEmailAdds.EditValue

        loadData()
        'RefreshData()
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        bAddMode = True
        BRECORDUPDATEDs = False
        isEditdable = True
        If cmdAdd.Text = "Cancel" Then
            RefreshData()
        Else
            strID = Nothing
            ClearFields(Me.LayoutControl1.Root, False)
            ClearFields(Me.LayoutControl3.Root, False)
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            cboEmailAdds.ReadOnly = True
            cmdEdit.Enabled = False
            cmdDel.Enabled = False
            cmdSave.Enabled = True
            cmdAdd.Text = "Cancel"
        End If
    End Sub

    Private Sub cmdEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdEdit.Click
        If IsNothing(cboEmailAdds.EditValue) Or cboEmailAdds.EditValue = "" Then
            MsgBox("No email selected to edit.", vbOKOnly + MsgBoxStyle.Information, GetAppName)
        Else
            bAddMode = False
            BRECORDUPDATEDs = False
            isEditdable = True
            If cmdEdit.Text = "Cancel" Then
                RefreshData()
            Else
                RemoveReadOnlyListener(Me.LayoutControl1.Root)
                cboEmailAdds.ReadOnly = True
                cmdAdd.Enabled = False
                cmdDel.Enabled = False
                cmdSave.Enabled = True
                cmdEdit.Text = "Cancel"
            End If
        End If
    End Sub

    Private Sub cmdDel_Click(sender As System.Object, e As System.EventArgs) Handles cmdDel.Click
        If IsNothing(cboEmailAdds.EditValue) Or cboEmailAdds.EditValue = "" Then
            MsgBox("No email selected to delete.", vbOKOnly + MsgBoxStyle.Information, GetAppName)
        Else
            If MsgBox("Do you want to delete the selected item?", vbYesNo + vbQuestion, GetAppName) = MsgBoxResult.Yes Then
                info = MPSDB.RunSql("DELETE FROM " & TableName & " WHERE PKey='" & strID & "'")
                MsgBox(GetMessage("Deleted", info), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, GetAppName)
                strID = Nothing
                RefreshData()
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim Type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtEmailAdd, cboFKeySMTPAcct}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, FormName, 10, System.Environment.MachineName, txtEmailAdd.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "FKeyUserID,LastUpdatedBy", "'" & USER_ID & "','" & LastUpdatedBy & "'"))
                    BRECORDUPDATEDs = False
                    'get the last inserted Record
                    strID = DB.GetLastInsertedItem("PKey", Me.TableName)
                    Type = "Inserted"
                End If
            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "FKeyUserID='" & USER_ID & "', LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
                    BRECORDUPDATEDs = False
                    Type = "Updated"
                End If
            End If
            bAddMode = False
            RefreshData()
            If info Then
                MsgBox(GetMessage(Type, info), MsgBoxStyle.Information, GetAppName)
            End If
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Information + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtEmailAdd, cboFKeySMTPAcct}) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        'SaveData()
                        cmdSave_Click(Nothing, Nothing)
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}, "PKey<>'" & strID & "'") Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        'SaveData()
                        cmdSave_Click(Nothing, Nothing)
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

End Class

