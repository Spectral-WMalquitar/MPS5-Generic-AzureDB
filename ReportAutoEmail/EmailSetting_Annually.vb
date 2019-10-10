Public Class EmailSetting_Annually

    Public Overrides Sub initControls()
        'list of days
        Dim dtDays As New DataTable
        dtDays.Columns.Add("PKey", GetType(Integer))
        dtDays.Columns.Add("Name", GetType(String))
        For cnt As Integer = 1 To 31
            dtDays.Rows.Add(cnt, NumberToOrdinal(cnt))
        Next
        dtDays.Rows.Add(-1, "Last Day")
        cboDay.Properties.DataSource = dtDays
        cboDay.EditValue = 1

        'months list
        Dim dtMonths As New DataTable
        dtMonths.Columns.Add("PKey", GetType(Integer))
        dtMonths.Columns.Add("Name", GetType(String))
        For cnt As Integer = 1 To 12
            dtMonths.Rows.Add(cnt, System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames(cnt - 1))
        Next
        cboExecMonth.Properties.DataSource = dtMonths
        cboStartMonth.Properties.DataSource = dtMonths
        cboExecMonth.EditValue = 1
        cboStartMonth.EditValue = 1
    End Sub

    Public Overrides Sub ClearControls()
        ClearFields(Me.layoutSubPanel.Root, False)
    End Sub

    Public Overrides Sub SetIntervals(value As String)
        If value.Length = 0 Then Exit Sub

        Dim vals As String()
        vals = value.Split(";")

        cboDay.EditValue = CInt(vals(0))
        cboExecMonth.EditValue = CInt(vals(1))
        cboStartMonth.EditValue = CInt(vals(2))
    End Sub

    Public Overrides Function GetIntervals()
        Dim retVal As String = ""
        retVal = cboDay.EditValue & ";" & cboExecMonth.EditValue & ";" & cboStartMonth.EditValue
        Return retVal
    End Function

    Public Overrides Sub MakeControlsEditable(editable As Boolean)
        If Not editable Then
            MakeReadOnlyListener(Me.layoutSubPanel.Root)
        Else
            RemoveReadOnlyListener(Me.layoutSubPanel.Root)
        End If
    End Sub

    Public Overrides Sub EnableEditListener(value As Boolean)
        If value Then
            AddEditListener(Me.layoutSubPanel.Root)
        Else
            RemoveEditListener(Me.layoutSubPanel.Root)
        End If
    End Sub

    Private Sub cboExecMonth_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboExecMonth.EditValueChanged
        If IsNothing(cboStartMonth.EditValue) Then
            cboStartMonth.EditValue = 1
        End If
    End Sub

End Class
