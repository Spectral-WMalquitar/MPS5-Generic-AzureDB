<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailSetting_Daily
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailSetting_Daily))
        Me.layoutMain = New DevExpress.XtraLayout.LayoutControl()
        Me.mainPanel = New DevExpress.XtraEditors.PanelControl()
        Me.layoutSubPanel = New DevExpress.XtraLayout.LayoutControl()
        Me.chkSat = New DevExpress.XtraEditors.CheckEdit()
        Me.chkFri = New DevExpress.XtraEditors.CheckEdit()
        Me.chkThu = New DevExpress.XtraEditors.CheckEdit()
        Me.chkWed = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTue = New DevExpress.XtraEditors.CheckEdit()
        Me.chkMon = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSun = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutMain.SuspendLayout()
        CType(Me.mainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainPanel.SuspendLayout()
        CType(Me.layoutSubPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutSubPanel.SuspendLayout()
        CType(Me.chkSat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkThu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkWed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.layoutMain.Controls.Add(Me.mainPanel)
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
        Me.layoutMain.Size = New System.Drawing.Size(500, 63)
        Me.layoutMain.TabIndex = 0
        Me.layoutMain.Text = "LayoutControl1"
        '
        'mainPanel
        '
        Me.mainPanel.Controls.Add(Me.layoutSubPanel)
        Me.mainPanel.Location = New System.Drawing.Point(2, 2)
        Me.mainPanel.Name = "mainPanel"
        Me.mainPanel.Size = New System.Drawing.Size(496, 59)
        Me.mainPanel.TabIndex = 4
        '
        'layoutSubPanel
        '
        Me.layoutSubPanel.Controls.Add(Me.chkSat)
        Me.layoutSubPanel.Controls.Add(Me.chkFri)
        Me.layoutSubPanel.Controls.Add(Me.chkThu)
        Me.layoutSubPanel.Controls.Add(Me.chkWed)
        Me.layoutSubPanel.Controls.Add(Me.chkTue)
        Me.layoutSubPanel.Controls.Add(Me.chkMon)
        Me.layoutSubPanel.Controls.Add(Me.chkSun)
        Me.layoutSubPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutSubPanel.Location = New System.Drawing.Point(0, 0)
        Me.layoutSubPanel.Name = "layoutSubPanel"
        Me.layoutSubPanel.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(998, 152, 250, 350)
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
        Me.layoutSubPanel.Size = New System.Drawing.Size(496, 59)
        Me.layoutSubPanel.TabIndex = 0
        Me.layoutSubPanel.Text = "LayoutControl1"
        '
        'chkSat
        '
        Me.chkSat.Location = New System.Drawing.Point(370, 2)
        Me.chkSat.Name = "chkSat"
        Me.chkSat.Properties.Caption = "Saturday"
        Me.chkSat.Size = New System.Drawing.Size(108, 19)
        Me.chkSat.StyleController = Me.layoutSubPanel
        Me.chkSat.TabIndex = 10
        '
        'chkFri
        '
        Me.chkFri.Location = New System.Drawing.Point(250, 25)
        Me.chkFri.Name = "chkFri"
        Me.chkFri.Properties.Caption = "Friday"
        Me.chkFri.Size = New System.Drawing.Size(108, 19)
        Me.chkFri.StyleController = Me.layoutSubPanel
        Me.chkFri.TabIndex = 9
        '
        'chkThu
        '
        Me.chkThu.Location = New System.Drawing.Point(250, 2)
        Me.chkThu.Name = "chkThu"
        Me.chkThu.Properties.Caption = "Thursday"
        Me.chkThu.Size = New System.Drawing.Size(108, 19)
        Me.chkThu.StyleController = Me.layoutSubPanel
        Me.chkThu.TabIndex = 8
        '
        'chkWed
        '
        Me.chkWed.Location = New System.Drawing.Point(130, 25)
        Me.chkWed.Name = "chkWed"
        Me.chkWed.Properties.Caption = "Wednesday"
        Me.chkWed.Size = New System.Drawing.Size(108, 19)
        Me.chkWed.StyleController = Me.layoutSubPanel
        Me.chkWed.TabIndex = 7
        '
        'chkTue
        '
        Me.chkTue.Location = New System.Drawing.Point(130, 2)
        Me.chkTue.Name = "chkTue"
        Me.chkTue.Properties.Caption = "Tuesday"
        Me.chkTue.Size = New System.Drawing.Size(108, 19)
        Me.chkTue.StyleController = Me.layoutSubPanel
        Me.chkTue.TabIndex = 6
        '
        'chkMon
        '
        Me.chkMon.Location = New System.Drawing.Point(10, 25)
        Me.chkMon.Name = "chkMon"
        Me.chkMon.Properties.Caption = "Monday"
        Me.chkMon.Size = New System.Drawing.Size(108, 19)
        Me.chkMon.StyleController = Me.layoutSubPanel
        Me.chkMon.TabIndex = 5
        '
        'chkSun
        '
        Me.chkSun.Location = New System.Drawing.Point(10, 2)
        Me.chkSun.Name = "chkSun"
        Me.chkSun.Properties.Caption = "Sunday"
        Me.chkSun.Size = New System.Drawing.Size(108, 19)
        Me.chkSun.StyleController = Me.layoutSubPanel
        Me.chkSun.TabIndex = 4
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem2, Me.EmptySpaceItem1, Me.EmptySpaceItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(496, 59)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.chkSun
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = " "
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(3, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.chkMon
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 23)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = " "
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(3, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.chkTue
        Me.LayoutControlItem4.Location = New System.Drawing.Point(120, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = " "
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(3, 13)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.chkWed
        Me.LayoutControlItem5.Location = New System.Drawing.Point(120, 23)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = " "
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(3, 13)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.chkThu
        Me.LayoutControlItem6.Location = New System.Drawing.Point(240, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = " "
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(3, 13)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkFri
        Me.LayoutControlItem7.Location = New System.Drawing.Point(240, 23)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = " "
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(3, 13)
        Me.LayoutControlItem7.TextToControlDistance = 5
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.chkSat
        Me.LayoutControlItem8.Location = New System.Drawing.Point(360, 0)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(120, 23)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = " "
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(3, 13)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 46)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(496, 13)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(360, 23)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(136, 23)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(480, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(16, 23)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(500, 63)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.mainPanel
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(500, 63)
        Me.LayoutControlItem1.Text = " "
        Me.LayoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Right
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmailSetting_Daily
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.layoutMain)
        Me.Name = "EmailSetting_Daily"
        Me.Size = New System.Drawing.Size(500, 63)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutMain.ResumeLayout(False)
        CType(Me.mainPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainPanel.ResumeLayout(False)
        CType(Me.layoutSubPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutSubPanel.ResumeLayout(False)
        CType(Me.chkSat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkThu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkWed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents layoutMain As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents mainPanel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents layoutSubPanel As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents chkSat As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkFri As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkThu As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkWed As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTue As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkMon As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSun As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

End Class
