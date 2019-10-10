<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManPowerFilter
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
        Me.chkYearStart = New DevExpress.XtraEditors.CheckEdit()
        Me.cboAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboFleet = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboPeriod = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtNote = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkYearStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFleet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkYearStart)
        Me.LayoutControl1.Controls.Add(Me.cboAgent)
        Me.LayoutControl1.Controls.Add(Me.cboFleet)
        Me.LayoutControl1.Controls.Add(Me.cboPeriod)
        Me.LayoutControl1.Controls.Add(Me.txtNote)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(417, 47, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(375, 258)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkYearStart
        '
        Me.chkYearStart.Location = New System.Drawing.Point(251, 108)
        Me.chkYearStart.Name = "chkYearStart"
        Me.chkYearStart.Properties.Caption = "Year Start (Period)"
        Me.chkYearStart.Size = New System.Drawing.Size(112, 19)
        Me.chkYearStart.StyleController = Me.LayoutControl1
        Me.chkYearStart.TabIndex = 5
        '
        'cboAgent
        '
        Me.cboAgent.Location = New System.Drawing.Point(12, 28)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAgent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboAgent.Properties.DisplayMember = "Name"
        Me.cboAgent.Properties.DropDownRows = 10
        Me.cboAgent.Properties.NullText = ""
        Me.cboAgent.Properties.ShowFooter = False
        Me.cboAgent.Properties.ShowHeader = False
        Me.cboAgent.Properties.ValueMember = "PKey"
        Me.cboAgent.Size = New System.Drawing.Size(351, 20)
        Me.cboAgent.StyleController = Me.LayoutControl1
        Me.cboAgent.TabIndex = 4
        '
        'cboFleet
        '
        Me.cboFleet.Location = New System.Drawing.Point(12, 68)
        Me.cboFleet.Name = "cboFleet"
        Me.cboFleet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFleet.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFleet.Properties.DisplayMember = "Name"
        Me.cboFleet.Properties.DropDownRows = 10
        Me.cboFleet.Properties.NullText = ""
        Me.cboFleet.Properties.ShowFooter = False
        Me.cboFleet.Properties.ShowHeader = False
        Me.cboFleet.Properties.ValueMember = "PKey"
        Me.cboFleet.Size = New System.Drawing.Size(351, 20)
        Me.cboFleet.StyleController = Me.LayoutControl1
        Me.cboFleet.TabIndex = 4
        '
        'cboPeriod
        '
        Me.cboPeriod.Location = New System.Drawing.Point(12, 108)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPeriod.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodDesc", "Period")})
        Me.cboPeriod.Properties.DisplayMember = "PeriodDesc"
        Me.cboPeriod.Properties.DropDownRows = 10
        Me.cboPeriod.Properties.NullText = ""
        Me.cboPeriod.Properties.ShowFooter = False
        Me.cboPeriod.Properties.ShowHeader = False
        Me.cboPeriod.Properties.ValueMember = "Period"
        Me.cboPeriod.Size = New System.Drawing.Size(235, 20)
        Me.cboPeriod.StyleController = Me.LayoutControl1
        Me.cboPeriod.TabIndex = 4
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(12, 148)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(351, 98)
        Me.txtNote.StyleController = Me.LayoutControl1
        Me.txtNote.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(375, 258)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cboAgent
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(355, 40)
        Me.LayoutControlItem1.Text = "Agent"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboFleet
        Me.LayoutControlItem2.CustomizationFormText = "Agent"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(355, 40)
        Me.LayoutControlItem2.Text = "Fleet"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboPeriod
        Me.LayoutControlItem3.CustomizationFormText = "Agent"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 80)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(239, 40)
        Me.LayoutControlItem3.Text = "Period"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtNote
        Me.LayoutControlItem4.CustomizationFormText = "Agent"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(355, 118)
        Me.LayoutControlItem4.Text = "Note"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.chkYearStart
        Me.LayoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.LayoutControlItem5.Location = New System.Drawing.Point(239, 80)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(116, 40)
        Me.LayoutControlItem5.Text = " "
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(30, 13)
        '
        'ManPowerFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "ManPowerFilter"
        Me.Size = New System.Drawing.Size(375, 258)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkYearStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFleet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboFleet As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboPeriod As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents chkYearStart As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem

End Class
