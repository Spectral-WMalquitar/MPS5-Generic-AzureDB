Imports DevExpress.XtraReports.UI

Public Class ExpDoc_All
    Public MainReport As New rptExpDoc_All

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

        BindData(MainReport.celCrewName, "Text", Nothing, "CrewName")
        BindData(MainReport.celDocType, "Text", Nothing, "DocType")
        BindData(MainReport.celDocGrp, "Text", Nothing, "DocType")
        BindData(MainReport.celDocName, "Text", Nothing, "DocName")
        BindData(MainReport.celDocNumber, "Text", Nothing, "DocNum")
        BindData(MainReport.celDateIssue, "Text", Nothing, "DocStart", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celDateExpiry, "Text", Nothing, "DocEnd", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celRem, "Text", Nothing, "Remarks")

        sortDetail(dt.DefaultView.Sort)

        MainReport.GroupHeader2.GroupFields.Add(New GroupField("CrewName"))
        'MainReport.GroupHeader1.GroupFields.Add(New GroupField("DocType"))
        MainReport.GroupHeader1.Visible = False

        MainReport.ShowPreviewDialog()
    End Sub

    Private Sub sortDetail(sort As String)
        Dim fieldName As String = ""
        Dim sortOrder As XRColumnSortOrder
        Dim gss As New DevExpress.XtraReports.UI.XRGroupSortingSummary

        If sort.Length = 0 Then Exit Sub

        For Each iSort As String In sort.Split(",")
            If iSort.EndsWith("ASC") Then
                fieldName = iSort.Replace(" ASC", "")
                sortOrder = XRColumnSortOrder.Ascending
            Else
                fieldName = iSort.Replace(" DESC", "")
                sortOrder = XRColumnSortOrder.Descending
            End If

            gss.Enabled = True
            gss.FieldName = fieldName
            gss.Function = IIf(sortOrder = XRColumnSortOrder.Ascending, SortingSummaryFunction.Min, SortingSummaryFunction.Max)
            gss.SortOrder = sortOrder
            MainReport.GroupHeader1.SortingSummary = gss
        Next
    End Sub
End Class
