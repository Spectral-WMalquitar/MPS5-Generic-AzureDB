<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KPI))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SplitContainerControl_KPIList_Selection_Result = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LayoutControl6 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboDateCoverageType = New DevExpress.XtraEditors.LookUpEdit()
        Me.BarManager_KPI = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ViewKPIDetails = New DevExpress.XtraBars.BarButtonItem()
        Me.barGenerateChartFromTemplate = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdClearDateCoverage = New System.Windows.Forms.Button()
        Me.dateAsOf = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboKPIType = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboPeriodTo = New DevExpress.XtraEditors.LookUpEdit()
        Me.GridKPI = New DevExpress.XtraGrid.GridControl()
        Me.GridKPIView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colKPIPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKPIName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repKPIMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colKPIPeriod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repPeriod = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colStoredProcedureName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKPIType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelectionListing = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPeriod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repKPIPeriod = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboPeriodFrom = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_DateCoverage = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem_From = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_To = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_DateAsOf = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl7 = New DevExpress.XtraLayout.LayoutControl()
        Me.SplitContainerControl_Selection_Result = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.SplitContainerControl_Selection = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelControl_FilterOption = New DevExpress.XtraEditors.PanelControl()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_FilterOption = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem_FilterOption = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl5 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboSelectionType = New DevExpress.XtraEditors.LookUpEdit()
        Me.GridSelectionList = New DevExpress.XtraGrid.GridControl()
        Me.GridSelectionListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSelectionPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelectionName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVslisSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSelected = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colFKeyPrincipal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyFlt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVslStat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVsl = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cmdDeselectAll = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_Select = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_SelectAll = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_DeselectAll = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.MainChart = New DevExpress.XtraCharts.ChartControl()
        Me.GridTemplates = New DevExpress.XtraGrid.GridControl()
        Me.GridRepTemplates = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TemplateName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.TemplateContent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TemplateDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_Result = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem_Chart = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Templates = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem_Template = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlGroup9 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.StyleController1 = New DevExpress.XtraEditors.StyleController(Me.components)
        Me.RightClickMenu_KPI = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.RightClickMenu_Templates = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SplitContainerControl_KPIList_Selection_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl_KPIList_Selection_Result.SuspendLayout()
        CType(Me.LayoutControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl6.SuspendLayout()
        CType(Me.cboDateCoverageType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager_KPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateAsOf.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateAsOf.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKPIType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridKPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridKPIView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repKPIMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repKPIPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_DateCoverage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_From, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_DateAsOf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl7.SuspendLayout()
        CType(Me.SplitContainerControl_Selection_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl_Selection_Result.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.SplitContainerControl_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl_Selection.SuspendLayout()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl4.SuspendLayout()
        CType(Me.PanelControl_FilterOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_FilterOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_FilterOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl5.SuspendLayout()
        CType(Me.cboSelectionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSelectionList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSelectionListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVsl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Select, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_SelectAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_DeselectAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.MainChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRepTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Result, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Templates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem_Template, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightClickMenu_KPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightClickMenu_Templates, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1480, 633)
        Me.header.TabIndex = 0
        Me.header.Text = "Key Performance Indicator (KPI)"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SplitContainerControl_KPIList_Selection_Result)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 25)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1476, 606)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SplitContainerControl_KPIList_Selection_Result
        '
        Me.SplitContainerControl_KPIList_Selection_Result.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainerControl_KPIList_Selection_Result.Name = "SplitContainerControl_KPIList_Selection_Result"
        Me.SplitContainerControl_KPIList_Selection_Result.Panel1.Controls.Add(Me.LayoutControl6)
        Me.SplitContainerControl_KPIList_Selection_Result.Panel1.Text = "Panel1"
        Me.SplitContainerControl_KPIList_Selection_Result.Panel2.Controls.Add(Me.LayoutControl7)
        Me.SplitContainerControl_KPIList_Selection_Result.Panel2.Text = "Panel2"
        Me.SplitContainerControl_KPIList_Selection_Result.Size = New System.Drawing.Size(1472, 602)
        Me.SplitContainerControl_KPIList_Selection_Result.SplitterPosition = 395
        Me.SplitContainerControl_KPIList_Selection_Result.TabIndex = 5
        Me.SplitContainerControl_KPIList_Selection_Result.Text = "SplitContainerControl3"
        '
        'LayoutControl6
        '
        Me.LayoutControl6.Controls.Add(Me.cboDateCoverageType)
        Me.LayoutControl6.Controls.Add(Me.cmdClearDateCoverage)
        Me.LayoutControl6.Controls.Add(Me.dateAsOf)
        Me.LayoutControl6.Controls.Add(Me.Label1)
        Me.LayoutControl6.Controls.Add(Me.cboKPIType)
        Me.LayoutControl6.Controls.Add(Me.cboPeriodTo)
        Me.LayoutControl6.Controls.Add(Me.GridKPI)
        Me.LayoutControl6.Controls.Add(Me.cboPeriodFrom)
        Me.LayoutControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl6.Name = "LayoutControl6"
        Me.LayoutControl6.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(411, 162, 250, 350)
        Me.LayoutControl6.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl6.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl6.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl6.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl6.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl6.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl6.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl6.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl6.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl6.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl6.Root = Me.LayoutControlGroup5
        Me.LayoutControl6.Size = New System.Drawing.Size(395, 602)
        Me.LayoutControl6.TabIndex = 0
        Me.LayoutControl6.Text = "LayoutControl6"
        '
        'cboDateCoverageType
        '
        Me.cboDateCoverageType.Location = New System.Drawing.Point(158, 452)
        Me.cboDateCoverageType.MenuManager = Me.BarManager_KPI
        Me.cboDateCoverageType.Name = "cboDateCoverageType"
        Me.cboDateCoverageType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboDateCoverageType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboDateCoverageType.Properties.DisplayMember = "Name"
        Me.cboDateCoverageType.Properties.NullText = "Choose..."
        Me.cboDateCoverageType.Properties.ShowFooter = False
        Me.cboDateCoverageType.Properties.ShowHeader = False
        Me.cboDateCoverageType.Properties.ValueMember = "PKey"
        Me.cboDateCoverageType.Size = New System.Drawing.Size(219, 22)
        Me.cboDateCoverageType.StyleController = Me.LayoutControl6
        Me.cboDateCoverageType.TabIndex = 15
        '
        'BarManager_KPI
        '
        Me.BarManager_KPI.DockControls.Add(Me.barDockControlTop)
        Me.BarManager_KPI.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager_KPI.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager_KPI.DockControls.Add(Me.barDockControlRight)
        Me.BarManager_KPI.Form = Me
        Me.BarManager_KPI.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ViewKPIDetails, Me.barGenerateChartFromTemplate})
        Me.BarManager_KPI.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(1480, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 633)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1480, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 633)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1480, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 633)
        '
        'ViewKPIDetails
        '
        Me.ViewKPIDetails.Caption = "View Details"
        Me.ViewKPIDetails.Id = 0
        Me.ViewKPIDetails.Name = "ViewKPIDetails"
        '
        'barGenerateChartFromTemplate
        '
        Me.barGenerateChartFromTemplate.Caption = "Generate chart from this template"
        Me.barGenerateChartFromTemplate.Id = 1
        Me.barGenerateChartFromTemplate.Name = "barGenerateChartFromTemplate"
        '
        'cmdClearDateCoverage
        '
        Me.cmdClearDateCoverage.Location = New System.Drawing.Point(199, 556)
        Me.cmdClearDateCoverage.Name = "cmdClearDateCoverage"
        Me.cmdClearDateCoverage.Size = New System.Drawing.Size(178, 28)
        Me.cmdClearDateCoverage.TabIndex = 14
        Me.cmdClearDateCoverage.Text = "Clear"
        Me.cmdClearDateCoverage.UseVisualStyleBackColor = True
        '
        'dateAsOf
        '
        Me.dateAsOf.EditValue = Nothing
        Me.dateAsOf.Location = New System.Drawing.Point(73, 530)
        Me.dateAsOf.MenuManager = Me.BarManager_KPI
        Me.dateAsOf.Name = "dateAsOf"
        Me.dateAsOf.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dateAsOf.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dateAsOf.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.dateAsOf.Properties.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.dateAsOf.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.dateAsOf.Size = New System.Drawing.Size(304, 22)
        Me.dateAsOf.StyleController = Me.LayoutControl6
        Me.dateAsOf.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 397)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(375, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Note: Right click an item to view details"
        '
        'cboKPIType
        '
        Me.cboKPIType.Location = New System.Drawing.Point(65, 33)
        Me.cboKPIType.Name = "cboKPIType"
        Me.cboKPIType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboKPIType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboKPIType.Properties.DisplayMember = "Name"
        Me.cboKPIType.Properties.NullText = ""
        Me.cboKPIType.Properties.ShowFooter = False
        Me.cboKPIType.Properties.ShowHeader = False
        Me.cboKPIType.Properties.ValueMember = "PKey"
        Me.cboKPIType.Size = New System.Drawing.Size(320, 22)
        Me.cboKPIType.StyleController = Me.LayoutControl6
        Me.cboKPIType.TabIndex = 11
        '
        'cboPeriodTo
        '
        Me.cboPeriodTo.Location = New System.Drawing.Point(73, 504)
        Me.cboPeriodTo.Name = "cboPeriodTo"
        Me.cboPeriodTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPeriodTo.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Period", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodDesc", "PeriodDesc")})
        Me.cboPeriodTo.Properties.DisplayMember = "PeriodDesc"
        Me.cboPeriodTo.Properties.DropDownRows = 4
        Me.cboPeriodTo.Properties.NullText = ""
        Me.cboPeriodTo.Properties.ShowFooter = False
        Me.cboPeriodTo.Properties.ShowHeader = False
        Me.cboPeriodTo.Properties.ValueMember = "Period"
        Me.cboPeriodTo.Size = New System.Drawing.Size(304, 22)
        Me.cboPeriodTo.StyleController = Me.LayoutControl6
        Me.cboPeriodTo.TabIndex = 9
        '
        'GridKPI
        '
        Me.GridKPI.Location = New System.Drawing.Point(10, 59)
        Me.GridKPI.MainView = Me.GridKPIView
        Me.GridKPI.Name = "GridKPI"
        Me.GridKPI.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repPeriod, Me.repKPIPeriod, Me.repKPIMemoEdit})
        Me.GridKPI.Size = New System.Drawing.Size(375, 334)
        Me.GridKPI.TabIndex = 6
        Me.GridKPI.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridKPIView})
        '
        'GridKPIView
        '
        Me.GridKPIView.Appearance.SelectedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridKPIView.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridKPIView.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridKPIView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colKPIPKey, Me.colKPIName, Me.colKPIPeriod, Me.colStoredProcedureName, Me.colKPIType, Me.colSelectionListing, Me.colPeriod, Me.colCategory})
        Me.GridKPIView.GridControl = Me.GridKPI
        Me.GridKPIView.Name = "GridKPIView"
        Me.GridKPIView.OptionsBehavior.ReadOnly = True
        Me.GridKPIView.OptionsFind.AlwaysVisible = True
        Me.GridKPIView.OptionsView.RowAutoHeight = True
        Me.GridKPIView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridKPIView.OptionsView.ShowGroupPanel = False
        Me.GridKPIView.OptionsView.ShowIndicator = False
        '
        'colKPIPKey
        '
        Me.colKPIPKey.Caption = "PKey"
        Me.colKPIPKey.FieldName = "PKey"
        Me.colKPIPKey.Name = "colKPIPKey"
        '
        'colKPIName
        '
        Me.colKPIName.Caption = "Name"
        Me.colKPIName.ColumnEdit = Me.repKPIMemoEdit
        Me.colKPIName.FieldName = "KPIName"
        Me.colKPIName.Name = "colKPIName"
        Me.colKPIName.OptionsColumn.AllowFocus = False
        Me.colKPIName.Visible = True
        Me.colKPIName.VisibleIndex = 0
        Me.colKPIName.Width = 183
        '
        'repKPIMemoEdit
        '
        Me.repKPIMemoEdit.Name = "repKPIMemoEdit"
        '
        'colKPIPeriod
        '
        Me.colKPIPeriod.Caption = "Period"
        Me.colKPIPeriod.ColumnEdit = Me.repPeriod
        Me.colKPIPeriod.FieldName = "FKeyPeriod"
        Me.colKPIPeriod.Name = "colKPIPeriod"
        '
        'repPeriod
        '
        Me.repPeriod.AutoHeight = False
        Me.repPeriod.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repPeriod.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.repPeriod.DisplayMember = "Name"
        Me.repPeriod.Name = "repPeriod"
        Me.repPeriod.NullText = ""
        Me.repPeriod.ShowFooter = False
        Me.repPeriod.ShowHeader = False
        Me.repPeriod.ValueMember = "PKey"
        '
        'colStoredProcedureName
        '
        Me.colStoredProcedureName.Caption = "StoredProcedureName"
        Me.colStoredProcedureName.FieldName = "StoredProcedureName"
        Me.colStoredProcedureName.Name = "colStoredProcedureName"
        '
        'colKPIType
        '
        Me.colKPIType.Caption = "KPIType"
        Me.colKPIType.FieldName = "KPIType"
        Me.colKPIType.Name = "colKPIType"
        '
        'colSelectionListing
        '
        Me.colSelectionListing.Caption = "Grouped By"
        Me.colSelectionListing.FieldName = "SelectionListingLabel"
        Me.colSelectionListing.Name = "colSelectionListing"
        Me.colSelectionListing.OptionsColumn.AllowFocus = False
        Me.colSelectionListing.OptionsColumn.FixedWidth = True
        Me.colSelectionListing.Visible = True
        Me.colSelectionListing.VisibleIndex = 1
        Me.colSelectionListing.Width = 71
        '
        'colPeriod
        '
        Me.colPeriod.Caption = "Period"
        Me.colPeriod.FieldName = "PeriodLabel"
        Me.colPeriod.Name = "colPeriod"
        Me.colPeriod.OptionsColumn.AllowEdit = False
        Me.colPeriod.OptionsColumn.AllowFocus = False
        Me.colPeriod.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colPeriod.OptionsColumn.AllowMove = False
        Me.colPeriod.OptionsColumn.AllowShowHide = False
        Me.colPeriod.OptionsColumn.AllowSize = False
        Me.colPeriod.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[True]
        Me.colPeriod.OptionsColumn.FixedWidth = True
        Me.colPeriod.OptionsColumn.ReadOnly = True
        Me.colPeriod.Visible = True
        Me.colPeriod.VisibleIndex = 2
        Me.colPeriod.Width = 70
        '
        'repKPIPeriod
        '
        Me.repKPIPeriod.AutoHeight = False
        Me.repKPIPeriod.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repKPIPeriod.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repKPIPeriod.DisplayMember = "Name"
        Me.repKPIPeriod.Name = "repKPIPeriod"
        Me.repKPIPeriod.NullText = ""
        Me.repKPIPeriod.ShowFooter = False
        Me.repKPIPeriod.ShowHeader = False
        Me.repKPIPeriod.ValueMember = "PKey"
        '
        'colCategory
        '
        Me.colCategory.Caption = "Category"
        Me.colCategory.FieldName = "CategoryLabel"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.Visible = True
        Me.colCategory.VisibleIndex = 3
        Me.colCategory.Width = 49
        '
        'cboPeriodFrom
        '
        Me.cboPeriodFrom.Location = New System.Drawing.Point(73, 478)
        Me.cboPeriodFrom.Name = "cboPeriodFrom"
        Me.cboPeriodFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPeriodFrom.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Period", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodDesc", "PeriodDesc")})
        Me.cboPeriodFrom.Properties.DisplayMember = "PeriodDesc"
        Me.cboPeriodFrom.Properties.DropDownRows = 4
        Me.cboPeriodFrom.Properties.NullText = ""
        Me.cboPeriodFrom.Properties.ShowFooter = False
        Me.cboPeriodFrom.Properties.ShowHeader = False
        Me.cboPeriodFrom.Properties.ValueMember = "Period"
        Me.cboPeriodFrom.Size = New System.Drawing.Size(304, 22)
        Me.cboPeriodFrom.StyleController = Me.LayoutControl6
        Me.cboPeriodFrom.TabIndex = 10
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup5.GroupBordersVisible = False
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup7})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "Root"
        Me.LayoutControlGroup5.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(395, 602)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlGroup7
        '
        Me.LayoutControlGroup7.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup7.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem4, Me.LayoutControlGroup_DateCoverage, Me.LayoutControlItem7})
        Me.LayoutControlGroup7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup7.Name = "LayoutControlGroup7"
        Me.LayoutControlGroup7.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup7.Size = New System.Drawing.Size(395, 602)
        Me.LayoutControlGroup7.Text = "1. Choose KPI"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.GridKPI
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(379, 338)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboKPIType
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(379, 26)
        Me.LayoutControlItem4.Text = "KPI Type:"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(50, 13)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlGroup_DateCoverage
        '
        Me.LayoutControlGroup_DateCoverage.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem_From, Me.LayoutControlItem_To, Me.LayoutControlItem_DateAsOf, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem10})
        Me.LayoutControlGroup_DateCoverage.Location = New System.Drawing.Point(0, 388)
        Me.LayoutControlGroup_DateCoverage.Name = "LayoutControlGroup_DateCoverage"
        Me.LayoutControlGroup_DateCoverage.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_DateCoverage.Size = New System.Drawing.Size(379, 175)
        Me.LayoutControlGroup_DateCoverage.Text = "2. Set Date Coverage"
        '
        'LayoutControlItem_From
        '
        Me.LayoutControlItem_From.Control = Me.cboPeriodFrom
        Me.LayoutControlItem_From.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem_From.Name = "LayoutControlItem_From"
        Me.LayoutControlItem_From.Size = New System.Drawing.Size(363, 26)
        Me.LayoutControlItem_From.Text = "From:"
        Me.LayoutControlItem_From.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem_From.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem_From.TextToControlDistance = 5
        '
        'LayoutControlItem_To
        '
        Me.LayoutControlItem_To.Control = Me.cboPeriodTo
        Me.LayoutControlItem_To.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem_To.Name = "LayoutControlItem_To"
        Me.LayoutControlItem_To.Size = New System.Drawing.Size(363, 26)
        Me.LayoutControlItem_To.Text = "To:"
        Me.LayoutControlItem_To.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem_To.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem_To.TextToControlDistance = 5
        '
        'LayoutControlItem_DateAsOf
        '
        Me.LayoutControlItem_DateAsOf.Control = Me.dateAsOf
        Me.LayoutControlItem_DateAsOf.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem_DateAsOf.Name = "LayoutControlItem_DateAsOf"
        Me.LayoutControlItem_DateAsOf.Size = New System.Drawing.Size(363, 26)
        Me.LayoutControlItem_DateAsOf.Text = "As Of"
        Me.LayoutControlItem_DateAsOf.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem_DateAsOf.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem_DateAsOf.TextToControlDistance = 5
        Me.LayoutControlItem_DateAsOf.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdClearDateCoverage
        Me.LayoutControlItem6.Location = New System.Drawing.Point(181, 104)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(24, 32)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(182, 32)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 104)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(181, 32)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem10.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem10.Control = Me.cboDateCoverageType
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(363, 26)
        Me.LayoutControlItem10.Text = "Date Coverage Type:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(137, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.Label1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 364)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(0, 24)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(24, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(379, 24)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControl7
        '
        Me.LayoutControl7.Controls.Add(Me.SplitContainerControl_Selection_Result)
        Me.LayoutControl7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl7.Name = "LayoutControl7"
        Me.LayoutControl7.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl7.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl7.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl7.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl7.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl7.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl7.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl7.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl7.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl7.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl7.Root = Me.LayoutControlGroup9
        Me.LayoutControl7.Size = New System.Drawing.Size(1072, 602)
        Me.LayoutControl7.TabIndex = 0
        Me.LayoutControl7.Text = "LayoutControl7"
        '
        'SplitContainerControl_Selection_Result
        '
        Me.SplitContainerControl_Selection_Result.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainerControl_Selection_Result.Name = "SplitContainerControl_Selection_Result"
        Me.SplitContainerControl_Selection_Result.Panel1.Controls.Add(Me.LayoutControl2)
        Me.SplitContainerControl_Selection_Result.Panel1.Text = "Panel1"
        Me.SplitContainerControl_Selection_Result.Panel2.Controls.Add(Me.LayoutControl3)
        Me.SplitContainerControl_Selection_Result.Panel2.Text = "Panel2"
        Me.SplitContainerControl_Selection_Result.Size = New System.Drawing.Size(1068, 598)
        Me.SplitContainerControl_Selection_Result.SplitterPosition = 287
        Me.SplitContainerControl_Selection_Result.TabIndex = 4
        Me.SplitContainerControl_Selection_Result.Text = "SplitContainerControl1"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.SplitContainerControl_Selection)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(861, 255, 250, 350)
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
        Me.LayoutControl2.Size = New System.Drawing.Size(287, 598)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'SplitContainerControl_Selection
        '
        Me.SplitContainerControl_Selection.Horizontal = False
        Me.SplitContainerControl_Selection.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainerControl_Selection.Name = "SplitContainerControl_Selection"
        Me.SplitContainerControl_Selection.Panel1.Controls.Add(Me.LayoutControl4)
        Me.SplitContainerControl_Selection.Panel1.Text = "Panel1"
        Me.SplitContainerControl_Selection.Panel2.Controls.Add(Me.LayoutControl5)
        Me.SplitContainerControl_Selection.Panel2.Text = "Panel2"
        Me.SplitContainerControl_Selection.Size = New System.Drawing.Size(283, 594)
        Me.SplitContainerControl_Selection.SplitterPosition = 163
        Me.SplitContainerControl_Selection.TabIndex = 12
        Me.SplitContainerControl_Selection.Text = "SplitContainerControl2"
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.PanelControl_FilterOption)
        Me.LayoutControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl4.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl4.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl4.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl4.Root = Me.LayoutControlGroup4
        Me.LayoutControl4.Size = New System.Drawing.Size(283, 163)
        Me.LayoutControl4.TabIndex = 0
        Me.LayoutControl4.Text = "LayoutControl4"
        '
        'PanelControl_FilterOption
        '
        Me.PanelControl_FilterOption.Location = New System.Drawing.Point(10, 33)
        Me.PanelControl_FilterOption.Name = "PanelControl_FilterOption"
        Me.PanelControl_FilterOption.Size = New System.Drawing.Size(263, 120)
        Me.PanelControl_FilterOption.TabIndex = 11
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_FilterOption})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(283, 163)
        Me.LayoutControlGroup4.TextVisible = False
        '
        'LayoutControlGroup_FilterOption
        '
        Me.LayoutControlGroup_FilterOption.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_FilterOption.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_FilterOption.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem_FilterOption})
        Me.LayoutControlGroup_FilterOption.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_FilterOption.Name = "LayoutControlGroup_FilterOption"
        Me.LayoutControlGroup_FilterOption.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_FilterOption.Size = New System.Drawing.Size(283, 163)
        Me.LayoutControlGroup_FilterOption.Text = "Filter"
        '
        'LayoutControlItem_FilterOption
        '
        Me.LayoutControlItem_FilterOption.Control = Me.PanelControl_FilterOption
        Me.LayoutControlItem_FilterOption.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem_FilterOption.Name = "LayoutControlItem_FilterOption"
        Me.LayoutControlItem_FilterOption.Size = New System.Drawing.Size(267, 124)
        Me.LayoutControlItem_FilterOption.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_FilterOption.TextVisible = False
        '
        'LayoutControl5
        '
        Me.LayoutControl5.Controls.Add(Me.cboSelectionType)
        Me.LayoutControl5.Controls.Add(Me.GridSelectionList)
        Me.LayoutControl5.Controls.Add(Me.cmdDeselectAll)
        Me.LayoutControl5.Controls.Add(Me.cmdSelectAll)
        Me.LayoutControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl5.Name = "LayoutControl5"
        Me.LayoutControl5.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(756, 192, 487, 350)
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl5.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl5.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl5.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl5.Root = Me.LayoutControlGroup6
        Me.LayoutControl5.Size = New System.Drawing.Size(283, 426)
        Me.LayoutControl5.TabIndex = 0
        Me.LayoutControl5.Text = "LayoutControl5"
        '
        'cboSelectionType
        '
        Me.cboSelectionType.Location = New System.Drawing.Point(102, 33)
        Me.cboSelectionType.MenuManager = Me.BarManager_KPI
        Me.cboSelectionType.Name = "cboSelectionType"
        Me.cboSelectionType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSelectionType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboSelectionType.Properties.DisplayMember = "Name"
        Me.cboSelectionType.Properties.NullText = "Choose..."
        Me.cboSelectionType.Properties.ShowFooter = False
        Me.cboSelectionType.Properties.ShowHeader = False
        Me.cboSelectionType.Properties.ValueMember = "Name"
        Me.cboSelectionType.Size = New System.Drawing.Size(171, 22)
        Me.cboSelectionType.StyleController = Me.LayoutControl5
        Me.cboSelectionType.TabIndex = 7
        '
        'GridSelectionList
        '
        Me.GridSelectionList.Location = New System.Drawing.Point(10, 59)
        Me.GridSelectionList.MainView = Me.GridSelectionListView
        Me.GridSelectionList.Name = "GridSelectionList"
        Me.GridSelectionList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repVsl, Me.repSelected})
        Me.GridSelectionList.Size = New System.Drawing.Size(263, 325)
        Me.GridSelectionList.TabIndex = 4
        Me.GridSelectionList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridSelectionListView})
        '
        'GridSelectionListView
        '
        Me.GridSelectionListView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSelectionPKey, Me.colSelectionName, Me.colVslisSelected, Me.colFKeyPrincipal, Me.colFKeyFlt, Me.colVslStat})
        Me.GridSelectionListView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.GridSelectionListView.GridControl = Me.GridSelectionList
        Me.GridSelectionListView.Name = "GridSelectionListView"
        Me.GridSelectionListView.OptionsFind.AlwaysVisible = True
        Me.GridSelectionListView.OptionsSelection.MultiSelect = True
        Me.GridSelectionListView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridSelectionListView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridSelectionListView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridSelectionListView.OptionsView.ShowColumnHeaders = False
        Me.GridSelectionListView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridSelectionListView.OptionsView.ShowGroupPanel = False
        Me.GridSelectionListView.OptionsView.ShowIndicator = False
        '
        'colSelectionPKey
        '
        Me.colSelectionPKey.Caption = "PKey"
        Me.colSelectionPKey.FieldName = "PKey"
        Me.colSelectionPKey.Name = "colSelectionPKey"
        '
        'colSelectionName
        '
        Me.colSelectionName.Caption = "Name"
        Me.colSelectionName.FieldName = "Name"
        Me.colSelectionName.Name = "colSelectionName"
        Me.colSelectionName.OptionsColumn.AllowEdit = False
        Me.colSelectionName.OptionsColumn.AllowFocus = False
        Me.colSelectionName.OptionsColumn.ReadOnly = True
        Me.colSelectionName.Visible = True
        Me.colSelectionName.VisibleIndex = 1
        '
        'colVslisSelected
        '
        Me.colVslisSelected.ColumnEdit = Me.repSelected
        Me.colVslisSelected.FieldName = "isSelected"
        Me.colVslisSelected.Name = "colVslisSelected"
        '
        'repSelected
        '
        Me.repSelected.AutoHeight = False
        Me.repSelected.Name = "repSelected"
        '
        'colFKeyPrincipal
        '
        Me.colFKeyPrincipal.Caption = "FKeyPrincipal"
        Me.colFKeyPrincipal.FieldName = "FKeyPrincipal"
        Me.colFKeyPrincipal.Name = "colFKeyPrincipal"
        '
        'colFKeyFlt
        '
        Me.colFKeyFlt.Caption = "FKeyFlt"
        Me.colFKeyFlt.FieldName = "FKeyFlt"
        Me.colFKeyFlt.Name = "colFKeyFlt"
        '
        'colVslStat
        '
        Me.colVslStat.Caption = "VslStat"
        Me.colVslStat.FieldName = "VslStat"
        Me.colVslStat.Name = "colVslStat"
        '
        'repVsl
        '
        Me.repVsl.AutoHeight = False
        Me.repVsl.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repVsl.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repVsl.DisplayMember = "Name"
        Me.repVsl.Name = "repVsl"
        Me.repVsl.ValueMember = "PKey"
        '
        'cmdDeselectAll
        '
        Me.cmdDeselectAll.Location = New System.Drawing.Point(143, 388)
        Me.cmdDeselectAll.Name = "cmdDeselectAll"
        Me.cmdDeselectAll.Size = New System.Drawing.Size(130, 28)
        Me.cmdDeselectAll.TabIndex = 6
        Me.cmdDeselectAll.Text = "Deselect All"
        Me.cmdDeselectAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(10, 388)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(129, 28)
        Me.cmdSelectAll.TabIndex = 5
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup6.GroupBordersVisible = False
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_Select})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "Root"
        Me.LayoutControlGroup6.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(283, 426)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlGroup_Select
        '
        Me.LayoutControlGroup_Select.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Select.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Select.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem_SelectAll, Me.LayoutControlItem_DeselectAll, Me.LayoutControlItem11})
        Me.LayoutControlGroup_Select.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Select.Name = "LayoutControlGroup_Select"
        Me.LayoutControlGroup_Select.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Select.Size = New System.Drawing.Size(283, 426)
        Me.LayoutControlGroup_Select.Text = "3. Select"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridSelectionList
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(267, 329)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem_SelectAll
        '
        Me.LayoutControlItem_SelectAll.Control = Me.cmdSelectAll
        Me.LayoutControlItem_SelectAll.Location = New System.Drawing.Point(0, 355)
        Me.LayoutControlItem_SelectAll.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem_SelectAll.MinSize = New System.Drawing.Size(24, 32)
        Me.LayoutControlItem_SelectAll.Name = "LayoutControlItem_SelectAll"
        Me.LayoutControlItem_SelectAll.Size = New System.Drawing.Size(133, 32)
        Me.LayoutControlItem_SelectAll.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_SelectAll.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_SelectAll.TextVisible = False
        '
        'LayoutControlItem_DeselectAll
        '
        Me.LayoutControlItem_DeselectAll.Control = Me.cmdDeselectAll
        Me.LayoutControlItem_DeselectAll.Location = New System.Drawing.Point(133, 355)
        Me.LayoutControlItem_DeselectAll.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem_DeselectAll.MinSize = New System.Drawing.Size(24, 32)
        Me.LayoutControlItem_DeselectAll.Name = "LayoutControlItem_DeselectAll"
        Me.LayoutControlItem_DeselectAll.Size = New System.Drawing.Size(134, 32)
        Me.LayoutControlItem_DeselectAll.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_DeselectAll.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_DeselectAll.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cboSelectionType
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(267, 26)
        Me.LayoutControlItem11.Text = "Selection Type:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(287, 598)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SplitContainerControl_Selection
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(287, 598)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.MainChart)
        Me.LayoutControl3.Controls.Add(Me.GridTemplates)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(184, 251, 200, 345)
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
        Me.LayoutControl3.Size = New System.Drawing.Size(776, 598)
        Me.LayoutControl3.TabIndex = 0
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'MainChart
        '
        Me.MainChart.Location = New System.Drawing.Point(10, 34)
        Me.MainChart.Name = "MainChart"
        Me.MainChart.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.MainChart.Size = New System.Drawing.Size(476, 554)
        Me.MainChart.TabIndex = 6
        '
        'GridTemplates
        '
        Me.GridTemplates.Location = New System.Drawing.Point(511, 33)
        Me.GridTemplates.MainView = Me.GridRepTemplates
        Me.GridTemplates.Name = "GridTemplates"
        Me.GridTemplates.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repMemoEdit})
        Me.GridTemplates.Size = New System.Drawing.Size(255, 555)
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
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_Result, Me.LayoutControlGroup_Templates, Me.SplitterItem_Template})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "Root"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(776, 598)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlGroup_Result
        '
        Me.LayoutControlGroup_Result.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Result.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Result.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem_Chart})
        Me.LayoutControlGroup_Result.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Result.Name = "LayoutControlGroup_Result"
        Me.LayoutControlGroup_Result.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Result.Size = New System.Drawing.Size(496, 598)
        Me.LayoutControlGroup_Result.Text = "Result:"
        '
        'LayoutControlItem_Chart
        '
        Me.LayoutControlItem_Chart.Control = Me.MainChart
        Me.LayoutControlItem_Chart.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem_Chart.Name = "LayoutControlItem_Chart"
        Me.LayoutControlItem_Chart.Size = New System.Drawing.Size(480, 558)
        Me.LayoutControlItem_Chart.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Chart.TextVisible = False
        '
        'LayoutControlGroup_Templates
        '
        Me.LayoutControlGroup_Templates.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Templates.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Templates.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup_Templates.Location = New System.Drawing.Point(501, 0)
        Me.LayoutControlGroup_Templates.Name = "LayoutControlGroup_Templates"
        Me.LayoutControlGroup_Templates.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Templates.Size = New System.Drawing.Size(275, 598)
        Me.LayoutControlGroup_Templates.Text = "Saved Templates"
        Me.LayoutControlGroup_Templates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridTemplates
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(259, 559)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'SplitterItem_Template
        '
        Me.SplitterItem_Template.AllowHotTrack = True
        Me.SplitterItem_Template.Location = New System.Drawing.Point(496, 0)
        Me.SplitterItem_Template.Name = "SplitterItem_Template"
        Me.SplitterItem_Template.Size = New System.Drawing.Size(5, 598)
        '
        'LayoutControlGroup9
        '
        Me.LayoutControlGroup9.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup9.GroupBordersVisible = False
        Me.LayoutControlGroup9.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup9.Name = "LayoutControlGroup9"
        Me.LayoutControlGroup9.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup9.Size = New System.Drawing.Size(1072, 602)
        Me.LayoutControlGroup9.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SplitContainerControl_Selection_Result
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1072, 602)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1476, 606)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.SplitContainerControl_KPIList_Selection_Result
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1476, 606)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'RightClickMenu_KPI
        '
        Me.RightClickMenu_KPI.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ViewKPIDetails)})
        Me.RightClickMenu_KPI.Manager = Me.BarManager_KPI
        Me.RightClickMenu_KPI.Name = "RightClickMenu_KPI"
        '
        'RightClickMenu_Templates
        '
        Me.RightClickMenu_Templates.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barGenerateChartFromTemplate)})
        Me.RightClickMenu_Templates.Manager = Me.BarManager_KPI
        Me.RightClickMenu_Templates.Name = "RightClickMenu_Templates"
        '
        'KPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "KPI"
        Me.Size = New System.Drawing.Size(1480, 633)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl_KPIList_Selection_Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl_KPIList_Selection_Result.ResumeLayout(False)
        CType(Me.LayoutControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl6.ResumeLayout(False)
        CType(Me.cboDateCoverageType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager_KPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateAsOf.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateAsOf.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKPIType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridKPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridKPIView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repKPIMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repKPIPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_DateCoverage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_From, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_DateAsOf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl7.ResumeLayout(False)
        CType(Me.SplitContainerControl_Selection_Result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl_Selection_Result.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl_Selection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl_Selection.ResumeLayout(False)
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl4.ResumeLayout(False)
        CType(Me.PanelControl_FilterOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_FilterOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_FilterOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl5.ResumeLayout(False)
        CType(Me.cboSelectionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSelectionList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSelectionListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVsl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Select, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_SelectAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_DeselectAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.MainChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRepTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Result, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Templates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem_Template, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightClickMenu_KPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightClickMenu_Templates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SplitContainerControl_Selection_Result As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Result As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridSelectionList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridSelectionListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents StyleController1 As DevExpress.XtraEditors.StyleController
    Friend WithEvents colSelectionName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repVsl As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridKPI As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridKPIView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colKPIName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colKPIPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repPeriod As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colKPIPeriod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSelectionPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVslisSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repSelected As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cboPeriodTo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboPeriodFrom As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colFKeyPrincipal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyFlt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVslStat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStoredProcedureName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboKPIType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colKPIType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repKPIPeriod As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colPeriod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MainChart As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControlItem_Chart As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdDeselectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents RightClickMenu_KPI As DevExpress.XtraBars.PopupMenu
    Friend WithEvents ViewKPIDetails As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager_KPI As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainerControl_KPIList_Selection_Result As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LayoutControl6 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl7 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup9 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_DateCoverage As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem_From As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_To As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PanelControl_FilterOption As DevExpress.XtraEditors.PanelControl
    Friend WithEvents colSelectionListing As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainerControl_Selection As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_FilterOption As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem_FilterOption As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl5 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Select As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_SelectAll As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_DeselectAll As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repKPIMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents dateAsOf As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem_DateAsOf As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridTemplates As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridRepTemplates As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TemplateName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents TemplateContent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TemplateDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup_Templates As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem_Template As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents barGenerateChartFromTemplate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RightClickMenu_Templates As DevExpress.XtraBars.PopupMenu
    Friend WithEvents cmdClearDateCoverage As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboDateCoverageType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboSelectionType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem

End Class
