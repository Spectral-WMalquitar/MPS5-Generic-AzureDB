<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPS4Splash_Crew
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPS4Splash_Crew))
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.marqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.lblCopyright = New DevExpress.XtraEditors.LabelControl()
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(31, 254)
        Me.labelControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(57, 16)
        Me.labelControl2.TabIndex = 12
        Me.labelControl2.Text = "Starting..."
        '
        'marqueeProgressBarControl1
        '
        Me.marqueeProgressBarControl1.EditValue = 0
        Me.marqueeProgressBarControl1.Location = New System.Drawing.Point(31, 284)
        Me.marqueeProgressBarControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1"
        Me.marqueeProgressBarControl1.Size = New System.Drawing.Size(539, 15)
        Me.marqueeProgressBarControl1.TabIndex = 10
        '
        'PictureEdit1
        '
        Me.PictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(16, 15)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.AllowFocused = False
        Me.PictureEdit1.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.[False]
        Me.PictureEdit1.Properties.AllowScrollViaMouseDrag = False
        Me.PictureEdit1.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.[False]
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(568, 222)
        Me.PictureEdit1.TabIndex = 15
        '
        'lblCopyright
        '
        Me.lblCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lblCopyright.Location = New System.Drawing.Point(31, 346)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(4)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(257, 16)
        Me.lblCopyright.TabIndex = 16
        Me.lblCopyright.Text = "Copyright Spectral Technologies Inc. © 2016"
        '
        'MPS4Splash_Crew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 394)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.labelControl2)
        Me.Controls.Add(Me.marqueeProgressBarControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MPS4Splash_Crew"
        Me.Text = "Form1"
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents marqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Private WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Private WithEvents lblCopyright As DevExpress.XtraEditors.LabelControl
End Class
