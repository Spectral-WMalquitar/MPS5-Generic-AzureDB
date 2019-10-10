Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class frmFilterBuilder
    ' ** Fields
    Private _field As QueryField
    Private _builder As QueryBuilder
    Private Shared _rx1 As Regex = New Regex("^([^<>=]*)\s*(<|>|=|<>|<=|>=|START|ENDS)\s*([^<>=]+)$", (RegexOptions.Compiled Or RegexOptions.IgnoreCase))
    Private Shared _rx2 As Regex = New Regex("^([^<>=]*)\s*BETWEEN\s+(.+)\s+AND\s+(.+)$", (RegexOptions.Compiled Or RegexOptions.IgnoreCase))

    Dim dt As New DataTable

    ' ** Properties
    Public Property QueryField() As QueryField
        Get
            Return Me._field
        End Get
        Set(ByVal value As QueryField)
            Me._field = value
            Dim crit As String = Me._field.Filter
            Me._value.Text = crit
            Me.txtOpenP.Text = Me._field.CriteriaOpenParenthesis
            Me.txtCloseP.Text = Me._field.CriteriaCloseParenthesis
            Me._valueformated.Text = Me._field.FilterFormated
            Me.lblPreviewCriteria.Text = Me.txtOpenP.Text & _valueformated.Text & Me.txtCloseP.Text
            If (crit.Length > 0) Then
                Dim m As Match = frmFilterBuilder._rx1.Match(crit)
                If m.Success Then
                    Me._cmbOperator.EditValue = m.Groups.Item(2).Value
                    Me._txtValue.Text = m.Groups.Item(3).Value
                End If
                m = frmFilterBuilder._rx2.Match(crit)
                If m.Success Then
                    Me._txtFrom.Text = m.Groups.Item(2).Value
                    Me._txtTo.Text = m.Groups.Item(3).Value
                End If
            End If
        End Set
    End Property

    Public Property QueryFields() As QueryBuilder
        Get
            Return Me._builder
        End Get
        Set(ByVal value As QueryBuilder)
            Me._builder = value
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

    Public Property FilterFValue() As String
        Get
            Return Me._valueformated.Text
        End Get
        Set(ByVal value As String)
            Me._valueformated.Text = value
            Me.lblPreviewCriteria.Text = _valueformated.Text
        End Set
    End Property

    Public Property OpenP() As String
        Get
            Return Me.txtOpenP.Text
        End Get
        Set(ByVal value As String)
            Me.txtOpenP.Text = value
        End Set
    End Property

    Public Property CloseP() As String
        Get
            Return Me.txtCloseP.Text
        End Get
        Set(ByVal value As String)
            Me.txtCloseP.Text = value
        End Set
    End Property

    ' ** Event Handlers
    Protected Overrides Sub OnActivated(ByVal e As EventArgs)
        PopulateCriteriaOp()
        _cmbOperator.Properties.DataSource = dt
        If (Me._txtValue.Text.Length > 0) Then
            Me._txtValue.Focus()
            Me._txtValue.SelectAll()
        ElseIf (Me._txtFrom.Text.Length > 0) Then
            Me._txtFrom.Focus()
            Me._txtFrom.SelectAll()
        End If
        Me.UpdateSimple()
        Me.UpdateBetween()
        MyBase.OnActivated(e)
    End Sub

    Private Sub _between_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles _txtFrom.TextChanged, _txtTo.TextChanged
        Me.UpdateBetween()
    End Sub

    Private Sub _simpleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtValue.TextChanged, _cmbOperator.EditValueChanged
        Me.UpdateSimple()
    End Sub

    ' ** Implementation
    Private Sub UpdateBetween()
        If ((Me._txtFrom.Text.Length > 0) AndAlso (Me._txtTo.Text.Length > 0)) Then
            Dim parmFrom As String = GetParameter(_txtFrom.Text)
            Dim parmTo As String = GetParameter(_txtTo.Text)
            _value.Text = String.Format("BETWEEN {0} AND {1}", parmFrom, parmTo)
            _valueformated.Text = String.Format("BETWEEN {0} AND {1}", parmFrom, parmTo)
            lblPreviewCriteria.Text = txtOpenP.Text & _valueformated.Text & txtCloseP.Text
        End If
    End Sub

    Private Sub UpdateSimple()
        If ((IfNull(Me._cmbOperator.EditValue, "") <> "") AndAlso (Me._txtValue.Text.Length > 0)) Then
            Dim parm As String = GetParameter(_txtValue.Text)
            Dim cmbText As String = _cmbOperator.Properties.GetDisplayText(_cmbOperator.EditValue)
            _value.Text = String.Format("{0} {1}", _cmbOperator.EditValue, parm)
            _valueformated.Text = String.Format("{0} {1}", cmbText, parm)
            lblPreviewCriteria.Text = txtOpenP.Text & _valueformated.Text & txtCloseP.Text
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

    Private Sub cmdClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdClear.Click
        Me._cmbOperator.EditValue = Nothing
        Me._txtValue.Text = String.Empty
        Me._txtFrom.Text = String.Empty
        Me._txtTo.Text = String.Empty
        Me._value.Text = String.Empty
        Me._valueformated.Text = String.Empty
        Me.txtOpenP.Text = String.Empty
        Me.txtCloseP.Text = String.Empty
        lblPreviewCriteria.Text = String.Empty
    End Sub

    Private Sub PopulateCriteriaOp()
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CritOperator"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CritOperatorDesc"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)
        Dim crow() As Object = {"=", "Equals To"}
        dt.Rows.Add(crow)
        crow(0) = ">"
        crow(1) = "Greater Than"
        dt.Rows.Add(crow)
        crow(0) = ">="
        crow(1) = "Greater Than Or Equal to"
        dt.Rows.Add(crow)
        crow(0) = "<"
        crow(1) = "Less Than"
        dt.Rows.Add(crow)
        crow(0) = "<="
        crow(1) = "Less Than Or Equal To"
        dt.Rows.Add(crow)
        crow(0) = "<>"
        crow(1) = "Not Equal To"
        dt.Rows.Add(crow)
        crow(0) = "START"
        crow(1) = "Starts With"
        dt.Rows.Add(crow)
        crow(0) = "ENDSW"
        crow(1) = "Ends With"
        dt.Rows.Add(crow)
    End Sub

    Private Sub cmdAddOP_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddOP.Click
        txtOpenP.Text = txtOpenP.Text & "("
        lblPreviewCriteria.Text = txtOpenP.Text & _valueformated.Text & txtCloseP.Text
    End Sub

    Private Sub cmdAddCP_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddCP.Click
        txtCloseP.Text = txtCloseP.Text & ")"
        lblPreviewCriteria.Text = txtOpenP.Text & _valueformated.Text & txtCloseP.Text
    End Sub

    Private Sub cmdRevOP_Click(sender As System.Object, e As System.EventArgs) Handles cmdRevOP.Click
        If Len(txtOpenP.Text.Trim) > 0 Then
            txtOpenP.Text = txtOpenP.Text.Substring(0, Len(txtOpenP.Text.Trim) - 1)
            lblPreviewCriteria.Text = txtOpenP.Text & _valueformated.Text
        End If
    End Sub

    Private Sub cmdRevCP_Click(sender As System.Object, e As System.EventArgs) Handles cmdRevCP.Click
        If Len(txtCloseP.Text.Trim) > 0 Then
            txtCloseP.Text = txtCloseP.Text.Substring(0, Len(txtCloseP.Text.Trim) - 1)
            lblPreviewCriteria.Text = _valueformated.Text & txtCloseP.Text
        End If
    End Sub
End Class