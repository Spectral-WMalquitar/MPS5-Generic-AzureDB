Public Class MPSArchiveUtil

    Private MPSARC As SQLDB
    Private ServerName As String
    Private ID As String
    Private PWD As String
    Private DBName As String

#Region "Class Constructor"
    Sub New()
        ConnectToDatabase()
    End Sub
#End Region

#Region "Connection Setting for Archive"

    Public Sub ConnectToDatabase()
        GetConnectionDetails()
        MPSARC = New SQLDB(GetArcConnectionString())
    End Sub

    Public Sub SetConnectionsDetails(ByVal Server As String, ByVal UID As String, ByVal PWD As String, ByVal DB As String)
        Try
            WriteReg("ARCSERVER", Server)
            WriteReg("ARCUID", UID)
            WriteReg("ARCPWD", PWD)
            WriteReg("ARCDBNAME", DB)
        Catch ex As Exception
            WriteReg("ARCSERVER", "")
            WriteReg("ARCUID", "")
            WriteReg("ARCPWD", "")
            WriteReg("ARCDBNAME", "")
            Debug.WriteLine("There is an error in archive connection : " + ex.Message)
        End Try
    End Sub

    Private Sub GetConnectionDetails()
        Try
            ServerName = GetReg("ARCSERVER")
            ID = GetReg("ARCUID")
            PWD = GetReg("ARCPWD")
            DBName = GetReg("ARCDBNAME")
        Catch ex As Exception
            ServerName = ""
            ID = ""
            PWD = ""
            DBName = ""
            Debug.WriteLine("There is an error in archive connection : " + ex.Message)
        End Try

    End Sub

    Private Function GetArcConnectionString()
        Return "Data Source=" & ServerName & ";Database=" & DBName & ";Persist Security Info=True;User ID=" & ID & ";Password=" & PWD & ";"
    End Function

#End Region

    Private Function ProcessStringCriteria(ByVal CrewID As String) As String

        'Dim separator As Char() = {","}
        Dim idnbrs As String() = CrewID.Split(",")
        Dim retVal As New System.Text.StringBuilder("")

        For i As Int32 = 0 To idnbrs.Length - 1
            retVal.Append("(" & idnbrs(i) & "),")
        Next
        idnbrs = Nothing
        Return retVal.ToString().Substring(0, retVal.ToString().LastIndexOf(",", StringComparison.Ordinal))

    End Function

    Public Function RunTransferToArchive(ByVal CrewID As String) As Boolean
        Dim IsSuccess As Boolean = False
        Dim queries As New ArrayList()
        Try
            'Dim crewIDNbrs As String = ProcessStringCriteria(CrewID)
            queries.Add("DELETE FROM dbo.tbl_temp_selected_IDNbrs")
            queries.Add("INSERT INTO dbo.tbl_temp_selected_IDNbrs ( idnbrs ) VALUES " & ProcessStringCriteria(CrewID))
            queries.Add("EXEC RunTransferToArchive")
            IsSuccess = MPSDB.RunTransaction(queries)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            queries = Nothing
        End Try

        Return IsSuccess
    End Function

    Public Function RunDeleteCrewInArchive(ByVal CrewID As String) As Boolean
        Dim IsSuccess As Boolean = False
        Dim queries As New ArrayList()
        Try
            Me.ConnectToDatabase()
            'Dim crewIDNbrs As String = ProcessStringCriteria(CrewID)
            queries.Add("DELETE FROM dbo.tbl_temp_selected_IDNbrs")
            queries.Add("INSERT INTO dbo.tbl_temp_selected_IDNbrs ( idnbrs ) VALUES " & ProcessStringCriteria(CrewID))
            queries.Add("EXEC RunDeleteCrewInArchive @LastUpdatedBy = '" & GetUserName() & "'")
            IsSuccess = MPSDB.RunTransaction(queries)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            queries = Nothing
        End Try
        Return IsSuccess
    End Function


    Public Function RunTrasferToActive(ByVal CrewID As String) As Boolean
        Dim IsSuccess As Boolean = False
        Dim queries As New ArrayList()
        Try
            Me.ConnectToDatabase()
            'Dim crewIDNbrs As String = ProcessStringCriteria(CrewID)
            queries.Add("DELETE FROM dbo.tbl_temp_selected_IDNbrs")
            queries.Add("INSERT INTO dbo.tbl_temp_selected_IDNbrs ( idnbrs ) VALUES " & ProcessStringCriteria(CrewID))
            queries.Add("EXEC RunTransferToActive")
            IsSuccess = MPSDB.RunTransaction(queries)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            queries = Nothing
        End Try
        Return IsSuccess
    End Function

End Class
