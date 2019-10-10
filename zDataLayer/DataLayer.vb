Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data
Imports System
'Imports MySql.Data.MySqlClient
Imports System.Collections.Generic
Imports zUtil

'enum for connection type
Public Enum ConnTypeEnum
    SqlConnection
    OleDbConnection
    OdbcConnection
    MySQLConnection
End Enum

'for external modules use
Public Structure connDetails
    Public Type As ConnTypeEnum
    Public Server As String
    Public DBName As String
    Public User As String
    Public Pwd As String
    Public Port As Integer
    Public ConnStr As String
    Public OtherOptions As String
    Public Driver As String
End Structure

Public Class DataLayer
    Public oConnDetails As connDetails
    Private bBeenInit As Boolean = False
    Private oOpenConnection As Object


#Region "Database Objects"
    'connection form of application database(AccessDB) settings
    'RETURNS : 0 - Failed
    '          1 - Success
    '          2 - Cancelled
    Public Function ShowConnectForm() As Integer
        Dim frmConnectBRS As New frmConnectBRS(oConnDetails)
        frmConnectBRS.ShowDialog()
        oConnDetails = frmConnectBRS.oConn
        Return frmConnectBRS.nResult
    End Function

    'connection form of sql server database(Server settings)
    'RETURNS : 0 - Failed
    '          1 - Success
    '          2 - Cancelled
    Public Function ShowServerConnectionForm(ByRef oConDetails As connDetails) As Integer
        Dim frmConnect As New frmConnect(oConnDetails)
        frmConnect.ShowDialog()
        oConnDetails = frmConnect.oConn
        oConDetails = oConnDetails
        Return frmConnect.nResult
    End Function

    Public Function AssembleConnString() As String
        Dim cConnStr As String = ""
        Select Case oConnDetails.Type
            Case ConnTypeEnum.OdbcConnection
                cConnStr = MySQL_ODBC_Assemble_ConnStr(oConnDetails.Server, oConnDetails.DBName, oConnDetails.User, oConnDetails.Pwd, oConnDetails.Port, oConnDetails.OtherOptions, oConnDetails.Driver)
            Case ConnTypeEnum.OleDbConnection
                cConnStr = OleDB_Assemble_ConnStr(oConnDetails.Server, oConnDetails.DBName)
            Case ConnTypeEnum.SqlConnection
                cConnStr = SQLClient_Assemble_ConnStr(oConnDetails.Server, oConnDetails.User, oConnDetails.Pwd, oConnDetails.OtherOptions, oConnDetails.DBName)
            Case ConnTypeEnum.MySQLConnection
        End Select
        Return cConnStr
    End Function

    'returns the connection object
    Private Function ConnObject() As Object
        Dim cObject As Object

        cObject = Nothing

        Select Case oConnDetails.Type
            Case ConnTypeEnum.OdbcConnection
                cObject = New OdbcConnection
            Case ConnTypeEnum.OleDbConnection
                cObject = New OleDbConnection
            Case ConnTypeEnum.SqlConnection
                cObject = New SqlConnection
            Case ConnTypeEnum.MySQLConnection
                'cObject = New MySqlConnection
        End Select

        Return cObject

    End Function

    'returns the adapter object
    Private Function AdapterObject() As Object
        Dim cObject As Object

        cObject = Nothing

        Select Case oConnDetails.Type
            Case ConnTypeEnum.OdbcConnection
                cObject = New OdbcDataAdapter
            Case ConnTypeEnum.OleDbConnection
                cObject = New OleDbDataAdapter
            Case ConnTypeEnum.SqlConnection
                cObject = New SqlDataAdapter
            Case ConnTypeEnum.MySQLConnection
                'cObject = New MySqlDataAdapter
        End Select

        Return cObject

    End Function


    Public Function ParamObject(Optional ByVal nArraySize As Integer = 1) As Object()
        Dim oObject(nArraySize) As Object
        Dim nCtr As Integer = 0

        For nCtr = 0 To nArraySize
            Select Case oConnDetails.Type
                Case ConnTypeEnum.OdbcConnection
                    oObject(nCtr) = New OdbcParameter

                Case ConnTypeEnum.OleDbConnection
                    oObject(nCtr) = New OleDbParameter

                Case ConnTypeEnum.SqlConnection
                    oObject(nCtr) = New SqlParameter

                Case ConnTypeEnum.MySQLConnection
                    'oObject(nCtr) = New MySqlParameter
            End Select
        Next

        Return oObject

    End Function

    'returns the command object
    Private Function CommandObject() As Object
        Dim cObject As Object

        cObject = Nothing

        Select Case oConnDetails.Type
            Case ConnTypeEnum.OdbcConnection
                cObject = New OdbcCommand
            Case ConnTypeEnum.OleDbConnection
                cObject = New OleDbCommand
            Case ConnTypeEnum.SqlConnection
                cObject = New SqlCommand
            Case ConnTypeEnum.MySQLConnection
                'cObject = New MySqlCommand
        End Select

        Return cObject

    End Function

#End Region

#Region "Initialization"

    Public Sub Init(ByRef pConnODBC As connDetails)
        'get all details
        oConnDetails = pConnODBC
        'reassemble connection string and return
        oConnDetails.ConnStr = AssembleConnString()
        pConnODBC = oConnDetails
        bBeenInit = True
    End Sub


    Public Function GetConnDetailObject() As connDetails
        Return oConnDetails
    End Function

#End Region

    'opens the connection 
    Public Function TestConn(Optional ByRef cErr As String = "") As Boolean
        Dim Connection As Object
        Dim bRetVal As Boolean = False

        If bBeenInit Then
            Try
                Connection = ConnObject()
                If NullToString(oConnDetails.ConnStr).Length > 0 Then
                    Connection.ConnectionString = oConnDetails.ConnStr
                End If
                Connection.Open()
                Connection.Dispose()
                Connection.Close()
                bRetVal = True

            Catch ex As Exception
                cErr = ex.Message & ". CONNSTR: [" & oConnDetails.ConnStr & "]"
            End Try
        End If

        Return bRetVal
    End Function

    Public Function CloseConn(ByRef oConn As Object) As Boolean
        Dim bRetVal As Boolean = False

        If bBeenInit Then
            Try
                oConn.close()
                bRetVal = True
            Catch ex As Exception
            End Try
        Else
        End If

        Return bRetVal
    End Function

    're-opens a lost connection. Default = 5 retries before giving up
    Public Function ReOpenConn(Optional ByRef cErr As String = "", Optional ByVal nRetry As Integer = 3) As Boolean
        Dim Connection As Object
        Dim bRetVal As Boolean = False
        Dim nCtr As Integer

        If bBeenInit Then
            For nCtr = 1 To nRetry
                Connection = OpenConn(cErr)
                If Not IsNothing(Connection) Then
                    bRetVal = True
                    Exit For
                End If
            Next
        Else
            cErr = "ReOpenConn() : DataLayer has not been initialized"
        End If

        Return bRetVal

    End Function

    'opens the connection 
    Public Function OpenConn(Optional ByRef cErr As String = "") As Object
        Dim Connection As Object

        If bBeenInit Then
            Try
                Connection = ConnObject()
                Connection.ConnectionString = oConnDetails.ConnStr
                Connection.open()
                Return Connection
            Catch ex As Exception
                cErr = ex.Message
                Return Nothing
            End Try

        Else
            cErr = "OpenConn() : DataLayer has not been initialized"
            Return Nothing
        End If

    End Function

    'returns a dataset with the sql
    Public Function ExecuteDataTable(ByVal cSQL As String, Optional ByRef cErr As String = "") As DataTable
        Dim ds As DataSet = Nothing
        Dim dt As DataTable = Nothing

        If bBeenInit Then
            Try
                ds = ExecuteDataSet(cSQL)
                dt = ds.Tables(0)
                Return dt

            Catch ex As Exception
                cErr = ex.Message
                Return Nothing
            End Try
        Else
            cErr = "ExecuteDataTable() : DataLayer has not been initialized"
            Return Nothing
        End If

    End Function

    'returns a dataset with the sql
    Public Function ExecuteDataSet(ByVal cSQL As String, Optional ByRef cErr As String = "") As DataSet
        Dim ds As New DataSet
        Dim adapt As Object
        Dim command As Object
        Dim da As Object
        Dim Restore As Boolean = False

        If bBeenInit Then
            Try
                da = AdapterObject()

                command = CommandObject()
                command.CommandText = cSQL
                command.CommandType = CommandType.Text
                command.Connection = OpenConn()

                adapt = AdapterObject()
                adapt.SelectCommand = command

                adapt.Fill(ds)

                command.connection.close()
                command = Nothing
                adapt = Nothing

                Return ds

            Catch ex As Exception
                cErr = ex.Message
                Return Nothing
            End Try

        Else
            cErr = "ExecuteDataSet() : DataLayer has not been initialized"
            Return Nothing
        End If

    End Function

    'get permission
    Public Function Get_Permissions(ByVal Schema As String, UserID As Integer, ObjectID As String, Optional ByRef cErr As String = "") As String
        'returns "U" or "A"  or "D" or combination "UAD" or "V" / U - Update, A - Add, D - Delete, V - View Only
        Dim returnKo As String = ""

        Dim command As Object

        If bBeenInit Then
            command = CommandObject()
            Try


                command.CommandText = Schema & ".dbo.sec_get_permissions"
                command.CommandType = CommandType.StoredProcedure
                command.Connection = OpenConn(cErr)

                If cErr = "" Then
                    command.Parameters.AddWithValue("UserID", UserID)
                    command.Parameters.AddWithValue("ObjectID", ObjectID)

                    returnKo = command.ExecuteScalar()
                    command.Connection.close()
                    command = Nothing
                Else

                End If

            Catch ex As Exception
                cErr = "sec_get_permissions" & "ErrMsg: " & ex.Message
                command.Connection.close()
                returnKo = ""
            End Try
        End If

        Return returnKo
    End Function

    Public Function isUserAdmin(ByVal Schema As String, UserID As Integer, Optional ByRef cErr As String = "") As Boolean
        Dim ret As Boolean = False

        ret = IIf(DLookUp("AdminUser", Schema & ".dbo.MSysSec_Users", "ID=" & UserID.ToString & "") = 1, True, False)

        Return ret

    End Function

    'returns a dataset with the sql
    Public Function ExecuteDataSet(ByVal cSQL As String, ByRef da As Object, ByRef ds As DataSet, Optional ByRef cErr As String = "") As Boolean
        Dim adapt As Object
        Dim command As Object
        Dim Restore As Boolean = False

        If bBeenInit Then
            Try
                da = AdapterObject()

                command = CommandObject()
                command.CommandText = cSQL
                command.CommandType = CommandType.Text
                command.Connection = OpenConn()

                adapt = AdapterObject()
                adapt.SelectCommand = command

                adapt.Fill(ds)

                command.connection.close()
                command = Nothing
                adapt = Nothing

                Return True

            Catch ex As Exception
                cErr = ex.Message
                Return False
            End Try

        Else
            cErr = "ExecuteDataSet() : DataLayer has not been initialized"
            Return False
        End If



    End Function


    Public Function DLookUpSQL(ByVal cSQL As String) As DataRow
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow

        Try

            ds = ExecuteDataSet(cSQL)
            dt = ds.Tables(0)

            If dt.Rows.Count = 0 Then
                Return Nothing
            End If

            dr = dt.Rows(0)
            Return dr

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function DLookUpSQL(ByVal cField As String, ByVal cSQL As String, Optional ByRef cErr As String = "") As String
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow

        Try

            ds = ExecuteDataSet(cSQL)
            dt = ds.Tables(0)

            If dt.Rows.Count = 0 Then
                Return Nothing
            End If

            dr = dt.Rows(0)
            Return NullToString(dr.Item(cField))

        Catch ex As Exception

            Return Nothing
        End Try
    End Function

    'finds the first item
    Public Function DLookUp(ByVal Field As String, ByVal Table As String, Optional ByVal Criteria As String = "", Optional ByVal cOrderBy As String = "", Optional ByVal bReturnString As Boolean = True) As Object
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim cSQL As String = ""
        Dim oRetVal

        Try
            cSQL = "select " & Field & " AS RetVal from " & Table

            If Criteria.Length > 0 Then
                cSQL = cSQL & " where " & Criteria
            End If

            If cOrderBy.Length > 0 Then
                cSQL = cSQL & " order by " & cOrderBy
            End If

            ds = ExecuteDataSet(cSQL)
            dt = ds.Tables(0)

            If dt.Rows.Count = 0 Then
                Return Nothing
            End If

            dr = dt.Rows(0)
            If bReturnString Then
                'return a string
                oRetVal = NullToString(dr.Item("RetVal"))
            Else
                'return an object
                oRetVal = dr.Item("RetVal")
            End If

            Return oRetVal
        Catch ex As Exception

            Return Nothing
        End Try

    End Function

    Public Function DCount(ByVal cSQL As String) As Long
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow

        Try

            ds = ExecuteDataSet(cSQL)
            dt = ds.Tables(0)

            If dt.Rows.Count = 0 Then
                Return 0
            End If

            dr = dt.Rows(0)
            Return dt.Rows.Count

        Catch ex As Exception

            Return Nothing
        End Try
    End Function

    'finds the last
    Public Function DLast(ByVal Field As String, ByVal Table As String, Optional ByVal Criteria As String = "") As String
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim cSQL As String

        Try
            cSQL = "select " & Field & " from " & Table

            If Criteria.Length > 0 Then
                cSQL = cSQL & " where " & Criteria
            End If

            ds = ExecuteDataSet(cSQL)
            dt = ds.Tables(0)
            dr = dt.Rows(dt.Rows.Count - 1)
            Return dr.Item(Field)
        Catch ex As Exception

            Return Nothing
        End Try

    End Function

    'finds the sum 
    Public Function DSum(ByVal Field As String, ByVal Table As String, Optional ByVal Criteria As String = "") As Double
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim cSQL As String

        Try
            cSQL = "select Sum(" & Field & ") as _Result from " & Table

            If Criteria.Length > 0 Then
                cSQL = cSQL & " where " & Criteria
            End If

            ds = ExecuteDataSet(cSQL)
            dt = ds.Tables(0)
            dr = dt.Rows(0)
            Return dr.Item("_Result")
        Catch ex As Exception

            Return Nothing
        End Try

    End Function

    'returns a dataset with the sql
    Public Function ExecuteNonQuery(ByVal cSQL As String, Optional ByRef cErr As String = "", Optional ByRef nAffectedRows As Integer = 0, Optional ByVal oParam() As Object = Nothing) As Boolean
        Dim command As Object
        Dim Restore As Boolean = False
        Dim bResult As Boolean = False
        Dim nCtr As Integer = 0

        If bBeenInit Then
            Try
                command = CommandObject()
                command.CommandText = cSQL
                command.CommandType = CommandType.Text
                command.Connection = OpenConn(cErr)
                command.commandtimeout = 0  'added by tony20181018

                If cErr = "" Then
                    If Not (oParam Is Nothing) Then
                        For nCtr = 0 To oParam.Count - 1
                            command.parameters.add(oParam(nCtr))
                        Next
                    End If
                    nAffectedRows = command.ExecuteNonQuery()
                    command.Connection.close()
                    command = Nothing
                    bResult = True
                Else
                    bResult = False
                End If

            Catch ex As Exception
                'MsgBox(cSQL & "ErrMsg: " & ex.Message)
                cErr = cSQL & "ErrMsg: " & ex.Message
            End Try
        End If
        Return bResult
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function MySQL_GetServerTime(Optional ByRef cErr As String = "") As DateTime
        Dim dRetVal As DateTime = Nothing
        Try
            dRetVal = DLookUpSQL("mysqltime", "SELECT now() mysqltime")
        Catch ex As Exception
            cErr = "DB Server Err. " & ex.Message
        End Try
        Return dRetVal
    End Function

    Public Function MSSql_GetServerTime(Optional ByRef cErr As String = "") As DateTime
        Dim dRetVal As DateTime = Nothing
        Try
            dRetVal = DLookUpSQL("mssqltime", "SELECT GETDATE() mssqltime")
        Catch ex As Exception
            cErr = "DB Server Err. " & ex.Message
        End Try
        Return dRetVal
    End Function

    'FUNCTION: Returns an SQL that can be used to performs server-side pagination with MySQL datasource
    '          The returned SQL will add ONE column (row_number) 
    '
    'WORKS WITH: OneX_Pager User Control
    '
    'PARAMETERS:
    ' <cSQL_Original> - your original SQl (e.g. SELECT * FROM tblOrders)
    ' <nTotalRows> - BY REFERENCE parameter that will RETURN the TOTAL NUMBER of records in the ORIGINAL seleect statement
    ' <nStartIndex> - Starting row_number for WHERE expression
    ' <nEndIndex> - Ending row_number for WHERE condition
    ' <cWhere> - Where statement that will replace the "1=1" placeholder
    '
    '                IMPORTANT REQUIREMENT: For <cWhere> to work, <cSQL_Original> MUST be have the "1=1" marker like this:
    '                                       e.g. SELECT * FROM tblOrders WHERE (1=1)
    '                                       "1=1" -> this will be replaced with the criteria in <dictCriteria>
    '
    Public Function MySQL_FetchPage_SQL(ByVal cSQL_Original As String, ByRef nTotalRows As Long, ByVal nStartIndex As Long, ByVal nRowsPerPage As Integer, ByVal cWhere As String, Optional ByVal bCountRows As Boolean = True) As String
        Dim cTmpSQL As String = ""

        'remove SQL command end delimiter
        cSQL_Original = IIf(Right(cSQL_Original, 1) = ";", Left(cSQL_Original, cSQL_Original.Length - 1), cSQL_Original)

        'remove SQL command end delimiter
        cTmpSQL = cSQL_Original

        'apply criteria for INNER select
        Try
            If InStr(cTmpSQL, "1=1") And cWhere.Length > 0 Then
                cTmpSQL = Regex.Replace(cTmpSQL, Regex.Escape("1=1"), cWhere, RegexOptions.IgnoreCase)
            End If
        Catch ex As Exception
        End Try

        If bCountRows Then
            'get total rows BEFORE applying the filter
            nTotalRows = DLookUpSQL("rowcount", "SELECT COUNT(*) rowcount FROM (" & cTmpSQL & ") dc")
        End If

        'apply range filter to OUTER select
        cTmpSQL = cTmpSQL & " LIMIT " & nStartIndex - 1 & ", " & nRowsPerPage

        Return cTmpSQL
    End Function


    'FUNCTION: Returns an SQL that can be used to performs server-side pagination with MySQL datasource
    '          The returned SQL will add ONE column (row_number) 
    '
    'WORKS WITH: OneX_Pager User Control
    '
    'PARAMETERS:
    ' <cSQL_Original> - your original SQl (e.g. SELECT * FROM tblOrders)
    ' <nTotalRows> - BY REFERENCE parameter that will RETURN the TOTAL NUMBER of records in the ORIGINAL seleect statement
    ' <nStartIndex> - Starting row_number for WHERE expression
    ' <nEndIndex> - Ending row_number for WHERE condition
    ' <cWhere> - Where statement that will replace the "1=1" placeholder
    '
    '                IMPORTANT REQUIREMENT: For <cWhere> to work, <cSQL_Original> MUST be have the "1=1" marker like this:
    '                                       e.g. SELECT * FROM tblOrders WHERE (1=1)
    '                                       "1=1" -> this will be replaced with the criteria in <dictCriteria>
    '
    Public Function MySQL_RowNumber_SQL(ByVal cSQL_Original As String, ByRef nTotalRows As Long, ByVal nStartIndex As Long, ByVal nEndIndex As Long, ByVal cWhere As String) As String
        Dim cTmpSQL As String = ""

        nTotalRows = 0

        'remove SQL command end delimiter
        cSQL_Original = IIf(Right(cSQL_Original, 1) = ";", Left(cSQL_Original, cSQL_Original.Length - 1), cSQL_Original)

        'remove SQL command end delimiter
        cTmpSQL = cSQL_Original
        'case insensitive replace
        cTmpSQL = Regex.Replace(cTmpSQL, Regex.Escape("select "), "SELECT @curRow := @curRow + 1 AS `row_number`,", RegexOptions.IgnoreCase)
        cTmpSQL = Regex.Replace(cTmpSQL, Regex.Escape("from "), "FROM (SELECT @curRow := 0) r2,", RegexOptions.IgnoreCase)

        'apply criteria for INNER select
        Try
            If InStr(cTmpSQL, "1=1") And cWhere.Length > 0 Then
                cTmpSQL = Regex.Replace(cTmpSQL, Regex.Escape("1=1"), cWhere, RegexOptions.IgnoreCase)
            End If
        Catch ex As Exception
        End Try

        'RSA: enclose in a select to force mysql to create a table from the result so we can set a criteria on the begin and end index
        cTmpSQL = "SELECT * FROM (" & cTmpSQL
        cTmpSQL = cTmpSQL & ") r3"

        'get total rows BEFORE applying the filter
        nTotalRows = DLookUpSQL("rowcount", "SELECT COUNT(*) rowcount FROM (" & cTmpSQL & ") dc")

        'apply range filter to OUTER select
        If nStartIndex <= nEndIndex Then
            If nStartIndex <> -1 And nEndIndex <> -1 Then
                cTmpSQL = cTmpSQL & " WHERE row_number BETWEEN " & nStartIndex & " AND " & nEndIndex
            End If
        Else
            cTmpSQL = "<nStartIndex> MUST be LESS THAN OR EQUAL TO <nEndIndex>"
        End If

        Return cTmpSQL
    End Function

    Public Function MySQL_ODBC_Assemble_ConnStr(ByVal cServer As String, ByVal cDatabase As String, ByVal cUserName As String, ByVal cPwd As String, Optional ByVal nPort As Integer = 3306, Optional ByVal cOtherOptions As String = "option=0", Optional ByVal cDriver As String = "{MySQL ODBC 3.51 Driver}") As String
        Dim cConnStr As String = ""
        Try
            cConnStr = "Driver=" & RemoveInject(cDriver) & ";database=" & RemoveInject(cDatabase) & ";port=" & RemoveInject(NullToZero(nPort)) & ";server=" & RemoveInject(cServer) & ";uid=" & RemoveInject(cUserName) & ";pwd=" & RemoveInject(cPwd) & ";" & RemoveInject(cOtherOptions)
        Catch ex As Exception
            TryCatch("MySQL_ODBC_Assemble_ConnStr", ex)
        End Try
        Return cConnStr
    End Function

    Public Function SQLClient_Assemble_ConnStr(ByVal cServer As String, ByVal cUserName As String, ByVal cPwd As String, Optional ByVal cOtherOptions As String = "option=0", Optional ByVal cDatabase As String = "") As String
        Dim cConnStr As String = ""
        Try
            If cOtherOptions = "STISQLSERVER" Then
                cServer = cServer.Replace("\STISQLSERVER", "")
                cConnStr = " Data Source=" & cServer & "\STISQLSERVER;" & IIf(cDatabase <> "", "Initial Catalog=" & RemoveInject(cDatabase) & ";", "") & "Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS"
            ElseIf cOtherOptions = "SQLSERVER_AUTH" Then
                cConnStr = " Data Source=" & cServer & ";" & IIf(cDatabase <> "", "Initial Catalog=" & RemoveInject(cDatabase) & ";", "") & "Persist Security Info=True;User ID=" & RemoveInject(cUserName) & ";Password=" & RemoveInject(cPwd)
            ElseIf cOtherOptions = "WIN_AUTH" Then
                cConnStr = " Data Source=" & cServer & ";" & IIf(cDatabase <> "", "Initial Catalog=" & RemoveInject(cDatabase) & ";", "") & "Integrated Security=SSPI"
            End If
        Catch ex As Exception
            TryCatch("SQLClient_Assemble_ConnStr", ex)
        End Try
        Return cConnStr
    End Function

    Public Function OleDB_Assemble_ConnStr(ByVal cServer As String, ByVal cDatabase As String) As String
        Dim cConnStr As String = ""
        Try
            cConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & CleanPath(RemoveInject(cServer)) & RemoveInject(cDatabase) & ";Persist Security Info=False"
        Catch ex As Exception
            TryCatch("OleDB_Assemble_ConnStr", ex)
        End Try
        Return cConnStr
    End Function

End Class