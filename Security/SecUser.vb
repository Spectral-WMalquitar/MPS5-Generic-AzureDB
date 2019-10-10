Public Class SecUser
    Private FormName As String = "Admin Group Security Details"
    Dim strs As String
    Dim clsSec As New clsSecurity
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
    Private Const DEFAULT_USER_PASSWORD As String = "12345"

    Private ReadOnly Property LayoutControlGroups As DevExpress.XtraLayout.LayoutControlGroup()
        Get
            Dim returnValue As DevExpress.XtraLayout.LayoutControlGroup()
            returnValue = New DevExpress.XtraLayout.LayoutControlGroup() {Me.LayoutControl1.Root, LayoutControlGroup_UserInfo, LayoutControlGroup_LogInfo}
            Return returnValue
        End Get
    End Property

    Private Sub initControls()

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False

        Dim dt As New DataTable
        'Dim clsSec As New clsSecurity(DB.GetConnectionString)
        Dim strres As String
        clsSec.propSQLConnStr = DB.GetConnectionString

        strres = clsSec.get_any_fr_db("select * from dbo.MSysSec_Groups where name <> 'admins' order by name", dt)

        If strres = "" Then
            Me.lkuGroup.Properties.DataSource = dt
        Else
            MsgBox(strres)
        End If

        'me.btnClearGroup.Enabled = False
        Me.btnClearGroup.Enabled = False

    End Sub

    'load sub tables
    Private Sub LoadSub()
        Me.LayoutControl1.AllowCustomization = False


    End Sub

    'Refesh
    Public Overrides Sub RefreshData()
        TableName = "MSysSec_Users"
        MyBase.RefreshData()
        strRequiredFields = "txtName"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If

        SetForceLogoutVisibility(Name, True)

        If blList.GetID() = "" Then
            If hasSecGroup() Then
                LayoutControlGroup1.Enabled = True
                AddData()
            Else
                LayoutControlGroup1.Enabled = False
                MsgBox("Adding of new user is currently disabled because there are no available security group yet. Please add first the security groups.", MsgBoxStyle.Exclamation, "Add New User")
            End If
            SetForceLogoutEnabled(Name, False)  'added by tony20190812
        Else
            LayoutControlGroup1.Enabled = True
            SetForceLogoutEnabled(Name, True)   'added by tony20190812
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.lkuGroup.EditValue = blList.GetFocusedRowData("GroupID")

            Me.txtFullName.EditValue = blList.GetFocusedRowData("FullName")
            Me.txtDescription.EditValue = blList.GetFocusedRowData("Description")
            Me.txtEmployeeID.EditValue = blList.GetFocusedRowData("EmployeeID")
            Me.txtContactInfo.EditValue = blList.GetFocusedRowData("ContactInfo")

            'Me.txtLastLog.Text = Trim(IfNull(blList.GetFocusedRowData("vLastCheck"), ""))
            'Me.txtComputerLogged.Text = Trim(IfNull(blList.GetFocusedRowData("vCompName"), ""))

            lciRestoreBtn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            cmdResetPass.Enabled = False
            BRECORDUPDATEDs = False

        End If

        'LayoutControlGroups
        AddEditListener(LayoutControlGroups)
        MakeReadOnlyListener(LayoutControlGroups)
        Me.lkuGroup.Properties.Buttons(1).Enabled = False 'clear button

        Me.gridLogInfo.DataSource = DB.CreateTable("SELECT * FROM dbo.viewUserLogged WHERE FKeyUserID=" & Trim(IfNull(blList.GetFocusedRowData("ID"), "")))
    End Sub

    '<!-- added by tony20190812
    Private Function hasSecGroup() As Boolean
        Dim bRetval As Boolean = False

        Try
            bRetval = TryCast(lkuGroup.Properties.DataSource, DataTable).Rows.Count > 0
        Catch ex As Exception
            bRetval = False
        End Try
        Return bRetval
    End Function
    '-->

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            txtName.Focus()
            RemoveReadOnlyListener(LayoutControlGroups)
            cmdResetPass.Enabled = isEditdable
            Me.lkuGroup.Properties.Buttons(1).Enabled = True 'clear button

        Else
            txtName.Focus()
            MakeReadOnlyListener(LayoutControlGroups)
            Me.lkuGroup.Properties.Buttons(1).Enabled = False 'clear button

        End If
        BRECORDUPDATEDs = False
        Me.viewLogInfo.OptionsBehavior.Editable = False
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As Long = 0
        Dim type As String = "", info As Boolean = False
        Dim errmsg As String

        'neil
        If Me.txtName.Text = "Spectral" Or Me.txtName.Text = "Administrator" Then
            MsgBox("You cannot use the reserved name [" & Me.txtName.Text & "] as a new user", MsgBoxStyle.Information, GetAppName)
            Exit Sub
        End If

        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            'getusername() & <Description><FormName>
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else
                    'com/out neil
                    'info = DB.RunSql("INSERT INTO dbo.MSysSec_Users(Name,Password)" & _
                    '                 "VALUES('" & Me.txtName.Text & "'" & _
                    '                 ",'" & DEFAULT_PASSWORD & "')")
                    'Dim GenID As Int64

                    '<!-- edited by tony20171124 - added FullName, Description, EmployeeID, ContactInfo
                    errmsg = clsSec.add_user(Me.txtName.Text, DEFAULT_PASSWORD, id, , , LastUpdatedBy, IfNull(Me.txtFullName.Text, ""), IfNull(Me.txtDescription.Text, ""), IfNull(Me.txtEmployeeID.Text, ""), IfNull(Me.txtContactInfo.Text, ""))
                    '-->

                    'id = GenID
                    If errmsg = "" Then
                        If Not Me.lkuGroup.EditValue Is Nothing And Not IsDBNull(Me.lkuGroup.EditValue) Then
                            errmsg = clsSec.del_user_frGroup(id)
                            errmsg = clsSec.add_user_to_group(id, Me.lkuGroup.EditValue, LastUpdatedBy)
                        End If
                    End If
                    '======================================================================================
                    ' Insert in to Security Table
                    ' ID + Name 
                    '======================================================================================
                    'com/out by neil id = Trim(IfNull(DB.GetLastInsertedItem("ID", "MSysSec_Users"), "")) 'get PKey

                    'com/out by Neil
                    'info = DB.RunSql("INSERT INTO dbo.MSysSecUserDetail(ID,SecUser) " & _
                    '                "VALUES('" & id & "'" & _
                    '                ",'" & AES_Encrypt(id & Me.txtName.Text, id & Me.txtName.Text) & "')")
                    clsSec.add_MSysSecUserDetail(id, AES_Encrypt(id & Me.txtName.Text, id & Me.txtName.Text))
                    type = "Inserted"
                    '======================================================================================
                    BRECORDUPDATEDs = False
                End If
            Else

                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & id & "'") Then
                    Exit Sub
                Else

                    id = strID

                    'com/out by neil
                    'info = DB.RunSql("UPDATE dbo.MSysSec_Users" & _
                    '                "SET Name='" & Me.txtName.Text & "' " & _
                    '                "WHERE ID = '" & id & "'")
                    'info = DB.RunSql("UPDATE dbo.MSysSecUserDetail" & _
                    '                "SET SecUser='" & AES_Encrypt(id & Me.txtName.Text, id & Me.txtName.Text) & "' " & _
                    '                "WHERE ID = '" & id & "'")

                    '<!-- edited by tony20171124 - added FullName, Description, EmployeeID, ContactInfo
                    errmsg = clsSec.update_user(id, Me.txtName.Text, , , , LastUpdatedBy, IfNull(Me.txtFullName.Text, ""), IfNull(Me.txtDescription.Text, ""), IfNull(Me.txtEmployeeID.Text, ""), IfNull(Me.txtContactInfo.Text, ""))
                    '-->

                    If errmsg = "" Then
                        If Not Me.lkuGroup.EditValue Is Nothing And Not IsDBNull(Me.lkuGroup.EditValue) Then
                            errmsg = clsSec.del_user_frGroup(id)
                            errmsg = clsSec.add_user_to_group(id, Me.lkuGroup.EditValue, LastUpdatedBy)
                        End If
                    End If
                    errmsg = clsSec.update_MSysSecUserDetail(id, AES_Encrypt(id & Me.txtName.Text, id & Me.txtName.Text))

                    BRECORDUPDATEDs = False
                    type = "Updated"
                End If

            End If

            If errmsg = "" Then
                info = True
            End If
            blList.RefreshData()
            If info Then
                blList.SetSelection(id)
                RefreshData()
                MsgBox(GetMessage(type, info) & IIf(type = "Inserted", vbNewLine & vbNewLine & "Default password is set to '" & DEFAULT_USER_PASSWORD & "'.", ""), MsgBoxStyle.Information, GetAppName)
            End If
        End If

    End Sub



    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(LayoutControlGroups)
        If Not bAddMode Then
            lciRestoreBtn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            ClearFields(LayoutControlGroups, False)
            AllowEditing(Name, False) 'Allow Edit Button
            AllowDeletion(Name, False) 'Disable Delete button
            Me.gridLogInfo.DataSource = Nothing
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            'Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName, "FKeyDocGroup='SYSTRAVELDOC'")

            BRECORDUPDATEDs = False
        End If
    End Sub


    Private Sub btnClearGroup_Click(sender As System.Object, e As System.EventArgs) Handles btnClearGroup.Click
        Me.lkuGroup.EditValue = Nothing
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, lkuGroup}, showMsg) Then
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
        'Dim info As Boolean = False
        Dim info As String = ""
        If MsgBox("Are you sure want to delete user '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                ' info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                '<!--added by tony20180922 : Log Deletion
                oLogDeletionSec.Init(DB.GetConnectionString())

                oLogDeletionSec.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Admin", _
                    "msyssec_users", _
                    "ID IN ('" & strID & "')", _
                    "<< Delete Security Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->

                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                info = clsSec.del_User(strID)
                If info = "" Then
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletionSec.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Admin", _
                        "MSysSec_UsersGroup", _
                        "GroupID IN ('" & strID & "')", _
                        "<< Delete Security Data - " & FormName & " - User-Group >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - User-Group>", _
                        GetUserName())

                    oLogDeletionSec.AddLogEntryToDatabase()
                    '-->
                    clsSec.del_user_frGroup(strID)
                    ClearFields(Me.LayoutControlGroups, False)
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

    Private Sub lkuGroup_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuGroup.Properties.ButtonClick
        Me.lkuGroup.EditValue = Nothing
    End Sub


#Region "Reset Password"
    Private Sub cmdResetPass_Click(sender As System.Object, e As System.EventArgs) Handles cmdResetPass.Click
        If isEditdable Then
            If MsgBox("Are you sure to restore the password of '" & strDesc & "' to default Password [12345]?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName()) = MsgBoxResult.Yes Then
                Dim frm As New frmPwdInputBox(USER_PASSWORD)
                frm.ShowDialog(Me)
                Dim strPassword As String = IfNull(frm.Password, String.Empty)
                If strPassword.Equals(USER_PASSWORD) Then
                    If ResetUserPassword(strID) Then
                        MsgBox("Password restored.", MsgBoxStyle.Information, GetAppName)
                    Else
                        MsgBox("Password restoration failed.", MsgBoxStyle.Critical, GetAppName)
                    End If
                End If
            End If
        End If
    End Sub

    Private Function ResetUserPassword(UserID As String) As Boolean
        Dim strLastUpdated As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Admin Restore to Default Password.", FormName)
        Return DB.RunSql("Update dbo.MSysSec_Users set Password='" & DEFAULT_PASSWORD & "', LastUpdatedBy='" & strLastUpdated & "' WHERE  ID=" & UserID)
    End Function
#End Region

    Private Function txtIsLogin() As Object
        Throw New NotImplementedException
    End Function

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Dim ermsg As String = "", tempvPKey As Integer = 0
        'MsgBox("test")
        Select Case param(0)
            Case "ForceLogout"
                'MsgBox(Trim(IfNull(blList.GetFocusedRowData("vPKey"), "")))
                'If MsgBox("User """ & Me.txtName.Text & """ will be logged out, continue?", vbQuestion + vbYesNo) = vbYes Then
                If Not Me.txtName.Text Is Nothing And Me.txtName.Text <> "" Then
                    If Me.viewLogInfo.RowCount <> 0 Then
                        If MsgBox("User """ & Me.txtName.Text & """ will be logged out, continue?", vbQuestion + vbYesNo) = vbYes Then
                            tempvPKey = blList.GetFocusedRowData("ID")
                            Dim recaffectcnt As Integer
                            If removeLogRec(tempvPKey, recaffectcnt) Then
                                If recaffectcnt > 0 Or recaffectcnt = -1 Then
                                    Dim auditlogid As Long
                                    clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
                                    ' clsAudit.saveAuditLog("User """ & Me.txtName.Text & """ logged out by Admin - """ & USER_NAME & """", USER_NAME, auditlogid, System.Environment.MachineName, 10,
                                    clsAudit.saveAuditLog("User " & Me.txtName.Text & " logged out by Admin - " & USER_NAME, USER_NAME, auditlogid, System.Environment.MachineName, 10,
                                     , , , , , "User Security Details") 'neil

                                    MsgBox("User logged off.", vbInformation)
                                    blList.RefreshData()
                                    RefreshData()
                                Else
                                    MsgBox("Cannot log off user.", vbInformation)
                                End If
                            End If
                        End If
                    Else
                        MsgBox("Unable to log out. User """ & Me.txtName.Text & """ is not logged in from any computer.", vbInformation)
                    End If

                Else
                    MsgBox("No User is selected.", vbExclamation)
                End If
        End Select
    End Sub

    '/// force log-out
    Function removeLogRec(UserID As Integer, Optional ByRef recaffect As Boolean = 0) As Boolean
        Dim retval As Boolean = True

        Try
            'modified by tony20170811 - should not logout the user from Admin if he is logging out himself (just in case)
            'neil DB.RunSql("Delete from MSysSec_Users_Log where FKeyUserID in (" & UserID & ") AND ModuleName <> 'ADMIN'", False)
            If UserID = USER_ID Then
                DB.RunSql("Delete from MSysSec_Users_Log where FKeyUserID in (" & UserID & ") AND ModuleName <> 'ADMIN'", False, recaffect)
            Else
                DB.RunSql("Delete from MSysSec_Users_Log where FKeyUserID in (" & UserID & ") ", False, recaffect)
            End If
            'DB.RunSql("Delete from MSysSec_Users_Log where FKeyUserID in (" & UserID & ") and CompName <> '" & My.Computer.Name.Replace("'", "''") & "'", False, recaffect)
            retval = True
        Catch ex As Exception
            retval = False
        End Try

        Return retval
    End Function
End Class
