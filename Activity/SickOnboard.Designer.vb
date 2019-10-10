<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SickOnboard
    Inherits BaseControl.BaseControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SickOnboard))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Maingrid = New DevExpress.XtraGrid.GridControl()
        Me.Mainview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDNbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrActID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CrewName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StartDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GenericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TypeSortValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LCGSickOnboard = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LCGSickOnboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Controls.Add(Me.Maingrid)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl1.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl1.Root = Me.LCGSickOnboard
        Me.LayoutControl1.Size = New System.Drawing.Size(1107, 496)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Maingrid
        '
        Me.Maingrid.AllowDrop = True
        Me.Maingrid.Location = New System.Drawing.Point(14, 41)
        Me.Maingrid.MainView = Me.Mainview
        Me.Maingrid.Name = "Maingrid"
        Me.Maingrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.GenericDateEdit})
        Me.Maingrid.Size = New System.Drawing.Size(1079, 441)
        Me.Maingrid.TabIndex = 34
        Me.Maingrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.Mainview})
        '
        'Mainview
        '
        Me.Mainview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDNbr, Me.CurrActID, Me.CrewName, Me.Status, Me.StartDate, Me.Remarks, Me.Type, Me.TypeSortValue})
        Me.Mainview.GridControl = Me.Maingrid
        Me.Mainview.Name = "Mainview"
        Me.Mainview.OptionsCustomization.AllowGroup = False
        Me.Mainview.OptionsCustomization.AllowQuickHideColumns = False
        Me.Mainview.OptionsFind.AllowFindPanel = False
        Me.Mainview.OptionsMenu.EnableColumnMenu = False
        Me.Mainview.OptionsMenu.EnableFooterMenu = False
        Me.Mainview.OptionsMenu.EnableGroupPanelMenu = False
        Me.Mainview.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.Mainview.OptionsSelection.MultiSelect = True
        Me.Mainview.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.Mainview.OptionsView.ShowGroupPanel = False
        '
        'IDNbr
        '
        Me.IDNbr.FieldName = "IDNbr"
        Me.IDNbr.Name = "IDNbr"
        '
        'CurrActID
        '
        Me.CurrActID.FieldName = "CurrActID"
        Me.CurrActID.Name = "CurrActID"
        '
        'CrewName
        '
        Me.CrewName.Caption = "Crew Name"
        Me.CrewName.FieldName = "Crew"
        Me.CrewName.Name = "CrewName"
        Me.CrewName.OptionsColumn.AllowEdit = False
        Me.CrewName.OptionsColumn.AllowFocus = False
        Me.CrewName.OptionsColumn.ReadOnly = True
        Me.CrewName.Visible = True
        Me.CrewName.VisibleIndex = 0
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.OptionsColumn.AllowEdit = False
        Me.Status.OptionsColumn.AllowFocus = False
        Me.Status.OptionsColumn.ReadOnly = True
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 1
        '
        'StartDate
        '
        Me.StartDate.AppearanceHeader.Options.UseTextOptions = True
        Me.StartDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.StartDate.Caption = "Date Started as Sick/ Start Date to Resume as Onboard"
        Me.StartDate.ColumnEdit = Me.GenericDateEdit
        Me.StartDate.FieldName = "StartDate"
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Tag = "Required"
        Me.StartDate.Visible = True
        Me.StartDate.VisibleIndex = 2
        '
        'GenericDateEdit
        '
        Me.GenericDateEdit.AutoHeight = False
        Me.GenericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.GenericDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.GenericDateEdit.Name = "GenericDateEdit"
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 3
        '
        'Type
        '
        Me.Type.Caption = "Action"
        Me.Type.FieldName = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = True
        Me.Type.VisibleIndex = 4
        '
        'TypeSortValue
        '
        Me.TypeSortValue.Caption = "TypeSortValue"
        Me.TypeSortValue.FieldName = "TypeSortValue"
        Me.TypeSortValue.Name = "TypeSortValue"
        '
        'LCGSickOnboard
        '
        Me.LCGSickOnboard.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCGSickOnboard.AppearanceGroup.Options.UseFont = True
        Me.LCGSickOnboard.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LCGSickOnboard.GroupBordersVisible = False
        Me.LCGSickOnboard.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LCGSickOnboard.Location = New System.Drawing.Point(0, 0)
        Me.LCGSickOnboard.Name = "LCGSickOnboard"
        Me.LCGSickOnboard.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LCGSickOnboard.Size = New System.Drawing.Size(1107, 496)
        Me.LCGSickOnboard.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1107, 496)
        Me.LayoutControlGroup2.Text = "Sick Onboard"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Maingrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1083, 445)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'SickOnboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "SickOnboard"
        Me.Size = New System.Drawing.Size(1107, 496)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Maingrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mainview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LCGSickOnboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LCGSickOnboard As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents Maingrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents Mainview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDNbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrActID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CrewName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StartDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GenericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TypeSortValue As DevExpress.XtraGrid.Columns.GridColumn

End Class
