<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TravelEventV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TravelEventV2))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.FlightGrid = New DevExpress.XtraGrid.GridControl()
        Me.FlightView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Seq = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FKeyAirline = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AirlineEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Flight = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AirportFrom = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AirportEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.AirportTo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DepDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GenericDate2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DepTime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GenericTime = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ArrDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ArrTime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FlightStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.StatusEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CrewGrid = New DevExpress.XtraGrid.GridControl()
        Me.CrewView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CrewEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.FKeyRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.isEdited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TravelGrid = New DevExpress.XtraGrid.GridControl()
        Me.TravelView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn29 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn30 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn31 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn32 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn33 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn34 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BookingGrid = New DevExpress.XtraGrid.GridControl()
        Me.BookingView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BookingDetails = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BookingRef = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Status = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FKeyCurr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CurrencyEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.TicketCost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.InvoiceNbr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.InvoiceDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GenericDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.cboTravelAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboInvoiceTo = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboPortAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.deReqArrDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtArrPlace = New DevExpress.XtraEditors.TextEdit()
        Me.txtDepPlace = New DevExpress.XtraEditors.TextEdit()
        Me.cboPlaceSON = New DevExpress.XtraEditors.LookUpEdit()
        Me.deDateSON = New DevExpress.XtraEditors.DateEdit()
        Me.txtVessel = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LCGPlanDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciReqDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.FlightGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlightView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AirlineEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AirportEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDate2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericTime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TravelGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TravelView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookingGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookingView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenericDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTravelAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboInvoiceTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPortAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deReqArrDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deReqArrDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArrPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPlaceSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LCGPlanDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciReqDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.FlightGrid)
        Me.LayoutControl1.Controls.Add(Me.CrewGrid)
        Me.LayoutControl1.Controls.Add(Me.TravelGrid)
        Me.LayoutControl1.Controls.Add(Me.BookingGrid)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.cboTravelAgent)
        Me.LayoutControl1.Controls.Add(Me.cboInvoiceTo)
        Me.LayoutControl1.Controls.Add(Me.cboPortAgent)
        Me.LayoutControl1.Controls.Add(Me.deReqArrDate)
        Me.LayoutControl1.Controls.Add(Me.txtArrPlace)
        Me.LayoutControl1.Controls.Add(Me.txtDepPlace)
        Me.LayoutControl1.Controls.Add(Me.cboPlaceSON)
        Me.LayoutControl1.Controls.Add(Me.deDateSON)
        Me.LayoutControl1.Controls.Add(Me.txtVessel)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(689, 353, 250, 350)
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
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1231, 561)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'FlightGrid
        '
        Me.FlightGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlightGrid.Location = New System.Drawing.Point(279, 368)
        Me.FlightGrid.MainView = Me.FlightView
        Me.FlightGrid.Name = "FlightGrid"
        Me.FlightGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.AirlineEdit, Me.AirportEdit, Me.GenericDate2, Me.GenericTime, Me.StatusEdit})
        Me.FlightGrid.Size = New System.Drawing.Size(938, 179)
        Me.FlightGrid.TabIndex = 8
        Me.FlightGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FlightView})
        '
        'FlightView
        '
        Me.FlightView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand3})
        Me.FlightView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn17, Me.BandedGridColumn18, Me.Seq, Me.FKeyAirline, Me.Flight, Me.AirportFrom, Me.AirportTo, Me.DepDate, Me.DepTime, Me.ArrDate, Me.ArrTime, Me.FlightStatus, Me.BandedGridColumn8})
        Me.FlightView.GridControl = Me.FlightGrid
        Me.FlightView.Name = "FlightView"
        Me.FlightView.OptionsCustomization.AllowQuickHideColumns = False
        Me.FlightView.OptionsMenu.EnableColumnMenu = False
        Me.FlightView.OptionsView.ShowGroupPanel = False
        '
        'GridBand3
        '
        Me.GridBand3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand3.AppearanceHeader.Options.UseFont = True
        Me.GridBand3.Caption = "Flight Details"
        Me.GridBand3.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand3.Columns.Add(Me.Seq)
        Me.GridBand3.Columns.Add(Me.FKeyAirline)
        Me.GridBand3.Columns.Add(Me.Flight)
        Me.GridBand3.Columns.Add(Me.AirportFrom)
        Me.GridBand3.Columns.Add(Me.AirportTo)
        Me.GridBand3.Columns.Add(Me.DepDate)
        Me.GridBand3.Columns.Add(Me.DepTime)
        Me.GridBand3.Columns.Add(Me.ArrDate)
        Me.GridBand3.Columns.Add(Me.ArrTime)
        Me.GridBand3.Columns.Add(Me.FlightStatus)
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 0
        Me.GridBand3.Width = 1238
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "isEdited"
        Me.BandedGridColumn8.FieldName = "isEdited"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        '
        'Seq
        '
        Me.Seq.Caption = "Seq"
        Me.Seq.FieldName = "Seq"
        Me.Seq.Name = "Seq"
        Me.Seq.Visible = True
        '
        'FKeyAirline
        '
        Me.FKeyAirline.Caption = "Airline"
        Me.FKeyAirline.ColumnEdit = Me.AirlineEdit
        Me.FKeyAirline.FieldName = "FKeyAirline"
        Me.FKeyAirline.Name = "FKeyAirline"
        Me.FKeyAirline.Tag = "Required"
        Me.FKeyAirline.Visible = True
        Me.FKeyAirline.Width = 168
        '
        'AirlineEdit
        '
        Me.AirlineEdit.AutoHeight = False
        Me.AirlineEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AirlineEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.AirlineEdit.DisplayMember = "Name"
        Me.AirlineEdit.Name = "AirlineEdit"
        Me.AirlineEdit.NullText = ""
        Me.AirlineEdit.ShowFooter = False
        Me.AirlineEdit.ShowHeader = False
        Me.AirlineEdit.ValueMember = "PKey"
        '
        'Flight
        '
        Me.Flight.Caption = "Flight"
        Me.Flight.FieldName = "Flight"
        Me.Flight.Name = "Flight"
        Me.Flight.Tag = "Required"
        Me.Flight.Visible = True
        '
        'AirportFrom
        '
        Me.AirportFrom.Caption = "Airport From"
        Me.AirportFrom.ColumnEdit = Me.AirportEdit
        Me.AirportFrom.FieldName = "FKeyAirportFrom"
        Me.AirportFrom.Name = "AirportFrom"
        Me.AirportFrom.Tag = "Required"
        Me.AirportFrom.Visible = True
        Me.AirportFrom.Width = 154
        '
        'AirportEdit
        '
        Me.AirportEdit.AutoHeight = False
        Me.AirportEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AirportEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.AirportEdit.DisplayMember = "Name"
        Me.AirportEdit.Name = "AirportEdit"
        Me.AirportEdit.NullText = ""
        Me.AirportEdit.ShowFooter = False
        Me.AirportEdit.ShowHeader = False
        Me.AirportEdit.ValueMember = "PKey"
        '
        'AirportTo
        '
        Me.AirportTo.Caption = "Airport To"
        Me.AirportTo.ColumnEdit = Me.AirportEdit
        Me.AirportTo.FieldName = "FKeyAirportTo"
        Me.AirportTo.Name = "AirportTo"
        Me.AirportTo.Tag = "Required"
        Me.AirportTo.Visible = True
        Me.AirportTo.Width = 160
        '
        'DepDate
        '
        Me.DepDate.Caption = "ETD"
        Me.DepDate.ColumnEdit = Me.GenericDate2
        Me.DepDate.FieldName = "ETD"
        Me.DepDate.Name = "DepDate"
        Me.DepDate.Tag = "Required"
        Me.DepDate.Visible = True
        Me.DepDate.Width = 208
        '
        'GenericDate2
        '
        Me.GenericDate2.AutoHeight = False
        Me.GenericDate2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDate2.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[False]
        Me.GenericDate2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDate2.Mask.EditMask = "dd-MMM-yyyy HH:mm"
        Me.GenericDate2.Mask.UseMaskAsDisplayFormat = True
        Me.GenericDate2.Name = "GenericDate2"
        '
        'DepTime
        '
        Me.DepTime.Caption = "Dep Time"
        Me.DepTime.ColumnEdit = Me.GenericTime
        Me.DepTime.FieldName = "DepTime"
        Me.DepTime.Name = "DepTime"
        '
        'GenericTime
        '
        Me.GenericTime.AutoHeight = False
        Me.GenericTime.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericTime.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.GenericTime.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericTime.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.GenericTime.Mask.EditMask = "HH:mm"
        Me.GenericTime.Mask.UseMaskAsDisplayFormat = True
        Me.GenericTime.Name = "GenericTime"
        Me.GenericTime.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        '
        'ArrDate
        '
        Me.ArrDate.Caption = "ETA"
        Me.ArrDate.ColumnEdit = Me.GenericDate2
        Me.ArrDate.FieldName = "ETA"
        Me.ArrDate.Name = "ArrDate"
        Me.ArrDate.Tag = "Required"
        Me.ArrDate.Visible = True
        Me.ArrDate.Width = 205
        '
        'ArrTime
        '
        Me.ArrTime.Caption = "Arr Time"
        Me.ArrTime.ColumnEdit = Me.GenericTime
        Me.ArrTime.FieldName = "ArrTime"
        Me.ArrTime.Name = "ArrTime"
        '
        'FlightStatus
        '
        Me.FlightStatus.Caption = "Flight Status"
        Me.FlightStatus.ColumnEdit = Me.StatusEdit
        Me.FlightStatus.FieldName = "Status"
        Me.FlightStatus.Name = "FlightStatus"
        Me.FlightStatus.Tag = "Required"
        Me.FlightStatus.Visible = True
        Me.FlightStatus.Width = 193
        '
        'StatusEdit
        '
        Me.StatusEdit.AutoHeight = False
        Me.StatusEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StatusEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FlightStatus", "FlightStatus")})
        Me.StatusEdit.DisplayMember = "FlightStatus"
        Me.StatusEdit.Name = "StatusEdit"
        Me.StatusEdit.NullText = ""
        Me.StatusEdit.ShowFooter = False
        Me.StatusEdit.ShowHeader = False
        Me.StatusEdit.ValueMember = "FlightStatus"
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.Caption = "PKey"
        Me.BandedGridColumn17.FieldName = "PKey"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        '
        'BandedGridColumn18
        '
        Me.BandedGridColumn18.Caption = "FKeyBooking"
        Me.BandedGridColumn18.FieldName = "FKeyBookingDetail"
        Me.BandedGridColumn18.Name = "BandedGridColumn18"
        '
        'CrewGrid
        '
        Me.CrewGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CrewGrid.Location = New System.Drawing.Point(14, 248)
        Me.CrewGrid.MainView = Me.CrewView
        Me.CrewGrid.Name = "CrewGrid"
        Me.CrewGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CrewEdit})
        Me.CrewGrid.Size = New System.Drawing.Size(256, 299)
        Me.CrewGrid.TabIndex = 9
        Me.CrewGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CrewView})
        '
        'CrewView
        '
        Me.CrewView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.CrewView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn6, Me.BandedGridColumn7, Me.isEdited, Me.clmPKey, Me.FKeyRank})
        Me.CrewView.GridControl = Me.CrewGrid
        Me.CrewView.Name = "CrewView"
        Me.CrewView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.CrewView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CrewView.OptionsMenu.EnableColumnMenu = False
        Me.CrewView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.CrewView.OptionsView.ShowGroupPanel = False
        '
        'GridBand2
        '
        Me.GridBand2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand2.AppearanceHeader.Options.UseFont = True
        Me.GridBand2.Caption = "Crew List"
        Me.GridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand2.Columns.Add(Me.FKeyRank)
        Me.GridBand2.Columns.Add(Me.isEdited)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 75
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "Crew"
        Me.BandedGridColumn7.ColumnEdit = Me.CrewEdit
        Me.BandedGridColumn7.FieldName = "FKeyCrewID"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Visible = True
        '
        'CrewEdit
        '
        Me.CrewEdit.AutoHeight = False
        Me.CrewEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CrewEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CrewName", "CrewName"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CrewID", "CrewID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.CrewEdit.DisplayMember = "CrewName"
        Me.CrewEdit.Name = "CrewEdit"
        Me.CrewEdit.NullText = ""
        Me.CrewEdit.ShowFooter = False
        Me.CrewEdit.ShowHeader = False
        Me.CrewEdit.ValueMember = "CrewID"
        '
        'FKeyRank
        '
        Me.FKeyRank.FieldName = "FKeyRank"
        Me.FKeyRank.Name = "FKeyRank"
        '
        'isEdited
        '
        Me.isEdited.FieldName = "isEdited"
        Me.isEdited.Name = "isEdited"
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "FKeyTravelEvent"
        Me.BandedGridColumn6.FieldName = "FKeyTravelEvent"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        '
        'clmPKey
        '
        Me.clmPKey.FieldName = "PKey"
        Me.clmPKey.Name = "clmPKey"
        '
        'TravelGrid
        '
        Me.TravelGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TravelGrid.Location = New System.Drawing.Point(14, 112)
        Me.TravelGrid.MainView = Me.TravelView
        Me.TravelGrid.Name = "TravelGrid"
        Me.TravelGrid.Size = New System.Drawing.Size(256, 127)
        Me.TravelGrid.TabIndex = 16
        Me.TravelGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TravelView})
        '
        'TravelView
        '
        Me.TravelView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.TravelView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn29, Me.BandedGridColumn30, Me.BandedGridColumn31, Me.BandedGridColumn32, Me.BandedGridColumn33, Me.BandedGridColumn34})
        Me.TravelView.GridControl = Me.TravelGrid
        Me.TravelView.Name = "TravelView"
        Me.TravelView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.TravelView.OptionsBehavior.Editable = False
        Me.TravelView.OptionsBehavior.ReadOnly = True
        Me.TravelView.OptionsCustomization.AllowGroup = False
        Me.TravelView.OptionsCustomization.AllowQuickHideColumns = False
        Me.TravelView.OptionsFind.AllowFindPanel = False
        Me.TravelView.OptionsMenu.EnableColumnMenu = False
        Me.TravelView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Travel Events"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 150
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Departing Place"
        Me.BandedGridColumn3.FieldName = "DepPlace"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn3.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn3.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Req Arr Date"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn4.FieldName = "ReqArrDate"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.OptionsColumn.AllowFocus = False
        Me.BandedGridColumn4.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "PKey"
        Me.BandedGridColumn1.FieldName = "PKey"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "FKeyPlanningEvent"
        Me.BandedGridColumn2.FieldName = "FKeyPlanningEvent"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        '
        'BandedGridColumn29
        '
        Me.BandedGridColumn29.Caption = "DateReq"
        Me.BandedGridColumn29.FieldName = "DateReq"
        Me.BandedGridColumn29.Name = "BandedGridColumn29"
        '
        'BandedGridColumn30
        '
        Me.BandedGridColumn30.Caption = "FKeyPortAgent"
        Me.BandedGridColumn30.FieldName = "FKeyPortAgent"
        Me.BandedGridColumn30.Name = "BandedGridColumn30"
        '
        'BandedGridColumn31
        '
        Me.BandedGridColumn31.Caption = "FKeyPrincipal"
        Me.BandedGridColumn31.FieldName = "FKeyPrincipal"
        Me.BandedGridColumn31.Name = "BandedGridColumn31"
        '
        'BandedGridColumn32
        '
        Me.BandedGridColumn32.Caption = "FKeyTravelAgent"
        Me.BandedGridColumn32.FieldName = "FKeyTravelAgent"
        Me.BandedGridColumn32.Name = "BandedGridColumn32"
        '
        'BandedGridColumn33
        '
        Me.BandedGridColumn33.Caption = "Remarks"
        Me.BandedGridColumn33.FieldName = "Remarks"
        Me.BandedGridColumn33.Name = "BandedGridColumn33"
        '
        'BandedGridColumn34
        '
        Me.BandedGridColumn34.Caption = "ArrPlace"
        Me.BandedGridColumn34.FieldName = "ArrPlace"
        Me.BandedGridColumn34.Name = "BandedGridColumn34"
        '
        'BookingGrid
        '
        Me.BookingGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BookingGrid.Location = New System.Drawing.Point(279, 242)
        Me.BookingGrid.MainView = Me.BookingView
        Me.BookingGrid.Name = "BookingGrid"
        Me.BookingGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CurrencyEdit, Me.GenericDate})
        Me.BookingGrid.Size = New System.Drawing.Size(938, 122)
        Me.BookingGrid.TabIndex = 7
        Me.BookingGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BookingView})
        '
        'BookingView
        '
        Me.BookingView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.BookingDetails})
        Me.BookingView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BookingRef, Me.Status, Me.FKeyCurr, Me.TicketCost, Me.InvoiceNbr, Me.InvoiceDate, Me.BandedGridColumn5})
        Me.BookingView.GridControl = Me.BookingGrid
        Me.BookingView.Name = "BookingView"
        Me.BookingView.OptionsCustomization.AllowQuickHideColumns = False
        Me.BookingView.OptionsMenu.EnableColumnMenu = False
        Me.BookingView.OptionsView.ShowGroupPanel = False
        '
        'BookingDetails
        '
        Me.BookingDetails.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BookingDetails.AppearanceHeader.Options.UseFont = True
        Me.BookingDetails.Caption = "Booking Details"
        Me.BookingDetails.Columns.Add(Me.BandedGridColumn5)
        Me.BookingDetails.Columns.Add(Me.BookingRef)
        Me.BookingDetails.Columns.Add(Me.Status)
        Me.BookingDetails.Columns.Add(Me.FKeyCurr)
        Me.BookingDetails.Columns.Add(Me.TicketCost)
        Me.BookingDetails.Columns.Add(Me.InvoiceNbr)
        Me.BookingDetails.Columns.Add(Me.InvoiceDate)
        Me.BookingDetails.Name = "BookingDetails"
        Me.BookingDetails.VisibleIndex = 0
        Me.BookingDetails.Width = 375
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "BandedGridColumn5"
        Me.BandedGridColumn5.FieldName = "isEdited"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        '
        'BookingRef
        '
        Me.BookingRef.Caption = "Booking Reference"
        Me.BookingRef.FieldName = "BookingRef"
        Me.BookingRef.Name = "BookingRef"
        Me.BookingRef.Tag = "Required"
        Me.BookingRef.Visible = True
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.OptionsColumn.AllowEdit = False
        Me.Status.OptionsColumn.AllowFocus = False
        Me.Status.OptionsColumn.ReadOnly = True
        Me.Status.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'FKeyCurr
        '
        Me.FKeyCurr.Caption = "Currency"
        Me.FKeyCurr.ColumnEdit = Me.CurrencyEdit
        Me.FKeyCurr.FieldName = "FKeyCurrency"
        Me.FKeyCurr.Name = "FKeyCurr"
        Me.FKeyCurr.Visible = True
        '
        'CurrencyEdit
        '
        Me.CurrencyEdit.AutoHeight = False
        Me.CurrencyEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol")})
        Me.CurrencyEdit.DisplayMember = "Symbol"
        Me.CurrencyEdit.Name = "CurrencyEdit"
        Me.CurrencyEdit.NullText = ""
        Me.CurrencyEdit.ShowFooter = False
        Me.CurrencyEdit.ShowHeader = False
        Me.CurrencyEdit.ValueMember = "PKey"
        '
        'TicketCost
        '
        Me.TicketCost.Caption = "Ticket Cost"
        Me.TicketCost.DisplayFormat.FormatString = "n2"
        Me.TicketCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TicketCost.FieldName = "TicketCost"
        Me.TicketCost.Name = "TicketCost"
        Me.TicketCost.Visible = True
        '
        'InvoiceNbr
        '
        Me.InvoiceNbr.Caption = "Invoice Nbr"
        Me.InvoiceNbr.FieldName = "InvoiceNbr"
        Me.InvoiceNbr.Name = "InvoiceNbr"
        Me.InvoiceNbr.Visible = True
        '
        'InvoiceDate
        '
        Me.InvoiceDate.Caption = "Invoice Date"
        Me.InvoiceDate.ColumnEdit = Me.GenericDate
        Me.InvoiceDate.FieldName = "InvoiceDate"
        Me.InvoiceDate.Name = "InvoiceDate"
        Me.InvoiceDate.Visible = True
        '
        'GenericDate
        '
        Me.GenericDate.AutoHeight = False
        Me.GenericDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GenericDate.Mask.EditMask = "dd-MMM-yyyy"
        Me.GenericDate.Mask.UseMaskAsDisplayFormat = True
        Me.GenericDate.Name = "GenericDate"
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "PKey"
        Me.BandedGridColumn9.FieldName = "PKey"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.Caption = "FKeyTravelEvent"
        Me.BandedGridColumn10.FieldName = "FKeyTravelEvent"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(827, 138)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(390, 74)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 6
        '
        'cboTravelAgent
        '
        Me.cboTravelAgent.Location = New System.Drawing.Point(827, 112)
        Me.cboTravelAgent.Name = "cboTravelAgent"
        Me.cboTravelAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTravelAgent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboTravelAgent.Properties.DisplayMember = "Name"
        Me.cboTravelAgent.Properties.NullText = ""
        Me.cboTravelAgent.Properties.ShowFooter = False
        Me.cboTravelAgent.Properties.ShowHeader = False
        Me.cboTravelAgent.Properties.ValueMember = "PKey"
        Me.cboTravelAgent.Size = New System.Drawing.Size(390, 22)
        Me.cboTravelAgent.StyleController = Me.LayoutControl1
        Me.cboTravelAgent.TabIndex = 5
        '
        'cboInvoiceTo
        '
        Me.cboInvoiceTo.Location = New System.Drawing.Point(391, 216)
        Me.cboInvoiceTo.Name = "cboInvoiceTo"
        Me.cboInvoiceTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboInvoiceTo.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboInvoiceTo.Properties.DisplayMember = "Name"
        Me.cboInvoiceTo.Properties.NullText = ""
        Me.cboInvoiceTo.Properties.ShowFooter = False
        Me.cboInvoiceTo.Properties.ShowHeader = False
        Me.cboInvoiceTo.Properties.ValueMember = "PKey"
        Me.cboInvoiceTo.Size = New System.Drawing.Size(305, 22)
        Me.cboInvoiceTo.StyleController = Me.LayoutControl1
        Me.cboInvoiceTo.TabIndex = 4
        '
        'cboPortAgent
        '
        Me.cboPortAgent.Location = New System.Drawing.Point(391, 190)
        Me.cboPortAgent.Name = "cboPortAgent"
        Me.cboPortAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPortAgent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboPortAgent.Properties.DisplayMember = "Name"
        Me.cboPortAgent.Properties.NullText = ""
        Me.cboPortAgent.Properties.ShowFooter = False
        Me.cboPortAgent.Properties.ShowHeader = False
        Me.cboPortAgent.Properties.ValueMember = "PKey"
        Me.cboPortAgent.Size = New System.Drawing.Size(305, 22)
        Me.cboPortAgent.StyleController = Me.LayoutControl1
        Me.cboPortAgent.TabIndex = 3
        '
        'deReqArrDate
        '
        Me.deReqArrDate.EditValue = Nothing
        Me.deReqArrDate.Location = New System.Drawing.Point(391, 164)
        Me.deReqArrDate.Name = "deReqArrDate"
        Me.deReqArrDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deReqArrDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deReqArrDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deReqArrDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deReqArrDate.Size = New System.Drawing.Size(305, 22)
        Me.deReqArrDate.StyleController = Me.LayoutControl1
        Me.deReqArrDate.TabIndex = 2
        '
        'txtArrPlace
        '
        Me.txtArrPlace.Location = New System.Drawing.Point(391, 138)
        Me.txtArrPlace.Name = "txtArrPlace"
        Me.txtArrPlace.Size = New System.Drawing.Size(305, 22)
        Me.txtArrPlace.StyleController = Me.LayoutControl1
        Me.txtArrPlace.TabIndex = 1
        '
        'txtDepPlace
        '
        Me.txtDepPlace.Location = New System.Drawing.Point(391, 112)
        Me.txtDepPlace.Name = "txtDepPlace"
        Me.txtDepPlace.Size = New System.Drawing.Size(305, 22)
        Me.txtDepPlace.StyleController = Me.LayoutControl1
        Me.txtDepPlace.TabIndex = 0
        '
        'cboPlaceSON
        '
        Me.cboPlaceSON.Location = New System.Drawing.Point(781, 38)
        Me.cboPlaceSON.Name = "cboPlaceSON"
        Me.cboPlaceSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPlaceSON.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboPlaceSON.Properties.DisplayMember = "Name"
        Me.cboPlaceSON.Properties.NullText = ""
        Me.cboPlaceSON.Properties.ShowFooter = False
        Me.cboPlaceSON.Properties.ShowHeader = False
        Me.cboPlaceSON.Properties.ValueMember = "PKey"
        Me.cboPlaceSON.Size = New System.Drawing.Size(436, 22)
        Me.cboPlaceSON.StyleController = Me.LayoutControl1
        Me.cboPlaceSON.TabIndex = 6
        '
        'deDateSON
        '
        Me.deDateSON.EditValue = Nothing
        Me.deDateSON.Location = New System.Drawing.Point(472, 38)
        Me.deDateSON.Name = "deDateSON"
        Me.deDateSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSON.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSON.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.deDateSON.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.deDateSON.Properties.ReadOnly = True
        Me.deDateSON.Size = New System.Drawing.Size(178, 22)
        Me.deDateSON.StyleController = Me.LayoutControl1
        Me.deDateSON.TabIndex = 5
        '
        'txtVessel
        '
        Me.txtVessel.Location = New System.Drawing.Point(123, 38)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Properties.ReadOnly = True
        Me.txtVessel.Size = New System.Drawing.Size(218, 22)
        Me.txtVessel.StyleController = Me.LayoutControl1
        Me.txtVessel.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LCGPlanDetails, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1231, 561)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LCGPlanDetails
        '
        Me.LCGPlanDetails.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCGPlanDetails.AppearanceGroup.Options.UseFont = True
        Me.LCGPlanDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LCGPlanDetails.Location = New System.Drawing.Point(0, 0)
        Me.LCGPlanDetails.Name = "LCGPlanDetails"
        Me.LCGPlanDetails.Size = New System.Drawing.Size(1231, 74)
        Me.LCGPlanDetails.Text = "Planning Details"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtVessel
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(331, 26)
        Me.LayoutControlItem1.Text = " Vessel: "
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.deDateSON
        Me.LayoutControlItem2.Location = New System.Drawing.Point(331, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 2, 2, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(309, 26)
        Me.LayoutControlItem2.Text = " Date Sign-on:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cboPlaceSON
        Me.LayoutControlItem3.Location = New System.Drawing.Point(640, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 2, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(567, 26)
        Me.LayoutControlItem3.Text = " Place Sign-on:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5, Me.lciReqDate, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.LayoutControlItem12, Me.LayoutControlItem11, Me.LayoutControlItem13, Me.SplitterItem2, Me.LayoutControlItem14, Me.SplitterItem1})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 74)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1231, 487)
        Me.LayoutControlGroup3.Text = "Travel Event Details"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtDepPlace
        Me.LayoutControlItem4.Location = New System.Drawing.Point(265, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(421, 26)
        Me.LayoutControlItem4.Text = "* Departing Place:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtArrPlace
        Me.LayoutControlItem5.Location = New System.Drawing.Point(265, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(421, 26)
        Me.LayoutControlItem5.Text = "* Arrival Place:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(106, 16)
        '
        'lciReqDate
        '
        Me.lciReqDate.Control = Me.deReqArrDate
        Me.lciReqDate.Location = New System.Drawing.Point(265, 52)
        Me.lciReqDate.Name = "lciReqDate"
        Me.lciReqDate.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.lciReqDate.Size = New System.Drawing.Size(421, 26)
        Me.lciReqDate.Text = "* Req Arr Date:"
        Me.lciReqDate.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cboPortAgent
        Me.LayoutControlItem7.Location = New System.Drawing.Point(265, 78)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(421, 26)
        Me.LayoutControlItem7.Text = "* Port Agent:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cboInvoiceTo
        Me.LayoutControlItem8.Location = New System.Drawing.Point(265, 104)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(421, 26)
        Me.LayoutControlItem8.Text = "* Invoice To:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cboTravelAgent
        Me.LayoutControlItem9.Location = New System.Drawing.Point(686, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 2, 2, 2)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(521, 26)
        Me.LayoutControlItem9.Text = "Travel Agent:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem10.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.LayoutControlItem10.Control = Me.txtRemarks
        Me.LayoutControlItem10.Location = New System.Drawing.Point(686, 26)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 2, 2, 2)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(521, 78)
        Me.LayoutControlItem10.Text = "Remarks:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(106, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(686, 104)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(521, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.BookingGrid
        Me.LayoutControlItem12.Location = New System.Drawing.Point(265, 130)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(942, 126)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.TravelGrid
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(260, 131)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.CrewGrid
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 136)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(260, 303)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 131)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(260, 5)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.FlightGrid
        Me.LayoutControlItem14.Location = New System.Drawing.Point(265, 256)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(942, 183)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(260, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(5, 439)
        '
        'TravelEventV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "TravelEventV2"
        Me.Size = New System.Drawing.Size(1231, 561)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.FlightGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlightView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AirlineEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AirportEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDate2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericTime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TravelGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TravelView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookingGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookingView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenericDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTravelAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboInvoiceTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPortAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deReqArrDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deReqArrDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArrPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPlaceSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LCGPlanDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciReqDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtVessel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LCGPlanDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents deDateSON As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboPlaceSON As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtDepPlace As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtArrPlace As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents deReqArrDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lciReqDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboPortAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboTravelAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboInvoiceTo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BookingGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BookingView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents TravelGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TravelView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents CrewGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents CrewView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BookingRef As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FKeyCurr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TicketCost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents InvoiceNbr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents InvoiceDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FlightGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents FlightView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents Seq As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FKeyAirline As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Flight As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AirportFrom As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AirportTo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DepDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DepTime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ArrDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ArrTime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FlightStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CurrencyEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GenericDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents AirlineEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents AirportEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GenericDate2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GenericTime As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CrewEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BandedGridColumn29 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn30 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn31 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn32 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn33 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn34 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents StatusEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents isEdited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BookingDetails As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents clmPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FKeyRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
