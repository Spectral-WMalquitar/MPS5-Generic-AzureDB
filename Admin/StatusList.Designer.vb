<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatusList
    Inherits BaseControl.BaseList

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
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSortCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateUpdated = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colColor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(404, 398)
        Me.MainGrid.TabIndex = 2
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.FocusedRow.Options.UseTextOptions = True
        Me.MainView.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.GroupRow.Options.UseTextOptions = True
        Me.MainView.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.Row.Options.UseTextOptions = True
        Me.MainView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.AppearancePrint.Row.Options.UseTextOptions = True
        Me.MainView.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn2, Me.colName, Me.colSortCode, Me.colDateUpdated, Me.colColor, Me.colLastUpdatedBy, Me.BandedGridColumn1, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowBands = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Columns.Add(Me.colName)
        Me.GridBand1.Columns.Add(Me.colSortCode)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand1.Columns.Add(Me.colDateUpdated)
        Me.GridBand1.Columns.Add(Me.colColor)
        Me.GridBand1.Columns.Add(Me.colLastUpdatedBy)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 386
        '
        'colName
        '
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        Me.colName.Width = 96
        '
        'colSortCode
        '
        Me.colSortCode.FieldName = "SortCode"
        Me.colSortCode.Name = "colSortCode"
        Me.colSortCode.Visible = True
        Me.colSortCode.Width = 96
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "StatType"
        Me.BandedGridColumn1.FieldName = "StatType"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Status Type"
        Me.BandedGridColumn3.FieldName = "StatTypeName"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 122
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "SystemStatus"
        Me.BandedGridColumn6.FieldName = "isSysRecord"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 72
        '
        'colDateUpdated
        '
        Me.colDateUpdated.FieldName = "DateUpdated"
        Me.colDateUpdated.Name = "colDateUpdated"
        Me.colDateUpdated.RowIndex = 1
        '
        'colColor
        '
        Me.colColor.FieldName = "Color"
        Me.colColor.Name = "colColor"
        Me.colColor.RowIndex = 1
        '
        'colLastUpdatedBy
        '
        Me.colLastUpdatedBy.FieldName = "LastUpdatedBy"
        Me.colLastUpdatedBy.Name = "colLastUpdatedBy"
        Me.colLastUpdatedBy.RowIndex = 1
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "PKey"
        Me.BandedGridColumn2.FieldName = "PKey"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Default Ashore Status"
        Me.BandedGridColumn4.FieldName = "DefAshStat"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "LeaveType"
        Me.BandedGridColumn5.FieldName = "LeaveType"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        '
        'StatusList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "StatusList"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colSortCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colColor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
