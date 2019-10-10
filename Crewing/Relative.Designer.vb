<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Relative
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Relative))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.xheader = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSexCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRel = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCntry = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.reptxt20 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.reptxt30 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.reptxt50 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.reptxt200 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        Me.xheader.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSexCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCntry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reptxt20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reptxt30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reptxt50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reptxt200, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.xheader)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(854, 480)
        Me.header.TabIndex = 51
        Me.header.Text = "Crew Relatives"
        '
        'xheader
        '
        Me.xheader.Controls.Add(Me.LayoutControl1)
        Me.xheader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xheader.Location = New System.Drawing.Point(2, 24)
        Me.xheader.Name = "xheader"
        Me.xheader.Size = New System.Drawing.Size(850, 454)
        Me.xheader.TabIndex = 48
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(850, 454)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(25, 45)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.reptxt20, Me.reptxt30, Me.reptxt50, Me.reptxt200, Me.repDate, Me.repCntry, Me.repRel, Me.repSexCode})
        Me.MainGrid.Size = New System.Drawing.Size(800, 384)
        Me.MainGrid.TabIndex = 10
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.MainView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.MainView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.Row.Options.UseTextOptions = True
        Me.MainView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.MainView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn22, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn21, Me.GridColumn18, Me.GridColumn8})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new Record"
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsFind.AllowFindPanel = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.ViewCaption = " Other Information"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PKey"
        Me.GridColumn1.FieldName = "PKey"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "FKeyIDNbr"
        Me.GridColumn2.FieldName = "FKeyIDNbr"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Last Name"
        Me.GridColumn3.FieldName = "LName"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 174
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "First Name"
        Me.GridColumn4.FieldName = "FName"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 178
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Middle Name"
        Me.GridColumn5.FieldName = "MName"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 163
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Notify in Case of Emergency"
        Me.GridColumn6.FieldName = "Notify"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 145
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Beneficiary of Insurance"
        Me.GridColumn7.FieldName = "Benef"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 126
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Gender"
        Me.GridColumn22.ColumnEdit = Me.repSexCode
        Me.GridColumn22.FieldName = "SexCode"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 3
        Me.GridColumn22.Width = 93
        '
        'repSexCode
        '
        Me.repSexCode.AutoHeight = False
        Me.repSexCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repSexCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repSexCode.DisplayMember = "Name"
        Me.repSexCode.Name = "repSexCode"
        Me.repSexCode.NullText = ""
        Me.repSexCode.ValueMember = "PKey"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Relationship"
        Me.GridColumn9.ColumnEdit = Me.repRel
        Me.GridColumn9.FieldName = "FKeyRel"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 204
        '
        'repRel
        '
        Me.repRel.AutoHeight = False
        Me.repRel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repRel.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repRel.DisplayMember = "Name"
        Me.repRel.Name = "repRel"
        Me.repRel.NullText = ""
        Me.repRel.ValueMember = "PKey"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Address"
        Me.GridColumn10.FieldName = "Addr"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        Me.GridColumn10.Width = 408
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Country"
        Me.GridColumn11.ColumnEdit = Me.repCntry
        Me.GridColumn11.FieldName = "FKeyCntry"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 8
        Me.GridColumn11.Width = 218
        '
        'repCntry
        '
        Me.repCntry.AutoHeight = False
        Me.repCntry.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repCntry.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repCntry.DisplayMember = "Name"
        Me.repCntry.DropDownRows = 10
        Me.repCntry.Name = "repCntry"
        Me.repCntry.NullText = ""
        Me.repCntry.ShowFooter = False
        Me.repCntry.ShowHeader = False
        Me.repCntry.ValueMember = "PKey"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Mobile"
        Me.GridColumn12.FieldName = "Phone"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        Me.GridColumn12.Width = 240
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Telephone"
        Me.GridColumn13.FieldName = "Telefax"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 11
        Me.GridColumn13.Width = 269
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Email"
        Me.GridColumn14.FieldName = "Email"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 12
        Me.GridColumn14.Width = 223
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Date of Birth"
        Me.GridColumn21.ColumnEdit = Me.repDate
        Me.GridColumn21.FieldName = "DOB"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 4
        Me.GridColumn21.Width = 146
        '
        'repDate
        '
        Me.repDate.AutoHeight = False
        Me.repDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDate.Mask.EditMask = "dd-MMM-yyyy"
        Me.repDate.Mask.UseMaskAsDisplayFormat = True
        Me.repDate.Name = "repDate"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Edited"
        Me.GridColumn18.FieldName = "Edited"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "SeaAddr"
        Me.GridColumn8.FieldName = "SeaAddr"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'reptxt20
        '
        Me.reptxt20.AutoHeight = False
        Me.reptxt20.MaxLength = 20
        Me.reptxt20.Name = "reptxt20"
        '
        'reptxt30
        '
        Me.reptxt30.AutoHeight = False
        Me.reptxt30.MaxLength = 30
        Me.reptxt30.Name = "reptxt30"
        '
        'reptxt50
        '
        Me.reptxt50.AutoHeight = False
        Me.reptxt50.MaxLength = 50
        Me.reptxt50.Name = "reptxt50"
        '
        'reptxt200
        '
        Me.reptxt200.AutoHeight = False
        Me.reptxt200.MaxLength = 200
        Me.reptxt200.Name = "reptxt200"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(850, 454)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(810, 414)
        Me.LayoutControlGroup2.Text = "Relatives"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.MainGrid
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(804, 388)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'Relative
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "Relative"
        Me.Size = New System.Drawing.Size(854, 480)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.xheader.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSexCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCntry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reptxt20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reptxt30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reptxt50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reptxt200, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents xheader As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents reptxt20 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents reptxt30 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents reptxt50 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents reptxt200 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents repDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repCntry As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repRel As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repSexCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn

End Class
