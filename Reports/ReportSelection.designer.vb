<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelection))
        Me.ReportListGrid = New DevExpress.XtraGrid.GridControl()
        Me.ReportListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ObjectID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReportName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.reportMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GroupedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SortedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SortCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridSelected = New DevExpress.XtraGrid.GridControl()
        Me.GridSelectedView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Key_Selected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Display_Selected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridTemplates = New DevExpress.XtraGrid.GridControl()
        Me.GridRepTemplates = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TemplateName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.TemplateContent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TemplateDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnDeselectAll = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl_ReportSelection = New DevExpress.XtraLayout.LayoutControl()
        Me.GridSelection = New DevExpress.XtraGrid.GridControl()
        Me.GridSelectionView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSelectionKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelectionName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel_SortOption = New DevExpress.XtraEditors.PanelControl()
        Me.btnSelectAll = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel_FilterOption = New DevExpress.XtraEditors.PanelControl()
        Me.LayoutControlGroup_ForAll = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem3 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlGroup10 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Filter = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Sort = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Selection = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Templates = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.LayoutControlGroup9 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.rightClickMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.barGenerateReportFromTemplate = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportListGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reportMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSelectedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRepTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl_ReportSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl_ReportSelection.SuspendLayout()
        CType(Me.GridSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSelectionView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_SortOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel_FilterOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_ForAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Filter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Sort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Templates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControlGroup9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection.InsertGalleryImage("add_32x32.png", "images/actions/add_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png"), 0)
        Me.ImageCollection.Images.SetKeyName(0, "add_32x32.png")
        Me.ImageCollection.InsertGalleryImage("cancel_32x32.png", "images/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"), 1)
        Me.ImageCollection.Images.SetKeyName(1, "cancel_32x32.png")
        Me.ImageCollection.InsertGalleryImage("edit_32x32.png", "images/edit/edit_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_32x32.png"), 2)
        Me.ImageCollection.Images.SetKeyName(2, "edit_32x32.png")
        '
        'ReportListGrid
        '
        Me.ReportListGrid.Location = New System.Drawing.Point(7, 30)
        Me.ReportListGrid.MainView = Me.ReportListView
        Me.ReportListGrid.Name = "ReportListGrid"
        Me.ReportListGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.reportMemoEdit})
        Me.ReportListGrid.Size = New System.Drawing.Size(347, 744)
        Me.ReportListGrid.TabIndex = 0
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
        Me.ReportListView.OptionsPrint.PrintVertLines = False
        Me.ReportListView.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = True
        Me.ReportListView.OptionsSelection.UseIndicatorForSelection = False
        Me.ReportListView.OptionsView.RowAutoHeight = True
        Me.ReportListView.OptionsView.ShowGroupPanel = False
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
        Me.ReportName.ColumnEdit = Me.reportMemoEdit
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
        'reportMemoEdit
        '
        Me.reportMemoEdit.Name = "reportMemoEdit"
        '
        'GroupedBy
        '
        Me.GroupedBy.Caption = "Grouped By"
        Me.GroupedBy.ColumnEdit = Me.reportMemoEdit
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
        'GridSelected
        '
        Me.GridSelected.AllowDrop = True
        Me.GridSelected.Location = New System.Drawing.Point(681, 346)
        Me.GridSelected.MainView = Me.GridSelectedView
        Me.GridSelected.Name = "GridSelected"
        Me.GridSelected.Size = New System.Drawing.Size(302, 401)
        Me.GridSelected.TabIndex = 1
        Me.GridSelected.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridSelectedView})
        '
        'GridSelectedView
        '
        Me.GridSelectedView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Key_Selected, Me.Display_Selected})
        Me.GridSelectedView.GridControl = Me.GridSelected
        Me.GridSelectedView.Name = "GridSelectedView"
        Me.GridSelectedView.OptionsBehavior.Editable = False
        Me.GridSelectedView.OptionsCustomization.AllowColumnMoving = False
        Me.GridSelectedView.OptionsCustomization.AllowColumnResizing = False
        Me.GridSelectedView.OptionsFind.AlwaysVisible = True
        Me.GridSelectedView.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridSelectedView.OptionsPrint.PrintHorzLines = False
        Me.GridSelectedView.OptionsPrint.PrintVertLines = False
        Me.GridSelectedView.OptionsSelection.MultiSelect = True
        Me.GridSelectedView.OptionsSelection.UseIndicatorForSelection = False
        Me.GridSelectedView.OptionsView.ShowColumnHeaders = False
        Me.GridSelectedView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridSelectedView.OptionsView.ShowGroupPanel = False
        Me.GridSelectedView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridSelectedView.OptionsView.ShowIndicator = False
        Me.GridSelectedView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridSelectedView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridSelectedView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Display_Selected, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'Key_Selected
        '
        Me.Key_Selected.Caption = "Key"
        Me.Key_Selected.Name = "Key_Selected"
        '
        'Display_Selected
        '
        Me.Display_Selected.Name = "Display_Selected"
        Me.Display_Selected.Visible = True
        Me.Display_Selected.VisibleIndex = 0
        '
        'GridTemplates
        '
        Me.GridTemplates.Location = New System.Drawing.Point(1002, 30)
        Me.GridTemplates.MainView = Me.GridRepTemplates
        Me.GridTemplates.Name = "GridTemplates"
        Me.GridTemplates.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repMemoEdit})
        Me.GridTemplates.Size = New System.Drawing.Size(319, 744)
        Me.GridTemplates.TabIndex = 4
        Me.GridTemplates.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridRepTemplates})
        '
        'GridRepTemplates
        '
        Me.GridRepTemplates.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PKey, Me.TemplateName, Me.TemplateContent, Me.TemplateDesc})
        Me.GridRepTemplates.GridControl = Me.GridTemplates
        Me.GridRepTemplates.Name = "GridRepTemplates"
        Me.GridRepTemplates.OptionsBehavior.Editable = False
        Me.GridRepTemplates.OptionsCustomization.AllowColumnMoving = False
        Me.GridRepTemplates.OptionsCustomization.AllowFilter = False
        Me.GridRepTemplates.OptionsCustomization.AllowSort = False
        Me.GridRepTemplates.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.GridRepTemplates.OptionsView.RowAutoHeight = True
        Me.GridRepTemplates.OptionsView.ShowGroupPanel = False
        '
        'PKey
        '
        Me.PKey.Caption = "PKey"
        Me.PKey.FieldName = "PKey"
        Me.PKey.Name = "PKey"
        '
        'TemplateName
        '
        Me.TemplateName.Caption = "Name"
        Me.TemplateName.ColumnEdit = Me.repMemoEdit
        Me.TemplateName.FieldName = "Name"
        Me.TemplateName.Name = "TemplateName"
        Me.TemplateName.Visible = True
        Me.TemplateName.VisibleIndex = 0
        Me.TemplateName.Width = 50
        '
        'repMemoEdit
        '
        Me.repMemoEdit.Name = "repMemoEdit"
        '
        'TemplateContent
        '
        Me.TemplateContent.Caption = "Content"
        Me.TemplateContent.ColumnEdit = Me.repMemoEdit
        Me.TemplateContent.FieldName = "Content"
        Me.TemplateContent.Name = "TemplateContent"
        Me.TemplateContent.Visible = True
        Me.TemplateContent.VisibleIndex = 1
        Me.TemplateContent.Width = 40
        '
        'TemplateDesc
        '
        Me.TemplateDesc.Caption = "Description"
        Me.TemplateDesc.ColumnEdit = Me.repMemoEdit
        Me.TemplateDesc.FieldName = "Description"
        Me.TemplateDesc.Name = "TemplateDesc"
        Me.TemplateDesc.Visible = True
        Me.TemplateDesc.VisibleIndex = 2
        Me.TemplateDesc.Width = 50
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(681, 751)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(302, 23)
        Me.btnDeselectAll.StyleController = Me.LayoutControl_ReportSelection
        Me.btnDeselectAll.TabIndex = 12
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'LayoutControl_ReportSelection
        '
        Me.LayoutControl_ReportSelection.Controls.Add(Me.GridSelection)
        Me.LayoutControl_ReportSelection.Controls.Add(Me.Panel_SortOption)
        Me.LayoutControl_ReportSelection.Controls.Add(Me.ReportListGrid)
        Me.LayoutControl_ReportSelection.Controls.Add(Me.btnDeselectAll)
        Me.LayoutControl_ReportSelection.Controls.Add(Me.GridSelected)
        Me.LayoutControl_ReportSelection.Controls.Add(Me.btnSelectAll)
        Me.LayoutControl_ReportSelection.Controls.Add(Me.Panel_FilterOption)
        Me.LayoutControl_ReportSelection.Controls.Add(Me.GridTemplates)
        Me.LayoutControl_ReportSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl_ReportSelection.Location = New System.Drawing.Point(2, 31)
        Me.LayoutControl_ReportSelection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl_ReportSelection.Name = "LayoutControl_ReportSelection"
        Me.LayoutControl_ReportSelection.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(228, 266, 756, 350)
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl_ReportSelection.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_ReportSelection.Root = Me.LayoutControlGroup_ForAll
        Me.LayoutControl_ReportSelection.Size = New System.Drawing.Size(1328, 781)
        Me.LayoutControl_ReportSelection.TabIndex = 4
        Me.LayoutControl_ReportSelection.Text = "LayoutControl7"
        '
        'GridSelection
        '
        Me.GridSelection.AllowDrop = True
        Me.GridSelection.Location = New System.Drawing.Point(373, 346)
        Me.GridSelection.MainView = Me.GridSelectionView
        Me.GridSelection.Name = "GridSelection"
        Me.GridSelection.Size = New System.Drawing.Size(304, 401)
        Me.GridSelection.TabIndex = 0
        Me.GridSelection.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridSelectionView})
        '
        'GridSelectionView
        '
        Me.GridSelectionView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSelectionKey, Me.colSelectionName})
        Me.GridSelectionView.GridControl = Me.GridSelection
        Me.GridSelectionView.Name = "GridSelectionView"
        Me.GridSelectionView.OptionsBehavior.Editable = False
        Me.GridSelectionView.OptionsCustomization.AllowColumnMoving = False
        Me.GridSelectionView.OptionsCustomization.AllowColumnResizing = False
        Me.GridSelectionView.OptionsFind.AlwaysVisible = True
        Me.GridSelectionView.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridSelectionView.OptionsPrint.PrintHorzLines = False
        Me.GridSelectionView.OptionsPrint.PrintVertLines = False
        Me.GridSelectionView.OptionsSelection.MultiSelect = True
        Me.GridSelectionView.OptionsSelection.UseIndicatorForSelection = False
        Me.GridSelectionView.OptionsView.ShowColumnHeaders = False
        Me.GridSelectionView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridSelectionView.OptionsView.ShowGroupPanel = False
        Me.GridSelectionView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridSelectionView.OptionsView.ShowIndicator = False
        Me.GridSelectionView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridSelectionView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colSelectionKey
        '
        Me.colSelectionKey.Caption = "PKey"
        Me.colSelectionKey.Name = "colSelectionKey"
        '
        'colSelectionName
        '
        Me.colSelectionName.Caption = "Name"
        Me.colSelectionName.Name = "colSelectionName"
        Me.colSelectionName.Visible = True
        Me.colSelectionName.VisibleIndex = 0
        '
        'Panel_SortOption
        '
        Me.Panel_SortOption.Location = New System.Drawing.Point(685, 30)
        Me.Panel_SortOption.Name = "Panel_SortOption"
        Me.Panel_SortOption.Size = New System.Drawing.Size(298, 255)
        Me.Panel_SortOption.TabIndex = 15
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(373, 751)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(304, 23)
        Me.btnSelectAll.StyleController = Me.LayoutControl_ReportSelection
        Me.btnSelectAll.TabIndex = 11
        Me.btnSelectAll.Text = "Select All"
        '
        'Panel_FilterOption
        '
        Me.Panel_FilterOption.Location = New System.Drawing.Point(373, 30)
        Me.Panel_FilterOption.Name = "Panel_FilterOption"
        Me.Panel_FilterOption.Size = New System.Drawing.Size(298, 255)
        Me.Panel_FilterOption.TabIndex = 14
        '
        'LayoutControlGroup_ForAll
        '
        Me.LayoutControlGroup_ForAll.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup_ForAll.GroupBordersVisible = False
        Me.LayoutControlGroup_ForAll.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.SplitterItem1, Me.SplitterItem2, Me.SplitterItem3, Me.LayoutControlGroup10, Me.LayoutControlGroup_Filter, Me.LayoutControlGroup_Sort, Me.LayoutControlGroup_Selection, Me.LayoutControlGroup_Templates})
        Me.LayoutControlGroup_ForAll.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_ForAll.Name = "Root"
        Me.LayoutControlGroup_ForAll.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_ForAll.Size = New System.Drawing.Size(1328, 781)
        Me.LayoutControlGroup_ForAll.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(361, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 781)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(990, 0)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(5, 781)
        '
        'SplitterItem3
        '
        Me.SplitterItem3.AllowHotTrack = True
        Me.SplitterItem3.Location = New System.Drawing.Point(366, 292)
        Me.SplitterItem3.Name = "SplitterItem3"
        Me.SplitterItem3.Size = New System.Drawing.Size(624, 5)
        '
        'LayoutControlGroup10
        '
        Me.LayoutControlGroup10.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup10.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup10.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup10.Name = "LayoutControlGroup10"
        Me.LayoutControlGroup10.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup10.Size = New System.Drawing.Size(361, 781)
        Me.LayoutControlGroup10.Text = "1. Select Report"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ReportListGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(351, 748)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup_Filter
        '
        Me.LayoutControlGroup_Filter.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Filter.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Filter.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup_Filter.Location = New System.Drawing.Point(366, 0)
        Me.LayoutControlGroup_Filter.Name = "LayoutControlGroup_Filter"
        Me.LayoutControlGroup_Filter.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup_Filter.Size = New System.Drawing.Size(312, 292)
        Me.LayoutControlGroup_Filter.Text = "2. Filter Records"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Panel_FilterOption
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(302, 259)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup_Sort
        '
        Me.LayoutControlGroup_Sort.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Sort.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Sort.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup_Sort.Location = New System.Drawing.Point(678, 0)
        Me.LayoutControlGroup_Sort.Name = "LayoutControlGroup_Sort"
        Me.LayoutControlGroup_Sort.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup_Sort.Size = New System.Drawing.Size(312, 292)
        Me.LayoutControlGroup_Sort.Text = "3. Sort Records"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.Panel_SortOption
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(302, 259)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup_Selection
        '
        Me.LayoutControlGroup_Selection.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Selection.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Selection.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem6, Me.LayoutControlItem8})
        Me.LayoutControlGroup_Selection.Location = New System.Drawing.Point(366, 297)
        Me.LayoutControlGroup_Selection.Name = "LayoutControlGroup_Selection"
        Me.LayoutControlGroup_Selection.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup_Selection.Size = New System.Drawing.Size(624, 484)
        Me.LayoutControlGroup_Selection.Text = "3. Select Records"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridSelection
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(308, 424)
        Me.LayoutControlItem5.Text = "Available Records"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(101, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.GridSelected
        Me.LayoutControlItem7.Location = New System.Drawing.Point(308, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(306, 424)
        Me.LayoutControlItem7.Text = "Selected Records"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(101, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnSelectAll
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 424)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(308, 27)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnDeselectAll
        Me.LayoutControlItem8.Location = New System.Drawing.Point(308, 424)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(306, 27)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlGroup_Templates
        '
        Me.LayoutControlGroup_Templates.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Templates.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Templates.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup_Templates.Location = New System.Drawing.Point(995, 0)
        Me.LayoutControlGroup_Templates.Name = "LayoutControlGroup_Templates"
        Me.LayoutControlGroup_Templates.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup_Templates.Size = New System.Drawing.Size(333, 781)
        Me.LayoutControlGroup_Templates.Text = "Saved Templates"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridTemplates
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(323, 748)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(239, 188)
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl_ReportSelection)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1332, 814)
        Me.header.TabIndex = 2
        Me.header.Text = "Reports"
        '
        'LayoutControlGroup9
        '
        Me.LayoutControlGroup9.Location = New System.Drawing.Point(274, 0)
        Me.LayoutControlGroup9.Name = "LayoutControlGroup9"
        Me.LayoutControlGroup9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup9.Size = New System.Drawing.Size(275, 170)
        Me.LayoutControlGroup9.Text = "4. Sort Records"
        '
        'rightClickMenu
        '
        Me.rightClickMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barGenerateReportFromTemplate)})
        Me.rightClickMenu.Manager = Me.BarManager1
        Me.rightClickMenu.Name = "rightClickMenu"
        '
        'barGenerateReportFromTemplate
        '
        Me.barGenerateReportFromTemplate.Caption = "Generate Report From this Template"
        Me.barGenerateReportFromTemplate.Id = 0
        Me.barGenerateReportFromTemplate.Name = "barGenerateReportFromTemplate"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barGenerateReportFromTemplate})
        Me.BarManager1.MaxItemId = 1
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(1332, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 814)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1332, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 814)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1332, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 814)
        '
        'ReportSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "ReportSelection"
        Me.Size = New System.Drawing.Size(1332, 814)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportListGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reportMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSelectedView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRepTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl_ReportSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl_ReportSelection.ResumeLayout(False)
        CType(Me.GridSelection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSelectionView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_SortOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel_FilterOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_ForAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Filter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Sort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Selection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Templates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControlGroup9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportListGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ReportName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SortedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ObjectID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridSelected As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridSelectedView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Key_Selected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Display_Selected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridTemplates As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridRepTemplates As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TemplateName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TemplateDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridSelection As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridSelectionView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SortCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnDeselectAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSelectAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents LayoutControlGroup9 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents colSelectionKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSelectionName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel_FilterOption As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Panel_SortOption As DevExpress.XtraEditors.PanelControl
    Friend WithEvents repMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents TemplateContent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rightClickMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents barGenerateReportFromTemplate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LayoutControl_ReportSelection As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup_ForAll As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem3 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlGroup10 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Filter As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Sort As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Selection As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Templates As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents reportMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

End Class
