Imports MPS4.GTRSServiceReference

Public Class frmGTravelSample

    Dim gtAddPassenger As New GTRSServiceReference.AddPassenger

    Private Sub EnableTabPages(Optional val As Boolean = True)
        For Each tp As TabPage In tabcommands.TabPages
            tp.Enabled = IIf(val, True, tp.Name = "tabAuthenticateUser")
        Next
    End Sub

    Private Sub btnOK_AuthenticateUser_Click(sender As System.Object, e As System.EventArgs) Handles btnOK_AuthenticateUser.Click


        'Dim oGTravelRequest As New modGTravel.GTravelRequestClass

        Dim oGTCredential As New GTRSServiceReference.credentials

        oGTCredential.username = txtUsername.Text
        oGTCredential.password = txtPassword.Text

        Dim oAuthenticateUserResponse As AuthenticateUserResponse = oGTRSTester.AuthenticateUser(oGTCredential)

        If oGTRSTester.UserAuthenticated Then
            UserAuthenticated(oAuthenticateUserResponse.userDetails.clientID, oAuthenticateUserResponse.userDetails.userID, oAuthenticateUserResponse.userDetails.departmentID)
        End If
        'Dim gtAuthenticateUser As New GTravelWebService.AuthenticateUser
        'Dim gtAuthenticateUserResponse As New GTravelWebService.AuthenticateUserResponse

        'Dim c As New GTravelWebService.credentials

        'With c
        '    c.username = txtUsername.Text
        '    c.password = txtPassword.Text
        'End With

        ''With gtAuthenticateUser.credentials
        ''    .username = txtUsername.Text
        ''    .password = txtPassword.Text
        ''End With

        'gtAuthenticateUser.credentials = c


        ''gtAuthenticateUserResponse.userDetails.userID
        'With gtAuthenticateUserResponse.userDetails
        '    txtUserID.Text = .userID
        '    txtClientID.Text = .clientID
        '    txtDepartmentID.Text = .departmentID
        'End With

        'Using client As GTravelServiceReference.OCSService = New GTravelServiceReference.OCSService

        'End Using
        'Dim OCSServiceClient As GTravelWebService.OCSServicePort.ocs = New GTravelWebService


        '---------------------------------------------
        'Dim client As OCSServiceClient = New OCSServiceClient

        'Dim viaUser As New AuthenticateUser
        'Dim viaCredentials As New credentials

        'viaCredentials.username = txtUsername.Text
        'viaCredentials.password = txtPassword.Text

        'viaUser.credentials = viaCredentials

        'Try
        '    Dim response As AuthenticateUserResponse = client.AuthenticateUser(viaUser)
        '    txtUserID.Text = response.userDetails.userID
        '    txtClientID.Text = response.userDetails.clientID
        '    txtDepartmentID.Text = response.userDetails.departmentID


        '    Dim oAddPassenger As New AddPassenger
        '    Dim oPassenger As New passenger

        '    Dim i As New CreateTravelRequest

        '    oPassenger.firstName = "test"
        '    oAddPassenger.passenger = oPassenger


        '    'Dim response2 As AddPassengerResponse= client.AddPassenger(
        'Catch ex As Exception

        'End Try


        'Dim gtCredential As New credentials
        'Dim oAuthenticateUserResponse As New AuthenticateUserResponse
        'gtCredential.username = txtUsername.Text
        'gtCredential.password = txtPassword.Text
        'oAuthenticateUserResponse = modGTravel.AuthenticateUser(gtCredential)


        'If IsNothing(oAuthenticateUserResponse.userDetails) Then
        '    MsgBox("Unable to authenticate user")
        'Else
        '    With oAuthenticateUserResponse.userDetails
        '        txtUserID.Text = .userID
        '        txtClientID.Text = .clientID
        '        txtDepartmentID.Text = .departmentID

        '        txtUserID_TravelRequest.Text = .userID
        '        txtClientID_TravelRequest.Text = .clientID
        '    End With

        'End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        EnableTabPages(False)

        txtUsername.Text = "ocsspectral"
        txtPassword.Text = "ocsspectral"

        'txtCurrentDate.Text = Now()
    End Sub


    Private Sub UserAuthenticated(ClientID, UserID, DepartmentID)
        txtClientID.Text = ClientID
        txtClientID_TravelRequest.Text = ClientID

        txtDepartmentID.Text = DepartmentID
        txtDepartmentID_TravelRequest.Text = DepartmentID

        txtUserID.Text = UserID
        txtUserID_TravelRequest.Text = UserID

        EnableTabPages()
        InitDates()
    End Sub

    Private Sub SetTravelRequestID(TravelRequestID)
        txtTravelRequestID.Text = TravelRequestID
        txtTravelRequestID_AddPassenger.Text = TravelRequestID
        txttravelRequestID_Cancel.Text = TravelRequestID
        txttravelRequestID_View.Text = TravelRequestID
    End Sub

    Private Sub SetPassengerID(PassengerID)
        txtPassengerID.Text = PassengerID
        txtPassengerID_Cancel.Text = PassengerID
    End Sub

    Private Sub InitDates()
        Dim strDate As String = ChangeToGTRSDate(System.DateTime.Now)
        txtCurrentDate.Text = strDate
        txtDueDate.Text = strDate
        txtLeadTime.Text = 0
        txtETAE.Text = strDate
        txtETAL.Text = strDate
        txtETD.Text = strDate
    End Sub

    'Public Function AddPassenger(request As GTravelServiceReference.AddPassengerRequest) As GTravelServiceReference.AddPassengerResponse1 Implements GTravelServiceReference.OCSService.AddPassenger

    'End Function

    'Public Function AuthenticateUser(request As GTravelServiceReference.AuthenticateUserRequest) As GTravelServiceReference.AuthenticateUserResponse1 Implements GTravelServiceReference.OCSService.AuthenticateUser

    'End Function

    'Public Function CancelPassenger(request As GTravelServiceReference.CancelPassengerRequest) As GTravelServiceReference.CancelPassengerResponse1 Implements GTravelServiceReference.OCSService.CancelPassenger

    'End Function

    'Public Function CancelTravelRequest(request As GTravelServiceReference.CancelTravelRequestRequest) As GTravelServiceReference.CancelTravelRequestResponse1 Implements GTravelServiceReference.OCSService.CancelTravelRequest

    'End Function

    'Public Function CreateTravelRequest(request As GTravelServiceReference.CreateTravelRequestRequest) As GTravelServiceReference.CreateTravelRequestResponse1 Implements GTravelServiceReference.OCSService.CreateTravelRequest

    'End Function

    'Public Function UpdatePassenger(request As GTravelServiceReference.UpdatePassengerRequest) As GTravelServiceReference.UpdatePassengerResponse1 Implements GTravelServiceReference.OCSService.UpdatePassenger

    'End Function

    'Public Function UpdateTravelRequest(request As GTravelServiceReference.UpdateTravelRequestRequest) As GTravelServiceReference.UpdateTravelRequestResponse1 Implements GTravelServiceReference.OCSService.UpdateTravelRequest

    'End Function

    'Public Function ViewTravelRequest(request As GTravelServiceReference.ViewTravelRequestRequest) As GTravelServiceReference.ViewTravelRequestResponse1 Implements GTravelServiceReference.OCSService.ViewTravelRequest

    'End Function

    'Public Function ViewTravelRequestByDate(request As GTravelServiceReference.ViewTravelRequestByDateRequest) As GTravelServiceReference.ViewTravelRequestByDateResponse1 Implements GTravelServiceReference.OCSService.ViewTravelRequestByDate

    'End Function

    Private Sub btnCreateTravelRequest_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateTravelRequest.Click
        Dim oCreateTravelRequestResponse As New CreateTravelRequestResponse
        Dim oCreateTravelRequest As New CreateTravelRequest
        Dim oTravelRequest As New travelRequest

        With oTravelRequest
            .vesselName = txtVesselName.Text
            .portName = txtPortName.Text
            .currentDate = txtCurrentDate.Text
            .dueDate = txtDueDate.Text
            .leadTime = txtLeadTime.Text
            .etae = txtETAE.Text
            .etal = txtETAL.Text
            .etd = txtETD.Text
            .remarks = txtRemarks_TravelRequest.Text
            .transactionReference = txtTransactionRef.Text
            .allocation1 = txtAllocation1.Text
            .allocation2 = txtAllocation2.Text
            .allocation3 = txtAllocation3.Text
            .nearestAirport = txtNearestAirport.Text
            .clientID = txtClientID_TravelRequest.Text
            .userID = txtUserID_TravelRequest.Text
            .departmentID = txtDepartmentID_TravelRequest.Text
        End With

        oCreateTravelRequest.travelRequest = oTravelRequest


        oCreateTravelRequestResponse = oGTRSTester.ServiceClient.CreateTravelRequest(oCreateTravelRequest)

        If Not IsNothing(oCreateTravelRequestResponse) Then
            SetTravelRequestID(oCreateTravelRequestResponse.travelRequestID)
        End If

    End Sub


    Private Sub btnUpdateTravelRequest_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateTravelRequest.Click
        Dim oUpdateTravelRequestResponse As New UpdateTravelRequestResponse
        Dim oUpdateTravelRequest As New UpdateTravelRequest
        Dim otravelRequestUpdate As New travelRequestUpdate

        With otravelRequestUpdate
            .vesselName = txtVesselName.Text
            .portName = txtPortName.Text
            .currentDate = txtCurrentDate.Text
            .dueDate = txtDueDate.Text
            .leadTime = txtLeadTime.Text
            .etae = txtETAE.Text
            .etal = txtETAL.Text
            .etd = txtETD.Text
            .remarks = txtRemarks_TravelRequest.Text
            .transactionReference = txtTransactionRef.Text
            .allocation1 = txtAllocation1.Text
            .allocation2 = txtAllocation2.Text
            .allocation3 = txtAllocation3.Text
            .nearestAirport = txtNearestAirport.Text
            .travelRequestID = txtTravelRequestID.Text
            .clientID = txtClientID_TravelRequest.Text
            .userID = txtUserID_TravelRequest.Text
            .departmentID = txtDepartmentID_TravelRequest.Text
        End With

        oUpdateTravelRequest.travelRequestUpdate = otravelRequestUpdate


        oUpdateTravelRequestResponse = oGTRSTester.ServiceClient.UpdateTravelRequest(oUpdateTravelRequest)

        'If Not IsNothing(oUpdateTravelRequestResponse) Then
        '    MsgBox("Update Sent." & vbNewLine & "Status: " & oUpdateTravelRequestResponse.updateStatus, MsgBoxStyle.Information)
        'Else
        '    MsgBox("Update failed.", MsgBoxStyle.Critical)
        'End If

        ShowStatus(oUpdateTravelRequestResponse)
    End Sub

    Private Sub btnCreate_AddPassenger_Click(sender As System.Object, e As System.EventArgs) Handles btnCreate_AddPassenger.Click
        Dim oAddPassenger As New AddPassenger
        Dim oAddPassengerResponse As New AddPassengerResponse
        Dim oPassenger As New passenger

        With oPassenger
            .employeeNo = txtemployeeNo.Text
            .lastName = txtLastName.Text
            .firstName = txtFirstName.Text
            .dateOfBirth = txtDateOfBirth.Text
            .placeOfBirth = txtPlaceOfBirth.Text
            .passportNo = txtPassportNo.Text
            .passportIssuedDate = txtpassportIssueDate.Text
            .passportExpiryDate = txtpassportExpiryDate.Text
            .passportPlaceIssue = txtpassportPlaceIssue.Text
            .seamansBookNo = txtseamanBookNo.Text
            .seamanIssuedDate = txtseamanIssuedDate.Text
            .seamanExpiryDate = txtpassportExpiryDate.Text
            .seamanPlaceIssue = txtseamanPlaceIssue.Text
            .position = txtposition.Text
            .nearestAirport = txtnearestAirport_AddPassenger.Text
            .nationality = txtnationality.Text
            .cellphone = txtcelphone.Text
            .phone = txtphone.Text
            .email = txtemail.Text
            .alternateAirport = txtalternateairport.Text
            .recruitingOffice = txtrecruitingOffice.Text
            .frequentFlyerMemberShip = txtfrequentFlyerMemberShip.Text
            .frequentFlyerNumber = txtfrequentFlyerNumber.Text
            .gender = txtgender.Text
            .visa = txtVisa.Text
            .allocation1 = txtAllocation1_AddPassenger.Text
            .allocation2 = txtAllocation2_AddPassenger.Text
            .allocation3 = txtAllocation3_AddPassenger.Text
            .earliestArrival = txtEarliestArrival.Text
            .latestArrival = txtlatestArrival.Text
            .requestType = txtrequestType.Text
            .earliestDeparture = txtEarliestDeparture.Text
            .travelRequestID = txtTravelRequestID_AddPassenger.Text
        End With

        oAddPassenger.passenger = oPassenger

        oAddPassengerResponse = oGTRSTester.ServiceClient.AddPassenger(oAddPassenger)

        If Not IsNothing(oAddPassengerResponse) Then
            SetPassengerID(oAddPassengerResponse.passengerID)
        End If
    End Sub

    Private Sub btnUpdate_AddPassenger_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate_AddPassenger.Click
        Dim oUpdatePassenger As New UpdatePassenger
        Dim oUpdatePassengerResponse As New UpdatePassengerResponse
        Dim oPassengerUpdate As New passengerUpdate

        With oPassengerUpdate
            .passengerID = txtPassengerID.Text
            .employeeNo = txtemployeeNo.Text
            .lastName = txtLastName.Text
            .firstName = txtFirstName.Text
            .dateOfBirth = txtDateOfBirth.Text
            .placeOfBirth = txtPlaceOfBirth.Text
            .passportNo = txtPassportNo.Text
            .passportIssuedDate = txtpassportIssueDate.Text
            .passportExpiryDate = txtpassportExpiryDate.Text
            .passportPlaceIssue = txtpassportPlaceIssue.Text
            .seamansBookNo = txtseamanBookNo.Text
            .seamanIssuedDate = txtseamanIssuedDate.Text
            .seamanExpiryDate = txtpassportExpiryDate.Text
            .seamanPlaceIssue = txtseamanPlaceIssue.Text
            .position = txtposition.Text
            .nearestAirport = txtnearestAirport_AddPassenger.Text
            .nationality = txtnationality.Text
            .cellphone = txtcelphone.Text
            .phone = txtphone.Text
            .email = txtemail.Text
            .alternateAirport = txtalternateairport.Text
            .recruitingOffice = txtrecruitingOffice.Text
            .frequentFlyerMemberShip = txtfrequentFlyerMemberShip.Text
            .frequentFlyerNumber = txtfrequentFlyerNumber.Text
            .gender = txtgender.Text
            .visa = txtVisa.Text
            .allocation1 = txtAllocation1_AddPassenger.Text
            .allocation2 = txtAllocation2_AddPassenger.Text
            .allocation3 = txtAllocation3_AddPassenger.Text
            .earliestArrival = txtEarliestArrival.Text
            .latestArrival = txtlatestArrival.Text
            .requestType = txtrequestType.Text
            .earliestDeparture = txtEarliestDeparture.Text
            .travelRequestID = txtTravelRequestID_AddPassenger.Text

        End With

        oUpdatePassenger.passengerUpdate = oPassengerUpdate

        oUpdatePassengerResponse = oGTRSTester.ServiceClient.UpdatePassenger(oUpdatePassenger)

        'If Not IsNothing(oUpdatePassengerResponse) Then
        '    MsgBox("Update Sent." & vbNewLine & "Status: " & oUpdatePassengerResponse.updateStatus, MsgBoxStyle.Information)
        'Else
        '    MsgBox("Update failed.", MsgBoxStyle.Critical)
        'End If
        ShowStatus(oUpdatePassengerResponse)
    End Sub

    Private Sub btnCancelTravelRequest_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelTravelRequest.Click
        Dim oCancelTravelRequest As New CancelTravelRequest
        Dim oCancelTravelRequestResponse As New CancelTravelRequestResponse

        oCancelTravelRequest.travelRequestID = txttravelRequestID_Cancel.Text

        oCancelTravelRequestResponse = oGTRSTester.ServiceClient.CancelTravelRequest(oCancelTravelRequest)

        ShowStatus(oCancelTravelRequestResponse)
    End Sub


    Private Sub ShowStatus(obj As Object)
        If Not IsNothing(obj) Then
            MsgBox("Update Sent." & vbNewLine & "Status: " & obj.updateStatus, MsgBoxStyle.Information)
        Else
            MsgBox("Update failed.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnCancelPassenger_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelPassenger.Click
        Dim oCancelPassenger As New CancelPassenger
        Dim oCancelPassengerResponse As New CancelPassengerResponse

        oCancelPassenger.passengerID = txtPassengerID.Text

        oCancelPassengerResponse = oGTRSTester.ServiceClient.CancelPassenger(oCancelPassenger)

        ShowStatus(oCancelPassengerResponse)
    End Sub

    Private Sub btnViewTravelRequest_Click(sender As System.Object, e As System.EventArgs) Handles btnViewTravelRequest.Click
        Dim oViewTravelRequest As New ViewTravelRequest
        Dim oViewTravelRequestResponse As New ViewTravelRequestResponse

        oViewTravelRequest.travelRequestID = txttravelRequestID_View.Text

        oViewTravelRequestResponse = oGTRSTester.ServiceClient.ViewTravelRequest(oViewTravelRequest)
        'MsgBox(oViewTravelRequestResponse.ocsTransactions.Length)

        'Dim result As System.Text.StringBuilder
        'For i As Integer = 0 To oViewTravelRequestResponse.ocsTransactions.Length - 1
        '    result = New System.Text.StringBuilder
        '    result.AppendLine("amaName : " & oViewTravelRequestResponse.ocsTransactions(i).amaName)
        '    result.AppendLine("arrivalTime : " & oViewTravelRequestResponse.ocsTransactions(i).arrivalTime)
        '    result.AppendLine("classOfService : " & oViewTravelRequestResponse.ocsTransactions(i).classOfService)
        '    result.AppendLine("company : " & oViewTravelRequestResponse.ocsTransactions(i).company)
        '    result.AppendLine("cost : " & oViewTravelRequestResponse.ocsTransactions(i).cost)
        '    result.AppendLine("costRating : " & oViewTravelRequestResponse.ocsTransactions(i).costRating)
        '    result.AppendLine("costRatingDivision : " & oViewTravelRequestResponse.ocsTransactions(i).costRatingDivision)
        '    result.AppendLine("currency : " & oViewTravelRequestResponse.ocsTransactions(i).currency)
        '    result.AppendLine("departureTime : " & oViewTravelRequestResponse.ocsTransactions(i).departureTime)
        '    result.AppendLine("destination : " & oViewTravelRequestResponse.ocsTransactions(i).destination)
        '    result.AppendLine("destinationDesc : " & oViewTravelRequestResponse.ocsTransactions(i).destinationDesc)
        '    result.AppendLine("employeeNo : " & oViewTravelRequestResponse.ocsTransactions(i).employeeNo)
        '    result.AppendLine("flightnumber : " & oViewTravelRequestResponse.ocsTransactions(i).flightnumber)
        '    result.AppendLine("itemType : " & oViewTravelRequestResponse.ocsTransactions(i).itemType)
        '    result.AppendLine("origin : " & oViewTravelRequestResponse.ocsTransactions(i).origin)
        '    result.AppendLine("originDesc : " & oViewTravelRequestResponse.ocsTransactions(i).originDesc)
        '    result.AppendLine("reference : " & oViewTravelRequestResponse.ocsTransactions(i).reference)
        '    result.AppendLine("status : " & oViewTravelRequestResponse.ocsTransactions(i).status)

        '    MsgBox(result.ToString)
        'Next

        Dim dtResult As DataTable = CreateViewTravelRequestTable()
        Dim row As DataRow

        For i As Integer = 0 To oViewTravelRequestResponse.ocsTransactions.Length - 1
            row = dtResult.NewRow
            row.ItemArray = New Object() {oViewTravelRequestResponse.ocsTransactions(i).amaName, _
                                         oViewTravelRequestResponse.ocsTransactions(i).arrivalTime, _
                                         oViewTravelRequestResponse.ocsTransactions(i).classOfService, _
                                         oViewTravelRequestResponse.ocsTransactions(i).company, _
                                         oViewTravelRequestResponse.ocsTransactions(i).cost, _
                                         oViewTravelRequestResponse.ocsTransactions(i).costRating, _
                                         oViewTravelRequestResponse.ocsTransactions(i).costRatingDivision, _
                                         oViewTravelRequestResponse.ocsTransactions(i).currency, _
                                         oViewTravelRequestResponse.ocsTransactions(i).departureTime, _
                                         oViewTravelRequestResponse.ocsTransactions(i).destination, _
                                         oViewTravelRequestResponse.ocsTransactions(i).destinationDesc, _
                                         oViewTravelRequestResponse.ocsTransactions(i).employeeNo, _
                                         oViewTravelRequestResponse.ocsTransactions(i).flightnumber, _
                                         oViewTravelRequestResponse.ocsTransactions(i).itemType, _
                                         oViewTravelRequestResponse.ocsTransactions(i).origin, _
                                         oViewTravelRequestResponse.ocsTransactions(i).originDesc, _
                                         oViewTravelRequestResponse.ocsTransactions(i).reference, _
                                         oViewTravelRequestResponse.ocsTransactions(i).status}
            dtResult.Rows.Add(row)

        Next

        ViewTravelRequestGrid.DataSource = dtResult
    End Sub

    Private Function CreateViewTravelRequestTable() As DataTable
        Dim _tbl As New DataTable
        Dim ccolumn As DataColumn
        Dim fldList As String() = New String() {"amaName", _
                                                "arrivalTime", _
                                                "classOfService", _
                                                "company", _
                                                "cost", _
                                                "costRating", _
                                                "costRatingDivision", _
                                                "currency", _
                                                "departureTime", _
                                                "destination", _
                                                "destinationDesc", _
                                                "employeeNo", _
                                                "flightnumber", _
                                                "itemType", _
                                                "origin", _
                                                "originDesc", _
                                                "reference", _
                                                "status"}

        For i As Integer = 0 To fldList.GetUpperBound(0)
            ccolumn = New DataColumn
            ccolumn.ColumnName = fldList(i)
            ccolumn.DataType = System.Type.GetType("System.String")
            _tbl.Columns.Add(ccolumn)
        Next

        Return _tbl
    End Function

    Private Sub txttravelRequestID_View_TextChanged(sender As System.Object, e As System.EventArgs) Handles txttravelRequestID_View.TextChanged
        ViewTravelRequestGrid.DataSource = ""
    End Sub

End Class