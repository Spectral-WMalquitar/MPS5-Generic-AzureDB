<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Service
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Service))
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.xheader = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.ServSumGrpGrid = New DevExpress.XtraGrid.GridControl()
        Me.ServSumGrpView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn121 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn122 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn138 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn123 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn124 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn139 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ServSumRankGrid = New DevExpress.XtraGrid.GridControl()
        Me.ServSumRankView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn120 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn119 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn106 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn118 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn126 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtDays = New DevExpress.XtraEditors.TextEdit()
        Me.sp = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.OthSeaGrid = New DevExpress.XtraGrid.GridControl()
        Me.OthSeaView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ActGrpID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Crew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repOthDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFKeyPort = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repIsComp = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSignOffStat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repActType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn72 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn73 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVslCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn74 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVslName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn76 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVslType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn77 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn78 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn79 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn80 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repPrinCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn81 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn82 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repAgentCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn83 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn84 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFltMgr = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn85 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn86 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFKeyStatCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn87 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn88 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn89 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn90 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFKeyRank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn91 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn92 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn93 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn94 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn95 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn96 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFkeyWScale = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn97 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repWScalRank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn98 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn99 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn100 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn101 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn102 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn103 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn104 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn107 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repReliver = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.AshGrid = New DevExpress.XtraGrid.GridControl()
        Me.AshView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn114 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn115 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn117 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repAshRemarks = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.AshRepStat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.SeaServGrid = New DevExpress.XtraGrid.GridControl()
        Me.SeaServView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn125 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn105 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearepStat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn112 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn113 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn116 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCompServRemarks = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.SeaServDateDep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SeaServDateArr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SeaServDateSOn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SeaServDateSOff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OtherGrid = New DevExpress.XtraGrid.GridControl()
        Me.OtherView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn108 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn110 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repOthSOFFStat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repLOC = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVslTypeName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repYrBuilt = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repStatName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repOthRankName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn111 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repOthPort = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repremarks = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn109 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OtherSeaServDateDep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OtherSeaServDateArr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LDGrid = New DevExpress.XtraGrid.GridControl()
        Me.LDView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn127 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn128 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn129 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn130 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn131 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn132 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn133 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn134 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn137 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn135 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn136 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LDWScaleRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtTotalDays = New DevExpress.XtraEditors.TextEdit()
        Me.txtConsumedDays = New DevExpress.XtraEditors.TextEdit()
        Me.txtRemainingDays = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalPay = New DevExpress.XtraEditors.TextEdit()
        Me.txtConsumedPay = New DevExpress.XtraEditors.TextEdit()
        Me.txtRemainingPay = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabControl = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgLDHistory = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciLDGrid = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgLDSum = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciTotDays = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciConDays = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciRemDays = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcgLPSum = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciTotPay = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciConPay = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciRemPay = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        Me.xheader.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.ServSumGrpGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServSumGrpView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServSumRankGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServSumRankView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OthSeaGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OthSeaView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repOthDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repOthDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFKeyPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repIsComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSignOffStat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repActType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVslCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVslName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVslType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPrinCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAgentCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFltMgr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFKeyStatCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFKeyRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFkeyWScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repWScalRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repReliver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AshGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AshView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAshRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AshRepStat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeaServGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeaServView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearepStat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCompServRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OtherGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OtherView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repOthSOFFStat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repLOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVslTypeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repYrBuilt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repStatName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repOthRankName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repOthPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repremarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LDGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LDView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsumedDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemainingDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConsumedPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemainingPay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgLDHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciLDGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgLDSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciTotDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciConDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciRemDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgLPSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciTotPay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciConPay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciRemPay, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1072, 576)
        Me.header.TabIndex = 50
        Me.header.Text = "Acitivity History"
        '
        'xheader
        '
        Me.xheader.Controls.Add(Me.LayoutControl1)
        Me.xheader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xheader.Location = New System.Drawing.Point(2, 27)
        Me.xheader.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.xheader.Name = "xheader"
        Me.xheader.Size = New System.Drawing.Size(1068, 547)
        Me.xheader.TabIndex = 48
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.LayoutControl2)
        Me.LayoutControl1.Controls.Add(Me.OthSeaGrid)
        Me.LayoutControl1.Controls.Add(Me.AshGrid)
        Me.LayoutControl1.Controls.Add(Me.SeaServGrid)
        Me.LayoutControl1.Controls.Add(Me.OtherGrid)
        Me.LayoutControl1.Controls.Add(Me.LDGrid)
        Me.LayoutControl1.Controls.Add(Me.txtTotalDays)
        Me.LayoutControl1.Controls.Add(Me.txtConsumedDays)
        Me.LayoutControl1.Controls.Add(Me.txtRemainingDays)
        Me.LayoutControl1.Controls.Add(Me.txtTotalPay)
        Me.LayoutControl1.Controls.Add(Me.txtConsumedPay)
        Me.LayoutControl1.Controls.Add(Me.txtRemainingPay)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(852, 290, 422, 583)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1068, 547)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.cmdSave)
        Me.LayoutControl2.Controls.Add(Me.ServSumGrpGrid)
        Me.LayoutControl2.Controls.Add(Me.ServSumRankGrid)
        Me.LayoutControl2.Controls.Add(Me.txtDays)
        Me.LayoutControl2.Location = New System.Drawing.Point(35, 62)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(979, 191, 250, 350)
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl2.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl2.Root = Me.sp
        Me.LayoutControl2.Size = New System.Drawing.Size(998, 450)
        Me.LayoutControl2.TabIndex = 8
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(259, 422)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(76, 22)
        Me.cmdSave.StyleController = Me.LayoutControl2
        Me.cmdSave.TabIndex = 11
        Me.cmdSave.Text = "Save"
        '
        'ServSumGrpGrid
        '
        Me.ServSumGrpGrid.Location = New System.Drawing.Point(6, 211)
        Me.ServSumGrpGrid.MainView = Me.ServSumGrpView
        Me.ServSumGrpGrid.Name = "ServSumGrpGrid"
        Me.ServSumGrpGrid.Size = New System.Drawing.Size(986, 207)
        Me.ServSumGrpGrid.TabIndex = 9
        Me.ServSumGrpGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ServSumGrpView})
        '
        'ServSumGrpView
        '
        Me.ServSumGrpView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn121, Me.GridColumn122, Me.GridColumn138, Me.GridColumn123, Me.GridColumn124, Me.GridColumn139})
        Me.ServSumGrpView.GridControl = Me.ServSumGrpGrid
        Me.ServSumGrpView.Name = "ServSumGrpView"
        Me.ServSumGrpView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn121
        '
        Me.GridColumn121.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn121.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn121.FieldName = "GroupType"
        Me.GridColumn121.Name = "GridColumn121"
        Me.GridColumn121.OptionsColumn.ReadOnly = True
        Me.GridColumn121.Visible = True
        Me.GridColumn121.VisibleIndex = 0
        Me.GridColumn121.Width = 287
        '
        'GridColumn122
        '
        Me.GridColumn122.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn122.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn122.Caption = "Total Sea Service"
        Me.GridColumn122.FieldName = "ServAll"
        Me.GridColumn122.Name = "GridColumn122"
        Me.GridColumn122.OptionsColumn.ReadOnly = True
        Me.GridColumn122.Visible = True
        Me.GridColumn122.VisibleIndex = 1
        Me.GridColumn122.Width = 290
        '
        'GridColumn138
        '
        Me.GridColumn138.Caption = "ActivityType"
        Me.GridColumn138.FieldName = "ActivityType"
        Me.GridColumn138.Name = "GridColumn138"
        Me.GridColumn138.OptionsColumn.ReadOnly = True
        Me.GridColumn138.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn138.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn138.Width = 226
        '
        'GridColumn123
        '
        Me.GridColumn123.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn123.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn123.Caption = "Other Sea Service"
        Me.GridColumn123.FieldName = "ServOther"
        Me.GridColumn123.Name = "GridColumn123"
        Me.GridColumn123.OptionsColumn.ReadOnly = True
        Me.GridColumn123.Visible = True
        Me.GridColumn123.VisibleIndex = 3
        Me.GridColumn123.Width = 223
        '
        'GridColumn124
        '
        Me.GridColumn124.Caption = "SortNo"
        Me.GridColumn124.FieldName = "SortNo"
        Me.GridColumn124.Name = "GridColumn124"
        Me.GridColumn124.OptionsColumn.ReadOnly = True
        '
        'GridColumn139
        '
        Me.GridColumn139.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn139.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn139.Caption = "Company Sea Service"
        Me.GridColumn139.FieldName = "ServCompany"
        Me.GridColumn139.Name = "GridColumn139"
        Me.GridColumn139.OptionsColumn.ReadOnly = True
        Me.GridColumn139.Visible = True
        Me.GridColumn139.VisibleIndex = 2
        Me.GridColumn139.Width = 277
        '
        'ServSumRankGrid
        '
        Me.ServSumRankGrid.Location = New System.Drawing.Point(6, 6)
        Me.ServSumRankGrid.MainView = Me.ServSumRankView
        Me.ServSumRankGrid.Name = "ServSumRankGrid"
        Me.ServSumRankGrid.Size = New System.Drawing.Size(986, 196)
        Me.ServSumRankGrid.TabIndex = 8
        Me.ServSumRankGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ServSumRankView})
        '
        'ServSumRankView
        '
        Me.ServSumRankView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.ServSumRankView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn120, Me.GridColumn119, Me.GridColumn106, Me.GridColumn118, Me.GridColumn126})
        Me.ServSumRankView.GridControl = Me.ServSumRankGrid
        Me.ServSumRankView.Name = "ServSumRankView"
        Me.ServSumRankView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn120
        '
        Me.GridColumn120.Caption = "Rank"
        Me.GridColumn120.FieldName = "RankName"
        Me.GridColumn120.Name = "GridColumn120"
        Me.GridColumn120.OptionsColumn.ReadOnly = True
        Me.GridColumn120.Visible = True
        Me.GridColumn120.VisibleIndex = 0
        Me.GridColumn120.Width = 152
        '
        'GridColumn119
        '
        Me.GridColumn119.Caption = "Total Sea Service"
        Me.GridColumn119.FieldName = "ServAll"
        Me.GridColumn119.Name = "GridColumn119"
        Me.GridColumn119.OptionsColumn.ReadOnly = True
        Me.GridColumn119.Visible = True
        Me.GridColumn119.VisibleIndex = 1
        Me.GridColumn119.Width = 308
        '
        'GridColumn106
        '
        Me.GridColumn106.Caption = "Company Sea Service"
        Me.GridColumn106.FieldName = "ServCompany"
        Me.GridColumn106.Name = "GridColumn106"
        Me.GridColumn106.OptionsColumn.ReadOnly = True
        Me.GridColumn106.Visible = True
        Me.GridColumn106.VisibleIndex = 2
        Me.GridColumn106.Width = 301
        '
        'GridColumn118
        '
        Me.GridColumn118.Caption = "Other Sea Service"
        Me.GridColumn118.FieldName = "ServOther"
        Me.GridColumn118.Name = "GridColumn118"
        Me.GridColumn118.OptionsColumn.ReadOnly = True
        Me.GridColumn118.Visible = True
        Me.GridColumn118.VisibleIndex = 3
        Me.GridColumn118.Width = 316
        '
        'GridColumn126
        '
        Me.GridColumn126.Caption = "Rank Sort"
        Me.GridColumn126.FieldName = "RankSort"
        Me.GridColumn126.Name = "GridColumn126"
        Me.GridColumn126.OptionsColumn.ReadOnly = True
        '
        'txtDays
        '
        Me.txtDays.Location = New System.Drawing.Point(139, 422)
        Me.txtDays.MaximumSize = New System.Drawing.Size(50, 20)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDays.Size = New System.Drawing.Size(50, 20)
        Me.txtDays.StyleController = Me.LayoutControl2
        Me.txtDays.TabIndex = 10
        '
        'sp
        '
        Me.sp.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.sp.GroupBordersVisible = False
        Me.sp.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.SplitterItem1, Me.LayoutControlItem8, Me.EmptySpaceItem1})
        Me.sp.Location = New System.Drawing.Point(0, 0)
        Me.sp.Name = "Root"
        Me.sp.Padding = New DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4)
        Me.sp.Size = New System.Drawing.Size(998, 450)
        Me.sp.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtDays
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 416)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(187, 26)
        Me.LayoutControlItem5.Text = "1 month is quivalent to"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(130, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.ServSumRankGrid
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(990, 200)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.ServSumGrpGrid
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 205)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(990, 211)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 200)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(990, 5)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmdSave
        Me.LayoutControlItem8.Location = New System.Drawing.Point(187, 416)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(146, 26)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(146, 26)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(146, 26)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "days"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(26, 16)
        Me.LayoutControlItem8.TextToControlDistance = 40
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(333, 416)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(657, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'OthSeaGrid
        '
        Me.OthSeaGrid.Location = New System.Drawing.Point(35, 62)
        Me.OthSeaGrid.MainView = Me.OthSeaView
        Me.OthSeaGrid.Name = "OthSeaGrid"
        Me.OthSeaGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repOthDateEdit, Me.repSignOffStat, Me.repActType, Me.repVslCode, Me.repVslType, Me.repPrinCode, Me.repAgentCode, Me.repFltMgr, Me.repFKeyRank, Me.repFkeyWScale, Me.repWScalRank, Me.repReliver, Me.repFKeyPort, Me.repIsComp, Me.repFKeyStatCode, Me.repVslName})
        Me.OthSeaGrid.Size = New System.Drawing.Size(998, 450)
        Me.OthSeaGrid.TabIndex = 6
        Me.OthSeaGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.OthSeaView})
        '
        'OthSeaView
        '
        Me.OthSeaView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.OthSeaView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ActGrpID, Me.ActID, Me.IDNbr, Me.Crew, Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68, Me.GridColumn69, Me.GridColumn70, Me.GridColumn71, Me.GridColumn72, Me.GridColumn73, Me.GridColumn74, Me.GridColumn75, Me.GridColumn76, Me.GridColumn77, Me.GridColumn78, Me.GridColumn79, Me.GridColumn42, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn80, Me.GridColumn81, Me.GridColumn82, Me.GridColumn83, Me.GridColumn84, Me.GridColumn85, Me.GridColumn86, Me.GridColumn87, Me.GridColumn88, Me.GridColumn89, Me.GridColumn90, Me.GridColumn91, Me.GridColumn92, Me.GridColumn93, Me.GridColumn94, Me.GridColumn95, Me.GridColumn96, Me.GridColumn97, Me.GridColumn98, Me.GridColumn99, Me.GridColumn100, Me.GridColumn101, Me.GridColumn102, Me.GridColumn103, Me.GridColumn104, Me.GridColumn107})
        Me.OthSeaView.GridControl = Me.OthSeaGrid
        Me.OthSeaView.Name = "OthSeaView"
        Me.OthSeaView.OptionsBehavior.AutoExpandAllGroups = True
        Me.OthSeaView.OptionsPrint.ExpandAllDetails = True
        Me.OthSeaView.OptionsView.ColumnAutoWidth = False
        Me.OthSeaView.OptionsView.ShowGroupedColumns = True
        Me.OthSeaView.OptionsView.ShowGroupPanel = False
        '
        'ActGrpID
        '
        Me.ActGrpID.Caption = "Activity Group"
        Me.ActGrpID.FieldName = "ActGrpID"
        Me.ActGrpID.Name = "ActGrpID"
        '
        'ActID
        '
        Me.ActID.Caption = "ActID"
        Me.ActID.FieldName = "ActID"
        Me.ActID.Name = "ActID"
        '
        'IDNbr
        '
        Me.IDNbr.Caption = "IDNbr"
        Me.IDNbr.FieldName = "IDNbr"
        Me.IDNbr.Name = "IDNbr"
        '
        'Crew
        '
        Me.Crew.Caption = "Crew"
        Me.Crew.FieldName = "Crew"
        Me.Crew.Name = "Crew"
        '
        'GridColumn63
        '
        Me.GridColumn63.Caption = "DateDep"
        Me.GridColumn63.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn63.FieldName = "DateDep"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 9
        Me.GridColumn63.Width = 94
        '
        'repOthDateEdit
        '
        Me.repOthDateEdit.AutoHeight = False
        Me.repOthDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repOthDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repOthDateEdit.CalendarTimeProperties.Mask.EditMask = "d"
        Me.repOthDateEdit.Name = "repOthDateEdit"
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "DateArr"
        Me.GridColumn64.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn64.FieldName = "DateArr"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.Visible = True
        Me.GridColumn64.VisibleIndex = 10
        Me.GridColumn64.Width = 113
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "PlaceDep"
        Me.GridColumn65.ColumnEdit = Me.repFKeyPort
        Me.GridColumn65.FieldName = "PlaceDep"
        Me.GridColumn65.Name = "GridColumn65"
        Me.GridColumn65.Visible = True
        Me.GridColumn65.VisibleIndex = 11
        '
        'repFKeyPort
        '
        Me.repFKeyPort.AutoHeight = False
        Me.repFKeyPort.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFKeyPort.DisplayMember = "Name"
        Me.repFKeyPort.DropDownRows = 10
        Me.repFKeyPort.Name = "repFKeyPort"
        Me.repFKeyPort.NullText = " "
        Me.repFKeyPort.ShowFooter = False
        Me.repFKeyPort.ShowHeader = False
        Me.repFKeyPort.ValueMember = "PKey"
        '
        'GridColumn66
        '
        Me.GridColumn66.Caption = "PlaceArr"
        Me.GridColumn66.ColumnEdit = Me.repFKeyPort
        Me.GridColumn66.FieldName = "PlaceArr"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 12
        '
        'GridColumn67
        '
        Me.GridColumn67.Caption = "IsCompServ"
        Me.GridColumn67.ColumnEdit = Me.repIsComp
        Me.GridColumn67.FieldName = "IsCompServ"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.Visible = True
        Me.GridColumn67.VisibleIndex = 1
        Me.GridColumn67.Width = 131
        '
        'repIsComp
        '
        Me.repIsComp.AutoHeight = False
        Me.repIsComp.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repIsComp.DisplayMember = "Name"
        Me.repIsComp.DropDownRows = 10
        Me.repIsComp.Name = "repIsComp"
        Me.repIsComp.NullText = " "
        Me.repIsComp.ShowFooter = False
        Me.repIsComp.ShowHeader = False
        Me.repIsComp.ValueMember = "PKey"
        '
        'GridColumn68
        '
        Me.GridColumn68.Caption = "DateDue"
        Me.GridColumn68.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn68.FieldName = "DateDue"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 13
        '
        'GridColumn69
        '
        Me.GridColumn69.Caption = "SOFFStat"
        Me.GridColumn69.ColumnEdit = Me.repSignOffStat
        Me.GridColumn69.FieldName = "SOFFStat"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.Width = 127
        '
        'repSignOffStat
        '
        Me.repSignOffStat.AutoHeight = False
        Me.repSignOffStat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repSignOffStat.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repSignOffStat.DisplayMember = "Name"
        Me.repSignOffStat.DropDownRows = 10
        Me.repSignOffStat.Name = "repSignOffStat"
        Me.repSignOffStat.NullText = " "
        Me.repSignOffStat.ShowFooter = False
        Me.repSignOffStat.ShowHeader = False
        Me.repSignOffStat.ValueMember = "Name"
        '
        'GridColumn70
        '
        Me.GridColumn70.Caption = "ActivityType"
        Me.GridColumn70.ColumnEdit = Me.repActType
        Me.GridColumn70.FieldName = "ActivityType"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.Visible = True
        Me.GridColumn70.VisibleIndex = 2
        Me.GridColumn70.Width = 114
        '
        'repActType
        '
        Me.repActType.AutoHeight = False
        Me.repActType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repActType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repActType.DisplayMember = "Name"
        Me.repActType.DropDownRows = 10
        Me.repActType.Name = "repActType"
        Me.repActType.NullText = " "
        Me.repActType.ShowFooter = False
        Me.repActType.ShowHeader = False
        Me.repActType.ValueMember = "PKey"
        '
        'GridColumn71
        '
        Me.GridColumn71.Caption = "LOC"
        Me.GridColumn71.FieldName = "LOC"
        Me.GridColumn71.Name = "GridColumn71"
        Me.GridColumn71.Visible = True
        Me.GridColumn71.VisibleIndex = 14
        Me.GridColumn71.Width = 123
        '
        'GridColumn72
        '
        Me.GridColumn72.Caption = "LOCDays"
        Me.GridColumn72.FieldName = "LOCDays"
        Me.GridColumn72.Name = "GridColumn72"
        Me.GridColumn72.Visible = True
        Me.GridColumn72.VisibleIndex = 15
        Me.GridColumn72.Width = 94
        '
        'GridColumn73
        '
        Me.GridColumn73.Caption = "Vessel"
        Me.GridColumn73.ColumnEdit = Me.repVslCode
        Me.GridColumn73.FieldName = "FKeyVslCode"
        Me.GridColumn73.Name = "GridColumn73"
        Me.GridColumn73.Width = 151
        '
        'repVslCode
        '
        Me.repVslCode.AutoHeight = False
        Me.repVslCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repVslCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repVslCode.DisplayMember = "Name"
        Me.repVslCode.DropDownRows = 10
        Me.repVslCode.Name = "repVslCode"
        Me.repVslCode.NullText = " "
        Me.repVslCode.ShowFooter = False
        Me.repVslCode.ShowHeader = False
        Me.repVslCode.ValueMember = "PKey"
        '
        'GridColumn74
        '
        Me.GridColumn74.Caption = "VslName"
        Me.GridColumn74.ColumnEdit = Me.repVslName
        Me.GridColumn74.FieldName = "VslName"
        Me.GridColumn74.Name = "GridColumn74"
        Me.GridColumn74.Visible = True
        Me.GridColumn74.VisibleIndex = 0
        Me.GridColumn74.Width = 221
        '
        'repVslName
        '
        Me.repVslName.AutoHeight = False
        Me.repVslName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repVslName.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repVslName.DisplayMember = "Name"
        Me.repVslName.DropDownRows = 10
        Me.repVslName.Name = "repVslName"
        Me.repVslName.NullText = " "
        Me.repVslName.ShowFooter = False
        Me.repVslName.ShowHeader = False
        Me.repVslName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.repVslName.ValueMember = "Name"
        '
        'GridColumn75
        '
        Me.GridColumn75.Caption = "IMONo"
        Me.GridColumn75.FieldName = "IMONo"
        Me.GridColumn75.Name = "GridColumn75"
        '
        'GridColumn76
        '
        Me.GridColumn76.Caption = "Vessel Type"
        Me.GridColumn76.ColumnEdit = Me.repVslType
        Me.GridColumn76.FieldName = "FKeyVslTypeCode"
        Me.GridColumn76.Name = "GridColumn76"
        Me.GridColumn76.Width = 145
        '
        'repVslType
        '
        Me.repVslType.AutoHeight = False
        Me.repVslType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repVslType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repVslType.DisplayMember = "Name"
        Me.repVslType.DropDownRows = 10
        Me.repVslType.Name = "repVslType"
        Me.repVslType.NullText = " "
        Me.repVslType.ShowFooter = False
        Me.repVslType.ShowHeader = False
        Me.repVslType.ValueMember = "PKey"
        '
        'GridColumn77
        '
        Me.GridColumn77.Caption = "VslTypeName"
        Me.GridColumn77.FieldName = "VslTypeName"
        Me.GridColumn77.Name = "GridColumn77"
        '
        'GridColumn78
        '
        Me.GridColumn78.Caption = "DeadWt"
        Me.GridColumn78.FieldName = "DeadWt "
        Me.GridColumn78.Name = "GridColumn78"
        '
        'GridColumn79
        '
        Me.GridColumn79.Caption = "GrossTon"
        Me.GridColumn79.FieldName = "GrossTon"
        Me.GridColumn79.Name = "GridColumn79"
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "EngType"
        Me.GridColumn42.FieldName = "EngType"
        Me.GridColumn42.Name = "GridColumn42"
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = "EngPower"
        Me.GridColumn60.FieldName = "EngPower"
        Me.GridColumn60.Name = "GridColumn60"
        '
        'GridColumn61
        '
        Me.GridColumn61.Caption = "YrBuilt"
        Me.GridColumn61.FieldName = "YrBuilt"
        Me.GridColumn61.Name = "GridColumn61"
        '
        'GridColumn62
        '
        Me.GridColumn62.Caption = "Auxillaries"
        Me.GridColumn62.FieldName = "Auxillaries"
        Me.GridColumn62.Name = "GridColumn62"
        '
        'GridColumn80
        '
        Me.GridColumn80.Caption = "Principal"
        Me.GridColumn80.ColumnEdit = Me.repPrinCode
        Me.GridColumn80.FieldName = "FKeyPrinCode"
        Me.GridColumn80.Name = "GridColumn80"
        Me.GridColumn80.Visible = True
        Me.GridColumn80.VisibleIndex = 16
        Me.GridColumn80.Width = 169
        '
        'repPrinCode
        '
        Me.repPrinCode.AutoHeight = False
        Me.repPrinCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repPrinCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repPrinCode.DisplayMember = "Name"
        Me.repPrinCode.DropDownRows = 10
        Me.repPrinCode.Name = "repPrinCode"
        Me.repPrinCode.NullText = " "
        Me.repPrinCode.ShowFooter = False
        Me.repPrinCode.ShowHeader = False
        Me.repPrinCode.ValueMember = "PKey"
        '
        'GridColumn81
        '
        Me.GridColumn81.Caption = "PrinName"
        Me.GridColumn81.FieldName = "PrinName"
        Me.GridColumn81.Name = "GridColumn81"
        Me.GridColumn81.Width = 188
        '
        'GridColumn82
        '
        Me.GridColumn82.Caption = "Agent"
        Me.GridColumn82.ColumnEdit = Me.repAgentCode
        Me.GridColumn82.FieldName = "FKeyAgentCode"
        Me.GridColumn82.Name = "GridColumn82"
        Me.GridColumn82.Visible = True
        Me.GridColumn82.VisibleIndex = 17
        Me.GridColumn82.Width = 193
        '
        'repAgentCode
        '
        Me.repAgentCode.AutoHeight = False
        Me.repAgentCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAgentCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repAgentCode.DisplayMember = "Name"
        Me.repAgentCode.DropDownRows = 10
        Me.repAgentCode.Name = "repAgentCode"
        Me.repAgentCode.NullText = " "
        Me.repAgentCode.ShowFooter = False
        Me.repAgentCode.ShowHeader = False
        Me.repAgentCode.ValueMember = "PKey"
        '
        'GridColumn83
        '
        Me.GridColumn83.Caption = "AgentName"
        Me.GridColumn83.FieldName = "AgentName"
        Me.GridColumn83.Name = "GridColumn83"
        Me.GridColumn83.Width = 183
        '
        'GridColumn84
        '
        Me.GridColumn84.Caption = "Fleet Mgr"
        Me.GridColumn84.ColumnEdit = Me.repFltMgr
        Me.GridColumn84.FieldName = "FKeyFltMgrCode"
        Me.GridColumn84.Name = "GridColumn84"
        Me.GridColumn84.Visible = True
        Me.GridColumn84.VisibleIndex = 18
        Me.GridColumn84.Width = 161
        '
        'repFltMgr
        '
        Me.repFltMgr.AutoHeight = False
        Me.repFltMgr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFltMgr.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[False]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repFltMgr.DisplayMember = "Name"
        Me.repFltMgr.DropDownRows = 10
        Me.repFltMgr.Name = "repFltMgr"
        Me.repFltMgr.NullText = " "
        Me.repFltMgr.ShowFooter = False
        Me.repFltMgr.ShowHeader = False
        Me.repFltMgr.ValueMember = "PKey"
        '
        'GridColumn85
        '
        Me.GridColumn85.Caption = "FltMgrName"
        Me.GridColumn85.FieldName = "FltMgrName"
        Me.GridColumn85.Name = "GridColumn85"
        Me.GridColumn85.Width = 166
        '
        'GridColumn86
        '
        Me.GridColumn86.Caption = "Status"
        Me.GridColumn86.ColumnEdit = Me.repFKeyStatCode
        Me.GridColumn86.FieldName = "FKeyStatCode"
        Me.GridColumn86.Name = "GridColumn86"
        Me.GridColumn86.Visible = True
        Me.GridColumn86.VisibleIndex = 4
        Me.GridColumn86.Width = 156
        '
        'repFKeyStatCode
        '
        Me.repFKeyStatCode.AutoHeight = False
        Me.repFKeyStatCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFKeyStatCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repFKeyStatCode.DisplayMember = "Name"
        Me.repFKeyStatCode.DropDownRows = 10
        Me.repFKeyStatCode.Name = "repFKeyStatCode"
        Me.repFKeyStatCode.NullText = " "
        Me.repFKeyStatCode.ShowFooter = False
        Me.repFKeyStatCode.ShowHeader = False
        Me.repFKeyStatCode.ValueMember = "PKey"
        '
        'GridColumn87
        '
        Me.GridColumn87.Caption = "StatName"
        Me.GridColumn87.FieldName = "StatName"
        Me.GridColumn87.Name = "GridColumn87"
        '
        'GridColumn88
        '
        Me.GridColumn88.Caption = "ActDateStart"
        Me.GridColumn88.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn88.FieldName = "ActDateStart"
        Me.GridColumn88.Name = "GridColumn88"
        Me.GridColumn88.Visible = True
        Me.GridColumn88.VisibleIndex = 19
        Me.GridColumn88.Width = 128
        '
        'GridColumn89
        '
        Me.GridColumn89.Caption = "ActDateEnd"
        Me.GridColumn89.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn89.FieldName = "ActDateEnd"
        Me.GridColumn89.Name = "GridColumn89"
        Me.GridColumn89.Visible = True
        Me.GridColumn89.VisibleIndex = 20
        Me.GridColumn89.Width = 133
        '
        'GridColumn90
        '
        Me.GridColumn90.Caption = "Rank"
        Me.GridColumn90.ColumnEdit = Me.repFKeyRank
        Me.GridColumn90.FieldName = "FKeyRankCode"
        Me.GridColumn90.Name = "GridColumn90"
        Me.GridColumn90.Visible = True
        Me.GridColumn90.VisibleIndex = 3
        Me.GridColumn90.Width = 146
        '
        'repFKeyRank
        '
        Me.repFKeyRank.AutoHeight = False
        Me.repFKeyRank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFKeyRank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repFKeyRank.DisplayMember = "Name"
        Me.repFKeyRank.DropDownRows = 10
        Me.repFKeyRank.Name = "repFKeyRank"
        Me.repFKeyRank.NullText = " "
        Me.repFKeyRank.ShowFooter = False
        Me.repFKeyRank.ShowHeader = False
        Me.repFKeyRank.ValueMember = "PKey"
        '
        'GridColumn91
        '
        Me.GridColumn91.Caption = "RankName"
        Me.GridColumn91.FieldName = "RankName"
        Me.GridColumn91.Name = "GridColumn91"
        '
        'GridColumn92
        '
        Me.GridColumn92.Caption = "DateSOff"
        Me.GridColumn92.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn92.FieldName = "DateSOff"
        Me.GridColumn92.Name = "GridColumn92"
        Me.GridColumn92.Visible = True
        Me.GridColumn92.VisibleIndex = 6
        Me.GridColumn92.Width = 116
        '
        'GridColumn93
        '
        Me.GridColumn93.Caption = "PlaceSOn"
        Me.GridColumn93.ColumnEdit = Me.repFKeyPort
        Me.GridColumn93.FieldName = "PlaceSOn"
        Me.GridColumn93.Name = "GridColumn93"
        Me.GridColumn93.Visible = True
        Me.GridColumn93.VisibleIndex = 21
        Me.GridColumn93.Width = 128
        '
        'GridColumn94
        '
        Me.GridColumn94.Caption = "DateSOn"
        Me.GridColumn94.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn94.FieldName = "DateSOn"
        Me.GridColumn94.Name = "GridColumn94"
        Me.GridColumn94.Visible = True
        Me.GridColumn94.VisibleIndex = 5
        Me.GridColumn94.Width = 149
        '
        'GridColumn95
        '
        Me.GridColumn95.Caption = "PlaceSOff"
        Me.GridColumn95.ColumnEdit = Me.repFKeyPort
        Me.GridColumn95.FieldName = "PlaceSOff"
        Me.GridColumn95.Name = "GridColumn95"
        Me.GridColumn95.Visible = True
        Me.GridColumn95.VisibleIndex = 22
        Me.GridColumn95.Width = 157
        '
        'GridColumn96
        '
        Me.GridColumn96.Caption = "Wage Scale"
        Me.GridColumn96.ColumnEdit = Me.repFkeyWScale
        Me.GridColumn96.FieldName = "FkeyWScaleCode"
        Me.GridColumn96.Name = "GridColumn96"
        Me.GridColumn96.Width = 140
        '
        'repFkeyWScale
        '
        Me.repFkeyWScale.AutoHeight = False
        Me.repFkeyWScale.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repFkeyWScale.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repFkeyWScale.DisplayMember = "Name"
        Me.repFkeyWScale.DropDownRows = 10
        Me.repFkeyWScale.Name = "repFkeyWScale"
        Me.repFkeyWScale.NullText = " "
        Me.repFkeyWScale.ShowFooter = False
        Me.repFkeyWScale.ShowHeader = False
        Me.repFkeyWScale.ValueMember = "PKey"
        '
        'GridColumn97
        '
        Me.GridColumn97.Caption = "Wage Scale Rank"
        Me.GridColumn97.ColumnEdit = Me.repWScalRank
        Me.GridColumn97.FieldName = "FKeyWScaleRankCode"
        Me.GridColumn97.Name = "GridColumn97"
        Me.GridColumn97.Width = 144
        '
        'repWScalRank
        '
        Me.repWScalRank.AutoHeight = False
        Me.repWScalRank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repWScalRank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repWScalRank.DisplayMember = "Name"
        Me.repWScalRank.DropDownRows = 10
        Me.repWScalRank.Name = "repWScalRank"
        Me.repWScalRank.NullText = " "
        Me.repWScalRank.ShowFooter = False
        Me.repWScalRank.ShowHeader = False
        Me.repWScalRank.ValueMember = "PKey"
        '
        'GridColumn98
        '
        Me.GridColumn98.Caption = "RelievedID"
        Me.GridColumn98.FieldName = "RelievedID"
        Me.GridColumn98.Name = "GridColumn98"
        '
        'GridColumn99
        '
        Me.GridColumn99.Caption = "Remarks"
        Me.GridColumn99.FieldName = "Remarks"
        Me.GridColumn99.Name = "GridColumn99"
        Me.GridColumn99.Width = 213
        '
        'GridColumn100
        '
        Me.GridColumn100.Caption = "DateUpdated"
        Me.GridColumn100.FieldName = "DateUpdated"
        Me.GridColumn100.Name = "GridColumn100"
        '
        'GridColumn101
        '
        Me.GridColumn101.Caption = "LastUpdatedBy"
        Me.GridColumn101.FieldName = "LastUpdatedBy"
        Me.GridColumn101.Name = "GridColumn101"
        '
        'GridColumn102
        '
        Me.GridColumn102.Caption = "DateStarted"
        Me.GridColumn102.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn102.FieldName = "DateStarted"
        Me.GridColumn102.Name = "GridColumn102"
        Me.GridColumn102.Visible = True
        Me.GridColumn102.VisibleIndex = 7
        Me.GridColumn102.Width = 113
        '
        'GridColumn103
        '
        Me.GridColumn103.Caption = "DateEnded"
        Me.GridColumn103.ColumnEdit = Me.repOthDateEdit
        Me.GridColumn103.FieldName = "DateEnded"
        Me.GridColumn103.Name = "GridColumn103"
        Me.GridColumn103.Visible = True
        Me.GridColumn103.VisibleIndex = 8
        Me.GridColumn103.Width = 108
        '
        'GridColumn104
        '
        Me.GridColumn104.Caption = "Edited"
        Me.GridColumn104.FieldName = "Edited"
        Me.GridColumn104.Name = "GridColumn104"
        '
        'GridColumn107
        '
        Me.GridColumn107.Caption = "SignOFF Status"
        Me.GridColumn107.ColumnEdit = Me.repSignOffStat
        Me.GridColumn107.FieldName = "SOFFStat"
        Me.GridColumn107.Name = "GridColumn107"
        Me.GridColumn107.Visible = True
        Me.GridColumn107.VisibleIndex = 23
        '
        'repReliver
        '
        Me.repReliver.AutoHeight = False
        Me.repReliver.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repReliver.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repReliver.DisplayMember = "Name"
        Me.repReliver.DropDownRows = 10
        Me.repReliver.Name = "repReliver"
        Me.repReliver.NullText = " "
        Me.repReliver.ShowFooter = False
        Me.repReliver.ShowHeader = False
        Me.repReliver.ValueMember = "PKey"
        '
        'AshGrid
        '
        Me.AshGrid.Location = New System.Drawing.Point(35, 62)
        Me.AshGrid.MainView = Me.AshView
        Me.AshGrid.Name = "AshGrid"
        Me.AshGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.AshRepStat, Me.RepositoryItemDateEdit2, Me.repAshRemarks})
        Me.AshGrid.Size = New System.Drawing.Size(998, 450)
        Me.AshGrid.TabIndex = 5
        Me.AshGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AshView})
        '
        'AshView
        '
        Me.AshView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.AshView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn35, Me.GridColumn36, Me.GridColumn114, Me.GridColumn115, Me.GridColumn117})
        Me.AshView.GridControl = Me.AshGrid
        Me.AshView.Name = "AshView"
        Me.AshView.OptionsView.ColumnAutoWidth = False
        Me.AshView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "IDNbr"
        Me.GridColumn19.FieldName = "IDNbr"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "ActGrpID"
        Me.GridColumn20.FieldName = "ActGrpID"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "ActID"
        Me.GridColumn21.FieldName = "ActID"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Vessel"
        Me.GridColumn22.FieldName = "Vessel"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Width = 214
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Rank"
        Me.GridColumn23.FieldName = "Rank"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 0
        Me.GridColumn23.Width = 191
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "FKeyRankCode"
        Me.GridColumn24.FieldName = "FKeyRankCode"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Width = 157
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Wage Scale"
        Me.GridColumn25.FieldName = "WageScale"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 2
        Me.GridColumn25.Width = 159
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Seniority"
        Me.GridColumn26.FieldName = "Seniority"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Width = 117
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Date Started"
        Me.GridColumn27.ColumnEdit = Me.RepositoryItemDateEdit2
        Me.GridColumn27.FieldName = "DateStarted"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 3
        Me.GridColumn27.Width = 177
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.Mask.EditMask = "dd-MMM-yyyy"
        Me.RepositoryItemDateEdit2.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Date Ended"
        Me.GridColumn28.ColumnEdit = Me.RepositoryItemDateEdit2
        Me.GridColumn28.FieldName = "DateEnded"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 4
        Me.GridColumn28.Width = 158
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Starting Place"
        Me.GridColumn29.FieldName = "StartingPlace"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 7
        Me.GridColumn29.Width = 159
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Ending Place"
        Me.GridColumn30.FieldName = "EndingPlace"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 8
        Me.GridColumn30.Width = 143
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "LOC"
        Me.GridColumn31.FieldName = "LOC"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Width = 108
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Status"
        Me.GridColumn32.FieldName = "Status"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 1
        Me.GridColumn32.Width = 165
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Activity Type"
        Me.GridColumn35.FieldName = "ActivityType"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.Width = 70
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "rn"
        Me.GridColumn36.FieldName = "rn"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.Width = 20
        '
        'GridColumn114
        '
        Me.GridColumn114.Caption = "Agent"
        Me.GridColumn114.FieldName = "AgentName"
        Me.GridColumn114.Name = "GridColumn114"
        Me.GridColumn114.Visible = True
        Me.GridColumn114.VisibleIndex = 5
        Me.GridColumn114.Width = 186
        '
        'GridColumn115
        '
        Me.GridColumn115.Caption = "Principal"
        Me.GridColumn115.FieldName = "PrinName"
        Me.GridColumn115.Name = "GridColumn115"
        Me.GridColumn115.Visible = True
        Me.GridColumn115.VisibleIndex = 6
        Me.GridColumn115.Width = 214
        '
        'GridColumn117
        '
        Me.GridColumn117.Caption = "Remarks"
        Me.GridColumn117.ColumnEdit = Me.repAshRemarks
        Me.GridColumn117.FieldName = "Remarks"
        Me.GridColumn117.Name = "GridColumn117"
        Me.GridColumn117.Visible = True
        Me.GridColumn117.VisibleIndex = 9
        '
        'repAshRemarks
        '
        Me.repAshRemarks.Name = "repAshRemarks"
        '
        'AshRepStat
        '
        Me.AshRepStat.AutoHeight = False
        Me.AshRepStat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AshRepStat.DisplayMember = "Name"
        Me.AshRepStat.Name = "AshRepStat"
        Me.AshRepStat.NullText = " "
        Me.AshRepStat.ShowFooter = False
        Me.AshRepStat.ShowHeader = False
        Me.AshRepStat.ValueMember = "PKey"
        '
        'SeaServGrid
        '
        Me.SeaServGrid.Location = New System.Drawing.Point(35, 62)
        Me.SeaServGrid.MainView = Me.SeaServView
        Me.SeaServGrid.Name = "SeaServGrid"
        Me.SeaServGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SearepStat, Me.RepositoryItemDateEdit1, Me.repCompServRemarks})
        Me.SeaServGrid.Size = New System.Drawing.Size(998, 450)
        Me.SeaServGrid.TabIndex = 4
        Me.SeaServGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SeaServView})
        '
        'SeaServView
        '
        Me.SeaServView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SeaServView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn125, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn17, Me.GridColumn18, Me.GridColumn34, Me.GridColumn105, Me.GridColumn112, Me.GridColumn113, Me.GridColumn116, Me.SeaServDateDep, Me.SeaServDateArr, Me.SeaServDateSOn, Me.SeaServDateSOff})
        Me.SeaServView.GridControl = Me.SeaServGrid
        Me.SeaServView.Name = "SeaServView"
        Me.SeaServView.OptionsView.ColumnAutoWidth = False
        Me.SeaServView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "IDNbr"
        Me.GridColumn1.FieldName = "IDNbr"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ActGrpID"
        Me.GridColumn2.FieldName = "ActGrpID"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ActID"
        Me.GridColumn3.FieldName = "ActID"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Vessel"
        Me.GridColumn4.FieldName = "Vessel"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 176
        '
        'GridColumn125
        '
        Me.GridColumn125.Caption = "Vessel Type"
        Me.GridColumn125.FieldName = "VslType"
        Me.GridColumn125.Name = "GridColumn125"
        Me.GridColumn125.Visible = True
        Me.GridColumn125.VisibleIndex = 1
        Me.GridColumn125.Width = 154
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Rank"
        Me.GridColumn5.FieldName = "Rank"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 191
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "FKeyRankCode"
        Me.GridColumn6.FieldName = "FKeyRankCode"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn6.Width = 157
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Wage Scale"
        Me.GridColumn7.FieldName = "WScaleRankName"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 13
        Me.GridColumn7.Width = 159
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Seniority"
        Me.GridColumn8.FieldName = "Seniority"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Width = 117
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Date Started"
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn9.FieldName = "DateStarted"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 6
        Me.GridColumn9.Width = 177
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Mask.EditMask = "dd-MMM-yyyy"
        Me.RepositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Date Ended"
        Me.GridColumn10.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn10.FieldName = "DateEnded"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 7
        Me.GridColumn10.Width = 158
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Starting Place"
        Me.GridColumn11.FieldName = "StartingPlace"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 15
        Me.GridColumn11.Width = 159
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Ending Place"
        Me.GridColumn12.FieldName = "EndingPlace"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 16
        Me.GridColumn12.Width = 143
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "LOC"
        Me.GridColumn13.FieldName = "LOC"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 14
        Me.GridColumn13.Width = 108
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Status"
        Me.GridColumn14.FieldName = "Status"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 158
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Activity Type"
        Me.GridColumn17.FieldName = "ActivityType"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn17.Width = 70
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "rn"
        Me.GridColumn18.FieldName = "rn"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn18.Width = 20
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Edited"
        Me.GridColumn34.FieldName = "Edited"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn34.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn105
        '
        Me.GridColumn105.Caption = "Sign Off Reason"
        Me.GridColumn105.ColumnEdit = Me.SearepStat
        Me.GridColumn105.FieldName = "SOFFStat"
        Me.GridColumn105.Name = "GridColumn105"
        Me.GridColumn105.Visible = True
        Me.GridColumn105.VisibleIndex = 4
        Me.GridColumn105.Width = 222
        '
        'SearepStat
        '
        Me.SearepStat.AutoHeight = False
        Me.SearepStat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearepStat.DisplayMember = "Name"
        Me.SearepStat.Name = "SearepStat"
        Me.SearepStat.NullText = " "
        Me.SearepStat.ShowFooter = False
        Me.SearepStat.ShowHeader = False
        Me.SearepStat.ValueMember = "PKey"
        '
        'GridColumn112
        '
        Me.GridColumn112.Caption = "Agent"
        Me.GridColumn112.FieldName = "AgentName"
        Me.GridColumn112.Name = "GridColumn112"
        Me.GridColumn112.Visible = True
        Me.GridColumn112.VisibleIndex = 9
        Me.GridColumn112.Width = 192
        '
        'GridColumn113
        '
        Me.GridColumn113.Caption = "Principal"
        Me.GridColumn113.FieldName = "PrinName"
        Me.GridColumn113.Name = "GridColumn113"
        Me.GridColumn113.Visible = True
        Me.GridColumn113.VisibleIndex = 10
        Me.GridColumn113.Width = 186
        '
        'GridColumn116
        '
        Me.GridColumn116.Caption = "Remarks"
        Me.GridColumn116.ColumnEdit = Me.repCompServRemarks
        Me.GridColumn116.FieldName = "Remarks"
        Me.GridColumn116.Name = "GridColumn116"
        Me.GridColumn116.Visible = True
        Me.GridColumn116.VisibleIndex = 17
        '
        'repCompServRemarks
        '
        Me.repCompServRemarks.Name = "repCompServRemarks"
        '
        'SeaServDateDep
        '
        Me.SeaServDateDep.Caption = "Date Depart"
        Me.SeaServDateDep.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.SeaServDateDep.FieldName = "ActDateDep"
        Me.SeaServDateDep.Name = "SeaServDateDep"
        Me.SeaServDateDep.Visible = True
        Me.SeaServDateDep.VisibleIndex = 5
        Me.SeaServDateDep.Width = 190
        '
        'SeaServDateArr
        '
        Me.SeaServDateArr.Caption = "Date Arrived"
        Me.SeaServDateArr.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.SeaServDateArr.FieldName = "ActDateArr"
        Me.SeaServDateArr.Name = "SeaServDateArr"
        Me.SeaServDateArr.Visible = True
        Me.SeaServDateArr.VisibleIndex = 8
        Me.SeaServDateArr.Width = 187
        '
        'SeaServDateSOn
        '
        Me.SeaServDateSOn.Caption = "Date Sign On"
        Me.SeaServDateSOn.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.SeaServDateSOn.FieldName = "ActDateSOn"
        Me.SeaServDateSOn.Name = "SeaServDateSOn"
        Me.SeaServDateSOn.Visible = True
        Me.SeaServDateSOn.VisibleIndex = 11
        Me.SeaServDateSOn.Width = 146
        '
        'SeaServDateSOff
        '
        Me.SeaServDateSOff.Caption = "Date Sign Off"
        Me.SeaServDateSOff.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.SeaServDateSOff.FieldName = "ActDateSOff"
        Me.SeaServDateSOff.Name = "SeaServDateSOff"
        Me.SeaServDateSOff.Visible = True
        Me.SeaServDateSOff.VisibleIndex = 12
        Me.SeaServDateSOff.Width = 162
        '
        'OtherGrid
        '
        Me.OtherGrid.Location = New System.Drawing.Point(35, 62)
        Me.OtherGrid.MainView = Me.OtherView
        Me.OtherGrid.Name = "OtherGrid"
        Me.OtherGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repOthSOFFStat, Me.repVslTypeName, Me.repStatName, Me.repOthRankName, Me.repOthPort, Me.repDateEdit, Me.repremarks, Me.repLOC, Me.repYrBuilt})
        Me.OtherGrid.Size = New System.Drawing.Size(998, 450)
        Me.OtherGrid.TabIndex = 4
        Me.OtherGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.OtherView})
        '
        'OtherView
        '
        Me.OtherView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.OtherView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn108, Me.GridColumn110, Me.GridColumn33, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn111, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58, Me.GridColumn59, Me.GridColumn109, Me.GridColumn138, Me.OtherSeaServDateDep, Me.OtherSeaServDateArr})
        Me.OtherView.GridControl = Me.OtherGrid
        Me.OtherView.Name = "OtherView"
        Me.OtherView.OptionsLayout.Columns.RemoveOldColumns = False
        Me.OtherView.OptionsLayout.StoreAllOptions = True
        Me.OtherView.OptionsView.ColumnAutoWidth = False
        Me.OtherView.OptionsView.RowAutoHeight = True
        Me.OtherView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "IDNbr"
        Me.GridColumn15.FieldName = "IDNbr"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn15.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ActID"
        Me.GridColumn16.FieldName = "ActID"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn16.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn108
        '
        Me.GridColumn108.Caption = "ActGroupID"
        Me.GridColumn108.FieldName = "ActGroupID"
        Me.GridColumn108.Name = "GridColumn108"
        Me.GridColumn108.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn108.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumn110
        '
        Me.GridColumn110.Caption = "Sign Off Reason "
        Me.GridColumn110.ColumnEdit = Me.repOthSOFFStat
        Me.GridColumn110.FieldName = "SOFFStat"
        Me.GridColumn110.Name = "GridColumn110"
        Me.GridColumn110.Visible = True
        Me.GridColumn110.VisibleIndex = 3
        Me.GridColumn110.Width = 136
        '
        'repOthSOFFStat
        '
        Me.repOthSOFFStat.AutoHeight = False
        Me.repOthSOFFStat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repOthSOFFStat.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repOthSOFFStat.DisplayMember = "Name"
        Me.repOthSOFFStat.Name = "repOthSOFFStat"
        Me.repOthSOFFStat.NullText = " "
        Me.repOthSOFFStat.ShowFooter = False
        Me.repOthSOFFStat.ShowHeader = False
        Me.repOthSOFFStat.ValueMember = "PKey"
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Length Of Contract (Month)"
        Me.GridColumn33.ColumnEdit = Me.repLOC
        Me.GridColumn33.FieldName = "LOC"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 11
        Me.GridColumn33.Width = 94
        '
        'repLOC
        '
        Me.repLOC.AutoHeight = False
        Me.repLOC.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repLOC.Name = "repLOC"
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Length of Contract (Days)"
        Me.GridColumn37.ColumnEdit = Me.repLOC
        Me.GridColumn37.FieldName = "LOCDays"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 10
        Me.GridColumn37.Width = 103
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Vessel"
        Me.GridColumn38.FieldName = "VslName"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 0
        Me.GridColumn38.Width = 147
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "IMO No."
        Me.GridColumn39.FieldName = "IMONo"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 16
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Vessel Type"
        Me.GridColumn40.ColumnEdit = Me.repVslTypeName
        Me.GridColumn40.FieldName = "VslTypeName"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 15
        Me.GridColumn40.Width = 123
        '
        'repVslTypeName
        '
        Me.repVslTypeName.AutoHeight = False
        Me.repVslTypeName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repVslTypeName.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repVslTypeName.DisplayMember = "Name"
        Me.repVslTypeName.Name = "repVslTypeName"
        Me.repVslTypeName.NullText = " "
        Me.repVslTypeName.ShowFooter = False
        Me.repVslTypeName.ShowHeader = False
        Me.repVslTypeName.ValueMember = "Name"
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Dead Weight"
        Me.GridColumn41.FieldName = "DeadWt"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 17
        Me.GridColumn41.Width = 84
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Gross Ton"
        Me.GridColumn43.FieldName = "GrossTon"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 18
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Engine Type"
        Me.GridColumn44.FieldName = "EngType"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 19
        Me.GridColumn44.Width = 96
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Engine Power"
        Me.GridColumn45.FieldName = "EngPower"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 20
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Year Built"
        Me.GridColumn46.ColumnEdit = Me.repYrBuilt
        Me.GridColumn46.FieldName = "YrBuilt"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 21
        Me.GridColumn46.Width = 69
        '
        'repYrBuilt
        '
        Me.repYrBuilt.AutoHeight = False
        Me.repYrBuilt.Mask.EditMask = "d4"
        Me.repYrBuilt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repYrBuilt.Mask.UseMaskAsDisplayFormat = True
        Me.repYrBuilt.Name = "repYrBuilt"
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "Auxillaries"
        Me.GridColumn47.FieldName = "Auxillaries"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 22
        Me.GridColumn47.Width = 93
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Principal"
        Me.GridColumn48.FieldName = "PrinName"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 8
        Me.GridColumn48.Width = 167
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Agent"
        Me.GridColumn49.FieldName = "AgentName"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 9
        Me.GridColumn49.Width = 165
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Fleet Manager"
        Me.GridColumn50.FieldName = "FltMgrName"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 23
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "Status"
        Me.GridColumn51.ColumnEdit = Me.repStatName
        Me.GridColumn51.FieldName = "StatName"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.Visible = True
        Me.GridColumn51.VisibleIndex = 2
        Me.GridColumn51.Width = 146
        '
        'repStatName
        '
        Me.repStatName.AutoHeight = False
        Me.repStatName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repStatName.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repStatName.DisplayMember = "Name"
        Me.repStatName.Name = "repStatName"
        Me.repStatName.NullText = " "
        Me.repStatName.ShowFooter = False
        Me.repStatName.ShowHeader = False
        Me.repStatName.ValueMember = "Name"
        '
        'GridColumn52
        '
        Me.GridColumn52.Caption = "Date Started"
        Me.GridColumn52.ColumnEdit = Me.repDateEdit
        Me.GridColumn52.FieldName = "ActDateStart"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 12
        Me.GridColumn52.Width = 107
        '
        'repDateEdit
        '
        Me.repDateEdit.AutoHeight = False
        Me.repDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.repDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.repDateEdit.Name = "repDateEdit"
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "Date Ended"
        Me.GridColumn53.ColumnEdit = Me.repDateEdit
        Me.GridColumn53.FieldName = "ActDateEnd"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 13
        Me.GridColumn53.Width = 122
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "Rank"
        Me.GridColumn54.ColumnEdit = Me.repOthRankName
        Me.GridColumn54.FieldName = "RankName"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 1
        Me.GridColumn54.Width = 140
        '
        'repOthRankName
        '
        Me.repOthRankName.AutoHeight = False
        Me.repOthRankName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repOthRankName.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repOthRankName.DisplayMember = "Name"
        Me.repOthRankName.Name = "repOthRankName"
        Me.repOthRankName.NullText = " "
        Me.repOthRankName.ShowFooter = False
        Me.repOthRankName.ShowHeader = False
        Me.repOthRankName.ValueMember = "Name"
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "Date Sign Off"
        Me.GridColumn55.ColumnEdit = Me.repDateEdit
        Me.GridColumn55.FieldName = "ActDateSOff"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 6
        Me.GridColumn55.Width = 169
        '
        'GridColumn111
        '
        Me.GridColumn111.Caption = "Date Sign On"
        Me.GridColumn111.ColumnEdit = Me.repDateEdit
        Me.GridColumn111.FieldName = "ActDateSOn"
        Me.GridColumn111.Name = "GridColumn111"
        Me.GridColumn111.Visible = True
        Me.GridColumn111.VisibleIndex = 5
        Me.GridColumn111.Width = 153
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "Place Sign Off"
        Me.GridColumn56.ColumnEdit = Me.repOthPort
        Me.GridColumn56.FieldName = "PlaceSOff"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 25
        Me.GridColumn56.Width = 127
        '
        'repOthPort
        '
        Me.repOthPort.AutoHeight = False
        Me.repOthPort.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repOthPort.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repOthPort.DisplayMember = "Name"
        Me.repOthPort.Name = "repOthPort"
        Me.repOthPort.NullText = " "
        Me.repOthPort.ShowFooter = False
        Me.repOthPort.ShowHeader = False
        Me.repOthPort.ValueMember = "Name"
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "Place Sign On"
        Me.GridColumn57.ColumnEdit = Me.repOthPort
        Me.GridColumn57.FieldName = "PlaceSOn"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 24
        Me.GridColumn57.Width = 144
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "Remarks"
        Me.GridColumn58.ColumnEdit = Me.repremarks
        Me.GridColumn58.FieldName = "Remarks"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 26
        '
        'repremarks
        '
        Me.repremarks.MaxLength = 200
        Me.repremarks.Name = "repremarks"
        '
        'GridColumn59
        '
        Me.GridColumn59.Caption = "Fleet"
        Me.GridColumn59.FieldName = "FltName"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.Visible = True
        Me.GridColumn59.VisibleIndex = 14
        '
        'GridColumn109
        '
        Me.GridColumn109.Caption = "Edited"
        Me.GridColumn109.FieldName = "Edited"
        Me.GridColumn109.Name = "GridColumn109"
        Me.GridColumn109.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn109.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'OtherSeaServDateDep
        '
        Me.OtherSeaServDateDep.Caption = "Date Depart"
        Me.OtherSeaServDateDep.ColumnEdit = Me.repDateEdit
        Me.OtherSeaServDateDep.FieldName = "ActDateDep"
        Me.OtherSeaServDateDep.Name = "OtherSeaServDateDep"
        Me.OtherSeaServDateDep.Visible = True
        Me.OtherSeaServDateDep.VisibleIndex = 4
        Me.OtherSeaServDateDep.Width = 157
        '
        'OtherSeaServDateArr
        '
        Me.OtherSeaServDateArr.Caption = "Date Arrived"
        Me.OtherSeaServDateArr.ColumnEdit = Me.repDateEdit
        Me.OtherSeaServDateArr.FieldName = "ActDateArr"
        Me.OtherSeaServDateArr.Name = "OtherSeaServDateArr"
        Me.OtherSeaServDateArr.Visible = True
        Me.OtherSeaServDateArr.VisibleIndex = 7
        Me.OtherSeaServDateArr.Width = 179
        '
        'LDGrid
        '
        Me.LDGrid.Location = New System.Drawing.Point(35, 62)
        Me.LDGrid.MainView = Me.LDView
        Me.LDGrid.Name = "LDGrid"
        Me.LDGrid.Size = New System.Drawing.Size(998, 326)
        Me.LDGrid.TabIndex = 7
        Me.LDGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LDView})
        '
        'LDView
        '
        Me.LDView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn127, Me.GridColumn128, Me.GridColumn129, Me.GridColumn130, Me.GridColumn131, Me.GridColumn132, Me.GridColumn133, Me.GridColumn134, Me.GridColumn137, Me.GridColumn135, Me.GridColumn136, Me.LDWScaleRank})
        Me.LDView.GridControl = Me.LDGrid
        Me.LDView.Name = "LDView"
        Me.LDView.OptionsCustomization.AllowQuickHideColumns = False
        Me.LDView.OptionsMenu.EnableColumnMenu = False
        Me.LDView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn127
        '
        Me.GridColumn127.Caption = "GridColumn1"
        Me.GridColumn127.FieldName = "PKey"
        Me.GridColumn127.Name = "GridColumn127"
        Me.GridColumn127.OptionsColumn.AllowFocus = False
        '
        'GridColumn128
        '
        Me.GridColumn128.Caption = "Activity"
        Me.GridColumn128.FieldName = "Activity"
        Me.GridColumn128.Name = "GridColumn128"
        Me.GridColumn128.OptionsColumn.AllowFocus = False
        Me.GridColumn128.Visible = True
        Me.GridColumn128.VisibleIndex = 0
        '
        'GridColumn129
        '
        Me.GridColumn129.Caption = "Vessel"
        Me.GridColumn129.FieldName = "Vessel"
        Me.GridColumn129.Name = "GridColumn129"
        Me.GridColumn129.OptionsColumn.AllowFocus = False
        Me.GridColumn129.Visible = True
        Me.GridColumn129.VisibleIndex = 1
        '
        'GridColumn130
        '
        Me.GridColumn130.Caption = "Rank"
        Me.GridColumn130.FieldName = "RankName"
        Me.GridColumn130.Name = "GridColumn130"
        Me.GridColumn130.OptionsColumn.AllowFocus = False
        Me.GridColumn130.Visible = True
        Me.GridColumn130.VisibleIndex = 2
        '
        'GridColumn131
        '
        Me.GridColumn131.Caption = "Date Start"
        Me.GridColumn131.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.GridColumn131.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn131.FieldName = "ActDateStart"
        Me.GridColumn131.Name = "GridColumn131"
        Me.GridColumn131.OptionsColumn.AllowFocus = False
        Me.GridColumn131.Visible = True
        Me.GridColumn131.VisibleIndex = 4
        '
        'GridColumn132
        '
        Me.GridColumn132.Caption = "Date End"
        Me.GridColumn132.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.GridColumn132.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn132.FieldName = "ActDateEnd"
        Me.GridColumn132.Name = "GridColumn132"
        Me.GridColumn132.OptionsColumn.AllowFocus = False
        Me.GridColumn132.Visible = True
        Me.GridColumn132.VisibleIndex = 5
        '
        'GridColumn133
        '
        Me.GridColumn133.Caption = "Days"
        Me.GridColumn133.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn133.FieldName = "TotalDays"
        Me.GridColumn133.Name = "GridColumn133"
        Me.GridColumn133.OptionsColumn.AllowFocus = False
        Me.GridColumn133.Visible = True
        Me.GridColumn133.VisibleIndex = 6
        '
        'GridColumn134
        '
        Me.GridColumn134.Caption = "Leave Days Earned"
        Me.GridColumn134.FieldName = "LDEarn"
        Me.GridColumn134.Name = "GridColumn134"
        Me.GridColumn134.OptionsColumn.AllowFocus = False
        Me.GridColumn134.Visible = True
        Me.GridColumn134.VisibleIndex = 7
        '
        'GridColumn137
        '
        Me.GridColumn137.Caption = "Leave Days Consumed"
        Me.GridColumn137.FieldName = "LDConsumed"
        Me.GridColumn137.Name = "GridColumn137"
        Me.GridColumn137.OptionsColumn.AllowFocus = False
        Me.GridColumn137.Visible = True
        Me.GridColumn137.VisibleIndex = 9
        '
        'GridColumn135
        '
        Me.GridColumn135.Caption = "Leave Pay Earned"
        Me.GridColumn135.DisplayFormat.FormatString = "n2"
        Me.GridColumn135.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn135.FieldName = "LPEarn"
        Me.GridColumn135.Name = "GridColumn135"
        Me.GridColumn135.OptionsColumn.AllowFocus = False
        Me.GridColumn135.Visible = True
        Me.GridColumn135.VisibleIndex = 8
        '
        'GridColumn136
        '
        Me.GridColumn136.Caption = "Leave Pay Consumed"
        Me.GridColumn136.DisplayFormat.FormatString = "n2"
        Me.GridColumn136.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn136.FieldName = "LPConsumed"
        Me.GridColumn136.Name = "GridColumn136"
        Me.GridColumn136.OptionsColumn.AllowFocus = False
        Me.GridColumn136.Visible = True
        Me.GridColumn136.VisibleIndex = 10
        '
        'LDWScaleRank
        '
        Me.LDWScaleRank.Caption = "Wage Scale"
        Me.LDWScaleRank.FieldName = "WScaleRank"
        Me.LDWScaleRank.Name = "LDWScaleRank"
        Me.LDWScaleRank.OptionsColumn.AllowFocus = False
        Me.LDWScaleRank.Visible = True
        Me.LDWScaleRank.VisibleIndex = 3
        '
        'txtTotalDays
        '
        Me.txtTotalDays.EditValue = "0"
        Me.txtTotalDays.Location = New System.Drawing.Point(146, 426)
        Me.txtTotalDays.Name = "txtTotalDays"
        Me.txtTotalDays.Properties.Mask.EditMask = "n2"
        Me.txtTotalDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtTotalDays.Properties.ReadOnly = True
        Me.txtTotalDays.Size = New System.Drawing.Size(297, 22)
        Me.txtTotalDays.StyleController = Me.LayoutControl1
        Me.txtTotalDays.TabIndex = 4
        '
        'txtConsumedDays
        '
        Me.txtConsumedDays.EditValue = "0"
        Me.txtConsumedDays.Location = New System.Drawing.Point(146, 452)
        Me.txtConsumedDays.Name = "txtConsumedDays"
        Me.txtConsumedDays.Properties.Mask.EditMask = "n2"
        Me.txtConsumedDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtConsumedDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtConsumedDays.Properties.ReadOnly = True
        Me.txtConsumedDays.Size = New System.Drawing.Size(297, 22)
        Me.txtConsumedDays.StyleController = Me.LayoutControl1
        Me.txtConsumedDays.TabIndex = 5
        '
        'txtRemainingDays
        '
        Me.txtRemainingDays.EditValue = "0"
        Me.txtRemainingDays.Location = New System.Drawing.Point(146, 478)
        Me.txtRemainingDays.Name = "txtRemainingDays"
        Me.txtRemainingDays.Properties.Mask.EditMask = "n2"
        Me.txtRemainingDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRemainingDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtRemainingDays.Properties.ReadOnly = True
        Me.txtRemainingDays.Size = New System.Drawing.Size(297, 22)
        Me.txtRemainingDays.StyleController = Me.LayoutControl1
        Me.txtRemainingDays.TabIndex = 6
        '
        'txtTotalPay
        '
        Me.txtTotalPay.EditValue = "0"
        Me.txtTotalPay.Location = New System.Drawing.Point(570, 426)
        Me.txtTotalPay.Name = "txtTotalPay"
        Me.txtTotalPay.Properties.Mask.EditMask = "n2"
        Me.txtTotalPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalPay.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtTotalPay.Properties.ReadOnly = True
        Me.txtTotalPay.Size = New System.Drawing.Size(451, 22)
        Me.txtTotalPay.StyleController = Me.LayoutControl1
        Me.txtTotalPay.TabIndex = 8
        '
        'txtConsumedPay
        '
        Me.txtConsumedPay.EditValue = "0"
        Me.txtConsumedPay.Location = New System.Drawing.Point(570, 452)
        Me.txtConsumedPay.Name = "txtConsumedPay"
        Me.txtConsumedPay.Properties.Mask.EditMask = "n2"
        Me.txtConsumedPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtConsumedPay.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtConsumedPay.Properties.ReadOnly = True
        Me.txtConsumedPay.Size = New System.Drawing.Size(451, 22)
        Me.txtConsumedPay.StyleController = Me.LayoutControl1
        Me.txtConsumedPay.TabIndex = 9
        '
        'txtRemainingPay
        '
        Me.txtRemainingPay.EditValue = "0"
        Me.txtRemainingPay.Location = New System.Drawing.Point(570, 478)
        Me.txtRemainingPay.Name = "txtRemainingPay"
        Me.txtRemainingPay.Properties.Mask.EditMask = "n2"
        Me.txtRemainingPay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRemainingPay.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtRemainingPay.Properties.ReadOnly = True
        Me.txtRemainingPay.Size = New System.Drawing.Size(451, 22)
        Me.txtRemainingPay.StyleController = Me.LayoutControl1
        Me.txtRemainingPay.TabIndex = 10
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabControl})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1068, 547)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'TabControl
        '
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10)
        Me.TabControl.SelectedTabPage = Me.LayoutControlGroup3
        Me.TabControl.SelectedTabPageIndex = 2
        Me.TabControl.Size = New System.Drawing.Size(1028, 507)
        Me.TabControl.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup4, Me.LayoutControlGroup3, Me.LayoutControlGroup5, Me.LayoutControlGroup6, Me.lcgLDHistory})
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlGroup3.Tag = "OthAct1"
        Me.LayoutControlGroup3.Text = "Other Sea Service"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.OtherGrid
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlItem3.Text = "LayoutControlItem1"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlGroup2.Tag = "SeaAct"
        Me.LayoutControlGroup2.Text = "Company Sea Service"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SeaServGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup4.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlGroup4.Tag = "AshAct"
        Me.LayoutControlGroup4.Text = "Ashore Activity"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.AshGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlGroup5.Tag = "OthAct"
        Me.LayoutControlGroup5.Text = "Other Sea Service (temp)"
        Me.LayoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.OthSeaGrid
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlGroup6.Tag = "ServSum"
        Me.LayoutControlGroup6.Text = "Sea Service Summary"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.LayoutControl2
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1002, 454)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'lcgLDHistory
        '
        Me.lcgLDHistory.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciLDGrid, Me.lcgLDSum, Me.lcgLPSum})
        Me.lcgLDHistory.Location = New System.Drawing.Point(0, 0)
        Me.lcgLDHistory.Name = "lcgLDHistory"
        Me.lcgLDHistory.Size = New System.Drawing.Size(1002, 454)
        Me.lcgLDHistory.Tag = "CrewLeaveDay"
        Me.lcgLDHistory.Text = "Leave Day History"
        '
        'lciLDGrid
        '
        Me.lciLDGrid.Control = Me.LDGrid
        Me.lciLDGrid.CustomizationFormText = "LayoutControlItem4"
        Me.lciLDGrid.Location = New System.Drawing.Point(0, 0)
        Me.lciLDGrid.Name = "lciLDGrid"
        Me.lciLDGrid.Size = New System.Drawing.Size(1002, 330)
        Me.lciLDGrid.Text = "LayoutControlItem4"
        Me.lciLDGrid.TextSize = New System.Drawing.Size(0, 0)
        Me.lciLDGrid.TextVisible = False
        '
        'lcgLDSum
        '
        Me.lcgLDSum.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcgLDSum.AppearanceGroup.Options.UseFont = True
        Me.lcgLDSum.CustomizationFormText = "Leave Days Summary"
        Me.lcgLDSum.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciTotDays, Me.lciConDays, Me.lciRemDays})
        Me.lcgLDSum.Location = New System.Drawing.Point(0, 330)
        Me.lcgLDSum.Name = "lcgLDSum"
        Me.lcgLDSum.Size = New System.Drawing.Size(424, 124)
        Me.lcgLDSum.Text = "Leave Days Summary"
        '
        'lciTotDays
        '
        Me.lciTotDays.Control = Me.txtTotalDays
        Me.lciTotDays.CustomizationFormText = "Total Days: "
        Me.lciTotDays.Location = New System.Drawing.Point(0, 0)
        Me.lciTotDays.Name = "lciTotDays"
        Me.lciTotDays.Size = New System.Drawing.Size(400, 26)
        Me.lciTotDays.Text = "Total Days: "
        Me.lciTotDays.TextSize = New System.Drawing.Size(96, 16)
        '
        'lciConDays
        '
        Me.lciConDays.Control = Me.txtConsumedDays
        Me.lciConDays.CustomizationFormText = "Consumed Days:"
        Me.lciConDays.Location = New System.Drawing.Point(0, 26)
        Me.lciConDays.Name = "lciConDays"
        Me.lciConDays.Size = New System.Drawing.Size(400, 26)
        Me.lciConDays.Text = "Consumed Days:"
        Me.lciConDays.TextSize = New System.Drawing.Size(96, 16)
        '
        'lciRemDays
        '
        Me.lciRemDays.Control = Me.txtRemainingDays
        Me.lciRemDays.CustomizationFormText = "Remaining:"
        Me.lciRemDays.Location = New System.Drawing.Point(0, 52)
        Me.lciRemDays.Name = "lciRemDays"
        Me.lciRemDays.Size = New System.Drawing.Size(400, 26)
        Me.lciRemDays.Text = "Remaining:"
        Me.lciRemDays.TextSize = New System.Drawing.Size(96, 16)
        '
        'lcgLPSum
        '
        Me.lcgLPSum.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lcgLPSum.AppearanceGroup.Options.UseFont = True
        Me.lcgLPSum.CustomizationFormText = "Leave Pay Summary"
        Me.lcgLPSum.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciTotPay, Me.lciConPay, Me.lciRemPay})
        Me.lcgLPSum.Location = New System.Drawing.Point(424, 330)
        Me.lcgLPSum.Name = "lcgLPSum"
        Me.lcgLPSum.Size = New System.Drawing.Size(578, 124)
        Me.lcgLPSum.Text = "Leave Pay Summary"
        '
        'lciTotPay
        '
        Me.lciTotPay.Control = Me.txtTotalPay
        Me.lciTotPay.CustomizationFormText = "Total Pay:"
        Me.lciTotPay.Location = New System.Drawing.Point(0, 0)
        Me.lciTotPay.Name = "lciTotPay"
        Me.lciTotPay.Size = New System.Drawing.Size(554, 26)
        Me.lciTotPay.Text = "Total Pay:"
        Me.lciTotPay.TextSize = New System.Drawing.Size(96, 16)
        '
        'lciConPay
        '
        Me.lciConPay.Control = Me.txtConsumedPay
        Me.lciConPay.CustomizationFormText = "Consumed Pay:"
        Me.lciConPay.Location = New System.Drawing.Point(0, 26)
        Me.lciConPay.Name = "lciConPay"
        Me.lciConPay.Size = New System.Drawing.Size(554, 26)
        Me.lciConPay.Text = "Consumed Pay:"
        Me.lciConPay.TextSize = New System.Drawing.Size(96, 16)
        Me.lciConPay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'lciRemPay
        '
        Me.lciRemPay.Control = Me.txtRemainingPay
        Me.lciRemPay.CustomizationFormText = "Remaining:"
        Me.lciRemPay.Location = New System.Drawing.Point(0, 52)
        Me.lciRemPay.Name = "lciRemPay"
        Me.lciRemPay.Size = New System.Drawing.Size(554, 26)
        Me.lciRemPay.Text = "Remaining:"
        Me.lciRemPay.TextSize = New System.Drawing.Size(96, 16)
        Me.lciRemPay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'Service
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "Service"
        Me.Size = New System.Drawing.Size(1072, 576)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.xheader.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.ServSumGrpGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServSumGrpView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServSumRankGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServSumRankView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OthSeaGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OthSeaView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repOthDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repOthDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFKeyPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repIsComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSignOffStat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repActType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVslCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVslName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVslType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPrinCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAgentCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFltMgr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFKeyStatCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFKeyRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFkeyWScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repWScalRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repReliver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AshGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AshView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAshRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AshRepStat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeaServGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeaServView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearepStat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCompServRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OtherGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OtherView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repOthSOFFStat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repLOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVslTypeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repYrBuilt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repStatName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repOthRankName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repOthPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repremarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LDGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LDView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsumedDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemainingDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConsumedPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemainingPay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgLDHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciLDGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgLDSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciTotDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciConDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciRemDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgLPSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciTotPay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciConPay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciRemPay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents xheader As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TabControl As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SeaServGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SeaServView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AshGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents AshView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents OtherGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents OtherView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OthSeaGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents OthSeaView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ActGrpID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Crew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn72 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn73 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn74 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn77 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn78 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn79 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn80 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn81 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn82 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn83 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn84 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn85 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn86 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn87 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn88 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn89 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn90 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn91 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn92 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn93 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn94 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn95 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn96 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn97 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn98 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn99 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn100 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn101 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn102 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn103 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repOthDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repFKeyPort As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repIsComp As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repSignOffStat As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repActType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repVslCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repVslType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repPrinCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repAgentCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repFltMgr As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repFKeyStatCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repFKeyRank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repFkeyWScale As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repWScalRank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repReliver As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn104 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repVslName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn105 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SearepStat As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn107 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AshRepStat As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn108 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn109 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn110 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn111 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repOthSOFFStat As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repVslTypeName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repStatName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repOthRankName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repOthPort As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents repDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repremarks As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumn112 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn113 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn114 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn115 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridColumn117 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repAshRemarks As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GridColumn116 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repCompServRemarks As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents repLOC As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ServSumRankGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ServSumRankView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn120 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn119 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn106 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn118 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ServSumGrpGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ServSumGrpView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn121 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn122 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn123 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents sp As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn126 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtDays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn124 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn125 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lcgLDHistory As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LDGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents LDView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn127 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn128 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn129 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn130 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn131 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn132 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn133 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn134 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn135 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn136 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtTotalDays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConsumedDays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRemainingDays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotalPay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConsumedPay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRemainingPay As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lciLDGrid As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgLDSum As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lciTotDays As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciConDays As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciRemDays As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgLPSum As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lciTotPay As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciConPay As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciRemPay As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn137 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LDWScaleRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn138 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repYrBuilt As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn139 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SeaServDateDep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SeaServDateArr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SeaServDateSOn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SeaServDateSOff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OtherSeaServDateDep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OtherSeaServDateArr As DevExpress.XtraGrid.Columns.GridColumn

End Class
