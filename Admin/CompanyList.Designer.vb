<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyList
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
        Me.colAbbrv = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCntryName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colisManAgent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFKeyCntry = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPhone = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTeleFax = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colEmail = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDateUpdated = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colLastUpdatedBy = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colName, Me.colAbbrv, Me.colFKeyCntry, Me.colPhone, Me.colTeleFax, Me.colEmail, Me.colisManAgent, Me.BandedGridColumn1, Me.colDateUpdated, Me.colLastUpdatedBy, Me.colCntryName, Me.BandedGridColumn2})
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
        Me.GridBand1.Columns.Add(Me.colCntryName)
        Me.GridBand1.Columns.Add(Me.colAbbrv)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.colisManAgent)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 1152
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        Me.colName.Width = 463
        '
        'colAbbrv
        '
        Me.colAbbrv.Caption = "Abbrv"
        Me.colAbbrv.FieldName = "Abbrv"
        Me.colAbbrv.Name = "colAbbrv"
        Me.colAbbrv.Visible = True
        Me.colAbbrv.Width = 401
        '
        'colCntryName
        '
        Me.colCntryName.Caption = "Country"
        Me.colCntryName.FieldName = "Country"
        Me.colCntryName.Name = "colCntryName"
        Me.colCntryName.Visible = True
        Me.colCntryName.Width = 288
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Owner"
        Me.BandedGridColumn2.FieldName = "isOwner"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.RowIndex = 1
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "isPrincipal"
        Me.BandedGridColumn1.FieldName = "isPrincipal"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.RowIndex = 2
        '
        'colisManAgent
        '
        Me.colisManAgent.Caption = "isManAgent"
        Me.colisManAgent.FieldName = "isManAgent"
        Me.colisManAgent.Name = "colisManAgent"
        Me.colisManAgent.RowIndex = 2
        '
        'colPKey
        '
        Me.colPKey.Caption = "PKey"
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        Me.colPKey.Visible = True
        '
        'colFKeyCntry
        '
        Me.colFKeyCntry.Caption = "FKeyCntry"
        Me.colFKeyCntry.FieldName = "FKeyCntry"
        Me.colFKeyCntry.Name = "colFKeyCntry"
        Me.colFKeyCntry.Visible = True
        '
        'colPhone
        '
        Me.colPhone.Caption = "Phone"
        Me.colPhone.FieldName = "Phone"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.Visible = True
        '
        'colTeleFax
        '
        Me.colTeleFax.Caption = "TeleFax"
        Me.colTeleFax.FieldName = "TeleFax"
        Me.colTeleFax.Name = "colTeleFax"
        Me.colTeleFax.Visible = True
        '
        'colEmail
        '
        Me.colEmail.Caption = "Email"
        Me.colEmail.FieldName = "Email"
        Me.colEmail.Name = "colEmail"
        Me.colEmail.Visible = True
        '
        'colDateUpdated
        '
        Me.colDateUpdated.Caption = "DateUpdated"
        Me.colDateUpdated.FieldName = "DateUpdated"
        Me.colDateUpdated.Name = "colDateUpdated"
        Me.colDateUpdated.Visible = True
        '
        'colLastUpdatedBy
        '
        Me.colLastUpdatedBy.Caption = "LastUpdatedBy"
        Me.colLastUpdatedBy.FieldName = "LastUpdatedBy"
        Me.colLastUpdatedBy.Name = "colLastUpdatedBy"
        Me.colLastUpdatedBy.Visible = True
        '
        'CompanyList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "CompanyList"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colAbbrv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCntryName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFKeyCntry As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPhone As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTeleFax As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colEmail As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colisManAgent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDateUpdated As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colLastUpdatedBy As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
