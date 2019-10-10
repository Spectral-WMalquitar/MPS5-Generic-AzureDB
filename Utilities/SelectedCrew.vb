Public Class SelectedCrew

    Private _rankName As String
    Private _surName As String
    Private _firstName As String
    Private _middleName As String
    Private _vesselName As String
    Private _flagRegistry As String
    Private _departureDate As String
    Private _joiningPort As String
    Private _crewIDNbr As String
    Private _activityID As String
    Private _activityGroupID As String
    Private _remarks As String
    Private _startEndDate As String
    Private _competence As String
    Private _competenceRank As String
    Private _startActivityDate As String

    Sub New()
        _crewIDNbr = ""
        _rankName = ""
        _surName = ""
        _firstName = ""
        _middleName = ""
        _vesselName = ""
        _flagRegistry = ""
        _departureDate = ""
        _joiningPort = ""
        _activityID = ""
        _activityGroupID = ""
        _remarks = ""
        _startEndDate = ""
        _competence = ""
        _competenceRank = ""
        _startActivityDate = ""
    End Sub

    Public Property StartActivityDate As String
        Get
            Return _startActivityDate
        End Get
        Set(value As String)
            _startActivityDate = value
        End Set
    End Property

    Public Property Competence As String
        Get
            Return _competence
        End Get
        Set(value As String)
            _competence = value
        End Set
    End Property

    Public Property CompetenceRank As String
        Get
            Return _competenceRank
        End Get
        Set(value As String)
            _competenceRank = value
        End Set
    End Property

    Public Property StartEndDate As String
        Get
            Return _startEndDate
        End Get
        Set(value As String)
            _startEndDate = value
        End Set
    End Property

    Public Property Remarks As String
        Get
            Return _remarks
        End Get
        Set(value As String)
            _remarks = value
        End Set
    End Property

    Public Property ActivityGroupID As String
        Get
            Return _activityGroupID
        End Get
        Set(value As String)
            _activityGroupID = value
        End Set
    End Property

    Public Property ActivityID As String
        Get
            Return _activityID
        End Get
        Set(value As String)
            _activityID = value
        End Set
    End Property

    Public Property CrewIDNbr As String
        Get
            Return _crewIDNbr
        End Get
        Set(value As String)
            _crewIDNbr = value
        End Set
    End Property

    Public Property RankName As String
        Get
            Return _rankName
        End Get
        Set(value As String)
            _rankName = value
        End Set
    End Property

    Public Property SurName As String
        Get
            Return _surName
        End Get
        Set(value As String)
            _surName = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _firstName
        End Get
        Set(value As String)
            _firstName = value
        End Set
    End Property

    Public Property MiddleName As String
        Get
            Return _middleName
        End Get
        Set(value As String)
            _middleName = value
        End Set
    End Property

    Public Property VesselName As String
        Get
            Return _vesselName
        End Get
        Set(value As String)
            _vesselName = value
        End Set
    End Property

    Public Property FlagRegistry As String
        Get
            Return _flagRegistry
        End Get
        Set(value As String)
            _flagRegistry = value
        End Set
    End Property

    Public Property DepartureDate As String
        Get
            Return _departureDate
        End Get
        Set(value As String)
            _departureDate = value
        End Set
    End Property

    Public Property JoiningPort As String
        Get
            Return _joiningPort
        End Get
        Set(value As String)
            _joiningPort = value
        End Set
    End Property
End Class
