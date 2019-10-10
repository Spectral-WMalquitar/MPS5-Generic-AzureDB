Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class Promotion
    Friend dtMainview As New DataTable
    Dim _deleteid As String
    Dim clsAudit As New clsAudit 'neil
    Dim strFilter, strStatFilter As String
    Dim downHitInfo As GridHitInfo = Nothing
    Dim isGridRequiredFieldsIncomplete As Boolean = False
    Dim clsActDoc As New clsActivityDocs_temptbl("Promote", MPSDB)

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If bLoaded = False Then
            SetSaveCaption(Name, "Promote")
            blList.Draggable(True)

            'Create columns for Mainview's datatable
            InitData()
            'Apply ashore only filter
            InitFilter()

            'Get updated datasource for mainview's dropdown lists.
            RankEdit.DataSource = RankList(DB)
            WageScaleRankEdit.DataSource = WageRankScaleList(DB)

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

        If checkRequiredFields() = True Then
            'BRECORDUPDATEDs = False
            Exit Sub
        End If

        'edited by tony20170904
        'If MsgBox("Are you sure you want to add activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
        If MsgBox("Are you sure you want to promote the crew/s?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
            Exit Sub
        End If

        For i As Integer = 0 To Mainview.RowCount - 1
            strIDNbr = getRowCellValue(i, "IDNbr").ToString
            strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "INSERT_ACT_HERE", 0, System.Environment.MachineName, "DESC_HERE", "Activity", strIDNbr)

            strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Promoted")
            sqls.Add("EXEC SP_PROMOTE @CurrActID = '" & getRowCellValue(i, "CurrActID") & "', " & _
                     "@ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "'," & _
                     "@DateProm = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateProm").ToString) & ", " & _
                     "@NewRank = '" & getRowCellValue(i, "FKeyRank") & "', " & _
                     "@WScaleRank = '" & getRowCellValue(i, "FKeyWScaleRank") & "'," & _
                     "@Remarks = '" & getRowCellValue(i, "Remarks") & "', @LastUpdatedBy = '" & strUpdatedBy & "'," & _
                     "@IDNbr = '" & strIDNbr & "',@activitykeyOut = @activitykeyOut output, @crewidnbrOut = @crewidnbrOut output")

            Mainview.SelectRow(i)
            msg = "Promotion complete."

            clsActDoc.updateDateIssue(strIDNbr, Mainview.GetRowCellValue(i, "DateProm"))
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
            End If
        End If

        isGridRequiredFieldsIncomplete = False
    End Sub

    Private Sub InitFilter()
        strStatFilter = "(StatCode='SYSONB' OR StatCode='SYSSICKONB')"
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
        ccolumn.ColumnName = "VesselName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "RankName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateProm"
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
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyVslCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyWScaleRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Nat"
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
                    If DB.DLookUp("FKeyStatCode", "tblActivity", "", "PKey = '" & IfNull(nrow("CurrActID"), "") & "'") = "SYSSICKONB" Then
                        MsgBox("Cannot promote sick onboard crew, " & nrow("Crew") & ". Please end sick onboard status first.")
                        'ElseIf DB.DLookUp("PKey", "tblPlanningEventCrew", "", "ToRelieveID = '" & IfNull(nrow("CurrActID"), "") & "' AND FKeyActicity is null").Equals("") Then
                        'MsgBox("Cannot promote a crew that has a planned reliever. Cancel the planned crew first before you proceed with this crew's promotion.", MsgBoxStyle.Information)
                    Else
                        Dim Reliever As String = DB.DLookUp("CrewName", "view_PlannedCrews_WithRelieverOnly", "", "ToRelieveID = '" & IfNull(nrow("CurrActID"), "") & "'")
                        If Not IfNull(Reliever, "").Equals("") Then
                            MsgBox("Cannot promote this crew because he is currently planned to be relieved by: " & Reliever & vbNewLine & vbNewLine & "Cancel the above crew's planning first before you can proceed with the selected crew's promotion.", MsgBoxStyle.Information)
                        Else
                            'Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("Crew"), nrow("VslName"), nrow("RankName"), DBNull.Value}
                            Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), ""), nrow("Crew"), nrow("VslName"), nrow("RankName"), DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, nrow("FKeyVslCode"), nrow("FKeyWScaleRankCode"), nrow("Nat")}
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
                    Mainview.FocusedRowHandle = i
                    isGridRequiredFieldsIncomplete = True
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
            If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateProm"))) = False Then
                If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateProm"))) = False Then
                    e.Valid = False
                    view.GetDataRow(e.RowHandle).SetColumnError("DateProm", "Date of promotion must be later than the current activity.")
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

    Private Sub Promote_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
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
                Dim dson As Date = IIf(Mainview.GetRowCellDisplayText(Mainview.FocusedRowHandle, "DateProm") = "",
                                                      Nothing, Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "DateProm"))

                'Dim row As System.Data.DataRow = Mainview.GetDataRow(Mainview.FocusedRowHandle)

                               Dim vslname As String = Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "VesselName")

                If crewId = "" Or crewId Is DBNull.Value Then
                    MsgBox("Please select Crew.", vbExclamation)
                    Exit Select
                End If

                If Not IsDate(dson) Or dson = Nothing Then
                    MsgBox("Please enter Date of Promotion.", vbExclamation)
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

    Private Sub RankEdit_EditValueChanged(sender As Object, e As System.EventArgs) Handles RankEdit.EditValueChanged
        'neil 20180116
        Dim lkurank As DevExpress.XtraEditors.LookUpEdit = DirectCast(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim strWScaleRank As String = ""
        Dim vslWScaleRank As String = ""
        Dim natcode As String, vslcode As String, rankcode As String

        'natcode = MPSDB.DLookUp("NatCode", "tblCrewInfo", "", "PKey='" & Mainview.GetFocusedRowCellDisplayText("IDNbr") & "'")
        natcode = MPSDB.DLookUp("PKey", "tblAdmCntry", "", "Nat='" & Mainview.GetFocusedRowCellDisplayText("Nat") & "'")
        'vslcode = MPSDB.DLookUp("PKey", "tblAdmVsl", "", "Name='" & Mainview.GetFocusedRowCellDisplayText("VesselName") & "'")
        vslcode = Mainview.GetFocusedRowCellDisplayText("FKeyVslCode")
        'strWScaleRank = Mainview.GetFocusedRowCellDisplayText("FKeyWScaleRankCode")
        rankcode = lkurank.EditValue

        'strWScaleRank = getNatWScaleRank(vslcode, rankcode, natcode, strWScaleRank)
        strWScaleRank = getNatWScaleRank(vslcode, rankcode, natcode, "")

        Mainview.SetFocusedRowCellValue("FKeyWScaleRank", strWScaleRank)

    End Sub
End Class
