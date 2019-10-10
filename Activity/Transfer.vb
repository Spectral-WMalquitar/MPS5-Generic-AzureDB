Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils

Public Class Transfer
    Friend dtMainview As New DataTable
    Dim _deleteid As String
    Dim clsAudit As New clsAudit 'neil
    Dim strFilter, strStatFilter As String
    Dim downHitInfo As GridHitInfo = Nothing
    Dim isGridRequiredFieldsIncomplete As Boolean = False

    Dim clsConflict As New clsCrewConflict
    Dim clsActDoc As New clsActivityDocs_temptbl("Transfer", MPSDB)

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If bLoaded = False Then
            SetSaveCaption(Name, "Transfer")
            blList.Draggable(True)

            'Create columns for Mainview's datatable
            InitData()
            'Apply ashore only filter
            InitFilter()

            'Get updated datasource for dropdown lists.
            cboNewVessel.Properties.DataSource = VesselList(DB)
            cboPlaceSON.Properties.DataSource = PortList(DB)
            cboPlaceSOFF.Properties.DataSource = cboPlaceSON.Properties.DataSource
            cboVessel.Properties.DataSource = cboNewVessel.Properties.DataSource
            lkuWScaleRank.DataSource = WageRankScaleList(DB)
            lkuCurWScaleRank.DataSource = WageRankScaleList(DB)

            'Get updated datasource for mainview's dropdown lists.
            PortEdit.DataSource = cboPlaceSON.Properties.DataSource
            VesselEdit.DataSource = cboNewVessel.Properties.DataSource

            'Set audittrail's connection string
            clsAudit.propSQLConnStr = DB.GetConnectionString
            BRECORDUPDATEDs = False

            bLoaded = True

            SetActivityActivityDocsRpgVisibility(Name, True)
        End If
    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim msg As String = ""
        Dim strIDNbr As String = ""
        Dim strUpdatedBy As String = ""
        cboVessel.Focus()

        'Welly
        Dim selectedCrew As New Utilities.SelectedCrew()
        Dim sickOnbCrew As New Utilities.SelectedCrew()
        Dim listOfSelectedCrews As New List(Of Utilities.SelectedCrew)
        Dim listOfSickOnbCrews As New List(Of Utilities.SelectedCrew)
        Dim hasQualifyForMedHistory As Boolean = False
        Dim medHistoryLabel As String = ""
        'end welly

        If checkRequiredFields() = True Then
            'BRECORDUPDATEDs = False
            Exit Sub
        End If

        'edited by tony20170904
        'If MsgBox("Are you sure you want to add activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
        If MsgBox("Are you sure you want transfer the crew/s?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
            Exit Sub
        End If

        Dim tempWSCaleRankCode As Object

        For i As Integer = 0 To Mainview.RowCount - 1

            tempWSCaleRankCode = getRowCellValue(i, "FKeyWScaleRankCode") 'neil
            If tempWSCaleRankCode Is DBNull.Value Then
                tempWSCaleRankCode = getRowCellValue(i, "curFKeyWScaleRankCode")
            End If

            strIDNbr = getRowCellValue(i, "IDNbr").ToString
            strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "INSERT_ACT_HERE", 0, System.Environment.MachineName, "DESC_HERE", "Activity", strIDNbr)

            strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Transfered")
            sqls.Add("EXEC SP_TRANSFER @CurrActID = '" & getRowCellValue(i, "CurrActID") & "', " & _
                     "@ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "'," & _
                     "@DateSON = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSON").ToString) & ", " & _
                     "@PlaceSON = '" & getRowCellValue(i, "PlaceSON") & "', " & _
                     "@DateSOFF = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSOFF").ToString) & "," & _
                     "@PlaceSOFF = '" & getRowCellValue(i, "PlaceSOFF") & "', " & _
                     "@FKeyVslCode = '" & getRowCellValue(i, "FKeyVessel") & "'," & _
                     "@RelievedID = '', @Remarks = '" & getRowCellValue(i, "Remarks") & "', @LastUpdatedBy = '" & strUpdatedBy & "'," & _
                     "@IDNbr = '" & strIDNbr & "', @parFKeyWScaleRankCode ='" & tempWSCaleRankCode & "', @activitykeyOut = @activitykeyOut output, @crewidnbrOut = @crewidnbrOut output")
            '"@IDNbr = '" & strIDNbr & "',@activitykeyOut = @activitykeyOut output, @crewidnbrOut = @crewidnbrOut output")

            Mainview.SelectRow(i)
            msg = "Transfer complete."

            clsActDoc.updateDateIssue(strIDNbr, Mainview.GetRowCellValue(i, "DateSON"))
        Next

        If sqls.Count > 0 Then

            Dim colname As New ArrayList, dt As New DataTable
            colname.Add("activitykeyOut") '/// should be the same name as in the sql without the @ sign. pls check above
            colname.Add("crewidnbrOut") '/// should be the same name as in the sql without the @ sign. pls check above

            If MPSDB.RunSqls(sqls, colname, dt, True) = True Then

                If dt.Rows.Count > 0 Then '//save image doc per
                    For Each row As DataRow In dt.Rows
                        clsActDoc.saveDtToDb(row("activitykeyOut"), row("crewidnbrOut"))
                    Next
                End If

                MsgBox(msg, MsgBoxStyle.Information, GetAppName() & " - Activity")
                Mainview.DeleteSelectedRows()
                'forceRefresh(True)
                blList.RefreshData()
                BRECORDUPDATEDs = False
                InitFilter()

                cboVessel.EditValue = Nothing
                cboNewVessel.EditValue = Nothing
                cboPlaceSOFF.EditValue = Nothing
                cboPlaceSON.EditValue = Nothing
                deDateSOFF.EditValue = Nothing
                deDateSON.EditValue = Nothing
            End If
        End If

        isGridRequiredFieldsIncomplete = False
    End Sub

    Private Sub InitFilter()
        strStatFilter = "(StatCode='SYSONB' OR StatCode='SYSSICKONB') AND VslName = '" & cboVessel.Text & "'"
        If strCrewListFilter <> "" Then
            If strStatFilter <> "" Then
                strFilter = "(" & strStatFilter & " AND " & Replace(strCrewListFilter, "''", "'") & ")"
            Else
                strFilter = "(" & strStatFilter & ")"
            End If
        Else
            strFilter = strStatFilter
        End If
        strBContentFilter = strStatFilter
        blList.SetFilter(strFilter)
    End Sub

    Private Sub InitData()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "CurrActID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActGrpID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "CurrentVessel"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSOFF"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlaceSOFF"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyVessel"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSON"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlaceSON"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "curFKeyWScaleRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyWScaleRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        Maingrid.DataSource = dtMainview
    End Sub

    Public Overrides Sub DeleteData()
        Dim i As Integer = 0
        While i < Mainview.RowCount
            If _deleteid.Contains(";" & Mainview.GetRowCellValue(i, "IDNbr") & ";") Then
                Mainview.DeleteRow(i)
                i = -1
            End If
            i += 1
        End While
        _deleteid = ""
        Mainview.RefreshData()
        Mainview.ClearSelection()
        If Mainview.RowCount > 0 Then
            Mainview.FocusedRowHandle = 0
            Mainview.SelectRow(0)
        End If
        If Mainview.RowCount = 0 Then AllowSaving(Name, False)
    End Sub

    Private Sub Mainview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Mainview.CellValueChanged
        If e.Column.FieldName = "DateSOFF" Then
            If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateSOFF"), "") <> "" Then
                If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateSON"), "") = "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "DateSON", DateAdd(DateInterval.Day, 1, Mainview.GetRowCellValue(e.RowHandle, "DateSOFF")))
                End If
            End If

        ElseIf e.Column.FieldName = "DateSON" Then
            If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateSON"), "") <> "" Then
                If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateSOFF"), "") = "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "DateSOFF", DateAdd(DateInterval.Day, -1, Mainview.GetRowCellValue(e.RowHandle, "DateSON")))
                End If
            End If

        End If
    End Sub

#Region "Drag N'Drop"

    

    Private Sub MainView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mainview.MouseDown
        Dim view As GridView = CType(sender, GridView)

        downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

        If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
            Exit Sub
        End If

        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub MainView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mainview.MouseMove
        Dim view As GridView = CType(sender, GridView)
        If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim DragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)
            If Not DragRect.Contains(New Point(e.X, e.Y)) Then
                view.GridControl.DoDragDrop(GetSelectedRows(), DragDropEffects.Move)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragDrop
        If Me.cboNewVessel.EditValue = "" Then
            MsgBox("Please select New Vessel.", vbExclamation)
            Exit Sub
        End If
        Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
        If Mainview.RowCount = 0 Then isGridRequiredFieldsIncomplete = False 'added by tony20170508
        If Not xtbl Is Nothing Then

            '//// Neil 20170814 crew conflict feature
            Dim dtres As New DataTable
            dtres = clsConflict.CrewConflict_GetCrewWithConflict(xtbl.Rows(0)("IDNbr"), dtMainview, "IDNbr", MPSDB.GetConnectionString)

            If dtres.Rows.Count > 0 Then
                If MsgBox("Crew " & xtbl.Rows(0)("Crew") & " is conflict with crew " & dtres.Rows(0)("CConflictName") & ", do you want to continue?", vbExclamation + vbYesNo) = vbNo Then
                    Exit Sub
                End If
            End If

            Dim dtcrewlist As New DataTable
            dtcrewlist = MPSDB.CreateTable("select * from view_CrewConflict_ONB where FKeyVslCode ='" & cboNewVessel.EditValue & "'")
            dtres = clsConflict.CrewConflict_GetCrewWithConflict(xtbl.Rows(0)("IDNbr"), dtcrewlist, "FKeyIDNbr", MPSDB.GetConnectionString)

            If dtres.Rows.Count > 0 Then
                If MsgBox("Crew " & xtbl.Rows(0)("Crew") & " is conflict with crew " & dtres.Rows(0)("CConflictName") & " on-board the vessel " & cboNewVessel.Text & ", do you want to continue?", vbExclamation + vbYesNo) = vbNo Then
                    Exit Sub
                End If
            End If

            '///////////

            strFilter = strStatFilter
            Try
                For Each nrow In xtbl.Rows

                    If DB.DLookUp("FKeyStatCode", "tblActivity", "", "PKey = '" & IfNull(nrow("CurrActID"), "") & "'") = "SYSSICKONB" Then
                        MsgBox("Cannot transfer sick onboard crew, " & nrow("Crew") & ". Please end sick onboard status first.")
                    Else
                        Dim Reliever As String = DB.DLookUp("CrewName", "view_PlannedCrews_WithRelieverOnly", "", "ToRelieveID = '" & IfNull(nrow("CurrActID"), "") & "'")
                        If Not IfNull(Reliever, "").Equals("") Then
                            MsgBox("Cannot transfer this crew because he is currently planned to be relieved by: " & Reliever & vbNewLine & vbNewLine & "Cancel the above crew's planning first before you can proceed with the selected crew's vessel transfer.", MsgBoxStyle.Information)
                        Else

                            'neil 20180116
                            Dim crewnatCode As String, strWScaleRank As Object
                            crewnatCode = MPSDB.DLookUp("PKey", "tblAdmCntry", "", "Nat='" & nrow("nat") & "'")
                            strWScaleRank = getNatWScaleRank(cboNewVessel.EditValue, nrow("FKeyRankCode"), crewnatCode, "", False)

                            If strWScaleRank = "" Then
                                '<!-- edited by tony20180130
                                'strWScaleRank = DBNull.Value
                                strWScaleRank = nrow("FKeyWScaleRankCode")
                                '-->
                            End If
                            Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("Crew"), nrow("VslName"), deDateSOFF.EditValue, cboPlaceSOFF.EditValue, cboNewVessel.EditValue, deDateSON.EditValue, cboPlaceSON.EditValue, nrow("FKeyWScaleRankCode"), strWScaleRank}
                            dtMainview.Rows.Add(xrow)
                        End If
                    End If
                Next
            Catch ex As Exception
                LogErrors(ex.Message)
                'MsgBox(ex.Message)
            End Try

            For Each nrow In dtMainview.Rows
                strFilter = strFilter & " AND IDNbr <> '" & nrow("IDNbr") & "'"
                strBContentFilter = strFilter
            Next

            If strCrewListFilter <> "" Then
                'strFilter = "(" & strFilter & " AND " & strCrewListFilter & ")"
                strFilter = "(" & strFilter & " AND " & Replace(strCrewListFilter, "''", "'") & ")"
            End If

            Mainview.RefreshData()
            If Mainview.RowCount > 0 Then
                AllowSaving(Name, True)
                Mainview.SelectRow(0)
                BRECORDUPDATEDs = True
            Else
                BRECORDUPDATEDs = False
            End If
            blList.SetFilter(strFilter)
        End If
    End Sub

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Function GetSelectedRows() As DataTable
        Dim ntbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        ntbl.Columns.Add(ccolumn)
        _deleteid = ";"

        For Each xrow In Mainview.GetSelectedRows
            Mainview.GetDataRow(xrow).ClearErrors()
            _deleteid = _deleteid & Mainview.GetRowCellValue(xrow, "IDNbr") & ";"
            ntbl.ImportRow(Mainview.GetDataRow(xrow))
        Next

        If (Mainview.RowCount) - (Mainview.GetSelectedRows.Count) = 0 Then
            BRECORDUPDATEDs = False
        End If

        Return ntbl
    End Function
#End Region

#Region "EditValueChanged"
    Private Sub cboVessel_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboVessel.EditValueChanging
        If BRECORDUPDATEDs = True Then
            If CheckValidateFields() = True Then
                Exit Sub
            Else
                If ALLOWNEXTS = False Then e.Cancel = True
            End If
        End If

        If cboNewVessel.EditValue <> "" Then
            e.Cancel = cboNewVessel.EditValue = e.NewValue
            If e.Cancel = True Then MsgBox("Cannot transfer to the same vessel.")
        End If
    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        Mainview.SelectAll()
        Mainview.DeleteSelectedRows()
        InitFilter()
        BRECORDUPDATEDs = False
    End Sub

    Private Sub cboReason_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboNewVessel.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "FKeyVessel", cboNewVessel.EditValue)
            Mainview.SetRowCellValue(i, "FKeyWScaleRankCode", DBNull.Value)
        Next
    End Sub

    Private Sub deDateSOFF_EditValueChanged(sender As Object, e As System.EventArgs) Handles deDateSOFF.EditValueChanged
        If Not IsNothing(deDateSOFF.EditValue) Then         '<-- added by tony20170406
            For i As Integer = 0 To Mainview.RowCount - 1
                Mainview.SetRowCellValue(i, "DateSOFF", deDateSOFF.EditValue)
            Next

            If IsDate(deDateSOFF.EditValue) Then
                If IsNothing(deDateSON.EditValue) Or IfNull(deDateSON.EditValue, "").Equals("") Then
                    deDateSON.EditValue = DateAdd(DateInterval.Day, 1, deDateSOFF.EditValue) '<-- added by tony20170406
                    '<!-- added by tony20170927
                Else
                    If IsDate(deDateSON.EditValue) Then
                        If deDateSON.EditValue <= deDateSOFF.EditValue Then
                            deDateSON.EditValue = DateAdd(DateInterval.Day, 1, deDateSOFF.EditValue)
                        End If
                    End If
                    '-->
                End If
            End If

        End If
    End Sub

    Private Sub cboPlaceSignOff_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPlaceSOFF.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "PlaceSOFF", cboPlaceSOFF.EditValue)
        Next
    End Sub

    Private Sub deDateSON_EditValueChanged(sender As Object, e As System.EventArgs) Handles deDateSON.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "DateSON", deDateSON.EditValue)
        Next

        If IsDate(deDateSON.EditValue) Then
            If IsNothing(deDateSOFF.EditValue) Or IfNull(deDateSOFF.EditValue, "").Equals("") Then
                deDateSOFF.EditValue = DateAdd(DateInterval.Day, -1, deDateSON.EditValue) '<-- added by tony20170406
                '<!-- added by tony20170927
            Else
                If IsDate(deDateSOFF.EditValue) Then
                    If deDateSOFF.EditValue >= deDateSON.EditValue Then
                        deDateSOFF.EditValue = DateAdd(DateInterval.Day, -1, deDateSON.EditValue)
                    End If
                End If
                '-->
            End If
        End If
    End Sub

    Private Sub cboPlaceSON_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPlaceSON.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "PlaceSON", cboPlaceSON.EditValue)
        Next
    End Sub
#End Region

#Region "Validation"
    Private Sub ToolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        If Not e.SelectedControl Is Maingrid Then Return
        Dim info As ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As GridView = Maingrid.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells
        If hi.HitTest = GridHitTest.RowIndicator Then
            'An object that uniquely identifies a row indicator cell
            Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
            Dim currAct As Columns.GridColumn = view.Columns("CurrActID")
            Dim text As String = AllowSignOff(hi.RowHandle)(1)
            info = New ToolTipControlInfo(o, text)
        End If
        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub

    Private Sub MainView_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles Mainview.CustomDrawRowIndicator
        Dim view As Views.Grid.GridView = CType(sender, Views.Grid.GridView)
        Dim currAct As Columns.GridColumn = view.Columns("CurrActID")
        Dim hasError As Boolean = False

        If e.Info.IsRowIndicator AndAlso e.RowHandle >= 0 Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)

            Dim rec As Rectangle = e.Bounds
            Dim img As Image = New System.Drawing.Bitmap(DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"))
            rec.Inflate(-1, -1)
            Dim x1 As Integer = rec.X + (rec.Width - img.Width) / 2
            Dim y1 As Integer = rec.Y + (rec.Height - img.Height) / 2
            Dim strMsg As String = ""

            If AllowSignOff(e.RowHandle)(0) = True Then
                e.Graphics.DrawImageUnscaled(img, x1, y1)
                e.Handled = True
            End If

        End If
    End Sub

    Private Function AllowSignOff(ByVal rHandle As Integer) As ArrayList
        Dim arrRes As New ArrayList
        Dim currAct As Columns.GridColumn = Mainview.Columns("CurrActID")
        Dim hasErr As Boolean = False
        Dim strMsg As String = ""

        If IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSON"))) = False Then
            If validateActivity(Mainview.GetRowCellValue(rHandle, currAct), Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSON"))) = False Then
                hasErr = True
                strMsg = "Date sign-on must be later than the current activity."
            End If
            If IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSOFF"))) = False Then
                If Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSOFF")) >= Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSON")) Then
                    hasErr = True
                    strMsg = "Sign-off date must be earlier than sign-on date."
                End If
                If validateActivity(Mainview.GetRowCellValue(rHandle, currAct), Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSOFF"))) = False Then
                    hasErr = True
                    strMsg = "Sign-off date must be later than the current activity."
                End If
            End If
        End If

        arrRes.Add(hasErr)
        arrRes.Add(strMsg)
        Return arrRes
    End Function


    Private Function validateActivity(ByVal currAct As String, ByVal ActStartDate As Date) As Boolean
        Dim res As Boolean = True
        Try
            If currAct <> "" Then
                Dim CurrAct_StartDate As Date
                CurrAct_StartDate = MPSDB.DLookUp("ActDateStart", "tblActivity", "", "Pkey='" & currAct & "'")
                If ActStartDate <= CurrAct_StartDate Then
                    res = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogErrors(ex.Message)
        End Try
        Return res
    End Function

    Private Function checkRequiredFields() As Boolean
        Dim res As Boolean = False
        Dim clm, cmln As New DevExpress.XtraGrid.Columns.GridColumn

        If IfNull(cboNewVessel.EditValue, "") = "" Then
            MsgBox("Please select the new vessel.", MsgBoxStyle.Information, GetAppName() & " - Activity")
            cboNewVessel.Focus()
            res = True
            Return res
            Exit Function
        End If

        For i As Integer = 0 To Mainview.RowCount - 1
            For Each clm In Mainview.Columns
                If clm.Tag = "Required" And IfNull(Mainview.GetRowCellValue(i, clm), "") = "" Then 'IsDBNull(Mainview.GetRowCellValue(i, clm)) = True Then
                    Mainview.FocusedRowHandle = i
                    isGridRequiredFieldsIncomplete = True
                    Mainview.UpdateCurrentRow()
                    MsgBox("Please complete the required fields.", MsgBoxStyle.Information, GetAppName() & " - Activity")
                    res = True
                    Return res
                    Exit Function
                End If

                If AllowSignOff(i)(0) Then
                    MsgBox("Please fix invalid input.", MsgBoxStyle.Information, GetAppName() & " - Activity")
                    res = True
                    Return res
                    Exit Function
                End If
            Next
        Next
        Return res
    End Function

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If checkRequiredFields() Or Mainview.HasColumnErrors = True Then
                flag = False
                ALLOWNEXTS = flag
            Else
                flag = True
                ALLOWNEXTS = flag
                SaveData() '
            End If
        ElseIf res = MsgBoxResult.No Then
            BRECORDUPDATEDs = False
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

#End Region

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        If Mainview.IsRowSelected(e.RowHandle) And e.Column.Tag = "Required" Then
            If IsDBNull(e.CellValue) Then
                e.Appearance.BackColor = REQUIRED_SELECTED_COLOR
                If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "Required field must not be blank.")
            Else
                If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "")
            End If
        ElseIf Mainview.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
            e.Appearance.ForeColor = Color.Black
        Else
            If e.Column.Tag = "Required" Then
                If IsDBNull(e.CellValue) Then
                    e.Appearance.BackColor = REQUIRED_COLOR
                    If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "Required field must not be blank.")
                Else
                    If isGridRequiredFieldsIncomplete Then Mainview.SetColumnError(e.Column, "")
                End If
            End If
        End If
    End Sub

    Public Sub ClearLayoutControls(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup, ByVal bFormatOnly As Boolean)
        For a As Integer = 0 To cContainer.Items.Count - 1
            If TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim cItem As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(a), DevExpress.XtraLayout.LayoutControlItem)
                Dim ctr As System.Windows.Forms.Control = cItem.Control
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue = System.DBNull.Value
                    If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                        ctr.BackColor = REQUIRED_COLOR
                    Else
                        ctr.BackColor = Color.White
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Transfer_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        strBContentFilter = ""
        dtMainview.Dispose()
        _deleteid = Nothing
        clsAudit = Nothing
        strFilter = Nothing
        strStatFilter = Nothing
        downHitInfo = Nothing
    End Sub

    Private Function getRowCellValue(row As Integer, columnName As String)
        Try
            Return IfNull(Mainview.GetRowCellValue(row, columnName), "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

#Region "Save/Load Layout"
    Public Overrides Sub SaveMainContentLayout()
        MyBase.SaveMainContentLayout()
        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
        Mainview.SaveLayoutToXml(strLayoutPath & Me.Name & "_Mainview.xml")
        LayoutControl1.SaveLayoutToXml(strLayoutPath & Me.Name & "_Layout.xml")
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        Try
            MyBase.LoadMainContentLayout()
            Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
            Mainview.RestoreLayoutFromXml(strLayoutPath & Me.Name & "_Mainview.xml")
            LayoutControl1.RestoreLayoutFromXml(strLayoutPath & Me.Name & "_Layout.xml")
        Catch ex As Exception
            'Wala talagang laman to. Para pag wala syang nakita default lang. :D
        End Try
    End Sub
#End Region

  
    Private Sub cboNewVessel_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboNewVessel.EditValueChanging
        If cboVessel.EditValue <> "" Then
            e.Cancel = cboVessel.EditValue = e.NewValue
            If e.Cancel = True Then
                MsgBox("Cannot transfer to the same vessel.")
                Exit Sub
            End If
        End If

        If Not SignOn.VesselValidForSelection(cboVessel, e.NewValue) Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Dim ermsg As String = "", tempvPKey As Integer = 0
        'MsgBox("test")
        Select Case param(0)
            Case "ACTIVITYDOCS"
                'MsgBox(Me.SeaServView.GridControl.ContainsFocus)
                'MsgBox(mainview.Name)
                'Dim _CurrActId As String = IfNull(Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "ActID"), "")
                Mainview.PostEditor()

                Dim crewId As String = IfNull(Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "IDNbr"), "")
                ' Dim dson As Date = Me.deDateSON.EditValue
                Dim dson As Date = IIf(Mainview.GetRowCellDisplayText(Mainview.FocusedRowHandle, "DateSON") = "",
                                                  Nothing, Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "DateSON"))

                Dim vslname As String = Me.cboNewVessel.Text

                If crewId = "" Or crewId Is DBNull.Value Then
                    MsgBox("Please select Crew.", vbExclamation)
                    Exit Select
                End If

                If Not IsDate(dson) Or dson = Nothing Then
                    MsgBox("Please enter Date Sign On.", vbExclamation)
                    Exit Select
                End If

                If vslname = "" Or vslname Is Nothing Then
                    MsgBox("Please select Vessel.", vbExclamation)
                    Exit Select
                End If

                'If crewId <> "" And Not crewId Is DBNull.Value And _
                '        IsDate(Me.deDateSON.EditValue) And _
                '        vslname <> "" And Not vslname Is Nothing Then
                ' MsgBox(_CurrActId)

                ' If _CurrActID <> "" Then
                Dim activitydocsfrm As New frmActivityDocs(clsActDoc, crewId, dson, vslname, , Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "Crew"))
                activitydocsfrm.ShowDialog()
                'Else
                'End If
                'Else
                'End If

        End Select
    End Sub

    Private Sub lkuWScaleRank_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lkuWScaleRank.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Function getSuggestedWScale(natcode As String, vslcode As String, rankcode As String, strWScaleRank As String, Optional ask As Boolean = True) As String
        Dim ret As String = ""

        'Dim lkurank As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
        'Dim strWScaleRank As String = ""
        'Dim vslWScaleRank As String = ""
        'Dim natcode As String, vslcode As String, rankcode As String

        'natcode = MPSDB.DLookUp("PKey", "tblAdmCntry", "", "Nat='" & Mainview.GetFocusedRowCellDisplayText("Nat") & "'")
        'vslcode = Mainview.GetFocusedRowCellDisplayText("FKeyVslCode")
        'rankcode = lkurank.EditValue

        'strWScaleRank = getNatWScaleRank(vslcode, rankcode, natcode, strWScaleRank)
        strWScaleRank = getNatWScaleRank(vslcode, rankcode, natcode, "")

        Mainview.SetFocusedRowCellValue("FKeyWScaleRank", strWScaleRank)

        Return ret
    End Function
End Class
