Imports Reports

Public Class CrewList_IMO_Sgp
    Public MainReport As New rptCrewList_IMO_Sgp

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String

        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT *, Left(Gender,1) Sex FROM rpt_CrewList_IMO "

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

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        MainReport.celLoc.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Location")
        MainReport.celAgent.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Agent")
        Try
            MainReport.celDateArr.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Date of Arrival")
            MainReport.celDateArr2.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Date of Arrival")
        Catch ex As Exception
            MainReport.celDateArr.Text = ""
        End Try
        Try
            MainReport.celDateToDep.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Proposed Departure Date")
        Catch ex As Exception
            MainReport.celDateArr.Text = ""
        End Try
        MainReport.celLastPort.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Last Port")
        MainReport.celNextPort.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Next Port")

        BindData(MainReport.celVslGRT, "Text", Nothing, "GrossTon")
        BindData(MainReport.celVslNRT, "Text", Nothing, "NetTon")
        BindData(MainReport.celVslNat, "Text", Nothing, "VslNat")
        BindData(MainReport.celVslCall, "Text", Nothing, "CallSign")
        BindData(MainReport.celVslType, "Text", Nothing, "VslType")
        BindData(MainReport.celVslPhone, "Text", Nothing, "VslPhone")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celVslOwner, "Text", Nothing, "VslOwner")
        BindData(MainReport.celCrewName, "Text", Nothing, "Crew")
        BindData(MainReport.celSex, "Text", Nothing, "Sex")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celNat, "Text", Nothing, "Nat")
        BindData(MainReport.celDocNum, "Text", Nothing, "PPortNbr")
        BindData(MainReport.celDocExp, "Text", Nothing, "PPortExp", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, "VslName", REPORT_DETAIL.SortOption.GetSortValueCode("VslName"))
        AddSortFieldsToDetailBandFromDT(MainReport.Detail, REPORT_DETAIL.SortOption.SortDataSource)

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
