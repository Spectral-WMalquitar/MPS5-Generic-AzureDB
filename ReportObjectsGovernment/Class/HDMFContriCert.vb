
Public Class HDMFContriCert
    Public MainReport As New rptHDMFContriCert
    Public SubRepHeader As New rptHeader


    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim cSQL As String
        Dim dt As DataTable

        cSQL = "EXEC SP_Pay_HDMF_Contri_cert @IDNBR = '" & Replace(WhereList, "'", "") & "'"
        dt = MPSDB.CreateTable(cSQL)
        MainReport.DataSource = dt

        'If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        If Not dt Is Nothing Then
            If dt.Rows.Count = 0 Then
                MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
                Exit Sub
            End If
        Else
            MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
            Exit Sub
        End If
        'paragraph = "	This is to certify that EPSILON MARITIME SERVICES, INC with SSS No. 03-9158194-0" & _
        '            "has remitted the following SSS Contribution for MR. AARON, LEO AARON, one of our" & _
        '            "crewmembers, with SSS No. 07-2081234-5 who was onboard the Vessel ELIXIR from 2/13/2016" & _
        '            "to 8/31/2016."

        With MainReport
            BindData(.txtCrew, "Text", Nothing, "CrewName")
            BindData(.txtCrewLName, "Text", Nothing, "LName")
            BindData(.txtPeriod, "Text", Nothing, "MCodeYear")
            BindData(.txtTotalContri, "Text", Nothing, "Amt", "{0:#,##0.00}")
            BindData(.txtPeriodCover, "Text", Nothing, "MCode")
            BindData(.txtCrewHDMFNo, "Text", Nothing, "HDMFno")
            BindData(.txtReceiptNo, "Text", Nothing, "ReceiptNumber")
            BindData(.txtDatePaid, "Text", Nothing, "DatePaid", "{0:MM/dd/yyyy}")

            'SIGNATORY
            With REPORT_DETAIL.FilterOption
                MainReport.celSignatoryName.Text = .GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue)
                MainReport.celSignatoryPos.Text = .GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue)
                MainReport.Reason = .GetFilterValue("Reason", BaseFilterOption.GetFilterReturnWhat.DisplayValue)
            End With

            AddFieldsToGroupHeaderBand(MainReport.grpSBRNum, "ReceiptNumber", FieldSortOrder.Descending)
            AddFieldsToGroupHeaderBand(MainReport.grpCrew, "CrewName", FieldSortOrder.Descending)
            AddFieldsToGroupHeaderBand(MainReport.grpPeriod, "MCodeYear", FieldSortOrder.Ascending)

            .SubHeader.ReportSource = SubRepHeader
        End With

        'With SubRepHeader
        '    .XrPictureBox1.Image = New System.Drawing.Bitmap(Trim(MPSDB.GetConfig("LOGOPATH")))
        'End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
