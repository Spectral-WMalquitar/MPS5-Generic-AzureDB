<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnect
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnect))
        Me.txtServer = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUser = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPwd = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cboAuth = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblAuth = New DevExpress.XtraEditors.LabelControl()
        Me.cmdTest = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cboAuth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(175, 35)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(193, 20)
        Me.txtServer.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(31, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Server Instance"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(31, 87)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "User Name"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(175, 84)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(193, 20)
        Me.txtUser.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(31, 113)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Password"
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(175, 110)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(193, 20)
        Me.txtPwd.TabIndex = 3
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.cboAuth)
        Me.GroupControl1.Controls.Add(Me.lblAuth)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtServer)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.txtPwd)
        Me.GroupControl1.Controls.Add(Me.txtUser)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Location = New System.Drawing.Point(33, 55)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(405, 157)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "SQL Server Configuration"
        '
        'cboAuth
        '
        Me.cboAuth.Location = New System.Drawing.Point(175, 60)
        Me.cboAuth.Name = "cboAuth"
        Me.cboAuth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAuth.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboAuth.Properties.DisplayMember = "Name"
        Me.cboAuth.Properties.DropDownRows = 3
        Me.cboAuth.Properties.NullText = ""
        Me.cboAuth.Properties.ShowFooter = False
        Me.cboAuth.Properties.ShowHeader = False
        Me.cboAuth.Properties.ValueMember = "PKey"
        Me.cboAuth.Size = New System.Drawing.Size(193, 20)
        Me.cboAuth.TabIndex = 13
        '
        'lblAuth
        '
        Me.lblAuth.Location = New System.Drawing.Point(31, 63)
        Me.lblAuth.Name = "lblAuth"
        Me.lblAuth.Size = New System.Drawing.Size(70, 13)
        Me.lblAuth.TabIndex = 12
        Me.lblAuth.Text = "Authentication"
        '
        'cmdTest
        '
        Me.cmdTest.Location = New System.Drawing.Point(33, 230)
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.Size = New System.Drawing.Size(98, 32)
        Me.cmdTest.TabIndex = 5
        Me.cmdTest.Text = "Test Connection"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(340, 230)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(98, 32)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(230, 230)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(98, 32)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(33, 22)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(368, 13)
        Me.LabelControl7.TabIndex = 12
        Me.LabelControl7.Text = "Please fill up the proper authentication details for the database shown below"
        '
        'frmConnect
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 278)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdTest)
        Me.Controls.Add(Me.GroupControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Server Connection"
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.cboAuth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAuth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboAuth As DevExpress.XtraEditors.LookUpEdit
End Class
