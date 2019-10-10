Public Class clsSortOption
    Public Function Create(oReportInfo As ReportInfo) As BaseSortOption
        Dim ReturnValue As New BaseSortOption
        Try
            ReturnValue.RefreshData(Trim(IfNull(oReportInfo.SortFields, "")))
        Catch ex As Exception
            LogErrors("Failed to Refresh Sort Options with SortFields '" & oReportInfo.SortFields & "'")
        End Try

        Return ReturnValue

    End Function
End Class
