<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoadTemplate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoadTemplate))
        Me.lblLoadTemplate = New System.Windows.Forms.Label()
        Me.chkViewAfterLoad = New DevExpress.XtraEditors.CheckEdit()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.chkViewAfterLoad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLoadTemplate
        '
        Me.lblLoadTemplate.AutoSize = True
        Me.lblLoadTemplate.Location = New System.Drawing.Point(113, 27)
        Me.lblLoadTemplate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoadTemplate.Name = "lblLoadTemplate"
        Me.lblLoadTemplate.Size = New System.Drawing.Size(111, 17)
        Me.lblLoadTemplate.TabIndex = 0
        Me.lblLoadTemplate.Text = "Load Template?"
        '
        'chkViewAfterLoad
        '
        Me.chkViewAfterLoad.Location = New System.Drawing.Point(3, 137)
        Me.chkViewAfterLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkViewAfterLoad.Name = "chkViewAfterLoad"
        Me.chkViewAfterLoad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkViewAfterLoad.Properties.Appearance.Options.UseFont = True
        Me.chkViewAfterLoad.Properties.Caption = "View report after template is loaded"
        Me.chkViewAfterLoad.Size = New System.Drawing.Size(401, 20)
        Me.chkViewAfterLoad.TabIndex = 3
        Me.chkViewAfterLoad.Visible = False
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(16, 16)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Size = New System.Drawing.Size(57, 49)
        Me.PictureEdit1.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(91, 84)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(135, 28)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(225, 84)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(135, 28)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmLoadTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(433, 160)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.chkViewAfterLoad)
        Me.Controls.Add(Me.lblLoadTemplate)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoadTemplate"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MPS 5"
        CType(Me.chkViewAfterLoad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLoadTemplate As System.Windows.Forms.Label
    Friend WithEvents chkViewAfterLoad As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
