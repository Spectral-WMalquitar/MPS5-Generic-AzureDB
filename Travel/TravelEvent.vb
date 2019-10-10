Public Class TravelEvent
    Dim param() As String
    Dim peID As String = ""
    Dim dtFlightDetails, dtTravelEvent, dtBookingDetails As New DataTable
    Dim ds As New DataSet
    Dim defaultIDVal As String
    Dim focusedGroup As String
    Dim focusedPlanID As String
    Dim isTravelEdited As Boolean = False
    Dim deleteCap As String = ""
    Dim TravelEventType As String
    Dim strLastUpdatedBy As String = ""
    Dim strFocusedVsl As String = ""
    Dim isFirstLoad As Boolean = False
    Dim clsAudit As New clsAudit 'neil
    Private Const NoAssignmentGroupLabel As String = "Crew(s) without travel" 'added by tony20161123

#Region "Easy Edit" 'neil
    Private FormName As String = "Travel Event"
#End Region

#Region "Overridables"

    Public Overrides Sub RefreshData()
        RaiseCustomEvent(Name, New Object() {"HideTravelGTRSControls"})    'added by tony20180503 - related to GTravel

        bAddMode = False
        isEditdable = False
        SetGridLayout(gvBookingDetails)
        SetGridLayout(gvCrewList)
        TravelEventType = MAIN_CONTENT
        initControls()
        SetPreviewReportEnabled(Name, True)
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neil 20160913
        peID = blList.GetID()
        If bLoaded = False Then
            MyBase.RefreshData()
            RaiseCustomEvent(Name, New Object() {"SetUpTravelEventControls"})
            initLookupEdits()
            initDatatables()
            'SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            'SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            'SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            'SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetAddCaption(Name, "Add")
            SetSaveCaption(Name, "Save")
            SetEditCaption(Name, "Edit")
            SetDeleteCaption(Name, "Delete")
            clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
            bLoaded = True
        End If

        If peID <> "" Then
            bAddMode = False
            isEditdable = False

            Dim dt, crewDt As New DataTable
            Dim userdatafilterstring As String = GetUserFilterString(, "curr_act.FKeyAgentCode", "curr_act.FKeyPrinCode", "curr_act.FKeyFlt")
            Select Case TravelEventType
                Case "TravelEvent"

                    dt = DB.CreateTable("SELECT * FROM [dbo].[Planning_Events] WHERE PKey = '" & peID & "'")
                    txtVsl.EditValue = dt.Rows(0).Item("VslName")
                    luPlaceSign.EditValue = dt.Rows(0).Item("PlannedPlaceSON")
                    deDateSign.EditValue = CDate(dt.Rows(0).Item("PlannedDateSON")).ToString("dd-MMM-yyyy") 'This will cause an error if the Planned Date sign on is null. 20160215
                    'edited by tony20161123 according to error image 'KBS MPS 146 Nov 22_Fordz.jpg'
                    'crewDt = DB.CreateTable("SELECT ctj.CrewName, ctj.RankName, CAST(0 as bit) as isSelected, ctj.PKey, ctj.FKeyTravelEvent, ctj.ToRelieveID,ISNULL(ctj.DepPlace + ', ' + CONVERT(VARCHAR,ctj.ReqArrDate, 106),'- No Assignment') as GroupHead " & _
                    crewDt = DB.CreateTable("SELECT ctj.CrewName, ctj.RankName, CAST(0 as bit) as isSelected, ctj.PKey, ctj.FKeyTravelEvent, ctj.ToRelieveID,ISNULL(ctj.DepPlace + ', ' + CONVERT(VARCHAR,ctj.ReqArrDate, 106),'- " & NoAssignmentGroupLabel & "') as GroupHead " & _
                                            "FROM [dbo].[Crewlist_TravelEvents_Joining] ctj " & _
                                            "INNER JOIN dbo.Current_Activites curr_act ON ctj.CrewID = curr_act.FKeyIDNbr " & _
                                            "WHERE FKeyPlanningEvent = '" & peID & "'" & IIf(userdatafilterstring.Length > 0, " AND " & userdatafilterstring & " ", "") & _
                                            " ORDER BY ctj.CrewName")
                    strFocusedVsl = dt.Rows(0).Item("FKeyVessel")
                    isFirstLoad = True
                Case "TravelEvent_Returning"
                    txtVsl.EditValue = blList.GetFocusedRowData("Name")
                    If isFirstLoad = True Then
                        blList.SetSelection(strFocusedVsl)
                        isFirstLoad = False
                    End If
                    'edited by tony20161123 according to error image 'KBS MPS 146 Nov 22_Fordz.jpg'
                    'Dim cSql As String = "SELECT ctr.PKey,ctr.CrewID, ctr.CrewName,ctr.RankName,ctr.FKeyRankCode, CAST(0 as bit) as isSelected, ctr.FKeyTravelEvent, ctr.FKeyPlanningEvent, ISNULL(ctr.DepPlace + ', ' + CONVERT(VARCHAR,ctr.ReqArrDate, 106),'- No Assignment') as GroupHead " & _
                    Dim cSql As String = "SELECT ctr.PKey,ctr.CrewID, ctr.CrewName,ctr.RankName,ctr.FKeyRankCode, CAST(0 as bit) as isSelected, ctr.FKeyTravelEvent, ctr.FKeyPlanningEvent, ISNULL(ctr.DepPlace + ', ' + CONVERT(VARCHAR,ctr.ReqArrDate, 106),'- " & NoAssignmentGroupLabel & "') as GroupHead " & _
                                            "FROM [dbo].[Crewlist_TravelEvents_Returning] ctr " & _
                                            "INNER JOIN dbo.Current_Activites curr_act ON ctr.ActID = curr_act.PKey " & _
                                            "WHERE ctr.FKeyVslCode = '" & peID & "' " & _
                                            IIf(userdatafilterstring.Length > 0, " AND " & userdatafilterstring & " ", "") & _
                                            " ORDER BY ctr.CrewName"
                    crewDt = DB.CreateTable(cSql)
            End Select

            gcCrewList.DataSource = crewDt
            gvCrewList.Columns("GroupHead").Group()
            isTravelEdited = False
            gvCrewList.FocusedRowHandle = 0
        End If


        AllowEditing(Name, True)
        AllowAddition(Name, True)
        AllowSaving(Name, False)
        AllowDeletion(Name, True)

        EditCheck(Name, False)
        disableControls(True)
        deleteCap = ""
        BRECORDUPDATEDs = False
    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim detailView As GridView
        Dim arrReliver As New ArrayList
        Try
            txtPlace.Focus()
            If validateRequiredFields() = True Then
                BRECORDUPDATEDs = False
                Exit Sub
            End If

            If bAddMode = True Then
                If checkIfHasSelectedCrew() = True Then
                    'edited by tony20161123 according to error image 'KBS MPS 146 Nov 22_Fordz.jpg'
                    'MessageBox.Show("Please select crew under """"No Assignment."""".", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("Please select crew under """"" & NoAssignmentGroupLabel & "."""".", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    BRECORDUPDATEDs = False
                    Exit Sub
                End If

                Dim newID, planningID As String
                newID = DB.CreateTable("SELECT dbo.SETID('tblTravelEvent')").Rows(0).Item(0).ToString()
                If TravelEventType = "TravelEvent_Returning" Then

                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, txtVsl.Text & " / " & ChangeToSQLDate(deDateSign.EditValue.ToString), FormName) 'neil

                    DB.RunSql("INSERT INTO [MPS].[dbo].[tblPlanningEvent] " & _
                               "([PlanningEvent] ,[FKeyVessel] ,[Vessel] ,[PlannedDateSON], [PlannedPlaceSON] ,[Remarks], [PlanType])" & _
                               " VALUES " & _
                               "('SPECTPKey'  " & _
                               ",'" & peID & "' " & _
                               ",'" & txtVsl.Text & "' " & _
                               "," & ChangeToSQLDate(deDateSign.EditValue.ToString) & _
                               ",'" & luPlaceSign.EditValue & "' " & _
                               ",'Created in Returning', 'RETURN')")
                    planningID = DB.DLookUp("PKey", "tblPlanningEvent", "", "ID = IDENT_CURRENT('tblPlanningEvent')")

                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Created travel event.", "TravelEvent", "")
                    DB.RunSql("INSERT INTO [MPS].[dbo].[tblTravelEvent] ([PKey],[DepPlace],[ReqArrDate],[DateReq],[FKeyPortAgent],[FKeyPrincipal],[FKeyTravelAgent],[Remarks], [TravelEventType], [LastUpdatedBy], [ArrPlace])" & _
                    " VALUES ('" & newID & "','" & txtPlace.EditValue & "'," & ChangeToSQLDate(deReqDate.EditValue.ToString) & "," & ChangeToSQLDate(deDateReq.EditValue.ToString) & ",'" & lePortAgent.EditValue & "','" & leInvoiceTo.EditValue & "','" & leTravelAgent.EditValue & "','" & W.EditValue & "', 'Returning', '" & strLastUpdatedBy & "', '" & txtArrPlace.Text & "')")

                    For i As Integer = 0 To gvCrewList.DataRowCount - 1
                        If gvCrewList.GetRowCellValue(i, "isSelected") = True And gvCrewList.GetRowCellValue(i, "FKeyTravelEvent").ToString = "" Then
                            strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Assign Travel Event to crew.", "TravelEvent", gvCrewList.GetRowCellValue(i, "CrewID"))
                            sqls.Add("INSERT INTO [MPS].[dbo].[tblPlanningEventCrew] " & _
                                       "([CrewID],[FKeyPlanningEvent] ,[FKeyRank],[Rank],[FKeyTravelEvent], [LastUpdatedBy]) " & _
                                       "VALUES " & _
                                       "('" & gvCrewList.GetRowCellValue(i, "CrewID") & "' " & _
                                       ",'" & planningID & "' " & _
                                       ",'" & gvCrewList.GetRowCellValue(i, "FKeyRankCode") & "' " & _
                                       ",'" & gvCrewList.GetRowCellValue(i, "RankName") & "' " & _
                                       ",'" & newID & "' " & _
                                       ",'" & strLastUpdatedBy & "')")
                        End If
                    Next


                Else
                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Update Planned Place Sign-on.", "TravelEvent", "")
                    sqls.Add("UPDATE tblPlanningEvent SET PlannedPlaceSON = '" & luPlaceSign.EditValue & "' WHERE PKey = '" & peID & "'")
                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Created travel event.", "TravelEvent", "")
                    DB.RunSql("INSERT INTO [MPS].[dbo].[tblTravelEvent] ([PKey],[DepPlace],[ReqArrDate],[DateReq],[FKeyPortAgent],[FKeyPrincipal],[FKeyTravelAgent],[Remarks], [TravelEventType], [LastUpdatedBy], [ArrPlace])" & _
                                " VALUES ('" & newID & "','" & txtPlace.EditValue & "'," & ChangeToSQLDate(deReqDate.EditValue.ToString) & "," & ChangeToSQLDate(deDateReq.EditValue.ToString) & ",'" & lePortAgent.EditValue & "','" & leInvoiceTo.EditValue & "','" & leTravelAgent.EditValue & "','" & W.EditValue & "', 'Joining', '" & strLastUpdatedBy & "', '" & txtArrPlace.Text & "')")
                    For i As Integer = 0 To gvCrewList.DataRowCount - 1
                        If gvCrewList.GetRowCellValue(i, "isSelected") = True And gvCrewList.GetRowCellValue(i, "FKeyTravelEvent").ToString = "" Then
                            strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Assign Travel Event to crew.", "TravelEvent", gvCrewList.GetRowCellValue(i, "CrewID"))
                            sqls.Add("UPDATE tblPlanningEventCrew SET FKeyTravelEvent = '" & newID & "' WHERE PKey = '" & gvCrewList.GetRowCellValue(i, "PKey") & "'")
                            If IsDBNull(gvCrewList.GetRowCellValue(i, "ToRelieveID")) = False Then
                                If gvCrewList.GetRowCellValue(i, "ToRelieveID").ToString <> "" Then
                                    arrReliver.Add(DB.DLookUp("FKeyIDNbr", "dbo.Current_Activites", "", "PKey = '" & gvCrewList.GetRowCellValue(i, "ToRelieveID") & "'"))
                                End If
                            End If
                        End If
                    Next

                    If arrReliver.Count > 0 Then
                        Dim strReturningNewID As String = DB.CreateTable("SELECT dbo.SETID('tblTravelEvent')").Rows(0).Item(0).ToString()
                        planningID = DB.CreateTable("SELECT dbo.SETID('tblPlanningEvent')").Rows(0).Item(0).ToString()

                        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, txtVsl.Text & " / " & ChangeToSQLDate(deDateSign.EditValue.ToString), FormName) 'neil

                        DB.RunSql("INSERT INTO [MPS].[dbo].[tblPlanningEvent] " & _
                                   "([PlanningEvent] ,[FKeyVessel] ,[Vessel] ,[PlannedDateSON], [PlannedPlaceSON] ,[Remarks],[PlanType])" & _
                                   " VALUES " & _
                                   "('SPECTPKey'  " & _
                                   ",'" & peID & "' " & _
                                   ",'" & txtVsl.Text & "' " & _
                                   "," & ChangeToSQLDate(deDateSign.EditValue.ToString) & _
                                   ",'" & luPlaceSign.EditValue & "' " & _
                                   ",'Created in Joining', 'RETURN')")

                        planningID = DB.DLookUp("PKey", "tblPlanningEvent", "", "ID = IDENT_CURRENT('tblPlanningEvent')")
                        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Created travel event.", "TravelEvent", "")
                        sqls.Add("INSERT INTO [MPS].[dbo].[tblTravelEvent] ([PKey],[DepPlace],[ReqArrDate],[DateReq],[FKeyPortAgent],[FKeyPrincipal],[Remarks], [TravelEventType], [LastUpdatedBy], [ArrPlace])" & _
                        " VALUES ('" & strReturningNewID & "','" & txtPlace.EditValue & "'," & ChangeToSQLDate(deReqDate.EditValue.ToString) & "," & ChangeToSQLDate(deDateReq.EditValue.ToString) & ",'" & lePortAgent.EditValue & "','" & leInvoiceTo.EditValue & "','" & W.EditValue & "', 'Returning', '" & strLastUpdatedBy & "', '" & txtArrPlace.Text & "')")

                        For i As Integer = 0 To arrReliver.Count - 1
                            sqls.Add("INSERT INTO [MPS].[dbo].[tblPlanningEventCrew] " & _
                                       "([CrewID],[FKeyPlanningEvent] ,[FKeyTravelEvent]) " & _
                                       "VALUES " & _
                                       "('" & arrReliver.Item(i) & "' " & _
                                       ",'" & planningID & "' " & _
                                       ",'" & strReturningNewID & "')")
                        Next
                    End If
                End If

                For i As Integer = 0 To gvBookingDetails.DataRowCount - 1
                    Dim strBDPKey As String = ""
                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Created Booking Detail.", "TravelEvent", "")
                    Dim ss As String = "INSERT INTO [MPS].[dbo].[tblBookingDetails] ([FKeyTravelEvent],[FKeyCurrency],[BookingRef],[TicketCost],[InvoiceNbr],[InvoiceDate], [LastUpdatedBy]) " & _
                             "VALUES ('" & newID & "'," & _
                             "'" & gvBookingDetails.GetRowCellValue(i, "FKeyCurrency") & "'," & _
                             "'" & gvBookingDetails.GetRowCellValue(i, "BookingRef") & "'," & _
                                   IfNull(gvBookingDetails.GetRowCellValue(i, "TicketCost"), 0) & "," & _
                             "'" & gvBookingDetails.GetRowCellValue(i, "InvoiceNbr") & "'," & _
                    ChangeToSQLDate(gvBookingDetails.GetRowCellValue(i, "InvoiceDate")) & ", '" & strLastUpdatedBy & "')"
                    DB.RunSql(ss)
                    strBDPKey = DB.DLookUp("PKey", "tblBookingDetails", "", "ID = IDENT_CURRENT('tblBookingDetails')") 'SELECT PKey From [tblPlanningEvent] WHERE ID = IDENT_CURRENT('tblPlanningEvent')

                    gvBookingDetails.SetRowCellValue(i, "PKey", strBDPKey)

                    detailView = gvBookingDetails.GetDetailView(i, 0)
                    If IsNothing(detailView) = False Then
                        If detailView.RowCount > 0 Then
                            For x As Integer = 0 To detailView.RowCount - 1
                                strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Created Flight Detail.", "TravelEvent", "")
                                sqls.Add("INSERT INTO [MPS].[dbo].[tblFlightDetails]([FKeyBookingDetail],[FKeyAirline],[ETD],[ETA],[Flight],[Status],[Seq],[FKeyAirportFrom],[FKeyAirportTo], [LastUpdatedBy]) " & _
                                     "VALUES ('" & strBDPKey & "'," & _
                                     "'" & detailView.GetRowCellValue(x, "FKeyAirline") & "'," & _
                                     "" & ChangeToSQLDate(detailView.GetRowCellValue(x, "ETD").ToString) & "," & _
                                     "" & ChangeToSQLDate(detailView.GetRowCellValue(x, "ETA").ToString) & "," & _
                                     "'" & detailView.GetRowCellValue(x, "Flight") & "'," & _
                                     "'" & detailView.GetRowCellValue(x, "Status") & "'," & _
                                     "'" & detailView.GetRowCellValue(x, "Seq") & "'," & _
                                     "'" & detailView.GetRowCellValue(x, "FKeyAirportFrom") & "'," & _
                                     "'" & detailView.GetRowCellValue(x, "FKeyAirportTo") & "', '" & strLastUpdatedBy & "')")
                            Next
                        End If
                    End If
                Next

            Else
                If isTravelEdited = True Then
                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Updated Travel Event.", "TravelEvent", "")
                    sqls.Add("UPDATE tblPlanningEvent SET PlannedPlaceSON = '" & luPlaceSign.EditValue & "' WHERE PKey = '" & peID & "'")
                    sqls.Add("UPDATE [MPS].[dbo].[tblTravelEvent] " & _
                             "SET [DepPlace] = '" & txtPlace.EditValue & "' " & _
                             ",[ReqArrDate] = " & ChangeToSQLDate(deReqDate.EditValue.ToString) & _
                             ",[DateReq] = " & ChangeToSQLDate(deDateReq.EditValue) & _
                             ",[FKeyPortAgent] = '" & lePortAgent.EditValue & "' " & _
                             ",[FKeyPrincipal] = '" & leInvoiceTo.EditValue & "' " & _
                             ",[FKeyTravelAgent] = '" & leTravelAgent.EditValue & "' " & _
                             ",[Remarks] = '" & W.EditValue & "' " & _
                             ",[LastUpdatedBy] = '" & strLastUpdatedBy & "' " & _
                             ",[ArrPlace] = '" & txtArrPlace.Text & "' " & _
                             "WHERE PKey = '" & focusedGroup & "'")
                End If

                For i As Integer = 0 To gvCrewList.DataRowCount - 1
                    If gvCrewList.GetRowCellValue(i, "isSelected") = True Then
                        If IsDBNull(gvCrewList.GetRowCellValue(i, "FKeyTravelEvent")) = False Then
                            If gvCrewList.GetRowCellValue(i, "FKeyTravelEvent") = focusedGroup Then
                                strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Assignned Travel Event to crew.", "TravelEvent", gvCrewList.GetRowCellValue(i, "CrewID"))
                                sqls.Add("UPDATE tblPlanningEventCrew SET FKeyTravelEvent = '" & focusedGroup & "', LastUpdatedBy = '" & strLastUpdatedBy & "' WHERE PKey = '" & gvCrewList.GetRowCellValue(i, "PKey") & "'")
                            End If
                        End If
                    Else
                        'strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Removed Crew Travel Event.", "TravelEvent", gvCrewList.GetRowCellValue(i, "CrewID"))
                        sqls.Add("UPDATE tblPlanningEventCrew SET FKeyTravelEvent = NULL, LastUpdatedBy = '" & strLastUpdatedBy & "' WHERE PKey = '" & gvCrewList.GetRowCellValue(i, "PKey") & "'")
                    End If
                Next

                For i As Integer = 0 To gvBookingDetails.DataRowCount - 1

                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, gvBookingDetails.GetRowCellValue(i, "BookingRef"), FormName) 'neil

                    If gvBookingDetails.GetRowCellValue(i, "Rmks").ToString = "Edited" Then
                        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Updated Booking Detail.", "TravelEvent", "")
                        sqls.Add("UPDATE [MPS].[dbo].[tblBookingDetails] " & _
                                  "SET [FKeyCurrency] = '" & gvBookingDetails.GetRowCellValue(i, "FKeyCurrency") & "' " & _
                                  ",[BookingRef] = '" & gvBookingDetails.GetRowCellValue(i, "BookingRef") & "' " & _
                                  ",[TicketCost] = " & IfNull(gvBookingDetails.GetRowCellValue(i, "TicketCost"), 0) & _
                                  ",[InvoiceNbr] = '" & gvBookingDetails.GetRowCellValue(i, "InvoiceNbr") & "' " & _
                                  ",[InvoiceDate] = " & ChangeToSQLDate(gvBookingDetails.GetRowCellValue(i, "InvoiceDate")) & _
                                  ",[LastUpdatedBy] = '" & strLastUpdatedBy & "' " & _
                                  "WHERE PKey = '" & gvBookingDetails.GetRowCellValue(i, "PKey") & "'")
                    ElseIf gvBookingDetails.GetRowCellValue(i, "Rmks").ToString = "New" Then
                        Dim strBDPKey As String = ""
                        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Created Booking Detail.", "TravelEvent", "")
                        Dim ss As String = "INSERT INTO [MPS].[dbo].[tblBookingDetails] ([FKeyTravelEvent],[FKeyCurrency],[BookingRef],[TicketCost],[InvoiceNbr],[InvoiceDate], [LastUpdatedBy]) " & _
                                             "VALUES ('" & focusedGroup & "'," & _
                                             "'" & gvBookingDetails.GetRowCellValue(i, "FKeyCurrency") & "'," & _
                                             "'" & gvBookingDetails.GetRowCellValue(i, "BookingRef") & "'," & _
                                                   IfNull(gvBookingDetails.GetRowCellValue(i, "TicketCost"), 0) & "," & _
                                             "'" & gvBookingDetails.GetRowCellValue(i, "InvoiceNbr") & "'," & _
                                             "" & ChangeToSQLDate(gvBookingDetails.GetRowCellValue(i, "InvoiceDate")) & ", '" & strLastUpdatedBy & "')"
                        DB.RunSql(ss)
                        strBDPKey = DB.DLookUp("PKey", "tblBookingDetails", "", "ID = IDENT_CURRENT('tblBookingDetails')")
                        gvBookingDetails.SetRowCellValue(i, "PKey", strBDPKey)
                    End If

                    detailView = gvBookingDetails.GetDetailView(i, 0)
                    If IsNothing(detailView) = False Then
                        If detailView.RowCount > 0 Then
                            If Not IsNothing(detailView) Then
                                For x As Integer = 0 To detailView.RowCount - 1

                                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, detailView.GetRowCellValue(x, "Flight"), FormName) 'neil

                                    If detailView.GetRowCellValue(x, "Rmks").ToString = "Edited" Then
                                        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Updated Flight Detail.", "TravelEvent", "")
                                        sqls.Add("UPDATE [MPS].[dbo].[tblFlightDetails] " & _
                                                 "SET [FKeyAirline] = '" & detailView.GetRowCellValue(x, "FKeyAirline") & "' " & _
                                                 ",[ETD] = " & ChangeToSQLDate(detailView.GetRowCellValue(x, "ETD").ToString) & _
                                                 ",[ETA] = " & ChangeToSQLDate(detailView.GetRowCellValue(x, "ETA").ToString) & _
                                                 ",[Flight] = '" & detailView.GetRowCellValue(x, "Flight") & "' " & _
                                                 ",[Status] = '" & detailView.GetRowCellValue(x, "Status") & "' " & _
                                                 ",[Seq] = '" & detailView.GetRowCellValue(x, "Seq") & "' " & _
                                                 ",[FKeyAirportFrom] = '" & detailView.GetRowCellValue(x, "FKeyAirportFrom") & "' " & _
                                                 ",[FKeyAirportTo] = '" & detailView.GetRowCellValue(x, "FKeyAirportTo") & "' " & _
                                                 ",[LastUpdatedBy] = '" & strLastUpdatedBy & "' " & _
                                                 "WHERE PKey = '" & detailView.GetRowCellValue(x, "PKey") & "'")
                                    ElseIf detailView.GetRowCellValue(x, "Rmks").ToString = "New" Then
                                        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Travel Event", 0, System.Environment.MachineName, "Created Flight Detail.", "TravelEvent", "")
                                        sqls.Add("INSERT INTO [MPS].[dbo].[tblFlightDetails]([FKeyBookingDetail],[FKeyAirline],[ETD],[ETA],[Flight],[Status],[Seq],[FKeyAirportFrom],[FKeyAirportTo], [LastUpdatedBy]) " & _
                                                 "VALUES ('" & gvBookingDetails.GetRowCellValue(i, "PKey") & "'," & _
                                                 "'" & (detailView.GetRowCellValue(x, "FKeyAirline").ToString) & "'," & _
                                                 "" & ChangeToSQLDate(detailView.GetRowCellValue(x, "ETD").ToString) & "," & _
                                                 "" & ChangeToSQLDate(detailView.GetRowCellDisplayText(x, "ETA").ToString) & "," & _
                                                 "'" & detailView.GetRowCellValue(x, "Flight") & "'," & _
                                                 "'" & detailView.GetRowCellValue(x, "Status") & "'," & _
                                                 "'" & detailView.GetRowCellValue(x, "Seq") & "'," & _
                                                 "'" & detailView.GetRowCellValue(x, "FKeyAirportFrom") & "'," & _
                                                 "'" & detailView.GetRowCellValue(x, "FKeyAirportTo") & "', '" & strLastUpdatedBy & "')")
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            End If

            If DB.RunSqls(sqls) = True Then
                Dim updatedPEID As String = peID
                Dim updatedGrp As String = focusedGroup
                MsgBox(GetMessage("Saved", True), MsgBoxStyle.Information, GetAppName)
                BRECORDUPDATEDs = False
                bAddMode = False
                isEditdable = False
                RefreshData()
            End If
        Catch ex As Exception
            BRECORDUPDATEDs = False
        End Try
    End Sub

    Public Overrides Sub AddData()
        disableControls(False)
        AllowSaving(Name, True)
        AllowDeletion(Name, False)
        AllowEditing(Name, False)
        clearTravelEvent()
        bAddMode = True
        checkHasTravelEvent()
        gvCrewList.ExpandAllGroups()
        deDateReq.EditValue = Date.Now.ToString("dd-MMM-yyyy")
    End Sub

    Public Overrides Sub EditData()
        If focusedGroup = "" Then
            BRECORDUPDATEDs = False
            isEditdable = False
            'edited by tony20161123 according to error 'KBS MPS 139 Nov 22_Fordz.jpg'
            'MessageBox.Show("Please select travel event.", "MPS5 - Planning Event", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MessageBox.Show("Select an existing travel event or add and save a new travel event.", "MPS5 - Planning Event", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EditCheck(Name, False)
            Exit Sub
        End If
        MyBase.EditData()
        disableControls(False)
        checkHasTravelEvent()
    End Sub

    Public Overrides Sub DeleteData()
        Dim sqls As New ArrayList
        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

        Select Case deleteCap
            Case "Delete Booking Detail"
                Dim bookingID As String = gvBookingDetails.GetRowCellValue(gvBookingDetails.FocusedRowHandle, "PKey").ToString
                If MessageBox.Show(" Are you sure you want to delete """ & gvBookingDetails.GetRowCellValue(gvBookingDetails.FocusedRowHandle, "BookingRef") & """?", "MPS5 - Travel Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    clsAudit.saveAuditPreDelDetails("tblBookingDetails", bookingID, strLastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblBookingDetails", _
                        "PKey IN ('" & bookingID & "')", _
                        "<< Delete Crew Data - " & FormName & " - Booking Details >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Booking Details>", _
                        GetUserName()) 'added by tony20180922 : Log Deletion
                    If DB.RunSql("DELETE FROM tblBookingDetails WHERE PKey = '" & bookingID & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        MessageBox.Show("Booking detail successfully deleted.", "MPS5 - Travel Event", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RefreshData()
                    End If
                End If
            Case "Delete Flight Detail"
                Dim dView As GridView = gvBookingDetails.GetDetailView(gvBookingDetails.FocusedRowHandle, 0)
                If MessageBox.Show(" Are you sure you want to delete """ & dView.GetRowCellValue(dView.FocusedRowHandle, "Flight") & """?", "MPS5 - Travel Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    clsAudit.saveAuditPreDelDetails("tblFlightDetails", dView.GetRowCellValue(dView.FocusedRowHandle, "PKey"), strLastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblFlightDetails", _
                        "PKey IN ('" & dView.GetRowCellValue(dView.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " - Flight >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Flight>", _
                        GetUserName()) 'added by tony20180922 : Log Deletion
                    If DB.RunSql("DELETE FROM tblFlightDetails WHERE PKey = '" & dView.GetRowCellValue(dView.FocusedRowHandle, "PKey") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        MessageBox.Show("Booking detail successfully deleted.", "MPS5 - Travel Event", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RefreshData()
                    End If
                End If
            Case "Delete Travel Event"
                If MessageBox.Show("You are trying to delete a travel event, booking and flight details under this travel event will be deleted. Are you sure you want to delete """ & gvCrewList.GetGroupRowValue(gvCrewList.FocusedRowHandle, gvCrewList.Columns("GroupHead")) & """ ?", "MPS5 - Travel Event", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    clsAudit.saveAuditPreDelDetails("tblTravelEvent", focusedGroup, strLastUpdatedBy) 'neil
                    DB.RunSql("DELETE FROM tblTravelEvent WHERE PKey = '" & focusedGroup & "'")
                    If TravelEventType = "TravelEvent_Returning" Then
                        clsAudit.saveAuditPreDelDetails("tblPlanningEvent", focusedPlanID, strLastUpdatedBy) 'neil
                        '<!--added by tony20180922 : Log Deletion
                        Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tblPlanningEvent", _
                            "PKey IN ('" & focusedPlanID & "')", _
                            "<< Delete Crew Data - " & FormName & " - Travel Event >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & " - Travel Event>", _
                            GetUserName())
                        '-->
                        If DB.RunSql("DELETE FROM tblPlanningEvent WHERE PKey = '" & focusedPlanID & "'") Then
                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        End If
                    End If
                    MessageBox.Show("Booking detail successfully deleted.", "MPS5 - Travel Event", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshData()
                    blList.RefreshData()
                End If
        End Select
    End Sub
#End Region

#Region "Inits"
    Private Sub initLookupEdits()
        Dim dtPrin, dtPortAgent, dtAirport, dtCurrency, dtStatus, dtAirline, dtPorts, dtTvlAgnt As New DataTable
        dtPrin = DB.CreateTable("SELECT * FROM [dbo].[PrincipalList] ORDER BY Name")
        dtPortAgent = DB.CreateTable("SELECT PKey, Name FROM [dbo].[tblAdmPortAgent] ORDER BY Name")
        dtAirport = DB.CreateTable("SELECT PKey, Name FROM [dbo].[tblAdmAirport] ORDER BY Name")
        dtCurrency = DB.CreateTable("SELECT PKey, Name, Symbol FROM [dbo].[tblAdmCurr] ORDER BY Name")
        dtAirline = DB.CreateTable("SELECT PKey, Name from tblAdmAirline ORDER By Name")
        dtPorts = DB.CreateTable("SELECT PKey, Name FROM tblAdmPort ORDER BY Name")
        dtTvlAgnt = DB.CreateTable("SELECT Name, PKey FROM tblAdmTravAgent ORDER BY Name")

        lePortAgent.Properties.DataSource = dtPortAgent
        leInvoiceTo.Properties.DataSource = dtPrin
        luPlaceSign.Properties.DataSource = dtPorts
        leTravelAgent.Properties.DataSource = dtTvlAgnt
        currencyEdit.DataSource = dtCurrency
        airportEdit.DataSource = dtAirport
        airlineEdit.DataSource = dtAirline

        deReqDate.Properties.EditMask = "dd-MMM-yyyy"
        deReqDate.Properties.Mask.UseMaskAsDisplayFormat = True

        deDateReq.Properties.EditMask = "dd-MMM-yyyy"
        deDateReq.Properties.Mask.UseMaskAsDisplayFormat = True

        deDateSign.Properties.EditMask = "dd-MMM-yyyy"
        deDateSign.Properties.Mask.UseMaskAsDisplayFormat = True

        genericDateEdit.EditMask = "dd-MMM-yyyy"
        genericDateEdit.Mask.UseMaskAsDisplayFormat = True

        DateTimeEdit.EditMask = "dd-MMM-yyyy hh:mm tt"
        DateTimeEdit.Mask.UseMaskAsDisplayFormat = True

        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Status"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtStatus.Columns.Add(ccolumn)

        dtStatus.Rows.Add(New Object() {"Requested"})
        dtStatus.Rows.Add(New Object() {"Waitlisted"})
        dtStatus.Rows.Add(New Object() {"Confirmed"})

        statusEdit.DataSource = dtStatus
    End Sub

    Private Sub initDatatables()
        Dim flightClms, bookingClms As DataColumn
        defaultIDVal = DB.CreateTable("SELECT dbo.SETID('tblBookingDetails')").Rows(0).Item(0).ToString()
        bookingClms = New DataColumn
        bookingClms.ColumnName = "PKey"
        bookingClms.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "FKeyTravelEvent"
        bookingClms.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "BookingRef"
        bookingClms.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "TicketCost"
        bookingClms.DataType = System.Type.GetType("System.Double")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "FKeyCurrency"
        bookingClms.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "InvoiceNbr"
        bookingClms.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "InvoiceDate"
        bookingClms.DataType = System.Type.GetType("System.DateTime")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "Rmks"
        bookingClms.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(bookingClms)

        bookingClms = New DataColumn
        bookingClms.ColumnName = "Status"
        bookingClms.DataType = System.Type.GetType("System.String")
        dtBookingDetails.Columns.Add(bookingClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "PKey"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "FKeyBookingDetail"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "FKeyAirline"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "Flight"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "Seq"
        flightClms.DataType = System.Type.GetType("System.Int32")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "FKeyAirportFrom"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "FKeyAirportTo"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "ETA"
        flightClms.DataType = System.Type.GetType("System.DateTime")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "ETD"
        flightClms.DataType = System.Type.GetType("System.DateTime")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "Status"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        flightClms = New DataColumn
        flightClms.ColumnName = "Rmks"
        flightClms.DataType = System.Type.GetType("System.String")
        dtFlightDetails.Columns.Add(flightClms)

        ds.Tables.Add(dtBookingDetails)
        ds.Tables.Add(dtFlightDetails)

        ds.Tables(0).TableName = "dtBookingDetails"
        ds.Tables(1).TableName = "dtFlightDetails"

        Dim clmUnique As UniqueConstraint = New UniqueConstraint(New DataColumn() {dtBookingDetails.Columns("PKey")}, True)
        Dim clmForeign As ForeignKeyConstraint = New ForeignKeyConstraint(New DataColumn() {dtBookingDetails.Columns("PKey")}, New DataColumn() {dtFlightDetails.Columns("FKeyBookingDetail")})

        ds.Tables("dtBookingDetails").Constraints.Add(clmUnique)
        ds.Tables("dtFlightDetails").Constraints.Add(clmForeign)

        ds.Relations.Add("FlightDetails", ds.Tables("dtBookingDetails").Columns("PKey"), ds.Tables("dtFlightDetails").Columns("FKeyBookingDetail"))
        gcBookingDetails.LevelTree.Nodes.Add("FlightDetails", gvFlightDetails)
        gcBookingDetails.DataSource = ds.Tables("dtBookingDetails")
        gcBookingDetails.ForceInitialize()
    End Sub

    Private Sub initControls()
        Select Case TravelEventType
            Case "TravelEvent"
                lblDateSign.Text = "* Date Sign-on"
                lblPlaceSign.Text = "* Place Sign-on"
                lblReqDate.Text = "* Req Arr Date"
            Case "TravelEvent_Returning"
                lblDateSign.Text = "* Date Sign-off"
                lblPlaceSign.Text = "* Place Sign-off"
                lblReqDate.Text = "* Req Dep Date"
        End Select

        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
    End Sub
#End Region

#Region "GridView Events"

#Region "gvCrewList"

    Private Sub gvCrewList_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gvCrewList.ShowingEditor
        If bAddMode = True Then
            If gvCrewList.FocusedColumn.FieldName = "isSelected" And IsDBNull(gvCrewList.GetRowCellValue(gvCrewList.FocusedRowHandle, "FKeyTravelEvent")) = False Then
                e.Cancel = True
            End If
        End If
        If isEditdable = True Then
            If gvCrewList.FocusedColumn.FieldName = "isSelected" And IsDBNull(gvCrewList.GetRowCellValue(gvCrewList.FocusedRowHandle, "FKeyTravelEvent")) = True Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub gvCrewList_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvCrewList.FocusedRowChanged
        If (bAddMode Or isEditdable) And BRECORDUPDATEDs = True And (IfNull(gvCrewList.GetGroupRowValue(gvCrewList.FocusedRowHandle, gvCrewList.Columns("FKeyTravelEvent")), "") <> "") Then
            CheckValidateFields()
            Exit Sub
        ElseIf isEditdable And (IfNull(gvCrewList.GetGroupRowValue(gvCrewList.FocusedRowHandle, gvCrewList.Columns("FKeyTravelEvent")), "") = "") And _
            IfNull(gvCrewList.GetGroupRowValue(gvCrewList.FocusedRowHandle, gvCrewList.Columns("FKeyTravelEvent")), "") <> focusedGroup Then
            'IfNull(gvCrewList.GetFocusedRowCellValue("FKeyPlanningEvent"), "") <> IfNull(gvCrewList.GetRowCellValue(e.PrevFocusedRowHandle, "FKeyPlanningEvent"), "") Then
            MsgBox("Adding new crew to a travel is not allowed.")
            Exit Sub
        End If

        If focusedGroup = IfNull(gvCrewList.GetGroupRowValue(gvCrewList.FocusedRowHandle, gvCrewList.Columns("FKeyTravelEvent")), "") Then
            'addRowsTodtBookingDetails(DB.CreateTable("SELECT * FROM tblBookingDetails WHERE 1 = 0"))
            addRowsTodtBookingDetails(DB.CreateTable("SELECT * FROM tblBookingDetails WHERE FKeyTravelEvent = '" & focusedGroup & "'"))
            Exit Sub
        End If

        isEditdable = False
        BRECORDUPDATEDs = False
        focusedGroup = IfNull(gvCrewList.GetGroupRowValue(gvCrewList.FocusedRowHandle, gvCrewList.Columns("FKeyTravelEvent")), "")
        If gvCrewList.DataRowCount > 0 Then
            'If (focusedGroup <> IfNull(gvCrewList.GetGroupRowValue(e.PrevFocusedRowHandle, gvCrewList.Columns("FKeyTravelEvent")), "")) Or gvCrewList.GroupCount = 1 Then
            dtTravelEvent = DB.CreateTable("SELECT * FROM tblTravelEvent WHERE PKey = '" & focusedGroup & "'")
            addRowsTodtBookingDetails(DB.CreateTable("SELECT * FROM tblBookingDetails WHERE FKeyTravelEvent = '" & focusedGroup & "'"))
            If dtTravelEvent.Rows.Count > 0 Then
                txtPlace.EditValue = dtTravelEvent.Rows(0).Item("DepPlace")
                txtArrPlace.EditValue = dtTravelEvent.Rows(0).Item("ArrPlace")
                deReqDate.EditValue = dtTravelEvent.Rows(0).Item("ReqArrDate")
                deDateReq.EditValue = dtTravelEvent.Rows(0).Item("DateReq")
                lePortAgent.EditValue = dtTravelEvent.Rows(0).Item("FKeyPortAgent")
                leInvoiceTo.EditValue = dtTravelEvent.Rows(0).Item("FKeyPrincipal")
                leTravelAgent.EditValue = dtTravelEvent.Rows(0).Item("FKeyTravelAgent")
                W.EditValue = dtTravelEvent.Rows(0).Item("Remarks")
            Else
                clearTravelEvent()
                dtBookingDetails.Clear()
                dtFlightDetails.Clear()
            End If
            'End If

            If TravelEventType = "TravelEvent_Returning" Then
                Dim dt As New DataTable
                focusedPlanID = IfNull(gvCrewList.GetGroupRowValue(gvCrewList.FocusedRowHandle, gvCrewList.Columns("FKeyPlanningEvent")), "")
                dt = DB.CreateTable("SELECT * FROM [dbo].[Planning_Events] WHERE PKey = '" & focusedPlanID & "'")
                If dt.Rows.Count > 0 Then
                    luPlaceSign.EditValue = dt.Rows(0).Item("PlannedPlaceSON")
                    deDateSign.EditValue = CDate(dt.Rows(0).Item("PlannedDateSON")).ToString("dd-MMM-yyyy")
                Else
                    luPlaceSign.EditValue = Nothing
                    deDateSign.EditValue = Nothing
                End If
            End If
        Else
            clearTravelEvent()
            dtBookingDetails.Clear()
            dtFlightDetails.Clear()
        End If
        disableControls(True)
            EditCheck(Name, False)
            AllowEditing(Name, True)
            AllowAddition(Name, True)
            AllowSaving(Name, False)
            'AllowDeletion(Name, False)
            isTravelEdited = False
    End Sub
#End Region

#Region "gvFlightDetails"
    Private Sub gvFlightDetails_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvFlightDetails.CellValueChanged
        If IsDBNull(e.Value) = False And bAddMode = False And e.Column.FieldName <> "Rmks" Then
            Dim dview As GridView = sender
            If dview.IsNewItemRow(e.RowHandle) Then
                dview.SetRowCellValue(e.RowHandle, "Rmks", "New")
            Else
                If dview.GetRowCellValue(e.RowHandle, "Rmks").ToString = "" Then
                    dview.SetRowCellValue(e.RowHandle, "Rmks", "Edited")
                End If
            End If
            BRECORDUPDATEDs = True
        End If
        'If bAddMode = True Or isEditdable = True Then
        '    e.Column.AppearanceCell.BackColor = EDITED_COLOR
        'End If
    End Sub
#End Region

#Region "gvBookingDetails"
    Private Sub gvBookingDetails_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvBookingDetails.CellValueChanged
        If IsDBNull(e.Value) = False And bAddMode = False And e.Column.FieldName <> "Rmks" Then
            Dim dview As GridView = sender
            If dview.IsNewItemRow(e.RowHandle) Then
                dview.SetRowCellValue(e.RowHandle, "Rmks", "New")
            Else
                If dview.GetRowCellValue(e.RowHandle, "Rmks").ToString = "" Then
                    dview.SetRowCellValue(e.RowHandle, "Rmks", "Edited")
                End If
            End If
            BRECORDUPDATEDs = True
        End If
    End Sub

    Private Sub gvBookingDetails_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvBookingDetails.CellValueChanging
        dtBookingDetails.Columns("PKey").DefaultValue = "SPECT" & (defaultIDVal.Substring(5, 10) + 1).ToString.PadLeft(10, "0")
        dtBookingDetails.Columns("Status").DefaultValue = "Waitlisted"
        defaultIDVal = "SPECT" & (defaultIDVal.Substring(5, 10) + 1).ToString.PadLeft(10, "0")
    End Sub

    Private Sub gvBookingDetails_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gvBookingDetails.CustomUnboundColumnData
        Dim rowIndex As Integer = e.ListSourceRowIndex
        Dim detailRows() As DataRow = dtFlightDetails.Select("FKeyBookingDetail = '" & gvBookingDetails.GetRowCellValue(gvBookingDetails.GetRowHandle(rowIndex), "PKey") & "'")
        Dim confirmedFlight As Integer = 0
        If e.Column.FieldName = "BookingStatus" Then
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub gvBookingDetails_GotFocus(sender As Object, e As System.EventArgs) Handles gvBookingDetails.GotFocus, gvFlightDetails.GotFocus, gvCrewList.GotFocus
        Dim gview As GridView = sender
        Select Case gview.Name
            Case "gvBookingDetails"
                deleteCap = "Delete Booking Detail"
            Case "gvFlightDetails"
                deleteCap = "Delete Flight Detail"
            Case "gvCrewList"
                deleteCap = "Delete Travel Event"
        End Select
        SetDeleteCaption(Name, deleteCap)
    End Sub

    Private Sub gvBookingDetails_MasterRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs) Handles gvBookingDetails.MasterRowCollapsing
        If bAddMode = True Or isEditdable = True Then
            Dim detailView As GridView = gvBookingDetails.GetDetailView(e.RowHandle, e.RelationIndex)
            If IsNothing(detailView) = False Then
                For i As Integer = 0 To detailView.DataRowCount - 1
                    If detailView.GetRowCellValue(i, "Rmks").ToString <> "" Then
                        e.Allow = False
                        Exit Sub
                    Else
                        If bAddMode = True Then
                            e.Allow = False
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub gvBookingDetails_MasterRowExpanding(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventArgs) Handles gvBookingDetails.MasterRowExpanding
        e.Allow = True
    End Sub

    Private Sub gvBookingDetails_MasterRowGetRelationCount(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles gvBookingDetails.MasterRowGetRelationCount
        If e.RowHandle < 0 Then
            e.RelationCount = 1
        End If
    End Sub

#End Region
#End Region

    Private Sub editModeGrids(ByVal bol As Boolean)
        gvCrewList.Columns("isSelected").Visible = bol
        If bol = True Then
            gvBookingDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            gvFlightDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
            gvBookingDetails.OptionsBehavior.ReadOnly = False
            gvFlightDetails.OptionsBehavior.ReadOnly = False

        Else
            gvBookingDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            gvFlightDetails.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            gvBookingDetails.OptionsBehavior.ReadOnly = True
            gvFlightDetails.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Private Sub clearTravelEvent()
        If TravelEventType = "TravelEvent_Returning" Then
            luPlaceSign.EditValue = Nothing
            deDateSign.EditValue = DBNull.Value
        End If
        txtPlace.EditValue = Nothing
        txtArrPlace.EditValue = Nothing
        deReqDate.EditValue = Nothing
        deDateReq.EditValue = Nothing
        lePortAgent.EditValue = Nothing
        leInvoiceTo.EditValue = Nothing
        leTravelAgent.EditValue = Nothing
        W.EditValue = Nothing
        dtFlightDetails.Clear()
        dtBookingDetails.Clear()
    End Sub

    Private Sub addRowsTodtBookingDetails(ByVal source As DataTable)
        Dim tblFlight As New DataTable
        dtFlightDetails.Rows.Clear()
        dtBookingDetails.Rows.Clear()

        For Each nrow In source.Rows
            If dtBookingDetails.Select("PKey='" & nrow("PKey") & "'").Count = 0 Then
                dtBookingDetails.Rows.Add(New Object() {nrow("PKey"), nrow("FKeyTravelEvent"), nrow("BookingRef"), nrow("TicketCost"), nrow("FKeyCurrency"), nrow("InvoiceNbr"), nrow("InvoiceDate"), ""})
            End If

            tblFlight = DB.CreateTable("SELECT * FROM tblFlightDetails WHERE FKeyBookingDetail = '" & nrow("PKey") & "'")
            For Each xrow In tblFlight.Rows
                If dtFlightDetails.Select("PKey='" & xrow("PKey") & "'").Count = 0 Then
                    dtFlightDetails.Rows.Add(New Object() {xrow("PKey"), xrow("FKeyBookingDetail"), xrow("FKeyAirline"), xrow("Flight"), xrow("Seq"), xrow("FKeyAirportFrom"), xrow("FKeyAirportTo"), xrow("ETA"), xrow("ETD"), xrow("Status"), ""})
                End If
            Next
        Next
        gvBookingDetails.RefreshData()
    End Sub

    Private Sub disableControls(ByVal bol As Boolean)
        txtPlace.ReadOnly = bol
        txtArrPlace.ReadOnly = bol
        deReqDate.ReadOnly = bol
        deDateReq.ReadOnly = bol
        lePortAgent.ReadOnly = bol
        leInvoiceTo.ReadOnly = bol
        leTravelAgent.ReadOnly = bol
        W.ReadOnly = bol
        editModeGrids(Not bol)
        luPlaceSign.ReadOnly = bol

        If TravelEventType = "TravelEvent_Returning" Then
            deDateSign.ReadOnly = bol
        End If

        If bol = True Then
            txtPlace.BackColor = DISABLED_COLOR
            txtArrPlace.BackColor = DISABLED_COLOR
            deReqDate.BackColor = DISABLED_COLOR
            deDateReq.BackColor = DISABLED_COLOR
            lePortAgent.BackColor = DISABLED_COLOR
            leInvoiceTo.BackColor = DISABLED_COLOR
            leTravelAgent.BackColor = DISABLED_COLOR
            W.BackColor = DISABLED_COLOR
            luPlaceSign.BackColor = DISABLED_COLOR
            deDateSign.BackColor = DISABLED_COLOR
        Else
            txtPlace.BackColor = REQUIRED_COLOR
            txtArrPlace.BackColor = REQUIRED_COLOR
            deReqDate.BackColor = REQUIRED_COLOR
            deDateReq.BackColor = REQUIRED_COLOR
            lePortAgent.BackColor = REQUIRED_COLOR
            leInvoiceTo.BackColor = REQUIRED_COLOR
            leTravelAgent.BackColor = REQUIRED_COLOR
            luPlaceSign.BackColor = REQUIRED_COLOR
            deDateSign.BackColor = REQUIRED_COLOR
        End If
    End Sub

    Private Sub leTravelAgent_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles leTravelAgent.ButtonClick
        If bAddMode = True Or isEditdable = True Then
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
                leTravelAgent.EditValue = Nothing
            End If
        End If
    End Sub

    Private Sub txtDepPlace_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtPlace.EditValueChanged, deDateReq.EditValueChanged, deReqDate.EditValueChanged, leInvoiceTo.EditValueChanged, lePortAgent.EditValueChanged, leTravelAgent.EditValueChanged, W.EditValueChanged, luPlaceSign.EditValueChanged, deDateSign.EditValueChanged, txtArrPlace.EditValueChanged
        If bAddMode = True Or isEditdable = True Then
            Dim cntrl As DevExpress.XtraEditors.TextEdit = TryCast(sender, DevExpress.XtraEditors.TextEdit)
            cntrl.BackColor = EDITED_COLOR
            isTravelEdited = True
            BRECORDUPDATEDs = True
            'txtPlace.Text = luPlaceSign.Text
            deReqDate.EditValue = deDateSign.EditValue
        End If
    End Sub

    Private Sub checkHasTravelEvent()
        For i As Integer = 0 To gvCrewList.DataRowCount - 1
            If IsDBNull(gvCrewList.GetRowCellValue(i, "FKeyTravelEvent")) = False Then
                gvCrewList.SetRowCellValue(i, "isSelected", True)
            End If
        Next
    End Sub

    Private Sub requiredFieldsBackColor()
        txtPlace.BackColor = REQUIRED_COLOR
        txtArrPlace.BackColor = REQUIRED_COLOR
        deReqDate.BackColor = REQUIRED_COLOR
        deDateReq.BackColor = REQUIRED_COLOR
        lePortAgent.BackColor = REQUIRED_COLOR
        leInvoiceTo.BackColor = REQUIRED_COLOR
        leTravelAgent.BackColor = REQUIRED_COLOR
        deDateSign.BackColor = REQUIRED_COLOR
        luPlaceSign.BackColor = REQUIRED_COLOR
    End Sub

#Region "Validations"
    Private Function validateRequiredFields() As Boolean
        Dim res As Boolean = False
        Dim detailView As GridView
        If txtPlace.Text = "" Or _
            txtArrPlace.Text = "" Or _
           deDateReq.Text = "" Or _
           deReqDate.Text = "" Or _
           lePortAgent.Text = "" Or _
           luPlaceSign.Text = "" Or _
           leInvoiceTo.Text = "" Then
            'IsNothing(leTravelAgent.EditValue) Or IsDBNull(leTravelAgent.EditValue) Or _
            res = True
            MessageBox.Show("Please enter data on required fields.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return res
        End If

        If gvBookingDetails.DataRowCount > 0 Then
            For i As Integer = 0 To gvBookingDetails.DataRowCount - 1
                For y As Integer = 0 To gvBookingDetails.Columns.Count - 1
                    If gvBookingDetails.Columns(y).Tag = "Required" Then
                        If gvBookingDetails.GetRowCellValue(i, gvBookingDetails.Columns(y).FieldName).ToString = "" Or IsNothing(gvBookingDetails.GetRowCellValue(i, gvBookingDetails.Columns(y).FieldName)) Or IsDBNull(gvBookingDetails.GetRowCellValue(i, gvBookingDetails.Columns(y).FieldName)) Then
                            res = True
                            MessageBox.Show("Please enter data on required fields.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return res
                            Exit Function
                        End If
                    End If
                Next

                detailView = gvBookingDetails.GetDetailView(i, 0)
                If IsNothing(detailView) = False Then
                    If detailView.RowCount > 0 Then
                        For x As Integer = 0 To detailView.RowCount - 1
                            For p As Integer = 0 To detailView.Columns.Count - 1
                                If detailView.Columns(p).Tag = "Required" Then
                                    If detailView.GetRowCellValue(x, detailView.Columns(p).FieldName).ToString = "" Then 'IsNothing(detailView.GetRowCellValue(x, detailView.Columns(p).FieldName)) Or IsDBNull(detailView.GetRowCellValue(x, detailView.Columns(p).FieldName)) Then
                                        res = True
                                        MessageBox.Show("Please enter data on required fields.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Return res
                                        Exit Function
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Next
        End If

        Return res
    End Function

    Private Function checkIfHasSelectedCrew() As Boolean
        Dim res As Boolean = True
        If bAddMode = True Then
            If gvCrewList.DataRowCount > 0 Then
                For i As Integer = 0 To gvCrewList.DataRowCount - 1
                    If gvCrewList.GetRowCellValue(i, "FKeyTravelEvent").ToString = "" Then
                        If gvCrewList.GetRowCellValue(i, "isSelected") = True Then
                            res = False
                            Return res
                            Exit Function
                        End If
                    End If
                Next
            End If
        End If
        Return res
    End Function
#End Region

    Public Overrides Sub ExecCustomFunction(param() As Object)
        Try
            If focusedGroup = "" Then
                MessageBox.Show("Select an existing travel event or add and save a new travel event in order to view this report.", "MPS5 - Planning Event", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim repClass As New CrewFlightReq(DB, gvCrewList.GetFocusedDataRow("FKeyTravelEvent").ToString, IIf(TravelEventType = "TravelEvent", "Joining", "Returning"))
                repClass.showPreview()
            End If
        Catch ex As Exception
            MsgBox("Unable to generate report source. " & Chr(13) & "Error " & ex.Message, vbExclamation)
        End Try
    End Sub

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

#Region "Save/Load Layout"
    Public Overrides Sub SaveMainContentLayout()
        MyBase.SaveMainContentLayout() 'this will create a path for layouts if path does not exist
        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\" 'layout path saved on local app layout folder
        gvCrewList.SaveLayoutToXml(strLayoutPath & "Travel_gvCrewList_Layout.xml") 'save gridview layout in local app layout folder
        gvBookingDetails.SaveLayoutToXml(strLayoutPath & "DMS_gvBookingDetails_Layout.xml")
        Dim strSplitterPositions As String
        strSplitterPositions = SplitContainerControl2.SplitterPosition & ";" & SplitContainerControl3.SplitterPosition 'concut splittercontainer positions
        Dim wtr As IO.StreamWriter = System.IO.File.CreateText(strLayoutPath & "Travel_SplitterPositions.txt") 'create a text file in local app layout folter that will contain the splittercontainer positions
        Using wtr
            wtr.WriteLine(strSplitterPositions) 'write strSplitterPositions in the text file created
        End Using
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        Try
            MyBase.LoadMainContentLayout() 'this do nothing "YET", no future plans for this :D
            Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\" 'again get the local app layout folder..
            Dim rdr As IO.StreamReader = System.IO.File.OpenText(strLayoutPath & "Travel_SplitterPositions.txt") 'open the text file that contains splitter positions
            gvCrewList.RestoreLayoutFromXml(strLayoutPath & "Travel_gvCrewList_Layout.xml") 'restore the gridview layout
            gvBookingDetails.RestoreLayoutFromXml(strLayoutPath & "DMS_gvBookingDetails_Layout.xml")
            Using rdr
                Dim nSplitterPositions() As String = rdr.ReadLine().ToString.Split(";") 'get the splitter positions insert in an array
                SplitContainerControl2.SplitterPosition = nSplitterPositions(0) 'assign the splitter position from text file to splitter
                SplitContainerControl3.SplitterPosition = nSplitterPositions(1)
            End Using
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub gvFlightDetails_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles gvFlightDetails.InvalidRowException, gvBookingDetails.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub gvFlightDetails_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvFlightDetails.ValidateRow, gvBookingDetails.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        For i As Integer = 0 To view.Columns.Count - 1
            If view.Columns(i).Tag = "Required" Then
                If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns(i))) = True Then
                    e.Valid = False
                    view.GetDataRow(e.RowHandle).SetColumnError(view.Columns(i).FieldName, "This field cannot be empty.")
                    AllowSaving(Name, False)
                    Exit Sub
                End If
            End If
        Next
        view.GetDataRow(e.RowHandle).ClearErrors()
        AllowSaving(Name, True)
    End Sub
End Class
