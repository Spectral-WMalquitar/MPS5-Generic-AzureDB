Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class Planning

#Region "Declarations"
    Dim downHitInfo As GridHitInfo
    Friend _tbl As New DataTable
    Dim _deleteid As String
    Dim recordCnt As Integer
    Dim vslDT, wscaleDT, portDT, rankDT, relieveDT, wsOnlyDT As New DataTable
    Dim relieveDV As DataView
    Dim refreshCrewlist As Boolean = True
    Dim strRelieveFilter As String
    Dim SONDateBeforeEditing As Date
    Dim filteredDataView As DataView
    Dim checkIfCrewToRelieveDuplicates As Boolean
    Dim strLastUpdatedBy As String
    Dim frmCreWOnb As New frmOnboardCrew

    Private FormName As String = "Planning"
    Dim clsAudit As New clsAudit 'neil
    'Private strLastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Dim strRemovedCrews As String
    Dim userdatafilterstring As String = ""

    Dim clsConflict As New clsCrewConflict
#End Region

#Region "Overridables"
    Public Overrides Sub RefreshData()

        If bLoaded = False Then
            MyBase.RefreshData()
            initLookupEdits()
            InitData()
            LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never  'set wage scale hidden for the moment.
            '                                                                                   the grid sets the crew's latest wage scale by default
            'SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            'SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            'SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetDeleteCaption(Name, "Delete Planning Event")
            SetEditCaption(Name, "Edit")
            SetSaveCaption(Name, "Save")
            SetAddCaption(Name, "Add Planning Event")
            Mainview.OptionsBehavior.Editable = False
            Mainview.OptionsBehavior.ReadOnly = True
            bLoaded = True
            enableControls(True)
            SetGridLayout(Mainview)
            SetGridLayout(CrewList)
            userdatafilterstring = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
            clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
            chkCompetenceFilter.Enabled = False
            CrewlistGrid.Enabled = False
            RaiseCustomEvent(Name, New Object() {"barChkShowAllPlanning"})
        End If

        'Dim crewlistDT As New DataTable
        'If refreshCrewlist = True Then
        '    crewlistDT = DB.CreateTable("SELECT * FROM Crewlist_Planning " & _
        '                                IIf(userdatafilterstring.Length > 0, "WHERE " & userdatafilterstring & " ", "") & _
        '                                IIf(userdatafilterstring.Length > 0 And chkCompetenceFilter.Checked = True, " AND " & GetCompetenceFilter() & " ", "") & _
        '                                "ORDER BY CrewName")
        '    CrewlistGrid.DataSource = crewlistDT
        '    refreshCrewlist = False
        'End If
        PopulateCrewList()

        If blList.GetID <> "" Then
            Dim dt As New DataTable
            bAddMode = False
            isEditdable = False
            strID = blList.GetID
            AllowEditing(Name, False)
            Mainview.SelectAll()
            Mainview.DeleteSelectedRows()
            userdatafilterstring = GetUserFilterString(, "curr_act.FKeyAgentCode", "curr_act.FKeyPrinCode", "curr_act.FKeyFlt")
            dt = DB.CreateTable("SELECT UPPER(ci.LName) + ', ' + ISNULL(ci.FName,'') + ' ' + ISNULL(ci.MName,'') as CrewName, " & _
                                 "pec.PKey, pec.CrewID, pec.FKeyRank as FKeyRankCode,ws.rn as WScaleCode, pec.ToRelieveID, pec.LOC, pec.LOCDays, pec.FKeyTravelEvent, curr_act.FKeyWScaleRankCode " & _
                                 "FROM tblPlanningEventCrew pec LEFT JOIN tblCrewInfo ci ON pec.CrewID = ci.PKey " & _
                                 "LEFT JOIN dbo.WAGESCALE ws ON ws.WScaleRankCode = pec.FKeyWageScaleRank LEFT JOIN " & _
                                 "dbo.Current_Activites curr_act ON pec.CrewID = curr_act.FKeyIDNbr " & _
                                 "WHERE pec.FKeyActivity IS NULL AND FKeyPlanningEvent = '" & blList.GetID & "' " & _
                                 IIf(userdatafilterstring.Length > 0, "AND " & userdatafilterstring & " ", ""))
            txtPlanEvent.EditValue = blList.GetFocusedRowData("PlanningEvent")
            luVsl.EditValue = blList.GetFocusedRowData("FKeyVessel")
            deDateSON.EditValue = blList.GetFocusedRowData("PlannedDateSON")
            luPlaceSON.EditValue = blList.GetFocusedRowData("PlannedPlaceSON")
            txtRemarks.EditValue = blList.GetFocusedRowData("Remarks")
            MaingridDragDrop(dt)
            recordCnt = Mainview.RowCount
            'CrewlistGrid.Enabled = False
            AllowAddition(Name, True)
            AllowDeletion(Name, True)
            AllowEditing(Name, True)
            AllowSaving(Name, False)
            enableControls(True)
            BRECORDUPDATEDs = False
            EditCheck(Name, False)
            CrewlistGrid.Enabled = False
        Else
            AddData()
        End If

        'Application.OpenForms.Cast(Of Form)().Except({Application.OpenForms("frmCrewMain")}).ToList().ForEach(Sub(form) form.Close())
        'Application.OpenForms.Cast(Of Form)().Except({Application.OpenForms("frmCrewMain"), Application.OpenForms("WaitForm")}).ToList().ForEach(Sub(form) form.Close())
        'BRECORDUPDATEDs = False
        frmCreWOnb.ReloadData(luVsl.EditValue)
        CloseCustomLoadScreen()
    End Sub

    Private Sub PopulateCrewList()
        Dim crewlistDT As New DataTable
        If refreshCrewlist = True Then
            Dim sCrewListSource As String = "SELECT * FROM Crewlist_Planning " & _
                                            IIf(userdatafilterstring.Length > 0, "WHERE " & userdatafilterstring & " ", "") & _
                                            IIf(userdatafilterstring.Length > 0 And chkCompetenceFilter.Checked = True, " AND " & GetCompetenceFilter() & " ", "") & _
                                            " ORDER BY CrewName"
            crewlistDT = DB.CreateTable(sCrewListSource.Replace("curr_act", "Crewlist_Planning"))
            CrewlistGrid.DataSource = crewlistDT
            refreshCrewlist = False
            If isEditdable Then
                chkCompetenceFilter.Enabled = True
            Else
                chkCompetenceFilter.Enabled = False
            End If

            If chkCompetenceFilter.Checked Then
                Try
                    If SplashScreenManager.Default IsNot Nothing Then CloseCustomLoadScreen() 'Added by calvhin 20170118
                    'SplashScreenManager.CloseForm() 'commented by calvhin 20170118
                Catch ex As Exception
                    Debug.WriteLine(ex.Message) 'This is a potential error.
                    LogErrors(" Checking Competence: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If strID <> "" Then
            If MessageBox.Show("Are you sure you want to delete """ & txtPlanEvent.EditValue & """?", "MPS5 - Planning", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim strDeletedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "Delete Plan.", 0, System.Environment.MachineName, "Deleted Planning Event", "Planning", "")
                clsAudit.saveAuditPreDelDetails("tblPlanningEvent", strID, strDeletedBy)
                Dim sqls As New ArrayList
                '<!--added by tony20180922 : Log Deletion
                Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblPlanningEvent", _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Crew Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                If DB.RunSql("DELETE FROM tblPlanningEvent WHERE PKey = '" & strID & "'") Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                End If
                MessageBox.Show("Successfully deleted """ & txtPlanEvent.EditValue & """.", "MPS5 - Planning")
                refreshCrewlist = True
                clearControls()
                RefreshData()
                isEditdable = False
                EditData()
                blList.RefreshData()
            End If
        Else
            MessageBox.Show("There is no record to delete.", "MPS5 - Planning")
        End If
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        strRemovedCrews = ""
        If isEditdable Then
            CrewlistGrid.Enabled = True
            AllowDeletion(Name, False)
            AllowSaving(Name, True)
            Mainview.OptionsBehavior.Editable = True
            Mainview.OptionsBehavior.ReadOnly = False
            bAddMode = False
            enableControls(False)
            chkCompetenceFilter.Enabled = True
        Else
            CrewlistGrid.Enabled = False
            AllowAddition(Name, True)
            AllowDeletion(Name, True)
            AllowSaving(Name, False)
            AllowEditing(Name, True)
            Mainview.OptionsBehavior.Editable = False
            Mainview.OptionsBehavior.ReadOnly = True
            chkCompetenceFilter.Enabled = False
            enableControls(True)
        End If
    End Sub

    Public Overrides Sub AddData()
        bAddMode = True
        clearControls()
        AllowSaving(Name, True)
        AllowEditing(Name, False)
        AllowDeletion(Name, False)
        CrewList.ClearColumnsFilter()
        CrewlistGrid.Enabled = True
        enableControls(False)
        Mainview.OptionsBehavior.ReadOnly = False
        Mainview.OptionsBehavior.Editable = True
        BRECORDUPDATEDs = False
    End Sub

    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList
        Dim PlanningEventID As String = ""
        Dim msg As String = ""
        Dim dr() As System.Data.DataRow
        If Mainview.RowCount > 0 Then
            If checkIfPlanningExist() Then
                MessageBox.Show("Planning event already exist", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPlanEvent.Focus()
                txtPlanEvent.SelectAll()
                BRECORDUPDATEDs = False
                Exit Sub
            End If

            If validateRequiredFields() Then
                BRECORDUPDATEDs = False
                Exit Sub
            End If

            If checkIfVesselHasExistingPlanningWithSameSignOnDate() Then
                MessageBox.Show("Planning for " & luVsl.Text & " with " & deDateSON.Text & " sign-on date already exist.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BRECORDUPDATEDs = False
                Exit Sub
            End If

            If checkIfCrewExistingPlanningOverlaps() Then
                BRECORDUPDATEDs = False
                Exit Sub
            End If

            If checkIfCrewToRelieveDuplicates Then
                MessageBox.Show("A crew to relieved was assigned to more than one crew.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                BRECORDUPDATEDs = False
                Exit Sub
            End If

            If bAddMode = True Then
                strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Add Planning.", 0, System.Environment.MachineName, "Added Planning Event", "Planning", "")
                'PlanningEventID = DB.CreateTable("SELECT dbo.SETID('tblPlanningEvent')").Rows(0).Item(0).ToString()
                DB.RunSql("INSERT INTO tblPlanningEvent([PlanningEvent],[FKeyVessel],[Vessel],[PlannedDateSON],[PlannedPlaceSON],[Remarks],[LastUpdatedBy], [PlanType]) " & _
                         "VALUES ('" & txtPlanEvent.EditValue & "', '" & luVsl.EditValue & "', '" & luVsl.Text & "', '" & deDateSON.Text & "', '" & luPlaceSON.EditValue & "', '" & txtRemarks.EditValue & "', '" & strLastUpdatedBy & "', 'PLAN')")
                PlanningEventID = DB.DLookUp("PKey", "tblPlanningEvent", "", "ID = IDENT_CURRENT('tblPlanningEvent')")
                For i As Integer = 0 To Mainview.RowCount - 1
                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Add Planning.", 0, System.Environment.MachineName, "DESC_HERE.", "Planning", Mainview.GetRowCellValue(i, "CrewID"))
                    dr = wscaleDT.Select("rn = '" & Mainview.GetRowCellValue(i, "WScaleCode") & "'")
                    sqls.Add("EXEC	[dbo].[SP_INSERT_UPDATE_PLANNINGCREW] " & _
                              "@strFkeyPlanningEvent = '" & PlanningEventID & "', " & _
                              "@strCrewID = '" & Mainview.GetRowCellValue(i, "CrewID") & "', " & _
                              "@strFKeyRank = '" & Mainview.GetRowCellValue(i, "FKeyRankCode") & "', " & _
                              "@strRank = '" & Mainview.GetRowCellDisplayText(i, "FKeyRankCode") & "', " & _
                              "@strFKeyWageScaleRank = '" & dr(0)("WScaleRankCode").ToString & "', " & _
                              "@strToRelieveID = '" & Mainview.GetRowCellValue(i, "ToRelieveID") & "', " & _
                              "@nLOC = " & Mainview.GetRowCellValue(i, "LOC") & ", " & _
                              "@nLOCDays = " & Mainview.GetRowCellValue(i, "LOCDays") & ", " & _
                              "@LastUpdatedBy = '" & strLastUpdatedBy & "'")
                Next
                msg = "Planning Event """ & txtPlanEvent.EditValue & """ Successfully Added."
                refreshCrewlist = True
            Else
                PlanningEventID = strID
                strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Add Planning.", 0, System.Environment.MachineName, "Update Planning Event", "Planning", "")
                sqls.Add("UPDATE [tblPlanningEvent] " & _
                         "SET [PlanningEvent] = '" & txtPlanEvent.EditValue & "' " & _
                            ",[FKeyVessel] = '" & luVsl.EditValue & "' " & _
                            ",[Vessel] = '" & luVsl.Text & "' " & _
                            ",[PlannedDateSON] = '" & deDateSON.Text & "' " & _
                            ",[PlannedPlaceSON] = '" & luPlaceSON.EditValue & "' " & _
                            ",[Remarks] = '" & txtRemarks.EditValue & "' " & _
                            ",[LastUpdatedBy] = '" & strLastUpdatedBy & "' " & _
                         "WHERE [PKey] = '" & PlanningEventID & "'")

                If strRemovedCrews <> "" Then
                    strRemovedCrews = Replace(strRemovedCrews, ";;", "','")
                    strRemovedCrews = Replace(strRemovedCrews, ";", "'")
                    sqls.Add("DELETE FROM tblPlanningEventCrew WHERE CrewID IN(" & strRemovedCrews & ") AND FKeyPlanningEvent = '" & PlanningEventID & "'")
                End If

                For i As Integer = 0 To Mainview.RowCount - 1
                    strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Add Planning.", 0, System.Environment.MachineName, "DESC_HERE.", "Planning", Mainview.GetRowCellValue(i, "CrewID"))
                    dr = wscaleDT.Select("rn = '" & Mainview.GetRowCellValue(i, "WScaleCode") & "'")
                    sqls.Add("EXEC	[dbo].[SP_INSERT_UPDATE_PLANNINGCREW] " & _
                              "@strFkeyPlanningEvent = '" & PlanningEventID & "', " & _
                              "@strCrewID = '" & Mainview.GetRowCellValue(i, "CrewID") & "', " & _
                              "@strFKeyRank = '" & Mainview.GetRowCellValue(i, "FKeyRankCode") & "', " & _
                              "@strRank = '" & Mainview.GetRowCellDisplayText(i, "FKeyRankCode") & "', " & _
                              "@strFKeyWageScaleRank = '" & dr(0)("WScaleRankCode").ToString & "', " & _
                              "@strToRelieveID = '" & Mainview.GetRowCellValue(i, "ToRelieveID") & "', " & _
                              "@nLOC = " & Mainview.GetRowCellValue(i, "LOC") & ", " & _
                              "@nLOCDays = " & Mainview.GetRowCellValue(i, "LOCDays") & ", " & _
                              "@LastUpdatedBy = '" & strLastUpdatedBy & "'")
                Next
                msg = "Planning Event """ & txtPlanEvent.EditValue & """ Updated."
                If recordCnt <> Mainview.RowCount Then refreshCrewlist = True
            End If
            DB.RunSqls(sqls)
            MessageBox.Show(msg, "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearControls()
            BRECORDUPDATEDs = False
            blList.RefreshData()
            RefreshData()
            EditData()
            blList.SetSelection(PlanningEventID)
            'Application.OpenForms.Cast(Of Form)().Except({Application.OpenForms("frmCrewMain"), Application.OpenForms("WaitForm")}).ToList().ForEach(Sub(form) form.Close())
            CloseCustomLoadScreen()

            '<!-- edited by tony20190812
            Dim clsSec As New clsSecurity
            clsSec.propSQLConnStr = DB.GetConnectionString

            Dim dv As New DataView(userPermDt)
            dv.RowFilter = "ObjectID = 'Travel_GTRS'"
            'If Not clsSec.hasNoUpdatePermission("Travel_GTRS", USER_ID, True, userPermDt)  Then    ' <<<< edited on tony2019812
            If Not clsSec.hasNoUpdatePermission("Travel_GTRS", USER_ID, True, userPermDt) And dv.Count > 0 Then
                'If MessageBox.Show("Do you want to assign Travel Event?", "MPS5- Planning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then ' <<<< edited on tony2019812
                If MessageBox.Show("Do you want to create a travel booking from this Planning Event?", "MPS5- Planning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RaiseCustomEvent(Name, New Object() {"GoTo", "Travel_GTRS", "Travel", PlanningEventID})
                End If
            End If
            'end tony -->
        Else
            MessageBox.Show("Please add crew/s.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region

#Region "Inits"
    Private Sub initLookupEdits()
        Dim userdatafilterstring As String = GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt")
        'unfiltered: vslDT = DB.CreateTable("SELECT Pkey as VslCode, Name as VslName FROM [tblAdmVsl] WHERE [VslStat] = 1 ORDER BY Name ASC") ' 
        vslDT = createFilteredData("SELECT Pkey as VslCode, Name as VslName, FKeyPrincipal, FKeyFlt FROM [tblAdmVsl] WHERE [VslStat] = 1", FilteredDataObjectType.SQL, "VslName", , , "FKeyPrincipal", "FKeyFlt")
        portDT = DB.CreateTable("SELECT Pkey as PortCode, Name as PortName FROM [tblAdmPort] ORDER BY Name ASC")
        rankDT = DB.CreateTable("SELECT Pkey as RankCode, Abbrv, Name as RankName FROM [tblAdmRank] ORDER BY Name ASC")
        wscaleDT = MPSDB.CreateTable("SELECT * FROM WAGESCALE WHERE [Active] <> 0 ORDER BY WageScale ASC")
        wsOnlyDT = DB.CreateTable("SELECT Pkey as WScaleCode, Name as WScaleName FROM tblAdmWScale WHERE [Active] <> 0 ORDER BY Name ASC")

        luVsl.Properties.DataSource = vslDT
        luVsl.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslCode"))
        luVsl.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslName"))
        luVsl.Properties.ValueMember = "VslCode"
        luVsl.Properties.DisplayMember = "VslName"
        luVsl.Properties.Columns("VslCode").Visible = False

        luPlaceSON.Properties.DataSource = portDT
        luPlaceSON.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortCode"))
        luPlaceSON.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PortName"))
        luPlaceSON.Properties.ValueMember = "PortCode"
        luPlaceSON.Properties.DisplayMember = "PortName"
        luPlaceSON.Properties.Columns("PortCode").Visible = False

        luWScale.Properties.DataSource = wsOnlyDT
        luWScale.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleCode"))
        luWScale.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleName"))
        luWScale.Properties.ValueMember = "WScaleCode"
        luWScale.Properties.DisplayMember = "WScaleName"
        luWScale.Properties.Columns("WScaleCode").Visible = False

        WScaleEdit.DataSource = wscaleDT
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleCode"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WageScale"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WScaleRankCode"))
        WScaleEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("rn"))
        WScaleEdit.DisplayMember = "WageScale"
        WScaleEdit.Columns("WScaleCode").Visible = False
        WScaleEdit.Columns("WScaleRankCode").Visible = False
        WScaleEdit.Columns("rn").Visible = False

        rankEdit.DataSource = rankDT
        rankEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode"))
        rankEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv"))
        rankEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankName"))
        rankEdit.Columns("RankCode").Visible = False

        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CrewName"))
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ToRelieve"))
        RelieveEdit.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankName"))
        RelieveEdit.Columns("ToRelieve").Visible = False

        deDateSON.Properties.EditMask = "dd-MMM-yyyy"
        deDateSON.Properties.Mask.UseMaskAsDisplayFormat = True

        genericDateEdit.EditMask = "dd-MMM-yyyy"
        genericDateEdit.Mask.UseMaskAsDisplayFormat = True
    End Sub

    Private Sub InitData()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "WScaleCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ToRelieveID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "LOC"
        ccolumn.DataType = System.Type.GetType("System.Int16")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "LOCDays"
        ccolumn.DataType = System.Type.GetType("System.Int16")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyTravelEvent"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)

        Maingrid.DataSource = _tbl
    End Sub
#End Region

#Region "Drag And Drop"

#Region "CrewlistView Drag n' Drop"
    Private Sub CrewList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CrewList.MouseDown
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

    Private Sub CrewList_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CrewList.MouseMove
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

    Private Sub CrewlistGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles CrewlistGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub CrewlistGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles CrewlistGrid.DragDrop
        crewlistDragDrop(e.Data.GetData(GetType(DataTable)))
    End Sub

    Private Sub crewlistDragDrop(ByVal dt As DataTable)
        Try
            Dim xtbl As DataTable = dt
            Dim row As DataRow
            If Not xtbl Is Nothing Then
                For Each row In xtbl.Rows
                    Dim xfilter As String = CrewList.ActiveFilterString
                    xfilter = xfilter.Replace(xfilter.Substring(xfilter.IndexOf(row("CrewID"), 0) - 17, 17 + CType(row("CrewID"), String).Length + 1), "")
                    CrewList.ActiveFilterString = xfilter
                    DeleteSelectedInMainView()
                Next
            End If
        Catch ex As Exception
            LogErrors(" Crewlist DragDrop: " & ex.Message)
        End Try
    End Sub

    Private Function GetSelectedRows() As DataTable
        Dim _tblcrew As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewName"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "WScaleCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ToRelieveID"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "LOC"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "LOCDays"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyWScaleRankCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tblcrew.Columns.Add(ccolumn)

        For Each xrow In CrewList.GetSelectedRows
            _tblcrew.ImportRow(CrewList.GetDataRow(xrow))
        Next

        Return _tblcrew
    End Function

    Public Sub DeleteSelectedInMainView()
        Dim i As Integer = 0
        While i < Mainview.RowCount
            If _deleteid.Contains(";" & Mainview.GetRowCellValue(i, "CrewID") & ";") Then
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
        '/Neil commented out/ If Mainview.RowCount = 0 Then AllowSaving(Name, False)
    End Sub
#End Region

#Region "Mainview Drag N'Drop"

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

                view.GridControl.DoDragDrop(DeleteSelectedRows(), DragDropEffects.Move)

                downHitInfo = Nothing

                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True

            End If

        End If

    End Sub

    Private Sub MainGrid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragDrop
        If IsNothing(luVsl.EditValue) Or IsNothing(deDateSON.EditValue) Then
            MsgBox("Please fill required fields first.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            Exit Sub
        End If

        '//// Neil 20170814 crew conflict feature
        Dim dd As New DataTable, maindt As New DataTable, dtres As New DataTable
        dd = e.Data.GetData(GetType(DataTable))
        maindt = Maingrid.DataSource
        dtres = clsConflict.CrewConflict_GetCrewWithConflict(dd.Rows(0)("CrewID"), maindt, "CrewID", MPSDB.GetConnectionString)

        If dtres.Rows.Count > 0 Then
            If MsgBox("Crew " & dd.Rows(0)("Crewname") & " is conflict with crew " & dtres.Rows(0)("CConflictName") & ", do you want to continue?", vbExclamation + vbYesNo) = vbNo Then
                Exit Sub
            End If
        End If
        '//////////////

        MaingridDragDrop(e.Data.GetData(GetType(DataTable)))
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MainGrid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Maingrid.DragOver
        If e.Data.GetDataPresent(GetType(DataTable)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Function DeleteSelectedRows() As DataTable
        Dim ntbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        ntbl.Columns.Add(ccolumn)
        _deleteid = ";"

        For Each xrow In Mainview.GetSelectedRows
            Mainview.GetDataRow(xrow).ClearErrors()
            _deleteid = _deleteid & Mainview.GetRowCellValue(xrow, "CrewID") & ";"
            ntbl.ImportRow(Mainview.GetDataRow(xrow))
        Next
        strRemovedCrews = strRemovedCrews & _deleteid
        Return ntbl
    End Function

    Private Sub MaingridDragDrop(ByVal dt As DataTable)
        Dim xtbl As DataTable = dt
        Dim strFilter As String = "(CrewID IS NOT NULL)"
        If Not xtbl Is Nothing Then
            Try
                For Each nrow In xtbl.Rows
                    'Dim temptbl As New DataTables
                    'Dim actDT As New DataTable
                    Dim LOC, LOCDays As Integer
                    Dim strWScaleRank As String = ""
                    If bAddMode Or isEditdable = True Then
                        If Not IfNull(luWScale.EditValue, "").Equals("") Then
                            strWScaleRank = MPSDB.DLookUp("rn", "WAGESCALE", "", "WScaleCode = '" & luWScale.EditValue & "' AND RankCode = '" & nrow("FKeyRankCode") & "'")
                        Else
                            If xtbl.Columns.Contains("FKeyWScaleRankCode") Then
                                If Not IfNull(nrow("FKeyWScaleRankCode"), "").Equals("") Then
                                    strWScaleRank = MPSDB.DLookUp("rn", "WAGESCALE", "", "WScaleRankCode = '" & nrow("FKeyWScaleRankCode") & "'")
                                End If
                            End If
                        End If

                        Dim dr() As System.Data.DataRow
                        If strWScaleRank <> "" Then
                            dr = wscaleDT.Select("rn = '" & strWScaleRank & "'")
                            LOC = IfNull(dr(0)("LOC"), 0)
                            LOCDays = IfNull(dr(0)("LOCDays"), 0)
                        End If
                    Else
                        'strWScaleRank = IfNull(nrow("WScaleCode"), "")
                        strWScaleRank = ""
                        If xtbl.Columns.Contains("FKeyWScaleRankCode") Then
                            If Not IfNull(nrow("FKeyWScaleRankCode"), "").Equals("") Then
                                strWScaleRank = MPSDB.DLookUp("rn", "WAGESCALE", "", "WScaleRankCode = '" & nrow("FKeyWScaleRankCode") & "'")
                            End If
                        End If
                        LOC = IfNull(nrow("LOC"), 0)
                        LOCDays = IfNull(nrow("LOCDays"), 0)
                    End If

                    Dim xrow() As Object = {nrow("CrewID"), nrow("CrewName"), nrow("FKeyRankCode"), strWScaleRank, nrow("ToRelieveID"), LOC, LOCDays}
                    _tbl.Rows.Add(xrow)

                Next
            Catch ex As Exception
                'MsgBox(ex.Message)
                LogErrors(" MaingridDragDrop: " & ex.Message)
            End Try

            For Each nrow In _tbl.Rows
                'strFilter = strFilter & " CrewID <> '" & nrow("CrewID") & "' AND"
                strFilter = strFilter & " AND CrewID <> '" & nrow("CrewID") & "'"
            Next

            Mainview.RefreshData()
            If Mainview.RowCount > 0 Then
                Mainview.SelectRow(0)
                AllowSaving(Name, True)
            End If
            'modified by tony20170628 - this is to keep the crew list in same focus after a crew is dragged to the list of crews to be planned
            Dim rowhandle As Integer = CrewList.FocusedRowHandle
            Dim tmpTopIndex As Integer = CrewList.TopRowIndex
            CrewList.ActiveFilterString = strFilter
            CrewList.FocusedRowHandle = IIf(rowhandle > 0 And rowhandle < CrewList.RowCount, rowhandle, 0)
            Try
                CrewList.TopRowIndex = tmpTopIndex
            Catch
                'do nothing
            End Try
            'end tony
        End If
    End Sub
#End Region

#End Region

#Region "Close Up Events"
    Private Sub luVsl_EditValueChanged(sender As Object, e As System.EventArgs) Handles luVsl.EditValueChanged
        'relieveDT = DB.CreateTable("SELECT UPPER(ci.LName) + ', ' + ISNULL(ci.FName,'') + ' ' + ISNULL(ci.MName,'') as CrewName, FKeyIDNbr as ToRelieve, ar.Abbrv as RankName, Current_Activites.FKeyStatCode FROM Current_Activites LEFT JOIN tblAdmRank ar ON Current_Activites.FkeyRankCode = ar.PKey LEFT JOIN tblCrewinfo ci ON ci.PKey = Current_Activites.FKeyIDNbr WHERE [FKeyVslCode] = '" & luVsl.EditValue & "' ORDER BY CrewName") ' AND Current_Activites.FKeyStatCode IN ('SYSONB','54') ")
        'Application.OpenForms.Cast(Of Form)().Except({Application.OpenForms("frmCrewMain")}).ToList().ForEach(Sub(form) form.Close())
        'Application.OpenForms.Cast(Of Form)().Except({Application.OpenForms("frmCrewMain"), Application.OpenForms("WaitForm")}).ToList().ForEach(Sub(form) form.Close())
        frmCreWOnb.Hide()
        CloseCustomLoadScreen()
        BRECORDUPDATEDs = True
        refreshCrewlist = True
        PopulateCrewList()
    End Sub

    Private Sub luWScale_EditValueChanged(sender As Object, e As System.EventArgs) Handles luWScale.EditValueChanged
        'Dim wscode As String = ""
        If Mainview.RowCount > 0 Then
            For i As Integer = 0 To Mainview.RowCount - 1
                'wscode = IfNull(Mainview.GetRowCellValue(i, "WScaleCode"), "")
                'If wscode = "" Then 'IsDBNull(Mainview.GetRowCellValue(i, "WScaleCode")) = True Then
                If IsDBNull(Mainview.GetRowCellValue(i, "FKeyRankCode")) = False Then
                    Mainview.SetRowCellValue(i, "WScaleCode", MPSDB.DLookUp("rn", "WAGESCALE", "", "WScaleCode = '" & luWScale.EditValue & "' AND RankCode = '" & Mainview.GetRowCellValue(i, "FKeyRankCode") & "'"))
                End If
                'End If
            Next
            Mainview.RefreshData()
        End If
    End Sub

    Private Sub Mainview_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles Mainview.CellValueChanged
        If e.Column.FieldName = "WScaleCode" Then
            If IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "WScaleCode")) = False Then
                If Mainview.GetRowCellValue(e.RowHandle, "WScaleCode") <> "" Then
                    Dim dr() As System.Data.DataRow
                    dr = wscaleDT.Select("rn = '" & Mainview.GetRowCellValue(e.RowHandle, "WScaleCode") & "'")
                    Mainview.SetRowCellValue(e.RowHandle, "LOC", dr(0)("LOC").ToString)
                    Mainview.SetRowCellValue(e.RowHandle, "LOCDays", dr(0)("LOCDays").ToString)
                End If
            End If
        End If
        If e.Column.FieldName = "FKeyRankCode" Then
            If IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "FKeyRankCode")) = False Then
                If Mainview.GetRowCellValue(e.RowHandle, "FKeyRankCode") <> "" Then
                    If IsDBNull(Mainview.GetRowCellValue(e.RowHandle, "WScaleCode")) = True Then
                        Dim rn As String = 0
                        For i As Integer = 0 To wscaleDT.Rows.Count - 1
                            If Mainview.GetRowCellValue(e.RowHandle, "FKeyRankCode") = wscaleDT.Rows(i).Item("RankCode") Then
                                If IsDBNull(luWScale.EditValue) = False Then
                                    If luWScale.EditValue = wscaleDT.Rows(i).Item("WScaleCode") Then
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
        If e.Column.FieldName = "ToRelieveID" And e.RowHandle = Mainview.FocusedRowHandle Then
            If IsDBNull(Mainview.GetFocusedRowCellValue("ToRelieveID")) = False Then
                Dim crew As String = Mainview.GetFocusedRowCellValue("ToRelieveID")
                For i As Integer = 0 To Mainview.DataRowCount - 1
                    If i <> Mainview.FocusedRowHandle Then
                        If crew = IfNull(Mainview.GetRowCellValue(i, "ToRelieveID"), "") Then
                            MessageBox.Show("Crew is already selected.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Mainview.SetFocusedRowCellValue("ToRelieveID", Nothing)
                        End If
                    End If
                Next
            End If
        End If
        BRECORDUPDATEDs = True
    End Sub
#End Region

#Region "Validations"
    Private Function checkIfPlanningExist() As Boolean
        Dim res As Boolean = False
        Try
            If bAddMode = True Then
                If DB.DLookUp("PlanningEvent", "tblPlanningEvent", "", "PlanningEvent='" & txtPlanEvent.EditValue & "'").ToString.Length > 0 Then Return True
            End If
            If isEditdable = True Then
                If txtPlanEvent.Tag = 1 Then
                    If DB.DLookUp("PlanningEvent", "tblPlanningEvent", "", "PlanningEvent='" & txtPlanEvent.EditValue & "'").ToString.Length > 0 Then Return True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LogErrors(" checkIfPlanningExist: " & ex.Message)
        End Try
        Return res
    End Function

    Private Function validateRequiredFields() As Boolean
        Dim res As Boolean = False
        Try
            If IsNothing(luVsl.EditValue) Or IsDBNull(luVsl.EditValue) Or _
                txtPlanEvent.Text = "" Or _
                 deDateSON.Text = "" Then
                MessageBox.Show("Please enter data on required fields.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                res = True
                Return res
                Exit Function
            End If

            For i As Integer = 0 To Mainview.DataRowCount - 1
                If IsNothing(Mainview.GetRowCellValue(i, "WScaleCode")) Or IsDBNull(Mainview.GetRowCellValue(i, "WScaleCode")) Or Mainview.GetRowCellValue(i, "WScaleCode") = "" Or _
                   IsNothing(Mainview.GetRowCellValue(i, "FKeyRankCode")) Or IsDBNull(Mainview.GetRowCellValue(i, "FKeyRankCode")) Or _
                   IsNothing(Mainview.GetRowCellValue(i, "LOC")) Or IsDBNull(Mainview.GetRowCellValue(i, "LOC")) Or _
                   IsNothing(Mainview.GetRowCellValue(i, "LOCDays")) Or IsDBNull(Mainview.GetRowCellValue(i, "LOCDays")) Then
                    MessageBox.Show("Please enter data on required fields.", "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    res = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LogErrors(" validateRequiredFields: " & ex.Message)
        End Try
        Return res
    End Function

    Private Function checkIfVesselHasExistingPlanningWithSameSignOnDate() As Boolean
        Dim res As Boolean = False
        Try
            If bAddMode Then
                If deDateSON.EditValue = DB.DLookUp("PlannedDateSON", "tblPlanningEvent", "", "FKeyVessel='" & luVsl.EditValue & "'") Then
                    res = True
                End If
            End If

            If isEditdable Then
                If deDateSON.Tag = 1 Then
                    If deDateSON.EditValue = DB.DLookUp("PlannedDateSON", "tblPlanningEvent", "", "FKeyVessel='" & luVsl.EditValue & "'") Then
                        res = True
                    End If
                End If
            End If
        Catch ex As Exception
            Return False
            LogErrors(" checkIfVesselHasExistingPlanningWithSameSignOnDate: " & ex.Message)
        End Try
        Return res
    End Function

    Private Function checkIfCrewExistingPlanningOverlaps() As Boolean
        Dim res As Boolean = False
        Dim msg As String = ""
        Dim cnt As Integer = 0
        Try
            If bAddMode = True Or (isEditdable = True And deDateSON.Tag = 1) Then
                If isEditdable = True And bAddMode = False Then cnt = 1
                For i As Integer = 0 To Mainview.DataRowCount - 1
                    Dim dt As DataTable = DB.CreateTable("SELECT PlannedDateSON, PlannedDateDue FROM tblPlanningEventCrew LEFT JOIN tblPlanningEvent ON tblPlanningEvent.PKey = tblPlanningEventCrew.FKeyPlanningEvent WHERE CrewID = '" & Mainview.GetRowCellValue(i, "CrewID") & "' ORDER BY PlannedDateDue DESC")
                    If dt.Rows.Count > cnt Then
                        If IsDBNull(dt.Rows(0).Item("PlannedDateDue")) = False Then
                            'If deDateSON.EditValue < CDate(dt.Rows(1).Item(0)) Then
                            If deDateSON.EditValue < CDate(dt.Rows(cnt).Item("PlannedDateDue")) Then
                                msg = msg & Mainview.GetRowCellValue(i, "CrewName") & " - From " & CDate(dt.Rows(0).Item("PlannedDateSON")).ToString("dd-MMM-yyyy") & " To " & CDate(dt.Rows(0).Item("PlannedDateDue")).ToString("dd-MMM-yyyy") & Environment.NewLine
                                res = True
                            End If
                            'End If
                        End If
                    End If
                Next
            End If

            If res = True Then
                MessageBox.Show("The following crews has existing planning event that overlaps with the sign-on date you entered." & Environment.NewLine & Environment.NewLine & msg, "MPS5 - Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Saving canceled: " & ex.Message, "MPS5 - Planning")
            LogErrors(" checkIfCrewExistingPlanningOverlaps: " & ex.Message)
        End Try
        Return res
    End Function
#End Region

#Region "Backcolors"
    Private Sub fieldEdited(ByVal sender As Object, ByVal e As EventArgs) Handles txtPlanEvent.EditValueChanged, txtRemarks.EditValueChanged, luVsl.EditValueChanged, luWScale.EditValueChanged, deDateSON.EditValueChanged ', luPlaceSON.EditValueChanged
        Dim cntrl As Control = TryCast(sender, DevExpress.XtraEditors.TextEdit)

        If sender.GetType Is GetType(DevExpress.XtraEditors.LookUpEdit) Then
            cntrl = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        ElseIf sender.GetType Is GetType(DevExpress.XtraEditors.DateEdit) Then
            cntrl = TryCast(sender, DevExpress.XtraEditors.DateEdit)
        End If

        If bAddMode Or isEditdable Then
            cntrl.Tag = 1
            cntrl.BackColor = EDITED_COLOR
            BRECORDUPDATEDs = True
        Else
            cntrl.Tag = 0
        End If

        If (cntrl.Name = "luVsl" Or cntrl.Name = "deDateSON") And
            (luVsl.EditValue <> Nothing And deDateSON.EditValue <> Nothing) Then
            relieveDT = DB.CreateTable("EXEC Planning_CrewToRelieve_Datasource @VslCode = '" & luVsl.EditValue & "', @PlannedDateSON = " & ChangeToSQLDate(deDateSON.EditValue))
            relieveDV = New DataView(relieveDT)
            RelieveEdit.DataSource = relieveDV
        End If
    End Sub

    Private Sub deDateSON_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles deDateSON.EditValueChanging
        If Mainview.RowCount > 0 Then
            MsgBox("Date Sign On must not be empty.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            e.Cancel = True
            Exit Sub
        End If
        SONDateBeforeEditing = CDate(e.OldValue).ToString("dd-MMM-yyyy")
    End Sub

    Private Sub GotFocusEdited(ByVal sender As Object, ByVal e As EventArgs) Handles txtPlanEvent.GotFocus, txtRemarks.GotFocus, luVsl.GotFocus, luWScale.GotFocus, deDateSON.GotFocus ', luPlaceSON.GotFocus
        Dim cntrl As Control = sender
        If bAddMode Or isEditdable Then
            If cntrl.Tag = 0 Then cntrl.BackColor = REQUIRED_SELECTED_COLOR
        End If
    End Sub

    Private Sub LostFocusEdited(ByVal sender As Object, ByVal e As EventArgs) Handles txtPlanEvent.LostFocus, txtRemarks.LostFocus, luVsl.LostFocus, luWScale.LostFocus, deDateSON.LostFocus ', luPlaceSON.LostFocus
        Dim cntrl As Control = sender
        If bAddMode Or isEditdable Then
            If cntrl.Tag = 0 Then
                cntrl.BackColor = REQUIRED_COLOR
            End If
        End If
    End Sub

    Private Sub clearControls()
        Mainview.SelectAll()
        Mainview.DeleteSelectedRows()
        txtPlanEvent.EditValue = Nothing
        luVsl.EditValue = Nothing
        deDateSON.EditValue = Nothing
        luPlaceSON.EditValue = Nothing
        luWScale.EditValue = Nothing
        txtRemarks.EditValue = Nothing
        CrewlistGrid.Enabled = True

        'Mainview.SelectAll()
        'Mainview.DeleteSelectedRows()
    End Sub

    Private Sub enableControls(ByVal bol As Boolean)
        Dim back_kulay As System.Drawing.Color

        txtPlanEvent.ReadOnly = bol
        luVsl.ReadOnly = bol
        deDateSON.ReadOnly = bol
        luPlaceSON.ReadOnly = bol
        luWScale.ReadOnly = bol
        txtRemarks.ReadOnly = bol
        RelieveEdit.ReadOnly = bol
        lblViewOnb.Enabled = Not bol

        If bol = True Then
            back_kulay = DISABLED_COLOR
            lblViewOnb.ForeColor = Color.DarkGray
        Else
            back_kulay = REQUIRED_COLOR
            lblViewOnb.ForeColor = Color.Blue
        End If

        txtPlanEvent.BackColor = back_kulay
        luVsl.BackColor = back_kulay
        deDateSON.BackColor = back_kulay
        'luPlaceSON.BackColor = back_kulay
        luWScale.BackColor = back_kulay
        txtRemarks.BackColor = back_kulay
    End Sub
#End Region

    Private Sub RelieveEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RelieveEdit.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Mainview.SetRowCellValue(Mainview.FocusedRowHandle, "ToRelieveID", Nothing)
        End If
    End Sub

    Private Sub RelieveEdit_EditValueChanged(sender As Object, e As System.EventArgs) Handles RelieveEdit.EditValueChanged
        Mainview.FocusedColumn = Mainview.Columns(0)
    End Sub

    Private Sub luPlaceSON_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles luPlaceSON.ButtonClick
        If bAddMode = True Or isEditdable = True Then
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
                luPlaceSON.EditValue = Nothing
            End If
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel, GetAppName)
        If res = MsgBoxResult.Yes Then
            'flag = True
            'ALLOWNEXTS = flag
            'SaveData() '
            If validateRequiredFields() Or Mainview.HasColumnErrors = True Then
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

#Region "Save/Load Layout"
    Public Overrides Sub SaveMainContentLayout()
        MyBase.SaveMainContentLayout()
        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
        CrewList.SaveLayoutToXml(strLayoutPath & "Planning_CrewList_Layout.xml")
        Mainview.SaveLayoutToXml(strLayoutPath & "Planning_Mainview_Layout.xml")
        Dim strSplitterPositions As String
        strSplitterPositions = SplitContainerControl1.SplitterPosition
        Dim wtr As IO.StreamWriter = System.IO.File.CreateText(strLayoutPath & "Planning_SplitterPositions.txt")
        Using wtr
            wtr.WriteLine(strSplitterPositions)
        End Using
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        Try
            MyBase.LoadMainContentLayout()
            Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
            Dim rdr As IO.StreamReader = System.IO.File.OpenText(strLayoutPath & "Planning_SplitterPositions.txt")
            Using rdr
                Dim nSplitterPositions() As String = rdr.ReadLine().ToString.Split(";")
                CrewList.RestoreLayoutFromXml(strLayoutPath & "Planning_CrewList_Layout.xml")
                Mainview.RestoreLayoutFromXml(strLayoutPath & "Planning_Mainview_Layout.xml")
                SplitContainerControl1.SplitterPosition = nSplitterPositions(0)
            End Using
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub Planning_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        'Application.OpenForms.Cast(Of Form)().Except({Application.OpenForms("frmCrewMain")}).ToList().ForEach(Sub(form) form.Close())
        'Application.OpenForms.Cast(Of Form)().Except({Application.OpenForms("frmCrewMain"), Application.OpenForms("WaitForm")}).ToList().ForEach(Sub(form) form.Close())
        frmCreWOnb.Dispose()
        CloseCustomLoadScreen()
    End Sub

    Private Sub Planning_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or _
                    ControlStyles.UserPaint Or _
                    ControlStyles.AllPaintingInWmPaint Or _
                    ControlStyles.Selectable Or _
                    ControlStyles.StandardClick _
                    , True)
        Me.UpdateStyles()
    End Sub

    Private Sub chkCompetenceFilter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCompetenceFilter.CheckedChanged

        refreshCrewlist = True
        PopulateCrewList()

    End Sub

    Private Function GetCompetenceFilter() As String
        Dim sVslID As String = luVsl.EditValue
        Dim sCompetenceID As String = DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey='" & sVslID & "'")
        Dim sCompetence As String = DB.DLookUp("Name", "tblAdmComp", "", "PKey='" & sCompetenceID & "'")

        chkCompetenceFilter.ToolTip = "Vessel Competence : " & IIf(sCompetence.Equals(""), "[Not yet assigned]", sCompetence)

        If chkCompetenceFilter.Checked Then
            If isEditdable And sCompetence.Trim().Length = 0 Then
                MessageBox.Show("There is no competence assigned to this vessel.", "MPS5 Checking Competence", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return " CrewID IS NOT NULL "
            Else
                If SplashScreenManager.Default Is Nothing Then ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Checking Competence ...") 'Added by calvhin 20170118

                Return " PlannedDateSON IS NOT NULL AND CrewID IN (SELECT cp.CreWID FROM dbo.Crewlist_Planning cp " & _
                       " WHERE dbo.HasLacking_Filtering(cp.CrewID, cp.FKeyRankCode, '" & sCompetenceID & "', IIF(cp.LOC IS NULL, 0, cp.LOC), cp.PlannedDateSON, cp.FKeyRankCode) = 0)"

            End If
        End If
        Return ""

    End Function

    Private Sub CrewList_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles CrewList.SelectionChanged
        'Dim cnt As Integer = 0
        'For i As Integer = 0 To CrewList.SelectedRowsCount - 1
        '    If CrewList.FocusedRowHandle = CrewList.GetSelectedRows(i) Then
        '        cnt += 1
        '    End If
        'Next
        'If cnt = 1 Then CrewList.UnselectRow(CrewList.FocusedRowHandle)
    End Sub

    Private Sub lblViewOnb_Click(sender As System.Object, e As System.EventArgs) Handles lblViewOnb.Click
        If luVsl.Text <> "" Then
            frmCreWOnb.ReloadData(luVsl.EditValue)
            frmCreWOnb.Show()
        End If
    End Sub

    Private Sub Mainview_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Mainview.ShowingEditor

    End Sub

    Private Sub Mainview_ShownEditor(sender As Object, e As System.EventArgs) Handles Mainview.ShownEditor
        If Mainview.FocusedColumn.FieldName = "ToRelieveID" Then
            Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(Mainview.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            Dim ctbl As New DataTable
            Dim strFilter As String = ""

            strFilter = "RankName = '" & Mainview.GetFocusedRowCellDisplayText("FKeyRankCode") & "'"
            If relieveDT.Select(strFilter).Length > 0 Then
                ctbl = relieveDT.Select(strFilter).CopyToDataTable
            Else
                ctbl = relieveDV.ToTable.Copy
                ctbl.Clear()
            End If

            edit.Properties.DataSource = ctbl
        End If
    End Sub
End Class
