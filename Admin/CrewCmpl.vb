Public Class CrewCmpl

#Region "Easy Edit"
    Private FormName As String = "Admin Crew Compliment"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        Me.repRankCode.DataSource = DB.CreateTable("SELECT PKey,Name,SortCode FROM dbo.tblAdmRank ORDER BY Name")
    End Sub

    Private Sub LoadSub()
        BRECORDUPDATEDs = False
        Me.MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.frmadmCrewCmplSub WHERE FKeyCrewCmpl='" & strID & "' ORDER BY RankSort")
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblAdmCrewCmpl"
        MyBase.RefreshData()
        SetDeleteCaption(Name, "Delete Crew Compliment")
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Crew Compliment Details - " & strDesc)
        strRequiredFields = "txtName"
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
            'add sub
            EditSubAllowGrid(Me.MainView, False)
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub
    'Edit
    Public Overrides Sub EditData()
        txtName.Focus()
        MyBase.EditData()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, True)
            EditSubAllowGrid(Me.MainView, isEditdable)
        Else
            AllowDeletion(Name, False)
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EditSubAllowGrid(Me.MainView, isEditdable)
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        AllowDeletion(Name, True)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowDeletion(Name, True)
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            Me.MainGrid.DataSource = DB.CreateTable("SELECT * ,cast(0 as bit) as Edited FROM dbo.frmadmCrewCmplSub WHERE FKeyCrewCmpl='" & strID & "'")
            BRECORDUPDATEDs = False
        End If
        EditSubAllowGrid(Me.MainView, True)

    End Sub

    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False
        If Not Me.MainView.HasColumnErrors Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Compliment", 10, System.Environment.MachineName, txtName.EditValue, FormName)
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                        Exit Sub
                    Else
                        info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                        BRECORDUPDATEDs = False
                        ''get the last inserted Record
                        id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                        type = "Inserted"
                    End If

                Else
                    id = strID

                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & id & "'") Then
                        Exit Sub
                    Else
                        query.Add(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                        BRECORDUPDATEDs = False
                        type = "Updated"
                    End If
                End If
                'Else
                With Me.MainView
                    .CloseEditForm()
                    .UpdateCurrentRow()
                    For i As Integer = 0 To .RowCount - 1
                        If .GetRowCellValue(i, "Edited") Then
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Compliment - Rank", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyRank"), FormName)

                            If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                                query.Add("INSERT INTO dbo.tblAdmCrewCmplRank(FKeyCrewCmpl,FKeyRank,LastUpdatedBy) " & _
                                          "VALUES('" & id & "','" & .GetRowCellValue(i, "FKeyRank") & "','" & LastUpdatedBy & "')")
                            Else
                                query.Add("UPDATE dbo.tblAdmCrewCmplRank SET FKeyRank='" & .GetRowCellValue(i, "FKeyRank") & "', DateUpdated=(getdate())  WHERE FKeyCrewCmpl='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
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
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
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
            DeleteSubTable()
        End If
    End Sub

    Private Sub DeleteMain()
        MyBase.DeleteData()
        Dim info As Boolean = False

        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Compliment", 10, System.Environment.MachineName, txtName.EditValue, FormName)

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

        With focusedView
            .CancelUpdateCurrentRow()
            If MsgBox("Are you sure want to delete '" & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Compliment - Rank", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyRank"), FormName)

                    clsAudit.saveAuditPreDelDetails("tblAdmCrewCmplRank", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                        FormName, _
                        "Admin", _
                        "tblAdmCrewCmplRank", _
                        "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Admin Data - " & FormName & " - Rank >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & "- Rank>", _
                        GetUserName())
                    '-->
                    DB.RunSql("DELETE FROM dbo.tblAdmCrewCmplRank WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
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

    Private Sub MainView_ValidateRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Rank As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyRank"), CrewCmpl As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCrewCmpl")

        AllowSaving(Name, False)
        If view.GetRowCellValue(e.RowHandle, Rank) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Rank) Is Nothing Then
            e.Valid = False
            view.SetColumnError(CrewCmpl, "Please enter Crew Compliment.")
            Me.MainView.FocusedColumn = Me.MainView.VisibleColumns(1)
            AllowSaving(Name, False)
        ElseIf view.GetRowCellValue(e.RowHandle, Rank) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Rank) Is Nothing Then
            e.Valid = False
            view.SetColumnError(Rank, "Please enter Rank.")
            Me.MainView.FocusedColumn = Me.MainView.VisibleColumns(0)
            AllowSaving(Name, False)
        Else
            e.Valid = True
            view.ClearColumnErrors()
            AllowSaving(Name, True)
        End If
    End Sub

#Region "Crew Compliment"
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

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyCrewCmpl"), strID)
        SubAddMode = True
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MainView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            MainView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") And MainView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub
    'Popup Form
    Private Sub MainView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles MainView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Rank"
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

    Private Sub MainView_GotFocus(sender As Object, e As System.EventArgs) Handles MainView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Then
            'Deleted Sub Table
            focusedView = view
            SetDeleteCaption(Name, "Delete Rank")
        Else
            'Delete Main Table
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Crew Compliment")
        End If
    End Sub
#End Region


    Private Sub repRankCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repRankCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
