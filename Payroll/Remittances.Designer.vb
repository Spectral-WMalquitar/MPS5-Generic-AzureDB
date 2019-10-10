<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Remittances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Remittances))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lueBankBranch = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcOtherDeduction = New DevExpress.XtraGrid.GridControl()
        Me.gvOtherDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn19 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WageAshDEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DCurrencyEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repDedAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BandedGridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.dGenericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gcOtherEarnings = New DevExpress.XtraGrid.GridControl()
        Me.gvOtherEarnings = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WageAshEEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ECurrencyEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repEarnAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.eGenericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gcAllotment = New DevExpress.XtraGrid.GridControl()
        Me.gvAllotment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.aCurrEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repAllotmentAmount = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.periodDisplay = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.periodEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.btnViewRelatives = New DevExpress.XtraEditors.SimpleButton()
        Me.gcAllottee = New DevExpress.XtraGrid.GridControl()
        Me.gvAllottee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmMName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmLName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WAllotSorting = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFullName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyRel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmTelNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPartOfCity = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyCity = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyCntry = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmEmail = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmMobileNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyBank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyBranch = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmAcctName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmAcctNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmAcctType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyCurr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmIsEeDedShare = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyProvince = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSexCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cboSexCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.chkDeduct = New DevExpress.XtraEditors.CheckEdit()
        Me.lueCurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.lueAccType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtAccName = New DevExpress.XtraEditors.TextEdit()
        Me.txtAccNo = New DevExpress.XtraEditors.TextEdit()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.lueState = New DevExpress.XtraEditors.LookUpEdit()
        Me.lueCity = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnUserCrewAddr = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFName = New DevExpress.XtraEditors.TextEdit()
        Me.txtStreet = New DevExpress.XtraEditors.TextEdit()
        Me.lueCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPartOfCity = New DevExpress.XtraEditors.TextEdit()
        Me.txtMName = New DevExpress.XtraEditors.TextEdit()
        Me.txtLName = New DevExpress.XtraEditors.TextEdit()
        Me.lueRelationship = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtMobileNo = New DevExpress.XtraEditors.TextEdit()
        Me.txtTelNo = New DevExpress.XtraEditors.TextEdit()
        Me.lueTypeOfAllot = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.Root2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.tabAllotteeBankDetails = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup_BankDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_AccountInfo = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_AlloteeDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_AllotteeInfo = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_AddrInfo = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup11 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.tabEarnDed = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup_OtherEarn = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_OtherDed = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Allotment = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_AllotteeList = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.lueBankBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcOtherDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOtherDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WageAshDEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DCurrencyEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDedAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGenericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dGenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcOtherEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvOtherEarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WageAshEEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECurrencyEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repEarnAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eGenericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eGenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcAllotment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvAllotment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.aCurrEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAllotmentAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.periodEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.periodEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcAllottee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvAllottee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSexCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDeduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueAccType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueState.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStreet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartOfCity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueRelationship.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMobileNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueTypeOfAllot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabAllotteeBankDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_BankDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_AccountInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_AlloteeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_AllotteeInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_AddrInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabEarnDed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_OtherEarn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_OtherDed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Allotment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_AllotteeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.lueBankBranch)
        Me.LayoutControl1.Controls.Add(Me.gcOtherDeduction)
        Me.LayoutControl1.Controls.Add(Me.gcOtherEarnings)
        Me.LayoutControl1.Controls.Add(Me.gcAllotment)
        Me.LayoutControl1.Controls.Add(Me.btnViewRelatives)
        Me.LayoutControl1.Controls.Add(Me.gcAllottee)
        Me.LayoutControl1.Controls.Add(Me.cboSexCode)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.chkDeduct)
        Me.LayoutControl1.Controls.Add(Me.lueCurrency)
        Me.LayoutControl1.Controls.Add(Me.lueAccType)
        Me.LayoutControl1.Controls.Add(Me.txtAccName)
        Me.LayoutControl1.Controls.Add(Me.txtAccNo)
        Me.LayoutControl1.Controls.Add(Me.txtEmail)
        Me.LayoutControl1.Controls.Add(Me.lueState)
        Me.LayoutControl1.Controls.Add(Me.lueCity)
        Me.LayoutControl1.Controls.Add(Me.btnUserCrewAddr)
        Me.LayoutControl1.Controls.Add(Me.txtFName)
        Me.LayoutControl1.Controls.Add(Me.txtStreet)
        Me.LayoutControl1.Controls.Add(Me.lueCountry)
        Me.LayoutControl1.Controls.Add(Me.txtPartOfCity)
        Me.LayoutControl1.Controls.Add(Me.txtMName)
        Me.LayoutControl1.Controls.Add(Me.txtLName)
        Me.LayoutControl1.Controls.Add(Me.lueRelationship)
        Me.LayoutControl1.Controls.Add(Me.txtMobileNo)
        Me.LayoutControl1.Controls.Add(Me.txtTelNo)
        Me.LayoutControl1.Controls.Add(Me.lueTypeOfAllot)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(111, 92, 670, 532)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1136, 652)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lueBankBranch
        '
        Me.lueBankBranch.Location = New System.Drawing.Point(388, 78)
        Me.lueBankBranch.Name = "lueBankBranch"
        Me.lueBankBranch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)})
        Me.lueBankBranch.Properties.NullText = ""
        Me.lueBankBranch.Properties.View = Me.SearchLookUpEdit1View
        Me.lueBankBranch.Size = New System.Drawing.Size(300, 22)
        Me.lueBankBranch.StyleController = Me.LayoutControl1
        Me.lueBankBranch.TabIndex = 23
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'gcOtherDeduction
        '
        Me.gcOtherDeduction.Location = New System.Drawing.Point(650, 382)
        Me.gcOtherDeduction.MainView = Me.gvOtherDeduction
        Me.gcOtherDeduction.Name = "gcOtherDeduction"
        Me.gcOtherDeduction.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.WageAshDEdit, Me.DCurrencyEdit, Me.dGenericDateEdit, Me.repDedAmount})
        Me.gcOtherDeduction.Size = New System.Drawing.Size(457, 241)
        Me.gcOtherDeduction.TabIndex = 1
        Me.gcOtherDeduction.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvOtherDeduction})
        '
        'gvOtherDeduction
        '
        Me.gvOtherDeduction.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand4})
        Me.gvOtherDeduction.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn19, Me.BandedGridColumn15, Me.BandedGridColumn16, Me.BandedGridColumn17, Me.BandedGridColumn18, Me.BandedGridColumn2, Me.BandedGridColumn4})
        Me.gvOtherDeduction.GridControl = Me.gcOtherDeduction
        Me.gvOtherDeduction.Name = "gvOtherDeduction"
        Me.gvOtherDeduction.OptionsCustomization.AllowSort = False
        Me.gvOtherDeduction.OptionsView.ShowBands = False
        Me.gvOtherDeduction.OptionsView.ShowGroupPanel = False
        '
        'GridBand4
        '
        Me.GridBand4.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.GridBand4.AppearanceHeader.Options.UseFont = True
        Me.GridBand4.Caption = "Other Deduction"
        Me.GridBand4.Columns.Add(Me.BandedGridColumn19)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn15)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn16)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn17)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn18)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 0
        Me.GridBand4.Width = 450
        '
        'BandedGridColumn19
        '
        Me.BandedGridColumn19.FieldName = "PKey"
        Me.BandedGridColumn19.Name = "BandedGridColumn19"
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.Caption = "Deduction"
        Me.BandedGridColumn15.ColumnEdit = Me.WageAshDEdit
        Me.BandedGridColumn15.FieldName = "FKeyWageAshID"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.Tag = "Required"
        Me.BandedGridColumn15.Visible = True
        '
        'WageAshDEdit
        '
        Me.WageAshDEdit.AutoHeight = False
        Me.WageAshDEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WageAshDEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.WageAshDEdit.DisplayMember = "Name"
        Me.WageAshDEdit.Name = "WageAshDEdit"
        Me.WageAshDEdit.NullText = " "
        Me.WageAshDEdit.ShowFooter = False
        Me.WageAshDEdit.ShowHeader = False
        Me.WageAshDEdit.ValueMember = "PKey"
        '
        'BandedGridColumn16
        '
        Me.BandedGridColumn16.Caption = "Currency"
        Me.BandedGridColumn16.ColumnEdit = Me.DCurrencyEdit
        Me.BandedGridColumn16.FieldName = "FKeyCurr"
        Me.BandedGridColumn16.Name = "BandedGridColumn16"
        Me.BandedGridColumn16.Tag = "Required"
        Me.BandedGridColumn16.Visible = True
        '
        'DCurrencyEdit
        '
        Me.DCurrencyEdit.AutoHeight = False
        Me.DCurrencyEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DCurrencyEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.DCurrencyEdit.DisplayMember = "Symbol"
        Me.DCurrencyEdit.Name = "DCurrencyEdit"
        Me.DCurrencyEdit.NullText = " "
        Me.DCurrencyEdit.ShowFooter = False
        Me.DCurrencyEdit.ShowHeader = False
        Me.DCurrencyEdit.ValueMember = "PKey"
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.Caption = "Amount"
        Me.BandedGridColumn17.ColumnEdit = Me.repDedAmount
        Me.BandedGridColumn17.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn17.FieldName = "Amt"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        Me.BandedGridColumn17.Tag = "Required"
        Me.BandedGridColumn17.Visible = True
        '
        'repDedAmount
        '
        Me.repDedAmount.AutoHeight = False
        Me.repDedAmount.Mask.EditMask = "n2"
        Me.repDedAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repDedAmount.Mask.UseMaskAsDisplayFormat = True
        Me.repDedAmount.Name = "repDedAmount"
        '
        'BandedGridColumn18
        '
        Me.BandedGridColumn18.Caption = "Date Start"
        Me.BandedGridColumn18.ColumnEdit = Me.dGenericDateEdit
        Me.BandedGridColumn18.FieldName = "DateStart"
        Me.BandedGridColumn18.Name = "BandedGridColumn18"
        Me.BandedGridColumn18.Tag = "Required"
        Me.BandedGridColumn18.Visible = True
        '
        'dGenericDateEdit
        '
        Me.dGenericDateEdit.AutoHeight = False
        Me.dGenericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dGenericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dGenericDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.dGenericDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.dGenericDateEdit.Name = "dGenericDateEdit"
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Date End"
        Me.BandedGridColumn2.ColumnEdit = Me.dGenericDateEdit
        Me.BandedGridColumn2.FieldName = "DateEnd"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Remarks"
        Me.BandedGridColumn4.FieldName = "Remarks"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        '
        'gcOtherEarnings
        '
        Me.gcOtherEarnings.Location = New System.Drawing.Point(650, 382)
        Me.gcOtherEarnings.MainView = Me.gvOtherEarnings
        Me.gcOtherEarnings.Name = "gcOtherEarnings"
        Me.gcOtherEarnings.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.WageAshEEdit, Me.ECurrencyEdit, Me.eGenericDateEdit, Me.repEarnAmount})
        Me.gcOtherEarnings.Size = New System.Drawing.Size(457, 241)
        Me.gcOtherEarnings.TabIndex = 1
        Me.gcOtherEarnings.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvOtherEarnings})
        '
        'gvOtherEarnings
        '
        Me.gvOtherEarnings.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand3})
        Me.gvOtherEarnings.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn14, Me.BandedGridColumn10, Me.BandedGridColumn11, Me.BandedGridColumn12, Me.BandedGridColumn13, Me.BandedGridColumn1, Me.BandedGridColumn3})
        Me.gvOtherEarnings.GridControl = Me.gcOtherEarnings
        Me.gvOtherEarnings.Name = "gvOtherEarnings"
        Me.gvOtherEarnings.OptionsCustomization.AllowSort = False
        Me.gvOtherEarnings.OptionsView.ShowBands = False
        Me.gvOtherEarnings.OptionsView.ShowGroupPanel = False
        '
        'GridBand3
        '
        Me.GridBand3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.GridBand3.AppearanceHeader.Options.UseFont = True
        Me.GridBand3.Caption = "Other Earnings"
        Me.GridBand3.Columns.Add(Me.BandedGridColumn14)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn10)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn11)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn12)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn13)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 0
        Me.GridBand3.Width = 450
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.FieldName = "PKey"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.Caption = "Earning"
        Me.BandedGridColumn10.ColumnEdit = Me.WageAshEEdit
        Me.BandedGridColumn10.FieldName = "FKeyWageAshID"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Tag = "Required"
        Me.BandedGridColumn10.Visible = True
        '
        'WageAshEEdit
        '
        Me.WageAshEEdit.AutoHeight = False
        Me.WageAshEEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WageAshEEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.WageAshEEdit.DisplayMember = "Name"
        Me.WageAshEEdit.Name = "WageAshEEdit"
        Me.WageAshEEdit.NullText = " "
        Me.WageAshEEdit.ShowFooter = False
        Me.WageAshEEdit.ShowHeader = False
        Me.WageAshEEdit.ValueMember = "PKey"
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Currency"
        Me.BandedGridColumn11.ColumnEdit = Me.ECurrencyEdit
        Me.BandedGridColumn11.FieldName = "FKeyCurr"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Tag = "Required"
        Me.BandedGridColumn11.Visible = True
        '
        'ECurrencyEdit
        '
        Me.ECurrencyEdit.AutoHeight = False
        Me.ECurrencyEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ECurrencyEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.ECurrencyEdit.DisplayMember = "Symbol"
        Me.ECurrencyEdit.Name = "ECurrencyEdit"
        Me.ECurrencyEdit.NullText = " "
        Me.ECurrencyEdit.ShowFooter = False
        Me.ECurrencyEdit.ShowHeader = False
        Me.ECurrencyEdit.ValueMember = "PKey"
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.Caption = "Amount"
        Me.BandedGridColumn12.ColumnEdit = Me.repEarnAmount
        Me.BandedGridColumn12.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn12.FieldName = "Amt"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.Tag = "Required"
        Me.BandedGridColumn12.Visible = True
        '
        'repEarnAmount
        '
        Me.repEarnAmount.AutoHeight = False
        Me.repEarnAmount.Mask.EditMask = "n2"
        Me.repEarnAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repEarnAmount.Mask.UseMaskAsDisplayFormat = True
        Me.repEarnAmount.Name = "repEarnAmount"
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.Caption = "Date Start"
        Me.BandedGridColumn13.ColumnEdit = Me.eGenericDateEdit
        Me.BandedGridColumn13.FieldName = "DateStart"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.Tag = "Required"
        Me.BandedGridColumn13.Visible = True
        '
        'eGenericDateEdit
        '
        Me.eGenericDateEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.eGenericDateEdit.AutoHeight = False
        Me.eGenericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eGenericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.eGenericDateEdit.CalendarTimeProperties.Mask.EditMask = "dd-MMM-yyyy"
        Me.eGenericDateEdit.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = True
        Me.eGenericDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.eGenericDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.eGenericDateEdit.Name = "eGenericDateEdit"
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Date End"
        Me.BandedGridColumn1.ColumnEdit = Me.eGenericDateEdit
        Me.BandedGridColumn1.FieldName = "DateEnd"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Remarks"
        Me.BandedGridColumn3.FieldName = "Remarks"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'gcAllotment
        '
        Me.gcAllotment.Location = New System.Drawing.Point(303, 381)
        Me.gcAllotment.MainView = Me.gvAllotment
        Me.gcAllotment.Name = "gcAllotment"
        Me.gcAllotment.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.periodEdit, Me.aCurrEdit, Me.repAllotmentAmount})
        Me.gcAllotment.Size = New System.Drawing.Size(319, 242)
        Me.gcAllotment.TabIndex = 0
        Me.gcAllotment.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvAllotment})
        '
        'gvAllotment
        '
        Me.gvAllotment.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.gvAllotment.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn9, Me.BandedGridColumn7, Me.periodDisplay, Me.BandedGridColumn5})
        Me.gvAllotment.GridControl = Me.gcAllotment
        Me.gvAllotment.Name = "gvAllotment"
        Me.gvAllotment.OptionsBehavior.Editable = False
        Me.gvAllotment.OptionsBehavior.ReadOnly = True
        Me.gvAllotment.OptionsCustomization.AllowFilter = False
        Me.gvAllotment.OptionsCustomization.AllowGroup = False
        Me.gvAllotment.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvAllotment.OptionsCustomization.AllowSort = False
        Me.gvAllotment.OptionsCustomization.ShowBandsInCustomizationForm = False
        Me.gvAllotment.OptionsEditForm.BindingMode = DevExpress.XtraGrid.Views.Grid.EditFormBindingMode.Direct
        Me.gvAllotment.OptionsMenu.EnableColumnMenu = False
        Me.gvAllotment.OptionsMenu.EnableGroupPanelMenu = False
        Me.gvAllotment.OptionsView.ShowGroupPanel = False
        Me.gvAllotment.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.periodDisplay, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridBand2
        '
        Me.GridBand2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.GridBand2.AppearanceHeader.Options.UseFont = True
        Me.GridBand2.Caption = "Allotment"
        Me.GridBand2.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand2.Columns.Add(Me.periodDisplay)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 225
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Currency"
        Me.BandedGridColumn5.ColumnEdit = Me.aCurrEdit
        Me.BandedGridColumn5.FieldName = "FKeyCurr"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Tag = "Required"
        Me.BandedGridColumn5.Visible = True
        '
        'aCurrEdit
        '
        Me.aCurrEdit.AutoHeight = False
        Me.aCurrEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.aCurrEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.aCurrEdit.DisplayMember = "Symbol"
        Me.aCurrEdit.Name = "aCurrEdit"
        Me.aCurrEdit.NullText = " "
        Me.aCurrEdit.ShowFooter = False
        Me.aCurrEdit.ShowHeader = False
        Me.aCurrEdit.ValueMember = "PKey"
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "Amount"
        Me.BandedGridColumn7.ColumnEdit = Me.repAllotmentAmount
        Me.BandedGridColumn7.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "Amt"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Tag = "Required"
        Me.BandedGridColumn7.Visible = True
        '
        'repAllotmentAmount
        '
        Me.repAllotmentAmount.AutoHeight = False
        Me.repAllotmentAmount.Mask.EditMask = "n2"
        Me.repAllotmentAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repAllotmentAmount.Mask.UseMaskAsDisplayFormat = True
        Me.repAllotmentAmount.Name = "repAllotmentAmount"
        '
        'periodDisplay
        '
        Me.periodDisplay.Caption = "Start Period"
        Me.periodDisplay.ColumnEdit = Me.periodEdit
        Me.periodDisplay.FieldName = "StartPeriod"
        Me.periodDisplay.Name = "periodDisplay"
        Me.periodDisplay.Tag = "Required"
        Me.periodDisplay.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.periodDisplay.Visible = True
        '
        'periodEdit
        '
        Me.periodEdit.AutoHeight = False
        Me.periodEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.periodEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.periodEdit.Mask.EditMask = "MMM yyyy"
        Me.periodEdit.Mask.UseMaskAsDisplayFormat = True
        Me.periodEdit.Name = "periodEdit"
        Me.periodEdit.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        Me.periodEdit.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.FieldName = "PKey"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        '
        'btnViewRelatives
        '
        Me.btnViewRelatives.Location = New System.Drawing.Point(17, 65)
        Me.btnViewRelatives.Name = "btnViewRelatives"
        Me.btnViewRelatives.Size = New System.Drawing.Size(246, 23)
        Me.btnViewRelatives.StyleController = Me.LayoutControl1
        Me.btnViewRelatives.TabIndex = 22
        Me.btnViewRelatives.Text = "View Relatives"
        '
        'gcAllottee
        '
        Me.gcAllottee.Location = New System.Drawing.Point(17, 92)
        Me.gcAllottee.MainView = Me.gvAllottee
        Me.gcAllottee.Name = "gcAllottee"
        Me.gcAllottee.Size = New System.Drawing.Size(246, 543)
        Me.gcAllottee.TabIndex = 5
        Me.gcAllottee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvAllottee})
        '
        'gvAllottee
        '
        Me.gvAllottee.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.gvAllottee.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.clmType, Me.clmFullName, Me.clmPKey, Me.clmFName, Me.clmMName, Me.clmLName, Me.clmFKeyRel, Me.clmTelNo, Me.clmSt, Me.clmPartOfCity, Me.clmFKeyCity, Me.clmFKeyCntry, Me.clmEmail, Me.clmMobileNo, Me.clmRemarks, Me.clmFKeyBank, Me.clmFKeyBranch, Me.clmAcctName, Me.clmAcctNo, Me.clmAcctType, Me.clmFKeyCurr, Me.clmIsEeDedShare, Me.clmFKeyProvince, Me.clmSexCode, Me.WAllotSorting})
        Me.gvAllottee.GridControl = Me.gcAllottee
        Me.gvAllottee.Name = "gvAllottee"
        Me.gvAllottee.OptionsBehavior.Editable = False
        Me.gvAllottee.OptionsBehavior.ReadOnly = True
        Me.gvAllottee.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvAllottee.OptionsFind.AlwaysVisible = True
        Me.gvAllottee.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gvAllottee.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Allottee"
        Me.GridBand1.Columns.Add(Me.clmPKey)
        Me.GridBand1.Columns.Add(Me.clmMName)
        Me.GridBand1.Columns.Add(Me.clmLName)
        Me.GridBand1.Columns.Add(Me.clmFName)
        Me.GridBand1.Columns.Add(Me.WAllotSorting)
        Me.GridBand1.Columns.Add(Me.clmFullName)
        Me.GridBand1.Columns.Add(Me.clmType)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 195
        '
        'clmPKey
        '
        Me.clmPKey.FieldName = "PKey"
        Me.clmPKey.Name = "clmPKey"
        '
        'clmMName
        '
        Me.clmMName.Caption = "Middlename"
        Me.clmMName.FieldName = "MName"
        Me.clmMName.Name = "clmMName"
        '
        'clmLName
        '
        Me.clmLName.Caption = "Lastname"
        Me.clmLName.FieldName = "LName"
        Me.clmLName.Name = "clmLName"
        '
        'clmFName
        '
        Me.clmFName.Caption = "Firstname"
        Me.clmFName.FieldName = "FName"
        Me.clmFName.Name = "clmFName"
        '
        'WAllotSorting
        '
        Me.WAllotSorting.Caption = "WAllotSorting"
        Me.WAllotSorting.FieldName = "WAllotSorting"
        Me.WAllotSorting.Name = "WAllotSorting"
        Me.WAllotSorting.UnboundExpression = "Iif([WAllot] = 'Primary', 1, Iif([WAllot] = 'Secondary', 2, 3))"
        Me.WAllotSorting.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.WAllotSorting.Width = 34
        '
        'clmFullName
        '
        Me.clmFullName.Caption = "Name"
        Me.clmFullName.FieldName = "Fullname"
        Me.clmFullName.Name = "clmFullName"
        Me.clmFullName.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.clmFullName.Visible = True
        Me.clmFullName.Width = 97
        '
        'clmType
        '
        Me.clmType.Caption = "Type"
        Me.clmType.FieldName = "WAllot"
        Me.clmType.Name = "clmType"
        Me.clmType.Visible = True
        Me.clmType.Width = 98
        '
        'clmFKeyRel
        '
        Me.clmFKeyRel.FieldName = "FKeyRel"
        Me.clmFKeyRel.Name = "clmFKeyRel"
        '
        'clmTelNo
        '
        Me.clmTelNo.FieldName = "Phone"
        Me.clmTelNo.Name = "clmTelNo"
        '
        'clmSt
        '
        Me.clmSt.FieldName = "St"
        Me.clmSt.Name = "clmSt"
        '
        'clmPartOfCity
        '
        Me.clmPartOfCity.FieldName = "PartofCity"
        Me.clmPartOfCity.Name = "clmPartOfCity"
        '
        'clmFKeyCity
        '
        Me.clmFKeyCity.FieldName = "FKeyCity"
        Me.clmFKeyCity.Name = "clmFKeyCity"
        '
        'clmFKeyCntry
        '
        Me.clmFKeyCntry.FieldName = "FKeyCntry"
        Me.clmFKeyCntry.Name = "clmFKeyCntry"
        '
        'clmEmail
        '
        Me.clmEmail.FieldName = "Email"
        Me.clmEmail.Name = "clmEmail"
        '
        'clmMobileNo
        '
        Me.clmMobileNo.FieldName = "Mobile"
        Me.clmMobileNo.Name = "clmMobileNo"
        '
        'clmRemarks
        '
        Me.clmRemarks.FieldName = "Remarks"
        Me.clmRemarks.Name = "clmRemarks"
        '
        'clmFKeyBank
        '
        Me.clmFKeyBank.FieldName = "FKeyBank"
        Me.clmFKeyBank.Name = "clmFKeyBank"
        '
        'clmFKeyBranch
        '
        Me.clmFKeyBranch.FieldName = "FKeyBranch"
        Me.clmFKeyBranch.Name = "clmFKeyBranch"
        '
        'clmAcctName
        '
        Me.clmAcctName.FieldName = "AcctName"
        Me.clmAcctName.Name = "clmAcctName"
        '
        'clmAcctNo
        '
        Me.clmAcctNo.FieldName = "AcctNbr"
        Me.clmAcctNo.Name = "clmAcctNo"
        '
        'clmAcctType
        '
        Me.clmAcctType.FieldName = "AcctType"
        Me.clmAcctType.Name = "clmAcctType"
        '
        'clmFKeyCurr
        '
        Me.clmFKeyCurr.FieldName = "FKeyCurrency"
        Me.clmFKeyCurr.Name = "clmFKeyCurr"
        '
        'clmIsEeDedShare
        '
        Me.clmIsEeDedShare.FieldName = "IsEeDedShare"
        Me.clmIsEeDedShare.Name = "clmIsEeDedShare"
        '
        'clmFKeyProvince
        '
        Me.clmFKeyProvince.FieldName = "FKeyProvince"
        Me.clmFKeyProvince.Name = "clmFKeyProvince"
        '
        'clmSexCode
        '
        Me.clmSexCode.Caption = "SexCode"
        Me.clmSexCode.FieldName = "SexCode"
        Me.clmSexCode.Name = "clmSexCode"
        '
        'cboSexCode
        '
        Me.cboSexCode.Location = New System.Drawing.Point(388, 155)
        Me.cboSexCode.Name = "cboSexCode"
        Me.cboSexCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboSexCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboSexCode.Properties.DisplayMember = "Name"
        Me.cboSexCode.Properties.DropDownRows = 2
        Me.cboSexCode.Properties.NullText = " "
        Me.cboSexCode.Properties.ShowFooter = False
        Me.cboSexCode.Properties.ShowHeader = False
        Me.cboSexCode.Properties.ValueMember = "PKey"
        Me.cboSexCode.Size = New System.Drawing.Size(273, 22)
        Me.cboSexCode.StyleController = Me.LayoutControl1
        Me.cboSexCode.TabIndex = 22
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(794, 260)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(260, 21)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 12
        '
        'chkDeduct
        '
        Me.chkDeduct.Location = New System.Drawing.Point(291, 297)
        Me.chkDeduct.Name = "chkDeduct"
        Me.chkDeduct.Properties.Caption = "Deduct Employee Contribution"
        Me.chkDeduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkDeduct.Size = New System.Drawing.Size(828, 20)
        Me.chkDeduct.StyleController = Me.LayoutControl1
        Me.chkDeduct.TabIndex = 19
        '
        'lueCurrency
        '
        Me.lueCurrency.Location = New System.Drawing.Point(388, 182)
        Me.lueCurrency.Name = "lueCurrency"
        Me.lueCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lueCurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lueCurrency.Properties.DisplayMember = "Symbol"
        Me.lueCurrency.Properties.NullText = " "
        Me.lueCurrency.Properties.ShowFooter = False
        Me.lueCurrency.Properties.ShowHeader = False
        Me.lueCurrency.Properties.ValueMember = "PKey"
        Me.lueCurrency.Size = New System.Drawing.Size(300, 22)
        Me.lueCurrency.StyleController = Me.LayoutControl1
        Me.lueCurrency.TabIndex = 18
        '
        'lueAccType
        '
        Me.lueAccType.Location = New System.Drawing.Point(388, 156)
        Me.lueAccType.Name = "lueAccType"
        Me.lueAccType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lueAccType.Properties.DisplayMember = "AccType"
        Me.lueAccType.Properties.DropDownRows = 3
        Me.lueAccType.Properties.NullText = " "
        Me.lueAccType.Properties.ShowFooter = False
        Me.lueAccType.Properties.ShowHeader = False
        Me.lueAccType.Properties.ValueMember = "AccType"
        Me.lueAccType.Size = New System.Drawing.Size(300, 22)
        Me.lueAccType.StyleController = Me.LayoutControl1
        Me.lueAccType.TabIndex = 17
        '
        'txtAccName
        '
        Me.txtAccName.Location = New System.Drawing.Point(388, 104)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(300, 22)
        Me.txtAccName.StyleController = Me.LayoutControl1
        Me.txtAccName.TabIndex = 15
        '
        'txtAccNo
        '
        Me.txtAccNo.Location = New System.Drawing.Point(388, 130)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(300, 22)
        Me.txtAccNo.StyleController = Me.LayoutControl1
        Me.txtAccNo.TabIndex = 16
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(794, 234)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(260, 22)
        Me.txtEmail.StyleController = Me.LayoutControl1
        Me.txtEmail.TabIndex = 10
        '
        'lueState
        '
        Me.lueState.Location = New System.Drawing.Point(794, 182)
        Me.lueState.Name = "lueState"
        Me.lueState.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lueState.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lueState.Properties.DisplayMember = "Name"
        Me.lueState.Properties.NullText = " "
        Me.lueState.Properties.ShowFooter = False
        Me.lueState.Properties.ShowHeader = False
        Me.lueState.Properties.ValueMember = "PKey"
        Me.lueState.Size = New System.Drawing.Size(260, 22)
        Me.lueState.StyleController = Me.LayoutControl1
        Me.lueState.TabIndex = 20
        '
        'lueCity
        '
        Me.lueCity.Location = New System.Drawing.Point(794, 208)
        Me.lueCity.Name = "lueCity"
        Me.lueCity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lueCity.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lueCity.Properties.DisplayMember = "Name"
        Me.lueCity.Properties.NullText = " "
        Me.lueCity.Properties.ShowFooter = False
        Me.lueCity.Properties.ShowHeader = False
        Me.lueCity.Properties.ValueMember = "PKey"
        Me.lueCity.Size = New System.Drawing.Size(260, 22)
        Me.lueCity.StyleController = Me.LayoutControl1
        Me.lueCity.TabIndex = 8
        '
        'btnUserCrewAddr
        '
        Me.btnUserCrewAddr.Location = New System.Drawing.Point(709, 78)
        Me.btnUserCrewAddr.Name = "btnUserCrewAddr"
        Me.btnUserCrewAddr.Size = New System.Drawing.Size(345, 23)
        Me.btnUserCrewAddr.StyleController = Me.LayoutControl1
        Me.btnUserCrewAddr.TabIndex = 21
        Me.btnUserCrewAddr.Text = "User Crew Address"
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(388, 103)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(273, 22)
        Me.txtFName.StyleController = Me.LayoutControl1
        Me.txtFName.TabIndex = 0
        '
        'txtStreet
        '
        Me.txtStreet.Location = New System.Drawing.Point(794, 105)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(260, 22)
        Me.txtStreet.StyleController = Me.LayoutControl1
        Me.txtStreet.TabIndex = 6
        '
        'lueCountry
        '
        Me.lueCountry.Location = New System.Drawing.Point(794, 156)
        Me.lueCountry.Name = "lueCountry"
        Me.lueCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lueCountry.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.lueCountry.Properties.DisplayMember = "Name"
        Me.lueCountry.Properties.NullText = " "
        Me.lueCountry.Properties.ShowFooter = False
        Me.lueCountry.Properties.ShowHeader = False
        Me.lueCountry.Properties.ValueMember = "PKey"
        Me.lueCountry.Size = New System.Drawing.Size(260, 22)
        Me.lueCountry.StyleController = Me.LayoutControl1
        Me.lueCountry.TabIndex = 9
        '
        'txtPartOfCity
        '
        Me.txtPartOfCity.Location = New System.Drawing.Point(794, 130)
        Me.txtPartOfCity.Name = "txtPartOfCity"
        Me.txtPartOfCity.Size = New System.Drawing.Size(260, 22)
        Me.txtPartOfCity.StyleController = Me.LayoutControl1
        Me.txtPartOfCity.TabIndex = 7
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(388, 129)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.Size = New System.Drawing.Size(273, 22)
        Me.txtMName.StyleController = Me.LayoutControl1
        Me.txtMName.TabIndex = 1
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(388, 78)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(273, 22)
        Me.txtLName.StyleController = Me.LayoutControl1
        Me.txtLName.TabIndex = 2
        '
        'lueRelationship
        '
        Me.lueRelationship.Location = New System.Drawing.Point(388, 181)
        Me.lueRelationship.Name = "lueRelationship"
        Me.lueRelationship.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lueRelationship.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lueRelationship.Properties.DisplayMember = "Name"
        Me.lueRelationship.Properties.NullText = " "
        Me.lueRelationship.Properties.ShowFooter = False
        Me.lueRelationship.Properties.ShowHeader = False
        Me.lueRelationship.Properties.ValueMember = "PKey"
        Me.lueRelationship.Size = New System.Drawing.Size(273, 22)
        Me.lueRelationship.StyleController = Me.LayoutControl1
        Me.lueRelationship.TabIndex = 3
        '
        'txtMobileNo
        '
        Me.txtMobileNo.Location = New System.Drawing.Point(388, 259)
        Me.txtMobileNo.Name = "txtMobileNo"
        Me.txtMobileNo.Size = New System.Drawing.Size(273, 22)
        Me.txtMobileNo.StyleController = Me.LayoutControl1
        Me.txtMobileNo.TabIndex = 11
        '
        'txtTelNo
        '
        Me.txtTelNo.Location = New System.Drawing.Point(388, 233)
        Me.txtTelNo.Name = "txtTelNo"
        Me.txtTelNo.Size = New System.Drawing.Size(273, 22)
        Me.txtTelNo.StyleController = Me.LayoutControl1
        Me.txtTelNo.TabIndex = 5
        '
        'lueTypeOfAllot
        '
        Me.lueTypeOfAllot.Location = New System.Drawing.Point(388, 207)
        Me.lueTypeOfAllot.Name = "lueTypeOfAllot"
        Me.lueTypeOfAllot.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.lueTypeOfAllot.Properties.DisplayMember = "TypeofAllot"
        Me.lueTypeOfAllot.Properties.DropDownRows = 3
        Me.lueTypeOfAllot.Properties.NullText = " "
        Me.lueTypeOfAllot.Properties.ShowFooter = False
        Me.lueTypeOfAllot.Properties.ShowHeader = False
        Me.lueTypeOfAllot.Properties.ValueMember = "TypeofAllot"
        Me.lueTypeOfAllot.Size = New System.Drawing.Size(273, 22)
        Me.lueTypeOfAllot.StyleController = Me.LayoutControl1
        Me.lueTypeOfAllot.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1136, 652)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.Root2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1136, 652)
        Me.LayoutControlGroup2.Text = "Remittances"
        '
        'Root2
        '
        Me.Root2.CustomizationFormText = "Root"
        Me.Root2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root2.GroupBordersVisible = False
        Me.Root2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.tabAllotteeBankDetails, Me.LayoutControlGroup11, Me.LayoutControlGroup_AllotteeList})
        Me.Root2.Location = New System.Drawing.Point(0, 0)
        Me.Root2.Name = "Root2"
        Me.Root2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.Root2.Size = New System.Drawing.Size(1130, 622)
        Me.Root2.Spacing = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.Root2.Text = "Root"
        Me.Root2.TextVisible = False
        '
        'tabAllotteeBankDetails
        '
        Me.tabAllotteeBankDetails.AppearanceTabPage.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.tabAllotteeBankDetails.AppearanceTabPage.Header.Options.UseFont = True
        Me.tabAllotteeBankDetails.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.tabAllotteeBankDetails.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.tabAllotteeBankDetails.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabAllotteeBankDetails.Location = New System.Drawing.Point(274, 0)
        Me.tabAllotteeBankDetails.Name = "tabAllotteeBankDetails"
        Me.tabAllotteeBankDetails.SelectedTabPage = Me.LayoutControlGroup_AlloteeDetails
        Me.tabAllotteeBankDetails.SelectedTabPageIndex = 0
        Me.tabAllotteeBankDetails.Size = New System.Drawing.Size(856, 304)
        Me.tabAllotteeBankDetails.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_AlloteeDetails, Me.LayoutControlGroup_BankDetails})
        '
        'LayoutControlGroup_BankDetails
        '
        Me.LayoutControlGroup_BankDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem3, Me.LayoutControlGroup_AccountInfo})
        Me.LayoutControlGroup_BankDetails.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_BankDetails.Name = "LayoutControlGroup_BankDetails"
        Me.LayoutControlGroup_BankDetails.Size = New System.Drawing.Size(832, 255)
        Me.LayoutControlGroup_BankDetails.Text = "Bank Details"
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(413, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(419, 255)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_AccountInfo
        '
        Me.LayoutControlGroup_AccountInfo.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem5, Me.EmptySpaceItem4, Me.LayoutControlItem12, Me.LayoutControlItem6, Me.LayoutControlItem11, Me.LayoutControlItem22, Me.LayoutControlItem27})
        Me.LayoutControlGroup_AccountInfo.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_AccountInfo.Name = "LayoutControlGroup_AccountInfo"
        Me.LayoutControlGroup_AccountInfo.Size = New System.Drawing.Size(413, 255)
        Me.LayoutControlGroup_AccountInfo.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 139)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(389, 92)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 130)
        Me.EmptySpaceItem4.MaxSize = New System.Drawing.Size(0, 9)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(9, 9)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(389, 9)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.lueCurrency
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(389, 26)
        Me.LayoutControlItem12.Text = "*Currency:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.lueAccType
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(389, 26)
        Me.LayoutControlItem6.Text = "*Acc Type:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtAccNo
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(389, 26)
        Me.LayoutControlItem11.Text = "*Acc No.:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.txtAccName
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(389, 26)
        Me.LayoutControlItem22.Text = "*Acc Name:"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.lueBankBranch
        Me.LayoutControlItem27.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(389, 26)
        Me.LayoutControlItem27.Text = "*Bank:"
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlGroup_AlloteeDetails
        '
        Me.LayoutControlGroup_AlloteeDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2, Me.EmptySpaceItem6, Me.LayoutControlGroup_AllotteeInfo, Me.LayoutControlGroup_AddrInfo, Me.LayoutControlItem1})
        Me.LayoutControlGroup_AlloteeDetails.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_AlloteeDetails.Name = "LayoutControlGroup_AlloteeDetails"
        Me.LayoutControlGroup_AlloteeDetails.Size = New System.Drawing.Size(832, 255)
        Me.LayoutControlGroup_AlloteeDetails.Text = "Allottee Details"
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(386, 0)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(20, 0)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(20, 9)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(20, 231)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(779, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(53, 231)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_AllotteeInfo
        '
        Me.LayoutControlGroup_AllotteeInfo.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem3, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem15})
        Me.LayoutControlGroup_AllotteeInfo.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_AllotteeInfo.Name = "LayoutControlGroup_AllotteeInfo"
        Me.LayoutControlGroup_AllotteeInfo.Size = New System.Drawing.Size(386, 231)
        Me.LayoutControlGroup_AllotteeInfo.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtLName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(362, 25)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(362, 25)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(362, 25)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "*Lastname:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtFName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(362, 26)
        Me.LayoutControlItem3.Text = "*Firstname:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtMName
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(362, 26)
        Me.LayoutControlItem7.Text = "Middlename:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboSexCode
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 77)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(362, 26)
        Me.LayoutControlItem9.Text = "*Gender:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.lueRelationship
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 103)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(362, 26)
        Me.LayoutControlItem10.Text = "*Relationship:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.lueTypeOfAllot
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 129)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(362, 26)
        Me.LayoutControlItem13.Text = "Type of Allot:"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.txtTelNo
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 155)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(362, 26)
        Me.LayoutControlItem14.Text = "Tel no.:"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.txtMobileNo
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 181)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(362, 26)
        Me.LayoutControlItem15.Text = "Mobile No.:"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlGroup_AddrInfo
        '
        Me.LayoutControlGroup_AddrInfo.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem16, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LayoutControlItem19, Me.LayoutControlItem20, Me.LayoutControlItem21, Me.LayoutControlItem23, Me.LayoutControlItem24})
        Me.LayoutControlGroup_AddrInfo.Location = New System.Drawing.Point(406, 0)
        Me.LayoutControlGroup_AddrInfo.Name = "LayoutControlGroup_AddrInfo"
        Me.LayoutControlGroup_AddrInfo.Size = New System.Drawing.Size(373, 231)
        Me.LayoutControlGroup_AddrInfo.TextVisible = False
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.btnUserCrewAddr
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(349, 27)
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.txtStreet
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControlItem17.MaxSize = New System.Drawing.Size(349, 25)
        Me.LayoutControlItem17.MinSize = New System.Drawing.Size(349, 25)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(349, 25)
        Me.LayoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem17.Text = "Street:"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.txtPartOfCity
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(349, 26)
        Me.LayoutControlItem18.Text = "Part of City:"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.lueCountry
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(349, 26)
        Me.LayoutControlItem19.Text = "Country:"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.lueState
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(349, 26)
        Me.LayoutControlItem20.Text = "State:"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.lueCity
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(349, 26)
        Me.LayoutControlItem21.Text = "City:"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.txtEmail
        Me.LayoutControlItem23.Location = New System.Drawing.Point(0, 156)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(349, 26)
        Me.LayoutControlItem23.Text = "Email:"
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.txtRemarks
        Me.LayoutControlItem24.Location = New System.Drawing.Point(0, 182)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(349, 25)
        Me.LayoutControlItem24.Text = "Remarks:"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.chkDeduct
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 231)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(832, 24)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup11
        '
        Me.LayoutControlGroup11.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.tabEarnDed, Me.LayoutControlGroup_Allotment})
        Me.LayoutControlGroup11.Location = New System.Drawing.Point(274, 304)
        Me.LayoutControlGroup11.Name = "LayoutControlGroup11"
        Me.LayoutControlGroup11.Size = New System.Drawing.Size(856, 318)
        Me.LayoutControlGroup11.TextVisible = False
        '
        'tabEarnDed
        '
        Me.tabEarnDed.AppearanceTabPage.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.tabEarnDed.AppearanceTabPage.Header.Options.UseFont = True
        Me.tabEarnDed.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabEarnDed.Location = New System.Drawing.Point(347, 0)
        Me.tabEarnDed.Name = "tabEarnDed"
        Me.tabEarnDed.SelectedTabPage = Me.LayoutControlGroup_OtherEarn
        Me.tabEarnDed.SelectedTabPageIndex = 0
        Me.tabEarnDed.Size = New System.Drawing.Size(485, 294)
        Me.tabEarnDed.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_OtherEarn, Me.LayoutControlGroup_OtherDed})
        '
        'LayoutControlGroup_OtherEarn
        '
        Me.LayoutControlGroup_OtherEarn.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem26})
        Me.LayoutControlGroup_OtherEarn.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_OtherEarn.Name = "LayoutControlGroup_OtherEarn"
        Me.LayoutControlGroup_OtherEarn.Size = New System.Drawing.Size(461, 245)
        Me.LayoutControlGroup_OtherEarn.Text = "Other Earnings"
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.gcOtherEarnings
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(461, 245)
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem26.TextVisible = False
        '
        'LayoutControlGroup_OtherDed
        '
        Me.LayoutControlGroup_OtherDed.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem29})
        Me.LayoutControlGroup_OtherDed.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_OtherDed.Name = "LayoutControlGroup_OtherDed"
        Me.LayoutControlGroup_OtherDed.Size = New System.Drawing.Size(461, 245)
        Me.LayoutControlGroup_OtherDed.Text = "Other Deductions"
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.gcOtherDeduction
        Me.LayoutControlItem29.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(461, 245)
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem29.TextVisible = False
        '
        'LayoutControlGroup_Allotment
        '
        Me.LayoutControlGroup_Allotment.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem28})
        Me.LayoutControlGroup_Allotment.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Allotment.Name = "LayoutControlGroup_Allotment"
        Me.LayoutControlGroup_Allotment.Size = New System.Drawing.Size(347, 294)
        Me.LayoutControlGroup_Allotment.Text = "Allotment"
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.gcAllotment
        Me.LayoutControlItem28.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(323, 246)
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem28.TextVisible = False
        '
        'LayoutControlGroup_AllotteeList
        '
        Me.LayoutControlGroup_AllotteeList.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem25, Me.LayoutControlItem2})
        Me.LayoutControlGroup_AllotteeList.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_AllotteeList.Name = "LayoutControlGroup_AllotteeList"
        Me.LayoutControlGroup_AllotteeList.Size = New System.Drawing.Size(274, 622)
        Me.LayoutControlGroup_AllotteeList.Text = "Allottee List"
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.btnViewRelatives
        Me.LayoutControlItem25.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(250, 27)
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem25.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.gcAllottee
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(250, 547)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'Remittances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Remittances"
        Me.Size = New System.Drawing.Size(1136, 652)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.lueBankBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcOtherDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvOtherDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WageAshDEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DCurrencyEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDedAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dGenericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcOtherEarnings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvOtherEarnings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WageAshEEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECurrencyEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repEarnAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eGenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eGenericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcAllotment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvAllotment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.aCurrEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAllotmentAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.periodEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.periodEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcAllottee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvAllottee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSexCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDeduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueAccType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueState.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStreet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartOfCity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueRelationship.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMobileNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueTypeOfAllot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabAllotteeBankDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_BankDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_AccountInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_AlloteeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_AllotteeInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_AddrInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabEarnDed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_OtherEarn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_OtherDed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Allotment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_AllotteeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents gcAllotment As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvAllotment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents periodDisplay As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Root2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtFName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueRelationship As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtMName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueTypeOfAllot As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtStreet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPartOfCity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueCity As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lueCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTelNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMobileNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtAccNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lueAccType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lueCurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkDeduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtAccName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents periodEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents gcOtherEarnings As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvOtherEarnings As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents WageAshEEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ECurrencyEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents eGenericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gcOtherDeduction As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvOtherDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents WageAshDEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BandedGridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DCurrencyEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents dGenericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn19 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents aCurrEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents lueState As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnUserCrewAddr As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnViewRelatives As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcAllottee As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvAllottee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents clmPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmMName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmLName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFullName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyRel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmTelNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPartOfCity As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyCity As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyCntry As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmEmail As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmMobileNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyBank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyBranch As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmAcctName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmAcctNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmAcctType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyCurr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmIsEeDedShare As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyProvince As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSexCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents cboSexCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup_AllotteeList As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents tabAllotteeBankDetails As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup_BankDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup_AlloteeDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup11 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents tabEarnDed As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup_OtherEarn As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_OtherDed As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_Allotment As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents WAllotSorting As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlGroup_AllotteeInfo As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_AddrInfo As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_AccountInfo As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents repAllotmentAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents repDedAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents repEarnAmount As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents lueBankBranch As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem

End Class
