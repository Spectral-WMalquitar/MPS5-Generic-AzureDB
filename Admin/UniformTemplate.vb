Public Class UniformTemplate

#Region "Easy Edit"
    Private FormName As String = "Admin Uniform Template"
    'LASTUPDATED BY FORMAT
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
    Dim type As String = "" 'Used for message

    Dim tblAdmGarment As New DataTable
#End Region


    Public Overrides Sub RefreshData()
        TableName = "tblAdmGarmentTemplate"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Uniform Template Details - " & strDesc)
        strRequiredFields = "txtName"
        If Not bLoaded Then
            LoadSub()
            initControls()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
            LoadSub()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False

            LoadSub()
            EditSubAllowGrid(SubGridView, False)

        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub

    Sub LoadSub()
        'GARMENT ITEMS
        SubGrid.DataSource = DB.CreateTable("SELECT cast(0 as bit) Edited, gitem.*, g.PhotoPath FROM dbo.tblAdmGarmentTemplateItem gitem LEFT JOIN dbo.tblAdmGarment g ON gitem.FKeyGarment = g.PKey WHERE FKeyGarmentTemplate = '" & strID & "'")
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
        EditSubAllowGrid(Me.SubGridView, isEditdable)
        AllowDeletion(Name, isEditdable)
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Me.txtSortCode.EditValue = 0
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            Dim dt As DataTable = TryCast(SubGrid.DataSource, DataTable)
            dt.Rows.Clear()
            SubGrid.DataSource = dt
            AllowSaving(Name, True) 'Enable save button 
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            EditSubAllowGrid(Me.SubGridView, bAddMode)
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
        header.Focus()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Uniform Template", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    info = info And DB.RunSqls(SaveGarments())
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    blList.SetSelection(DB.GetLastInsertedItem("PKey", Me.TableName))
                    type = "Inserted"
                End If
            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & strID & "'"))
                    info = info And DB.RunSqls(SaveGarments())
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

    Function SaveGarments() As ArrayList
        Dim query As New ArrayList
        With Me.SubGridView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    Dim cAuditDesc As String = ConcatWithSpaces(New Object() {"Garment Items for Uniform Template [" & txtName.EditValue.ToString.Replace("'", "''") & "]"})
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Uniform", 0, System.Environment.MachineName, cAuditDesc, "Uniform Issuance", strID)

                    Dim FKeyGarmentTemplate As String = ""
                    If bAddMode Then
                        FKeyGarmentTemplate = DB.GetLastInsertedItem("PKey", "tblAdmGarmentTemplate")
                    Else
                        FKeyGarmentTemplate = strID
                    End If

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblAdmGarmentTemplateItem(FKeyGarmentTemplate, FKeyGarment, SortCode, Remarks, DateUpdated, LastUpdatedBy, Qty)" & _
                                   "VALUES('" & FKeyGarmentTemplate & "'" & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "FKeyGarment"), "").Equals(""), "NULL", "'" & .GetRowCellValue(i, "FKeyGarment") & "'") & _
                                   "," & IfNull(.GetRowCellValue(i, "SortCode"), 0) & _
                                   "," & IIf(IfNull(.GetRowCellValue(i, "Remarks"), "").Equals(""), "NULL", "'" & .GetRowCellValue(i, "Remarks") & "'") & _
                                   ",getdate() " & _
                                   ",'" & LastUpdatedBy & "' " & _
                                   "," & IfNull(.GetRowCellValue(i, "Qty"), 0) & ")")
                        Type = "Inserted"
                    Else
                        query.Add("UPDATE dbo.tblAdmGarmentTemplateItem SET " & _
                                  "FKeyGarment = " & IIf(IfNull(.GetRowCellValue(i, "FKeyGarment"), "").Equals(""), "NULL", "'" & .GetRowCellValue(i, "FKeyGarment") & "'") & _
                                  ",SortCode = " & IfNull(.GetRowCellValue(i, "Quantity"), 0) & _
                                  ",Remarks = " & IIf(IfNull(.GetRowCellValue(i, "Remarks"), "").Equals(""), "NULL", "'" & .GetRowCellValue(i, "Remarks") & "'") & _
                                  ",DateUpdated = getdate() " & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                  ",Qty = " & IfNull(.GetRowCellValue(i, "Qty"), 0) & " " & _
                                  " WHERE FKeyGarmentTemplate = '" & FKeyGarmentTemplate & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        Type = "Updated"
                    End If
                End If
            Next
        End With
        Return query
    End Function

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
        If IsNothing(focusedView) Then
            DeleteMain()
        Else
            DeleteSubTable()
        End If
    End Sub

    Sub DeleteMain()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Uniform Template", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
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

    Sub DeleteSubTable()
        Dim info As Boolean

        With focusedView
            Dim SubDesc As String = ""
            SubDesc = .GetRowCellDisplayText(.FocusedRowHandle, "FKeyGarment")
            If MsgBox("Are you sure want to delete the '" & SubDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                'Delete Per Record
                If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                    If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then
                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                            FormName, _
                            "Admin", _
                            "tbladmgarmenttemplateitem", _
                            "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                            "<< Delete Admin Data - " & FormName & " - Garment Item >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & "- Garment Item>", _
                            GetUserName())
                        '-->
                        info = DB.RunSql("DELETE dbo.tbladmgarmenttemplateitem WHERE PKey ='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
                .DeleteRow(.FocusedRowHandle)
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
            End If
        End With
    End Sub


    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False

        'GARMENT REPOSITORY
        tblAdmGarment = DB.CreateTable("SELECT g.*, gt.name as GarmentType FROM dbo.tblAdmGarment g LEFT JOIN dbo.tblAdmGarmentType gt ON g.FKeyGarmentType = gt.PKey ORDER BY g.Name")
        repGarment.DataSource = tblAdmGarment
        'repGarment.DataSource = DB.CreateTable("SELECT g.*, gt.name as GarmentType FROM dbo.tblAdmGarment g LEFT JOIN dbo.tblAdmGarmentType gt ON g.FKeyGarmentType = gt.PKey ORDER BY g.Name")

    End Sub

    Private Sub SubGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles SubGridView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.SubGridView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub SubGridView_GotFocus(sender As Object, e As System.EventArgs) Handles SubGridView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, True)
            focusedView = view
            SetDeleteCaption(Name, "Delete Garment")
        Else
            focusedView = Nothing
            AllowDeletion(Name, False)
            SetDeleteCaption(Name, "Delete")
        End If
    End Sub

    Private Sub SubGridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles SubGridView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyGarmentTemplate"), strID)
        View.SetRowCellValue(e.RowHandle, View.Columns("SortCode"), 0)
        View.SetRowCellValue(e.RowHandle, View.Columns("Qty"), 1)
        SubAddMode = True
    End Sub

    Private Sub repGarment_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repGarment.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
            Dim PhotoPath As String = ""

            If Not IsNothing(row) Then
                If Not IfNull(row("PhotoPath"), "").Equals("") Then PhotoPath = GetGarmentPhotoPath(row("PKey"), row("PhotoPath"))
            End If

            If Not IfNull(PhotoPath, "").Equals("") Then
                Dim f As New frmImagePreview(PhotoPath, row("Name"))
                f.ShowDialog()
            Else
                MsgBox("Preview not available", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub SubGridView_LostFocus(sender As Object, e As System.EventArgs) Handles SubGridView.LostFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        focusedView = Nothing
        AllowDeletion(Name, False)
        SetDeleteCaption(Name, "Delete")
    End Sub

    Private Sub SubGridView_ShownEditor(sender As Object, e As System.EventArgs) Handles SubGridView.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)


        If view.FocusedColumn.FieldName.Equals("FKeyGarment") Then

            Dim dv As DataView = New DataView(tblAdmGarment)
            Dim cCondition As String = GetSelectedGarmentsAsFilterString("PKey", view.FocusedRowHandle)

            With view
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)

                If IfNull(cCondition, "").Length > 0 Then
                    dv.RowFilter = cCondition
                End If

                edit.Properties.DataSource = dv.ToTable

            End With
        End If


    End Sub

    Private Function GetSelectedGarmentsAsFilterString(FieldName As String, CurrentRow As Integer) As String
        Dim returnValue As String = ""
        SubGridView.UpdateCurrentRow()

        For i As Integer = 0 To SubGridView.RowCount - 1
            If i <> CurrentRow Then
                returnValue = returnValue & IIf(IfNull(returnValue, "").Length > 0, " AND ", "") & _
                FieldName & " <> '" & SubGridView.GetRowCellValue(i, "FKeyGarment") & "'"

            End If
            
        Next

        Return returnValue
    End Function
End Class
