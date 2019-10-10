Public Class DataUtility 
    Public DB As SQLDB
    Public TBName As String = "" 'Table Name
    'Public AllowDuplicate As Boolean = True 'allow duplicate option
    'Public AllowMerge As Boolean = True 'allow duplicate option
    'Public ObjectID As String
    Private FormName As String = "Admin Data Tool"

    Protected Mode As Integer = 0 'Mode Merge or Duplicate
    Public ColList As String = "" 'Required Columns
    Public ListSelect As String = "" 'Select Statement
    Dim downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Dim maintbl As New DataTable 'table of the Admin Items
    Dim BRECORDUPDATEDs As Boolean = False

    Private Function allowOption(ByVal value As Boolean)
        If value Then
            Return DevExpress.XtraBars.BarItemVisibility.Always
        Else
            Return DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Function

    'Load
    Private Sub DataUtility_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ResetRibbon()
        'cmdMerge.Visibility = allowOption(AllowMerge)
        'cmdDuplicate.Visibility = allowOption(AllowDuplicate)
        RefreshData()
        InitDefaultButton()
        initGrid(Me.MainView)
        initGrid(Me.MergeView)
        initGrid(Me.ReplaceWithView)
        'SelectMode("cmdMerge")
    End Sub

    'Apply Button
    Private Sub cmdApply_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdApply.ItemClick
        Me.RibbonControl.Focus()

        Dim tblName As String = TBName
        Dim info As Boolean = False
        Dim type As String = ""
        Select Case Mode
            Case 1 'Merge and Replace
                type = "Merge"
                Dim NewValue As String = ""
                Dim OldValue As String = ""
                Dim nNewValue As String = ""
                Dim nOldValue As String = ""
                If Me.ReplaceWithView.RowCount <= 0 Then
                    MsgBox("Please select an item to Replace with.", MsgBoxStyle.Information, GetAppName)
                Else
                    'MsgBox(Me.ReplaceWithView.RowCount)
                    If Mode = 1 And MsgBox("Are you sure you want to replace the items with '" & Me.ReplaceWithView.GetRowCellValue(0, "Name") & "'. " & vbCrLf & "This process is irrevocable.", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        For i As Integer = 0 To Me.MergeView.RowCount - 1
                            info = False 'reset info
                            'MsgBox(tblName & "------" & Me.ReplaceWithView.GetRowCellValue(0, "PKey") & "-------" & Me.MergeView.GetRowCellValue(i, "PKey"))
                            '<!--added by tony20180922 : Log Deletion
                            oLogDeletion.Init()

                            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                                FormName, _
                                "Crewing", _
                                "tbltravelbooking", _
                                "PKey IN ('" & MergeView.GetRowCellValue(i, "PKey") & "')", _
                                "<< Delete Crew Data - " & FormName & " >>", _
                                LogDeletion.DeletionType.Manual, _
                                "Manually Deleted in <" & FormName & ">", _
                                GetUserName())
                            '-->

                            info = DB.RunSql("EXEC dbo.SP_UpdAdmRelatedTblRec '" & tblName & "','" & Me.MergeView.GetRowCellValue(i, "PKey") & "','" & Me.ReplaceWithView.GetRowCellValue(0, "PKey") & "'")

                            'For the Deletion of the Titems in merge Record.
                            If info Then
                                If DB.RunSql("DELETE FROM dbo." & tblName & " WHERE PKey='" & Me.MergeView.GetRowCellValue(i, "PKey") & "'") Then
                                    oLogDeletion.AddLogEntryToDatabase()
                                End If
                            Else
                                MsgBox("Failed to delete the Main Item(s).", MsgBoxStyle.Exclamation, GetAppName)
                            End If
                        Next
                    End If
                End If

            Case 2 'Duplicate Item
                If Not MergeView.HasColumnErrors Then
                    If Mode = 2 And MsgBox("Are you sure you want to Duplicate the selected record(s)?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                        type = "Duplicate"
                        Dim str As String
                        With Me.MergeView
                            For i As Integer = 0 To .RowCount - 1
                                info = False 'reset info
                                str = ""
                                For Each colName As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                                    If colName.Visible = True And colName.FieldName <> "OrigName" Then
                                        str = "[" & colName.FieldName & "]='" & .GetRowCellValue(i, colName).ToString.Replace("'", "''") & "'," & str
                                    End If
                                Next
                                str = str.Substring(0, Len(str) - 1)
                                info = DB.DuplicateAdminRecord(tblName, "'" & Me.MergeView.GetRowCellValue(i, "PKey") & "'", str)
                                If Not info Then
                                    MsgBox("Failed to duplicate item(s).", MsgBoxStyle.Critical, GetAppName)
                                    RefreshData()
                                    Exit Sub
                                Else
                                End If
                            Next
                        End With
                    End If
                Else
                    MessageBox.Show("A new 'Name' has already been used, please replace it.", GetAppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        End Select
        If info Then
            RefreshData()
            MsgBox("" & type & " Successful.", MsgBoxStyle.Information, GetAppName)
        End If

    End Sub

    'Cancel Button
    Private Sub cmdCancel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
        Me.Close()
    End Sub

    'Select Mode
    Private Sub SelectMode(ByVal cMode As String)

        'Me.MergeView.Columns(0).Visible = False
        Try

            Select Case cMode
                Case "cmdMerge"
                    Mode = 1
                    cmdMerge.Down = True
                    Me.gcList1.Text = "Item(s) to be Replaced"
                    Me.gcList2.Text = "Replace above items(s) with"
                    MainPanel2.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                    Me.MergeView.OptionsBehavior.Editable = False
                    initGrid(Me.MergeView, Mode)
                    'Me.MergeView.Columns("PKey").Visible = False
                    'Me.MergeView.Columns("Edited").Visible = False

                Case "cmdDuplicate"
                    Mode = 2
                    cmdDuplicate.Down = True
                    Me.gcList1.Text = "Items to be Duplicated"
                    Me.gcList2.Text = ""
                    MainPanel2.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
                    Me.MergeView.OptionsBehavior.Editable = True
                    initGrid(Me.MergeView, Mode)
                    'Me.MergeView.Columns.AddVisible("Name", "Original Name")
                    'Dim newCOl As New DevExpress.XtraGrid.Columns.GridColumn
                    'newCOl.Caption = "Original Name"
                    'Me.MergeView.Columns.Add(newCOl)
                Case Else
                    Mode = 0
                    Me.MergeView.OptionsBehavior.Editable = False
                    'MsgBox("Select 1")
                    'cMode= "cmdMerge"
            End Select
            RefreshData()
        Catch ex As Exception
            'MsgBox(ex.Message, , "SEL MODe")
        End Try


    End Sub

    'Refresh
    Public Sub RefreshData()
        Try
            maintbl = DB.CreateTable(ListSelect)
            Me.MainGrid.DataSource = maintbl
            Dim sdt As DataTable = maintbl.Clone
            Dim newCol As New System.Data.DataColumn
            newCol.ColumnName = "OrigName"
            newCol.Caption = "Original Name"
            sdt.Columns.Add(newCol)
            Me.MergeGrid.DataSource = sdt
            Me.ReplaceWithGrid.DataSource = maintbl.Clone
        Catch ex As Exception
        End Try

    End Sub

    Public Sub InitDefaultButton()
        If cmdMerge.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
            SelectMode("cmdMerge")
        ElseIf cmdDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
            SelectMode("cmdDuplicate")
        End If
    End Sub

    'Show All Buttons
    Private Sub ResetRibbon()
        Dim nPage As DevExpress.XtraBars.Ribbon.RibbonPage, nPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        For Each nPage In RibbonControl.Pages
            nPage.Visible = True
            For Each nPageGroup In nPage.Groups
                nPageGroup.Visible = True
                If nPageGroup.Tag = 1 Then
                    InitRibbonItems(nPageGroup)
                End If
            Next
        Next
    End Sub

    'button Click
    Private Sub Contain_ItemClick(ByVal Sender As System.Object, ByVal a As DevExpress.XtraBars.ItemClickEventArgs)
        Try
            SelectMode(a.Item.Name)
        Catch ex As Exception
            'MsgBox(ex.Message, , "Contain_itemClick")
        End Try
    End Sub


    Private Sub InitRibbonItems(ByVal container As DevExpress.XtraBars.Ribbon.RibbonPageGroup)
        For i As Integer = 0 To container.ItemLinks.Count - 1
            If TypeOf (container.ItemLinks(i).Item) Is DevExpress.XtraBars.BarButtonItem Then
                Dim btn As DevExpress.XtraBars.BarButtonItem = container.ItemLinks(i).Item
                If btn.GroupIndex > 0 Then
                    AddHandler btn.ItemClick, AddressOf Contain_ItemClick
                End If
            End If
        Next
    End Sub


#Region "MainGrid"
    Private Sub MainView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseDown
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

    Private Sub MainView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseMove
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

    Private Sub MainGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            Select Case Mode
                Case 2 'Duplicate Mode
                    row.Delete()
                Case Else
                    table.ImportRow(row)
                    row.Delete()
            End Select
        End If
        'table.Select("", "Name ASC").CopyToDataTable()
    End Sub

    Private Sub MainGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") And view.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub
#End Region

#Region "Merge Table"

    Private Sub MergeView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MergeView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With Me.MainView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub MergeView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MergeView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MergeView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MergeView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            MainView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub MergeView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MergeView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
        strRequiredFieldName = UniqueColumns()
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

    Private Sub MergeView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles MergeView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MergeView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MergeView.MouseDown
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

    Private Sub MergeView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MergeView.MouseMove
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

    Private Sub MergeGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles MergeGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        'Dim nrow As DataRow = row.Table
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            Select Case Mode
                Case 1 'Merge
                    If Mid(row("PKey"), 1, 3) <> "SYS" Then
                        table.ImportRow(row)
                        row.Delete()
                    Else
                        MsgBox("Cannot Merge System Record", MsgBoxStyle.Critical, GetAppName)
                    End If

                Case 2 'Duplicate
                    'table.ImportRow(row)
                    Dim uncol As String = UniqueColumns()
                    Dim nrow As DataRow = table.NewRow

                    Dim OriginalName As String = ""
                    If Not MergeView.HasColumnErrors Then
                        For x As Integer = 0 To Me.MergeView.Columns.Count - 1
                            If InStr(1, uncol, table.Columns(x).ColumnName) > 0 Then
                                If table.Columns(x).ColumnName = "Name" Then
                                    OriginalName = row(table.Columns(x).ColumnName)
                                End If
                                If table.Columns(x).ColumnName <> "FileTag" Then
                                    nrow(table.Columns(x).ColumnName) = row(table.Columns(x).ColumnName) & " Copy" & CStr((table.Rows.Count() + 1))
                                Else
                                    Me.MergeView.Columns(x).ColumnEdit = repFileTag
                                    If Len(row(table.Columns(x).ColumnName) & " Copy".ToString) < 5 Then
                                        nrow(table.Columns(x).ColumnName) = row(table.Columns(x).ColumnName) & " Copy" & CStr(table.Rows.Count())
                                    Else
                                        nrow(table.Columns(x).ColumnName) = (row(table.Columns(x).ColumnName) & " Copy").ToString.Substring(0, 5)

                                    End If
                                End If
                            Else
                                If table.Columns(x).ColumnName <> "OrigName" Then
                                    nrow(table.Columns(x).ColumnName) = row(table.Columns(x).ColumnName)
                                End If
                            End If
                        Next
                        table.Rows.Add(nrow)
                        Me.MergeView.SetRowCellValue(table.Rows.Count - 1, "OrigName", OriginalName)
                        Me.MergeView.FocusedRowHandle = Me.MergeView.RowCount - 1
                        ColumnDuplicateCheck(Me.MergeView)
                    Else
                        MsgBox("Please fix the duplicate value(s).", MsgBoxStyle.Information, GetAppName)
                    End If
                Case 3 'Delete
                    If isDeleteAllowed_(row.Item("PKey")) Then
                        table.ImportRow(row)
                        row.Delete()
                    Else
                        MsgBox("The record you are trying to delete is already in use or a System Admin Data.", MsgBoxStyle.Information, GetAppName)
                    End If
                Case Else
                    table.ImportRow(row)
                    row.Delete()
            End Select
        End If
    End Sub

    Private Sub MergeView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MergeView.ValidateRow
        If Mode = 2 Then 'do this only in duplicate mode
            Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim unq As String = UniqueColumns()
            With views
                For x = 0 To .VisibleColumns.Count - 1
                    If InStr(1, unq, .VisibleColumns(x).FieldName) > 0 Then
                        For i = 0 To .DataRowCount - 1
                            If DB.HasDuplicate(Me.TBName, "[" & .VisibleColumns(x).FieldName & "]='" & .GetRowCellValue(.FocusedRowHandle, .VisibleColumns(x).FieldName) & "'") Then
                                .SetColumnError(.VisibleColumns(x), "Already in use")
                                e.Valid = False
                                Exit For
                            Else
                                If i <> .FocusedRowHandle Then
                                    If .GetRowCellValue(.FocusedRowHandle, .VisibleColumns(x)).Equals(.GetRowCellValue(i, .VisibleColumns(x))) Then
                                        .SetColumnError(.VisibleColumns(x), "Already in use")
                                        e.Valid = False
                                        'e.ErrorText = "Already in use"
                                    Else
                                        .SetColumnError(.VisibleColumns(x), "")
                                        'e.Valid = True
                                    End If
                                Else
                                    .SetColumnError(.VisibleColumns(x), "")
                                    'e.Valid = True
                                End If
                            End If
                        Next
                    End If
                Next

                If Not .HasColumnErrors Then
                    .ClearColumnErrors()
                    e.Valid = True
                End If
            End With
        End If

    End Sub

    Private Sub MergeView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles MergeView.ValidatingEditor
        If Mode = 2 Then 'do this only in duplicate mode
            Dim views As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim unq As String = UniqueColumns()
            With views
                For i = 0 To .DataRowCount - 1

                    If DB.HasDuplicate(Me.TBName, "[" & .FocusedColumn.FieldName & "]='" & e.Value & "'") Then
                        e.ErrorText = "Already in use"
                        e.Valid = False
                    Else
                        If i <> (.FocusedRowHandle) Then
                            If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                                e.Valid = False
                                e.ErrorText = "Already in use"
                            End If
                        End If
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub MergeView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MergeView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MergeView_RowCountChanged(sender As Object, e As System.EventArgs) Handles MergeView.RowCountChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Select Case Mode
            Case 1 'Merge and Rep
                If (view.RowCount) > 0 And (Me.ReplaceWithView.RowCount > 0) Then
                    cmdApply.Enabled = True
                Else
                    cmdApply.Enabled = False
                End If
            Case 2 'Duplicate
                If (view.RowCount) > 0 Then
                    cmdApply.Enabled = True
                Else
                    cmdApply.Enabled = False
                End If
        End Select

    End Sub

    Private Sub MergeGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles MergeGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

#End Region

#Region "ReplaceGrid"
    Private Sub ReplaceWithView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ReplaceWithView.MouseDown
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

    Private Sub ReplaceWithView_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles ReplaceWithView.MouseMove
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

    Private Sub ReplaceWithGrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ReplaceWithGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        Dim counter As Integer = grid.MainView.RowCount - 1

        If counter < 0 Then
            If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
                table.ImportRow(row)
                row.Delete()

            End If
        Else
            ''If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            ''    table.ImportRow(row)
            ''    row.Delete()
            ''End If
            MsgBox("Only one Item is allowed.", vbInformation, GetAppName)
        End If

    End Sub

    Private Sub ReplaceWithGrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ReplaceWithGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ReplaceWithView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ReplaceWithView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") And view.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = ReplaceWithView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub ReplaceWithView_RowCountChanged(sender As Object, e As System.EventArgs) Handles ReplaceWithView.RowCountChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If (view.RowCount) > 0 And (Me.MergeView.RowCount > 0) Then
            cmdApply.Enabled = True
        Else
            cmdApply.Enabled = False
        End If
    End Sub
#End Region

    Private Sub cmdRefresh_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRefresh.ItemClick
        RefreshData()
    End Sub

#Region "Function"
    'Function that check if it is allowed to delete the record
    Private Function isDeleteAllowed_(ByVal Value As String) As Boolean
        Dim isAllowed As Boolean = False
        DB.BeginReader("EXEC dbo.SP_DelAdmRec '" & TBName & "','" & Value & "'")
        While DB.Read
            'isAllowed = Not (DB.ReaderItem("isUsed"))
            If DB.ReaderItem("isUsed") = True Then
                isAllowed = False
            Else
                isAllowed = True
            End If
        End While
        DB.CloseReader()
        Return isAllowed
    End Function

    'Initialize Grid Columns
    Private Sub initGrid(ByRef _grid As DevExpress.XtraGrid.Views.Grid.GridView, Optional ByVal _Mode As Integer = 1)
        Dim colNames As String = ""
        colNames = UniqueColumns()
        With _grid
            For colCount As Integer = 0 To .Columns.Count - 1
                'Dim colstr As String = ""
                If InStr(1, colNames, .Columns(colCount).FieldName) > 0 Then
                    .Columns(colCount).Visible = True
                Else
                    If Mode = 2 Then
                        If .Columns(colCount).FieldName <> "OrigName" Then
                            .Columns(colCount).Visible = False
                        Else
                            .Columns(colCount).Visible = True
                            .Columns(colCount).VisibleIndex = 0
                            .Columns(colCount).OptionsColumn.ReadOnly = True
                        End If

                    Else
                        .Columns(colCount).Visible = False
                    End If

                End If
            Next
        End With
    End Sub

    'Get the unique columns of the tables
    Private Function UniqueColumns() As String
        Dim str As String = ""
        With DB
            .BeginReader("exec [SP_UNQColumn] '" & TBName & "'")
            While .Read
                'MsgBox(.ReaderItem(0).ToString)
                str = .ReaderItem(0).ToString
            End While
            .CloseReader()
        End With

        Return str
    End Function
#End Region

    Private Sub ColumnDuplicateCheck(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim unq As String = UniqueColumns()
        For x = 0 To View.VisibleColumns.Count - 1
            If InStr(1, unq, View.VisibleColumns(x).FieldName) > 0 Then
                If DB.HasDuplicate(Me.TBName, "[" & View.VisibleColumns(x).FieldName & "]='" & View.GetRowCellValue(View.FocusedRowHandle, View.VisibleColumns(x).FieldName) & "'") Then
                    View.SetColumnError(View.VisibleColumns(x), "Already in use")
                Else
                    With View
                        Dim currval As String = .GetRowCellValue(.FocusedRowHandle, .VisibleColumns(x))
                        For i = 0 To .DataRowCount - 1
                            If i <> .FocusedRowHandle Then
                                If currval.Equals(.GetRowCellValue(i, .VisibleColumns(x))) Then
                                    .SetColumnError(.VisibleColumns(x), "Already in use")
                                End If
                            End If
                        Next
                    End With
                End If
            End If
        Next
    End Sub

    Public Function GetRelatedTables(_tableName As String, _pKey As String, _newName As String, status As Integer) As Integer

        'The first record will always be the _tableName
        Dim baseQuery As String = "EXEC dbo.GetRelatedTables '" & _tableName & "' "

        Dim tableReturned As DataTable = DB.CreateTable(baseQuery)
        Dim relatedTables As New ArrayList
        Dim count As Integer = 0

        If (status = 0) Then
            Return 0
        Else
            If (status = 888) Then DB.RunSql("DELETE FROM tbl_temp_related_tables")
            For Each row As DataRow In tableReturned.Rows
                relatedTables.Add(row("TableWithForeignKey"))
                DB.RunSql("INSERT INTO tbl_temp_related_tables(TableName, FKColumnName) VALUES ('" & row("TableWithForeignKey") & "','" & row("ForeignKeyColumn") & "')")
                '_pKey = row("ForeignKeyColumn")
                'count = count + GetRelatedTables(row("TableWithForeignKey"), _pKey, _newName, tableReturned.Rows.Count)
            Next
            Return count
        End If
    End Function



    Public Sub New(Optional ObjectID As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Select Case ObjectID
            Case "CompetenceTemplate", "PayScale"
                cmdDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                cmdMerge.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case Else
                cmdDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                cmdMerge.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End Select


    End Sub
End Class