Public Class CertType

#Region "Easy Edit"
    Private FormName As String = "Admin Certificate Type"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    'initialization
    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        Me.repFunc.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmLicCertFunct ORDER BY Name ASC")
        Me.repFuncLevel.DataSource = GetFuncLevel()
        Me.repCapRank.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC")
    End Sub

    Private Sub LoadSub()
        'Function
        Me.FuncGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmLicCertCap_Func WHERE FKeyDocument='" & strID & "'")

        'Capacity
        Me.CapGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.TblAdmLicCertCap_Map WHERE FKeyDocument ='" & strID & "'")
    End Sub

    'Refresh
    Public Overrides Sub RefreshData()
        TableName = "tblAdmDocument"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Certificate Type Details - " & strDesc)
        SetDeleteCaption(Name, "Delete Cert Type")
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
            Me.chkAllowDuplicate.Checked = CBool(IfNull(blList.GetFocusedRowData("AllowDuplicate"), "0"))
            Me.txtBufferNo.Text = Trim(IfNull(blList.GetFocusedRowData("BufferNo"), "0"))
            MakeReadOnlyListener(Me.LayoutControlGroup4)
            'Capacity
            EditSubAllowGrid(Me.CapView, False)
            EditSubAllowGrid(Me.FuncView, False)
            LoadSub()
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControlGroup4)

    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControlGroup4)
        Else
            MakeReadOnlyListener(Me.LayoutControlGroup4)
        End If
        EditSubAllowGrid(Me.CapView, isEditdable)
        EditSubAllowGrid(Me.FuncView, isEditdable)
        AllowDeletion(Name, False)
    End Sub

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        SetSaveCaption(Name, "Save")
        RemoveReadOnlyListener(Me.LayoutControlGroup4)
        If Not bAddMode Then
            ClearFields(Me.LayoutControlGroup4, False)
            AllowSaving(Name, True) 'Enable save button 
            AllowDeletion(Name, False)
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
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName, "FKeyDocGroup='SYSLICCERT'")
            BRECORDUPDATEDs = False
        End If
        'Capacity
        Me.CapGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM db.TblAdmLicCertCap_Map WHERE FKeyDocument ='" & strID & "'")
        EditSubAllowGrid(Me.CapView, True)
        'Function
        Me.FuncGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmLicCertCap_Func WHERE FKeyDocument='" & strID & "'")
        EditSubAllowGrid(Me.FuncView, True)

    End Sub

    'Save
    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False
        Dim query As New ArrayList, id As String = ""
        Dim FwillDelete As Boolean = False 'FUnction table
        Dim CwillDelete As Boolean = False ' Capacity Table
        Me.header.Focus()
        If FuncView.HasColumnErrors Or CapView.HasColumnErrors Then
            MsgBox("Please fill in all the required fields.", MsgBoxStyle.Critical, GetAppName)
            Exit Sub
        End If
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}) Then
            'LASTUPDATED BY FORMAT
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'tony20160719
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "FKeyDocGroup = 'SYSLICCERT'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControlGroup4, 3, Me.TableName, "LastUpdatedBy,FKeyDocGroup", "'" & LastUpdatedBy & "','SYSLICCERT'"))
                    BRECORDUPDATEDs = False
                    'get the last inserted Record
                    id = DB.GetLastInsertedItem("PKey", Me.TableName)
                    type = "Inserted"
                End If
            Else
                id = strID
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtFileTag}, "PKey<>'" & id & "' and FKeyDocGroup = 'SYSLICCERT'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControlGroup4, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & strID & "'"))
                    BRECORDUPDATEDs = False
                    type = "Updated"
                End If
            End If
            info = DB.RunSqls(SaveFunc(id)) 'insert function
            info = DB.RunSqls(SaveCapacity(id)) 'insert capacity
            bAddMode = False
            blList.RefreshData()
            blList.SetSelection(id)

            If info Then
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
                RefreshData()
            End If
        End If

    End Sub

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

    'Delete
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
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'tony20160719
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "' AND FKeyDocGroup='SYSLICCERT'")
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    ClearFields(Me.LayoutControl1.Root, False)
                    RefreshData()
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    blList.RefreshData()
                    BRECORDUPDATEDs = False
                End If
            Else
                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If
        End If
    End Sub

    'Delete Sub
    Private Sub DeleteSubItem()

        With focusedView
            Select Case focusedView.Name
                Case CapView.Name
                    If MsgBox("Are you sure you want to delete '" & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCapacity") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate Capacity", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'tony20160719
                            clsAudit.saveAuditPreDelDetails("TblAdmLicCertCap_Map", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                FormName, _
                                "Admin", _
                                "TblAdmLicCertCap_Map", _
                                "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                                "<< Delete Admin Data - " & FormName & " - Capacity >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <" & FormName & " - Capacity>", _
                                GetUserName())
                            '-->
                            DB.RunSql("DELETE FROM dbo.TblAdmLicCertCap_Map WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                        .DeleteRow(.FocusedRowHandle)
                        If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                    End If
                Case FuncView.Name
                    If MsgBox("Are you sure you want to delete '" & .GetRowCellDisplayText(.FocusedRowHandle, "FKeyLicCertFunc") & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate Function", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'tony20160719
                            clsAudit.saveAuditPreDelDetails("tblAdmLicCertCap_Funcp", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil'<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()
                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                FormName, _
                                "Admin", _
                                "tblAdmLicCertCap_Func", _
                                "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                                "<< Delete Admin Data - " & FormName & " - Function >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <" & FormName & " - Function>", _
                                GetUserName())
                            '-->
                            DB.RunSql("DELETE FROM dbo.tblAdmLicCertCap_Func WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                        .DeleteRow(.FocusedRowHandle)
                        If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                    End If
            End Select
        End With
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    'Repository for Function LEVEL
    Private Function GetFuncLevel() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.Int16")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {1, "Management"}
        ctable.Rows.Add(crow)
        crow(0) = 2
        crow(1) = "Operational"
        ctable.Rows.Add(crow)
        crow(0) = 3
        crow(1) = "Support"
        ctable.Rows.Add(crow)
        Return ctable
    End Function

#Region "Functions"
    'Save Function
    Private Function SaveFunc(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With Me.FuncView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate Function", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyLicCertFunc"), FormName) 'tony20160719

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblAdmLicCertCap_Func(FKeyDocument,FKeyLicCertFunc,LevelCode,LastUpdatedBy)" & _
                                   "VALUES('" & id & "'" & _
                                   ",'" & .GetRowCellValue(i, "FKeyLicCertFunc") & "'" & _
                                   ",'" & .GetRowCellValue(i, "LevelCode") & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblAdmLicCertCap_Func SET " & _
                                  "FKeyLicCertFunc = '" & .GetRowCellValue(i, "FKeyLicCertFunc") & "'" & _
                                  ",LevelCode = '" & .GetRowCellValue(i, "LevelCode") & "'" & _
                                  ",DateUpdated = (getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyDocument = '" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query

    End Function

    Private Sub FuncView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles FuncView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.FuncView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If

    End Sub

    Private Sub FuncView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles FuncView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub FuncView_GotFocus(sender As Object, e As System.EventArgs) Handles FuncView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Function")
            AllowDeletion(Name, True)
        End If
    End Sub

    Private Sub FuncView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles FuncView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyDocument"), strID)
        View.SetRowCellValue(e.RowHandle, View.Columns("isDelete"), False)
        'View.SetRowCellValue(e.RowHandle, View.Columns("FKeyLicCertCap"), Me.CapView.GetRowCellValue(Me.CapView.GetRow, "FKeyRank"))
        'View.SetRowCellValue(e.RowHandle, View.Columns("FKeyLicCertCap"), Me.CapView.GetRowCellValue(Me.CapView.FocusedRowHandle, "FKeyLicCertCapID"))
        SubAddMode = True
    End Sub

    Private Sub FuncView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles FuncView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub FuncView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles FuncView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            FuncView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub FuncView_LostFocus(sender As Object, e As System.EventArgs) Handles FuncView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Cert Type")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub FuncView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles FuncView.RowCellStyle
        If FuncView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
            If FuncView.GetRowCellValue(e.RowHandle, "isDelete") Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf FuncView.GetRowCellValue(e.RowHandle, "Edited") And FuncView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            If FuncView.GetRowCellValue(e.RowHandle, "isDelete") Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf FuncView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
            If FuncView.GetRowCellValue(e.RowHandle, "isDelete") Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf e.RowHandle = FuncView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If

    End Sub

    Private Sub FuncView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles FuncView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub FuncView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles FuncView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Certificate Functions"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
        e.EditForm.FormBorderStyle = FormBorderStyle.FixedSingle
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

    Private Sub FuncView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles FuncView.ValidateRow, FuncView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Funct As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyLicCertFunc")
        'If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        If view.GetRowCellValue(e.RowHandle, Funct) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Funct) Is Nothing Then
            e.Valid = False
            view.SetColumnError(Funct, "Please select a Function")
            view.FocusedColumn = view.VisibleColumns(0)
        Else
            e.Valid = True
        End If
        'End If

    End Sub
#End Region

#Region "Capacity"

    Private Function SaveCapacity(ByVal id As String) As ArrayList
        'Capacity
        Dim query As New ArrayList
        With Me.CapView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Certificate Capacity", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyCapacity"), FormName) 'tony20160719

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblAdmLicCertCap_map(FKeyDocument,FKeyCapacity,LastUpdatedBy)" & _
                                  "VALUES('" & id & "'" & _
                                  ",'" & .GetRowCellValue(i, "FKeyCapacity") & "'" & _
                                  ",'" & LastUpdatedBy & "')")
                    Else
                        id = strID
                        query.Add("UPDATE dbo.tblAdmLicCertCap_map SET " & _
                                  "FKeyCapacity = '" & .GetRowCellValue(i, "FKeyCapacity") & "'" & _
                                  ",DateUpdated = (getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyDocument = '" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")

                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub CapView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CapView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.CapView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If

    End Sub

    Private Sub CapView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CapView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CapView_GotFocus(sender As Object, e As System.EventArgs) Handles CapView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Capacity")
            AllowDeletion(Name, True)

        End If
    End Sub

    Private Sub CapView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CapView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyDocument"), strID)
        View.SetRowCellValue(e.RowHandle, View.Columns("isDelete"), False)
        'View.SetRowCellValue(e.RowHandle, View.Columns("FKeyLicCertCapID"), GenerateID(DB, "FKeyLicCertCapID", "dbo.tblAdmLicCertCap_map"))
        SubAddMode = True
    End Sub

    Private Sub CapView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CapView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CapView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CapView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            CapView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub CapView_LostFocus(sender As Object, e As System.EventArgs) Handles CapView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Cert Type")
            AllowDeletion(Name, False)
        End If

    End Sub

    Private Sub CapView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CapView.RowCellStyle
        If CapView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
            If CapView.GetRowCellValue(e.RowHandle, "isDelete") Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf CapView.GetRowCellValue(e.RowHandle, "Edited") And CapView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            If CapView.GetRowCellValue(e.RowHandle, "isDelete") Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf CapView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
            If CapView.GetRowCellValue(e.RowHandle, "isDelete") Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf e.RowHandle = CapView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub CapView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CapView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CapView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles CapView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Certificate Functions"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
        e.EditForm.FormBorderStyle = FormBorderStyle.FixedSingle

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

    Private Sub CapView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CapView.ValidateRow, CapView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FKeyRank As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCapacity")
        '20160831 fords - also need to check existing records
        'If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
        If view.GetRowCellValue(e.RowHandle, FKeyRank) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, FKeyRank) Is Nothing Then
            e.Valid = False
            view.SetColumnError(FKeyRank, "Please select Capacity")
            view.FocusedColumn = view.VisibleColumns(0)
        Else
            e.Valid = True
        End If
        'End If
    End Sub
#End Region

    Private Sub repFunc_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFunc.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repFuncLevel_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFuncLevel.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repCapRank_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCapRank.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
