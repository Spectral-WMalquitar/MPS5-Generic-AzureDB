<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WageScaleCalendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WageScaleCalendar))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtJan = New DevExpress.XtraEditors.TextEdit()
        Me.txtJul = New DevExpress.XtraEditors.TextEdit()
        Me.txtFeb = New DevExpress.XtraEditors.TextEdit()
        Me.txtAug = New DevExpress.XtraEditors.TextEdit()
        Me.txtMar = New DevExpress.XtraEditors.TextEdit()
        Me.txtSep = New DevExpress.XtraEditors.TextEdit()
        Me.txtApr = New DevExpress.XtraEditors.TextEdit()
        Me.txtOct = New DevExpress.XtraEditors.TextEdit()
        Me.txtMay = New DevExpress.XtraEditors.TextEdit()
        Me.txtNov = New DevExpress.XtraEditors.TextEdit()
        Me.txtJun = New DevExpress.XtraEditors.TextEdit()
        Me.txtDec = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJul.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFeb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAug.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSep.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNov.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(601, 387)
        Me.header.TabIndex = 0
        Me.header.Text = "Wage Scale Calendar Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cboType)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtJan)
        Me.LayoutControl1.Controls.Add(Me.txtJul)
        Me.LayoutControl1.Controls.Add(Me.txtFeb)
        Me.LayoutControl1.Controls.Add(Me.txtAug)
        Me.LayoutControl1.Controls.Add(Me.txtMar)
        Me.LayoutControl1.Controls.Add(Me.txtSep)
        Me.LayoutControl1.Controls.Add(Me.txtApr)
        Me.LayoutControl1.Controls.Add(Me.txtOct)
        Me.LayoutControl1.Controls.Add(Me.txtMay)
        Me.LayoutControl1.Controls.Add(Me.txtNov)
        Me.LayoutControl1.Controls.Add(Me.txtJun)
        Me.LayoutControl1.Controls.Add(Me.txtDec)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 22)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(597, 363)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboType
        '
        Me.cboType.Location = New System.Drawing.Point(411, 28)
        Me.cboType.Name = "cboType"
        Me.cboType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboType.Properties.DisplayMember = "Name"
        Me.cboType.Properties.DropDownRows = 10
        Me.cboType.Properties.NullText = ""
        Me.cboType.Properties.ShowFooter = False
        Me.cboType.Properties.ShowHeader = False
        Me.cboType.Properties.ValueMember = "PKey"
        Me.cboType.Size = New System.Drawing.Size(174, 20)
        Me.cboType.StyleController = Me.LayoutControl1
        Me.cboType.TabIndex = 6
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(12, 28)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 100
        Me.txtName.Size = New System.Drawing.Size(395, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 5
        '
        'txtJan
        '
        Me.txtJan.Location = New System.Drawing.Point(24, 112)
        Me.txtJan.Name = "txtJan"
        Me.txtJan.Properties.Mask.EditMask = "\d\d"
        Me.txtJan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtJan.Size = New System.Drawing.Size(272, 20)
        Me.txtJan.StyleController = Me.LayoutControl1
        Me.txtJan.TabIndex = 4
        '
        'txtJul
        '
        Me.txtJul.Location = New System.Drawing.Point(24, 232)
        Me.txtJul.Name = "txtJul"
        Me.txtJul.Properties.Mask.EditMask = "\d\d"
        Me.txtJul.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtJul.Size = New System.Drawing.Size(272, 20)
        Me.txtJul.StyleController = Me.LayoutControl1
        Me.txtJul.TabIndex = 4
        '
        'txtFeb
        '
        Me.txtFeb.Location = New System.Drawing.Point(300, 112)
        Me.txtFeb.Name = "txtFeb"
        Me.txtFeb.Properties.Mask.EditMask = "\d\d"
        Me.txtFeb.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtFeb.Size = New System.Drawing.Size(273, 20)
        Me.txtFeb.StyleController = Me.LayoutControl1
        Me.txtFeb.TabIndex = 4
        '
        'txtAug
        '
        Me.txtAug.Location = New System.Drawing.Point(300, 232)
        Me.txtAug.Name = "txtAug"
        Me.txtAug.Properties.Mask.EditMask = "\d\d"
        Me.txtAug.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtAug.Size = New System.Drawing.Size(273, 20)
        Me.txtAug.StyleController = Me.LayoutControl1
        Me.txtAug.TabIndex = 4
        '
        'txtMar
        '
        Me.txtMar.Location = New System.Drawing.Point(24, 152)
        Me.txtMar.Name = "txtMar"
        Me.txtMar.Properties.Mask.EditMask = "\d\d"
        Me.txtMar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtMar.Size = New System.Drawing.Size(272, 20)
        Me.txtMar.StyleController = Me.LayoutControl1
        Me.txtMar.TabIndex = 4
        '
        'txtSep
        '
        Me.txtSep.Location = New System.Drawing.Point(24, 272)
        Me.txtSep.Name = "txtSep"
        Me.txtSep.Properties.Mask.EditMask = "\d\d"
        Me.txtSep.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtSep.Size = New System.Drawing.Size(272, 20)
        Me.txtSep.StyleController = Me.LayoutControl1
        Me.txtSep.TabIndex = 4
        '
        'txtApr
        '
        Me.txtApr.Location = New System.Drawing.Point(300, 152)
        Me.txtApr.Name = "txtApr"
        Me.txtApr.Properties.Mask.EditMask = "\d\d"
        Me.txtApr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtApr.Size = New System.Drawing.Size(273, 20)
        Me.txtApr.StyleController = Me.LayoutControl1
        Me.txtApr.TabIndex = 4
        '
        'txtOct
        '
        Me.txtOct.Location = New System.Drawing.Point(300, 272)
        Me.txtOct.Name = "txtOct"
        Me.txtOct.Properties.Mask.EditMask = "\d\d"
        Me.txtOct.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtOct.Size = New System.Drawing.Size(273, 20)
        Me.txtOct.StyleController = Me.LayoutControl1
        Me.txtOct.TabIndex = 4
        '
        'txtMay
        '
        Me.txtMay.Location = New System.Drawing.Point(24, 192)
        Me.txtMay.Name = "txtMay"
        Me.txtMay.Properties.Mask.EditMask = "\d\d"
        Me.txtMay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtMay.Size = New System.Drawing.Size(272, 20)
        Me.txtMay.StyleController = Me.LayoutControl1
        Me.txtMay.TabIndex = 4
        '
        'txtNov
        '
        Me.txtNov.Location = New System.Drawing.Point(24, 312)
        Me.txtNov.Name = "txtNov"
        Me.txtNov.Properties.Mask.EditMask = "\d\d"
        Me.txtNov.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtNov.Size = New System.Drawing.Size(272, 20)
        Me.txtNov.StyleController = Me.LayoutControl1
        Me.txtNov.TabIndex = 4
        '
        'txtJun
        '
        Me.txtJun.Location = New System.Drawing.Point(300, 192)
        Me.txtJun.Name = "txtJun"
        Me.txtJun.Properties.Mask.EditMask = "\d\d"
        Me.txtJun.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtJun.Size = New System.Drawing.Size(273, 20)
        Me.txtJun.StyleController = Me.LayoutControl1
        Me.txtJun.TabIndex = 4
        '
        'txtDec
        '
        Me.txtDec.Location = New System.Drawing.Point(300, 312)
        Me.txtDec.Name = "txtDec"
        Me.txtDec.Properties.Mask.EditMask = "\d\d"
        Me.txtDec.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtDec.Size = New System.Drawing.Size(273, 20)
        Me.txtDec.StyleController = Me.LayoutControl1
        Me.txtDec.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlItem13, Me.LayoutControlItem14})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(597, 363)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem6, Me.LayoutControlItem10, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem11, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem8, Me.LayoutControlItem12})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 53)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(577, 290)
        Me.LayoutControlGroup2.Text = " "
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtJan
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(276, 40)
        Me.LayoutControlItem1.Text = "January"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtSep
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 160)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(276, 40)
        Me.LayoutControlItem6.Text = "September"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtNov
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 200)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(276, 47)
        Me.LayoutControlItem10.Text = "November"
        Me.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtFeb
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(276, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(277, 40)
        Me.LayoutControlItem3.Text = "Febuary"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtMar
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(276, 40)
        Me.LayoutControlItem5.Text = "March"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtApr
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(276, 40)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(277, 40)
        Me.LayoutControlItem7.Text = "April"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtMay
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 80)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(276, 40)
        Me.LayoutControlItem9.Text = "May"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtJun
        Me.LayoutControlItem11.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(276, 80)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(277, 40)
        Me.LayoutControlItem11.Text = "June"
        Me.LayoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtJul
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(276, 40)
        Me.LayoutControlItem2.Text = "July"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtAug
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(276, 120)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(277, 40)
        Me.LayoutControlItem4.Text = "August"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtOct
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(276, 160)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(277, 40)
        Me.LayoutControlItem8.Text = "October"
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtDec
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(276, 200)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(277, 47)
        Me.LayoutControlItem12.Text = "December"
        Me.LayoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.txtName
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 15)
        Me.LayoutControlItem13.Size = New System.Drawing.Size(399, 53)
        Me.LayoutControlItem13.Text = "Calendar Name"
        Me.LayoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(73, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.cboType
        Me.LayoutControlItem14.Location = New System.Drawing.Point(399, 0)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(178, 53)
        Me.LayoutControlItem14.Text = "Type"
        Me.LayoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(73, 13)
        '
        'WageScaleCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "WageScaleCalendar"
        Me.Size = New System.Drawing.Size(601, 387)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJul.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFeb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAug.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSep.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNov.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtJan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtJul As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFeb As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAug As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSep As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtApr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtOct As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNov As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtJun As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDec As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem

End Class
