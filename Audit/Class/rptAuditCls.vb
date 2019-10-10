'Imports DevExpress.XtraReports.UI.ReportPrintTool
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports
'Imports DevExpress.XtraReports.UI.XtraReportExtensions

Public Class rptAuditCls
    Dim MainReport As New rptAudit
    'Dim childReport As New rptAudit_sub
    Dim repPrintTool As New DevExpress.XtraReports.UI.ReportPrintTool(MainReport)
    Dim dt As DataTable
    Dim cSQL As String

    Public Sub New(parentDt As DataTable, Optional childDt As DataTable = Nothing)

        If Not parentDt Is Nothing Then
            If parentDt.Rows.Count = 0 Then
                MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
                Exit Sub
            End If
        Else
            MsgBox("Report has no data. If you have not tried yet, select much specific or fewer records.", vbExclamation, GetAppName() & " Reports")
            Exit Sub
        End If

        'Dim MainReport As New rptAudit, SubRepHeader

        If Not childDt Is Nothing Then

        Else

        End If

        dt = parentDt 'MPSDB.CreateTable(cSQL)

        MainReport.DataSource = dt

        With MainReport
            Reports.basReports.BindData(.celSeamanID, "Text", Nothing, "CrewID")
            Reports.basReports.BindData(.celSeamanName, "Text", Nothing, "crewname")
            Reports.basReports.BindData(.celScreenCaption, "Text", Nothing, "ScreenCaption")
            Reports.basReports.BindData(.celAction, "Text", Nothing, "ActionDescrip")
            Reports.basReports.BindData(.celDescription, "Text", Nothing, "DataDescrip")
            Reports.basReports.BindData(.celRecordKeyword, "Text", Nothing, "RecordName")
            Reports.basReports.BindData(.celDateUpdated, "Text", Nothing, "Dateupdated", "{0:dd-MMM-yyyy}")
            Reports.basReports.BindData(.celUsername, "Text", Nothing, "UserName")
            Reports.basReports.BindData(.celComputerName, "Text", Nothing, "ComputerName")

        End With


    End Sub

End Class
