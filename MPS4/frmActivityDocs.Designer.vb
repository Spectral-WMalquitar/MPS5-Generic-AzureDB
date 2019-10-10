<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivityDocs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActivityDocs))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.cmdEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdSave = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdView = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgEditOption = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.gridImages = New DevExpress.XtraGrid.GridControl()
        Me.viewImages = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repBtnBrowse = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layMainGrid = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBtnBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layMainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.cmdEdit, Me.cmdSave, Me.cmdDelete, Me.cmdView})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 11
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowQatLocationSelector = False
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(627, 121)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        '
        'cmdEdit
        '
        Me.cmdEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.cmdEdit.Caption = "Add/Edit"
        Me.cmdEdit.Glyph = CType(resources.GetObject("cmdEdit.Glyph"), System.Drawing.Image)
        Me.cmdEdit.Id = 1
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdSave
        '
        Me.cmdSave.Caption = "Save"
        Me.cmdSave.Glyph = CType(resources.GetObject("cmdSave.Glyph"), System.Drawing.Image)
        Me.cmdSave.Id = 3
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdDelete
        '
        Me.cmdDelete.Caption = "Delete"
        Me.cmdDelete.Glyph = CType(resources.GetObject("cmdDelete.Glyph"), System.Drawing.Image)
        Me.cmdDelete.Id = 6
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'cmdView
        '
        Me.cmdView.Caption = "View Attachment"
        Me.cmdView.Id = 7
        Me.cmdView.LargeGlyph = CType(resources.GetObject("cmdView.LargeGlyph"), System.Drawing.Image)
        Me.cmdView.Name = "cmdView"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgEditOption, Me.RibbonPageGroup2})
        Me.RibbonPage1.MergeOrder = 0
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'rpgEditOption
        '
        Me.rpgEditOption.ItemLinks.Add(Me.cmdEdit)
        Me.rpgEditOption.ItemLinks.Add(Me.cmdSave)
        Me.rpgEditOption.ItemLinks.Add(Me.cmdDelete)
        Me.rpgEditOption.Name = "rpgEditOption"
        Me.rpgEditOption.Text = "Edit Options"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.cmdView)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "View Attachement"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 343)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(627, 27)
        '
        'gridImages
        '
        Me.gridImages.Location = New System.Drawing.Point(2, 21)
        Me.gridImages.MainView = Me.viewImages
        Me.gridImages.MenuManager = Me.RibbonControl1
        Me.gridImages.Name = "gridImages"
        Me.gridImages.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repBtnBrowse})
        Me.gridImages.Size = New System.Drawing.Size(623, 199)
        Me.gridImages.TabIndex = 1
        Me.gridImages.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewImages})
        '
        'viewImages
        '
        Me.viewImages.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.Description, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn4})
        Me.viewImages.GridControl = Me.gridImages
        Me.viewImages.Name = "viewImages"
        Me.viewImages.OptionsCustomization.AllowColumnMoving = False
        Me.viewImages.OptionsMenu.EnableColumnMenu = False
        Me.viewImages.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "DocImgPKey"
        Me.GridColumn1.FieldName = "DocImgPKey"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowShowHide = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ActivityPKey"
        Me.GridColumn2.FieldName = "ActivityPKey"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowShowHide = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "FilePath"
        Me.GridColumn3.FieldName = "FilePath"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowShowHide = False
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.ColumnEdit = Me.repBtnBrowse
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 0
        '
        'repBtnBrowse
        '
        Me.repBtnBrowse.AutoHeight = False
        Me.repBtnBrowse.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Browse", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.repBtnBrowse.Name = "repBtnBrowse"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Edited"
        Me.GridColumn5.FieldName = "Edited"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowShowHide = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "FKeyDocument"
        Me.GridColumn6.FieldName = "FKeyDocument"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowShowHide = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "FPathEdited"
        Me.GridColumn7.FieldName = "FPathEdited"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowShowHide = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "VslName"
        Me.GridColumn4.FieldName = "VslName"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.gridImages)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 121)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(592, 60, 250, 350)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(627, 222)
        Me.LayoutControl1.TabIndex = 3
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layMainGrid})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(627, 222)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'layMainGrid
        '
        Me.layMainGrid.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.layMainGrid.AppearanceItemCaption.Options.UseFont = True
        Me.layMainGrid.Control = Me.gridImages
        Me.layMainGrid.Location = New System.Drawing.Point(0, 0)
        Me.layMainGrid.MinSize = New System.Drawing.Size(104, 41)
        Me.layMainGrid.Name = "layMainGrid"
        Me.layMainGrid.Size = New System.Drawing.Size(627, 222)
        Me.layMainGrid.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layMainGrid.TextLocation = DevExpress.Utils.Locations.Top
        Me.layMainGrid.TextSize = New System.Drawing.Size(74, 16)
        '
        'frmActivityDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 370)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActivityDocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activity Documents"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBtnBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layMainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgEditOption As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents gridImages As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewImages As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repBtnBrowse As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents layMainGrid As DevExpress.XtraLayout.LayoutControlItem
End Class
