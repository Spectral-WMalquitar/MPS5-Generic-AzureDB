<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaySASummaryCrewPS
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.CboCrew = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboVsl = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboPeriodTo = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboPeriodFrom = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.CboCrew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVsl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.CboCrew)
        Me.GroupControl1.Controls.Add(Me.cboVsl)
        Me.GroupControl1.Controls.Add(Me.cboPeriodTo)
        Me.GroupControl1.Controls.Add(Me.cboPeriodFrom)
        Me.GroupControl1.Controls.Add(Me.btnCancel)
        Me.GroupControl1.Controls.Add(Me.btnOK)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(303, 173)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Print Selection"
        '
        'CboCrew
        '
        Me.CboCrew.Cursor = System.Windows.Forms.Cursors.Default
        Me.CboCrew.Location = New System.Drawing.Point(95, 88)
        Me.CboCrew.Name = "CboCrew"
        Me.CboCrew.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.CboCrew.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FKeyIDNbr", "FKeyIDNbr", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CrewName", "CrewName")})
        Me.CboCrew.Properties.DisplayMember = "CrewName"
        Me.CboCrew.Properties.DropDownRows = 10
        Me.CboCrew.Properties.NullText = ""
        Me.CboCrew.Properties.ShowFooter = False
        Me.CboCrew.Properties.ShowHeader = False
        Me.CboCrew.Properties.ValueMember = "FKeyIDNbr"
        Me.CboCrew.Size = New System.Drawing.Size(193, 20)
        Me.CboCrew.TabIndex = 11
        '
        'cboVsl
        '
        Me.cboVsl.Location = New System.Drawing.Point(79, 153)
        Me.cboVsl.Name = "cboVsl"
        Me.cboVsl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboVsl.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboVsl.Properties.DisplayMember = "Name"
        Me.cboVsl.Properties.DropDownRows = 10
        Me.cboVsl.Properties.NullText = ""
        Me.cboVsl.Properties.ShowFooter = False
        Me.cboVsl.Properties.ShowHeader = False
        Me.cboVsl.Properties.ValueMember = "PKey"
        Me.cboVsl.Size = New System.Drawing.Size(193, 20)
        Me.cboVsl.TabIndex = 10
        Me.cboVsl.Visible = False
        '
        'cboPeriodTo
        '
        Me.cboPeriodTo.Location = New System.Drawing.Point(95, 62)
        Me.cboPeriodTo.Name = "cboPeriodTo"
        Me.cboPeriodTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboPeriodTo.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodDesc", "Period"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Period", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboPeriodTo.Properties.DisplayMember = "PeriodDesc"
        Me.cboPeriodTo.Properties.DropDownRows = 10
        Me.cboPeriodTo.Properties.NullText = ""
        Me.cboPeriodTo.Properties.ShowFooter = False
        Me.cboPeriodTo.Properties.ShowHeader = False
        Me.cboPeriodTo.Properties.ValueMember = "Period"
        Me.cboPeriodTo.Size = New System.Drawing.Size(193, 20)
        Me.cboPeriodTo.TabIndex = 9
        '
        'cboPeriodFrom
        '
        Me.cboPeriodFrom.Location = New System.Drawing.Point(95, 34)
        Me.cboPeriodFrom.Name = "cboPeriodFrom"
        Me.cboPeriodFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboPeriodFrom.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodDesc", "Period"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Period", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboPeriodFrom.Properties.DisplayMember = "PeriodDesc"
        Me.cboPeriodFrom.Properties.DropDownRows = 10
        Me.cboPeriodFrom.Properties.NullText = ""
        Me.cboPeriodFrom.Properties.ShowFooter = False
        Me.cboPeriodFrom.Properties.ShowHeader = False
        Me.cboPeriodFrom.Properties.ValueMember = "Period"
        Me.cboPeriodFrom.Size = New System.Drawing.Size(193, 20)
        Me.cboPeriodFrom.TabIndex = 8
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(152, 128)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(70, 128)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(24, 91)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Crew:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(24, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Period To:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 37)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Period From:"
        '
        'frmPaySASummaryCrewPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 173)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaySASummaryCrewPS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Print Selection"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.CboCrew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVsl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboPeriodFrom As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboPeriodTo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboVsl As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents CboCrew As DevExpress.XtraEditors.LookUpEdit
End Class
