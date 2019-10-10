<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplashScreen))
        Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCopyright = New DevExpress.XtraEditors.LabelControl()
        Me.marqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.lblAppName = New DevExpress.XtraEditors.LabelControl()
        Me.lblVersion = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEditBG = New DevExpress.XtraEditors.PictureEdit()
        Me.Timer1 = New System.Windows.Forms.Timer()
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEditBG.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelControl2
        '
        Me.labelControl2.Location = New System.Drawing.Point(23, 206)
        Me.labelControl2.Name = "labelControl2"
        Me.labelControl2.Size = New System.Drawing.Size(50, 13)
        Me.labelControl2.TabIndex = 12
        Me.labelControl2.Text = "Starting..."
        '
        'lblCopyright
        '
        Me.lblCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lblCopyright.Location = New System.Drawing.Point(23, 286)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(216, 13)
        Me.lblCopyright.TabIndex = 11
        Me.lblCopyright.Text = "Copyright Spectral Technologies Inc. © 2016"
        '
        'marqueeProgressBarControl1
        '
        Me.marqueeProgressBarControl1.EditValue = 0
        Me.marqueeProgressBarControl1.Location = New System.Drawing.Point(23, 231)
        Me.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1"
        Me.marqueeProgressBarControl1.Size = New System.Drawing.Size(404, 12)
        Me.marqueeProgressBarControl1.TabIndex = 10
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013"
        '
        'lblAppName
        '
        Me.lblAppName.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!)
        Me.lblAppName.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblAppName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblAppName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblAppName.Location = New System.Drawing.Point(12, 126)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(426, 24)
        Me.lblAppName.TabIndex = 15
        Me.lblAppName.Text = "AppName"
        '
        'lblVersion
        '
        Me.lblVersion.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lblVersion.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblVersion.Location = New System.Drawing.Point(12, 156)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(426, 15)
        Me.lblVersion.TabIndex = 16
        Me.lblVersion.Text = "Ver"
        '
        'PictureEditBG
        '
        Me.PictureEditBG.EditValue = Global.zServiceUI.My.Resources.Resources.dotDE_Splash_Screen4
        Me.PictureEditBG.Location = New System.Drawing.Point(-1, -1)
        Me.PictureEditBG.Name = "PictureEditBG"
        Me.PictureEditBG.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.PictureEditBG.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditBG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditBG.Properties.ShowMenu = False
        Me.PictureEditBG.Size = New System.Drawing.Size(452, 201)
        Me.PictureEditBG.TabIndex = 18
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'frmSplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 320)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblAppName)
        Me.Controls.Add(Me.labelControl2)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.marqueeProgressBarControl1)
        Me.Controls.Add(Me.PictureEditBG)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSplashScreen"
        Me.Text = "Form1"
        CType(Me.marqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEditBG.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents labelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents lblCopyright As DevExpress.XtraEditors.LabelControl
    Private WithEvents marqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents lblAppName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEditBG As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
