<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayrollFilter
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboPeriod = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboPrincipal = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboVessel = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.cboRefNum = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrincipal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRefNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Controls.Add(Me.cboPeriod)
        Me.LayoutControl1.Controls.Add(Me.cboPrincipal)
        Me.LayoutControl1.Controls.Add(Me.cboVessel)
        Me.LayoutControl1.Controls.Add(Me.cboRefNum)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(533, 182)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboPeriod
        '
        Me.cboPeriod.Location = New System.Drawing.Point(128, 40)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboPeriod.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Period", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodDesc", "PeriodDesc")})
        Me.cboPeriod.Properties.DisplayMember = "PeriodDesc"
        Me.cboPeriod.Properties.DropDownRows = 10
        Me.cboPeriod.Properties.NullText = ""
        Me.cboPeriod.Properties.ShowFooter = False
        Me.cboPeriod.Properties.ShowHeader = False
        Me.cboPeriod.Properties.ValueMember = "Period"
        Me.cboPeriod.Size = New System.Drawing.Size(388, 22)
        Me.cboPeriod.StyleController = Me.LayoutControl1
        Me.cboPeriod.TabIndex = 4
        '
        'cboPrincipal
        '
        Me.cboPrincipal.Location = New System.Drawing.Point(128, 66)
        Me.cboPrincipal.Name = "cboPrincipal"
        Me.cboPrincipal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboPrincipal.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboPrincipal.Properties.DisplayMember = "Name"
        Me.cboPrincipal.Properties.DropDownRows = 10
        Me.cboPrincipal.Properties.NullText = ""
        Me.cboPrincipal.Properties.ShowFooter = False
        Me.cboPrincipal.Properties.ShowHeader = False
        Me.cboPrincipal.Properties.ValueMember = "PKey"
        Me.cboPrincipal.Size = New System.Drawing.Size(388, 22)
        Me.cboPrincipal.StyleController = Me.LayoutControl1
        Me.cboPrincipal.TabIndex = 4
        '
        'cboVessel
        '
        Me.cboVessel.EditValue = ""
        Me.cboVessel.Location = New System.Drawing.Point(128, 92)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Properties.AllowMultiSelect = True
        Me.cboVessel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboVessel.Properties.DisplayMember = "Name"
        Me.cboVessel.Properties.DropDownRows = 10
        Me.cboVessel.Properties.PopupSizeable = False
        Me.cboVessel.Properties.ShowButtons = False
        Me.cboVessel.Properties.ShowPopupCloseButton = False
        Me.cboVessel.Properties.ValueMember = "PKey"
        Me.cboVessel.Size = New System.Drawing.Size(388, 22)
        Me.cboVessel.StyleController = Me.LayoutControl1
        Me.cboVessel.TabIndex = 4
        '
        'cboRefNum
        '
        Me.cboRefNum.Location = New System.Drawing.Point(128, 118)
        Me.cboRefNum.Name = "cboRefNum"
        Me.cboRefNum.Properties.AllowMultiSelect = True
        Me.cboRefNum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboRefNum.Properties.DisplayMember = "VslRef"
        Me.cboRefNum.Properties.DropDownRows = 10
        Me.cboRefNum.Properties.PopupSizeable = False
        Me.cboRefNum.Properties.ShowButtons = False
        Me.cboRefNum.Properties.ShowPopupCloseButton = False
        Me.cboRefNum.Properties.ValueMember = "PKey"
        Me.cboRefNum.Size = New System.Drawing.Size(388, 22)
        Me.cboRefNum.StyleController = Me.LayoutControl1
        Me.cboRefNum.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(533, 182)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(533, 182)
        Me.LayoutControlGroup2.Text = "Payroll Filter"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboPeriod
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(503, 26)
        Me.LayoutControlItem1.Text = "Period"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(107, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboPrincipal
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(503, 26)
        Me.LayoutControlItem2.Text = "Principal"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(107, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboVessel
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(503, 26)
        Me.LayoutControlItem3.Text = "Vessel"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(107, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboRefNum
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(503, 52)
        Me.LayoutControlItem4.Text = "Reference Number"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(107, 16)
        '
        'PayrollFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "PayrollFilter"
        Me.Size = New System.Drawing.Size(533, 182)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrincipal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRefNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboPeriod As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboPrincipal As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboVessel As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents cboRefNum As DevExpress.XtraEditors.CheckedComboBoxEdit

End Class
