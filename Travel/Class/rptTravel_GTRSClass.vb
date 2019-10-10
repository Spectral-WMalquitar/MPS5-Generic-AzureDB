Public Class rptTravel_GTRSClass

    Dim MainReport As New rptTravel_GTRS
    Dim repPrintTool As New DevExpress.XtraReports.UI.ReportPrintTool(MainReport)
    Dim dt As DataTable
    Dim cSQL As String

    Public Sub New(BookingPKey As String, isBookedWithGTravel As Boolean)
        cSQL = "SELECT		tb.TravelDate, tb.VslName VesselName, tb.PortName, tb.RefNo, tb.RequestType, tb.ETD, tb.ETAE, tb.ETAL, tb.NearestAirportName,  dbo.AssembleName(lname, fname, '', 1,1,0,0,0) as CrewName, FlightNumber, ClassOfService, Origin, OriginDesc, DepartureTime, Destination, DestinationDesc, ArrivalTime, FreeTxt as Remarks " & _
               "FROM		dbo.tblTravelBooking tb LEFT JOIN " & _
               "            dbo.tblTravelBookingCrew tbc ON tb.PKey = tbc.FKeyTravelBooking LEFT JOIN " & _
               IIf(isBookedWithGTravel, _
                   "            dbo.tblTravelBookingDetail det ON det.PassengerID = tbc.PassengerID AND det.FKeyTravelBooking = tbc.FKeyTravelBooking ", _
                   "            dbo.tblTravelBookingDetail det ON det.FKeyCrew = tbc.FKeyCrew AND det.FKeyTravelBooking = tbc.FKeyTravelBooking ") & _
               "WHERE       tb.pkey = '" & BookingPKey & "' AND isnull(det.iscanceled,0) = 0"

        dt = MPSDB.CreateTable(cSQL)
        If Not validateReportDataSource(dt, False) Then Exit Sub

        MainReport.DataSource = dt
        SetDefaultReportLabels(MainReport, MPSDB)
        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        With MainReport
            BindData(.celTravelDate, "Text", Nothing, "TravelDate", "{0:dd-MMM-yyyy hh:mm tt}")
            BindData(.celVessel, "Text", Nothing, "VesselName")

            BindData(.celPort, "Text", Nothing, "PortName")

            BindData(.celRefNo, "Text", Nothing, "RefNo")
            BindData(.celRequestType, "Text", Nothing, "RequestType")
            BindData(.celETD, "Text", Nothing, "ETD", "{0:dd-MMM-yyyy hh:mm tt}")
            BindData(.celETAE, "Text", Nothing, "ETAE", "{0:dd-MMM-yyyy hh:mm tt}")
            BindData(.celETAL, "Text", Nothing, "ETAL", "{0:dd-MMM-yyyy hh:mm tt}")
            BindData(.celNearestAirport, "Text", Nothing, "NearestAirportName")

            BindData(.celDepartureTime, "Text", Nothing, "DepartureTime", "{0:dd-MMM-yyyy hh:mm tt}")
            BindData(.celArrivalTime, "Text", Nothing, "ArrivalTime", "{0:dd-MMM-yyyy hh:mm tt}")


            BindData(.celCrewName, "Text", Nothing, "CrewName")
            BindData(.celFlightNumber, "Text", Nothing, "FlightNumber")
            BindData(.celClassOfService, "Text", Nothing, "ClassOfService")
            BindData(.celDepartureTime, "Text", Nothing, "DepartureTime", "{0:dd-MMM-yyyy}")
            BindData(.celOrigin, "Text", Nothing, "Origin")
            BindData(.celOriginDesc, "Text", Nothing, "OriginDesc")
            BindData(.celArrivalTime, "Text", Nothing, "ArrivalTime", "{0:dd-MMM-yyyy}")
            BindData(.celDestination, "Text", Nothing, "Destination")
            BindData(.celDestinationDesc, "Text", Nothing, "DestinationDesc")
            BindData(.celRemarks, "Text", Nothing, "Remarks", "")
        End With

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader, "PKey", FieldSortOrder.None)
        MainReport.Detail.SortFields.Add(New DevExpress.XtraReports.UI.GroupField("CrewName"))
        MainReport.Detail.SortFields("CrewName").SortOrder = DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending
        MainReport.Detail.SortFields.Add(New DevExpress.XtraReports.UI.GroupField("DepartureTime"))
        MainReport.Detail.SortFields("DepartureTime").SortOrder = DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending

    End Sub

    Public Sub showPreview()
        If MainReport.RowCount = 0 Then
            'edited by tony20170929 MsgBox("Unable to generate report source.", vbExclamation)
            MsgBox("Report has no data.", MsgBoxStyle.Information)
        Else
            repPrintTool.ShowPreviewDialog()
        End If
    End Sub
End Class
