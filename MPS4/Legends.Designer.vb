<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Legends
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Legends))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.lcMain = New DevExpress.XtraLayout.LayoutControl()
        Me.gcCrewList = New DevExpress.XtraEditors.GroupControl()
        Me.lcCrewList = New DevExpress.XtraLayout.LayoutControl()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lcgCrewList = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgMain = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.lcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lcMain.SuspendLayout()
        CType(Me.gcCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcCrewList.SuspendLayout()
        CType(Me.lcCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lcCrewList.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgMain, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.lcMain)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(767, 635)
        Me.header.TabIndex = 0
        Me.header.Text = "Legends"
        '
        'lcMain
        '
        Me.lcMain.Controls.Add(Me.gcCrewList)
        Me.lcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lcMain.Location = New System.Drawing.Point(2, 26)
        Me.lcMain.Name = "lcMain"
        Me.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(431, 229, 250, 350)
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcMain.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcMain.Root = Me.lcgMain
        Me.lcMain.Size = New System.Drawing.Size(763, 607)
        Me.lcMain.TabIndex = 0
        Me.lcMain.Text = "LayoutControl1"
        '
        'gcCrewList
        '
        Me.gcCrewList.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gcCrewList.AppearanceCaption.Options.UseFont = True
        Me.gcCrewList.Controls.Add(Me.lcCrewList)
        Me.gcCrewList.Location = New System.Drawing.Point(12, 12)
        Me.gcCrewList.Name = "gcCrewList"
        Me.gcCrewList.Size = New System.Drawing.Size(739, 583)
        Me.gcCrewList.TabIndex = 4
        Me.gcCrewList.Text = "Crew List"
        '
        'lcCrewList
        '
        Me.lcCrewList.Controls.Add(Me.PictureBox3)
        Me.lcCrewList.Controls.Add(Me.PictureBox2)
        Me.lcCrewList.Controls.Add(Me.PictureBox1)
        Me.lcCrewList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lcCrewList.Location = New System.Drawing.Point(2, 26)
        Me.lcCrewList.Name = "lcCrewList"
        Me.lcCrewList.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.lcCrewList.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lcCrewList.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.lcCrewList.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.lcCrewList.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.lcCrewList.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lcCrewList.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcCrewList.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.lcCrewList.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lcCrewList.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcCrewList.Root = Me.lcgCrewList
        Me.lcCrewList.Size = New System.Drawing.Size(735, 555)
        Me.lcCrewList.TabIndex = 1
        Me.lcCrewList.Text = "LayoutControl1"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(24, 399)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(687, 132)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(24, 263)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(687, 132)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(687, 167)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'lcgCrewList
        '
        Me.lcgCrewList.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.lcgCrewList.GroupBordersVisible = False
        Me.lcgCrewList.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2})
        Me.lcgCrewList.Location = New System.Drawing.Point(0, 0)
        Me.lcgCrewList.Name = "Root"
        Me.lcgCrewList.Size = New System.Drawing.Size(735, 555)
        Me.lcgCrewList.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 217)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(715, 318)
        Me.LayoutControlGroup1.Text = "Contract Due"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PictureBox2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 136)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(104, 136)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(691, 136)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.PictureBox3
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 136)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 136)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(104, 136)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(691, 136)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(715, 217)
        Me.LayoutControlGroup2.Text = "Expiring Document"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.PictureBox1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(0, 171)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(104, 171)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(691, 171)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'lcgMain
        '
        Me.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.lcgMain.GroupBordersVisible = False
        Me.lcgMain.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.lcgMain.Location = New System.Drawing.Point(0, 0)
        Me.lcgMain.Name = "Root"
        Me.lcgMain.Size = New System.Drawing.Size(763, 607)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.gcCrewList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(743, 587)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'Legends
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "Legends"
        Me.Size = New System.Drawing.Size(767, 635)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.lcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lcMain.ResumeLayout(False)
        CType(Me.gcCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcCrewList.ResumeLayout(False)
        CType(Me.lcCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lcCrewList.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lcMain As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents lcgMain As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents gcCrewList As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcCrewList As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents lcgCrewList As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem

End Class
