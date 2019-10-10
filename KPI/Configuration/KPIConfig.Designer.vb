<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KPIConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KPIConfig))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkCanChangeFKeyPeriod = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCanChangeSelectionListing = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowCrewInSelectionListing = New DevExpress.XtraEditors.CheckEdit()
        Me.chkGroupGrid = New DevExpress.XtraEditors.CheckEdit()
        Me.cboGenerateScript = New DevExpress.XtraEditors.LookUpEdit()
        Me.GridFilterOptions = New DevExpress.XtraGrid.GridControl()
        Me.GridFilterOptionsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFilterOption = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repApplyToReportSource = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRowSourceHasUserDataFilter = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.txtPKey = New DevExpress.XtraEditors.TextEdit()
        Me.chkUserPercentage = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowShownInGenerateListOnly = New DevExpress.XtraEditors.CheckEdit()
        Me.cboCategory = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFormula = New DevExpress.XtraEditors.TextEdit()
        Me.cboDefaultChartView = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFleetFieldName = New DevExpress.XtraEditors.TextEdit()
        Me.txtPrinFieldName = New DevExpress.XtraEditors.TextEdit()
        Me.txtAgentFieldName = New DevExpress.XtraEditors.TextEdit()
        Me.txtFooterNote = New DevExpress.XtraEditors.TextEdit()
        Me.isMultiSelection = New DevExpress.XtraEditors.CheckEdit()
        Me.isNeedDateCoverage = New DevExpress.XtraEditors.CheckEdit()
        Me.txtStoredProcedureName = New DevExpress.XtraEditors.TextEdit()
        Me.chkShowInGenerateList = New DevExpress.XtraEditors.CheckEdit()
        Me.txtSubTitle = New DevExpress.XtraEditors.TextEdit()
        Me.cboTimePeriod = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboSelectionListing = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtAxisYLabel = New DevExpress.XtraEditors.TextEdit()
        Me.txtAxisXLabel = New DevExpress.XtraEditors.TextEdit()
        Me.cmdFormulaRemove = New System.Windows.Forms.Button()
        Me.cmdFormulaChange = New System.Windows.Forms.Button()
        Me.imgFormula = New DevExpress.XtraEditors.PictureEdit()
        Me.txtTarget = New DevExpress.XtraEditors.TextEdit()
        Me.txtMinReq = New DevExpress.XtraEditors.TextEdit()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdAddReportGroup = New System.Windows.Forms.Button()
        Me.cmdMoveDownFilterOption = New System.Windows.Forms.Button()
        Me.cmdMoveUpFilterOption = New System.Windows.Forms.Button()
        Me.cmdDeleteFilterOption = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdEditCancel = New System.Windows.Forms.Button()
        Me.cmdAddSave = New System.Windows.Forms.Button()
        Me.GridFilterOptions_Addl = New DevExpress.XtraGrid.GridControl()
        Me.GridFilterOptionsView_Addl = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFilterEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRowNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterSortCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterCaption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterFKeyFilterOption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFilterOption_Addl = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colFilter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterOperator = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterComboBoxCustomRowSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterCustomRowSourceKeyField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterCustomRowSourceDisplayField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterIsApplyToReportSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repApplyToReportSource_Addl = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colFilterRowSourceHasUserDataFilter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRowSourceHasUserDataFilter_Addl = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.txtNbr = New DevExpress.XtraEditors.TextEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.cboKPITypeSelected = New DevExpress.XtraEditors.LookUpEdit()
        Me.GridKPI = New DevExpress.XtraGrid.GridControl()
        Me.GridKPIView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboKPIType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Main = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem37 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.tabDetails = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup_KPIDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_Details = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_MainDetail = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem38 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_ShowCrewInSelectionListing = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem35 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem39 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Computation = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_FormulaImage = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_Change = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_Remove = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_FormulaString = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_DateCoverage = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_DataFilter = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_StoredProcedureName = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_DefaultFilterOptions = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_AdditionalFilterOptions = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_FilterOptionGeneric = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem_Add = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_Edit = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem_Delete = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem36 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkCanChangeFKeyPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCanChangeSelectionListing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowCrewInSelectionListing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGroupGrid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGenerateScript.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFilterOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFilterOptionsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFilterOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repApplyToReportSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRowSourceHasUserDataFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPKey.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUserPercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowShownInGenerateListOnly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormula.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDefaultChartView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFleetFieldName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrinFieldName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAgentFieldName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFooterNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.isMultiSelection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.isNeedDateCoverage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStoredProcedureName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowInGenerateList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTimePeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSelectionListing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAxisYLabel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAxisXLabel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFormula.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinReq.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFilterOptions_Addl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFilterOptionsView_Addl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFilterOption_Addl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repApplyToReportSource_Addl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRowSourceHasUserDataFilter_Addl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNbr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKPITypeSelected.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridKPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridKPIView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboKPIType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_KPIDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Details, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_MainDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_ShowCrewInSelectionListing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Computation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_FormulaImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Change, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Remove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_FormulaString, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_DateCoverage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_DataFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_StoredProcedureName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_DefaultFilterOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_AdditionalFilterOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_FilterOptionGeneric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Add, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Delete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkCanChangeFKeyPeriod)
        Me.LayoutControl1.Controls.Add(Me.chkCanChangeSelectionListing)
        Me.LayoutControl1.Controls.Add(Me.chkShowCrewInSelectionListing)
        Me.LayoutControl1.Controls.Add(Me.chkGroupGrid)
        Me.LayoutControl1.Controls.Add(Me.cboGenerateScript)
        Me.LayoutControl1.Controls.Add(Me.GridFilterOptions)
        Me.LayoutControl1.Controls.Add(Me.txtPKey)
        Me.LayoutControl1.Controls.Add(Me.chkUserPercentage)
        Me.LayoutControl1.Controls.Add(Me.chkShowShownInGenerateListOnly)
        Me.LayoutControl1.Controls.Add(Me.cboCategory)
        Me.LayoutControl1.Controls.Add(Me.txtFormula)
        Me.LayoutControl1.Controls.Add(Me.cboDefaultChartView)
        Me.LayoutControl1.Controls.Add(Me.txtFleetFieldName)
        Me.LayoutControl1.Controls.Add(Me.txtPrinFieldName)
        Me.LayoutControl1.Controls.Add(Me.txtAgentFieldName)
        Me.LayoutControl1.Controls.Add(Me.txtFooterNote)
        Me.LayoutControl1.Controls.Add(Me.isMultiSelection)
        Me.LayoutControl1.Controls.Add(Me.isNeedDateCoverage)
        Me.LayoutControl1.Controls.Add(Me.txtStoredProcedureName)
        Me.LayoutControl1.Controls.Add(Me.chkShowInGenerateList)
        Me.LayoutControl1.Controls.Add(Me.txtSubTitle)
        Me.LayoutControl1.Controls.Add(Me.cboTimePeriod)
        Me.LayoutControl1.Controls.Add(Me.cboSelectionListing)
        Me.LayoutControl1.Controls.Add(Me.txtAxisYLabel)
        Me.LayoutControl1.Controls.Add(Me.txtAxisXLabel)
        Me.LayoutControl1.Controls.Add(Me.cmdFormulaRemove)
        Me.LayoutControl1.Controls.Add(Me.cmdFormulaChange)
        Me.LayoutControl1.Controls.Add(Me.imgFormula)
        Me.LayoutControl1.Controls.Add(Me.txtTarget)
        Me.LayoutControl1.Controls.Add(Me.txtMinReq)
        Me.LayoutControl1.Controls.Add(Me.txtDescription)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.Label1)
        Me.LayoutControl1.Controls.Add(Me.cmdAddReportGroup)
        Me.LayoutControl1.Controls.Add(Me.cmdMoveDownFilterOption)
        Me.LayoutControl1.Controls.Add(Me.cmdMoveUpFilterOption)
        Me.LayoutControl1.Controls.Add(Me.cmdDeleteFilterOption)
        Me.LayoutControl1.Controls.Add(Me.cmdDelete)
        Me.LayoutControl1.Controls.Add(Me.cmdEditCancel)
        Me.LayoutControl1.Controls.Add(Me.cmdAddSave)
        Me.LayoutControl1.Controls.Add(Me.GridFilterOptions_Addl)
        Me.LayoutControl1.Controls.Add(Me.txtNbr)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.cboKPITypeSelected)
        Me.LayoutControl1.Controls.Add(Me.GridKPI)
        Me.LayoutControl1.Controls.Add(Me.cboKPIType)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1281, 374, 471, 508)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1361, 723)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkCanChangeFKeyPeriod
        '
        Me.chkCanChangeFKeyPeriod.Location = New System.Drawing.Point(569, 302)
        Me.chkCanChangeFKeyPeriod.Name = "chkCanChangeFKeyPeriod"
        Me.chkCanChangeFKeyPeriod.Properties.Caption = "Can Change Time Period"
        Me.chkCanChangeFKeyPeriod.Size = New System.Drawing.Size(735, 20)
        Me.chkCanChangeFKeyPeriod.StyleController = Me.LayoutControl1
        Me.chkCanChangeFKeyPeriod.TabIndex = 83
        '
        'chkCanChangeSelectionListing
        '
        Me.chkCanChangeSelectionListing.Location = New System.Drawing.Point(569, 278)
        Me.chkCanChangeSelectionListing.Name = "chkCanChangeSelectionListing"
        Me.chkCanChangeSelectionListing.Properties.Caption = "Can Change Selection Listing"
        Me.chkCanChangeSelectionListing.Size = New System.Drawing.Size(735, 20)
        Me.chkCanChangeSelectionListing.StyleController = Me.LayoutControl1
        Me.chkCanChangeSelectionListing.TabIndex = 82
        '
        'chkShowCrewInSelectionListing
        '
        Me.chkShowCrewInSelectionListing.Location = New System.Drawing.Point(568, 368)
        Me.chkShowCrewInSelectionListing.Name = "chkShowCrewInSelectionListing"
        Me.chkShowCrewInSelectionListing.Properties.Caption = "Show Crew In SelectionListing"
        Me.chkShowCrewInSelectionListing.Size = New System.Drawing.Size(291, 20)
        Me.chkShowCrewInSelectionListing.StyleController = Me.LayoutControl1
        Me.chkShowCrewInSelectionListing.TabIndex = 81
        '
        'chkGroupGrid
        '
        Me.chkGroupGrid.Location = New System.Drawing.Point(24, -3)
        Me.chkGroupGrid.Name = "chkGroupGrid"
        Me.chkGroupGrid.Properties.Caption = "Group List by Category"
        Me.chkGroupGrid.Size = New System.Drawing.Size(350, 20)
        Me.chkGroupGrid.StyleController = Me.LayoutControl1
        Me.chkGroupGrid.TabIndex = 80
        '
        'cboGenerateScript
        '
        Me.cboGenerateScript.Location = New System.Drawing.Point(1181, -94)
        Me.cboGenerateScript.Name = "cboGenerateScript"
        Me.cboGenerateScript.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)})
        Me.cboGenerateScript.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboGenerateScript.Properties.DisplayMember = "Name"
        Me.cboGenerateScript.Properties.NullText = ""
        Me.cboGenerateScript.Properties.ShowFooter = False
        Me.cboGenerateScript.Properties.ShowHeader = False
        Me.cboGenerateScript.Properties.ValueMember = "PKey"
        Me.cboGenerateScript.Size = New System.Drawing.Size(147, 22)
        Me.cboGenerateScript.StyleController = Me.LayoutControl1
        Me.cboGenerateScript.TabIndex = 79
        '
        'GridFilterOptions
        '
        Me.GridFilterOptions.Location = New System.Drawing.Point(403, 190)
        Me.GridFilterOptions.MainView = Me.GridFilterOptionsView
        Me.GridFilterOptions.Name = "GridFilterOptions"
        Me.GridFilterOptions.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repFilterOption, Me.repApplyToReportSource, Me.repRowSourceHasUserDataFilter})
        Me.GridFilterOptions.Size = New System.Drawing.Size(917, 513)
        Me.GridFilterOptions.TabIndex = 78
        Me.GridFilterOptions.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridFilterOptionsView})
        '
        'GridFilterOptionsView
        '
        Me.GridFilterOptionsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GridFilterOptionsView.GridControl = Me.GridFilterOptions
        Me.GridFilterOptionsView.Name = "GridFilterOptionsView"
        Me.GridFilterOptionsView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Edited"
        Me.GridColumn1.FieldName = "Edited"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "RowNumber"
        Me.GridColumn2.FieldName = "rn"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "PKey"
        Me.GridColumn3.FieldName = "PKey"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Sort Code"
        Me.GridColumn4.FieldName = "SortCode"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Caption"
        Me.GridColumn5.FieldName = "Caption"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Filter Option Type"
        Me.GridColumn6.ColumnEdit = Me.repFilterOption
        Me.GridColumn6.FieldName = "FKeyFilterOption"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 106
        '
        'repFilterOption
        '
        Me.repFilterOption.AutoHeight = False
        Me.repFilterOption.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFilterOption.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ObjectID", 100, "ObjectID"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", 300, "Description")})
        Me.repFilterOption.DisplayMember = "ObjectID"
        Me.repFilterOption.Name = "repFilterOption"
        Me.repFilterOption.NullText = ""
        Me.repFilterOption.PopupWidth = 500
        Me.repFilterOption.ShowHeader = False
        Me.repFilterOption.ValueMember = "ObjectID"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Report Key Filter Field"
        Me.GridColumn7.FieldName = "ReportKeyFilterField"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 7
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Operator"
        Me.GridColumn8.FieldName = "Operator"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 8
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ComboBox Custom Row Source"
        Me.GridColumn9.FieldName = "ComboBoxCustomRowSource"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Key Field (Custom)"
        Me.GridColumn10.FieldName = "CustomRowSourceKeyField"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Display Field (Custom)"
        Me.GridColumn11.FieldName = "CustomRowSourceDisplayField"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Apply Filter To Report DataSource"
        Me.GridColumn12.ColumnEdit = Me.repApplyToReportSource
        Me.GridColumn12.FieldName = "ApplyToReportSource"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 6
        Me.GridColumn12.Width = 99
        '
        'repApplyToReportSource
        '
        Me.repApplyToReportSource.AutoHeight = False
        Me.repApplyToReportSource.Name = "repApplyToReportSource"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Row Source Has User DataFilter"
        Me.GridColumn13.ColumnEdit = Me.repRowSourceHasUserDataFilter
        Me.GridColumn13.FieldName = "isRowSourceHasUserDataFilter"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 5
        Me.GridColumn13.Width = 107
        '
        'repRowSourceHasUserDataFilter
        '
        Me.repRowSourceHasUserDataFilter.AutoHeight = False
        Me.repRowSourceHasUserDataFilter.Name = "repRowSourceHasUserDataFilter"
        '
        'txtPKey
        '
        Me.txtPKey.Location = New System.Drawing.Point(548, -32)
        Me.txtPKey.Name = "txtPKey"
        Me.txtPKey.Size = New System.Drawing.Size(311, 22)
        Me.txtPKey.StyleController = Me.LayoutControl1
        Me.txtPKey.TabIndex = 77
        '
        'chkUserPercentage
        '
        Me.chkUserPercentage.Location = New System.Drawing.Point(863, 412)
        Me.chkUserPercentage.Name = "chkUserPercentage"
        Me.chkUserPercentage.Properties.Caption = "Display Percentage (for Pie Chart View)"
        Me.chkUserPercentage.Size = New System.Drawing.Size(437, 20)
        Me.chkUserPercentage.StyleController = Me.LayoutControl1
        Me.chkUserPercentage.TabIndex = 76
        '
        'chkShowShownInGenerateListOnly
        '
        Me.chkShowShownInGenerateListOnly.Location = New System.Drawing.Point(24, -27)
        Me.chkShowShownInGenerateListOnly.Name = "chkShowShownInGenerateListOnly"
        Me.chkShowShownInGenerateListOnly.Properties.Caption = "Show Only Shown In Generate List"
        Me.chkShowShownInGenerateListOnly.Size = New System.Drawing.Size(350, 20)
        Me.chkShowShownInGenerateListOnly.StyleController = Me.LayoutControl1
        Me.chkShowShownInGenerateListOnly.TabIndex = 75
        '
        'cboCategory
        '
        Me.cboCategory.Location = New System.Drawing.Point(1008, 20)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCategory.Properties.NullText = ""
        Me.cboCategory.Size = New System.Drawing.Size(274, 22)
        Me.cboCategory.StyleController = Me.LayoutControl1
        Me.cboCategory.TabIndex = 74
        '
        'txtFormula
        '
        Me.txtFormula.Location = New System.Drawing.Point(564, 533)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Size = New System.Drawing.Size(655, 22)
        Me.txtFormula.StyleController = Me.LayoutControl1
        Me.txtFormula.TabIndex = 73
        '
        'cboDefaultChartView
        '
        Me.cboDefaultChartView.Location = New System.Drawing.Point(568, 412)
        Me.cboDefaultChartView.Name = "cboDefaultChartView"
        Me.cboDefaultChartView.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDefaultChartView.Properties.NullText = ""
        Me.cboDefaultChartView.Size = New System.Drawing.Size(291, 22)
        Me.cboDefaultChartView.StyleController = Me.LayoutControl1
        Me.cboDefaultChartView.TabIndex = 72
        '
        'txtFleetFieldName
        '
        Me.txtFleetFieldName.Location = New System.Drawing.Point(1175, 655)
        Me.txtFleetFieldName.Name = "txtFleetFieldName"
        Me.txtFleetFieldName.Size = New System.Drawing.Size(129, 22)
        Me.txtFleetFieldName.StyleController = Me.LayoutControl1
        Me.txtFleetFieldName.TabIndex = 71
        '
        'txtPrinFieldName
        '
        Me.txtPrinFieldName.Location = New System.Drawing.Point(864, 655)
        Me.txtPrinFieldName.Name = "txtPrinFieldName"
        Me.txtPrinFieldName.Size = New System.Drawing.Size(162, 22)
        Me.txtPrinFieldName.StyleController = Me.LayoutControl1
        Me.txtPrinFieldName.TabIndex = 70
        '
        'txtAgentFieldName
        '
        Me.txtAgentFieldName.Location = New System.Drawing.Point(564, 655)
        Me.txtAgentFieldName.Name = "txtAgentFieldName"
        Me.txtAgentFieldName.Size = New System.Drawing.Size(151, 22)
        Me.txtAgentFieldName.StyleController = Me.LayoutControl1
        Me.txtAgentFieldName.TabIndex = 69
        '
        'txtFooterNote
        '
        Me.txtFooterNote.Location = New System.Drawing.Point(548, 123)
        Me.txtFooterNote.Name = "txtFooterNote"
        Me.txtFooterNote.Size = New System.Drawing.Size(772, 22)
        Me.txtFooterNote.StyleController = Me.LayoutControl1
        Me.txtFooterNote.TabIndex = 68
        '
        'isMultiSelection
        '
        Me.isMultiSelection.Location = New System.Drawing.Point(863, 342)
        Me.isMultiSelection.Name = "isMultiSelection"
        Me.isMultiSelection.Properties.Caption = "Multi Selection"
        Me.isMultiSelection.Size = New System.Drawing.Size(441, 20)
        Me.isMultiSelection.StyleController = Me.LayoutControl1
        Me.isMultiSelection.TabIndex = 67
        '
        'isNeedDateCoverage
        '
        Me.isNeedDateCoverage.Location = New System.Drawing.Point(419, 228)
        Me.isNeedDateCoverage.Name = "isNeedDateCoverage"
        Me.isNeedDateCoverage.Properties.Caption = "Need Date Coverage"
        Me.isNeedDateCoverage.Size = New System.Drawing.Size(885, 20)
        Me.isNeedDateCoverage.StyleController = Me.LayoutControl1
        Me.isNeedDateCoverage.TabIndex = 65
        '
        'txtStoredProcedureName
        '
        Me.txtStoredProcedureName.Location = New System.Drawing.Point(559, 596)
        Me.txtStoredProcedureName.Name = "txtStoredProcedureName"
        Me.txtStoredProcedureName.Size = New System.Drawing.Size(750, 22)
        Me.txtStoredProcedureName.StyleController = Me.LayoutControl1
        Me.txtStoredProcedureName.TabIndex = 64
        '
        'chkShowInGenerateList
        '
        Me.chkShowInGenerateList.Location = New System.Drawing.Point(403, -56)
        Me.chkShowInGenerateList.Name = "chkShowInGenerateList"
        Me.chkShowInGenerateList.Properties.Caption = "Show In Generate List"
        Me.chkShowInGenerateList.Size = New System.Drawing.Size(917, 20)
        Me.chkShowInGenerateList.StyleController = Me.LayoutControl1
        Me.chkShowInGenerateList.TabIndex = 63
        '
        'txtSubTitle
        '
        Me.txtSubTitle.Location = New System.Drawing.Point(548, 97)
        Me.txtSubTitle.Name = "txtSubTitle"
        Me.txtSubTitle.Size = New System.Drawing.Size(772, 22)
        Me.txtSubTitle.StyleController = Me.LayoutControl1
        Me.txtSubTitle.TabIndex = 62
        '
        'cboTimePeriod
        '
        Me.cboTimePeriod.Location = New System.Drawing.Point(564, 252)
        Me.cboTimePeriod.Name = "cboTimePeriod"
        Me.cboTimePeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboTimePeriod.Properties.NullText = "Choose one if KPI is specific for that period."
        Me.cboTimePeriod.Size = New System.Drawing.Size(740, 22)
        Me.cboTimePeriod.StyleController = Me.LayoutControl1
        Me.cboTimePeriod.TabIndex = 61
        '
        'cboSelectionListing
        '
        Me.cboSelectionListing.Location = New System.Drawing.Point(564, 342)
        Me.cboSelectionListing.Name = "cboSelectionListing"
        Me.cboSelectionListing.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboSelectionListing.Properties.NullText = "Choose one if KPI is specific for that listing."
        Me.cboSelectionListing.Size = New System.Drawing.Size(295, 22)
        Me.cboSelectionListing.StyleController = Me.LayoutControl1
        Me.cboSelectionListing.TabIndex = 60
        '
        'txtAxisYLabel
        '
        Me.txtAxisYLabel.Location = New System.Drawing.Point(1008, 559)
        Me.txtAxisYLabel.Name = "txtAxisYLabel"
        Me.txtAxisYLabel.Size = New System.Drawing.Size(296, 22)
        Me.txtAxisYLabel.StyleController = Me.LayoutControl1
        Me.txtAxisYLabel.TabIndex = 59
        '
        'txtAxisXLabel
        '
        Me.txtAxisXLabel.Location = New System.Drawing.Point(564, 559)
        Me.txtAxisXLabel.Name = "txtAxisXLabel"
        Me.txtAxisXLabel.Size = New System.Drawing.Size(295, 22)
        Me.txtAxisXLabel.StyleController = Me.LayoutControl1
        Me.txtAxisXLabel.TabIndex = 58
        '
        'cmdFormulaRemove
        '
        Me.cmdFormulaRemove.Location = New System.Drawing.Point(1223, 521)
        Me.cmdFormulaRemove.Name = "cmdFormulaRemove"
        Me.cmdFormulaRemove.Size = New System.Drawing.Size(81, 34)
        Me.cmdFormulaRemove.TabIndex = 57
        Me.cmdFormulaRemove.Text = "Remove"
        Me.cmdFormulaRemove.UseVisualStyleBackColor = True
        '
        'cmdFormulaChange
        '
        Me.cmdFormulaChange.Location = New System.Drawing.Point(1223, 484)
        Me.cmdFormulaChange.Name = "cmdFormulaChange"
        Me.cmdFormulaChange.Size = New System.Drawing.Size(81, 33)
        Me.cmdFormulaChange.TabIndex = 56
        Me.cmdFormulaChange.Text = "Change"
        Me.cmdFormulaChange.UseVisualStyleBackColor = True
        '
        'imgFormula
        '
        Me.imgFormula.Location = New System.Drawing.Point(564, 484)
        Me.imgFormula.Name = "imgFormula"
        Me.imgFormula.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray
        Me.imgFormula.Size = New System.Drawing.Size(655, 45)
        Me.imgFormula.StyleController = Me.LayoutControl1
        Me.imgFormula.TabIndex = 55
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(1008, 458)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(296, 22)
        Me.txtTarget.StyleController = Me.LayoutControl1
        Me.txtTarget.TabIndex = 54
        '
        'txtMinReq
        '
        Me.txtMinReq.Location = New System.Drawing.Point(564, 458)
        Me.txtMinReq.Name = "txtMinReq"
        Me.txtMinReq.Size = New System.Drawing.Size(295, 22)
        Me.txtMinReq.StyleController = Me.LayoutControl1
        Me.txtMinReq.TabIndex = 53
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(548, 75)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(772, 18)
        Me.txtDescription.StyleController = Me.LayoutControl1
        Me.txtDescription.TabIndex = 52
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(1008, 49)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Size = New System.Drawing.Size(312, 22)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(426, -94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(647, 26)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "This configuration is available only in debug mode and if logged in as 'Administr" & _
    "ator'"
        '
        'cmdAddReportGroup
        '
        Me.cmdAddReportGroup.Location = New System.Drawing.Point(1286, 20)
        Me.cmdAddReportGroup.Name = "cmdAddReportGroup"
        Me.cmdAddReportGroup.Size = New System.Drawing.Size(34, 25)
        Me.cmdAddReportGroup.TabIndex = 45
        Me.cmdAddReportGroup.Text = "+"
        Me.cmdAddReportGroup.UseVisualStyleBackColor = True
        '
        'cmdMoveDownFilterOption
        '
        Me.cmdMoveDownFilterOption.Location = New System.Drawing.Point(406, 347)
        Me.cmdMoveDownFilterOption.Name = "cmdMoveDownFilterOption"
        Me.cmdMoveDownFilterOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdMoveDownFilterOption.TabIndex = 44
        Me.cmdMoveDownFilterOption.Text = "Move Down"
        Me.cmdMoveDownFilterOption.UseVisualStyleBackColor = True
        '
        'cmdMoveUpFilterOption
        '
        Me.cmdMoveUpFilterOption.Location = New System.Drawing.Point(406, 286)
        Me.cmdMoveUpFilterOption.Name = "cmdMoveUpFilterOption"
        Me.cmdMoveUpFilterOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdMoveUpFilterOption.TabIndex = 43
        Me.cmdMoveUpFilterOption.Text = "Move Up"
        Me.cmdMoveUpFilterOption.UseVisualStyleBackColor = True
        '
        'cmdDeleteFilterOption
        '
        Me.cmdDeleteFilterOption.Location = New System.Drawing.Point(406, 225)
        Me.cmdDeleteFilterOption.Name = "cmdDeleteFilterOption"
        Me.cmdDeleteFilterOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdDeleteFilterOption.TabIndex = 42
        Me.cmdDeleteFilterOption.Text = "Delete"
        Me.cmdDeleteFilterOption.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(243, -94)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(113, 26)
        Me.cmdDelete.TabIndex = 37
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdEditCancel
        '
        Me.cmdEditCancel.Location = New System.Drawing.Point(129, -94)
        Me.cmdEditCancel.Name = "cmdEditCancel"
        Me.cmdEditCancel.Size = New System.Drawing.Size(110, 26)
        Me.cmdEditCancel.TabIndex = 36
        Me.cmdEditCancel.Text = "Edit"
        Me.cmdEditCancel.UseVisualStyleBackColor = True
        '
        'cmdAddSave
        '
        Me.cmdAddSave.Location = New System.Drawing.Point(12, -94)
        Me.cmdAddSave.Name = "cmdAddSave"
        Me.cmdAddSave.Size = New System.Drawing.Size(113, 26)
        Me.cmdAddSave.TabIndex = 35
        Me.cmdAddSave.Text = "Add"
        Me.cmdAddSave.UseVisualStyleBackColor = True
        '
        'GridFilterOptions_Addl
        '
        Me.GridFilterOptions_Addl.Location = New System.Drawing.Point(464, 193)
        Me.GridFilterOptions_Addl.MainView = Me.GridFilterOptionsView_Addl
        Me.GridFilterOptions_Addl.Name = "GridFilterOptions_Addl"
        Me.GridFilterOptions_Addl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repFilterOption_Addl, Me.repApplyToReportSource_Addl, Me.repRowSourceHasUserDataFilter_Addl})
        Me.GridFilterOptions_Addl.Size = New System.Drawing.Size(853, 507)
        Me.GridFilterOptions_Addl.TabIndex = 34
        Me.GridFilterOptions_Addl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridFilterOptionsView_Addl})
        '
        'GridFilterOptionsView_Addl
        '
        Me.GridFilterOptionsView_Addl.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFilterEdited, Me.colRowNumber, Me.colFilterPKey, Me.colFilterSortCode, Me.colFilterCaption, Me.colFilterFKeyFilterOption, Me.colFilter, Me.colFilterOperator, Me.colFilterComboBoxCustomRowSource, Me.colFilterCustomRowSourceKeyField, Me.colFilterCustomRowSourceDisplayField, Me.colFilterIsApplyToReportSource, Me.colFilterRowSourceHasUserDataFilter})
        Me.GridFilterOptionsView_Addl.GridControl = Me.GridFilterOptions_Addl
        Me.GridFilterOptionsView_Addl.Name = "GridFilterOptionsView_Addl"
        Me.GridFilterOptionsView_Addl.OptionsView.ShowGroupPanel = False
        '
        'colFilterEdited
        '
        Me.colFilterEdited.Caption = "Edited"
        Me.colFilterEdited.FieldName = "Edited"
        Me.colFilterEdited.Name = "colFilterEdited"
        '
        'colRowNumber
        '
        Me.colRowNumber.Caption = "RowNumber"
        Me.colRowNumber.FieldName = "rn"
        Me.colRowNumber.Name = "colRowNumber"
        '
        'colFilterPKey
        '
        Me.colFilterPKey.Caption = "PKey"
        Me.colFilterPKey.FieldName = "PKey"
        Me.colFilterPKey.Name = "colFilterPKey"
        '
        'colFilterSortCode
        '
        Me.colFilterSortCode.Caption = "Sort Code"
        Me.colFilterSortCode.FieldName = "SortCode"
        Me.colFilterSortCode.Name = "colFilterSortCode"
        '
        'colFilterCaption
        '
        Me.colFilterCaption.Caption = "Caption"
        Me.colFilterCaption.FieldName = "Caption"
        Me.colFilterCaption.Name = "colFilterCaption"
        Me.colFilterCaption.Visible = True
        Me.colFilterCaption.VisibleIndex = 0
        '
        'colFilterFKeyFilterOption
        '
        Me.colFilterFKeyFilterOption.Caption = "Filter Option Type"
        Me.colFilterFKeyFilterOption.ColumnEdit = Me.repFilterOption_Addl
        Me.colFilterFKeyFilterOption.FieldName = "FKeyFilterOption"
        Me.colFilterFKeyFilterOption.Name = "colFilterFKeyFilterOption"
        Me.colFilterFKeyFilterOption.Visible = True
        Me.colFilterFKeyFilterOption.VisibleIndex = 1
        Me.colFilterFKeyFilterOption.Width = 106
        '
        'repFilterOption_Addl
        '
        Me.repFilterOption_Addl.AutoHeight = False
        Me.repFilterOption_Addl.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFilterOption_Addl.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ObjectID", 100, "ObjectID"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", 300, "Description")})
        Me.repFilterOption_Addl.DisplayMember = "ObjectID"
        Me.repFilterOption_Addl.Name = "repFilterOption_Addl"
        Me.repFilterOption_Addl.NullText = ""
        Me.repFilterOption_Addl.PopupWidth = 500
        Me.repFilterOption_Addl.ShowHeader = False
        Me.repFilterOption_Addl.ValueMember = "ObjectID"
        '
        'colFilter
        '
        Me.colFilter.Caption = "Report Key Filter Field"
        Me.colFilter.FieldName = "ReportKeyFilterField"
        Me.colFilter.Name = "colFilter"
        Me.colFilter.Visible = True
        Me.colFilter.VisibleIndex = 7
        '
        'colFilterOperator
        '
        Me.colFilterOperator.Caption = "Operator"
        Me.colFilterOperator.FieldName = "Operator"
        Me.colFilterOperator.Name = "colFilterOperator"
        Me.colFilterOperator.Visible = True
        Me.colFilterOperator.VisibleIndex = 8
        '
        'colFilterComboBoxCustomRowSource
        '
        Me.colFilterComboBoxCustomRowSource.Caption = "ComboBox Custom Row Source"
        Me.colFilterComboBoxCustomRowSource.FieldName = "ComboBoxCustomRowSource"
        Me.colFilterComboBoxCustomRowSource.Name = "colFilterComboBoxCustomRowSource"
        Me.colFilterComboBoxCustomRowSource.Visible = True
        Me.colFilterComboBoxCustomRowSource.VisibleIndex = 2
        '
        'colFilterCustomRowSourceKeyField
        '
        Me.colFilterCustomRowSourceKeyField.Caption = "Key Field (Custom)"
        Me.colFilterCustomRowSourceKeyField.FieldName = "CustomRowSourceKeyField"
        Me.colFilterCustomRowSourceKeyField.Name = "colFilterCustomRowSourceKeyField"
        Me.colFilterCustomRowSourceKeyField.Visible = True
        Me.colFilterCustomRowSourceKeyField.VisibleIndex = 3
        '
        'colFilterCustomRowSourceDisplayField
        '
        Me.colFilterCustomRowSourceDisplayField.Caption = "Display Field (Custom)"
        Me.colFilterCustomRowSourceDisplayField.FieldName = "CustomRowSourceDisplayField"
        Me.colFilterCustomRowSourceDisplayField.Name = "colFilterCustomRowSourceDisplayField"
        Me.colFilterCustomRowSourceDisplayField.Visible = True
        Me.colFilterCustomRowSourceDisplayField.VisibleIndex = 4
        '
        'colFilterIsApplyToReportSource
        '
        Me.colFilterIsApplyToReportSource.Caption = "Apply Filter To Report DataSource"
        Me.colFilterIsApplyToReportSource.ColumnEdit = Me.repApplyToReportSource_Addl
        Me.colFilterIsApplyToReportSource.FieldName = "ApplyToReportSource"
        Me.colFilterIsApplyToReportSource.Name = "colFilterIsApplyToReportSource"
        Me.colFilterIsApplyToReportSource.Visible = True
        Me.colFilterIsApplyToReportSource.VisibleIndex = 6
        Me.colFilterIsApplyToReportSource.Width = 99
        '
        'repApplyToReportSource_Addl
        '
        Me.repApplyToReportSource_Addl.AutoHeight = False
        Me.repApplyToReportSource_Addl.Name = "repApplyToReportSource_Addl"
        '
        'colFilterRowSourceHasUserDataFilter
        '
        Me.colFilterRowSourceHasUserDataFilter.Caption = "Row Source Has User DataFilter"
        Me.colFilterRowSourceHasUserDataFilter.ColumnEdit = Me.repRowSourceHasUserDataFilter_Addl
        Me.colFilterRowSourceHasUserDataFilter.FieldName = "isRowSourceHasUserDataFilter"
        Me.colFilterRowSourceHasUserDataFilter.Name = "colFilterRowSourceHasUserDataFilter"
        Me.colFilterRowSourceHasUserDataFilter.Visible = True
        Me.colFilterRowSourceHasUserDataFilter.VisibleIndex = 5
        Me.colFilterRowSourceHasUserDataFilter.Width = 107
        '
        'repRowSourceHasUserDataFilter_Addl
        '
        Me.repRowSourceHasUserDataFilter_Addl.AutoHeight = False
        Me.repRowSourceHasUserDataFilter_Addl.Name = "repRowSourceHasUserDataFilter_Addl"
        '
        'txtNbr
        '
        Me.txtNbr.Location = New System.Drawing.Point(548, 49)
        Me.txtNbr.Name = "txtNbr"
        Me.txtNbr.Size = New System.Drawing.Size(311, 22)
        Me.txtNbr.StyleController = Me.LayoutControl1
        Me.txtNbr.TabIndex = 13
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(548, -6)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(772, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 12
        '
        'cboKPITypeSelected
        '
        Me.cboKPITypeSelected.Location = New System.Drawing.Point(548, 20)
        Me.cboKPITypeSelected.Name = "cboKPITypeSelected"
        Me.cboKPITypeSelected.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboKPITypeSelected.Properties.NullText = ""
        Me.cboKPITypeSelected.Size = New System.Drawing.Size(311, 22)
        Me.cboKPITypeSelected.StyleController = Me.LayoutControl1
        Me.cboKPITypeSelected.TabIndex = 8
        '
        'GridKPI
        '
        Me.GridKPI.Location = New System.Drawing.Point(12, 49)
        Me.GridKPI.MainView = Me.GridKPIView
        Me.GridKPI.Name = "GridKPI"
        Me.GridKPI.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repMemoEdit})
        Me.GridKPI.Size = New System.Drawing.Size(374, 662)
        Me.GridKPI.TabIndex = 5
        Me.GridKPI.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridKPIView})
        '
        'GridKPIView
        '
        Me.GridKPIView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.colCategory, Me.colName})
        Me.GridKPIView.GridControl = Me.GridKPI
        Me.GridKPIView.Name = "GridKPIView"
        Me.GridKPIView.OptionsFind.AlwaysVisible = True
        Me.GridKPIView.OptionsView.RowAutoHeight = True
        Me.GridKPIView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridKPIView.OptionsView.ShowGroupPanel = False
        '
        'colPKey
        '
        Me.colPKey.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 6.5!)
        Me.colPKey.AppearanceCell.Options.UseFont = True
        Me.colPKey.AppearanceCell.Options.UseTextOptions = True
        Me.colPKey.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.colPKey.Caption = "KPI Code"
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        Me.colPKey.OptionsColumn.AllowEdit = False
        Me.colPKey.OptionsColumn.AllowMove = False
        Me.colPKey.OptionsColumn.AllowShowHide = False
        Me.colPKey.OptionsColumn.ReadOnly = True
        Me.colPKey.Visible = True
        Me.colPKey.VisibleIndex = 0
        Me.colPKey.Width = 90
        '
        'colCategory
        '
        Me.colCategory.Caption = "Category"
        Me.colCategory.ColumnEdit = Me.repMemoEdit
        Me.colCategory.FieldName = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.OptionsColumn.AllowEdit = False
        Me.colCategory.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCategory.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.colCategory.OptionsColumn.AllowMove = False
        Me.colCategory.OptionsColumn.AllowShowHide = False
        Me.colCategory.OptionsColumn.AllowSize = False
        Me.colCategory.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[True]
        Me.colCategory.OptionsColumn.ReadOnly = True
        Me.colCategory.Visible = True
        Me.colCategory.VisibleIndex = 1
        Me.colCategory.Width = 108
        '
        'repMemoEdit
        '
        Me.repMemoEdit.Name = "repMemoEdit"
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.ColumnEdit = Me.repMemoEdit
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.OptionsColumn.AllowEdit = False
        Me.colName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colName.OptionsColumn.AllowMove = False
        Me.colName.OptionsColumn.AllowShowHide = False
        Me.colName.OptionsColumn.AllowSize = False
        Me.colName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colName.OptionsColumn.ReadOnly = True
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 2
        Me.colName.Width = 158
        '
        'cboKPIType
        '
        Me.cboKPIType.Location = New System.Drawing.Point(169, -56)
        Me.cboKPIType.Name = "cboKPIType"
        Me.cboKPIType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboKPIType.Properties.NullText = "Select KPI Type..."
        Me.cboKPIType.Size = New System.Drawing.Size(205, 22)
        Me.cboKPIType.StyleController = Me.LayoutControl1
        Me.cboKPIType.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlGroup_Main, Me.SplitterItem1, Me.tabDetails, Me.LayoutControlItem_Add, Me.LayoutControlItem_Edit, Me.EmptySpaceItem3, Me.LayoutControlItem_Delete, Me.LayoutControlItem36, Me.LayoutControlGroup3, Me.LayoutControlItem33})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, -106)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1340, 829)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem2.Control = Me.GridKPI
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(136, 43)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(378, 686)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "KPI List"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(142, 17)
        '
        'LayoutControlGroup_Main
        '
        Me.LayoutControlGroup_Main.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9, Me.LayoutControlItem5, Me.LayoutControlItem31, Me.LayoutControlItem3, Me.LayoutControlItem37, Me.LayoutControlItem4, Me.LayoutControlItem20, Me.LayoutControlItem21, Me.LayoutControlItem24, Me.LayoutControlItem12, Me.EmptySpaceItem4, Me.LayoutControlItem15})
        Me.LayoutControlGroup_Main.Location = New System.Drawing.Point(383, 30)
        Me.LayoutControlGroup_Main.Name = "LayoutControlGroup_Main"
        Me.LayoutControlGroup_Main.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Main.Size = New System.Drawing.Size(937, 221)
        Me.LayoutControlGroup_Main.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem9.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem9.Control = Me.txtName
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(921, 26)
        Me.LayoutControlItem9.Text = "*Name:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(142, 17)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem5.Control = Me.cboKPITypeSelected
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 76)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(460, 29)
        Me.LayoutControlItem5.Text = "*KPI Type:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(142, 17)
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Control = Me.cmdAddReportGroup
        Me.LayoutControlItem31.Location = New System.Drawing.Point(883, 76)
        Me.LayoutControlItem31.MaxSize = New System.Drawing.Size(38, 29)
        Me.LayoutControlItem31.MinSize = New System.Drawing.Size(38, 29)
        Me.LayoutControlItem31.Name = "LayoutControlItem31"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(38, 29)
        Me.LayoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem31.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtNbr
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 105)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(460, 26)
        Me.LayoutControlItem3.Text = "No.:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem37
        '
        Me.LayoutControlItem37.Control = Me.txtSortCode
        Me.LayoutControlItem37.Location = New System.Drawing.Point(460, 105)
        Me.LayoutControlItem37.Name = "LayoutControlItem37"
        Me.LayoutControlItem37.Size = New System.Drawing.Size(461, 26)
        Me.LayoutControlItem37.Text = "Sort Code:"
        Me.LayoutControlItem37.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtDescription
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 131)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(921, 22)
        Me.LayoutControlItem4.Text = "Description:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.txtSubTitle
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 153)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(921, 26)
        Me.LayoutControlItem20.Text = "Sub Title:"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.chkShowInGenerateList
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(921, 24)
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.txtFooterNote
        Me.LayoutControlItem24.Location = New System.Drawing.Point(0, 179)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(921, 26)
        Me.LayoutControlItem24.Text = "Footer Note:"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cboCategory
        Me.LayoutControlItem12.Location = New System.Drawing.Point(460, 76)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(423, 29)
        Me.LayoutControlItem12.Text = "*Category:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(142, 16)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(460, 24)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(461, 26)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem15.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem15.Control = Me.txtPKey
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(460, 26)
        Me.LayoutControlItem15.Text = "*KPI Code:"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(142, 17)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(378, 30)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 779)
        '
        'tabDetails
        '
        Me.tabDetails.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabDetails.Location = New System.Drawing.Point(383, 251)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.tabDetails.SelectedTabPage = Me.LayoutControlGroup_KPIDetails
        Me.tabDetails.SelectedTabPageIndex = 0
        Me.tabDetails.Size = New System.Drawing.Size(937, 558)
        Me.tabDetails.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_KPIDetails, Me.LayoutControlGroup_DefaultFilterOptions, Me.LayoutControlGroup_AdditionalFilterOptions})
        '
        'LayoutControlGroup_KPIDetails
        '
        Me.LayoutControlGroup_KPIDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_Details})
        Me.LayoutControlGroup_KPIDetails.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_KPIDetails.Name = "LayoutControlGroup_KPIDetails"
        Me.LayoutControlGroup_KPIDetails.Size = New System.Drawing.Size(921, 517)
        Me.LayoutControlGroup_KPIDetails.Text = "KPI Details"
        '
        'LayoutControlGroup_Details
        '
        Me.LayoutControlGroup_Details.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlGroup_MainDetail, Me.LayoutControlGroup_Computation, Me.LayoutControlGroup_DataFilter, Me.LayoutControlGroup_StoredProcedureName, Me.LayoutControlGroup_DateCoverage, Me.LayoutControlGroup2})
        Me.LayoutControlGroup_Details.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Details.Name = "LayoutControlGroup_Details"
        Me.LayoutControlGroup_Details.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Details.Size = New System.Drawing.Size(921, 517)
        Me.LayoutControlGroup_Details.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 491)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(905, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_MainDetail
        '
        Me.LayoutControlGroup_MainDetail.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem18, Me.LayoutControlItem23, Me.LayoutControlItem_ShowCrewInSelectionListing, Me.EmptySpaceItem2})
        Me.LayoutControlGroup_MainDetail.Location = New System.Drawing.Point(0, 136)
        Me.LayoutControlGroup_MainDetail.Name = "LayoutControlGroup_MainDetail"
        Me.LayoutControlGroup_MainDetail.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_MainDetail.Size = New System.Drawing.Size(905, 66)
        Me.LayoutControlGroup_MainDetail.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.cboSelectionListing
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(444, 26)
        Me.LayoutControlItem18.Text = "Selection Listing:"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.cboTimePeriod
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(889, 26)
        Me.LayoutControlItem19.Text = "Time Period:"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.isMultiSelection
        Me.LayoutControlItem23.Location = New System.Drawing.Point(444, 0)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(445, 50)
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem23.TextVisible = False
        '
        'LayoutControlItem38
        '
        Me.LayoutControlItem38.Control = Me.cboDefaultChartView
        Me.LayoutControlItem38.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem38.Name = "LayoutControlItem38"
        Me.LayoutControlItem38.Size = New System.Drawing.Size(440, 26)
        Me.LayoutControlItem38.Text = "Default ChartView:"
        Me.LayoutControlItem38.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.chkUserPercentage
        Me.LayoutControlItem14.Location = New System.Drawing.Point(440, 0)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(441, 26)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem_ShowCrewInSelectionListing
        '
        Me.LayoutControlItem_ShowCrewInSelectionListing.Control = Me.chkShowCrewInSelectionListing
        Me.LayoutControlItem_ShowCrewInSelectionListing.Location = New System.Drawing.Point(149, 26)
        Me.LayoutControlItem_ShowCrewInSelectionListing.Name = "LayoutControlItem_ShowCrewInSelectionListing"
        Me.LayoutControlItem_ShowCrewInSelectionListing.Size = New System.Drawing.Size(295, 24)
        Me.LayoutControlItem_ShowCrewInSelectionListing.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_ShowCrewInSelectionListing.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(149, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem35
        '
        Me.LayoutControlItem35.Control = Me.chkCanChangeSelectionListing
        Me.LayoutControlItem35.Location = New System.Drawing.Point(150, 50)
        Me.LayoutControlItem35.Name = "LayoutControlItem35"
        Me.LayoutControlItem35.Size = New System.Drawing.Size(739, 24)
        Me.LayoutControlItem35.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem35.TextVisible = False
        '
        'LayoutControlItem39
        '
        Me.LayoutControlItem39.Control = Me.chkCanChangeFKeyPeriod
        Me.LayoutControlItem39.Location = New System.Drawing.Point(150, 74)
        Me.LayoutControlItem39.Name = "LayoutControlItem39"
        Me.LayoutControlItem39.Size = New System.Drawing.Size(739, 24)
        Me.LayoutControlItem39.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem39.TextVisible = False
        '
        'LayoutControlGroup_Computation
        '
        Me.LayoutControlGroup_Computation.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem_FormulaImage, Me.LayoutControlItem_Change, Me.LayoutControlItem_Remove, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.LayoutControlItem_FormulaString})
        Me.LayoutControlGroup_Computation.Location = New System.Drawing.Point(0, 252)
        Me.LayoutControlGroup_Computation.Name = "LayoutControlGroup_Computation"
        Me.LayoutControlGroup_Computation.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Computation.Size = New System.Drawing.Size(905, 143)
        Me.LayoutControlGroup_Computation.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtMinReq
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(444, 26)
        Me.LayoutControlItem6.Text = "Minimum Requirement:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtTarget
        Me.LayoutControlItem8.Location = New System.Drawing.Point(444, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(445, 26)
        Me.LayoutControlItem8.Text = "Target:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem_FormulaImage
        '
        Me.LayoutControlItem_FormulaImage.Control = Me.imgFormula
        Me.LayoutControlItem_FormulaImage.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem_FormulaImage.Name = "LayoutControlItem_FormulaImage"
        Me.LayoutControlItem_FormulaImage.Size = New System.Drawing.Size(804, 49)
        Me.LayoutControlItem_FormulaImage.Text = "Formula (Image):"
        Me.LayoutControlItem_FormulaImage.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem_Change
        '
        Me.LayoutControlItem_Change.Control = Me.cmdFormulaChange
        Me.LayoutControlItem_Change.Location = New System.Drawing.Point(804, 26)
        Me.LayoutControlItem_Change.MaxSize = New System.Drawing.Size(85, 37)
        Me.LayoutControlItem_Change.MinSize = New System.Drawing.Size(85, 37)
        Me.LayoutControlItem_Change.Name = "LayoutControlItem_Change"
        Me.LayoutControlItem_Change.Size = New System.Drawing.Size(85, 37)
        Me.LayoutControlItem_Change.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Change.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Change.TextVisible = False
        '
        'LayoutControlItem_Remove
        '
        Me.LayoutControlItem_Remove.Control = Me.cmdFormulaRemove
        Me.LayoutControlItem_Remove.Location = New System.Drawing.Point(804, 63)
        Me.LayoutControlItem_Remove.MaxSize = New System.Drawing.Size(85, 38)
        Me.LayoutControlItem_Remove.MinSize = New System.Drawing.Size(85, 38)
        Me.LayoutControlItem_Remove.Name = "LayoutControlItem_Remove"
        Me.LayoutControlItem_Remove.Size = New System.Drawing.Size(85, 38)
        Me.LayoutControlItem_Remove.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Remove.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Remove.TextVisible = False
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.txtAxisXLabel
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 101)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(444, 26)
        Me.LayoutControlItem16.Text = "Axis X Label:"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.txtAxisYLabel
        Me.LayoutControlItem17.Location = New System.Drawing.Point(444, 101)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(445, 26)
        Me.LayoutControlItem17.Text = "Axis Y Label:"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem_FormulaString
        '
        Me.LayoutControlItem_FormulaString.Control = Me.txtFormula
        Me.LayoutControlItem_FormulaString.Location = New System.Drawing.Point(0, 75)
        Me.LayoutControlItem_FormulaString.Name = "LayoutControlItem_FormulaString"
        Me.LayoutControlItem_FormulaString.Size = New System.Drawing.Size(804, 26)
        Me.LayoutControlItem_FormulaString.Text = "Formula (Text):"
        Me.LayoutControlItem_FormulaString.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlGroup_DateCoverage
        '
        Me.LayoutControlGroup_DateCoverage.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11, Me.LayoutControlItem19, Me.LayoutControlItem35, Me.LayoutControlItem39, Me.EmptySpaceItem5})
        Me.LayoutControlGroup_DateCoverage.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_DateCoverage.Name = "LayoutControlGroup_DateCoverage"
        Me.LayoutControlGroup_DateCoverage.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_DateCoverage.Size = New System.Drawing.Size(905, 136)
        Me.LayoutControlGroup_DateCoverage.Text = "Date Coverage"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.isNeedDateCoverage
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(889, 24)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlGroup_DataFilter
        '
        Me.LayoutControlGroup_DataFilter.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem25, Me.LayoutControlItem26, Me.LayoutControlItem27})
        Me.LayoutControlGroup_DataFilter.Location = New System.Drawing.Point(0, 427)
        Me.LayoutControlGroup_DataFilter.Name = "LayoutControlGroup_DataFilter"
        Me.LayoutControlGroup_DataFilter.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_DataFilter.Size = New System.Drawing.Size(905, 64)
        Me.LayoutControlGroup_DataFilter.Text = "User-Data Filtering (Optional)"
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.txtAgentFieldName
        Me.LayoutControlItem25.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(300, 26)
        Me.LayoutControlItem25.Text = "Agent Field Name:"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.txtPrinFieldName
        Me.LayoutControlItem26.Location = New System.Drawing.Point(300, 0)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(311, 26)
        Me.LayoutControlItem26.Text = "Principal Field Name:"
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.txtFleetFieldName
        Me.LayoutControlItem27.Location = New System.Drawing.Point(611, 0)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(278, 26)
        Me.LayoutControlItem27.Text = "Fleet Field Name:"
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlGroup_StoredProcedureName
        '
        Me.LayoutControlGroup_StoredProcedureName.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10})
        Me.LayoutControlGroup_StoredProcedureName.Location = New System.Drawing.Point(0, 395)
        Me.LayoutControlGroup_StoredProcedureName.Name = "LayoutControlGroup_StoredProcedureName"
        Me.LayoutControlGroup_StoredProcedureName.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_StoredProcedureName.Size = New System.Drawing.Size(905, 32)
        Me.LayoutControlGroup_StoredProcedureName.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtStoredProcedureName
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(899, 26)
        Me.LayoutControlItem10.Text = "Stored Procedure Name:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(142, 16)
        '
        'LayoutControlGroup_DefaultFilterOptions
        '
        Me.LayoutControlGroup_DefaultFilterOptions.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem32})
        Me.LayoutControlGroup_DefaultFilterOptions.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_DefaultFilterOptions.Name = "LayoutControlGroup_DefaultFilterOptions"
        Me.LayoutControlGroup_DefaultFilterOptions.Size = New System.Drawing.Size(921, 517)
        Me.LayoutControlGroup_DefaultFilterOptions.Text = "Default Filter Options"
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.GridFilterOptions
        Me.LayoutControlItem32.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem32.Name = "LayoutControlItem32"
        Me.LayoutControlItem32.Size = New System.Drawing.Size(921, 517)
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem32.TextVisible = False
        '
        'LayoutControlGroup_AdditionalFilterOptions
        '
        Me.LayoutControlGroup_AdditionalFilterOptions.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_FilterOptionGeneric})
        Me.LayoutControlGroup_AdditionalFilterOptions.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_AdditionalFilterOptions.Name = "LayoutControlGroup_AdditionalFilterOptions"
        Me.LayoutControlGroup_AdditionalFilterOptions.Size = New System.Drawing.Size(921, 517)
        Me.LayoutControlGroup_AdditionalFilterOptions.Text = "Additional Filter Options"
        Me.LayoutControlGroup_AdditionalFilterOptions.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlGroup_FilterOptionGeneric
        '
        Me.LayoutControlGroup_FilterOptionGeneric.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem6, Me.LayoutControlItem7, Me.LayoutControlItem28, Me.LayoutControlItem29, Me.LayoutControlItem30, Me.EmptySpaceItem7})
        Me.LayoutControlGroup_FilterOptionGeneric.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_FilterOptionGeneric.Name = "LayoutControlGroup_FilterOptionGeneric"
        Me.LayoutControlGroup_FilterOptionGeneric.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_FilterOptionGeneric.Size = New System.Drawing.Size(921, 517)
        Me.LayoutControlGroup_FilterOptionGeneric.TextVisible = False
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem6.MaxSize = New System.Drawing.Size(58, 32)
        Me.EmptySpaceItem6.MinSize = New System.Drawing.Size(58, 32)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(58, 32)
        Me.EmptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.GridFilterOptions_Addl
        Me.LayoutControlItem7.Location = New System.Drawing.Point(58, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(857, 511)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.cmdDeleteFilterOption
        Me.LayoutControlItem28.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem28.MaxSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem28.MinSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem28.Text = "Button1"
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem28.TextVisible = False
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.cmdMoveUpFilterOption
        Me.LayoutControlItem29.Location = New System.Drawing.Point(0, 93)
        Me.LayoutControlItem29.MaxSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem29.MinSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem29.TextVisible = False
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.Control = Me.cmdMoveDownFilterOption
        Me.LayoutControlItem30.Location = New System.Drawing.Point(0, 154)
        Me.LayoutControlItem30.MaxSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem30.MinSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem30.Name = "LayoutControlItem30"
        Me.LayoutControlItem30.Size = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem30.TextVisible = False
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(0, 215)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(58, 296)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem_Add
        '
        Me.LayoutControlItem_Add.Control = Me.cmdAddSave
        Me.LayoutControlItem_Add.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem_Add.MaxSize = New System.Drawing.Size(0, 30)
        Me.LayoutControlItem_Add.MinSize = New System.Drawing.Size(27, 30)
        Me.LayoutControlItem_Add.Name = "LayoutControlItem_Add"
        Me.LayoutControlItem_Add.Size = New System.Drawing.Size(117, 30)
        Me.LayoutControlItem_Add.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Add.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Add.TextVisible = False
        '
        'LayoutControlItem_Edit
        '
        Me.LayoutControlItem_Edit.Control = Me.cmdEditCancel
        Me.LayoutControlItem_Edit.Location = New System.Drawing.Point(117, 0)
        Me.LayoutControlItem_Edit.MaxSize = New System.Drawing.Size(0, 30)
        Me.LayoutControlItem_Edit.MinSize = New System.Drawing.Size(27, 30)
        Me.LayoutControlItem_Edit.Name = "LayoutControlItem_Edit"
        Me.LayoutControlItem_Edit.Size = New System.Drawing.Size(114, 30)
        Me.LayoutControlItem_Edit.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Edit.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Edit.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(348, 0)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(66, 30)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(66, 30)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(66, 30)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem_Delete
        '
        Me.LayoutControlItem_Delete.Control = Me.cmdDelete
        Me.LayoutControlItem_Delete.Location = New System.Drawing.Point(231, 0)
        Me.LayoutControlItem_Delete.MaxSize = New System.Drawing.Size(0, 30)
        Me.LayoutControlItem_Delete.MinSize = New System.Drawing.Size(27, 30)
        Me.LayoutControlItem_Delete.Name = "LayoutControlItem_Delete"
        Me.LayoutControlItem_Delete.Size = New System.Drawing.Size(117, 30)
        Me.LayoutControlItem_Delete.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Delete.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Delete.TextVisible = False
        '
        'LayoutControlItem36
        '
        Me.LayoutControlItem36.Control = Me.Label1
        Me.LayoutControlItem36.Location = New System.Drawing.Point(414, 0)
        Me.LayoutControlItem36.Name = "LayoutControlItem36"
        Me.LayoutControlItem36.Size = New System.Drawing.Size(651, 30)
        Me.LayoutControlItem36.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem36.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem13, Me.LayoutControlItem34})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(9, 9, 5, 5)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(378, 93)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem1.Control = Me.cboKPIType
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(354, 29)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(354, 29)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(354, 29)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "KPI Type"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(142, 17)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.chkShowShownInGenerateListOnly
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 29)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(354, 24)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.Control = Me.chkGroupGrid
        Me.LayoutControlItem34.Location = New System.Drawing.Point(0, 53)
        Me.LayoutControlItem34.Name = "LayoutControlItem34"
        Me.LayoutControlItem34.Size = New System.Drawing.Size(354, 24)
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem34.TextVisible = False
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.cboGenerateScript
        Me.LayoutControlItem33.Location = New System.Drawing.Point(1065, 0)
        Me.LayoutControlItem33.Name = "LayoutControlItem33"
        Me.LayoutControlItem33.Size = New System.Drawing.Size(255, 30)
        Me.LayoutControlItem33.Text = "Generate Script:"
        Me.LayoutControlItem33.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem33.TextToControlDistance = 4
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1365, 751)
        Me.header.TabIndex = 1
        Me.header.Text = "KPI Configuration"
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 50)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(150, 48)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem14, Me.LayoutControlItem38})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 202)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(905, 50)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'KPIConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "KPIConfig"
        Me.Size = New System.Drawing.Size(1365, 751)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkCanChangeFKeyPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCanChangeSelectionListing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowCrewInSelectionListing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGroupGrid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboGenerateScript.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFilterOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFilterOptionsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFilterOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repApplyToReportSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRowSourceHasUserDataFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPKey.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUserPercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowShownInGenerateListOnly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormula.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDefaultChartView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFleetFieldName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrinFieldName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAgentFieldName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFooterNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.isMultiSelection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.isNeedDateCoverage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStoredProcedureName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowInGenerateList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTimePeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSelectionListing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAxisYLabel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAxisXLabel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFormula.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinReq.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFilterOptions_Addl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFilterOptionsView_Addl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFilterOption_Addl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repApplyToReportSource_Addl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRowSourceHasUserDataFilter_Addl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNbr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKPITypeSelected.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridKPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridKPIView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboKPIType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_KPIDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Details, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_MainDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_ShowCrewInSelectionListing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Computation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_FormulaImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Change, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Remove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_FormulaString, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_DateCoverage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_DataFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_StoredProcedureName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_DefaultFilterOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_AdditionalFilterOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_FilterOptionGeneric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Add, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Delete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtNbr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboKPITypeSelected As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridKPI As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridKPIView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboKPIType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_Main As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridFilterOptions_Addl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridFilterOptionsView_Addl As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents tabDetails As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup_KPIDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Details As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_AdditionalFilterOptions As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEditCancel As System.Windows.Forms.Button
    Friend WithEvents cmdAddSave As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem_Add As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_Edit As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem_Delete As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colFilterSortCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterFKeyFilterOption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterCaption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterOperator As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterComboBoxCustomRowSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterIsApplyToReportSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterRowSourceHasUserDataFilter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repFilterOption_Addl As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repApplyToReportSource_Addl As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents repRowSourceHasUserDataFilter_Addl As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cmdMoveDownFilterOption As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUpFilterOption As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteFilterOption As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem30 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colRowNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdAddReportGroup As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem31 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colFilterCustomRowSourceKeyField As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterCustomRowSourceDisplayField As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup_FilterOptionGeneric As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem36 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents repMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents txtTarget As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMinReq As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem37 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkShowInGenerateList As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtSubTitle As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboTimePeriod As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboSelectionListing As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtAxisYLabel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAxisXLabel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdFormulaRemove As System.Windows.Forms.Button
    Friend WithEvents cmdFormulaChange As System.Windows.Forms.Button
    Friend WithEvents imgFormula As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup_MainDetail As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_Computation As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem_FormulaImage As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_Change As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_Remove As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFleetFieldName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPrinFieldName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAgentFieldName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFooterNote As DevExpress.XtraEditors.TextEdit
    Friend WithEvents isMultiSelection As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDateCoverageType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents isNeedDateCoverage As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtStoredProcedureName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_DateCoverage As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_DataFilter As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboDefaultChartView As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem38 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFormula As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem_FormulaString As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboCategory As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkShowShownInGenerateListOnly As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkUserPercentage As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPKey As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridFilterOptions As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridFilterOptionsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repFilterOption As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repApplyToReportSource As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repRowSourceHasUserDataFilter As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents LayoutControlGroup_DefaultFilterOptions As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem32 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_StoredProcedureName As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboGenerateScript As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem33 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkGroupGrid As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem34 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents chkShowCrewInSelectionListing As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem_ShowCrewInSelectionListing As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents chkCanChangeFKeyPeriod As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCanChangeSelectionListing As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem35 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem39 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup

End Class
