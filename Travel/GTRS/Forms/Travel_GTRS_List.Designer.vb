<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Travel_GTRS_List
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
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BookingStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TravelDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VslName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PlanningEvent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Port = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BookedWithGTravel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.checkEditBookedWithGTravel = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.isBooked = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.checkEditBooked = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.isCompleted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.checkEditCompleted = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.isUnread = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StatusToolTip = New DevExpress.Utils.ToolTipController(Me.components)
        Me.LayoutControl_Main = New DevExpress.XtraLayout.LayoutControl()
        Me.cboCompleted = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboBookingType = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboRecordFilter = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup_Main = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_Filters = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkEditBookedWithGTravel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkEditBooked, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.checkEditCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl_Main.SuspendLayout()
        CType(Me.cboCompleted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBookingType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRecordFilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Filters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(2, 104)
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repDateEdit, Me.checkEditBooked, Me.checkEditCompleted, Me.checkEditBookedWithGTravel})
        Me.MainGrid.Size = New System.Drawing.Size(400, 292)
        Me.MainGrid.TabIndex = 0
        Me.MainGrid.ToolTipController = Me.StatusToolTip
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PKey, Me.BookingStatus, Me.TravelDate, Me.RefNo, Me.VslName, Me.PlanningEvent, Me.Port, Me.BookedWithGTravel, Me.isBooked, Me.isCompleted, Me.isUnread})
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.ReadOnly = True
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'PKey
        '
        Me.PKey.Caption = "PKey"
        Me.PKey.FieldName = "PKey"
        Me.PKey.Name = "PKey"
        '
        'BookingStatus
        '
        Me.BookingStatus.Caption = "Status"
        Me.BookingStatus.FieldName = "BookingStatusLabel"
        Me.BookingStatus.Name = "BookingStatus"
        Me.BookingStatus.OptionsColumn.AllowSize = False
        Me.BookingStatus.OptionsColumn.FixedWidth = True
        Me.BookingStatus.Visible = True
        Me.BookingStatus.VisibleIndex = 0
        Me.BookingStatus.Width = 100
        '
        'TravelDate
        '
        Me.TravelDate.Caption = "Travel Date"
        Me.TravelDate.ColumnEdit = Me.repDateEdit
        Me.TravelDate.FieldName = "TravelDate"
        Me.TravelDate.Name = "TravelDate"
        Me.TravelDate.OptionsColumn.AllowEdit = False
        Me.TravelDate.Visible = True
        Me.TravelDate.VisibleIndex = 1
        Me.TravelDate.Width = 181
        '
        'repDateEdit
        '
        Me.repDateEdit.AutoHeight = False
        Me.repDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repDateEdit.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.repDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.repDateEdit.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.repDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.repDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.repDateEdit.Name = "repDateEdit"
        Me.repDateEdit.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        '
        'RefNo
        '
        Me.RefNo.Caption = "Ref. No."
        Me.RefNo.FieldName = "RefNo"
        Me.RefNo.Name = "RefNo"
        Me.RefNo.Visible = True
        Me.RefNo.VisibleIndex = 2
        Me.RefNo.Width = 120
        '
        'VslName
        '
        Me.VslName.Caption = "Vessel"
        Me.VslName.FieldName = "VslName"
        Me.VslName.Name = "VslName"
        Me.VslName.Visible = True
        Me.VslName.VisibleIndex = 3
        Me.VslName.Width = 242
        '
        'PlanningEvent
        '
        Me.PlanningEvent.Caption = "Planning Event"
        Me.PlanningEvent.FieldName = "PlanningEvent"
        Me.PlanningEvent.Name = "PlanningEvent"
        '
        'Port
        '
        Me.Port.Caption = "Port"
        Me.Port.FieldName = "PortName"
        Me.Port.Name = "Port"
        Me.Port.Visible = True
        Me.Port.VisibleIndex = 4
        Me.Port.Width = 304
        '
        'BookedWithGTravel
        '
        Me.BookedWithGTravel.Caption = " "
        Me.BookedWithGTravel.ColumnEdit = Me.checkEditBookedWithGTravel
        Me.BookedWithGTravel.FieldName = "BookedWithGTravel"
        Me.BookedWithGTravel.Name = "BookedWithGTravel"
        Me.BookedWithGTravel.OptionsColumn.FixedWidth = True
        Me.BookedWithGTravel.Visible = True
        Me.BookedWithGTravel.VisibleIndex = 5
        Me.BookedWithGTravel.Width = 36
        '
        'checkEditBookedWithGTravel
        '
        Me.checkEditBookedWithGTravel.AutoHeight = False
        Me.checkEditBookedWithGTravel.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.checkEditBookedWithGTravel.Name = "checkEditBookedWithGTravel"
        '
        'isBooked
        '
        Me.isBooked.Caption = " "
        Me.isBooked.ColumnEdit = Me.checkEditBooked
        Me.isBooked.FieldName = "isBooked"
        Me.isBooked.Name = "isBooked"
        Me.isBooked.OptionsColumn.FixedWidth = True
        Me.isBooked.Width = 36
        '
        'checkEditBooked
        '
        Me.checkEditBooked.AutoHeight = False
        Me.checkEditBooked.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.checkEditBooked.Name = "checkEditBooked"
        '
        'isCompleted
        '
        Me.isCompleted.Caption = " "
        Me.isCompleted.ColumnEdit = Me.checkEditCompleted
        Me.isCompleted.FieldName = "isCompleted"
        Me.isCompleted.Name = "isCompleted"
        Me.isCompleted.OptionsColumn.FixedWidth = True
        Me.isCompleted.Visible = True
        Me.isCompleted.VisibleIndex = 6
        Me.isCompleted.Width = 33
        '
        'checkEditCompleted
        '
        Me.checkEditCompleted.AutoHeight = False
        Me.checkEditCompleted.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.checkEditCompleted.Name = "checkEditCompleted"
        '
        'isUnread
        '
        Me.isUnread.Caption = "isUnread"
        Me.isUnread.FieldName = "isUnread"
        Me.isUnread.Name = "isUnread"
        '
        'StatusToolTip
        '
        '
        'LayoutControl_Main
        '
        Me.LayoutControl_Main.Controls.Add(Me.cboCompleted)
        Me.LayoutControl_Main.Controls.Add(Me.cboBookingType)
        Me.LayoutControl_Main.Controls.Add(Me.cboRecordFilter)
        Me.LayoutControl_Main.Controls.Add(Me.MainGrid)
        Me.LayoutControl_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl_Main.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl_Main.Name = "LayoutControl_Main"
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl_Main.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl_Main.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl_Main.Root = Me.LayoutControlGroup_Main
        Me.LayoutControl_Main.Size = New System.Drawing.Size(404, 398)
        Me.LayoutControl_Main.TabIndex = 1
        Me.LayoutControl_Main.Text = "LayoutControl1"
        '
        'cboCompleted
        '
        Me.cboCompleted.Location = New System.Drawing.Point(101, 66)
        Me.cboCompleted.Name = "cboCompleted"
        Me.cboCompleted.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboCompleted.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboCompleted.Properties.DisplayMember = "Name"
        Me.cboCompleted.Properties.NullText = ""
        Me.cboCompleted.Properties.ValueMember = "PKey"
        Me.cboCompleted.Size = New System.Drawing.Size(289, 22)
        Me.cboCompleted.StyleController = Me.LayoutControl_Main
        Me.cboCompleted.TabIndex = 10
        '
        'cboBookingType
        '
        Me.cboBookingType.Location = New System.Drawing.Point(101, 40)
        Me.cboBookingType.Name = "cboBookingType"
        Me.cboBookingType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboBookingType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboBookingType.Properties.DisplayMember = "Name"
        Me.cboBookingType.Properties.DropDownRows = 3
        Me.cboBookingType.Properties.NullText = ""
        Me.cboBookingType.Properties.ShowFooter = False
        Me.cboBookingType.Properties.ShowHeader = False
        Me.cboBookingType.Properties.ValueMember = "PKey"
        Me.cboBookingType.Size = New System.Drawing.Size(289, 22)
        Me.cboBookingType.StyleController = Me.LayoutControl_Main
        Me.cboBookingType.TabIndex = 9
        '
        'cboRecordFilter
        '
        Me.cboRecordFilter.Location = New System.Drawing.Point(101, 14)
        Me.cboRecordFilter.Name = "cboRecordFilter"
        Me.cboRecordFilter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboRecordFilter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboRecordFilter.Properties.DisplayMember = "Name"
        Me.cboRecordFilter.Properties.DropDownRows = 4
        Me.cboRecordFilter.Properties.NullText = ""
        Me.cboRecordFilter.Properties.ShowFooter = False
        Me.cboRecordFilter.Properties.ShowHeader = False
        Me.cboRecordFilter.Properties.ValueMember = "PKey"
        Me.cboRecordFilter.Size = New System.Drawing.Size(289, 22)
        Me.cboRecordFilter.StyleController = Me.LayoutControl_Main
        Me.cboRecordFilter.TabIndex = 6
        '
        'LayoutControlGroup_Main
        '
        Me.LayoutControlGroup_Main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup_Main.GroupBordersVisible = False
        Me.LayoutControlGroup_Main.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlGroup_Filters})
        Me.LayoutControlGroup_Main.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Main.Name = "LayoutControlGroup_Main"
        Me.LayoutControlGroup_Main.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup_Main.Size = New System.Drawing.Size(404, 398)
        Me.LayoutControlGroup_Main.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MainGrid
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(404, 296)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup_Filters
        '
        Me.LayoutControlGroup_Filters.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem4, Me.LayoutControlItem2})
        Me.LayoutControlGroup_Filters.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Filters.Name = "LayoutControlGroup_Filters"
        Me.LayoutControlGroup_Filters.Size = New System.Drawing.Size(404, 102)
        Me.LayoutControlGroup_Filters.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboRecordFilter
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(380, 26)
        Me.LayoutControlItem5.Text = "Filter Records:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboBookingType
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(380, 26)
        Me.LayoutControlItem4.Text = "Booking Type:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboCompleted
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(380, 26)
        Me.LayoutControlItem2.Text = "Completed:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(84, 16)
        '
        'Travel_GTRS_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.Controls.Add(Me.LayoutControl_Main)
        Me.Name = "Travel_GTRS_List"
        CType(Me.dtCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.checkEditBookedWithGTravel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.checkEditBooked, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.checkEditCompleted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl_Main.ResumeLayout(False)
        CType(Me.cboCompleted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBookingType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRecordFilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Filters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VslName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TravelDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PlanningEvent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Port As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents isBooked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents checkEditBooked As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents isCompleted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents checkEditCompleted As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents StatusToolTip As DevExpress.Utils.ToolTipController
    Friend WithEvents LayoutControl_Main As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup_Main As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_Filters As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cboRecordFilter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BookedWithGTravel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents checkEditBookedWithGTravel As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cboBookingType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BookingStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents isUnread As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboCompleted As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem

End Class
