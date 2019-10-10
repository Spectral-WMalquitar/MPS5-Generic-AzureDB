Imports MPS4.GTRSServiceReference

Public Module modGTRS
    Private Const DefaultClientID As String = "00000000-0000-0000-0000-000000000000"
    Private Const IDFormat As String = "00000000-0000-0000-0000-000000000000"
    Public GTRS_FEATURE_AVAILABLE As Object

    Public Const GTRS_DEFAULT_ENDPOINTURL As String = "https://gtrsapi.gtravel.no:8078/"

    Public oGTRS As GTRSService = Nothing
    Public oGTRSTester As New GTRSServiceTester

    'Public oGTRS As Object = Nothing
    'Public oGTRSTester As New Object
#Region "GTRS Service Tester"
    Public Class GTRSServiceTester
        Public ServiceClient As New GTRSServiceReference.OCSServiceClient

        Public UserAuthenticated As Boolean = False

        Public Sub New()

        End Sub

        'Public Sub New(ocredential As GTravelServiceReference.credentials)
        '    AuthenticateUser(ocredential)
        'End Sub

        ' ''' <summary>
        ' ''' Opens the GTravel Client Object
        ' ''' Credential is retrieved from the database
        ' ''' </summary>
        ' ''' <remarks></remarks>
        'Public Sub Open()
        '    ServiceClient = New GTravelServiceReference.OCSServiceClient
        'End Sub

        ' ''' <summary>
        ' ''' Opens the GTravel Client Object
        ' ''' Credential is passed through parameter
        ' ''' </summary>
        ' ''' <param name="ocredential">Username and password client credential</param>
        ' ''' <remarks></remarks>
        'Public Sub Open(ocredential As GTravelServiceReference.credentials)
        '    ServiceClient = New GTravelServiceReference.OCSServiceClient
        '    AuthenticateUser(ocredential)
        'End Sub


        'AutheticateUser
        Public Function AuthenticateUser(ocredential As GTRSServiceReference.credentials) As GTRSServiceReference.AuthenticateUserResponse
            Dim response As GTRSServiceReference.AuthenticateUserResponse
            Dim viaUser As New GTRSServiceReference.AuthenticateUser
            'Dim viaCredentials As New credentials

            'gtCredential : credentials
            '   gtCredential.username
            '   gtCredential.password

            viaUser.credentials = ocredential

            Try
                response = ServiceClient.AuthenticateUser(viaUser)

            Catch ex As Exception
                response = Nothing
            End Try

            If Not response Is Nothing Then
                UserAuthenticated = response.userDetails.clientID <> DefaultClientID
            End If

            Return response
        End Function

        'Public Function CreateTravelRequest(gtCredential As GTravelServiceReference.credentials) As GTravelServiceReference.AuthenticateUserResponse

        '    Dim viaUser As New GTravelServiceReference.AuthenticateUser
        '    'Dim viaCredentials As New credentials

        '    'viaCredentials.username = oGTCredential.username
        '    'viaCredentials.password = oGTCredential.password

        '    viaUser.credentials = gtCredential

        '    Try
        '        Dim response As GTravelServiceReference.CreateTravelRequestResponse = oGTravel.CreateTravelRequestRespons
        '        Return response
        '    Catch ex As Exception
        '        Return Nothing
        '    End Try
        'End Function
    End Class
#End Region

#Region "Enumarations"
    Public Enum UserAuthentication
        None
        Invalid
        Success
    End Enum

    Public Enum GTRSServiceStatus
        Okay = 1
        NotOkay = 2
        NotEnabled = 3
    End Enum

    Public Structure GTRSConfigCode
        Public Shared Account As String = "GTRSACCOUNT"
        Public Shared Password As String = "GTRSPWD"
        Public Shared EndpointURL As String = "GTRSENDPOINTURL"
        Public Shared ResponseRate_Hours As String = "GTRSRESPONSERATE_HOURS"
        Public Shared ResponseRate_Minutes As String = "GTRSRESPONSERATE_MINS"
    End Structure

    Public Structure PassengerRequestType
        Public Shared Embark As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("EMBARK", "Embarkation")
        Public Shared Disembark As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("DISEMBARK", "Disembarkation")
        Public Shared Course As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("COURSE", "Course")
        Public Shared TravelPlan As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("TRAVELPLAN", "TravelPlan")

    End Structure

    Public Structure TravelBookingStatus
        Public Shared NewRequest As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("SYSBSNEW", "New")
        Public Shared InProgress As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("SYSBSINPROG", "In Progress")
        Public Shared Booked As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("SYSBSBOOKED", "Booked")
        Public Shared Canceled As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("SYSBSCANCELED", "Canceled")

    End Structure
#End Region

#Region "GTRS Service"
    Public Class GTRSService
        Public ServiceClient As New OCSServiceClient
        Public ClientInfo As New userDetails
        Public UserCredential As credentials = Nothing
        Public clsAudit As clsAudit

        Public Structure DefaultErrorMessages
            Public Shared NoBookingDetailsYet As String = "No booking details yet."
        End Structure


        Private _LastErrorMessage As String
        Public ReadOnly Property LastErrorMessage As String
            Get
                Return IfNull(_LastErrorMessage, "")
            End Get
        End Property

        Public Sub ClearLastErrorMessage()
            _LastErrorMessage = ""
        End Sub

        Public MyStatus As GTRSServiceStatus = Nothing
        Public MyStatusDesc As String = ""

#Region "New"
        Public Sub New()
            SendEndpointAddress(MPSDB.GetConfig("GTRSENDPOINTURL"))
        End Sub

        Public Sub New(cEndpointAddress As String)
            SendEndpointAddress(cEndpointAddress)
        End Sub
#End Region

#Region "EndPoint Address"
        Private Sub SendEndpointAddress(cEndpointAddress As String)
            Try
                ServiceClient.Endpoint.Address = New System.ServiceModel.EndpointAddress(cEndpointAddress)
            Catch ex As Exception
                modGTRS.LogProcess("Error setting endpoint address to: " & cEndpointAddress)
                modGTRS.LogProcess("")
            End Try
        End Sub
#End Region

#Region "Initialization"

        Public Sub Init()
            If MyStatus = GTRSServiceStatus.NotEnabled Or MyStatus = GTRSServiceStatus.Okay Then
                Exit Sub
            End If

            modGTRS.LogProcess("[Initializiting GTRS Integration Service Control...]")
            modGTRS.LogProcess("")

            'CHECK IF FEATURE IS ENABLED. EXITS IF NOT
            If Not CheckIfFeatureEnabled() Then
                MyStatus = GTRSServiceStatus.NotEnabled
                Exit Sub
            End If

            'CHECK INTERNET CONNECTION
            If Not CheckForInternetConnection() Then
                MyStatus = GTRSServiceStatus.NotOkay
                MyStatusDesc = "Cannot Connect to the Internet"
                modGTRS.LogProcess("Failed to establish internet connection.")
                modGTRS.LogProcess("")
                LogGTRSTransaction(New TransactionLogInfo(TransactionType.NotApplicable, "", "GTRS Service", "", "Initializing GTRS Integration Object", "Checking internet connection"), "Cannot connect to the internet.")
                Exit Sub
            End If

            'START INITIALIZATION IF NOT YET INITIALIZED
            If IsNothing(MyStatus) Or MyStatus = 0 Then
                ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Initializing GTRS Service Control...")
                UserCredential = GetGTRSCredential()


                If Not IsNothing(UserCredential) Then
                    modGTRS.LogProcess("Checking User Authentication...")
                    modGTRS.LogProcess("  Username: " & UserCredential.username)
                    modGTRS.LogProcess("  Password: " & New String("*"c, IfNull(UserCredential.password, "").Length))
                    modGTRS.LogProcess("")
                    modGTRS.LogProcess("")

                    Dim response As AuthenticateUserResponse = AuthenticateUser(UserCredential)

                    If Not IsNothing(response) Then
                        If Not IsNothing(response.userDetails.userID) Then
                            If isValidGTRSID(response.userDetails.userID) Then
                                With response.userDetails
                                    ClientInfo = New userDetails
                                    ClientInfo.clientID = .clientID
                                    ClientInfo.departmentID = .departmentID
                                    ClientInfo.userID = .userID
                                End With

                                MyStatus = GTRSServiceStatus.Okay
                                modGTRS.LogProcess("User Authentication SUCCESSFUL!")
                                LogGTRSTransaction(New TransactionLogInfo(TransactionType.Send, "AuthenticateUser", "GTRS Service", "", "Initializing GTRS Integration Object", "Authenticating User [" & UserCredential.username & "]"))

                            Else

                                ClientInfo = New userDetails
                                ClientInfo = Nothing
                                MyStatus = GTRSServiceStatus.NotOkay

                                modGTRS.LogProcess("User Authentication FAILED!")
                                modGTRS.LogProcess(" - Invalid User")
                                LogGTRSTransaction(New TransactionLogInfo(TransactionType.Send, "AuthenticateUser", "GTRS Service", "", "Initializing GTRS Integration Object", "Authenticating User [" & UserCredential.username & "]"), "Authentication Failed.")
                            End If
                        Else
                            ClientInfo = New userDetails
                            ClientInfo = Nothing
                            MyStatus = GTRSServiceStatus.NotOkay

                            modGTRS.LogProcess("User Authentication FAILED!")
                            modGTRS.LogProcess(" - Invalid User")
                            LogGTRSTransaction(New TransactionLogInfo(TransactionType.Send, "AuthenticateUser", "GTRS Service", "", "Initializing GTRS Integration Object", "Authenticating User [" & UserCredential.username & "]"), "Authentication Failed.")
                        End If


                    Else
                        modGTRS.LogProcess("User Authentication FAILED!")
                        modGTRS.LogProcess(" - GTravel failed to authenticate the user.")
                        LogGTRSTransaction(New TransactionLogInfo(TransactionType.Send, "AuthenticateUser", "GTRS Service", "", "Initializing GTRS Integration Object", "Authenticating User [" & UserCredential.username & "]"), "No response from GTRS.")
                    End If

                Else
                    modGTRS.LogProcess("No GTRS Account Found.")
                End If

                CloseCustomLoadScreen()
            End If

            modGTRS.LogProcess("")
            modGTRS.LogProcess("")
            modGTRS.LogProcess("[END : Initializiting GTRS Integration Service Control...]")


        End Sub

#End Region
        Private Function CheckIfFeatureEnabled() As Boolean
            Dim enabled As Boolean = False

            Dim clsFeature As New clsFeatureMod

            Try
                'enabled = clsFeature.isFeatureAvailable(IfNull(MPSDB.GetConfig("COMPANYID"), ""), _
                '                                    IfNull(MPSDB.GetConfig("FEATKEY"), ""), _
                '                                    "s")
                enabled = True
            Catch ex As Exception
                enabled = False
            End Try

            'If Not enabled Then Initialized = ServiceObjectState.NotEnabled
            Return enabled
        End Function

#Region "User Authentication"

        'AutheticateUser
        Private Function AuthenticateUser(ocredential As credentials) As AuthenticateUserResponse
            Dim response As AuthenticateUserResponse
            Dim oAuthenticateUser As New AuthenticateUser

            oAuthenticateUser.credentials = ocredential

            Try
                Dim cEndpointURL As String = GetEndpointURL()
                'edited by tony20190611 : to use URL set in config
                'ServiceClient.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://gtrswebservice01.gtravel.no:8078/")
                ServiceClient.Endpoint.Address = New System.ServiceModel.EndpointAddress(cEndpointURL)
                'end tony
                response = ServiceClient.AuthenticateUser(oAuthenticateUser)

            Catch ex As Exception
                response = Nothing
                Dim cPassword As String
                cPassword = IIf(IfNull(oAuthenticateUser.credentials.password, "").Length > 0, Mid(oAuthenticateUser.credentials.password, 1) & StrDup(IfNull(oAuthenticateUser.credentials.password, "").Length - 2, "*") & Mid(oAuthenticateUser.credentials.password, oAuthenticateUser.credentials.password.Length, 1) & "'", "")
                LogGTRSTransaction(New TransactionLogInfo(TransactionType.Send, _
                                                          "", _
                                                          "", _
                                                          "", _
                                                          "User Authentication", _
                                                          "Authenticating user account [" & oAuthenticateUser.credentials.username & "] with password '" & cPassword & "'"), "User authentication failed [" & ex.Message & "]")
            End Try

            'If Not response Is Nothing Then
            '    UserAuthenticated = response.userDetails.clientID <> DefaultClientID
            'End If

            Return response
        End Function

        Private Function GetEndpointURL() As String
            Dim cEndpointURL As String = MPSDB.GetConfig(GTRSConfigCode.EndpointURL)

            If IfNull(cEndpointURL, "").Length = 0 Then
                cEndpointURL = GTRS_DEFAULT_ENDPOINTURL
            End If

            Return cEndpointURL
        End Function

        Private Function AuthenticateUser(Username As String, Password As String) As AuthenticateUserResponse
            Dim ocredential As New credentials

            ocredential.username = Username
            ocredential.password = Password

            Dim response As AuthenticateUserResponse

            Try
                response = AuthenticateUser(ocredential)

            Catch ex As Exception
                response = Nothing
            End Try

            'If Not response Is Nothing Then
            '    UserAuthenticated = response.userDetails.clientID <> DefaultClientID
            'End If

            Return response
        End Function

        Public Function ValidateUserAccount(Username As String, Password As String) As Boolean
            Dim ocredential As New credentials

            ocredential.username = Username
            ocredential.password = Password

            Dim response As AuthenticateUserResponse

            Try
                response = AuthenticateUser(ocredential)

            Catch ex As Exception
                response = Nothing
            End Try

            'If Not response Is Nothing Then
            '    UserAuthenticated = response.userDetails.clientID <> DefaultClientID
            'End If

            Return ValidateUserAccountResponse(response)

        End Function

        Public Function ValidateUserAccountResponse(Response As AuthenticateUserResponse) As Boolean
            If IsNothing(Response) Then
                Return False
            Else
                If IsNothing(Response.userDetails.userID) Then
                    Return False
                Else
                    Return isValidGTRSID(Response.userDetails.userID)
                End If
            End If
        End Function

#End Region

#Region "Transactions"
        ''' <summary>
        ''' Sends Travel Request to GTRS Service via CreateTravelRequest Method
        ''' </summary>
        ''' <param name="oTravelRequest"></param>
        ''' <returns>String : TravelRequestID provided by GTravel</returns>
        ''' <remarks></remarks>
        Public Function CreateTravelRequest(oTravelRequest As MPS4.GTRSServiceReference.travelRequest) As String
            Dim ReturnValue As String = ""
            ClearLastErrorMessage()

            Try
                Dim oCreateTravelRequest As New MPS4.GTRSServiceReference.CreateTravelRequest
                Dim response As New MPS4.GTRSServiceReference.CreateTravelRequestResponse
                oCreateTravelRequest.travelRequest = oTravelRequest
                response = ServiceClient.CreateTravelRequest(oCreateTravelRequest)

                If Not IsNothing(response) Then
                    ReturnValue = response.travelRequestID()
                    modGTRS.LogProcess(vbTab & "Status: SUCCESS")
                Else
                    modGTRS.LogProcess(vbTab & "Status: FAILED")
                End If

                If Not isValidGTRSID(IfNull(ReturnValue, "")) Then
                    ReturnValue = ""
                End If

            Catch ex As Exception
                LogErrors("Failed to Send Travel Request to GTravel. Error:" & ex.Message)
                modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
                _LastErrorMessage = "Failed to Send Travel Request to GTravel." & vbNewLine & "Error:" & ex.Message

                ReturnValue = ""
            End Try

            Return ReturnValue
        End Function

        ''' <summary>
        ''' Updates Travel Request to GTRS Service via CreateTravelRequest Method
        ''' </summary>
        ''' <param name="otravelRequestUpdate"></param>
        ''' <returns>Boolean : if update request is successfully sent to GTravel</returns>
        ''' <remarks></remarks>
        Public Function UpdateTravelRequest(otravelRequestUpdate As MPS4.GTRSServiceReference.travelRequestUpdate) As Boolean
            Dim ReturnValue As Boolean = False
            Dim oUpdateTravelRequest As New MPS4.GTRSServiceReference.UpdateTravelRequest

            ClearLastErrorMessage()
            oUpdateTravelRequest.travelRequestUpdate = otravelRequestUpdate

            Dim response As MPS4.GTRSServiceReference.UpdateTravelRequestResponse = ServiceClient.UpdateTravelRequest(oUpdateTravelRequest)

            Try
                If Not IsNothing(response) Then
                    ReturnValue = response.updateStatus.Equals("SUCCESS")
                    modGTRS.LogProcess(vbTab & "Status: SUCCESS")
                Else
                    modGTRS.LogProcess(vbTab & "Status: FAILED")
                End If
            Catch ex As Exception
                LogErrors("Failed to Send Travel Request Update to GTravel. Error:" & ex.Message)
                modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
                _LastErrorMessage = "Failed to Send Travel Request Update to GTravel." & vbNewLine & "Error:" & ex.Message

            End Try



            Return ReturnValue


        End Function

        ''' <summary>
        ''' Cancels Travel Request from GTravel via the TravelRequestID
        ''' </summary>
        ''' <param name="cTravelRequestID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CancelTravelRequest(cTravelRequestID As String) As Boolean
            Dim ReturnValue As Boolean = False
            ClearLastErrorMessage()

            Dim oCancelTravelRequest As New MPS4.GTRSServiceReference.CancelTravelRequest
            oCancelTravelRequest.travelRequestID = IfNull(cTravelRequestID, "")

            modGTRS.LogProcess("Sending Travel Cancel Request...")
            modGTRS.LogProcess("  TravelRequestID:" & oCancelTravelRequest.travelRequestID)
            Try
                Dim response As MPS4.GTRSServiceReference.CancelTravelRequestResponse = ServiceClient.CancelTravelRequest(oCancelTravelRequest)

                If Not IsNothing(response) Then
                    ReturnValue = response.updateStatus.Equals("SUCCESS")
                    modGTRS.LogProcess(vbTab & "Status: SUCCESS")
                Else
                    modGTRS.LogProcess(vbTab & "Status: FAILED")
                End If

            Catch ex As Exception
                LogErrors("Failed to Send Travel Request Update to GTravel. Error:" & ex.Message)
                modGTRS.LogProcess("Status: FAILED [" & ex.Message & "]")
                _LastErrorMessage = "Failed to Send Travel Request Update to GTravel." & vbNewLine & "Error:" & ex.Message

            End Try


            Return ReturnValue
        End Function

        ''' <summary>
        ''' Adds Passenger to Existing Travel Request via AddPassenger Method
        ''' </summary>
        ''' <param name="Passenger" ></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AddPassenger(Passenger As MPS4.GTRSServiceReference.passenger) As String
            Dim ReturnValue As String = ""
            ClearLastErrorMessage()
            Dim oAddPassenger As New MPS4.GTRSServiceReference.AddPassenger
            oAddPassenger.passenger = Passenger

            Dim response As New MPS4.GTRSServiceReference.AddPassengerResponse
            modGTRS.LogProcess(" - Passenger (New): " & oAddPassenger.passenger.lastName & ", " & oAddPassenger.passenger.firstName)
            Try
                response = ServiceClient.AddPassenger(oAddPassenger)
            Catch ex As Exception
                _LastErrorMessage = ex.Message
                response = Nothing
            End Try

            If Not IsNothing(response) Then
                If isValidGTRSID(IfNull(response.passengerID, "")) Then
                    ReturnValue = response.passengerID
                    modGTRS.LogProcess(vbTab & "Add Passenger Success with PassengerID: " & response.passengerID)
                Else
                    modGTRS.LogProcess(vbTab & "Add Passenger Failed. " & response.passengerID)
                    _LastErrorMessage = "Add Passenger Failed. " & response.passengerID

                End If

            Else
                modGTRS.LogProcess(vbTab & "Add Passenger Failed.")
                _LastErrorMessage = "Add Passenger failed. No response from GTRS"

            End If

            Return ReturnValue
        End Function

        Public Function UpdatePassenger(opassengerUpdate As GTRSServiceReference.passengerUpdate) As Boolean
            Dim ReturnValue As Boolean = False
            Dim oUpdatePassenger As New MPS4.GTRSServiceReference.UpdatePassenger
            ClearLastErrorMessage()
            oUpdatePassenger.passengerUpdate = opassengerUpdate

            modGTRS.LogProcess(" - Passenger (Update): [" & oUpdatePassenger.passengerUpdate.passengerID & "] " & oUpdatePassenger.passengerUpdate.lastName & ", " & oUpdatePassenger.passengerUpdate.firstName)

            Dim response As New MPS4.GTRSServiceReference.UpdatePassengerResponse
            Try
                response = ServiceClient.UpdatePassenger(oUpdatePassenger)

            Catch ex As Exception
                _LastErrorMessage = ex.Message
                response = Nothing
            End Try

            If Not IsNothing(response) Then
                ReturnValue = response.updateStatus.Equals("SUCCESS")
                modGTRS.LogProcess(vbTab & "Status: SUCCESS")

            Else
                ReturnValue = False
                modGTRS.LogProcess(vbTab & "Status: FAILED")

            End If

            Return ReturnValue
        End Function

        Public Function CancelPassenger(oCancelPassenger As MPS4.GTRSServiceReference.CancelPassenger) As Boolean
            Dim ReturnValue As Boolean = False
            Dim response As New MPS4.GTRSServiceReference.CancelPassengerResponse
            ClearLastErrorMessage()

            Try
                response = ServiceClient.CancelPassenger(oCancelPassenger)

            Catch ex As Exception
                _LastErrorMessage = ex.Message
                response = Nothing
            End Try

            If Not IsNothing(response) Then
                ReturnValue = response.updateStatus.Equals("SUCCESS")
                modGTRS.LogProcess(vbTab & "Status: SUCCESS")

            Else
                ReturnValue = False
                modGTRS.LogProcess(vbTab & "Status: FAILED")

            End If

            Return ReturnValue
        End Function

        Public Function GetTravelRequestDetails(cTravelRecordPKey As String, cTravelRequestID As String, Optional showMessage As Boolean = True) As Boolean
            Dim ReturnValue As Boolean = False
            ClearLastErrorMessage()
            Dim oViewTravelRequest As New ViewTravelRequest

            oViewTravelRequest.travelRequestID = cTravelRequestID

            Dim response As ViewTravelRequestResponse = ServiceClient.ViewTravelRequest(oViewTravelRequest)

            If Not IsNothing(response) Then
                ReturnValue = GetTravelRequestDetails_SaveInDB(cTravelRecordPKey, cTravelRequestID, response)
                If Not ReturnValue Then
                    If showMessage Then
                        If LastErrorMessage() = GTRSService.DefaultErrorMessages.NoBookingDetailsYet Then
                            MsgBox(LastErrorMessage, MsgBoxStyle.Exclamation, GetAppName)
                        Else
                            MsgBox("Retrieving of Travel Details failed." & IIf(IfNull(LastErrorMessage(), "").Length > 0, vbNewLine & "Error: " & LastErrorMessage, ""), MsgBoxStyle.Exclamation, GetAppName)
                        End If
                    End If
                End If
            End If
            Return ReturnValue
        End Function

        Private Function GetTravelRequestDetails_SaveInDB(cTravelRecordPKey As String, cTravelRequestID As String, response As ViewTravelRequestResponse) As Boolean
            Dim ReturnValue As Boolean = False
            Dim LastUpdatedBy As String
            ClearLastErrorMessage()

            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Get Travel Reqeust Details from GTravel", 0, System.Environment.MachineName, "<tblTravelBookingDetail><PKey : '" & cTravelRecordPKey & "'><TravelRequestID : '" & cTravelRequestID & "'", "GTRS Integration")
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Get Travel Reqeust Details from GTravel", 0, System.Environment.MachineName, "<tblTravelBookingDetail><PKey : '" & cTravelRecordPKey & "'>", "GTRS Integration")
            MPSDB.RunSql("DELETE FROM dbo.tblTravelBookingDetail WHERE FKeyTravelBooking = '" & cTravelRecordPKey & "'")

            Dim sqls As New ArrayList
            Dim cSQL As String = ""

            If response.ocsTransactions.Count = 1 Then
                If IfNull(response.ocsTransactions(0).origin, "").Equals("") And IfNull(response.ocsTransactions(0).destination, "").Equals("") Then
                    _LastErrorMessage = GTRSService.DefaultErrorMessages.NoBookingDetailsYet
                    Return False
                End If
            End If
            For i As Integer = 0 To response.ocsTransactions.Count - 1
                Try
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
                               "            ,[isCanceled] " & _
                               "            ,[isFromGTravel]) " & _
                               "VALUES " & _
                               "            ('" & cTravelRecordPKey & "' " & _
                               "            ,'" & .employeeNo & "' " & _
                               "            ,'" & IfNull(.itemType, "") & "' " & _
                               "            ,'" & .amaName & "' " & _
                               "            ,'" & .flightnumber & "' " & _
                               "            ,'" & .classOfService & "' " & _
                               "            ,'" & .origin & "' " & _
                               "            ,'" & .originDesc & "' " & _
                               "            ," & If(ChangeToSQLDate(ChangeGTRSDateToDateTime(.departureTime)).Equals("''"), "NULL", ChangeToSQLDate(ChangeGTRSDateToDateTime(.departureTime))) & " " & _
                               "            ,'" & .destination & "' " & _
                               "            ,'" & .destinationDesc & "' " & _
                               "            ," & If(ChangeToSQLDate(ChangeGTRSDateToDateTime(.arrivalTime)).Equals("''"), "NULL", ChangeToSQLDate(ChangeGTRSDateToDateTime(.arrivalTime))) & " " & _
                               "            ,'" & .company & "' " & _
                               "            ,'" & .freeText & "' " & _
                               "            ,'" & .status & "' " & _
                               "            ,'" & .reference & "' " & _
                               "            ,getdate()  " & _
                               "            ,'" & LastUpdatedBy & "' " & _
                               "            ,0 " & _
                               "            ,1)"

                    End With
                    sqls.Add(cSQL)
                Catch ex As Exception
                    ReturnValue = False
                    _LastErrorMessage = ex.Message
                    Exit For
                End Try

            Next

            If sqls.Count > 0 Then
                ReturnValue = MPSDB.RunSqls(sqls)
            End If

            Return ReturnValue
        End Function
#End Region
    End Class
#End Region

#Region "Utilities"
    Public Function InitializeGTRSServiceObject() As GTRSServiceStatus
        If IsNothing(oGTRS) Then
            oGTRS = New GTRSService
        End If

        oGTRS.Init()
        Return oGTRS.MyStatus

    End Function

    Public Function isValidGTRSID(strID As String) As Boolean
        Dim tmpGUID As Guid
        If IfNull(strID, "").Equals("") Then
            Return False
        Else
            Try
                Return Guid.TryParse(strID, tmpGUID) And Not Guid.Parse(strID).Equals(Guid.Empty)

            Catch ex As Exception
                Return False
            End Try
        End If

    End Function
    Public Function GetGTRSCredential() As credentials

        Try
            Dim Username As String = IfNull(MPSDB.GetConfig(GTRSConfigCode.Account), "")
            Dim Password As String = IfNull(MPSDB.GetConfig(GTRSConfigCode.Password), "")

            If Not IfNull(Username, "").Equals("") Then Username = sysMpsUserPassword("DECRYPT", Username)
            If Not IfNull(Password, "").Equals("") Then Password = sysMpsUserPassword("DECRYPT", Password)

            If Username.Length = 0 And Password.Length = 0 Then
                Return Nothing
            Else
                Dim ReturnValue As New credentials
                ReturnValue.username = Username
                ReturnValue.password = Password
                Return ReturnValue
            End If
        Catch ex As Exception
            LogErrors("Failed to get GTRS Credential")
            Return Nothing
        End Try

    End Function
#Region "Date"
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToGTRSDate(ByVal nDate As Object) As String
        Try

            If Not IsDate(nDate) Then
                Return ""

            Else
                Dim ddate As Date = CDate(nDate)
                Return ddate.Year.ToString("0000") & "-" & ddate.Month.ToString("00") & "-" & ddate.Day.ToString("00") & " " & ddate.Hour.ToString("00") & ":" & ddate.Minute.ToString("00")
            End If



        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function ChangeGTRSDateToDateTime(cDateString As Object) As Object
        Dim arr() As String
        Dim ReturnValue As Object = ""
        Dim tmpReturnValue As String = ""


        Dim _cDate As String = ""


        If IfNull(cDateString, "").Length > 0 Then
            _cDate = IfNull(cDateString, "")
            arr = _cDate.Split(".")
            tmpReturnValue = "#" & DateSerial(Mid(arr(2), 1, 4), arr(1), arr(0)) & " " & Trim(Mid(arr(2), 5)) & "#"
            If IsDate(tmpReturnValue) Then
                ReturnValue = CDate(tmpReturnValue)
            End If
        Else
            ReturnValue = ""
        End If

        Return ReturnValue
    End Function
#End Region
#End Region

    Public Function HasControlUpdated(ByVal _containers() As DevExpress.XtraLayout.LayoutControlGroup) As Boolean
        Dim retval As String = ""
        For Each _container As DevExpress.XtraLayout.LayoutControlGroup In _containers
            For o As Integer = 0 To _container.Items.Count - 1
                If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
                        If ctr.Tag = 1 Then
                            Return True
                        End If
                        '===================================================
                    End If
                End If
            Next
        Next

        Return False

    End Function
#Region "Check for GTRS Responses"

    'Structure GTRSTravelRequest
    '    Dim PKey As String
    '    Dim TravelRequestID As String
    '    Dim Success As Boolean
    'End Structure



    ' ''' <summary>
    ' ''' This event refreshes and checks if there any travel request responded by GTravel
    ' ''' This is called in the LoadContent event of the program.
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Function CheckForTravelRequestDetails() As Boolean
    '    'tonytest 
    '    Dim ReturnValue As Boolean = False


    '    ''<!-- commented out by tony20181003 - transferred init to frmCrewMain
    '    ''CHECKS IF GTRS INTEGRATION FEATURE IS AVAILABLE
    '    'If IsNothing(GTRS_FEATURE_AVAILABLE) Then
    '    '    Dim clsFeature As New clsFeatureMod

    '    '    GTRS_FEATURE_AVAILABLE = clsFeature.HasFeature(MPSDB.GetConfig("COMPANYID"), MPSDB.GetConfig("FEATKEY"), "s")

    '    'End If
    '    ''-->

    '    ''EXITS IF GTRS INTEGRATION FEATURE IS NOT AVAILABLE
    '    'If Not GTRS_FEATURE_AVAILABLE Or IsNothing(GTRS_FEATURE_AVAILABLE) Then
    '    '    Return ReturnValue
    '    '    Exit Function
    '    'End If

    '    ''PROCEEDS IF GTRS INTEGRATION FEATURE IS AVAILABLE
    '    'modGTRS.LogProcess("Checking Response from GTravel...")
    '    'InitNotificationConfig()

    '    'If GTRSNotificationConfig.ReceiveResponse Then  ' GetUserSetting(UserSettingCode.Travel.ReceiveResponseNotification, "0").Equals("1") Then

    '    '    If GTRSNotificationConfig.ResponseTime > 0 And DateAdd(DateInterval.Minute, GTRSNotificationConfig.ResponseTime, GTRSNotificationConfig.LastResponseCheckTime) < DateTime.Now Then
    '    '        modGTRS.LogProcess(" - Last Checked: " & Format(GTRSNotificationConfig.LastResponseCheckTime, "dd-MMM-yyyy hh:mm:ss tt"))

    '    '        Dim dtResponseList As DataTable = MPSDB.CreateTable("SELECT * FROM dbo.tblTravelBooking WHERE dbo.isValidGUID(TravelRequestID) <> 0 AND RefreshGTRSDetailsAt <= getdate() ORDER BY TravelDate")
    '    '        Dim receivedResponseDT As DataTable = dtResponseList.Clone
    '    '        receivedResponseDT.Rows.Clear()

    '    '        If dtResponseList.Rows.Count > 0 Then

    '    '            If IsNothing(oGTRS) Then
    '    '                'Dim i As System.ServiceModel.ClientBase(Of GTRSServiceReference.GTRSServiceClass)
    '    '                oGTRS = New GTRSService
    '    '            End If

    '    '            oGTRS.Init()

    '    '            If oGTRS.Initialized = ServiceObjectState.Initialized And oGTRS.UserAuthenticated = UserAuthentication.Success Then
    '    '                For Each dr As DataRow In dtResponseList.Rows
    '    '                    Dim oGTRSTravelRequest As GTRSTravelRequest
    '    '                    Dim clsAudit As New clsAudit
    '    '                    Dim LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", "Auto-Refresh GTRS Response Check") 'neil

    '    '                    oGTRSTravelRequest = New GTRSTravelRequest
    '    '                    oGTRSTravelRequest.PKey = dr("PKey")
    '    '                    oGTRSTravelRequest.TravelRequestID = dr("TravelRequestID")
    '    '                    oGTRSTravelRequest.Success = False



    '    '                    UpdateBookingDetails(oGTRSTravelRequest, LastUpdatedBy)



    '    '                    If oGTRSTravelRequest.Success Then

    '    '                        modGTRS.LogProcess("--> Response Received")
    '    '                        modGTRS.LogProcess("--> MPS Record ID: " & dr("PKey"))
    '    '                        modGTRS.LogProcess("    Travel Request ID: " & dr("TravelRequestID") & " (" & dr("RequestType") & ")")
    '    '                        modGTRS.LogProcess("    Vessel: " & dr("VslName"))
    '    '                        modGTRS.LogProcess("    Port: " & dr("PortName"))
    '    '                        modGTRS.LogProcess("    Travel Date: " & dr("TravelDate"))
    '    '                        modGTRS.LogProcess("    Ref No.: " & dr("RefNo"))
    '    '                        modGTRS.LogProcess("")

    '    '                        receivedResponseDT.ImportRow(dr)
    '    '                    End If
    '    '                Next

    '    '                If receivedResponseDT.Rows.Count > 0 Then
    '    '                    Dim f As New frmGTravelNotif
    '    '                    f.MainGrid.DataSource = receivedResponseDT
    '    '                    modGTRS.LogProcess("Show Notification Form for Updated Travel Request(s)")
    '    '                    modGTRS.LogProcess("")
    '    '                    f.ShowDialog()
    '    '                    ReturnValue = True
    '    '                End If

    '    '            End If

    '    '        Else
    '    '            modGTRS.LogProcess("No response.")
    '    '        End If
    '    '    End If

    '    'Else
    '    '    modGTRS.LogProcess(" - Auto-receive response from GTravel is disabled.")
    '    '    modGTRS.LogProcess("")

    '    'End If
    '    'modGTRS.LogProcess(vbTab & "***** END *****")

    '    Return ReturnValue
    'End Function

    'Private Sub UpdateBookingDetails(ByRef GTRSTravelRequest As GTRSTravelRequest, ByRef LastUPdatedBy As String, Optional isManualRefresh As Boolean = False)
    '    Dim bSuccess As Boolean = False


    '    If CheckForInternetConnection() Then
    '        bSuccess = GetTravelRequestDetailsFromGTRS(GTRSTravelRequest, LastUPdatedBy, True)

    '        If bSuccess Then
    '            MPSDB.RunSql("UPDATE dbo.tblTravelBooking SET BookingStatus = '" & TravelBookingStatus.Booked.Key & "', isSentToGTravel = 1, isUnread = 1, DateUpdated = getdate(), LastUpdatedBy = '" & LastUPdatedBy & "' WHERE PKey = '" & GTRSTravelRequest.PKey & "'")
    '            GTRSTravelRequest.Success = True
    '        Else
    '            MPSDB.RunSql("UPDATE dbo.tblTravelBooking SET BookingStatus = '" & TravelBookingStatus.InProgress.Key & "', isUnread = 0, DateUpdated = getdate(), LastUpdatedBy = '" & LastUPdatedBy & "' WHERE PKey = '" & GTRSTravelRequest.PKey & "'")

    '        End If
    '    End If

    '    CloseCustomLoadScreen()

    'End Sub

    'Public Function GetTravelRequestDetailsFromGTRS(ByRef GTRSTravelRequest As GTRSTravelRequest, ByRef LastUpdatedBy As String, Optional SaveTravelRequestIDToDatabase As Boolean = False) As Boolean
    '    Dim ReturnValue As Boolean = False
    '    Dim oViewTravelRequest As New ViewTravelRequest

    '    oViewTravelRequest.travelRequestID = GTRSTravelRequest.TravelRequestID

    '    Dim response As ViewTravelRequestResponse = oGTRS.ServiceClient.ViewTravelRequest(oViewTravelRequest)

    '    If Not IsNothing(response) Then
    '        If TravelRequestHasTransactions(response) Then ' If response.ocsTransactions.Count > 0 Then
    '            ReturnValue = SaveBookingDetailsFromGTRS(GTRSTravelRequest, response, LastUpdatedBy)
    '        End If
    '    End If
    '    Return ReturnValue
    'End Function

    'Private Function TravelRequestHasTransactions(response As ViewTravelRequestResponse) As Boolean
    '    Dim ReturnValue As Boolean = True
    '    For i As Integer = 0 To response.ocsTransactions.Count - 1
    '        ReturnValue = ReturnValue And Not IfNull(response.ocsTransactions(i).employeeNo, "").Equals("")
    '    Next

    '    Return ReturnValue
    'End Function

    'Private Function SaveBookingDetailsFromGTRS(ByRef GTRSTravelRequest As GTRSTravelRequest, response As ViewTravelRequestResponse, LastUpdatedBy As String) As Boolean
    '    Dim ReturnValue As Boolean = False

    '    MPSDB.RunSql("DELETE FROM dbo.tblTravelBookingDetail WHERE FKeyTravelBooking = '" & GTRSTravelRequest.PKey & "'")

    '    Dim sqls As New ArrayList
    '    Dim cSQL As String = ""
    '    For i As Integer = 0 To response.ocsTransactions.Count - 1
    '        With response.ocsTransactions(i)

    '            cSQL = "INSERT INTO [dbo].[tblTravelBookingDetail] " & _
    '                   "            ([FKeyTravelBooking] " & _
    '                   "            ,[PassengerID] " & _
    '                   "            ,[ItemType] " & _
    '                   "            ,[AmadeusName] " & _
    '                   "            ,[FlightNumber] " & _
    '                   "            ,[ClassOfService] " & _
    '                   "            ,[Origin] " & _
    '                   "            ,[OriginDesc] " & _
    '                   "            ,[DepartureTime] " & _
    '                   "            ,[Destination] " & _
    '                   "            ,[DestinationDesc] " & _
    '                   "            ,[ArrivalTime] " & _
    '                   "            ,[Company] " & _
    '                   "            ,[FreeTxt] " & _
    '                   "            ,[Status] " & _
    '                   "            ,[Reference] " & _
    '                   "            ,[DateUpdated] " & _
    '                   "            ,[LastUpdatedBy], " & _
    '                   "            ,[isCanceled]) " & _
    '                   "VALUES " & _
    '                   "            ('" & GTRSTravelRequest.PKey & "' " & _
    '                   "            ,'" & .employeeNo & "' " & _
    '                   "            ,'" & IfNull(.itemType, "") & "' " & _
    '                   "            ,'" & .amaName & "' " & _
    '                   "            ,'" & .flightnumber & "' " & _
    '                   "            ,'" & .classOfService & "' " & _
    '                   "            ,'" & .origin & "' " & _
    '                   "            ,'" & .originDesc & "' " & _
    '                   "            ," & If(ChangeToSQLDate(.departureTime).Equals("''"), "NULL", ChangeToSQLDate(.departureTime)) & " " & _
    '                   "            ,'" & .destination & "' " & _
    '                   "            ,'" & .destinationDesc & "' " & _
    '                   "            ," & If(ChangeToSQLDate(.arrivalTime).Equals("''"), "NULL", ChangeToSQLDate(.arrivalTime)) & " " & _
    '                   "            ,'" & .company & "' " & _
    '                   "            ,'" & .freeText & "' " & _
    '                   "            ,'" & .status & "' " & _
    '                   "            ,'" & .reference & "' " & _
    '                   "            ,getdate()  " & _
    '                   "            ,'" & LastUpdatedBy & "' " & _
    '                   "            ,0)"

    '        End With
    '        sqls.Add(cSQL)

    '    Next

    '    If sqls.Count > 0 Then
    '        ReturnValue = MPSDB.RunSqls(sqls)
    '    End If

    '    Return ReturnValue
    'End Function
#End Region

#Region "Log"
    Public Enum TransactionType
        NotApplicable = 0
        [Get] = 1
        Send = 2
        MPS = 3
    End Enum

    Public Function GetTransactionTypeDesc(pTransactionType As TransactionType) As String
        Select Case pTransactionType
            Case TransactionType.NotApplicable
                Return "NOT APPLICABLE"

            Case TransactionType.Get
                Return "GET"

            Case TransactionType.Send
                Return "SEND"

            Case TransactionType.MPS
                Return "MPS"

            Case Else
                Return ""
        End Select
    End Function


    Public Structure TransactionLogInfo
        Public TransactionType As TransactionType
        Public CalledMethod As Object
        Public CallingForm As Object
        Public TravelBookingPKey As Object
        Public Action As Object
        Public Description As Object

        Public Sub New(pTransactionType As TransactionType, pCalledMethod As Object, pCallingForm As Object, pTravelBookingPKey As Object, pAction As Object, pDescription As Object)
            TransactionType = pTransactionType
            CalledMethod = pCalledMethod
            CallingForm = pCallingForm
            TravelBookingPKey = pTravelBookingPKey
            Action = pAction
            Description = pDescription
        End Sub
    End Structure

    Public Sub LogGTRSTransaction(pTransactionLogInfo As TransactionLogInfo, Optional cFailErrorMessage As String = "")
        Dim cSQL As String
        With pTransactionLogInfo
            cSQL = "INSERT INTO [dbo].[tblLog_GTRSTrans] " & _
                   "           ([TransactionType] " & _
                   "          ,[CalledMethod] " & _
                   "          ,[CallingForm] " & _
                   "          ,[Action] " & _
                   "          ,[Description] " & _
                   "          ,[tblTravelBookingPKey] " & _
                   "          ,[TransactionDate] " & _
                   "          ,[ComputerName] " & _
                   "          ,[UserID] " & _
                   "          ,[FailErrorMessage]) " & _
                   "VALUES " & _
                   "          (" & ChangeToSQLString(GetTransactionTypeDesc(.TransactionType)) & _
                   "          ," & IIf(IfNull(.CalledMethod, "").Length > 0, "'" & .CalledMethod & "'", "NULL") & " " & _
                   "          ," & IIf(IfNull(.CallingForm, "").Length > 0, "'" & .CallingForm & "'", "NULL") & " " & _
                   "          ," & IIf(IfNull(.Action, "").Length > 0, "'" & .Action & "'", "NULL") & " " & _
                   "          ," & IIf(IfNull(.Description, "").Length > 0, "'" & .Description & "'", "NULL") & " " & _
                   "          ," & ChangeToSQLString(.TravelBookingPKey) & " " & _
                   "          ,getdate() " & _
                   "          ,'" & System.Environment.MachineName & "' " & _
                   "          ," & IfNull(USER_ID, 0) & " " & _
                   "          ," & IIf(IfNull(cFailErrorMessage, "").Length > 0, "'" & cFailErrorMessage & "'", "NULL") & ")"
        End With

        MPSDB.RunSql(cSQL)

    End Sub

    Public Sub LogProcess(loginfo As String)
        '------------------------------------------------------------------------------------------------------------------------------
        'Init Log File
        Dim cFileName As String = "MPS5_GTRS_Log_" & Format(DateTime.Now(), "yyyyMMdd") & ".txt"
        Dim LogFileLocation As String

        LogFileLocation = Application.StartupPath
        LogFileLocation = LogFileLocation & IIf(Right(LogFileLocation, 1) <> "\", "\", "") & "logs\"
        If Not IO.Directory.Exists(LogFileLocation) Then
            MkDir(LogFileLocation)
        End If

        LogFileLocation = LogFileLocation & cFileName

        If Not IO.File.Exists(LogFileLocation) Then
            Dim writeFile As IO.StreamWriter
            writeFile = IO.File.CreateText(LogFileLocation) 'Creates a new file
            writeFile.WriteLine("")
            writeFile.Close()

        End If

        '------------------------------------------------------------------------------------------------------------------------------
        'Add Log
        Dim objWriter As New System.IO.StreamWriter(LogFileLocation)
        Dim cUser As String = USER_NAME
        Dim cPrefix As String = Format(DateTime.Now(), "yyyy-MM-dd hh:mm:ss tt") & " " & cUser & " " & "|" & vbTab
        objWriter.WriteLine(cPrefix & _
                            loginfo)
        objWriter.Close()


    End Sub
#End Region
End Module
