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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUsr = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPwd = New DevExpress.XtraEditors.TextEdit()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureEditLogo = New DevExpress.XtraEditors.PictureEdit()
        Me.lblLoginVer = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtUsr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEditLogo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(140, 25)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(176, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Enter your User Name and Password"
        '
        'txtUsr
        '
        Me.txtUsr.Location = New System.Drawing.Point(198, 57)
        Me.txtUsr.Name = "txtUsr"
        Me.txtUsr.Size = New System.Drawing.Size(151, 20)
        Me.txtUsr.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(140, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "User Name"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(140, 91)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Password"
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(198, 88)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(151, 20)
        Me.txtPwd.TabIndex = 4
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(82, 156)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(138, 32)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(226, 156)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(138, 32)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        '
        'PictureEditLogo
        '
        Me.PictureEditLogo.EditValue = Global.zServiceUI.My.Resources.Resources.backup_restore_icon
        Me.PictureEditLogo.Location = New System.Drawing.Point(24, 25)
        Me.PictureEditLogo.Name = "PictureEditLogo"
        Me.PictureEditLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditLogo.Properties.ShowMenu = False
        Me.PictureEditLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditLogo.Size = New System.Drawing.Size(87, 83)
        Me.PictureEditLogo.TabIndex = 1
        '
        'lblLoginVer
        '
        Me.lblLoginVer.Location = New System.Drawing.Point(198, 114)
        Me.lblLoginVer.Name = "lblLoginVer"
        Me.lblLoginVer.Size = New System.Drawing.Size(74, 13)
        Me.lblLoginVer.TabIndex = 8
        Me.lblLoginVer.Text = "Version 1.2.3.4"
        '
        'frmLogin
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblLoginVer)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtUsr)
        Me.Controls.Add(Me.PictureEditLogo)
        Me.Controls.Add(Me.LabelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.txtUsr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEditLogo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEditLogo As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtUsr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblLoginVer As DevExpress.XtraEditors.LabelControl
End Class
