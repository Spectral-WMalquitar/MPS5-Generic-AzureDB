<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VersionUpdates
    Inherits BaseControl.BaseControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VersionUpdates))
        Me.grpVersionUpdates = New DevExpress.XtraEditors.GroupControl()
        Me.grdVersionUpdates = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AppVersion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VersionDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.LoadedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VersionDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpVersionUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVersionUpdates.SuspendLayout()
        CType(Me.grdVersionUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection.InsertGalleryImage("add_32x32.png", "images/actions/add_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_32x32.png"), 0)
        Me.ImageCollection.Images.SetKeyName(0, "add_32x32.png")
        Me.ImageCollection.InsertGalleryImage("cancel_32x32.png", "images/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"), 1)
        Me.ImageCollection.Images.SetKeyName(1, "cancel_32x32.png")
        Me.ImageCollection.InsertGalleryImage("edit_32x32.png", "images/edit/edit_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_32x32.png"), 2)
        Me.ImageCollection.Images.SetKeyName(2, "edit_32x32.png")
        '
        'grpVersionUpdates
        '
        Me.grpVersionUpdates.Controls.Add(Me.grdVersionUpdates)
        Me.grpVersionUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpVersionUpdates.Location = New System.Drawing.Point(0, 0)
        Me.grpVersionUpdates.Name = "grpVersionUpdates"
        Me.grpVersionUpdates.Size = New System.Drawing.Size(881, 448)
        Me.grpVersionUpdates.TabIndex = 0
        Me.grpVersionUpdates.Text = "Product Version"
        '
        'grdVersionUpdates
        '
        Me.grdVersionUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVersionUpdates.Location = New System.Drawing.Point(2, 21)
        Me.grdVersionUpdates.MainView = Me.GridView1
        Me.grdVersionUpdates.Name = "grdVersionUpdates"
        Me.grdVersionUpdates.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.RepositoryItemDateEdit1})
        Me.grdVersionUpdates.Size = New System.Drawing.Size(877, 425)
        Me.grdVersionUpdates.TabIndex = 0
        Me.grdVersionUpdates.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.AppVersion, Me.VersionDate, Me.LoadedBy, Me.VersionDesc})
        Me.GridView1.GridControl = Me.grdVersionUpdates
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'AppVersion
        '
        Me.AppVersion.Caption = "Version"
        Me.AppVersion.FieldName = "AppVersion"
        Me.AppVersion.Name = "AppVersion"
        Me.AppVersion.Visible = True
        Me.AppVersion.VisibleIndex = 0
        Me.AppVersion.Width = 60
        '
        'VersionDate
        '
        Me.VersionDate.AppearanceCell.Options.UseTextOptions = True
        Me.VersionDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.VersionDate.Caption = "Date"
        Me.VersionDate.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.VersionDate.FieldName = "VersionDate"
        Me.VersionDate.Name = "VersionDate"
        Me.VersionDate.OptionsColumn.AllowEdit = False
        Me.VersionDate.OptionsColumn.ReadOnly = True
        Me.VersionDate.Visible = True
        Me.VersionDate.VisibleIndex = 1
        Me.VersionDate.Width = 105
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.EditFormat.FormatString = "dd-MMMM-yyyy"
        Me.RepositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.Mask.EditMask = "dd-MMMM-yyyy"
        Me.RepositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'LoadedBy
        '
        Me.LoadedBy.Caption = "Loaded By"
        Me.LoadedBy.FieldName = "LoadedBy"
        Me.LoadedBy.Name = "LoadedBy"
        Me.LoadedBy.Visible = True
        Me.LoadedBy.VisibleIndex = 2
        Me.LoadedBy.Width = 184
        '
        'VersionDesc
        '
        Me.VersionDesc.Caption = "Description"
        Me.VersionDesc.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.VersionDesc.FieldName = "VersionDesc"
        Me.VersionDesc.Name = "VersionDesc"
        Me.VersionDesc.Visible = True
        Me.VersionDesc.VisibleIndex = 3
        Me.VersionDesc.Width = 729
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'VersionUpdates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.grpVersionUpdates)
        Me.Name = "VersionUpdates"
        Me.Size = New System.Drawing.Size(881, 448)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpVersionUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVersionUpdates.ResumeLayout(False)
        CType(Me.grdVersionUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpVersionUpdates As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grdVersionUpdates As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AppVersion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VersionDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VersionDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents LoadedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

End Class
