<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdmKPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdmKPI))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridRetStat = New DevExpress.XtraGrid.GridControl()
        Me.GridRetStatView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colRetEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRetStat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRetStatType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRetStatType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colRetTermination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRetTermination = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colRetTermType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRetTerminationType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridStatus = New DevExpress.XtraGrid.GridControl()
        Me.GridStatusView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colStatusEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMapStat_Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatusName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatusAdmin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repAdmStat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colStatusType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repStatType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabAdmKPI = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.grpRetTermStatus = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.grpActivityStatus = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridRetStat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRetStatView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRetStatType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRetTermination, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRetTerminationType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridStatusView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAdmStat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repStatType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabAdmKPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpRetTermStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpActivityStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(1049, 610)
        Me.header.TabIndex = 0
        Me.header.Text = "KPI"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.Label2)
        Me.LayoutControl1.Controls.Add(Me.Label1)
        Me.LayoutControl1.Controls.Add(Me.GridRetStat)
        Me.LayoutControl1.Controls.Add(Me.GridStatus)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(471, 283, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1045, 582)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(26, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(993, 26)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "This maps out the Activities calculated in the KPI to the Admin Status items used" & _
    " in creating MPS Activities."
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(26, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(993, 26)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'GridRetStat
        '
        Me.GridRetStat.Location = New System.Drawing.Point(26, 83)
        Me.GridRetStat.MainView = Me.GridRetStatView
        Me.GridRetStat.Name = "GridRetStat"
        Me.GridRetStat.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repRetTermination, Me.repRetTerminationType, Me.repRetStatType})
        Me.GridRetStat.Size = New System.Drawing.Size(993, 471)
        Me.GridRetStat.TabIndex = 5
        Me.GridRetStat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridRetStatView})
        '
        'GridRetStatView
        '
        Me.GridRetStatView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colRetEdited, Me.colRetStat, Me.colRetStatType, Me.colRetTermination, Me.colRetTermType})
        Me.GridRetStatView.GridControl = Me.GridRetStat
        Me.GridRetStatView.Name = "GridRetStatView"
        Me.GridRetStatView.OptionsFind.AlwaysVisible = True
        Me.GridRetStatView.OptionsView.ShowGroupPanel = False
        '
        'colRetEdited
        '
        Me.colRetEdited.Caption = "Edited"
        Me.colRetEdited.FieldName = "Edited"
        Me.colRetEdited.Name = "colRetEdited"
        '
        'colRetStat
        '
        Me.colRetStat.Caption = "All Activity Status in the System"
        Me.colRetStat.FieldName = "Name"
        Me.colRetStat.Name = "colRetStat"
        Me.colRetStat.OptionsColumn.AllowEdit = False
        Me.colRetStat.OptionsColumn.AllowFocus = False
        Me.colRetStat.OptionsColumn.AllowMove = False
        Me.colRetStat.OptionsColumn.AllowShowHide = False
        Me.colRetStat.OptionsColumn.AllowSize = False
        Me.colRetStat.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colRetStat.OptionsColumn.FixedWidth = True
        Me.colRetStat.OptionsColumn.ReadOnly = True
        Me.colRetStat.Visible = True
        Me.colRetStat.VisibleIndex = 0
        '
        'colRetStatType
        '
        Me.colRetStatType.Caption = "Status Type"
        Me.colRetStatType.ColumnEdit = Me.repRetStatType
        Me.colRetStatType.FieldName = "StatType"
        Me.colRetStatType.Name = "colRetStatType"
        Me.colRetStatType.OptionsColumn.AllowEdit = False
        Me.colRetStatType.OptionsColumn.AllowFocus = False
        Me.colRetStatType.OptionsColumn.AllowMove = False
        Me.colRetStatType.OptionsColumn.AllowShowHide = False
        Me.colRetStatType.OptionsColumn.AllowSize = False
        Me.colRetStatType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colRetStatType.OptionsColumn.FixedWidth = True
        Me.colRetStatType.OptionsColumn.ReadOnly = True
        Me.colRetStatType.Visible = True
        Me.colRetStatType.VisibleIndex = 1
        '
        'repRetStatType
        '
        Me.repRetStatType.AutoHeight = False
        Me.repRetStatType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repRetStatType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatType", "StatType", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.repRetStatType.DisplayMember = "Name"
        Me.repRetStatType.Name = "repRetStatType"
        Me.repRetStatType.NullText = ""
        Me.repRetStatType.ShowFooter = False
        Me.repRetStatType.ShowHeader = False
        Me.repRetStatType.ValueMember = "PKey"
        '
        'colRetTermination
        '
        Me.colRetTermination.Caption = "Count as Termination in Retention Rate"
        Me.colRetTermination.ColumnEdit = Me.repRetTermination
        Me.colRetTermination.FieldName = "RetentionRateTermination"
        Me.colRetTermination.Name = "colRetTermination"
        Me.colRetTermination.OptionsColumn.AllowMove = False
        Me.colRetTermination.OptionsColumn.AllowShowHide = False
        Me.colRetTermination.OptionsColumn.AllowSize = False
        Me.colRetTermination.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colRetTermination.OptionsColumn.FixedWidth = True
        '
        'repRetTermination
        '
        Me.repRetTermination.AutoHeight = False
        Me.repRetTermination.Name = "repRetTermination"
        '
        'colRetTermType
        '
        Me.colRetTermType.Caption = "Set Retention Rate Termination Type"
        Me.colRetTermType.ColumnEdit = Me.repRetTerminationType
        Me.colRetTermType.FieldName = "TerminationType"
        Me.colRetTermType.Name = "colRetTermType"
        Me.colRetTermType.OptionsColumn.AllowMove = False
        Me.colRetTermType.OptionsColumn.AllowShowHide = False
        Me.colRetTermType.OptionsColumn.AllowSize = False
        Me.colRetTermType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.colRetTermType.OptionsColumn.FixedWidth = True
        Me.colRetTermType.Visible = True
        Me.colRetTermType.VisibleIndex = 2
        '
        'repRetTerminationType
        '
        Me.repRetTerminationType.AutoHeight = False
        Me.repRetTerminationType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repRetTerminationType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repRetTerminationType.DisplayMember = "Name"
        Me.repRetTerminationType.Name = "repRetTerminationType"
        Me.repRetTerminationType.NullText = ""
        Me.repRetTerminationType.ShowFooter = False
        Me.repRetTerminationType.ShowHeader = False
        Me.repRetTerminationType.ValueMember = "PKey"
        '
        'GridStatus
        '
        Me.GridStatus.Location = New System.Drawing.Point(26, 83)
        Me.GridStatus.MainView = Me.GridStatusView
        Me.GridStatus.Name = "GridStatus"
        Me.GridStatus.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repAdmStat, Me.repStatType})
        Me.GridStatus.Size = New System.Drawing.Size(993, 471)
        Me.GridStatus.TabIndex = 4
        Me.GridStatus.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridStatusView})
        '
        'GridStatusView
        '
        Me.GridStatusView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colStatusEdited, Me.colMapStat_Code, Me.colStatusName, Me.colStatusAdmin, Me.colStatusType})
        Me.GridStatusView.GridControl = Me.GridStatus
        Me.GridStatusView.Name = "GridStatusView"
        Me.GridStatusView.OptionsFind.AlwaysVisible = True
        Me.GridStatusView.OptionsView.ShowGroupPanel = False
        '
        'colStatusEdited
        '
        Me.colStatusEdited.Caption = "Edited"
        Me.colStatusEdited.FieldName = "Edited"
        Me.colStatusEdited.Name = "colStatusEdited"
        '
        'colMapStat_Code
        '
        Me.colMapStat_Code.Caption = "PKey"
        Me.colMapStat_Code.FieldName = "PKey"
        Me.colMapStat_Code.Name = "colMapStat_Code"
        '
        'colStatusName
        '
        Me.colStatusName.Caption = "Activtity Status Used In KPI"
        Me.colStatusName.FieldName = "Name"
        Me.colStatusName.Name = "colStatusName"
        Me.colStatusName.OptionsColumn.AllowEdit = False
        Me.colStatusName.OptionsColumn.AllowFocus = False
        Me.colStatusName.OptionsColumn.AllowMove = False
        Me.colStatusName.OptionsColumn.AllowShowHide = False
        Me.colStatusName.OptionsColumn.AllowSize = False
        Me.colStatusName.OptionsColumn.FixedWidth = True
        Me.colStatusName.OptionsColumn.ReadOnly = True
        Me.colStatusName.Visible = True
        Me.colStatusName.VisibleIndex = 0
        '
        'colStatusAdmin
        '
        Me.colStatusAdmin.Caption = "Value from Admin Status"
        Me.colStatusAdmin.ColumnEdit = Me.repAdmStat
        Me.colStatusAdmin.FieldName = "CriteriaFieldValue"
        Me.colStatusAdmin.Name = "colStatusAdmin"
        Me.colStatusAdmin.OptionsColumn.AllowMove = False
        Me.colStatusAdmin.OptionsColumn.AllowSize = False
        Me.colStatusAdmin.OptionsColumn.FixedWidth = True
        Me.colStatusAdmin.Visible = True
        Me.colStatusAdmin.VisibleIndex = 1
        '
        'repAdmStat
        '
        Me.repAdmStat.AutoHeight = False
        Me.repAdmStat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAdmStat.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repAdmStat.DisplayMember = "Name"
        Me.repAdmStat.Name = "repAdmStat"
        Me.repAdmStat.NullText = ""
        Me.repAdmStat.ShowFooter = False
        Me.repAdmStat.ShowHeader = False
        Me.repAdmStat.ValueMember = "PKey"
        '
        'colStatusType
        '
        Me.colStatusType.Caption = "Status Type"
        Me.colStatusType.ColumnEdit = Me.repStatType
        Me.colStatusType.FieldName = "StatType"
        Me.colStatusType.Name = "colStatusType"
        Me.colStatusType.OptionsColumn.AllowFocus = False
        Me.colStatusType.OptionsColumn.AllowMove = False
        Me.colStatusType.OptionsColumn.AllowSize = False
        Me.colStatusType.OptionsColumn.FixedWidth = True
        Me.colStatusType.OptionsColumn.ReadOnly = True
        Me.colStatusType.Visible = True
        Me.colStatusType.VisibleIndex = 2
        '
        'repStatType
        '
        Me.repStatType.AutoHeight = False
        Me.repStatType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repStatType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repStatType.DisplayMember = "Name"
        Me.repStatType.Name = "repStatType"
        Me.repStatType.NullText = ""
        Me.repStatType.ValueMember = "PKey"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabAdmKPI})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1045, 582)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'TabAdmKPI
        '
        Me.TabAdmKPI.Location = New System.Drawing.Point(0, 0)
        Me.TabAdmKPI.Name = "TabAdmKPI"
        Me.TabAdmKPI.SelectedTabPage = Me.grpRetTermStatus
        Me.TabAdmKPI.SelectedTabPageIndex = 1
        Me.TabAdmKPI.Size = New System.Drawing.Size(1023, 558)
        Me.TabAdmKPI.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.grpActivityStatus, Me.grpRetTermStatus})
        '
        'grpRetTermStatus
        '
        Me.grpRetTermStatus.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.grpRetTermStatus.Location = New System.Drawing.Point(0, 0)
        Me.grpRetTermStatus.Name = "grpRetTermStatus"
        Me.grpRetTermStatus.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.grpRetTermStatus.Size = New System.Drawing.Size(997, 505)
        Me.grpRetTermStatus.Text = "Retention Rate Termination Status"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridRetStat
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(997, 475)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.Label1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(997, 30)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'grpActivityStatus
        '
        Me.grpActivityStatus.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem4})
        Me.grpActivityStatus.Location = New System.Drawing.Point(0, 0)
        Me.grpActivityStatus.Name = "grpActivityStatus"
        Me.grpActivityStatus.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.grpActivityStatus.Size = New System.Drawing.Size(997, 505)
        Me.grpActivityStatus.Text = "Activity Status"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridStatus
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(997, 475)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Label2
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(997, 30)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'AdmKPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "AdmKPI"
        Me.Size = New System.Drawing.Size(1049, 610)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridRetStat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRetStatView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRetStatType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRetTermination, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRetTerminationType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridStatusView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAdmStat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repStatType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabAdmKPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpRetTermStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpActivityStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridStatus As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridStatusView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TabAdmKPI As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents grpActivityStatus As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colMapStat_Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusAdmin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repAdmStat As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colStatusType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repStatType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colStatusEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grpRetTermStatus As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridRetStat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridRetStatView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colRetStat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRetTermination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repRetTermination As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colRetTermType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repRetTerminationType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colRetStatType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repRetStatType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colRetEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem

End Class
