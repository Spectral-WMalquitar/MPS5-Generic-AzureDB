Public Class clsDatasourceUpdate
    Dim db As SQLDB

#Region "Update_Datasource"
    Public Function updateDatasource(ByVal dt As DataTable, ByVal strViewName As String, ByVal strPKeyName As String) As Object
        Dim dtTempTbl As DataTable
        Dim strCmd As String
        Dim strTempTblName As String = GetUserName() & "_" & strViewName
        If dt.Rows.Count > 0 Then
            strCmd = "EXEC [dbo].[CREATE_UserTempTable] @tempTblName = '" & strTempTblName & "', @viewName = '" & strViewName & "'"
            dtTempTbl = db.CreateTable(strCmd)
            dtTempTbl.PrimaryKey = New DataColumn() {New DataColumn(strPKeyName)}
            dt.PrimaryKey = New DataColumn() {dt.Columns(strPKeyName)}
            dt.Merge(dtTempTbl, True)
            Return dt
        Else
            strCmd = "EXEC [dbo].[CREATE_UserTempTable] @tempTblName = '', @viewName = ''"
            dtTempTbl = db.CreateTable(strCmd)
            Return dtTempTbl
        End If
    End Function
#End Region

End Class
