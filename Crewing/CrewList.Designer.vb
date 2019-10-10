<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrewList
    Inherits BaseControl.BaseList

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrewList))
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colLName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colMName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVslName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colStatName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRankName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRankCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPlaceSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colStatCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repStatCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateSOff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCrewMonthsAshore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colIncludeInArchive = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colActGrpID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCurrActID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPromFrom = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTransFrom = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRankSortCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colNat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bgclFKeyRankCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ActDateStart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.rightClickMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.TravInfo = New DevExpress.XtraBars.BarButtonItem()
        Me.RecordSum = New DevExpress.XtraBars.BarButtonItem()
        Me.Biodata = New DevExpress.XtraBars.BarButtonItem()
        Me.Document = New DevExpress.XtraBars.BarButtonItem()
        Me.Training = New DevExpress.XtraBars.BarButtonItem()
        Me.MedicalHis = New DevExpress.XtraBars.BarButtonItem()
        Me.Service = New DevExpress.XtraBars.BarButtonItem()
        Me.Relative = New DevExpress.XtraBars.BarButtonItem()
        Me.Appraisal = New DevExpress.XtraBars.BarButtonItem()
        Me.AddComment = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintBio = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintPOEAContract = New DevExpress.XtraBars.BarButtonItem()
        Me.LTPCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.ViewAct = New DevExpress.XtraBars.BarButtonItem()
        Me.ViewExpDocs = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.XpServerCollectionSource1 = New DevExpress.Xpo.XPServerCollectionSource(Me.components)
        Me.fpMain = New DevExpress.Utils.FlyoutPanel()
        Me.fpControl = New DevExpress.Utils.FlyoutPanelControl()
        Me.lcMain = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdCopyToClip = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSBExpiry = New DevExpress.XtraEditors.TextEdit()
        Me.txtSBIssue = New DevExpress.XtraEditors.TextEdit()
        Me.txtSBNum = New DevExpress.XtraEditors.TextEdit()
        Me.txtPPPlace = New DevExpress.XtraEditors.TextEdit()
        Me.txtPPExpiry = New DevExpress.XtraEditors.TextEdit()
        Me.txtPPIssue = New DevExpress.XtraEditors.TextEdit()
        Me.txtPPNum = New DevExpress.XtraEditors.TextEdit()
        Me.txtPOB = New DevExpress.XtraEditors.TextEdit()
        Me.txtDOB = New DevExpress.XtraEditors.TextEdit()
        Me.txtNat = New DevExpress.XtraEditors.TextEdit()
        Me.txtRank = New DevExpress.XtraEditors.TextEdit()
        Me.txtCrew = New DevExpress.XtraEditors.TextEdit()
        Me.txtCOIDNo = New DevExpress.XtraEditors.TextEdit()
        Me.lcgSub = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repStatCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpServerCollectionSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fpMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fpMain.SuspendLayout()
        CType(Me.fpControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fpControl.SuspendLayout()
        CType(Me.lcMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lcMain.SuspendLayout()
        CType(Me.txtSBExpiry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSBIssue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSBNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPExpiry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPIssue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCrew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCOIDNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgSub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.AllowDrop = True
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repStatCode})
        Me.MainGrid.Size = New System.Drawing.Size(769, 476)
        Me.MainGrid.TabIndex = 4
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colLName, Me.colFName, Me.colMName, Me.colRankName, Me.colRankCode, Me.colPlaceSON, Me.colStatName, Me.colStatCode, Me.colActGrpID, Me.colCurrActID, Me.colVslName, Me.colPromFrom, Me.colTransFrom, Me.colRankSortCode, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.colIncludeInArchive, Me.BandedGridColumn5, Me.colDateSOff, Me.colCrewMonthsAshore, Me.colNat, Me.bgclFKeyRankCode, Me.ActDateStart})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsLayout.StoreDataSettings = False
        Me.MainView.OptionsPrint.AutoResetPrintDocument = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Columns.Add(Me.colLName)
        Me.GridBand1.Columns.Add(Me.colFName)
        Me.GridBand1.Columns.Add(Me.colMName)
        Me.GridBand1.Columns.Add(Me.colVslName)
        Me.GridBand1.Columns.Add(Me.colStatName)
        Me.GridBand1.Columns.Add(Me.colRankName)
        Me.GridBand1.Columns.Add(Me.colRankCode)
        Me.GridBand1.Columns.Add(Me.colPlaceSON)
        Me.GridBand1.Columns.Add(Me.colStatCode)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand1.Columns.Add(Me.colDateSOff)
        Me.GridBand1.Columns.Add(Me.colCrewMonthsAshore)
        Me.GridBand1.Columns.Add(Me.colIncludeInArchive)
        Me.GridBand1.Columns.Add(Me.colActGrpID)
        Me.GridBand1.Columns.Add(Me.colCurrActID)
        Me.GridBand1.Columns.Add(Me.colPromFrom)
        Me.GridBand1.Columns.Add(Me.colTransFrom)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.OptionsBand.FixedWidth = True
        Me.GridBand1.OptionsBand.ShowInCustomizationForm = False
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 868
        '
        'colPKey
        '
        Me.colPKey.Caption = "IDNbr"
        Me.colPKey.FieldName = "IDNbr"
        Me.colPKey.Name = "colPKey"
        '
        'colLName
        '
        Me.colLName.Caption = "Last Name"
        Me.colLName.FieldName = "LName"
        Me.colLName.Name = "colLName"
        Me.colLName.OptionsColumn.AllowEdit = False
        Me.colLName.Visible = True
        Me.colLName.Width = 115
        '
        'colFName
        '
        Me.colFName.Caption = "First Name"
        Me.colFName.FieldName = "FName"
        Me.colFName.Name = "colFName"
        Me.colFName.OptionsColumn.AllowEdit = False
        Me.colFName.Visible = True
        Me.colFName.Width = 117
        '
        'colMName
        '
        Me.colMName.Caption = "Middle Name"
        Me.colMName.FieldName = "MName"
        Me.colMName.Name = "colMName"
        Me.colMName.OptionsColumn.AllowEdit = False
        Me.colMName.Visible = True
        Me.colMName.Width = 96
        '
        'colVslName
        '
        Me.colVslName.Caption = "Vessel"
        Me.colVslName.FieldName = "VslName"
        Me.colVslName.Name = "colVslName"
        Me.colVslName.OptionsColumn.AllowEdit = False
        Me.colVslName.Visible = True
        Me.colVslName.Width = 92
        '
        'colStatName
        '
        Me.colStatName.Caption = "Status"
        Me.colStatName.FieldName = "StatName"
        Me.colStatName.Name = "colStatName"
        Me.colStatName.OptionsColumn.AllowEdit = False
        Me.colStatName.Visible = True
        Me.colStatName.Width = 136
        '
        'colRankName
        '
        Me.colRankName.Caption = "Rank"
        Me.colRankName.FieldName = "RankName"
        Me.colRankName.Name = "colRankName"
        Me.colRankName.OptionsColumn.AllowEdit = False
        Me.colRankName.Visible = True
        Me.colRankName.Width = 97
        '
        'colRankCode
        '
        Me.colRankCode.FieldName = "RankCode"
        Me.colRankCode.Name = "colRankCode"
        Me.colRankCode.OptionsColumn.AllowEdit = False
        '
        'colPlaceSON
        '
        Me.colPlaceSON.Caption = "Sign-on Place"
        Me.colPlaceSON.FieldName = "PlaceSON"
        Me.colPlaceSON.Name = "colPlaceSON"
        Me.colPlaceSON.OptionsColumn.AllowEdit = False
        '
        'colStatCode
        '
        Me.colStatCode.Caption = "Current Status"
        Me.colStatCode.ColumnEdit = Me.repStatCode
        Me.colStatCode.FieldName = "StatCode"
        Me.colStatCode.Name = "colStatCode"
        Me.colStatCode.OptionsColumn.AllowEdit = False
        Me.colStatCode.Width = 33
        '
        'repStatCode
        '
        Me.repStatCode.AutoHeight = False
        Me.repStatCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repStatCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repStatCode.DisplayMember = "Name"
        Me.repStatCode.Name = "repStatCode"
        Me.repStatCode.ShowFooter = False
        Me.repStatCode.ShowHeader = False
        Me.repStatCode.ValueMember = "PKey"
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Date Due"
        Me.BandedGridColumn5.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.BandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn5.FieldName = "DueDate"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 103
        '
        'colDateSOff
        '
        Me.colDateSOff.Caption = "Last Sign Off Date"
        Me.colDateSOff.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.colDateSOff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDateSOff.FieldName = "DateSOff"
        Me.colDateSOff.Name = "colDateSOff"
        Me.colDateSOff.OptionsColumn.AllowEdit = False
        Me.colDateSOff.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.colDateSOff.Visible = True
        Me.colDateSOff.Width = 112
        '
        'colCrewMonthsAshore
        '
        Me.colCrewMonthsAshore.Caption = "MonthsAshore"
        Me.colCrewMonthsAshore.FieldName = "MonthsAshore"
        Me.colCrewMonthsAshore.Name = "colCrewMonthsAshore"
        Me.colCrewMonthsAshore.Width = 126
        '
        'colIncludeInArchive
        '
        Me.colIncludeInArchive.Caption = "Include in Archive"
        Me.colIncludeInArchive.FieldName = "IsIncludeInArchive"
        Me.colIncludeInArchive.Name = "colIncludeInArchive"
        Me.colIncludeInArchive.Width = 150
        '
        'colActGrpID
        '
        Me.colActGrpID.FieldName = "ActGrpID"
        Me.colActGrpID.Name = "colActGrpID"
        Me.colActGrpID.OptionsColumn.AllowEdit = False
        '
        'colCurrActID
        '
        Me.colCurrActID.FieldName = "CurrActID"
        Me.colCurrActID.Name = "colCurrActID"
        Me.colCurrActID.OptionsColumn.AllowEdit = False
        '
        'colPromFrom
        '
        Me.colPromFrom.FieldName = "PromFrom"
        Me.colPromFrom.Name = "colPromFrom"
        Me.colPromFrom.OptionsColumn.AllowEdit = False
        '
        'colTransFrom
        '
        Me.colTransFrom.FieldName = "TransFrom"
        Me.colTransFrom.Name = "colTransFrom"
        Me.colTransFrom.OptionsColumn.AllowEdit = False
        '
        'colRankSortCode
        '
        Me.colRankSortCode.FieldName = "RankSortCode"
        Me.colRankSortCode.Name = "colRankSortCode"
        Me.colRankSortCode.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Company ID"
        Me.BandedGridColumn1.FieldName = "COIDNo"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "BandedGridColumn2"
        Me.BandedGridColumn2.FieldName = "hasExpDoc"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "FKeyWScaleRankCode"
        Me.BandedGridColumn3.FieldName = "FKeyWScaleRankCode"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn3.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "FkeyWScaleCode"
        Me.BandedGridColumn4.FieldName = "FkeyWScaleCode"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colNat
        '
        Me.colNat.Caption = "Nationality"
        Me.colNat.FieldName = "Nat"
        Me.colNat.Name = "colNat"
        Me.colNat.Visible = True
        '
        'bgclFKeyRankCode
        '
        Me.bgclFKeyRankCode.FieldName = "FKeyRankCode"
        Me.bgclFKeyRankCode.Name = "bgclFKeyRankCode"
        '
        'ActDateStart
        '
        Me.ActDateStart.Caption = "ActDateStart"
        Me.ActDateStart.FieldName = "ActDateStart"
        Me.ActDateStart.Name = "ActDateStart"
        '
        'rightClickMenu
        '
        Me.rightClickMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.TravInfo), New DevExpress.XtraBars.LinkPersistInfo(Me.RecordSum, True), New DevExpress.XtraBars.LinkPersistInfo(Me.Biodata), New DevExpress.XtraBars.LinkPersistInfo(Me.Document), New DevExpress.XtraBars.LinkPersistInfo(Me.Training), New DevExpress.XtraBars.LinkPersistInfo(Me.MedicalHis), New DevExpress.XtraBars.LinkPersistInfo(Me.Service), New DevExpress.XtraBars.LinkPersistInfo(Me.Relative), New DevExpress.XtraBars.LinkPersistInfo(Me.Appraisal), New DevExpress.XtraBars.LinkPersistInfo(Me.AddComment, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintBio), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintPOEAContract), New DevExpress.XtraBars.LinkPersistInfo(Me.LTPCopy), New DevExpress.XtraBars.LinkPersistInfo(Me.ViewAct, True), New DevExpress.XtraBars.LinkPersistInfo(Me.ViewExpDocs)})
        Me.rightClickMenu.Manager = Me.BarManager1
        Me.rightClickMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText
        Me.rightClickMenu.Name = "rightClickMenu"
        '
        'TravInfo
        '
        Me.TravInfo.Caption = "View Essential Info"
        Me.TravInfo.Glyph = CType(resources.GetObject("TravInfo.Glyph"), System.Drawing.Image)
        Me.TravInfo.Id = 26
        Me.TravInfo.LargeGlyph = CType(resources.GetObject("TravInfo.LargeGlyph"), System.Drawing.Image)
        Me.TravInfo.Name = "TravInfo"
        '
        'RecordSum
        '
        Me.RecordSum.Caption = "Record Summary"
        Me.RecordSum.Glyph = CType(resources.GetObject("RecordSum.Glyph"), System.Drawing.Image)
        Me.RecordSum.Id = 10
        Me.RecordSum.Name = "RecordSum"
        '
        'Biodata
        '
        Me.Biodata.Caption = "Biodata"
        Me.Biodata.Glyph = CType(resources.GetObject("Biodata.Glyph"), System.Drawing.Image)
        Me.Biodata.Id = 11
        Me.Biodata.Name = "Biodata"
        '
        'Document
        '
        Me.Document.Caption = "Documents"
        Me.Document.Glyph = CType(resources.GetObject("Document.Glyph"), System.Drawing.Image)
        Me.Document.Id = 12
        Me.Document.Name = "Document"
        '
        'Training
        '
        Me.Training.Caption = "Training"
        Me.Training.Glyph = CType(resources.GetObject("Training.Glyph"), System.Drawing.Image)
        Me.Training.Id = 18
        Me.Training.LargeGlyph = CType(resources.GetObject("Training.LargeGlyph"), System.Drawing.Image)
        Me.Training.Name = "Training"
        '
        'MedicalHis
        '
        Me.MedicalHis.Caption = "Medical History"
        Me.MedicalHis.Glyph = CType(resources.GetObject("MedicalHis.Glyph"), System.Drawing.Image)
        Me.MedicalHis.Id = 19
        Me.MedicalHis.Name = "MedicalHis"
        '
        'Service
        '
        Me.Service.Caption = "Service"
        Me.Service.Glyph = CType(resources.GetObject("Service.Glyph"), System.Drawing.Image)
        Me.Service.Id = 13
        Me.Service.Name = "Service"
        '
        'Relative
        '
        Me.Relative.Caption = "Relatives"
        Me.Relative.Glyph = CType(resources.GetObject("Relative.Glyph"), System.Drawing.Image)
        Me.Relative.Id = 14
        Me.Relative.Name = "Relative"
        '
        'Appraisal
        '
        Me.Appraisal.Caption = "Appraisals"
        Me.Appraisal.Glyph = CType(resources.GetObject("Appraisal.Glyph"), System.Drawing.Image)
        Me.Appraisal.Id = 15
        Me.Appraisal.Name = "Appraisal"
        '
        'AddComment
        '
        Me.AddComment.Caption = "View/Add Comments"
        Me.AddComment.Glyph = CType(resources.GetObject("AddComment.Glyph"), System.Drawing.Image)
        Me.AddComment.Id = 16
        Me.AddComment.Name = "AddComment"
        '
        'PrintBio
        '
        Me.PrintBio.Caption = "Print Biodata"
        Me.PrintBio.Glyph = CType(resources.GetObject("PrintBio.Glyph"), System.Drawing.Image)
        Me.PrintBio.Id = 17
        Me.PrintBio.Name = "PrintBio"
        '
        'PrintPOEAContract
        '
        Me.PrintPOEAContract.Caption = "Print POEA Contract"
        Me.PrintPOEAContract.Glyph = Global.Crewing.My.Resources.Resources.RightClick_PrintPOEA
        Me.PrintPOEAContract.Id = 27
        Me.PrintPOEAContract.Name = "PrintPOEAContract"
        '
        'LTPCopy
        '
        Me.LTPCopy.Caption = "Copy"
        Me.LTPCopy.Id = 22
        Me.LTPCopy.Name = "LTPCopy"
        '
        'ViewAct
        '
        Me.ViewAct.Caption = "View Activities"
        Me.ViewAct.Glyph = CType(resources.GetObject("ViewAct.Glyph"), System.Drawing.Image)
        Me.ViewAct.Id = 23
        Me.ViewAct.Name = "ViewAct"
        '
        'ViewExpDocs
        '
        Me.ViewExpDocs.Caption = "View Exp Docs"
        Me.ViewExpDocs.Glyph = Global.Crewing.My.Resources.Resources.expiringDocs_16x16
        Me.ViewExpDocs.Id = 25
        Me.ViewExpDocs.Name = "ViewExpDocs"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RecordSum, Me.Biodata, Me.Document, Me.Service, Me.Relative, Me.Appraisal, Me.AddComment, Me.PrintBio, Me.Training, Me.MedicalHis, Me.LTPCopy, Me.ViewAct, Me.BarButtonItem2, Me.ViewExpDocs, Me.TravInfo, Me.PrintPOEAContract})
        Me.BarManager1.MaxItemId = 28
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(769, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 476)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(769, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 476)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(769, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 476)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Id = 24
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'fpMain
        '
        Me.fpMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fpMain.Controls.Add(Me.fpControl)
        Me.fpMain.Location = New System.Drawing.Point(107, 43)
        Me.fpMain.Name = "fpMain"
        Me.fpMain.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual
        Me.fpMain.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade
        Me.fpMain.Options.CloseOnOuterClick = True
        Me.fpMain.OwnerControl = Me
        Me.fpMain.Size = New System.Drawing.Size(576, 386)
        Me.fpMain.TabIndex = 9
        '
        'fpControl
        '
        Me.fpControl.Controls.Add(Me.lcMain)
        Me.fpControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fpControl.FlyoutPanel = Me.fpMain
        Me.fpControl.Location = New System.Drawing.Point(0, 0)
        Me.fpControl.Margin = New System.Windows.Forms.Padding(10)
        Me.fpControl.Name = "fpControl"
        Me.fpControl.Padding = New System.Windows.Forms.Padding(10)
        Me.fpControl.Size = New System.Drawing.Size(574, 384)
        Me.fpControl.TabIndex = 0
        '
        'lcMain
        '
        Me.lcMain.Controls.Add(Me.cmdCopyToClip)
        Me.lcMain.Controls.Add(Me.cmdClose)
        Me.lcMain.Controls.Add(Me.txtSBExpiry)
        Me.lcMain.Controls.Add(Me.txtSBIssue)
        Me.lcMain.Controls.Add(Me.txtSBNum)
        Me.lcMain.Controls.Add(Me.txtPPPlace)
        Me.lcMain.Controls.Add(Me.txtPPExpiry)
        Me.lcMain.Controls.Add(Me.txtPPIssue)
        Me.lcMain.Controls.Add(Me.txtPPNum)
        Me.lcMain.Controls.Add(Me.txtPOB)
        Me.lcMain.Controls.Add(Me.txtDOB)
        Me.lcMain.Controls.Add(Me.txtNat)
        Me.lcMain.Controls.Add(Me.txtRank)
        Me.lcMain.Controls.Add(Me.txtCrew)
        Me.lcMain.Controls.Add(Me.txtCOIDNo)
        Me.lcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lcMain.Location = New System.Drawing.Point(10, 10)
        Me.lcMain.Name = "lcMain"
        Me.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(718, 239, 250, 350)
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcMain.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcMain.Root = Me.lcgSub
        Me.lcMain.Size = New System.Drawing.Size(554, 364)
        Me.lcMain.TabIndex = 0
        Me.lcMain.Text = "LayoutControl1"
        '
        'cmdCopyToClip
        '
        Me.cmdCopyToClip.Location = New System.Drawing.Point(278, 334)
        Me.cmdCopyToClip.Name = "cmdCopyToClip"
        Me.cmdCopyToClip.Size = New System.Drawing.Size(269, 23)
        Me.cmdCopyToClip.StyleController = Me.lcMain
        Me.cmdCopyToClip.TabIndex = 18
        Me.cmdCopyToClip.Text = "Copy to clipboard"
        '
        'cmdClose
        '
        Me.cmdClose.Appearance.ForeColor = System.Drawing.Color.Red
        Me.cmdClose.Appearance.Options.UseForeColor = True
        Me.cmdClose.Location = New System.Drawing.Point(7, 334)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(93, 23)
        Me.cmdClose.StyleController = Me.lcMain
        Me.cmdClose.TabIndex = 17
        Me.cmdClose.Text = "Close"
        '
        'txtSBExpiry
        '
        Me.txtSBExpiry.Location = New System.Drawing.Point(374, 268)
        Me.txtSBExpiry.MenuManager = Me.BarManager1
        Me.txtSBExpiry.Name = "txtSBExpiry"
        Me.txtSBExpiry.Properties.ReadOnly = True
        Me.txtSBExpiry.Size = New System.Drawing.Size(170, 22)
        Me.txtSBExpiry.StyleController = Me.lcMain
        Me.txtSBExpiry.TabIndex = 16
        '
        'txtSBIssue
        '
        Me.txtSBIssue.Location = New System.Drawing.Point(374, 242)
        Me.txtSBIssue.MenuManager = Me.BarManager1
        Me.txtSBIssue.Name = "txtSBIssue"
        Me.txtSBIssue.Properties.ReadOnly = True
        Me.txtSBIssue.Size = New System.Drawing.Size(170, 22)
        Me.txtSBIssue.StyleController = Me.lcMain
        Me.txtSBIssue.TabIndex = 15
        '
        'txtSBNum
        '
        Me.txtSBNum.Location = New System.Drawing.Point(374, 216)
        Me.txtSBNum.MenuManager = Me.BarManager1
        Me.txtSBNum.Name = "txtSBNum"
        Me.txtSBNum.Properties.ReadOnly = True
        Me.txtSBNum.Size = New System.Drawing.Size(170, 22)
        Me.txtSBNum.StyleController = Me.lcMain
        Me.txtSBNum.TabIndex = 14
        '
        'txtPPPlace
        '
        Me.txtPPPlace.Location = New System.Drawing.Point(97, 294)
        Me.txtPPPlace.MenuManager = Me.BarManager1
        Me.txtPPPlace.Name = "txtPPPlace"
        Me.txtPPPlace.Properties.ReadOnly = True
        Me.txtPPPlace.Size = New System.Drawing.Size(170, 22)
        Me.txtPPPlace.StyleController = Me.lcMain
        Me.txtPPPlace.TabIndex = 13
        '
        'txtPPExpiry
        '
        Me.txtPPExpiry.Location = New System.Drawing.Point(97, 268)
        Me.txtPPExpiry.MenuManager = Me.BarManager1
        Me.txtPPExpiry.Name = "txtPPExpiry"
        Me.txtPPExpiry.Properties.ReadOnly = True
        Me.txtPPExpiry.Size = New System.Drawing.Size(170, 22)
        Me.txtPPExpiry.StyleController = Me.lcMain
        Me.txtPPExpiry.TabIndex = 12
        '
        'txtPPIssue
        '
        Me.txtPPIssue.Location = New System.Drawing.Point(97, 242)
        Me.txtPPIssue.MenuManager = Me.BarManager1
        Me.txtPPIssue.Name = "txtPPIssue"
        Me.txtPPIssue.Properties.ReadOnly = True
        Me.txtPPIssue.Size = New System.Drawing.Size(170, 22)
        Me.txtPPIssue.StyleController = Me.lcMain
        Me.txtPPIssue.TabIndex = 11
        '
        'txtPPNum
        '
        Me.txtPPNum.Location = New System.Drawing.Point(97, 216)
        Me.txtPPNum.MenuManager = Me.BarManager1
        Me.txtPPNum.Name = "txtPPNum"
        Me.txtPPNum.Properties.ReadOnly = True
        Me.txtPPNum.Size = New System.Drawing.Size(170, 22)
        Me.txtPPNum.StyleController = Me.lcMain
        Me.txtPPNum.TabIndex = 10
        '
        'txtPOB
        '
        Me.txtPOB.Location = New System.Drawing.Point(97, 162)
        Me.txtPOB.MenuManager = Me.BarManager1
        Me.txtPOB.Name = "txtPOB"
        Me.txtPOB.Properties.ReadOnly = True
        Me.txtPOB.Size = New System.Drawing.Size(447, 22)
        Me.txtPOB.StyleController = Me.lcMain
        Me.txtPOB.TabIndex = 9
        '
        'txtDOB
        '
        Me.txtDOB.Location = New System.Drawing.Point(97, 136)
        Me.txtDOB.MenuManager = Me.BarManager1
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Properties.ReadOnly = True
        Me.txtDOB.Size = New System.Drawing.Size(447, 22)
        Me.txtDOB.StyleController = Me.lcMain
        Me.txtDOB.TabIndex = 8
        '
        'txtNat
        '
        Me.txtNat.Location = New System.Drawing.Point(97, 110)
        Me.txtNat.MenuManager = Me.BarManager1
        Me.txtNat.Name = "txtNat"
        Me.txtNat.Properties.ReadOnly = True
        Me.txtNat.Size = New System.Drawing.Size(447, 22)
        Me.txtNat.StyleController = Me.lcMain
        Me.txtNat.TabIndex = 7
        '
        'txtRank
        '
        Me.txtRank.Location = New System.Drawing.Point(97, 84)
        Me.txtRank.MenuManager = Me.BarManager1
        Me.txtRank.Name = "txtRank"
        Me.txtRank.Properties.ReadOnly = True
        Me.txtRank.Size = New System.Drawing.Size(447, 22)
        Me.txtRank.StyleController = Me.lcMain
        Me.txtRank.TabIndex = 6
        '
        'txtCrew
        '
        Me.txtCrew.Location = New System.Drawing.Point(97, 58)
        Me.txtCrew.MenuManager = Me.BarManager1
        Me.txtCrew.Name = "txtCrew"
        Me.txtCrew.Properties.ReadOnly = True
        Me.txtCrew.Size = New System.Drawing.Size(447, 22)
        Me.txtCrew.StyleController = Me.lcMain
        Me.txtCrew.TabIndex = 5
        '
        'txtCOIDNo
        '
        Me.txtCOIDNo.Location = New System.Drawing.Point(97, 32)
        Me.txtCOIDNo.MenuManager = Me.BarManager1
        Me.txtCOIDNo.Name = "txtCOIDNo"
        Me.txtCOIDNo.Properties.ReadOnly = True
        Me.txtCOIDNo.Size = New System.Drawing.Size(447, 22)
        Me.txtCOIDNo.StyleController = Me.lcMain
        Me.txtCOIDNo.TabIndex = 4
        '
        'lcgSub
        '
        Me.lcgSub.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.lcgSub.GroupBordersVisible = False
        Me.lcgSub.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlGroup3, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem14, Me.EmptySpaceItem3, Me.LayoutControlItem15})
        Me.lcgSub.Location = New System.Drawing.Point(0, 0)
        Me.lcgSub.Name = "Root"
        Me.lcgSub.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.lcgSub.Size = New System.Drawing.Size(554, 364)
        Me.lcgSub.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(544, 184)
        Me.LayoutControlGroup1.Text = "Crew Information"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtCOIDNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(538, 26)
        Me.LayoutControlItem1.Text = "Company ID :"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtCrew
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(538, 26)
        Me.LayoutControlItem2.Text = "Name :"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtRank
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(538, 26)
        Me.LayoutControlItem3.Text = "Rank :"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtNat
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(538, 26)
        Me.LayoutControlItem4.Text = "Nationality :"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtDOB
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(538, 26)
        Me.LayoutControlItem5.Text = "Date of Birth :"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtPOB
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(538, 26)
        Me.LayoutControlItem6.Text = "Place of Birth :"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 184)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(267, 132)
        Me.LayoutControlGroup2.Text = "Passport"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtPPNum
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem7.Text = "Number :"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtPPIssue
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem8.Text = "Date Issue :"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtPPExpiry
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem9.Text = "Date Expiry :"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtPPPlace
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem10.Text = "Place Issued :"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(277, 184)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(267, 132)
        Me.LayoutControlGroup3.Text = "Seaman's Book"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtSBNum
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem11.Text = "Number :"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtSBIssue
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem12.Text = "Date Issue :"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.txtSBExpiry
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(261, 52)
        Me.LayoutControlItem13.Text = "Date Expiry :"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(84, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(267, 184)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(10, 0)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(10, 132)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 316)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(544, 11)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.cmdClose
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 327)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(97, 27)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(97, 27)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(97, 27)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(97, 327)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(174, 27)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.cmdCopyToClip
        Me.LayoutControlItem15.Location = New System.Drawing.Point(271, 327)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(273, 27)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'CrewList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.fpMain)
        Me.Controls.Add(Me.MainGrid)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "CrewList"
        Me.Size = New System.Drawing.Size(769, 476)
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repStatCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpServerCollectionSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fpMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fpMain.ResumeLayout(False)
        CType(Me.fpControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fpControl.ResumeLayout(False)
        CType(Me.lcMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lcMain.ResumeLayout(False)
        CType(Me.txtSBExpiry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSBIssue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSBNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPExpiry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPIssue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCrew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCOIDNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgSub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colLName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colMName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRankCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPlaceSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colStatCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colActGrpID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCurrActID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPromFrom As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTransFrom As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVslName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colStatName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRankName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repStatCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colRankSortCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents rightClickMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents RecordSum As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Biodata As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Document As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Service As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Relative As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Appraisal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AddComment As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintBio As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Training As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MedicalHis As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colIncludeInArchive As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colDateSOff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCrewMonthsAshore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colNat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bgclFKeyRankCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LTPCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents XpServerCollectionSource1 As DevExpress.Xpo.XPServerCollectionSource
    Friend WithEvents ViewAct As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ViewExpDocs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ActDateStart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TravInfo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents fpMain As DevExpress.Utils.FlyoutPanel
    Friend WithEvents fpControl As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents lcMain As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents lcgSub As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtPOB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDOB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRank As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCrew As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCOIDNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtPPNum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPPIssue As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPPExpiry As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPPPlace As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSBNum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtSBExpiry As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSBIssue As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdCopyToClip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PrintPOEAContract As DevExpress.XtraBars.BarButtonItem

End Class
