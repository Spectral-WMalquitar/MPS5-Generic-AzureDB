﻿Public Class MinCrew

#Region "Easy Edit"
    Private FormName As String = "Admin Safe Manning"

    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region
    Public Overrides Sub RefreshData()
        TableName = "tbladmMinCrew"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Safe Manning Details - " & strDesc)
        SetDeleteCaption(Name, "Delete Safe Manning")
        strRequiredFields = "txtName"
        If Not bLoaded Then
            initControls()
            LoadSub()
            'AddEditListener(Me.LayoutControl1.Root)
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            LoadSub()
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            'for SUB DATA
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EditSubAllowGrid(MainView, False)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub

    'Edit
    Public Overrides Sub EditData()
        txtName.Focus()
        MyBase.EditData()
        If isEditdable Then
            AllowDeletion(Name, True)
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            EditSubAllowGrid(MainView, isEditdable)
        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, False)
            EditSubAllowGrid(MainView, isEditdable)

        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowSaving(Name, True) 'Enable save button 
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            Me.MainGrid.DataSource = DB.CreateTable("SELECT *,Cast(0 as bit)as Edited FROM dbo.frmAdmMinCrewSub WHERE FKeyMinCrew='" & strID & "'")
            BRECORDUPDATEDs = False
        End If
        EditSubAllowGrid(MainView, True)


    End Sub

    Public Overrides Sub SaveData()
        Me.txtName.Focus()
        Dim query As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False

        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            'LASTUPDATED BY FORMAT
            'getusername() & <Description><FormName>
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Safe Manning", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil

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
                    query.Add(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                    BRECORDUPDATEDs = False
                    type = "Updated"
                End If
            End If

            'for Sub table
            With Me.MainView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "Edited") Then
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Safe Manning - Rank", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyRank"), FormName) 'neil

                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmMinCrewRank(FKeyMinCrew,FKeyRank,LastUpdatedBy) VALUES('" & id & "','" & .GetRowCellValue(i, "FKeyRank") & "','" & LastUpdatedBy & "')")
                        Else
                            query.Add("UPDATE dbo.tblAdmMinCrewRank SET FKeyMinCrew='" & id & "', FKeyRank='" & .GetRowCellValue(i, "FKeyRank") & "', LastUpdatedBy='" & LastUpdatedBy & ",DateUpdated=(getdate()) ' WHERE FKeyMinCrew='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
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
                        SaveData()
                    Else
                        flag = True
                        ALLOWNEXTS = flag
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
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Safe Manning", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil
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
    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        'Repository ITEM
        Me.repRankCode.DataSource = DB.CreateTable("SELECT * FROM tblAdmRank ORDER BY SortCode ASC")

    End Sub

    Private Sub LoadSub()
        BRECORDUPDATEDs = False
        Dim dt As DataTable
        dt = DB.CreateTable("SELECT * FROM dbo.frmAdmMinCrewSub WHERE FKeyMinCrew='" & strID & "' ORDER BY RankSC ASC")
        Me.MainGrid.DataSource = dt

        If strID <> "" Then
            Me.MainGrid.Enabled = True
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "DeleteOther"
                DeleteSubItem()
                'Case "Preview"
                '    Preview()
        End Select
    End Sub

    Private Sub DeleteSubItem()
        If MsgBox("Are you sure want to delete the Rank?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey"), "") <> "" Then

                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Safe Manning - Rank", 10, System.Environment.MachineName, txtName.EditValue & " : " & MainView.GetRowCellDisplayText(MainView.FocusedRowHandle, "FKeyRank"), FormName) 'neil
                clsAudit.saveAuditPreDelDetails("tblAdmMinCrewRank", Me.MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    "tblAdmMinCrewRank", _
                    "PKey IN ('" & Me.MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey") & "')", _
                    "<< Delete Admin Data - " & FormName & " - Rank >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & "- Rank>", _
                    GetUserName())
                '-->
                DB.RunSql("DELETE FROM dbo.tblAdmMinCrewRank WHERE PKey='" & MainView.GetRowCellValue(MainView.FocusedRowHandle, "PKey") & "'")
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
            MainView.DeleteRow(MainView.FocusedRowHandle)
            If MainView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
        End If
    End Sub


#Region "Sub table"
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

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyMinCrew"), strID)
        SubAddMode = True
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MainView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    'Popup Form
    Private Sub MainView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles MainView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Add Rank"
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

    'Validations
    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyRank")

        With view
            AllowSaving(Name, False)
            'Validate Country
            If .GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
                .SetColumnError(Cntry, "Please select Rank.")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(Cntry, "")
                e.Valid = True
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With

        'If view.GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
        '    e.Valid = False
        '    view.SetColumnError(Cntry, "Please select Rank")
        '    view.FocusedColumn = view.VisibleColumns(0)
        '    AllowSaving(Name, False)
        'Else
        '    e.Valid = True
        '    view.ClearColumnErrors()
        '    AllowSaving(Name, False)
        'End If

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
        strRequiredFieldName = "FKeyRank;"
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


#End Region


    Private Sub MainView_GotFocus(sender As Object, e As System.EventArgs) Handles MainView.GotFocus, MainView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Rank")
        End If
    End Sub

    Private Sub MainView_LostFocus(sender As System.Object, e As System.EventArgs) Handles MainView.LostFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Safe Manning")
        End If
    End Sub

    Private Sub repRankCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repRankCode.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

End Class
