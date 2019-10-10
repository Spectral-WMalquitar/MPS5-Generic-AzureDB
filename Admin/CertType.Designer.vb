<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CertType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CertType))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkAllowDuplicate = New DevExpress.XtraEditors.CheckEdit()
        Me.CapGrid = New DevExpress.XtraGrid.GridControl()
        Me.CapView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCapRank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FuncGrid = New DevExpress.XtraGrid.GridControl()
        Me.FuncView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyTravelDoc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFunc = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFuncLevel = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtFileTag = New DevExpress.XtraEditors.TextEdit()
        Me.txtBufferNo = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkAllowDuplicate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCapRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FuncGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FuncView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFunc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFuncLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFileTag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBufferNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(818, 430)
        Me.header.TabIndex = 3
        Me.header.Text = "Certificate Type Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkAllowDuplicate)
        Me.LayoutControl1.Controls.Add(Me.CapGrid)
        Me.LayoutControl1.Controls.Add(Me.FuncGrid)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.txtFileTag)
        Me.LayoutControl1.Controls.Add(Me.txtBufferNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 22)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(814, 406)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkAllowDuplicate
        '
        Me.chkAllowDuplicate.Location = New System.Drawing.Point(645, 70)
        Me.chkAllowDuplicate.Name = "chkAllowDuplicate"
        Me.chkAllowDuplicate.Properties.Caption = "Allow Duplicate"
        Me.chkAllowDuplicate.Size = New System.Drawing.Size(134, 19)
        Me.chkAllowDuplicate.StyleController = Me.LayoutControl1
        Me.chkAllowDuplicate.TabIndex = 10
        '
        'CapGrid
        '
        Me.CapGrid.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton()})
        Me.CapGrid.Location = New System.Drawing.Point(25, 253)
        Me.CapGrid.MainView = Me.CapView
        Me.CapGrid.Name = "CapGrid"
        Me.CapGrid.Padding = New System.Windows.Forms.Padding(10)
        Me.CapGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repCapRank})
        Me.CapGrid.Size = New System.Drawing.Size(764, 113)
        Me.CapGrid.TabIndex = 9
        Me.CapGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CapView})
        '
        'CapView
        '
        Me.CapView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CapView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CapView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CapView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CapView.Appearance.Row.Options.UseTextOptions = True
        Me.CapView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CapView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CapView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CapView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CapView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CapView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CapView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.CapView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn7})
        Me.CapView.GridControl = Me.CapGrid
        Me.CapView.Name = "CapView"
        Me.CapView.NewItemRowText = "Click here to add new Record"
        Me.CapView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.CapView.OptionsBehavior.AutoPopulateColumns = False
        Me.CapView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CapView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.CapView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.CapView.OptionsCustomization.AllowFilter = False
        Me.CapView.OptionsCustomization.AllowGroup = False
        Me.CapView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CapView.OptionsCustomization.AllowSort = False
        Me.CapView.OptionsEditForm.EditFormColumnCount = 2
        Me.CapView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.CapView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.CapView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.CapView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.[False]
        Me.CapView.OptionsFind.AllowFindPanel = False
        Me.CapView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CapView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CapView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CapView.OptionsSelection.UseIndicatorForSelection = False
        Me.CapView.OptionsView.ShowGroupPanel = False
        Me.CapView.ViewCaption = " Other Information"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PKey"
        Me.GridColumn1.FieldName = "PKey"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Capacity"
        Me.GridColumn2.ColumnEdit = Me.repCapRank
        Me.GridColumn2.FieldName = "FKeyCapacity"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 826
        '
        'repCapRank
        '
        Me.repCapRank.AutoHeight = False
        Me.repCapRank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repCapRank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repCapRank.DisplayMember = "Name"
        Me.repCapRank.DropDownRows = 10
        Me.repCapRank.Name = "repCapRank"
        Me.repCapRank.NullText = ""
        Me.repCapRank.ShowFooter = False
        Me.repCapRank.ShowHeader = False
        Me.repCapRank.ValueMember = "PKey"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Edited"
        Me.GridColumn3.FieldName = "Edited"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "ID"
        Me.GridColumn5.FieldName = "FKeyLicCertCapID"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "FKeyDocument"
        Me.GridColumn7.FieldName = "FKeyDocument"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'FuncGrid
        '
        Me.FuncGrid.EmbeddedNavigator.CustomButtons.AddRange(New DevExpress.XtraEditors.NavigatorCustomButton() {New DevExpress.XtraEditors.NavigatorCustomButton()})
        Me.FuncGrid.Location = New System.Drawing.Point(25, 141)
        Me.FuncGrid.MainView = Me.FuncView
        Me.FuncGrid.Name = "FuncGrid"
        Me.FuncGrid.Padding = New System.Windows.Forms.Padding(10)
        Me.FuncGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repFunc, Me.repFuncLevel})
        Me.FuncGrid.Size = New System.Drawing.Size(764, 67)
        Me.FuncGrid.TabIndex = 7
        Me.FuncGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FuncView})
        '
        'FuncView
        '
        Me.FuncView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.FuncView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.FuncView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.FuncView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.FuncView.Appearance.Row.Options.UseTextOptions = True
        Me.FuncView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.FuncView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FuncView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.FuncView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.FuncView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.FuncView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.FuncView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.FuncView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.GridColumn4, Me.colFKeyTravelDoc, Me.GridColumn6, Me.GridColumn8})
        Me.FuncView.GridControl = Me.FuncGrid
        Me.FuncView.Name = "FuncView"
        Me.FuncView.NewItemRowText = "Click here to add new Record"
        Me.FuncView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.FuncView.OptionsBehavior.AutoPopulateColumns = False
        Me.FuncView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.FuncView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.FuncView.OptionsCustomization.AllowFilter = False
        Me.FuncView.OptionsCustomization.AllowGroup = False
        Me.FuncView.OptionsCustomization.AllowQuickHideColumns = False
        Me.FuncView.OptionsCustomization.AllowSort = False
        Me.FuncView.OptionsEditForm.EditFormColumnCount = 2
        Me.FuncView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.FuncView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.FuncView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.FuncView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.[False]
        Me.FuncView.OptionsFind.AllowFindPanel = False
        Me.FuncView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.FuncView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.FuncView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.FuncView.OptionsSelection.UseIndicatorForSelection = False
        Me.FuncView.OptionsView.ShowGroupPanel = False
        Me.FuncView.ViewCaption = " Other Information"
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Document"
        Me.GridColumn4.FieldName = "FKeyDocument"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'colFKeyTravelDoc
        '
        Me.colFKeyTravelDoc.Caption = "Function"
        Me.colFKeyTravelDoc.ColumnEdit = Me.repFunc
        Me.colFKeyTravelDoc.FieldName = "FKeyLicCertFunc"
        Me.colFKeyTravelDoc.Name = "colFKeyTravelDoc"
        Me.colFKeyTravelDoc.Visible = True
        Me.colFKeyTravelDoc.VisibleIndex = 0
        Me.colFKeyTravelDoc.Width = 570
        '
        'repFunc
        '
        Me.repFunc.AutoHeight = False
        Me.repFunc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repFunc.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repFunc.DisplayMember = "Name"
        Me.repFunc.DropDownRows = 10
        Me.repFunc.Name = "repFunc"
        Me.repFunc.NullText = ""
        Me.repFunc.ShowFooter = False
        Me.repFunc.ShowHeader = False
        Me.repFunc.ValueMember = "PKey"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Level"
        Me.GridColumn6.ColumnEdit = Me.repFuncLevel
        Me.GridColumn6.FieldName = "LevelCode"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 340
        '
        'repFuncLevel
        '
        Me.repFuncLevel.AutoHeight = False
        Me.repFuncLevel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repFuncLevel.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repFuncLevel.DisplayMember = "Name"
        Me.repFuncLevel.DropDownRows = 10
        Me.repFuncLevel.Name = "repFuncLevel"
        Me.repFuncLevel.NullText = ""
        Me.repFuncLevel.ShowFooter = False
        Me.repFuncLevel.ShowHeader = False
        Me.repFuncLevel.ValueMember = "PKey"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Edited"
        Me.GridColumn8.FieldName = "Edited"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(33, 68)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(208, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "License / Certificate Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(241, 68)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(134, 20)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'txtFileTag
        '
        Me.txtFileTag.Location = New System.Drawing.Point(509, 68)
        Me.txtFileTag.Name = "txtFileTag"
        Me.txtFileTag.Properties.Mask.EditMask = "[a-zA-Z0-9]{0,5}"
        Me.txtFileTag.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtFileTag.Properties.MaxLength = 5
        Me.txtFileTag.Size = New System.Drawing.Size(134, 20)
        Me.txtFileTag.StyleController = Me.LayoutControl1
        Me.txtFileTag.TabIndex = 4
        Me.txtFileTag.ToolTip = "File Tag"
        '
        'txtBufferNo
        '
        Me.txtBufferNo.EditValue = "0"
        Me.txtBufferNo.Location = New System.Drawing.Point(375, 68)
        Me.txtBufferNo.Name = "txtBufferNo"
        Me.txtBufferNo.Properties.Mask.EditMask = "f"
        Me.txtBufferNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtBufferNo.Size = New System.Drawing.Size(134, 20)
        Me.txtBufferNo.StyleController = Me.LayoutControl1
        Me.txtBufferNo.TabIndex = 4
        Me.txtBufferNo.ToolTip = "SortCode"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3, Me.LayoutControlGroup4, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(814, 406)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(774, 112)
        Me.LayoutControlGroup3.Text = "Certificate Functions"
        Me.LayoutControlGroup3.TextLocation = DevExpress.Utils.Locations.[Default]
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.FuncGrid
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(768, 71)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem6})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10)
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(774, 96)
        Me.LayoutControlGroup4.Text = " "
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.CustomizationFormText = "* License / Certificate Name"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(208, 51)
        Me.LayoutControlItem1.Text = "* License / Certificate Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSortCode
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(208, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(134, 51)
        Me.LayoutControlItem2.Text = "Sort Code"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtFileTag
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(476, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(134, 51)
        Me.LayoutControlItem3.Text = "* DMS File Code"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtBufferNo
        Me.LayoutControlItem9.CustomizationFormText = "Buffer Days"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(342, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(134, 51)
        Me.LayoutControlItem9.Text = "Buffer Days"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.chkAllowDuplicate
        Me.LayoutControlItem6.Location = New System.Drawing.Point(610, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(138, 51)
        Me.LayoutControlItem6.Text = " "
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(134, 13)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 208)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(774, 158)
        Me.LayoutControlGroup2.Text = "Capacity"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.CapGrid
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(768, 117)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'CertType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "CertType"
        Me.Size = New System.Drawing.Size(818, 430)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkAllowDuplicate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCapRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FuncGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FuncView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFunc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFuncLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFileTag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBufferNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CapGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CapView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FuncGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents FuncView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyTravelDoc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repFunc As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFileTag As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repFuncLevel As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repCapRank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkAllowDuplicate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBufferNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem

End Class
