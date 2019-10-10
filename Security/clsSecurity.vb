Imports System.Data.SqlClient

Public Class clsSecurity

    'Dim clsSQLDB As SQLDB
    Private sqlConn As New SqlClient.SqlConnection
    Private sqlConnStr As String

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
                        Optional SecAnswer As String = "<NO_CHANGES>", Optional LastUpdatedBy As String = "<NO_CHANGES>") As String

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
                sqlComm.Parameters.Add("GenId", SqlDbType.BigInt)
                sqlComm.Parameters("GenId").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    GenID = sqlComm.Parameters("GenID").Value
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
                              Optional CanDelete As Long = 0, Optional ViewOnly As Long = 0, _
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
                        Optional ByRef affRows As Long = 0)

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
                sqlComm.Parameters.Add("affRows", SqlDbType.BigInt)
                sqlComm.Parameters("affRows").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    affRows = sqlComm.Parameters("returnKo").Value
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
                    affRows = sqlComm.Parameters("returnKo").Value
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

    Function del_group(GroupID As Integer, Optional LastUpdatedBy As String = "<NO_CHANGES>")

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

            sqlConn.Close()
        End Using

        'End If
        Return returnKo
    End Function

    Function get_permissions(UserID As Integer, GroupID As Integer, ObjectID As String, ByRef strPermission As String)

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
                sqlComm.Parameters.AddWithValue("GroupID", GroupID)
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
                    affRows = sqlComm.Parameters("returnKo").Value
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
        Dim ret As Boolean
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
End Class
