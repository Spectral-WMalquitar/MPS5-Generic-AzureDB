Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils

Public Class SignOff
    Friend dtMainview As New DataTable
    Dim _deleteid As String
    Dim clsAudit As New clsAudit 'neil
    Dim strFilter, strStatFilter As String
    Dim downHitInfo As GridHitInfo = Nothing
    Dim relieveDV As New DataView
    Dim relieveDT As New DataTable
    Dim isGridRequiredFieldsIncomplete As Boolean = False

    Dim ashWScaleRank As New DataTable

    'Private UndefinedWageScaleCode As String = 

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If bLoaded = False Then
            SetSaveCaption(Name, "Sign-off")
            blList.Draggable(True)

            'Create columns for Mainview's datatable
            InitData()
            'Apply ashore only filter
            InitFilter()

            'Get updated datasource for dropdown lists.
            cboVessel.Properties.DataSource = VesselList(DB)
            cboPlaceSignOff.Properties.DataSource = PortList(DB)
            cboArrivalPlace.Properties.DataSource = cboPlaceSignOff.Properties.DataSource
            cboReason.Properties.DataSource = ReasonList(DB)
            cboNxtAct.Properties.DataSource = AshoreStatusList(DB)
            cboWScale.Properties.DataSource = WageScaleList(DB)

            'Get updated datasource for mainview's dropdown lists.
            PortEdit.DataSource = cboPlaceSignOff.Properties.DataSource
            ReasonEdit.DataSource = cboReason.Properties.DataSource
            AshoreStatusEdit.DataSource = cboNxtAct.Properties.DataSource
            WageScaleRankEdit.DataSource = WageRankScaleList(DB)

            cboNxtAct.EditValue = DB.DLookUp("PKey", "tblAdmStat", "", "DefAshStat = 1")
            cboWScale.EditValue = modAdminData.UndefinedWScaleCode  '"SYSWSNOWSCALE"

            'Get crewlist datasource for crew to relieve drop down.
            Try
                If TryCast(blList.getBListDatasource(), DataTable).Columns.Count > 0 Then
                    relieveDT = New DataView(TryCast(blList.getBListDatasource(), DataTable)).ToTable(True, "Crew", "CurrActID", "FKeyVslCode", "StatCode", "RankName")
                End If
                relieveDV = New DataView(relieveDT)

                RelieveEdit.DataSource = relieveDV
            Catch ex As Exception
                MessageBox.Show("Crew Activity : " + ex.Message)
                LogErrors(ex.Message)
            End Try

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
        If MsgBox("Are you sure you want to sign off the crew/s?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
            Exit Sub
        End If

        For i As Integer = 0 To Mainview.RowCount - 1
            strIDNbr = getRowCellValue(i, "IDNbr").ToString
            strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "INSERT_ACT_HERE", 0, System.Environment.MachineName, "DESC_HERE", "Activity", strIDNbr)

            strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Sign-off")
            sqls.Add("EXEC [SP_SIGN_OFF] @IDNbr = '" & getRowCellValue(i, "IDNbr") & "', " & _
                     "@ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "', " & _
                     "@CurrActID = '" & getRowCellValue(i, "CurrActID") & "'," & _
                     "@DateArr = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateArr")) & ", " & _
                     "@PlaceArr ='" & getRowCellValue(i, "PlaceArr") & "', " & _
                     "@DateSOFF = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSOFF").ToString) & "," & _
                     "@PlaceSOFF = '" & getRowCellValue(i, "PlaceSOFF") & "', " & _
                     "@PlaceStart = '" & getRowCellValue(i, "NxtActPlace") & "', " & _
                     "@StatCode = '" & getRowCellValue(i, "Reason") & "', " & _
                     "@LastUpdatedBy = '" & strUpdatedBy & "', " & _
                     "@Remarks = '" & getRowCellValue(i, "Remarks") & "'," & _
                     "@NxtAct = '" & getRowCellValue(i, "NextActivity") & "', " & _
                     "@NxtActDateStart = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "NxtActDate").ToString) & ", " & _
                     "@PlaceEnd = '', " & _
                     "@RankCode = NULL, @RelieverID = '" & getRowCellValue(i, "RelievedID") & "', " & _
                     "@FKeyWScaleRank = '" & getRowCellValue(i, "FKeyWScaleRank") & "'")

            Mainview.SelectRow(i)
            msg = "Sign-off complete."


            'Welly
            '<!-- edited by tony20180709 : included check if next activity is set to add a Medical History -->
            'If (MPSDB.DLookUp("IncludeMedHistory", "tblAdmStat", False, "PKey='" & getRowCellValue(i, "Reason") & "'") = True) Then
            If (MPSDB.DLookUp("IncludeMedHistory", "tblAdmStat", False, "(PKey='" & getRowCellValue(i, "Reason") & "' OR PKey='" & getRowCellValue(i, "NextActivity") & "') AND IncludeMedHistory <> 0") = True) Then
                selectedCrew = New Utilities.SelectedCrew()
                selectedCrew.CrewIDNbr = getRowCellValue(i, "IDNbr")
                selectedCrew.ActivityID = getRowCellValue(i, "CurrActID")
                selectedCrew.ActivityGroupID = getRowCellValue(i, "ActGrpID")
                selectedCrew.FirstName = getRowCellValue(i, "Crew")

                'Update by calvhin
                Dim dr() As DataRow = relieveDT.Select("CurrActID = '" & getRowCellValue(i, "CurrActID") & "'")
                selectedCrew.RankName = dr(0)("RankName") 'old : getRowCellValue(i, "RankName")
                selectedCrew.VesselName = dr(0)("FKeyVslCode") 'old : getRowCellValue(i, "VslCode")
                'end calvhin

                listOfSelectedCrews.Add(selectedCrew)
            End If
            medHistoryLabel = "Signing Off Crew"
            'end welly
        Next

        If sqls.Count > 0 Then
            If MPSDB.RunSqls(sqls, True) = True Then

                'Welly
                If listOfSelectedCrews.Count > 0 Then
                    Dim message = "Create Medical History for selected crew" & IIf(listOfSelectedCrews.Count > 1, "s", "") & "?"
                    If (MessageBox.Show(message, "Create Medical History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        Dim medHistory As New Crewing.frmPopupMedHistory(listOfSelectedCrews, medHistoryLabel) 'Showing pop-up window for medical history. 
                        medHistory.ShowDialog()
                        listOfSelectedCrews.Clear()
                    End If
                End If
                'end welly

                MsgBox(msg, MsgBoxStyle.Information, GetAppName() & " - Activity")
                Mainview.DeleteSelectedRows()
                'forceRefresh(True)
                blList.RefreshData()
                BRECORDUPDATEDs = False

                cboVessel.EditValue = Nothing
                cboReason.EditValue = Nothing
                cboPlaceSignOff.EditValue = Nothing
                cboArrivalPlace.EditValue = Nothing
                deDateSignOff.EditValue = DBNull.Value
                deNxtActDate.EditValue = DBNull.Value
                deDateArrivedHome.EditValue = DBNull.Value
                cboNxtAct.EditValue = DB.DLookUp("PKey", "tblAdmStat", "", "DefAshStat = 1")
                cboWScale.EditValue = modAdminData.UndefinedWScaleCode  '"SYSWSNOWSCALE"
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
        ccolumn.ColumnName = "Reason"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateArr"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlaceArr"
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
        ccolumn.ColumnName = "NextActivity"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "NxtActDate"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
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
        ccolumn.ColumnName = "NxtActPlace"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "RelieveID"
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
                    'Dim dr() As DataRow = Nothing
                    Dim strWScaleRank As String = ""

                    'If IfNull(nrow("FkeyRankCode"), "") <> "" And IfNull(cboWScale.EditValue, "") <> "" Then
                    '    dr = WageScaleRankEdit.DataSource.Select("RankCode = '" & nrow("FkeyRankCode") & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
                    'End If

                    'If dr IsNot Nothing Then
                    '    If dr.Count > 0 Then
                    '        strWScaleRank = IfNull(dr(0)("PKey"), "")
                    '    End If
                    'End If

                    'strWScaleRank = modAdminData.UndefinedWScaleRankCode    '"SYSWSRUNDEF"
                    strWScaleRank = GetAshWScaleRank(nrow("FkeyRankCode"))
                    'If cboWScale.EditValue = modAdminData.UndefinedWScaleCode Then
                    '    strWScaleRank = modAdminData.UndefinedWScaleRankCode    '"SYSWSRUNDEF"
                    'Else
                    '    If Not IsNothing(cboWScale.EditValue) Then
                    '        If Not IfNull(cboWScale.EditValue, "").Equals("") Then

                    '        End If
                    '    End If
                    'End If

                    Dim dNxtActDate As Nullable(Of DateTime)
                    Dim dDateSOff As Nullable(Of DateTime)

                    If Not IsDBNull(deDateSignOff.EditValue) And Not IsNothing(deDateSignOff.EditValue) Then
                        dNxtActDate = DateAdd(DateInterval.Day, 1, deDateSignOff.EditValue)
                        dDateSOff = deDateSignOff.EditValue
                    Else
                        If Not IsDBNull(deNxtActDate.EditValue) And Not IsNothing(deNxtActDate.EditValue) Then
                            dNxtActDate = deNxtActDate.EditValue
                            dDateSOff = DateAdd(DateInterval.Day, -1, deNxtActDate.EditValue)
                        End If
                    End If

                    '<!-- edited by tony20170927
                    Dim strArrivalPlace As String = cboArrivalPlace.EditValue

                    'Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("Crew"), cboReason.EditValue, dDateSOff, DBNull.Value, dDateSOff, cboPlaceSignOff.EditValue, cboNxtAct.EditValue, dNxtActDate, nrow("FkeyRankCode"), strWScaleRank}
                    Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("Crew"), cboReason.EditValue, dDateSOff, strArrivalPlace, dDateSOff, cboPlaceSignOff.EditValue, cboNxtAct.EditValue, dNxtActDate, nrow("FkeyRankCode"), strWScaleRank, strArrivalPlace}
                    '-->
                    dtMainview.Rows.Add(xrow)
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

    Private Sub Mainview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Mainview.CellValueChanged
        If e.Column.FieldName = "PlaceArr" Then
            'If Not IsNothing(e.Value) And IfNull(Mainview.GetRowCellValue(e.RowHandle, "NxtActPlace"), "") = "" Then Mainview.SetRowCellValue(e.RowHandle, "NxtActPlace", e.Value)
            Mainview.SetRowCellValue(e.RowHandle, "NxtActPlace", e.Value)
        ElseIf e.Column.FieldName = "DateSOFF" Then
            If Not IsNothing(e.Value) Then
                If IsDate(e.Value) Then
                    Mainview.SetRowCellValue(e.RowHandle, "DateArr", e.Value)
                End If
            End If
        ElseIf e.Column.FieldName = "DateArr" Then
            If Not IsNothing(e.Value) Then
                If IsDate(e.Value) Then
                    Mainview.SetRowCellValue(e.RowHandle, "NxtActDate", DateAdd(DateInterval.Day, 1, e.Value))
                End If
            End If
        End If
    End Sub

    Private Sub cboWScale_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboWScale.EditValueChanged
        ashWScaleRank = MPSDB.CreateTable("SELECT * FROM dbo.tblAdmWscaleRank WHERE FKeyWScale = '" & cboWScale.EditValue & "' ORDER BY FKeyRank, YrsServ desc, LOC desc, LOCDays desc ")
        For i As Integer = 0 To Mainview.RowCount - 1
            'Dim strRank As String = "SYSRUNDEFINED" 'IfNull(Mainview.GetRowCellValue(i, "FKeyRank"), "SYSRUNDEFINED")
            'If strRank <> "" Then
            '    Dim dr() As DataRow = TryCast(WageScaleRankEdit.DataSource, DataTable).Select("RankCode = '" & Mainview.GetRowCellValue(i, "FKeyRank") & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
            '    If dr.Count > 0 Then
            '        Mainview.SetRowCellValue(i, "FKeyWScaleRank", dr(0)("PKey"))
            '    End If
            'End If

            'edited by tony20170522
            'Mainview.SetRowCellValue(i, "FKeyWScaleRank", "SYSWSRUNDEF")
            Mainview.SetRowCellValue(i, "FKeyWScaleRank", GetAshWScaleRank("FKeyRankCode")) 'edited by tony20170522
        Next
    End Sub

    Function GetAshWScaleRank(CrewRankCode As String) As String
        If IfNull(cboWScale.EditValue, "") = UndefinedWScaleCode Then
            Return UndefinedWScaleRankCode
        Else
            Dim dv As DataView = New DataView(ashWScaleRank)
            dv.RowFilter = "FKeyRank = '" & CrewRankCode & "'"
            If dv.Count > 0 Then
                Return dv(0)("PKey")
            Else
                Return UndefinedWScaleRankCode
            End If
        End If
        
    End Function

    Private Sub cboVessel_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboVessel.EditValueChanging
        If BRECORDUPDATEDs = True Then
            If CheckValidateFields() = True Then
                Exit Sub
            Else
                If ALLOWNEXTS = False Then e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        Mainview.SelectAll()
        Mainview.DeleteSelectedRows()
        InitFilter()
        BRECORDUPDATEDs = False
    End Sub

    Private Sub deDateSOFF_EditValueChanged(sender As Object, e As System.EventArgs) Handles deDateSignOff.EditValueChanged
        If Not IsNothing(deDateSignOff.EditValue) Then  '<-- added by tony20170406
            For i As Integer = 0 To Mainview.RowCount - 1
                Mainview.SetRowCellValue(i, "DateSOFF", deDateSignOff.EditValue)
                If Not IsDBNull(deDateSignOff.EditValue) Then
                    Mainview.SetRowCellValue(i, "DateArr", deDateSignOff.EditValue)
                    Mainview.SetRowCellValue(i, "NxtActDate", DateAdd(DateInterval.Day, 1, deDateSignOff.EditValue))
                End If
            Next

            '<!-- added by tony20170406
            If IsDate(deDateSignOff.EditValue) Then
                deDateArrivedHome.EditValue = deDateSignOff.EditValue '<-- added by tony20170904
                deNxtActDate.EditValue = DateAdd(DateInterval.Day, 1, deDateSignOff.EditValue)
            End If
            '-->
        End If

    End Sub

    Private Sub cboPlaceSignOff_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPlaceSignOff.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "PlaceSOFF", cboPlaceSignOff.EditValue)
        Next
    End Sub

    Private Sub cboReason_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboReason.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "Reason", cboReason.EditValue)
        Next
    End Sub

    Private Sub deNxtActDate_EditValueChanged(sender As Object, e As System.EventArgs) Handles deNxtActDate.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "NxtActDate", deNxtActDate.EditValue)
            If IsDBNull(deDateSignOff.EditValue) And Not IsDBNull(deNxtActDate.EditValue) Then
                Mainview.SetRowCellValue(i, "DateSOFF", DateAdd(DateInterval.Day, -1, deNxtActDate.EditValue))
                Mainview.SetRowCellValue(i, "DateArr", DateAdd(DateInterval.Day, -1, deNxtActDate.EditValue))
            End If
        Next
    End Sub

    Private Sub cboNxtAct_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboNxtAct.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "NextActivity", cboNxtAct.EditValue)
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

        If IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSOFF"))) = False Then
            If validateActivity(Mainview.GetRowCellValue(rHandle, currAct), Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSOFF"))) = False Then
                hasErr = True
                strMsg = "Sign-off date must be later than the current activity."
            End If
            If IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateArr"))) = False Then
                If Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateArr")) < Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSOFF")) Then
                    hasErr = True
                    strMsg = "Arrival date must be later than sign-off date."
                End If
            End If
            If IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("NxtActDate"))) = False Then
                If IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateArr"))) = False Then
                    If Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateArr")) >= Mainview.GetRowCellValue(rHandle, Mainview.Columns("NxtActDate")) Then
                        hasErr = True
                        strMsg = "Start date of next activity must be later than arrival date."
                    End If
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
        For i As Integer = 0 To Mainview.RowCount - 1
            For Each clm In Mainview.Columns
                If clm.Tag = "Required" And IfNull(Mainview.GetRowCellValue(i, clm), "") = "" Then 'IsDBNull(Mainview.GetRowCellValue(i, clm)) = True Then
                    isGridRequiredFieldsIncomplete = True
                    Mainview.UpdateCurrentRow()
                    Mainview.FocusedRowHandle = i
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

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        If Mainview.IsRowSelected(e.RowHandle) And e.Column.Tag = "Required" Then
            If IfNull(e.CellValue, "").Equals("") Then
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
                If IfNull(e.CellValue, "").Equals("") Then
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
        dtMainview.Dispose()
        _deleteid = Nothing
        clsAudit = Nothing
        strFilter = Nothing
        strStatFilter = Nothing
        downHitInfo = Nothing

        relieveDV.Dispose()
        relieveDT.Dispose()
    End Sub

    Private Function getRowCellValue(row As Integer, columnName As String)
        Try
            Return IfNull(Mainview.GetRowCellValue(row, columnName), "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub RelieveEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RelieveEdit.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Mainview.SetFocusedRowCellValue("RelieveID", "")
        End If
    End Sub


    Private Sub WageScaleRankEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles WageScaleRankEdit.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Mainview.SetFocusedRowCellValue("FKeyWScaleRank", "")
        End If
    End Sub

    Private Sub cboWScale_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboWScale.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            'edited by tony20180108 
            'cboWScale.EditValue = System.DBNull.Value
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




    Private Sub deDateArrivedHome_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles deDateArrivedHome.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "DateArr", deDateArrivedHome.EditValue)
        Next
    End Sub

    Private Sub cboArrivalPlace_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboArrivalPlace.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "PlaceArr", cboArrivalPlace.EditValue)
        Next
    End Sub
End Class
