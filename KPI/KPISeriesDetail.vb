Public Class KPISeriesDetail

#Region "Properties"

    'Record Key
    Dim _RecordKey As String
    Public Property RecordKey() As String
        Get
            Return _RecordKey
        End Get
        Set(ByVal value As String)
            _RecordKey = value
        End Set
    End Property

    'Record Name
    Dim _RecordName As String
    Public Property RecordName() As String
        Get
            Return _RecordName
        End Get
        Set(ByVal value As String)
            _RecordName = value
        End Set
    End Property
#End Region
End Class
