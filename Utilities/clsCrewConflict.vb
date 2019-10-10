Imports System.Data.SqlClient

Public Class clsCrewConflict
    Private sqlConn As New SqlClient.SqlConnection
    Private sqlConnStr As String
    'Private DTablePermission As New DataTable

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

    'affRows = affected rows of update
    Function CrewConflict_add(FKeyIDNbr As String, Reason As String, FKeyIDNbrConflict As String, CConflictName As String, CurrentCrewName As String, Optional isResolved As Integer = 0, _
                          Optional LastUpdatedBy As String = "<NO_CHANGES>", Optional ByRef affRows As Long = 0, Optional SQLConnStr As String = "", _
                          Optional closeConn As Boolean = True) As String

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn

            If SQLConnStr <> "" Then
                sqlConn.ConnectionString = SQLConnStr
            Else
                sqlConn.ConnectionString = propSQLConnStr
            End If

            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "CrewConflict_add"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("FKeyIDNbr", FKeyIDNbr)
                sqlComm.Parameters.AddWithValue("Reason", Reason)
                sqlComm.Parameters.AddWithValue("FKeyIDNbrConflict", FKeyIDNbrConflict)
                sqlComm.Parameters.AddWithValue("CConflictName", CConflictName)
                sqlComm.Parameters.AddWithValue("CurrentCrewName", CurrentCrewName)
                sqlComm.Parameters.AddWithValue("isResolved", isResolved)
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

            End If

            If closeConn Then
                sqlConn.Close()
            End If

        End Using

        'End If
        Return returnKo
    End Function

    'affRows = affected rows of update
    Function CrewConflict_edit(bindKey As String, Reason As String, isResolved As Integer, _
                          Optional LastUpdatedBy As String = "<NO_CHANGES>", Optional ByRef affRows As Long = 0, Optional SQLConnStr As String = "", _
                          Optional closeConn As Boolean = True) As String

        Dim returnKo As String = ""

        'Using dbconn.myConn
        'dbconn.closeconn()
        'If dbconn.startConn Then

        Using sqlConn

            If SQLConnStr <> "" Then
                sqlConn.ConnectionString = SQLConnStr
            Else
                sqlConn.ConnectionString = propSQLConnStr
            End If

            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "CrewConflict_edit"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("bindKey", bindKey)
                sqlComm.Parameters.AddWithValue("Reason", Reason)
                sqlComm.Parameters.AddWithValue("isResolved", isResolved)
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

            End If

            If closeConn Then
                sqlConn.Close()
            End If

        End Using

        'End If
        Return returnKo
    End Function

    Function CrewConflict_getConflict(ByRef dt As DataTable, Optional idnbr As String = "", Optional SQLConnStr As String = "", _
                          Optional closeConn As Boolean = True) As String
        'result data will be put to variable dt..
        'result of the function is blank sring "" if no error, or error string

        Dim returnKo As String = ""
        Dim sqlstr As String

        Using sqlConn
            If SQLConnStr <> "" Then
                sqlConn.ConnectionString = SQLConnStr
            Else
                sqlConn.ConnectionString = propSQLConnStr
            End If

            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                returnKo = "sql connection is nothing"
            Else
                Dim sqlComm As New SqlCommand()
                Dim da As New SqlDataAdapter
                'Dim dt As New DataTable


                sqlComm.Connection = sqlConn

                sqlstr = "select * from dbo.tblCrewConflict "
                If idnbr <> "" Then
                    sqlstr = sqlstr & "where FKeyIDNbr in ('" & idnbr & "')"
                End If

                sqlComm.CommandText = sqlstr
                sqlComm.CommandType = CommandType.Text
                'sqlComm.Parameters.AddWithValue("GroupID", GroupID)

                Dim dr As SqlDataReader

                'da.SelectCommand = sqlComm
                'da = New SqlDataAdapter(sqlComm)

                Try
                    dr = sqlComm.ExecuteReader()
                    dt.Load(dr)
                    'da.Fill(dt)

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

    Function CrewConflict_GetCrewWithConflict(sIDNbr As String, dtCrewList As DataTable, colNameWithIDNbr As String, Optional SQLConnStr As String = "", _
                          Optional closeConn As Boolean = True, Optional ByRef errmsg As String = "") As DataTable
        Dim dt As New DataTable, sErr As String

        Dim dtConflictCrew As New DataTable

        Try

            sErr = CrewConflict_getConflict(dtConflictCrew, sIDNbr, IIf(SQLConnStr <> "", SQLConnStr, propSQLConnStr), closeConn)

            If sErr = "" Then
                If dtConflictCrew.Rows.Count > 0 Then
                    For i As Integer = 0 To dtConflictCrew.Rows.Count - 1
                        If dtCrewList.Select(colNameWithIDNbr & " = '" & dtConflictCrew.Rows(i)("FKeyIDNbrConflict") & "'").Count = 0 Then
                            dtConflictCrew.Rows(i).Delete() 'delete row not in the check crew list
                        End If
                    Next

                    dtConflictCrew.AcceptChanges()
                    dt = dtConflictCrew
                Else

                End If
            Else
                errmsg = sErr
            End If

        Catch ex As Exception
            errmsg = ex.Message
        End Try

        Return dt
    End Function

    Function CrewConflict_GetCrewWithConflict(sIDNbr As String, dtCrewList As DataTable, colNameWithIDNbr As String,
                        colNameDStart As String, colNameDEnd As String,
                         dtStart As Date, dtEnd As Date, Optional SQLConnStr As String = "",
                        Optional closeConn As Boolean = True, Optional ByRef errmsg As String = "") As DataTable
        Dim dt As New DataTable, sErr As String

        Dim dtConflictCrew As New DataTable

        Try

            sErr = CrewConflict_getConflict(dtConflictCrew, sIDNbr, IIf(SQLConnStr <> "", SQLConnStr, propSQLConnStr), closeConn)

            If sErr = "" Then
                If dtConflictCrew.Rows.Count > 0 Then

                    Dim xpresion As String
                       
                    For i As Integer = 0 To dtConflictCrew.Rows.Count - 1
                        xpresion = colNameWithIDNbr & " = '" & dtConflictCrew.Rows(i)("FKeyIDNbrConflict") & "' and " & _
                                    "not ( ([" & colNameDStart & "] < #" & dtStart & "# and [" & colNameDEnd & "] < #" & dtStart & "#) or ([" & colNameDStart & "] > #" & dtEnd & "# and [" & colNameDEnd & "] > #" & dtEnd & "#) )"

                        'MsgBox(xpresion)

                        If dtCrewList.Select(xpresion).Count = 0 Then
                            'isOverlap(dtCrewList.Rows(i)(colNameDStart),
                            '             dtCrewList.Rows(i)(colNameDEnd), dtStart, dtEnd)).Count = 0 Then
                            'Else
                            dtConflictCrew.Rows(i).Delete() 'delete row not in the check crew list
                        End If
                    Next

                    dtConflictCrew.AcceptChanges()
                    dt = dtConflictCrew
                Else

                End If
            Else
                errmsg = sErr
            End If

        Catch ex As Exception
            errmsg = ex.Message
        End Try

        Return dt
    End Function

    Function isOverlap(dBStart As Date, dBEnd As Date, dLStart As Date, dLEnd As Date) As Boolean
        Dim bRet As Boolean = False

        If dLStart >= dBStart And dLStart <= dBEnd Then
            ' bRet = True
            Return True
        End If

        If dBStart >= dLStart And dBStart <= dLEnd Then
            ' bRet = True
            Return True
        End If

        Return bRet
    End Function


    Public Function closeConn() As Boolean
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
        Call closeConn()
        MyBase.Finalize()
    End Sub
End Class
