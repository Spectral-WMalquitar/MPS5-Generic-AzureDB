Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FilterEditorForm

    ' ** Fields
    Private _field As QueryField
    Private Shared _rx1 As Regex = New Regex("^([^<>=]*)\s*(<|>|=|<>|<=|>=)\s*([^<>=]+)$", (RegexOptions.Compiled Or RegexOptions.IgnoreCase))
    Private Shared _rx2 As Regex = New Regex("^([^<>=]*)\s*BETWEEN\s+(.+)\s+AND\s+(.+)$", (RegexOptions.Compiled Or RegexOptions.IgnoreCase))

    ' ** Properties
    Public Property QueryField() As QueryField
        Get
            Return Me._field
        End Get
        Set(ByVal value As QueryField)
            Me._field = value
            Dim crit As String = Me._field.Filter
            Me._value.Text = crit
            If (crit.Length > 0) Then
                Dim m As Match = FilterEditorForm._rx1.Match(crit)
                If m.Success Then
                    Me._cmbOperator.Text = m.Groups.Item(2).Value
                    Me._txtValue.Text = m.Groups.Item(3).Value
                End If
                m = FilterEditorForm._rx2.Match(crit)
                If m.Success Then
                    Me._txtFrom.Text = m.Groups.Item(2).Value
                    Me._txtTo.Text = m.Groups.Item(3).Value
                End If
            End If
        End Set
    End Property

    Public Property Value() As String
        Get
            Return Me._value.Text
        End Get
        Set(ByVal value As String)
            Me._value.Text = value
        End Set
    End Property

    ' ** Event Handlers
    Protected Overrides Sub OnActivated(ByVal e As EventArgs)
        If (Me._txtValue.Text.Length > 0) Then
            Me._txtValue.Focus()
            Me._txtValue.SelectAll()
        ElseIf (Me._txtFrom.Text.Length > 0) Then
            Me._txtFrom.Focus()
            Me._txtFrom.SelectAll()
        End If
        MyBase.OnActivated(e)
    End Sub

    Private Sub _between_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles _txtFrom.TextChanged, _txtTo.TextChanged
        Me.UpdateBetween()
    End Sub

    Private Sub _btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClear.Click
        Me._cmbOperator.SelectedIndex = -1
        Me._txtValue.Text = String.Empty
        Me._txtFrom.Text = String.Empty
        Me._txtTo.Text = String.Empty
        Me._value.Text = String.Empty
    End Sub

    Private Sub _simpleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtValue.TextChanged, _cmbOperator.SelectedIndexChanged
        Me.UpdateSimple()
    End Sub

    ' ** Implementation
    Private Sub UpdateBetween()
        If ((Me._txtFrom.Text.Length > 0) AndAlso (Me._txtTo.Text.Length > 0)) Then
            Dim parmFrom As String = GetParameter(_txtFrom.Text)
            Dim parmTo As String = GetParameter(_txtTo.Text)
            _value.Text = String.Format("BETWEEN {0} AND {1}", parmFrom, parmTo)
        End If
    End Sub

    Private Sub UpdateSimple()
        If ((Me._cmbOperator.SelectedIndex > -1) AndAlso (Me._txtValue.Text.Length > 0)) Then
            Dim parm As String = GetParameter(_txtValue.Text)
            _value.Text = String.Format("{0} {1}", _cmbOperator.Text, parm)
        End If
    End Sub

    Private Function GetParameter(ByVal p As String) As String
        Dim quote As Boolean = True
        Dim d As Double

        ' don't quote numbers
        If Double.TryParse(p, NumberStyles.Any, CultureInfo.InvariantCulture, d) Then
            quote = False
        End If

        ' don't quote if already quoted
        If p.StartsWith("'") AndAlso p.EndsWith("'") AndAlso p.Length > 1 Then
            quote = False
        End If

        ' OK to quote
        If quote Then
            p = String.Format("'{0}'", p)
        End If

        ' done
        Return p
    End Function
End Class