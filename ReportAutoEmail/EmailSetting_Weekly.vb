Public Class EmailSetting_Weekly

    Public Overrides Sub initControls()
    End Sub

    Public Overrides Sub ClearControls()
        ClearFields(Me.layoutSubPanel.Root, False)
    End Sub

    Public Overrides Sub SetIntervals(value As String)
        If value.Length = 0 Then Exit Sub

        Dim vals As String()
        vals = value.Split(";")

        optSun.Checked = IIf(CInt(vals(0)) > 0, True, False)
        optMon.Checked = IIf(CInt(vals(1)) > 0, True, False)
        optTue.Checked = IIf(CInt(vals(2)) > 0, True, False)
        optWed.Checked = IIf(CInt(vals(3)) > 0, True, False)
        optThu.Checked = IIf(CInt(vals(4)) > 0, True, False)
        optFri.Checked = IIf(CInt(vals(5)) > 0, True, False)
        optSat.Checked = IIf(CInt(vals(6)) > 0, True, False)
    End Sub

    Public Overrides Function GetIntervals()
        Dim retVal As String = ""
        retVal = IIf(optSun.Checked, 1, 0) & ";" & _
                IIf(optMon.Checked, 2, 0) & ";" & _
                IIf(optTue.Checked, 3, 0) & ";" & _
                IIf(optWed.Checked, 4, 0) & ";" & _
                IIf(optThu.Checked, 5, 0) & ";" & _
                IIf(optFri.Checked, 6, 0) & ";" & _
                IIf(optSat.Checked, 7, 0)
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
