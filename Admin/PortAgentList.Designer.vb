<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PortAgentList
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
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPort = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MainGrid.Size = New System.Drawing.Size(391, 393)
        Me.MainGrid.TabIndex = 5
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.BandedGridColumn1, Me.colPort, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn7, Me.BandedGridColumn6, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BandedGridColumn11, Me.BandedGridColumn12, Me.BandedGridColumn13, Me.BandedGridColumn14, Me.BandedGridColumn15, Me.BandedGridColumn16, Me.BandedGridColumn17, Me.BandedGridColumn18, Me.BandedGridColumn4})
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
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Columns.Add(Me.colPort)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 150
        '
        'colPKey
        '
        Me.colPKey.FieldName = "PKey"
        Me.colPKey.Name = "colPKey"
        '
        'colPort
        '
        Me.colPort.Caption = "Port"
        Me.colPort.FieldName = "Port"
        Me.colPort.Name = "colPort"
        Me.colPort.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Agency Name"
        Me.BandedGridColumn2.FieldName = "Name"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "FKeyCntry"
        Me.BandedGridColumn4.FieldName = "FKeyCntry"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.RowIndex = 1
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "FKeyPort"
        Me.BandedGridColumn1.FieldName = "FKeyPort"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "AusState"
        Me.BandedGridColumn3.FieldName = "AusState"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "PortNo"
        Me.BandedGridColumn7.FieldName = "PortNo"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Visible = True
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Trade"
        Me.BandedGridColumn6.FieldName = "Trade"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "Address"
        Me.BandedGridColumn8.FieldName = "Address"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "Address2"
        Me.BandedGridColumn9.FieldName = "Address2"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Visible = True
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.Caption = "Address3"
        Me.BandedGridColumn10.FieldName = "Address3"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.Visible = True
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Address3"
        Me.BandedGridColumn11.FieldName = "Address3"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.Visible = True
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.Caption = "AgentRep"
        Me.BandedGridColumn12.FieldName = "AgentRep"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.Visible = True
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.Caption = "Address4"
        Me.BandedGridColumn13.FieldName = "Address4"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.Visible = True
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.Caption = "AgentTel"
        Me.BandedGridColumn14.FieldName = "AgentTel"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        Me.BandedGridColumn14.Visible = True
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.Caption = "AgentMobile"
        Me.BandedGridColumn15.FieldName = "AgentMobile"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.Visible = True
        '
        'BandedGridColumn16
        '
        Me.BandedGridColumn16.Caption = "AgentEmail"
        Me.BandedGridColumn16.FieldName = "AgentEmail"
        Me.BandedGridColumn16.Name = "BandedGridColumn16"
        Me.BandedGridColumn16.Visible = True
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.Caption = "AgentFax"
        Me.BandedGridColumn17.FieldName = "AgentFax"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        Me.BandedGridColumn17.Visible = True
        '
        'BandedGridColumn18
        '
        Me.BandedGridColumn18.Caption = "Comments"
        Me.BandedGridColumn18.FieldName = "Comments"
        Me.BandedGridColumn18.Name = "BandedGridColumn18"
        Me.BandedGridColumn18.Visible = True
        '
        'PortAgentList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "PortAgentList"
        Me.Size = New System.Drawing.Size(391, 393)
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPort As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
