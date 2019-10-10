<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Promotion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Promotion))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VesselName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyWScaleRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WageScaleRankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.PromDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GenericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LCGPromotion = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WageScaleRankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LCGPromotion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.Maingrid)
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
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(936, 492)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Maingrid
        '
        Me.Maingrid.AllowDrop = True
        Me.Maingrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.RelationName = "Level1"
        Me.Maingrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.Maingrid.Location = New System.Drawing.Point(14, 37)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RankEdit, Me.WageScaleRankEdit, Me.GenericDateEdit})
        Me.Maingrid.Size = New System.Drawing.Size(908, 441)
        Me.Maingrid.TabIndex = 33
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDNbr, Me.CurrActID, Me.CrewName, Me.VesselName, Me.RankName, Me.FKeyRank, Me.FKeyWScaleRank, Me.PromDate, Me.Remarks, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
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
        'VesselName
        '
        Me.VesselName.Caption = "Current Vessel"
        Me.VesselName.FieldName = "VesselName"
        Me.VesselName.Name = "VesselName"
        Me.VesselName.OptionsColumn.AllowEdit = False
        Me.VesselName.OptionsColumn.AllowFocus = False
        Me.VesselName.OptionsColumn.ReadOnly = True
        Me.VesselName.Visible = True
        Me.VesselName.VisibleIndex = 1
        '
        'RankName
        '
        Me.RankName.Caption = "Current Rank"
        Me.RankName.FieldName = "RankName"
        Me.RankName.Name = "RankName"
        Me.RankName.OptionsColumn.AllowEdit = False
        Me.RankName.OptionsColumn.AllowFocus = False
        Me.RankName.OptionsColumn.ReadOnly = True
        Me.RankName.Visible = True
        Me.RankName.VisibleIndex = 2
        '
        'FKeyRank
        '
        Me.FKeyRank.Caption = "New Rank"
        Me.FKeyRank.ColumnEdit = Me.RankEdit
        Me.FKeyRank.FieldName = "FKeyRank"
        Me.FKeyRank.Name = "FKeyRank"
        Me.FKeyRank.Tag = "Required"
        Me.FKeyRank.Visible = True
        Me.FKeyRank.VisibleIndex = 3
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
        Me.FKeyWScaleRank.VisibleIndex = 4
        '
        'WageScaleRankEdit
        '
        Me.WageScaleRankEdit.AutoHeight = False
        Me.WageScaleRankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WageScaleRankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.WageScaleRankEdit.DisplayMember = "Name"
        Me.WageScaleRankEdit.Name = "WageScaleRankEdit"
        Me.WageScaleRankEdit.NullText = ""
        Me.WageScaleRankEdit.ShowFooter = False
        Me.WageScaleRankEdit.ShowHeader = False
        Me.WageScaleRankEdit.ValueMember = "PKey"
        '
        'PromDate
        '
        Me.PromDate.Caption = "Date of Promotion"
        Me.PromDate.ColumnEdit = Me.GenericDateEdit
        Me.PromDate.FieldName = "DateProm"
        Me.PromDate.Name = "PromDate"
        Me.PromDate.Tag = "Required"
        Me.PromDate.Visible = True
        Me.PromDate.VisibleIndex = 5
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
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "recent wscale rank code"
        Me.GridColumn1.FieldName = "FKeyWScaleRankCode"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "FKeyVslCode"
        Me.GridColumn2.FieldName = "FKeyVslCode"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LCGPromotion})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(936, 492)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LCGPromotion
        '
        Me.LCGPromotion.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCGPromotion.AppearanceGroup.Options.UseFont = True
        Me.LCGPromotion.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LCGPromotion.Location = New System.Drawing.Point(0, 0)
        Me.LCGPromotion.Name = "LCGPromotion"
        Me.LCGPromotion.Size = New System.Drawing.Size(936, 492)
        Me.LCGPromotion.Text = "Promotion"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Maingrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(912, 445)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Nat"
        Me.GridColumn3.FieldName = "Nat"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'Promotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Promotion"
        Me.Size = New System.Drawing.Size(936, 492)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WageScaleRankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LCGPromotion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents FKeyWScaleRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WageScaleRankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GenericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LCGPromotion As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PromDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VesselName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn

End Class
