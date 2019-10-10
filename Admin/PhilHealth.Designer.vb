<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhilHealth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PhilHealth))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtRate = New DevExpress.XtraEditors.TextEdit()
        Me.txtSalary = New DevExpress.XtraEditors.TextEdit()
        Me.txtSalaryTo = New DevExpress.XtraEditors.TextEdit()
        Me.txtSalCredit = New DevExpress.XtraEditors.TextEdit()
        Me.txtMCREmployee = New DevExpress.XtraEditors.TextEdit()
        Me.txtMCREmployer = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layCtrlSalaryRange = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layCtrlPhilHealth = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layCtrlPhilHealthFixedAmount = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layCtrlPhilHealthPercentage = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.layCtrlSalCred = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalaryTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSalCredit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMCREmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMCREmployer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layCtrlSalaryRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layCtrlPhilHealth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layCtrlPhilHealthFixedAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layCtrlPhilHealthPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layCtrlSalCred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(656, 517)
        Me.header.TabIndex = 5
        Me.header.Text = "PhilHealth Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtRate)
        Me.LayoutControl1.Controls.Add(Me.txtSalary)
        Me.LayoutControl1.Controls.Add(Me.txtSalaryTo)
        Me.LayoutControl1.Controls.Add(Me.txtSalCredit)
        Me.LayoutControl1.Controls.Add(Me.txtMCREmployee)
        Me.LayoutControl1.Controls.Add(Me.txtMCREmployer)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(352, 207, 536, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(652, 489)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(57, 398)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Properties.Mask.EditMask = "p2"
        Me.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtRate.Size = New System.Drawing.Size(258, 22)
        Me.txtRate.StyleController = Me.LayoutControl1
        Me.txtRate.TabIndex = 5
        '
        'txtSalary
        '
        Me.txtSalary.Location = New System.Drawing.Point(32, 75)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.Properties.Mask.EditMask = "###,###,###,##0.00;"
        Me.txtSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSalary.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtSalary.Size = New System.Drawing.Size(274, 22)
        Me.txtSalary.StyleController = Me.LayoutControl1
        Me.txtSalary.TabIndex = 4
        '
        'txtSalaryTo
        '
        Me.txtSalaryTo.Location = New System.Drawing.Point(306, 75)
        Me.txtSalaryTo.Name = "txtSalaryTo"
        Me.txtSalaryTo.Properties.Mask.EditMask = "###,###,###,##0.00;"
        Me.txtSalaryTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSalaryTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtSalaryTo.Size = New System.Drawing.Size(314, 22)
        Me.txtSalaryTo.StyleController = Me.LayoutControl1
        Me.txtSalaryTo.TabIndex = 4
        '
        'txtSalCredit
        '
        Me.txtSalCredit.Location = New System.Drawing.Point(32, 177)
        Me.txtSalCredit.Name = "txtSalCredit"
        Me.txtSalCredit.Properties.Mask.EditMask = "###,###,###,##0.00;"
        Me.txtSalCredit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSalCredit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtSalCredit.Size = New System.Drawing.Size(588, 22)
        Me.txtSalCredit.StyleController = Me.LayoutControl1
        Me.txtSalCredit.TabIndex = 4
        '
        'txtMCREmployee
        '
        Me.txtMCREmployee.Location = New System.Drawing.Point(317, 309)
        Me.txtMCREmployee.Name = "txtMCREmployee"
        Me.txtMCREmployee.Properties.Mask.EditMask = "###,###,###,##0.00;"
        Me.txtMCREmployee.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMCREmployee.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtMCREmployee.Size = New System.Drawing.Size(300, 22)
        Me.txtMCREmployee.StyleController = Me.LayoutControl1
        Me.txtMCREmployee.TabIndex = 4
        '
        'txtMCREmployer
        '
        Me.txtMCREmployer.Location = New System.Drawing.Point(55, 309)
        Me.txtMCREmployer.Name = "txtMCREmployer"
        Me.txtMCREmployer.Properties.Mask.EditMask = "###,###,###,##0.00;"
        Me.txtMCREmployer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMCREmployer.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtMCREmployer.Size = New System.Drawing.Size(262, 22)
        Me.txtMCREmployer.StyleController = Me.LayoutControl1
        Me.txtMCREmployer.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.layCtrlSalaryRange, Me.layCtrlPhilHealth, Me.layCtrlSalCred})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(652, 489)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 417)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(612, 32)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'layCtrlSalaryRange
        '
        Me.layCtrlSalaryRange.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.layCtrlSalaryRange.AppearanceGroup.Options.UseFont = True
        Me.layCtrlSalaryRange.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.layCtrlSalaryRange.Location = New System.Drawing.Point(0, 0)
        Me.layCtrlSalaryRange.Name = "layCtrlSalaryRange"
        Me.layCtrlSalaryRange.Size = New System.Drawing.Size(612, 104)
        Me.layCtrlSalaryRange.Text = "Salary Range"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtSalary
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(274, 56)
        Me.LayoutControlItem1.Text = "* From"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(86, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSalaryTo
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(274, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(314, 56)
        Me.LayoutControlItem2.Text = "* To"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(86, 16)
        '
        'layCtrlPhilHealth
        '
        Me.layCtrlPhilHealth.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.layCtrlPhilHealth.AppearanceGroup.Options.UseFont = True
        Me.layCtrlPhilHealth.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layCtrlPhilHealthFixedAmount, Me.layCtrlPhilHealthPercentage})
        Me.layCtrlPhilHealth.Location = New System.Drawing.Point(0, 206)
        Me.layCtrlPhilHealth.Name = "layCtrlPhilHealth"
        Me.layCtrlPhilHealth.Size = New System.Drawing.Size(612, 211)
        Me.layCtrlPhilHealth.Text = "Contribution"
        '
        'layCtrlPhilHealthFixedAmount
        '
        Me.layCtrlPhilHealthFixedAmount.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.layCtrlPhilHealthFixedAmount.AppearanceGroup.Options.UseFont = True
        Me.layCtrlPhilHealthFixedAmount.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.layCtrlPhilHealthFixedAmount.Location = New System.Drawing.Point(0, 0)
        Me.layCtrlPhilHealthFixedAmount.Name = "layCtrlPhilHealthFixedAmount"
        Me.layCtrlPhilHealthFixedAmount.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 0, 5, 0)
        Me.layCtrlPhilHealthFixedAmount.Size = New System.Drawing.Size(588, 87)
        Me.layCtrlPhilHealthFixedAmount.Text = "Fixed Amount"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtMCREmployer
        Me.LayoutControlItem4.CustomizationFormText = "layCtrlPhilHealth"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(262, 56)
        Me.LayoutControlItem4.Text = "* Employer"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(86, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtMCREmployee
        Me.LayoutControlItem5.CustomizationFormText = "layCtrlPhilHealth"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(262, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(300, 56)
        Me.LayoutControlItem5.Text = "* Employee"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(86, 16)
        '
        'layCtrlPhilHealthPercentage
        '
        Me.layCtrlPhilHealthPercentage.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.layCtrlPhilHealthPercentage.AppearanceGroup.Options.UseFont = True
        Me.layCtrlPhilHealthPercentage.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.EmptySpaceItem2})
        Me.layCtrlPhilHealthPercentage.Location = New System.Drawing.Point(0, 87)
        Me.layCtrlPhilHealthPercentage.Name = "layCtrlPhilHealthPercentage"
        Me.layCtrlPhilHealthPercentage.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 0, 5, 0)
        Me.layCtrlPhilHealthPercentage.Size = New System.Drawing.Size(588, 76)
        Me.layCtrlPhilHealthPercentage.Text = "By Rate (%)"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtRate
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(262, 45)
        Me.LayoutControlItem6.Text = "* Rate"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(86, 16)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(262, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(300, 45)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'layCtrlSalCred
        '
        Me.layCtrlSalCred.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.layCtrlSalCred.Location = New System.Drawing.Point(0, 104)
        Me.layCtrlSalCred.Name = "layCtrlSalCred"
        Me.layCtrlSalCred.Size = New System.Drawing.Size(612, 102)
        Me.layCtrlSalCred.Text = "  "
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtSalCredit
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(588, 56)
        Me.LayoutControlItem3.Text = "* Salary Credit"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(86, 16)
        '
        'PhilHealth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "PhilHealth"
        Me.Size = New System.Drawing.Size(656, 517)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalaryTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSalCredit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMCREmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMCREmployer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layCtrlSalaryRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layCtrlPhilHealth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layCtrlPhilHealthFixedAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layCtrlPhilHealthPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layCtrlSalCred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtSalary As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSalaryTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSalCredit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtMCREmployee As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtMCREmployer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layCtrlSalaryRange As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents layCtrlPhilHealth As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents layCtrlSalCred As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtRate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents layCtrlPhilHealthFixedAmount As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents layCtrlPhilHealthPercentage As DevExpress.XtraLayout.LayoutControlGroup

End Class
