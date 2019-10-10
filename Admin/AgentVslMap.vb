Public Class AgentVslMap


#Region "Easy Edit"
    Private FormName As String = "Admin Agent-Vessel Mapping"
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil


    Enum SelectDeselectAll
        SelectAll = 1
        DeselectAll = 2
    End Enum

    'LASTUPDATED BY FORMAT
    'getusername() & <Description><FormName>
    ' Private LastUpdatedBy As String = GetUserName() & "<" & FormName & ">"
#End Region

    Private Sub initControls()

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil

        Me.LayoutControl1.AllowCustomization = False
        Dim dt As New DataTable

        'Repository ITEMS
        'dt = createFilteredData("SELECT PKey, Name FROM dbo.tbladmvsl WHERE pkey IN (SELECT FKeyVsl FROM sec_filtermap WHERE FKeyAgent = '" & strID & "') GROUP BY PKey, Name", FilteredDataObjectType.SQL, "Name")
        'repVsl.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.VesselAll)
        'repVsl_Selection.DataSource = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmvsl WHERE pkey NOT IN (SELECT FKeyVsl FROM sec_filtermap WHERE FKeyAgent = '" & strID & "') GROUP BY PKey, Name ORDER BY Name")
        'repVsl_Selected.DataSource = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmvsl WHERE pkey IN (SELECT FKeyVsl FROM sec_filtermap WHERE FKeyAgent = '" & strID & "') GROUP BY PKey, Name ORDER BY Name")
        dt = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmvsl ORDER BY Name")
        repVsl_Selection.DataSource = dt
        repVsl_Selected.DataSource = dt

        'dt = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Principal)
        dt = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmcompany WHERE isPrincipal <> 0 ORDER BY Name")
        repPrin_Selection.DataSource = dt
        repPrin_Selected.DataSource = dt

        'dt = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Fleet)
        dt = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tbladmflt ORDER BY Name")
        repFlt_Selection.DataSource = dt
        repFlt_Selected.DataSource = dt

        SelectionGrid.ForceInitialize()
        Me.SelectionView.OptionsView.ColumnAutoWidth = True
        SetGridLayout(Me.SelectionView)

        SelectedGrid.ForceInitialize()
        Me.SelectedView.OptionsView.ColumnAutoWidth = True
        SetGridLayout(Me.SelectedView)
    End Sub

    Private Sub LoadSub()
        SelectionGrid.DataSource = MPSDB.CreateTable("SELECT PKey as FKeyVsl, FKeyPrincipal as FKeyPrin, FKeyFlt FROM dbo.tbladmvsl WHERE pkey NOT IN (SELECT FKeyVsl FROM sec_filtermap WHERE FKeyAgent = '" & strID & "')")
        SelectedGrid.DataSource = MPSDB.CreateTable("SELECT PKey as FKeyVsl, FKeyPrincipal as FKeyPrin, FKeyFlt FROM dbo.tbladmvsl WHERE pkey IN (SELECT FKeyVsl FROM sec_filtermap WHERE FKeyAgent = '" & strID & "')")
    End Sub

    'Refresh Data
    Public Overrides Sub RefreshData()
        TableName = "MSystblAdmAgentVsl_map"
        MyBase.RefreshData()
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

        BRECORDUPDATEDs = False

        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Agent-Vessel Mapping - " & strDesc)
        If Not bLoaded Then
            initControls()
            LoadSub()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            MsgBox("Unable to initialize content because there is no agent selected.", vbInformation)
            Exit Sub
        Else
            Me.txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            'for SUB DATA
            EditSubAllowGrid(Me.SelectionView, False)
            EditSubAllowGrid(Me.SelectedView, False)
            EnableSubControls(False)
            BRECORDUPDATEDs = False
        End If
        AddEditListener(Me.LayoutControl1.Root)
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable Then
            txtName.Focus()
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            EnableSubControls()
        Else
            txtName.Focus()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            EnableSubControls(False)
        End If
    End Sub

    Public Overrides Sub AddData()
        'MyBase.AddData()
    End Sub

    Sub EnableSubControls(Optional ByVal isEnable As Boolean = True)
        SelectedView.OptionsBehavior.ReadOnly = Not isEnable
        SelectionView.OptionsBehavior.ReadOnly = Not isEnable
        SelectionGrid.AllowDrop = isEnable
        SelectedGrid.AllowDrop = isEnable
        btnAssignAll.Enabled = isEnable
        btnRemoveAll.Enabled = isEnable
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            flag = True
            ALLOWNEXTS = flag
            SaveData()
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    'Save
    Public Overrides Sub SaveData()
        Me.header.Focus()
        blList.HideSelection()
        Dim query As New ArrayList ', id As String
        Dim type As String = "", info As Boolean = False



        type = "Updated"
        With Me.SelectedView
            .CloseEditForm()
            .UpdateCurrentRow()
            clsAudit.saveAuditPreDelDetails("MSystblAdmAgentVsl_map", strID, LastUpdatedBy) 'neil
            query.Add("DELETE FROM dbo.MSystblAdmAgentVsl_map WHERE FKeyAgent = '" & strID & "'")
            For i As Integer = 0 To .RowCount - 1
                .UpdateCurrentRow()
                BRECORDUPDATEDs = False
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, .GetRowCellValue(i, "FKeyVsl"), FormName) 'neil
                query.Add("INSERT INTO dbo.MSystblAdmAgentVsl_map (FKeyAgent, FKeyVsl, DateUpdated, LastUpdatedBy) VALUES('" & strID & "', '" & .GetRowCellValue(i, "FKeyVsl") & "', getdate(), '" & LastUpdatedBy & "')")

            Next
        End With
        info = DB.RunSqls(query)
        BRECORDUPDATEDs = False
        blList.RefreshData()
        If info Then
            blList.SetSelection(strID)
            RefreshData()
            MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)

        End If
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Sub execSelectDeselectAll(nMode As SelectDeselectAll)
        '### Description: Select/Deselect All selection
        Dim gridSource As DevExpress.XtraGrid.GridControl

        Dim viewSource As DevExpress.XtraGrid.Views.Grid.GridView
        Dim viewDest As DevExpress.XtraGrid.Views.Grid.GridView

        Dim destTable As DataTable
        Dim sourceTable As DataTable

        Select Case nMode
            Case SelectDeselectAll.SelectAll
                viewSource = CType(SelectionView, DevExpress.XtraGrid.Views.Grid.GridView)
                viewDest = CType(SelectedView, DevExpress.XtraGrid.Views.Grid.GridView)

                gridSource = CType(SelectionGrid, DevExpress.XtraGrid.GridControl)

                sourceTable = CType(SelectionGrid.DataSource, DataTable)
                destTable = CType(SelectedGrid.DataSource, DataTable)
            Case SelectDeselectAll.DeselectAll
                viewSource = CType(SelectedView, DevExpress.XtraGrid.Views.Grid.GridView)
                viewDest = CType(SelectionView, DevExpress.XtraGrid.Views.Grid.GridView)

                gridSource = CType(SelectedGrid, DevExpress.XtraGrid.GridControl)

                sourceTable = CType(SelectedGrid.DataSource, DataTable)
                destTable = CType(SelectionGrid.DataSource, DataTable)
            Case Else
                Exit Sub

        End Select

        For i As Integer = 0 To viewSource.DataRowCount - 1
            Dim row As DataRow = CType(viewSource.GetDataRow(i), DataRow)
            destTable.ImportRow(row)
        Next
        sourceTable.Rows.Clear()
        gridSource.DataSource = sourceTable

    End Sub

#Region "DragAndDrop"

    Private Sub SelectionView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles SelectionView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub SelectionView_DoubleClick(sender As Object, e As System.EventArgs) Handles SelectionView.DoubleClick
        Dim table As DataTable = TryCast(SelectedGrid.DataSource, DataTable)
        Dim row As DataRow = TryCast(SelectionView.GetDataRow(SelectionView.FocusedRowHandle), DataRow)
        Dim RowHandler As Integer = SelectionView.FocusedRowHandle
        If isEditdable Then
            If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
                table.ImportRow(row)
                row.Delete()
                Try
                    SelectionView.FocusedRowHandle = RowHandler
                Catch ex As Exception
                    'go to the very end
                    SelectionView.FocusedRowHandle = SelectionView.RowCount - 1
                End Try
            End If
        End If

    End Sub
    Private Sub SelectionView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SelectionView.MouseDown
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

    Private Sub SelectionView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SelectionView.MouseMove
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

    Private Sub SelectionGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles SelectionGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = TryCast(grid.DataSource, DataTable)
        Dim row As DataRow = TryCast(e.Data.GetData(GetType(DataRow)), DataRow)
        Dim RowHandler As Integer = SelectedView.FocusedRowHandle
        If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
            BRECORDUPDATEDs = True
            table.ImportRow(row)
            row.Delete()
            Try
                SelectedView.FocusedRowHandle = RowHandler
            Catch ex As Exception
                'go to the very end
                SelectedView.FocusedRowHandle = SelectedView.RowCount - 1
            End Try
        End If
    End Sub

    Private Sub SelectionGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles SelectionGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub SelectedGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles SelectedGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        Dim RowHandler As Integer = SelectionView.FocusedRowHandle
        'Dim nrow As DataRow = row.Table
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            BRECORDUPDATEDs = True
            table.ImportRow(row)
            row.Delete()
            Try
                SelectionView.FocusedRowHandle = RowHandler
            Catch ex As Exception
                'go to the very end
                SelectionView.FocusedRowHandle = SelectionView.RowCount - 1
            End Try
        End If
    End Sub

    Private Sub GridSelected_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles SelectedGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub SelectedView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles SelectedView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub SelectedView_DoubleClick(sender As Object, e As System.EventArgs) Handles SelectedView.DoubleClick
        Dim table As DataTable = TryCast(SelectionGrid.DataSource, DataTable)
        Dim row As DataRow = TryCast(SelectedView.GetDataRow(SelectedView.FocusedRowHandle), DataRow)
        Dim RowHandler As Integer = SelectedView.FocusedRowHandle
        If isEditdable Then
            If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
                table.ImportRow(row)
                row.Delete()
                Try
                    SelectedView.FocusedRowHandle = RowHandler
                Catch ex As Exception
                    'go to the very end
                    SelectedView.FocusedRowHandle = SelectedView.RowCount - 1
                End Try
            End If
        End If

    End Sub

    Private Sub SelectedView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SelectedView.MouseDown
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

    Private Sub SelectedView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SelectedView.MouseMove
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

    Private Sub btnAssignAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAssignAll.Click
        execSelectDeselectAll(SelectDeselectAll.SelectAll)
        BRECORDUPDATEDs = True
    End Sub

    Private Sub btnRemoveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveAll.Click
        execSelectDeselectAll(SelectDeselectAll.DeselectAll)
        BRECORDUPDATEDs = True
    End Sub

    Private Sub repVsl_Selection_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repVsl_Selection.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repPrin_Selection_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repPrin_Selection.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repFlt_Selection_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFlt_Selection.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repVsl_Selected_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repVsl_Selected.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repPrin_Selected_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repPrin_Selected.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repFlt_Selected_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repFlt_Selected.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub
End Class
