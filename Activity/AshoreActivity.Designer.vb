<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AshoreActivity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AshoreActivity))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboWScale = New DevExpress.XtraEditors.LookUpEdit()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ActGrpID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FkeyRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyWScaleRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WageScaleRankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.NextActivity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AshoreStatusEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DateStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GenericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.StartPlace = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PortEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.EndPlace = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboNxtAct = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboStartPlace = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboEndPlace = New DevExpress.XtraEditors.LookUpEdit()
        Me.deStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.grpASHACT = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboWScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WageScaleRankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AshoreStatusEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNxtAct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStartPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEndPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpASHACT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.cboWScale)
        Me.LayoutControl1.Controls.Add(Me.Maingrid)
        Me.LayoutControl1.Controls.Add(Me.cboNxtAct)
        Me.LayoutControl1.Controls.Add(Me.cboStartPlace)
        Me.LayoutControl1.Controls.Add(Me.cboEndPlace)
        Me.LayoutControl1.Controls.Add(Me.deStartDate)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(997, 553)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboWScale
        '
        Me.cboWScale.Location = New System.Drawing.Point(134, 173)
        Me.cboWScale.Name = "cboWScale"
        Me.cboWScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboWScale.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboWScale.Properties.DisplayMember = "Name"
        Me.cboWScale.Properties.NullText = ""
        Me.cboWScale.Properties.ShowFooter = False
        Me.cboWScale.Properties.ShowHeader = False
        Me.cboWScale.Properties.ValueMember = "PKey"
        Me.cboWScale.Size = New System.Drawing.Size(362, 22)
        Me.cboWScale.StyleController = Me.LayoutControl1
        Me.cboWScale.TabIndex = 5
        '
        'Maingrid
        '
        Me.Maingrid.AllowDrop = True
        Me.Maingrid.Location = New System.Drawing.Point(2, 211)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PortEdit, Me.GenericDateEdit, Me.AshoreStatusEdit, Me.RankEdit, Me.WageScaleRankEdit})
        Me.Maingrid.Size = New System.Drawing.Size(993, 340)
        Me.Maingrid.TabIndex = 4
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDNbr, Me.CurrActID, Me.ActGrpID, Me.CrewName, Me.FkeyRank, Me.FKeyWScaleRank, Me.NextActivity, Me.DateStart, Me.StartPlace, Me.EndPlace, Me.Remarks})
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
        'ActGrpID
        '
        Me.ActGrpID.Caption = "ActGrpID"
        Me.ActGrpID.FieldName = "ActGrpID"
        Me.ActGrpID.Name = "ActGrpID"
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
        Me.CrewName.Width = 190
        '
        'FkeyRank
        '
        Me.FkeyRank.Caption = "Rank"
        Me.FkeyRank.ColumnEdit = Me.RankEdit
        Me.FkeyRank.FieldName = "FKeyRank"
        Me.FkeyRank.Name = "FkeyRank"
        Me.FkeyRank.Visible = True
        Me.FkeyRank.VisibleIndex = 1
        Me.FkeyRank.Width = 154
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Abbrv"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RankEdit.DisplayMember = "Abbrv"
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "PKey"
        '
        'FKeyWScaleRank
        '
        Me.FKeyWScaleRank.Caption = "Ashore Wage Scale"
        Me.FKeyWScaleRank.ColumnEdit = Me.WageScaleRankEdit
        Me.FKeyWScaleRank.FieldName = "FKeyWScaleRank"
        Me.FKeyWScaleRank.Name = "FKeyWScaleRank"
        Me.FKeyWScaleRank.Visible = True
        Me.FKeyWScaleRank.VisibleIndex = 2
        Me.FKeyWScaleRank.Width = 156
        '
        'WageScaleRankEdit
        '
        Me.WageScaleRankEdit.AutoHeight = False
        Me.WageScaleRankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.WageScaleRankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.WageScaleRankEdit.DisplayMember = "Name"
        Me.WageScaleRankEdit.Name = "WageScaleRankEdit"
        Me.WageScaleRankEdit.NullText = ""
        Me.WageScaleRankEdit.ShowFooter = False
        Me.WageScaleRankEdit.ShowHeader = False
        Me.WageScaleRankEdit.ValueMember = "PKey"
        '
        'NextActivity
        '
        Me.NextActivity.Caption = "Next Activity"
        Me.NextActivity.ColumnEdit = Me.AshoreStatusEdit
        Me.NextActivity.FieldName = "NextActivity"
        Me.NextActivity.Name = "NextActivity"
        Me.NextActivity.Tag = "Required"
        Me.NextActivity.Visible = True
        Me.NextActivity.VisibleIndex = 3
        Me.NextActivity.Width = 206
        '
        'AshoreStatusEdit
        '
        Me.AshoreStatusEdit.AutoHeight = False
        Me.AshoreStatusEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AshoreStatusEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.AshoreStatusEdit.DisplayMember = "Name"
        Me.AshoreStatusEdit.Name = "AshoreStatusEdit"
        Me.AshoreStatusEdit.NullText = ""
        Me.AshoreStatusEdit.ShowFooter = False
        Me.AshoreStatusEdit.ShowHeader = False
        Me.AshoreStatusEdit.ValueMember = "PKey"
        '
        'DateStart
        '
        Me.DateStart.Caption = "Date Start"
        Me.DateStart.ColumnEdit = Me.GenericDateEdit
        Me.DateStart.FieldName = "DateStart"
        Me.DateStart.Name = "DateStart"
        Me.DateStart.Tag = "Required"
        Me.DateStart.Visible = True
        Me.DateStart.VisibleIndex = 4
        Me.DateStart.Width = 138
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
        'StartPlace
        '
        Me.StartPlace.Caption = "Starting Place"
        Me.StartPlace.ColumnEdit = Me.PortEdit
        Me.StartPlace.FieldName = "StartPlace"
        Me.StartPlace.Name = "StartPlace"
        Me.StartPlace.Tag = "Required"
        Me.StartPlace.Visible = True
        Me.StartPlace.VisibleIndex = 5
        Me.StartPlace.Width = 138
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
        'EndPlace
        '
        Me.EndPlace.Caption = "End Place"
        Me.EndPlace.ColumnEdit = Me.PortEdit
        Me.EndPlace.FieldName = "EndPlace"
        Me.EndPlace.Name = "EndPlace"
        Me.EndPlace.Visible = True
        Me.EndPlace.VisibleIndex = 6
        Me.EndPlace.Width = 145
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 7
        Me.Remarks.Width = 130
        '
        'cboNxtAct
        '
        Me.cboNxtAct.Location = New System.Drawing.Point(134, 44)
        Me.cboNxtAct.Name = "cboNxtAct"
        Me.cboNxtAct.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNxtAct.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboNxtAct.Properties.DisplayMember = "Name"
        Me.cboNxtAct.Properties.NullText = ""
        Me.cboNxtAct.Properties.ShowFooter = False
        Me.cboNxtAct.Properties.ShowHeader = False
        Me.cboNxtAct.Properties.ValueMember = "PKey"
        Me.cboNxtAct.Size = New System.Drawing.Size(362, 22)
        Me.cboNxtAct.StyleController = Me.LayoutControl1
        Me.cboNxtAct.TabIndex = 0
        Me.cboNxtAct.Tag = "NxtAct"
        '
        'cboStartPlace
        '
        Me.cboStartPlace.Location = New System.Drawing.Point(134, 77)
        Me.cboStartPlace.Name = "cboStartPlace"
        Me.cboStartPlace.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboStartPlace.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboStartPlace.Properties.DisplayMember = "Name"
        Me.cboStartPlace.Properties.NullText = ""
        Me.cboStartPlace.Properties.ShowFooter = False
        Me.cboStartPlace.Properties.ShowHeader = False
        Me.cboStartPlace.Properties.ValueMember = "PKey"
        Me.cboStartPlace.Size = New System.Drawing.Size(362, 22)
        Me.cboStartPlace.StyleController = Me.LayoutControl1
        Me.cboStartPlace.TabIndex = 1
        Me.cboStartPlace.Tag = "PlaceStart"
        '
        'cboEndPlace
        '
        Me.cboEndPlace.Location = New System.Drawing.Point(134, 110)
        Me.cboEndPlace.Name = "cboEndPlace"
        Me.cboEndPlace.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboEndPlace.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboEndPlace.Properties.DisplayMember = "Name"
        Me.cboEndPlace.Properties.NullText = ""
        Me.cboEndPlace.Properties.ShowFooter = False
        Me.cboEndPlace.Properties.ShowHeader = False
        Me.cboEndPlace.Properties.ValueMember = "PKey"
        Me.cboEndPlace.Size = New System.Drawing.Size(362, 22)
        Me.cboEndPlace.StyleController = Me.LayoutControl1
        Me.cboEndPlace.TabIndex = 2
        Me.cboEndPlace.Tag = "PlaceEnd"
        '
        'deStartDate
        '
        Me.deStartDate.EditValue = Nothing
        Me.deStartDate.Location = New System.Drawing.Point(134, 143)
        Me.deStartDate.Name = "deStartDate"
        Me.deStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deStartDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deStartDate.Size = New System.Drawing.Size(362, 22)
        Me.deStartDate.StyleController = Me.LayoutControl1
        Me.deStartDate.TabIndex = 3
        Me.deStartDate.Tag = "ActDateStart"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.grpASHACT, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(997, 553)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'grpASHACT
        '
        Me.grpASHACT.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpASHACT.AppearanceGroup.Options.UseFont = True
        Me.grpASHACT.CustomizationFormText = "Ashore Activity"
        Me.grpASHACT.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.grpASHACT.ExpandButtonVisible = True
        Me.grpASHACT.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem11, Me.EmptySpaceItem1, Me.LayoutControlItem2})
        Me.grpASHACT.Location = New System.Drawing.Point(0, 0)
        Me.grpASHACT.Name = "grpASHACT"
        Me.grpASHACT.Size = New System.Drawing.Size(997, 209)
        Me.grpASHACT.Text = "Ashore Activity"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboNxtAct
        Me.LayoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem5.CustomizationFormText = "Next Activity:"
        Me.LayoutControlItem5.FillControlToClientArea = False
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Next Activity:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(117, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.cboStartPlace
        Me.LayoutControlItem13.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem13.CustomizationFormText = "Starting Place:"
        Me.LayoutControlItem13.FillControlToClientArea = False
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 33)
        Me.LayoutControlItem13.MaxSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem13.Text = "Starting Place:"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(117, 16)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.cboEndPlace
        Me.LayoutControlItem14.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem14.CustomizationFormText = "Ending Place:"
        Me.LayoutControlItem14.FillControlToClientArea = False
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 66)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "Ending Place:"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(117, 16)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.deStartDate
        Me.LayoutControlItem11.ControlAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LayoutControlItem11.CustomizationFormText = "Activity Start Date:"
        Me.LayoutControlItem11.FillControlToClientArea = False
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 99)
        Me.LayoutControlItem11.MaxSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(486, 33)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.Text = "Activity Start Date:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(117, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(486, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(487, 158)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboWScale
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 132)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(486, 26)
        Me.LayoutControlItem2.Text = "Ashore Wage Scale:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(117, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Maingrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 209)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(997, 344)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'AshoreActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "AshoreActivity"
        Me.Size = New System.Drawing.Size(997, 553)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboWScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WageScaleRankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AshoreStatusEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNxtAct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStartPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEndPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpASHACT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboNxtAct As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboStartPlace As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboEndPlace As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents grpASHACT As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ActGrpID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GenericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents PortEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents NextActivity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AshoreStatusEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents FkeyRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StartPlace As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents EndPlace As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboWScale As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents WageScaleRankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents FKeyWScaleRank As DevExpress.XtraGrid.Columns.GridColumn

End Class
