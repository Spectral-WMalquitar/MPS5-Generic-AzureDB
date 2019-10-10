Imports System.Data
Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.IO.Directory
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

'Imports Microsoft.Office.Interop.Excel 'Before you add this reference to your project,
'' you need to install Microsoft Office and find last version of this file.
'Imports Microsoft.Office.Interop

Public Class ADVANCEDSEARCH


    ' ** Fields
    Private _builder As QueryBuilder
    Private sqlstr As String = ""
    Private LoadedTemplate As String = ""

    Dim ColumnDescTable As New System.Data.DataTable()
    Dim CriteriaOptable As New System.Data.DataTable()
    ' * ctor

    Dim clsAudit As New clsAudit 'neil

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "EXPORT"
                ExportData()
            Case "LOADTEMPLATE"
                LoadTemplate()
            Case "CLEARFILTER"
                _grid.Rows.Clear()
        End Select
    End Sub

#Region "Easy Edit"
    Private FormName As String = "Query Builder"
    Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
#End Region

#Region "Export Data"
    'export to function
    Private Sub ExportData()
        Try
            If MainView.RowCount > 0 Then
                Dim s As SaveFileDialog = New SaveFileDialog
                s.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html |Csv File (.csv)|*.csv"
                If s.ShowDialog() = DialogResult.OK Then
                    Dim exportFilePath As String = s.FileName
                    Dim fileExtenstion As String = New System.IO.FileInfo(exportFilePath).Extension

                    Select Case fileExtenstion
                        Case ".xlsx"
                            MainView.ExportToXlsx(exportFilePath)
                        Case ".xls"
                            MainView.ExportToXls(exportFilePath)
                        Case ".rtf"
                            MainView.ExportToRtf(exportFilePath)
                        Case ".pdf"
                            MainView.ExportToPdf(exportFilePath)
                        Case ".html"
                            MainView.ExportToHtml(exportFilePath)
                        Case ".csv"
                            MainView.ExportToCsv(exportFilePath)
                    End Select

                    If MsgBox("Export successful!" & vbNewLine & vbNewLine & "File saved to: " & exportFilePath & vbNewLine & vbNewLine & "Do you wish to open the exported file?", 68, GetAppName) = MsgBoxResult.Yes Then

                        Dim filePath As String = exportFilePath
                        Try
                            System.Diagnostics.Process.Start(filePath)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                        End Try
                    End If
                End If
            Else
                MsgBox("No data to export.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, GetAppName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, GetAppName)
        End Try

    End Sub
#End Region

    Private Sub GetCriteriaOperand()
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CriteriaOperator"
        ccolumn.DataType = System.Type.GetType("System.String")
        CriteriaOptable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CriteriaOpDisplay"
        ccolumn.DataType = System.Type.GetType("System.String")
        CriteriaOptable.Columns.Add(ccolumn)
        Dim crow() As Object = {"AND", "AND"}
        CriteriaOptable.Rows.Add(crow)
        crow(0) = "OR"
        crow(1) = "OR"
        CriteriaOptable.Rows.Add(crow)
    End Sub

    Public Overrides Sub RefreshData()

        'tony20151015
        SetShowListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetExportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetClearFilterVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetClearFilterCaption(Name, "Clear Builder")
        SetClearFilterEnabled(Name, True)
        AllowSaving(Name, True)
        SetApplyVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        'end tony


        If DevExpress.XtraSplashScreen.SplashScreenManager.Default IsNot Nothing Then SplashScreenManager.CloseForm() 'added by calvhin 20170118

        SplashScreenManager.ShowForm(GetType(Waitform))

        'create datatable for columnDesc
        Me.TableName = "tblReportTemplates"

        Try
            If Not bLoaded Then
                ColumnDescTable = DB.CreateTable("SELECT * FROM dbo.COLUMNDESCRIPTIONS")
                GetCriteriaOperand()
            End If
        Catch ex As Exception
        End Try
        'end create

        Me._builder = New QueryBuilder(New OleDbSchema(DB))
        _builder.ConnectionString = "Provider=SQLOLEDB.1;" & DB.GetConnectionString
        AddHandler Me._builder.QueryFields.ListChanged, New ListChangedEventHandler(AddressOf Me.QueryFields_ListChanged)
        Me._grid.DataSource = Me._builder.QueryFields
        Me.FixGridColumns()
        Me.UpdateGridColumns()
        Me.UpdateTableTree()

        'populate report templates
        RefreshTemplates()



        SplashScreenManager.CloseForm()
    End Sub

    Private Sub RefreshTemplates() 'populate report templates
        GridTemplates.DataSource = DB.CreateTable("SELECT * FROM dbo.tblReportTemplates Order by TemplateName")
        If GridRepTemplates.RowCount > 0 Then
            AllowDeletion(Name, True) 'Enable Delete button
            AllowLoadingTemplate(Name, True) 'Enable LoadTemplate button
        Else
            AllowDeletion(Name, False) 'Disable Delete button
            AllowLoadingTemplate(Name, False) 'Disable LoadTemplate button
        End If
    End Sub

    '' ** Properties
    'Public Property CanChangeConnectionString() As Boolean
    '    Get
    '        Return Me._btnConnString.Visible
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Me._btnConnString.Visible = value
    '    End Set
    'End Property

    Public Property ConnectionString() As String
        Get
            Return Me._builder.ConnectionString
        End Get
        Set(ByVal value As String)
            If (value <> Me.ConnectionString) Then
                Me._builder.ConnectionString = value
                Me.UpdateTableTree()
            End If
        End Set
    End Property

    Private ReadOnly Property Schema() As OleDbSchema
        Get
            Return Me._builder.Schema
        End Get
    End Property

    Public Property SelectStatement() As String
        Get
            Return Me._builder.Sql()
        End Get
        Set(ByVal value As String)
        End Set
    End Property

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

    'Private Sub _btnGroupBy_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me._btnGroupBy.Checked = Not Me._btnGroupBy.Checked
    '    Me._builder.GroupBy = Me._btnGroupBy.Checked
    '    'Me._txtSql.Text = Me._builder.Sql
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

    Private Sub _grid_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles _grid.CellClick
        Try
            If (Me._grid.Columns.Item(e.ColumnIndex).Name = "Filter") Then
                'Using dlg As FilterEditorForm = New FilterEditorForm
                Using dlg As frmFilterBuilder = New frmFilterBuilder
                    Dim field As QueryField = TryCast(Me._grid.Rows.Item(e.RowIndex).DataBoundItem, QueryField)
                    dlg.Font = Me.Font
                    dlg.QueryField = field
                    dlg.QueryFields = _builder
                    If (dlg.ShowDialog(Me) = DialogResult.OK) Then
                        field.Filter = dlg.Value
                        field.FilterFormated = dlg.FilterFValue
                        field.CriteriaOpenParenthesis = dlg.OpenP
                        field.CriteriaCloseParenthesis = dlg.CloseP
                    End If
                End Using
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub _grid_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles _grid.CellEndEdit, _grid.CellContentClick
        Me._grid.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub _grid_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles _grid.DragDrop
        Dim node As TreeNode = TryCast(e.Data.GetData(GetType(TreeNode)), TreeNode)
        If (Not node Is Nothing) Then
            Me.AddField(node.Parent.Text, node.Tag, node.Text)
        Else
            Dim row As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            If (Not row Is Nothing) Then
                Dim pt As System.Drawing.Point = Me._grid.PointToClient(New System.Drawing.Point(e.X, e.Y))
                Dim ht As DataGridView.HitTestInfo = Me._grid.HitTest(pt.X, pt.Y)
                Dim src As Integer = row.Index
                Dim dst As Integer = ht.RowIndex
                If (dst < 0) Then
                    dst = (Me._grid.Rows.Count - 1)
                End If
                If (src <> dst) Then
                    Dim fields As QueryFieldCollection = Me._builder.QueryFields
                    Dim field As QueryField = fields.Item(src)
                    fields.RemoveAt(src)
                    fields.Insert(dst, field)
                End If
            End If
        End If
    End Sub

    Private Sub _grid_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles _grid.DragEnter
        Dim node As TreeNode = TryCast(e.Data.GetData(GetType(TreeNode)), TreeNode)
        If ((Not node Is Nothing) AndAlso (TypeOf node.Tag Is DataColumn OrElse TypeOf node.Tag Is System.Data.DataTable)) Then
            e.Effect = DragDropEffects.Copy
        Else
            Dim row As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            If ((Not row Is Nothing) AndAlso Me._grid.Rows.Contains(row)) Then
                e.Effect = DragDropEffects.Move
            End If
        End If
    End Sub

    Private Sub _grid_DragOver(ByVal sender As Object, ByVal e As DragEventArgs) Handles _grid.DragOver
        Dim row As DataGridViewRow = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
        If (Not row Is Nothing) Then
            Dim pt As System.Drawing.Point = Me._grid.PointToClient(New System.Drawing.Point(e.X, e.Y))
            Select Case Me._grid.HitTest(pt.X, pt.Y).Type
                Case DataGridViewHitTestType.None, DataGridViewHitTestType.Cell, DataGridViewHitTestType.RowHeader
                    e.Effect = DragDropEffects.Move
                    Return
            End Select
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub _grid_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _grid.MouseDown
        Dim ht As DataGridView.HitTestInfo = Me._grid.HitTest(e.X, e.Y)
        If (ht.Type = DataGridViewHitTestType.RowHeader) Then
            Dim row As DataGridViewRow = Me._grid.Rows.Item(ht.RowIndex)
            If (Not row Is Nothing) Then
                Dim field As QueryField = TryCast(row.DataBoundItem, QueryField)
                If (Not field Is Nothing) Then
                    Me._grid.CurrentCell = row.Cells.Item(1) ' before: Me._grid.CurrentCell = row.Cells.Item(0)
                    If (MyBase.DoDragDrop(row, DragDropEffects.Move) <> DragDropEffects.None) Then
                        Me._timer.Tag = field
                        Me._timer.Start()
                    End If
                End If
            End If
        End If
    End Sub

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

    Private Sub _mnuTree_Opening(ByVal sender As Object, ByVal e As CancelEventArgs)
        Dim pt As System.Drawing.Point = Me._treeTables.PointToClient(Control.MousePosition)
        Dim nd As TreeNode = Me._treeTables.GetNodeAt(pt)
        Dim dt As System.Data.DataTable = IIf((nd Is Nothing), Nothing, TryCast(nd.Tag, System.Data.DataTable))
        If (Not nd Is Nothing) Then
            Me._treeTables.SelectedNode = nd
        End If
        If (dt Is Nothing) Then
            e.Cancel = True
        Else
            'Me._mnuRelatedTables.DropDownItems.Clear()
            If ((Not nd Is Nothing) AndAlso TypeOf nd.Tag Is System.Data.DataTable) Then
                Dim list As New List(Of String)
                Dim dr As DataRelation
                For Each dr In Me._builder.Schema.Relations
                    If Not ((Not dr.ParentTable Is dt) OrElse list.Contains(dr.ChildTable.TableName)) Then
                        list.Add(dr.ChildTable.TableName)
                    ElseIf Not ((Not dr.ChildTable Is dt) OrElse list.Contains(dr.ParentTable.TableName)) Then
                        list.Add(dr.ParentTable.TableName)
                    End If
                Next
                list.Sort()
                'Dim tableName As String
                'For Each tableName In list
                '    If (Not Me.FindNode(tableName) Is Nothing) Then
                '        Me._mnuRelatedTables.DropDownItems.Add(tableName)
                '    End If
                'Next
            End If
        End If
    End Sub

    Private Sub _timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Me._timer.Stop()
        Me.SelectField(TryCast(Me._timer.Tag, QueryField))
    End Sub

    Private Sub _treeTables_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles _treeTables.ItemDrag
        Dim node As TreeNode = TryCast(e.Item, TreeNode)
        'If ((Not node Is Nothing) AndAlso (TypeOf node.Tag Is System.Data.DataTable OrElse TypeOf node.Tag Is DataColumn)) Then

        If ((Not node Is Nothing) AndAlso (TypeOf node.Tag Is DataColumn)) Then ' column only to drag do not allow full table
            Me._treeTables.SelectedNode = node
            MyBase.DoDragDrop(e.Item, DragDropEffects.Copy)
        End If
    End Sub

    Private Sub _treeTables_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles _treeTables.NodeMouseDoubleClick
        If ((e.Node Is Me._treeTables.SelectedNode) AndAlso TypeOf e.Node.Tag Is DataColumn) Then
            Me.AddField(e.Node.Parent.Text, e.Node.Tag, e.Node.Text)
        End If
    End Sub

    Private Sub QueryFields_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        sqlstr = Me._builder.Sql()
        txtStrFullCriteria.Text = "= " & Me._builder.CriteriaStatement
        'refresh data grid 
        Me.MainView.Columns.Clear()
        Me.DATA.DataSource = DB.CreateTable(sqlstr)
        If sqlstr = "" Then
            grpCriteriaBuilder.Text = "CRITERIA BUILDER"
        End If
    End Sub

    ' ** Implementation
    Private Sub AddColumn(ByVal ctblNameFormated As String, ByVal dc As DataColumn, Optional ColunmName As String = "", Optional pOutPut As Integer = 1, Optional pSort As Integer = 0, Optional pFilter As String = "", Optional pFilterFormated As String = "", Optional pOParenthesis As String = "", Optional pCParenthesis As String = "", Optional pCritOpenrand As Integer = 0)
        Dim field As New QueryField(ctblNameFormated, dc, ColunmName, pOutPut, pSort, pFilter, pFilterFormated, pOParenthesis, pCParenthesis, pCritOpenrand)
        Me._builder.QueryFields.Add(field)
        Me.SelectField(field)
    End Sub

    Private Sub AddDataColumns(ByVal node As TreeNode, ByVal dt As System.Data.DataTable)
        Dim col As DataColumn
        For Each col In dt.Columns
            Dim findrows() As DataRow = ColumnDescTable.Select("TABLE_NAME='" & dt.TableName.ToString & "' AND COLUMN_NAME='" & col.ColumnName.ToString & "'")
            If findrows.Count = 1 Then
                Dim field As TreeNode = node.Nodes.Add(col.ColumnName)
                field.Tag = col
                field.ImageIndex = 2
                field.SelectedImageIndex = 2
                field.Text = findrows(0)(2)
                field.Name = col.ColumnName
            End If
        Next
    End Sub

    Private Sub AddField(ByVal tblNameFormated As String, ByVal element As Object, Optional ColumnDesc As String = "", Optional zOutPut As Integer = 1, Optional zSort As Integer = 0, Optional zFilter As String = "", Optional zFilterFormated As String = "", Optional zOParenthesis As String = "", Optional zCParenthesis As String = "", Optional zCritOpenrand As Integer = 0)
        'Dim dt As System.Data.DataTable = TryCast(element, System.Data.DataTable)
        'If (Not dt Is Nothing) Then
        '    Me.AddTable(dt)
        'End If
        Dim dc As DataColumn = TryCast(element, DataColumn)
        If (Not dc Is Nothing) Then
            Me.AddColumn(tblNameFormated, dc, ColumnDesc, zOutPut, zSort, zFilter, zFilterFormated, zOParenthesis, zCParenthesis, zCritOpenrand)
        End If
    End Sub

    Private Sub AddTable(ByVal dt As System.Data.DataTable)
        Dim field As New QueryField(dt)
        Me._builder.QueryFields.Add(field)
        Me.SelectField(field)
    End Sub

    Private Function FindNode(ByVal [text] As String) As TreeNode
        Return Me.FindNode(Me._treeTables.Nodes, [text])
    End Function

    Private Function FindNode(ByVal nodes As TreeNodeCollection, ByVal [text] As String) As TreeNode
        Dim node As TreeNode
        For Each node In nodes
            Dim dt As System.Data.DataTable = TryCast(node.Tag, System.Data.DataTable)
            If ((Not dt Is Nothing) AndAlso (dt.TableName = [text])) Then
                Return node
            End If
            Dim child As TreeNode = Me.FindNode(node.Nodes, [text])
            If (Not child Is Nothing) Then
                Return child
            End If
        Next
        Return Nothing
    End Function

    Private Sub FixGridColumns()
        Dim i As Integer
        For i = 0 To Me._grid.Columns.Count - 1
            Dim col As DataGridViewColumn = Me._grid.Columns.Item(i)
            If col.ValueType.IsEnum Then
                Dim cmb As New DataGridViewComboBoxColumn
                cmb.ValueType = col.ValueType
                cmb.Name = col.Name
                cmb.DataPropertyName = col.DataPropertyName
                cmb.HeaderText = col.HeaderText
                cmb.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                cmb.DisplayStyleForCurrentCellOnly = True
                cmb.DataSource = [Enum].GetValues(col.ValueType)
                Me._grid.Columns.RemoveAt(i)
                Me._grid.Columns.Insert(i, cmb)
            ElseIf (col.Name = "Filter") Then
                Dim btn As New DataGridViewButtonColumn
                btn.ValueType = col.ValueType
                btn.Name = col.Name
                btn.DataPropertyName = col.DataPropertyName
                btn.HeaderText = col.HeaderText
                Me._grid.Columns.RemoveAt(i)
                Me._grid.Columns.Insert(i, btn)
            End If
        Next i
    End Sub

    Private Sub SelectField(ByVal field As QueryField)
        Dim cm As CurrencyManager = TryCast(Me.BindingContext.Item(Me._grid.DataSource), CurrencyManager)
        cm.Position = cm.List.IndexOf(field)
    End Sub

    Private Sub UpdateGridColumns()
        Me._grid.Columns.Item("Column").Frozen = True
        Me._grid.Columns.Item("Column").Visible = False
        Me._grid.Columns.Item("Table").Visible = False
        Me._grid.Columns.Item("TableNameFormated").HeaderText = "Table Name"
        Me._grid.Columns.Item("TableNameFormated").ReadOnly = True
        Me._grid.Columns.Item("Alias").HeaderText = "Column"
        Me._grid.Columns.Item("CriteriaOperator").HeaderText = "Operator"
        Me._grid.Columns.Item("GroupBy").Visible = Me._builder.GroupBy
        Me._grid.Columns.Item("FilterFormated").Visible = False
        Me._grid.Columns.Item("CriteriaOpenParenthesis").Visible = False
        Me._grid.Columns.Item("CriteriaCloseParenthesis").Visible = False
    End Sub

    Private Sub UpdateTableTree()
        Dim tblcounter As Integer = 0
        Dim nodes As TreeNodeCollection = Me._treeTables.Nodes
        nodes.Clear()
        Dim ndTables As New TreeNode(My.Resources.Tables, 0, 0)
        Dim ndViews As New TreeNode(My.Resources.Views, 1, 1)
        If (Not Me.Schema Is Nothing) Then
            Me._treeTables.BeginUpdate()
            Dim dt As System.Data.DataTable
            For Each dt In Me.Schema.Tables
                Dim node As New TreeNode(dt.TableName)
                node.Tag = dt
                Select Case OleDbSchema.GetTableType(dt)
                    Case TableType.Table
                        ndTables.Nodes.Add(node)
                        node.ImageIndex = 0
                        node.SelectedImageIndex = 0
                        node.Text = OleDbSchema.GetTableDescription(dt) ' elmer display table description to user
                        node.Name = dt.TableName.ToString
                        Me.AddDataColumns(node, dt)
                        tblcounter = tblcounter + 1
                        Exit Select
                    Case TableType.View
                        Exit Select 'uncomment this if views will display.. elmer 20150605
                        ndViews.Nodes.Add(node)
                        node.ImageIndex = 1
                        node.SelectedImageIndex = 1
                        Me.AddDataColumns(node, dt)
                        Exit Select
                End Select
            Next

            Dim nd As TreeNode
            For Each nd In New TreeNode() {ndTables, ndViews}
                If (nd.Nodes.Count > 0) Then
                    nd.Text = String.Format("{0} ({1})", nd.Text, nd.Nodes.Count)
                    nodes.Add(nd)
                End If
            Next
            ndTables.Expand()
            Me._treeTables.EndUpdate()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MsgBox(sqlstr)
    End Sub

    'Save Report Template
    Public Overrides Sub SaveData()

        Dim id As String = ""
        Dim bSuccess As Boolean
        Dim cTemplateNameDesc As String = ""

        If sqlstr = "" Then
            MsgBox("Cannot save as a report template." & vbNewLine & vbNewLine & "Please ceate a valid result data.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            LoadedTemplate = ""
        Else
            'begin add or update templates
            If LoadedTemplate = "" Then
                cTemplateNameDesc = "TemplateName;TemplateDesc"
            Else
                cTemplateNameDesc = LoadedTemplate
            End If

            cTemplateNameDesc = InputBox("Enter a Template name to save. Existing template with the same name will be overwritten." & vbNewLine & vbNewLine & "Format: <Template Name>;<Description>" & vbNewLine & "Ex: Crewlist;List of Crew", "Save Template", cTemplateNameDesc)
            If cTemplateNameDesc = "" Then
                MsgBox("Save cancelled.", 64, GetAppName)
            Else

                Dim cTemp As String()
                cTemp = cTemplateNameDesc.Split(";")
                Dim cTemplateName As String = ""
                Dim cTemplateDesc As String = ""

                If cTemp.Count <= 2 Then
                    cTemplateName = cTemp(0).ToString

                    If cTemp.Count = 2 Then
                        cTemplateDesc = cTemp(1).ToString
                    End If

                    Dim strTempNameID As String = ""
                    strTempNameID = DB.DLookUp("PKey", Me.TableName, "", "TemplateName='" & cTemplateName & "'")

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Query Builder", 0, System.Environment.MachineName, "Template Name : " & cTemplateName, "Reports")

                    If strTempNameID = "" Then
                        bSuccess = DB.RunSql("INSERT INTO " & Me.TableName & " (TemplateName,TemplateDesc,LastUpdatedBy) VALUES ('" & cTemplateName.Replace("'", "''") & "','" & cTemplateDesc.Replace("'", "''") & "','" & LastUpdatedBy & "')")
                        id = IfNull(DB.GetLastInsertedItem("PKey", Me.TableName), "")
                        bSuccess = DB.RunSql("DELETE FROM dbo.tblReportTemplatesConfigs WHERE FKeyRPTID='" & id & "'")
                    Else
                        If MsgBox("Template: '" & cTemplateName & "' already exist." & vbNewLine & vbNewLine & "Overwrite existing template?", 36, GetAppName) = vbYes Then
                            id = strTempNameID
                            bSuccess = DB.RunSql("UPDATE " & Me.TableName & " SET TemplateName='" & cTemplateName.Replace("'", "''") & "',TemplateDesc='" & cTemplateDesc.Replace("'", "''") & "',LastUpdatedBy='" & LastUpdatedBy & "' WHERE PKey='" & id & "'")
                            bSuccess = DB.RunSql("DELETE FROM dbo.tblReportTemplatesConfigs WHERE FKeyRPTID='" & id & "'")
                        Else
                            MsgBox("Save cancelled.", 64, GetAppName)
                            Exit Sub
                        End If

                    End If


                    Dim sqls As New ArrayList
                    With Me._grid

                        For x As Integer = 0 To _grid.Rows.Count - 1
                            sqls.Add("INSERT INTO dbo.tblReportTemplatesConfigs(FKeyRPTID" & _
                                          ",TblName" & _
                                          ",TblNameFormated" & _
                                          ",ColName" & _
                                          ",StrAlias" & _
                                          ",IsOutput" & _
                                          ",SortBy" & _
                                          ",WhereCon" & _
                                          ",WhereConFormated" & _
                                          ",OpenP" & _
                                          ",CloseP" & _
                                          ",CriteriaOpenrand" & _
                                          ",OrderNo" & _
                                          ",LastUpdatedBy ) " & _
                                          "VALUES('" & id & "'" & _
                                          ",'" & .Rows(x).Cells.Item("Table").Value & "'" & _
                                          ",'" & .Rows(x).Cells.Item("TableNameFormated").Value & "'" & _
                                          ",'" & .Rows(x).Cells.Item("Column").Value & "'" & _
                                          ",'" & .Rows(x).Cells.Item("Alias").Value & "'" & _
                                          ",'" & IIf(.Rows(x).Cells.Item("Output").Value = True, 1, 0) & "'" & _
                                          ",'" & .Rows(x).Cells.Item("Sort").Value & "'" & _
                                          ",'" & .Rows(x).Cells.Item("Filter").Value.ToString.Replace("'", "''") & "'" & _
                                          ",'" & .Rows(x).Cells.Item("FilterFormated").Value.ToString.Replace("'", "''") & "'" & _
                                          ",'" & .Rows(x).Cells.Item("CriteriaOpenParenthesis").Value & "'" & _
                                          ",'" & .Rows(x).Cells.Item("CriteriaCloseParenthesis").Value & "'" & _
                                          ",'" & .Rows(x).Cells.Item("CriteriaOperator").Value & "'" & _
                                          ",'" & x & "'" & _
                                          ",'" & LastUpdatedBy & "')")
                        Next
                    End With

                    If Not sqls Is Nothing And bSuccess Then
                        bSuccess = DB.RunSqls(sqls)
                    End If

                    If bSuccess Then
                        MsgBox("Template:  '" & cTemplateName & "' saved.", 64, GetAppName)
                        'populate report templates
                        RefreshTemplates()
                        LoadedTemplate = ""
                    End If
                Else
                    MsgBox("Invalid format.", MsgBoxStyle.Exclamation, GetAppName)
                End If
            End If
        End If
    End Sub

    'Load Template
    Private Sub LoadTemplate()
        If GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateName") <> "" Then
            If MsgBox("Load Template: '" & GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateName") & "'?", 36, GetAppName) = vbYes Then
                LoadT(GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "PKey"))
            End If
        Else
            MsgBox("Please select template to load.", MsgBoxStyle.Information, GetAppName)
        End If
    End Sub

    Private Sub LoadT(ByVal PKey As String)
        Try
            SplashScreenManager.ShowForm(GetType(Waitform))
            _grid.Rows.Clear()
            Dim templateItems As New DataTable
            templateItems = DB.CreateTable("SELECT * FROM dbo.tblReportTemplatesConfigs WHERE FKeyRPTID='" & PKey & "' ORDER BY OrderNo ASC")

            For Each dr In templateItems.Rows
                Dim xTable As String = dr("TblName").ToString
                Dim xColumn As String = dr("ColName").ToString
                Dim xAlias As String = dr("StrAlias").ToString
                Dim xOutput As Integer = CInt(dr("IsOutput"))
                Dim xSort As Integer = CInt(dr("SortBy"))
                Dim xFilter As String = dr("WhereCon").ToString
                Dim xFilterFormated As String = dr("WhereConFormated").ToString
                Dim xOParenthesis As String = dr("OpenP").ToString
                Dim xCParenthesis As String = dr("CloseP").ToString
                Dim xCritOpenrand As Integer = CInt(dr("CriteriaOpenrand"))

                Dim ParentNode() As TreeNode = _treeTables.Nodes.Find(xTable, True)
                Dim ChildNode() As TreeNode = ParentNode(0).Nodes.Find(xColumn, True)

                AddField(ParentNode(0).Text, ChildNode(0).Tag, xAlias, xOutput, xSort, xFilter, xFilterFormated, xOParenthesis, xCParenthesis, xCritOpenrand)
            Next
            SplashScreenManager.CloseForm()
            LoadedTemplate = GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateName") & ";" & GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateDesc")
            grpCriteriaBuilder.Text = "CRITERIA BUILDER - " & GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateName").ToString
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppPath)
        End Try
    End Sub

    'Delete Template
    Public Overrides Sub DeleteData()
        If GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateName") <> "" Then
            If MsgBox("Are you sure want to delete the template: '" & GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateName") & "'?", MsgBoxStyle.Critical + vbYesNo + vbDefaultButton2) = MsgBoxResult.Yes Then

                clsAudit.propSQLConnStr = MPSDB.GetConnectionString

                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Query Builder Template", 0, System.Environment.MachineName, "Template : " & GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "TemplateName"), "Query Builder") 'neil
                clsAudit.saveAuditPreDelDetails(Me.TableName, GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                DB.RunSql("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "PKey") & "'")
                MsgBox("Template Deleted.", MsgBoxStyle.Information, GetAppName)
                RefreshTemplates()
            End If
        Else
            MsgBox("Please select template to delete.", MsgBoxStyle.Information, GetAppName)
        End If

    End Sub

    Private Function GetId() As String
        If GridRepTemplates.RowCount > 0 Then
            Return GridRepTemplates.GetRowCellValue(GridRepTemplates.FocusedRowHandle, "PKey")
        Else
            Return ""
        End If
    End Function

    Private Sub GridRepTemplates_RowCellStyle(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridRepTemplates.RowCellStyle
        If e.RowHandle = GridRepTemplates.FocusedRowHandle And Not bAddMode Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub GridRepTemplates_FocusedRowChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridRepTemplates.FocusedRowChanged
        If GridRepTemplates.FocusedRowHandle >= 0 Then
            strID = GetId()
        End If
    End Sub

    Private Sub GridRepTemplates_Click(sender As System.Object, e As System.EventArgs) Handles GridRepTemplates.Click
        bAddMode = False
        GridRepTemplates.RefreshRow(GridRepTemplates.FocusedRowHandle)
    End Sub

    Private Sub GridRepTemplates_DoubleClick(sender As Object, e As EventArgs) Handles GridRepTemplates.DoubleClick
        Try
            Dim oSender As GridView = DirectCast(sender, GridView)
            If oSender.FocusedRowHandle >= 0 Then
                Dim p As Point = oSender.GridControl.PointToClient(Control.MousePosition)
                Dim hi As GridHitInfo = DirectCast(sender, GridView).CalcHitInfo(p)
                If hi.HitTest = GridHitTest.Row OrElse hi.HitTest = GridHitTest.RowCell Then
                    'Load Template
                    LoadTemplate()
                End If
            End If
        Catch ex As Exception
            'Log exception
        End Try
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub
End Class





