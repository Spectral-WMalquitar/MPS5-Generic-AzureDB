Imports DevExpress.XtraEditors.Repository

Public Class SecGroup
    Private FormName As String = "Admin Group Security Details"
    Dim clsSec As New clsSecurity
    Dim insID As Long
    Const ALL_ROW = 0
    Private emptyEditor As RepositoryItemButtonEdit
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
    Dim frmprog As frmProgressBar

    Public Overrides Sub RefreshData()
        TableName = "MSysSec_Groups"
        MyBase.RefreshData()
        'SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        strRequiredFields = "txtName"
        If Not bLoaded Then
            initControls()
            'LoadSub()
            'AddEditListener(Me.LayoutControl1.Root)
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))

            Call refreshGrids()
            'Call refreshGridRpt()
            BRECORDUPDATEDs = False
        End If

        AddEditListener(Me.LayoutControl1.Root)
        ''for SUB DATA

        'MakeReadOnlyListener(Me.LayoutControl1.Root)
        Me.txtName.ReadOnly = True
        Call enableGridsViews(False)
        Me.lkuCate.Enabled = True
        Me.lkuCateRpt.Enabled = True


    End Sub

    Sub enableGridsViews(parB As Boolean)
        If Not parB Then
            Me.gridViewUsers.OptionsBehavior.ReadOnly = True
            Me.gridViewUsers.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewUsers.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewUsers.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewUsers.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            Me.gridViewObjects.OptionsBehavior.ReadOnly = True
            Me.gridViewObjects.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewObjects.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewObjects.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewObjects.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            Me.gridViewReports.OptionsBehavior.ReadOnly = True
            Me.gridViewReports.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewReports.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewReports.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            Me.gridViewReports.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

        Else
            Me.gridViewUsers.OptionsBehavior.ReadOnly = False
            Me.gridViewUsers.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.gridViewUsers.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.gridViewUsers.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            'Me.gridViewUsers.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

            Me.gridViewObjects.OptionsBehavior.ReadOnly = False
            Me.gridViewObjects.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.gridViewObjects.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.gridViewObjects.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
            'Me.gridViewObjects.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

            Me.gridViewReports.OptionsBehavior.ReadOnly = False
            Me.gridViewReports.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
            Me.gridViewReports.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
            Me.gridViewReports.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub

    Sub refreshGrids()
        Dim dt As New DataTable, dtO As New DataTable
        Dim strres As String

        'MsgBox(strID)

        Dim waitfrm As New WaitForm1
        'waitfrm.SetDescription("Saving...")
        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(Me, GetType(WaitForm1), False, True, True)
        DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Loading...")

        If strID <> "" And strID <> "0" Then 'And strID <> 0 Then

            clsSec.propSQLConnStr = DB.GetConnectionString
            strres = clsSec.get_group_users(strID, dt)
            'strres = clsSec.get_any_fr_db("select Userid,CAST(1 as bit) As Selected,Name from MSysSec_UsersGroup " & _
            '"left join MSysSec_Users on MSysSec_UsersGroup.UserID = MSysSec_Users.ID " & _
            '"where GroupID = str(" & strid & ")", dt)

            'MsgBox(dt.Rows(0).Item("name"))

            If strres = "" Then
                'Me.gridViewUsers.Columns.Clear()
                Me.gridUsers.DataSource = Nothing
                Me.gridUsers.DataSource = dt
            Else
                MsgBox(strres)
            End If

            Call refreshGridObj(IfNull(Me.lkuCate.EditValue, "<NOCRITERIA>"))
            Call refreshGridRpt(IfNull(Me.lkuCateRpt.EditValue, "<NOCRITERIA>"))
            Me.lkuCate.Enabled = True
            Me.lkuCateRpt.Enabled = True
            Me.btnClear.Enabled = True
        Else
            'Me.lkuCate.Enabled = False
            Me.btnClear.Enabled = False
            Me.GridObjects.DataSource = Nothing
            Me.gridReports.DataSource = Nothing
            Me.gridUsers.DataSource = Nothing
        End If

        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()

    End Sub

    Private Sub initControls()
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        Me.LayoutControl1.AllowCustomization = False

        Dim dt As New DataTable, dtrpt As New DataTable
        'Dim clsSec As New clsSecurity(DB.GetConnectionString)
        Dim strres As String
        clsSec.propSQLConnStr = DB.GetConnectionString

        'strres = clsSec.get_any_fr_db("select dbo.fntitlecase(Category) as Category from MPS.dbo.tblObjects group by Category", dt)
        strres = clsSec.get_any_fr_db("select " & _
                 "case isnull(Category,'') " & _
                 "when ''  then '<UNCATEGORIZED>'  " & _
                 "else " & _
                 "dbo.fntitlecase(LTrim(RTrim(Category))) " & _
                 "End " & _
                 "as Category  from MPS.dbo.tblObjects group by Category ", dt)
        strres = clsSec.get_any_fr_db("select dbo.fntitlecase(ReportGroup) as ReportGroup from MPS.dbo.MSystblReports group by ReportGroup", dtrpt)

        'MsgBox(dt.Rows.Count)
        If strres = "" Then
            ' Me.gridUsers.DataSource = dt

            Me.lkuCate.Properties.DataSource = dt
            Me.lkuCateRpt.Properties.DataSource = dtrpt
            ' Me.lkuCategory.EditValue = "Crewing"
        Else
            MsgBox(strres)
        End If
    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        'RemoveReadOnlyListener(Me.LayoutControl1.Root)
        Me.txtName.ReadOnly = False
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowEditing(Name, False) 'Allow Edit Button
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = 0
            strDesc = "New Record"
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            'Me.txtSortCode.EditValue = GetSortCode(DB, Me.TableName, "FKeyDocGroup='SYSTRAVELDOC'")

            BRECORDUPDATEDs = False
        End If


        Call refreshGrids()

    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        'isEditing = True
        If isEditdable Then
            txtName.Focus()
            'AllowDeletionSub(Name, True)
            'RemoveReadOnlyListener(Me.LayoutControl1.Root)
            Me.txtName.ReadOnly = False
            'RemoveReadOnlyListener(Me.header_sub)

            enableGridsViews(True)
            Me.btnClear.Enabled = True

        Else
            txtName.Focus()
            'MyBase.EditData()
            'AllowDeletionSub(Name, False)
            'MakeReadOnlyListener(Me.LayoutControl1.Root)
            Me.txtName.ReadOnly = True
            'MakeReadOnlyListener(Me.header_sub)
            enableGridsViews(False)

            Me.btnClear.Enabled = False
        End If
        BRECORDUPDATEDs = False

        Me.lkuCate.Enabled = True
        Me.lkuCateRpt.Enabled = True
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, id As Long = 0
        Dim type As String = "", info As Boolean = False
        Dim errmsg As String = "", tempFocusIndex As Integer, tempFocusIndexRpt As Integer

        Dim waitfrm As New WaitForm1
        'waitfrm.SetDescription("Saving...")
        'DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True, False)
        'DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Saving...")


        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            'getusername() & <Description><FormName>
            If bAddMode Then
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                    Exit Sub
                Else

                    'Dim GenID As Int64
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Group Added", FormName) 'neil
                    clsSec.add_group(Me.txtName.Text, LastUpdatedBy, id)
                    'id = GenID
                    type = "Inserted"
                    BRECORDUPDATEDs = False
                End If
            Else
                If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & id & "'") Then
                    Exit Sub
                Else
                    id = strID

                    'Dim affrows As Long
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Update is done to/under this Group", FormName) 'neil
                    errmsg = clsSec.update_group(id, Me.txtName.Text, LastUpdatedBy) ', , affrows)
                    ' MsgBox(affrows)
                    tempFocusIndex = Me.gridViewObjects.GetFocusedDataSourceRowIndex
                    tempFocusIndexRpt = Me.gridViewReports.GetFocusedDataSourceRowIndex

                    '/progressbar form
                    frmprog = New frmProgressBar
                    frmprog.prb1.Properties.Minimum = 0
                    frmprog.prd2.Properties.Minimum = 0
                    frmprog.prd2.Properties.Maximum = 99
                    frmprog.prd2.Properties.Step = 33 '3 functions / 3
                    frmprog.prb1.Position = 1
                    frmprog.prd2.Position = 1
                    frmprog.Show()
                    System.Windows.Forms.Application.DoEvents()

                    Call updUsers()
                    frmprog.prb1.Position = 1
                    frmprog.prd2.PerformStep()
                    frmprog.prd2.Update()
                    System.Windows.Forms.Application.DoEvents()
                    Call updObjs()
                    frmprog.prb1.Position = 1
                    frmprog.prd2.PerformStep()
                    frmprog.prd2.Update()
                    System.Windows.Forms.Application.DoEvents()
                    Call updRpts()
                    frmprog.prd2.Position = 99
                    frmprog.prd2.Update()
                    System.Windows.Forms.Application.DoEvents()

                    'MsgBox(Me.gridViewUsers.GetRowCellValue(1, "selected"))
                    BRECORDUPDATEDs = False
                    type = "Updated"

                    frmprog.Close()
                    frmprog = Nothing

                End If

            End If

            ' DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()

            If errmsg = "" Then
                info = True
            End If
            blList.RefreshData()
            If info Then
                blList.SetSelection(id)
                RefreshData()
                MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)
            End If

            Me.gridViewObjects.FocusedRowHandle = tempFocusIndex
            Me.gridViewReports.FocusedRowHandle = tempFocusIndexRpt
        End If

    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        'Dim info As Boolean = False
        Dim info As String = ""
        If MsgBox("Are you sure want to delete group " & strDesc & "?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then
                ' info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Delete Group", FormName) 'neil
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil

                '<!--added by tony20180922 : Log Deletion
                oLogDeletionSec.Init(DB.GetConnectionString())

                oLogDeletionSec.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Admin", _
                    "msyssec_groups", _
                    "GroupID IN ('" & strID & "')", _
                    "<< Delete Security Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->

                info = clsSec.del_group(strID)
                If info = "" Then
                    oLogDeletionSec.AddLogEntryToDatabase()
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

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Me.lkuCate.EditValue = Nothing
        Me.lkuCateRpt.EditValue = Nothing
        Call refreshGridObj(IfNull(Me.lkuCate.EditValue, "<NOCRITERIA>"))
        Call refreshGridRpt(IfNull(Me.lkuCateRpt.EditValue, "<NOCRITERIA>"))
        BRECORDUPDATEDs = False
    End Sub

    Function updUsers() As Boolean
        Dim ret As Boolean, errmsg As String
        Dim dv As DataView

        dv = gridViewUsers.DataSource

        Try
            With Me.gridViewUsers
                '.CloseEditForm()
                .CloseEditor()
                .UpdateCurrentRow()

                'For i As Integer = 0 To .RowCount - 1
                '    If .GetRowCellValue(i, "Edited") Then

                '        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Delete user from group", FormName) 'neil
                '        clsAudit.saveAuditPreDelDetails("MSysSec_UsersGroup", strID, LastUpdatedBy) 'neil
                '        clsSec.del_user_frGroup(.GetRowCellValue(i, "ID"), strID, False) 'delete first to be sure no duplicate although sql server will not accept dupli

                '        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Add user to group", FormName) 'neil
                '        If .GetRowCellValue(i, "selected") = 1 Then
                '            errmsg = clsSec.add_user_to_group(.GetRowCellValue(i, "ID"), strID, LastUpdatedBy, False)
                '            If errmsg <> "" Then
                '                Err.Raise(Err.Number)
                '            End If
                '        End If
                '    End If
                'Next

                frmprog.prb1.Properties.Maximum = dv.Table.Rows.Count
                frmprog.prb1.Properties.Step = 1

                For i As Integer = 0 To dv.Table.Rows.Count - 1
                    If dv.Table.Rows(i)("Edited") Then

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Delete user " & dv.Table.Rows(i)("Name") & " from group", FormName) 'neil
                        'neil 20170804 clsAudit.saveAuditPreDelDetails("MSysSec_UsersGroup", strID, LastUpdatedBy) 'neil
                        clsAudit.saveAuditPreDelDetails("MSysSec_UsersGroup", dv.Table.Rows(i)("ID"), LastUpdatedBy) 'neil
                        clsSec.del_user_frGroup(dv.Table.Rows(i)("ID"), strID, False) 'delete first to be sure no duplicate although sql server will not accept dupli

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Add user " & dv.Table.Rows(i)("Name") & " to group", FormName) 'neil
                        If dv.Table.Rows(i)("selected") = 1 Then
                            errmsg = clsSec.add_user_to_group(dv.Table.Rows(i)("ID"), strID, LastUpdatedBy, False)
                            If errmsg <> "" Then
                                Err.Raise(Err.Number)
                            End If
                        End If
                    End If
                    frmprog.prb1.PerformStep()
                    frmprog.prb1.Update()
                    System.Windows.Forms.Application.DoEvents()
                Next
                clsSec.closeConn()
            End With
            ret = True
        Catch
            ret = False
            clsSec.closeConn()
        End Try

        Return ret
    End Function

    Function updObjs(Optional exemptRow As Integer = 9999) As Boolean
        Dim ret As Boolean, errmsg As String
        Dim canadd As Integer, candelete As Integer, canupdate As Integer, viewonly As Integer, tot As Integer
        Dim candatatool As Integer
        Dim dv As DataView

        dv = gridViewObjects.DataSource

        Try
            With Me.gridViewObjects
                '.CloseEditForm()
                .CloseEditor()
                .UpdateCurrentRow()

                '    'For i As Integer = 0 To .RowCount - 1
                '    If i <> exemptRow Then
                '        If .GetRowCellValue(i, "ObjectID") <> "<ALL>" Then
                '            If .GetRowCellValue(i, "Edited") Then

                '                canadd = IfNull(.GetRowCellValue(i, "CanAdd"), 0)
                '                candelete = IfNull(.GetRowCellValue(i, "CanDelete"), 0)
                '                canupdate = IfNull(.GetRowCellValue(i, "CanUpdate"), 0)
                '                viewonly = IfNull(.GetRowCellValue(i, "ViewOnly"), 0)
                '                candatatool = IfNull(.GetRowCellValue(i, "CanDataTool"), 0)

                '                tot = canadd + candelete + canupdate + viewonly + candatatool

                '                Debug.Print(.GetRowCellValue(i, "ObjectID"))

                '                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Delete permission", FormName) 'neil
                '                clsAudit.saveAuditPreDelDetails("MSysSec_GroupObjectPerm", strID, LastUpdatedBy) 'neil
                '                clsSec.del_obj_frGroup(.GetRowCellValue(i, "ObjectID"), strID, False) 'delete first to be sure no duplicate although sql server will not accept dupli

                '                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Update permission", FormName) 'neil
                '                If tot >= 1 Then
                '                    errmsg = clsSec.add_obj_to_group(.GetRowCellValue(i, "ObjectID"), strID, canadd, canupdate, candelete, viewonly, candatatool, LastUpdatedBy, False)
                '                    If errmsg <> "" Then
                '                        Err.Raise(Err.Number)
                '                    End If
                '                End If
                '            End If
                '        End If
                '    End If
                'Next

                frmprog.prb1.Properties.Maximum = dv.Table.Rows.Count
                frmprog.prb1.Properties.Step = 1

                For i As Integer = 0 To dv.Table.Rows.Count - 1
                    'For i As Integer = 0 To .RowCount - 1
                    If i <> exemptRow Then
                        If dv.Table.Rows(i)("ObjectID") <> "<ALL>" Then
                            If dv.Table.Rows(i)("Edited") Then

                                canadd = IfNull(dv.Table.Rows(i)("CanAdd"), 0)
                                candelete = IfNull(dv.Table.Rows(i)("CanDelete"), 0)
                                canupdate = IfNull(dv.Table.Rows(i)("CanUpdate"), 0)
                                viewonly = IfNull(dv.Table.Rows(i)("ViewOnly"), 0)
                                candatatool = IfNull(dv.Table.Rows(i)("CanDataTool"), 0)

                                tot = canadd + candelete + canupdate + viewonly + candatatool

                                Debug.Print(dv.Table.Rows(i)("ObjectID"))

                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Delete permission", FormName) 'neil
                                clsAudit.saveAuditPreDelDetails("MSysSec_GroupObjectPerm", strID, LastUpdatedBy) 'neil
                                clsSec.del_obj_frGroup(dv.Table.Rows(i)("ObjectID"), strID, False) 'delete first to be sure no duplicate although sql server will not accept dupli

                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Update permission", FormName) 'neil
                                If tot >= 1 Then
                                    errmsg = clsSec.add_obj_to_group(dv.Table.Rows(i)("ObjectID"), strID, canadd, canupdate, candelete, viewonly, candatatool, LastUpdatedBy, False)
                                    If errmsg <> "" Then
                                        Err.Raise(Err.Number)
                                    End If
                                End If
                            End If
                        End If
                    End If

                    frmprog.prb1.PerformStep()
                    frmprog.prb1.Update()
                    System.Windows.Forms.Application.DoEvents()
                Next

                clsSec.closeConn()
            End With
            ret = True
        Catch
            ret = False
            clsSec.closeConn()
        End Try

        Return ret
    End Function

    Function updRpts(Optional exemptRow As Integer = 9999) As Boolean
        Dim ret As Boolean, errmsg As String
        Dim canview As Integer
        Dim dv As DataView


        dv = Me.gridViewReports.DataSource

        Try
            With Me.gridViewReports
                '.CloseEditForm()
                .CloseEditor()
                .UpdateCurrentRow()

                frmprog.prb1.Properties.Maximum = dv.Table.Rows.Count
                frmprog.prb1.Properties.Step = 1

                For i As Integer = 0 To dv.Table.Rows.Count - 1
                    '    Debug.Print(dt.Table.Rows(e)("Caption") & ":" & e & ": " & dt.Table.Rows(e)("CanView"))
                    'Next

                    'For i As Integer = 0 To .DataRowCount - 1
                    'For i As Integer = 0 To .RowCount - 1
                    If i <> exemptRow Then
                        'If .GetRowCellValue(i, "ObjectID") <> "<ALL>" Then
                        If dv.Table.Rows(i)("ObjectID") <> "<ALL>" Then
                            'If .GetRowCellValue(i, "Edited") Then
                            If dv.Table.Rows(i)("Edited") Then
                                'canview = IfNull(.GetRowCellValue(i, "CanView"), 0)
                                canview = IfNull(dv.Table.Rows(i)("CanView"), 0)

                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Delete permission", FormName) 'neil
                                clsAudit.saveAuditPreDelDetails("MSysSec_GroupObjectPermReports", strID, LastUpdatedBy) 'neil
                                'clsSec.del_objRpt_frGroup(.GetRowCellValue(i, "ObjectID"), strID, False, .GetRowCellValue(i, "ReportGroup")) 'delete first to be sure no duplicate although sql server will not accept dupli
                                clsSec.del_objRpt_frGroup(dv.Table.Rows(i)("ObjectID"), strID, False, dv.Table.Rows(i)("ReportGroup")) 'delete first to be sure no duplicate although sql server will not accept dupli

                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "Update permission", FormName) 'neil
                                If canview = 1 Then
                                    'errmsg = clsSec.add_objrpt_to_group(.GetRowCellValue(i, "ObjectID"), strID, canview, LastUpdatedBy, False, .GetRowCellValue(i, "ReportGroup"))
                                    errmsg = clsSec.add_objrpt_to_group(dv.Table.Rows(i)("ObjectID"), strID, canview, LastUpdatedBy, False, dv.Table.Rows(i)("ReportGroup"))
                                    If errmsg <> "" Then
                                        Err.Raise(Err.Number)
                                    End If
                                End If

                            End If
                        End If
                    End If

                    frmprog.prb1.PerformStep()
                    frmprog.prb1.Update()
                    System.Windows.Forms.Application.DoEvents()
                Next
                clsSec.closeConn()
            End With
            ret = True
        Catch
            ret = False
            clsSec.closeConn()
        End Try

        Return ret
    End Function


    Sub refreshGridObj(Optional sCate As String = "<NOCRITERIA>")
        Dim strres As String
        Dim dtO As New DataTable, dtrow As DataRow

        strres = clsSec.get_group_objects(strID, dtO, sCate)

        clsFeature.filterTableByFeature(dtO, COMPANYID, FEATUREKEY)

        If strres = "" Then
            'Me.gridViewObjects.Columns.Clear()
            Me.GridObjects.DataSource = Nothing

            Dim rowrow As DataRow = dtO.NewRow

            rowrow.Item("ObjectID") = "<ALL>"
            rowrow.Item("Caption") = "<ALL>"
            rowrow.Item("fullperm") = 0
            rowrow.Item("CanAdd") = 0
            rowrow.Item("CanUpdate") = 0
            rowrow.Item("ViewOnly") = 0
            rowrow.Item("CanDelete") = 0
            rowrow.Item("CanDataTool") = 0
            dtO.Rows.InsertAt(rowrow, ALL_ROW)

            For Each dtrow In dtO.Rows '' set null values to zero
                If dtrow.Item("fullperm").GetType Is GetType(DBNull) Then
                    dtrow.Item("fullperm") = 0
                End If
                If dtrow.Item("CanAdd").GetType Is GetType(DBNull) Then
                    dtrow.Item("CanAdd") = 0
                End If
                If dtrow.Item("CanUpdate").GetType Is GetType(DBNull) Then
                    dtrow.Item("CanUpdate") = 0
                End If
                If dtrow.Item("ViewOnly").GetType Is GetType(DBNull) Then
                    dtrow.Item("ViewOnly") = 0
                End If
                If dtrow.Item("CanDelete").GetType Is GetType(DBNull) Then
                    dtrow.Item("CanDelete") = 0
                End If
                If dtrow.Item("CanDataTool").GetType Is GetType(DBNull) Then
                    dtrow.Item("CanDataTool") = 0
                End If
            Next

            Me.GridObjects.DataSource = dtO
            'Me.GridObjects.RefreshDataSource()
        Else
            MsgBox(strres)
        End If
    End Sub

    Sub refreshGridRpt(Optional rptGroup As String = "<NOCRITERIA>")
        Dim strres As String
        Dim dtO As New DataTable, dtrow As DataRow

        strres = clsSec.get_group_reports(strID, dtO, rptGroup)

        clsFeature.filterTableByFeature(dtO, COMPANYID, FEATUREKEY)

        If strres = "" Then
            'Me.gridViewObjects.Columns.Clear()
            Me.gridReports.DataSource = Nothing

            Dim rowrow As DataRow = dtO.NewRow

            rowrow.Item("ObjectID") = "<ALL>"
            rowrow.Item("Caption") = "<ALL>"
            rowrow.Item("CanView") = 0
            dtO.Rows.InsertAt(rowrow, ALL_ROW)

            For Each dtrow In dtO.Rows '' set null values to zero
                If dtrow.Item("CanView").GetType Is GetType(DBNull) Then
                    dtrow.Item("CanView") = 0
                End If
            Next
            Me.gridReports.DataSource = dtO
            'Me.GridObjects.RefreshDataSource()
        Else
            MsgBox(strres)
        End If
    End Sub



    Private Sub chkFullPerm_CheckStateChanged(sender As System.Object, e As System.EventArgs) Handles chkFullPerm.CheckStateChanged
        'MsgBox(Me.gridViewObjects.FocusedRowHandle)
        'Me.gridViewObjects.SetRowCellValue(1, "HasOpen", 1)
        'Me.gridViewObjects.SetRowCellValue(5, "HasAdd", 1)
        'MsgBox(Me.gridViewObjects.GetFocusedRowCellValue("HasOpen"))
        'Me.gridViewObjects.PostEditor()
        'MsgBox(gridViewObjects.GetFocusedDisplayText)
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If gridViewUsers.HasColumnErrors() Or gridViewObjects.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}, showMsg) Then
                    If bAddMode Then
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                            flag = False
                            ALLOWNEXTS = flag
                        Else
                            flag = True
                            ALLOWNEXTS = flag
                            SaveData() '
                        End If
                    Else
                        If CheckDuplicate(Me.TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
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



    Private Sub chkHasOpen_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkHasOpen.CheckedChanged
        ' Me.gridViewObjects.PostEditor()
    End Sub

    Private Sub chkHasAdd_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkHasAdd.CheckStateChanged
        'Me.gridViewObjects.PostEditor()
    End Sub

    Private Sub chkHasEdit_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkHasEdit.CheckStateChanged
        'Me.gridViewObjects.PostEditor()
    End Sub

    Private Sub chkHasDel_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkHasDel.CheckStateChanged
        'Me.gridViewObjects.PostEditor()
    End Sub

    Private Sub gridViewUsers_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles gridViewUsers.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub txtName_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtName.EditValueChanged
        'BRECORDUPDATEDs = True
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As System.EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub lkuCate_TextChanged(sender As Object, e As System.EventArgs) Handles lkuCate.TextChanged
        BRECORDUPDATEDs = False 'make it false again. after baseControl.Field_EditValueChanged did make this variable to true
    End Sub

    Private Sub lkuCate_Validated(sender As Object, e As System.EventArgs) Handles lkuCate.Validated

    End Sub

    Private Sub lkuCate_EditValueChanged(sender As Object, e As System.EventArgs) Handles lkuCate.EditValueChanged
        'If Me.lkuCate.EditValue <> "" And Not Me.lkuCate.EditValue Is Nothing Then
        '    Call refreshGridObj(ifnull(Me.lkuCate.EditValue,""))
        'Else
        If Me.lkuCate.EditValue = "" Or Me.lkuCate.EditValue Is Nothing Then
            Call refreshGridObj()
        Else
            Me.gridViewObjects.ActiveFilterString = "Category like '" & Me.lkuCate.EditValue & "%' or [ObjectID] = '<ALL>'"
        End If
        'Call refreshGridObj(IfNull(Me.lkuCate.EditValue, "<NOCRITERIA>"))
        'Me.gridViewObjects.ActiveFilterString = "Category like '" & Me.lkuCate.EditValue & "%' or [ObjectID] = '<ALL>'"
        'Me.gridViewObjects.ActiveFilterString = " isnull(category,'') like '" & Me.lkuCate.EditValue & "%' or [ObjectID] = '<ALL>'"

        ' Me.gridViewObjects.ActiveFilterString = "[Category] is null or [ObjectID] = '<ALL>'"

        ' End If
        BRECORDUPDATEDs = False
    End Sub

    Private Sub lkuCate_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuCate.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            Me.gridViewObjects.ActiveFilterString = ""
            Me.lkuCate.EditValue = Nothing
            'Me.gridViewObjects.ActiveFilterString = ""
            'Call refreshGridObj(IfNull(Me.lkuCate.EditValue, "<NOCRITERIA>"))
        End If
        BRECORDUPDATEDs = False
    End Sub

    Private Sub SecGroup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        emptyEditor = New RepositoryItemButtonEdit()
        emptyEditor.Buttons.Clear()
        emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.GridObjects.RepositoryItems.Add(emptyEditor)
    End Sub

    Private Sub lkuCateRpt_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuCateRpt.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then '20160518
            Me.gridViewReports.ActiveFilterString = ""
            Me.lkuCateRpt.EditValue = Nothing
        End If
        'Me.gridViewReports.ActiveFilterString = ""
        'Call refreshGridRpt(IfNull(Me.lkuCateRpt.EditValue, "<NOCRITERIA>"))
        BRECORDUPDATEDs = False
    End Sub

    Private Sub lkuCateRpt_EditValueChanged(sender As Object, e As System.EventArgs) Handles lkuCateRpt.EditValueChanged
        'Call refreshGridRpt(IfNull(Me.lkuCateRpt.EditValue, "<NOCRITERIA>"))
        Me.gridViewReports.ActiveFilterString = "[ReportGroup] like '" & Me.lkuCateRpt.EditValue & "%' or [ObjectID] = '<ALL>'"
        BRECORDUPDATEDs = False
    End Sub



#Region "GRIDVIEWUSERS"

    Private Sub gridViewUsers_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridViewUsers.CellValueChanged
        'Me.gridViewUsers.PostEditor()
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.gridViewUsers.SetRowCellValue(e.RowHandle, "Edited", True)
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub gridViewUsers_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gridViewUsers.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
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

#Region "GRIDVIEWOBJECTS"

    Private Sub gridViewObjects_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridViewObjects.CellValueChanging

        'MsgBox(IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm"), 0))
        'MsgBox(IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 0))

        'MsgBox(e.Column.FieldName)
        Dim tempval As Integer
        Try

            Select Case e.Column.FieldName
                Case "fullperm"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm"), 0) = 0 Then
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 1)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 1)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanAdd", 1)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanUpdate", 1)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDelete", 1)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 1)
                    Else
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 0)
                    End If

                Case "ViewOnly"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 0) = 0 Then
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 1)
                        '20171123
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanAdd", 0)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanUpdate", 0)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDelete", 0)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 0)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 0)
                    Else 'when unchecked
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanAdd", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanUpdate", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDelete", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 0)
                    End If
                Case "CanUpdate"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanUpdate"), 0) = 1 Then
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanUpdate", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 0)
                    Else
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanUpdate", 1)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 1)
                    End If

                Case "CanDelete"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDelete"), 0) = 1 Then
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDelete", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 0)
                    Else
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDelete", 1)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 1)
                    End If

                Case "CanAdd"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd"), 0) = 1 Then
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanAdd", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 0)
                    Else
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanAdd", 1)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 1)
                    End If

                Case "CanDataTool"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDataTool"), 0) = 0 Then
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 1)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanAdd", 1)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanUpdate", 1)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDelete", 1)
                        'Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "ViewOnly", 1)
                    Else
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDataTool", 0)
                        Me.gridViewObjects.SetRowCellValue(e.RowHandle, "fullperm", 0)
                    End If
                Case Else
            End Select

            'MsgBox(IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm"), 0))
            'MsgBox(IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 0))

            ''If e.Column.FieldName = "fullperm" Then
            'If e.Column.FieldName <> "CanDataTool" Then
            '    If Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then
            '        For i As Integer = 1 To Me.gridViewObjects.RowCount

            '            Me.gridViewObjects.SetRowCellValue(i, "fullperm", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm"), 0))
            '            Me.gridViewObjects.SetRowCellValue(i, "CanAdd", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd"), 0))
            '            Me.gridViewObjects.SetRowCellValue(i, "CanUpdate", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanUpdate"), 0))
            '            Me.gridViewObjects.SetRowCellValue(i, "CanDelete", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDelete"), 0))
            '            Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 0))

            '            '20160518 If Me.gridViewObjects.GetRowCellValue(i, "Category") = "ADMIN" Then
            '            Me.gridViewObjects.SetRowCellValue(i, "CanDataTool", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDataTool"), 0))
            '            'End If

            '        Next
            '    Else

            '    End If
            'End If

            If Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then

               
                If e.Column.FieldName = "CanDelete" Then
                    'If Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then
                    tempval = Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDelete")
                    For i As Integer = 1 To Me.gridViewObjects.RowCount

                        If tempval = 0 Then
                            Me.gridViewObjects.SetRowCellValue(i, "fullperm", 0)
                        ElseIf tempval = 1 Then
                            'Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", 0)
                            Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", 1)
                        End If
                        Me.gridViewObjects.SetRowCellValue(i, "CanDelete", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDelete"), 0))

                        If tempval = 0 Then
                            Me.gridViewObjects.SetRowCellValue(i, "CanDataTool", 0)
                        End If
                    Next
                    'Else

                    'End If
                End If

                If e.Column.FieldName = "CanUpdate" Then
                    'If Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then
                    tempval = Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanUpdate")
                    For i As Integer = 1 To Me.gridViewObjects.RowCount

                        If tempval = 0 Then
                            Me.gridViewObjects.SetRowCellValue(i, "fullperm", 0)
                        ElseIf tempval = 1 Then
                            'Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", 0)
                            Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", 1)
                        End If
                        Me.gridViewObjects.SetRowCellValue(i, "CanUpdate", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanUpdate"), 0))

                        If tempval = 0 Then
                            Me.gridViewObjects.SetRowCellValue(i, "CanDataTool", 0)
                        End If
                    Next
                    'Else

                    'End If
                End If

                If e.Column.FieldName = "CanAdd" Then
                    'If Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then
                    tempval = Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd")
                    For i As Integer = 1 To Me.gridViewObjects.RowCount

                        If tempval = 0 Then
                            Me.gridViewObjects.SetRowCellValue(i, "fullperm", 0)
                        ElseIf tempval = 1 Then
                            'Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", 0)
                            Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", 1)
                        End If
                        Me.gridViewObjects.SetRowCellValue(i, "CanAdd", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd"), 0))

                        If tempval = 0 Then
                            Me.gridViewObjects.SetRowCellValue(i, "CanDataTool", 0)
                        End If
                    Next
                    'Else

                    'End If
                End If

                If e.Column.FieldName = "ViewOnly" Then
                    'If Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then
                    For i As Integer = 1 To Me.gridViewObjects.RowCount

                        'Me.gridViewObjects.SetRowCellValue(i, "fullperm", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm"), 1))
                        'Me.gridViewObjects.SetRowCellValue(i, "CanAdd", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd"), 1))
                        'Me.gridViewObjects.SetRowCellValue(i, "CanUpdate", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanUpdate"), 1))
                        'Me.gridViewObjects.SetRowCellValue(i, "CanDelete", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDelete"), 1))
                        'Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 1))
                        'Me.gridViewObjects.SetRowCellValue(i, "CanDataTool", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDataTool"), 1))
                        If IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 0) = 0 Then
                            Me.gridViewObjects.SetRowCellValue(i, "fullperm", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm"), 0))
                            Me.gridViewObjects.SetRowCellValue(i, "CanAdd", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd"), 0))
                            Me.gridViewObjects.SetRowCellValue(i, "CanUpdate", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanUpdate"), 0))
                            Me.gridViewObjects.SetRowCellValue(i, "CanDelete", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDelete"), 0))

                            Me.gridViewObjects.SetRowCellValue(i, "CanDataTool", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDataTool"), 0))
                        End If
                        Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 0))
                    Next
                    'Else

                    'End If
                End If

                If e.Column.FieldName = "CanDataTool" Then
                    'If Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then
                    For i As Integer = 1 To Me.gridViewObjects.RowCount

                        'If Me.gridViewObjects.GetRowCellValue(i, "Category") = "ADMIN" Then
                        'If Me.gridViewObjects.GetRowCellValue(i, "CanDataTool") <> 0 Then
                        Me.gridViewObjects.SetRowCellValue(i, "fullperm", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm"), 0))
                        Me.gridViewObjects.SetRowCellValue(i, "CanAdd", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd"), 0))
                        Me.gridViewObjects.SetRowCellValue(i, "CanUpdate", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanUpdate"), 0))
                        Me.gridViewObjects.SetRowCellValue(i, "CanDelete", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDelete"), 0))
                        Me.gridViewObjects.SetRowCellValue(i, "ViewOnly", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "ViewOnly"), 0))
                        Me.gridViewObjects.SetRowCellValue(i, "CanDataTool", IfNull(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanDataTool"), 0))
                        ' End If

                    Next
                    'Else

                End If
            End If

            'Me.gridViewObjects.SetRowCellValue(1, "fullperm", 1)

            'MsgBox(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm").ToString)
            'MsgBox(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "CanAdd").ToString)


            ' Me.gridViewObjects.SetRowCellValue(e.RowHandle, "CanDelete", 0)
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub gridViewObjects_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridViewObjects.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.gridViewObjects.SetRowCellValue(e.RowHandle, "Edited", True)
            BRECORDUPDATEDs = True
        End If
        'MsgBox(Me.gridViewObjects.GetRowCellValue(e.RowHandle, "fullperm").ToString)
    End Sub

    Private Sub gridViewObjects_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gridViewObjects.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
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

    Private Sub gridViewObjects_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles gridViewObjects.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub gridViewObjects_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridViewObjects.ShowingEditor
        'e.Cancel = True

    End Sub

    Private Sub gridViewObjects_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles gridViewObjects.CustomRowCellEdit
        'If e.RowHandle <> 0 Then
        'Debug.Print(e.Column.FieldName & " " & e.RowHandle)
        If Not DoHaveButton(TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView), e.Column.FieldName, e.RowHandle) Then
            'If e.RowHandle = 3 Then
            e.RepositoryItem = emptyEditor
            'End If
            'Debug.Print("donthave")
        Else
            'Debug.Print("dohave")
        End If
        'End If
    End Sub

    Private Function DoHaveButton(view As DevExpress.XtraGrid.Views.Grid.GridView, fldname As String, row As Integer) As Boolean
        Dim tempReturn As Boolean

        If view.GetRowCellValue(row, "ObjectID") = "<ALL>" Then
            tempReturn = True
        Else
            Select Case fldname
                Case "CanAdd"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(row, "HasAddBtn"), 0) = "1" Then
                        tempReturn = True
                    Else
                        tempReturn = False
                    End If
                Case "CanUpdate"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(row, "HasUpdateBtn"), 0) = "1" Then
                        tempReturn = True
                    Else
                        tempReturn = False
                    End If
                Case "CanDelete"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(row, "HasDeleteBtn"), 0) = "1" Then
                        tempReturn = True
                    Else
                        tempReturn = False
                    End If
                Case "CanDataTool"
                    If IfNull(Me.gridViewObjects.GetRowCellValue(row, "HasDataToolBtn"), 0) = "1" Then
                        tempReturn = True
                    Else
                        tempReturn = False
                    End If
                Case Else
                    tempReturn = True
            End Select

            'If Not IsDBNull(Me.gridViewObjects.GetRowCellValue(row, "HasDataTool")) Then
            '    Return False
            'Else
            '    Return True
            'End If

        End If

        Return tempReturn
    End Function

#End Region

#Region "GRIDVIEWREPORTS"

    Private Sub gridViewReports_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles gridViewReports.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub gridViewReports_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridViewReports.CellValueChanging

        If IfNull(Me.gridViewReports.GetRowCellValue(e.RowHandle, "CanView"), 0) = 0 Then
            Me.gridViewReports.SetRowCellValue(e.RowHandle, "CanView", 1)
        Else
            Me.gridViewReports.SetRowCellValue(e.RowHandle, "CanView", 0)
        End If

        If Me.gridViewReports.GetRowCellValue(e.RowHandle, "ObjectID") = "<ALL>" Then
            For i As Integer = 1 To Me.gridViewReports.RowCount

                Me.gridViewReports.SetRowCellValue(i, "CanView", IfNull(Me.gridViewReports.GetRowCellValue(e.RowHandle, "CanView"), 0))

            Next
        Else

        End If

    End Sub

    Private Sub gridViewReports_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gridViewReports.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
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

    Private Sub gridViewReports_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridViewReports.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.gridViewReports.SetRowCellValue(e.RowHandle, "Edited", True)
            BRECORDUPDATEDs = True
        End If
    End Sub

#End Region

    Function revCheck(val As Integer) As Integer
        If val = 1 Then
            Return 0
        ElseIf val = 0 Then
            Return 1
        Else
            Return 0
        End If
    End Function
   
    Private Sub gridViewObjects_CustomRowFilter(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles gridViewObjects.CustomRowFilter
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim dv As DataView = view.DataSource

        If CStr(dv(e.ListSourceRow)("Caption")) = "<ALL>" Then
            ' Make the current row visible.
            e.Visible = True
            ' Prevent default processing, so the row will be visible 
            ' regardless of the view's filter.
            e.Handled = True
        End If
    End Sub

    Private Sub gridViewReports_CustomRowFilter(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles gridViewReports.CustomRowFilter
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim dv As DataView = view.DataSource

        If CStr(dv(e.ListSourceRow)("Caption")) = "<ALL>" Then
            ' Make the current row visible.
            e.Visible = True
            ' Prevent default processing, so the row will be visible 
            ' regardless of the view's filter.
            e.Handled = True
        End If
    End Sub
End Class
