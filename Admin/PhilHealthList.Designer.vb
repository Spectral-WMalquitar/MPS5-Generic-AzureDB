<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhilHealthList
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
        Me.SalaryRange = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colSalaryTo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateUpdated = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SalCredit = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colSalCredit = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PhilH = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colMCREmployer = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colMCRmployer = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repRate = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repRate})
        Me.MainGrid.Size = New System.Drawing.Size(404, 398)
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
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.SalaryRange, Me.SalCredit, Me.PhilH})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colSalary, Me.colSalaryTo, Me.colSalCredit, Me.colMCREmployer, Me.colMCRmployer, Me.colDateUpdated, Me.colLastUpdatedBy, Me.colRate})
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
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'SalaryRange
        '
        Me.SalaryRange.Caption = "Salary Range"
        Me.SalaryRange.Columns.Add(Me.colSalary)
        Me.SalaryRange.Columns.Add(Me.colPKey)
        Me.SalaryRange.Columns.Add(Me.colSalaryTo)
        Me.SalaryRange.Columns.Add(Me.colDateUpdated)
        Me.SalaryRange.Columns.Add(Me.colLastUpdatedBy)
        Me.SalaryRange.Name = "SalaryRange"
        Me.SalaryRange.OptionsBand.AllowMove = False
        Me.SalaryRange.VisibleIndex = 0
        Me.SalaryRange.Width = 150
        '
        'colSalary
        '
        Me.colSalary.Caption = "From"
        Me.colSalary.DisplayFormat.FormatString = "n2"
        Me.colSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSalary.FieldName = "Salary"
        Me.colSalary.Name = "colSalary"
        Me.colSalary.Visible = True
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colSalaryTo
        '
        Me.colSalaryTo.Caption = "To"
        Me.colSalaryTo.DisplayFormat.FormatString = "n2"
        Me.colSalaryTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSalaryTo.FieldName = "SalaryTo"
        Me.colSalaryTo.Name = "colSalaryTo"
        Me.colSalaryTo.Visible = True
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
        'SalCredit
        '
        Me.SalCredit.Columns.Add(Me.colSalCredit)
        Me.SalCredit.Name = "SalCredit"
        Me.SalCredit.VisibleIndex = 1
        Me.SalCredit.Width = 75
        '
        'colSalCredit
        '
        Me.colSalCredit.Caption = "Salary Credit"
        Me.colSalCredit.DisplayFormat.FormatString = "n2"
        Me.colSalCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colSalCredit.FieldName = "SalCredit"
        Me.colSalCredit.Name = "colSalCredit"
        Me.colSalCredit.Visible = True
        '
        'PhilH
        '
        Me.PhilH.Caption = "Contribution"
        Me.PhilH.Columns.Add(Me.colMCREmployer)
        Me.PhilH.Columns.Add(Me.colMCRmployer)
        Me.PhilH.Columns.Add(Me.colRate)
        Me.PhilH.Name = "PhilH"
        Me.PhilH.VisibleIndex = 2
        Me.PhilH.Width = 298
        '
        'colMCREmployer
        '
        Me.colMCREmployer.Caption = "Employer"
        Me.colMCREmployer.DisplayFormat.FormatString = "n2"
        Me.colMCREmployer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMCREmployer.FieldName = "MCREmployer"
        Me.colMCREmployer.Name = "colMCREmployer"
        Me.colMCREmployer.Visible = True
        Me.colMCREmployer.Width = 111
        '
        'colMCRmployer
        '
        Me.colMCRmployer.Caption = "Employee"
        Me.colMCRmployer.DisplayFormat.FormatString = "n2"
        Me.colMCRmployer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMCRmployer.FieldName = "MCREmployee"
        Me.colMCRmployer.Name = "colMCRmployer"
        Me.colMCRmployer.Visible = True
        Me.colMCRmployer.Width = 112
        '
        'colRate
        '
        Me.colRate.Caption = "Rate"
        Me.colRate.ColumnEdit = Me.repRate
        Me.colRate.FieldName = "Rate"
        Me.colRate.Name = "colRate"
        Me.colRate.Visible = True
        '
        'repRate
        '
        Me.repRate.AutoHeight = False
        Me.repRate.Mask.EditMask = "p2"
        Me.repRate.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repRate.Mask.UseMaskAsDisplayFormat = True
        Me.repRate.Name = "repRate"
        '
        'PhilHealthList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoSize = True
        Me.Controls.Add(Me.MainGrid)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "PhilHealthList"
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSalaryTo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSalCredit As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colMCREmployer As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colMCRmployer As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SalaryRange As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents SalCredit As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PhilH As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colRate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repRate As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit

End Class
