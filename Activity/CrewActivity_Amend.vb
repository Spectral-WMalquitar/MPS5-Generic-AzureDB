Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid
Imports System.Drawing

Public Class CrewActivity_Amend
    Dim strCrewID As String = ""
    Dim isLoadingData As Boolean = False

#Region "Easy Edit"
    Private FormName As String = "Amend Activity"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil
#End Region

#Region "Load Data"
    Public Overrides Sub RefreshData()
        If bLoaded = False Then
            MyBase.RefreshData()
            Dim dtPort As DataTable = PortList(DB)

            leEnd.Properties.DataSource = dtPort
            leStart.Properties.DataSource = dtPort
            PortEdit.DataSource = dtPort

            If strCrewListFilter <> "" Then
                blList.SetFilter("(ActGrpID IS NOT NULL) AND " & strCrewListFilter)
            Else
                blList.SetFilter("ActGrpID IS NOT NULL")
            End If

            blList.Draggable(False)
            bLoaded = True
        End If

        strCrewID = blList.GetID()
        If strCrewID <> "" Then
            Dim dtActList As DataTable = DB.CreateTable("SELECT *, '' as isEdited FROM [Crewlist_Activities_All] WHERE IDNbr = '" & strCrewID & "' ORDER BY DateStarted DESC")
            MainGrid.DataSource = dtActList
            MainView_FocusedRowChanged(Nothing, Nothing)
        End If
        AllowSaving(Name, False)
    End Sub



    Private Sub MainView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        isLoadingData = True
        LayoutControlGroup2.Text = GetCurrentRowData("Crew") & " (" & IfNull(GetCurrentRowData("Rank"), "N/A") & ", " & GetCurrentRowData("Status") & ")"

        deStart.EditValue = GetCurrentRowData("DateStarted")
        leStart.EditValue = GetCurrentRowData("PlaceSOn")
        teLOC.EditValue = GetCurrentRowData("LOC")
        deDue.EditValue = GetCurrentRowData("DueDate")

        If IsDBNull(GetCurrentRowData("DateEnded")) = True Then
            deEnd.EditValue = Nothing
            deEnd.Properties.ReadOnly = True
        Else
            deEnd.Properties.ReadOnly = False
            deEnd.EditValue = GetCurrentRowData("DateEnded")
        End If

        If IfNull(GetCurrentRowData("PlaceSOff"), "") = "" Then
            leEnd.EditValue = Nothing
            leEnd.Properties.ReadOnly = True
        Else
            leEnd.Properties.ReadOnly = False
            leEnd.EditValue = GetCurrentRowData("PlaceSOff")
        End If
        isLoadingData = False
    End Sub

    Private Function GetCurrentRowData(ByVal fieldname As String)
        Return MainView.GetRowCellValue(MainView.FocusedRowHandle, fieldname)
    End Function
#End Region

#Region "Validations"
    Private Sub ToolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If Not e.SelectedControl Is MainGrid Then Return
        Dim info As ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As GridView = MainGrid.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells
        If hi.HitTest = GridHitTest.RowIndicator Then
            'An object that uniquely identifies a row indicator cell
            Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
            Dim text As String = ValidateEditedRow(hi.RowHandle)(1)
            info = New ToolTipControlInfo(o, text)
        End If
        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub

    Private Sub MainView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles MainView.CustomDrawRowIndicator
        Dim view As Views.Grid.GridView = CType(sender, Views.Grid.GridView)
        Dim currAct As Columns.GridColumn = view.Columns("CurrActID")
        Dim hasError As Boolean = False

        If e.Info.IsRowIndicator AndAlso e.RowHandle >= 0 Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)

            Dim rec As Rectangle = e.Bounds
            rec.Inflate(-1, -1)
            Dim img As Image = New System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"))
            Dim imgSave As Image = New System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/savedialog_16x16.png"))
            Dim x1 As Integer = rec.X + (rec.Width - img.Width) / 2
            Dim y1 As Integer = rec.Y + (rec.Height - img.Height) / 2
            Dim strMsg As String = ""

            If ValidateEditedRow(e.RowHandle)(0) = True Then
                e.Graphics.DrawImageUnscaled(img, x1, y1)
                e.Handled = True
            Else
                If view.GetRowCellValue(e.RowHandle, "isEdited") = "Yes" Then
                    e.Graphics.DrawImageUnscaled(imgSave, x1, y1)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Function ValidateEditedRow(ByVal rHandle As Integer) As ArrayList
        Dim arrRes As New ArrayList
        Dim currAct As Columns.GridColumn = MainView.Columns("CurrActID")
        Dim hasErr As Boolean = False
        Dim strMsg As String = ""

        If MainView.GetRowCellValue(rHandle + 1, MainView.Columns("DateStarted")) >= MainView.GetRowCellValue(rHandle, MainView.Columns("DateStarted")) Then
            strMsg = "Start date of activity must be later than the start date of the previous activity."
            hasErr = True
        End If

        If IsDBNull(MainView.GetRowCellValue(rHandle, MainView.Columns("DateEnded"))) = False Then
            'If MainView.GetRowCellValue(rHandle, MainView.Columns("DateEnded")) <= MainView.GetRowCellValue(rHandle, MainView.Columns("DateStarted")) Then
            '    strMsg = "Start date of activity must be earlier than it's end date."
            '    hasErr = True
            'End If
            If IsDBNull(MainView.GetRowCellValue(rHandle - 1, MainView.Columns("DateEnded"))) = False Then
                If IsNothing(MainView.GetRowCellValue(rHandle - 1, MainView.Columns("DateEnded"))) = False Then
                    If MainView.GetRowCellValue(rHandle - 1, MainView.Columns("DateEnded")) <= MainView.GetRowCellValue(rHandle, MainView.Columns("DateEnded")) Then
                        strMsg = "End date of activity must be later than the end date of the next activity."
                        hasErr = True
                    End If
                End If
            End If
        End If

        arrRes.Add(hasErr)
        arrRes.Add(strMsg)
        Return arrRes
    End Function
#End Region

#Region "Editing Values"
    Private Sub deStart_EditValueChanged(sender As Object, e As System.EventArgs) Handles deStart.EditValueChanged
        If Not isLoadingData Then
            If MainView.RowCount > 0 Then
                MainView.SetFocusedRowCellValue("DateStarted", deStart.EditValue)
                MainView.SetFocusedRowCellValue("isEdited", "Yes")
                If MainView.IsValidRowHandle(MainView.FocusedRowHandle + 1) Then
                    MainView.SetRowCellValue(MainView.FocusedRowHandle + 1, "DateEnded", DateAdd(DateInterval.Day, -1, deStart.EditValue))
                    MainView.SetRowCellValue(MainView.FocusedRowHandle + 1, "isEdited", "Yes")
                End If
            End If
        End If
    End Sub

    Private Sub deEnd_EditValueChanged(sender As Object, e As System.EventArgs) Handles deEnd.EditValueChanged
        If Not isLoadingData Then
            If MainView.RowCount > 0 Then
                MainView.SetFocusedRowCellValue("DateEnded", deEnd.EditValue)
                MainView.SetFocusedRowCellValue("isEdited", "Yes")
                If MainView.IsValidRowHandle(MainView.FocusedRowHandle - 1) Then
                    MainView.SetRowCellValue(MainView.FocusedRowHandle - 1, "DateStarted", DateAdd(DateInterval.Day, 1, deEnd.EditValue))
                    MainView.SetRowCellValue(MainView.FocusedRowHandle - 1, "isEdited", "Yes")
                End If
            End If
        End If
    End Sub

    Private Sub leEnd_EditValueChanged(sender As Object, e As System.EventArgs) Handles leEnd.EditValueChanged
        If Not isLoadingData Then
            If MainView.RowCount > 0 Then
                MainView.SetFocusedRowCellValue("PlaceSOff", leEnd.EditValue)
                MainView.SetFocusedRowCellValue("isEdited", "Yes")
            End If
        End If
    End Sub

    Private Sub leStart_EditValueChanged(sender As Object, e As System.EventArgs) Handles leStart.EditValueChanged
        If Not isLoadingData Then
            If MainView.RowCount > 0 Then
                MainView.SetFocusedRowCellValue("PlaceSOn", leStart.EditValue)
                MainView.SetFocusedRowCellValue("isEdited", "Yes")
            End If
        End If
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If Not isLoadingData Then AllowSaving(Name, True)
    End Sub

    Private Sub deStart_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles deStart.EditValueChanging
        If Not isLoadingData Then AllowSaving(Name, True)
    End Sub
#End Region

#Region "Saving"
    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Amend", 0, System.Environment.MachineName, "Amend_desc", "Activity", strCrewID)

        MainView.Focus()

        If MsgBox("Are you sure you want to save the changes to this activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = MsgBoxResult.Yes Then
            For i As Integer = 0 To MainView.DataRowCount - 1
                If MainView.GetRowCellValue(i, "isEdited") = "Yes" Then
                    If ValidateEditedRow(i)(0) Then
                        MsgBox("Please fix invalid input.", MsgBoxStyle.Information, GetAppName() & " - Activity")
                        Exit Sub
                    Else

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Amend", 0, System.Environment.MachineName, "Amend_desc", "Activity", strCrewID)

                        If IfNull(MainView.GetRowCellValue(i, "DateEnded"), "") = "" Then
                            sqls.Add("EXEC [dbo].[SP_AMEND] @ActID = '" & MainView.GetRowCellValue(i, "ActID") & "', @NewDateStart = " & ChangeToSQLDate(MainView.GetRowCellValue(i, "DateStarted").ToString) & ", @NewDateEnd = NULL, @NewPlaceSON = '" & MainView.GetRowCellValue(i, "PlaceSOn") & "', @NewPlaceSOFF = '" & MainView.GetRowCellValue(i, "PlaceSOff") & "', @LastUpdatedBy = '" & LastUpdatedBy & "'")
                        Else
                            sqls.Add("EXEC [dbo].[SP_AMEND] @ActID = '" & MainView.GetRowCellValue(i, "ActID") & "', @NewDateStart = " & ChangeToSQLDate(MainView.GetRowCellValue(i, "DateStarted").ToString) & ", @NewDateEnd = " & ChangeToSQLDate(MainView.GetRowCellValue(i, "DateEnded").ToString) & ", @NewPlaceSON = '" & MainView.GetRowCellValue(i, "PlaceSOn") & "', @NewPlaceSOFF = '" & MainView.GetRowCellValue(i, "PlaceSOff") & "', @LastUpdatedBy = '" & LastUpdatedBy & "'")
                        End If
                        MainView.SetRowCellValue(i, "isEdited", "")
                    End If
                End If
            Next

            MsgBox(GetMessage("Saved", DB.RunSqls(sqls)), MsgBoxStyle.Information, GetAppName)
            RefreshData()
        End If
    End Sub
#End Region

 
End Class
