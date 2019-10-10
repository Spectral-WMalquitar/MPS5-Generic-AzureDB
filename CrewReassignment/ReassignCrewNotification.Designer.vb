<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReassignCrewNotification
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdGotoConfirmation = New System.Windows.Forms.Button()
        Me.chkDoNotShowAgain = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Crew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReassignToAgent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repAgent = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ReassignToVsl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVsl = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ActionCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RequestedConfirmedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CrewReassignmentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.chkDoNotShowAgain.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVsl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.Controls.Add(Me.LayoutControl3)
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(4)
        Me.header.Name = "header"
        Me.header.ShowCaption = False
        Me.header.Size = New System.Drawing.Size(1245, 489)
        Me.header.TabIndex = 0
        Me.header.Text = "GroupControl1"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.cmdGotoConfirmation)
        Me.LayoutControl3.Controls.Add(Me.chkDoNotShowAgain)
        Me.LayoutControl3.Controls.Add(Me.cmdOk)
        Me.LayoutControl3.Controls.Add(Me.MainGrid)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(2, 2)
        Me.LayoutControl3.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(417, 179, 250, 350)
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
        Me.LayoutControl3.Root = Me.LayoutControlGroup3
        Me.LayoutControl3.Size = New System.Drawing.Size(1241, 485)
        Me.LayoutControl3.TabIndex = 2
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'cmdGotoConfirmation
        '
        Me.cmdGotoConfirmation.Location = New System.Drawing.Point(496, 401)
        Me.cmdGotoConfirmation.Name = "cmdGotoConfirmation"
        Me.cmdGotoConfirmation.Size = New System.Drawing.Size(253, 25)
        Me.cmdGotoConfirmation.TabIndex = 6
        Me.cmdGotoConfirmation.Text = "Go to Confirmation Form"
        Me.cmdGotoConfirmation.UseVisualStyleBackColor = True
        '
        'chkDoNotShowAgain
        '
        Me.chkDoNotShowAgain.Location = New System.Drawing.Point(2, 463)
        Me.chkDoNotShowAgain.Name = "chkDoNotShowAgain"
        Me.chkDoNotShowAgain.Properties.Caption = "Do not show again"
        Me.chkDoNotShowAgain.Size = New System.Drawing.Size(149, 20)
        Me.chkDoNotShowAgain.StyleController = Me.LayoutControl3
        Me.chkDoNotShowAgain.TabIndex = 5
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(496, 430)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(253, 29)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(2, 2)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repMemoEdit, Me.repAgent, Me.repVsl, Me.repStatus})
        Me.MainGrid.Size = New System.Drawing.Size(1237, 395)
        Me.MainGrid.TabIndex = 0
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GroupNo, Me.GroupDesc, Me.PKey, Me.Crew, Me.RankName, Me.ReassignToAgent, Me.ReassignToVsl, Me.ActionCode, Me.RequestedConfirmedBy, Me.CrewReassignmentDate, Me.Remarks})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.ReadOnly = True
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowRowSizing = True
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsView.ShowIndicator = False
        Me.MainView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.RowHeight = 40
        '
        'GroupNo
        '
        Me.GroupNo.Caption = "GroupNo"
        Me.GroupNo.FieldName = "GroupNo"
        Me.GroupNo.Name = "GroupNo"
        Me.GroupNo.OptionsColumn.AllowFocus = False
        '
        'GroupDesc
        '
        Me.GroupDesc.Caption = "Info"
        Me.GroupDesc.FieldName = "GroupDesc"
        Me.GroupDesc.Name = "GroupDesc"
        Me.GroupDesc.OptionsColumn.AllowFocus = False
        '
        'PKey
        '
        Me.PKey.Caption = "PKey"
        Me.PKey.FieldName = "PKey"
        Me.PKey.Name = "PKey"
        Me.PKey.OptionsColumn.AllowFocus = False
        '
        'Crew
        '
        Me.Crew.Caption = "Crew"
        Me.Crew.FieldName = "Crew"
        Me.Crew.Name = "Crew"
        Me.Crew.OptionsColumn.AllowFocus = False
        Me.Crew.Visible = True
        Me.Crew.VisibleIndex = 0
        Me.Crew.Width = 134
        '
        'RankName
        '
        Me.RankName.Caption = "Rank"
        Me.RankName.FieldName = "RankName"
        Me.RankName.Name = "RankName"
        Me.RankName.OptionsColumn.AllowFocus = False
        Me.RankName.Visible = True
        Me.RankName.VisibleIndex = 1
        '
        'ReassignToAgent
        '
        Me.ReassignToAgent.Caption = "Reassign to Agent"
        Me.ReassignToAgent.ColumnEdit = Me.repAgent
        Me.ReassignToAgent.FieldName = "ReassignToAgent"
        Me.ReassignToAgent.Name = "ReassignToAgent"
        Me.ReassignToAgent.OptionsColumn.AllowFocus = False
        Me.ReassignToAgent.Visible = True
        Me.ReassignToAgent.VisibleIndex = 2
        Me.ReassignToAgent.Width = 134
        '
        'repAgent
        '
        Me.repAgent.AutoHeight = False
        Me.repAgent.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAgent.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repAgent.DisplayMember = "Name"
        Me.repAgent.Name = "repAgent"
        Me.repAgent.NullText = ""
        Me.repAgent.ValueMember = "PKey"
        '
        'ReassignToVsl
        '
        Me.ReassignToVsl.Caption = "Reassign To Vessel"
        Me.ReassignToVsl.ColumnEdit = Me.repVsl
        Me.ReassignToVsl.FieldName = "ReassignToVsl"
        Me.ReassignToVsl.Name = "ReassignToVsl"
        Me.ReassignToVsl.OptionsColumn.AllowFocus = False
        Me.ReassignToVsl.Visible = True
        Me.ReassignToVsl.VisibleIndex = 3
        Me.ReassignToVsl.Width = 128
        '
        'repVsl
        '
        Me.repVsl.AutoHeight = False
        Me.repVsl.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repVsl.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repVsl.DisplayMember = "Name"
        Me.repVsl.Name = "repVsl"
        Me.repVsl.NullText = ""
        Me.repVsl.ValueMember = "PKey"
        '
        'ActionCode
        '
        Me.ActionCode.Caption = "Status"
        Me.ActionCode.ColumnEdit = Me.repStatus
        Me.ActionCode.FieldName = "ActionCode"
        Me.ActionCode.Name = "ActionCode"
        Me.ActionCode.OptionsColumn.AllowFocus = False
        Me.ActionCode.Visible = True
        Me.ActionCode.VisibleIndex = 4
        Me.ActionCode.Width = 93
        '
        'repStatus
        '
        Me.repStatus.AutoHeight = False
        Me.repStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repStatus.DisplayMember = "Name"
        Me.repStatus.Name = "repStatus"
        Me.repStatus.NullText = ""
        Me.repStatus.ValueMember = "PKey"
        '
        'RequestedConfirmedBy
        '
        Me.RequestedConfirmedBy.Caption = " "
        Me.RequestedConfirmedBy.FieldName = "RequestedConfirmedBy"
        Me.RequestedConfirmedBy.Name = "RequestedConfirmedBy"
        Me.RequestedConfirmedBy.OptionsColumn.AllowFocus = False
        Me.RequestedConfirmedBy.Visible = True
        Me.RequestedConfirmedBy.VisibleIndex = 5
        Me.RequestedConfirmedBy.Width = 148
        '
        'CrewReassignmentDate
        '
        Me.CrewReassignmentDate.Caption = "Date"
        Me.CrewReassignmentDate.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.CrewReassignmentDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CrewReassignmentDate.FieldName = "CrewReassignmentDate"
        Me.CrewReassignmentDate.Name = "CrewReassignmentDate"
        Me.CrewReassignmentDate.OptionsColumn.AllowFocus = False
        Me.CrewReassignmentDate.Visible = True
        Me.CrewReassignmentDate.VisibleIndex = 6
        Me.CrewReassignmentDate.Width = 86
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.ColumnEdit = Me.repMemoEdit
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.OptionsColumn.AllowFocus = False
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 7
        Me.Remarks.Width = 220
        '
        'repMemoEdit
        '
        Me.repMemoEdit.Name = "repMemoEdit"
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.EmptySpaceItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "Root"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1241, 485)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MainGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1241, 399)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdOk
        Me.LayoutControlItem2.Location = New System.Drawing.Point(494, 428)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(257, 33)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(257, 33)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(257, 33)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 399)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(494, 62)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(751, 399)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(490, 62)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.chkDoNotShowAgain
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 461)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(153, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(153, 461)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1088, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdGotoConfirmation
        Me.LayoutControlItem4.Location = New System.Drawing.Point(494, 399)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(257, 29)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Location = New System.Drawing.Point(185, 145)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(11, 10)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(20, 20)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'ReassignCrewNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 489)
        Me.ControlBox = False
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReassignCrewNotification"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NOTIFICATION: Crew Reassignment Request"
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.chkDoNotShowAgain.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVsl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GroupNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrewReassignmentDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents repMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Crew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReassignToAgent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repAgent As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repVsl As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RequestedConfirmedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkDoNotShowAgain As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ReassignToVsl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ActionCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents RankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdGotoConfirmation As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
