Imports System.Data.SqlClient

Public Class clsSecurity

    'Dim clsSQLDB As SQLDB
    Private sqlConn As New SqlClient.SqlConnection
    Private sqlConnStr As String
    Private DTablePermission As New DataTable



    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Public Property propSQLConnStr As String
        Get
            Return sqlConnStr
        End Get
        Set(value As String)
            sqlConnStr = value
        End Set
    End Property

    Public Property propSQLConn As SqlClient.SqlConnection
        Get
            Return sqlConn
        End Get
        Set(value As SqlClient.SqlConnection)
            sqlConn = value
        End Set
    End Property

    Function add_user(sUName As String, Optional sUPass As String = "<NO_CHANGES>", Optional ByRef GenID As Int64 = 0, Optional SecQuestion As String = "<NO_CHANGES>", _
                        Optional SecAnswer As String = "<NO_CHANGES>", Optional LastUpdatedBy As String = "<NO_CHANGES>", _
                        Optional FullName As String = "<NO_CHANGES>", Optional Description As String = "<NO_CHANGES>", Optional EmployeeID As String = "<NO_CHANGES>", Optional ContactInfo As String = "<NO_CHANGES>") As String
        'parameters edited by tony20171124 - Added FullName, Description, EmployeeID, Contact Information

        Dim returnKo As String = ""
        Dim sqlComm As New SqlCommand()

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_add_user"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("sUName", sUName)
                sqlComm.Parameters.AddWithValue("sUPass", sUPass)
                sqlComm.Parameters.AddWithValue("SecQuestion", SecQuestion)
                sqlComm.Parameters.AddWithValue("SecAnswer", SecAnswer)
                sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                sqlComm.Parameters.AddWithValue("FullName", FullName)
                sqlComm.Parameters.AddWithValue("Description", Description)
                sqlComm.Parameters.AddWithValue("EmployeeID", EmployeeID)
                sqlComm.Parameters.AddWithValue("ContactInfo", ContactInfo)
                sqlComm.Parameters.Add("GenId", SqlDbType.BigInt)
                sqlComm.Parameters("GenId").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    'GenID = sqlComm.Parameters("GenID").Value
                    GenID = IfNull(sqlComm.Parameters("GenID").Value, 0)
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
            'GenID = sqlComm.Parameters("GenID").Value
        End Using
        Return returnKo

    End Function

    Function add_user_to_group(UserID As Int64, GroupID As Int64, Optional LastUpdatedBy As String = "<NO_CHANGES>", _
                                Optional closeConn As Boolean = True)

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        'Using sqlConn
        If sqlConn.State <> ConnectionState.Open Then
            sqlConn.ConnectionString = propSQLConnStr
            sqlConn.Open()
        End If

        If sqlConn.State <> ConnectionState.Open Then
            returnKo = "sql connection is nothing/cannot connect"
        Else
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlConn

            sqlComm.CommandText = "sec_add_user_toGroup"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("UserID", UserID)
            sqlComm.Parameters.AddWithValue("GroupID", GroupID)
            sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
            'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

            'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

            Try
                sqlComm.ExecuteNonQuery()
                'returnKo = ""
            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
            'Try
            '    sqlComm.ExecuteNonQuery()
            '    'returnKo = ""
            'Catch ex As Exception
            '    returnKo = Err.Description
            'End Try

        End If

        If closeConn Then
            sqlConn.Close()
        End If
        'End Using

        'End If
        Return returnKo
    End Function

    Function add_obj_to_group(ObjectID As String, GroupID As Int64, Optional CanAdd As Long = 0, Optional CanUpdate As Long = 0, _
                              Optional CanDelete As Long = 0, Optional ViewOnly As Long = 0, Optional CanDataTool As Long = 0, _
                              Optional LastUpdatedBy As String = "<NO_CHANGES>", _
                              Optional closeConn As Boolean = True)

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        'Using sqlConn
        If sqlConn.State <> ConnectionState.Open Then
            sqlConn.ConnectionString = propSQLConnStr
            sqlConn.Open()
        End If

        If sqlConn.State <> ConnectionState.Open Then
            returnKo = "sql connection is nothing/cannot connect"
        Else
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlConn

            sqlComm.CommandText = "sec_add_object_toGroup"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("ObjectID", ObjectID)
            sqlComm.Parameters.AddWithValue("GroupID", GroupID)
            sqlComm.Parameters.AddWithValue("CanUpdate", CanUpdate)
            sqlComm.Parameters.AddWithValue("CanAdd", CanAdd)
            sqlComm.Parameters.AddWithValue("CanDelete", CanDelete)
            sqlComm.Parameters.AddWithValue("ViewOnly", ViewOnly)
            sqlComm.Parameters.AddWithValue("CanDataTool", CanDataTool)
            sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
            'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

            'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

            Try
                sqlComm.ExecuteNonQuery()
                'returnKo = ""
            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
            'Try
            '    sqlComm.ExecuteNonQuery()
            '    'returnKo = ""
            'Catch ex As Exception
            '    returnKo = Err.Description
            'End Try

        End If

        If closeConn Then
            sqlConn.Close()
        End If
        'End Using

        'End If
        Return returnKo
    End Function

    Function add_objrpt_to_group(ObjectID As String, GroupID As Int64, Optional CanView As Long = 0,
                            Optional LastUpdatedBy As String = "<NO_CHANGES>", _
                            Optional closeConn As Boolean = True, Optional ReportGroup As String = "<NOT_DEFINED>") As String

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        'Using sqlConn
        If sqlConn.State <> ConnectionState.Open Then
            sqlConn.ConnectionString = propSQLConnStr
            sqlConn.Open()
        End If

        If sqlConn.State <> ConnectionState.Open Then
            returnKo = "sql connection is nothing/cannot connect"
        Else
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlConn

            sqlComm.CommandText = "sec_add_objectRpt_toGroup"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("ObjectID", ObjectID)
            sqlComm.Parameters.AddWithValue("GroupID", GroupID)
            sqlComm.Parameters.AddWithValue("CanView", CanView)
            sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
            sqlComm.Parameters.AddWithValue("ReportGroup", ReportGroup)
            'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

            'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

            Try
                sqlComm.ExecuteNonQuery()
                'returnKo = ""
            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
            'Try
            '    sqlComm.ExecuteNonQuery()
            '    'returnKo = ""
            'Catch ex As Exception
            '    returnKo = Err.Description
            'End Try

        End If

        If closeConn Then
            sqlConn.Close()
        End If
        'End Using

        'End If
        Return returnKo
    End Function

    Function add_group(grpName As String, Optional LastUpdatedBy As String = "<NO_CHANGES>", Optional ByRef GenID As Int64 = 0)

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_add_group"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("Name", grpName)
                sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

                'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

                sqlComm.Parameters.Add("GenId", SqlDbType.BigInt)
                sqlComm.Parameters("GenId").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    GenID = IfNull(sqlComm.Parameters("GenID").Value, 0)
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function

    'affRows = affected rows of update
    Function update_group(GrpID As Long, grpName As String, Optional LastUpdatedBy As String = "<NO_CHANGES>", Optional ByRef affRows As Long = 0)

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_update_group"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("GrpID", GrpID)
                sqlComm.Parameters.AddWithValue("Name", grpName)
                sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                sqlComm.Parameters.Add("affRows", SqlDbType.BigInt)
                sqlComm.Parameters("affRows").Direction = ParameterDirection.Output


                Try
                    sqlComm.ExecuteNonQuery()
                    affRows = sqlComm.Parameters("affRows").Value
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function

    'affRows = affected rows of update
    Function update_user(UserID As Integer, sUName As String, Optional sUPass As String = "<NO_CHANGES>", Optional SecQuestion As String = "<NO_CHANGES>", _
                        Optional SecAnswer As String = "<NO_CHANGES>", Optional LastUpdatedBy As String = "<NO_CHANGES>", _
                        Optional FullName As String = "<NO_CHANGES>", Optional Description As String = "<NO_CHANGES>", Optional EmployeeID As String = "<NO_CHANGES>", Optional ContactInfo As String = "<NO_CHANGES>", _
                        Optional ByRef affRows As Long = 0)
        'parameters edited by tony20171124 - Added FullName, Description, EmployeeID, Contact Information

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_update_user"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("UserID", UserID)
                sqlComm.Parameters.AddWithValue("sUName", sUName)
                sqlComm.Parameters.AddWithValue("sUPass", sUPass)
                sqlComm.Parameters.AddWithValue("SecQuestion", SecQuestion)
                sqlComm.Parameters.AddWithValue("SecAnswer", SecAnswer)
                sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                sqlComm.Parameters.AddWithValue("FullName", FullName)
                sqlComm.Parameters.AddWithValue("Description", Description)
                sqlComm.Parameters.AddWithValue("EmployeeID", EmployeeID)
                sqlComm.Parameters.AddWithValue("ContactInfo", ContactInfo)
                sqlComm.Parameters.Add("affRows", SqlDbType.BigInt)
                sqlComm.Parameters("affRows").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    affRows = sqlComm.Parameters("affRows").Value
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function

    '---------------------------------------------------------
    'not in use, instead del_obj_frGroup then add_obj_toGroup
    '---------------------------------------------------------
    'affRows = affected rows of update
    Function update_group_objects_perm(GroupID As Integer, ObjectID As String, Optional CanDelete As Integer = 3, Optional CanAdd As Integer = 3, _
                                         Optional CanUpdate As Integer = 3, Optional ViewOnly As Integer = 3, _
                                         Optional LastUpdatedBy As String = "<NO_CHANGES>", Optional ByRef affRows As Long = 0)

        'No. 3 will treat by Stored proc as no changes for the field.
        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_update_grpObjperm"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("GroupID", GroupID)
                sqlComm.Parameters.AddWithValue("ObjectID", ObjectID)
                sqlComm.Parameters.AddWithValue("CanDelete", CanDelete)
                sqlComm.Parameters.AddWithValue("CanAdd", CanAdd)
                sqlComm.Parameters.AddWithValue("CanUpdate", CanUpdate)
                sqlComm.Parameters.AddWithValue("ViewOnly", ViewOnly)
                sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                sqlComm.Parameters.Add("affRows", SqlDbType.BigInt)
                sqlComm.Parameters("affRows").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    affRows = sqlComm.Parameters("affRows").Value
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function

    Function del_user_frGroup(UserID As Int64, Optional GroupID As Int64 = 9999, Optional closeConn As Boolean = True)
        'if you pass false to var closeConn. close it later. 

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        'Using sqlConn
        If sqlConn.State <> ConnectionState.Open Then
            sqlConn.ConnectionString = propSQLConnStr
            sqlConn.Open()
        End If

        If sqlConn.State <> ConnectionState.Open Then
            returnKo = "sql connection is nothing/cannot connect"
        Else
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlConn

            sqlComm.CommandText = "sec_del_user_frGroup"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("UserID", UserID)
            sqlComm.Parameters.AddWithValue("GroupID", GroupID)
            'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

            'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

            Try
                sqlComm.ExecuteNonQuery()
                'returnKo = ""
            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
            'Try
            '    sqlComm.ExecuteNonQuery()
            '    'returnKo = ""
            'Catch ex As Exception
            '    returnKo = Err.Description
            'End Try

        End If

        If closeConn Then
            sqlConn.Close()
        End If
        ' End Using

        'End If
        Return returnKo
    End Function

    Function del_obj_frGroup(ObjectID As String, Optional GroupID As Int64 = 9999, Optional closeConn As Boolean = True)
        'if you pass false to var closeConn. close it later. 

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        'Using sqlConn
        If sqlConn.State <> ConnectionState.Open Then
            sqlConn.ConnectionString = propSQLConnStr
            sqlConn.Open()
        End If

        If sqlConn.State <> ConnectionState.Open Then
            returnKo = "sql connection is nothing/cannot connect"
        Else
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlConn

            sqlComm.CommandText = "sec_del_object_frGroup"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("ObjectID", ObjectID)
            sqlComm.Parameters.AddWithValue("GroupID", GroupID)
            'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

            'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

            Try
                sqlComm.ExecuteNonQuery()
                'returnKo = ""
            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
            'Try
            '    sqlComm.ExecuteNonQuery()
            '    'returnKo = ""
            'Catch ex As Exception
            '    returnKo = Err.Description
            'End Try

        End If

        If closeConn Then
            sqlConn.Close()
        End If
        ' End Using

        'End If
        Return returnKo
    End Function

    Function del_objRpt_frGroup(ObjectID As String, Optional GroupID As Int64 = 9999, Optional closeConn As Boolean = True,
                                 Optional ReportGroup As String = "<NOT_DEFINED>") As String
        'if you pass false to var closeConn. close it later. 

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        'Using sqlConn
        If sqlConn.State <> ConnectionState.Open Then
            sqlConn.ConnectionString = propSQLConnStr
            sqlConn.Open()
        End If

        If sqlConn.State <> ConnectionState.Open Then
            returnKo = "sql connection is nothing/cannot connect"
        Else
            Dim sqlComm As New SqlCommand()

            sqlComm.Connection = sqlConn

            sqlComm.CommandText = "sec_del_objectRpt_frGroup"
            sqlComm.CommandType = CommandType.StoredProcedure

            sqlComm.Parameters.AddWithValue("ObjectID", ObjectID)
            sqlComm.Parameters.AddWithValue("GroupID", GroupID)
            sqlComm.Parameters.AddWithValue("ReportGroup", ReportGroup)
            'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

            'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

            Try
                sqlComm.ExecuteNonQuery()
                'returnKo = ""
            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
            'Try
            '    sqlComm.ExecuteNonQuery()
            '    'returnKo = ""
            'Catch ex As Exception
            '    returnKo = Err.Description
            'End Try

        End If

        If closeConn Then
            sqlConn.Close()
        End If
        ' End Using

        'End If
        Return returnKo
    End Function

    Function del_group(GroupID As Integer)

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_del_group"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("GroupID", GroupID)
                'sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

                'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

                Try
                    sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function


    Function del_User(UserID As Integer)

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_del_user"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("UserID", UserID)
                'sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

                'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

                Try
                    sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function

    Sub get_permissions_dtable(UserID As Integer, ObjectID As String, ByRef strPermission As String,
                                Optional ByRef UserDTable As DataTable = Nothing)
        Dim foundRow() As DataRow

        If UserDTable Is Nothing Then
            If Me.DTablePermission.Rows.Count > 0 Then
                foundRow = Me.DTablePermission.Select("UserID = '" & UserID & "' and objectid = '" & ObjectID & "'")
                If foundRow.Length <> 0 Then
                    strPermission = foundRow(0)(0)
                Else
                    strPermission = ""
                End If
            End If
        Else
            If UserDTable.Rows.Count > 0 Then
                foundRow = UserDTable.Select("UserID = '" & UserID & "' and objectid = '" & ObjectID & "'")
                If foundRow.Length <> 0 Then
                    strPermission = foundRow(0)(0)
                Else
                    strPermission = ""
                End If
            End If
        End If
    End Sub

    Function get_permissions(UserID As Integer, ObjectID As String, ByRef strPermission As String)
        'returns "U" or "A"  or "D" or combination "UAD" or "V" / U - Update, A - Add, D - Delete, V - View Only
        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_permissions"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("UserID", UserID)
                'sqlComm.Parameters.AddWithValue("GroupID", GroupID)
                sqlComm.Parameters.AddWithValue("ObjectID", ObjectID)

                'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

                Try
                    strPermission = sqlComm.ExecuteScalar
                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using


        'End If
        Return returnKo
    End Function

    Function get_permissions_all(UserID As Integer, Optional ObjectID As String = "<NOCRITERIA>", Optional ByRef UserDTable As DataTable = Nothing) As String
        'this function fills with data the datatable DTablePermission for later checking of buttons permission (function get_permissions_dtable)
        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_permissions_all"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("UserID", UserID)
                'sqlComm.Parameters.AddWithValue("GroupID", GroupID)
                sqlComm.Parameters.AddWithValue("ObjectID", ObjectID)

                'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

                da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try
                    If UserDTable Is Nothing Then
                        Me.DTablePermission.Reset()
                        da.Fill(DTablePermission)
                        AssignCrewListPerm(DTablePermission)
                    Else
                        UserDTable.Reset()
                        da.Fill(UserDTable)
                        AssignCrewListPerm(UserDTable)
                    End If
                    'sqlComm.ExecuteNonQuery()
                    returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using


        'End If
        Return returnKo
    End Function

    Private Sub AssignCrewListPerm(dtTable As DataTable)
        Dim thisSqlConn As New SqlClient.SqlConnection
        Dim crewObj As New DataTable
        Try
            Using thisSqlConn
                thisSqlConn.ConnectionString = propSQLConnStr
                thisSqlConn.Open()

                If thisSqlConn.State <> ConnectionState.Open Then
                    MsgBox("Not connected to database.")
                Else
                    Dim sqlComm As New SqlCommand()
                    Dim da As New SqlDataAdapter

                    sqlComm.Connection = sqlConn
                    sqlComm.CommandText = "SELECT TOP 1 * FROM MPS.dbo.tblObjects " &
                                            "WHERE ObjectID = 'Crew' " &
                                            "AND ObjectList = 'CrewList_ActivityList'"
                    da.SelectCommand = sqlComm
                    crewObj.Reset()
                    da.Fill(crewObj)
                End If

                thisSqlConn.Close()
            End Using

            If dtTable.Select("ObjectID='Crew'").Count = 0 And
                dtTable.Rows.Count > 0 And
                crewObj.Rows.Count > 0 Then

                Dim dr As DataRow = dtTable.NewRow
                dr("PermString") = "V"
                dr("ObjectID") = "Crew"
                dr("UserID") = dtTable(0)("UserID")
                dr("FID") = crewObj(0)("FID") '"7sIJ6U9ycbDRQTmM1toqZA==" 'Crew
                dtTable.Rows.Add(dr)
            End If
        Catch ex As Exception
            Dim err As String = "AssignCrewListPerm(DataTable) Error :" & vbNewLine &
                               "Cannot assign permission for Crew List" & vbNewLine &
                               ex.Message
            LogErrors(err)
            MsgBox(err)
        End Try
    End Sub

    Function get_all_users(ByRef dt As DataTable) As String
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_all_user"
                sqlComm.CommandType = CommandType.StoredProcedure
                da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try

                    da.Fill(dt)

                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If

            sqlConn.Close()
        End Using
        Return returnKo

    End Function

    Function get_all_groups(ByRef dt As DataTable) As String
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_all_groups"
                sqlComm.CommandType = CommandType.StoredProcedure
                da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try

                    da.Fill(dt)

                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If
        End Using
        Return returnKo

    End Function

    Function get_group_users(GroupID As Integer, ByRef dt As DataTable) As String
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_group_users"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("GroupID", GroupID)

                da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try

                    da.Fill(dt)

                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If
            sqlConn.Close()
        End Using
        Return returnKo

    End Function

    Function get_group_objects(GroupID As Integer, ByRef dt As DataTable, Optional sCategory As String = "<NOCRITERIA>") As String
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_group_objects"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("GroupID", GroupID)
                sqlComm.Parameters.AddWithValue("Category", sCategory)

                da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try

                    da.Fill(dt)

                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If
            sqlConn.Close()
        End Using
        Return returnKo

    End Function

    Function get_group_reports(GroupID As Integer, ByRef dt As DataTable, Optional ReportGroup As String = "<NOCRITERIA>") As String
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_group_reports"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("groupID", GroupID)
                sqlComm.Parameters.AddWithValue("reportgroup", ReportGroup)

                da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try

                    da.Fill(dt)

                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If
            sqlConn.Close()
        End Using
        Return returnKo

    End Function

    Function get_reports(UserID As Integer, ByRef dt As DataTable, Optional ReportGroup As String = "<NOCRITERIA>",
                         Optional checkifAdmin As Integer = 1) As String

        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string
        'chekifadmin = pass 0 to disable checking of user if admin. if user is admin,.all reports will be return
        '   

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_get_reports"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.Parameters.AddWithValue("UserID", UserID)
                sqlComm.Parameters.AddWithValue("reportgroup", ReportGroup)
                sqlComm.Parameters.AddWithValue("CheckIfAdmin", checkifAdmin)

                da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try

                    da.Fill(dt)

                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If
            sqlConn.Close()
        End Using
        Return returnKo

    End Function

    Function get_any_fr_db(qry As String, ByRef dt As DataTable) As String
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                'Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                'sqlComm.Connection = sqlConn


                'sqlComm.CommandText = "sec_get_all_groups"
                'sqlComm.CommandType = CommandType.StoredProcedure

                da = New SqlDataAdapter(qry, sqlConn)

                Try

                    da.Fill(dt)
                    sqlConn.Close()
                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If

            sqlConn.Close()
        End Using
        Return returnKo

    End Function

    'affRows = affected rows of update
    Function update_MSysSecUserDetail(UserID As Integer, AES_String As String, Optional ByRef affRows As Long = 0) As String

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_update_MSysSecUserDetail"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("UserID", UserID)
                sqlComm.Parameters.AddWithValue("AES_String", AES_String)
                sqlComm.Parameters.Add("affRows", SqlDbType.BigInt)
                sqlComm.Parameters("affRows").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    affRows = sqlComm.Parameters("affRows").Value
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function

    Function add_MSysSecUserDetail(UserID As Integer, AES_String As String) As String

        Dim returnKo As String = ""

        Using sqlConn
            'dbconn.closeconn()
            If sqlConn.State <> ConnectionState.Open Then
                sqlConn.ConnectionString = propSQLConnStr
                sqlConn.Open()
            End If

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing/cannot connect"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_add_MSysSecUserDetail"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("UserID", UserID)
                sqlComm.Parameters.AddWithValue("AES_String", AES_String)
                'sqlComm.Parameters("returnKo").Direction = ParameterDirection.Output

                'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

                Try
                    sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using

        Return returnKo

    End Function

    Function closeConn() As Boolean
        Dim ret As Boolean = True
        If sqlConn.State = ConnectionState.Open Then
            Try
                sqlConn.Close()
                ret = True
            Catch ex As Exception
                ret = False
            End Try
        End If
        Return ret
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function hasNoViewPermission(objID As String, UserID As String,
                                        Optional search_DTable As Boolean = False,
                                Optional ByRef UserDTable As DataTable = Nothing, Optional chkifadmin As Boolean = True) As Integer
        'return 1 if no permission, 0 if do have permission
        Dim ret As Integer = 1
        Dim Permi As String = ""

        Dim isUserAdminRet As Integer = 0
        If chkifadmin Then
            isUserAdmin(UserID, isUserAdminRet)
        End If

        If isUserAdminRet.Equals(0) Then
            If search_DTable Then
                If UserDTable Is Nothing Then
                    Call get_permissions_dtable(UserID, objID, Permi)
                Else
                    Call get_permissions_dtable(UserID, objID, Permi, UserDTable)
                End If
            Else
                Call get_permissions(UserID, objID, Permi)
            End If


            If Len(Trim(Permi)) > 0 Then
                ret = 0
            End If
        Else
            ret = 0
        End If

        Return ret

    End Function

    Public Function hasViewOnlyPermission(objID As String, UserID As String,
                                          Optional search_DTable As Boolean = False,
                                Optional ByRef UserDTable As DataTable = Nothing, Optional chkifadmin As Boolean = True) As Integer
        'return 1 if no permission, 0 if do have permission
        Dim ret As Integer = 1
        Dim Permi As String = ""

        Dim isUserAdminRet As Integer = 0
        If chkifadmin Then
            isUserAdmin(UserID, isUserAdminRet)
        End If

        If isUserAdminRet.Equals(0) Then
            If search_DTable Then
                If UserDTable Is Nothing Then
                    Call get_permissions_dtable(UserID, objID, Permi)
                Else
                    Call get_permissions_dtable(UserID, objID, Permi, UserDTable)
                End If
            Else
                Call get_permissions(UserID, objID, Permi)
            End If

            If Trim(Permi) = "V" Then
                ret = 0
            End If
        Else
            ret = 0
        End If

        Return ret

    End Function

    Public Function hasNoAddPermission(objID As String, UserID As String,
                                        Optional search_DTable As Boolean = False,
                                Optional ByRef UserDTable As DataTable = Nothing, Optional chkifadmin As Boolean = True) As Integer
        'return 1 if no permission, 0 if do have permission
        Dim ret As Integer = 1
        Dim Permi As String = ""

        Dim isUserAdminRet As Integer = 0
        If chkifadmin Then
            isUserAdmin(UserID, isUserAdminRet)
        End If

        If isUserAdminRet.Equals(0) Then
            If search_DTable Then
                If UserDTable Is Nothing Then
                    Call get_permissions_dtable(UserID, objID, Permi)
                Else
                    Call get_permissions_dtable(UserID, objID, Permi, UserDTable)
                End If
            Else
                Call get_permissions(UserID, objID, Permi)
            End If

            If InStr(Trim(Permi), "A") Then
                ret = 0
            End If
        Else
            ret = 0
        End If
        Return ret

    End Function

    Public Function hasNoUpdatePermission(objID As String, UserID As String,
                                           Optional search_DTable As Boolean = False,
                                Optional ByRef UserDTable As DataTable = Nothing, Optional chkifadmin As Boolean = True) As Integer
        'return 1 if no permission, 0 if do have permission
        Dim ret As Integer = 1
        Dim Permi As String = ""

        Dim isUserAdminRet As Integer = 0
        If chkifadmin Then
            isUserAdmin(UserID, isUserAdminRet)
        End If

        If isUserAdminRet.Equals(0) Then
            If search_DTable Then
                If UserDTable Is Nothing Then
                    Call get_permissions_dtable(UserID, objID, Permi)
                Else
                    Call get_permissions_dtable(UserID, objID, Permi, UserDTable)
                End If
            Else
                Call get_permissions(UserID, objID, Permi)
            End If

            If InStr(Trim(Permi), "U") Then
                ret = 0
            End If

        Else
            ret = 0
        End If
        Return ret

    End Function

    Public Function hasNoDeletePermission(objID As String, UserID As String,
                                           Optional search_DTable As Boolean = False,
                                Optional ByRef UserDTable As DataTable = Nothing, Optional chkifadmin As Boolean = True) As Integer
        'return 1 if no permission, 0 if do have permission
        Dim ret As Integer = 1
        Dim Permi As String = ""

        Dim isUserAdminRet As Integer = 0
        If chkifadmin Then
            isUserAdmin(UserID, isUserAdminRet)
        End If

        If isUserAdminRet.Equals(0) Then
            If search_DTable Then
                If UserDTable Is Nothing Then
                    Call get_permissions_dtable(UserID, objID, Permi)
                Else
                    Call get_permissions_dtable(UserID, objID, Permi, UserDTable)
                End If
            Else
                Call get_permissions(UserID, objID, Permi)
            End If

            If InStr(Trim(Permi), "D") Then
                ret = 0
            End If

        Else
            ret = 0
        End If


        Return ret

    End Function

    Public Function hasNoDataToolPermission(objID As String, UserID As String,
                                             Optional search_DTable As Boolean = False,
                                Optional ByRef UserDTable As DataTable = Nothing, Optional chkifadmin As Boolean = True) As Integer
        'return 1 if no permission, 0 if do have permission
        Dim ret As Integer = 1
        Dim Permi As String = ""

        Dim isUserAdminRet As Integer = 0
        If chkifadmin Then
            isUserAdmin(UserID, isUserAdminRet)
        End If

        If isUserAdminRet.Equals(0) Then
            If search_DTable Then
                If UserDTable Is Nothing Then
                    Call get_permissions_dtable(UserID, objID, Permi)
                Else
                    Call get_permissions_dtable(UserID, objID, Permi, UserDTable)
                End If
            Else
                Call get_permissions(UserID, objID, Permi)
            End If

            If InStr(Trim(Permi), "T") Then
                ret = 0
            End If

        Else
            ret = 0
        End If
        Return ret

    End Function

    Public Function isUserAdmin(UserID As Integer, ByRef getRet As Integer) As String
        'getRet = 1 if admin, otherwise 0
        'if user in [MSysSec_Users] have value of 1 in AdminUser field then getRet = 1

        Dim returnKo As String = ""

        '//// neil test Spectral user
        If UserID = "99999" Then 'this is hardcoded in frmLogin Load event
            getRet = 1
            isUserAdmin = returnKo
            Exit Function
        End If
        '//// neil test end

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "sec_isadmin_user"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("UserID", UserID)
                'sqlComm.Parameters.AddWithValue("GroupID", GroupID)

                'returnKo = sqlComm.Parameters("returnKo").Value.ToString()

                sqlComm.Parameters.Add("isadmin", SqlDbType.Int)
                sqlComm.Parameters("isadmin").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    'getRet = IfNull(sqlComm.Parameters("isadmin").Value, 0)
                    getRet = sqlComm.Parameters("isadmin").Value
                    'returnKo = ""
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        returnKo = returnKo & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try
                'Try
                '    sqlComm.ExecuteNonQuery()
                '    'returnKo = ""
                'Catch ex As Exception
                '    returnKo = Err.Description
                'End Try

            End If

            sqlConn.Close()
        End Using


        'End If
        Return returnKo

    End Function

    '<!-- Added by tony20170926
    Public Function CheckBtnVisibleSpecialPermission(objID As String, UserID As String, ByRef Permit As Integer,
                                        Optional search_DTable As Boolean = False,
                                Optional ByRef UserDTable As DataTable = Nothing) As Boolean

        Dim hasSpecialPerm As Boolean = False

        Select Case objID
            Case "DeleteCrew"
                hasSpecialPerm = True
                Permit = hasNoDeletePermission("DeleteCrew", USER_ID, True, userPermDt)

            Case "About"
                hasSpecialPerm = True
                Permit = 0
        End Select

        Return hasSpecialPerm
    End Function
    '-->



End Class
