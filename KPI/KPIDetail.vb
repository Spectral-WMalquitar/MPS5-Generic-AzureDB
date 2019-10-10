Imports MPS4
Imports Utilities

Public Class KPIDetail
#Region "Properties"
    'REMINDER!! EVERYTIME YOU ADD A PROPERTY HERE MAKE SURE YOU ADD IT ON THE KPI.REFRESHKPIDETAIL PROCEDURE, IF APPLICABLE
    'KPICode
    Public KPICode As String

    'Name
    Public Name As String

    'KPITypeName
    Public KPITypeCode As String

    'KPITypeName
    Public KPITypeName As String

    'Title
    Public Title As New KPITitle

    'DataSource Condition
    Public DataSourceCondition As String

    'Auto Email Report Condition
    Public AutoEmailReportCondition As String

    Public AxisLabel As New KPISeriesAxis

    'ChartView
    Public ChartView As KPI.ChartView

    'Period
    Public Period As String

    'KPI Description
    Public ReadOnly Property KPIDescription() As String
        Get
            Dim retval = ""

            Try
                'MPSDB.BeginReader("SELECT * FROM dbo.tblkpi WHERE PKey = '" & _KPICode & "'")
                MPSDB.BeginReader("SELECT * FROM dbo.tblkpi WHERE PKey = '" & KPICode & "'")
                While MPSDB.Read()
                    retval = MPSDB.ReaderItem("Description")
                End While
                MPSDB.CloseReader()
            Catch ex As Exception
                'do nothing
                'should return empty string
            End Try

            Return retval
        End Get
    End Property

    'Period Name
    Public ReadOnly Property PeriodName() As String
        Get
            Dim retval = ""

            Try
                'MPSDB.BeginReader("SELECT * FROM dbo.tbladmkpiperiod WHERE PKey = '" & _Period & "'")
                MPSDB.BeginReader("SELECT * FROM dbo.tbladmkpiperiod WHERE PKey = '" & Period & "'")
                While MPSDB.Read()
                    retval = MPSDB.ReaderItem("Name")
                End While
                MPSDB.CloseReader()
            Catch ex As Exception
                'do nothing
                'should return empty string
            End Try

            Return retval
        End Get
    End Property

    'Measurement Unit
    Public ReadOnly Property MeasurementUnit() As String
        Get
            Dim retval = ""

            Try
                MPSDB.BeginReader("SELECT unit.name [MeasurementUnit] FROM dbo.tblkpi kpi LEFT JOIN dbo.tbladmkpiunit unit ON kpi.fkeyunit = unit.pkey WHERE kpi.PKey = '" & KPICode & "'")
                While MPSDB.Read()
                    retval = MPSDB.ReaderItem("MeasurementUnit")
                End While
                MPSDB.CloseReader()
            Catch ex As Exception
                'do nothing
                'should return empty string
            End Try

            Return retval
        End Get
    End Property


    'Date Coverage
    Public DateCoverage As New DateCoverageClass

    'Stored Procedure Name
    Public StoredProcedureName As String
    
    'Selection Listing
    Public SelectionListing As String

    'MultiSelection
    Public MultiSelection As Boolean

    'DefaultChartView
    Public DefaultChartView As KPI.ChartView
    
    'AllowedChartViewList
    Public AllowedChartViewList As ArrayList
    
    'MinReq
    Public MinReq As Object

    'Target
    Public Target As Object
    
    'MainTitleToDisplay
    Public ReadOnly Property SubTitleToDisplay() As String
        Get
            Dim retval As String = ""

            If Target.ToString <> "0" And MinReq.ToString <> "0" Then
                If Target.ToString.Length > 0 Then
                    retval = "Target = " & Target
                End If

                If MinReq.ToString.Length > 0 Then
                    retval = retval & IIf(retval.Length > 0, " ; ", "") & _
                                "Min. Required = " & MinReq
                End If
            End If

            If Title.SubTitle.ToString.Length > 0 Then
                retval = Title.SubTitle
            End If
            Return retval
        End Get

    End Property

    'NeedDateCoverage
    Public NeedDateCoverage As Boolean

    'UsePercentInPieChartView
    Public UsePercentInPieChartView As Boolean

    'Formula
    Public Formula As New FormulaClass

    'Color Palette
    Public ColorPalette As String

    'FilterOption
    Public FilterOption As BaseFilterOption

    'AutoEmail
    Public AutoEmail As New AutoEmailClass

    'Result
    Public Result As New ResultStructure
    Public Structure ResultStructure
        Public SelectionListing As String
        Public DateCoverageType As String
    End Structure

#End Region
#Region "Classes"
    Public Class DateCoverageClass
        Public Type As String = Nothing
        Public Period As New DateRangePeriod
        Public DateAsOf As Date = Nothing
    End Class

    Public Class FormulaClass
        Public FormulaString As String = Nothing
        Public FormulaImage As Byte() = Nothing
    End Class

    Public Class KPITitle
        Public MainTitle As String = ""
        Public SubTitle As String = ""
        Public FooterNote As String = ""
    End Class

    Public Class KPISeriesAxis
        Public AxisXLabel As String = ""
        Public AxisYLabel As String = ""
    End Class
#End Region
End Class
