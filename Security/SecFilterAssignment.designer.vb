<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecFilterAssignment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecFilterAssignment))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblFeatureDisabled = New DevExpress.XtraEditors.LabelControl()
        Me.btnRemoveAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAssignAll = New DevExpress.XtraEditors.SimpleButton()
        Me.cboFilterType = New DevExpress.XtraEditors.LookUpEdit()
        Me.GridAssigned = New DevExpress.XtraGrid.GridControl()
        Me.GVAssigned = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Code_Assigned = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Name_Assigned = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridAvailable = New DevExpress.XtraGrid.GridControl()
        Me.GVAvailable = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Code_Avail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Name_Avail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtUserName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcgAssignment = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_Available = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Assigned = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.lciFeatureDisabled = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboFilterType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAssigned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAssigned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAvailable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAvailable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgAssignment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Available, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Assigned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciFeatureDisabled, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(1078, 553)
        Me.header.TabIndex = 0
        Me.header.Text = "Filter Assignment"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.lblFeatureDisabled)
        Me.LayoutControl1.Controls.Add(Me.btnRemoveAll)
        Me.LayoutControl1.Controls.Add(Me.btnAssignAll)
        Me.LayoutControl1.Controls.Add(Me.cboFilterType)
        Me.LayoutControl1.Controls.Add(Me.GridAssigned)
        Me.LayoutControl1.Controls.Add(Me.GridAvailable)
        Me.LayoutControl1.Controls.Add(Me.txtUserName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(124, 336, 682, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1074, 525)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblFeatureDisabled
        '
        Me.lblFeatureDisabled.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Italic)
        Me.lblFeatureDisabled.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblFeatureDisabled.Location = New System.Drawing.Point(12, 497)
        Me.lblFeatureDisabled.Name = "lblFeatureDisabled"
        Me.lblFeatureDisabled.Size = New System.Drawing.Size(402, 16)
        Me.lblFeatureDisabled.StyleController = Me.LayoutControl1
        Me.lblFeatureDisabled.TabIndex = 11
        Me.lblFeatureDisabled.Text = "Feature is currently disabled because there are no available users yet."
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Location = New System.Drawing.Point(542, 456)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(511, 28)
        Me.btnRemoveAll.StyleController = Me.LayoutControl1
        Me.btnRemoveAll.TabIndex = 10
        Me.btnRemoveAll.Text = "Remove All"
        '
        'btnAssignAll
        '
        Me.btnAssignAll.Location = New System.Drawing.Point(21, 456)
        Me.btnAssignAll.Name = "btnAssignAll"
        Me.btnAssignAll.Size = New System.Drawing.Size(511, 28)
        Me.btnAssignAll.StyleController = Me.LayoutControl1
        Me.btnAssignAll.TabIndex = 9
        Me.btnAssignAll.Text = "Assign All"
        '
        'cboFilterType
        '
        Me.cboFilterType.Location = New System.Drawing.Point(141, 86)
        Me.cboFilterType.Name = "cboFilterType"
        Me.cboFilterType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFilterType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFilterType.Properties.DisplayMember = "Name"
        Me.cboFilterType.Properties.NullText = ""
        Me.cboFilterType.Properties.ShowFooter = False
        Me.cboFilterType.Properties.ShowHeader = False
        Me.cboFilterType.Properties.ValueMember = "PKey"
        Me.cboFilterType.Size = New System.Drawing.Size(917, 22)
        Me.cboFilterType.StyleController = Me.LayoutControl1
        Me.cboFilterType.TabIndex = 8
        '
        'GridAssigned
        '
        Me.GridAssigned.AllowDrop = True
        Me.GridAssigned.Location = New System.Drawing.Point(542, 137)
        Me.GridAssigned.MainView = Me.GVAssigned
        Me.GridAssigned.Name = "GridAssigned"
        Me.GridAssigned.Size = New System.Drawing.Size(511, 315)
        Me.GridAssigned.TabIndex = 5
        Me.GridAssigned.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAssigned})
        '
        'GVAssigned
        '
        Me.GVAssigned.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Code_Assigned, Me.Name_Assigned})
        Me.GVAssigned.GridControl = Me.GridAssigned
        Me.GVAssigned.Name = "GVAssigned"
        Me.GVAssigned.OptionsBehavior.Editable = False
        Me.GVAssigned.OptionsFind.AlwaysVisible = True
        Me.GVAssigned.OptionsView.ShowColumnHeaders = False
        Me.GVAssigned.OptionsView.ShowGroupPanel = False
        Me.GVAssigned.OptionsView.ShowIndicator = False
        '
        'Code_Assigned
        '
        Me.Code_Assigned.Caption = "Code"
        Me.Code_Assigned.FieldName = "PKey"
        Me.Code_Assigned.Name = "Code_Assigned"
        '
        'Name_Assigned
        '
        Me.Name_Assigned.Caption = "Name"
        Me.Name_Assigned.FieldName = "Name"
        Me.Name_Assigned.Name = "Name_Assigned"
        Me.Name_Assigned.Visible = True
        Me.Name_Assigned.VisibleIndex = 0
        '
        'GridAvailable
        '
        Me.GridAvailable.AllowDrop = True
        Me.GridAvailable.Location = New System.Drawing.Point(21, 137)
        Me.GridAvailable.MainView = Me.GVAvailable
        Me.GridAvailable.Name = "GridAvailable"
        Me.GridAvailable.Size = New System.Drawing.Size(511, 315)
        Me.GridAvailable.TabIndex = 4
        Me.GridAvailable.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAvailable})
        '
        'GVAvailable
        '
        Me.GVAvailable.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Code_Avail, Me.Name_Avail})
        Me.GVAvailable.GridControl = Me.GridAvailable
        Me.GVAvailable.Name = "GVAvailable"
        Me.GVAvailable.OptionsBehavior.Editable = False
        Me.GVAvailable.OptionsFind.AlwaysVisible = True
        Me.GVAvailable.OptionsView.ShowColumnHeaders = False
        Me.GVAvailable.OptionsView.ShowGroupPanel = False
        Me.GVAvailable.OptionsView.ShowIndicator = False
        '
        'Code_Avail
        '
        Me.Code_Avail.Caption = "Code"
        Me.Code_Avail.FieldName = "PKey"
        Me.Code_Avail.Name = "Code_Avail"
        '
        'Name_Avail
        '
        Me.Name_Avail.Caption = "Name"
        Me.Name_Avail.FieldName = "Name"
        Me.Name_Avail.Name = "Name_Avail"
        Me.Name_Avail.Visible = True
        Me.Name_Avail.VisibleIndex = 0
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(15, 37)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(1044, 22)
        Me.txtUserName.StyleController = Me.LayoutControl1
        Me.txtUserName.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgAssignment, Me.lciFeatureDisabled})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1074, 525)
        '
        'lcgAssignment
        '
        Me.lcgAssignment.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3})
        Me.lcgAssignment.Location = New System.Drawing.Point(0, 0)
        Me.lcgAssignment.Name = "lcgAssignment"
        Me.lcgAssignment.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lcgAssignment.Size = New System.Drawing.Size(1054, 485)
        Me.lcgAssignment.Text = "User Name"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtUserName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1048, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_Available, Me.LayoutControlGroup_Assigned, Me.LayoutControlItem2, Me.SimpleLabelItem1})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1048, 431)
        Me.LayoutControlGroup3.Text = "Assigned Permission"
        '
        'LayoutControlGroup_Available
        '
        Me.LayoutControlGroup_Available.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem5})
        Me.LayoutControlGroup_Available.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlGroup_Available.Name = "LayoutControlGroup_Available"
        Me.LayoutControlGroup_Available.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_Available.Size = New System.Drawing.Size(521, 379)
        Me.LayoutControlGroup_Available.Text = "Available"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridAvailable
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(515, 319)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnAssignAll
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 319)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(96, 32)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(515, 32)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup_Assigned
        '
        Me.LayoutControlGroup_Assigned.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem6})
        Me.LayoutControlGroup_Assigned.Location = New System.Drawing.Point(521, 24)
        Me.LayoutControlGroup_Assigned.Name = "LayoutControlGroup_Assigned"
        Me.LayoutControlGroup_Assigned.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_Assigned.Size = New System.Drawing.Size(521, 379)
        Me.LayoutControlGroup_Assigned.Text = "Assigned"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridAssigned
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(515, 319)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnRemoveAll
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 319)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(0, 32)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(96, 32)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(515, 32)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboFilterType
        Me.LayoutControlItem2.Location = New System.Drawing.Point(125, 0)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(152, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(917, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Use filter type:  "
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'SimpleLabelItem1
        '
        Me.SimpleLabelItem1.AllowHotTrack = False
        Me.SimpleLabelItem1.Location = New System.Drawing.Point(0, 0)
        Me.SimpleLabelItem1.Name = "SimpleLabelItem1"
        Me.SimpleLabelItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(12, 2, 2, 2)
        Me.SimpleLabelItem1.Size = New System.Drawing.Size(125, 24)
        Me.SimpleLabelItem1.Text = "Use filter type:  "
        Me.SimpleLabelItem1.TextSize = New System.Drawing.Size(92, 16)
        '
        'lciFeatureDisabled
        '
        Me.lciFeatureDisabled.Control = Me.lblFeatureDisabled
        Me.lciFeatureDisabled.Location = New System.Drawing.Point(0, 485)
        Me.lciFeatureDisabled.Name = "lciFeatureDisabled"
        Me.lciFeatureDisabled.Size = New System.Drawing.Size(1054, 20)
        Me.lciFeatureDisabled.TextSize = New System.Drawing.Size(0, 0)
        Me.lciFeatureDisabled.TextVisible = False
        '
        'SecFilterAssignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "SecFilterAssignment"
        Me.Size = New System.Drawing.Size(1078, 553)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboFilterType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAssigned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAssigned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAvailable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAvailable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgAssignment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Available, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Assigned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciFeatureDisabled, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lcgAssignment As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridAssigned As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAssigned As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridAvailable As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAvailable As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup_Available As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_Assigned As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Code_Assigned As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Name_Assigned As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Code_Avail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Name_Avail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboFilterType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnRemoveAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAssignAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents lblFeatureDisabled As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lciFeatureDisabled As DevExpress.XtraLayout.LayoutControlItem

End Class
