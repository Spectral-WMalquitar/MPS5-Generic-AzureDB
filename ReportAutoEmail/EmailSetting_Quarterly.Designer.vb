<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailSetting_Quarterly
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailSetting_Quarterly))
        Me.layoutMain = New DevExpress.XtraLayout.LayoutControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.layoutSubPanel = New DevExpress.XtraLayout.LayoutControl()
        Me.cboDay = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboQuarter = New DevExpress.XtraEditors.LookUpEdit()
        Me.layoutSubPanelGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.SimpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.SimpleLabelItem3 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layoutMainGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutMain.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.layoutSubPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutSubPanel.SuspendLayout()
        CType(Me.cboDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboQuarter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutSubPanelGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutMainGroup, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.layoutMain.Root = Me.layoutMainGroup
        Me.layoutMain.Size = New System.Drawing.Size(668, 68)
        Me.layoutMain.TabIndex = 0
        Me.layoutMain.Text = "LayoutControl1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.layoutSubPanel)
        Me.PanelControl1.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(664, 64)
        Me.PanelControl1.TabIndex = 4
        '
        'layoutSubPanel
        '
        Me.layoutSubPanel.Controls.Add(Me.cboDay)
        Me.layoutSubPanel.Controls.Add(Me.cboQuarter)
        Me.layoutSubPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutSubPanel.Location = New System.Drawing.Point(0, 0)
        Me.layoutSubPanel.Name = "layoutSubPanel"
        Me.layoutSubPanel.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1088, 85, 250, 350)
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
        Me.layoutSubPanel.Root = Me.layoutSubPanelGroup
        Me.layoutSubPanel.Size = New System.Drawing.Size(664, 64)
        Me.layoutSubPanel.TabIndex = 0
        Me.layoutSubPanel.Text = "LayoutControl1"
        '
        'cboDay
        '
        Me.cboDay.Location = New System.Drawing.Point(410, 2)
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
        Me.cboDay.TabIndex = 5
        '
        'cboQuarter
        '
        Me.cboQuarter.Location = New System.Drawing.Point(118, 2)
        Me.cboQuarter.Name = "cboQuarter"
        Me.cboQuarter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboQuarter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboQuarter.Properties.DisplayMember = "Name"
        Me.cboQuarter.Properties.DropDownRows = 3
        Me.cboQuarter.Properties.NullText = ""
        Me.cboQuarter.Properties.PopupWidth = 10
        Me.cboQuarter.Properties.ShowFooter = False
        Me.cboQuarter.Properties.ShowHeader = False
        Me.cboQuarter.Properties.ValueMember = "PKey"
        Me.cboQuarter.Size = New System.Drawing.Size(100, 20)
        Me.cboQuarter.StyleController = Me.layoutSubPanel
        Me.cboQuarter.TabIndex = 4
        '
        'layoutSubPanelGroup
        '
        Me.layoutSubPanelGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutSubPanelGroup.GroupBordersVisible = False
        Me.layoutSubPanelGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.SimpleLabelItem1, Me.SimpleLabelItem2, Me.SimpleLabelItem3, Me.EmptySpaceItem1, Me.EmptySpaceItem2})
        Me.layoutSubPanelGroup.Location = New System.Drawing.Point(0, 0)
        Me.layoutSubPanelGroup.Name = "Root"
        Me.layoutSubPanelGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.layoutSubPanelGroup.Size = New System.Drawing.Size(664, 64)
        Me.layoutSubPanelGroup.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboQuarter
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(220, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(220, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(220, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Execution Date : Every"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(111, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboDay
        Me.LayoutControlItem3.Location = New System.Drawing.Point(370, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(142, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(142, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(142, 24)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "On the"
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(33, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'SimpleLabelItem1
        '
        Me.SimpleLabelItem1.AllowHotTrack = False
        Me.SimpleLabelItem1.Location = New System.Drawing.Point(220, 0)
        Me.SimpleLabelItem1.MaxSize = New System.Drawing.Size(150, 24)
        Me.SimpleLabelItem1.MinSize = New System.Drawing.Size(150, 24)
        Me.SimpleLabelItem1.Name = "SimpleLabelItem1"
        Me.SimpleLabelItem1.Size = New System.Drawing.Size(150, 24)
        Me.SimpleLabelItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.SimpleLabelItem1.Text = "month of the quarter"
        Me.SimpleLabelItem1.TextSize = New System.Drawing.Size(101, 13)
        '
        'SimpleLabelItem2
        '
        Me.SimpleLabelItem2.AllowHotTrack = False
        Me.SimpleLabelItem2.Location = New System.Drawing.Point(512, 0)
        Me.SimpleLabelItem2.Name = "SimpleLabelItem2"
        Me.SimpleLabelItem2.Size = New System.Drawing.Size(152, 24)
        Me.SimpleLabelItem2.Text = "day of the month"
        Me.SimpleLabelItem2.TextSize = New System.Drawing.Size(101, 13)
        '
        'SimpleLabelItem3
        '
        Me.SimpleLabelItem3.AllowHotTrack = False
        Me.SimpleLabelItem3.Location = New System.Drawing.Point(0, 34)
        Me.SimpleLabelItem3.Name = "SimpleLabelItem3"
        Me.SimpleLabelItem3.Size = New System.Drawing.Size(664, 17)
        Me.SimpleLabelItem3.Text = "Coverage : 1st Quarter (Jan-Mar), 2nd Quarter (Apr-Jun), 3rd Quarter (Jul-Sep), 4" & _
    "th Quarter (Oct-Dec)"
        Me.SimpleLabelItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.SimpleLabelItem3.TextSize = New System.Drawing.Size(502, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 51)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(664, 13)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(664, 10)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'layoutMainGroup
        '
        Me.layoutMainGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.layoutMainGroup.GroupBordersVisible = False
        Me.layoutMainGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.layoutMainGroup.Location = New System.Drawing.Point(0, 0)
        Me.layoutMainGroup.Name = "layoutMainGroup"
        Me.layoutMainGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.layoutMainGroup.Size = New System.Drawing.Size(668, 68)
        Me.layoutMainGroup.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PanelControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(668, 68)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmailSetting_Quarterly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.layoutMain)
        Me.Name = "EmailSetting_Quarterly"
        Me.Size = New System.Drawing.Size(668, 68)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutMain.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.layoutSubPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutSubPanel.ResumeLayout(False)
        CType(Me.cboDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboQuarter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutSubPanelGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutMainGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutMain As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents layoutMainGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutSubPanel As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents layoutSubPanelGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboDay As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboQuarter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents SimpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents SimpleLabelItem3 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem

End Class
