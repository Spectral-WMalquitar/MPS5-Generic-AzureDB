Public Class PrintSelection

    Public Table As New DataTable

    Sub New()
        InitTable()
    End Sub

    Sub InitTable()
        Dim ccolumn As DataColumn

        Table.Columns.Clear()

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        Table.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        Table.Columns.Add(ccolumn)
    End Sub
End Class
