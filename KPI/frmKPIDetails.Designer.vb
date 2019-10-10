<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKPIDetails
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.picFormulaImage = New DevExpress.XtraEditors.PictureEdit()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.GridPI = New DevExpress.XtraGrid.GridControl()
        Me.GridPIView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVariableName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMPSReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtListing = New DevExpress.XtraEditors.TextEdit()
        Me.txtTimePeriod = New DevExpress.XtraEditors.TextEdit()
        Me.txtTarget = New DevExpress.XtraEditors.TextEdit()
        Me.txtMinReq = New DevExpress.XtraEditors.TextEdit()
        Me.txtFormula = New DevExpress.XtraEditors.TextEdit()
        Me.txtKPIType = New DevExpress.XtraEditors.TextEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Formula = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem_Formula = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem_FormulaImage = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_MinReqTarget = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Legend = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.picFormulaImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPIView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtListing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTimePeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTarget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinReq.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormula.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKPIType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Formula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_Formula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem_FormulaImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_MinReqTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Legend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.picFormulaImage)
        Me.LayoutControl1.Controls.Add(Me.txtDescription)
        Me.LayoutControl1.Controls.Add(Me.GridPI)
        Me.LayoutControl1.Controls.Add(Me.txtListing)
        Me.LayoutControl1.Controls.Add(Me.txtTimePeriod)
        Me.LayoutControl1.Controls.Add(Me.txtTarget)
        Me.LayoutControl1.Controls.Add(Me.txtMinReq)
        Me.LayoutControl1.Controls.Add(Me.txtFormula)
        Me.LayoutControl1.Controls.Add(Me.txtKPIType)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(620, 230, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1021, 699)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'picFormulaImage
        '
        Me.picFormulaImage.Location = New System.Drawing.Point(25, 259)
        Me.picFormulaImage.Name = "picFormulaImage"
        Me.picFormulaImage.Size = New System.Drawing.Size(981, 84)
        Me.picFormulaImage.StyleController = Me.LayoutControl1
        Me.picFormulaImage.TabIndex = 17
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(25, 99)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(981, 100)
        Me.txtDescription.StyleController = Me.LayoutControl1
        Me.txtDescription.TabIndex = 14
        '
        'GridPI
        '
        Me.GridPI.Location = New System.Drawing.Point(24, 441)
        Me.GridPI.MainView = Me.GridPIView
        Me.GridPI.Name = "GridPI"
        Me.GridPI.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repMemoEdit})
        Me.GridPI.Size = New System.Drawing.Size(982, 245)
        Me.GridPI.TabIndex = 12
        Me.GridPI.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridPIView})
        '
        'GridPIView
        '
        Me.GridPIView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colVariableName, Me.colName, Me.colDescription, Me.colMPSReference})
        Me.GridPIView.GridControl = Me.GridPI
        Me.GridPIView.Name = "GridPIView"
        Me.GridPIView.OptionsBehavior.ReadOnly = True
        Me.GridPIView.OptionsView.RowAutoHeight = True
        Me.GridPIView.OptionsView.ShowGroupPanel = False
        Me.GridPIView.OptionsView.ShowIndicator = False
        '
        'colVariableName
        '
        Me.colVariableName.Caption = "VariableName"
        Me.colVariableName.FieldName = "VariableName"
        Me.colVariableName.Name = "colVariableName"
        Me.colVariableName.Visible = True
        Me.colVariableName.VisibleIndex = 0
        Me.colVariableName.Width = 47
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.ColumnEdit = Me.repMemoEdit
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 1
        Me.colName.Width = 229
        '
        'repMemoEdit
        '
        Me.repMemoEdit.Name = "repMemoEdit"
        '
        'colDescription
        '
        Me.colDescription.Caption = "Description"
        Me.colDescription.ColumnEdit = Me.repMemoEdit
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 2
        Me.colDescription.Width = 219
        '
        'colMPSReference
        '
        Me.colMPSReference.Caption = "MPS Reference"
        Me.colMPSReference.ColumnEdit = Me.repMemoEdit
        Me.colMPSReference.FieldName = "MPSReference"
        Me.colMPSReference.Name = "colMPSReference"
        Me.colMPSReference.Visible = True
        Me.colMPSReference.VisibleIndex = 3
        Me.colMPSReference.Width = 193
        '
        'txtListing
        '
        Me.txtListing.Location = New System.Drawing.Point(105, 385)
        Me.txtListing.Name = "txtListing"
        Me.txtListing.Properties.ReadOnly = True
        Me.txtListing.Size = New System.Drawing.Size(409, 22)
        Me.txtListing.StyleController = Me.LayoutControl1
        Me.txtListing.TabIndex = 11
        '
        'txtTimePeriod
        '
        Me.txtTimePeriod.Location = New System.Drawing.Point(606, 385)
        Me.txtTimePeriod.Name = "txtTimePeriod"
        Me.txtTimePeriod.Properties.ReadOnly = True
        Me.txtTimePeriod.Size = New System.Drawing.Size(400, 22)
        Me.txtTimePeriod.StyleController = Me.LayoutControl1
        Me.txtTimePeriod.TabIndex = 10
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(605, 353)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Properties.ReadOnly = True
        Me.txtTarget.Size = New System.Drawing.Size(401, 22)
        Me.txtTarget.StyleController = Me.LayoutControl1
        Me.txtTarget.TabIndex = 9
        '
        'txtMinReq
        '
        Me.txtMinReq.Location = New System.Drawing.Point(205, 353)
        Me.txtMinReq.Name = "txtMinReq"
        Me.txtMinReq.Properties.ReadOnly = True
        Me.txtMinReq.Size = New System.Drawing.Size(307, 22)
        Me.txtMinReq.StyleController = Me.LayoutControl1
        Me.txtMinReq.TabIndex = 8
        '
        'txtFormula
        '
        Me.txtFormula.Location = New System.Drawing.Point(25, 233)
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.Properties.ReadOnly = True
        Me.txtFormula.Size = New System.Drawing.Size(981, 22)
        Me.txtFormula.StyleController = Me.LayoutControl1
        Me.txtFormula.TabIndex = 7
        '
        'txtKPIType
        '
        Me.txtKPIType.Location = New System.Drawing.Point(67, 46)
        Me.txtKPIType.Name = "txtKPIType"
        Me.txtKPIType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.txtKPIType.Properties.Appearance.Options.UseBackColor = True
        Me.txtKPIType.Properties.ReadOnly = True
        Me.txtKPIType.Size = New System.Drawing.Size(234, 22)
        Me.txtKPIType.StyleController = Me.LayoutControl1
        Me.txtKPIType.TabIndex = 5
        '
        'txtName
        '
        Me.txtName.EditValue = ""
        Me.txtName.Location = New System.Drawing.Point(12, 12)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.AllowFocused = False
        Me.txtName.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtName.Properties.Appearance.Options.UseBackColor = True
        Me.txtName.Properties.Appearance.Options.UseFont = True
        Me.txtName.Properties.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(997, 28)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlGroup2, Me.LayoutControlGroup_Formula, Me.LayoutControlGroup_MinReqTarget, Me.LayoutControlGroup5, Me.LayoutControlGroup_Legend})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1021, 699)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1001, 32)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtKPIType
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(293, 26)
        Me.LayoutControlItem2.Text = "Type:"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(293, 32)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(708, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 60)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1001, 134)
        Me.LayoutControlGroup2.Text = "Description"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtDescription
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 104)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(18, 104)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(985, 104)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup_Formula
        '
        Me.LayoutControlGroup_Formula.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Formula.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Formula.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem_Formula, Me.LayoutControlItem_FormulaImage})
        Me.LayoutControlGroup_Formula.Location = New System.Drawing.Point(0, 194)
        Me.LayoutControlGroup_Formula.Name = "LayoutControlGroup_Formula"
        Me.LayoutControlGroup_Formula.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 0, 0, 0)
        Me.LayoutControlGroup_Formula.Size = New System.Drawing.Size(1001, 144)
        Me.LayoutControlGroup_Formula.Text = "Formula"
        '
        'LayoutControlItem_Formula
        '
        Me.LayoutControlItem_Formula.Control = Me.txtFormula
        Me.LayoutControlItem_Formula.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem_Formula.Name = "LayoutControlItem_Formula"
        Me.LayoutControlItem_Formula.Size = New System.Drawing.Size(985, 26)
        Me.LayoutControlItem_Formula.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_Formula.TextVisible = False
        '
        'LayoutControlItem_FormulaImage
        '
        Me.LayoutControlItem_FormulaImage.Control = Me.picFormulaImage
        Me.LayoutControlItem_FormulaImage.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem_FormulaImage.MaxSize = New System.Drawing.Size(0, 88)
        Me.LayoutControlItem_FormulaImage.MinSize = New System.Drawing.Size(32, 88)
        Me.LayoutControlItem_FormulaImage.Name = "LayoutControlItem_FormulaImage"
        Me.LayoutControlItem_FormulaImage.Size = New System.Drawing.Size(985, 88)
        Me.LayoutControlItem_FormulaImage.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem_FormulaImage.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem_FormulaImage.TextVisible = False
        '
        'LayoutControlGroup_MinReqTarget
        '
        Me.LayoutControlGroup_MinReqTarget.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup_MinReqTarget.Location = New System.Drawing.Point(0, 338)
        Me.LayoutControlGroup_MinReqTarget.Name = "LayoutControlGroup_MinReqTarget"
        Me.LayoutControlGroup_MinReqTarget.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 0, 0, 0)
        Me.LayoutControlGroup_MinReqTarget.Size = New System.Drawing.Size(1001, 32)
        Me.LayoutControlGroup_MinReqTarget.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem5.Control = Me.txtMinReq
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(491, 26)
        Me.LayoutControlItem5.Text = "Mininum Requirement:"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(170, 13)
        Me.LayoutControlItem5.TextToControlDistance = 10
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem6.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem6.Control = Me.txtTarget
        Me.LayoutControlItem6.Location = New System.Drawing.Point(491, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(494, 26)
        Me.LayoutControlItem6.Text = "Target:"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(60, 13)
        Me.LayoutControlItem6.TextToControlDistance = 29
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 370)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 0, 0, 0)
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1001, 32)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem7.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem7.Control = Me.txtTimePeriod
        Me.LayoutControlItem7.Location = New System.Drawing.Point(493, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(492, 26)
        Me.LayoutControlItem7.Text = "Time Period:"
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem7.TextToControlDistance = 8
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem8.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem8.Control = Me.txtListing
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(493, 26)
        Me.LayoutControlItem8.Text = "Listed By:"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(70, 14)
        Me.LayoutControlItem8.TextToControlDistance = 10
        '
        'LayoutControlGroup_Legend
        '
        Me.LayoutControlGroup_Legend.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Legend.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Legend.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup_Legend.Location = New System.Drawing.Point(0, 402)
        Me.LayoutControlGroup_Legend.Name = "LayoutControlGroup_Legend"
        Me.LayoutControlGroup_Legend.Padding = New DevExpress.XtraLayout.Utils.Padding(9, 0, 0, 0)
        Me.LayoutControlGroup_Legend.Size = New System.Drawing.Size(1001, 279)
        Me.LayoutControlGroup_Legend.Text = "Performance Indicators"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GridPI
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(986, 249)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'frmKPIDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1021, 699)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKPIDetails"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KPI Details"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.picFormulaImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPIView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtListing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTimePeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTarget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinReq.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormula.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKPIType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Formula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_Formula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem_FormulaImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_MinReqTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Legend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridPI As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridPIView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtListing As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTimePeriod As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTarget As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMinReq As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFormula As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKPIType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem_Formula As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Formula As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_MinReqTarget As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Legend As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colVariableName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMPSReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents picFormulaImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem_FormulaImage As DevExpress.XtraLayout.LayoutControlItem
End Class
