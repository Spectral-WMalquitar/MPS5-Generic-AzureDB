<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rank))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtAbbrv = New DevExpress.XtraEditors.TextEdit()
        Me.txtChineseName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.cboFKeyRankGrp = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboFKeyRankType = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboDeptCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbbrv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtChineseName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyRankGrp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyRankType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDeptCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(858, 401)
        Me.header.TabIndex = 1
        Me.header.Text = "Rank Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtAbbrv)
        Me.LayoutControl1.Controls.Add(Me.txtChineseName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyRankGrp)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyRankType)
        Me.LayoutControl1.Controls.Add(Me.cboDeptCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 22)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(512, 188, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(854, 377)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(20, 138)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Properties.MaxLength = 200
        Me.txtRemarks.Size = New System.Drawing.Size(814, 64)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 8
        Me.txtRemarks.ToolTip = "Remarks"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 36)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 50
        Me.txtName.Size = New System.Drawing.Size(183, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtAbbrv
        '
        Me.txtAbbrv.Location = New System.Drawing.Point(203, 36)
        Me.txtAbbrv.Name = "txtAbbrv"
        Me.txtAbbrv.Properties.MaxLength = 15
        Me.txtAbbrv.Size = New System.Drawing.Size(198, 20)
        Me.txtAbbrv.StyleController = Me.LayoutControl1
        Me.txtAbbrv.TabIndex = 5
        Me.txtAbbrv.ToolTip = "Abbreviation"
        '
        'txtChineseName
        '
        Me.txtChineseName.Location = New System.Drawing.Point(627, 36)
        Me.txtChineseName.Name = "txtChineseName"
        Me.txtChineseName.Properties.MaxLength = 15
        Me.txtChineseName.Size = New System.Drawing.Size(207, 20)
        Me.txtChineseName.StyleController = Me.LayoutControl1
        Me.txtChineseName.TabIndex = 6
        Me.txtChineseName.ToolTip = "Chinese Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(401, 36)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(226, 20)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'cboFKeyRankGrp
        '
        Me.cboFKeyRankGrp.Location = New System.Drawing.Point(401, 87)
        Me.cboFKeyRankGrp.Name = "cboFKeyRankGrp"
        Me.cboFKeyRankGrp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboFKeyRankGrp.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFKeyRankGrp.Properties.DisplayMember = "Name"
        Me.cboFKeyRankGrp.Properties.DropDownRows = 10
        Me.cboFKeyRankGrp.Properties.NullText = ""
        Me.cboFKeyRankGrp.Properties.ShowFooter = False
        Me.cboFKeyRankGrp.Properties.ShowHeader = False
        Me.cboFKeyRankGrp.Properties.ValueMember = "PKey"
        Me.cboFKeyRankGrp.Size = New System.Drawing.Size(226, 20)
        Me.cboFKeyRankGrp.StyleController = Me.LayoutControl1
        Me.cboFKeyRankGrp.TabIndex = 6
        Me.cboFKeyRankGrp.ToolTip = "Rank Group"
        '
        'cboFKeyRankType
        '
        Me.cboFKeyRankType.Location = New System.Drawing.Point(20, 87)
        Me.cboFKeyRankType.Name = "cboFKeyRankType"
        Me.cboFKeyRankType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboFKeyRankType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFKeyRankType.Properties.DisplayMember = "Name"
        Me.cboFKeyRankType.Properties.DropDownRows = 10
        Me.cboFKeyRankType.Properties.NullText = ""
        Me.cboFKeyRankType.Properties.ShowFooter = False
        Me.cboFKeyRankType.Properties.ShowHeader = False
        Me.cboFKeyRankType.Properties.ValueMember = "PKey"
        Me.cboFKeyRankType.Size = New System.Drawing.Size(183, 20)
        Me.cboFKeyRankType.StyleController = Me.LayoutControl1
        Me.cboFKeyRankType.TabIndex = 7
        Me.cboFKeyRankType.ToolTip = "Type"
        '
        'cboDeptCode
        '
        Me.cboDeptCode.Location = New System.Drawing.Point(203, 87)
        Me.cboDeptCode.Name = "cboDeptCode"
        Me.cboDeptCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboDeptCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboDeptCode.Properties.DisplayMember = "Name"
        Me.cboDeptCode.Properties.DropDownRows = 10
        Me.cboDeptCode.Properties.NullText = ""
        Me.cboDeptCode.Properties.ShowFooter = False
        Me.cboDeptCode.Properties.ShowHeader = False
        Me.cboDeptCode.Properties.ValueMember = "PKey"
        Me.cboDeptCode.Size = New System.Drawing.Size(198, 20)
        Me.cboDeptCode.StyleController = Me.LayoutControl1
        Me.cboDeptCode.TabIndex = 7
        Me.cboDeptCode.ToolTip = "Department"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem4, Me.layoutControlItem5, Me.layoutControlItem6, Me.LayoutControlItem9, Me.EmptySpaceItem1, Me.layoutControlItem8, Me.layoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(854, 377)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'layoutControlItem1
        '
        Me.layoutControlItem1.Control = Me.txtName
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.layoutControlItem1.Size = New System.Drawing.Size(183, 51)
        Me.layoutControlItem1.Text = "* Name"
        Me.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(70, 13)
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.Control = Me.txtAbbrv
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(183, 0)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.layoutControlItem2.Size = New System.Drawing.Size(198, 51)
        Me.layoutControlItem2.Text = "* Abbreviation"
        Me.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(70, 13)
        '
        'layoutControlItem3
        '
        Me.layoutControlItem3.Control = Me.txtChineseName
        Me.layoutControlItem3.CustomizationFormText = "layoutControlItem3"
        Me.layoutControlItem3.Location = New System.Drawing.Point(607, 0)
        Me.layoutControlItem3.Name = "layoutControlItem3"
        Me.layoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.layoutControlItem3.Size = New System.Drawing.Size(207, 102)
        Me.layoutControlItem3.Text = "Chinese Name"
        Me.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem3.TextSize = New System.Drawing.Size(70, 13)
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.cboDeptCode
        Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem4.Location = New System.Drawing.Point(183, 51)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.layoutControlItem4.Size = New System.Drawing.Size(198, 51)
        Me.layoutControlItem4.Text = "* Department"
        Me.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(70, 13)
        '
        'layoutControlItem5
        '
        Me.layoutControlItem5.Control = Me.txtSortCode
        Me.layoutControlItem5.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem5.Location = New System.Drawing.Point(381, 0)
        Me.layoutControlItem5.Name = "layoutControlItem5"
        Me.layoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.layoutControlItem5.Size = New System.Drawing.Size(226, 51)
        Me.layoutControlItem5.Text = "Sort Code"
        Me.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem5.TextSize = New System.Drawing.Size(70, 13)
        '
        'layoutControlItem6
        '
        Me.layoutControlItem6.Control = Me.cboFKeyRankGrp
        Me.layoutControlItem6.CustomizationFormText = "layoutControlItem3"
        Me.layoutControlItem6.Location = New System.Drawing.Point(381, 51)
        Me.layoutControlItem6.Name = "layoutControlItem6"
        Me.layoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.layoutControlItem6.Size = New System.Drawing.Size(226, 51)
        Me.layoutControlItem6.Text = "* Group"
        Me.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem6.TextSize = New System.Drawing.Size(70, 13)
        '
        'layoutControlItem8
        '
        Me.layoutControlItem8.Control = Me.cboFKeyRankType
        Me.layoutControlItem8.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem8.Location = New System.Drawing.Point(0, 51)
        Me.layoutControlItem8.Name = "layoutControlItem8"
        Me.layoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.layoutControlItem8.Size = New System.Drawing.Size(183, 51)
        Me.layoutControlItem8.Text = "* Type"
        Me.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.layoutControlItem8.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtRemarks
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(814, 95)
        Me.LayoutControlItem9.Text = "Remarks"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(70, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 197)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(814, 140)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'Rank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "Rank"
        Me.Size = New System.Drawing.Size(858, 401)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbbrv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtChineseName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyRankGrp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyRankType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDeptCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAbbrv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtChineseName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents layoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboFKeyRankGrp As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboFKeyRankType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboDeptCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem

End Class
