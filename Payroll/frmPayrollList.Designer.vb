<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayrollList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayrollList))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.cmdApply = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdClearFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.GovtRcpt = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSave = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdLockUnlockPayroll = New DevExpress.XtraBars.BarButtonItem()
        Me.cboView = New DevExpress.XtraBars.BarEditItem()
        Me.repView = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnSelectMultiple = New DevExpress.XtraBars.BarButtonItem()
        Me.menuLockUnlockMultiple = New DevExpress.XtraBars.PopupMenu()
        Me.btnLockMultiple = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUnlockMultiple = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdCancelLockUnlockMultiple = New DevExpress.XtraBars.BarButtonItem()
        Me.GovtRcptMulti = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgPayFilter = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgGovtRcpt = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgPayLock = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgGREditingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.menuLockUnlockMultiple, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.cmdApply, Me.BarButtonItem2, Me.cmdClearFilter, Me.GovtRcpt, Me.cmdEdit, Me.cmdSave, Me.cmdDelete, Me.cmdLockUnlockPayroll, Me.cboView, Me.btnSelectMultiple, Me.btnLockMultiple, Me.btnUnlockMultiple, Me.cmdCancelLockUnlockMultiple, Me.GovtRcptMulti})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl.MaxItemId = 18
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repView})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(785, 131)
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'cmdApply
        '
        Me.cmdApply.Caption = "Select Payroll"
        Me.cmdApply.Glyph = CType(resources.GetObject("cmdApply.Glyph"), System.Drawing.Image)
        Me.cmdApply.Id = 1
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Cancel"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdClearFilter
        '
        Me.cmdClearFilter.Caption = "Clear Filter"
        Me.cmdClearFilter.Glyph = CType(resources.GetObject("cmdClearFilter.Glyph"), System.Drawing.Image)
        Me.cmdClearFilter.Id = 3
        Me.cmdClearFilter.Name = "cmdClearFilter"
        Me.cmdClearFilter.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'GovtRcpt
        '
        Me.GovtRcpt.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.GovtRcpt.Caption = "Gov't Receipt"
        Me.GovtRcpt.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.GovtRcpt.Glyph = CType(resources.GetObject("GovtRcpt.Glyph"), System.Drawing.Image)
        Me.GovtRcpt.Id = 4
        Me.GovtRcpt.Name = "GovtRcpt"
        Me.GovtRcpt.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdEdit
        '
        Me.cmdEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.cmdEdit.Caption = "Edit"
        Me.cmdEdit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdEdit.Glyph = CType(resources.GetObject("cmdEdit.Glyph"), System.Drawing.Image)
        Me.cmdEdit.Id = 6
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdSave
        '
        Me.cmdSave.Caption = "Save"
        Me.cmdSave.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdSave.Glyph = CType(resources.GetObject("cmdSave.Glyph"), System.Drawing.Image)
        Me.cmdSave.Id = 7
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdDelete
        '
        Me.cmdDelete.Caption = "Delete"
        Me.cmdDelete.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdDelete.Glyph = CType(resources.GetObject("cmdDelete.Glyph"), System.Drawing.Image)
        Me.cmdDelete.Id = 8
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cmdLockUnlockPayroll
        '
        Me.cmdLockUnlockPayroll.Caption = "Lock / Unlock Payroll"
        Me.cmdLockUnlockPayroll.Glyph = CType(resources.GetObject("cmdLockUnlockPayroll.Glyph"), System.Drawing.Image)
        Me.cmdLockUnlockPayroll.Id = 10
        Me.cmdLockUnlockPayroll.Name = "cmdLockUnlockPayroll"
        Me.cmdLockUnlockPayroll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'cboView
        '
        Me.cboView.Caption = "Show:"
        Me.cboView.Edit = Me.repView
        Me.cboView.EditValue = ""
        Me.cboView.Id = 11
        Me.cboView.Name = "cboView"
        Me.cboView.Width = 120
        '
        'repView
        '
        Me.repView.AutoHeight = False
        Me.repView.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repView.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repView.DisplayMember = "Name"
        Me.repView.Name = "repView"
        Me.repView.NullText = ""
        Me.repView.ShowFooter = False
        Me.repView.ShowHeader = False
        Me.repView.ValueMember = "PKey"
        '
        'btnSelectMultiple
        '
        Me.btnSelectMultiple.ActAsDropDown = True
        Me.btnSelectMultiple.AllowAllUp = True
        Me.btnSelectMultiple.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.CheckDropDown
        Me.btnSelectMultiple.Caption = "Select Multiple"
        Me.btnSelectMultiple.DropDownControl = Me.menuLockUnlockMultiple
        Me.btnSelectMultiple.Glyph = CType(resources.GetObject("btnSelectMultiple.Glyph"), System.Drawing.Image)
        Me.btnSelectMultiple.Id = 12
        Me.btnSelectMultiple.Name = "btnSelectMultiple"
        Me.btnSelectMultiple.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'menuLockUnlockMultiple
        '
        Me.menuLockUnlockMultiple.ItemLinks.Add(Me.btnLockMultiple)
        Me.menuLockUnlockMultiple.ItemLinks.Add(Me.btnUnlockMultiple)
        Me.menuLockUnlockMultiple.Name = "menuLockUnlockMultiple"
        Me.menuLockUnlockMultiple.Ribbon = Me.RibbonControl
        '
        'btnLockMultiple
        '
        Me.btnLockMultiple.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnLockMultiple.Caption = "Lock Multiple"
        Me.btnLockMultiple.Glyph = Global.Payroll.My.Resources.Resources.Lock_24x24
        Me.btnLockMultiple.GroupIndex = 10
        Me.btnLockMultiple.Id = 13
        Me.btnLockMultiple.Name = "btnLockMultiple"
        '
        'btnUnlockMultiple
        '
        Me.btnUnlockMultiple.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnUnlockMultiple.Caption = "Unlock Multiple"
        Me.btnUnlockMultiple.Glyph = Global.Payroll.My.Resources.Resources.Unlock24x24
        Me.btnUnlockMultiple.GroupIndex = 10
        Me.btnUnlockMultiple.Id = 14
        Me.btnUnlockMultiple.Name = "btnUnlockMultiple"
        '
        'cmdCancelLockUnlockMultiple
        '
        Me.cmdCancelLockUnlockMultiple.Caption = "Cancel"
        Me.cmdCancelLockUnlockMultiple.Glyph = CType(resources.GetObject("cmdCancelLockUnlockMultiple.Glyph"), System.Drawing.Image)
        Me.cmdCancelLockUnlockMultiple.Id = 15
        Me.cmdCancelLockUnlockMultiple.Name = "cmdCancelLockUnlockMultiple"
        Me.cmdCancelLockUnlockMultiple.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'GovtRcptMulti
        '
        Me.GovtRcptMulti.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.GovtRcptMulti.Caption = "Select Multiple"
        Me.GovtRcptMulti.Glyph = CType(resources.GetObject("GovtRcptMulti.Glyph"), System.Drawing.Image)
        Me.GovtRcptMulti.Id = 16
        Me.GovtRcptMulti.Name = "GovtRcptMulti"
        Me.GovtRcptMulti.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgPayFilter, Me.rpgGovtRcpt, Me.rpgPayLock, Me.rpgGREditingOptions})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'rpgPayFilter
        '
        Me.rpgPayFilter.ItemLinks.Add(Me.cmdApply)
        Me.rpgPayFilter.ItemLinks.Add(Me.cmdClearFilter)
        Me.rpgPayFilter.ItemLinks.Add(Me.cboView)
        Me.rpgPayFilter.Name = "rpgPayFilter"
        Me.rpgPayFilter.Text = "Filter"
        '
        'rpgGovtRcpt
        '
        Me.rpgGovtRcpt.ItemLinks.Add(Me.GovtRcpt)
        Me.rpgGovtRcpt.ItemLinks.Add(Me.GovtRcptMulti)
        Me.rpgGovtRcpt.Name = "rpgGovtRcpt"
        '
        'rpgPayLock
        '
        Me.rpgPayLock.ItemLinks.Add(Me.cmdLockUnlockPayroll)
        Me.rpgPayLock.ItemLinks.Add(Me.btnSelectMultiple)
        Me.rpgPayLock.ItemLinks.Add(Me.cmdCancelLockUnlockMultiple)
        Me.rpgPayLock.Name = "rpgPayLock"
        Me.rpgPayLock.Text = " "
        '
        'rpgGREditingOptions
        '
        Me.rpgGREditingOptions.ItemLinks.Add(Me.cmdEdit)
        Me.rpgGREditingOptions.ItemLinks.Add(Me.cmdSave)
        Me.rpgGREditingOptions.ItemLinks.Add(Me.cmdDelete)
        Me.rpgGREditingOptions.Name = "rpgGREditingOptions"
        Me.rpgGREditingOptions.Text = "Editing Options"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 131)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.AutoScroll = True
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.header)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(785, 670)
        Me.SplitContainerControl1.SplitterPosition = 94
        Me.SplitContainerControl1.TabIndex = 8
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        Me.SplitContainerControl1.UseDisabledStatePainter = False
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.MainGrid)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(785, 554)
        Me.header.TabIndex = 1
        Me.header.Text = "Payroll List"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainGrid.Location = New System.Drawing.Point(2, 26)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainGrid.MenuManager = Me.RibbonControl
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(781, 526)
        Me.MainGrid.TabIndex = 0
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PKey"
        Me.GridColumn1.FieldName = "PKey"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "MCode"
        Me.GridColumn2.FieldName = "MCode"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Date Created"
        Me.GridColumn3.FieldName = "DateCreated"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Width = 264
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Ref No."
        Me.GridColumn4.FieldName = "RefNo"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 178
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "FKeyPrincipal"
        Me.GridColumn5.FieldName = "FKeyPrincipal"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "PrinName"
        Me.GridColumn6.FieldName = "PrinName"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "FKeyVsl"
        Me.GridColumn7.FieldName = "FKeyVsl"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "VslName"
        Me.GridColumn8.FieldName = "VslName"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Paytype"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "RefCurr"
        Me.GridColumn10.FieldName = "RefCurr"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Principal"
        Me.GridColumn11.FieldName = "AdmPrinName"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        Me.GridColumn11.Width = 330
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Vessel"
        Me.GridColumn12.FieldName = "AdmVslName"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        Me.GridColumn12.Width = 317
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Period"
        Me.GridColumn13.FieldName = "Period"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 174
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "VslRef"
        Me.GridColumn14.FieldName = "VslRef"
        Me.GridColumn14.Name = "GridColumn14"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Date Created"
        Me.GridColumn15.FieldName = "strDateCreated"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 2
        Me.GridColumn15.Width = 153
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "isLocked"
        Me.GridColumn16.FieldName = "isLocked"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'frmPayrollList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 801)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.RibbonControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmPayrollList"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Processed Payroll List"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.menuLockUnlockMultiple, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgPayFilter As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdApply As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdClearFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GovtRcpt As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgGovtRcpt As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgGREditingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgPayLock As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdLockUnlockPayroll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cboView As DevExpress.XtraBars.BarEditItem
    Friend WithEvents repView As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnSelectMultiple As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLockMultiple As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUnlockMultiple As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents menuLockUnlockMultiple As DevExpress.XtraBars.PopupMenu
    Friend WithEvents cmdCancelLockUnlockMultiple As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GovtRcptMulti As DevExpress.XtraBars.BarButtonItem


End Class
