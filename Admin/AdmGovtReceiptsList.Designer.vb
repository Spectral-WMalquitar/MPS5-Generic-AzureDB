<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdmGovtReceiptsList
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
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSortCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateUpdated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.CausesValidation = False
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(407, 381)
        Me.MainGrid.TabIndex = 6
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPKey, Me.colSortCode, Me.colName, Me.colDateUpdated, Me.colLastUpdatedBy})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.AutoUpdateTotalSummary = False
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.MainView.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsMenu.ShowAutoFilterRowItem = False
        Me.MainView.OptionsNavigation.AutoFocusNewRow = True
        Me.MainView.OptionsPrint.AutoResetPrintDocument = False
        Me.MainView.OptionsPrint.AutoWidth = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colSortCode
        '
        Me.colSortCode.FieldName = "SortCode"
        Me.colSortCode.Name = "colSortCode"
        Me.colSortCode.Visible = True
        Me.colSortCode.VisibleIndex = 1
        '
        'colName
        '
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 0
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
        'AdmGovtReceiptsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "AdmGovtReceiptsList"
        Me.Size = New System.Drawing.Size(407, 381)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSortCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn

End Class
