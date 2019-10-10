Public Class TravelDoc

#Region "Easy Edit"
    Private FormName As String = "Admin Document Type"

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
        repCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC, SortCode ASC")
        MainGrid.ForceInitialize()
        Dim newCol As DevExpress.XtraGrid.Columns.GridColumn = Me.MainView.Columns.AddField("ValDesc")
        newCol.VisibleIndex() = MainView.Columns.Count + 1
        newCol.UnboundType = DevExpress.Data.UnboundColumnType.String
        Me.MainView.OptionsView.ColumnAutoWidth = True
        newCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
        newCol.Caption = "Validation Description"
        newCol.OptionsColumn.ReadOnly = True
        newCol.OptionsColumn.AllowFocus = False
        MainView.VisibleColumns(1).Width = 150
        SetGridLayout(Me.MainView)

    End Sub

    Private Sub LoadSub()
        Dim dt As DataTable
        dt = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmDocCntry WHERE FKeyDocument='" & strID & "'")
        Me.MainGrid.DataSource = dt
    End Sub

    'Refresh Data
    Public Overrides Sub RefreshData()
        TableName = "tblAdmDocument"
        MyBase.RefreshData()
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteCaption(Name, "Delete Document Type")
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Travel Document Details - " & strDesc)
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
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), 0))
            Me.txtFileTag.Text = Trim(IfNull(blList.GetFocusedRowData("FileTag"), ""))
            Me.txtRemarks.Text = Trim(IfNull(blList.GetFocusedRowData("Remarks"), ""))
            Me.chkAllowDuplicate.EditValue = CBool((IfNull(blList.GetFocusedRowData("AllowDuplicate"), "0")))
            Me.txtBufferNo.EditValue = Trim(IfNull(blList.GetFocusedRowData("BufferNo"), 0))


            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'for SUB DATA
            EditSubAllowGrid(Me.MainView, False)
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
        AllowDeletion(Name, False)
        'MainView Sub
        EditSubAllowGrid(Me.MainView, isEditdable)
    End Sub

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Me.txtName.Focus()
        Me.txtName.BackColor = SEL_COLOR
        Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName, "FKeyDocGroup='SYSTRAVELDOC'")
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowEditing(Name, False) 'Dont Allow Edit Button
            AllowDeletion(Name, False)
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            '<!-- added by tony20171124
            Try
                Me.txtFileTag.Text = GenerateFileTag(MPSDB)
            Catch ex As Exception
            End Try
            '-->
            Me.header.Text = strDesc
            Dim tempDT As DataTable
            tempDT = DB.CreateTable("SELECT *, CAST(0 as bit) As Edited FROM dbo.tblAdmDocCntry WHERE FKeyDocument = '" & strID & "'")
            Me.MainGrid.DataSource = tempDT
            EditSubAllowGrid(Me.MainView, True)
            BRECORDUPDATEDs = False
        End If

    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False

        If Not MainView.HasColumnErrors() Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Document", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                        Exit Sub
                        'Return False
                    Else
                        info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy,FKeyDocGroup", "'" & LastUpdatedBy & "','SYSTRAVELDOC'"))
                        BRECORDUPDATEDs = False
                        id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                        type = "Inserted"
                    End If
                Else
                    id = strID
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & id & "'") Then
                        Exit Sub
                    Else
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
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Document Country & Validity", 10, System.Environment.MachineName, Me.txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyCntry"), FormName)
                            If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                                query.Add("INSERT INTO dbo.tblAdmDocCntry (FKeyCntry,FKeyDocument,Validity,LastUpdatedBy) VALUES('" & .GetRowCellValue(i, "FKeyCntry") & "','" & id & "','" & .GetRowCellValue(i, "Validity") & "','" & LastUpdatedBy & "')")
                            Else
                                id = strID
                                'query.Add("UPDATE dbo.tblAdmDocCntry SET FKeyCntry='" & .GetRowCellValue(i, "FKeyCntry") & "', Validity='" & .GetRowCellValue(i, "Validity") & "', LastUpdatedBy='" & LastUpdatedBy & "' , DateUpdated=(getdate()) WHERE FKeyDocument='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                                query.Add("UPDATE dbo.tblAdmDocCntry SET FKeyCntry='" & .GetRowCellValue(i, "FKeyCntry") & "', Validity='" & .GetRowCellValue(i, "Validity") & "', LastUpdatedBy='" & LastUpdatedBy & "' , DateUpdated=(getdate()) WHERE FKeyDocument='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                            End If
                        End If
                    Next
                End With
                info = DB.RunSqls(query)
                BRECORDUPDATEDs = False
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

    'Validation Check
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
                        'If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
                        '    flag = False
                        '    ALLOWNEXTS = flag
                        'Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData() '
                        'End If
                    Else
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & strID & "'") Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            SaveData() '
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

    'Delete
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
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Document", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    "Travel Document", _
                    "Admin", _
                    TableName, _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Admin Data - Travel Document >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <Travel Document>", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "' AND FKeyDocGroup='SYSTRAVELDOC'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    ClearFields(Me.LayoutControl1.Root, False)
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

        With focusedView
            .CancelUpdateCurrentRow()
            If MsgBox("Are you sure want to delete " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCntry") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Document Country & Validity", 10, System.Environment.MachineName, Me.txtName.EditValue & " : " & MainView.GetRowCellDisplayText(MainView.FocusedRowHandle, "FKeyCntry"), FormName)
                    clsAudit.saveAuditPreDelDetails("tblAdmDocCntry", MainView.GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                        "Travel Document", _
                        "Admin", _
                        "tblAdmDocCntry", _
                        "PKey IN ('" & MainView.GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Admin Data - Travel Document - Country >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Travel Document - Country>", _
                        GetUserName())
                    '-->
                    DB.RunSql("DELETE FROM dbo.tblAdmDocCntry WHERE PKey='" & MainView.GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                End If
                .DeleteRow(.FocusedRowHandle)
                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
            End If
        End With
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

#Region "TravelDoc Sub"

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.MainView
                .SetRowCellValue(e.RowHandle, "Edited", True)
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
            AllowDeletion(Name, True)
            'Else
            '    focusedView = Nothing
            '    SetDeleteCaption(Name, "Delete Document Type")
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

    Private Sub MainView_LostFocus(sender As Object, e As System.EventArgs) Handles MainView.LostFocus
        If isEditdable Or bAddMode Then
            AllowDeletion(Name, False)
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Document Type")
        End If

    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        ViewRowCellStyle(sender, e, "FKeyCntry;Validity;")

    End Sub

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles MainView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Add Travel Document Country"
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
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
        Dim Validity As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Validity")

        With view
            AllowSaving(Name, False)
            'Validate Country
            If .GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
                .SetColumnError(Cntry, "Please select Country.")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(Cntry, "")
            End If

            ''Validate
            'If .GetRowCellValue(e.RowHandle, Validity) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Validity) Is Nothing Then
            '    .SetColumnError(Validity, "Please Enter Validity.")
            '    AllowSaving(Name, False)
            '    e.Valid = False
            'Else
            '    If IsNothing(.GetRowCellValue(e.RowHandle, Validity)) Then
            '        .SetColumnError(Validity, "Please Enter Validity.")
            '        AllowSaving(Name, False)
            '        e.Valid = False
            '    Else
            '        .SetColumnError(Validity, "")
            '    End If
            'End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub


#End Region

    Private Sub ViewValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            With _view
                Dim AllowDup As Boolean = False
                If .FocusedColumn.FieldName.Equals("FKeyCntry") Then
                    If DB.HasDuplicate("tblAdmDocCntry", "FKeyCntry= '" & e.Value & "' AND FKeyDocument='" & strID & "'") Then
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

    Private Sub MainView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles MainView.ValidatingEditor
        ViewValidatingEditor(sender, e)
    End Sub

    Private Sub repCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
