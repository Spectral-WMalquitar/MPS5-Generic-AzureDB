'On Error Blame Teddy
Public Class SQLDB

    Private nRecordCount As Integer = 0
    Private ErrMsg As String

    'SQL Server connectors
    Private sqlcon As SqlClient.SqlConnection
    Private sqladp As SqlClient.SqlDataAdapter
    Private sqlcmd As SqlClient.SqlCommand
    Private sqlrdr As SqlClient.SqlDataReader

    'Initialize the Database
    'ConnectionString -> Connection string for the specified database or server.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub New(ByVal ConnectionString As String)
        sqlcon = New SqlClient.SqlConnection(ConnectionString)
    End Sub

    'Creates a Recordset, requires sql statement
    <System.Diagnostics.DebuggerStepThrough()> _
    Function CreateTable(ByVal sql As String) As DataTable
        Dim ctable As New DataTable
        Try
            sqlcon.Open()
            sqladp = New SqlClient.SqlDataAdapter(sql, sqlcon)
            sqladp.Fill(ctable)
            sqladp.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        nRecordCount = ctable.Rows.Count
        Return ctable
    End Function

    'Creates a Recordset, requires sql statement
    <System.Diagnostics.DebuggerStepThrough()> _
    Function CreateDataSet(ByVal queries() As String, ByVal relations() As String) As DataSet
        Dim data As New DataSet()
        Dim query As String, rel As String
        Try
            sqlcon.Open()
            For Each query In queries
                sqladp = New SqlClient.SqlDataAdapter
                sqladp.TableMappings.Add("Table", query.Split(";").GetValue(0))
                sqlcmd = New SqlClient.SqlCommand(query.Split(";").GetValue(1), sqlcon)
                sqladp.SelectCommand = sqlcmd
                sqladp.Fill(data)
                sqladp.Dispose()
            Next
            For Each rel In relations
                Dim rel_item() As String = rel.Split(";")
                Dim keyColumn As DataColumn = data.Tables(rel_item(1).Split(".").GetValue(0)).Columns(rel_item(1).Split(".").GetValue(1))
                Dim foreignKeyColumn As DataColumn = data.Tables(rel_item(2).Split(".").GetValue(0)).Columns(rel_item(2).Split(".").GetValue(1))
                data.Relations.Add(rel_item(0), keyColumn, foreignKeyColumn)
            Next
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return data
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Function FillTable(ByVal sql As String, ByVal ctable As DataTable) As DataTable
        Dim xtable As DataTable = ctable.Clone
        Try
            sqlcon.Open()
            sqladp = New SqlClient.SqlDataAdapter(sql, sqlcon)
            sqladp.Fill(xtable)
            sqladp.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        nRecordCount = xtable.Rows.Count
        Return xtable
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Function RecordCount() As Integer
        Return nRecordCount
    End Function

    'Execute the specified sql statement
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function RunSql(ByVal sql As String) As Boolean
        Try
            sqlcmd = New SqlClient.SqlCommand(sql, sqlcon)
            sqlcon.Open()
            sqlcmd.ExecuteNonQuery()
            sqlcmd.Dispose()
            sqlcon.Close()
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
            Return False
        End Try
    End Function

    'Execute the specified sql statement
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function RunSqls(ByVal sqls As ArrayList) As Boolean
        ErrMsg = ""
        Try
            Dim sql As String
            sqlcmd = New SqlClient.SqlCommand()
            sqlcmd.Connection = sqlcon
            sqlcon.Open()
            For Each sql In sqls
                If sql <> "" Then
                    sqlcmd.CommandText = sql
                    Try
                        sqlcmd.ExecuteNonQuery()
                    Catch ex As Exception
                        ErrMsg = String.Format("{0}Error Message:{1}{2}SQL Statement:{3}{4}", ErrMsg, ex.Message, Environment.NewLine, sql, Environment.NewLine)
                    End Try
                End If
            Next
            sqlcmd.Dispose()
            sqlcon.Close()
            If ErrMsg <> "" Then
                LogErrors(ErrMsg)
            End If
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
            LogErrors(ErrMsg)
            Return False
        End Try
    End Function

    'Execute the specified sql statement in a transaction
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function RunTransaction(ByVal sqls As ArrayList) As Boolean
        Try
            sqlcon.Open()
            sqlcmd = sqlcon.CreateCommand()
            Dim transaction As SqlClient.SqlTransaction = sqlcon.BeginTransaction(), sql As String
            sqlcmd.Connection = sqlcon
            sqlcmd.Transaction = transaction
            Try
                For Each sql In sqls
                    If sql <> "" Then
                        sqlcmd.CommandText = sql
                        sqlcmd.ExecuteNonQuery()
                    End If
                Next
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
            End Try
            sqlcmd.Dispose()
            sqlcon.Close()
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
            Return False
        End Try
    End Function

    'expr -> field or expresion you want to lookup
    'domain -> requires <table/query> name in the specified database or <database>.<table/view> name on the specified server.
    'defaultvalue -> the return value if expresion is null, cannot be found or the function encountered error.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As String, ByVal defaultvalue As String) As String
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 " & expr & " FROM " & domain, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0).ToString
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    'expr -> field or expresion you want to lookup
    'domain -> requires <table/query> name in the specified database or <database>.<table/view> name on the specified server.
    'defaultvalue -> the return value if expresion is null, cannot be found or the function encountered error.
    'Criteria -> primary filter.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As String, ByVal defaultvalue As String, ByVal Criteria As String) As String
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 " & expr & " FROM " & domain & IIf(Criteria = "", "", " WHERE " & Criteria).ToString, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0).ToString
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    'expr -> field or expresion you want to lookup
    'domain -> requires <table/query> name in the specified database or <database>.<table/view> name on the specified server.
    'defaultvalue -> the return value if expresion is null, cannot be found or the function encountered error.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As Date, ByVal defaultvalue As String) As Date
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 " & expr & " FROM " & domain, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0).ToString
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    'expr -> field or expresion you want to lookup
    'domain -> requires <table/query> name in the specified database or <database>.<table/view> name on the specified server.
    'defaultvalue -> the return value if expresion is null, cannot be found or the function encountered error.
    'Criteria -> primary filter.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As String, ByVal defaultvalue As Date, ByVal Criteria As String) As Date
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 " & expr & " FROM " & domain & IIf(Criteria = "", "", " WHERE " & Criteria).ToString, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0)
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    'expr -> field or expresion you want to lookup
    'domain -> requires <table/query> name in the specified database or <database>.<table/view> name on the specified server.
    'defaultvalue -> the return value if expresion is null, cannot be found or the function encountered error.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DFunction(ByVal expr As String, ByVal defaultvalue As Object) As Object
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT " & expr, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0)
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub BeginReader(ByVal _sql As String)
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand(_sql, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Read()
        Try
            Return sqlrdr.Read()
        Catch ex As Exception
            ErrMsg = ex.Message
            Return False
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal index As Integer) As Object
        Try
            Return sqlrdr.Item(index)
        Catch ex As Exception
            ErrMsg = ex.Message
            Return System.DBNull.Value
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal name As String) As Object
        Try
            Return sqlrdr.Item(name)
        Catch ex As Exception
            ErrMsg = ex.Message
            Return System.DBNull.Value
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal name As String, defaultvalue As Object) As Object
        Try
            If sqlrdr.Item(name) Is System.DBNull.Value Then
                Return defaultvalue
            Else
                Return sqlrdr.Item(name)
            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            Return defaultvalue
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal index As Integer, defaultvalue As Object) As Object
        Try
            If sqlrdr.Item(index) Is System.DBNull.Value Then
                Return defaultvalue
            Else
                Return sqlrdr.Item(index)
            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            Return defaultvalue
        End Try
    End Function
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItemCount() As Integer
        Try
            Return sqlrdr.FieldCount
        Catch ex As Exception
            ErrMsg = ex.Message
            Return 0
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function HasRows() As Boolean
        Try
            Return sqlrdr.HasRows
        Catch ex As Exception
            ErrMsg = ex.Message
            Return False
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub CloseReader()
        Try
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Connect() As Boolean
        Try
            sqlcon.Open()
            sqlcon.Close()
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            Return False
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetDataDir(ByVal cDbName As String) As String
        Dim cFileName As String = ""
        sqlcon.Open()
        sqlcmd = New SqlClient.SqlCommand("select physical_name from master.sys.master_files WHERE databasestrID = DBstrID(N'" & cDbName & "') AND name='" & cDbName & "'", sqlcon)
        sqlrdr = sqlcmd.ExecuteReader()
        If sqlrdr.HasRows Then
            sqlrdr.Read()
            cFileName = sqlrdr(0).ToString
        End If
        sqlrdr.Close()
        sqlcmd.Dispose()
        sqlcon.Close()
        Return cFileName
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Backup(ByVal cDBName As String, ByVal cFileName As String) As Boolean
        Return RunSql("BACKUP DATABASE " & cDBName & " TO DISK='" & cFileName & "'")
    End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function Restore(ByVal cDBName As String, ByVal cFileName As String) As Boolean
        Return RunSql("USE MASTER; ALTER DATABASE " & cDBName & " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE " & cDBName & " FROM DISK='" & cFileName & "'; ALTER DATABASE " & cDBName & " SET MULTI_USER")
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetLastErrorMessage() As String
        Return ErrMsg
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub ShowLastErrorMessage()
        MsgBox(ErrMsg, MsgBoxStyle.Critical)
    End Sub

End Class
