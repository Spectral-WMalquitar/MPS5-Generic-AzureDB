<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrewListArchive
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrewListArchive))
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colLName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colMName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colVslName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colStatName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRankName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRankCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPlaceSON = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colStatCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repStatCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colIncludeInArchive = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colActGrpID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colCurrActID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPromFrom = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colTransFrom = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colRankSortCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.rightClickMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.RecordSum = New DevExpress.XtraBars.BarButtonItem()
        Me.Biodata = New DevExpress.XtraBars.BarButtonItem()
        Me.Document = New DevExpress.XtraBars.BarButtonItem()
        Me.Training = New DevExpress.XtraBars.BarButtonItem()
        Me.MedicalHis = New DevExpress.XtraBars.BarButtonItem()
        Me.Service = New DevExpress.XtraBars.BarButtonItem()
        Me.Relative = New DevExpress.XtraBars.BarButtonItem()
        Me.Appraisal = New DevExpress.XtraBars.BarButtonItem()
        Me.AddComment = New DevExpress.XtraBars.BarButtonItem()
        Me.PrintBio = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repStatCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.AllowDrop = True
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repStatCode})
        Me.MainGrid.Size = New System.Drawing.Size(312, 323)
        Me.MainGrid.TabIndex = 4
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPKey, Me.colLName, Me.colFName, Me.colMName, Me.colRankName, Me.colRankCode, Me.colPlaceSON, Me.colStatName, Me.colStatCode, Me.colActGrpID, Me.colCurrActID, Me.colVslName, Me.colPromFrom, Me.colTransFrom, Me.colRankSortCode, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.colIncludeInArchive})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsLayout.StoreDataSettings = False
        Me.MainView.OptionsPrint.AutoResetPrintDocument = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Columns.Add(Me.colPKey)
        Me.GridBand1.Columns.Add(Me.colLName)
        Me.GridBand1.Columns.Add(Me.colMName)
        Me.GridBand1.Columns.Add(Me.colFName)
        Me.GridBand1.Columns.Add(Me.colVslName)
        Me.GridBand1.Columns.Add(Me.colStatName)
        Me.GridBand1.Columns.Add(Me.colRankName)
        Me.GridBand1.Columns.Add(Me.colRankCode)
        Me.GridBand1.Columns.Add(Me.colPlaceSON)
        Me.GridBand1.Columns.Add(Me.colStatCode)
        Me.GridBand1.Columns.Add(Me.colIncludeInArchive)
        Me.GridBand1.Columns.Add(Me.colActGrpID)
        Me.GridBand1.Columns.Add(Me.colCurrActID)
        Me.GridBand1.Columns.Add(Me.colPromFrom)
        Me.GridBand1.Columns.Add(Me.colTransFrom)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.OptionsBand.FixedWidth = True
        Me.GridBand1.OptionsBand.ShowInCustomizationForm = False
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 844
        '
        'colPKey
        '
        Me.colPKey.Caption = "IDNbr"
        Me.colPKey.FieldName = "IDNbr"
        Me.colPKey.Name = "colPKey"
        '
        'colLName
        '
        Me.colLName.Caption = "Last Name"
        Me.colLName.FieldName = "LName"
        Me.colLName.Name = "colLName"
        Me.colLName.OptionsColumn.AllowEdit = False
        Me.colLName.Visible = True
        Me.colLName.Width = 160
        '
        'colMName
        '
        Me.colMName.Caption = "Middle Name"
        Me.colMName.FieldName = "MName"
        Me.colMName.Name = "colMName"
        Me.colMName.OptionsColumn.AllowEdit = False
        Me.colMName.Visible = True
        Me.colMName.Width = 161
        '
        'colFName
        '
        Me.colFName.Caption = "First Name"
        Me.colFName.FieldName = "FName"
        Me.colFName.Name = "colFName"
        Me.colFName.OptionsColumn.AllowEdit = False
        Me.colFName.Visible = True
        Me.colFName.Width = 168
        '
        'colVslName
        '
        Me.colVslName.Caption = "Vessel"
        Me.colVslName.FieldName = "VslName"
        Me.colVslName.Name = "colVslName"
        Me.colVslName.OptionsColumn.AllowEdit = False
        Me.colVslName.Visible = True
        Me.colVslName.Width = 160
        '
        'colStatName
        '
        Me.colStatName.Caption = "Status"
        Me.colStatName.FieldName = "StatName"
        Me.colStatName.Name = "colStatName"
        Me.colStatName.OptionsColumn.AllowEdit = False
        Me.colStatName.Width = 139
        '
        'colRankName
        '
        Me.colRankName.Caption = "Rank"
        Me.colRankName.FieldName = "RankName"
        Me.colRankName.Name = "colRankName"
        Me.colRankName.OptionsColumn.AllowEdit = False
        Me.colRankName.Visible = True
        Me.colRankName.Width = 108
        '
        'colRankCode
        '
        Me.colRankCode.FieldName = "RankCode"
        Me.colRankCode.Name = "colRankCode"
        Me.colRankCode.OptionsColumn.AllowEdit = False
        '
        'colPlaceSON
        '
        Me.colPlaceSON.Caption = "Sign-on Place"
        Me.colPlaceSON.FieldName = "PlaceSON"
        Me.colPlaceSON.Name = "colPlaceSON"
        Me.colPlaceSON.OptionsColumn.AllowEdit = False
        '
        'colStatCode
        '
        Me.colStatCode.Caption = "Current Status"
        Me.colStatCode.ColumnEdit = Me.repStatCode
        Me.colStatCode.FieldName = "StatCode"
        Me.colStatCode.Name = "colStatCode"
        Me.colStatCode.OptionsColumn.AllowEdit = False
        Me.colStatCode.Visible = True
        Me.colStatCode.Width = 87
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
        'colIncludeInArchive
        '
        Me.colIncludeInArchive.Caption = "Include in Archive"
        Me.colIncludeInArchive.FieldName = "IsIncludeInArchive"
        Me.colIncludeInArchive.Name = "colIncludeInArchive"
        Me.colIncludeInArchive.Width = 150
        '
        'colActGrpID
        '
        Me.colActGrpID.FieldName = "ActGrpID"
        Me.colActGrpID.Name = "colActGrpID"
        Me.colActGrpID.OptionsColumn.AllowEdit = False
        '
        'colCurrActID
        '
        Me.colCurrActID.FieldName = "CurrActID"
        Me.colCurrActID.Name = "colCurrActID"
        Me.colCurrActID.OptionsColumn.AllowEdit = False
        '
        'colPromFrom
        '
        Me.colPromFrom.FieldName = "PromFrom"
        Me.colPromFrom.Name = "colPromFrom"
        Me.colPromFrom.OptionsColumn.AllowEdit = False
        '
        'colTransFrom
        '
        Me.colTransFrom.FieldName = "TransFrom"
        Me.colTransFrom.Name = "colTransFrom"
        Me.colTransFrom.OptionsColumn.AllowEdit = False
        '
        'colRankSortCode
        '
        Me.colRankSortCode.FieldName = "RankSortCode"
        Me.colRankSortCode.Name = "colRankSortCode"
        Me.colRankSortCode.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Company ID"
        Me.BandedGridColumn1.FieldName = "COIDNo"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "BandedGridColumn2"
        Me.BandedGridColumn2.FieldName = "hasExpDoc"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "FKeyWScaleRankCode"
        Me.BandedGridColumn3.FieldName = "FKeyWScaleRankCode"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn3.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "FkeyWScaleCode"
        Me.BandedGridColumn4.FieldName = "FkeyWScaleCode"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'rightClickMenu
        '
        Me.rightClickMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.RecordSum), New DevExpress.XtraBars.LinkPersistInfo(Me.Biodata), New DevExpress.XtraBars.LinkPersistInfo(Me.Document), New DevExpress.XtraBars.LinkPersistInfo(Me.Training), New DevExpress.XtraBars.LinkPersistInfo(Me.MedicalHis), New DevExpress.XtraBars.LinkPersistInfo(Me.Service), New DevExpress.XtraBars.LinkPersistInfo(Me.Relative), New DevExpress.XtraBars.LinkPersistInfo(Me.Appraisal), New DevExpress.XtraBars.LinkPersistInfo(Me.AddComment, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintBio)})
        Me.rightClickMenu.Manager = Me.BarManager1
        Me.rightClickMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText
        Me.rightClickMenu.Name = "rightClickMenu"
        '
        'RecordSum
        '
        Me.RecordSum.Caption = "Record Summary"
        Me.RecordSum.Glyph = CType(resources.GetObject("RecordSum.Glyph"), System.Drawing.Image)
        Me.RecordSum.Id = 10
        Me.RecordSum.Name = "RecordSum"
        '
        'Biodata
        '
        Me.Biodata.Caption = "Biodata"
        Me.Biodata.Glyph = CType(resources.GetObject("Biodata.Glyph"), System.Drawing.Image)
        Me.Biodata.Id = 11
        Me.Biodata.Name = "Biodata"
        '
        'Document
        '
        Me.Document.Caption = "Documents"
        Me.Document.Glyph = CType(resources.GetObject("Document.Glyph"), System.Drawing.Image)
        Me.Document.Id = 12
        Me.Document.Name = "Document"
        '
        'Training
        '
        Me.Training.Caption = "Training"
        Me.Training.Glyph = CType(resources.GetObject("Training.Glyph"), System.Drawing.Image)
        Me.Training.Id = 18
        Me.Training.LargeGlyph = CType(resources.GetObject("Training.LargeGlyph"), System.Drawing.Image)
        Me.Training.Name = "Training"
        '
        'MedicalHis
        '
        Me.MedicalHis.Caption = "Medical History"
        Me.MedicalHis.Glyph = CType(resources.GetObject("MedicalHis.Glyph"), System.Drawing.Image)
        Me.MedicalHis.Id = 19
        Me.MedicalHis.Name = "MedicalHis"
        '
        'Service
        '
        Me.Service.Caption = "Service"
        Me.Service.Glyph = CType(resources.GetObject("Service.Glyph"), System.Drawing.Image)
        Me.Service.Id = 13
        Me.Service.Name = "Service"
        '
        'Relative
        '
        Me.Relative.Caption = "Relatives"
        Me.Relative.Glyph = CType(resources.GetObject("Relative.Glyph"), System.Drawing.Image)
        Me.Relative.Id = 14
        Me.Relative.Name = "Relative"
        '
        'Appraisal
        '
        Me.Appraisal.Caption = "Appraisals"
        Me.Appraisal.Glyph = CType(resources.GetObject("Appraisal.Glyph"), System.Drawing.Image)
        Me.Appraisal.Id = 15
        Me.Appraisal.Name = "Appraisal"
        '
        'AddComment
        '
        Me.AddComment.Caption = "Add Comment"
        Me.AddComment.Glyph = CType(resources.GetObject("AddComment.Glyph"), System.Drawing.Image)
        Me.AddComment.Id = 16
        Me.AddComment.Name = "AddComment"
        '
        'PrintBio
        '
        Me.PrintBio.Caption = "Print Biodata"
        Me.PrintBio.Glyph = CType(resources.GetObject("PrintBio.Glyph"), System.Drawing.Image)
        Me.PrintBio.Id = 17
        Me.PrintBio.Name = "PrintBio"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RecordSum, Me.Biodata, Me.Document, Me.Service, Me.Relative, Me.Appraisal, Me.AddComment, Me.PrintBio, Me.Training, Me.MedicalHis})
        Me.BarManager1.MaxItemId = 20
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlTop.Size = New System.Drawing.Size(312, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 323)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(312, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 323)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(312, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 323)
        '
        'CrewList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CrewList"
        Me.Size = New System.Drawing.Size(312, 323)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repStatCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rightClickMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents colPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colLName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colMName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRankCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPlaceSON As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colStatCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colActGrpID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colCurrActID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPromFrom As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colTransFrom As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colVslName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colStatName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colRankName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents repStatCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colRankSortCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents rightClickMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents RecordSum As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Biodata As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Document As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Service As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Relative As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Appraisal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AddComment As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintBio As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Training As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MedicalHis As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colIncludeInArchive As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

End Class
