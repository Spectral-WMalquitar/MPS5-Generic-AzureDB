<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appraisal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Appraisal))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.xheader = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.AppraisalGrid = New DevExpress.XtraGrid.GridControl()
        Me.AppraisalView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.glcmPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmFKeyIDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmFKeyActivity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmService = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepMemoService = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.glcmAppraisalDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmOverallScore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmOccasionForReport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmReemployed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmPromotion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmSailAgain = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmMasterName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmChiefOfficerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmStrength = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmWeakneses = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmOfficerComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmOfficerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCommentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCommentFromOffice1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmShipFleetManager = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmCommentFromOffice2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmSafetyOperationsManager = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmReemploy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmPromote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmPromoteReemployWhen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmAdditionalRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmTrainingRequirements = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmOverallAssessment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmIsEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glcmGrade = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepServices = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tmrResetClickCounter = New System.Windows.Forms.Timer()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        Me.xheader.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.AppraisalGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppraisalView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepMemoService, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepServices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.xheader)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(860, 547)
        Me.header.TabIndex = 52
        Me.header.Text = "Crew Appraisals"
        '
        'xheader
        '
        Me.xheader.Controls.Add(Me.LayoutControl1)
        Me.xheader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xheader.Location = New System.Drawing.Point(2, 24)
        Me.xheader.Name = "xheader"
        Me.xheader.Size = New System.Drawing.Size(856, 521)
        Me.xheader.TabIndex = 48
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.AppraisalGrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(584, 309, 391, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(856, 521)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'AppraisalGrid
        '
        GridLevelNode1.RelationName = "Level1"
        Me.AppraisalGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.AppraisalGrid.Location = New System.Drawing.Point(25, 44)
        Me.AppraisalGrid.MainView = Me.AppraisalView
        Me.AppraisalGrid.Name = "AppraisalGrid"
        Me.AppraisalGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepServices, Me.RepMemoService})
        Me.AppraisalGrid.Size = New System.Drawing.Size(806, 452)
        Me.AppraisalGrid.TabIndex = 10
        Me.AppraisalGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AppraisalView})
        '
        'AppraisalView
        '
        Me.AppraisalView.Appearance.FocusedCell.Options.UseTextOptions = True
        Me.AppraisalView.Appearance.FocusedCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.AppraisalView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.AppraisalView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AppraisalView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.AppraisalView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AppraisalView.Appearance.Row.Options.UseTextOptions = True
        Me.AppraisalView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AppraisalView.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.AppraisalView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.AppraisalView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.AppraisalView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.AppraisalView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AppraisalView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.AppraisalView.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.AppraisalView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.AppraisalView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.glcmPKey, Me.glcmFKeyIDNbr, Me.glcmFKeyActivity, Me.glcmService, Me.glcmAppraisalDate, Me.glcmOverallScore, Me.glcmOccasionForReport, Me.glcmReemployed, Me.glcmPromotion, Me.glcmSailAgain, Me.glcmRemarks, Me.glcmMasterName, Me.glcmChiefOfficerName, Me.glcmStrength, Me.glcmWeakneses, Me.glcmOfficerComment, Me.glcmOfficerName, Me.glcmCommentDate, Me.glcmCommentFromOffice1, Me.glcmShipFleetManager, Me.glcmCommentFromOffice2, Me.glcmSafetyOperationsManager, Me.glcmReemploy, Me.glcmPromote, Me.glcmPromoteReemployWhen, Me.glcmAdditionalRemarks, Me.glcmTrainingRequirements, Me.glcmOverallAssessment, Me.glcmIsEdited, Me.glcmGrade})
        Me.AppraisalView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.AppraisalView.GridControl = Me.AppraisalGrid
        Me.AppraisalView.Name = "AppraisalView"
        Me.AppraisalView.NewItemRowText = "Click here to add new Appraisal"
        Me.AppraisalView.OptionsBehavior.AutoPopulateColumns = False
        Me.AppraisalView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.AppraisalView.OptionsCustomization.AllowFilter = False
        Me.AppraisalView.OptionsCustomization.AllowGroup = False
        Me.AppraisalView.OptionsCustomization.AllowQuickHideColumns = False
        Me.AppraisalView.OptionsCustomization.AllowSort = False
        Me.AppraisalView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.AppraisalView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.AppraisalView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.AppraisalView.OptionsFind.AllowFindPanel = False
        Me.AppraisalView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.AppraisalView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.AppraisalView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.AppraisalView.OptionsSelection.UseIndicatorForSelection = False
        Me.AppraisalView.OptionsView.ColumnAutoWidth = False
        Me.AppraisalView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.AppraisalView.OptionsView.RowAutoHeight = True
        Me.AppraisalView.OptionsView.ShowGroupPanel = False
        Me.AppraisalView.ViewCaption = " Other Information"
        '
        'glcmPKey
        '
        Me.glcmPKey.Caption = "AppraisalPKey"
        Me.glcmPKey.FieldName = "PKey"
        Me.glcmPKey.Name = "glcmPKey"
        Me.glcmPKey.OptionsColumn.AllowEdit = False
        Me.glcmPKey.Width = 86
        '
        'glcmFKeyIDNbr
        '
        Me.glcmFKeyIDNbr.Caption = "FKeyIDNbr"
        Me.glcmFKeyIDNbr.FieldName = "FKeyIDNbr"
        Me.glcmFKeyIDNbr.Name = "glcmFKeyIDNbr"
        '
        'glcmFKeyActivity
        '
        Me.glcmFKeyActivity.Caption = "FKeyActivity"
        Me.glcmFKeyActivity.FieldName = "FKeyActivity"
        Me.glcmFKeyActivity.Name = "glcmFKeyActivity"
        Me.glcmFKeyActivity.OptionsColumn.AllowEdit = False
        '
        'glcmService
        '
        Me.glcmService.Caption = "Service"
        Me.glcmService.ColumnEdit = Me.RepMemoService
        Me.glcmService.FieldName = "Service"
        Me.glcmService.Name = "glcmService"
        Me.glcmService.OptionsColumn.AllowEdit = False
        Me.glcmService.Visible = True
        Me.glcmService.VisibleIndex = 0
        Me.glcmService.Width = 388
        '
        'RepMemoService
        '
        Me.RepMemoService.Name = "RepMemoService"
        '
        'glcmAppraisalDate
        '
        Me.glcmAppraisalDate.Caption = "Appraisal Date"
        Me.glcmAppraisalDate.DisplayFormat.FormatString = """c2"""
        Me.glcmAppraisalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.glcmAppraisalDate.FieldName = "AppraisalDate"
        Me.glcmAppraisalDate.Name = "glcmAppraisalDate"
        Me.glcmAppraisalDate.OptionsColumn.AllowEdit = False
        Me.glcmAppraisalDate.Visible = True
        Me.glcmAppraisalDate.VisibleIndex = 1
        Me.glcmAppraisalDate.Width = 147
        '
        'glcmOverallScore
        '
        Me.glcmOverallScore.Caption = "Overall Score"
        Me.glcmOverallScore.FieldName = "OverallScore"
        Me.glcmOverallScore.Name = "glcmOverallScore"
        Me.glcmOverallScore.OptionsColumn.AllowEdit = False
        Me.glcmOverallScore.Visible = True
        Me.glcmOverallScore.VisibleIndex = 3
        Me.glcmOverallScore.Width = 94
        '
        'glcmOccasionForReport
        '
        Me.glcmOccasionForReport.Caption = "OccasionForReport"
        Me.glcmOccasionForReport.FieldName = "OccasionForReport"
        Me.glcmOccasionForReport.Name = "glcmOccasionForReport"
        '
        'glcmReemployed
        '
        Me.glcmReemployed.Caption = "Reemployed"
        Me.glcmReemployed.FieldName = "Reemployed"
        Me.glcmReemployed.Name = "glcmReemployed"
        '
        'glcmPromotion
        '
        Me.glcmPromotion.Caption = "Promotion"
        Me.glcmPromotion.FieldName = "Promotion"
        Me.glcmPromotion.Name = "glcmPromotion"
        '
        'glcmSailAgain
        '
        Me.glcmSailAgain.Caption = "SailAgain"
        Me.glcmSailAgain.FieldName = "SailAgain"
        Me.glcmSailAgain.Name = "glcmSailAgain"
        '
        'glcmRemarks
        '
        Me.glcmRemarks.Caption = "Remarks"
        Me.glcmRemarks.FieldName = "Remarks"
        Me.glcmRemarks.Name = "glcmRemarks"
        '
        'glcmMasterName
        '
        Me.glcmMasterName.Caption = "MasterName"
        Me.glcmMasterName.FieldName = "MasterName"
        Me.glcmMasterName.Name = "glcmMasterName"
        '
        'glcmChiefOfficerName
        '
        Me.glcmChiefOfficerName.Caption = "ChiefOfficerName"
        Me.glcmChiefOfficerName.FieldName = "ChiefOfficerName"
        Me.glcmChiefOfficerName.Name = "glcmChiefOfficerName"
        '
        'glcmStrength
        '
        Me.glcmStrength.Caption = "Strength"
        Me.glcmStrength.FieldName = "Strength"
        Me.glcmStrength.Name = "glcmStrength"
        '
        'glcmWeakneses
        '
        Me.glcmWeakneses.Caption = "Weakneses"
        Me.glcmWeakneses.FieldName = "Weakneses"
        Me.glcmWeakneses.Name = "glcmWeakneses"
        '
        'glcmOfficerComment
        '
        Me.glcmOfficerComment.Caption = "OfficerComment"
        Me.glcmOfficerComment.FieldName = "OfficerComment"
        Me.glcmOfficerComment.Name = "glcmOfficerComment"
        '
        'glcmOfficerName
        '
        Me.glcmOfficerName.Caption = "OfficerName"
        Me.glcmOfficerName.FieldName = "OfficerName"
        Me.glcmOfficerName.Name = "glcmOfficerName"
        '
        'glcmCommentDate
        '
        Me.glcmCommentDate.Caption = "CommentDate"
        Me.glcmCommentDate.FieldName = "CommentDate"
        Me.glcmCommentDate.Name = "glcmCommentDate"
        '
        'glcmCommentFromOffice1
        '
        Me.glcmCommentFromOffice1.Caption = "CommentFromOffice1"
        Me.glcmCommentFromOffice1.FieldName = "CommentFromOffice1"
        Me.glcmCommentFromOffice1.Name = "glcmCommentFromOffice1"
        '
        'glcmShipFleetManager
        '
        Me.glcmShipFleetManager.Caption = "ShipFleetManager"
        Me.glcmShipFleetManager.FieldName = "ShipFleetManager"
        Me.glcmShipFleetManager.Name = "glcmShipFleetManager"
        '
        'glcmCommentFromOffice2
        '
        Me.glcmCommentFromOffice2.Caption = "CommentFromOffice2"
        Me.glcmCommentFromOffice2.FieldName = "CommentFromOffice2"
        Me.glcmCommentFromOffice2.Name = "glcmCommentFromOffice2"
        '
        'glcmSafetyOperationsManager
        '
        Me.glcmSafetyOperationsManager.Caption = "SafetyOperationsManager"
        Me.glcmSafetyOperationsManager.FieldName = "SafetyOperationsManager"
        Me.glcmSafetyOperationsManager.Name = "glcmSafetyOperationsManager"
        '
        'glcmReemploy
        '
        Me.glcmReemploy.Caption = "Reemploy"
        Me.glcmReemploy.FieldName = "Reemploy"
        Me.glcmReemploy.Name = "glcmReemploy"
        '
        'glcmPromote
        '
        Me.glcmPromote.Caption = "Promote"
        Me.glcmPromote.FieldName = "Promote"
        Me.glcmPromote.Name = "glcmPromote"
        '
        'glcmPromoteReemployWhen
        '
        Me.glcmPromoteReemployWhen.Caption = "PromoteReemployWhen"
        Me.glcmPromoteReemployWhen.FieldName = "PromoteReemployWhen"
        Me.glcmPromoteReemployWhen.Name = "glcmPromoteReemployWhen"
        '
        'glcmAdditionalRemarks
        '
        Me.glcmAdditionalRemarks.Caption = "AdditionalRemarks"
        Me.glcmAdditionalRemarks.FieldName = "AdditionalRemarks"
        Me.glcmAdditionalRemarks.Name = "glcmAdditionalRemarks"
        '
        'glcmTrainingRequirements
        '
        Me.glcmTrainingRequirements.Caption = "TrainingRequirements"
        Me.glcmTrainingRequirements.FieldName = "TrainingRequirements"
        Me.glcmTrainingRequirements.Name = "glcmTrainingRequirements"
        '
        'glcmOverallAssessment
        '
        Me.glcmOverallAssessment.Caption = "Overall Assessment"
        Me.glcmOverallAssessment.FieldName = "OverallAssessment"
        Me.glcmOverallAssessment.Name = "glcmOverallAssessment"
        Me.glcmOverallAssessment.OptionsColumn.AllowEdit = False
        Me.glcmOverallAssessment.Visible = True
        Me.glcmOverallAssessment.VisibleIndex = 2
        Me.glcmOverallAssessment.Width = 246
        '
        'glcmIsEdited
        '
        Me.glcmIsEdited.Caption = "IsEdited"
        Me.glcmIsEdited.FieldName = "IsEdited"
        Me.glcmIsEdited.Name = "glcmIsEdited"
        Me.glcmIsEdited.OptionsColumn.AllowEdit = False
        '
        'glcmGrade
        '
        Me.glcmGrade.Caption = "Grade"
        Me.glcmGrade.FieldName = "Grade"
        Me.glcmGrade.Name = "glcmGrade"
        Me.glcmGrade.Visible = True
        Me.glcmGrade.VisibleIndex = 4
        Me.glcmGrade.Width = 85
        '
        'RepServices
        '
        Me.RepServices.AutoHeight = False
        Me.RepServices.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepServices.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FKeyActivity", "PKey"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.RepServices.DisplayMember = "Name"
        Me.RepServices.Name = "RepServices"
        Me.RepServices.NullText = ""
        Me.RepServices.ValueMember = "FKeyActivity"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(856, 521)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "Relatives"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(816, 481)
        Me.LayoutControlGroup3.Text = "Appraisals"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.AppraisalGrid
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(810, 456)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'tmrResetClickCounter
        '
        Me.tmrResetClickCounter.Enabled = True
        Me.tmrResetClickCounter.Interval = 1000
        '
        'Appraisal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "Appraisal"
        Me.Size = New System.Drawing.Size(860, 547)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.xheader.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.AppraisalGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppraisalView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepMemoService, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepServices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents xheader As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AppraisalGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents AppraisalView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents glcmPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmService As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmAppraisalDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmOverallAssessment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmOverallScore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmFKeyActivity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepServices As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents glcmFKeyIDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmOccasionForReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmReemployed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmPromotion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmSailAgain As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmMasterName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmChiefOfficerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmStrength As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmWeakneses As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmOfficerComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmOfficerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCommentDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCommentFromOffice1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmShipFleetManager As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmCommentFromOffice2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmSafetyOperationsManager As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmReemploy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmPromote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmPromoteReemployWhen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmAdditionalRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmTrainingRequirements As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glcmIsEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tmrResetClickCounter As System.Windows.Forms.Timer
    Friend WithEvents glcmGrade As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepMemoService As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

End Class
