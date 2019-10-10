<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignOn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignOn))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.deDepDate = New DevExpress.XtraEditors.DateEdit()
        Me.cboDepPlace = New DevExpress.XtraEditors.LookUpEdit()
        Me.Plangrid = New DevExpress.XtraGrid.GridControl()
        Me.Planview = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PlanRankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PlanWScaleRankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PlanPort = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PlanRelieveEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FKeyPlannedVsl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyWScaleRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WageScaleRankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LOCDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateDep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GenericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.PlaceDep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PortEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DateSON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PlaceSON = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RelieveID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RelieveEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmInvalidMsg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyAgentCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AgentEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.WageScaleEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VesselEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController()
        Me.cboVessel = New DevExpress.XtraEditors.LookUpEdit()
        Me.deDateSON = New DevExpress.XtraEditors.DateEdit()
        Me.cboPlaceSON = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboWScale = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.LCGSignOn = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.header = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LCGAutoFill = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.txtVessel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.deDepDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDepDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Plangrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Planview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanRankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanWScaleRankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlanRelieveEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WageScaleRankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RelieveEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgentEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WageScaleEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VesselEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPlaceSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboWScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LCGSignOn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LCGAutoFill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.deDepDate)
        Me.LayoutControl1.Controls.Add(Me.cboDepPlace)
        Me.LayoutControl1.Controls.Add(Me.Plangrid)
        Me.LayoutControl1.Controls.Add(Me.Maingrid)
        Me.LayoutControl1.Controls.Add(Me.cboVessel)
        Me.LayoutControl1.Controls.Add(Me.deDateSON)
        Me.LayoutControl1.Controls.Add(Me.cboPlaceSON)
        Me.LayoutControl1.Controls.Add(Me.cboWScale)
        Me.LayoutControl1.Controls.Add(Me.cboAgent)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(494, 143, 705, 498)
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
        Me.LayoutControl1.Root = Me.LCGSignOn
        Me.LayoutControl1.Size = New System.Drawing.Size(1222, 459)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Italic)
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(634, 269)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(574, 18)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Drag a crew from the Planned Crew list to sign on to the selected vessel"
        '
        'deDepDate
        '
        Me.deDepDate.EditValue = Nothing
        Me.deDepDate.Location = New System.Drawing.Point(108, 130)
        Me.deDepDate.Name = "deDepDate"
        Me.deDepDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDepDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDepDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deDepDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deDepDate.Size = New System.Drawing.Size(505, 20)
        Me.deDepDate.StyleController = Me.LayoutControl1
        Me.deDepDate.TabIndex = 35
        '
        'cboDepPlace
        '
        Me.cboDepPlace.Location = New System.Drawing.Point(108, 156)
        Me.cboDepPlace.Name = "cboDepPlace"
        Me.cboDepPlace.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDepPlace.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboDepPlace.Properties.DisplayMember = "Name"
        Me.cboDepPlace.Properties.NullText = ""
        Me.cboDepPlace.Properties.ShowFooter = False
        Me.cboDepPlace.Properties.ShowHeader = False
        Me.cboDepPlace.Properties.ValueMember = "PKey"
        Me.cboDepPlace.Size = New System.Drawing.Size(505, 20)
        Me.cboDepPlace.StyleController = Me.LayoutControl1
        Me.cboDepPlace.TabIndex = 34
        '
        'Plangrid
        '
        Me.Plangrid.AllowDrop = True
        Me.Plangrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Plangrid.Location = New System.Drawing.Point(634, 37)
        Me.Plangrid.MainView = Me.Planview
        Me.Plangrid.Name = "Plangrid"
        Me.Plangrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PlanRankEdit, Me.PlanWScaleRankEdit, Me.PlanRelieveEdit, Me.PlanPort})
        Me.Plangrid.Size = New System.Drawing.Size(574, 228)
        Me.Plangrid.TabIndex = 33
        Me.Plangrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Planview})
        '
        'Planview
        '
        Me.Planview.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.Planview.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.FKeyPlannedVsl})
        Me.Planview.GridControl = Me.Plangrid
        Me.Planview.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.Planview.Name = "Planview"
        Me.Planview.OptionsBehavior.Editable = False
        Me.Planview.OptionsBehavior.ReadOnly = True
        Me.Planview.OptionsCustomization.AllowGroup = False
        Me.Planview.OptionsCustomization.AllowQuickHideColumns = False
        Me.Planview.OptionsFind.AllowFindPanel = False
        Me.Planview.OptionsHint.ShowFooterHints = False
        Me.Planview.OptionsMenu.EnableColumnMenu = False
        Me.Planview.OptionsMenu.EnableFooterMenu = False
        Me.Planview.OptionsMenu.EnableGroupPanelMenu = False
        Me.Planview.OptionsSelection.MultiSelect = True
        Me.Planview.OptionsView.ColumnAutoWidth = False
        Me.Planview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.Planview.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Planned Crew"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 799
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Crew"
        Me.BandedGridColumn4.FieldName = "Crew"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn4.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 259
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Rank"
        Me.BandedGridColumn5.ColumnEdit = Me.PlanRankEdit
        Me.BandedGridColumn5.FieldName = "PlannedRank"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn5.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn5.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 68
        '
        'PlanRankEdit
        '
        Me.PlanRankEdit.AutoHeight = False
        Me.PlanRankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanRankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Abbrv")})
        Me.PlanRankEdit.DisplayMember = "Abbrv"
        Me.PlanRankEdit.Name = "PlanRankEdit"
        Me.PlanRankEdit.NullText = ""
        Me.PlanRankEdit.ShowFooter = False
        Me.PlanRankEdit.ShowHeader = False
        Me.PlanRankEdit.ValueMember = "PKey"
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Wage Scale"
        Me.BandedGridColumn6.ColumnEdit = Me.PlanWScaleRankEdit
        Me.BandedGridColumn6.FieldName = "PlannedWScaleRank"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn6.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn6.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 135
        '
        'PlanWScaleRankEdit
        '
        Me.PlanWScaleRankEdit.AutoHeight = False
        Me.PlanWScaleRankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanWScaleRankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.PlanWScaleRankEdit.DisplayMember = "Name"
        Me.PlanWScaleRankEdit.Name = "PlanWScaleRankEdit"
        Me.PlanWScaleRankEdit.NullText = ""
        Me.PlanWScaleRankEdit.ShowFooter = False
        Me.PlanWScaleRankEdit.ShowHeader = False
        Me.PlanWScaleRankEdit.ValueMember = "PKey"
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "Plan Sign-on Date"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn7.FieldName = "PlannedDateSON"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn7.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn7.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 108
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "Plan Sign-on Place"
        Me.BandedGridColumn8.ColumnEdit = Me.PlanPort
        Me.BandedGridColumn8.FieldName = "PlannedPlaceSON"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn8.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn8.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 109
        '
        'PlanPort
        '
        Me.PlanPort.AutoHeight = False
        Me.PlanPort.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanPort.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey")})
        Me.PlanPort.DisplayMember = "Name"
        Me.PlanPort.Name = "PlanPort"
        Me.PlanPort.NullText = ""
        Me.PlanPort.ValueMember = "PKey"
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "Crew to Relieve"
        Me.BandedGridColumn9.ColumnEdit = Me.PlanRelieveEdit
        Me.BandedGridColumn9.FieldName = "PlannedToRelieveID"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn9.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn9.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 120
        '
        'PlanRelieveEdit
        '
        Me.PlanRelieveEdit.AutoHeight = False
        Me.PlanRelieveEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PlanRelieveEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Crew", "Crew"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrActID", "CurrActID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.PlanRelieveEdit.DisplayMember = "Crew"
        Me.PlanRelieveEdit.Name = "PlanRelieveEdit"
        Me.PlanRelieveEdit.NullText = ""
        Me.PlanRelieveEdit.ShowFooter = False
        Me.PlanRelieveEdit.ShowHeader = False
        Me.PlanRelieveEdit.ValueMember = "CurrActID"
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "IDNbr"
        Me.BandedGridColumn1.FieldName = "IDNbr"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "CurrActID"
        Me.BandedGridColumn2.FieldName = "CurrActID"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "ActGrpID"
        Me.BandedGridColumn3.FieldName = "ActGrpID"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        '
        'FKeyPlannedVsl
        '
        Me.FKeyPlannedVsl.Caption = "FKeyPlannedVsl"
        Me.FKeyPlannedVsl.FieldName = "FKeyPlannedVsl"
        Me.FKeyPlannedVsl.Name = "FKeyPlannedVsl"
        '
        'Maingrid
        '
        Me.Maingrid.AllowDrop = True
        Me.Maingrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Maingrid.Location = New System.Drawing.Point(14, 296)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RankEdit, Me.PortEdit, Me.WageScaleEdit, Me.WageScaleRankEdit, Me.VesselEdit, Me.AgentEdit, Me.GenericDateEdit, Me.RelieveEdit})
        Me.Maingrid.Size = New System.Drawing.Size(1194, 149)
        Me.Maingrid.TabIndex = 32
        Me.Maingrid.ToolTipController = Me.ToolTipController1
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mainview.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Red
        Me.Mainview.Appearance.FooterPanel.Options.UseFont = True
        Me.Mainview.Appearance.FooterPanel.Options.UseForeColor = True
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDNbr, Me.CurrActID, Me.CrewName, Me.FKeyRank, Me.FKeyWScaleRank, Me.LOC, Me.LOCDays, Me.DateDep, Me.PlaceDep, Me.DateSON, Me.PlaceSON, Me.RelieveID, Me.Remarks, Me.clmInvalidMsg, Me.FKeyAgentCode})
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
        'FKeyRank
        '
        Me.FKeyRank.Caption = "Rank"
        Me.FKeyRank.ColumnEdit = Me.RankEdit
        Me.FKeyRank.FieldName = "FKeyRank"
        Me.FKeyRank.Name = "FKeyRank"
        Me.FKeyRank.Tag = "Required"
        Me.FKeyRank.Visible = True
        Me.FKeyRank.VisibleIndex = 1
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Abbrv"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RankEdit.DisplayMember = "Abbrv"
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "PKey"
        '
        'FKeyWScaleRank
        '
        Me.FKeyWScaleRank.Caption = "Wage Scale"
        Me.FKeyWScaleRank.ColumnEdit = Me.WageScaleRankEdit
        Me.FKeyWScaleRank.FieldName = "FKeyWScaleRank"
        Me.FKeyWScaleRank.Name = "FKeyWScaleRank"
        Me.FKeyWScaleRank.Tag = "Required"
        Me.FKeyWScaleRank.Visible = True
        Me.FKeyWScaleRank.VisibleIndex = 2
        '
        'WageScaleRankEdit
        '
        Me.WageScaleRankEdit.AutoHeight = False
        Me.WageScaleRankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WageScaleRankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "RankCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.WageScaleRankEdit.DisplayMember = "Name"
        Me.WageScaleRankEdit.Name = "WageScaleRankEdit"
        Me.WageScaleRankEdit.NullText = ""
        Me.WageScaleRankEdit.ShowFooter = False
        Me.WageScaleRankEdit.ShowHeader = False
        Me.WageScaleRankEdit.ValueMember = "PKey"
        '
        'LOC
        '
        Me.LOC.Caption = "LOC Months"
        Me.LOC.FieldName = "LOC"
        Me.LOC.Name = "LOC"
        Me.LOC.Tag = "Required"
        Me.LOC.Visible = True
        Me.LOC.VisibleIndex = 3
        '
        'LOCDays
        '
        Me.LOCDays.Caption = "LOC Days"
        Me.LOCDays.FieldName = "LOCDays"
        Me.LOCDays.Name = "LOCDays"
        Me.LOCDays.Tag = "Required"
        Me.LOCDays.Visible = True
        Me.LOCDays.VisibleIndex = 4
        '
        'DateDep
        '
        Me.DateDep.Caption = "Departing Date"
        Me.DateDep.ColumnEdit = Me.GenericDateEdit
        Me.DateDep.FieldName = "DateDep"
        Me.DateDep.Name = "DateDep"
        Me.DateDep.Tag = "Required"
        Me.DateDep.Visible = True
        Me.DateDep.VisibleIndex = 5
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
        'PlaceDep
        '
        Me.PlaceDep.Caption = "Departing Place"
        Me.PlaceDep.ColumnEdit = Me.PortEdit
        Me.PlaceDep.FieldName = "PlaceDep"
        Me.PlaceDep.Name = "PlaceDep"
        Me.PlaceDep.Tag = "Required"
        Me.PlaceDep.Visible = True
        Me.PlaceDep.VisibleIndex = 6
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
        'DateSON
        '
        Me.DateSON.Caption = "Date Sign-on"
        Me.DateSON.ColumnEdit = Me.GenericDateEdit
        Me.DateSON.FieldName = "DateSON"
        Me.DateSON.Name = "DateSON"
        Me.DateSON.Tag = "Required"
        Me.DateSON.Visible = True
        Me.DateSON.VisibleIndex = 7
        '
        'PlaceSON
        '
        Me.PlaceSON.Caption = "Place Sign-on"
        Me.PlaceSON.ColumnEdit = Me.PortEdit
        Me.PlaceSON.FieldName = "PlaceSON"
        Me.PlaceSON.Name = "PlaceSON"
        Me.PlaceSON.Tag = "Required"
        Me.PlaceSON.Visible = True
        Me.PlaceSON.VisibleIndex = 8
        '
        'RelieveID
        '
        Me.RelieveID.Caption = "Crew to Relieve"
        Me.RelieveID.ColumnEdit = Me.RelieveEdit
        Me.RelieveID.FieldName = "RelieveID"
        Me.RelieveID.Name = "RelieveID"
        Me.RelieveID.Visible = True
        Me.RelieveID.VisibleIndex = 10
        '
        'RelieveEdit
        '
        Me.RelieveEdit.AutoHeight = False
        Me.RelieveEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.RelieveEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrActID", "CurrActID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Crew", "Crew")})
        Me.RelieveEdit.DisplayMember = "Crew"
        Me.RelieveEdit.Name = "RelieveEdit"
        Me.RelieveEdit.NullText = ""
        Me.RelieveEdit.ShowFooter = False
        Me.RelieveEdit.ShowHeader = False
        Me.RelieveEdit.ValueMember = "CurrActID"
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 11
        '
        'clmInvalidMsg
        '
        Me.clmInvalidMsg.Caption = "InvalidMsg"
        Me.clmInvalidMsg.FieldName = "InvalidMsg"
        Me.clmInvalidMsg.Name = "clmInvalidMsg"
        '
        'FKeyAgentCode
        '
        Me.FKeyAgentCode.Caption = "Agent"
        Me.FKeyAgentCode.ColumnEdit = Me.AgentEdit
        Me.FKeyAgentCode.FieldName = "FKeyAgentCode"
        Me.FKeyAgentCode.Name = "FKeyAgentCode"
        Me.FKeyAgentCode.Tag = "Required"
        Me.FKeyAgentCode.Visible = True
        Me.FKeyAgentCode.VisibleIndex = 9
        '
        'AgentEdit
        '
        Me.AgentEdit.AutoHeight = False
        Me.AgentEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AgentEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.AgentEdit.DisplayMember = "Name"
        Me.AgentEdit.Name = "AgentEdit"
        Me.AgentEdit.NullText = ""
        Me.AgentEdit.ShowFooter = False
        Me.AgentEdit.ShowHeader = False
        Me.AgentEdit.ValueMember = "PKey"
        '
        'WageScaleEdit
        '
        Me.WageScaleEdit.AutoHeight = False
        Me.WageScaleEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WageScaleEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey")})
        Me.WageScaleEdit.DisplayMember = "Name"
        Me.WageScaleEdit.Name = "WageScaleEdit"
        Me.WageScaleEdit.NullText = ""
        Me.WageScaleEdit.ValueMember = "PKey"
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
        'ToolTipController1
        '
        '
        'cboVessel
        '
        Me.cboVessel.Location = New System.Drawing.Point(96, 40)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVessel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboVessel.Properties.DisplayMember = "Name"
        Me.cboVessel.Properties.NullText = ""
        Me.cboVessel.Properties.ShowFooter = False
        Me.cboVessel.Properties.ShowHeader = False
        Me.cboVessel.Properties.ValueMember = "PKey"
        Me.cboVessel.Size = New System.Drawing.Size(529, 20)
        Me.cboVessel.StyleController = Me.LayoutControl1
        Me.cboVessel.TabIndex = 7
        Me.cboVessel.Tag = "VslCode"
        '
        'deDateSON
        '
        Me.deDateSON.EditValue = Nothing
        Me.deDateSON.Location = New System.Drawing.Point(108, 182)
        Me.deDateSON.Name = "deDateSON"
        Me.deDateSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSON.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSON.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deDateSON.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deDateSON.Size = New System.Drawing.Size(505, 20)
        Me.deDateSON.StyleController = Me.LayoutControl1
        Me.deDateSON.TabIndex = 8
        Me.deDateSON.Tag = "DateSON;DateDep"
        '
        'cboPlaceSON
        '
        Me.cboPlaceSON.Location = New System.Drawing.Point(108, 208)
        Me.cboPlaceSON.Name = "cboPlaceSON"
        Me.cboPlaceSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPlaceSON.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboPlaceSON.Properties.DisplayMember = "Name"
        Me.cboPlaceSON.Properties.NullText = ""
        Me.cboPlaceSON.Properties.ShowFooter = False
        Me.cboPlaceSON.Properties.ShowHeader = False
        Me.cboPlaceSON.Properties.ValueMember = "PKey"
        Me.cboPlaceSON.Size = New System.Drawing.Size(505, 20)
        Me.cboPlaceSON.StyleController = Me.LayoutControl1
        Me.cboPlaceSON.TabIndex = 9
        Me.cboPlaceSON.Tag = "PlaceSON;PlaceDep"
        '
        'cboWScale
        '
        Me.cboWScale.Location = New System.Drawing.Point(108, 104)
        Me.cboWScale.Name = "cboWScale"
        Me.cboWScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboWScale.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboWScale.Properties.DisplayMember = "Name"
        Me.cboWScale.Properties.NullText = ""
        Me.cboWScale.Properties.ShowFooter = False
        Me.cboWScale.Properties.ShowHeader = False
        Me.cboWScale.Properties.ValueMember = "PKey"
        Me.cboWScale.Size = New System.Drawing.Size(505, 20)
        Me.cboWScale.StyleController = Me.LayoutControl1
        Me.cboWScale.TabIndex = 30
        '
        'cboAgent
        '
        Me.cboAgent.Location = New System.Drawing.Point(108, 78)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAgent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboAgent.Properties.DisplayMember = "Name"
        Me.cboAgent.Properties.NullText = ""
        Me.cboAgent.Properties.ShowFooter = False
        Me.cboAgent.Properties.ShowHeader = False
        Me.cboAgent.Properties.ValueMember = "PKey"
        Me.cboAgent.Size = New System.Drawing.Size(505, 20)
        Me.cboAgent.StyleController = Me.LayoutControl1
        Me.cboAgent.TabIndex = 28
        Me.cboAgent.Tag = "AgentCode"
        '
        'LCGSignOn
        '
        Me.LCGSignOn.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCGSignOn.AppearanceGroup.Options.UseFont = True
        Me.LCGSignOn.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LCGSignOn.GroupBordersVisible = False
        Me.LCGSignOn.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.header})
        Me.LCGSignOn.Location = New System.Drawing.Point(0, 0)
        Me.LCGSignOn.Name = "Root"
        Me.LCGSignOn.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LCGSignOn.Size = New System.Drawing.Size(1222, 459)
        Me.LCGSignOn.TextVisible = False
        '
        'header
        '
        Me.header.CustomizationFormText = "Sign On"
        Me.header.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.header.ExpandButtonVisible = True
        Me.header.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LCGAutoFill, Me.LayoutControlItem3, Me.SplitterItem1, Me.txtVessel, Me.SplitterItem2, Me.EmptySpaceItem1, Me.LayoutControlItem6})
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1222, 459)
        Me.header.Text = "Sign-on"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Maingrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 259)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1198, 153)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LCGAutoFill
        '
        Me.LCGAutoFill.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCGAutoFill.AppearanceGroup.Options.UseFont = True
        Me.LCGAutoFill.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem19, Me.LayoutControlItem20, Me.LayoutControlItem10, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem21})
        Me.LCGAutoFill.Location = New System.Drawing.Point(0, 26)
        Me.LCGAutoFill.Name = "LCGAutoFill"
        Me.LCGAutoFill.Size = New System.Drawing.Size(615, 180)
        Me.LCGAutoFill.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.deDateSON
        Me.LayoutControlItem19.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem19.CustomizationFormText = "Sign On Date:"
        Me.LayoutControlItem19.FillControlToClientArea = False
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem19.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem19.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5)
        Me.LayoutControlItem19.Size = New System.Drawing.Size(591, 26)
        Me.LayoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem19.Text = "Date Sign-on:"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.cboPlaceSON
        Me.LayoutControlItem20.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem20.CustomizationFormText = "Place Sign On:"
        Me.LayoutControlItem20.FillControlToClientArea = False
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlItem20.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem20.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5)
        Me.LayoutControlItem20.Size = New System.Drawing.Size(591, 26)
        Me.LayoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem20.Text = "Place Sign-on:"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.cboWScale
        Me.LayoutControlItem10.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem10.CustomizationFormText = "Wage Scale:"
        Me.LayoutControlItem10.FillControlToClientArea = False
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(591, 26)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.Text = "Wage Scale:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboDepPlace
        Me.LayoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem4.FillControlToClientArea = False
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(591, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Departing Place:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.deDepDate
        Me.LayoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem5.FillControlToClientArea = False
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(591, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Departing Date:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.cboAgent
        Me.LayoutControlItem21.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem21.CustomizationFormText = "Agent: "
        Me.LayoutControlItem21.FillControlToClientArea = False
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem21.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5)
        Me.LayoutControlItem21.Size = New System.Drawing.Size(591, 26)
        Me.LayoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem21.Text = "Agent: "
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.Plangrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(620, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(578, 232)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(615, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 254)
        '
        'txtVessel
        '
        Me.txtVessel.Control = Me.cboVessel
        Me.txtVessel.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtVessel.CustomizationFormText = "Vessel:"
        Me.txtVessel.FillControlToClientArea = False
        Me.txtVessel.Location = New System.Drawing.Point(0, 0)
        Me.txtVessel.MaxSize = New System.Drawing.Size(0, 26)
        Me.txtVessel.MinSize = New System.Drawing.Size(127, 26)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5)
        Me.txtVessel.Size = New System.Drawing.Size(615, 26)
        Me.txtVessel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.txtVessel.Text = "* Vessel:"
        Me.txtVessel.TextSize = New System.Drawing.Size(79, 13)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 254)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(1198, 5)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 206)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(615, 48)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.Label1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(620, 232)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(0, 22)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(18, 22)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(578, 22)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Maingrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1020, 357)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(111, 16)
        '
        'SignOn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "SignOn"
        Me.Size = New System.Drawing.Size(1222, 459)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.deDepDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDepDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Plangrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Planview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanRankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanWScaleRankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlanRelieveEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WageScaleRankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RelieveEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgentEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WageScaleEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VesselEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPlaceSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboWScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LCGSignOn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LCGAutoFill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LCGSignOn As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboVessel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deDateSON As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboPlaceSON As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboWScale As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents header As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtVessel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents IDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyWScaleRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LOCDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateDep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PlaceDep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateSON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PlaceSON As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RelieveID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PortEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents WageScaleEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents WageScaleRankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents AgentEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents VesselEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GenericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CurrActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LCGAutoFill As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents Plangrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents Planview As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PlanRankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PlanWScaleRankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PlanRelieveEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RelieveEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PlanPort As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmInvalidMsg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents deDepDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cboDepPlace As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents FKeyPlannedVsl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents FKeyAgentCode As DevExpress.XtraGrid.Columns.GridColumn

End Class
