
Public Class CrewActivity_AmendV2
    Dim IDNbr, ActID, ActGrpID As String
    Dim ActDT As New DataTable
    Dim adjDT As New DataTable
    Dim portDT As New DataTable
    Dim CrewName As String = ""
    Dim sEdited As Boolean = False
    Dim eEdited As Boolean = False
    Dim pEdited As Boolean = False
    Dim editedRows As New ArrayList
    Dim strUpdatedBy As String = ""
    Dim isSupplying As Boolean = False

#Region "Easy Edit"
    Private FormName As String = "Amend Activity"
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Public Overrides Sub RefreshData()
        If bLoaded = False Then
            portDT = PortList(DB) 'MPSDB.CreateTable("SELECT Pkey as PortCode, Name as PortName FROM [tblAdmPort] ORDER BY Name ASC")

            leEnd.Properties.DataSource = portDT
            leEnd.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
            leEnd.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
            leEnd.Properties.Columns("PortCode").Visible = False

            leStart.Properties.DataSource = portDT
            leStart.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
            leStart.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
            leStart.Properties.Columns("PortCode").Visible = False

            PortEdit.DataSource = portDT
            PortEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
            PortEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
            PortEdit.Columns("PortCode").Visible = False

            genericDateEdit.EditMask = "MMM-dd-yyyy"
            genericDateEdit.Mask.UseMaskAsDisplayFormat = True

            deStart.Properties.EditMask = "MMM-dd-yyyy"
            deStart.Properties.Mask.UseMaskAsDisplayFormat = True

            deEnd.Properties.EditMask = "MMM-dd-yyyy"
            deEnd.Properties.Mask.UseMaskAsDisplayFormat = True

            deDue.Properties.EditMask = "MMM-dd-yyyy"
            deDue.Properties.Mask.UseMaskAsDisplayFormat = True

            MainView.Bands(0).Visible = True

            If strCrewListFilter <> "" Then
                blList.SetFilter("(ActGrpID IS NOT NULL) AND " & strCrewListFilter)
            Else
                blList.SetFilter("ActGrpID IS NOT NULL")
            End If

            blList.Draggable(False)
            bLoaded = True
        End If

        If blList.GetID <> "" Then
            IDNbr = blList.GetID
            ActDT = DB.CreateTable("SELECT * FROM [Crewlist_Activities_All] WHERE IDNbr = '" & IDNbr & "' ORDER BY DateStarted DESC")
            MainGrid.DataSource = ActDT
            CrewName = "Activity Details - " & getCurrentRowData("Crew")
            MainView.ClearColumnErrors()
            MainView_FocusedRowChanged(Nothing, Nothing)
            eEdited = False
            sEdited = False
            pEdited = False
            AllowSaving(Name, False)
        End If

    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim strIDNbr As String = ""


        If MsgBox("Are you sure you want to save the changes to this activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then Exit Sub
        editedRows.Add(MainView.FocusedRowHandle)
        strIDNbr = MainView.GetRowCellValue(0, "IDNbr")
        strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Amend", 0, System.Environment.MachineName, "Amend_desc", "Activity", strIDNbr)
        For i As Integer = 0 To editedRows.Count - 1
            If IfNull(MainView.GetRowCellValue(editedRows(i), "DateEnded"), "") = "" Then
                sqls.Add("EXEC [dbo].[SP_AMEND] @ActID = '" & MainView.GetRowCellValue(editedRows(i), "ActID") & "', @NewDateStart = " & ChangeToSQLDate(MainView.GetRowCellValue(editedRows(i), "DateStarted").ToString) & ", @NewDateEnd = NULL, @NewPlaceSON = '" & MainView.GetRowCellValue(editedRows(i), "PlaceSOn") & "', @NewPlaceSOFF = '" & MainView.GetRowCellValue(editedRows(i), "PlaceSOff") & "', @LastUpdatedBy = '" & LastUpdatedBy & "'")
            Else
                sqls.Add("EXEC [dbo].[SP_AMEND] @ActID = '" & MainView.GetRowCellValue(editedRows(i), "ActID") & "', @NewDateStart = " & ChangeToSQLDate(MainView.GetRowCellValue(editedRows(i), "DateStarted").ToString) & ", @NewDateEnd = " & ChangeToSQLDate(MainView.GetRowCellValue(editedRows(i), "DateEnded").ToString) & ", @NewPlaceSON = '" & MainView.GetRowCellValue(editedRows(i), "PlaceSOn") & "', @NewPlaceSOFF = '" & MainView.GetRowCellValue(editedRows(i), "PlaceSOff") & "', @LastUpdatedBy = '" & LastUpdatedBy & "'")
            End If
        Next
        MsgBox(GetMessage("Saved", DB.RunSqls(sqls)), MsgBoxStyle.Information, GetAppName)
        MainView.ClearColumnErrors()
        RefreshData()
    End Sub

    Private Function getCurrentRowData(ByVal fieldname As String)
        Return MainView.GetRowCellValue(MainView.FocusedRowHandle, fieldname)
    End Function

    Private Sub MainView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        isSupplying = True
        LayoutControlGroup2.Text = CrewName & " (" & IfNull(getCurrentRowData("Rank"), "N/A") & ", " & getCurrentRowData("Status") & ")"

        deStart.EditValue = getCurrentRowData("DateStarted")
        leStart.EditValue = getCurrentRowData("PlaceSOn")
        teLOC.EditValue = getCurrentRowData("LOC")
        deDue.EditValue = getCurrentRowData("DueDate")

        If IsDBNull(getCurrentRowData("DateEnded")) = True Then
            deEnd.EditValue = Nothing
            deEnd.Properties.ReadOnly = True
        Else
            deEnd.Properties.ReadOnly = False
            deEnd.EditValue = getCurrentRowData("DateEnded")
        End If

        If IfNull(getCurrentRowData("PlaceSOff"), "") = "" Then
            leEnd.EditValue = Nothing
            leEnd.Properties.ReadOnly = True
        Else
            leEnd.Properties.ReadOnly = False
            leEnd.EditValue = getCurrentRowData("PlaceSOff")
        End If

        eEdited = False
        sEdited = False
        pEdited = False
        isSupplying = False
        editedRows.Clear()
    End Sub

    Private Sub MainView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MainView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.RowCount > 0 Then
            If eEdited = True And sEdited = True Then
                If ((e.RowHandle = MainView.FocusedRowHandle And e.Column.FieldName = "DateEnded") Or (e.RowHandle = (MainView.FocusedRowHandle - 1) And e.Column.FieldName = "DateStarted")) _
                   Or ((e.RowHandle = MainView.FocusedRowHandle And e.Column.FieldName = "DateStarted") Or (e.RowHandle = (MainView.FocusedRowHandle + 1) And e.Column.FieldName = "DateEnded")) Then
                    e.Appearance.ForeColor = System.Drawing.Color.BlueViolet
                End If
            ElseIf sEdited = True Then
                If ((e.RowHandle = MainView.FocusedRowHandle And e.Column.FieldName = "DateStarted") Or (e.RowHandle = (MainView.FocusedRowHandle + 1) And e.Column.FieldName = "DateEnded")) Then
                    e.Appearance.ForeColor = System.Drawing.Color.BlueViolet
                End If
            ElseIf eEdited = True Then
                If ((e.RowHandle = MainView.FocusedRowHandle And e.Column.FieldName = "DateEnded") Or (e.RowHandle = (MainView.FocusedRowHandle - 1) And e.Column.FieldName = "DateStarted")) Then
                    e.Appearance.ForeColor = System.Drawing.Color.BlueViolet
                End If
            End If
        End If
    End Sub

    Private Sub MainView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MainView.ValidateRow

        If MainView.GetRowCellValue(MainView.FocusedRowHandle + 1, MainView.Columns("DateStarted")) >= MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateStarted")) Then
            e.Valid = False
            AllowSaving(Name, False)
            MainView.GetDataRow(MainView.FocusedRowHandle).SetColumnError("DateStarted", "Start date of activity must be later than the start date of the previous activity.")
            Exit Sub
        End If

        'If IsDBNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateDue"))) = False Then
        '    If MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateStarted")) > MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateDue")) Then
        '        e.Valid = False
        '        AllowSaving(Name, False)
        '        MainView.GetDataRow(MainView.FocusedRowHandle).SetColumnError("DateStarted", "Contract overdue.")
        '        Exit Sub
        '    End If
        'End If

        If IsDBNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateEnded"))) = False Then
            If MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateEnded")) <= MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateStarted")) Then
                e.Valid = False
                AllowSaving(Name, False)
                MainView.GetDataRow(MainView.FocusedRowHandle).SetColumnError("DateStarted", "Start date of activity must be earlier than it's end date.")
                Exit Sub
            End If
            If IsDBNull(MainView.GetRowCellValue(MainView.FocusedRowHandle - 1, MainView.Columns("DateEnded"))) = False Then
                If IsNothing(MainView.GetRowCellValue(MainView.FocusedRowHandle - 1, MainView.Columns("DateEnded"))) = False Then
                    If MainView.GetRowCellValue(MainView.FocusedRowHandle - 1, MainView.Columns("DateEnded")) <= MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateEnded")) Then
                        e.Valid = False
                        AllowSaving(Name, False)
                        MainView.GetDataRow(MainView.FocusedRowHandle).SetColumnError("DateEnded", "End date of activity must be later than the end date of the next activity.")
                        Exit Sub
                    End If
                End If
            End If
            'If IsDBNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateDue"))) = False Then
            '    If MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateEnded")) = MainView.GetRowCellValue(MainView.FocusedRowHandle, MainView.Columns("DateDue")) Then
            '        e.Valid = False
            '        AllowSaving(Name, False)
            '        MainView.GetDataRow(MainView.FocusedRowHandle).SetColumnError("DateEnded", "Contract overdue.")
            '        Exit Sub
            '    End If
            'End If
        End If

        'If (sEdited = True Or eEdited = True Or pEdited = True) Then
        ' If isSupplying = False Then
        AllowSaving(Name, True)
        MainView.GetDataRow(MainView.FocusedRowHandle).ClearErrors()
        e.Valid = True
        MainView.SetColumnError(MainView.Columns("Status"), "Updated", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information)
        '   End If
        'End If
    End Sub

    Private Sub deStart_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles deStart.CloseUp
        If MainView.RowCount > 0 Then
            sEdited = True
        End If
    End Sub

    Private Sub deEnd_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles deEnd.CloseUp
        If MainView.RowCount > 0 Then
            eEdited = True
        End If
    End Sub

    Private Sub deStart_EditValueChanged(sender As Object, e As System.EventArgs) Handles deStart.EditValueChanged
        If MainView.RowCount > 0 Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "DateStarted", deStart.EditValue)
            If isSupplying = False Then
                If MainView.IsValidRowHandle(MainView.FocusedRowHandle + 1) Then
                    MainView.SetRowCellValue(MainView.FocusedRowHandle + 1, "DateEnded", DateAdd(DateInterval.Day, -1, deStart.EditValue))
                    editedRows.Add(MainView.FocusedRowHandle + 1)
                End If
            End If
            'AllowSaving(Name, True)
            'If sEdited = True Then
            ' End If
        End If
    End Sub

    Private Sub deEnd_EditValueChanged(sender As Object, e As System.EventArgs) Handles deEnd.EditValueChanged
        If MainView.RowCount > 0 Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "DateEnded", deEnd.EditValue)
            If isSupplying = False Then
                If MainView.IsValidRowHandle(MainView.FocusedRowHandle - 1) Then
                    MainView.SetRowCellValue(MainView.FocusedRowHandle - 1, "DateStarted", DateAdd(DateInterval.Day, 1, deEnd.EditValue))
                    editedRows.Add(MainView.FocusedRowHandle - 1)
                End If
            End If
            'AllowSaving(Name, True)
            'If eEdited = True Then
            'End If
        End If
    End Sub

    Private Sub leEnd_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles leEnd.CloseUp, leStart.CloseUp
        If MainView.RowCount > 0 Then
            pEdited = True
        End If
    End Sub

    Private Sub leEnd_EditValueChanged(sender As Object, e As System.EventArgs) Handles leEnd.EditValueChanged
        If MainView.RowCount > 0 Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "PlaceSOff", leEnd.EditValue)
        End If
    End Sub

    Private Sub leStart_EditValueChanged(sender As Object, e As System.EventArgs) Handles leStart.EditValueChanged
        If MainView.RowCount > 0 Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "PlaceSOn", leStart.EditValue)
        End If
    End Sub

    Private Sub deStart_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles deStart.EditValueChanging
        If MainView.RowCount > 0 Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "DateStarted", deStart.EditValue)
            If isSupplying = False Then
                If MainView.IsValidRowHandle(MainView.FocusedRowHandle + 1) Then
                    MainView.SetRowCellValue(MainView.FocusedRowHandle + 1, "DateEnded", DateAdd(DateInterval.Day, -1, deStart.EditValue))
                    editedRows.Add(MainView.FocusedRowHandle + 1)
                End If
            End If
        End If
    End Sub

End Class
