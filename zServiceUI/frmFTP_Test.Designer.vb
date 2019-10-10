<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFTP_Test
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.ListBoxControl_FTP = New DevExpress.XtraEditors.ListBoxControl()
        Me.txtLogText = New DevExpress.XtraEditors.MemoEdit()
        Me.lblCaption = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MarqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.lblInProgress = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ListBoxControl_FTP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLogText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(457, 450)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 2
        Me.OK_Button.Text = "Close"
        '
        'ListBoxControl_FTP
        '
        Me.ListBoxControl_FTP.Appearance.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.ListBoxControl_FTP.Appearance.Options.UseFont = True
        Me.ListBoxControl_FTP.Items.AddRange(New Object() {"Fifth", "First", "Fourth", "Second", "Third"})
        Me.ListBoxControl_FTP.Location = New System.Drawing.Point(12, 31)
        Me.ListBoxControl_FTP.Name = "ListBoxControl_FTP"
        Me.ListBoxControl_FTP.Size = New System.Drawing.Size(512, 172)
        Me.ListBoxControl_FTP.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.ListBoxControl_FTP.TabIndex = 0
        '
        'txtLogText
        '
        Me.txtLogText.EditValue = "ABCDEFG12345'67890'"
        Me.txtLogText.Location = New System.Drawing.Point(12, 252)
        Me.txtLogText.Name = "txtLogText"
        Me.txtLogText.Properties.Appearance.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.txtLogText.Properties.Appearance.Options.UseFont = True
        Me.txtLogText.Properties.ReadOnly = True
        Me.txtLogText.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogText.Properties.WordWrap = False
        Me.txtLogText.Size = New System.Drawing.Size(512, 183)
        Me.txtLogText.TabIndex = 1
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(12, 12)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(118, 13)
        Me.lblCaption.TabIndex = 3
        Me.lblCaption.Text = "FTP host directory listing"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 233)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(118, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "FTP host directory listing"
        '
        'MarqueeProgressBarControl1
        '
        Me.MarqueeProgressBarControl1.EditValue = ""
        Me.MarqueeProgressBarControl1.Location = New System.Drawing.Point(353, 209)
        Me.MarqueeProgressBarControl1.Name = "MarqueeProgressBarControl1"
        Me.MarqueeProgressBarControl1.Size = New System.Drawing.Size(171, 18)
        Me.MarqueeProgressBarControl1.TabIndex = 10
        '
        'lblInProgress
        '
        Me.lblInProgress.Location = New System.Drawing.Point(258, 209)
        Me.lblInProgress.Name = "lblInProgress"
        Me.lblInProgress.Size = New System.Drawing.Size(89, 13)
        Me.lblInProgress.TabIndex = 11
        Me.lblInProgress.Text = "Test in progress..."
        '
        'frmFTP_Test
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblInProgress)
        Me.Controls.Add(Me.MarqueeProgressBarControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.txtLogText)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.ListBoxControl_FTP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFTP_Test"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Test FTP Settings"
        CType(Me.ListBoxControl_FTP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLogText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents ListBoxControl_FTP As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents txtLogText As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblCaption As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MarqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents lblInProgress As DevExpress.XtraEditors.LabelControl

End Class
