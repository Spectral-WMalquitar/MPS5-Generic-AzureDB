<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bank))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtAbbrv = New DevExpress.XtraEditors.TextEdit()
        Me.txtSwiftCode = New DevExpress.XtraEditors.TextEdit()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCntry = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repState = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCity = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repNumeric = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBranchName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAddr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repTxt50 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.repRem = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.txtIBANNo = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbbrv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSwiftCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCntry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repNumeric, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repTxt50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIBANNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(791, 530)
        Me.header.TabIndex = 1
        Me.header.Text = "Bank Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.txtAbbrv)
        Me.LayoutControl1.Controls.Add(Me.txtSwiftCode)
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
        Me.LayoutControl1.Controls.Add(Me.txtIBANNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(787, 502)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 39)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 200
        Me.txtName.Size = New System.Drawing.Size(374, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(394, 39)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(125, 22)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'txtAbbrv
        '
        Me.txtAbbrv.Location = New System.Drawing.Point(519, 39)
        Me.txtAbbrv.Name = "txtAbbrv"
        Me.txtAbbrv.Properties.MaxLength = 50
        Me.txtAbbrv.Size = New System.Drawing.Size(248, 22)
        Me.txtAbbrv.StyleController = Me.LayoutControl1
        Me.txtAbbrv.TabIndex = 4
        Me.txtAbbrv.ToolTip = "Abbreviation"
        '
        'txtSwiftCode
        '
        Me.txtSwiftCode.Location = New System.Drawing.Point(20, 95)
        Me.txtSwiftCode.Name = "txtSwiftCode"
        Me.txtSwiftCode.Properties.MaxLength = 15
        Me.txtSwiftCode.Size = New System.Drawing.Size(374, 22)
        Me.txtSwiftCode.StyleController = Me.LayoutControl1
        Me.txtSwiftCode.TabIndex = 4
        Me.txtSwiftCode.ToolTip = "Swift Code"
        '
        'MainGrid
        '
        Me.MainGrid.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton()})
        Me.MainGrid.Location = New System.Drawing.Point(25, 166)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Padding = New System.Windows.Forms.Padding(10)
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repCntry, Me.repNumeric, Me.repTxt50, Me.repRem, Me.repState, Me.repCity})
        Me.MainGrid.Size = New System.Drawing.Size(737, 311)
        Me.MainGrid.TabIndex = 7
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
        Me.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.GridColumn1, Me.GridColumn7, Me.GridColumn8, Me.GridColumn6, Me.GridColumn9, Me.GridColumn11, Me.GridColumn10, Me.GridColumn2, Me.GridColumn4, Me.GridColumn5, Me.colEdited, Me.colBranchName, Me.colAddr})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new Record"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsEditForm.EditFormColumnCount = 2
        Me.MainView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.ViewCaption = " Other Information"
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Bank"
        Me.GridColumn1.FieldName = "FKeyBank"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Bldg"
        Me.GridColumn7.FieldName = "Bldg"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Width = 111
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Street"
        Me.GridColumn8.FieldName = "St"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Width = 115
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Country"
        Me.GridColumn6.ColumnEdit = Me.repCntry
        Me.GridColumn6.FieldName = "FKeyCntry"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Width = 165
        '
        'repCntry
        '
        Me.repCntry.AutoHeight = False
        Me.repCntry.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repCntry.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repCntry.DisplayMember = "Name"
        Me.repCntry.DropDownRows = 10
        Me.repCntry.Name = "repCntry"
        Me.repCntry.NullText = ""
        Me.repCntry.ShowFooter = False
        Me.repCntry.ShowHeader = False
        Me.repCntry.ValueMember = "PKey"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Part of City"
        Me.GridColumn9.FieldName = "PartofCity"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Width = 151
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "State"
        Me.GridColumn11.ColumnEdit = Me.repState
        Me.GridColumn11.FieldName = "FKeyProvince"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Width = 155
        '
        'repState
        '
        Me.repState.AutoHeight = False
        Me.repState.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Add Stat | Province", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repState.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repState.DisplayMember = "Name"
        Me.repState.DropDownRows = 10
        Me.repState.Name = "repState"
        Me.repState.NullText = ""
        Me.repState.ShowFooter = False
        Me.repState.ShowHeader = False
        Me.repState.ValueMember = "PKey"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "City"
        Me.GridColumn10.ColumnEdit = Me.repCity
        Me.GridColumn10.FieldName = "FKeyCity"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Width = 118
        '
        'repCity
        '
        Me.repCity.AutoHeight = False
        Me.repCity.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Add New City", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repCity.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repCity.DisplayMember = "Name"
        Me.repCity.DropDownRows = 10
        Me.repCity.Name = "repCity"
        Me.repCity.NullText = ""
        Me.repCity.ShowFooter = False
        Me.repCity.ShowHeader = False
        Me.repCity.ValueMember = "PKey"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Sort Code"
        Me.GridColumn2.ColumnEdit = Me.repNumeric
        Me.GridColumn2.FieldName = "SortCode"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 77
        '
        'repNumeric
        '
        Me.repNumeric.AutoHeight = False
        Me.repNumeric.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repNumeric.Name = "repNumeric"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Bank Charge"
        Me.GridColumn4.ColumnEdit = Me.repNumeric
        Me.GridColumn4.FieldName = "BankCharge"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 143
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Swift Code"
        Me.GridColumn5.FieldName = "SwiftCode"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'colEdited
        '
        Me.colEdited.FieldName = "Edited"
        Me.colEdited.Name = "colEdited"
        '
        'colBranchName
        '
        Me.colBranchName.Caption = "Branch Name"
        Me.colBranchName.FieldName = "Name"
        Me.colBranchName.Name = "colBranchName"
        Me.colBranchName.Visible = True
        Me.colBranchName.VisibleIndex = 0
        Me.colBranchName.Width = 184
        '
        'colAddr
        '
        Me.colAddr.Caption = "Address"
        Me.colAddr.FieldName = "Addr"
        Me.colAddr.Name = "colAddr"
        Me.colAddr.Visible = True
        Me.colAddr.VisibleIndex = 1
        Me.colAddr.Width = 290
        '
        'repTxt50
        '
        Me.repTxt50.AutoHeight = False
        Me.repTxt50.MaxLength = 50
        Me.repTxt50.Name = "repTxt50"
        '
        'repRem
        '
        Me.repRem.MaxLength = 200
        Me.repRem.Name = "repRem"
        '
        'txtIBANNo
        '
        Me.txtIBANNo.Location = New System.Drawing.Point(394, 95)
        Me.txtIBANNo.Name = "txtIBANNo"
        Me.txtIBANNo.Properties.MaxLength = 15
        Me.txtIBANNo.Size = New System.Drawing.Size(373, 22)
        Me.txtIBANNo.StyleController = Me.LayoutControl1
        Me.txtIBANNo.TabIndex = 4
        Me.txtIBANNo.ToolTip = "Swift Code"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlGroup2, Me.LayoutControlItem4, Me.LayoutControlItem6})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(787, 502)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(374, 56)
        Me.LayoutControlItem1.Text = "* Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSortCode
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(374, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(125, 56)
        Me.LayoutControlItem2.Text = "Sort Code"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtAbbrv
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(499, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(248, 56)
        Me.LayoutControlItem3.Text = "* Abbreviation"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 117)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(747, 345)
        Me.LayoutControlGroup2.Text = "Branch"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.MainGrid
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(741, 315)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtSwiftCode
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 20)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(374, 61)
        Me.LayoutControlItem4.Text = "* Swift Code"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtIBANNo
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(374, 56)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 20)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(373, 61)
        Me.LayoutControlItem6.Text = "IBAN No."
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(83, 16)
        '
        'Bank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "Bank"
        Me.Size = New System.Drawing.Size(791, 530)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbbrv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSwiftCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCntry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repNumeric, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repTxt50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIBANNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAbbrv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repCntry As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repNumeric As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents repTxt50 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repRem As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtSwiftCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents repState As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repCity As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents txtIBANNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colBranchName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAddr As DevExpress.XtraGrid.Columns.GridColumn

End Class
