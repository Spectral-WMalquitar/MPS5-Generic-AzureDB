<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MinCrew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MinCrew))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyMinCrew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRankCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRankCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colDateUpdated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRankCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(618, 332)
        Me.header.TabIndex = 3
        Me.header.Text = "Safe Manning Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(614, 308)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(25, 96)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repRankCode})
        Me.MainGrid.Size = New System.Drawing.Size(564, 187)
        Me.MainGrid.TabIndex = 5
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.colFKeyMinCrew, Me.colRankName, Me.colRankCode, Me.colDateUpdated, Me.colLastUpdatedBy, Me.colEdited})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new Record"
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsFind.AllowFindPanel = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.ViewCaption = " Other Information"
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colFKeyMinCrew
        '
        Me.colFKeyMinCrew.FieldName = "FKeyMinCrew"
        Me.colFKeyMinCrew.Name = "colFKeyMinCrew"
        '
        'colRankName
        '
        Me.colRankName.FieldName = "Rank"
        Me.colRankName.Name = "colRankName"
        '
        'colRankCode
        '
        Me.colRankCode.Caption = "Rank"
        Me.colRankCode.ColumnEdit = Me.repRankCode
        Me.colRankCode.FieldName = "FKeyRank"
        Me.colRankCode.Name = "colRankCode"
        Me.colRankCode.Visible = True
        Me.colRankCode.VisibleIndex = 0
        '
        'repRankCode
        '
        Me.repRankCode.AutoHeight = False
        Me.repRankCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repRankCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 34, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Rank Name", 37, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Abbreviation", 39, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)})
        Me.repRankCode.DisplayMember = "Name"
        Me.repRankCode.DropDownRows = 10
        Me.repRankCode.Name = "repRankCode"
        Me.repRankCode.NullText = ""
        Me.repRankCode.ShowFooter = False
        Me.repRankCode.ValueMember = "PKey"
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
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 36)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 100
        Me.txtName.Size = New System.Drawing.Size(287, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(307, 36)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(287, 20)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem1, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(614, 308)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtName
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(287, 51)
        Me.LayoutControlItem2.Text = "* Name"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtSortCode
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(287, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(287, 51)
        Me.LayoutControlItem1.Text = "Sort Code"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(574, 217)
        Me.LayoutControlGroup2.Text = "Rank"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.MainGrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(568, 191)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'MinCrew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "MinCrew"
        Me.Size = New System.Drawing.Size(618, 332)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRankCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyMinCrew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRankCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repRankCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem

End Class
