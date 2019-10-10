Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class Vessel
    Dim is_clicked As Boolean = False, photo_changed As Boolean = False, photo_path As String
    Dim FormName As String = "Admin Vessel"
    'Dim LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
    Dim tabChanged As Boolean = False, PrevTab As Integer = 0
    Dim bInsertVslHst As Boolean
    Dim bRemark As Boolean

    Dim wordToPdf As DevExpress.XtraRichEdit.RichEditControlCompatibility
    'initialize
    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False
        Me.TabControl.SelectedTabPageIndex = 0
        Dim tblPort As DataTable = DB.CreateTable("SELECT PKey, Name,SortCode FROM dbo.tblAdmPort ORDER BY Name, SortCode ASC")

        cboFKeyVslType.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmVslType ORDER BY Name ASC")

        'Vessel Specifications
        cboFlag.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.CntryList ORDER BY Name ASC")


        cboPortofReg.Properties.DataSource = tblPort

        'Company Sepecific
        'edited by: tony20160229; Apply user-data filtering
        cboFKeyPrincipal.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.PrincipalList ORDER BY Name ASC")
        'cboFKeyPrincipal.Properties.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Principal)
        cboFKeyOwner.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.OwnerList ORDER BY Name ASC")
        cboFKeyMgrFlt.Properties.DataSource = DB.CreateTable("SELECT PKey,dbo.AssembleName(b.LName,b.FName,b.MName,1,1,0,0,0) as LFMName FROM dbo.tblAdmMgFlt b ORDER BY LName ASC,FName ASC")
        cboFKeyCrewCmpl.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tbladmCrewCmpl ORDER BY Name ASC")
        cboFKeyMinCrew.Properties.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmMinCrew ORDER BY Name ASC")
        cboFKeyComp.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmComp ORDER BY Name ASC")
        cboVslStat.Properties.DataSource = GetVslStat()
        cboFKeyFlt.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.FltList ORDER BY Name ASC")
        'cboFKeyFlt.Properties.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Fleet)
        cboFKeyWageScale.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmWScale where Active <> 0 ORDER BY Name ASC")

        'Union Agreements
        repCBA.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCBAType ORDER BY Name ASC")
        repCBAAbbrv.DataSource = DB.CreateTable("SELECT PKey, Abbrv FROM dbo.tblAdmCBAType ORDER BY Name ASC")
        repCBAUnion.DataSource = DB.CreateTable("SELECT PKey, UnionName FROM dbo.tblAdmCBAType ORDER BY Name ASC")
        repCBACompany.DataSource = DB.CreateTable("SELECT PKey, Company FROM dbo.tblAdmCBAType ORDER BY Name ASC")

        'Vsl History
        repPort.DataSource = tblPort

        MPS4Functions.AttachDocument.InitBrowseButton(repBtnEditBrowse)
    End Sub

    'load sub
    Private Sub LoadSub()
        'Header
        Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
        Me.txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
        Me.txtAbbrv.Text = Trim(IfNull(blList.GetFocusedRowData("Abbrv"), ""))
        Me.cboFKeyVslType.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyVslType"), ""))
        Dim tblAdmVsl As DataTable
        tblAdmVsl = DB.CreateTable("SELECT * FROM  dbo.tblAdmVslGrp RIGHT OUTER JOIN " &
                                   " dbo.tblAdmVslType ON dbo.tblAdmVslGrp.PKey = dbo.tblAdmVslType.FKeyVslGrp RIGHT OUTER JOIN " &
                                    " dbo.tblAdmVsl ON dbo.tblAdmVslType.PKey = dbo.tblAdmVsl.FKeyVslType WHERE dbo.tblAdmVsl.PKEY='" & strID & "'")
        For Each ItemRow In tblAdmVsl.Rows
            'Vessel Specifications
            Me.txtOffNbr.Text = Trim(IfNull(ItemRow("OffNbr"), ""))
            Me.txtIMONo.Text = Trim(IfNull(ItemRow("IMONo"), ""))
            Me.cboPortofReg.EditValue = Trim(IfNull(ItemRow("PortofReg"), ""))
            Me.cboFlag.EditValue = Trim(IfNull(ItemRow("Flag"), ""))
            Me.txtClassf.Text = Trim(IfNull(ItemRow("Classf"), ""))
            'Me.txtYrBuilt.Text = IIf(Not ItemRow("YrBuilt").Equals(System.DBNull.Value), CDate(Trim(IfNull(ItemRow("YrBuilt"), "01/01/1900"))).Year, "01/01/1900")
            Me.txtYrBuilt.Text = CDate(Trim(IfNull(ItemRow("YrBuilt"), "01/01/1900"))).Year
            Me.txtGrossTon.Text = Trim(IfNull(ItemRow("GrossTon"), ""))
            Me.txtDeadWt.Text = Trim(IfNull(ItemRow("DeadWt"), ""))
            Me.txtNetTon.Text = Trim(IfNull(ItemRow("NetTon"), ""))
            Me.txtEngType.Text = Trim(IfNull(ItemRow("EngType"), ""))
            Me.txtEngPower.Text = Trim(IfNull(ItemRow("EngPower"), ""))
            Me.chkUMS.Checked = Trim(IfNull(ItemRow("UMS"), 0))
            Me.txtCallSign.Text = Trim(IfNull(ItemRow("CallSign"), ""))
            Me.txtPhone.Text = Trim(IfNull(ItemRow("Phone"), ""))
            Me.txtEmail.Text = Trim(IfNull(ItemRow("Email"), ""))

            'Company Specific Items
            cboFKeyPrincipal.EditValue = Trim(IfNull(ItemRow("FKeyPrincipal"), ""))
            cboFKeyOwner.EditValue = Trim(IfNull(ItemRow("FKeyOwner"), ""))

            'added by elmer 20151107
            cboFKeyMgrFlt.EditValue = Trim(IfNull(ItemRow("FKeyMgrFlt"), ""))
            'end elmer

            cboFKeyFlt.EditValue = Trim(IfNull(ItemRow("FKeyFlt"), ""))
            cboFKeyCrewCmpl.EditValue = Trim(IfNull(ItemRow("FKeyCrewCmpl"), ""))
            txtLifeBoatCapacity.Text = Trim(IfNull(ItemRow("LifeBoatCapacity"), ""))
            cboFKeyMinCrew.EditValue = Trim(IfNull(ItemRow("FKeyMinCrew"), ""))
            cboFKeyComp.EditValue = Trim(IfNull(ItemRow("FKeyComp"), ""))
            cboVslStat.EditValue = Trim(IfNull(ItemRow("VslStat"), "0"))
            txtDateJoined.Text = Trim(IfNull(ItemRow("DateJoined"), ""))
            txtDateLeft.Text = Trim(IfNull(ItemRow("DateLeft"), ""))

        Next

        'Pay Related
        txtCutOff.Text = Trim(IfNull(blList.GetFocusedRowData("CutOff"), "0"))
        txtSOFFCutOff.Text = Trim(IfNull(blList.GetFocusedRowData("SOFFCutOff"), "0"))

        'Union Agreements
        'UnionGrid.DataSource = DB.CreateTable("SELECT *, FKeyCBA AS FKeyCBAOther,0 AS Edited FROM dbo.tblAdmVslUnion WHERE FKeyVsl='" & strID & "'")
        MPS4Functions.AttachDocument.LoadViewWithDocImage(UnionGrid, UnionView, UnionImgView, _
                          "SELECT *, FKeyCBA AS FKeyCBAOther,0 AS Edited FROM dbo.tblAdmVslUnion WHERE FKeyVsl='" & strID & "'", _
                          "SELECT sub.*, 0 as Edited, '' AS tempFilePath FROM dbo.tblAttachDoc sub INNER JOIN tblAdmVslUnion main ON main.PKey = sub.FKeyParent WHERE main.FKeyVsl = '" & strID & "' AND sub.TableName = 'tblAdmVslUnion'", _
                          "PKey", "FKeyParent")

        'Vsl History
        VslHistoryGrid.DataSource = DB.CreateTable("SELECT *,0 AS Edited FROM dbo.frmAdmVsl_VslHistory WHERE FKeyVsl= '" & strID & "'")

        cboFKeyWageScale.EditValue = Trim(IfNull(blList.GetFocusedRowData("FKeyWageScale"), ""))
        Me.gridNatWScale.DataSource = DB.CreateTable("Select *, 0 as Edited from tblAdmVslNatWScale where FKeyVslCode ='" & strID & "'")
        lkuNationality.DataSource = DB.CreateTable("Select PKey, Nat from tbladmcntry")
        lkuWScale.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmWScale where Active = -1 ORDER BY Name ASC")
    End Sub

    'Refresh
    Public Overrides Sub RefreshData()
        TableName = "tblAdmVsl"
        strRequiredFields = "txtName,txtAbbrv,cboFKeyVslType"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Vessel Details - " & strDesc)
        bInsertVslHst = False
        bRemark = False
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        GetSelectedTab()
        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            initControls()
            LoadSub()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()
        Else
            LoadSub()
            BRECORDUPDATEDs = False
        End If
        'Add Listener for edited fields
        AddEditListener(Me.LayoutControl1.Root)
        AddEditListener(Me.TabPage1)
        AddEditListener(Me.TabPage2)
        AddEditListener(Me.TabPage3)

        'RemoveEditListener(Me.TabPage1)
        MakeReadOnlyListener(Me.LayoutControl1.Root)
        MakeReadOnlyListener(Me.TabPage1)
        MakeReadOnlyListener(Me.TabPage2)
        MakeReadOnlyListener(Me.TabPage3)

        'Vsl Union
        EditSubAllowGrid(UnionView, False)
        EditSubAllowGrid(UnionImgView, False)
        MPS4Functions.AllowRepositoryBtnEdit(repBtnEditBrowse, False)

        'Vsl History
        EditSubAllowGrid(VslHistoryView, False)

        'Nationality Wage Scale
        EditSubAllowGrid(vslNatWScaleView, False)

        SetDelOption()
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        txtName.Focus()

        '20161017 - comment out by fords - no agent tab exist
        'if Agents Tab is selected
        'If Me.TabControl.SelectedTabPageIndex = 4 Then
        '    AllowDeletionSub(Name, True)
        'End If

        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            RemoveReadOnlyListener(Me.TabPage1)
            RemoveReadOnlyListener(Me.TabPage2)
            RemoveReadOnlyListener(Me.TabPage3)

            ''Vsl History
            With Me.VslHistoryView
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            End With

        Else
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            MakeReadOnlyListener(Me.TabPage1)
            MakeReadOnlyListener(Me.TabPage2)
            MakeReadOnlyListener(Me.TabPage3)

            'Vsl History
            With Me.VslHistoryView
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            End With

        End If

        EditSubAllowGrid(UnionView, isEditdable)
        EditSubAllowGrid(UnionImgView, isEditdable)
        EditSubAllowGrid(vslNatWScaleView, isEditdable)
        MPS4Functions.AllowRepositoryBtnEdit(repBtnEditBrowse, isEditdable)
    End Sub

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        Me.TabControl.SelectedTabPageIndex = 0
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            ClearFields(Me.TabPage1, False)
            ClearFields(Me.TabPage2, False)
            AllowDeletion(Name, False) 'Disable Delete button
            AllowEditing(Name, False) 'Disable Edit Button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName)
            Me.TabControl.SelectedTabPageIndex = 0
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            RemoveReadOnlyListener(Me.TabPage1)
            RemoveReadOnlyListener(Me.TabPage2)

            Me.UnionGrid.DataSource = Nothing
            EditSubAllowGrid(UnionView, False)
            EditSubAllowGrid(UnionImgView, False)
            MPS4Functions.AllowRepositoryBtnEdit(repBtnEditBrowse, False)
            EditSubAllowGrid(VslHistoryView, False)
            ''Vsl History
            'Me.VslHistoryGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.tblAdmVslHistory ORDER BY Name ASC")
            Me.VslHistoryGrid.DataSource = Nothing
            'With Me.VslHistoryView
            '    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            '    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            '    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            '    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            'End With
            BRECORDUPDATEDs = False

        End If
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        Dim info As Boolean = False
        Dim id As String = "", type As String = ""
        'insert Header
        id = strID
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, cboFKeyVslType}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName) 'neil	'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Vessel", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}) Then
                    Exit Sub
                Else
                    info = DB.RunSql(GenerateInsertScript(Me.LayoutControl1.Root, 3, "tblAdmVsl", "LastUpdatedBy", "'" & LastUpdatedBy & "'"))
                    id = IfNull(DB.GetLastInsertedItem("PKey", "tblAdmVsl"), strID)
                    type = "Inserted"
                    BRECORDUPDATEDs = False
                End If
            Else
                id = strID
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}, "PKey<>'" & strID & "'") Then
                    Exit Sub
                Else
                    If bRemark Then
                        bInsertVslHst = False
                    Else
                        bInsertVslHst = True
                    End If
                    Dim lcg As DevExpress.XtraLayout.LayoutControlGroup = Nothing
                    Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPageIndex)
                        Case 0 'Vessel Specification
                            info = SaveVslSpecs(id)
                            lcg = Me.TabPage1
                        Case 1 ' Company Specification
                            info = SaveCompanySpecific(id)
                            lcg = Me.TabPage2
                        Case 2 'Pay Related
                            info = SavePayRelated(id)
                            info = DB.RunSqls(SaveNatWScale(id))
                        Case 3 'Union Agreements
                            info = DB.RunSqls(SaveVslUnion(id))
                        Case 4 'Vessel History
                            info = DB.RunSqls(SaveVslHistory(id))
                    End Select

                    tabChanged = False
                    'info = DB.RunSql(GenerateUpdateScript(Me.LayoutControl1.Root, 3, "tbladmVsl", "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate())", "PKey='" & id & "'"))
                    Dim qupd As String = ""
                    If Not IsNothing(lcg) Then
                        qupd = GenerateUpdateScript(New DevExpress.XtraLayout.LayoutControlGroup() {Me.LayoutControl1.Root, lcg}, 3, "tbladmVsl", "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate())", "PKey='" & id & "'")
                    End If
                    info = UpdateRelatedAdminName(id, TableName, qupd)
                    type = "Updated"
                    BRECORDUPDATEDs = False
                End If

            End If

            If bInsertVslHst Then
                info = DB.RunSqls(InsertVslHistory(id))
            End If
            If bRemark Then
                info = DB.RunSqls(SaveVslHistory(id))
            End If
            blList.RefreshData()
            blList.SetSelection(id)
            If info Then
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
                RefreshData()
            End If
        End If
        'End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv, cboFKeyVslType}) Then
                If bAddMode Then
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}) Then
                        flag = False
                        ALLOWNEXTS = flag
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    End If
                Else
                    If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName, txtAbbrv}, "PKey<>'" & strID & "'") Then
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
        Dim info As Boolean = False
        Dim infoCBA As Boolean = False
        Dim res As MsgBoxResult = MsgBoxResult.No

        If UnionGrid.IsFocused Then
            If UnionGrid.FocusedView.Name = "UnionView" Then
                res = MsgBox("Are you sure want to delete the selected Vessel?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
            ElseIf UnionGrid.FocusedView.Name = "UnionImgView" Then
                res = MsgBox("Are you sure want to delete the selected document?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
            End If
        Else
            If vslNatWScaleView.IsFocusedView Then
                res = MsgBox("Are you sure want to delete the selected Nationality?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
            Else
                res = MsgBox("Are you sure want to delete '" & strDesc & "''?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
            End If
        End If

        'If UnionGrid.FocusedView.Name = "UnionView" Then
        '    res = MsgBox("Are you sure want to delete the selected Vessel?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
        'ElseIf UnionGrid.FocusedView.Name = "UnionImgView" Then
        '    res = MsgBox("Are you sure want to delete the selected document?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
        'Else
        '    res = MsgBox("Are you sure want to delete '" & strDesc & "''?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName)
        'End If

        If res = MsgBoxResult.Yes Then
            If UnionGrid.IsFocused Then
                DeleteUnion()
            ElseIf DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Vessel", 10, System.Environment.MachineName, Me.txtName.EditValue, FormName)
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

                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    "tblAdmVslUnion", _
                    "FKeyVsl IN ('" & strID & "')", _
                    "<< Delete Admin Data - " & FormName & " - Union >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & "- Union>", _
                    GetUserName())
                '-->
                'If UnionGrid.FocusedView.Name = "UnionView" Then
                '    infoCBA = DB.RunSql("DELETE FROM dbo.tblAdmVslUnion WHERE PKey='" & UnionView.GetFocusedDataRow("PKey") & "'")
                '    MPS4Functions.AttachDocument.DeleteAttachDoc(UnionView, UnionImgView.LevelName, "ADMIN\VESSEL\" & strID)
                'Else
                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                infoCBA = DB.RunSql("DELETE FROM dbo.tblAdmVslUnion WHERE FKeyVsl='" & strID & "'")
                '<!-- commented out by tony20170906
                'IO.Directory.Delete("ADMIN\VESSEL\" & strID, True)
                '-->
                'End If

                If info Or infoCBA Then
                    If info Then
                        ClearFields(Me.LayoutControl1.Root, False)
                    End If

                    oLogDeletion.AddLogEntryToDatabase()

                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    blList.RefreshData()
                    RefreshData()
                    BRECORDUPDATEDs = False
                End If
            ElseIf vslNatWScaleView.IsFocusedView Then
                'Dim info As Boolean 
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()

                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    "tblAdmVslNatWScale", _
                    "PKey IN ('" & vslNatWScaleView.GetFocusedDataRow("PKey") & "')", _
                    "<< Delete Admin Data - " & FormName & " - Wage Scale per Nationality >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & "-Wage Scale per Nationality>", _
                    GetUserName())
                '-->

                info = DB.RunSql("DELETE FROM dbo.tblAdmVslNatWScale WHERE PKey='" & vslNatWScaleView.GetFocusedDataRow("PKey") & "'")

                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
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

    Private Sub DeleteUnion()
        Dim info As Boolean = False


        If UnionGrid.FocusedView.Name = "UnionView" Then
            '<!--added by tony20180922 : Log Deletion
            oLogDeletion.Init()
            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Admin,
                FormName, _
                "Admin", _
                "tblAdmVslUnion", _
                "PKey IN ('" & UnionView.GetFocusedDataRow("PKey") & "')", _
                "<< Delete Admin Data - " & FormName & " - Union >>", _
                LogDeletion.DeletionType.Manual, _
                "Manually Deleted in <" & FormName & "- Union>", _
                GetUserName())
            '-->
            info = DB.RunSql("DELETE FROM dbo.tblAdmVslUnion WHERE PKey='" & UnionView.GetFocusedDataRow("PKey") & "'")
            If info Then
                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
        End If
        MPS4Functions.AttachDocument.DeleteAttachDoc(UnionView, UnionImgView.LevelName, "ADMIN\VESSEL\" & strID)

        MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
        blList.RefreshData()
        RefreshData()
        BRECORDUPDATEDs = False
    End Sub

    Private Sub TabControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles TabControl.SelectedPageChanging
        'get the previous tab
        PrevTab = Me.TabControl.SelectedTabPageIndex
    End Sub

    Private Sub TabControl_TabIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl.SelectedPageChanged
        GetSelectedTab()
        SetDelOption()
        If BRECORDUPDATEDs Then
            'If BRECORDUPDATEDs And (bPermission And 4) > 0 Then
            If MsgBox("Would you like to save the changes you made on " & strDesc & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                tabChanged = True
                SaveData()
            Else
                RefreshData()
            End If
        End If
    End Sub

#Region "Vessel Specification Tab"

    Private Function SaveVslSpecs(ByVal id As String) As Boolean
        Return DB.RunSql(GenerateUpdateScript(Me.TabPage1, 3, "tblAdmVsl", "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & id & "'"))
    End Function
#End Region

#Region "Company Specific Tab"

    Private Function SaveCompanySpecific(ByVal id As String) As Boolean
        Return DB.RunSql(GenerateUpdateScript(Me.TabPage2, 3, "tblAdmVsl", "LastUpdatedBy='" & LastUpdatedBy & "',DateUpdated=(getdate())", "PKey='" & id & "'"))

    End Function

    Private Function AllowInactive(VslCode As String) As Boolean
        Dim retVal As Boolean = False

        'edited by tony20170605
        Dim cSQL As String
        cSQL = "SELECT sum(t.CrewCount) as CrewCount FROM " & _
               "    (" & _
               "        SELECT count(*) as CrewCount FROM dbo.Current_Activites WHERE FKeyVslCode = '" & VslCode & "' AND FKeyStatCode IN ('SYSONB', 'SYSSICKONB') " & _
               "        UNION " & _
               "        SELECT count(*) as CrewCount FROM dbo.tblPlanningEvent pe INNER JOIN dbo.tblPlanningEventCrew pec ON pec.FKeyPlanningEvent = pe.PKey WHERE FKeyVessel = 'SPECT0000000242' " & _
               "    ) t"
        'DB.BeginReader("SELECT COUNT(FKeyIDNbr) AS OnbCount FROM dbo.Current_Activites WHERE FKeyVslCode = '" & VslCode & "'")
        'end tony
        DB.BeginReader(cSQL)
        While DB.Read
            If DB.ReaderItem(0) > 0 Then
                retVal = False
            Else
                retVal = True
            End If
        End While
        DB.CloseReader()

        Return retVal
    End Function
#End Region

#Region "PayRelated Tab"
    Private Function SavePayRelated(id As String) As Boolean
        Return DB.RunSql(GenerateUpdateScript_Recursive(Me.TabPage3, 3, "tblAdmVsl", "LastUpdatedBy='" & LastUpdatedBy & "'", "PKey='" & id & "'"))
    End Function
#End Region

#Region "Vessel History Tab"
    'Temporary for Vessel History
    Private Function InsertVslHistory(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With blList


            query.Add("INSERT INTO dbo.tblAdmVslHistory" & _
                      "(FKeyVsl" & _
                      ",Name" & _
                      ",OffNbr" & _
                      ",FKeyVslType" & _
                      ",PortofReg" & _
                      ",Flag" & _
                      ",Classf" & _
                      ",YrBuilt" & _
                      ",GrossTon" & _
                      ",DeadWt" & _
                      ",NetTon" & _
                      ",EngType" & _
                      ",EngPower" & _
                      ",UMS" & _
                      ",CallSign" & _
                      ",Phone" & _
                      ",Telefax" & _
                      ",Email" & _
                      ",FKeyPrincipal" & _
                      ",FKeyOwner" & _
                      ",FKeyEmployer" & _
                      ",FKeyMgrTech" & _
                      ",FKeyMgrFlt" & _
                      ",FKeyFlt" & _
                      ",FKeyMinCrew" & _
                      ",LifeBoatCapacity" & _
                      ",DateJoined" & _
                      ",DateLeft" & _
                      ",DateUpdated" & _
                      ")" & _
                      " VALUES(" & _
                      "'" & id & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("Name"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("OffNbr"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyVslType"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("PortofReg"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("Flag"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("Classf"), ""))) & "'" & _
                      ",'" & Trim(IfNull(.GetFocusedRowData("YrBuilt"), "")) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("GrossTon"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("DeadWt"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("NetTon"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("EngType"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("EngPower"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("UMS"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("CallSign"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("Phone"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("Telefax"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("Email"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyPrincipal"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyOwner"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyEmployer"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyMgrTech"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyMgrFlt"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyFlt"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("FKeyMinCrew"), ""))) & "'" & _
                      ",'" & Trim(CleanInput(IfNull(.GetFocusedRowData("LifeBoatCapacity"), ""))) & "'" & _
                      "," & ChangeToSQLDate(blList.GetFocusedRowData("DateJoined")) & "" & _
                      "," & ChangeToSQLDate(blList.GetFocusedRowData("DateLeft")) & "" & _
                      ",GETDATE()" & _
                      ")")

        End With

        Return query
    End Function

    'VSL History has no INSERT because will put trigger in the on every update automatic vsl history.
    'You can only add "Remarks"
    Private Function SaveVslHistory(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With Me.VslHistoryView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Vessel History", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'tony20160719

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        'query.Add("INSERT INTO dbo.tblAdnV(FKeyIDNbr,Bldg,St,PartofCity,City,State,FKeyCntry,PostCode,FKeyAirport,Phone,Telefax,Email,AddrStat,PayAddr,LastUpdatedBy)" & _
                        '           "VALUES('" & strID & "'" & _
                        '           ",'" & .GetRowCellValue(i, "Bldg") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "St") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "PartofCity") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "City") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "State") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "FKeyCntry") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "PostCode") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "FKeyAirport") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "Phone") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "Telefax") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "Email") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "AddrStat") & "'" & _
                        '           ",'" & .GetRowCellValue(i, "PayAddr") & "'" & _
                        '           ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblAdmVslHistory SET " & _
                                  "Remarks = '" & .GetRowCellValue(i, "Remarks") & "'" & _
                                  ",DateUpdated = '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyVsl = '" & id & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                End If
            Next
        End With
        Return query
    End Function

    Private Sub VslHistoryView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles VslHistoryView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.VslHistoryView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
        'BRECORDUPDATEDs = True
    End Sub

    Private Sub VslHistoryView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles VslHistoryView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        SubAddMode = True
    End Sub

    Private Sub VslHistoryView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles VslHistoryView.InvalidRowException, VslHistoryView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub VslHistoryView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles VslHistoryView.KeyDown, VslHistoryView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.VslHistoryView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub VslHistoryView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles VslHistoryView.RowCellStyle
        If Me.VslHistoryView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.VslHistoryView.GetRowCellValue(e.RowHandle, "Edited") And Me.VslHistoryView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.VslHistoryView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.VslHistoryView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub VslHistoryView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles VslHistoryView.RowUpdated, VslHistoryView.RowUpdated
        BRECORDUPDATEDs = True
        bRemark = True

    End Sub

    Private Sub VslHistoryView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles VslHistoryView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Vessel History"
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

    Private Sub VslHistoryView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles VslHistoryView.ValidateRow, VslHistoryView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'validate Payrol Address
        'validate Current Address
    End Sub

#End Region

#Region "NatWScale"

    Private Sub vslNatWScaleView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles vslNatWScaleView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub vslNatWScaleView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles vslNatWScaleView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.vslNatWScaleView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub vslNatWScaleView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles vslNatWScaleView.RowCellStyle
        If Me.vslNatWScaleView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.vslNatWScaleView.GetRowCellValue(e.RowHandle, "Edited") And Me.vslNatWScaleView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.vslNatWScaleView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.vslNatWScaleView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub vslNatWScaleView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles vslNatWScaleView.RowUpdated
        BRECORDUPDATEDs = True
        'bRemark = True
    End Sub

    Private Sub vslNatWScaleView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles vslNatWScaleView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.vslNatWScaleView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
        'BRECORDUPDATEDs = True
    End Sub

    Private Sub vslNatWScaleView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles vslNatWScaleView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("FKeyVslCode"), strID)
        SubAddMode = True
    End Sub

    Private Function SaveNatWScale(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With Me.vslNatWScaleView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Nationality/Wage Scale", 10, System.Environment.MachineName, txtName.EditValue, FormName)

                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals("") Then
                        query.Add("INSERT INTO dbo.tblAdmVslNatWScale(FKeyVslCode,NatCode,FKeyWScale,LastUpdatedBy)" & _
                                   "VALUES('" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "NatCode") & "'" & _
                                   ",'" & .GetRowCellValue(i, "FKeyWScale") & "'" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tbladmvslnatwscale SET " & _
                                  "FKeyVslCode = '" & .GetRowCellValue(i, "FKeyVslCode") & "'" & _
                                  ",NatCode = '" & .GetRowCellValue(i, "NatCode") & "'" & _
                                  ",FKeyWScale = '" & .GetRowCellValue(i, "FKeyWScale") & "'" & _
                                  ",DateUpdated = '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If

                End If
            Next
        End With

        Return query
    End Function

    Private Sub vslNatWScaleView_FocusedColumnChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles vslNatWScaleView.FocusedColumnChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'Clear Errors
        With views
            .ClearColumnErrors()
        End With
    End Sub

    Private Sub vslNatWScaleView_GotFocus(sender As System.Object, e As System.EventArgs) Handles vslNatWScaleView.GotFocus
        'edited by tony20190712 
        'SetDelOption()
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Default Nationality-Wage Scale")
            AllowDeletion(Name, True)
        End If
        'end tony
    End Sub

    Private Sub vslNatWScaleView_LostFocus(sender As System.Object, e As System.EventArgs) Handles vslNatWScaleView.LostFocus
        'edited by tony20190712 
        'SetDelOption()
        If isEditdable Or bAddMode Then
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete")
            AllowDeletion(Name, False)
        End If
        'end tony
    End Sub
#End Region

#Region "Union Agreements Tab"

    Private Function SaveVslUnion(ByVal id As String) As ArrayList
        Dim query As New ArrayList
        With Me.UnionView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Union Agreements", 10, System.Environment.MachineName, txtName.EditValue, FormName)

                    If CStr(IfNull(.GetRowCellValue(i, "PKey"), "")).Equals(CStr(i)) Then
                        query.Add("INSERT INTO dbo.tblAdmVslUnion(FKeyVsl,FKeyCBA,ExpiryDate,LastUpdatedBy)" & _
                                   "VALUES('" & strID & "'" & _
                                   ",'" & .GetRowCellValue(i, "FKeyCBA") & "'" & _
                                   "," & ChangeToSQLDate(.GetRowCellValue(i, "ExpiryDate")) & "" & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        query.Add("UPDATE dbo.tblAdmVslUnion SET " & _
                                  "ExpiryDate = " & ChangeToSQLDate(.GetRowCellValue(i, "ExpiryDate")) & "" & _
                                  ",DateUpdated = '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyVsl = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If


                End If
            Next
        End With
        MPS4Functions.AttachDocument.SaveAttachDoc(UnionView, UnionImgView.LevelName, LastUpdatedBy, "ADMIN\VESSEL\" & strID, strID, "UNION", "ExpiryDate", "tblAdmVslUnion")
        Return query
    End Function

    Private Sub UnionView_CellValueChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles UnionView.CellValueChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        BRECORDUPDATEDs = True
        If e.Column.FieldName.ToString <> "Edited" Then
            With views
                .SetRowCellValue(e.RowHandle, "Edited", True)

                If e.Column.FieldName.ToString = "FKeyCBA" Then
                    .SetRowCellValue(e.RowHandle, "FKeyCBAOther", .GetRowCellValue(e.RowHandle, "FKeyCBA"))
                End If
            End With
        End If
    End Sub

    Private Sub UnionView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles UnionView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            .SetRowCellValue(e.RowHandle, "Edited", True)
            .SetRowCellValue(e.RowHandle, "PKey", view.RowCount)
        End With
        SubAddMode = True
    End Sub

    Private Sub UnionView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles UnionView.InvalidRowException, UnionView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub UnionView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles UnionView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.UnionView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub UnionView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles UnionView.RowCellStyle
        If Me.UnionView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.UnionView.GetRowCellValue(e.RowHandle, "Edited") And Me.UnionView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.UnionView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.UnionView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub UnionView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles UnionView.RowUpdated, UnionView.RowUpdated
        BRECORDUPDATEDs = True
        bRemark = True

    End Sub

    Private Sub UnionView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles UnionView.ValidateRow, UnionView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        header.Focus()
        With view
            AllowSaving(Name, False)
            e.Valid = False

            ValidateRequiredFields(sender, e, "FKeyCBA", "Please specify the CBA Type")
            ValidateRequiredFields(sender, e, "ExpiryDate", "Please specify the Expiry Date")

            'Clear Errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
        End With

    End Sub

    Private Sub UnionView_FocusedColumnChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles UnionView.FocusedColumnChanged
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'Clear Errors
        With views
            .ClearColumnErrors()
        End With
    End Sub

    Private Sub UnionView_GotFocus(sender As System.Object, e As System.EventArgs) Handles UnionView.GotFocus
        SetDelOption()
    End Sub

    Private Sub UnionView_LostFocus(sender As System.Object, e As System.EventArgs) Handles UnionView.LostFocus
        SetDelOption()
    End Sub

    Private Sub UnionImgView_CellValueChanging(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles UnionImgView.CellValueChanging
        Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim parentView As DevExpress.XtraGrid.Views.Grid.GridView = views.ParentView
        BRECORDUPDATEDs = True
        If e.Column.FieldName.ToString <> "Edited" Then
            With views
                .SetRowCellValue(e.RowHandle, "Edited", True)
                parentView.SetRowCellValue(.SourceRowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub UnionImgView_GotFocus(sender As System.Object, e As System.EventArgs) Handles UnionImgView.GotFocus
        SetRibbonPageGroupVisibility(Name, "rpgTool", True)
    End Sub

    Private Sub UnionImgView_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles UnionImgView.MouseDown
        SetRibbonPageGroupVisibility(Name, "rpgTool", True)
    End Sub

    Private Sub UnionImgView_LostFocus(sender As System.Object, e As System.EventArgs) Handles UnionImgView.LostFocus
        SetRibbonPageGroupVisibility(Name, "rpgTool", False)
    End Sub

#End Region

    Private Sub GetSelectedTab()
        Select Case TabControl.SelectedTabPage.Tag
            Case "VslSpec"
                SetEditOptionsVisibility(Name, True)
            Case "CompSpe"
                SetEditOptionsVisibility(Name, True)
            Case "Pay"
            Case "VslHist"
                SetEditOptionsVisibility(Name, False)
            Case Else
                SetEditOptionsVisibility(Name, True)
        End Select
    End Sub

#Region "LookUpEdit Event"
    Private Sub LookUpEdit_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repDateChange.ButtonClick, repPort.ButtonClick, cboFKeyVslType.ButtonClick, cboPortofReg.ButtonClick, cboFlag.ButtonClick, txtYrBuilt.ButtonClick, cboFKeyPrincipal.ButtonClick, cboFKeyFlt.ButtonClick, cboFKeyMinCrew.ButtonClick, txtDateJoined.ButtonClick, cboFKeyOwner.ButtonClick, cboFKeyCrewCmpl.ButtonClick, cboFKeyComp.ButtonClick, txtDateLeft.ButtonClick, cboFKeyMgrFlt.ButtonClick, cboVslStat.ButtonClick, repCBA.ButtonClick, repDate.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
#End Region

    Public Sub ValidateRequiredFields(ByRef sender As Object, ByRef e As ValidateRowEventArgs, colName As String, errMessage As String)
        Dim view As GridView = TryCast(sender, GridView)
        Dim column As DevExpress.XtraGrid.Columns.GridColumn = view.Columns(colName)
        If view.GetRowCellValue(e.RowHandle, column) Is DBNull.Value Or
            view.GetRowCellValue(e.RowHandle, column) Is Nothing Then
            view.SetColumnError(column, errMessage)
        Else
            view.SetColumnError(column, "")
        End If
    End Sub

    Private Sub SetDelOption()
        If UnionView.IsFocusedView Then
            Try
                If UnionView.GetFocusedDataRow("PKey") <> "" Then
                    AllowDeletion(Name, True)
                Else
                    AllowDeletion(Name, False)
                End If
            Catch ex As Exception
                AllowDeletion(Name, False)
            End Try
        Else
            AllowDeletion(Name, True)
        End If
    End Sub

    Private Sub cboVslStat_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboVslStat.EditValueChanging
        If bAddMode Or isEditdable Then
            If e.NewValue = 2 Then
                If Not AllowInactive(strID) Then
                    e.Cancel = True
                    'edited by tony20170605
                    'MsgBox("The vessel has Crew(s) onboard. Unable to set to inactive.", MsgBoxStyle.Critical, GetAppName)
                    MsgBox("Unable to set the vessel to inactive because there are currently onboard/planned crew(s) to it.", MsgBoxStyle.Information, GetAppName)
                    'end tony
                Else
                    e.Cancel = False
                End If
            Else
                e.Cancel = False
            End If

        End If

    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "ViewData"
                ViewFile(MPS4Functions.AttachDocument.GetAttachDocFilePath(UnionGrid, "ADMIN\VESSEL\" & strID))
        End Select
    End Sub

    Private Sub cboFKeyWageScale_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyWageScale.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub lkuNationality_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuNationality.ButtonClick
        Dim lku As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)

        ClearLookUpEdit(sender, e)
        'If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
        '    Me.vslNatWScaleView.DeleteRow(Me.vslNatWScaleView.FocusedRowHandle)
        'End If

    End Sub

    Private Sub lkuWScale_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuWScale.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Function alreadyInList(Desc As String, fld As String, ByRef gview As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim ret As Boolean = False
        With gview
            For a As Integer = 0 To .RowCount - 1
                'If .GetRowCellDisplayText(a, fld) = Desc Then
                If Not .GetRowCellValue(a, fld) Is DBNull.Value Then
                    If .GetRowCellValue(a, fld) = Desc Then
                        ret = True
                        Exit For
                    End If
                End If

            Next
        End With
        Return ret
    End Function

    'Private Sub lkuNationality_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles lkuNationality.CloseUp
    '    Dim lku As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
    '    If alreadyInList(lku.Text, "NatCode", Me.vslNatWScaleView) Then
    '        MsgBox("Selected Nationality is already in the list.", vbExclamation)
    '        e.AcceptValue = False
    '    End If
    'End Sub

    'Private Sub lkuNationality_EditValueChanged(sender As Object, e As System.EventArgs) Handles lkuNationality.EditValueChanged
    '    Dim lku As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
    '    If alreadyInList(lku.Text, "NatCode", Me.vslNatWScaleView) Then
    '        MsgBox("Selected Nationality is already in the list.", vbExclamation)

    '    End If
    '    'MsgBox(Me.vslNatWScaleView.GetRowCellDisplayText(0, "NatCode"))
    'End Sub

    'Private Sub lkuWScale_EditValueChanged(sender As Object, e As System.EventArgs) Handles lkuWScale.EditValueChanged
    '    Dim lku As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
    '    MsgBox(lku.EditValue)
    'End Sub

    Private Sub lkuNationality_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles lkuNationality.EditValueChanging
        Dim lku As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If alreadyInList(e.NewValue, "NatCode", Me.vslNatWScaleView) Then
            MsgBox("Selected Nationality is already in the list.", vbExclamation)
            e.Cancel = True
        End If

    End Sub

    Private Sub vslNatWScaleView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles vslNatWScaleView.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim Nat As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("NatCode")
        Dim WScale As DevExpress.XtraGrid.Columns.GridColumn = View.Columns("FKeyWScale")

        'If (View.GetRowCellValue(e.RowHandle, Nat) = "" Or View.GetRowCellValue(e.RowHandle, Nat) Is Nothing) Then
        If (View.GetRowCellValue(e.RowHandle, Nat) Is DBNull.Value) Then
            View.SetColumnError(Nat, "Select Nationality")
            e.Valid = False
        End If
        If (View.GetRowCellValue(e.RowHandle, WScale) Is DBNull.Value) Then
            View.SetColumnError(WScale, "Select Wage Scale")
            e.Valid = False
        End If
    End Sub

    Private Sub cboFKeyOtherBonusTemplate_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        ClearLookUpEdit(sender, e)
    End Sub

End Class
