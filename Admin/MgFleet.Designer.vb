﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MgFleet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MgFleet))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtLName = New DevExpress.XtraEditors.TextEdit()
        Me.txtFName = New DevExpress.XtraEditors.TextEdit()
        Me.txtMName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSortCode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtLName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(705, 255)
        Me.header.TabIndex = 3
        Me.header.Text = "Fleet Manager Details"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtLName)
        Me.LayoutControl1.Controls.Add(Me.txtFName)
        Me.LayoutControl1.Controls.Add(Me.txtMName)
        Me.LayoutControl1.Controls.Add(Me.txtSortCode)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(701, 231)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(20, 36)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(186, 20)
        Me.txtLName.StyleController = Me.LayoutControl1
        Me.txtLName.TabIndex = 4
        Me.txtLName.ToolTip = "Last Name"
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(206, 36)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(167, 20)
        Me.txtFName.StyleController = Me.LayoutControl1
        Me.txtFName.TabIndex = 4
        Me.txtFName.ToolTip = "First Name"
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(373, 36)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(160, 20)
        Me.txtMName.StyleController = Me.LayoutControl1
        Me.txtMName.TabIndex = 4
        Me.txtMName.ToolTip = "Middle Name"
        '
        'txtSortCode
        '
        Me.txtSortCode.Location = New System.Drawing.Point(533, 36)
        Me.txtSortCode.Name = "txtSortCode"
        Me.txtSortCode.Properties.Mask.EditMask = "f"
        Me.txtSortCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSortCode.Size = New System.Drawing.Size(148, 20)
        Me.txtSortCode.StyleController = Me.LayoutControl1
        Me.txtSortCode.TabIndex = 4
        Me.txtSortCode.ToolTip = "Sort Code"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(701, 231)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtLName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(186, 191)
        Me.LayoutControlItem1.Text = "* Last Name"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(60, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtFName
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(186, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(167, 191)
        Me.LayoutControlItem2.Text = "* First Name"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(60, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtMName
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(353, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(160, 191)
        Me.LayoutControlItem3.Text = "Middle Name"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(60, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtSortCode
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(513, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(148, 191)
        Me.LayoutControlItem4.Text = "Sort Code"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(60, 13)
        '
        'MgFleet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "MgFleet"
        Me.Size = New System.Drawing.Size(705, 255)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtLName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSortCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtLName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSortCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem

End Class
