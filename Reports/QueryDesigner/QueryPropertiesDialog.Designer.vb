<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueryPropertiesDialog
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
        Me._btnCancel = New System.Windows.Forms.Button
        Me._btnOK = New System.Windows.Forms.Button
        Me._chkDistinct = New System.Windows.Forms.CheckBox
        Me._cmbGroupBy = New System.Windows.Forms.ComboBox
        Me._numTopN = New System.Windows.Forms.NumericUpDown
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        CType(Me._numTopN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_btnCancel
        '
        Me._btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me._btnCancel.Location = New System.Drawing.Point(183, 106)
        Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
        Me._btnCancel.Name = "_btnCancel"
        Me._btnCancel.Size = New System.Drawing.Size(70, 22)
        Me._btnCancel.TabIndex = 13
        Me._btnCancel.Text = "Cancel"
        Me._btnCancel.UseVisualStyleBackColor = True
        '
        '_btnOK
        '
        Me._btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me._btnOK.Location = New System.Drawing.Point(108, 106)
        Me._btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me._btnOK.Name = "_btnOK"
        Me._btnOK.Size = New System.Drawing.Size(70, 22)
        Me._btnOK.TabIndex = 12
        Me._btnOK.Text = "OK"
        Me._btnOK.UseVisualStyleBackColor = True
        '
        '_chkDistinct
        '
        Me._chkDistinct.AutoSize = True
        Me._chkDistinct.Location = New System.Drawing.Point(11, 11)
        Me._chkDistinct.Margin = New System.Windows.Forms.Padding(2)
        Me._chkDistinct.Name = "_chkDistinct"
        Me._chkDistinct.Size = New System.Drawing.Size(96, 17)
        Me._chkDistinct.TabIndex = 7
        Me._chkDistinct.Text = "&Distinct Values"
        Me._chkDistinct.UseVisualStyleBackColor = True
        '
        '_cmbGroupBy
        '
        Me._cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._cmbGroupBy.FormattingEnabled = True
        Me._cmbGroupBy.Items.AddRange(New Object() {"None", "Cube", "Rollup", "All"})
        Me._cmbGroupBy.Location = New System.Drawing.Point(81, 67)
        Me._cmbGroupBy.Margin = New System.Windows.Forms.Padding(2)
        Me._cmbGroupBy.Name = "_cmbGroupBy"
        Me._cmbGroupBy.Size = New System.Drawing.Size(118, 21)
        Me._cmbGroupBy.TabIndex = 11
        '
        '_numTopN
        '
        Me._numTopN.Location = New System.Drawing.Point(81, 40)
        Me._numTopN.Margin = New System.Windows.Forms.Padding(2)
        Me._numTopN.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me._numTopN.Name = "_numTopN"
        Me._numTopN.Size = New System.Drawing.Size(117, 20)
        Me._numTopN.TabIndex = 9
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(11, 69)
        Me.label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(54, 13)
        Me.label2.TabIndex = 10
        Me.label2.Text = "&Group By:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(11, 42)
        Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(40, 13)
        Me.label1.TabIndex = 8
        Me.label1.Text = "&Top N:"
        '
        'QueryPropertiesDialog
        '
        Me.AcceptButton = Me._btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me._btnCancel
        Me.ClientSize = New System.Drawing.Size(264, 139)
        Me.Controls.Add(Me._btnCancel)
        Me.Controls.Add(Me._btnOK)
        Me.Controls.Add(Me._chkDistinct)
        Me.Controls.Add(Me._cmbGroupBy)
        Me.Controls.Add(Me._numTopN)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "QueryPropertiesDialog"
        Me.Text = "Query Properties"
        CType(Me._numTopN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents _btnCancel As System.Windows.Forms.Button
    Private WithEvents _btnOK As System.Windows.Forms.Button
    Private WithEvents _chkDistinct As System.Windows.Forms.CheckBox
    Private WithEvents _cmbGroupBy As System.Windows.Forms.ComboBox
    Private WithEvents _numTopN As System.Windows.Forms.NumericUpDown
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
