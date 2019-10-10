Public Class QueryPropertiesDialog

    ' Fields
    Private _builder As QueryBuilder

    ' Properties
    Public Property QueryBuilder() As QueryBuilder
        Get
            Return Me._builder
        End Get
        Set(ByVal value As QueryBuilder)
            If (Not Me._builder Is value) Then
                Me._builder = value
                Me.UpdateDialogValues()
            End If
        End Set
    End Property

    ' ** Event Handers
    Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.UpdateBuilderValues()
    End Sub

    ' ** Implementation
    Private Sub UpdateBuilderValues()
        Me._builder.Top = CInt(Me._numTopN.Value)
        If Me._builder.GroupBy Then
            Me._builder.GroupByExtension = DirectCast(Me._cmbGroupBy.SelectedIndex, GroupByExtension)
        End If
        Me._builder.Distinct = Me._chkDistinct.Checked
    End Sub

    Private Sub UpdateDialogValues()
        Me._numTopN.Value = Me._builder.Top
        If Me._builder.GroupBy Then
            Me._cmbGroupBy.SelectedIndex = CInt(Me._builder.GroupByExtension)
        Else
            Me._cmbGroupBy.Enabled = False
        End If
        Me._chkDistinct.Checked = Me._builder.Distinct
    End Sub

End Class