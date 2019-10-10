<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportConfig))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboGenScript = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFeature = New DevExpress.XtraEditors.TextEdit()
        Me.cmdGenerateFID = New System.Windows.Forms.Button()
        Me.cboFeature = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFID = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReportFilterOptionClass = New DevExpress.XtraEditors.TextEdit()
        Me.txtReportFilterOptionDLL = New DevExpress.XtraEditors.TextEdit()
        Me.optFilterOption_UseGeneric = New DevExpress.XtraEditors.CheckEdit()
        Me.optFilterOption_UseSpecific = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdAddReportGroup = New System.Windows.Forms.Button()
        Me.cmdMoveDownFilterOption = New System.Windows.Forms.Button()
        Me.cmdMoveUpFilterOption = New System.Windows.Forms.Button()
        Me.cmdDeleteFilterOption = New System.Windows.Forms.Button()
        Me.cmdMoveDownSortOption = New System.Windows.Forms.Button()
        Me.cmdMoveUpSortOption = New System.Windows.Forms.Button()
        Me.cmdDeleteSortOption = New System.Windows.Forms.Button()
        Me.GridSortOptions = New DevExpress.XtraGrid.GridControl()
        Me.GridSortOptionsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSortFieldName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSortCaption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSortDefaultSortOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSortOrder = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSortIsMovable = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSortIsMovable = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdEditCancel = New System.Windows.Forms.Button()
        Me.cmdAddSave = New System.Windows.Forms.Button()
        Me.GridFilterOptions = New DevExpress.XtraGrid.GridControl()
        Me.GridFilterOptionsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFilterEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRowNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterSortCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterCaption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterFKeyFilterOption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFilterOption = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colFilter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterOperator = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterComboBoxCustomRowSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterCustomRowSourceKeyField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterCustomRowSourceDisplayField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFilterIsApplyToReportSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repApplyToReportSource = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colFilterRowSourceHasUserDataFilter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRowSourceHasUserDataFilter = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colFilterDefaultValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtDateRangeToField = New DevExpress.XtraEditors.TextEdit()
        Me.txtDateRangeFromField = New DevExpress.XtraEditors.TextEdit()
        Me.chkShowInPopup = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUseExportButton = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUsePreviewButton = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUseTemplateList = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUseSelectionList = New DevExpress.XtraEditors.CheckEdit()
        Me.txtRemarks = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortedBy = New DevExpress.XtraEditors.TextEdit()
        Me.txtReportClass = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtKeyFilterField = New DevExpress.XtraEditors.TextEdit()
        Me.txtSelectionDisplayField = New DevExpress.XtraEditors.TextEdit()
        Me.txtSelectionSortField = New DevExpress.XtraEditors.TextEdit()
        Me.txtSelectionKeyField = New DevExpress.XtraEditors.TextEdit()
        Me.txtSelectionSource = New DevExpress.XtraEditors.TextEdit()
        Me.cboSelectionSource = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboSelectionSourceType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtGroupedBy = New DevExpress.XtraEditors.TextEdit()
        Me.txtDLL = New DevExpress.XtraEditors.TextEdit()
        Me.txtObjectID = New DevExpress.XtraEditors.TextEdit()
        Me.txtCaption = New DevExpress.XtraEditors.TextEdit()
        Me.cboReportGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.GridReports = New DevExpress.XtraGrid.GridControl()
        Me.GridReportsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colObjectID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReportGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboReportGroupList = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Main = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.tabDetails = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup_FilterOptions = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_FilterOptionSpecific = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem35 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_FilterOptionGeneric = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_SelectionSource = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem_SelectionSourceType = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_SelectionKeyField = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem_SelectionSource = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Optionals = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_DateRangeFields = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_SortOptions = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Feature = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem37 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_FeatureSetup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem38 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem39 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem40 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_Add = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_Edit = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem_Delete = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem36 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem41 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboGenScript.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFeature.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFeature.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportFilterOptionClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportFilterOptionDLL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optFilterOption_UseGeneric.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optFilterOption_UseSpecific.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSortOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSortOptionsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSortOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSortIsMovable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFilterOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridFilterOptionsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFilterOption, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repApplyToReportSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRowSourceHasUserDataFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateRangeToField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateRangeFromField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowInPopup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseExportButton.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUsePreviewButton.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseTemplateList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseSelectionList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKeyFilterField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSelectionDisplayField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSelectionSortField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSelectionKeyField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSelectionSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSelectionSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSelectionSourceType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroupedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDLL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObjectID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaption.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboReportGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridReports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridReportsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboReportGroupList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_FilterOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_FilterOptionSpecific, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_FilterOptionGeneric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_SelectionSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_SelectionSourceType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_SelectionKeyField, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_SelectionSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Optionals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_DateRangeFields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_SortOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Feature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_FeatureSetup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Add, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Delete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
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
        Me.LayoutControl1.Controls.Add(Me.cboGenScript)
        Me.LayoutControl1.Controls.Add(Me.txtFeature)
        Me.LayoutControl1.Controls.Add(Me.cmdGenerateFID)
        Me.LayoutControl1.Controls.Add(Me.cboFeature)
        Me.LayoutControl1.Controls.Add(Me.txtFID)
        Me.LayoutControl1.Controls.Add(Me.Label1)
        Me.LayoutControl1.Controls.Add(Me.txtReportFilterOptionClass)
        Me.LayoutControl1.Controls.Add(Me.txtReportFilterOptionDLL)
        Me.LayoutControl1.Controls.Add(Me.optFilterOption_UseGeneric)
        Me.LayoutControl1.Controls.Add(Me.optFilterOption_UseSpecific)
        Me.LayoutControl1.Controls.Add(Me.cmdAddReportGroup)
        Me.LayoutControl1.Controls.Add(Me.cmdMoveDownFilterOption)
        Me.LayoutControl1.Controls.Add(Me.cmdMoveUpFilterOption)
        Me.LayoutControl1.Controls.Add(Me.cmdDeleteFilterOption)
        Me.LayoutControl1.Controls.Add(Me.cmdMoveDownSortOption)
        Me.LayoutControl1.Controls.Add(Me.cmdMoveUpSortOption)
        Me.LayoutControl1.Controls.Add(Me.cmdDeleteSortOption)
        Me.LayoutControl1.Controls.Add(Me.GridSortOptions)
        Me.LayoutControl1.Controls.Add(Me.cmdDelete)
        Me.LayoutControl1.Controls.Add(Me.cmdEditCancel)
        Me.LayoutControl1.Controls.Add(Me.cmdAddSave)
        Me.LayoutControl1.Controls.Add(Me.GridFilterOptions)
        Me.LayoutControl1.Controls.Add(Me.txtDateRangeToField)
        Me.LayoutControl1.Controls.Add(Me.txtDateRangeFromField)
        Me.LayoutControl1.Controls.Add(Me.chkShowInPopup)
        Me.LayoutControl1.Controls.Add(Me.chkUseExportButton)
        Me.LayoutControl1.Controls.Add(Me.chkUsePreviewButton)
        Me.LayoutControl1.Controls.Add(Me.chkUseTemplateList)
        Me.LayoutControl1.Controls.Add(Me.chkUseSelectionList)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.txtSortedBy)
        Me.LayoutControl1.Controls.Add(Me.txtReportClass)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.txtKeyFilterField)
        Me.LayoutControl1.Controls.Add(Me.txtSelectionDisplayField)
        Me.LayoutControl1.Controls.Add(Me.txtSelectionSortField)
        Me.LayoutControl1.Controls.Add(Me.txtSelectionKeyField)
        Me.LayoutControl1.Controls.Add(Me.txtSelectionSource)
        Me.LayoutControl1.Controls.Add(Me.cboSelectionSource)
        Me.LayoutControl1.Controls.Add(Me.cboSelectionSourceType)
        Me.LayoutControl1.Controls.Add(Me.txtGroupedBy)
        Me.LayoutControl1.Controls.Add(Me.txtDLL)
        Me.LayoutControl1.Controls.Add(Me.txtObjectID)
        Me.LayoutControl1.Controls.Add(Me.txtCaption)
        Me.LayoutControl1.Controls.Add(Me.cboReportGroup)
        Me.LayoutControl1.Controls.Add(Me.GridReports)
        Me.LayoutControl1.Controls.Add(Me.cboReportGroupList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(138, 480, 799, 572)
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
        'cboGenScript
        '
        Me.cboGenScript.Location = New System.Drawing.Point(1181, 12)
        Me.cboGenScript.Name = "cboGenScript"
        Me.cboGenScript.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboGenScript.Size = New System.Drawing.Size(168, 22)
        Me.cboGenScript.StyleController = Me.LayoutControl1
        Me.cboGenScript.TabIndex = 55
        '
        'txtFeature
        '
        Me.txtFeature.Location = New System.Drawing.Point(539, 224)
        Me.txtFeature.Name = "txtFeature"
        Me.txtFeature.Properties.ReadOnly = True
        Me.txtFeature.Size = New System.Drawing.Size(802, 22)
        Me.txtFeature.StyleController = Me.LayoutControl1
        Me.txtFeature.TabIndex = 54
        '
        'cmdGenerateFID
        '
        Me.cmdGenerateFID.Location = New System.Drawing.Point(874, 310)
        Me.cmdGenerateFID.Name = "cmdGenerateFID"
        Me.cmdGenerateFID.Size = New System.Drawing.Size(225, 22)
        Me.cmdGenerateFID.TabIndex = 53
        Me.cmdGenerateFID.Text = "Assign to Feature"
        Me.cmdGenerateFID.UseVisualStyleBackColor = True
        '
        'cboFeature
        '
        Me.cboFeature.Location = New System.Drawing.Point(551, 310)
        Me.cboFeature.Name = "cboFeature"
        Me.cboFeature.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFeature.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Feature", "Feature"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboFeature.Properties.DisplayMember = "Feature"
        Me.cboFeature.Properties.NullText = ""
        Me.cboFeature.Properties.ValueMember = "Value"
        Me.cboFeature.Size = New System.Drawing.Size(319, 22)
        Me.cboFeature.StyleController = Me.LayoutControl1
        Me.cboFeature.TabIndex = 52
        '
        'txtFID
        '
        Me.txtFID.Location = New System.Drawing.Point(539, 250)
        Me.txtFID.Name = "txtFID"
        Me.txtFID.Properties.ReadOnly = True
        Me.txtFID.Size = New System.Drawing.Size(802, 22)
        Me.txtFID.StyleController = Me.LayoutControl1
        Me.txtFID.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(432, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(609, 26)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "This configuration is available only in debug mode and if logged in as 'Administr" & _
    "ator' or 'Spectral'"
        '
        'txtReportFilterOptionClass
        '
        Me.txtReportFilterOptionClass.Location = New System.Drawing.Point(1036, 251)
        Me.txtReportFilterOptionClass.Name = "txtReportFilterOptionClass"
        Me.txtReportFilterOptionClass.Size = New System.Drawing.Size(302, 22)
        Me.txtReportFilterOptionClass.StyleController = Me.LayoutControl1
        Me.txtReportFilterOptionClass.TabIndex = 49
        '
        'txtReportFilterOptionDLL
        '
        Me.txtReportFilterOptionDLL.Location = New System.Drawing.Point(590, 251)
        Me.txtReportFilterOptionDLL.Name = "txtReportFilterOptionDLL"
        Me.txtReportFilterOptionDLL.Size = New System.Drawing.Size(306, 22)
        Me.txtReportFilterOptionDLL.StyleController = Me.LayoutControl1
        Me.txtReportFilterOptionDLL.TabIndex = 48
        '
        'optFilterOption_UseGeneric
        '
        Me.optFilterOption_UseGeneric.Location = New System.Drawing.Point(411, 280)
        Me.optFilterOption_UseGeneric.Name = "optFilterOption_UseGeneric"
        Me.optFilterOption_UseGeneric.Properties.Caption = "Use the generic automated gridcontrol"
        Me.optFilterOption_UseGeneric.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.optFilterOption_UseGeneric.Properties.RadioGroupIndex = 1
        Me.optFilterOption_UseGeneric.Size = New System.Drawing.Size(930, 20)
        Me.optFilterOption_UseGeneric.StyleController = Me.LayoutControl1
        Me.optFilterOption_UseGeneric.TabIndex = 47
        Me.optFilterOption_UseGeneric.TabStop = False
        '
        'optFilterOption_UseSpecific
        '
        Me.optFilterOption_UseSpecific.Location = New System.Drawing.Point(411, 224)
        Me.optFilterOption_UseSpecific.Name = "optFilterOption_UseSpecific"
        Me.optFilterOption_UseSpecific.Properties.Caption = "Use a specific vb class from an existing project"
        Me.optFilterOption_UseSpecific.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.optFilterOption_UseSpecific.Properties.RadioGroupIndex = 1
        Me.optFilterOption_UseSpecific.Size = New System.Drawing.Size(930, 20)
        Me.optFilterOption_UseSpecific.StyleController = Me.LayoutControl1
        Me.optFilterOption_UseSpecific.TabIndex = 46
        Me.optFilterOption_UseSpecific.TabStop = False
        '
        'cmdAddReportGroup
        '
        Me.cmdAddReportGroup.Location = New System.Drawing.Point(1307, 50)
        Me.cmdAddReportGroup.Name = "cmdAddReportGroup"
        Me.cmdAddReportGroup.Size = New System.Drawing.Size(34, 25)
        Me.cmdAddReportGroup.TabIndex = 45
        Me.cmdAddReportGroup.Text = "+"
        Me.cmdAddReportGroup.UseVisualStyleBackColor = True
        '
        'cmdMoveDownFilterOption
        '
        Me.cmdMoveDownFilterOption.Location = New System.Drawing.Point(406, 461)
        Me.cmdMoveDownFilterOption.Name = "cmdMoveDownFilterOption"
        Me.cmdMoveDownFilterOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdMoveDownFilterOption.TabIndex = 44
        Me.cmdMoveDownFilterOption.Text = "Move Down"
        Me.cmdMoveDownFilterOption.UseVisualStyleBackColor = True
        '
        'cmdMoveUpFilterOption
        '
        Me.cmdMoveUpFilterOption.Location = New System.Drawing.Point(406, 400)
        Me.cmdMoveUpFilterOption.Name = "cmdMoveUpFilterOption"
        Me.cmdMoveUpFilterOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdMoveUpFilterOption.TabIndex = 43
        Me.cmdMoveUpFilterOption.Text = "Move Up"
        Me.cmdMoveUpFilterOption.UseVisualStyleBackColor = True
        '
        'cmdDeleteFilterOption
        '
        Me.cmdDeleteFilterOption.Location = New System.Drawing.Point(406, 339)
        Me.cmdDeleteFilterOption.Name = "cmdDeleteFilterOption"
        Me.cmdDeleteFilterOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdDeleteFilterOption.TabIndex = 42
        Me.cmdDeleteFilterOption.Text = "Delete"
        Me.cmdDeleteFilterOption.UseVisualStyleBackColor = True
        '
        'cmdMoveDownSortOption
        '
        Me.cmdMoveDownSortOption.Location = New System.Drawing.Point(403, 378)
        Me.cmdMoveDownSortOption.Name = "cmdMoveDownSortOption"
        Me.cmdMoveDownSortOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdMoveDownSortOption.TabIndex = 41
        Me.cmdMoveDownSortOption.Text = "Move Down"
        Me.cmdMoveDownSortOption.UseVisualStyleBackColor = True
        '
        'cmdMoveUpSortOption
        '
        Me.cmdMoveUpSortOption.Location = New System.Drawing.Point(403, 317)
        Me.cmdMoveUpSortOption.Name = "cmdMoveUpSortOption"
        Me.cmdMoveUpSortOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdMoveUpSortOption.TabIndex = 40
        Me.cmdMoveUpSortOption.Text = "Move Up"
        Me.cmdMoveUpSortOption.UseVisualStyleBackColor = True
        '
        'cmdDeleteSortOption
        '
        Me.cmdDeleteSortOption.Location = New System.Drawing.Point(403, 256)
        Me.cmdDeleteSortOption.Name = "cmdDeleteSortOption"
        Me.cmdDeleteSortOption.Size = New System.Drawing.Size(54, 57)
        Me.cmdDeleteSortOption.TabIndex = 39
        Me.cmdDeleteSortOption.Text = "Delete"
        Me.cmdDeleteSortOption.UseVisualStyleBackColor = True
        '
        'GridSortOptions
        '
        Me.GridSortOptions.Location = New System.Drawing.Point(461, 224)
        Me.GridSortOptions.MainView = Me.GridSortOptionsView
        Me.GridSortOptions.Name = "GridSortOptions"
        Me.GridSortOptions.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repSortOrder, Me.repSortIsMovable})
        Me.GridSortOptions.Size = New System.Drawing.Size(880, 479)
        Me.GridSortOptions.TabIndex = 38
        Me.GridSortOptions.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridSortOptionsView})
        '
        'GridSortOptionsView
        '
        Me.GridSortOptionsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSortFieldName, Me.colSortCaption, Me.colSortDefaultSortOrder, Me.colSortIsMovable})
        Me.GridSortOptionsView.GridControl = Me.GridSortOptions
        Me.GridSortOptionsView.Name = "GridSortOptionsView"
        Me.GridSortOptionsView.OptionsView.ShowGroupPanel = False
        '
        'colSortFieldName
        '
        Me.colSortFieldName.Caption = "FieldName"
        Me.colSortFieldName.FieldName = "FieldName"
        Me.colSortFieldName.Name = "colSortFieldName"
        Me.colSortFieldName.Visible = True
        Me.colSortFieldName.VisibleIndex = 0
        '
        'colSortCaption
        '
        Me.colSortCaption.Caption = "Caption"
        Me.colSortCaption.FieldName = "Caption"
        Me.colSortCaption.Name = "colSortCaption"
        Me.colSortCaption.Visible = True
        Me.colSortCaption.VisibleIndex = 1
        '
        'colSortDefaultSortOrder
        '
        Me.colSortDefaultSortOrder.Caption = "Default Sort Order"
        Me.colSortDefaultSortOrder.ColumnEdit = Me.repSortOrder
        Me.colSortDefaultSortOrder.FieldName = "SortOrder"
        Me.colSortDefaultSortOrder.Name = "colSortDefaultSortOrder"
        Me.colSortDefaultSortOrder.Visible = True
        Me.colSortDefaultSortOrder.VisibleIndex = 2
        '
        'repSortOrder
        '
        Me.repSortOrder.AutoHeight = False
        Me.repSortOrder.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repSortOrder.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repSortOrder.DisplayMember = "Name"
        Me.repSortOrder.Name = "repSortOrder"
        Me.repSortOrder.NullText = "Select..."
        Me.repSortOrder.NullValuePrompt = "A default sort order must be selected"
        Me.repSortOrder.ShowFooter = False
        Me.repSortOrder.ShowHeader = False
        Me.repSortOrder.ValueMember = "PKey"
        '
        'colSortIsMovable
        '
        Me.colSortIsMovable.Caption = "Is Movable"
        Me.colSortIsMovable.ColumnEdit = Me.repSortIsMovable
        Me.colSortIsMovable.FieldName = "isMovable"
        Me.colSortIsMovable.Name = "colSortIsMovable"
        Me.colSortIsMovable.Visible = True
        Me.colSortIsMovable.VisibleIndex = 3
        '
        'repSortIsMovable
        '
        Me.repSortIsMovable.AutoHeight = False
        Me.repSortIsMovable.Name = "repSortIsMovable"
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(247, 12)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(115, 26)
        Me.cmdDelete.TabIndex = 37
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdEditCancel
        '
        Me.cmdEditCancel.Location = New System.Drawing.Point(131, 12)
        Me.cmdEditCancel.Name = "cmdEditCancel"
        Me.cmdEditCancel.Size = New System.Drawing.Size(112, 26)
        Me.cmdEditCancel.TabIndex = 36
        Me.cmdEditCancel.Text = "Edit"
        Me.cmdEditCancel.UseVisualStyleBackColor = True
        '
        'cmdAddSave
        '
        Me.cmdAddSave.Location = New System.Drawing.Point(12, 12)
        Me.cmdAddSave.Name = "cmdAddSave"
        Me.cmdAddSave.Size = New System.Drawing.Size(115, 26)
        Me.cmdAddSave.TabIndex = 35
        Me.cmdAddSave.Text = "Add"
        Me.cmdAddSave.UseVisualStyleBackColor = True
        '
        'GridFilterOptions
        '
        Me.GridFilterOptions.Location = New System.Drawing.Point(464, 307)
        Me.GridFilterOptions.MainView = Me.GridFilterOptionsView
        Me.GridFilterOptions.Name = "GridFilterOptions"
        Me.GridFilterOptions.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repFilterOption, Me.repApplyToReportSource, Me.repRowSourceHasUserDataFilter})
        Me.GridFilterOptions.Size = New System.Drawing.Size(874, 393)
        Me.GridFilterOptions.TabIndex = 34
        Me.GridFilterOptions.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridFilterOptionsView})
        '
        'GridFilterOptionsView
        '
        Me.GridFilterOptionsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFilterEdited, Me.colRowNumber, Me.colFilterPKey, Me.colFilterSortCode, Me.colFilterCaption, Me.colFilterFKeyFilterOption, Me.colFilter, Me.colFilterOperator, Me.colFilterComboBoxCustomRowSource, Me.colFilterCustomRowSourceKeyField, Me.colFilterCustomRowSourceDisplayField, Me.colFilterIsApplyToReportSource, Me.colFilterRowSourceHasUserDataFilter, Me.colFilterDefaultValue})
        Me.GridFilterOptionsView.GridControl = Me.GridFilterOptions
        Me.GridFilterOptionsView.Name = "GridFilterOptionsView"
        Me.GridFilterOptionsView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridFilterOptionsView.OptionsView.ShowGroupPanel = False
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
        Me.colFilterFKeyFilterOption.ColumnEdit = Me.repFilterOption
        Me.colFilterFKeyFilterOption.FieldName = "FKeyFilterOption"
        Me.colFilterFKeyFilterOption.Name = "colFilterFKeyFilterOption"
        Me.colFilterFKeyFilterOption.Visible = True
        Me.colFilterFKeyFilterOption.VisibleIndex = 1
        Me.colFilterFKeyFilterOption.Width = 106
        '
        'repFilterOption
        '
        Me.repFilterOption.AutoHeight = False
        Me.repFilterOption.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)})
        Me.repFilterOption.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ObjectID", 100, "ObjectID"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", 300, "Description")})
        Me.repFilterOption.DisplayMember = "ObjectID"
        Me.repFilterOption.Name = "repFilterOption"
        Me.repFilterOption.NullText = ""
        Me.repFilterOption.PopupWidth = 500
        Me.repFilterOption.ShowHeader = False
        Me.repFilterOption.ValueMember = "ObjectID"
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
        Me.colFilterIsApplyToReportSource.ColumnEdit = Me.repApplyToReportSource
        Me.colFilterIsApplyToReportSource.FieldName = "ApplyToReportSource"
        Me.colFilterIsApplyToReportSource.Name = "colFilterIsApplyToReportSource"
        Me.colFilterIsApplyToReportSource.Visible = True
        Me.colFilterIsApplyToReportSource.VisibleIndex = 6
        Me.colFilterIsApplyToReportSource.Width = 99
        '
        'repApplyToReportSource
        '
        Me.repApplyToReportSource.AutoHeight = False
        Me.repApplyToReportSource.Name = "repApplyToReportSource"
        '
        'colFilterRowSourceHasUserDataFilter
        '
        Me.colFilterRowSourceHasUserDataFilter.Caption = "Row Source Has User DataFilter"
        Me.colFilterRowSourceHasUserDataFilter.ColumnEdit = Me.repRowSourceHasUserDataFilter
        Me.colFilterRowSourceHasUserDataFilter.FieldName = "isRowSourceHasUserDataFilter"
        Me.colFilterRowSourceHasUserDataFilter.Name = "colFilterRowSourceHasUserDataFilter"
        Me.colFilterRowSourceHasUserDataFilter.Visible = True
        Me.colFilterRowSourceHasUserDataFilter.VisibleIndex = 5
        Me.colFilterRowSourceHasUserDataFilter.Width = 107
        '
        'repRowSourceHasUserDataFilter
        '
        Me.repRowSourceHasUserDataFilter.AutoHeight = False
        Me.repRowSourceHasUserDataFilter.Name = "repRowSourceHasUserDataFilter"
        '
        'colFilterDefaultValue
        '
        Me.colFilterDefaultValue.Caption = "Default Value"
        Me.colFilterDefaultValue.FieldName = "DefaultValue"
        Me.colFilterDefaultValue.Name = "colFilterDefaultValue"
        Me.colFilterDefaultValue.Visible = True
        Me.colFilterDefaultValue.VisibleIndex = 9
        '
        'txtDateRangeToField
        '
        Me.txtDateRangeToField.Location = New System.Drawing.Point(934, 460)
        Me.txtDateRangeToField.Name = "txtDateRangeToField"
        Me.txtDateRangeToField.Size = New System.Drawing.Size(399, 22)
        Me.txtDateRangeToField.StyleController = Me.LayoutControl1
        Me.txtDateRangeToField.TabIndex = 33
        '
        'txtDateRangeFromField
        '
        Me.txtDateRangeFromField.Location = New System.Drawing.Point(547, 460)
        Me.txtDateRangeFromField.Name = "txtDateRangeFromField"
        Me.txtDateRangeFromField.Size = New System.Drawing.Size(247, 22)
        Me.txtDateRangeFromField.StyleController = Me.LayoutControl1
        Me.txtDateRangeFromField.TabIndex = 32
        '
        'chkShowInPopup
        '
        Me.chkShowInPopup.Location = New System.Drawing.Point(875, 397)
        Me.chkShowInPopup.Name = "chkShowInPopup"
        Me.chkShowInPopup.Properties.Caption = "Shown In Print Biodata Form"
        Me.chkShowInPopup.Size = New System.Drawing.Size(458, 20)
        Me.chkShowInPopup.StyleController = Me.LayoutControl1
        Me.chkShowInPopup.TabIndex = 31
        '
        'chkUseExportButton
        '
        Me.chkUseExportButton.Location = New System.Drawing.Point(875, 373)
        Me.chkUseExportButton.Name = "chkUseExportButton"
        Me.chkUseExportButton.Properties.Caption = "Uses Export Button"
        Me.chkUseExportButton.Size = New System.Drawing.Size(458, 20)
        Me.chkUseExportButton.StyleController = Me.LayoutControl1
        Me.chkUseExportButton.TabIndex = 30
        '
        'chkUsePreviewButton
        '
        Me.chkUsePreviewButton.Location = New System.Drawing.Point(411, 373)
        Me.chkUsePreviewButton.Name = "chkUsePreviewButton"
        Me.chkUsePreviewButton.Properties.Caption = "Uses Preview Button"
        Me.chkUsePreviewButton.Size = New System.Drawing.Size(460, 20)
        Me.chkUsePreviewButton.StyleController = Me.LayoutControl1
        Me.chkUsePreviewButton.TabIndex = 29
        '
        'chkUseTemplateList
        '
        Me.chkUseTemplateList.Location = New System.Drawing.Point(411, 397)
        Me.chkUseTemplateList.Name = "chkUseTemplateList"
        Me.chkUseTemplateList.Properties.Caption = "Allow Saving/Loading of Templates"
        Me.chkUseTemplateList.Size = New System.Drawing.Size(460, 20)
        Me.chkUseTemplateList.StyleController = Me.LayoutControl1
        Me.chkUseTemplateList.TabIndex = 28
        '
        'chkUseSelectionList
        '
        Me.chkUseSelectionList.Location = New System.Drawing.Point(411, 224)
        Me.chkUseSelectionList.Name = "chkUseSelectionList"
        Me.chkUseSelectionList.Properties.Caption = "Uses Print Selection List"
        Me.chkUseSelectionList.Size = New System.Drawing.Size(930, 20)
        Me.chkUseSelectionList.StyleController = Me.LayoutControl1
        Me.chkUseSelectionList.TabIndex = 27
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(539, 157)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(802, 22)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 26
        '
        'txtSortedBy
        '
        Me.txtSortedBy.Location = New System.Drawing.Point(1011, 131)
        Me.txtSortedBy.Name = "txtSortedBy"
        Me.txtSortedBy.Size = New System.Drawing.Size(330, 22)
        Me.txtSortedBy.StyleController = Me.LayoutControl1
        Me.txtSortedBy.TabIndex = 25
        '
        'txtReportClass
        '
        Me.txtReportClass.Location = New System.Drawing.Point(539, 131)
        Me.txtReportClass.Name = "txtReportClass"
        Me.txtReportClass.Size = New System.Drawing.Size(332, 22)
        Me.txtReportClass.StyleController = Me.LayoutControl1
        Me.txtReportClass.TabIndex = 24
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(1011, 79)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Size = New System.Drawing.Size(330, 22)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 23
        '
        'txtKeyFilterField
        '
        Me.txtKeyFilterField.Location = New System.Drawing.Point(547, 331)
        Me.txtKeyFilterField.Name = "txtKeyFilterField"
        Me.txtKeyFilterField.Size = New System.Drawing.Size(150, 22)
        Me.txtKeyFilterField.StyleController = Me.LayoutControl1
        Me.txtKeyFilterField.TabIndex = 22
        '
        'txtSelectionDisplayField
        '
        Me.txtSelectionDisplayField.Location = New System.Drawing.Point(837, 305)
        Me.txtSelectionDisplayField.Name = "txtSelectionDisplayField"
        Me.txtSelectionDisplayField.Size = New System.Drawing.Size(191, 22)
        Me.txtSelectionDisplayField.StyleController = Me.LayoutControl1
        Me.txtSelectionDisplayField.TabIndex = 21
        '
        'txtSelectionSortField
        '
        Me.txtSelectionSortField.Location = New System.Drawing.Point(1168, 305)
        Me.txtSelectionSortField.Name = "txtSelectionSortField"
        Me.txtSelectionSortField.Size = New System.Drawing.Size(165, 22)
        Me.txtSelectionSortField.StyleController = Me.LayoutControl1
        Me.txtSelectionSortField.TabIndex = 20
        '
        'txtSelectionKeyField
        '
        Me.txtSelectionKeyField.Location = New System.Drawing.Point(547, 305)
        Me.txtSelectionKeyField.Name = "txtSelectionKeyField"
        Me.txtSelectionKeyField.Size = New System.Drawing.Size(150, 22)
        Me.txtSelectionKeyField.StyleController = Me.LayoutControl1
        Me.txtSelectionKeyField.TabIndex = 19
        '
        'txtSelectionSource
        '
        Me.txtSelectionSource.Location = New System.Drawing.Point(1168, 279)
        Me.txtSelectionSource.Name = "txtSelectionSource"
        Me.txtSelectionSource.Size = New System.Drawing.Size(165, 22)
        Me.txtSelectionSource.StyleController = Me.LayoutControl1
        Me.txtSelectionSource.TabIndex = 18
        '
        'cboSelectionSource
        '
        Me.cboSelectionSource.Location = New System.Drawing.Point(837, 279)
        Me.cboSelectionSource.Name = "cboSelectionSource"
        Me.cboSelectionSource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)})
        Me.cboSelectionSource.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", 150, "Code")})
        Me.cboSelectionSource.Properties.DisplayMember = "Code"
        Me.cboSelectionSource.Properties.NullText = ""
        Me.cboSelectionSource.Properties.ShowFooter = False
        Me.cboSelectionSource.Properties.ShowHeader = False
        Me.cboSelectionSource.Properties.ValueMember = "Code"
        Me.cboSelectionSource.Size = New System.Drawing.Size(191, 22)
        Me.cboSelectionSource.StyleController = Me.LayoutControl1
        Me.cboSelectionSource.TabIndex = 17
        '
        'cboSelectionSourceType
        '
        Me.cboSelectionSourceType.Location = New System.Drawing.Point(547, 279)
        Me.cboSelectionSourceType.Name = "cboSelectionSourceType"
        Me.cboSelectionSourceType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSelectionSourceType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboSelectionSourceType.Properties.DisplayMember = "Name"
        Me.cboSelectionSourceType.Properties.NullText = ""
        Me.cboSelectionSourceType.Properties.ShowFooter = False
        Me.cboSelectionSourceType.Properties.ShowHeader = False
        Me.cboSelectionSourceType.Properties.ValueMember = "PKey"
        Me.cboSelectionSourceType.Size = New System.Drawing.Size(150, 22)
        Me.cboSelectionSourceType.StyleController = Me.LayoutControl1
        Me.cboSelectionSourceType.TabIndex = 16
        '
        'txtGroupedBy
        '
        Me.txtGroupedBy.Location = New System.Drawing.Point(1011, 105)
        Me.txtGroupedBy.Name = "txtGroupedBy"
        Me.txtGroupedBy.Size = New System.Drawing.Size(330, 22)
        Me.txtGroupedBy.StyleController = Me.LayoutControl1
        Me.txtGroupedBy.TabIndex = 15
        '
        'txtDLL
        '
        Me.txtDLL.Location = New System.Drawing.Point(539, 105)
        Me.txtDLL.Name = "txtDLL"
        Me.txtDLL.Size = New System.Drawing.Size(332, 22)
        Me.txtDLL.StyleController = Me.LayoutControl1
        Me.txtDLL.TabIndex = 14
        '
        'txtObjectID
        '
        Me.txtObjectID.Location = New System.Drawing.Point(539, 79)
        Me.txtObjectID.Name = "txtObjectID"
        Me.txtObjectID.Size = New System.Drawing.Size(332, 22)
        Me.txtObjectID.StyleController = Me.LayoutControl1
        Me.txtObjectID.TabIndex = 13
        '
        'txtCaption
        '
        Me.txtCaption.Location = New System.Drawing.Point(539, 50)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(332, 22)
        Me.txtCaption.StyleController = Me.LayoutControl1
        Me.txtCaption.TabIndex = 12
        '
        'cboReportGroup
        '
        Me.cboReportGroup.Location = New System.Drawing.Point(1011, 50)
        Me.cboReportGroup.Name = "cboReportGroup"
        Me.cboReportGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboReportGroup.Properties.NullText = ""
        Me.cboReportGroup.Size = New System.Drawing.Size(292, 22)
        Me.cboReportGroup.StyleController = Me.LayoutControl1
        Me.cboReportGroup.TabIndex = 8
        '
        'GridReports
        '
        Me.GridReports.Location = New System.Drawing.Point(12, 107)
        Me.GridReports.MainView = Me.GridReportsView
        Me.GridReports.Name = "GridReports"
        Me.GridReports.Size = New System.Drawing.Size(374, 604)
        Me.GridReports.TabIndex = 5
        Me.GridReports.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridReportsView})
        '
        'GridReportsView
        '
        Me.GridReportsView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow
        Me.GridReportsView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Yellow
        Me.GridReportsView.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridReportsView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.GridReportsView.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Yellow
        Me.GridReportsView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridReportsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colObjectID, Me.colReportGroup, Me.colCaption})
        Me.GridReportsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.GridReportsView.GridControl = Me.GridReports
        Me.GridReportsView.Name = "GridReportsView"
        Me.GridReportsView.OptionsFind.AlwaysVisible = True
        Me.GridReportsView.OptionsView.ShowGroupPanel = False
        '
        'colObjectID
        '
        Me.colObjectID.Caption = "ObjectID"
        Me.colObjectID.FieldName = "ObjectID"
        Me.colObjectID.Name = "colObjectID"
        '
        'colReportGroup
        '
        Me.colReportGroup.Caption = "ReportGroup"
        Me.colReportGroup.FieldName = "ReportGroup"
        Me.colReportGroup.Name = "colReportGroup"
        Me.colReportGroup.OptionsColumn.AllowEdit = False
        Me.colReportGroup.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colReportGroup.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.colReportGroup.OptionsColumn.AllowMove = False
        Me.colReportGroup.OptionsColumn.AllowShowHide = False
        Me.colReportGroup.OptionsColumn.AllowSize = False
        Me.colReportGroup.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[True]
        Me.colReportGroup.OptionsColumn.ReadOnly = True
        Me.colReportGroup.Visible = True
        Me.colReportGroup.VisibleIndex = 0
        Me.colReportGroup.Width = 117
        '
        'colCaption
        '
        Me.colCaption.Caption = "Caption"
        Me.colCaption.FieldName = "Caption"
        Me.colCaption.Name = "colCaption"
        Me.colCaption.OptionsColumn.AllowEdit = False
        Me.colCaption.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCaption.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCaption.OptionsColumn.AllowMove = False
        Me.colCaption.OptionsColumn.AllowShowHide = False
        Me.colCaption.OptionsColumn.AllowSize = False
        Me.colCaption.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCaption.OptionsColumn.ReadOnly = True
        Me.colCaption.Visible = True
        Me.colCaption.VisibleIndex = 1
        Me.colCaption.Width = 165
        '
        'cboReportGroupList
        '
        Me.cboReportGroupList.Location = New System.Drawing.Point(160, 50)
        Me.cboReportGroupList.Name = "cboReportGroupList"
        Me.cboReportGroupList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboReportGroupList.Properties.NullText = ""
        Me.cboReportGroupList.Size = New System.Drawing.Size(214, 22)
        Me.cboReportGroupList.StyleController = Me.LayoutControl1
        Me.cboReportGroupList.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlGroup_Main, Me.SplitterItem1, Me.tabDetails, Me.LayoutControlItem_Add, Me.LayoutControlItem_Edit, Me.EmptySpaceItem3, Me.LayoutControlItem_Delete, Me.LayoutControlItem36, Me.LayoutControlGroup3, Me.LayoutControlItem41})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1361, 723)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem2.Control = Me.GridReports
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 75)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(136, 43)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(378, 628)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Report List"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(133, 17)
        '
        'LayoutControlGroup_Main
        '
        Me.LayoutControlGroup_Main.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem16, Me.LayoutControlItem18, Me.LayoutControlItem5, Me.LayoutControlItem15, Me.LayoutControlItem6, Me.LayoutControlItem17, Me.LayoutControlItem31})
        Me.LayoutControlGroup_Main.Location = New System.Drawing.Point(383, 30)
        Me.LayoutControlGroup_Main.Name = "LayoutControlGroup_Main"
        Me.LayoutControlGroup_Main.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Main.Size = New System.Drawing.Size(958, 149)
        Me.LayoutControlGroup_Main.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem9.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem9.Control = Me.txtCaption
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(472, 29)
        Me.LayoutControlItem9.Text = "*Caption:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(133, 17)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtObjectID
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 29)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(472, 26)
        Me.LayoutControlItem3.Text = "*Object ID:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtDLL
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 55)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(472, 26)
        Me.LayoutControlItem4.Text = "*DLL:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.txtReportClass
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 81)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(472, 26)
        Me.LayoutControlItem16.Text = "*Class:"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.txtRemarks
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 107)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(942, 26)
        Me.LayoutControlItem18.Text = "Remarks:"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem5.Control = Me.cboReportGroup
        Me.LayoutControlItem5.Location = New System.Drawing.Point(472, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(432, 29)
        Me.LayoutControlItem5.Text = "*Report Group:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(133, 17)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.txtSortCode
        Me.LayoutControlItem15.Location = New System.Drawing.Point(472, 29)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(470, 26)
        Me.LayoutControlItem15.Text = "*Sort Code:"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtGroupedBy
        Me.LayoutControlItem6.Location = New System.Drawing.Point(472, 55)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(470, 26)
        Me.LayoutControlItem6.Text = "Grouped By:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.txtSortedBy
        Me.LayoutControlItem17.Location = New System.Drawing.Point(472, 81)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(470, 26)
        Me.LayoutControlItem17.Text = "Sorted By:"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Control = Me.cmdAddReportGroup
        Me.LayoutControlItem31.Location = New System.Drawing.Point(904, 0)
        Me.LayoutControlItem31.MaxSize = New System.Drawing.Size(38, 29)
        Me.LayoutControlItem31.MinSize = New System.Drawing.Size(38, 29)
        Me.LayoutControlItem31.Name = "LayoutControlItem31"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(38, 29)
        Me.LayoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem31.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(378, 30)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 673)
        '
        'tabDetails
        '
        Me.tabDetails.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabDetails.Location = New System.Drawing.Point(383, 179)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.tabDetails.SelectedTabPage = Me.LayoutControlGroup_FilterOptions
        Me.tabDetails.SelectedTabPageIndex = 1
        Me.tabDetails.Size = New System.Drawing.Size(958, 524)
        Me.tabDetails.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup_FilterOptions, Me.LayoutControlGroup_SortOptions, Me.LayoutControlGroup_Feature})
        '
        'LayoutControlGroup_FilterOptions
        '
        Me.LayoutControlGroup_FilterOptions.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem32, Me.LayoutControlItem33, Me.LayoutControlGroup_FilterOptionSpecific, Me.LayoutControlGroup_FilterOptionGeneric})
        Me.LayoutControlGroup_FilterOptions.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_FilterOptions.Name = "LayoutControlGroup_FilterOptions"
        Me.LayoutControlGroup_FilterOptions.Size = New System.Drawing.Size(942, 483)
        Me.LayoutControlGroup_FilterOptions.Text = "Filter Options"
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.optFilterOption_UseSpecific
        Me.LayoutControlItem32.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem32.Name = "LayoutControlItem32"
        Me.LayoutControlItem32.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem32.Size = New System.Drawing.Size(942, 24)
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem32.TextVisible = False
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.optFilterOption_UseGeneric
        Me.LayoutControlItem33.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem33.Name = "LayoutControlItem33"
        Me.LayoutControlItem33.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem33.Size = New System.Drawing.Size(942, 24)
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem33.TextVisible = False
        '
        'LayoutControlGroup_FilterOptionSpecific
        '
        Me.LayoutControlGroup_FilterOptionSpecific.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem34, Me.LayoutControlItem35})
        Me.LayoutControlGroup_FilterOptionSpecific.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlGroup_FilterOptionSpecific.Name = "LayoutControlGroup_FilterOptionSpecific"
        Me.LayoutControlGroup_FilterOptionSpecific.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_FilterOptionSpecific.Size = New System.Drawing.Size(942, 32)
        Me.LayoutControlGroup_FilterOptionSpecific.TextVisible = False
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.Control = Me.txtReportFilterOptionDLL
        Me.LayoutControlItem34.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem34.Name = "LayoutControlItem34"
        Me.LayoutControlItem34.Padding = New DevExpress.XtraLayout.Utils.Padding(50, 2, 2, 2)
        Me.LayoutControlItem34.Size = New System.Drawing.Size(494, 26)
        Me.LayoutControlItem34.Text = "DLL:"
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem35
        '
        Me.LayoutControlItem35.Control = Me.txtReportFilterOptionClass
        Me.LayoutControlItem35.Location = New System.Drawing.Point(494, 0)
        Me.LayoutControlItem35.Name = "LayoutControlItem35"
        Me.LayoutControlItem35.Size = New System.Drawing.Size(442, 26)
        Me.LayoutControlItem35.Text = "VB Class:"
        Me.LayoutControlItem35.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlGroup_FilterOptionGeneric
        '
        Me.LayoutControlGroup_FilterOptionGeneric.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem6, Me.LayoutControlItem7, Me.LayoutControlItem28, Me.LayoutControlItem29, Me.LayoutControlItem30, Me.EmptySpaceItem7})
        Me.LayoutControlGroup_FilterOptionGeneric.Location = New System.Drawing.Point(0, 80)
        Me.LayoutControlGroup_FilterOptionGeneric.Name = "LayoutControlGroup_FilterOptionGeneric"
        Me.LayoutControlGroup_FilterOptionGeneric.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_FilterOptionGeneric.Size = New System.Drawing.Size(942, 403)
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
        Me.LayoutControlItem7.Control = Me.GridFilterOptions
        Me.LayoutControlItem7.Location = New System.Drawing.Point(58, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(878, 397)
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
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(58, 182)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_SelectionSource, Me.LayoutControlGroup_Optionals, Me.LayoutControlGroup_DateRangeFields, Me.LayoutControlItem19})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(942, 483)
        Me.LayoutControlGroup2.Text = "Report Details"
        '
        'LayoutControlGroup_SelectionSource
        '
        Me.LayoutControlGroup_SelectionSource.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_SelectionSource.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_SelectionSource.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem_SelectionSourceType, Me.LayoutControlItem_SelectionKeyField, Me.LayoutControlItem8, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.EmptySpaceItem1, Me.LayoutControlItem_SelectionSource, Me.LayoutControlItem12})
        Me.LayoutControlGroup_SelectionSource.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlGroup_SelectionSource.Name = "LayoutControlGroup_SelectionSource"
        Me.LayoutControlGroup_SelectionSource.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_SelectionSource.Size = New System.Drawing.Size(942, 117)
        Me.LayoutControlGroup_SelectionSource.Text = "Selection Source"
        '
        'LayoutControlItem_SelectionSourceType
        '
        Me.LayoutControlItem_SelectionSourceType.Control = Me.cboSelectionSourceType
        Me.LayoutControlItem_SelectionSourceType.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem_SelectionSourceType.Name = "LayoutControlItem_SelectionSourceType"
        Me.LayoutControlItem_SelectionSourceType.Size = New System.Drawing.Size(290, 26)
        Me.LayoutControlItem_SelectionSourceType.Text = "Selection Source Type:"
        Me.LayoutControlItem_SelectionSourceType.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem_SelectionKeyField
        '
        Me.LayoutControlItem_SelectionKeyField.Control = Me.txtSelectionKeyField
        Me.LayoutControlItem_SelectionKeyField.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem_SelectionKeyField.Name = "LayoutControlItem_SelectionKeyField"
        Me.LayoutControlItem_SelectionKeyField.Size = New System.Drawing.Size(290, 26)
        Me.LayoutControlItem_SelectionKeyField.Text = "EditValue Field:"
        Me.LayoutControlItem_SelectionKeyField.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cboSelectionSource
        Me.LayoutControlItem8.Location = New System.Drawing.Point(290, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(331, 26)
        Me.LayoutControlItem8.Text = "Selection Source:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.txtSelectionDisplayField
        Me.LayoutControlItem13.Location = New System.Drawing.Point(290, 26)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(331, 26)
        Me.LayoutControlItem13.Text = "DisplayValue Field:"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.txtKeyFilterField
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(290, 26)
        Me.LayoutControlItem14.Text = "DataSource Key Field:"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(133, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(290, 52)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(636, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem_SelectionSource
        '
        Me.LayoutControlItem_SelectionSource.Control = Me.txtSelectionSource
        Me.LayoutControlItem_SelectionSource.Location = New System.Drawing.Point(621, 0)
        Me.LayoutControlItem_SelectionSource.Name = "LayoutControlItem_SelectionSource"
        Me.LayoutControlItem_SelectionSource.Size = New System.Drawing.Size(305, 26)
        Me.LayoutControlItem_SelectionSource.Text = "Selection Source:"
        Me.LayoutControlItem_SelectionSource.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtSelectionSortField
        Me.LayoutControlItem12.Location = New System.Drawing.Point(621, 26)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(305, 26)
        Me.LayoutControlItem12.Text = "Sort Field:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlGroup_Optionals
        '
        Me.LayoutControlGroup_Optionals.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem20, Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem23})
        Me.LayoutControlGroup_Optionals.Location = New System.Drawing.Point(0, 141)
        Me.LayoutControlGroup_Optionals.Name = "LayoutControlGroup_Optionals"
        Me.LayoutControlGroup_Optionals.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_Optionals.Size = New System.Drawing.Size(942, 64)
        Me.LayoutControlGroup_Optionals.TextVisible = False
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.chkUseTemplateList
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem20.TextVisible = False
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.chkUsePreviewButton
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.chkUseExportButton
        Me.LayoutControlItem22.Location = New System.Drawing.Point(464, 0)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(462, 24)
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem22.TextVisible = False
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.chkShowInPopup
        Me.LayoutControlItem23.Location = New System.Drawing.Point(464, 24)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(462, 24)
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem23.TextVisible = False
        '
        'LayoutControlGroup_DateRangeFields
        '
        Me.LayoutControlGroup_DateRangeFields.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_DateRangeFields.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_DateRangeFields.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem24, Me.LayoutControlItem25, Me.EmptySpaceItem2})
        Me.LayoutControlGroup_DateRangeFields.Location = New System.Drawing.Point(0, 205)
        Me.LayoutControlGroup_DateRangeFields.Name = "LayoutControlGroup_DateRangeFields"
        Me.LayoutControlGroup_DateRangeFields.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlGroup_DateRangeFields.Size = New System.Drawing.Size(942, 278)
        Me.LayoutControlGroup_DateRangeFields.Text = "(Optional) Report Email Automation Date Range Fields"
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.txtDateRangeFromField
        Me.LayoutControlItem24.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(387, 26)
        Me.LayoutControlItem24.Text = "Date From Field:"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.txtDateRangeToField
        Me.LayoutControlItem25.Location = New System.Drawing.Point(387, 0)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(539, 26)
        Me.LayoutControlItem25.Text = "Date To Field:"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(133, 16)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(926, 213)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.chkUseSelectionList
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem19.Size = New System.Drawing.Size(942, 24)
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem19.TextVisible = False
        '
        'LayoutControlGroup_SortOptions
        '
        Me.LayoutControlGroup_SortOptions.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem27, Me.LayoutControlItem10, Me.EmptySpaceItem4, Me.EmptySpaceItem5, Me.LayoutControlItem11, Me.LayoutControlItem26})
        Me.LayoutControlGroup_SortOptions.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_SortOptions.Name = "LayoutControlGroup_SortOptions"
        Me.LayoutControlGroup_SortOptions.Size = New System.Drawing.Size(942, 483)
        Me.LayoutControlGroup_SortOptions.Text = "Sort Options"
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.GridSortOptions
        Me.LayoutControlItem27.Location = New System.Drawing.Point(58, 0)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(884, 483)
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem27.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.cmdDeleteSortOption
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem4.MaxSize = New System.Drawing.Size(58, 32)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(58, 32)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(58, 32)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 215)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(58, 268)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cmdMoveUpSortOption
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 93)
        Me.LayoutControlItem11.MaxSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.cmdMoveDownSortOption
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 154)
        Me.LayoutControlItem26.MaxSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem26.MinSize = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(58, 61)
        Me.LayoutControlItem26.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem26.TextVisible = False
        '
        'LayoutControlGroup_Feature
        '
        Me.LayoutControlGroup_Feature.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem37, Me.EmptySpaceItem8, Me.LayoutControlGroup_FeatureSetup, Me.LayoutControlItem40})
        Me.LayoutControlGroup_Feature.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Feature.Name = "LayoutControlGroup_Feature"
        Me.LayoutControlGroup_Feature.Size = New System.Drawing.Size(942, 483)
        Me.LayoutControlGroup_Feature.Text = "Feature Assignment"
        '
        'LayoutControlItem37
        '
        Me.LayoutControlItem37.Control = Me.txtFID
        Me.LayoutControlItem37.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem37.Name = "LayoutControlItem37"
        Me.LayoutControlItem37.Size = New System.Drawing.Size(942, 26)
        Me.LayoutControlItem37.Text = "Feature ID:"
        Me.LayoutControlItem37.TextSize = New System.Drawing.Size(133, 16)
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(0, 124)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(942, 359)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_FeatureSetup
        '
        Me.LayoutControlGroup_FeatureSetup.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_FeatureSetup.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_FeatureSetup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem38, Me.LayoutControlItem39, Me.EmptySpaceItem9})
        Me.LayoutControlGroup_FeatureSetup.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlGroup_FeatureSetup.Name = "LayoutControlGroup_FeatureSetup"
        Me.LayoutControlGroup_FeatureSetup.Size = New System.Drawing.Size(942, 72)
        Me.LayoutControlGroup_FeatureSetup.Text = "Setup"
        '
        'LayoutControlItem38
        '
        Me.LayoutControlItem38.Control = Me.cboFeature
        Me.LayoutControlItem38.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem38.Name = "LayoutControlItem38"
        Me.LayoutControlItem38.Size = New System.Drawing.Size(459, 26)
        Me.LayoutControlItem38.Text = "Feature:"
        Me.LayoutControlItem38.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem39
        '
        Me.LayoutControlItem39.Control = Me.cmdGenerateFID
        Me.LayoutControlItem39.Location = New System.Drawing.Point(459, 0)
        Me.LayoutControlItem39.Name = "LayoutControlItem39"
        Me.LayoutControlItem39.Size = New System.Drawing.Size(229, 26)
        Me.LayoutControlItem39.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem39.TextVisible = False
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(688, 0)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(230, 26)
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem40
        '
        Me.LayoutControlItem40.Control = Me.txtFeature
        Me.LayoutControlItem40.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem40.Name = "LayoutControlItem40"
        Me.LayoutControlItem40.Size = New System.Drawing.Size(942, 26)
        Me.LayoutControlItem40.Text = "Assigned to Feature:"
        Me.LayoutControlItem40.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem_Add
        '
        Me.LayoutControlItem_Add.Control = Me.cmdAddSave
        Me.LayoutControlItem_Add.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem_Add.MaxSize = New System.Drawing.Size(0, 30)
        Me.LayoutControlItem_Add.MinSize = New System.Drawing.Size(27, 30)
        Me.LayoutControlItem_Add.Name = "LayoutControlItem_Add"
        Me.LayoutControlItem_Add.Size = New System.Drawing.Size(119, 30)
        Me.LayoutControlItem_Add.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Add.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Add.TextVisible = False
        '
        'LayoutControlItem_Edit
        '
        Me.LayoutControlItem_Edit.Control = Me.cmdEditCancel
        Me.LayoutControlItem_Edit.Location = New System.Drawing.Point(119, 0)
        Me.LayoutControlItem_Edit.MaxSize = New System.Drawing.Size(0, 30)
        Me.LayoutControlItem_Edit.MinSize = New System.Drawing.Size(27, 30)
        Me.LayoutControlItem_Edit.Name = "LayoutControlItem_Edit"
        Me.LayoutControlItem_Edit.Size = New System.Drawing.Size(116, 30)
        Me.LayoutControlItem_Edit.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Edit.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Edit.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(354, 0)
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
        Me.LayoutControlItem_Delete.Location = New System.Drawing.Point(235, 0)
        Me.LayoutControlItem_Delete.MaxSize = New System.Drawing.Size(0, 30)
        Me.LayoutControlItem_Delete.MinSize = New System.Drawing.Size(27, 30)
        Me.LayoutControlItem_Delete.Name = "LayoutControlItem_Delete"
        Me.LayoutControlItem_Delete.Size = New System.Drawing.Size(119, 30)
        Me.LayoutControlItem_Delete.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_Delete.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Delete.TextVisible = False
        '
        'LayoutControlItem36
        '
        Me.LayoutControlItem36.Control = Me.Label1
        Me.LayoutControlItem36.Location = New System.Drawing.Point(420, 0)
        Me.LayoutControlItem36.Name = "LayoutControlItem36"
        Me.LayoutControlItem36.Size = New System.Drawing.Size(613, 30)
        Me.LayoutControlItem36.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem36.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(9, 9, 5, 5)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(378, 45)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem1.Control = Me.cboReportGroupList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(354, 29)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(354, 29)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(354, 29)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Report Group"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(133, 17)
        '
        'LayoutControlItem41
        '
        Me.LayoutControlItem41.Control = Me.cboGenScript
        Me.LayoutControlItem41.Location = New System.Drawing.Point(1033, 0)
        Me.LayoutControlItem41.Name = "LayoutControlItem41"
        Me.LayoutControlItem41.Size = New System.Drawing.Size(308, 30)
        Me.LayoutControlItem41.Text = "Generate Script:"
        Me.LayoutControlItem41.TextSize = New System.Drawing.Size(133, 16)
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
        Me.header.Text = "Report Configuration"
        '
        'ReportConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "ReportConfig"
        Me.Size = New System.Drawing.Size(1365, 751)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboGenScript.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFeature.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFeature.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportFilterOptionClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportFilterOptionDLL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optFilterOption_UseGeneric.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optFilterOption_UseSpecific.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSortOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSortOptionsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSortOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSortIsMovable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFilterOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridFilterOptionsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFilterOption, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repApplyToReportSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRowSourceHasUserDataFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateRangeToField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateRangeFromField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowInPopup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseExportButton.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUsePreviewButton.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseTemplateList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseSelectionList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKeyFilterField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSelectionDisplayField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSelectionSortField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSelectionKeyField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSelectionSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSelectionSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSelectionSourceType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroupedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDLL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObjectID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaption.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboReportGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridReports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridReportsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboReportGroupList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_FilterOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_FilterOptionSpecific, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_FilterOptionGeneric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_SelectionSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_SelectionSourceType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_SelectionKeyField, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_SelectionSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Optionals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_DateRangeFields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_SortOptions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Feature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_FeatureSetup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Add, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Delete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents chkShowInPopup As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUseExportButton As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUsePreviewButton As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUseTemplateList As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUseSelectionList As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSortedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtReportClass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKeyFilterField As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSelectionDisplayField As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSelectionSortField As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSelectionKeyField As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSelectionSource As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboSelectionSource As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboSelectionSourceType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtGroupedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDLL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtObjectID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCaption As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboReportGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridReports As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridReportsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cboReportGroupList As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDateRangeToField As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDateRangeFromField As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup_Main As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents colObjectID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReportGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridFilterOptions As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridFilterOptionsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents tabDetails As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_SelectionSource As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem_SelectionSourceType As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_SelectionKeyField As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_SelectionSource As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup_Optionals As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_DateRangeFields As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup_FilterOptions As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdEditCancel As System.Windows.Forms.Button
    Friend WithEvents cmdAddSave As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem_Add As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_Edit As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem_Delete As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridSortOptions As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridSortOptionsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup_SortOptions As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colSortFieldName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSortCaption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSortDefaultSortOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repSortOrder As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colSortIsMovable As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repSortIsMovable As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colFilterSortCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterFKeyFilterOption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterCaption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterOperator As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterComboBoxCustomRowSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterIsApplyToReportSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFilterRowSourceHasUserDataFilter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repFilterOption As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repApplyToReportSource As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents repRowSourceHasUserDataFilter As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cmdMoveDownSortOption As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUpSortOption As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteSortOption As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
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
    Friend WithEvents txtReportFilterOptionClass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtReportFilterOptionDLL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents optFilterOption_UseGeneric As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents optFilterOption_UseSpecific As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem32 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem33 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_FilterOptionSpecific As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem34 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem35 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_FilterOptionGeneric As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem36 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdGenerateFID As System.Windows.Forms.Button
    Friend WithEvents cboFeature As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtFID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup_Feature As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem37 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup_FeatureSetup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem38 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem39 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFeature As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem40 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboGenScript As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem41 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colFilterDefaultValue As DevExpress.XtraGrid.Columns.GridColumn

End Class
