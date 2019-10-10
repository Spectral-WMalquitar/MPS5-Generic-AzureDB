Public Class CrewDetail

#Region "Crew Information"
    Private _IDNbr As String
    Public Property IDNbr() As String
        Get
            Return _IDNbr
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                _IDNbr = value
            End If
        End Set
    End Property

    Private _LName As String
    Public Property LName() As String
        Get
            Return _LName
        End Get
        Set(ByVal value As String)
            If Not IsNothing(value) Then
                _LName = value
            End If
        End Set
    End Property

    Private _FName As String
    Public Property FName() As String
        Get
            Return _FName
        End Get
        Set(ByVal value As String)
            _FName = value
        End Set
    End Property

    Private _MName As String = ""
    Public Property MName() As String
        Get
            Return _MName
        End Get
        Set(ByVal value As String)
            _MName = value
        End Set
    End Property

    Private _NickName As String
    Public Property NickName() As String
        Get
            Return _NickName
        End Get
        Set(ByVal value As String)
            _NickName = value
        End Set
    End Property


    Private _SexCode As Integer
    Public Property SexCode() As Integer
        Get
            Return _SexCode
        End Get
        Set(ByVal value As Integer)
            _SexCode = value
        End Set
    End Property

    Private _DOB As Date
    Public Property DOB() As Date
        Get
            Return _DOB
        End Get
        Set(ByVal value As Date)
            _DOB = value
        End Set
    End Property

    Private _POB As String
    Public Property POB() As String
        Get
            Return _POB
        End Get
        Set(ByVal value As String)
            _POB = value
        End Set
    End Property

    Private _COB As String
    Public Property COB() As String
        Get
            Return _COB
        End Get
        Set(ByVal value As String)
            _COB = value
        End Set
    End Property

    Private _Height As String
    Public Property Height() As String
        Get
            Return _Height
        End Get
        Set(ByVal value As String)
            _Height = value
        End Set
    End Property

    'Private Weight As String = ""
    Private _Weight As String
    Public Property Weight() As String
        Get
            Return _Weight
        End Get
        Set(ByVal value As String)
            _Weight = value
        End Set
    End Property

    'Private Blood As String = ""
    Private _Blood As String
    Public Property Blood() As String
        Get
            Return _Blood
        End Get
        Set(ByVal value As String)
            _Blood = value
        End Set
    End Property

    'Private NatCode As String = ""
    Private _NatCode As String
    Public Property NatCode() As String
        Get
            Return _NatCode
        End Get
        Set(ByVal value As String)
            _NatCode = value
        End Set
    End Property

    'Private TeleFax As String = ""
    Private _TeleFax As String
    Public Property TeleFax() As String
        Get
            Return _TeleFax
        End Get
        Set(ByVal value As String)
            _TeleFax = value
        End Set
    End Property

    'Private Email As String = ""
    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    'Private Phone As String = ""
    Private _Phone As String
    Public Property Phone() As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            _Phone = value
        End Set
    End Property

    'Private FKeyCivilStat As String = ""
    Private _FKeyCivilStat As String
    Public Property FKeyCivilStat() As String
        Get
            Return _FKeyCivilStat
        End Get
        Set(ByVal value As String)
            _FKeyCivilStat = value
        End Set
    End Property

    'Private Religion As String = ""
    Private _Religion As String
    Public Property Religion() As String
        Get
            Return _Religion
        End Get
        Set(ByVal value As String)
            _Religion = value
        End Set
    End Property

    'Private EmpTypeCode As String = ""
    Private _EmpTypeCode As String
    Public Property EmpTypeCode() As String
        Get
            Return _EmpTypeCode
        End Get
        Set(ByVal value As String)
            _EmpTypeCode = value
        End Set
    End Property

    'Private LangAblilityCode As String = ""
    Private _LangAblilityCode As String
    Public Property LangAblilityCode() As String
        Get
            Return _LangAblilityCode
        End Get
        Set(ByVal value As String)
            _LangAblilityCode = value
        End Set
    End Property

    'Private LangLevelCode As String = ""
    Private _LangLevelCode As String
    Public Property LangLevelCode() As String
        Get
            Return _LangLevelCode
        End Get
        Set(ByVal value As String)
            _LangLevelCode = value
        End Set
    End Property

    'Private HireStatCode As Integer = 0
    Private _HireStatCode As Integer
    Public Property HireStatCode() As Integer
        Get
            Return _HireStatCode
        End Get
        Set(ByVal value As Integer)
            _HireStatCode = value
        End Set
    End Property

    'Private PhotoPath As String = ""
    Private _PhotoPath As String
    Public Property PhotoPath() As String
        Get
            Return _PhotoPath
        End Get
        Set(ByVal value As String)
            _PhotoPath = value
        End Set
    End Property

    'Private DateUpdated As Date
    Private _DateUpdated As Date
    Public Property DateUpdated() As Date
        Get
            Return _DateUpdated
        End Get
        Set(ByVal value As Date)
            _DateUpdated = value
        End Set
    End Property

    'Private LastUpdatedBy As String
    Private _LastUpdatedBy As String
    Public Property LastUpdatedBy() As String
        Get
            Return _LastUpdatedBy
        End Get
        Set(ByVal value As String)
            _LastUpdatedBy = value
        End Set
    End Property

    'Private FKeyRank As String = ""
    Private _FKeyRank As String
    Public Property FKeyRank() As String
        Get
            Return _FKeyRank
        End Get
        Set(ByVal value As String)
            _FKeyRank = value
        End Set
    End Property

    '<!-- added by tony20171125
    'ShoeSize
    Private _ShoeSize As String
    Public Property ShoeSize() As String
        Get
            Return _ShoeSize
        End Get
        Set(ByVal value As String)
            _ShoeSize = value
        End Set
    End Property

    'CoverallSize
    Private _CoverallSize As String
    Public Property CoverallSize() As String
        Get
            Return _CoverallSize
        End Get
        Set(ByVal value As String)
            _CoverallSize = value
        End Set
    End Property

    'PoloSize
    Private _PoloSize As String
    Public Property PoloSize() As String
        Get
            Return _PoloSize
        End Get
        Set(ByVal value As String)
            _PoloSize = value
        End Set
    End Property

    'PantsSize
    Private _PantsSize As String
    Public Property PantsSize() As String
        Get
            Return _PantsSize
        End Get
        Set(ByVal value As String)
            _PantsSize = value
        End Set
    End Property

    '-->

    '<!-- added by tony20180505
    'HairColor
    Private _HairColor As String
    Public Property HairColor() As String
        Get
            Return _HairColor
        End Get
        Set(ByVal value As String)
            _HairColor = value
        End Set
    End Property

    'EyeColor
    Private _EyeColor As String
    Public Property EyeColor() As String
        Get
            Return _EyeColor
        End Get
        Set(ByVal value As String)
            _EyeColor = value
        End Set
    End Property

    'BMI
    Private _BMI As String
    Public Property BMI() As String
        Get
            Return _BMI
        End Get
        Set(ByVal value As String)
            _BMI = value
        End Set
    End Property
    '-->

#End Region

#Region "Activities"
    'Private RankName As String = "", RankCode As String = ""
    Private _RankName As String
    Public Property RankName() As String
        Get
            Return _RankName
        End Get
        Set(ByVal value As String)
            _RankName = value
        End Set
    End Property

    Private _RankCode As String
    Public Property RankCode() As String
        Get
            Return _RankCode
        End Get
        Set(ByVal value As String)
            _RankCode = value
        End Set
    End Property

    'Private ActGroupID As String = ""
    Private _ActGroupID As String
    Public Property ActGroupID() As String
        Get
            Return _ActGroupID
        End Get
        Set(ByVal value As String)
            _ActGroupID = value
        End Set
    End Property

    'Private ActID As String = ""
    Private _ActID As String
    Public Property ActID() As String
        Get
            Return _ActID
        End Get
        Set(ByVal value As String)
            _ActID = value
        End Set
    End Property

    'Private AgentName As String = "", AgentCode As String = ""
    Private _AgentName As String
    Public Property AgentName() As String
        Get
            Return _AgentName
        End Get
        Set(ByVal value As String)
            _AgentName = value
        End Set
    End Property

    Private _AgentCode As String
    Public Property AgentCode() As String
        Get
            Return _AgentCode
        End Get
        Set(ByVal value As String)
            _AgentCode = value
        End Set
    End Property

    'Private WScaleCode As String = "", WScaleRankCode As String = ""
    Private _WScaleCode As String
    Public Property WScaleCode() As String
        Get
            Return _WScaleCode
        End Get
        Set(ByVal value As String)
            _WScaleCode = value
        End Set
    End Property

    Private _WScaleRankCode As String
    Public Property WScaleRankCode() As String
        Get
            Return _WScaleRankCode
        End Get
        Set(ByVal value As String)
            _WScaleRankCode = value
        End Set
    End Property

    'Private StatName As String = "", StatCode As String = ""
    Private _StatName As String
    Public Property StatName() As String
        Get
            Return _StatName
        End Get
        Set(ByVal value As String)
            _StatName = value
        End Set
    End Property

    Private _StatCode As String
    Public Property StatCode() As String
        Get
            Return _StatCode
        End Get
        Set(ByVal value As String)
            _StatCode = value
        End Set
    End Property




#End Region

End Class
