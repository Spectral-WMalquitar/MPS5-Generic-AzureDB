Public Class Country
    Private clsSec As New clsSecurity
#Region "Easy Edit"
    Private FormName As String = "Admin Country"
    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Dim ProvinceID As String 'The province ID
    Dim PrevProvID As String
    Dim ProvChange As Boolean = False 'identifier for changes in Province Table
    Dim CityRecordUpdated As Boolean = False 'Flag for city Table

    'if you have LookUpEdit
    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        clsSec.propSQLConnStr = DB.GetConnectionString 'tony20170906
        Me.LayoutControl1.AllowCustomization = False
    End Sub

    Private Sub LoadSub()
        'Throw New NotImplementedException
        Me.ProvGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmProvince WHERE FKeyCntry='" & strID & "' ORDER BY Name ASC,SortCode ASC")
        Me.CityGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmCity WHERE FKeyProvince ='" & GetProvinceID() & "' ORDER BY Name ASC,SortCode ASC")
        RefreshCity()
    End Sub

    'Refresh Data
    Public Overrides Sub RefreshData()
        'Dim perm As Boolean = False
        TableName = "tblAdmCntry"
        DataToolDuplicate = False
        MyBase.RefreshData()
        SetDeleteCaption(Name, "Delete Country")
        strRequiredFields = "txtName;txtNat"
        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If
        If blList.GetID() = "" Then
            AddData()
        Else
            'put values in the controls
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            Me.txtNat.Text = Trim(IfNull(blList.GetFocusedRowData("Nat"), ""))
            Me.txtCountryCode.Text = Trim(IfNull(blList.GetFocusedRowData("CountryCode"), ""))
            Me.txtCallingCode.Text = Trim(IfNull(blList.GetFocusedRowData("CallingCode"), ""))
            LoadSub()

            'Province Table
            With Me.ProvView
                .OptionsBehavior.ReadOnly = True
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            End With
            With Me.CityView
                .OptionsBehavior.ReadOnly = True
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            End With

            MakeReadOnlyListener(Me.LayoutControl1.Root)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
        ProvChange = False
        CityRecordUpdated = False

        If Microsoft.VisualBasic.Left(Trim(IfNull(blList.GetFocusedRowData("PKey"), "")), 3) = "SYS" Then
            AllowDeletion(Name, False)
            RemoveEditListener(Me.txtName)
            RemoveEditListener(Me.txtNat)
        Else
            If clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, True, userPermDt).Equals(0) Then
                AllowDeletion(Name, True)
            Else
                AllowDeletion(Name, False)
            End If
        End If
    End Sub

    'Edit Datas
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            'Province Table
            Me.ProvView.OptionsBehavior.ReadOnly = False
            Me.ProvView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.ProvView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.ProvView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.ProvView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            'Me.ProvView.

            ''City Table
            Me.CityView.OptionsBehavior.ReadOnly = False
            Me.CityView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.CityView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.CityView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            Me.CityView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'Province Table
            Me.ProvView.OptionsBehavior.ReadOnly = True
            Me.ProvView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.ProvView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.ProvView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.ProvView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            ''City Table
            Me.CityView.OptionsBehavior.ReadOnly = True
            Me.CityView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.CityView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.CityView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.CityView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        End If
        AllowDeletion(Name, False)

    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        MyBase.AddData()
        AddEditListener(Me.LayoutControl1.Root)
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
            'get the max SortCode
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            BRECORDUPDATEDs = False
        End If

        LoadSub()
        With Me.ProvView
            .OptionsBehavior.ReadOnly = False
            .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        End With

        'City Table
        With Me.CityView
            .OptionsBehavior.ReadOnly = False
            .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        End With
        'RefreshCity()
    End Sub

    'Save Data
    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim type As String = "", info As Boolean = False
        Dim id As String = "", ProvinceID As String = ""
        Dim PwillDelete As Boolean = False 'Province
        Dim CwillDelete As Boolean = False ' Capacity Table
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtNat}) Then
            If countDelete(New DevExpress.XtraGrid.Views.Grid.GridView() {Me.ProvView, Me.CityView}) > 0 Then
                If MsgBox("There are items marked for Deletion. Are you sure you want to proceed?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                    If countDelete(New DevExpress.XtraGrid.Views.Grid.GridView() {Me.CityView}) > 0 Then
                        CwillDelete = True
                    Else
                        CwillDelete = False
                    End If
                    If countDelete(New DevExpress.XtraGrid.Views.Grid.GridView() {Me.ProvView}) > 0 Then
                        PwillDelete = True
                    Else
                        PwillDelete = False
                    End If
                Else
                    CwillDelete = False
                    PwillDelete = False
                End If
            End If

            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Country", 10, System.Environment.MachineName, txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtNat}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    BRECORDUPDATEDs = False
                    id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                    type = "Inserted"
                End If

            Else
                id = strID
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtNat}, "PKey<>'" & id & "'") Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, Me.TableName, "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & id & "'"))
                    BRECORDUPDATEDs = False
                    type = "Updated"
                End If
            End If
            'Save Province
            ProvinceID = GetProvinceID()
            info = SaveProvince(id, PwillDelete)
            'MsgBox(PrevProvID)
            info = SaveCity(IIf(ProvChange, PrevProvID, ProvinceID))
            ProvChange = False
            CityRecordUpdated = False
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
            If ProvView.HasColumnErrors() Or CityView.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtNat}, showMsg) Then
                    If bAddMode Then
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtNat}) Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            SaveData()
                        End If
                    Else
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtNat}, "PKey<>'" & strID & "'") Then
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

    'Delete Data
    Public Overrides Sub DeleteData()
        Dim info As Boolean = False

        If IsNothing(focusedView) Then
            SetDeleteCaption(Name, "Delete Country")
            'DeleteData()
            MyBase.DeleteData()
            If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                If DB.isDeleteAllowed(Me.TableName, strID) Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Country", 10, System.Environment.MachineName, txtName.EditValue, FormName)
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
                        LastUpdatedBy)
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
        Else
            DeleteSubTables()
        End If

    End Sub

    'Delete sub tables
    Private Sub DeleteSubTables()
        Dim info As Boolean = False

        With focusedView
            Select Case focusedView.Name
                Case ProvView.Name
                    If MsgBox("Are you sure want to delete " & .GetRowCellValue(.FocusedRowHandle, "Name") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                            If DB.isDeleteAllowed("tblAdmProvince", .GetRowCellValue(.FocusedRowHandle, "PKey")) Then
                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Country - Province/State", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellValue(.FocusedRowHandle, "Name"), FormName) 'tony20160719

                                clsAudit.saveAuditPreDelDetails("tblAdmProvince", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                                Dim query As New ArrayList
                                '<!--added by tony20180922 : Log Deletion
                                oLogDeletion.listLogEntry.Add(New LogDeletion.RecordStructure( _
                                    LogDeletion.CallingApp.Admin,
                                    FormName, _
                                    "Admin", _
                                    "tbladmcity", _
                                    "FKeyProvince IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                                    "<< Delete Admin Data - " & FormName & " - City >>", _
                                    LogDeletion.DeletionType.Manual, _
                                    "Manually Deleted in <" & FormName & "- City>", _
                                    GetUserName()))
                                '-->
                                query.Add("DELETE FROM dbo.tbladmcity WHERE FKeyProvince = '" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")

                                '<!--added by tony20180922 : Log Deletion
                                oLogDeletion.listLogEntry.Add(New LogDeletion.RecordStructure( _
                                    LogDeletion.CallingApp.Admin,
                                    FormName, _
                                    "Admin", _
                                    "tblAdmProvince", _
                                    "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                                    "<< Delete Admin Data - " & FormName & " - Province >>", _
                                    LogDeletion.DeletionType.Manual, _
                                    "Manually Deleted in <" & FormName & "- Province>", _
                                    GetUserName()))
                                '-->
                                query.Add("DELETE FROM dbo.tblAdmProvince WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")

                                'info = DB.RunSql("DELETE FROM dbo.tblAdmProvince WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                                info = DB.RunSqls(query)
                                If info Then
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                                    .DeleteRow(.FocusedRowHandle)
                                    RefreshCity()
                                    '<!-- edited by tony20170906
                                    If Not focusedView Is Nothing Then
                                        BRECORDUPDATEDs = CheckForUpdated(focusedView)
                                    Else
                                        BRECORDUPDATEDs = True
                                    End If
                                    '-->
                                End If
                            Else
                                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                            End If
                        Else
                            .DeleteRow(.FocusedRowHandle)
                        End If
                        '<!-- edited by tony20170906
                        If Not focusedView Is Nothing Then
                            BRECORDUPDATEDs = CheckForUpdated(focusedView)
                        Else
                            BRECORDUPDATEDs = True
                        End If
                        '-->
                    End If

                Case CityView.Name
                    If MsgBox("Are you sure want to delete " & .GetRowCellValue(.FocusedRowHandle, "Name") & " ?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        If IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "") <> "" Then
                            If DB.isDeleteAllowed("tbladmCity", .GetRowCellValue(.FocusedRowHandle, "PKey")) Then
                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Country - City", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellValue(.FocusedRowHandle, "Name"), FormName) 'tony20160719

                                clsAudit.saveAuditPreDelDetails("tblAdmCity", .GetRowCellValue(.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                                '<!--added by tony20180922 : Log Deletion
                                oLogDeletion.Init()
                                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                                    FormName, _
                                    "Admin", _
                                    "tblAdmCity", _
                                    "PKey IN ('" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "')", _
                                    "<< Delete Admin Data - " & FormName & " - City >>", _
                                    LogDeletion.DeletionType.Manual, _
                                    "Manually Deleted in <" & FormName & " - City>", _
                                    GetUserName())
                                '-->
                                info = DB.RunSql("DELETE FROM dbo.tblAdmCity WHERE PKey='" & .GetRowCellValue(.FocusedRowHandle, "PKey") & "'")
                                If info Then
                                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    MsgBox(GetMessage("Deleted", info), MsgBoxStyle.Information, GetAppName)
                                    .DeleteRow(.FocusedRowHandle)
                                End If
                            Else
                                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                            End If
                        Else
                            .DeleteRow(.FocusedRowHandle)
                        End If
                        'BRECORDUPDATEDs = CheckForUpdated(focusedView)
                        'CityRecordUpdated = CheckForUpdated(focusedView)

                        '<!-- edited by tony20170906
                        If Not focusedView Is Nothing Then
                            BRECORDUPDATEDs = CheckForUpdated(focusedView)
                        Else
                            BRECORDUPDATEDs = True
                        End If

                        'BRECORDUPDATEDs = CheckForUpdated(CityView)
                        'CityRecordUpdated = CheckForUpdated(CityView)
                        CityRecordUpdated = BRECORDUPDATEDs
                        '-->

                    End If
            End Select
        End With
    End Sub

    Private Function CheckForUpdated(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim info As Boolean = False
        For i As Integer = 0 To view.DataRowCount
            If view.GetRowCellValue(i, "Edited") = True Then
                info = True
                Exit For
            Else
                info = False
            End If
        Next
        Return info
    End Function

    Private Function countDelete(ByVal _view As DevExpress.XtraGrid.Views.Grid.GridView()) As Integer
        Dim count As Integer = 0, delcount As Integer = 0
        For x = 0 To _view.Length - 1
            For count = 0 To _view(x).RowCount - 1
                If Not _view(x).GetRowCellValue(count, "isDelete") Is System.DBNull.Value Then
                    If _view(x).GetRowCellValue(count, "isDelete") Then
                        delcount = delcount + 1
                        Exit For
                    End If
                End If
            Next
            If delcount > 0 Then
                Exit For
            End If
        Next
        Return delcount
    End Function

#Region "Province Table"
    'Save Province Table
    Private Function SaveProvince(ByVal id As String, Optional ByVal willDelete As Boolean = False) As Boolean
        Dim query As New ArrayList, bool As Boolean = True
        With Me.ProvView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Country - Province/State", 10, System.Environment.MachineName, txtName.EditValue & " : " & ProvView.GetRowCellValue(i, "Name"), FormName) 'tony20160719

                    If IfNull(.GetRowCellValue(i, "isDelete"), False) Then
                        If willDelete Then
                            If DB.isDeleteAllowed("tblAdmProvince", ProvView.GetRowCellValue(i, "PKey")) Then
                                query.Add("DELETE FROM dbo.tblAdmProvince WHERE PKey='" & ProvView.GetRowCellValue(i, "PKey") & "'")
                            Else
                                MsgBox(ProvView.GetRowCellValue(i, "Name") & " - " & GetMessage("Deleted", False), MsgBoxStyle.Information, GetAppName)
                            End If
                        End If
                    ElseIf IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        'Use insert query
                        query.Add("INSERT INTO dbo.tblAdmProvince " & _
                                  "(" & _
                                  "FKeyCntry" & _
                                  ",Name" & _
                                  ",SortCode" & _
                                  ",LastUpdatedBy)" & _
                                  "VALUES(" & _
                                  "'" & id & "'" & _
                                 ",'" & .GetRowCellValue(i, "Name") & "'" & _
                                 ",'" & .GetRowCellValue(i, "SortCode") & "'" & _
                                 ",'" & LastUpdatedBy & "')")
                    Else
                        'Use Update query
                        query.Add("UPDATE dbo.tblAdmProvince SET " & _
                                  "Name = '" & .GetRowCellValue(i, "Name") & "' " & _
                                  ",SortCode = '" & .GetRowCellValue(i, "SortCode") & "' " & _
                                  ",DateUpdated= (getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                  "WHERE PKey='" & .GetRowCellValue(i, "PKey") & "' AND FKeyCntry='" & id & "'")
                    End If
                End If
            Next
        End With
        bool = DB.RunSqls(query)
        Return bool

    End Function

    Private Sub ProvView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ProvView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.ProvView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub ProvView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ProvView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub ProvView_Click(sender As Object, e As System.EventArgs) Handles ProvView.Click
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.RefreshRow(view.FocusedRowHandle)
        'neil RefreshCity()
    End Sub

    Private Sub ProvView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ProvView.FocusedRowChanged
        If CityRecordUpdated Then
            'If BRECORDUPDATEDs Then
            If MsgBox("Would you like to save the changes you made on City?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                ProvChange = True
                SaveCity(IIf(ProvChange, PrevProvID, ProvinceID))
                'neil RefreshCity()
            Else
                RefreshCity() 'neil move here
            End If
        Else
            RefreshCity()
        End If
    End Sub

    Private Sub ProvView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ProvView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyCntry"), strID)
        'View.SetRowCellValue(e.RowHandle, View.Columns("FKeyDocGroup"), "SYSTRAVELDOC")
        SubAddMode = True
    End Sub

    Private Sub ProvView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles ProvView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub ProvView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ProvView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            ProvView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub ProvView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ProvView.RowCellStyle
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If views.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") And views.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = views.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub ProvView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles ProvView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub ProvView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles ProvView.ShowingPopupEditForm
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

    Private Sub ProvView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles ProvView.ValidateRow, ProvView.ValidateRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim CityName As DevExpress.XtraGrid.Columns.GridColumn = views.Columns("Name")

        'check for duplicate in the database
        With views
            AllowSaving(Name, False)
            If .GetRowCellValue(e.RowHandle, CityName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, CityName) Is Nothing Then
                .SetColumnError(CityName, "Please enter Province.")
                e.Valid = False
                AllowSaving(Name, False)
            ElseIf DB.HasDuplicate("tblAdmProvince", "[" & CityName.FieldName & "]='" & .GetRowCellValue(e.RowHandle, CityName.FieldName) & "' AND  [FKeyProvince]='" & strID & "'") Then
                .SetColumnError(CityName, "Already in use")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(CityName, "")
                e.Valid = True
            End If

            'Clear Errors
            If Not .HasColumnErrors Then
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub ProvView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles ProvView.ValidatingEditor
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'check for duplicate within the gridview
        With views
            Dim strRequiredFields As String = "Name;"
            If InStr(1, strRequiredFields, .FocusedColumn.FieldName) > 0 Then
                For i = 0 To .DataRowCount - 1
                    If i <> .FocusedRowHandle Then
                        If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                            e.Valid = False
                            e.ErrorText = "Already in use"
                        End If
                    End If
                Next
            End If
        End With
    End Sub

    Private Function GetProvinceID() As String
        'HAHAHAHA! Sorry.. antok ako!
        Try
            If ProvView.RowCount > 0 Then
                Return ProvView.GetRowCellValue(ProvView.FocusedRowHandle, "PKey")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub ProvView_GotFocus(sender As Object, e As System.EventArgs) Handles ProvView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Province")
            AllowDeletion(Name, True)
        End If
    End Sub

    Private Sub ProvView_LostFocus(sender As Object, e As System.EventArgs) Handles ProvView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Country")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub ProvView_BeforeLeaveRow(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles ProvView.BeforeLeaveRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If CityRecordUpdated Then
            PrevProvID = view.GetRowCellValue(e.RowHandle, "PKey")
        End If
    End Sub

#End Region

#Region "City Table"
    'Save Province Table
    Private Function SaveCity(ByVal id As String, Optional ByVal willDelete As Boolean = False) As Boolean
        Dim query As New ArrayList, bool As Boolean = True
        With Me.CityView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Country - City", 10, System.Environment.MachineName, txtName.EditValue & " : " & CityView.GetRowCellValue(i, "Name"), FormName) 'tony20160719
                    If IfNull(.GetRowCellValue(i, "isDelete"), False) Then
                        If willDelete Then
                            If DB.isDeleteAllowed("tblAdmCity", CityView.GetRowCellValue(i, "PKey")) Then
                                query.Add("DELETE FROM dbo.tblAdmCity WHERE PKey='" & CityView.GetRowCellValue(i, "PKey") & "'")
                            Else
                                MsgBox(CityView.GetRowCellValue(i, "Name") & " - " & GetMessage("Deleted", False), MsgBoxStyle.Information, GetAppName)
                            End If
                        End If
                    ElseIf IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        'Use insert query
                        query.Add("INSERT INTO dbo.tblAdmCity " & _
                                  "(" & _
                                  "FKeyProvince" & _
                                  ",Name" & _
                                  ",SortCode" & _
                                  ",LastUpdatedBy)" & _
                                  "VALUES(" & _
                                  "'" & id & "'" & _
                                 ",'" & .GetRowCellValue(i, "Name") & "'" & _
                                 ",'" & .GetRowCellValue(i, "SortCode") & "'" & _
                                 ",'" & LastUpdatedBy & "')")
                    Else
                        'Use Update query
                        query.Add("UPDATE dbo.tblAdmCity SET " & _
                                  "Name = '" & .GetRowCellValue(i, "Name") & "' " & _
                                  ",SortCode = '" & .GetRowCellValue(i, "SortCode") & "' " & _
                                  ",DateUpdated= (getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                  "WHERE PKey='" & .GetRowCellValue(i, "PKey") & "' AND FKeyProvince='" & id & "'")
                    End If
                End If
            Next
        End With
        CityRecordUpdated = False
        bool = DB.RunSqls(query)
        ProvChange = False
        RefreshCity()
        BRECORDUPDATEDs = CheckForUpdated(Me.CityView)
        Return bool
    End Function

    'This will Enable or Disable the SubTable based on the Selected Item in The Main Table
    Private Sub RefreshCity()
        Me.CityGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited,CAST(0 AS BIT) AS isDelete FROM dbo.tblAdmCity WHERE FKeyProvince ='" & GetProvinceID() & "' ORDER BY Name ASC, SortCode ASC")
        If GetProvinceID() = "" Then 'Check if the Province is a new record
            Me.CityGrid.Enabled = False
        Else
            Me.CityGrid.Enabled = True
        End If
        CityRecordUpdated = False
    End Sub

    Private Sub CityView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CityView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.CityView
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'BRECORDUPDATEDs = True
            End With
        End If
    End Sub

    Private Sub CityView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CityView.CellValueChanging
        BRECORDUPDATEDs = True
        CityRecordUpdated = True
    End Sub

    Private Sub CityView_GotFocus(sender As Object, e As System.EventArgs) Handles CityView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete City")
            AllowDeletion(Name, True)
            'Else
            '    focusedView = Nothing
            '    SetDeleteCaption(Name, "Delete Country")
        End If
    End Sub

    Private Sub CityView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CityView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyProvince"), GetProvinceID)
        SubAddMode = True
    End Sub

    Private Sub CityView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CityView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CityView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CityView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            CityView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub CityView_LostFocus(sender As Object, e As System.EventArgs) Handles CityView.LostFocus
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Country")
            AllowDeletion(Name, False)
        End If
    End Sub

    Private Sub CityView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CityView.RowCellStyle
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If views.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
            If IfNull(views.GetRowCellValue(e.RowHandle, "isDelete"), False) Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") And views.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            If IfNull(views.GetRowCellValue(e.RowHandle, "isDelete"), False) Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf views.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
            If IfNull(views.GetRowCellValue(e.RowHandle, "isDelete"), False) Then
                e.Appearance.BackColor = Color.LightCoral
            End If
        ElseIf e.RowHandle = views.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub CityView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CityView.RowUpdated
        BRECORDUPDATEDs = True
        CityRecordUpdated = True
    End Sub

    Private Sub CityView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles CityView.ShowingPopupEditForm
        'e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        'e.EditForm.Text = "Add Travel Document Country"
        'e.EditForm.Height = e.EditForm.Height + 17
        'e.EditForm.ControlBox = False
        'For Each cntrl As Windows.Forms.Control In e.EditForm.Controls
        '    If Not TypeOf cntrl Is DevExpress.XtraGrid.EditForm.Helpers.Controls.EditFormContainer Then
        '        Continue For
        '    End If
        '    For Each nctrl As Windows.Forms.Control In cntrl.Controls
        '        If Not (TypeOf nctrl Is DevExpress.XtraEditors.PanelControl) Then
        '            Continue For
        '        Else
        '            nctrl.Height = 70
        '        End If
        '        For Each btn As Windows.Forms.Control In nctrl.Controls
        '            If TypeOf btn Is DevExpress.XtraEditors.SimpleButton Then
        '                Dim sbtn = TryCast(btn, DevExpress.XtraEditors.SimpleButton)
        '                'Update Button
        '                If sbtn.Text = "Update" Or sbtn.Text = "Add" Or sbtn.Text = "Edit" Then
        '                    If SubAddMode Then
        '                        sbtn.Text = "Add"
        '                        sbtn.Image = ImageCollection.Images.Item(0)
        '                        sbtn.ImageIndex = 2
        '                    Else
        '                        sbtn.Text = "Edit"
        '                        sbtn.Image = ImageCollection.Images.Item(2)
        '                        sbtn.ImageIndex = 0
        '                    End If
        '                    SubAddMode = False
        '                    sbtn.Size = New System.Drawing.Point(90, 38)
        '                    sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) - sbtn.Size.Width - 3, 18)
        '                End If
        '                'Cancel Button
        '                If sbtn.Text = "Cancel" Then
        '                    sbtn.Image = ImageCollection.Images.Item(1)
        '                    sbtn.ImageIndex = 0
        '                    sbtn.Size = New System.Drawing.Point(90, 38)
        '                    sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) + 3, 18)
        '                End If
        '            End If
        '        Next
        '    Next
        'Next
    End Sub

    Private Sub CityView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CityView.ValidateRow
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim CityName As DevExpress.XtraGrid.Columns.GridColumn = views.Columns("Name")
        Dim Prov As DevExpress.XtraGrid.Columns.GridColumn = views.Columns("FKeyProvince")
        'check for duplicate in the database
        With views
            AllowSaving(Name, False)
            If .GetRowCellValue(e.RowHandle, CityName) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, CityName) Is Nothing Then
                .SetColumnError(CityName, "Please enter City.")
                e.Valid = False
                AllowSaving(Name, False)
            ElseIf DB.HasDuplicate("tblAdmCity", "[" & CityName.FieldName & "]='" & .GetRowCellValue(e.RowHandle, CityName.FieldName) & "' AND  [FKeyProvince]='" & strID & "'") Then
                .SetColumnError(CityName, "Already in use")
                e.Valid = False
                AllowSaving(Name, False)
            Else
                .SetColumnError(CityName, "")
                e.Valid = True
            End If

            'Clear Errors
            If Not .HasColumnErrors Then
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With
    End Sub

    Private Sub CityView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles CityView.ValidatingEditor
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'check for duplicate within the gridview
        With views
            Dim strRequiredFields As String = "Name;"
            If InStr(1, strRequiredFields, .FocusedColumn.FieldName) > 0 Then
                For i = 0 To .DataRowCount - 1
                    If i <> .FocusedRowHandle Then
                        If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                            e.Valid = False
                            e.ErrorText = "Already in use"
                        End If
                    End If
                Next
            End If

        End With
    End Sub

#End Region





End Class

