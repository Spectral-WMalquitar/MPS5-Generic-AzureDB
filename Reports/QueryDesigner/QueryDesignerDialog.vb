Imports System.Data
Imports System.Data.OleDb
Imports System.ComponentModel

Public Class QueryDesignerDialog

    '' ** Fields
    'Private _builder As QueryBuilder

    '' * ctor
    'Public Sub New()
    '    Me.InitializeComponent()
    '    Me._builder = New QueryBuilder(New OleDbSchema)
    '    AddHandler Me._builder.QueryFields.ListChanged, New ListChangedEventHandler(AddressOf Me.QueryFields_ListChanged)
    '    Me._grid.DataSource = Me._builder.QueryFields
    '    Me.FixGridColumns()
    '    Me.UpdateGridColumns()
    '    Me.UpdateTableTree()
    'End Sub

    '' ** Properties
    'Public Property CanChangeConnectionString() As Boolean
    '    Get
    '        Return Me._btnConnString.Visible
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Me._btnConnString.Visible = value
    '    End Set
    'End Property

    'Public Property ConnectionString() As String
    '    Get
    '        Return Me._builder.ConnectionString
    '    End Get
    '    Set(ByVal value As String)
    '        If (value <> Me.ConnectionString) Then
    '            Me._builder.ConnectionString = value
    '            Me.UpdateTableTree()
    '        End If
    '    End Set
    'End Property

    'Private ReadOnly Property Schema() As OleDbSchema
    '    Get
    '        Return Me._builder.Schema
    '    End Get
    'End Property

    'Public Property SelectStatement() As String
    '    Get
    '        Return Me._builder.Sql
    '    End Get
    '    Set(ByVal value As String)
    '    End Set
    'End Property

    '' ** Event Handlers
    'Private Sub _btnCheckSql_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCheckSql.Click
    '    Try
    '        Dim da As New OleDbDataAdapter(Me.SelectStatement, Me.ConnectionString)
    '        Dim dt As New DataTable
    '        da.FillSchema(dt, SchemaType.Mapped)
    '        MessageBox.Show(Me, My.Resources.SqlCheckSucceeded, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '    Catch x As Exception
    '        Dim msg As String = String.Format(My.Resources.SqlCheckFailed, x.Message)
    '        MessageBox.Show(Me, msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try
    'End Sub

    'Private Sub _btnClearQuery_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClearQuery.Click
    '    If (MessageBox.Show(Me, My.Resources.ConfirmClear, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
    '        Me._builder.QueryFields.Clear()
    '    End If
    'End Sub

    'Private Sub _btnConnString_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnConnString.Click
    '    Me.ConnectionString = OleDbConnString.EditConnectionString(Me, Me.ConnectionString)
    'End Sub

    'Private Sub _btnGroupBy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnGroupBy.Click
    '    Me._btnGroupBy.Checked = Not Me._btnGroupBy.Checked
    '    Me._builder.GroupBy = Me._btnGroupBy.Checked
    '    Me._txtSql.Text = Me._builder.Sql
    '    Me.UpdateGridColumns()
    'End Sub

    'Private Sub _btnProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnProperties.Click
    '    Using dlg As QueryPropertiesDialog = New QueryPropertiesDialog
    '        dlg.Font = Me.Font
    '        dlg.QueryBuilder = Me._builder
    '        If (dlg.ShowDialog = DialogResult.OK) Then
    '            Me._txtSql.Text = Me._builder.Sql
    '        End If
    '    End Using
    'End Sub

    'Private Sub _btnViewResults_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnViewResults.Click
    '    Try
    '        Dim da As New OleDbDataAdapter(Me.SelectStatement, Me.ConnectionString)
    '        Dim dt As New DataTable("Query")
    '        da.Fill(dt)
    '        Using dlg As DataPreviewDialog = New DataPreviewDialog(dt, Me.Font, MyBase.Size)
    '            dlg.ShowDialog(Me)
    '        End Using
    '    Catch x As Exception
    '        Dim msg As String = String.Format(My.Resources.ErrGettingData, x.Message)
    '        MessageBox.Show(Me, msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try
    'End Sub

    'Private Sub _grid_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles _grid.CellClick
    '    If (Me._grid.Columns.Item(e.ColumnIndex).Name = "Filter") Then
    '        Using dlg As FilterEditorForm = New FilterEditorForm
    '            Dim field As QueryField = TryCast(Me._grid.Rows.Item(e.RowIndex).DataBoundItem, QueryField)
    '            dlg.Font = Me.Font
    '            dlg.QueryField = field
    '            If (dlg.ShowDialog(Me) = DialogResult.OK) Then
    '                field.Filter = dlg.Value
    '            End If
    '        End Using
    '    End If
    'End Sub

    'Private Sub _grid_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles _grid.CellEndEdit, _grid.CellContentClick
    '    Me._grid.CommitEdit(DataGridViewDataErrorContexts.Commit)
    'End Sub

    'Private Sub _grid_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles _grid.DragDrop
    '    Dim node As TreeNode = TryCast(e.Data.GetData(GetType(TreeNode)), TreeNode)
    '    If (Not node Is Nothing) Then
    '        Me.AddField(node.Tag)
    '    Else
    '        Dim row As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
    '        If (Not row Is Nothing) Then
    '            Dim pt As Point = Me._grid.PointToClient(New Point(e.X, e.Y))
    '            Dim ht As DataGridView.HitTestInfo = Me._grid.HitTest(pt.X, pt.Y)
    '            Dim src As Integer = row.Index
    '            Dim dst As Integer = ht.RowIndex
    '            If (dst < 0) Then
    '                dst = (Me._grid.Rows.Count - 1)
    '            End If
    '            If (src <> dst) Then
    '                Dim fields As QueryFieldCollection = Me._builder.QueryFields
    '                Dim field As QueryField = fields.Item(src)
    '                fields.RemoveAt(src)
    '                fields.Insert(dst, field)
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub _grid_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles _grid.DragEnter
    '    Dim node As TreeNode = TryCast(e.Data.GetData(GetType(TreeNode)), TreeNode)
    '    If ((Not node Is Nothing) AndAlso (TypeOf node.Tag Is DataColumn OrElse TypeOf node.Tag Is DataTable)) Then
    '        e.Effect = DragDropEffects.Copy
    '    Else
    '        Dim row As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
    '        If ((Not row Is Nothing) AndAlso Me._grid.Rows.Contains(row)) Then
    '            e.Effect = DragDropEffects.Move
    '        End If
    '    End If
    'End Sub

    'Private Sub _grid_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles _grid.DragOver
    '    Dim row As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
    '    If (Not row Is Nothing) Then
    '        Dim pt As Point = Me._grid.PointToClient(New Point(e.X, e.Y))
    '        Select Case Me._grid.HitTest(pt.X, pt.Y).Type
    '            Case DataGridViewHitTestType.None, DataGridViewHitTestType.Cell, DataGridViewHitTestType.RowHeader
    '                e.Effect = DragDropEffects.Move
    '                Return
    '        End Select
    '        e.Effect = DragDropEffects.None
    '    End If
    'End Sub

    'Private Sub _grid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _grid.MouseDown
    '    Dim ht As DataGridView.HitTestInfo = Me._grid.HitTest(e.X, e.Y)
    '    If (ht.Type = DataGridViewHitTestType.RowHeader) Then
    '        Dim row As DataGridViewRow = Me._grid.Rows.Item(ht.RowIndex)
    '        If (Not row Is Nothing) Then
    '            Dim field As QueryField = TryCast(row.DataBoundItem, QueryField)
    '            If (Not field Is Nothing) Then
    '                Me._grid.CurrentCell = row.Cells.Item(0)
    '                If (MyBase.DoDragDrop(row, DragDropEffects.Move) <> DragDropEffects.None) Then
    '                    Me._timer.Tag = field
    '                    Me._timer.Start()
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub _mnuHideThisTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuHideThisTable.Click
    '    Dim node As TreeNode = Me._treeTables.SelectedNode
    '    If (Not node Is Nothing) Then
    '        Me._treeTables.Nodes.Remove(node)
    '    End If
    'End Sub

    'Private Sub _mnuRelatedTables_DropDownItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles _mnuRelatedTables.DropDownItemClicked
    '    Dim node As TreeNode = Me.FindNode(e.ClickedItem.Text)
    '    If (Not node Is Nothing) Then
    '        Me._treeTables.SelectedNode = node
    '        node.Expand()
    '    End If
    'End Sub

    'Private Sub _mnuShowAllTables_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuShowAllTables.Click
    '    Me.UpdateTableTree()
    'End Sub

    'Private Sub _mnuTree_Opening(ByVal sender As Object, ByVal e As CancelEventArgs)
    '    Dim pt As Point = Me._treeTables.PointToClient(Control.MousePosition)
    '    Dim nd As TreeNode = Me._treeTables.GetNodeAt(pt)
    '    Dim dt As DataTable = IIf((nd Is Nothing), Nothing, TryCast(nd.Tag, DataTable))
    '    If (Not nd Is Nothing) Then
    '        Me._treeTables.SelectedNode = nd
    '    End If
    '    If (dt Is Nothing) Then
    '        e.Cancel = True
    '    Else
    '        Me._mnuRelatedTables.DropDownItems.Clear()
    '        If ((Not nd Is Nothing) AndAlso TypeOf nd.Tag Is DataTable) Then
    '            Dim list As New List(Of String)
    '            Dim dr As DataRelation
    '            For Each dr In Me._builder.Schema.Relations
    '                If Not ((Not dr.ParentTable Is dt) OrElse list.Contains(dr.ChildTable.TableName)) Then
    '                    list.Add(dr.ChildTable.TableName)
    '                ElseIf Not ((Not dr.ChildTable Is dt) OrElse list.Contains(dr.ParentTable.TableName)) Then
    '                    list.Add(dr.ParentTable.TableName)
    '                End If
    '            Next
    '            list.Sort()
    '            Dim tableName As String
    '            For Each tableName In list
    '                If (Not Me.FindNode(tableName) Is Nothing) Then
    '                    Me._mnuRelatedTables.DropDownItems.Add(tableName)
    '                End If
    '            Next
    '        End If
    '    End If
    'End Sub

    'Private Sub _timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
    '    Me._timer.Stop()
    '    Me.SelectField(TryCast(Me._timer.Tag, QueryField))
    'End Sub

    'Private Sub _treeTables_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles _treeTables.ItemDrag
    '    Dim node As TreeNode = TryCast(e.Item, TreeNode)
    '    If ((Not node Is Nothing) AndAlso (TypeOf node.Tag Is DataTable OrElse TypeOf node.Tag Is DataColumn)) Then
    '        Me._treeTables.SelectedNode = node
    '        MyBase.DoDragDrop(e.Item, DragDropEffects.Copy)
    '    End If
    'End Sub

    'Private Sub _treeTables_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles _treeTables.NodeMouseDoubleClick
    '    If ((e.Node Is Me._treeTables.SelectedNode) AndAlso TypeOf e.Node.Tag Is DataColumn) Then
    '        Me.AddField(e.Node.Tag)
    '    End If
    'End Sub

    'Private Sub QueryFields_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
    '    Me._txtSql.Text = Me._builder.Sql
    'End Sub

    '' ** Implementation
    'Private Sub AddColumn(ByVal dc As DataColumn)
    '    Dim field As New QueryField(dc)
    '    Me._builder.QueryFields.Add(field)
    '    Me.SelectField(field)
    'End Sub

    'Private Sub AddDataColumns(ByVal node As TreeNode, ByVal dt As DataTable)
    '    Dim col As DataColumn
    '    For Each col In dt.Columns
    '        Dim field As TreeNode = node.Nodes.Add(col.ColumnName)
    '        field.Tag = col
    '        field.ImageIndex = 2
    '        field.SelectedImageIndex = 2
    '    Next
    'End Sub

    'Private Sub AddField(ByVal element As Object)
    '    Dim dt As DataTable = TryCast(element, DataTable)
    '    If (Not dt Is Nothing) Then
    '        Me.AddTable(dt)
    '    End If
    '    Dim dc As DataColumn = TryCast(element, DataColumn)
    '    If (Not dc Is Nothing) Then
    '        Me.AddColumn(dc)
    '    End If
    'End Sub

    'Private Sub AddTable(ByVal dt As DataTable)
    '    Dim field As New QueryField(dt)
    '    Me._builder.QueryFields.Add(field)
    '    Me.SelectField(field)
    'End Sub

    'Private Function FindNode(ByVal [text] As String) As TreeNode
    '    Return Me.FindNode(Me._treeTables.Nodes, [text])
    'End Function

    'Private Function FindNode(ByVal nodes As TreeNodeCollection, ByVal [text] As String) As TreeNode
    '    Dim node As TreeNode
    '    For Each node In nodes
    '        Dim dt As DataTable = TryCast(node.Tag, DataTable)
    '        If ((Not dt Is Nothing) AndAlso (dt.TableName = [text])) Then
    '            Return node
    '        End If
    '        Dim child As TreeNode = Me.FindNode(node.Nodes, [text])
    '        If (Not child Is Nothing) Then
    '            Return child
    '        End If
    '    Next
    '    Return Nothing
    'End Function

    'Private Sub FixGridColumns()
    '    Dim i As Integer
    '    For i = 0 To Me._grid.Columns.Count - 1
    '        Dim col As DataGridViewColumn = Me._grid.Columns.Item(i)
    '        If col.ValueType.IsEnum Then
    '            Dim cmb As New DataGridViewComboBoxColumn
    '            cmb.ValueType = col.ValueType
    '            cmb.Name = col.Name
    '            cmb.DataPropertyName = col.DataPropertyName
    '            cmb.HeaderText = col.HeaderText
    '            cmb.DisplayStyleForCurrentCellOnly = True
    '            cmb.DataSource = [Enum].GetValues(col.ValueType)
    '            Me._grid.Columns.RemoveAt(i)
    '            Me._grid.Columns.Insert(i, cmb)
    '        ElseIf (col.Name = "Filter") Then
    '            Dim btn As New DataGridViewButtonColumn
    '            btn.ValueType = col.ValueType
    '            btn.Name = col.Name
    '            btn.DataPropertyName = col.DataPropertyName
    '            btn.HeaderText = col.HeaderText
    '            Me._grid.Columns.RemoveAt(i)
    '            Me._grid.Columns.Insert(i, btn)
    '        End If
    '    Next i
    'End Sub

    'Private Sub SelectField(ByVal field As QueryField)
    '    Dim cm As CurrencyManager = TryCast(Me.BindingContext.Item(Me._grid.DataSource), CurrencyManager)
    '    cm.Position = cm.List.IndexOf(field)
    'End Sub

    'Private Sub UpdateGridColumns()
    '    Me._grid.Columns.Item("Column").Frozen = True
    '    Me._grid.Columns.Item("GroupBy").Visible = Me._builder.GroupBy
    'End Sub

    'Private Sub UpdateTableTree()
    '    Dim nodes As TreeNodeCollection = Me._treeTables.Nodes
    '    nodes.Clear()
    '    Dim ndTables As New TreeNode(My.Resources.Tables, 0, 0)
    '    Dim ndViews As New TreeNode(My.Resources.Views, 1, 1)
    '    If (Not Me.Schema Is Nothing) Then
    '        Me._treeTables.BeginUpdate()
    '        Dim dt As DataTable
    '        For Each dt In Me.Schema.Tables
    '            Dim node As New TreeNode(dt.TableName)
    '            node.Tag = dt
    '            Select Case OleDbSchema.GetTableType(dt)
    '                Case TableType.Table
    '                    ndTables.Nodes.Add(node)
    '                    node.ImageIndex = 0
    '                    node.SelectedImageIndex = 0
    '                    Me.AddDataColumns(node, dt)
    '                    Exit Select
    '                Case TableType.View
    '                    ndViews.Nodes.Add(node)
    '                    node.ImageIndex = 1
    '                    node.SelectedImageIndex = 1
    '                    Me.AddDataColumns(node, dt)
    '                    Exit Select
    '            End Select
    '        Next
    '        Dim nd As TreeNode
    '        For Each nd In New TreeNode() {ndTables, ndViews}
    '            If (nd.Nodes.Count > 0) Then
    '                nd.Text = String.Format("{0} ({1})", nd.Text, nd.Nodes.Count)
    '                nodes.Add(nd)
    '            End If
    '        Next
    '        ndTables.Expand()
    '        Me._treeTables.EndUpdate()
    '    End If
    'End Sub
End Class