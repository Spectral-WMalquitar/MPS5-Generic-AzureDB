<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrewComments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrewComments))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.CommentGrid = New DevExpress.XtraGrid.GridControl()
        Me.CommentView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.rNIMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rNIMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.btnSave})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonControl1.MaxItemId = 2
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowQatLocationSelector = False
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(744, 131)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        '
        'btnSave
        '
        Me.btnSave.Caption = "Save"
        Me.btnSave.Glyph = CType(resources.GetObject("btnSave.Glyph"), System.Drawing.Image)
        Me.btnSave.Id = 1
        Me.btnSave.LargeWidth = 80
        Me.btnSave.Name = "btnSave"
        Me.btnSave.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
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
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnSave)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Editing Options"
        '
        'CommentGrid
        '
        Me.CommentGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommentGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CommentGrid.Location = New System.Drawing.Point(0, 131)
        Me.CommentGrid.MainView = Me.CommentView
        Me.CommentGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CommentGrid.Name = "CommentGrid"
        Me.CommentGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rNIMemoEdit, Me.RepositoryItemDateEdit1})
        Me.CommentGrid.Size = New System.Drawing.Size(744, 264)
        Me.CommentGrid.TabIndex = 17
        Me.CommentGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CommentView})
        '
        'CommentView
        '
        Me.CommentView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.CommentView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CommentView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.CommentView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CommentView.Appearance.Row.Options.UseTextOptions = True
        Me.CommentView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CommentView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CommentView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.CommentView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.CommentView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.CommentView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CommentView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.CommentView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.CommentView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn9})
        Me.CommentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.CommentView.GridControl = Me.CommentGrid
        Me.CommentView.Name = "CommentView"
        Me.CommentView.NewItemRowText = "Click here to add new Record"
        Me.CommentView.OptionsBehavior.AutoPopulateColumns = False
        Me.CommentView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.CommentView.OptionsCustomization.AllowColumnMoving = False
        Me.CommentView.OptionsCustomization.AllowFilter = False
        Me.CommentView.OptionsCustomization.AllowGroup = False
        Me.CommentView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CommentView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.CommentView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.CommentView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.CommentView.OptionsFind.AllowFindPanel = False
        Me.CommentView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CommentView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CommentView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.CommentView.OptionsSelection.UseIndicatorForSelection = False
        Me.CommentView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.CommentView.OptionsView.RowAutoHeight = True
        Me.CommentView.OptionsView.ShowGroupPanel = False
        Me.CommentView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn5, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn4, DevExpress.Data.ColumnSortOrder.Descending)})
        Me.CommentView.ViewCaption = " Other Information"
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Columns.Add(Me.GridColumn1)
        Me.GridBand1.Columns.Add(Me.GridColumn2)
        Me.GridBand1.Columns.Add(Me.GridColumn3)
        Me.GridBand1.Columns.Add(Me.GridColumn4)
        Me.GridBand1.Columns.Add(Me.GridColumn5)
        Me.GridBand1.Columns.Add(Me.GridColumn6)
        Me.GridBand1.Columns.Add(Me.GridColumn9)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 726
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "PKey"
        Me.GridColumn1.FieldName = "PKey"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "FKeyIDNbr"
        Me.GridColumn2.FieldName = "FKeyIDNbr"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Comment"
        Me.GridColumn3.ColumnEdit = Me.rNIMemoEdit
        Me.GridColumn3.FieldName = "Comment"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.Width = 273
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Commented By"
        Me.GridColumn4.FieldName = "ComBy"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.GridColumn4.Visible = True
        Me.GridColumn4.Width = 244
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Comment Date"
        Me.GridColumn5.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn5.FieldName = "ComDate"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.GridColumn5.Visible = True
        Me.GridColumn5.Width = 209
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Mask.EditMask = "dd-MMM-yyyy HH:mm:ss"
        Me.RepositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Attached File Path"
        Me.GridColumn6.FieldName = "FilePath"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Width = 301
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Edited"
        Me.GridColumn9.FieldName = "Edited"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'rNIMemoEdit
        '
        Me.rNIMemoEdit.MaxLength = 200
        Me.rNIMemoEdit.Name = "rNIMemoEdit"
        '
        'frmCrewComments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 395)
        Me.Controls.Add(Me.CommentGrid)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmCrewComments"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crew Comments"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rNIMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CommentGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents rNIMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CommentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
