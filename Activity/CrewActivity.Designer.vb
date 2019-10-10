<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrewActivity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrewActivity))
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.gbSOFF = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmSOFFCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSOFFReason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ReasonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSOFFDateSOFF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.genericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.clmSOFFPlaceSOFF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PortEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSOFFDateArr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSOFFPlaceArr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSOFFNxtAct = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.StatusEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSOFFNxtActDateStart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSOFFNxtActPlaceStart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSOFFNxtActPlaceEnd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSOFFReliever = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RelieveEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSOFFRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbSON = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmSONCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSONWScale = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WScaleEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSONSeniority = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONLOC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONLOCDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONAgent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AgentEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSONVsl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.VslEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmSONDateDep = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONPlaceDep = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTSONDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONPlaceSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONRelieve = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbGOBACK = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmGBCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmGBRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmGBStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbASHACT = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmASHACTCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmASHACTRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmASHACTNxtAct = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmASHACTDateStart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmASHACTPlaceStart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmASHACTPlaceEnd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmASHACTRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbTRANS = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmTCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTOldVsl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTDateSOFF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTPlaceSOFF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTVsl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONDateSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTPlaceSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmBlank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbPROM = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmPROMCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPROMOldRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPROMRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPROMWScale = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPROMDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPROMSeniority = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPROMRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbSICKONB = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmSONBCrew = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONBStat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONBDateStart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSONBDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmIDNbr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTBlank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmActDateStart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmActDateEnd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmCurrActID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmActGrpID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RelieveEditSON = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdlist = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblViewPlan = New DevExpress.XtraEditors.LabelControl()
        Me.sonWScale = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.sonAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.ashDateStart = New DevExpress.XtraEditors.DateEdit()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.transPlaceSON = New DevExpress.XtraEditors.LookUpEdit()
        Me.transPlaceSOFF = New DevExpress.XtraEditors.LookUpEdit()
        Me.transDateSOFF = New DevExpress.XtraEditors.DateEdit()
        Me.transDateSON = New DevExpress.XtraEditors.DateEdit()
        Me.transVsl = New DevExpress.XtraEditors.LookUpEdit()
        Me.ashNxtAct = New DevExpress.XtraEditors.LookUpEdit()
        Me.ashPlaceStart = New DevExpress.XtraEditors.LookUpEdit()
        Me.ashPlaceEnd = New DevExpress.XtraEditors.LookUpEdit()
        Me.soffDateSOFF = New DevExpress.XtraEditors.DateEdit()
        Me.soffPlaceSOFF = New DevExpress.XtraEditors.LookUpEdit()
        Me.soffReason = New DevExpress.XtraEditors.LookUpEdit()
        Me.sonVsl = New DevExpress.XtraEditors.LookUpEdit()
        Me.sonDateSON = New DevExpress.XtraEditors.DateEdit()
        Me.sonPlaceSON = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.grpSON = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.txtVessel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.grpTRANS = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.grpSOFF = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.grpASHACT = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.grpRemarks = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReasonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RelieveEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WScaleEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgentEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VslEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RelieveEditSON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cmdlist.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sonWScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sonAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ashDateStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ashDateStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transPlaceSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transPlaceSOFF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transDateSOFF.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transDateSOFF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transDateSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transVsl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ashNxtAct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ashPlaceStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ashPlaceEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.soffDateSOFF.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.soffDateSOFF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.soffPlaceSOFF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.soffReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sonVsl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sonDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sonDateSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sonPlaceSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSON, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpTRANS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSOFF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpASHACT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'MainGrid
        '
        Me.MainGrid.AllowDrop = True
        Me.MainGrid.Location = New System.Drawing.Point(2, 386)
        Me.MainGrid.MainView = Me.Mainview
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.genericDateEdit, Me.PortEdit, Me.VslEdit, Me.RankEdit, Me.ReasonEdit, Me.StatusEdit, Me.AgentEdit, Me.WScaleEdit, Me.RelieveEdit})
        Me.MainGrid.Size = New System.Drawing.Size(1210, 213)
        Me.MainGrid.TabIndex = 4
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Mainview.Appearance.OddRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Mainview.Appearance.OddRow.Options.UseBackColor = True
        Me.Mainview.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gbSOFF, Me.gbSON, Me.gbGOBACK, Me.gbASHACT, Me.gbTRANS, Me.gbPROM, Me.gbSICKONB})
        Me.Mainview.ColumnPanelRowHeight = 2
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.clmIDNbr, Me.clmSONCrewName, Me.clmSONRank, Me.clmSONWScale, Me.clmSONSeniority, Me.clmSONLOC, Me.clmSONLOCDays, Me.clmSONDateSON, Me.clmSONPlaceSON, Me.clmSONVsl, Me.clmSONRemarks, Me.clmSONPlaceDep, Me.clmSONDateDep, Me.clmSONAgent, Me.clmSOFFCrewName, Me.clmSOFFReason, Me.clmSOFFDateSOFF, Me.clmSOFFPlaceSOFF, Me.clmSOFFPlaceArr, Me.clmSOFFDateArr, Me.clmSOFFRemarks, Me.clmASHACTCrewName, Me.clmASHACTNxtAct, Me.clmASHACTPlaceStart, Me.clmASHACTPlaceEnd, Me.clmASHACTDateStart, Me.clmASHACTRemarks, Me.clmTCrewName, Me.clmTOldVsl, Me.clmTVsl, Me.clmTRank, Me.clmTSONDate, Me.clmTPlaceSON, Me.clmTDateSOFF, Me.clmTPlaceSOFF, Me.clmTRemarks, Me.clmTBlank, Me.clmPROMCrewName, Me.clmPROMOldRank, Me.clmPROMRank, Me.clmPROMDate, Me.clmPROMWScale, Me.clmPROMSeniority, Me.clmPROMRemarks, Me.clmGBCrewName, Me.clmGBRank, Me.clmGBStatus, Me.clmActDateStart, Me.clmActDateEnd, Me.clmBlank, Me.clmCurrActID, Me.clmActGrpID, Me.clmSOFFNxtAct, Me.clmSOFFNxtActDateStart, Me.clmSOFFNxtActPlaceStart, Me.clmSOFFNxtActPlaceEnd, Me.clmSONBCrew, Me.clmSONBDateStart, Me.clmSONBDesc, Me.clmSONBStat, Me.clmASHACTRank, Me.clmSONRelieve, Me.clmSOFFReliever})
        Me.Mainview.GridControl = Me.MainGrid
        Me.Mainview.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsCustomization.AllowFilter = False
        Me.Mainview.OptionsCustomization.AllowGroup = False
        Me.Mainview.OptionsCustomization.AllowQuickHideColumns = False
        Me.Mainview.OptionsDetail.AllowExpandEmptyDetails = True
        Me.Mainview.OptionsMenu.EnableColumnMenu = False
        Me.Mainview.OptionsSelection.MultiSelect = True
        Me.Mainview.OptionsView.ShowChildrenInGroupPanel = True
        Me.Mainview.OptionsView.ShowGroupPanel = False
        Me.Mainview.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'gbSOFF
        '
        Me.gbSOFF.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbSOFF.AppearanceHeader.Options.UseFont = True
        Me.gbSOFF.Caption = "Sign-off Details"
        Me.gbSOFF.Columns.Add(Me.clmSOFFCrewName)
        Me.gbSOFF.Columns.Add(Me.clmSOFFReason)
        Me.gbSOFF.Columns.Add(Me.clmSOFFDateSOFF)
        Me.gbSOFF.Columns.Add(Me.clmSOFFPlaceSOFF)
        Me.gbSOFF.Columns.Add(Me.clmSOFFDateArr)
        Me.gbSOFF.Columns.Add(Me.clmSOFFPlaceArr)
        Me.gbSOFF.Columns.Add(Me.clmSOFFNxtAct)
        Me.gbSOFF.Columns.Add(Me.clmSOFFNxtActDateStart)
        Me.gbSOFF.Columns.Add(Me.clmSOFFNxtActPlaceStart)
        Me.gbSOFF.Columns.Add(Me.clmSOFFNxtActPlaceEnd)
        Me.gbSOFF.Columns.Add(Me.clmSOFFReliever)
        Me.gbSOFF.Columns.Add(Me.clmSOFFRemarks)
        Me.gbSOFF.Name = "gbSOFF"
        Me.gbSOFF.VisibleIndex = 0
        Me.gbSOFF.Width = 1353
        '
        'clmSOFFCrewName
        '
        Me.clmSOFFCrewName.Caption = "Crew Name"
        Me.clmSOFFCrewName.FieldName = "Crew"
        Me.clmSOFFCrewName.Name = "clmSOFFCrewName"
        Me.clmSOFFCrewName.OptionsColumn.AllowEdit = False
        Me.clmSOFFCrewName.OptionsColumn.ReadOnly = True
        Me.clmSOFFCrewName.Tag = "SOFF"
        Me.clmSOFFCrewName.Visible = True
        Me.clmSOFFCrewName.Width = 156
        '
        'clmSOFFReason
        '
        Me.clmSOFFReason.Caption = "Reason"
        Me.clmSOFFReason.ColumnEdit = Me.ReasonEdit
        Me.clmSOFFReason.FieldName = "Reason"
        Me.clmSOFFReason.Name = "clmSOFFReason"
        Me.clmSOFFReason.Tag = "Required"
        Me.clmSOFFReason.Visible = True
        Me.clmSOFFReason.Width = 107
        '
        'ReasonEdit
        '
        Me.ReasonEdit.AutoHeight = False
        Me.ReasonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReasonEdit.DisplayMember = "StatName"
        Me.ReasonEdit.Name = "ReasonEdit"
        Me.ReasonEdit.NullText = ""
        Me.ReasonEdit.ShowFooter = False
        Me.ReasonEdit.ShowHeader = False
        Me.ReasonEdit.ValueMember = "StatCode"
        '
        'clmSOFFDateSOFF
        '
        Me.clmSOFFDateSOFF.Caption = "Date Sign-off"
        Me.clmSOFFDateSOFF.ColumnEdit = Me.genericDateEdit
        Me.clmSOFFDateSOFF.FieldName = "DateSOFF"
        Me.clmSOFFDateSOFF.Name = "clmSOFFDateSOFF"
        Me.clmSOFFDateSOFF.Tag = "Required"
        Me.clmSOFFDateSOFF.Visible = True
        Me.clmSOFFDateSOFF.Width = 107
        '
        'genericDateEdit
        '
        Me.genericDateEdit.AutoHeight = False
        Me.genericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.DisplayFormat.FormatString = "d"
        Me.genericDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.genericDateEdit.Mask.EditMask = ""
        Me.genericDateEdit.Name = "genericDateEdit"
        '
        'clmSOFFPlaceSOFF
        '
        Me.clmSOFFPlaceSOFF.Caption = "Place Sign-off "
        Me.clmSOFFPlaceSOFF.ColumnEdit = Me.PortEdit
        Me.clmSOFFPlaceSOFF.FieldName = "PlaceSOFF"
        Me.clmSOFFPlaceSOFF.Name = "clmSOFFPlaceSOFF"
        Me.clmSOFFPlaceSOFF.Tag = "Required"
        Me.clmSOFFPlaceSOFF.Visible = True
        Me.clmSOFFPlaceSOFF.Width = 99
        '
        'PortEdit
        '
        Me.PortEdit.AutoHeight = False
        Me.PortEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PortEdit.DisplayMember = "PortName"
        Me.PortEdit.Name = "PortEdit"
        Me.PortEdit.NullText = ""
        Me.PortEdit.ShowFooter = False
        Me.PortEdit.ShowHeader = False
        Me.PortEdit.ValueMember = "PortCode"
        '
        'clmSOFFDateArr
        '
        Me.clmSOFFDateArr.Caption = "Date Arrived home"
        Me.clmSOFFDateArr.ColumnEdit = Me.genericDateEdit
        Me.clmSOFFDateArr.FieldName = "DateArr"
        Me.clmSOFFDateArr.Name = "clmSOFFDateArr"
        Me.clmSOFFDateArr.Tag = "Required"
        Me.clmSOFFDateArr.Visible = True
        Me.clmSOFFDateArr.Width = 119
        '
        'clmSOFFPlaceArr
        '
        Me.clmSOFFPlaceArr.Caption = "Arrival Place"
        Me.clmSOFFPlaceArr.ColumnEdit = Me.PortEdit
        Me.clmSOFFPlaceArr.FieldName = "PlaceArr"
        Me.clmSOFFPlaceArr.Name = "clmSOFFPlaceArr"
        Me.clmSOFFPlaceArr.Tag = "Required"
        Me.clmSOFFPlaceArr.Visible = True
        Me.clmSOFFPlaceArr.Width = 95
        '
        'clmSOFFNxtAct
        '
        Me.clmSOFFNxtAct.Caption = "Next Activity"
        Me.clmSOFFNxtAct.ColumnEdit = Me.StatusEdit
        Me.clmSOFFNxtAct.FieldName = "NxtAct"
        Me.clmSOFFNxtAct.Name = "clmSOFFNxtAct"
        Me.clmSOFFNxtAct.Tag = "Required"
        Me.clmSOFFNxtAct.Visible = True
        Me.clmSOFFNxtAct.Width = 109
        '
        'StatusEdit
        '
        Me.StatusEdit.AutoHeight = False
        Me.StatusEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StatusEdit.DisplayMember = "StatName"
        Me.StatusEdit.Name = "StatusEdit"
        Me.StatusEdit.NullText = ""
        Me.StatusEdit.ShowFooter = False
        Me.StatusEdit.ShowHeader = False
        Me.StatusEdit.ValueMember = "StatCode"
        '
        'clmSOFFNxtActDateStart
        '
        Me.clmSOFFNxtActDateStart.Caption = "Start Date of Next Activity"
        Me.clmSOFFNxtActDateStart.ColumnEdit = Me.genericDateEdit
        Me.clmSOFFNxtActDateStart.FieldName = "ActDateStart"
        Me.clmSOFFNxtActDateStart.Name = "clmSOFFNxtActDateStart"
        Me.clmSOFFNxtActDateStart.Tag = "Required"
        Me.clmSOFFNxtActDateStart.Visible = True
        Me.clmSOFFNxtActDateStart.Width = 137
        '
        'clmSOFFNxtActPlaceStart
        '
        Me.clmSOFFNxtActPlaceStart.Caption = "Starting Place of Next Activity"
        Me.clmSOFFNxtActPlaceStart.ColumnEdit = Me.PortEdit
        Me.clmSOFFNxtActPlaceStart.FieldName = "PlaceStart"
        Me.clmSOFFNxtActPlaceStart.Name = "clmSOFFNxtActPlaceStart"
        Me.clmSOFFNxtActPlaceStart.Visible = True
        Me.clmSOFFNxtActPlaceStart.Width = 147
        '
        'clmSOFFNxtActPlaceEnd
        '
        Me.clmSOFFNxtActPlaceEnd.Caption = "Ending Place of Next Activity"
        Me.clmSOFFNxtActPlaceEnd.ColumnEdit = Me.PortEdit
        Me.clmSOFFNxtActPlaceEnd.FieldName = "PlaceEnd"
        Me.clmSOFFNxtActPlaceEnd.Name = "clmSOFFNxtActPlaceEnd"
        Me.clmSOFFNxtActPlaceEnd.Visible = True
        Me.clmSOFFNxtActPlaceEnd.Width = 186
        '
        'clmSOFFReliever
        '
        Me.clmSOFFReliever.Caption = "Reliever"
        Me.clmSOFFReliever.ColumnEdit = Me.RelieveEdit
        Me.clmSOFFReliever.FieldName = "RelievedID"
        Me.clmSOFFReliever.Name = "clmSOFFReliever"
        Me.clmSOFFReliever.OptionsColumn.AllowFocus = False
        Me.clmSOFFReliever.OptionsColumn.ReadOnly = True
        Me.clmSOFFReliever.Visible = True
        Me.clmSOFFReliever.Width = 71
        '
        'RelieveEdit
        '
        Me.RelieveEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.RelieveEdit.AutoHeight = False
        Me.RelieveEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.RelieveEdit.DisplayMember = "Crew"
        Me.RelieveEdit.Name = "RelieveEdit"
        Me.RelieveEdit.NullText = ""
        Me.RelieveEdit.PopupWidth = 350
        Me.RelieveEdit.ShowFooter = False
        Me.RelieveEdit.ShowHeader = False
        Me.RelieveEdit.ValueMember = "IDNbr"
        '
        'clmSOFFRemarks
        '
        Me.clmSOFFRemarks.Caption = "Remarks"
        Me.clmSOFFRemarks.FieldName = "Remarks"
        Me.clmSOFFRemarks.Name = "clmSOFFRemarks"
        Me.clmSOFFRemarks.Tag = "SOFF"
        Me.clmSOFFRemarks.Visible = True
        Me.clmSOFFRemarks.Width = 20
        '
        'gbSON
        '
        Me.gbSON.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbSON.AppearanceHeader.Options.UseFont = True
        Me.gbSON.Caption = "Sign-on Details"
        Me.gbSON.Columns.Add(Me.clmSONCrewName)
        Me.gbSON.Columns.Add(Me.clmSONRank)
        Me.gbSON.Columns.Add(Me.clmSONWScale)
        Me.gbSON.Columns.Add(Me.clmSONSeniority)
        Me.gbSON.Columns.Add(Me.clmSONLOC)
        Me.gbSON.Columns.Add(Me.clmSONLOCDays)
        Me.gbSON.Columns.Add(Me.clmSONAgent)
        Me.gbSON.Columns.Add(Me.clmSONVsl)
        Me.gbSON.Columns.Add(Me.clmSONDateDep)
        Me.gbSON.Columns.Add(Me.clmSONPlaceDep)
        Me.gbSON.Columns.Add(Me.clmTSONDate)
        Me.gbSON.Columns.Add(Me.clmSONPlaceSON)
        Me.gbSON.Columns.Add(Me.clmSONRelieve)
        Me.gbSON.Columns.Add(Me.clmSONRemarks)
        Me.gbSON.Name = "gbSON"
        Me.gbSON.Visible = False
        Me.gbSON.VisibleIndex = -1
        Me.gbSON.Width = 1750
        '
        'clmSONCrewName
        '
        Me.clmSONCrewName.Caption = "Crew Name"
        Me.clmSONCrewName.FieldName = "Crew"
        Me.clmSONCrewName.Name = "clmSONCrewName"
        Me.clmSONCrewName.OptionsColumn.AllowEdit = False
        Me.clmSONCrewName.OptionsColumn.AllowMove = False
        Me.clmSONCrewName.OptionsColumn.ReadOnly = True
        Me.clmSONCrewName.Tag = "General"
        Me.clmSONCrewName.Visible = True
        Me.clmSONCrewName.Width = 188
        '
        'clmSONRank
        '
        Me.clmSONRank.Caption = "Rank"
        Me.clmSONRank.ColumnEdit = Me.RankEdit
        Me.clmSONRank.FieldName = "RankCode"
        Me.clmSONRank.Name = "clmSONRank"
        Me.clmSONRank.Tag = "Required"
        Me.clmSONRank.Visible = True
        Me.clmSONRank.Width = 121
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.DisplayMember = "RankName"
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "RankCode"
        '
        'clmSONWScale
        '
        Me.clmSONWScale.Caption = "Wage Scale"
        Me.clmSONWScale.ColumnEdit = Me.WScaleEdit
        Me.clmSONWScale.FieldName = "WScaleCode"
        Me.clmSONWScale.Name = "clmSONWScale"
        Me.clmSONWScale.Tag = "Required"
        Me.clmSONWScale.Visible = True
        Me.clmSONWScale.Width = 120
        '
        'WScaleEdit
        '
        Me.WScaleEdit.AutoHeight = False
        Me.WScaleEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WScaleEdit.Name = "WScaleEdit"
        Me.WScaleEdit.NullText = ""
        Me.WScaleEdit.ShowFooter = False
        Me.WScaleEdit.ShowHeader = False
        Me.WScaleEdit.ValueMember = "rn"
        '
        'clmSONSeniority
        '
        Me.clmSONSeniority.Caption = "Seniority"
        Me.clmSONSeniority.FieldName = "Seniority"
        Me.clmSONSeniority.Name = "clmSONSeniority"
        Me.clmSONSeniority.Tag = ""
        Me.clmSONSeniority.Width = 74
        '
        'clmSONLOC
        '
        Me.clmSONLOC.Caption = "LOC"
        Me.clmSONLOC.FieldName = "LOC"
        Me.clmSONLOC.Name = "clmSONLOC"
        Me.clmSONLOC.Tag = "Required"
        Me.clmSONLOC.Visible = True
        Me.clmSONLOC.Width = 46
        '
        'clmSONLOCDays
        '
        Me.clmSONLOCDays.Caption = "LOC Days"
        Me.clmSONLOCDays.FieldName = "LOCDays"
        Me.clmSONLOCDays.Name = "clmSONLOCDays"
        Me.clmSONLOCDays.Visible = True
        Me.clmSONLOCDays.Width = 58
        '
        'clmSONAgent
        '
        Me.clmSONAgent.Caption = "Agent"
        Me.clmSONAgent.ColumnEdit = Me.AgentEdit
        Me.clmSONAgent.FieldName = "AgentCode"
        Me.clmSONAgent.Name = "clmSONAgent"
        Me.clmSONAgent.Tag = "Required"
        Me.clmSONAgent.Visible = True
        Me.clmSONAgent.Width = 137
        '
        'AgentEdit
        '
        Me.AgentEdit.AutoHeight = False
        Me.AgentEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AgentEdit.DisplayMember = "AgentName"
        Me.AgentEdit.Name = "AgentEdit"
        Me.AgentEdit.NullText = ""
        Me.AgentEdit.ShowFooter = False
        Me.AgentEdit.ShowHeader = False
        Me.AgentEdit.ValueMember = "AgentCode"
        '
        'clmSONVsl
        '
        Me.clmSONVsl.Caption = "Vessel"
        Me.clmSONVsl.ColumnEdit = Me.VslEdit
        Me.clmSONVsl.FieldName = "VslCode"
        Me.clmSONVsl.Name = "clmSONVsl"
        Me.clmSONVsl.Tag = "Required"
        Me.clmSONVsl.Visible = True
        Me.clmSONVsl.Width = 136
        '
        'VslEdit
        '
        Me.VslEdit.AutoHeight = False
        Me.VslEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VslEdit.DisplayMember = "VslName"
        Me.VslEdit.Name = "VslEdit"
        Me.VslEdit.NullText = ""
        Me.VslEdit.ShowFooter = False
        Me.VslEdit.ShowHeader = False
        Me.VslEdit.ValueMember = "VslCode"
        '
        'clmSONDateDep
        '
        Me.clmSONDateDep.Caption = "Departing Date"
        Me.clmSONDateDep.ColumnEdit = Me.genericDateEdit
        Me.clmSONDateDep.FieldName = "DateDep"
        Me.clmSONDateDep.Name = "clmSONDateDep"
        Me.clmSONDateDep.Tag = "Required"
        Me.clmSONDateDep.Visible = True
        Me.clmSONDateDep.Width = 100
        '
        'clmSONPlaceDep
        '
        Me.clmSONPlaceDep.Caption = "Departing Place"
        Me.clmSONPlaceDep.ColumnEdit = Me.PortEdit
        Me.clmSONPlaceDep.FieldName = "PlaceDep"
        Me.clmSONPlaceDep.Name = "clmSONPlaceDep"
        Me.clmSONPlaceDep.Tag = "Required"
        Me.clmSONPlaceDep.Visible = True
        Me.clmSONPlaceDep.Width = 127
        '
        'clmTSONDate
        '
        Me.clmTSONDate.Caption = "Date Sign-on"
        Me.clmTSONDate.ColumnEdit = Me.genericDateEdit
        Me.clmTSONDate.FieldName = "DateSON"
        Me.clmTSONDate.Name = "clmTSONDate"
        Me.clmTSONDate.Tag = "Required"
        Me.clmTSONDate.Visible = True
        Me.clmTSONDate.Width = 121
        '
        'clmSONPlaceSON
        '
        Me.clmSONPlaceSON.Caption = "Place Sign-on "
        Me.clmSONPlaceSON.ColumnEdit = Me.PortEdit
        Me.clmSONPlaceSON.FieldName = "PlaceSON"
        Me.clmSONPlaceSON.Name = "clmSONPlaceSON"
        Me.clmSONPlaceSON.Tag = "Required"
        Me.clmSONPlaceSON.Visible = True
        Me.clmSONPlaceSON.Width = 108
        '
        'clmSONRelieve
        '
        Me.clmSONRelieve.Caption = "Crew to relieve"
        Me.clmSONRelieve.ColumnEdit = Me.RelieveEdit
        Me.clmSONRelieve.FieldName = "RelievedID"
        Me.clmSONRelieve.Name = "clmSONRelieve"
        Me.clmSONRelieve.Visible = True
        Me.clmSONRelieve.Width = 146
        '
        'clmSONRemarks
        '
        Me.clmSONRemarks.Caption = "Remarks"
        Me.clmSONRemarks.FieldName = "Remarks"
        Me.clmSONRemarks.Name = "clmSONRemarks"
        Me.clmSONRemarks.Tag = "General"
        Me.clmSONRemarks.Visible = True
        Me.clmSONRemarks.Width = 342
        '
        'gbGOBACK
        '
        Me.gbGOBACK.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbGOBACK.AppearanceHeader.Options.UseFont = True
        Me.gbGOBACK.Caption = "Go Back to Previous Status Details"
        Me.gbGOBACK.Columns.Add(Me.clmGBCrewName)
        Me.gbGOBACK.Columns.Add(Me.clmGBRank)
        Me.gbGOBACK.Columns.Add(Me.clmGBStatus)
        Me.gbGOBACK.Name = "gbGOBACK"
        Me.gbGOBACK.Visible = False
        Me.gbGOBACK.VisibleIndex = -1
        Me.gbGOBACK.Width = 1051
        '
        'clmGBCrewName
        '
        Me.clmGBCrewName.Caption = "Crew Name"
        Me.clmGBCrewName.FieldName = "Crew"
        Me.clmGBCrewName.Name = "clmGBCrewName"
        Me.clmGBCrewName.OptionsColumn.AllowEdit = False
        Me.clmGBCrewName.OptionsColumn.ReadOnly = True
        Me.clmGBCrewName.Visible = True
        Me.clmGBCrewName.Width = 269
        '
        'clmGBRank
        '
        Me.clmGBRank.Caption = "Current Rank"
        Me.clmGBRank.FieldName = "RankName"
        Me.clmGBRank.Name = "clmGBRank"
        Me.clmGBRank.OptionsColumn.AllowEdit = False
        Me.clmGBRank.OptionsColumn.ReadOnly = True
        Me.clmGBRank.Visible = True
        Me.clmGBRank.Width = 209
        '
        'clmGBStatus
        '
        Me.clmGBStatus.Caption = "Current Status"
        Me.clmGBStatus.FieldName = "StatName"
        Me.clmGBStatus.Name = "clmGBStatus"
        Me.clmGBStatus.OptionsColumn.AllowEdit = False
        Me.clmGBStatus.OptionsColumn.ReadOnly = True
        Me.clmGBStatus.Visible = True
        Me.clmGBStatus.Width = 573
        '
        'gbASHACT
        '
        Me.gbASHACT.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbASHACT.AppearanceHeader.Options.UseFont = True
        Me.gbASHACT.Caption = "Ashore Activity Details"
        Me.gbASHACT.Columns.Add(Me.clmASHACTCrewName)
        Me.gbASHACT.Columns.Add(Me.clmASHACTRank)
        Me.gbASHACT.Columns.Add(Me.clmASHACTNxtAct)
        Me.gbASHACT.Columns.Add(Me.clmASHACTDateStart)
        Me.gbASHACT.Columns.Add(Me.clmASHACTPlaceStart)
        Me.gbASHACT.Columns.Add(Me.clmASHACTPlaceEnd)
        Me.gbASHACT.Columns.Add(Me.clmASHACTRemarks)
        Me.gbASHACT.Name = "gbASHACT"
        Me.gbASHACT.Visible = False
        Me.gbASHACT.VisibleIndex = -1
        Me.gbASHACT.Width = 889
        '
        'clmASHACTCrewName
        '
        Me.clmASHACTCrewName.Caption = "Crew Name"
        Me.clmASHACTCrewName.FieldName = "Crew"
        Me.clmASHACTCrewName.Name = "clmASHACTCrewName"
        Me.clmASHACTCrewName.OptionsColumn.AllowEdit = False
        Me.clmASHACTCrewName.OptionsColumn.ReadOnly = True
        Me.clmASHACTCrewName.Tag = ""
        Me.clmASHACTCrewName.Visible = True
        Me.clmASHACTCrewName.Width = 151
        '
        'clmASHACTRank
        '
        Me.clmASHACTRank.Caption = "Rank"
        Me.clmASHACTRank.ColumnEdit = Me.RankEdit
        Me.clmASHACTRank.FieldName = "RankCode"
        Me.clmASHACTRank.Name = "clmASHACTRank"
        Me.clmASHACTRank.Visible = True
        Me.clmASHACTRank.Width = 87
        '
        'clmASHACTNxtAct
        '
        Me.clmASHACTNxtAct.Caption = "Next Activity"
        Me.clmASHACTNxtAct.ColumnEdit = Me.StatusEdit
        Me.clmASHACTNxtAct.FieldName = "NxtAct"
        Me.clmASHACTNxtAct.Name = "clmASHACTNxtAct"
        Me.clmASHACTNxtAct.Tag = "Required"
        Me.clmASHACTNxtAct.Visible = True
        Me.clmASHACTNxtAct.Width = 112
        '
        'clmASHACTDateStart
        '
        Me.clmASHACTDateStart.Caption = "Start Date"
        Me.clmASHACTDateStart.ColumnEdit = Me.genericDateEdit
        Me.clmASHACTDateStart.FieldName = "ActDateStart"
        Me.clmASHACTDateStart.Name = "clmASHACTDateStart"
        Me.clmASHACTDateStart.Tag = "Required"
        Me.clmASHACTDateStart.Visible = True
        Me.clmASHACTDateStart.Width = 120
        '
        'clmASHACTPlaceStart
        '
        Me.clmASHACTPlaceStart.Caption = "Start Place"
        Me.clmASHACTPlaceStart.ColumnEdit = Me.PortEdit
        Me.clmASHACTPlaceStart.FieldName = "PlaceStart"
        Me.clmASHACTPlaceStart.Name = "clmASHACTPlaceStart"
        Me.clmASHACTPlaceStart.Tag = "Required"
        Me.clmASHACTPlaceStart.Visible = True
        Me.clmASHACTPlaceStart.Width = 127
        '
        'clmASHACTPlaceEnd
        '
        Me.clmASHACTPlaceEnd.Caption = "End Place"
        Me.clmASHACTPlaceEnd.ColumnEdit = Me.PortEdit
        Me.clmASHACTPlaceEnd.FieldName = "PlaceEnd"
        Me.clmASHACTPlaceEnd.Name = "clmASHACTPlaceEnd"
        Me.clmASHACTPlaceEnd.Tag = "Required"
        Me.clmASHACTPlaceEnd.Visible = True
        Me.clmASHACTPlaceEnd.Width = 155
        '
        'clmASHACTRemarks
        '
        Me.clmASHACTRemarks.Caption = "Remarks"
        Me.clmASHACTRemarks.FieldName = "Remarks"
        Me.clmASHACTRemarks.Name = "clmASHACTRemarks"
        Me.clmASHACTRemarks.Visible = True
        Me.clmASHACTRemarks.Width = 137
        '
        'gbTRANS
        '
        Me.gbTRANS.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbTRANS.AppearanceHeader.Options.UseFont = True
        Me.gbTRANS.Caption = "Transfer Details"
        Me.gbTRANS.Columns.Add(Me.clmTCrewName)
        Me.gbTRANS.Columns.Add(Me.clmTOldVsl)
        Me.gbTRANS.Columns.Add(Me.clmTDateSOFF)
        Me.gbTRANS.Columns.Add(Me.clmTPlaceSOFF)
        Me.gbTRANS.Columns.Add(Me.clmTVsl)
        Me.gbTRANS.Columns.Add(Me.clmSONDateSON)
        Me.gbTRANS.Columns.Add(Me.clmTPlaceSON)
        Me.gbTRANS.Columns.Add(Me.clmTRemarks)
        Me.gbTRANS.Columns.Add(Me.clmBlank)
        Me.gbTRANS.Columns.Add(Me.clmTRank)
        Me.gbTRANS.Name = "gbTRANS"
        Me.gbTRANS.Visible = False
        Me.gbTRANS.VisibleIndex = -1
        Me.gbTRANS.Width = 1194
        '
        'clmTCrewName
        '
        Me.clmTCrewName.Caption = "Crew Name"
        Me.clmTCrewName.FieldName = "Crew"
        Me.clmTCrewName.Name = "clmTCrewName"
        Me.clmTCrewName.OptionsColumn.AllowEdit = False
        Me.clmTCrewName.OptionsColumn.ReadOnly = True
        Me.clmTCrewName.Visible = True
        Me.clmTCrewName.Width = 166
        '
        'clmTOldVsl
        '
        Me.clmTOldVsl.Caption = "Current Vessel"
        Me.clmTOldVsl.FieldName = "VslName"
        Me.clmTOldVsl.Name = "clmTOldVsl"
        Me.clmTOldVsl.OptionsColumn.AllowEdit = False
        Me.clmTOldVsl.OptionsColumn.ReadOnly = True
        Me.clmTOldVsl.Visible = True
        Me.clmTOldVsl.Width = 149
        '
        'clmTDateSOFF
        '
        Me.clmTDateSOFF.Caption = "Date Sign-off"
        Me.clmTDateSOFF.ColumnEdit = Me.genericDateEdit
        Me.clmTDateSOFF.FieldName = "DateSOFF"
        Me.clmTDateSOFF.Name = "clmTDateSOFF"
        Me.clmTDateSOFF.Tag = "Required"
        Me.clmTDateSOFF.Visible = True
        Me.clmTDateSOFF.Width = 104
        '
        'clmTPlaceSOFF
        '
        Me.clmTPlaceSOFF.Caption = "Place Sign-off"
        Me.clmTPlaceSOFF.ColumnEdit = Me.PortEdit
        Me.clmTPlaceSOFF.FieldName = "PlaceSOFF"
        Me.clmTPlaceSOFF.Name = "clmTPlaceSOFF"
        Me.clmTPlaceSOFF.Tag = "Required"
        Me.clmTPlaceSOFF.Visible = True
        Me.clmTPlaceSOFF.Width = 96
        '
        'clmTVsl
        '
        Me.clmTVsl.Caption = "New Vessel"
        Me.clmTVsl.ColumnEdit = Me.VslEdit
        Me.clmTVsl.FieldName = "VslCode"
        Me.clmTVsl.Name = "clmTVsl"
        Me.clmTVsl.Tag = "Required"
        Me.clmTVsl.Visible = True
        Me.clmTVsl.Width = 135
        '
        'clmSONDateSON
        '
        Me.clmSONDateSON.Caption = "Date Sign-on"
        Me.clmSONDateSON.ColumnEdit = Me.genericDateEdit
        Me.clmSONDateSON.FieldName = "DateSON"
        Me.clmSONDateSON.Name = "clmSONDateSON"
        Me.clmSONDateSON.Tag = "Required"
        Me.clmSONDateSON.Visible = True
        Me.clmSONDateSON.Width = 107
        '
        'clmTPlaceSON
        '
        Me.clmTPlaceSON.Caption = "Place Sign-on"
        Me.clmTPlaceSON.ColumnEdit = Me.PortEdit
        Me.clmTPlaceSON.FieldName = "PlaceSON"
        Me.clmTPlaceSON.Name = "clmTPlaceSON"
        Me.clmTPlaceSON.Tag = "Required"
        Me.clmTPlaceSON.Visible = True
        Me.clmTPlaceSON.Width = 115
        '
        'clmTRemarks
        '
        Me.clmTRemarks.Caption = "Remarks"
        Me.clmTRemarks.FieldName = "Remarks"
        Me.clmTRemarks.Name = "clmTRemarks"
        Me.clmTRemarks.Visible = True
        Me.clmTRemarks.Width = 322
        '
        'clmBlank
        '
        Me.clmBlank.Caption = " "
        Me.clmBlank.FieldName = "clmBlank"
        Me.clmBlank.Name = "clmBlank"
        Me.clmBlank.OptionsColumn.AllowEdit = False
        Me.clmBlank.OptionsColumn.AllowSize = False
        Me.clmBlank.OptionsColumn.FixedWidth = True
        Me.clmBlank.RowIndex = 1
        Me.clmBlank.Tag = "General"
        Me.clmBlank.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.clmBlank.Width = 173
        '
        'clmTRank
        '
        Me.clmTRank.Caption = "Rank"
        Me.clmTRank.ColumnEdit = Me.RankEdit
        Me.clmTRank.FieldName = "FKeyRankCode"
        Me.clmTRank.Name = "clmTRank"
        Me.clmTRank.RowIndex = 1
        Me.clmTRank.Tag = ""
        Me.clmTRank.Width = 200
        '
        'gbPROM
        '
        Me.gbPROM.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbPROM.AppearanceHeader.Options.UseFont = True
        Me.gbPROM.Caption = "Promotion Details"
        Me.gbPROM.Columns.Add(Me.clmPROMCrewName)
        Me.gbPROM.Columns.Add(Me.clmPROMOldRank)
        Me.gbPROM.Columns.Add(Me.clmPROMRank)
        Me.gbPROM.Columns.Add(Me.clmPROMWScale)
        Me.gbPROM.Columns.Add(Me.clmPROMDate)
        Me.gbPROM.Columns.Add(Me.clmPROMSeniority)
        Me.gbPROM.Columns.Add(Me.clmPROMRemarks)
        Me.gbPROM.Name = "gbPROM"
        Me.gbPROM.Visible = False
        Me.gbPROM.VisibleIndex = -1
        Me.gbPROM.Width = 996
        '
        'clmPROMCrewName
        '
        Me.clmPROMCrewName.Caption = "Crew Name"
        Me.clmPROMCrewName.FieldName = "Crew"
        Me.clmPROMCrewName.Name = "clmPROMCrewName"
        Me.clmPROMCrewName.OptionsColumn.AllowEdit = False
        Me.clmPROMCrewName.OptionsColumn.AllowSize = False
        Me.clmPROMCrewName.OptionsColumn.FixedWidth = True
        Me.clmPROMCrewName.OptionsColumn.ReadOnly = True
        Me.clmPROMCrewName.Visible = True
        Me.clmPROMCrewName.Width = 249
        '
        'clmPROMOldRank
        '
        Me.clmPROMOldRank.Caption = "Current Rank"
        Me.clmPROMOldRank.FieldName = "RankName"
        Me.clmPROMOldRank.Name = "clmPROMOldRank"
        Me.clmPROMOldRank.OptionsColumn.AllowEdit = False
        Me.clmPROMOldRank.OptionsColumn.ReadOnly = True
        Me.clmPROMOldRank.Visible = True
        Me.clmPROMOldRank.Width = 129
        '
        'clmPROMRank
        '
        Me.clmPROMRank.Caption = "New Rank"
        Me.clmPROMRank.ColumnEdit = Me.RankEdit
        Me.clmPROMRank.FieldName = "RankCode"
        Me.clmPROMRank.Name = "clmPROMRank"
        Me.clmPROMRank.Tag = "Required"
        Me.clmPROMRank.Visible = True
        Me.clmPROMRank.Width = 144
        '
        'clmPROMWScale
        '
        Me.clmPROMWScale.Caption = "Wage Scale"
        Me.clmPROMWScale.ColumnEdit = Me.WScaleEdit
        Me.clmPROMWScale.FieldName = "WScaleCode"
        Me.clmPROMWScale.Name = "clmPROMWScale"
        Me.clmPROMWScale.Tag = "Required"
        Me.clmPROMWScale.Visible = True
        Me.clmPROMWScale.Width = 199
        '
        'clmPROMDate
        '
        Me.clmPROMDate.Caption = "Date of Promotion"
        Me.clmPROMDate.ColumnEdit = Me.genericDateEdit
        Me.clmPROMDate.FieldName = "DateProm"
        Me.clmPROMDate.Name = "clmPROMDate"
        Me.clmPROMDate.Tag = "Required"
        Me.clmPROMDate.Visible = True
        Me.clmPROMDate.Width = 112
        '
        'clmPROMSeniority
        '
        Me.clmPROMSeniority.Caption = "Seniority"
        Me.clmPROMSeniority.FieldName = "Seniority"
        Me.clmPROMSeniority.Name = "clmPROMSeniority"
        Me.clmPROMSeniority.Tag = ""
        Me.clmPROMSeniority.Width = 59
        '
        'clmPROMRemarks
        '
        Me.clmPROMRemarks.Caption = "Remarks"
        Me.clmPROMRemarks.FieldName = "Remarks"
        Me.clmPROMRemarks.Name = "clmPROMRemarks"
        Me.clmPROMRemarks.Visible = True
        Me.clmPROMRemarks.Width = 163
        '
        'gbSICKONB
        '
        Me.gbSICKONB.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSICKONB.AppearanceHeader.Options.UseFont = True
        Me.gbSICKONB.Caption = "Sick Onboard Details"
        Me.gbSICKONB.Columns.Add(Me.clmSONBCrew)
        Me.gbSICKONB.Columns.Add(Me.clmSONBStat)
        Me.gbSICKONB.Columns.Add(Me.clmSONBDateStart)
        Me.gbSICKONB.Columns.Add(Me.clmSONBDesc)
        Me.gbSICKONB.Name = "gbSICKONB"
        Me.gbSICKONB.Visible = False
        Me.gbSICKONB.VisibleIndex = -1
        Me.gbSICKONB.Width = 1155
        '
        'clmSONBCrew
        '
        Me.clmSONBCrew.Caption = "Crew Name"
        Me.clmSONBCrew.FieldName = "Crew"
        Me.clmSONBCrew.Name = "clmSONBCrew"
        Me.clmSONBCrew.OptionsColumn.AllowEdit = False
        Me.clmSONBCrew.OptionsColumn.ReadOnly = True
        Me.clmSONBCrew.Visible = True
        Me.clmSONBCrew.Width = 175
        '
        'clmSONBStat
        '
        Me.clmSONBStat.Caption = "Status"
        Me.clmSONBStat.FieldName = "StatName"
        Me.clmSONBStat.Name = "clmSONBStat"
        Me.clmSONBStat.OptionsColumn.AllowEdit = False
        Me.clmSONBStat.OptionsColumn.ReadOnly = True
        Me.clmSONBStat.Visible = True
        Me.clmSONBStat.Width = 158
        '
        'clmSONBDateStart
        '
        Me.clmSONBDateStart.Caption = "Start/End Date"
        Me.clmSONBDateStart.ColumnEdit = Me.genericDateEdit
        Me.clmSONBDateStart.FieldName = "ActDateStart"
        Me.clmSONBDateStart.Name = "clmSONBDateStart"
        Me.clmSONBDateStart.Tag = "Required"
        Me.clmSONBDateStart.Visible = True
        Me.clmSONBDateStart.Width = 132
        '
        'clmSONBDesc
        '
        Me.clmSONBDesc.Caption = "Remarks"
        Me.clmSONBDesc.FieldName = "Remarks"
        Me.clmSONBDesc.Name = "clmSONBDesc"
        Me.clmSONBDesc.Visible = True
        Me.clmSONBDesc.Width = 690
        '
        'clmIDNbr
        '
        Me.clmIDNbr.Caption = "IDNbr"
        Me.clmIDNbr.FieldName = "IDNbr"
        Me.clmIDNbr.Name = "clmIDNbr"
        '
        'clmTBlank
        '
        Me.clmTBlank.Name = "clmTBlank"
        Me.clmTBlank.OptionsColumn.AllowEdit = False
        Me.clmTBlank.OptionsColumn.AllowSize = False
        Me.clmTBlank.OptionsColumn.FixedWidth = True
        Me.clmTBlank.OptionsColumn.ReadOnly = True
        Me.clmTBlank.Visible = True
        '
        'clmActDateStart
        '
        Me.clmActDateStart.Caption = "Activity Starting Date"
        Me.clmActDateStart.ColumnEdit = Me.genericDateEdit
        Me.clmActDateStart.FieldName = "ActDateStart"
        Me.clmActDateStart.Name = "clmActDateStart"
        Me.clmActDateStart.OptionsColumn.AllowEdit = False
        Me.clmActDateStart.OptionsColumn.AllowSize = False
        Me.clmActDateStart.OptionsColumn.FixedWidth = True
        Me.clmActDateStart.Tag = "General"
        Me.clmActDateStart.Visible = True
        Me.clmActDateStart.Width = 115
        '
        'clmActDateEnd
        '
        Me.clmActDateEnd.Caption = "Activity Ending Date"
        Me.clmActDateEnd.ColumnEdit = Me.genericDateEdit
        Me.clmActDateEnd.FieldName = "ActDateEnd"
        Me.clmActDateEnd.Name = "clmActDateEnd"
        Me.clmActDateEnd.Tag = "General"
        Me.clmActDateEnd.Visible = True
        Me.clmActDateEnd.Width = 349
        '
        'clmCurrActID
        '
        Me.clmCurrActID.FieldName = "CurrActID"
        Me.clmCurrActID.Name = "clmCurrActID"
        '
        'clmActGrpID
        '
        Me.clmActGrpID.FieldName = "ActGrpID"
        Me.clmActGrpID.Name = "clmActGrpID"
        '
        'RelieveEditSON
        '
        Me.RelieveEditSON.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.RelieveEditSON.AutoHeight = False
        Me.RelieveEditSON.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.RelieveEditSON.DisplayMember = "Crew"
        Me.RelieveEditSON.Name = "RelieveEditSON"
        Me.RelieveEditSON.NullText = ""
        Me.RelieveEditSON.PopupWidth = 350
        Me.RelieveEditSON.ShowFooter = False
        Me.RelieveEditSON.ShowHeader = False
        Me.RelieveEditSON.ValueMember = "IDNbr"
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1218, 625)
        Me.header.TabIndex = 4
        Me.header.Text = "Activity"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdlist)
        Me.LayoutControl1.Controls.Add(Me.lblViewPlan)
        Me.LayoutControl1.Controls.Add(Me.sonWScale)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.sonAgent)
        Me.LayoutControl1.Controls.Add(Me.ashDateStart)
        Me.LayoutControl1.Controls.Add(Me.MemoEdit1)
        Me.LayoutControl1.Controls.Add(Me.transPlaceSON)
        Me.LayoutControl1.Controls.Add(Me.transPlaceSOFF)
        Me.LayoutControl1.Controls.Add(Me.transDateSOFF)
        Me.LayoutControl1.Controls.Add(Me.transDateSON)
        Me.LayoutControl1.Controls.Add(Me.transVsl)
        Me.LayoutControl1.Controls.Add(Me.MainGrid)
        Me.LayoutControl1.Controls.Add(Me.ashNxtAct)
        Me.LayoutControl1.Controls.Add(Me.ashPlaceStart)
        Me.LayoutControl1.Controls.Add(Me.ashPlaceEnd)
        Me.LayoutControl1.Controls.Add(Me.soffDateSOFF)
        Me.LayoutControl1.Controls.Add(Me.soffPlaceSOFF)
        Me.LayoutControl1.Controls.Add(Me.soffReason)
        Me.LayoutControl1.Controls.Add(Me.sonVsl)
        Me.LayoutControl1.Controls.Add(Me.sonDateSON)
        Me.LayoutControl1.Controls.Add(Me.sonPlaceSON)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 22)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(226, 171, 828, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1214, 601)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdlist
        '
        Me.cmdlist.Location = New System.Drawing.Point(117, 10)
        Me.cmdlist.Name = "cmdlist"
        Me.cmdlist.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmdlist.Properties.NullText = ""
        Me.cmdlist.Size = New System.Drawing.Size(606, 20)
        Me.cmdlist.StyleController = Me.LayoutControl1
        Me.cmdlist.TabIndex = 5
        '
        'lblViewPlan
        '
        Me.lblViewPlan.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViewPlan.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.lblViewPlan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblViewPlan.Location = New System.Drawing.Point(358, 36)
        Me.lblViewPlan.Name = "lblViewPlan"
        Me.lblViewPlan.Size = New System.Drawing.Size(99, 9)
        Me.lblViewPlan.StyleController = Me.LayoutControl1
        Me.lblViewPlan.TabIndex = 31
        Me.lblViewPlan.Text = "Planned Crew"
        '
        'sonWScale
        '
        Me.sonWScale.Location = New System.Drawing.Point(110, 96)
        Me.sonWScale.Name = "sonWScale"
        Me.sonWScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sonWScale.Properties.DisplayMember = "WScaleName"
        Me.sonWScale.Properties.NullText = ""
        Me.sonWScale.Properties.ShowFooter = False
        Me.sonWScale.Properties.ShowHeader = False
        Me.sonWScale.Properties.ValueMember = "WScaleCode"
        Me.sonWScale.Size = New System.Drawing.Size(347, 20)
        Me.sonWScale.StyleController = Me.LayoutControl1
        Me.sonWScale.TabIndex = 30
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 302)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Padding = New System.Windows.Forms.Padding(2)
        Me.LabelControl1.Size = New System.Drawing.Size(77, 17)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 29
        Me.LabelControl1.Text = "Current Vessel: "
        '
        'sonAgent
        '
        Me.sonAgent.Location = New System.Drawing.Point(575, 33)
        Me.sonAgent.Name = "sonAgent"
        Me.sonAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sonAgent.Properties.DisplayMember = "AgentName"
        Me.sonAgent.Properties.NullText = ""
        Me.sonAgent.Properties.ShowFooter = False
        Me.sonAgent.Properties.ShowHeader = False
        Me.sonAgent.Properties.ValueMember = "AgentCode"
        Me.sonAgent.Size = New System.Drawing.Size(303, 20)
        Me.sonAgent.StyleController = Me.LayoutControl1
        Me.sonAgent.TabIndex = 28
        Me.sonAgent.Tag = "AgentCode"
        '
        'ashDateStart
        '
        Me.ashDateStart.EditValue = Nothing
        Me.ashDateStart.Location = New System.Drawing.Point(568, 232)
        Me.ashDateStart.Name = "ashDateStart"
        Me.ashDateStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ashDateStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ashDateStart.Size = New System.Drawing.Size(310, 20)
        Me.ashDateStart.StyleController = Me.LayoutControl1
        Me.ashDateStart.TabIndex = 26
        Me.ashDateStart.Tag = "ActDateStart"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(906, 33)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(294, 337)
        Me.MemoEdit1.StyleController = Me.LayoutControl1
        Me.MemoEdit1.TabIndex = 25
        Me.MemoEdit1.Tag = "Remarks"
        '
        'transPlaceSON
        '
        Me.transPlaceSON.Location = New System.Drawing.Point(560, 350)
        Me.transPlaceSON.Name = "transPlaceSON"
        Me.transPlaceSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.transPlaceSON.Properties.DisplayMember = "PortName"
        Me.transPlaceSON.Properties.NullText = ""
        Me.transPlaceSON.Properties.ShowFooter = False
        Me.transPlaceSON.Properties.ShowHeader = False
        Me.transPlaceSON.Properties.ValueMember = "PortCode"
        Me.transPlaceSON.Size = New System.Drawing.Size(318, 20)
        Me.transPlaceSON.StyleController = Me.LayoutControl1
        Me.transPlaceSON.TabIndex = 22
        Me.transPlaceSON.Tag = "PlaceSON"
        '
        'transPlaceSOFF
        '
        Me.transPlaceSOFF.Location = New System.Drawing.Point(110, 350)
        Me.transPlaceSOFF.Name = "transPlaceSOFF"
        Me.transPlaceSOFF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.transPlaceSOFF.Properties.DisplayMember = "PortName"
        Me.transPlaceSOFF.Properties.NullText = ""
        Me.transPlaceSOFF.Properties.ShowFooter = False
        Me.transPlaceSOFF.Properties.ShowHeader = False
        Me.transPlaceSOFF.Properties.ValueMember = "PortCode"
        Me.transPlaceSOFF.Size = New System.Drawing.Size(342, 20)
        Me.transPlaceSOFF.StyleController = Me.LayoutControl1
        Me.transPlaceSOFF.TabIndex = 21
        Me.transPlaceSOFF.Tag = "PlaceSOFF"
        '
        'transDateSOFF
        '
        Me.transDateSOFF.EditValue = Nothing
        Me.transDateSOFF.Location = New System.Drawing.Point(110, 326)
        Me.transDateSOFF.Name = "transDateSOFF"
        Me.transDateSOFF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.transDateSOFF.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.transDateSOFF.Size = New System.Drawing.Size(342, 20)
        Me.transDateSOFF.StyleController = Me.LayoutControl1
        Me.transDateSOFF.TabIndex = 27
        Me.transDateSOFF.Tag = "DateSOFF"
        '
        'transDateSON
        '
        Me.transDateSON.EditValue = Nothing
        Me.transDateSON.Location = New System.Drawing.Point(560, 323)
        Me.transDateSON.Name = "transDateSON"
        Me.transDateSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.transDateSON.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.transDateSON.Size = New System.Drawing.Size(318, 20)
        Me.transDateSON.StyleController = Me.LayoutControl1
        Me.transDateSON.TabIndex = 19
        Me.transDateSON.Tag = "DateSON"
        '
        'transVsl
        '
        Me.transVsl.Location = New System.Drawing.Point(560, 299)
        Me.transVsl.Name = "transVsl"
        Me.transVsl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.transVsl.Properties.DisplayMember = "VslName"
        Me.transVsl.Properties.NullText = ""
        Me.transVsl.Properties.ShowFooter = False
        Me.transVsl.Properties.ShowHeader = False
        Me.transVsl.Properties.ValueMember = "VslCode"
        Me.transVsl.Size = New System.Drawing.Size(318, 20)
        Me.transVsl.StyleController = Me.LayoutControl1
        Me.transVsl.TabIndex = 17
        Me.transVsl.Tag = "VslCode"
        '
        'ashNxtAct
        '
        Me.ashNxtAct.Location = New System.Drawing.Point(568, 160)
        Me.ashNxtAct.Name = "ashNxtAct"
        Me.ashNxtAct.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ashNxtAct.Properties.DisplayMember = "StatName"
        Me.ashNxtAct.Properties.NullText = ""
        Me.ashNxtAct.Properties.ShowFooter = False
        Me.ashNxtAct.Properties.ShowHeader = False
        Me.ashNxtAct.Properties.ValueMember = "StatCode"
        Me.ashNxtAct.Size = New System.Drawing.Size(310, 20)
        Me.ashNxtAct.StyleController = Me.LayoutControl1
        Me.ashNxtAct.TabIndex = 21
        Me.ashNxtAct.Tag = "NxtAct"
        '
        'ashPlaceStart
        '
        Me.ashPlaceStart.Location = New System.Drawing.Point(568, 184)
        Me.ashPlaceStart.Name = "ashPlaceStart"
        Me.ashPlaceStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ashPlaceStart.Properties.DisplayMember = "PortName"
        Me.ashPlaceStart.Properties.NullText = ""
        Me.ashPlaceStart.Properties.ShowFooter = False
        Me.ashPlaceStart.Properties.ShowHeader = False
        Me.ashPlaceStart.Properties.ValueMember = "PortCode"
        Me.ashPlaceStart.Size = New System.Drawing.Size(310, 20)
        Me.ashPlaceStart.StyleController = Me.LayoutControl1
        Me.ashPlaceStart.TabIndex = 23
        Me.ashPlaceStart.Tag = "PlaceStart"
        '
        'ashPlaceEnd
        '
        Me.ashPlaceEnd.Location = New System.Drawing.Point(568, 208)
        Me.ashPlaceEnd.Name = "ashPlaceEnd"
        Me.ashPlaceEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ashPlaceEnd.Properties.DisplayMember = "PortName"
        Me.ashPlaceEnd.Properties.NullText = ""
        Me.ashPlaceEnd.Properties.ShowFooter = False
        Me.ashPlaceEnd.Properties.ShowHeader = False
        Me.ashPlaceEnd.Properties.ValueMember = "PortCode"
        Me.ashPlaceEnd.Size = New System.Drawing.Size(310, 20)
        Me.ashPlaceEnd.StyleController = Me.LayoutControl1
        Me.ashPlaceEnd.TabIndex = 24
        Me.ashPlaceEnd.Tag = "PlaceEnd"
        '
        'soffDateSOFF
        '
        Me.soffDateSOFF.EditValue = Nothing
        Me.soffDateSOFF.Location = New System.Drawing.Point(110, 208)
        Me.soffDateSOFF.Name = "soffDateSOFF"
        Me.soffDateSOFF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.soffDateSOFF.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.soffDateSOFF.Size = New System.Drawing.Size(334, 20)
        Me.soffDateSOFF.StyleController = Me.LayoutControl1
        Me.soffDateSOFF.TabIndex = 18
        Me.soffDateSOFF.Tag = "DateSOFF;DateArr"
        '
        'soffPlaceSOFF
        '
        Me.soffPlaceSOFF.Location = New System.Drawing.Point(110, 184)
        Me.soffPlaceSOFF.Name = "soffPlaceSOFF"
        Me.soffPlaceSOFF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.soffPlaceSOFF.Properties.DisplayMember = "PortName"
        Me.soffPlaceSOFF.Properties.NullText = ""
        Me.soffPlaceSOFF.Properties.ShowFooter = False
        Me.soffPlaceSOFF.Properties.ShowHeader = False
        Me.soffPlaceSOFF.Properties.ValueMember = "PortCode"
        Me.soffPlaceSOFF.Size = New System.Drawing.Size(334, 20)
        Me.soffPlaceSOFF.StyleController = Me.LayoutControl1
        Me.soffPlaceSOFF.TabIndex = 19
        Me.soffPlaceSOFF.Tag = "PlaceSOFF;PlaceArr"
        '
        'soffReason
        '
        Me.soffReason.Location = New System.Drawing.Point(110, 160)
        Me.soffReason.Name = "soffReason"
        Me.soffReason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.soffReason.Properties.DisplayMember = "StatName"
        Me.soffReason.Properties.NullText = ""
        Me.soffReason.Properties.ShowFooter = False
        Me.soffReason.Properties.ShowHeader = False
        Me.soffReason.Properties.ValueMember = "StatCode"
        Me.soffReason.Size = New System.Drawing.Size(334, 20)
        Me.soffReason.StyleController = Me.LayoutControl1
        Me.soffReason.TabIndex = 17
        Me.soffReason.Tag = "Reason"
        '
        'sonVsl
        '
        Me.sonVsl.Location = New System.Drawing.Point(110, 33)
        Me.sonVsl.Name = "sonVsl"
        Me.sonVsl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sonVsl.Properties.DisplayMember = "VslName"
        Me.sonVsl.Properties.NullText = ""
        Me.sonVsl.Properties.ShowFooter = False
        Me.sonVsl.Properties.ShowHeader = False
        Me.sonVsl.Properties.ValueMember = "VslCode"
        Me.sonVsl.Size = New System.Drawing.Size(244, 20)
        Me.sonVsl.StyleController = Me.LayoutControl1
        Me.sonVsl.TabIndex = 7
        Me.sonVsl.Tag = "VslCode"
        '
        'sonDateSON
        '
        Me.sonDateSON.EditValue = Nothing
        Me.sonDateSON.Location = New System.Drawing.Point(110, 54)
        Me.sonDateSON.Name = "sonDateSON"
        Me.sonDateSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sonDateSON.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sonDateSON.Size = New System.Drawing.Size(347, 20)
        Me.sonDateSON.StyleController = Me.LayoutControl1
        Me.sonDateSON.TabIndex = 8
        Me.sonDateSON.Tag = "DateSON;DateDep"
        '
        'sonPlaceSON
        '
        Me.sonPlaceSON.Location = New System.Drawing.Point(110, 75)
        Me.sonPlaceSON.Name = "sonPlaceSON"
        Me.sonPlaceSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sonPlaceSON.Properties.DisplayMember = "PortName"
        Me.sonPlaceSON.Properties.NullText = ""
        Me.sonPlaceSON.Properties.ShowFooter = False
        Me.sonPlaceSON.Properties.ShowHeader = False
        Me.sonPlaceSON.Properties.ValueMember = "PortCode"
        Me.sonPlaceSON.Size = New System.Drawing.Size(347, 20)
        Me.sonPlaceSON.StyleController = Me.LayoutControl1
        Me.sonPlaceSON.TabIndex = 9
        Me.sonPlaceSON.Tag = "PlaceSON;PlaceDep"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cmdlist
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 10, 10, 10)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(733, 40)
        Me.LayoutControlItem2.Text = "Select Activity:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.grpSON, Me.grpTRANS, Me.LayoutControlGroup2, Me.grpSOFF, Me.grpASHACT})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1214, 601)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MainGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 384)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1214, 217)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'grpSON
        '
        Me.grpSON.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpSON.AppearanceGroup.Options.UseFont = True
        Me.grpSON.CustomizationFormText = "Sign On"
        Me.grpSON.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.grpSON.ExpandButtonVisible = True
        Me.grpSON.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.txtVessel, Me.LayoutControlItem19, Me.LayoutControlItem20, Me.LayoutControlItem10, Me.LayoutControlItem18, Me.LayoutControlItem21})
        Me.grpSON.Location = New System.Drawing.Point(0, 0)
        Me.grpSON.Name = "grpSON"
        Me.grpSON.Size = New System.Drawing.Size(892, 127)
        Me.grpSON.Text = "Sign On"
        Me.grpSON.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'txtVessel
        '
        Me.txtVessel.Control = Me.sonVsl
        Me.txtVessel.CustomizationFormText = "Vessel:"
        Me.txtVessel.Location = New System.Drawing.Point(0, 0)
        Me.txtVessel.MinSize = New System.Drawing.Size(140, 21)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(344, 21)
        Me.txtVessel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.txtVessel.Text = "Vessel:"
        Me.txtVessel.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.sonDateSON
        Me.LayoutControlItem19.CustomizationFormText = "Sign On Date:"
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 21)
        Me.LayoutControlItem19.MinSize = New System.Drawing.Size(140, 21)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(447, 21)
        Me.LayoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem19.Text = "Date Sign-on:"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.sonPlaceSON
        Me.LayoutControlItem20.CustomizationFormText = "Place Sign On:"
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem20.MinSize = New System.Drawing.Size(140, 21)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(447, 21)
        Me.LayoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem20.Text = "Place Sign-on:"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.sonWScale
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 63)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(140, 21)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(447, 21)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.Text = "Wage Scale:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.lblViewPlan
        Me.LayoutControlItem18.Location = New System.Drawing.Point(344, 0)
        Me.LayoutControlItem18.MaxSize = New System.Drawing.Size(103, 16)
        Me.LayoutControlItem18.MinSize = New System.Drawing.Size(103, 16)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 2)
        Me.LayoutControlItem18.Size = New System.Drawing.Size(103, 21)
        Me.LayoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.sonAgent
        Me.LayoutControlItem21.Location = New System.Drawing.Point(447, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 2, 2, 2)
        Me.LayoutControlItem21.Size = New System.Drawing.Size(421, 84)
        Me.LayoutControlItem21.Text = "Agent: "
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(93, 13)
        '
        'grpTRANS
        '
        Me.grpTRANS.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTRANS.AppearanceGroup.Options.UseFont = True
        Me.grpTRANS.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.grpTRANS.ExpandButtonVisible = True
        Me.grpTRANS.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12, Me.LayoutControlItem7, Me.EmptySpaceItem2, Me.LayoutControlItem9, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem4})
        Me.grpTRANS.Location = New System.Drawing.Point(0, 266)
        Me.grpTRANS.Name = "grpTRANS"
        Me.grpTRANS.Size = New System.Drawing.Size(892, 118)
        Me.grpTRANS.Tag = "TRANS"
        Me.grpTRANS.Text = "Transfer"
        Me.grpTRANS.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.transDateSOFF
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControlItem12.MaxSize = New System.Drawing.Size(442, 24)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(442, 24)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(442, 24)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.Text = "Date Sign-off:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LabelControl1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(77, 27)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(77, 27)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 5)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(77, 27)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.transVsl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(442, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(426, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(426, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(426, 24)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "New Vessel:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(93, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(77, 0)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(365, 27)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(365, 27)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(365, 27)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.transPlaceSON
        Me.LayoutControlItem9.Location = New System.Drawing.Point(442, 51)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(426, 24)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(426, 24)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(426, 24)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.Text = "Place Sign-on:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.transDateSON
        Me.LayoutControlItem6.Location = New System.Drawing.Point(442, 24)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(426, 27)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(426, 27)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(426, 27)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Date Sign-on:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.transPlaceSOFF
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(442, 24)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(442, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(442, 24)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Place Sign-off:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutControlGroup2.ExpandButtonVisible = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(892, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(322, 384)
        Me.LayoutControlGroup2.Text = "Remarks"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.MemoEdit1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(298, 341)
        Me.LayoutControlItem3.Text = "Remarks"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'grpSOFF
        '
        Me.grpSOFF.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpSOFF.AppearanceGroup.Options.UseFont = True
        Me.grpSOFF.CustomizationFormText = "Sign Off"
        Me.grpSOFF.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.grpSOFF.ExpandButtonVisible = True
        Me.grpSOFF.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.EmptySpaceItem1})
        Me.grpSOFF.Location = New System.Drawing.Point(0, 127)
        Me.grpSOFF.Name = "grpSOFF"
        Me.grpSOFF.Size = New System.Drawing.Size(458, 139)
        Me.grpSOFF.Text = "Sign Off"
        Me.grpSOFF.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.soffDateSOFF
        Me.LayoutControlItem15.CustomizationFormText = "Sign-off Date:"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem15.MaxSize = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem15.MinSize = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem15.Tag = ""
        Me.LayoutControlItem15.Text = "Date Sign-off:"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.soffPlaceSOFF
        Me.LayoutControlItem16.CustomizationFormText = "Sign-off Place:"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem16.MaxSize = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem16.Text = "Sign-off Place:"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.soffReason
        Me.LayoutControlItem17.CustomizationFormText = "Reason:"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem17.MaxSize = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem17.MinSize = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(434, 24)
        Me.LayoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem17.Text = "Reason:"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(93, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(434, 24)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(434, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(434, 24)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'grpASHACT
        '
        Me.grpASHACT.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpASHACT.AppearanceGroup.Options.UseFont = True
        Me.grpASHACT.CustomizationFormText = "Ashore Activity"
        Me.grpASHACT.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.grpASHACT.ExpandButtonVisible = True
        Me.grpASHACT.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem11})
        Me.grpASHACT.Location = New System.Drawing.Point(458, 127)
        Me.grpASHACT.Name = "grpASHACT"
        Me.grpASHACT.Size = New System.Drawing.Size(434, 139)
        Me.grpASHACT.Text = "Ashore Activity"
        Me.grpASHACT.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ashNxtAct
        Me.LayoutControlItem5.CustomizationFormText = "Next Activity:"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Next Activity:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.ashPlaceStart
        Me.LayoutControlItem13.CustomizationFormText = "Starting Place:"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem13.MaxSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem13.Text = "Starting Place:"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.ashPlaceEnd
        Me.LayoutControlItem14.CustomizationFormText = "Ending Place:"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "Ending Place:"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(93, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.ashDateStart
        Me.LayoutControlItem11.CustomizationFormText = "Activity Start Date:"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem11.MaxSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(410, 24)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.Text = "Activity Start Date:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(93, 13)
        '
        'grpRemarks
        '
        Me.grpRemarks.Location = New System.Drawing.Point(754, 40)
        Me.grpRemarks.Name = "grpRemarks"
        Me.grpRemarks.OptionsItemText.TextToControlDistance = 5
        Me.grpRemarks.Size = New System.Drawing.Size(76, 139)
        '
        'CrewActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CrewActivity"
        Me.Size = New System.Drawing.Size(1218, 625)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReasonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RelieveEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WScaleEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgentEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VslEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RelieveEditSON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cmdlist.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sonWScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sonAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ashDateStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ashDateStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transPlaceSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transPlaceSOFF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transDateSOFF.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transDateSOFF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transDateSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transVsl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ashNxtAct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ashPlaceStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ashPlaceEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.soffDateSOFF.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.soffDateSOFF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.soffPlaceSOFF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.soffReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sonVsl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sonDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sonDateSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sonPlaceSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSON, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpTRANS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSOFF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpASHACT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdlist As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents transVsl As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents grpTRANS As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents transDateSON As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents transPlaceSON As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents transPlaceSOFF As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ashNxtAct As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ashPlaceStart As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ashPlaceEnd As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents grpASHACT As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents soffDateSOFF As DevExpress.XtraEditors.DateEdit
    Friend WithEvents soffPlaceSOFF As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents soffReason As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents sonVsl As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents sonDateSON As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sonPlaceSON As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents grpSOFF As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grpSON As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtVessel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents grpRemarks As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents genericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents PortEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents VslEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents clmIDNbr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONWScale As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONSeniority As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONLOC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONVsl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFReason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFDateSOFF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFPlaceSOFF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmASHACTNxtAct As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmASHACTPlaceStart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmASHACTPlaceEnd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPROMRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPROMDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmActDateEnd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONPlaceSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONDateSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONPlaceDep As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONDateDep As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmActDateStart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmBlank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTVsl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTSONDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTPlaceSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTPlaceSOFF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPROMWScale As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPROMSeniority As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents StatusEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ReasonEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmSOFFPlaceArr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFDateArr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmCurrActID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmActGrpID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmASHACTCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmASHACTDateStart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmASHACTRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ashDateStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents clmTCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTDateSOFF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTBlank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents transDateSOFF As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents sonAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents clmSONAgent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AgentEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmSONLOCDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTOldVsl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPROMCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPROMOldRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPROMRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmGBCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmGBRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmGBStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents clmSOFFNxtAct As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFNxtActDateStart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents WScaleEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmSOFFNxtActPlaceStart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents sonWScale As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents clmSONBCrew As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONBDateStart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONBDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSONBStat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSOFFNxtActPlaceEnd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmASHACTRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents lblViewPlan As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents clmSONRelieve As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RelieveEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmSOFFReliever As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RelieveEditSON As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gbSOFF As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbSON As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbGOBACK As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbASHACT As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbTRANS As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbPROM As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbSICKONB As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
