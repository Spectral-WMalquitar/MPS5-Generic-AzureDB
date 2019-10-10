<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataUtility
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataUtility))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.cmdApply = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdMerge = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdDuplicate = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.MainPanel = New DevExpress.XtraEditors.SplitContainerControl()
        Me.gcMain = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MainPanel2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.gcList1 = New DevExpress.XtraEditors.GroupControl()
        Me.MergeGrid = New DevExpress.XtraGrid.GridControl()
        Me.MergeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.repFileTag = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gcList2 = New DevExpress.XtraEditors.GroupControl()
        Me.ReplaceWithGrid = New DevExpress.XtraGrid.GridControl()
        Me.ReplaceWithView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        CType(Me.gcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcMain.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel2.SuspendLayout()
        CType(Me.gcList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcList1.SuspendLayout()
        CType(Me.MergeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MergeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFileTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcList2.SuspendLayout()
        CType(Me.ReplaceWithGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReplaceWithView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.cmdApply, Me.cmdRefresh, Me.cmdCancel, Me.cmdMerge, Me.cmdDuplicate})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl.MaxItemId = 10
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(1004, 131)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'cmdApply
        '
        Me.cmdApply.Caption = "Apply"
        Me.cmdApply.Glyph = CType(resources.GetObject("cmdApply.Glyph"), System.Drawing.Image)
        Me.cmdApply.GroupIndex = 2
        Me.cmdApply.Id = 1
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Caption = "Refresh"
        Me.cmdRefresh.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdRefresh.Glyph = CType(resources.GetObject("cmdRefresh.Glyph"), System.Drawing.Image)
        Me.cmdRefresh.GroupIndex = 2
        Me.cmdRefresh.Id = 2
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdCancel
        '
        Me.cmdCancel.Caption = "Cancel"
        Me.cmdCancel.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdCancel.Glyph = CType(resources.GetObject("cmdCancel.Glyph"), System.Drawing.Image)
        Me.cmdCancel.GroupIndex = 2
        Me.cmdCancel.Id = 3
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdMerge
        '
        Me.cmdMerge.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.cmdMerge.Caption = "Merge and Replace"
        Me.cmdMerge.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdMerge.Glyph = CType(resources.GetObject("cmdMerge.Glyph"), System.Drawing.Image)
        Me.cmdMerge.GroupIndex = 1
        Me.cmdMerge.Id = 4
        Me.cmdMerge.Name = "cmdMerge"
        Me.cmdMerge.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdDuplicate
        '
        Me.cmdDuplicate.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.cmdDuplicate.Caption = "Duplicate"
        Me.cmdDuplicate.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdDuplicate.Glyph = CType(resources.GetObject("cmdDuplicate.Glyph"), System.Drawing.Image)
        Me.cmdDuplicate.GroupIndex = 1
        Me.cmdDuplicate.Id = 5
        Me.cmdDuplicate.Name = "cmdDuplicate"
        Me.cmdDuplicate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.cmdMerge)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.cmdDuplicate)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Tag = "1"
        Me.RibbonPageGroup2.Text = "Tool"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdRefresh)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdApply)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdCancel)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Tag = "2"
        Me.RibbonPageGroup1.Text = "Editing Options"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 728)
        Me.RibbonStatusBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1004, 31)
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 131)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.MainPanel.Panel1.Controls.Add(Me.gcMain)
        Me.MainPanel.Panel1.Text = "Panel1"
        Me.MainPanel.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.MainPanel.Panel2.Controls.Add(Me.MainPanel2)
        Me.MainPanel.Panel2.Text = "Panel2"
        Me.MainPanel.Size = New System.Drawing.Size(1004, 597)
        Me.MainPanel.SplitterPosition = 381
        Me.MainPanel.TabIndex = 6
        Me.MainPanel.Text = "SplitContainerControl1"
        '
        'gcMain
        '
        Me.gcMain.Controls.Add(Me.MainGrid)
        Me.gcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcMain.Location = New System.Drawing.Point(0, 0)
        Me.gcMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gcMain.Name = "gcMain"
        Me.gcMain.Size = New System.Drawing.Size(441, 593)
        Me.gcMain.TabIndex = 0
        Me.gcMain.Text = "Items"
        '
        'MainGrid
        '
        Me.MainGrid.AllowDrop = True
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.EmbeddedNavigator.AllowDrop = True
        Me.MainGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainGrid.Location = New System.Drawing.Point(2, 24)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(437, 567)
        Me.MainGrid.TabIndex = 8
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.MainView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.MainView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.Row.Options.UseTextOptions = True
        Me.MainView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.MainView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'MainPanel2
        '
        Me.MainPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel2.Horizontal = False
        Me.MainPanel2.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainPanel2.Name = "MainPanel2"
        Me.MainPanel2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.MainPanel2.Panel1.Controls.Add(Me.gcList1)
        Me.MainPanel2.Panel1.Text = "Panel1"
        Me.MainPanel2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.MainPanel2.Panel2.Controls.Add(Me.gcList2)
        Me.MainPanel2.Panel2.Text = "Panel2"
        Me.MainPanel2.Size = New System.Drawing.Size(550, 593)
        Me.MainPanel2.SplitterPosition = 325
        Me.MainPanel2.TabIndex = 6
        Me.MainPanel2.Text = "SplitContainerControl1"
        '
        'gcList1
        '
        Me.gcList1.Controls.Add(Me.MergeGrid)
        Me.gcList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcList1.Location = New System.Drawing.Point(0, 0)
        Me.gcList1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gcList1.Name = "gcList1"
        Me.gcList1.Size = New System.Drawing.Size(546, 376)
        Me.gcList1.TabIndex = 0
        Me.gcList1.Text = "GroupControl1"
        '
        'MergeGrid
        '
        Me.MergeGrid.AllowDrop = True
        Me.MergeGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MergeGrid.EmbeddedNavigator.AllowDrop = True
        Me.MergeGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MergeGrid.Location = New System.Drawing.Point(2, 24)
        Me.MergeGrid.MainView = Me.MergeView
        Me.MergeGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MergeGrid.Name = "MergeGrid"
        Me.MergeGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repFileTag})
        Me.MergeGrid.Size = New System.Drawing.Size(542, 350)
        Me.MergeGrid.TabIndex = 9
        Me.MergeGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MergeView})
        '
        'MergeView
        '
        Me.MergeView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.MergeView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MergeView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.MergeView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MergeView.Appearance.Row.Options.UseTextOptions = True
        Me.MergeView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MergeView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MergeView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MergeView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.MergeView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MergeView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MergeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MergeView.GridControl = Me.MergeGrid
        Me.MergeView.Name = "MergeView"
        Me.MergeView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MergeView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MergeView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MergeView.OptionsBehavior.Editable = False
        Me.MergeView.OptionsCustomization.AllowFilter = False
        Me.MergeView.OptionsCustomization.AllowGroup = False
        Me.MergeView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MergeView.OptionsFind.AllowFindPanel = False
        Me.MergeView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MergeView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MergeView.OptionsSelection.UseIndicatorForSelection = False
        Me.MergeView.OptionsView.ShowGroupPanel = False
        '
        'repFileTag
        '
        Me.repFileTag.AutoHeight = False
        Me.repFileTag.MaxLength = 5
        Me.repFileTag.Name = "repFileTag"
        '
        'gcList2
        '
        Me.gcList2.Controls.Add(Me.ReplaceWithGrid)
        Me.gcList2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcList2.Location = New System.Drawing.Point(0, 0)
        Me.gcList2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gcList2.Name = "gcList2"
        Me.gcList2.Size = New System.Drawing.Size(546, 204)
        Me.gcList2.TabIndex = 0
        Me.gcList2.Text = "GroupControl2"
        '
        'ReplaceWithGrid
        '
        Me.ReplaceWithGrid.AllowDrop = True
        Me.ReplaceWithGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReplaceWithGrid.EmbeddedNavigator.AllowDrop = True
        Me.ReplaceWithGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReplaceWithGrid.Location = New System.Drawing.Point(2, 24)
        Me.ReplaceWithGrid.MainView = Me.ReplaceWithView
        Me.ReplaceWithGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReplaceWithGrid.Name = "ReplaceWithGrid"
        Me.ReplaceWithGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.ReplaceWithGrid.Size = New System.Drawing.Size(542, 178)
        Me.ReplaceWithGrid.TabIndex = 10
        Me.ReplaceWithGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReplaceWithView})
        '
        'ReplaceWithView
        '
        Me.ReplaceWithView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.ReplaceWithView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReplaceWithView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.ReplaceWithView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReplaceWithView.Appearance.Row.Options.UseTextOptions = True
        Me.ReplaceWithView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReplaceWithView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ReplaceWithView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.ReplaceWithView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.ReplaceWithView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ReplaceWithView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ReplaceWithView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.ReplaceWithView.GridControl = Me.ReplaceWithGrid
        Me.ReplaceWithView.Name = "ReplaceWithView"
        Me.ReplaceWithView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReplaceWithView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReplaceWithView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.ReplaceWithView.OptionsBehavior.Editable = False
        Me.ReplaceWithView.OptionsCustomization.AllowFilter = False
        Me.ReplaceWithView.OptionsCustomization.AllowGroup = False
        Me.ReplaceWithView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ReplaceWithView.OptionsFind.AllowFindPanel = False
        Me.ReplaceWithView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.ReplaceWithView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.ReplaceWithView.OptionsSelection.UseIndicatorForSelection = False
        Me.ReplaceWithView.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.MaxLength = 5
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'DataUtility
        '
        Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.[False]
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 759)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DataUtility"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Data Utility"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        CType(Me.gcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcMain.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel2.ResumeLayout(False)
        CType(Me.gcList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcList1.ResumeLayout(False)
        CType(Me.MergeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MergeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFileTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcList2.ResumeLayout(False)
        CType(Me.ReplaceWithGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReplaceWithView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents cmdApply As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdMerge As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdDuplicate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents MainPanel As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents MainPanel2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents gcMain As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcList1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MergeGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MergeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcList2 As DevExpress.XtraEditors.GroupControl
    Public WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents repFileTag As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ReplaceWithGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReplaceWithView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit


End Class
