Public Class CrewTravelEvent

    Dim MainReport As New rptCrewTravelEvent
    Dim repPrintTool As New DevExpress.XtraReports.UI.ReportPrintTool(MainReport)
    Dim dt As DataTable
    Dim cSQL As String

    Public Sub New(ByVal db As SQLDB, recID As String)
        cSQL = "SELECT * FROM Rpt_CrewTravelEvent WHERE PKey='" & recID & "'"
        dt = MPSDB.CreateTable(cSQL)

        MainReport.DataSource = dt
        MainReport.celCompanyName.Text = db.GetConfig("Name")
        MainReport.celDatePrinted.Text = Format(Now, "dd-MMM-yyyy").ToString
        BindData(MainReport.celTravAgent, "Text", Nothing, "TravelAgent")
        BindData(MainReport.celAddr, "Text", Nothing, "Addr")
        BindData(MainReport.celContact, "Text", Nothing, "Contact")
        MainReport.celRptBody.Text = MainReport.celRptBody.Text.Replace("<StartPoint>", dt.Rows(0).Item("StartPoint"))

        BindData(MainReport.celCrewCnt, "Text", Nothing, "Crew")
        BindData(MainReport.celCrew, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")

        BindData(MainReport.celFlightCnt, "Text", Nothing, "RefNo")
        BindData(MainReport.celRefNo, "Text", Nothing, "RefNo")
        BindData(MainReport.celFlightFrom, "Text", Nothing, "FlightFrom")
        BindData(MainReport.celETD, "Text", Nothing, "ETD", "{0:dd-MMM-yyyy HH:mm}")
        BindData(MainReport.celFlightTo, "Text", Nothing, "FlightTo")
        BindData(MainReport.celETA, "Text", Nothing, "ETA", "{0:dd-MMM-yyyy HH:mm}")

        LoadDetailReport(MainReport.DetailReport_Crew, "SELECT * FROM Rpt_CrewTravelEvent_CrewList")
        LoadDetailReport(MainReport.DetailReport_Flight, "SELECT * FROM Rpt_CrewTravelEvent_FlightDetails")


    End Sub

    Public Sub showPreview()
        If MainReport.RowCount = 0 Then
            MsgBox("Unable to generate report source.", vbExclamation)
        Else
            repPrintTool.ShowPreviewDialog()
        End If
    End Sub

    Private Sub LoadDetailReport(sender As System.Object, sql As String)
        Dim dt_sub As DataTable
        Dim detailReport As DevExpress.XtraReports.UI.DetailReportBand
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        dt_sub = MPSDB.CreateTable(sql)
        detailReport.DataSource = dt_sub
        AddHandler detailReport.BeforePrint, AddressOf SetDetailReport_BeforePrint
    End Sub

    Private Sub SetDetailReport_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim detailReport As DevExpress.XtraReports.UI.DetailReportBand
        detailReport = TryCast(sender, DevExpress.XtraReports.UI.DetailReportBand)
        detailReport.FilterString = "FKey='" & MainReport.GetCurrentColumnValue("PKey").ToString & "'"
        If detailReport.RowCount = 0 Then
            detailReport.Visible = False
        End If
    End Sub
End Class
