<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.grpProgramInfo = New DevExpress.XtraEditors.GroupControl()
        Me.grpLicenseBy = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCompName = New DevExpress.XtraEditors.LabelControl()
        Me.lblVersionDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.hplSpectralLink = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblComAddr = New DevExpress.XtraEditors.LabelControl()
        Me.lblCompany = New DevExpress.XtraEditors.LabelControl()
        Me.lblProgramName = New System.Windows.Forms.Label()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpProgramInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProgramInfo.SuspendLayout()
        CType(Me.grpLicenseBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpLicenseBy.SuspendLayout()
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
        'grpProgramInfo
        '
        Me.grpProgramInfo.Controls.Add(Me.grpLicenseBy)
        Me.grpProgramInfo.Controls.Add(Me.lblProgramName)
        Me.grpProgramInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpProgramInfo.Location = New System.Drawing.Point(0, 0)
        Me.grpProgramInfo.Name = "grpProgramInfo"
        Me.grpProgramInfo.Size = New System.Drawing.Size(913, 513)
        Me.grpProgramInfo.TabIndex = 1
        Me.grpProgramInfo.Text = "Program Information"
        '
        'grpLicenseBy
        '
        Me.grpLicenseBy.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLicenseBy.Appearance.Options.UseFont = True
        Me.grpLicenseBy.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLicenseBy.AppearanceCaption.Options.UseFont = True
        Me.grpLicenseBy.Controls.Add(Me.LabelControl9)
        Me.grpLicenseBy.Controls.Add(Me.lblCompName)
        Me.grpLicenseBy.Controls.Add(Me.lblVersionDate)
        Me.grpLicenseBy.Controls.Add(Me.lblVersion)
        Me.grpLicenseBy.Controls.Add(Me.hplSpectralLink)
        Me.grpLicenseBy.Controls.Add(Me.LabelControl7)
        Me.grpLicenseBy.Controls.Add(Me.LabelControl6)
        Me.grpLicenseBy.Controls.Add(Me.LabelControl5)
        Me.grpLicenseBy.Controls.Add(Me.LabelControl4)
        Me.grpLicenseBy.Controls.Add(Me.LabelControl3)
        Me.grpLicenseBy.Controls.Add(Me.LabelControl2)
        Me.grpLicenseBy.Controls.Add(Me.LabelControl1)
        Me.grpLicenseBy.Controls.Add(Me.lblComAddr)
        Me.grpLicenseBy.Controls.Add(Me.lblCompany)
        Me.grpLicenseBy.Location = New System.Drawing.Point(47, 84)
        Me.grpLicenseBy.Name = "grpLicenseBy"
        Me.grpLicenseBy.Size = New System.Drawing.Size(330, 349)
        Me.grpLicenseBy.TabIndex = 1
        Me.grpLicenseBy.Text = "This product is licensed by:"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(25, 200)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl9.TabIndex = 13
        Me.LabelControl9.Text = "Website           :"
        '
        'lblCompName
        '
        Me.lblCompName.Location = New System.Drawing.Point(127, 296)
        Me.lblCompName.Name = "lblCompName"
        Me.lblCompName.Size = New System.Drawing.Size(85, 13)
        Me.lblCompName.TabIndex = 12
        Me.lblCompName.Text = "[Computer Name]"
        '
        'lblVersionDate
        '
        Me.lblVersionDate.Location = New System.Drawing.Point(126, 265)
        Me.lblVersionDate.Name = "lblVersionDate"
        Me.lblVersionDate.Size = New System.Drawing.Size(31, 13)
        Me.lblVersionDate.TabIndex = 11
        Me.lblVersionDate.Text = "[Date]"
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(126, 233)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(22, 13)
        Me.lblVersion.TabIndex = 10
        Me.lblVersion.Text = "0.00"
        '
        'hplSpectralLink
        '
        Me.hplSpectralLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.hplSpectralLink.Location = New System.Drawing.Point(127, 198)
        Me.hplSpectralLink.Name = "hplSpectralLink"
        Me.hplSpectralLink.Size = New System.Drawing.Size(105, 13)
        Me.hplSpectralLink.TabIndex = 9
        Me.hplSpectralLink.Text = "www.spectralasia.net"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(127, 162)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(125, 13)
        Me.LabelControl7.TabIndex = 8
        Me.LabelControl7.Text = "spectral@spectralasia.net"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(127, 131)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl6.TabIndex = 7
        Me.LabelControl6.Text = "+63 2 524 0455"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(24, 296)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Computer        :"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(24, 265)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Version Info    :"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(24, 233)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Version            :"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 162)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Email                :"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(25, 131)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Telephone       :"
        '
        'lblComAddr
        '
        Me.lblComAddr.Location = New System.Drawing.Point(16, 64)
        Me.lblComAddr.Name = "lblComAddr"
        Me.lblComAddr.Size = New System.Drawing.Size(301, 26)
        Me.lblComAddr.TabIndex = 1
        Me.lblComAddr.Text = "4th Floor, Suite 403 Marioco Bldg, 1945 M. Adriatico St. Malate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manila Philippin" & _
    "es"
        '
        'lblCompany
        '
        Me.lblCompany.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(25, 42)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(179, 14)
        Me.lblCompany.TabIndex = 0
        Me.lblCompany.Text = " © Spectral Technologies Inc."
        '
        'lblProgramName
        '
        Me.lblProgramName.AutoSize = True
        Me.lblProgramName.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramName.Location = New System.Drawing.Point(40, 33)
        Me.lblProgramName.Name = "lblProgramName"
        Me.lblProgramName.Size = New System.Drawing.Size(126, 42)
        Me.lblProgramName.TabIndex = 0
        Me.lblProgramName.Text = "MPS 5"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.grpProgramInfo)
        Me.Name = "About"
        Me.Size = New System.Drawing.Size(913, 513)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpProgramInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpProgramInfo.ResumeLayout(False)
        Me.grpProgramInfo.PerformLayout()
        CType(Me.grpLicenseBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpLicenseBy.ResumeLayout(False)
        Me.grpLicenseBy.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpProgramInfo As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grpLicenseBy As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblCompName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblVersionDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents hplSpectralLink As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblComAddr As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCompany As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblProgramName As System.Windows.Forms.Label
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl

End Class
