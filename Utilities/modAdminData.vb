Public Module modAdminData

#Region "Admin Datatable Declarations"
    Dim dtRank As New DataTable
    Dim dtPort As New DataTable
    Dim dtWScale As New DataTable
    Dim dtWScaleRank As New DataTable
    Dim dtVessel As New DataTable
    Dim dtAgent As New DataTable
    Dim dtReason As New DataTable
    Dim dtAshoreStatus As New DataTable
    Dim dtCurrency As New DataTable
    Dim dtAirline As New DataTable
    Dim dtAirport As New DataTable
    Dim dtPrincipal As New DataTable
    Dim dtPortAgent As New DataTable
    Dim dtTravelAgent As New DataTable
    Dim dtLTPRankList As New DataTable

    Public UndefinedWScaleCode As String = "SYSWSNOWSCALE"
    Public UndefinedWScaleRankCode As String = "SYSWSRUNDEF"
    Public UndefinedRankCode As String = "SYSRUNDEFINED"

#End Region

#Region "Admin Last Update Dates Declarations"
    Dim rankLastUpdateDate As New DateTime
    Dim portLastUpdateDate As New DateTime
    Dim wscaleLastUpdateDate As New DateTime
    Dim wscaleRankLastUpdateDate As New DateTime
    Dim vesselLastUpdateDate As New DateTime
    Dim agentLastUpdateDate As New DateTime
    Dim reasonLastUpdateDate As New DateTime
    Dim ashstatLastUpdateDate As New DateTime
    Dim currencyLastUpdateDate As New DateTime
    Dim airlineLastUpdateDate As New DateTime
    Dim airportLastUpdateDate As New DateTime
    Dim principalLastUpdateDate As New DateTime
    Dim portAgentLastUpdateDate As New DateTime
    Dim travelAgentLastUpdateDate As New DateTime
    Dim LTPRankListLastUpdateDate As New DateTime
#End Region

    Public Function LTPRankList(ByVal db As SQLDB, ByVal VslCode As String) As DataTable
        If dtRank.Rows.Count = 0 Then
            dtRank = db.CreateTable("SELECT PKey, Name, Abbrv, SortCode FROM LTP_RankList WHERE FKeyVsl = '" & VslCode & "' ORDER BY SortCode")
            dtRank.PrimaryKey = New DataColumn() {dtRank.Columns("PKey")}
            rankLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name, Abbrv, SortCode FROM LTP_RankList WHERE DateUpdated >= " & ChangeToSQLDate(rankLastUpdateDate) & " AND FKeyVsl = '" & VslCode & "' ORDER BY SortCode")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtRank.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtRank.Rows.Remove(drFound)
                    End If
                    dtRank.ImportRow(drNew)
                Next
                dtRank.DefaultView.Sort = "SortCode, Name ASC"
                rankLastUpdateDate = Now
            End If
        End If
        Return dtRank
    End Function

    Public Function TravelAgentList(ByVal db As SQLDB) As DataTable
        If dtTravelAgent.Rows.Count = 0 Then
            dtTravelAgent = db.CreateTable("SELECT Name, PKey FROM tblAdmTravAgent ORDER BY Name")
            dtTravelAgent.PrimaryKey = New DataColumn() {dtTravelAgent.Columns("PKey")}
            travelAgentLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT Name, PKey FROM tblAdmTravAgent WHERE DateUpdated >= " & ChangeToSQLDate(travelAgentLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtTravelAgent.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtTravelAgent.Rows.Remove(drFound)
                    End If
                    dtTravelAgent.ImportRow(drNew)
                Next
                dtTravelAgent.DefaultView.Sort = "Name ASC"
                travelAgentLastUpdateDate = Now
            End If
        End If
        Return dtTravelAgent
    End Function

    Public Function PortAgentList(ByVal db As SQLDB) As DataTable
        If dtPortAgent.Rows.Count = 0 Then
            dtPortAgent = db.CreateTable("SELECT PKey, Name FROM [dbo].[tblAdmPortAgent] ORDER BY Name")
            dtPortAgent.PrimaryKey = New DataColumn() {dtPortAgent.Columns("PKey")}
            portAgentLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name FROM [dbo].[tblAdmPortAgent] WHERE DateUpdated >= " & ChangeToSQLDate(portAgentLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtPortAgent.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtPortAgent.Rows.Remove(drFound)
                    End If
                    dtPortAgent.ImportRow(drNew)
                Next
                dtPortAgent.DefaultView.Sort = "Name ASC"
                portAgentLastUpdateDate = Now
            End If
        End If
        Return dtPortAgent
    End Function

    Public Function PrincipalList(ByVal db As SQLDB) As DataTable
        If dtPrincipal.Rows.Count = 0 Then
            dtPrincipal = db.CreateTable("SELECT PKey, Name FROM [dbo].[PrincipalList] ORDER BY Name")
            dtPrincipal.PrimaryKey = New DataColumn() {dtPrincipal.Columns("PKey")}
            principalLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name FROM [dbo].[PrincipalList] WHERE DateUpdated >= " & ChangeToSQLDate(principalLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtPrincipal.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtPrincipal.Rows.Remove(drFound)
                    End If
                    dtPrincipal.ImportRow(drNew)
                Next
                dtPrincipal.DefaultView.Sort = "Name ASC"
                principalLastUpdateDate = Now
            End If
        End If
        Return dtPrincipal
    End Function

    Public Function AirportList(ByVal db As SQLDB) As DataTable
        If dtAirport.Rows.Count = 0 Then
            dtAirport = db.CreateTable("SELECT PKey, Name FROM [dbo].[tblAdmAirport] ORDER BY Name")
            dtAirport.PrimaryKey = New DataColumn() {dtAirport.Columns("PKey")}
            airportLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name FROM [dbo].[tblAdmAirport] WHERE DateUpdated >= " & ChangeToSQLDate(airportLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtAirport.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtAirport.Rows.Remove(drFound)
                    End If
                    dtAirport.ImportRow(drNew)
                Next
                dtAirport.DefaultView.Sort = "Name ASC"
                airportLastUpdateDate = Now
            End If
        End If
        Return dtAirport
    End Function

    Public Function AirlineList(ByVal db As SQLDB) As DataTable
        If dtAirline.Rows.Count = 0 Then
            dtAirline = db.CreateTable("SELECT PKey, Name from tblAdmAirline ORDER By Name")
            dtAirline.PrimaryKey = New DataColumn() {dtAirline.Columns("PKey")}
            airlineLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name from tblAdmAirline WHERE DateUpdated >= " & ChangeToSQLDate(airlineLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtAirline.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtAirline.Rows.Remove(drFound)
                    End If
                    dtAirline.ImportRow(drNew)
                Next
                dtAirline.DefaultView.Sort = "Name ASC"
                airlineLastUpdateDate = Now
            End If
        End If
        Return dtAirline
    End Function

    Public Function CurrencyList(ByVal db As SQLDB) As DataTable
        If dtCurrency.Rows.Count = 0 Then
            dtCurrency = db.CreateTable("SELECT PKey, Name, Symbol, SortCode FROM [dbo].[tblAdmCurr] ORDER BY SortCode, Name")
            dtCurrency.PrimaryKey = New DataColumn() {dtCurrency.Columns("PKey")}
            currencyLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name, Symbol, SortCode FROM [dbo].[tblAdmCurr] WHERE DateUpdated >= " & ChangeToSQLDate(currencyLastUpdateDate) & " ORDER BY SortCode, Name")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtCurrency.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtCurrency.Rows.Remove(drFound)
                    End If
                    dtCurrency.ImportRow(drNew)
                Next
                dtCurrency.DefaultView.Sort = "SortCode, Name ASC"
                currencyLastUpdateDate = Now
            End If
        End If
        Return dtCurrency
    End Function

    Public Function AshoreStatusList(ByVal db As SQLDB) As DataTable
        If dtAshoreStatus.Rows.Count = 0 Then
            dtAshoreStatus = db.CreateTable("SELECT PKey, Name FROM tblAdmStat WHERE StatType = 3 AND Pkey NOT IN ('SYSAPP', 'SYSHIRED', '67') ORDER BY Name ASC")
            dtAshoreStatus.PrimaryKey = New DataColumn() {dtAshoreStatus.Columns("PKey")}
            ashstatLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name FROM tblAdmStat WHERE StatType = 3 AND Pkey NOT IN ('SYSAPP', 'SYSHIRED', '67') AND DateUpdated >= " & ChangeToSQLDate(ashstatLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtAshoreStatus.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtAshoreStatus.Rows.Remove(drFound)
                    End If
                    dtAshoreStatus.ImportRow(drNew)
                Next
                dtAshoreStatus.DefaultView.Sort = "Name ASC"
                ashstatLastUpdateDate = Now
            End If
        End If
        Return dtAshoreStatus
    End Function

    Public Function ReasonList(ByVal db As SQLDB) As DataTable
        If dtReason.Rows.Count = 0 Then
            dtReason = db.CreateTable("SELECT PKey, Name FROM tblAdmStat WHERE StatType = 2 AND Pkey <> 'SYSAPP' ORDER BY Name ASC")
            dtReason.PrimaryKey = New DataColumn() {dtReason.Columns("PKey")}
            reasonLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name FROM tblAdmStat WHERE (StatType = 2 AND Pkey <> 'SYSAPP') AND DateUpdated >= " & ChangeToSQLDate(reasonLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtReason.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtReason.Rows.Remove(drFound)
                    End If
                    dtReason.ImportRow(drNew)
                Next
                dtReason.DefaultView.Sort = "Name ASC"
                reasonLastUpdateDate = Now
            End If
        End If
        Return dtReason
    End Function

    Public Function RankList(ByVal db As SQLDB) As DataTable
        If dtRank.Rows.Count = 0 Then
            dtRank = db.CreateTable("SELECT PKey, Name, Abbrv, SortCode FROM tblAdmRank ORDER BY SortCode")
            dtRank.PrimaryKey = New DataColumn() {dtRank.Columns("PKey")}
            rankLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name, Abbrv, SortCode FROM tblAdmRank WHERE DateUpdated >= " & ChangeToSQLDate(rankLastUpdateDate) & " ORDER BY SortCode")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtRank.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtRank.Rows.Remove(drFound)
                    End If
                    dtRank.ImportRow(drNew)
                Next
                dtRank.DefaultView.Sort = "SortCode, Name ASC"
                rankLastUpdateDate = Now
            End If
        End If
        Return dtRank
    End Function

    Public Function PortList(ByVal db As SQLDB) As DataTable
        If dtPort.Rows.Count = 0 Then
            dtPort = db.CreateTable("SELECT PKey, Name FROM tblAdmPort ORDER BY Name")
            dtPort.PrimaryKey = New DataColumn() {dtPort.Columns("PKey")}
            portLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name FROM tblAdmPort WHERE DateUpdated >= " & ChangeToSQLDate(portLastUpdateDate) & " ORDER BY Name")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtPort.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtPort.Rows.Remove(drFound)
                    End If
                    dtPort.ImportRow(drNew)
                Next
                dtPort.DefaultView.Sort = "Name ASC"
                portLastUpdateDate = Now
            End If
        End If
        Return dtPort
    End Function

    Public Function WageScaleList(ByVal db As SQLDB) As DataTable
        If dtWScale.Rows.Count = 0 Then
            dtWScale = db.CreateTable("SELECT PKey, Name FROM tblAdmWScale WHERE [Active] <> 0 ORDER BY Name ASC")
            dtWScale.PrimaryKey = New DataColumn() {dtWScale.Columns("PKey")}
            wscaleLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT PKey, Name FROM tblAdmWScale WHERE [Active] <> 0 AND DateUpdated >= " & ChangeToSQLDate(wscaleLastUpdateDate) & " ORDER BY Name ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtWScale.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtWScale.Rows.Remove(drFound)
                    End If
                    dtWScale.ImportRow(drNew)
                Next
                dtWScale.DefaultView.Sort = "Name ASC"
                wscaleLastUpdateDate = Now
            End If
        End If
        Return dtWScale
    End Function

    Public Function WageRankScaleList(ByVal db As SQLDB) As DataTable
        If dtWScaleRank.Rows.Count = 0 Then
            dtWScaleRank = db.CreateTable("SELECT WScaleRankCode as PKey, WageScale as Name, WScaleCode,LOC, LOCDays,rn, RankCode FROM dbo.WAGESCALE WHERE [Active] <> 0 ORDER BY WageScale ASC")
            dtWScaleRank.PrimaryKey = New DataColumn() {dtWScaleRank.Columns("PKey")}
            wscaleRankLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = db.CreateTable("SELECT WScaleRankCode as PKey, WageScale as Name, WScaleCode,LOC, LOCDays,rn, RankCode FROM dbo.WAGESCALE WHERE [Active] <> 0 AND DateUpdated >= " & ChangeToSQLDate(wscaleRankLastUpdateDate) & " ORDER BY WageScale ASC")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtWScaleRank.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtWScaleRank.Rows.Remove(drFound)
                    End If
                    dtWScaleRank.ImportRow(drNew)
                Next
                dtWScaleRank.DefaultView.Sort = "Name ASC"
                wscaleRankLastUpdateDate = Now
            End If
        End If
        Return dtWScaleRank
    End Function

    Public Function VesselList(ByVal db As SQLDB) As DataTable
        If dtVessel.Rows.Count = 0 Then
            dtVessel = getFilteredData(db, "SELECT PKey, Name, FKeyPrincipal, FKeyFlt FROM [tblAdmVsl] WHERE [VslStat] = 1", enumFilteredDataObjectType.SQL, "Name", , , "FKeyPrincipal", "FkeyFlt")
            dtVessel.PrimaryKey = New DataColumn() {dtVessel.Columns("PKey")}
            vesselLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = getFilteredData(db, "SELECT PKey, Name, FKeyPrincipal, FKeyFlt FROM [tblAdmVsl] WHERE [VslStat] = 1 AND DateUpdated >= " & ChangeToSQLDate(vesselLastUpdateDate), enumFilteredDataObjectType.SQL, "Name", , , "FKeyPrincipal", "FkeyFlt")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtVessel.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtVessel.Rows.Remove(drFound)
                    End If
                    dtVessel.ImportRow(drNew)
                Next
                dtVessel.DefaultView.Sort = "Name ASC"
                vesselLastUpdateDate = Now
            End If
        End If
        Return dtVessel
    End Function

    Public Function AgentList(ByVal db As SQLDB) As DataTable
        If dtAgent.Rows.Count = 0 Then
            dtAgent = getFilteredData(db, "SELECT PKey, Name FROM ManAgentList", enumFilteredDataObjectType.SQL, "Name", , "PKey")
            dtAgent.PrimaryKey = New DataColumn() {dtAgent.Columns("PKey")}
            agentLastUpdateDate = Now
        Else
            Dim dt As New DataTable
            dt = getFilteredData(db, "SELECT PKey, Name FROM ManAgentList WHERE DateUpdated >= " & ChangeToSQLDate(agentLastUpdateDate), enumFilteredDataObjectType.SQL, "Name", , "PKey")
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim drFound As DataRow = dtAgent.Rows.Find(dt.Rows(i)("PKey"))
                    Dim drNew As DataRow = dt.Rows(i)
                    If drFound IsNot Nothing Then
                        dtAgent.Rows.Remove(drFound)
                    End If
                    dtAgent.ImportRow(drNew)
                Next
                dtAgent.DefaultView.Sort = "Name ASC"
                agentLastUpdateDate = Now
            End If
        End If
        Return dtAgent
    End Function


    'Function for Filtered Data Vessel and Agent
    Public Enum enumFilteredDataObjectType
        OBJ = 1
        SQL = 2
    End Enum

    Public Function getFilteredData(ByVal MPSDB As SQLDB, ByVal Source As String, ByVal SourceType As enumFilteredDataObjectType, Optional OrderBy As String = "", Optional ByVal UserID As Object = "CURRENT_USER", Optional AgentFieldName As String = "", Optional PrinFieldName As String = "", Optional FltFieldName As String = "", Optional ShowErrMsg As Boolean = False) As DataTable
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnVal As String = ""
        Dim returnErr As String = ""
        Dim sqlConn As New SqlClient.SqlConnection
        Dim dt As New DataTable

        If SourceType <> enumFilteredDataObjectType.OBJ And SourceType <> enumFilteredDataObjectType.SQL Then
            returnErr = "Invalid source type parameter."
            GoTo RETURN_ERROR_AND_EXIT
        End If

        If UserID = "CURRENT_USER" Then UserID = USER_ID

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                returnErr = "Unable to open connection."
                GoTo RETURN_ERROR_AND_EXIT
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                returnErr = "sql connection is nothing"
                GoTo RETURN_ERROR_AND_EXIT
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand()
                Dim da As New System.Data.SqlClient.SqlDataAdapter


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "CreateFilteredData"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("_Source", Source)
                sqlComm.Parameters.AddWithValue("_SourceType", IIf(SourceType = enumFilteredDataObjectType.OBJ, "OBJ", IIf(SourceType = enumFilteredDataObjectType.SQL, "SQL", "")))
                sqlComm.Parameters.AddWithValue("_AgentFieldName", AgentFieldName)
                sqlComm.Parameters.AddWithValue("_PrinFieldName", PrinFieldName)
                sqlComm.Parameters.AddWithValue("_FltFieldName", FltFieldName)
                sqlComm.Parameters.AddWithValue("_OrderBy", OrderBy)
                sqlComm.Parameters.AddWithValue("UserID", UserID)

                da.SelectCommand = sqlComm

                Try

                    da.Fill(dt)

                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next
                    GoTo RETURN_ERROR_AND_EXIT

                End Try


            End If
            sqlConn.Close()
        End Using
        Return dt

        Exit Function
RETURN_ERROR_AND_EXIT:
        MsgBox(returnErr, MsgBoxStyle.Exclamation, "Get Data Source")
        Return dt
    End Function

End Module
