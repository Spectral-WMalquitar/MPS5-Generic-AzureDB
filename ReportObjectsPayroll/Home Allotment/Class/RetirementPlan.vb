Public Class RetirementPlan
    Public MainReport As New rptRetirementPlan

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE        
        cSQL = "SELECT * FROM Rpt_RetirementPlan "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------
        SetDefaultReportLabels(MainReport, REPORT_DETAIL.DB)

        With MainReport
            .DataSource = dt

            .celCompany.Text = MPS4.MPSDB.GetConfig("Name").ToUpper
            BindData(.celVslName, "Text", Nothing, "VslName")

            BindData(.celRank, "Text", Nothing, "RankName")
            BindData(.celCrewName, "Text", Nothing, "CrewName")
            BindData(.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
            BindData(.celEmbark, "Text", Nothing, "Embark", "{0:dd-MMM-yyyy}")
            BindData(.celDisEmbark, "Text", Nothing, "Disembark", "{0:dd-MMM-yyyy}")
            BindData(.celBasic, "Text", Nothing, "BasicAmount", "{0:#,##0.00}")
            BindData(.celAmount, "Text", Nothing, "PFAmount", "{0:#,##0.00}")
            BindData(.celTotalBasic, "Text", Nothing, "BasicAmount", "{0:#,##0.00}")
            BindData(.celTotalAmount, "Text", Nothing, "PFAmount", "{0:#,##0.00}")

            AddFieldsToGroupHeaderBand(.GroupHeader1, "MCode", REPORT_DETAIL.SortOption.GetSortValueCode("MCode"))
            AddFieldsToGroupHeaderBand(.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))

            AddSortFieldsToDetailBandFromDT(.Detail, REPORT_DETAIL.SortOption.SortDataSource)

            AddHandler .celPeriodDesc.BeforePrint, AddressOf cel_BeforePrint
            AddHandler .celNbr.BeforePrint, AddressOf cel_BeforePrint
            AddHandler .celDisEmbark.BeforePrint, AddressOf cel_BeforePrint

            .celPreparedName.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Prepared By", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToString.ToUpper
            .celPreparedPos.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Prepared By").ToString.ToUpper
            .celApprovedName.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Approved By", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToString.ToUpper
            .celApprovedPos.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Approved By").ToString.ToUpper

        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

    End Sub

    Private Sub cel_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim cel As DevExpress.XtraReports.UI.XRTableCell = sender
        Dim disembark As String = ""

        If cel.Name = MainReport.celPeriodDesc.Name Then
            'cel.Text = cel.Text.Replace("[MMMMYYYY]", Format(Utilities.Util.NumCodeToDate(cel.Report.GetCurrentColumnValue("MCode"), 1), "MMMM yyyy").ToUpper)
            cel.Text = "FOR THE MONTH OF " & Format(Utilities.Util.NumCodeToDate(cel.Report.GetCurrentColumnValue("MCode"), 1), "MMMM yyyy").ToUpper

        ElseIf cel.Name = MainReport.celNbr.Name Then
            disembark = IIf(IsDBNull(cel.Report.GetCurrentColumnValue("Disembark")), "", cel.Report.GetCurrentColumnValue("Disembark"))
            If Not (disembark = "") Then
                If CDate(disembark) = cel.Report.GetCurrentColumnValue("Disembark") Then
                    cel.Text = "OFF"
                End If
            End If

        ElseIf cel.Name = MainReport.celDisEmbark.Name Then
            Dim mcode As Integer = IIf(IsDBNull(cel.Report.GetCurrentColumnValue("MCode")), Nothing, cel.Report.GetCurrentColumnValue("MCode"))
            disembark = IIf(IsDBNull(cel.Report.GetCurrentColumnValue("Disembark")), Nothing, cel.Report.GetCurrentColumnValue("Disembark"))

            If IsNothing(disembark) Then
                cel.Text = ""
            Else
                If mcode = Utilities.Util.DateToNumCode(disembark) Then
                    cel.Text = Format(disembark, "dd-MMM-yyyy")
                Else
                    cel.Text = ""
                End If
            End If

        End If


    End Sub


End Class
