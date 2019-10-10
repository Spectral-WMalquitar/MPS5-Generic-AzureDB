Imports System.Text
Imports System.Data
Imports System.Data.OleDb

Friend Enum TableType
    Table = 0
    View = 1
    Procedure = 2
End Enum


Friend Class OleDbSchema
    Inherits DataSet

    ' ** Fields
    Private _connString As String = String.Empty
    Private Shared _expressionChars As Char() = "(),*".ToCharArray
    Private Const COLUMN_NAME As String = "COLUMN_NAME"
    Private Const DATA_TYPE As String = "DATA_TYPE"
    Private Const FK_COLUMN_NAME As String = "FK_COLUMN_NAME"
    Private Const FK_TABLE_NAME As String = "FK_TABLE_NAME"
    Private Const LINK As String = "LINK"
    Private Const PARAMETER_DEFAULT As String = "PARAMETER_DEFAULT"
    Private Const PARAMETER_NAME As String = "PARAMETER_NAME"
    Private Const PARAMETERS As String = "PARAMETERS"
    Private Const PK_COLUMN_NAME As String = "PK_COLUMN_NAME"
    Private Const PK_TABLE_NAME As String = "PK_TABLE_NAME"
    Private Const PROCEDURE_DEFINITION As String = "PROCEDURE_DEFINITION"
    Private Const PROCEDURE_NAME As String = "PROCEDURE_NAME"
    Private Const PROCEDURE_PARAMETERS As String = "PROCEDURE_PARAMETERS"
    Private Const PROCEDURE_SCHEMA As String = "PROCEDURE_SCHEMA"
    Private Const RETURN_VALUE As String = "RETURN_VALUE"
    Private Const TABLE As String = "TABLE"
    Private Const TABLE_DEFINITION As String = "TABLE_DEFINITION"
    Private Const TABLE_NAME As String = "TABLE_NAME"
    Private Const TABLE_RETURN_VALUE As String = "TABLE_RETURN_VALUE"
    Private Const TABLE_SCHEMA As String = "TABLE_SCHEMA"
    Private Const TABLE_TYPE As String = "TABLE_TYPE"
    Private Const VIEW As String = "VIEW"

    Dim SDB As SQLDB

    ' ** Properties
    Public Property ConnectionString() As String
        Get
            Return Me._connString
        End Get
        Set(ByVal value As String)
            If (value <> Me._connString) Then
                Me._connString = value
                Me.GetSchema()
            End If
        End Set
    End Property

    Public Sub New(Optional DB As SQLDB = Nothing)
        Me.InitializeDerivedDataSet()
        SDB = DB
    End Sub

    ' ** Methods
    Public Shared Function BracketName(ByVal name As String) As String
        If (((name.Length > 1) AndAlso (name.Chars(0) = "["c)) AndAlso (name.Chars((name.Length - 1)) = "]"c)) Then
            Return name
        End If
        Dim needsBrackets As Boolean = False
        If Not OleDbSchema.IsExpression(name) Then
            Dim i As Integer = 0
            Do While ((i < name.Length) AndAlso Not needsBrackets)
                Dim c As Char = name.Chars(i)
                needsBrackets = IIf((i = 0), Not Char.IsLetter(c), (Not Char.IsLetterOrDigit(c) AndAlso (c <> "_"c)))
                i += 1
            Loop
        End If
        Return IIf(needsBrackets, String.Format("[{0}]", name), name)
    End Function

    Private Sub GetAccessParameters(ByVal dr As DataRow, ByVal list As List(Of OleDbParameter))
        Dim procDef As String = TryCast(dr.Item("PROCEDURE_DEFINITION"), String)
        If ((Not procDef Is Nothing) AndAlso procDef.StartsWith("PARAMETERS", StringComparison.OrdinalIgnoreCase)) Then
            Dim pos As Integer = procDef.IndexOf(";"c)
            If (pos > -1) Then
                Dim parmDef As String = procDef.Substring(11, (pos - 11))
                Dim parm As String
                For Each parm In parmDef.Split(New Char() {","c})
                    pos = parm.LastIndexOf(" "c)
                    If (pos > -1) Then
                        Dim p As New OleDbParameter
                        p.ParameterName = parm.Substring(0, pos).Trim
                        p.OleDbType = OleDbSchema.GetOleDbType(parm.Substring((pos + 1)))
                        list.Add(p)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub GetConstraints(ByVal conn As OleDbConnection)
        Dim columnName As String
        Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, Nothing)
        Dim uniqueTables As New Dictionary(Of String, String)
        Dim dr As DataRow
        For Each dr In dt.Rows
            Dim name As String = dr.Item("TABLE_NAME").ToString
            columnName = dr.Item("COLUMN_NAME").ToString
            If MyBase.Tables.Contains(name) Then
                If uniqueTables.ContainsKey(name) Then
                    uniqueTables.Remove(name)
                    Continue For
                End If
                uniqueTables.Item(name) = columnName
            End If
        Next
        Dim tableName As String
        For Each tableName In uniqueTables.Keys
            columnName = uniqueTables.Item(tableName)
            Dim table As DataTable = MyBase.Tables.Item(tableName)
            Dim pk As DataColumn = table.Columns.Item(columnName)
            pk.Unique = True
            pk.AllowDBNull = False
            If ((Not pk.DataType Is GetType(String)) AndAlso (Not pk.DataType Is GetType(Byte))) Then
                Try
                    pk.AutoIncrement = True
                    pk.ReadOnly = True
                Catch
                End Try
            End If
            MyBase.Tables.Item(tableName).PrimaryKey = New DataColumn() {pk}
        Next
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Shared Function GetFullTableName(ByVal table As DataTable) As String
        Dim sb As New StringBuilder
        Dim schema As String = TryCast(table.ExtendedProperties.Item("TABLE_SCHEMA"), String)
        If (Not schema Is Nothing) Then
            sb.AppendFormat("{0}.", schema)
        End If
        sb.Append(OleDbSchema.BracketName(table.TableName))
        Return sb.ToString
    End Function

    Public Shared Function GetOleDbType(ByVal typeName As String) As OleDbType
        Select Case typeName.ToLower
            Case "Bit"
                Return OleDbType.Boolean
            Case "Byte"
                Return OleDbType.TinyInt
            Case "Short"
                Return OleDbType.SmallInt
            Case "Long"
                Return OleDbType.BigInt
            Case "Currency"
                Return OleDbType.Currency
            Case "IEEESingle"
                Return OleDbType.Single
            Case "IEEEDouble"
                Return OleDbType.Double
            Case "DateTime"
                Return OleDbType.Date
            Case "Text"
                Return OleDbType.VarChar
            Case "Decimal"
                Return OleDbType.Decimal
        End Select
        Debug.WriteLine("** unknown type: '{0}'", typeName)
        Return OleDbType.VarChar
    End Function

    Private Shared Function GetProcedureParameters(ByVal table As DataTable) As String
        Dim sb As New StringBuilder
        Dim parms As List(Of OleDbParameter) = TryCast(table.ExtendedProperties.Item("PROCEDURE_PARAMETERS"), List(Of OleDbParameter))
        If (Not parms Is Nothing) Then
            Dim parm As OleDbParameter
            For Each parm In parms
                If (sb.Length > 0) Then
                    sb.Append(", ")
                End If
                Dim value As String = TryCast(parm.Value, String)
                sb.AppendFormat("'{0}'", value.Replace("'", "''"))
            Next
        End If
        Return sb.ToString
    End Function

    Private Sub GetRelations(ByVal conn As OleDbConnection)
        Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, Nothing)
        Dim dr As DataRow
        For Each dr In dt.Rows
            Dim pkTableName As String = CStr(dr.Item("PK_TABLE_NAME"))
            Dim fkTableName As String = CStr(dr.Item("FK_TABLE_NAME"))
            Dim pkColumnName As String = CStr(dr.Item("PK_COLUMN_NAME"))
            Dim fkColumnName As String = CStr(dr.Item("FK_COLUMN_NAME"))
            If ((MyBase.Tables.Contains(pkTableName) AndAlso MyBase.Tables.Contains(fkTableName)) AndAlso (pkTableName <> fkTableName)) Then
                Dim relationName As String = (pkTableName & "_"c & fkTableName)
                If MyBase.Relations.Contains(relationName) Then
                    relationName = (relationName & MyBase.Relations.Count.ToString)
                End If
                Dim pkColumn As DataColumn = MyBase.Tables.Item(pkTableName).Columns.Item(pkColumnName)
                Dim fkColumn As DataColumn = MyBase.Tables.Item(fkTableName).Columns.Item(fkColumnName)
                MyBase.Relations.Add(relationName, pkColumn, fkColumn, True)
            End If
        Next
    End Sub

    Private Sub GetSchema()
        Dim connString As String = OleDbConnString.TranslateConnectionString(Me._connString)
        Me.Reset()
        MyBase.EnforceConstraints = False
        Using conn As OleDbConnection = New OleDbConnection(connString)
            conn.Open()
            Me.GetTables(conn)
            Me.GetRelations(conn)
            Me.GetConstraints(conn)
            'Me.GetStoredProcedures(conn) 'comment by Elmer 20160824 Error invalid OLEDBTYPE 143
            conn.Close()
        End Using
    End Sub

    Public Shared Function GetSchema(ByVal connString As String) As OleDbSchema
        connString = OleDbConnString.TranslateConnectionString(connString)
        If (String.IsNullOrEmpty(connString) OrElse (connString.IndexOf("Provider=", StringComparison.OrdinalIgnoreCase) < 0)) Then
            Return Nothing
        End If
        Try
            Dim ds As New OleDbSchema
            ds.ConnectionString = connString
            Return ds
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Function GetSelectStatement(ByVal table As DataTable) As String
        Return IIf((OleDbSchema.GetTableType(table) = TableType.Procedure), String.Format("EXEC {0}{1}", OleDbSchema.GetFullTableName(table), OleDbSchema.GetProcedureParameters(table)), String.Format("SELECT * from {0}", OleDbSchema.GetFullTableName(table)))
    End Function

    Private Function GetSqlServerParameters(ByVal dtParms As DataTable, ByVal list As List(Of OleDbParameter)) As Boolean
        Dim returnsValue As Boolean = False
        Dim parm As DataRow
        For Each parm In dtParms.Rows
            Dim name As String = CStr(parm.Item("PARAMETER_NAME")).Substring(1)
            If ((name = "RETURN_VALUE") OrElse (name = "TABLE_RETURN_VALUE")) Then
                returnsValue = True
            Else
                Dim p As New OleDbParameter(name, DirectCast(parm.Item("DATA_TYPE"), OleDbType))
                p.Value = TryCast(parm.Item("PARAMETER_DEFAULT"), String)
                If (p.Value Is Nothing) Then
                    p.Value = String.Empty
                End If
                list.Add(p)
            End If
        Next
        Return returnsValue
    End Function

    Private Sub GetStoredProcedures(ByVal conn As OleDbConnection)
        Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Procedures, Nothing)
        Dim dr As DataRow
        For Each dr In dt.Rows
            Dim name As String = TryCast(dr.Item("PROCEDURE_NAME"), String)
            If (Not name.StartsWith("~") AndAlso Not name.StartsWith("dt_", StringComparison.OrdinalIgnoreCase)) Then
                Dim schema As String = TryCast(dr.Item("PROCEDURE_SCHEMA"), String)
                If Not Object.Equals(schema, "sys") Then
                    Dim i As Integer
                    Dim pos As Integer = name.LastIndexOf(";"c)
                    If ((pos > -1) AndAlso Integer.TryParse(name.Substring((pos + 1)), i)) Then
                        name = name.Substring(0, pos)
                    End If
                    Dim table As New DataTable(name)
                    Dim parmList As New List(Of OleDbParameter)
                    table.ExtendedProperties.Item("PROCEDURE_PARAMETERS") = parmList
                    If Not conn.Provider.Contains("SQLOLEDB") Then
                        Me.GetAccessParameters(dr, parmList)
                    Else
                        Dim restrictions As Object() = New Object(3) {}
                        restrictions(2) = name
                        Dim dtParms As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Procedure_Parameters, restrictions)
                        If Not Me.GetSqlServerParameters(dtParms, parmList) Then
                            Continue For
                        End If
                    End If
                    Try
                        Dim da As New OleDbDataAdapter(OleDbSchema.GetSelectStatement(table), Me.ConnectionString)
                        da.FillSchema(table, SchemaType.Mapped)
                    Catch x As Exception
                        Debug.WriteLine(x.Message)
                    End Try
                    MyBase.Tables.Add(table)
                End If
            End If
        Next
    End Sub

    Public Shared Function GetTableParameters(ByVal table As DataTable) As List(Of OleDbParameter)
        Return TryCast(table.ExtendedProperties.Item("PROCEDURE_PARAMETERS"), List(Of OleDbParameter))
    End Function

    Private Sub GetTables(ByVal conn As OleDbConnection)
        'Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
        'Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing) 'uncomment to include all
        Dim dt As DataTable = SDB.CreateTable("SELECT * FROM dbo.DATABASETABLES ORDER BY DESCRIPTION")
        Dim dr As DataRow
        For Each dr In dt.Rows
            Dim type As String = CStr(dr.Item("TABLE_TYPE"))
            If ((Not (type <> "TABLE") OrElse Not (type <> "VIEW")) OrElse Not (type <> "LINK")) Then
                Dim name As String = CStr(dr.Item("TABLE_NAME"))
                    Dim table As New DataTable(name)
                    table.ExtendedProperties.Item("TABLE_TYPE") = type
                    Dim col As DataColumn
                    For Each col In dt.Columns
                            table.ExtendedProperties.Item(col.ColumnName) = dr.Item(col)
                    Next
                    Try
                        Dim da As New OleDbDataAdapter(OleDbSchema.GetSelectStatement(table), conn)
                        da.FillSchema(table, SchemaType.Mapped)
                        MyBase.Tables.Add(table)
                    Catch
                    End Try
                End If
        Next
    End Sub

    Public Shared Function GetTableType(ByVal table As DataTable) As TableType
        Select Case TryCast(table.ExtendedProperties.Item("TABLE_TYPE"), String)
            Case "TABLE"
                Return TableType.Table
            Case "LINK", "VIEW"
                Return TableType.View
        End Select
        Return TableType.Procedure
    End Function

    Public Shared Function GetNetType(ByVal oleDbType As OleDbType) As Type
        Select Case CInt(oleDbType)
            Case 0
                Return GetType(Nullable)
            Case 2
                Return GetType(Short)
            Case 3
                Return GetType(Integer)
            Case 4
                Return GetType(Single)
            Case 5
                Return GetType(Double)
            Case 6
                Return GetType(Decimal)
            Case 7
                Return GetType(DateTime)
            Case 8
                Return GetType(String)
            Case 9
                Return GetType(Object)
            Case 10
                Return GetType(Exception)
            Case 11
                Return GetType(Boolean)
            Case 12
                Return GetType(Object)
            Case 13
                Return GetType(Object)
            Case 14
                Return GetType(Decimal)
            Case &H10
                Return GetType(SByte)
            Case &H11
                Return GetType(Byte)
            Case &H12
                Return GetType(UInt16)
            Case &H13
                Return GetType(UInt32)
            Case 20
                Return GetType(Long)
            Case &H15
                Return GetType(UInt64)
            Case &H40
                Return GetType(DateTime)
            Case &H80
                Return GetType(Byte())
            Case &H81
                Return GetType(String)
            Case 130
                Return GetType(String)
            Case &H83
                Return GetType(Decimal)
            Case &H85
                Return GetType(DateTime)
            Case &H86
                Return GetType(TimeSpan)
            Case &H87
                Return GetType(DateTime)
            Case &H8A
                Return GetType(Object)
            Case &H8B
                Return GetType(Decimal)
            Case &H48
                Return GetType(Guid)
            Case 200
                Return GetType(String)
            Case &HC9
                Return GetType(String)
            Case &HCA
                Return GetType(String)
            Case &HCB
                Return GetType(String)
            Case &HCC
                Return GetType(Byte())
            Case &HCD
                Return GetType(Byte())
        End Select
        Debug.WriteLine(("** unknown type: " & oleDbType.ToString))
        Return GetType(String)
    End Function

    Private Shared Function IsExpression(ByVal name As String) As Boolean
        Return (name.IndexOfAny(OleDbSchema._expressionChars) > -1)
    End Function

    Public Shared Function IsNumeric(ByVal type As Type) As Boolean
        Select Case type.GetTypeCode(type)
            Case TypeCode.SByte, TypeCode.Byte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Single, TypeCode.Double, TypeCode.Decimal
                Return True
        End Select
        type = Nullable.GetUnderlyingType(type)
        Return IIf((Not type Is Nothing), OleDbSchema.IsNumeric(type), False)
    End Function

    '-------- Get Table Description
    Public Shared Function GetTableDescription(ByVal table As DataTable) As String
        Return TryCast(table.ExtendedProperties.Item("DESCRIPTION"), String)
    End Function

End Class
