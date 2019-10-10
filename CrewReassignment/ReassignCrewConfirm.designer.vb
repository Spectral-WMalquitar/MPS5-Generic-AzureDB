<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReassignCrewConfirm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReassignCrewConfirm))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colSelPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colAgentReassign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVslAssign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRemarksRequest = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colAgent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPrin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFlt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRequestedBy = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateRequested = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRecentActivity = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colActionCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repAction = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colEffectivityDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repEffectivityDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colActionRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colGroupColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colIDNbr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Edited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colReassignToAgent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colReassignToVsl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRecentActivityDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repDateEdit_ReadOnly = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.repTextEdit_ReadOnly = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repEffectivityDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repEffectivityDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit_ReadOnly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit_ReadOnly.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repTextEdit_ReadOnly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(1402, 495)
        Me.header.TabIndex = 0
        Me.header.Text = "Crew Reassignment Transfer Confirmation"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1398, 467)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'MainGrid
        '
        Me.MainGrid.AllowDrop = True
        Me.MainGrid.Location = New System.Drawing.Point(2, 2)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repAction, Me.repEffectivityDate, Me.repDateEdit_ReadOnly, Me.repTextEdit_ReadOnly, Me.repMemoEdit})
        Me.MainGrid.Size = New System.Drawing.Size(1394, 463)
        Me.MainGrid.TabIndex = 7
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colSelPKey, Me.colIDNbr, Me.colCrewName, Me.colRank, Me.colAgent, Me.colPrin, Me.colFlt, Me.colAgentReassign, Me.colVslAssign, Me.colRemarksRequest, Me.Edited, Me.colActionCode, Me.colActionRemarks, Me.colGroupColumn, Me.colRequestedBy, Me.colDateRequested, Me.colReassignToAgent, Me.colReassignToVsl, Me.colRecentActivity, Me.colRecentActivityDate, Me.colEffectivityDate})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsMenu.EnableColumnMenu = False
        Me.MainView.OptionsSelection.MultiSelect = True
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.RowHeight = 40
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "List of Crew(s) Requested for Reassignment"
        Me.GridBand1.Columns.Add(Me.colSelPKey)
        Me.GridBand1.Columns.Add(Me.colCrewName)
        Me.GridBand1.Columns.Add(Me.colRank)
        Me.GridBand1.Columns.Add(Me.colAgentReassign)
        Me.GridBand1.Columns.Add(Me.colVslAssign)
        Me.GridBand1.Columns.Add(Me.colRemarksRequest)
        Me.GridBand1.Columns.Add(Me.colAgent)
        Me.GridBand1.Columns.Add(Me.colPrin)
        Me.GridBand1.Columns.Add(Me.colFlt)
        Me.GridBand1.Columns.Add(Me.colRequestedBy)
        Me.GridBand1.Columns.Add(Me.colDateRequested)
        Me.GridBand1.Columns.Add(Me.colRecentActivity)
        Me.GridBand1.Columns.Add(Me.colActionCode)
        Me.GridBand1.Columns.Add(Me.colEffectivityDate)
        Me.GridBand1.Columns.Add(Me.colActionRemarks)
        Me.GridBand1.Columns.Add(Me.colGroupColumn)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 1176
        '
        'colSelPKey
        '
        Me.colSelPKey.FieldName = "ReassignPKey"
        Me.colSelPKey.Name = "colSelPKey"
        Me.colSelPKey.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSelPKey.Width = 74
        '
        'colCrewName
        '
        Me.colCrewName.Caption = "Crew Name"
        Me.colCrewName.FieldName = "CrewName"
        Me.colCrewName.Name = "colCrewName"
        Me.colCrewName.OptionsColumn.AllowEdit = False
        Me.colCrewName.Visible = True
        Me.colCrewName.Width = 114
        '
        'colRank
        '
        Me.colRank.Caption = "Rank"
        Me.colRank.FieldName = "Rank"
        Me.colRank.Name = "colRank"
        Me.colRank.OptionsColumn.AllowEdit = False
        Me.colRank.Visible = True
        Me.colRank.Width = 87
        '
        'colAgentReassign
        '
        Me.colAgentReassign.Caption = "Reassign To Agent"
        Me.colAgentReassign.FieldName = "ReassignToAgentName"
        Me.colAgentReassign.Name = "colAgentReassign"
        Me.colAgentReassign.OptionsColumn.AllowEdit = False
        Me.colAgentReassign.Visible = True
        Me.colAgentReassign.Width = 114
        '
        'colVslAssign
        '
        Me.colVslAssign.Caption = "Reassign to Vessel"
        Me.colVslAssign.FieldName = "ReassignToVslName"
        Me.colVslAssign.Name = "colVslAssign"
        Me.colVslAssign.OptionsColumn.AllowEdit = False
        Me.colVslAssign.Visible = True
        Me.colVslAssign.Width = 120
        '
        'colRemarksRequest
        '
        Me.colRemarksRequest.Caption = "Remarks"
        Me.colRemarksRequest.ColumnEdit = Me.repMemoEdit
        Me.colRemarksRequest.FieldName = "Remarks"
        Me.colRemarksRequest.Name = "colRemarksRequest"
        Me.colRemarksRequest.OptionsColumn.AllowEdit = False
        Me.colRemarksRequest.Visible = True
        Me.colRemarksRequest.Width = 117
        '
        'repMemoEdit
        '
        Me.repMemoEdit.Name = "repMemoEdit"
        '
        'colAgent
        '
        Me.colAgent.Caption = "Agent"
        Me.colAgent.FieldName = "AgentName"
        Me.colAgent.Name = "colAgent"
        Me.colAgent.OptionsColumn.AllowEdit = False
        Me.colAgent.Width = 85
        '
        'colPrin
        '
        Me.colPrin.Caption = "Principal"
        Me.colPrin.FieldName = "PrinName"
        Me.colPrin.Name = "colPrin"
        Me.colPrin.OptionsColumn.AllowEdit = False
        Me.colPrin.Width = 90
        '
        'colFlt
        '
        Me.colFlt.Caption = "Fleet"
        Me.colFlt.FieldName = "FltName"
        Me.colFlt.Name = "colFlt"
        Me.colFlt.OptionsColumn.AllowEdit = False
        Me.colFlt.Width = 91
        '
        'colRequestedBy
        '
        Me.colRequestedBy.Caption = "Requested By"
        Me.colRequestedBy.FieldName = "RequestedByName"
        Me.colRequestedBy.Name = "colRequestedBy"
        Me.colRequestedBy.OptionsColumn.AllowEdit = False
        Me.colRequestedBy.Visible = True
        Me.colRequestedBy.Width = 80
        '
        'colDateRequested
        '
        Me.colDateRequested.Caption = "Date Requested"
        Me.colDateRequested.FieldName = "DateRequested"
        Me.colDateRequested.Name = "colDateRequested"
        Me.colDateRequested.OptionsColumn.AllowEdit = False
        Me.colDateRequested.Visible = True
        Me.colDateRequested.Width = 83
        '
        'colRecentActivity
        '
        Me.colRecentActivity.Caption = "Recent Activity"
        Me.colRecentActivity.FieldName = "RecentActivity"
        Me.colRecentActivity.Name = "colRecentActivity"
        Me.colRecentActivity.Visible = True
        Me.colRecentActivity.Width = 132
        '
        'colActionCode
        '
        Me.colActionCode.Caption = "Action"
        Me.colActionCode.ColumnEdit = Me.repAction
        Me.colActionCode.FieldName = "ActionCode"
        Me.colActionCode.Name = "colActionCode"
        Me.colActionCode.Visible = True
        '
        'repAction
        '
        Me.repAction.AutoHeight = False
        Me.repAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAction.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ActionID", "ActionID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Action", "Action")})
        Me.repAction.DisplayMember = "Action"
        Me.repAction.Name = "repAction"
        Me.repAction.NullText = ""
        Me.repAction.ShowFooter = False
        Me.repAction.ShowHeader = False
        Me.repAction.ValueMember = "ActionCode"
        '
        'colEffectivityDate
        '
        Me.colEffectivityDate.Caption = "Effectivity Date"
        Me.colEffectivityDate.ColumnEdit = Me.repEffectivityDate
        Me.colEffectivityDate.FieldName = "EffectivityDate"
        Me.colEffectivityDate.Name = "colEffectivityDate"
        Me.colEffectivityDate.Visible = True
        Me.colEffectivityDate.Width = 94
        '
        'repEffectivityDate
        '
        Me.repEffectivityDate.AutoHeight = False
        Me.repEffectivityDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repEffectivityDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repEffectivityDate.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.repEffectivityDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.repEffectivityDate.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.repEffectivityDate.Mask.EditMask = "dd-MMM-yyyy"
        Me.repEffectivityDate.Name = "repEffectivityDate"
        '
        'colActionRemarks
        '
        Me.colActionRemarks.Caption = "Reason/Remarks"
        Me.colActionRemarks.ColumnEdit = Me.repMemoEdit
        Me.colActionRemarks.FieldName = "ActionRemarks"
        Me.colActionRemarks.Name = "colActionRemarks"
        Me.colActionRemarks.Visible = True
        Me.colActionRemarks.Width = 160
        '
        'colGroupColumn
        '
        Me.colGroupColumn.Caption = "Request Info"
        Me.colGroupColumn.FieldName = "GroupColumn"
        Me.colGroupColumn.Name = "colGroupColumn"
        Me.colGroupColumn.Width = 72
        '
        'colIDNbr
        '
        Me.colIDNbr.Caption = "IDNbr"
        Me.colIDNbr.FieldName = "IDNbr"
        Me.colIDNbr.Name = "colIDNbr"
        Me.colIDNbr.OptionsColumn.AllowEdit = False
        Me.colIDNbr.OptionsColumn.ReadOnly = True
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        Me.Edited.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.Edited.Visible = True
        '
        'colReassignToAgent
        '
        Me.colReassignToAgent.Caption = "ReassignToAgent"
        Me.colReassignToAgent.FieldName = "ReassignToAgent"
        Me.colReassignToAgent.Name = "colReassignToAgent"
        Me.colReassignToAgent.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colReassignToAgent.Visible = True
        '
        'colReassignToVsl
        '
        Me.colReassignToVsl.Caption = "ReassignToVsl"
        Me.colReassignToVsl.FieldName = "ReassignToVsl"
        Me.colReassignToVsl.Name = "colReassignToVsl"
        Me.colReassignToVsl.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.colReassignToVsl.Visible = True
        '
        'colRecentActivityDate
        '
        Me.colRecentActivityDate.Caption = "Recent Activity Date"
        Me.colRecentActivityDate.FieldName = "RecentActivityDate"
        Me.colRecentActivityDate.Name = "colRecentActivityDate"
        '
        'repDateEdit_ReadOnly
        '
        Me.repDateEdit_ReadOnly.AutoHeight = False
        Me.repDateEdit_ReadOnly.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit_ReadOnly.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit_ReadOnly.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.repDateEdit_ReadOnly.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.repDateEdit_ReadOnly.Mask.EditMask = "dd-MMM-yyyy"
        Me.repDateEdit_ReadOnly.Name = "repDateEdit_ReadOnly"
        Me.repDateEdit_ReadOnly.ReadOnly = True
        '
        'repTextEdit_ReadOnly
        '
        Me.repTextEdit_ReadOnly.AutoHeight = False
        Me.repTextEdit_ReadOnly.Name = "repTextEdit_ReadOnly"
        Me.repTextEdit_ReadOnly.ReadOnly = True
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1398, 467)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MainGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1398, 467)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'ReassignCrewConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "ReassignCrewConfirm"
        Me.Size = New System.Drawing.Size(1402, 495)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repEffectivityDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repEffectivityDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit_ReadOnly.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit_ReadOnly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repTextEdit_ReadOnly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents colCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colAgentReassign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVslAssign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRemarksRequest As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colAgent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPrin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFlt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colIDNbr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colActionCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colActionRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repAction As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colGroupColumn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRequestedBy As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDateRequested As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSelPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colReassignToAgent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colReassignToVsl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colRecentActivity As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colEffectivityDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repEffectivityDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colRecentActivityDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repDateEdit_ReadOnly As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repTextEdit_ReadOnly As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents repMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

End Class
