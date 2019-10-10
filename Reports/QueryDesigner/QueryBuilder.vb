Imports System.Text
Imports System.ComponentModel

Public Enum GroupByExtension
    None = 0
    Cube = 1
    Rollup = 2
    All = 3
End Enum

Public Class QueryBuilder

    ' ** Fields
    Private _distinct As Boolean
    Private _gbExtension As GroupByExtension
    Private _groupBy As Boolean
    Private _missingJoins As Boolean
    Private _queryFields As QueryFieldCollection
    Private _schema As OleDbSchema
    Private _sql As String = Nothing
    Private _sqlIsDirty As Boolean
    Private _tableCount As Integer
    Private _top As Integer

    Private _criStatement As String

    ' ** Ctor
    Friend Sub New(ByVal schema As OleDbSchema)
        Me._schema = schema
        Me._queryFields = New QueryFieldCollection
        AddHandler Me._queryFields.ListChanged, New ListChangedEventHandler(AddressOf Me._queryFields_ListChanged)
    End Sub

    ' ** Event Handlers
    Private Sub _queryFields_ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        Me._sqlIsDirty = True
    End Sub

    ' ** Implementation
    Private Function BuildFromClause() As String
RETRYCLAUSE:
        Dim dt As DataTable
        Dim i As Integer
        Dim tables As New List(Of DataTable)
        Dim field As QueryField
        For Each field In Me.QueryFields
            Dim tableName As String = field.Table
            Dim table As DataTable = Me._schema.Tables.Item(tableName)
            If Not ((table Is Nothing) OrElse tables.Contains(table)) Then
                tables.Add(table)
            End If
        Next
        Me._tableCount = tables.Count
        Dim qTables As New List(Of DataTable)
        Dim done As Boolean = False
        'added by Elmer 20151211
        tables.Reverse()
        Do While ((qTables.Count < tables.Count) AndAlso Not done)
            done = True
            For Each dt In tables
                If Me.InsertRelatedTable(dt, qTables) Then
                    done = False
                End If
            Next
        Loop

        Dim qJoins As New List(Of String)
        Dim index As Integer
        For index = 0 To (qTables.Count - 1) - 1
            Dim dt1 As DataTable = qTables.Item(index)
            Dim dt2 As DataTable = qTables.Item((index + 1))
            Dim dr As DataRelation = Me.GetRelation(dt1, dt2)
            qJoins.Add(String.Format("{0}.{1} = {2}.{3}", New Object() {OleDbSchema.GetFullTableName(dr.ParentTable), dr.ParentColumns(0).ColumnName, OleDbSchema.GetFullTableName(dr.ChildTable), dr.ChildColumns(0).ColumnName}))
        Next index
        Dim sb As New StringBuilder
        For i = 0 To (qTables.Count - 1) - 1
            dt = qTables.Item(i)
            If (sb.Length > 0) Then
                sb.Append(vbNewLine + vbTab)
            End If
            sb.AppendFormat("({0} LEFT JOIN", OleDbSchema.GetFullTableName(dt))
        Next i
        sb.AppendFormat(" {0}", OleDbSchema.GetFullTableName(qTables.Item((qTables.Count - 1))))
        i = (qJoins.Count - 1)
        Do While (i >= 0)
            Dim join As String = qJoins.Item(i)
            sb.AppendFormat(vbNewLine + vbTab & "ON {0})", join)
            i -= 1
        Loop

        Me._missingJoins = (qTables.Count < tables.Count)
        If Me._missingJoins Then
            MsgBox("A non-relational tables have detected. Query will refresh.", MsgBoxStyle.Exclamation, GetAppName)
            Dim ss As String = tables.Item(0).TableName
            tables.RemoveAt(0)
            qTables.RemoveAt(0)
            Dim q As QueryField
            For Each q In Me.QueryFields
                If q.Table = ss Then
                    Me.QueryFields.Remove(q)
                    Exit For
                End If
            Next

            GoTo RETRYCLAUSE ' this will reconstruct from clause

            'For Each dt In tables
            '    If Not qTables.Contains(dt) Then
            '        sb.AppendFormat(", {0}", OleDbSchema.GetFullTableName(dt))
            '        qTables.Add(dt)
            '    End If
            'Next
        End If
        Return sb.ToString
    End Function

    Private Function BuildGroupByClause() As String
        Dim sb As New StringBuilder
        If Me.GroupBy Then
            Dim field As QueryField
            For Each field In Me.QueryFields
                If (field.GroupBy = GroupingAggregate.GroupBy) Then
                    If (sb.Length > 0) Then
                        sb.Append("," & vbNewLine + vbTab)
                    End If
                    Dim item As String = field.GetFullName
                    sb.Append(item)
                End If
            Next
            Select Case Me.GroupByExtension
                Case GroupByExtension.Cube
                    sb.Append(" WITH CUBE")
                    Exit Select
                Case GroupByExtension.Rollup
                    sb.Append(" WITH ROLLUP")
                    Exit Select
                Case GroupByExtension.All
                    Return ("ALL " & sb.ToString)
            End Select
        End If
        Return sb.ToString
    End Function

    Private Function BuildOrderByClause() As String
        Dim sb As New StringBuilder
        Dim field As QueryField
        For Each field In Me.QueryFields
            If (field.Sort <> Sort.NoSort) Then
                If (sb.Length > 0) Then
                    sb.Append("," & vbNewLine + vbTab)
                End If
                Dim item As String = field.GetFullName(True)
                sb.Append(item)
                If (field.Sort = Sort.Descending) Then
                    sb.Append(" DESC")
                End If
            End If
        Next
        Return sb.ToString
    End Function

    Private Function BuildSelectClause() As String
        Dim sb As New StringBuilder
        Dim field As QueryField
        For Each field In Me.QueryFields
            If field.Output Then
                If (sb.Length > 0) Then
                    sb.Append("," & vbNewLine + vbTab)
                End If
                Dim item As String = field.GetFullName(Me.GroupBy)
                sb.Append(item)
                If Not String.IsNullOrEmpty(field.Alias) Then
                    sb.AppendFormat(" AS {0}", OleDbSchema.BracketName(field.Alias))
                End If
            End If
        Next
        Return sb.ToString
    End Function

    Private Function BuildSqlStatement() As String
        If ((Me.QueryFields.Count = 0) OrElse (Me._schema Is Nothing)) Then
            Me._tableCount = 0
            Me._missingJoins = False
            Return String.Empty
        End If
        Dim sb As New StringBuilder
        sb.Append("SELECT ")
        If Me.Distinct Then
            sb.Append("DISTINCT ")
        End If
        If (Me.Top > 0) Then
            sb.AppendFormat("TOP {0} ", Me.Top)
        End If
        sb.Append(vbNewLine + vbTab)
        Dim cFromClause As String
        cFromClause = Me.BuildFromClause
        Dim cSelectClause As String
        cSelectClause = Me.BuildSelectClause
        sb.Append(cSelectClause)
        sb.AppendFormat(ChrW(13) & ChrW(10) & "FROM" & vbNewLine + vbTab & "{0}", cFromClause)
        If Me.GroupBy Then
            Dim groupBy As String = Me.BuildGroupByClause
            If (groupBy.Length > 0) Then
                sb.AppendFormat(ChrW(13) & ChrW(10) & "GROUP BY" & vbNewLine + vbTab & "{0}", groupBy)
            End If
            Dim havingArr(1) As String
            havingArr = Me.BuildWhereClause()
            Dim having As String = havingArr(0)
            If (having.Length > 0) Then
                sb.AppendFormat(ChrW(13) & ChrW(10) & "HAVING" & vbNewLine + vbTab & "{0}", having)
            End If
        Else
            Dim whereArr(1) As String
            whereArr = Me.BuildWhereClause()
            Dim where As String = whereArr(0)
            If (where.Length > 0) Then
                sb.AppendFormat(ChrW(13) & ChrW(10) & "WHERE" & vbNewLine + vbTab & "{0}", where)
            End If
        End If
        Dim orderBy As String = Me.BuildOrderByClause
        If (orderBy.Length > 0) Then
            sb.AppendFormat(ChrW(13) & ChrW(10) & "ORDER BY" & vbNewLine + vbTab & "{0}", orderBy)
        End If
        sb.Append(";"c)
        Return sb.ToString
    End Function

    Private Function BuildWhereClause() As Array

        Dim sb As New StringBuilder
        Dim sbF As New StringBuilder
        Dim field As QueryField
        Dim strCriteriaOperator As String = ""

        For Each field In Me.QueryFields
            If (field.Filter.Length > 0) Then
                Dim item As String = field.GetFilterExpression
                Dim itemF As String = field.GetFilterExpressionFormated
                If (item.Length > 0) Then
                    If (sb.Length > 0) Then
                        If strCriteriaOperator = "AND" Then
                            sb.Append(" AND" & vbNewLine + vbTab)
                            sbF.Append(" AND ")
                            strCriteriaOperator = field.GetCriteriaOperator
                        ElseIf strCriteriaOperator = "OR" Then
                            sb.Append(" OR" & vbNewLine + vbTab)
                            sbF.Append(" OR ")
                            strCriteriaOperator = field.GetCriteriaOperator
                        End If
                    Else
                        strCriteriaOperator = field.GetCriteriaOperator
                    End If
                    sb.Append(field.GetOpenParen & item & field.GetCloseParen)
                    sbF.Append(field.GetOpenParen & itemF & field.GetCloseParen)
                End If
            End If
        Next

        Dim arrReturn(1) As String
        arrReturn(0) = sb.ToString
        arrReturn(1) = sbF.ToString

        Return arrReturn
    End Function

    Private Function GetRelation(ByVal dt1 As DataTable, ByVal dt2 As DataTable) As DataRelation
        Dim dr As DataRelation
        For Each dr In Me._schema.Relations
            If (((dr.ParentTable Is dt1) AndAlso (dr.ChildTable Is dt2)) OrElse ((dr.ParentTable Is dt2) AndAlso (dr.ChildTable Is dt1))) Then
                Return dr
            End If
        Next
        Return Nothing
    End Function

    Private Function InsertRelatedTable(ByVal dt As DataTable, ByVal list As List(Of DataTable)) As Boolean
        If Not list.Contains(dt) Then
            If (list.Count = 0) Then
                list.Add(dt)
                Return True
            End If
            Dim index As Integer = 0
            Do While (index <= list.Count)
                Dim before As Boolean = ((index = 0) OrElse (Not Me.GetRelation(dt, list.Item((index - 1))) Is Nothing))
                Dim after As Boolean = ((index = list.Count) OrElse (Not Me.GetRelation(dt, list.Item(index)) Is Nothing))
                If (before AndAlso after) Then
                    list.Insert(index, dt)
                    Return True
                End If
                index += 1
            Loop
        End If
        Return False
    End Function

    ' ** Properties
    Public Property ConnectionString() As String
        Get
            Return Me._schema.ConnectionString
        End Get
        Set(ByVal value As String)
            If (Me._schema.ConnectionString <> value) Then
                Me._schema.ConnectionString = value
                Me._sql = Nothing
                Me.QueryFields.Clear()
            End If
        End Set
    End Property

    Public Property Distinct() As Boolean
        Get
            Return Me._distinct
        End Get
        Set(ByVal value As Boolean)
            Me._distinct = value
            Me._sql = Nothing
        End Set
    End Property

    Public Property GroupBy() As Boolean
        Get
            Return Me._groupBy
        End Get
        Set(ByVal value As Boolean)
            If (Me._groupBy <> value) Then
                Me._groupBy = value
                Me._sql = Nothing
            End If
        End Set
    End Property

    Public Property GroupByExtension() As GroupByExtension
        Get
            Return Me._gbExtension
        End Get
        Set(ByVal value As GroupByExtension)
            If (Me._gbExtension <> value) Then
                Me._gbExtension = value
                Me._sql = Nothing
            End If
        End Set
    End Property

    Public ReadOnly Property QueryFields() As QueryFieldCollection
        Get
            Return Me._queryFields
        End Get
    End Property

    Friend ReadOnly Property Schema() As OleDbSchema
        Get
            Return Me._schema
        End Get
    End Property

    Public ReadOnly Property Sql() As String
        Get
            If ((Me._sql Is Nothing) OrElse Me._sqlIsDirty) Then
                Me._sqlIsDirty = False
                Me._sql = Me.BuildSqlStatement()
            End If
            Return Me._sql
        End Get
    End Property

    Public Property Top() As Integer
        Get
            Return Me._top
        End Get
        Set(ByVal value As Integer)
            Me._top = value
            Me._sql = Nothing
        End Set
    End Property

    Public ReadOnly Property CriteriaStatement() As String
        Get
            Dim returnStr(1) As String
            returnStr = Me.BuildWhereClause()
            Me._criStatement = returnStr(1)
            Return Me._criStatement
        End Get
    End Property
End Class
