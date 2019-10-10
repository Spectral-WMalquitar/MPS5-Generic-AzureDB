<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocViewer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocViewer))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnClear2 = New DevExpress.XtraEditors.LabelControl()
        Me.gcCrewList = New DevExpress.XtraGrid.GridControl()
        Me.gvCrewList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsSelected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.COIDNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.xCrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.crewSelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.dteTo = New DevExpress.XtraEditors.DateEdit()
        Me.dtefrom = New DevExpress.XtraEditors.DateEdit()
        Me.btnClearSelection = New DevExpress.XtraEditors.LabelControl()
        Me.luDoc = New DevExpress.XtraEditors.LookUpEdit()
        Me.luDocGrp = New DevExpress.XtraEditors.LookUpEdit()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.clmCrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmDocType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmDateIssue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.genericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.clmDateExpiry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmHasFile = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dtefromLay = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dteToLay = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitContainerControl3 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.previewPdf = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.supportingDocsGC = New DevExpress.XtraGrid.GridControl()
        Me.supportingDocs = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.clmPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmFileName = New DevExpress.XtraGrid.Columns.GridColumn()
        'Me.SplashScreenManager2 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.DocumentViewer.DMS_Waitform), True, True, DevExpress.XtraSplashScreen.ParentType.UserControl)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.gcCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.crewSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.dteTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtefrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtefrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luDoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luDocGrp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtefromLay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteToLay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl3.SuspendLayout()
        CType(Me.supportingDocsGC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.supportingDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LayoutControl3)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1112, 579)
        Me.SplitContainerControl1.SplitterPosition = 330
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.btnClear2)
        Me.LayoutControl3.Controls.Add(Me.gcCrewList)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1201, 275, 533, 586)
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl3.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl3.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl3.Root = Me.LayoutControlGroup4
        Me.LayoutControl3.Size = New System.Drawing.Size(330, 579)
        Me.LayoutControl3.TabIndex = 1
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'btnClear2
        '
        Me.btnClear2.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear2.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.btnClear2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear2.Location = New System.Drawing.Point(220, 38)
        Me.btnClear2.Name = "btnClear2"
        Me.btnClear2.Size = New System.Drawing.Size(96, 16)
        Me.btnClear2.StyleController = Me.LayoutControl3
        Me.btnClear2.TabIndex = 6
        Me.btnClear2.Text = "Clear Selection"
        '
        'gcCrewList
        '
        Me.gcCrewList.Location = New System.Drawing.Point(14, 58)
        Me.gcCrewList.MainView = Me.gvCrewList
        Me.gcCrewList.Name = "gcCrewList"
        Me.gcCrewList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.crewSelect})
        Me.gcCrewList.Size = New System.Drawing.Size(302, 507)
        Me.gcCrewList.TabIndex = 0
        Me.gcCrewList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCrewList})
        '
        'gvCrewList
        '
        Me.gvCrewList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDNbr, Me.FName, Me.IsSelected, Me.LName, Me.MName, Me.COIDNo, Me.xCrewName, Me.RankName, Me.GridColumn1})
        Me.gvCrewList.GridControl = Me.gcCrewList
        Me.gvCrewList.Name = "gvCrewList"
        Me.gvCrewList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvCrewList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvCrewList.OptionsBehavior.AutoPopulateColumns = False
        Me.gvCrewList.OptionsBehavior.AutoSelectAllInEditor = False
        Me.gvCrewList.OptionsCustomization.AllowGroup = False
        Me.gvCrewList.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvCrewList.OptionsFind.AlwaysVisible = True
        Me.gvCrewList.OptionsFind.FindDelay = 100
        Me.gvCrewList.OptionsHint.ShowFooterHints = False
        Me.gvCrewList.OptionsMenu.ShowAutoFilterRowItem = False
        Me.gvCrewList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvCrewList.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.gvCrewList.OptionsSelection.EnableAppearanceHideSelection = False
        Me.gvCrewList.OptionsSelection.UseIndicatorForSelection = False
        Me.gvCrewList.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.gvCrewList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gvCrewList.OptionsView.ShowGroupPanel = False
        '
        'IDNbr
        '
        Me.IDNbr.Caption = "GridColumn1"
        Me.IDNbr.FieldName = "IDNbr"
        Me.IDNbr.Name = "IDNbr"
        Me.IDNbr.OptionsColumn.ShowInCustomizationForm = False
        '
        'FName
        '
        Me.FName.Caption = "Firstname"
        Me.FName.FieldName = "FName"
        Me.FName.Name = "FName"
        Me.FName.OptionsColumn.AllowEdit = False
        Me.FName.OptionsColumn.ReadOnly = True
        Me.FName.Visible = True
        Me.FName.VisibleIndex = 1
        Me.FName.Width = 219
        '
        'IsSelected
        '
        Me.IsSelected.Caption = "   "
        Me.IsSelected.FieldName = "IsSelected"
        Me.IsSelected.Name = "IsSelected"
        Me.IsSelected.OptionsColumn.ShowCaption = False
        Me.IsSelected.Visible = True
        Me.IsSelected.VisibleIndex = 5
        Me.IsSelected.Width = 73
        '
        'LName
        '
        Me.LName.Caption = "Lastname"
        Me.LName.FieldName = "LName"
        Me.LName.Name = "LName"
        Me.LName.OptionsColumn.AllowEdit = False
        Me.LName.OptionsColumn.ReadOnly = True
        Me.LName.Visible = True
        Me.LName.VisibleIndex = 0
        Me.LName.Width = 258
        '
        'MName
        '
        Me.MName.Caption = "Middlename"
        Me.MName.FieldName = "MName"
        Me.MName.Name = "MName"
        Me.MName.OptionsColumn.AllowEdit = False
        Me.MName.OptionsColumn.ReadOnly = True
        Me.MName.Visible = True
        Me.MName.VisibleIndex = 2
        Me.MName.Width = 154
        '
        'COIDNo
        '
        Me.COIDNo.Caption = "Company ID"
        Me.COIDNo.FieldName = "COIDNo"
        Me.COIDNo.Name = "COIDNo"
        Me.COIDNo.OptionsColumn.AllowEdit = False
        Me.COIDNo.OptionsColumn.ReadOnly = True
        Me.COIDNo.Visible = True
        Me.COIDNo.VisibleIndex = 3
        Me.COIDNo.Width = 128
        '
        'xCrewName
        '
        Me.xCrewName.Caption = "GridColumn1"
        Me.xCrewName.FieldName = "CrewName"
        Me.xCrewName.Name = "xCrewName"
        Me.xCrewName.OptionsColumn.ShowInCustomizationForm = False
        '
        'RankName
        '
        Me.RankName.Caption = "Rank"
        Me.RankName.FieldName = "RankName"
        Me.RankName.Name = "RankName"
        Me.RankName.OptionsColumn.AllowEdit = False
        Me.RankName.OptionsColumn.ReadOnly = True
        Me.RankName.Visible = True
        Me.RankName.VisibleIndex = 4
        Me.RankName.Width = 212
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "RankSortCode"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ShowInCustomizationForm = False
        '
        'crewSelect
        '
        Me.crewSelect.AutoHeight = False
        Me.crewSelect.Name = "crewSelect"
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup5})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "Root"
        Me.LayoutControlGroup4.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(330, 579)
        Me.LayoutControlGroup4.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.gcCrewList
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 20)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(306, 511)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnClear2
        Me.LayoutControlItem7.Location = New System.Drawing.Point(206, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(206, 20)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.LayoutControl2)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SplitContainerControl3)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(777, 579)
        Me.SplitContainerControl2.SplitterPosition = 381
        Me.SplitContainerControl2.TabIndex = 2
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.btnClearFilter)
        Me.LayoutControl2.Controls.Add(Me.dteTo)
        Me.LayoutControl2.Controls.Add(Me.dtefrom)
        Me.LayoutControl2.Controls.Add(Me.btnClearSelection)
        Me.LayoutControl2.Controls.Add(Me.luDoc)
        Me.LayoutControl2.Controls.Add(Me.luDocGrp)
        Me.LayoutControl2.Controls.Add(Me.Maingrid)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(788, 265, 543, 350)
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
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        Me.LayoutControl2.Size = New System.Drawing.Size(381, 579)
        Me.LayoutControl2.TabIndex = 1
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Location = New System.Drawing.Point(192, 142)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(175, 23)
        Me.btnClearFilter.TabIndex = 9
        Me.btnClearFilter.Text = "Clear Filter"
        Me.btnClearFilter.UseVisualStyleBackColor = True
        '
        'dteTo
        '
        Me.dteTo.EditValue = Nothing
        Me.dteTo.Location = New System.Drawing.Point(117, 116)
        Me.dteTo.Name = "dteTo"
        Me.dteTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.dteTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteTo.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.dteTo.Properties.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.dteTo.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.dteTo.Size = New System.Drawing.Size(250, 22)
        Me.dteTo.StyleController = Me.LayoutControl2
        Me.dteTo.TabIndex = 8
        '
        'dtefrom
        '
        Me.dtefrom.EditValue = Nothing
        Me.dtefrom.Location = New System.Drawing.Point(117, 90)
        Me.dtefrom.Name = "dtefrom"
        Me.dtefrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.dtefrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtefrom.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.dtefrom.Properties.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.dtefrom.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.dtefrom.Size = New System.Drawing.Size(250, 22)
        Me.dtefrom.StyleController = Me.LayoutControl2
        Me.dtefrom.TabIndex = 7
        '
        'btnClearSelection
        '
        Me.btnClearSelection.Appearance.Font = New System.Drawing.Font("Tahoma", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSelection.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.btnClearSelection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSelection.Location = New System.Drawing.Point(271, 217)
        Me.btnClearSelection.Name = "btnClearSelection"
        Me.btnClearSelection.Size = New System.Drawing.Size(96, 16)
        Me.btnClearSelection.StyleController = Me.LayoutControl2
        Me.btnClearSelection.TabIndex = 6
        Me.btnClearSelection.Text = "Clear Selection"
        '
        'luDoc
        '
        Me.luDoc.Location = New System.Drawing.Point(117, 64)
        Me.luDoc.Name = "luDoc"
        Me.luDoc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.luDoc.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.luDoc.Properties.DisplayMember = "Name"
        Me.luDoc.Properties.NullText = ""
        Me.luDoc.Properties.ShowFooter = False
        Me.luDoc.Properties.ShowHeader = False
        Me.luDoc.Properties.ValueMember = "PKey"
        Me.luDoc.Size = New System.Drawing.Size(250, 22)
        Me.luDoc.StyleController = Me.LayoutControl2
        Me.luDoc.TabIndex = 5
        '
        'luDocGrp
        '
        Me.luDocGrp.Location = New System.Drawing.Point(117, 38)
        Me.luDocGrp.Name = "luDocGrp"
        Me.luDocGrp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("luDocGrp.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.luDocGrp.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.luDocGrp.Properties.DisplayMember = "Name"
        Me.luDocGrp.Properties.NullText = ""
        Me.luDocGrp.Properties.ShowFooter = False
        Me.luDocGrp.Properties.ShowHeader = False
        Me.luDocGrp.Properties.ValueMember = "PKey"
        Me.luDocGrp.Size = New System.Drawing.Size(250, 22)
        Me.luDocGrp.StyleController = Me.LayoutControl2
        Me.luDocGrp.TabIndex = 4
        '
        'Maingrid
        '
        Me.Maingrid.Location = New System.Drawing.Point(14, 237)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.genericDateEdit})
        Me.Maingrid.Size = New System.Drawing.Size(353, 328)
        Me.Maingrid.TabIndex = 0
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.clmCrewName, Me.clmDocType, Me.clmNumber, Me.clmDateIssue, Me.clmDateExpiry, Me.clmHasFile, Me.clmSelect})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsBehavior.AutoExpandAllGroups = True
        Me.Mainview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'clmCrewName
        '
        Me.clmCrewName.Caption = " "
        Me.clmCrewName.FieldName = "CrewName"
        Me.clmCrewName.Name = "clmCrewName"
        Me.clmCrewName.Visible = True
        Me.clmCrewName.VisibleIndex = 0
        '
        'clmDocType
        '
        Me.clmDocType.Caption = "Document"
        Me.clmDocType.FieldName = "DocType"
        Me.clmDocType.Name = "clmDocType"
        Me.clmDocType.OptionsColumn.AllowEdit = False
        Me.clmDocType.OptionsColumn.ReadOnly = True
        Me.clmDocType.Visible = True
        Me.clmDocType.VisibleIndex = 1
        '
        'clmNumber
        '
        Me.clmNumber.Caption = "Number"
        Me.clmNumber.FieldName = "Number"
        Me.clmNumber.Name = "clmNumber"
        Me.clmNumber.OptionsColumn.AllowEdit = False
        Me.clmNumber.OptionsColumn.ReadOnly = True
        Me.clmNumber.Visible = True
        Me.clmNumber.VisibleIndex = 2
        '
        'clmDateIssue
        '
        Me.clmDateIssue.Caption = "Date Issue"
        Me.clmDateIssue.ColumnEdit = Me.genericDateEdit
        Me.clmDateIssue.FieldName = "DateIssue"
        Me.clmDateIssue.Name = "clmDateIssue"
        Me.clmDateIssue.OptionsColumn.AllowEdit = False
        Me.clmDateIssue.OptionsColumn.ReadOnly = True
        Me.clmDateIssue.Visible = True
        Me.clmDateIssue.VisibleIndex = 3
        '
        'genericDateEdit
        '
        Me.genericDateEdit.AutoHeight = False
        Me.genericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.Name = "genericDateEdit"
        '
        'clmDateExpiry
        '
        Me.clmDateExpiry.Caption = "Date Expiry"
        Me.clmDateExpiry.ColumnEdit = Me.genericDateEdit
        Me.clmDateExpiry.FieldName = "DateExpiry"
        Me.clmDateExpiry.Name = "clmDateExpiry"
        Me.clmDateExpiry.OptionsColumn.AllowEdit = False
        Me.clmDateExpiry.OptionsColumn.ReadOnly = True
        Me.clmDateExpiry.Visible = True
        Me.clmDateExpiry.VisibleIndex = 4
        '
        'clmHasFile
        '
        Me.clmHasFile.Caption = "Linked"
        Me.clmHasFile.FieldName = "hasFile"
        Me.clmHasFile.Name = "clmHasFile"
        Me.clmHasFile.OptionsColumn.AllowEdit = False
        '
        'clmSelect
        '
        Me.clmSelect.Caption = "Select"
        Me.clmSelect.FieldName = "IsSelected"
        Me.clmSelect.Name = "clmSelect"
        Me.clmSelect.Visible = True
        Me.clmSelect.VisibleIndex = 5
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3, Me.LayoutControlGroup6})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(381, 579)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Maingrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 20)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(357, 332)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.dtefromLay, Me.dteToLay, Me.LayoutControlItem8, Me.EmptySpaceItem3, Me.LayoutControlItem3})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(381, 179)
        Me.LayoutControlGroup3.Text = "Document Filter"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.luDoc
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(357, 26)
        Me.LayoutControlItem4.Text = "Document:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(100, 16)
        '
        'dtefromLay
        '
        Me.dtefromLay.Control = Me.dtefrom
        Me.dtefromLay.Location = New System.Drawing.Point(0, 52)
        Me.dtefromLay.Name = "dtefromLay"
        Me.dtefromLay.Size = New System.Drawing.Size(357, 26)
        Me.dtefromLay.Text = "Date Issue from:"
        Me.dtefromLay.TextSize = New System.Drawing.Size(100, 16)
        '
        'dteToLay
        '
        Me.dteToLay.Control = Me.dteTo
        Me.dteToLay.Location = New System.Drawing.Point(0, 78)
        Me.dteToLay.Name = "dteToLay"
        Me.dteToLay.Size = New System.Drawing.Size(357, 26)
        Me.dteToLay.Text = "Date Issue to:"
        Me.dteToLay.TextSize = New System.Drawing.Size(100, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnClearFilter
        Me.LayoutControlItem8.Location = New System.Drawing.Point(178, 104)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(179, 27)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(179, 27)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(179, 27)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 104)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(178, 27)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.luDocGrp
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(357, 26)
        Me.LayoutControlItem3.Text = "Document Group:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(100, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(257, 20)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnClearSelection
        Me.LayoutControlItem5.Location = New System.Drawing.Point(257, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(100, 20)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'SplitContainerControl3
        '
        Me.SplitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl3.Horizontal = False
        Me.SplitContainerControl3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl3.Name = "SplitContainerControl3"
        Me.SplitContainerControl3.Panel1.Controls.Add(Me.previewPdf)
        Me.SplitContainerControl3.Panel1.Text = "Panel1"
        Me.SplitContainerControl3.Panel2.Controls.Add(Me.supportingDocsGC)
        Me.SplitContainerControl3.Panel2.Text = "Panel2"
        Me.SplitContainerControl3.Size = New System.Drawing.Size(391, 579)
        Me.SplitContainerControl3.SplitterPosition = 399
        Me.SplitContainerControl3.TabIndex = 1
        Me.SplitContainerControl3.Text = "SplitContainerControl3"
        '
        'previewPdf
        '
        Me.previewPdf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.previewPdf.Location = New System.Drawing.Point(0, 0)
        Me.previewPdf.Name = "previewPdf"
        Me.previewPdf.ReadOnly = True
        Me.previewPdf.Size = New System.Drawing.Size(391, 399)
        Me.previewPdf.TabIndex = 0
        Me.previewPdf.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible
        '
        'supportingDocsGC
        '
        Me.supportingDocsGC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.supportingDocsGC.Location = New System.Drawing.Point(0, 0)
        Me.supportingDocsGC.MainView = Me.supportingDocs
        Me.supportingDocsGC.Name = "supportingDocsGC"
        Me.supportingDocsGC.Size = New System.Drawing.Size(391, 175)
        Me.supportingDocsGC.TabIndex = 0
        Me.supportingDocsGC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.supportingDocs})
        '
        'supportingDocs
        '
        Me.supportingDocs.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.clmPKey, Me.clmDesc, Me.clmFileName})
        Me.supportingDocs.GridControl = Me.supportingDocsGC
        Me.supportingDocs.Name = "supportingDocs"
        Me.supportingDocs.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.supportingDocs.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.supportingDocs.OptionsBehavior.Editable = False
        Me.supportingDocs.OptionsBehavior.ReadOnly = True
        Me.supportingDocs.OptionsCustomization.AllowColumnMoving = False
        Me.supportingDocs.OptionsCustomization.AllowFilter = False
        Me.supportingDocs.OptionsCustomization.AllowGroup = False
        Me.supportingDocs.OptionsCustomization.AllowQuickHideColumns = False
        Me.supportingDocs.OptionsCustomization.AllowSort = False
        Me.supportingDocs.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.supportingDocs.OptionsView.ShowGroupPanel = False
        '
        'clmPKey
        '
        Me.clmPKey.FieldName = "PKey"
        Me.clmPKey.Name = "clmPKey"
        '
        'clmDesc
        '
        Me.clmDesc.Caption = "Description"
        Me.clmDesc.FieldName = "Description"
        Me.clmDesc.Name = "clmDesc"
        Me.clmDesc.Visible = True
        Me.clmDesc.VisibleIndex = 0
        '
        'clmFileName
        '
        Me.clmFileName.Caption = "FileName"
        Me.clmFileName.FieldName = "FilePath"
        Me.clmFileName.Name = "clmFileName"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SplitContainerControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(1116, 583)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1116, 583)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SplitContainerControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1116, 583)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup5.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem6, Me.EmptySpaceItem2})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(330, 579)
        Me.LayoutControlGroup5.Text = "Crew List"
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup6.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.EmptySpaceItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 179)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(381, 400)
        Me.LayoutControlGroup6.Text = "Documents List"
        '
        'DocViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "DocViewer"
        Me.Size = New System.Drawing.Size(1116, 583)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.gcCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.crewSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.dteTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtefrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtefrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luDoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luDocGrp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtefromLay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteToLay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl3.ResumeLayout(False)
        CType(Me.supportingDocsGC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.supportingDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPanel As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents WinExplorerView1 As DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents gcCrewList As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCrewList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents crewSelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents IDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsSelected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents COIDNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents xCrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    'Friend WithEvents SplashScreenManager2 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents clmCrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmDocType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmDateIssue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmDateExpiry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmHasFile As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents genericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents clmSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents previewPdf As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents luDocGrp As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents luDoc As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainerControl3 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents supportingDocsGC As DevExpress.XtraGrid.GridControl
    Friend WithEvents supportingDocs As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents clmPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmFileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents btnClearSelection As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnClear2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents dteTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtefrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtefromLay As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dteToLay As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnClearFilter As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup


End Class
