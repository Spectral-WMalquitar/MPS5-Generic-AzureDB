Public Class DataPreviewDialog

    Public Sub New(ByVal dt As DataTable, ByVal font As Font, ByVal size As Size)
        InitializeComponent()
        Me.Font = font
        MyBase.Size = size
        Me._grid.DataSource = dt
        Me.Text = String.Format(Me.Text, dt.TableName, dt.Rows.Count)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If (e.KeyCode = Keys.Escape) Then
            MyBase.Close()
        End If
    End Sub

End Class