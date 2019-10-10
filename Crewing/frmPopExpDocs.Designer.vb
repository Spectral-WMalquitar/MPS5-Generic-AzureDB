<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopExpDocs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPopExpDocs))
        Me.rcPopExpDocs = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnExpDocs = New DevExpress.XtraBars.BarButtonItem()
        Me.btnGoToDocs = New DevExpress.XtraBars.BarButtonItem()
        Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.rcPopExpDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rcPopExpDocs
        '
        Me.rcPopExpDocs.ExpandCollapseItem.Id = 0
        Me.rcPopExpDocs.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.rcPopExpDocs.ExpandCollapseItem, Me.btnExpDocs, Me.btnGoToDocs, Me.btnClose})
        Me.rcPopExpDocs.Location = New System.Drawing.Point(0, 0)
        Me.rcPopExpDocs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rcPopExpDocs.MaxItemId = 6
        Me.rcPopExpDocs.Name = "rcPopExpDocs"
        Me.rcPopExpDocs.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.rcPopExpDocs.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcPopExpDocs.ShowCategoryInCaption = False
        Me.rcPopExpDocs.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcPopExpDocs.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.rcPopExpDocs.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.rcPopExpDocs.ShowQatLocationSelector = False
        Me.rcPopExpDocs.ShowToolbarCustomizeItem = False
        Me.rcPopExpDocs.Size = New System.Drawing.Size(1255, 131)
        Me.rcPopExpDocs.StatusBar = Me.RibbonStatusBar
        Me.rcPopExpDocs.Toolbar.ShowCustomizeItem = False
        '
        'btnExpDocs
        '
        Me.btnExpDocs.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btnExpDocs.Caption = "Exp Docs"
        Me.btnExpDocs.Down = True
        Me.btnExpDocs.Glyph = CType(resources.GetObject("btnExpDocs.Glyph"), System.Drawing.Image)
        Me.btnExpDocs.Id = 1
        Me.btnExpDocs.LargeWidth = 70
        Me.btnExpDocs.Name = "btnExpDocs"
        Me.btnExpDocs.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnGoToDocs
        '
        Me.btnGoToDocs.Caption = "Go to Documents"
        Me.btnGoToDocs.Glyph = CType(resources.GetObject("btnGoToDocs.Glyph"), System.Drawing.Image)
        Me.btnGoToDocs.Id = 2
        Me.btnGoToDocs.LargeWidth = 80
        Me.btnGoToDocs.Name = "btnGoToDocs"
        Me.btnGoToDocs.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnClose
        '
        Me.btnClose.Caption = "Close"
        Me.btnClose.Glyph = CType(resources.GetObject("btnClose.Glyph"), System.Drawing.Image)
        Me.btnClose.Id = 3
        Me.btnClose.LargeWidth = 70
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
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
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnExpDocs)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnGoToDocs, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnClose)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.rcPopExpDocs
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1255, 31)
        '
        'Maingrid
        '
        Me.Maingrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Maingrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Maingrid.Location = New System.Drawing.Point(0, 131)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Maingrid.MenuManager = Me.rcPopExpDocs
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.Size = New System.Drawing.Size(1255, 287)
        Me.Maingrid.TabIndex = 2
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 300
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Document"
        Me.BandedGridColumn4.FieldName = "Name"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Number"
        Me.BandedGridColumn1.FieldName = "Number"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Date Issue"
        Me.BandedGridColumn2.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.BandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn2.FieldName = "DateIssue"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Date Expiry / Date Ended"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn3.FieldName = "DateExpiry"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.FieldName = "hasExpDoc"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowFocus = False
        '
        'frmPopExpDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1255, 449)
        Me.Controls.Add(Me.Maingrid)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.rcPopExpDocs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPopExpDocs"
        Me.Ribbon = Me.rcPopExpDocs
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Expired and Expiring Documents"
        CType(Me.rcPopExpDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rcPopExpDocs As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents btnExpDocs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents btnGoToDocs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand


End Class
