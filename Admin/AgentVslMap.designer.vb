<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgentVslMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgentVslMap))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnRemoveAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAssignAll = New DevExpress.XtraEditors.SimpleButton()
        Me.SelectedGrid = New DevExpress.XtraGrid.GridControl()
        Me.SelectedView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FKeyVsl_Selected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVsl_Selected = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyPrin_Selected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repPrin_Selected = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyFlt_Selected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFlt_Selected = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.SelectionGrid = New DevExpress.XtraGrid.GridControl()
        Me.SelectionView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FKeyVsl_Selection = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVsl_Selection = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyPrin_Selection = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repPrin_Selection = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyFlt_Selection = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFlt_Selection = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SelectedGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVsl_Selected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPrin_Selected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFlt_Selected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectionView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVsl_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPrin_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFlt_Selection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(1036, 410)
        Me.header.TabIndex = 0
        Me.header.Text = "Agent-Vessel Mapping"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnRemoveAll)
        Me.LayoutControl1.Controls.Add(Me.btnAssignAll)
        Me.LayoutControl1.Controls.Add(Me.SelectedGrid)
        Me.LayoutControl1.Controls.Add(Me.SelectionGrid)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(482, 120, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1032, 382)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Location = New System.Drawing.Point(518, 337)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(498, 28)
        Me.btnRemoveAll.StyleController = Me.LayoutControl1
        Me.btnRemoveAll.TabIndex = 8
        Me.btnRemoveAll.Text = "Remove All"
        '
        'btnAssignAll
        '
        Me.btnAssignAll.Location = New System.Drawing.Point(16, 337)
        Me.btnAssignAll.Name = "btnAssignAll"
        Me.btnAssignAll.Size = New System.Drawing.Size(498, 28)
        Me.btnAssignAll.StyleController = Me.LayoutControl1
        Me.btnAssignAll.TabIndex = 7
        Me.btnAssignAll.Text = "Assign All"
        '
        'SelectedGrid
        '
        Me.SelectedGrid.AllowDrop = True
        Me.SelectedGrid.Location = New System.Drawing.Point(518, 105)
        Me.SelectedGrid.MainView = Me.SelectedView
        Me.SelectedGrid.Name = "SelectedGrid"
        Me.SelectedGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repVsl_Selected, Me.repPrin_Selected, Me.repFlt_Selected})
        Me.SelectedGrid.Size = New System.Drawing.Size(498, 228)
        Me.SelectedGrid.TabIndex = 6
        Me.SelectedGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SelectedView})
        '
        'SelectedView
        '
        Me.SelectedView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FKeyVsl_Selected, Me.FKeyPrin_Selected, Me.FKeyFlt_Selected})
        Me.SelectedView.GridControl = Me.SelectedGrid
        Me.SelectedView.Name = "SelectedView"
        Me.SelectedView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SelectedView.OptionsCustomization.AllowSort = False
        Me.SelectedView.OptionsFind.AlwaysVisible = True
        Me.SelectedView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[True]
        Me.SelectedView.OptionsView.ShowIndicator = False
        Me.SelectedView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[True]
        Me.SelectedView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.FKeyVsl_Selected, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'FKeyVsl_Selected
        '
        Me.FKeyVsl_Selected.Caption = "Vessel"
        Me.FKeyVsl_Selected.ColumnEdit = Me.repVsl_Selected
        Me.FKeyVsl_Selected.FieldName = "FKeyVsl"
        Me.FKeyVsl_Selected.Name = "FKeyVsl_Selected"
        Me.FKeyVsl_Selected.OptionsColumn.AllowEdit = False
        Me.FKeyVsl_Selected.OptionsColumn.AllowFocus = False
        Me.FKeyVsl_Selected.OptionsColumn.AllowShowHide = False
        Me.FKeyVsl_Selected.OptionsColumn.FixedWidth = True
        Me.FKeyVsl_Selected.OptionsColumn.ReadOnly = True
        Me.FKeyVsl_Selected.Visible = True
        Me.FKeyVsl_Selected.VisibleIndex = 0
        '
        'repVsl_Selected
        '
        Me.repVsl_Selected.AutoHeight = False
        Me.repVsl_Selected.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repVsl_Selected.DisplayMember = "Name"
        Me.repVsl_Selected.Name = "repVsl_Selected"
        Me.repVsl_Selected.NullText = ""
        Me.repVsl_Selected.ValueMember = "PKey"
        '
        'FKeyPrin_Selected
        '
        Me.FKeyPrin_Selected.Caption = "Principal"
        Me.FKeyPrin_Selected.ColumnEdit = Me.repPrin_Selected
        Me.FKeyPrin_Selected.FieldName = "FKeyPrin"
        Me.FKeyPrin_Selected.Name = "FKeyPrin_Selected"
        Me.FKeyPrin_Selected.OptionsColumn.AllowEdit = False
        Me.FKeyPrin_Selected.OptionsColumn.AllowFocus = False
        Me.FKeyPrin_Selected.OptionsColumn.AllowShowHide = False
        Me.FKeyPrin_Selected.OptionsColumn.FixedWidth = True
        Me.FKeyPrin_Selected.OptionsColumn.ReadOnly = True
        Me.FKeyPrin_Selected.Visible = True
        Me.FKeyPrin_Selected.VisibleIndex = 1
        '
        'repPrin_Selected
        '
        Me.repPrin_Selected.AutoHeight = False
        Me.repPrin_Selected.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repPrin_Selected.DisplayMember = "Name"
        Me.repPrin_Selected.Name = "repPrin_Selected"
        Me.repPrin_Selected.NullText = ""
        Me.repPrin_Selected.ValueMember = "PKey"
        '
        'FKeyFlt_Selected
        '
        Me.FKeyFlt_Selected.Caption = "Fleet"
        Me.FKeyFlt_Selected.ColumnEdit = Me.repFlt_Selected
        Me.FKeyFlt_Selected.FieldName = "FKeyFlt"
        Me.FKeyFlt_Selected.Name = "FKeyFlt_Selected"
        Me.FKeyFlt_Selected.OptionsColumn.AllowEdit = False
        Me.FKeyFlt_Selected.OptionsColumn.AllowFocus = False
        Me.FKeyFlt_Selected.OptionsColumn.AllowShowHide = False
        Me.FKeyFlt_Selected.OptionsColumn.FixedWidth = True
        Me.FKeyFlt_Selected.OptionsColumn.ReadOnly = True
        Me.FKeyFlt_Selected.Visible = True
        Me.FKeyFlt_Selected.VisibleIndex = 2
        '
        'repFlt_Selected
        '
        Me.repFlt_Selected.AutoHeight = False
        Me.repFlt_Selected.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repFlt_Selected.DisplayMember = "Name"
        Me.repFlt_Selected.Name = "repFlt_Selected"
        Me.repFlt_Selected.NullText = ""
        Me.repFlt_Selected.ValueMember = "PKey"
        '
        'SelectionGrid
        '
        Me.SelectionGrid.AllowDrop = True
        Me.SelectionGrid.Location = New System.Drawing.Point(16, 105)
        Me.SelectionGrid.MainView = Me.SelectionView
        Me.SelectionGrid.Name = "SelectionGrid"
        Me.SelectionGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repVsl_Selection, Me.repPrin_Selection, Me.repFlt_Selection})
        Me.SelectionGrid.Size = New System.Drawing.Size(498, 228)
        Me.SelectionGrid.TabIndex = 5
        Me.SelectionGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SelectionView})
        '
        'SelectionView
        '
        Me.SelectionView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FKeyVsl_Selection, Me.FKeyPrin_Selection, Me.FKeyFlt_Selection})
        Me.SelectionView.GridControl = Me.SelectionGrid
        Me.SelectionView.Name = "SelectionView"
        Me.SelectionView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SelectionView.OptionsFind.AlwaysVisible = True
        Me.SelectionView.OptionsPrint.PrintVertLines = False
        Me.SelectionView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.SelectionView.OptionsView.ShowIndicator = False
        Me.SelectionView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.SelectionView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.FKeyVsl_Selection, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'FKeyVsl_Selection
        '
        Me.FKeyVsl_Selection.Caption = "Vessel"
        Me.FKeyVsl_Selection.ColumnEdit = Me.repVsl_Selection
        Me.FKeyVsl_Selection.FieldName = "FKeyVsl"
        Me.FKeyVsl_Selection.Name = "FKeyVsl_Selection"
        Me.FKeyVsl_Selection.OptionsColumn.AllowEdit = False
        Me.FKeyVsl_Selection.OptionsColumn.AllowFocus = False
        Me.FKeyVsl_Selection.OptionsColumn.AllowShowHide = False
        Me.FKeyVsl_Selection.OptionsColumn.FixedWidth = True
        Me.FKeyVsl_Selection.OptionsColumn.ReadOnly = True
        Me.FKeyVsl_Selection.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.FKeyVsl_Selection.Visible = True
        Me.FKeyVsl_Selection.VisibleIndex = 0
        '
        'repVsl_Selection
        '
        Me.repVsl_Selection.AutoHeight = False
        Me.repVsl_Selection.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repVsl_Selection.DisplayMember = "Name"
        Me.repVsl_Selection.Name = "repVsl_Selection"
        Me.repVsl_Selection.NullText = ""
        Me.repVsl_Selection.ValueMember = "PKey"
        '
        'FKeyPrin_Selection
        '
        Me.FKeyPrin_Selection.Caption = "Principal"
        Me.FKeyPrin_Selection.ColumnEdit = Me.repPrin_Selection
        Me.FKeyPrin_Selection.FieldName = "FKeyPrin"
        Me.FKeyPrin_Selection.Name = "FKeyPrin_Selection"
        Me.FKeyPrin_Selection.OptionsColumn.AllowEdit = False
        Me.FKeyPrin_Selection.OptionsColumn.AllowFocus = False
        Me.FKeyPrin_Selection.OptionsColumn.AllowShowHide = False
        Me.FKeyPrin_Selection.OptionsColumn.FixedWidth = True
        Me.FKeyPrin_Selection.OptionsColumn.ReadOnly = True
        Me.FKeyPrin_Selection.Visible = True
        Me.FKeyPrin_Selection.VisibleIndex = 1
        '
        'repPrin_Selection
        '
        Me.repPrin_Selection.AutoHeight = False
        Me.repPrin_Selection.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repPrin_Selection.DisplayMember = "Name"
        Me.repPrin_Selection.Name = "repPrin_Selection"
        Me.repPrin_Selection.NullText = ""
        Me.repPrin_Selection.ValueMember = "PKey"
        '
        'FKeyFlt_Selection
        '
        Me.FKeyFlt_Selection.Caption = "Fleet"
        Me.FKeyFlt_Selection.ColumnEdit = Me.repFlt_Selection
        Me.FKeyFlt_Selection.FieldName = "FKeyFlt"
        Me.FKeyFlt_Selection.Name = "FKeyFlt_Selection"
        Me.FKeyFlt_Selection.OptionsColumn.AllowEdit = False
        Me.FKeyFlt_Selection.OptionsColumn.AllowFocus = False
        Me.FKeyFlt_Selection.OptionsColumn.AllowShowHide = False
        Me.FKeyFlt_Selection.OptionsColumn.FixedWidth = True
        Me.FKeyFlt_Selection.OptionsColumn.ReadOnly = True
        Me.FKeyFlt_Selection.Visible = True
        Me.FKeyFlt_Selection.VisibleIndex = 2
        '
        'repFlt_Selection
        '
        Me.repFlt_Selection.AutoHeight = False
        Me.repFlt_Selection.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repFlt_Selection.DisplayMember = "Name"
        Me.repFlt_Selection.Name = "repFlt_Selection"
        Me.repFlt_Selection.NullText = ""
        Me.repFlt_Selection.ValueMember = "PKey"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(13, 33)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(1006, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1032, 382)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1010, 45)
        Me.LayoutControlItem1.Text = "Agent:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(231, 16)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 45)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1010, 313)
        Me.LayoutControlGroup2.Text = "Assigned Vessel(s)"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SelectionGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(502, 251)
        Me.LayoutControlItem2.Text = "Select a vessel(s) to assign to this agent"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(231, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SelectedGrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(502, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(502, 251)
        Me.LayoutControlItem3.Text = "Assigned Vessel(s)"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(231, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnAssignAll
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 251)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(69, 32)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(502, 32)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnRemoveAll
        Me.LayoutControlItem5.Location = New System.Drawing.Point(502, 251)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(79, 32)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(502, 32)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'AgentVslMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "AgentVslMap"
        Me.Size = New System.Drawing.Size(1036, 410)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SelectedGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectedView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVsl_Selected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPrin_Selected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFlt_Selected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectionView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVsl_Selection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPrin_Selection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFlt_Selection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SelectedGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SelectedView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FKeyVsl_Selected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyPrin_Selected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyFlt_Selected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SelectionGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SelectionView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FKeyVsl_Selection As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyPrin_Selection As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyFlt_Selection As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents repVsl_Selection As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repVsl_Selected As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repPrin_Selected As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repFlt_Selected As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repPrin_Selection As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repFlt_Selection As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnRemoveAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAssignAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem

End Class
