<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transfer
    Inherits BaseControl.BaseControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Transfer))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboVessel = New DevExpress.XtraEditors.LookUpEdit()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrentVessel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateSOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GenericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.PlaceSOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PortEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyVessel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VesselEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DateSON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PlaceSON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuCurWScaleRank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyWScaleRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuWScaleRank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.deDateSOFF = New DevExpress.XtraEditors.DateEdit()
        Me.cboPlaceSON = New DevExpress.XtraEditors.LookUpEdit()
        Me.deDateSON = New DevExpress.XtraEditors.DateEdit()
        Me.cboPlaceSOFF = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboNewVessel = New DevExpress.XtraEditors.LookUpEdit()
        Me.LCGTransfer = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.grpTRANS = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VesselEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuCurWScaleRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuWScaleRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSOFF.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSOFF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPlaceSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPlaceSOFF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNewVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LCGTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpTRANS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Controls.Add(Me.Label1)
        Me.LayoutControl1.Controls.Add(Me.cboVessel)
        Me.LayoutControl1.Controls.Add(Me.Maingrid)
        Me.LayoutControl1.Controls.Add(Me.deDateSOFF)
        Me.LayoutControl1.Controls.Add(Me.cboPlaceSON)
        Me.LayoutControl1.Controls.Add(Me.deDateSON)
        Me.LayoutControl1.Controls.Add(Me.cboPlaceSOFF)
        Me.LayoutControl1.Controls.Add(Me.cboNewVessel)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
        Me.LayoutControl1.Root = Me.LCGTransfer
        Me.LayoutControl1.Size = New System.Drawing.Size(1158, 526)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(14, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1130, 19)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Select the current vessel to populate the crew list"
        '
        'cboVessel
        '
        Me.cboVessel.Location = New System.Drawing.Point(106, 67)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVessel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboVessel.Properties.DisplayMember = "Name"
        Me.cboVessel.Properties.NullText = ""
        Me.cboVessel.Properties.ShowFooter = False
        Me.cboVessel.Properties.ShowHeader = False
        Me.cboVessel.Properties.ValueMember = "PKey"
        Me.cboVessel.Size = New System.Drawing.Size(466, 22)
        Me.cboVessel.StyleController = Me.LayoutControl1
        Me.cboVessel.TabIndex = 0
        '
        'Maingrid
        '
        Me.Maingrid.AllowDrop = True
        Me.Maingrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.RelationName = "Level1"
        Me.Maingrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.Maingrid.Location = New System.Drawing.Point(2, 172)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PortEdit, Me.VesselEdit, Me.GenericDateEdit, Me.lkuWScaleRank, Me.lkuCurWScaleRank})
        Me.Maingrid.Size = New System.Drawing.Size(1154, 352)
        Me.Maingrid.TabIndex = 34
        Me.Maingrid.ToolTipController = Me.ToolTipController1
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDNbr, Me.CurrActID, Me.CrewName, Me.CurrentVessel, Me.DateSOFF, Me.PlaceSOFF, Me.FKeyVessel, Me.DateSON, Me.PlaceSON, Me.GridColumn1, Me.GridColumn2, Me.FKeyWScaleRank, Me.Remarks})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsCustomization.AllowGroup = False
        Me.Mainview.OptionsCustomization.AllowQuickHideColumns = False
        Me.Mainview.OptionsFind.AllowFindPanel = False
        Me.Mainview.OptionsMenu.EnableColumnMenu = False
        Me.Mainview.OptionsMenu.EnableFooterMenu = False
        Me.Mainview.OptionsMenu.EnableGroupPanelMenu = False
        Me.Mainview.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsSelection.MultiSelect = True
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'IDNbr
        '
        Me.IDNbr.FieldName = "IDNbr"
        Me.IDNbr.Name = "IDNbr"
        '
        'CurrActID
        '
        Me.CurrActID.FieldName = "CurrActID"
        Me.CurrActID.Name = "CurrActID"
        '
        'CrewName
        '
        Me.CrewName.Caption = "Crew Name"
        Me.CrewName.FieldName = "Crew"
        Me.CrewName.Name = "CrewName"
        Me.CrewName.OptionsColumn.AllowEdit = False
        Me.CrewName.OptionsColumn.AllowFocus = False
        Me.CrewName.OptionsColumn.ReadOnly = True
        Me.CrewName.Visible = True
        Me.CrewName.VisibleIndex = 0
        '
        'CurrentVessel
        '
        Me.CurrentVessel.Caption = "Current Vessel"
        Me.CurrentVessel.FieldName = "CurrentVessel"
        Me.CurrentVessel.Name = "CurrentVessel"
        Me.CurrentVessel.OptionsColumn.AllowEdit = False
        Me.CurrentVessel.OptionsColumn.AllowFocus = False
        Me.CurrentVessel.OptionsColumn.ReadOnly = True
        Me.CurrentVessel.Tag = ""
        Me.CurrentVessel.Visible = True
        Me.CurrentVessel.VisibleIndex = 1
        '
        'DateSOFF
        '
        Me.DateSOFF.Caption = "Date Sign-off"
        Me.DateSOFF.ColumnEdit = Me.GenericDateEdit
        Me.DateSOFF.FieldName = "DateSOFF"
        Me.DateSOFF.Name = "DateSOFF"
        Me.DateSOFF.Tag = "Required"
        Me.DateSOFF.Visible = True
        Me.DateSOFF.VisibleIndex = 2
        '
        'GenericDateEdit
        '
        Me.GenericDateEdit.AutoHeight = False
        Me.GenericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.GenericDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.GenericDateEdit.Name = "GenericDateEdit"
        '
        'PlaceSOFF
        '
        Me.PlaceSOFF.Caption = "Place Sign-off"
        Me.PlaceSOFF.ColumnEdit = Me.PortEdit
        Me.PlaceSOFF.FieldName = "PlaceSOFF"
        Me.PlaceSOFF.Name = "PlaceSOFF"
        Me.PlaceSOFF.Tag = "Required"
        Me.PlaceSOFF.Visible = True
        Me.PlaceSOFF.VisibleIndex = 3
        '
        'PortEdit
        '
        Me.PortEdit.AutoHeight = False
        Me.PortEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PortEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.PortEdit.DisplayMember = "Name"
        Me.PortEdit.Name = "PortEdit"
        Me.PortEdit.NullText = ""
        Me.PortEdit.ShowFooter = False
        Me.PortEdit.ShowHeader = False
        Me.PortEdit.ValueMember = "PKey"
        '
        'FKeyVessel
        '
        Me.FKeyVessel.Caption = "New Vessel"
        Me.FKeyVessel.ColumnEdit = Me.VesselEdit
        Me.FKeyVessel.FieldName = "FKeyVessel"
        Me.FKeyVessel.Name = "FKeyVessel"
        Me.FKeyVessel.OptionsColumn.AllowEdit = False
        Me.FKeyVessel.OptionsColumn.AllowFocus = False
        Me.FKeyVessel.OptionsColumn.ReadOnly = True
        Me.FKeyVessel.Tag = "Required"
        Me.FKeyVessel.Visible = True
        Me.FKeyVessel.VisibleIndex = 4
        '
        'VesselEdit
        '
        Me.VesselEdit.AutoHeight = False
        Me.VesselEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VesselEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.VesselEdit.DisplayMember = "Name"
        Me.VesselEdit.Name = "VesselEdit"
        Me.VesselEdit.NullText = ""
        Me.VesselEdit.ShowFooter = False
        Me.VesselEdit.ShowHeader = False
        Me.VesselEdit.ValueMember = "PKey"
        '
        'DateSON
        '
        Me.DateSON.Caption = "Date Sign-on"
        Me.DateSON.ColumnEdit = Me.GenericDateEdit
        Me.DateSON.FieldName = "DateSON"
        Me.DateSON.Name = "DateSON"
        Me.DateSON.Tag = "Required"
        Me.DateSON.Visible = True
        Me.DateSON.VisibleIndex = 5
        '
        'PlaceSON
        '
        Me.PlaceSON.Caption = "Place Sign-on"
        Me.PlaceSON.ColumnEdit = Me.PortEdit
        Me.PlaceSON.FieldName = "PlaceSON"
        Me.PlaceSON.Name = "PlaceSON"
        Me.PlaceSON.Tag = "Required"
        Me.PlaceSON.Visible = True
        Me.PlaceSON.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "curFKeyWScaleCode"
        Me.GridColumn1.FieldName = "curFKeyWScaleCode"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Current Wage Scale"
        Me.GridColumn2.ColumnEdit = Me.lkuCurWScaleRank
        Me.GridColumn2.FieldName = "curFKeyWScaleRankCode"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Tag = "Required"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 7
        '
        'lkuCurWScaleRank
        '
        Me.lkuCurWScaleRank.AutoHeight = False
        Me.lkuCurWScaleRank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkuCurWScaleRank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey")})
        Me.lkuCurWScaleRank.DisplayMember = "Name"
        Me.lkuCurWScaleRank.Name = "lkuCurWScaleRank"
        Me.lkuCurWScaleRank.NullText = ""
        Me.lkuCurWScaleRank.ReadOnly = True
        Me.lkuCurWScaleRank.ValueMember = "PKey"
        '
        'FKeyWScaleRank
        '
        Me.FKeyWScaleRank.Caption = "Change to Wage Scale"
        Me.FKeyWScaleRank.ColumnEdit = Me.lkuWScaleRank
        Me.FKeyWScaleRank.FieldName = "FKeyWScaleRankCode"
        Me.FKeyWScaleRank.Name = "FKeyWScaleRank"
        Me.FKeyWScaleRank.Tag = "Required"
        Me.FKeyWScaleRank.Visible = True
        Me.FKeyWScaleRank.VisibleIndex = 8
        '
        'lkuWScaleRank
        '
        Me.lkuWScaleRank.AutoHeight = False
        Me.lkuWScaleRank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuWScaleRank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "WScaleRankCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuWScaleRank.DisplayMember = "Name"
        Me.lkuWScaleRank.Name = "lkuWScaleRank"
        Me.lkuWScaleRank.NullText = ""
        Me.lkuWScaleRank.ShowFooter = False
        Me.lkuWScaleRank.ShowHeader = False
        Me.lkuWScaleRank.ValueMember = "PKey"
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 9
        '
        'ToolTipController1
        '
        '
        'deDateSOFF
        '
        Me.deDateSOFF.EditValue = Nothing
        Me.deDateSOFF.Location = New System.Drawing.Point(106, 99)
        Me.deDateSOFF.Name = "deDateSOFF"
        Me.deDateSOFF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSOFF.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSOFF.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deDateSOFF.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deDateSOFF.Size = New System.Drawing.Size(466, 22)
        Me.deDateSOFF.StyleController = Me.LayoutControl1
        Me.deDateSOFF.TabIndex = 1
        Me.deDateSOFF.Tag = "DateSOFF"
        '
        'cboPlaceSON
        '
        Me.cboPlaceSON.Location = New System.Drawing.Point(676, 131)
        Me.cboPlaceSON.Name = "cboPlaceSON"
        Me.cboPlaceSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPlaceSON.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboPlaceSON.Properties.DisplayMember = "Name"
        Me.cboPlaceSON.Properties.NullText = ""
        Me.cboPlaceSON.Properties.ShowFooter = False
        Me.cboPlaceSON.Properties.ShowHeader = False
        Me.cboPlaceSON.Properties.ValueMember = "PKey"
        Me.cboPlaceSON.Size = New System.Drawing.Size(468, 22)
        Me.cboPlaceSON.StyleController = Me.LayoutControl1
        Me.cboPlaceSON.TabIndex = 5
        Me.cboPlaceSON.Tag = "PlaceSON"
        '
        'deDateSON
        '
        Me.deDateSON.EditValue = Nothing
        Me.deDateSON.Location = New System.Drawing.Point(676, 99)
        Me.deDateSON.Name = "deDateSON"
        Me.deDateSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSON.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSON.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deDateSON.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deDateSON.Size = New System.Drawing.Size(468, 22)
        Me.deDateSON.StyleController = Me.LayoutControl1
        Me.deDateSON.TabIndex = 4
        Me.deDateSON.Tag = "DateSON"
        '
        'cboPlaceSOFF
        '
        Me.cboPlaceSOFF.Location = New System.Drawing.Point(106, 131)
        Me.cboPlaceSOFF.Name = "cboPlaceSOFF"
        Me.cboPlaceSOFF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPlaceSOFF.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboPlaceSOFF.Properties.DisplayMember = "Name"
        Me.cboPlaceSOFF.Properties.NullText = ""
        Me.cboPlaceSOFF.Properties.ShowFooter = False
        Me.cboPlaceSOFF.Properties.ShowHeader = False
        Me.cboPlaceSOFF.Properties.ValueMember = "PKey"
        Me.cboPlaceSOFF.Size = New System.Drawing.Size(466, 22)
        Me.cboPlaceSOFF.StyleController = Me.LayoutControl1
        Me.cboPlaceSOFF.TabIndex = 2
        Me.cboPlaceSOFF.Tag = "PlaceSOFF"
        '
        'cboNewVessel
        '
        Me.cboNewVessel.Location = New System.Drawing.Point(676, 67)
        Me.cboNewVessel.Name = "cboNewVessel"
        Me.cboNewVessel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNewVessel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboNewVessel.Properties.DisplayMember = "Name"
        Me.cboNewVessel.Properties.NullText = ""
        Me.cboNewVessel.Properties.ShowFooter = False
        Me.cboNewVessel.Properties.ShowHeader = False
        Me.cboNewVessel.Properties.ValueMember = "PKey"
        Me.cboNewVessel.Size = New System.Drawing.Size(468, 22)
        Me.cboNewVessel.StyleController = Me.LayoutControl1
        Me.cboNewVessel.TabIndex = 3
        Me.cboNewVessel.Tag = "VslCode"
        '
        'LCGTransfer
        '
        Me.LCGTransfer.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LCGTransfer.GroupBordersVisible = False
        Me.LCGTransfer.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.grpTRANS, Me.LayoutControlItem1})
        Me.LCGTransfer.Location = New System.Drawing.Point(0, 0)
        Me.LCGTransfer.Name = "Root"
        Me.LCGTransfer.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LCGTransfer.Size = New System.Drawing.Size(1158, 526)
        Me.LCGTransfer.TextVisible = False
        '
        'grpTRANS
        '
        Me.grpTRANS.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTRANS.AppearanceGroup.Options.UseFont = True
        Me.grpTRANS.CustomizationFormText = "Transfer"
        Me.grpTRANS.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.grpTRANS.ExpandButtonVisible = True
        Me.grpTRANS.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem6, Me.LayoutControlItem12, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.grpTRANS.Location = New System.Drawing.Point(0, 0)
        Me.grpTRANS.Name = "grpTRANS"
        Me.grpTRANS.Size = New System.Drawing.Size(1158, 170)
        Me.grpTRANS.Text = "Transfer"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboNewVessel
        Me.LayoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem4.CustomizationFormText = "New Vessel:"
        Me.LayoutControlItem4.FillControlToClientArea = False
        Me.LayoutControlItem4.Location = New System.Drawing.Point(562, 23)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(153, 32)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(572, 32)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "New Vessel:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cboPlaceSOFF
        Me.LayoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem8.CustomizationFormText = "Place Sign-off:"
        Me.LayoutControlItem8.FillControlToClientArea = False
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 87)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(145, 32)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(562, 32)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Place Sign-off:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboPlaceSON
        Me.LayoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem9.CustomizationFormText = "Place Sign-on:"
        Me.LayoutControlItem9.FillControlToClientArea = False
        Me.LayoutControlItem9.Location = New System.Drawing.Point(562, 87)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(153, 32)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(572, 32)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.Text = "Place Sign-on:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.deDateSON
        Me.LayoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem6.CustomizationFormText = "Date Sign-on:"
        Me.LayoutControlItem6.FillControlToClientArea = False
        Me.LayoutControlItem6.Location = New System.Drawing.Point(562, 55)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(153, 32)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(572, 32)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Date Sign-on:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.deDateSOFF
        Me.LayoutControlItem12.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem12.CustomizationFormText = "Date Sign-off:"
        Me.LayoutControlItem12.FillControlToClientArea = False
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 55)
        Me.LayoutControlItem12.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(145, 32)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(562, 32)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.Text = "Date Sign-off:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboVessel
        Me.LayoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem2.FillControlToClientArea = False
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 23)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(145, 32)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(562, 32)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Current Vessel:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.Label1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 23)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(23, 23)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1134, 23)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Maingrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 170)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1158, 356)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'Transfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Transfer"
        Me.Size = New System.Drawing.Size(1158, 526)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VesselEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuCurWScaleRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuWScaleRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSOFF.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSOFF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPlaceSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPlaceSOFF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNewVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LCGTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpTRANS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LCGTransfer As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents deDateSOFF As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboPlaceSON As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deDateSON As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboPlaceSOFF As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboNewVessel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents grpTRANS As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrentVessel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateSOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GenericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PortEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents VesselEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PlaceSOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyVessel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateSON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PlaceSON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents cboVessel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuWScaleRank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents FKeyWScaleRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuCurWScaleRank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

End Class
