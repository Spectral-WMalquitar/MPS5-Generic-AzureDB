Public Class frmTest


    Private Sub frmTest_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable

        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Key"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Value"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        dt.Rows.Add(New Object() {"1", "One"})
        dt.Rows.Add(New Object() {"2", "Two"})
        dt.Rows.Add(New Object() {"3", "Three"})

        With CheckedComboBoxEdit1.Properties
            .DataSource = dt
            .ValueMember = "Key"
            .DisplayMember = "Value"
        End With

        CheckedComboBoxEdit1.SetEditValue("1, 2, 3")

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ''For i As Integer = 0 to CheckedComboBoxEdit1.get
        'For i As Integer = 0 To CheckedComboBoxEdit1.Properties.Items.Count - 1
        '    If CheckedComboBoxEdit1.Properties.Items(i).CheckState = CheckState.Checked Then
        '        MsgBox(CheckedComboBoxEdit1.Properties.Items(i).Value)

        '    End If
        'Next
        ''MsgBox CheckedComboBoxEdit1.get

        MsgBox(CheckedComboBoxEdit1.Text)
    End Sub
End Class