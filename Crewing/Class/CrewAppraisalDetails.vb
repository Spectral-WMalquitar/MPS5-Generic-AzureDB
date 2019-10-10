Public Class CrewAppraisalDetails

    Private _AppraisalID As String
    Private _AppraisalFactorID As String
    Private _AppraisalComment As String
    Private _AppraisalGrade As String
    Private _AppraisalGroup As String
    Private _AppraisalFactorName As String

    Sub New()
        Me._AppraisalID = ""
        Me._AppraisalFactorID = ""
        Me._AppraisalComment = ""
        Me._AppraisalGrade = ""
        Me._AppraisalGroup = ""
        Me._AppraisalFactorName = ""
    End Sub

    Public Property AppraisalFactorName As String
        Get
            Return Me._AppraisalFactorName
        End Get
        Set(value As String)
            Me._AppraisalFactorName = value
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

    Public Property AppraisalFactorID As String
        Get
            Return Me._AppraisalFactorID
        End Get
        Set(value As String)
            Me._AppraisalFactorID = value
        End Set
    End Property

    Public Property AppraisalComment As String
        Get
            Return Me._AppraisalComment
        End Get
        Set(value As String)
            Me._AppraisalComment = value
        End Set
    End Property

    Public Property AppraisalGrade As String
        Get
            Return Me._AppraisalGrade
        End Get
        Set(value As String)
            If value.Trim().Equals("") Then
                Me._AppraisalGrade = "0"
            Else
                Me._AppraisalGrade = value
            End If
        End Set
    End Property

    Public Property AppraisalGroup As String
        Get
            Return Me._AppraisalGroup
        End Get
        Set(value As String)
            Me._AppraisalGroup = value
        End Set
    End Property

End Class
