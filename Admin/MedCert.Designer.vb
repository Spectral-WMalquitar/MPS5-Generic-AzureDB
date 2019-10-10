<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MedCert
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MedCert))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkAllowDuplicate = New DevExpress.XtraEditors.CheckEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtFileTag = New DevExpress.XtraEditors.TextEdit()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.txtValDesc = New DevExpress.XtraEditors.TextEdit()
        Me.txtValidity = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.txtBufferNo = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkAllowDuplicate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFileTag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValidity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBufferNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(608, 355)
        Me.header.TabIndex = 4
        Me.header.Text = "Medical Document Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkAllowDuplicate)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
        Me.LayoutControl1.Controls.Add(Me.txtFileTag)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.txtValDesc)
        Me.LayoutControl1.Controls.Add(Me.txtValidity)
        Me.LayoutControl1.Controls.Add(Me.txtBufferNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 22)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(574, 142, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(604, 331)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkAllowDuplicate
        '
        Me.chkAllowDuplicate.Location = New System.Drawing.Point(487, 89)
        Me.chkAllowDuplicate.Name = "chkAllowDuplicate"
        Me.chkAllowDuplicate.Properties.Caption = "Allow Duplicate"
        Me.chkAllowDuplicate.Size = New System.Drawing.Size(95, 19)
        Me.chkAllowDuplicate.StyleController = Me.LayoutControl1
        Me.chkAllowDuplicate.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(20, 36)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 200
        Me.txtName.Size = New System.Drawing.Size(197, 20)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        Me.txtName.ToolTip = "Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(217, 36)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(367, 20)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'txtFileTag
        '
        Me.txtFileTag.Location = New System.Drawing.Point(20, 87)
        Me.txtFileTag.Name = "txtFileTag"
        Me.txtFileTag.Properties.Mask.EditMask = "[a-zA-Z0-9]{0,5}"
        Me.txtFileTag.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtFileTag.Properties.MaxLength = 5
        Me.txtFileTag.Size = New System.Drawing.Size(116, 20)
        Me.txtFileTag.StyleController = Me.LayoutControl1
        Me.txtFileTag.TabIndex = 4
        Me.txtFileTag.ToolTip = "File Tag"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(20, 138)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Properties.MaxLength = 200
        Me.txtRemarks.Size = New System.Drawing.Size(564, 16)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 4
        Me.txtRemarks.ToolTip = "Remarks"
        '
        'txtValDesc
        '
        Me.txtValDesc.Location = New System.Drawing.Point(255, 87)
        Me.txtValDesc.Name = "txtValDesc"
        Me.txtValDesc.Properties.Mask.EditMask = "\d?\d?\.\d?\d?\.\d?\d?\.\d?\d?"
        Me.txtValDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtValDesc.Properties.ReadOnly = True
        Me.txtValDesc.Size = New System.Drawing.Size(109, 20)
        Me.txtValDesc.StyleController = Me.LayoutControl1
        Me.txtValDesc.TabIndex = 4
        Me.txtValDesc.ToolTip = "Validity"
        '
        'txtValidity
        '
        Me.txtValidity.EditValue = ""
        Me.txtValidity.Location = New System.Drawing.Point(136, 87)
        Me.txtValidity.Name = "txtValidity"
        Me.txtValidity.Properties.EditFormat.FormatString = "\d?\d?\.\d?\d?\.\d?\d?"
        Me.txtValidity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtValidity.Properties.Mask.EditMask = "\d?\d?\.\d?\d?\.\d?\d?"
        Me.txtValidity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtValidity.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtValidity.Size = New System.Drawing.Size(119, 20)
        Me.txtValidity.StyleController = Me.LayoutControl1
        Me.txtValidity.TabIndex = 4
        Me.txtValidity.ToolTip = "Validity (YY.MM.WW.DD)"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.EmptySpaceItem1, Me.LayoutControlItem6, Me.LayoutControlItem3, Me.LayoutControlItem7, Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(604, 331)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(197, 51)
        Me.LayoutControlItem1.Text = "* Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtRemarks
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(564, 47)
        Me.LayoutControlItem5.Text = "Remarks"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtSortCode
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(197, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(367, 51)
        Me.LayoutControlItem2.Text = "Sort Code"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtFileTag
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(116, 51)
        Me.LayoutControlItem4.Text = "* DMS File Code"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(95, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 149)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(564, 142)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtValDesc
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(235, 51)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(109, 51)
        Me.LayoutControlItem6.Text = "Validity Description"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtValidity
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(116, 51)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(119, 51)
        Me.LayoutControlItem3.Text = "Validity (YY.MM.DD)"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.chkAllowDuplicate
        Me.LayoutControlItem7.Location = New System.Drawing.Point(465, 51)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(99, 51)
        Me.LayoutControlItem7.Text = " "
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(95, 13)
        '
        'txtBufferNo
        '
        Me.txtBufferNo.EditValue = "0"
        Me.txtBufferNo.Location = New System.Drawing.Point(364, 87)
        Me.txtBufferNo.Name = "txtBufferNo"
        Me.txtBufferNo.Properties.Mask.EditMask = "f"
        Me.txtBufferNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtBufferNo.Size = New System.Drawing.Size(121, 20)
        Me.txtBufferNo.StyleController = Me.LayoutControl1
        Me.txtBufferNo.TabIndex = 4
        Me.txtBufferNo.ToolTip = "SortCode"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtBufferNo
        Me.LayoutControlItem9.CustomizationFormText = "Buffer Days"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(344, 51)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(121, 51)
        Me.LayoutControlItem9.Text = "Buffer Days"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(95, 13)
        '
        'MedCert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "MedCert"
        Me.Size = New System.Drawing.Size(608, 355)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkAllowDuplicate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFileTag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValidity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBufferNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFileTag As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtValDesc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtValidity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkAllowDuplicate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBufferNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem

End Class
