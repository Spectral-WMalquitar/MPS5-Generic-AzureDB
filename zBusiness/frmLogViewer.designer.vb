<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogViewer))
        Me.txtLogText = New DevExpress.XtraEditors.MemoEdit()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtLogText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtLogText
        '
        Me.txtLogText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLogText.EditValue = "ABCDEFG12345'67890'"
        Me.txtLogText.Location = New System.Drawing.Point(12, 12)
        Me.txtLogText.Name = "txtLogText"
        Me.txtLogText.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.txtLogText.Properties.Appearance.Options.UseFont = True
        Me.txtLogText.Properties.ReadOnly = True
        Me.txtLogText.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogText.Properties.WordWrap = False
        Me.txtLogText.Size = New System.Drawing.Size(859, 447)
        Me.txtLogText.TabIndex = 1
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(796, 465)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        '
        'frmLogViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(883, 500)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtLogText)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(833, 538)
        Me.Name = "frmLogViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View log"
        Me.TopMost = True
        CType(Me.txtLogText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtLogText As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
End Class
