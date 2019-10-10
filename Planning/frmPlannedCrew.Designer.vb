<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlannedCrew
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlannedCrew))
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPlannedRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colPlannedWScale = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WScaleEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colPlannedDateSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.genericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colPlannedPlaceSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PortEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colToRelieveID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPlannedVsl = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repStatCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WScaleEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repStatCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.AllowDrop = True
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repStatCode, Me.RankEdit, Me.WScaleEdit, Me.PortEdit, Me.genericDateEdit})
        Me.MainGrid.Size = New System.Drawing.Size(761, 404)
        Me.MainGrid.TabIndex = 5
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colCrewName, Me.colPlannedRank, Me.colPlannedWScale, Me.colPlannedDateSON, Me.colPlannedPlaceSON, Me.colPlannedVsl, Me.colToRelieveID})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsPrint.AutoResetPrintDocument = False
        Me.MainView.OptionsSelection.MultiSelect = True
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Planned Crews (Note: All details are according to planning event.)"
        Me.GridBand1.Columns.Add(Me.colCrewName)
        Me.GridBand1.Columns.Add(Me.colPlannedRank)
        Me.GridBand1.Columns.Add(Me.colPlannedWScale)
        Me.GridBand1.Columns.Add(Me.colPlannedDateSON)
        Me.GridBand1.Columns.Add(Me.colPlannedPlaceSON)
        Me.GridBand1.Columns.Add(Me.colToRelieveID)
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.OptionsBand.FixedWidth = True
        Me.GridBand1.OptionsBand.ShowInCustomizationForm = False
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 375
        '
        'colCrewName
        '
        Me.colCrewName.Caption = "CrewName"
        Me.colCrewName.FieldName = "Crew"
        Me.colCrewName.Name = "colCrewName"
        Me.colCrewName.Visible = True
        '
        'colPlannedRank
        '
        Me.colPlannedRank.Caption = "Rank"
        Me.colPlannedRank.ColumnEdit = Me.RankEdit
        Me.colPlannedRank.FieldName = "PlannedRank"
        Me.colPlannedRank.Name = "colPlannedRank"
        Me.colPlannedRank.Visible = True
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankName", "RankName"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode", "PortCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RankEdit.DisplayMember = "RankName"
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "RankCode"
        '
        'colPlannedWScale
        '
        Me.colPlannedWScale.Caption = "Wage Scale"
        Me.colPlannedWScale.ColumnEdit = Me.WScaleEdit
        Me.colPlannedWScale.FieldName = "PlannedWScaleRank"
        Me.colPlannedWScale.Name = "colPlannedWScale"
        Me.colPlannedWScale.Visible = True
        '
        'WScaleEdit
        '
        Me.WScaleEdit.AutoHeight = False
        Me.WScaleEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WScaleEdit.Name = "WScaleEdit"
        Me.WScaleEdit.NullText = ""
        Me.WScaleEdit.ShowFooter = False
        Me.WScaleEdit.ShowHeader = False
        Me.WScaleEdit.ValueMember = "WScaleRankCode"
        '
        'colPlannedDateSON
        '
        Me.colPlannedDateSON.Caption = "Date Sign-on"
        Me.colPlannedDateSON.ColumnEdit = Me.genericDateEdit
        Me.colPlannedDateSON.FieldName = "PlannedDateSON"
        Me.colPlannedDateSON.Name = "colPlannedDateSON"
        Me.colPlannedDateSON.Visible = True
        '
        'genericDateEdit
        '
        Me.genericDateEdit.AutoHeight = False
        Me.genericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.Name = "genericDateEdit"
        '
        'colPlannedPlaceSON
        '
        Me.colPlannedPlaceSON.Caption = "Place Sign-on"
        Me.colPlannedPlaceSON.ColumnEdit = Me.PortEdit
        Me.colPlannedPlaceSON.FieldName = "PlannedPlaceSON"
        Me.colPlannedPlaceSON.Name = "colPlannedPlaceSON"
        Me.colPlannedPlaceSON.Visible = True
        '
        'PortEdit
        '
        Me.PortEdit.AutoHeight = False
        Me.PortEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PortEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode", "PortCode")})
        Me.PortEdit.DisplayMember = "PortName"
        Me.PortEdit.Name = "PortEdit"
        Me.PortEdit.NullText = ""
        Me.PortEdit.ShowFooter = False
        Me.PortEdit.ShowHeader = False
        Me.PortEdit.ValueMember = "PortCode"
        '
        'colToRelieveID
        '
        Me.colToRelieveID.Caption = "Crew to Relieve"
        Me.colToRelieveID.FieldName = "PlannedToRelieveID"
        Me.colToRelieveID.Name = "colToRelieveID"
        '
        'colPKey
        '
        Me.colPKey.Caption = "PKey"
        Me.colPKey.FieldName = "IDNbr"
        Me.colPKey.Name = "colPKey"
        '
        'colPlannedVsl
        '
        Me.colPlannedVsl.FieldName = "PlannedVsl"
        Me.colPlannedVsl.Name = "colPlannedVsl"
        Me.colPlannedVsl.Visible = True
        '
        'repStatCode
        '
        Me.repStatCode.AutoHeight = False
        Me.repStatCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repStatCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repStatCode.DisplayMember = "Name"
        Me.repStatCode.Name = "repStatCode"
        Me.repStatCode.NullText = ""
        Me.repStatCode.ShowFooter = False
        Me.repStatCode.ShowHeader = False
        Me.repStatCode.ValueMember = "PKey"
        '
        'frmPlannedCrew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 404)
        Me.Controls.Add(Me.MainGrid)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmPlannedCrew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planned Crews"
        Me.TopMost = True
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WScaleEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PortEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repStatCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repStatCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPlannedRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPlannedWScale As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPlannedDateSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPlannedPlaceSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPlannedVsl As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents WScaleEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PortEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents genericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colToRelieveID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
