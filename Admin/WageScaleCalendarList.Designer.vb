<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WageScaleCalendarList
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
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateUpdated = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(303, 323)
        Me.MainGrid.TabIndex = 3
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.FilterCloseButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colName, Me.BandedGridColumn13, Me.BandedGridColumn12, Me.BandedGridColumn11, Me.BandedGridColumn10, Me.BandedGridColumn9, Me.BandedGridColumn8, Me.BandedGridColumn7, Me.BandedGridColumn6, Me.BandedGridColumn5, Me.BandedGridColumn4, Me.BandedGridColumn3, Me.BandedGridColumn2, Me.BandedGridColumn1, Me.colDateUpdated, Me.colLastUpdatedBy})
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
        Me.MainView.OptionsDetail.EnableMasterViewMode = False
        Me.MainView.OptionsFilter.AllowFilterEditor = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsMenu.EnableColumnMenu = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowBands = False
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Columns.Add(Me.colName)
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Columns.Add(Me.colDateUpdated)
        Me.GridBand1.Columns.Add(Me.colLastUpdatedBy)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 75
        '
        'colName
        '
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colDateUpdated
        '
        Me.colDateUpdated.FieldName = "DateUpdated"
        Me.colDateUpdated.Name = "colDateUpdated"
        '
        'colLastUpdatedBy
        '
        Me.colLastUpdatedBy.FieldName = "LastUpdatedBy"
        Me.colLastUpdatedBy.Name = "colLastUpdatedBy"
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.Caption = "January"
        Me.BandedGridColumn12.FieldName = "Jan"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Febuary"
        Me.BandedGridColumn11.FieldName = "Feb"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.Caption = "March"
        Me.BandedGridColumn10.FieldName = "Mar"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "April"
        Me.BandedGridColumn9.FieldName = "Apr"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "May"
        Me.BandedGridColumn8.FieldName = "May"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "June"
        Me.BandedGridColumn7.FieldName = "Jun"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "July"
        Me.BandedGridColumn6.FieldName = "July"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "August"
        Me.BandedGridColumn5.FieldName = "August"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "September"
        Me.BandedGridColumn4.FieldName = "Sep"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "October"
        Me.BandedGridColumn3.FieldName = "Oct"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "November"
        Me.BandedGridColumn2.FieldName = "Nov"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "December"
        Me.BandedGridColumn1.FieldName = "Dec"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.Caption = "Type"
        Me.BandedGridColumn13.FieldName = "Type"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.Visible = True
        '
        'WageScaleCalendarList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "WageScaleCalendarList"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
