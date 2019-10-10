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
            RequiredControls = {txtEmailAdd, cboFKeySMTPAcct}
            rbgUseSpecificLogIn.EditValue = 1
            bLoaded = True
        End If
        ClearFields(lcgContent, False)
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
        MakeReadOnlyListener(Me.lcgContent)
        rbgUseSpecificLogIn.ReadOnly = True
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
            RemoveEditListener(Me.lcgContent)

            Dim row As DataRowView = CType(cboEmailAdds.Properties.GetDataSourceRowByKeyValue(strID), DataRowView)
            'cboEmailAdds.EditValue = strID
            txtEmailAdd.Text = row("EmailAdd")
            cboFKeySMTPAcct.EditValue = row("FKeySMTPAcct")
            rbgUseSpecificLogIn.EditValue = row("UseSpecificLogIn")
            txtSMTPUsername.EditValue = row("SMTPUsername")
            txtSMTPPassword.EditValue = row("SMTPPassword")

        End If

        AddEditListener(Me.lcgContent)
        'RemoveEditListener(cboEmailAdds, False)
        RemoveEditListener(txtTestReciever, False)

        BRECORDUPDATEDs = False

        EnableAccount(IIf(Me.rbgUseSpecificLogIn.EditValue = 2, True, False))
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
            ClearFields(Me.lcgMain, False)
            ClearFields(Me.lcgContent, False)
            RemoveReadOnlyListener(Me.lcgContent)
            rbgUseSpecificLogIn.ReadOnly = False
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
                RemoveReadOnlyListener(Me.lcgContent)
                rbgUseSpecificLogIn.ReadOnly = False
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

                clsAudit.propSQLConnStr = MPSDB.GetConnectionString
                Dim nReaderItemCount As Integer = 0
                With MPSDB
                    .BeginReader("SELECT * FROM dbo.tblUserEmailProfile WHERE FKeyEmailAdd = '" & strID & "'")
                    nReaderItemCount = .ReaderItemCount()
                    .CloseReader()
                End With

                If nReaderItemCount > 0 Then
                    If MsgBox("There are scheduled email profiles created under this email account. These email profiles will be deleted." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        MsgBox("Delete canceled.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                End If


                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, FormName, 10, System.Environment.MachineName, txtEmailAdd.EditValue, FormName)
                clsAudit.saveAuditPreDelDetails(TableName, strID, LastUpdatedBy) 'neil

                Dim query As New ArrayList
                query.Add("DELETE FROM dbo.tblUserEmailProfile WHERE FKeyEmailAdd ='" & strID & "'")
                query.Add("DELETE FROM " & TableName & " WHERE PKey='" & strID & "'")

                'info = MPSDB.RunSql("DELETE FROM " & TableName & " WHERE PKey='" & strID & "'")
                info = MPSDB.RunSqls(query)
                If info Then
                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.OkOnly + MsgBoxStyle.Information, GetAppName)
                    strID = Nothing
                    RefreshData()
                End If

            End If
        End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim Type As String = "", info As Boolean = False
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtEmailAdd, cboFKeySMTPAcct}) Then
            If Not IsAccountValid() Then
                MsgBox("Specify a login information to be used", MsgBoxStyle.Exclamation, GetAppName)
                Exit Sub
            End If
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, FormName, 10, System.Environment.MachineName, txtEmailAdd.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}, "FKeyUserID='" & USER_ID & "'") Then
                    Exit Sub
                Else
                    'info = DB.RunSql(GenerateInsertScript(Me.lcContent.Root, 3, Me.TableName, "FKeyUserID,LastUpdatedBy", "'" & USER_ID & "','" & LastUpdatedBy & "'"))
                    info = DB.RunSql("INSERT INTO " & Me.TableName & " (EmailAdd,FKeySMTPAcct,UseSpecificLogIn,SMTPUsername,SMTPPassword,FKeyUserID,LastUpdatedBy) " & _
                                     " VALUES ('" & txtEmailAdd.EditValue & "'," & _
                                     "'" & cboFKeySMTPAcct.EditValue & "'," & _
                                     "" & rbgUseSpecificLogIn.EditValue & "," & _
                                     "'" & txtSMTPUsername.EditValue & "'," & _
                                     "'" & txtSMTPPassword.EditValue & "'," & _
                                     "'" & USER_ID & "'," & _
                                     "'" & LastUpdatedBy & "')")
                    BRECORDUPDATEDs = False
                    'get the last inserted Record
                    strID = DB.GetLastInsertedItem("PKey", Me.TableName)
                    Type = "Inserted"
                End If
            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}, "PKey<>'" & strID & "' AND FKeyUserID='" & USER_ID & "'") Then
                    Exit Sub
                Else
                    'info = DB.RunSql(GenerateUpdateScript(Me.lcContent.Root, 3, Me.TableName, "FKeyUserID='" & USER_ID & "', LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & strID & "'"))
                    info = DB.RunSql("UPDATE " & Me.TableName & " SET " & _
                                     "EmailAdd = '" & txtEmailAdd.EditValue & "'" & _
                                     ",FKeySMTPAcct = '" & cboFKeySMTPAcct.EditValue & "'" & _
                                     ",UseSpecificLogIn = " & rbgUseSpecificLogIn.EditValue & _
                                     ",SMTPUsername = '" & txtSMTPUsername.EditValue & "'" & _
                                     ",SMTPPassword = '" & txtSMTPPassword.EditValue & "'" & _
                                     ",FKeyUserID = '" & USER_ID & "'" & _
                                     ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                     " WHERE PKey='" & strID & "'")
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
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtEmailAdd, cboFKeySMTPAcct}) Then
                If Not IsAccountValid() Then
                    MsgBox("Specify a login information to be used", MsgBoxStyle.Exclamation, GetAppName)
                    Return flag
                    Exit Function
                End If
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}, "FKeyUserID='" & USER_ID & "'") Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        'SaveData()
                        cmdSave_Click(Nothing, Nothing)
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtEmailAdd}, "PKey<>'" & strID & "' AND FKeyUserID='" & USER_ID & "'") Then
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

    Private Sub cmdSendTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdSendTest.Click
        If IsNothing(txtEmailAdd.EditValue) Or txtEmailAdd.EditValue = "" Then
            MsgBox("Specify a valid email address of sender", MsgBoxStyle.Exclamation, GetAppName)

        ElseIf (IsNothing(cboFKeySMTPAcct.EditValue) Or cboFKeySMTPAcct.EditValue = "") Then
            MsgBox("Specify an SMTP Account to be used", MsgBoxStyle.Exclamation, GetAppName)

        ElseIf Not IsAccountValid() Then
            MsgBox("Specify a login information to be used", MsgBoxStyle.Exclamation, GetAppName)

        ElseIf IsNothing(txtTestReciever.EditValue) Or txtTestReciever.EditValue = "" Then
            MsgBox("Specify a valid email address that will recieve the test email", MsgBoxStyle.Exclamation, GetAppName)

        Else
            If MsgBox("Do you want to continue to send email?", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, GetAppName) = MsgBoxResult.Ok Then
                ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Sending Email . . .")
                Dim success As Boolean = True
                Dim addMsg As String = ""
                Dim dtConfig As DataTable
                'get the SMTP config of the sender
                dtConfig = MPSDB.CreateTable("SELECT TOP 1 * FROM tblAdmSMTPConfig WHERE PKey='" & cboFKeySMTPAcct.EditValue & "'")
                'sends then deletes the export folder
                success = ReportAutoEmail.SendMailByCK(dtConfig.Rows(0).Item("SMTPHost"), CInt(dtConfig.Rows(0).Item("SMTPPort")), CBool(dtConfig.Rows(0).Item("UseSSL")), CBool(dtConfig.Rows(0).Item("UseTLS")), dtConfig.Rows(0).Item("SMTPUsername"), dtConfig.Rows(0).Item("SMTPPassword"), _
                                    txtEmailAdd.EditValue, txtTestReciever.EditValue, ReportAutoEmail.MAIL_TEST_SUBJECT, ReportAutoEmail.MAIL_TEST_MSG, "", "", "", , addMsg)
                CloseCustomLoadScreen()
                ReportAutoEmail.ShowMailMsg(success, True, addMsg)
            End If
        End If

    End Sub

    Private Function IsAccountValid() As Boolean
        If rbgUseSpecificLogIn.EditValue = 2 Then
            If txtSMTPUsername.EditValue.ToString.Length <> 0 Or txtSMTPPassword.EditValue.ToString.Length <> 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Public Sub EnableAccount(enable As Boolean)
        Me.txtSMTPUsername.Enabled = enable
        Me.txtSMTPPassword.Enabled = enable
    End Sub

    Private Sub rbgUseSpecificLogIn_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles rbgUseSpecificLogIn.EditValueChanged
        EnableAccount(IIf(Me.rbgUseSpecificLogIn.EditValue = 2, True, False))
    End Sub
End Class

