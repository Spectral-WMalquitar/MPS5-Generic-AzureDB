Public Class Bank

#Region "Easy Edit"
    Private FormName As String = "Admin Bank"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
#End Region
    Dim City As DataTable = Nothing
    Dim Province As DataTable = Nothing
    Dim cCity As DataView, cProvince As DataView

    'Reload Province Repository
    Private Sub ReloadProvince()
        'With Me.MainView
        Province = DB.CreateTable("SELECT * FROM tblAdmProvince ORDER BY Name ASC")
        Me.repState.DataSource = Province
        'End With

    End Sub

    'Reload City Repository
    Private Sub ReloadCity()
        'With Me.MainView
        City = DB.CreateTable("SELECT * FROM tblAdmCity ORDER BY Name ASC")
        Me.repCity.DataSource = City
        'End With
    End Sub

    'Reload City Repository
    Private Sub ReloadCntry()
        Me.repCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC, SortCode ASC")
        Me.MainView.SetRowCellValue(Me.MainView.FocusedRowHandle, "FKeyProvince", "")
    End Sub


    'Initialize Controls
    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString
        Me.LayoutControl1.AllowCustomization = False
        ReloadCntry()
        ReloadProvince()
        ReloadCity()
    End Sub

    'Load Sub Table
    Private Sub LoadSub()
        BRECORDUPDATEDs = False
        Me.MainGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmBranch WHERE FKeyBank='" & strID & "' ORDER BY Name ASC")
    End Sub

    'Refresh Data
    Public Overrides Sub RefreshData()

        TableName = "tblAdmBank"
        MyBase.RefreshData()
        SetDeleteCaption(Name, "Delete Bank")
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Bank Details - " & strDesc)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        strRequiredFields = "txtName;txtAbbrv,txtSwiftCode"
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
            Me.txtAbbrv.Text = Trim(IfNull(blList.GetFocusedRowData("Abbrv"), ""))
            Me.txtSwiftCode.Text = Trim(IfNull(blList.GetFocusedRowData("SwiftCode"), ""))
            'Me.txtRemarks.Text = Trim(IfNull(blList.GetFocusedRowData("Remarks"), ""))
            'for SUB DATA
            EditSubAllowGrid(Me.MainView, False)

            MakeReadOnlyListener(Me.LayoutControl1.Root)
            LoadSub()
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)

    End Sub

    'Edit Data
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            'AllowDeletion(Name, True)
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            'MainView Sub
            With Me.MainView
                .OptionsBehavior.ReadOnly = False
                AllowRepositoryBtnEdit(repCity, True)
                AllowRepositoryBtnEdit(repState, True)
            End With
        Else
            'AllowDeletion(Name, False)
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'MainView Sub
            With Me.MainView
                .OptionsBehavior.ReadOnly = True
                AllowRepositoryBtnEdit(repCity, False)
                AllowRepositoryBtnEdit(repState, False)
            End With
        End If
        EditSubAllowGrid(MainView, isEditdable)
        AllowDeletion(Name, isEditdable)
    End Sub

    'Add Data
    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.header.Text = strDesc
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            Me.MainGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmBranch WHERE FKeyBank='" & strID & "' ORDER By Name ASC")
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            BRECORDUPDATEDs = False
        End If
        With Me.MainView
            .CancelUpdateCurrentRow()
            .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            .OptionsBehavior.ReadOnly = False
            AllowRepositoryBtnEdit(repState, True)
        End With


    End Sub

    'Save Data
    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim query As New ArrayList, info As Boolean = False, id As String = ""
        Dim type As String = ""
        'blList.HideSelection()

        If Not Me.MainView.HasColumnErrors() Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, txtSwiftCode}) Then
                'LASTUPDATED BY FORMAT
                'getusername() & <Description><FormName>
                'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Bank", 10, System.Environment.MachineName, txtName.EditValue, FormName)
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, txtSwiftCode}) Then
                        Exit Sub
                    Else
                        info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                        BRECORDUPDATEDs = False
                        id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                        type = "Inserted"
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, txtSwiftCode}, "PKey<>'" & strID & "'") Then
                        Exit Sub
                    Else
                        id = strID
                        info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & id & "'"))
                        BRECORDUPDATEDs = False
                        type = "Updated"
                    End If
                End If

                'Sub Table
                With Me.MainView
                    .CloseEditForm()
                    .UpdateCurrentRow()
                    For i As Integer = 0 To .RowCount - 1
                        If .GetRowCellValue(i, "Edited") Then
                            Dim cDataDescription As String = Util.ConcatWithSpaces(New Object() {.GetRowCellValue(i, "Bldg") & _
                                                                                                     .GetRowCellValue(i, "St") & _
                                                                                                     .GetRowCellValue(i, "PartofCity") & _
                                                                                                     .GetRowCellDisplayText(i, "FKeyCity") & _
                                                                                                     .GetRowCellDisplayText(i, "FKeyProvince") & _
                                                                                                     .GetRowCellDisplayText(i, "FKeyCntry")})
                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Bank Branch", 10, System.Environment.MachineName, cDataDescription, FormName)

                            If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                                'query.Add("INSERT INTO dbo.tblAdmBranch(FKeyBank" & _
                                '          ",SortCode" & _
                                '          ",Bldg" & _
                                '          ",St" & _
                                '          ",PartofCity" & _
                                '          ",FKeyCity" & _
                                '          ",FKeyProvince" & _
                                '          ",BankCharge" & _
                                '          ",FKeyCntry" & _
                                '          ",BranchName" & _
                                '          ",Addr" & _
                                '          ",LastUpdatedBy) " & _
                                '          "VALUES('" & id & "'" & _
                                '          ",'" & .GetRowCellValue(i, "SortCode") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "Bldg") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "St") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "PartofCity") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "FKeyCity") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "FKeyProvince") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "BankCharge") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "FKeyCntry") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "BranchName") & "'" & _
                                '          ",'" & .GetRowCellValue(i, "Addr") & "'" & _
                                '          ",'" & LastUpdatedBy & "')")

                                query.Add("INSERT INTO dbo.tblAdmBranch(FKeyBank" & _
                                          ",SortCode" & _
                                          ",Bldg" & _
                                          ",St" & _
                                          ",PartofCity" & _
                                          ",FKeyCity" & _
                                          ",FKeyProvince" & _
                                          ",BankCharge" & _
                                          ",FKeyCntry" & _
                                          ",Name" & _
                                          ",Addr" & _
                                          ",LastUpdatedBy) " & _
                                          "VALUES('" & id & "'" & _
                                          ",'" & .GetRowCellValue(i, "SortCode") & "'" & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "Bldg")) & " " & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "St")) & " " & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "PartofCity")) & " " & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "FKeyCity")) & " " & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "FKeyProvince")) & " " & _
                                          ",'" & .GetRowCellValue(i, "BankCharge") & "'" & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "FKeyCntry")) & " " & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "Name")) & " " & _
                                          "," & ChangeToSQLString(.GetRowCellValue(i, "Addr")) & " " & _
                                          ",'" & LastUpdatedBy & "')")
                            Else
                                query.Add("UPDATE dbo.tblAdmBranch SET " & _
                                          "SortCode='" & .GetRowCellValue(i, "SortCode") & "' " & _
                                          ",Bldg=" & ChangeToSQLString(.GetRowCellValue(i, "Bldg")) & " " & _
                                          ",St=" & ChangeToSQLString(.GetRowCellValue(i, "St")) & " " & _
                                          ",PartofCity=" & ChangeToSQLString(.GetRowCellValue(i, "PartofCity")) & " " & _
                                          ",FKeyCity=" & ChangeToSQLString(.GetRowCellValue(i, "FKeyCity")) & " " & _
                                          ",FKeyProvince=" & ChangeToSQLString(.GetRowCellValue(i, "FKeyProvince")) & " " & _
                                          ",BankCharge='" & .GetRowCellValue(i, "BankCharge") & "'" & _
                                          ",FKeyCntry=" & ChangeToSQLString(.GetRowCellValue(i, "FKeyCntry")) & " " & _
                                          ",Name=" & ChangeToSQLString(.GetRowCellValue(i, "Name")) & " " & _
                                          ",Addr=" & ChangeToSQLString(.GetRowCellValue(i, "Addr")) & " " & _
                                          ",DateUpdated=(getdate())" & _
                                          ",LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                          "WHERE FKeyBank='" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
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
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, txtSwiftCode}, showMsg) Then
                    If bAddMode Then
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, txtSwiftCode}) Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            SaveData() '
                        End If
                    Else
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, txtSwiftCode}, "PKey<>'" & strID & "'") Then
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

    'Delete Data
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
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Bank", 10, System.Environment.MachineName, txtName.EditValue, FormName)
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

    'Custom Function
    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "DeleteOther"
                DeleteSubItem()
        End Select
    End Sub

    'Delete Sub Item
    Private Sub DeleteSubItem()
        With focusedView
            If MsgBox("Are you sure want to delete the Branch?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then

                    Dim cDataDescription As String = Util.ConcatWithSpaces(New Object() {.GetRowCellValue(.FocusedRowHandle, "Bldg") & _
                                                                                                     .GetRowCellValue(.FocusedRowHandle, "St") & _
                                                                                                     .GetRowCellValue(.FocusedRowHandle, "PartofCity") & _
                                                                                                     .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCity") & _
                                                                                                     .GetRowCellDisplayText(.FocusedRowHandle, "FKeyProvince") & _
                                                                                                     .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCntry")})
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Bank Branch", 10, System.Environment.MachineName, cDataDescription, FormName)
                    clsAudit.saveAuditPreDelDetails("tblAdmBranch", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                        FormName, _
                        "Admin", _
                        "tblAdmBranch", _
                        "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Admin Data - " & FormName & " - Branch >>", _
                         LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Branch>", _
                        GetUserName())
                    '-->
                    If DB.RunSql("DELETE FROM dbo.tblAdmBranch WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()
                    End If
                    'RefreshData()
                End If
                .DeleteRow(.FocusedRowHandle)
                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
            End If
        End With

    End Sub

#Region "Branch"
    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.MainView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        ElseIf e.Column.FieldName = "FKeyCntry" Then
            repState.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmProvince WHERE FKeyCntry='" & Me.MainView.GetRowCellValue(MainView.FocusedRowHandle, "FKeyCntry") & "'")
        End If
    End Sub

    Private Sub MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'With view
        'End With
        'Me.repState.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmProvince ORDER BY Name ASC")
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyBank"), strID)
        View.SetRowCellValue(e.RowHandle, View.Columns("SortCode"), 0)
        View.SetRowCellValue(e.RowHandle, View.Columns("BankCharge"), 0)
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

    Private Sub MainView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MainView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainView_ValidateRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
        'Dim Prov As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyProvince")
        'Dim City As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCity")

        'AllowSaving(Name, False)

        ''Cntry
        'If view.GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
        '    e.Valid = False
        '    view.SetColumnError(Cntry, "Please selecet Country.")
        '    view.FocusedColumn = view.VisibleColumns(0)
        '    AllowSaving(Name, False)
        'ElseIf view.GetRowCellValue(e.RowHandle, Cntry) = "" Then
        '    e.Valid = False
        '    view.SetColumnError(Prov, "Please selecet Province.")
        '    view.FocusedColumn = view.VisibleColumns(0)
        '    AllowSaving(Name, False)
        'Else
        '    e.Valid = True
        '    view.ClearColumnErrors()
        '    AllowSaving(Name, True)
        'End If

        ''Province
        'If view.GetRowCellValue(e.RowHandle, Prov) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, Prov) Is Nothing Then
        '    e.Valid = False
        '    view.SetColumnError(Prov, "Please selecet Province.")
        '    view.FocusedColumn = view.VisibleColumns(0)
        '    AllowSaving(Name, False)
        'ElseIf view.GetRowCellValue(e.RowHandle, Prov) = "" Then
        '    e.Valid = False
        '    view.SetColumnError(Prov, "Please selecet Province.")
        '    view.FocusedColumn = view.VisibleColumns(0)
        '    AllowSaving(Name, False)
        'Else
        '    'e.Valid = True
        '    'view.ClearColumnErrors()
        '    'AllowSaving(Name, True)
        '    'City
        '    If view.GetRowCellValue(e.RowHandle, City) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, City) Is Nothing Then
        '        e.Valid = False
        '        view.SetColumnError(City, "Please selecet City.")
        '        view.FocusedColumn = view.VisibleColumns(0)
        '        AllowSaving(Name, False)
        '    ElseIf view.GetRowCellValue(e.RowHandle, City) = "" Then
        '        e.Valid = False
        '        view.SetColumnError(City, "Please selecet City.")
        '        view.FocusedColumn = view.VisibleColumns(0)
        '        AllowSaving(Name, False)
        '    Else
        '        e.Valid = True
        '        view.ClearColumnErrors()
        '        AllowSaving(Name, True)
        '    End If
        'End If

        ''City
        'If view.GetRowCellValue(e.RowHandle, City) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, City) Is Nothing Then
        '    e.Valid = False
        '    view.SetColumnError(City, "Please select Province.")
        '    view.FocusedColumn = view.VisibleColumns(0)
        '    AllowSaving(Name, False)
        'ElseIf view.GetRowCellValue(e.RowHandle, City) = "" Then
        '    e.Valid = False
        '    view.SetColumnError(City, "Please select Province.")
        '    view.FocusedColumn = view.VisibleColumns(0)
        '    AllowSaving(Name, False)
        'Else
        '    e.Valid = True
        '    view.ClearColumnErrors()
        '    AllowSaving(Name, True)
        'End If

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim BranchName As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Name")
        Dim Addr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Addr")

        AllowSaving(Name, False)

        'BranchName
        If view.GetRowCellValue(e.RowHandle, BranchName) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, BranchName) Is Nothing Then
            e.Valid = False
            view.SetColumnError(BranchName, "Please enter the Branch Name.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        ElseIf view.GetRowCellValue(e.RowHandle, BranchName) = "" Then
            e.Valid = False
            view.SetColumnError(BranchName, "{Please enter the Branch Name.")
            view.FocusedColumn = view.VisibleColumns(0)
            AllowSaving(Name, False)
        Else
            e.Valid = True
            view.ClearColumnErrors()
            AllowSaving(Name, True)
        End If
    End Sub

    'Add New City Button
    Private Sub repCity_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCity.ButtonClick
        ClearLookUpEdit(sender, e)
        If e.Button.Index = 1 Then
            Dim province As String = ""
            Dim kProvince As String = ""
            With Me.MainView
                province = Trim(IfNull(.GetRowCellDisplayText(.FocusedRowHandle, "FKeyProvince"), ""))
                kProvince = Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyProvince"), ""))
            End With
            If kProvince <> "" And province <> "" Then
                Dim strCity As String = MPSInputDialog("Add City?", "Add")
                If strCity <> "" Then
                    MainView.SetFocusedRowCellValue("FKeyCity", strCity)
                End If
                If strCity <> "" Then
                    If MsgBox("Are you sure you want to Add City in " & province & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        DB.RunSql("INSERT INTO dbo.tblAdmCity(FKeyProvince,Name,LastUpdatedBy) VALUES('" & kProvince & "','" & strCity & "','" & LastUpdatedBy & "')")
                    End If
                End If
            End If
            ReloadCity()
        End If
    End Sub

    'Add New Province | State Button
    Private Sub repState_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repState.ButtonClick
        ClearLookUpEdit(sender, e)
        If e.Button.Index = 1 Then
            Dim cntry As String = ""
            Dim Kcntry As String = ""
            Dim info As Boolean = False
            With Me.MainView
                cntry = Trim(IfNull(.GetRowCellDisplayText(.FocusedRowHandle, "FKeyCntry"), ""))
                Kcntry = Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCntry"), ""))
            End With
            If Kcntry <> "" And cntry <> "" Then
                Dim strstate As String = MPSInputDialog("ADD State | Province ?", "Add")
                If strstate <> "" Then
                    MainView.SetFocusedRowCellValue("FKeyProvince", strstate)
                End If
                If strstate <> "" Then
                    If MsgBox("Are you sure you want to Add Province in " & cntry & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        info = DB.RunSql("INSERT INTO dbo.tblAdmProvince(FKeyCntry,Name,LastUpdatedBy) VALUES('" & Kcntry & "','" & strstate & "','" & LastUpdatedBy & "')")
                    End If
                End If
                ReloadProvince()
            End If
        End If
    End Sub

    Private Sub MainView_ShownEditor(sender As System.Object, e As System.EventArgs) Handles MainView.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        RepoProvince(view)
        RepoCity(view)
    End Sub

    Private Sub MainView_HiddenEditor(sender As Object, e As System.EventArgs) Handles MainView.HiddenEditor
        'For Province
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "FKeyProvince" Then
            If Not cProvince Is Nothing Then
                cProvince.Dispose()
                cProvince = Nothing
            End If
        End If

        'for City
        If view.FocusedColumn.FieldName = "FKeyCity" Then
            If Not cCity Is Nothing Then
                cCity.Dispose()
                cCity = Nothing
            End If
        End If
    End Sub

    Private Sub RepoProvince(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)
        'view.SetFocusedRowCellValue("FKeyCntry", "") 'Clear City
        If view.FocusedColumn.FieldName = "FKeyProvince" And (TypeOf (view.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
            Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            cProvince = New DataView(Province)
            cProvince.RowFilter = "FKeyCntry ='" & view.GetRowCellValue(view.FocusedRowHandle, "FKeyCntry") & "'"
            edit.Properties.DataSource = cProvince
            If cProvince.Count < 0 Then
                view.SetFocusedRowCellValue("FKeyCity", "")
            End If
        End If
    End Sub

    Private Sub RepoCity(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "FKeyCity" And (TypeOf (view.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
            Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            cCity = New DataView(City)
            cCity.RowFilter = "FKeyProvince ='" & view.GetRowCellValue(view.FocusedRowHandle, "FKeyProvince") & "'"
            edit.Properties.DataSource = cCity
            If cCity.Count < 0 Then
                edit.Properties.DataSource = Nothing
            End If
        End If
    End Sub

#End Region


    'For Column Validation
    Public Sub ValidateRequiredFields(ByRef sender As Object, ByRef e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs, colName As String, errMessage As String, Optional ByRef hasTrue As Boolean = False)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim column As DevExpress.XtraGrid.Columns.GridColumn = view.Columns(colName)
        If view.GetRowCellValue(e.RowHandle, column) Is System.DBNull.Value Or view.GetRowCellValue(e.RowHandle, column) Is Nothing Then
            e.Valid = False
            view.SetColumnError(column, errMessage)
            view.FocusedColumn = view.VisibleColumns(0)
            hasTrue = False
        Else
            e.Valid = True
            hasTrue = True
        End If
    End Sub

    Private Sub repCntry_EditValueChanged(sender As Object, e As System.EventArgs) Handles repCntry.EditValueChanged
        Dim txt As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        'MsgBox(txt.EditValue)
        RepoProvince(Me.MainView)
        RepoCity(Me.MainView)

        MainView.SetFocusedRowCellValue("FKeyProvince", "")
        MainView.SetFocusedRowCellValue("FKeyCity", "")
    End Sub

    Private Sub MainView_GotFocus(sender As Object, e As System.EventArgs) Handles MainView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Branch")
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Bank")
        End If
    End Sub

    Private Sub repCntry_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
