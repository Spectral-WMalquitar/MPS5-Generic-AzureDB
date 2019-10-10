Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraScheduler.Outlook
Imports DevExpress.XtraScheduler.Outlook.Interop
Imports DevExpress.XtraScheduler.Reporting
Imports DevExpress.XtraPrinting
Imports System.Drawing
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports Crewing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraScheduler.Native

Public Class LTPV2
    Dim dtAppointments, dtNewDependencies, dtVessel, dtRank, dtWScaleRank, dtDependencies As New DataTable
    Dim colorSchemeCollection As SchedulerColorSchemaCollection
    Dim strCurrentVsl, strCurrentRank, strFilterMode As String
    Dim showAll As Boolean = False
    Dim frmCrewlist As New frmLTPCrewlist
    Dim isSupplying As Boolean = True

#Region "Loading Data"
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        InitDatatable()
        SetupLookupEdits()
        SetupSchedulerMapping()
        SchedulerEditMode(False)

        colorSchemeCollection = SchedulerControl1.GetResourceColorSchemasCopy()

        SetDeleteCaption(Name, "Delete")
        SetSaveCaption(Name, "Save")
        SetEditCaption(Name, "Edit")
        AllowEditing(Name, True)
    End Sub

    Public Overrides Function GetLTPFilterDS(ByVal filter As String) As DataTable
        If filter = "Rank" Then
            Return dtRank
        Else
            Return dtVessel
        End If
    End Function

    Public Overrides Sub FilterLTPResource(ByVal Id As String, ByVal FilterMode As String)
        Dim dtAppt As New DataTable
        Dim dtRes As New DataTable
        Dim strIdentifier As String = "FKey" & FilterMode
        Dim cFilterString As String = GetUserVslFilterString(, "[LTP_Datasource].[FKeyVessel]")

        dtAppointments = MPSDB.CreateTable("SELECT [Id],[PKey],[Start],[End],[Label],[Location],[FKeyRank],[Subject],[Percent],[FKeyVessel],[FKeyWScaleRank], [LOC], [LOCDays], [CrewID], [Remarks], [RecType], [PlanningEvent] FROM [dbo].[LTP_Datasource] WHERE " & strIdentifier & " = '" & Id & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY [Id]")
        With SchedulerControl1.Storage

            Select Case FilterMode
                Case "Vessel"
                    dtRes = dtRank
                    .Appointments.Mappings.ResourceId = "FKeyRank"
                    strCurrentVsl = Id
                    ResourcesTree1.Columns("Name").Caption = "Rank"
                Case "Rank"
                    dtRes = dtVessel
                    .Appointments.Mappings.ResourceId = "FKeyVessel"
                    strCurrentRank = Id
                    ResourcesTree1.Columns("Name").Caption = "Vessel"
            End Select
            strFilterMode = FilterMode
            .Appointments.DataSource = dtAppointments
            .Resources.DataSource = dtRes
            ResourcesTree1.RefreshDataSource()
            If dtAppointments.Rows.Count > 0 Then
                Dim sDate As Date = DateAdd(DateInterval.Month, -3, dtAppointments.Select("", "Start").CopyToDataTable.Rows(0)("Start"))
                SchedulerControl1.Start = sDate
                SchedulerControl1.LimitInterval.Start = sDate
                SchedulerControl1.OptionsRangeControl.MaxSelectedIntervalCount = 7
            End If
            ExpandActiveSchedulerView()

            'refresh relievers
            dtDependencies = MPSDB.CreateTable("SELECT * FROM LTP_Dependency WHERE DependentId IS NOT NULL")
            .AppointmentDependencies.DataSource = dtDependencies

        End With
    End Sub

    Public Overrides Sub LTPShowAllRecords(ByVal show As Boolean, ByVal FilterMode As String, ByVal FilterId As String)
        Select Case FilterMode
            Case "Vessel"
                If show = False Then
                    SchedulerControl1.Storage.Resources.DataSource = MPSDB.CreateTable("SELECT DISTINCT ar.Abbrv as [Name], ar.PKey, ar.SortCode FROM tblAdmRank ar INNER JOIN LTP_Datasource ltp ON ltp.FKeyRank = ar.PKey WHERE ltp.FKeyVessel = '" & FilterId & "' Order by ar.SortCode")
                Else
                    SchedulerControl1.Storage.Resources.DataSource = dtRank
                End If
            Case "Rank"
                Dim cFilterString As String = GetUserVslFilterString(, "[ltp].[FKeyVessel]")
                If show = False Then
                    SchedulerControl1.Storage.Resources.DataSource = MPSDB.CreateTable("SELECT DISTINCT Name, ar.PKey FROM tblAdmVsl ar INNER JOIN LTP_Datasource ltp ON ltp.FKeyVessel = ar.PKey WHERE ltp.FKeyRank = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY Name")
                Else
                    SchedulerControl1.Storage.Resources.DataSource = dtVessel
                End If
        End Select
        If ResourcesTree1.Nodes.Count > 0 Then ResourcesTree1.FocusedNode = ResourcesTree1.Nodes(0)
        showAll = show
        ExpandActiveSchedulerView()
    End Sub

    Public Overrides Function getColorSchemes() As DataTable
        Dim dtColors As New DataTable
        Dim clm As DataColumn
        clm = New DataColumn
        clm.ColumnName = "Caption"
        clm.DataType = System.Type.GetType("System.String")
        dtColors.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Index"
        clm.DataType = System.Type.GetType("System.Int32")
        dtColors.Columns.Add(clm)

        dtColors.Rows.Add(New Object() {"White", 0})
        dtColors.Rows.Add(New Object() {"Salt Pan", 1})
        dtColors.Rows.Add(New Object() {"Azure", 2})
        dtColors.Rows.Add(New Object() {"Linen", 3})
        dtColors.Rows.Add(New Object() {"Magnolia", 4})
        dtColors.Rows.Add(New Object() {"Cosmic Latte", 5})
        dtColors.Rows.Add(New Object() {"Lavander Blush", 6})
        dtColors.Rows.Add(New Object() {"Romance", 7})
        dtColors.Rows.Add(New Object() {"White Smoke", 8})
        dtColors.Rows.Add(New Object() {"Light Cyan", 9})
        dtColors.Rows.Add(New Object() {"Panache", 10})
        dtColors.Rows.Add(New Object() {"Beige", 11})
        dtColors.Rows.Add(New Object() {"Default", 12})
        Return dtColors
    End Function

    Private Sub InitDatatable()
        Dim clm As DataColumn

        clm = New DataColumn
        clm.ColumnName = "Id"
        clm.DataType = System.Type.GetType("System.Int64")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Start"
        clm.DataType = System.Type.GetType("System.DateTime")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "End"
        clm.DataType = System.Type.GetType("System.DateTime")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Subject"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Percent"
        clm.DataType = System.Type.GetType("System.Int64")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Label"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "FKeyRank"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "FKeyVessel"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "PKey"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "CrewID"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "FKeyWScaleRank"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "LOC"
        clm.DataType = System.Type.GetType("System.Int64")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "LOCDays"
        clm.DataType = System.Type.GetType("System.Int64")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Remarks"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "RecType"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        dtNewDependencies = New DataTable
        Dim dClm As DataColumn

        dClm = New DataColumn
        dClm.ColumnName = "ParentID"
        dClm.DataType = System.Type.GetType("System.Object")
        dtNewDependencies.Columns.Add(dClm)

        dClm = New DataColumn
        dClm.ColumnName = "DependentID"
        dClm.DataType = System.Type.GetType("System.Object")
        dtNewDependencies.Columns.Add(dClm)
    End Sub

    Private Sub SetupLookupEdits()
        dtVessel = VesselList(DB)
        dtRank = RankList(DB)
        dtWScaleRank = WageRankScaleList(DB)

        lueRank.Properties.DataSource = dtRank
        lueVessel.Properties.DataSource = dtVessel
        lueWScale.Properties.DataSource = dtWScaleRank
    End Sub

    Public Sub SetupSchedulerMapping()
        SchedulerControl1.Storage.EnableReminders = False
        RaiseCustomEvent(Name, New Object() {"SetupLTPControls", "Vessel", Nothing})
        dtDependencies = MPSDB.CreateTable("SELECT * FROM LTP_Dependency WHERE DependentId IS NOT NULL")

        SchedulerControl1.Storage.Appointments.DataSource = dtAppointments
        SchedulerControl1.Storage.Appointments.Mappings.AppointmentId = "Id"
        SchedulerControl1.Storage.Appointments.Mappings.Start = "Start"
        SchedulerControl1.Storage.Appointments.Mappings.End = "End"
        SchedulerControl1.Storage.Appointments.Mappings.Subject = "Subject"
        SchedulerControl1.Storage.Appointments.Mappings.PercentComplete = "Percent"
        SchedulerControl1.Storage.Appointments.Mappings.Label = "Label"
        SchedulerControl1.Storage.Appointments.Mappings.Description = "CrewID"
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("FKeyRank", "FKeyRank"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("FKeyVessel", "FKeyVessel"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("PKey", "PKey"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("CrewID", "CrewID"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("FKeyWScaleRank", "FKeyWScaleRank"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("LOC", "LOC"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("LOCDays", "LOCDays"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("Remarks", "Remarks"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("RecType", "RecType"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("PlanningEvent", "PlanningEvent"))

        SchedulerControl1.Storage.AppointmentDependencies.DataSource = dtDependencies
        SchedulerControl1.Storage.AppointmentDependencies.Mappings.DependentId = "DependentId"
        SchedulerControl1.Storage.AppointmentDependencies.Mappings.ParentId = "ParentId"

        SchedulerControl1.Storage.Resources.Mappings.Id = "PKey"
        SchedulerControl1.Storage.Resources.Mappings.Caption = "Name"
    End Sub

    Private Sub SupplyDataToControls()
        isSupplying = True
        With SchedulerControl1.SelectedAppointments(0)
            txtCrewName.EditValue = .Subject & " - Id: " & .Id
            deStartDate.EditValue = .Start
            deEndDate.EditValue = .End
            lueRank.EditValue = .CustomFields("FKeyRank")
            lueVessel.EditValue = .CustomFields("FKeyVessel")
            lueWScale.EditValue = .CustomFields("FKeyWScaleRank")
            txtLOC.EditValue = computeLOC(.Start, .End, "LOC")
            txtLOCDays.EditValue = computeLOC(.Start, .End, "LOCDays")
            txtRemarks.EditValue = .CustomFields("Remarks")
            txtValidationMsg.Text = ""
            txtValidationMsg2.Text = ""
            If .LabelId <> 3 Then
                isOverlapping(.CustomFields("CrewID"), .Start, .End, .Subject, .CustomFields("PKey"), .Id)
            End If
            If .LabelId = 3 Then
                LayoutControlGroup3.Text = "Onboard Activity Details"
            Else
                LayoutControlGroup3.Text = "Planning Event : " & .CustomFields("PlanningEvent")
            End If
        End With
        isSupplying = False
    End Sub
#End Region

#Region "Enable/Disable Controls"
    Private Sub SchedulerEditMode(ByVal bol As Boolean)
        If bol = True Then
            SchedulerControl1.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.All
            SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.All
            SchedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.All
            SchedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.All

            DisableLTPFields(False)
            AllowAddition(Name, True)
            AllowDeletion(Name, True)
        Else
            SchedulerControl1.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.None
            SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None
            SchedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None
            SchedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.None

            DisableLTPFields(True)
            AllowAddition(Name, False)
            AllowDeletion(Name, False)
            AllowSaving(Name, False)
            EditCheck(Name, False)
            AllowUndoChanges(Name, False)
        End If
    End Sub

    Private Sub DisableLTPFields(ByVal bol As Boolean)
        lueRank.ReadOnly = bol
        lueVessel.ReadOnly = bol
        lueWScale.ReadOnly = bol
        deEndDate.ReadOnly = bol
        deStartDate.ReadOnly = bol
        txtLOC.ReadOnly = bol
        txtLOCDays.ReadOnly = bol
        txtRemarks.ReadOnly = bol
    End Sub
#End Region

    Private Sub ExpandActiveSchedulerView()
        SchedulerControl1.GanttView.ShowMoreButtons = True
        Dim view As SchedulerViewBase = SchedulerControl1.ActiveView
        view.ResourcesPerPage = 7
        Do While view.ViewInfo.MoreButtons.Count > 0
            If view.GetResources.Count = 0 Then Exit Sub
            If view.ResourcesPerPage = 0 Then
                view.ResourcesPerPage = view.Control.Storage.Resources.Count - 1
            Else
                view.ResourcesPerPage -= 1
            End If
        Loop
        SchedulerControl1.GanttView.ShowMoreButtons = False
    End Sub

    Public Overrides Sub setLTPColorScheme(ByVal indx As Integer)
        If indx <> 12 Then
            Dim clr As SchedulerColorSchema = colorSchemeCollection(indx)
            SchedulerControl1.BeginUpdate()
            SchedulerControl1.ResourceColorSchemas.Clear()
            SchedulerControl1.ResourceColorSchemas.Add(clr)
            SchedulerControl1.EndUpdate()
        Else
            SchedulerControl1.ResourceColorSchemas.Clear()
            SchedulerControl1.ResourceColorSchemas.AddRange(colorSchemeCollection)
        End If
    End Sub

    Public Overrides Sub AdjustScaleWidth(ByVal width As Integer)
        SchedulerControl1.GanttView.GetBaseTimeScale().Width = width
    End Sub

    Private Sub ResourcesTree1_AfterFocusNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles ResourcesTree1.AfterFocusNode
        If frmCrewlist.Visible = True And strFilterMode = "Vessel" Then
            frmCrewlist.setFocusRank(e.Node.GetDisplayText("Name"), "RankName")
        End If
    End Sub

    Private Sub SchedulerControl1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SchedulerControl1.MouseDown
        If isEditdable = True Then
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                SchedulerControl1_Click(Nothing, Nothing)
                If SchedulerControl1.SelectedAppointments(0).LabelId = 3 Then
                    'If Form.ModifierKeys = Keys.Control Then
                    '    SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.All
                    '    disableLTPFields(False)
                    'Else
                    SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None
                    disableLTPFields(True)
                    deEndDate.ReadOnly = False
                    txtLOC.ReadOnly = False
                    txtLOCDays.ReadOnly = False
                    'End If
                Else
                    SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.All
                    SchedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.All
                    disableLTPFields(False)
                End If
            Else
                clearDataFields()
            End If
        End If
    End Sub

    Private Sub SchedulerControl1_Click(sender As Object, e As System.EventArgs) Handles SchedulerControl1.Click
        If SchedulerControl1.SelectedAppointments.Count > 0 Then
            Dim apt As Appointment = SchedulerControl1.SelectedAppointments(0)
            SupplyDataToControls()
            SchedulerControl1.ToolTipController.ShowHint(txtLOC.EditValue & " Month/s " & txtLOCDays.EditValue & " Day/s from " & deStartDate.Text & " to " & deEndDate.Text)
            gridComp.DataSource = CheckCrewCompetence(apt.CustomFields("CrewID"), apt.CustomFields("FKeyRank"), apt.CustomFields("FKeyVessel"), txtLOC.EditValue, deStartDate.Text)
        Else
            clearDataFields()
            disableLTPFields(True)
        End If
    End Sub

    Private Sub clearDataFields()
        txtCrewName.EditValue = Nothing
        lueRank.EditValue = Nothing
        lueVessel.EditValue = Nothing
        lueWScale.EditValue = Nothing
        deEndDate.EditValue = Nothing
        deStartDate.EditValue = Nothing
        txtLOC.EditValue = Nothing
        txtLOCDays.EditValue = Nothing
        txtRemarks.EditValue = Nothing
        gridComp.DataSource = Nothing
        txtValidationMsg.Text = ""
    End Sub

    Private Function computeLOC(ByVal sDate As Date, ByVal eDate As Date, ByVal ret As String) As Integer
        Dim nMonths As Integer = 0
        Dim nDays As Integer = 0

        nMonths = DateDiff(DateInterval.Month, sDate, eDate)
        If sDate.Day > eDate.Day Then nMonths = nMonths - 1
        Select Case ret
            Case "LOC"
                Return nMonths
            Case Else
                nDays = ((sDate.Day) - (eDate.Day))
                If nDays < 0 Then nDays = nDays * -1
                Return nDays
        End Select
    End Function

#Region "Validations"

    Private Function CheckCrewCompetence(ByVal crewID As String, crewRank As String, vesselCode As String, loc As String, plannedSignOn As String) As DataTable
        Dim dtRes As New DataTable
        Dim strFKeyComp As String = DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey = '" & vesselCode & "'")
        If strFKeyComp = "" Then
            LayoutControlGroup4.Text = "Vessel has no assigned Qualification template."
            Return Nothing
            Exit Function
        Else
            LayoutControlGroup4.Text = "Vessel Qualification"
            dtRes = DB.CreateTable("SELECT * FROM dbo.CompetenceForPlannedCrew('" & crewID & "','" & crewRank & "','" & strFKeyComp & "'," & loc & ",'" & plannedSignOn & "')")
        End If
        Return dtRes
    End Function

    Private Function isOverlapping(ByVal CrewID As String, ByVal dStartDate As Date, ByVal dEndDate As Date, ByVal CrewName As String, ByVal PKey As String, Optional ByVal id As Object = 0) As Boolean ', ByVal field As String
        Dim res As Boolean = False
        Dim msg As String = ""
        Dim cnt As Integer = 0
        Dim dt As DataTable
        Dim aptDt As DataTable = Nothing
        Try
            If isEditdable = True Then
                If PKey = Nothing Then
                    dt = DB.CreateTable("SELECT PlannedDateSON, PlannedDateDue FROM tblPlanningEventCrew LEFT JOIN tblPlanningEvent ON tblPlanningEvent.PKey = tblPlanningEventCrew.FKeyPlanningEvent WHERE CrewID = '" & CrewID & "' AND (" & ChangeToSQLDate(dStartDate) & "  BETWEEN PlannedDateSON AND PlannedDateDue OR " & ChangeToSQLDate(dEndDate) & " BETWEEN  PlannedDateSON AND PlannedDateDue) ORDER BY PlannedDateDue DESC")
                Else
                    dt = DB.CreateTable("SELECT PlannedDateSON, PlannedDateDue FROM tblPlanningEventCrew LEFT JOIN tblPlanningEvent ON tblPlanningEvent.PKey = tblPlanningEventCrew.FKeyPlanningEvent WHERE CrewID = '" & CrewID & "' AND tblPlanningEventCrew.PKey  <> '" & PKey & "' AND (" & ChangeToSQLDate(dStartDate) & "  BETWEEN PlannedDateSON AND PlannedDateDue OR " & ChangeToSQLDate(dEndDate) & " BETWEEN  PlannedDateSON AND PlannedDateDue) ORDER BY PlannedDateDue DESC")
                End If

                If dt.Rows.Count > cnt Then
                    msg = " - From " & CDate(dt.Rows(0).Item("PlannedDateSON")).ToString("dd-MMM-yyyy") & " To " & CDate(dt.Rows(0).Item("PlannedDateDue")).ToString("dd-MMM-yyyy")
                    res = True
                End If
            End If

            If id = 0 Then
                If TryCast(SchedulerStorage1.Appointments.DataSource, DataTable).Select("CrewID = '" & CrewID & "'", "End DESC").ToArray.Length > 0 Then
                    aptDt = TryCast(SchedulerStorage1.Appointments.DataSource, DataTable).Select("CrewID = '" & CrewID & "'", "End DESC").CopyToDataTable
                End If
            Else
                If TryCast(SchedulerStorage1.Appointments.DataSource, DataTable).Select("CrewID = '" & CrewID & "' AND Id <> " & id, "End DESC").ToArray.Length > 0 Then
                    aptDt = TryCast(SchedulerStorage1.Appointments.DataSource, DataTable).Select("CrewID = '" & CrewID & "' AND Id <> " & id, "End DESC").CopyToDataTable
                End If
            End If

            If Not IsNothing(aptDt) Then
                Dim dEnd As Date = aptDt.Rows(0).Item("End")
                Dim dStart As Date = aptDt.Rows(0).Item("Start")
                If (dEnd > dStartDate) And (dStartDate > dStart) Then
                    msg = " - From " & CDate(aptDt.Rows(0).Item("Start")).ToString("dd-MMM-yyyy") & " To " & CDate(aptDt.Rows(0).Item("End")).ToString("dd-MMM-yyyy")
                    res = True
                End If
            End If

            If res = True Then
                txtValidationMsg.Text = "* An activity overlaps " & msg & " on " & lueVessel.Text & "."
            Else
                txtValidationMsg.Text = ""
            End If
        Catch ex As System.Exception

        End Try
        Return res
    End Function

#End Region

    Private Sub LTPV2_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub
End Class
