<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveTemplate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaveTemplate))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cboTemplateName = New DevExpress.XtraEditors.LookUpEdit()
        Me.chkSelectedData = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSort = New DevExpress.XtraEditors.CheckEdit()
        Me.chkFilter = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_ContentSelection = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lblItemSelection = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem_Filtering = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_Sorting = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_SelectedData = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboTemplateName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSelectedData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_ContentSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItemSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Filtering, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Sorting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_SelectedData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cboTemplateName)
        Me.LayoutControl1.Controls.Add(Me.chkSelectedData)
        Me.LayoutControl1.Controls.Add(Me.chkSort)
        Me.LayoutControl1.Controls.Add(Me.chkFilter)
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtDescription)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(886, 201, 303, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(628, 249)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cboTemplateName
        '
        Me.cboTemplateName.Location = New System.Drawing.Point(148, 12)
        Me.cboTemplateName.Name = "cboTemplateName"
        Me.cboTemplateName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboTemplateName.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboTemplateName.Properties.DisplayMember = "Name"
        Me.cboTemplateName.Properties.NullText = "[Type a new template name or select an existing to overwrite.]"
        Me.cboTemplateName.Properties.ShowFooter = False
        Me.cboTemplateName.Properties.ShowHeader = False
        Me.cboTemplateName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboTemplateName.Properties.ValueMember = "PKey"
        Me.cboTemplateName.Size = New System.Drawing.Size(468, 22)
        Me.cboTemplateName.StyleController = Me.LayoutControl1
        Me.cboTemplateName.TabIndex = 15
        '
        'chkSelectedData
        '
        Me.chkSelectedData.Location = New System.Drawing.Point(431, 146)
        Me.chkSelectedData.Name = "chkSelectedData"
        Me.chkSelectedData.Properties.Caption = "Selected Data"
        Me.chkSelectedData.Size = New System.Drawing.Size(182, 20)
        Me.chkSelectedData.StyleController = Me.LayoutControl1
        Me.chkSelectedData.TabIndex = 14
        '
        'chkSort
        '
        Me.chkSort.Location = New System.Drawing.Point(255, 146)
        Me.chkSort.Name = "chkSort"
        Me.chkSort.Properties.Caption = "Sorting"
        Me.chkSort.Size = New System.Drawing.Size(172, 20)
        Me.chkSort.StyleController = Me.LayoutControl1
        Me.chkSort.TabIndex = 13
        '
        'chkFilter
        '
        Me.chkFilter.Location = New System.Drawing.Point(55, 146)
        Me.chkFilter.Name = "chkFilter"
        Me.chkFilter.Properties.Caption = "Filtering"
        Me.chkFilter.Size = New System.Drawing.Size(196, 20)
        Me.chkFilter.StyleController = Me.LayoutControl1
        Me.chkFilter.TabIndex = 12
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(317, 208)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(299, 29)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 208)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(301, 29)
        Me.cmdSave.TabIndex = 10
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(148, 38)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(468, 81)
        Me.txtDescription.StyleController = Me.LayoutControl1
        Me.txtDescription.TabIndex = 5
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem2, Me.LayoutControlGroup_ContentSelection, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(628, 249)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtDescription
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(608, 85)
        Me.LayoutControlItem2.Text = "Description:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(133, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdSave
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 196)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 33)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(32, 33)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(305, 33)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdCancel
        Me.LayoutControlItem4.Location = New System.Drawing.Point(305, 196)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 33)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(32, 33)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(303, 33)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 161)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(608, 35)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_ContentSelection
        '
        Me.LayoutControlGroup_ContentSelection.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lblItemSelection, Me.EmptySpaceItem1, Me.LayoutControlItem_Filtering, Me.LayoutControlItem_Sorting, Me.LayoutControlItem_SelectedData})
        Me.LayoutControlGroup_ContentSelection.Location = New System.Drawing.Point(0, 111)
        Me.LayoutControlGroup_ContentSelection.Name = "LayoutControlGroup_ContentSelection"
        Me.LayoutControlGroup_ContentSelection.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_ContentSelection.Size = New System.Drawing.Size(608, 50)
        Me.LayoutControlGroup_ContentSelection.TextVisible = False
        '
        'lblItemSelection
        '
        Me.lblItemSelection.AllowHotTrack = False
        Me.lblItemSelection.Location = New System.Drawing.Point(0, 0)
        Me.lblItemSelection.Name = "lblItemSelection"
        Me.lblItemSelection.Size = New System.Drawing.Size(602, 20)
        Me.lblItemSelection.Text = "Select Item(s) to Save:"
        Me.lblItemSelection.TextSize = New System.Drawing.Size(133, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 20)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(40, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem_Filtering
        '
        Me.LayoutControlItem_Filtering.Control = Me.chkFilter
        Me.LayoutControlItem_Filtering.Location = New System.Drawing.Point(40, 20)
        Me.LayoutControlItem_Filtering.Name = "LayoutControlItem_Filtering"
        Me.LayoutControlItem_Filtering.Size = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem_Filtering.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Filtering.TextVisible = False
        '
        'LayoutControlItem_Sorting
        '
        Me.LayoutControlItem_Sorting.Control = Me.chkSort
        Me.LayoutControlItem_Sorting.Location = New System.Drawing.Point(240, 20)
        Me.LayoutControlItem_Sorting.Name = "LayoutControlItem_Sorting"
        Me.LayoutControlItem_Sorting.Size = New System.Drawing.Size(176, 24)
        Me.LayoutControlItem_Sorting.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Sorting.TextVisible = False
        '
        'LayoutControlItem_SelectedData
        '
        Me.LayoutControlItem_SelectedData.Control = Me.chkSelectedData
        Me.LayoutControlItem_SelectedData.Location = New System.Drawing.Point(416, 20)
        Me.LayoutControlItem_SelectedData.Name = "LayoutControlItem_SelectedData"
        Me.LayoutControlItem_SelectedData.Size = New System.Drawing.Size(186, 24)
        Me.LayoutControlItem_SelectedData.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_SelectedData.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboTemplateName
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(608, 26)
        Me.LayoutControlItem5.Text = "Template Name:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(133, 16)
        '
        'frmSaveTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(628, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Save Template"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboTemplateName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSelectedData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_ContentSelection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItemSelection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Filtering, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Sorting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_SelectedData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    'Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Public WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    'Friend WithEvents chkSelectedData As DevExpress.XtraEditors.CheckEdit
    'Friend WithEvents chkSort As DevExpress.XtraEditors.CheckEdit
    'Friend WithEvents chkFilter As DevExpress.XtraEditors.CheckEdit
    Public WithEvents chkSelectedData As DevExpress.XtraEditors.CheckEdit
    Public WithEvents chkSort As DevExpress.XtraEditors.CheckEdit
    Public WithEvents chkFilter As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lblItemSelection As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlGroup_ContentSelection As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    'Friend WithEvents LayoutControlItem_Filtering As DevExpress.XtraLayout.LayoutControlItem
    'Friend WithEvents LayoutControlItem_Sorting As DevExpress.XtraLayout.LayoutControlItem
    'Friend WithEvents LayoutControlItem_SelectedData As DevExpress.XtraLayout.LayoutControlItem
    Public WithEvents LayoutControlItem_Filtering As DevExpress.XtraLayout.LayoutControlItem
    Public WithEvents LayoutControlItem_Sorting As DevExpress.XtraLayout.LayoutControlItem
    Public WithEvents LayoutControlItem_SelectedData As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboTemplateName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
