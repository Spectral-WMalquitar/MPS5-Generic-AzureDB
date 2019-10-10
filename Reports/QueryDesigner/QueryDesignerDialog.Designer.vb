<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryDesignerDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryDesignerDialog))
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me._treeTables = New System.Windows.Forms.TreeView()
        Me._mnuTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me._mnuHideThisTable = New System.Windows.Forms.ToolStripMenuItem()
        Me._mnuShowAllTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me._mnuRelatedTables = New System.Windows.Forms.ToolStripMenuItem()
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me._grid = New System.Windows.Forms.DataGridView()
        Me._txtSql = New System.Windows.Forms.TextBox()
        Me._toolStrip = New System.Windows.Forms.ToolStrip()
        Me._btnConnString = New System.Windows.Forms.ToolStripButton()
        Me._btnGroupBy = New System.Windows.Forms.ToolStripButton()
        Me._btnProperties = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me._btnCheckSql = New System.Windows.Forms.ToolStripButton()
        Me._btnViewResults = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me._btnClearQuery = New System.Windows.Forms.ToolStripButton()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me._lblStatus = New System.Windows.Forms.Label()
        Me._btnCancel = New System.Windows.Forms.Button()
        Me._btnOK = New System.Windows.Forms.Button()
        Me._imgList = New System.Windows.Forms.ImageList(Me.components)
        Me._timer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me._mnuTree.SuspendLayout()
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.Panel2.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        CType(Me._grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._toolStrip.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.splitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me._treeTables)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.splitContainer2)
        Me.splitContainer1.Size = New System.Drawing.Size(580, 272)
        Me.splitContainer1.SplitterDistance = 233
        Me.splitContainer1.SplitterWidth = 3
        Me.splitContainer1.TabIndex = 5
        '
        '_treeTables
        '
        Me._treeTables.ContextMenuStrip = Me._mnuTree
        Me._treeTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me._treeTables.Location = New System.Drawing.Point(0, 0)
        Me._treeTables.Margin = New System.Windows.Forms.Padding(2)
        Me._treeTables.Name = "_treeTables"
        Me._treeTables.Size = New System.Drawing.Size(233, 272)
        Me._treeTables.TabIndex = 0
        '
        '_mnuTree
        '
        Me._mnuTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuHideThisTable, Me._mnuShowAllTables, Me.toolStripMenuItem1, Me._mnuRelatedTables})
        Me._mnuTree.Name = "_mnuTree"
        Me._mnuTree.Size = New System.Drawing.Size(153, 76)
        '
        '_mnuHideThisTable
        '
        Me._mnuHideThisTable.Name = "_mnuHideThisTable"
        Me._mnuHideThisTable.Size = New System.Drawing.Size(152, 22)
        Me._mnuHideThisTable.Text = "Hide this table"
        '
        '_mnuShowAllTables
        '
        Me._mnuShowAllTables.Name = "_mnuShowAllTables"
        Me._mnuShowAllTables.Size = New System.Drawing.Size(152, 22)
        Me._mnuShowAllTables.Text = "Show all tables"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        '_mnuRelatedTables
        '
        Me._mnuRelatedTables.Name = "_mnuRelatedTables"
        Me._mnuRelatedTables.Size = New System.Drawing.Size(152, 22)
        Me._mnuRelatedTables.Text = "Related tables"
        '
        'splitContainer2
        '
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer2.Margin = New System.Windows.Forms.Padding(2)
        Me.splitContainer2.Name = "splitContainer2"
        Me.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me._grid)
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me._txtSql)
        Me.splitContainer2.Size = New System.Drawing.Size(344, 272)
        Me.splitContainer2.SplitterDistance = 155
        Me.splitContainer2.SplitterWidth = 3
        Me.splitContainer2.TabIndex = 0
        '
        '_grid
        '
        Me._grid.AllowDrop = True
        Me._grid.AllowUserToAddRows = False
        Me._grid.AllowUserToResizeRows = False
        Me._grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me._grid.Location = New System.Drawing.Point(0, 0)
        Me._grid.Margin = New System.Windows.Forms.Padding(2)
        Me._grid.MultiSelect = False
        Me._grid.Name = "_grid"
        Me._grid.RowTemplate.Height = 24
        Me._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me._grid.Size = New System.Drawing.Size(344, 155)
        Me._grid.TabIndex = 0
        '
        '_txtSql
        '
        Me._txtSql.BackColor = System.Drawing.SystemColors.Window
        Me._txtSql.Dock = System.Windows.Forms.DockStyle.Fill
        Me._txtSql.Location = New System.Drawing.Point(0, 0)
        Me._txtSql.Margin = New System.Windows.Forms.Padding(2)
        Me._txtSql.Multiline = True
        Me._txtSql.Name = "_txtSql"
        Me._txtSql.ReadOnly = True
        Me._txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._txtSql.Size = New System.Drawing.Size(344, 114)
        Me._txtSql.TabIndex = 0
        Me._txtSql.WordWrap = False
        '
        '_toolStrip
        '
        Me._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me._toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._btnConnString, Me._btnGroupBy, Me._btnProperties, Me.toolStripSeparator1, Me._btnCheckSql, Me._btnViewResults, Me.toolStripSeparator2, Me._btnClearQuery})
        Me._toolStrip.Location = New System.Drawing.Point(0, 0)
        Me._toolStrip.Name = "_toolStrip"
        Me._toolStrip.Size = New System.Drawing.Size(580, 25)
        Me._toolStrip.TabIndex = 4
        Me._toolStrip.Text = "toolStrip1"
        '
        '_btnConnString
        '
        Me._btnConnString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._btnConnString.Image = CType(resources.GetObject("_btnConnString.Image"), System.Drawing.Image)
        Me._btnConnString.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._btnConnString.Name = "_btnConnString"
        Me._btnConnString.Size = New System.Drawing.Size(23, 22)
        Me._btnConnString.Text = "Select connection string"
        Me._btnConnString.Visible = False
        '
        '_btnGroupBy
        '
        Me._btnGroupBy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._btnGroupBy.Image = CType(resources.GetObject("_btnGroupBy.Image"), System.Drawing.Image)
        Me._btnGroupBy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._btnGroupBy.Name = "_btnGroupBy"
        Me._btnGroupBy.Size = New System.Drawing.Size(23, 22)
        Me._btnGroupBy.Text = "Group results"
        '
        '_btnProperties
        '
        Me._btnProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._btnProperties.Image = CType(resources.GetObject("_btnProperties.Image"), System.Drawing.Image)
        Me._btnProperties.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._btnProperties.Name = "_btnProperties"
        Me._btnProperties.Size = New System.Drawing.Size(23, 22)
        Me._btnProperties.Text = "Query properties"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        '_btnCheckSql
        '
        Me._btnCheckSql.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._btnCheckSql.Image = CType(resources.GetObject("_btnCheckSql.Image"), System.Drawing.Image)
        Me._btnCheckSql.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._btnCheckSql.Name = "_btnCheckSql"
        Me._btnCheckSql.Size = New System.Drawing.Size(23, 22)
        Me._btnCheckSql.Text = "Check SQL syntax"
        '
        '_btnViewResults
        '
        Me._btnViewResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._btnViewResults.Image = CType(resources.GetObject("_btnViewResults.Image"), System.Drawing.Image)
        Me._btnViewResults.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._btnViewResults.Name = "_btnViewResults"
        Me._btnViewResults.Size = New System.Drawing.Size(23, 22)
        Me._btnViewResults.Text = "View query results"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        '_btnClearQuery
        '
        Me._btnClearQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me._btnClearQuery.Image = CType(resources.GetObject("_btnClearQuery.Image"), System.Drawing.Image)
        Me._btnClearQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me._btnClearQuery.Name = "_btnClearQuery"
        Me._btnClearQuery.Size = New System.Drawing.Size(23, 22)
        Me._btnClearQuery.Text = "Clear query"
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me._lblStatus)
        Me.panel1.Controls.Add(Me._btnCancel)
        Me.panel1.Controls.Add(Me._btnOK)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel1.Location = New System.Drawing.Point(0, 297)
        Me.panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(580, 33)
        Me.panel1.TabIndex = 6
        '
        '_lblStatus
        '
        Me._lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._lblStatus.Location = New System.Drawing.Point(10, 6)
        Me._lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me._lblStatus.Name = "_lblStatus"
        Me._lblStatus.Size = New System.Drawing.Size(410, 22)
        Me._lblStatus.TabIndex = 8
        Me._lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_btnCancel
        '
        Me._btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me._btnCancel.Location = New System.Drawing.Point(501, 6)
        Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me._btnCancel.Name = "_btnCancel"
        Me._btnCancel.Size = New System.Drawing.Size(70, 22)
        Me._btnCancel.TabIndex = 7
        Me._btnCancel.Text = "Cancel"
        Me._btnCancel.UseVisualStyleBackColor = True
        '
        '_btnOK
        '
        Me._btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me._btnOK.Location = New System.Drawing.Point(425, 6)
        Me._btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me._btnOK.Name = "_btnOK"
        Me._btnOK.Size = New System.Drawing.Size(70, 22)
        Me._btnOK.TabIndex = 6
        Me._btnOK.Text = "OK"
        Me._btnOK.UseVisualStyleBackColor = True
        '
        '_imgList
        '
        Me._imgList.ImageStream = CType(resources.GetObject("_imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me._imgList.TransparentColor = System.Drawing.Color.Red
        Me._imgList.Images.SetKeyName(0, "Table.png")
        Me._imgList.Images.SetKeyName(1, "View.png")
        Me._imgList.Images.SetKeyName(2, "Field.png")
        '
        '_timer
        '
        Me._timer.Interval = 10
        '
        'QueryDesignerDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(580, 330)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me._toolStrip)
        Me.Controls.Add(Me.panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QueryDesignerDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Query Designer"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me._mnuTree.ResumeLayout(False)
        Me.splitContainer2.Panel1.ResumeLayout(False)
        Me.splitContainer2.Panel2.ResumeLayout(False)
        Me.splitContainer2.Panel2.PerformLayout()
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer2.ResumeLayout(False)
        CType(Me._grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me._toolStrip.ResumeLayout(False)
        Me._toolStrip.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents _treeTables As System.Windows.Forms.TreeView
    Private WithEvents splitContainer2 As System.Windows.Forms.SplitContainer
    Private WithEvents _grid As System.Windows.Forms.DataGridView
    Private WithEvents _txtSql As System.Windows.Forms.TextBox
    Private WithEvents _toolStrip As System.Windows.Forms.ToolStrip
    Private WithEvents _btnConnString As System.Windows.Forms.ToolStripButton
    Private WithEvents _btnGroupBy As System.Windows.Forms.ToolStripButton
    Private WithEvents _btnProperties As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _btnCheckSql As System.Windows.Forms.ToolStripButton
    Private WithEvents _btnViewResults As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _btnClearQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents _lblStatus As System.Windows.Forms.Label
    Private WithEvents _btnCancel As System.Windows.Forms.Button
    Private WithEvents _btnOK As System.Windows.Forms.Button
    Private WithEvents _imgList As System.Windows.Forms.ImageList
    Private WithEvents _timer As System.Windows.Forms.Timer
    Private WithEvents _mnuTree As System.Windows.Forms.ContextMenuStrip
    Private WithEvents _mnuHideThisTable As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents _mnuShowAllTables As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents _mnuRelatedTables As System.Windows.Forms.ToolStripMenuItem
End Class
