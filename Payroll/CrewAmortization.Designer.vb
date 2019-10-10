<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrewAmortization
    Inherits BaseControl.BaseControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrewAmortization))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.gcCrewAmort = New DevExpress.XtraGrid.GridControl()
        Me.gvCrewAmort = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmItem = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WageAshEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmRefNum = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmStartPeriod = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.periodEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.clmPaid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repAmt = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.clmRemaining = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.txtMonDed = New DevExpress.XtraEditors.TextEdit()
        Me.txtRemain = New DevExpress.XtraEditors.TextEdit()
        Me.txtPaid = New DevExpress.XtraEditors.TextEdit()
        Me.txtLoanTotal = New DevExpress.XtraEditors.TextEdit()
        Me.gcAmortDistrib = New DevExpress.XtraGrid.GridControl()
        Me.gvAmortDistrib = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmPeriod = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmVessel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTotalAmt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.remAmtPd = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.clmPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.lueItem = New DevExpress.XtraEditors.LookUpEdit()
        Me.lueRemitAllot = New DevExpress.XtraEditors.LookUpEdit()
        Me.deStartPeriod = New DevExpress.XtraEditors.DateEdit()
        Me.deDateGranted = New DevExpress.XtraEditors.DateEdit()
        Me.deLoanDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtRefNo = New DevExpress.XtraEditors.TextEdit()
        Me.txtLoanAmt = New DevExpress.XtraEditors.TextEdit()
        Me.txtInterest = New DevExpress.XtraEditors.TextEdit()
        Me.txtOtherCharge = New DevExpress.XtraEditors.TextEdit()
        Me.txtRemarks = New DevExpress.XtraEditors.TextEdit()
        Me.lueCurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.clmLoanTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcCrewAmort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCrewAmort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WageAshEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.periodEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.periodEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAmt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonDed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemain.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLoanTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcAmortDistrib, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvAmortDistrib, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.remAmtPd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueRemitAllot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartPeriod.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateGranted.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateGranted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deLoanDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deLoanDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRefNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLoanAmt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInterest.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOtherCharge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
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
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.gcCrewAmort)
        Me.LayoutControl1.Controls.Add(Me.txtMonDed)
        Me.LayoutControl1.Controls.Add(Me.txtRemain)
        Me.LayoutControl1.Controls.Add(Me.txtPaid)
        Me.LayoutControl1.Controls.Add(Me.txtLoanTotal)
        Me.LayoutControl1.Controls.Add(Me.gcAmortDistrib)
        Me.LayoutControl1.Controls.Add(Me.lueItem)
        Me.LayoutControl1.Controls.Add(Me.lueRemitAllot)
        Me.LayoutControl1.Controls.Add(Me.deStartPeriod)
        Me.LayoutControl1.Controls.Add(Me.deDateGranted)
        Me.LayoutControl1.Controls.Add(Me.deLoanDate)
        Me.LayoutControl1.Controls.Add(Me.txtRefNo)
        Me.LayoutControl1.Controls.Add(Me.txtLoanAmt)
        Me.LayoutControl1.Controls.Add(Me.txtInterest)
        Me.LayoutControl1.Controls.Add(Me.txtOtherCharge)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.lueCurrency)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(384, 483, 880, 394)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1281, 645)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'gcCrewAmort
        '
        Me.gcCrewAmort.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcCrewAmort.Location = New System.Drawing.Point(12, 12)
        Me.gcCrewAmort.MainView = Me.gvCrewAmort
        Me.gcCrewAmort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcCrewAmort.Name = "gcCrewAmort"
        Me.gcCrewAmort.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.WageAshEdit, Me.periodEdit, Me.repAmt})
        Me.gcCrewAmort.Size = New System.Drawing.Size(1257, 201)
        Me.gcCrewAmort.TabIndex = 0
        Me.gcCrewAmort.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCrewAmort})
        '
        'gvCrewAmort
        '
        Me.gvCrewAmort.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.gvCrewAmort.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.PKey, Me.clmItem, Me.clmRefNum, Me.clmStartPeriod, Me.clmLoanTotal, Me.clmPaid, Me.clmRemaining})
        Me.gvCrewAmort.GridControl = Me.gcCrewAmort
        Me.gvCrewAmort.Name = "gvCrewAmort"
        Me.gvCrewAmort.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvCrewAmort.OptionsBehavior.Editable = False
        Me.gvCrewAmort.OptionsBehavior.ReadOnly = True
        Me.gvCrewAmort.OptionsCustomization.AllowBandMoving = False
        Me.gvCrewAmort.OptionsCustomization.AllowBandResizing = False
        Me.gvCrewAmort.OptionsCustomization.AllowGroup = False
        Me.gvCrewAmort.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvCrewAmort.OptionsCustomization.ShowBandsInCustomizationForm = False
        Me.gvCrewAmort.OptionsMenu.ShowAutoFilterRowItem = False
        Me.gvCrewAmort.OptionsMenu.ShowDateTimeGroupIntervalItems = False
        Me.gvCrewAmort.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.gvCrewAmort.OptionsMenu.ShowSplitItem = False
        Me.gvCrewAmort.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.gvCrewAmort.OptionsView.ShowGroupPanel = False
        '
        'GridBand2
        '
        Me.GridBand2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.GridBand2.AppearanceHeader.Options.UseFont = True
        Me.GridBand2.Caption = "Crew Amortization List"
        Me.GridBand2.Columns.Add(Me.clmItem)
        Me.GridBand2.Columns.Add(Me.clmRefNum)
        Me.GridBand2.Columns.Add(Me.clmStartPeriod)
        Me.GridBand2.Columns.Add(Me.clmLoanTotal)
        Me.GridBand2.Columns.Add(Me.clmPaid)
        Me.GridBand2.Columns.Add(Me.clmRemaining)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 925
        '
        'clmItem
        '
        Me.clmItem.Caption = "Item"
        Me.clmItem.ColumnEdit = Me.WageAshEdit
        Me.clmItem.FieldName = "FKeyWageAsh"
        Me.clmItem.Name = "clmItem"
        Me.clmItem.Visible = True
        Me.clmItem.Width = 154
        '
        'WageAshEdit
        '
        Me.WageAshEdit.AutoHeight = False
        Me.WageAshEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WageAshEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.WageAshEdit.DisplayMember = "Name"
        Me.WageAshEdit.Name = "WageAshEdit"
        Me.WageAshEdit.NullText = ""
        Me.WageAshEdit.ValueMember = "PKey"
        '
        'clmRefNum
        '
        Me.clmRefNum.Caption = "Ref. Number"
        Me.clmRefNum.FieldName = "RefNo"
        Me.clmRefNum.Name = "clmRefNum"
        Me.clmRefNum.Visible = True
        Me.clmRefNum.Width = 154
        '
        'clmStartPeriod
        '
        Me.clmStartPeriod.Caption = "Start Period"
        Me.clmStartPeriod.ColumnEdit = Me.periodEdit
        Me.clmStartPeriod.FieldName = "StartPeriod"
        Me.clmStartPeriod.Name = "clmStartPeriod"
        Me.clmStartPeriod.Visible = True
        Me.clmStartPeriod.Width = 154
        '
        'periodEdit
        '
        Me.periodEdit.AutoHeight = False
        Me.periodEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.periodEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.periodEdit.Mask.EditMask = "MMM yyyy"
        Me.periodEdit.Mask.UseMaskAsDisplayFormat = True
        Me.periodEdit.Name = "periodEdit"
        '
        'clmPaid
        '
        Me.clmPaid.Caption = "Paid"
        Me.clmPaid.ColumnEdit = Me.repAmt
        Me.clmPaid.FieldName = "AmtPd"
        Me.clmPaid.Name = "clmPaid"
        Me.clmPaid.Visible = True
        Me.clmPaid.Width = 147
        '
        'repAmt
        '
        Me.repAmt.AutoHeight = False
        Me.repAmt.Mask.EditMask = "n2"
        Me.repAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repAmt.Mask.UseMaskAsDisplayFormat = True
        Me.repAmt.Name = "repAmt"
        '
        'clmRemaining
        '
        Me.clmRemaining.Caption = "Remaining"
        Me.clmRemaining.ColumnEdit = Me.repAmt
        Me.clmRemaining.FieldName = "RemBal"
        Me.clmRemaining.Name = "clmRemaining"
        Me.clmRemaining.Visible = True
        Me.clmRemaining.Width = 148
        '
        'PKey
        '
        Me.PKey.FieldName = "PKey"
        Me.PKey.Name = "PKey"
        '
        'txtMonDed
        '
        Me.txtMonDed.Location = New System.Drawing.Point(435, 415)
        Me.txtMonDed.Name = "txtMonDed"
        Me.txtMonDed.Properties.Mask.EditMask = "n2"
        Me.txtMonDed.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMonDed.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtMonDed.Size = New System.Drawing.Size(101, 22)
        Me.txtMonDed.StyleController = Me.LayoutControl1
        Me.txtMonDed.TabIndex = 18
        '
        'txtRemain
        '
        Me.txtRemain.Location = New System.Drawing.Point(442, 511)
        Me.txtRemain.Name = "txtRemain"
        Me.txtRemain.Properties.Mask.EditMask = "n2"
        Me.txtRemain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRemain.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtRemain.Properties.NullText = "0.00"
        Me.txtRemain.Properties.ReadOnly = True
        Me.txtRemain.Size = New System.Drawing.Size(94, 22)
        Me.txtRemain.StyleController = Me.LayoutControl1
        Me.txtRemain.TabIndex = 17
        '
        'txtPaid
        '
        Me.txtPaid.Location = New System.Drawing.Point(248, 511)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.Properties.Mask.EditMask = "n2"
        Me.txtPaid.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPaid.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtPaid.Properties.NullText = "0.00"
        Me.txtPaid.Properties.ReadOnly = True
        Me.txtPaid.Size = New System.Drawing.Size(112, 22)
        Me.txtPaid.StyleController = Me.LayoutControl1
        Me.txtPaid.TabIndex = 16
        '
        'txtLoanTotal
        '
        Me.txtLoanTotal.Location = New System.Drawing.Point(106, 511)
        Me.txtLoanTotal.Name = "txtLoanTotal"
        Me.txtLoanTotal.Properties.Mask.EditMask = "n2"
        Me.txtLoanTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtLoanTotal.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtLoanTotal.Properties.NullText = "0.00"
        Me.txtLoanTotal.Properties.ReadOnly = True
        Me.txtLoanTotal.Size = New System.Drawing.Size(96, 22)
        Me.txtLoanTotal.StyleController = Me.LayoutControl1
        Me.txtLoanTotal.TabIndex = 15
        '
        'gcAmortDistrib
        '
        Me.gcAmortDistrib.Location = New System.Drawing.Point(564, 222)
        Me.gcAmortDistrib.MainView = Me.gvAmortDistrib
        Me.gcAmortDistrib.Name = "gcAmortDistrib"
        Me.gcAmortDistrib.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.remAmtPd})
        Me.gcAmortDistrib.Size = New System.Drawing.Size(705, 411)
        Me.gcAmortDistrib.TabIndex = 0
        Me.gcAmortDistrib.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvAmortDistrib})
        '
        'gvAmortDistrib
        '
        Me.gvAmortDistrib.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.gvAmortDistrib.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.clmPKey, Me.clmPeriod, Me.clmVessel, Me.clmTotalAmt})
        Me.gvAmortDistrib.GridControl = Me.gcAmortDistrib
        Me.gvAmortDistrib.Name = "gvAmortDistrib"
        Me.gvAmortDistrib.OptionsBehavior.ReadOnly = True
        Me.gvAmortDistrib.OptionsCustomization.AllowBandMoving = False
        Me.gvAmortDistrib.OptionsCustomization.AllowBandResizing = False
        Me.gvAmortDistrib.OptionsCustomization.AllowGroup = False
        Me.gvAmortDistrib.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvAmortDistrib.OptionsCustomization.ShowBandsInCustomizationForm = False
        Me.gvAmortDistrib.OptionsMenu.ShowAutoFilterRowItem = False
        Me.gvAmortDistrib.OptionsMenu.ShowDateTimeGroupIntervalItems = False
        Me.gvAmortDistrib.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.gvAmortDistrib.OptionsMenu.ShowSplitItem = False
        Me.gvAmortDistrib.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.gvAmortDistrib.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gvAmortDistrib.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Payment History"
        Me.GridBand1.Columns.Add(Me.clmPeriod)
        Me.GridBand1.Columns.Add(Me.clmVessel)
        Me.GridBand1.Columns.Add(Me.clmTotalAmt)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 225
        '
        'clmPeriod
        '
        Me.clmPeriod.Caption = "Period"
        Me.clmPeriod.FieldName = "Period"
        Me.clmPeriod.Name = "clmPeriod"
        Me.clmPeriod.Visible = True
        '
        'clmVessel
        '
        Me.clmVessel.Caption = "Vessel"
        Me.clmVessel.FieldName = "VslName"
        Me.clmVessel.Name = "clmVessel"
        Me.clmVessel.Visible = True
        '
        'clmTotalAmt
        '
        Me.clmTotalAmt.Caption = "Paid Amount"
        Me.clmTotalAmt.ColumnEdit = Me.remAmtPd
        Me.clmTotalAmt.FieldName = "AmtPd"
        Me.clmTotalAmt.Name = "clmTotalAmt"
        Me.clmTotalAmt.Visible = True
        '
        'remAmtPd
        '
        Me.remAmtPd.AutoHeight = False
        Me.remAmtPd.Mask.EditMask = "n2"
        Me.remAmtPd.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.remAmtPd.Mask.UseMaskAsDisplayFormat = True
        Me.remAmtPd.Name = "remAmtPd"
        '
        'clmPKey
        '
        Me.clmPKey.FieldName = "PKey"
        Me.clmPKey.Name = "clmPKey"
        '
        'lueItem
        '
        Me.lueItem.Location = New System.Drawing.Point(119, 256)
        Me.lueItem.Name = "lueItem"
        Me.lueItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueItem.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lueItem.Properties.DisplayMember = "Name"
        Me.lueItem.Properties.NullText = ""
        Me.lueItem.Properties.ShowFooter = False
        Me.lueItem.Properties.ShowHeader = False
        Me.lueItem.Properties.ValueMember = "PKey"
        Me.lueItem.Size = New System.Drawing.Size(161, 22)
        Me.lueItem.StyleController = Me.LayoutControl1
        Me.lueItem.TabIndex = 0
        '
        'lueRemitAllot
        '
        Me.lueRemitAllot.Location = New System.Drawing.Point(131, 440)
        Me.lueRemitAllot.Name = "lueRemitAllot"
        Me.lueRemitAllot.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueRemitAllot.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lueRemitAllot.Properties.DisplayMember = "Name"
        Me.lueRemitAllot.Properties.NullText = ""
        Me.lueRemitAllot.Properties.ShowFooter = False
        Me.lueRemitAllot.Properties.ShowHeader = False
        Me.lueRemitAllot.Properties.ValueMember = "PKey"
        Me.lueRemitAllot.Size = New System.Drawing.Size(405, 22)
        Me.lueRemitAllot.StyleController = Me.LayoutControl1
        Me.lueRemitAllot.TabIndex = 12
        '
        'deStartPeriod
        '
        Me.deStartPeriod.EditValue = Nothing
        Me.deStartPeriod.Location = New System.Drawing.Point(131, 415)
        Me.deStartPeriod.Name = "deStartPeriod"
        Me.deStartPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartPeriod.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartPeriod.Properties.Mask.EditMask = "MMM yyyy"
        Me.deStartPeriod.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deStartPeriod.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        Me.deStartPeriod.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        Me.deStartPeriod.Size = New System.Drawing.Size(150, 22)
        Me.deStartPeriod.StyleController = Me.LayoutControl1
        Me.deStartPeriod.TabIndex = 9
        '
        'deDateGranted
        '
        Me.deDateGranted.EditValue = Nothing
        Me.deDateGranted.Location = New System.Drawing.Point(119, 331)
        Me.deDateGranted.Name = "deDateGranted"
        Me.deDateGranted.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateGranted.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateGranted.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deDateGranted.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deDateGranted.Size = New System.Drawing.Size(161, 22)
        Me.deDateGranted.StyleController = Me.LayoutControl1
        Me.deDateGranted.TabIndex = 7
        '
        'deLoanDate
        '
        Me.deLoanDate.EditValue = Nothing
        Me.deLoanDate.Location = New System.Drawing.Point(119, 306)
        Me.deLoanDate.Name = "deLoanDate"
        Me.deLoanDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deLoanDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deLoanDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deLoanDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deLoanDate.Size = New System.Drawing.Size(161, 22)
        Me.deLoanDate.StyleController = Me.LayoutControl1
        Me.deLoanDate.TabIndex = 5
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(119, 281)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(161, 22)
        Me.txtRefNo.StyleController = Me.LayoutControl1
        Me.txtRefNo.TabIndex = 3
        '
        'txtLoanAmt
        '
        Me.txtLoanAmt.Location = New System.Drawing.Point(387, 281)
        Me.txtLoanAmt.Name = "txtLoanAmt"
        Me.txtLoanAmt.Properties.Mask.EditMask = "n2"
        Me.txtLoanAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtLoanAmt.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtLoanAmt.Size = New System.Drawing.Size(161, 22)
        Me.txtLoanAmt.StyleController = Me.LayoutControl1
        Me.txtLoanAmt.TabIndex = 2
        '
        'txtInterest
        '
        Me.txtInterest.Location = New System.Drawing.Point(387, 306)
        Me.txtInterest.Name = "txtInterest"
        Me.txtInterest.Properties.Mask.EditMask = "n2"
        Me.txtInterest.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtInterest.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtInterest.Size = New System.Drawing.Size(161, 22)
        Me.txtInterest.StyleController = Me.LayoutControl1
        Me.txtInterest.TabIndex = 4
        '
        'txtOtherCharge
        '
        Me.txtOtherCharge.Location = New System.Drawing.Point(387, 331)
        Me.txtOtherCharge.Name = "txtOtherCharge"
        Me.txtOtherCharge.Properties.Mask.EditMask = "n2"
        Me.txtOtherCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtOtherCharge.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtOtherCharge.Size = New System.Drawing.Size(161, 22)
        Me.txtOtherCharge.StyleController = Me.LayoutControl1
        Me.txtOtherCharge.TabIndex = 6
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(119, 356)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(429, 22)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 8
        '
        'lueCurrency
        '
        Me.lueCurrency.Location = New System.Drawing.Point(387, 256)
        Me.lueCurrency.Name = "lueCurrency"
        Me.lueCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueCurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lueCurrency.Properties.DisplayMember = "Symbol"
        Me.lueCurrency.Properties.NullText = ""
        Me.lueCurrency.Properties.ShowFooter = False
        Me.lueCurrency.Properties.ShowHeader = False
        Me.lueCurrency.Properties.ValueMember = "PKey"
        Me.lueCurrency.Size = New System.Drawing.Size(161, 22)
        Me.lueCurrency.StyleController = Me.LayoutControl1
        Me.lueCurrency.TabIndex = 10
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup3, Me.LayoutControlItem13, Me.SplitterItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1281, 645)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.gcAmortDistrib
        Me.LayoutControlItem1.Location = New System.Drawing.Point(552, 210)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(709, 415)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.LayoutControlGroup2, Me.LayoutControlGroup4, Me.LayoutControlItem15, Me.LayoutControlItem11, Me.LayoutControlItem7, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 210)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(552, 415)
        Me.LayoutControlGroup3.Text = "Loan Details"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.lueItem
        Me.LayoutControlItem2.CustomizationFormText = "Item:"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "* Item:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtLoanAmt
        Me.LayoutControlItem8.CustomizationFormText = "Loan Amt.:"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(268, 25)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "* Loan Amt.:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtInterest
        Me.LayoutControlItem9.CustomizationFormText = "Interest:"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(268, 50)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.Text = "Interest:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtOtherCharge
        Me.LayoutControlItem10.CustomizationFormText = "Other Charge:"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(268, 75)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.Text = "Other Charge:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(92, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 293)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(528, 76)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem16, Me.LayoutControlItem17, Me.LayoutControlItem18})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 221)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(528, 72)
        Me.LayoutControlGroup2.Text = "Loan Summary"
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.txtLoanTotal
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(170, 26)
        Me.LayoutControlItem16.Text = "Loan Total:"
        Me.LayoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(65, 16)
        Me.LayoutControlItem16.TextToControlDistance = 5
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.txtPaid
        Me.LayoutControlItem17.Location = New System.Drawing.Point(170, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem17.Size = New System.Drawing.Size(158, 26)
        Me.LayoutControlItem17.Text = "Paid:"
        Me.LayoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(29, 16)
        Me.LayoutControlItem17.TextToControlDistance = 5
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.txtRemain
        Me.LayoutControlItem18.Location = New System.Drawing.Point(328, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem18.Size = New System.Drawing.Size(176, 26)
        Me.LayoutControlItem18.Text = "Remaining:"
        Me.LayoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(65, 16)
        Me.LayoutControlItem18.TextToControlDistance = 5
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem12})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 125)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(528, 96)
        Me.LayoutControlGroup4.Text = "Payment Details"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.deStartPeriod
        Me.LayoutControlItem5.CustomizationFormText = "Start Period:"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(139, 25)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(257, 25)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "* Start Period:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtMonDed
        Me.LayoutControlItem6.Location = New System.Drawing.Point(257, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(183, 25)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(247, 25)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "* Monthly Amortization:"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(137, 16)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.lueRemitAllot
        Me.LayoutControlItem12.CustomizationFormText = "Deduct From:"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItem12.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(136, 25)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(504, 25)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.Text = "* Deduct From:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.lueCurrency
        Me.LayoutControlItem15.CustomizationFormText = "Currency:"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(268, 0)
        Me.LayoutControlItem15.MaxSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem15.MinSize = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(260, 25)
        Me.LayoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem15.Text = "* Currency:"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtRemarks
        Me.LayoutControlItem11.CustomizationFormText = "Remarks:"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 100)
        Me.LayoutControlItem11.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(138, 25)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(528, 25)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.Text = "Remarks:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtRefNo
        Me.LayoutControlItem7.CustomizationFormText = "Ref. No.:"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "* Ref. No.:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.deLoanDate
        Me.LayoutControlItem3.CustomizationFormText = "Loan Date:"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "* Loan Date:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.deDateGranted
        Me.LayoutControlItem4.CustomizationFormText = "Date Granted:"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 75)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(268, 25)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "* Date Granted:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(92, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.gcCrewAmort
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(1261, 205)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 205)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(1261, 5)
        '
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1285, 673)
        Me.header.TabIndex = 2
        Me.header.Text = "Crew Amortization Details"
        '
        'clmLoanTotal
        '
        Me.clmLoanTotal.Caption = "Total Loan Amount"
        Me.clmLoanTotal.ColumnEdit = Me.repAmt
        Me.clmLoanTotal.FieldName = "LoanTotal"
        Me.clmLoanTotal.Name = "clmLoanTotal"
        Me.clmLoanTotal.Visible = True
        Me.clmLoanTotal.Width = 168
        '
        'CrewAmortization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.header)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "CrewAmortization"
        Me.Size = New System.Drawing.Size(1285, 673)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcCrewAmort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCrewAmort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WageAshEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.periodEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.periodEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAmt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonDed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemain.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLoanTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcAmortDistrib, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvAmortDistrib, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.remAmtPd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueRemitAllot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartPeriod.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateGranted.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateGranted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deLoanDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deLoanDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRefNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLoanAmt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInterest.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOtherCharge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gcAmortDistrib As DevExpress.XtraGrid.GridControl
    Friend WithEvents gcCrewAmort As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvAmortDistrib As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gvCrewAmort As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents clmPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPeriod As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmVessel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTotalAmt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents clmItem As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmRefNum As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmStartPeriod As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPaid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmRemaining As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lueItem As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lueRemitAllot As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deStartPeriod As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deDateGranted As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deLoanDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtRefNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLoanAmt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtInterest As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtOtherCharge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueCurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtLoanTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPaid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRemain As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtMonDed As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents WageAshEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents periodEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents remAmtPd As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents repAmt As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents clmLoanTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
