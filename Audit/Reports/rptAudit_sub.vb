Imports DevExpress.XtraReports.UI

Public Class rptAudit_sub

    Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        'TryCast(sender, DevExpress.XtraReports.UI.XtraReport).FilterString = "AuditLogID='" & GetCurrentColumnValue("AuditLogID").ToString & "'"
        'Try
        '    DirectCast(sender, XtraReport).Parameters("AuditLogID").Value = GetCurrentColumnValue("AuditLogID")
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub rptAudit_sub_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint
      
    End Sub
End Class