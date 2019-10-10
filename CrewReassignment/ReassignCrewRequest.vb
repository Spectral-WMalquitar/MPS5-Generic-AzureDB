Imports System.Drawing
Imports DevExpress.XtraGrid

Public Class ReassignCrewRequest

#Region "Declarations"

    Private Enum FocusedViewCtrl
        None = 0
        Selection = 1
        Selected = 2
    End Enum

    Private FormName As String = "Crew Reassignment Transfer Request"

    'Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Private _userdatafilter As String
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

    Private FOCUSED_VIEW As FocusedViewCtrl

#End Region

#Region "Initialization"
    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        'Repository ITEMS
        _userdatafilter = GetUserVslFilterString(, "PKey")
        repVsl.DataSource = DB.CreateTable("SELECT * FROM dbo.tbladmvsl " & _
                                           IIf(_userdatafilter.Length > 0, "WHERE " & _userdatafilter, "") & _
                                           "ORDER BY Name ASC, SortCode ASC")
        _userdatafilter = GetUserFilterString(, "PKey")
        repAgent.DataSource = DB.CreateTable("SELECT * FROM dbo.tbladmcompany " & _
                                           "WHERE isManagent <> 0 " & _
                                           IIf(_userdatafilter.Length > 0, "AND " & _userdatafilter & " ", "") & _
                                           "ORDER BY Name ASC, SortCode ASC")

        Me.LayoutControl1.AllowCustomization = False
        'Repository ITEMS
        Dim dt As New DataTable
        dt.Columns.Add("ActionCode", Type.GetType("System.Int32"))
        dt.Columns.Add("Action", Type.GetType("System.String"))

        dt.Rows.Add({0, "Pending"})
        dt.Rows.Add({1, "Approved"})
        dt.Rows.Add({2, "Rejected"})
        repAction.DataSource = dt

        With txtDateRequested.Properties
            .EditFormat.FormatString = "dd-MMM-yyyy"
            .Mask.EditMask = "dd-MMM-yyyy"
            .Mask.UseMaskAsDisplayFormat = True
            .CharacterCasing = Windows.Forms.CharacterCasing.Normal
        End With

        repActionAppliedBy.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.MSysSec_Users")
    End Sub
#End Region

#Region "Main"
    Private Sub LoadSub()
        Dim subFilterJoin As String = ""
        Dim _selectionFilter As String = ""
        Dim _selectedFilter As String = ""
        Dim cSQL As String = ""

        '-- GENERATE CREW DATA FILTERSTRING
        _userdatafilter = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        _userdatafilter = IIf(_userdatafilter.Length = 0, "'SHOW' = 'NO'", "NOT " & _userdatafilter)
        '------------------------------------------------------------------------------------------------------

        'GENERATE MAIN DATA CRITERIA
        _selectionFilter = _userdatafilter
        _selectedFilter = ""

        If blList.GetID() <> "" And Not bAddMode Then

            _selectionFilter = _selectionFilter & IIf(_selectionFilter.Length > 0, " AND ", "") & "idnbr NOT IN (SELECT FKeyIDNbr FROM dbo.tblCrewReassignCrews rcrew WHERE FKeyReassignID = '" & strID & "')"
            _selectionFilter = IIf(_selectionFilter.Length > 0, "WHERE " & _selectionFilter, "")

            _selectedFilter = _selectedFilter & IIf(_selectedFilter.Length > 0, " AND ", "") & "fkeyreassignid = '" & strID & "'"
            _selectedFilter = IIf(_selectedFilter.Length > 0, "WHERE " & _selectedFilter, "")
        Else
            '    'if there is no request selected or is in add mode
            _selectionFilter = IIf(_selectionFilter.Length > 0, "WHERE " & _selectionFilter, "")
            _selectedFilter = "WHERE 'SHOW' = 'NO'"       'DO NOT SHOW ANY CREWS IN THE SELECTED SECTION
        End If
        '------------------------------------------------------------------------------------------------------

        '-- CREATE SOURCE OF CREWLIST GRID
        cSQL = "SELECT		CAST(0 AS BIT) AS Existing, CAST(1 AS BIT) AS Edited, * FROM view_ReassignCrewAll " & _
               _selectionFilter & _
               "ORDER BY   CrewName"
        Me.CrewlistGrid.DataSource = DB.CreateTable(cSQL)
        CrewList.Columns("CrewName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '------------------------------------------------------------------------------------------------------

        '-- CREATE SOURCE OF SELECTED CREW GRID
        cSQL = "SELECT		CAST(1 AS BIT) AS Existing, CAST(0 AS BIT) AS Edited, * FROM view_ReassignCrewList " & _
               _selectedFilter & _
               "ORDER BY   CrewName"
        Me.CrewListSelectedGrid.DataSource = DB.CreateTable(cSQL)
        CrewListSelected.Columns("CrewName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        '------------------------------------------------------------------------------------------------------

    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblCrewReassign"
        MyBase.RefreshData()
        SetEditOptionsVisibility(Me.Name, True)
        SetHideCrewReassignmentRequestVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetViewRecordSumEnabled(Name, False)
        SetDeleteCaption(Name, "Delete Request")
        SetViewRecordSumEnabled(Name, False)
        Me.txtRequestedByName.Enabled = False

        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Crew Reassignment Request - " & strDesc)
        strRequiredFields = "txtDescription;txtDateRequested"

        BRECORDUPDATEDs = False

        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            AddData()

            SetHideCrewReassignmentRequestEnabled(Name, False)
        Else
            Me.txtDescription.Text = Trim(IfNull(blList.GetFocusedRowData("Description"), ""))
            Me.txtDateRequested.Text = Trim(Format(blList.GetFocusedRowData("DateRequested"), "dd-MMM-yyyy"))    'Trim(blList.GetFocusedRowData("DateRequested"))
            Me.txtRequestedByName.Text = Trim(blList.GetFocusedRowData("RequestedByName"))

            LoadSub()
            MakeReadOnlyListener(Me.LayoutControlGroup2)
            ByPassMakeReadOnlyListener(Me.LayoutControlGroup2)
            AllowDeletion(Name, True)
            'for SUB DATA
            AllowEditSubGrid(Me.CrewList, False, False)
            AllowEditSubGrid(Me.CrewListSelected, False)
            SetHideCrewReassignmentRequestEnabled(Name, True)
            BRECORDUPDATEDs = False
        End If
        Me.txtDescription.Focus()

    End Sub

    Sub ByPassMakeReadOnlyListener(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup)
        Try
            For o As Integer = 0 To cContainer.Items.Count - 1
                If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                    ctr.BackColor = System.Drawing.Color.White
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel, GetAppName)
        If res = MsgBoxResult.Yes Then
            If CrewListSelected.HasColumnErrors() Then
                flag = False
                ALLOWNEXTS = flag
            Else
                If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtDescription, txtDateRequested}) Then
                    If bAddMode Then
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
                    Else
                        flag = True
                        ALLOWNEXTS = flag
                        SaveData()
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

    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        SetHideCrewReassignmentRequestEnabled(Name, False)
        ClearFields(Me.LayoutControlGroup2, False)

        Me.txtDescription.Focus()
        Me.txtDescription.BackColor = SEL_COLOR
        blList.HideSelection()

        AllowEditing(Name, False) 'Dont Allow Edit Button
        AllowDeletion(Name, False)
        AllowEditSubGrid(Me.CrewList)
        AllowEditSubGrid(Me.CrewListSelected)

        bAddMode = True
        strID = ""
        strDesc = "New Record"

        Me.header.Text = strDesc
        Me.txtDescription.EditValue = ""
        Me.txtDateRequested.EditValue = DateTime.Now 'Nothing
        Me.txtRequestedByName.EditValue = USER_NAME.ToString
        Me.txtRequestedByName.Enabled = False
        RemoveReadOnlyListener(Me.LayoutControlGroup2)
        LoadSub()

        BRECORDUPDATEDs = False
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            txtDescription.Focus()
            SetHideCrewReassignmentRequestEnabled(Name, False)
            AllowDeletion(Name, False)
            RemoveReadOnlyListener(Me.LayoutControlGroup2)
            AllowAddition(Name, False)
            'Sub
            AllowEditSubGrid(Me.CrewList)
            AllowEditSubGrid(Me.CrewListSelected)
            Me.txtRequestedByName.Enabled = False
        Else
            txtDateRequested.Focus()
            SetHideCrewReassignmentRequestEnabled(Name, True)
            AllowDeletion(Name, True)
            MakeReadOnlyListener(Me.LayoutControlGroup2)
            AllowAddition(Name, True)
            'Sub
            AllowEditSubGrid(Me.CrewList, False, False)
            AllowEditSubGrid(Me.CrewListSelected, False)
            Me.txtRequestedByName.Enabled = False
        End If
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList, deletequery As New ArrayList, id As String = ""
        Dim type As String = "", info As Boolean = False
        Dim existingList As String = ""

        If Not CrewListSelected.HasColumnErrors() Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtDescription, txtDateRequested}) Then
                If isValidAllInSub() Then

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Request", 0, System.Environment.MachineName, "user [" & txtRequestedByName.EditValue.ToString.Replace("'", "''") & "] created a reassignment request: " & txtDescription.EditValue.ToString.Replace("'", "''"), FormName) 'tony20160719

                    If bAddMode Then
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "user [" & txtRequestedByName.EditValue.ToString.Replace("'", "''") & "] created a reassignment request: " & txtDescription.EditValue.ToString.Replace("'", "''"), FormName) 'tony20160719

                        info = DB.RunSql("INSERT INTO dbo.tblcrewreassign([Description], [DateRequested], [RequestedBy], [RequestedByName], [DateCreated], [LastUpdatedBy], [DateUpdated], [HideFromList]) " & _
                                         "VALUES ('" & txtDescription.EditValue & "', " & ChangeToSQLDate(txtDateRequested.EditValue) & ", " & IfNull(USER_ID, 0) & ", '" & txtRequestedByName.EditValue & "', getdate(), '" & LastUpdatedBy & "', getdate(), 0)")
                        BRECORDUPDATEDs = False
                        id = Trim(IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), ""))
                        type = "Inserted"

                    Else
                        id = strID
                        query.Add(GenerateUpdateScript(Me.LayoutControlGroup2, 3, Me.TableName, "LastUpdatedBy='" & Me.LastUpdatedBy & "', DateUpdated=(getdate()) ", "PKey='" & id & "'"))
                        BRECORDUPDATEDs = False
                        type = "Updated"
                    End If

                    'for sub table
                    With Me.CrewListSelected
                        .CloseEditForm()
                        .UpdateCurrentRow()
                        For i As Integer = 0 To .RowCount - 1
                            If .GetRowCellValue(i, "Existing") = True And .GetRowCellValue(i, "Edited") <> True Then

                                existingList = existingList & IIf(existingList.Length > 0, ", ", "") & "'" & .GetRowCellValue(i, "ReassignPKey") & "'"
                            ElseIf .GetRowCellValue(i, "Existing") = True And .GetRowCellValue(i, "Edited") = True Then
                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Update Request", 0, System.Environment.MachineName, "user [" & txtRequestedByName.EditValue.ToString.Replace("'", "''") & "] requested crew [" & .GetRowCellDisplayText(i, "CrewName").ToString.Replace("'", "''") & "] for reassignment.", FormName, .GetRowCellValue(i, "IDNbr")) 'tony20161013
                                query.Add("UPDATE dbo.tblcrewreassigncrews SET ReassignToAgent = '" & .GetRowCellValue(i, "ReassignToAgent") & "', ReassignToAgentName = '" & .GetRowCellDisplayText(i, "ReassignToAgent") & "', ReassignToVsl = '" & .GetRowCellValue(i, "ReassignToVsl") & "', ReassignToVslName = '" & .GetRowCellDisplayText(i, "ReassignToVsl") & "', Remarks = '" & .GetRowCellValue(i, "Remarks") & "', DateUpdated = getdate(), LastUpdatedBy = '" & Me.LastUpdatedBy & "' WHERE PKey = '" & .GetRowCellValue(i, "ReassignPKey") & "' AND FKeyReassignID = '" & strID & "'")
                                existingList = existingList & IIf(existingList.Length > 0, ", ", "") & "'" & .GetRowCellValue(i, "ReassignPKey") & "'"
                            ElseIf .GetRowCellValue(i, "Existing") <> True And .GetRowCellValue(i, "Edited") = True Then
                                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Create Request", 0, System.Environment.MachineName, "user [" & txtRequestedByName.EditValue.ToString.Replace("'", "''") & "] requested crew [" & .GetRowCellDisplayText(i, "CrewName").ToString.Replace("'", "''") & "] for reassignment.", FormName, .GetRowCellValue(i, "IDNbr")) 'tony20161013
                                query.Add("INSERT INTO dbo.tblCrewReassignCrews (FKeyReassignID, FKeyIDNbr, CrewName, ReassignToAgent, ReassignToAgentName, ReassignToVsl, ReassignToVslName, ActionCode, LastUpdatedBy, DateUpdated, Remarks) " & _
                                          "VALUES('" & id & "', '" & .GetRowCellValue(i, "IDNbr") & "', '" & .GetRowCellValue(i, "CrewName") & "', '" & .GetRowCellValue(i, "ReassignToAgent") & "', '" & .GetRowCellDisplayText(i, "ReassignToAgent") & "', '" & .GetRowCellValue(i, "ReassignToVsl") & "', '" & .GetRowCellDisplayText(i, "ReassignToVsl") & "', 0, '" & Me.LastUpdatedBy & "', getdate(), '" & .GetRowCellValue(i, "Remarks") & "')")
                            End If


                            query.Add("")
                        Next


                    End With
                    If existingList.Length > 0 Then
                        DB.RunSql("DELETE FROM dbo.tblcrewreassigncrews WHERE FKeyReassignID = '" & id & "' AND PKey NOT IN (" & existingList & ")")
                    End If
                    info = DB.RunSqls(query)
                    bAddMode = False
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    If info Then
                        blList.SetSelection(id)
                        RefreshData()
                        MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)

                    End If
                End If
            End If
        Else
            info = False
            MsgBox(GetMessage("Sub"), MsgBoxStyle.Critical, GetAppName)
        End If
    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = False
        If MsgBox("Are you sure want to delete the '" & strDesc & "'?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then
            If DB.isDeleteAllowed(Me.TableName, strID) Then 'Check if the record is in use or a system data

                clsAudit.propSQLConnStr = MPSDB.GetConnectionString
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Request", 0, System.Environment.MachineName, "Description : " & strDesc, FormName)
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil

                info = DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                If info Then
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
        Me.RefreshData()
    End Sub

    Private Function isValidAllInSub() As Boolean
        '## Description: Validates if all in sub grid are assigned with an Agent and Vessel
        Dim retval As Boolean = True

        With CrewListSelected

            For i As Integer = 0 To .RowCount - 1
                If IsDBNull(.GetRowCellValue(i, "ReassignToAgent")) = True Then
                    .GetDataRow(i).SetColumnError("ReassignToAgent", "Must select an Agent where the crew will be reassigned.")
                    AllowSaving(Name, False)
                    retval = False
                    Exit For
                ElseIf IsDBNull(.GetRowCellValue(i, "ReassignToVsl")) = True Then
                    .GetDataRow(i).SetColumnError("ReassignToVsl", "Must select a Vessel where the crew will be reassigned.")
                    AllowSaving(Name, False)
                    retval = False
                    Exit For
                End If
            Next

        End With

        Return retval
    End Function

    Private Sub ViewRecordSum()
        Try
            Select Case FOCUSED_VIEW
                Case FocusedViewCtrl.Selection
                    clsReassignCrew.ViewRecordSum(Trim(IfNull(CrewList.GetRowCellValue(CrewList.FocusedRowHandle, "IDNbr"), "")))
                Case FocusedViewCtrl.Selected
                    clsReassignCrew.ViewRecordSum(Trim(IfNull(CrewListSelected.GetRowCellValue(CrewListSelected.FocusedRowHandle, "IDNbr"), "")))
            End Select
        Catch ex As Exception
            MsgBox("Unable to open record summary. Please contact your system provider.", vbInformation)
        End Try
    End Sub

    Public Sub HideCrewReassignmentRequest()
        '## Description: Hides the Crew Reassignment Request from the list

        Dim dt As New DataTable
        If blList.GetID() <> "" Then    'checks if there is a selected request from the mainlist
            dt = MPSDB.CreateTable("SELECT * FROM dbo.tblcrewreassigncrews WHERE FKeyReassignID = '" & blList.GetID() & "' AND ActionCode = 0")
            If dt.Rows.Count > 0 Then
                MsgBox("Unable to hide. There are still pending crew reassignment(s) request.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("Do you want to continue hide the request """ & blList.GetDesc & """?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                If Not MPSDB.RunSql("UPDATE dbo.tblcrewreassign SET HideFromList = 1 WHERE PKey = '" & blList.GetID() & "'") Then
                    MsgBox("Hide request failed!", MsgBoxStyle.Exclamation)
                Else
                    blList.RefreshData()
                    Me.RefreshData()
                End If
            End If
        End If

    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        Select Case param(0)
            Case "ViewRecordSum"
                ViewRecordSum()
            Case "HideRequest"
                HideCrewReassignmentRequest()
        End Select
    End Sub

#End Region

#Region "Allow Edit Grid"
    Private Sub AllowDropGrid(ByRef gc As DevExpress.XtraGrid.GridControl, Optional ByVal Allow As Boolean = True)
        gc.AllowDrop = Allow
    End Sub

    Public Sub AllowEditSubGrid(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, Optional ByVal value As Boolean = True, Optional ByVal EnableGrid As Boolean = True)
        With view
            .CancelUpdateCurrentRow()
            If value Then
                .OptionsBehavior.ReadOnly = False
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                .GridControl.AllowDrop = True
            Else
                .OptionsBehavior.ReadOnly = True
                .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
            End If
        End With

        view.GridControl.Enabled = EnableGrid
        view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub
#End Region

#Region "DragAndDrop"

    Private Sub CrewList_GotFocus(sender As Object, e As System.EventArgs) Handles CrewList.GotFocus
        If CrewList.FocusedRowHandle >= 0 Then
            SetViewRecordSumEnabled(Name, True)
        Else
            SetViewRecordSumEnabled(Name, False)
        End If
        SetFocusedViewCtrl(FocusedViewCtrl.Selection)
    End Sub

    Private Sub CrewList_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewList.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left AndAlso hitInfo.RowHandle >= 0 Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub CrewList_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewList.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If (Not dragRect.Contains(New Point(e.X, e.Y))) Then
                Dim row As DataRow = view.GetDataRow(downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub CrewlistGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewlistGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = TryCast(grid.DataSource, DataTable)
        Dim row As DataRow = TryCast(e.Data.GetData(GetType(DataRow)), DataRow)
        Dim RowHandler As Integer = CrewListSelected.FocusedRowHandle
        If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
            table.ImportRow(row)
            row.Delete()
            Try
                CrewListSelected.FocusedRowHandle = RowHandler
            Catch ex As Exception
                'go to the very end
                CrewListSelected.FocusedRowHandle = CrewListSelected.RowCount - 1
            End Try
        End If
    End Sub

    Private Sub CrewlistGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewlistGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub CrewListSelectedGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewListSelectedGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        Dim RowHandler As Integer = CrewList.FocusedRowHandle
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            BRECORDUPDATEDs = True
            table.ImportRow(row)
            row.Delete()
            AllowSaving(Name, False)
            Try
                CrewList.FocusedRowHandle = RowHandler
            Catch ex As Exception
                'go to the very end
                CrewList.FocusedRowHandle = CrewList.RowCount - 1
            End Try
        End If
    End Sub

    Private Sub CrewListSelectedGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles CrewListSelectedGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub CrewListSelected_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CrewListSelected.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.CrewListSelected
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub CrewListSelected_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CrewListSelected.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CrewListSelected_GotFocus(sender As Object, e As System.EventArgs) Handles CrewListSelected.GotFocus
        If CrewListSelected.FocusedRowHandle >= 0 Then
            SetViewRecordSumEnabled(Name, True)
        Else
            SetViewRecordSumEnabled(Name, False)
        End If
        SetFocusedViewCtrl(FocusedViewCtrl.Selected)
    End Sub

    Private Sub CrewListSelected_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CrewListSelected.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        SubAddMode = True
    End Sub

    Private Sub CrewListSelected_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CrewListSelected.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub CrewListSelected_LostFocus(sender As Object, e As System.EventArgs) Handles CrewListSelected.LostFocus
        SetViewRecordSumEnabled(Name, False)
        SetFocusedViewCtrl(FocusedViewCtrl.Selected)
    End Sub

    Private Sub CrewListSelected_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListSelected.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not Control.ModifierKeys = Keys.None Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub CrewListSelected_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewListSelected.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not downHitInfo Is Nothing Then
            Dim dragSize = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                Dim row As DataRow = view.GetDataRow(downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

#End Region

#Region "Grid Events"

    Private Sub CrewListSelected_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewListSelected.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If e.Column.FieldName = "ActionCode" Or e.Column.FieldName = "ActionAppliedBy" Then
            Dim nStatus As Integer = CInt(IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("ActionCode")), 0))
            If CrewListSelected.OptionsBehavior.ReadOnly Then
                clsReassignCrew.changeCrewReassignmentStatusColor(nStatus, e)
            Else
                e.Appearance.BackColor = DISABLED_COLOR
            End If
        Else
            If CrewListSelected.OptionsBehavior.ReadOnly Then
                clsReassignCrew.changeCrewReassignmentStatusColor(-1, e)
            Else
                e.Appearance.BackColor = REQUIRED_COLOR
            End If
        End If

    End Sub

    Private Sub CrewListSelected_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CrewListSelected.ValidateRow
        Dim view As Views.Grid.GridView = CType(sender, Views.Grid.GridView)
        Dim col As DevExpress.XtraGrid.Columns.GridColumn

        With view

            '-- Validate ReassignToAgent
            col = view.Columns("ReassignToAgent")
            If .GetRowCellValue(e.RowHandle, col) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, col) Is Nothing Then
                .SetColumnError(col, "Must select an Agent where the crew will be reassigned.")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(col, "")
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------

            '-- Validate ReassignToAgent
            col = view.Columns("ReassignToVsl")
            If .GetRowCellValue(e.RowHandle, col) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, col) Is Nothing Then
                .SetColumnError(col, "Must select a Vessel where the crew will be reassigned..")
                AllowSaving(Name, False)
                e.Valid = False
            Else
                .SetColumnError(col, "")
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------

            '-- Allow Saving If There Are No Errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                AllowSaving(Name, True)
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------
        End With

    End Sub

    Private Sub Crewlist_LostFocus(sender As Object, e As System.EventArgs) Handles CrewList.LostFocus
        SetViewRecordSumEnabled(Name, False)
        SetFocusedViewCtrl(FocusedViewCtrl.None)
    End Sub

    Private Sub SetFocusedViewCtrl(ByVal n As FocusedViewCtrl)
        '## Description: Assigns the focused sub grid control to the monitoring variable 
        FOCUSED_VIEW = n
    End Sub

#End Region

    
End Class
