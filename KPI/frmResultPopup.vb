Public Class frmResultPopup 

    Private Sub btnClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        Me.Close()
    End Sub

    Private Sub btnPrintChart_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrintChart.ItemClick
        Dim MainReport As clsRptKPI = Nothing

        Reports.OpenReportWaitForm()
        ShowKPIResultPopupForms(ResultPopupFormShowMode.HideAll)

        Try
            MainReport = New clsRptKPI(CType(Me.PanelControl_Chart.Controls("MainChart"), DevExpress.XtraCharts.ChartControl))
        Catch ex As Exception
            'do nothing
        End Try

        If Not MainReport Is Nothing Then
            MainReport.OpenReport()
        Else
            MsgBox("Unable to open print chart result.", MsgBoxStyle.Exclamation)
        End If

        ShowKPIResultPopupForms(ResultPopupFormShowMode.ShowAll)
        Reports.CloseReportWaitForm()
    End Sub
End Class