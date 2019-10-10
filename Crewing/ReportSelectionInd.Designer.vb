<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSelectionInd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectionInd))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.cmdPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.tabReports = New DevExpress.XtraTab.XtraTabControl()
        Me.tabReportInd = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.ReportListGrid = New DevExpress.XtraGrid.GridControl()
        Me.ReportListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ObjectID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReportName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SortedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SortCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tabReportGovt = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.Panel_FilterOption = New DevExpress.XtraEditors.PanelControl()
        Me.ReportListGridGovt = New DevExpress.XtraGrid.GridControl()
        Me.ReportListViewGovt = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.tabReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabReports.SuspendLayout()
        Me.tabReportInd.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.ReportListGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabReportGovt.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.Panel_FilterOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportListGridGovt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportListViewGovt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.cmdPreview, Me.cmdPrint, Me.cmdCancel})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl.MaxItemId = 4
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl.ShowQatLocationSelector = False
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(455, 131)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'cmdPreview
        '
        Me.cmdPreview.Caption = "Preview"
        Me.cmdPreview.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdPreview.Glyph = CType(resources.GetObject("cmdPreview.Glyph"), System.Drawing.Image)
        Me.cmdPreview.Id = 1
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdPrint
        '
        Me.cmdPrint.Caption = "Print"
        Me.cmdPrint.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdPrint.Glyph = CType(resources.GetObject("cmdPrint.Glyph"), System.Drawing.Image)
        Me.cmdPrint.Id = 2
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdCancel
        '
        Me.cmdCancel.Caption = "Cancel"
        Me.cmdCancel.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdCancel.Glyph = CType(resources.GetObject("cmdCancel.Glyph"), System.Drawing.Image)
        Me.cmdCancel.Id = 3
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdPreview)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdCancel)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Report Options"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 706)
        Me.RibbonStatusBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(455, 31)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.tabReports)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 131)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(439, 304, 426, 350)
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(455, 575)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'tabReports
        '
        Me.tabReports.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabReports.Location = New System.Drawing.Point(12, 36)
        Me.tabReports.Name = "tabReports"
        Me.tabReports.SelectedTabPage = Me.tabReportInd
        Me.tabReports.Size = New System.Drawing.Size(431, 527)
        Me.tabReports.TabIndex = 4
        Me.tabReports.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabReportInd, Me.tabReportGovt})
        '
        'tabReportInd
        '
        Me.tabReportInd.Controls.Add(Me.LayoutControl2)
        Me.tabReportInd.Name = "tabReportInd"
        Me.tabReportInd.Size = New System.Drawing.Size(425, 496)
        Me.tabReportInd.Text = "Individual Reports"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.ReportListGrid)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        Me.LayoutControl2.Size = New System.Drawing.Size(425, 496)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'ReportListGrid
        '
        Me.ReportListGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportListGrid.Location = New System.Drawing.Point(2, 2)
        Me.ReportListGrid.MainView = Me.ReportListView
        Me.ReportListGrid.Name = "ReportListGrid"
        Me.ReportListGrid.Size = New System.Drawing.Size(421, 492)
        Me.ReportListGrid.TabIndex = 1
        Me.ReportListGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportListView})
        '
        'ReportListView
        '
        Me.ReportListView.ActiveFilterEnabled = False
        Me.ReportListView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow
        Me.ReportListView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.ReportListView.Appearance.FocusedCell.Options.UseBackColor = True
        Me.ReportListView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ReportListView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ReportListView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ReportListView.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportListView.Appearance.Row.Options.UseFont = True
        Me.ReportListView.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.ReportListView.Appearance.SelectedRow.Options.UseBackColor = True
        Me.ReportListView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ObjectID, Me.ReportName, Me.GroupedBy, Me.SortedBy, Me.SortCode})
        Me.ReportListView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.ReportListView.GridControl = Me.ReportListGrid
        Me.ReportListView.Name = "ReportListView"
        Me.ReportListView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.ReportListView.OptionsBehavior.KeepFocusedRowOnUpdate = False
        Me.ReportListView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.ReportListView.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = True
        Me.ReportListView.OptionsSelection.UseIndicatorForSelection = False
        Me.ReportListView.OptionsView.ShowGroupPanel = False
        Me.ReportListView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportListView.OptionsView.ShowIndicator = False
        Me.ReportListView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportListView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'ObjectID
        '
        Me.ObjectID.Caption = "ObjectID"
        Me.ObjectID.FieldName = "ObjectID"
        Me.ObjectID.Name = "ObjectID"
        Me.ObjectID.OptionsColumn.AllowEdit = False
        Me.ObjectID.OptionsColumn.AllowFocus = False
        Me.ObjectID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.ObjectID.OptionsColumn.AllowIncrementalSearch = False
        Me.ObjectID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.ObjectID.OptionsColumn.AllowMove = False
        Me.ObjectID.OptionsColumn.AllowShowHide = False
        Me.ObjectID.OptionsColumn.AllowSize = False
        Me.ObjectID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.ObjectID.OptionsColumn.FixedWidth = True
        Me.ObjectID.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.ObjectID.OptionsColumn.ReadOnly = True
        Me.ObjectID.OptionsColumn.ShowInCustomizationForm = False
        Me.ObjectID.OptionsColumn.ShowInExpressionEditor = False
        Me.ObjectID.OptionsColumn.TabStop = False
        Me.ObjectID.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'ReportName
        '
        Me.ReportName.Caption = "Report Name"
        Me.ReportName.FieldName = "Caption"
        Me.ReportName.Name = "ReportName"
        Me.ReportName.OptionsColumn.AllowEdit = False
        Me.ReportName.OptionsColumn.AllowFocus = False
        Me.ReportName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsColumn.AllowIncrementalSearch = False
        Me.ReportName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsColumn.AllowMove = False
        Me.ReportName.OptionsColumn.AllowShowHide = False
        Me.ReportName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsColumn.FixedWidth = True
        Me.ReportName.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsColumn.ReadOnly = True
        Me.ReportName.OptionsColumn.ShowInCustomizationForm = False
        Me.ReportName.OptionsColumn.ShowInExpressionEditor = False
        Me.ReportName.OptionsColumn.TabStop = False
        Me.ReportName.OptionsFilter.AllowAutoFilter = False
        Me.ReportName.OptionsFilter.AllowFilter = False
        Me.ReportName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsFilter.ImmediateUpdateAutoFilter = False
        Me.ReportName.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportName.Visible = True
        Me.ReportName.VisibleIndex = 0
        Me.ReportName.Width = 142
        '
        'GroupedBy
        '
        Me.GroupedBy.Caption = "Grouped By"
        Me.GroupedBy.FieldName = "GroupedBy"
        Me.GroupedBy.Name = "GroupedBy"
        Me.GroupedBy.OptionsColumn.AllowEdit = False
        Me.GroupedBy.OptionsColumn.AllowFocus = False
        Me.GroupedBy.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GroupedBy.OptionsColumn.AllowIncrementalSearch = False
        Me.GroupedBy.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GroupedBy.OptionsColumn.AllowMove = False
        Me.GroupedBy.OptionsColumn.AllowShowHide = False
        Me.GroupedBy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupedBy.OptionsColumn.FixedWidth = True
        Me.GroupedBy.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupedBy.OptionsColumn.ReadOnly = True
        Me.GroupedBy.OptionsColumn.ShowInCustomizationForm = False
        Me.GroupedBy.OptionsColumn.ShowInExpressionEditor = False
        Me.GroupedBy.OptionsColumn.TabStop = False
        Me.GroupedBy.OptionsFilter.AllowAutoFilter = False
        Me.GroupedBy.OptionsFilter.AllowFilter = False
        Me.GroupedBy.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupedBy.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupedBy.OptionsFilter.ImmediateUpdateAutoFilter = False
        Me.GroupedBy.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupedBy.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupedBy.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.[False]
        Me.GroupedBy.Visible = True
        Me.GroupedBy.VisibleIndex = 1
        Me.GroupedBy.Width = 61
        '
        'SortedBy
        '
        Me.SortedBy.Caption = "Sorted By"
        Me.SortedBy.FieldName = "SortedBy"
        Me.SortedBy.Name = "SortedBy"
        Me.SortedBy.OptionsColumn.AllowEdit = False
        Me.SortedBy.OptionsColumn.AllowFocus = False
        Me.SortedBy.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.SortedBy.OptionsColumn.AllowIncrementalSearch = False
        Me.SortedBy.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.OptionsColumn.AllowMove = False
        Me.SortedBy.OptionsColumn.AllowShowHide = False
        Me.SortedBy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.OptionsColumn.FixedWidth = True
        Me.SortedBy.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.OptionsColumn.ReadOnly = True
        Me.SortedBy.OptionsColumn.ShowInCustomizationForm = False
        Me.SortedBy.OptionsColumn.ShowInExpressionEditor = False
        Me.SortedBy.OptionsColumn.TabStop = False
        Me.SortedBy.OptionsFilter.AllowAutoFilter = False
        Me.SortedBy.OptionsFilter.AllowFilter = False
        Me.SortedBy.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.OptionsFilter.ImmediateUpdateAutoFilter = False
        Me.SortedBy.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortedBy.Width = 92
        '
        'SortCode
        '
        Me.SortCode.Caption = "SortCode"
        Me.SortCode.FieldName = "SortCode"
        Me.SortCode.Name = "SortCode"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(425, 496)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ReportListGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(425, 496)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'tabReportGovt
        '
        Me.tabReportGovt.Controls.Add(Me.LayoutControl3)
        Me.tabReportGovt.Name = "tabReportGovt"
        Me.tabReportGovt.Size = New System.Drawing.Size(425, 496)
        Me.tabReportGovt.Text = "Government Reports"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.Panel_FilterOption)
        Me.LayoutControl3.Controls.Add(Me.ReportListGridGovt)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl3.Root = Me.LayoutControlGroup3
        Me.LayoutControl3.Size = New System.Drawing.Size(425, 496)
        Me.LayoutControl3.TabIndex = 6
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'Panel_FilterOption
        '
        Me.Panel_FilterOption.Location = New System.Drawing.Point(2, 349)
        Me.Panel_FilterOption.Name = "Panel_FilterOption"
        Me.Panel_FilterOption.Size = New System.Drawing.Size(421, 145)
        Me.Panel_FilterOption.TabIndex = 5
        '
        'ReportListGridGovt
        '
        Me.ReportListGridGovt.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportListGridGovt.Location = New System.Drawing.Point(2, 2)
        Me.ReportListGridGovt.MainView = Me.ReportListViewGovt
        Me.ReportListGridGovt.Name = "ReportListGridGovt"
        Me.ReportListGridGovt.Size = New System.Drawing.Size(421, 324)
        Me.ReportListGridGovt.TabIndex = 2
        Me.ReportListGridGovt.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportListViewGovt})
        '
        'ReportListViewGovt
        '
        Me.ReportListViewGovt.ActiveFilterEnabled = False
        Me.ReportListViewGovt.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow
        Me.ReportListViewGovt.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.ReportListViewGovt.Appearance.FocusedCell.Options.UseBackColor = True
        Me.ReportListViewGovt.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.ReportListViewGovt.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.ReportListViewGovt.Appearance.FocusedRow.Options.UseBackColor = True
        Me.ReportListViewGovt.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportListViewGovt.Appearance.Row.Options.UseFont = True
        Me.ReportListViewGovt.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.ReportListViewGovt.Appearance.SelectedRow.Options.UseBackColor = True
        Me.ReportListViewGovt.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.ReportListViewGovt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.ReportListViewGovt.GridControl = Me.ReportListGridGovt
        Me.ReportListViewGovt.Name = "ReportListViewGovt"
        Me.ReportListViewGovt.OptionsBehavior.AutoSelectAllInEditor = False
        Me.ReportListViewGovt.OptionsBehavior.KeepFocusedRowOnUpdate = False
        Me.ReportListViewGovt.OptionsBehavior.ReadOnly = True
        Me.ReportListViewGovt.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.ReportListViewGovt.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = True
        Me.ReportListViewGovt.OptionsSelection.UseIndicatorForSelection = False
        Me.ReportListViewGovt.OptionsView.ShowGroupPanel = False
        Me.ReportListViewGovt.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportListViewGovt.OptionsView.ShowIndicator = False
        Me.ReportListViewGovt.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ReportListViewGovt.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ObjectID"
        Me.GridColumn1.FieldName = "ObjectID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowFocus = False
        Me.GridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.OptionsColumn.AllowIncrementalSearch = False
        Me.GridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.OptionsColumn.AllowMove = False
        Me.GridColumn1.OptionsColumn.AllowShowHide = False
        Me.GridColumn1.OptionsColumn.AllowSize = False
        Me.GridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn1.OptionsColumn.ShowInExpressionEditor = False
        Me.GridColumn1.OptionsColumn.TabStop = False
        Me.GridColumn1.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Report Name"
        Me.GridColumn2.FieldName = "Caption"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowFocus = False
        Me.GridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsColumn.AllowIncrementalSearch = False
        Me.GridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsColumn.AllowMove = False
        Me.GridColumn2.OptionsColumn.AllowShowHide = False
        Me.GridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn2.OptionsColumn.ShowInExpressionEditor = False
        Me.GridColumn2.OptionsColumn.TabStop = False
        Me.GridColumn2.OptionsFilter.AllowAutoFilter = False
        Me.GridColumn2.OptionsFilter.AllowFilter = False
        Me.GridColumn2.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsFilter.ImmediateUpdateAutoFilter = False
        Me.GridColumn2.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 142
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Grouped By"
        Me.GridColumn3.FieldName = "GroupedBy"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        Me.GridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn3.OptionsColumn.AllowIncrementalSearch = False
        Me.GridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn3.OptionsColumn.AllowMove = False
        Me.GridColumn3.OptionsColumn.AllowShowHide = False
        Me.GridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn3.OptionsColumn.ShowInExpressionEditor = False
        Me.GridColumn3.OptionsColumn.TabStop = False
        Me.GridColumn3.OptionsFilter.AllowAutoFilter = False
        Me.GridColumn3.OptionsFilter.AllowFilter = False
        Me.GridColumn3.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.OptionsFilter.ImmediateUpdateAutoFilter = False
        Me.GridColumn3.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 61
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Sorted By"
        Me.GridColumn4.FieldName = "SortedBy"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowFocus = False
        Me.GridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn4.OptionsColumn.AllowIncrementalSearch = False
        Me.GridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsColumn.AllowMove = False
        Me.GridColumn4.OptionsColumn.AllowShowHide = False
        Me.GridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn4.OptionsColumn.ShowInExpressionEditor = False
        Me.GridColumn4.OptionsColumn.TabStop = False
        Me.GridColumn4.OptionsFilter.AllowAutoFilter = False
        Me.GridColumn4.OptionsFilter.AllowFilter = False
        Me.GridColumn4.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsFilter.ImmediateUpdateAutoFilter = False
        Me.GridColumn4.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.Width = 92
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "SortCode"
        Me.GridColumn5.FieldName = "SortCode"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(425, 496)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ReportListGridGovt
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(425, 328)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Panel_FilterOption
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 328)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(425, 168)
        Me.LayoutControlItem4.Text = "Report Options:"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(90, 16)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup1.CustomizationFormText = "Select Report"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(455, 575)
        Me.LayoutControlGroup1.Text = "Select Report"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.tabReports
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(435, 531)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'ReportSelectionInd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 737)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportSelectionInd"
        Me.Ribbon = Me.RibbonControl
        Me.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Visible
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Report Selection"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.tabReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabReports.ResumeLayout(False)
        Me.tabReportInd.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.ReportListGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabReportGovt.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.Panel_FilterOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportListGridGovt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportListViewGovt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents cmdPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents tabReports As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabReportInd As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ReportListGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ObjectID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReportName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SortedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SortCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tabReportGovt As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ReportListGridGovt As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportListViewGovt As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Panel_FilterOption As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem


End Class
