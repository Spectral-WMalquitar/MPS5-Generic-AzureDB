Public Class EmailSetting_Monthly

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

        'preferance
        Dim dtMonthlyPref As New DataTable
        dtMonthlyPref.Columns.Add("PKey", GetType(Integer))
        dtMonthlyPref.Columns.Add("Name", GetType(String))
        dtMonthlyPref.Rows.Add(1, "Month of Execution")
        dtMonthlyPref.Rows.Add(2, "Month Before Execution Date")

        cboPref.Properties.DataSource = dtMonthlyPref
        cboPref.EditValue = 1
    End Sub

    Public Overrides Sub ClearControls()
        ClearFields(Me.layoutSubPanel.Root, False)
    End Sub

    Public Overrides Sub SetIntervals(value As String)
        If value.Length = 0 Then Exit Sub

        Dim vals As String()
        vals = value.Split(";")
        
        cboDay.EditValue = CInt(vals(0))
        cboPref.EditValue = CInt(vals(1))
    End Sub

    Public Overrides Function GetIntervals()
        Dim retVal As String = ""
        retVal = cboDay.EditValue & ";" & cboPref.EditValue
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

End Class
