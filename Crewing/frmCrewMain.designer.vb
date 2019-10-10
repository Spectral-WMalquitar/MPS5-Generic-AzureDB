<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrewMain
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    ''Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrewMain))
        Me.LEDocType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LEVessel = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.popAppIcon = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
        Me.Biodata = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSave = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdView = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.SortRank = New DevExpress.XtraBars.BarButtonItem()
        Me.RankMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cmdSortRank_ASC = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSortRank_DESC = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.RecordSum = New DevExpress.XtraBars.BarButtonItem()
        Me.Service = New DevExpress.XtraBars.BarButtonItem()
        Me.Relative = New DevExpress.XtraBars.BarButtonItem()
        Me.Appraisal = New DevExpress.XtraBars.BarButtonItem()
        Me.Career = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdBackMenu = New DevExpress.XtraBars.BarButtonItem()
        Me.sbiInformation = New DevExpress.XtraBars.BarStaticItem()
        Me.sbiWarning = New DevExpress.XtraBars.BarStaticItem()
        Me.cmdDeleteSub = New DevExpress.XtraBars.BarButtonItem()
        Me.sbiCheck = New DevExpress.XtraBars.BarStaticItem()
        Me.cmdSort = New DevExpress.XtraBars.BarButtonItem()
        Me.SortMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cmdSortName = New DevExpress.XtraBars.BarButtonItem()
        Me.CrewNameMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cmdSortNameASC = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSortNameDESC = New DevExpress.XtraBars.BarButtonItem()
        Me.Crew = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSaveLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdResetLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.Document = New DevExpress.XtraBars.BarButtonItem()
        Me.CREWREPORT = New DevExpress.XtraBars.BarButtonItem()
        Me.ADVANCEDSEARCH = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdChangePass = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdChangeUser = New DevExpress.XtraBars.BarButtonItem()
        Me.SignOn = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.CrewActivity_Amend = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdLoadData = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdExport = New DevExpress.XtraBars.BarButtonItem()
        Me.SignOff = New DevExpress.XtraBars.BarButtonItem()
        Me.Promotion = New DevExpress.XtraBars.BarButtonItem()
        Me.Transfer = New DevExpress.XtraBars.BarButtonItem()
        Me.SickOnboard = New DevExpress.XtraBars.BarButtonItem()
        Me.AshoreActivity = New DevExpress.XtraBars.BarButtonItem()
        Me.GoBack = New DevExpress.XtraBars.BarButtonItem()
        Me.DocViewer = New DevExpress.XtraBars.BarButtonItem()
        Me.ftrVessel = New DevExpress.XtraBars.BarEditItem()
        Me.ftrDocType = New DevExpress.XtraBars.BarEditItem()
        Me.cmdBulk = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSetFolder = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Individual_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdShowSelectionList = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdPreviewReport = New DevExpress.XtraBars.BarButtonItem()
        Me.Onboard_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.Planning_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.History_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.Ashore_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.QualificationMatrix = New DevExpress.XtraBars.BarButtonItem()
        Me.btnNotif = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdUserSettings = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdApply = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdClearFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.Planning = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdDownload = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdPrintFile = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdClearCLFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.TravelEventV2 = New DevExpress.XtraBars.BarButtonItem()
        Me.TravelEvent_Returning = New DevExpress.XtraBars.BarButtonItem()
        Me.CrewChecklist = New DevExpress.XtraBars.BarButtonItem()
        Me.txtServerName = New DevExpress.XtraBars.BarStaticItem()
        Me.txtUserName = New DevExpress.XtraBars.BarStaticItem()
        Me.NotifExpDocs = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockingMenuItem1 = New DevExpress.XtraBars.BarDockingMenuItem()
        Me.cmdExpCrewList = New DevExpress.XtraBars.BarButtonItem()
        Me.Training = New DevExpress.XtraBars.BarButtonItem()
        Me.AshCrewWages = New DevExpress.XtraBars.BarButtonItem()
        Me.CrewAmortization = New DevExpress.XtraBars.BarButtonItem()
        Me.ReassignCrewRequest = New DevExpress.XtraBars.BarButtonItem()
        Me.ReassignCrewConfirm = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdViewRecordSum = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdHideRequest = New DevExpress.XtraBars.BarButtonItem()
        Me.OnbCrewWages = New DevExpress.XtraBars.BarButtonItem()
        Me.Government_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.ReportsGovMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ReportGovIndi_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.ReportGovMonthly_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.btnViewRelatives = New DevExpress.XtraBars.BarButtonItem()
        Me.Remittances = New DevExpress.XtraBars.BarButtonItem()
        Me.MedicalHis = New DevExpress.XtraBars.BarButtonItem()
        Me.ReassignCrewHistory = New DevExpress.XtraBars.BarButtonItem()
        Me.LTP = New DevExpress.XtraBars.BarButtonItem()
        Me.LTPScaler = New DevExpress.XtraBars.BarEditItem()
        Me.LTPTrackbar = New DevExpress.XtraEditors.Repository.RepositoryItemTrackBar()
        Me.barLTPLUE = New DevExpress.XtraBars.BarEditItem()
        Me.lueLTPFilter = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.barLTPChk = New DevExpress.XtraBars.BarEditItem()
        Me.chkLTPShowAll = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Other_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.Statistics_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.barLUEFilterMode = New DevExpress.XtraBars.BarEditItem()
        Me.repLTPFilterMode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.barColorScheme = New DevExpress.XtraBars.BarEditItem()
        Me.repColorSchemes = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.PayrollProcessOnb = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollProcessHA = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollProcessSA = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollViewSA = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdRunPayroll = New DevExpress.XtraBars.BarButtonItem()
        Me.ContractExtension = New DevExpress.XtraBars.BarButtonItem()
        Me.KPI = New DevExpress.XtraBars.BarButtonItem()
        Me.btnKPIClearFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.barKPIChartView = New DevExpress.XtraBars.BarEditItem()
        Me.repKPIChartView = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.barKPIPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.barKPIGenerateResult = New DevExpress.XtraBars.BarButtonItem()
        Me.barKPIClearChart = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCrewComments = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollViewHA = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollOnboard_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollHA_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollSA_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollDisketting_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollCompanySpecific_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdPayrollReports = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollReportsMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.PayrollViewONB = New DevExpress.XtraBars.BarButtonItem()
        Me.CrewCashAdvance = New DevExpress.XtraBars.BarButtonItem()
        Me.PayAdvances = New DevExpress.XtraBars.BarButtonItem()
        Me.barKPIChkShowResultOnly = New DevExpress.XtraBars.BarCheckItem()
        Me.barKPIColorPalette = New DevExpress.XtraBars.BarEditItem()
        Me.repKPIColorPalette = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ArchivedCrews = New DevExpress.XtraBars.BarButtonItem()
        Me.Archived_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.PayrollList = New DevExpress.XtraBars.BarButtonItem()
        Me.PlanChecklist = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiManualRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.beiShowFlaggedColors = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemCheckEdit11 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.DeleteCrew = New DevExpress.XtraBars.BarButtonItem()
        Me.barKPIShowHideTemplates = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTravelSearch = New DevExpress.XtraBars.BarButtonItem()
        Me.beLgndOnb = New DevExpress.XtraBars.BarEditItem()
        Me.repLgndOnb = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.beLgndPln = New DevExpress.XtraBars.BarEditItem()
        Me.repLgndPln = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.beLgndEdited = New DevExpress.XtraBars.BarEditItem()
        Me.repLgndEdited = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.beLgndInvalid = New DevExpress.XtraBars.BarEditItem()
        Me.repLgndInvalid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.cmdQuickReports = New DevExpress.XtraBars.BarButtonItem()
        Me.Email_Profile = New DevExpress.XtraBars.BarButtonItem()
        Me.Email_Config = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCheckItem1 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarCheckItem2 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarCheckItem3 = New DevExpress.XtraBars.BarCheckItem()
        Me.ReportConfig = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdHelp = New DevExpress.XtraBars.BarButtonItem()
        Me.KPIConfig = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdGenCAImpTemplate = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdImportFromExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.UniformIssuance = New DevExpress.XtraBars.BarButtonItem()
        Me.legendHigh = New DevExpress.XtraBars.BarStaticItem()
        Me.legendMedium = New DevExpress.XtraBars.BarStaticItem()
        Me.legendLow = New DevExpress.XtraBars.BarStaticItem()
        Me.barChkShowAllPlanning = New DevExpress.XtraBars.BarEditItem()
        Me.ChkShowAllPlanning = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cmdQuickFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.menuQuickFilter = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cmdFilterONB = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdFilterAshore = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdFilterPlanning = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdClearQuickFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.Activity_Docs = New DevExpress.XtraBars.BarButtonItem()
        Me.CompanySpecific_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.barLUESortMode = New DevExpress.XtraBars.BarEditItem()
        Me.repLTPSortMode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.barLTPLUESort = New DevExpress.XtraBars.BarEditItem()
        Me.lueLTPSort = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.CrewTraining_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.AllCrew_Report = New DevExpress.XtraBars.BarButtonItem()
        Me.barLTPSelectVesselRank = New DevExpress.XtraBars.BarButtonItem()
        Me.Travel_GTRS = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.GTRSConfig = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.Crewing = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgTool = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgCrewing = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.CrewListArchive = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiStartArchive = New DevExpress.XtraBars.BarButtonItem()
        Me.rpgActivityDocs = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgEditOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.Activity = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgActRefresh = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgActTools = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgActivity = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgActivityActivityDocs = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgActivityEditingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpLTP = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgLTPRefresh = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgLTPFilter = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgLTPSort = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgExport = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup9 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpPlanning = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgPlanning = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPlanningFilter = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgEditing = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpTravel = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgTravelRefresh = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.travelGTRS = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.travelEventRibbon = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgTravelFilter = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgTravel_EditingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgTravelEventSearch = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpChecklist = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgManualRefresh = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgFilter = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.PlanningChecklist = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPrintCheckList = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgIncludeFlaggedColors = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpCompetence = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgQualificationMatrix = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPrintOption = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpDMS = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgCrewFilter = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgDocViewer = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgDMSEditOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgExtract = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpReports = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgReport = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgReportEditOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgReportOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgReportConfig = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpKPI = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgKPI = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgKPIDisplayOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgKPITemplateOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPrintOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgKPIReportOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgKPIConfig = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpAshWageAcct = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgASHWTool = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgASHW = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAshWages = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpOnbWageAcct = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgONBWTool = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgONBWageAcct = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgONBWEditOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgONBImports = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpPayroll = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgPayrollFilters = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup8 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup10 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup7 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPayrollReport = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPayrollReportOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpArchive = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgCrewRecordSummary = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgArchiveProcess = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.bbiStartTransferToActive = New DevExpress.XtraBars.BarButtonItem()
        Me.rpgViewArchivedReport = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpLog = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpApproval = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpCrewReassignment = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgCrewReassignViewOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgCrewReassign = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgCrewReassignEditOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpInfo = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgAppInfo = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.About = New DevExpress.XtraBars.BarButtonItem()
        Me.VersionUpdates = New DevExpress.XtraBars.BarButtonItem()
        Me.rbgLTPFilter = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.RepositoryItemRadioGroup1 = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemToggleSwitch1 = New DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemPictureEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.RepositoryItemCheckEdit13 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemToggleSwitch2 = New DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.bbDeselectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageCategory2 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.bbiSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiDeselectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemRadioGroup2 = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.RepositoryItemCheckEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemRadioGroup3 = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.RepositoryItemRadioGroup4 = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.RepositoryItemCheckEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemRadioGroup5 = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.RepositoryItemCheckEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit10 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.chkIncludeLabeling = New DevExpress.XtraBars.BarEditItem()
        Me.MainPanel = New DevExpress.XtraEditors.SplitContainerControl()
        Me.DETAILS = New DevExpress.XtraBars.BarButtonItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.PopupMenu2 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.ReportsGovMonthly = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu3 = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.LEDocType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popAppIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SortMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewNameMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportsGovMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LTPTrackbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueLTPFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLTPShowAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repLTPFilterMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repColorSchemes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repKPIChartView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PayrollReportsMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repKPIColorPalette, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repLgndOnb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repLgndPln, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repLgndEdited, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repLgndInvalid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkShowAllPlanning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.menuQuickFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repLTPSortMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueLTPSort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbgLTPFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRadioGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemToggleSwitch1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemToggleSwitch2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRadioGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRadioGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRadioGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRadioGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LEDocType
        '
        Me.LEDocType.AutoHeight = False
        Me.LEDocType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDocType.DropDownRows = 10
        Me.LEDocType.Name = "LEDocType"
        Me.LEDocType.ShowFooter = False
        Me.LEDocType.ShowHeader = False
        '
        'LEVessel
        '
        Me.LEVessel.AutoHeight = False
        Me.LEVessel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEVessel.DropDownRows = 10
        Me.LEVessel.Name = "LEVessel"
        Me.LEVessel.ShowFooter = False
        Me.LEVessel.ShowHeader = False
        '
        'RibbonControl
        '
        Me.RibbonControl.ApplicationButtonDropDownControl = Me.popAppIcon
        Me.RibbonControl.ApplicationCaption = "MPS5 - Crew"
        Me.RibbonControl.ApplicationIcon = CType(resources.GetObject("RibbonControl.ApplicationIcon"), System.Drawing.Bitmap)
        Me.RibbonControl.AutoSizeItems = True
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.Biodata, Me.cmdAdd, Me.cmdSave, Me.cmdView, Me.cmdPrint, Me.SortRank, Me.cmdFilter, Me.RecordSum, Me.Service, Me.Relative, Me.Appraisal, Me.Career, Me.cmdEdit, Me.cmdBackMenu, Me.sbiInformation, Me.sbiWarning, Me.cmdDeleteSub, Me.sbiCheck, Me.cmdSort, Me.Crew, Me.cmdSaveLayout, Me.cmdResetLayout, Me.Document, Me.CREWREPORT, Me.ADVANCEDSEARCH, Me.cmdChangePass, Me.cmdChangeUser, Me.SignOn, Me.cmdDelete, Me.CrewActivity_Amend, Me.cmdLoadData, Me.cmdExport, Me.SignOff, Me.Promotion, Me.Transfer, Me.SickOnboard, Me.AshoreActivity, Me.GoBack, Me.DocViewer, Me.ftrVessel, Me.ftrDocType, Me.cmdBulk, Me.cmdSetFolder, Me.BarButtonItem1, Me.Individual_Report, Me.cmdShowSelectionList, Me.cmdPreviewReport, Me.Onboard_Report, Me.Planning_Report, Me.History_Report, Me.Ashore_Report, Me.QualificationMatrix, Me.btnNotif, Me.cmdUserSettings, Me.cmdApply, Me.cmdClearFilter, Me.cmdSortNameASC, Me.cmdSortNameDESC, Me.BarButtonItem2, Me.cmdSortName, Me.cmdSortRank_ASC, Me.cmdSortRank_DESC, Me.Planning, Me.cmdDownload, Me.cmdPrintFile, Me.cmdClearCLFilter, Me.TravelEventV2, Me.TravelEvent_Returning, Me.CrewChecklist, Me.txtServerName, Me.txtUserName, Me.NotifExpDocs, Me.cmdRefresh, Me.BarDockingMenuItem1, Me.cmdExpCrewList, Me.Training, Me.AshCrewWages, Me.CrewAmortization, Me.ReassignCrewRequest, Me.ReassignCrewConfirm, Me.cmdViewRecordSum, Me.cmdHideRequest, Me.OnbCrewWages, Me.Government_Report, Me.btnViewRelatives, Me.Remittances, Me.MedicalHis, Me.ReassignCrewHistory, Me.LTP, Me.LTPScaler, Me.barLTPLUE, Me.barLTPChk, Me.Other_Report, Me.Statistics_Report, Me.barLUEFilterMode, Me.barColorScheme, Me.PayrollProcessOnb, Me.PayrollProcessHA, Me.PayrollProcessSA, Me.PayrollViewSA, Me.cmdRunPayroll, Me.ContractExtension, Me.KPI, Me.btnKPIClearFilter, Me.barKPIChartView, Me.barKPIPrint, Me.barKPIGenerateResult, Me.barKPIClearChart, Me.btnCrewComments, Me.PayrollViewHA, Me.PayrollOnboard_Report, Me.PayrollHA_Report, Me.PayrollSA_Report, Me.PayrollDisketting_Report, Me.PayrollCompanySpecific_Report, Me.cmdPayrollReports, Me.PayrollViewONB, Me.CrewCashAdvance, Me.PayAdvances, Me.barKPIChkShowResultOnly, Me.barKPIColorPalette, Me.ArchivedCrews, Me.Archived_Report, Me.PayrollList, Me.PlanChecklist, Me.bbiManualRefresh, Me.beiShowFlaggedColors, Me.DeleteCrew, Me.barKPIShowHideTemplates, Me.btnTravelSearch, Me.beLgndOnb, Me.beLgndPln, Me.beLgndEdited, Me.beLgndInvalid, Me.cmdQuickReports, Me.Email_Profile, Me.Email_Config, Me.ReportGovIndi_Report, Me.BarCheckItem1, Me.BarCheckItem2, Me.ReportGovMonthly_Report, Me.BarCheckItem3, Me.ReportConfig, Me.cmdHelp, Me.KPIConfig, Me.cmdGenCAImpTemplate, Me.cmdImportFromExcel, Me.UniformIssuance, Me.legendHigh, Me.legendMedium, Me.legendLow, Me.barChkShowAllPlanning, Me.cmdQuickFilter, Me.cmdFilterONB, Me.cmdFilterPlanning, Me.cmdFilterAshore, Me.cmdClearQuickFilter, Me.Activity_Docs, Me.CompanySpecific_Report, Me.barLUESortMode, Me.barLTPLUESort, Me.CrewTraining_Report, Me.AllCrew_Report, Me.btnClose, Me.barLTPSelectVesselRank, Me.Travel_GTRS, Me.cmdCancel, Me.GTRSConfig})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.RibbonControl.MaxItemId = 93
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1})
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.Crewing, Me.Activity, Me.rpLTP, Me.rpPlanning, Me.rpTravel, Me.rpChecklist, Me.rpCompetence, Me.rpDMS, Me.rpReports, Me.rpKPI, Me.rpAshWageAcct, Me.rpOnbWageAcct, Me.rpPayroll, Me.rpArchive, Me.rpLog, Me.rpApproval, Me.rpCrewReassignment, Me.rpInfo})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.LEDocType, Me.LEVessel, Me.LTPTrackbar, Me.rbgLTPFilter, Me.RepositoryItemPictureEdit1, Me.RepositoryItemImageEdit1, Me.lueLTPFilter, Me.chkLTPShowAll, Me.RepositoryItemRadioGroup1, Me.repLTPFilterMode, Me.repColorSchemes, Me.RepositoryItemCheckEdit1, Me.repKPIChartView, Me.RepositoryItemCheckEdit2, Me.RepositoryItemToggleSwitch1, Me.RepositoryItemTextEdit1, Me.repKPIColorPalette, Me.RepositoryItemCheckEdit11, Me.RepositoryItemPictureEdit2, Me.RepositoryItemCheckEdit13, Me.repLgndOnb, Me.repLgndPln, Me.repLgndEdited, Me.repLgndInvalid, Me.repLTPSortMode, Me.lueLTPSort, Me.ChkShowAllPlanning, Me.RepositoryItemToggleSwitch2, Me.RepositoryItemTextEdit2, Me.RepositoryItemSpinEdit1})
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(1290, 155)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar1
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdSaveLayout, "S")
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdResetLayout, "RS")
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdChangePass, "CA")
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdChangeUser, "CN")
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdUserSettings, "U")
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdHelp)
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'popAppIcon
        '
        Me.popAppIcon.ItemLinks.Add(Me.btnClose)
        Me.popAppIcon.Name = "popAppIcon"
        Me.popAppIcon.Ribbon = Me.RibbonControl
        '
        'btnClose
        '
        Me.btnClose.Caption = "Close MPS"
        Me.btnClose.Glyph = CType(resources.GetObject("btnClose.Glyph"), System.Drawing.Image)
        Me.btnClose.Id = 68
        Me.btnClose.Name = "btnClose"
        '
        'Biodata
        '
        Me.Biodata.AllowAllUp = True
        Me.Biodata.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Biodata.Caption = " Biodata"
        Me.Biodata.Description = "Crew"
        Me.Biodata.Glyph = CType(resources.GetObject("Biodata.Glyph"), System.Drawing.Image)
        Me.Biodata.GroupIndex = 1
        Me.Biodata.Id = 1
        Me.Biodata.Name = "Biodata"
        Me.Biodata.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdAdd
        '
        Me.cmdAdd.Caption = "Add"
        Me.cmdAdd.Glyph = CType(resources.GetObject("cmdAdd.Glyph"), System.Drawing.Image)
        Me.cmdAdd.Id = 2
        Me.cmdAdd.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N))
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdSave
        '
        Me.cmdSave.Caption = "Save"
        Me.cmdSave.Glyph = CType(resources.GetObject("cmdSave.Glyph"), System.Drawing.Image)
        Me.cmdSave.Id = 3
        Me.cmdSave.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S))
        Me.cmdSave.LargeWidth = 100
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdView
        '
        Me.cmdView.Caption = "View Attachment"
        Me.cmdView.Glyph = CType(resources.GetObject("cmdView.Glyph"), System.Drawing.Image)
        Me.cmdView.Id = 8
        Me.cmdView.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P))
        Me.cmdView.Name = "cmdView"
        '
        'cmdPrint
        '
        Me.cmdPrint.Caption = "Print Biodata"
        Me.cmdPrint.Glyph = CType(resources.GetObject("cmdPrint.Glyph"), System.Drawing.Image)
        Me.cmdPrint.Id = 11
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'SortRank
        '
        Me.SortRank.ActAsDropDown = True
        Me.SortRank.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.SortRank.Caption = "Rank"
        Me.SortRank.DropDownControl = Me.RankMenu
        Me.SortRank.Glyph = CType(resources.GetObject("SortRank.Glyph"), System.Drawing.Image)
        Me.SortRank.GroupIndex = 3
        Me.SortRank.Id = 14
        Me.SortRank.Name = "SortRank"
        Me.SortRank.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'RankMenu
        '
        Me.RankMenu.ItemLinks.Add(Me.cmdSortRank_ASC, "A")
        Me.RankMenu.ItemLinks.Add(Me.cmdSortRank_DESC, "D")
        Me.RankMenu.Name = "RankMenu"
        Me.RankMenu.Ribbon = Me.RibbonControl
        '
        'cmdSortRank_ASC
        '
        Me.cmdSortRank_ASC.Caption = "Ascending"
        Me.cmdSortRank_ASC.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdSortRank_ASC.Glyph = CType(resources.GetObject("cmdSortRank_ASC.Glyph"), System.Drawing.Image)
        Me.cmdSortRank_ASC.Id = 1
        Me.cmdSortRank_ASC.Name = "cmdSortRank_ASC"
        '
        'cmdSortRank_DESC
        '
        Me.cmdSortRank_DESC.Caption = "Descending"
        Me.cmdSortRank_DESC.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdSortRank_DESC.Glyph = CType(resources.GetObject("cmdSortRank_DESC.Glyph"), System.Drawing.Image)
        Me.cmdSortRank_DESC.Id = 2
        Me.cmdSortRank_DESC.Name = "cmdSortRank_DESC"
        '
        'cmdFilter
        '
        Me.cmdFilter.Caption = "Filter"
        Me.cmdFilter.Glyph = CType(resources.GetObject("cmdFilter.Glyph"), System.Drawing.Image)
        Me.cmdFilter.Id = 18
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'RecordSum
        '
        Me.RecordSum.AllowAllUp = True
        Me.RecordSum.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.RecordSum.Caption = "Record Summary"
        Me.RecordSum.Description = "Crew"
        Me.RecordSum.Down = True
        Me.RecordSum.Glyph = CType(resources.GetObject("RecordSum.Glyph"), System.Drawing.Image)
        Me.RecordSum.GroupIndex = 1
        Me.RecordSum.Id = 19
        Me.RecordSum.Name = "RecordSum"
        Me.RecordSum.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Service
        '
        Me.Service.AllowAllUp = True
        Me.Service.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Service.Caption = "Service"
        Me.Service.Description = "Crew"
        Me.Service.Glyph = CType(resources.GetObject("Service.Glyph"), System.Drawing.Image)
        Me.Service.GroupIndex = 1
        Me.Service.Id = 23
        Me.Service.Name = "Service"
        Me.Service.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Relative
        '
        Me.Relative.AllowAllUp = True
        Me.Relative.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Relative.Caption = "Relatives"
        Me.Relative.Description = "Crew"
        Me.Relative.Glyph = CType(resources.GetObject("Relative.Glyph"), System.Drawing.Image)
        Me.Relative.GroupIndex = 1
        Me.Relative.Id = 24
        Me.Relative.Name = "Relative"
        Me.Relative.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Appraisal
        '
        Me.Appraisal.AllowAllUp = True
        Me.Appraisal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Appraisal.Caption = "Appraisals"
        Me.Appraisal.Description = "Crew"
        Me.Appraisal.Glyph = CType(resources.GetObject("Appraisal.Glyph"), System.Drawing.Image)
        Me.Appraisal.GroupIndex = 1
        Me.Appraisal.Id = 25
        Me.Appraisal.Name = "Appraisal"
        Me.Appraisal.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Career
        '
        Me.Career.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Career.Caption = "Career Plan"
        Me.Career.Glyph = CType(resources.GetObject("Career.Glyph"), System.Drawing.Image)
        Me.Career.Id = 26
        Me.Career.Name = "Career"
        Me.Career.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Career.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'cmdEdit
        '
        Me.cmdEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.cmdEdit.Caption = "Edit"
        Me.cmdEdit.Glyph = CType(resources.GetObject("cmdEdit.Glyph"), System.Drawing.Image)
        Me.cmdEdit.Id = 27
        Me.cmdEdit.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E))
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdBackMenu
        '
        Me.cmdBackMenu.Caption = "Menu"
        Me.cmdBackMenu.Glyph = CType(resources.GetObject("cmdBackMenu.Glyph"), System.Drawing.Image)
        Me.cmdBackMenu.Id = 29
        Me.cmdBackMenu.LargeGlyph = CType(resources.GetObject("cmdBackMenu.LargeGlyph"), System.Drawing.Image)
        Me.cmdBackMenu.Name = "cmdBackMenu"
        Me.cmdBackMenu.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'sbiInformation
        '
        Me.sbiInformation.Caption = "Information"
        Me.sbiInformation.Glyph = CType(resources.GetObject("sbiInformation.Glyph"), System.Drawing.Image)
        Me.sbiInformation.Id = 2
        Me.sbiInformation.Name = "sbiInformation"
        Me.sbiInformation.TextAlignment = System.Drawing.StringAlignment.Near
        Me.sbiInformation.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'sbiWarning
        '
        Me.sbiWarning.Caption = "Warning"
        Me.sbiWarning.Glyph = CType(resources.GetObject("sbiWarning.Glyph"), System.Drawing.Image)
        Me.sbiWarning.Id = 3
        Me.sbiWarning.Name = "sbiWarning"
        Me.sbiWarning.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        Me.sbiWarning.TextAlignment = System.Drawing.StringAlignment.Near
        Me.sbiWarning.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'cmdDeleteSub
        '
        Me.cmdDeleteSub.Caption = "Delete Sub"
        Me.cmdDeleteSub.Glyph = CType(resources.GetObject("cmdDeleteSub.Glyph"), System.Drawing.Image)
        Me.cmdDeleteSub.Id = 6
        Me.cmdDeleteSub.Name = "cmdDeleteSub"
        Me.cmdDeleteSub.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'sbiCheck
        '
        Me.sbiCheck.Caption = "Check"
        Me.sbiCheck.Glyph = CType(resources.GetObject("sbiCheck.Glyph"), System.Drawing.Image)
        Me.sbiCheck.Id = 22
        Me.sbiCheck.LargeGlyph = CType(resources.GetObject("sbiCheck.LargeGlyph"), System.Drawing.Image)
        Me.sbiCheck.Name = "sbiCheck"
        Me.sbiCheck.TextAlignment = System.Drawing.StringAlignment.Near
        Me.sbiCheck.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'cmdSort
        '
        Me.cmdSort.ActAsDropDown = True
        Me.cmdSort.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.cmdSort.Caption = "Sort"
        Me.cmdSort.DropDownControl = Me.SortMenu
        Me.cmdSort.Glyph = CType(resources.GetObject("cmdSort.Glyph"), System.Drawing.Image)
        Me.cmdSort.Id = 25
        Me.cmdSort.Name = "cmdSort"
        Me.cmdSort.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'SortMenu
        '
        Me.SortMenu.ItemLinks.Add(Me.cmdSortName)
        Me.SortMenu.ItemLinks.Add(Me.SortRank, "R")
        Me.SortMenu.Name = "SortMenu"
        Me.SortMenu.Ribbon = Me.RibbonControl
        '
        'cmdSortName
        '
        Me.cmdSortName.ActAsDropDown = True
        Me.cmdSortName.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.cmdSortName.Caption = "Crew Name"
        Me.cmdSortName.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdSortName.DropDownControl = Me.CrewNameMenu
        Me.cmdSortName.Glyph = CType(resources.GetObject("cmdSortName.Glyph"), System.Drawing.Image)
        Me.cmdSortName.Id = 83
        Me.cmdSortName.Name = "cmdSortName"
        Me.cmdSortName.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'CrewNameMenu
        '
        Me.CrewNameMenu.ItemLinks.Add(Me.cmdSortNameASC, "A")
        Me.CrewNameMenu.ItemLinks.Add(Me.cmdSortNameDESC, "D")
        Me.CrewNameMenu.Name = "CrewNameMenu"
        Me.CrewNameMenu.Ribbon = Me.RibbonControl
        '
        'cmdSortNameASC
        '
        Me.cmdSortNameASC.Caption = "Ascending"
        Me.cmdSortNameASC.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdSortNameASC.Glyph = CType(resources.GetObject("cmdSortNameASC.Glyph"), System.Drawing.Image)
        Me.cmdSortNameASC.Id = 78
        Me.cmdSortNameASC.Name = "cmdSortNameASC"
        '
        'cmdSortNameDESC
        '
        Me.cmdSortNameDESC.Caption = "Descending"
        Me.cmdSortNameDESC.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdSortNameDESC.Glyph = CType(resources.GetObject("cmdSortNameDESC.Glyph"), System.Drawing.Image)
        Me.cmdSortNameDESC.Id = 79
        Me.cmdSortNameDESC.Name = "cmdSortNameDESC"
        '
        'Crew
        '
        Me.Crew.AllowAllUp = True
        Me.Crew.AllowRightClickInMenu = False
        Me.Crew.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Crew.Caption = "Crew List"
        Me.Crew.Description = "Crew"
        Me.Crew.Glyph = CType(resources.GetObject("Crew.Glyph"), System.Drawing.Image)
        Me.Crew.GroupIndex = 1
        Me.Crew.Id = 26
        Me.Crew.Name = "Crew"
        Me.Crew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdSaveLayout
        '
        Me.cmdSaveLayout.Caption = "Save Layout"
        Me.cmdSaveLayout.Glyph = CType(resources.GetObject("cmdSaveLayout.Glyph"), System.Drawing.Image)
        Me.cmdSaveLayout.Id = 31
        Me.cmdSaveLayout.Name = "cmdSaveLayout"
        '
        'cmdResetLayout
        '
        Me.cmdResetLayout.Caption = "Restore Layout"
        Me.cmdResetLayout.Glyph = CType(resources.GetObject("cmdResetLayout.Glyph"), System.Drawing.Image)
        Me.cmdResetLayout.Id = 32
        Me.cmdResetLayout.Name = "cmdResetLayout"
        '
        'Document
        '
        Me.Document.AllowAllUp = True
        Me.Document.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Document.Caption = "Documents"
        Me.Document.Description = "Crew"
        Me.Document.Glyph = CType(resources.GetObject("Document.Glyph"), System.Drawing.Image)
        Me.Document.GroupIndex = 1
        Me.Document.Id = 33
        Me.Document.Name = "Document"
        Me.Document.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'CREWREPORT
        '
        Me.CREWREPORT.AllowAllUp = True
        Me.CREWREPORT.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CREWREPORT.Caption = "Report"
        Me.CREWREPORT.GroupIndex = 1
        Me.CREWREPORT.Id = 34
        Me.CREWREPORT.Name = "CREWREPORT"
        Me.CREWREPORT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ADVANCEDSEARCH
        '
        Me.ADVANCEDSEARCH.AllowAllUp = True
        Me.ADVANCEDSEARCH.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ADVANCEDSEARCH.Caption = "Query Builder"
        Me.ADVANCEDSEARCH.Description = "Reports"
        Me.ADVANCEDSEARCH.Glyph = CType(resources.GetObject("ADVANCEDSEARCH.Glyph"), System.Drawing.Image)
        Me.ADVANCEDSEARCH.GroupIndex = 1
        Me.ADVANCEDSEARCH.Id = 35
        Me.ADVANCEDSEARCH.Name = "ADVANCEDSEARCH"
        Me.ADVANCEDSEARCH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdChangePass
        '
        Me.cmdChangePass.Caption = "Change Password"
        Me.cmdChangePass.Glyph = CType(resources.GetObject("cmdChangePass.Glyph"), System.Drawing.Image)
        Me.cmdChangePass.Id = 36
        Me.cmdChangePass.Name = "cmdChangePass"
        '
        'cmdChangeUser
        '
        Me.cmdChangeUser.Caption = "Change User"
        Me.cmdChangeUser.Glyph = CType(resources.GetObject("cmdChangeUser.Glyph"), System.Drawing.Image)
        Me.cmdChangeUser.Id = 37
        Me.cmdChangeUser.Name = "cmdChangeUser"
        '
        'SignOn
        '
        Me.SignOn.AllowAllUp = True
        Me.SignOn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.SignOn.Caption = "Sign On"
        Me.SignOn.Description = "Activity"
        Me.SignOn.Glyph = CType(resources.GetObject("SignOn.Glyph"), System.Drawing.Image)
        Me.SignOn.GroupIndex = 1
        Me.SignOn.Id = 39
        Me.SignOn.LargeWidth = 80
        Me.SignOn.Name = "SignOn"
        Me.SignOn.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdDelete
        '
        Me.cmdDelete.Caption = "Delete"
        Me.cmdDelete.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdDelete.Glyph = CType(resources.GetObject("cmdDelete.Glyph"), System.Drawing.Image)
        Me.cmdDelete.Id = 42
        Me.cmdDelete.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D))
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'CrewActivity_Amend
        '
        Me.CrewActivity_Amend.AllowAllUp = True
        Me.CrewActivity_Amend.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CrewActivity_Amend.Caption = "Amend Activity"
        Me.CrewActivity_Amend.Description = "Activity"
        Me.CrewActivity_Amend.Glyph = CType(resources.GetObject("CrewActivity_Amend.Glyph"), System.Drawing.Image)
        Me.CrewActivity_Amend.GroupIndex = 1
        Me.CrewActivity_Amend.Id = 43
        Me.CrewActivity_Amend.LargeWidth = 80
        Me.CrewActivity_Amend.Name = "CrewActivity_Amend"
        Me.CrewActivity_Amend.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdLoadData
        '
        Me.cmdLoadData.Caption = "Load Template"
        Me.cmdLoadData.Glyph = CType(resources.GetObject("cmdLoadData.Glyph"), System.Drawing.Image)
        Me.cmdLoadData.Id = 44
        Me.cmdLoadData.Name = "cmdLoadData"
        Me.cmdLoadData.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdExport
        '
        Me.cmdExport.Caption = "Export"
        Me.cmdExport.Glyph = CType(resources.GetObject("cmdExport.Glyph"), System.Drawing.Image)
        Me.cmdExport.Id = 45
        Me.cmdExport.LargeWidth = 80
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'SignOff
        '
        Me.SignOff.AllowAllUp = True
        Me.SignOff.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.SignOff.Caption = "Sign Off"
        Me.SignOff.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.SignOff.Description = "Activity"
        Me.SignOff.Glyph = CType(resources.GetObject("SignOff.Glyph"), System.Drawing.Image)
        Me.SignOff.GroupIndex = 1
        Me.SignOff.Id = 46
        Me.SignOff.Name = "SignOff"
        Me.SignOff.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Promotion
        '
        Me.Promotion.AllowAllUp = True
        Me.Promotion.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Promotion.Caption = "Promotion"
        Me.Promotion.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Promotion.Description = "Activity"
        Me.Promotion.Glyph = CType(resources.GetObject("Promotion.Glyph"), System.Drawing.Image)
        Me.Promotion.GroupIndex = 1
        Me.Promotion.Id = 47
        Me.Promotion.Name = "Promotion"
        Me.Promotion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Transfer
        '
        Me.Transfer.AllowAllUp = True
        Me.Transfer.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Transfer.Caption = "Transfer"
        Me.Transfer.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Transfer.Description = "Activity"
        Me.Transfer.Glyph = CType(resources.GetObject("Transfer.Glyph"), System.Drawing.Image)
        Me.Transfer.GroupIndex = 1
        Me.Transfer.Id = 48
        Me.Transfer.Name = "Transfer"
        Me.Transfer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'SickOnboard
        '
        Me.SickOnboard.AllowAllUp = True
        Me.SickOnboard.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.SickOnboard.Caption = "Sick On Board"
        Me.SickOnboard.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.SickOnboard.Description = "Activity"
        Me.SickOnboard.Glyph = CType(resources.GetObject("SickOnboard.Glyph"), System.Drawing.Image)
        Me.SickOnboard.GroupIndex = 1
        Me.SickOnboard.Id = 49
        Me.SickOnboard.Name = "SickOnboard"
        Me.SickOnboard.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'AshoreActivity
        '
        Me.AshoreActivity.AllowAllUp = True
        Me.AshoreActivity.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.AshoreActivity.Caption = "Ashore Activity"
        Me.AshoreActivity.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.AshoreActivity.Description = "Activity"
        Me.AshoreActivity.Glyph = CType(resources.GetObject("AshoreActivity.Glyph"), System.Drawing.Image)
        Me.AshoreActivity.GroupIndex = 1
        Me.AshoreActivity.Id = 50
        Me.AshoreActivity.Name = "AshoreActivity"
        Me.AshoreActivity.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'GoBack
        '
        Me.GoBack.AllowAllUp = True
        Me.GoBack.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.GoBack.Caption = "Go Back To Previous"
        Me.GoBack.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.GoBack.Description = "Activity"
        Me.GoBack.Glyph = CType(resources.GetObject("GoBack.Glyph"), System.Drawing.Image)
        Me.GoBack.GroupIndex = 1
        Me.GoBack.Id = 51
        Me.GoBack.Name = "GoBack"
        Me.GoBack.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'DocViewer
        '
        Me.DocViewer.AllowAllUp = True
        Me.DocViewer.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.DocViewer.Caption = "Document Manager"
        Me.DocViewer.Description = "Document Manager"
        Me.DocViewer.Glyph = CType(resources.GetObject("DocViewer.Glyph"), System.Drawing.Image)
        Me.DocViewer.GroupIndex = 1
        Me.DocViewer.Id = 53
        Me.DocViewer.LargeWidth = 80
        Me.DocViewer.Name = "DocViewer"
        Me.DocViewer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ftrVessel
        '
        Me.ftrVessel.Caption = "Vessel :"
        Me.ftrVessel.Edit = Me.LEDocType
        Me.ftrVessel.Id = 54
        Me.ftrVessel.Name = "ftrVessel"
        Me.ftrVessel.Width = 150
        '
        'ftrDocType
        '
        Me.ftrDocType.Caption = "Document:"
        Me.ftrDocType.Edit = Me.LEVessel
        Me.ftrDocType.Id = 55
        Me.ftrDocType.Name = "ftrDocType"
        Me.ftrDocType.Width = 135
        '
        'cmdBulk
        '
        Me.cmdBulk.Caption = "Bulk"
        Me.cmdBulk.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdBulk.Glyph = CType(resources.GetObject("cmdBulk.Glyph"), System.Drawing.Image)
        Me.cmdBulk.Id = 57
        Me.cmdBulk.Name = "cmdBulk"
        Me.cmdBulk.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdSetFolder
        '
        Me.cmdSetFolder.Caption = "Set Documents Folder"
        Me.cmdSetFolder.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdSetFolder.Glyph = CType(resources.GetObject("cmdSetFolder.Glyph"), System.Drawing.Image)
        Me.cmdSetFolder.Id = 58
        Me.cmdSetFolder.Name = "cmdSetFolder"
        Me.cmdSetFolder.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Change Connection"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 59
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'Individual_Report
        '
        Me.Individual_Report.AllowAllUp = True
        Me.Individual_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Individual_Report.Caption = "Individual"
        Me.Individual_Report.Description = "Reports"
        Me.Individual_Report.Glyph = CType(resources.GetObject("Individual_Report.Glyph"), System.Drawing.Image)
        Me.Individual_Report.GroupIndex = 1
        Me.Individual_Report.Id = 61
        Me.Individual_Report.Name = "Individual_Report"
        Me.Individual_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Individual_Report.Tag = "Individual"
        Me.Individual_Report.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'cmdShowSelectionList
        '
        Me.cmdShowSelectionList.Caption = "Show Selection"
        Me.cmdShowSelectionList.Glyph = CType(resources.GetObject("cmdShowSelectionList.Glyph"), System.Drawing.Image)
        Me.cmdShowSelectionList.Id = 62
        Me.cmdShowSelectionList.Name = "cmdShowSelectionList"
        Me.cmdShowSelectionList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.cmdShowSelectionList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'cmdPreviewReport
        '
        Me.cmdPreviewReport.Caption = "View Report"
        Me.cmdPreviewReport.Glyph = CType(resources.GetObject("cmdPreviewReport.Glyph"), System.Drawing.Image)
        Me.cmdPreviewReport.Id = 63
        Me.cmdPreviewReport.LargeWidth = 100
        Me.cmdPreviewReport.Name = "cmdPreviewReport"
        Me.cmdPreviewReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Onboard_Report
        '
        Me.Onboard_Report.AllowAllUp = True
        Me.Onboard_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Onboard_Report.Caption = "Onboard"
        Me.Onboard_Report.Description = "Reports"
        Me.Onboard_Report.Glyph = CType(resources.GetObject("Onboard_Report.Glyph"), System.Drawing.Image)
        Me.Onboard_Report.GroupIndex = 1
        Me.Onboard_Report.Id = 64
        Me.Onboard_Report.Name = "Onboard_Report"
        Me.Onboard_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Onboard_Report.Tag = "Onboard"
        '
        'Planning_Report
        '
        Me.Planning_Report.AllowAllUp = True
        Me.Planning_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Planning_Report.Caption = "Planning"
        Me.Planning_Report.Description = "Reports"
        Me.Planning_Report.Glyph = CType(resources.GetObject("Planning_Report.Glyph"), System.Drawing.Image)
        Me.Planning_Report.GroupIndex = 1
        Me.Planning_Report.Id = 65
        Me.Planning_Report.Name = "Planning_Report"
        Me.Planning_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Planning_Report.Tag = "Planning"
        '
        'History_Report
        '
        Me.History_Report.AllowAllUp = True
        Me.History_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.History_Report.Caption = "History"
        Me.History_Report.Description = "Reports"
        Me.History_Report.Glyph = CType(resources.GetObject("History_Report.Glyph"), System.Drawing.Image)
        Me.History_Report.GroupIndex = 1
        Me.History_Report.Id = 66
        Me.History_Report.Name = "History_Report"
        Me.History_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.History_Report.Tag = "History"
        '
        'Ashore_Report
        '
        Me.Ashore_Report.AllowAllUp = True
        Me.Ashore_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Ashore_Report.Caption = "Ashore"
        Me.Ashore_Report.Description = "Reports"
        Me.Ashore_Report.Glyph = CType(resources.GetObject("Ashore_Report.Glyph"), System.Drawing.Image)
        Me.Ashore_Report.GroupIndex = 1
        Me.Ashore_Report.Id = 67
        Me.Ashore_Report.Name = "Ashore_Report"
        Me.Ashore_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Ashore_Report.Tag = "Ashore"
        '
        'QualificationMatrix
        '
        Me.QualificationMatrix.AllowAllUp = True
        Me.QualificationMatrix.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.QualificationMatrix.Caption = "Qualification Matrix"
        Me.QualificationMatrix.Description = "Qualification Matrix"
        Me.QualificationMatrix.Glyph = CType(resources.GetObject("QualificationMatrix.Glyph"), System.Drawing.Image)
        Me.QualificationMatrix.GroupIndex = 1
        Me.QualificationMatrix.Id = 68
        Me.QualificationMatrix.LargeWidth = 100
        Me.QualificationMatrix.Name = "QualificationMatrix"
        Me.QualificationMatrix.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnNotif
        '
        Me.btnNotif.Caption = "Notification"
        Me.btnNotif.Glyph = CType(resources.GetObject("btnNotif.Glyph"), System.Drawing.Image)
        Me.btnNotif.Id = 70
        Me.btnNotif.Name = "btnNotif"
        '
        'cmdUserSettings
        '
        Me.cmdUserSettings.Caption = "User Settings"
        Me.cmdUserSettings.Glyph = CType(resources.GetObject("cmdUserSettings.Glyph"), System.Drawing.Image)
        Me.cmdUserSettings.Id = 71
        Me.cmdUserSettings.Name = "cmdUserSettings"
        '
        'cmdApply
        '
        Me.cmdApply.Caption = "Apply"
        Me.cmdApply.Glyph = CType(resources.GetObject("cmdApply.Glyph"), System.Drawing.Image)
        Me.cmdApply.Id = 73
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdClearFilter
        '
        Me.cmdClearFilter.Caption = "Clear Filter"
        Me.cmdClearFilter.Glyph = CType(resources.GetObject("cmdClearFilter.Glyph"), System.Drawing.Image)
        Me.cmdClearFilter.Id = 74
        Me.cmdClearFilter.Name = "cmdClearFilter"
        Me.cmdClearFilter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Connection Check"
        Me.BarButtonItem2.Id = 80
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'Planning
        '
        Me.Planning.AllowAllUp = True
        Me.Planning.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Planning.Caption = "Planning"
        Me.Planning.Description = "Planning"
        Me.Planning.Glyph = CType(resources.GetObject("Planning.Glyph"), System.Drawing.Image)
        Me.Planning.GroupIndex = 1
        Me.Planning.Id = 3
        Me.Planning.LargeWidth = 80
        Me.Planning.Name = "Planning"
        Me.Planning.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdDownload
        '
        Me.cmdDownload.Caption = "Copy Image"
        Me.cmdDownload.Glyph = CType(resources.GetObject("cmdDownload.Glyph"), System.Drawing.Image)
        Me.cmdDownload.Id = 4
        Me.cmdDownload.LargeWidth = 80
        Me.cmdDownload.Name = "cmdDownload"
        Me.cmdDownload.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdPrintFile
        '
        Me.cmdPrintFile.Caption = "Print"
        Me.cmdPrintFile.Glyph = CType(resources.GetObject("cmdPrintFile.Glyph"), System.Drawing.Image)
        Me.cmdPrintFile.Id = 6
        Me.cmdPrintFile.LargeWidth = 80
        Me.cmdPrintFile.Name = "cmdPrintFile"
        Me.cmdPrintFile.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdClearCLFilter
        '
        Me.cmdClearCLFilter.Caption = "Clear Filter"
        Me.cmdClearCLFilter.Glyph = CType(resources.GetObject("cmdClearCLFilter.Glyph"), System.Drawing.Image)
        Me.cmdClearCLFilter.Id = 7
        Me.cmdClearCLFilter.Name = "cmdClearCLFilter"
        Me.cmdClearCLFilter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'TravelEventV2
        '
        Me.TravelEventV2.AllowAllUp = True
        Me.TravelEventV2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.TravelEventV2.Caption = "Joining"
        Me.TravelEventV2.Description = "Travel"
        Me.TravelEventV2.Glyph = CType(resources.GetObject("TravelEventV2.Glyph"), System.Drawing.Image)
        Me.TravelEventV2.GroupIndex = 1
        Me.TravelEventV2.Id = 80
        Me.TravelEventV2.LargeWidth = 80
        Me.TravelEventV2.Name = "TravelEventV2"
        Me.TravelEventV2.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'TravelEvent_Returning
        '
        Me.TravelEvent_Returning.AllowAllUp = True
        Me.TravelEvent_Returning.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.TravelEvent_Returning.Caption = "Returning"
        Me.TravelEvent_Returning.Glyph = CType(resources.GetObject("TravelEvent_Returning.Glyph"), System.Drawing.Image)
        Me.TravelEvent_Returning.GroupIndex = 1
        Me.TravelEvent_Returning.Id = 81
        Me.TravelEvent_Returning.LargeWidth = 80
        Me.TravelEvent_Returning.Name = "TravelEvent_Returning"
        Me.TravelEvent_Returning.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'CrewChecklist
        '
        Me.CrewChecklist.AllowAllUp = True
        Me.CrewChecklist.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CrewChecklist.Caption = "Crew Checklist"
        Me.CrewChecklist.Description = "Checklist"
        Me.CrewChecklist.Glyph = CType(resources.GetObject("CrewChecklist.Glyph"), System.Drawing.Image)
        Me.CrewChecklist.GroupIndex = 1
        Me.CrewChecklist.Id = 1
        Me.CrewChecklist.LargeWidth = 100
        Me.CrewChecklist.Name = "CrewChecklist"
        Me.CrewChecklist.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'txtServerName
        '
        Me.txtServerName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.txtServerName.Caption = "ServerName"
        Me.txtServerName.Id = 6
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.TextAlignment = System.Drawing.StringAlignment.Near
        Me.txtServerName.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'txtUserName
        '
        Me.txtUserName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.txtUserName.Caption = "UserName"
        Me.txtUserName.Id = 7
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'NotifExpDocs
        '
        Me.NotifExpDocs.Caption = "Expiring Documents"
        Me.NotifExpDocs.Description = "Crew"
        Me.NotifExpDocs.Glyph = CType(resources.GetObject("NotifExpDocs.Glyph"), System.Drawing.Image)
        Me.NotifExpDocs.Id = 8
        Me.NotifExpDocs.LargeWidth = 80
        Me.NotifExpDocs.Name = "NotifExpDocs"
        Me.NotifExpDocs.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Caption = "Refresh List"
        Me.cmdRefresh.Glyph = CType(resources.GetObject("cmdRefresh.Glyph"), System.Drawing.Image)
        Me.cmdRefresh.Id = 8
        Me.cmdRefresh.LargeWidth = 60
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarDockingMenuItem1
        '
        Me.BarDockingMenuItem1.Caption = "BarDockingMenuItem1"
        Me.BarDockingMenuItem1.Id = 24
        Me.BarDockingMenuItem1.Name = "BarDockingMenuItem1"
        '
        'cmdExpCrewList
        '
        Me.cmdExpCrewList.Caption = "Export Crew List"
        Me.cmdExpCrewList.Glyph = CType(resources.GetObject("cmdExpCrewList.Glyph"), System.Drawing.Image)
        Me.cmdExpCrewList.Id = 26
        Me.cmdExpCrewList.Name = "cmdExpCrewList"
        '
        'Training
        '
        Me.Training.AllowAllUp = True
        Me.Training.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Training.Caption = "Training"
        Me.Training.Description = "Crew"
        Me.Training.Glyph = CType(resources.GetObject("Training.Glyph"), System.Drawing.Image)
        Me.Training.GroupIndex = 1
        Me.Training.Id = 28
        Me.Training.Name = "Training"
        Me.Training.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Training.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'AshCrewWages
        '
        Me.AshCrewWages.AllowAllUp = True
        Me.AshCrewWages.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.AshCrewWages.Caption = "Ashore Crew Wages"
        Me.AshCrewWages.Description = "Ashore Wages"
        Me.AshCrewWages.Glyph = CType(resources.GetObject("AshCrewWages.Glyph"), System.Drawing.Image)
        Me.AshCrewWages.GroupIndex = 1
        Me.AshCrewWages.Id = 30
        Me.AshCrewWages.Name = "AshCrewWages"
        Me.AshCrewWages.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'CrewAmortization
        '
        Me.CrewAmortization.AllowAllUp = True
        Me.CrewAmortization.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CrewAmortization.Caption = "Crew Amortization"
        Me.CrewAmortization.Description = "Ashore Wages"
        Me.CrewAmortization.Glyph = CType(resources.GetObject("CrewAmortization.Glyph"), System.Drawing.Image)
        Me.CrewAmortization.GroupIndex = 1
        Me.CrewAmortization.Id = 46
        Me.CrewAmortization.LargeWidth = 90
        Me.CrewAmortization.Name = "CrewAmortization"
        Me.CrewAmortization.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'ReassignCrewRequest
        '
        Me.ReassignCrewRequest.AllowAllUp = True
        Me.ReassignCrewRequest.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReassignCrewRequest.Caption = "Request"
        Me.ReassignCrewRequest.Glyph = CType(resources.GetObject("ReassignCrewRequest.Glyph"), System.Drawing.Image)
        Me.ReassignCrewRequest.GroupIndex = 1
        Me.ReassignCrewRequest.Id = 32
        Me.ReassignCrewRequest.Name = "ReassignCrewRequest"
        Me.ReassignCrewRequest.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ReassignCrewConfirm
        '
        Me.ReassignCrewConfirm.AllowAllUp = True
        Me.ReassignCrewConfirm.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReassignCrewConfirm.Caption = "Confirm"
        Me.ReassignCrewConfirm.Glyph = CType(resources.GetObject("ReassignCrewConfirm.Glyph"), System.Drawing.Image)
        Me.ReassignCrewConfirm.GroupIndex = 1
        Me.ReassignCrewConfirm.Id = 33
        Me.ReassignCrewConfirm.Name = "ReassignCrewConfirm"
        Me.ReassignCrewConfirm.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdViewRecordSum
        '
        Me.cmdViewRecordSum.Caption = "View Record Summary"
        Me.cmdViewRecordSum.Glyph = CType(resources.GetObject("cmdViewRecordSum.Glyph"), System.Drawing.Image)
        Me.cmdViewRecordSum.Id = 34
        Me.cmdViewRecordSum.Name = "cmdViewRecordSum"
        '
        'cmdHideRequest
        '
        Me.cmdHideRequest.Caption = "Hide Request"
        Me.cmdHideRequest.Glyph = CType(resources.GetObject("cmdHideRequest.Glyph"), System.Drawing.Image)
        Me.cmdHideRequest.Id = 48
        Me.cmdHideRequest.Name = "cmdHideRequest"
        Me.cmdHideRequest.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'OnbCrewWages
        '
        Me.OnbCrewWages.AllowAllUp = True
        Me.OnbCrewWages.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.OnbCrewWages.Caption = "Onboard Wages"
        Me.OnbCrewWages.Description = "Onboard Wages"
        Me.OnbCrewWages.Glyph = CType(resources.GetObject("OnbCrewWages.Glyph"), System.Drawing.Image)
        Me.OnbCrewWages.GroupIndex = 1
        Me.OnbCrewWages.Id = 49
        Me.OnbCrewWages.Name = "OnbCrewWages"
        Me.OnbCrewWages.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Government_Report
        '
        Me.Government_Report.ActAsDropDown = True
        Me.Government_Report.AllowAllUp = True
        Me.Government_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
        Me.Government_Report.Caption = "Government"
        Me.Government_Report.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Government_Report.DropDownControl = Me.ReportsGovMenu
        Me.Government_Report.Glyph = CType(resources.GetObject("Government_Report.Glyph"), System.Drawing.Image)
        Me.Government_Report.GroupIndex = 2
        Me.Government_Report.Id = 49
        Me.Government_Report.LargeGlyph = CType(resources.GetObject("Government_Report.LargeGlyph"), System.Drawing.Image)
        Me.Government_Report.Name = "Government_Report"
        Me.Government_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ReportsGovMenu
        '
        Me.ReportsGovMenu.ItemLinks.Add(Me.ReportGovIndi_Report)
        Me.ReportsGovMenu.ItemLinks.Add(Me.ReportGovMonthly_Report)
        Me.ReportsGovMenu.Name = "ReportsGovMenu"
        Me.ReportsGovMenu.Ribbon = Me.RibbonControl
        '
        'ReportGovIndi_Report
        '
        Me.ReportGovIndi_Report.AllowAllUp = True
        Me.ReportGovIndi_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReportGovIndi_Report.Caption = "Individual"
        Me.ReportGovIndi_Report.Description = "Government"
        Me.ReportGovIndi_Report.Glyph = CType(resources.GetObject("ReportGovIndi_Report.Glyph"), System.Drawing.Image)
        Me.ReportGovIndi_Report.GroupIndex = 1
        Me.ReportGovIndi_Report.Id = 142
        Me.ReportGovIndi_Report.Name = "ReportGovIndi_Report"
        Me.ReportGovIndi_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.ReportGovIndi_Report.Tag = "Individual Government Report"
        '
        'ReportGovMonthly_Report
        '
        Me.ReportGovMonthly_Report.AllowAllUp = True
        Me.ReportGovMonthly_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReportGovMonthly_Report.Caption = "Monthly"
        Me.ReportGovMonthly_Report.Description = "Government"
        Me.ReportGovMonthly_Report.Glyph = CType(resources.GetObject("ReportGovMonthly_Report.Glyph"), System.Drawing.Image)
        Me.ReportGovMonthly_Report.GroupIndex = 1
        Me.ReportGovMonthly_Report.Id = 145
        Me.ReportGovMonthly_Report.Name = "ReportGovMonthly_Report"
        Me.ReportGovMonthly_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.ReportGovMonthly_Report.Tag = "Monthly Government Report"
        '
        'btnViewRelatives
        '
        Me.btnViewRelatives.Caption = "View Relatives"
        Me.btnViewRelatives.Id = 48
        Me.btnViewRelatives.Name = "btnViewRelatives"
        Me.btnViewRelatives.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'Remittances
        '
        Me.Remittances.AllowAllUp = True
        Me.Remittances.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Remittances.Caption = "Remittances"
        Me.Remittances.Description = "Ashore Wages"
        Me.Remittances.Glyph = CType(resources.GetObject("Remittances.Glyph"), System.Drawing.Image)
        Me.Remittances.GroupIndex = 1
        Me.Remittances.Id = 49
        Me.Remittances.Name = "Remittances"
        Me.Remittances.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'MedicalHis
        '
        Me.MedicalHis.AllowAllUp = True
        Me.MedicalHis.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.MedicalHis.Caption = "Medical History"
        Me.MedicalHis.Description = "Crew"
        Me.MedicalHis.Glyph = CType(resources.GetObject("MedicalHis.Glyph"), System.Drawing.Image)
        Me.MedicalHis.GroupIndex = 1
        Me.MedicalHis.Id = 49
        Me.MedicalHis.Name = "MedicalHis"
        Me.MedicalHis.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ReassignCrewHistory
        '
        Me.ReassignCrewHistory.AllowAllUp = True
        Me.ReassignCrewHistory.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReassignCrewHistory.Caption = "History"
        Me.ReassignCrewHistory.Glyph = CType(resources.GetObject("ReassignCrewHistory.Glyph"), System.Drawing.Image)
        Me.ReassignCrewHistory.GroupIndex = 1
        Me.ReassignCrewHistory.Id = 51
        Me.ReassignCrewHistory.Name = "ReassignCrewHistory"
        Me.ReassignCrewHistory.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'LTP
        '
        Me.LTP.AllowAllUp = True
        Me.LTP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.LTP.Caption = "Graphical Planning"
        Me.LTP.Description = "Graphical Planning"
        Me.LTP.Glyph = CType(resources.GetObject("LTP.Glyph"), System.Drawing.Image)
        Me.LTP.GroupIndex = 1
        Me.LTP.Id = 51
        Me.LTP.LargeWidth = 80
        Me.LTP.Name = "LTP"
        Me.LTP.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'LTPScaler
        '
        Me.LTPScaler.Caption = "Scaler:"
        Me.LTPScaler.Edit = Me.LTPTrackbar
        Me.LTPScaler.Id = 52
        Me.LTPScaler.Name = "LTPScaler"
        Me.LTPScaler.Width = 200
        '
        'LTPTrackbar
        '
        Me.LTPTrackbar.LabelAppearance.Options.UseTextOptions = True
        Me.LTPTrackbar.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LTPTrackbar.LargeChange = 10
        Me.LTPTrackbar.Maximum = 100
        Me.LTPTrackbar.Minimum = 50
        Me.LTPTrackbar.Name = "LTPTrackbar"
        Me.LTPTrackbar.SmallChange = 5
        Me.LTPTrackbar.TickFrequency = 10
        Me.LTPTrackbar.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'barLTPLUE
        '
        Me.barLTPLUE.Caption = ":"
        Me.barLTPLUE.Edit = Me.lueLTPFilter
        Me.barLTPLUE.Id = 56
        Me.barLTPLUE.Name = "barLTPLUE"
        Me.barLTPLUE.Width = 150
        '
        'lueLTPFilter
        '
        Me.lueLTPFilter.AutoHeight = False
        Me.lueLTPFilter.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueLTPFilter.DisplayMember = "Name"
        Me.lueLTPFilter.Name = "lueLTPFilter"
        Me.lueLTPFilter.NullText = " "
        Me.lueLTPFilter.ShowFooter = False
        Me.lueLTPFilter.ShowHeader = False
        Me.lueLTPFilter.ValueMember = "PKey"
        '
        'barLTPChk
        '
        Me.barLTPChk.Edit = Me.chkLTPShowAll
        Me.barLTPChk.Id = 58
        Me.barLTPChk.Name = "barLTPChk"
        Me.barLTPChk.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.barLTPChk.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.barLTPChk.Width = 150
        '
        'chkLTPShowAll
        '
        Me.chkLTPShowAll.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkLTPShowAll.Appearance.Options.UseBackColor = True
        Me.chkLTPShowAll.AutoHeight = False
        Me.chkLTPShowAll.Caption = "Show All Vessels:"
        Me.chkLTPShowAll.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.chkLTPShowAll.Name = "chkLTPShowAll"
        '
        'Other_Report
        '
        Me.Other_Report.AllowAllUp = True
        Me.Other_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Other_Report.Caption = "Others"
        Me.Other_Report.Description = "Reports"
        Me.Other_Report.Glyph = CType(resources.GetObject("Other_Report.Glyph"), System.Drawing.Image)
        Me.Other_Report.GroupIndex = 1
        Me.Other_Report.Id = 59
        Me.Other_Report.Name = "Other_Report"
        Me.Other_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Other_Report.Tag = "Other"
        '
        'Statistics_Report
        '
        Me.Statistics_Report.AllowAllUp = True
        Me.Statistics_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Statistics_Report.Caption = "Statistics"
        Me.Statistics_Report.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Statistics_Report.Description = "KPI"
        Me.Statistics_Report.Glyph = CType(resources.GetObject("Statistics_Report.Glyph"), System.Drawing.Image)
        Me.Statistics_Report.GroupIndex = 1
        Me.Statistics_Report.Id = 54
        Me.Statistics_Report.Name = "Statistics_Report"
        Me.Statistics_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Statistics_Report.Tag = "Statistics"
        '
        'barLUEFilterMode
        '
        Me.barLUEFilterMode.Caption = "Filter by:"
        Me.barLUEFilterMode.Edit = Me.repLTPFilterMode
        Me.barLUEFilterMode.Id = 61
        Me.barLUEFilterMode.Name = "barLUEFilterMode"
        Me.barLUEFilterMode.Width = 150
        '
        'repLTPFilterMode
        '
        Me.repLTPFilterMode.AutoHeight = False
        Me.repLTPFilterMode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repLTPFilterMode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FilterMode", "FilterMode")})
        Me.repLTPFilterMode.DisplayMember = "FilterMode"
        Me.repLTPFilterMode.DropDownRows = 2
        Me.repLTPFilterMode.Name = "repLTPFilterMode"
        Me.repLTPFilterMode.NullText = " "
        Me.repLTPFilterMode.ShowFooter = False
        Me.repLTPFilterMode.ShowHeader = False
        Me.repLTPFilterMode.ValueMember = "FilterMode"
        '
        'barColorScheme
        '
        Me.barColorScheme.Caption = "Color Scheme:"
        Me.barColorScheme.Edit = Me.repColorSchemes
        Me.barColorScheme.Id = 62
        Me.barColorScheme.Name = "barColorScheme"
        Me.barColorScheme.Width = 150
        '
        'repColorSchemes
        '
        Me.repColorSchemes.AutoHeight = False
        Me.repColorSchemes.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repColorSchemes.DisplayMember = "Caption"
        Me.repColorSchemes.Name = "repColorSchemes"
        Me.repColorSchemes.NullText = "Default"
        Me.repColorSchemes.ShowFooter = False
        Me.repColorSchemes.ShowHeader = False
        Me.repColorSchemes.ValueMember = "Index"
        '
        'PayrollProcessOnb
        '
        Me.PayrollProcessOnb.AllowAllUp = True
        Me.PayrollProcessOnb.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollProcessOnb.Caption = "Process Onboard Payroll"
        Me.PayrollProcessOnb.Description = "Payroll"
        Me.PayrollProcessOnb.Glyph = CType(resources.GetObject("PayrollProcessOnb.Glyph"), System.Drawing.Image)
        Me.PayrollProcessOnb.GroupIndex = 1
        Me.PayrollProcessOnb.Id = 60
        Me.PayrollProcessOnb.Name = "PayrollProcessOnb"
        Me.PayrollProcessOnb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PayrollProcessHA
        '
        Me.PayrollProcessHA.AllowAllUp = True
        Me.PayrollProcessHA.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollProcessHA.Caption = "Process Home Allotment"
        Me.PayrollProcessHA.Description = "Payroll"
        Me.PayrollProcessHA.Glyph = CType(resources.GetObject("PayrollProcessHA.Glyph"), System.Drawing.Image)
        Me.PayrollProcessHA.GroupIndex = 1
        Me.PayrollProcessHA.Id = 61
        Me.PayrollProcessHA.Name = "PayrollProcessHA"
        Me.PayrollProcessHA.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PayrollProcessSA
        '
        Me.PayrollProcessSA.AllowAllUp = True
        Me.PayrollProcessSA.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollProcessSA.Caption = "Process Special Allotment"
        Me.PayrollProcessSA.Description = "Payroll"
        Me.PayrollProcessSA.Glyph = CType(resources.GetObject("PayrollProcessSA.Glyph"), System.Drawing.Image)
        Me.PayrollProcessSA.GroupIndex = 1
        Me.PayrollProcessSA.Id = 62
        Me.PayrollProcessSA.Name = "PayrollProcessSA"
        Me.PayrollProcessSA.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PayrollViewSA
        '
        Me.PayrollViewSA.AllowAllUp = True
        Me.PayrollViewSA.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollViewSA.Caption = "View/Edit Special Allotment"
        Me.PayrollViewSA.Description = "Payroll"
        Me.PayrollViewSA.Glyph = CType(resources.GetObject("PayrollViewSA.Glyph"), System.Drawing.Image)
        Me.PayrollViewSA.GroupIndex = 1
        Me.PayrollViewSA.Id = 63
        Me.PayrollViewSA.Name = "PayrollViewSA"
        Me.PayrollViewSA.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdRunPayroll
        '
        Me.cmdRunPayroll.Caption = "Calculate Pay"
        Me.cmdRunPayroll.Glyph = CType(resources.GetObject("cmdRunPayroll.Glyph"), System.Drawing.Image)
        Me.cmdRunPayroll.Id = 66
        Me.cmdRunPayroll.Name = "cmdRunPayroll"
        Me.cmdRunPayroll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ContractExtension
        '
        Me.ContractExtension.AllowAllUp = True
        Me.ContractExtension.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ContractExtension.Caption = "Contract Extension"
        Me.ContractExtension.Description = "Activity"
        Me.ContractExtension.Glyph = CType(resources.GetObject("ContractExtension.Glyph"), System.Drawing.Image)
        Me.ContractExtension.GroupIndex = 1
        Me.ContractExtension.Id = 63
        Me.ContractExtension.LargeWidth = 80
        Me.ContractExtension.Name = "ContractExtension"
        Me.ContractExtension.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'KPI
        '
        Me.KPI.AllowAllUp = True
        Me.KPI.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.KPI.Caption = "KPI"
        Me.KPI.Description = "KPI"
        Me.KPI.Glyph = CType(resources.GetObject("KPI.Glyph"), System.Drawing.Image)
        Me.KPI.GroupIndex = 1
        Me.KPI.Id = 63
        Me.KPI.Name = "KPI"
        Me.KPI.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnKPIClearFilter
        '
        Me.btnKPIClearFilter.Caption = "Clear Filter"
        Me.btnKPIClearFilter.Glyph = CType(resources.GetObject("btnKPIClearFilter.Glyph"), System.Drawing.Image)
        Me.btnKPIClearFilter.Id = 69
        Me.btnKPIClearFilter.Name = "btnKPIClearFilter"
        Me.btnKPIClearFilter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barKPIChartView
        '
        Me.barKPIChartView.Caption = "Chart View:"
        Me.barKPIChartView.Edit = Me.repKPIChartView
        Me.barKPIChartView.Id = 72
        Me.barKPIChartView.Name = "barKPIChartView"
        Me.barKPIChartView.Width = 70
        '
        'repKPIChartView
        '
        Me.repKPIChartView.AutoHeight = False
        Me.repKPIChartView.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repKPIChartView.DisplayMember = "Name"
        Me.repKPIChartView.DropDownRows = 4
        Me.repKPIChartView.Name = "repKPIChartView"
        Me.repKPIChartView.NullValuePrompt = "Please select a Chart View"
        Me.repKPIChartView.NullValuePromptShowForEmptyValue = True
        Me.repKPIChartView.ShowFooter = False
        Me.repKPIChartView.ShowHeader = False
        Me.repKPIChartView.ValueMember = "PKey"
        '
        'barKPIPrint
        '
        Me.barKPIPrint.Caption = "Print Chart"
        Me.barKPIPrint.Glyph = CType(resources.GetObject("barKPIPrint.Glyph"), System.Drawing.Image)
        Me.barKPIPrint.Id = 73
        Me.barKPIPrint.Name = "barKPIPrint"
        Me.barKPIPrint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barKPIGenerateResult
        '
        Me.barKPIGenerateResult.Caption = "Generate Result"
        Me.barKPIGenerateResult.Glyph = CType(resources.GetObject("barKPIGenerateResult.Glyph"), System.Drawing.Image)
        Me.barKPIGenerateResult.Id = 64
        Me.barKPIGenerateResult.Name = "barKPIGenerateResult"
        Me.barKPIGenerateResult.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barKPIClearChart
        '
        Me.barKPIClearChart.Caption = "Clear Chart"
        Me.barKPIClearChart.Glyph = CType(resources.GetObject("barKPIClearChart.Glyph"), System.Drawing.Image)
        Me.barKPIClearChart.Id = 65
        Me.barKPIClearChart.Name = "barKPIClearChart"
        Me.barKPIClearChart.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnCrewComments
        '
        Me.btnCrewComments.Caption = "Crew Comments"
        Me.btnCrewComments.Glyph = CType(resources.GetObject("btnCrewComments.Glyph"), System.Drawing.Image)
        Me.btnCrewComments.Id = 66
        Me.btnCrewComments.LargeWidth = 100
        Me.btnCrewComments.Name = "btnCrewComments"
        Me.btnCrewComments.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'PayrollViewHA
        '
        Me.PayrollViewHA.AllowAllUp = True
        Me.PayrollViewHA.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollViewHA.Caption = "View/Edit Home Allotment"
        Me.PayrollViewHA.Description = "Payroll"
        Me.PayrollViewHA.Glyph = CType(resources.GetObject("PayrollViewHA.Glyph"), System.Drawing.Image)
        Me.PayrollViewHA.GroupIndex = 1
        Me.PayrollViewHA.Id = 67
        Me.PayrollViewHA.Name = "PayrollViewHA"
        Me.PayrollViewHA.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PayrollOnboard_Report
        '
        Me.PayrollOnboard_Report.AllowAllUp = True
        Me.PayrollOnboard_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollOnboard_Report.Caption = "Onboard"
        Me.PayrollOnboard_Report.Description = "Payroll Reports"
        Me.PayrollOnboard_Report.Glyph = CType(resources.GetObject("PayrollOnboard_Report.Glyph"), System.Drawing.Image)
        Me.PayrollOnboard_Report.GroupIndex = 1
        Me.PayrollOnboard_Report.Id = 74
        Me.PayrollOnboard_Report.Name = "PayrollOnboard_Report"
        Me.PayrollOnboard_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.PayrollOnboard_Report.Tag = "Onboard Payroll"
        '
        'PayrollHA_Report
        '
        Me.PayrollHA_Report.AllowAllUp = True
        Me.PayrollHA_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollHA_Report.Caption = "Home Allotment"
        Me.PayrollHA_Report.Description = "Payroll Reports"
        Me.PayrollHA_Report.Glyph = CType(resources.GetObject("PayrollHA_Report.Glyph"), System.Drawing.Image)
        Me.PayrollHA_Report.GroupIndex = 1
        Me.PayrollHA_Report.Id = 75
        Me.PayrollHA_Report.Name = "PayrollHA_Report"
        Me.PayrollHA_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.PayrollHA_Report.Tag = "Home Allotment Payroll"
        '
        'PayrollSA_Report
        '
        Me.PayrollSA_Report.AllowAllUp = True
        Me.PayrollSA_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollSA_Report.Caption = "Special Allotment"
        Me.PayrollSA_Report.Description = "Payroll Reports"
        Me.PayrollSA_Report.Glyph = CType(resources.GetObject("PayrollSA_Report.Glyph"), System.Drawing.Image)
        Me.PayrollSA_Report.GroupIndex = 1
        Me.PayrollSA_Report.Id = 76
        Me.PayrollSA_Report.Name = "PayrollSA_Report"
        Me.PayrollSA_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.PayrollSA_Report.Tag = "Special Allotment Payroll"
        '
        'PayrollDisketting_Report
        '
        Me.PayrollDisketting_Report.AllowAllUp = True
        Me.PayrollDisketting_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollDisketting_Report.Caption = "Disketting"
        Me.PayrollDisketting_Report.Description = "Payroll Reports"
        Me.PayrollDisketting_Report.Glyph = CType(resources.GetObject("PayrollDisketting_Report.Glyph"), System.Drawing.Image)
        Me.PayrollDisketting_Report.GroupIndex = 1
        Me.PayrollDisketting_Report.Id = 77
        Me.PayrollDisketting_Report.Name = "PayrollDisketting_Report"
        Me.PayrollDisketting_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.PayrollDisketting_Report.Tag = "Disketting Payroll"
        '
        'PayrollCompanySpecific_Report
        '
        Me.PayrollCompanySpecific_Report.AllowAllUp = True
        Me.PayrollCompanySpecific_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollCompanySpecific_Report.Caption = "Company Specific"
        Me.PayrollCompanySpecific_Report.Description = "Payroll Reports"
        Me.PayrollCompanySpecific_Report.Glyph = CType(resources.GetObject("PayrollCompanySpecific_Report.Glyph"), System.Drawing.Image)
        Me.PayrollCompanySpecific_Report.GroupIndex = 1
        Me.PayrollCompanySpecific_Report.Id = 78
        Me.PayrollCompanySpecific_Report.Name = "PayrollCompanySpecific_Report"
        Me.PayrollCompanySpecific_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.PayrollCompanySpecific_Report.Tag = "Company Specific Payroll"
        '
        'cmdPayrollReports
        '
        Me.cmdPayrollReports.ActAsDropDown = True
        Me.cmdPayrollReports.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
        Me.cmdPayrollReports.Caption = "Payroll Reports"
        Me.cmdPayrollReports.Description = "Payroll Reports"
        Me.cmdPayrollReports.DropDownControl = Me.PayrollReportsMenu
        Me.cmdPayrollReports.Glyph = CType(resources.GetObject("cmdPayrollReports.Glyph"), System.Drawing.Image)
        Me.cmdPayrollReports.GroupIndex = 2
        Me.cmdPayrollReports.Id = 80
        Me.cmdPayrollReports.Name = "cmdPayrollReports"
        Me.cmdPayrollReports.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PayrollReportsMenu
        '
        Me.PayrollReportsMenu.ItemLinks.Add(Me.PayrollOnboard_Report, "O")
        Me.PayrollReportsMenu.ItemLinks.Add(Me.PayrollHA_Report, "H")
        Me.PayrollReportsMenu.ItemLinks.Add(Me.PayrollSA_Report, "S")
        Me.PayrollReportsMenu.ItemLinks.Add(Me.PayrollDisketting_Report, "D")
        Me.PayrollReportsMenu.ItemLinks.Add(Me.PayrollCompanySpecific_Report, "C")
        Me.PayrollReportsMenu.Name = "PayrollReportsMenu"
        Me.PayrollReportsMenu.Ribbon = Me.RibbonControl
        '
        'PayrollViewONB
        '
        Me.PayrollViewONB.AllowAllUp = True
        Me.PayrollViewONB.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayrollViewONB.Caption = "View/Edit Onboard Payroll"
        Me.PayrollViewONB.Description = "Payroll"
        Me.PayrollViewONB.Glyph = CType(resources.GetObject("PayrollViewONB.Glyph"), System.Drawing.Image)
        Me.PayrollViewONB.GroupIndex = 1
        Me.PayrollViewONB.Id = 81
        Me.PayrollViewONB.Name = "PayrollViewONB"
        Me.PayrollViewONB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'CrewCashAdvance
        '
        Me.CrewCashAdvance.AllowAllUp = True
        Me.CrewCashAdvance.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CrewCashAdvance.Caption = "View Advances"
        Me.CrewCashAdvance.Description = "Onboard Wages"
        Me.CrewCashAdvance.Glyph = CType(resources.GetObject("CrewCashAdvance.Glyph"), System.Drawing.Image)
        Me.CrewCashAdvance.GroupIndex = 1
        Me.CrewCashAdvance.Id = 84
        Me.CrewCashAdvance.Name = "CrewCashAdvance"
        Me.CrewCashAdvance.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PayAdvances
        '
        Me.PayAdvances.AllowAllUp = True
        Me.PayAdvances.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PayAdvances.Caption = "Add Advances"
        Me.PayAdvances.Description = "Onboard Wages"
        Me.PayAdvances.Glyph = CType(resources.GetObject("PayAdvances.Glyph"), System.Drawing.Image)
        Me.PayAdvances.GroupIndex = 1
        Me.PayAdvances.Id = 85
        Me.PayAdvances.Name = "PayAdvances"
        Me.PayAdvances.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barKPIChkShowResultOnly
        '
        Me.barKPIChkShowResultOnly.Caption = "Show Result Only"
        Me.barKPIChkShowResultOnly.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText
        Me.barKPIChkShowResultOnly.Id = 84
        Me.barKPIChkShowResultOnly.Name = "barKPIChkShowResultOnly"
        '
        'barKPIColorPalette
        '
        Me.barKPIColorPalette.Caption = "Color Palette"
        Me.barKPIColorPalette.Edit = Me.repKPIColorPalette
        Me.barKPIColorPalette.Id = 85
        Me.barKPIColorPalette.Name = "barKPIColorPalette"
        Me.barKPIColorPalette.Width = 100
        '
        'repKPIColorPalette
        '
        Me.repKPIColorPalette.AutoHeight = False
        Me.repKPIColorPalette.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repKPIColorPalette.DisplayMember = "Name"
        Me.repKPIColorPalette.DropDownRows = 15
        Me.repKPIColorPalette.Name = "repKPIColorPalette"
        Me.repKPIColorPalette.NullValuePrompt = "Please select a Color Palette"
        Me.repKPIColorPalette.NullValuePromptShowForEmptyValue = True
        Me.repKPIColorPalette.ShowFooter = False
        Me.repKPIColorPalette.ShowHeader = False
        Me.repKPIColorPalette.ValueMember = "Name"
        '
        'ArchivedCrews
        '
        Me.ArchivedCrews.AllowAllUp = True
        Me.ArchivedCrews.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ArchivedCrews.Caption = "Archived Crews"
        Me.ArchivedCrews.Glyph = CType(resources.GetObject("ArchivedCrews.Glyph"), System.Drawing.Image)
        Me.ArchivedCrews.GroupIndex = 1
        Me.ArchivedCrews.Id = 85
        Me.ArchivedCrews.LargeGlyph = CType(resources.GetObject("ArchivedCrews.LargeGlyph"), System.Drawing.Image)
        Me.ArchivedCrews.LargeWidth = 70
        Me.ArchivedCrews.Name = "ArchivedCrews"
        '
        'Archived_Report
        '
        Me.Archived_Report.AllowAllUp = True
        Me.Archived_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Archived_Report.Caption = "Reports"
        Me.Archived_Report.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Archived_Report.Glyph = CType(resources.GetObject("Archived_Report.Glyph"), System.Drawing.Image)
        Me.Archived_Report.GroupIndex = 1
        Me.Archived_Report.Id = 88
        Me.Archived_Report.LargeWidth = 70
        Me.Archived_Report.Name = "Archived_Report"
        Me.Archived_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.Archived_Report.Tag = "Individual"
        Me.Archived_Report.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PayrollList
        '
        Me.PayrollList.AllowAllUp = True
        Me.PayrollList.Caption = "Processed Payroll List"
        Me.PayrollList.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.PayrollList.Glyph = CType(resources.GetObject("PayrollList.Glyph"), System.Drawing.Image)
        Me.PayrollList.GroupIndex = 1
        Me.PayrollList.Id = 89
        Me.PayrollList.Name = "PayrollList"
        Me.PayrollList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PlanChecklist
        '
        Me.PlanChecklist.AllowAllUp = True
        Me.PlanChecklist.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PlanChecklist.Caption = "Joining Checklist"
        Me.PlanChecklist.Description = "Checklist"
        Me.PlanChecklist.Glyph = CType(resources.GetObject("PlanChecklist.Glyph"), System.Drawing.Image)
        Me.PlanChecklist.GroupIndex = 1
        Me.PlanChecklist.Id = 90
        Me.PlanChecklist.LargeWidth = 100
        Me.PlanChecklist.Name = "PlanChecklist"
        Me.PlanChecklist.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'bbiManualRefresh
        '
        Me.bbiManualRefresh.Caption = "Refresh Planning List"
        Me.bbiManualRefresh.Glyph = CType(resources.GetObject("bbiManualRefresh.Glyph"), System.Drawing.Image)
        Me.bbiManualRefresh.Id = 92
        Me.bbiManualRefresh.LargeGlyph = CType(resources.GetObject("bbiManualRefresh.LargeGlyph"), System.Drawing.Image)
        Me.bbiManualRefresh.Name = "bbiManualRefresh"
        '
        'beiShowFlaggedColors
        '
        Me.beiShowFlaggedColors.Caption = "Highlight Non-Compliant Crews"
        Me.beiShowFlaggedColors.Edit = Me.RepositoryItemCheckEdit11
        Me.beiShowFlaggedColors.Id = 96
        Me.beiShowFlaggedColors.Name = "beiShowFlaggedColors"
        Me.beiShowFlaggedColors.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        Me.beiShowFlaggedColors.Width = 20
        '
        'RepositoryItemCheckEdit11
        '
        Me.RepositoryItemCheckEdit11.AutoHeight = False
        Me.RepositoryItemCheckEdit11.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit11.Name = "RepositoryItemCheckEdit11"
        '
        'DeleteCrew
        '
        Me.DeleteCrew.Caption = "Delete Crew"
        Me.DeleteCrew.Glyph = CType(resources.GetObject("DeleteCrew.Glyph"), System.Drawing.Image)
        Me.DeleteCrew.Id = 98
        Me.DeleteCrew.Name = "DeleteCrew"
        Me.DeleteCrew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'barKPIShowHideTemplates
        '
        Me.barKPIShowHideTemplates.Caption = "Show Templates"
        Me.barKPIShowHideTemplates.Glyph = CType(resources.GetObject("barKPIShowHideTemplates.Glyph"), System.Drawing.Image)
        Me.barKPIShowHideTemplates.Id = 98
        Me.barKPIShowHideTemplates.LargeGlyph = CType(resources.GetObject("barKPIShowHideTemplates.LargeGlyph"), System.Drawing.Image)
        Me.barKPIShowHideTemplates.Name = "barKPIShowHideTemplates"
        '
        'btnTravelSearch
        '
        Me.btnTravelSearch.Caption = "Search"
        Me.btnTravelSearch.Glyph = CType(resources.GetObject("btnTravelSearch.Glyph"), System.Drawing.Image)
        Me.btnTravelSearch.Id = 98
        Me.btnTravelSearch.Name = "btnTravelSearch"
        Me.btnTravelSearch.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'beLgndOnb
        '
        Me.beLgndOnb.Caption = "Onboard"
        Me.beLgndOnb.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.beLgndOnb.Edit = Me.repLgndOnb
        Me.beLgndOnb.Enabled = False
        Me.beLgndOnb.Id = 108
        Me.beLgndOnb.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Black
        Me.beLgndOnb.ItemAppearance.Disabled.Options.UseForeColor = True
        Me.beLgndOnb.Name = "beLgndOnb"
        '
        'repLgndOnb
        '
        Me.repLgndOnb.AllowFocused = False
        Me.repLgndOnb.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.repLgndOnb.Appearance.Options.UseBackColor = True
        Me.repLgndOnb.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.repLgndOnb.AppearanceDisabled.Options.UseBackColor = True
        Me.repLgndOnb.AutoHeight = False
        Me.repLgndOnb.HideSelection = False
        Me.repLgndOnb.Name = "repLgndOnb"
        Me.repLgndOnb.ReadOnly = True
        '
        'beLgndPln
        '
        Me.beLgndPln.Caption = "Planned"
        Me.beLgndPln.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.beLgndPln.Edit = Me.repLgndPln
        Me.beLgndPln.Enabled = False
        Me.beLgndPln.Id = 109
        Me.beLgndPln.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Black
        Me.beLgndPln.ItemAppearance.Disabled.Options.UseForeColor = True
        Me.beLgndPln.Name = "beLgndPln"
        '
        'repLgndPln
        '
        Me.repLgndPln.AllowFocused = False
        Me.repLgndPln.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.repLgndPln.Appearance.Options.UseBackColor = True
        Me.repLgndPln.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.repLgndPln.AppearanceDisabled.Options.UseBackColor = True
        Me.repLgndPln.AutoHeight = False
        Me.repLgndPln.HideSelection = False
        Me.repLgndPln.Name = "repLgndPln"
        Me.repLgndPln.ReadOnly = True
        '
        'beLgndEdited
        '
        Me.beLgndEdited.Caption = "New/Edited"
        Me.beLgndEdited.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.beLgndEdited.Edit = Me.repLgndEdited
        Me.beLgndEdited.Enabled = False
        Me.beLgndEdited.Id = 110
        Me.beLgndEdited.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Black
        Me.beLgndEdited.ItemAppearance.Disabled.Options.UseForeColor = True
        Me.beLgndEdited.Name = "beLgndEdited"
        '
        'repLgndEdited
        '
        Me.repLgndEdited.AllowFocused = False
        Me.repLgndEdited.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.repLgndEdited.Appearance.Options.UseBackColor = True
        Me.repLgndEdited.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.repLgndEdited.AppearanceDisabled.Options.UseBackColor = True
        Me.repLgndEdited.AutoHeight = False
        Me.repLgndEdited.HideSelection = False
        Me.repLgndEdited.Name = "repLgndEdited"
        Me.repLgndEdited.ReadOnly = True
        '
        'beLgndInvalid
        '
        Me.beLgndInvalid.Caption = "Invalid"
        Me.beLgndInvalid.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.beLgndInvalid.Edit = Me.repLgndInvalid
        Me.beLgndInvalid.Enabled = False
        Me.beLgndInvalid.Id = 111
        Me.beLgndInvalid.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Black
        Me.beLgndInvalid.ItemAppearance.Disabled.Options.UseForeColor = True
        Me.beLgndInvalid.Name = "beLgndInvalid"
        '
        'repLgndInvalid
        '
        Me.repLgndInvalid.AllowFocused = False
        Me.repLgndInvalid.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.repLgndInvalid.Appearance.Options.UseBackColor = True
        Me.repLgndInvalid.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.repLgndInvalid.AppearanceDisabled.Options.UseBackColor = True
        Me.repLgndInvalid.AutoHeight = False
        Me.repLgndInvalid.HideSelection = False
        Me.repLgndInvalid.Name = "repLgndInvalid"
        Me.repLgndInvalid.ReadOnly = True
        '
        'cmdQuickReports
        '
        Me.cmdQuickReports.Caption = "View Quick Reports"
        Me.cmdQuickReports.Glyph = CType(resources.GetObject("cmdQuickReports.Glyph"), System.Drawing.Image)
        Me.cmdQuickReports.Id = 113
        Me.cmdQuickReports.Name = "cmdQuickReports"
        Me.cmdQuickReports.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Email_Profile
        '
        Me.Email_Profile.AllowAllUp = True
        Me.Email_Profile.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Email_Profile.Caption = "Scheduled Emailing"
        Me.Email_Profile.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Email_Profile.Description = "Reports"
        Me.Email_Profile.Glyph = CType(resources.GetObject("Email_Profile.Glyph"), System.Drawing.Image)
        Me.Email_Profile.GroupIndex = 1
        Me.Email_Profile.Id = 112
        Me.Email_Profile.Name = "Email_Profile"
        Me.Email_Profile.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'Email_Config
        '
        Me.Email_Config.AllowAllUp = True
        Me.Email_Config.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Email_Config.Caption = "Email Account"
        Me.Email_Config.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Email_Config.Description = "Reports"
        Me.Email_Config.Glyph = CType(resources.GetObject("Email_Config.Glyph"), System.Drawing.Image)
        Me.Email_Config.GroupIndex = 1
        Me.Email_Config.Id = 113
        Me.Email_Config.Name = "Email_Config"
        Me.Email_Config.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarCheckItem1
        '
        Me.BarCheckItem1.Caption = "BarCheckItem1"
        Me.BarCheckItem1.Id = 143
        Me.BarCheckItem1.Name = "BarCheckItem1"
        '
        'BarCheckItem2
        '
        Me.BarCheckItem2.Caption = "Monthly"
        Me.BarCheckItem2.Id = 144
        Me.BarCheckItem2.Name = "BarCheckItem2"
        '
        'BarCheckItem3
        '
        Me.BarCheckItem3.Caption = "BarCheckItem3"
        Me.BarCheckItem3.Id = 1
        Me.BarCheckItem3.Name = "BarCheckItem3"
        '
        'ReportConfig
        '
        Me.ReportConfig.AllowAllUp = True
        Me.ReportConfig.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReportConfig.Caption = "Report Configuration"
        Me.ReportConfig.Glyph = CType(resources.GetObject("ReportConfig.Glyph"), System.Drawing.Image)
        Me.ReportConfig.GroupIndex = 1
        Me.ReportConfig.Id = 142
        Me.ReportConfig.Name = "ReportConfig"
        Me.ReportConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdHelp
        '
        Me.cmdHelp.Caption = "Help"
        Me.cmdHelp.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdHelp.Glyph = CType(resources.GetObject("cmdHelp.Glyph"), System.Drawing.Image)
        Me.cmdHelp.Id = 18
        Me.cmdHelp.Name = "cmdHelp"
        '
        'KPIConfig
        '
        Me.KPIConfig.AllowAllUp = True
        Me.KPIConfig.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.KPIConfig.Caption = "KPI Config"
        Me.KPIConfig.Glyph = CType(resources.GetObject("KPIConfig.Glyph"), System.Drawing.Image)
        Me.KPIConfig.GroupIndex = 1
        Me.KPIConfig.Id = 18
        Me.KPIConfig.Name = "KPIConfig"
        Me.KPIConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdGenCAImpTemplate
        '
        Me.cmdGenCAImpTemplate.Caption = "Generate CA Import Template"
        Me.cmdGenCAImpTemplate.Glyph = CType(resources.GetObject("cmdGenCAImpTemplate.Glyph"), System.Drawing.Image)
        Me.cmdGenCAImpTemplate.Id = 3
        Me.cmdGenCAImpTemplate.Name = "cmdGenCAImpTemplate"
        Me.cmdGenCAImpTemplate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdImportFromExcel
        '
        Me.cmdImportFromExcel.Caption = "Import CA From Excel"
        Me.cmdImportFromExcel.Glyph = CType(resources.GetObject("cmdImportFromExcel.Glyph"), System.Drawing.Image)
        Me.cmdImportFromExcel.Id = 19
        Me.cmdImportFromExcel.Name = "cmdImportFromExcel"
        Me.cmdImportFromExcel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'UniformIssuance
        '
        Me.UniformIssuance.AllowAllUp = True
        Me.UniformIssuance.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.UniformIssuance.Caption = "Uniform"
        Me.UniformIssuance.Description = "Crew"
        Me.UniformIssuance.Glyph = CType(resources.GetObject("UniformIssuance.Glyph"), System.Drawing.Image)
        Me.UniformIssuance.GroupIndex = 1
        Me.UniformIssuance.Id = 29
        Me.UniformIssuance.Name = "UniformIssuance"
        Me.UniformIssuance.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'legendHigh
        '
        Me.legendHigh.Caption = "Has Lacking/Expired Document"
        Me.legendHigh.Glyph = CType(resources.GetObject("legendHigh.Glyph"), System.Drawing.Image)
        Me.legendHigh.Id = 32
        Me.legendHigh.Name = "legendHigh"
        Me.legendHigh.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'legendMedium
        '
        Me.legendMedium.Caption = "Has Document To Expire"
        Me.legendMedium.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.legendMedium.Glyph = CType(resources.GetObject("legendMedium.Glyph"), System.Drawing.Image)
        Me.legendMedium.Id = 33
        Me.legendMedium.Name = "legendMedium"
        Me.legendMedium.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'legendLow
        '
        Me.legendLow.Caption = "[Optional] Has Document To Expire"
        Me.legendLow.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.legendLow.Glyph = CType(resources.GetObject("legendLow.Glyph"), System.Drawing.Image)
        Me.legendLow.Id = 34
        Me.legendLow.Name = "legendLow"
        Me.legendLow.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'barChkShowAllPlanning
        '
        Me.barChkShowAllPlanning.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barChkShowAllPlanning.Edit = Me.ChkShowAllPlanning
        Me.barChkShowAllPlanning.Id = 47
        Me.barChkShowAllPlanning.Name = "barChkShowAllPlanning"
        Me.barChkShowAllPlanning.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.barChkShowAllPlanning.Width = 130
        '
        'ChkShowAllPlanning
        '
        Me.ChkShowAllPlanning.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ChkShowAllPlanning.Appearance.Options.UseBackColor = True
        Me.ChkShowAllPlanning.AutoHeight = False
        Me.ChkShowAllPlanning.Caption = "Show All Planning"
        Me.ChkShowAllPlanning.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ChkShowAllPlanning.Name = "ChkShowAllPlanning"
        '
        'cmdQuickFilter
        '
        Me.cmdQuickFilter.ActAsDropDown = True
        Me.cmdQuickFilter.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.cmdQuickFilter.Caption = "Quick Filter"
        Me.cmdQuickFilter.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdQuickFilter.DropDownControl = Me.menuQuickFilter
        Me.cmdQuickFilter.Glyph = CType(resources.GetObject("cmdQuickFilter.Glyph"), System.Drawing.Image)
        Me.cmdQuickFilter.Id = 47
        Me.cmdQuickFilter.Name = "cmdQuickFilter"
        '
        'menuQuickFilter
        '
        Me.menuQuickFilter.ItemLinks.Add(Me.cmdFilterONB)
        Me.menuQuickFilter.ItemLinks.Add(Me.cmdFilterAshore)
        Me.menuQuickFilter.ItemLinks.Add(Me.cmdFilterPlanning)
        Me.menuQuickFilter.ItemLinks.Add(Me.cmdClearQuickFilter)
        Me.menuQuickFilter.Name = "menuQuickFilter"
        Me.menuQuickFilter.Ribbon = Me.RibbonControl
        '
        'cmdFilterONB
        '
        Me.cmdFilterONB.Caption = "Onboard Crews"
        Me.cmdFilterONB.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdFilterONB.Glyph = CType(resources.GetObject("cmdFilterONB.Glyph"), System.Drawing.Image)
        Me.cmdFilterONB.Id = 48
        Me.cmdFilterONB.Name = "cmdFilterONB"
        '
        'cmdFilterAshore
        '
        Me.cmdFilterAshore.Caption = "Ashore Crews"
        Me.cmdFilterAshore.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdFilterAshore.Glyph = CType(resources.GetObject("cmdFilterAshore.Glyph"), System.Drawing.Image)
        Me.cmdFilterAshore.Id = 50
        Me.cmdFilterAshore.Name = "cmdFilterAshore"
        '
        'cmdFilterPlanning
        '
        Me.cmdFilterPlanning.Caption = "Crews w/ Planning"
        Me.cmdFilterPlanning.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdFilterPlanning.Glyph = CType(resources.GetObject("cmdFilterPlanning.Glyph"), System.Drawing.Image)
        Me.cmdFilterPlanning.Id = 49
        Me.cmdFilterPlanning.Name = "cmdFilterPlanning"
        '
        'cmdClearQuickFilter
        '
        Me.cmdClearQuickFilter.Caption = "Clear"
        Me.cmdClearQuickFilter.Id = 51
        Me.cmdClearQuickFilter.Name = "cmdClearQuickFilter"
        Me.cmdClearQuickFilter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'Activity_Docs
        '
        Me.Activity_Docs.Caption = "Activity Documents"
        Me.Activity_Docs.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.Activity_Docs.Glyph = CType(resources.GetObject("Activity_Docs.Glyph"), System.Drawing.Image)
        Me.Activity_Docs.Id = 47
        Me.Activity_Docs.Name = "Activity_Docs"
        Me.Activity_Docs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'CompanySpecific_Report
        '
        Me.CompanySpecific_Report.AllowAllUp = True
        Me.CompanySpecific_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CompanySpecific_Report.Caption = "Company Specific"
        Me.CompanySpecific_Report.Glyph = CType(resources.GetObject("CompanySpecific_Report.Glyph"), System.Drawing.Image)
        Me.CompanySpecific_Report.GroupIndex = 1
        Me.CompanySpecific_Report.Id = 64
        Me.CompanySpecific_Report.Name = "CompanySpecific_Report"
        Me.CompanySpecific_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.CompanySpecific_Report.Tag = "Company Specific"
        '
        'barLUESortMode
        '
        Me.barLUESortMode.Caption = "Sort by:"
        Me.barLUESortMode.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barLUESortMode.Edit = Me.repLTPSortMode
        Me.barLUESortMode.Id = 35
        Me.barLUESortMode.Name = "barLUESortMode"
        Me.barLUESortMode.Width = 150
        '
        'repLTPSortMode
        '
        Me.repLTPSortMode.AutoHeight = False
        Me.repLTPSortMode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repLTPSortMode.DisplayMember = "Name"
        Me.repLTPSortMode.DropDownRows = 3
        Me.repLTPSortMode.Name = "repLTPSortMode"
        Me.repLTPSortMode.NullText = ""
        Me.repLTPSortMode.ShowFooter = False
        Me.repLTPSortMode.ShowHeader = False
        Me.repLTPSortMode.ValueMember = "PKey"
        '
        'barLTPLUESort
        '
        Me.barLTPLUESort.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barLTPLUESort.Edit = Me.lueLTPSort
        Me.barLTPLUESort.Id = 36
        Me.barLTPLUESort.Name = "barLTPLUESort"
        Me.barLTPLUESort.Width = 150
        '
        'lueLTPSort
        '
        Me.lueLTPSort.AutoHeight = False
        Me.lueLTPSort.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueLTPSort.DisplayMember = "Name"
        Me.lueLTPSort.DropDownRows = 2
        Me.lueLTPSort.Name = "lueLTPSort"
        Me.lueLTPSort.NullText = ""
        Me.lueLTPSort.ShowFooter = False
        Me.lueLTPSort.ShowHeader = False
        Me.lueLTPSort.ValueMember = "PKey"
        '
        'CrewTraining_Report
        '
        Me.CrewTraining_Report.AllowAllUp = True
        Me.CrewTraining_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CrewTraining_Report.Caption = "Crew Training"
        Me.CrewTraining_Report.Description = "Reports"
        Me.CrewTraining_Report.Glyph = CType(resources.GetObject("CrewTraining_Report.Glyph"), System.Drawing.Image)
        Me.CrewTraining_Report.GroupIndex = 1
        Me.CrewTraining_Report.Id = 66
        Me.CrewTraining_Report.Name = "CrewTraining_Report"
        Me.CrewTraining_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.CrewTraining_Report.Tag = "Crew Training"
        '
        'AllCrew_Report
        '
        Me.AllCrew_Report.AllowAllUp = True
        Me.AllCrew_Report.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.AllCrew_Report.Caption = "All Crew"
        Me.AllCrew_Report.Glyph = CType(resources.GetObject("AllCrew_Report.Glyph"), System.Drawing.Image)
        Me.AllCrew_Report.GroupIndex = 1
        Me.AllCrew_Report.Id = 67
        Me.AllCrew_Report.Name = "AllCrew_Report"
        Me.AllCrew_Report.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.AllCrew_Report.Tag = "All Crew"
        '
        'barLTPSelectVesselRank
        '
        Me.barLTPSelectVesselRank.Caption = "Filter Vessel(s)"
        Me.barLTPSelectVesselRank.Glyph = CType(resources.GetObject("barLTPSelectVesselRank.Glyph"), System.Drawing.Image)
        Me.barLTPSelectVesselRank.Id = 69
        Me.barLTPSelectVesselRank.Name = "barLTPSelectVesselRank"
        '
        'Travel_GTRS
        '
        Me.Travel_GTRS.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Travel_GTRS.Caption = "Travel"
        Me.Travel_GTRS.Glyph = CType(resources.GetObject("Travel_GTRS.Glyph"), System.Drawing.Image)
        Me.Travel_GTRS.GroupIndex = 1
        Me.Travel_GTRS.Id = 76
        Me.Travel_GTRS.Name = "Travel_GTRS"
        Me.Travel_GTRS.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdCancel
        '
        Me.cmdCancel.Caption = "Cancel"
        Me.cmdCancel.Glyph = CType(resources.GetObject("cmdCancel.Glyph"), System.Drawing.Image)
        Me.cmdCancel.Id = 77
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'GTRSConfig
        '
        Me.GTRSConfig.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.GTRSConfig.Caption = "GTRS Config"
        Me.GTRSConfig.Glyph = CType(resources.GetObject("GTRSConfig.Glyph"), System.Drawing.Image)
        Me.GTRSConfig.GroupIndex = 1
        Me.GTRSConfig.Id = 78
        Me.GTRSConfig.Name = "GTRSConfig"
        Me.GTRSConfig.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Text = "RibbonPageCategory1"
        '
        'Crewing
        '
        Me.Crewing.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgTool, Me.rpgCrewing, Me.rpgActivityDocs, Me.rpgEditOptions})
        Me.Crewing.KeyTip = "CR"
        Me.Crewing.Name = "Crewing"
        Me.Crewing.Text = "Crew"
        '
        'rpgTool
        '
        Me.rpgTool.ItemLinks.Add(Me.cmdRefresh, "RE")
        Me.rpgTool.ItemLinks.Add(Me.cmdSort, "SO")
        Me.rpgTool.ItemLinks.Add(Me.cmdFilter, "F")
        Me.rpgTool.ItemLinks.Add(Me.cmdQuickFilter)
        Me.rpgTool.ItemLinks.Add(Me.cmdClearCLFilter, "CL")
        Me.rpgTool.ItemLinks.Add(Me.cmdExpCrewList, True, "EX")
        Me.rpgTool.ItemLinks.Add(Me.cmdView, True, "V")
        Me.rpgTool.ItemLinks.Add(Me.cmdPrint, "P")
        Me.rpgTool.KeyTip = "0"
        Me.rpgTool.Name = "rpgTool"
        Me.rpgTool.ShowCaptionButton = False
        Me.rpgTool.Text = " "
        '
        'rpgCrewing
        '
        Me.rpgCrewing.ItemLinks.Add(Me.Crew, True, "CE")
        Me.rpgCrewing.ItemLinks.Add(Me.NotifExpDocs, "EP")
        Me.rpgCrewing.ItemLinks.Add(Me.RecordSum, True, "RC")
        Me.rpgCrewing.ItemLinks.Add(Me.Biodata, "B")
        Me.rpgCrewing.ItemLinks.Add(Me.Document, "DO")
        Me.rpgCrewing.ItemLinks.Add(Me.Training, "TR")
        Me.rpgCrewing.ItemLinks.Add(Me.MedicalHis, "M")
        Me.rpgCrewing.ItemLinks.Add(Me.Service, "SE")
        Me.rpgCrewing.ItemLinks.Add(Me.Relative, "RL")
        Me.rpgCrewing.ItemLinks.Add(Me.Appraisal, "AP")
        Me.rpgCrewing.ItemLinks.Add(Me.UniformIssuance)
        Me.rpgCrewing.ItemLinks.Add(Me.CrewListArchive, True, "TA")
        Me.rpgCrewing.ItemLinks.Add(Me.bbiStartArchive, "ST")
        Me.rpgCrewing.ItemLinks.Add(Me.DeleteCrew)
        Me.rpgCrewing.KeyTip = "CR"
        Me.rpgCrewing.Name = "rpgCrewing"
        Me.rpgCrewing.ShowCaptionButton = False
        Me.rpgCrewing.Tag = "1"
        Me.rpgCrewing.Text = "Crew"
        '
        'CrewListArchive
        '
        Me.CrewListArchive.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CrewListArchive.Caption = "Transfer to Archive"
        Me.CrewListArchive.Description = "Crew"
        Me.CrewListArchive.Glyph = CType(resources.GetObject("CrewListArchive.Glyph"), System.Drawing.Image)
        Me.CrewListArchive.GroupIndex = 1
        Me.CrewListArchive.Id = 82
        Me.CrewListArchive.LargeGlyph = CType(resources.GetObject("CrewListArchive.LargeGlyph"), System.Drawing.Image)
        Me.CrewListArchive.Name = "CrewListArchive"
        '
        'bbiStartArchive
        '
        Me.bbiStartArchive.Caption = "Start Transfer to Archive"
        Me.bbiStartArchive.Glyph = CType(resources.GetObject("bbiStartArchive.Glyph"), System.Drawing.Image)
        Me.bbiStartArchive.GroupIndex = 1
        Me.bbiStartArchive.Id = 83
        Me.bbiStartArchive.LargeGlyph = CType(resources.GetObject("bbiStartArchive.LargeGlyph"), System.Drawing.Image)
        Me.bbiStartArchive.Name = "bbiStartArchive"
        Me.bbiStartArchive.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'rpgActivityDocs
        '
        Me.rpgActivityDocs.ItemLinks.Add(Me.Activity_Docs)
        Me.rpgActivityDocs.KeyTip = "D"
        Me.rpgActivityDocs.Name = "rpgActivityDocs"
        Me.rpgActivityDocs.Text = "Activity Documents"
        Me.rpgActivityDocs.Visible = False
        '
        'rpgEditOptions
        '
        Me.rpgEditOptions.ItemLinks.Add(Me.cmdAdd, "AD")
        Me.rpgEditOptions.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.rpgEditOptions.ItemLinks.Add(Me.cmdSave, "SA")
        Me.rpgEditOptions.ItemLinks.Add(Me.cmdDeleteSub, "DE")
        Me.rpgEditOptions.ItemLinks.Add(Me.cmdDelete, "DL")
        Me.rpgEditOptions.ItemLinks.Add(Me.cmdPreviewReport)
        Me.rpgEditOptions.KeyTip = "ED"
        Me.rpgEditOptions.Name = "rpgEditOptions"
        Me.rpgEditOptions.Text = "Editing Options"
        Me.rpgEditOptions.Visible = False
        '
        'Activity
        '
        Me.Activity.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgActRefresh, Me.rpgActTools, Me.rpgActivity, Me.rpgActivityActivityDocs, Me.rpgActivityEditingOptions})
        Me.Activity.KeyTip = "AC"
        Me.Activity.Name = "Activity"
        Me.Activity.Tag = 2
        Me.Activity.Text = "Activity"
        '
        'rpgActRefresh
        '
        Me.rpgActRefresh.ItemLinks.Add(Me.cmdRefresh)
        Me.rpgActRefresh.Name = "rpgActRefresh"
        '
        'rpgActTools
        '
        Me.rpgActTools.ItemLinks.Add(Me.cmdSort, "SO")
        Me.rpgActTools.ItemLinks.Add(Me.cmdFilter, "FL")
        Me.rpgActTools.ItemLinks.Add(Me.cmdClearCLFilter, "CL")
        Me.rpgActTools.KeyTip = "FI"
        Me.rpgActTools.Name = "rpgActTools"
        Me.rpgActTools.Text = "Filter"
        '
        'rpgActivity
        '
        Me.rpgActivity.ItemLinks.Add(Me.SignOn, "SI")
        Me.rpgActivity.ItemLinks.Add(Me.SignOff, "SG")
        Me.rpgActivity.ItemLinks.Add(Me.Promotion, "P")
        Me.rpgActivity.ItemLinks.Add(Me.Transfer, "T")
        Me.rpgActivity.ItemLinks.Add(Me.SickOnboard, "SC")
        Me.rpgActivity.ItemLinks.Add(Me.AshoreActivity, "AS")
        Me.rpgActivity.ItemLinks.Add(Me.CrewActivity_Amend, "AM")
        Me.rpgActivity.ItemLinks.Add(Me.GoBack, "G")
        Me.rpgActivity.ItemLinks.Add(Me.ContractExtension, "CO")
        Me.rpgActivity.KeyTip = "AC"
        Me.rpgActivity.Name = "rpgActivity"
        Me.rpgActivity.Tag = "1"
        Me.rpgActivity.Text = "Activity Options"
        '
        'rpgActivityActivityDocs
        '
        Me.rpgActivityActivityDocs.ItemLinks.Add(Me.Activity_Docs)
        Me.rpgActivityActivityDocs.Name = "rpgActivityActivityDocs"
        Me.rpgActivityActivityDocs.Text = "Activity Documents"
        Me.rpgActivityActivityDocs.Visible = False
        '
        'rpgActivityEditingOptions
        '
        Me.rpgActivityEditingOptions.ItemLinks.Add(Me.cmdSave, "SA")
        Me.rpgActivityEditingOptions.KeyTip = "E"
        Me.rpgActivityEditingOptions.Name = "rpgActivityEditingOptions"
        Me.rpgActivityEditingOptions.Text = "Editing Options"
        '
        'rpLTP
        '
        Me.rpLTP.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgLTPRefresh, Me.RibbonPageGroup2, Me.rpgLTPFilter, Me.rpgLTPSort, Me.RibbonPageGroup5, Me.rpgExport, Me.RibbonPageGroup4, Me.RibbonPageGroup9})
        Me.rpLTP.KeyTip = "G"
        Me.rpLTP.Name = "rpLTP"
        Me.rpLTP.Tag = "2"
        Me.rpLTP.Text = "Graphical Planning"
        '
        'rpgLTPRefresh
        '
        Me.rpgLTPRefresh.ItemLinks.Add(Me.cmdRefresh, "R")
        Me.rpgLTPRefresh.KeyTip = "0"
        Me.rpgLTPRefresh.Name = "rpgLTPRefresh"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.LTP, True, "LP")
        Me.RibbonPageGroup2.KeyTip = "LT"
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Tag = "1"
        Me.RibbonPageGroup2.Text = "Graphical Planning"
        '
        'rpgLTPFilter
        '
        Me.rpgLTPFilter.ItemLinks.Add(Me.barLUEFilterMode, "FL")
        Me.rpgLTPFilter.ItemLinks.Add(Me.barLTPLUE, ":")
        Me.rpgLTPFilter.ItemLinks.Add(Me.barLTPSelectVesselRank, True)
        Me.rpgLTPFilter.ItemLinks.Add(Me.barLTPChk)
        Me.rpgLTPFilter.KeyTip = "FI"
        Me.rpgLTPFilter.Name = "rpgLTPFilter"
        Me.rpgLTPFilter.Text = "Filter Options"
        '
        'rpgLTPSort
        '
        Me.rpgLTPSort.ItemLinks.Add(Me.barLUESortMode, "SO")
        Me.rpgLTPSort.ItemLinks.Add(Me.barLTPLUESort)
        Me.rpgLTPSort.KeyTip = "SO"
        Me.rpgLTPSort.Name = "rpgLTPSort"
        Me.rpgLTPSort.Text = "Sort Options"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.RibbonPageGroup5.ItemLinks.Add(Me.cmdSave, "SA")
        Me.RibbonPageGroup5.ItemLinks.Add(Me.cmdDelete, "DE")
        Me.RibbonPageGroup5.KeyTip = "ED"
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "Editing Options"
        '
        'rpgExport
        '
        Me.rpgExport.ItemLinks.Add(Me.cmdExport)
        Me.rpgExport.Name = "rpgExport"
        Me.rpgExport.Text = "Export Data"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.barColorScheme, "C")
        Me.RibbonPageGroup4.ItemLinks.Add(Me.LTPScaler, "SC")
        Me.RibbonPageGroup4.KeyTip = "DI"
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "Display Options"
        '
        'RibbonPageGroup9
        '
        Me.RibbonPageGroup9.ItemLinks.Add(Me.beLgndOnb)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.beLgndPln)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.beLgndEdited, True)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.beLgndInvalid)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.legendHigh, True)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.legendMedium)
        Me.RibbonPageGroup9.ItemLinks.Add(Me.legendLow)
        Me.RibbonPageGroup9.Name = "RibbonPageGroup9"
        Me.RibbonPageGroup9.Text = "Legend"
        '
        'rpPlanning
        '
        Me.rpPlanning.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgPlanning, Me.rpgPlanningFilter, Me.rpgEditing})
        Me.rpPlanning.KeyTip = "PL"
        Me.rpPlanning.Name = "rpPlanning"
        Me.rpPlanning.Tag = "2"
        Me.rpPlanning.Text = "Planning"
        '
        'rpgPlanning
        '
        Me.rpgPlanning.ItemLinks.Add(Me.Planning, "PA")
        Me.rpgPlanning.KeyTip = "PL"
        Me.rpgPlanning.Name = "rpgPlanning"
        Me.rpgPlanning.Tag = "1"
        Me.rpgPlanning.Text = "Planning Options"
        '
        'rpgPlanningFilter
        '
        Me.rpgPlanningFilter.ItemLinks.Add(Me.barChkShowAllPlanning)
        Me.rpgPlanningFilter.KeyTip = "PF"
        Me.rpgPlanningFilter.Name = "rpgPlanningFilter"
        Me.rpgPlanningFilter.Text = "Filter Options"
        '
        'rpgEditing
        '
        Me.rpgEditing.ItemLinks.Add(Me.cmdAdd, "A")
        Me.rpgEditing.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.rpgEditing.ItemLinks.Add(Me.cmdSave, "S")
        Me.rpgEditing.ItemLinks.Add(Me.cmdDelete, "D")
        Me.rpgEditing.KeyTip = "ED"
        Me.rpgEditing.Name = "rpgEditing"
        Me.rpgEditing.Text = "Editing Options"
        '
        'rpTravel
        '
        Me.rpTravel.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgTravelRefresh, Me.travelGTRS, Me.travelEventRibbon, Me.rpgTravelFilter, Me.rpgTravel_EditingOptions, Me.rpgTravelEventSearch})
        Me.rpTravel.KeyTip = "T"
        Me.rpTravel.Name = "rpTravel"
        Me.rpTravel.Tag = "2"
        Me.rpTravel.Text = "Travel"
        '
        'rpgTravelRefresh
        '
        Me.rpgTravelRefresh.ItemLinks.Add(Me.cmdRefresh)
        Me.rpgTravelRefresh.Name = "rpgTravelRefresh"
        '
        'travelGTRS
        '
        Me.travelGTRS.ItemLinks.Add(Me.Travel_GTRS)
        Me.travelGTRS.ItemLinks.Add(Me.GTRSConfig)
        Me.travelGTRS.Name = "travelGTRS"
        Me.travelGTRS.Tag = "1"
        Me.travelGTRS.Text = "Travel"
        '
        'travelEventRibbon
        '
        Me.travelEventRibbon.ItemLinks.Add(Me.TravelEventV2, "J")
        Me.travelEventRibbon.ItemLinks.Add(Me.TravelEvent_Returning, "R")
        Me.travelEventRibbon.KeyTip = "T"
        Me.travelEventRibbon.Name = "travelEventRibbon"
        Me.travelEventRibbon.Tag = "1"
        Me.travelEventRibbon.Text = "Travel Event Options"
        '
        'rpgTravelFilter
        '
        Me.rpgTravelFilter.ItemLinks.Add(Me.barChkShowAllPlanning)
        Me.rpgTravelFilter.KeyTip = "TF"
        Me.rpgTravelFilter.Name = "rpgTravelFilter"
        Me.rpgTravelFilter.Text = "Filter Options"
        '
        'rpgTravel_EditingOptions
        '
        Me.rpgTravel_EditingOptions.ItemLinks.Add(Me.cmdAdd, "A")
        Me.rpgTravel_EditingOptions.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.rpgTravel_EditingOptions.ItemLinks.Add(Me.cmdSave, "S")
        Me.rpgTravel_EditingOptions.ItemLinks.Add(Me.cmdDelete, "D")
        Me.rpgTravel_EditingOptions.ItemLinks.Add(Me.cmdCancel)
        Me.rpgTravel_EditingOptions.ItemLinks.Add(Me.cmdPreviewReport, "V")
        Me.rpgTravel_EditingOptions.KeyTip = "ED"
        Me.rpgTravel_EditingOptions.Name = "rpgTravel_EditingOptions"
        Me.rpgTravel_EditingOptions.Text = "Editing Options"
        '
        'rpgTravelEventSearch
        '
        Me.rpgTravelEventSearch.ItemLinks.Add(Me.btnTravelSearch)
        Me.rpgTravelEventSearch.Name = "rpgTravelEventSearch"
        Me.rpgTravelEventSearch.Text = "Search Option"
        '
        'rpChecklist
        '
        Me.rpChecklist.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgManualRefresh, Me.rpgFilter, Me.PlanningChecklist, Me.rpgPrintCheckList, Me.rpgIncludeFlaggedColors})
        Me.rpChecklist.KeyTip = "CH"
        Me.rpChecklist.Name = "rpChecklist"
        Me.rpChecklist.Tag = "2"
        Me.rpChecklist.Text = "Check List"
        '
        'rpgManualRefresh
        '
        Me.rpgManualRefresh.ItemLinks.Add(Me.bbiManualRefresh)
        Me.rpgManualRefresh.Name = "rpgManualRefresh"
        Me.rpgManualRefresh.Text = "Refresh"
        Me.rpgManualRefresh.Visible = False
        '
        'rpgFilter
        '
        Me.rpgFilter.ItemLinks.Add(Me.cmdSort)
        Me.rpgFilter.ItemLinks.Add(Me.cmdFilter)
        Me.rpgFilter.ItemLinks.Add(Me.cmdClearCLFilter)
        Me.rpgFilter.Name = "rpgFilter"
        Me.rpgFilter.Text = "Filter"
        '
        'PlanningChecklist
        '
        Me.PlanningChecklist.AllowTextClipping = False
        Me.PlanningChecklist.ItemLinks.Add(Me.CrewChecklist, "PA")
        Me.PlanningChecklist.ItemLinks.Add(Me.PlanChecklist, True)
        Me.PlanningChecklist.KeyTip = "PL"
        Me.PlanningChecklist.Name = "PlanningChecklist"
        Me.PlanningChecklist.Tag = "1"
        Me.PlanningChecklist.Text = "Checklist"
        '
        'rpgPrintCheckList
        '
        Me.rpgPrintCheckList.AllowTextClipping = False
        Me.rpgPrintCheckList.ItemLinks.Add(Me.cmdSave, "S")
        Me.rpgPrintCheckList.ItemLinks.Add(Me.cmdPreviewReport, "V")
        Me.rpgPrintCheckList.KeyTip = "PR"
        Me.rpgPrintCheckList.Name = "rpgPrintCheckList"
        Me.rpgPrintCheckList.Text = "Print Check List"
        '
        'rpgIncludeFlaggedColors
        '
        Me.rpgIncludeFlaggedColors.ItemLinks.Add(Me.beiShowFlaggedColors)
        Me.rpgIncludeFlaggedColors.Name = "rpgIncludeFlaggedColors"
        Me.rpgIncludeFlaggedColors.Text = "Settings"
        '
        'rpCompetence
        '
        Me.rpCompetence.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgQualificationMatrix, Me.rpgPrintOption})
        Me.rpCompetence.KeyTip = "Q"
        Me.rpCompetence.Name = "rpCompetence"
        Me.rpCompetence.Tag = "2"
        Me.rpCompetence.Text = "Qualification"
        '
        'rpgQualificationMatrix
        '
        Me.rpgQualificationMatrix.AllowTextClipping = False
        Me.rpgQualificationMatrix.ItemLinks.Add(Me.QualificationMatrix, "QA")
        Me.rpgQualificationMatrix.KeyTip = "QU"
        Me.rpgQualificationMatrix.Name = "rpgQualificationMatrix"
        Me.rpgQualificationMatrix.Tag = CType(1, Short)
        Me.rpgQualificationMatrix.Text = "Qualification Matrix Option"
        '
        'rpgPrintOption
        '
        Me.rpgPrintOption.ItemLinks.Add(Me.cmdSave)
        Me.rpgPrintOption.ItemLinks.Add(Me.cmdPreviewReport, "V")
        Me.rpgPrintOption.KeyTip = "P"
        Me.rpgPrintOption.Name = "rpgPrintOption"
        Me.rpgPrintOption.Text = "Print Option"
        '
        'rpDMS
        '
        Me.rpDMS.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgCrewFilter, Me.rpgDocViewer, Me.rpgDMSEditOptions, Me.rpgExtract})
        Me.rpDMS.KeyTip = "D"
        Me.rpDMS.Name = "rpDMS"
        Me.rpDMS.Text = "DMS"
        '
        'rpgCrewFilter
        '
        Me.rpgCrewFilter.ItemLinks.Add(Me.cmdSort, "S")
        Me.rpgCrewFilter.ItemLinks.Add(Me.cmdFilter, "FL")
        Me.rpgCrewFilter.ItemLinks.Add(Me.cmdClearCLFilter, "C")
        Me.rpgCrewFilter.KeyTip = "FI"
        Me.rpgCrewFilter.Name = "rpgCrewFilter"
        Me.rpgCrewFilter.Text = "Filter"
        '
        'rpgDocViewer
        '
        Me.rpgDocViewer.ItemLinks.Add(Me.DocViewer, "DC")
        Me.rpgDocViewer.KeyTip = "DO"
        Me.rpgDocViewer.Name = "rpgDocViewer"
        Me.rpgDocViewer.Tag = "1"
        Me.rpgDocViewer.Text = "Document Viewer"
        '
        'rpgDMSEditOptions
        '
        Me.rpgDMSEditOptions.ItemLinks.Add(Me.cmdAdd, "A")
        Me.rpgDMSEditOptions.ItemLinks.Add(Me.cmdDelete, "DE")
        Me.rpgDMSEditOptions.KeyTip = "ED"
        Me.rpgDMSEditOptions.Name = "rpgDMSEditOptions"
        Me.rpgDMSEditOptions.Text = "Editing Options"
        '
        'rpgExtract
        '
        Me.rpgExtract.ItemLinks.Add(Me.cmdDownload, "ET")
        Me.rpgExtract.ItemLinks.Add(Me.cmdPrintFile, "P")
        Me.rpgExtract.KeyTip = "EX"
        Me.rpgExtract.Name = "rpgExtract"
        Me.rpgExtract.Text = "Extraction Options"
        '
        'rpReports
        '
        Me.rpReports.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgReport, Me.rpgReportEditOptions, Me.rpgReportOptions, Me.rpgReportConfig})
        Me.rpReports.KeyTip = "RE"
        Me.rpReports.Name = "rpReports"
        Me.rpReports.Text = "Reports"
        '
        'rpgReport
        '
        Me.rpgReport.ItemLinks.Add(Me.Individual_Report, "I")
        Me.rpgReport.ItemLinks.Add(Me.Onboard_Report, "ON")
        Me.rpgReport.ItemLinks.Add(Me.Planning_Report, "P")
        Me.rpgReport.ItemLinks.Add(Me.History_Report, "H")
        Me.rpgReport.ItemLinks.Add(Me.Ashore_Report, "AS")
        Me.rpgReport.ItemLinks.Add(Me.CrewTraining_Report)
        Me.rpgReport.ItemLinks.Add(Me.AllCrew_Report)
        Me.rpgReport.ItemLinks.Add(Me.Government_Report, "G")
        Me.rpgReport.ItemLinks.Add(Me.Other_Report, "OT")
        Me.rpgReport.ItemLinks.Add(Me.CompanySpecific_Report)
        Me.rpgReport.ItemLinks.Add(Me.ADVANCEDSEARCH, "Q")
        Me.rpgReport.ItemLinks.Add(Me.Email_Profile, True)
        Me.rpgReport.ItemLinks.Add(Me.Email_Config, "EC")
        Me.rpgReport.KeyTip = "RE"
        Me.rpgReport.Name = "rpgReport"
        Me.rpgReport.Tag = CType(1, Short)
        Me.rpgReport.Text = "Report"
        '
        'rpgReportEditOptions
        '
        Me.rpgReportEditOptions.ItemLinks.Add(Me.cmdSave, True, "SA")
        Me.rpgReportEditOptions.ItemLinks.Add(Me.cmdLoadData, "L")
        Me.rpgReportEditOptions.ItemLinks.Add(Me.cmdDelete, "D")
        Me.rpgReportEditOptions.KeyTip = "T"
        Me.rpgReportEditOptions.Name = "rpgReportEditOptions"
        Me.rpgReportEditOptions.Text = "Template Options"
        '
        'rpgReportOptions
        '
        Me.rpgReportOptions.ItemLinks.Add(Me.cmdShowSelectionList, True, "SH")
        Me.rpgReportOptions.ItemLinks.Add(Me.cmdApply, "AP")
        Me.rpgReportOptions.ItemLinks.Add(Me.cmdClearFilter, "C")
        Me.rpgReportOptions.ItemLinks.Add(Me.cmdPreviewReport, True, "V")
        Me.rpgReportOptions.ItemLinks.Add(Me.cmdExport, "E")
        Me.rpgReportOptions.KeyTip = "RP"
        Me.rpgReportOptions.Name = "rpgReportOptions"
        Me.rpgReportOptions.Text = "Report Options"
        '
        'rpgReportConfig
        '
        Me.rpgReportConfig.ItemLinks.Add(Me.ReportConfig)
        Me.rpgReportConfig.Name = "rpgReportConfig"
        Me.rpgReportConfig.Text = "Config"
        '
        'rpKPI
        '
        Me.rpKPI.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgKPI, Me.rpgKPIDisplayOptions, Me.rpgKPITemplateOptions, Me.rpgPrintOptions, Me.rpgKPIReportOptions, Me.rpgKPIConfig})
        Me.rpKPI.KeyTip = "K"
        Me.rpKPI.Name = "rpKPI"
        Me.rpKPI.Text = "KPI"
        '
        'rpgKPI
        '
        Me.rpgKPI.ItemLinks.Add(Me.KPI, "KI")
        Me.rpgKPI.ItemLinks.Add(Me.Statistics_Report)
        Me.rpgKPI.KeyTip = "KP"
        Me.rpgKPI.Name = "rpgKPI"
        Me.rpgKPI.Tag = "1"
        Me.rpgKPI.Text = "KPI"
        '
        'rpgKPIDisplayOptions
        '
        Me.rpgKPIDisplayOptions.ItemLinks.Add(Me.barKPIChartView)
        Me.rpgKPIDisplayOptions.ItemLinks.Add(Me.barKPIChkShowResultOnly)
        Me.rpgKPIDisplayOptions.ItemLinks.Add(Me.barKPIColorPalette, True)
        Me.rpgKPIDisplayOptions.Name = "rpgKPIDisplayOptions"
        Me.rpgKPIDisplayOptions.Text = "Display Options"
        '
        'rpgKPITemplateOptions
        '
        Me.rpgKPITemplateOptions.ItemLinks.Add(Me.barKPIShowHideTemplates)
        Me.rpgKPITemplateOptions.ItemLinks.Add(Me.cmdSave)
        Me.rpgKPITemplateOptions.ItemLinks.Add(Me.cmdLoadData)
        Me.rpgKPITemplateOptions.ItemLinks.Add(Me.cmdDelete)
        Me.rpgKPITemplateOptions.Name = "rpgKPITemplateOptions"
        Me.rpgKPITemplateOptions.Text = "Template Options"
        '
        'rpgPrintOptions
        '
        Me.rpgPrintOptions.ItemLinks.Add(Me.btnKPIClearFilter)
        Me.rpgPrintOptions.ItemLinks.Add(Me.barKPIGenerateResult, True)
        Me.rpgPrintOptions.ItemLinks.Add(Me.barKPIPrint)
        Me.rpgPrintOptions.ItemLinks.Add(Me.barKPIClearChart)
        Me.rpgPrintOptions.Name = "rpgPrintOptions"
        Me.rpgPrintOptions.Text = "Viewing Options"
        '
        'rpgKPIReportOptions
        '
        Me.rpgKPIReportOptions.ItemLinks.Add(Me.cmdShowSelectionList)
        Me.rpgKPIReportOptions.ItemLinks.Add(Me.cmdApply)
        Me.rpgKPIReportOptions.ItemLinks.Add(Me.cmdClearFilter)
        Me.rpgKPIReportOptions.ItemLinks.Add(Me.cmdPreviewReport, True)
        Me.rpgKPIReportOptions.Name = "rpgKPIReportOptions"
        Me.rpgKPIReportOptions.Text = "Report Options"
        '
        'rpgKPIConfig
        '
        Me.rpgKPIConfig.ItemLinks.Add(Me.KPIConfig)
        Me.rpgKPIConfig.Name = "rpgKPIConfig"
        Me.rpgKPIConfig.Text = "Config"
        '
        'rpAshWageAcct
        '
        Me.rpAshWageAcct.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgASHWTool, Me.rpgASHW, Me.rpgAshWages})
        Me.rpAshWageAcct.KeyTip = "AS"
        Me.rpAshWageAcct.Name = "rpAshWageAcct"
        Me.rpAshWageAcct.Text = "Ashore Wages"
        '
        'rpgASHWTool
        '
        Me.rpgASHWTool.ItemLinks.Add(Me.cmdRefresh, "RE")
        Me.rpgASHWTool.ItemLinks.Add(Me.cmdSort, "SO")
        Me.rpgASHWTool.ItemLinks.Add(Me.cmdFilter, "F")
        Me.rpgASHWTool.ItemLinks.Add(Me.cmdClearCLFilter, "CL")
        Me.rpgASHWTool.KeyTip = "0"
        Me.rpgASHWTool.Name = "rpgASHWTool"
        Me.rpgASHWTool.Text = " "
        '
        'rpgASHW
        '
        Me.rpgASHW.ItemLinks.Add(Me.AshCrewWages, "AS")
        Me.rpgASHW.ItemLinks.Add(Me.Remittances, "RM")
        Me.rpgASHW.ItemLinks.Add(Me.CrewAmortization, "CR")
        Me.rpgASHW.KeyTip = "P"
        Me.rpgASHW.Name = "rpgASHW"
        Me.rpgASHW.Tag = 1
        Me.rpgASHW.Text = "Payroll"
        '
        'rpgAshWages
        '
        Me.rpgAshWages.ItemLinks.Add(Me.cmdAdd, "AD")
        Me.rpgAshWages.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.rpgAshWages.ItemLinks.Add(Me.cmdSave, "SA")
        Me.rpgAshWages.ItemLinks.Add(Me.cmdDelete, "D")
        Me.rpgAshWages.KeyTip = "ED"
        Me.rpgAshWages.Name = "rpgAshWages"
        Me.rpgAshWages.Text = "Editing Options"
        '
        'rpOnbWageAcct
        '
        Me.rpOnbWageAcct.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgONBWTool, Me.rpgONBWageAcct, Me.rpgONBWEditOptions, Me.rpgONBImports})
        Me.rpOnbWageAcct.KeyTip = "O"
        Me.rpOnbWageAcct.Name = "rpOnbWageAcct"
        Me.rpOnbWageAcct.Text = "Onboard Wages"
        '
        'rpgONBWTool
        '
        Me.rpgONBWTool.ItemLinks.Add(Me.cmdRefresh, "R")
        Me.rpgONBWTool.ItemLinks.Add(Me.cmdSort, "SO")
        Me.rpgONBWTool.ItemLinks.Add(Me.cmdFilter, "F")
        Me.rpgONBWTool.ItemLinks.Add(Me.cmdClearCLFilter, "C")
        Me.rpgONBWTool.KeyTip = "0"
        Me.rpgONBWTool.Name = "rpgONBWTool"
        Me.rpgONBWTool.Text = " "
        '
        'rpgONBWageAcct
        '
        Me.rpgONBWageAcct.ItemLinks.Add(Me.OnbCrewWages, "OB")
        Me.rpgONBWageAcct.ItemLinks.Add(Me.PayAdvances)
        Me.rpgONBWageAcct.ItemLinks.Add(Me.CrewCashAdvance, "ADV")
        Me.rpgONBWageAcct.KeyTip = "ON"
        Me.rpgONBWageAcct.Name = "rpgONBWageAcct"
        Me.rpgONBWageAcct.Tag = CType(1, Short)
        Me.rpgONBWageAcct.Text = "Onboard Wage Account"
        '
        'rpgONBWEditOptions
        '
        Me.rpgONBWEditOptions.ItemLinks.Add(Me.cmdAdd, "ADD")
        Me.rpgONBWEditOptions.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.rpgONBWEditOptions.ItemLinks.Add(Me.cmdSave, "SA")
        Me.rpgONBWEditOptions.ItemLinks.Add(Me.cmdDelete, "D")
        Me.rpgONBWEditOptions.KeyTip = "ED"
        Me.rpgONBWEditOptions.Name = "rpgONBWEditOptions"
        Me.rpgONBWEditOptions.Text = "Editing Options"
        '
        'rpgONBImports
        '
        Me.rpgONBImports.ItemLinks.Add(Me.cmdGenCAImpTemplate)
        Me.rpgONBImports.ItemLinks.Add(Me.cmdImportFromExcel)
        Me.rpgONBImports.Name = "rpgONBImports"
        Me.rpgONBImports.Text = "Import Options"
        '
        'rpPayroll
        '
        Me.rpPayroll.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgPayrollFilters, Me.RibbonPageGroup6, Me.RibbonPageGroup8, Me.RibbonPageGroup10, Me.RibbonPageGroup7, Me.rpgPayrollReport, Me.rpgPayrollReportOptions})
        Me.rpPayroll.KeyTip = "PA"
        Me.rpPayroll.Name = "rpPayroll"
        Me.rpPayroll.Text = "Payroll"
        '
        'rpgPayrollFilters
        '
        Me.rpgPayrollFilters.ItemLinks.Add(Me.PayrollList)
        Me.rpgPayrollFilters.ItemLinks.Add(Me.btnKPIClearFilter)
        Me.rpgPayrollFilters.Name = "rpgPayrollFilters"
        Me.rpgPayrollFilters.Text = " "
        '
        'RibbonPageGroup6
        '
        Me.RibbonPageGroup6.ItemLinks.Add(Me.PayrollViewHA)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.PayrollProcessHA)
        Me.RibbonPageGroup6.KeyTip = "PA"
        Me.RibbonPageGroup6.Name = "RibbonPageGroup6"
        Me.RibbonPageGroup6.Tag = CType(1, Short)
        Me.RibbonPageGroup6.Text = "Home Allotment"
        '
        'RibbonPageGroup8
        '
        Me.RibbonPageGroup8.ItemLinks.Add(Me.PayrollViewSA)
        Me.RibbonPageGroup8.ItemLinks.Add(Me.PayrollProcessSA)
        Me.RibbonPageGroup8.Name = "RibbonPageGroup8"
        Me.RibbonPageGroup8.Tag = CType(1, Short)
        Me.RibbonPageGroup8.Text = "Special Allotment"
        '
        'RibbonPageGroup10
        '
        Me.RibbonPageGroup10.ItemLinks.Add(Me.PayrollViewONB)
        Me.RibbonPageGroup10.ItemLinks.Add(Me.PayrollProcessOnb)
        Me.RibbonPageGroup10.Name = "RibbonPageGroup10"
        Me.RibbonPageGroup10.Tag = CType(1, Short)
        Me.RibbonPageGroup10.Text = "Onboard Pay"
        '
        'RibbonPageGroup7
        '
        Me.RibbonPageGroup7.ItemLinks.Add(Me.cmdRunPayroll, "CA")
        Me.RibbonPageGroup7.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.RibbonPageGroup7.ItemLinks.Add(Me.cmdSave, "SA")
        Me.RibbonPageGroup7.ItemLinks.Add(Me.cmdLoadData)
        Me.RibbonPageGroup7.ItemLinks.Add(Me.cmdDelete, "D")
        Me.RibbonPageGroup7.KeyTip = "ED"
        Me.RibbonPageGroup7.Name = "RibbonPageGroup7"
        Me.RibbonPageGroup7.Text = "Editing Options"
        '
        'rpgPayrollReport
        '
        Me.rpgPayrollReport.ItemLinks.Add(Me.cmdPayrollReports, "PY")
        Me.rpgPayrollReport.KeyTip = "RE"
        Me.rpgPayrollReport.Name = "rpgPayrollReport"
        Me.rpgPayrollReport.Tag = "1"
        Me.rpgPayrollReport.Text = "Reports"
        '
        'rpgPayrollReportOptions
        '
        Me.rpgPayrollReportOptions.ItemLinks.Add(Me.cmdQuickReports)
        Me.rpgPayrollReportOptions.ItemLinks.Add(Me.cmdShowSelectionList, "SH")
        Me.rpgPayrollReportOptions.ItemLinks.Add(Me.cmdClearFilter)
        Me.rpgPayrollReportOptions.ItemLinks.Add(Me.cmdPreviewReport, True, "VR")
        Me.rpgPayrollReportOptions.ItemLinks.Add(Me.cmdExport, "EX")
        Me.rpgPayrollReportOptions.KeyTip = "RP"
        Me.rpgPayrollReportOptions.Name = "rpgPayrollReportOptions"
        Me.rpgPayrollReportOptions.Text = "Report Options"
        '
        'rpArchive
        '
        Me.rpArchive.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgCrewRecordSummary, Me.rpgArchiveProcess, Me.rpgViewArchivedReport})
        Me.rpArchive.KeyTip = "AR"
        Me.rpArchive.Name = "rpArchive"
        Me.rpArchive.Text = "Archive"
        '
        'rpgCrewRecordSummary
        '
        Me.rpgCrewRecordSummary.ItemLinks.Add(Me.ArchivedCrews)
        Me.rpgCrewRecordSummary.ItemLinks.Add(Me.Archived_Report, True)
        Me.rpgCrewRecordSummary.KeyTip = "C"
        Me.rpgCrewRecordSummary.Name = "rpgCrewRecordSummary"
        Me.rpgCrewRecordSummary.Tag = "1"
        Me.rpgCrewRecordSummary.Text = "Crew Record Summary"
        '
        'rpgArchiveProcess
        '
        Me.rpgArchiveProcess.ItemLinks.Add(Me.DeleteCrew)
        Me.rpgArchiveProcess.ItemLinks.Add(Me.bbiStartTransferToActive, "S")
        Me.rpgArchiveProcess.KeyTip = "P"
        Me.rpgArchiveProcess.Name = "rpgArchiveProcess"
        Me.rpgArchiveProcess.Text = "Process Archive"
        '
        'bbiStartTransferToActive
        '
        Me.bbiStartTransferToActive.Caption = "Start Transfer to Active"
        Me.bbiStartTransferToActive.Glyph = CType(resources.GetObject("bbiStartTransferToActive.Glyph"), System.Drawing.Image)
        Me.bbiStartTransferToActive.GroupIndex = 1
        Me.bbiStartTransferToActive.Id = 88
        Me.bbiStartTransferToActive.LargeGlyph = CType(resources.GetObject("bbiStartTransferToActive.LargeGlyph"), System.Drawing.Image)
        Me.bbiStartTransferToActive.Name = "bbiStartTransferToActive"
        Me.bbiStartTransferToActive.Tag = "1"
        '
        'rpgViewArchivedReport
        '
        Me.rpgViewArchivedReport.ItemLinks.Add(Me.cmdPreviewReport)
        Me.rpgViewArchivedReport.Name = "rpgViewArchivedReport"
        Me.rpgViewArchivedReport.Text = "Report Options"
        '
        'rpLog
        '
        Me.rpLog.KeyTip = "L"
        Me.rpLog.Name = "rpLog"
        Me.rpLog.Text = "Log"
        '
        'rpApproval
        '
        Me.rpApproval.KeyTip = "AP"
        Me.rpApproval.Name = "rpApproval"
        Me.rpApproval.Text = "Approval"
        '
        'rpCrewReassignment
        '
        Me.rpCrewReassignment.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgCrewReassignViewOptions, Me.rpgCrewReassign, Me.rpgCrewReassignEditOptions})
        Me.rpCrewReassignment.KeyTip = "CE"
        Me.rpCrewReassignment.Name = "rpCrewReassignment"
        Me.rpCrewReassignment.Text = "Crew Reassignment"
        '
        'rpgCrewReassignViewOptions
        '
        Me.rpgCrewReassignViewOptions.ItemLinks.Add(Me.cmdViewRecordSum, "V")
        Me.rpgCrewReassignViewOptions.KeyTip = "0"
        Me.rpgCrewReassignViewOptions.Name = "rpgCrewReassignViewOptions"
        '
        'rpgCrewReassign
        '
        Me.rpgCrewReassign.ItemLinks.Add(Me.ReassignCrewRequest, "R")
        Me.rpgCrewReassign.ItemLinks.Add(Me.ReassignCrewConfirm, "CO")
        Me.rpgCrewReassign.ItemLinks.Add(Me.ReassignCrewHistory, "HI")
        Me.rpgCrewReassign.KeyTip = "CR"
        Me.rpgCrewReassign.Name = "rpgCrewReassign"
        Me.rpgCrewReassign.Tag = "1"
        Me.rpgCrewReassign.Text = "Crew Reassignment"
        '
        'rpgCrewReassignEditOptions
        '
        Me.rpgCrewReassignEditOptions.ItemLinks.Add(Me.cmdAdd, "A")
        Me.rpgCrewReassignEditOptions.ItemLinks.Add(Me.cmdEdit, "EI")
        Me.rpgCrewReassignEditOptions.ItemLinks.Add(Me.cmdSave, "S")
        Me.rpgCrewReassignEditOptions.ItemLinks.Add(Me.cmdDelete, "D")
        Me.rpgCrewReassignEditOptions.ItemLinks.Add(Me.cmdHideRequest, "HD")
        Me.rpgCrewReassignEditOptions.KeyTip = "ED"
        Me.rpgCrewReassignEditOptions.Name = "rpgCrewReassignEditOptions"
        Me.rpgCrewReassignEditOptions.Text = "Editing Options"
        '
        'rpInfo
        '
        Me.rpInfo.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgAppInfo})
        Me.rpInfo.KeyTip = "AL"
        Me.rpInfo.Name = "rpInfo"
        Me.rpInfo.Text = "Application Info"
        '
        'rpgAppInfo
        '
        Me.rpgAppInfo.ItemLinks.Add(Me.About, "A")
        Me.rpgAppInfo.ItemLinks.Add(Me.VersionUpdates, "V")
        Me.rpgAppInfo.KeyTip = "P"
        Me.rpgAppInfo.Name = "rpgAppInfo"
        Me.rpgAppInfo.Tag = "1"
        Me.rpgAppInfo.Text = "Program Information"
        '
        'About
        '
        Me.About.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.About.Caption = "About"
        Me.About.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.About.Glyph = CType(resources.GetObject("About.Glyph"), System.Drawing.Image)
        Me.About.GroupIndex = 1
        Me.About.Id = 51
        Me.About.LargeGlyph = CType(resources.GetObject("About.LargeGlyph"), System.Drawing.Image)
        Me.About.LargeGlyphDisabled = CType(resources.GetObject("About.LargeGlyphDisabled"), System.Drawing.Image)
        Me.About.Name = "About"
        '
        'VersionUpdates
        '
        Me.VersionUpdates.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.VersionUpdates.Caption = "Version Updates"
        Me.VersionUpdates.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.VersionUpdates.Glyph = CType(resources.GetObject("VersionUpdates.Glyph"), System.Drawing.Image)
        Me.VersionUpdates.GroupIndex = 1
        Me.VersionUpdates.Id = 52
        Me.VersionUpdates.LargeGlyph = CType(resources.GetObject("VersionUpdates.LargeGlyph"), System.Drawing.Image)
        Me.VersionUpdates.LargeGlyphDisabled = CType(resources.GetObject("VersionUpdates.LargeGlyphDisabled"), System.Drawing.Image)
        Me.VersionUpdates.Name = "VersionUpdates"
        '
        'rbgLTPFilter
        '
        Me.rbgLTPFilter.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.rbgLTPFilter.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.rbgLTPFilter.Appearance.Options.UseBackColor = True
        Me.rbgLTPFilter.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Vessel", "Vessel"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Rank", "Rank")})
        Me.rbgLTPFilter.Name = "rbgLTPFilter"
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        '
        'RepositoryItemImageEdit1
        '
        Me.RepositoryItemImageEdit1.AutoHeight = False
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'RepositoryItemRadioGroup1
        '
        Me.RepositoryItemRadioGroup1.Name = "RepositoryItemRadioGroup1"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'RepositoryItemToggleSwitch1
        '
        Me.RepositoryItemToggleSwitch1.AutoHeight = False
        Me.RepositoryItemToggleSwitch1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemToggleSwitch1.Name = "RepositoryItemToggleSwitch1"
        Me.RepositoryItemToggleSwitch1.OffText = "Off"
        Me.RepositoryItemToggleSwitch1.OnText = "On"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemPictureEdit2
        '
        Me.RepositoryItemPictureEdit2.InitialImage = CType(resources.GetObject("RepositoryItemPictureEdit2.InitialImage"), System.Drawing.Image)
        Me.RepositoryItemPictureEdit2.Name = "RepositoryItemPictureEdit2"
        Me.RepositoryItemPictureEdit2.NullText = " "
        Me.RepositoryItemPictureEdit2.PictureAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RepositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        '
        'RepositoryItemCheckEdit13
        '
        Me.RepositoryItemCheckEdit13.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RepositoryItemCheckEdit13.Appearance.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit13.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RepositoryItemCheckEdit13.AppearanceDisabled.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit13.AppearanceReadOnly.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RepositoryItemCheckEdit13.AppearanceReadOnly.BackColor2 = System.Drawing.Color.Transparent
        Me.RepositoryItemCheckEdit13.AppearanceReadOnly.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit13.AutoHeight = False
        Me.RepositoryItemCheckEdit13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.RepositoryItemCheckEdit13.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit13.Name = "RepositoryItemCheckEdit13"
        '
        'RepositoryItemToggleSwitch2
        '
        Me.RepositoryItemToggleSwitch2.AutoHeight = False
        Me.RepositoryItemToggleSwitch2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemToggleSwitch2.Name = "RepositoryItemToggleSwitch2"
        Me.RepositoryItemToggleSwitch2.OffText = "No"
        Me.RepositoryItemToggleSwitch2.OnText = "Yes"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.sbiInformation)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.sbiWarning)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.sbiCheck)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.txtUserName)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.txtServerName)
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 640)
        Me.RibbonStatusBar1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1290, 31)
        '
        'bbDeselectAll
        '
        Me.bbDeselectAll.Id = -1
        Me.bbDeselectAll.Name = "bbDeselectAll"
        '
        'bbSelectAll
        '
        Me.bbSelectAll.Id = -1
        Me.bbSelectAll.Name = "bbSelectAll"
        '
        'RibbonPageCategory2
        '
        Me.RibbonPageCategory2.Name = "RibbonPageCategory2"
        Me.RibbonPageCategory2.Text = "RibbonPageCategory2"
        '
        'bbiSelectAll
        '
        Me.bbiSelectAll.Caption = "Select All"
        Me.bbiSelectAll.Glyph = CType(resources.GetObject("bbiSelectAll.Glyph"), System.Drawing.Image)
        Me.bbiSelectAll.Id = 86
        Me.bbiSelectAll.LargeGlyph = CType(resources.GetObject("bbiSelectAll.LargeGlyph"), System.Drawing.Image)
        Me.bbiSelectAll.Name = "bbiSelectAll"
        '
        'bbiDeselectAll
        '
        Me.bbiDeselectAll.Caption = "Deselect All"
        Me.bbiDeselectAll.Glyph = CType(resources.GetObject("bbiDeselectAll.Glyph"), System.Drawing.Image)
        Me.bbiDeselectAll.Id = 87
        Me.bbiDeselectAll.LargeGlyph = CType(resources.GetObject("bbiDeselectAll.LargeGlyph"), System.Drawing.Image)
        Me.bbiDeselectAll.LargeGlyphDisabled = CType(resources.GetObject("bbiDeselectAll.LargeGlyphDisabled"), System.Drawing.Image)
        Me.bbiDeselectAll.Name = "bbiDeselectAll"
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.RepositoryItemCheckEdit3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.RepositoryItemCheckEdit4.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        '
        'RepositoryItemRadioGroup2
        '
        Me.RepositoryItemRadioGroup2.Name = "RepositoryItemRadioGroup2"
        '
        'RepositoryItemCheckEdit5
        '
        Me.RepositoryItemCheckEdit5.AutoHeight = False
        Me.RepositoryItemCheckEdit5.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit5.Name = "RepositoryItemCheckEdit5"
        '
        'RepositoryItemCheckEdit6
        '
        Me.RepositoryItemCheckEdit6.AutoHeight = False
        Me.RepositoryItemCheckEdit6.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit6.Name = "RepositoryItemCheckEdit6"
        '
        'RepositoryItemRadioGroup3
        '
        Me.RepositoryItemRadioGroup3.Name = "RepositoryItemRadioGroup3"
        '
        'RepositoryItemRadioGroup4
        '
        Me.RepositoryItemRadioGroup4.Name = "RepositoryItemRadioGroup4"
        '
        'RepositoryItemCheckEdit7
        '
        Me.RepositoryItemCheckEdit7.AutoHeight = False
        Me.RepositoryItemCheckEdit7.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.RepositoryItemCheckEdit7.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit7.Name = "RepositoryItemCheckEdit7"
        '
        'RepositoryItemRadioGroup5
        '
        Me.RepositoryItemRadioGroup5.Name = "RepositoryItemRadioGroup5"
        '
        'RepositoryItemCheckEdit8
        '
        Me.RepositoryItemCheckEdit8.AutoHeight = False
        Me.RepositoryItemCheckEdit8.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.RepositoryItemCheckEdit8.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit8.Name = "RepositoryItemCheckEdit8"
        '
        'RepositoryItemCheckEdit9
        '
        Me.RepositoryItemCheckEdit9.AutoHeight = False
        Me.RepositoryItemCheckEdit9.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.RepositoryItemCheckEdit9.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit9.Name = "RepositoryItemCheckEdit9"
        '
        'RepositoryItemCheckEdit10
        '
        Me.RepositoryItemCheckEdit10.AutoHeight = False
        Me.RepositoryItemCheckEdit10.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.RepositoryItemCheckEdit10.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemCheckEdit10.Name = "RepositoryItemCheckEdit10"
        '
        'chkIncludeLabeling
        '
        Me.chkIncludeLabeling.Caption = "Include colors in report"
        Me.chkIncludeLabeling.Edit = Me.RepositoryItemCheckEdit2
        Me.chkIncludeLabeling.Id = 67
        Me.chkIncludeLabeling.Name = "chkIncludeLabeling"
        Me.chkIncludeLabeling.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        Me.chkIncludeLabeling.Width = 20
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(0, 155)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Panel1.Text = "Panel1"
        Me.MainPanel.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.MainPanel.Panel2.Text = "Panel2"
        Me.MainPanel.Size = New System.Drawing.Size(1290, 485)
        Me.MainPanel.SplitterPosition = 314
        Me.MainPanel.TabIndex = 2
        Me.MainPanel.Text = "MainPanel"
        '
        'DETAILS
        '
        Me.DETAILS.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.DETAILS.Caption = "Details"
        Me.DETAILS.Id = 5
        Me.DETAILS.Name = "DETAILS"
        Me.DETAILS.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'FolderBrowserDialog1
        '
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "BarButtonItem3"
        Me.BarButtonItem3.Id = 64
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.ItemLinks.Add(Me.Biodata, "B")
        Me.PopupMenu1.ItemLinks.Add(Me.Document, "D")
        Me.PopupMenu1.ItemLinks.Add(Me.Service, "S")
        Me.PopupMenu1.ItemLinks.Add(Me.Appraisal, "A")
        Me.PopupMenu1.ItemLinks.Add(Me.cmdPrint, "P")
        Me.PopupMenu1.Name = "PopupMenu1"
        Me.PopupMenu1.Ribbon = Me.RibbonControl
        '
        'tmr
        '
        Me.tmr.Interval = 1000
        '
        'PopupMenu2
        '
        Me.PopupMenu2.Name = "PopupMenu2"
        Me.PopupMenu2.Ribbon = Me.RibbonControl
        '
        'ReportsGovMonthly
        '
        Me.ReportsGovMonthly.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReportsGovMonthly.Caption = " Biodata"
        Me.ReportsGovMonthly.Description = "Crew"
        Me.ReportsGovMonthly.Glyph = CType(resources.GetObject("ReportsGovMonthly.Glyph"), System.Drawing.Image)
        Me.ReportsGovMonthly.GroupIndex = 1
        Me.ReportsGovMonthly.Id = 1
        Me.ReportsGovMonthly.Name = "ReportsGovMonthly"
        Me.ReportsGovMonthly.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'PopupMenu3
        '
        Me.PopupMenu3.Name = "PopupMenu3"
        Me.PopupMenu3.Ribbon = Me.RibbonControl
        '
        'frmCrewMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 671)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.MinimumSize = New System.Drawing.Size(800, 400)
        Me.Name = "frmCrewMain"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "MPS5 - Crew"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.LEDocType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popAppIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SortMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewNameMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportsGovMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LTPTrackbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueLTPFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLTPShowAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repLTPFilterMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repColorSchemes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repKPIChartView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PayrollReportsMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repKPIColorPalette, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repLgndOnb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repLgndPln, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repLgndEdited, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repLgndInvalid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkShowAllPlanning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.menuQuickFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repLTPSortMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueLTPSort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbgLTPFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRadioGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemToggleSwitch1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemToggleSwitch2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRadioGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRadioGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRadioGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRadioGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents Crewing As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgCrewing As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Biodata As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents MainPanel As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents rpgEditOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Activity As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpPlanning As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpTravel As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents cmdView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgTool As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpReports As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpCompetence As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpDMS As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpArchive As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpLog As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpApproval As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents SortRank As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RecordSum As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DETAILS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Service As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Relative As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Appraisal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Career As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdBackMenu As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents sbiInformation As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents sbiWarning As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents cmdDeleteSub As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents sbiCheck As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents cmdSort As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Crew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSaveLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdResetLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Document As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CREWREPORT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ADVANCEDSEARCH As DevExpress.XtraBars.BarButtonItem
    Private WithEvents rpgReport As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdChangePass As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdChangeUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SignOn As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgActivity As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgActivityEditingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CrewActivity_Amend As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgReportEditOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdLoadData As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SignOff As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Promotion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Transfer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SickOnboard As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AshoreActivity As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoBack As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgDocViewer As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DocViewer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgDMSEditOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ftrVessel As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ftrDocType As DevExpress.XtraBars.BarEditItem
    Friend WithEvents cmdBulk As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSetFolder As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Individual_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdShowSelectionList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdPreviewReport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Onboard_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Planning_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents History_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Ashore_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgQualificationMatrix As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgPrintOption As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents QualificationMatrix As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnNotif As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdUserSettings As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdApply As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdClearFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SortMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents CrewNameMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents RankMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents cmdSortNameASC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSortNameDESC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSortName As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSortRank_ASC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSortRank_DESC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgPlanning As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Planning As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgEditing As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgExtract As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdDownload As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdPrintFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgCrewFilter As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgActTools As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdClearCLFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents TravelEventV2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents travelEventRibbon As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgTravel_EditingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents TravelEvent_Returning As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpChecklist As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgPrintCheckList As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents CrewChecklist As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PlanningChecklist As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents txtServerName As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents txtUserName As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents NotifExpDocs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarDockingMenuItem1 As DevExpress.XtraBars.BarDockingMenuItem
    Friend WithEvents cmdExpCrewList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Training As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpCrewReassignment As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgCrewReassignViewOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgCrewReassign As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgCrewReassignEditOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ReassignCrewRequest As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LEVessel As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ReassignCrewConfirm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdViewRecordSum As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpAshWageAcct As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgASHW As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents AshCrewWages As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgASHWTool As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents CrewAmortization As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdHideRequest As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Government_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpOnbWageAcct As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgONBWageAcct As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgONBWEditOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents OnbCrewWages As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnViewRelatives As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MedicalHis As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Remittances As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReassignCrewHistory As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LTP As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpLTP As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgLTPFilter As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LTPScaler As DevExpress.XtraBars.BarEditItem
    Friend WithEvents LTPTrackbar As DevExpress.XtraEditors.Repository.RepositoryItemTrackBar
    Friend WithEvents rbgLTPFilter As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents barLTPLUE As DevExpress.XtraBars.BarEditItem
    Friend WithEvents lueLTPFilter As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents RepositoryItemImageEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents barLTPChk As DevExpress.XtraBars.BarEditItem
    Friend WithEvents chkLTPShowAll As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents rpInfo As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgAppInfo As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents About As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VersionUpdates As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Statistics_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpPayroll As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents PayrollProcessOnb As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayrollProcessHA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayrollProcessSA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayrollViewSA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup7 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdRunPayroll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Other_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgONBWTool As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RepositoryItemRadioGroup1 As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents barLUEFilterMode As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repLTPFilterMode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents barColorScheme As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repColorSchemes As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rpKPI As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents KPI As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgKPI As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnKPIClearFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barKPIChartView As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repKPIChartView As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rpgKPIDisplayOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgPrintOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents barKPIPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ContractExtension As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barKPIGenerateResult As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barKPIClearChart As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgAshWages As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnCrewComments As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents chkIncludeLabeling As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemToggleSwitch1 As DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch
    Friend WithEvents PayrollViewHA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgCrewRecordSummary As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemRadioGroup3 As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents RepositoryItemCheckEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemRadioGroup2 As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents RepositoryItemCheckEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemRadioGroup4 As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents RepositoryItemRadioGroup5 As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents RepositoryItemCheckEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit10 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents bbiSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiDeselectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiStartTransferToActive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgArchiveProcess As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PayrollReportsMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents rpgPayrollReport As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PayrollOnboard_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayrollHA_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayrollSA_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayrollDisketting_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayrollCompanySpecific_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgReportOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdPayrollReports As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgPayrollReportOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PayrollViewONB As DevExpress.XtraBars.BarButtonItem
    Private WithEvents LEDocType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents barKPIChkShowResultOnly As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents barKPIColorPalette As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repKPIColorPalette As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rpgLTPRefresh As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents CrewCashAdvance As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CrewListArchive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiStartArchive As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategory2 As DevExpress.XtraBars.Ribbon.RibbonPageCategory
    Friend WithEvents ArchivedCrews As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDeselectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PayAdvances As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgViewArchivedReport As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Archived_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgKPIReportOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PayrollList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgPayrollFilters As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgFilter As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PlanChecklist As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BackstageViewControl1 As DevExpress.XtraBars.Ribbon.BackstageViewControl
    Friend WithEvents BackstageViewClientControl1 As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Friend WithEvents BackstageViewTabItem1 As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Friend WithEvents rpgManualRefresh As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbiManualRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgKPITemplateOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgIncludeFlaggedColors As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents beiShowFlaggedColors As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemCheckEdit11 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btnTravelSearch As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgTravelEventSearch As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RepositoryItemPictureEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents barKPIShowHideTemplates As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DeleteCrew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup9 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RepositoryItemCheckEdit12 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents beLgndOnb As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repLgndOnb As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents beLgndPln As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repLgndPln As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit13 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents beLgndEdited As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repLgndEdited As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents beLgndInvalid As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repLgndInvalid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents tmr As System.Windows.Forms.Timer
    Friend WithEvents Email_Profile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Email_Config As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdQuickReports As DevExpress.XtraBars.BarButtonItem

    Friend WithEvents ReportsGovMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents ReportGovIndi_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCheckItem2 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarCheckItem1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents ReportGovMonthly_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu2 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarCheckItem3 As DevExpress.XtraBars.BarCheckItem

    Friend WithEvents RibbonPageGroup8 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup10 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ReportConfig As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgReportConfig As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ReportsGovMonthly As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdGenCAImpTemplate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgONBImports As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgExport As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents KPIConfig As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgKPIConfig As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdHelp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdImportFromExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UniformIssuance As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu3 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents legendHigh As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents legendMedium As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents legendLow As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barLUESortMode As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repLTPSortMode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents barLTPLUESort As DevExpress.XtraBars.BarEditItem
    Friend WithEvents lueLTPSort As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rpgLTPSort As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Activity_Docs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgActivityDocs As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents barChkShowAllPlanning As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ChkShowAllPlanning As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents rpgPlanningFilter As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgTravelFilter As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdQuickFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents QuickFilterMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents cmdFilterONB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdFilterPlanning As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdFilterAshore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdClearQuickFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgActivityActivityDocs As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents menuQuickFilter As DevExpress.XtraBars.PopupMenu
    Friend WithEvents rpgActRefresh As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents CompanySpecific_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CrewTraining_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AllCrew_Report As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barLTPSelectVesselRank As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents popAppIcon As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Travel_GTRS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents travelGTRS As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GTRSConfig As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemToggleSwitch2 As DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents rpgTravelRefresh As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    ' Friend WithEvents rpgActivityActivityDocs As DevExpress.XtraBars.Ribbon.RibbonPageGroup

End Class
