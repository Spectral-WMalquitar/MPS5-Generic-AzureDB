Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class AshoreActivity
    Friend dtMainview As New DataTable
    Dim _deleteid As String
    Dim clsAudit As New clsAudit 'neil
    Dim strFilter, strStatFilter As String
    Dim downHitInfo As GridHitInfo = Nothing
    Dim isGridRequiredFieldsIncomplete As Boolean = False

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If bLoaded = False Then
            SetSaveCaption(Name, "Add Ashore Activity")

            blList.Draggable(True)

            'Create columns for Mainview's datatable
            InitData()
            'Apply ashore only filter
            InitFilter()

            'Get updated datasource for dropdown lists.
            cboNxtAct.Properties.DataSource = AshoreStatusList(DB)
            cboStartPlace.Properties.DataSource = PortList(DB)
            cboEndPlace.Properties.DataSource = cboStartPlace.Properties.DataSource
            cboWScale.Properties.DataSource = WageScaleList(DB)

            'Get updated datasource for mainview's dropdown lists.
            PortEdit.DataSource = cboStartPlace.Properties.DataSource
            AshoreStatusEdit.DataSource = cboNxtAct.Properties.DataSource
            RankEdit.DataSource = RankList(DB)
            WageScaleRankEdit.DataSource = WageRankScaleList(DB)
            'tony20180108
            cboWScale.EditValue = modAdminData.UndefinedWScaleCode
            'end tony

            'Set audittrail's connection string
            clsAudit.propSQLConnStr = DB.GetConnectionString
            BRECORDUPDATEDs = False
            bLoaded = True
        End If
    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim msg As String = ""
        Dim strIDNbr As String = ""
        Dim strUpdatedBy As String = ""
        cboNxtAct.Focus()

        'Welly
        Dim selectedCrew As New Utilities.SelectedCrew()
        Dim listOfSelectedCrews As New List(Of Utilities.SelectedCrew)
        Dim hasQualifyForMedHistory As Boolean = False
        Dim medHistoryLabel As String = ""
        'end welly

        If checkRequiredFields() = True Then
            'BRECORDUPDATEDs = False
            Exit Sub
        End If

        'edited by tony20170904
        'If MsgBox("Are you sure you want to add activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
        If MsgBox("Are you sure you want to add an ashore activity/s?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
            Exit Sub
        End If

        For i As Integer = 0 To Mainview.RowCount - 1
            strIDNbr = getRowCellValue(i, "IDNbr").ToString
            strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "INSERT_ACT_HERE", 0, System.Environment.MachineName, "DESC_HERE", "Activity", strIDNbr)

            strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Add Ashore Activity.")
            sqls.Add("EXEC SP_SIGN_OFF @IDNbr = '" & getRowCellValue(i, "IDNbr") & "', " & _
                     "@ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "'," & _
                     "@CurrActID = '" & getRowCellValue(i, "CurrActID") & "'," & _
                     "@DateArr = '', @PlaceArr ='" & Nothing & "', " & _
                     "@DateSOFF = '" & Nothing & "'," & _
                     "@PlaceSOFF = '', @PlaceStart = '" & getRowCellValue(i, "StartPlace") & "', " & _
                     "@StatCode = '', @LastUpdatedBy = '" & strUpdatedBy & "', " & _
                     "@Remarks = '" & getRowCellValue(i, "Remarks") & "'," & _
                     "@NxtAct = '" & getRowCellValue(i, "NextActivity") & "', " & _
                     "@NxtActDateStart = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateStart").ToString) & ", " & _
                     "@PlaceEnd = '" & getRowCellValue(i, "EndPlace") & "', " & _
                     "@RankCode = '" & getRowCellValue(i, "FKeyRank") & "', @RelieverID = '', @FKeyWScaleRank = '" & getRowCellValue(i, "FKeyWScaleRank") & "'")

            '<!-- edited by tony20180709  If (MPSDB.DLookUp("IncludeMedHistory", "tblAdmStat", False, "PKey='" & getRowCellValue(i, "NxtAct") & "'") = True) Then
            If (MPSDB.DLookUp("IncludeMedHistory", "tblAdmStat", False, "PKey='" & getRowCellValue(i, "NextActivity") & "'") = True) Then
                selectedCrew = New Utilities.SelectedCrew()
                selectedCrew.CrewIDNbr = getRowCellValue(i, "IDNbr")
                selectedCrew.ActivityID = getRowCellValue(i, "CurrActID")
                selectedCrew.ActivityGroupID = getRowCellValue(i, "ActGrpID")
                selectedCrew.RankName = Mainview.GetRowCellDisplayText(i, "FKeyRank")
                selectedCrew.FirstName = getRowCellValue(i, "Crew")

                listOfSelectedCrews.Add(selectedCrew)
            End If
            medHistoryLabel = "Crew Ashore Activity"

            Mainview.SelectRow(i)
            msg = "Ashore activity successfuly added."
        Next

        If sqls.Count > 0 Then
            If MPSDB.RunSqls(sqls, True) = True Then

                If listOfSelectedCrews.Count > 0 Then
                    Dim message = "Create Medical History for selected crew" & IIf(listOfSelectedCrews.Count > 1, "s", "") & "?"
                    If (MessageBox.Show(message, "Create Medical History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        Dim medHistory As New Crewing.frmPopupMedHistory(listOfSelectedCrews, medHistoryLabel) 'Showing pop-up window for medical history. 
                        medHistory.ShowDialog()
                        listOfSelectedCrews.Clear()
                    End If
                End If

                MsgBox(msg, MsgBoxStyle.Information, GetAppName() & " - Activity")
                Mainview.DeleteSelectedRows()
                ClearFields(grpASHACT, False)
                cboWScale.EditValue = modAdminData.UndefinedWScaleCode
                'forceRefresh(True)
                blList.RefreshData()
                BRECORDUPDATEDs = False
                InitFilter()
            End If
        End If

        isGridRequiredFieldsIncomplete = False
    End Sub

    Private Sub InitFilter()
        strStatFilter = "(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')"
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
        ccolumn.ColumnName = "FKeyRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyWScaleRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "NextActivity"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateStart"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "StartPlace"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "EndPlace"
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
        Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
        If Mainview.RowCount = 0 Then isGridRequiredFieldsIncomplete = False 'added by tony20170508
        If Not xtbl Is Nothing Then
            strFilter = strStatFilter
            Try
                For Each nrow In xtbl.Rows
                    Dim dr() As DataRow = Nothing
                    Dim strWScaleRank As String = ""

                    If IfNull(nrow("FkeyRankCode"), "") <> "" And IfNull(cboWScale.EditValue, "") <> "" Then
                        If cboWScale.EditValue = modAdminData.UndefinedWScaleCode Then
                            dr = WageScaleRankEdit.DataSource.Select("RankCode = '" & modAdminData.UndefinedRankCode & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
                        Else
                            dr = WageScaleRankEdit.DataSource.Select("RankCode = '" & nrow("FkeyRankCode") & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
                        End If

                    End If


                    If dr IsNot Nothing Then
                        If dr.Count > 0 Then
                            strWScaleRank = IfNull(dr(0)("PKey"), "")
                        End If
                    End If

                    Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("Crew"), nrow("FkeyRankCode"), strWScaleRank, cboNxtAct.EditValue, deStartDate.EditValue, cboStartPlace.EditValue, cboEndPlace.EditValue}
                    dtMainview.Rows.Add(xrow)
                Next
            Catch ex As Exception
                LogErrors(ex.Message)
            End Try

            For Each nrow In dtMainview.Rows
                strFilter = strFilter & " AND IDNbr <> '" & nrow("IDNbr") & "'"
                strBContentFilter = strFilter
            Next

            If strCrewListFilter <> "" Then
                strFilter = "(" & strFilter & " AND " & strCrewListFilter & ")"
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
    Private Sub cboWScale_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboWScale.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            If IfNull(Mainview.GetRowCellValue(i, "FKeyRank"), "") <> "" Then
                Dim dr() As DataRow = Nothing
                If cboWScale.EditValue = modAdminData.UndefinedWScaleCode Then
                    dr = TryCast(WageScaleRankEdit.DataSource, DataTable).Select("RankCode = '" & modAdminData.UndefinedRankCode & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
                Else
                    dr = TryCast(WageScaleRankEdit.DataSource, DataTable).Select("RankCode = '" & Mainview.GetRowCellValue(i, "FKeyRank") & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
                End If
                If dr.Count > 0 Then
                    Mainview.SetRowCellValue(i, "FKeyWScaleRank", dr(0)("PKey"))
                End If
            End If
        Next
    End Sub

    Private Sub deStartDate_EditValueChanged(sender As Object, e As System.EventArgs) Handles deStartDate.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "DateStart", deStartDate.EditValue)
        Next
    End Sub

    Private Sub cboStartPlace_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboStartPlace.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "StartPlace", cboStartPlace.EditValue)
        Next
    End Sub

    Private Sub cboEndPlace_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboEndPlace.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "EndPlace", cboEndPlace.EditValue)
        Next
    End Sub

    Private Sub cboNxtAct_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboNxtAct.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "NextActivity", cboNxtAct.EditValue)
        Next
    End Sub
#End Region

#Region "Validation"
    Private Sub Mainview_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles Mainview.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

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
        For i As Integer = 0 To Mainview.RowCount - 1
            For Each clm In Mainview.Columns
                If clm.Tag = "Required" And IfNull(Mainview.GetRowCellValue(i, clm), "") = "" Then 'IsDBNull(Mainview.GetRowCellValue(i, clm)) = True Then
                    isGridRequiredFieldsIncomplete = True
                    Mainview.FocusedRowHandle = i
                    Mainview.UpdateCurrentRow()
                    MsgBox("Please complete the required fields.", MsgBoxStyle.Information, GetAppName() & " - Activity")
                    res = True
                    Return res
                    Exit Function
                End If
            Next
        Next
        Return res
    End Function

    Private Sub Mainview_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles Mainview.ValidateRow
        Dim view As Views.Grid.GridView = CType(sender, Views.Grid.GridView)
        Dim currAct As Columns.GridColumn = view.Columns("CurrActID")

        If Mainview.RowCount > 0 Then
            If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateStart"))) = False Then
                If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateStart"))) = False Then
                    e.Valid = False
                    view.GetDataRow(e.RowHandle).SetColumnError("DateStart", "Start date of activity must be later than the current activity.")
                    AllowSaving(Name, False)
                    Exit Sub
                End If
            End If

            view.GetDataRow(e.RowHandle).ClearErrors()
            AllowSaving(Name, True)
        End If
    End Sub

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

    Private Sub SignOff_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        strBContentFilter = ""
        _deleteid = Nothing
        clsAudit = Nothing
        strFilter = Nothing
        strStatFilter = Nothing
        downHitInfo = Nothing

        dtMainview.Dispose()
    End Sub

    Private Function getRowCellValue(row As Integer, columnName As String)
        Try
            Return IfNull(Mainview.GetRowCellValue(row, columnName), "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub WageScaleRankEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles WageScaleRankEdit.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Mainview.SetFocusedRowCellValue("FKeyWScaleRank", "")
        End If
    End Sub

    Private Sub cboWScale_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboWScale.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            'edited by tony20180108
            'cboWScale.EditValue = ""
            cboWScale.EditValue = modAdminData.UndefinedWScaleCode
            'end tony
        End If
    End Sub

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



End Class

