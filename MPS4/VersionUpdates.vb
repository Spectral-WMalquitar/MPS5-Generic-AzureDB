Public Class VersionUpdates
    Dim oDB As clsVersioning
    Dim clsSec As New clsSecurity
    Dim cPageCaption As String = "Application Info"
    Dim cPageGroupName As String = "rpgAppInfoOption"
    Private Sub Init()
        Dim cConn As String = "Data Source=" & SQLServer & ";Persist Security Info=True;User ID=" & SQLID & ";Password=" & SQLPW & ";"
        oDB = New clsVersioning(cConn)
        clsSec.propSQLConnStr = MPSDB.GetConnectionString
    End Sub
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        Init()
        grdVersionUpdates.DataSource = oDB.oGetAllVersionUpdates()
        Dim isAdmin As Integer = 0
        clsSec.isUserAdmin(USER_ID, isAdmin)
        If isAdmin = 1 Then
            SetUpdateProgramVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetPageGroupVisibility(Name, cPageCaption, cPageGroupName, True)
        Else
            If clsSec.hasNoAddPermission("VersionUpdates", USER_ID) Then
                SetUpdateProgramVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                SetPageGroupVisibility(Name, cPageCaption, cPageGroupName, False)
            Else
                SetUpdateProgramVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetPageGroupVisibility(Name, cPageCaption, cPageGroupName, True)
            End If
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            With view
                If e.RowHandle = .FocusedRowHandle Then
                    e.Appearance.BackColor = SEL_COLOR
                    e.Appearance.ForeColor = GRID_SELFONTCOLOR
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
End Class
