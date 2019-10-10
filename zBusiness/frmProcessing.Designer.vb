<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessing))
        Me.grpStatus = New DevExpress.XtraEditors.GroupControl()
        Me.lblCompleted = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCurr = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MarqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        CType(Me.grpStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStatus.SuspendLayout()
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.lblCompleted)
        Me.grpStatus.Controls.Add(Me.LabelControl4)
        Me.grpStatus.Controls.Add(Me.lblCurr)
        Me.grpStatus.Controls.Add(Me.LabelControl1)
        Me.grpStatus.Controls.Add(Me.MarqueeProgressBarControl1)
        Me.grpStatus.Location = New System.Drawing.Point(27, 28)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(460, 170)
        Me.grpStatus.TabIndex = 20
        Me.grpStatus.Text = "Status"
        '
        'lblCompleted
        '
        Me.lblCompleted.Location = New System.Drawing.Point(130, 44)
        Me.lblCompleted.Name = "lblCompleted"
        Me.lblCompleted.Size = New System.Drawing.Size(12, 13)
        Me.lblCompleted.TabIndex = 21
        Me.lblCompleted.Text = "---"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(36, 44)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl4.TabIndex = 20
        Me.LabelControl4.Text = "Completed:"
        '
        'lblCurr
        '
        Me.lblCurr.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblCurr.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblCurr.Location = New System.Drawing.Point(130, 63)
        Me.lblCurr.Name = "lblCurr"
        Me.lblCurr.Size = New System.Drawing.Size(290, 13)
        Me.lblCurr.TabIndex = 19
        Me.lblCurr.Text = "Starting process..."
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(36, 63)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 18
        Me.LabelControl1.Text = "Current Task:"
        '
        'MarqueeProgressBarControl1
        '
        Me.MarqueeProgressBarControl1.EditValue = 0
        Me.MarqueeProgressBarControl1.Location = New System.Drawing.Point(36, 120)
        Me.MarqueeProgressBarControl1.Name = "MarqueeProgressBarControl1"
        Me.MarqueeProgressBarControl1.Size = New System.Drawing.Size(384, 18)
        Me.MarqueeProgressBarControl1.TabIndex = 17
        '
        'frmProcessing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 228)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProcessing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Processing Request"
        Me.TopMost = True
        CType(Me.grpStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpStatus As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblCompleted As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCurr As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MarqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
End Class
