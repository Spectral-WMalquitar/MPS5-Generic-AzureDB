<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVesselRankSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVesselRankSelection))
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnShowAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnShowAllWithDataOnly = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSelect = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdOK = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.rpOptions = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgConfirmation = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LayoutControl_Main = New DevExpress.XtraLayout.LayoutControl()
        Me.chkShowAllSelectedOnly = New System.Windows.Forms.CheckBox()
        Me.lblShowAllWithDataOnly = New System.Windows.Forms.Label()
        Me.lblShowAll = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdDeselectAll = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSelectAllDisplayed = New System.Windows.Forms.Button()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroupOptions = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroupShowAll = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroupSelect = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItemSelection = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroupShowAllWithData = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl_Main.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroupOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroupShowAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroupSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroupShowAllWithData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 607)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(433, 31)
        Me.RibbonStatusBar.Visible = False
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btnShowAll, Me.btnShowAllWithDataOnly, Me.btnSelect, Me.cmdOK, Me.cmdCancel})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 7
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpOptions})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowCategoryInCaption = False
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl.ShowQatLocationSelector = False
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(433, 131)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'btnShowAll
        '
        Me.btnShowAll.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnShowAll.Caption = "Show All"
        Me.btnShowAll.Glyph = CType(resources.GetObject("btnShowAll.Glyph"), System.Drawing.Image)
        Me.btnShowAll.GroupIndex = 1
        Me.btnShowAll.Id = 1
        Me.btnShowAll.LargeGlyph = CType(resources.GetObject("btnShowAll.LargeGlyph"), System.Drawing.Image)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnShowAllWithDataOnly
        '
        Me.btnShowAllWithDataOnly.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnShowAllWithDataOnly.Caption = "Show All With Data Only"
        Me.btnShowAllWithDataOnly.Glyph = CType(resources.GetObject("btnShowAllWithDataOnly.Glyph"), System.Drawing.Image)
        Me.btnShowAllWithDataOnly.GroupIndex = 1
        Me.btnShowAllWithDataOnly.Id = 2
        Me.btnShowAllWithDataOnly.Name = "btnShowAllWithDataOnly"
        Me.btnShowAllWithDataOnly.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnSelect
        '
        Me.btnSelect.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnSelect.Caption = "Select:"
        Me.btnSelect.Glyph = CType(resources.GetObject("btnSelect.Glyph"), System.Drawing.Image)
        Me.btnSelect.GroupIndex = 1
        Me.btnSelect.Id = 3
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdOK
        '
        Me.cmdOK.Caption = "Ok"
        Me.cmdOK.Glyph = CType(resources.GetObject("cmdOK.Glyph"), System.Drawing.Image)
        Me.cmdOK.Id = 5
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdCancel
        '
        Me.cmdCancel.Caption = "Cancel"
        Me.cmdCancel.Glyph = CType(resources.GetObject("cmdCancel.Glyph"), System.Drawing.Image)
        Me.cmdCancel.Id = 6
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'rpOptions
        '
        Me.rpOptions.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgOptions, Me.rpgConfirmation})
        Me.rpOptions.Name = "rpOptions"
        Me.rpOptions.Text = "RibbonPage1"
        '
        'rpgOptions
        '
        Me.rpgOptions.ItemLinks.Add(Me.btnShowAll)
        Me.rpgOptions.ItemLinks.Add(Me.btnShowAllWithDataOnly)
        Me.rpgOptions.ItemLinks.Add(Me.btnSelect)
        Me.rpgOptions.Name = "rpgOptions"
        '
        'rpgConfirmation
        '
        Me.rpgConfirmation.ItemLinks.Add(Me.cmdOK)
        Me.rpgConfirmation.ItemLinks.Add(Me.cmdCancel)
        Me.rpgConfirmation.Name = "rpgConfirmation"
        '
        'LayoutControl_Main
        '
        Me.LayoutControl_Main.Controls.Add(Me.chkShowAllSelectedOnly)
        Me.LayoutControl_Main.Controls.Add(Me.lblShowAllWithDataOnly)
        Me.LayoutControl_Main.Controls.Add(Me.lblShowAll)
        Me.LayoutControl_Main.Controls.Add(Me.Label2)
        Me.LayoutControl_Main.Controls.Add(Me.cmdDeselectAll)
        Me.LayoutControl_Main.Controls.Add(Me.Label1)
        Me.LayoutControl_Main.Controls.Add(Me.cmdSelectAllDisplayed)
        Me.LayoutControl_Main.Controls.Add(Me.MainGrid)
        Me.LayoutControl_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl_Main.Location = New System.Drawing.Point(0, 131)
        Me.LayoutControl_Main.Name = "LayoutControl_Main"
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_Main.Root = Me.LayoutControlGroupOptions
        Me.LayoutControl_Main.Size = New System.Drawing.Size(433, 476)
        Me.LayoutControl_Main.TabIndex = 2
        Me.LayoutControl_Main.Text = "LayoutControl1"
        '
        'chkShowAllSelectedOnly
        '
        Me.chkShowAllSelectedOnly.Location = New System.Drawing.Point(24, 288)
        Me.chkShowAllSelectedOnly.Name = "chkShowAllSelectedOnly"
        Me.chkShowAllSelectedOnly.Size = New System.Drawing.Size(385, 20)
        Me.chkShowAllSelectedOnly.TabIndex = 12
        Me.chkShowAllSelectedOnly.Text = "Show All Selected Only"
        Me.chkShowAllSelectedOnly.UseVisualStyleBackColor = True
        '
        'lblShowAllWithDataOnly
        '
        Me.lblShowAllWithDataOnly.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblShowAllWithDataOnly.Location = New System.Drawing.Point(24, 432)
        Me.lblShowAllWithDataOnly.Name = "lblShowAllWithDataOnly"
        Me.lblShowAllWithDataOnly.Size = New System.Drawing.Size(385, 20)
        Me.lblShowAllWithDataOnly.TabIndex = 11
        Me.lblShowAllWithDataOnly.Text = "Shows All Ranks with Onboard/Planned Crews Only"
        '
        'lblShowAll
        '
        Me.lblShowAll.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblShowAll.Location = New System.Drawing.Point(24, 384)
        Me.lblShowAll.Name = "lblShowAll"
        Me.lblShowAll.Size = New System.Drawing.Size(385, 20)
        Me.lblShowAll.TabIndex = 10
        Me.lblShowAll.Text = "Shows All Ranks"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(61, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(348, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Deselect All"
        '
        'cmdDeselectAll
        '
        Me.cmdDeselectAll.Location = New System.Drawing.Point(24, 336)
        Me.cmdDeselectAll.Name = "cmdDeselectAll"
        Me.cmdDeselectAll.Size = New System.Drawing.Size(33, 20)
        Me.cmdDeselectAll.TabIndex = 8
        Me.cmdDeselectAll.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(61, 312)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(348, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Select All Displayed"
        '
        'cmdSelectAllDisplayed
        '
        Me.cmdSelectAllDisplayed.Location = New System.Drawing.Point(24, 312)
        Me.cmdSelectAllDisplayed.Name = "cmdSelectAllDisplayed"
        Me.cmdSelectAllDisplayed.Size = New System.Drawing.Size(33, 20)
        Me.cmdSelectAllDisplayed.TabIndex = 6
        Me.cmdSelectAllDisplayed.UseVisualStyleBackColor = True
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(24, 24)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repCheckEdit})
        Me.MainGrid.Size = New System.Drawing.Size(385, 260)
        Me.MainGrid.TabIndex = 5
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSelected, Me.colPKey, Me.colName})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
        Me.MainView.OptionsCustomization.AllowColumnResizing = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsView.ShowColumnHeaders = False
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'colSelected
        '
        Me.colSelected.Caption = "Select"
        Me.colSelected.ColumnEdit = Me.repCheckEdit
        Me.colSelected.FieldName = "Selected"
        Me.colSelected.Name = "colSelected"
        Me.colSelected.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.colSelected.OptionsColumn.AllowMove = False
        Me.colSelected.OptionsColumn.AllowShowHide = False
        Me.colSelected.OptionsColumn.AllowSize = False
        Me.colSelected.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSelected.OptionsColumn.FixedWidth = True
        Me.colSelected.Visible = True
        Me.colSelected.VisibleIndex = 0
        Me.colSelected.Width = 50
        '
        'repCheckEdit
        '
        Me.repCheckEdit.AutoHeight = False
        Me.repCheckEdit.Name = "repCheckEdit"
        '
        'colPKey
        '
        Me.colPKey.Caption = "PKey"
        Me.colPKey.Name = "colPKey"
        Me.colPKey.OptionsColumn.AllowEdit = False
        Me.colPKey.OptionsColumn.AllowFocus = False
        Me.colPKey.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colPKey.OptionsColumn.AllowMove = False
        Me.colPKey.OptionsColumn.AllowShowHide = False
        Me.colPKey.OptionsColumn.AllowSize = False
        Me.colPKey.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colPKey.OptionsColumn.FixedWidth = True
        Me.colPKey.OptionsColumn.ReadOnly = True
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.Name = "colName"
        Me.colName.OptionsColumn.ReadOnly = True
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 1
        Me.colName.Width = 662
        '
        'LayoutControlGroupOptions
        '
        Me.LayoutControlGroupOptions.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroupOptions.GroupBordersVisible = False
        Me.LayoutControlGroupOptions.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroupShowAll, Me.LayoutControlGroupSelect, Me.LayoutControlGroupShowAllWithData})
        Me.LayoutControlGroupOptions.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroupOptions.Name = "LayoutControlGroupOptions"
        Me.LayoutControlGroupOptions.Size = New System.Drawing.Size(433, 476)
        Me.LayoutControlGroupOptions.TextVisible = False
        '
        'LayoutControlGroupShowAll
        '
        Me.LayoutControlGroupShowAll.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroupShowAll.Location = New System.Drawing.Point(0, 360)
        Me.LayoutControlGroupShowAll.Name = "LayoutControlGroupShowAll"
        Me.LayoutControlGroupShowAll.Size = New System.Drawing.Size(413, 48)
        Me.LayoutControlGroupShowAll.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.lblShowAll
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroupSelect
        '
        Me.LayoutControlGroupSelect.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItemSelection, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem7})
        Me.LayoutControlGroupSelect.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroupSelect.Name = "LayoutControlGroupSelect"
        Me.LayoutControlGroupSelect.Size = New System.Drawing.Size(413, 360)
        Me.LayoutControlGroupSelect.TextVisible = False
        '
        'LayoutControlItemSelection
        '
        Me.LayoutControlItemSelection.Control = Me.MainGrid
        Me.LayoutControlItemSelection.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItemSelection.Name = "LayoutControlItemSelection"
        Me.LayoutControlItemSelection.Size = New System.Drawing.Size(389, 264)
        Me.LayoutControlItemSelection.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItemSelection.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmdSelectAllDisplayed
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 288)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(37, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(37, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(37, 24)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Label1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(37, 288)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(352, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdDeselectAll
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 312)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(37, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(37, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(37, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Label2
        Me.LayoutControlItem4.Location = New System.Drawing.Point(37, 312)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(352, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkShowAllSelectedOnly
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 264)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlGroupShowAllWithData
        '
        Me.LayoutControlGroupShowAllWithData.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.LayoutControlGroupShowAllWithData.Location = New System.Drawing.Point(0, 408)
        Me.LayoutControlGroupShowAllWithData.Name = "LayoutControlGroupShowAllWithData"
        Me.LayoutControlGroupShowAllWithData.Size = New System.Drawing.Size(413, 48)
        Me.LayoutControlGroupShowAllWithData.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.lblShowAllWithDataOnly
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'frmVesselRankSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 638)
        Me.ControlBox = False
        Me.Controls.Add(Me.LayoutControl_Main)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVesselRankSelection"
        Me.Ribbon = Me.RibbonControl
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Graphical Planning Filter"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl_Main.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroupOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroupShowAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroupSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemSelection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroupShowAllWithData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rpOptions As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnShowAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnShowAllWithDataOnly As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSelect As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutControl_Main As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroupOptions As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItemSelection As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdOK As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgConfirmation As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdDeselectAll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSelectAllDisplayed As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblShowAll As System.Windows.Forms.Label
    Friend WithEvents LayoutControlGroupShowAll As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroupSelect As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lblShowAllWithDataOnly As System.Windows.Forms.Label
    Friend WithEvents LayoutControlGroupShowAllWithData As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkShowAllSelectedOnly As System.Windows.Forms.CheckBox
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem


End Class
