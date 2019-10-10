<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecUser))
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtContactInfo = New DevExpress.XtraEditors.MemoEdit()
        Me.txtEmployeeID = New DevExpress.XtraEditors.TextEdit()
        Me.txtFullName = New DevExpress.XtraEditors.TextEdit()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.gridLogInfo = New DevExpress.XtraGrid.GridControl()
        Me.viewLogInfo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyUserID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUserName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colModuleName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdResetPass = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClearGroup = New DevExpress.XtraEditors.SimpleButton()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.lkuGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciRestoreBtn = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_UserInfo = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_LogInfo = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtContactInfo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmployeeID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFullName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridLogInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewLogInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciRestoreBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_UserInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_LogInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(1037, 595)
        Me.header.TabIndex = 4
        Me.header.Text = "User Security Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtContactInfo)
        Me.LayoutControl1.Controls.Add(Me.txtEmployeeID)
        Me.LayoutControl1.Controls.Add(Me.txtFullName)
        Me.LayoutControl1.Controls.Add(Me.txtDescription)
        Me.LayoutControl1.Controls.Add(Me.gridLogInfo)
        Me.LayoutControl1.Controls.Add(Me.cmdResetPass)
        Me.LayoutControl1.Controls.Add(Me.btnClearGroup)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.lkuGroup)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(481, 224, 387, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1033, 567)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtContactInfo
        '
        Me.txtContactInfo.Location = New System.Drawing.Point(148, 317)
        Me.txtContactInfo.Name = "txtContactInfo"
        Me.txtContactInfo.Size = New System.Drawing.Size(501, 31)
        Me.txtContactInfo.StyleController = Me.LayoutControl1
        Me.txtContactInfo.TabIndex = 16
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(148, 283)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(501, 22)
        Me.txtEmployeeID.StyleController = Me.LayoutControl1
        Me.txtEmployeeID.TabIndex = 15
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(148, 184)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(501, 22)
        Me.txtFullName.StyleController = Me.LayoutControl1
        Me.txtFullName.TabIndex = 14
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(148, 218)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(501, 53)
        Me.txtDescription.StyleController = Me.LayoutControl1
        Me.txtDescription.TabIndex = 13
        '
        'gridLogInfo
        '
        Me.gridLogInfo.Location = New System.Drawing.Point(34, 416)
        Me.gridLogInfo.MainView = Me.viewLogInfo
        Me.gridLogInfo.Name = "gridLogInfo"
        Me.gridLogInfo.Size = New System.Drawing.Size(965, 117)
        Me.gridLogInfo.TabIndex = 9
        Me.gridLogInfo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewLogInfo})
        '
        'viewLogInfo
        '
        Me.viewLogInfo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.colFKeyUserID, Me.colUserName, Me.colModuleName, Me.colCompName})
        Me.viewLogInfo.GridControl = Me.gridLogInfo
        Me.viewLogInfo.Name = "viewLogInfo"
        Me.viewLogInfo.OptionsView.ShowGroupPanel = False
        '
        'colPKey
        '
        Me.colPKey.Caption = "PKey"
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colFKeyUserID
        '
        Me.colFKeyUserID.Caption = "FKeyUserID"
        Me.colFKeyUserID.FieldName = "FKeyUserID"
        Me.colFKeyUserID.Name = "colFKeyUserID"
        '
        'colUserName
        '
        Me.colUserName.Caption = "User Name"
        Me.colUserName.FieldName = "UserName"
        Me.colUserName.Name = "colUserName"
        '
        'colModuleName
        '
        Me.colModuleName.Caption = "Module Name"
        Me.colModuleName.FieldName = "ModuleName"
        Me.colModuleName.Name = "colModuleName"
        Me.colModuleName.Visible = True
        Me.colModuleName.VisibleIndex = 1
        '
        'colCompName
        '
        Me.colCompName.Caption = "Computer Name"
        Me.colCompName.FieldName = "CompName"
        Me.colCompName.Name = "colCompName"
        Me.colCompName.Visible = True
        Me.colCompName.VisibleIndex = 0
        '
        'cmdResetPass
        '
        Me.cmdResetPass.Location = New System.Drawing.Point(835, 43)
        Me.cmdResetPass.Name = "cmdResetPass"
        Me.cmdResetPass.Size = New System.Drawing.Size(173, 23)
        Me.cmdResetPass.StyleController = Me.LayoutControl1
        Me.cmdResetPass.TabIndex = 5
        Me.cmdResetPass.Text = "Restore Default Password"
        '
        'btnClearGroup
        '
        Me.btnClearGroup.Location = New System.Drawing.Point(22, 126)
        Me.btnClearGroup.Name = "btnClearGroup"
        Me.btnClearGroup.Size = New System.Drawing.Size(841, 22)
        Me.btnClearGroup.StyleController = Me.LayoutControl1
        Me.btnClearGroup.TabIndex = 5
        Me.btnClearGroup.Text = "Clear Group"
        Me.btnClearGroup.Visible = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(25, 44)
        Me.txtName.MaximumSize = New System.Drawing.Size(0, 22)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.AutoHeight = False
        Me.txtName.Size = New System.Drawing.Size(800, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "User Name"
        '
        'lkuGroup
        '
        Me.lkuGroup.Location = New System.Drawing.Point(25, 105)
        Me.lkuGroup.MaximumSize = New System.Drawing.Size(0, 22)
        Me.lkuGroup.Name = "lkuGroup"
        Me.lkuGroup.Properties.AutoHeight = False
        Me.lkuGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Clear", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("lkuGroup.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "Clear", Nothing, Nothing, True)})
        Me.lkuGroup.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupID", "GroupID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuGroup.Properties.DisplayMember = "Name"
        Me.lkuGroup.Properties.NullText = ""
        Me.lkuGroup.Properties.ShowFooter = False
        Me.lkuGroup.Properties.ShowHeader = False
        Me.lkuGroup.Properties.ShowLines = False
        Me.lkuGroup.Properties.ValueMember = "GroupID"
        Me.lkuGroup.Size = New System.Drawing.Size(983, 22)
        Me.lkuGroup.StyleController = Me.LayoutControl1
        Me.lkuGroup.TabIndex = 4
        Me.lkuGroup.ToolTip = "Group Name"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnClearGroup
        Me.LayoutControlItem3.Location = New System.Drawing.Point(488, 38)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(357, 336)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.lciRestoreBtn, Me.LayoutControlGroup_UserInfo, Me.LayoutControlGroup_LogInfo, Me.EmptySpaceItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1033, 567)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(810, 51)
        Me.LayoutControlItem1.Text = "* User Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(118, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.lkuGroup
        Me.LayoutControlItem2.CustomizationFormText = "Group Name"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(993, 61)
        Me.LayoutControlItem2.Spacing = New DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0)
        Me.LayoutControlItem2.Text = "Group Name"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(118, 16)
        '
        'lciRestoreBtn
        '
        Me.lciRestoreBtn.Control = Me.cmdResetPass
        Me.lciRestoreBtn.ControlAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.lciRestoreBtn.Location = New System.Drawing.Point(810, 0)
        Me.lciRestoreBtn.Name = "lciRestoreBtn"
        Me.lciRestoreBtn.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.lciRestoreBtn.Size = New System.Drawing.Size(183, 51)
        Me.lciRestoreBtn.TextLocation = DevExpress.Utils.Locations.Top
        Me.lciRestoreBtn.TextSize = New System.Drawing.Size(0, 0)
        Me.lciRestoreBtn.TextVisible = False
        Me.lciRestoreBtn.TrimClientAreaToControl = False
        '
        'LayoutControlGroup_UserInfo
        '
        Me.LayoutControlGroup_UserInfo.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_UserInfo.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_UserInfo.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup_UserInfo.Location = New System.Drawing.Point(0, 134)
        Me.LayoutControlGroup_UserInfo.Name = "LayoutControlGroup_UserInfo"
        Me.LayoutControlGroup_UserInfo.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlGroup_UserInfo.Size = New System.Drawing.Size(993, 217)
        Me.LayoutControlGroup_UserInfo.Text = "User Information"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtDescription
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(0, 65)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(128, 65)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(626, 65)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Description:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(118, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(626, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(357, 176)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtFullName
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(626, 34)
        Me.LayoutControlItem5.Text = "Full Name:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(118, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtEmployeeID
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 99)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(626, 34)
        Me.LayoutControlItem6.Text = "Employee ID:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(118, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtContactInfo
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 133)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(0, 43)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(128, 43)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(626, 43)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "Contact Information:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(118, 16)
        '
        'LayoutControlGroup_LogInfo
        '
        Me.LayoutControlGroup_LogInfo.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_LogInfo.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_LogInfo.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup_LogInfo.Location = New System.Drawing.Point(0, 351)
        Me.LayoutControlGroup_LogInfo.Name = "LayoutControlGroup_LogInfo"
        Me.LayoutControlGroup_LogInfo.Size = New System.Drawing.Size(993, 176)
        Me.LayoutControlGroup_LogInfo.Text = "Log Information"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.gridLogInfo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(969, 129)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 112)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 22)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(10, 22)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(993, 22)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'SecUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "SecUser"
        Me.Size = New System.Drawing.Size(1037, 595)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtContactInfo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmployeeID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFullName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridLogInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewLogInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciRestoreBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_UserInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_LogInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lkuGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnClearGroup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdResetPass As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lciRestoreBtn As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gridLogInfo As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewLogInfo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyUserID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUserName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colModuleName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlGroup_UserInfo As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup_LogInfo As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtContactInfo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtEmployeeID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFullName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem

End Class
