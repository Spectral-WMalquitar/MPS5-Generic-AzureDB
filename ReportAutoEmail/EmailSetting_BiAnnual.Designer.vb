<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailSetting_BiAnnual
    Inherits EmailBaseSetting

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailSetting_BiAnnual))
        Me.layoutMain = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.layoutSubPanel = New DevExpress.XtraLayout.LayoutControl()
        Me.cboStartMonth2 = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboStartMonth = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboDay = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboExecMonth2 = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboExecMonth = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutMain.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.layoutSubPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutSubPanel.SuspendLayout()
        CType(Me.cboStartMonth2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStartMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboExecMonth2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboExecMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'layoutMain
        '
        Me.layoutMain.Controls.Add(Me.PanelControl1)
        Me.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMain.Location = New System.Drawing.Point(0, 0)
        Me.layoutMain.Name = "layoutMain"
        Me.layoutMain.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.layoutMain.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.layoutMain.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.layoutMain.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.layoutMain.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.layoutMain.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.layoutMain.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.layoutMain.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.layoutMain.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.layoutMain.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.layoutMain.Root = Me.LayoutControlGroup1
        Me.layoutMain.Size = New System.Drawing.Size(681, 74)
        Me.layoutMain.TabIndex = 0
        Me.layoutMain.Text = "LayoutControl1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.layoutSubPanel)
        Me.PanelControl1.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(677, 70)
        Me.PanelControl1.TabIndex = 4
        '
        'layoutSubPanel
        '
        Me.layoutSubPanel.Controls.Add(Me.cboStartMonth2)
        Me.layoutSubPanel.Controls.Add(Me.cboStartMonth)
        Me.layoutSubPanel.Controls.Add(Me.cboDay)
        Me.layoutSubPanel.Controls.Add(Me.cboExecMonth2)
        Me.layoutSubPanel.Controls.Add(Me.cboExecMonth)
        Me.layoutSubPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutSubPanel.Location = New System.Drawing.Point(0, 0)
        Me.layoutSubPanel.Name = "layoutSubPanel"
        Me.layoutSubPanel.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1229, 59, 250, 350)
        Me.layoutSubPanel.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.layoutSubPanel.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.layoutSubPanel.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.layoutSubPanel.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.layoutSubPanel.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.layoutSubPanel.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.layoutSubPanel.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.layoutSubPanel.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.layoutSubPanel.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.layoutSubPanel.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.layoutSubPanel.Root = Me.LayoutControlGroup2
        Me.layoutSubPanel.Size = New System.Drawing.Size(677, 70)
        Me.layoutSubPanel.TabIndex = 0
        Me.layoutSubPanel.Text = "LayoutControl1"
        '
        'cboStartMonth2
        '
        Me.cboStartMonth2.Location = New System.Drawing.Point(325, 36)
        Me.cboStartMonth2.Name = "cboStartMonth2"
        Me.cboStartMonth2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboStartMonth2.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboStartMonth2.Properties.DisplayMember = "Name"
        Me.cboStartMonth2.Properties.NullText = ""
        Me.cboStartMonth2.Properties.PopupWidth = 10
        Me.cboStartMonth2.Properties.ShowFooter = False
        Me.cboStartMonth2.Properties.ShowHeader = False
        Me.cboStartMonth2.Properties.ValueMember = "PKey"
        Me.cboStartMonth2.Size = New System.Drawing.Size(150, 20)
        Me.cboStartMonth2.StyleController = Me.layoutSubPanel
        Me.cboStartMonth2.TabIndex = 8
        '
        'cboStartMonth
        '
        Me.cboStartMonth.Location = New System.Drawing.Point(148, 36)
        Me.cboStartMonth.Name = "cboStartMonth"
        Me.cboStartMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboStartMonth.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboStartMonth.Properties.DisplayMember = "Name"
        Me.cboStartMonth.Properties.NullText = ""
        Me.cboStartMonth.Properties.PopupWidth = 10
        Me.cboStartMonth.Properties.ShowFooter = False
        Me.cboStartMonth.Properties.ShowHeader = False
        Me.cboStartMonth.Properties.ValueMember = "PKey"
        Me.cboStartMonth.Size = New System.Drawing.Size(150, 20)
        Me.cboStartMonth.StyleController = Me.layoutSubPanel
        Me.cboStartMonth.TabIndex = 7
        '
        'cboDay
        '
        Me.cboDay.Location = New System.Drawing.Point(487, 2)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDay.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboDay.Properties.DisplayMember = "Name"
        Me.cboDay.Properties.NullText = ""
        Me.cboDay.Properties.PopupWidth = 10
        Me.cboDay.Properties.ShowFooter = False
        Me.cboDay.Properties.ShowHeader = False
        Me.cboDay.Properties.ValueMember = "PKey"
        Me.cboDay.Size = New System.Drawing.Size(100, 20)
        Me.cboDay.StyleController = Me.layoutSubPanel
        Me.cboDay.TabIndex = 6
        '
        'cboExecMonth2
        '
        Me.cboExecMonth2.Location = New System.Drawing.Point(295, 2)
        Me.cboExecMonth2.Name = "cboExecMonth2"
        Me.cboExecMonth2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboExecMonth2.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboExecMonth2.Properties.DisplayMember = "Name"
        Me.cboExecMonth2.Properties.NullText = ""
        Me.cboExecMonth2.Properties.PopupWidth = 10
        Me.cboExecMonth2.Properties.ShowFooter = False
        Me.cboExecMonth2.Properties.ShowHeader = False
        Me.cboExecMonth2.Properties.ValueMember = "PKey"
        Me.cboExecMonth2.Size = New System.Drawing.Size(150, 20)
        Me.cboExecMonth2.StyleController = Me.layoutSubPanel
        Me.cboExecMonth2.TabIndex = 5
        '
        'cboExecMonth
        '
        Me.cboExecMonth.Location = New System.Drawing.Point(118, 2)
        Me.cboExecMonth.Name = "cboExecMonth"
        Me.cboExecMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboExecMonth.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboExecMonth.Properties.DisplayMember = "Name"
        Me.cboExecMonth.Properties.NullText = ""
        Me.cboExecMonth.Properties.PopupWidth = 10
        Me.cboExecMonth.Properties.ShowFooter = False
        Me.cboExecMonth.Properties.ShowHeader = False
        Me.cboExecMonth.Properties.ValueMember = "PKey"
        Me.cboExecMonth.Size = New System.Drawing.Size(150, 20)
        Me.cboExecMonth.StyleController = Me.layoutSubPanel
        Me.cboExecMonth.TabIndex = 4
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem6, Me.EmptySpaceItem3, Me.SimpleLabelItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(677, 70)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboExecMonth
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(270, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(270, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(270, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Execution Date : Every"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(111, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboExecMonth2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(270, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(177, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(177, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(177, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "and"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(18, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboDay
        Me.LayoutControlItem4.Location = New System.Drawing.Point(447, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(142, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(142, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(142, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "On the"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(33, 13)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboStartMonth
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(300, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(300, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(300, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Starting Month of Coverage :"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(141, 13)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 58)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(677, 12)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(477, 34)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(200, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cboStartMonth2
        Me.LayoutControlItem6.Location = New System.Drawing.Point(300, 34)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(177, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(177, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(177, 24)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "and"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(18, 13)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(677, 10)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleLabelItem1
        '
        Me.SimpleLabelItem1.AllowHotTrack = False
        Me.SimpleLabelItem1.Location = New System.Drawing.Point(589, 0)
        Me.SimpleLabelItem1.Name = "SimpleLabelItem1"
        Me.SimpleLabelItem1.Size = New System.Drawing.Size(88, 24)
        Me.SimpleLabelItem1.Text = "day of the month"
        Me.SimpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.SimpleLabelItem1.TextSize = New System.Drawing.Size(83, 13)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(681, 74)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PanelControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(681, 74)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmailSetting_BiAnnual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.layoutMain)
        Me.Name = "EmailSetting_BiAnnual"
        Me.Size = New System.Drawing.Size(681, 74)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutMain.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.layoutSubPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutSubPanel.ResumeLayout(False)
        CType(Me.cboStartMonth2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStartMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboExecMonth2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboExecMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutMain As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents layoutSubPanel As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboDay As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboExecMonth2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboExecMonth As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboStartMonth2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboStartMonth As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem

End Class
