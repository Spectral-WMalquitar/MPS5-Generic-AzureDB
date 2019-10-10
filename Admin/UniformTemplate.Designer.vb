<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UniformTemplate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UniformTemplate))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SubGrid = New DevExpress.XtraGrid.GridControl()
        Me.SubGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyGarmentTemplate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyGarment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repGarment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSortCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SubGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repGarment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSpinEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(673, 596)
        Me.header.TabIndex = 1
        Me.header.Text = "Rank Group Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SubGrid)
        Me.LayoutControl1.Controls.Add(Me.MemoEdit1)
        Me.LayoutControl1.Controls.Add(Me.txtDescription)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(694, 256, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(669, 568)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SubGrid
        '
        GridLevelNode1.RelationName = "Level1"
        Me.SubGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.SubGrid.Location = New System.Drawing.Point(22, 249)
        Me.SubGrid.MainView = Me.SubGridView
        Me.SubGrid.Name = "SubGrid"
        Me.SubGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repGarment, Me.repSpinEdit})
        Me.SubGrid.Size = New System.Drawing.Size(625, 163)
        Me.SubGrid.TabIndex = 7
        Me.SubGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SubGridView})
        '
        'SubGridView
        '
        Me.SubGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Edited, Me.colPKey, Me.colFKeyGarmentTemplate, Me.colFKeyGarment, Me.colSortCode, Me.colQty})
        Me.SubGridView.GridControl = Me.SubGrid
        Me.SubGridView.Name = "SubGridView"
        Me.SubGridView.OptionsView.ColumnAutoWidth = False
        Me.SubGridView.OptionsView.ShowGroupPanel = False
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'colPKey
        '
        Me.colPKey.Caption = "PKey"
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colFKeyGarmentTemplate
        '
        Me.colFKeyGarmentTemplate.Caption = "FKeyGarmentTemplate"
        Me.colFKeyGarmentTemplate.FieldName = "FKeyGarmentTemplate"
        Me.colFKeyGarmentTemplate.Name = "colFKeyGarmentTemplate"
        '
        'colFKeyGarment
        '
        Me.colFKeyGarment.Caption = "Garment"
        Me.colFKeyGarment.ColumnEdit = Me.repGarment
        Me.colFKeyGarment.FieldName = "FKeyGarment"
        Me.colFKeyGarment.Name = "colFKeyGarment"
        Me.colFKeyGarment.Visible = True
        Me.colFKeyGarment.VisibleIndex = 0
        Me.colFKeyGarment.Width = 223
        '
        'repGarment
        '
        Me.repGarment.AutoHeight = False
        Me.repGarment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)})
        Me.repGarment.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GarmentType", "Garment Type"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PhotoPath", "PhotoPath", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.repGarment.DisplayMember = "Name"
        Me.repGarment.Name = "repGarment"
        Me.repGarment.NullText = ""
        Me.repGarment.ValueMember = "PKey"
        '
        'colSortCode
        '
        Me.colSortCode.Caption = "Sort Code"
        Me.colSortCode.FieldName = "SortCode"
        Me.colSortCode.Name = "colSortCode"
        '
        'colQty
        '
        Me.colQty.Caption = "Quantity"
        Me.colQty.ColumnEdit = Me.repSpinEdit
        Me.colQty.DisplayFormat.FormatString = "d"
        Me.colQty.FieldName = "Qty"
        Me.colQty.Name = "colQty"
        Me.colQty.Visible = True
        Me.colQty.VisibleIndex = 1
        Me.colQty.Width = 115
        '
        'repSpinEdit
        '
        Me.repSpinEdit.AutoHeight = False
        Me.repSpinEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repSpinEdit.DisplayFormat.FormatString = "d"
        Me.repSpinEdit.EditFormat.FormatString = "d"
        Me.repSpinEdit.Mask.EditMask = "d"
        Me.repSpinEdit.MaxValue = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.repSpinEdit.Name = "repSpinEdit"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(93, 164)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(554, 81)
        Me.MemoEdit1.StyleController = Me.LayoutControl1
        Me.MemoEdit1.TabIndex = 6
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(93, 78)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(554, 82)
        Me.txtDescription.StyleController = Me.LayoutControl1
        Me.txtDescription.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 39)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 30
        Me.txtName.Size = New System.Drawing.Size(319, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(339, 39)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(310, 22)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(669, 568)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(319, 56)
        Me.LayoutControlItem1.Text = "* Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(68, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSortCode
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(319, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(310, 56)
        Me.LayoutControlItem2.Text = "Sort Code"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(68, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtDescription
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 86)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(127, 86)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(629, 86)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Description:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(68, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 394)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(629, 134)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.MemoEdit1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 142)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 85)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(128, 85)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(629, 85)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Remarks:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(68, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SubGrid
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 227)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(629, 167)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'UniformTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "UniformTemplate"
        Me.Size = New System.Drawing.Size(673, 596)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SubGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repGarment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSpinEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SubGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SubGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyGarmentTemplate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyGarment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repGarment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colSortCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

End Class
