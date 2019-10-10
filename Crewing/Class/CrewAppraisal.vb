'This class has the pattern of tblCrewAppraisal
Public Class CrewAppraisal

    Private _AppraisalID As String              'PKey
    Private _FKeyIDNbr As String                'FKeyIDNbr
    Private _AppraisalDate As String            'AppraisalDate
    Private _FKeyActivityID As String           'FKeyActivityID
    Private _Service As String                  'Service
    Private _OccasionForReport As String        'OccasionForReport
    Private _OverallScore As Double             'OverallScore
    Private _Reemployed As Boolean              'Reemployed
    Private _Promotion As Boolean               'Promotion
    Private _SailAgain As Boolean               'SailAgain
    Private _Remarks As String                  'Remarks
    Private _MasterName As String               'MasterName
    Private _ChiefOfficerName As String         'ChiefOfficerName
    Private _ChiefEngineerName As String        'ChiefEngineerName
    Private _Strength As String                 'Strength
    Private _Weaknesses As String               'Weaknesses
    Private _OfficerComment As String           'OfficerComment
    Private _OfficerName As String              'OfficerName
    Private _CommentDate As String              'CommentDate
    Private _CommentFromOffice1 As String       'CommentFromOffice1
    Private _ShipFleetManager As String         'ShipFleetManager
    Private _CommentFromOffice2 As String       'CommentFromOffice2
    Private _SafetyOperationsManager As String  'SafetyOperationsManager
    Private _Reemploy As Boolean                'Reemploy
    Private _Promote As Boolean                 'Promote
    Private _PromoteReemployWhen As String      'PromoteReemployWhen
    Private _AdditionalRemarks As String        'AdditionalRemarks
    Private _TrainingRequirements As String     'TrainingRequirements
    Private _OverallAssessment As String        'OverallAssessment
    Private _DataRemarks As String
    Private _AppraisalFactors As HashSet(Of CrewAppraisalDetails)

    Public Property ChiefEngineer As String
        Get
            Return Me._ChiefEngineerName
        End Get
        Set(value As String)
            Me._ChiefEngineerName = value
        End Set
    End Property

    Public Property DataRemarks As String
        Get
            Return Me._DataRemarks
        End Get
        Set(value As String)
            Me._DataRemarks = value
        End Set
    End Property

    Public Property AppraisalFactorsGrades As HashSet(Of CrewAppraisalDetails)
        Get
            Return Me._AppraisalFactors
        End Get
        Set(value As HashSet(Of CrewAppraisalDetails))
            Me._AppraisalFactors = value
        End Set
    End Property

    Public Function GetAppraisalFactor(index As Int32) As CrewAppraisalDetails
        If Me._AppraisalFactors.Count > 0 Then
            Return Me._AppraisalFactors(index)
        Else
            Return Nothing
        End If
    End Function

    Public Property OverallAssessment As String
        Get
            Return Me._OverallAssessment
        End Get
        Set(value As String)
            Me._OverallAssessment = value
        End Set
    End Property

    Public Property TrainingRequirements As String
        Get
            Return Me._TrainingRequirements
        End Get
        Set(value As String)
            Me._TrainingRequirements = value
        End Set
    End Property

    Public Property AdditionalRemarks As String
        Get
            Return Me._AdditionalRemarks
        End Get
        Set(value As String)
            Me._AdditionalRemarks = value
        End Set
    End Property

    Public Property PromoteReemployWhen As String
        Get
            Return Me._PromoteReemployWhen
        End Get
        Set(value As String)
            Me._PromoteReemployWhen = value
        End Set
    End Property

    Public Property Promote As Boolean
        Get
            Return Me._Promote
        End Get
        Set(value As Boolean)
            Me._Promote = value
        End Set
    End Property

    Public Property Reemploy As Boolean
        Get
            Return Me._Reemploy
        End Get
        Set(value As Boolean)
            Me._Reemploy = value
        End Set
    End Property

    Public Property SafetyOperationsManager As String
        Get
            Return Me._SafetyOperationsManager
        End Get
        Set(value As String)
            Me._SafetyOperationsManager = value
        End Set
    End Property

    Public Property CommentFromOfficer2 As String
        Get
            Return Me._CommentFromOffice2
        End Get
        Set(value As String)
            Me._CommentFromOffice2 = value
        End Set
    End Property

    Public Property ShipFleetManager As String
        Get
            Return Me._ShipFleetManager
        End Get
        Set(value As String)
            Me._ShipFleetManager = value
        End Set
    End Property

    Public Property CommentFromOfficer1 As String
        Get
            Return Me._CommentFromOffice1
        End Get
        Set(value As String)
            Me._CommentFromOffice1 = value
        End Set
    End Property

    Public Property CommentDate As String
        Get
            Return Me._CommentDate
        End Get
        Set(value As String)
            Me._CommentDate = value
        End Set
    End Property

    Public Property AppraisalID As String
        Get
            Return Me._AppraisalID
        End Get
        Set(value As String)
            Me._AppraisalID = value
        End Set
    End Property

    Public Property FKeyIDNbr As String
        Get
            Return Me._FKeyIDNbr
        End Get
        Set(value As String)
            Me._FKeyIDNbr = value
        End Set
    End Property

    Public Property AppraisalDate As String
        Get
            Return Me._AppraisalDate
        End Get
        Set(value As String)
            Me._AppraisalDate = value
        End Set
    End Property

    Public Property FKeyActivityID As String
        Get
            Return Me._FKeyActivityID
        End Get
        Set(value As String)
            Me._FKeyActivityID = value
        End Set
    End Property

    Public Property Service As String
        Get
            Return Me._Service
        End Get
        Set(value As String)
            Me._Service = value
        End Set
    End Property

    Public Property OccasionForReport As String
        Get
            Return Me._OccasionForReport
        End Get
        Set(value As String)
            Me._OccasionForReport = value
        End Set
    End Property

    Public Property OverallScore As Double
        Get
            Return Me._OverallScore
        End Get
        Set(value As Double)
            Me._OverallScore = value
        End Set
    End Property

    Public Property Reemployed As Boolean
        Get
            Return Me._Reemployed
        End Get
        Set(value As Boolean)
            Me._Reemployed = value
        End Set
    End Property

    Public Property Promotion As Boolean
        Get
            Return Me._Promotion
        End Get
        Set(value As Boolean)
            Me._Promotion = value
        End Set
    End Property

    Public Property SailAgain As Boolean
        Get
            Return Me._SailAgain
        End Get
        Set(value As Boolean)
            Me._SailAgain = value
        End Set
    End Property

    Public Property Remarks As String
        Get
            Return Me._Remarks
        End Get
        Set(value As String)
            Me._Remarks = value
        End Set
    End Property

    Public Property Master As String
        Get
            Return Me._MasterName
        End Get
        Set(value As String)
            Me._MasterName = value
        End Set
    End Property

    Public Property ChiefOfficer As String
        Get
            Return Me._ChiefOfficerName
        End Get
        Set(value As String)
            Me._ChiefOfficerName = value
        End Set
    End Property

    Public Property Strength As String
        Get
            Return Me._Strength
        End Get
        Set(value As String)
            Me._Strength = value
        End Set
    End Property

    Public Property Weaknesses As String
        Get
            Return Me._Weaknesses
        End Get
        Set(value As String)
            Me._Weaknesses = value
        End Set
    End Property

    Public Property OfficerComment As String
        Get
            Return Me._OfficerComment
        End Get
        Set(value As String)
            Me._OfficerComment = value
        End Set
    End Property

    Public Property OfficerName As String
        Get
            Return Me._OfficerName
        End Get
        Set(value As String)
            Me._OfficerName = value
        End Set
    End Property

    Sub New()
        Me._AppraisalID = ""
        Me._FKeyIDNbr = ""
        Me._AppraisalDate = ""
        Me._FKeyActivityID = ""
        Me._Service = ""
        Me._OccasionForReport = ""
        Me._OverallScore = 0
        Me._Reemployed = False
        Me._Promotion = False
        Me._SailAgain = False
        Me._Remarks = ""
        Me._MasterName = ""
        Me._ChiefOfficerName = ""
        Me._ChiefEngineerName = ""
        Me._Strength = ""
        Me._Weaknesses = ""
        Me._OfficerComment = ""
        Me._OfficerName = ""
        Me._CommentDate = ""
        Me._CommentFromOffice1 = ""
        Me._ShipFleetManager = ""
        Me._CommentFromOffice2 = ""
        Me._SafetyOperationsManager = ""
        Me._Reemploy = False
        Me._Promote = False
        Me._PromoteReemployWhen = ""
        Me._AdditionalRemarks = ""
        Me._TrainingRequirements = ""
        Me._OverallAssessment = ""
    End Sub

End Class
