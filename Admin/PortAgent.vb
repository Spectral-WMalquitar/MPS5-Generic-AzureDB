Public Class PortAgent

#Region "Easy Edit"
    Private FormName As String = "Admin Port Agent"

    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        Me.cboFKeyCntry.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC")
        Me.cboFKeyPort.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmPort ORDER BY Name ASC")
    End Sub

    Private Sub LoadSub()
        BRECORDUPDATEDs = False
        Me.ContactGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmAdmPortAgentSub WHERE FKeyPortAgent='" & strID & "'")

    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        Me.headerMain.Text = IIf(strDesc = "New Record", strDesc, "Port Agent Details - " & strDesc)
        SetDeleteCaption(Name, "Delete Port Agent")
        TableName = "tblAdmPortAgent"
        strRequiredFields = "txtName,cboFKeyPort"

        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtPortNo.Text = Trim(IfNull(blList.GetFocusedRowData("PortNo"), ""))
            Me.cboFKeyPort.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyPort"), ""))
            'Me.cboFKeyCntry.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyCntry"), ""))
            Me.cboFKeyCntry.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyCntry"), ""))
            Me.txtAusState.Text = Trim(IfNull(blList.GetFocusedRowData("AusState"), ""))
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtAddress.Text = Trim(IfNull(blList.GetFocusedRowData("Address"), ""))
            Me.txtAddress2.Text = Trim(IfNull(blList.GetFocusedRowData("Address2"), ""))
            Me.txtAddress3.Text = Trim(IfNull(blList.GetFocusedRowData("Address3"), ""))
            Me.txtAddress4.Text = Trim(IfNull(blList.GetFocusedRowData("Address4"), ""))
            Me.txtAgentTel.Text = Trim(IfNull(blList.GetFocusedRowData("AgentTel"), ""))
            Me.txtAgentMobile.Text = Trim(IfNull(blList.GetFocusedRowData("AgentMobile"), ""))
            Me.txtAgentFax.Text = Trim(IfNull(blList.GetFocusedRowData("AgentFax"), ""))
            Me.txtAgentEmail.Text = Trim(IfNull(blList.GetFocusedRowData("AgentEmail"), ""))
            Me.txtComments.Text = Trim(IfNull(blList.GetFocusedRowData("Comments"), ""))
            'for SUB DATA
            EditAllowSubGrid(Me.ContactView, False)
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub


    'Save
    Public Overrides Sub SaveData()
        Me.headerMain.Focus()
        Dim query As New ArrayList, info As Boolean = False
        Dim type As String = "", id As String = ""
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyPort}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil   'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Port Agent", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    BRECORDUPDATEDs = False
                    id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                    type = "Inserted"
                End If
            Else
                id = strID
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    query.Add(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                    BRECORDUPDATEDs = False
                    type = "Updated"
                End If


            End If
            With Me.ContactView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then
                        Dim cDataDescription As String = ConcatWithSpaces(New Object() {.GetRowCellValue(i, "FName"), .GetRowCellValue(i, "MName"), .GetRowCellValue(i, "LName")})
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Port Agent Contact List", 10, System.Environment.MachineName, cDataDescription, FormName)

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmPortAgentContacts ( " & _
                                      "FKeyPortAgent," & _
                                      "LName, " & _
                                      "FName, " & _
                                      "MName, " & _
                                      "Title, " & _
                                      "PhoneOffice, " & _
                                      "PhoneHome, " & _
                                      "PhoneMobile, " & _
                                      "Email, " & _
                                      "LastUpdatedBy)" & _
                                      "VALUES('" & id & "', " & _
                                      "'" & .GetRowCellValue(i, "LName") & "', " & _
                                      "'" & .GetRowCellValue(i, "FName") & "', " & _
                                      "'" & .GetRowCellValue(i, "MName") & "', " & _
                                      "'" & .GetRowCellValue(i, "Title") & "', " & _
                                      "'" & .GetRowCellValue(i, "PhoneOffice") & "', " & _
                                      "'" & .GetRowCellValue(i, "PhoneHome") & "', " & _
                                      "'" & .GetRowCellValue(i, "PhoneMobile") & "', " & _
                                      "'" & .GetRowCellValue(i, "EMail") & "', " & _
                                      "'" & LastUpdatedBy & "')")
                        Else
                            id = strID
                            query.Add("UPDATE dbo.tblAdmPortAgentContacts " & _
                                      "SET LName='" & .GetRowCellValue(i, "LName") & "'" & _
                                      ", FName='" & .GetRowCellValue(i, "FName") & "'" & _
                                      ", MName='" & .GetRowCellValue(i, "MName") & "'" & _
                                      ", Title='" & .GetRowCellValue(i, "Title") & "'" & _
                                      ", PhoneOffice='" & .GetRowCellValue(i, "PhoneOffice") & "'" & _
                                      ", PhoneHome='" & .GetRowCellValue(i, "PhoneHome") & "'" & _
                                      ", PhoneMobile='" & .GetRowCellValue(i, "PhoneMobile") & "'" & _
                                      ", Email='" & .GetRowCellValue(i, "Email") & "'" & _
                                      ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                      ",DateUpdated=(getdate())" & _
                                      "WHERE FKeyPortAgent='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next
            End With
            info = DB.RunSqls(query)
            blList.RefreshData()
            If info Then
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
                blList.SetSelection(id)
                RefreshData()
            End If
        End If

    End Sub


    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, cboFKeyPort}, showMsg) Then
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

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowDeletion(Name, False)
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.headerMain.Text = strDesc
            Me.txtPortNo.Focus()
            Me.txtPortNo.BackColor = SEL_COLOR
        End If
        Me.ContactGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmAdmPortAgentSub WHERE FKeyPortAgent='" & strID & "'")
        EditAllowSubGrid(Me.ContactView, True)

        BRECORDUPDATEDs = False
    End Sub

    'Edit
    Public Overrides Sub EditData()
        Me.txtPortNo.Focus()
        MyBase.EditData()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            EditAllowSubGrid(Me.ContactView, isEditdable)

        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EditAllowSubGrid(Me.ContactView, isEditdable)
        End If
        AllowDeletion(Name, False)

    End Sub

    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            DeleteMain()
        Else
            DeleteSubTable()
        End If
    End Sub

    Private Sub DeleteMain()
        MyBase.DeleteData()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Port Agent", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
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

    Private Sub DeleteSubTable()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete '" & ContactView.GetRowCellDisplayText(ContactView.FocusedRowHandle, "LName") & " " & ContactView.GetRowCellDisplayText(ContactView.FocusedRowHandle, "FName") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If IfNull(ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey"), "") <> "" Then
                Dim cDataDescription As String = ConcatWithSpaces(New Object() {ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "FName"), ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "MName"), ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "LName")})
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Port Agent Contact List", 10, System.Environment.MachineName, cDataDescription, FormName)
                clsAudit.saveAuditPreDelDetails("tblAdmPortAgentContacts", ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    "tblAdmPortAgentContacts", _
                    "PKey IN ('" & ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey") & "')", _
                    "<< Delete Admin Data - " & FormName & " - Contacts >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & "- Contacts>", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo.tblAdmPortAgentContacts WHERE PKey='" & ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey") & "'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                    ContactView.DeleteRow(ContactView.FocusedRowHandle)
                Else
                    MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Information, GetAppName)
                End If
            End If
            If ContactView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
        End If
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles headerMain.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub EditAllowSubGrid(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal value As Boolean)
        With view
            If value Then
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                .OptionsBehavior.ReadOnly = False
            Else
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                .OptionsBehavior.ReadOnly = True
            End If
        End With


    End Sub

#Region "Port Agent Contacts"
    Private Sub ContactView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ContactView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.ContactView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub ContactView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ContactView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub ContactView_GotFocus(sender As Object, e As System.EventArgs) Handles ContactView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Contact")
            AllowDeletion(Name, True)
        End If
    End Sub

    Private Sub ContactView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ContactView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyPortAgent"), strID)
        SubAddMode = True
    End Sub

    Private Sub ContactView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles ContactView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub ContactView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ContactView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            ContactView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub ContactView_LostFocus(sender As Object, e As System.EventArgs) Handles ContactView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Port Agent")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub ContactView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ContactView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
        strRequiredFieldName = "LName;FName;"
        With view
            If InStr(1, strRequiredFieldName, e.Column.FieldName) > 0 Then
                e.Appearance.BackColor = REQUIRED_COLOR
                If .GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
                    e.Appearance.BackColor = SEL_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") And .FocusedRowHandle = e.RowHandle Then
                    e.Appearance.BackColor = EDITED_FOCUSED_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") Then
                    e.Appearance.BackColor = EDITED_COLOR
                ElseIf e.RowHandle = .FocusedRowHandle Then
                    e.Appearance.BackColor = SEL_COLOR
                End If
            ElseIf .IsRowSelected(e.RowHandle) Then
                e.Appearance.BackColor = SEL_COLOR
                e.Appearance.ForeColor = System.Drawing.Color.Black
            End If
        End With
        'If ContactView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
        '    e.Appearance.BackColor = SEL_COLOR
        'ElseIf ContactView.GetRowCellValue(e.RowHandle, "Edited") And ContactView.FocusedRowHandle = e.RowHandle Then
        '    e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        'ElseIf ContactView.GetRowCellValue(e.RowHandle, "Edited") Then
        '    e.Appearance.BackColor = EDITED_COLOR
        'ElseIf e.RowHandle = ContactView.FocusedRowHandle Then
        '    e.Appearance.BackColor = SEL_COLOR
        'End If
    End Sub

    Private Sub ContactView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles ContactView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub ContactView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles ContactView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Add Port Agent Contacts"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
        For Each cntrl As Windows.Forms.Control In e.EditForm.Controls
            If Not TypeOf cntrl Is DevExpress.XtraGrid.EditForm.Helpers.Controls.EditFormContainer Then
                Continue For
            End If
            For Each nctrl As Windows.Forms.Control In cntrl.Controls
                If Not (TypeOf nctrl Is DevExpress.XtraEditors.PanelControl) Then
                    Continue For
                Else
                    nctrl.Height = 70
                End If
                For Each btn As Windows.Forms.Control In nctrl.Controls
                    If TypeOf btn Is DevExpress.XtraEditors.SimpleButton Then
                        Dim sbtn = TryCast(btn, DevExpress.XtraEditors.SimpleButton)
                        'Update Button
                        If sbtn.Text = "Update" Or sbtn.Text = "Add" Or sbtn.Text = "Edit" Then
                            If SubAddMode Then
                                sbtn.Text = "Add"
                                sbtn.Image = ImageCollection.Images.Item(0)
                                sbtn.ImageIndex = 2
                            Else
                                sbtn.Text = "Edit"
                                sbtn.Image = ImageCollection.Images.Item(2)
                                sbtn.ImageIndex = 0
                            End If
                            SubAddMode = False
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) - sbtn.Size.Width - 3, 18)
                        End If
                        'Cancel Button
                        If sbtn.Text = "Cancel" Then
                            sbtn.Image = ImageCollection.Images.Item(1)
                            sbtn.ImageIndex = 0
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) + 3, 18)
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub ContactView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles ContactView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim LName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("LName")
        Dim FName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FName")
        'Dim LName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("LName")

        With view
            AllowSaving(Name, False)
            'LName
            If .GetRowCellValue(.FocusedRowHandle, LName) Is System.DBNull.Value Or .GetRowCellValue(.FocusedRowHandle, LName) Is Nothing Then
                .SetColumnError(LName, "Please enter Last Name.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                If .GetRowCellValue(.FocusedRowHandle, LName).Equals("") Then
                    .SetColumnError(LName, "Please enter Last Name.")
                    e.Valid = False
                    AllowSaving(Name, False)
                Else
                    .SetColumnError(LName, "")
                End If
            End If

            'FName
            If .GetRowCellValue(.FocusedRowHandle, FName) Is System.DBNull.Value Or .GetRowCellValue(.FocusedRowHandle, FName) Is Nothing Then
                .SetColumnError(FName, "Please enter First Name.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                If .GetRowCellValue(.FocusedRowHandle, FName).Equals("") Then
                    .SetColumnError(FName, "Please enter First Name.")
                    e.Valid = False
                    AllowSaving(Name, False)
                Else
                    .SetColumnError(FName, "")
                End If
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub


#End Region


    Private Sub ContactView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles ContactView.ValidatingEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim requiredFieldNames As String = "LName;FName;"
        With view
            If InStr(1, requiredFieldNames, .FocusedColumn.FieldName) > 0 Then
                If IsNothing(e.Value) Then
                    .SetColumnError(.FocusedColumn, "Invalid Input")
                End If
            End If
        End With

    End Sub

    Private Sub cboFKeyPort_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyPort.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cboFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
