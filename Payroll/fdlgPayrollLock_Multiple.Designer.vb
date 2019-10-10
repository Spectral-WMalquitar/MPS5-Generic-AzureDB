<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlgPayrollLock_Multiple
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlgPayrollLock_Multiple))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblDesc = New DevExpress.XtraEditors.LabelControl()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.txtPwd = New DevExpress.XtraEditors.TextEdit()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciPasswordField = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciDesc = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SharedImageCollection1 = New DevExpress.Utils.SharedImageCollection(Me.components)
        Me.lblDesc2 = New DevExpress.XtraEditors.LabelControl()
        Me.lciDesc2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPasswordField, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDesc2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.lblDesc2)
        Me.LayoutControl1.Controls.Add(Me.lblDesc)
        Me.LayoutControl1.Controls.Add(Me.cmdOK)
        Me.LayoutControl1.Controls.Add(Me.PictureEdit1)
        Me.LayoutControl1.Controls.Add(Me.txtPwd)
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(526, 192)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDesc.Location = New System.Drawing.Point(173, 54)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(331, 16)
        Me.lblDesc.StyleController = Me.LayoutControl1
        Me.lblDesc.TabIndex = 8
        Me.lblDesc.Text = "Enter password to lock/unlock payroll :"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(22, 157)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(234, 23)
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
        Me.PictureEdit1.Size = New System.Drawing.Size(119, 141)
        Me.PictureEdit1.StyleController = Me.LayoutControl1
        Me.PictureEdit1.TabIndex = 4
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(240, 105)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.UseSystemPasswordChar = True
        Me.txtPwd.Size = New System.Drawing.Size(264, 22)
        Me.txtPwd.StyleController = Me.LayoutControl1
        Me.txtPwd.TabIndex = 6
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(260, 157)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(244, 23)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup2, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 10, 10)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(526, 192)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PictureEdit1
        Me.LayoutControlItem1.FillControlToClientArea = False
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(123, 145)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(123, 145)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(123, 145)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        Me.LayoutControlItem1.TrimClientAreaToControl = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[False]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciPasswordField, Me.lciDesc, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.lciDesc2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(123, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(363, 145)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'lciPasswordField
        '
        Me.lciPasswordField.Control = Me.txtPwd
        Me.lciPasswordField.CustomizationFormText = "Period:"
        Me.lciPasswordField.Location = New System.Drawing.Point(0, 93)
        Me.lciPasswordField.Name = "lciPasswordField"
        Me.lciPasswordField.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 2, 2, 2)
        Me.lciPasswordField.Size = New System.Drawing.Size(363, 26)
        Me.lciPasswordField.Text = "Password :"
        Me.lciPasswordField.TextSize = New System.Drawing.Size(64, 16)
        '
        'lciDesc
        '
        Me.lciDesc.Control = Me.lblDesc
        Me.lciDesc.FillControlToClientArea = False
        Me.lciDesc.Location = New System.Drawing.Point(0, 42)
        Me.lciDesc.Name = "lciDesc"
        Me.lciDesc.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 2, 2, 2)
        Me.lciDesc.Size = New System.Drawing.Size(363, 20)
        Me.lciDesc.TextSize = New System.Drawing.Size(0, 0)
        Me.lciDesc.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(363, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 119)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(363, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 82)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(363, 11)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdOK
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 145)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(238, 27)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmdCancel
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(238, 145)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(248, 27)
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
        'lblDesc2
        '
        Me.lblDesc2.Location = New System.Drawing.Point(173, 74)
        Me.lblDesc2.Name = "lblDesc2"
        Me.lblDesc2.Size = New System.Drawing.Size(331, 16)
        Me.lblDesc2.StyleController = Me.LayoutControl1
        Me.lblDesc2.TabIndex = 9
        '
        'lciDesc2
        '
        Me.lciDesc2.Control = Me.lblDesc2
        Me.lciDesc2.Location = New System.Drawing.Point(0, 62)
        Me.lciDesc2.Name = "lciDesc2"
        Me.lciDesc2.Padding = New DevExpress.XtraLayout.Utils.Padding(30, 2, 2, 2)
        Me.lciDesc2.Size = New System.Drawing.Size(363, 20)
        Me.lciDesc2.TextSize = New System.Drawing.Size(0, 0)
        Me.lciDesc2.TextVisible = False
        '
        'fdlgPayrollLock_Multiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 192)
        Me.ControlBox = False
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "fdlgPayrollLock_Multiple"
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
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1.ImageSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SharedImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDesc2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lblDesc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lciDesc As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SharedImageCollection1 As DevExpress.Utils.SharedImageCollection
    Friend WithEvents txtPwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciPasswordField As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lblDesc2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lciDesc2 As DevExpress.XtraLayout.LayoutControlItem
End Class
