﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RankList
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
        Me.colSortCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colAbbrv = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colChineseName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colDeptCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFKeyRankGrp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFKeyRankType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRegistryCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRemarks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
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
        Me.MainGrid.Size = New System.Drawing.Size(333, 377)
        Me.MainGrid.TabIndex = 1
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colSortCode, Me.colAbbrv, Me.colName, Me.colChineseName, Me.colDeptCode, Me.colFKeyRankGrp, Me.colFKeyRankType, Me.colRegistryCode, Me.colRemarks})
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
        Me.GridBand1.Columns.Add(Me.colAbbrv)
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Columns.Add(Me.colChineseName)
        Me.GridBand1.Columns.Add(Me.colDeptCode)
        Me.GridBand1.Columns.Add(Me.colFKeyRankGrp)
        Me.GridBand1.Columns.Add(Me.colFKeyRankType)
        Me.GridBand1.Columns.Add(Me.colRegistryCode)
        Me.GridBand1.Columns.Add(Me.colRemarks)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 225
        '
        'colName
        '
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        '
        'colPKey
        '
        Me.colPKey.AppearanceCell.Options.UseTextOptions = True
        Me.colPKey.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        Me.colPKey.RowIndex = 1
        '
        'colSortCode
        '
        Me.colSortCode.FieldName = "SortCode"
        Me.colSortCode.Name = "colSortCode"
        Me.colSortCode.Visible = True
        '
        'colAbbrv
        '
        Me.colAbbrv.FieldName = "Abbrv"
        Me.colAbbrv.Name = "colAbbrv"
        Me.colAbbrv.Visible = True
        '
        'colChineseName
        '
        Me.colChineseName.FieldName = "ChineseName"
        Me.colChineseName.Name = "colChineseName"
        Me.colChineseName.RowIndex = 1
        '
        'colDeptCode
        '
        Me.colDeptCode.FieldName = "DeptCode"
        Me.colDeptCode.Name = "colDeptCode"
        Me.colDeptCode.RowIndex = 1
        '
        'colFKeyRankGrp
        '
        Me.colFKeyRankGrp.FieldName = "FKeyRankGrp"
        Me.colFKeyRankGrp.Name = "colFKeyRankGrp"
        Me.colFKeyRankGrp.RowIndex = 1
        '
        'colFKeyRankType
        '
        Me.colFKeyRankType.FieldName = "FKeyRankType"
        Me.colFKeyRankType.Name = "colFKeyRankType"
        Me.colFKeyRankType.RowIndex = 1
        '
        'colRegistryCode
        '
        Me.colRegistryCode.FieldName = "RegistryCode"
        Me.colRegistryCode.Name = "colRegistryCode"
        Me.colRegistryCode.RowIndex = 1
        '
        'colRemarks
        '
        Me.colRemarks.FieldName = "Remarks"
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.RowIndex = 1
        '
        'RankList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "RankList"
        Me.Size = New System.Drawing.Size(333, 377)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colSortCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colAbbrv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colChineseName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colDeptCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFKeyRankGrp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFKeyRankType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRegistryCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRemarks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
