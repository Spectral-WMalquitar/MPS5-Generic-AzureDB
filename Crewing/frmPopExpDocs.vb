Imports System.Drawing
Public Class frmPopExpDocs
    Public isPressedGoTo As Boolean = False
    Public Sub New(ByVal IDNbr As String, CrewList As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim dt As New DataTable
        Dim sql As String = ""
        Dim expDocDays As Integer
        If GetUserSetting("DocExpDays") <> "" Then expDocDays = GetUserSetting("DocExpDays") Else expDocDays = 0
        selectedID = IDNbr

        Dim cTable As New DataTable
        Dim sqlConn As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_EXPIRING_DOCUMENTS"
                With cmd.Parameters
                    .AddWithValue("@DocExpDays", expDocDays)
                    .AddWithValue("@crewFilter", IDNbr)
                    .AddWithValue("@ExpiringCrewList", CrewList)
                End With
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(cTable)
                End Using

            End Using

        Catch ex As Exception
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

        'sql = "EXEC [SP_EXPIRING_DOCUMENTS] @DocExpDays = " & expDocDays & ", @crewFilter = '" & IDNbr & "'"
        'dt = MPSDB.CreateTable(sql)
        dt = cTable
        Maingrid.DataSource = dt
    End Sub

    Private Sub Mainview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        Dim view As GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "DateExpiry" Then
            Select Case view.GetRowCellValue(e.RowHandle, "hasExpDoc")
                Case 1
                    e.Appearance.BackColor = Color.Orange
                    e.Appearance.BackColor2 = Color.Red
                    e.Appearance.GradientMode = Drawing2D.LinearGradientMode.Horizontal
                Case 2
                    e.Appearance.BackColor = Color.White
                    e.Appearance.BackColor2 = Color.Orange
                    e.Appearance.GradientMode = Drawing2D.LinearGradientMode.Horizontal
            End Select
        End If
    End Sub

    Private Sub btnGoToDocs_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGoToDocs.ItemClick
        isPressedGoTo = True
        Me.Hide()
    End Sub

    Private Sub btnClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        Me.Close()
    End Sub
End Class