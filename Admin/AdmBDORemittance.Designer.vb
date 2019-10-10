<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdmBDORemittance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdmBDORemittance))
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkUseCustomPassword = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUseFixedPassword = New DevExpress.XtraEditors.CheckEdit()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BankCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyBank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repBank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.CharLength = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdResetBatchNo = New System.Windows.Forms.Button()
        Me.txtFixedPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtNextBatchNo = New DevExpress.XtraEditors.TextEdit()
        Me.txtLocatorCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtShortCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkUseCustomPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseFixedPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFixedPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNextBatchNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocatorCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtShortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1144, 572)
        Me.header.TabIndex = 0
        Me.header.Text = "BDO Remittance System"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkUseCustomPassword)
        Me.LayoutControl1.Controls.Add(Me.chkUseFixedPassword)
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
        Me.LayoutControl1.Controls.Add(Me.cmdResetBatchNo)
        Me.LayoutControl1.Controls.Add(Me.txtFixedPassword)
        Me.LayoutControl1.Controls.Add(Me.txtNextBatchNo)
        Me.LayoutControl1.Controls.Add(Me.txtLocatorCode)
        Me.LayoutControl1.Controls.Add(Me.txtShortCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 24)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(780, 392, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1140, 546)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkUseCustomPassword
        '
        Me.chkUseCustomPassword.Location = New System.Drawing.Point(264, 159)
        Me.chkUseCustomPassword.Name = "chkUseCustomPassword"
        Me.chkUseCustomPassword.Properties.Caption = "Set User to Provide Password"
        Me.chkUseCustomPassword.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chkUseCustomPassword.Properties.RadioGroupIndex = 1
        Me.chkUseCustomPassword.Size = New System.Drawing.Size(191, 20)
        Me.chkUseCustomPassword.StyleController = Me.LayoutControl1
        Me.chkUseCustomPassword.TabIndex = 11
        Me.chkUseCustomPassword.TabStop = False
        '
        'chkUseFixedPassword
        '
        Me.chkUseFixedPassword.Location = New System.Drawing.Point(264, 133)
        Me.chkUseFixedPassword.Name = "chkUseFixedPassword"
        Me.chkUseFixedPassword.Properties.Caption = "Use Fixed Password"
        Me.chkUseFixedPassword.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.chkUseFixedPassword.Properties.RadioGroupIndex = 1
        Me.chkUseFixedPassword.Size = New System.Drawing.Size(185, 20)
        Me.chkUseFixedPassword.StyleController = Me.LayoutControl1
        Me.chkUseFixedPassword.TabIndex = 10
        Me.chkUseFixedPassword.TabStop = False
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(24, 232)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repBank})
        Me.MainGrid.Size = New System.Drawing.Size(1092, 290)
        Me.MainGrid.TabIndex = 9
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Edited, Me.BankCode, Me.FKeyBank, Me.CharLength})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        Me.Edited.OptionsColumn.AllowSize = False
        '
        'BankCode
        '
        Me.BankCode.Caption = "Bank Code"
        Me.BankCode.FieldName = "BankCode"
        Me.BankCode.Name = "BankCode"
        Me.BankCode.OptionsColumn.AllowFocus = False
        Me.BankCode.OptionsColumn.AllowSize = False
        Me.BankCode.OptionsColumn.ReadOnly = True
        Me.BankCode.Visible = True
        Me.BankCode.VisibleIndex = 0
        '
        'FKeyBank
        '
        Me.FKeyBank.Caption = "Bank from MPS Admin"
        Me.FKeyBank.ColumnEdit = Me.repBank
        Me.FKeyBank.FieldName = "FKeyBank"
        Me.FKeyBank.Name = "FKeyBank"
        Me.FKeyBank.OptionsColumn.AllowSize = False
        Me.FKeyBank.Visible = True
        Me.FKeyBank.VisibleIndex = 1
        '
        'repBank
        '
        Me.repBank.AutoHeight = False
        Me.repBank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "Clear", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.repBank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repBank.DisplayMember = "Name"
        Me.repBank.Name = "repBank"
        Me.repBank.NullText = ""
        Me.repBank.ShowFooter = False
        Me.repBank.ShowHeader = False
        Me.repBank.ValueMember = "PKey"
        '
        'CharLength
        '
        Me.CharLength.AppearanceCell.Options.UseTextOptions = True
        Me.CharLength.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CharLength.Caption = "CA/SA Length"
        Me.CharLength.FieldName = "CharLength"
        Me.CharLength.Name = "CharLength"
        Me.CharLength.OptionsColumn.AllowSize = False
        Me.CharLength.OptionsColumn.ReadOnly = True
        Me.CharLength.ToolTip = "Account No. Length"
        Me.CharLength.Visible = True
        Me.CharLength.VisibleIndex = 2
        '
        'cmdResetBatchNo
        '
        Me.cmdResetBatchNo.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.cmdResetBatchNo.Location = New System.Drawing.Point(777, 92)
        Me.cmdResetBatchNo.Name = "cmdResetBatchNo"
        Me.cmdResetBatchNo.Size = New System.Drawing.Size(111, 21)
        Me.cmdResetBatchNo.TabIndex = 8
        Me.cmdResetBatchNo.Text = "Reset"
        Me.cmdResetBatchNo.UseVisualStyleBackColor = True
        '
        'txtFixedPassword
        '
        Me.txtFixedPassword.Location = New System.Drawing.Point(516, 133)
        Me.txtFixedPassword.Name = "txtFixedPassword"
        Me.txtFixedPassword.Size = New System.Drawing.Size(372, 22)
        Me.txtFixedPassword.StyleController = Me.LayoutControl1
        Me.txtFixedPassword.TabIndex = 7
        '
        'txtNextBatchNo
        '
        Me.txtNextBatchNo.Location = New System.Drawing.Point(419, 92)
        Me.txtNextBatchNo.Name = "txtNextBatchNo"
        Me.txtNextBatchNo.Size = New System.Drawing.Size(354, 22)
        Me.txtNextBatchNo.StyleController = Me.LayoutControl1
        Me.txtNextBatchNo.TabIndex = 6
        '
        'txtLocatorCode
        '
        Me.txtLocatorCode.Location = New System.Drawing.Point(419, 52)
        Me.txtLocatorCode.Name = "txtLocatorCode"
        Me.txtLocatorCode.Size = New System.Drawing.Size(469, 22)
        Me.txtLocatorCode.StyleController = Me.LayoutControl1
        Me.txtLocatorCode.TabIndex = 5
        '
        'txtShortCode
        '
        Me.txtShortCode.Location = New System.Drawing.Point(419, 12)
        Me.txtShortCode.Name = "txtShortCode"
        Me.txtShortCode.Size = New System.Drawing.Size(469, 22)
        Me.txtShortCode.StyleController = Me.LayoutControl1
        Me.txtShortCode.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.LayoutControlItem2, Me.EmptySpaceItem3, Me.LayoutControlItem3, Me.EmptySpaceItem4, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem5, Me.EmptySpaceItem6, Me.EmptySpaceItem7, Me.LayoutControlGroup2, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1140, 546)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtShortCode
        Me.LayoutControlItem1.Location = New System.Drawing.Point(252, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(628, 26)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(628, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(628, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Tie-up Short Code:"
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(150, 20)
        Me.LayoutControlItem1.TextToControlDistance = 5
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(252, 26)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 14)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(9, 14)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(628, 14)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtLocatorCode
        Me.LayoutControlItem2.Location = New System.Drawing.Point(252, 40)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(628, 26)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(628, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(628, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Locator Code:"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(150, 16)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(252, 66)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(0, 14)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(9, 14)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(628, 14)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtNextBatchNo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(252, 80)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(513, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(513, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(513, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Next Batch No.:"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(150, 20)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(252, 106)
        Me.EmptySpaceItem4.MaxSize = New System.Drawing.Size(0, 15)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(10, 15)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(628, 15)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtFixedPassword
        Me.LayoutControlItem4.Location = New System.Drawing.Point(441, 121)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(439, 26)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(439, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(439, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Password:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(60, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdResetBatchNo
        Me.LayoutControlItem5.Location = New System.Drawing.Point(765, 80)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(115, 25)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(115, 25)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(115, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(252, 186)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(880, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(240, 186)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(252, 171)
        Me.EmptySpaceItem7.MaxSize = New System.Drawing.Size(0, 15)
        Me.EmptySpaceItem7.MinSize = New System.Drawing.Size(10, 15)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(628, 15)
        Me.EmptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 186)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1120, 340)
        Me.LayoutControlGroup2.Text = "Bank Codes:"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.MainGrid
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1096, 294)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkUseFixedPassword
        Me.LayoutControlItem7.Location = New System.Drawing.Point(252, 121)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(189, 26)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(189, 26)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(189, 26)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.chkUseCustomPassword
        Me.LayoutControlItem8.Location = New System.Drawing.Point(252, 147)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(195, 24)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(195, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(195, 24)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(447, 147)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(433, 24)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(433, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(433, 24)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'AdmBDORemittance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "AdmBDORemittance"
        Me.Size = New System.Drawing.Size(1144, 572)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkUseCustomPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseFixedPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFixedPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNextBatchNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocatorCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtShortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtNextBatchNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLocatorCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtShortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdResetBatchNo As System.Windows.Forms.Button
    Friend WithEvents txtFixedPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkUseCustomPassword As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUseFixedPassword As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BankCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyBank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CharLength As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repBank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

End Class
