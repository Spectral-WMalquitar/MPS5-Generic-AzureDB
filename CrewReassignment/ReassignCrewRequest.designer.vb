<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReassignCrewRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReassignCrewRequest))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtRequestedByName = New DevExpress.XtraEditors.TextEdit()
        Me.txtDateRequested = New DevExpress.XtraEditors.DateEdit()
        Me.txtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CrewListSelectedGrid = New DevExpress.XtraGrid.GridControl()
        Me.CrewListSelected = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colSelCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSelRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSelAgentReassign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repAgent = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSelVslAssign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repVsl = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSelRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSelAgent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSelPrin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSelFlt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Action = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repAction = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ActionAppliedBy = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repActionAppliedBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSelPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSelIDNbr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Edited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CrewlistGrid = New DevExpress.XtraGrid.GridControl()
        Me.CrewList = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gbCrewList = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colAgent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPrin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFlt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colIDNbr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.genericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.txtRequestedByName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateRequested.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateRequested.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewListSelectedGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewListSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVsl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repActionAppliedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewlistGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(1202, 550)
        Me.header.TabIndex = 0
        Me.header.Text = "Crew Reassignment Transfer Request"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.LayoutControl2)
        Me.LayoutControl1.Controls.Add(Me.CrewlistGrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1198, 522)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.LayoutControl3)
        Me.LayoutControl2.Controls.Add(Me.CrewListSelectedGrid)
        Me.LayoutControl2.Location = New System.Drawing.Point(504, 12)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.Root = Me.Root
        Me.LayoutControl2.Size = New System.Drawing.Size(682, 498)
        Me.LayoutControl2.TabIndex = 6
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.txtRequestedByName)
        Me.LayoutControl3.Controls.Add(Me.txtDateRequested)
        Me.LayoutControl3.Controls.Add(Me.txtDescription)
        Me.LayoutControl3.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(116, 257, 250, 350)
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(658, 93)
        Me.LayoutControl3.TabIndex = 7
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'txtRequestedByName
        '
        Me.txtRequestedByName.Enabled = False
        Me.txtRequestedByName.Location = New System.Drawing.Point(94, 50)
        Me.txtRequestedByName.Name = "txtRequestedByName"
        Me.txtRequestedByName.Size = New System.Drawing.Size(562, 22)
        Me.txtRequestedByName.StyleController = Me.LayoutControl3
        Me.txtRequestedByName.TabIndex = 6
        Me.txtRequestedByName.Tag = "1"
        Me.txtRequestedByName.ToolTip = "Requested By"
        '
        'txtDateRequested
        '
        Me.txtDateRequested.EditValue = Nothing
        Me.txtDateRequested.Location = New System.Drawing.Point(94, 26)
        Me.txtDateRequested.Name = "txtDateRequested"
        Me.txtDateRequested.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateRequested.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateRequested.Size = New System.Drawing.Size(562, 22)
        Me.txtDateRequested.StyleController = Me.LayoutControl3
        Me.txtDateRequested.TabIndex = 5
        Me.txtDateRequested.Tag = "1"
        Me.txtDateRequested.ToolTip = "Request Date"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(94, 2)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(562, 22)
        Me.txtDescription.StyleController = Me.LayoutControl3
        Me.txtDescription.TabIndex = 4
        Me.txtDescription.Tag = "1"
        Me.txtDescription.ToolTip = "Description"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(658, 93)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtDescription
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(0, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(133, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(658, 24)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "*Description:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtDateRequested
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(0, 24)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(128, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(658, 24)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "*Request Date:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(89, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtRequestedByName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(133, 25)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(658, 45)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Requested By:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(89, 16)
        '
        'CrewListSelectedGrid
        '
        Me.CrewListSelectedGrid.AllowDrop = True
        Me.CrewListSelectedGrid.Location = New System.Drawing.Point(12, 109)
        Me.CrewListSelectedGrid.MainView = Me.CrewListSelected
        Me.CrewListSelectedGrid.Name = "CrewListSelectedGrid"
        Me.CrewListSelectedGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repVsl, Me.repAgent, Me.repAction, Me.repActionAppliedBy})
        Me.CrewListSelectedGrid.Size = New System.Drawing.Size(658, 377)
        Me.CrewListSelectedGrid.TabIndex = 6
        Me.CrewListSelectedGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CrewListSelected})
        '
        'CrewListSelected
        '
        Me.CrewListSelected.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.CrewListSelected.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colSelPKey, Me.colSelIDNbr, Me.colSelCrewName, Me.colSelRank, Me.colSelAgent, Me.colSelPrin, Me.colSelFlt, Me.colSelAgentReassign, Me.colSelVslAssign, Me.colSelRemarks, Me.Edited, Me.Action, Me.ActionAppliedBy})
        Me.CrewListSelected.GridControl = Me.CrewListSelectedGrid
        Me.CrewListSelected.Name = "CrewListSelected"
        Me.CrewListSelected.OptionsMenu.EnableColumnMenu = False
        Me.CrewListSelected.OptionsSelection.MultiSelect = True
        Me.CrewListSelected.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CrewListSelected.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.CrewListSelected.OptionsView.ShowGroupPanel = False
        Me.CrewListSelected.RowHeight = 30
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Selected Crew(s) To Be Requested for Reassignment"
        Me.GridBand1.Columns.Add(Me.colSelCrewName)
        Me.GridBand1.Columns.Add(Me.colSelRank)
        Me.GridBand1.Columns.Add(Me.colSelAgentReassign)
        Me.GridBand1.Columns.Add(Me.colSelVslAssign)
        Me.GridBand1.Columns.Add(Me.colSelRemarks)
        Me.GridBand1.Columns.Add(Me.colSelAgent)
        Me.GridBand1.Columns.Add(Me.colSelPrin)
        Me.GridBand1.Columns.Add(Me.colSelFlt)
        Me.GridBand1.Columns.Add(Me.Action)
        Me.GridBand1.Columns.Add(Me.ActionAppliedBy)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 540
        '
        'colSelCrewName
        '
        Me.colSelCrewName.Caption = "Crew Name"
        Me.colSelCrewName.FieldName = "CrewName"
        Me.colSelCrewName.Name = "colSelCrewName"
        Me.colSelCrewName.OptionsColumn.AllowEdit = False
        Me.colSelCrewName.Visible = True
        Me.colSelCrewName.Width = 103
        '
        'colSelRank
        '
        Me.colSelRank.Caption = "Rank"
        Me.colSelRank.FieldName = "Rank"
        Me.colSelRank.Name = "colSelRank"
        Me.colSelRank.OptionsColumn.AllowEdit = False
        Me.colSelRank.Visible = True
        Me.colSelRank.Width = 47
        '
        'colSelAgentReassign
        '
        Me.colSelAgentReassign.Caption = "Reassign To Agent"
        Me.colSelAgentReassign.ColumnEdit = Me.repAgent
        Me.colSelAgentReassign.FieldName = "ReassignToAgent"
        Me.colSelAgentReassign.Name = "colSelAgentReassign"
        Me.colSelAgentReassign.Visible = True
        Me.colSelAgentReassign.Width = 95
        '
        'repAgent
        '
        Me.repAgent.AutoHeight = False
        Me.repAgent.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAgent.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repAgent.DisplayMember = "Name"
        Me.repAgent.Name = "repAgent"
        Me.repAgent.NullText = ""
        Me.repAgent.ShowFooter = False
        Me.repAgent.ShowHeader = False
        Me.repAgent.ValueMember = "PKey"
        '
        'colSelVslAssign
        '
        Me.colSelVslAssign.Caption = "Reassign to Vessel"
        Me.colSelVslAssign.ColumnEdit = Me.repVsl
        Me.colSelVslAssign.FieldName = "ReassignToVsl"
        Me.colSelVslAssign.Name = "colSelVslAssign"
        Me.colSelVslAssign.Visible = True
        Me.colSelVslAssign.Width = 96
        '
        'repVsl
        '
        Me.repVsl.AutoHeight = False
        Me.repVsl.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repVsl.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repVsl.DisplayMember = "Name"
        Me.repVsl.Name = "repVsl"
        Me.repVsl.NullText = ""
        Me.repVsl.ShowFooter = False
        Me.repVsl.ShowHeader = False
        Me.repVsl.ValueMember = "PKey"
        '
        'colSelRemarks
        '
        Me.colSelRemarks.Caption = "Remarks"
        Me.colSelRemarks.FieldName = "Remarks"
        Me.colSelRemarks.Name = "colSelRemarks"
        Me.colSelRemarks.Visible = True
        Me.colSelRemarks.Width = 70
        '
        'colSelAgent
        '
        Me.colSelAgent.Caption = "Agent"
        Me.colSelAgent.FieldName = "AgentName"
        Me.colSelAgent.Name = "colSelAgent"
        Me.colSelAgent.OptionsColumn.AllowEdit = False
        Me.colSelAgent.Width = 85
        '
        'colSelPrin
        '
        Me.colSelPrin.Caption = "Principal"
        Me.colSelPrin.FieldName = "PrinName"
        Me.colSelPrin.Name = "colSelPrin"
        Me.colSelPrin.OptionsColumn.AllowEdit = False
        Me.colSelPrin.Width = 90
        '
        'colSelFlt
        '
        Me.colSelFlt.Caption = "Fleet"
        Me.colSelFlt.FieldName = "FltName"
        Me.colSelFlt.Name = "colSelFlt"
        Me.colSelFlt.OptionsColumn.AllowEdit = False
        Me.colSelFlt.Width = 91
        '
        'Action
        '
        Me.Action.Caption = "Status"
        Me.Action.ColumnEdit = Me.repAction
        Me.Action.FieldName = "ActionCode"
        Me.Action.Name = "Action"
        Me.Action.OptionsColumn.AllowEdit = False
        Me.Action.Visible = True
        Me.Action.Width = 60
        '
        'repAction
        '
        Me.repAction.AutoHeight = False
        Me.repAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAction.DisplayMember = "Action"
        Me.repAction.Name = "repAction"
        Me.repAction.NullText = ""
        Me.repAction.ShowFooter = False
        Me.repAction.ShowHeader = False
        Me.repAction.ValueMember = "ActionCode"
        '
        'ActionAppliedBy
        '
        Me.ActionAppliedBy.Caption = "Action Applied By"
        Me.ActionAppliedBy.ColumnEdit = Me.repActionAppliedBy
        Me.ActionAppliedBy.FieldName = "ActionAppliedBy"
        Me.ActionAppliedBy.Name = "ActionAppliedBy"
        Me.ActionAppliedBy.OptionsColumn.AllowEdit = False
        Me.ActionAppliedBy.Visible = True
        Me.ActionAppliedBy.Width = 69
        '
        'repActionAppliedBy
        '
        Me.repActionAppliedBy.AutoHeight = False
        Me.repActionAppliedBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repActionAppliedBy.DisplayMember = "Name"
        Me.repActionAppliedBy.Name = "repActionAppliedBy"
        Me.repActionAppliedBy.NullText = ""
        Me.repActionAppliedBy.ValueMember = "ID"
        '
        'colSelPKey
        '
        Me.colSelPKey.Caption = "PKey"
        Me.colSelPKey.FieldName = "PKey"
        Me.colSelPKey.Name = "colSelPKey"
        Me.colSelPKey.OptionsColumn.AllowEdit = False
        Me.colSelPKey.Visible = True
        '
        'colSelIDNbr
        '
        Me.colSelIDNbr.Caption = "IDNbr"
        Me.colSelIDNbr.FieldName = "IDNbr"
        Me.colSelIDNbr.Name = "colSelIDNbr"
        Me.colSelIDNbr.OptionsColumn.AllowEdit = False
        Me.colSelIDNbr.OptionsColumn.ReadOnly = True
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        Me.Edited.Visible = True
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem5})
        Me.Root.Location = New System.Drawing.Point(0, 0)
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(682, 498)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CrewListSelectedGrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 97)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(662, 381)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LayoutControl3
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(662, 97)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'CrewlistGrid
        '
        Me.CrewlistGrid.AllowDrop = True
        Me.CrewlistGrid.Enabled = False
        Me.CrewlistGrid.Location = New System.Drawing.Point(12, 12)
        Me.CrewlistGrid.MainView = Me.CrewList
        Me.CrewlistGrid.Name = "CrewlistGrid"
        Me.CrewlistGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.genericDateEdit})
        Me.CrewlistGrid.Size = New System.Drawing.Size(488, 498)
        Me.CrewlistGrid.TabIndex = 5
        Me.CrewlistGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CrewList})
        '
        'CrewList
        '
        Me.CrewList.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gbCrewList})
        Me.CrewList.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colIDNbr, Me.colCrewName, Me.colRank, Me.colAgent, Me.colPrin, Me.colFlt})
        Me.CrewList.GridControl = Me.CrewlistGrid
        Me.CrewList.Name = "CrewList"
        Me.CrewList.OptionsBehavior.Editable = False
        Me.CrewList.OptionsBehavior.ReadOnly = True
        Me.CrewList.OptionsFind.AlwaysVisible = True
        Me.CrewList.OptionsMenu.EnableColumnMenu = False
        Me.CrewList.OptionsSelection.MultiSelect = True
        Me.CrewList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.CrewList.OptionsView.ShowGroupPanel = False
        '
        'gbCrewList
        '
        Me.gbCrewList.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCrewList.AppearanceHeader.Options.UseFont = True
        Me.gbCrewList.Caption = "All (Ashore) Crews From Other Users"
        Me.gbCrewList.Columns.Add(Me.colCrewName)
        Me.gbCrewList.Columns.Add(Me.colRank)
        Me.gbCrewList.Columns.Add(Me.colAgent)
        Me.gbCrewList.Columns.Add(Me.colPrin)
        Me.gbCrewList.Columns.Add(Me.colFlt)
        Me.gbCrewList.Name = "gbCrewList"
        Me.gbCrewList.VisibleIndex = 0
        Me.gbCrewList.Width = 474
        '
        'colCrewName
        '
        Me.colCrewName.Caption = "Crew Name"
        Me.colCrewName.FieldName = "CrewName"
        Me.colCrewName.Name = "colCrewName"
        Me.colCrewName.Visible = True
        Me.colCrewName.Width = 153
        '
        'colRank
        '
        Me.colRank.Caption = "Rank"
        Me.colRank.FieldName = "Rank"
        Me.colRank.Name = "colRank"
        Me.colRank.Visible = True
        Me.colRank.Width = 55
        '
        'colAgent
        '
        Me.colAgent.Caption = "Agent"
        Me.colAgent.FieldName = "AgentName"
        Me.colAgent.Name = "colAgent"
        Me.colAgent.Visible = True
        Me.colAgent.Width = 85
        '
        'colPrin
        '
        Me.colPrin.Caption = "Principal"
        Me.colPrin.FieldName = "PrinName"
        Me.colPrin.Name = "colPrin"
        Me.colPrin.Visible = True
        Me.colPrin.Width = 90
        '
        'colFlt
        '
        Me.colFlt.Caption = "Fleet"
        Me.colFlt.FieldName = "FltName"
        Me.colFlt.Name = "colFlt"
        Me.colFlt.Visible = True
        Me.colFlt.Width = 91
        '
        'colIDNbr
        '
        Me.colIDNbr.Caption = "IDNbr"
        Me.colIDNbr.FieldName = "IDNbr"
        Me.colIDNbr.Name = "colIDNbr"
        '
        'genericDateEdit
        '
        Me.genericDateEdit.AutoHeight = False
        Me.genericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.Name = "genericDateEdit"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1198, 522)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CrewlistGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(492, 502)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.LayoutControl2
        Me.LayoutControlItem2.Location = New System.Drawing.Point(492, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(686, 502)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'ReassignCrewRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "ReassignCrewRequest"
        Me.Size = New System.Drawing.Size(1202, 550)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.txtRequestedByName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateRequested.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateRequested.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewListSelectedGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewListSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVsl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repActionAppliedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewlistGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CrewlistGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CrewList As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents colCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colIDNbr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents genericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colAgent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPrin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colFlt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CrewListSelectedGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CrewListSelected As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents colSelCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSelRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSelAgent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSelPrin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSelFlt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSelIDNbr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSelVslAssign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repVsl As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gbCrewList As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtDateRequested As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colSelRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colSelAgentReassign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repAgent As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colSelPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents txtRequestedByName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Action As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ActionAppliedBy As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repAction As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repActionAppliedBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

End Class
