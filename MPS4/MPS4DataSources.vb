Public Module MPS4DataSources


    Public Enum FilteredDataObjectType
        OBJ = 1
        SQL = 2
    End Enum

    Public Enum StatusType
        Onboard = 1
        Ashore = 3
        SignOffReason = 2
    End Enum

    Public Structure FlightStatus
        Const Requested As String = "Requested"
        Const Waitlisted As String = "Waitlisted"
        Const Confirmed As String = "Confirmed"
    End Structure

#Region "Database Connection"
    Function InitAppConnection() As Boolean
        Dim frmcon As New frmConnect(True)
        frmcon.ShowDialog()
        If frmcon.bQuitApp Then
            Return False
            Exit Function
        Else
            Return True
        End If
    End Function
#End Region

#Region "Generic Data Sources"
    'Charge Type
    Public Function getChargeType() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
        ctable.Columns.Add("Name", System.Type.GetType("System.String"))
        ctable.Rows.Add("0", "None")
        ctable.Rows.Add("1", "Charge To Company")
        ctable.Rows.Add("2", "Charge To Crew")
        Return ctable
    End Function

    'Address Status DataTable
    Public Function GetAddStat() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {"1", "Current"}
        ctable.Rows.Add(crow)
        crow(0) = "2"
        crow(1) = "Previous"
        ctable.Rows.Add(crow)
        Return ctable
    End Function

    'Employee Type Code
    Public Function getEmpType() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
        ctable.Columns.Add("Name", System.Type.GetType("System.String"))
        ctable.Rows.Add("1", "Contractual")
        ctable.Rows.Add("2", "Permanent")
        Return ctable
    End Function

    'Civil Status Table
    Public Function getCivilStatus() As DataTable
        Dim ctable As New DataTable
        ctable = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmCivilStat ORDER BY SortCode ASC")
        Return ctable
    End Function

    'Gender Table
    Public Function GetSex() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {"1", "Male"}
        ctable.Rows.Add(crow)
        crow(0) = "2"
        crow(1) = "Female"
        ctable.Rows.Add(crow)
        Return ctable
    End Function

    'Hire Status
    Public Function GetHireStat() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.Int16")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object
        crow = {2, "Newly Hired"}
        ctable.Rows.Add(crow)
        crow = {1, "Rehired"}
        ctable.Rows.Add(crow)
        Return ctable
    End Function

    Public Function GetStatType() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
        ctable.Columns.Add("Name", System.Type.GetType("System.String"))

        ctable.Rows.Add("1", "ONBOARD STATUS")
        ctable.Rows.Add("2", "SIGNOFF REASON")
        ctable.Rows.Add("3", "ASHORE STATUS")

        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "PKey"
        'ccolumn.DataType = System.Type.GetType("System.String")
        'ctable.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "Name"
        'ccolumn.DataType = System.Type.GetType("System.String")
        'ctable.Columns.Add(ccolumn)
        'Dim crow() As Object = {"1", "ONBOARD"}
        'ctable.Rows.Add(crow)
        'crow(0) = "2"
        'crow(1) = "SIGNOFF Reason"
        'ctable.Rows.Add(crow)
        'crow(0) = "3"
        'crow(1) = "ASHORE"
        'ctable.Rows.Add(crow)

        Return ctable
    End Function

    Public Structure RetentionRateTerminationType
        Public Const NotApplicable As String = "NOTAPPLICABLE"
        Public Const Unavoidable As String = "UNAVOIDABLE"
        Public Const Beneficial As String = "BENEFICIAL"
    End Structure

    Public Function GetRetentionRateTerminationType() As DataTable
        Dim ctable As New DataTable
        ctable.Columns.Add("PKey", System.Type.GetType("System.String"))
        ctable.Columns.Add("Name", System.Type.GetType("System.String"))
        ctable.Columns.Add("Description", System.Type.GetType("System.String"))

        ctable.Rows.Add(RetentionRateTerminationType.NotApplicable, "Not Applicable", "")
        ctable.Rows.Add(RetentionRateTerminationType.Unavoidable, "Unavoidable Termination", "(i.e. retirement or long term illness)")
        ctable.Rows.Add(RetentionRateTerminationType.Beneficial, "Beneficial Termination", "(i.e. sometimes those staff that do leave provide benefit to the company by virtue of leaving, for example under performers)")
        Return ctable
    End Function

    Public Function getCourseType() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {1, "STCW"}
        ctable.Rows.Add(crow)
        crow(0) = 2
        crow(1) = "Company Required"
        ctable.Rows.Add(crow)
        crow(0) = 3
        crow(1) = "Others"
        ctable.Rows.Add(crow)

        crow(0) = 4
        crow(1) = "Safety"
        ctable.Rows.Add(crow)

        crow(0) = 5
        crow(1) = "Technical"
        ctable.Rows.Add(crow)
        Return ctable
    End Function

    Public Function getCouseStatus() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {1, "Planned"}
        ctable.Rows.Add(crow)
        crow(0) = 2
        crow(1) = "Required"
        ctable.Rows.Add(crow)
        crow(0) = 3
        crow(1) = "Completed"
        ctable.Rows.Add(crow)
        Return ctable
    End Function

    'Secret Questions
    Public Function SecQuestion() As DataTable
        Dim list As New DataTable
        With list
            .Columns.Add("Code", System.Type.GetType("System.String"))
            .Columns.Add("Question", System.Type.GetType("System.String"))
        End With
        'Questions
        Dim crow() As Object = {"1", "What is the name of your Favorite pet?"}
        list.Rows.Add(crow)
        crow(0) = "2"
        crow(1) = "What is the name of your first school?"
        list.Rows.Add(crow)
        crow(0) = "3"
        crow(1) = "What is your favorite movie?"
        list.Rows.Add(crow)
        crow(0) = "4"
        crow(1) = "What is your mother's maiden name?"
        list.Rows.Add(crow)
        crow(0) = "5"
        crow(1) = "When is your anniversary?"
        list.Rows.Add(crow)
        crow(0) = "6"
        crow(1) = "What is your father's middle name?"
        list.Rows.Add(crow)
        Return list
    End Function

    Public Class StoredProcedureCommand
        Public Name As String
        Public DB As SQLDB = MPSDB
        Public Parameters As New List(Of SPParameter)

        Sub New()

        End Sub

        Sub New(StoredProcedureName As String, Optional ChangeSQLDBObjectTo As SQLDB = Nothing)
            Name = StoredProcedureName

            If Not IsNothing(ChangeSQLDBObjectTo) Then
                DB = ChangeSQLDBObjectTo
            End If
        End Sub

        Public Function Execute(ReturnType As ReturnType, Optional ShowErrorMessage As Boolean = True) As Object
            Dim ReturnValue As Object = Nothing
            Dim returnErr As String = ""
            Dim sqlConn As New SqlClient.SqlConnection

            Using sqlConn
                sqlConn.ConnectionString = DB.GetConnectionString
                Try
                    sqlConn.Open()
                Catch ex As Exception
                    returnErr = "Unable to open connection."
                    GoTo RETURN_AND_EXIT
                End Try

                If sqlConn.State <> ConnectionState.Open Then
                    returnErr = "sql connection is nothing"
                    GoTo RETURN_AND_EXIT

                Else
                    Dim sqlComm As New System.Data.SqlClient.SqlCommand
                    Dim da As New System.Data.SqlClient.SqlDataAdapter

                    sqlComm.Connection = sqlConn

                    sqlComm.CommandText = Me.Name
                    sqlComm.CommandType = CommandType.StoredProcedure
                    For Each param As SPParameter In Parameters
                        sqlComm.Parameters.AddWithValue(param.Name, param.Value)
                        If param.OutputParam Then
                            sqlComm.Parameters(param.Name).Direction = ParameterDirection.Output
                        End If
                    Next


                    Select Case ReturnType
                        Case ReturnType.ReturnValue
                            Dim retParameter As IDbDataParameter = sqlComm.CreateParameter()
                            retParameter.ParameterName = "@ReturnValue"
                            retParameter.Direction = System.Data.ParameterDirection.Output
                            retParameter.DbType = System.Data.DbType.String
                            retParameter.Size = -1
                            sqlComm.Parameters.Add(retParameter)

                            Try
                                sqlComm.ExecuteNonQuery()
                                ReturnValue = retParameter.Value
                            Catch SqlEx As System.Data.SqlClient.SqlException
                                Dim myError As System.Data.SqlClient.SqlError
                                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                                For Each myError In SqlEx.Errors
                                    returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                                Next
                                GoTo RETURN_AND_EXIT
                            End Try

                        Case ReturnType.Table
                            da.SelectCommand = sqlComm

                            Try
                                Dim dt As New DataTable
                                da.Fill(dt)

                                ReturnValue = dt

                            Catch SqlEx As System.Data.SqlClient.SqlException
                                Dim myError As System.Data.SqlClient.SqlError
                                'Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                                For Each myError In SqlEx.Errors
                                    returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                                Next
                                GoTo RETURN_AND_EXIT

                            End Try

                        Case StoredProcedureCommand.ReturnType.DataSet
                            da.SelectCommand = sqlComm

                            Try
                                Dim ds As New DataSet
                                da.Fill(ds)

                                ReturnValue = ds

                            Catch SqlEx As System.Data.SqlClient.SqlException
                                Dim myError As System.Data.SqlClient.SqlError
                                'Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                                For Each myError In SqlEx.Errors
                                    returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                                Next
                                GoTo RETURN_AND_EXIT

                            End Try

                        Case StoredProcedureCommand.ReturnType.ExecuteAndReturnRecordsAffected
                            Try
                                ReturnValue = (sqlComm.ExecuteNonQuery > 0)
                            Catch SqlEx As System.Data.SqlClient.SqlException
                                Dim myError As System.Data.SqlClient.SqlError
                                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                                For Each myError In SqlEx.Errors
                                    returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                                Next
                                GoTo RETURN_AND_EXIT
                            End Try

                    End Select


                End If
                sqlConn.Close()
                sqlConn.Dispose()
            End Using

RETURN_AND_EXIT:
            If sqlConn.State <> ConnectionState.Closed Then
                sqlConn.Close()
                sqlConn.Dispose()
            End If
            If returnErr.Length > 0 Then
                MsgBox(returnErr, MsgBoxStyle.Exclamation)
            End If
            Return ReturnValue
        End Function


        Public Enum ReturnType
            Table = 1
            DataSet = 4
            ReturnValue = 2
            ExecuteAndReturnRecordsAffected = 3
        End Enum

        Public Class SPParameter
            Public Name As String = ""
            Public Value As Object = vbNull
            Public SqlDbType As SqlDbType = SqlDbType.NVarChar
            Public OutputParam As Boolean

            Sub New()

            End Sub

            Sub New(cVariableName As String, oParameterValue As Object, Optional isOutputParam As Boolean = False)
                Name = cVariableName
                Value = oParameterValue
                OutputParam = isOutputParam
            End Sub

            Sub New(cVariableName As String, oSqlDbType As SqlDbType, Optional isOutputParam As Boolean = False)
                Name = cVariableName
                SqlDbType = oSqlDbType
                OutputParam = isOutputParam
            End Sub

            Sub New(cVariableName As String, oSqlDbType As SqlDbType, oParameterValue As Object, Optional isOutputParam As Boolean = False)
                Name = cVariableName
                SqlDbType = oSqlDbType
                Value = oParameterValue
                OutputParam = isOutputParam
            End Sub
        End Class
    End Class

#End Region

#Region "Admin"

    Public Function GetVslStat() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {"1", "Active"}
        ctable.Rows.Add(crow)
        crow(0) = "2"
        crow(1) = "Inactive"
        ctable.Rows.Add(crow)
        Return ctable
    End Function
#End Region

#Region "Crew"
    Public CREW_DATATABLE As DataTable
    Public CREWLIST_DATASET As New DataSet
    Private forceRef As Boolean = False

    Public Function getCrewListDataTable(_query As String, Optional _RefreshList As String = "Automatic") As DataTable
        Dim retTable As New DataTable

        If _RefreshList.Equals("Automatic") Or forceRef = True Then
            retTable = MPSDB.CreateTable(_query)
            'retTable = CREW_DATATABLE
            CREW_DATATABLE = retTable
            forceRefresh(False)
        Else
            If IsNothing(CREW_DATATABLE) Then
                retTable = MPSDB.CreateTable(_query)
                CREW_DATATABLE = retTable
            Else
                'CREW_DATATABLE.Dispose()
                'CREW_DATATABLE.Clear()
                retTable = CREW_DATATABLE
            End If
        End If
        Return retTable
    End Function

    Public Function getCrewListActivitiesDTs(_query As String, tblName As String, Optional _RefreshList As String = "Automatic") As DataTable
        Dim retTable As New DataTable
        Dim tempDT As DataTable
        If _RefreshList.Equals("Automatic") Then
            tempDT = MPSDB.CreateTable(_query)
            'retTable = CREW_DATATABLE
            If CREWLIST_DATASET.Tables.Count > 0 Then
                If CREWLIST_DATASET.Tables.Contains(tblName) Then
                    CREWLIST_DATASET.Tables.Remove(tblName)
                End If
            End If
            CREWLIST_DATASET.Tables.Add(tempDT)
            CREWLIST_DATASET.Tables("Table1").TableName = tblName
        Else
            If CREWLIST_DATASET.Tables.Contains(tblName) = False Then
                tempDT = MPSDB.CreateTable(_query)
                CREWLIST_DATASET.Tables.Add(tempDT)
                CREWLIST_DATASET.Tables("Table1").TableName = tblName
            Else
                tempDT = CREWLIST_DATASET.Tables(tblName)
            End If
        End If
        retTable = tempDT.Copy
        Return retTable
    End Function

    'Added by Calvhin
    Public Sub forceRefresh(ByVal force As Boolean)
        forceRef = force
    End Sub
#End Region

#Region "Payroll"
    Public Function dtDateType() As DataTable
        Dim retValue As New DataTable
        retValue.Columns.Add("PKey", GetType(Integer))
        retValue.Columns.Add("Name", GetType(String))
        retValue.Rows.Add("1", "Departed / Arrived")
        retValue.Rows.Add("2", "Signed On / Off")
        Return retValue
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetPayPeriods() As DataTable
        Dim ctable As New DataTable
        Dim Interval As String = MPSDB.GetConfig("PayPeriodInterval")
        Dim MinValue As String = MPSDB.GetConfig("PayPeriodMin")
        Dim MaxValue As String = MPSDB.GetConfig("PayPeriodMax")
        ctable = MPSDB.CreateTable("EXEC dbo.GetPeriodsInterval '" & Interval.ToUpper & "' , " & MinValue & "," & MaxValue)
        Return ctable
    End Function
#End Region

#Region "User-Data Filter Functions/Procedures"
    Public Function getPredefDataSource(ByVal Code As String, Optional ByVal UserID As Object = "CURRENT_USER", Optional ShowErrMsg As Boolean = False) As DataTable
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnVal As String = ""
        Dim returnErr As String = ""
        Dim sqlConn As New SqlClient.SqlConnection
        Dim dt As New DataTable

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

                sqlComm.CommandText = "GetPredefDataSource"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("UserID", UserID)
                sqlComm.Parameters.AddWithValue("Code", Code)

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

    Public Function createFilteredData(ByVal Source As String, ByVal SourceType As FilteredDataObjectType, Optional OrderBy As String = "", Optional ByVal UserID As Object = "CURRENT_USER", Optional AgentFieldName As String = "", Optional PrinFieldName As String = "", Optional FltFieldName As String = "", Optional ShowErrMsg As Boolean = False) As DataTable
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnVal As String = ""
        Dim returnErr As String = ""
        Dim sqlConn As New SqlClient.SqlConnection
        Dim dt As New DataTable

        If SourceType <> FilteredDataObjectType.OBJ And SourceType <> FilteredDataObjectType.SQL Then
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
                sqlComm.Parameters.AddWithValue("_SourceType", IIf(SourceType = FilteredDataObjectType.OBJ, "OBJ", IIf(SourceType = FilteredDataObjectType.SQL, "SQL", "")))
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetUserFilterString(Optional ByVal UserID As Object = "CURRENT_USER", Optional ByVal AgentFldName As String = "", Optional ByVal PrinFldName As String = "", Optional ByVal FltFldName As String = "") As String
        '### description: returns criteria string based on passed field names: agent, principal and/or fleet

        Dim returnVal As String = ""
        Dim returnErr As String = ""
        Dim sqlConn As New SqlClient.SqlConnection

        If UserID = "CURRENT_USER" Then UserID = USER_ID

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                returnErr = "Unable to open connection."
                GoTo SHOW_ERROR_AND_EXIT
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                returnErr = "sql connection is nothing"
                GoTo SHOW_ERROR_AND_EXIT
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_userdatafilterstring"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("UserID", UserID)
                sqlComm.Parameters.AddWithValue("agentfldname", AgentFldName)
                sqlComm.Parameters.AddWithValue("prinfldname", PrinFldName)
                sqlComm.Parameters.AddWithValue("fltfldname", FltFldName)

                Dim retParameter As IDbDataParameter = sqlComm.CreateParameter()
                retParameter.ParameterName = "@ReturnValue"
                retParameter.Direction = System.Data.ParameterDirection.Output
                retParameter.DbType = System.Data.DbType.String
                retParameter.Size = -1
                sqlComm.Parameters.Add(retParameter)

                Try
                    sqlComm.ExecuteNonQuery()
                    returnVal = retParameter.Value
                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next
                    GoTo SHOW_ERROR_AND_EXIT
                End Try

            End If
            sqlConn.Close()
        End Using
        Return returnVal

        Exit Function
SHOW_ERROR_AND_EXIT:
        MsgBox(returnErr, MsgBoxStyle.Exclamation, "User-Data Filter Assignment Initialization")
        Return returnVal
    End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetUserVslFilterString(Optional ByVal UserID As Object = "CURRENT_USER", Optional ByVal VslFldName As String = "") As String
        '### description: returns criteria string based on passed field names: agent, principal and/or fleet

        Dim returnVal As String = ""
        Dim returnErr As String = ""
        Dim sqlConn As New SqlClient.SqlConnection

        If UserID = "CURRENT_USER" Then UserID = USER_ID

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                returnErr = "Unable to open connection."
                GoTo SHOW_ERROR_AND_EXIT
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                returnErr = "sql connection is nothing"
                GoTo SHOW_ERROR_AND_EXIT
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_userdatavslfilterstring"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("UserID", UserID)
                sqlComm.Parameters.AddWithValue("vslfldname", VslFldName)

                Dim retParameter As IDbDataParameter = sqlComm.CreateParameter()
                retParameter.ParameterName = "@ReturnValue"
                retParameter.Direction = System.Data.ParameterDirection.Output
                retParameter.DbType = System.Data.DbType.String
                retParameter.Size = -1
                sqlComm.Parameters.Add(retParameter)

                Try
                    sqlComm.ExecuteNonQuery()
                    returnVal = retParameter.Value
                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next
                    GoTo SHOW_ERROR_AND_EXIT
                End Try

            End If
            sqlConn.Close()
        End Using
        Return returnVal

        Exit Function
SHOW_ERROR_AND_EXIT:
        MsgBox(returnErr, MsgBoxStyle.Exclamation, "User-Data Filter Assignment Initialization")
        Return returnVal
    End Function

    Function GetUserFilterDT(Optional ByVal UserID As Object = "CURRENT_USER") As DataTable
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim dt As New DataTable
        Dim returnErr As String = ""
        Dim sqlConn As New SqlClient.SqlConnection

        If UserID = "CURRENT_USER" Then UserID = USER_ID

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            'dbconn.closeconn()
            Try
                sqlConn.Open()
            Catch ex As Exception
                returnErr = "Unable to open connection."
                GoTo SHOW_ERROR_AND_EXIT
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                returnErr = "sql connection is nothing"
                GoTo SHOW_ERROR_AND_EXIT
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_userdatafilter"
                sqlComm.CommandType = CommandType.StoredProcedure
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
                    GoTo SHOW_ERROR_AND_EXIT

                End Try


            End If
            sqlConn.Close()
        End Using
        Return dt

        Exit Function
SHOW_ERROR_AND_EXIT:
        MsgBox(returnErr, MsgBoxStyle.Exclamation, "User-Data Filter Assignment Initialization")
        Return dt
    End Function

    Function UserHasDataFilter(Optional ByVal UserID As Object = "CURRENT_USER", Optional ShowNoUserDataMessage As Boolean = False) As Boolean
        Dim bRetval As Boolean = True
        Dim cMessage As String = ""
        Dim cFilterAssignment = ""

        Dim dt As DataTable = GetUserFilterDT(UserID)
        Try
            If dt.Rows.Count > 0 Then
                Dim cFilterType As String = dt.Rows(0).Item("FilterType")
                Select Case cFilterType
                    Case "BY AGENT"
                        If dt.Rows(0).Item("AgentFilterList").ToString.Length = 0 Then
                            cFilterAssignment = "agent"
                            bRetval = False
                        End If
                    Case "BY PRINCIPAL"
                        If dt.Rows(0).Item("PrinFilterList").ToString.Length = 0 Then
                            cFilterAssignment = "principal"
                            bRetval = False
                        End If

                    Case "BY FLEET"
                        If dt.Rows(0).Item("FltFilterList").ToString.Length = 0 Then
                            cFilterAssignment = "fleet"
                            bRetval = False
                        End If

                    Case "NO PERMISSION"
                        cFilterAssignment = "NO PERMISSION"
                        bRetval = False
                End Select
            Else
                cFilterAssignment = "NO PERMISSION"
                bRetval = False
            End If
        Catch ex As Exception
            cFilterAssignment = "NO PERMISSION"
            bRetval = False
        End Try

        If Not bRetval Then
            If cFilterAssignment = "NO PERMISSION" Then
                cMessage = "Your account is not assigned with any filter assingment type. The program will proceed to open but you may not be able to see any crew/s at all."
            Else
                cMessage = "Youe account is assigned with a filter type [BY " & UCase(cFilterAssignment) & "] but is not assigned with any " & cFilterAssignment & "(s) to manage. The program will proceed to open but you may only see crews that are not under any " & cFilterAssignment & " management."
            End If

            If cMessage.Length > 0 And ShowNoUserDataMessage Then MsgBox("Reminder : " & Chr(13) & Chr(13) & cMessage & Chr(13) & Chr(13) & "Contact your system administrator for assistance.", vbInformation, "MPS5")
        End If

        Return bRetval
    End Function
#End Region
End Module
