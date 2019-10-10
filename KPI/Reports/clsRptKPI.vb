Imports Reports
Imports DevExpress.XtraReports.UI

Public Class clsRptKPI

    Public ReadOnly Property ReportObject
        Get
            Return MainReport
        End Get
    End Property

    Dim MainReport As New rptKPI

    Public Sub New(ByVal oChartControl As DevExpress.XtraCharts.ChartControl, Optional ByVal bOpenReport As Boolean = False)

        ''CHART
        If oChartControl Is Nothing Then
            MsgBox("Unable to print chart as report.", vbExclamation)
            Exit Sub
        End If

        CType(oChartControl, DevExpress.XtraCharts.Native.IChartContainer).Chart.DataSnapshot()
        MainReport.xrMainChart.Chart.Assign(CType(oChartControl, DevExpress.XtraCharts.Native.IChartContainer).Chart)

        ''HEADER
        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)
        
        SetDefaultReportLabels(MainReport, MPS4.MPSDB)

        If bOpenReport Then MainReport.ShowPreviewDialog()

    End Sub

    Public Sub OpenReport()
        MainReport.ShowPreviewDialog()
    End Sub

End Class
