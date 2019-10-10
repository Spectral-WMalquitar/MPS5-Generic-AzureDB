Public Class SMTPConfig

#Region "Easy Edit"
    Private FormName As String = "SMTP Configuration"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Dim info As Boolean = True

    Public Overrides Sub RefreshData()
        TableName = "tblAdmSMTPConfig"
        MyBase.RefreshData()

        isEditdable = False
        BRECORDUPDATEDs = False

        ClearFields(lcSub.Root, False)
        'ClearFields(LayoutControl3.Root, False)
        SetRibbonPageGroupVisibility(Name, "rpgAdminReportOptions", False)
        SetRibbonPageGroupVisibility(Name, "rpgAdminEditOptions", False)
        cboAccounts.Properties.DataSource = MPSDB.CreateTable("SELECT *  FROM " & TableName)
        'If strID <> "" Then
        cboAccounts.EditValue = strID
        'Else
        loadData()
        'End If
        cmdAdd.Text = "Add New Account"
        cmdEdit.Text = "Edit Account"
        MakeReadOnlyListener(Me.lcSub.Root)
        cboAccounts.ReadOnly = False
        cmdAdd.Enabled = True
        cmdEdit.Enabled = True
        cmdDel.Enabled = True
        cmdSave.Enabled = False
    End Sub

    Private Sub loadData()
        If (Not IsNothing(strID)) And (strID <> "") Then
            'Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            RemoveEditListener(Me.lcSub.Root)

            Dim row As DataRowView = CType(cboAccounts.Properties.GetDataSourceRowByKeyValue(strID), DataRowView)
            'cboEmailAdds.EditValue = strID
            txtName.Text = row("Name")
            txtSMTPHost.Text = row("SMTPHost")
            txtSMTPUsername.Text = row("SMTPUsername")
            txtSMTPPassword.Text = row("SMTPPassword")
            txtSMTPPort.Text = row("SMTPPort")
            chkUseTLS.EditValue = CBool(row("UseTLS"))
            chkUseSSL.EditValue = CBool(row("UseSSL"))
        End If

        AddEditListener(Me.lcSub.Root)

        BRECORDUPDATEDs = False
    End Sub

    Private Sub cboAccounts_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAccounts.EditValueChanged
        strID = cboAccounts.EditValue

        loadData()
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        bAddMode = True
        BRECORDUPDATEDs = False
        isEditdable = True
        If cmdAdd.Text = "Cancel" Then
            RefreshData()
        Else
            strID = Nothing
            ClearFields(Me.lcMain.Root, False)
            ClearFields(Me.lcSub.Root, False)
            RemoveReadOnlyListener(Me.lcSub.Root)
            cboAccounts.ReadOnly = True
            cmdEdit.Enabled = False
            cmdDel.Enabled = False
            cmdSave.Enabled = True
            cmdAdd.Text = "Cancel"
        End If
    End Sub

    Private Sub cmdEdit_Click(sender As System.Object, e As System.EventArgs) Handles cmdEdit.Click
        If IsNothing(cboAccounts.EditValue) Or cboAccounts.EditValue = "" Then
            MsgBox("No email selected to edit.", vbOKOnly + MsgBoxStyle.Information, GetAppName)
        Else
            bAddMode = False
            BRECORDUPDATEDs = False
            isEditdable = True
            If cmdEdit.Text = "Cancel" Then
                RefreshData()
            Else
                RemoveReadOnlyListener(Me.lcSub.Root)
                cboAccounts.ReadOnly = True
                cmdAdd.Enabled = False
                cmdDel.Enabled = False
                cmdSave.Enabled = True
                cmdEdit.Text = "Cancel"
            End If
        End If
    End Sub

    Private Sub cmdDel_Click(sender As System.Object, e As System.EventArgs) Handles cmdDel.Click
        If IsNothing(cboAccounts.EditValue) Or cboAccounts.EditValue = "" Then
            MsgBox("No account selected to delete.", vbOKOnly + MsgBoxStyle.Information, GetAppName)
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
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtSMTPHost, txtSMTPUsername, txtSMTPPassword, txtSMTPPort}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, FormName, 10, System.Environment.MachineName, txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSMTPHost, txtSMTPUsername}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.lcSub.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    BRECORDUPDATEDs = False
                    'get the last inserted Record
                    strID = DB.GetLastInsertedItem("PKey", Me.TableName)
                    Type = "Inserted"
                End If
            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSMTPHost, txtSMTPUsername}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(Me.lcSub.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
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
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtSMTPHost, txtSMTPUsername, txtSMTPPassword, txtSMTPPort}) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSMTPHost, txtSMTPUsername, txtSMTPPassword, txtSMTPPort}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        'SaveData()
                        cmdSave_Click(Nothing, Nothing)
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtSMTPHost, txtSMTPUsername, txtSMTPPassword, txtSMTPPort}, "PKey<>'" & strID & "'") Then
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
