<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADVANCEDSEARCH
    Inherits BaseControl.BaseControl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADVANCEDSEARCH))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.splContainer = New System.Windows.Forms.SplitContainer()
        Me._treeTables = New System.Windows.Forms.TreeView()
        Me.splCritTemplates = New System.Windows.Forms.SplitContainer()
        Me.splContainMain = New System.Windows.Forms.SplitContainer()
        Me.splConCriteriaBuilder = New System.Windows.Forms.SplitContainer()
        Me.grpCriteriaBuilder = New DevExpress.XtraEditors.GroupControl()
        Me._grid = New System.Windows.Forms.DataGridView()
        Me.grpFullCrit = New DevExpress.XtraEditors.GroupControl()
        Me.txtStrFullCriteria = New DevExpress.XtraEditors.MemoEdit()
        Me.grpCntrlData = New DevExpress.XtraEditors.GroupControl()
        Me.DATA = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.grpTemplates = New DevExpress.XtraEditors.GroupControl()
        Me.GridTemplates = New DevExpress.XtraGrid.GridControl()
        Me.GridRepTemplates = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.TemplateName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TemplateDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me._timer = New System.Windows.Forms.Timer(Me.components)
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Reports.Waitform), True, True, DevExpress.XtraSplashScreen.ParentType.UserControl)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.splContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splContainer.Panel1.SuspendLayout()
        Me.splContainer.Panel2.SuspendLayout()
        Me.splContainer.SuspendLayout()
        CType(Me.splCritTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splCritTemplates.Panel1.SuspendLayout()
        Me.splCritTemplates.Panel2.SuspendLayout()
        Me.splCritTemplates.SuspendLayout()
        CType(Me.splContainMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splContainMain.Panel1.SuspendLayout()
        Me.splContainMain.Panel2.SuspendLayout()
        Me.splContainMain.SuspendLayout()
        CType(Me.splConCriteriaBuilder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splConCriteriaBuilder.Panel1.SuspendLayout()
        Me.splConCriteriaBuilder.Panel2.SuspendLayout()
        Me.splConCriteriaBuilder.SuspendLayout()
        CType(Me.grpCriteriaBuilder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCriteriaBuilder.SuspendLayout()
        CType(Me._grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpFullCrit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFullCrit.SuspendLayout()
        CType(Me.txtStrFullCriteria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpCntrlData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCntrlData.SuspendLayout()
        CType(Me.DATA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTemplates.SuspendLayout()
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRepTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.Button1)
        Me.header.Controls.Add(Me.splContainer)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(867, 706)
        Me.header.TabIndex = 47
        Me.header.Text = "Query Builder"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(136, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(16, 15)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'splContainer
        '
        Me.splContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splContainer.Location = New System.Drawing.Point(2, 24)
        Me.splContainer.Name = "splContainer"
        '
        'splContainer.Panel1
        '
        Me.splContainer.Panel1.Controls.Add(Me._treeTables)
        '
        'splContainer.Panel2
        '
        Me.splContainer.Panel2.Controls.Add(Me.splCritTemplates)
        Me.splContainer.Size = New System.Drawing.Size(863, 680)
        Me.splContainer.SplitterDistance = 199
        Me.splContainer.TabIndex = 0
        '
        '_treeTables
        '
        Me._treeTables.Dock = System.Windows.Forms.DockStyle.Fill
        Me._treeTables.Location = New System.Drawing.Point(0, 0)
        Me._treeTables.Margin = New System.Windows.Forms.Padding(2)
        Me._treeTables.Name = "_treeTables"
        Me._treeTables.Size = New System.Drawing.Size(199, 680)
        Me._treeTables.TabIndex = 1
        '
        'splCritTemplates
        '
        Me.splCritTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splCritTemplates.Location = New System.Drawing.Point(0, 0)
        Me.splCritTemplates.Name = "splCritTemplates"
        '
        'splCritTemplates.Panel1
        '
        Me.splCritTemplates.Panel1.Controls.Add(Me.splContainMain)
        '
        'splCritTemplates.Panel2
        '
        Me.splCritTemplates.Panel2.Controls.Add(Me.grpTemplates)
        Me.splCritTemplates.Size = New System.Drawing.Size(660, 680)
        Me.splCritTemplates.SplitterDistance = 481
        Me.splCritTemplates.TabIndex = 1
        '
        'splContainMain
        '
        Me.splContainMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splContainMain.Location = New System.Drawing.Point(0, 0)
        Me.splContainMain.Name = "splContainMain"
        Me.splContainMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splContainMain.Panel1
        '
        Me.splContainMain.Panel1.Controls.Add(Me.splConCriteriaBuilder)
        '
        'splContainMain.Panel2
        '
        Me.splContainMain.Panel2.Controls.Add(Me.grpCntrlData)
        Me.splContainMain.Size = New System.Drawing.Size(481, 680)
        Me.splContainMain.SplitterDistance = 264
        Me.splContainMain.TabIndex = 0
        '
        'splConCriteriaBuilder
        '
        Me.splConCriteriaBuilder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splConCriteriaBuilder.Location = New System.Drawing.Point(0, 0)
        Me.splConCriteriaBuilder.Name = "splConCriteriaBuilder"
        Me.splConCriteriaBuilder.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splConCriteriaBuilder.Panel1
        '
        Me.splConCriteriaBuilder.Panel1.Controls.Add(Me.grpCriteriaBuilder)
        '
        'splConCriteriaBuilder.Panel2
        '
        Me.splConCriteriaBuilder.Panel2.Controls.Add(Me.grpFullCrit)
        Me.splConCriteriaBuilder.Size = New System.Drawing.Size(481, 264)
        Me.splConCriteriaBuilder.SplitterDistance = 188
        Me.splConCriteriaBuilder.TabIndex = 3
        '
        'grpCriteriaBuilder
        '
        Me.grpCriteriaBuilder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCriteriaBuilder.Appearance.Options.UseFont = True
        Me.grpCriteriaBuilder.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCriteriaBuilder.AppearanceCaption.Options.UseFont = True
        Me.grpCriteriaBuilder.Controls.Add(Me._grid)
        Me.grpCriteriaBuilder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCriteriaBuilder.Location = New System.Drawing.Point(0, 0)
        Me.grpCriteriaBuilder.Name = "grpCriteriaBuilder"
        Me.grpCriteriaBuilder.Size = New System.Drawing.Size(481, 188)
        Me.grpCriteriaBuilder.TabIndex = 2
        Me.grpCriteriaBuilder.Text = "CRITERIA BUILDER"
        '
        '_grid
        '
        Me._grid.AllowDrop = True
        Me._grid.AllowUserToAddRows = False
        Me._grid.AllowUserToResizeRows = False
        Me._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me._grid.BackgroundColor = System.Drawing.Color.White
        Me._grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me._grid.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me._grid.Location = New System.Drawing.Point(2, 22)
        Me._grid.Margin = New System.Windows.Forms.Padding(2)
        Me._grid.MultiSelect = False
        Me._grid.Name = "_grid"
        Me._grid.RowHeadersWidth = 20
        Me._grid.RowTemplate.Height = 20
        Me._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me._grid.Size = New System.Drawing.Size(477, 164)
        Me._grid.TabIndex = 1
        '
        'grpFullCrit
        '
        Me.grpFullCrit.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFullCrit.AppearanceCaption.Options.UseFont = True
        Me.grpFullCrit.Controls.Add(Me.txtStrFullCriteria)
        Me.grpFullCrit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpFullCrit.Location = New System.Drawing.Point(0, 0)
        Me.grpFullCrit.Name = "grpFullCrit"
        Me.grpFullCrit.Size = New System.Drawing.Size(481, 72)
        Me.grpFullCrit.TabIndex = 1
        Me.grpFullCrit.Text = "FILTER CONDITION"
        '
        'txtStrFullCriteria
        '
        Me.txtStrFullCriteria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStrFullCriteria.Location = New System.Drawing.Point(2, 22)
        Me.txtStrFullCriteria.Name = "txtStrFullCriteria"
        Me.txtStrFullCriteria.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtStrFullCriteria.Properties.Appearance.Options.UseBackColor = True
        Me.txtStrFullCriteria.Properties.ReadOnly = True
        Me.txtStrFullCriteria.Size = New System.Drawing.Size(477, 48)
        Me.txtStrFullCriteria.TabIndex = 0
        Me.txtStrFullCriteria.ToolTip = "Filter Condition"
        '
        'grpCntrlData
        '
        Me.grpCntrlData.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCntrlData.AppearanceCaption.Options.UseFont = True
        Me.grpCntrlData.Controls.Add(Me.DATA)
        Me.grpCntrlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCntrlData.Location = New System.Drawing.Point(0, 0)
        Me.grpCntrlData.Name = "grpCntrlData"
        Me.grpCntrlData.Size = New System.Drawing.Size(481, 412)
        Me.grpCntrlData.TabIndex = 6
        Me.grpCntrlData.Text = "RESULT DATA"
        '
        'DATA
        '
        Me.DATA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DATA.Location = New System.Drawing.Point(2, 22)
        Me.DATA.MainView = Me.MainView
        Me.DATA.Name = "DATA"
        Me.DATA.Size = New System.Drawing.Size(477, 388)
        Me.DATA.TabIndex = 5
        Me.DATA.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
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
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.DATA
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.ReadOnly = True
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowBands = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 75
        '
        'grpTemplates
        '
        Me.grpTemplates.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTemplates.AppearanceCaption.Options.UseFont = True
        Me.grpTemplates.Controls.Add(Me.GridTemplates)
        Me.grpTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTemplates.Location = New System.Drawing.Point(0, 0)
        Me.grpTemplates.Name = "grpTemplates"
        Me.grpTemplates.Size = New System.Drawing.Size(175, 680)
        Me.grpTemplates.TabIndex = 7
        Me.grpTemplates.Text = "TEMPLATES"
        '
        'GridTemplates
        '
        Me.GridTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTemplates.Location = New System.Drawing.Point(2, 22)
        Me.GridTemplates.MainView = Me.GridRepTemplates
        Me.GridTemplates.Name = "GridTemplates"
        Me.GridTemplates.Size = New System.Drawing.Size(171, 656)
        Me.GridTemplates.TabIndex = 5
        Me.GridTemplates.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridRepTemplates})
        '
        'GridRepTemplates
        '
        Me.GridRepTemplates.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridRepTemplates.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridRepTemplates.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridRepTemplates.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridRepTemplates.Appearance.Row.Options.UseTextOptions = True
        Me.GridRepTemplates.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridRepTemplates.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridRepTemplates.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridRepTemplates.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridRepTemplates.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridRepTemplates.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridRepTemplates.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.GridRepTemplates.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.PKey, Me.TemplateName, Me.TemplateDesc})
        Me.GridRepTemplates.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridRepTemplates.GridControl = Me.GridTemplates
        Me.GridRepTemplates.Name = "GridRepTemplates"
        Me.GridRepTemplates.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridRepTemplates.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridRepTemplates.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridRepTemplates.OptionsBehavior.Editable = False
        Me.GridRepTemplates.OptionsCustomization.AllowFilter = False
        Me.GridRepTemplates.OptionsCustomization.AllowGroup = False
        Me.GridRepTemplates.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridRepTemplates.OptionsFind.AlwaysVisible = True
        Me.GridRepTemplates.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridRepTemplates.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridRepTemplates.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridRepTemplates.OptionsSelection.UseIndicatorForSelection = False
        Me.GridRepTemplates.OptionsView.ColumnAutoWidth = True
        Me.GridRepTemplates.OptionsView.ShowBands = False
        Me.GridRepTemplates.OptionsView.ShowGroupPanel = False
        '
        'GridBand2
        '
        Me.GridBand2.Caption = "GridBand1"
        Me.GridBand2.Columns.Add(Me.TemplateName)
        Me.GridBand2.Columns.Add(Me.TemplateDesc)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 150
        '
        'TemplateName
        '
        Me.TemplateName.Caption = "Name"
        Me.TemplateName.FieldName = "TemplateName"
        Me.TemplateName.Name = "TemplateName"
        Me.TemplateName.Visible = True
        '
        'TemplateDesc
        '
        Me.TemplateDesc.Caption = "Desc"
        Me.TemplateDesc.FieldName = "TemplateDesc"
        Me.TemplateDesc.Name = "TemplateDesc"
        Me.TemplateDesc.Visible = True
        '
        'PKey
        '
        Me.PKey.Caption = "PKey"
        Me.PKey.FieldName = "PKey"
        Me.PKey.Name = "PKey"
        Me.PKey.Visible = True
        '
        '_timer
        '
        Me._timer.Interval = 10
        '
        'ADVANCEDSEARCH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "ADVANCEDSEARCH"
        Me.Size = New System.Drawing.Size(867, 706)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.splContainer.Panel1.ResumeLayout(False)
        Me.splContainer.Panel2.ResumeLayout(False)
        CType(Me.splContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splContainer.ResumeLayout(False)
        Me.splCritTemplates.Panel1.ResumeLayout(False)
        Me.splCritTemplates.Panel2.ResumeLayout(False)
        CType(Me.splCritTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splCritTemplates.ResumeLayout(False)
        Me.splContainMain.Panel1.ResumeLayout(False)
        Me.splContainMain.Panel2.ResumeLayout(False)
        CType(Me.splContainMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splContainMain.ResumeLayout(False)
        Me.splConCriteriaBuilder.Panel1.ResumeLayout(False)
        Me.splConCriteriaBuilder.Panel2.ResumeLayout(False)
        CType(Me.splConCriteriaBuilder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splConCriteriaBuilder.ResumeLayout(False)
        CType(Me.grpCriteriaBuilder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCriteriaBuilder.ResumeLayout(False)
        CType(Me._grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpFullCrit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFullCrit.ResumeLayout(False)
        CType(Me.txtStrFullCriteria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpCntrlData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCntrlData.ResumeLayout(False)
        CType(Me.DATA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTemplates.ResumeLayout(False)
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRepTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents splContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents splContainMain As System.Windows.Forms.SplitContainer
    Private WithEvents _treeTables As System.Windows.Forms.TreeView
    Private WithEvents _grid As System.Windows.Forms.DataGridView
    Friend WithEvents DATA As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Private WithEvents _timer As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grpCntrlData As DevExpress.XtraEditors.GroupControl
    Friend WithEvents splConCriteriaBuilder As System.Windows.Forms.SplitContainer
    Friend WithEvents grpCriteriaBuilder As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtStrFullCriteria As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents grpFullCrit As DevExpress.XtraEditors.GroupControl
    Friend WithEvents splCritTemplates As System.Windows.Forms.SplitContainer
    Friend WithEvents grpTemplates As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridTemplates As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridRepTemplates As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents PKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TemplateName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TemplateDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
