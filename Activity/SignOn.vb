Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils
Imports System.Reflection

Public Class SignOn

#Region "Structures"

    Private Structure MainCompetence
        Public CrewID As String
        Public DocType As String
        Public DocName As String
        Public Number As String
        Public Issue As String
        Public Expiry As String
        Public Country As String
        Public Capacity As String
        Public Complied As String
        Public Comment As String
    End Structure

    Private Structure VesselCompetence
        Public CrewID As String
        Public VslType As String
        Public RankName As String
        Public YrOfService As String
        Public TotalYrsOfService As String
        Public Complied As String
    End Structure

    Private Structure SelectedCrewSignOn
        Public CrewIDNbr As String
        Public CrewName As String
        Public Rank As String
    End Structure


#End Region

    Private SelectedCrewSignOn_Hash As New HashSet(Of SelectedCrewSignOn)

    Private _compentenceDocs As New HashSet(Of DataTable)
    Private _compentenceVsl As New HashSet(Of DataTable)

    Private _mainSource As New DataTable
    Private _vesselSource As New DataTable


    Friend dtMainview As New DataTable
    Dim _deleteid As String
    Dim clsAudit As New clsAudit 'neil
    Dim strFilter, strStatFilter As String
    Dim downHitInfo As GridHitInfo = Nothing
    Dim relieveDV As New DataView
    Dim userdatafilterstring As String = GetUserFilterString(, "curr_act.FKeyAgentCode", "curr_act.FKeyPrinCode", "curr_act.FKeyFlt")
    Dim isGridRequiredFieldsIncomplete As Boolean = False

    Dim UsePlannedSOnDate As Boolean = False

    Dim clsConflict As New clsCrewConflict
    Dim clsActDoc As New clsActivityDocs_temptbl("SignOn", MPSDB)
    Dim dragEvent As DragEventArgs

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If bLoaded = False Then
            SplitterItem2.Location = New Point(SplitterItem2.Location.X, 200)
            SetSaveCaption(Name, "Sign-on")
            blList.Draggable(True)

            LayoutControlItem3.Height = 233
            LayoutControlItem10.Visibility = LayoutVisibility.Never 'Wage Scale is set to hidden at the moment since the wage scale in the grid
            '                                                       is automatically populated based on the crew's latest wage scale

            'Create columns for Mainview's datatable
            InitData()
            'Apply ashore only filter
            InitFilter()

            'Get updated datasource for dropdown lists.
            cboVessel.Properties.DataSource = VesselList(DB)
            cboPlaceSON.Properties.DataSource = PortList(DB)
            cboWScale.Properties.DataSource = WageScaleList(DB)
            cboAgent.Properties.DataSource = AgentList(DB)
            cboDepPlace.Properties.DataSource = cboPlaceSON.Properties.DataSource

            'Get updated datasource for mainview's dropdown lists.
            PortEdit.DataSource = cboPlaceSON.Properties.DataSource
            RankEdit.DataSource = RankList(DB)
            WageScaleRankEdit.DataSource = WageRankScaleList(DB)
            AgentEdit.DataSource = AgentList(DB)

            'Get updated datasorce for planview's dropdown lists.
            PlanRankEdit.DataSource = RankEdit.DataSource
            PlanWScaleRankEdit.DataSource = WageScaleRankEdit.DataSource
            PlanPort.DataSource = PortEdit.DataSource

            'Get crewlist datasource for crew to relieve drop down.
            Try
                Dim relieveDT As New DataTable
                If TryCast(blList.getBListDatasource(), DataTable).Columns.Count > 0 Then
                    relieveDT = New DataView(TryCast(blList.getBListDatasource(), DataTable)).ToTable(True, "Crew", "CurrActID", "FKeyVslCode", "StatCode")
                End If
                relieveDV = New DataView(relieveDT)

                RelieveEdit.DataSource = relieveDV
                PlanRelieveEdit.DataSource = relieveDV
                relieveDT.Dispose()
            Catch ex As Exception
                MessageBox.Show("Crew Activity : " + ex.Message)
                LogErrors(ex.Message)
            End Try

            'Set audittrail's connection string
            clsAudit.propSQLConnStr = DB.GetConnectionString
            BRECORDUPDATEDs = False

            bLoaded = True
            Plangrid.AllowDrop = True

            SetActivityActivityDocsRpgVisibility(Name, True)
        End If
        _mainSource.Clear()
        _vesselSource.Clear()
    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim msg As String = ""
        Dim strIDNbr As String = ""
        Dim strUpdatedBy As String = ""
        cboVessel.Focus()
        _mainSource.Clear()
        _vesselSource.Clear()
        SelectedCrewSignOn_Hash.Clear()
        _compentenceDocs.Clear()
        _compentenceVsl.Clear()

        If checkRequiredFields() = True Then Exit Sub

        'edited by tony20170904
        'If MsgBox("Are you sure you want to add activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
        If MsgBox("Are you sure you want to sign on the crew/s?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
            Exit Sub
        End If

        Dim competenceID As String = MPSDB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey = '" & IfNull(cboVessel.EditValue, "") & "'")

        For i As Integer = 0 To Mainview.RowCount - 1
            strIDNbr = getRowCellValue(i, "IDNbr").ToString

            strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "INSERT_ACT_HERE", 0, System.Environment.MachineName, "DESC_HERE", "Activity", strIDNbr)

            strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Sign-on")

            sqls.Add("EXEC SP_SIGN_ON @IDNbr = '" & getRowCellValue(i, "IDNbr") & "'," & _
                     "@CurrActID = '" & getRowCellValue(i, "CurrActID") & "'," & _
                     "@ActivityType= 'sea'," & _
                     "@DateDep =" & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateDep").ToString) & "," & _
                     "@PlaceDep = '" & getRowCellValue(i, "PlaceDep") & "'," & _
                     "@LOC = " & IfNull(getRowCellValue(i, "LOC"), 0) & "," & _
                     "@FKeyVslCode = '" & IfNull(cboVessel.EditValue, "") & "'," & _
                     "@FKeyAgentCode = '" & IfNull(getRowCellValue(i, "FKeyAgentCode"), "") & "'," & _
                     "@FKeyStatCode = 'SYSONB'," & _
                     "@DateSOn = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSON").ToString) & "," & _
                     "@PlaceSOn = '" & getRowCellValue(i, "PlaceSON") & "'," & _
                     "@FKeyWScaleRankCode = '" & getRowCellValue(i, "FKeyWScaleRank") & "'," & _
                     "@RelievedID = '" & getRowCellValue(i, "RelievedID") & "'," & _
                     "@Remarks = '" & getRowCellValue(i, "Remarks") & "'," & _
                     "@LastUpdatedBy = '" & strUpdatedBy & "'," & _
                     "@LOCDAYS = " & IfNull(getRowCellValue(i, "LOCDays"), 0) & "," & _
                     "@FKeyRankCode = '" & getRowCellValue(i, "FKeyRank") & "'," & _
                     "@PlanEventCrewID = '" & getRowCellValue(i, "PlanEventCrewID") & "'," & _
                     "@activitykeyOut = @activitykeyOut output, @crewidnbrOut = @crewidnbrOut output")

            Mainview.SelectRow(i)
            msg = "Sign-on complete."

            Dim hasLacking As Integer = GatherCrewWithLackingCompetence(strIDNbr, getRowCellValue(i, "Crew"), getRowCellValue(i, "FKeyRank"), competenceID, IfNull(getRowCellValue(i, "LOC"), "0"), Mainview.GetRowCellValue(i, "DateSON").ToString())
            If hasLacking > 0 Then
                CollectCrewData(strIDNbr, getRowCellValue(i, "Crew"), getRowCellValue(i, "FKeyRank"))
            End If

            clsActDoc.updateDateIssue(getRowCellValue(i, "IDNbr"), Mainview.GetRowCellValue(i, "DateSON"))
        Next

        If DialogResult.Yes = OpenReportForNonCompliedCrews() Then
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
                    Plangrid.DataSource = Nothing
                    BRECORDUPDATEDs = False
                    cboVessel.EditValue = Nothing
                    cboAgent.EditValue = Nothing
                    cboWScale.EditValue = Nothing
                    cboDepPlace.EditValue = Nothing
                    cboPlaceSON.EditValue = Nothing
                    deDateSON.EditValue = Nothing
                    deDepDate.EditValue = Nothing
                End If
            End If
            isGridRequiredFieldsIncomplete = False
        End If


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
        ccolumn.ColumnName = "LOC"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "LOCDays"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateDep"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlaceDep"
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
        ccolumn.ColumnName = "RelieveID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "InvalidMsg"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        'added by tony20170408
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyAgentCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        'added by fords20171003
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlanEventCrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        Maingrid.DataSource = dtMainview

    End Sub

    Public Overrides Sub DeleteData()
        Dim i As Integer = 0
        While i < Mainview.RowCount
            If _deleteid.Contains(";" & Mainview.GetRowCellValue(i, "IDNbr") & ";") Then
                'Unhide dragged crews from plan view
                Planview.ActiveFilterString = Planview.ActiveFilterString.Replace(Mainview.GetRowCellValue(i, "IDNbr"), "")

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
        Else
            AllowSaving(Name, False)
        End If
        If Mainview.RowCount = 0 Then AllowSaving(Name, False)
    End Sub

#Region "Drag N'Drop"

    Private Sub MainView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mainview.MouseDown, Planview.MouseDown
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

    Private Sub MainView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mainview.MouseMove, Planview.MouseMove
        Dim view As GridView = CType(sender, GridView)
        If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim DragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)
            If Not DragRect.Contains(New Point(e.X, e.Y)) Then
                If view.Name = "Mainview" Then
                    view.GridControl.DoDragDrop(GetSelectedRows(), DragDropEffects.Move)
                Else
                    view.GridControl.DoDragDrop(GetSelectedPlanRows(), DragDropEffects.Move)
                End If

                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragDrop
        dragEvent = e
        Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))

        '<!-- added by tony20181005
        'as of 5-Oct-2018 the xtbl has only one field (IDNbr) when dragged from MainGrid
        If xtbl.Columns.Count = 1 Then
            If xtbl.Columns(0).ColumnName = "IDNbr" Then
                Exit Sub
            End If
        End If
        '-->

        '//// Neil 20170814 crew conflict feature
        If IfNull(cboVessel.EditValue, "") = "" Then
            MsgBox("Please select the vessel.", MsgBoxStyle.Information, GetAppName() & " - Activity")
            Exit Sub
        End If

        '<!-- added by tony20180118
        If Not CheckPlannedBeforeAfterSelectedDateSON(xtbl) Then Exit Sub
        'end tony -->

        Dim dtres As New DataTable
        dtres = clsConflict.CrewConflict_GetCrewWithConflict(xtbl.Rows(0)("IDNbr"), dtMainview, "IDNbr", MPSDB.GetConnectionString)

        If dtres.Rows.Count > 0 Then
            If MsgBox("Crew " & xtbl.Rows(0)("Crew") & " is conflict with crew " & dtres.Rows(0)("CConflictName") & ", do you want to continue?", vbExclamation + vbYesNo) = vbNo Then
                Exit Sub
            End If
        End If

        Dim dtcrewlist As New DataTable
        dtcrewlist = MPSDB.CreateTable("select * from view_CrewConflict_ONB where FKeyVslCode ='" & cboVessel.EditValue & "'")
        dtres = clsConflict.CrewConflict_GetCrewWithConflict(xtbl.Rows(0)("IDNbr"), dtcrewlist, "FKeyIDNbr", MPSDB.GetConnectionString)

        If dtres.Rows.Count > 0 Then
            If MsgBox("Crew " & xtbl.Rows(0)("Crew") & " is conflict with crew " & dtres.Rows(0)("CConflictName") & " on-board the vessel " & cboVessel.Text & ", do you want to continue?", vbExclamation + vbYesNo) = vbNo Then
                Exit Sub
            End If
        End If

        '///////////

        If Mainview.RowCount = 0 Then isGridRequiredFieldsIncomplete = False 'added by tony20170508
        If Not xtbl Is Nothing Then
            strFilter = strStatFilter
            Try
                For Each nrow In xtbl.Rows
                    Dim crewRank As String = IfNull(nrow("FkeyRankCode"), "")
                    Dim LOC As Integer = 0
                    Dim LOCDays As Integer = 0
                    Dim dr() As DataRow = Nothing
                    Dim strReliever As String = ""
                    Dim dtWScaleRank As DataTable = WageScaleRankEdit.DataSource
                    Dim strWScaleRank As String = ""
                    Dim strPlaceSON As String = IfNull(cboPlaceSON.EditValue, "")
                    Dim strDateSON As Nullable(Of Date) = deDateSON.EditValue

                    'checks what wage scale rank column name should be used
                    Dim col_wscalerank As String = ""
                    If xtbl.Columns.Contains("FKeyWScaleRankCode") Then
                        col_wscalerank = "FKeyWScaleRankCode"
                    ElseIf xtbl.Columns.Contains("PlannedWScaleRank") Then
                        col_wscalerank = "PlannedWScaleRank"
                    End If
                    '----------------------------------------------------------------------------

                    'get wage scale rank to be assigned to the crew
                    If Not IfNull(col_wscalerank, "").Equals("") Then
                        If Not IfNull(nrow(col_wscalerank), "").Equals("") Then
                            dr = dtWScaleRank.Select("PKey = '" & nrow(col_wscalerank) & "'")
                            GoTo AFTER_Get_WscaleRank_From_AutoFill
                        End If
                    End If


Get_WscaleRank_From_AutoFill:
                    If IfNull(nrow("FkeyRankCode"), "") <> "" And IfNull(cboWScale.EditValue, "") <> "" Then
                        dr = dtWScaleRank.Select("RankCode = '" & nrow("FkeyRankCode") & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
                    End If

AFTER_Get_WscaleRank_From_AutoFill:

                    If (IfNull(cboVessel.EditValue, "") <> "") And (IfNull(nrow("FKeyPlannedVsl"), "") = cboVessel.EditValue) Then
                        If dtWScaleRank IsNot Nothing Then
                            If IfNull(nrow("PlannedWScaleRank"), "") <> "" Then
                                dr = dtWScaleRank.Select("PKey = '" & IfNull(nrow("PlannedWScaleRank"), "") & "'")
                            End If
                        End If

                        crewRank = IfNull(nrow("PlannedRank"), IfNull(nrow("FkeyRankCode"), ""))
                        strReliever = IfNull(nrow("PlannedToRelieveID"), "")
                        '<!-- edited by tony20180118
                        'strDateSON = nrow("PlannedDateSON")
                        If IfNull(nrow("PlannedDateSON"), "").Length > 0 Then 'tonytest If UsePlannedSOnDate Then
                            strDateSON = nrow("PlannedDateSON")
                        Else
                            strDateSON = deDateSON.EditValue
                        End If
                        'end tony -->
                        strPlaceSON = IfNull(nrow("PlannedPlaceSON"), "")
                        strWScaleRank = IfNull(nrow("PlannedWScaleRank"), "")   'added by tony20181005
                    End If

                    If dr IsNot Nothing Then
                        If dr.Count > 0 Then
                            strWScaleRank = IfNull(dr(0)("PKey"), "")
                            LOC = IfNull(dr(0)("LOC"), 0)
                            LOCDays = IfNull(dr(0)("LOCDays"), 0)
                        End If
                    End If

                    'neil 20180116
                    'Dim vslWScaleRank As String = ""
                    'If strWScaleRank = "" Or strWScaleRank = "SYSWSRUNDEF" Then
                    '    If crewRank <> "" Then
                    '        Dim crewnatCode As String
                    '        crewnatCode = MPSDB.DLookUp("PKey", "tblAdmCntry", "", "Nat='" & nrow("nat") & "'")
                    '        'strWScaleRank = getNatWScaleRank(cboVessel.EditValue, crewnatCode, crewRank)
                    '        strWScaleRank = MPSDB.DLookUp("WScaleRankCode", "viewVslNatWScale", "",
                    '                                      "FKeyVslCode='" & cboVessel.EditValue & "' and NatCode='" & crewnatCode & "' and RankCode ='" & crewRank & "'")
                    '        If strWScaleRank = "" Then 'perhaps no nationality is entered.
                    '            strWScaleRank = MPSDB.DLookUp("WScaleRankCode", "viewVslNatWScale", "",
                    '                                     "FKeyVslCode='" & cboVessel.EditValue & "' and RankCode ='" & crewRank & "'")
                    '        End If
                    '    End If
                    'End If

                    'neil 20180116
                    Dim crewnatCode As String
                    crewnatCode = MPSDB.DLookUp("PKey", "tblAdmCntry", "", "Nat='" & nrow("nat") & "'")
                    '<!-- tony20181005 - if strWscaleRank has no value, it means it has no wage scale dragged from planned.
                    If IfNull(strWScaleRank, "").Length = 0 Then
                        strWScaleRank = getNatWScaleRank(cboVessel.EditValue, crewRank, crewnatCode, strWScaleRank)
                    End If
                    'strWScaleRank = getNatWScaleRank(cboVessel.EditValue, crewRank, crewnatCode, strWScaleRank)
                    '-->

                    'edited by tony20170408
                    Dim strAgentCode As String = ""
                    If Not IfNull(cboAgent.EditValue, "").Equals("") Then strAgentCode = cboAgent.EditValue
                    Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), nrow("Crew"), crewRank, strWScaleRank, LOC, LOCDays, deDepDate.EditValue, cboDepPlace.EditValue, strDateSON, strPlaceSON, strReliever, Nothing, Nothing, strAgentCode, nrow("PlanEventCrewID")}
                    'Dim xrow() As Object = {nrow("IDNbr"), IfNull(nrow("CurrActID"), ""), nrow("Crew"), crewRank, strWScaleRank, LOC, LOCDays, deDepDate.EditValue, cboDepPlace.EditValue, strDateSON, strAgentCode, "", "", strReliever}
                    dtMainview.Rows.Add(xrow)
                    '------------------------------------------------------------------------------------------------------------------------------------------------

                    'Hide crew in Planview that are dragged into the mainview
                    If Planview.ActiveFilterString.Length > 0 Then
                        Planview.ActiveFilterString = Planview.ActiveFilterString & " AND IDNbr <> '" & nrow("IDNbr") & "' "
                    Else
                        Planview.ActiveFilterString = " IDNbr <> '" & nrow("IDNbr") & "'"
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

    Private Function CheckPlannedBeforeAfterSelectedDateSON(dtSelectedCrew As DataTable) As Boolean
        Try
            Dim ReturnValue As Boolean = True
            Dim beforeSelectedDate As New System.Text.StringBuilder
            Dim afterSelectedDate As New System.Text.StringBuilder
            Dim cText As String

            Dim rowList As DataRow() = dtSelectedCrew.Select("", "Crew asc")
            For Each r As DataRow In rowList
                If (IfNull(cboVessel.EditValue, "") <> "") And (IfNull(r("FKeyPlannedVsl"), "") = cboVessel.EditValue) Then
                    If Not IfNull(deDateSON.EditValue, "").Equals("") Then
                        cText = vbTab & r("Crew") & " : " & Format(r("PlannedDateSON"), "dd-MMM-yyyy")

                        If r("PlannedDateSON") < deDateSON.EditValue Then
                            beforeSelectedDate.AppendLine(cText)
                        ElseIf r("PlannedDateSON") > deDateSON.EditValue Then
                            afterSelectedDate.AppendLine(cText)
                        End If
                    End If
                End If
            Next

            Dim draggedPlanResult As New System.Text.StringBuilder
            If beforeSelectedDate.Length > 0 Then
                draggedPlanResult.Append("There is a selected crew(s) planned to be sign on before the selected date sign on:")
                draggedPlanResult.AppendLine()
                draggedPlanResult.AppendLine(beforeSelectedDate.ToString)
            End If

            If afterSelectedDate.Length > 0 Then
                If draggedPlanResult.Length > 0 Then draggedPlanResult.AppendLine()
                draggedPlanResult.Append("There is a selected crew(s) planned to be sign on later than the selected date sign on:")
                draggedPlanResult.AppendLine()
                draggedPlanResult.AppendLine(afterSelectedDate.ToString)
            End If

            If draggedPlanResult.Length > 0 Then
                Dim resp = MsgBox(draggedPlanResult.ToString & vbNewLine & "Do you want to continue and use the planned date sign on?" & vbNewLine & "Select No to use the entered sign on date [" & Format(deDateSON.EditValue, "dd-MMM-yyyy") & "].", MsgBoxStyle.Question + vbYesNoCancel)

                If resp = MsgBoxResult.Cancel Then
                    ReturnValue = False
                Else
                    ReturnValue = resp = MsgBoxResult.Yes
                End If

            End If

            Return ReturnValue
        Catch ex As Exception
            MsgBox("Error on CheckPlannedBeforeAfterSelectedDateSON : " & ex.Message)
            '<!-- edited by tony20181016 - produces warning: missing a 'Return' statement?
            Return False
            '-->
        End Try


    End Function


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


    Private Function GetSelectedPlanRows() As DataTable
        Dim _tbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CurrActID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedWScaleRank"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedDateSON"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedPlaceSON"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlannedToRelieveID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FkeyRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyPlannedVsl"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlanEventCrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        '<!-- tony20180130
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Nat"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        '-->

        For Each xrow In Planview.GetSelectedRows
            _tbl.ImportRow(Planview.GetDataRow(xrow))
        Next

        Return _tbl
    End Function

#End Region

#Region "EditValueChanged"
    Private Sub deDateSON_EditValueChanged(sender As Object, e As System.EventArgs) Handles deDateSON.EditValueChanged
        If deDateSON.Text <> "" Then
            For i As Integer = 0 To Mainview.RowCount - 1
                Mainview.SetRowCellValue(i, "DateSON", deDateSON.EditValue)
            Next
        End If

        If IsDate(deDateSON.EditValue) Then
            If IsNothing(deDepDate.EditValue) Or IfNull(deDepDate.EditValue, "").Equals("") Then
                deDepDate.EditValue = deDateSON.EditValue '<-- added by tony20170406
            End If
        End If
    End Sub

    Private Sub deDepDate_EditValueChanged(sender As Object, e As System.EventArgs) Handles deDepDate.EditValueChanged
        If Not IsNothing(deDepDate) Then                    '<-- added by tony20170406
            If deDepDate.Text <> "" Then
                For i As Integer = 0 To Mainview.RowCount - 1
                    Mainview.SetRowCellValue(i, "DateDep", deDepDate.EditValue)
                Next
            End If

            If IsDate(deDepDate.EditValue) Then
                If IsNothing(deDateSON.EditValue) Or IfNull(deDateSON.EditValue, "").Equals("") Then
                    deDateSON.EditValue = deDepDate.EditValue '<-- added by tony20170406
                End If
            End If

        End If

    End Sub

    Private Sub cboPlaceSON_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboPlaceSON.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "PlaceSON", cboPlaceSON.EditValue)
        Next
    End Sub

    Private Sub cboDepPlace_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboDepPlace.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "PlaceDep", cboDepPlace.EditValue)
        Next
    End Sub

    Private Sub cboWScale_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboWScale.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            If IfNull(Mainview.GetRowCellValue(i, "FKeyRank"), "") <> "" Then
                Dim dr() As DataRow = TryCast(WageScaleRankEdit.DataSource, DataTable).Select("RankCode = '" & Mainview.GetRowCellValue(i, "FKeyRank") & "' AND WScaleCode = '" & cboWScale.EditValue & "'")
                If dr.Count > 0 Then
                    Mainview.SetRowCellValue(i, "FKeyWScaleRank", dr(0)("PKey"))
                End If
            End If
        Next
    End Sub

    Private Sub Mainview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Mainview.CellValueChanged
        If e.Column.FieldName = "FKeyWScaleRank" Then
            If IfNull(Mainview.GetRowCellValue(e.RowHandle, "FKeyWScaleRank"), "") <> "" Then
                Dim dr() As DataRow = TryCast(WageScaleRankEdit.DataSource, DataTable).Select("PKey = '" & Mainview.GetRowCellValue(e.RowHandle, "FKeyWScaleRank") & "'")
                If dr.Count > 0 Then
                    Mainview.SetRowCellValue(e.RowHandle, "LOC", dr(0)("LOC"))
                    Mainview.SetRowCellValue(e.RowHandle, "LOCDays", dr(0)("LOCDays"))
                End If
            End If

        ElseIf e.Column.FieldName = "DateSON" Then
            If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateSON"), "") <> "" Then
                If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateDep"), "") = "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "DateDep", Mainview.GetRowCellValue(e.RowHandle, "DateSON"))
                End If
            End If

        ElseIf e.Column.FieldName = "DateDep" Then
            If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateDep"), "") <> "" Then
                If IfNull(Mainview.GetRowCellValue(e.RowHandle, "DateSON"), "") = "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "DateSON", Mainview.GetRowCellValue(e.RowHandle, "DateDep"))
                End If
            End If
        End If
    End Sub

    Private Sub cboVessel_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        If IfNull(cboVessel.EditValue, "") <> "" Then
            relieveDV.RowFilter = "FKeyVslCode = '" & cboVessel.EditValue & "' AND StatCode IN('SYSONB', 'SYSSICKONB')"
            '<!-- tony20180130
            'Dim strSql As String = "SELECT pc.IDNbr, pc.CurrActID, pc.ActGrpID, pc.Crew, pc.PlannedRank, pc.PlannedWScaleRank, pc.PlannedDateSON,pc.PlannedPlaceSON, pc.PlannedToRelieveID, pc.FKeyPlannedVsl, pc.PKey AS PlanEventCrewID " & _
            '                                     "FROM [frmPlannedCrew_Datasource] pc " & _
            '                                     "INNER JOIN dbo.Current_Activites curr_act ON pc.CurrActID = curr_act.PKey " & _
            '                                     "WHERE pc.FKeyPlannedVsl = '" & cboVessel.EditValue & "' " & _
            '                                     IIf(userdatafilterstring.Length > 0, " AND " & userdatafilterstring & " ", "") & _
            '                                     " ORDER BY SortCode"
            Dim strSql As String = "SELECT pc.IDNbr, pc.CurrActID, pc.ActGrpID, pc.Crew, pc.PlannedRank, pc.PlannedWScaleRank, pc.PlannedDateSON,pc.PlannedPlaceSON, pc.PlannedToRelieveID, pc.FKeyPlannedVsl, pc.PKey AS PlanEventCrewID, nat.name as nat " & _
                                                 "FROM [frmPlannedCrew_Datasource] pc " & _
                                                 "INNER JOIN dbo.Current_Activites curr_act ON pc.CurrActID = curr_act.PKey INNER JOIN dbo.tblcrewinfo ci ON pc.idnbr = ci.pkey LEFT JOIN dbo.tbladmcntry nat ON ci.natcode = nat.pkey " & _
                                                 "WHERE pc.FKeyPlannedVsl = '" & cboVessel.EditValue & "' AND StatType = 3 " & _
                                                 IIf(userdatafilterstring.Length > 0, " AND " & userdatafilterstring & " ", "") & _
                                                 " ORDER BY pc.SortCode"
            '-->
            Plangrid.DataSource = DB.CreateTable(strSql)
        End If
    End Sub
#End Region

#Region "Validation"

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
        'edited by tony20170419
        'If IfNull(cboAgent.EditValue, "") = "" Or IfNull(cboVessel.EditValue, "") = "" Then
        '    MsgBox("Please complete required fields.", MsgBoxStyle.Information, GetAppName() & " - Activity")
        '    res = True
        '    Return res
        '    Exit Function
        'End If

        If IfNull(cboVessel.EditValue, "") = "" Then
            MsgBox("Please select the vessel.", MsgBoxStyle.Information, GetAppName() & " - Activity")
            res = True
            Return res
            Exit Function
        End If

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
            Next

            If AllowSignOn(i)(0) Then
                MsgBox("Please fix invalid input.", MsgBoxStyle.Information, GetAppName() & " - Activity")
                res = True
                Return res
                Exit Function
            End If
        Next
        Return res
    End Function

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
            Dim text As String = AllowSignOn(hi.RowHandle)(1)
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

            If AllowSignOn(e.RowHandle)(0) = True Then
                e.Graphics.DrawImageUnscaled(img, x1, y1)
                e.Handled = True
            End If

        End If
    End Sub

    Private Function AllowSignOn(ByVal rHandle As Integer) As ArrayList
        Dim arrRes As New ArrayList
        Dim currAct As Columns.GridColumn = Mainview.Columns("CurrActID")
        Dim hasErr As Boolean = False
        Dim strMsg As String = ""

        If IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSON"))) = False And IsDBNull(Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateDep"))) = False Then
            If validateActivity(Mainview.GetRowCellValue(rHandle, currAct), Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSON"))) = False Then
                strMsg = "Sign-on date must be later than the current activity."
                hasErr = True
            ElseIf validateActivity(Mainview.GetRowCellValue(rHandle, currAct), Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateDep"))) = False Then
                strMsg = "Departure date must be later than the current activity."
                hasErr = True
            ElseIf Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateSON")) < Mainview.GetRowCellValue(rHandle, Mainview.Columns("DateDep")) Then
                strMsg = "Departure date must be earlier than or the same with sign-on date."
                hasErr = True
            End If
        End If

        If IsDBNull(Mainview.GetRowCellValue(rHandle, "FKeyWScaleRank")) = False Then
            If Mainview.GetRowCellValue(rHandle, "FKeyWScaleRank") <> "" Then
                If IfNull(Mainview.GetRowCellValue(rHandle, "LOC"), 0) <= 0 Then
                    strMsg = "LOC months must be greater than 0."
                    hasErr = True
                End If

                If IfNull(Mainview.GetRowCellValue(rHandle, "LOCDays"), 0) < 0 Then
                    strMsg = "LOC days must be greater than 0."
                    hasErr = True
                End If
            End If
        End If

        arrRes.Add(hasErr)
        arrRes.Add(strMsg)
        Return arrRes
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

    Private Sub SignOn_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        strBContentFilter = ""
        _deleteid = Nothing
        clsAudit = Nothing
        strFilter = Nothing
        strStatFilter = Nothing
        downHitInfo = Nothing
        userdatafilterstring = Nothing

        dtMainview.Dispose()
        relieveDV.Dispose()
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
            Mainview.SetRowCellValue(0, "RelieveID", "")
        End If
    End Sub

#Region "Save/Load Layout"
    Public Overrides Sub SaveMainContentLayout()
        MyBase.SaveMainContentLayout()
        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
        Mainview.SaveLayoutToXml(strLayoutPath & "SignOn_Mainview.xml")
        LayoutControl1.SaveLayoutToXml(strLayoutPath & "SignOn_Layout.xml")
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        Try
            MyBase.LoadMainContentLayout()
            Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
            Mainview.RestoreLayoutFromXml(strLayoutPath & "SignOn_Mainview.xml")
            LayoutControl1.RestoreLayoutFromXml(strLayoutPath & "SignOn_Layout.xml")
        Catch ex As Exception
            'Wala talagang laman to. Para pag wala syang nakita default lang. :D
        End Try
    End Sub
#End Region

    Private Sub cboAgent_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAgent.EditValueChanged
        For i As Integer = 0 To Mainview.RowCount - 1
            Mainview.SetRowCellValue(i, "FKeyAgentCode", cboAgent.EditValue)
        Next
    End Sub

    Private Sub cboVessel_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cboVessel.EditValueChanging
        If Not VesselValidForSelection(cboVessel, e.NewValue) Then
            e.Cancel = True
        Else
            Dim dr As DataRow()
            dr = dtMainview.Select("PlanEventCrewID <> '' OR PlanEventCrewID NOT IS NULL")

            If dr.Count > 0 Then
                If MsgBox("Some crew(s) are planned in vessel " & cboVessel.Properties.GetDisplayValueByKeyValue(e.OldValue) & "." & vbNewLine &
                          "Selecting another vessel will remove the crew(s) planned in vessel " & cboVessel.Properties.GetDisplayValueByKeyValue(e.OldValue) & "." & vbNewLine &
                          "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, GetAppName) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    Dim dt As DataTable
                    dt = dtMainview.Copy
                    dt.Rows.Clear()
                    For cnt As Integer = 0 To dr.Count - 1
                        dt.ImportRow(dr(cnt))
                        dtMainview.Rows.Remove(dr(cnt))
                    Next
                    Mainview.GridControl.DoDragDrop(dt, DragDropEffects.Move)
                    dragEvent.Data.SetData(dt)
                    Plangrid_DragDrop(Maingrid, dragEvent)
                    Planview.ActiveFilterString = ""
                    For cnt As Integer = 0 To dtMainview.Rows.Count - 1
                        If Planview.ActiveFilterString.Length > 0 Then
                            Planview.ActiveFilterString = Planview.ActiveFilterString & " AND IDNbr <> '" & dtMainview(cnt)("IDNbr") & "' "
                        Else
                            Planview.ActiveFilterString = " IDNbr <> '" & dtMainview(cnt)("IDNbr") & "'"
                        End If
                    Next
                    'blList.ExecCustomFunction(New Object() {"SON_DraggedOutPlannedCrew", dragEvent})
                End If
            End If

        End If

    End Sub

    Public Shared Function VesselValidForSelection(_cboVessel As DevExpress.XtraEditors.LookUpEdit, _value As String, Optional ShowMessage As Boolean = True) As Boolean
        'added by tony20170410
        'this is added to avoid data problem wherein activities has no principal value
        Dim ReturnValue As Boolean = True

        If Not IsNothing(_value) Then
            If Not IsDBNull(_value) Then
                Dim dv As DataView = New DataView(_cboVessel.Properties.DataSource)

                dv.RowFilter = "PKey = '" & _value & "'"
                If dv.Count > 0 Then
                    If IfNull(dv(0).Item("FKeyPrincipal"), "").Equals("") Then
                        If ShowMessage Then MsgBox("You cannot select this vessel because it is not assigned to any principal." & vbNewLine & "Please assign the vessel to a principal or contact your system administrator for assistance.", MsgBoxStyle.Information)
                        ReturnValue = False
                    End If
                End If

            End If
        End If

        Return ReturnValue
    End Function

#Region "Pre-Joining Checking using the Competence Template"

    Private Sub CollectCrewData(crewID As String, crewName As String, rank As String)

        Dim rankName As String = MPSDB.DLookUp("Name", "tblAdmRank", "", "PKey='" & rank & "'")

        Dim _selectedCrew As SelectedCrewSignOn
        _selectedCrew.CrewIDNbr = crewID
        _selectedCrew.CrewName = "Crew Name : " & crewName
        _selectedCrew.Rank = "Rank : " & rankName
        SelectedCrewSignOn_Hash.Add(_selectedCrew)

    End Sub

    Private Function GatherCrewWithLackingCompetence(crewID As String, crewName As String, rank As String, competenceID As String, loc As String, dateSOn As String) As Integer

        Try
            Dim mainCompQuery As String = "SELECT *, REPLACE(CONVERT(NVARCHAR, DateExpiry, 106), ' ','-') AS Expiry, REPLACE(CONVERT(NVARCHAR, DateIssue, 106),' ','-') AS Issue " & _
                                          "FROM Checklist('" & crewID & "','" & rank & "','" & competenceID & "', " & loc & ",'" & Convert.ToDateTime(dateSOn).ToString("dd-MMM-yyyy") & "') " & _
                                          "WHERE Complied = 'No' ORDER BY Sorting"
            Dim vesselCompQuery As String = "SELECT * FROM GetCompetenceInVesselType('" & crewID & "','" & rank & "','" & competenceID & "') WHERE Complied = 'No' ORDER BY SortCode "


            Dim _mainCompetence As DataTable = MPSDB.CreateTable(mainCompQuery)
            Dim _vesselCompetence As DataTable = MPSDB.CreateTable(vesselCompQuery)

            If Not IsNothing(_mainCompetence) And _mainCompetence.Rows.Count > 0 Then
                _mainSource.Merge(_mainCompetence)
                _compentenceDocs.Add(_mainCompetence)
            End If

            If Not IsNothing(_vesselCompetence) And _vesselCompetence.Rows.Count > 0 Then
                _vesselSource.Merge(_vesselCompetence)
                _compentenceVsl.Add(_vesselCompetence)
            End If

            Return _mainCompetence.Rows.Count + _vesselCompetence.Rows.Count
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function OpenReportForNonCompliedCrews() As DialogResult

        Dim retVal As DialogResult
        Dim message As String = "You have crew" & IIf(SelectedCrewSignOn_Hash.Count > 1, "s", "") & " with lacking Competence for the vessel [" & _
                                MPSDB.DLookUp("Name", "tblAdmVsl", "", "PKey='" & cboVessel.EditValue & "'") & "]. Click 'Yes' if you want to proceed signing on the crew, or 'No' " & _
                                "to cancel the process and review the lacking documents."
        Try
            If _mainSource.Rows.Count > 0 Or _vesselSource.Rows.Count > 0 Then
                retVal = MessageBox.Show(message, "Sign On", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If retVal = DialogResult.No Then
                    Dim report As New LackCompetenceCrewReport(ConvertToDataTable(SelectedCrewSignOn_Hash), _mainSource, _vesselSource)
                End If
                Return retVal
            End If
            Return DialogResult.Yes
        Catch ex As Exception
            MsgBox(ex.Message)
            Return DialogResult.No
        End Try
    End Function

    'This method will receive a list with a specified user-defined types (T) and convert it to DataTable.
    Public Function ConvertToDataTable(Of T)(ByVal list As HashSet(Of T)) As DataTable
        Dim table As New DataTable()

        'Identify columns and types
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        'Insert record from the list to table.
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row) 'Add a single row
        Next
        Return table 'return the converted data.
    End Function


    'Private Sub PopulateMainCompetence(query As String, crewID As String)
    '    Try
    '        Dim mainComp_Hash As New HashSet(Of MainCompetence)
    '        Dim table As DataTable = MPSDB.CreateTable(query)
    '        For Each row As DataRow In table.Rows
    '            Dim _mainComp As MainCompetence
    '            With _mainComp
    '                .CrewID = crewID
    '                .DocType = row("DocType").ToString()
    '                .DocName = row("DocName").ToString()
    '                .Number = row("Number").ToString()
    '                .Issue = row("Issue").ToString()
    '                .Expiry = row("Expiry").ToString()
    '                .Country = row("Country").ToString()
    '                .Capacity = row("Capacity").ToString()
    '                .Complied = row("Complied").ToString()
    '                .Comment = row("Comment").ToString()
    '            End With
    '            If _mainComp.Complied.Equals("No") Then
    '                mainComp_Hash.Add(_mainComp)
    '            End If
    '        Next
    '        If mainComp_Hash.Count > 0 Then
    '            _mainCompetenceHash.Add(mainComp_Hash)
    '        End If
    '        table.Dispose()
    '    Catch ex As Exception
    '        LogErrors("--Error Generated in PopulateMainCompetence() method in SignOn.vb - Start --")
    '        LogErrors(ex.Message)
    '        LogErrors("--Error Generated in PopulateMainCompetence() method in SignOn.vb - End--")
    '        MessageBox.Show("An error has been encountered in Sign On - PopulateMainCompetence() method : " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub PopulateVesselCompetence(query As String, crewID As String)
    '    Try
    '        Dim vesselComp_Hash As New HashSet(Of VesselCompetence)
    '        Dim table As DataTable = MPSDB.CreateTable(query)
    '        For Each row As DataRow In table.Rows
    '            Dim _vslComp As VesselCompetence
    '            With _vslComp
    '                .CrewID = crewID
    '                .VslType = row("VslType").ToString()
    '                .RankName = row("RankName").ToString()
    '                .YrOfService = row("YrOfService").ToString()
    '                .TotalYrsOfService = row("TotalYrsOfService").ToString()
    '                .Complied = row("Complied").ToString()
    '            End With
    '            If _vslComp.Complied.Equals("No") Then
    '                vesselComp_Hash.Add(_vslComp)
    '            End If
    '        Next
    '        If vesselComp_Hash.Count > 0 Then
    '            _vesselCompetenceHash.Add(vesselComp_Hash)
    '        End If
    '        table.Dispose()
    '    Catch ex As Exception
    '        LogErrors("--Error Generated in PopulateVesselCompetence() method in SignOn.vb - Start --")
    '        LogErrors(ex.Message)
    '        LogErrors("--Error Generated in PopulateVesselCompetence() method in SignOn.vb - End--")
    '        MessageBox.Show("An error has been encountered in Sign On - PopulateVesselCompetence() method : " & ex.Message)
    '    End Try
    'End Sub



#End Region

    Private Sub Plangrid_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Plangrid.DragDrop
        Try
            blList.ExecCustomFunction(New Object() {"SON_DraggedOutPlannedCrew", e})
        Catch ex As Exception
            LogErrors("--Error Generated in Plangrid_DragDrop() method in SignOn.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in Plangrid_DragDrop() method in SignOn.vb - End--")

        End Try
    End Sub

    Private Sub GridControl1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)
        Beep()
    End Sub

    Private Sub Plangrid_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Plangrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
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
                'Dim dson As Date = Me.deDateSON.EditValue
                Dim dson As Date = IIf(Mainview.GetRowCellDisplayText(Mainview.FocusedRowHandle, "DateSON") = "",
                                                     Nothing, Mainview.GetRowCellValue(Mainview.FocusedRowHandle, "DateSON"))
                Dim vslname As String = Me.cboVessel.Text

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
End Class
