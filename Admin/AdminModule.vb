Module AdminModule

    Private sqlConn As New SqlClient.SqlConnection(MPSDB.GetConnectionString())
    Private sqlCmd As SqlClient.SqlCommand

    Public Function UpdateRelatedAdminName(PKeyValue As String, TableName As String, MainUpdQuery As String) As Boolean
        Dim retval As Boolean = False
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim AllowUpdate As Boolean = False, isMainUpdated As Boolean = False
        Try
            sqlConn.Open()
            sqlTrans = sqlConn.BeginTransaction()
            'update Admin Table
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = sqlConn
                cmd.CommandText = MainUpdQuery
                cmd.Transaction = sqlTrans
                isMainUpdated = (cmd.ExecuteNonQuery().Equals(1))
            End Using

            If isMainUpdated Then
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTrans
                    cmd.CommandText = "EXEC dbo.SP_UpdateActivity '" & TableName & "', '" & PKeyValue & "'"
                    AllowUpdate = (cmd.ExecuteNonQuery() >= 0)
                End Using
                If AllowUpdate Then
                    sqlTrans.Commit()
                    retval = True
                Else
                    retval = False
                End If
            End If
        Catch ex As Exception
            sqlTrans.Rollback()
            retval = False
        Finally
            sqlConn.Close()
        End Try
        Return retval
    End Function

    Public Function isWageScaleInUse(cWageScaleCode As String, ByRef getRet As Integer) As String

        Dim returnKo As String = ""

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString()

            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlClient.SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "isWageScaleInUse"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("wagescalecode", cWageScaleCode)


                sqlComm.Parameters.Add("inUse", SqlDbType.Int)
                sqlComm.Parameters("inUse").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    getRet = sqlComm.Parameters("inUse").Value
                    'returnKo = ""
                Catch SqlEx As SqlClient.SqlException
                    Dim myError As SqlClient.SqlError
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
End Module
