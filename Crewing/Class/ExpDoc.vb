Imports DevExpress.XtraReports.UI

Public Class ExpDoc
    Public MainReport As New rptExpDoc

    Public Sub New(dt As DataTable)
        MainReport.DataSource = dt

        MainReport.subHeader.ReportSource = New Reports.rptHeader(MainReport)

        Dim view As New DataView(dt)
        If view.ToTable(True, "hasExpDoc").Rows.Count > 1 Then
            MainReport.lblTitle.Text = "EXPIRING/EXPIRED DOCUMENTS"
        Else
            If view.ToTable(True, "hasExpDoc").Rows(0).Item(0) = 1 Then
                MainReport.lblTitle.Text = "EXPIRED DOCUMENTS"
            Else
                MainReport.lblTitle.Text = "EXPIRING DOCUMENTS"
            End If
        End If
        SetDefaultReportLabels(MainReport, MPSDB)

        MainReport.celDocType.Text = dt.TableName
        BindData(MainReport.celCrewName, "Text", Nothing, "CrewName")
        BindData(MainReport.celDocName, "Text", Nothing, "DocName")
        BindData(MainReport.celDocNumber, "Text", Nothing, "DocNum")
        BindData(MainReport.celDateIssue, "Text", Nothing, "DocStart", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateExpiry, "Text", Nothing, "DocEnd", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celRem, "Text", Nothing, "Remarks")

        If dt.TableName.ToLower = "training" Then
            MainReport.celStart.Text = "Date Start"
            MainReport.celEnd.Text = "Date End"
        Else
            MainReport.celStart.Text = "Date Issue"
            MainReport.celEnd.Text = "Date Expiry"
        End If
        'sda
        MainReport.ShowPreviewDialog()
    End Sub
End Class
