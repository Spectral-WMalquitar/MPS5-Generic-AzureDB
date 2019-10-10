Public Class ManPowerFilter


    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        InitControls()
        cboPeriod.EditValue = CInt(Format(Date.Now, "yyyyMM").ToString)
    End Sub

    Private Sub InitControls()
        cboAgent.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.ManAgentList ORDER BY Name")
        cboFleet.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.FltList ORDER BY Name")
        cboPeriod.Properties.DataSource = GetPeriods()
    End Sub

    Private Sub cboAgent_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAgent.EditValueChanged
        Dim AgentCode As String = IfNull(TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue, "")
        Dim query As String = "SELECT m.FKeyFlt AS PKey,f.Name" & _
            " FROM dbo.sec_filtermap m " & _
            " LEFT JOIN dbo.tblAdmFlt f ON m.FKeyFlt = f.PKey " & _
            " GROUP BY m.FKeyFlt,f.PKey,f.Name,m.FKeyAgent " & _
            " HAVING FKeyAgent = '" & AgentCode & "'"
        cboFleet.Properties.DataSource = DB.CreateTable(query)
    End Sub

    Private Sub cboFleet_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFleet.EditValueChanged
        Dim FltCode As String = IfNull(TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue, "")
        Dim query As String = "SELECT m.FKeyAgent AS PKey,f.Name" & _
            " FROM dbo.sec_filtermap m " & _
            " LEFT JOIN dbo.ManAgentList f ON m.FKeyAgent = f.PKey " & _
            " GROUP BY m.FKeyFlt,f.PKey,f.Name,m.FKeyAgent " & _
            " HAVING FKeyFlt = '" & FltCode & "'"
        cboAgent.Properties.DataSource = DB.CreateTable(query)
    End Sub

    Private Sub cboPeriod_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles cboPeriod.ParseEditValue
        Try
            e.Value = Convert.ToInt32(e.Value)
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try
    End Sub
End Class
