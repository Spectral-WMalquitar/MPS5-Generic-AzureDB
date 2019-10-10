<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgressBar
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
        Me.lblStatus = New DevExpress.XtraEditors.LabelControl()
        Me.progressBar_Main = New DevExpress.XtraEditors.ProgressBarControl()
        CType(Me.progressBar_Main.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lblStatus.Location = New System.Drawing.Point(28, 14)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(539, 18)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Status"
        '
        'progressBar_Main
        '
        Me.progressBar_Main.Location = New System.Drawing.Point(28, 50)
        Me.progressBar_Main.Name = "progressBar_Main"
        Me.progressBar_Main.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.progressBar_Main.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.progressBar_Main.Properties.ReadOnly = True
        Me.progressBar_Main.Properties.ShowTitle = True
        Me.progressBar_Main.Properties.StartColor = System.Drawing.Color.PaleGreen
        Me.progressBar_Main.Properties.Step = 1
        Me.progressBar_Main.ShowProgressInTaskBar = True
        Me.progressBar_Main.Size = New System.Drawing.Size(539, 18)
        Me.progressBar_Main.TabIndex = 3
        '
        'frmProgressBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 87)
        Me.ControlBox = False
        Me.Controls.Add(Me.progressBar_Main)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmProgressBar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Progress"
        Me.TopMost = True
        CType(Me.progressBar_Main.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents progressBar_Main As DevExpress.XtraEditors.ProgressBarControl
End Class
