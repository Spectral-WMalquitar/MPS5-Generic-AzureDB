Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Drawing

Public Class Travel_GTRS
    Private FormName As String = "Travel Manager (using GTRS)"
    Private clsSecurity As New clsSecurity

    Private HasDeletePermission As Boolean = False

    Dim clsAudit As New clsAudit
    Dim dtVessels As New DataTable
    Dim dvVessels As New DataView
    Dim dtAirport As New DataTable
    Dim dtRanks As New DataTable
    Dim dtCrews As New DataTable
    Dim dvCrews As DataView
    Dim dtBookingStatus As DataTable
    Dim dtPlanningEvent As DataTable

    Private showPromptToSendToGTravel As Boolean = True

#Region "Flags"
    Private isCheckIfChangingBookingStatus As Boolean = False
    Private isAfterSaving As Boolean = False
#End Region

    Private Const ADD_CREW_PASSENGER_LABEL As String = "Select Crew to Add as Passenger"
    Private Const DEFAULT_BOOKING_STATUS As String = "SYSBSNEW"
    Private ApplyPassengerGridBackColor As Boolean = False

    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Private WithEvents oGTRSControl As BaseGTRSControl

    Private GRID_FOCUS_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(200, 247, 200)    'System.Drawing.Color.Azure

    Private GTRSPassengerList As New List(Of GTRSPassenger)

    Private BookingStatus As New BookingStatusStructure

#Region "Structures"
    Private Structure BookingStatusStructure
        'Public WaitingForGTRSResponse As Boolean
        Public Booked As Boolean
        Public Updated As Boolean
        Public Completed As Boolean

        Sub Init()
            Booked = False
            Updated = False
            Completed = False
        End Sub
    End Structure

    Private Structure BookedOrCanceled
        Public Shared Booked As String = "BOOKED"
        Public Shared Canceled As String = "CANCELED"
    End Structure

    Private Structure GTRSPassenger
        Public Mode As GTRSPassengerMode
        Public FKeyTravelBookingCrew As String
        Public Passenger As Object

        Public Sub New(oMode As GTRSPassengerMode, cFKeyTravelBookingCrew As String, oPassenger As Object)
            Mode = oMode
            FKeyTravelBookingCrew = cFKeyTravelBookingCrew
            Passenger = oPassenger

        End Sub

    End Structure

    Private Enum GTRSPassengerMode
        Add = 1
        Update = 2
        Cancel = 3
    End Enum

#End Region

#Region "Properties"
    'Private LayoutControlGroups As DevExpress.XtraLayout.LayoutControlGroup()
    Private ReadOnly Property LayoutControlGroups As DevExpress.XtraLayout.LayoutControlGroup()
        Get
            Return New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup_TravelDetails, LayoutControlGroup_TravelRequest, LayoutControlGroup_Status, LayoutControlGroup_Origin, LayoutControlGroup_Destination, LayoutControlGroup_RequestInfo, LayoutControlGroup_Passenger, LayoutControlGroup_BookingDetails, LayoutControlGroup_AddPassenger}
        End Get
    End Property

    Private ReadOnly Property RequiredFields As DevExpress.XtraEditors.TextEdit()
        Get
            Return New DevExpress.XtraEditors.TextEdit() {cboVessel, txtTravelDate, cboPort, txtRefNo, txtETD, txtETAE, txtETAL, cboNearestAirport}
        End Get
    End Property

    Public Property TravelRequestID As String

        Get
            Return IfNull(txtTravelRequestID.EditValue, "")
        End Get
        Set(value As String)
            txtTravelRequestID.EditValue = IfNull(value, "")
        End Set
    End Property

    Public ReadOnly Property TravelRequestIsBooked As Boolean
        Get
            Return cboBookingStatus.EditValue.Equals(TravelBookingStatus.Booked.Key)
        End Get
    End Property

    'Private _HasUpdatesForGTravel As Boolean = False
    'Public Property HasUpdatesForGTravel As Boolean
    '    Set(value As Boolean)
    '        _HasUpdatesForGTravel = value
    '        oGTRSControl.ExecCustomFunction(New Object() {""})
    '    End Set
    '    Get
    '        Return _HasUpdatesForGTravel
    '    End Get
    'End Property


#End Region

#Region "Inits"
    Private Sub initControls()
        header.Focus()

        clsAudit.propSQLConnStr = MPSDB.GetConnectionString 'neil


    End Sub

    Private Sub initLookupEdits()
        'AIRPORT
        SetupAirportLookupEdit()
        SetupAirportSearchLookupEdit()

        'CREW SELECTION - check initDatatables for data initialization
        cboAddCrew.Properties.DataSource = dtCrews
        SetupCrewSelectionLookupEdit()

        'PORT
        cboPort.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmport ORDER BY Name")

        'VESSEL - check initDatatables for data initialization
        ShowVesselData(False)


        'STATUS
        cboBookingStatus.Properties.DataSource = dtBookingStatus
        cboBookingStatus.Properties.DropDownRows = TryCast(cboBookingStatus.Properties.DataSource, DataTable).Rows.Count

        'PLANNING EVENT
        '<!-- edited by tony20181127 : should only refresh when user is going to select a planning event
        'SetupPlanningEventLookupEdit()
        dtPlanningEvent = Nothing
        '--> 

        'REQUEST TYPE
        Dim dt As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        dt.Rows.Add(New Object() {PassengerRequestType.Embark.Key, PassengerRequestType.Embark.Value})
        dt.Rows.Add(New Object() {PassengerRequestType.Disembark.Key, PassengerRequestType.Disembark.Value})
        cboRequestType.Properties.DataSource = dt


        'TRAVEL COSTS
        'TRAVEL COST ITEM
        tcRepTravelCostItem.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmTravelCostItem ORDER BY Name")

        'CURRENCY
        tcRepCurr.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmCurr ORDER BY Ref Desc, Name")

        'BOOKING DETAILS CANCELATION STATUS
        dt = New DataTable
        col = New DataColumn
        col.ColumnName = "PKey"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "Name"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        dt.Rows.Add(New Object() {"BOOKED", "Booked"})
        dt.Rows.Add(New Object() {"CANCELED", "Canceled"})
        repBDStatus.DataSource = dt
    End Sub

    ''' <summary>
    ''' Sets up data source of Planning Event Selection
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetupPlanningEventLookupEdit()
        Dim dt As New DataTable
        Dim cSQL As String

        'Planning Event
        cSQL = "SELECT pe.PKey, concat(vsl.name, ' / ', format(pe.planneddateson, 'dd-MMM-yyyy')) as PlanningEventLabel, pe.PlanningEvent, pe.FKeyVessel, vsl.Name as Vessel, format(pe.PlannedDateSON,'dd-MMM-yyyy') as PlannedDateSignOn, pe.PlannedPlaceSON, port.Name as PlannedPlaceSignOn, pe.Remarks " & _
               "FROM	dbo.tblPlanningEvent pe INNER JOIN " & _
               "        (SELECT FKeyPlanningEvent FROM dbo.tblPlanningEventCrew WHERE FKeyActivity is null GROUP BY FKeyPlanningEvent) pendingPEvent ON pendingPEvent.FKeyPlanningEvent = pe.PKey INNER JOIN " & _
               "        dbo.tbladmvsl vsl ON pe.FKeyVessel = vsl.PKey LEFT JOIN " & _
               "        dbo.tbladmport port ON pe.PlannedPlaceSON = port.PKey " & _
               "ORDER BY vsl.Name, pe.planneddateson desc "

        dtPlanningEvent = New DataTable
        dtPlanningEvent = MPSDB.CreateTable(cSQL)
        cboFKeyPlanningEvent.Properties.DataSource = dtPlanningEvent
    End Sub

    Private Sub SetupAirportLookupEdit()
        Dim repCtl As DevExpress.XtraEditors.SearchLookUpEdit = cboNearestAirport
        repCtl.Properties.DataSource = dtAirport
        Dim gcol As DevExpress.XtraGrid.Columns.GridColumn
        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "PKey"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "Name"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "Abbrv"
        gcol.FieldName = gcol.Name
        gcol.Caption = "Abbrv / Airport Code"
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "AirportAbbrvLabel"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        With repCtl.Properties
            .ValueMember = "PKey"
            .DisplayMember = "AirportAbbrvLabel"
            .NullText = String.Empty
            .ShowClearButton = False
            .ShowFooter = False
            .AppearanceFocused.BackColor = EDITED_FOCUSED_COLOR
        End With
    End Sub

    Private Sub SetupAirportSearchLookupEdit()
        Dim repCtl As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit = repPAirport
        repCtl.DataSource = dtAirport
        Dim gcol As DevExpress.XtraGrid.Columns.GridColumn
        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "PKey"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "Name"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = True
        repCtl.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "Abbrv"
        gcol.FieldName = gcol.Name
        gcol.Caption = "Abbrv / Airport Code"
        gcol.Visible = True
        repCtl.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "AirportAbbrvLabel"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.View.Columns.Add(gcol)

        With repCtl
            .ValueMember = "PKey"
            .DisplayMember = "AirportAbbrvLabel"
            .NullText = String.Empty
            .ShowClearButton = False
            .ShowFooter = False
            .AppearanceFocused.BackColor = EDITED_FOCUSED_COLOR
        End With
    End Sub

    Private Sub SetupCrewSelectionLookupEdit()
        Dim repCtl As DevExpress.XtraEditors.SearchLookUpEdit = cboAddCrew
        repCtl.Properties.DataSource = dtCrews
        Dim gcol As DevExpress.XtraGrid.Columns.GridColumn
        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "PKey"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "COIDNo"
        gcol.FieldName = gcol.Name
        gcol.Caption = "Company ID"
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "LName"
        gcol.FieldName = gcol.Name
        gcol.Caption = "Last Name"
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "FName"
        gcol.FieldName = gcol.Name
        gcol.Caption = "First Name"
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "MName"
        gcol.FieldName = gcol.Name
        gcol.Caption = "Middle Name"
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "RankName"
        gcol.FieldName = gcol.Name
        gcol.Caption = "Rank"
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "CrewName"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        With repCtl.Properties
            .ValueMember = "FKeyCrew"
            .DisplayMember = "CrewName"
            .NullText = String.Empty
            .ShowClearButton = False
            .ShowFooter = False
            .AppearanceFocused.BackColor = EDITED_FOCUSED_COLOR
        End With
    End Sub

    ''' <summary>
    ''' Sets if to show only active vessels in the Vessel Dropdown
    ''' </summary>
    ''' <param name="ActiveVesselOnly"></param>
    ''' <remarks>If viewing a record, inactive vessels must be shown. But if editing, should only be able to select from active vessels </remarks>
    Private Sub ShowVesselData(ActiveVesselOnly As Boolean, Optional FilterOutCurrentlySelectedIfInactive As Boolean = True)
        If ActiveVesselOnly Then
            cboVessel.Properties.DataSource = vesselDTSource(vesselDTSourceFilter.ActiveOnly, IIf(FilterOutCurrentlySelectedIfInactive, IfNull(cboVessel.EditValue, ""), ""))

        Else
            cboVessel.Properties.DataSource = vesselDTSource(vesselDTSourceFilter.All)

        End If
    End Sub

    Private Sub initDatatables()
        'VESSEL
        USER_INFO.InitFilteredUserData(UserDetail.FilteredUserDataTables.VesselAll)
        dtVessels = USER_INFO.FilteredVesselDT
        dvVessels = New DataView(dtVessels)

        'AIRPORT
        dtAirport = MPSDB.CreateTable("SELECT *, concat(name, CASE WHEN len(isnull(abbrv,'')) > 0 THEN concat(' (',abbrv,')') ELSE ''END) as AirportAbbrvLabel FROM dbo.tbladmairport ORDER BY Name")

        'RANKS
        dtRanks = MPSDB.CreateTable("SELECT * FROM dbo.tbladmrank ORDER BY Name")

        'CREWS - ADD PASSENGER
        '<!-- edited by tony20181116
        'dtCrews = MPSDB.CreateTable("SELECT * FROM dbo.ViewTravelBookingCrewSelection ORDER BY CrewName")
        dtCrews = MPSDB.CreateTable("EXEC dbo.CreateSrc_TravelGTRSCrewSelection '" & GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt") & "' ")
        dvCrews = New DataView(dtCrews)

        'BOOKING STATUS
        dtBookingStatus = MPSDB.CreateTable("SELECT PKey, UPPER(Name) Name FROM dbo.tbladmbookingstatus ORDER BY SortCode")

    End Sub

    Private Sub InitGTravelUserControl()

        If IsNothing(oGTRS) Then
            'Dim i As System.ServiceModel.ClientBase(Of GTRSServiceReference.GTRSServiceClass)
            oGTRS = New GTRSService
        End If

        oGTRS.Init()
        oGTRS.clsAudit = clsAudit
        oGTRSControl = GTRSControlObject(oGTRS.MyStatus, oGTRS.MyStatusDesc)
        oGTRSControl.RefreshData()
        With PanelGTRSControl
            .Controls.Clear()
            .Controls.Add(oGTRSControl)
            If Not IsNothing(oGTRSControl) Then
                oGTRSControl.Dock = DockStyle.Fill
            End If
            .Height = oGTRSControl.Height
        End With

        If Not IsNothing(oGTRSControl) Then
            oGTRSControl.RefreshData()
            oGTRSControl.bContent = Me
            oGTRSControl.Dock = DockStyle.Fill
        End If
    End Sub

    Private Function GTRSControlObject(serviceStatus As GTRSServiceStatus, serviceStatusDesc As String) As BaseGTRSControl
        Dim ReturnValue As BaseGTRSControl = Nothing

        If serviceStatus = GTRSServiceStatus.Okay Then
            ReturnValue = New GTRSControl
        ElseIf serviceStatus = GTRSServiceStatus.NotEnabled Then
            ReturnValue = New GTRSControl_Invalid
            ReturnValue.ExecCustomFunction(New Object() {"UPDATE_DISPLAY_MESSAGE", "G Travel Service Feature is Not Enabled."})
        ElseIf serviceStatus = GTRSServiceStatus.Okay Then
            ReturnValue = New GTRSControl_Invalid
            ReturnValue.ExecCustomFunction(New Object() {"UPDATE_DISPLAY_MESSAGE", IIf(IfNull(serviceStatusDesc, "").Length > 0, serviceStatusDesc, "Failed to initialized GTRS Integration.")})
        Else
            ReturnValue = New GTRSControl_Invalid
            ReturnValue.ExecCustomFunction(New Object() {"UPDATE_DISPLAY_MESSAGE", IIf(IfNull(serviceStatusDesc, "").Length > 0, serviceStatusDesc, "Service Unavailable.")})
        End If

        Return ReturnValue
    End Function

    Private Enum vesselDTSourceFilter
        All
        ActiveOnly
        InactiveOnly
    End Enum

    Private Function vesselDTSource(Filter As vesselDTSourceFilter, Optional IncludeSpecificVslCode As String = "") As DataTable
        Dim cCondition As String = ""

        Select Case Filter
            Case vesselDTSourceFilter.ActiveOnly
                cCondition = "VslStat = 1"

            Case vesselDTSourceFilter.InactiveOnly
                cCondition = "VslStat = 2"

            Case vesselDTSourceFilter.All
                cCondition = ""

            Case Else
                cCondition = ""
        End Select

        If IfNull(IncludeSpecificVslCode, "").Length > 0 Then
            cCondition = cCondition & _
                         IIf(IfNull(cCondition, "").Length > 0 And IfNull(IncludeSpecificVslCode, "").Length > 0, " OR ", "") & _
                         "PKey = '" & IncludeSpecificVslCode & "'"
        End If

        dvVessels.RowFilter = cCondition
        dvVessels.Sort = "Name"
        Return dvVessels.ToTable

    End Function

    Private Sub ClearContent()
        strID = ""
        Me.header.Text = "Travel Booking"
        LoadSub()
    End Sub

#End Region

#Region "Refresh"
    ''' <summary>
    ''' Initialize Variables and Controls
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitVariablesAndControls()
        '************************************************************************************************
        '### Initialize Variables
        TableName = "tblTravelBooking"
        bAddMode = False
        isEditdable = False
        isCheckIfChangingBookingStatus = False

        '************************************************************************************************
        '### Initialize Controls
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Travel Details - " & strDesc)

        tabDetails.SelectedTabPage = LayoutControlGroup_Passenger

        'SetDeleteCaption(Name, "Delete Travel Request")
        SetDeleteCaption(Name, "Delete")
        cboAddCrew.EditValue = ""
        Application.DoEvents()
        SetRibbonPageGroupVisibility(Name, "rpgTravelRefresh", True)
        Application.DoEvents()

        '### Disable Add From Planning Event button
        AllowAddFromPlanningEvent(False)
        '### Disable Add Passenger
        EnableAddPassengerGroup(False)

        '************************************************************************************************
        '### Initialize Booking Status variable
        BookingStatus.Init()

    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()

        '************************************************************************************************
        InitVariablesAndControls()

        '************************************************************************************************
        If bLoaded = False Then
            LayoutControlGroup_TravelRequest.Expanded = True
            initControls()
            blList.RefreshData()    'note [tony20180404]: this is added because the bllist's mainview.rowcount does not return the real row count even after the maingrid.datasource does have a content
            RaiseCustomEvent(Name, New Object() {"SetUpTravelGTRSControls"})
            clsSecurity.propSQLConnStr = MPSDB.GetConnectionString

            '************************************************************************************************
            '### Init Button Captions
            SetAddCaption(Name, "Add")
            SetSaveCaption(Name, "Save")
            SetEditCaption(Name, "Edit")
            SetDeleteCaption(Name, "Delete")

            '************************************************************************************************
            '### Checks if has delete permission
            HasDeletePermission = Not clsSecurity.hasNoDeletePermission(Me.Name, USER_ID, True, userPermDt)

            '************************************************************************************************
            '### Initialize Controls
            ShowPlanningEventDetail(False)

            '<!-- edited by tony20181127 - simplified getting of variable
            'MPSDB.BeginReader("SELECT dbo.GetRptDataMapCodeValue('BOOKINGSTATUS_NEW') PKey")
            'While MPSDB.Read()
            '    DefaultBookingStatus = MPSDB.ReaderItem("PKey")
            'End While
            'MPSDB.CloseReader()
            '-->

            '************************************************************************************************
            '### Initialize LookupEdits, especially admin data
            InitGTravelUserControl()    'Initializes the PanelControl for GTRS
            initDatatables()
            initLookupEdits()

            bLoaded = True
        End If

        '************************************************************************************************
        '### Checks if there are records listed in the main list
        If blList.GetID() = "" Then
            '### has no record

            '### Clears All Fields 
            ClearFields(Me.LayoutControl1.Root, False)
            '### Clears Passenger List
            ClearPassengerList()

            AllowEditing(Name, False)
            AllowDeletion(Name, False)
            ShowPlanningEventDetail(False)
            oGTRSControl.BookedWithGTravel = False
        Else
            '### has record
            LoadSub()
            BRECORDUPDATEDs = False
            AllowEditing(Name, Not BookingStatus.Completed)
            AllowDeletion(Name, Not BookingStatus.Completed)
            PassengerView.Bands("bandGTRS").Visible = oGTRSControl.BookedWithGTravel
        End If

        isAfterSaving = False
        oGTRSControl.RefreshData()

        '************************************************************************************************
        '### Update button captions
        AllowSaving(Name, False)
        AllowAddition(Name, True)
        RaiseCustomEvent(Name, New Object() {"ShowCancelButton", False})

        '************************************************************************************************
        '### Disable Grids for editing
        EditSubAllowGrid(PassengerView, False)
        EditSubAllowGrid(BookingDetailsView, False)
        EditSubAllowGrid(TravelCostView, False)

        '************************************************************************************************
        '### Shows all vessel in vessel dropdown
        ShowVesselData(False)

        '************************************************************************************************
        '### Disable Remove Passenger button
        EnableRemovePassenger(False)

        '************************************************************************************************
        '### Disable Mark as Completed Button
        EnableMarkAsCompleted(False)

        '************************************************************************************************
        '### Hide Delete and Copy buttons in Booking Details and Costs GridView
        ShowManualBookingCtls(False)
        ShowTravelCostsCtls(False)

        '************************************************************************************************
        '### Set Edit Check basecontrol variable to false
        EditCheck(Name, False)
        BRECORDUPDATEDs = False

        '************************************************************************************************
        '### Sets PassengerView FocusedRow BackColor to Nothing/White
        PassengerView.Appearance.FocusedRow.BackColor = Nothing

        '************************************************************************************************
        '### Removes EditListeners and Set to ReadOnly
        RemoveEditListener(LayoutControlGroups, False)
        RemoveGTRSEditListener()
        MakeReadOnlyListener(LayoutControlGroups)

        '************************************************************************************************
        '### Update Status Colors
        SetCompletedCheckColor()
        SetBookingStatusColorProperty()     'called after the AddEditListener because the said listener sets the BackColor to white

        Me.txtCurrentDate.Focus()



    End Sub

#End Region

#Region "Validations"

    Public Overrides Function CheckDuplicate(ByVal domain As String, ByVal ctrs() As DevExpress.XtraEditors.BaseEdit, Optional ByVal strCriteria As String = "") As Boolean
        Dim info As Boolean = False 'Return Value
        Dim ctr As DevExpress.XtraEditors.BaseEdit
        Dim str As String = ""
        For Each ctr In ctrs
            If Not TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                If TypeOf (ctr.EditValue) Is String Then
                    If Trim(ctr.EditValue) <> "" Then
                        If DB.HasDuplicate(domain, "[" & Mid(ctr.Name, 4) & "]='" & ctr.EditValue & "'" & IIf(strCriteria.Length > 0, " AND " & strCriteria, "")) Then
                            info = True
                            str = ctr.ToolTip & ": " & UCase(ctr.Text) & " is already in use." & vbCrLf
                            ctr.BackColor = INVALID_COLOR
                            MsgBox(str, MsgBoxStyle.Exclamation, GetAppName)
                            Exit For
                        Else
                            info = False
                        End If
                    End If
                End If
            End If
        Next
        Return info
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(RequiredFields, showMsg) Then
                If bAddMode Then
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData()
                Else
                    flag = True
                    ALLOWNEXTS = flag
                    SaveData()
                End If
            Else
                flag = False
                ALLOWNEXTS = flag
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Private Function isValidForCreateTravelRequest() As Boolean
        'If IfNull(txtCurrentDate.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the Travel Date.", MsgBoxStyle.Information)
        '    txtTravelDate.Focus()
        '    Return False
        'End If

        'If IfNull(cboVessel.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the Vessel.", MsgBoxStyle.Information)
        '    cboVessel.Focus()
        '    Return False
        'End If

        'If IfNull(cboPort.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the Port.", MsgBoxStyle.Information)
        '    cboPort.Focus()
        '    Return False
        'End If

        'If IfNull(txtETD.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the ETD.", MsgBoxStyle.Information)
        '    txtETD.Focus()
        '    Return False
        'End If

        'If IfNull(txtETAE.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the ETAE.", MsgBoxStyle.Information)
        '    txtETAE.Focus()
        '    Return False
        'End If

        'If IfNull(txtETAL.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the ETAL.", MsgBoxStyle.Information)
        '    txtETAL.Focus()
        '    Return False
        'End If

        'If IfNull(txtDueDate.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the Request Due Date.", MsgBoxStyle.Information)
        '    txtDueDate.Focus()
        '    Return False
        'End If

        'If IfNull(cboLeadTime.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the Request Lead Time.", MsgBoxStyle.Information)
        '    cboLeadTime.Focus()
        '    Return False
        'End If

        'If IfNull(cboNearestAirport.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the Nearest Airport.", MsgBoxStyle.Information)
        '    cboNearestAirport.Focus()
        '    Return False
        'End If

        'If IfNull(cboRequestType.EditValue, "").Equals("") Then
        '    MsgBox("Please enter the Request Type.", MsgBoxStyle.Information)
        '    cboVessel.Focus()
        '    Return False
        'End If
        Dim bSuccess As Boolean = True

        bSuccess = checkRequiredFields()

        If bSuccess Then
            If Not HasPassengers() Then
                MsgBox("There are no added passengers for this Travel Request. Please add the passengers and try again.", MsgBoxStyle.Exclamation)
                tabDetails.SelectedTabPage = LayoutControlGroup_Passenger
                bSuccess = bSuccess And False
            End If

            If HasManuallyAddedBookingDetails() Then
                MsgBox("Booking Details are already manually added to this record. Booking with GTravel is not applicable unless there are no bookings yet.", MsgBoxStyle.Exclamation)
                tabDetails.SelectedTabPage = LayoutControlGroup_BookingDetails
                bSuccess = bSuccess And False
            End If
        End If

        Return bSuccess

    End Function

    Private Function checkRequiredFields() As Boolean
        Dim bSuccess As Boolean = True
        Dim HIGHLIGH_COLOR As System.Drawing.Color = System.Drawing.Color.IndianRed

        If IfNull(txtTravelDate.EditValue, "").Equals("") Then
            txtTravelDate.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(txtRefNo.EditValue, "").Equals("") Then
            txtRefNo.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(cboVessel.EditValue, "").Equals("") Then
            cboVessel.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(cboPort.EditValue, "").Equals("") Then
            cboPort.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(txtETD.EditValue, "").Equals("") Then
            txtETD.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(txtETAE.EditValue, "").Equals("") Then
            txtETAE.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(txtETAL.EditValue, "").Equals("") Then
            txtETAL.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(txtDueDate.EditValue, "").Equals("") Then
            txtDueDate.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        '<!-- commented out by tony20181203 - not required anymore
        'If IfNull(cboLeadTime.EditValue, "").Equals("") Then
        '    cboLeadTime.BackColor = HIGHLIGH_COLOR
        '    bSuccess = bSuccess And False
        'End If
        '-->

        If IfNull(cboNearestAirport.EditValue, "").Equals("") Then
            cboNearestAirport.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If IfNull(cboRequestType.EditValue, "").Equals("") Then
            cboRequestType.BackColor = HIGHLIGH_COLOR
            bSuccess = bSuccess And False
        End If

        If Not bSuccess Then
            MsgBox("Please complete the required fields.", MsgBoxStyle.Information)
        End If
        Return bSuccess
    End Function

#End Region

#Region "Saving of Data"
    'Add
    Public Overrides Sub AddData()
        MyBase.AddData()
        bAddMode = True

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### enables the Add Passenger button
        EnableAddPassengerGroup()

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### disables the Mark as Completed button
        EnableMarkAsCompleted(False)

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### initialize controls
        RemoveReadOnlyListener(LayoutControl1.Root)
        ClearFields(LayoutControlGroups, False)
        ShowPlanningEventDetail(False)

        AllowSaving(Name, True)
        AllowAddition(Name, False)
        AllowDeletion(Name, False) 'Disable Delete button
        AllowEditing(Name, False)
        RaiseCustomEvent(Name, New Object() {"ShowCancelButton", True})

        blList.HideSelection()
        strID = ""
        strDesc = "New Record"
        Me.header.Text = strDesc
        Me.txtTravelDate.Focus()
        Me.txtTravelDate.BackColor = SEL_COLOR
        Me.txtCurrentDate.Text = System.DateTime.Now
        Me.cboLeadTime.EditValue = 0

        BRECORDUPDATEDs = False
        tabDetails.SelectedTabPage = LayoutControlGroup_Passenger

        cboBookingStatus.EditValue = DEFAULT_BOOKING_STATUS
        cboBookingStatus.ReadOnly = True
        oGTRSControl.BookedWithGTravel = False

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### show copy and deleted buttons in booking details gridview
        ShowManualBookingCtls(True)
        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### show copy button in Costs gridview
        ShowTravelCostsCtls(True)

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        AddEditListener(LayoutControlGroups)
        AddGTRSEditListener()
        RemoveEditListener(cboAddCrew, False)
        RemoveGTRSEditListener()


        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        cboAddCrew.Properties.ReadOnly = False
        EditSubAllowGrid(PassengerView, True, False)
        EditSubAllowGrid(BookingDetailsView, True)
        EditSubAllowGrid(TravelCostView, True)

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### initialize Passenger Details Grid - New Record
        LoadSub_2PassengerDetails(True)
        '### initialize Booking Details Grid - New Record
        LoadSub_3BookingDetails(True)
        '### initialize Costs Details Grid - New Record
        LoadSub_5TravelCostDetails(True)

        '### Shows Delete Passenger button
        EnableRemovePassenger()

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### shows only active vessels on vessel dropdown list
        ShowVesselData(True)

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        oGTRSControl.AddData()
        isCheckIfChangingBookingStatus = True

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '### allow adding of planning event
        AllowAddFromPlanningEvent(True)
    End Sub

    ''' <summary>
    ''' Enables or disables controls to add Planning Event
    ''' </summary>
    ''' <param name="allow"></param>
    ''' <remarks></remarks>
    Private Sub AllowAddFromPlanningEvent(allow As Boolean)
        If allow Then
            lciAddFromPlanningEvent.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            lciAddFromPlanningEvent.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

        btnAddFromPlanningEvent.Enabled = (lciAddFromPlanningEvent.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always)

        btnAddFromPlanningEvent.ForeColor = System.Drawing.Color.Green
    End Sub
#End Region

#Region "Deleting of Data"

    'Delete
    Public Overrides Sub DeleteData()
        DeleteMain()
    End Sub

    'Public Sub DeleteMain()
    '    MyBase.DeleteData()
    '    Dim info As Boolean = False
    '    If MsgBox("Are you sure, you want to delete the Travel Booking?" & vbNewLine & _
    '              vbTab & "Travel Date: " & txtTravelDate.Text & vbNewLine & _
    '              vbTab & "Vessel: " & cboVessel.Text, MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

    '        MsgBox("1")
    '        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete Travel Booking", 0, System.Environment.MachineName, "", FormName) 'neil
    '        clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy)
    '        MsgBox("2")

    '        Dim bSuccess As Boolean = False

    '        If IfNull(Me.TravelRequestID, "").Equals("") Then
    '            bSuccess = True
    '            MsgBox("3")

    '        Else
    '            MsgBox("4")

    '            If isValidGTRSID(Me.TravelRequestID) Then
    '                MsgBox("5")
    '                bSuccess = CancelTravelRequest()
    '            Else
    '                MsgBox("6")
    '                bSuccess = True
    '            End If
    '        End If
    '        MsgBox("7")
    '        If Not bSuccess Then
    '            MsgBox("Failed to sent Cancel Request to G Travel.", MsgBoxStyle.Exclamation)
    '        Else
    '            MsgBox("8")
    '            info = MPSDB.RunSql("DELETE FROM dbo.tbltravelbooking WHERE PKey = '" & strID & "'")
    '            If info Then
    '                MsgBox("9")
    '                blList.RefreshData()
    '                MsgBox("10")
    '                ClearFields(LayoutControlGroups, False)
    '                MsgBox("11")
    '                MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
    '                MsgBox("12")
    '                RefreshData()
    '                MsgBox("13")
    '                BRECORDUPDATEDs = False
    '            Else
    '                MsgBox("14")
    '                MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
    '                BRECORDUPDATEDs = False
    '            End If
    '        End If


    '    End If
    'End Sub

    Public Sub DeleteMain()
        MyBase.DeleteData()
        Dim info As Boolean = False

        Dim gtprompt As String = ""
        If oGTRSControl.BookedWithGTravel Then
            gtprompt = "This is booked to GTravel and with status " & vbNewLine & """" & cboBookingStatus.Text & """." & vbNewLine
        End If

        If MsgBox(gtprompt & "Are you sure, you want to delete the Travel Booking?" & vbNewLine & _
                  vbTab & "Travel Date: " & txtTravelDate.Text & vbNewLine & _
                  vbTab & "Vessel: " & cboVessel.Text, MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete Travel Booking", 0, System.Environment.MachineName, "", FormName) 'neil
            clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy)

            Dim bSuccess As Boolean = False

            If IfNull(Me.TravelRequestID, "").Equals("") Then
                bSuccess = True

            Else

                If isValidGTRSID(Me.TravelRequestID) Then
                    bSuccess = CancelTravelRequest(True)
                Else
                    bSuccess = True
                End If
            End If

            Application.DoEvents()
            If Not bSuccess Then
                MsgBox("Failed to send Cancel Request to G Travel.", MsgBoxStyle.Exclamation)
            Else
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tbltravelbooking", _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Crew Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                info = MPSDB.RunSql("DELETE FROM dbo.tbltravelbooking WHERE PKey = '" & strID & "'")
                isEditdable = False
                bAddMode = False
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    blList.RefreshData()
                    ClearFields(LayoutControlGroups, False)
                    MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                    RefreshData()
                    BRECORDUPDATEDs = False
                Else
                    MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                    BRECORDUPDATEDs = False
                End If
            End If


        End If
    End Sub

    Private Sub DeleteBooking()
        If TravelRequestIsBooked Then
            MsgBox("This travel request's status is already set as 'Booked'. Deleting of any booking details is not allowed." & vbNewLine & vbNewLine & "You can set this booking detail as 'Canceled' instead.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = BookingDetailsView


        If view.FocusedRowHandle >= 0 Then
            If MsgBox("You are about to delete the selected booking detail for crew " & view.GetFocusedRowCellValue("AmadeusName") & "." & vbNewLine & vbNewLine & _
                      "Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim bSuccess As Boolean = False
                If IfNull(view.GetFocusedRowCellValue("PKey"), "") <> "" Then
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tbltravelbookingdetail", _
                        "PKey IN ('" & view.GetFocusedRowCellValue("PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " - Travel Booking Detail >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Travel Booking Detail>", _
                        GetUserName())
                    '-->
                    bSuccess = MPSDB.RunSql("DELETE FROM dbo.tbltravelbookingdetail WHERE PKey = '" & view.GetFocusedRowCellValue("PKey") & "'")
                Else
                    bSuccess = True
                End If

                If bSuccess Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    view.DeleteRow(view.FocusedRowHandle)
                    LoadSub_3BookingDetails()
                End If

            End If
        End If
    End Sub

    Private Sub DeleteTravelCost()
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TravelCostView

        If view.FocusedRowHandle >= 0 Then
            If MsgBox("You are about to delete the selected travel cost detail " & view.GetFocusedRowCellDisplayText("FKeyTravelCostItem") & "." & vbNewLine & vbNewLine & _
                      "Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim bSuccess As Boolean = False

                If IfNull(view.GetFocusedRowCellValue("PKey"), "") <> "" Then
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()

                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tbltravelbookingcosts", _
                        "PKey IN ('" & view.GetFocusedRowCellValue("PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " - Travel Booking Course >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Travel Booking Course >", _
                        GetUserName())
                    '-->

                    bSuccess = MPSDB.RunSql("DELETE FROM dbo.tbltravelbookingcosts WHERE PKey = '" & view.GetFocusedRowCellValue("PKey") & "'")
                Else
                    bSuccess = True
                End If

                If bSuccess Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    view.DeleteRow(view.FocusedRowHandle)
                    LoadSub_5TravelCostDetails()
                End If

            End If
        End If
    End Sub

#End Region

#Region "Loading of Data"
    Private Sub LoadSub()

        ClearFields(LayoutControlGroups, False)

        '### Load Main Details - Travel Details
        LoadSub_1TravelDetails()

        '### Load Details of Selected Passengers
        LoadSub_2PassengerDetails()

        '### Load Booking Details 
        LoadSub_3BookingDetails()

        '### Updates passengers if has flight, this is to whether show the Plane icon (Has Flight Details)
        LoadSub_4PassengerDetails_Flight()

        '### Load Travel Cost Details
        LoadSub_5TravelCostDetails()
    End Sub

#Region "Travel Request Details"
    Private Sub LoadSub_1TravelDetails()
        Dim dt As DataTable = MPSDB.CreateTable("SELECT * FROM dbo.tbltravelbooking WHERE PKEy = '" & strID & "'")
        If dt.Rows.Count > 0 Then
            'Load Basic Details
            Dim dr As DataRow = dt.Rows(0)
            txtTravelDate.EditValue = IfNull(dr.Item("TravelDate"), "")
            cboVessel.EditValue = IfNull(dr.Item("FKeyVsl"), "")
            cboPort.EditValue = IfNull(dr.Item("FKeyPort"), "")
            txtRefNo.Text = IfNull(dr.Item("RefNo"), "")
            txtCurrentDate.Text = IfNull(dr.Item("CurrentDate"), "")
            txtETD.Text = IfNull(dr.Item("ETD"), "")
            txtETAE.Text = IfNull(dr.Item("ETAE"), "")
            txtETAL.Text = IfNull(dr.Item("ETAL"), "")
            txtDueDate.EditValue = IfNull(dr.Item("DueDate"), "")
            cboLeadTime.EditValue = IfNull(dr.Item("LeadTime"), "")
            txtETAE.EditValue = IfNull(dr.Item("ETAE"), "")
            txtETAL.EditValue = IfNull(dr.Item("ETAL"), "")
            txtETD.EditValue = IfNull(dr.Item("ETD"), "")
            cboNearestAirport.EditValue = IfNull(dr.Item("FKeyNearestAirport"), "")
            txtRemarks.Text = IfNull(dr.Item("Remarks"), "")
            cboRequestType.EditValue = IfNull(dr.Item("RequestType"), "")
            chkisSentToGTravel.Checked = (IfNull(dr.Item("isSentToGTravel"), 0) <> 0)
            Me.TravelRequestID = IfNull(dr.Item("TravelRequestID"), "")

            'Planning Event Key
            cboFKeyPlanningEvent.EditValue = IfNull(dr.Item("FKeyPlanningEvent"), "")

            If IfNull(cboFKeyPlanningEvent.EditValue, "").Length > 0 Then
                ShowPlanningEventDetail()
                If IsNothing(dtPlanningEvent) Then SetupPlanningEventLookupEdit()
            Else
                ShowPlanningEventDetail(False)

            End If

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Load BookingStatus Details
            BookingStatus.Booked = IfNull(dr.Item("BookingStatus"), "").Equals(TravelBookingStatus.Booked.Key)
            BookingStatus.Completed = IfNull(dr.Item("isCompleted"), False)


            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Check if Completed
            SetTravelCompletedButton(BookingStatus.Completed)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Set if Booked With GTravel
            oGTRSControl.BookedWithGTravel = isValidGTRSID(Me.TravelRequestID)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Load Booking Status Combo Box
            cboBookingStatus.EditValue = IfNull(dr.Item("BookingStatus"), "")

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Load GTRS Controls
            If oGTRSControl.BookedWithGTravel Then
                'Show TravelRequestID if BOOKED WITH GTRAVEL
                lciGTravelRequestID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Else
                'Hide TravelRequestID if NOT BOOKED WITH GTRAVEL
                lciGTravelRequestID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            End If

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            'Enable Create Request Button
            EnableCreateTravelRequestButton(Me.TravelRequestID)



        Else
            ClearFields(LayoutControlGroups, False)
        End If

    End Sub

    Private Function HasUnsentUpdates() As Boolean
        Dim _HasUnsentUpdates As Boolean = False

        If Not chkisSentToGTravel.Checked Then
            _HasUnsentUpdates = True
        End If

        If Not _HasUnsentUpdates Then
            For i As Integer = 0 To PassengerView.RowCount - 1
                If Not IfNull(PassengerView.GetRowCellValue(i, "isSentToGTravel"), False) Then
                    _HasUnsentUpdates = True
                    Exit For
                End If
            Next
        End If

        Return _HasUnsentUpdates
    End Function

    Private Sub EnableCreateTravelRequestButton(cTravelRequestID)
        If isValidGTRSID(cTravelRequestID) Then
            If BookingStatus.Updated And Not BookingStatus.Booked Then
                'if Travel Booking is Updated and no update transaction has been set to GTravel yet
                oGTRSControl.EnableCreateRequest()
            Else    'otherwise
                oGTRSControl.EnableCreateRequest(False)
            End If
        Else
            oGTRSControl.EnableCreateRequest(False)
        End If
    End Sub

    Private Sub LoadSub_3BookingDetails(Optional NewRecord As Boolean = False)
        If NewRecord Then
            BookingDetailsGrid.DataSource = MPSDB.CreateTable("SELECT *, cast(0 as bit) Edited, CASE WHEN isCanceled <> 0 THEN '" & BookedOrCanceled.Canceled & "' ELSE '" & BookedOrCanceled.Booked & "' END as CancelStatus FROM dbo.tblTravelBookingDetail WHERE FKeyTravelBooking = 'NEWRECORD' ORDER BY AmadeusName")
        Else
            BookingDetailsGrid.DataSource = MPSDB.CreateTable("SELECT *, cast(0 as bit) Edited, CASE WHEN isCanceled <> 0 THEN '" & BookedOrCanceled.Canceled & "' ELSE '" & BookedOrCanceled.Booked & "' END as CancelStatus FROM dbo.tblTravelBookingDetail WHERE FKeyTravelBooking = '" & strID & "' ORDER BY AmadeusName")
        End If
    End Sub

    Private Sub LoadSub_5TravelCostDetails(Optional NewRecord As Boolean = False)
        If NewRecord Then
            TravelCostGrid.DataSource = MPSDB.CreateTable("SELECT *, cast(0 as bit) Edited FROM dbo.tblTravelBookingCosts WHERE FKeyTravelBooking = 'NEWRECORD' ")
        Else
            TravelCostGrid.DataSource = MPSDB.CreateTable("SELECT *, cast(0 as bit) Edited FROM dbo.tblTravelBookingCosts WHERE FKeyTravelBooking = '" & strID & "' ")
        End If

        TravelCostView.Columns("FKeyTravelCostItem").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
    End Sub
#End Region

#Region "Passenger"
    Private Sub LoadSub_2PassengerDetails(Optional AllowDelete As Boolean = False)
        PassengerGrid.DataSource = MPSDB.CreateTable("SELECT cast(0 as bit) as Edited, dbo.assemblename(lname, fname, '', 1,1,0,0,0) as CrewName, cast(0 as bit) HasFlightDetails, * FROM dbo.tblTravelBookingCrew WHERE FKeyTravelBooking = '" & strID & "' ORDER BY lname, fname")
        EnableRemovePassenger(AllowDelete)
    End Sub

    ''' <summary>
    ''' Updates Passenger GridView, sets HasFlightDetails column to true if user hase booking details linked to 
    ''' his CrewID or PassengerID (GTravel)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSub_4PassengerDetails_Flight()
        Dim dv As New DataView(TryCast(BookingDetailsGrid.DataSource, DataTable))
        For Each row As DataRow In TryCast(PassengerGrid.DataSource, DataTable).Rows
            'ATTEMPT TO COUNT FLIGHT DETAILS BY FKEYCREW
            dv.RowFilter = "FKeyCrew = '" & IfNull(row("FKeyCrew"), "") & "'"
            row("HasFlightDetails") = (dv.Count > 0)

            If dv.Count > 0 Then GoTo NEXT_ROW

            'IF NO FLIGHT DETAILS BY FKEYCREW, ATTEMPT TO COUNT BY PassengerID
            dv.RowFilter = "PassengerID = '" & IfNull(row("PassengerID"), "") & "'"
            row("HasFlightDetails") = (dv.Count > 0)

NEXT_ROW:
        Next
    End Sub

    Public Sub DeletePassenger()
        If TravelRequestIsBooked Then
            MsgBox("Deleting a passenger is not allowed if a travel request is set as 'Booked'.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'Dim nFocusedRecord As Integer = PassengerVGrid.FocusedRecord
        'If Not IfNull(GetPassengerGridData("PKey", nFocusedRecord), "").Equals("") Then
        '    Dim CrewName As String
        '    Dim bSuccess As Boolean = False
        '    CrewName = GetPassengerGridData("CrewName", nFocusedRecord)

        '    If MsgBox("Do you want to delete " & CrewName & " from this Travel Booking information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        If Not IfNull(GetPassengerGridData("PassengerID", nFocusedRecord), "").Equals("") Then
        '            bSuccess = CancelPassenger(GetPassengerGridData("PKey", nFocusedRecord), IfNull(GetPassengerGridData("PassengerID", nFocusedRecord), ""))
        '        Else
        '            bSuccess = True
        '        End If


        '        If bSuccess Then
        '            '<!--added by tony20180922 : Log Deletion
        '            oLogDeletion.Init()
        '            oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
        '                FormName, _
        '                "Crewing", _
        '                "tblTravelBookingCrew", _
        '                "PKey IN ('" & GetPassengerGridData("PKey", nFocusedRecord) & "')", _
        '                "<< Delete Crew Data - " & FormName & " - Delete Passenger >>", _
        '                LogDeletion.DeletionType.Manual, _
        '                "Manually Deleted in <" & FormName & " - Delete Passenger>", _
        '                GetUserName())
        '            '-->
        '            bSuccess = MPSDB.RunSql("DELETE FROM dbo.tblTravelBookingCrew WHERE PKey = '" & GetPassengerGridData("PKey", nFocusedRecord) & "'")

        '            If bSuccess Then
        '                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
        '                MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)

        '                RefreshData()
        '            End If
        '        End If
        '    End If
        'Else
        '    MsgBox("No crew selected.", MsgBoxStyle.Information)
        'End If

        Dim nFocusedRow As Integer = PassengerView.FocusedRowHandle
        If Not IfNull(GetPassengerGridData("PKey", nFocusedRow), "").Equals("") Then
            Dim CrewName As String
            Dim bSuccess As Boolean = False
            CrewName = GetPassengerGridData("CrewName", nFocusedRow)

            If MsgBox("Do you want to delete " & CrewName & " from this Travel Booking information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Not IfNull(GetPassengerGridData("PassengerID", nFocusedRow), "").Equals("") Then
                    bSuccess = SendGTRSTravelRequest_3CancelPassenger(GetPassengerGridData("PKey", nFocusedRow), IfNull(GetPassengerGridData("PassengerID", nFocusedRow), ""))
                Else
                    bSuccess = True
                End If


                If bSuccess Then
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblTravelBookingCrew", _
                        "PKey IN ('" & GetPassengerGridData("PKey", nFocusedRow) & "')", _
                        "<< Delete Crew Data - " & FormName & " - Delete Passenger >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Delete Passenger>", _
                        GetUserName())
                    '-->
                    bSuccess = MPSDB.RunSql("DELETE FROM dbo.tblTravelBookingCrew WHERE PKey = '" & GetPassengerGridData("PKey", nFocusedRow) & "'")

                    If bSuccess Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)

                        RefreshData()
                    End If
                End If
            End If
        Else
            MsgBox("No crew selected.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Function RemovePassenger(nFocusedRecord As Integer) As Boolean
        Dim bSuccess As Boolean = False

        Try
            If Not IfNull(GetPassengerGridData("PassengerID", nFocusedRecord), "").Equals("") Then
                bSuccess = SendGTRSTravelRequest_3CancelPassenger(GetPassengerGridData("PKey", nFocusedRecord), IfNull(GetPassengerGridData("PassengerID", nFocusedRecord), ""))
            Else
                bSuccess = True
            End If


            If bSuccess Then
                Dim sqls As New ArrayList
                'ManualTravelBookingCrewSrc.RemoveCrew(GetPassengerGridData("FKeyCrew", nFocusedRecord))

                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblTravelBookingDetail", _
                    "FKeyTravelBooking = '" & strID & "' AND PassengerID = '" & GetPassengerGridData("PassengerID", nFocusedRecord) & "'", _
                    "<< Delete Crew Data - " & FormName & " - Travel Booking Detail >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & " - Travel Booking Detail >", _
                    GetUserName())

                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblTravelBookingCrew", _
                    "PKey IN ('" & GetPassengerGridData("PKey", nFocusedRecord) & "')", _
                    "<< Delete Crew Data - " & FormName & " - Travel Booking Crew >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & " - Travel Booking Crew >", _
                    GetUserName())
                '-->
                sqls.Add("DELETE FROM dbo.tblTravelBookingDetail WHERE FKeyTravelBooking = '" & strID & "' AND PassengerID = '" & GetPassengerGridData("PassengerID", nFocusedRecord) & "'")
                sqls.Add("DELETE FROM dbo.tblTravelBookingCrew WHERE PKey = '" & GetPassengerGridData("PKey", nFocusedRecord) & "'")
                bSuccess = MPSDB.RunSqls(sqls)

                If bSuccess Then
                    oLogDeletion.AddLogEntryToDatabase()
                End If

            Else
                MsgBox("Failed to Remove Passenger. Please try again.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            bSuccess = False
            MsgBox("Remove Passenger Fail.", MsgBoxStyle.Critical)
            LogErrors("Remove Passenger Fail. Error Message : " & ex.Message)
        End Try

        Return bSuccess
    End Function

    Private Function RemovePassengerBooking(nFocusedRowHandle As Integer) As Boolean
        Dim bSuccess As Boolean = False
        Dim cCriteria As String = ""
        Dim cCriteriaField As String = ""
        Dim cCriteriaFieldValue As String = ""

        Dim sqls As New ArrayList

        Try
            If oGTRSControl.BookedWithGTravel Then
                Dim cPassengerID As String = IfNull(PassengerView.GetRowCellValue(nFocusedRowHandle, "PassengerID"), "").ToString

                cCriteriaField = "PassengerID"
                cCriteriaFieldValue = cPassengerID

            Else    'Not Booked with GTravel
                Dim cFKeyCrew As String = IfNull(PassengerView.GetRowCellValue(nFocusedRowHandle, "FKeyCrew"), "")

                cCriteriaField = "FKeyCrew"
                cCriteriaFieldValue = cFKeyCrew
            End If

            oLogDeletion.Init() 'added by tony20180922 : Log Deletion
            If IfNull(cCriteriaFieldValue, "").Length > 0 Then
                Dim cWhereCond As String = ""
                For i As Integer = 0 To BookingDetailsView.RowCount - 1
                    If BookingDetailsView.GetRowCellValue(i, cCriteriaField).Equals(cCriteriaFieldValue) Then
                        cWhereCond = cWhereCond & IIf(IfNull(cWhereCond, "").Length > 0, ", ", "") & _
                                     "'" & BookingDetailsView.GetRowCellValue(i, "PKey") & "'"
                        If IfNull(BookingDetailsView.GetRowCellValue(i, "PKey"), "").Length > 0 Then
                            sqls.Add("DELETE FROM dbo.tblTravelBookingDetail WHERE PKey = '" & BookingDetailsView.GetRowCellValue(i, "PKey") & "'")
                        End If
                    End If
                Next

                '<!--added by tony20180922 : Log Deletion
                If IfNull(cWhereCond, "").Length > 0 Then
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblTravelBookingDetail", _
                        "PKey IN (" & cWhereCond & ")", _
                        "<< Delete Crew Data - " & FormName & " - Remove Passenger Booking >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & "-Remove Passenger Booking>", _
                        GetUserName())
                End If
                '-->
            End If

            If sqls.Count > 0 Then
                bSuccess = MPSDB.RunSqls(sqls)

                If bSuccess Then
                    oLogDeletion.AddLogEntryToDatabase()
                    LoadSub_3BookingDetails()

                End If
            Else
                bSuccess = True
            End If

            If bSuccess Then
                For i As Integer = BookingDetailsView.RowCount - 1 To 0 Step -1
                    If BookingDetailsView.GetRowCellValue(i, cCriteriaField).Equals(cCriteriaFieldValue) Then
                        BookingDetailsView.DeleteRow(i)
                    End If
                Next
            End If
        Catch ex As Exception
            bSuccess = False
            MsgBox("Remove Passenger Fail.", MsgBoxStyle.Critical)
            LogErrors("Remove Passenger Fail. Error Message : " & ex.Message)
        End Try

        Return bSuccess
    End Function

#End Region

#Region "Save Data"
    'Save
    Public Overrides Sub SaveData()
        Dim type As String = "", info As Boolean = False
        Dim sqls As New ArrayList

        header.Focus()
        If ValidateFields(RequiredFields) Then
            If Not HasPassengers() Then
                MsgBox("There are no added passengers for this Travel Request. Please add the passengers and try again.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Not isValidForSaving() Then
                Exit Sub
            End If

            If SaveData_1TravelDetails() Then

                SaveData_2Passenger(sqls)
                SaveData_3BookingDetails(sqls)
                SaveData_4TravelCosts(sqls)

                Dim bSuccess As Boolean = False
                bSuccess = MPSDB.RunTransaction(sqls)

                If bSuccess Then
                    MsgBox("Record saved.", MsgBoxStyle.Information, GetAppName())

                    If oGTRS.MyStatus = GTRSServiceStatus.Okay And IfNull(Me.TravelRequestID, "").Length = 0 Then
                        If bAddMode Then
                            If showPromptToSendToGTravel Then
                                If MsgBox("Do you want to book with GTravel?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then
                                    SendGTRSTravelRequest()
                                End If
                            End If
                            'Else
                            '    If oGTRSControl.BookedWithGTravel Then
                            '        If HasUnsentUpdates() Then
                            '            If MsgBox("Do you want to send your updates to GTravel?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then
                            '                SaveData_SendToGTravel()
                            '            End If
                            '        End If
                            '    End If

                        End If
                    End If
                    BRECORDUPDATEDs = False
                    blList.RefreshData()
                    RefreshData()
                Else
                    MsgBox("Failed to save record with error: " & MPSDB.GetLastErrorMessage, MsgBoxStyle.Critical, GetAppName)
                End If
            End If
        End If


    End Sub

    Private Function isValidForSaving() As Boolean
        If IfNull(txtETD.EditValue, "").Length = 0 Then
            MsgBox("Please enter the ETD.", MsgBoxStyle.Exclamation, GetAppName)
            txtETD.Focus()
            Return False
        ElseIf IfNull(txtETAE.EditValue, "").Length = 0 Then
            MsgBox("Please enter the ETA Earliest.", MsgBoxStyle.Exclamation, GetAppName)
            txtETD.Focus()
            Return False
        ElseIf IfNull(txtETAL.EditValue, "").Length = 0 Then
            MsgBox("Please enter the ETA Latest.", MsgBoxStyle.Exclamation, GetAppName)
            txtETD.Focus()
            Return False
        Else
            If IsDate(txtETD.EditValue) And IsDate(txtETAE.EditValue) Then
                If CDate(txtETD.EditValue) > CDate(txtETAE.EditValue) Then
                    MsgBox("ETD must be earlier than the ETA Earliest.", MsgBoxStyle.Exclamation, GetAppName)
                    txtETD.Focus()
                    Return False
                End If
            ElseIf IsDate(txtETD.EditValue) And IsDate(txtETAL.EditValue) Then
                If CDate(txtETD.EditValue) > CDate(txtETAE.EditValue) Then
                    MsgBox("ETD must be earlier than the ETA Latest.", MsgBoxStyle.Exclamation, GetAppName)
                    txtETD.Focus()
                    Return False
                End If
            End If

        End If
        Return True
    End Function

    Private Function SaveData_1TravelDetails() As Boolean
        Dim ReturnValue As Boolean = False
        Dim cSQL As String = ""
        Dim cDueDate As String = ""

        If IfNull(txtDueDate.EditValue, "").Length > 0 Then
            cDueDate = ChangeToSQLDate(txtDueDate.EditValue)
        Else
            cDueDate = "NULL"
        End If

        If bAddMode And IfNull(strID, "").Length = 0 Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Add Travel Request", 10, System.Environment.MachineName, "Vessel: " & cboVessel.Text & ";Travel Date: " & ChangeToGTRSDate(txtTravelDate.EditValue), FormName)

            If CheckDuplicate(Me.TableName, RequiredFields) Then
                Return False
            End If

            cSQL = "INSERT INTO [dbo].[tblTravelBooking] " & _
                   "        ([ClientID] " & _
                   "        ,[UserID] " & _
                   "        ,[DepartmentID] " & _
                   "        ,[FKeyVsl] " & _
                   "        ,[VslName] " & _
                   "        ,[FKeyPort] " & _
                   "        ,[PortName] " & _
                   "        ,[TravelDate] " & _
                   "        ,[RefNo] " & _
                   "        ,[CurrentDate] " & _
                   "        ,[DueDate] " & _
                   "        ,[LeadTime] " & _
                   "        ,[ETAE] " & _
                   "        ,[ETAL] " & _
                   "        ,[ETD] " & _
                   "        ,[RequestType] " & _
                   "        ,[FKeyNearestAirport] " & _
                   "        ,[NearestAirportName] " & _
                   "        ,[Remarks] " & _
                   "        ,[DateUpdated] " & _
                   "        ,[LastUpdatedBy] " & _
                   "        ,[isCompleted] " & _
                   "        ,[BookingStatus] " & _
                   "        ,[FKeyPlanningEvent] " & _
                   "        ,[isSentToGTravel]) " & _
                   "VALUES(" & ChangeToSQLString(oGTRS.ClientInfo.clientID, "NULL") & " " & _
                   "       ," & ChangeToSQLString(oGTRS.ClientInfo.userID, "NULL") & " " & _
                   "       ," & ChangeToSQLString(oGTRS.ClientInfo.departmentID, "NULL") & " " & _
                   "       ," & ChangeToSQLString(cboVessel.EditValue, "NULL") & " " & _
                   "       ," & ChangeToSQLString(cboVessel.Text, "NULL") & " " & _
                   "       ," & ChangeToSQLString(cboPort.EditValue, "NULL") & " " & _
                   "       ," & ChangeToSQLString(cboPort.Text, "NULL") & " " & _
                   "       ," & ChangeToSQLDate(txtTravelDate.EditValue) & " " & _
                   "       ," & ChangeToSQLString(txtRefNo.EditValue, "NULL") & " " & _
                   "       ," & ChangeToSQLDate(txtCurrentDate.EditValue) & " " & _
                   "       ," & cDueDate & " " & _
                   "       ," & IfNull(cboLeadTime.EditValue, 0) & " " & _
                   "       ," & ChangeToSQLDate(txtETAE.EditValue) & " " & _
                   "       ," & ChangeToSQLDate(txtETAL.EditValue) & " " & _
                   "       ," & ChangeToSQLDate(txtETD.EditValue) & " " & _
                   "       ," & ChangeToSQLString(cboRequestType.EditValue, "NULL") & " " & _
                   "       ," & ChangeToSQLString(cboNearestAirport.EditValue, "NULL") & " " & _
                   "       ," & ChangeToSQLString(cboNearestAirport.Text, "NULL") & " " & _
                   "       ," & ChangeToSQLString(txtRemarks.Text, "NULL") & " " & _
                   "       ,getdate() " & _
                   "       ,'" & LastUpdatedBy & "'" & _
                   "       ," & IIf(BookingStatus.Completed, 1, 0) & _
                   "       ,'" & TravelBookingStatus.NewRequest.Key & "' " & _
                   "       ," & ChangeToSQLString(cboFKeyPlanningEvent.EditValue, "NULL") & " " & _
                   "       , 0)"

            If DB.RunSql(cSQL, True) Then
                ReturnValue = True
                strID = DB.GetLastInsertedItem("PKey", Me.TableName)

            End If

        Else
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Edit Travel Request", 10, System.Environment.MachineName, "Vessel: " & cboVessel.Text & ";Travel Date: " & ChangeToGTRSDate(txtTravelDate.EditValue), FormName)

            If CheckDuplicate(Me.TableName, RequiredFields, "PKey<>'" & strID & "'") Then
                Return False
            End If

            Dim TravelRequestUpdated As Boolean = False
            If HasControlUpdated(LayoutControlGroups()) Then

                cSQL = "UPDATE [dbo].[tblTravelBooking] " & _
                       "SET     [FKeyVsl] = " & ChangeToSQLString(cboVessel.EditValue, "NULL") & " " & _
                       "        ,[VslName] = " & ChangeToSQLString(cboVessel.Text, "NULL") & " " & _
                       "        ,[FKeyPort] = " & ChangeToSQLString(cboPort.EditValue, "NULL") & " " & _
                       "        ,[PortName] = " & ChangeToSQLString(cboPort.Text, "NULL") & " " & _
                       "        ,[TravelDate] = " & ChangeToSQLString(txtTravelDate.EditValue, "NULL") & " " & _
                       "        ,[RefNo] = " & ChangeToSQLString(txtRefNo.Text, "NULL") & " " & _
                       "        ,[DueDate] = " & cDueDate & " " & _
                       "        ,[LeadTime] = " & IfNull(cboLeadTime.Text, 0) & " " & _
                       "        ,[ETAE] = " & ChangeToSQLDate(txtETAE.EditValue) & " " & _
                       "        ,[ETAL] = " & ChangeToSQLDate(txtETAL.EditValue) & " " & _
                       "        ,[ETD] = " & ChangeToSQLDate(txtETD.EditValue) & " " & _
                       "        ,[FKeyNearestAirport] = " & ChangeToSQLString(cboNearestAirport.EditValue, "NULL") & " " & _
                       "        ,[NearestAirportName] = " & ChangeToSQLString(cboNearestAirport.Text, "NULL") & " " & _
                       "        ,[Remarks] = " & ChangeToSQLString(txtRemarks.Text, "NULL") & " " & _
                       "        ,[DateUpdated] = getdate() " & _
                       "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
                       "        ,[isCompleted] = " & IIf(BookingStatus.Completed, 1, 0) & " " & _
                       "        ,[BookingStatus] = " & ChangeToSQLString(cboBookingStatus.EditValue, "NULL") & " " & _
                       "        ,[FKeyPlanningEvent] = " & ChangeToSQLString(cboFKeyPlanningEvent.EditValue, "NULL") & " " & _
                       "        ,[isSentToGTravel] = 0 " & _
                       "WHERE PKey = '" & strID & "'"

                ReturnValue = DB.RunSql(cSQL, True)

                TravelRequestUpdated = True
            Else
                ReturnValue = True
            End If



        End If

        Return ReturnValue
    End Function


    Public Sub SaveData_2Passenger(ByRef sqls As ArrayList)
        Dim cSQL As String

        With Me.PassengerView
            .CloseEditor()
            .UpdateCurrentRow()

            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then

                    If IfNull(.GetRowCellValue(i, "PKey"), "").Equals("") Then


                        cSQL = "INSERT INTO [dbo].[tblTravelBookingCrew] " & _
                           "        ([FKeyTravelBooking] " & _
                           "        ,[PassengerID] " & _
                           "        ,[FKeyCrew] " & _
                           "        ,[CoIDNo] " & _
                           "        ,[LName] " & _
                           "        ,[FName] " & _
                           "        ,[SexCode] " & _
                           "        ,[DOB] " & _
                           "        ,[POB] " & _
                           "        ,[FKeyNat] " & _
                           "        ,[Nationality] " & _
                           "        ,[FKeyRank] " & _
                           "        ,[RankName] " & _
                           "        ,[RankAbbrv] " & _
                           "        ,[FKeyAgent] " & _
                           "        ,[AgentName] " & _
                           "        ,[PPNo] " & _
                           "        ,[PPIssueDate] " & _
                           "        ,[PPExpiryDate] " & _
                           "        ,[PPPlaceIssue] " & _
                           "        ,[SBNo] " & _
                           "        ,[SBIssueDate] " & _
                           "        ,[SBExpiryDate] " & _
                           "        ,[SBPlaceIssue] " & _
                           "        ,[Celphone] " & _
                           "        ,[Phone] " & _
                           "        ,[Email] " & _
                           "        ,[FKeyNearestAirport] " & _
                           "        ,[NearestAirportName] " & _
                           "        ,[FKeyAlternativeAirport] " & _
                           "        ,[AlternativeAirportName] " & _
                           "        ,[ETAE] " & _
                           "        ,[ETAL] " & _
                           "        ,[ETD] " & _
                           "        ,[FrequentFlyerMembership] " & _
                           "        ,[FrequentFlyerNumber] " & _
                           "        ,[Visa] " & _
                           "        ,[RequestType] " & _
                           "        ,[LastUpdatedBy] " & _
                           "        ,[DateCreated] " & _
                           "        ,[isSentToGTravel]) " & _
                           "VALUES( '" & strID & "' " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("PassengerID", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FKeyCrew", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("CoIDNo", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("LName", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FName", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("SexCode", i), "NULL") & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("DOB", i)) & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("POB", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FKeyNat", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("Nationality", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FKeyRank", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("RankName", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("RankAbbrv", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FKeyAgent", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("AgentName", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("PPNo", i), "NULL") & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("PPIssueDate", i)) & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("PPExpiryDate", i)) & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("PPPlaceIssue", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("SBNo", i), "NULL") & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("SBIssueDate", i)) & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("SBExpiryDate", i)) & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("SBPlaceIssue", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("Celphone", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("Phone", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("Email", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FKeyNearestAirport", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("NearestAirportName", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FKeyAlternateAirport", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("AlternateAirportName", i), "NULL") & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("ETAE", i)) & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("ETAL", i)) & " " & _
                           "        ," & ChangeToSQLDate(GetPassengerGridData("ETD", i)) & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FrequentFlyerMembership", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("FrequentFlyerNumber", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("Visa", i), "NULL") & " " & _
                           "        ," & ChangeToSQLString(GetPassengerGridData("RequestType", i), "NULL") & " " & _
                           "        ,'" & LastUpdatedBy & "' " & _
                           "        ,getdate() " & _
                           "        ,0)"

                        sqls.Add(cSQL)

                    Else

                        cSQL = "UPDATE  [dbo].[tblTravelBookingCrew] " & _
                               "SET     [PassengerID] = " & ChangeToSQLString(GetPassengerGridData("PassengerID", i), "NULL") & " " & _
                               "        ,[CoIDNo] = " & ChangeToSQLString(GetPassengerGridData("CoIDNo", i), "NULL") & " " & _
                               "        ,[LName] = " & ChangeToSQLString(GetPassengerGridData("LName", i), "NULL") & " " & _
                               "        ,[FName] = " & ChangeToSQLString(GetPassengerGridData("FName", i), "NULL") & " " & _
                               "        ,[SexCode] = " & ChangeToSQLString(GetPassengerGridData("SexCode", i), "NULL") & " " & _
                               "        ,[DOB] = " & ChangeToSQLDate(GetPassengerGridData("DOB", i)) & " " & _
                               "        ,[POB] = " & ChangeToSQLString(GetPassengerGridData("POB", i), "NULL") & " " & _
                               "        ,[FKeyNat] = " & ChangeToSQLString(GetPassengerGridData("FKeyNat", i), "NULL") & " " & _
                               "        ,[Nationality] = " & ChangeToSQLString(GetPassengerGridData("Nationality", i), "NULL") & " " & _
                               "        ,[FKeyRank] = " & ChangeToSQLString(GetPassengerGridData("FKeyRank", i), "NULL") & " " & _
                               "        ,[RankName] = " & ChangeToSQLString(GetPassengerGridData("RankName", i), "NULL") & " " & _
                               "        ,[RankAbbrv] = " & ChangeToSQLString(GetPassengerGridData("RankAbbrv", i), "NULL") & " " & _
                               "        ,[FKeyAgent] = " & ChangeToSQLString(GetPassengerGridData("FKeyAgent", i), "NULL") & " " & _
                               "        ,[AgentName] = " & ChangeToSQLString(GetPassengerGridData("AgentName", i), "NULL") & " " & _
                               "        ,[PPNo] = " & ChangeToSQLString(GetPassengerGridData("PPNo", i), "NULL") & " " & _
                               "        ,[PPIssueDate] = " & ChangeToSQLDate(GetPassengerGridData("PPIssueDate", i)) & " " & _
                               "        ,[PPExpiryDate] = " & ChangeToSQLDate(GetPassengerGridData("PPExpiryDate", i)) & " " & _
                               "        ,[PPPlaceIssue] = " & ChangeToSQLString(GetPassengerGridData("PPPlaceIssue", i), "NULL") & " " & _
                               "        ,[SBNo] = " & ChangeToSQLString(GetPassengerGridData("SBNo", i), "NULL") & " " & _
                               "        ,[SBIssueDate] = " & ChangeToSQLString(GetPassengerGridData("SBIssueDate", i), "NULL") & " " & _
                               "        ,[SBExpiryDate] = " & ChangeToSQLString(GetPassengerGridData("SBExpiryDate", i), "NULL") & " " & _
                               "        ,[SBPlaceIssue] = " & ChangeToSQLString(GetPassengerGridData("SBPlaceIssue", i), "NULL") & " " & _
                               "        ,[Celphone] = " & ChangeToSQLString(GetPassengerGridData("Celphone", i), "NULL") & " " & _
                               "        ,[Phone] = " & ChangeToSQLString(GetPassengerGridData("Phone", i), "NULL") & " " & _
                               "        ,[Email] = " & ChangeToSQLString(GetPassengerGridData("Email", i), "NULL") & " " & _
                               "        ,[FKeyNearestAirport] = " & ChangeToSQLString(GetPassengerGridData("FKeyNearestAirport", i), "NULL") & " " & _
                               "        ,[NearestAirportName] = " & ChangeToSQLString(GetPassengerGridData("NearestAirportName", i), "NULL") & " " & _
                               "        ,[FKeyAlternativeAirport] = " & ChangeToSQLString(GetPassengerGridData("FKeyAlternativeAirport", i), "NULL") & " " & _
                               "        ,[AlternativeAirportName] = " & ChangeToSQLString(GetPassengerGridData("AlternativeAirportName", i), "NULL") & " " & _
                               "        ,[ETAE] = " & ChangeToSQLDate(GetPassengerGridData("ETAE", i)) & " " & _
                               "        ,[ETAL] = " & ChangeToSQLDate(GetPassengerGridData("ETAL", i)) & " " & _
                               "        ,[ETD] = " & ChangeToSQLDate(GetPassengerGridData("ETD", i)) & " " & _
                               "        ,[FrequentFlyerMembership] = " & ChangeToSQLString(GetPassengerGridData("FrequentFlyerMembership", i), "NULL") & " " & _
                               "        ,[FrequentFlyerNumber] = " & ChangeToSQLString(GetPassengerGridData("FrequentFlyerNumber", i), "NULL") & " " & _
                               "        ,[Visa] = " & ChangeToSQLString(GetPassengerGridData("Visa", i), "NULL") & " " & _
                               "        ,[RequestType] = " & ChangeToSQLString(GetPassengerGridData("RequestType", i), "NULL") & " " & _
                               "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
                               "        ,[DateUpdated] = getdate() " & _
                               "        ,isSentToGTravel = 0 " & _
                               "WHERE   PKey = '" & GetPassengerGridData("PKey", i) & "'"

                        sqls.Add(cSQL)

                    End If

                End If

            Next

        End With
    End Sub

    Public Function SaveManualBookingDetails() As Boolean
        Dim ReturnValue As Boolean = False
        Dim sqls As New ArrayList
        Dim cSQL As String = ""

        For i As Integer = 0 To BookingDetailsView.RowCount - 1
            If BookingDetailsView.GetRowCellValue(i, "Edited") Then
                If IfNull(BookingDetailsView.GetRowCellValue(i, "PKey"), "").Equals("") Then
                    'cSQL = "INSERT INTO [dbo].[tblTravelBookingDetail] " & _
                    '                       "            ([FKeyTravelBooking] " & _
                    '                       "            ,[PassengerID] " & _
                    '                       "            ,[ItemType] " & _
                    '                       "            ,[FKeyCrew] " & _
                    '                       "            ,[AmadeusName] " & _
                    '                       "            ,[FlightNumber] " & _
                    '                       "            ,[ClassOfService] " & _
                    '                       "            ,[Origin] " & _
                    '                       "            ,[OriginDesc] " & _
                    '                       "            ,[DepartureTime] " & _
                    '                       "            ,[Destination] " & _
                    '                       "            ,[DestinationDesc] " & _
                    '                       "            ,[ArrivalTime] " & _
                    '                       "            ,[Company] " & _
                    '                       "            ,[FreeTxt] " & _
                    '                       "            ,[Status] " & _
                    '                       "            ,[Reference] " & _
                    '                       "            ,[Cost] " & _
                    '                       "            ,[Currency] " & _
                    '                       "            ,[CostRatingDivision] " & _
                    '                       "            ,[CostRating] " & _
                    '                       "            ,[DateUpdated] " & _
                    '                       "            ,[LastUpdatedBy]) " & _
                    '                       "VALUES " & _
                    '                       "            ('" & strID & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "PassengerID"), "") & "' " & _
                    '                       "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "ItemType"), 0) & " " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "FKeyCrew"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "AmadeusName"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "FlightNumber"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "ClassOfService"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "Origin"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "OriginDesc"), "") & "' " & _
                    '                       "            ," & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "DepartureTime")) & " " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "Destination"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "DestinationDesc"), "") & "' " & _
                    '                       "            ," & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "ArrivalTime")) & " " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "Company"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "FreeTxt"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "Status"), "") & "' " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "Reference"), "") & "' " & _
                    '                       "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "Cost"), 0) & " " & _
                    '                       "            ,'" & IfNull(BookingDetailsView.GetRowCellValue(i, "Currency"), "") & "' " & _
                    '                       "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRatingDivision"), 0) & " " & _
                    '                       "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRating"), 0) & " " & _
                    '                       "            ,getdate() " & _
                    '                       "            ,'" & LastUpdatedBy & "')"

                    cSQL = "INSERT INTO [dbo].[tblTravelBookingDetail] " & _
                                           "            ([FKeyTravelBooking] " & _
                                           "            ,[PassengerID] " & _
                                           "            ,[ItemType] " & _
                                           "            ,[FKeyCrew] " & _
                                           "            ,[AmadeusName] " & _
                                           "            ,[FlightNumber] " & _
                                           "            ,[ClassOfService] " & _
                                           "            ,[Origin] " & _
                                           "            ,[OriginDesc] " & _
                                           "            ,[DepartureTime] " & _
                                           "            ,[Destination] " & _
                                           "            ,[DestinationDesc] " & _
                                           "            ,[ArrivalTime] " & _
                                           "            ,[Company] " & _
                                           "            ,[FreeTxt] " & _
                                           "            ,[Status] " & _
                                           "            ,[Reference] " & _
                                           "            ,[Cost] " & _
                                           "            ,[Currency] " & _
                                           "            ,[CostRatingDivision] " & _
                                           "            ,[CostRating] " & _
                                           "            ,[DateUpdated] " & _
                                           "            ,[LastUpdatedBy] " & _
                                           "            ,[isCanceled]) " & _
                                           "VALUES " & _
                                           "            ('" & strID & "' " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "PassengerID"), "NULL") & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "ItemType"), 0) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FKeyCrew"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "AmadeusName"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FlightNumber"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "ClassOfService"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Origin"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "OriginDesc"), "NULL") & " " & _
                                           "            ," & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "DepartureTime")) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Destination"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "DestinationDesc"), "NULL") & " " & _
                                           "            ," & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "ArrivalTime")) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Company"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FreeTxt"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Status"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Reference"), "NULL") & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "Cost"), 0) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Currency"), "NULL") & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRatingDivision"), 0) & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRating"), 0) & " " & _
                                           "            ,getdate() " & _
                                           "            ,'" & LastUpdatedBy & "' " & _
                                           "            ," & IIf(IfNull(BookingDetailsView.GetRowCellValue(i, "CancelStatus"), "").Equals(BookedOrCanceled.Canceled), 1, 0) & ")"
                    sqls.Add(cSQL)

                Else
                    'cSQL = "UPDATE  [dbo].[tblTravelBookingDetail] " & _
                    '       "SET     [PassengerID] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "PassengerID"), "") & "' " & _
                    '       "        ,[ItemType] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "ItemType"), 0) & " " & _
                    '       "        ,[FKeyCrew] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "FKeyCrew"), "") & "' " & _
                    '       "        ,[AmadeusName] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "AmadeusName"), "") & "' " & _
                    '       "        ,[FlightNumber] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "FlightNumber"), "") & "' " & _
                    '       "        ,[ClassOfService] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "ClassOfService"), "") & "' " & _
                    '       "        ,[Origin] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "Origin"), "") & "' " & _
                    '       "        ,[OriginDesc] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "OriginDesc"), "") & "' " & _
                    '       "        ,[DepartureTime] = " & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "DepartureTime")) & " " & _
                    '       "        ,[Destination] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "Destination"), "") & "' " & _
                    '       "        ,[DestinationDesc] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "DestinationDesc"), "") & "' " & _
                    '       "        ,[ArrivalTime] = " & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "ArrivalTime")) & " " & _
                    '       "        ,[Company] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "Company"), "") & "' " & _
                    '       "        ,[FreeTxt] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "FreeTxt"), "") & "' " & _
                    '       "        ,[Status] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "Status"), "") & "' " & _
                    '       "        ,[Reference] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "Reference"), "") & "' " & _
                    '       "        ,[Cost] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "Cost"), 0) & " " & _
                    '       "        ,[Currency] = '" & IfNull(BookingDetailsView.GetRowCellValue(i, "Currency"), "") & "' " & _
                    '       "        ,[CostRatingDivision] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRatingDivision"), 0) & " " & _
                    '       "        ,[CostRating] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRating"), 0) & " " & _
                    '       "        ,[DateUpdated] = getdate() " & _
                    '       "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
                    '       "WHERE   PKey = '" & BookingDetailsView.GetRowCellValue(i, "PKey") & "'"

                    cSQL = "UPDATE  [dbo].[tblTravelBookingDetail] " & _
                           "SET     [PassengerID] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "PassengerID"), "NULL") & " " & _
                           "        ,[ItemType] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "ItemType"), 0) & " " & _
                           "        ,[FKeyCrew] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FKeyCrew"), "NULL") & " " & _
                           "        ,[AmadeusName] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "AmadeusName"), "NULL") & " " & _
                           "        ,[FlightNumber] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FlightNumber"), "NULL") & " " & _
                           "        ,[ClassOfService] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "ClassOfService"), "NULL") & " " & _
                           "        ,[Origin] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Origin"), "NULL") & " " & _
                           "        ,[OriginDesc] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "OriginDesc"), "NULL") & " " & _
                           "        ,[DepartureTime] = " & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "DepartureTime")) & " " & _
                           "        ,[Destination] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Destination"), "NULL") & " " & _
                           "        ,[DestinationDesc] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "DestinationDesc"), "NULL") & " " & _
                           "        ,[ArrivalTime] = " & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "ArrivalTime")) & " " & _
                           "        ,[Company] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Company"), "NULL") & " " & _
                           "        ,[FreeTxt] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FreeTxt"), "NULL") & " " & _
                           "        ,[Status] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Status"), "NULL") & " " & _
                           "        ,[Reference] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Reference"), "NULL") & " " & _
                           "        ,[Cost] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "Cost"), 0) & " " & _
                           "        ,[Currency] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Currency"), "NULL") & " " & _
                           "        ,[CostRatingDivision] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRatingDivision"), 0) & " " & _
                           "        ,[CostRating] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRating"), 0) & " " & _
                           "        ,[DateUpdated] = getdate() " & _
                           "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
                           "        ,[isCanceled] = " & IIf(IfNull(BookingDetailsView.GetRowCellValue(i, "CancelStatus"), "").Equals(BookedOrCanceled.Canceled), 1, 0) & " " & _
                           "WHERE   PKey = '" & BookingDetailsView.GetRowCellValue(i, "PKey") & "'"
                    sqls.Add(cSQL)

                End If

            End If
        Next

        If sqls.Count > 0 Then
            Return MPSDB.RunSqls(sqls)
        Else
            Return True
        End If

    End Function

    Public Sub SaveData_3BookingDetails(ByRef sqls As ArrayList)
        Dim cSQL As String = ""

        If isValidGTRSID(Me.TravelRequestID) Then
            Exit Sub
        End If

        For i As Integer = 0 To BookingDetailsView.RowCount - 1
            If BookingDetailsView.GetRowCellValue(i, "Edited") Then
                If IfNull(BookingDetailsView.GetRowCellValue(i, "PKey"), "").Equals("") Then
                    cSQL = "INSERT INTO [dbo].[tblTravelBookingDetail] " & _
                                           "            ([FKeyTravelBooking] " & _
                                           "            ,[PassengerID] " & _
                                           "            ,[ItemType] " & _
                                           "            ,[FKeyCrew] " & _
                                           "            ,[AmadeusName] " & _
                                           "            ,[FlightNumber] " & _
                                           "            ,[ClassOfService] " & _
                                           "            ,[Origin] " & _
                                           "            ,[OriginDesc] " & _
                                           "            ,[DepartureTime] " & _
                                           "            ,[Destination] " & _
                                           "            ,[DestinationDesc] " & _
                                           "            ,[ArrivalTime] " & _
                                           "            ,[Company] " & _
                                           "            ,[FreeTxt] " & _
                                           "            ,[Status] " & _
                                           "            ,[Reference] " & _
                                           "            ,[Cost] " & _
                                           "            ,[Currency] " & _
                                           "            ,[CostRatingDivision] " & _
                                           "            ,[CostRating] " & _
                                           "            ,[DateUpdated] " & _
                                           "            ,[LastUpdatedBy] " & _
                                           "            ,[isCanceled] " & _
                                           "            ,[isFromGTravel]) " & _
                                           "VALUES " & _
                                           "            ('" & strID & "' " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "PassengerID"), "NULL") & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "ItemType"), 0) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FKeyCrew"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "AmadeusName"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FlightNumber"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "ClassOfService"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Origin"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "OriginDesc"), "NULL") & " " & _
                                           "            ," & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "DepartureTime")) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Destination"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "DestinationDesc"), "NULL") & " " & _
                                           "            ," & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "ArrivalTime")) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Company"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FreeTxt"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Status"), "NULL") & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Reference"), "NULL") & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "Cost"), 0) & " " & _
                                           "            ," & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Currency"), "NULL") & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRatingDivision"), 0) & " " & _
                                           "            ," & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRating"), 0) & " " & _
                                           "            ,getdate() " & _
                                           "            ,'" & LastUpdatedBy & "' " & _
                                           "            ," & IIf(IfNull(BookingDetailsView.GetRowCellValue(i, "CancelStatus"), "").Equals(BookedOrCanceled.Canceled), 1, 0) & " " & _
                                           "            ,0)"
                    sqls.Add(cSQL)

                Else

                    cSQL = "UPDATE  [dbo].[tblTravelBookingDetail] " & _
                           "SET     [PassengerID] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "PassengerID"), "NULL") & " " & _
                           "        ,[ItemType] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "ItemType"), 0) & " " & _
                           "        ,[FKeyCrew] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FKeyCrew"), "NULL") & " " & _
                           "        ,[AmadeusName] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "AmadeusName"), "NULL") & " " & _
                           "        ,[FlightNumber] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FlightNumber"), "NULL") & " " & _
                           "        ,[ClassOfService] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "ClassOfService"), "NULL") & " " & _
                           "        ,[Origin] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Origin"), "NULL") & " " & _
                           "        ,[OriginDesc] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "OriginDesc"), "NULL") & " " & _
                           "        ,[DepartureTime] = " & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "DepartureTime")) & " " & _
                           "        ,[Destination] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Destination"), "NULL") & " " & _
                           "        ,[DestinationDesc] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "DestinationDesc"), "NULL") & " " & _
                           "        ,[ArrivalTime] = " & ChangeToSQLDate(BookingDetailsView.GetRowCellValue(i, "ArrivalTime")) & " " & _
                           "        ,[Company] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Company"), "NULL") & " " & _
                           "        ,[FreeTxt] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "FreeTxt"), "NULL") & " " & _
                           "        ,[Status] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Status"), "NULL") & " " & _
                           "        ,[Reference] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Reference"), "NULL") & " " & _
                           "        ,[Cost] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "Cost"), 0) & " " & _
                           "        ,[Currency] = " & ChangeToSQLString(BookingDetailsView.GetRowCellValue(i, "Currency"), "NULL") & " " & _
                           "        ,[CostRatingDivision] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRatingDivision"), 0) & " " & _
                           "        ,[CostRating] = " & IfNull(BookingDetailsView.GetRowCellValue(i, "CostRating"), 0) & " " & _
                           "        ,[DateUpdated] = getdate() " & _
                           "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
                           "        ,[isCanceled] = " & IIf(IfNull(BookingDetailsView.GetRowCellValue(i, "CancelStatus"), "").Equals(BookedOrCanceled.Canceled), 1, 0) & " " & _
                           "WHERE   PKey = '" & BookingDetailsView.GetRowCellValue(i, "PKey") & "'"
                    sqls.Add(cSQL)

                End If

            End If
        Next
    End Sub

    'Public Function SaveTravelCostDetails() As Boolean
    '    Dim ReturnValue As Boolean = False
    '    Dim sqls As New ArrayList
    '    Dim cSQL As String = ""

    '    For i As Integer = 0 To TravelCostView.RowCount - 1
    '        If TravelCostView.GetRowCellValue(i, "Edited") Then
    '            If IfNull(TravelCostView.GetRowCellValue(i, "PKey"), "").Equals("") Then
    '                'cSQL = "INSERT INTO [dbo].[tblTravelBookingCosts] " & _
    '                '       "           ([FKeyTravelBooking] " & _
    '                '       "           ,[InvoiceNo] " & _
    '                '       "           ,[InvoiceDate] " & _
    '                '       "           ,[FKeyTravelCostItem] " & _
    '                '       "           ,[Details] " & _
    '                '       "           ,[BookingRefNo] " & _
    '                '       "           ,[FKeyCurr] " & _
    '                '       "           ,[Amount] " & _
    '                '       "           ,[ExRateToUSD] " & _
    '                '       "           ,[ConvertedAmount] " & _
    '                '       "           ,[TravelAgentRefNo] " & _
    '                '       "           ,[TravelAgentRefDate] " & _
    '                '       "           ,[LastUpdatedBy] " & _
    '                '       "           ,[DateCreated] " & _
    '                '       "           ,[DateUpdated]) " & _
    '                '       "VALUES " & _
    '                '       "           ('" & strID & "' " & _
    '                '       "           ,'" & IfNull(TravelCostView.GetRowCellValue(i, "InvoiceNo"), "") & "' " & _
    '                '       "           ," & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "InvoiceDate")) & " " & _
    '                '       "           ,'" & IfNull(TravelCostView.GetRowCellValue(i, "FKeyTravelCostItem"), "") & "' " & _
    '                '       "           ,'" & IfNull(TravelCostView.GetRowCellValue(i, "Details"), "") & "' " & _
    '                '       "           ,'" & IfNull(TravelCostView.GetRowCellValue(i, "BookingRefNo"), "") & "' " & _
    '                '       "           ,'" & IfNull(TravelCostView.GetRowCellValue(i, "FKeyCurr"), "") & "' " & _
    '                '       "           ," & IfNull(TravelCostView.GetRowCellValue(i, "Amount"), 0) & " " & _
    '                '       "           ," & IfNull(TravelCostView.GetRowCellValue(i, "ExRateToUSD"), 0) & " " & _
    '                '       "           ," & IfNull(TravelCostView.GetRowCellValue(i, "ConvertedAmount"), 0) & " " & _
    '                '       "           ,'" & IfNull(TravelCostView.GetRowCellValue(i, "TravelAgentRefNo"), "") & "' " & _
    '                '       "           ," & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "TravelAgentRefDate")) & " " & _
    '                '       "           ,'" & LastUpdatedBy & "' " & _
    '                '       "           ,getdate() " & _
    '                '       "           ,getdate())"

    '                cSQL = "INSERT INTO [dbo].[tblTravelBookingCosts] " & _
    '                       "           ([FKeyTravelBooking] " & _
    '                       "           ,[InvoiceNo] " & _
    '                       "           ,[InvoiceDate] " & _
    '                       "           ,[FKeyTravelCostItem] " & _
    '                       "           ,[Details] " & _
    '                       "           ,[BookingRefNo] " & _
    '                       "           ,[FKeyCurr] " & _
    '                       "           ,[Amount] " & _
    '                       "           ,[ExRateToUSD] " & _
    '                       "           ,[ConvertedAmount] " & _
    '                       "           ,[TravelAgentRefNo] " & _
    '                       "           ,[TravelAgentRefDate] " & _
    '                       "           ,[LastUpdatedBy] " & _
    '                       "           ,[DateCreated] " & _
    '                       "           ,[DateUpdated]) " & _
    '                       "VALUES " & _
    '                       "           ('" & strID & "' " & _
    '                       "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "InvoiceNo"), "NULL") & " " & _
    '                       "           ," & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "InvoiceDate")) & " " & _
    '                       "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyTravelCostItem"), "NULL") & " " & _
    '                       "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "Details"), "NULL") & " " & _
    '                       "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "BookingRefNo"), "NULL") & " " & _
    '                       "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyCurr"), "NULL") & " " & _
    '                       "           ," & IfNull(TravelCostView.GetRowCellValue(i, "Amount"), 0) & " " & _
    '                       "           ," & IfNull(TravelCostView.GetRowCellValue(i, "ExRateToUSD"), 0) & " " & _
    '                       "           ," & IfNull(TravelCostView.GetRowCellValue(i, "ConvertedAmount"), 0) & " " & _
    '                       "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "TravelAgentRefNo"), "NULL") & " " & _
    '                       "           ," & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "TravelAgentRefDate")) & " " & _
    '                       "           ,'" & LastUpdatedBy & "' " & _
    '                       "           ,getdate() " & _
    '                       "           ,getdate())"

    '                sqls.Add(cSQL)

    '            Else
    '                'cSQL = "UPDATE [dbo].[tblTravelBookingCosts] " & _
    '                '       "SET     [InvoiceNo] = '" & IfNull(TravelCostView.GetRowCellValue(i, "InvoiceNo"), "") & "' " & _
    '                '       "        ,[InvoiceDate] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "InvoiceDate")) & " " & _
    '                '       "        ,[FKeyTravelCostItem] = '" & IfNull(TravelCostView.GetRowCellValue(i, "[FKeyTravelCostItem]"), "") & "' " & _
    '                '       "        ,[Details] = '" & IfNull(TravelCostView.GetRowCellValue(i, "Details"), "") & "' " & _
    '                '       "        ,[BookingRefNo] = '" & IfNull(TravelCostView.GetRowCellValue(i, "BookingRefNo"), "") & "' " & _
    '                '       "        ,[FKeyCurr] = '" & IfNull(TravelCostView.GetRowCellValue(i, "FKeyCurr"), "") & "' " & _
    '                '       "        ,[Amount] = " & IfNull(TravelCostView.GetRowCellValue(i, "Amount"), 0) & " " & _
    '                '       "        ,[ExRateToUSD] = " & IfNull(TravelCostView.GetRowCellValue(i, "ExRateToUSD"), 0) & " " & _
    '                '       "        ,[ConvertedAmount] = " & IfNull(TravelCostView.GetRowCellValue(i, "ConvertedAmount"), 0) & " " & _
    '                '       "        ,[TravelAgentRefNo] = '" & IfNull(TravelCostView.GetRowCellValue(i, "TravelAgentRefNo"), "") & "' " & _
    '                '       "        ,[TravelAgentRefDate] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "TravelAgentRefDate")) & " " & _
    '                '       "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
    '                '       "        ,[DateUpdated] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "DateUpdated")) & " " & _
    '                '       "WHERE   PKey = '" & TravelCostView.GetRowCellValue(i, "PKey") & "'"

    '                cSQL = "UPDATE [dbo].[tblTravelBookingCosts] " & _
    '                       "SET     [InvoiceNo] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "InvoiceNo"), "NULL") & " " & _
    '                       "        ,[InvoiceDate] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "InvoiceDate")) & " " & _
    '                       "        ,[FKeyTravelCostItem] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyTravelCostItem"), "NULL") & " " & _
    '                       "        ,[Details] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "Details"), "NULL") & " " & _
    '                       "        ,[BookingRefNo] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "BookingRefNo"), "NULL") & " " & _
    '                       "        ,[FKeyCurr] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyCurr"), "NULL") & " " & _
    '                       "        ,[Amount] = " & IfNull(TravelCostView.GetRowCellValue(i, "Amount"), 0) & " " & _
    '                       "        ,[ExRateToUSD] = " & IfNull(TravelCostView.GetRowCellValue(i, "ExRateToUSD"), 0) & " " & _
    '                       "        ,[ConvertedAmount] = " & IfNull(TravelCostView.GetRowCellValue(i, "ConvertedAmount"), 0) & " " & _
    '                       "        ,[TravelAgentRefNo] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "TravelAgentRefNo"), "NULL") & " " & _
    '                       "        ,[TravelAgentRefDate] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "TravelAgentRefDate")) & " " & _
    '                       "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
    '                       "        ,[DateUpdated] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "DateUpdated")) & " " & _
    '                       "WHERE   PKey = '" & TravelCostView.GetRowCellValue(i, "PKey") & "'"

    '                sqls.Add(cSQL)

    '            End If

    '        End If
    '    Next

    '    If sqls.Count > 0 Then
    '        Return MPSDB.RunSqls(sqls)
    '    Else
    '        Return True
    '    End If

    'End Function

    Public Sub SaveData_4TravelCosts(ByRef sqls As ArrayList)
        Dim ReturnValue As Boolean = False
        Dim cSQL As String = ""

        For i As Integer = 0 To TravelCostView.RowCount - 1
            If TravelCostView.GetRowCellValue(i, "Edited") Then
                If IfNull(TravelCostView.GetRowCellValue(i, "PKey"), "").Equals("") Then
                    cSQL = "INSERT INTO [dbo].[tblTravelBookingCosts] " & _
                           "           ([FKeyTravelBooking] " & _
                           "           ,[InvoiceNo] " & _
                           "           ,[InvoiceDate] " & _
                           "           ,[FKeyTravelCostItem] " & _
                           "           ,[Details] " & _
                           "           ,[BookingRefNo] " & _
                           "           ,[FKeyCurr] " & _
                           "           ,[Amount] " & _
                           "           ,[ExRateToUSD] " & _
                           "           ,[ConvertedAmount] " & _
                           "           ,[TravelAgentRefNo] " & _
                           "           ,[TravelAgentRefDate] " & _
                           "           ,[LastUpdatedBy] " & _
                           "           ,[DateCreated] " & _
                           "           ,[DateUpdated]) " & _
                           "VALUES " & _
                           "           ('" & strID & "' " & _
                           "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "InvoiceNo"), "NULL") & " " & _
                           "           ," & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "InvoiceDate")) & " " & _
                           "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyTravelCostItem"), "NULL") & " " & _
                           "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "Details"), "NULL") & " " & _
                           "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "BookingRefNo"), "NULL") & " " & _
                           "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyCurr"), "NULL") & " " & _
                           "           ," & IfNull(TravelCostView.GetRowCellValue(i, "Amount"), 0) & " " & _
                           "           ," & IfNull(TravelCostView.GetRowCellValue(i, "ExRateToUSD"), 0) & " " & _
                           "           ," & IfNull(TravelCostView.GetRowCellValue(i, "ConvertedAmount"), 0) & " " & _
                           "           ," & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "TravelAgentRefNo"), "NULL") & " " & _
                           "           ," & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "TravelAgentRefDate")) & " " & _
                           "           ,'" & LastUpdatedBy & "' " & _
                           "           ,getdate() " & _
                           "           ,getdate())"

                    sqls.Add(cSQL)

                Else
                    cSQL = "UPDATE [dbo].[tblTravelBookingCosts] " & _
                           "SET     [InvoiceNo] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "InvoiceNo"), "NULL") & " " & _
                           "        ,[InvoiceDate] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "InvoiceDate")) & " " & _
                           "        ,[FKeyTravelCostItem] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyTravelCostItem"), "NULL") & " " & _
                           "        ,[Details] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "Details"), "NULL") & " " & _
                           "        ,[BookingRefNo] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "BookingRefNo"), "NULL") & " " & _
                           "        ,[FKeyCurr] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "FKeyCurr"), "NULL") & " " & _
                           "        ,[Amount] = " & IfNull(TravelCostView.GetRowCellValue(i, "Amount"), 0) & " " & _
                           "        ,[ExRateToUSD] = " & IfNull(TravelCostView.GetRowCellValue(i, "ExRateToUSD"), 0) & " " & _
                           "        ,[ConvertedAmount] = " & IfNull(TravelCostView.GetRowCellValue(i, "ConvertedAmount"), 0) & " " & _
                           "        ,[TravelAgentRefNo] = " & ChangeToSQLString(TravelCostView.GetRowCellValue(i, "TravelAgentRefNo"), "NULL") & " " & _
                           "        ,[TravelAgentRefDate] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "TravelAgentRefDate")) & " " & _
                           "        ,[LastUpdatedBy] = '" & LastUpdatedBy & "' " & _
                           "        ,[DateUpdated] = " & ChangeToSQLDate(TravelCostView.GetRowCellValue(i, "DateUpdated")) & " " & _
                           "WHERE   PKey = '" & TravelCostView.GetRowCellValue(i, "PKey") & "'"

                    sqls.Add(cSQL)

                End If

            End If
        Next
    End Sub

#End Region

#Region "GTRS - Travel Request Procedures"


    Private Function SaveData_SendToGTravel(Optional SendWithoutPrompt As Boolean = False) As Boolean
        Dim ReturnValue As Boolean = False
        Dim bSuccess As Boolean = False
        Try
            bSuccess = (oGTRS.MyStatus = GTRSServiceStatus.Okay)
        Catch ex As Exception
            bSuccess = False
        End Try

        '************************************************************************************************
        '### EXIT IF GTRS IS NOT ENABLED, NOT INITLIZED OR IF USER IS NOT SUCCESSFULLY AUTHENTICATED
        If Not bSuccess Then
            Return False
        End If

        '************************************************************************************************
        '### Confirm from user if to send Request to GTravel
        Dim cGTRSTravelRequestID As String = Me.TravelRequestID
        Dim isSendingUpdate As Boolean = False
        If SendWithoutPrompt Then
            bSuccess = True
        Else
            bSuccess = False
            If IfNull(cGTRSTravelRequestID, "").Length > 0 Then
                bSuccess = MsgBox("Do you want to continue send the updates to GTravel?" & vbNewLine & _
                                  "[TravelRequestID: " & cGTRSTravelRequestID & "]", _
                                  MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetAppName()) = MsgBoxResult.Yes
                isSendingUpdate = True
            Else
                bSuccess = MsgBox("Do you want to book with GTravel?" & vbNewLine & "Click Yes to create a Travel Request with G Travel.", _
                                  MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetAppName()) = MsgBoxResult.Yes
            End If
        End If

        If bSuccess Then
            ReturnValue = SendGTRSTravelRequest(isSendingUpdate)

        End If

        Return ReturnValue
    End Function

    Private Function SendGTRSTravelRequest(Optional isSendingUpdate As Boolean = False) As Boolean
        Dim ReturnValue As Boolean = False
        Dim bSuccess As Boolean = False

        bSuccess = SendGTRSTravelRequest_1Main()

        If bSuccess Then
            Dim _result As PassengerTravelRequestResult
            _result = SendGTRSTravelRequest_2Passenger()
            Select Case _result
                Case PassengerTravelRequestResult.Completed
                    MsgBox("Successfully sent Travel Request " & IIf(isSendingUpdate, "Update ", "") & "to GTravel.", MsgBoxStyle.Information, GetAppName)
                    ReturnValue = True

                Case PassengerTravelRequestResult.Failed
                    MsgBox("Sending of Travel Request " & IIf(isSendingUpdate, "Update ", "") & "to GTravel Failed.", MsgBoxStyle.Critical, GetAppName)
                    ReturnValue = False

                Case PassengerTravelRequestResult.Incomplete
                    MsgBox("Successfully sent Travel Request " & IIf(isSendingUpdate, "Update ", "") & "to GTravel but some passengers have failed.", MsgBoxStyle.Exclamation, GetAppName)
                    ReturnValue = True

            End Select



        Else
            MsgBox("Failed to send travel request to GTravel", MsgBoxStyle.Critical)
            ReturnValue = False

        End If

        Return ReturnValue
    End Function

    Private Function SendGTRSTravelRequest_1Main() As Boolean
        ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Sending request to GTravel")
        If chkisSentToGTravel.Checked Then
            Return True
            '### EXIT AND RETURN TRUE IF THE UPDATES ARE ALREADY SENT TO GTRAVEL
        End If

        'START SEND GTRS TRANSACTION
        Dim isNewRequest As Boolean = IfNull(Me.TravelRequestID, "").Length = 0
        Dim bSuccess As Boolean = False

        If isNewRequest Then
            If isValidForCreateTravelRequest() Then
                bSuccess = CreateTravelRequest()
            End If
        Else
            bSuccess = UpdateTravelRequest()
        End If

        CloseCustomLoadScreen()

        Return bSuccess
    End Function

    ''' <summary>
    ''' Result Return Value for function SendGTRSTravelRequest_2Passenger
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum PassengerTravelRequestResult
        Completed = 1
        Incomplete = 2 'Some are sent, some failed
        Failed = 3
    End Enum
    Private Function SendGTRSTravelRequest_2Passenger() As PassengerTravelRequestResult
        Dim pToSend As Integer = 0, pSuccess As Integer = 0

        ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Sending passenger request to GTravel")

        For i As Integer = 0 To PassengerView.RowCount - 1
            '### CHECKS IF PASSENGER RECORD HAS PKEY
            If IfNull(PassengerView.GetRowCellValue(i, "PKey"), "").Length > 0 Then

                'IF NOT YET SENT TO GTRAVEL
                If Not IfNull(PassengerView.GetRowCellValue(i, "isSentToGTravel"), False) Then
                    pToSend = pToSend + 1
                    '### CHECKS IF PASSENGER RECORD HAS PASSENGERID FROM GTRAVEL
                    If IfNull(PassengerView.GetRowCellValue(i, "PassengerID"), "").Length > 0 Then
                        'if passenger has passengerid, send a Passenger Update to GTRS
                        If SendGTRSTravelRequest_2Passenger_Update(i) Then
                            pSuccess = pSuccess + 1
                        End If
                    Else
                        'if passenger has no passengerid, send an Add Passenger command to GTRS
                        If SendGTRSTravelRequest_2Passenger_Add(i) Then
                            pSuccess = pSuccess + 1
                        End If
                    End If
                End If

            End If
        Next

        CloseCustomLoadScreen()

        If pToSend > 0 Then
            If pToSend = pSuccess Then
                Return PassengerTravelRequestResult.Completed
            Else
                If pSuccess = 0 Then
                    Return PassengerTravelRequestResult.Failed
                Else
                    Return PassengerTravelRequestResult.Incomplete
                End If
            End If
        Else
            Return PassengerTravelRequestResult.Completed
        End If
    End Function

    Private Function SendGTRSTravelRequest_2Passenger_Add(rowhandle As Integer) As Boolean
        Dim cNewPassengerID As String = ""

        Try
            Dim passenger As MPS4.GTRSServiceReference.passenger
            passenger = GetPassengerToAdd(rowhandle)
            Dim oTransactionLogInfo As New TransactionLogInfo(TransactionType.Send, "AddPassenger", FormName, strID, "Add Passenger to Travel Request", "CrewName: " & passenger.lastName & ", " & passenger.firstName)
            cNewPassengerID = oGTRS.AddPassenger(passenger)
            If IfNull(cNewPassengerID, "").Length > 0 Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "AddPassenger to GTravel", 10, System.Environment.MachineName, "<tblTravelBookingCrew><PKey: " & IfNull(PassengerView.GetRowCellValue(rowhandle, "PKey"), "") & ">", FormName)
                LogGTRSTransaction(oTransactionLogInfo)
                Return MPSDB.RunSql("UPDATE dbo.tblTravelBookingCrew SET PassengerID = '" & cNewPassengerID & "', isSentToGTravel = 1, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & IfNull(PassengerView.GetRowCellValue(rowhandle, "PKey"), "") & "'")
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function SendGTRSTravelRequest_2Passenger_Update(rowhandle As Integer) As Boolean
        Dim bSuccess As Boolean = False

        Try
            Dim passenger As MPS4.GTRSServiceReference.passengerUpdate
            passenger = GetPassengerToUpdate(rowhandle)
            Dim oTransactionLogInfo As New TransactionLogInfo(TransactionType.Send, "UpdatePassenger", FormName, strID, "Update Passenger from Travel Request", "CrewName: " & passenger.lastName & ", " & passenger.firstName)
            bSuccess = oGTRS.UpdatePassenger(GetPassengerToUpdate(rowhandle))
            If bSuccess Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "UpdatePassenger to GTravel", 10, System.Environment.MachineName, "<tblTravelBookingCrew><PKey: " & IfNull(PassengerView.GetRowCellValue(rowhandle, "PKey"), "") & "><PassengerID: " & IfNull(PassengerView.GetRowCellValue(rowhandle, "PassengerID"), ""), FormName)
                LogGTRSTransaction(oTransactionLogInfo)
                Return MPSDB.RunSql("UPDATE dbo.tblTravelBookingCrew SET isSentToGTravel = 1, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & IfNull(PassengerView.GetRowCellValue(rowhandle, "PKey"), "") & "'")
            Else
                LogGTRSTransaction(oTransactionLogInfo, "Failed to send UpdatePassenger data to GTRS. " & oGTRS.LastErrorMessage)
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Sends Passenger Cancelation to GTravel
    ''' </summary>
    ''' <param name="TravelBookingCrewID"></param>
    ''' <param name="PassengerID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendGTRSTravelRequest_3CancelPassenger(TravelBookingCrewID As String, PassengerID As String) As Boolean

        Dim bSuccess As Boolean = False

        Try
            Dim oCancelPassenger As New MPS4.GTRSServiceReference.CancelPassenger

            oCancelPassenger.passengerID = PassengerID

            modGTRS.LogProcess(" - Cancel Passenger : [" & oCancelPassenger.passengerID & "]")
            Dim oTransactionLogInfo As New TransactionLogInfo(TransactionType.Send, "CancelPassenger", FormName, strID, "Cancel Passenger from Travel Request", "CrewName: " & PassengerView.GetFocusedRowCellValue("LName") & ", " & PassengerView.GetFocusedRowCellValue("FName"))

            bSuccess = oGTRS.CancelPassenger(oCancelPassenger)
            If bSuccess Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "CancelPassenger to GTravel", 10, System.Environment.MachineName, "<tblTravelBookingCrew><PKey: " & IfNull(TravelBookingCrewID, "") & "><PassengerID: " & IfNull(PassengerID, ""), FormName)
                Return MPSDB.RunSql("UPDATE dbo.tblTravelBookingCrew SET TravelRequestID = '', isSentToGTravel = 0, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & TravelBookingCrewID & "'")
            Else
                LogGTRSTransaction(oTransactionLogInfo, "Failed to send CancelPassenger data to GTRS. " & oGTRS.LastErrorMessage)
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Get Passenger Data"

    Private Function HasPassengers() As Boolean
        Return PassengerView.RowCount > 0
    End Function

    Private Function GetPassengerToAdd(FocusedRowHandle As Integer) As MPS4.GTRSServiceReference.passenger
        Dim ReturnValue As New MPS4.GTRSServiceReference.passenger

        If FocusedRowHandle > (PassengerView.RowCount - 1) Or FocusedRowHandle < 0 Then
            ReturnValue = Nothing
        Else
            With ReturnValue
                .travelRequestID = Me.TravelRequestID
                .employeeNo = IfNull(GetPassengerGridData("FKeyCrew", FocusedRowHandle), "")
                .lastName = IfNull(GetPassengerGridData("LName", FocusedRowHandle), "")
                .firstName = IfNull(GetPassengerGridData("FName", FocusedRowHandle), "")
                .gender = IfNull(GetPassengerGridData("Gender", FocusedRowHandle), "")
                .dateOfBirth = ChangeToGTRSDate(GetPassengerGridData("DOB", FocusedRowHandle))
                .placeOfBirth = IfNull(GetPassengerGridData("POB", FocusedRowHandle), "")
                .nationality = IfNull(GetPassengerGridData("Nationality", FocusedRowHandle), "")
                .position = IfNull(GetPassengerGridData("RankName", FocusedRowHandle), "")
                .recruitingOffice = IfNull(GetPassengerGridData("AgentName", FocusedRowHandle), "")
                .passportNo = IfNull(GetPassengerGridData("PPNo", FocusedRowHandle), "")
                .passportIssuedDate = ChangeToGTRSDate(GetPassengerGridData("PPIssueDate", FocusedRowHandle))
                .passportExpiryDate = ChangeToGTRSDate(GetPassengerGridData("PPExpiryDate", FocusedRowHandle))
                .passportPlaceIssue = IfNull(GetPassengerGridData("PPPlaceIssue", FocusedRowHandle), "")
                .seamansBookNo = IfNull(GetPassengerGridData("SBNo", FocusedRowHandle), "")
                .seamanIssuedDate = ChangeToGTRSDate(GetPassengerGridData("SBIssueDate", FocusedRowHandle))
                .seamanExpiryDate = ChangeToGTRSDate(GetPassengerGridData("SBExpiryDate", FocusedRowHandle))
                .seamanPlaceIssue = IfNull(GetPassengerGridData("SBPlaceIssue", FocusedRowHandle), "")
                .cellphone = IfNull(GetPassengerGridData("Celphone", FocusedRowHandle), "")
                .phone = IfNull(GetPassengerGridData("Phone", FocusedRowHandle), "")
                .email = IfNull(GetPassengerGridData("Email", FocusedRowHandle), "")
                .nearestAirport = IfNull(GetPassengerGridData("NearestAirportName", FocusedRowHandle), "")
                .alternateAirport = IfNull(GetPassengerGridData("AlternateAirportName", FocusedRowHandle), "")
                .allocation1 = ""
                .allocation2 = ""
                .allocation3 = ""
                .earliestArrival = ChangeToGTRSDate(GetPassengerGridData("ETAE", FocusedRowHandle))
                .latestArrival = ChangeToGTRSDate(GetPassengerGridData("ETAL", FocusedRowHandle))
                .earliestDeparture = ChangeToGTRSDate(GetPassengerGridData("ETD", FocusedRowHandle))
                .frequentFlyerMemberShip = IfNull(GetPassengerGridData("FrequentFlyerMembership", FocusedRowHandle), "")
                .frequentFlyerNumber = IfNull(GetPassengerGridData("FrequentFlyerNumber", FocusedRowHandle), "")
                .visa = IfNull(GetPassengerGridData("Visa", FocusedRowHandle), "")
            End With

        End If

        Return ReturnValue
    End Function

    Private Function GetPassengerToUpdate(FocusedRowHandle) As MPS4.GTRSServiceReference.passengerUpdate
        Dim ReturnValue As New MPS4.GTRSServiceReference.passengerUpdate

        If FocusedRowHandle > (PassengerView.RowCount - 1) Or FocusedRowHandle < 0 Then
            ReturnValue = Nothing
        Else
            With ReturnValue
                .travelRequestID = Me.TravelRequestID
                .employeeNo = IfNull(GetPassengerGridData("FKeyCrew", FocusedRowHandle), "")
                .lastName = IfNull(GetPassengerGridData("LName", FocusedRowHandle), "")
                .firstName = IfNull(GetPassengerGridData("FName", FocusedRowHandle), "")
                .gender = IfNull(GetPassengerGridData("Gender", FocusedRowHandle), "")
                .dateOfBirth = ChangeToGTRSDate(GetPassengerGridData("DOB", FocusedRowHandle))
                .placeOfBirth = IfNull(GetPassengerGridData("POB", FocusedRowHandle), "")
                .nationality = IfNull(GetPassengerGridData("Nationality", FocusedRowHandle), "")
                .position = IfNull(GetPassengerGridData("RankName", FocusedRowHandle), "")
                .recruitingOffice = IfNull(GetPassengerGridData("AgentName", FocusedRowHandle), "")
                .passportNo = IfNull(GetPassengerGridData("PPNo", FocusedRowHandle), "")
                .passportIssuedDate = ChangeToGTRSDate(GetPassengerGridData("PPIssueDate", FocusedRowHandle))
                .passportExpiryDate = ChangeToGTRSDate(GetPassengerGridData("PPExpiryDate", FocusedRowHandle))
                .passportPlaceIssue = IfNull(GetPassengerGridData("PPPlaceIssue", FocusedRowHandle), "")
                .seamansBookNo = IfNull(GetPassengerGridData("SBNo", FocusedRowHandle), "")
                .seamanIssuedDate = IfNull(GetPassengerGridData("SBIssueDate", FocusedRowHandle), "")
                .seamanExpiryDate = IfNull(GetPassengerGridData("SBExpiryDate", FocusedRowHandle), "")
                .seamanPlaceIssue = IfNull(GetPassengerGridData("SBPlaceIssue", FocusedRowHandle), "")
                .cellphone = IfNull(GetPassengerGridData("Celphone", FocusedRowHandle), "")
                .phone = IfNull(GetPassengerGridData("Phone", FocusedRowHandle), "")
                .email = IfNull(GetPassengerGridData("Email", FocusedRowHandle), "")
                .nearestAirport = IfNull(GetPassengerGridData("NearestAirportName", FocusedRowHandle), "")
                .alternateAirport = IfNull(GetPassengerGridData("AlternateAirportName", FocusedRowHandle), "")
                .allocation1 = ""
                .allocation2 = ""
                .allocation3 = ""
                .earliestArrival = ChangeToGTRSDate(GetPassengerGridData("ETAE", FocusedRowHandle))
                .latestArrival = ChangeToGTRSDate(GetPassengerGridData("ETAL", FocusedRowHandle))
                .earliestDeparture = ChangeToGTRSDate(GetPassengerGridData("ETD", FocusedRowHandle))
                .frequentFlyerMemberShip = IfNull(GetPassengerGridData("FrequentFlyerMembership", FocusedRowHandle), "")
                .frequentFlyerNumber = IfNull(GetPassengerGridData("FrequentFlyerNumber", FocusedRowHandle), "")
                .visa = IfNull(GetPassengerGridData("Visa", FocusedRowHandle), "")
                .passengerID = IfNull(GetPassengerGridData("PassengerID", FocusedRowHandle), "")
            End With

        End If

        Return ReturnValue
    End Function

    Private Function GetPassengerGridData(FieldName As String, FocusedRowIndex As Integer)
        Return PassengerView.GetRowCellValue(FocusedRowIndex, FieldName)
    End Function

    ''' <summary>
    ''' Enables or disables Add Passenger dropdown and button inside the Passenger Details section
    ''' </summary>
    ''' <param name="enable"></param>
    ''' <remarks></remarks>
    Private Sub EnableAddPassengerGroup(Optional enable As Boolean = True)
        If enable Then
            LayoutControlGroup_AddPassenger.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlGroup_AddPassenger.Expanded = True
        Else
            LayoutControlGroup_AddPassenger.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlGroup_AddPassenger.Expanded = False
        End If
    End Sub
#End Region


#Region "Edit Data"
    Public Overrides Sub EditData()
        MyBase.EditData()

        header.Focus()

        If isEditdable Then
            If BookingStatus.Completed Then
                MsgBox("This travel request record is already set as completed. Editing is no longer allowed.", MsgBoxStyle.Information)
                RaiseCustomEvent(Name, New Object() {"UnpressEditButtonDown"})
                Exit Sub
            End If
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### enables the Add Passenger button
            EnableAddPassengerGroup()

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### shows and enables Mark as Completed button
            EnableMarkAsCompleted(True)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### record is 'Canceled' do you want to continue?
            If cboBookingStatus.EditValue.Equals(TravelBookingStatus.Canceled.Key) Then
                If MsgBox("This travel request is already set as 'Canceled'." & vbNewLine & vbNewLine & "Do you still want to continue to edit the record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    ExecCustomFunction(New Object() {"CancelData"})
                    Exit Sub
                End If
            End If

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            AllowAddition(Name, False)
            AllowSaving(Name, True)
            RaiseCustomEvent(Name, New Object() {"ShowCancelButton", True})

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            RemoveReadOnlyListener(LayoutControlGroups)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### Updates Mark as Completed button ForeColor
            SetCompletedCheckColor()

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### Updates Mark as Completed button ForeColor
            txtTravelRequestID.ReadOnly = True

            If Not BookingStatus.Completed Then
                '### COMPLETED
                AddEditListener(LayoutControlGroups)
                AddGTRSEditListener()

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                EditSubAllowGrid(PassengerView, True, False)

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If oGTRSControl.BookedWithGTravel Then
                    'IF BOOKED WITH GTRAVEL, disable Booking Details and hide delete and copy buttons
                    EditSubAllowGrid(BookingDetailsView, False)
                    ShowManualBookingCtls(False)
                Else
                    'IF NOT, enable Booking Details and show delete and copy buttons
                    EditSubAllowGrid(BookingDetailsView, True, True)
                    ShowManualBookingCtls(True)
                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '### show copy button control on Travel Costs grid
                ShowTravelCostsCtls(True)

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                EditSubAllowGrid(TravelCostView, True)

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                RemoveEditListener(cboAddCrew, False)

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '### enable/show remove passenger button in Passenger View
                EnableRemovePassenger()
            End If

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### enable/show remove passenger button in Passenger View
            ShowVesselData(True, False)
            oGTRSControl.EditData()
            oGTRSControl.HasUnsentUpdates = HasUnsentUpdates()
            isCheckIfChangingBookingStatus = True

        Else
            'IF NOT EDITABLE
            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### disable Mark as Completed button
            EnableMarkAsCompleted(False)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            AllowAddition(Name, True)
            AllowSaving(Name, False)
            RaiseCustomEvent(Name, New Object() {"ShowCancelButton", False})
            MakeReadOnlyListener(LayoutControlGroups)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            EditSubAllowGrid(PassengerView, False)
            EditSubAllowGrid(BookingDetailsView, False)
            EditSubAllowGrid(TravelCostView, False)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### hide Remove (Delete) Passenger button in Passenger View
            EnableRemovePassenger(False)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### Show All Vessel
            ShowVesselData(False)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            oGTRSControl.RefreshData()

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '### hide copy and delete buttons in Booking Details grid
            ShowManualBookingCtls(False)
            '### hide delete buttons in Costs Details grid
            ShowTravelCostsCtls(False)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            RemoveEditListener(LayoutControlGroups, False)
            RemoveGTRSEditListener()
            RemoveEditListener(LayoutControlGroup_TravelRequest, False)

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            isCheckIfChangingBookingStatus = False

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            RefreshData()
        End If

        SetBookingStatusColorProperty()
        AllowDeletion(Name, isEditdable)

    End Sub

#End Region
#End Region

#Region "Manual Booking"
    ''' <summary>
    ''' Shows or hides Booking Details GridView controls (Copy and Delete buttons)
    ''' </summary>
    ''' <param name="show"></param>
    ''' <remarks></remarks>
    Private Sub ShowManualBookingCtls(show As Boolean)
        For i As Integer = 0 To BookingDetailsView.Bands.Count - 1
            If BookingDetailsView.Bands(i).Name = "bdBandControls" Then
                BookingDetailsView.Bands(i).Visible = show
            End If
        Next
        For i As Integer = 0 To BookingDetailsView.Columns.Count - 1
            If BookingDetailsView.Columns(i).Name = "bdDelete" Or BookingDetailsView.Columns(i).Name = "bdCopy" Then
                Try
                    BookingDetailsView.Columns(i).Visible = show
                    If BookingDetailsView.Columns(i).Name = "bdDelete" And show Then
                        BookingDetailsView.Columns(i).Visible = (show And HasDeletePermission)
                        BookingDetailsView.Columns(i).VisibleIndex = 0
                    ElseIf BookingDetailsView.Columns(i).Name = "bdCopy" And show Then
                        BookingDetailsView.Columns(i).VisibleIndex = 2
                    End If
                Catch ex As Exception
                    BookingDetailsView.Columns(i).Visible = False
                End Try
            End If
        Next
    End Sub

    Private Function HasManuallyAddedBookingDetails() As Boolean
        For i As Integer = 0 To BookingDetailsView.RowCount - 1
            If Not BookingDetailsView.GetRowCellValue(i, "isFromGTravel") Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function
#End Region

#Region "Travel Details"
    Private Sub txtETD_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtETD.EditValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub
        If IfNull(txtETD.EditValue, "").Length > 0 Then

            If IfNull(txtETAE.EditValue, "").Length = 0 And IfNull(txtETAL.EditValue, "").Length = 0 Then
                Dim dDate As DateTime = DateAdd(DateInterval.Hour, 1, txtETD.EditValue)
                txtETAE.EditValue = dDate
                txtETAL.EditValue = dDate
            End If

            For i As Integer = 0 To PassengerView.RowCount - 1
                PassengerView.SetRowCellValue(i, "ETD", txtETD.EditValue)
                PassengerView.SetRowCellValue(i, "Edited", True)
            Next

            If IfNull(txtETD.EditValue, "").Length > 0 Then
                If IsDate(txtETD.EditValue) Then
                    Dim _date As Date = txtETD.EditValue
                    txtETAE.Properties.MinValue = DateSerial(_date.Year, _date.Month, _date.Day)
                    txtETAL.Properties.MinValue = DateSerial(_date.Year, _date.Month, _date.Day)
                End If

            End If
        End If
    End Sub

    Private Sub txtETAE_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtETAE.EditValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub
        If IfNull(txtETAE.EditValue, "").Length > 0 Then
            For i As Integer = 0 To PassengerView.RowCount - 1
                PassengerView.SetRowCellValue(i, "ETAE", txtETAE.EditValue)
                PassengerView.SetRowCellValue(i, "Edited", True)
            Next
        End If
    End Sub

    Private Sub txtETAL_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtETAL.EditValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub
        If IfNull(txtETD.EditValue, "").Length > 0 Then
            For i As Integer = 0 To PassengerView.RowCount - 1
                PassengerView.SetRowCellValue(i, "ETAL", txtETAL.EditValue)
                PassengerView.SetRowCellValue(i, "Edited", True)
            Next
        End If
    End Sub

    Private Sub chkTravelCompleted_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If Not isEditdable Then Exit Sub
        If e.NewValue = True Then
            If Not BookingStatus.Booked Then
                If MsgBox("This travel request is not yet booked." & vbNewLine & "Do you want to continue to mark this as Completed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            e.Cancel = (MsgBox("Are you sure you want to mark this travel booking as 'Completed'?" & vbNewLine & "Marking this Travel Request/Booking as 'Completed' will no longer allow any editing in the future." & vbNewLine & vbNewLine & "Continue?", MsgBoxStyle.Question + vbYesNo) = vbNo)

        ElseIf e.NewValue = False Then
            e.Cancel = (MsgBox("Are you sure you want to unmark this travel booking as completed?", MsgBoxStyle.Question + vbYesNo) = vbNo)
        End If
    End Sub

#End Region

#Region "Booking Details"
    'Private Function CreateBookingDetailsDatatable() As DataTable
    '    Dim dt As New DataTable

    '    Dim col As New DataColumn
    '    col.ColumnName = "PKey"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "FKeyTravelBooking"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "FKeyTravelBookingCrew"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "CoIDNo"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "ItemType"
    '    col.DataType = System.Type.GetType("System.Int32")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "AmadeusName"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "FlightNumber"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "ClassOfService"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "Origin"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "OriginDesc"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "DepartureTime"
    '    col.DataType = System.Type.GetType("System.DateTime")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "Destination"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "DestinationDesc"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "ArrivalTime"
    '    col.DataType = System.Type.GetType("System.DateTime")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "Company"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "FreeTxt"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "Status"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)

    '    col = New DataColumn
    '    col.ColumnName = "Reference"
    '    col.DataType = System.Type.GetType("System.String")
    '    dt.Columns.Add(col)
    'End Function

    Private Sub UpdateBookingDetails(Optional isManualRefresh As Boolean = False)
        'tonytest
        'Dim bSuccess As Boolean = False
        'Dim _DateToCheck As DateTime

        'If Not oGTRSControl.BookedWithGTravel Then Exit Sub
        'If IsNothing(cboBookingStatus.EditValue) Then Exit Sub
        'If cboBookingStatus.EditValue.Equals(TravelBookingStatus.Canceled.Key) Or cboBookingStatus.EditValue.Equals(TravelBookingStatus.Booked.Key) Then Exit Sub

        ''If isManualRefresh Then ShowCustomLoadScreen(GetType(MPS4.Waitform), "Gathering response from GTravel...")
        'If Not BookingStatus.Booked And BookingStatus.WaitingForGTRSResponse And oGTRS.Initialized = ServiceObjectState.Initialized Then
        '    'IF NOT YET BOOKED AND HAS BOOKING REQUEST

        '    If isManualRefresh Then
        '        _DateToCheck = DateAdd(DateInterval.Minute, -10, getServerDateTime())
        '    Else
        '        If IsNothing(RefreshStatusAt) Then
        '            RefreshStatusAt = GetNextResponseTime() 'tonytest DateAdd(DateInterval.Minute, 15, getServerDateTime())
        '            MPSDB.RunSql("UPDATE dbo.tblTravelBooking SET RefreshGTRSDetailsAt = " & ChangeToSQLDate(RefreshStatusAt) & ", BookingStatus = '" & TravelBookingStatus.WaitingGTRSResponse.Key & "', DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & strID & "'")
        '        End If
        '        _DateToCheck = RefreshStatusAt
        '    End If

        '    If _DateToCheck < getServerDateTime() And RefreshStatusAt <> #12:00:00 AM# Then
        '        'IF REFRESH TIME IS ALREDY PASS CURRENT TIME
        '        ShowCustomLoadScreen(GetType(MPS4.Waitform), "MPS5 - Travel", "Gathering response from GTravel...")

        '        'IF TravelRequestID is INVALID
        '        If Not isValidGTRSID(IfNull(Me.TravelRequestID, "")) Then
        '            CreateTravelRequest(True)
        '            LoadTravelDetails()
        '        End If

        '        If CheckForInternetConnection() Then
        '            If oGTRS.Initialized = ServiceObjectState.Initialized And oGTRS.UserAuthenticated = UserAuthentication.Success Then
        '                bSuccess = GetTravelRequestDetailsFromGTRS(True)

        '                If bSuccess Then
        '                    MPSDB.RunSql("UPDATE dbo.tblTravelBooking SET RefreshGTRSDetailsAt = NULL, BookingStatus = '" & TravelBookingStatus.Booked.Key & "', isUpdated = 0, BookingStatus = '" & TravelBookingStatus.Booked.Key & "' , DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & strID & "'")
        '                    BookingStatus.WaitingForGTRSResponse = False
        '                    BookingStatus.Booked = True
        '                    cboBookingStatus.EditValue = TravelBookingStatus.Booked.Key
        '                    RefreshStatusAt = Nothing

        '                    CloseCustomLoadScreen()
        '                    If isManualRefresh Then MsgBox("Refresh Successful.", MsgBoxStyle.Information)
        '                Else
        '                    RefreshStatusAt = GetNextResponseTime() 'tonytest DateAdd(DateInterval.Minute, 15, getServerDateTime())
        '                    MPSDB.RunSql("UPDATE dbo.tblTravelBooking SET RefreshGTRSDetailsAt = " & ChangeToSQLDate(RefreshStatusAt) & ", BookingStatus = '" & TravelBookingStatus.WaitingGTRSResponse.Key & "', DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & strID & "'")
        '                    cboBookingStatus.EditValue = TravelBookingStatus.WaitingGTRSResponse.Key

        '                    CloseCustomLoadScreen()
        '                    If isManualRefresh Then MsgBox("No Tranascation Response Received Yet From GTravel.", MsgBoxStyle.Exclamation)

        '                End If
        '            End If


        '        Else
        '            CloseCustomLoadScreen()
        '            If isManualRefresh Then MsgBox("Unable to connect to the internet.", MsgBoxStyle.Exclamation)
        '        End If
        '        CloseCustomLoadScreen()


        '    End If


        'End If

        ''If isManualRefresh Then CloseCustomLoadScreen()

    End Sub

    Private Function SaveBookingDetailsFromGTRS(response As MPS4.GTRSServiceReference.ViewTravelRequestResponse) As Boolean
        Dim ReturnValue As Boolean = False
        '<!--added by tony20180922 : Log Deletion
        oLogDeletion.Init()
        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
            FormName, _
            "Crewing", _
            "tblTravelBookingDetail", _
            "PKey IN ('" & strID & "')", _
            "<< Delete Crew Data - " & FormName & " - Refresh Travel Booking Details>>", _
            LogDeletion.DeletionType.Manual, _
            "Manually Deleted in <" & FormName & "- Refresh Travel Booking Details>", _
            GetUserName())
        '-->

        If MPSDB.RunSql("DELETE FROM dbo.tblTravelBookingDetail WHERE FKeyTravelBooking = '" & strID & "'") Then
            oLogDeletion.AddLogEntryToDatabase()
        End If

        Dim sqls As New ArrayList
        Dim cSQL As String = ""
        For i As Integer = 0 To response.ocsTransactions.Count - 1
            With response.ocsTransactions(i)

                cSQL = "INSERT INTO [dbo].[tblTravelBookingDetail] " & _
                       "            ([FKeyTravelBooking] " & _
                       "            ,[PassengerID] " & _
                       "            ,[ItemType] " & _
                       "            ,[AmadeusName] " & _
                       "            ,[FlightNumber] " & _
                       "            ,[ClassOfService] " & _
                       "            ,[Origin] " & _
                       "            ,[OriginDesc] " & _
                       "            ,[DepartureTime] " & _
                       "            ,[Destination] " & _
                       "            ,[DestinationDesc] " & _
                       "            ,[ArrivalTime] " & _
                       "            ,[Company] " & _
                       "            ,[FreeTxt] " & _
                       "            ,[Status] " & _
                       "            ,[Reference] " & _
                       "            ,[DateUpdated] " & _
                       "            ,[LastUpdatedBy] " & _
                       "            ,[isCanceled]) " & _
                       "VALUES " & _
                       "            ('" & strID & "' " & _
                       "            ,'" & .employeeNo & "' " & _
                       "            ,'" & IfNull(.itemType, "") & "' " & _
                       "            ,'" & .amaName & "' " & _
                       "            ,'" & .flightnumber & "' " & _
                       "            ,'" & .classOfService & "' " & _
                       "            ,'" & .origin & "' " & _
                       "            ,'" & .originDesc & "' " & _
                       "            ," & If(ChangeToSQLDate(.departureTime).Equals("''"), "NULL", ChangeToSQLDate(.departureTime)) & " " & _
                       "            ,'" & .destination & "' " & _
                       "            ,'" & .destinationDesc & "' " & _
                       "            ," & If(ChangeToSQLDate(.arrivalTime).Equals("''"), "NULL", ChangeToSQLDate(.arrivalTime)) & " " & _
                       "            ,'" & .company & "' " & _
                       "            ,'" & .freeText & "' " & _
                       "            ,'" & .status & "' " & _
                       "            ,'" & .reference & "' " & _
                       "            ,getdate()  " & _
                       "            ,'" & LastUpdatedBy & "' " & _
                       "            ,0)"

            End With
            sqls.Add(cSQL)

        Next

        If sqls.Count > 0 Then
            ReturnValue = MPSDB.RunSqls(sqls)
        End If

        Return ReturnValue
    End Function

    Private Sub BookingDetailsView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BookingDetailsView.CellValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub
        If e.Column.FieldName <> "Edited" Then
            BookingDetailsView.SetFocusedRowCellValue("Edited", True)
        End If
    End Sub

    Private Sub BookingDetailsView_CustomDrawEmptyForeground(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs) Handles BookingDetailsView.CustomDrawEmptyForeground
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If oGTRS.MyStatus = GTRSServiceStatus.Okay Then
            If BookingDetailsView.RowCount = 0 And oGTRSControl.BookedWithGTravel Then
                Dim drawFormat As New System.Drawing.StringFormat()
                drawFormat.LineAlignment = System.Drawing.StringAlignment.Center
                drawFormat.Alignment = drawFormat.LineAlignment
                'e.Graphics.DrawString("Awaiting response from GTravel." & vbCrLf & "Will check response again later on" & IIf(IfNull(RefreshStatusAt, "").Length > 0, " " & Format(RefreshStatusAt, "dd-MMM-yyyy hh:mm"), "") & ".", New System.Drawing.Font(e.Appearance.Font.Style, 14), System.Drawing.SystemBrushes.ControlDark, New System.Drawing.RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat)
                e.Graphics.DrawString("This travel has no booking details yet. Please coordinate with GTravel. Once they have arrange the booking, click on the Update Travel Request button to update the booking details.", New System.Drawing.Font(e.Appearance.Font.Style, 14), System.Drawing.SystemBrushes.ControlDark, New System.Drawing.RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat)
            End If
        End If
    End Sub

    Private Sub BookingDetailsView_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BookingDetailsView.CustomRowCellEditForEditing

        If e.Column.FieldName = "AmadeusName" Then
            If oGTRSControl.BookedWithGTravel Then
                e.RepositoryItem = CreateGTRSBookingCrewSrc()
            Else
                e.RepositoryItem = CreateManualBookingCrewSrc()
            End If
        End If

    End Sub

    Private Sub cmdRefreshBookingDetails_Click(sender As System.Object, e As System.EventArgs)
        UpdateBookingDetails(True)
    End Sub

    Private Sub BookingDetailsView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles BookingDetailsView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("CancelStatus"), BookedOrCanceled.Booked)
    End Sub

    Private Sub repBDDelete_Click(sender As Object, e As System.EventArgs) Handles repBDDelete.Click
        DeleteBooking()
    End Sub

    Private Sub repBDCopy_Click(sender As Object, e As System.EventArgs) Handles repBDCopy.Click
        CopyBookingDetails()
    End Sub

    Private Sub CopyBookingDetails()
        If TravelRequestIsBooked Then
            MsgBox("Copying of booking details is not allowed if a travel request is set as 'Booked'.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = BookingDetailsView
        If view.FocusedRowHandle >= 0 Then
            If MsgBox("You are about to copy the booking details of " & view.GetFocusedRowCellValue("AmadeusName") & "." & vbNewLine & vbNewLine & _
                      "Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim f As New frmCopyBookingDetails
                f.cboCrew.Properties.DataSource = GetManualCrewDataSrc()
                f.ShowDialog()
                If f.CancelButtonClicked Then
                    Exit Sub
                ElseIf f.CopyButtonClicked Then
                    Dim row As DataRow = BookingDetailsView.GetDataRow(view.FocusedRowHandle)
                    row("FKeyCrew") = f.cboCrew.EditValue
                    row("AmadeusName") = f.cboCrew.Text

                    BookingDetailsView.AddNewRow()

                    'Dim row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
                    Dim fldName As String
                    For Each dc As DataColumn In TryCast(BookingDetailsGrid.DataSource, DataTable).Columns
                        fldName = dc.ColumnName
                        If fldName = "FKeyCrew" Then
                            BookingDetailsView.SetRowCellValue(BookingDetailsView.FocusedRowHandle, fldName, f.cboCrew.EditValue)
                        ElseIf fldName = "AmadeusName" Then
                            BookingDetailsView.SetRowCellValue(BookingDetailsView.FocusedRowHandle, fldName, f.cboCrew.Text)
                        ElseIf fldName = "PKey" Then
                            BookingDetailsView.SetRowCellValue(BookingDetailsView.FocusedRowHandle, fldName, DBNull.Value)
                        End If
                        BookingDetailsView.SetRowCellValue(BookingDetailsView.FocusedRowHandle, fldName, row(fldName))
                    Next

                    BookingDetailsView.SetRowCellValue(BookingDetailsView.FocusedRowHandle, "Edited", True)

                    f.Dispose()
                    BookingDetailsGrid.Update()
                    BookingDetailsView.UpdateCurrentRow()

                    BookingDetailsView.FocusedRowHandle = BookingDetailsView.RowCount - 1

                End If
            End If
        End If
    End Sub


    Private Sub BookingDetailsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BookingDetailsView.RowCellStyle
        ViewRowCellStyle(sender, e, "")

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName = "CancelStatus" Then
                If IfNull(.GetRowCellValue(e.RowHandle, "CancelStatus"), "").Equals(BookedOrCanceled.Canceled) Then
                    e.Appearance.BackColor = System.Drawing.Color.Firebrick
                    e.Appearance.ForeColor = System.Drawing.Color.White
                Else
                    e.Appearance.ForeColor = System.Drawing.Color.Black
                End If
            End If

        End With
    End Sub


    Private Sub txtTravelDate_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTravelDate.EditValueChanged
        If IsDate(txtTravelDate.EditValue) Then
            Dim maxDate As DateTime = DateAdd(DateInterval.Day, 2, txtTravelDate.EditValue)
            Dim minDate As DateTime = DateAdd(DateInterval.Day, -1, txtTravelDate.EditValue)
            'txtETAE.Properties.MaxValue = maxDate
            'txtETAE.Properties.MinValue = minDate
            'txtETAL.Properties.MaxValue = maxDate
            'txtETAL.Properties.MinValue = minDate
            'txtETD.Properties.MaxValue = maxDate
            'txtETD.Properties.MinValue = minDate
        End If
    End Sub

    Private Sub cboBookingStatus_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboBookingStatus.EditValueChanged

        Try
            BookingStatus.Booked = cboBookingStatus.EditValue.Equals(TravelBookingStatus.Booked.Key)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BookingDetailsView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles BookingDetailsView.RowUpdated
        If bAddMode Or isEditdable Then
            SetTravelRequestIsUpdated()
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub cboBookingStatus_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboBookingStatus.EditValueChanging
        If (isEditdable Or bAddMode) And isCheckIfChangingBookingStatus Then
            If IfNull(e.OldValue, "").Equals(TravelBookingStatus.Booked.Key) Then
                If MsgBox("This Travel Request is already set as 'Booked'. Are you sure you want to change its status to '" & LookupStatusName(e.NewValue) & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            cboBookingStatus.ForeColor = System.Drawing.Color.Black
        End If

    End Sub

#End Region

#Region "Travel Cost"
    ''' <summary>
    ''' Shows or hides Travel Costs GridView control (Copy button)
    ''' </summary>
    ''' <param name="show"></param>
    ''' <remarks></remarks>
    Private Sub ShowTravelCostsCtls(show As Boolean)
        For i As Integer = 0 To TravelCostView.Columns.Count - 1
            If TravelCostView.Columns(i).Name = "tcDelete" Then
                Try
                    TravelCostView.Columns(i).Visible = show And HasDeletePermission
                    If TravelCostView.Columns(i).Name = "tcDelete" And show Then
                        TravelCostView.Columns(i).VisibleIndex = 0
                    End If
                Catch ex As Exception
                    TravelCostView.Columns(i).Visible = False
                End Try
            End If
        Next
    End Sub

    Private Sub TravelCostView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TravelCostView.CellValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub

        If e.Column.FieldName = "ExRateToUSD" Or e.Column.FieldName = "Amount" Then
            Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
            View.SetRowCellValue(e.RowHandle, View.Columns("ConvertedAmount"), IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("Amount")), 0) * IfNull(View.GetRowCellValue(e.RowHandle, View.Columns("ExRateToUSD")), 0))
        End If

        If e.Column.FieldName <> "Edited" Then
            TravelCostView.SetFocusedRowCellValue("Edited", True)
        End If
    End Sub

    Private Sub TravelCostView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles TravelCostView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("Amount"), 0)
        View.SetRowCellValue(e.RowHandle, View.Columns("ExRateToUSD"), 0)
        View.SetRowCellValue(e.RowHandle, View.Columns("ConvertedAmount"), 0)
    End Sub

    Private Sub TravelCostView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles TravelCostView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub TravelCostView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles TravelCostView.RowUpdated
        If bAddMode Or isEditdable Then
            SetTravelRequestIsUpdated()
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub TravelCostView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles TravelCostView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim FKeyTravelCostItem As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyTravelCostItem")
        'Dim FKeyDocument As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")
        Dim FKeyCurr As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCurr")
        Dim Amount As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Amount")
        Dim ExRateToUSD As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("ExRateToUSD")
        'Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")
        'Dim tsNumber As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Number")

        With view
            'Validate Travel Cost Item
            If .GetRowCellValue(e.RowHandle, FKeyTravelCostItem) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyTravelCostItem) Is Nothing Then
                .SetColumnError(FKeyTravelCostItem, "Please select a Travel Cost Item.")
                e.Valid = False
            Else
                .SetColumnError(FKeyTravelCostItem, "")
            End If

            'Validate Currency
            If .GetRowCellValue(e.RowHandle, FKeyCurr) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyCurr) Is Nothing Then
                .SetColumnError(FKeyCurr, "Please select the currency.")
                e.Valid = False
            Else
                .SetColumnError(FKeyCurr, "")
            End If

            'Validate Amount
            If .GetRowCellValue(e.RowHandle, Amount) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, FKeyCurr) Is Nothing Or .GetRowCellValue(e.RowHandle, Amount) = 0 Then
                .SetColumnError(Amount, "Please enter the amount.")
                e.Valid = False
            Else
                .SetColumnError(Amount, "")
            End If

            'Validate ExRateToUSD
            If .GetRowCellValue(e.RowHandle, ExRateToUSD) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, ExRateToUSD) Is Nothing Or .GetRowCellValue(e.RowHandle, ExRateToUSD) = 0 Then
                .SetColumnError(ExRateToUSD, "Please enter the exchange rate to USD.")
                e.Valid = False
            Else
                .SetColumnError(ExRateToUSD, "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If
        End With
    End Sub

    Private Sub tcRepDelete_Click(sender As Object, e As System.EventArgs) Handles tcRepDelete.Click
        DeleteTravelCost()
    End Sub

#End Region

#Region "Form Events"
    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "CREATE_TRAVEL_REQUEST"
                If BRECORDUPDATEDs Then
                    If MsgBox("Would you like to save the changes first?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        If Not isValidForCreateTravelRequest() Then
                            Exit Sub
                        End If

                        showPromptToSendToGTravel = False
                        SaveData()
                        showPromptToSendToGTravel = True
                    Else
                        Exit Sub
                    End If
                    'Else
                    '    If Not isValidForCreateTravelRequest() Then
                    '        Exit Sub
                    '    End If

                    '    If SaveData_SendToGTravel(True) Then
                    '        blList.RefreshData()
                    '        RefreshData()
                    '    End If

                End If


                If SaveData_SendToGTravel(True) Then
                    blList.RefreshData()
                    RefreshData()
                End If
            Case "UPDATE_TRAVEL_REQUEST"
                If BRECORDUPDATEDs Then
                    If MsgBox("Would you like to save the changes first?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        If Not isValidForCreateTravelRequest() Then
                            Exit Sub
                        End If

                        showPromptToSendToGTravel = False
                        SaveData()
                        showPromptToSendToGTravel = True
                    Else
                        Exit Sub
                    End If
                    'Else
                    '    If Not isValidForCreateTravelRequest() Then
                    '        Exit Sub
                    '    End If

                    '    If SaveData_SendToGTravel(True) Then
                    '        blList.RefreshData()
                    '        RefreshData()
                    '    End If

                End If

                If oGTRSControl.BookedWithGTravel Then
                    SaveData_SendToGTravel()
                End If

            Case "GET_TRAVEL_REQUEST_UPDATE"
                If oGTRSControl.BookedWithGTravel Then
                    If oGTRS.MyStatus = GTRSServiceStatus.Okay And oGTRSControl.BookedWithGTravel Then
                        If Not GetGTRSTravelRequest_UpdateBookingDetails(False) Then
                            If IfNull(oGTRS.LastErrorMessage, "").Equals(GTRSService.DefaultErrorMessages.NoBookingDetailsYet) Then
                                MsgBox(GTRSService.DefaultErrorMessages.NoBookingDetailsYet, MsgBoxStyle.Exclamation, GetAppName)
                            Else
                                MsgBox("Get Travel Request Update failed." & IIf(IfNull(oGTRS.LastErrorMessage, "").Length > 0, IfNull(oGTRS.LastErrorMessage, ""), ""), MsgBoxStyle.Critical, GetAppName)
                            End If
                        Else
                            LoadSub_3BookingDetails()
                            tabDetails.SelectedTabPage = LayoutControlGroup_BookingDetails
                            MsgBox("Update successful.", MsgBoxStyle.Information, GetAppName)
                        End If
                    Else
                        MsgBox("Not applicable because this is not booked with GTravel.", MsgBoxStyle.Exclamation, GetAppName)
                    End If
                End If

            Case "CANCEL_TRAVEL_REQUEST"
                If oGTRSControl.BookedWithGTravel Then
                    If BRECORDUPDATEDs Then
                        If MsgBox("Would you like to save the changes first?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                            If Not isValidForCreateTravelRequest() Then
                                Exit Sub
                            End If

                            SaveData()
                        Else
                            Exit Sub
                        End If
                    End If

                    If BookingStatus.Booked Then
                        If MsgBox("This Travel Request is already booked by GTravel." & vbNewLine & vbNewLine & "Are you want to cancel this Travel Request? Continuing will delete the created booking information.", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                    Else
                        If MsgBox("This will cancel the booking request from GTravel." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                    End If

                    If CancelTravelRequest() Then
                        blList.RefreshData()
                        RefreshData()
                    End If

                End If

            Case "ServiceUnavailable"

            Case "CancelData"
                'blList.RefreshData()
                RefreshData()

            Case "REFRESH"
                blList.RefreshData()

            Case "PREVIEWREPORT"
                Dim rpt As New rptTravel_GTRSClass(strID, oGTRSControl.BookedWithGTravel)
                rpt.showPreview()

            Case "LOADFROMPLANNINGEVENT" '<!-- added by tony20190812 : added loading of details from Planning Event
                Dim f As New frmAddFromPlanningEvent

                If IsNothing(dtPlanningEvent) Then SetupPlanningEventLookupEdit()

                f.PlanningEventDataSource = dtPlanningEvent

                'f.LoadPlanningEvent(param(1))
                f.cboPlanningEvent.EditValue = param(1)
                f.LoadPlanningEvent(f.cboPlanningEvent.EditValue)
                'f.ShowDialog()

                'If Not f.AddIsClicked Then
                '    Exit Sub
                'Else
                '    AddFromPlanningEventForm(f)
                'End If
                LoadSub_2PassengerDetails(True)
                AddFromPlanningEventForm(f)
                'end tony -->
        End Select
    End Sub

    Private Sub SetTravelRequestIsUpdated()
        If oGTRSControl.BookedWithGTravel Then
            oGTRSControl.ExecCustomFunction(New Object() {"ENABLE_SEND_TRAVEL_REQUEST_UPDATES"})
        End If
    End Sub
#End Region

#Region "GTRS"
    ''' <summary>
    ''' Sends Travel Request to GTRS Service via CreateTravelRequest Method
    ''' </summary>
    ''' <returns>Boolean : if tracvel request is successfully created</returns>
    ''' <remarks>Note: This method already returns an error message if method fails</remarks>
    Private Function CreateTravelRequest() As Boolean
        Dim bSuccess As Boolean = False
        Dim cNewTravelRequestID As String = ""
        Dim otravelRequest As New MPS4.GTRSServiceReference.travelRequest

        Dim oTransactionLogInfo As TransactionLogInfo

        modGTRS.LogProcess("Sending Travel Request...")
        With otravelRequest
            modGTRS.LogProcess("  Vessel:" & .vesselName)
            modGTRS.LogProcess("  Port:" & .portName)
            modGTRS.LogProcess("  ETAE:" & .etae)
            modGTRS.LogProcess("  ETAL:" & .etal)
            modGTRS.LogProcess("  ETD:" & .etd)
            modGTRS.LogProcess("  ClientID:" & .clientID)
            modGTRS.LogProcess("  UserID:" & .userID)
            oTransactionLogInfo = New TransactionLogInfo(TransactionType.Send, "CreateTravelRequest", FormName, strID, "Send/Create Travel Request to GTravel", "Vessel : " & cboVessel.Text & vbNewLine & _
                                                                                                                "Port : " & cboPort.Text & vbNewLine & _
                                                                                                                "ETD:" & txtETD.Text & vbNewLine & _
                                                                                                                "ETAE:" & txtETAE.Text & vbNewLine & _
                                                                                                                "ETAL:" & txtETAL.Text)
        End With

        Try
            With otravelRequest
                .vesselName = cboVessel.Text
                .portName = cboPort.Text
                .currentDate = ChangeToGTRSDate(System.DateTime.Now())
                .dueDate = ChangeToGTRSDate(txtDueDate.EditValue)
                .leadTime = cboLeadTime.EditValue
                .etae = ChangeToGTRSDate(txtETAE.EditValue)
                .etal = ChangeToGTRSDate(txtETAL.EditValue)
                .etd = ChangeToGTRSDate(txtETD.EditValue)
                .remarks = txtRemarks.Text
                .transactionReference = txtRefNo.Text
                .allocation1 = ""
                .allocation2 = ""
                .allocation3 = ""
                .nearestAirport = cboNearestAirport.Text
                .clientID = oGTRS.ClientInfo.clientID
                .userID = oGTRS.ClientInfo.userID
                .departmentID = oGTRS.ClientInfo.departmentID
            End With

            cNewTravelRequestID = oGTRS.CreateTravelRequest(otravelRequest)
            If IfNull(cNewTravelRequestID, "").Length > 0 Then
                Try
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Send Travel Request to GTravel", 0, System.Environment.MachineName, "PKey = '" & strID & "'", FormName) 'neil
                    If MPSDB.RunSql("UPDATE dbo.tblTravelBooking SET TravelRequestID = '" & cNewTravelRequestID & "', BookingStatus = '" & TravelBookingStatus.InProgress.Key & "', isSentToGTravel = 1, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & strID & "'") Then
                        bSuccess = True
                        LogGTRSTransaction(oTransactionLogInfo)
                    Else
                        LogErrors("<Travel_GTRS><CreateTravelRequest><Save In Database><" & strID & ">" & MPSDB.GetLastErrorMessage)
                        MsgBox("Record failed to save in the database. Reverting the sent request.")
                        modGTRS.LogProcess("Status: FAILED [" & MPSDB.GetLastErrorMessage & "]")
                        LogGTRSTransaction(oTransactionLogInfo, MPSDB.GetLastErrorMessage)
                    End If
                Catch ex As Exception
                    LogErrors("<Travel_GTRS><CreateTravelRequest><Save In Database><" & strID & ">" & ex.Message)
                    MsgBox("Record failed to save in the database. Reverting the sent request.")
                    modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
                    LogGTRSTransaction(oTransactionLogInfo, ex.Message)
                End Try

                If bSuccess Then
                    RemoveEditListener(txtTravelRequestID, False)
                    Me.TravelRequestID = cNewTravelRequestID
                    If bAddMode Or isEditdable Then
                        AddEditListener(txtTravelRequestID)
                    End If
                Else
                    CancelTravelRequest()
                End If
            End If

        Catch ex As Exception
            LogErrors("<Travel_GTRS><CreateTravelRequest><Send Travel Request><" & strID & ">" & ex.Message)
            MsgBox("Failed to Send Travel Request to GTravel." & vbNewLine & "Error: " & ex.Message)
            modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
            LogGTRSTransaction(oTransactionLogInfo, ex.Message)
        End Try

        Return bSuccess
    End Function


    ''' <summary>
    ''' Updates Travel Request to GTRS Service via CreateTravelRequest Method
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Function UpdateTravelRequest() As Boolean
        Dim bSuccess As Boolean = False
        Dim otravelRequestUpdate As New MPS4.GTRSServiceReference.travelRequestUpdate

        Dim oTransactionLogInfo As New TransactionLogInfo(TransactionType.Send, "UpdateTravelRequest", FormName, strID, "Send Travel Request Update to GTravel", "Vessel : " & cboVessel.Text & vbNewLine & _
                                                                                                                 "Port : " & cboPort.Text & vbNewLine & _
                                                                                                                 "ETD:" & txtETD.Text & vbNewLine & _
                                                                                                                 "ETAE:" & txtETAE.Text & vbNewLine & _
                                                                                                                 "ETAL:" & txtETAL.Text)
                                                                                                                 
        Try
            With otravelRequestUpdate
                .vesselName = cboVessel.Text
                .portName = cboPort.Text
                .currentDate = ChangeToGTRSDate(System.DateTime.Now())
                .dueDate = ChangeToGTRSDate(txtDueDate.EditValue)
                .leadTime = cboLeadTime.EditValue
                .etae = ChangeToGTRSDate(txtETAE.EditValue)
                .etal = ChangeToGTRSDate(txtETAL.EditValue)
                .etd = ChangeToGTRSDate(txtETD.EditValue)
                .remarks = txtRemarks.Text
                .transactionReference = txtRefNo.Text
                .allocation1 = ""
                .allocation2 = ""
                .allocation3 = ""
                .nearestAirport = cboNearestAirport.Text
                .clientID = oGTRS.ClientInfo.clientID
                .userID = oGTRS.ClientInfo.userID
                .departmentID = oGTRS.ClientInfo.departmentID
                .travelRequestID = Me.TravelRequestID
            End With

            bSuccess = oGTRS.UpdateTravelRequest(otravelRequestUpdate)

            If bSuccess Then
                Try
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Send Travel Request Update to GTravel", 0, System.Environment.MachineName, "PKey = '" & strID & "' AND TravelRequestID = '" & Me.TravelRequestID & "'", FormName) 'neil
                    If MPSDB.RunSql("UPDATE dbo.tblTravelBooking SET BookingStatus = '" & TravelBookingStatus.InProgress.Key & "', isSentToGTravel = 1, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & strID & "'") Then
                        bSuccess = True
                        LogGTRSTransaction(oTransactionLogInfo)
                    Else
                        LogErrors("<Travel_GTRS><UpdateTravelRequest><Save In Database><" & strID & ">" & MPSDB.GetLastErrorMessage)
                        MsgBox("Record failed to save in the database.")
                        modGTRS.LogProcess("Status: FAILED [" & MPSDB.GetLastErrorMessage & "]")
                        LogGTRSTransaction(oTransactionLogInfo, MPSDB.GetLastErrorMessage)
                    End If

                Catch ex As Exception
                    LogErrors("<Travel_GTRS><UpdateTravelRequest><Save In Database><" & strID & ">" & ex.Message)
                    MsgBox("Record failed to save in the database.")
                    modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
                    LogGTRSTransaction(oTransactionLogInfo, ex.Message)
                End Try
            End If

        Catch ex As Exception
            LogErrors("<Travel_GTRS><UpdateTravelRequest><Send Travel Request Update><" & strID & " : " & Me.TravelRequestID & ">" & ex.Message)
            MsgBox("Failed to Send Travel Request Update to GTravel." & vbNewLine & "Error: " & ex.Message)
            modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
            LogGTRSTransaction(oTransactionLogInfo, ex.Message)
        End Try


        Return bSuccess


    End Function

    ''' <summary>
    ''' Cancels Travel Request to GTRS Service via CreateTravelRequest Method
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CancelTravelRequest(Optional showMsg As Boolean = True) As Boolean
        Dim ReturnValue As Boolean = False
        Dim bSuccess As Boolean = False

        ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Canceling request from GTravel")

        Dim oTransactionLogInfo As New TransactionLogInfo(TransactionType.Send, "CancelTravelRequest", FormName, strID, "Cancel Travel Request Update to GTravel", "Vessel : " & cboVessel.Text & vbNewLine & _
                                                                                                                 "Port : " & cboPort.Text & vbNewLine & _
                                                                                                                 "ETD:" & txtETD.Text & vbNewLine & _
                                                                                                                 "ETAE:" & txtETAE.Text & vbNewLine & _
                                                                                                                 "ETAL:" & txtETAL.Text)
        Try
            If IfNull(Me.TravelRequestID, "").Length > 0 Then
                bSuccess = oGTRS.CancelTravelRequest(IfNull(Me.TravelRequestID, ""))

                If bSuccess Then
                    ReturnValue = True

                Else
                    If IfNull(oGTRS.LastErrorMessage, "").Length > 0 Then
                        MsgBox(oGTRS.LastErrorMessage, MsgBoxStyle.Critical, GetAppName)
                        ReturnValue = False
                    End If
                End If
            Else
                ReturnValue = True
            End If

            If bSuccess Then
                Try
                    If ClearTravelGTRSLink() Then
                        ReturnValue = True
                        RemoveEditListener(txtTravelRequestID, False)
                        Me.TravelRequestID = ""
                        If bAddMode Or isEditdable Then
                            AddEditListener(txtTravelRequestID)
                        End If
                        LogGTRSTransaction(oTransactionLogInfo)
                    Else
                        LogErrors("<Travel_GTRS><CancelTravelRequest><Save In Database><" & strID & ">" & MPSDB.GetLastErrorMessage)
                        MsgBox("Record failed to save in the database.")
                        modGTRS.LogProcess("Status: FAILED [" & MPSDB.GetLastErrorMessage & "]")
                        LogGTRSTransaction(oTransactionLogInfo, MPSDB.GetLastErrorMessage)
                    End If

                Catch ex As Exception
                    LogErrors("<Travel_GTRS><CancelTravelRequest><Save In Database><" & strID & ">" & ex.Message)
                    MsgBox("Record failed to save in the database.")
                    modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
                    LogGTRSTransaction(oTransactionLogInfo, ex.Message)
                End Try
            End If

        Catch ex As Exception
            LogErrors("<Travel_GTRS><CancelTravelRequest><Cancel Travel Request><" & strID & " : " & Me.TravelRequestID & ">" & ex.Message)
            MsgBox("Failed to Cancel Travel Request from GTravel." & vbNewLine & "Error: " & ex.Message)
            modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
            LogGTRSTransaction(oTransactionLogInfo, ex.Message)
        End Try
        CloseCustomLoadScreen()
        Return ReturnValue
    End Function

    Private Function ClearTravelGTRSLink() As Boolean
        Dim sqls As New ArrayList
        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Cancel Travel Request from GTravel", 0, System.Environment.MachineName, "PKey = '" & strID & "' AND TravelRequestID = '" & Me.TravelRequestID & "'", FormName) 'neil

        sqls.Add("UPDATE dbo.tblTravelBooking SET BookingStatus = '" & TravelBookingStatus.Canceled.Key & "', isSentToGTravel = 0, TravelRequestID = NULL, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE PKey = '" & strID & "'")
        sqls.Add("UPDATE dbo.tblTravelBookingCrew SET isSentToGTravel = 0, PassengerID = NULL, DateUpdated = getdate(), LastUpdatedBy = '" & LastUpdatedBy & "' WHERE FKeyTravelBooking = '" & strID & "'")

        Return MPSDB.RunSqls(sqls)
    End Function

    Private Sub CancelBookedData()
        '<!--added by tony20180922 : Log Deletion
        oLogDeletion.Init()

        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
            FormName, _
            "Crewing", _
            "tbltravelbookingdetail", _
            "FKeyTravelBooking IN ('" & strID & "')", _
            "<< Delete Crew Data - " & FormName & " - Cancel Travel Booking >>", _
            LogDeletion.DeletionType.Manual, _
            "Manually Deleted in <" & FormName & "- Cancel Travel Booking>", _
            GetUserName())
        '-->
        If MPSDB.RunSql("DELETE FROM dbo.tbltravelbookingdetail WHERE FKeyTravelBooking = '" & strID & "'") Then
            oLogDeletion.AddLogEntryToDatabase()
        End If
    End Sub

    Private Function GetGTRSTravelRequest_UpdateBookingDetails(Optional ShowMessage As Boolean = True) As Boolean
        If oGTRS.MyStatus = GTRSServiceStatus.Okay And oGTRSControl.BookedWithGTravel Then
            Dim ReturnValue As Boolean = False
            Dim oTransactionLogInfo As New TransactionLogInfo(TransactionType.Get, "ViewTravelRequest", FormName, strID, "Get Travel Request Details from GTravel", "Vessel : " & cboVessel.Text & vbNewLine & _
                                                                                                                     "Port : " & cboPort.Text & vbNewLine & _
                                                                                                                     "ETD:" & txtETD.Text & vbNewLine & _
                                                                                                                     "ETAE:" & txtETAE.Text & vbNewLine & _
                                                                                                                     "ETAL:" & txtETAL.Text)

            ReturnValue = oGTRS.GetTravelRequestDetails(strID, Me.TravelRequestID, ShowMessage)
            LogGTRSTransaction(oTransactionLogInfo, oGTRS.LastErrorMessage)
            Return ReturnValue
        Else
            Return True
        End If
    End Function
#End Region

#Region "Passenger Grid"
    ''' <summary>
    ''' Show or hides the Remove Passenger (Delete) button on Passenger Grid View
    ''' </summary>
    ''' <param name="enable"></param>
    ''' <remarks></remarks>
    Private Sub EnableRemovePassenger(Optional enable As Boolean = True)

        If Not HasDeletePermission Then Exit Sub

        For i As Integer = 0 To PassengerView.Columns.Count - 1
            If PassengerView.Columns(i).Name.Equals("colPRemove") Then
                PassengerView.Columns(i).Visible = enable
                Exit For
            End If
        Next

    End Sub

    Private Sub ClearPassengerList()
        Try
            PassengerView.SelectRows(0, PassengerView.RowCount - 1)
            PassengerView.DeleteSelectedRows()
        Catch ex As Exception
            LogErrors("<ClearPassengerList>" & "Failed to clear PassengerView rows")
        End Try

    End Sub

    Private Sub AddCrewPassenger()
        If IfNull(cboAddCrew.EditValue, "").Length = 0 Then Exit Sub

        If BookingStatus.Completed Then
            MsgBox("You cannot add a new passenger to this travel booking because this is already marked as Completed.", MsgBoxStyle.Information)
            cboAddCrew.EditValue = ""
            Exit Sub
        End If

        If BookingStatus.Booked Then
            If MsgBox("This travel booking is already tagged as booked. Are you sure you want to add another passenger?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                cboAddCrew.EditValue = ""
                Exit Sub
            End If
        End If

        If IfNull(cboAddCrew.EditValue, "").Length = 0 Then
            Exit Sub
        End If

        'LOCATE CREW IN PASSENGER LIST
        Dim dv As New DataView(TryCast(PassengerGrid.DataSource, DataTable))
        dv.RowFilter = "FKeyCrew = '" & cboAddCrew.EditValue & "'"
        If dv.Count > 0 Then
            MsgBox("Cannot add crew " & cboAddCrew.Text & " because he is already in the passenger list.", MsgBoxStyle.Exclamation, "Add Passenger")
            cboAddCrew.EditValue = ""
            Exit Sub
        ElseIf MsgBox("Continune add " & cboAddCrew.Text & " in the passenger list?" & _
                  vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            cboAddCrew.EditValue = ""
            Exit Sub


        End If

        'START ADDING
        header.Focus()

        Dim srcRow As DataRow = cboAddCrew.Properties.View.GetFocusedDataRow()

        Dim destDt As DataTable = TryCast(PassengerView.GridControl.DataSource, DataTable)
        Dim newRow As DataRow = destDt.NewRow

        With newRow
            .Item("Edited") = 1
            .Item("HasFlightDetails") = 0
            .Item("ID") = 0
            .Item("PKey") = DBNull.Value
            .Item("FKeyTravelBooking") = strID
            .Item("PassengerID") = DBNull.Value
            .Item("FKeyCrew") = srcRow("FKeyCrew")
            .Item("CoIDNo") = srcRow("CoIDNo")
            .Item("CrewName") = srcRow("CrewName")
            .Item("LName") = srcRow("LName")
            .Item("FName") = srcRow("FName")
            .Item("SexCode") = srcRow("SexCode")
            .Item("POB") = srcRow("POB")
            .Item("FKeyNat") = srcRow("FKeyNationality")
            .Item("Nationality") = srcRow("Nationality")
            .Item("FKeyRank") = srcRow("FKeyRankCode")
            .Item("RankName") = srcRow("RankName")
            .Item("RankAbbrv") = DBNull.Value
            .Item("FKeyAgent") = srcRow("FKeyAgentCode")
            .Item("AgentName") = srcRow("AgentName")
            .Item("PPNo") = srcRow("PPNo")
            .Item("PPIssueDate") = srcRow("PPIssueDate")
            .Item("PPExpiryDate") = srcRow("PPExpiryDate")
            .Item("PPPlaceIssue") = srcRow("PPPlaceIssue")
            .Item("SBNo") = srcRow("SBNo")
            .Item("SBIssueDate") = srcRow("SBIssueDate")
            .Item("SBExpiryDate") = srcRow("SBExpiryDate")
            .Item("SBPlaceIssue") = srcRow("SBPlaceIssue")
            .Item("Phone") = srcRow("Phone")
            .Item("Celphone") = srcRow("Celphone")
            .Item("Email") = srcRow("Email")
            .Item("FKeyNearestAirport") = cboNearestAirport.EditValue
            .Item("NearestAirportName") = cboNearestAirport.Text
            .Item("FKeyAlternativeAirport") = srcRow("FKeyAlternateAirport")
            .Item("AlternativeAirportName") = srcRow("AlternateAirportName")
            .Item("ETAE") = txtETAE.EditValue
            .Item("ETAL") = txtETAL.EditValue
            .Item("ETD") = txtETD.EditValue
            .Item("FrequentFlyerMembership") = DBNull.Value
            .Item("FrequentFlyerNumber") = DBNull.Value
            .Item("Visa") = DBNull.Value
            .Item("RequestType") = cboRequestType.EditValue
            .Item("LastUpdatedBy") = DBNull.Value
            .Item("DateCreated") = DBNull.Value
            .Item("DateUpdated") = DBNull.Value
            .Item("isSentToGTravel") = 0

        End With

        destDt.Rows.Add(newRow)

        cboAddCrew.EditValue = ""
        PassengerView.Appearance.FocusedRow.BackColor = EDITED_COLOR
        PassengerGrid.DataSource = destDt
        Dim _focRowhandle As Integer = -1
        _focRowhandle = PassengerView.LocateByValue("FKeyCrew", srcRow("FKeyCrew"))
        If _focRowhandle >= 0 Then
            PassengerView.FocusedRowHandle = _focRowhandle
        End If

        SetTravelRequestIsUpdated()
        BRECORDUPDATEDs = True

    End Sub

    Private Sub AddCrewPassengerFromPlanningEvent(planningEventCrewsDt As DataTable, CrewIDField As String)

        Dim crewname As String = "", crewid As String = "", crewlname As String = "", crewfname As String = "", crewmname As String = ""
        Dim row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

        Dim destDt As DataTable = TryCast(PassengerGrid.DataSource, DataTable)
        Dim newRow As DataRow
        Dim dvSelectedCrew As DataView = New DataView(dtCrews)
        For Each srcrow As DataRow In planningEventCrewsDt.Rows
            newRow = destDt.NewRow

            dvSelectedCrew.RowFilter = "FKeyCrew = '" & srcrow("CrewID") & "'"

            With newRow
                .Item("Edited") = 1
                .Item("HasFlightDetails") = 0
                .Item("ID") = 0
                .Item("PKey") = DBNull.Value
                .Item("FKeyTravelBooking") = strID
                .Item("PassengerID") = DBNull.Value
                .Item("FKeyCrew") = srcrow("CrewID")
                .Item("FKeyRank") = srcrow("FKeyRank")
                If IfNull(srcrow("FKeyRank"), "").Length > 0 Then
                    If dtRanks.Select("PKey = '" & srcrow("FKeyRank") & "'").Count > 0 Then
                        .Item("RankName") = dtRanks.Select("PKey = '" & srcrow("FKeyRank") & "'")(0).Item("Name")
                        .Item("RankAbbrv") = dtRanks.Select("PKey = '" & srcrow("FKeyRank") & "'")(0).Item("Abbrv")
                    End If
                End If

                If dvSelectedCrew.Count > 0 Then
                    .Item("CoIDNo") = dvSelectedCrew(0)("CoIDNo")
                    .Item("CrewName") = dvSelectedCrew(0)("CrewName")
                    .Item("LName") = dvSelectedCrew(0)("LName")
                    .Item("FName") = dvSelectedCrew(0)("FName")
                    .Item("SexCode") = dvSelectedCrew(0)("SexCode")
                    .Item("POB") = dvSelectedCrew(0)("POB")
                    .Item("FKeyNat") = dvSelectedCrew(0)("FKeyNationality")
                    .Item("Nationality") = dvSelectedCrew(0)("Nationality")
                    .Item("FKeyAgent") = dvSelectedCrew(0)("FKeyAgentCode")
                    .Item("AgentName") = dvSelectedCrew(0)("AgentName")
                    .Item("PPNo") = dvSelectedCrew(0)("PPNo")
                    .Item("PPIssueDate") = dvSelectedCrew(0)("PPIssueDate")
                    .Item("PPExpiryDate") = dvSelectedCrew(0)("PPExpiryDate")
                    .Item("PPPlaceIssue") = dvSelectedCrew(0)("PPPlaceIssue")
                    .Item("SBNo") = dvSelectedCrew(0)("SBNo")
                    .Item("SBIssueDate") = dvSelectedCrew(0)("SBIssueDate")
                    .Item("SBExpiryDate") = dvSelectedCrew(0)("SBExpiryDate")
                    .Item("SBPlaceIssue") = dvSelectedCrew(0)("SBPlaceIssue")
                    .Item("Phone") = dvSelectedCrew(0)("Phone")
                    .Item("Celphone") = dvSelectedCrew(0)("Celphone")
                    .Item("Email") = dvSelectedCrew(0)("Email")
                    .Item("FKeyAlternativeAirport") = dvSelectedCrew(0)("FKeyAlternateAirport")
                    .Item("AlternativeAirportName") = dvSelectedCrew(0)("AlternateAirportName")
                End If

                .Item("FKeyNearestAirport") = cboNearestAirport.EditValue
                .Item("NearestAirportName") = cboNearestAirport.Text
                .Item("ETAE") = txtETAE.EditValue
                .Item("ETAL") = txtETAL.EditValue
                .Item("ETD") = txtETD.EditValue
                .Item("FrequentFlyerMembership") = DBNull.Value
                .Item("FrequentFlyerNumber") = DBNull.Value
                .Item("Visa") = DBNull.Value
                .Item("RequestType") = cboRequestType.EditValue
                .Item("LastUpdatedBy") = DBNull.Value
                .Item("DateCreated") = DBNull.Value
                .Item("DateUpdated") = DBNull.Value
                .Item("isSentToGTravel") = 0

            End With

            destDt.Rows.Add(newRow)

        Next

        PassengerView.GridControl.DataSource = destDt
        PassengerView.GridControl.RefreshDataSource()
        PassengerView.Appearance.FocusedRow.BackColor = EDITED_COLOR

    End Sub

    Private Function GetRemovePassengerValidationMessage() As String
        Dim ReturnValue As String = ""
        '<!-- edited by tony20181016 - produces warning: Function 'GetRemovePassengerValidationMessage' doesn't return a value on all code paths.
        'ReturnValue = IIf(isPassengerHasBooking(PassengerGrid.FocusedRecord), IIf(oGTRSControl.BookedWithGTravel, "Crew already has a booking made by GTravel.", "Crew is already booked.") & vbNewLine, vbNewLine)
        Return IIf(isPassengerHasBooking(PassengerView.FocusedRowHandle), IIf(oGTRSControl.BookedWithGTravel, "Crew already has a booking made by GTravel.", "Crew is already booked.") & vbNewLine, vbNewLine)
        '-->
    End Function

    Private Function isPassengerHasBooking(PassengerFocusedRowIndex As String) As Boolean
        Dim ReturnValue As Boolean = False
        If oGTRSControl.BookedWithGTravel Then
            Dim cPassengerID As String = IfNull(PassengerView.GetRowCellValue(PassengerFocusedRowIndex, "PassengerID"), "").ToString

            If IfNull(cPassengerID, "").Equals("") Then
                ReturnValue = False

            Else
                Dim RowHandle As Integer = -1
                Dim Col As DevExpress.XtraGrid.Columns.GridColumn = BookingDetailsView.Columns("PassengerID")
                RowHandle = BookingDetailsView.LocateByValue(0, Col, cPassengerID)
                ReturnValue = (RowHandle >= 0)
            End If

        Else    'Not Booked with GTravel
            Dim cFKeyCrew As String = IfNull(PassengerView.GetRowCellValue(PassengerFocusedRowIndex, "FKeyCrew"), "").ToString

            If IfNull(cFKeyCrew, "").Equals("") Then
                ReturnValue = False

            Else
                Dim RowHandle As Integer = -1
                Dim Col As DevExpress.XtraGrid.Columns.GridColumn = BookingDetailsView.Columns("FKeyCrew")
                RowHandle = BookingDetailsView.LocateByValue(0, Col, cFKeyCrew)
                ReturnValue = (RowHandle >= 0)
            End If
        End If

        Return ReturnValue

    End Function

#Region "Add Crew"

    Private Sub btnAddCrew_Click(sender As Object, e As System.EventArgs) Handles btnAddCrew.Click
        AddCrewPassenger()
    End Sub

    Private Sub cboAddCrew_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboAddCrew.ButtonClick
        If isEditdable Or bAddMode Then
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus Then
                AddCrewPassenger()

            ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
                cboAddCrew.EditValue = ""
            End If
        End If
    End Sub

#End Region
#End Region

#Region "Control Appearances"
    ''' <summary>
    ''' Updates Mark as Completed button ForeColor
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetCompletedCheckColor()
        If BookingStatus.Completed Then
            btnCompleted.ForeColor = System.Drawing.Color.Green
        Else
            btnCompleted.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub SetBookingStatusColorProperty()

        Try
            If Not cboBookingStatus.EditValue Is Nothing And cboBookingStatus.EditValue.Equals(TravelBookingStatus.Booked.Key) Then
                cboBookingStatus.BackColor = System.Drawing.Color.ForestGreen
                cboBookingStatus.ForeColor = System.Drawing.Color.White
            ElseIf Not cboBookingStatus.EditValue Is Nothing And cboBookingStatus.EditValue.Equals(TravelBookingStatus.Canceled.Key) Then
                cboBookingStatus.BackColor = System.Drawing.Color.Firebrick
                cboBookingStatus.ForeColor = System.Drawing.Color.White
            Else
                cboBookingStatus.BackColor = System.Drawing.Color.White
                cboBookingStatus.ForeColor = System.Drawing.Color.Black
            End If

        Catch '<!-- edited by tony20181016 - produces warning: Unused local variable: 'ex'.
            '--> ex As Exception
            cboBookingStatus.BackColor = System.Drawing.Color.White
        End Try

    End Sub
#End Region

#Region "Crew DataSource For Manual Booking"

#End Region

#Region "Manually-Created Booking"
    Private Function CreateManualBookingCrewSrc() As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim ReturnValue As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

        ReturnValue.DataSource = GetManualCrewDataSrc()
        ReturnValue.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FKeyCrew", "PKey", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), _
                                                                                             New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CrewName", "CrewName"), _
                                                                                             New DevExpress.XtraEditors.Controls.LookUpColumnInfo("LName", "LName", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), _
                                                                                             New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FName", "FName", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), _
                                                                                             New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MName", "MName", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        ReturnValue.DisplayMember = "CrewName"
        ReturnValue.ValueMember = "CrewName"
        ReturnValue.NullText = ""
        ReturnValue.ShowHeader = False
        ReturnValue.ShowFooter = False

        AddHandler ReturnValue.EditValueChanged, AddressOf CustomLookUpEdit_EditValueChanged

        Return ReturnValue
    End Function

    Private Function GetManualCrewDataSrc() As DataTable
        Dim dt As New DataTable
        Dim col As New DataColumn
        col.ColumnName = "FKeyCrew"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "CrewName"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "LName"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "FName"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)
        col = New DataColumn
        col.ColumnName = "MName"
        col.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(col)

        For i As Integer = 0 To PassengerView.RowCount - 1
            dt.Rows.Add(New Object() {PassengerView.GetRowCellValue(i, "FKeyCrew"), _
                                      PassengerView.GetRowCellValue(i, "CrewName"), _
                                      PassengerView.GetRowCellValue(i, "LName"), _
                                      PassengerView.GetRowCellValue(i, "FName"), _
                                      PassengerView.GetRowCellValue(i, "MName")})
        Next

        Return dt
    End Function

    Private Function CreateGTRSBookingCrewSrc() As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Return New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    End Function
#End Region


    Private Sub CustomLookUpEdit_EditValueChanged(sender As Object, e As System.EventArgs)
        Dim rep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        rep = TryCast(sender, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)

        Try

            If row Is Nothing Then
                BookingDetailsView.SetRowCellValue(BookingDetailsView.FocusedRowHandle, "FKeyCrew", Nothing)
            Else

                BookingDetailsView.SetRowCellValue(BookingDetailsView.FocusedRowHandle, "FKeyCrew", row.Item("FKeyCrew"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


#Region "Booking Status Lookup"
    Private Function LookupStatusName(StatusKey As String) As String
        Dim dv As DataView = New DataView(dtBookingStatus)
        dv.RowFilter = "PKey = '" & StatusKey & "'"
        If dv.Count > 0 Then
            Return dv(0).Item("Name")
        Else
            Return ""
        End If
    End Function
#End Region

    Private Sub repBDStatus_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repBDStatus.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repBDStatus_EditValueChanged(sender As Object, e As System.EventArgs) Handles repBDStatus.EditValueChanged
        'BookingDetailsView.UpdateCurrentRow()
        'Dim gcol As DevExpress.XtraGrid.Columns.GridColumn = BookingDetailsView.Columns("CrewName")
        BookingDetailsView.FocusedColumn = BookingDetailsView.Columns("CrewName")
    End Sub

    Private Sub repBDStatus_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles repBDStatus.EditValueChanging
        If isEditdable Or bAddMode Then
            If e.NewValue.Equals(BookedOrCanceled.Canceled) Then
                If MsgBox("You are setting this booking detail as 'Canceled'." & Chr(13) & Chr(13) & "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub btnAddFromPlanningEvent_Click(sender As System.Object, e As System.EventArgs) Handles btnAddFromPlanningEvent.Click
        If bAddMode Then
            If IfNull(txtCurrentDate.EditValue, "").Length > 0 And _
                (IfNull(cboRequestType.EditValue, "").Length > 0 Or IfNull(cboVessel.EditValue, "").Length > 0 Or IfNull(txtRefNo.EditValue, "").Length > 0 Or IfNull(cboNearestAirport.EditValue, "").Length > 0 Or IfNull(txtETD.EditValue, "").Length > 0 Or IfNull(txtETAE.EditValue, "").Length > 0 Or IfNull(txtETAL.EditValue, "").Length > 0 Or IfNull(cboPort.EditValue, "").Length > 0 Or HasPassengers()) Then

                MsgBox("Unable to select load planning event details. Please clear out details or add a new record.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If


            Dim f As New frmAddFromPlanningEvent

            If IsNothing(dtPlanningEvent) Then SetupPlanningEventLookupEdit()

            f.PlanningEventDataSource = dtPlanningEvent

            f.ShowDialog()
            If Not f.AddIsClicked Then
                Exit Sub
            Else
                '<!-- edited by tony20190812
                'Me.txtCurrentDate.Text = System.DateTime.Now
                'Me.cboFKeyPlanningEvent.EditValue = f.cboPlanningEvent.EditValue
                'ShowPlanningEventDetail()
                'Me.cboLeadTime.EditValue = 0
                'If IfNull(f.txtPlannedDateSOn.EditValue, "").Length > 0 Then
                '    Me.txtTravelDate.EditValue = CDate(f.txtPlannedDateSOn.EditValue)
                'End If

                'Me.cboRequestType.EditValue = PassengerRequestType.Embark.Key

                'If IfNull(f.txtPlannedDateSOn.EditValue, "").Length > 0 Then
                '    Me.cboVessel.EditValue = f.VesselCode
                'End If

                'Me.txtETD.EditValue = Format(CDate(f.txtPlannedDateSOn.EditValue), "dd-MMM-yyyy 00:00 tt")  'Format(f.txtPlannedDateSOn.EditValue, "dd-MMM-yyyy 00:00 tt")
                'Me.txtETAE.EditValue = Me.txtETD.EditValue
                'Me.txtETAL.EditValue = Me.txtETD.EditValue

                'If IfNull(f.PlaceSOnCode, "").Length > 0 Then
                '    Me.cboPort.EditValue = f.PlaceSOnCode
                'End If

                'AddCrewPassengerFromPlanningEvent(TryCast(f.MainGrid.DataSource, DataTable), "CrewID")

                'DisableControlsPlanningEventSelected()
                'AllowAddFromPlanningEvent(False)
                AddFromPlanningEventForm(f)
                'end tony -->
            End If
        End If
    End Sub

    '<!-- edited by tony20190812
    Private Sub AddFromPlanningEventForm(ByRef f As frmAddFromPlanningEvent)
        Me.txtCurrentDate.Text = System.DateTime.Now
        Me.cboFKeyPlanningEvent.EditValue = f.cboPlanningEvent.EditValue
        ShowPlanningEventDetail()
        Me.cboLeadTime.EditValue = 0
        If IfNull(f.txtPlannedDateSOn.EditValue, "").Length > 0 Then
            Me.txtTravelDate.EditValue = CDate(f.txtPlannedDateSOn.EditValue)
        End If

        Me.cboRequestType.EditValue = PassengerRequestType.Embark.Key

        If IfNull(f.txtPlannedDateSOn.EditValue, "").Length > 0 Then
            Me.cboVessel.EditValue = f.VesselCode
        End If

        Me.txtETD.EditValue = Format(CDate(f.txtPlannedDateSOn.EditValue), "dd-MMM-yyyy 00:00 tt")  'Format(f.txtPlannedDateSOn.EditValue, "dd-MMM-yyyy 00:00 tt")
        Me.txtETAE.EditValue = Me.txtETD.EditValue
        Me.txtETAL.EditValue = Me.txtETD.EditValue

        If IfNull(f.PlaceSOnCode, "").Length > 0 Then
            Me.cboPort.EditValue = f.PlaceSOnCode
        End If

        AddCrewPassengerFromPlanningEvent(TryCast(f.MainGrid.DataSource, DataTable), "CrewID")

        DisableControlsPlanningEventSelected()
        AllowAddFromPlanningEvent(False)
    End Sub
    'end tony -->

    ''' <summary>
    ''' Toggles if to show Planning Event Name label and Add Planning Event button
    ''' </summary>
    ''' <param name="show"></param>
    ''' <remarks></remarks>
    Private Sub ShowPlanningEventDetail(Optional show As Boolean = True)
        lcgPlanningEvent.Visibility = IIf(show, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
        cboFKeyPlanningEvent.ReadOnly = True
    End Sub

    Private Sub DisableControlsPlanningEventSelected()
        cboRequestType.ReadOnly = True
        cboVessel.ReadOnly = True
        'cboPort.ReadOnly = True
        MakeReadOnlyListener(LayoutControlGroup_Passenger)
        EnableAddPassengerGroup(False)
        btnAddFromPlanningEvent.Enabled = False
    End Sub


#Region "Completed"

    Private Sub SetTravelCompletedButton(Completed As Boolean)
        If Completed Then
            btnCompleted.Text = "Completed"
            btnCompleted.Appearance.ForeColor = System.Drawing.Color.Green
            Me.btnCompleted.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)

        Else
            btnCompleted.Text = "Mark as Completed"
            btnCompleted.Appearance.ForeColor = System.Drawing.Color.Black
            Me.btnCompleted.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        End If
    End Sub

    Private Sub btnCompleted_Click(sender As Object, e As System.EventArgs) Handles btnCompleted.Click
        If Not isEditdable Then Exit Sub
        If Not BookingStatus.Completed Then 'IF BEING SET AS COMPLETED
            'If Not BookingStatus.Booked Then
            '    If MsgBox("This travel request is not yet booked." & vbNewLine & "Do you want to continue to mark this as Completed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '        Exit Sub
            '    End If
            'End If

            If MsgBox("Are you sure you want to mark this travel booking as 'Completed'?" & vbNewLine & vbNewLine & "Marking this Travel Request/Booking as 'Completed' will no longer allow any editing in the future." & vbNewLine & vbNewLine & "Continue?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                BookingStatus.Completed = True
                Me.txtCurrentDate.Tag = 1
                SaveData()
            Else
                Exit Sub
            End If

        Else 'IF BEING AS NOT COMPLETED
            If MsgBox("Are you sure you want to unmark this travel booking as completed?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                BookingStatus.Completed = False
                Me.txtCurrentDate.Tag = 1
                SaveData()
            Else
                Exit Sub
            End If
        End If
    End Sub

    ''' <summary>
    ''' Enables or disables Mark as Completed button 
    ''' Changes the font color to Green if Completed, otherwise black
    ''' </summary>
    ''' <param name="enable"></param>
    ''' <remarks></remarks>
    Private Sub EnableMarkAsCompleted(enable As Boolean)
        btnCompleted.Enabled = enable

        If BookingStatus.Completed Then
            btnCompleted.ForeColor = System.Drawing.Color.Green
        Else
            btnCompleted.ForeColor = System.Drawing.Color.Black
        End If
    End Sub
#End Region

    Private Sub ShowCrewTravelDetailsInPopup()
        If PassengerView.FocusedRowHandle >= 0 Then
            If PassengerView.GetFocusedRowCellValue("HasFlightDetails") = True Then

                Dim f As New frmPopupTravelDetails(PassengerView.GetFocusedRowCellValue("CrewName"), GetGridWithSelection(BookingDetailsGrid))
                f.ShowDialog()
            End If

        End If
    End Sub

#Region "Clone Grid"
    Private Function GetTableOfSelectedRows(ByVal view As GridView) As DataTable

        Dim resultTable As New DataTable

        If TypeOf view.DataSource Is DataView Then

            Dim sourceTable As DataTable = CType(view.DataSource, DataView).Table

            resultTable = sourceTable.Clone()

            Dim rowHandle As Integer

            For Each rowHandle In view.GetSelectedRows()

                Dim row As DataRow = view.GetDataRow(rowHandle)

                resultTable.Rows.Add(row.ItemArray)

            Next rowHandle

            resultTable.AcceptChanges()

        End If

        Return resultTable

    End Function

    Private Function GetTableOfSelectedCrew(ByVal view As GridView) As DataTable

        Dim resultTable As New DataTable

        If TypeOf view.DataSource Is DataView Then

            Dim copyTable As DataTable = CType(view.DataSource, DataView).Table
            Dim dv As New DataView(CType(view.DataSource, DataView).Table)

            If IfNull(PassengerView.GetFocusedRowCellValue("FKeyCrew"), "").Length > 0 Then
                dv.RowFilter = "FKeyCrew = '" & IfNull(PassengerView.GetFocusedRowCellValue("FKeyCrew"), "") & "'"
                If dv.Count > 0 Then
                    Return dv.ToTable
                End If
            End If

            If IfNull(PassengerView.GetFocusedRowCellValue("PassengerID"), "").Length > 0 Then
                dv.RowFilter = "PassengerID = '" & IfNull(PassengerView.GetFocusedRowCellValue("PassengerID"), "") & "'"
                If dv.Count > 0 Then
                    Return dv.ToTable
                End If
            End If

            Return copyTable.Clone()

        End If

        'resultTable = sourceTable.Clone()

        'Dim rowHandle As Integer

        'For Each rowHandle In view.GetSelectedRows()

        '    Dim row As DataRow = view.GetDataRow(rowHandle)

        '    resultTable.Rows.Add(row.ItemArray)

        'Next rowHandle

        'resultTable.AcceptChanges()


        Return resultTable

    End Function

    Private Function CloneGrid(sourceGrid As DevExpress.XtraGrid.GridControl) As DevExpress.XtraGrid.GridControl
        Dim resultGrid As DevExpress.XtraGrid.GridControl = New DevExpress.XtraGrid.GridControl

        resultGrid.MainView = New GridView(resultGrid)
        resultGrid.MainView.Assign(sourceGrid.MainView, False)

        'Controls.Add(resultGrid);

        'resultGrid.Visible = false;

        Return resultGrid

    End Function

    Private Function GetGridWithSelection(ByVal grid As DevExpress.XtraGrid.GridControl) As DevExpress.XtraGrid.GridControl

        Dim clonedGrid As DevExpress.XtraGrid.GridControl = CloneGrid(grid)

        Dim clonedTable As DataTable = GetTableOfSelectedCrew(grid.MainView) '

        clonedGrid.DataSource = clonedTable

        Return clonedGrid

    End Function

#End Region

    Private Sub PassengerView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles PassengerView.CellValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub
        If e.Column.FieldName <> "Edited" Then
            PassengerView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If

        If e.Column.FieldName = "FKeyNearestAirport" Then
            Dim text As String = repPAirport.View.GetFocusedRowCellValue("AirportAbbrvLabel")

            If Not e.Value Is Nothing Then
                Dim value As String = PassengerView.GetRowCellDisplayText(e.RowHandle, "FKeyNearestAirport")
                PassengerView.SetRowCellValue(e.RowHandle, "NearestAirportName", value)
            End If

        ElseIf e.Column.FieldName = "FKeyAlternativeAirport" Then
            Dim text As String = repPAirport.View.GetFocusedRowCellValue("AirportAbbrvLabel")

            If Not e.Value Is Nothing Then
                Dim value As String = PassengerView.GetRowCellDisplayText(e.RowHandle, "FKeyAlternativeAirport")
                PassengerView.SetRowCellValue(e.RowHandle, "AlternativeAirportName", value)
            End If

        End If
    End Sub

    Private Sub PassengerView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles PassengerView.FocusedRowChanged
        PassengerView.Appearance.FocusedRow.BackColor = Nothing
    End Sub

    Private Sub PassengerView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles PassengerView.InitNewRow
        PassengerView.SetFocusedRowCellValue("Edited", True)
        PassengerView.SetFocusedRowCellValue("RequestType", cboRequestType.EditValue)
    End Sub

    Private Sub PassengerView_LostFocus(sender As Object, e As System.EventArgs) Handles PassengerView.LostFocus
        Me.header.Focus()
    End Sub

    Private Sub PassengerView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PassengerView.MouseDown
        Dim view As GridView = CType(sender, GridView)
        Dim pt As System.Drawing.Point = New System.Drawing.Point(e.X, e.Y)
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

        Dim rowCaption As String = ""

        'hitInfo = grid.

        'If hitInfo.RecordIndex >= 0 Then

        '    PassengerVGrid.Appearance.FocusedRecord.BackColor = VGRID_FOCUS_COLOR
        '    ApplyPassengerGridBackColor = True
        '    'SetDeleteCaption(Name, "Delete Passenger")
        'Else
        '    PassengerVGrid.Appearance.FocusedRecord.BackColor = Nothing
        '    ApplyPassengerGridBackColor = False
        '    'SetDeleteCaption(Name, "Delete Travel Request")
        'End If

        If hitInfo.InRow >= 0 Then

            PassengerView.Appearance.FocusedRow.BackColor = GRID_FOCUS_COLOR
            ApplyPassengerGridBackColor = True
            'SetDeleteCaption(Name, "Delete Passenger")
        Else
            PassengerView.Appearance.FocusedRow.BackColor = Nothing
            ApplyPassengerGridBackColor = False
            'SetDeleteCaption(Name, "Delete Travel Request")
        End If
    End Sub

    Private Sub PassengerView_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles PassengerView.RowCellClick
        If e.Column.Name = "colPFlightDetails" Then
            If PassengerView.GetFocusedRowCellValue("HasFlightDetails") = True Then
                ShowCrewTravelDetailsInPopup()
            End If
        End If
    End Sub

    Private Sub repPAirport_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repPAirport.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub ShowCrewDetailsInPopup(pTypeOfRecordToShow As frmPopupDetails.TypeOfRecordToShow, data As DataRow)
        If IsNothing(data) Then
            MsgBox("No data to show.", MsgBoxStyle.Information, GetAppName)
            Exit Sub
        End If

        Dim f As New frmPopupDetails(pTypeOfRecordToShow, data)
        f.ShowDialog()
    End Sub

    Private Sub repPContactDetails_Click(sender As Object, e As System.EventArgs) Handles repPContactDetails.Click
        If PassengerView.FocusedRowHandle >= 0 Then
            ShowCrewDetailsInPopup(frmPopupDetails.TypeOfRecordToShow.ContactDetails, PassengerView.GetFocusedDataRow)
        End If
    End Sub

    Private Sub repPDocuments_Click(sender As Object, e As System.EventArgs) Handles repPDocuments.Click
        If PassengerView.FocusedRowHandle >= 0 Then
            ShowCrewDetailsInPopup(frmPopupDetails.TypeOfRecordToShow.TravelDocuments, PassengerView.GetFocusedDataRow)
        End If
    End Sub

    Private Sub repPAirport_EditValueChanged(sender As Object, e As System.EventArgs) Handles repPAirport.EditValueChanged
        If PassengerView.FocusedColumn.FieldName = "FKeyNearestAirport" Then
            PassengerView.SetFocusedRowCellValue("FKeyNearestAirport", repPAirport.View.GetFocusedRowCellValue("PKey"))
            PassengerView.SetFocusedRowCellValue("NearestAirportName", repPAirport.View.GetFocusedRowCellValue("AirportAbbrvLabel"))
        ElseIf PassengerView.FocusedColumn.FieldName = "FKeyAlternativeAirport" Then
            PassengerView.SetFocusedRowCellValue("FKeyAlternativeAirport", repPAirport.View.GetFocusedRowCellValue("PKey"))
            PassengerView.SetFocusedRowCellValue("AlternativeAirport", repPAirport.View.GetFocusedRowCellValue("AirportAbbrvLabel"))
        End If

    End Sub

    Private Sub cboNearestAirport_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboNearestAirport.EditValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub
        If IfNull(cboNearestAirport.EditValue, "").Length > 0 Then
            If PassengerView.RowCount > 0 Then
                If MsgBox("Do you want to set all crew's Nearest Airport to '" & cboNearestAirport.Text & "'?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetAppName) = MsgBoxResult.Yes Then
                    For i As Integer = 0 To PassengerView.RowCount - 1
                        PassengerView.SetRowCellValue(i, "FKeyNearestAirport", cboNearestAirport.EditValue)
                        PassengerView.SetRowCellValue(i, "NearestAirportName", cboNearestAirport.Text)
                        PassengerView.SetRowCellValue(i, "Edited", True)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub repPRemove_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repPRemove.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
            If PassengerView.FocusedRowHandle >= 0 Then

                Dim hasFlightDetails As Boolean = isPassengerHasBooking(PassengerView.FocusedRowHandle)
                If MsgBox(IIf(hasFlightDetails, "This crew already has a flight detail(s)" & IIf(oGTRSControl.BookedWithGTravel, " booked by GTravel." & vbNewLine, "." & vbNewLine), "") & vbNewLine & _
                          "Do you want to continue to remove crew [" & PassengerView.GetFocusedRowCellValue("CrewName").ToString.ToUpper & "]?" & _
                          IIf(hasFlightDetails, vbNewLine & vbNewLine & "If you continue the already existing flight details will be deleted.", ""), MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Remove Crew as Passenger") = MsgBoxResult.Yes Then

                    If RemovePassenger(PassengerView.FocusedRowHandle) Then
                        If isPassengerHasBooking(PassengerView.FocusedRowHandle) Then
                            RemovePassengerBooking(PassengerView.FocusedRowHandle)
                        End If
                        MsgBox("Successfully removed crew as passenger.", MsgBoxStyle.Information, GetAppName)
                        PassengerView.DeleteRow(PassengerView.FocusedRowHandle)
                    Else
                        MsgBox("Failed to removed crew as passenger.", MsgBoxStyle.Critical, GetAppName)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboRequestType_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboRequestType.EditValueChanged
        If Not isEditdable And Not bAddMode Then Exit Sub
        If IfNull(cboRequestType.EditValue, "").Length > 0 Then
            For i As Integer = 0 To PassengerView.RowCount - 1
                PassengerView.SetRowCellValue(i, "RequestType", cboRequestType.EditValue)
                PassengerView.SetRowCellValue(i, "Edited", True)
            Next
        End If
    End Sub

    Private Sub PassengerView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles PassengerView.RowUpdated
        If bAddMode Or isEditdable Then
            SetTravelRequestIsUpdated()
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub AddGTRSEditListener()
        Dim lcgs As DevExpress.XtraLayout.LayoutControlGroup() = New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup_TravelDetails, LayoutControlGroup_TravelRequest, LayoutControlGroup_Status, LayoutControlGroup_Origin, LayoutControlGroup_Destination, LayoutControlGroup_RequestInfo}

        'GTRSField_EditValueChanged
        For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In lcgs
            For o As Integer = 0 To cContainer.Items.Count - 1
                If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                    'insert Old Process Here
                    'MsgBox(ctr.Name)
                    '===================================================

                    If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                        AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf GTRSField_EditValueChanged
                    ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then 'Includes TextEdit, DateEdit, LookupEdit
                        AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf GTRSField_EditValueChanged
                    End If
                    '===================================================
                End If
            Next
        Next
    End Sub

    Protected Sub GTRSField_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If oGTRSControl.BookedWithGTravel Then
            If Not TypeOf (sender) Is DevExpress.XtraGrid.GridControl Then
                If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
                End If
                oGTRSControl.ExecCustomFunction(New Object() {"ENABLE_SEND_TRAVEL_REQUEST_UPDATES"})
            End If
        End If

    End Sub

    Private Sub RemoveGTRSEditListener()
        Dim lcgs As DevExpress.XtraLayout.LayoutControlGroup() = New DevExpress.XtraLayout.LayoutControlGroup() {LayoutControl1.Root, LayoutControlGroup_TravelDetails, LayoutControlGroup_TravelRequest, LayoutControlGroup_Status, LayoutControlGroup_Origin, LayoutControlGroup_Destination, LayoutControlGroup_RequestInfo}
        Try
            For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In lcgs
                For i As Integer = 0 To cContainer.Items.Count - 1
                    If TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.LayoutControlGroup Then

                        Dim group As DevExpress.XtraLayout.LayoutControlGroup = TryCast(cContainer.Items(i), DevExpress.XtraLayout.LayoutControlGroup)
                        For o As Integer = 0 To group.Items.Count - 1
                            If TypeOf (group.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (group.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(group.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                                Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                                'insert Old Process Here
                                '===================================================
                                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf GTRSField_EditValueChanged
                                End If
                                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                    RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf GTRSField_EditValueChanged
                                End If
                                '===================================================

                            End If
                        Next
                    ElseIf TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                        RemoveGTRSEditListener(TryCast(cContainer.Items(i), DevExpress.XtraLayout.LayoutControlItem))
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RemoveGTRSEditListener(ByVal ctl As DevExpress.XtraLayout.LayoutControlItem)
        Dim ctr As System.Windows.Forms.Control = ctl.Control
        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
            RemoveGTRSEditListener(CType(ctr, DevExpress.XtraEditors.TextEdit))
        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
            RemoveGTRSEditListener(CType(ctr, DevExpress.XtraEditors.CheckEdit))
        End If
    End Sub

    Private Sub RemoveGTRSEditListener(ByVal ctl As DevExpress.XtraEditors.TextEdit)

        If TypeOf (ctl) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
            RemoveHandler CType(ctl, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf GTRSField_EditValueChanged
        End If
    End Sub

    Private Sub RemoveGTRSEditListener(ByVal ctl As DevExpress.XtraEditors.CheckEdit)

        If TypeOf (ctl) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
            RemoveHandler CType(ctl, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf GTRSField_EditValueChanged
        End If
    End Sub


End Class
