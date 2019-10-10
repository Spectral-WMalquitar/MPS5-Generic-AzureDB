<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TravelEvent
    Inherits BaseControl.BaseControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TravelEvent))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.gvFlightDetails = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.clmFlightID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmFKeyBookingDetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmSeq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.seqEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.clmAirline = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.airlineEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmFlight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmAirportFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.airportEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmAirportTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmETD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateTimeEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.clmETA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmFlightStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.statusEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcBookingDetails = New DevExpress.XtraGrid.GridControl()
        Me.gvBookingDetails = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmBookingRef = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmCurrency = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.currencyEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.clmTicketCost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmInvoiceNbr = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmInvoiceDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.genericDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.clmRmks = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmBookingID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.DateEdit3 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit7 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit6 = New DevExpress.XtraEditors.TextEdit()
        Me.LookUpEdit6 = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookUpEdit5 = New DevExpress.XtraEditors.LookUpEdit()
        Me.TextEdit5 = New DevExpress.XtraEditors.TextEdit()
        Me.lcRight = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lcLeft = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.LookUpEdit4 = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookUpEdit3 = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookUpEdit2 = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LayoutControl5 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtArrPlace = New DevExpress.XtraEditors.TextEdit()
        Me.W = New DevExpress.XtraEditors.MemoEdit()
        Me.leTravelAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.leInvoiceTo = New DevExpress.XtraEditors.LookUpEdit()
        Me.lePortAgent = New DevExpress.XtraEditors.LookUpEdit()
        Me.deDateReq = New DevExpress.XtraEditors.DateEdit()
        Me.deReqDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtPlace = New DevExpress.XtraEditors.TextEdit()
        Me.txtVsl = New DevExpress.XtraEditors.TextEdit()
        Me.deDateSign = New DevExpress.XtraEditors.DateEdit()
        Me.luPlaceSign = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lblPlaceSign = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lblReqDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lblPlace = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lblDateSign = New DevExpress.XtraLayout.LayoutControlItem()
        Me.gcCrewList = New DevExpress.XtraGrid.GridControl()
        Me.gvCrewList = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.clmCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmRank = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmSelect = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmCrewID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyTravelEvent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmDepPlace = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmReqArrDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.clmFKeyPlanningEvent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SplitContainerControl3 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvFlightDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seqEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.airlineEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.airportEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statusEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcBookingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvBookingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.currencyEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl4.SuspendLayout()
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lcLeft.SuspendLayout()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl5.SuspendLayout()
        CType(Me.txtArrPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.W.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leTravelAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leInvoiceTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lePortAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateReq.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateReq.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deReqDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deReqDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVsl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSign.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateSign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.luPlaceSign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlaceSign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReqDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDateSign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCrewList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl3.SuspendLayout()
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
        'gvFlightDetails
        '
        Me.gvFlightDetails.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.clmFlightID, Me.clmFKeyBookingDetail, Me.clmSeq, Me.clmAirline, Me.clmFlight, Me.clmAirportFrom, Me.clmAirportTo, Me.clmETD, Me.clmETA, Me.clmFlightStatus, Me.clm})
        Me.gvFlightDetails.GridControl = Me.gcBookingDetails
        Me.gvFlightDetails.Name = "gvFlightDetails"
        Me.gvFlightDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvFlightDetails.OptionsMenu.EnableColumnMenu = False
        Me.gvFlightDetails.OptionsMenu.EnableFooterMenu = False
        Me.gvFlightDetails.OptionsMenu.EnableGroupPanelMenu = False
        Me.gvFlightDetails.OptionsView.ShowGroupPanel = False
        '
        'clmFlightID
        '
        Me.clmFlightID.FieldName = "PKey"
        Me.clmFlightID.Name = "clmFlightID"
        '
        'clmFKeyBookingDetail
        '
        Me.clmFKeyBookingDetail.FieldName = "FKeyBookingDetail"
        Me.clmFKeyBookingDetail.Name = "clmFKeyBookingDetail"
        '
        'clmSeq
        '
        Me.clmSeq.Caption = "Seq"
        Me.clmSeq.ColumnEdit = Me.seqEdit
        Me.clmSeq.FieldName = "Seq"
        Me.clmSeq.Name = "clmSeq"
        Me.clmSeq.Visible = True
        Me.clmSeq.VisibleIndex = 0
        Me.clmSeq.Width = 37
        '
        'seqEdit
        '
        Me.seqEdit.AutoHeight = False
        Me.seqEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.seqEdit.MaxLength = 2
        Me.seqEdit.Name = "seqEdit"
        '
        'clmAirline
        '
        Me.clmAirline.Caption = "Airline"
        Me.clmAirline.ColumnEdit = Me.airlineEdit
        Me.clmAirline.FieldName = "FKeyAirline"
        Me.clmAirline.Name = "clmAirline"
        Me.clmAirline.Tag = "Required"
        Me.clmAirline.Visible = True
        Me.clmAirline.VisibleIndex = 1
        Me.clmAirline.Width = 143
        '
        'airlineEdit
        '
        Me.airlineEdit.AutoHeight = False
        Me.airlineEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.airlineEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.airlineEdit.DisplayMember = "Name"
        Me.airlineEdit.Name = "airlineEdit"
        Me.airlineEdit.NullText = ""
        Me.airlineEdit.ShowFooter = False
        Me.airlineEdit.ShowHeader = False
        Me.airlineEdit.ValueMember = "PKey"
        '
        'clmFlight
        '
        Me.clmFlight.Caption = "Flight Number"
        Me.clmFlight.FieldName = "Flight"
        Me.clmFlight.Name = "clmFlight"
        Me.clmFlight.Tag = "Required"
        Me.clmFlight.Visible = True
        Me.clmFlight.VisibleIndex = 2
        Me.clmFlight.Width = 143
        '
        'clmAirportFrom
        '
        Me.clmAirportFrom.Caption = "From"
        Me.clmAirportFrom.ColumnEdit = Me.airportEdit
        Me.clmAirportFrom.FieldName = "FKeyAirportFrom"
        Me.clmAirportFrom.Name = "clmAirportFrom"
        Me.clmAirportFrom.Tag = "Required"
        Me.clmAirportFrom.Visible = True
        Me.clmAirportFrom.VisibleIndex = 3
        Me.clmAirportFrom.Width = 143
        '
        'airportEdit
        '
        Me.airportEdit.AutoHeight = False
        Me.airportEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.airportEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.airportEdit.DisplayMember = "Name"
        Me.airportEdit.Name = "airportEdit"
        Me.airportEdit.NullText = ""
        Me.airportEdit.ShowFooter = False
        Me.airportEdit.ShowHeader = False
        Me.airportEdit.ValueMember = "PKey"
        '
        'clmAirportTo
        '
        Me.clmAirportTo.Caption = "To"
        Me.clmAirportTo.ColumnEdit = Me.airportEdit
        Me.clmAirportTo.FieldName = "FKeyAirportTo"
        Me.clmAirportTo.Name = "clmAirportTo"
        Me.clmAirportTo.Tag = "Required"
        Me.clmAirportTo.Visible = True
        Me.clmAirportTo.VisibleIndex = 4
        Me.clmAirportTo.Width = 143
        '
        'clmETD
        '
        Me.clmETD.Caption = "ETD"
        Me.clmETD.ColumnEdit = Me.DateTimeEdit
        Me.clmETD.FieldName = "ETD"
        Me.clmETD.Name = "clmETD"
        Me.clmETD.Tag = "Required"
        Me.clmETD.Visible = True
        Me.clmETD.VisibleIndex = 5
        Me.clmETD.Width = 143
        '
        'DateTimeEdit
        '
        Me.DateTimeEdit.AutoHeight = False
        Me.DateTimeEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTimeEdit.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateTimeEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTimeEdit.EditFormat.FormatString = "g"
        Me.DateTimeEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateTimeEdit.Name = "DateTimeEdit"
        '
        'clmETA
        '
        Me.clmETA.Caption = "ETA"
        Me.clmETA.ColumnEdit = Me.DateTimeEdit
        Me.clmETA.FieldName = "ETA"
        Me.clmETA.Name = "clmETA"
        Me.clmETA.Tag = "Required"
        Me.clmETA.Visible = True
        Me.clmETA.VisibleIndex = 6
        Me.clmETA.Width = 143
        '
        'clmFlightStatus
        '
        Me.clmFlightStatus.Caption = "Status"
        Me.clmFlightStatus.ColumnEdit = Me.statusEdit
        Me.clmFlightStatus.FieldName = "Status"
        Me.clmFlightStatus.Name = "clmFlightStatus"
        Me.clmFlightStatus.Tag = "Required"
        Me.clmFlightStatus.Visible = True
        Me.clmFlightStatus.VisibleIndex = 7
        '
        'statusEdit
        '
        Me.statusEdit.AutoHeight = False
        Me.statusEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.statusEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status")})
        Me.statusEdit.DisplayMember = "Status"
        Me.statusEdit.Name = "statusEdit"
        Me.statusEdit.NullText = ""
        Me.statusEdit.ShowFooter = False
        Me.statusEdit.ShowHeader = False
        Me.statusEdit.ValueMember = "Status"
        '
        'clm
        '
        Me.clm.Caption = "Rmks"
        Me.clm.FieldName = "Rmks"
        Me.clm.Name = "clm"
        '
        'gcBookingDetails
        '
        Me.gcBookingDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcBookingDetails.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        GridLevelNode1.LevelTemplate = Me.gvFlightDetails
        GridLevelNode1.RelationName = "Level1"
        Me.gcBookingDetails.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.gcBookingDetails.Location = New System.Drawing.Point(0, 0)
        Me.gcBookingDetails.MainView = Me.gvBookingDetails
        Me.gcBookingDetails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcBookingDetails.Name = "gcBookingDetails"
        Me.gcBookingDetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.currencyEdit, Me.DateTimeEdit, Me.genericDateEdit, Me.airportEdit, Me.statusEdit, Me.airlineEdit, Me.seqEdit})
        Me.gcBookingDetails.Size = New System.Drawing.Size(792, 353)
        Me.gcBookingDetails.TabIndex = 11
        Me.gcBookingDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvBookingDetails, Me.gvFlightDetails})
        '
        'gvBookingDetails
        '
        Me.gvBookingDetails.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.gvBookingDetails.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.clmBookingID, Me.clmBookingRef, Me.clmStatus, Me.clmCurrency, Me.clmTicketCost, Me.clmInvoiceNbr, Me.clmInvoiceDate, Me.clmRmks})
        Me.gvBookingDetails.GridControl = Me.gcBookingDetails
        Me.gvBookingDetails.Name = "gvBookingDetails"
        Me.gvBookingDetails.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvBookingDetails.OptionsDetail.AllowExpandEmptyDetails = True
        Me.gvBookingDetails.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails
        Me.gvBookingDetails.OptionsMenu.EnableColumnMenu = False
        Me.gvBookingDetails.OptionsView.ShowGroupPanel = False
        '
        'GridBand2
        '
        Me.GridBand2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand2.AppearanceHeader.Options.UseFont = True
        Me.GridBand2.Caption = "Booking Details"
        Me.GridBand2.Columns.Add(Me.clmBookingRef)
        Me.GridBand2.Columns.Add(Me.clmStatus)
        Me.GridBand2.Columns.Add(Me.clmCurrency)
        Me.GridBand2.Columns.Add(Me.clmTicketCost)
        Me.GridBand2.Columns.Add(Me.clmInvoiceNbr)
        Me.GridBand2.Columns.Add(Me.clmInvoiceDate)
        Me.GridBand2.Columns.Add(Me.clmRmks)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 450
        '
        'clmBookingRef
        '
        Me.clmBookingRef.Caption = "Booking Reference"
        Me.clmBookingRef.FieldName = "BookingRef"
        Me.clmBookingRef.Name = "clmBookingRef"
        Me.clmBookingRef.Tag = "Required"
        Me.clmBookingRef.Visible = True
        '
        'clmStatus
        '
        Me.clmStatus.Caption = "Status"
        Me.clmStatus.FieldName = "BookingStatus"
        Me.clmStatus.Name = "clmStatus"
        Me.clmStatus.OptionsColumn.AllowEdit = False
        Me.clmStatus.OptionsColumn.ReadOnly = True
        Me.clmStatus.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.clmStatus.Visible = True
        '
        'clmCurrency
        '
        Me.clmCurrency.Caption = "Currency"
        Me.clmCurrency.ColumnEdit = Me.currencyEdit
        Me.clmCurrency.FieldName = "FKeyCurrency"
        Me.clmCurrency.Name = "clmCurrency"
        Me.clmCurrency.Tag = ""
        Me.clmCurrency.Visible = True
        '
        'currencyEdit
        '
        Me.currencyEdit.AutoHeight = False
        Me.currencyEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.currencyEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.currencyEdit.DisplayMember = "Name"
        Me.currencyEdit.Name = "currencyEdit"
        Me.currencyEdit.NullText = ""
        Me.currencyEdit.ShowFooter = False
        Me.currencyEdit.ShowHeader = False
        Me.currencyEdit.ValueMember = "PKey"
        '
        'clmTicketCost
        '
        Me.clmTicketCost.Caption = "Ticket Cost"
        Me.clmTicketCost.DisplayFormat.FormatString = "n2"
        Me.clmTicketCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.clmTicketCost.FieldName = "TicketCost"
        Me.clmTicketCost.Name = "clmTicketCost"
        Me.clmTicketCost.Tag = ""
        Me.clmTicketCost.Visible = True
        '
        'clmInvoiceNbr
        '
        Me.clmInvoiceNbr.Caption = "Invoice Nbr"
        Me.clmInvoiceNbr.FieldName = "InvoiceNbr"
        Me.clmInvoiceNbr.Name = "clmInvoiceNbr"
        Me.clmInvoiceNbr.Visible = True
        '
        'clmInvoiceDate
        '
        Me.clmInvoiceDate.Caption = "Invoice Date"
        Me.clmInvoiceDate.ColumnEdit = Me.genericDateEdit
        Me.clmInvoiceDate.FieldName = "InvoiceDate"
        Me.clmInvoiceDate.Name = "clmInvoiceDate"
        Me.clmInvoiceDate.Visible = True
        '
        'genericDateEdit
        '
        Me.genericDateEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.genericDateEdit.AutoHeight = False
        Me.genericDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.genericDateEdit.Name = "genericDateEdit"
        '
        'clmRmks
        '
        Me.clmRmks.Caption = "Rmks"
        Me.clmRmks.FieldName = "Rmks"
        Me.clmRmks.Name = "clmRmks"
        '
        'clmBookingID
        '
        Me.clmBookingID.FieldName = "PKey"
        Me.clmBookingID.Name = "clmBookingID"
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.DateEdit3)
        Me.LayoutControl4.Controls.Add(Me.TextEdit7)
        Me.LayoutControl4.Controls.Add(Me.TextEdit6)
        Me.LayoutControl4.Controls.Add(Me.LookUpEdit6)
        Me.LayoutControl4.Controls.Add(Me.LookUpEdit5)
        Me.LayoutControl4.Controls.Add(Me.TextEdit5)
        Me.LayoutControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl4.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl4.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl4.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl4.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl4.Root = Me.lcRight
        Me.LayoutControl4.Size = New System.Drawing.Size(311, 237)
        Me.LayoutControl4.TabIndex = 0
        '
        'DateEdit3
        '
        Me.DateEdit3.EditValue = Nothing
        Me.DateEdit3.Location = New System.Drawing.Point(100, 173)
        Me.DateEdit3.Name = "DateEdit3"
        Me.DateEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit3.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit3.Size = New System.Drawing.Size(197, 22)
        Me.DateEdit3.StyleController = Me.LayoutControl4
        Me.DateEdit3.TabIndex = 9
        '
        'TextEdit7
        '
        Me.TextEdit7.Location = New System.Drawing.Point(100, 146)
        Me.TextEdit7.Name = "TextEdit7"
        Me.TextEdit7.Size = New System.Drawing.Size(197, 22)
        Me.TextEdit7.StyleController = Me.LayoutControl4
        Me.TextEdit7.TabIndex = 8
        '
        'TextEdit6
        '
        Me.TextEdit6.Location = New System.Drawing.Point(100, 119)
        Me.TextEdit6.Name = "TextEdit6"
        Me.TextEdit6.Size = New System.Drawing.Size(197, 22)
        Me.TextEdit6.StyleController = Me.LayoutControl4
        Me.TextEdit6.TabIndex = 7
        '
        'LookUpEdit6
        '
        Me.LookUpEdit6.Location = New System.Drawing.Point(100, 92)
        Me.LookUpEdit6.Name = "LookUpEdit6"
        Me.LookUpEdit6.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit6.Size = New System.Drawing.Size(197, 22)
        Me.LookUpEdit6.StyleController = Me.LayoutControl4
        Me.LookUpEdit6.TabIndex = 6
        '
        'LookUpEdit5
        '
        Me.LookUpEdit5.Location = New System.Drawing.Point(100, 65)
        Me.LookUpEdit5.Name = "LookUpEdit5"
        Me.LookUpEdit5.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit5.Size = New System.Drawing.Size(197, 22)
        Me.LookUpEdit5.StyleController = Me.LayoutControl4
        Me.LookUpEdit5.TabIndex = 5
        '
        'TextEdit5
        '
        Me.TextEdit5.Location = New System.Drawing.Point(100, 38)
        Me.TextEdit5.Name = "TextEdit5"
        Me.TextEdit5.Size = New System.Drawing.Size(197, 22)
        Me.TextEdit5.StyleController = Me.LayoutControl4
        Me.TextEdit5.TabIndex = 4
        '
        'lcRight
        '
        Me.lcRight.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.lcRight.GroupBordersVisible = False
        Me.lcRight.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup4})
        Me.lcRight.Location = New System.Drawing.Point(0, 0)
        Me.lcRight.Name = "lcRight"
        Me.lcRight.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lcRight.Size = New System.Drawing.Size(311, 237)
        Me.lcRight.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup4.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LayoutControlItem19})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(311, 237)
        Me.LayoutControlGroup4.Text = "Booking Details and Costs"
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.TextEdit5
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(0, 27)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(129, 27)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5)
        Me.LayoutControlItem14.Size = New System.Drawing.Size(287, 27)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "Booking Ref : "
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.LookUpEdit5
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControlItem15.MaxSize = New System.Drawing.Size(0, 27)
        Me.LayoutControlItem15.MinSize = New System.Drawing.Size(129, 27)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5)
        Me.LayoutControlItem15.Size = New System.Drawing.Size(287, 27)
        Me.LayoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem15.Text = "Status : "
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.LookUpEdit6
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 54)
        Me.LayoutControlItem16.MaxSize = New System.Drawing.Size(0, 27)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(129, 27)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5)
        Me.LayoutControlItem16.Size = New System.Drawing.Size(287, 27)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem16.Text = "Currency : "
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.TextEdit6
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 81)
        Me.LayoutControlItem17.MaxSize = New System.Drawing.Size(0, 27)
        Me.LayoutControlItem17.MinSize = New System.Drawing.Size(129, 27)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5)
        Me.LayoutControlItem17.Size = New System.Drawing.Size(287, 27)
        Me.LayoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem17.Text = "Ticket Cost : "
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.TextEdit7
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 108)
        Me.LayoutControlItem18.MaxSize = New System.Drawing.Size(0, 27)
        Me.LayoutControlItem18.MinSize = New System.Drawing.Size(129, 27)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5)
        Me.LayoutControlItem18.Size = New System.Drawing.Size(287, 27)
        Me.LayoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem18.Text = "Invoice Nbr : "
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(83, 16)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem19.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.LayoutControlItem19.Control = Me.DateEdit3
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 135)
        Me.LayoutControlItem19.MaxSize = New System.Drawing.Size(0, 51)
        Me.LayoutControlItem19.MinSize = New System.Drawing.Size(129, 51)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 5)
        Me.LayoutControlItem19.Size = New System.Drawing.Size(287, 54)
        Me.LayoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem19.Text = "Invoice Date : "
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(83, 16)
        '
        'lcLeft
        '
        Me.lcLeft.Controls.Add(Me.MemoEdit1)
        Me.lcLeft.Controls.Add(Me.LookUpEdit4)
        Me.lcLeft.Controls.Add(Me.LookUpEdit3)
        Me.lcLeft.Controls.Add(Me.LookUpEdit2)
        Me.lcLeft.Controls.Add(Me.LookUpEdit1)
        Me.lcLeft.Controls.Add(Me.DateEdit2)
        Me.lcLeft.Controls.Add(Me.DateEdit1)
        Me.lcLeft.Controls.Add(Me.TextEdit4)
        Me.lcLeft.Controls.Add(Me.TextEdit3)
        Me.lcLeft.Controls.Add(Me.TextEdit1)
        Me.lcLeft.Controls.Add(Me.TextEdit2)
        Me.lcLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lcLeft.Location = New System.Drawing.Point(0, 0)
        Me.lcLeft.Name = "lcLeft"
        Me.lcLeft.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(665, 28, 250, 350)
        Me.lcLeft.OptionsFocus.EnableAutoTabOrder = False
        Me.lcLeft.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.lcLeft.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.lcLeft.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.lcLeft.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.lcLeft.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.lcLeft.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lcLeft.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcLeft.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.lcLeft.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lcLeft.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lcLeft.Root = Nothing
        Me.lcLeft.Size = New System.Drawing.Size(673, 237)
        Me.lcLeft.TabIndex = 0
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(438, 115)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(221, 104)
        Me.MemoEdit1.TabIndex = 8
        '
        'LookUpEdit4
        '
        Me.LookUpEdit4.Location = New System.Drawing.Point(438, 88)
        Me.LookUpEdit4.Name = "LookUpEdit4"
        Me.LookUpEdit4.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit4.Size = New System.Drawing.Size(221, 22)
        Me.LookUpEdit4.TabIndex = 6
        '
        'LookUpEdit3
        '
        Me.LookUpEdit3.Location = New System.Drawing.Point(438, 61)
        Me.LookUpEdit3.Name = "LookUpEdit3"
        Me.LookUpEdit3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit3.Size = New System.Drawing.Size(221, 22)
        Me.LookUpEdit3.TabIndex = 4
        '
        'LookUpEdit2
        '
        Me.LookUpEdit2.Location = New System.Drawing.Point(438, 34)
        Me.LookUpEdit2.Name = "LookUpEdit2"
        Me.LookUpEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit2.Size = New System.Drawing.Size(221, 22)
        Me.LookUpEdit2.TabIndex = 2
        '
        'LookUpEdit1
        '
        Me.LookUpEdit1.Location = New System.Drawing.Point(106, 196)
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit1.Size = New System.Drawing.Size(220, 22)
        Me.LookUpEdit1.TabIndex = 11
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(106, 169)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Size = New System.Drawing.Size(220, 22)
        Me.DateEdit2.TabIndex = 10
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(106, 142)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(220, 22)
        Me.DateEdit1.TabIndex = 9
        '
        'TextEdit4
        '
        Me.TextEdit4.Location = New System.Drawing.Point(106, 115)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Size = New System.Drawing.Size(220, 22)
        Me.TextEdit4.TabIndex = 7
        '
        'TextEdit3
        '
        Me.TextEdit3.Location = New System.Drawing.Point(106, 88)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Size = New System.Drawing.Size(220, 22)
        Me.TextEdit3.TabIndex = 5
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(106, 34)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(220, 22)
        Me.TextEdit1.TabIndex = 0
        '
        'TextEdit2
        '
        Me.TextEdit2.EditValue = Nothing
        Me.TextEdit2.Location = New System.Drawing.Point(106, 61)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TextEdit2.Size = New System.Drawing.Size(220, 22)
        Me.TextEdit2.TabIndex = 3
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.OptionsItemText.TextToControlDistance = 5
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(673, 237)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.AutoScroll = True
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.SplitContainerControl1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.gcBookingDetails)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(792, 545)
        Me.SplitContainerControl2.SplitterPosition = 187
        Me.SplitContainerControl2.TabIndex = 11
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl1.MaximumSize = New System.Drawing.Size(0, 238)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LayoutControl5)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        Me.SplitContainerControl1.Size = New System.Drawing.Size(792, 187)
        Me.SplitContainerControl1.SplitterPosition = 369
        Me.SplitContainerControl1.TabIndex = 9
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LayoutControl5
        '
        Me.LayoutControl5.Controls.Add(Me.txtArrPlace)
        Me.LayoutControl5.Controls.Add(Me.W)
        Me.LayoutControl5.Controls.Add(Me.leTravelAgent)
        Me.LayoutControl5.Controls.Add(Me.leInvoiceTo)
        Me.LayoutControl5.Controls.Add(Me.lePortAgent)
        Me.LayoutControl5.Controls.Add(Me.deDateReq)
        Me.LayoutControl5.Controls.Add(Me.deReqDate)
        Me.LayoutControl5.Controls.Add(Me.txtPlace)
        Me.LayoutControl5.Controls.Add(Me.txtVsl)
        Me.LayoutControl5.Controls.Add(Me.deDateSign)
        Me.LayoutControl5.Controls.Add(Me.luPlaceSign)
        Me.LayoutControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl5.Name = "LayoutControl5"
        Me.LayoutControl5.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(665, 28, 250, 350)
        Me.LayoutControl5.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LayoutControl5.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl5.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControl5.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LayoutControl5.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LayoutControl5.Root = Me.LayoutControlGroup5
        Me.LayoutControl5.Size = New System.Drawing.Size(792, 187)
        Me.LayoutControl5.TabIndex = 0
        Me.LayoutControl5.Text = "LayoutControl2"
        '
        'txtArrPlace
        '
        Me.txtArrPlace.EditValue = ""
        Me.txtArrPlace.Location = New System.Drawing.Point(133, 111)
        Me.txtArrPlace.Name = "txtArrPlace"
        Me.txtArrPlace.Size = New System.Drawing.Size(255, 22)
        Me.txtArrPlace.StyleController = Me.LayoutControl5
        Me.txtArrPlace.TabIndex = 4
        '
        'W
        '
        Me.W.Location = New System.Drawing.Point(526, 86)
        Me.W.Name = "W"
        Me.W.Size = New System.Drawing.Size(230, 96)
        Me.W.StyleController = Me.LayoutControl5
        Me.W.TabIndex = 10
        '
        'leTravelAgent
        '
        Me.leTravelAgent.Location = New System.Drawing.Point(526, 61)
        Me.leTravelAgent.Name = "leTravelAgent"
        Me.leTravelAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.leTravelAgent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.leTravelAgent.Properties.DisplayMember = "Name"
        Me.leTravelAgent.Properties.NullText = ""
        Me.leTravelAgent.Properties.ShowFooter = False
        Me.leTravelAgent.Properties.ShowHeader = False
        Me.leTravelAgent.Properties.ValueMember = "PKey"
        Me.leTravelAgent.Size = New System.Drawing.Size(230, 22)
        Me.leTravelAgent.StyleController = Me.LayoutControl5
        Me.leTravelAgent.TabIndex = 9
        '
        'leInvoiceTo
        '
        Me.leInvoiceTo.Location = New System.Drawing.Point(526, 36)
        Me.leInvoiceTo.Name = "leInvoiceTo"
        Me.leInvoiceTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leInvoiceTo.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.leInvoiceTo.Properties.DisplayMember = "Name"
        Me.leInvoiceTo.Properties.NullText = ""
        Me.leInvoiceTo.Properties.ShowFooter = False
        Me.leInvoiceTo.Properties.ShowHeader = False
        Me.leInvoiceTo.Properties.ValueMember = "PKey"
        Me.leInvoiceTo.Size = New System.Drawing.Size(230, 22)
        Me.leInvoiceTo.StyleController = Me.LayoutControl5
        Me.leInvoiceTo.TabIndex = 8
        '
        'lePortAgent
        '
        Me.lePortAgent.Location = New System.Drawing.Point(526, 11)
        Me.lePortAgent.Name = "lePortAgent"
        Me.lePortAgent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lePortAgent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lePortAgent.Properties.DisplayMember = "Name"
        Me.lePortAgent.Properties.NullText = ""
        Me.lePortAgent.Properties.ShowFooter = False
        Me.lePortAgent.Properties.ShowHeader = False
        Me.lePortAgent.Properties.ValueMember = "PKey"
        Me.lePortAgent.Size = New System.Drawing.Size(230, 22)
        Me.lePortAgent.StyleController = Me.LayoutControl5
        Me.lePortAgent.TabIndex = 7
        '
        'deDateReq
        '
        Me.deDateReq.EditValue = Nothing
        Me.deDateReq.Location = New System.Drawing.Point(133, 161)
        Me.deDateReq.Name = "deDateReq"
        Me.deDateReq.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateReq.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateReq.Size = New System.Drawing.Size(255, 22)
        Me.deDateReq.StyleController = Me.LayoutControl5
        Me.deDateReq.TabIndex = 6
        '
        'deReqDate
        '
        Me.deReqDate.EditValue = Nothing
        Me.deReqDate.Location = New System.Drawing.Point(133, 136)
        Me.deReqDate.Name = "deReqDate"
        Me.deReqDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deReqDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deReqDate.Size = New System.Drawing.Size(255, 22)
        Me.deReqDate.StyleController = Me.LayoutControl5
        Me.deReqDate.TabIndex = 5
        '
        'txtPlace
        '
        Me.txtPlace.Location = New System.Drawing.Point(133, 86)
        Me.txtPlace.Name = "txtPlace"
        Me.txtPlace.Size = New System.Drawing.Size(255, 22)
        Me.txtPlace.StyleController = Me.LayoutControl5
        Me.txtPlace.TabIndex = 3
        '
        'txtVsl
        '
        Me.txtVsl.Location = New System.Drawing.Point(133, 11)
        Me.txtVsl.Name = "txtVsl"
        Me.txtVsl.Properties.ReadOnly = True
        Me.txtVsl.Size = New System.Drawing.Size(255, 22)
        Me.txtVsl.StyleController = Me.LayoutControl5
        Me.txtVsl.TabIndex = 0
        '
        'deDateSign
        '
        Me.deDateSign.EditValue = Nothing
        Me.deDateSign.Location = New System.Drawing.Point(133, 36)
        Me.deDateSign.Name = "deDateSign"
        Me.deDateSign.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSign.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateSign.Properties.ReadOnly = True
        Me.deDateSign.Size = New System.Drawing.Size(255, 22)
        Me.deDateSign.StyleController = Me.LayoutControl5
        Me.deDateSign.TabIndex = 1
        '
        'luPlaceSign
        '
        Me.luPlaceSign.Location = New System.Drawing.Point(133, 61)
        Me.luPlaceSign.Name = "luPlaceSign"
        Me.luPlaceSign.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.luPlaceSign.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.luPlaceSign.Properties.DisplayMember = "Name"
        Me.luPlaceSign.Properties.NullText = ""
        Me.luPlaceSign.Properties.ReadOnly = True
        Me.luPlaceSign.Properties.ShowFooter = False
        Me.luPlaceSign.Properties.ShowHeader = False
        Me.luPlaceSign.Properties.ValueMember = "PKey"
        Me.luPlaceSign.Size = New System.Drawing.Size(255, 22)
        Me.luPlaceSign.StyleController = Me.LayoutControl5
        Me.luPlaceSign.TabIndex = 2
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup5.GroupBordersVisible = False
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup6})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, -29)
        Me.LayoutControlGroup5.Name = "Root"
        Me.LayoutControlGroup5.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(771, 216)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup6.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem8, Me.lblPlaceSign, Me.lblReqDate, Me.LayoutControlItem12, Me.lblPlace, Me.LayoutControlItem10, Me.LayoutControlItem13, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.lblDateSign})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup6.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 11, 0)
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(771, 216)
        Me.LayoutControlGroup6.StartNewLine = True
        Me.LayoutControlGroup6.Text = "Travel Details"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.leInvoiceTo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(385, 25)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(177, 25)
        Me.LayoutControlItem4.Name = "LayoutControlItem10"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 5)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(360, 25)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "* Invoice To : "
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(115, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.leTravelAgent
        Me.LayoutControlItem8.Location = New System.Drawing.Point(385, 50)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(177, 25)
        Me.LayoutControlItem8.Name = "LayoutControlItem12"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 5)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(360, 25)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "Travel Agent : "
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(115, 16)
        '
        'lblPlaceSign
        '
        Me.lblPlaceSign.Control = Me.luPlaceSign
        Me.lblPlaceSign.Location = New System.Drawing.Point(0, 50)
        Me.lblPlaceSign.MinSize = New System.Drawing.Size(177, 25)
        Me.lblPlaceSign.Name = "lblPlaceSign"
        Me.lblPlaceSign.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 5)
        Me.lblPlaceSign.Size = New System.Drawing.Size(385, 25)
        Me.lblPlaceSign.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lblPlaceSign.Text = "* Place Sign-on : "
        Me.lblPlaceSign.TextSize = New System.Drawing.Size(115, 16)
        '
        'lblReqDate
        '
        Me.lblReqDate.Control = Me.deReqDate
        Me.lblReqDate.Location = New System.Drawing.Point(0, 125)
        Me.lblReqDate.MinSize = New System.Drawing.Size(177, 25)
        Me.lblReqDate.Name = "lblReqDate"
        Me.lblReqDate.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 5)
        Me.lblReqDate.Size = New System.Drawing.Size(385, 25)
        Me.lblReqDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lblReqDate.Text = "* Req Arr Date : "
        Me.lblReqDate.TextSize = New System.Drawing.Size(115, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.deDateReq
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 150)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(177, 25)
        Me.LayoutControlItem12.Name = "LayoutControlItem8"
        Me.LayoutControlItem12.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 5)
        Me.LayoutControlItem12.Size = New System.Drawing.Size(385, 25)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.Text = "* Date Requested : "
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(115, 16)
        '
        'lblPlace
        '
        Me.lblPlace.Control = Me.txtPlace
        Me.lblPlace.Location = New System.Drawing.Point(0, 75)
        Me.lblPlace.MinSize = New System.Drawing.Size(177, 25)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 5)
        Me.lblPlace.Size = New System.Drawing.Size(385, 25)
        Me.lblPlace.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lblPlace.Text = "* Departing Place : "
        Me.lblPlace.TextSize = New System.Drawing.Size(115, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem10.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.LayoutControlItem10.Control = Me.W
        Me.LayoutControlItem10.Location = New System.Drawing.Point(385, 75)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(116, 16)
        Me.LayoutControlItem10.Name = "LayoutControlItem13"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(360, 100)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.Text = "Remarks : "
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(115, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.lePortAgent
        Me.LayoutControlItem13.Location = New System.Drawing.Point(385, 0)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(177, 25)
        Me.LayoutControlItem13.Name = "LayoutControlItem9"
        Me.LayoutControlItem13.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 5)
        Me.LayoutControlItem13.Size = New System.Drawing.Size(360, 25)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem13.Text = "* Port Agent : "
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(115, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtArrPlace
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 100)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(177, 25)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 5)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(385, 25)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "* Arrival Place :"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(115, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtVsl
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(177, 25)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 5)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(385, 25)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "* Vessel : "
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(115, 16)
        '
        'lblDateSign
        '
        Me.lblDateSign.Control = Me.deDateSign
        Me.lblDateSign.Location = New System.Drawing.Point(0, 25)
        Me.lblDateSign.MinSize = New System.Drawing.Size(177, 25)
        Me.lblDateSign.Name = "lblDateSign"
        Me.lblDateSign.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 5)
        Me.lblDateSign.Size = New System.Drawing.Size(385, 25)
        Me.lblDateSign.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lblDateSign.Text = "* Date Sign-on :"
        Me.lblDateSign.TextSize = New System.Drawing.Size(115, 16)
        '
        'gcCrewList
        '
        Me.gcCrewList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcCrewList.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcCrewList.Location = New System.Drawing.Point(0, 0)
        Me.gcCrewList.MainView = Me.gvCrewList
        Me.gcCrewList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gcCrewList.Name = "gcCrewList"
        Me.gcCrewList.Size = New System.Drawing.Size(371, 545)
        Me.gcCrewList.TabIndex = 10
        Me.gcCrewList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCrewList})
        '
        'gvCrewList
        '
        Me.gvCrewList.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.gvCrewList.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.clmCrewName, Me.clmRank, Me.clmSelect, Me.clmCrewID, Me.clmPKey, Me.clmFKeyTravelEvent, Me.clmDepPlace, Me.clmReqArrDate, Me.clmFKeyPlanningEvent})
        Me.gvCrewList.GridControl = Me.gcCrewList
        Me.gvCrewList.Name = "gvCrewList"
        Me.gvCrewList.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvCrewList.OptionsMenu.EnableColumnMenu = False
        Me.gvCrewList.OptionsMenu.EnableGroupPanelMenu = False
        Me.gvCrewList.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridBand1.AppearanceHeader.Options.UseFont = True
        Me.GridBand1.Caption = "Crew Details"
        Me.GridBand1.Columns.Add(Me.clmCrewName)
        Me.GridBand1.Columns.Add(Me.clmRank)
        Me.GridBand1.Columns.Add(Me.clmSelect)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 895
        '
        'clmCrewName
        '
        Me.clmCrewName.Caption = "Crew Name"
        Me.clmCrewName.FieldName = "CrewName"
        Me.clmCrewName.Name = "clmCrewName"
        Me.clmCrewName.OptionsColumn.AllowEdit = False
        Me.clmCrewName.OptionsColumn.ReadOnly = True
        Me.clmCrewName.Visible = True
        Me.clmCrewName.Width = 465
        '
        'clmRank
        '
        Me.clmRank.Caption = "Rank"
        Me.clmRank.FieldName = "RankName"
        Me.clmRank.Name = "clmRank"
        Me.clmRank.OptionsColumn.AllowEdit = False
        Me.clmRank.OptionsColumn.ReadOnly = True
        Me.clmRank.Visible = True
        Me.clmRank.Width = 430
        '
        'clmSelect
        '
        Me.clmSelect.Caption = "Select"
        Me.clmSelect.FieldName = "isSelected"
        Me.clmSelect.Name = "clmSelect"
        Me.clmSelect.Width = 143
        '
        'clmCrewID
        '
        Me.clmCrewID.FieldName = "CrewID"
        Me.clmCrewID.Name = "clmCrewID"
        '
        'clmPKey
        '
        Me.clmPKey.Caption = " "
        Me.clmPKey.FieldName = "PKey"
        Me.clmPKey.Name = "clmPKey"
        '
        'clmFKeyTravelEvent
        '
        Me.clmFKeyTravelEvent.Caption = " "
        Me.clmFKeyTravelEvent.FieldName = "FKeyTravelEvent"
        Me.clmFKeyTravelEvent.Name = "clmFKeyTravelEvent"
        '
        'clmDepPlace
        '
        Me.clmDepPlace.Caption = "Travel Event"
        Me.clmDepPlace.FieldName = "GroupHead"
        Me.clmDepPlace.Name = "clmDepPlace"
        Me.clmDepPlace.Visible = True
        '
        'clmReqArrDate
        '
        Me.clmReqArrDate.Caption = " "
        Me.clmReqArrDate.FieldName = "ReqArrDate"
        Me.clmReqArrDate.Name = "clmReqArrDate"
        Me.clmReqArrDate.Visible = True
        '
        'clmFKeyPlanningEvent
        '
        Me.clmFKeyPlanningEvent.FieldName = "FKeyPlanningEvent"
        Me.clmFKeyPlanningEvent.Name = "clmFKeyPlanningEvent"
        '
        'SplitContainerControl3
        '
        Me.SplitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SplitContainerControl3.Name = "SplitContainerControl3"
        Me.SplitContainerControl3.Panel1.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl3.Panel1.Text = "Panel1"
        Me.SplitContainerControl3.Panel2.Controls.Add(Me.gcCrewList)
        Me.SplitContainerControl3.Panel2.Text = "Panel2"
        Me.SplitContainerControl3.Size = New System.Drawing.Size(1168, 545)
        Me.SplitContainerControl3.SplitterPosition = 792
        Me.SplitContainerControl3.TabIndex = 12
        Me.SplitContainerControl3.Text = "SplitContainerControl3"
        '
        'TravelEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerControl3)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "TravelEvent"
        Me.Size = New System.Drawing.Size(1168, 545)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvFlightDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seqEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.airlineEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.airportEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statusEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcBookingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvBookingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.currencyEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.genericDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl4.ResumeLayout(False)
        CType(Me.DateEdit3.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lcLeft.ResumeLayout(False)
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl5.ResumeLayout(False)
        CType(Me.txtArrPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.W.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leTravelAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leInvoiceTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lePortAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateReq.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateReq.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deReqDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deReqDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVsl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSign.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateSign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.luPlaceSign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlaceSign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReqDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDateSign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCrewList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DateEdit3 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit7 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit6 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LookUpEdit6 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEdit5 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TextEdit5 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lcRight As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcLeft As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LookUpEdit4 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEdit3 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEdit2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LayoutControl5 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents W As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents leTravelAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents leInvoiceTo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lePortAgent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deDateReq As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deReqDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtPlace As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtVsl As DevExpress.XtraEditors.TextEdit
    Friend WithEvents deDateSign As DevExpress.XtraEditors.DateEdit
    Friend WithEvents luPlaceSign As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblDateSign As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblPlaceSign As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblReqDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblPlace As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcBookingDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvFlightDetails As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents clmFlightID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmFKeyBookingDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmSeq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmAirline As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents airlineEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmFlight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmAirportFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents airportEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmAirportTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmETD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents clmETA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmFlightStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents statusEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gvBookingDetails As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents clmBookingRef As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmCurrency As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents currencyEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents clmTicketCost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmInvoiceNbr As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmInvoiceDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents genericDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents clmRmks As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmBookingID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gcCrewList As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCrewList As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents clmCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmRank As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmSelect As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmCrewID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyTravelEvent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmDepPlace As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmReqArrDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents clmFKeyPlanningEvent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SplitContainerControl3 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents seqEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txtArrPlace As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

End Class
