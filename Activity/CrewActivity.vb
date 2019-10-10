Imports System.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class CrewActivity

#Region "Declarations"
    Dim frmPlan As frmPlannedCrew
    Dim _deleteid As String
    Dim downHitInfo As GridHitInfo = Nothing
    Friend dtMainview, dtMainviewSub As New DataTable
    Private grpList As New List(Of DevExpress.XtraLayout.LayoutControlGroup)
    Dim vslDT As New DataTable
    Dim portDT As New DataTable
    Dim rankDT As New DataTable
    Dim reasonDT As New DataTable
    Dim ashactDT As New DataTable
    Dim agentDT As New DataTable
    Dim wscaleDT As New DataTable
    Dim wsOnlyDT As New DataTable
    Dim relieveDT As New DataTable
    Dim relieveDV As New DataView
    Private strCurrent_Act, strActGroupID As String
    Dim strFilter, strStatFilter As String
    Dim strUpdatedBy As String = ""
    Dim ds As New DataSet
    Dim strTempID As Integer = 0
    Dim ctr As Integer = 0
    'Dim clsAudit As New clsAudit
#End Region

#Region "Easy Edit"
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><Activity>"
    Private FormName As String = "Crew Activity"
    Dim clsAudit As New clsAudit 'neil
    'Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If bLoaded = False Then
            initLookupEdits()
            AllowSaving(Name, True)

            InitData()
            InitSubData()
            initRelations()
            initControls()
            initCommandList()

            MainGrid.DataSource = ds.Tables("dtMainview")
            MainGrid.ForceInitialize()
            Mainview.OptionsDetail.AllowExpandEmptyDetails = False

            Dim gView As New DevExpress.XtraGrid.Views.Grid.GridView(MainGrid)
            MainGrid.LevelTree.Nodes.Add("ActivityHistory", gView) 'iakda ang gView bilang isang antas ng MainGrid
            gView.ViewCaption = "Activity History"
            gView.PopulateColumns(ds.Tables("dtMainviewSub")) 'igaya ang mga haligi ng gView sa dtMainviewSub
            gView.OptionsView.ShowGroupPanel = False
            gView.OptionsCustomization.AllowFilter = False
            gView.OptionsBehavior.Editable = False
            gView.OptionsBehavior.ReadOnly = True
            'gView.OptionsMenu.EnableColumnMenu = False 'tanggaling ang kumento kung ang iyong nais ay alisin ang mga pagpipilian kapag pinindot ng gumagamit ang kanang button ng mouse.
            gView.Columns("ActGrpID").VisibleIndex = -1
            gView.Columns("ActGrpID").OptionsColumn.ShowInCustomizationForm = False

            blList.Draggable(True)
            bLoaded = True
            AllowSaving(Name, False)
            SetSaveCaption(Name, "Save")
            cmdlist.EditValue = CURR_ACT
            strCurrent_Act = CURR_ACT
            clsAudit.propSQLConnStr = DB.GetConnectionString
        End If
        BRECORDUPDATEDs = False
    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim msg As String = ""
        Dim Act_Type As String = ""
        Dim strIDNbr As String = ""
        Dim dr() As System.Data.DataRow
        Dim selectedCrew As New Utilities.SelectedCrew()
        Dim sickOnbCrew As New Utilities.SelectedCrew()
        Dim listOfSelectedCrews As New List(Of Utilities.SelectedCrew)
        Dim listOfSickOnbCrews As New List(Of Utilities.SelectedCrew)
        Dim hasQualifyForMedHistory As Boolean = False
        Dim medHistoryLabel As String = ""

        sqls.Clear()

        If checkRequiredFields() = True Then
            'BRECORDUPDATEDs = False
            Exit Sub
        End If

        If strCurrent_Act = "GOBACK" Then
            If MsgBox("Are you sure you want go back to previous activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
                Exit Sub
            End If
        Else
            If MsgBox("Are you sure you want to add activity?", MsgBoxStyle.YesNo, GetAppName() & " - Activity") = vbNo Then
                Exit Sub
            End If
        End If

        For i As Integer = 0 To Mainview.RowCount - 1
            strIDNbr = getRowCellValue(i, "IDNbr").ToString
            strUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "INSERT_ACT_HERE", 0, System.Environment.MachineName, "DESC_HERE", "Activity", strIDNbr)
            If strCurrent_Act = "ASHACT" Then Act_Type = "ashore" Else Act_Type = "sea"

            Select Case strCurrent_Act
                Case "SON"
                    strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Sign-on")
                    dr = wscaleDT.Select("rn = '" & Mainview.GetRowCellValue(i, "WScaleCode") & "'")
                    sqls.Add("EXEC SP_SIGN_ON @IDNbr = '" & getRowCellValue(i, "IDNbr") & "',@CurrActID = '" & getRowCellValue(i, "CurrActID") & "', @ActivityType= '" & Act_Type & "', @DateDep =" & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateDep").ToString) & "," & _
                             "@PlaceDep = '" & getRowCellValue(i, "PlaceDep") & "', @LOC = " & IfNull(getRowCellValue(i, "LOC"), 0) & ", @FKeyVslCode = '" & getRowCellValue(i, "VslCode") & "'," & _
                             "@FKeyAgentCode = '" & getRowCellValue(i, "AgentCode") & "', @FKeyStatCode = 'SYSONB'," & _
                             "@DateSOn = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSON").ToString) & ", @PlaceSOn = '" & getRowCellValue(i, "PlaceSON") & "'," & _
                             "@FKeyWScaleRankCode = '" & dr(0)("WScaleRankCode").ToString & "', @RelievedID = '" & getRowCellValue(i, "RelievedID") & "', @Remarks = '" & getRowCellValue(i, "Remarks") & "', @LastUpdatedBy = '" & strUpdatedBy & "'," & _
                             "@LOCDAYS = " & IfNull(getRowCellValue(i, "LOCDays"), 0) & ", @FKeyRankCode = '" & getRowCellValue(i, "RankCode") & "'")

                    Mainview.SelectRow(i)
                    msg = "Sign-on complete."
                Case "SOFF"
                    strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Sign-off")
                    sqls.Add("EXEC [SP_SIGN_OFF] @IDNbr = '" & getRowCellValue(i, "IDNbr") & "', @ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "', @CurrActID = '" & getRowCellValue(i, "CurrActID") & "'," & _
                             "@DateArr = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateArr")) & ", @PlaceArr ='" & getRowCellValue(i, "PlaceArr") & "', @DateSOFF = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSOFF").ToString) & "," & _
                             "@PlaceSOFF = '" & getRowCellValue(i, "PlaceSOFF") & "', @PlaceStart = '" & getRowCellValue(i, "PlaceStart") & "', @StatCode = '" & getRowCellValue(i, "Reason") & "', @LastUpdatedBy = '" & strUpdatedBy & "', @Remarks = '" & getRowCellValue(i, "Remarks") & "'," & _
                             "@NxtAct = '" & getRowCellValue(i, "NxtAct") & "', @NxtActDateStart = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "ActDateStart").ToString) & ", @PlaceEnd = '" & getRowCellValue(i, "PlaceEnd") & "', @RankCode = NULL, @RelieverID = '" & getRowCellValue(i, "RelievedID") & "'")
                    msg = "Sign-off complete."


                    If (MPSDB.DLookUp("IncludeMedHistory", "tblAdmStat", False, "PKey='" & getRowCellValue(i, "Reason") & "'") = True) Then
                        selectedCrew = New Utilities.SelectedCrew()
                        selectedCrew.CrewIDNbr = getRowCellValue(i, "IDNbr")
                        selectedCrew.ActivityID = getRowCellValue(i, "CurrActID")
                        selectedCrew.ActivityGroupID = getRowCellValue(i, "ActGrpID")
                        selectedCrew.RankName = getRowCellValue(i, "RankName")
                        selectedCrew.FirstName = getRowCellValue(i, "Crew")
                        selectedCrew.StartActivityDate = Mainview.GetRowCellValue(i, "ActDateStart")
                        'selectedCrew.VesselName = blList.GetFocusedRowData("VslCode")
                        selectedCrew.VesselName = getRowCellValue(i, "VslCode")
                        listOfSelectedCrews.Add(selectedCrew)
                    End If
                    medHistoryLabel = "Signing Off Crew"
                Case "ASHACT"
                    strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Add Ashore Activity.")
                    sqls.Add("EXEC SP_SIGN_OFF @IDNbr = '" & getRowCellValue(i, "IDNbr") & "', @ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "', @CurrActID = '" & getRowCellValue(i, "CurrActID") & "'," & _
                             "@DateArr = '', @PlaceArr ='" & Nothing & "', @DateSOFF = '" & Nothing & "'," & _
                             "@PlaceSOFF = '', @PlaceStart = '" & getRowCellValue(i, "PlaceStart") & "', @StatCode = '', @LastUpdatedBy = '" & USER_NAME & "', @Remarks = '" & getRowCellValue(i, "Remarks") & "'," & _
                             "@NxtAct = '" & getRowCellValue(i, "NxtAct") & "', @NxtActDateStart = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "ActDateStart").ToString) & ", @PlaceEnd = '" & getRowCellValue(i, "PlaceEnd") & "', @RankCode = '" & getRowCellValue(i, "RankCode") & "', @RelieverID = ''")
                    msg = "Ashore activity successfuly added."

                    If (MPSDB.DLookUp("IncludeMedHistory", "tblAdmStat", False, "PKey='" & getRowCellValue(i, "NxtAct") & "'") = True) Then
                        selectedCrew = New Utilities.SelectedCrew()
                        selectedCrew.CrewIDNbr = getRowCellValue(i, "IDNbr")
                        selectedCrew.ActivityID = getRowCellValue(i, "CurrActID")
                        selectedCrew.ActivityGroupID = getRowCellValue(i, "ActGrpID")
                        selectedCrew.RankName = getRowCellValue(i, "RankName")
                        selectedCrew.FirstName = getRowCellValue(i, "Crew")
                        listOfSelectedCrews.Add(selectedCrew)
                    End If
                    medHistoryLabel = "Crew Ashore Activity"
                Case "TRANS"
                    strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Transfered")
                    sqls.Add("EXEC SP_TRANSFER @CurrActID = '" & getRowCellValue(i, "CurrActID") & "', @ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "'," & _
                             "@DateSON = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSON").ToString) & ", @PlaceSON = '" & getRowCellValue(i, "PlaceSON") & "', @DateSOFF = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateSOFF").ToString) & "," & _
                             "@PlaceSOFF = '" & getRowCellValue(i, "PlaceSOFF") & "', @FKeyVslCode = '" & getRowCellValue(i, "VslCode") & "'," & _
                             "@RelievedID = '', @Remarks = '" & getRowCellValue(i, "Remarks") & "', @LastUpdatedBy = '" & strUpdatedBy & "'")
                    msg = "Transfer complete."
                Case "PROM"
                    strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Promoted")
                    dr = wscaleDT.Select("rn = '" & Mainview.GetRowCellValue(i, "WScaleCode") & "'")
                    sqls.Add("EXEC SP_PROMOTE @CurrActID = '" & getRowCellValue(i, "CurrActID") & "', @ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "'," & _
                            "@DateProm = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "DateProm").ToString) & ", @NewRank = '" & getRowCellValue(i, "RankCode") & "', @WScaleRank = '" & dr(0)("WScaleRankCode").ToString & "' , " & _
                            "@Remarks = '" & getRowCellValue(i, "Remarks") & "', @LastUpdatedBy = '" & strUpdatedBy & "'")
                    msg = "Promotion complete."
                Case "GOBACK"
                    strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Go Back to Previous Status")
                    Dim strDeletedBy As String = strUpdatedBy.Replace("DESC_HERE", "Deleted current activity.")
                    clsAudit.saveAuditPreDelDetails("tblActivity", getRowCellValue(i, "CurrActID"), strDeletedBy)
                    sqls.Add("EXEC SP_GOBACK @CurrActID = '" & getRowCellValue(i, "CurrActID") & "', @ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "', @LastUpdatedBy = '" & strUpdatedBy & "'")
                    msg = "Previous activity restored."
                Case "SICKONB"
                    strUpdatedBy = strUpdatedBy.Replace("INSERT_ACT_HERE", "Set/End Sick Onboard")
                    sqls.Add("EXEC SP_SICKONB @CurrActID = '" & getRowCellValue(i, "CurrActID") & "', @ActGrpID = '" & getRowCellValue(i, "ActGrpID") & "', @StartDate = " & ChangeToSQLDate(Mainview.GetRowCellValue(i, "ActDateStart").ToString) & ", @Remarks = '" & getRowCellValue(i, "Remarks") & "', @LastUpdatedby = '" & strUpdatedBy & "'")
                    msg = "Set/end sick onboard successful."

                    Dim currActivity As String = MPSDB.DLookUp("FKeyStatCode", "tblActivity", "", "PKey='" & getRowCellValue(i, "CurrActID") & "'")

                    If (currActivity.Equals("SYSONB")) Then
                        selectedCrew = New Utilities.SelectedCrew()
                        selectedCrew.CrewIDNbr = getRowCellValue(i, "IDNbr")
                        selectedCrew.ActivityID = getRowCellValue(i, "CurrActID")
                        selectedCrew.ActivityGroupID = getRowCellValue(i, "ActGrpID")
                        selectedCrew.RankName = getRowCellValue(i, "RankName")
                        selectedCrew.FirstName = getRowCellValue(i, "Crew")
                        selectedCrew.StartActivityDate = Mainview.GetRowCellValue(i, "ActDateStart").ToString()
                        listOfSelectedCrews.Add(selectedCrew)
                        medHistoryLabel = "Sick Onboard Crews"
                    ElseIf (currActivity.Equals("SYSSICKONB")) Then
                        sickOnbCrew = New Utilities.SelectedCrew()
                        sickOnbCrew.CrewIDNbr = getRowCellValue(i, "IDNbr")
                        sickOnbCrew.ActivityID = getRowCellValue(i, "CurrActID")
                        sickOnbCrew.Remarks = IfNull(getRowCellValue(i, "Remarks"), "") 'IfNull added by Calvhin
                        sickOnbCrew.StartEndDate = ChangeToSQLDate(Mainview.GetRowCellValue(i, "ActDateStart").ToString)
                        listOfSickOnbCrews.Add(sickOnbCrew)
                    End If
            End Select
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

                If listOfSickOnbCrews.Count > 0 Then
                    Dim updateSickCrew As New ArrayList
                    For counter As Integer = 0 To listOfSickOnbCrews.Count - 1
                        Dim updateSickOnbQuery As String = "UPDATE tblMedHistory SET DateStatus = " & listOfSickOnbCrews(counter).StartEndDate & ", " & _
                                                           "FKeyMedStatus = 'SYSMEDFITTOWORK', " & _
                                                           "Remarks = '" & listOfSickOnbCrews(counter).Remarks + "' " & _
                                                           "WHERE FKeyIDNbr='" & listOfSickOnbCrews(counter).CrewIDNbr & "' AND " & _
                                                           "FKeyActivityID='" & listOfSickOnbCrews(counter).ActivityID & "'"
                        updateSickCrew.Add(updateSickOnbQuery)
                    Next

                    MPSDB.RunSqls(updateSickCrew, True)

                End If

                MsgBox(msg, MsgBoxStyle.Information, GetAppName() & " - Activity")
                Mainview.DeleteSelectedRows()
                If strCurrent_Act = "SON" Then ClearLayoutControls(grpSON, False)
                If strCurrent_Act = "SOFF" Then ClearLayoutControls(grpSOFF, False)
                If strCurrent_Act = "ASHACT" Then ClearLayoutControls(grpASHACT, False)
                If strCurrent_Act = "TRANS" Then ClearLayoutControls(grpTRANS, False)
                MemoEdit1.Text = ""
                'If strCurrent_Act = "SOFF" Then cmdlist.EditValue = "ASHACT"
                forceRefresh(True)
                blList.RefreshData()
                BRECORDUPDATEDs = False
                cmdlist_EditValueChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    'Added By Earlsan
    'Validation Check

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
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Private Sub cmdlist_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cmdlist.EditValueChanged
        If cmdlist.EditValue = "SON" And BRECORDUPDATEDs = True Then
            CheckValidateFields()
        End If

        showLayoutGroup(cmdlist.EditValue)
        strCurrent_Act = cmdlist.EditValue
        If Mainview.RowCount > 0 Then
            Mainview.SelectAll()
            Mainview.DeleteSelectedRows()
        End If

        Select Case strCurrent_Act
            Case "SON"
                strStatFilter = "(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')"
            Case "SOFF"
                strStatFilter = "(StatCode='SYSONB' OR StatCode='SYSSICKONB')"
                clmSOFFReliever.Visible = False 'Earlsan: 20161123
            Case "ASHACT"
                strStatFilter = "(StatCode<>'SYSONB' AND StatCode<>'SYSSICKONB')"
            Case "TRANS"
                strStatFilter = "(StatCode='SYSONB')"
            Case "PROM"
                strStatFilter = "(StatCode='SYSONB')"
            Case "GOBACK"
                strStatFilter = "(StatCode<>'')"
            Case "SICKONB"
                strStatFilter = "(StatCode='SYSONB' OR StatCode='SYSSICKONB')"
            Case Else
                clmSOFFReliever.Visible = True
        End Select
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
        AllowSaving(Name, False)
        'If CURR_ACT = "SOFF" Then
        '    relieveDV.RowFilter = "StatCode NOT IN('SYSONB', 'SYSSICKONB')"
        'End If
        BRECORDUPDATEDs = False
    End Sub

    Private Sub showLayoutGroup(ByVal tag As String)
        For i As Integer = 0 To grpList.Count - 1
            If grpList(i).Name = "grp" & tag Then
                grpList(i).Visibility = False

                'grpList(i).Expanded = True 'Removew By Earlsan 20161124
                'LayoutControlGroup2.Expanded = False 'Removew By Earlsan 20161124

            Else
                grpList(i).Visibility = True
                'grpList(i).Expanded = False 'Removew By Earlsan 20161124
                'LayoutControlGroup2.Expanded = True ' Removew By Earlsan 20161124
            End If
        Next

        For i As Integer = 0 To Mainview.Bands.Count - 1
            If Mainview.Bands(i).Name = "gb" & tag Then
                Mainview.Bands(i).Visible = True
            Else
                Mainview.Bands(i).Visible = False
            End If
        Next

        If tag = "PROM" Or tag = "GOBACK" Or tag = "SICKONB" Then
            ' LayoutControlItem3.Visibility = True
            LayoutControlGroup2.Visibility = True
        Else
            ' LayoutControlItem3.Visibility = False
            LayoutControlGroup2.Visibility = False
        End If
    End Sub

    Private Sub Mainview_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles Mainview.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        If Mainview.IsRowSelected(e.RowHandle) And e.Column.Tag = "Required" Then
            If IsDBNull(e.CellValue) Then
                e.Appearance.BackColor = REQUIRED_SELECTED_COLOR
            End If
        ElseIf Mainview.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
            e.Appearance.ForeColor = Color.Black
        Else
            If e.Column.Tag = "Required" Then
                If IsDBNull(e.CellValue) Then
                    e.Appearance.BackColor = REQUIRED_COLOR
                End If
            End If
        End If
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

    Private Function getRowCellValue(row As Integer, columnName As String)
        Try
            Return IfNull(Mainview.GetRowCellValue(row, columnName), "")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Mainview_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Mainview.KeyDown
        If (e.KeyCode And Not Keys.Modifiers) = Keys.E AndAlso e.Modifiers = Keys.Alt Then
            If ctr = 0 Then
                Mainview.ExpandMasterRow(Mainview.FocusedRowHandle)
                ctr = 1
            Else
                Mainview.CollapseMasterRow(Mainview.FocusedRowHandle)
                ctr = 0
            End If
        End If
    End Sub

    Private Sub Mainview_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles Mainview.SelectionChanged
        If Mainview.GetMasterRowExpanded(Mainview.FocusedRowHandle) = True Then
            ctr = 1
        Else
            ctr = 0
        End If
    End Sub

    Public Overrides Sub ActivityCommand(_activity As String)
        cmdlist.EditValue = _activity
    End Sub

#Region "Inits" 'kabaliktaran ng lamigs

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
    End Sub

    Private Sub initCommandList()
        Dim dt As New DataTable
        Dim clmn As DataColumn
        Dim xrow As DataRow

        clmn = New DataColumn
        clmn.ColumnName = "ActivityName"
        clmn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(clmn)

        clmn = New DataColumn
        clmn.ColumnName = "Tag"
        clmn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(clmn)

        xrow = dt.NewRow
        xrow("ActivityName") = "Ashore Activity"
        xrow("Tag") = "ASHACT"
        dt.Rows.Add(xrow)

        xrow = dt.NewRow
        xrow("ActivityName") = "Go Back to Previous Status"
        xrow("Tag") = "GOBACK"
        dt.Rows.Add(xrow)

        xrow = dt.NewRow
        xrow("ActivityName") = "Promote"
        xrow("Tag") = "PROM"
        dt.Rows.Add(xrow)

        xrow = dt.NewRow
        xrow("ActivityName") = "Sick Onboard"
        xrow("Tag") = "SICKONB"
        dt.Rows.Add(xrow)

        xrow = dt.NewRow
        xrow("ActivityName") = "Sign-off"
        xrow("Tag") = "SOFF"
        dt.Rows.Add(xrow)

        xrow = dt.NewRow
        xrow("ActivityName") = "Sign-on"
        xrow("Tag") = "SON"
        dt.Rows.Add(xrow)

        xrow = dt.NewRow
        xrow("ActivityName") = "Transfer"
        xrow("Tag") = "TRANS"
        dt.Rows.Add(xrow)

        'xrow = dt.NewRow
        'xrow("ActivityName") = "Contract Extension"
        'xrow("Tag") = "EXTND"
        'dt.Rows.Add(xrow)

        cmdlist.Properties.DataSource = dt
        cmdlist.Properties.DisplayMember = "ActivityName"
        cmdlist.Properties.ValueMember = "Tag"
        cmdlist.Properties.ShowFooter = False
        cmdlist.Properties.ShowHeader = False
        cmdlist.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ActivityName"))
        cmdlist.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Tag"))
        cmdlist.Properties.Columns("Tag").Visible = False
        cmdlist.Properties.SortColumnIndex = 0

        grpList.Add(grpASHACT)
        grpList.Add(grpSOFF)
        grpList.Add(grpSON)
        grpList.Add(grpTRANS)
        'cmdlist.EditValue = CURR_ACT
    End Sub

    Private Sub InitData()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "IDNbr"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Crew"
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
        ccolumn.ColumnName = "VslName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RankName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "StatName"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        'ccolumn = New DataColumn
        'ccolumn.ColumnName = "FkeyRankCode"
        'ccolumn.DataType = System.Type.GetType("System.String")
        'dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "WScaleCode"
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
        ccolumn.ColumnName = "VslCode"
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
        ccolumn.ColumnName = "PlaceDep"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateDep"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "RelievedID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Seniority"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "AgentCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActDateStart"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActDateEnd"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Reason"
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
        ccolumn.ColumnName = "DateAvail"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
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
        ccolumn.ColumnName = "NxtAct"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlaceEnd"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PlaceStart"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Remarks"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainview.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateProm"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        dtMainview.Columns.Add(ccolumn)
    End Sub

    Private Sub InitSubData()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActGrpID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Status"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Rank"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Vessel"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSign-on"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateSign-off"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActivityStartDate"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActivityEndDate"
        ccolumn.DataType = System.Type.GetType("System.String")
        dtMainviewsub.Columns.Add(ccolumn)
    End Sub

    Private Sub initRelations()
        ds.Tables.Add(dtMainview)
        ds.Tables.Add(dtMainviewsub)

        ds.Tables(0).TableName = "dtMainview"
        ds.Tables(1).TableName = "dtMainviewSub"

        Dim clmUnique As UniqueConstraint = New UniqueConstraint(New DataColumn() {dtMainview.Columns("ActGrpID")}, True)
        Dim clmForeign As ForeignKeyConstraint = New ForeignKeyConstraint(New DataColumn() {dtMainview.Columns("ActGrpID")}, New DataColumn() {dtMainviewsub.Columns("ActGrpID")})

        ds.Tables("dtMainview").Constraints.Add(clmUnique)
        ds.Tables("dtMainviewSub").Constraints.Add(clmForeign)

        ds.Relations.Add("ActivityHistory", ds.Tables("dtMainview").Columns("ActGrpID"), ds.Tables("dtMainviewSub").Columns("ActGrpID"))
    End Sub

    Private Sub initLookupEdits()
        '*****Look Up etitssssss
        ''edited by: tony20160229; Apply user-data filtering
        'unfiltered: vslDT = MPSDB.CreateTable("SELECT Pkey as VslCode, Name as VslName FROM [tblAdmVsl] WHERE [VslStat] = 1 ORDER BY Name ASC") ' 
        vslDT = createFilteredData("SELECT Pkey as VslCode, Name as VslName, FKeyPrincipal, FKeyFlt FROM [tblAdmVsl] WHERE [VslStat] = 1", FilteredDataObjectType.SQL, "VslName", , , "FKeyPrincipal", "FkeyFlt")
        portDT = MPSDB.CreateTable("SELECT Pkey as PortCode, Name as PortName FROM [tblAdmPort] ORDER BY Name ASC")
        rankDT = MPSDB.CreateTable("SELECT Pkey as RankCode, Abbrv as RankName FROM [tblAdmRank] ORDER BY Name ASC")
        reasonDT = MPSDB.CreateTable("SELECT PKey as StatCode, Name as StatName FROM tblAdmStat WHERE StatType = 2 AND Pkey <> 'SYSAPP' ORDER BY Name ASC")
        ashactDT = MPSDB.CreateTable("SELECT PKey as StatCode, Name as StatName FROM tblAdmStat WHERE StatType = 3 AND Pkey NOT IN ('SYSAPP', 'SYSHIRED', '67') ORDER BY Name ASC")
        'unfiltered: agentDT = MPSDB.CreateTable("SELECT PKey as AgentCode, Name as AgentName FROM ManAgentList ORDER BY Name ASC")
        agentDT = createFilteredData("SELECT PKey as AgentCode, Name as AgentName FROM ManAgentList", FilteredDataObjectType.SQL, "AgentName", , "AgentCode")
        wscaleDT = MPSDB.CreateTable("SELECT * FROM WAGESCALE WHERE [Active] <> 0 ORDER BY WageScale ASC")
        wsOnlyDT = MPSDB.CreateTable("SELECT Pkey as WScaleCode, Name as WScaleName FROM tblAdmWScale WHERE [Active] <> 0 ORDER BY Name ASC")
        Try
            relieveDT = New DataView(TryCast(blList.getBListDatasource(), DataTable)).ToTable(True, "Crew", "IDNbr", "FKeyVslCode", "StatCode", "RankName", "StatName")
            relieveDV = New DataView(relieveDT)
        Catch ex As Exception
            MessageBox.Show("Crew Activity : " + ex.Message)
        End Try
        VslEdit.DataSource = vslDT
        VslEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslCode"))
        VslEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslName"))
        VslEdit.Columns("VslCode").Visible = False

        WScaleEdit.DataSource = wscaleDT
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleCode"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WageScale"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleRankCode"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("rn"))
        WScaleEdit.DisplayMember = "WageScale"
        WScaleEdit.Columns("WScaleCode").Visible = False
        WScaleEdit.Columns("WScaleRankCode").Visible = False
        WScaleEdit.Columns("rn").Visible = False

        sonWScale.Properties.DataSource = wsOnlyDT
        sonWScale.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleCode"))
        sonWScale.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleName"))
        sonWScale.Properties.Columns("WScaleCode").Visible = False

        sonVsl.Properties.DataSource = vslDT
        sonVsl.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslCode"))
        sonVsl.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslName"))
        sonVsl.Properties.Columns("VslCode").Visible = False

        sonPlaceSON.Properties.DataSource = portDT
        sonPlaceSON.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        sonPlaceSON.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        sonPlaceSON.Properties.Columns("PortCode").Visible = False

        sonAgent.Properties.DataSource = agentDT
        sonAgent.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AgentCode"))
        sonAgent.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AgentName"))
        sonAgent.Properties.Columns("AgentCode").Visible = False

        AgentEdit.DataSource = agentDT
        AgentEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AgentCode"))
        AgentEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AgentName"))
        AgentEdit.Columns("AgentCode").Visible = False

        PortEdit.DataSource = portDT
        PortEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        PortEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        PortEdit.Columns("PortCode").Visible = False

        RankEdit.DataSource = rankDT
        RankEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode"))
        RankEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankName"))
        RankEdit.Columns("RankCode").Visible = False

        ReasonEdit.DataSource = reasonDT
        ReasonEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatCode"))
        ReasonEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatName"))
        ReasonEdit.Columns("StatCode").Visible = False

        StatusEdit.DataSource = ashactDT
        StatusEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatCode"))
        StatusEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatName"))
        StatusEdit.Columns("StatCode").Visible = False

        RelieveEdit.DataSource = relieveDV
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IDNbr"))
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Crew"))
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("FKeyVslCode"))
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatCode"))
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankName"))
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatName"))
        RelieveEdit.DisplayMember = "Crew"
        RelieveEdit.Columns("Crew").Width = 200
        RelieveEdit.Columns("StatName").Width = 100
        RelieveEdit.Columns("RankName").Width = 50
        RelieveEdit.Columns("IDNbr").Visible = False
        RelieveEdit.Columns("FKeyVslCode").Visible = False
        RelieveEdit.Columns("StatCode").Visible = False

        soffReason.Properties.DataSource = reasonDT
        soffReason.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatCode"))
        soffReason.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatName"))
        soffReason.Properties.Columns("StatCode").Visible = False

        soffPlaceSOFF.Properties.DataSource = portDT
        soffPlaceSOFF.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        soffPlaceSOFF.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        soffPlaceSOFF.Properties.Columns("PortCode").Visible = False

        ashPlaceEnd.Properties.DataSource = portDT
        ashPlaceEnd.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        ashPlaceEnd.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        ashPlaceEnd.Properties.Columns("PortCode").Visible = False

        ashPlaceStart.Properties.DataSource = portDT
        ashPlaceStart.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        ashPlaceStart.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        ashPlaceStart.Properties.Columns("PortCode").Visible = False

        ashNxtAct.Properties.DataSource = ashactDT
        ashNxtAct.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatCode"))
        ashNxtAct.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatName"))
        ashNxtAct.Properties.Columns("StatCode").Visible = False

        transVsl.Properties.DataSource = vslDT
        transVsl.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslCode"))
        transVsl.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslName"))
        transVsl.Properties.Columns("VslCode").Visible = False

        transPlaceSON.Properties.DataSource = portDT
        transPlaceSON.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        transPlaceSON.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        transPlaceSON.Properties.Columns("PortCode").Visible = False

        transPlaceSOFF.Properties.DataSource = portDT
        transPlaceSOFF.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        transPlaceSOFF.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        transPlaceSOFF.Properties.Columns("PortCode").Visible = False

        Dim dateFormat As String = "dd-MMM-yyyy"

        genericDateEdit.EditMask = dateFormat
        genericDateEdit.Mask.UseMaskAsDisplayFormat = True

        sonDateSON.Properties.EditMask = dateFormat
        sonDateSON.Properties.Mask.UseMaskAsDisplayFormat = True

        soffDateSOFF.Properties.EditMask = dateFormat
        soffDateSOFF.Properties.Mask.UseMaskAsDisplayFormat = True

        ashDateStart.Properties.EditMask = dateFormat
        ashDateStart.Properties.Mask.UseMaskAsDisplayFormat = True

        transDateSON.Properties.EditMask = dateFormat
        transDateSON.Properties.Mask.UseMaskAsDisplayFormat = True

        transDateSOFF.Properties.EditMask = dateFormat
        transDateSOFF.Properties.Mask.UseMaskAsDisplayFormat = True
        '*************************
    End Sub

#End Region

#Region "AutoFill"
    Private Sub Mainview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Mainview.CellValueChanged
        If strCurrent_Act = "SON" Then
            If e.Column.FieldName = "WScaleCode" Then
                If IsDBNull(getRowCellValue(e.RowHandle, "WScaleCode")) = False Then
                    If getRowCellValue(e.RowHandle, "WScaleCode") <> "" Then
                        Dim dr() As System.Data.DataRow
                        dr = wscaleDT.Select("rn = '" & Mainview.GetRowCellValue(e.RowHandle, "WScaleCode") & "'")
                        Mainview.SetRowCellValue(e.RowHandle, "LOC", dr(0)("LOC").ToString)
                        Mainview.SetRowCellValue(e.RowHandle, "LOCDays", dr(0)("LOCDays").ToString)
                    End If
                End If
            End If
            If e.Column.FieldName = "RankCode" Then
                If IsDBNull(getRowCellValue(e.RowHandle, "RankCode")) = False Then
                    If getRowCellValue(e.RowHandle, "RankCode") <> "" Then
                        If IsDBNull(getRowCellValue(e.RowHandle, "WScaleCode")) = True Then
                            Dim rn As String = 0
                            For i As Integer = 0 To wscaleDT.Rows.Count - 1
                                If getRowCellValue(e.RowHandle, "RankCode") = wscaleDT.Rows(i).Item("RankCode") Then
                                    If IsDBNull(sonWScale.EditValue) = False Then
                                        If sonWScale.EditValue = wscaleDT.Rows(i).Item("WScaleCode") Then
                                            rn = wscaleDT.Rows(i).Item("rn")
                                            Exit For
                                        End If
                                    Else
                                        rn = wscaleDT.Rows(i).Item("rn")
                                    End If
                                End If
                            Next
                            If rn > 0 Then Mainview.SetRowCellValue(e.RowHandle, "WScaleCode", rn)
                        End If
                    End If
                End If
            End If
            If e.Column.FieldName = "VslCode" Then
                If Mainview.GetFocusedDataRow("VslCode").ToString <> "" Then
                    relieveDV.RowFilter = "FKeyVslCode = '" & Mainview.GetFocusedDataRow("VslCode") & "' AND StatCode IN('SYSONB', 'SYSSICKONB')"
                End If
            End If

        ElseIf strCurrent_Act = "SOFF" Then
            If e.Column.FieldName = "DateArr" Then
                If e.Value.ToString <> "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "ActDateStart", DateAdd(DateInterval.Day, 1, e.Value))
                End If
            End If
            If e.Column.FieldName = "PlaceArr" Then
                If e.Value.ToString <> "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "PlaceStart", e.Value)
                End If
            End If
            If e.Column.FieldName = "Reason" Then
                If Mainview.GetRowCellValue(e.RowHandle, "NxtAct").ToString = "" Then
                    If e.Value.ToString <> "" Then
                        Mainview.SetRowCellValue(e.RowHandle, "NxtAct", "26")
                    End If
                End If
            End If
            If e.Column.FieldName = "PlaceStart" Then
                If e.Value.ToString <> "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "PlaceEnd", e.Value)
                End If
            End If
        ElseIf strCurrent_Act = "ASHACT" Then
            If e.Column.FieldName = "PlaceStart" Then
                If e.Value.ToString <> "" Then
                    Mainview.SetRowCellValue(e.RowHandle, "PlaceEnd", e.Value)
                End If
            End If
        End If
    End Sub
    Private Sub LagyanNgLamanLahatNgWalangLaman(sender As System.Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles soffPlaceSOFF.CloseUp, transPlaceSOFF.CloseUp, soffReason.CloseUp, sonVsl.CloseUp, transVsl.CloseUp, sonAgent.CloseUp, sonPlaceSON.CloseUp, transPlaceSON.CloseUp, ashNxtAct.CloseUp, ashPlaceEnd.CloseUp, ashPlaceStart.CloseUp
        If Mainview.RowCount > 0 Then
            Dim cntrl As Object = CTypeDynamic(sender, sender.GetType)
            If cntrl.Tag <> Nothing Then
                Dim fldName() As String
                fldName = cntrl.Tag.ToString.Split(";")
                For i As Integer = 0 To Mainview.RowCount - 1
                    For Each strTag In fldName
                        If IsDBNull(Mainview.GetRowCellValue(i, strTag)) = True Then
                            'If cntrl.GetType.FullName = "DevExpress.XtraEditors.DateEdit" Then
                            '    If validateActivity(Mainview.GetRowCellValue(i, "CurrActID"), e.Value) = True Then
                            '        Mainview.SetRowCellValue(i, strTag, e.Value)
                            '    End If
                            'Else
                            Mainview.SetRowCellValue(i, strTag, e.Value)
                            'End If
                        End If
                    Next
                Next
            End If
            Mainview.RefreshData()
        End If
    End Sub

    Private Sub LagyanNgLamanLahatNgDateNaWalangLaman(sender As Object, e As System.EventArgs) Handles soffDateSOFF.EditValueChanged, transDateSOFF.EditValueChanged, sonDateSON.EditValueChanged, transDateSON.EditValueChanged, ashDateStart.EditValueChanged
        If Mainview.RowCount > 0 Then
            Dim cntrl As DevExpress.XtraEditors.DateEdit = sender
            If cntrl.Tag <> Nothing Then
                Dim fldName() As String
                fldName = cntrl.Tag.ToString.Split(";")
                For i As Integer = 0 To Mainview.RowCount - 1
                    For Each strTag In fldName
                        If IsDBNull(Mainview.GetRowCellValue(i, strTag)) = True Then
                            If validateActivity(Mainview.GetRowCellValue(i, "CurrActID"), cntrl.EditValue) = True Then
                                Mainview.SetRowCellValue(i, strTag, cntrl.EditValue)
                            End If
                        End If
                    Next
                Next
            End If
            Mainview.RefreshData()
        End If
    End Sub

    Private Sub transDateSOFF_EditValueChanged(sender As Object, e As System.EventArgs) Handles transDateSOFF.EditValueChanged
        transDateSON.EditValue = DateAdd(DateInterval.Day, 1, transDateSOFF.EditValue)
    End Sub

    Private Sub sonWScale_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles sonWScale.CloseUp
        Dim wscode As String = ""
        If Mainview.RowCount > 0 Then
            For i As Integer = 0 To Mainview.RowCount - 1
                wscode = IfNull(Mainview.GetRowCellValue(i, "WScaleCode"), "")
                If wscode = "" Then 'IsDBNull(Mainview.GetRowCellValue(i, "WScaleCode")) = True Then
                    If IsDBNull(Mainview.GetRowCellValue(i, "RankCode")) = False Then
                        Mainview.SetRowCellValue(i, "WScaleCode", MPSDB.DLookUp("rn", "WAGESCALE", "", "WScaleCode = '" & e.Value & "' AND RankCode = '" & Mainview.GetRowCellValue(i, "RankCode") & "'"))
                    End If
                End If
            Next
            Mainview.RefreshData()
        End If
    End Sub

    Private Sub MemoEdit1_Leave(sender As Object, e As System.EventArgs) Handles MemoEdit1.Leave
        If Mainview.RowCount > 0 Then
            For i As Integer = 0 To Mainview.RowCount - 1
                If IsDBNull(Mainview.GetRowCellValue(i, "Remarks")) = True Then
                    Mainview.SetRowCellValue(i, "Remarks", MemoEdit1.EditValue)
                End If
            Next
        End If
    End Sub

    'Private Sub LagyanNgLamanAndMgaNapili(sender As System.Object, e As System.EventArgs) Handles soffDateSOFF.EditValueChanged, transDateSOFF.EditValueChanged, soffPlaceSOFF.EditValueChanged, transPlaceSOFF.EditValueChanged, soffReason.EditValueChanged, sonVsl.EditValueChanged, transVsl.EditValueChanged, sonAgent.EditValueChanged, sonDateSON.EditValueChanged, transDateSON.EditValueChanged, sonPlaceSON.EditValueChanged, transPlaceSON.EditValueChanged, ashNxtAct.EditValueChanged, ashDateStart.EditValueChanged, ashPlaceEnd.EditValueChanged, ashPlaceStart.EditValueChanged, MemoEdit1.Leave
    '    If Mainview.RowCount > 0 Then
    '        Dim cntrl As Object = CTypeDynamic(sender, sender.GetType)
    '        If cntrl.Tag <> Nothing Then
    '            Dim fldName() As String
    '            fldName = cntrl.Tag.ToString.Split(";")
    '            For i As Integer = 0 To Mainview.RowCount - 1
    '                For Each strTag In fldName
    '                    If Mainview.IsRowSelected(i) Then
    '                        Mainview.SetRowCellValue(i, strTag, cntrl.EditValue)
    '                    End If
    '                Next
    '            Next
    '        End If
    '    End If
    'End Sub
#End Region

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

                If Application.OpenForms().OfType(Of frmPlannedCrew).Any Then
                    If frmPlan.accepted = True Then
                        DeleteData()
                        frmPlan.accepted = False
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragDrop
        Dim xtbl As DataTable = e.Data.GetData(GetType(DataTable))
        If Not xtbl Is Nothing Then
            strFilter = strStatFilter
            Try
                For Each nrow In xtbl.Rows
                    Dim temptbl As New DataTable
                    Dim actDT As New DataTable
                    Dim crewRank As String
                    Dim Wscale As String = ""
                    Dim LOC As Integer = 0
                    Dim LOCDays As Integer = 0
                    Dim dr() As DataRow
                    Dim strReliever As String = ""
                    If strCurrent_Act = "SON" Then
                        dr = wscaleDT.Select("WScaleRankCode = '" & IfNull(nrow("PlannedWScaleRank"), "") & "'")
                        crewRank = IfNull(nrow("PlannedRank"), IfNull(nrow("FkeyRankCode"), ""))
                        If dr.Count > 0 Then
                            Wscale = dr(0)("rn")
                            LOC = IfNull(dr(0)("LOC"), 0)
                            LOCDays = IfNull(dr(0)("LOCDays"), 0)
                        End If
                    Else
                        crewRank = IfNull(nrow("FkeyRankCode"), "")
                        Wscale = ""
                    End If

                    If strCurrent_Act = "SON" Then
                        strReliever = IfNull(("PlannedToRelieveID"), "")
                    ElseIf strCurrent_Act = "SOFF" Then
                        strReliever = DB.DLookUp("CrewID", "tblPlanningEventCrew", "", "ToRelieveID = '" & IfNull(nrow("CurrActID"), "") & "'")
                    End If

                    Dim xrow() As Object = {nrow("IDNbr"), nrow("Crew"), IfNull(nrow("CurrActID"), ""), IfNull(nrow("ActGrpID"), "tempID" & strTempID), nrow("VslName"), nrow("RankName"), nrow("StatName"), crewRank, Wscale, nrow("PlannedDateSON"), nrow("PlannedPlaceSON"), nrow("FKeyPlannedVsl"), LOC, LOCDays, nrow("PlannedPlaceSON"), nrow("PlannedDateSON"), strReliever, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DB.GetDefAshStat()} ', IfNull(nrow("FkeyRankCode"), "")
                    dtMainview.Rows.Add(xrow)

                    temptbl = DB.CreateTable("SELECT FKeyActivityGroupID as ActGrpID, StatName as [Status], RankName as [Rank], VslName as [Vessel], CONVERT(VARCHAR(15),DateSON,106) as [DateSign-on], CONVERT(VARCHAR(15),DateSOFF,106) as [DateSign-off],CONVERT(VARCHAR(15),ActDateStart,106) as ActivityStartDate, CONVERT(VARCHAR(15),ActDateEnd,106) as ActivityEndDate FROM tblActivity WHERE FKeyActivityGroupID = '" & nrow("ActGrpID") & "' ORDER BY ActDateStart DESC")
                    For Each nsub In temptbl.Rows
                        Dim xsub() As Object = {nsub("ActGrpID"), nsub("Status"), nsub("Rank"), nsub("Vessel"), nsub("DateSign-on"), nsub("DateSign-off"), nsub("ActivityStartDate"), nsub("ActivityEndDate")}
                        dtMainviewSub.Rows.Add(xsub)
                    Next
                    strTempID += 1
                Next
            Catch ex As Exception
                'MsgBox(ex.Message)
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
                Mainview.SelectRow(0)
                If CURR_ACT = "GOBACK" Then AllowSaving(Name, True)
                BRECORDUPDATEDs = True
            Else
                BRECORDUPDATEDs = False
            End If
            blList.SetFilter(strFilter)
            If Application.OpenForms().OfType(Of frmPlannedCrew).Any Then frmPlan.SetFilter(strBContentFilter)
        End If
    End Sub

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MainGrid.DragOver
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
        End Try
        Return res
    End Function

    Private Function checkRequiredFields() As Boolean
        Dim res As Boolean = False
        Dim clm, cmln As New DevExpress.XtraGrid.Columns.GridColumn
        For i As Integer = 0 To Mainview.RowCount - 1
            For Each clm In Mainview.Bands("gb" & strCurrent_Act).Columns
                If clm.Tag = "Required" And IfNull(Mainview.GetRowCellValue(i, clm), "") = "" Then 'IsDBNull(Mainview.GetRowCellValue(i, clm)) = True Then
                    MsgBox("Please complete required fields.", MsgBoxStyle.Information, GetAppName() & " - Activity")
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
        Dim dateDue As Date

        If Mainview.RowCount > 0 Then
            Select Case strCurrent_Act
                Case "SON"
                    'view.Columns(7) - DateSON
                    'view.Columns(12) - DateDep
                    If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateSON"))) = False And IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateDep"))) = False Then
                        If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateSON"))) = False Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("DateSON", "Sign-on date must be later than the previous activity.")
                            AllowSaving(Name, False)
                            Exit Sub
                        ElseIf validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateDep"))) = False Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("DateDep", "Departure date must be later than the previous activity.")
                            AllowSaving(Name, False)
                            Exit Sub
                        ElseIf view.GetRowCellValue(e.RowHandle, view.Columns("DateSON")) < view.GetRowCellValue(e.RowHandle, view.Columns("DateDep")) Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("DateDep", "Departure date must be earlier than sign-on date.")
                            AllowSaving(Name, False)
                            Exit Sub
                        End If
                    End If
                    If IsDBNull(view.GetRowCellValue(e.RowHandle, "WScaleCode")) = False Then
                        If view.GetRowCellValue(e.RowHandle, "WScaleCode") <> "" Then
                            If IfNull(view.GetRowCellValue(e.RowHandle, "LOC"), 0) <= 0 Then
                                e.Valid = False
                                view.GetDataRow(e.RowHandle).SetColumnError("LOC", "LOC must be greater than 0.")
                                AllowSaving(Name, False)
                                Exit Sub
                            End If
                        End If
                    End If
                Case "SOFF"
                    'view.Columns(19) - DateArr
                    'view.Columns(16) - DateSOFF
                    'view.Columns(53) - DateStart of Nxt Activity
                    If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateSOFF"))) = False Then
                        If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateSOFF"))) = False Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("DateSOFF", "Sign-off date must be later than the previous activity.")
                            AllowSaving(Name, False)
                            Exit Sub
                        End If
                        If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateArr"))) = False Then
                            If view.GetRowCellValue(e.RowHandle, view.Columns("DateArr")) < view.GetRowCellValue(e.RowHandle, view.Columns("DateSOFF")) Then
                                e.Valid = False
                                view.GetDataRow(e.RowHandle).SetColumnError("DateArr", "Arrival date must be later than sign-off date.")
                                AllowSaving(Name, False)
                                Exit Sub
                            End If
                        End If
                        If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("ActDateStart"))) = False Then
                            If view.GetRowCellValue(e.RowHandle, view.Columns("DateArr")) >= view.GetRowCellValue(e.RowHandle, view.Columns("ActDateStart")) Then
                                e.Valid = False
                                view.GetDataRow(e.RowHandle).SetColumnError("ActDateStart", "Start date of next activity must be later than arrival date.")
                                AllowSaving(Name, False)
                                Exit Sub
                            End If
                        End If
                    End If
                Case "ASHACT"
                    'view.Columns(25) ActDateStart
                    If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("ActDateStart"))) = False Then
                        If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("ActDateStart"))) = False Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("ActDateStart", "Start date of activity must be later than the previous activity.")
                            AllowSaving(Name, False)
                            Exit Sub
                        End If
                    End If
                Case "TRANS"
                    'view.Columns(31) DateSON
                    'view.Columns(33) DateSOFF
                    dateDue = DB.DLookUp("DateDue", "tblActivityGroup", "", "PKey = '" & getRowCellValue(e.RowHandle, "ActGrpID") & "'")
                    If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateSON"))) = False Then
                        If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateSON"))) = False Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("DateSON", "Date of promotion must be later than the previous activity.")
                            AllowSaving(Name, False)
                            Exit Sub
                        End If
                        'If dateDue < view.GetRowCellValue(e.RowHandle, view.Columns("DateSON")) Then
                        '    e.Valid = False
                        '    view.GetDataRow(e.RowHandle).SetColumnError(view.Columns("DateSON").FieldName, "Contract overdue. Contract due is on " & dateDue & ".")
                        '    AllowSaving(Name, False)
                        '    Exit Sub
                        'End If
                        If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateSOFF"))) = False Then
                            If view.GetRowCellValue(e.RowHandle, view.Columns("DateSOFF")) >= view.GetRowCellValue(e.RowHandle, view.Columns("DateSON")) Then
                                e.Valid = False
                                view.GetDataRow(e.RowHandle).SetColumnError("DateSOFF", "Sign-off date must be earlier than sign-on date.")
                                AllowSaving(Name, False)
                                Exit Sub
                            End If
                            If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateSOFF"))) = False Then
                                e.Valid = False
                                view.GetDataRow(e.RowHandle).SetColumnError("DateSOFF", "Sign-off date must be later than the previous activity.")
                                AllowSaving(Name, False)
                                Exit Sub
                            End If
                        End If
                    End If
                Case "PROM"
                    'view.Columns(40) - DateProm
                    dateDue = DB.DLookUp("DateDue", "tblActivityGroup", "", "PKey = '" & getRowCellValue(e.RowHandle, "ActGrpID") & "'")
                    If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("DateProm"))) = False Then
                        If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("DateProm"))) = False Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("DateProm", "Date of promotion must be later than the previous activity.")
                            AllowSaving(Name, False)
                            Exit Sub
                        End If
                        'If dateDue < view.GetRowCellValue(e.RowHandle, view.Columns("DateProm")) Then
                        '    e.Valid = False
                        '    view.GetDataRow(e.RowHandle).SetColumnError(view.Columns("DateProm").FieldName, "Contract overdue. Contract due is on " & dateDue & ".")
                        '    AllowSaving(Name, False)
                        '    Exit Sub
                        'End If
                    End If
                Case "SICKONB"
                    If IsDBNull(view.GetRowCellValue(e.RowHandle, view.Columns("ActDateStart"))) = False Then
                        If validateActivity(view.GetRowCellValue(e.RowHandle, currAct), view.GetRowCellValue(e.RowHandle, view.Columns("ActDateStart"))) = False Then
                            e.Valid = False
                            view.GetDataRow(e.RowHandle).SetColumnError("ActDateStart", "Start date must be later than the previous activity.")
                            AllowSaving(Name, False)
                            Exit Sub
                        End If
                    End If
            End Select

            view.GetDataRow(e.RowHandle).ClearErrors()
            AllowSaving(Name, True)
        End If
    End Sub
#End Region

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
                    'ctr.Tag = 0
                End If
            End If
        Next
        'BRECORDUPDATEDs = False 'Test
    End Sub

    Private Sub lblViewPlan_Click(sender As System.Object, e As System.EventArgs) Handles lblViewPlan.Click
        If sonVsl.Text = "" Then
            MessageBox.Show("Please select a vessel.", "MPS5 - Activity", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        frmPlan = New frmPlannedCrew(sonVsl.EditValue, sonVsl.Text, portDT, rankDT, wscaleDT)
        frmPlan.Show()
    End Sub

    Private Sub RelieveEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RelieveEdit.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Mainview.SetRowCellValue(0, "RelievedID", Nothing)
            Mainview.FocusedColumn = Mainview.Columns(10)
        End If
    End Sub

#Region "Save/Load Layout"
    'Public Overrides Sub SaveMainContentLayout()
    '    MyBase.SaveMainContentLayout()
    '    Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
    '    Mainview.SaveLayoutToXml(strLayoutPath & "Activity_Mainview_Layout.xml")
    'End Sub

    'Public Overrides Sub LoadMainContentLayout()
    '    Try
    '        MyBase.LoadMainContentLayout()
    '        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
    '        Mainview.RestoreLayoutFromXml(strLayoutPath & "Activity_Mainview_Layout.xml")
    '    Catch ex As Exception
    '        'Wala talagang laman to. Para pag wala syang nakita default lang. :D
    '    End Try
    'End Sub
#End Region

    Private Sub CrewActivity_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        strBContentFilter = ""
    End Sub

    Private Sub Mainview_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Mainview.ShowingEditor
        If strCurrent_Act = "SON" Then
            If Mainview.GetFocusedDataRow("VslCode").ToString <> "" Then
                relieveDV.RowFilter = "FKeyVslCode = '" & Mainview.GetFocusedDataRow("VslCode") & "' AND StatCode IN('SYSONB', 'SYSSICKONB')"
            Else
                relieveDV.RowFilter = "1 = 0"
            End If
        End If
    End Sub
End Class
