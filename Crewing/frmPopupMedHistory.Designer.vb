<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopupMedHistory
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPopupMedHistory))
        Me.MedHistoryGrid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmFKeyActivityId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmFKeyIDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmMedHistPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmWorkRel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmDateAcquired = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmPlace = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmFKeyVessel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepCertVsl = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.glcmPICase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmPICaseRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmFKeyMedStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepMedStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.glcmDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmDateUpdated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmLastUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SigningOffCrewsGrid = New DevExpress.XtraGrid.GridControl()
        Me.CrewGrid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmActGrpID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabControl = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.tabMainGrid = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.MedHistoryGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepCertVsl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepMedStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SigningOffCrewsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabMainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MedHistoryGrid
        '
        Me.MedHistoryGrid.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmFKeyActivityId, Me.glcmFKeyIDNbr, Me.glcmMedHistPKey, Me.glcmWorkRel, Me.glcmDiagnosis, Me.glcmDateAcquired, Me.glcmPlace, Me.glcmFKeyVessel, Me.glcmPICase, Me.glcmPICaseRefNo, Me.glcmFKeyMedStatus, Me.glcmDate, Me.glcmRemarks, Me.glcmDateUpdated, Me.glcmLastUpdatedBy, Me.glcmEdited})
        Me.MedHistoryGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.MedHistoryGrid.GridControl = Me.SigningOffCrewsGrid
        Me.MedHistoryGrid.Name = "MedHistoryGrid"
        Me.MedHistoryGrid.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.MedHistoryGrid.OptionsDetail.AllowOnlyOneMasterRowExpanded = True
        Me.MedHistoryGrid.OptionsView.ColumnAutoWidth = False
        Me.MedHistoryGrid.OptionsView.ShowGroupPanel = False
        '
        'glcmFKeyActivityId
        '
        Me.glcmFKeyActivityId.FieldName = "FKeyActivityID"
        Me.glcmFKeyActivityId.Name = "glcmFKeyActivityId"
        '
        'glcmFKeyIDNbr
        '
        Me.glcmFKeyIDNbr.FieldName = "FKeyIDNbr"
        Me.glcmFKeyIDNbr.Name = "glcmFKeyIDNbr"
        Me.glcmFKeyIDNbr.Width = 70
        '
        'glcmMedHistPKey
        '
        Me.glcmMedHistPKey.FieldName = "PKey"
        Me.glcmMedHistPKey.Name = "glcmMedHistPKey"
        '
        'glcmWorkRel
        '
        Me.glcmWorkRel.Caption = "Work Related?"
        Me.glcmWorkRel.FieldName = "WorkRel"
        Me.glcmWorkRel.Name = "glcmWorkRel"
        Me.glcmWorkRel.Visible = True
        Me.glcmWorkRel.VisibleIndex = 0
        Me.glcmWorkRel.Width = 99
        '
        'glcmDiagnosis
        '
        Me.glcmDiagnosis.Caption = "Diagnosis"
        Me.glcmDiagnosis.FieldName = "Diagnosis"
        Me.glcmDiagnosis.Name = "glcmDiagnosis"
        Me.glcmDiagnosis.Visible = True
        Me.glcmDiagnosis.VisibleIndex = 1
        Me.glcmDiagnosis.Width = 82
        '
        'glcmDateAcquired
        '
        Me.glcmDateAcquired.Caption = "Date Acquired"
        Me.glcmDateAcquired.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.glcmDateAcquired.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.glcmDateAcquired.FieldName = "DateAcq"
        Me.glcmDateAcquired.Name = "glcmDateAcquired"
        Me.glcmDateAcquired.Visible = True
        Me.glcmDateAcquired.VisibleIndex = 2
        Me.glcmDateAcquired.Width = 95
        '
        'glcmPlace
        '
        Me.glcmPlace.Caption = "Place"
        Me.glcmPlace.FieldName = "PlaceAcq"
        Me.glcmPlace.Name = "glcmPlace"
        Me.glcmPlace.Visible = True
        Me.glcmPlace.VisibleIndex = 5
        Me.glcmPlace.Width = 92
        '
        'glcmFKeyVessel
        '
        Me.glcmFKeyVessel.Caption = "Vessel"
        Me.glcmFKeyVessel.ColumnEdit = Me.RepCertVsl
        Me.glcmFKeyVessel.FieldName = "FKeyVessel"
        Me.glcmFKeyVessel.Name = "glcmFKeyVessel"
        Me.glcmFKeyVessel.Visible = True
        Me.glcmFKeyVessel.VisibleIndex = 4
        Me.glcmFKeyVessel.Width = 116
        '
        'RepCertVsl
        '
        Me.RepCertVsl.AutoHeight = False
        Me.RepCertVsl.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepCertVsl.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RepCertVsl.DisplayMember = "Name"
        Me.RepCertVsl.MaxLength = 10
        Me.RepCertVsl.Name = "RepCertVsl"
        Me.RepCertVsl.NullText = " "
        Me.RepCertVsl.ShowFooter = False
        Me.RepCertVsl.ValueMember = "PKey"
        '
        'glcmPICase
        '
        Me.glcmPICase.Caption = "Is P&I Case?"
        Me.glcmPICase.FieldName = "IsPICase"
        Me.glcmPICase.Name = "glcmPICase"
        Me.glcmPICase.Visible = True
        Me.glcmPICase.VisibleIndex = 6
        '
        'glcmPICaseRefNo
        '
        Me.glcmPICaseRefNo.Caption = "P&I Case Ref. No."
        Me.glcmPICaseRefNo.FieldName = "PICaseRefNo"
        Me.glcmPICaseRefNo.Name = "glcmPICaseRefNo"
        Me.glcmPICaseRefNo.Visible = True
        Me.glcmPICaseRefNo.VisibleIndex = 7
        Me.glcmPICaseRefNo.Width = 98
        '
        'glcmFKeyMedStatus
        '
        Me.glcmFKeyMedStatus.Caption = "Status"
        Me.glcmFKeyMedStatus.ColumnEdit = Me.RepMedStatus
        Me.glcmFKeyMedStatus.FieldName = "FKeyMedStatus"
        Me.glcmFKeyMedStatus.Name = "glcmFKeyMedStatus"
        Me.glcmFKeyMedStatus.Visible = True
        Me.glcmFKeyMedStatus.VisibleIndex = 3
        Me.glcmFKeyMedStatus.Width = 91
        '
        'RepMedStatus
        '
        Me.RepMedStatus.AutoHeight = False
        Me.RepMedStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepMedStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RepMedStatus.DisplayMember = "Name"
        Me.RepMedStatus.DropDownRows = 10
        Me.RepMedStatus.Name = "RepMedStatus"
        Me.RepMedStatus.NullText = " "
        Me.RepMedStatus.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple
        Me.RepMedStatus.ShowFooter = False
        Me.RepMedStatus.ValueMember = "PKey"
        '
        'glcmDate
        '
        Me.glcmDate.Caption = "Last Status Date"
        Me.glcmDate.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.glcmDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.glcmDate.FieldName = "DateStatus"
        Me.glcmDate.Name = "glcmDate"
        Me.glcmDate.Visible = True
        Me.glcmDate.VisibleIndex = 8
        '
        'glcmRemarks
        '
        Me.glcmRemarks.Caption = "Remarks"
        Me.glcmRemarks.FieldName = "Remarks"
        Me.glcmRemarks.Name = "glcmRemarks"
        Me.glcmRemarks.Visible = True
        Me.glcmRemarks.VisibleIndex = 9
        Me.glcmRemarks.Width = 178
        '
        'glcmDateUpdated
        '
        Me.glcmDateUpdated.FieldName = "DateUpdated"
        Me.glcmDateUpdated.Name = "glcmDateUpdated"
        '
        'glcmLastUpdatedBy
        '
        Me.glcmLastUpdatedBy.FieldName = "LastUpdatedBy"
        Me.glcmLastUpdatedBy.Name = "glcmLastUpdatedBy"
        '
        'glcmEdited
        '
        Me.glcmEdited.Caption = "Edited"
        Me.glcmEdited.FieldName = "Edited"
        Me.glcmEdited.Name = "glcmEdited"
        '
        'SigningOffCrewsGrid
        '
        GridLevelNode1.LevelTemplate = Me.MedHistoryGrid
        GridLevelNode1.RelationName = "Level1"
        Me.SigningOffCrewsGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.SigningOffCrewsGrid.Location = New System.Drawing.Point(24, 49)
        Me.SigningOffCrewsGrid.MainView = Me.CrewGrid
        Me.SigningOffCrewsGrid.Name = "SigningOffCrewsGrid"
        Me.SigningOffCrewsGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepCertVsl, Me.RepMedStatus})
        Me.SigningOffCrewsGrid.Size = New System.Drawing.Size(1308, 505)
        Me.SigningOffCrewsGrid.TabIndex = 2
        Me.SigningOffCrewsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CrewGrid, Me.MedHistoryGrid})
        '
        'CrewGrid
        '
        Me.CrewGrid.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CrewGrid.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewGrid.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CrewGrid.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewGrid.Appearance.Row.Options.UseTextOptions = True
        Me.CrewGrid.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewGrid.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CrewGrid.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CrewGrid.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CrewGrid.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CrewGrid.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CrewGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CrewGrid.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmPKey, Me.glcmCrewName, Me.glcmRank, Me.glcmActID, Me.glcmActGrpID})
        Me.CrewGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.CrewGrid.GridControl = Me.SigningOffCrewsGrid
        Me.CrewGrid.Name = "CrewGrid"
        Me.CrewGrid.NewItemRowText = "Click here to add new Record"
        Me.CrewGrid.OptionsBehavior.AutoPopulateColumns = False
        Me.CrewGrid.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CrewGrid.OptionsCustomization.AllowFilter = False
        Me.CrewGrid.OptionsCustomization.AllowGroup = False
        Me.CrewGrid.OptionsCustomization.AllowQuickHideColumns = False
        Me.CrewGrid.OptionsCustomization.AllowSort = False
        Me.CrewGrid.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.CrewGrid.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[True]
        Me.CrewGrid.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[True]
        Me.CrewGrid.OptionsFind.AllowFindPanel = False
        Me.CrewGrid.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CrewGrid.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CrewGrid.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CrewGrid.OptionsSelection.UseIndicatorForSelection = False
        Me.CrewGrid.OptionsView.ColumnAutoWidth = False
        Me.CrewGrid.OptionsView.RowAutoHeight = True
        Me.CrewGrid.OptionsView.ShowChildrenInGroupPanel = True
        Me.CrewGrid.OptionsView.ShowGroupPanel = False
        Me.CrewGrid.ViewCaption = " Other Information"
        '
        'glcmPKey
        '
        Me.glcmPKey.Caption = "PKey"
        Me.glcmPKey.FieldName = "PKey"
        Me.glcmPKey.Name = "glcmPKey"
        Me.glcmPKey.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.glcmPKey.Width = 212
        '
        'glcmCrewName
        '
        Me.glcmCrewName.Caption = "Crew Name"
        Me.glcmCrewName.FieldName = "CrewName"
        Me.glcmCrewName.Name = "glcmCrewName"
        Me.glcmCrewName.Visible = True
        Me.glcmCrewName.VisibleIndex = 0
        Me.glcmCrewName.Width = 549
        '
        'glcmRank
        '
        Me.glcmRank.Caption = "Rank"
        Me.glcmRank.FieldName = "RankName"
        Me.glcmRank.Name = "glcmRank"
        Me.glcmRank.Visible = True
        Me.glcmRank.VisibleIndex = 1
        Me.glcmRank.Width = 443
        '
        'glcmActID
        '
        Me.glcmActID.FieldName = "CurrActID"
        Me.glcmActID.Name = "glcmActID"
        '
        'glcmActGrpID
        '
        Me.glcmActGrpID.FieldName = "ActGrpID"
        Me.glcmActGrpID.Name = "glcmActGrpID"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.btnSave)
        Me.LayoutControl1.Controls.Add(Me.btnCancel)
        Me.LayoutControl1.Controls.Add(Me.SigningOffCrewsGrid)
        Me.LayoutControl1.Location = New System.Drawing.Point(0, -9)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1356, 681)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.DarkRed
        Me.LabelControl1.Location = New System.Drawing.Point(12, 655)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(307, 14)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "* Press 'Delete' key to remove selected Medical History."
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(1126, 570)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 81)
        Me.btnSave.TabIndex = 3
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(1239, 570)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 81)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabControl, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1356, 681)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'TabControl
        '
        Me.TabControl.CustomizationFormText = "TabControl"
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedTabPage = Me.tabMainGrid
        Me.TabControl.SelectedTabPageIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1336, 558)
        Me.TabControl.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.tabMainGrid})
        '
        'tabMainGrid
        '
        Me.tabMainGrid.CustomizationFormText = "Training"
        Me.tabMainGrid.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.tabMainGrid.Location = New System.Drawing.Point(0, 0)
        Me.tabMainGrid.Name = "tabMainGrid"
        Me.tabMainGrid.Size = New System.Drawing.Size(1312, 509)
        Me.tabMainGrid.Text = "Crews"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SigningOffCrewsGrid
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1312, 509)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 558)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1114, 85)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnCancel
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1227, 558)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(109, 85)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnSave
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1114, 558)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(113, 85)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.LabelControl1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 643)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1336, 18)
        Me.LayoutControlItem4.Text = "* Press 'Delete' key to remove selected Medical History"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'frmPopupMedHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1345, 663)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPopupMedHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Medical History"
        CType(Me.MedHistoryGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepCertVsl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepMedStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SigningOffCrewsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabMainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SigningOffCrewsGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MedHistoryGrid As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents glcmFKeyActivityId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmFKeyIDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmMedHistPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmWorkRel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDateAcquired As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmPlace As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmFKeyVessel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmPICase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmPICaseRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmFKeyMedStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmDateUpdated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmLastUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrewGrid As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents glcmPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabControl As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents tabMainGrid As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepCertVsl As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents glcmActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmActGrpID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepMedStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
