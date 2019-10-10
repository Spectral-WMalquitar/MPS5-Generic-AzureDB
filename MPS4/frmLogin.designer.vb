<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdDatabase = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciResetConn = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.cboUsers = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.rPwd = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciUserName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPassword = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciRememberPass = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciForgotPass = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciResetConn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUsers.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciRememberPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciForgotPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Controls.Add(Me.LayoutControl2)
        Me.LayoutControl1.Controls.Add(Me.LinkLabel1)
        Me.LayoutControl1.Controls.Add(Me.cboUsers)
        Me.LayoutControl1.Controls.Add(Me.txtPassword)
        Me.LayoutControl1.Controls.Add(Me.rPwd)
        Me.LayoutControl1.Controls.Add(Me.cmdOk)
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(637, 108, 459, 383)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(397, 289)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.cmdDatabase)
        Me.LayoutControl2.Location = New System.Drawing.Point(195, 152)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.Root = Me.Root
        Me.LayoutControl2.Size = New System.Drawing.Size(180, 83)
        Me.LayoutControl2.TabIndex = 14
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'cmdDatabase
        '
        Me.cmdDatabase.Location = New System.Drawing.Point(12, 12)
        Me.cmdDatabase.Name = "cmdDatabase"
        Me.cmdDatabase.Size = New System.Drawing.Size(156, 23)
        Me.cmdDatabase.StyleController = Me.LayoutControl2
        Me.cmdDatabase.TabIndex = 13
        Me.cmdDatabase.Text = "Reset Connection"
        Me.cmdDatabase.Visible = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciResetConn})
        Me.Root.Location = New System.Drawing.Point(0, 0)
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(180, 83)
        Me.Root.TextVisible = False
        '
        'lciResetConn
        '
        Me.lciResetConn.Control = Me.cmdDatabase
        Me.lciResetConn.Location = New System.Drawing.Point(0, 0)
        Me.lciResetConn.Name = "lciResetConn"
        Me.lciResetConn.Size = New System.Drawing.Size(160, 63)
        Me.lciResetConn.TextSize = New System.Drawing.Size(0, 0)
        Me.lciResetConn.TextVisible = False
        Me.lciResetConn.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(22, 128)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(353, 20)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Forgot Password"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboUsers
        '
        Me.cboUsers.Location = New System.Drawing.Point(20, 39)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboUsers.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Password", "Password", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboUsers.Properties.DisplayMember = "Name"
        Me.cboUsers.Properties.DropDownRows = 10
        Me.cboUsers.Properties.NullText = ""
        Me.cboUsers.Properties.ShowFooter = False
        Me.cboUsers.Properties.ShowHeader = False
        Me.cboUsers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboUsers.Properties.ValueMember = "ID"
        Me.cboUsers.Size = New System.Drawing.Size(357, 22)
        Me.cboUsers.StyleController = Me.LayoutControl1
        Me.cboUsers.TabIndex = 7
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(20, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.UseSystemPasswordChar = True
        Me.txtPassword.Size = New System.Drawing.Size(357, 22)
        Me.txtPassword.StyleController = Me.LayoutControl1
        Me.txtPassword.TabIndex = 7
        '
        'rPwd
        '
        Me.rPwd.AutoSizeInLayoutControl = True
        Me.rPwd.EditValue = True
        Me.rPwd.Location = New System.Drawing.Point(126, 104)
        Me.rPwd.Name = "rPwd"
        Me.rPwd.Properties.Caption = "Remember Password"
        Me.rPwd.Size = New System.Drawing.Size(144, 20)
        Me.rPwd.StyleController = Me.LayoutControl1
        Me.rPwd.TabIndex = 8
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(67, 239)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(126, 28)
        Me.cmdOk.StyleController = Me.LayoutControl1
        Me.cmdOk.TabIndex = 11
        Me.cmdOk.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(203, 239)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(126, 28)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "Cancel"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciUserName, Me.lciPassword, Me.lciRememberPass, Me.lciForgotPass, Me.EmptySpaceItem3, Me.emptySpaceItem1, Me.emptySpaceItem2, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem1, Me.EmptySpaceItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(397, 289)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'lciUserName
        '
        Me.lciUserName.Control = Me.cboUsers
        Me.lciUserName.CustomizationFormText = "LayoutControlItem3"
        Me.lciUserName.Location = New System.Drawing.Point(0, 0)
        Me.lciUserName.Name = "lciUserName"
        Me.lciUserName.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lciUserName.Size = New System.Drawing.Size(357, 41)
        Me.lciUserName.Text = "User Name"
        Me.lciUserName.TextLocation = DevExpress.Utils.Locations.Top
        Me.lciUserName.TextSize = New System.Drawing.Size(63, 16)
        '
        'lciPassword
        '
        Me.lciPassword.Control = Me.txtPassword
        Me.lciPassword.CustomizationFormText = "Password"
        Me.lciPassword.Location = New System.Drawing.Point(0, 41)
        Me.lciPassword.Name = "lciPassword"
        Me.lciPassword.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lciPassword.Size = New System.Drawing.Size(357, 41)
        Me.lciPassword.Text = "Password"
        Me.lciPassword.TextLocation = DevExpress.Utils.Locations.Top
        Me.lciPassword.TextSize = New System.Drawing.Size(63, 16)
        '
        'lciRememberPass
        '
        Me.lciRememberPass.Control = Me.rPwd
        Me.lciRememberPass.ControlAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.lciRememberPass.CustomizationFormText = "LayoutControlItem5"
        Me.lciRememberPass.Location = New System.Drawing.Point(0, 82)
        Me.lciRememberPass.Name = "lciRememberPass"
        Me.lciRememberPass.Size = New System.Drawing.Size(357, 24)
        Me.lciRememberPass.TextSize = New System.Drawing.Size(0, 0)
        Me.lciRememberPass.TextVisible = False
        '
        'lciForgotPass
        '
        Me.lciForgotPass.Control = Me.LinkLabel1
        Me.lciForgotPass.Location = New System.Drawing.Point(0, 106)
        Me.lciForgotPass.Name = "lciForgotPass"
        Me.lciForgotPass.Size = New System.Drawing.Size(357, 24)
        Me.lciForgotPass.TextSize = New System.Drawing.Size(0, 0)
        Me.lciForgotPass.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 130)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(121, 29)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(173, 87)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'emptySpaceItem1
        '
        Me.emptySpaceItem1.AllowHotTrack = False
        Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
        Me.emptySpaceItem1.Location = New System.Drawing.Point(175, 217)
        Me.emptySpaceItem1.MaxSize = New System.Drawing.Size(6, 25)
        Me.emptySpaceItem1.MinSize = New System.Drawing.Size(6, 25)
        Me.emptySpaceItem1.Name = "emptySpaceItem1"
        Me.emptySpaceItem1.Size = New System.Drawing.Size(6, 32)
        Me.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'emptySpaceItem2
        '
        Me.emptySpaceItem2.AllowHotTrack = False
        Me.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2"
        Me.emptySpaceItem2.Location = New System.Drawing.Point(0, 217)
        Me.emptySpaceItem2.Name = "emptySpaceItem2"
        Me.emptySpaceItem2.Size = New System.Drawing.Size(45, 32)
        Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdOk
        Me.LayoutControlItem7.Location = New System.Drawing.Point(45, 217)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(130, 0)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(130, 32)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(130, 32)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmdCancel
        Me.LayoutControlItem8.Location = New System.Drawing.Point(181, 217)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(130, 0)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(130, 32)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(130, 32)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LayoutControl2
        Me.LayoutControlItem1.Location = New System.Drawing.Point(173, 130)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(144, 61)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(184, 87)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(311, 217)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(46, 32)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 289)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TopMost = True
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciResetConn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUsers.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciRememberPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciForgotPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboUsers As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lciUserName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciPassword As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents rPwd As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lciRememberPass As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lciForgotPass As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDatabase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lciResetConn As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
End Class
