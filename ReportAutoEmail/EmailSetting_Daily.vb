Public Class EmailSetting_Daily

    Public Overrides Sub initControls()

    End Sub

    Public Overrides Sub ClearControls()
        ClearFields(Me.layoutSubPanel.Root, False)
    End Sub

    Public Overrides Sub SetIntervals(value As String)
        If value.Length = 0 Then Exit Sub

        Dim vals As String()
        vals = value.Split(";")

        chkSun.Checked = IIf(CInt(vals(0)) > 0, True, False)
        chkMon.Checked = IIf(CInt(vals(1)) > 0, True, False)
        chkTue.Checked = IIf(CInt(vals(2)) > 0, True, False)
        chkWed.Checked = IIf(CInt(vals(3)) > 0, True, False)
        chkThu.Checked = IIf(CInt(vals(4)) > 0, True, False)
        chkFri.Checked = IIf(CInt(vals(5)) > 0, True, False)
        chkSat.Checked = IIf(CInt(vals(6)) > 0, True, False)
    End Sub

    Public Overrides Function GetIntervals()
        Dim retVal As String = ""
        retVal = IIf(chkSun.Checked, 1, 0) & ";" & _
                        IIf(chkMon.Checked, 2, 0) & ";" & _
                        IIf(chkTue.Checked, 3, 0) & ";" & _
                        IIf(chkWed.Checked, 4, 0) & ";" & _
                        IIf(chkThu.Checked, 5, 0) & ";" & _
                        IIf(chkFri.Checked, 6, 0) & ";" & _
                        IIf(chkSat.Checked, 7, 0)
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
