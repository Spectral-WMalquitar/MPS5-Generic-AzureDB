<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayrollFilterOption
    Inherits Reports.BaseFilterOption

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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.RefNo = New DevExpress.XtraEditors.LookUpEdit()
        Me.Vessel = New DevExpress.XtraEditors.LookUpEdit()
        Me.Principal = New DevExpress.XtraEditors.LookUpEdit()
        Me.Period = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.RefNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Vessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Principal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Period.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.RefNo)
        Me.LayoutControl1.Controls.Add(Me.Vessel)
        Me.LayoutControl1.Controls.Add(Me.Principal)
        Me.LayoutControl1.Controls.Add(Me.Period)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(354, 192)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'RefNo
        '
        Me.RefNo.Location = New System.Drawing.Point(54, 84)
        Me.RefNo.Name = "RefNo"
        Me.RefNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.RefNo.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RefNo.Properties.DisplayMember = "Name"
        Me.RefNo.Properties.NullText = ""
        Me.RefNo.Properties.ShowFooter = False
        Me.RefNo.Properties.ShowHeader = False
        Me.RefNo.Properties.ValueMember = "PKey"
        Me.RefNo.Size = New System.Drawing.Size(288, 20)
        Me.RefNo.StyleController = Me.LayoutControl1
        Me.RefNo.TabIndex = 7
        '
        'Vessel
        '
        Me.Vessel.Location = New System.Drawing.Point(54, 60)
        Me.Vessel.Name = "Vessel"
        Me.Vessel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.Vessel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.Vessel.Properties.DisplayMember = "Name"
        Me.Vessel.Properties.NullText = ""
        Me.Vessel.Properties.ShowFooter = False
        Me.Vessel.Properties.ShowHeader = False
        Me.Vessel.Properties.ValueMember = "PKey"
        Me.Vessel.Size = New System.Drawing.Size(288, 20)
        Me.Vessel.StyleController = Me.LayoutControl1
        Me.Vessel.TabIndex = 6
        '
        'Principal
        '
        Me.Principal.Location = New System.Drawing.Point(54, 36)
        Me.Principal.Name = "Principal"
        Me.Principal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.Principal.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.Principal.Properties.DisplayMember = "Name"
        Me.Principal.Properties.NullText = ""
        Me.Principal.Properties.ShowFooter = False
        Me.Principal.Properties.ShowHeader = False
        Me.Principal.Properties.ValueMember = "PKey"
        Me.Principal.Size = New System.Drawing.Size(288, 20)
        Me.Principal.StyleController = Me.LayoutControl1
        Me.Principal.TabIndex = 5
        '
        'Period
        '
        Me.Period.Location = New System.Drawing.Point(54, 12)
        Me.Period.Name = "Period"
        Me.Period.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.Period.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MCode", "MCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Period")})
        Me.Period.Properties.DisplayMember = "Period"
        Me.Period.Properties.NullText = ""
        Me.Period.Properties.ShowFooter = False
        Me.Period.Properties.ShowHeader = False
        Me.Period.Properties.ValueMember = "MCode"
        Me.Period.Size = New System.Drawing.Size(288, 20)
        Me.Period.StyleController = Me.LayoutControl1
        Me.Period.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(354, 192)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Period
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(334, 24)
        Me.LayoutControlItem1.Text = "Period"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(39, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Principal
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(334, 24)
        Me.LayoutControlItem2.Text = "Principal"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(39, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.Vessel
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(334, 24)
        Me.LayoutControlItem3.Text = "Vessel"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(39, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.RefNo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(334, 100)
        Me.LayoutControlItem4.Text = "RefNo"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(39, 13)
        '
        'PayrollFilterOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "PayrollFilterOption"
        Me.Size = New System.Drawing.Size(354, 192)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.RefNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Vessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Principal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Period.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents RefNo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Principal As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Period As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Vessel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem

End Class
