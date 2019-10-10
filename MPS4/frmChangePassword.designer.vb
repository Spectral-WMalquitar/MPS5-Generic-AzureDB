<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePassword))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtOldPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtNewPass = New DevExpress.XtraEditors.TextEdit()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtConfirmPassword = New DevExpress.XtraEditors.TextEdit()
        Me.cboSecQuestion = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtSecAnswer = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.emptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.emptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgQuestion = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciSA = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciSQ = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgNewPass = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtOldPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNewPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSecQuestion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSecAnswer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciSA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciSQ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgNewPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Controls.Add(Me.txtOldPassword)
        Me.LayoutControl1.Controls.Add(Me.txtNewPass)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtConfirmPassword)
        Me.LayoutControl1.Controls.Add(Me.cboSecQuestion)
        Me.LayoutControl1.Controls.Add(Me.txtSecAnswer)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(537, 82, 443, 427)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(391, 375)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(271, 283)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(98, 23)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "C&ancel"
        '
        'txtOldPassword
        '
        Me.txtOldPassword.Location = New System.Drawing.Point(33, 53)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.Properties.UseSystemPasswordChar = True
        Me.txtOldPassword.Size = New System.Drawing.Size(325, 22)
        Me.txtOldPassword.StyleController = Me.LayoutControl1
        Me.txtOldPassword.TabIndex = 4
        '
        'txtNewPass
        '
        Me.txtNewPass.Location = New System.Drawing.Point(33, 94)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Properties.UseSystemPasswordChar = True
        Me.txtNewPass.Size = New System.Drawing.Size(325, 22)
        Me.txtNewPass.StyleController = Me.LayoutControl1
        Me.txtNewPass.TabIndex = 4
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(161, 283)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(88, 23)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "&Save"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(33, 135)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Properties.UseSystemPasswordChar = True
        Me.txtConfirmPassword.Size = New System.Drawing.Size(325, 22)
        Me.txtConfirmPassword.StyleController = Me.LayoutControl1
        Me.txtConfirmPassword.TabIndex = 4
        '
        'cboSecQuestion
        '
        Me.cboSecQuestion.Location = New System.Drawing.Point(33, 204)
        Me.cboSecQuestion.Name = "cboSecQuestion"
        Me.cboSecQuestion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSecQuestion.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Question", "Questions")})
        Me.cboSecQuestion.Properties.DisplayMember = "Question"
        Me.cboSecQuestion.Properties.DropDownRows = 6
        Me.cboSecQuestion.Properties.NullText = ""
        Me.cboSecQuestion.Properties.ShowFooter = False
        Me.cboSecQuestion.Properties.ShowHeader = False
        Me.cboSecQuestion.Properties.ValueMember = "Code"
        Me.cboSecQuestion.Size = New System.Drawing.Size(325, 22)
        Me.cboSecQuestion.StyleController = Me.LayoutControl1
        Me.cboSecQuestion.TabIndex = 7
        '
        'txtSecAnswer
        '
        Me.txtSecAnswer.Location = New System.Drawing.Point(33, 245)
        Me.txtSecAnswer.Name = "txtSecAnswer"
        Me.txtSecAnswer.Properties.MaxLength = 30
        Me.txtSecAnswer.Size = New System.Drawing.Size(325, 22)
        Me.txtSecAnswer.StyleController = Me.LayoutControl1
        Me.txtSecAnswer.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.emptySpaceItem1, Me.emptySpaceItem2, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.lcgQuestion, Me.lcgNewPass, Me.EmptySpaceItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(391, 375)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'emptySpaceItem1
        '
        Me.emptySpaceItem1.AllowHotTrack = False
        Me.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1"
        Me.emptySpaceItem1.Location = New System.Drawing.Point(231, 261)
        Me.emptySpaceItem1.Name = "emptySpaceItem1"
        Me.emptySpaceItem1.Size = New System.Drawing.Size(18, 27)
        Me.emptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'emptySpaceItem2
        '
        Me.emptySpaceItem2.AllowHotTrack = False
        Me.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2"
        Me.emptySpaceItem2.Location = New System.Drawing.Point(0, 261)
        Me.emptySpaceItem2.Name = "emptySpaceItem2"
        Me.emptySpaceItem2.Size = New System.Drawing.Size(139, 27)
        Me.emptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdSave
        Me.LayoutControlItem6.Location = New System.Drawing.Point(139, 261)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(92, 27)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(92, 27)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(92, 27)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdCancel
        Me.LayoutControlItem7.Location = New System.Drawing.Point(249, 261)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(102, 27)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(102, 27)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(102, 27)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'lcgQuestion
        '
        Me.lcgQuestion.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciSA, Me.lciSQ})
        Me.lcgQuestion.Location = New System.Drawing.Point(0, 151)
        Me.lcgQuestion.Name = "lcgQuestion"
        Me.lcgQuestion.Size = New System.Drawing.Size(351, 110)
        Me.lcgQuestion.Text = "Security"
        Me.lcgQuestion.TextVisible = False
        Me.lcgQuestion.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'lciSA
        '
        Me.lciSA.Control = Me.txtSecAnswer
        Me.lciSA.CustomizationFormText = "Current Password"
        Me.lciSA.Location = New System.Drawing.Point(0, 41)
        Me.lciSA.Name = "lciSA"
        Me.lciSA.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lciSA.Size = New System.Drawing.Size(325, 41)
        Me.lciSA.Text = "Answer"
        Me.lciSA.TextLocation = DevExpress.Utils.Locations.Top
        Me.lciSA.TextSize = New System.Drawing.Size(165, 16)
        '
        'lciSQ
        '
        Me.lciSQ.Control = Me.cboSecQuestion
        Me.lciSQ.CustomizationFormText = "LayoutControlItem3"
        Me.lciSQ.Location = New System.Drawing.Point(0, 0)
        Me.lciSQ.Name = "lciSQ"
        Me.lciSQ.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lciSQ.Size = New System.Drawing.Size(325, 41)
        Me.lciSQ.Text = "Password Recovery Question"
        Me.lciSQ.TextLocation = DevExpress.Utils.Locations.Top
        Me.lciSQ.TextSize = New System.Drawing.Size(165, 16)
        '
        'lcgNewPass
        '
        Me.lcgNewPass.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem2, Me.LayoutControlItem1})
        Me.lcgNewPass.Location = New System.Drawing.Point(0, 0)
        Me.lcgNewPass.Name = "lcgNewPass"
        Me.lcgNewPass.Size = New System.Drawing.Size(351, 151)
        Me.lcgNewPass.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtConfirmPassword
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(325, 41)
        Me.LayoutControlItem3.Text = "Confirm Password"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(165, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtNewPass
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 41)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(325, 41)
        Me.LayoutControlItem2.Text = "New Password"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(165, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtOldPassword
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(325, 41)
        Me.LayoutControlItem1.Text = "Current Password"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(165, 16)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 288)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(351, 47)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 375)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.TopMost = True
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtOldPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNewPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSecQuestion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSecAnswer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.emptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciSA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciSQ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgNewPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNewPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtConfirmPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents emptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents emptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboSecQuestion As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lciSQ As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSecAnswer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciSA As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgQuestion As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtOldPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lcgNewPass As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
End Class
