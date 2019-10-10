<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Garment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Garment))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CheckEdit_None = New DevExpress.XtraEditors.CheckEdit()
        Me.txtReIssueEveryPeriodMonth = New DevExpress.XtraEditors.SpinEdit()
        Me.txtReIssueEveryPeriodYr = New DevExpress.XtraEditors.SpinEdit()
        Me.chkReIssueEveryPeriod = New DevExpress.XtraEditors.CheckEdit()
        Me.chkReIssueEverySignOn = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdDeletePhoto = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.GarmentPhoto = New DevExpress.XtraEditors.PictureEdit()
        Me.cboFKeyGarmentType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_ReIssue = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckEdit_None.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReIssueEveryPeriodMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReIssueEveryPeriodYr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkReIssueEveryPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkReIssueEverySignOn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GarmentPhoto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyGarmentType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_ReIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(880, 662)
        Me.header.TabIndex = 1
        Me.header.Text = "Rank Group Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CheckEdit_None)
        Me.LayoutControl1.Controls.Add(Me.txtReIssueEveryPeriodMonth)
        Me.LayoutControl1.Controls.Add(Me.txtReIssueEveryPeriodYr)
        Me.LayoutControl1.Controls.Add(Me.chkReIssueEveryPeriod)
        Me.LayoutControl1.Controls.Add(Me.chkReIssueEverySignOn)
        Me.LayoutControl1.Controls.Add(Me.cmdDeletePhoto)
        Me.LayoutControl1.Controls.Add(Me.cmdBrowse)
        Me.LayoutControl1.Controls.Add(Me.GarmentPhoto)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyGarmentType)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1044, 314, 503, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(876, 634)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CheckEdit_None
        '
        Me.CheckEdit_None.Location = New System.Drawing.Point(34, 151)
        Me.CheckEdit_None.Name = "CheckEdit_None"
        Me.CheckEdit_None.Properties.Caption = "None"
        Me.CheckEdit_None.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.CheckEdit_None.Properties.RadioGroupIndex = 1
        Me.CheckEdit_None.Size = New System.Drawing.Size(396, 20)
        Me.CheckEdit_None.StyleController = Me.LayoutControl1
        Me.CheckEdit_None.TabIndex = 13
        Me.CheckEdit_None.TabStop = False
        '
        'txtReIssueEveryPeriodMonth
        '
        Me.txtReIssueEveryPeriodMonth.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtReIssueEveryPeriodMonth.Location = New System.Drawing.Point(209, 223)
        Me.txtReIssueEveryPeriodMonth.Name = "txtReIssueEveryPeriodMonth"
        Me.txtReIssueEveryPeriodMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtReIssueEveryPeriodMonth.Properties.DisplayFormat.FormatString = "d"
        Me.txtReIssueEveryPeriodMonth.Properties.Mask.EditMask = "d"
        Me.txtReIssueEveryPeriodMonth.Properties.MaxValue = New Decimal(New Integer() {12, 0, 0, 0})
        Me.txtReIssueEveryPeriodMonth.Size = New System.Drawing.Size(50, 22)
        Me.txtReIssueEveryPeriodMonth.StyleController = Me.LayoutControl1
        Me.txtReIssueEveryPeriodMonth.TabIndex = 12
        '
        'txtReIssueEveryPeriodYr
        '
        Me.txtReIssueEveryPeriodYr.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtReIssueEveryPeriodYr.Location = New System.Drawing.Point(108, 223)
        Me.txtReIssueEveryPeriodYr.Name = "txtReIssueEveryPeriodYr"
        Me.txtReIssueEveryPeriodYr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtReIssueEveryPeriodYr.Properties.DisplayFormat.FormatString = "d"
        Me.txtReIssueEveryPeriodYr.Properties.Mask.EditMask = "d"
        Me.txtReIssueEveryPeriodYr.Properties.MaxValue = New Decimal(New Integer() {50, 0, 0, 0})
        Me.txtReIssueEveryPeriodYr.Size = New System.Drawing.Size(52, 22)
        Me.txtReIssueEveryPeriodYr.StyleController = Me.LayoutControl1
        Me.txtReIssueEveryPeriodYr.TabIndex = 11
        '
        'chkReIssueEveryPeriod
        '
        Me.chkReIssueEveryPeriod.Location = New System.Drawing.Point(34, 199)
        Me.chkReIssueEveryPeriod.Name = "chkReIssueEveryPeriod"
        Me.chkReIssueEveryPeriod.Properties.Caption = "Periodical"
        Me.chkReIssueEveryPeriod.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chkReIssueEveryPeriod.Properties.RadioGroupIndex = 1
        Me.chkReIssueEveryPeriod.Size = New System.Drawing.Size(396, 20)
        Me.chkReIssueEveryPeriod.StyleController = Me.LayoutControl1
        Me.chkReIssueEveryPeriod.TabIndex = 10
        Me.chkReIssueEveryPeriod.TabStop = False
        '
        'chkReIssueEverySignOn
        '
        Me.chkReIssueEverySignOn.Location = New System.Drawing.Point(34, 175)
        Me.chkReIssueEverySignOn.Name = "chkReIssueEverySignOn"
        Me.chkReIssueEverySignOn.Properties.Caption = "Every Sign On"
        Me.chkReIssueEverySignOn.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chkReIssueEverySignOn.Properties.RadioGroupIndex = 1
        Me.chkReIssueEverySignOn.Size = New System.Drawing.Size(396, 20)
        Me.chkReIssueEverySignOn.StyleController = Me.LayoutControl1
        Me.chkReIssueEverySignOn.TabIndex = 9
        Me.chkReIssueEverySignOn.TabStop = False
        '
        'cmdDeletePhoto
        '
        Me.cmdDeletePhoto.Location = New System.Drawing.Point(446, 404)
        Me.cmdDeletePhoto.Name = "cmdDeletePhoto"
        Me.cmdDeletePhoto.Size = New System.Drawing.Size(408, 23)
        Me.cmdDeletePhoto.StyleController = Me.LayoutControl1
        Me.cmdDeletePhoto.TabIndex = 8
        Me.cmdDeletePhoto.Text = "Delete"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(446, 377)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(408, 23)
        Me.cmdBrowse.StyleController = Me.LayoutControl1
        Me.cmdBrowse.TabIndex = 7
        Me.cmdBrowse.Text = "Browse"
        '
        'GarmentPhoto
        '
        Me.GarmentPhoto.Location = New System.Drawing.Point(446, 97)
        Me.GarmentPhoto.Name = "GarmentPhoto"
        Me.GarmentPhoto.Properties.ShowMenu = False
        Me.GarmentPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.GarmentPhoto.Size = New System.Drawing.Size(408, 276)
        Me.GarmentPhoto.StyleController = Me.LayoutControl1
        Me.GarmentPhoto.TabIndex = 6
        '
        'cboFKeyGarmentType
        '
        Me.cboFKeyGarmentType.Location = New System.Drawing.Point(119, 78)
        Me.cboFKeyGarmentType.Name = "cboFKeyGarmentType"
        Me.cboFKeyGarmentType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFKeyGarmentType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFKeyGarmentType.Properties.DisplayMember = "Name"
        Me.cboFKeyGarmentType.Properties.NullText = ""
        Me.cboFKeyGarmentType.Properties.ShowFooter = False
        Me.cboFKeyGarmentType.Properties.ShowHeader = False
        Me.cboFKeyGarmentType.Properties.ValueMember = "PKey"
        Me.cboFKeyGarmentType.Size = New System.Drawing.Size(323, 22)
        Me.cboFKeyGarmentType.StyleController = Me.LayoutControl1
        Me.cboFKeyGarmentType.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 39)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 30
        Me.txtName.Size = New System.Drawing.Size(424, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(444, 39)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(412, 22)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem3, Me.LayoutControlGroup_ReIssue, Me.EmptySpaceItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(876, 634)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(424, 56)
        Me.LayoutControlItem1.Text = "* Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(94, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSortCode
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(424, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(412, 56)
        Me.LayoutControlItem2.Text = "Sort Code"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(94, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GarmentPhoto
        Me.LayoutControlItem4.Location = New System.Drawing.Point(424, 56)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(412, 299)
        Me.LayoutControlItem4.Text = "Photo:"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(94, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboFKeyGarmentType
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(424, 39)
        Me.LayoutControlItem3.Text = "*Garment Type:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(94, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdBrowse
        Me.LayoutControlItem5.Location = New System.Drawing.Point(424, 355)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(412, 27)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdDeletePhoto
        Me.LayoutControlItem6.Location = New System.Drawing.Point(424, 382)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(412, 27)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 239)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(424, 355)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_ReIssue
        '
        Me.LayoutControlGroup_ReIssue.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_ReIssue.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_ReIssue.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem1, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.EmptySpaceItem2, Me.LayoutControlItem11})
        Me.LayoutControlGroup_ReIssue.Location = New System.Drawing.Point(0, 95)
        Me.LayoutControlGroup_ReIssue.Name = "LayoutControlGroup_ReIssue"
        Me.LayoutControlGroup_ReIssue.Size = New System.Drawing.Size(424, 144)
        Me.LayoutControlGroup_ReIssue.Text = "Validity"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkReIssueEverySignOn
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(400, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.chkReIssueEveryPeriod
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(400, 24)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(38, 0)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(38, 10)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(38, 26)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtReIssueEveryPeriodYr
        Me.LayoutControlItem9.Location = New System.Drawing.Point(38, 72)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(92, 26)
        Me.LayoutControlItem9.Text = "Year:"
        Me.LayoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(31, 16)
        Me.LayoutControlItem9.TextToControlDistance = 5
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtReIssueEveryPeriodMonth
        Me.LayoutControlItem10.Location = New System.Drawing.Point(130, 72)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(99, 26)
        Me.LayoutControlItem10.Text = "Month:"
        Me.LayoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(40, 16)
        Me.LayoutControlItem10.TextToControlDistance = 5
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(229, 72)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(171, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.CheckEdit_None
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(400, 24)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(424, 409)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(412, 185)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'Garment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "Garment"
        Me.Size = New System.Drawing.Size(880, 662)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CheckEdit_None.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReIssueEveryPeriodMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReIssueEveryPeriodYr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkReIssueEveryPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkReIssueEverySignOn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GarmentPhoto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyGarmentType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_ReIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboFKeyGarmentType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GarmentPhoto As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdDeletePhoto As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtReIssueEveryPeriodMonth As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtReIssueEveryPeriodYr As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chkReIssueEveryPeriod As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkReIssueEverySignOn As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup_ReIssue As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents CheckEdit_None As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem

End Class
