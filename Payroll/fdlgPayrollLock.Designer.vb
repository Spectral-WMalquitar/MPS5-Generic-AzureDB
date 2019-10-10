<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgPayrollLock
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgPayrollLock))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblPeriod = New DevExpress.XtraEditors.LabelControl()
        Me.lblDesc = New DevExpress.XtraEditors.LabelControl()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.txtPwd = New DevExpress.XtraEditors.TextEdit()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblVsl = New DevExpress.XtraEditors.LabelControl()
        Me.lvlRefNo = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciPasswordField = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciDesc = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPasswordField, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.lblPeriod)
        Me.LayoutControl1.Controls.Add(Me.lblDesc)
        Me.LayoutControl1.Controls.Add(Me.cmdOK)
        Me.LayoutControl1.Controls.Add(Me.PictureEdit1)
        Me.LayoutControl1.Controls.Add(Me.txtPwd)
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Controls.Add(Me.lblVsl)
        Me.LayoutControl1.Controls.Add(Me.lvlRefNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(788, 96, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(451, 138)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPeriod.Location = New System.Drawing.Point(201, 29)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(228, 13)
        Me.lblPeriod.StyleController = Me.LayoutControl1
        Me.lblPeriod.TabIndex = 9
        Me.lblPeriod.Text = "Period"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDesc.Location = New System.Drawing.Point(130, 12)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(299, 13)
        Me.lblDesc.StyleController = Me.LayoutControl1
        Me.lblDesc.TabIndex = 8
        Me.lblDesc.Text = "Enter password to lock/unlock payroll :"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(22, 104)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(197, 22)
        Me.cmdOK.StyleController = Me.LayoutControl1
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "OK"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(22, 12)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.[False]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit1.Size = New System.Drawing.Size(76, 76)
        Me.PictureEdit1.StyleController = Me.LayoutControl1
        Me.PictureEdit1.TabIndex = 4
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(186, 80)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.UseSystemPasswordChar = True
        Me.txtPwd.Size = New System.Drawing.Size(243, 20)
        Me.txtPwd.StyleController = Me.LayoutControl1
        Me.txtPwd.TabIndex = 6
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(223, 104)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(206, 22)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        '
        'lblVsl
        '
        Me.lblVsl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblVsl.Location = New System.Drawing.Point(201, 46)
        Me.lblVsl.Name = "lblVsl"
        Me.lblVsl.Size = New System.Drawing.Size(228, 13)
        Me.lblVsl.StyleController = Me.LayoutControl1
        Me.lblVsl.TabIndex = 9
        Me.lblVsl.Text = "Vessel"
        '
        'lvlRefNo
        '
        Me.lvlRefNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lvlRefNo.Location = New System.Drawing.Point(201, 63)
        Me.lvlRefNo.Name = "lvlRefNo"
        Me.lvlRefNo.Size = New System.Drawing.Size(228, 13)
        Me.lvlRefNo.StyleController = Me.LayoutControl1
        Me.lvlRefNo.TabIndex = 9
        Me.lvlRefNo.Text = "refNo"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup2, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 10, 10)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(451, 138)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PictureEdit1
        Me.LayoutControlItem1.FillControlToClientArea = False
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(80, 80)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(80, 80)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(80, 92)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        Me.LayoutControlItem1.TrimClientAreaToControl = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciPasswordField, Me.lciDesc, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(80, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(331, 92)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'lciPasswordField
        '
        Me.lciPasswordField.Control = Me.txtPwd
        Me.lciPasswordField.CustomizationFormText = "Period:"
        Me.lciPasswordField.Location = New System.Drawing.Point(0, 68)
        Me.lciPasswordField.Name = "lciPasswordField"
        Me.lciPasswordField.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 2, 2, 2)
        Me.lciPasswordField.Size = New System.Drawing.Size(331, 24)
        Me.lciPasswordField.Text = "Password :"
        Me.lciPasswordField.TextSize = New System.Drawing.Size(53, 13)
        '
        'lciDesc
        '
        Me.lciDesc.Control = Me.lblDesc
        Me.lciDesc.FillControlToClientArea = False
        Me.lciDesc.Location = New System.Drawing.Point(0, 0)
        Me.lciDesc.Name = "lciDesc"
        Me.lciDesc.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 2, 2, 2)
        Me.lciDesc.Size = New System.Drawing.Size(331, 17)
        Me.lciDesc.TextSize = New System.Drawing.Size(0, 0)
        Me.lciDesc.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lblPeriod
        Me.LayoutControlItem3.FillControlToClientArea = False
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 17)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(45, 2, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(331, 17)
        Me.LayoutControlItem3.Text = "Period :"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(53, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.lblVsl
        Me.LayoutControlItem9.CustomizationFormText = "Period :"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(45, 2, 2, 2)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(331, 17)
        Me.LayoutControlItem9.Text = "Vessel :"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(53, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.lvlRefNo
        Me.LayoutControlItem10.CustomizationFormText = "Period :"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(45, 2, 2, 2)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(331, 17)
        Me.LayoutControlItem10.Text = "Ref. No. :"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(53, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdOK
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 92)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(201, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmdCancel
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(201, 92)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(210, 26)
        Me.LayoutControlItem8.Text = "LayoutControlItem7"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'SharedImageCollection1
        '
        '
        '
        '
        Me.SharedImageCollection1.ImageSource.ImageStream = CType(resources.GetObject("SharedImageCollection1.ImageSource.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(0, "payroll_Unlock_icon.png")
        Me.SharedImageCollection1.ImageSource.Images.SetKeyName(1, "payroll_lock_icon.png")
        Me.SharedImageCollection1.ParentControl = Me
        '
        'fdlgPayrollLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "fdlgPayrollLock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lock / Unlock Payroll"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPasswordField, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDesc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciPasswordField As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lblDesc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lciDesc As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblPeriod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblVsl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lvlRefNo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SharedImageCollection1 As DevExpress.Utils.SharedImageCollection
End Class
