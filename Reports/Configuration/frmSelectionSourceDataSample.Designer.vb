<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectionSourceDataSample
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboDisplayValueField = New DevExpress.XtraEditors.LookUpEdit()
        Me.ActualDataSourceGrid = New DevExpress.XtraGrid.GridControl()
        Me.ActualDataSourceView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtSelectionSource = New DevExpress.XtraEditors.TextEdit()
        Me.PrintSelectionGrid = New DevExpress.XtraGrid.GridControl()
        Me.PrintSelectionView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDisplayField = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cboDisplayValueField.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActualDataSourceGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActualDataSourceView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSelectionSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintSelectionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintSelectionView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.cboDisplayValueField)
        Me.LayoutControl1.Controls.Add(Me.ActualDataSourceGrid)
        Me.LayoutControl1.Controls.Add(Me.txtSelectionSource)
        Me.LayoutControl1.Controls.Add(Me.PrintSelectionGrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(837, 404)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Firebrick
        Me.LabelControl1.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(464, 16)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Note: Selection Source is based on pre-defined entries in table: MSysDataSource"
        '
        'cboDisplayValueField
        '
        Me.cboDisplayValueField.Location = New System.Drawing.Point(135, 95)
        Me.cboDisplayValueField.Name = "cboDisplayValueField"
        Me.cboDisplayValueField.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDisplayValueField.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FieldName", "FieldName")})
        Me.cboDisplayValueField.Properties.DisplayMember = "FieldName"
        Me.cboDisplayValueField.Properties.DropDownRows = 10
        Me.cboDisplayValueField.Properties.NullText = ""
        Me.cboDisplayValueField.Properties.ShowFooter = False
        Me.cboDisplayValueField.Properties.ShowHeader = False
        Me.cboDisplayValueField.Properties.ValueMember = "FieldName"
        Me.cboDisplayValueField.Size = New System.Drawing.Size(281, 22)
        Me.cboDisplayValueField.StyleController = Me.LayoutControl1
        Me.cboDisplayValueField.TabIndex = 8
        '
        'ActualDataSourceGrid
        '
        Me.ActualDataSourceGrid.Location = New System.Drawing.Point(24, 95)
        Me.ActualDataSourceGrid.MainView = Me.ActualDataSourceView
        Me.ActualDataSourceGrid.Name = "ActualDataSourceGrid"
        Me.ActualDataSourceGrid.Size = New System.Drawing.Size(789, 285)
        Me.ActualDataSourceGrid.TabIndex = 7
        Me.ActualDataSourceGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ActualDataSourceView})
        '
        'ActualDataSourceView
        '
        Me.ActualDataSourceView.GridControl = Me.ActualDataSourceGrid
        Me.ActualDataSourceView.Name = "ActualDataSourceView"
        Me.ActualDataSourceView.OptionsBehavior.ReadOnly = True
        Me.ActualDataSourceView.OptionsCustomization.AllowColumnMoving = False
        Me.ActualDataSourceView.OptionsCustomization.AllowColumnResizing = False
        Me.ActualDataSourceView.OptionsCustomization.AllowFilter = False
        Me.ActualDataSourceView.OptionsCustomization.AllowGroup = False
        Me.ActualDataSourceView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ActualDataSourceView.OptionsCustomization.AllowSort = False
        Me.ActualDataSourceView.OptionsView.ShowGroupPanel = False
        Me.ActualDataSourceView.OptionsView.ShowIndicator = False
        '
        'txtSelectionSource
        '
        Me.txtSelectionSource.Location = New System.Drawing.Point(123, 12)
        Me.txtSelectionSource.Name = "txtSelectionSource"
        Me.txtSelectionSource.Size = New System.Drawing.Size(702, 22)
        Me.txtSelectionSource.StyleController = Me.LayoutControl1
        Me.txtSelectionSource.TabIndex = 6
        '
        'PrintSelectionGrid
        '
        Me.PrintSelectionGrid.Location = New System.Drawing.Point(24, 121)
        Me.PrintSelectionGrid.MainView = Me.PrintSelectionView
        Me.PrintSelectionGrid.Name = "PrintSelectionGrid"
        Me.PrintSelectionGrid.Size = New System.Drawing.Size(789, 259)
        Me.PrintSelectionGrid.TabIndex = 5
        Me.PrintSelectionGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.PrintSelectionView})
        '
        'PrintSelectionView
        '
        Me.PrintSelectionView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Yellow
        Me.PrintSelectionView.Appearance.FocusedRow.Options.UseBackColor = True
        Me.PrintSelectionView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDisplayField})
        Me.PrintSelectionView.GridControl = Me.PrintSelectionGrid
        Me.PrintSelectionView.Name = "PrintSelectionView"
        Me.PrintSelectionView.OptionsBehavior.ReadOnly = True
        Me.PrintSelectionView.OptionsCustomization.AllowColumnMoving = False
        Me.PrintSelectionView.OptionsCustomization.AllowColumnResizing = False
        Me.PrintSelectionView.OptionsCustomization.AllowFilter = False
        Me.PrintSelectionView.OptionsCustomization.AllowGroup = False
        Me.PrintSelectionView.OptionsCustomization.AllowQuickHideColumns = False
        Me.PrintSelectionView.OptionsCustomization.AllowSort = False
        Me.PrintSelectionView.OptionsView.ShowColumnHeaders = False
        Me.PrintSelectionView.OptionsView.ShowGroupPanel = False
        Me.PrintSelectionView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.PrintSelectionView.OptionsView.ShowIndicator = False
        Me.PrintSelectionView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colDisplayField
        '
        Me.colDisplayField.Caption = "colDisplayField"
        Me.colDisplayField.Name = "colDisplayField"
        Me.colDisplayField.OptionsColumn.AllowEdit = False
        Me.colDisplayField.Visible = True
        Me.colDisplayField.VisibleIndex = 0
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.TabbedControlGroup1, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(837, 404)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtSelectionSource
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(817, 26)
        Me.LayoutControlItem1.Text = "Selection Source:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(108, 16)
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 46)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup2
        Me.TabbedControlGroup1.SelectedTabPageIndex = 0
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(817, 338)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem4, Me.EmptySpaceItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(793, 289)
        Me.LayoutControlGroup2.Text = "Displayed in Print Selection"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.PrintSelectionGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(793, 263)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboDisplayValueField
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem4.Text = "DisplayValue Field:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(108, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(396, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(397, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(793, 289)
        Me.LayoutControlGroup3.Text = "Actual Data Source"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ActualDataSourceGrid
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(793, 289)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LabelControl1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(817, 20)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'frmSelectionSourceDataSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 404)
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectionSourceDataSample"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Show Selection Source Data"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cboDisplayValueField.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActualDataSourceGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActualDataSourceView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSelectionSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintSelectionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintSelectionView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PrintSelectionGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents PrintSelectionView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtSelectionSource As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ActualDataSourceGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ActualDataSourceView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboDisplayValueField As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colDisplayField As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
