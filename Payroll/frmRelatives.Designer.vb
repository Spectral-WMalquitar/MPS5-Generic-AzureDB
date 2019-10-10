<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatives
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRelatives))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.clmLName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmFName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmMName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmFKeyRel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.relEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmAddr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmPartofCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FKeyCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cityEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmFKeyProvince = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.stateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmFKeyCntry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cntryEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmPhone = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmTelefax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.relEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cityEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cntryEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.AllowMinimizeRibbon = False
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.btnCopy, Me.BarButtonItem1})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowItemCaptionsInPageHeader = True
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages
        Me.RibbonControl1.ShowQatLocationSelector = False
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(1020, 131)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        '
        'btnCopy
        '
        Me.btnCopy.Caption = "Copy Details"
        Me.btnCopy.Glyph = CType(resources.GetObject("btnCopy.Glyph"), System.Drawing.Image)
        Me.btnCopy.Id = 1
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnCopy)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Options"
        '
        'Maingrid
        '
        Me.Maingrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Maingrid.Location = New System.Drawing.Point(0, 131)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.MenuManager = Me.RibbonControl1
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cityEdit, Me.stateEdit, Me.cntryEdit, Me.relEdit})
        Me.Maingrid.Size = New System.Drawing.Size(1020, 277)
        Me.Maingrid.TabIndex = 1
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.clmLName, Me.clmFName, Me.clmMName, Me.clmFKeyRel, Me.clmAddr, Me.clmPartofCity, Me.FKeyCity, Me.clmFKeyProvince, Me.clmFKeyCntry, Me.clmPhone, Me.clmTelefax, Me.clmEmail})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsBehavior.Editable = False
        Me.Mainview.OptionsBehavior.ReadOnly = True
        Me.Mainview.OptionsCustomization.AllowGroup = False
        Me.Mainview.OptionsCustomization.AllowQuickHideColumns = False
        Me.Mainview.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden
        Me.Mainview.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'clmLName
        '
        Me.clmLName.Caption = "Lastname"
        Me.clmLName.FieldName = "LName"
        Me.clmLName.Name = "clmLName"
        Me.clmLName.Visible = True
        Me.clmLName.VisibleIndex = 0
        '
        'clmFName
        '
        Me.clmFName.Caption = "Firstname"
        Me.clmFName.FieldName = "FName"
        Me.clmFName.Name = "clmFName"
        Me.clmFName.Visible = True
        Me.clmFName.VisibleIndex = 1
        '
        'clmMName
        '
        Me.clmMName.Caption = "Middlename"
        Me.clmMName.FieldName = "MName"
        Me.clmMName.Name = "clmMName"
        Me.clmMName.Visible = True
        Me.clmMName.VisibleIndex = 2
        '
        'clmFKeyRel
        '
        Me.clmFKeyRel.Caption = "Relationship"
        Me.clmFKeyRel.ColumnEdit = Me.relEdit
        Me.clmFKeyRel.FieldName = "FKeyRel"
        Me.clmFKeyRel.Name = "clmFKeyRel"
        Me.clmFKeyRel.Visible = True
        Me.clmFKeyRel.VisibleIndex = 3
        '
        'relEdit
        '
        Me.relEdit.AutoHeight = False
        Me.relEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.relEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.relEdit.DisplayMember = "Name"
        Me.relEdit.Name = "relEdit"
        Me.relEdit.NullText = ""
        Me.relEdit.ShowFooter = False
        Me.relEdit.ShowHeader = False
        Me.relEdit.ValueMember = "PKey"
        '
        'clmAddr
        '
        Me.clmAddr.Caption = "St"
        Me.clmAddr.FieldName = "Addr"
        Me.clmAddr.Name = "clmAddr"
        Me.clmAddr.Visible = True
        Me.clmAddr.VisibleIndex = 4
        '
        'clmPartofCity
        '
        Me.clmPartofCity.Caption = "Part of City"
        Me.clmPartofCity.FieldName = "PartofCity"
        Me.clmPartofCity.Name = "clmPartofCity"
        Me.clmPartofCity.Visible = True
        Me.clmPartofCity.VisibleIndex = 5
        '
        'FKeyCity
        '
        Me.FKeyCity.Caption = "City"
        Me.FKeyCity.ColumnEdit = Me.cityEdit
        Me.FKeyCity.FieldName = "FKeyCity"
        Me.FKeyCity.Name = "FKeyCity"
        Me.FKeyCity.Visible = True
        Me.FKeyCity.VisibleIndex = 6
        '
        'cityEdit
        '
        Me.cityEdit.AutoHeight = False
        Me.cityEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cityEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cityEdit.DisplayMember = "Name"
        Me.cityEdit.Name = "cityEdit"
        Me.cityEdit.NullText = ""
        Me.cityEdit.ShowFooter = False
        Me.cityEdit.ShowHeader = False
        Me.cityEdit.ValueMember = "PKey"
        '
        'clmFKeyProvince
        '
        Me.clmFKeyProvince.Caption = "State"
        Me.clmFKeyProvince.ColumnEdit = Me.stateEdit
        Me.clmFKeyProvince.FieldName = "FKeyProvince"
        Me.clmFKeyProvince.Name = "clmFKeyProvince"
        Me.clmFKeyProvince.Visible = True
        Me.clmFKeyProvince.VisibleIndex = 7
        '
        'stateEdit
        '
        Me.stateEdit.AutoHeight = False
        Me.stateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.stateEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey")})
        Me.stateEdit.DisplayMember = "Name"
        Me.stateEdit.Name = "stateEdit"
        Me.stateEdit.NullText = ""
        Me.stateEdit.ShowFooter = False
        Me.stateEdit.ShowHeader = False
        Me.stateEdit.ValueMember = "PKey"
        '
        'clmFKeyCntry
        '
        Me.clmFKeyCntry.Caption = "Country"
        Me.clmFKeyCntry.ColumnEdit = Me.cntryEdit
        Me.clmFKeyCntry.FieldName = "FKeyCntry"
        Me.clmFKeyCntry.Name = "clmFKeyCntry"
        Me.clmFKeyCntry.Visible = True
        Me.clmFKeyCntry.VisibleIndex = 8
        '
        'cntryEdit
        '
        Me.cntryEdit.AutoHeight = False
        Me.cntryEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cntryEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cntryEdit.DisplayMember = "Name"
        Me.cntryEdit.Name = "cntryEdit"
        Me.cntryEdit.NullText = ""
        Me.cntryEdit.ShowFooter = False
        Me.cntryEdit.ShowHeader = False
        Me.cntryEdit.ValueMember = "PKey"
        '
        'clmPhone
        '
        Me.clmPhone.Caption = "Mobile"
        Me.clmPhone.FieldName = "Phone"
        Me.clmPhone.Name = "clmPhone"
        Me.clmPhone.Visible = True
        Me.clmPhone.VisibleIndex = 9
        '
        'clmTelefax
        '
        Me.clmTelefax.Caption = "Telephone"
        Me.clmTelefax.FieldName = "Telefax"
        Me.clmTelefax.Name = "clmTelefax"
        Me.clmTelefax.Visible = True
        Me.clmTelefax.VisibleIndex = 10
        '
        'clmEmail
        '
        Me.clmEmail.Caption = "Email"
        Me.clmEmail.FieldName = "Email"
        Me.clmEmail.Name = "clmEmail"
        Me.clmEmail.Visible = True
        Me.clmEmail.VisibleIndex = 11
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Close"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 2
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'frmRelatives
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 408)
        Me.Controls.Add(Me.Maingrid)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelatives"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crew Relatives"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.relEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cityEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cntryEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents clmLName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmFName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmMName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmAddr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmPartofCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FKeyCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmFKeyProvince As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmFKeyCntry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmPhone As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmTelefax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cityEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents stateEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cntryEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmFKeyRel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents relEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
End Class
