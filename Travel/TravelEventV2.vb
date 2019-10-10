Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class TravelEventV2
#Region "Declarations"
    Dim dtFlightDetails, dtTravelEvent, dtBookingDetails As New DataTable
    Dim clsAudit As New clsAudit 'neil
    Dim focusedRecordID As String
    Dim dtStatus As New DataTable
    Dim dtCrewlist As New DataTable
    Dim dvCrewlist As New DataView
    Dim strLastUpdatedBy As String = ""
    Dim strDelete As String = "TravelEvent"
    Dim userdatafilterstring As String = GetUserFilterString(, "curr_act.FKeyAgentCode", "curr_act.FKeyPrinCode", "curr_act.FKeyFlt")
    Dim strEventType As String = ""
    Dim isLoadingData As Boolean = False
#End Region

    'RefreshData, EditData, DeleteData, SaveData
#Region "Overridables"

    Public Overrides Sub RefreshData()
        isLoadingData = True
        RaiseCustomEvent(Name, New Object() {"HideTravelGTRSControls"})    'added by tony20180503 - related to GTravel

        If bLoaded = False Then
            MyBase.RefreshData()
            RaiseCustomEvent(Name, New Object() {"SetUpTravelEventControls"})
            SetPreviewReportEnabled(Name, True)
            SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neil 20160913

            SetGridLayout(CrewView)
            SetGridLayout(TravelView)
            SetGridLayout(BookingView)
            SetGridLayout(FlightView)

            InitCrewDatatable()
            InitBookingDatatable()
            InitFlightDatatable()

            CrewGrid.DataSource = dtCrewlist
            BookingGrid.DataSource = dtBookingDetails
            FlightGrid.DataSource = dtFlightDetails

            cboPlaceSON.Properties.DataSource = PortList(DB)
            cboPortAgent.Properties.DataSource = PortAgentList(DB)
            cboInvoiceTo.Properties.DataSource = PrincipalList(DB)
            cboTravelAgent.Properties.DataSource = TravelAgentList(DB)

            CurrencyEdit.DataSource = CurrencyList(DB)
            AirlineEdit.DataSource = AirlineList(DB)
            AirportEdit.DataSource = AirportList(DB)

            SetAddCaption(Name, "Add")
            SetSaveCaption(Name, "Save")
            SetEditCaption(Name, "Edit")
            SetDeleteCaption(Name, "Delete")
            clsAudit.propSQLConnStr = DB.GetConnectionString 'neil

            AddHandler txtDepPlace.EditValueChanged, AddressOf TravelFields_Editvaluechanged
            AddHandler txtArrPlace.EditValueChanged, AddressOf TravelFields_Editvaluechanged
            AddHandler deReqArrDate.EditValueChanged, AddressOf TravelFields_Editvaluechanged
            AddHandler cboPortAgent.EditValueChanged, AddressOf TravelFields_Editvaluechanged
            AddHandler cboInvoiceTo.EditValueChanged, AddressOf TravelFields_Editvaluechanged
            AddHandler cboTravelAgent.EditValueChanged, AddressOf TravelFields_Editvaluechanged
            AddHandler txtRemarks.EditValueChanged, AddressOf TravelFields_Editvaluechanged

            bLoaded = True
            RaiseCustomEvent(Name, New Object() {"barChkShowAllPlanning"})
        End If


        focusedRecordID = blList.GetID()
        If focusedRecordID <> "" Then
            Dim dtPlanEvent, dtTravelEvent As New DataTable
            LayoutControl1.AllowCustomization = True
            Select Case MAIN_CONTENT
                Case "TravelEvent_Returning"
                    strEventType = "Returning"
                    LCGPlanDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    dtTravelEvent = DB.CreateTable("SELECT * FROM tblTravelEvent WHERE FKeyReferenceID = '" & focusedRecordID & "' AND TravelEventType = 'Returning' ORDER BY ReqArrDate")

                    dvCrewlist = New DataView(DB.CreateTable("SELECT ctr.CrewName + ' - ' + ctr.RankName as CrewName, 'No' as isEdited, ctr.CrewID,  ctr.FKeyRankCode as FKeyRank " & _
                                                "FROM [dbo].[Crewlist_TravelEvents_Returning] ctr " & _
                                                "INNER JOIN dbo.Current_Activites curr_act ON ctr.ActID = curr_act.PKey " & _
                                                "WHERE ctr.FKeyVslCode = '" & focusedRecordID & "' " & _
                                                IIf(userdatafilterstring.Length > 0, " AND " & userdatafilterstring & " ", "") & _
                                                " ORDER BY ctr.CrewName"))

                    lciReqDate.Text = "* Req Dep Date"
                Case Else
                    strEventType = "Joining"
                    LCGPlanDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    dtTravelEvent = DB.CreateTable("SELECT * FROM tblTravelEvent WHERE FKeyReferenceID = '" & focusedRecordID & "' AND TravelEventType = 'Joining' ORDER BY ReqArrDate")
                    dtPlanEvent = DB.CreateTable("SELECT VslName, PlannedPlaceSON, PlannedDateSON FROM [dbo].[Planning_Events] WHERE PKey = '" & focusedRecordID & "'")

                    txtVessel.EditValue = dtPlanEvent.Rows(0)("VslName")
                    cboPlaceSON.EditValue = dtPlanEvent.Rows(0)("PlannedPlaceSON")
                    deDateSON.EditValue = CDate(dtPlanEvent.Rows(0)("PlannedDateSON")).ToString("dd-MMM-yyyy")

                    dvCrewlist = New DataView(DB.CreateTable("SELECT ctj.CrewName + ' - ' + ctj.RankName as CrewName, 'No' as isEdited, ctj.CrewID, ctj.FKeyRank " & _
                                                    "FROM [dbo].[Crewlist_TravelEvents_Joining] ctj " & _
                                                    "INNER JOIN dbo.Current_Activites curr_act ON ctj.CrewID = curr_act.FKeyIDNbr " & _
                                                    "WHERE FKeyPlanningEvent = '" & focusedRecordID & "'" & IIf(userdatafilterstring.Length > 0, " AND " & userdatafilterstring & " ", "") & _
                                                    "ORDER BY ctj.CrewName"))

                    lciReqDate.Text = "* Req Arr Date"
            End Select
            LayoutControl1.AllowCustomization = False

            CrewEdit.DataSource = dvCrewlist
            TravelGrid.DataSource = dtTravelEvent
            TravelView_FocusedRowChanged(Nothing, Nothing)

            EnableControls(False)
            BRECORDUPDATEDs = False

            AllowAddition(Name, True)
            If TravelView.RowCount > 0 Then AllowEditing(Name, True)
            AllowSaving(Name, False)
            EditCheck(Name, False)
            AllowDeletion(Name, False)
            isEditdable = False
            bAddMode = False
        End If
        SetTravelFieldsBackColor()
        isLoadingData = False
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        If isEditdable = True Then
            EnableControls(True)
            AllowDeletion(Name, True)
        Else
            If BRECORDUPDATEDs Then
                isEditdable = True
                EditCheck(Name, True)
                MyBase.EditData()
            Else
                EnableControls(False)
                AllowDeletion(Name, True)
                AllowAddition(Name, True)
            End If
        End If
    End Sub

    Public Overrides Sub AddData()
        MyBase.AddData()
        bAddMode = True
        EnableControls(True)
        ClearControls()
    End Sub

    Public Overrides Sub SaveData()
        txtDepPlace.Focus()

        If checkRequiredFields() = True Then Exit Sub

        Dim strTravelID As String = IfNull(TravelView.GetFocusedRowCellValue("PKey"), "")
        Dim strBookingID As String = ""
        Dim strFlightID As String = ""
        Dim strSql As String = ""
        Dim sqls As New ArrayList

        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, txtVessel.Text & " / " & ChangeToSQLDate(deDateSON.EditValue.ToString), "TravelEvent") 'neil
        If bAddMode = True Then strTravelID = ""

        'Add/Update Travel Event and return PKey of the inserted/updated Travel Event
        strSql = "EXEC [dbo].[TRAVEL_EVENT_INSERT/UPDATE] " & _
                    "@PKey = '" & strTravelID & "', " & _
                    "@DepPlace = '" & txtDepPlace.EditValue & "', " & _
                    "@ArrPlace = '" & txtArrPlace.EditValue & "', " & _
                    "@ReqArrDate = " & ChangeToSQLDate(deReqArrDate.EditValue) & ", " & _
                    "@FKeyPortAgent = '" & cboPortAgent.EditValue & "', " & _
                    "@FKeyPrincipal = '" & cboInvoiceTo.EditValue & "', " & _
                    "@FKeyTravelAgent = '" & cboTravelAgent.EditValue & "', " & _
                    "@Remarks = '" & txtRemarks.EditValue & "', " & _
                    "@LastUpdatedBy = '" & strLastUpdatedBy & "', " & _
                    "@TravelEventType = '" & strEventType & "'," & _
                    "@FKeyReferenceID = '" & focusedRecordID & "'"
        strTravelID = DB.CreateTable(strSql).Rows(0)(0) 'Inserted/Updated PKey
        TravelView.SetFocusedRowCellValue("PKey", strTravelID)

        'Assign travel event to crew.
        For i As Integer = 0 To CrewView.DataRowCount - 1
            If CrewView.GetRowCellValue(i, "isEdited") = "Yes" Then
                strSql = "EXEC dbo.[INSERT_TRAVELEVENTCREW] @FKeyCrewID ='" & CrewView.GetRowCellValue(i, "FKeyCrewID") & "', @FKeyTravelEvent = '" & strTravelID & "',@FKeyRank ='" & CrewView.GetRowCellValue(i, "FKeyRank") & "'"
                CrewView.SetRowCellValue(i, "PKey", DB.CreateTable(strSql).Rows(0)(0))
                CrewView.SetRowCellValue(i, "isEdited", "No")
            End If
        Next

        sqls.Clear()
        For i As Integer = 0 To BookingView.DataRowCount - 1
            If BookingView.GetRowCellValue(i, "isEdited") = "Yes" Then
                'Add/Update Booking Detail and return PKey of the inserted/updated Booking Detail
                strSql = "EXEC [dbo].[BOOKINGDETAILS_INSERT/UPDATE] " & _
                            "@PKey = '" & IfNull(BookingView.GetRowCellValue(i, "PKey"), "") & "'," & _
                            "@FKeyTravelEvent = '" & strTravelID & "'," & _
                            "@FKeyCurrency = '" & IfNull(BookingView.GetRowCellValue(i, "FKeyCurrency"), "") & "'," & _
                            "@BookingRef = '" & IfNull(BookingView.GetRowCellValue(i, "BookingRef"), "") & "'," & _
                            "@TicketCost = " & IfNull(BookingView.GetRowCellValue(i, "TicketCost"), 0) & "," & _
                            "@InvoiceNbr = '" & IfNull(BookingView.GetRowCellValue(i, "InvoiceNbr"), "") & "'," & _
                            "@InvoiceDate = " & ChangeToSQLDate(BookingView.GetRowCellValue(i, "InvoiceDate")) & "," & _
                            "@LastUpdatedBy = '" & strLastUpdatedBy & "'"
                strBookingID = DB.CreateTable(strSql).Rows(0)(0) 'Inserted/Updated PKey
                BookingView.SetRowCellValue(i, "PKey", strBookingID)
            End If
        Next

        For x As Integer = 0 To FlightView.DataRowCount - 1
            If FlightView.GetRowCellValue(x, "isEdited") = "Yes" Then
                strSql = "EXEC [dbo].[FLIGHTDETAILS_INSERT/UPDATE] " & _
                            "@PKey = '" & IfNull(FlightView.GetRowCellValue(x, "PKey"), "") & "'," & _
                            "@FKeyBookingDetail = '" & BookingView.GetFocusedRowCellValue("PKey") & "'," & _
                            "@FKeyAirline = '" & IfNull(FlightView.GetRowCellValue(x, "FKeyAirline"), "") & "'," & _
                            "@ETD = " & ChangeToSQLDate(FlightView.GetRowCellValue(x, "ETD")) & "," & _
                            "@ETA = " & ChangeToSQLDate(FlightView.GetRowCellValue(x, "ETA")) & "," & _
                            "@Flight = '" & IfNull(FlightView.GetRowCellValue(x, "Flight"), "") & "'," & _
                            "@Status = '" & IfNull(FlightView.GetRowCellValue(x, "Status"), "") & "'," & _
                            "@Seq = '" & IfNull(FlightView.GetRowCellValue(x, "Seq"), "") & "'," & _
                            "@FKeyAirportFrom = '" & IfNull(FlightView.GetRowCellValue(x, "FKeyAirportFrom"), "") & "'," & _
                            "@FKeyAirportTo = '" & IfNull(FlightView.GetRowCellValue(x, "FKeyAirportTo"), "") & "'," & _
                            "@LastUpdatedBy = '" & strLastUpdatedBy & "'"
                strFlightID = DB.CreateTable(strSql).Rows(0)(0) 'Inserted/Updated PKey
                FlightView.SetRowCellValue(x, "PKey", strFlightID)
            End If
        Next
        strBookingID = BookingView.GetFocusedRowCellValue("PKey")
        MsgBox("Record Saved!", MsgBoxStyle.OkOnly, GetAppName() & " - Travel Event")
        RefreshData()
        SetSelection(strTravelID, TravelView)
        SetSelection(strBookingID, BookingView)
    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        If MessageBox.Show("Are you sure you want to delete this " & strDelete & ": " & strDesc & "?", GetAppName() & " - Travel Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", "TravelEvent") 'neil

            Select Case strDelete
                Case "Travel Event"
                    clsAudit.saveAuditPreDelDetails("tblTravelEvent", TravelView.GetFocusedRowCellValue("PKey"), strLastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        "Travel Event", _
                        "Crewing", _
                        "tblTravelEvent", _
                        "PKey IN ('" & TravelView.GetFocusedRowCellValue("PKey") & "')", _
                        "<< Delete Crew Data - Travel Event >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Travel Event>", _
                        GetUserName())
                    '-->
                    If DB.RunSql("DELETE FROM tblTravelEvent WHERE PKey = '" & TravelView.GetFocusedRowCellValue("PKey") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    TravelView.DeleteSelectedRows()
                    RefreshData()
                Case "Crew"
                    clsAudit.saveAuditPreDelDetails("tblTravelEventCrew", CrewView.GetFocusedRowCellValue("PKey"), strLastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        "Travel Event", _
                        "Crewing", _
                        "tblTravelEventCrew", _
                        "PKey IN ('" & CrewView.GetFocusedRowCellValue("PKey") & "')", _
                        "<< Delete Crew Data - Travel Event - Crew >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Travel Event - Crew>", _
                        GetUserName())
                    '-->
                    If DB.RunSql("DELETE FROM tblTravelEventCrew WHERE PKey = '" & CrewView.GetFocusedRowCellValue("PKey") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    CrewView.DeleteSelectedRows()
                Case "Booking"
                    clsAudit.saveAuditPreDelDetails("tblBookingDetails", BookingView.GetFocusedRowCellValue("PKey"), strLastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        "Travel Event", _
                        "Crewing", _
                        "tblBookingDetails", _
                        "PKey IN ('" & BookingView.GetFocusedRowCellValue("PKey") & "')", _
                        "<< Delete Crew Data - Travel Event - Booking Details >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Travel Event - Booking Details>", _
                        GetUserName())
                    '-->
                    If DB.RunSql("DELETE FROM tblBookingDetails WHERE PKey = '" & BookingView.GetFocusedRowCellValue("PKey") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    BookingView.DeleteSelectedRows()
                Case "Flight"
                    clsAudit.saveAuditPreDelDetails("tblFlightDetails", FlightView.GetFocusedRowCellValue("PKey"), strLastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        "Travel Event", _
                        "Crewing", _
                        "tblFlightDetails", _
                        "PKey IN ('" & FlightView.GetFocusedRowCellValue("PKey") & "')", _
                        "<< Delete Crew Data - Travel Event - Flight Details >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Travel Event - Flight Details>", _
                        GetUserName())
                    '-->
                    If DB.RunSql("DELETE FROM tblFlightDetails WHERE PKey = '" & FlightView.GetFocusedRowCellValue("PKey") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    FlightView.DeleteSelectedRows()
            End Select
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        Try
            'If focusedGroup = "" Then
            '    MessageBox.Show("Select an existing travel event or add and save a new travel event in order to view this report.", "MPS5 - Planning Event", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            Select Case param(0)
                Case "TravelSearch"

                    Dim frmSearch As New frmTravelSearch(DB, strEventType)
                    frmSearch.ShowDialog()
                    If IsNothing(frmSearch.param) = False Then
                        blList.SetSelection(frmSearch.param(0)) 'param(0) Reference ID
                        SetFocusTravelEvent(frmSearch.param(1)) 'param(1) Travel Event PKey
                    End If

                Case "PREVIEWREPORT"
                    'Dim repClass As New CrewFlightReq(DB, focusedRecordID, strEventType)
                    
                    If TravelView.GetFocusedRowCellValue("PKey") = Nothing Then
                        MsgBox("There is no selected travel event to preview.", MsgBoxStyle.Information)
                    Else
                        If IfNull(TravelView.GetFocusedRowCellValue("PKey"), "").Equals("") Then
                            MsgBox("There is no selected travel event to preview.", MsgBoxStyle.Information)
                        Else
                            Dim repClass As New CrewFlightReq(DB, TravelView.GetFocusedRowCellValue("PKey"), strEventType)
                            repClass.showPreview()
                        End If
                    End If
                    
            End Select
            'End If
        Catch ex As Exception
            MsgBox("Unable to generate report source. " & Chr(13) & "Error " & ex.Message, vbExclamation)
            LogErrors(" ExecCustomFunction: " & ex.Message)
        End Try
    End Sub
#End Region

    'Initiate dtFlightDetails, dtTravelEvent, dtBookingDetails
#Region "Init Datatables"

    Private Sub InitCrewDatatable()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCrewlist.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyTravelEvent"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCrewlist.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyCrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCrewlist.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtCrewlist.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "isEdited"
        ccolumn.DataType = System.Type.GetType("System.String")
        ccolumn.DefaultValue = "Yes"
        dtCrewlist.Columns.Add(ccolumn)
    End Sub

    Private Sub InitBookingDatatable()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyTravelEvent"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "BookingRef"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyCurrency"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "TicketCost"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "InvoiceNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "InvoiceDate"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Status"
        ccolumn.DataType = System.Type.GetType("System.String")
        ccolumn.DefaultValue = "Waitlisted"
        dtBookingDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "isEdited"
        ccolumn.DataType = System.Type.GetType("System.String")
        ccolumn.DefaultValue = "Yes"
        dtBookingDetails.Columns.Add(ccolumn)
    End Sub

    Private Sub InitFlightDatatable()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyBookingDetail"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Seq"
        ccolumn.DataType = System.Type.GetType("System.Int16")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyAirline"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Flight"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyAirportFrom"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyAirportTo"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DepDate"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DepTime"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ArrDate"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ArrTime"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Status"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "isEdited"
        ccolumn.DataType = System.Type.GetType("System.String")
        ccolumn.DefaultValue = "Yes"
        dtFlightDetails.Columns.Add(ccolumn)

        Dim clm As DataColumn
        clm = New DataColumn
        clm.ColumnName = "FlightStatus"
        clm.DataType = System.Type.GetType("System.String")
        dtStatus.Columns.Add(clm)

        dtStatus.Rows.Add(New Object() {MPS4DataSources.FlightStatus.Requested})
        dtStatus.Rows.Add(New Object() {MPS4DataSources.FlightStatus.Waitlisted})
        dtStatus.Rows.Add(New Object() {MPS4DataSources.FlightStatus.Confirmed})
        StatusEdit.DataSource = dtStatus
    End Sub

#End Region

#Region "Validations"
    'Check if all required fields are filled.
    Private Function checkRequiredFields() As Boolean
        Dim res As Boolean = False
        Dim clm, cmln As New DevExpress.XtraGrid.Columns.GridColumn

        If IfNull(txtDepPlace.EditValue, "") = "" Or _
            IfNull(txtArrPlace.EditValue, "") = "" Or _
            IfNull(deReqArrDate.EditValue, "") = "" Or _
            IfNull(cboPortAgent.EditValue, "") = "" Or _
            IfNull(cboInvoiceTo.EditValue, "") = "" Then
            MsgBox("Please complete required fields.", MsgBoxStyle.Information, GetAppName() & " - Travel Event")
            res = True
            Return res
            Exit Function
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'BOOKING DETAILS
        'For i As Integer = 0 To BookingView.RowCount - 1
        '    For Each clm In BookingView.Columns
        '        If clm.Tag = "Required" And IfNull(BookingView.GetRowCellValue(i, clm), "") = "" Then
        '            BookingView.SetColumnError(clm, "Required Field")
        '            MsgBox("Please complete required fields.", MsgBoxStyle.Information, GetAppName() & " - Travel Event")
        '            res = True
        '            Return res
        '            Exit Function
        '        End If
        '    Next
        'Next
        Dim HasNoMissingRequired As Boolean = True
        For i As Integer = 0 To BookingView.RowCount - 1
            For Each clm In BookingView.Columns
                If clm.Tag = "Required" And IfNull(BookingView.GetRowCellValue(i, clm), "") = "" Then
                    BookingView.SetColumnError(clm, "Required Field")
                    HasNoMissingRequired = False
                End If
            Next
        Next
        If Not HasNoMissingRequired Then
            MsgBox("Please complete required fields.", MsgBoxStyle.Information, GetAppName() & " - Travel Event")
            res = True
            Return res
            Exit Function
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'FLIGHT DETAILS
        HasNoMissingRequired = True
        'For i As Integer = 0 To FlightView.RowCount - 1
        '    For Each clm In FlightView.Columns
        '        If clm.Tag = "Required" And IfNull(FlightView.GetRowCellValue(i, clm), "") = "" Then
        '            MsgBox("Please complete required fields.", MsgBoxStyle.Information, GetAppName() & " - Travel Event")
        '            res = True
        '            Return res
        '            Exit Function
        '        End If
        '    Next
        'Next
        For i As Integer = 0 To FlightView.RowCount - 1
            For Each clm In FlightView.Columns
                If clm.Tag = "Required" And IfNull(FlightView.GetRowCellValue(i, clm), "") = "" Then
                    FlightView.SetColumnError(clm, "Required Field")
                    HasNoMissingRequired = False
                End If
            Next
        Next

        If Not HasNoMissingRequired Then
            MsgBox("Please complete required fields.", MsgBoxStyle.Information, GetAppName() & " - Travel Event")
            res = True
            Return res
            Exit Function
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Crew Count
        If CrewView.DataRowCount = 0 Then
            MsgBox("Please assign crew/s.", MsgBoxStyle.Information, GetAppName() & " - Travel Event")
            res = True
            Return res
            Exit Function
        End If
        Return res
    End Function

    'Disable crew drop down if crew is already added.
    Private Sub CrewView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CrewView.ShowingEditor
        If Not CrewView.IsNewItemRow(CrewView.FocusedRowHandle) Then e.Cancel = True
    End Sub

    'Prevents validator pop up message.
    Private Sub CrewView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CrewView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    'Check if crew already belongs to the event.
    Private Sub CrewView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CrewView.ValidateRow
        Dim view As GridView = TryCast(sender, GridView)
        If view.IsNewItemRow(e.RowHandle) Then
            Dim column As Columns.GridColumn = view.Columns("FKeyCrewID")
            Dim val As Object = view.GetRowCellValue(e.RowHandle, column)

            For i As Integer = 0 To CrewView.DataRowCount - 1
                If CrewView.GetRowCellValue(i, column) = val Then
                    e.Valid = False
                    view.SetColumnError(column, "Crew is already included in the event. Press 'ESC' to clear.")
                    Exit For
                    Exit Sub
                End If
            Next

            If DB.DLookUp("tec.PKey", "tblTravelEventCrew tec LEFT JOIN tblTravelEvent te ON te.PKey = tec.FKeyTravelEvent", "", "tec.FKeyCrewID = '" & val & "' AND te.FKeyReferenceID = '" & focusedRecordID & "'") <> "" Then
                e.Valid = False
                view.SetColumnError(column, "Crew is already included in the event. Press 'ESC' to clear.")
                Exit Sub
            End If

            If isLoadingData = False Then BRECORDUPDATEDs = True
        End If
    End Sub

    'Validation when leaving unfinish business.
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            flag = True
            ALLOWNEXTS = flag
            SaveData() '
        ElseIf res = MsgBoxResult.No Then
            isEditdable = False
            bAddMode = False
            BRECORDUPDATEDs = False
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

#End Region

#Region "Save/Load Layout"
    Public Overrides Sub SaveMainContentLayout()
        MyBase.SaveMainContentLayout()
        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
        BookingView.SaveLayoutToXml(strLayoutPath & "TravelEvent_BookingView.xml")
        FlightView.SaveLayoutToXml(strLayoutPath & "TravelEvent_FlightView.xml")
        LayoutControl1.SaveLayoutToXml(strLayoutPath & "TravelEvent_Layout.xml")
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        Try
            MyBase.LoadMainContentLayout()
            Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
            BookingView.RestoreLayoutFromXml(strLayoutPath & "TravelEvent_BookingView.xml")
            FlightView.RestoreLayoutFromXml(strLayoutPath & "TravelEvent_FlightView.xml")
            LayoutControl1.RestoreLayoutFromXml(strLayoutPath & "TravelEvent_Layout.xml")
        Catch ex As Exception
            'Wala talagang laman to. Para pag wala syang nakita default lang. :D
        End Try
    End Sub
#End Region

    'Check unsaved changes before leaving current travel event.
    Private Sub TravelView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles TravelView.BeforeLeaveRow
        If BRECORDUPDATEDs = True And isLoadingData = False Then
            CheckValidateFields()
            e.Allow = ALLOWNEXTS
        End If
    End Sub

    'Assign Values to Travel Event Controls and BookingView's datasource.
    Private Sub TravelView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TravelView.FocusedRowChanged
        isLoadingData = True
        If TravelView.RowCount > 0 Then
            With TravelView
                'Assign data to travel event controls.
                txtDepPlace.EditValue = .GetFocusedRowCellValue("DepPlace")
                txtArrPlace.EditValue = .GetFocusedRowCellValue("ArrPlace")
                deReqArrDate.EditValue = .GetFocusedRowCellValue("ReqArrDate")
                cboPortAgent.EditValue = .GetFocusedRowCellValue("FKeyPortAgent")
                cboInvoiceTo.EditValue = .GetFocusedRowCellValue("FKeyPrincipal")
                cboTravelAgent.EditValue = .GetFocusedRowCellValue("FKeyTravelAgent")
                txtRemarks.EditValue = .GetFocusedRowCellValue("Remarks")

                'Filter Crewlist to show crew under the selected travel event.
                'dvCrewlist.RowFilter = "FKeyTravelEvent = '" & .GetFocusedRowCellValue("PKey") & "'"
                Dim strSql As String = "SELECT tec.*, '' as isEdited FROM [TravelEvent_Crewlist] tec " & _
                                                "INNER JOIN dbo.Current_Activites curr_act ON tec.FKeyCrewID = curr_act.FKeyIDNbr " & _
                                                "WHERE FKeyTravelEvent = '" & .GetFocusedRowCellValue("PKey") & "'" & IIf(userdatafilterstring.Length > 0, " AND " & userdatafilterstring & " ", "") & _
                                                "ORDER BY tec.CrewName"
                dtCrewlist = DB.CreateTable(strSql)
                CrewGrid.DataSource = dtCrewlist

                'Get booking data from database
                dtBookingDetails = DB.CreateTable("SELECT *, '' as isEdited FROM tblBookingDetails WHERE FKeyTravelEvent = '" & .GetFocusedRowCellValue("PKey") & "'")
                BookingGrid.DataSource = dtBookingDetails

                'If BookingView.DataRowCount > 0 Then BookingView_FocusedRowChanged(Nothing, Nothing)
                If BookingView.DataRowCount > 0 Then
                    BookingView_FocusedRowChanged(Nothing, Nothing)
                Else
                    FlightViewEditable()
                End If

                strDesc = IfNull(txtDepPlace.EditValue, "") & " - " & CDate(deReqArrDate.EditValue).ToString("dd-MMM-yyyy")

            End With
        Else
            AllowEditing(Name, False)
            AllowSaving(Name, False)
            ClearControls()
        End If
        isLoadingData = False
    End Sub

    'Assign Datasource to Flight details.
    Private Sub BookingView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles BookingView.FocusedRowChanged
        dtFlightDetails.Rows.Clear()
        If BookingView.RowCount > 0 Then
            'Get flight details datasource
            dtFlightDetails = DB.CreateTable("SELECT PKey, FKeyBookingDetail, FKeyAirline, ETD, ETA, Flight, [Status], Seq, FKeyAirportFrom, FKeyAirportTo, '' as isEdited FROM tblFlightDetails WHERE FKeyBookingDetail = '" & BookingView.GetFocusedRowCellValue("PKey") & "' ORDER BY ETD ASC")
            FlightGrid.DataSource = dtFlightDetails
            strDesc = IfNull(BookingView.GetFocusedRowCellValue("BookingRef"), "")
        End If

        FlightViewEditable()
    End Sub

    Private Sub FlightViewEditable()
        Dim canEditFlight As Boolean
        If BookingView.RowCount > 0 Then
            If isEditdable Or bAddMode Then
                canEditFlight = Not IsNothing(BookingView.GetFocusedRowCellValue("isEdited"))
            Else
                canEditFlight = False
            End If
        Else
            canEditFlight = False
        End If
        'FlightView.OptionsBehavior.ReadOnly = Not canEditFlight
        'If canEditFlight Then
        '    FlightView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        '    FlightView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        'Else
        '    FlightView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        '    FlightView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        'End If

        EditSubAllowGrid(FlightView, canEditFlight)
    End Sub

    'Tag booking row as edited.
    Private Sub BookingView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BookingView.CellValueChanged
        If e.Column.FieldName <> "isEdited" Then BookingView.SetFocusedRowCellValue("isEdited", "Yes")
        If isLoadingData = False Then BRECORDUPDATEDs = True
        CheckIfEnableFlightView(e.RowHandle)
    End Sub

    Private Sub CheckIfEnableFlightView(rowhandle As Integer)
        Dim RequiredFieldsCompleted As Boolean = True
        With BookingView
            For i As Integer = 0 To .Columns.Count - 1
                If .Columns(i).FieldName.ToString <> "Edited" And .Columns(i).Tag = "Required" Then
                    If IfNull(.GetRowCellValue(rowhandle, .Columns(i).FieldName.ToString), "").Equals("") Then
                        RequiredFieldsCompleted = False
                    End If
                End If
            Next
        End With

        EditSubAllowGrid(FlightView, RequiredFieldsCompleted)

    End Sub

    'Tag flight row as edited.
    Private Sub FlightView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles FlightView.CellValueChanged
        If e.Column.FieldName <> "isEdited" Then FlightView.SetFocusedRowCellValue("isEdited", "Yes")
        If isLoadingData = False Then BRECORDUPDATEDs = True
    End Sub

    'Get booking status based on flight details status.
    Private Sub BookingView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles BookingView.CustomUnboundColumnData
        Dim rowIndex As Integer = e.ListSourceRowIndex
        Dim detailRows() As DataRow = dtFlightDetails.Select("FKeyBookingDetail = '" & BookingView.GetRowCellValue(BookingView.GetRowHandle(rowIndex), "PKey") & "'")
        Dim confirmedFlight As Integer = 0
        If e.Column.FieldName = "Status" Then
            If e.IsGetData Then
                If detailRows.Count > 0 Then
                    For i As Integer = 0 To detailRows.Count - 1
                        If IsDBNull(detailRows(i)("Status")) = False Then
                            If detailRows(i)("Status") = "Confirmed" Then
                                confirmedFlight += 1
                            Else
                                e.Value = "Waitlisted"
                                Exit Sub
                            End If
                        End If
                    Next
                    If confirmedFlight = detailRows.Count Then e.Value = "Confirmed"
                Else
                    e.Value = "Waitlisted"
                End If
            End If
        End If
    End Sub

    'SET BRECORDUPDATEDs = True when fields are edited.
    'Private Sub TravelFields_Editvaluechanged(sender As Object, e As System.EventArgs) Handles txtDepPlace.EditValueChanged, txtArrPlace.EditValueChanged, deReqArrDate.EditValueChanged, cboPortAgent.EditValueChanged, cboInvoiceTo.EditValueChanged, cboTravelAgent.EditValueChanged, txtRemarks.EditValueChanged
    Private Sub TravelFields_Editvaluechanged(sender As Object, e As System.EventArgs)
        If isLoadingData = False Then
            Dim cntrl As DevExpress.XtraEditors.TextEdit = TryCast(sender, DevExpress.XtraEditors.TextEdit)
            cntrl.BackColor = EDITED_COLOR
            BRECORDUPDATEDs = True
        End If
    End Sub

    'SET FKeyRank in CrewView when adding new crew.
    Private Sub CrewView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CrewView.CellValueChanged
        If IfNull(CrewView.GetFocusedRowCellValue("FKeyRank"), "") = "" Then
            Dim dt As DataTable = dvCrewlist.ToTable.Select("CrewID = '" & CrewView.GetRowCellValue(e.RowHandle, "FKeyCrewID") & "'").CopyToDataTable
            If dt.Rows.Count > 0 Then
                Dim strRank As String = IfNull(dt.Rows(0)("FKeyRank"), "")
                CrewView.SetRowCellValue(e.RowHandle, "FKeyRank", strRank)
                CrewView.SetRowCellValue(e.RowHandle, "isEdited", "Yes")
            End If
        End If
    End Sub

    Private Sub ClearControls()
        isLoadingData = True
        dtCrewlist.Rows.Clear()
        dtBookingDetails.Rows.Clear()
        dtFlightDetails.Rows.Clear()

        txtDepPlace.EditValue = Nothing
        txtArrPlace.EditValue = Nothing
        deReqArrDate.EditValue = DBNull.Value
        cboPortAgent.EditValue = Nothing
        cboInvoiceTo.EditValue = Nothing
        cboTravelAgent.EditValue = Nothing
        txtRemarks.EditValue = Nothing
        isLoadingData = False
    End Sub

    Private Sub EnableControls(ByVal bol As Boolean)
        'Not bol = Enable
        'True = Enable
        cboPlaceSON.ReadOnly = True
        txtDepPlace.ReadOnly = Not bol
        txtArrPlace.ReadOnly = Not bol
        deReqArrDate.ReadOnly = Not bol
        cboPortAgent.ReadOnly = Not bol
        cboInvoiceTo.ReadOnly = Not bol
        cboTravelAgent.ReadOnly = Not bol
        txtRemarks.ReadOnly = Not bol

        CrewView.OptionsBehavior.ReadOnly = Not bol
        BookingView.OptionsBehavior.ReadOnly = Not bol
        FlightView.OptionsBehavior.ReadOnly = Not bol

        If bol = True Then
            CrewView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            CrewView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top

            BookingView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            BookingView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top

            FlightView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            FlightView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        Else
            CrewView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            CrewView.OptionsView.NewItemRowPosition = NewItemRowPosition.None

            BookingView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            BookingView.OptionsView.NewItemRowPosition = NewItemRowPosition.None

            FlightView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            FlightView.OptionsView.NewItemRowPosition = NewItemRowPosition.None

            txtDepPlace.BackColor = Color.White
            txtArrPlace.BackColor = Color.White
            txtRemarks.BackColor = Color.White
            cboInvoiceTo.BackColor = Color.White
            cboPortAgent.BackColor = Color.White
            cboTravelAgent.BackColor = Color.White
            deReqArrDate.BackColor = Color.White
        End If

        FlightViewEditable()

    End Sub

    Private Sub TravelView_GotFocus(sender As Object, e As System.EventArgs) Handles TravelView.GotFocus
        If TravelView.DataRowCount > 0 Then AllowDeletion(Name, True) Else AllowDeletion(Name, False)
        strDesc = IfNull(txtDepPlace.EditValue, "") & " - " & deReqArrDate.Text
        SetDeleteCaption(Name, "Delete Travel Event")
        strDelete = "Travel Event"
    End Sub

    Private Sub BookingView_GotFocus(sender As Object, e As System.EventArgs) Handles BookingView.GotFocus
        If BookingView.DataRowCount > 0 Then AllowDeletion(Name, True) Else AllowDeletion(Name, False)
        SetDeleteCaption(Name, "Delete Booking Detail")
        strDelete = "Booking"
        If BookingView.RowCount > 0 Then strDesc = IfNull(BookingView.GetFocusedRowCellValue("BookingRef"), "")
    End Sub

    Private Sub FlightView_GotFocus(sender As Object, e As System.EventArgs) Handles FlightView.GotFocus
        If FlightView.DataRowCount > 0 Then AllowDeletion(Name, True) Else AllowDeletion(Name, False)
        SetDeleteCaption(Name, "Delete Flight Detail")
        strDelete = "Flight"
        If FlightView.RowCount > 0 Then strDesc = IfNull(FlightView.GetFocusedRowCellValue("Flight"), "")
    End Sub

    Private Sub CrewView_GotFocus(sender As Object, e As System.EventArgs) Handles CrewView.GotFocus
        If CrewView.DataRowCount > 0 Then AllowDeletion(Name, True) Else AllowDeletion(Name, False)
        If CrewView.RowCount > 0 Then strDesc = IfNull(CrewView.GetFocusedRowCellDisplayText("FKeyCrewID"), "")
        SetDeleteCaption(Name, "Delete Crew")
        strDelete = "Crew"
    End Sub

    Private Sub CrewView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles CrewView.FocusedRowChanged
        If CrewView.RowCount > 0 Then strDesc = IfNull(CrewView.GetFocusedRowCellDisplayText("FKeyCrewID"), "")
    End Sub

    Private Sub FlightView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles FlightView.FocusedRowChanged
        If FlightView.RowCount > 0 Then strDesc = IfNull(FlightView.GetFocusedRowCellValue("Flight"), "")
    End Sub

    Private Sub SetSelection(ByVal id As String, ByVal view As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("PKey")
            RowHandle = view.LocateByValue(0, Col, id)
            RowHandle = IIf(RowHandle < 0, 0, RowHandle)
            view.FocusedRowHandle = RowHandle
            view.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetFocusTravelEvent(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = TravelView.Columns("PKey")
            RowHandle = TravelView.LocateByValue(0, Col, id)
            TravelView.FocusedRowHandle = RowHandle
            TravelView.TopRowIndex = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FlightView_ShownEditor(sender As Object, e As System.EventArgs) Handles FlightView.ShownEditor
        SetMinMaxDateValidation(sender, e, "ETD", "ETA")
    End Sub

    Private Sub SetTravelFieldsBackColor()
        txtDepPlace.BackColor = REQUIRED_COLOR
        txtArrPlace.BackColor = REQUIRED_COLOR
        deReqArrDate.BackColor = REQUIRED_COLOR
        cboPortAgent.BackColor = REQUIRED_COLOR
        cboInvoiceTo.BackColor = REQUIRED_COLOR
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BookingView.RowCellStyle, FlightView.RowCellStyle
        Dim view As GridView = CType(sender, GridView)
        If view.IsRowSelected(e.RowHandle) And e.Column.Tag = "Required" Then
            If IsDBNull(e.CellValue) Then
                e.Appearance.BackColor = REQUIRED_SELECTED_COLOR
            End If
        ElseIf view.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
            e.Appearance.ForeColor = Color.Black
        Else
            If e.Column.Tag = "Required" Then
                If IsDBNull(e.CellValue) Then
                    e.Appearance.BackColor = REQUIRED_COLOR
                End If
            End If
        End If
    End Sub

    Private Sub FlightView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles FlightView.ValidateRow
        Dim view As GridView = TryCast(sender, GridView)
        If view.IsNewItemRow(e.RowHandle) Then
            'Dim val As Object = view.GetRowCellValue(e.RowHandle, column)
            'If val Is Nothing OrElse val.ToString() = String.Empty Then
            '    e.Valid = False
            '    view.SetColumnError(column, "Value cannot be empty")
            'End If

            If BookingView.RowCount <= 0 Then
                e.Valid = False
            End If
        End If
    End Sub

    Private Sub FlightView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles FlightView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("Status"), MPS4DataSources.FlightStatus.Requested)
    End Sub
End Class
