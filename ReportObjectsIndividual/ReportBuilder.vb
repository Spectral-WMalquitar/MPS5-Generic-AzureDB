Imports MPS4
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
'Imports System.Windows.Forms
Imports Reports.ReportSelection

Public Class ReportBuilder
    Inherits Reports.BaseReportBuilder

    'Private ReportSelection As New Reports.ReportSelection

    Public Overrides Function BuildData() As String
        'MyBase.BuildData()
        Dim cSQL As String

        'to get a value from the filter, use GetFilterValue("Rank")
        Select Case ReportName
            Case "Report #1"
                cSQL = ""

            Case "Report #2"
                cSQL = ""

            Case Else
                cSQL = ""
        End Select

        Return cSQL

    End Function

    Public Overrides Function AssembleReport() As Boolean
        Return MyBase.AssembleReport()
    End Function

    Public Overrides Function ArrangeDataSource() As String
        'Return MyBase.ArrangeDataSource()
        BuildData()
        Return ""
    End Function

    Public Overrides Sub ShowReport()
        MyBase.ShowReport()
    End Sub
End Class
