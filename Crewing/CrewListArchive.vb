Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraScheduler
Imports System.Linq

Public Class CrewListArchive

    Dim downHitInfo As GridHitInfo
    Dim dt As New DataTable
    Dim allow As Boolean = True
    Public Shared SelectedGroupID As String
    Public Shared CrewCurrentRank As String
    Public Shared selectedCrewForArchive As Integer = 0
    Dim isActivated As Boolean = False
    Dim selectedCrewID As String = ""
    Dim GridCheckMarksSelection As MPS5.DevExpress.XtraGrid.Selection.GridCheckMarksSelection

    Public Overrides Sub HideSelection()
        bAddMode = True
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles MainView.BeforeLeaveRow
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If Not bDraggable Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                If Not bRecordDeleted Then
                    AllowN = bContent.CheckValidateFields()
                    If AllowN Then
                        e.Allow = True
                    Else
                        If ALLOWNEXTS Then
                            e.Allow = True
                        Else
                            e.Allow = False
                        End If
                    End If
                Else
                    e.Allow = True
                End If
            Else
                e.Allow = True
            End If
        End If
    End Sub

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainView.Click
        bAddMode = False
        SelectionChange(Name)
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.FocusedRowHandle >= 0 Then
            SelectionChange(Name)
            SelectedGroupID = MainView.GetRowCellValue(e.FocusedRowHandle, "ActGrpID").ToString()
            CrewCurrentRank = MainView.GetRowCellValue(e.FocusedRowHandle, "FKeyRankCode").ToString()
        End If
        'MsgBox("Before: " & selectedID)
        'selectedID = MainView.GetFocusedRowCellValue("IDNbr")
        'MsgBox("After: " & selectedID)
    End Sub

    Public Overrides Sub RefreshData()
        Dim expDocDays As Integer
        If GetUserSetting("DocExpDays") <> "" Then expDocDays = Val(GetUserSetting("DocExpDays")) Else expDocDays = 0
        initControl()
        SetGridLayout(Me.MainView)
        Me.MainGrid.ForceInitialize()
        bDisableSelectionEvent = True
        Dim userdatafilter As String = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        bListSelect = "EXEC [SP_Crewlist_Activities] @ExpDocDays = " & expDocDays & ", @userdatafilterstring = '" & Replace(userdatafilter, "'", "''") & "'"
        dt = getCrewListDataTable(bListSelect, USER_INFO.RefreshMode)
        Me.MainGrid.DataSource = dt
        SetSelection(selectedID)
        bDisableSelectionEvent = False
        ActivateArchive()

    End Sub

    Private Sub MainViewn_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        'If e.RowHandle = MainView.FocusedRowHandle And Not bAddMode Then
        '    e.Appearance.BackColor = SEL_COLOR
        'End If
        ViewRowCellStyle(sender, e)
    End Sub

    Private Sub GetVslCode()
        Dim VslCode As String = ""
        If MainView.RowCount > 0 Then
            VslCode = MainView.GetRowCellValue(MainView.FocusedRowHandle, "VslName")
            Debug.WriteLine(VslCode)
        Else
            Debug.WriteLine(VslCode)
        End If
    End Sub

    Public Overrides Function GetID() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "IDNbr")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetDesc() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "LName") & " " & MainView.GetRowCellValue(MainView.FocusedRowHandle, "FName")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try

    End Function

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("IDNbr")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
            MainView.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyData = Windows.Forms.Keys.Down Then
            MainView.MoveNext()
            e.Handled = True
        ElseIf e.KeyData = Windows.Forms.Keys.Up Then
            MainView.MovePrev()
            e.Handled = True
        End If
    End Sub

    Public Overrides Sub SetFilter(ByVal _criteria As String)
        MainView.ActiveFilterString = _criteria
        strFilter = _criteria
        ActivateArchive()
        'selectedCrewForArchive = TempGridCheckMarsSkelection.SelectedCount
    End Sub

    Public Overrides Sub ClearFilter()
        bDisableSelectionEvent = True
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        bDisableSelectionEvent = False
        strFilter = ""
        ActivateArchive()

    End Sub

    Private Sub setActivityCrewList()
        For i As Integer = 0 To MainView.Columns.Count - 1
            If MainView.Columns(i).Name = "colLName" Or MainView.Columns(i).Name = "colFName" Or MainView.Columns(i).Name = "colMName" Then
                MainView.Columns(i).Visible = True
            Else
                MainView.Columns(i).Visible = False
            End If
        Next
    End Sub

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As System.Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) And e.Button = Windows.Forms.MouseButtons.Right Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub MainView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            rightClickMenu.ShowPopup(MousePosition)
        Else
            rightClickMenu.HidePopup()
            If bDraggable Then
                Dim view As GridView = CType(sender, GridView)
                downHitInfo = Nothing
                Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
                If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
                    Exit Sub
                End If
                If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
                    downHitInfo = hitInfo
                End If
            End If
        End If
    End Sub

    Private Sub MainView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseMove
        If bDraggable Then

            Dim view As GridView = CType(sender, GridView)
            If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then

                Dim dragSize As Size = SystemInformation.DragSize
                Dim DragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

                If Not DragRect.Contains(New Point(e.X, e.Y)) Then
                    If MAIN_CONTENT = "LTP" Then
                        view.GridControl.DoDragDrop(GetDragDataForLTP(MainView), DragDropEffects.All)
                    Else
                        view.GridControl.DoDragDrop(GetSelectedRows(), DragDropEffects.Move)
                    End If
                    downHitInfo = Nothing
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
                End If
            End If
        End If
    End Sub

    Public Overrides Sub Draggable(ByVal value As Boolean)
        bDraggable = value
        bDisableSelectionEvent = value
        MainView.OptionsSelection.MultiSelect = value
        MainView.SelectRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragDrop
        Try
            If bDraggable Then
                Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
                Dim row As DataRow
                If Not xtbl Is Nothing Then
                    For Each row In xtbl.Rows
                        Dim xfilter As String = MainView.ActiveFilterString
                        xfilter = xfilter.Replace(xfilter.Substring(xfilter.IndexOf(row("IDNbr"), 0) - 17, 17 + CType(row("IDNbr"), String).Length + 1), "")
                        MainView.ActiveFilterString = xfilter
                        AcceptDragObject(Name)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragOver
        If bDraggable Then
            If e.Data.GetDataPresent(GetType(DataTable)) Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Function GetDragDataForLTP(ByVal view As GridView) As SchedulerDragData
        Dim selection As Integer() = view.GetSelectedRows()
        If selection Is Nothing Then
            Return Nothing
        End If

        Dim appointments As AppointmentBaseCollection = New AppointmentBaseCollection()
        Dim count As Integer = selection.Length
        Dim i As Integer = 0
        Do While i < count
            Dim rowIndex As Integer = selection(i)
            Dim apt As New Appointment
            apt.Subject = CStr(view.GetRowCellValue(rowIndex, "Crew"))
            apt.Description = CStr(view.GetRowCellValue(rowIndex, "IDNbr"))
            apt.LabelId = 2
            apt.Duration = TimeSpan.FromDays(180)
            appointments.Add(apt)
            i += 1
        Loop

        Return New SchedulerDragData(appointments, 0)
    End Function

    Private Function GetSelectedRows() As DataTable
        Dim _tbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActGrpID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CurrActID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "VslName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RankName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "StatName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FkeyRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedWScaleRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedDateSON"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedPlaceSON"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyPlannedVsl"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedToRelieveID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        For Each xrow In MainView.GetSelectedRows
            _tbl.ImportRow(MainView.GetDataRow(xrow))
        Next

        Return _tbl

    End Function

    Private Sub MainView_RowCountChanged(sender As Object, e As System.EventArgs) Handles MainView.RowCountChanged
        GridBand1.Caption = "Crew Count: " & MainView.RowCount
    End Sub

    Public Overrides Sub SaveLayout()
        'If BaseControl = "Biodata" Then
        '    DB.RunSql("Update dbo.tblUserLayout SET PicViewStyle='" & PicView & "' WHERE FKeyUserID='" & USER_ID & "' AND ObjectID='" & BaseControl & "' AND ObjectList='" & Name & "'")
        'End If 
        SaveUserSetting("Layout_BiodataPicView", PicView)
        MPS4.SaveLayout(DB, Me.MainView, USER_ID, BaseControl, Name)

    End Sub

    Public Overrides Sub SetListLayout(ByVal _ObjectID As String)
        GetLayout(DB, Me.MainView, USER_ID, _ObjectID, Name)
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "SortCrew_ASC"
                SortCrew_ASC(MainView)
            Case "SortCrew_DESC"
                SortCrew_DESC(MainView)
            Case "SortRank_ASC"
                SortRank_ASC(MainView)
            Case "SortRank_DESC"
                SortRank_DESC(MainView)
            Case "CrewList_Filter"
                CrewList_Filter(MainView)
            Case "CLEAR_FILTER"
            Case "ForceRefresh"
                forceRefresh()
            Case "SetFocusedRank"
                Dim RowHandle As Integer = 0
                Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns(param(2))
                RowHandle = MainView.LocateByValue(0, Col, param(1))
                MainView.FocusedRowHandle = RowHandle
                MainView.TopRowIndex = RowHandle
        End Select
        If Not IsNothing(bContent) Then
            If MainView.DataRowCount > 0 Then
                selectedID = MainView.GetFocusedRowCellValue("IDNbr") 'Added By Calvhin 20160413
                SetSelection(selectedID)
            Else
                bContent.ExecCustomFunction(New Object() {"ClearContent"})
            End If
        End If
    End Sub

    Private Sub initControl()
        If MAIN_CONTENT <> "LTP" Then repStatCode.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmStat")
        ActivateArchive()
    End Sub

    Public Overrides Function getBListDatasource()
        Return dt
    End Function

    Private Sub rightClick_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager1.ItemClick
        If e.Item.Name <> "AddComment" And e.Item.Name <> "PrintBio" Then
            RaiseCustomEvent(Name, New Object() {"GoTo", e.Item.Name, "Crew"})
        Else
            Dim CrewID As String = GetID()
            If e.Item.Name = "PrintBio" Then
                Try
                    Dim frmRptSel As New ReportSelectionInd(CrewID)
                    frmRptSel.ShowDialog(Me)
                Catch ex As Exception
                    MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
                End Try
            Else
                Dim commentDT As New DataTable
                commentDT = DB.CreateTable("SELECT *, '' as Remarks FROM dbo.frmCrew_Comment WHERE FKeyIDNbr = '" & CrewID & "' ORDER BY ComDate DESC")

                Dim frm As New frmCrewComments(commentDT, CrewID)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub MainView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles MainView.PopupMenuShowing
        selectedID = MainView.GetRowCellValue(e.HitInfo.RowHandle, "IDNbr")
    End Sub

    Private Sub forceRefresh()
        'Throw New NotImplementedException
        getCrewListDataTable(bListSelect, "Automatic") 'Refresh CrewList
        RefreshData()
    End Sub

    Public Overrides Sub ActivateArchive()

        If SelectedTab.Equals("Archive") Then
            If (Not isActivated) Then
                isActivated = True
                Me.MainView.ExpandAllGroups()
                GridCheckMarksSelection = New MPS5.DevExpress.XtraGrid.Selection.GridCheckMarksSelection(MainView)
                selectedCrewForArchive = GridCheckMarksSelection.SelectedCount
            End If
        Else
            If (isActivated) Then
                GridCheckMarksSelection.View = Nothing
                selectedCrewForArchive = 0
                isActivated = False
            End If
        End If
    End Sub


    Public Sub SetGridReadOnlyProperties(controlGrid As GridView, Optional isReadOnly As Boolean = True)
        With controlGrid
            Select Case isReadOnly
                Case True
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                    .OptionsBehavior.ReadOnly = True
                Case Else
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                    .OptionsBehavior.ReadOnly = False
            End Select
        End With
    End Sub

    Public Overrides Sub SetAllSelected(status As Boolean)
        'Include all crews in Archive. 
        If status Then
            GridCheckMarksSelection.SelectAll()
        Else
            GridCheckMarksSelection.ClearSelection()
        End If
    End Sub

    Public Overrides Sub RunSetToArchiveProcess()
        'archive.SetConnectionsDetails("localhost\sqlexpress", "sa", "stiteam", "MPSARC") 'Fixed for the mean time. - WLM 20160905
        'archive.ConnectToDatabase()
        Dim count As Integer = GridCheckMarksSelection.SelectedCount
        Dim archiveResult As Boolean = False
        Dim message = "You are about to archive " & count & " selected crew" & IIf(count > 1, "s", "") & ". Proceed? "

        If count = 0 Then
            MessageBox.Show("No crew selected for archiving.", "Crew Archiving", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            If DialogResult.Yes = MessageBox.Show(message, "Crew Archiving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Try
                    Dim archive = New MPSArchiveUtil()
                    archiveResult = archive.RunTransferToArchive(GetSelectedCrewID())
                    If archiveResult = True Then
                        MessageBox.Show("Crew\s succesfully transfered to archive.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        SetAllSelected(False)
                    Else
                        MessageBox.Show("There is a problem while archiving selected crews.", "Archive Process", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If

    End Sub

    Public Function GetSelectedCrewID() As String
        selectedCrewID = ""
        With MainView
            For i As Integer = 0 To .RowCount - 1
                GridCheckMarksSelection.IsRowSelected(i)
                If GridCheckMarksSelection.IsRowSelected(i) Then
                    selectedCrewID += ("'" + .GetRowCellValue(i, "IDNbr") & "',")
                End If
            Next
        End With
        Return IIf(selectedCrewID.Length <= 0, "", selectedCrewID.Substring(0, selectedCrewID.Length - 1))
    End Function

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        Try
            selectedCrewForArchive = GridCheckMarksSelection.SelectedCount
            bContent.RefreshData()
        Catch ex As Exception

        End Try
    End Sub
End Class
