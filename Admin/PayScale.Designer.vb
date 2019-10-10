<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayScale
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayScale))
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.chkProrata = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmdUpdatePayScale = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCopyRank = New DevExpress.XtraEditors.SimpleButton()
        Me.TabOnb = New DevExpress.XtraTab.XtraTabControl()
        Me.TPageEarn = New DevExpress.XtraTab.XtraTabPage()
        Me.GrdEarn = New DevExpress.XtraGrid.GridControl()
        Me.EarnView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.EarPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EarFKeyRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.earFKeyWageOnb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuFKeyWageOnb = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.earWageType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.earFKeyCurr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEarFKeyCurr = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.earAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.earDateType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEarDateType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.earProrata = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.earAccum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkAccum = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.earFormula = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TPageDed = New DevExpress.XtraTab.XtraTabPage()
        Me.GrdDed = New DevExpress.XtraGrid.GridControl()
        Me.DedView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuFKeyWageDed = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuDedFKeyCurr = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuDedDateType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkProrataDed = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkAccumDed = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.GrdInfo = New DevExpress.XtraGrid.GridControl()
        Me.InfoView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuFKeyWageInfo = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuInfoDen = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuInfoPrd = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuInfoDateType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GrdRank = New DevExpress.XtraGrid.GridControl()
        Me.RankView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyWScale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyRank = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuFKeyRank = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colLOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLOCDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLOCRem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colYrsServ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateUpdated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtmax = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.txtAbbrv = New DevExpress.XtraEditors.TextEdit()
        Me.cboFKeyCurr = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtDateAct = New DevExpress.XtraEditors.DateEdit()
        Me.txtDateInact = New DevExpress.XtraEditors.DateEdit()
        Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
        Me.cboRateType = New DevExpress.XtraEditors.LookUpEdit()
        Me.TabAsh = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.GrdEmpe = New DevExpress.XtraGrid.GridControl()
        Me.EmpeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEmpeWageAsh = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEmpeCurr = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEmpeDateType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.GrdEmpr = New DevExpress.XtraGrid.GridControl()
        Me.EmprView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEmprWageAshEmp = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEmprCurr = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkuEmprDateType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboFKeyWScalCalendar = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Rank1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Rank = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Rank2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkProrata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TabOnb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabOnb.SuspendLayout()
        Me.TPageEarn.SuspendLayout()
        CType(Me.GrdEarn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EarnView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuFKeyWageOnb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEarFKeyCurr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEarDateType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAccum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPageDed.SuspendLayout()
        CType(Me.GrdDed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuFKeyWageDed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuDedFKeyCurr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuDedDateType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkProrataDed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAccumDed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage5.SuspendLayout()
        CType(Me.GrdInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuFKeyWageInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuInfoDen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuInfoPrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuInfoDateType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuFKeyRank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbbrv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyCurr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateAct.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateAct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateInact.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDateInact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRateType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabAsh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAsh.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.GrdEmpe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmpeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEmpeWageAsh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEmpeCurr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEmpeDateType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.GrdEmpr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmprView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEmprWageAshEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEmprCurr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuEmprDateType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyWScalCalendar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rank1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rank2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'chkProrata
        '
        Me.chkProrata.AutoHeight = False
        Me.chkProrata.Name = "chkProrata"
        Me.chkProrata.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkProrata.ValueChecked = 1
        Me.chkProrata.ValueGrayed = 0
        Me.chkProrata.ValueUnchecked = 0
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
        Me.header.Size = New System.Drawing.Size(1133, 682)
        Me.header.TabIndex = 4
        Me.header.Text = "Wage Scale"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdUpdatePayScale)
        Me.LayoutControl1.Controls.Add(Me.cmdCopyRank)
        Me.LayoutControl1.Controls.Add(Me.TabOnb)
        Me.LayoutControl1.Controls.Add(Me.GrdRank)
        Me.LayoutControl1.Controls.Add(Me.txtName)
        Me.LayoutControl1.Controls.Add(Me.txtAbbrv)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyCurr)
        Me.LayoutControl1.Controls.Add(Me.txtDateAct)
        Me.LayoutControl1.Controls.Add(Me.txtDateInact)
        Me.LayoutControl1.Controls.Add(Me.chkActive)
        Me.LayoutControl1.Controls.Add(Me.cboRateType)
        Me.LayoutControl1.Controls.Add(Me.TabAsh)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyWScalCalendar)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(366, 304, 686, 423)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1129, 654)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdUpdatePayScale
        '
        Me.cmdUpdatePayScale.Location = New System.Drawing.Point(1027, 15)
        Me.cmdUpdatePayScale.Name = "cmdUpdatePayScale"
        Me.cmdUpdatePayScale.Size = New System.Drawing.Size(87, 102)
        Me.cmdUpdatePayScale.StyleController = Me.LayoutControl1
        Me.cmdUpdatePayScale.TabIndex = 15
        Me.cmdUpdatePayScale.Text = "Update " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Wage Scale"
        '
        'cmdCopyRank
        '
        Me.cmdCopyRank.Location = New System.Drawing.Point(24, 158)
        Me.cmdCopyRank.Name = "cmdCopyRank"
        Me.cmdCopyRank.Size = New System.Drawing.Size(305, 23)
        Me.cmdCopyRank.StyleController = Me.LayoutControl1
        Me.cmdCopyRank.TabIndex = 14
        Me.cmdCopyRank.Text = "Copy Wage Scale Rank"
        '
        'TabOnb
        '
        Me.TabOnb.Location = New System.Drawing.Point(362, 158)
        Me.TabOnb.Name = "TabOnb"
        Me.TabOnb.SelectedTabPage = Me.TPageEarn
        Me.TabOnb.Size = New System.Drawing.Size(743, 206)
        Me.TabOnb.TabIndex = 13
        Me.TabOnb.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TPageEarn, Me.TPageDed, Me.XtraTabPage5})
        '
        'TPageEarn
        '
        Me.TPageEarn.Controls.Add(Me.GrdEarn)
        Me.TPageEarn.Name = "TPageEarn"
        Me.TPageEarn.Size = New System.Drawing.Size(737, 175)
        Me.TPageEarn.Text = "Onboard Earnings"
        '
        'GrdEarn
        '
        Me.GrdEarn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdEarn.Location = New System.Drawing.Point(0, 0)
        Me.GrdEarn.MainView = Me.EarnView
        Me.GrdEarn.Name = "GrdEarn"
        Me.GrdEarn.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkuFKeyWageOnb, Me.lkuEarFKeyCurr, Me.lkuEarDateType, Me.RepositoryItemTextEdit1, Me.chkProrata, Me.chkAccum})
        Me.GrdEarn.Size = New System.Drawing.Size(737, 175)
        Me.GrdEarn.TabIndex = 11
        Me.GrdEarn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.EarnView})
        '
        'EarnView
        '
        Me.EarnView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.EarnView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EarnView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.EarnView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EarnView.Appearance.Row.Options.UseTextOptions = True
        Me.EarnView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EarnView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.EarnView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.EarnView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.EarnView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EarnView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.EarnView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.EarnView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.EarPKey, Me.EarFKeyRank, Me.earFKeyWageOnb, Me.earWageType, Me.earFKeyCurr, Me.earAmt, Me.earDateType, Me.earProrata, Me.earAccum, Me.earFormula, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11})
        Me.EarnView.GridControl = Me.GrdEarn
        Me.EarnView.Name = "EarnView"
        Me.EarnView.NewItemRowText = "Click here to add new Record"
        Me.EarnView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.EarnView.OptionsBehavior.AutoPopulateColumns = False
        Me.EarnView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.EarnView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.EarnView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.EarnView.OptionsCustomization.AllowFilter = False
        Me.EarnView.OptionsCustomization.AllowGroup = False
        Me.EarnView.OptionsCustomization.AllowQuickHideColumns = False
        Me.EarnView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.EarnView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.EarnView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.EarnView.OptionsFind.AllowFindPanel = False
        Me.EarnView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.EarnView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.EarnView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.EarnView.OptionsSelection.UseIndicatorForSelection = False
        Me.EarnView.OptionsView.ShowGroupPanel = False
        '
        'EarPKey
        '
        Me.EarPKey.Caption = "PKey"
        Me.EarPKey.FieldName = "PKey"
        Me.EarPKey.Name = "EarPKey"
        Me.EarPKey.OptionsColumn.AllowEdit = False
        '
        'EarFKeyRank
        '
        Me.EarFKeyRank.Caption = "FKeyWScaleRank"
        Me.EarFKeyRank.FieldName = "FKeyWScaleRank"
        Me.EarFKeyRank.Name = "EarFKeyRank"
        Me.EarFKeyRank.OptionsColumn.AllowEdit = False
        Me.EarFKeyRank.Width = 209
        '
        'earFKeyWageOnb
        '
        Me.earFKeyWageOnb.Caption = "Item"
        Me.earFKeyWageOnb.ColumnEdit = Me.lkuFKeyWageOnb
        Me.earFKeyWageOnb.FieldName = "FKeyWageOnb"
        Me.earFKeyWageOnb.Name = "earFKeyWageOnb"
        Me.earFKeyWageOnb.Visible = True
        Me.earFKeyWageOnb.VisibleIndex = 0
        Me.earFKeyWageOnb.Width = 209
        '
        'lkuFKeyWageOnb
        '
        Me.lkuFKeyWageOnb.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.lkuFKeyWageOnb.AutoHeight = False
        Me.lkuFKeyWageOnb.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuFKeyWageOnb.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Prorata", "Name24", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Accum", "Name25", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuFKeyWageOnb.DisplayMember = "Name"
        Me.lkuFKeyWageOnb.MaxLength = 15
        Me.lkuFKeyWageOnb.Name = "lkuFKeyWageOnb"
        Me.lkuFKeyWageOnb.NullText = ""
        Me.lkuFKeyWageOnb.ShowFooter = False
        Me.lkuFKeyWageOnb.ShowHeader = False
        Me.lkuFKeyWageOnb.ValueMember = "PKey"
        '
        'earWageType
        '
        Me.earWageType.Caption = "WageType"
        Me.earWageType.FieldName = "WageType"
        Me.earWageType.Name = "earWageType"
        Me.earWageType.OptionsColumn.AllowEdit = False
        '
        'earFKeyCurr
        '
        Me.earFKeyCurr.Caption = "Currency"
        Me.earFKeyCurr.ColumnEdit = Me.lkuEarFKeyCurr
        Me.earFKeyCurr.FieldName = "FKeyCurr"
        Me.earFKeyCurr.Name = "earFKeyCurr"
        Me.earFKeyCurr.Visible = True
        Me.earFKeyCurr.VisibleIndex = 2
        '
        'lkuEarFKeyCurr
        '
        Me.lkuEarFKeyCurr.AutoHeight = False
        Me.lkuEarFKeyCurr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEarFKeyCurr.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lkuEarFKeyCurr.DisplayMember = "Symbol"
        Me.lkuEarFKeyCurr.Name = "lkuEarFKeyCurr"
        Me.lkuEarFKeyCurr.NullText = " "
        Me.lkuEarFKeyCurr.ShowFooter = False
        Me.lkuEarFKeyCurr.ShowHeader = False
        Me.lkuEarFKeyCurr.ValueMember = "PKey"
        '
        'earAmt
        '
        Me.earAmt.AppearanceCell.Options.UseTextOptions = True
        Me.earAmt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.earAmt.Caption = "Amount"
        Me.earAmt.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.earAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.earAmt.FieldName = "Amt"
        Me.earAmt.Name = "earAmt"
        Me.earAmt.Visible = True
        Me.earAmt.VisibleIndex = 1
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemTextEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'earDateType
        '
        Me.earDateType.Caption = "Start / End Date"
        Me.earDateType.ColumnEdit = Me.lkuEarDateType
        Me.earDateType.FieldName = "DateType"
        Me.earDateType.Name = "earDateType"
        Me.earDateType.Visible = True
        Me.earDateType.VisibleIndex = 3
        '
        'lkuEarDateType
        '
        Me.lkuEarDateType.AutoHeight = False
        Me.lkuEarDateType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEarDateType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Key"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 20, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuEarDateType.DisplayMember = "Key"
        Me.lkuEarDateType.Name = "lkuEarDateType"
        Me.lkuEarDateType.NullText = ""
        Me.lkuEarDateType.ShowFooter = False
        Me.lkuEarDateType.ShowHeader = False
        Me.lkuEarDateType.ValueMember = "Value"
        '
        'earProrata
        '
        Me.earProrata.Caption = "Prorata"
        Me.earProrata.ColumnEdit = Me.chkProrata
        Me.earProrata.FieldName = "Prorata"
        Me.earProrata.Name = "earProrata"
        Me.earProrata.Visible = True
        Me.earProrata.VisibleIndex = 4
        '
        'earAccum
        '
        Me.earAccum.Caption = "Accum"
        Me.earAccum.ColumnEdit = Me.chkAccum
        Me.earAccum.FieldName = "Accum"
        Me.earAccum.Name = "earAccum"
        Me.earAccum.Visible = True
        Me.earAccum.VisibleIndex = 5
        '
        'chkAccum
        '
        Me.chkAccum.AutoHeight = False
        Me.chkAccum.Name = "chkAccum"
        Me.chkAccum.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkAccum.ValueChecked = 1
        Me.chkAccum.ValueGrayed = 0
        Me.chkAccum.ValueUnchecked = 0
        '
        'earFormula
        '
        Me.earFormula.Caption = "Formula"
        Me.earFormula.FieldName = "Formula"
        Me.earFormula.Name = "earFormula"
        Me.earFormula.OptionsColumn.AllowEdit = False
        Me.earFormula.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Date Updated"
        Me.GridColumn9.FieldName = "DateUpdated"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        '
        'GridColumn10
        '
        Me.GridColumn10.FieldName = "LastUpdatedBy"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        '
        'GridColumn11
        '
        Me.GridColumn11.FieldName = "Edited"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        '
        'TPageDed
        '
        Me.TPageDed.Controls.Add(Me.GrdDed)
        Me.TPageDed.Name = "TPageDed"
        Me.TPageDed.Size = New System.Drawing.Size(737, 175)
        Me.TPageDed.Text = "Onboard Deductions"
        '
        'GrdDed
        '
        Me.GrdDed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdDed.Location = New System.Drawing.Point(0, 0)
        Me.GrdDed.MainView = Me.DedView
        Me.GrdDed.Name = "GrdDed"
        Me.GrdDed.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkuFKeyWageDed, Me.lkuDedFKeyCurr, Me.lkuDedDateType, Me.chkProrataDed, Me.chkAccumDed})
        Me.GrdDed.Size = New System.Drawing.Size(737, 175)
        Me.GrdDed.TabIndex = 12
        Me.GrdDed.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DedView})
        '
        'DedView
        '
        Me.DedView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.DedView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.DedView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.DedView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.DedView.Appearance.Row.Options.UseTextOptions = True
        Me.DedView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.DedView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DedView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.DedView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.DedView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.DedView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DedView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.DedView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn7, Me.GridColumn5, Me.GridColumn6, Me.GridColumn39, Me.GridColumn47, Me.GridColumn8, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25})
        Me.DedView.GridControl = Me.GrdDed
        Me.DedView.Name = "DedView"
        Me.DedView.NewItemRowText = "Click here to add new Record"
        Me.DedView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.DedView.OptionsBehavior.AutoPopulateColumns = False
        Me.DedView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.DedView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.DedView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.DedView.OptionsCustomization.AllowFilter = False
        Me.DedView.OptionsCustomization.AllowGroup = False
        Me.DedView.OptionsCustomization.AllowQuickHideColumns = False
        Me.DedView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.DedView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.DedView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.DedView.OptionsFind.AllowFindPanel = False
        Me.DedView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DedView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.DedView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.DedView.OptionsSelection.UseIndicatorForSelection = False
        Me.DedView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PKey"
        Me.GridColumn1.FieldName = "PKey"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "FKeyWScaleRank"
        Me.GridColumn2.FieldName = "FKeyWScaleRank"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Width = 209
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Item"
        Me.GridColumn3.ColumnEdit = Me.lkuFKeyWageDed
        Me.GridColumn3.FieldName = "FKeyWageOnb"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 209
        '
        'lkuFKeyWageDed
        '
        Me.lkuFKeyWageDed.AutoHeight = False
        Me.lkuFKeyWageDed.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuFKeyWageDed.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuFKeyWageDed.DisplayMember = "Name"
        Me.lkuFKeyWageDed.MaxLength = 15
        Me.lkuFKeyWageDed.Name = "lkuFKeyWageDed"
        Me.lkuFKeyWageDed.NullText = ""
        Me.lkuFKeyWageDed.ShowFooter = False
        Me.lkuFKeyWageDed.ShowHeader = False
        Me.lkuFKeyWageDed.ValueMember = "PKey"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "WageType"
        Me.GridColumn4.FieldName = "WageType"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Currency"
        Me.GridColumn7.ColumnEdit = Me.lkuDedFKeyCurr
        Me.GridColumn7.FieldName = "FKeyCurr"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'lkuDedFKeyCurr
        '
        Me.lkuDedFKeyCurr.AutoHeight = False
        Me.lkuDedFKeyCurr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuDedFKeyCurr.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lkuDedFKeyCurr.DisplayMember = "Symbol"
        Me.lkuDedFKeyCurr.Name = "lkuDedFKeyCurr"
        Me.lkuDedFKeyCurr.NullText = ""
        Me.lkuDedFKeyCurr.ShowFooter = False
        Me.lkuDedFKeyCurr.ShowHeader = False
        Me.lkuDedFKeyCurr.ValueMember = "PKey"
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Amount"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "Amt"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Start / End Date"
        Me.GridColumn6.ColumnEdit = Me.lkuDedDateType
        Me.GridColumn6.FieldName = "DateType"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        '
        'lkuDedDateType
        '
        Me.lkuDedDateType.AutoHeight = False
        Me.lkuDedDateType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuDedDateType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Key"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Vlaue", "Value", 20, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuDedDateType.DisplayMember = "Key"
        Me.lkuDedDateType.Name = "lkuDedDateType"
        Me.lkuDedDateType.NullText = ""
        Me.lkuDedDateType.ShowFooter = False
        Me.lkuDedDateType.ShowHeader = False
        Me.lkuDedDateType.ValueMember = "Value"
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Prorata"
        Me.GridColumn39.ColumnEdit = Me.chkProrataDed
        Me.GridColumn39.FieldName = "Prorata"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 4
        '
        'chkProrataDed
        '
        Me.chkProrataDed.AutoHeight = False
        Me.chkProrataDed.Name = "chkProrataDed"
        Me.chkProrataDed.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkProrataDed.ValueChecked = 1
        Me.chkProrataDed.ValueGrayed = 0
        Me.chkProrataDed.ValueUnchecked = 0
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "Accum"
        Me.GridColumn47.ColumnEdit = Me.chkAccumDed
        Me.GridColumn47.FieldName = "Accum"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 5
        '
        'chkAccumDed
        '
        Me.chkAccumDed.AutoHeight = False
        Me.chkAccumDed.Name = "chkAccumDed"
        Me.chkAccumDed.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.chkAccumDed.ValueChecked = 1
        Me.chkAccumDed.ValueGrayed = 0
        Me.chkAccumDed.ValueUnchecked = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Formula"
        Me.GridColumn8.FieldName = "Formula"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Date Updated"
        Me.GridColumn23.FieldName = "DateUpdated"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        '
        'GridColumn24
        '
        Me.GridColumn24.FieldName = "LastUpdatedBy"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        '
        'GridColumn25
        '
        Me.GridColumn25.FieldName = "Edited"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Controls.Add(Me.GrdInfo)
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.Size = New System.Drawing.Size(737, 175)
        Me.XtraTabPage5.Text = "Wage Information"
        '
        'GrdInfo
        '
        Me.GrdInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdInfo.Location = New System.Drawing.Point(0, 0)
        Me.GrdInfo.MainView = Me.InfoView
        Me.GrdInfo.Name = "GrdInfo"
        Me.GrdInfo.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkuFKeyWageInfo, Me.lkuInfoDen, Me.lkuInfoPrd, Me.lkuInfoDateType, Me.RepositoryItemTextEdit2})
        Me.GrdInfo.Size = New System.Drawing.Size(737, 175)
        Me.GrdInfo.TabIndex = 13
        Me.GrdInfo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.InfoView})
        '
        'InfoView
        '
        Me.InfoView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.InfoView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.InfoView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.InfoView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.InfoView.Appearance.Row.Options.UseTextOptions = True
        Me.InfoView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.InfoView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.InfoView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.InfoView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.InfoView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.InfoView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.InfoView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.InfoView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn30, Me.GridColumn32, Me.GridColumn33, Me.GridColumn31, Me.GridColumn34, Me.GridColumn35, Me.GridColumn36})
        Me.InfoView.GridControl = Me.GrdInfo
        Me.InfoView.Name = "InfoView"
        Me.InfoView.NewItemRowText = "Click here to add new Record"
        Me.InfoView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.InfoView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.InfoView.OptionsBehavior.AutoPopulateColumns = False
        Me.InfoView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.InfoView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.InfoView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.InfoView.OptionsCustomization.AllowFilter = False
        Me.InfoView.OptionsCustomization.AllowGroup = False
        Me.InfoView.OptionsCustomization.AllowQuickHideColumns = False
        Me.InfoView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.InfoView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.InfoView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.InfoView.OptionsFind.AllowFindPanel = False
        Me.InfoView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.InfoView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.InfoView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.InfoView.OptionsSelection.UseIndicatorForSelection = False
        Me.InfoView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn26.Caption = "PKey"
        Me.GridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn26.FieldName = "PKey"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.AllowEdit = False
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "FKeyWScaleRank"
        Me.GridColumn27.FieldName = "FKeyWScaleRank"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.Width = 209
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Item"
        Me.GridColumn28.ColumnEdit = Me.lkuFKeyWageInfo
        Me.GridColumn28.FieldName = "FKeyWageInfo"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 0
        Me.GridColumn28.Width = 209
        '
        'lkuFKeyWageInfo
        '
        Me.lkuFKeyWageInfo.AutoHeight = False
        Me.lkuFKeyWageInfo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuFKeyWageInfo.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lkuFKeyWageInfo.DisplayMember = "Name"
        Me.lkuFKeyWageInfo.MaxLength = 15
        Me.lkuFKeyWageInfo.Name = "lkuFKeyWageInfo"
        Me.lkuFKeyWageInfo.NullText = ""
        Me.lkuFKeyWageInfo.ShowFooter = False
        Me.lkuFKeyWageInfo.ShowHeader = False
        Me.lkuFKeyWageInfo.ValueMember = "PKey"
        '
        'GridColumn30
        '
        Me.GridColumn30.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn30.Caption = "Value"
        Me.GridColumn30.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "Int"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 1
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemTextEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Denomination"
        Me.GridColumn32.ColumnEdit = Me.lkuInfoDen
        Me.GridColumn32.FieldName = "Den"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 2
        '
        'lkuInfoDen
        '
        Me.lkuInfoDen.AutoHeight = False
        Me.lkuInfoDen.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuInfoDen.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuInfoDen.DisplayMember = "Name"
        Me.lkuInfoDen.Name = "lkuInfoDen"
        Me.lkuInfoDen.NullText = ""
        Me.lkuInfoDen.ShowFooter = False
        Me.lkuInfoDen.ShowHeader = False
        Me.lkuInfoDen.ValueMember = "PKey"
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Period"
        Me.GridColumn33.ColumnEdit = Me.lkuInfoPrd
        Me.GridColumn33.FieldName = "Prd"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 4
        '
        'lkuInfoPrd
        '
        Me.lkuInfoPrd.AutoHeight = False
        Me.lkuInfoPrd.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuInfoPrd.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lkuInfoPrd.DisplayMember = "Name"
        Me.lkuInfoPrd.Name = "lkuInfoPrd"
        Me.lkuInfoPrd.NullText = ""
        Me.lkuInfoPrd.ShowFooter = False
        Me.lkuInfoPrd.ShowHeader = False
        Me.lkuInfoPrd.ValueMember = "PKey"
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Start / End Date"
        Me.GridColumn31.ColumnEdit = Me.lkuInfoDateType
        Me.GridColumn31.FieldName = "DateType"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 3
        '
        'lkuInfoDateType
        '
        Me.lkuInfoDateType.AutoHeight = False
        Me.lkuInfoDateType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuInfoDateType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 20, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Key")})
        Me.lkuInfoDateType.DisplayMember = "Key"
        Me.lkuInfoDateType.Name = "lkuInfoDateType"
        Me.lkuInfoDateType.NullText = ""
        Me.lkuInfoDateType.ShowFooter = False
        Me.lkuInfoDateType.ShowHeader = False
        Me.lkuInfoDateType.ValueMember = "Value"
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Date Updated"
        Me.GridColumn34.FieldName = "DateUpdated"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        '
        'GridColumn35
        '
        Me.GridColumn35.FieldName = "LastUpdatedBy"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        '
        'GridColumn36
        '
        Me.GridColumn36.FieldName = "Edited"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        '
        'GrdRank
        '
        Me.GrdRank.Location = New System.Drawing.Point(24, 185)
        Me.GrdRank.MainView = Me.RankView
        Me.GrdRank.Name = "GrdRank"
        Me.GrdRank.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkuFKeyRank, Me.RepositoryItemCheckEdit1, Me.txtmax})
        Me.GrdRank.Size = New System.Drawing.Size(305, 445)
        Me.GrdRank.TabIndex = 11
        Me.GrdRank.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.RankView})
        '
        'RankView
        '
        Me.RankView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.RankView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.RankView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.RankView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.RankView.Appearance.Row.Options.UseTextOptions = True
        Me.RankView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.RankView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RankView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.RankView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.RankView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.RankView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RankView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.RankView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.colFKeyWScale, Me.colFKeyRank, Me.colLOC, Me.colLOCDays, Me.colLOCRem, Me.colYrsServ, Me.colDescription, Me.colDateUpdated, Me.colLastUpdatedBy, Me.colEdited})
        Me.RankView.GridControl = Me.GrdRank
        Me.RankView.Name = "RankView"
        Me.RankView.NewItemRowText = "Click here to add new Record"
        Me.RankView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.RankView.OptionsBehavior.AutoPopulateColumns = False
        Me.RankView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.RankView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.RankView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.RankView.OptionsCustomization.AllowFilter = False
        Me.RankView.OptionsCustomization.AllowGroup = False
        Me.RankView.OptionsCustomization.AllowQuickHideColumns = False
        Me.RankView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.RankView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.RankView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.RankView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.[False]
        Me.RankView.OptionsFind.AllowFindPanel = False
        Me.RankView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RankView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.RankView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.RankView.OptionsSelection.UseIndicatorForSelection = False
        Me.RankView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.RankView.OptionsView.ShowGroupPanel = False
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        Me.colPKey.OptionsColumn.AllowEdit = False
        '
        'colFKeyWScale
        '
        Me.colFKeyWScale.FieldName = "FKeyWScale"
        Me.colFKeyWScale.Name = "colFKeyWScale"
        Me.colFKeyWScale.OptionsColumn.AllowEdit = False
        Me.colFKeyWScale.Width = 209
        '
        'colFKeyRank
        '
        Me.colFKeyRank.Caption = "Rank"
        Me.colFKeyRank.ColumnEdit = Me.lkuFKeyRank
        Me.colFKeyRank.FieldName = "FKeyRank"
        Me.colFKeyRank.Name = "colFKeyRank"
        Me.colFKeyRank.OptionsEditForm.ColumnSpan = 3
        Me.colFKeyRank.OptionsEditForm.UseEditorColRowSpan = False
        Me.colFKeyRank.Visible = True
        Me.colFKeyRank.VisibleIndex = 0
        Me.colFKeyRank.Width = 105
        '
        'lkuFKeyRank
        '
        Me.lkuFKeyRank.AutoHeight = False
        Me.lkuFKeyRank.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuFKeyRank.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", 60, "Abbrv"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 100, "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuFKeyRank.DisplayMember = "Name"
        Me.lkuFKeyRank.MaxLength = 15
        Me.lkuFKeyRank.Name = "lkuFKeyRank"
        Me.lkuFKeyRank.NullText = ""
        Me.lkuFKeyRank.PopupWidth = 400
        Me.lkuFKeyRank.ShowFooter = False
        Me.lkuFKeyRank.ShowHeader = False
        Me.lkuFKeyRank.ValueMember = "PKey"
        '
        'colLOC
        '
        Me.colLOC.Caption = "LOC Months"
        Me.colLOC.FieldName = "LOC"
        Me.colLOC.Name = "colLOC"
        Me.colLOC.OptionsEditForm.StartNewRow = True
        Me.colLOC.Visible = True
        Me.colLOC.VisibleIndex = 1
        Me.colLOC.Width = 50
        '
        'colLOCDays
        '
        Me.colLOCDays.Caption = "LOC Days"
        Me.colLOCDays.FieldName = "LOCDays"
        Me.colLOCDays.Name = "colLOCDays"
        Me.colLOCDays.Visible = True
        Me.colLOCDays.VisibleIndex = 2
        Me.colLOCDays.Width = 35
        '
        'colLOCRem
        '
        Me.colLOCRem.Caption = "LOCRem"
        Me.colLOCRem.FieldName = "LOCRem"
        Me.colLOCRem.Name = "colLOCRem"
        Me.colLOCRem.OptionsColumn.AllowEdit = False
        '
        'colYrsServ
        '
        Me.colYrsServ.Caption = "Seniority"
        Me.colYrsServ.FieldName = "YrsServ"
        Me.colYrsServ.Name = "colYrsServ"
        Me.colYrsServ.Visible = True
        Me.colYrsServ.VisibleIndex = 3
        Me.colYrsServ.Width = 47
        '
        'colDescription
        '
        Me.colDescription.Caption = "Description"
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = False
        Me.colDescription.OptionsColumn.ShowInCustomizationForm = False
        '
        'colDateUpdated
        '
        Me.colDateUpdated.Caption = "Date Updated"
        Me.colDateUpdated.FieldName = "DateUpdated"
        Me.colDateUpdated.Name = "colDateUpdated"
        Me.colDateUpdated.OptionsColumn.AllowEdit = False
        '
        'colLastUpdatedBy
        '
        Me.colLastUpdatedBy.FieldName = "LastUpdatedBy"
        Me.colLastUpdatedBy.Name = "colLastUpdatedBy"
        Me.colLastUpdatedBy.OptionsColumn.AllowEdit = False
        '
        'colEdited
        '
        Me.colEdited.FieldName = "Edited"
        Me.colEdited.Name = "colEdited"
        Me.colEdited.OptionsColumn.AllowEdit = False
        '
        'txtmax
        '
        Me.txtmax.AutoHeight = False
        Me.txtmax.Name = "txtmax"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(10, 29)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 30
        Me.txtName.Size = New System.Drawing.Size(494, 22)
        Me.txtName.StyleController = Me.LayoutControl1
        Me.txtName.TabIndex = 0
        '
        'txtAbbrv
        '
        Me.txtAbbrv.Location = New System.Drawing.Point(504, 29)
        Me.txtAbbrv.Name = "txtAbbrv"
        Me.txtAbbrv.Properties.MaxLength = 15
        Me.txtAbbrv.Size = New System.Drawing.Size(518, 22)
        Me.txtAbbrv.StyleController = Me.LayoutControl1
        Me.txtAbbrv.TabIndex = 1
        '
        'cboFKeyCurr
        '
        Me.cboFKeyCurr.Location = New System.Drawing.Point(10, 85)
        Me.cboFKeyCurr.Name = "cboFKeyCurr"
        Me.cboFKeyCurr.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboFKeyCurr.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFKeyCurr.Properties.DisplayMember = "Symbol"
        Me.cboFKeyCurr.Properties.DropDownRows = 10
        Me.cboFKeyCurr.Properties.NullText = ""
        Me.cboFKeyCurr.Properties.ShowFooter = False
        Me.cboFKeyCurr.Properties.ShowHeader = False
        Me.cboFKeyCurr.Properties.ValueMember = "PKey"
        Me.cboFKeyCurr.Size = New System.Drawing.Size(162, 22)
        Me.cboFKeyCurr.StyleController = Me.LayoutControl1
        Me.cboFKeyCurr.TabIndex = 2
        '
        'txtDateAct
        '
        Me.txtDateAct.EditValue = Nothing
        Me.txtDateAct.Location = New System.Drawing.Point(799, 85)
        Me.txtDateAct.Name = "txtDateAct"
        Me.txtDateAct.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtDateAct.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateAct.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.txtDateAct.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDateAct.Size = New System.Drawing.Size(223, 22)
        Me.txtDateAct.StyleController = Me.LayoutControl1
        Me.txtDateAct.TabIndex = 4
        '
        'txtDateInact
        '
        Me.txtDateInact.EditValue = Nothing
        Me.txtDateInact.Location = New System.Drawing.Point(598, 85)
        Me.txtDateInact.Name = "txtDateInact"
        Me.txtDateInact.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtDateInact.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDateInact.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.txtDateInact.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDateInact.Size = New System.Drawing.Size(201, 22)
        Me.txtDateInact.StyleController = Me.LayoutControl1
        Me.txtDateInact.TabIndex = 5
        '
        'chkActive
        '
        Me.chkActive.EditValue = Nothing
        Me.chkActive.Location = New System.Drawing.Point(504, 85)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.chkActive.Properties.Caption = "Active"
        Me.chkActive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.chkActive.Size = New System.Drawing.Size(94, 19)
        Me.chkActive.StyleController = Me.LayoutControl1
        Me.chkActive.TabIndex = 6
        '
        'cboRateType
        '
        Me.cboRateType.Location = New System.Drawing.Point(330, 85)
        Me.cboRateType.Name = "cboRateType"
        Me.cboRateType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboRateType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 20, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Key")})
        Me.cboRateType.Properties.DisplayMember = "Key"
        Me.cboRateType.Properties.DropDownRows = 2
        Me.cboRateType.Properties.NullText = ""
        Me.cboRateType.Properties.ShowFooter = False
        Me.cboRateType.Properties.ShowHeader = False
        Me.cboRateType.Properties.ValueMember = "Value"
        Me.cboRateType.Size = New System.Drawing.Size(174, 22)
        Me.cboRateType.StyleController = Me.LayoutControl1
        Me.cboRateType.TabIndex = 3
        '
        'TabAsh
        '
        Me.TabAsh.Location = New System.Drawing.Point(362, 419)
        Me.TabAsh.Name = "TabAsh"
        Me.TabAsh.SelectedTabPage = Me.XtraTabPage3
        Me.TabAsh.Size = New System.Drawing.Size(743, 211)
        Me.TabAsh.TabIndex = 13
        Me.TabAsh.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage3, Me.XtraTabPage4})
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.GrdEmpe)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(737, 180)
        Me.XtraTabPage3.Text = "Employee's Contribution"
        '
        'GrdEmpe
        '
        Me.GrdEmpe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdEmpe.Location = New System.Drawing.Point(0, 0)
        Me.GrdEmpe.MainView = Me.EmpeView
        Me.GrdEmpe.Name = "GrdEmpe"
        Me.GrdEmpe.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkuEmpeWageAsh, Me.lkuEmpeCurr, Me.lkuEmpeDateType, Me.RepositoryItemTextEdit3})
        Me.GrdEmpe.Size = New System.Drawing.Size(737, 180)
        Me.GrdEmpe.TabIndex = 12
        Me.GrdEmpe.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.EmpeView})
        '
        'EmpeView
        '
        Me.EmpeView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.EmpeView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmpeView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.EmpeView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmpeView.Appearance.Row.Options.UseTextOptions = True
        Me.EmpeView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmpeView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.EmpeView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.EmpeView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.EmpeView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmpeView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.EmpeView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.EmpeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn18, Me.GridColumn16, Me.GridColumn17, Me.GridColumn15, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22})
        Me.EmpeView.GridControl = Me.GrdEmpe
        Me.EmpeView.Name = "EmpeView"
        Me.EmpeView.NewItemRowText = "Click here to add new Record"
        Me.EmpeView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.EmpeView.OptionsBehavior.AutoPopulateColumns = False
        Me.EmpeView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.EmpeView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.EmpeView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.EmpeView.OptionsCustomization.AllowFilter = False
        Me.EmpeView.OptionsCustomization.AllowGroup = False
        Me.EmpeView.OptionsCustomization.AllowQuickHideColumns = False
        Me.EmpeView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.EmpeView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.EmpeView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.EmpeView.OptionsFind.AllowFindPanel = False
        Me.EmpeView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.EmpeView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.EmpeView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.EmpeView.OptionsSelection.UseIndicatorForSelection = False
        Me.EmpeView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "PKey"
        Me.GridColumn12.FieldName = "PKey"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "FKeyWScaleRank"
        Me.GridColumn13.FieldName = "FKeyWScaleRank"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Width = 209
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Item"
        Me.GridColumn14.ColumnEdit = Me.lkuEmpeWageAsh
        Me.GridColumn14.FieldName = "FKeyWageAsh"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 209
        '
        'lkuEmpeWageAsh
        '
        Me.lkuEmpeWageAsh.AutoHeight = False
        Me.lkuEmpeWageAsh.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEmpeWageAsh.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuEmpeWageAsh.DisplayMember = "Name"
        Me.lkuEmpeWageAsh.MaxLength = 15
        Me.lkuEmpeWageAsh.Name = "lkuEmpeWageAsh"
        Me.lkuEmpeWageAsh.NullText = ""
        Me.lkuEmpeWageAsh.ShowFooter = False
        Me.lkuEmpeWageAsh.ShowHeader = False
        Me.lkuEmpeWageAsh.ValueMember = "PKey"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Currency"
        Me.GridColumn18.ColumnEdit = Me.lkuEmpeCurr
        Me.GridColumn18.FieldName = "FKeyCurr"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 2
        '
        'lkuEmpeCurr
        '
        Me.lkuEmpeCurr.AutoHeight = False
        Me.lkuEmpeCurr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEmpeCurr.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lkuEmpeCurr.DisplayMember = "Symbol"
        Me.lkuEmpeCurr.Name = "lkuEmpeCurr"
        Me.lkuEmpeCurr.NullText = ""
        Me.lkuEmpeCurr.ShowFooter = False
        Me.lkuEmpeCurr.ShowHeader = False
        Me.lkuEmpeCurr.ValueMember = "PKey"
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.HighPriority = True
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn16.Caption = "Amount"
        Me.GridColumn16.ColumnEdit = Me.RepositoryItemTextEdit3
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "Amt"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 1
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemTextEdit3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Start / End Date"
        Me.GridColumn17.ColumnEdit = Me.lkuEmpeDateType
        Me.GridColumn17.FieldName = "DateType"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 3
        '
        'lkuEmpeDateType
        '
        Me.lkuEmpeDateType.AutoHeight = False
        Me.lkuEmpeDateType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEmpeDateType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Key"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 20, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuEmpeDateType.DisplayMember = "Key"
        Me.lkuEmpeDateType.Name = "lkuEmpeDateType"
        Me.lkuEmpeDateType.NullText = ""
        Me.lkuEmpeDateType.ShowFooter = False
        Me.lkuEmpeDateType.ShowHeader = False
        Me.lkuEmpeDateType.ValueMember = "Value"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "WageType"
        Me.GridColumn15.FieldName = "WageType"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Date Updated"
        Me.GridColumn20.FieldName = "DateUpdated"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn21
        '
        Me.GridColumn21.FieldName = "LastUpdatedBy"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn22
        '
        Me.GridColumn22.FieldName = "Edited"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.GrdEmpr)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(737, 180)
        Me.XtraTabPage4.Text = "Employer's Contribution"
        '
        'GrdEmpr
        '
        Me.GrdEmpr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdEmpr.Location = New System.Drawing.Point(0, 0)
        Me.GrdEmpr.MainView = Me.EmprView
        Me.GrdEmpr.Name = "GrdEmpr"
        Me.GrdEmpr.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkuEmprWageAshEmp, Me.lkuEmprCurr, Me.lkuEmprDateType, Me.RepositoryItemTextEdit4})
        Me.GrdEmpr.Size = New System.Drawing.Size(737, 180)
        Me.GrdEmpr.TabIndex = 13
        Me.GrdEmpr.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.EmprView})
        '
        'EmprView
        '
        Me.EmprView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.EmprView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmprView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.EmprView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmprView.Appearance.Row.Options.UseTextOptions = True
        Me.EmprView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmprView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.EmprView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.EmprView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.EmprView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.EmprView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.EmprView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.EmprView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29, Me.GridColumn37, Me.GridColumn38, Me.GridColumn42, Me.GridColumn40, Me.GridColumn41, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46})
        Me.EmprView.GridControl = Me.GrdEmpr
        Me.EmprView.Name = "EmprView"
        Me.EmprView.NewItemRowText = "Click here to add new Record"
        Me.EmprView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.EmprView.OptionsBehavior.AutoPopulateColumns = False
        Me.EmprView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.EmprView.OptionsBehavior.CopyToClipboardWithColumnHeaders = False
        Me.EmprView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace
        Me.EmprView.OptionsCustomization.AllowFilter = False
        Me.EmprView.OptionsCustomization.AllowGroup = False
        Me.EmprView.OptionsCustomization.AllowQuickHideColumns = False
        Me.EmprView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.EmprView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.EmprView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.EmprView.OptionsFind.AllowFindPanel = False
        Me.EmprView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.EmprView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.EmprView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.EmprView.OptionsSelection.UseIndicatorForSelection = False
        Me.EmprView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "PKey"
        Me.GridColumn29.FieldName = "PKey"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "FKeyWScaleRank"
        Me.GridColumn37.FieldName = "FKeyWScaleRank"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.Width = 209
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Item"
        Me.GridColumn38.ColumnEdit = Me.lkuEmprWageAshEmp
        Me.GridColumn38.FieldName = "FKeyWageAshEmp"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 0
        Me.GridColumn38.Width = 209
        '
        'lkuEmprWageAshEmp
        '
        Me.lkuEmprWageAshEmp.AutoHeight = False
        Me.lkuEmprWageAshEmp.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEmprWageAshEmp.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuEmprWageAshEmp.DisplayMember = "Name"
        Me.lkuEmprWageAshEmp.MaxLength = 15
        Me.lkuEmprWageAshEmp.Name = "lkuEmprWageAshEmp"
        Me.lkuEmprWageAshEmp.NullText = ""
        Me.lkuEmprWageAshEmp.ShowFooter = False
        Me.lkuEmprWageAshEmp.ShowHeader = False
        Me.lkuEmprWageAshEmp.ValueMember = "PKey"
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Currency"
        Me.GridColumn42.ColumnEdit = Me.lkuEmprCurr
        Me.GridColumn42.FieldName = "FKeyCurr"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 2
        '
        'lkuEmprCurr
        '
        Me.lkuEmprCurr.AutoHeight = False
        Me.lkuEmprCurr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEmprCurr.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lkuEmprCurr.DisplayMember = "Symbol"
        Me.lkuEmprCurr.Name = "lkuEmprCurr"
        Me.lkuEmprCurr.NullText = ""
        Me.lkuEmprCurr.ShowFooter = False
        Me.lkuEmprCurr.ShowHeader = False
        Me.lkuEmprCurr.ValueMember = "PKey"
        '
        'GridColumn40
        '
        Me.GridColumn40.AppearanceCell.Options.HighPriority = True
        Me.GridColumn40.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn40.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn40.Caption = "Amount"
        Me.GridColumn40.ColumnEdit = Me.RepositoryItemTextEdit4
        Me.GridColumn40.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn40.FieldName = "Amt"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 1
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemTextEdit4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Start / End Date"
        Me.GridColumn41.ColumnEdit = Me.lkuEmprDateType
        Me.GridColumn41.FieldName = "DateType"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 3
        '
        'lkuEmprDateType
        '
        Me.lkuEmprDateType.AutoHeight = False
        Me.lkuEmprDateType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lkuEmprDateType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Key"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 20, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuEmprDateType.DisplayMember = "Key"
        Me.lkuEmprDateType.Name = "lkuEmprDateType"
        Me.lkuEmprDateType.NullText = ""
        Me.lkuEmprDateType.ShowFooter = False
        Me.lkuEmprDateType.ShowHeader = False
        Me.lkuEmprDateType.ValueMember = "Value"
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Date Updated"
        Me.GridColumn44.FieldName = "DateUpdated"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        '
        'GridColumn45
        '
        Me.GridColumn45.FieldName = "LastUpdatedBy"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        '
        'GridColumn46
        '
        Me.GridColumn46.FieldName = "Edited"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.AllowEdit = False
        '
        'cboFKeyWScalCalendar
        '
        Me.cboFKeyWScalCalendar.Location = New System.Drawing.Point(172, 85)
        Me.cboFKeyWScalCalendar.Name = "cboFKeyWScalCalendar"
        Me.cboFKeyWScalCalendar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboFKeyWScalCalendar.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboFKeyWScalCalendar.Properties.DisplayMember = "Name"
        Me.cboFKeyWScalCalendar.Properties.DropDownRows = 10
        Me.cboFKeyWScalCalendar.Properties.NullText = ""
        Me.cboFKeyWScalCalendar.Properties.ShowFooter = False
        Me.cboFKeyWScalCalendar.Properties.ShowHeader = False
        Me.cboFKeyWScalCalendar.Properties.ValueMember = "PKey"
        Me.cboFKeyWScalCalendar.Size = New System.Drawing.Size(158, 22)
        Me.cboFKeyWScalCalendar.StyleController = Me.LayoutControl1
        Me.cboFKeyWScalCalendar.TabIndex = 2
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem5, Me.LayoutControlItem9, Me.Rank1, Me.Rank, Me.Rank2, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.SplitterItem1, Me.SplitterItem2, Me.LayoutControlItem12, Me.LayoutControlItem14, Me.LayoutControlItem4, Me.LayoutControlItem6})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1129, 654)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboFKeyCurr
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(162, 56)
        Me.LayoutControlItem2.Text = "* Currency"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(74, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtDateInact
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(588, 56)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(201, 56)
        Me.LayoutControlItem5.Text = "Date Inactive"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(74, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboRateType
        Me.LayoutControlItem9.Location = New System.Drawing.Point(320, 56)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(174, 56)
        Me.LayoutControlItem9.Text = "* Rate Type"
        Me.LayoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(74, 16)
        '
        'Rank1
        '
        Me.Rank1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11})
        Me.Rank1.Location = New System.Drawing.Point(338, 112)
        Me.Rank1.Name = "Rank1"
        Me.Rank1.Size = New System.Drawing.Size(771, 256)
        Me.Rank1.Text = "Onboard"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.TabOnb
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(747, 210)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'Rank
        '
        Me.Rank.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem13})
        Me.Rank.Location = New System.Drawing.Point(0, 112)
        Me.Rank.Name = "Rank"
        Me.Rank.Size = New System.Drawing.Size(333, 522)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.GrdRank
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(309, 449)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.cmdCopyRank
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(309, 27)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'Rank2
        '
        Me.Rank2.CustomizationFormText = "Rank"
        Me.Rank2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10})
        Me.Rank2.Location = New System.Drawing.Point(338, 373)
        Me.Rank2.Name = "Rank2"
        Me.Rank2.Size = New System.Drawing.Size(771, 261)
        Me.Rank2.Text = "Ashore"
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.TabAsh
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem11"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(747, 215)
        Me.LayoutControlItem10.Text = "LayoutControlItem11"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtName
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(494, 56)
        Me.LayoutControlItem3.Text = "* Name"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(74, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtAbbrv
        Me.LayoutControlItem1.CustomizationFormText = "Abbrv"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(494, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(518, 56)
        Me.LayoutControlItem1.Text = "Abbrv"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(74, 16)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(338, 368)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(771, 5)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(333, 112)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(5, 522)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cboFKeyWScalCalendar
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(162, 56)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem12.Size = New System.Drawing.Size(158, 56)
        Me.LayoutControlItem12.Text = "* Calendar"
        Me.LayoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(74, 16)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.cmdUpdatePayScale
        Me.LayoutControlItem14.CustomizationFormText = "Update PayScale Button"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(1012, 0)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(95, 32)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LayoutControlItem14.Size = New System.Drawing.Size(97, 112)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtDateAct
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(789, 56)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 15)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(223, 56)
        Me.LayoutControlItem4.Text = "Date Active"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(74, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControlItem6.Control = Me.chkActive
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(494, 56)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(94, 56)
        Me.LayoutControlItem6.Text = "Active"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(74, 16)
        '
        'PayScale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "PayScale"
        Me.Size = New System.Drawing.Size(1133, 682)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkProrata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TabOnb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabOnb.ResumeLayout(False)
        Me.TPageEarn.ResumeLayout(False)
        CType(Me.GrdEarn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EarnView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuFKeyWageOnb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEarFKeyCurr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEarDateType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAccum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPageDed.ResumeLayout(False)
        CType(Me.GrdDed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DedView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuFKeyWageDed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuDedFKeyCurr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuDedDateType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkProrataDed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAccumDed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage5.ResumeLayout(False)
        CType(Me.GrdInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuFKeyWageInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuInfoDen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuInfoPrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuInfoDateType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuFKeyRank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbbrv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyCurr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateAct.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateAct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateInact.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDateInact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRateType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabAsh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAsh.ResumeLayout(False)
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.GrdEmpe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmpeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEmpeWageAsh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEmpeCurr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEmpeDateType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage4.ResumeLayout(False)
        CType(Me.GrdEmpr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmprView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEmprWageAshEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEmprCurr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuEmprDateType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyWScalCalendar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rank1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rank2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAbbrv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboFKeyCurr As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtDateAct As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDateInact As DevExpress.XtraEditors.DateEdit
    Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GrdRank As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lkuFKeyRank As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Rank As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents RankView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyWScale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFKeyRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLOCDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLOCRem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colYrsServ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboRateType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TabOnb As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TPageEarn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GrdEarn As DevExpress.XtraGrid.GridControl
    Friend WithEvents EarnView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents EarPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EarFKeyRank As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents earFKeyWageOnb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuFKeyWageOnb As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents earWageType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents earAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents earDateType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents earFKeyCurr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents earFormula As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TPageDed As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Rank1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabAsh As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Rank2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lkuEarFKeyCurr As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GrdDed As DevExpress.XtraGrid.GridControl
    Friend WithEvents DedView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuFKeyWageDed As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuDedFKeyCurr As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GrdInfo As DevExpress.XtraGrid.GridControl
    Friend WithEvents InfoView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuFKeyWageInfo As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuInfoDen As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuInfoPrd As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents lkuInfoDateType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents lkuEarDateType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents lkuDedDateType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GrdEmpe As DevExpress.XtraGrid.GridControl
    Friend WithEvents EmpeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuEmpeWageAsh As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuEmpeDateType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuEmpeCurr As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GrdEmpr As DevExpress.XtraGrid.GridControl
    Friend WithEvents EmprView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuEmprWageAshEmp As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuEmprDateType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkuEmprCurr As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents chkProrata As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents txtmax As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents cboFKeyWScalCalendar As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents earProrata As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents earAccum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkAccum As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkProrataDed As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkAccumDed As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cmdCopyRank As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmdUpdatePayScale As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem

End Class
