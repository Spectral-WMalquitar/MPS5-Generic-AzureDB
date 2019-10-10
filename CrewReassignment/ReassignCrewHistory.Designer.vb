<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReassignCrewHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReassignCrewHistory))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SplitContainer_History = New System.Windows.Forms.SplitContainer()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.RequestGrid = New DevExpress.XtraGrid.GridControl()
        Me.RequestView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rDateRequested = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rCrew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rReassignToAgentName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rReassignToVslName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rRepAction = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.rActionAppliedByName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rActionRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rEffectivityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rReassignToAgent = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.rReassignToVsl = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LayoutControlGroup_Request = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.ConfirmGrid = New DevExpress.XtraGrid.GridControl()
        Me.ConfirmView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cDateConfirmed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cCrew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cReassignToAgentName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cReassignToVslName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cRequestedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cRepAction = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cEffectivityDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cActionRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cReassignToAgent = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cReassignToVsl = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LayoutControlGroup_Confirm = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Overall = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SplitContainer_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_History.Panel1.SuspendLayout()
        Me.SplitContainer_History.Panel2.SuspendLayout()
        Me.SplitContainer_History.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.RequestGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RequestView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rRepAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rReassignToAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rReassignToVsl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Request, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.ConfirmGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConfirmView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cRepAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cReassignToAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cReassignToVsl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Confirm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Overall, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(985, 575)
        Me.header.TabIndex = 0
        Me.header.Text = "Crew Reassignment Request/Confirmation History"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SplitContainer_History)
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
        Me.LayoutControl1.Root = Me.LayoutControlGroup_Overall
        Me.LayoutControl1.Size = New System.Drawing.Size(981, 547)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SplitContainer_History
        '
        Me.SplitContainer_History.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer_History.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer_History.Name = "SplitContainer_History"
        Me.SplitContainer_History.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_History.Panel1
        '
        Me.SplitContainer_History.Panel1.Controls.Add(Me.LayoutControl2)
        '
        'SplitContainer_History.Panel2
        '
        Me.SplitContainer_History.Panel2.Controls.Add(Me.LayoutControl3)
        Me.SplitContainer_History.Size = New System.Drawing.Size(957, 523)
        Me.SplitContainer_History.SplitterDistance = 299
        Me.SplitContainer_History.TabIndex = 4
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.RequestGrid)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
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
        Me.LayoutControl2.Root = Me.LayoutControlGroup_Request
        Me.LayoutControl2.Size = New System.Drawing.Size(955, 297)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'RequestGrid
        '
        Me.RequestGrid.Location = New System.Drawing.Point(12, 36)
        Me.RequestGrid.MainView = Me.RequestView
        Me.RequestGrid.Name = "RequestGrid"
        Me.RequestGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rRepAction, Me.rReassignToAgent, Me.rReassignToVsl})
        Me.RequestGrid.Size = New System.Drawing.Size(931, 249)
        Me.RequestGrid.TabIndex = 4
        Me.RequestGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.RequestView})
        '
        'RequestView
        '
        Me.RequestView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.rDateRequested, Me.rCrew, Me.rRank, Me.rReassignToAgentName, Me.rReassignToVslName, Me.rRemarks, Me.rStatus, Me.rActionAppliedByName, Me.rActionRemarks, Me.rEffectivityDate})
        Me.RequestView.GridControl = Me.RequestGrid
        Me.RequestView.Name = "RequestView"
        Me.RequestView.OptionsFind.AlwaysVisible = True
        Me.RequestView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.RequestView.OptionsView.RowAutoHeight = True
        Me.RequestView.OptionsView.ShowGroupPanel = False
        Me.RequestView.RowHeight = 30
        '
        'rDateRequested
        '
        Me.rDateRequested.Caption = "Date Requested"
        Me.rDateRequested.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.rDateRequested.FieldName = "CrewReassignmentDate"
        Me.rDateRequested.Name = "rDateRequested"
        Me.rDateRequested.OptionsColumn.ReadOnly = True
        Me.rDateRequested.Visible = True
        Me.rDateRequested.VisibleIndex = 0
        Me.rDateRequested.Width = 85
        '
        'rCrew
        '
        Me.rCrew.Caption = "Crew"
        Me.rCrew.FieldName = "Crew"
        Me.rCrew.Name = "rCrew"
        Me.rCrew.OptionsColumn.ReadOnly = True
        Me.rCrew.Visible = True
        Me.rCrew.VisibleIndex = 1
        Me.rCrew.Width = 85
        '
        'rRank
        '
        Me.rRank.Caption = "Rank"
        Me.rRank.FieldName = "Rank"
        Me.rRank.Name = "rRank"
        Me.rRank.OptionsColumn.ReadOnly = True
        Me.rRank.Visible = True
        Me.rRank.VisibleIndex = 2
        Me.rRank.Width = 63
        '
        'rReassignToAgentName
        '
        Me.rReassignToAgentName.Caption = "Reassign To Agent"
        Me.rReassignToAgentName.FieldName = "ReassignToAgentName"
        Me.rReassignToAgentName.Name = "rReassignToAgentName"
        Me.rReassignToAgentName.OptionsColumn.ReadOnly = True
        Me.rReassignToAgentName.Visible = True
        Me.rReassignToAgentName.VisibleIndex = 3
        Me.rReassignToAgentName.Width = 88
        '
        'rReassignToVslName
        '
        Me.rReassignToVslName.Caption = "Reassign To Vessel"
        Me.rReassignToVslName.FieldName = "ReassignToVslName"
        Me.rReassignToVslName.Name = "rReassignToVslName"
        Me.rReassignToVslName.OptionsColumn.ReadOnly = True
        Me.rReassignToVslName.Visible = True
        Me.rReassignToVslName.VisibleIndex = 4
        Me.rReassignToVslName.Width = 88
        '
        'rRemarks
        '
        Me.rRemarks.Caption = "Remarks"
        Me.rRemarks.FieldName = "Remarks"
        Me.rRemarks.Name = "rRemarks"
        Me.rRemarks.OptionsColumn.ReadOnly = True
        Me.rRemarks.Visible = True
        Me.rRemarks.VisibleIndex = 5
        Me.rRemarks.Width = 88
        '
        'rStatus
        '
        Me.rStatus.Caption = "Status"
        Me.rStatus.ColumnEdit = Me.rRepAction
        Me.rStatus.FieldName = "ActionCode"
        Me.rStatus.Name = "rStatus"
        Me.rStatus.OptionsColumn.ReadOnly = True
        Me.rStatus.Visible = True
        Me.rStatus.VisibleIndex = 6
        Me.rStatus.Width = 88
        '
        'rRepAction
        '
        Me.rRepAction.AutoHeight = False
        Me.rRepAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.rRepAction.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.rRepAction.DisplayMember = "Name"
        Me.rRepAction.Name = "rRepAction"
        Me.rRepAction.NullText = ""
        Me.rRepAction.ValueMember = "PKey"
        '
        'rActionAppliedByName
        '
        Me.rActionAppliedByName.Caption = "Approved/Rejected By"
        Me.rActionAppliedByName.FieldName = "ActionAppliedByName"
        Me.rActionAppliedByName.Name = "rActionAppliedByName"
        Me.rActionAppliedByName.Visible = True
        Me.rActionAppliedByName.VisibleIndex = 7
        '
        'rActionRemarks
        '
        Me.rActionRemarks.Caption = "Action Remarks"
        Me.rActionRemarks.FieldName = "ActionRemarks"
        Me.rActionRemarks.Name = "rActionRemarks"
        Me.rActionRemarks.OptionsColumn.ReadOnly = True
        Me.rActionRemarks.Visible = True
        Me.rActionRemarks.VisibleIndex = 8
        Me.rActionRemarks.Width = 88
        '
        'rEffectivityDate
        '
        Me.rEffectivityDate.Caption = "Effectivity Date"
        Me.rEffectivityDate.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.rEffectivityDate.FieldName = "EffectivityDate"
        Me.rEffectivityDate.Name = "rEffectivityDate"
        Me.rEffectivityDate.OptionsColumn.ReadOnly = True
        Me.rEffectivityDate.Visible = True
        Me.rEffectivityDate.VisibleIndex = 9
        Me.rEffectivityDate.Width = 99
        '
        'rReassignToAgent
        '
        Me.rReassignToAgent.AutoHeight = False
        Me.rReassignToAgent.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.rReassignToAgent.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.rReassignToAgent.DisplayMember = "Name"
        Me.rReassignToAgent.Name = "rReassignToAgent"
        Me.rReassignToAgent.ValueMember = "PKey"
        '
        'rReassignToVsl
        '
        Me.rReassignToVsl.AutoHeight = False
        Me.rReassignToVsl.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.rReassignToVsl.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.rReassignToVsl.DisplayMember = "Name"
        Me.rReassignToVsl.Name = "rReassignToVsl"
        Me.rReassignToVsl.ValueMember = "PKey"
        '
        'LayoutControlGroup_Request
        '
        Me.LayoutControlGroup_Request.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup_Request.GroupBordersVisible = False
        Me.LayoutControlGroup_Request.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1})
        Me.LayoutControlGroup_Request.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Request.Name = "LayoutControlGroup_Request"
        Me.LayoutControlGroup_Request.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_Request.Size = New System.Drawing.Size(955, 297)
        Me.LayoutControlGroup_Request.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(955, 297)
        Me.LayoutControlGroup1.Text = "List of Your Request(s):"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.RequestGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(931, 249)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.ConfirmGrid)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
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
        Me.LayoutControl3.Root = Me.LayoutControlGroup_Confirm
        Me.LayoutControl3.Size = New System.Drawing.Size(955, 218)
        Me.LayoutControl3.TabIndex = 0
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'ConfirmGrid
        '
        Me.ConfirmGrid.Location = New System.Drawing.Point(14, 38)
        Me.ConfirmGrid.MainView = Me.ConfirmView
        Me.ConfirmGrid.Name = "ConfirmGrid"
        Me.ConfirmGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cRepAction, Me.cReassignToAgent, Me.cReassignToVsl})
        Me.ConfirmGrid.Size = New System.Drawing.Size(927, 166)
        Me.ConfirmGrid.TabIndex = 4
        Me.ConfirmGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ConfirmView})
        '
        'ConfirmView
        '
        Me.ConfirmView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cDateConfirmed, Me.cCrew, Me.cRank, Me.cReassignToAgentName, Me.cReassignToVslName, Me.cRemarks, Me.cRequestedBy, Me.cAction, Me.cEffectivityDate, Me.cActionRemarks})
        Me.ConfirmView.GridControl = Me.ConfirmGrid
        Me.ConfirmView.Name = "ConfirmView"
        Me.ConfirmView.OptionsFind.AlwaysVisible = True
        Me.ConfirmView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ConfirmView.OptionsView.RowAutoHeight = True
        Me.ConfirmView.OptionsView.ShowGroupPanel = False
        Me.ConfirmView.RowHeight = 30
        '
        'cDateConfirmed
        '
        Me.cDateConfirmed.Caption = "Date Confirmed/Rejected"
        Me.cDateConfirmed.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.cDateConfirmed.FieldName = "CrewReassignmentDate"
        Me.cDateConfirmed.Name = "cDateConfirmed"
        Me.cDateConfirmed.OptionsColumn.ReadOnly = True
        Me.cDateConfirmed.Visible = True
        Me.cDateConfirmed.VisibleIndex = 0
        Me.cDateConfirmed.Width = 76
        '
        'cCrew
        '
        Me.cCrew.Caption = "Crew"
        Me.cCrew.FieldName = "Crew"
        Me.cCrew.Name = "cCrew"
        Me.cCrew.OptionsColumn.ReadOnly = True
        Me.cCrew.Visible = True
        Me.cCrew.VisibleIndex = 1
        Me.cCrew.Width = 76
        '
        'cRank
        '
        Me.cRank.Caption = "Rank"
        Me.cRank.FieldName = "Rank"
        Me.cRank.Name = "cRank"
        Me.cRank.OptionsColumn.ReadOnly = True
        Me.cRank.Visible = True
        Me.cRank.VisibleIndex = 2
        Me.cRank.Width = 64
        '
        'cReassignToAgentName
        '
        Me.cReassignToAgentName.Caption = "Reassign To Agent"
        Me.cReassignToAgentName.FieldName = "ReassignToAgentName"
        Me.cReassignToAgentName.Name = "cReassignToAgentName"
        Me.cReassignToAgentName.OptionsColumn.ReadOnly = True
        Me.cReassignToAgentName.Visible = True
        Me.cReassignToAgentName.VisibleIndex = 3
        Me.cReassignToAgentName.Width = 77
        '
        'cReassignToVslName
        '
        Me.cReassignToVslName.Caption = "Reassign To Vessel"
        Me.cReassignToVslName.FieldName = "ReassignToVslName"
        Me.cReassignToVslName.Name = "cReassignToVslName"
        Me.cReassignToVslName.OptionsColumn.ReadOnly = True
        Me.cReassignToVslName.Visible = True
        Me.cReassignToVslName.VisibleIndex = 4
        Me.cReassignToVslName.Width = 77
        '
        'cRemarks
        '
        Me.cRemarks.Caption = "Remarks"
        Me.cRemarks.FieldName = "Remarks"
        Me.cRemarks.Name = "cRemarks"
        Me.cRemarks.Visible = True
        Me.cRemarks.VisibleIndex = 5
        Me.cRemarks.Width = 77
        '
        'cRequestedBy
        '
        Me.cRequestedBy.Caption = "Requested By"
        Me.cRequestedBy.FieldName = "RequestedByName"
        Me.cRequestedBy.Name = "cRequestedBy"
        Me.cRequestedBy.OptionsColumn.ReadOnly = True
        Me.cRequestedBy.Visible = True
        Me.cRequestedBy.VisibleIndex = 6
        Me.cRequestedBy.Width = 77
        '
        'cAction
        '
        Me.cAction.Caption = "Status"
        Me.cAction.ColumnEdit = Me.cRepAction
        Me.cAction.FieldName = "ActionCode"
        Me.cAction.Name = "cAction"
        Me.cAction.OptionsColumn.ReadOnly = True
        Me.cAction.Visible = True
        Me.cAction.VisibleIndex = 7
        Me.cAction.Width = 77
        '
        'cRepAction
        '
        Me.cRepAction.AutoHeight = False
        Me.cRepAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cRepAction.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cRepAction.DisplayMember = "Name"
        Me.cRepAction.Name = "cRepAction"
        Me.cRepAction.ValueMember = "PKey"
        '
        'cEffectivityDate
        '
        Me.cEffectivityDate.Caption = "Effectivity Date"
        Me.cEffectivityDate.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.cEffectivityDate.FieldName = "EffectivityDate"
        Me.cEffectivityDate.Name = "cEffectivityDate"
        Me.cEffectivityDate.OptionsColumn.ReadOnly = True
        Me.cEffectivityDate.Visible = True
        Me.cEffectivityDate.VisibleIndex = 8
        Me.cEffectivityDate.Width = 77
        '
        'cActionRemarks
        '
        Me.cActionRemarks.Caption = "Remarks/Reason"
        Me.cActionRemarks.FieldName = "ActionRemarks"
        Me.cActionRemarks.Name = "cActionRemarks"
        Me.cActionRemarks.OptionsColumn.ReadOnly = True
        Me.cActionRemarks.Visible = True
        Me.cActionRemarks.VisibleIndex = 9
        Me.cActionRemarks.Width = 90
        '
        'cReassignToAgent
        '
        Me.cReassignToAgent.AutoHeight = False
        Me.cReassignToAgent.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cReassignToAgent.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cReassignToAgent.DisplayMember = "Name"
        Me.cReassignToAgent.Name = "cReassignToAgent"
        Me.cReassignToAgent.NullText = ""
        Me.cReassignToAgent.ValueMember = "PKey"
        '
        'cReassignToVsl
        '
        Me.cReassignToVsl.AutoHeight = False
        Me.cReassignToVsl.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cReassignToVsl.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cReassignToVsl.DisplayMember = "Name"
        Me.cReassignToVsl.Name = "cReassignToVsl"
        Me.cReassignToVsl.NullText = ""
        Me.cReassignToVsl.ValueMember = "PKey"
        '
        'LayoutControlGroup_Confirm
        '
        Me.LayoutControlGroup_Confirm.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup_Confirm.GroupBordersVisible = False
        Me.LayoutControlGroup_Confirm.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup_Confirm.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Confirm.Name = "LayoutControlGroup_Confirm"
        Me.LayoutControlGroup_Confirm.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_Confirm.Size = New System.Drawing.Size(955, 218)
        Me.LayoutControlGroup_Confirm.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(955, 218)
        Me.LayoutControlGroup2.Text = "List of Request(s) You Confirmed/Rejected:"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ConfirmGrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(931, 170)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup_Overall
        '
        Me.LayoutControlGroup_Overall.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup_Overall.GroupBordersVisible = False
        Me.LayoutControlGroup_Overall.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup_Overall.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Overall.Name = "LayoutControlGroup_Overall"
        Me.LayoutControlGroup_Overall.Size = New System.Drawing.Size(981, 547)
        Me.LayoutControlGroup_Overall.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SplitContainer_History
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(961, 527)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'ReassignCrewHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "ReassignCrewHistory"
        Me.Size = New System.Drawing.Size(985, 575)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        Me.SplitContainer_History.Panel1.ResumeLayout(False)
        Me.SplitContainer_History.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_History.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.RequestGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RequestView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rRepAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rReassignToAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rReassignToVsl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Request, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.ConfirmGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConfirmView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cRepAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cReassignToAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cReassignToVsl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Confirm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Overall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SplitContainer_History As System.Windows.Forms.SplitContainer
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RequestGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents RequestView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup_Request As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ConfirmGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ConfirmView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup_Confirm As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_Overall As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents rCrew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rReassignToAgentName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rReassignToVslName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rActionRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rEffectivityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rRepAction As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rDateRequested As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cDateConfirmed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cCrew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cReassignToAgentName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cReassignToVslName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cRequestedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cEffectivityDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cActionRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cRepAction As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rReassignToAgent As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rReassignToVsl As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cReassignToAgent As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cReassignToVsl As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rActionAppliedByName As DevExpress.XtraGrid.Columns.GridColumn

End Class
