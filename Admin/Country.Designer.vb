<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Country
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Country))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProvGrid = New DevExpress.XtraGrid.GridControl()
        Me.ProvView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repProvTxt50 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repProvSortCode = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colDateUpdated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtNat = New DevExpress.XtraEditors.TextEdit()
        Me.CityGrid = New DevExpress.XtraGrid.GridControl()
        Me.CityView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtCountryCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtCallingCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ProvGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProvView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repProvTxt50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repProvSortCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CityGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CityView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCountryCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCallingCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(840, 506)
        Me.header.TabIndex = 4
        Me.header.Text = "Country Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtCallingCode)
        Me.LayoutControl1.Controls.Add(Me.txtCountryCode)
        Me.LayoutControl1.Controls.Add(Me.ProvGrid)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.txtNat)
        Me.LayoutControl1.Controls.Add(Me.CityGrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(510, 198, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(836, 478)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ProvGrid
        '
        Me.ProvGrid.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton()})
        Me.ProvGrid.Location = New System.Drawing.Point(25, 155)
        Me.ProvGrid.MainView = Me.ProvView
        Me.ProvGrid.Name = "ProvGrid"
        Me.ProvGrid.Padding = New System.Windows.Forms.Padding(10)
        Me.ProvGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repProvTxt50, Me.repProvSortCode})
        Me.ProvGrid.Size = New System.Drawing.Size(388, 298)
        Me.ProvGrid.TabIndex = 11
        Me.ProvGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ProvView})
        '
        'ProvView
        '
        Me.ProvView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.ProvView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ProvView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.ProvView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ProvView.Appearance.Row.Options.UseTextOptions = True
        Me.ProvView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ProvView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ProvView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.ProvView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.ProvView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ProvView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ProvView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.ProvView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.GridColumn17, Me.GridColumn18, Me.colDateUpdated, Me.colLastUpdatedBy, Me.colEdited, Me.GridColumn7})
        Me.ProvView.GridControl = Me.ProvGrid
        Me.ProvView.Name = "ProvView"
        Me.ProvView.NewItemRowText = "Click here to add new Record"
        Me.ProvView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.ProvView.OptionsBehavior.AutoPopulateColumns = False
        Me.ProvView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.ProvView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.ProvView.OptionsCustomization.AllowFilter = False
        Me.ProvView.OptionsCustomization.AllowGroup = False
        Me.ProvView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ProvView.OptionsCustomization.AllowSort = False
        Me.ProvView.OptionsEditForm.EditFormColumnCount = 2
        Me.ProvView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.ProvView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.ProvView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.ProvView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.[False]
        Me.ProvView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ProvView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.ProvView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.ProvView.OptionsSelection.UseIndicatorForSelection = False
        Me.ProvView.OptionsView.ShowGroupPanel = False
        Me.ProvView.ViewCaption = " Other Information"
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "State | Province"
        Me.GridColumn17.ColumnEdit = Me.repProvTxt50
        Me.GridColumn17.FieldName = "Name"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        '
        'repProvTxt50
        '
        Me.repProvTxt50.AutoHeight = False
        Me.repProvTxt50.MaxLength = 50
        Me.repProvTxt50.Name = "repProvTxt50"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Sort Code"
        Me.GridColumn18.ColumnEdit = Me.repProvSortCode
        Me.GridColumn18.FieldName = "SortCode"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 1
        '
        'repProvSortCode
        '
        Me.repProvSortCode.AutoHeight = False
        Me.repProvSortCode.Mask.EditMask = "f"
        Me.repProvSortCode.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repProvSortCode.Name = "repProvSortCode"
        '
        'colDateUpdated
        '
        Me.colDateUpdated.FieldName = "DateUpdated"
        Me.colDateUpdated.Name = "colDateUpdated"
        '
        'colLastUpdatedBy
        '
        Me.colLastUpdatedBy.FieldName = "LastUpdatedBy"
        Me.colLastUpdatedBy.Name = "colLastUpdatedBy"
        '
        'colEdited
        '
        Me.colEdited.FieldName = "Edited"
        Me.colEdited.Name = "colEdited"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "FKeyCntry"
        Me.GridColumn7.FieldName = "FKeyCntry"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 39)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 100
        Me.txtName.Size = New System.Drawing.Size(336, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(356, 39)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(152, 22)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'txtNat
        '
        Me.txtNat.Location = New System.Drawing.Point(508, 39)
        Me.txtNat.Name = "txtNat"
        Me.txtNat.Properties.MaxLength = 100
        Me.txtNat.Size = New System.Drawing.Size(308, 22)
        Me.txtNat.StyleController = Me.LayoutControl1
        Me.txtNat.TabIndex = 4
        Me.txtNat.ToolTip = "Nationality"
        '
        'CityGrid
        '
        Me.CityGrid.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton()})
        Me.CityGrid.Location = New System.Drawing.Point(423, 155)
        Me.CityGrid.MainView = Me.CityView
        Me.CityGrid.Name = "CityGrid"
        Me.CityGrid.Padding = New System.Windows.Forms.Padding(10)
        Me.CityGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.CityGrid.Size = New System.Drawing.Size(388, 298)
        Me.CityGrid.TabIndex = 10
        Me.CityGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CityView})
        '
        'CityView
        '
        Me.CityView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CityView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CityView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CityView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CityView.Appearance.Row.Options.UseTextOptions = True
        Me.CityView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CityView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CityView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CityView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CityView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CityView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CityView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CityView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.CityView.GridControl = Me.CityGrid
        Me.CityView.Name = "CityView"
        Me.CityView.NewItemRowText = "Click here to add new Record"
        Me.CityView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CityView.OptionsBehavior.AutoPopulateColumns = False
        Me.CityView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CityView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.CityView.OptionsCustomization.AllowFilter = False
        Me.CityView.OptionsCustomization.AllowGroup = False
        Me.CityView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CityView.OptionsCustomization.AllowSort = False
        Me.CityView.OptionsEditForm.EditFormColumnCount = 2
        Me.CityView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.CityView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.CityView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.CityView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.[False]
        Me.CityView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CityView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CityView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CityView.OptionsSelection.UseIndicatorForSelection = False
        Me.CityView.OptionsView.ShowGroupPanel = False
        Me.CityView.ViewCaption = " Other Information"
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "PKey"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "City"
        Me.GridColumn2.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn2.FieldName = "Name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.MaxLength = 50
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Sort Code"
        Me.GridColumn3.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn3.FieldName = "SortCode"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.EditFormat.FormatString = "f"
        Me.RepositoryItemTextEdit2.Mask.EditMask = "f"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "DateUpdated"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "LastUpdatedBy"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "Edited"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlGroup4, Me.LayoutControlGroup3, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(836, 478)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 20)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(336, 61)
        Me.LayoutControlItem1.Text = "* Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(77, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSortCode
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(336, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 20)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(152, 61)
        Me.LayoutControlItem2.Text = "Sort Code"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(77, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtNat
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(488, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 20)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(308, 61)
        Me.LayoutControlItem3.Text = "* Nationality"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(77, 16)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup4.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 106)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(398, 332)
        Me.LayoutControlGroup4.Text = "State | Province"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.ProvGrid
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(392, 302)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(398, 106)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(398, 332)
        Me.LayoutControlGroup3.Text = "City"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.CityGrid
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(392, 302)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'txtCountryCode
        '
        Me.txtCountryCode.Location = New System.Drawing.Point(22, 102)
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.Size = New System.Drawing.Size(186, 22)
        Me.txtCountryCode.StyleController = Me.LayoutControl1
        Me.txtCountryCode.TabIndex = 12
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtCountryCode
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 61)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(190, 45)
        Me.LayoutControlItem6.Text = "Country Code"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(77, 16)
        '
        'txtCallingCode
        '
        Me.txtCallingCode.Location = New System.Drawing.Point(212, 102)
        Me.txtCallingCode.Name = "txtCallingCode"
        Me.txtCallingCode.Size = New System.Drawing.Size(186, 22)
        Me.txtCallingCode.StyleController = Me.LayoutControl1
        Me.txtCallingCode.TabIndex = 13
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtCallingCode
        Me.LayoutControlItem7.Location = New System.Drawing.Point(190, 61)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(190, 45)
        Me.LayoutControlItem7.Text = "Call Code"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(77, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(380, 61)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(416, 45)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'Country
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "Country"
        Me.Size = New System.Drawing.Size(840, 506)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ProvGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProvView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repProvTxt50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repProvSortCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CityGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CityView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCountryCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCallingCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CityGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CityView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ProvGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ProvView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repProvTxt50 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repProvSortCode As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCallingCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCountryCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem

End Class
