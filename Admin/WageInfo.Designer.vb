<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WageInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WageInfo))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.cboDateType = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboFKeyDen = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboFKeyPrd = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDateType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyDen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyPrd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(772, 392)
        Me.header.TabIndex = 7
        Me.header.Text = "Other Wage Items"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.cboDateType)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyDen)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyPrd)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(768, 368)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(384, 36)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(364, 20)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'cboDateType
        '
        Me.cboDateType.Location = New System.Drawing.Point(20, 138)
        Me.cboDateType.Name = "cboDateType"
        Me.cboDateType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboDateType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboDateType.Properties.DisplayMember = "Name"
        Me.cboDateType.Properties.DropDownRows = 2
        Me.cboDateType.Properties.NullText = ""
        Me.cboDateType.Properties.ShowFooter = False
        Me.cboDateType.Properties.ShowHeader = False
        Me.cboDateType.Properties.ValueMember = "PKey"
        Me.cboDateType.Size = New System.Drawing.Size(364, 20)
        Me.cboDateType.StyleController = Me.LayoutControl1
        Me.cboDateType.TabIndex = 4
        Me.cboDateType.ToolTip = "Start / End Date"
        '
        'cboFKeyDen
        '
        Me.cboFKeyDen.Location = New System.Drawing.Point(20, 87)
        Me.cboFKeyDen.Name = "cboFKeyDen"
        Me.cboFKeyDen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboFKeyDen.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFKeyDen.Properties.DisplayMember = "Name"
        Me.cboFKeyDen.Properties.DropDownRows = 10
        Me.cboFKeyDen.Properties.NullText = ""
        Me.cboFKeyDen.Properties.ShowFooter = False
        Me.cboFKeyDen.Properties.ShowHeader = False
        Me.cboFKeyDen.Properties.ValueMember = "PKey"
        Me.cboFKeyDen.Size = New System.Drawing.Size(364, 20)
        Me.cboFKeyDen.StyleController = Me.LayoutControl1
        Me.cboFKeyDen.TabIndex = 4
        Me.cboFKeyDen.ToolTip = "Denomination"
        '
        'cboFKeyPrd
        '
        Me.cboFKeyPrd.Location = New System.Drawing.Point(384, 87)
        Me.cboFKeyPrd.Name = "cboFKeyPrd"
        Me.cboFKeyPrd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboFKeyPrd.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFKeyPrd.Properties.DisplayMember = "Name"
        Me.cboFKeyPrd.Properties.DropDownRows = 10
        Me.cboFKeyPrd.Properties.NullText = ""
        Me.cboFKeyPrd.Properties.ShowFooter = False
        Me.cboFKeyPrd.Properties.ShowHeader = False
        Me.cboFKeyPrd.Properties.ValueMember = "PKey"
        Me.cboFKeyPrd.Size = New System.Drawing.Size(364, 20)
        Me.cboFKeyPrd.StyleController = Me.LayoutControl1
        Me.cboFKeyPrd.TabIndex = 4
        Me.cboFKeyPrd.ToolTip = "Calculation Period"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 36)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 50
        Me.txtName.Size = New System.Drawing.Size(364, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(20, 189)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Properties.MaxLength = 200
        Me.txtRemarks.Size = New System.Drawing.Size(728, 67)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 4
        Me.txtRemarks.ToolTip = "Remarks"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem8, Me.LayoutControlItem4, Me.EmptySpaceItem2, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(768, 368)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(364, 51)
        Me.LayoutControlItem1.Text = "* Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSortCode
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(364, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(364, 51)
        Me.LayoutControlItem2.Text = "Sort Code"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboDateType
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(364, 51)
        Me.LayoutControlItem4.Text = "* Start / End Date"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cboFKeyPrd
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(364, 51)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(364, 51)
        Me.LayoutControlItem8.Text = "Calculation Period"
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboFKeyDen
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(364, 51)
        Me.LayoutControlItem9.Text = "Denomination"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(87, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtRemarks
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 153)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(728, 98)
        Me.LayoutControlItem3.Text = "Remarks"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(87, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(364, 102)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(364, 51)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 251)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(728, 77)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'WageInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "WageInfo"
        Me.Size = New System.Drawing.Size(772, 392)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDateType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyDen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyPrd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboDateType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboFKeyDen As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboFKeyPrd As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem

End Class
