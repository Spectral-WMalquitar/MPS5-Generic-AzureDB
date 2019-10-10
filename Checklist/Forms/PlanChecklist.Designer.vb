<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanChecklist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlanChecklist))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.VesselTypeGrid = New DevExpress.XtraGrid.GridControl()
        Me.VesselTypeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmVslTypePKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmVslType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmRankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmYrOfService = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmTotalYrOfService = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmVslTypeComplied = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmVslTypeComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CompetenceDocsGrid = New DevExpress.XtraGrid.GridControl()
        Me.CompetenceDocsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmCompDocuments = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmDocNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmIssueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmExpiryDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmComplied = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCompType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmSorting = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmDocType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmDocStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmDocumentID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCapacity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CrewPlannedGrid = New DevExpress.XtraGrid.GridControl()
        Me.CrewPlannedView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmCrewPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmIDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCrewFullName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCrewRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmHasLackingDoc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmSignOffDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmPlannedDateSOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepFullName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.OnBoardCrewView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PlanningGrid = New DevExpress.XtraGrid.GridControl()
        Me.PlanningView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPlanningEvent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateDep = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVslName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.glcmLackInDocument = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgCompetenceTemplate = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem3 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView2 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridControl5 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.RadioGroup3 = New DevExpress.XtraEditors.RadioGroup()
        Me.DropDownButton3 = New DevExpress.XtraEditors.DropDownButton()
        Me.DropDownButton4 = New DevExpress.XtraEditors.DropDownButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GridControl6 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GridControl7 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView3 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridControl8 = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit10 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CheckEdit2 = New DevExpress.XtraEditors.CheckEdit()
        Me.RadioGroup4 = New DevExpress.XtraEditors.RadioGroup()
        Me.DropDownButton5 = New DevExpress.XtraEditors.DropDownButton()
        Me.DropDownButton6 = New DevExpress.XtraEditors.DropDownButton()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.GridControl9 = New DevExpress.XtraGrid.GridControl()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit11 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit12 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.DropDownButton7 = New DevExpress.XtraEditors.DropDownButton()
        Me.DropDownButton8 = New DevExpress.XtraEditors.DropDownButton()
        Me.CheckEdit3 = New DevExpress.XtraEditors.CheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RecordSum = New DevExpress.XtraBars.BarButtonItem()
        Me.Biodata = New DevExpress.XtraBars.BarButtonItem()
        Me.Document = New DevExpress.XtraBars.BarButtonItem()
        Me.Service = New DevExpress.XtraBars.BarButtonItem()
        Me.Relative = New DevExpress.XtraBars.BarButtonItem()
        Me.Appraisal = New DevExpress.XtraBars.BarButtonItem()
        Me.AddComment = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintBio = New DevExpress.XtraBars.BarButtonItem()
        Me.rightClickMenu = New DevExpress.XtraBars.PopupMenu()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.VesselTypeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VesselTypeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompetenceDocsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompetenceDocsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewPlannedGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewPlannedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepFullName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OnBoardCrewView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanningGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanningView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgCompetenceTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1337, 640)
        Me.header.TabIndex = 7
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.VesselTypeGrid)
        Me.LayoutControl1.Controls.Add(Me.PictureBox1)
        Me.LayoutControl1.Controls.Add(Me.CompetenceDocsGrid)
        Me.LayoutControl1.Controls.Add(Me.CrewPlannedGrid)
        Me.LayoutControl1.Controls.Add(Me.PlanningGrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(584, 376, 714, 502)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1333, 612)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'VesselTypeGrid
        '
        Me.VesselTypeGrid.Location = New System.Drawing.Point(573, 419)
        Me.VesselTypeGrid.MainView = Me.VesselTypeView
        Me.VesselTypeGrid.Name = "VesselTypeGrid"
        Me.VesselTypeGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit2})
        Me.VesselTypeGrid.Size = New System.Drawing.Size(741, 124)
        Me.VesselTypeGrid.TabIndex = 37
        Me.VesselTypeGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.VesselTypeView, Me.GridView7})
        '
        'VesselTypeView
        '
        Me.VesselTypeView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.VesselTypeView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselTypeView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.VesselTypeView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselTypeView.Appearance.Row.Options.UseTextOptions = True
        Me.VesselTypeView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselTypeView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.VesselTypeView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.VesselTypeView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.VesselTypeView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VesselTypeView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.VesselTypeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmVslTypePKey, Me.glcmVslType, Me.glcmRankName, Me.glcmYrOfService, Me.glcmTotalYrOfService, Me.glcmVslTypeComplied, Me.glcmVslTypeComment})
        Me.VesselTypeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.VesselTypeView.GridControl = Me.VesselTypeGrid
        Me.VesselTypeView.Name = "VesselTypeView"
        Me.VesselTypeView.NewItemRowText = "Add New Rank Here"
        Me.VesselTypeView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.VesselTypeView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.VesselTypeView.OptionsBehavior.AutoExpandAllGroups = True
        Me.VesselTypeView.OptionsBehavior.AutoPopulateColumns = False
        Me.VesselTypeView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.VesselTypeView.OptionsCustomization.AllowFilter = False
        Me.VesselTypeView.OptionsCustomization.AllowQuickHideColumns = False
        Me.VesselTypeView.OptionsDetail.EnableMasterViewMode = False
        Me.VesselTypeView.OptionsFilter.AllowFilterEditor = False
        Me.VesselTypeView.OptionsFind.AllowFindPanel = False
        Me.VesselTypeView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.VesselTypeView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.VesselTypeView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.VesselTypeView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.VesselTypeView.OptionsSelection.UseIndicatorForSelection = False
        Me.VesselTypeView.OptionsView.ShowGroupedColumns = True
        Me.VesselTypeView.OptionsView.ShowGroupPanel = False
        '
        'glcmVslTypePKey
        '
        Me.glcmVslTypePKey.FieldName = "VslTypePKey"
        Me.glcmVslTypePKey.Name = "glcmVslTypePKey"
        '
        'glcmVslType
        '
        Me.glcmVslType.Caption = "Vessel Type"
        Me.glcmVslType.FieldName = "VslType"
        Me.glcmVslType.Name = "glcmVslType"
        Me.glcmVslType.OptionsColumn.AllowEdit = False
        Me.glcmVslType.Visible = True
        Me.glcmVslType.VisibleIndex = 0
        Me.glcmVslType.Width = 125
        '
        'glcmRankName
        '
        Me.glcmRankName.Caption = "Rank Name"
        Me.glcmRankName.FieldName = "RankName"
        Me.glcmRankName.Name = "glcmRankName"
        Me.glcmRankName.OptionsColumn.AllowEdit = False
        Me.glcmRankName.Visible = True
        Me.glcmRankName.VisibleIndex = 1
        Me.glcmRankName.Width = 61
        '
        'glcmYrOfService
        '
        Me.glcmYrOfService.Caption = "Required Years of Service"
        Me.glcmYrOfService.FieldName = "YrOfService"
        Me.glcmYrOfService.Name = "glcmYrOfService"
        Me.glcmYrOfService.OptionsColumn.AllowEdit = False
        Me.glcmYrOfService.Visible = True
        Me.glcmYrOfService.VisibleIndex = 2
        Me.glcmYrOfService.Width = 133
        '
        'glcmTotalYrOfService
        '
        Me.glcmTotalYrOfService.Caption = "Total Years of Service on Vessel Type"
        Me.glcmTotalYrOfService.FieldName = "TotalYrsOfService"
        Me.glcmTotalYrOfService.Name = "glcmTotalYrOfService"
        Me.glcmTotalYrOfService.OptionsColumn.AllowEdit = False
        Me.glcmTotalYrOfService.Visible = True
        Me.glcmTotalYrOfService.VisibleIndex = 3
        Me.glcmTotalYrOfService.Width = 113
        '
        'glcmVslTypeComplied
        '
        Me.glcmVslTypeComplied.Caption = "Complied"
        Me.glcmVslTypeComplied.FieldName = "Complied"
        Me.glcmVslTypeComplied.Name = "glcmVslTypeComplied"
        Me.glcmVslTypeComplied.OptionsColumn.AllowEdit = False
        Me.glcmVslTypeComplied.Visible = True
        Me.glcmVslTypeComplied.VisibleIndex = 4
        Me.glcmVslTypeComplied.Width = 53
        '
        'glcmVslTypeComment
        '
        Me.glcmVslTypeComment.Caption = "Comment"
        Me.glcmVslTypeComment.FieldName = "Comment"
        Me.glcmVslTypeComment.Name = "glcmVslTypeComment"
        Me.glcmVslTypeComment.OptionsColumn.AllowEdit = False
        Me.glcmVslTypeComment.Width = 126
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit2.DisplayMember = "FullName"
        Me.RepositoryItemLookUpEdit2.DropDownRows = 10
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.ShowFooter = False
        Me.RepositoryItemLookUpEdit2.ShowHeader = False
        Me.RepositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.RepositoryItemLookUpEdit2.ValueMember = "FKeyIDNbr"
        '
        'GridView7
        '
        Me.GridView7.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView7.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView7.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView7.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView7.Appearance.Row.Options.UseTextOptions = True
        Me.GridView7.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView7.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView7.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView7.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView7.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView7.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView7.GridControl = Me.VesselTypeGrid
        Me.GridView7.Name = "GridView7"
        Me.GridView7.NewItemRowText = "Add New Rank Here"
        Me.GridView7.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView7.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView7.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView7.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView7.OptionsCustomization.AllowFilter = False
        Me.GridView7.OptionsCustomization.AllowGroup = False
        Me.GridView7.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView7.OptionsDetail.EnableMasterViewMode = False
        Me.GridView7.OptionsFilter.AllowFilterEditor = False
        Me.GridView7.OptionsFind.AllowFindPanel = False
        Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView7.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView7.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView7.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView7.OptionsView.ShowGroupPanel = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(573, 547)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(741, 46)
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        '
        'CompetenceDocsGrid
        '
        Me.CompetenceDocsGrid.Location = New System.Drawing.Point(573, 41)
        Me.CompetenceDocsGrid.MainView = Me.CompetenceDocsView
        Me.CompetenceDocsGrid.Name = "CompetenceDocsGrid"
        Me.CompetenceDocsGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1})
        Me.CompetenceDocsGrid.Size = New System.Drawing.Size(741, 369)
        Me.CompetenceDocsGrid.TabIndex = 3
        Me.CompetenceDocsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CompetenceDocsView, Me.GridView2})
        '
        'CompetenceDocsView
        '
        Me.CompetenceDocsView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CompetenceDocsView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CompetenceDocsView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CompetenceDocsView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CompetenceDocsView.Appearance.Row.Options.UseTextOptions = True
        Me.CompetenceDocsView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CompetenceDocsView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CompetenceDocsView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CompetenceDocsView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CompetenceDocsView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CompetenceDocsView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CompetenceDocsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmCompDocuments, Me.glcmDocNumber, Me.glcmIssueDate, Me.glcmExpiryDate, Me.glcmComplied, Me.glcmComment, Me.glcmCompType, Me.glcmSorting, Me.glcmDocType, Me.glcmEdited, Me.glcmDocStatus, Me.glcmDocumentID, Me.glcmCountry, Me.glcmCapacity})
        Me.CompetenceDocsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.CompetenceDocsView.GridControl = Me.CompetenceDocsGrid
        Me.CompetenceDocsView.Name = "CompetenceDocsView"
        Me.CompetenceDocsView.NewItemRowText = "Add New Rank Here"
        Me.CompetenceDocsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CompetenceDocsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CompetenceDocsView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CompetenceDocsView.OptionsBehavior.AutoPopulateColumns = False
        Me.CompetenceDocsView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CompetenceDocsView.OptionsCustomization.AllowFilter = False
        Me.CompetenceDocsView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CompetenceDocsView.OptionsDetail.EnableMasterViewMode = False
        Me.CompetenceDocsView.OptionsFilter.AllowFilterEditor = False
        Me.CompetenceDocsView.OptionsFind.AllowFindPanel = False
        Me.CompetenceDocsView.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.CompetenceDocsView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CompetenceDocsView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CompetenceDocsView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CompetenceDocsView.OptionsSelection.UseIndicatorForSelection = False
        Me.CompetenceDocsView.OptionsView.ShowGroupedColumns = True
        Me.CompetenceDocsView.OptionsView.ShowGroupPanel = False
        '
        'glcmCompDocuments
        '
        Me.glcmCompDocuments.Caption = "Document Type"
        Me.glcmCompDocuments.FieldName = "DocName"
        Me.glcmCompDocuments.Name = "glcmCompDocuments"
        Me.glcmCompDocuments.OptionsColumn.AllowEdit = False
        Me.glcmCompDocuments.Visible = True
        Me.glcmCompDocuments.VisibleIndex = 0
        Me.glcmCompDocuments.Width = 206
        '
        'glcmDocNumber
        '
        Me.glcmDocNumber.Caption = "Number"
        Me.glcmDocNumber.FieldName = "Number"
        Me.glcmDocNumber.Name = "glcmDocNumber"
        Me.glcmDocNumber.OptionsColumn.AllowEdit = False
        Me.glcmDocNumber.Visible = True
        Me.glcmDocNumber.VisibleIndex = 1
        Me.glcmDocNumber.Width = 82
        '
        'glcmIssueDate
        '
        Me.glcmIssueDate.Caption = "Issue Date"
        Me.glcmIssueDate.FieldName = "Issue"
        Me.glcmIssueDate.Name = "glcmIssueDate"
        Me.glcmIssueDate.OptionsColumn.AllowEdit = False
        Me.glcmIssueDate.Visible = True
        Me.glcmIssueDate.VisibleIndex = 2
        Me.glcmIssueDate.Width = 65
        '
        'glcmExpiryDate
        '
        Me.glcmExpiryDate.Caption = "Expiry Date"
        Me.glcmExpiryDate.FieldName = "Expiry"
        Me.glcmExpiryDate.Name = "glcmExpiryDate"
        Me.glcmExpiryDate.OptionsColumn.AllowEdit = False
        Me.glcmExpiryDate.Visible = True
        Me.glcmExpiryDate.VisibleIndex = 3
        Me.glcmExpiryDate.Width = 69
        '
        'glcmComplied
        '
        Me.glcmComplied.AppearanceHeader.Options.UseTextOptions = True
        Me.glcmComplied.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.glcmComplied.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.glcmComplied.Caption = "Complied"
        Me.glcmComplied.FieldName = "Complied"
        Me.glcmComplied.Name = "glcmComplied"
        Me.glcmComplied.OptionsColumn.AllowEdit = False
        Me.glcmComplied.Visible = True
        Me.glcmComplied.VisibleIndex = 4
        Me.glcmComplied.Width = 55
        '
        'glcmComment
        '
        Me.glcmComment.Caption = "Comment"
        Me.glcmComment.FieldName = "Comment"
        Me.glcmComment.Name = "glcmComment"
        Me.glcmComment.Visible = True
        Me.glcmComment.VisibleIndex = 7
        Me.glcmComment.Width = 141
        '
        'glcmCompType
        '
        Me.glcmCompType.Caption = "CompType"
        Me.glcmCompType.FieldName = "CompType"
        Me.glcmCompType.Name = "glcmCompType"
        Me.glcmCompType.OptionsColumn.AllowEdit = False
        '
        'glcmSorting
        '
        Me.glcmSorting.Caption = "Sorting"
        Me.glcmSorting.FieldName = "Sorting"
        Me.glcmSorting.Name = "glcmSorting"
        Me.glcmSorting.OptionsColumn.AllowEdit = False
        '
        'glcmDocType
        '
        Me.glcmDocType.Caption = "DocType"
        Me.glcmDocType.FieldName = "DocType"
        Me.glcmDocType.Name = "glcmDocType"
        Me.glcmDocType.OptionsColumn.AllowEdit = False
        '
        'glcmEdited
        '
        Me.glcmEdited.Caption = "Edited"
        Me.glcmEdited.FieldName = "Edited"
        Me.glcmEdited.Name = "glcmEdited"
        Me.glcmEdited.OptionsColumn.AllowEdit = False
        '
        'glcmDocStatus
        '
        Me.glcmDocStatus.Caption = "DocStatus"
        Me.glcmDocStatus.FieldName = "DocStatus"
        Me.glcmDocStatus.Name = "glcmDocStatus"
        '
        'glcmDocumentID
        '
        Me.glcmDocumentID.Caption = "DocumentID"
        Me.glcmDocumentID.FieldName = "DocumentID"
        Me.glcmDocumentID.Name = "glcmDocumentID"
        '
        'glcmCountry
        '
        Me.glcmCountry.Caption = "Country"
        Me.glcmCountry.FieldName = "Country"
        Me.glcmCountry.Name = "glcmCountry"
        Me.glcmCountry.Visible = True
        Me.glcmCountry.VisibleIndex = 5
        '
        'glcmCapacity
        '
        Me.glcmCapacity.Caption = "Capacity"
        Me.glcmCapacity.FieldName = "Capacity"
        Me.glcmCapacity.Name = "glcmCapacity"
        Me.glcmCapacity.Visible = True
        Me.glcmCapacity.VisibleIndex = 6
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit1.DisplayMember = "FullName"
        Me.RepositoryItemLookUpEdit1.DropDownRows = 10
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.ShowFooter = False
        Me.RepositoryItemLookUpEdit1.ShowHeader = False
        Me.RepositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.RepositoryItemLookUpEdit1.ValueMember = "FKeyIDNbr"
        '
        'GridView2
        '
        Me.GridView2.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView2.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView2.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView2.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView2.Appearance.Row.Options.UseTextOptions = True
        Me.GridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView2.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView2.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView2.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView2.GridControl = Me.CompetenceDocsGrid
        Me.GridView2.Name = "GridView2"
        Me.GridView2.NewItemRowText = "Add New Rank Here"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView2.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView2.OptionsCustomization.AllowFilter = False
        Me.GridView2.OptionsCustomization.AllowGroup = False
        Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView2.OptionsDetail.EnableMasterViewMode = False
        Me.GridView2.OptionsFilter.AllowFilterEditor = False
        Me.GridView2.OptionsFind.AllowFindPanel = False
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView2.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView2.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'CrewPlannedGrid
        '
        Me.CrewPlannedGrid.Location = New System.Drawing.Point(308, 7)
        Me.CrewPlannedGrid.MainView = Me.CrewPlannedView
        Me.CrewPlannedGrid.Name = "CrewPlannedGrid"
        Me.CrewPlannedGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepFullName})
        Me.CrewPlannedGrid.Size = New System.Drawing.Size(244, 598)
        Me.CrewPlannedGrid.TabIndex = 2
        Me.CrewPlannedGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CrewPlannedView, Me.OnBoardCrewView})
        '
        'CrewPlannedView
        '
        Me.CrewPlannedView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CrewPlannedView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewPlannedView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CrewPlannedView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewPlannedView.Appearance.Row.Options.UseTextOptions = True
        Me.CrewPlannedView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewPlannedView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CrewPlannedView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CrewPlannedView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CrewPlannedView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewPlannedView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CrewPlannedView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmCrewPKey, Me.glcmIDNbr, Me.glcmCrewFullName, Me.glcmCrewRank, Me.glcmHasLackingDoc, Me.glcmSignOffDate, Me.glcmPlannedDateSOn})
        Me.CrewPlannedView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.CrewPlannedView.GridControl = Me.CrewPlannedGrid
        Me.CrewPlannedView.Name = "CrewPlannedView"
        Me.CrewPlannedView.NewItemRowText = "Add New Rank Here"
        Me.CrewPlannedView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CrewPlannedView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CrewPlannedView.OptionsBehavior.AutoPopulateColumns = False
        Me.CrewPlannedView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CrewPlannedView.OptionsCustomization.AllowFilter = False
        Me.CrewPlannedView.OptionsCustomization.AllowGroup = False
        Me.CrewPlannedView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CrewPlannedView.OptionsDetail.EnableMasterViewMode = False
        Me.CrewPlannedView.OptionsFilter.AllowFilterEditor = False
        Me.CrewPlannedView.OptionsFind.AllowFindPanel = False
        Me.CrewPlannedView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CrewPlannedView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CrewPlannedView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CrewPlannedView.OptionsSelection.UseIndicatorForSelection = False
        Me.CrewPlannedView.OptionsView.ShowGroupPanel = False
        '
        'glcmCrewPKey
        '
        Me.glcmCrewPKey.FieldName = "PKey"
        Me.glcmCrewPKey.Name = "glcmCrewPKey"
        '
        'glcmIDNbr
        '
        Me.glcmIDNbr.Caption = "IDNbr"
        Me.glcmIDNbr.FieldName = "IDNbr"
        Me.glcmIDNbr.Name = "glcmIDNbr"
        Me.glcmIDNbr.Width = 114
        '
        'glcmCrewFullName
        '
        Me.glcmCrewFullName.Caption = "Crew Name"
        Me.glcmCrewFullName.FieldName = "CrewName"
        Me.glcmCrewFullName.Name = "glcmCrewFullName"
        Me.glcmCrewFullName.OptionsColumn.AllowEdit = False
        Me.glcmCrewFullName.Visible = True
        Me.glcmCrewFullName.VisibleIndex = 0
        Me.glcmCrewFullName.Width = 118
        '
        'glcmCrewRank
        '
        Me.glcmCrewRank.Caption = "Rank"
        Me.glcmCrewRank.FieldName = "Rank"
        Me.glcmCrewRank.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.glcmCrewRank.Name = "glcmCrewRank"
        Me.glcmCrewRank.OptionsColumn.AllowEdit = False
        Me.glcmCrewRank.Visible = True
        Me.glcmCrewRank.VisibleIndex = 1
        Me.glcmCrewRank.Width = 53
        '
        'glcmHasLackingDoc
        '
        Me.glcmHasLackingDoc.Caption = "HasLackingDoc"
        Me.glcmHasLackingDoc.FieldName = "HasLackingDoc"
        Me.glcmHasLackingDoc.Name = "glcmHasLackingDoc"
        '
        'glcmSignOffDate
        '
        Me.glcmSignOffDate.Caption = "Sign Off Date"
        Me.glcmSignOffDate.FieldName = "DateSignOff"
        Me.glcmSignOffDate.Name = "glcmSignOffDate"
        Me.glcmSignOffDate.OptionsColumn.AllowEdit = False
        Me.glcmSignOffDate.Visible = True
        Me.glcmSignOffDate.VisibleIndex = 2
        '
        'glcmPlannedDateSOn
        '
        Me.glcmPlannedDateSOn.FieldName = "PlannedDateSOn"
        Me.glcmPlannedDateSOn.Name = "glcmPlannedDateSOn"
        Me.glcmPlannedDateSOn.OptionsColumn.AllowEdit = False
        '
        'RepFullName
        '
        Me.RepFullName.AutoHeight = False
        Me.RepFullName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepFullName.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepFullName.DisplayMember = "FullName"
        Me.RepFullName.DropDownRows = 10
        Me.RepFullName.Name = "RepFullName"
        Me.RepFullName.ShowFooter = False
        Me.RepFullName.ShowHeader = False
        Me.RepFullName.ValueMember = "FKeyIDNbr"
        '
        'OnBoardCrewView
        '
        Me.OnBoardCrewView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.OnBoardCrewView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.OnBoardCrewView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.Appearance.Row.Options.UseTextOptions = True
        Me.OnBoardCrewView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.OnBoardCrewView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.OnBoardCrewView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.OnBoardCrewView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.OnBoardCrewView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.OnBoardCrewView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmCrewPKey, Me.glcmIDNbr, Me.glcmCrewFullName, Me.glcmCrewRank})
        Me.OnBoardCrewView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.OnBoardCrewView.GridControl = Me.CrewPlannedGrid
        Me.OnBoardCrewView.Name = "OnBoardCrewView"
        Me.OnBoardCrewView.NewItemRowText = "Add New Rank Here"
        Me.OnBoardCrewView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OnBoardCrewView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.OnBoardCrewView.OptionsBehavior.AutoPopulateColumns = False
        Me.OnBoardCrewView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.OnBoardCrewView.OptionsCustomization.AllowFilter = False
        Me.OnBoardCrewView.OptionsCustomization.AllowGroup = False
        Me.OnBoardCrewView.OptionsCustomization.AllowQuickHideColumns = False
        Me.OnBoardCrewView.OptionsDetail.EnableMasterViewMode = False
        Me.OnBoardCrewView.OptionsFilter.AllowFilterEditor = False
        Me.OnBoardCrewView.OptionsFind.AllowFindPanel = False
        Me.OnBoardCrewView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.OnBoardCrewView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.OnBoardCrewView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.OnBoardCrewView.OptionsSelection.UseIndicatorForSelection = False
        Me.OnBoardCrewView.OptionsView.ShowGroupPanel = False
        '
        'PlanningGrid
        '
        Me.PlanningGrid.Location = New System.Drawing.Point(7, 7)
        Me.PlanningGrid.MainView = Me.PlanningView
        Me.PlanningGrid.Name = "PlanningGrid"
        Me.PlanningGrid.Size = New System.Drawing.Size(292, 598)
        Me.PlanningGrid.TabIndex = 1
        Me.PlanningGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.PlanningView})
        '
        'PlanningView
        '
        Me.PlanningView.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.PlanningView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.PlanningView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.PlanningView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.PlanningView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.PlanningView.Appearance.Row.Options.UseTextOptions = True
        Me.PlanningView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.PlanningView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PlanningView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.PlanningView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.PlanningView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.PlanningView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.PlanningView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.PlanningView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colPlanningEvent, Me.colDateDep, Me.colVslName, Me.glcmLackInDocument})
        Me.PlanningView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.PlanningView.GridControl = Me.PlanningGrid
        Me.PlanningView.Name = "PlanningView"
        Me.PlanningView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.PlanningView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.PlanningView.OptionsBehavior.AutoPopulateColumns = False
        Me.PlanningView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.PlanningView.OptionsBehavior.Editable = False
        Me.PlanningView.OptionsCustomization.AllowFilter = False
        Me.PlanningView.OptionsCustomization.AllowGroup = False
        Me.PlanningView.OptionsCustomization.AllowQuickHideColumns = False
        Me.PlanningView.OptionsDetail.EnableMasterViewMode = False
        Me.PlanningView.OptionsFilter.AllowFilterEditor = False
        Me.PlanningView.OptionsFind.AlwaysVisible = True
        Me.PlanningView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.PlanningView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.PlanningView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.PlanningView.OptionsSelection.UseIndicatorForSelection = False
        Me.PlanningView.OptionsView.ColumnAutoWidth = True
        Me.PlanningView.OptionsView.ShowBands = False
        Me.PlanningView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.PlanningView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Columns.Add(Me.colPlanningEvent)
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Columns.Add(Me.colDateDep)
        Me.GridBand1.Columns.Add(Me.colVslName)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 231
        '
        'colPlanningEvent
        '
        Me.colPlanningEvent.Caption = "Planning Event"
        Me.colPlanningEvent.FieldName = "PlanningEvent"
        Me.colPlanningEvent.Name = "colPlanningEvent"
        Me.colPlanningEvent.Visible = True
        Me.colPlanningEvent.Width = 85
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colDateDep
        '
        Me.colDateDep.Caption = "Departure Date"
        Me.colDateDep.FieldName = "DateDep"
        Me.colDateDep.Name = "colDateDep"
        Me.colDateDep.Visible = True
        Me.colDateDep.Width = 83
        '
        'colVslName
        '
        Me.colVslName.Caption = "Vessel"
        Me.colVslName.FieldName = "VslName"
        Me.colVslName.Name = "colVslName"
        Me.colVslName.Visible = True
        Me.colVslName.Width = 63
        '
        'glcmLackInDocument
        '
        Me.glcmLackInDocument.Caption = "LackInDocument"
        Me.glcmLackInDocument.FieldName = "LackInDocument"
        Me.glcmLackInDocument.Name = "glcmLackInDocument"
        Me.glcmLackInDocument.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.glcmLackInDocument.Visible = True
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.lcgCompetenceTemplate, Me.SplitterItem1, Me.SplitterItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1333, 612)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PlanningGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(296, 602)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CrewPlannedGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(301, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(248, 602)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'lcgCompetenceTemplate
        '
        Me.lcgCompetenceTemplate.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.SplitterItem3})
        Me.lcgCompetenceTemplate.Location = New System.Drawing.Point(554, 0)
        Me.lcgCompetenceTemplate.Name = "lcgCompetenceTemplate"
        Me.lcgCompetenceTemplate.Size = New System.Drawing.Size(769, 602)
        Me.lcgCompetenceTemplate.Text = "Qualification Template "
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.CompetenceDocsGrid
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(745, 373)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PictureBox1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 506)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 50)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(103, 50)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(745, 50)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.VesselTypeGrid
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 378)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(745, 128)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'SplitterItem3
        '
        Me.SplitterItem3.AllowHotTrack = True
        Me.SplitterItem3.Location = New System.Drawing.Point(0, 373)
        Me.SplitterItem3.Name = "SplitterItem3"
        Me.SplitterItem3.Size = New System.Drawing.Size(745, 5)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(549, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 602)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(296, 0)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(5, 602)
        '
        'GridControl4
        '
        Me.GridControl4.Location = New System.Drawing.Point(37, 83)
        Me.GridControl4.MainView = Me.AdvBandedGridView2
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.Size = New System.Drawing.Size(374, 134)
        Me.GridControl4.TabIndex = 10
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView2})
        '
        'AdvBandedGridView2
        '
        Me.AdvBandedGridView2.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.AdvBandedGridView2.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.AdvBandedGridView2.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.Appearance.GroupRow.Options.UseTextOptions = True
        Me.AdvBandedGridView2.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.Appearance.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AdvBandedGridView2.Appearance.RowSeparator.Options.UseBackColor = True
        Me.AdvBandedGridView2.AppearancePrint.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView2.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView2.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.AdvBandedGridView2.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand3})
        Me.AdvBandedGridView2.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn7, Me.BandedGridColumn6, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10})
        Me.AdvBandedGridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.AdvBandedGridView2.GridControl = Me.GridControl4
        Me.AdvBandedGridView2.Name = "AdvBandedGridView2"
        Me.AdvBandedGridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView2.OptionsBehavior.AutoPopulateColumns = False
        Me.AdvBandedGridView2.OptionsBehavior.AutoSelectAllInEditor = False
        Me.AdvBandedGridView2.OptionsBehavior.Editable = False
        Me.AdvBandedGridView2.OptionsCustomization.AllowFilter = False
        Me.AdvBandedGridView2.OptionsCustomization.AllowGroup = False
        Me.AdvBandedGridView2.OptionsCustomization.AllowQuickHideColumns = False
        Me.AdvBandedGridView2.OptionsDetail.EnableMasterViewMode = False
        Me.AdvBandedGridView2.OptionsFilter.AllowFilterEditor = False
        Me.AdvBandedGridView2.OptionsFind.AlwaysVisible = True
        Me.AdvBandedGridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.AdvBandedGridView2.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.AdvBandedGridView2.OptionsSelection.EnableAppearanceHideSelection = False
        Me.AdvBandedGridView2.OptionsSelection.UseIndicatorForSelection = False
        Me.AdvBandedGridView2.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView2.OptionsView.ShowBands = False
        Me.AdvBandedGridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.AdvBandedGridView2.OptionsView.ShowGroupPanel = False
        '
        'GridBand3
        '
        Me.GridBand3.Caption = "GridBand1"
        Me.GridBand3.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn10)
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 0
        Me.GridBand3.Width = 240
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Vessel Name"
        Me.BandedGridColumn6.FieldName = "Name"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 162
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.FieldName = "PKey"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.FieldName = "SortCode"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 78
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.FieldName = "DateUpdated"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.FieldName = "LastUpdatedBy"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        '
        'GridControl5
        '
        Me.GridControl5.Location = New System.Drawing.Point(415, 245)
        Me.GridControl5.MainView = Me.GridView3
        Me.GridControl5.Name = "GridControl5"
        Me.GridControl5.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit5, Me.RepositoryItemLookUpEdit6})
        Me.GridControl5.Size = New System.Drawing.Size(389, 214)
        Me.GridControl5.TabIndex = 17
        Me.GridControl5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView3.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView3.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.Appearance.Row.Options.UseTextOptions = True
        Me.GridView3.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView3.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView3.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView3.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView3.GridControl = Me.GridControl5
        Me.GridView3.Name = "GridView3"
        Me.GridView3.NewItemRowText = "Add New Rank Here"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView3.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView3.OptionsCustomization.AllowFilter = False
        Me.GridView3.OptionsCustomization.AllowGroup = False
        Me.GridView3.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView3.OptionsDetail.EnableMasterViewMode = False
        Me.GridView3.OptionsFilter.AllowFilterEditor = False
        Me.GridView3.OptionsFind.AllowFindPanel = False
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView3.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView3.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.FieldName = "PKey"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "FKeyComp"
        Me.GridColumn13.FieldName = "FKeyComp"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Width = 114
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Full Name"
        Me.GridColumn14.ColumnEdit = Me.RepositoryItemLookUpEdit5
        Me.GridColumn14.FieldName = "FKeyRank"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 107
        '
        'RepositoryItemLookUpEdit5
        '
        Me.RepositoryItemLookUpEdit5.AutoHeight = False
        Me.RepositoryItemLookUpEdit5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit5.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit5.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit5.DropDownRows = 10
        Me.RepositoryItemLookUpEdit5.Name = "RepositoryItemLookUpEdit5"
        Me.RepositoryItemLookUpEdit5.ShowFooter = False
        Me.RepositoryItemLookUpEdit5.ShowHeader = False
        Me.RepositoryItemLookUpEdit5.ValueMember = "PKey"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Edited"
        Me.GridColumn15.FieldName = "Edited"
        Me.GridColumn15.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Rank"
        Me.GridColumn16.FieldName = "IsDelete"
        Me.GridColumn16.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 1
        Me.GridColumn16.Width = 58
        '
        'RepositoryItemLookUpEdit6
        '
        Me.RepositoryItemLookUpEdit6.AutoHeight = False
        Me.RepositoryItemLookUpEdit6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit6.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit6.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit6.DropDownRows = 10
        Me.RepositoryItemLookUpEdit6.Name = "RepositoryItemLookUpEdit6"
        Me.RepositoryItemLookUpEdit6.ShowFooter = False
        Me.RepositoryItemLookUpEdit6.ShowHeader = False
        Me.RepositoryItemLookUpEdit6.ValueMember = "PKey"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(415, 221)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(389, 20)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "4 - Selected for Inclusion in Report"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(374, 20)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "3 - List of Officers"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(374, 20)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "1 - Select a Vessel"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Location = New System.Drawing.Point(415, 83)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Size = New System.Drawing.Size(19, 19)
        Me.CheckEdit1.TabIndex = 23
        '
        'RadioGroup3
        '
        Me.RadioGroup3.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.RadioGroup3.Location = New System.Drawing.Point(808, 83)
        Me.RadioGroup3.Name = "RadioGroup3"
        Me.RadioGroup3.Properties.Columns = 2
        Me.RadioGroup3.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 1"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 2"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 3"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Shell"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Chevron && Total"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Conoco Philips"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Koch")})
        Me.RadioGroup3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioGroup3.Size = New System.Drawing.Size(297, 376)
        Me.RadioGroup3.TabIndex = 18
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Location = New System.Drawing.Point(439, 109)
        Me.DropDownButton3.Name = "DropDownButton3"
        Me.DropDownButton3.Size = New System.Drawing.Size(365, 22)
        Me.DropDownButton3.TabIndex = 15
        Me.DropDownButton3.Text = "Rank Name"
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Location = New System.Drawing.Point(438, 83)
        Me.DropDownButton4.Name = "DropDownButton4"
        Me.DropDownButton4.Size = New System.Drawing.Size(366, 22)
        Me.DropDownButton4.TabIndex = 14
        Me.DropDownButton4.Text = "Vessel Name"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(415, 109)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox1.TabIndex = 24
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GridControl6
        '
        Me.GridControl6.Location = New System.Drawing.Point(37, 245)
        Me.GridControl6.MainView = Me.GridView4
        Me.GridControl6.Name = "GridControl6"
        Me.GridControl6.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit7, Me.RepositoryItemLookUpEdit8})
        Me.GridControl6.Size = New System.Drawing.Size(374, 214)
        Me.GridControl6.TabIndex = 16
        Me.GridControl6.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView4.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView4.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.Appearance.Row.Options.UseTextOptions = True
        Me.GridView4.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView4.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView4.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView4.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView4.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView4.GridControl = Me.GridControl6
        Me.GridView4.Name = "GridView4"
        Me.GridView4.NewItemRowText = "Add New Rank Here"
        Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView4.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView4.OptionsCustomization.AllowFilter = False
        Me.GridView4.OptionsCustomization.AllowGroup = False
        Me.GridView4.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView4.OptionsDetail.EnableMasterViewMode = False
        Me.GridView4.OptionsFilter.AllowFilterEditor = False
        Me.GridView4.OptionsFind.AllowFindPanel = False
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView4.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView4.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn17
        '
        Me.GridColumn17.FieldName = "PKey"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "FKeyComp"
        Me.GridColumn18.FieldName = "FKeyComp"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Width = 114
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Full Name"
        Me.GridColumn19.ColumnEdit = Me.RepositoryItemLookUpEdit7
        Me.GridColumn19.FieldName = "FKeyRank"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        Me.GridColumn19.Width = 107
        '
        'RepositoryItemLookUpEdit7
        '
        Me.RepositoryItemLookUpEdit7.AutoHeight = False
        Me.RepositoryItemLookUpEdit7.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit7.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit7.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit7.DropDownRows = 10
        Me.RepositoryItemLookUpEdit7.Name = "RepositoryItemLookUpEdit7"
        Me.RepositoryItemLookUpEdit7.ShowFooter = False
        Me.RepositoryItemLookUpEdit7.ShowHeader = False
        Me.RepositoryItemLookUpEdit7.ValueMember = "PKey"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Edited"
        Me.GridColumn20.FieldName = "Edited"
        Me.GridColumn20.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Rank"
        Me.GridColumn21.FieldName = "IsDelete"
        Me.GridColumn21.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 1
        Me.GridColumn21.Width = 58
        '
        'RepositoryItemLookUpEdit8
        '
        Me.RepositoryItemLookUpEdit8.AutoHeight = False
        Me.RepositoryItemLookUpEdit8.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit8.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit8.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit8.DropDownRows = 10
        Me.RepositoryItemLookUpEdit8.Name = "RepositoryItemLookUpEdit8"
        Me.RepositoryItemLookUpEdit8.ShowFooter = False
        Me.RepositoryItemLookUpEdit8.ShowHeader = False
        Me.RepositoryItemLookUpEdit8.ValueMember = "PKey"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(808, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(297, 20)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "5- Select a Report"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(415, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(389, 20)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "2 - Filter"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridControl7
        '
        Me.GridControl7.Location = New System.Drawing.Point(37, 83)
        Me.GridControl7.MainView = Me.AdvBandedGridView3
        Me.GridControl7.Name = "GridControl7"
        Me.GridControl7.Size = New System.Drawing.Size(374, 134)
        Me.GridControl7.TabIndex = 10
        Me.GridControl7.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView3})
        '
        'AdvBandedGridView3
        '
        Me.AdvBandedGridView3.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
        Me.AdvBandedGridView3.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.AdvBandedGridView3.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.Appearance.GroupRow.Options.UseTextOptions = True
        Me.AdvBandedGridView3.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.Appearance.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView3.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AdvBandedGridView3.Appearance.RowSeparator.Options.UseBackColor = True
        Me.AdvBandedGridView3.AppearancePrint.Row.Options.UseTextOptions = True
        Me.AdvBandedGridView3.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AdvBandedGridView3.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.AdvBandedGridView3.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand4})
        Me.AdvBandedGridView3.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn12, Me.BandedGridColumn11, Me.BandedGridColumn13, Me.BandedGridColumn14, Me.BandedGridColumn15})
        Me.AdvBandedGridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.AdvBandedGridView3.GridControl = Me.GridControl7
        Me.AdvBandedGridView3.Name = "AdvBandedGridView3"
        Me.AdvBandedGridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.AdvBandedGridView3.OptionsBehavior.AutoPopulateColumns = False
        Me.AdvBandedGridView3.OptionsBehavior.AutoSelectAllInEditor = False
        Me.AdvBandedGridView3.OptionsBehavior.Editable = False
        Me.AdvBandedGridView3.OptionsCustomization.AllowFilter = False
        Me.AdvBandedGridView3.OptionsCustomization.AllowGroup = False
        Me.AdvBandedGridView3.OptionsCustomization.AllowQuickHideColumns = False
        Me.AdvBandedGridView3.OptionsDetail.EnableMasterViewMode = False
        Me.AdvBandedGridView3.OptionsFilter.AllowFilterEditor = False
        Me.AdvBandedGridView3.OptionsFind.AlwaysVisible = True
        Me.AdvBandedGridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.AdvBandedGridView3.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.AdvBandedGridView3.OptionsSelection.EnableAppearanceHideSelection = False
        Me.AdvBandedGridView3.OptionsSelection.UseIndicatorForSelection = False
        Me.AdvBandedGridView3.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView3.OptionsView.ShowBands = False
        Me.AdvBandedGridView3.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.AdvBandedGridView3.OptionsView.ShowGroupPanel = False
        '
        'GridBand4
        '
        Me.GridBand4.Caption = "GridBand1"
        Me.GridBand4.Columns.Add(Me.BandedGridColumn11)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn12)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn13)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn14)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn15)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 0
        Me.GridBand4.Width = 240
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Vessel Name"
        Me.BandedGridColumn11.FieldName = "Name"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Visible = True
        Me.BandedGridColumn11.Width = 162
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.FieldName = "PKey"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.FieldName = "SortCode"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.Visible = True
        Me.BandedGridColumn13.Width = 78
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.FieldName = "DateUpdated"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.FieldName = "LastUpdatedBy"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        '
        'GridControl8
        '
        Me.GridControl8.Location = New System.Drawing.Point(415, 245)
        Me.GridControl8.MainView = Me.GridView5
        Me.GridControl8.Name = "GridControl8"
        Me.GridControl8.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit9, Me.RepositoryItemLookUpEdit10})
        Me.GridControl8.Size = New System.Drawing.Size(389, 214)
        Me.GridControl8.TabIndex = 17
        Me.GridControl8.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView5.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView5.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.Appearance.Row.Options.UseTextOptions = True
        Me.GridView5.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView5.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView5.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView5.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView5.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView5.GridControl = Me.GridControl8
        Me.GridView5.Name = "GridView5"
        Me.GridView5.NewItemRowText = "Add New Rank Here"
        Me.GridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView5.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView5.OptionsCustomization.AllowFilter = False
        Me.GridView5.OptionsCustomization.AllowGroup = False
        Me.GridView5.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView5.OptionsDetail.EnableMasterViewMode = False
        Me.GridView5.OptionsFilter.AllowFilterEditor = False
        Me.GridView5.OptionsFind.AllowFindPanel = False
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView5.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView5.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn22
        '
        Me.GridColumn22.FieldName = "PKey"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "FKeyComp"
        Me.GridColumn23.FieldName = "FKeyComp"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Width = 114
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Full Name"
        Me.GridColumn24.ColumnEdit = Me.RepositoryItemLookUpEdit9
        Me.GridColumn24.FieldName = "FKeyRank"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 0
        Me.GridColumn24.Width = 107
        '
        'RepositoryItemLookUpEdit9
        '
        Me.RepositoryItemLookUpEdit9.AutoHeight = False
        Me.RepositoryItemLookUpEdit9.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit9.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit9.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit9.DropDownRows = 10
        Me.RepositoryItemLookUpEdit9.Name = "RepositoryItemLookUpEdit9"
        Me.RepositoryItemLookUpEdit9.ShowFooter = False
        Me.RepositoryItemLookUpEdit9.ShowHeader = False
        Me.RepositoryItemLookUpEdit9.ValueMember = "PKey"
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Edited"
        Me.GridColumn25.FieldName = "Edited"
        Me.GridColumn25.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn25.Name = "GridColumn25"
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Rank"
        Me.GridColumn26.FieldName = "IsDelete"
        Me.GridColumn26.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 1
        Me.GridColumn26.Width = 58
        '
        'RepositoryItemLookUpEdit10
        '
        Me.RepositoryItemLookUpEdit10.AutoHeight = False
        Me.RepositoryItemLookUpEdit10.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit10.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit10.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit10.DropDownRows = 10
        Me.RepositoryItemLookUpEdit10.Name = "RepositoryItemLookUpEdit10"
        Me.RepositoryItemLookUpEdit10.ShowFooter = False
        Me.RepositoryItemLookUpEdit10.ShowHeader = False
        Me.RepositoryItemLookUpEdit10.ValueMember = "PKey"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(415, 221)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(389, 20)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "4 - Selected for Inclusion in Report"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(37, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(374, 20)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "3 - List of Officers"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(37, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(374, 20)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "1 - Select a Vessel"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckEdit2
        '
        Me.CheckEdit2.Location = New System.Drawing.Point(415, 83)
        Me.CheckEdit2.Name = "CheckEdit2"
        Me.CheckEdit2.Size = New System.Drawing.Size(19, 19)
        Me.CheckEdit2.TabIndex = 23
        '
        'RadioGroup4
        '
        Me.RadioGroup4.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.RadioGroup4.Location = New System.Drawing.Point(808, 83)
        Me.RadioGroup4.Name = "RadioGroup4"
        Me.RadioGroup4.Properties.Columns = 2
        Me.RadioGroup4.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 1"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 2"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Report Version 3"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Shell"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Chevron && Total"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Conoco Philips"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Koch")})
        Me.RadioGroup4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadioGroup4.Size = New System.Drawing.Size(297, 376)
        Me.RadioGroup4.TabIndex = 18
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Location = New System.Drawing.Point(439, 109)
        Me.DropDownButton5.Name = "DropDownButton5"
        Me.DropDownButton5.Size = New System.Drawing.Size(365, 22)
        Me.DropDownButton5.TabIndex = 15
        Me.DropDownButton5.Text = "Rank Name"
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Location = New System.Drawing.Point(438, 83)
        Me.DropDownButton6.Name = "DropDownButton6"
        Me.DropDownButton6.Size = New System.Drawing.Size(366, 22)
        Me.DropDownButton6.TabIndex = 14
        Me.DropDownButton6.Text = "Vessel Name"
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(415, 109)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox2.TabIndex = 24
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'GridControl9
        '
        Me.GridControl9.Location = New System.Drawing.Point(37, 245)
        Me.GridControl9.MainView = Me.GridView6
        Me.GridControl9.Name = "GridControl9"
        Me.GridControl9.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit11, Me.RepositoryItemLookUpEdit12})
        Me.GridControl9.Size = New System.Drawing.Size(374, 214)
        Me.GridControl9.TabIndex = 16
        Me.GridControl9.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView6})
        '
        'GridView6
        '
        Me.GridView6.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.GridView6.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.Appearance.GroupRow.Options.UseTextOptions = True
        Me.GridView6.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.Appearance.Row.Options.UseTextOptions = True
        Me.GridView6.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridView6.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView6.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GridView6.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridView6.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31})
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.GridView6.GridControl = Me.GridControl9
        Me.GridView6.Name = "GridView6"
        Me.GridView6.NewItemRowText = "Add New Rank Here"
        Me.GridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView6.OptionsBehavior.AutoSelectAllInEditor = False
        Me.GridView6.OptionsCustomization.AllowFilter = False
        Me.GridView6.OptionsCustomization.AllowGroup = False
        Me.GridView6.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView6.OptionsDetail.EnableMasterViewMode = False
        Me.GridView6.OptionsFilter.AllowFilterEditor = False
        Me.GridView6.OptionsFind.AllowFindPanel = False
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GridView6.OptionsSelection.EnableAppearanceHideSelection = False
        Me.GridView6.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn27
        '
        Me.GridColumn27.FieldName = "PKey"
        Me.GridColumn27.Name = "GridColumn27"
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "FKeyComp"
        Me.GridColumn28.FieldName = "FKeyComp"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Width = 114
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Full Name"
        Me.GridColumn29.ColumnEdit = Me.RepositoryItemLookUpEdit11
        Me.GridColumn29.FieldName = "FKeyRank"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        Me.GridColumn29.Width = 107
        '
        'RepositoryItemLookUpEdit11
        '
        Me.RepositoryItemLookUpEdit11.AutoHeight = False
        Me.RepositoryItemLookUpEdit11.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit11.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit11.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit11.DropDownRows = 10
        Me.RepositoryItemLookUpEdit11.Name = "RepositoryItemLookUpEdit11"
        Me.RepositoryItemLookUpEdit11.ShowFooter = False
        Me.RepositoryItemLookUpEdit11.ShowHeader = False
        Me.RepositoryItemLookUpEdit11.ValueMember = "PKey"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Edited"
        Me.GridColumn30.FieldName = "Edited"
        Me.GridColumn30.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn30.Name = "GridColumn30"
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Rank"
        Me.GridColumn31.FieldName = "IsDelete"
        Me.GridColumn31.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.ToolTip = "Tick rank that you want to remove."
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 1
        Me.GridColumn31.Width = 58
        '
        'RepositoryItemLookUpEdit12
        '
        Me.RepositoryItemLookUpEdit12.AutoHeight = False
        Me.RepositoryItemLookUpEdit12.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit12.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepositoryItemLookUpEdit12.DisplayMember = "Name"
        Me.RepositoryItemLookUpEdit12.DropDownRows = 10
        Me.RepositoryItemLookUpEdit12.Name = "RepositoryItemLookUpEdit12"
        Me.RepositoryItemLookUpEdit12.ShowFooter = False
        Me.RepositoryItemLookUpEdit12.ShowHeader = False
        Me.RepositoryItemLookUpEdit12.ValueMember = "PKey"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(808, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(297, 20)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "5- Select a Report"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(415, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(389, 20)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "2 - Filter"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox3
        '
        Me.CheckBox3.Location = New System.Drawing.Point(415, 113)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(20, 20)
        Me.CheckBox3.TabIndex = 24
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Location = New System.Drawing.Point(438, 87)
        Me.DropDownButton7.Name = "DropDownButton7"
        Me.DropDownButton7.Size = New System.Drawing.Size(366, 22)
        Me.DropDownButton7.TabIndex = 14
        Me.DropDownButton7.Text = "Vessel Name"
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Location = New System.Drawing.Point(439, 113)
        Me.DropDownButton8.Name = "DropDownButton8"
        Me.DropDownButton8.Size = New System.Drawing.Size(365, 22)
        Me.DropDownButton8.TabIndex = 15
        Me.DropDownButton8.Text = "Rank Name"
        '
        'CheckEdit3
        '
        Me.CheckEdit3.Location = New System.Drawing.Point(415, 87)
        Me.CheckEdit3.Name = "CheckEdit3"
        Me.CheckEdit3.Size = New System.Drawing.Size(19, 19)
        Me.CheckEdit3.TabIndex = 23
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RecordSum, Me.Biodata, Me.Document, Me.Service, Me.Relative, Me.Appraisal, Me.AddComment, Me.PrintBio})
        Me.BarManager1.MaxItemId = 18
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlTop.Size = New System.Drawing.Size(1337, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 640)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1337, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 640)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1337, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 640)
        '
        'RecordSum
        '
        Me.RecordSum.Caption = "Record Summary"
        Me.RecordSum.Glyph = CType(resources.GetObject("RecordSum.Glyph"), System.Drawing.Image)
        Me.RecordSum.Id = 10
        Me.RecordSum.Name = "RecordSum"
        '
        'Biodata
        '
        Me.Biodata.Caption = "Biodata"
        Me.Biodata.Glyph = CType(resources.GetObject("Biodata.Glyph"), System.Drawing.Image)
        Me.Biodata.Id = 11
        Me.Biodata.Name = "Biodata"
        '
        'Document
        '
        Me.Document.Caption = "Documents"
        Me.Document.Glyph = CType(resources.GetObject("Document.Glyph"), System.Drawing.Image)
        Me.Document.Id = 12
        Me.Document.Name = "Document"
        '
        'Service
        '
        Me.Service.Caption = "Service"
        Me.Service.Glyph = CType(resources.GetObject("Service.Glyph"), System.Drawing.Image)
        Me.Service.Id = 13
        Me.Service.Name = "Service"
        '
        'Relative
        '
        Me.Relative.Caption = "Relatives"
        Me.Relative.Glyph = CType(resources.GetObject("Relative.Glyph"), System.Drawing.Image)
        Me.Relative.Id = 14
        Me.Relative.Name = "Relative"
        '
        'Appraisal
        '
        Me.Appraisal.Caption = "Appraisals"
        Me.Appraisal.Glyph = CType(resources.GetObject("Appraisal.Glyph"), System.Drawing.Image)
        Me.Appraisal.Id = 15
        Me.Appraisal.Name = "Appraisal"
        '
        'AddComment
        '
        Me.AddComment.Caption = "View/Add Comments"
        Me.AddComment.Glyph = CType(resources.GetObject("AddComment.Glyph"), System.Drawing.Image)
        Me.AddComment.Id = 16
        Me.AddComment.Name = "AddComment"
        '
        'PrintBio
        '
        Me.PrintBio.Caption = "Print Biodata"
        Me.PrintBio.Glyph = CType(resources.GetObject("PrintBio.Glyph"), System.Drawing.Image)
        Me.PrintBio.Id = 17
        Me.PrintBio.Name = "PrintBio"
        '
        'rightClickMenu
        '
        Me.rightClickMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.RecordSum), New DevExpress.XtraBars.LinkPersistInfo(Me.Biodata), New DevExpress.XtraBars.LinkPersistInfo(Me.Document), New DevExpress.XtraBars.LinkPersistInfo(Me.Service), New DevExpress.XtraBars.LinkPersistInfo(Me.Relative), New DevExpress.XtraBars.LinkPersistInfo(Me.Appraisal), New DevExpress.XtraBars.LinkPersistInfo(Me.AddComment, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintBio)})
        Me.rightClickMenu.Manager = Me.BarManager1
        Me.rightClickMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText
        Me.rightClickMenu.Name = "rightClickMenu"
        '
        'PlanChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "PlanChecklist"
        Me.Size = New System.Drawing.Size(1337, 640)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.VesselTypeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VesselTypeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompetenceDocsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompetenceDocsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewPlannedGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewPlannedView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepFullName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OnBoardCrewView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanningGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanningView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgCompetenceTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView2 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridControl5 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RadioGroup3 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents DropDownButton3 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents DropDownButton4 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GridControl6 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GridControl7 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView3 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridControl8 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit10 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CheckEdit2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RadioGroup4 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents DropDownButton5 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents DropDownButton6 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents GridControl9 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit11 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit12 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents DropDownButton7 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents DropDownButton8 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents CheckEdit3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PlanningGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents PlanningView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colPlanningEvent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDateDep As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVslName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CrewPlannedGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CrewPlannedView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents glcmCrewPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmIDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCrewFullName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCrewRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepFullName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents OnBoardCrewView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CompetenceDocsGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CompetenceDocsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lcgCompetenceTemplate As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents glcmCompDocuments As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDocNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmIssueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmExpiryDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmComplied As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCompType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmSorting As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDocType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDocStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDocumentID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RecordSum As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Biodata As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Document As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Service As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Relative As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Appraisal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AddComment As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintBio As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rightClickMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents glcmHasLackingDoc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmLackInDocument As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents glcmSignOffDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents glcmPlannedDateSOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VesselTypeGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents VesselTypeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents glcmVslTypePKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmVslType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmRankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmYrOfService As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmTotalYrOfService As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmVslTypeComplied As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmVslTypeComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents glcmCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCapacity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitterItem3 As DevExpress.XtraLayout.SplitterItem

End Class
