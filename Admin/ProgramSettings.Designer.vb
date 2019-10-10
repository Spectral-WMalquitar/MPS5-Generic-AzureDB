<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgramSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgramSettings))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkOverrideExpDoc = New DevExpress.XtraEditors.CheckEdit()
        Me.txtTemplateFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtFolderPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtUpdateFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtDays = New DevExpress.XtraEditors.SpinEdit()
        Me.txtLOCDays = New DevExpress.XtraEditors.SpinEdit()
        Me.chkExpDocAlert = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcgExpDoc = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkOverrideExpDoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTemplateFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFolderPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUpdateFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLOCDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExpDocAlert.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgExpDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.LayoutControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1064, 502)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Program Settings"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkOverrideExpDoc)
        Me.LayoutControl1.Controls.Add(Me.txtTemplateFolder)
        Me.LayoutControl1.Controls.Add(Me.txtFolderPath)
        Me.LayoutControl1.Controls.Add(Me.txtUpdateFolder)
        Me.LayoutControl1.Controls.Add(Me.txtDays)
        Me.LayoutControl1.Controls.Add(Me.txtLOCDays)
        Me.LayoutControl1.Controls.Add(Me.chkExpDocAlert)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 24)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(732, 302, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1060, 476)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkOverrideExpDoc
        '
        Me.chkOverrideExpDoc.Location = New System.Drawing.Point(24, 260)
        Me.chkOverrideExpDoc.Name = "chkOverrideExpDoc"
        Me.chkOverrideExpDoc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.chkOverrideExpDoc.Properties.Appearance.Options.UseFont = True
        Me.chkOverrideExpDoc.Properties.Caption = "Override Expiring Document Settings of Users"
        Me.chkOverrideExpDoc.Size = New System.Drawing.Size(1012, 20)
        Me.chkOverrideExpDoc.StyleController = Me.LayoutControl1
        Me.chkOverrideExpDoc.TabIndex = 10
        Me.chkOverrideExpDoc.ToolTip = "Enable to lock and apply specified settings below on users."
        '
        'txtTemplateFolder
        '
        Me.txtTemplateFolder.Location = New System.Drawing.Point(22, 175)
        Me.txtTemplateFolder.Name = "txtTemplateFolder"
        Me.txtTemplateFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtTemplateFolder.Properties.ReadOnly = True
        Me.txtTemplateFolder.Size = New System.Drawing.Size(1016, 22)
        Me.txtTemplateFolder.StyleController = Me.LayoutControl1
        Me.txtTemplateFolder.TabIndex = 5
        '
        'txtFolderPath
        '
        Me.txtFolderPath.Location = New System.Drawing.Point(22, 63)
        Me.txtFolderPath.Name = "txtFolderPath"
        Me.txtFolderPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtFolderPath.Properties.ReadOnly = True
        Me.txtFolderPath.Size = New System.Drawing.Size(1016, 22)
        Me.txtFolderPath.StyleController = Me.LayoutControl1
        Me.txtFolderPath.TabIndex = 4
        '
        'txtUpdateFolder
        '
        Me.txtUpdateFolder.Location = New System.Drawing.Point(22, 119)
        Me.txtUpdateFolder.Name = "txtUpdateFolder"
        Me.txtUpdateFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtUpdateFolder.Properties.ReadOnly = True
        Me.txtUpdateFolder.Size = New System.Drawing.Size(1016, 22)
        Me.txtUpdateFolder.StyleController = Me.LayoutControl1
        Me.txtUpdateFolder.TabIndex = 4
        '
        'txtDays
        '
        Me.txtDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDays.Location = New System.Drawing.Point(24, 313)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.txtDays.Properties.Appearance.Options.UseBackColor = True
        Me.txtDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDays.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtDays.Properties.IsFloatValue = False
        Me.txtDays.Properties.Mask.EditMask = "N00"
        Me.txtDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtDays.Properties.ReadOnly = True
        Me.txtDays.Size = New System.Drawing.Size(1012, 22)
        Me.txtDays.StyleController = Me.LayoutControl1
        Me.txtDays.TabIndex = 5
        '
        'txtLOCDays
        '
        Me.txtLOCDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtLOCDays.Location = New System.Drawing.Point(24, 358)
        Me.txtLOCDays.Name = "txtLOCDays"
        Me.txtLOCDays.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.txtLOCDays.Properties.Appearance.Options.UseBackColor = True
        Me.txtLOCDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtLOCDays.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtLOCDays.Properties.IsFloatValue = False
        Me.txtLOCDays.Properties.Mask.EditMask = "N00"
        Me.txtLOCDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtLOCDays.Properties.ReadOnly = True
        Me.txtLOCDays.Size = New System.Drawing.Size(1012, 22)
        Me.txtLOCDays.StyleController = Me.LayoutControl1
        Me.txtLOCDays.TabIndex = 5
        '
        'chkExpDocAlert
        '
        Me.chkExpDocAlert.Location = New System.Drawing.Point(24, 384)
        Me.chkExpDocAlert.Name = "chkExpDocAlert"
        Me.chkExpDocAlert.Properties.Caption = "Show Expiring Documents Form on Start up"
        Me.chkExpDocAlert.Size = New System.Drawing.Size(1012, 20)
        Me.chkExpDocAlert.StyleController = Me.LayoutControl1
        Me.chkExpDocAlert.TabIndex = 9
        Me.chkExpDocAlert.ToolTip = "When checked, Expiring Document form will show on open of MPS"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgExpDoc, Me.EmptySpaceItem3, Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1060, 476)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lcgExpDoc
        '
        Me.lcgExpDoc.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lcgExpDoc.AppearanceGroup.Options.UseFont = True
        Me.lcgExpDoc.CustomizationFormText = "Expiring Document Settings"
        Me.lcgExpDoc.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.EmptySpaceItem2})
        Me.lcgExpDoc.Location = New System.Drawing.Point(0, 214)
        Me.lcgExpDoc.Name = "lcgExpDoc"
        Me.lcgExpDoc.Size = New System.Drawing.Size(1040, 204)
        Me.lcgExpDoc.Text = "Expiring Document Settings"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtDays
        Me.LayoutControlItem4.CustomizationFormText = "Show in yellow color document due to expire within (days)"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1016, 45)
        Me.LayoutControlItem4.Text = "Show in yellow color document due to expire within (days)"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(1003, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtLOCDays
        Me.LayoutControlItem6.CustomizationFormText = " Set the number of days a document has to remain valid after a joining crews plan" & _
    "ned sign off date (system will give warning if a required document expires withi" & _
    "n this period)"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 79)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1016, 45)
        Me.LayoutControlItem6.StartNewLine = True
        Me.LayoutControlItem6.Text = " Set the number of days a document has to remain valid after a joining crews plan" & _
    "ned sign off date (system will give warning if a required document expires withi" & _
    "n this period)"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(1003, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkExpDocAlert
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 124)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(1016, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 148)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1016, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.chkOverrideExpDoc
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1016, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1016, 10)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 418)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1040, 38)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1040, 214)
        Me.LayoutControlGroup2.Text = "Folder Path"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtFolderPath
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1016, 56)
        Me.LayoutControlItem1.Text = "Folder for images attached in program"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(1003, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtUpdateFolder
        Me.LayoutControlItem2.CustomizationFormText = "Default Folder Path"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1016, 56)
        Me.LayoutControlItem2.Text = "Folder for application updates"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(1003, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtTemplateFolder
        Me.LayoutControlItem3.CustomizationFormText = "Template Folder Path"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 112)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1016, 56)
        Me.LayoutControlItem3.Text = "Template Folder Path"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(1003, 16)
        '
        'ProgramSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "ProgramSettings"
        Me.Size = New System.Drawing.Size(1064, 502)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkOverrideExpDoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTemplateFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFolderPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUpdateFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLOCDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExpDocAlert.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgExpDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtFolderPath As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtUpdateFolder As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTemplateFolder As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkOverrideExpDoc As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtDays As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtLOCDays As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents chkExpDocAlert As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lcgExpDoc As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup

End Class
