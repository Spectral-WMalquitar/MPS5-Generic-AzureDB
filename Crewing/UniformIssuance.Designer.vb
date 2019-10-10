<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UniformIssuance
    Inherits BaseControl.BaseControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UniformIssuance))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SizeInformationLabel = New System.Windows.Forms.Label()
        Me.txtPantsSize = New DevExpress.XtraEditors.TextEdit()
        Me.txtCoverallSize = New DevExpress.XtraEditors.TextEdit()
        Me.txtPoloSize = New DevExpress.XtraEditors.TextEdit()
        Me.txtShoeSize = New DevExpress.XtraEditors.TextEdit()
        Me.cboGarmentTemplate = New DevExpress.XtraEditors.LookUpEdit()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyIDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colInUse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repInUse = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colInUseLabel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyGarment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repGarment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colFKeyIssueType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repIssueType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colPreferredSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateIssue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colIssuedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSS = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colNeedReIssue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repRemarks = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.AddTemplateSessionNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItemShoeSize = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItemCoverallSize = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItemPoloSize = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItemPantsSize = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_SizeInformation = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtPantsSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCoverallSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPoloSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtShoeSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGarmentTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repInUse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repGarment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repIssueType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemShoeSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemCoverallSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemPoloSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItemPantsSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_SizeInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection.InsertGalleryImage("add_32x32.png", "images/actions/add_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png"), 0)
        Me.ImageCollection.Images.SetKeyName(0, "add_32x32.png")
        Me.ImageCollection.InsertGalleryImage("cancel_32x32.png", "images/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"), 1)
        Me.ImageCollection.Images.SetKeyName(1, "cancel_32x32.png")
        Me.ImageCollection.InsertGalleryImage("edit_32x32.png", "images/edit/edit_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_32x32.png"), 2)
        Me.ImageCollection.Images.SetKeyName(2, "edit_32x32.png")
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1043, 543)
        Me.header.TabIndex = 0
        Me.header.Text = "Uniform Issuance"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SizeInformationLabel)
        Me.LayoutControl1.Controls.Add(Me.txtPantsSize)
        Me.LayoutControl1.Controls.Add(Me.txtCoverallSize)
        Me.LayoutControl1.Controls.Add(Me.txtPoloSize)
        Me.LayoutControl1.Controls.Add(Me.txtShoeSize)
        Me.LayoutControl1.Controls.Add(Me.cboGarmentTemplate)
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1039, 515)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SizeInformationLabel
        '
        Me.SizeInformationLabel.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Italic)
        Me.SizeInformationLabel.ForeColor = System.Drawing.Color.Firebrick
        Me.SizeInformationLabel.Location = New System.Drawing.Point(490, 441)
        Me.SizeInformationLabel.Name = "SizeInformationLabel"
        Me.SizeInformationLabel.Size = New System.Drawing.Size(523, 34)
        Me.SizeInformationLabel.TabIndex = 21
        Me.SizeInformationLabel.Text = "Note: These information are read only. Go to the Biodata form to edit any of thes" & _
    "e information."
        '
        'txtPantsSize
        '
        Me.txtPantsSize.Location = New System.Drawing.Point(334, 466)
        Me.txtPantsSize.Name = "txtPantsSize"
        Me.txtPantsSize.Size = New System.Drawing.Size(144, 22)
        Me.txtPantsSize.StyleController = Me.LayoutControl1
        Me.txtPantsSize.TabIndex = 19
        '
        'txtCoverallSize
        '
        Me.txtCoverallSize.Location = New System.Drawing.Point(106, 466)
        Me.txtCoverallSize.Name = "txtCoverallSize"
        Me.txtCoverallSize.Size = New System.Drawing.Size(136, 22)
        Me.txtCoverallSize.StyleController = Me.LayoutControl1
        Me.txtCoverallSize.TabIndex = 18
        '
        'txtPoloSize
        '
        Me.txtPoloSize.Location = New System.Drawing.Point(334, 441)
        Me.txtPoloSize.Name = "txtPoloSize"
        Me.txtPoloSize.Size = New System.Drawing.Size(144, 22)
        Me.txtPoloSize.StyleController = Me.LayoutControl1
        Me.txtPoloSize.TabIndex = 17
        '
        'txtShoeSize
        '
        Me.txtShoeSize.Location = New System.Drawing.Point(106, 441)
        Me.txtShoeSize.Name = "txtShoeSize"
        Me.txtShoeSize.Size = New System.Drawing.Size(136, 22)
        Me.txtShoeSize.StyleController = Me.LayoutControl1
        Me.txtShoeSize.TabIndex = 16
        '
        'cboGarmentTemplate
        '
        Me.cboGarmentTemplate.Location = New System.Drawing.Point(186, 14)
        Me.cboGarmentTemplate.Name = "cboGarmentTemplate"
        Me.cboGarmentTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)})
        Me.cboGarmentTemplate.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboGarmentTemplate.Properties.DisplayMember = "Name"
        Me.cboGarmentTemplate.Properties.NullText = ""
        Me.cboGarmentTemplate.Properties.ValueMember = "PKey"
        Me.cboGarmentTemplate.Size = New System.Drawing.Size(165, 22)
        Me.cboGarmentTemplate.StyleController = Me.LayoutControl1
        Me.cboGarmentTemplate.TabIndex = 15
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(13, 39)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repGarment, Me.repIssueType, Me.repDateEdit, Me.repQty, Me.repInUse, Me.repRemarks, Me.repSS})
        Me.MainGrid.Size = New System.Drawing.Size(1013, 362)
        Me.MainGrid.TabIndex = 4
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Edited, Me.colPKey, Me.colFKeyIDNbr, Me.colInUse, Me.colInUseLabel, Me.colFKeyGarment, Me.colFKeyIssueType, Me.colQuantity, Me.colPreferredSize, Me.colDateIssue, Me.colIssuedBy, Me.colFKeyActID, Me.colNeedReIssue, Me.colRemarks, Me.AddTemplateSessionNo})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsView.ColumnAutoWidth = False
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'colPKey
        '
        Me.colPKey.Caption = "PKey"
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colFKeyIDNbr
        '
        Me.colFKeyIDNbr.Caption = "FKeyIDNbr"
        Me.colFKeyIDNbr.FieldName = "FKeyIDNbr"
        Me.colFKeyIDNbr.Name = "colFKeyIDNbr"
        '
        'colInUse
        '
        Me.colInUse.Caption = "In Use"
        Me.colInUse.ColumnEdit = Me.repInUse
        Me.colInUse.FieldName = "InUse"
        Me.colInUse.Name = "colInUse"
        Me.colInUse.Visible = True
        Me.colInUse.VisibleIndex = 2
        Me.colInUse.Width = 64
        '
        'repInUse
        '
        Me.repInUse.AutoHeight = False
        Me.repInUse.Name = "repInUse"
        '
        'colInUseLabel
        '
        Me.colInUseLabel.Caption = "Group"
        Me.colInUseLabel.FieldName = "InUseLabel"
        Me.colInUseLabel.Name = "colInUseLabel"
        '
        'colFKeyGarment
        '
        Me.colFKeyGarment.Caption = "Garment Type"
        Me.colFKeyGarment.ColumnEdit = Me.repGarment
        Me.colFKeyGarment.FieldName = "FKeyGarment"
        Me.colFKeyGarment.Name = "colFKeyGarment"
        Me.colFKeyGarment.Visible = True
        Me.colFKeyGarment.VisibleIndex = 0
        Me.colFKeyGarment.Width = 168
        '
        'repGarment
        '
        Me.repGarment.AutoHeight = False
        Me.repGarment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repGarment.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repGarment.DisplayMember = "Name"
        Me.repGarment.Name = "repGarment"
        Me.repGarment.NullText = ""
        Me.repGarment.ShowFooter = False
        Me.repGarment.ShowHeader = False
        Me.repGarment.ValueMember = "PKey"
        '
        'colFKeyIssueType
        '
        Me.colFKeyIssueType.Caption = "Issue Type"
        Me.colFKeyIssueType.ColumnEdit = Me.repIssueType
        Me.colFKeyIssueType.FieldName = "FKeyIssueType"
        Me.colFKeyIssueType.Name = "colFKeyIssueType"
        Me.colFKeyIssueType.Visible = True
        Me.colFKeyIssueType.VisibleIndex = 1
        Me.colFKeyIssueType.Width = 109
        '
        'repIssueType
        '
        Me.repIssueType.AutoHeight = False
        Me.repIssueType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repIssueType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repIssueType.DisplayMember = "Name"
        Me.repIssueType.Name = "repIssueType"
        Me.repIssueType.NullText = ""
        Me.repIssueType.ValueMember = "PKey"
        '
        'colQuantity
        '
        Me.colQuantity.Caption = "Qty"
        Me.colQuantity.ColumnEdit = Me.repQty
        Me.colQuantity.FieldName = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.Visible = True
        Me.colQuantity.VisibleIndex = 3
        Me.colQuantity.Width = 55
        '
        'repQty
        '
        Me.repQty.AutoHeight = False
        Me.repQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repQty.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.repQty.Name = "repQty"
        '
        'colPreferredSize
        '
        Me.colPreferredSize.Caption = "Preferred Size"
        Me.colPreferredSize.FieldName = "PreferredSize"
        Me.colPreferredSize.Name = "colPreferredSize"
        Me.colPreferredSize.Visible = True
        Me.colPreferredSize.VisibleIndex = 4
        Me.colPreferredSize.Width = 99
        '
        'colDateIssue
        '
        Me.colDateIssue.Caption = "Date Issued"
        Me.colDateIssue.ColumnEdit = Me.repDateEdit
        Me.colDateIssue.FieldName = "DateIssue"
        Me.colDateIssue.Name = "colDateIssue"
        Me.colDateIssue.Visible = True
        Me.colDateIssue.VisibleIndex = 5
        Me.colDateIssue.Width = 121
        '
        'repDateEdit
        '
        Me.repDateEdit.AutoHeight = False
        Me.repDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.repDateEdit.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.repDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.repDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.repDateEdit.Name = "repDateEdit"
        '
        'colIssuedBy
        '
        Me.colIssuedBy.Caption = "Issued By"
        Me.colIssuedBy.FieldName = "IssuedBy"
        Me.colIssuedBy.Name = "colIssuedBy"
        Me.colIssuedBy.Visible = True
        Me.colIssuedBy.VisibleIndex = 6
        Me.colIssuedBy.Width = 85
        '
        'colFKeyActID
        '
        Me.colFKeyActID.Caption = "Sea Service"
        Me.colFKeyActID.ColumnEdit = Me.repSS
        Me.colFKeyActID.FieldName = "FKeyActID"
        Me.colFKeyActID.Name = "colFKeyActID"
        Me.colFKeyActID.Visible = True
        Me.colFKeyActID.VisibleIndex = 8
        Me.colFKeyActID.Width = 300
        '
        'repSS
        '
        Me.repSS.AutoHeight = False
        Me.repSS.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repSS.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ActID", "ActID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", 40, "Description")})
        Me.repSS.DisplayMember = "Description"
        Me.repSS.Name = "repSS"
        Me.repSS.NullText = ""
        Me.repSS.PopupWidth = 150
        Me.repSS.ShowHeader = False
        Me.repSS.ValueMember = "ActID"
        '
        'colNeedReIssue
        '
        Me.colNeedReIssue.Caption = "Needs Re-Issue"
        Me.colNeedReIssue.FieldName = "NeedReIssue"
        Me.colNeedReIssue.Name = "colNeedReIssue"
        Me.colNeedReIssue.OptionsColumn.AllowEdit = False
        Me.colNeedReIssue.Visible = True
        Me.colNeedReIssue.VisibleIndex = 7
        Me.colNeedReIssue.Width = 112
        '
        'colRemarks
        '
        Me.colRemarks.Caption = "Remarks"
        Me.colRemarks.ColumnEdit = Me.repRemarks
        Me.colRemarks.FieldName = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.Visible = True
        Me.colRemarks.VisibleIndex = 9
        Me.colRemarks.Width = 122
        '
        'repRemarks
        '
        Me.repRemarks.Name = "repRemarks"
        '
        'AddTemplateSessionNo
        '
        Me.AddTemplateSessionNo.Caption = "AddTemplateSessionNo"
        Me.AddTemplateSessionNo.FieldName = "AddTemplateSessionNo"
        Me.AddTemplateSessionNo.Name = "AddTemplateSessionNo"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlGroup_SizeInformation})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1039, 515)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MainGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1017, 366)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboGarmentTemplate
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(342, 25)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(342, 25)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(342, 25)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Add garments from template:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(170, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(342, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(675, 25)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(464, 38)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(527, 12)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItemShoeSize
        '
        Me.LayoutControlItemShoeSize.Control = Me.txtShoeSize
        Me.LayoutControlItemShoeSize.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItemShoeSize.MaxSize = New System.Drawing.Size(228, 25)
        Me.LayoutControlItemShoeSize.MinSize = New System.Drawing.Size(228, 25)
        Me.LayoutControlItemShoeSize.Name = "LayoutControlItemShoeSize"
        Me.LayoutControlItemShoeSize.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItemShoeSize.Size = New System.Drawing.Size(228, 25)
        Me.LayoutControlItemShoeSize.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItemShoeSize.Text = "Shoe Size:"
        Me.LayoutControlItemShoeSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItemShoeSize.TextSize = New System.Drawing.Size(75, 16)
        Me.LayoutControlItemShoeSize.TextToControlDistance = 5
        '
        'LayoutControlItemCoverallSize
        '
        Me.LayoutControlItemCoverallSize.Control = Me.txtCoverallSize
        Me.LayoutControlItemCoverallSize.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItemCoverallSize.MaxSize = New System.Drawing.Size(228, 25)
        Me.LayoutControlItemCoverallSize.MinSize = New System.Drawing.Size(228, 25)
        Me.LayoutControlItemCoverallSize.Name = "LayoutControlItemCoverallSize"
        Me.LayoutControlItemCoverallSize.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItemCoverallSize.Size = New System.Drawing.Size(228, 25)
        Me.LayoutControlItemCoverallSize.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItemCoverallSize.Text = "Coverall:"
        Me.LayoutControlItemCoverallSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItemCoverallSize.TextSize = New System.Drawing.Size(75, 20)
        Me.LayoutControlItemCoverallSize.TextToControlDistance = 5
        '
        'LayoutControlItemPoloSize
        '
        Me.LayoutControlItemPoloSize.Control = Me.txtPoloSize
        Me.LayoutControlItemPoloSize.Location = New System.Drawing.Point(228, 0)
        Me.LayoutControlItemPoloSize.MaxSize = New System.Drawing.Size(236, 25)
        Me.LayoutControlItemPoloSize.MinSize = New System.Drawing.Size(236, 25)
        Me.LayoutControlItemPoloSize.Name = "LayoutControlItemPoloSize"
        Me.LayoutControlItemPoloSize.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItemPoloSize.Size = New System.Drawing.Size(236, 25)
        Me.LayoutControlItemPoloSize.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItemPoloSize.Text = "Polo Size:"
        Me.LayoutControlItemPoloSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItemPoloSize.TextSize = New System.Drawing.Size(75, 20)
        Me.LayoutControlItemPoloSize.TextToControlDistance = 5
        '
        'LayoutControlItemPantsSize
        '
        Me.LayoutControlItemPantsSize.Control = Me.txtPantsSize
        Me.LayoutControlItemPantsSize.Location = New System.Drawing.Point(228, 25)
        Me.LayoutControlItemPantsSize.MaxSize = New System.Drawing.Size(236, 25)
        Me.LayoutControlItemPantsSize.MinSize = New System.Drawing.Size(236, 25)
        Me.LayoutControlItemPantsSize.Name = "LayoutControlItemPantsSize"
        Me.LayoutControlItemPantsSize.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItemPantsSize.Size = New System.Drawing.Size(236, 25)
        Me.LayoutControlItemPantsSize.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItemPantsSize.Text = "Pants Size:"
        Me.LayoutControlItemPantsSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItemPantsSize.TextSize = New System.Drawing.Size(75, 20)
        Me.LayoutControlItemPantsSize.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SizeInformationLabel
        Me.LayoutControlItem3.Location = New System.Drawing.Point(464, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(527, 38)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup_SizeInformation
        '
        Me.LayoutControlGroup_SizeInformation.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_SizeInformation.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_SizeInformation.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItemPoloSize, Me.LayoutControlItemPantsSize, Me.LayoutControlItemShoeSize, Me.LayoutControlItemCoverallSize})
        Me.LayoutControlGroup_SizeInformation.Location = New System.Drawing.Point(0, 391)
        Me.LayoutControlGroup_SizeInformation.Name = "LayoutControlGroup_SizeInformation"
        Me.LayoutControlGroup_SizeInformation.Size = New System.Drawing.Size(1017, 100)
        Me.LayoutControlGroup_SizeInformation.Text = "Size Information"
        '
        'UniformIssuance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "UniformIssuance"
        Me.Size = New System.Drawing.Size(1043, 543)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtPantsSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCoverallSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPoloSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtShoeSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboGarmentTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repInUse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repGarment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repIssueType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemShoeSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemCoverallSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemPoloSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItemPantsSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_SizeInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyGarment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repGarment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colFKeyIssueType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repIssueType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colPreferredSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateIssue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colIssuedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colInUse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colInUseLabel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyIDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repInUse As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents repRemarks As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents repSS As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colNeedReIssue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboGarmentTemplate As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents AddTemplateSessionNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPantsSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCoverallSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPoloSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtShoeSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItemShoeSize As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItemCoverallSize As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItemPoloSize As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItemPantsSize As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SizeInformationLabel As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_SizeInformation As DevExpress.XtraLayout.LayoutControlGroup

End Class
