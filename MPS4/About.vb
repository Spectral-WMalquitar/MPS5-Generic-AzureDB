Public Class About
    Dim cPageCaption As String = "Application Info"
    Dim cPageGroupName As String = "rpgAppInfoOption"
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        Try
            lblVersion.Text = GetIni("VERSION")
            lblVersionDate.Text = GetIni("VERSIONDATE")
            lblCompName.Text = My.Computer.Name
            SetUpdateProgramVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetPageGroupVisibility(Name, cPageCaption, cPageGroupName, False)
        Catch ex As Exception
            MsgBox("An error ocurred getting program information", MsgBoxStyle.Exclamation, GetAppName)
        End Try
    End Sub


End Class
