<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaseSortOption
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridSort = New DevExpress.XtraGrid.GridControl()
        Me.GridSortView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SortFieldName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SortBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repSortOrder = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.MovableField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridSort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSortView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repSortOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.Label1)
        Me.LayoutControl1.Controls.Add(Me.GridSort)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(328, 270)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridSort
        '
        Me.GridSort.AllowDrop = True
        Me.GridSort.Location = New System.Drawing.Point(2, 2)
        Me.GridSort.MainView = Me.GridSortView
        Me.GridSort.Name = "GridSort"
        Me.GridSort.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repSortOrder})
        Me.GridSort.Size = New System.Drawing.Size(324, 242)
        Me.GridSort.TabIndex = 14
        Me.GridSort.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridSortView})
        '
        'GridSortView
        '
        Me.GridSortView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SortFieldName, Me.SortBy, Me.Order, Me.MovableField})
        Me.GridSortView.GridControl = Me.GridSort
        Me.GridSortView.Name = "GridSortView"
        Me.GridSortView.OptionsView.ShowGroupPanel = False
        Me.GridSortView.OptionsView.ShowIndicator = False
        '
        'SortFieldName
        '
        Me.SortFieldName.Caption = "SortFieldName"
        Me.SortFieldName.FieldName = "FieldName"
        Me.SortFieldName.Name = "SortFieldName"
        '
        'SortBy
        '
        Me.SortBy.Caption = "Sort By"
        Me.SortBy.FieldName = "Caption"
        Me.SortBy.Name = "SortBy"
        Me.SortBy.OptionsColumn.AllowEdit = False
        Me.SortBy.OptionsColumn.AllowFocus = False
        Me.SortBy.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.SortBy.OptionsColumn.AllowIncrementalSearch = False
        Me.SortBy.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.SortBy.OptionsColumn.AllowMove = False
        Me.SortBy.OptionsColumn.AllowShowHide = False
        Me.SortBy.OptionsColumn.AllowSize = False
        Me.SortBy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.SortBy.OptionsColumn.FixedWidth = True
        Me.SortBy.OptionsColumn.ReadOnly = True
        Me.SortBy.Visible = True
        Me.SortBy.VisibleIndex = 0
        Me.SortBy.Width = 70
        '
        'Order
        '
        Me.Order.Caption = "Order"
        Me.Order.ColumnEdit = Me.repSortOrder
        Me.Order.FieldName = "SortOrder"
        Me.Order.Name = "Order"
        Me.Order.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Order.OptionsColumn.AllowMove = False
        Me.Order.OptionsColumn.AllowShowHide = False
        Me.Order.OptionsColumn.AllowSize = False
        Me.Order.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Order.OptionsColumn.FixedWidth = True
        Me.Order.Visible = True
        Me.Order.VisibleIndex = 1
        Me.Order.Width = 70
        '
        'repSortOrder
        '
        Me.repSortOrder.AutoHeight = False
        Me.repSortOrder.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repSortOrder.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repSortOrder.DisplayMember = "Name"
        Me.repSortOrder.Name = "repSortOrder"
        Me.repSortOrder.ShowFooter = False
        Me.repSortOrder.ShowHeader = False
        Me.repSortOrder.ValueMember = "PKey"
        '
        'MovableField
        '
        Me.MovableField.Caption = "MovableField"
        Me.MovableField.FieldName = "isMovable"
        Me.MovableField.Name = "MovableField"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(328, 270)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridSort
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(328, 246)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(2, 248)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "*drag and drop to rearrange"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Label1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 246)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(328, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'BaseSortOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "BaseSortOption"
        Me.Size = New System.Drawing.Size(328, 270)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridSort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSortView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repSortOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridSort As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridSortView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SortFieldName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SortBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repSortOrder As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents MovableField As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem

End Class
