Imports Utilities
Imports MPS4

Public Class AllotSlip
    Public MainReport As New rptAllotSlip

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        cSQL = "SELECT * FROM rpt_AllotSlip "

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

        MainReport.celCompany.Text = MPS4.MPSDB.GetConfig("Name").ToUpper
        MainReport.celCompanyBot.Text = MPS4.MPSDB.GetConfig("Name").ToUpper

        MainReport.celMaster.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Master")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celCrew, "Text", Nothing, "Crew")
        BindData(MainReport.celCrewBot, "Text", Nothing, "Crew")
        BindData(MainReport.celRank, "Text", Nothing, "RankName")
        BindData(MainReport.celDateDep, "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celGuaranteed, "Text", Nothing, "Guaranteed")
        BindData(MainReport.celBasic, "Text", Nothing, "Basic")
        BindData(MainReport.celAllotDate, "Text", Nothing, "AllotDate", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celTIN, "Text", Nothing, "TIN")
        BindData(MainReport.celOTRate, "Text", Nothing, "OTRate")
        BindData(MainReport.celAmount, "Text", Nothing, "OTAmt")
        BindData(MainReport.celSSS, "Text", Nothing, "SSS")

        BindData(MainReport.celAllottee, "Text", Nothing, "Allottee")
        BindData(MainReport.celAllotRel, "Text", Nothing, "AllotRel")
        BindData(MainReport.celAllotAddr, "Text", Nothing, "AllotAddr")
        BindData(MainReport.celBankName, "Text", Nothing, "BankBranchName")
        BindData(MainReport.celBranchAddr, "Text", Nothing, "BranchAddr")
        BindData(MainReport.celAllotAcct, "Text", Nothing, "AllotAcct")
        BindData(MainReport.celAllotAmount, "Text", Nothing, "AllotAmt")

        AddFieldsToGroupHeaderBand(MainReport.GroupHeader1, REPORT_DETAIL.SortOption.SortDataSource)
        
        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub
End Class
