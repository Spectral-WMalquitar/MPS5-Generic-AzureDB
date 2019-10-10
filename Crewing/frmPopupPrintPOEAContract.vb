'Imports MPS4

Public Class frmPopupPrintPOEAContract

    Private CrewIDNbr As String
    'Public LName As String
    'Public FName As String
    'Public MName As String
    'Public FKeyRank As String
    'Public FKeyVessel As String
    'Public FKeyAgent As String
    'Public FKeyPrincipal As String
    'Public FKeyWageScale As String
    'Public LOC As Integer
    'Public LOCDays As Integer

    Public Sub New(IDNbr As String) '(LName As String, FName As String, MName As String, FKeyRank As String, FKeyVsl As String, FKeyAgent As String, FKeyPrincipal As String, FKeyWageScale As String, LOC As Integer, LOCDays As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.MainLayoutControl.AllowCustomization = False

        If IfNull(IDNbr, "").Length = 0 Then
            MsgBox("There is no crew selected.", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If

        'Dim cSQL As String = "SELECT	ca.fkeyIDNbr, " & _
        '                     "          dbo.AssembleName(ci.lname, ci.fname, ci.mname, 1, 1, 0, 0, 0) as Crew, " & _
        '                     "          p.FKeyVessel Planned_FKeyVsl, " & _
        '                     "          p.FKeyRank Planned_FKeyRank, " & _
        '                     "          p.FKeyWageScaleRank Planned_FKeyWageScaleRank,  " & _
        '                     "          p.FKeyPrincipal Planned_FKeyPrincipal,  " & _
        '                     "          p.LOC Planned_LOC, " & _
        '                     "          p.LOCDays Planned_LOCDays, " & _
        '                     "          ca.FKeyVslCode Current_FKeyVsl,  " & _
        '                     "          ca.FKeyRankCode Current_FKeyRank,  " & _
        '                     "          ca.FKeyWScaleRankCode Current_FKeyWageScaleRank,  " & _
        '                     "          ca.FKeyPrinCode Current_FKeyPrincipal,  " & _
        '                     "          ca.LOC Current_LOC, " & _
        '                     "          ca.LOCDays Current_LOCDays, " & _
        '                     "          ca.FKeyAgentCode, " & _
        '                     "          CASE WHEN p.FKeyPlanningEvent is null THEN ca.CurrentStatName ELSE 'Planned' END Status " & _
        '                     "FROM      dbo.Current_Activites ca INNER JOIN " & _
        '                     "          dbo.tblCrewInfo ci ON ca.FKeyIDNbr = ci.PKey LEFT OUTER JOIN " & _
        '                     "          (SELECT ped.*, v.FKeyPrincipal FROM dbo.PlannedCrewDetails ped LEFT JOIN dbo.tblAdmVsl v ON ped.FKeyVessel = v.PKey) p ON p.CrewID = ca.FKeyIDNbr AND p.rn = 1 AND p.FKeyActivity IS NULL " & _
        '                     "WHERE     FKeyIDNbr = '" & IDNbr & "'"

        'Dim cSQL As String = "SELECT	ca.fkeyIDNbr, " & _
        '                     "          dbo.AssembleName(ci.lname, ci.fname, ci.mname, 1, 1, 0, 0, 0) as Crew, " & _
        '                     "          p.FKeyVessel Planned_FKeyVsl, " & _
        '                     "          p.FKeyRank Planned_FKeyRank, " & _
        '                     "          p.FKeyWageScaleRank Planned_FKeyWageScaleRank,  " & _
        '                     "          p.FKeyPrincipal Planned_FKeyPrincipal,  " & _
        '                     "          p.PlannedPlaceSON Planned_PlaceSON, " & _
        '                     "          p.LOC Planned_LOC, " & _
        '                     "          p.LOCDays Planned_LOCDays, " & _
        '                     "          ca.FKeyVslCode Current_FKeyVsl,  " & _
        '                     "          ca.FKeyRankCode Current_FKeyRank,  " & _
        '                     "          ca.FKeyWScaleRankCode Current_FKeyWageScaleRank,  " & _
        '                     "          ca.FKeyPrinCode Current_FKeyPrincipal,  " & _
        '                     "          a.PlaceSON Current_PlaceSON, " & _
        '                     "          ca.LOC Current_LOC, " & _
        '                     "          ca.LOCDays Current_LOCDays, " & _
        '                     "          ca.FKeyAgentCode, " & _
        '                     "          CASE WHEN p.FKeyPlanningEvent is null THEN ca.CurrentStatName ELSE 'Planned' END Status " & _
        '                     "FROM      dbo.Current_Activites ca INNER JOIN " & _
        '                     "          dbo.tblCrewInfo ci ON ca.FKeyIDNbr = ci.PKey INNER JOIN " & _
        '                     "          dbo.tblactivity a ON a.pkey = ca.pkey LEFT OUTER JOIN " & _
        '                     "          (SELECT ped.*, v.FKeyPrincipal FROM dbo.PlannedCrewDetails ped LEFT JOIN dbo.tblAdmVsl v ON ped.FKeyVessel = v.PKey) p ON p.CrewID = ca.FKeyIDNbr AND p.rn = 1 AND p.FKeyActivity IS NULL " & _
        '                     "WHERE     FKeyIDNbr = '" & IDNbr & "'"

        Dim cSQL As String = "SELECT	ci.pkey as FKeyIDNbr, " & _
                             "          dbo.AssembleName(ci.lname, ci.fname, ci.mname, 1, 1, 0, 0, 0) as Crew, " & _
                             "          p.FKeyVessel Planned_FKeyVsl, " & _
                             "          p.FKeyRank Planned_FKeyRank, " & _
                             "          p.FKeyWageScaleRank Planned_FKeyWageScaleRank, " & _
                             "          p.FKeyPrincipal Planned_FKeyPrincipal, " & _
                             "          p.PlannedPlaceSON Planned_PlaceSON, " & _
                             "          p.LOC Planned_LOC, " & _
                             "          p.LOCDays Planned_LOCDays, " & _
                             "          recent_onb.FKeyVslCode Onboard_FKeyVsl, " & _
                             "          recent_onb.FKeyRankCode Onboard_FKeyRank, " & _
                             "          recent_onb.FKeyWScaleRankCode Onboard_FKeyWageScaleRank, " & _
                             "          recent_onb.FKeyPrinCode Onboard_FKeyPrincipal, " & _
                             "          recent_onb.PlaceSON Onboard_PlaceSON, " & _
                             "          recent_onb.LOC Onboard_LOC, " & _
                             "          recent_onb.LOCDays Onboard_LOCDays, " & _
                             "          recent_onb.FKeyAgentCode Onboard_FKeyAgentCode, " & _
                             "          ca.FKeyAgentCode Current_FKeyAgentCode, " & _
                             "          CASE WHEN p.FKeyPlanningEvent is null THEN ca.CurrentStatName ELSE 'Planned' END Status " & _
                             "FROM      dbo.tblCrewInfo ci INNER JOIN " & _
                             "          dbo.Current_Activites ca ON ca.FKeyIDNbr = ci.PKey LEFT OUTER JOIN " & _
                             "          (SELECT * FROM (SELECT ag.FKeyIDNbr, rn = ROW_NUMBER() OVER (PARTITION BY ag.FKeyIDNbr ORDER BY a.ActDateStart DESC), a.FKeyVslCode, a.FKeyRankCode, a.FKeyWScaleRankCode, a.FKeyPrinCode, a.PlaceSon,  a.FKeyAgentCode, ag.loc, ag.LOCDays FROM dbo.tblActivity a INNER JOIN dbo.tblActivityGroup ag ON a.FKeyActivityGroupID = ag.Pkey WHERE ag.FKeyIDNbr = '" & IDNbr & "' AND ag.IsCompServ <> 0 AND ag.ActivityType = 'SEA') t WHERE t.rn = 1) recent_onb ON recent_onb.fkeyidnbr = ci.PKey LEFT OUTER JOIN " & _
                             "          (SELECT ped.*, v.FKeyPrincipal FROM dbo.PlannedCrewDetails ped LEFT JOIN dbo.tblAdmVsl v ON ped.FKeyVessel = v.PKey) p ON p.CrewID = ca.FKeyIDNbr AND p.rn = 1 AND p.FKeyActivity IS NULL " & _
                             "WHERE     ci.PKey = '" & IDNbr & "'"

        Dim dt As DataTable = MPSDB.CreateTable(cSQL)

        If dt.Rows.Count = 0 Then
            MsgBox("Failed to initialize crew record.", MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If

        InitControls()

        LayoutControlGroup_SelectReport.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        txtDate.EditValue = DateTime.Now
        CrewIDNbr = IfNull(dt(0)("FKeyIDNbr"), "")
        txtCrewName.EditValue = IfNull(dt(0)("Crew"), "")
        txtStatus.EditValue = IfNull(dt(0)("Status"), "")
        cboRank.EditValue = IIf(IfNull(dt(0)("Planned_FKeyRank"), "").Length > 0, IfNull(dt(0)("Planned_FKeyRank"), ""), IfNull(dt(0)("Onboard_FKeyRank"), ""))
        cboVessel.EditValue = IIf(IfNull(dt(0)("Planned_FKeyVsl"), "").Length > 0, IfNull(dt(0)("Planned_FKeyVsl"), ""), IfNull(dt(0)("Onboard_FKeyVsl"), ""))
        cboAgent.EditValue = IIf(IfNull(dt(0)("Planned_FKeyVsl"), "").Length > 0, IfNull(dt(0)("Current_FKeyAgentCode"), ""), IfNull(dt(0)("Onboard_FKeyAgentCode"), ""))
        cboPrincipal.EditValue = IIf(IfNull(dt(0)("Planned_FKeyPrincipal"), "").Length > 0, IfNull(dt(0)("Planned_FKeyPrincipal"), ""), IfNull(dt(0)("Onboard_FKeyPrincipal"), ""))
        cboWageScale.EditValue = IIf(IfNull(dt(0)("Planned_FKeyWageScaleRank"), "").Length > 0, IfNull(dt(0)("Planned_FKeyWageScaleRank"), ""), IfNull(dt(0)("Onboard_FKeyWageScaleRank"), ""))
        cboPort.EditValue = IIf(IfNull(dt(0)("Planned_PlaceSOn"), "").Length > 0, IfNull(dt(0)("Planned_PlaceSOn"), ""), IfNull(dt(0)("Onboard_PlaceSOn"), ""))
        txtLOC.EditValue = IIf(IfNull(dt(0)("Planned_LOC"), "").Length > 0, IfNull(dt(0)("Planned_LOC"), 0), IfNull(dt(0)("Onboard_LOC"), 0))
        txtLOCDays.EditValue = IIf(IfNull(dt(0)("Planned_LOCDays"), "").Length > 0, IfNull(dt(0)("Planned_LOCDays"), 0), IfNull(dt(0)("Onboard_LOCDays"), 0))
        txtPlace.EditValue = "Manila, Philippines"

        chkPrintPOEAContract.Checked = True


        btnPrint.Focus()
    End Sub

    Public Sub InitControls()

        Me.txtCrewName.ReadOnly = True
        Me.txtCrewName.BackColor = DISABLED_COLOR

        Me.txtStatus.ReadOnly = True
        Me.txtStatus.BackColor = DISABLED_COLOR

        Me.cboRank.BackColor = REQUIRED_COLOR
        Me.txtLOC.BackColor = REQUIRED_COLOR
        Me.txtLOCDays.BackColor = REQUIRED_COLOR
        Me.cboWageScale.BackColor = REQUIRED_COLOR
        Me.cboVessel.BackColor = REQUIRED_COLOR
        Me.cboAgent.BackColor = REQUIRED_COLOR
        Me.cboPrincipal.BackColor = REQUIRED_COLOR
        Me.txtDate.BackColor = REQUIRED_COLOR
        Me.cboSignatory.BackColor = REQUIRED_COLOR
        Me.cboPort.BackColor = REQUIRED_COLOR
        Me.txtPlace.BackColor = REQUIRED_COLOR

        'RANK
        cboRank.Properties.DataSource = RankList(MPSDB)

        'WAGE SCALE
        cboWageScale.Properties.DataSource = WageRankScaleList(MPSDB)

        Dim userdatafilterstring As String

        'PORT
        cboPort.Properties.DataSource = PortList(MPSDB)

        'AGENT
        userdatafilterstring = GetUserFilterString(, "PKey")
        cboAgent.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.ManAgentList " & IIf(IfNull(userdatafilterstring, "").Length > 0, "WHERE " & userdatafilterstring & " ", "") & "ORDER BY Name")

        'PRINCIPAL
        userdatafilterstring = GetUserFilterString(, , "PKey")
        cboPrincipal.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.PrincipalList " & IIf(IfNull(userdatafilterstring, "").Length > 0, "WHERE " & userdatafilterstring & " ", "") & "ORDER BY Name")

        'VESSEL
        userdatafilterstring = GetUserVslFilterString(, "PKey")
        cboVessel.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.VslList_ActiveOnly " & IIf(IfNull(userdatafilterstring, "").Length > 0, "WHERE " & userdatafilterstring & " ", "") & "ORDER BY Name")

        'SIGNATORY
        Dim dtSign As DataTable = MPSDB.CreateTable("SELECT PKey, dbo.AssembleName(lname, fname, mname, 1,1,0,0,0) Name, Position, concat(dbo.AssembleName(lname, fname, mname, 1,1,0,0,0), CASE WHEN len(isnull(Position, '')) > 0 THEN concat(' / ', Position) ELSE '' END) AS NameAndPosition FROM dbo.tblAdmSign ORDER BY lname, fname, mname")
        Dim ctl As DevExpress.XtraEditors.SearchLookUpEdit
        Dim col As DevExpress.XtraGrid.Columns.GridColumn
        'ctl = TryCast(ctls(i), DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)
        ctl = cboSignatory
        With ctl
            .Properties.DataSource = dtSign
            col = .Properties.View.Columns.AddField("PKey")
            col.Visible = False
            col = .Properties.View.Columns.AddField("Name")
            col.Caption = "Name"
            col.Visible = True
            col = .Properties.View.Columns.AddField("Position")
            col.Caption = "Position"
            col.Visible = True
            col = .Properties.View.Columns.AddField("NameAndPosition")
            col.Caption = "NameAndPosition"
            col.Visible = False
            .Properties.View.OptionsFind.AlwaysVisible = False
        End With
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If chkPrintPOEAContract.Checked Then
            PrintPOEAContract()
        End If

    End Sub

    Private Sub PrintPOEAContract()
        Dim REPORT_DETAIL As New ReportDetail

        With REPORT_DETAIL
            .ReportInfo.ObjectID = "CUSTOM_POEA_CONTRACT"
            .ReportInfo.DLL = "ReportObjectsGovernment"
            .ReportInfo.ReportClass = "POEACont"

            .Params.Add("FKeyIDNbr", CrewIDNbr)
            .Params.Add("FKeyWScaleRank", IfNull(cboWageScale.EditValue, ""))
            .Params.Add("FKeyAgent", IfNull(cboAgent.EditValue, ""))
            .Params.Add("FKeyPrincipal", IfNull(cboPrincipal.EditValue, ""))
            .Params.Add("FKeyVsl", IfNull(cboVessel.EditValue, ""))
            .Params.Add("FKeyRank", IfNull(cboRank.EditValue, ""))
            .Params.Add("FKeyPort", IfNull(cboPort.EditValue, ""))
            .Params.Add("LOC", IfNull(txtLOC.EditValue, ""))
            .Params.Add("LOCDays", IfNull(txtLOCDays.EditValue, ""))
            .Params.Add("Date", IfNull(txtDate.EditValue, ""))

            .Params.Add("Place", IfNull(txtPlace.EditValue, ""))

            .Params.Add("Signatory", IfNull(cboSignatory.Properties.View.GetFocusedRowCellValue("NameAndPosition"), ""))
            .Params.Add("Signatory_Name", IfNull(cboSignatory.Properties.View.GetFocusedRowCellValue("Name"), ""))
            .Params.Add("Signatory_Position", IfNull(cboSignatory.Properties.View.GetFocusedRowCellValue("Position"), ""))
        End With

        Dim eA As System.Reflection.Assembly


        eA = System.Reflection.Assembly.Load(REPORT_DETAIL.ReportInfo.DLL)
        eA.CreateInstance(REPORT_DETAIL.ReportInfo.DLL & "." & REPORT_DETAIL.ReportInfo.ReportClass, True, Reflection.BindingFlags.Default, Nothing, New Object() {REPORT_DETAIL}, Nothing, Nothing)

        'ADD TITLE PARAMETER TO REPORT
        BuildReportDisplayName(REPORT_DETAIL.MainReport, REPORT_DETAIL)

        OutputReport(REPORT_DETAIL.MainReport, REPORT_DETAIL.Output.Mode, REPORT_DETAIL.Output.ExportType, REPORT_DETAIL.Output.Path, REPORT_DETAIL)


    End Sub

    
End Class