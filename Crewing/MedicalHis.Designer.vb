<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MedicalHis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MedicalHis))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.MedHisImgView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repBtnEditBrowse = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MedHisGrid = New DevExpress.XtraGrid.GridControl()
        Me.MedHisView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FKeyActivityID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyIDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkRel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repBool = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Diagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyVessel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVessel = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DateAcq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.PlaceAcq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsPICase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PICaseRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyMedStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repMedStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DateStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RemarksMed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateUpdated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LastUpdatedByA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.MedCostGrid = New DevExpress.XtraGrid.GridControl()
        Me.MedCostView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyCurr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCurr = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repAmt = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.FKeyMedCostItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repItems = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Place = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDateCost = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RemarksCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ChargeType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repChargeType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MedStatGrid = New DevExpress.XtraGrid.GridControl()
        Me.MedStatView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateEntry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDateStat = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RemarksStat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedHisImgView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBtnEditBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedHisGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedHisView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBool, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repMedStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MedCostGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedCostView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCurr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateCost.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repChargeType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedStatGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MedStatView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateStat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateStat.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'MedHisImgView
        '
        Me.MedHisImgView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23})
        Me.MedHisImgView.GridControl = Me.MedHisGrid
        Me.MedHisImgView.Name = "MedHisImgView"
        Me.MedHisImgView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "PKey"
        Me.GridColumn15.FieldName = "PKey"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "FKeyIDNbr"
        Me.GridColumn16.FieldName = "FKeyIDNbr"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "FKeyCrewDocumentID"
        Me.GridColumn17.FieldName = "FKeyCrewDocumentID"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Description"
        Me.GridColumn18.ColumnEdit = Me.repBtnEditBrowse
        Me.GridColumn18.FieldName = "Description"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 0
        '
        'repBtnEditBrowse
        '
        Me.repBtnEditBrowse.AutoHeight = False
        Me.repBtnEditBrowse.Name = "repBtnEditBrowse"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "FilePath"
        Me.GridColumn19.FieldName = "FilePath"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "DateUpdated"
        Me.GridColumn20.FieldName = "DateUpdated"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "LastUpdatedBy"
        Me.GridColumn21.FieldName = "LastUpdatedBy"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Edited"
        Me.GridColumn22.FieldName = "Edited"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "tempFilePath"
        Me.GridColumn23.FieldName = "tempFilePath"
        Me.GridColumn23.Name = "GridColumn23"
        '
        'MedHisGrid
        '
        GridLevelNode1.LevelTemplate = Me.MedHisImgView
        GridLevelNode1.RelationName = "DocImgView"
        Me.MedHisGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.MedHisGrid.Location = New System.Drawing.Point(25, 49)
        Me.MedHisGrid.MainView = Me.MedHisView
        Me.MedHisGrid.Name = "MedHisGrid"
        Me.MedHisGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repDate, Me.repVessel, Me.repMedStatus, Me.repBool, Me.repBtnEditBrowse})
        Me.MedHisGrid.Size = New System.Drawing.Size(1156, 231)
        Me.MedHisGrid.TabIndex = 4
        Me.MedHisGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MedHisView, Me.MedHisImgView})
        '
        'MedHisView
        '
        Me.MedHisView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.MedHisView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FKeyActivityID, Me.FKeyIDNbr, Me.PKey, Me.WorkRel, Me.Diagnosis, Me.FKeyVessel, Me.DateAcq, Me.PlaceAcq, Me.IsPICase, Me.PICaseRefNo, Me.FKeyMedStatus, Me.DateStatus, Me.RemarksMed, Me.DateUpdated, Me.LastUpdatedByA, Me.GridColumn10})
        Me.MedHisView.GridControl = Me.MedHisGrid
        Me.MedHisView.Name = "MedHisView"
        Me.MedHisView.OptionsView.ShowGroupPanel = False
        '
        'FKeyActivityID
        '
        Me.FKeyActivityID.Caption = "GridColumn1"
        Me.FKeyActivityID.FieldName = "FKeyActivityID"
        Me.FKeyActivityID.Name = "FKeyActivityID"
        '
        'FKeyIDNbr
        '
        Me.FKeyIDNbr.Caption = "GridColumn1"
        Me.FKeyIDNbr.FieldName = "FKeyIDNbr"
        Me.FKeyIDNbr.Name = "FKeyIDNbr"
        '
        'PKey
        '
        Me.PKey.Caption = "GridColumn1"
        Me.PKey.FieldName = "PKey"
        Me.PKey.Name = "PKey"
        '
        'WorkRel
        '
        Me.WorkRel.Caption = "Work Related?"
        Me.WorkRel.ColumnEdit = Me.repBool
        Me.WorkRel.FieldName = "WorkRel"
        Me.WorkRel.MinWidth = 10
        Me.WorkRel.Name = "WorkRel"
        Me.WorkRel.Visible = True
        Me.WorkRel.VisibleIndex = 0
        Me.WorkRel.Width = 78
        '
        'repBool
        '
        Me.repBool.AutoHeight = False
        Me.repBool.Name = "repBool"
        Me.repBool.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'Diagnosis
        '
        Me.Diagnosis.Caption = "Diagnosis"
        Me.Diagnosis.FieldName = "Diagnosis"
        Me.Diagnosis.Name = "Diagnosis"
        Me.Diagnosis.Visible = True
        Me.Diagnosis.VisibleIndex = 1
        Me.Diagnosis.Width = 134
        '
        'FKeyVessel
        '
        Me.FKeyVessel.Caption = "Vessel"
        Me.FKeyVessel.ColumnEdit = Me.repVessel
        Me.FKeyVessel.FieldName = "FKeyVessel"
        Me.FKeyVessel.Name = "FKeyVessel"
        Me.FKeyVessel.Visible = True
        Me.FKeyVessel.VisibleIndex = 4
        Me.FKeyVessel.Width = 66
        '
        'repVessel
        '
        Me.repVessel.AutoHeight = False
        Me.repVessel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repVessel.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 50, "Vessel"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VesselStatus", "Status")})
        Me.repVessel.DisplayMember = "Name"
        Me.repVessel.Name = "repVessel"
        Me.repVessel.NullText = ""
        Me.repVessel.ShowFooter = False
        Me.repVessel.ShowHeader = False
        Me.repVessel.ValueMember = "PKey"
        '
        'DateAcq
        '
        Me.DateAcq.Caption = "Date Acquired"
        Me.DateAcq.ColumnEdit = Me.repDate
        Me.DateAcq.FieldName = "DateAcq"
        Me.DateAcq.Name = "DateAcq"
        Me.DateAcq.Visible = True
        Me.DateAcq.VisibleIndex = 2
        Me.DateAcq.Width = 85
        '
        'repDate
        '
        Me.repDate.AutoHeight = False
        Me.repDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDate.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.repDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.repDate.Mask.EditMask = "dd-MMM-yyyy"
        Me.repDate.Mask.UseMaskAsDisplayFormat = True
        Me.repDate.Name = "repDate"
        Me.repDate.NullDate = ""
        '
        'PlaceAcq
        '
        Me.PlaceAcq.Caption = "Place"
        Me.PlaceAcq.FieldName = "PlaceAcq"
        Me.PlaceAcq.Name = "PlaceAcq"
        Me.PlaceAcq.Visible = True
        Me.PlaceAcq.VisibleIndex = 3
        Me.PlaceAcq.Width = 111
        '
        'IsPICase
        '
        Me.IsPICase.Caption = "Is P&I Case?"
        Me.IsPICase.ColumnEdit = Me.repBool
        Me.IsPICase.FieldName = "IsPICase"
        Me.IsPICase.Name = "IsPICase"
        Me.IsPICase.Visible = True
        Me.IsPICase.VisibleIndex = 5
        Me.IsPICase.Width = 62
        '
        'PICaseRefNo
        '
        Me.PICaseRefNo.Caption = "P&I Case Ref. No."
        Me.PICaseRefNo.FieldName = "PICaseRefNo"
        Me.PICaseRefNo.Name = "PICaseRefNo"
        Me.PICaseRefNo.Visible = True
        Me.PICaseRefNo.VisibleIndex = 6
        Me.PICaseRefNo.Width = 88
        '
        'FKeyMedStatus
        '
        Me.FKeyMedStatus.Caption = "Status"
        Me.FKeyMedStatus.ColumnEdit = Me.repMedStatus
        Me.FKeyMedStatus.FieldName = "FKeyMedStatus"
        Me.FKeyMedStatus.Name = "FKeyMedStatus"
        Me.FKeyMedStatus.Visible = True
        Me.FKeyMedStatus.VisibleIndex = 7
        Me.FKeyMedStatus.Width = 120
        '
        'repMedStatus
        '
        Me.repMedStatus.AutoHeight = False
        Me.repMedStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repMedStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repMedStatus.DisplayMember = "Name"
        Me.repMedStatus.Name = "repMedStatus"
        Me.repMedStatus.NullText = ""
        Me.repMedStatus.ShowFooter = False
        Me.repMedStatus.ShowHeader = False
        Me.repMedStatus.ValueMember = "PKey"
        '
        'DateStatus
        '
        Me.DateStatus.Caption = "Last Status Date"
        Me.DateStatus.ColumnEdit = Me.repDate
        Me.DateStatus.FieldName = "DateStatus"
        Me.DateStatus.Name = "DateStatus"
        Me.DateStatus.Visible = True
        Me.DateStatus.VisibleIndex = 8
        Me.DateStatus.Width = 117
        '
        'RemarksMed
        '
        Me.RemarksMed.Caption = "Remarks"
        Me.RemarksMed.FieldName = "Remarks"
        Me.RemarksMed.Name = "RemarksMed"
        Me.RemarksMed.Visible = True
        Me.RemarksMed.VisibleIndex = 9
        Me.RemarksMed.Width = 184
        '
        'DateUpdated
        '
        Me.DateUpdated.Caption = "GridColumn1"
        Me.DateUpdated.FieldName = "DateUpdated"
        Me.DateUpdated.Name = "DateUpdated"
        '
        'LastUpdatedByA
        '
        Me.LastUpdatedByA.Caption = "GridColumn2"
        Me.LastUpdatedByA.FieldName = "LastUpdatedBy"
        Me.LastUpdatedByA.Name = "LastUpdatedByA"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Edited"
        Me.GridColumn10.FieldName = "Edited"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1210, 570)
        Me.header.TabIndex = 5
        Me.header.Text = "Medical History"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.MedCostGrid)
        Me.LayoutControl1.Controls.Add(Me.MedStatGrid)
        Me.LayoutControl1.Controls.Add(Me.MedHisGrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(510, 198, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1206, 542)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'MedCostGrid
        '
        Me.MedCostGrid.Location = New System.Drawing.Point(485, 312)
        Me.MedCostGrid.MainView = Me.MedCostView
        Me.MedCostGrid.Name = "MedCostGrid"
        Me.MedCostGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repCurr, Me.repItems, Me.repChargeType, Me.repDateCost, Me.repAmt})
        Me.MedCostGrid.Size = New System.Drawing.Size(696, 205)
        Me.MedCostGrid.TabIndex = 6
        Me.MedCostGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MedCostView})
        '
        'MedCostView
        '
        Me.MedCostView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn7, Me.FKeyCurr, Me.Amount, Me.FKeyMedCostItem, Me.Place, Me.GridColumn9, Me.RemarksCost, Me.ChargeType, Me.GridColumn5, Me.GridColumn6, Me.GridColumn12})
        Me.MedCostView.GridControl = Me.MedCostGrid
        Me.MedCostView.Name = "MedCostView"
        Me.MedCostView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "PKey"
        Me.GridColumn8.FieldName = "PKey"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "FKeyMedHistory"
        Me.GridColumn7.FieldName = "FKeyMedHistory"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'FKeyCurr
        '
        Me.FKeyCurr.Caption = "Currency"
        Me.FKeyCurr.ColumnEdit = Me.repCurr
        Me.FKeyCurr.FieldName = "FKeyCurr"
        Me.FKeyCurr.Name = "FKeyCurr"
        Me.FKeyCurr.Visible = True
        Me.FKeyCurr.VisibleIndex = 0
        '
        'repCurr
        '
        Me.repCurr.AutoHeight = False
        Me.repCurr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repCurr.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repCurr.DisplayMember = "Name"
        Me.repCurr.Name = "repCurr"
        Me.repCurr.NullText = ""
        Me.repCurr.ShowFooter = False
        Me.repCurr.ShowHeader = False
        Me.repCurr.ValueMember = "PKey"
        '
        'Amount
        '
        Me.Amount.Caption = "Amount"
        Me.Amount.ColumnEdit = Me.repAmt
        Me.Amount.FieldName = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Visible = True
        Me.Amount.VisibleIndex = 1
        '
        'repAmt
        '
        Me.repAmt.AutoHeight = False
        Me.repAmt.Mask.EditMask = "n2"
        Me.repAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repAmt.Mask.UseMaskAsDisplayFormat = True
        Me.repAmt.Name = "repAmt"
        '
        'FKeyMedCostItem
        '
        Me.FKeyMedCostItem.Caption = "Item"
        Me.FKeyMedCostItem.ColumnEdit = Me.repItems
        Me.FKeyMedCostItem.FieldName = "FKeyMedCostItem"
        Me.FKeyMedCostItem.Name = "FKeyMedCostItem"
        Me.FKeyMedCostItem.Visible = True
        Me.FKeyMedCostItem.VisibleIndex = 2
        '
        'repItems
        '
        Me.repItems.AutoHeight = False
        Me.repItems.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repItems.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repItems.DisplayMember = "Name"
        Me.repItems.Name = "repItems"
        Me.repItems.NullText = ""
        Me.repItems.ShowFooter = False
        Me.repItems.ShowHeader = False
        Me.repItems.ValueMember = "PKey"
        '
        'Place
        '
        Me.Place.Caption = "Place"
        Me.Place.FieldName = "Place"
        Me.Place.Name = "Place"
        Me.Place.Visible = True
        Me.Place.VisibleIndex = 3
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Date"
        Me.GridColumn9.ColumnEdit = Me.repDateCost
        Me.GridColumn9.FieldName = "DateEntry"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 5
        '
        'repDateCost
        '
        Me.repDateCost.AutoHeight = False
        Me.repDateCost.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repDateCost.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateCost.Mask.EditMask = "dd-MMM-yyyy"
        Me.repDateCost.Mask.UseMaskAsDisplayFormat = True
        Me.repDateCost.Name = "repDateCost"
        Me.repDateCost.NullDate = ""
        '
        'RemarksCost
        '
        Me.RemarksCost.Caption = "Remarks"
        Me.RemarksCost.FieldName = "Remarks"
        Me.RemarksCost.Name = "RemarksCost"
        Me.RemarksCost.Visible = True
        Me.RemarksCost.VisibleIndex = 4
        '
        'ChargeType
        '
        Me.ChargeType.Caption = "Charge Type"
        Me.ChargeType.ColumnEdit = Me.repChargeType
        Me.ChargeType.FieldName = "ChargeType"
        Me.ChargeType.Name = "ChargeType"
        Me.ChargeType.Visible = True
        Me.ChargeType.VisibleIndex = 6
        '
        'repChargeType
        '
        Me.repChargeType.AutoHeight = False
        Me.repChargeType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repChargeType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repChargeType.DisplayMember = "Name"
        Me.repChargeType.DropDownRows = 3
        Me.repChargeType.Name = "repChargeType"
        Me.repChargeType.NullText = ""
        Me.repChargeType.ShowFooter = False
        Me.repChargeType.ShowHeader = False
        Me.repChargeType.ValueMember = "PKey"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "DateUpdated"
        Me.GridColumn5.FieldName = "DateUpdated"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "LastUpdatedBy"
        Me.GridColumn6.FieldName = "LastUpdatedBy"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Edited"
        Me.GridColumn12.FieldName = "Edited"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'MedStatGrid
        '
        Me.MedStatGrid.Location = New System.Drawing.Point(25, 312)
        Me.MedStatGrid.MainView = Me.MedStatView
        Me.MedStatGrid.Name = "MedStatGrid"
        Me.MedStatGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repDateStat})
        Me.MedStatGrid.Size = New System.Drawing.Size(450, 205)
        Me.MedStatGrid.TabIndex = 5
        Me.MedStatGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MedStatView})
        '
        'MedStatView
        '
        Me.MedStatView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.DateEntry, Me.Status, Me.RemarksStat, Me.GridColumn3, Me.GridColumn4, Me.GridColumn11, Me.GridColumn13, Me.GridColumn14})
        Me.MedStatView.GridControl = Me.MedStatGrid
        Me.MedStatView.Name = "MedStatView"
        Me.MedStatView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PKey"
        Me.GridColumn1.FieldName = "PKey"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "FKeyMedHistory"
        Me.GridColumn2.FieldName = "FKeyMedHistory"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'DateEntry
        '
        Me.DateEntry.Caption = "Date"
        Me.DateEntry.ColumnEdit = Me.repDateStat
        Me.DateEntry.FieldName = "DateEntry"
        Me.DateEntry.Name = "DateEntry"
        Me.DateEntry.Visible = True
        Me.DateEntry.VisibleIndex = 0
        Me.DateEntry.Width = 133
        '
        'repDateStat
        '
        Me.repDateStat.AutoHeight = False
        Me.repDateStat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repDateStat.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateStat.Mask.EditMask = "dd-MMM-yyyy HH:mm:ss"
        Me.repDateStat.Mask.UseMaskAsDisplayFormat = True
        Me.repDateStat.Name = "repDateStat"
        Me.repDateStat.NullDate = ""
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 1
        Me.Status.Width = 97
        '
        'RemarksStat
        '
        Me.RemarksStat.Caption = "Remarks"
        Me.RemarksStat.FieldName = "Remarks"
        Me.RemarksStat.Name = "RemarksStat"
        Me.RemarksStat.Visible = True
        Me.RemarksStat.VisibleIndex = 2
        Me.RemarksStat.Width = 105
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "DateUpdated"
        Me.GridColumn3.FieldName = "DateUpdated"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "LastUpdatedBy"
        Me.GridColumn4.FieldName = "LastUpdatedBy"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Edited"
        Me.GridColumn11.FieldName = "Edited"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "User"
        Me.GridColumn13.FieldName = "UserName"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 3
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "UserID"
        Me.GridColumn14.FieldName = "UserID"
        Me.GridColumn14.Name = "GridColumn14"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup4, Me.LayoutControlGroup3, Me.LayoutControlGroup5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1206, 542)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup4.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 265)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(460, 237)
        Me.LayoutControlGroup4.Text = "Status Monitoring"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.MedStatGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(454, 209)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(460, 265)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(706, 237)
        Me.LayoutControlGroup3.Text = "Cost Monitoring"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.MedCostGrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(700, 209)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup5.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup5.CustomizationFormText = "Medical History"
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1166, 265)
        Me.LayoutControlGroup5.Text = "Medical History"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MedHisGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1160, 235)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'MedicalHis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "MedicalHis"
        Me.Size = New System.Drawing.Size(1210, 570)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedHisImgView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBtnEditBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedHisGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedHisView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBool, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repMedStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MedCostGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedCostView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCurr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateCost.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repChargeType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedStatGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MedStatView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateStat.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateStat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MedCostGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MedCostView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MedStatGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MedStatView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MedHisGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MedHisView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents WorkRel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Diagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateAcq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PlaceAcq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsPICase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PICaseRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyMedStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RemarksMed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateEntry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RemarksStat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyMedCostItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Place As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RemarksCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ChargeType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyVessel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyActivityID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyIDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateUpdated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LastUpdatedByA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repVessel As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repMedStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repCurr As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repItems As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repDateStat As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repChargeType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repDateCost As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repBool As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents repAmt As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MedHisImgView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repBtnEditBrowse As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn

End Class
