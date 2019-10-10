Public Class NatInfo

#Region "Easy Edit"
    Private FormName As String = "Admin National Information"

    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        'Repository ITEMS
        repFKeyCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC, SortCode ASC")
        MainGrid.ForceInitialize()
        Dim newCol As DevExpress.XtraGrid.Columns.GridColumn = Me.MainView.Columns.AddField("ValDesc")
        newCol.VisibleIndex() = MainView.Columns.Count + 1
        newCol.UnboundType = DevExpress.Data.UnboundColumnType.String
        Me.MainView.OptionsView.ColumnAutoWidth = True
        newCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
        newCol.Caption = "Validation Description"
        newCol.OptionsColumn.ReadOnly = True

        MainView.VisibleColumns(1).Width = 150
    End Sub

    Private Sub LoadSub()
        BRECORDUPDATEDs = False
        Dim dt As DataTable
        dt = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmDocCntry WHERE FKeyDocument='" & strID & "'")
        Me.MainGrid.DataSource = dt
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblAdmDocument"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "National Information Details - " & strDesc)
        SetDeleteCaption(Name, "Delete National Information")
        strRequiredFields = "txtName;txtFileTag"
        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.txtFileTag.Text = Trim(IfNull(blList.GetFocusedRowData("FileTag"), ""))
            Me.txtRemarks.Text = Trim(IfNull(blList.GetFocusedRowData("Remarks"), ""))
            'for SUB DATA
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EditSubAllowGrid(Me.MainView, False)
            LoadSub()
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            txtName.Focus()
            AllowDeletion(Name, True)
            RemoveReadOnlyListener(Me.LayoutControl1.Root)

            'MainView Sub
            EditSubAllowGrid(Me.MainView, isEditdable)

        Else
            txtName.Focus()
            'MyBase.EditData()
            AllowDeletion(Name, False)
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'MainView Sub
            EditSubAllowGrid(Me.MainView, isEditdable)

        End If
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False
        If Not Me.MainView.HasColumnErrors Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                'LASTUPDATED BY FORMAT
                'getusername() & <Description><FormName>
                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil   'tony20160719
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "National Information", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil

                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                        Exit Sub
                    Else
                        info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy,FKeyDocGroup", "'" & LastUpdatedBy & "','SYSNATINFO'"))
                        BRECORDUPDATEDs = False
                        id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                        type = "Inserted"
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & strID & "'") Then
                        Exit Sub
                    Else
                        id = strID
                        query.Add(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                        BRECORDUPDATEDs = False
                        type = "Updated"
                    End If

                End If

                'for sub table
                With Me.MainView
                    .CloseEditForm()
                    .UpdateCurrentRow()
                    For i As Integer = 0 To .RowCount - 1
                        If .GetRowCellValue(i, "Edited") Then
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "National Information Country & Validity", 10, System.Environment.MachineName, Me.txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyCntry"), FormName)
                            If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                                query.Add("INSERT INTO dbo.tblAdmDocCntry (FKeyCntry,FKeyDocument,Validity,LastUpdatedBy) VALUES('" & .GetRowCellValue(i, "FKeyCntry") & "','" & id & "','" & .GetRowCellValue(i, "Validity") & "','" & LastUpdatedBy & "')")
                            Else
                                id = strID
                                query.Add("UPDATE dbo.tblAdmDocCntry SET FKeyCntry='" & .GetRowCellValue(i, "FKeyCntry") & "', Validity='" & .GetRowCellValue(i, "Validity") & "', LastUpdatedBy='" & LastUpdatedBy & "' , DateUpdated=(getdate()) WHERE FKeyDocument='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                            End If
                        End If
                    Next
                End With
                info = DB.RunSqls(query)
                blList.RefreshData()
                If info Then
                    blList.SetSelection(id)
                    RefreshData()
                    MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
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
            If MainView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, showMsg) Then
                    If bAddMode Then
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            SaveData()
                        End If
                    Else
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & strID & "'") Then
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
            ALLOWNEXTS = True 'i must proceed to the intended process
        End If
        Return flag
    End Function

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
        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then

                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "National Information", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    TableName, _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Crew Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    ClearFields(Me.LayoutControl1.Root, False)
                    LoadSub()
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    RefreshData()
                    blList.RefreshData()
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub

    Private Sub DeleteSubTable()

        If MsgBox("Are you sure want to delete '" & MainView.GetRowCellDisplayText(MainView.FocusedRowHandle, "FKeyCntry") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey"), "") <> "" Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "National Information Country & Validity", 10, System.Environment.MachineName, Me.txtName.EditValue & " : " & MainView.GetRowCellDisplayText(MainView.FocusedRowHandle, "FKeyCntry"), FormName)
                clsAudit.saveAuditPreDelDetails("tblAdmDocCntry", Me.MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblAdmDocCntry", _
                    "PKey IN ('" & MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey") & "')", _
                    "<< Delete Crew Data - " & FormName & " - Country >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & "-Country>", _
                    GetUserName())
                '-->
                DB.RunSql("DELETE FROM dbo.tblAdmDocCntry WHERE PKey='" & MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey") & "'")
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
            MainView.DeleteRow(MainView.FocusedRowHandle)
            If MainView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
        End If
    End Sub

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowEditing(Name, False) 'Allow Edit Button
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            '<!-- added by tony20171124
            Try
                Me.txtFileTag.Text = GenerateFileTag(MPSDB)
            Catch ex As Exception
            End Try
            '-->
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName, "FKeyDocGroup='SYSNATINFO'")
            BRECORDUPDATEDs = False
        End If
        Me.MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmDocCntry WHERE FKeyDocument = '" & strID & "'")
        EditSubAllowGrid(Me.MainView, True)


    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

#Region "National Info Sub"

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.MainView
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
            End With
        End If

    End Sub

    Private Sub MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles MainView.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "ValDesc" AndAlso e.IsGetData Then
            e.Value = getValDesc(view, e.ListSourceRowIndex)
        End If
    End Sub

    Private Sub MainView_GotFocus(sender As Object, e As System.EventArgs) Handles MainView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Country")
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete National Information")
        End If
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyDocument"), strID)
        SubAddMode = True
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MainView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            MainView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
        strRequiredFieldName = "FKeyCntry;Validity;"
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

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles MainView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Add National Information Country"
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

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
        'If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        '    If view.GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
        '        e.Valid = False
        '        view.SetColumnError(Cntry, "Please enter Country")
        '        view.FocusedColumn = view.VisibleColumns(0)
        '    End If
        'End If

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
        Dim Validity As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Validity")

        AllowSaving(Name, False)
        If view.GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
            e.Valid = False
            view.SetColumnError(Cntry, "Please enter Country")
            'view.GetDataRow(e.RowHandle).SetColumnError(view.Columns(2).FieldName, "Please enter Country")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
            'Else
            '    e.Valid = True
        ElseIf view.GetRowCellValue(e.RowHandle, Validity) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Validity) Is Nothing Then
            e.Valid = False
            view.SetColumnError(Validity, "Please enter Validity")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        ElseIf view.GetRowCellValue(e.RowHandle, Validity) = "" Then
            e.Valid = False
            view.SetColumnError(Validity, "Please enter Validity")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        Else
            e.Valid = True
            view.GetDataRow(e.RowHandle).ClearErrors()
            AllowSaving(Name, True)
        End If

    End Sub

    Private Sub MainView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles MainView.ValidatingEditor
        ViewValidatingEditor(sender, e)
    End Sub

#End Region


    Private Sub ViewValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            With _view
                Dim AllowDup As Boolean = False
                If .FocusedColumn.FieldName.Equals("FKeyCntry") Then
                    If DB.HasDuplicate("tblAdmDocCntry", "FKeyCntry= '" & e.Value & "' AND FKeyDocument='" & .GetFocusedRowCellValue("FKeyDocument") & "'") Then
                        e.Valid = False
                        .SetColumnError(.FocusedColumn, "Already in use.")
                    Else
                        For i As Integer = 0 To .DataRowCount - 1
                            If i <> (.FocusedRowHandle) Then
                                If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                                    e.Valid = False
                                    .SetColumnError(.FocusedColumn, "Already in use.")
                                Else
                                    .SetColumnError(.FocusedColumn, "")
                                    e.Valid = True
                                End If
                            End If
                        Next
                    End If


                Else
                    .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub repFKeyCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFKeyCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
