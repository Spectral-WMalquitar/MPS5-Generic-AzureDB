Public Class EmailSetting_Quarterly

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

        Dim dtMonthQuarter As New DataTable
        dtMonthQuarter.Columns.Add("PKey", GetType(Integer))
        dtMonthQuarter.Columns.Add("Name", GetType(String))
        dtMonthQuarter.Rows.Add(1, "1st")
        dtMonthQuarter.Rows.Add(2, "2nd")
        dtMonthQuarter.Rows.Add(3, "3rd")
        cboQuarter.Properties.DataSource = dtMonthQuarter
        cboQuarter.EditValue = 1
    End Sub
    Public Overrides Sub ClearControls()
        ClearFields(Me.layoutSubPanel.Root, False)
    End Sub

    Public Overrides Sub SetIntervals(value As String)
        If value.Length = 0 Then Exit Sub

        Dim vals As String()
        vals = value.Split(";")

        cboDay.EditValue = CInt(vals(0))
        cboQuarter.EditValue = CInt(vals(1))
    End Sub

    Public Overrides Function GetIntervals()
        Dim retVal As String = ""
        retVal = cboDay.EditValue & ";" & cboQuarter.EditValue
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
