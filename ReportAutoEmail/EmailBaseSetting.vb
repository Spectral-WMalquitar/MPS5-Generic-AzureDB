Public Class EmailBaseSetting

    Public Overridable Sub initControls()

    End Sub

    Public Overridable Sub loadData()

    End Sub

    Public Overridable Sub ClearControls()

    End Sub

    Public Overridable Sub SetIntervals(value As String)

    End Sub

    Public Overridable Function GetIntervals()
        Return ""
    End Function

    Public Overridable Sub MakeControlsEditable(editable As Boolean)

    End Sub

    Public Overridable Sub EnableEditListener(value As Boolean)

    End Sub

End Class
