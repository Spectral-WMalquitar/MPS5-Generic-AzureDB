<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Travel_GTRS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Travel_GTRS))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblDueDate = New System.Windows.Forms.Label()
        Me.chkisSentToGTravel = New DevExpress.XtraEditors.CheckEdit()
        Me.PassengerGrid = New DevExpress.XtraGrid.GridControl()
        Me.PassengerView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.bandCrewDetail = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPRemove = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repPRemove = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colPFKeyCrew = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPCrewName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPContactDetails = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repPContactDetails = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colPShowTravelDocuments = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repPDocuments = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.bandTravelDetails = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPETD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repPDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colPETAE = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPETAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandStat = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPFlightDetails = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repPFlightDetails = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.bandAirport = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPFKeyNearestAirport = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repPAirport = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPFKeyAlternateAirport = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandFrequentFlyer = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colFrequentFlyerMembership = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colFrequentFlyerNumber = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandGTRS = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.colPPassengerID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPisSentToGTravel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colPEdited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.btnCompleted = New DevExpress.XtraEditors.SimpleButton()
        Me.cboFKeyPlanningEvent = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnAddFromPlanningEvent = New DevExpress.XtraEditors.SimpleButton()
        Me.cboAddCrew = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cboNearestAirport = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAddCrew = New DevExpress.XtraEditors.SimpleButton()
        Me.TravelCostGrid = New DevExpress.XtraGrid.GridControl()
        Me.TravelCostView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tcDelete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcRepDelete = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.tcPKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcFKeyTravelBooking = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcInvoiceNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcInvoiceDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcRepDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.tcTravelCostItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcRepTravelCostItem = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.tcDetails = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcRepMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.tcBookingRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcRepCurr = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.tcAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcRepSpinEditDecimal = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.tcExRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcConvertedAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcTravelAgentRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcTravelAgentRefDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcEdited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tcRepSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.cboBookingStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtRefNo = New DevExpress.XtraEditors.TextEdit()
        Me.cboPort = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboVessel = New DevExpress.XtraEditors.LookUpEdit()
        Me.PanelGTRSControl = New DevExpress.XtraEditors.PanelControl()
        Me.txtTravelRequestID = New DevExpress.XtraEditors.TextEdit()
        Me.cboRequestType = New DevExpress.XtraEditors.LookUpEdit()
        Me.BookingDetailsGrid = New DevExpress.XtraGrid.GridControl()
        Me.BookingDetailsView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.bdBandControls = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.bdDelete = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repBDDelete = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.bdCopy = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repBDCopy = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.bdBandTravelDetails = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.bdStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repBDStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.bdPKey = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdFKeyTravelBooking = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdFKeyTravelBookingCrew = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdEmployeeNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdItemType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdAmadeusName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdReference = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdFlightNumber = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdClassOfService = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdEdited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdBandOrigin = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.bdOrigin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdOriginDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdDepartureTime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repBDDateEditWTime = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.bdBandDestination = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.bdDestination = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdDestinationDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdArrivalTime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdBandRemarks = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.bdFreeText = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdBandGTRS = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.bdPassengerID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bdisFromGTravel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.repBDDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.cboLeadTime = New DevExpress.XtraEditors.SpinEdit()
        Me.lblLeadTime = New System.Windows.Forms.Label()
        Me.txtCurrentDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtTravelDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.txtETD = New DevExpress.XtraEditors.DateEdit()
        Me.txtETAL = New DevExpress.XtraEditors.DateEdit()
        Me.txtETAE = New DevExpress.XtraEditors.DateEdit()
        Me.txtDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup_Main = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_Status = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciMarkAsCompleted = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_TravelRequest = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_Origin = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciETD = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciRemarks = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_RequestInfo = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciDueDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.lciisSentToGTravel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciGTravelRequestID = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_Destination = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciPort = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciETAE = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciETAL = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup_TravelDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lcgPlanningEvent = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.lciPlanningEvent = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciCurrentDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciTravelDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciVessel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciRefNo = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciAddFromPlanningEvent = New DevExpress.XtraLayout.LayoutControlItem()
        Me.tabDetails = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup_Passenger = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup_AddPassenger = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lciPassengerGrid = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup_BookingDetails = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.chkisSentToGTravel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassengerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassengerView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPContactDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPFlightDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repPAirport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFKeyPlanningEvent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAddCrew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNearestAirport.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TravelCostGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TravelCostView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepTravelCostItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepCurr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepSpinEditDecimal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcRepSpinEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBookingStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRefNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelGTRSControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelRequestID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRequestType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookingDetailsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookingDetailsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBDDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBDCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBDStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBDDateEditWTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBDDateEditWTime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBDDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repBDDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLeadTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrentDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurrentDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtETD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtETD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtETAL.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtETAL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtETAE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtETAE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciMarkAsCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_TravelRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Origin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciETD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_RequestInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciDueDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciisSentToGTravel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciGTravelRequestID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Destination, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciETAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciETAL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_TravelDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lcgPlanningEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPlanningEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciCurrentDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciTravelDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciRefNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciAddFromPlanningEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_Passenger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_AddPassenger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lciPassengerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup_BookingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1364, 1018)
        Me.header.TabIndex = 0
        Me.header.Text = "Travel"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Controls.Add(Me.lblDueDate)
        Me.LayoutControl1.Controls.Add(Me.chkisSentToGTravel)
        Me.LayoutControl1.Controls.Add(Me.PassengerGrid)
        Me.LayoutControl1.Controls.Add(Me.btnCompleted)
        Me.LayoutControl1.Controls.Add(Me.cboFKeyPlanningEvent)
        Me.LayoutControl1.Controls.Add(Me.btnAddFromPlanningEvent)
        Me.LayoutControl1.Controls.Add(Me.cboAddCrew)
        Me.LayoutControl1.Controls.Add(Me.cboNearestAirport)
        Me.LayoutControl1.Controls.Add(Me.btnAddCrew)
        Me.LayoutControl1.Controls.Add(Me.TravelCostGrid)
        Me.LayoutControl1.Controls.Add(Me.cboBookingStatus)
        Me.LayoutControl1.Controls.Add(Me.txtRefNo)
        Me.LayoutControl1.Controls.Add(Me.cboPort)
        Me.LayoutControl1.Controls.Add(Me.cboVessel)
        Me.LayoutControl1.Controls.Add(Me.PanelGTRSControl)
        Me.LayoutControl1.Controls.Add(Me.txtTravelRequestID)
        Me.LayoutControl1.Controls.Add(Me.cboRequestType)
        Me.LayoutControl1.Controls.Add(Me.BookingDetailsGrid)
        Me.LayoutControl1.Controls.Add(Me.PictureEdit1)
        Me.LayoutControl1.Controls.Add(Me.cboLeadTime)
        Me.LayoutControl1.Controls.Add(Me.lblLeadTime)
        Me.LayoutControl1.Controls.Add(Me.txtCurrentDate)
        Me.LayoutControl1.Controls.Add(Me.txtTravelDate)
        Me.LayoutControl1.Controls.Add(Me.txtRemarks)
        Me.LayoutControl1.Controls.Add(Me.txtETD)
        Me.LayoutControl1.Controls.Add(Me.txtETAL)
        Me.LayoutControl1.Controls.Add(Me.txtETAE)
        Me.LayoutControl1.Controls.Add(Me.txtDueDate)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1290, 221, 493, 707)
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
        Me.LayoutControl1.Root = Me.LayoutControlGroup_Main
        Me.LayoutControl1.Size = New System.Drawing.Size(1360, 990)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblDueDate
        '
        Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Italic)
        Me.lblDueDate.Location = New System.Drawing.Point(802, 360)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(522, 20)
        Me.lblDueDate.TabIndex = 79
        Me.lblDueDate.Text = "Target date for the request to be processed"
        '
        'chkisSentToGTravel
        '
        Me.chkisSentToGTravel.Location = New System.Drawing.Point(1209, 334)
        Me.chkisSentToGTravel.Name = "chkisSentToGTravel"
        Me.chkisSentToGTravel.Properties.Caption = "Sent To GTravel"
        Me.chkisSentToGTravel.Size = New System.Drawing.Size(115, 20)
        Me.chkisSentToGTravel.StyleController = Me.LayoutControl1
        Me.chkisSentToGTravel.TabIndex = 78
        Me.chkisSentToGTravel.Visible = False
        '
        'PassengerGrid
        '
        Me.PassengerGrid.Location = New System.Drawing.Point(24, 512)
        Me.PassengerGrid.MainView = Me.PassengerView
        Me.PassengerGrid.Name = "PassengerGrid"
        Me.PassengerGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repPDocuments, Me.repPContactDetails, Me.repPFlightDetails, Me.repPRemove, Me.repPAirport, Me.repPDate})
        Me.PassengerGrid.Size = New System.Drawing.Size(1312, 454)
        Me.PassengerGrid.TabIndex = 77
        Me.PassengerGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.PassengerView})
        '
        'PassengerView
        '
        Me.PassengerView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.bandCrewDetail, Me.bandTravelDetails, Me.bandStat, Me.bandAirport, Me.bandFrequentFlyer, Me.bandGTRS})
        Me.PassengerView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.colPRemove, Me.colPPKey, Me.colPFKeyCrew, Me.colPCrewName, Me.colPETD, Me.colPETAE, Me.colPETAL, Me.colPFKeyNearestAirport, Me.colPFKeyAlternateAirport, Me.colFrequentFlyerMembership, Me.colFrequentFlyerNumber, Me.colPContactDetails, Me.colPShowTravelDocuments, Me.colPFlightDetails, Me.colPPassengerID, Me.colPisSentToGTravel, Me.colPEdited})
        Me.PassengerView.GridControl = Me.PassengerGrid
        Me.PassengerView.Name = "PassengerView"
        Me.PassengerView.OptionsView.ColumnAutoWidth = False
        Me.PassengerView.OptionsView.ShowGroupPanel = False
        '
        'bandCrewDetail
        '
        Me.bandCrewDetail.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bandCrewDetail.AppearanceHeader.Options.UseFont = True
        Me.bandCrewDetail.Caption = "Crew Details"
        Me.bandCrewDetail.Columns.Add(Me.colPPKey)
        Me.bandCrewDetail.Columns.Add(Me.colPRemove)
        Me.bandCrewDetail.Columns.Add(Me.colPFKeyCrew)
        Me.bandCrewDetail.Columns.Add(Me.colPCrewName)
        Me.bandCrewDetail.Columns.Add(Me.colPContactDetails)
        Me.bandCrewDetail.Columns.Add(Me.colPShowTravelDocuments)
        Me.bandCrewDetail.Name = "bandCrewDetail"
        Me.bandCrewDetail.OptionsBand.ShowInCustomizationForm = False
        Me.bandCrewDetail.VisibleIndex = 0
        Me.bandCrewDetail.Width = 365
        '
        'colPPKey
        '
        Me.colPPKey.Caption = "PKey"
        Me.colPPKey.FieldName = "PKey"
        Me.colPPKey.Name = "colPPKey"
        Me.colPPKey.OptionsColumn.ShowInCustomizationForm = False
        Me.colPPKey.Width = 73
        '
        'colPRemove
        '
        Me.colPRemove.Caption = " "
        Me.colPRemove.ColumnEdit = Me.repPRemove
        Me.colPRemove.Name = "colPRemove"
        Me.colPRemove.OptionsColumn.ShowInCustomizationForm = False
        Me.colPRemove.Visible = True
        Me.colPRemove.Width = 25
        '
        'repPRemove
        '
        Me.repPRemove.AutoHeight = False
        Me.repPRemove.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("repPRemove.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.repPRemove.Name = "repPRemove"
        Me.repPRemove.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colPFKeyCrew
        '
        Me.colPFKeyCrew.Caption = "FKeyCrew"
        Me.colPFKeyCrew.FieldName = "FKeyCrew"
        Me.colPFKeyCrew.Name = "colPFKeyCrew"
        Me.colPFKeyCrew.OptionsColumn.ShowInCustomizationForm = False
        Me.colPFKeyCrew.Width = 228
        '
        'colPCrewName
        '
        Me.colPCrewName.Caption = "Crew"
        Me.colPCrewName.FieldName = "CrewName"
        Me.colPCrewName.Name = "colPCrewName"
        Me.colPCrewName.OptionsColumn.ShowInCustomizationForm = False
        Me.colPCrewName.Visible = True
        Me.colPCrewName.Width = 284
        '
        'colPContactDetails
        '
        Me.colPContactDetails.Caption = " "
        Me.colPContactDetails.ColumnEdit = Me.repPContactDetails
        Me.colPContactDetails.Name = "colPContactDetails"
        Me.colPContactDetails.OptionsColumn.ShowInCustomizationForm = False
        Me.colPContactDetails.Visible = True
        Me.colPContactDetails.Width = 26
        '
        'repPContactDetails
        '
        Me.repPContactDetails.AutoHeight = False
        Me.repPContactDetails.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("repPContactDetails.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.repPContactDetails.Name = "repPContactDetails"
        Me.repPContactDetails.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colPShowTravelDocuments
        '
        Me.colPShowTravelDocuments.Caption = " "
        Me.colPShowTravelDocuments.ColumnEdit = Me.repPDocuments
        Me.colPShowTravelDocuments.Name = "colPShowTravelDocuments"
        Me.colPShowTravelDocuments.OptionsColumn.ShowInCustomizationForm = False
        Me.colPShowTravelDocuments.Visible = True
        Me.colPShowTravelDocuments.Width = 30
        '
        'repPDocuments
        '
        Me.repPDocuments.AutoHeight = False
        Me.repPDocuments.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("repPDocuments.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, Nothing, True)})
        Me.repPDocuments.Name = "repPDocuments"
        Me.repPDocuments.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'bandTravelDetails
        '
        Me.bandTravelDetails.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bandTravelDetails.AppearanceHeader.Options.UseFont = True
        Me.bandTravelDetails.Caption = "Travel Details"
        Me.bandTravelDetails.Columns.Add(Me.colPETD)
        Me.bandTravelDetails.Columns.Add(Me.colPETAE)
        Me.bandTravelDetails.Columns.Add(Me.colPETAL)
        Me.bandTravelDetails.Name = "bandTravelDetails"
        Me.bandTravelDetails.OptionsBand.ShowInCustomizationForm = False
        Me.bandTravelDetails.VisibleIndex = 1
        Me.bandTravelDetails.Width = 535
        '
        'colPETD
        '
        Me.colPETD.Caption = "ETD"
        Me.colPETD.ColumnEdit = Me.repPDate
        Me.colPETD.FieldName = "ETD"
        Me.colPETD.Name = "colPETD"
        Me.colPETD.OptionsColumn.ShowInCustomizationForm = False
        Me.colPETD.Visible = True
        Me.colPETD.Width = 193
        '
        'repPDate
        '
        Me.repPDate.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.repPDate.AutoHeight = False
        Me.repPDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repPDate.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.repPDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repPDate.Mask.EditMask = "dd-MMM-yyyy hh:mm tt"
        Me.repPDate.Mask.UseMaskAsDisplayFormat = True
        Me.repPDate.Name = "repPDate"
        '
        'colPETAE
        '
        Me.colPETAE.Caption = "ETA - Earliest"
        Me.colPETAE.ColumnEdit = Me.repPDate
        Me.colPETAE.FieldName = "ETAE"
        Me.colPETAE.Name = "colPETAE"
        Me.colPETAE.OptionsColumn.ShowInCustomizationForm = False
        Me.colPETAE.Visible = True
        Me.colPETAE.Width = 190
        '
        'colPETAL
        '
        Me.colPETAL.Caption = "ETA - Latest"
        Me.colPETAL.ColumnEdit = Me.repPDate
        Me.colPETAL.FieldName = "ETAL"
        Me.colPETAL.Name = "colPETAL"
        Me.colPETAL.OptionsColumn.ShowInCustomizationForm = False
        Me.colPETAL.Visible = True
        Me.colPETAL.Width = 152
        '
        'bandStat
        '
        Me.bandStat.Caption = " "
        Me.bandStat.Columns.Add(Me.colPFlightDetails)
        Me.bandStat.Name = "bandStat"
        Me.bandStat.OptionsBand.ShowInCustomizationForm = False
        Me.bandStat.VisibleIndex = 2
        Me.bandStat.Width = 29
        '
        'colPFlightDetails
        '
        Me.colPFlightDetails.Caption = " "
        Me.colPFlightDetails.ColumnEdit = Me.repPFlightDetails
        Me.colPFlightDetails.FieldName = "HasFlightDetails"
        Me.colPFlightDetails.Name = "colPFlightDetails"
        Me.colPFlightDetails.OptionsColumn.AllowEdit = False
        Me.colPFlightDetails.OptionsColumn.ShowInCustomizationForm = False
        Me.colPFlightDetails.Visible = True
        Me.colPFlightDetails.Width = 29
        '
        'repPFlightDetails
        '
        Me.repPFlightDetails.AutoHeight = False
        Me.repPFlightDetails.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.repPFlightDetails.Name = "repPFlightDetails"
        Me.repPFlightDetails.PictureChecked = CType(resources.GetObject("repPFlightDetails.PictureChecked"), System.Drawing.Image)
        '
        'bandAirport
        '
        Me.bandAirport.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bandAirport.AppearanceHeader.Options.UseFont = True
        Me.bandAirport.Caption = "Airport"
        Me.bandAirport.Columns.Add(Me.colPFKeyNearestAirport)
        Me.bandAirport.Columns.Add(Me.colPFKeyAlternateAirport)
        Me.bandAirport.Name = "bandAirport"
        Me.bandAirport.OptionsBand.ShowInCustomizationForm = False
        Me.bandAirport.VisibleIndex = 3
        Me.bandAirport.Width = 351
        '
        'colPFKeyNearestAirport
        '
        Me.colPFKeyNearestAirport.Caption = "Nearest Airport"
        Me.colPFKeyNearestAirport.ColumnEdit = Me.repPAirport
        Me.colPFKeyNearestAirport.FieldName = "FKeyNearestAirport"
        Me.colPFKeyNearestAirport.Name = "colPFKeyNearestAirport"
        Me.colPFKeyNearestAirport.OptionsColumn.ShowInCustomizationForm = False
        Me.colPFKeyNearestAirport.Visible = True
        Me.colPFKeyNearestAirport.Width = 191
        '
        'repPAirport
        '
        Me.repPAirport.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.repPAirport.AutoHeight = False
        Me.repPAirport.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repPAirport.DisplayMember = "Name"
        Me.repPAirport.Name = "repPAirport"
        Me.repPAirport.NullText = ""
        Me.repPAirport.ValueMember = "PKey"
        Me.repPAirport.View = Me.GridView1
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colPFKeyAlternateAirport
        '
        Me.colPFKeyAlternateAirport.Caption = "Alternate Airport"
        Me.colPFKeyAlternateAirport.ColumnEdit = Me.repPAirport
        Me.colPFKeyAlternateAirport.FieldName = "FKeyAlternateAirport"
        Me.colPFKeyAlternateAirport.Name = "colPFKeyAlternateAirport"
        Me.colPFKeyAlternateAirport.OptionsColumn.ShowInCustomizationForm = False
        Me.colPFKeyAlternateAirport.Visible = True
        Me.colPFKeyAlternateAirport.Width = 160
        '
        'bandFrequentFlyer
        '
        Me.bandFrequentFlyer.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bandFrequentFlyer.AppearanceHeader.Options.UseFont = True
        Me.bandFrequentFlyer.Caption = "Frequent Flyer"
        Me.bandFrequentFlyer.Columns.Add(Me.colFrequentFlyerMembership)
        Me.bandFrequentFlyer.Columns.Add(Me.colFrequentFlyerNumber)
        Me.bandFrequentFlyer.Name = "bandFrequentFlyer"
        Me.bandFrequentFlyer.OptionsBand.ShowInCustomizationForm = False
        Me.bandFrequentFlyer.VisibleIndex = 4
        Me.bandFrequentFlyer.Width = 366
        '
        'colFrequentFlyerMembership
        '
        Me.colFrequentFlyerMembership.Caption = "Frequent Flyer Membership"
        Me.colFrequentFlyerMembership.FieldName = "colFrequentFlyerMembership"
        Me.colFrequentFlyerMembership.Name = "colFrequentFlyerMembership"
        Me.colFrequentFlyerMembership.OptionsColumn.ShowInCustomizationForm = False
        Me.colFrequentFlyerMembership.Visible = True
        Me.colFrequentFlyerMembership.Width = 176
        '
        'colFrequentFlyerNumber
        '
        Me.colFrequentFlyerNumber.Caption = "Frequent Flyer Number"
        Me.colFrequentFlyerNumber.FieldName = "FrequentFlyerNumber"
        Me.colFrequentFlyerNumber.Name = "colFrequentFlyerNumber"
        Me.colFrequentFlyerNumber.OptionsColumn.ShowInCustomizationForm = False
        Me.colFrequentFlyerNumber.Visible = True
        Me.colFrequentFlyerNumber.Width = 190
        '
        'bandGTRS
        '
        Me.bandGTRS.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bandGTRS.AppearanceHeader.Options.UseFont = True
        Me.bandGTRS.Caption = "For GTravel"
        Me.bandGTRS.Columns.Add(Me.colPPassengerID)
        Me.bandGTRS.Name = "bandGTRS"
        Me.bandGTRS.OptionsBand.ShowInCustomizationForm = False
        Me.bandGTRS.VisibleIndex = 5
        Me.bandGTRS.Width = 138
        '
        'colPPassengerID
        '
        Me.colPPassengerID.Caption = "PassengerID"
        Me.colPPassengerID.FieldName = "PassengerID"
        Me.colPPassengerID.Name = "colPPassengerID"
        Me.colPPassengerID.OptionsColumn.ShowInCustomizationForm = False
        Me.colPPassengerID.Visible = True
        Me.colPPassengerID.Width = 138
        '
        'colPisSentToGTravel
        '
        Me.colPisSentToGTravel.Caption = "isSentToGTravel"
        Me.colPisSentToGTravel.FieldName = "isSentToGTravel"
        Me.colPisSentToGTravel.Name = "colPisSentToGTravel"
        Me.colPisSentToGTravel.OptionsColumn.ShowInCustomizationForm = False
        '
        'colPEdited
        '
        Me.colPEdited.Caption = "Edited"
        Me.colPEdited.FieldName = "Edited"
        Me.colPEdited.Name = "colPEdited"
        Me.colPEdited.OptionsColumn.ShowInCustomizationForm = False
        '
        'btnCompleted
        '
        Me.btnCompleted.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCompleted.Appearance.Options.UseFont = True
        Me.btnCompleted.Location = New System.Drawing.Point(292, 24)
        Me.btnCompleted.Name = "btnCompleted"
        Me.btnCompleted.Size = New System.Drawing.Size(732, 25)
        Me.btnCompleted.StyleController = Me.LayoutControl1
        Me.btnCompleted.TabIndex = 76
        Me.btnCompleted.Text = "Mark as Completed"
        '
        'cboFKeyPlanningEvent
        '
        Me.cboFKeyPlanningEvent.Location = New System.Drawing.Point(154, 163)
        Me.cboFKeyPlanningEvent.Name = "cboFKeyPlanningEvent"
        Me.cboFKeyPlanningEvent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFKeyPlanningEvent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PlanningEvent", "PlanningEvent")})
        Me.cboFKeyPlanningEvent.Properties.DisplayMember = "PlanningEvent"
        Me.cboFKeyPlanningEvent.Properties.DropDownRows = 1
        Me.cboFKeyPlanningEvent.Properties.NullText = ""
        Me.cboFKeyPlanningEvent.Properties.ShowHeader = False
        Me.cboFKeyPlanningEvent.Properties.ValueMember = "PKey"
        Me.cboFKeyPlanningEvent.Size = New System.Drawing.Size(243, 22)
        Me.cboFKeyPlanningEvent.StyleController = Me.LayoutControl1
        Me.cboFKeyPlanningEvent.TabIndex = 75
        '
        'btnAddFromPlanningEvent
        '
        Me.btnAddFromPlanningEvent.Appearance.ForeColor = System.Drawing.Color.Green
        Me.btnAddFromPlanningEvent.Appearance.Options.UseForeColor = True
        Me.btnAddFromPlanningEvent.Location = New System.Drawing.Point(24, 99)
        Me.btnAddFromPlanningEvent.Name = "btnAddFromPlanningEvent"
        Me.btnAddFromPlanningEvent.Size = New System.Drawing.Size(762, 23)
        Me.btnAddFromPlanningEvent.StyleController = Me.LayoutControl1
        Me.btnAddFromPlanningEvent.TabIndex = 73
        Me.btnAddFromPlanningEvent.Text = "+ Add From an Existing Planning Event"
        '
        'cboAddCrew
        '
        Me.cboAddCrew.Location = New System.Drawing.Point(109, 481)
        Me.cboAddCrew.Name = "cboAddCrew"
        Me.cboAddCrew.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.cboAddCrew.Properties.NullText = ""
        Me.cboAddCrew.Properties.View = Me.GridView2
        Me.cboAddCrew.Size = New System.Drawing.Size(198, 22)
        Me.cboAddCrew.StyleController = Me.LayoutControl1
        Me.cboAddCrew.TabIndex = 72
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'cboNearestAirport
        '
        Me.cboNearestAirport.Location = New System.Drawing.Point(533, 160)
        Me.cboNearestAirport.Name = "cboNearestAirport"
        Me.cboNearestAirport.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboNearestAirport.Properties.NullText = ""
        Me.cboNearestAirport.Properties.View = Me.SearchLookUpEdit1View
        Me.cboNearestAirport.Size = New System.Drawing.Size(241, 22)
        Me.cboNearestAirport.StyleController = Me.LayoutControl1
        Me.cboNearestAirport.TabIndex = 70
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'btnAddCrew
        '
        Me.btnAddCrew.Location = New System.Drawing.Point(311, 481)
        Me.btnAddCrew.Name = "btnAddCrew"
        Me.btnAddCrew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddCrew.StyleController = Me.LayoutControl1
        Me.btnAddCrew.TabIndex = 69
        Me.btnAddCrew.Text = "Add"
        '
        'TravelCostGrid
        '
        Me.TravelCostGrid.Location = New System.Drawing.Point(24, 481)
        Me.TravelCostGrid.MainView = Me.TravelCostView
        Me.TravelCostGrid.Name = "TravelCostGrid"
        Me.TravelCostGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.tcRepDate, Me.tcRepTravelCostItem, Me.tcRepMemoEdit, Me.tcRepCurr, Me.tcRepSpinEdit, Me.tcRepSpinEditDecimal, Me.tcRepDelete})
        Me.TravelCostGrid.Size = New System.Drawing.Size(1312, 485)
        Me.TravelCostGrid.TabIndex = 68
        Me.TravelCostGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TravelCostView})
        '
        'TravelCostView
        '
        Me.TravelCostView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.tcDelete, Me.tcPKey, Me.tcFKeyTravelBooking, Me.tcInvoiceNo, Me.tcInvoiceDate, Me.tcTravelCostItem, Me.tcDetails, Me.tcBookingRefNo, Me.tcCurrency, Me.tcAmount, Me.tcExRate, Me.tcConvertedAmt, Me.tcTravelAgentRefNo, Me.tcTravelAgentRefDate, Me.tcEdited})
        Me.TravelCostView.GridControl = Me.TravelCostGrid
        Me.TravelCostView.Name = "TravelCostView"
        Me.TravelCostView.OptionsView.ColumnAutoWidth = False
        Me.TravelCostView.OptionsView.ShowGroupPanel = False
        '
        'tcDelete
        '
        Me.tcDelete.Caption = " "
        Me.tcDelete.ColumnEdit = Me.tcRepDelete
        Me.tcDelete.Name = "tcDelete"
        Me.tcDelete.OptionsColumn.AllowSize = False
        Me.tcDelete.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[True]
        Me.tcDelete.Visible = True
        Me.tcDelete.VisibleIndex = 0
        Me.tcDelete.Width = 20
        '
        'tcRepDelete
        '
        Me.tcRepDelete.AutoHeight = False
        Me.tcRepDelete.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("tcRepDelete.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, Nothing, True)})
        Me.tcRepDelete.Name = "tcRepDelete"
        Me.tcRepDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'tcPKey
        '
        Me.tcPKey.Caption = "PKey"
        Me.tcPKey.FieldName = "PKey"
        Me.tcPKey.Name = "tcPKey"
        '
        'tcFKeyTravelBooking
        '
        Me.tcFKeyTravelBooking.Caption = "KeyTravelBooking"
        Me.tcFKeyTravelBooking.FieldName = "KeyTravelBooking"
        Me.tcFKeyTravelBooking.Name = "tcFKeyTravelBooking"
        '
        'tcInvoiceNo
        '
        Me.tcInvoiceNo.Caption = "Invoice No."
        Me.tcInvoiceNo.FieldName = "InvoiceNo"
        Me.tcInvoiceNo.Name = "tcInvoiceNo"
        Me.tcInvoiceNo.Visible = True
        Me.tcInvoiceNo.VisibleIndex = 1
        Me.tcInvoiceNo.Width = 92
        '
        'tcInvoiceDate
        '
        Me.tcInvoiceDate.Caption = "Invoice Date"
        Me.tcInvoiceDate.ColumnEdit = Me.tcRepDate
        Me.tcInvoiceDate.FieldName = "InvoiceDate"
        Me.tcInvoiceDate.Name = "tcInvoiceDate"
        Me.tcInvoiceDate.Visible = True
        Me.tcInvoiceDate.VisibleIndex = 2
        Me.tcInvoiceDate.Width = 92
        '
        'tcRepDate
        '
        Me.tcRepDate.AutoHeight = False
        Me.tcRepDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tcRepDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tcRepDate.Mask.EditMask = "dd-MMM-yyyy"
        Me.tcRepDate.Mask.UseMaskAsDisplayFormat = True
        Me.tcRepDate.Name = "tcRepDate"
        '
        'tcTravelCostItem
        '
        Me.tcTravelCostItem.Caption = "Travel Cost Item"
        Me.tcTravelCostItem.ColumnEdit = Me.tcRepTravelCostItem
        Me.tcTravelCostItem.FieldName = "FKeyTravelCostItem"
        Me.tcTravelCostItem.Name = "tcTravelCostItem"
        Me.tcTravelCostItem.Visible = True
        Me.tcTravelCostItem.VisibleIndex = 3
        Me.tcTravelCostItem.Width = 118
        '
        'tcRepTravelCostItem
        '
        Me.tcRepTravelCostItem.AutoHeight = False
        Me.tcRepTravelCostItem.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tcRepTravelCostItem.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 30, "Name")})
        Me.tcRepTravelCostItem.DisplayMember = "Name"
        Me.tcRepTravelCostItem.DropDownRows = 10
        Me.tcRepTravelCostItem.Name = "tcRepTravelCostItem"
        Me.tcRepTravelCostItem.NullText = ""
        Me.tcRepTravelCostItem.ShowFooter = False
        Me.tcRepTravelCostItem.ShowHeader = False
        Me.tcRepTravelCostItem.ValueMember = "PKey"
        '
        'tcDetails
        '
        Me.tcDetails.Caption = "Details"
        Me.tcDetails.ColumnEdit = Me.tcRepMemoEdit
        Me.tcDetails.FieldName = "Details"
        Me.tcDetails.Name = "tcDetails"
        Me.tcDetails.Visible = True
        Me.tcDetails.VisibleIndex = 4
        Me.tcDetails.Width = 146
        '
        'tcRepMemoEdit
        '
        Me.tcRepMemoEdit.Name = "tcRepMemoEdit"
        '
        'tcBookingRefNo
        '
        Me.tcBookingRefNo.Caption = "Booking Ref. No."
        Me.tcBookingRefNo.FieldName = "BookingRefNo"
        Me.tcBookingRefNo.Name = "tcBookingRefNo"
        Me.tcBookingRefNo.Visible = True
        Me.tcBookingRefNo.VisibleIndex = 5
        Me.tcBookingRefNo.Width = 126
        '
        'tcCurrency
        '
        Me.tcCurrency.Caption = "Currency"
        Me.tcCurrency.ColumnEdit = Me.tcRepCurr
        Me.tcCurrency.FieldName = "FKeyCurr"
        Me.tcCurrency.Name = "tcCurrency"
        Me.tcCurrency.Visible = True
        Me.tcCurrency.VisibleIndex = 6
        Me.tcCurrency.Width = 81
        '
        'tcRepCurr
        '
        Me.tcRepCurr.AutoHeight = False
        Me.tcRepCurr.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tcRepCurr.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", 8, "Symbol"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.tcRepCurr.DisplayMember = "Symbol"
        Me.tcRepCurr.DropDownRows = 10
        Me.tcRepCurr.Name = "tcRepCurr"
        Me.tcRepCurr.NullText = ""
        Me.tcRepCurr.ShowFooter = False
        Me.tcRepCurr.ShowHeader = False
        Me.tcRepCurr.ValueMember = "PKey"
        '
        'tcAmount
        '
        Me.tcAmount.Caption = "Amount"
        Me.tcAmount.ColumnEdit = Me.tcRepSpinEditDecimal
        Me.tcAmount.FieldName = "Amount"
        Me.tcAmount.Name = "tcAmount"
        Me.tcAmount.Visible = True
        Me.tcAmount.VisibleIndex = 7
        Me.tcAmount.Width = 81
        '
        'tcRepSpinEditDecimal
        '
        Me.tcRepSpinEditDecimal.AutoHeight = False
        Me.tcRepSpinEditDecimal.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tcRepSpinEditDecimal.Mask.EditMask = "f"
        Me.tcRepSpinEditDecimal.Mask.UseMaskAsDisplayFormat = True
        Me.tcRepSpinEditDecimal.Name = "tcRepSpinEditDecimal"
        '
        'tcExRate
        '
        Me.tcExRate.Caption = "Ex. Rate to USD"
        Me.tcExRate.ColumnEdit = Me.tcRepSpinEditDecimal
        Me.tcExRate.FieldName = "ExRateToUSD"
        Me.tcExRate.Name = "tcExRate"
        Me.tcExRate.Visible = True
        Me.tcExRate.VisibleIndex = 8
        Me.tcExRate.Width = 111
        '
        'tcConvertedAmt
        '
        Me.tcConvertedAmt.Caption = "Converted Amount (USD)"
        Me.tcConvertedAmt.ColumnEdit = Me.tcRepSpinEditDecimal
        Me.tcConvertedAmt.FieldName = "ConvertedAmount"
        Me.tcConvertedAmt.Name = "tcConvertedAmt"
        Me.tcConvertedAmt.OptionsColumn.ReadOnly = True
        Me.tcConvertedAmt.Visible = True
        Me.tcConvertedAmt.VisibleIndex = 9
        Me.tcConvertedAmt.Width = 156
        '
        'tcTravelAgentRefNo
        '
        Me.tcTravelAgentRefNo.Caption = "(Travel Agent) Ref. No."
        Me.tcTravelAgentRefNo.FieldName = "TravelAgentRefNo"
        Me.tcTravelAgentRefNo.Name = "tcTravelAgentRefNo"
        Me.tcTravelAgentRefNo.Visible = True
        Me.tcTravelAgentRefNo.VisibleIndex = 10
        Me.tcTravelAgentRefNo.Width = 152
        '
        'tcTravelAgentRefDate
        '
        Me.tcTravelAgentRefDate.Caption = "(Travel Agent) Ref. Date"
        Me.tcTravelAgentRefDate.ColumnEdit = Me.tcRepDate
        Me.tcTravelAgentRefDate.FieldName = "TravelAgentRefDate"
        Me.tcTravelAgentRefDate.Name = "tcTravelAgentRefDate"
        Me.tcTravelAgentRefDate.Visible = True
        Me.tcTravelAgentRefDate.VisibleIndex = 11
        Me.tcTravelAgentRefDate.Width = 169
        '
        'tcEdited
        '
        Me.tcEdited.Caption = "Edited"
        Me.tcEdited.FieldName = "Edited"
        Me.tcEdited.Name = "tcEdited"
        '
        'tcRepSpinEdit
        '
        Me.tcRepSpinEdit.AutoHeight = False
        Me.tcRepSpinEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.tcRepSpinEdit.Mask.EditMask = "d"
        Me.tcRepSpinEdit.Name = "tcRepSpinEdit"
        '
        'cboBookingStatus
        '
        Me.cboBookingStatus.Location = New System.Drawing.Point(119, 24)
        Me.cboBookingStatus.Name = "cboBookingStatus"
        Me.cboBookingStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBookingStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboBookingStatus.Properties.DisplayMember = "Name"
        Me.cboBookingStatus.Properties.NullText = ""
        Me.cboBookingStatus.Properties.ShowFooter = False
        Me.cboBookingStatus.Properties.ShowHeader = False
        Me.cboBookingStatus.Properties.ValueMember = "PKey"
        Me.cboBookingStatus.Size = New System.Drawing.Size(138, 22)
        Me.cboBookingStatus.StyleController = Me.LayoutControl1
        Me.cboBookingStatus.TabIndex = 66
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(151, 296)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(249, 22)
        Me.txtRefNo.StyleController = Me.LayoutControl1
        Me.txtRefNo.TabIndex = 64
        '
        'cboPort
        '
        Me.cboPort.Location = New System.Drawing.Point(533, 258)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPort.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboPort.Properties.DisplayMember = "Name"
        Me.cboPort.Properties.DropDownRows = 10
        Me.cboPort.Properties.NullText = ""
        Me.cboPort.Properties.ShowFooter = False
        Me.cboPort.Properties.ShowHeader = False
        Me.cboPort.Properties.ValueMember = "PKey"
        Me.cboPort.Size = New System.Drawing.Size(241, 22)
        Me.cboPort.StyleController = Me.LayoutControl1
        Me.cboPort.TabIndex = 63
        '
        'cboVessel
        '
        Me.cboVessel.Location = New System.Drawing.Point(151, 270)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVessel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboVessel.Properties.DisplayMember = "Name"
        Me.cboVessel.Properties.NullText = ""
        Me.cboVessel.Properties.ShowFooter = False
        Me.cboVessel.Properties.ShowHeader = False
        Me.cboVessel.Properties.ValueMember = "PKey"
        Me.cboVessel.Size = New System.Drawing.Size(249, 22)
        Me.cboVessel.StyleController = Me.LayoutControl1
        Me.cboVessel.TabIndex = 62
        '
        'PanelGTRSControl
        '
        Me.PanelGTRSControl.Location = New System.Drawing.Point(946, 133)
        Me.PanelGTRSControl.Name = "PanelGTRSControl"
        Me.PanelGTRSControl.Size = New System.Drawing.Size(378, 161)
        Me.PanelGTRSControl.TabIndex = 61
        '
        'txtTravelRequestID
        '
        Me.txtTravelRequestID.Location = New System.Drawing.Point(952, 298)
        Me.txtTravelRequestID.Name = "txtTravelRequestID"
        Me.txtTravelRequestID.Size = New System.Drawing.Size(372, 22)
        Me.txtTravelRequestID.StyleController = Me.LayoutControl1
        Me.txtTravelRequestID.TabIndex = 60
        '
        'cboRequestType
        '
        Me.cboRequestType.Location = New System.Drawing.Point(151, 244)
        Me.cboRequestType.Name = "cboRequestType"
        Me.cboRequestType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRequestType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.cboRequestType.Properties.DisplayMember = "Name"
        Me.cboRequestType.Properties.NullText = ""
        Me.cboRequestType.Properties.ShowFooter = False
        Me.cboRequestType.Properties.ShowHeader = False
        Me.cboRequestType.Properties.ValueMember = "PKey"
        Me.cboRequestType.Size = New System.Drawing.Size(249, 22)
        Me.cboRequestType.StyleController = Me.LayoutControl1
        Me.cboRequestType.TabIndex = 54
        '
        'BookingDetailsGrid
        '
        Me.BookingDetailsGrid.Location = New System.Drawing.Point(24, 506)
        Me.BookingDetailsGrid.MainView = Me.BookingDetailsView
        Me.BookingDetailsGrid.Name = "BookingDetailsGrid"
        Me.BookingDetailsGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repBDDateEdit, Me.repBDDateEditWTime, Me.repBDDelete, Me.repBDCopy, Me.repBDStatus})
        Me.BookingDetailsGrid.Size = New System.Drawing.Size(1312, 460)
        Me.BookingDetailsGrid.TabIndex = 50
        Me.BookingDetailsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BookingDetailsView})
        '
        'BookingDetailsView
        '
        Me.BookingDetailsView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.bdBandControls, Me.bdBandTravelDetails, Me.bdBandOrigin, Me.bdBandDestination, Me.bdBandRemarks, Me.bdBandGTRS})
        Me.BookingDetailsView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.bdDelete, Me.bdCopy, Me.bdStatus, Me.bdPKey, Me.bdFKeyTravelBooking, Me.bdFKeyTravelBookingCrew, Me.bdEmployeeNo, Me.bdItemType, Me.bdAmadeusName, Me.bdFlightNumber, Me.bdClassOfService, Me.bdOrigin, Me.bdOriginDesc, Me.bdDepartureTime, Me.bdDestination, Me.bdDestinationDesc, Me.bdArrivalTime, Me.bdFreeText, Me.bdReference, Me.bdPassengerID, Me.bdEdited, Me.bdisFromGTravel})
        Me.BookingDetailsView.GridControl = Me.BookingDetailsGrid
        Me.BookingDetailsView.Name = "BookingDetailsView"
        Me.BookingDetailsView.OptionsFind.AllowFindPanel = False
        Me.BookingDetailsView.OptionsView.ColumnAutoWidth = False
        Me.BookingDetailsView.OptionsView.ShowGroupPanel = False
        '
        'bdBandControls
        '
        Me.bdBandControls.Columns.Add(Me.bdDelete)
        Me.bdBandControls.Columns.Add(Me.bdCopy)
        Me.bdBandControls.Name = "bdBandControls"
        Me.bdBandControls.OptionsBand.ShowInCustomizationForm = False
        Me.bdBandControls.VisibleIndex = 0
        Me.bdBandControls.Width = 72
        '
        'bdDelete
        '
        Me.bdDelete.Caption = " "
        Me.bdDelete.ColumnEdit = Me.repBDDelete
        Me.bdDelete.Name = "bdDelete"
        Me.bdDelete.OptionsColumn.FixedWidth = True
        Me.bdDelete.OptionsColumn.ShowInCustomizationForm = False
        Me.bdDelete.Visible = True
        Me.bdDelete.Width = 36
        '
        'repBDDelete
        '
        Me.repBDDelete.AutoHeight = False
        Me.repBDDelete.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("repBDDelete.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, "", Nothing, Nothing, True)})
        Me.repBDDelete.Name = "repBDDelete"
        Me.repBDDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'bdCopy
        '
        Me.bdCopy.Caption = " "
        Me.bdCopy.ColumnEdit = Me.repBDCopy
        Me.bdCopy.Name = "bdCopy"
        Me.bdCopy.OptionsColumn.FixedWidth = True
        Me.bdCopy.OptionsColumn.ShowInCustomizationForm = False
        Me.bdCopy.Visible = True
        Me.bdCopy.Width = 36
        '
        'repBDCopy
        '
        Me.repBDCopy.AutoHeight = False
        Me.repBDCopy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("repBDCopy.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, "", Nothing, Nothing, True)})
        Me.repBDCopy.Name = "repBDCopy"
        Me.repBDCopy.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'bdBandTravelDetails
        '
        Me.bdBandTravelDetails.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bdBandTravelDetails.AppearanceHeader.Options.UseFont = True
        Me.bdBandTravelDetails.Caption = "Travel Details"
        Me.bdBandTravelDetails.Columns.Add(Me.bdStatus)
        Me.bdBandTravelDetails.Columns.Add(Me.bdPKey)
        Me.bdBandTravelDetails.Columns.Add(Me.bdFKeyTravelBooking)
        Me.bdBandTravelDetails.Columns.Add(Me.bdFKeyTravelBookingCrew)
        Me.bdBandTravelDetails.Columns.Add(Me.bdEmployeeNo)
        Me.bdBandTravelDetails.Columns.Add(Me.bdItemType)
        Me.bdBandTravelDetails.Columns.Add(Me.bdAmadeusName)
        Me.bdBandTravelDetails.Columns.Add(Me.bdReference)
        Me.bdBandTravelDetails.Columns.Add(Me.bdFlightNumber)
        Me.bdBandTravelDetails.Columns.Add(Me.bdClassOfService)
        Me.bdBandTravelDetails.Columns.Add(Me.bdEdited)
        Me.bdBandTravelDetails.Name = "bdBandTravelDetails"
        Me.bdBandTravelDetails.OptionsBand.ShowInCustomizationForm = False
        Me.bdBandTravelDetails.VisibleIndex = 1
        Me.bdBandTravelDetails.Width = 626
        '
        'bdStatus
        '
        Me.bdStatus.Caption = "Status"
        Me.bdStatus.ColumnEdit = Me.repBDStatus
        Me.bdStatus.FieldName = "CancelStatus"
        Me.bdStatus.Name = "bdStatus"
        Me.bdStatus.OptionsColumn.ShowInCustomizationForm = False
        Me.bdStatus.Visible = True
        '
        'repBDStatus
        '
        Me.repBDStatus.AutoHeight = False
        Me.repBDStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.repBDStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PKey", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.repBDStatus.DisplayMember = "Name"
        Me.repBDStatus.DropDownRows = 2
        Me.repBDStatus.Name = "repBDStatus"
        Me.repBDStatus.NullText = ""
        Me.repBDStatus.ShowFooter = False
        Me.repBDStatus.ShowHeader = False
        Me.repBDStatus.ValueMember = "PKey"
        '
        'bdPKey
        '
        Me.bdPKey.Caption = "PKey"
        Me.bdPKey.FieldName = "PKey"
        Me.bdPKey.Name = "bdPKey"
        Me.bdPKey.OptionsColumn.ShowInCustomizationForm = False
        '
        'bdFKeyTravelBooking
        '
        Me.bdFKeyTravelBooking.Caption = "FKeyTravelBooking"
        Me.bdFKeyTravelBooking.FieldName = "FKeyTravelBooking"
        Me.bdFKeyTravelBooking.Name = "bdFKeyTravelBooking"
        Me.bdFKeyTravelBooking.OptionsColumn.ShowInCustomizationForm = False
        '
        'bdFKeyTravelBookingCrew
        '
        Me.bdFKeyTravelBookingCrew.Caption = "FKeyCrew"
        Me.bdFKeyTravelBookingCrew.FieldName = "FKeyCrew"
        Me.bdFKeyTravelBookingCrew.Name = "bdFKeyTravelBookingCrew"
        Me.bdFKeyTravelBookingCrew.OptionsColumn.ShowInCustomizationForm = False
        '
        'bdEmployeeNo
        '
        Me.bdEmployeeNo.Caption = "Employee No"
        Me.bdEmployeeNo.FieldName = "CoIDNo"
        Me.bdEmployeeNo.Name = "bdEmployeeNo"
        Me.bdEmployeeNo.OptionsColumn.ShowInCustomizationForm = False
        '
        'bdItemType
        '
        Me.bdItemType.Caption = "ItemType"
        Me.bdItemType.FieldName = "ItemType"
        Me.bdItemType.Name = "bdItemType"
        Me.bdItemType.OptionsColumn.ShowInCustomizationForm = False
        '
        'bdAmadeusName
        '
        Me.bdAmadeusName.Caption = "Crew Name"
        Me.bdAmadeusName.FieldName = "AmadeusName"
        Me.bdAmadeusName.Name = "bdAmadeusName"
        Me.bdAmadeusName.OptionsColumn.ShowInCustomizationForm = False
        Me.bdAmadeusName.Visible = True
        Me.bdAmadeusName.Width = 152
        '
        'bdReference
        '
        Me.bdReference.Caption = "Reference"
        Me.bdReference.FieldName = "Reference"
        Me.bdReference.Name = "bdReference"
        Me.bdReference.OptionsColumn.ShowInCustomizationForm = False
        Me.bdReference.Visible = True
        Me.bdReference.Width = 168
        '
        'bdFlightNumber
        '
        Me.bdFlightNumber.Caption = "Flight Number"
        Me.bdFlightNumber.FieldName = "FlightNumber"
        Me.bdFlightNumber.Name = "bdFlightNumber"
        Me.bdFlightNumber.OptionsColumn.ShowInCustomizationForm = False
        Me.bdFlightNumber.Visible = True
        Me.bdFlightNumber.Width = 114
        '
        'bdClassOfService
        '
        Me.bdClassOfService.Caption = "Class Of Service"
        Me.bdClassOfService.FieldName = "ClassOfService"
        Me.bdClassOfService.Name = "bdClassOfService"
        Me.bdClassOfService.OptionsColumn.ShowInCustomizationForm = False
        Me.bdClassOfService.Visible = True
        Me.bdClassOfService.Width = 117
        '
        'bdEdited
        '
        Me.bdEdited.Caption = "Edited"
        Me.bdEdited.FieldName = "Edited"
        Me.bdEdited.Name = "bdEdited"
        Me.bdEdited.OptionsColumn.ShowInCustomizationForm = False
        '
        'bdBandOrigin
        '
        Me.bdBandOrigin.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bdBandOrigin.AppearanceHeader.Options.UseFont = True
        Me.bdBandOrigin.AppearanceHeader.Options.UseTextOptions = True
        Me.bdBandOrigin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bdBandOrigin.Caption = "Origin"
        Me.bdBandOrigin.Columns.Add(Me.bdOrigin)
        Me.bdBandOrigin.Columns.Add(Me.bdOriginDesc)
        Me.bdBandOrigin.Columns.Add(Me.bdDepartureTime)
        Me.bdBandOrigin.Name = "bdBandOrigin"
        Me.bdBandOrigin.OptionsBand.ShowInCustomizationForm = False
        Me.bdBandOrigin.VisibleIndex = 2
        Me.bdBandOrigin.Width = 378
        '
        'bdOrigin
        '
        Me.bdOrigin.Caption = "Origin"
        Me.bdOrigin.FieldName = "Origin"
        Me.bdOrigin.Name = "bdOrigin"
        Me.bdOrigin.OptionsColumn.ShowInCustomizationForm = False
        Me.bdOrigin.Visible = True
        Me.bdOrigin.Width = 100
        '
        'bdOriginDesc
        '
        Me.bdOriginDesc.Caption = "Origin Description"
        Me.bdOriginDesc.FieldName = "OriginDesc"
        Me.bdOriginDesc.Name = "bdOriginDesc"
        Me.bdOriginDesc.OptionsColumn.ShowInCustomizationForm = False
        Me.bdOriginDesc.Visible = True
        Me.bdOriginDesc.Width = 155
        '
        'bdDepartureTime
        '
        Me.bdDepartureTime.Caption = "Departure Time"
        Me.bdDepartureTime.ColumnEdit = Me.repBDDateEditWTime
        Me.bdDepartureTime.FieldName = "DepartureTime"
        Me.bdDepartureTime.Name = "bdDepartureTime"
        Me.bdDepartureTime.OptionsColumn.ShowInCustomizationForm = False
        Me.bdDepartureTime.Visible = True
        Me.bdDepartureTime.Width = 123
        '
        'repBDDateEditWTime
        '
        Me.repBDDateEditWTime.AutoHeight = False
        Me.repBDDateEditWTime.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repBDDateEditWTime.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.repBDDateEditWTime.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repBDDateEditWTime.Mask.EditMask = "dd-MMM-yyyy hh:mm tt"
        Me.repBDDateEditWTime.Mask.UseMaskAsDisplayFormat = True
        Me.repBDDateEditWTime.Name = "repBDDateEditWTime"
        '
        'bdBandDestination
        '
        Me.bdBandDestination.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bdBandDestination.AppearanceHeader.Options.UseFont = True
        Me.bdBandDestination.AppearanceHeader.Options.UseTextOptions = True
        Me.bdBandDestination.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bdBandDestination.Caption = "Destination"
        Me.bdBandDestination.Columns.Add(Me.bdDestination)
        Me.bdBandDestination.Columns.Add(Me.bdDestinationDesc)
        Me.bdBandDestination.Columns.Add(Me.bdArrivalTime)
        Me.bdBandDestination.Name = "bdBandDestination"
        Me.bdBandDestination.OptionsBand.ShowInCustomizationForm = False
        Me.bdBandDestination.VisibleIndex = 3
        Me.bdBandDestination.Width = 417
        '
        'bdDestination
        '
        Me.bdDestination.Caption = "Destination"
        Me.bdDestination.FieldName = "Destination"
        Me.bdDestination.Name = "bdDestination"
        Me.bdDestination.OptionsColumn.ShowInCustomizationForm = False
        Me.bdDestination.Visible = True
        Me.bdDestination.Width = 106
        '
        'bdDestinationDesc
        '
        Me.bdDestinationDesc.Caption = "Destination Description"
        Me.bdDestinationDesc.FieldName = "DestinationDesc"
        Me.bdDestinationDesc.Name = "bdDestinationDesc"
        Me.bdDestinationDesc.OptionsColumn.ShowInCustomizationForm = False
        Me.bdDestinationDesc.Visible = True
        Me.bdDestinationDesc.Width = 161
        '
        'bdArrivalTime
        '
        Me.bdArrivalTime.Caption = "Arrival Time"
        Me.bdArrivalTime.ColumnEdit = Me.repBDDateEditWTime
        Me.bdArrivalTime.FieldName = "ArrivalTime"
        Me.bdArrivalTime.Name = "bdArrivalTime"
        Me.bdArrivalTime.OptionsColumn.ShowInCustomizationForm = False
        Me.bdArrivalTime.Visible = True
        Me.bdArrivalTime.Width = 150
        '
        'bdBandRemarks
        '
        Me.bdBandRemarks.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bdBandRemarks.AppearanceHeader.Options.UseFont = True
        Me.bdBandRemarks.Caption = "Remarks"
        Me.bdBandRemarks.Columns.Add(Me.bdFreeText)
        Me.bdBandRemarks.Name = "bdBandRemarks"
        Me.bdBandRemarks.VisibleIndex = 4
        Me.bdBandRemarks.Width = 166
        '
        'bdFreeText
        '
        Me.bdFreeText.Caption = "Remarks"
        Me.bdFreeText.FieldName = "FreeTxt"
        Me.bdFreeText.Name = "bdFreeText"
        Me.bdFreeText.OptionsColumn.ShowInCustomizationForm = False
        Me.bdFreeText.Visible = True
        Me.bdFreeText.Width = 166
        '
        'bdBandGTRS
        '
        Me.bdBandGTRS.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.bdBandGTRS.AppearanceHeader.Options.UseFont = True
        Me.bdBandGTRS.Caption = "GTRS"
        Me.bdBandGTRS.Columns.Add(Me.bdPassengerID)
        Me.bdBandGTRS.Name = "bdBandGTRS"
        Me.bdBandGTRS.OptionsBand.ShowInCustomizationForm = False
        Me.bdBandGTRS.Visible = False
        Me.bdBandGTRS.VisibleIndex = -1
        Me.bdBandGTRS.Width = 75
        '
        'bdPassengerID
        '
        Me.bdPassengerID.Caption = "PassengerID"
        Me.bdPassengerID.FieldName = "PassengerID"
        Me.bdPassengerID.Name = "bdPassengerID"
        Me.bdPassengerID.OptionsColumn.ShowInCustomizationForm = False
        Me.bdPassengerID.Visible = True
        '
        'bdisFromGTravel
        '
        Me.bdisFromGTravel.Caption = "isFromGTravel"
        Me.bdisFromGTravel.FieldName = "isFromGTravel"
        Me.bdisFromGTravel.Name = "bdisFromGTravel"
        Me.bdisFromGTravel.OptionsColumn.ShowInCustomizationForm = False
        '
        'repBDDateEdit
        '
        Me.repBDDateEdit.AutoHeight = False
        Me.repBDDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repBDDateEdit.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[False]
        Me.repBDDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repBDDateEdit.Mask.EditMask = "dd-MMM-yyyy"
        Me.repBDDateEdit.Mask.UseMaskAsDisplayFormat = True
        Me.repBDDateEdit.Name = "repBDDateEdit"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(802, 133)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit1.Size = New System.Drawing.Size(140, 161)
        Me.PictureEdit1.StyleController = Me.LayoutControl1
        Me.PictureEdit1.TabIndex = 49
        '
        'cboLeadTime
        '
        Me.cboLeadTime.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.cboLeadTime.Location = New System.Drawing.Point(912, 384)
        Me.cboLeadTime.Name = "cboLeadTime"
        Me.cboLeadTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLeadTime.Properties.Mask.EditMask = "d"
        Me.cboLeadTime.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.cboLeadTime.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.cboLeadTime.Size = New System.Drawing.Size(64, 22)
        Me.cboLeadTime.StyleController = Me.LayoutControl1
        Me.cboLeadTime.TabIndex = 41
        '
        'lblLeadTime
        '
        Me.lblLeadTime.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Italic)
        Me.lblLeadTime.Location = New System.Drawing.Point(980, 384)
        Me.lblLeadTime.Name = "lblLeadTime"
        Me.lblLeadTime.Size = New System.Drawing.Size(344, 20)
        Me.lblLeadTime.TabIndex = 40
        Me.lblLeadTime.Text = "Days required to process Flight Booking and Visa"
        '
        'txtCurrentDate
        '
        Me.txtCurrentDate.EditValue = Nothing
        Me.txtCurrentDate.Location = New System.Drawing.Point(151, 192)
        Me.txtCurrentDate.Name = "txtCurrentDate"
        Me.txtCurrentDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCurrentDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCurrentDate.Size = New System.Drawing.Size(249, 22)
        Me.txtCurrentDate.StyleController = Me.LayoutControl1
        Me.txtCurrentDate.TabIndex = 25
        '
        'txtTravelDate
        '
        Me.txtTravelDate.EditValue = Nothing
        Me.txtTravelDate.Location = New System.Drawing.Point(151, 218)
        Me.txtTravelDate.Name = "txtTravelDate"
        Me.txtTravelDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtTravelDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTravelDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTravelDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.txtTravelDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtTravelDate.Size = New System.Drawing.Size(249, 22)
        Me.txtTravelDate.StyleController = Me.LayoutControl1
        Me.txtTravelDate.TabIndex = 18
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.Location = New System.Drawing.Point(24, 367)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(762, 61)
        Me.txtRemarks.StyleController = Me.LayoutControl1
        Me.txtRemarks.TabIndex = 17
        '
        'txtETD
        '
        Me.txtETD.EditValue = Nothing
        Me.txtETD.Location = New System.Drawing.Point(533, 186)
        Me.txtETD.Name = "txtETD"
        Me.txtETD.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtETD.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtETD.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtETD.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtETD.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.txtETD.Properties.Mask.EditMask = "dd-MMM-yyyy hh:mm tt"
        Me.txtETD.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtETD.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtETD.Size = New System.Drawing.Size(241, 22)
        Me.txtETD.StyleController = Me.LayoutControl1
        Me.txtETD.TabIndex = 14
        '
        'txtETAL
        '
        Me.txtETAL.EditValue = Nothing
        Me.txtETAL.Location = New System.Drawing.Point(533, 310)
        Me.txtETAL.Name = "txtETAL"
        Me.txtETAL.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtETAL.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtETAL.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtETAL.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtETAL.Properties.Mask.EditMask = "dd-MMM-yyyy hh:mm tt"
        Me.txtETAL.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtETAL.Size = New System.Drawing.Size(241, 22)
        Me.txtETAL.StyleController = Me.LayoutControl1
        Me.txtETAL.TabIndex = 13
        '
        'txtETAE
        '
        Me.txtETAE.EditValue = Nothing
        Me.txtETAE.Location = New System.Drawing.Point(533, 284)
        Me.txtETAE.Name = "txtETAE"
        Me.txtETAE.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtETAE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtETAE.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtETAE.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtETAE.Properties.Mask.EditMask = "dd-MMM-yyyy hh:mm tt"
        Me.txtETAE.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtETAE.Size = New System.Drawing.Size(241, 22)
        Me.txtETAE.StyleController = Me.LayoutControl1
        Me.txtETAE.TabIndex = 12
        '
        'txtDueDate
        '
        Me.txtDueDate.EditValue = Nothing
        Me.txtDueDate.Location = New System.Drawing.Point(912, 334)
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDueDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.txtDueDate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtDueDate.Size = New System.Drawing.Size(203, 22)
        Me.txtDueDate.StyleController = Me.LayoutControl1
        Me.txtDueDate.TabIndex = 11
        '
        'LayoutControlGroup_Main
        '
        Me.LayoutControlGroup_Main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup_Main.GroupBordersVisible = False
        Me.LayoutControlGroup_Main.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem7, Me.LayoutControlGroup_Status, Me.LayoutControlGroup_TravelRequest, Me.tabDetails})
        Me.LayoutControlGroup_Main.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Main.Name = "Root"
        Me.LayoutControlGroup_Main.Size = New System.Drawing.Size(1360, 990)
        Me.LayoutControlGroup_Main.TextVisible = False
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(1028, 0)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(312, 53)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_Status
        '
        Me.LayoutControlGroup_Status.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciMarkAsCompleted, Me.EmptySpaceItem9, Me.LayoutControlItem6})
        Me.LayoutControlGroup_Status.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Status.Name = "LayoutControlGroup_Status"
        Me.LayoutControlGroup_Status.Size = New System.Drawing.Size(1028, 53)
        Me.LayoutControlGroup_Status.TextVisible = False
        '
        'lciMarkAsCompleted
        '
        Me.lciMarkAsCompleted.Control = Me.btnCompleted
        Me.lciMarkAsCompleted.Location = New System.Drawing.Point(268, 0)
        Me.lciMarkAsCompleted.MaxSize = New System.Drawing.Size(0, 29)
        Me.lciMarkAsCompleted.MinSize = New System.Drawing.Size(141, 29)
        Me.lciMarkAsCompleted.Name = "lciMarkAsCompleted"
        Me.lciMarkAsCompleted.Size = New System.Drawing.Size(736, 29)
        Me.lciMarkAsCompleted.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lciMarkAsCompleted.TextSize = New System.Drawing.Size(0, 0)
        Me.lciMarkAsCompleted.TextVisible = False
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(237, 0)
        Me.EmptySpaceItem9.MaxSize = New System.Drawing.Size(31, 0)
        Me.EmptySpaceItem9.MinSize = New System.Drawing.Size(31, 10)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(31, 29)
        Me.EmptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cboBookingStatus
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(237, 29)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Status:"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(90, 16)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlGroup_TravelRequest
        '
        Me.LayoutControlGroup_TravelRequest.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_TravelRequest.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_TravelRequest.ExpandButtonVisible = True
        Me.LayoutControlGroup_TravelRequest.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_Origin, Me.lciRemarks, Me.LayoutControlGroup_RequestInfo, Me.LayoutControlGroup_Destination, Me.LayoutControlGroup_TravelDetails, Me.lciAddFromPlanningEvent})
        Me.LayoutControlGroup_TravelRequest.Location = New System.Drawing.Point(0, 53)
        Me.LayoutControlGroup_TravelRequest.Name = "LayoutControlGroup_TravelRequest"
        Me.LayoutControlGroup_TravelRequest.Size = New System.Drawing.Size(1340, 379)
        Me.LayoutControlGroup_TravelRequest.Text = "1. Travel Information"
        '
        'LayoutControlGroup_Origin
        '
        Me.LayoutControlGroup_Origin.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciETD, Me.LayoutControlItem11})
        Me.LayoutControlGroup_Origin.Location = New System.Drawing.Point(392, 27)
        Me.LayoutControlGroup_Origin.Name = "LayoutControlGroup_Origin"
        Me.LayoutControlGroup_Origin.Size = New System.Drawing.Size(374, 98)
        Me.LayoutControlGroup_Origin.Text = "Origin"
        '
        'lciETD
        '
        Me.lciETD.Control = Me.txtETD
        Me.lciETD.Location = New System.Drawing.Point(0, 26)
        Me.lciETD.Name = "lciETD"
        Me.lciETD.Size = New System.Drawing.Size(350, 26)
        Me.lciETD.Text = "ETD:"
        Me.lciETD.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciETD.TextSize = New System.Drawing.Size(100, 16)
        Me.lciETD.TextToControlDistance = 5
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cboNearestAirport
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(350, 26)
        Me.LayoutControlItem11.Text = "Nearest Airport:"
        Me.LayoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(100, 16)
        Me.LayoutControlItem11.TextToControlDistance = 5
        '
        'lciRemarks
        '
        Me.lciRemarks.Control = Me.txtRemarks
        Me.lciRemarks.Location = New System.Drawing.Point(0, 249)
        Me.lciRemarks.MinSize = New System.Drawing.Size(145, 70)
        Me.lciRemarks.Name = "lciRemarks"
        Me.lciRemarks.Size = New System.Drawing.Size(766, 84)
        Me.lciRemarks.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.lciRemarks.Text = "Remarks:"
        Me.lciRemarks.TextLocation = DevExpress.Utils.Locations.Top
        Me.lciRemarks.TextSize = New System.Drawing.Size(107, 16)
        '
        'LayoutControlGroup_RequestInfo
        '
        Me.LayoutControlGroup_RequestInfo.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciDueDate, Me.LayoutControlItem4, Me.LayoutControlItem10, Me.LayoutControlItem8, Me.EmptySpaceItem8, Me.lciisSentToGTravel, Me.lciGTravelRequestID, Me.EmptySpaceItem10, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.EmptySpaceItem11})
        Me.LayoutControlGroup_RequestInfo.Location = New System.Drawing.Point(766, 0)
        Me.LayoutControlGroup_RequestInfo.Name = "LayoutControlGroup_RequestInfo"
        Me.LayoutControlGroup_RequestInfo.Size = New System.Drawing.Size(550, 333)
        Me.LayoutControlGroup_RequestInfo.Text = "GTRS Travel Request"
        '
        'lciDueDate
        '
        Me.lciDueDate.Control = Me.txtDueDate
        Me.lciDueDate.Location = New System.Drawing.Point(0, 201)
        Me.lciDueDate.Name = "lciDueDate"
        Me.lciDueDate.Size = New System.Drawing.Size(317, 26)
        Me.lciDueDate.Text = "Request Due Date:"
        Me.lciDueDate.TextSize = New System.Drawing.Size(107, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cboLeadTime
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 251)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(178, 26)
        Me.LayoutControlItem4.Text = "Lead Time:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(107, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.PanelGTRSControl
        Me.LayoutControlItem10.Location = New System.Drawing.Point(144, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(382, 165)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.PictureEdit1
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(144, 165)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(144, 165)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(144, 165)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(317, 201)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(90, 26)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'lciisSentToGTravel
        '
        Me.lciisSentToGTravel.Control = Me.chkisSentToGTravel
        Me.lciisSentToGTravel.Location = New System.Drawing.Point(407, 201)
        Me.lciisSentToGTravel.Name = "lciisSentToGTravel"
        Me.lciisSentToGTravel.Size = New System.Drawing.Size(119, 26)
        Me.lciisSentToGTravel.TextSize = New System.Drawing.Size(0, 0)
        Me.lciisSentToGTravel.TextVisible = False
        Me.lciisSentToGTravel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'lciGTravelRequestID
        '
        Me.lciGTravelRequestID.AppearanceItemCaption.BackColor = System.Drawing.Color.Navy
        Me.lciGTravelRequestID.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciGTravelRequestID.AppearanceItemCaption.ForeColor = System.Drawing.Color.White
        Me.lciGTravelRequestID.AppearanceItemCaption.Options.UseBackColor = True
        Me.lciGTravelRequestID.AppearanceItemCaption.Options.UseFont = True
        Me.lciGTravelRequestID.AppearanceItemCaption.Options.UseForeColor = True
        Me.lciGTravelRequestID.Control = Me.txtTravelRequestID
        Me.lciGTravelRequestID.Location = New System.Drawing.Point(0, 165)
        Me.lciGTravelRequestID.Name = "lciGTravelRequestID"
        Me.lciGTravelRequestID.Size = New System.Drawing.Size(526, 26)
        Me.lciGTravelRequestID.Text = "GTravel Request ID:    "
        Me.lciGTravelRequestID.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.lciGTravelRequestID.TextSize = New System.Drawing.Size(145, 16)
        Me.lciGTravelRequestID.TextToControlDistance = 5
        Me.lciGTravelRequestID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(0, 191)
        Me.EmptySpaceItem10.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem10.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(526, 10)
        Me.EmptySpaceItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lblDueDate
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 227)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(526, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.lblLeadTime
        Me.LayoutControlItem1.Location = New System.Drawing.Point(178, 251)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(0, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(24, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(348, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem11
        '
        Me.EmptySpaceItem11.AllowHotTrack = False
        Me.EmptySpaceItem11.Location = New System.Drawing.Point(0, 277)
        Me.EmptySpaceItem11.Name = "EmptySpaceItem11"
        Me.EmptySpaceItem11.Size = New System.Drawing.Size(526, 10)
        Me.EmptySpaceItem11.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_Destination
        '
        Me.LayoutControlGroup_Destination.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciPort, Me.lciETAE, Me.lciETAL})
        Me.LayoutControlGroup_Destination.Location = New System.Drawing.Point(392, 125)
        Me.LayoutControlGroup_Destination.Name = "LayoutControlGroup_Destination"
        Me.LayoutControlGroup_Destination.Size = New System.Drawing.Size(374, 124)
        Me.LayoutControlGroup_Destination.Text = "Destination"
        '
        'lciPort
        '
        Me.lciPort.Control = Me.cboPort
        Me.lciPort.Location = New System.Drawing.Point(0, 0)
        Me.lciPort.Name = "lciPort"
        Me.lciPort.Size = New System.Drawing.Size(350, 26)
        Me.lciPort.Text = "Port:"
        Me.lciPort.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciPort.TextSize = New System.Drawing.Size(100, 16)
        Me.lciPort.TextToControlDistance = 5
        '
        'lciETAE
        '
        Me.lciETAE.Control = Me.txtETAE
        Me.lciETAE.Location = New System.Drawing.Point(0, 26)
        Me.lciETAE.Name = "lciETAE"
        Me.lciETAE.Size = New System.Drawing.Size(350, 26)
        Me.lciETAE.Text = "ETA (Earliest):"
        Me.lciETAE.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciETAE.TextSize = New System.Drawing.Size(100, 16)
        Me.lciETAE.TextToControlDistance = 5
        '
        'lciETAL
        '
        Me.lciETAL.Control = Me.txtETAL
        Me.lciETAL.Location = New System.Drawing.Point(0, 52)
        Me.lciETAL.Name = "lciETAL"
        Me.lciETAL.Size = New System.Drawing.Size(350, 26)
        Me.lciETAL.Text = "ETA (Latest):"
        Me.lciETAL.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciETAL.TextSize = New System.Drawing.Size(100, 16)
        Me.lciETAL.TextToControlDistance = 5
        '
        'LayoutControlGroup_TravelDetails
        '
        Me.LayoutControlGroup_TravelDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lcgPlanningEvent, Me.lciCurrentDate, Me.lciTravelDate, Me.LayoutControlItem5, Me.lciVessel, Me.lciRefNo})
        Me.LayoutControlGroup_TravelDetails.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControlGroup_TravelDetails.Name = "LayoutControlGroup_TravelDetails"
        Me.LayoutControlGroup_TravelDetails.Size = New System.Drawing.Size(392, 222)
        Me.LayoutControlGroup_TravelDetails.Text = "Travel Details"
        '
        'lcgPlanningEvent
        '
        Me.lcgPlanningEvent.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.lciPlanningEvent})
        Me.lcgPlanningEvent.Location = New System.Drawing.Point(0, 0)
        Me.lcgPlanningEvent.Name = "lcgPlanningEvent"
        Me.lcgPlanningEvent.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.lcgPlanningEvent.Size = New System.Drawing.Size(368, 32)
        Me.lcgPlanningEvent.TextVisible = False
        '
        'lciPlanningEvent
        '
        Me.lciPlanningEvent.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lciPlanningEvent.AppearanceItemCaption.Options.UseFont = True
        Me.lciPlanningEvent.Control = Me.cboFKeyPlanningEvent
        Me.lciPlanningEvent.Location = New System.Drawing.Point(0, 0)
        Me.lciPlanningEvent.Name = "lciPlanningEvent"
        Me.lciPlanningEvent.Size = New System.Drawing.Size(362, 26)
        Me.lciPlanningEvent.Text = "Planning Event:"
        Me.lciPlanningEvent.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciPlanningEvent.TextSize = New System.Drawing.Size(110, 16)
        Me.lciPlanningEvent.TextToControlDistance = 5
        '
        'lciCurrentDate
        '
        Me.lciCurrentDate.Control = Me.txtCurrentDate
        Me.lciCurrentDate.Location = New System.Drawing.Point(0, 32)
        Me.lciCurrentDate.Name = "lciCurrentDate"
        Me.lciCurrentDate.Size = New System.Drawing.Size(368, 26)
        Me.lciCurrentDate.Text = "Current Date:"
        Me.lciCurrentDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciCurrentDate.TextSize = New System.Drawing.Size(110, 16)
        Me.lciCurrentDate.TextToControlDistance = 5
        Me.lciCurrentDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'lciTravelDate
        '
        Me.lciTravelDate.Control = Me.txtTravelDate
        Me.lciTravelDate.Location = New System.Drawing.Point(0, 58)
        Me.lciTravelDate.Name = "lciTravelDate"
        Me.lciTravelDate.Size = New System.Drawing.Size(368, 26)
        Me.lciTravelDate.Text = "Travel Date:"
        Me.lciTravelDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciTravelDate.TextSize = New System.Drawing.Size(110, 16)
        Me.lciTravelDate.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboRequestType
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(368, 26)
        Me.LayoutControlItem5.Text = "Travel Type:"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(110, 16)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'lciVessel
        '
        Me.lciVessel.Control = Me.cboVessel
        Me.lciVessel.Location = New System.Drawing.Point(0, 110)
        Me.lciVessel.Name = "lciVessel"
        Me.lciVessel.Size = New System.Drawing.Size(368, 26)
        Me.lciVessel.Text = "Vessel:"
        Me.lciVessel.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciVessel.TextSize = New System.Drawing.Size(110, 16)
        Me.lciVessel.TextToControlDistance = 5
        '
        'lciRefNo
        '
        Me.lciRefNo.Control = Me.txtRefNo
        Me.lciRefNo.Location = New System.Drawing.Point(0, 136)
        Me.lciRefNo.Name = "lciRefNo"
        Me.lciRefNo.Size = New System.Drawing.Size(368, 40)
        Me.lciRefNo.Text = "Reference No.:"
        Me.lciRefNo.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.lciRefNo.TextSize = New System.Drawing.Size(110, 16)
        Me.lciRefNo.TextToControlDistance = 5
        '
        'lciAddFromPlanningEvent
        '
        Me.lciAddFromPlanningEvent.Control = Me.btnAddFromPlanningEvent
        Me.lciAddFromPlanningEvent.Location = New System.Drawing.Point(0, 0)
        Me.lciAddFromPlanningEvent.Name = "lciAddFromPlanningEvent"
        Me.lciAddFromPlanningEvent.Size = New System.Drawing.Size(766, 27)
        Me.lciAddFromPlanningEvent.TextSize = New System.Drawing.Size(0, 0)
        Me.lciAddFromPlanningEvent.TextVisible = False
        Me.lciAddFromPlanningEvent.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'tabDetails
        '
        Me.tabDetails.AppearanceTabPage.Header.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.tabDetails.AppearanceTabPage.Header.Options.UseFont = True
        Me.tabDetails.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.tabDetails.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.tabDetails.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabDetails.Location = New System.Drawing.Point(0, 432)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.SelectedTabPage = Me.LayoutControlGroup_Passenger
        Me.tabDetails.SelectedTabPageIndex = 0
        Me.tabDetails.Size = New System.Drawing.Size(1340, 538)
        Me.tabDetails.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_Passenger, Me.LayoutControlGroup_BookingDetails, Me.LayoutControlGroup2})
        '
        'LayoutControlGroup_Passenger
        '
        Me.LayoutControlGroup_Passenger.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_Passenger.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_Passenger.ExpandButtonVisible = True
        Me.LayoutControlGroup_Passenger.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup_AddPassenger, Me.lciPassengerGrid, Me.EmptySpaceItem5})
        Me.LayoutControlGroup_Passenger.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_Passenger.Name = "LayoutControlGroup_Passenger"
        Me.LayoutControlGroup_Passenger.Size = New System.Drawing.Size(1316, 489)
        Me.LayoutControlGroup_Passenger.Text = "2. Crews/Passengers"
        '
        'LayoutControlGroup_AddPassenger
        '
        Me.LayoutControlGroup_AddPassenger.Expanded = False
        Me.LayoutControlGroup_AddPassenger.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9, Me.LayoutControlItem12})
        Me.LayoutControlGroup_AddPassenger.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_AddPassenger.Name = "LayoutControlGroup_AddPassenger"
        Me.LayoutControlGroup_AddPassenger.Size = New System.Drawing.Size(651, 31)
        Me.LayoutControlGroup_AddPassenger.Text = "Select Crew to Add as Passenger"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.btnAddCrew
        Me.LayoutControlItem9.Location = New System.Drawing.Point(287, 0)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(79, 27)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(79, 27)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(79, 27)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.cboAddCrew
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(287, 27)
        Me.LayoutControlItem12.Text = "Select Crew:"
        Me.LayoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(80, 20)
        Me.LayoutControlItem12.TextToControlDistance = 5
        '
        'lciPassengerGrid
        '
        Me.lciPassengerGrid.Control = Me.PassengerGrid
        Me.lciPassengerGrid.Location = New System.Drawing.Point(0, 31)
        Me.lciPassengerGrid.Name = "lciPassengerGrid"
        Me.lciPassengerGrid.Size = New System.Drawing.Size(1316, 458)
        Me.lciPassengerGrid.TextSize = New System.Drawing.Size(0, 0)
        Me.lciPassengerGrid.TextVisible = False
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(651, 0)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(665, 31)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup_BookingDetails
        '
        Me.LayoutControlGroup_BookingDetails.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup_BookingDetails.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup_BookingDetails.ExpandButtonVisible = True
        Me.LayoutControlGroup_BookingDetails.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem6})
        Me.LayoutControlGroup_BookingDetails.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup_BookingDetails.Name = "LayoutControlGroup_BookingDetails"
        Me.LayoutControlGroup_BookingDetails.Size = New System.Drawing.Size(1316, 489)
        Me.LayoutControlGroup_BookingDetails.Text = "3. Booking Details"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.BookingDetailsGrid
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1316, 464)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(1316, 25)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1316, 489)
        Me.LayoutControlGroup2.Text = "4. Costs"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TravelCostGrid
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(1316, 489)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 684)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1319, 10)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 694)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1319, 10)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'Travel_GTRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "Travel_GTRS"
        Me.Size = New System.Drawing.Size(1364, 1018)
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.chkisSentToGTravel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassengerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassengerView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPContactDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPFlightDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repPAirport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFKeyPlanningEvent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAddCrew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNearestAirport.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TravelCostGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TravelCostView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepTravelCostItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepCurr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepSpinEditDecimal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcRepSpinEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBookingStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRefNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelGTRSControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelRequestID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRequestType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookingDetailsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookingDetailsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBDDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBDCopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBDStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBDDateEditWTime.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBDDateEditWTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBDDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repBDDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLeadTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrentDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurrentDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtETD.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtETD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtETAL.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtETAL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtETAE.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtETAE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciMarkAsCompleted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_TravelRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Origin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciETD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_RequestInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciDueDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciisSentToGTravel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciGTravelRequestID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Destination, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciETAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciETAL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_TravelDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lcgPlanningEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPlanningEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciCurrentDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciTravelDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciRefNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciAddFromPlanningEvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_Passenger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_AddPassenger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lciPassengerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup_BookingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup_Main As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtETD As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtETAL As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtETAE As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lciDueDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciETAE As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciETAL As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciETD As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lciRemarks As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_TravelRequest As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtTravelDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lciTravelDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_RequestInfo As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtCurrentDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lciCurrentDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboLeadTime As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblLeadTime As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BookingDetailsGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cboRequestType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents repBDDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents repBDDateEditWTime As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents txtTravelRequestID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelGTRSControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents repBDCopy As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents repBDDelete As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents cboVessel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lciVessel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtRefNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboPort As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lciPort As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciRefNo As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboBookingStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TravelCostGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents TravelCostView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tcPKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcFKeyTravelBooking As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcInvoiceNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcInvoiceDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcRepDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents tcTravelCostItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcRepTravelCostItem As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents tcDetails As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcBookingRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcRepCurr As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents tcAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcRepSpinEditDecimal As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents tcExRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcConvertedAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcTravelAgentRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcTravelAgentRefDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcRepMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents tcRepSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents tcEdited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcDelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tcRepDelete As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents LayoutControlGroup_Origin As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_Destination As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnAddCrew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboNearestAirport As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Public WithEvents cboAddCrew As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents repBDStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnAddFromPlanningEvent As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lciAddFromPlanningEvent As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cboFKeyPlanningEvent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lciPlanningEvent As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lcgPlanningEvent As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnCompleted As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lciMarkAsCompleted As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_Status As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_TravelDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents tabDetails As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup_Passenger As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup_AddPassenger As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup_BookingDetails As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lciGTravelRequestID As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents PassengerGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents PassengerView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents colPPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPFKeyCrew As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPETD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPETAE As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPETAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPFKeyNearestAirport As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPFKeyAlternateAirport As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFrequentFlyerMembership As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colFrequentFlyerNumber As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repPDocuments As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents repPContactDetails As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents lciPassengerGrid As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents repPFlightDetails As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colPFlightDetails As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPShowTravelDocuments As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPContactDetails As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colPRemove As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repPRemove As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents colPCrewName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPPassengerID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repPAirport As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkisSentToGTravel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lciisSentToGTravel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colPisSentToGTravel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents repPDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BookingDetailsView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents bdDelete As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdCopy As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdPKey As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdFKeyTravelBooking As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdFKeyTravelBookingCrew As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdEmployeeNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdItemType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdAmadeusName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdReference As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdFlightNumber As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdClassOfService As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdEdited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdOrigin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdOriginDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdDepartureTime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdDestination As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdDestinationDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdArrivalTime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdFreeText As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents bdPassengerID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents colPEdited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem11 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents bdisFromGTravel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents bandCrewDetail As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandTravelDetails As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandStat As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandAirport As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandFrequentFlyer As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandGTRS As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bdBandControls As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bdBandTravelDetails As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bdBandOrigin As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bdBandDestination As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bdBandRemarks As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bdBandGTRS As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
