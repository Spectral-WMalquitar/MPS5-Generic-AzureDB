Public Module basSecurity

    Public oLogDeletionSec As New LogDeletion

    Public Class LogDeletion : Implements IDisposable
        Public listLogEntry As New List(Of RecordStructure)
        Private DBConnStr As String = ""

        Public Sub New()

        End Sub

        Public Sub New(pCallingApp As CallingApp, pCallingForm As String, pDLL As String, pTableName As String, pWhereCond As String, pRecordDesc As String, pDelType As DeletionType, pDelDesc As String, pLastUpdatedBy As String)
            CreateLogEntry(pCallingApp, pCallingForm, pDLL, pTableName, pWhereCond, pRecordDesc, pDelType, pDelDesc, pLastUpdatedBy)
        End Sub

        Public Sub Init(ConnStr As String)
            listLogEntry = New List(Of RecordStructure)
        End Sub

        'Public Sub New(pLogEntry As RecordStructure)
        '    CurrentLogEntry = pLogEntry
        'End Sub
        Public Sub CreateLogEntry(pCallingApp As CallingApp, pCallingForm As String, pDLL As String, pTableName As String, pWhereCond As String, pRecordDesc As String, pDelType As DeletionType, pDelDesc As String, pLastUpdatedBy As String)
            Dim _logentry As New RecordStructure
            Try
                With _logentry
                    .CallingApp = pCallingApp
                    .CallingForm = pCallingForm
                    .DLL = pDLL
                    .TableName = pTableName
                    .WhereCond = pWhereCond
                    .RecordDesc = pRecordDesc
                    .DelType = pDelType
                    .DelDesc = pDelDesc
                    .LastUpdatedBy = pLastUpdatedBy
                    .UserInfo = pLastUpdatedBy
                End With
            Catch ex As Exception
                _logentry = Nothing
            End Try

            If Not IsNothing(_logentry) Then
                listLogEntry.Add(_logentry)
            End If
        End Sub

        Public Enum CallingApp
            Crewing = 1
            Admin = 2
            Database = 3
        End Enum

        Private ReadOnly Property GetCallingAppName(pCallingApp As CallingApp) As String
            Get
                Select Case pCallingApp
                    Case CallingApp.Admin
                        Return "ADMIN"
                    Case CallingApp.Crewing
                        Return "CREWING"
                    Case CallingApp.Database
                        Return "DATABASE"

                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property

        Public Enum DeletionType
            Manual = 0
            Automatic = 1
        End Enum


        Public Class RecordStructure
            Public CallingApp As CallingApp
            Public CallingForm As String
            Public DLL As String
            Public UserInfo As String
            Public TableName As String
            Public WhereCond As String
            Public RecordDesc As String
            Public DelType As DeletionType
            Public DelDesc As String
            Public LastUpdatedBy As String

            Public Sub New()

            End Sub

            Public Sub New(pCallingApp As CallingApp, pCallingForm As String, pDLL As String, pTableName As String, pWhereCond As String, pRecordDesc As String, pDelType As DeletionType, pDelDesc As String, pLastUpdatedBy As String)
                CallingApp = pCallingApp
                CallingForm = pCallingForm
                DLL = pDLL
                UserInfo = pLastUpdatedBy
                TableName = pTableName
                WhereCond = pWhereCond
                RecordDesc = pRecordDesc
                DelType = pDelType
                DelDesc = pDelDesc
                LastUpdatedBy = pLastUpdatedBy
            End Sub
        End Class

        Public Sub AddLogEntryToDatabase()
            If Not IsNothing(listLogEntry) Then
                For Each obj As RecordStructure In listLogEntry
                    Try
                        AddLogEntryToDatabase(obj)
                    Catch ex As Exception
                        LogErrors("Add Log Deletion : [" & obj.TableName & "] " & obj.RecordDesc & " | " & obj.WhereCond)
                    End Try
                Next

            End If
            listLogEntry.Clear()
            Me.Dispose()
        End Sub

        Private Sub AddLogEntryToDatabase(pLogEntry As RecordStructure)
            Dim sqlConn As SqlClient.SqlConnection = New SqlClient.SqlConnection(DBConnStr)
            Dim sqlTran As SqlClient.SqlTransaction = Nothing
            Dim da As New System.Data.SqlClient.SqlDataAdapter

            Try
                sqlConn.Open()
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = "AddDeletionLog"
                    cmd.CommandType = CommandType.StoredProcedure
                    With cmd.Parameters
                        .AddWithValue("@CallingApp", GetCallingAppName(pLogEntry.CallingApp))
                        .AddWithValue("@CallingForm", pLogEntry.CallingForm)
                        .AddWithValue("@DLL", pLogEntry.DLL)
                        .AddWithValue("@UserInfo", pLogEntry.UserInfo)
                        .AddWithValue("@TableName", pLogEntry.TableName)
                        .AddWithValue("@WhereCond", pLogEntry.WhereCond)
                        .AddWithValue("@RecordDesc", pLogEntry.RecordDesc)
                        .AddWithValue("@DelType", pLogEntry.DelType)
                        .AddWithValue("@DelDesc", pLogEntry.DelDesc)
                        .AddWithValue("@LastUpdatedBy", pLogEntry.LastUpdatedBy)
                    End With
                    Dim d As New DataTable
                    da.SelectCommand = cmd
                    cmd.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                sqlConn.Close()

            Finally
                sqlConn.Close()
            End Try
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
                listLogEntry = Nothing
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

End Module
