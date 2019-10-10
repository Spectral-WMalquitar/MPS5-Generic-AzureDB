Imports Utilities
Imports MPS4

Public Class SECIDForm
    Public MainReport As New rptSECIDForm_pg1

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        'cSQL = "SELECT * FROM rpt_SECIDForm where IDNBr in " & WhereList
        cSQL = "SELECT * FROM rpt_SECIDForm "

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

        BindData(MainReport.txtWorkName, "Text", Nothing, "Crew")
        BindData(MainReport.txtLName, "Text", Nothing, "LName")
        BindData(MainReport.txtFName, "Text", Nothing, "FName")
        BindData(MainReport.txtMName, "Text", Nothing, "MName")
        BindData(MainReport.txtSRCNo, "Text", Nothing, "SRC_No")
        '!!!!!! BindData(MainReport.txtMotherMaidenName, "Text", Nothing, "00000")
        BindData(MainReport.txtPrintedName, "Text", Nothing, "Crew")
        '!!!!!! BindData(MainReport.txtOFWIDNo, "Text", Nothing, "00000")
        '!!!!!! BindData(MainReport.txtVENo, "Text", Nothing, "00000")

        BindData(MainReport.txtBirthday, "Text", Nothing, "DOB")
        BindData(MainReport.txtSex, "Text", Nothing, "SexCode")
        BindData(MainReport.txtCivilStat, "Text", Nothing, "FKeyCivilStat")

        REPORT_DETAIL.MainReport = MainReport
    End Sub
End Class
