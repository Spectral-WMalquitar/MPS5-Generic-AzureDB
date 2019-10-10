Public Class CrewFlightReq

    Dim MainReport As New rptCrewFlightReq
    Dim repPrintTool As New DevExpress.XtraReports.UI.ReportPrintTool(MainReport)
    Dim dt As DataTable
    Dim cSQL As String

    Public Sub New(ByVal db As SQLDB, recID As String, type As String)

        If type = "Joining" Then

            cSQL = "SELECT main.*, planEvent.Vessel AS Vessel FROM Rpt_CrewFlightReq AS main LEFT OUTER JOIN " & _
                    " dbo.tblPlanningEvent AS planEvent ON main.PKey = planEvent.PKey WHERE main.PKey='" & recID & "'"

            MainReport.descSignOnOff.Text = "Place Sign-on"
            MainReport.descDateReq.Text = "Requested Arrival Date"
        Else

            cSQL = "SELECT main.*, aVsl.Name AS Vessel FROM Rpt_CrewFlightReq AS main LEFT OUTER JOIN " & _
                    " dbo.tblAdmVsl AS aVsl ON main.PKey = aVsl.PKey WHERE main.PKey='" & recID & "'"

            MainReport.descSignOnOff.Text = "Place Sign-off"
            MainReport.descDateReq.Text = "Requested Departure Date"
        End If

        dt = MPSDB.CreateTable(cSQL)

        MainReport.DataSource = dt

        With MainReport
            BindData(.celTravAgent, "Text", Nothing, "TravelAgent")
            BindData(.celContact, "Text", Nothing, "Contact")

            BindData(.celVslName, "Text", Nothing, "Vessel")

            BindData(.celSignOnOff, "Text", Nothing, "PlaceSign")
            BindData(.celDepPlace, "Text", Nothing, "PlaceDep")
            BindData(.celArrPlace, "Text", Nothing, "ArrPlace")
            BindData(.celDateReq, "Text", Nothing, "DateReq", "{0:dd-MMM-yyyy}")
            BindData(.celPortAgent, "Text", Nothing, "PortAgent")

            BindData(.celCrew, "Text", Nothing, "Crew")
            BindData(.celRank, "Text", Nothing, "Rank")
            BindData(.celNat, "Text", Nothing, "Nat")
            BindData(.celPPNum, "Text", Nothing, "PPNum")
            BindData(.celPPExp, "Text", Nothing, "PPExp", "{0:dd-MMM-yyyy}")
        End With


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
