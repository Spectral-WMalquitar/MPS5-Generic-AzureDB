Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Win32

''' <summary>
''' OleDb Connection string utilities.
''' </summary>
Friend Class OleDbConnString

    ' ** Methods

    ''' <summary>
    ''' Prompts the user and edits a connection string.
    ''' </summary>
    Public Shared Function EditConnectionString(ByVal owner As IWin32Window, ByVal connString As String) As String
        Try

            Dim dlinks As New MSDASC.DataLinks
            Dim conn As New ADODB.Connection
            If ((dlinks Is Nothing) OrElse (conn Is Nothing)) Then
                OleDbConnString.Warning(owner, My.Resources.ErrDataLinks, New Object(0 - 1) {})
                Return connString
            End If
            If Not String.IsNullOrEmpty(connString) Then
                conn.ConnectionString = connString
            End If
            Dim obj As Object = conn
            If (Not owner Is Nothing) Then
                dlinks.hWnd = CInt(owner.Handle)
            End If
            If dlinks.PromptEdit((obj)) Then
                connString = conn.ConnectionString
            End If
        Catch x As Exception
            OleDbConnString.Warning(owner, My.Resources.ErrConnectionString, New Object() {x.Message})
        End Try
        Return connString
    End Function
    ''' <summary>
    ''' Prompts the user and gets a connection string.
    ''' </summary>
    Public Shared Function GetConnectionString(ByVal owner As IWin32Window) As String
        Return OleDbConnString.EditConnectionString(owner, String.Empty)
    End Function

    ''' <summary>
    ''' Translates Sql and Access ODBC connection strings into OleDb.
    ''' </summary>
    Public Shared Function TranslateConnectionString(ByVal connString As String) As String
        If ((Not connString Is Nothing) AndAlso (connString.IndexOf("provider=msdasql", StringComparison.OrdinalIgnoreCase) >= 0)) Then
            Dim ds As String = Regex.Match(connString, "Data Source=(?<ds>[^;]+)", RegexOptions.IgnoreCase).Groups.Item("ds").Value
            If String.IsNullOrEmpty(ds) Then
                Return connString
            End If
            Dim keyName As String = ("software\odbc\odbc.ini\" & ds)
            Using key = Registry.LocalMachine.OpenSubKey(keyName)
                If (Not key Is Nothing) Then
                    Return OleDbConnString.TranslateConnectionString(connString, key)
                End If
            End Using
            Using key = Registry.CurrentUser.OpenSubKey(keyName)
                If (Not key Is Nothing) Then
                    Return OleDbConnString.TranslateConnectionString(connString, key)
                End If
            End Using
        End If
        Return connString
    End Function

    Private Shared Function TranslateConnectionString(ByVal connString As String, ByVal key As RegistryKey) As String
        Dim driver As String = TryCast(key.GetValue("driver"), String)
        If ((Not driver Is Nothing) AndAlso (driver.ToLower.IndexOf("odbcjt") > -1)) Then
            Dim mdb As String = TryCast(key.GetValue("dbq"), String)
            If ((Not mdb Is Nothing) AndAlso mdb.ToLower.EndsWith(".mdb")) Then
                Return ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & mdb & ";")
            End If
        End If
        If ((Not driver Is Nothing) AndAlso (driver.ToLower.IndexOf("sqlsrv") > -1)) Then
            Dim server As String = TryCast(key.GetValue("server"), String)
            Dim dbase As String = TryCast(key.GetValue("database"), String)
            If ((((Not server Is Nothing) AndAlso (server.Length > 0)) AndAlso (Not dbase Is Nothing)) AndAlso (dbase.Length > 0)) Then
                Dim fmt As String = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Initial Catalog={0};Data Source={1}"
                Return String.Format(fmt, dbase, server)
            End If
        End If
        Return connString
    End Function

    ''' <summary>
    ''' Trims a connection string for display.
    ''' </summary>
    Public Shared Function TrimConnectionString(ByVal [text] As String) As String
        Dim keys As String() = New String() {"Provider", "Initial Catalog", "Data Source"}
        Dim sb As New StringBuilder
        Dim item As String
        For Each item In [text].Split(New Char() {";"c})
            Dim key As String
            For Each key In keys
                If (item.IndexOf(key, StringComparison.InvariantCultureIgnoreCase) > -1) Then
                    If (sb.Length > 0) Then
                        sb.Append("...")
                    End If
                    sb.Append(item.Split(New Char() {"="c})(1).Trim)
                End If
            Next
        Next
        Return sb.ToString
    End Function

    Private Shared Sub Warning(ByVal owner As IWin32Window, ByVal format As String, ByVal ParamArray args As Object())
        Dim msg As String = String.Format(format, args)
        MessageBox.Show(owner, msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

End Class

