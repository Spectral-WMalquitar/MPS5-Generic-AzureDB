Public Class frmCheckList

    Public Sub New(ByVal dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        GridControl1.DataSource = dt
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.CellValue = "No" Then
            e.Appearance.BackColor = System.Drawing.Color.Salmon
        End If
    End Sub

End Class