<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocViewer_Bulk
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
        Dim SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocViewer_Bulk))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Document = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Filename = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Valid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.cmdBrowse = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdRemoveAll = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdLink = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.AllowDrop = True
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(2, 24)
        Me.GridControl1.MainView = Me.Mainview
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(720, 275)
        Me.GridControl1.TabIndex = 12
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CrewName, Me.Document, Me.Filename, Me.Remarks, Me.Valid})
        Me.Mainview.GridControl = Me.GridControl1
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsBehavior.AutoPopulateColumns = False
        Me.Mainview.OptionsBehavior.AutoSelectAllInEditor = False
        Me.Mainview.OptionsBehavior.Editable = False
        Me.Mainview.OptionsCustomization.AllowFilter = False
        Me.Mainview.OptionsCustomization.AllowGroup = False
        Me.Mainview.OptionsCustomization.AllowQuickHideColumns = False
        Me.Mainview.OptionsFilter.AllowFilterEditor = False
        Me.Mainview.OptionsFind.AllowFindPanel = False
        Me.Mainview.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.Mainview.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.Mainview.OptionsSelection.EnableAppearanceHideSelection = False
        Me.Mainview.OptionsSelection.UseIndicatorForSelection = False
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'CrewName
        '
        Me.CrewName.Caption = "Crew Name"
        Me.CrewName.FieldName = "CrewName"
        Me.CrewName.Name = "CrewName"
        Me.CrewName.Visible = True
        Me.CrewName.VisibleIndex = 0
        '
        'Document
        '
        Me.Document.Caption = "Document"
        Me.Document.FieldName = "Document"
        Me.Document.Name = "Document"
        Me.Document.Visible = True
        Me.Document.VisibleIndex = 1
        '
        'Filename
        '
        Me.Filename.Caption = "File path"
        Me.Filename.FieldName = "Filename"
        Me.Filename.Name = "Filename"
        Me.Filename.Visible = True
        Me.Filename.VisibleIndex = 2
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 3
        '
        'Valid
        '
        Me.Valid.Caption = "Valid"
        Me.Valid.FieldName = "Valid"
        Me.Valid.Name = "Valid"
        Me.Valid.Visible = True
        Me.Valid.VisibleIndex = 4
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.GridControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(0, 127)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(724, 301)
        Me.GroupControl1.TabIndex = 13
        Me.GroupControl1.Text = "Drop files here."
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.cmdBrowse, Me.cmdRemove, Me.cmdRemoveAll, Me.cmdLink})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowQatLocationSelector = False
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(724, 123)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Caption = "Browse"
        Me.cmdBrowse.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.cmdBrowse.Glyph = CType(resources.GetObject("cmdBrowse.Glyph"), System.Drawing.Image)
        Me.cmdBrowse.Id = 1
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdRemove
        '
        Me.cmdRemove.Caption = "Remove Selected"
        Me.cmdRemove.Glyph = CType(resources.GetObject("cmdRemove.Glyph"), System.Drawing.Image)
        Me.cmdRemove.Id = 2
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdRemoveAll
        '
        Me.cmdRemoveAll.Caption = "Remove Invalid Files"
        Me.cmdRemoveAll.Glyph = CType(resources.GetObject("cmdRemoveAll.Glyph"), System.Drawing.Image)
        Me.cmdRemoveAll.Id = 3
        Me.cmdRemoveAll.Name = "cmdRemoveAll"
        Me.cmdRemoveAll.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdLink
        '
        Me.cmdLink.Caption = "Link"
        Me.cmdLink.Glyph = CType(resources.GetObject("cmdLink.Glyph"), System.Drawing.Image)
        Me.cmdLink.Id = 4
        Me.cmdLink.Name = "cmdLink"
        Me.cmdLink.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
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
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdBrowse)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdLink)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdRemove)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.cmdRemoveAll)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Editing Options"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DocViewer_Bulk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 430)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DocViewer_Bulk"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bulk Link"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Document As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Filename As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Valid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents cmdBrowse As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdRemoveAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdLink As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
