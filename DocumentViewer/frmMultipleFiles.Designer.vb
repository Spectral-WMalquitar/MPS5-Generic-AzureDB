<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMultipleFiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMultipleFiles))
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.clmDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.lblCrewName = New DevExpress.XtraBars.BarStaticItem()
        Me.btnSaveFile = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemoveFile = New DevExpress.XtraBars.BarButtonItem()
        Me.lblDocument = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Maingrid
        '
        Me.Maingrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Maingrid.Location = New System.Drawing.Point(0, 131)
        Me.Maingrid.MainView = Me.MainView
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.Size = New System.Drawing.Size(764, 219)
        Me.Maingrid.TabIndex = 0
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.clmDesc, Me.clmSource, Me.clm})
        Me.MainView.GridControl = Me.Maingrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFilter.AllowFilterEditor = False
        Me.MainView.OptionsMenu.ShowAutoFilterRowItem = False
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'clmDesc
        '
        Me.clmDesc.Caption = "Description"
        Me.clmDesc.FieldName = "Description"
        Me.clmDesc.Name = "clmDesc"
        Me.clmDesc.Visible = True
        Me.clmDesc.VisibleIndex = 0
        '
        'clmSource
        '
        Me.clmSource.Caption = "Source"
        Me.clmSource.FieldName = "Source"
        Me.clmSource.Name = "clmSource"
        Me.clmSource.OptionsColumn.AllowEdit = False
        Me.clmSource.OptionsColumn.ReadOnly = True
        Me.clmSource.Visible = True
        Me.clmSource.VisibleIndex = 1
        '
        'clm
        '
        Me.clm.Caption = "FileName"
        Me.clm.FieldName = "FileName"
        Me.clm.Name = "clm"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.lblCrewName, Me.btnSaveFile, Me.btnRemoveFile, Me.lblDocument})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 7
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowQatLocationSelector = False
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(764, 131)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        '
        'lblCrewName
        '
        Me.lblCrewName.Caption = "CrewName"
        Me.lblCrewName.Id = 2
        Me.lblCrewName.ItemAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrewName.ItemAppearance.Normal.Options.UseFont = True
        Me.lblCrewName.Name = "lblCrewName"
        Me.lblCrewName.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'btnSaveFile
        '
        Me.btnSaveFile.Caption = "Save Files"
        Me.btnSaveFile.Glyph = CType(resources.GetObject("btnSaveFile.Glyph"), System.Drawing.Image)
        Me.btnSaveFile.Id = 4
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'btnRemoveFile
        '
        Me.btnRemoveFile.Caption = "Remove File"
        Me.btnRemoveFile.Glyph = CType(resources.GetObject("btnRemoveFile.Glyph"), System.Drawing.Image)
        Me.btnRemoveFile.Id = 5
        Me.btnRemoveFile.Name = "btnRemoveFile"
        Me.btnRemoveFile.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'lblDocument
        '
        Me.lblDocument.Caption = "Document"
        Me.lblDocument.Id = 6
        Me.lblDocument.Name = "lblDocument"
        Me.lblDocument.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.AllowMinimize = False
        Me.RibbonPageGroup1.ItemLinks.Add(Me.lblCrewName, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.lblDocument)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnSaveFile)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnRemoveFile)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Editing Options"
        '
        'frmMultipleFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 350)
        Me.Controls.Add(Me.Maingrid)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMultipleFiles"
        Me.Ribbon = Me.RibbonControl1
        Me.Text = "DMS - Attach Multiple Files"
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents clmDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents lblCrewName As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnSaveFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemoveFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents lblDocument As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents clm As DevExpress.XtraGrid.Columns.GridColumn
End Class
