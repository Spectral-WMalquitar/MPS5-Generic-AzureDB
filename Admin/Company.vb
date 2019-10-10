Public Class Company

#Region "Easy Edit"
    Private FormName As String = "Admin Company"

    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
#End Region

    Dim photo_path As String
    Dim fStream As IO.FileStream

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        Me.cboFKeyCntry.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC,SortCode ASC")
    End Sub

    Private Sub LoadSub()
        BRECORDUPDATEDs = False
        Dim dt As DataTable
        dt = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmCompanyContact WHERE FKeyCompany='" & strID & "'")
        Me.ContactGrid.DataSource = dt

        'If strID <> "" Then
        '    Me.ContactGrid.Enabled = True
        'End If
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblAdmCompany"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Company Details - " & strDesc)
        SetDeleteCaption(Name, "Delete Company")
        strRequiredFields = "txtName,txtAbbrv,cboFKeyCntry"
        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()
        Else
            LoadSub()
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.txtAbbrv.Text = Trim(IfNull(blList.GetFocusedRowData("Abbrv"), ""))
            Me.txtAddr.Text = Trim(IfNull(blList.GetFocusedRowData("Addr"), ""))
            Me.txtPhone.Text = Trim(IfNull(blList.GetFocusedRowData("Phone"), ""))
            Me.txtTelefax.Text = Trim(IfNull(blList.GetFocusedRowData("Telefax"), ""))
            Me.txtEmail.Text = Trim(IfNull(blList.GetFocusedRowData("Email"), ""))
            Me.cboFKeyCntry.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyCntry"), ""))
            Me.chkisManAgent.Checked = Trim(IfNull(blList.GetFocusedRowData("isManAgent"), 0))
            Me.chkisPrincipal.Checked = Trim(IfNull(blList.GetFocusedRowData("isPrincipal"), 0))
            Me.chkisOwner.Checked = Trim(IfNull(blList.GetFocusedRowData("isOwner"), 0))

            'for SUB DATA
            EditSubAllowGrid(Me.ContactView, False)
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
        LoadCompanyLogo(GetLogoPath, pbLogo)
        setButtonEdit(False)
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            'Contact Sub
            EditSubAllowGrid(Me.ContactView, True)
        Else
            MyBase.EditData()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'Contact Sub
            EditSubAllowGrid(Me.ContactView, False)
        End If
        setButtonEdit(isEditdable)
        AllowDeletion(Name, False)
    End Sub

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
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR

            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)

            BRECORDUPDATEDs = False
            setButtonEdit(True)
        End If
        Me.ContactGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmCompanyContact WHERE FKeyCompany = '" & strID & "'")
        Me.ContactView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
        Me.ContactView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
        Me.ContactView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        Me.ContactView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False
        If Not ContactView.HasColumnErrors Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, cboFKeyCntry}) Then
                'LASTUPDATED BY FORMAT
                'getusername() & <Description><FormName>
                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company", 10, System.Environment.MachineName, txtName.EditValue, FormName)
                If bAddMode Then
                    If (CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "Name='" & txtName.Text & "' AND FKeyCntry='" & cboFKeyCntry.EditValue & "'") Or CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtAbbrv})) Then
                        Exit Sub
                    Else
                        info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                        BRECORDUPDATEDs = False
                        id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                        DB.RunSqls(SaveContacts(id))
                        type = "Inserted"
                    End If
                Else
                    id = strID
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}, "PKey<>'" & id & "' AND (Name<>'" & txtName.Text & "' AND FKeyCntry<>'" & Me.cboFKeyCntry.EditValue & "'AND Abbrv='" & txtAbbrv.Text & "' )") Then
                        Exit Sub
                    Else
                        Dim qupdstr As String = GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=(getdate())", "PKey='" & id & "'")
                        info = UpdateRelatedAdminName(id, TableName, qupdstr)
                        BRECORDUPDATEDs = False
                        type = "Updated"
                        DB.RunSqls(SaveContacts(id))
                    End If
                End If
                SaveLogo(GetLogoPath(id))
                blList.RefreshData()
                If info Then
                    MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
                    RefreshData()
                    blList.SetSelection(id)
                End If
            End If
        Else
            info = False
            MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
        End If

    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ContactView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, cboFKeyCntry}, showMsg) Then
                    If bAddMode Then
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "Name='" & Me.txtName.Text & "' AND FKeyCntry='" & Me.cboFKeyCntry.EditValue & "'") Or CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtAbbrv}) Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            SaveData()
                        End If
                    Else
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}, "PKey<>'" & strID & "' AND (Name<>'" & txtName.Text & "' AND FKeyCntry<>'" & Me.cboFKeyCntry.EditValue & "'AND Abbrv='" & txtAbbrv.Text & "' )") Then
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
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            DeleteMain()
        Else
            DeleteSubItem()
        End If
    End Sub

    Private Sub DeleteMain()
        MyBase.DeleteData()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company", 10, System.Environment.MachineName, txtName.EditValue, FormName)
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

    'for form Initialization
    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

#Region "Company Contacts Subs"

    Private Function SaveContacts(id As String) As ArrayList
        Dim query As New ArrayList

        With Me.ContactView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        Dim cDataDescription As String = ConcatWithSpaces(New Object() {.GetRowCellValue(i, "FName"), _
                                                                                       .GetRowCellValue(i, "MName"), _
                                                                                       .GetRowCellValue(i, "LName")})
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company Contacts", 10, System.Environment.MachineName, txtName.EditValue & " / " & cDataDescription, FormName)
                        query.Add("INSERT INTO dbo.tblAdmCompanyContact(FKeyCompany" & _
                                  ",LName" & _
                                  ",FName" & _
                                  ",MName" & _
                                  ",Pos" & _
                                  ",PhoneOff" & _
                                  ",PhoneRes" & _
                                  ",Email" & _
                                  ",LastUpdatedBy)" & _
                                  "VALUES('" & id & "'" & _
                                  ",'" & .GetRowCellValue(i, "LName") & "'" & _
                                  ",'" & .GetRowCellValue(i, "FName") & "'" & _
                                  ",'" & .GetRowCellValue(i, "MName") & "'" & _
                                  ",'" & .GetRowCellValue(i, "Pos") & "'" & _
                                  ",'" & .GetRowCellValue(i, "PhoneOff") & "'" & _
                                  ",'" & .GetRowCellValue(i, "PhoneRes") & "'" & _
                                  ",'" & .GetRowCellValue(i, "Email") & "'" & _
                                  ",'" & LastUpdatedBy & "')")
                    Else
                        'id = strID
                        query.Add("UPDATE dbo.tblAdmCompanyContact " & _
                                  "SET LName='" & .GetRowCellValue(i, "LName") & "'" & _
                                  ", FName='" & .GetRowCellValue(i, "FName") & "'" & _
                                  ", MName='" & .GetRowCellValue(i, "MName") & "'" & _
                                  ", Pos='" & .GetRowCellValue(i, "Pos") & "'" & _
                                  ", PhoneOff='" & .GetRowCellValue(i, "PhoneOff") & "'" & _
                                  ", PhoneRes='" & .GetRowCellValue(i, "PhoneRes") & "'" & _
                                  ", Email='" & .GetRowCellValue(i, "Email") & "'" & _
                                  ", LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                  ", DateUpdated=(getdate()) " & _
                                  "WHERE FKeyCompany='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function


    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ContactView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.ContactView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If

    End Sub

    Private Sub MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ContactView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ContactView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyCompany"), strID)
        SubAddMode = True
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles ContactView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ContactView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            ContactView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles ContactView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ContactView.RowCellStyle
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

    End Sub

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles ContactView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim LName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("LName")
        Dim FName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FName")
        With view
            AllowSaving(Name, False)
            'Validate Last Name
            If .GetRowCellValue(e.RowHandle, LName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, LName) Is Nothing Then
                .SetColumnError(LName, "Enter Last Name.")
                e.Valid = False
            Else
                .SetColumnError(LName, "")
                e.Valid = True
            End If

            'Validate First Name
            If .GetRowCellValue(e.RowHandle, FName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FName) Is Nothing Then
                .SetColumnError(FName, "Enter First Name.")
                e.Valid = False
            Else
                .SetColumnError(FName, "")
                e.Valid = True
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With

    End Sub

    Private Sub MainView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles ContactView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Add Contacts"
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

    Private Sub ContactView_GotFocus(sender As Object, e As System.EventArgs) Handles ContactView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Contacts")
            AllowDeletion(Name, True)
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Company")
        End If
    End Sub

    Private Sub DeleteSubItem()

        If MsgBox("Are you sure want to delete the item?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If IfNull(ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey"), "") <> "" Then
                Dim cDataDescription As String = ConcatWithSpaces(New Object() {ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "FName"), _
                                                                                ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "MName"), _
                                                                                ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "LName")})
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Company Contacts", 10, System.Environment.MachineName, txtName.EditValue & " / " & cDataDescription, FormName)
                clsAudit.saveAuditPreDelDetails("tblAdmCompanyContact", ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    "tblAdmCompanyContact", _
                    "PKey IN ('" & ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey") & "')", _
                    "<< Delete Admin Data - " & FormName & " - Contact >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & " - Contact>", _
                    GetUserName())
                '-->
                DB.RunSql("DELETE FROM dbo.tblAdmCompanyContact WHERE PKey='" & ContactView.GetRowCellValue(ContactView.FocusedRowHandle, "PKey") & "'")
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
            ContactView.DeleteRow(ContactView.FocusedRowHandle)
            If ContactView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
        End If
    End Sub

#End Region


    Private Sub cboFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim fileDiag As New OpenFileDialog
        fileDiag.Filter = "Image File (*.jpg)|*.jpg"
        If fileDiag.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            photo_path = fileDiag.FileName
            pbLogo.Image = New System.Drawing.Bitmap(fileDiag.FileName)
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As System.Object, e As System.EventArgs) Handles cmdDelete.Click
        If IsNothing(pbLogo.Image) Then Exit Sub
        If MsgBox("Are you sure you want to delete the Image?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
            Try
                pbLogo.Image = Nothing
                Dim path As String = GetLogoPath()
                If IO.File.Exists(path) Then
                    IO.File.Delete(path)
                End If
                photo_path = ""
                'BRECORDUPDATEDs = True
                MsgBox("Image Deleted", MsgBoxStyle.Information, GetAppName())
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
    End Sub

    Private Sub setButtonEdit(value As Boolean)
        cmdBrowse.Enabled = value
        cmdDelete.Enabled = value
    End Sub

    Private Sub SaveLogo(destPhotoPath As String)
        If Not IsNothing(photo_path) Then
            If Not photo_path.Equals("") Then
                Try
                    If IO.File.Exists(destPhotoPath) Then
                        Kill(destPhotoPath)
                    End If
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try
                Try
                    IO.File.Copy(photo_path, destPhotoPath)
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub LoadCompanyLogo(path As String, picEdit As DevExpress.XtraEditors.PictureEdit)
        Try
            photo_path = ""
            If IO.File.Exists(path) Then
                fStream = New IO.FileStream(path, IO.FileMode.Open)
                picEdit.Image = New System.Drawing.Bitmap(fStream)
                fStream.Dispose()
            Else
                picEdit.Image = Nothing
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            picEdit.Image = Nothing
        End Try
    End Sub

    Private Function GetLogoPath(Optional id As String = "")
        Return FOLDERDIRECTORY & "\" & IIf(id = "", strID, id) & ".jpg"
    End Function

    Private Sub ContactView_LostFocus(sender As Object, e As System.EventArgs) Handles ContactView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Company")
            AllowDeletion(Name, False)
        End If
    End Sub
End Class
