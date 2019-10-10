<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpDocs
    'Inherits BaseControl.BaseControl
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpDocs))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.docFilter = New DevExpress.XtraBars.BarEditItem()
        Me.documentEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.chkExpiring = New DevExpress.XtraBars.BarEditItem()
        Me.chkEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.chkExpired = New DevExpress.XtraBars.BarEditItem()
        Me.chkEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btnApply = New DevExpress.XtraBars.BarButtonItem()
        Me.btnGotoDocs = New DevExpress.XtraBars.BarButtonItem()
        Me.BarCheckItem1 = New DevExpress.XtraBars.BarCheckItem()
        Me.BarButtonGroup1 = New DevExpress.XtraBars.BarButtonGroup()
        Me.cmdPreviewReport = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdPreviewReportAll = New DevExpress.XtraBars.BarButtonItem()
        Me.chkExpDocAlert = New DevExpress.XtraBars.BarEditItem()
        Me.chkEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.tabDocGroups = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colIDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocGrp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDoc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateIssue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.genericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colDateExpiry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFKeyDoc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.documentEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.tabDocGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDocGroups.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.AllowMinimizeRibbon = False
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.docFilter, Me.chkExpiring, Me.chkExpired, Me.btnApply, Me.btnGotoDocs, Me.BarCheckItem1, Me.BarButtonGroup1, Me.cmdPreviewReport, Me.cmdPreviewReportAll, Me.chkExpDocAlert})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonControl1.MaxItemId = 30
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkEdit, Me.chkEdit2, Me.RepositoryItemLookUpEdit1, Me.chkEdit3})
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(1018, 104)
        Me.RibbonControl1.Toolbar.ItemLinks.Add(Me.BarButtonGroup1)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'docFilter
        '
        Me.docFilter.Caption = "Document"
        Me.docFilter.Edit = Me.documentEdit
        Me.docFilter.Id = 2
        Me.docFilter.Name = "docFilter"
        Me.docFilter.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.docFilter.Width = 150
        '
        'documentEdit
        '
        Me.documentEdit.AutoHeight = False
        Me.documentEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.documentEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.documentEdit.DisplayMember = "Name"
        Me.documentEdit.Name = "documentEdit"
        Me.documentEdit.NullText = ""
        Me.documentEdit.ShowFooter = False
        Me.documentEdit.ShowHeader = False
        Me.documentEdit.ValueMember = "PKey"
        '
        'chkExpiring
        '
        Me.chkExpiring.Caption = "Expiring"
        Me.chkExpiring.Edit = Me.chkEdit
        Me.chkExpiring.Id = 12
        Me.chkExpiring.Name = "chkExpiring"
        '
        'chkEdit
        '
        Me.chkEdit.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkEdit.Appearance.Options.UseBackColor = True
        Me.chkEdit.AppearanceFocused.BackColor = System.Drawing.Color.Transparent
        Me.chkEdit.AppearanceFocused.BackColor2 = System.Drawing.Color.Transparent
        Me.chkEdit.AppearanceFocused.Options.UseBackColor = True
        Me.chkEdit.AutoHeight = False
        Me.chkEdit.Name = "chkEdit"
        Me.chkEdit.ValueChecked = CType(2, Short)
        Me.chkEdit.ValueUnchecked = CType(0, Short)
        '
        'chkExpired
        '
        Me.chkExpired.Caption = "Expired "
        Me.chkExpired.Edit = Me.chkEdit2
        Me.chkExpired.Id = 13
        Me.chkExpired.Name = "chkExpired"
        '
        'chkEdit2
        '
        Me.chkEdit2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkEdit2.Appearance.Options.UseBackColor = True
        Me.chkEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Transparent
        Me.chkEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Transparent
        Me.chkEdit2.AppearanceFocused.Options.UseBackColor = True
        Me.chkEdit2.AutoHeight = False
        Me.chkEdit2.Name = "chkEdit2"
        Me.chkEdit2.ValueChecked = CType(1, Short)
        Me.chkEdit2.ValueUnchecked = CType(0, Short)
        '
        'btnApply
        '
        Me.btnApply.Caption = "Apply Filter"
        Me.btnApply.Glyph = CType(resources.GetObject("btnApply.Glyph"), System.Drawing.Image)
        Me.btnApply.Id = 15
        Me.btnApply.LargeWidth = 80
        Me.btnApply.Name = "btnApply"
        Me.btnApply.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnGotoDocs
        '
        Me.btnGotoDocs.Caption = "Go to Documents"
        Me.btnGotoDocs.Glyph = CType(resources.GetObject("btnGotoDocs.Glyph"), System.Drawing.Image)
        Me.btnGotoDocs.Id = 16
        Me.btnGotoDocs.LargeWidth = 80
        Me.btnGotoDocs.Name = "btnGotoDocs"
        Me.btnGotoDocs.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarCheckItem1
        '
        Me.BarCheckItem1.Caption = "BarCheckItem1"
        Me.BarCheckItem1.Id = 18
        Me.BarCheckItem1.Name = "BarCheckItem1"
        '
        'BarButtonGroup1
        '
        Me.BarButtonGroup1.Caption = "BarButtonGroup1"
        Me.BarButtonGroup1.Id = 19
        Me.BarButtonGroup1.Name = "BarButtonGroup1"
        '
        'cmdPreviewReport
        '
        Me.cmdPreviewReport.Caption = "Preview Selected Group"
        Me.cmdPreviewReport.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdPreviewReport.Glyph = CType(resources.GetObject("cmdPreviewReport.Glyph"), System.Drawing.Image)
        Me.cmdPreviewReport.Id = 21
        Me.cmdPreviewReport.Name = "cmdPreviewReport"
        Me.cmdPreviewReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdPreviewReportAll
        '
        Me.cmdPreviewReportAll.Caption = "Preview All"
        Me.cmdPreviewReportAll.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdPreviewReportAll.Glyph = CType(resources.GetObject("cmdPreviewReportAll.Glyph"), System.Drawing.Image)
        Me.cmdPreviewReportAll.Id = 22
        Me.cmdPreviewReportAll.Name = "cmdPreviewReportAll"
        Me.cmdPreviewReportAll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'chkExpDocAlert
        '
        Me.chkExpDocAlert.Caption = "Show form on start up"
        Me.chkExpDocAlert.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.chkExpDocAlert.Edit = Me.chkEdit3
        Me.chkExpDocAlert.Id = 26
        Me.chkExpDocAlert.Name = "chkExpDocAlert"
        '
        'chkEdit3
        '
        Me.chkEdit3.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.chkEdit3.Appearance.Options.UseBackColor = True
        Me.chkEdit3.AppearanceFocused.BackColor = System.Drawing.Color.Transparent
        Me.chkEdit3.AppearanceFocused.BackColor2 = System.Drawing.Color.Transparent
        Me.chkEdit3.AppearanceFocused.Options.UseBackColor = True
        Me.chkEdit3.AutoHeight = False
        Me.chkEdit3.Name = "chkEdit3"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.docFilter, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.chkExpiring, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.chkExpired)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnApply, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Filter Options"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnGotoDocs)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.cmdPreviewReport, True)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.cmdPreviewReportAll)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Viewing Options"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.chkExpDocAlert)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "User Settings"
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.tabDocGroups)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1018, 538)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'tabDocGroups
        '
        Me.tabDocGroups.Location = New System.Drawing.Point(2, 2)
        Me.tabDocGroups.Name = "tabDocGroups"
        Me.tabDocGroups.SelectedTabPage = Me.XtraTabPage1
        Me.tabDocGroups.Size = New System.Drawing.Size(1014, 534)
        Me.tabDocGroups.TabIndex = 4
        Me.tabDocGroups.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.Maingrid)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1008, 503)
        Me.XtraTabPage1.Text = "XtraTabPage1"
        '
        'Maingrid
        '
        Me.Maingrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Maingrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Maingrid.Location = New System.Drawing.Point(0, 0)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.MenuManager = Me.RibbonControl1
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.genericDateEdit})
        Me.Maingrid.Size = New System.Drawing.Size(1008, 503)
        Me.Maingrid.TabIndex = 0
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIDNbr, Me.colDocPKey, Me.colDocGrp, Me.colCrewName, Me.colDoc, Me.colNumber, Me.colDateIssue, Me.colDateExpiry, Me.colFKeyDoc, Me.colRemarks})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsBehavior.Editable = False
        Me.Mainview.OptionsBehavior.ReadOnly = True
        Me.Mainview.OptionsCustomization.AllowColumnMoving = False
        Me.Mainview.OptionsCustomization.AllowGroup = False
        Me.Mainview.OptionsFind.AlwaysVisible = True
        Me.Mainview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'colIDNbr
        '
        Me.colIDNbr.FieldName = "IDNbr"
        Me.colIDNbr.Name = "colIDNbr"
        '
        'colDocPKey
        '
        Me.colDocPKey.FieldName = "PKey"
        Me.colDocPKey.Name = "colDocPKey"
        '
        'colDocGrp
        '
        Me.colDocGrp.Caption = "colDocGrp"
        Me.colDocGrp.FieldName = "FKeyDocGroup"
        Me.colDocGrp.Name = "colDocGrp"
        '
        'colCrewName
        '
        Me.colCrewName.Caption = "Crew Name"
        Me.colCrewName.FieldName = "CrewName"
        Me.colCrewName.Name = "colCrewName"
        Me.colCrewName.Tag = "CrewName"
        Me.colCrewName.Visible = True
        Me.colCrewName.VisibleIndex = 0
        '
        'colDoc
        '
        Me.colDoc.Caption = "Document"
        Me.colDoc.FieldName = "Name"
        Me.colDoc.Name = "colDoc"
        Me.colDoc.Tag = "DocName"
        Me.colDoc.Visible = True
        Me.colDoc.VisibleIndex = 1
        '
        'colNumber
        '
        Me.colNumber.Caption = "Number"
        Me.colNumber.FieldName = "Number"
        Me.colNumber.Name = "colNumber"
        Me.colNumber.Tag = "DocNum"
        Me.colNumber.Visible = True
        Me.colNumber.VisibleIndex = 2
        '
        'colDateIssue
        '
        Me.colDateIssue.Caption = "Date Issue"
        Me.colDateIssue.ColumnEdit = Me.genericDateEdit
        Me.colDateIssue.FieldName = "DateIssue"
        Me.colDateIssue.Name = "colDateIssue"
        Me.colDateIssue.Tag = "DocStart"
        Me.colDateIssue.Visible = True
        Me.colDateIssue.VisibleIndex = 3
        '
        'genericDateEdit
        '
        Me.genericDateEdit.AutoHeight = False
        Me.genericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.Name = "genericDateEdit"
        '
        'colDateExpiry
        '
        Me.colDateExpiry.Caption = "Date Expiry"
        Me.colDateExpiry.ColumnEdit = Me.genericDateEdit
        Me.colDateExpiry.FieldName = "DateExpiry"
        Me.colDateExpiry.Name = "colDateExpiry"
        Me.colDateExpiry.Tag = "DocEnd"
        Me.colDateExpiry.Visible = True
        Me.colDateExpiry.VisibleIndex = 4
        '
        'colFKeyDoc
        '
        Me.colFKeyDoc.FieldName = "FKeyDoc"
        Me.colFKeyDoc.Name = "colFKeyDoc"
        '
        'colRemarks
        '
        Me.colRemarks.Caption = "Remarks"
        Me.colRemarks.FieldName = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.Tag = "Remarks"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1018, 538)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.tabDocGroups
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1018, 538)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'frmExpDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 642)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExpDocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crew Expiring Documents"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.documentEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.tabDocGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDocGroups.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents tabDocGroups As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colIDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocGrp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDoc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateIssue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateExpiry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents docFilter As DevExpress.XtraBars.BarEditItem
    Friend WithEvents documentEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents genericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colFKeyDoc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkExpiring As DevExpress.XtraBars.BarEditItem
    Friend WithEvents chkEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents chkExpired As DevExpress.XtraBars.BarEditItem
    Friend WithEvents chkEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btnApply As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnGotoDocs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarCheckItem1 As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarButtonGroup1 As DevExpress.XtraBars.BarButtonGroup
    Friend WithEvents cmdPreviewReport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdPreviewReportAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents chkExpDocAlert As DevExpress.XtraBars.BarEditItem
    Friend WithEvents chkEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents colRemarks As DevExpress.XtraGrid.Columns.GridColumn
End Class
