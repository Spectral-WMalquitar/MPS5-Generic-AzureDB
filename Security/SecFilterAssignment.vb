Imports System.Windows.Forms
Imports System.Drawing

Public Class SecFilterAssignment
    Dim clsSec As New clsSecurity
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Dim FormName As String = "User Filter Assignment"
    Dim LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim isFeatureEnabled As Boolean = True

    Enum FilterType As Integer
        None = 0
        ByAgent = 1
        ByPrincipal = 2
        ByFleet = 3
    End Enum

    Enum SelectDeselectAll
        SelectAll = 1
        DeselectAll = 2
    End Enum


#Region "Date Sources"
    Private Function GetSrcFilterType() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)

        Dim crow() As Object

        'None
        crow = {CInt(FilterType.None), "None"}
        ctable.Rows.Add(crow)

        'By Agent
        crow = {CInt(FilterType.ByAgent), "By Agent"}
        ctable.Rows.Add(crow)

        'By Principal
        crow = {CInt(FilterType.ByPrincipal), "By Principal"}
        ctable.Rows.Add(crow)

        'By Fleet
        crow = {CInt(FilterType.ByFleet), "By Fleet"}
        ctable.Rows.Add(crow)

        Return ctable
    End Function
#End Region

    'Refresh Data
    Public Overrides Sub RefreshData()
        TableName = "MSysSec_Users"
        MyBase.RefreshData()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        strRequiredFields = "txtUserName"
        If Not bLoaded Then
            initControls()
            bLoaded = True
        End If

        If blList.GetID() = "" Then
            'commented out by tony20190812
            'moved to bottom line
            'MsgBox("There are no users available right now.", MsgBoxStyle.Information, "Filter Assignment Not Available")
            isFeatureEnabled = False
        Else
            LoadSub()
            BRECORDUPDATEDs = False
        End If

        AddEditListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup1, lcgAssignment, LayoutControlGroup3, LayoutControlGroup_Assigned, LayoutControlGroup_Available})
        ''for SUB DATA
        MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup1, lcgAssignment, LayoutControlGroup3, LayoutControlGroup_Assigned, LayoutControlGroup_Available})
        EnableSubControls(False)

        '<!-- added by tony20190812
        If isFeatureEnabled Then
            lcgAssignment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            lciFeatureDisabled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            lcgAssignment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            lciFeatureDisabled.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            MsgBox("There are no users available right now.", MsgBoxStyle.Information, "Filter Assignment Not Available")
        End If
        'end tony -->

    End Sub

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False

        cboFilterType.Properties.DataSource = GetSrcFilterType()
        cboFilterType.RefreshEditValue()
    End Sub

    Sub EnableSubControls(Optional ByVal isEnable As Boolean = True)
        GVAssigned.OptionsBehavior.ReadOnly = Not isEnable
        GVAvailable.OptionsBehavior.ReadOnly = Not isEnable
        GridAssigned.AllowDrop = isEnable
        GridAvailable.AllowDrop = isEnable
        btnAssignAll.Enabled = isEnable
        btnRemoveAll.Enabled = isEnable
    End Sub

    Private Sub LoadSub()
        Me.LayoutControl1.AllowCustomization = False

        Me.txtUserName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
        Me.cboFilterType.EditValue = Trim(IfNull(blList.GetFocusedRowData("FilterType"), ""))
        RefreshAssignedPermObjs()
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
                viewSource = CType(GVAvailable, DevExpress.XtraGrid.Views.Grid.GridView)
                viewDest = CType(GVAssigned, DevExpress.XtraGrid.Views.Grid.GridView)

                gridSource = CType(GridAvailable, DevExpress.XtraGrid.GridControl)

                sourceTable = CType(GridAvailable.DataSource, DataTable)
                destTable = CType(GridAssigned.DataSource, DataTable)
            Case SelectDeselectAll.DeselectAll
                viewSource = CType(GVAssigned, DevExpress.XtraGrid.Views.Grid.GridView)
                viewDest = CType(GVAvailable, DevExpress.XtraGrid.Views.Grid.GridView)

                gridSource = CType(GridAssigned, DevExpress.XtraGrid.GridControl)

                sourceTable = CType(GridAssigned.DataSource, DataTable)
                destTable = CType(GridAvailable.DataSource, DataTable)
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

#Region "Permission-Related Functions/Procedures"
    Public Function GetAssignedPermObjsItem(ByVal ItemName As String, ByVal UserID As Integer) As VariantType
        Dim RetVal As VariantType

        RetVal = VariantType.Null
        Try
            With DB
                .BeginReader("SELECT " & ItemName & " FROM dbo.MSysSec_Users where ID = " & UserID)
                .Read()
                If .ReaderItemCount > 0 Then
                    If .ReaderItem(ItemName).ToString.Length > 0 Then
                        RetVal = .ReaderItem(ItemName)
                    End If
                End If
            End With
            DB.CloseReader()
        Catch ex As Exception
            DB.CloseReader()
        End Try


        Return RetVal
    End Function

    Private Sub RefreshAssignedPermObjs()
        Dim SQLAvailable As String = ""
        Dim SQLAssigned As String = ""
        Dim cWhereList As String = ""


        LayoutControlGroup_Available.Text = "Available"
        LayoutControlGroup_Assigned.Text = "Assigned"
        GridAvailable.DataSource = ""
        GridAssigned.DataSource = ""

        '### Get Filter Type assigned to selected user
        Dim nFilterType As Integer = Trim(IfNull(Me.cboFilterType.EditValue, 0))

        '### Populate Grid Based on User-assigned Filter Codes
        Try
            Dim cLabel As String = ""
            Select Case nFilterType
                Case FilterType.ByAgent
                    cLabel = "Agent"
                    SQLAssigned = "SELECT PKey, Name FROM dbo.tblAdmCompany WHERE isManAgent <> 0 AND PKey IN (SELECT FilterValue FROM dbo.MSysSec_Users_FilterAssignment WHERE FilterType = " & IfNull(nFilterType, 0) & " AND UserID = " & IfNull(strID, 0) & ");"
                    SQLAvailable = "SELECT PKey, Name FROM dbo.tblAdmCompany WHERE isManAgent <> 0 AND PKey NOT IN (SELECT FilterValue FROM dbo.MSysSec_Users_FilterAssignment WHERE FilterType = " & IfNull(nFilterType, 0) & " AND UserID = " & IfNull(strID, 0) & ");"
                Case FilterType.ByPrincipal
                    cLabel = "Principal"
                    SQLAssigned = "SELECT PKey, Name FROM dbo.tblAdmCompany WHERE isPrincipal <> 0 AND PKey IN (SELECT FilterValue FROM dbo.MSysSec_Users_FilterAssignment WHERE FilterType = " & IfNull(nFilterType, 0) & " AND UserID = " & IfNull(strID, 0) & ");"
                    SQLAvailable = "SELECT PKey, Name FROM dbo.tblAdmCompany WHERE isPrincipal <> 0 AND PKey NOT IN (SELECT FilterValue FROM dbo.MSysSec_Users_FilterAssignment WHERE FilterType = " & IfNull(nFilterType, 0) & " AND UserID = " & IfNull(strID, 0) & ");"
                Case FilterType.ByFleet
                    cLabel = "Fleet"
                    SQLAssigned = "SELECT PKey, Name FROM dbo.tbladmflt WHERE PKey IN (SELECT FilterValue FROM dbo.MSysSec_Users_FilterAssignment WHERE FilterType = " & IfNull(nFilterType, 0) & " AND UserID = " & IfNull(strID, 0) & ");"
                    SQLAvailable = "SELECT PKey, Name FROM dbo.tbladmflt WHERE PKey NOT IN (SELECT FilterValue FROM dbo.MSysSec_Users_FilterAssignment WHERE FilterType = " & IfNull(nFilterType, 0) & " AND UserID = " & IfNull(strID, 0) & ");"
                Case Else
                    Exit Sub
            End Select

            Dim dt As DataTable
            dt = DB.CreateTable(SQLAvailable)
            GridAvailable.DataSource = dt
            GVAvailable.Columns("Name").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            dt = DB.CreateTable(SQLAssigned)
            GridAssigned.DataSource = dt
            GVAssigned.Columns("Name").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

            LayoutControlGroup_Available.Text = "Available " & cLabel & "(s)"
            LayoutControlGroup_Assigned.Text = "Assigned " & cLabel & "(s)"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Add, Edit, Save"
    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        'isEditing = True
        If isEditdable Then
            'txtUserName.Focus()
            cboFilterType.Focus()
            RemoveReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup1, lcgAssignment, LayoutControlGroup3, LayoutControlGroup_Assigned, LayoutControlGroup_Available})
            EnableSubControls()
        Else
            txtUserName.Focus()
            MakeReadOnlyListener(New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControlGroup1, lcgAssignment, LayoutControlGroup3, LayoutControlGroup_Assigned, LayoutControlGroup_Available})
            EnableSubControls(False)
        End If
        BRECORDUPDATEDs = False
    End Sub

    'Save
    Public Overrides Sub SaveData()
        Dim query As New ArrayList
        Dim info As Boolean = False
        Dim id As String = "", type As String = ""
        Dim FilterValueList As New System.Text.StringBuilder
        Dim DeleteConditionList As New System.Text.StringBuilder
        Dim cTmp As String
        Dim cPKey As String

        Me.header.Focus()
        blList.HideSelection()

        Dim nFilterType As Integer = Trim(IfNull(Me.cboFilterType.EditValue, 0))

        ShowCustomLoadScreen(GetType(WaitForm1))
        Application.DoEvents()

        query.Add("UPDATE dbo.MSysSec_Users SET FilterType = " & nFilterType & _
                  " WHERE ID = " & strID & ";")

        If nFilterType = 1 Or nFilterType = 2 Or nFilterType = 3 Then

            With GVAssigned

                For i As Integer = 0 To .RowCount - 1
                    cPKey = .GetRowCellValue(i, "PKey")
                    cTmp = IIf(DeleteConditionList.Length > 0, " AND ", "") & _
                           "FilterValue <> '" & cPKey & "'"
                    DeleteConditionList.Append(cTmp)

                    query.Add("INSERT INTO dbo.MSysSec_Users_FilterAssignment(UserID, FilterType, FilterValue) " & _
                              "SELECT       " & strID & " UserID, " & _
                              "             " & nFilterType & " FilterType, " & _
                              "             '" & cPKey & "' FilterValue " & _
                              "WHERE        (SELECT Count(*) FROM dbo.MSysSec_Users_FilterAssignment WHERE UserID = " & strID & " AND FilterType = " & nFilterType & " AND FilterValue = '" & cPKey & "') = 0 ")
                Next
            End With

        End If

        '<!--added by tony20180922 : Log Deletion
        oLogDeletionSec.Init(DB.GetConnectionString())

        oLogDeletionSec.CreateLogEntry(LogDeletion.CallingApp.Crewing,
            FormName, _
            "Admin", _
            "MSysSec_Users_FilterAssignment", _
            "UserID = " & strID & " AND FilterType = " & nFilterType & IIf(DeleteConditionList.Length > 0, " AND (" & DeleteConditionList.ToString & ")", ""), _
            "<< Delete Security Data - " & FormName & " >>", _
            LogDeletion.DeletionType.Manual, _
            "Manually Security in <" & FormName & ">", _
            GetUserName())
        '-->
        query.Add("DELETE FROM dbo.MSysSec_Users_FilterAssignment WHERE UserID = " & strID & " AND FilterType = " & nFilterType & IIf(DeleteConditionList.Length > 0, " AND (" & DeleteConditionList.ToString & ")", ""))

        'Dim nFilterType As Integer = Trim(IfNull(Me.cboFilterType.EditValue, 0))
        'Dim FieldToUpdate As String
        'Select Case nFilterType
        '    Case FilterType.ByAgent
        '        FieldToUpdate = "FilterFKeyAgent"
        '    Case FilterType.ByPrincipal
        '        FieldToUpdate = "FilterFKeyPrin"
        '    Case FilterType.ByFleet
        '        FieldToUpdate = "FilterFKeyFlt"
        '    Case Else
        '        Exit Sub
        'End Select

        'info = DB.RunSql("UPDATE dbo.MSysSec_Users SET FilterType = " & Trim(IfNull(cboFilterType.EditValue, 0)) & _
        '                 IIf(IfNull(FieldToUpdate, "").ToString.Length > 0, ", " & FieldToUpdate & " = '" & FilterValueList.ToString & "'", "") & _
        '                 " WHERE ID = " & strID & ";")

        info = DB.RunSqls(query)
        type = "Updated"
        BRECORDUPDATEDs = False
        blList.RefreshData()

        CloseCustomLoadScreen()

        If info Then
            oLogDeletionSec.AddLogEntryToDatabase()
            blList.SetSelection(id)
            RefreshData()
            MsgBox(GetMessage(type, info), MsgBoxStyle.Information, GetAppName)

        End If
    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        RemoveReadOnlyListener(Me.LayoutControl1.Root)
        If Not bAddMode Then
            ClearFields(Me.LayoutControl1.Root, False)
            AllowEditing(Name, False) 'Allow Edit Button
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.txtUserName.Focus()
            Me.txtUserName.BackColor = SEL_COLOR

            BRECORDUPDATEDs = False
        End If
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

#End Region

    Private Sub cboFilterType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFilterType.EditValueChanged
        RefreshAssignedPermObjs()
    End Sub

    Private Sub GVAvailable_DoubleClick(sender As System.Object, e As System.EventArgs) Handles GVAvailable.DoubleClick
        Dim osender As DevExpress.XtraGrid.Views.Grid.GridView
        osender = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If osender.FocusedRowHandle >= 0 Then
            Dim p As Point = osender.GridControl.PointToClient(Control.MousePosition)
            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).CalcHitInfo(p)
            If hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Row OrElse hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                Dim table As DataTable = TryCast(GridAssigned.DataSource, DataTable)
                Dim row As DataRow = TryCast(GVAvailable.GetDataRow(GVAvailable.FocusedRowHandle), DataRow)
                Dim RowHandler As Integer = GVAvailable.FocusedRowHandle
                If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table And Not GVAvailable.OptionsBehavior.ReadOnly Then
                    table.ImportRow(row)
                    row.Delete()
                    Try
                        GVAvailable.FocusedRowHandle = RowHandler
                    Catch ex As Exception
                        'go to the very end
                        GVAvailable.FocusedRowHandle = GVAvailable.RowCount - 1
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub GVAssigned_DoubleClick(sender As Object, e As System.EventArgs) Handles GVAssigned.DoubleClick
        Dim osender As DevExpress.XtraGrid.Views.Grid.GridView
        osender = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If osender.FocusedRowHandle >= 0 Then
            Dim p As Point = osender.GridControl.PointToClient(Control.MousePosition)
            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).CalcHitInfo(p)
            If hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Row OrElse hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
                Dim table As DataTable = TryCast(GridAvailable.DataSource, DataTable)
                Dim row As DataRow = TryCast(GVAssigned.GetDataRow(GVAssigned.FocusedRowHandle), DataRow)
                Dim RowHandler As Integer = GVAssigned.FocusedRowHandle
                If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table And Not GVAssigned.OptionsBehavior.ReadOnly Then
                    table.ImportRow(row)
                    row.Delete()
                    Try
                        GVAssigned.FocusedRowHandle = RowHandler
                    Catch ex As Exception
                        'go to the very end
                        GVAssigned.FocusedRowHandle = GVAssigned.RowCount - 1
                    End Try
                End If
            End If

        End If
    End Sub
#Region "Drag and Drop"
    Private Sub GVAvailable_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GVAvailable.MouseDown
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

    Private Sub GVAvailable_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GVAvailable.MouseMove
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

    Private Sub GridAvailable_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridAvailable.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = TryCast(grid.DataSource, DataTable)
        Dim row As DataRow = TryCast(e.Data.GetData(GetType(DataRow)), DataRow)
        Dim RowHandler As Integer = GVAssigned.FocusedRowHandle
        If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table IsNot table Then
            table.ImportRow(row)
            row.Delete()
            Try
                GVAssigned.FocusedRowHandle = RowHandler
            Catch ex As Exception
                'go to the very end
                GVAssigned.FocusedRowHandle = GVAssigned.RowCount - 1
            End Try
        End If
    End Sub

    Private Sub GridAvailable_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridAvailable.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) And Not GVAvailable.OptionsBehavior.ReadOnly Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub GridAssigned_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridAssigned.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        Dim RowHandler As Integer = GVAvailable.FocusedRowHandle
        'Dim nrow As DataRow = row.Table
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            table.ImportRow(row)
            row.Delete()
            Try
                GVAvailable.FocusedRowHandle = RowHandler
            Catch ex As Exception
                'go to the very end
                GVAvailable.FocusedRowHandle = GVAvailable.RowCount - 1
            End Try
        End If
    End Sub

    Private Sub GridAssigned_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridAssigned.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) And Not GVAssigned.OptionsBehavior.ReadOnly Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub GVAssigned_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GVAssigned.MouseDown
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

    Private Sub GVAssigned_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GVAssigned.MouseMove
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

    Private Sub btnAssignAll_Click(sender As Object, e As System.EventArgs) Handles btnAssignAll.Click
        execSelectDeselectAll(SelectDeselectAll.SelectAll)
        BRECORDUPDATEDs = True
    End Sub

    Private Sub btnRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnRemoveAll.Click
        execSelectDeselectAll(SelectDeselectAll.DeselectAll)
        BRECORDUPDATEDs = True
    End Sub
End Class
