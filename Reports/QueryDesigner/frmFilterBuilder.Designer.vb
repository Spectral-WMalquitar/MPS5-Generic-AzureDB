<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFilterBuilder
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
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me._cmbOperator = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me._txtValue = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdClear = New DevExpress.XtraEditors.SimpleButton()
        Me._splContainerData = New System.Windows.Forms.SplitContainer()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblPreviewCriteria = New DevExpress.XtraEditors.LabelControl()
        Me.txtCloseP = New DevExpress.XtraEditors.LabelControl()
        Me.txtOpenP = New DevExpress.XtraEditors.LabelControl()
        Me._valueformated = New DevExpress.XtraEditors.LabelControl()
        Me.cmdAddCP = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdRevCP = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdRevOP = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAddOP = New DevExpress.XtraEditors.SimpleButton()
        Me._value = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me._txtTo = New DevExpress.XtraEditors.TextEdit()
        Me._txtFrom = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me._cmbOperator.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._splContainerData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._splContainerData.Panel1.SuspendLayout()
        Me._splContainerData.Panel2.SuspendLayout()
        Me._splContainerData.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me._txtTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(361, 14)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        '
        '_cmbOperator
        '
        Me._cmbOperator.Location = New System.Drawing.Point(16, 30)
        Me._cmbOperator.Name = "_cmbOperator"
        Me._cmbOperator.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._cmbOperator.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CritOperator", "CritOperator", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CritOperatorDesc", 10, "CritOperatorDesc")})
        Me._cmbOperator.Properties.DisplayMember = "CritOperatorDesc"
        Me._cmbOperator.Properties.DropDownRows = 10
        Me._cmbOperator.Properties.NullText = ""
        Me._cmbOperator.Properties.ShowFooter = False
        Me._cmbOperator.Properties.ShowHeader = False
        Me._cmbOperator.Properties.ValueMember = "CritOperator"
        Me._cmbOperator.Size = New System.Drawing.Size(153, 20)
        Me._cmbOperator.TabIndex = 10
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(223, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl2.TabIndex = 15
        Me.LabelControl2.Text = "and"
        '
        '_txtValue
        '
        Me._txtValue.Location = New System.Drawing.Point(175, 30)
        Me._txtValue.Name = "_txtValue"
        Me._txtValue.Properties.MaxLength = 60
        Me._txtValue.Size = New System.Drawing.Size(220, 20)
        Me._txtValue.TabIndex = 11
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(36, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "BETWEEN"
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(280, 14)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 12
        Me.cmdOk.Text = "Ok"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(21, 14)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "Clear"
        '
        '_splContainerData
        '
        Me._splContainerData.Dock = System.Windows.Forms.DockStyle.Fill
        Me._splContainerData.Location = New System.Drawing.Point(0, 0)
        Me._splContainerData.Name = "_splContainerData"
        Me._splContainerData.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        '_splContainerData.Panel1
        '
        Me._splContainerData.Panel1.Controls.Add(Me.GroupBox3)
        Me._splContainerData.Panel1.Controls.Add(Me.GroupBox2)
        Me._splContainerData.Panel1.Controls.Add(Me.GroupBox1)
        '
        '_splContainerData.Panel2
        '
        Me._splContainerData.Panel2.Controls.Add(Me.cmdOk)
        Me._splContainerData.Panel2.Controls.Add(Me.cmdClear)
        Me._splContainerData.Panel2.Controls.Add(Me.cmdCancel)
        Me._splContainerData.Size = New System.Drawing.Size(454, 387)
        Me._splContainerData.SplitterDistance = 332
        Me._splContainerData.TabIndex = 17
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblPreviewCriteria)
        Me.GroupBox3.Controls.Add(Me.txtCloseP)
        Me.GroupBox3.Controls.Add(Me.txtOpenP)
        Me.GroupBox3.Controls.Add(Me._valueformated)
        Me.GroupBox3.Controls.Add(Me.cmdAddCP)
        Me.GroupBox3.Controls.Add(Me.cmdRevCP)
        Me.GroupBox3.Controls.Add(Me.cmdRevOP)
        Me.GroupBox3.Controls.Add(Me.cmdAddOP)
        Me.GroupBox3.Controls.Add(Me._value)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(21, 181)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(415, 132)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Output"
        '
        'lblPreviewCriteria
        '
        Me.lblPreviewCriteria.Location = New System.Drawing.Point(16, 96)
        Me.lblPreviewCriteria.Name = "lblPreviewCriteria"
        Me.lblPreviewCriteria.Size = New System.Drawing.Size(102, 13)
        Me.lblPreviewCriteria.TabIndex = 27
        Me.lblPreviewCriteria.Text = "CRITFORMATEDFULL"
        '
        'txtCloseP
        '
        Me.txtCloseP.Location = New System.Drawing.Point(232, 25)
        Me.txtCloseP.Name = "txtCloseP"
        Me.txtCloseP.Size = New System.Drawing.Size(32, 13)
        Me.txtCloseP.TabIndex = 26
        Me.txtCloseP.Tag = ""
        Me.txtCloseP.Text = "CloseP"
        Me.txtCloseP.Visible = False
        '
        'txtOpenP
        '
        Me.txtOpenP.Location = New System.Drawing.Point(186, 25)
        Me.txtOpenP.Name = "txtOpenP"
        Me.txtOpenP.Size = New System.Drawing.Size(32, 13)
        Me.txtOpenP.TabIndex = 25
        Me.txtOpenP.Tag = ""
        Me.txtOpenP.Text = "OpenP"
        Me.txtOpenP.Visible = False
        '
        '_valueformated
        '
        Me._valueformated.Location = New System.Drawing.Point(16, 77)
        Me._valueformated.Name = "_valueformated"
        Me._valueformated.Size = New System.Drawing.Size(79, 13)
        Me._valueformated.TabIndex = 24
        Me._valueformated.Text = "CRITFORMATED"
        Me._valueformated.Visible = False
        '
        'cmdAddCP
        '
        Me.cmdAddCP.Location = New System.Drawing.Point(144, 20)
        Me.cmdAddCP.Name = "cmdAddCP"
        Me.cmdAddCP.Size = New System.Drawing.Size(36, 23)
        Me.cmdAddCP.TabIndex = 22
        Me.cmdAddCP.Text = "+ )"
        Me.cmdAddCP.ToolTip = "Add Close Parenthesis"
        '
        'cmdRevCP
        '
        Me.cmdRevCP.Location = New System.Drawing.Point(102, 20)
        Me.cmdRevCP.Name = "cmdRevCP"
        Me.cmdRevCP.Size = New System.Drawing.Size(36, 23)
        Me.cmdRevCP.TabIndex = 21
        Me.cmdRevCP.Text = "- )"
        Me.cmdRevCP.ToolTip = "Remove Close Parenthesis"
        '
        'cmdRevOP
        '
        Me.cmdRevOP.Location = New System.Drawing.Point(58, 20)
        Me.cmdRevOP.Name = "cmdRevOP"
        Me.cmdRevOP.Size = New System.Drawing.Size(36, 23)
        Me.cmdRevOP.TabIndex = 20
        Me.cmdRevOP.Text = "( -"
        Me.cmdRevOP.ToolTip = "Remove Open Parenthesis"
        '
        'cmdAddOP
        '
        Me.cmdAddOP.Location = New System.Drawing.Point(16, 20)
        Me.cmdAddOP.Name = "cmdAddOP"
        Me.cmdAddOP.Size = New System.Drawing.Size(36, 23)
        Me.cmdAddOP.TabIndex = 19
        Me.cmdAddOP.Text = "( +"
        Me.cmdAddOP.ToolTip = "Add Open Parenthesis"
        '
        '_value
        '
        Me._value.Location = New System.Drawing.Point(16, 58)
        Me._value.Name = "_value"
        Me._value.Size = New System.Drawing.Size(31, 13)
        Me._value.TabIndex = 17
        Me._value.Text = "VALUE"
        Me._value.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me._txtTo)
        Me.GroupBox2.Controls.Add(Me._txtFrom)
        Me.GroupBox2.Controls.Add(Me.LabelControl1)
        Me.GroupBox2.Controls.Add(Me.LabelControl2)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(21, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(415, 70)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Interval Criteria"
        '
        '_txtTo
        '
        Me._txtTo.Location = New System.Drawing.Point(262, 30)
        Me._txtTo.Name = "_txtTo"
        Me._txtTo.Size = New System.Drawing.Size(107, 20)
        Me._txtTo.TabIndex = 16
        '
        '_txtFrom
        '
        Me._txtFrom.Location = New System.Drawing.Point(102, 30)
        Me._txtFrom.Name = "_txtFrom"
        Me._txtFrom.Size = New System.Drawing.Size(107, 20)
        Me._txtFrom.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me._txtValue)
        Me.GroupBox1.Controls.Add(Me._cmbOperator)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 71)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Single Value Criteria"
        '
        'frmFilterBuilder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 387)
        Me.Controls.Add(Me._splContainerData)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFilterBuilder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criteria Builder"
        CType(Me._cmbOperator.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me._splContainerData.Panel1.ResumeLayout(False)
        Me._splContainerData.Panel2.ResumeLayout(False)
        CType(Me._splContainerData, System.ComponentModel.ISupportInitialize).EndInit()
        Me._splContainerData.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me._txtTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents _cmbOperator As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents _txtValue As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents _splContainerData As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents _txtFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _value As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAddOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdRevOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdAddCP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdRevCP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents _valueformated As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCloseP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOpenP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPreviewCriteria As DevExpress.XtraEditors.LabelControl
End Class
