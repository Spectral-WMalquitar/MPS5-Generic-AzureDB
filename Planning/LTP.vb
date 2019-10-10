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
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports DevExpress.Services

Public Class LTP
#Region "Declarations"
    Dim dtAppointments As New DataTable
    Dim dtResources As DataTable
    Dim dtDependencies As DataTable
    Dim dtNewDependencies As DataTable
    Dim dtRank As DataTable
    Dim dtWScaleRank As DataTable
    Dim dtFilteredAppointments As DataTable
    Dim dtFilteredResources As DataTable
    Dim dtLTPRankList As DataTable
    Dim customScales As TimeScaleFixedInterval
    Dim mUp As Boolean = True
    Dim mDown As Boolean = False
    Dim dtVessel As New DataTable
    Dim AllowAptResize As Boolean = False
    Dim strSelectedRecord As String = ""
    Dim strSelectedResource As String = ""
    Dim frmCrewlist As New frmLTPCrewlist
    Dim arrNewAndEdited As New ArrayList
    Dim strSelectedId As String = ""
    Dim strResourceId As String = ""
    Dim strCurrentVsl As String = ""
    Dim strCurrentRank As String = ""
    Dim strLastUpdatedBy As String = ""
    Dim strFilterMode As String = ""
    Dim cnt As Integer = 0
    Dim colorSchemeCollection As SchedulerColorSchemaCollection
    Dim clsAudit As New clsAudit
    Dim isSupplying As Boolean = True
    Dim isSaving As Boolean = False
    Dim aptDependencyToRemove As Object
    Dim allowDepDelete As Boolean = False
    Dim showAll As Boolean = False
    Dim copyAptData As Appointment
    Dim isCopying As Boolean = False
    Dim strUseCrewCmpl As String = GetUserSetting("UseCrewCmpl")
    Dim strSortMode As String = ""
    Dim strSortValue As String = ""
    ReadOnly _START As New Date(1900, 1, 1)
    ReadOnly _END As New Date(3000, 12, 31)
    'edited by tony20170717
    'Dim _crewID As String
    Dim _controlMousePoint As Point

    Dim _currentCrewIDs As New List(Of String)

    Dim LastUpdatedBy As String


    Dim _popupDetail As New CrewAppointmentData

    Dim isRightClicked As Boolean = False
    
    Private Const ExcelColumnWidthInch As Double = 8.11
    Private Const ExcelColumnWidthPixel As Double = 48
    'end tony

    'edited by tony20170714
    'Dim _currentCrewIDs As New List(Of String)
    Dim _listOfCrewIDs As New List(Of CrewAppointmentData)

    Dim clsConflict As New clsCrewConflict

    Private Enum LabelID
        Planned = 2
        Onboard = 3
        WithError = 1
        Edited = 5
    End Enum

    Private Class CrewAppointmentData
        Public CrewID As String = ""
        Public LackingResult As String = ""
        Public AppointmentID As Long = -1

        Public Sub New()
            Clear()
        End Sub

        Public Sub Clear()
            CrewID = ""
            LackingResult = ""
            AppointmentID = -1
        End Sub

        Public Sub New(CrewIDValue As String, LackingResultValue As String, AppointmentIDValue As Long)
            CrewID = CrewIDValue
            LackingResult = LackingResultValue
            AppointmentID = AppointmentIDValue
        End Sub

        Public Function IsEqual(CrewIDValue As String, AppointmentIDValue As Long)
            Return CrewID = CrewIDValue And AppointmentID = AppointmentIDValue
        End Function

        Public Function IsEqual(CrewIDValue As String)
            Return CrewID = CrewIDValue
        End Function
    End Class

#End Region

    Private WithEvents popUpMenu As New SchedulerPopupMenu
    Dim frmPopUp As New frmPopUpCrew

    Private WithEvents SelectionForm As frmVesselRankSelection = Nothing
    
    Private Structure AppointmentRightClick
        Public Shared Clicked As Boolean = False
        Public Shared SelectedAppointment As Appointment = Nothing
    End Structure
#Region "Overidables"

    Public Overrides Sub closeFrmCrewList()
        If frmCrewlist.Visible = True Then frmCrewlist.Hide()
    End Sub

    Public Overrides Sub viewCrewComments()
        If SchedulerControl1.SelectedAppointments.Count > 0 Then
            Dim commentDT As New DataTable
            commentDT = DB.CreateTable("SELECT *, '' as Remarks FROM dbo.frmCrew_Comment WHERE FKeyIDNbr = '" & SchedulerControl1.SelectedAppointments(0).CustomFields("CrewID") & "'")
            Dim frm As New frmCrewComments(commentDT, SchedulerControl1.SelectedAppointments(0).CustomFields("CrewID"), SchedulerControl1.SelectedAppointments(0).Subject)
            frm.ShowDialog()
        End If
    End Sub

    Public Overrides Sub undoChanges()
        ShowCustomLoadScreen(GetType(MPS4.Waitform))
        frmPopUp.Hide()
        dtDependencies = MPSDB.CreateTable("SELECT * FROM LTP_Dependency WHERE DependentId IS NOT NULL")
        SchedulerControl1.Storage.AppointmentDependencies.DataSource = dtDependencies
        If strFilterMode = "Vessel" Then
            FilterLTPResource(strCurrentVsl, strFilterMode)
            LTPShowAllRecords(showAll, strFilterMode, strCurrentVsl)
        Else
            FilterLTPResource(strCurrentRank, strFilterMode)
            LTPShowAllRecords(showAll, strFilterMode, strCurrentRank)
        End If
        SortLTPResource(strSortValue, strSortMode)
        arrNewAndEdited.Clear()

        clearDataFields()
        disableLTPFields(True)
        schedulerEditMode(False)

        BRECORDUPDATEDs = False
        CloseCustomLoadScreen()
    End Sub

    Public Overrides Sub DeleteData()
        If SchedulerControl1.SelectedAppointments.Count > 0 Then
            frmPopUp.Hide()
            If SchedulerControl1.SelectedAppointments(0).LabelId <> LabelID.Onboard Then
                Dim msg As String = Environment.NewLine & "Crew: " & SchedulerControl1.SelectedAppointments(0).Subject & Environment.NewLine & "Plan Date: " & SchedulerControl1.SelectedAppointments(0).Start.ToString("dd-MMM-yyyy")
                'edited by tony20171228
                'If MessageBox.Show("Are you sure you want to delete this record?" & msg, GetAppName() & " - LTP", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If MsgBox("Are you sure you want to delete this record?" & msg, MsgBoxStyle.YesNo + MsgBoxStyle.Question, GetAppName() & " - LTP") = MsgBoxResult.Yes Then

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete Record", 0, System.Environment.MachineName, _
                                                             "Crew: " & SchedulerControl1.SelectedAppointments(0).Subject & "Plan Date: " & SchedulerControl1.SelectedAppointments(0).Start.ToString("dd-MMM-yyyy"), _
                                                             "Graphical Planning", SchedulerControl1.SelectedAppointments(0).Description) 'neil
                    clsAudit.saveAuditPreDelDetails("tblPlanningEventCrew", SchedulerControl1.SelectedAppointments(0).CustomFields("PKey"), LastUpdatedBy)

                    '<!--added by tony20180922 : Log Deletion
                    Dim oLogDeletion As New LogDeletion(LogDeletion.CallingApp.Crewing,
                        "Graphical Planning", _
                        "Crewing", _
                        "tblPlanningEventCrew", _
                        "PKey IN ('" & SchedulerControl1.SelectedAppointments(0).CustomFields("PKey") & "')", _
                        "<< Delete Crew Data - Graphical Planning - Crew >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <Graphical Planning - Crew>", _
                        GetUserName())
                    '-->
                    If DB.RunSql("DELETE FROM tblPlanningEventCrew WHERE PKey = '" & SchedulerControl1.SelectedAppointments(0).CustomFields("PKey") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    arrNewAndEdited.Remove(SchedulerControl1.SelectedAppointments(0).Id)

                    'remove dependency
                    If SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count > 0 Then
                        For i As Integer = 0 To SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count - 1
                            Try
                                Dim aptD As AppointmentDependency = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id)(i)
                                Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.ParentId)
                                Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.DependentId)
                                Dim strParent As Object = aptParent.Id
                                Dim strDependent As Object = aptDependent.Id

                                allowDepDelete = True
                                For Each aptDx As AppointmentDependency In SchedulerStorage1.AppointmentDependencies.Items
                                    If aptDx.ParentId = aptParent.Id And aptDx.DependentId = aptDependent.Id Then
                                        SchedulerStorage1.AppointmentDependencies.Remove(aptDx)
                                        Exit For
                                    End If
                                Next

                                Dim strUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "Update", 0, System.Environment.MachineName, "Remove as reliever.", Name, aptDependent.CustomFields("CrewID"))
                                DB.RunSql("UPDATE tblPlanningEventCrew SET ToRelieveID = NULL, LastUpdatedBy = '" & strUpdatedBy & "' WHERE PKey = '" & aptDependent.CustomFields("PKey") & "'")
                                allowDepDelete = False
                            Catch ex As SystemException
                                Continue For
                            End Try
                        Next
                    End If
                    SchedulerControl1.SelectedAppointments(0).Delete()
                    clearDataFields()
                End If
            Else
                'edited by tony20171228
                'MessageBox.Show("Onboard services cannot be deleted." & vbNewLine & _
                '                "Use the [Go Back To Previous] feature instead.", GetAppName() & " - LTP", MessageBoxButtons.OK)
                MsgBox("Onboard services cannot be deleted." & vbNewLine & _
                                "Use the [Go Back To Previous] feature instead.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName() & " - LTP")
                'end tony
            End If

        Else
            MsgBox("No data selected.", MsgBoxStyle.Information, GetAppName() & " - LTP")
        End If
    End Sub

    Public Overrides Sub RefreshData()
        ShowCustomLoadScreen(GetType(MPS4.Waitform))
        MyBase.RefreshData()
        SetExportVisibility(Name, BarItemVisibility.Always)
        InitDatatable()
        setupLookupEdits()
        SetupSchedulerMapping()
        InitControls()
        schedulerEditMode(False)
        SetDeleteCaption(Name, "Delete")
        SetSaveCaption(Name, "Save")
        SetEditCaption(Name, "Edit")
        AllowEditing(Name, True)
        CloseCustomLoadScreen()
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        frmPopUp.Hide()
        Dim sql As String = ""
        Dim sqls As New ArrayList
        Dim strParentId As String = ""
        Dim strDependentId As String = ""
        Dim dtNewPKey As New DataTable
        Dim hasInvalid As Boolean = False
        Dim additionalMsg As String = "There are crews that are not saved :"
        Try
            isSaving = True
            With SchedulerStorage1
                For i As Integer = 0 To arrNewAndEdited.Count - 1
                    If .Appointments.GetAppointmentById(arrNewAndEdited(i)).LabelId <> LabelID.WithError Then
                        ' strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Add Planning.", 0, System.Environment.MachineName, "", Name, .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("CrewID"))
                        strLastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Add Planning.", 0, System.Environment.MachineName, "", "Graphical Planning", .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("CrewID"))

                        If .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("RecType") = "Onb" Then
                            sql = "EXECUTE [dbo].[LTP_INSERT/UPDATE_withExt] " & _
                                  "@CrewID = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("CrewID") & "' " & _
                                  ",@NewDateDue = " & ChangeToSQLDate(.Appointments.GetAppointmentById(arrNewAndEdited(i)).End) & " " & _
                                  ",@DateSON = " & ChangeToSQLDate(.Appointments.GetAppointmentById(arrNewAndEdited(i)).Start) & " " & _
                                  ",@ActID = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("PKey") & "' " & _
                                  ",@LastUpdatedBy = '" & strLastUpdatedBy & "' "
                        Else
                            sql = "EXECUTE [dbo].[LTP_INSERT/UPDATE] " & _
                               "@FKeyVessel  = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("FKeyVessel") & "'" & _
                              ",@PlannedDate = " & ChangeToSQLDate(.Appointments.GetAppointmentById(arrNewAndEdited(i)).Start) & "" & _
                              ",@PKey = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("PKey") & "'" & _
                              ",@CrewID = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("CrewID") & "'" & _
                              ",@FKeyRank = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("FKeyRank") & "'" & _
                              ",@FKeyWScaleRank = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("FKeyWScaleRank") & "'" & _
                              ",@ToRelieveID = NULL" & _
                              ",@LOC = " & computeLOC(.Appointments.GetAppointmentById(arrNewAndEdited(i)).Start, .Appointments.GetAppointmentById(arrNewAndEdited(i)).End, "LOC") & "" & _
                              ",@LOCDays = " & computeLOC(.Appointments.GetAppointmentById(arrNewAndEdited(i)).Start, .Appointments.GetAppointmentById(arrNewAndEdited(i)).End, "LOCDays") & "" & _
                              ",@PlannedDateDue = " & ChangeToSQLDate(.Appointments.GetAppointmentById(arrNewAndEdited(i)).End) & "" & _
                              ",@Remarks = '" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("Remarks") & "'" & _
                              ",@LastUpdatedBy = '" & strLastUpdatedBy & "'"
                        End If

                        dtNewPKey = MPSDB.CreateTable(sql)
                        If dtNewPKey.Rows.Count > 0 Then .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("PKey") = dtNewPKey.Rows(0)(0).ToString
                        If .Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("RecType") = "Onb" Then
                            .Appointments.GetAppointmentById(arrNewAndEdited(i)).LabelId = LabelID.Onboard
                        Else
                            .Appointments.GetAppointmentById(arrNewAndEdited(i)).LabelId = LabelID.Planned
                        End If
                    Else
                        'List invalid appointments
                        hasInvalid = True
                        additionalMsg = additionalMsg & vbNewLine & "     " & .Appointments.GetAppointmentById(arrNewAndEdited(i)).Subject

                        'collect and remove invalid dependencies
                        Dim drs As DataRow() = dtNewDependencies.Select("ParentID='" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).Id & "' OR DependentID='" & .Appointments.GetAppointmentById(arrNewAndEdited(i)).Id & "'")
                        If drs.Count > 0 Then
                            Dim drsDt As DataTable = drs.CopyToDataTable
                            For drCnt As Integer = 0 To drs.Count - 1
                                dtNewDependencies.Rows.Remove(drs(drCnt))
                            Next
                        End If

                    End If
                Next
                arrNewAndEdited.Clear()

                For x As Integer = 0 To dtNewDependencies.Rows.Count - 1
                    sqls.Add("Update tblPlanningEventCrew SET ToRelieveId = '" & .Appointments.GetAppointmentById(dtNewDependencies.Rows(x)("ParentId")).CustomFields("PKey") & "' WHERE PKey = '" & .Appointments.GetAppointmentById(dtNewDependencies.Rows(x)("DependentId")).CustomFields("PKey") & "'")
                Next

                MPSDB.RunSqls(sqls)

                Dim msg As String = "Record/s Saved." &
                                    vbNewLine & vbNewLine &
                                    IIf(hasInvalid, additionalMsg, "")
                MsgBox(msg, IIf(hasInvalid, MsgBoxStyle.Exclamation, MsgBoxStyle.Information), GetAppName)
                dtNewDependencies.Rows.Clear()
                isSaving = False
                BRECORDUPDATEDs = False
                If frmCrewlist.Visible = True Then frmCrewlist.Hide()
            End With
        Catch ex As SystemException
            isSaving = False
            BRECORDUPDATEDs = False
            LogErrors(" SaveData :" & ex.Message)
        End Try
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        frmPopUp.Hide()
        schedulerEditMode(isEditdable)
    End Sub

    Public Overrides Function GetLTPFilterDS(ByVal filter As String) As DataTable
        If filter = "Rank" Then
            Return dtRank
        Else
            Return dtVessel
        End If
    End Function

    Public Overrides Sub FilterLTPResource(ByVal Id As String, ByVal FilterMode As String)
        frmPopUp.Hide()
        strFilterMode = FilterMode
        strUseCrewCmpl = GetUserSetting("UseCrewCmpl")
        Select Case FilterMode
            Case "Vessel"
                strCurrentVsl = Id
                ResourcesTree1.Columns("Name").Caption = "Rank"
                ResourcesTree1.Columns("RankCount").Visible = CType(IIf(strUseCrewCmpl.Equals(""), "False", strUseCrewCmpl), Boolean)
            Case "Rank"
                strCurrentRank = Id
                ResourcesTree1.Columns("Name").Caption = "Vessel"
                ResourcesTree1.Columns("RankCount").Visible = False
        End Select
        SchedulerControl1.Storage.Appointments.Mappings.ResourceId = "ResourceID"

        'refresh relievers
        dtDependencies = MPSDB.CreateTable("SELECT * FROM LTP_Dependency WHERE DependentId IS NOT NULL")
        SchedulerControl1.Storage.AppointmentDependencies.DataSource = dtDependencies

    End Sub

    Public Overrides Sub SortLTPResource(Id As String, SortMode As String)
        strSortMode = SortMode
        strSortValue = Id
        Try

            Dim dtRes As New DataTable
            dtRes = SchedulerControl1.Storage.Resources.DataSource

            dtRes.DefaultView.Sort = Id & " " & SortMode
            dtRes = dtRes.DefaultView.ToTable

            SchedulerControl1.Storage.Resources.DataSource = dtRes
            SchedulerControl1.Storage.RefreshData()

        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub SetupCompetenceForCrewWithIcon(ByVal data As DataTable, ByVal appointment As Appointment)
        If IsNothing(appointment) Then
            Try
                '_currentCrewIDs.Clear()    'commented out by tony20170714
                _listOfCrewIDs.Clear()
                For Each d As DataRow In data.Rows
                    Dim crewId As String = d("CrewID").ToString()
                    Dim crewRank As String = d("FKeyRank").ToString()
                    Dim strFKeyComp As String = DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey = '" & d("FKeyVessel").ToString() & "'")
                    Dim loc As String = computeLOC(Convert.ToDateTime(d("Start").ToString()), Convert.ToDateTime(d("End").ToString()), "LOC").ToString()
                    Dim plannedSon As String = Convert.ToDateTime(d("Start").ToString()).ToString("dd-MMM-yyyy")  'e.ViewInfo.Appointment.Start.ToString("dd-MMM-yyyy")

                    Dim result As DataTable = DB.CreateTable("SELECT dbo.HasLacking_Graphical('" & crewId & "'" & _
                                                                                              ",'" & crewRank & "'" & _
                                                                                              ",'" & strFKeyComp & "'" & _
                                                                                              "," & loc & "," & _
                                                                                              "'" & plannedSon & "','') AS Result ")

                    If result.Rows.Count > 0 Then
                        For Each row As DataRow In result.Rows
                            Dim lackingResult As String = row(0).ToString()
                            'edited by tony20170714
                            '_currentCrewIDs.Add(d("CrewID").ToString() & "-" & lackingResult)
                            _listOfCrewIDs.Add(New CrewAppointmentData(d("CrewID"), lackingResult, d("ID")))
                            'end tony
                        Next
                    End If
                Next
            Catch ex As System.Exception

            End Try
        Else
            'Code to handle the adding of crew appointment details in _currentCrewIDs.
            Dim crewId As String = appointment.CustomFields("CrewID").ToString()
            Dim crewRank As String = appointment.CustomFields("FKeyRank").ToString()
            Dim strFKeyComp As String = DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey = '" & appointment.CustomFields("FKeyVessel").ToString() & "'")
            Dim loc As String = computeLOC(appointment.Start, appointment.End, "LOC")
            Dim plannedSon As String = appointment.Start.ToString("dd-MMM-yyyy")

            Dim result As DataTable = DB.CreateTable("SELECT dbo.HasLacking_Graphical('" & crewId & "'" & _
                                                                                             ",'" & crewRank & "'" & _
                                                                                             ",'" & strFKeyComp & "'" & _
                                                                                             "," & loc & "," & _
                                                                                             "'" & plannedSon & "','') AS Result ")
            If result.Rows.Count > 0 Then

                For Each row As DataRow In result.Rows
                    Dim lackingResult As String = row(0).ToString()
                    'edited by tony20170714
                    '_currentCrewIDs.Add(crewId & "-" & lackingResult)
                    _listOfCrewIDs.Add(New CrewAppointmentData(crewId, lackingResult, CLng(IfNull(appointment.Id, 0))))
                    'end tony
                Next
            End If
        End If

    End Sub

    Public Overrides Sub setLTPColorScheme(ByVal indx As Integer)
        If indx <> 12 Then
            Dim clr As SchedulerColorSchema = colorSchemeCollection(indx)
            SchedulerControl1.BeginUpdate()
            SchedulerControl1.ResourceColorSchemas.Clear()
            SchedulerControl1.ResourceColorSchemas.Add(clr)
            SchedulerControl1.EndUpdate()
        Else
            SchedulerControl1.BeginUpdate()
            SchedulerControl1.ResourceColorSchemas.Clear()
            SchedulerControl1.ResourceColorSchemas.AddRange(colorSchemeCollection)
            SchedulerControl1.EndUpdate()
        End If

        SaveUserSetting(UserSettingCode.LTP.ColorScheme, indx)
    End Sub

    Private Sub InitializeSelectionForm(FilterMode As String)
        If SelectionForm Is Nothing Then
            'SelectionForm = New frmVesselRankSelection(IIf(FilterMode = "Vessel", frmVesselRankSelection.SelectionMode.Rank, IIf(FilterMode = "Rank", frmVesselRankSelection.SelectionMode.Vessel, frmVesselRankSelection.SelectionMode.None)), _
            '                                           IIf(FilterMode = "Vessel", LTPDisplayMode, IIf(FilterMode = "Rank", frmVesselRankSelection.SelectionMode.Vessel, frmVesselRankSelection.SelectionMode.None)))
            SelectionForm = New frmVesselRankSelection(IIf(FilterMode = "Vessel", frmVesselRankSelection.SelectionMode.Rank, IIf(FilterMode = "Rank", frmVesselRankSelection.SelectionMode.Vessel, frmVesselRankSelection.SelectionMode.None)))
            'SelectionForm.RefreshForm()
            'SelectionForm = New frmVesselRankSelection

        Else
            SelectionForm.CurrentSelection = IIf(FilterMode = "Vessel", frmVesselRankSelection.SelectionMode.Rank, IIf(FilterMode = "Rank", frmVesselRankSelection.SelectionMode.Vessel, frmVesselRankSelection.SelectionMode.None))
            'SelectionForm.RefreshForm()
            If SelectionForm.CurrentSelectionChanged Then SelectionForm.RefreshForm()
        End If

        'SelectionForm.CurrentSelection = IIf(FilterMode = "Vessel", frmVesselRankSelection.SelectionMode.Rank, IIf(FilterMode = "Rank", frmVesselRankSelection.SelectionMode.Vessel, frmVesselRankSelection.SelectionMode.None))
        'SelectionForm.RefreshForm()
    End Sub

    Public Overrides Sub LTPShowAllRecords(ByVal show As Boolean, ByVal FilterMode As String, ByVal FilterId As String)
        'this procedure is modified by tony20171215 - make use of the filter (vessel/rank) form
        Dim cFilterString As String = GetUserVslFilterString(, "[FKeyVessel]")
        Dim qry As String

        InitializeSelectionForm(FilterMode)

        Select Case FilterMode
            Case "Vessel"
                If SelectionForm.DisplayMode = LTPDisplayMode.AllWithDataOnly Then
                    'SHOW ALL WITH DATA ONLY
                    If strUseCrewCmpl = "True" Then
                        qry = "SELECT TOP (100) PERCENT ltp.Id, ltp.Start, ltp.[End], ltp.Label, ltp.Location, ltp.FKeyRank, ltp.RankName, ltp.RankSort, ltp.Subject, ltp.[Percent], ltp.FKeyVessel, ltp.PKey, " & _
                                                           "ltp.CrewToRelieve, ltp.CrewID, ltp.FKeyWScaleRank, ltp.LOC, ltp.LOCDays, ltp.Remarks, ltp.RecType, ltp.PlanningEvent, ltp.CompID, ltp.DOB, ltp.Religion, ltp.AgentName, " & _
                                                           "ltp.PhotoPath, adm.Name, adm.Abbrv, adm.SortCode AS AdmSort, adm.PKey AS AdmPKey, CASE WHEN RankCount IS NULL THEN 0 ELSE RankCount END AS RankCount " & _
                                                           "FROM [dbo].[LTP_Datasource] AS ltp " & _
                                                           "INNER JOIN tblAdmRank AS adm ON ltp.FKeyRank = adm.PKey LEFT OUTER JOIN dbo.LTP_RankList rl on ltp.FKeyRank = rl.PKey " & _
                                                           "WHERE FKeyVessel = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " " & _
                                                           "GROUP BY ltp.Id, ltp.Start, ltp.[End], ltp.Label, ltp.Location, ltp.FKeyRank, ltp.RankName, ltp.RankSort, ltp.Subject, ltp.[Percent], ltp.FKeyVessel, ltp.PKey, ltp.CrewToRelieve, ltp.CrewID, " & _
                                                           "ltp.FKeyWScaleRank, ltp.LOC, ltp.LOCDays, ltp.Remarks, ltp.RecType, ltp.PlanningEvent, ltp.CompID, ltp.DOB, ltp.Religion, ltp.AgentName, ltp.PhotoPath, adm.Name, adm.Abbrv, adm.SortCode, " & _
                                                           "CASE WHEN RankCount IS NULL THEN 0 ELSE RankCount END " & _
                                                           "ORDER BY adm.SortCode"
                        dtAppointments = MPSDB.CreateTable(qry)
                    Else
                        dtAppointments = MPSDB.CreateTable("SELECT ltp.*, adm.Name, adm.Abbrv, adm.SortCode AS AdmSort, adm.PKey AS AdmPKey, 0 AS RankCount FROM [dbo].[LTP_Datasource] AS ltp INNER JOIN tblAdmRank AS adm ON ltp.FKeyRank = adm.PKey WHERE FKeyVessel = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY adm.SortCode")
                    End If

                ElseIf SelectionForm.DisplayMode = LTPDisplayMode.All Then
                    'SHOW ALL 

                    If strUseCrewCmpl = "True" Then
                        qry = "SELECT TOP (100) PERCENT ltp.Id, ltp.Start, ltp.[End], ltp.Label, ltp.Location, ltp.FKeyRank, ltp.RankName, ltp.RankSort, ltp.Subject, ltp.[Percent], ltp.FKeyVessel, ltp.PKey, " & _
                                                           "ltp.CrewToRelieve, ltp.CrewID, ltp.FKeyWScaleRank, ltp.LOC, ltp.LOCDays, ltp.Remarks, ltp.RecType, ltp.PlanningEvent, ltp.CompID, ltp.DOB, ltp.Religion, ltp.AgentName, " & _
                                                           "ltp.PhotoPath, adm.Name, adm.Abbrv, adm.SortCode AS AdmSort, adm.PKey AS AdmPKey, CASE WHEN RankCount IS NULL THEN 0 ELSE RankCount END AS RankCount " & _
                                                           "FROM (SELECT * FROM [dbo].[LTP_Datasource] WHERE FKeyVessel = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & ") AS ltp " & _
                                                           "RIGHT OUTER JOIN tblAdmRank AS adm ON ltp.FKeyRank = adm.PKey LEFT OUTER JOIN dbo.LTP_RankList rl on ltp.FKeyRank = rl.PKey " & _
                                                           "GROUP BY ltp.Id, ltp.Start, ltp.[End], ltp.Label, ltp.Location, ltp.FKeyRank, ltp.RankName, ltp.RankSort, ltp.Subject, ltp.[Percent], ltp.FKeyVessel, ltp.PKey, ltp.CrewToRelieve, ltp.CrewID, " & _
                                                           "ltp.FKeyWScaleRank, ltp.LOC, ltp.LOCDays, ltp.Remarks, ltp.RecType, ltp.PlanningEvent, ltp.CompID, ltp.DOB, ltp.Religion, ltp.AgentName, ltp.PhotoPath, adm.Name, adm.Abbrv, adm.SortCode, " & _
                                                           "CASE WHEN RankCount IS NULL THEN 0 ELSE RankCount END " & _
                                                           "ORDER BY adm.SortCode"

                        '"WHERE FKeyVessel = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " " & _
                        dtAppointments = MPSDB.CreateTable(qry)
                    Else
                        dtAppointments = MPSDB.CreateTable("SELECT adm.Name, adm.Abbrv, adm.SortCode as AdmSort, adm.PKey AS AdmPKey, 0 AS RankCount, ltp.* " & _
                                                           "FROM tblAdmRank AS adm LEFT OUTER JOIN " & _
                                                           "(SELECT * FROM LTP_Datasource WHERE FKeyVessel = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & ") AS ltp ON adm.PKey = ltp.FKeyRank " & _
                                                           "ORDER BY adm.SortCode")
                    End If

                ElseIf SelectionForm.DisplayMode = LTPDisplayMode.Selected Then
                    'SHOW SELECTED

                    'Dim condition As String = LTPGetVesselRankSelectionCriteria("RANK") 'Main Selection is Vessel. So the sub selection is RANK.
                    If strUseCrewCmpl = "True" Then
                        Dim condition As String = SelectionForm.Condition()
                        
                        qry = "SELECT TOP (100) PERCENT ltp.Id, ltp.Start, ltp.[End], ltp.Label, ltp.Location, ltp.FKeyRank, ltp.RankName, ltp.RankSort, ltp.Subject, ltp.[Percent], ltp.FKeyVessel, ltp.PKey, " & _
                                                          "ltp.CrewToRelieve, ltp.CrewID, ltp.FKeyWScaleRank, ltp.LOC, ltp.LOCDays, ltp.Remarks, ltp.RecType, ltp.PlanningEvent, ltp.CompID, ltp.DOB, ltp.Religion, ltp.AgentName, " & _
                                                          "ltp.PhotoPath, adm.Name, adm.Abbrv, adm.SortCode AS AdmSort, adm.PKey AS AdmPKey, CASE WHEN RankCount IS NULL THEN 0 ELSE RankCount END AS RankCount " & _
                                                          "FROM (SELECT * FROM [dbo].[LTP_Datasource] WHERE FKeyVessel = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & ") AS ltp " & _
                                                          "RIGHT OUTER JOIN tblAdmRank AS adm ON ltp.FKeyRank = adm.PKey LEFT OUTER JOIN dbo.LTP_RankList rl on ltp.FKeyRank = rl.PKey " & _
                                                          IIf(condition.Length > 0, "WHERE " & condition, "") & " " & _
                                                          "GROUP BY ltp.Id, ltp.Start, ltp.[End], ltp.Label, ltp.Location, ltp.FKeyRank, ltp.RankName, ltp.RankSort, ltp.Subject, ltp.[Percent], ltp.FKeyVessel, ltp.PKey, ltp.CrewToRelieve, ltp.CrewID, " & _
                                                          "ltp.FKeyWScaleRank, ltp.LOC, ltp.LOCDays, ltp.Remarks, ltp.RecType, ltp.PlanningEvent, ltp.CompID, ltp.DOB, ltp.Religion, ltp.AgentName, ltp.PhotoPath, adm.Name, adm.Abbrv, adm.SortCode, adm.pkey, " & _
                                                          "CASE WHEN RankCount IS NULL THEN 0 ELSE RankCount END " & _
                                                          "ORDER BY adm.SortCode"


                        dtAppointments = MPSDB.CreateTable(qry)
                    Else

                        Dim condition As String = SelectionForm.Condition

                        dtAppointments = MPSDB.CreateTable("SELECT adm.Name, adm.Abbrv, adm.SortCode as AdmSort, adm.PKey AS AdmPKey, 0 AS RankCount, ltp.* " & _
                                                           "FROM tblAdmRank AS adm LEFT OUTER JOIN " & _
                                                           "(SELECT * FROM LTP_Datasource WHERE FKeyVessel = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & ") AS ltp ON adm.PKey = ltp.FKeyRank " & _
                                                           IIf(condition.Length > 0, "WHERE " & condition, "") & " " & _
                                                           "ORDER BY adm.SortCode")
                    End If

                End If
            Case "Rank"

                If SelectionForm.DisplayMode = LTPDisplayMode.All Then
                    'SHOW ALL

                    cFilterString = GetUserVslFilterString(, "adm.PKey")
                    dtAppointments = MPSDB.CreateTable("SELECT adm.Name, adm.Abbrv, adm.SortCode as AdmSort, adm.PKey AS AdmPKey, ltp.*, 0 AS RankCount " &
                                                       "FROM tblAdmVsl AS adm LEFT OUTER JOIN (SELECT * FROM [dbo].[LTP_Datasource] WHERE FKeyRank = '" & FilterId & "') AS ltp ON adm.PKey = ltp.FKeyVessel WHERE VslStat = 1 " & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY adm.SortCode")
                ElseIf SelectionForm.DisplayMode = LTPDisplayMode.AllWithDataOnly Then
                    'SHOW ALL WITH DATA ONLY

                    dtAppointments = MPSDB.CreateTable("SELECT ltp.*, adm.Name, adm.Abbrv, adm.SortCode as AdmSort, adm.PKey AS AdmPKey, 0 AS RankCount FROM [dbo].[LTP_Datasource] AS ltp INNER JOIN tblAdmVsl AS adm ON ltp.FKeyVessel = adm.PKey WHERE FKeyRank = '" & FilterId & "'" & IIf(cFilterString.Length > 0, " AND " & cFilterString, "") & " ORDER BY adm.SortCode")

                ElseIf SelectionForm.DisplayMode = LTPDisplayMode.Selected Then
                    'SHOW ALL SELECTED

                    Dim condition As String = SelectionForm.Condition("adm.PKey")
                    Dim currentFilter As String = cFilterString
                    cFilterString = GetUserVslFilterString(, "adm.PKey")
                    currentFilter = currentFilter & _
                                IIf(IfNull(currentFilter, "").Length > 0, " AND ", "") & _
                                condition

                    dtAppointments = MPSDB.CreateTable("SELECT adm.Name, adm.Abbrv, adm.SortCode as AdmSort, adm.PKey AS AdmPKey, ltp.*, 0 AS RankCount " &
                                                       "FROM tblAdmVsl AS adm LEFT OUTER JOIN (SELECT * FROM [dbo].[LTP_Datasource] WHERE FKeyRank = '" & FilterId & "') AS ltp ON adm.PKey = ltp.FKeyVessel WHERE VslStat = 1 " & IIf(currentFilter.Length > 0, " AND " & currentFilter, "") & " ORDER BY adm.SortCode")
                End If

        End Select

        If dtAppointments.Rows.Count > 0 Then
            Dim dtRes As New DataTable
            dtAppointments = ConstructResourceDT(dtAppointments)
            dtRes = dtAppointments.Copy
            dtRes = dtRes.DefaultView.ToTable(True, {"ResourceID", "Name", "Abbrv", "AdmSort", "DateSOn", "DateDue", "AdmPKey", "RankCount"})

            SchedulerControl1.Storage.Appointments.DataSource = dtAppointments
            SchedulerControl1.Storage.Resources.DataSource = dtRes
            SetupCompetenceForCrewWithIcon(dtAppointments, Nothing)
            If dtAppointments.Rows.Count > 0 Then
                Dim sDate As Date = DateAdd(DateInterval.Month, -3, Today.Date)
                SchedulerControl1.Start = sDate
                SchedulerControl1.OptionsRangeControl.MaxSelectedIntervalCount = 7
            End If

            If ResourcesTree1.Nodes.Count > 0 Then ResourcesTree1.FocusedNode = ResourcesTree1.Nodes(0)
        Else
            SchedulerControl1.Storage.Appointments.DataSource = Nothing
            SchedulerControl1.Storage.Resources.DataSource = Nothing
        End If

        showAll = show
        ExpandActiveSchedulerView()

        SaveUserSetting(UserSettingCode.LTP.ShowEmptyVesselRank, show)
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
#End Region

#Region "LTP Control Functions"
    Public Overrides Sub AdjustScaleWidth(ByVal width As Integer)
        SchedulerControl1.GanttView.GetBaseTimeScale().Width = width
        SaveUserSetting(UserSettingCode.LTP.Scale, width)
    End Sub
#End Region

#Region "Init"
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

        clm = New DataColumn
        clm.ColumnName = "CompID"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "DOB"
        clm.DataType = System.Type.GetType("System.DateTime")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "Religion"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "AgentName"
        clm.DataType = System.Type.GetType("System.String")
        dtAppointments.Columns.Add(clm)

        clm = New DataColumn
        clm.ColumnName = "PhotoPath"
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

    Public Sub SetupSchedulerMapping()
        SchedulerControl1.Storage.EnableReminders = False
        colorSchemeCollection = SchedulerControl1.GetResourceColorSchemasCopy()
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
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("CompID", "CompID"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("DOB", "DOB"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("Religion", "Religion"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("AgentName", "AgentName"))
        SchedulerControl1.Storage.Appointments.CustomFieldMappings.Add(New AppointmentCustomFieldMapping("PhotoPath", "PhotoPath"))

        SchedulerControl1.Storage.AppointmentDependencies.DataSource = dtDependencies
        SchedulerControl1.Storage.AppointmentDependencies.Mappings.DependentId = "DependentId"
        SchedulerControl1.Storage.AppointmentDependencies.Mappings.ParentId = "ParentId"

        SchedulerControl1.Storage.Resources.Mappings.Id = "ResourceID"
        SchedulerControl1.Storage.Resources.Mappings.Caption = "Abbrv"
    End Sub

    Private Sub setupLookupEdits()
        dtVessel = VesselList(DB) 'createFilteredData("SELECT PKey as VslCode, Name as VslName, FKeyPrincipal, FKeyFlt FROM [tblAdmVsl] WHERE [VslStat] = 1", FilteredDataObjectType.SQL, "VslName", , , "FKeyPrincipal", "FKeyFlt")
        'dtVessel.Columns(0).ColumnName = "PKey"
        'dtVessel.Columns(1).ColumnName = "Name"
        dtRank = RankList(DB) 'MPSDB.CreateTable("SELECT DISTINCT ar.Abbrv as [Name], ar.PKey, ar.SortCode FROM tblAdmRank ar ORDER BY ar.SortCode") 'ar RIGHT JOIN LTP_Datasource ltp ON ltp.ResourceId = ar.PKey  ORDER BY Abbrv") 'RIGHT JOIN PlannedCrewDetails pcd ON pcd.FKeyRank = ar.PKey
        dtWScaleRank = WageRankScaleList(DB) 'MPSDB.CreateTable("SELECT WageScale as Name , WScaleRankCode as PKey, LOC, LOCDays FROM WAGESCALE WHERE Active = 1 ORDER BY WageScale")
    End Sub

    Private Sub InitControls()
        SchedulerControl1.LimitInterval = New TimeInterval(_START, _END)
        ResourcesTree1.Columns("RankCount").Visible = CType(IIf(strUseCrewCmpl.Equals(""), "False", strUseCrewCmpl), Boolean)

        With frmPopUp
            compGrid_H = .CompetenceDocsGrid.Height

            AddHandler .FormClosing, AddressOf frmPopUpCrew_FormClosing
            AddHandler .Resize, AddressOf frmPopUpCrew_Resize
            AddHandler .locMain.GroupExpandChanged, AddressOf locMain_GroupExpandChanged

            .CompGridGroup.Expanded = False
            .lueRank.Properties.DataSource = dtRank
            .lueVessel.Properties.DataSource = dtVessel
            .lueWScale.Properties.DataSource = dtWScaleRank


            .Hide()
        End With


        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil

        'added by tony20180108
        Dim oldMouseHandler As IMouseHandlerService = CType(SchedulerControl1.GetService(GetType(IMouseHandlerService)), IMouseHandlerService)
        If Not oldMouseHandler Is Nothing Then
            Dim newMouseHandler As MyMouseHandlerService = _
                New MyMouseHandlerService(SchedulerControl1, oldMouseHandler)
            SchedulerControl1.RemoveService(GetType(IMouseHandlerService))
            SchedulerControl1.AddService(GetType(IMouseHandlerService), newMouseHandler)
        End If

    End Sub
#End Region

#Region "Data Structure for Exporting Graphical Planning"
    Public Structure GraphicalData
        Public Id As Integer
        Public PKey As String
        Public StartDate As Date
        Public EndDate As Date
        Public Location As String
        Public FKeyRank As String
        Public Subject As String
        Public Percent As String
        Public FKeyVesel As String
        Public FKeyWScaleRank As String
        Public LOC As Integer
        Public LocDays As Integer
        Public CrewID As String
        Public Remarks As String
        Public RecType As String
        Public PlanningEvent As String
        Public ResourceID As String
    End Structure

    Private listOfGraphicalData As New HashSet(Of GraphicalData)
#End Region

#Region "LTP Events"
    Private Sub ResourcesTree1_AfterFocusNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles ResourcesTree1.AfterFocusNode
        If frmCrewlist.Visible = True And strFilterMode = "Vessel" Then
            frmCrewlist.setFocusRank(ResourcesTree1.FocusedNode.GetValue("Abbrv"), "RankName")
        End If
    End Sub

    Private Sub SchedulerControl1_AllowAppointmentEvent(sender As Object, e As DevExpress.XtraScheduler.AppointmentOperationEventArgs) Handles SchedulerControl1.AllowAppointmentDrag, SchedulerControl1.AllowAppointmentResize
        If e.Appointment.LabelId = LabelID.Onboard Then 'ONBOARD
            e.Allow = False
        Else
            e.Allow = True
        End If
    End Sub

    Private Sub SchedulerControl1_InitAppointmentImages(sender As Object, e As DevExpress.XtraScheduler.AppointmentImagesEventArgs) Handles SchedulerControl1.InitAppointmentImages

        Dim info As AppointmentImageInfo = New AppointmentImageInfo()
        Dim index As Integer = -1
        'Dim bm As Bitmap = Image.FromFile("C:\Users\DeveloperOne\Pictures\icons\lacking.png")

        Dim crewId As String = e.Appointment.CustomFields("CrewID")

        Try

            If _listOfCrewIDs.Count > 0 Then

                For Each row In _listOfCrewIDs
                    If row.IsEqual(crewId.ToString, CLng(IfNull(e.Appointment.Id, -1))) Then ' If crewId.Equals(row.CrewID) And CLng(IfNull(e.Appointment.Id, -1)).Equals(CLng(IfNull(row.AppointmentID, -1))) Then
                        Dim lackingResult As String = row.LackingResult
                        If lackingResult.Equals("1") Then       'Lacking (x)
                            index = 0
                        ElseIf lackingResult.Equals("2") Then   'Has document but will expire within the contract (/!\)
                            index = 1
                        ElseIf lackingResult.Equals("3") Then   'Has document but will expire within contract (optional) (!)
                            index = 2
                        End If
                    End If
                Next
            End If
        Catch ex As System.Exception
            index = -1
        End Try

        If index <> -1 Then
            Dim bm As Bitmap = ImageCollection.Images(index)
            info.Image = bm
            e.ImageInfoList.Add(info)
        End If

    End Sub

    Private Sub SchedulerControl1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SchedulerControl1.MouseDown

        Debug.Print(Format(DateTime.Now, "hh:mm:ss") & " - Mouse Down")

        Dim pos As New Point(e.X, e.Y)
        Dim viewInfo As SchedulerViewInfoBase = SchedulerControl1.ActiveView.ViewInfo
        Dim hitInfo As SchedulerHitInfo = viewInfo.CalcHitInfo(pos, False)

        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Checks if right clicked. focuses on selected time cell if right clicked and calls necessary click event
        If e.Button = Windows.Forms.MouseButtons.Right Then
            isRightClicked = True
            frmPopUp.Hide()
            SchedulerControl1.ActiveView.SetSelection(hitInfo.ViewInfo.Interval, hitInfo.ViewInfo.Resource)
            SchedulerControlClicked()
        End If

        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Checks if clicked item is an Appointment. Sets necessary AppointmentRightClick fields
        If hitInfo.HitTest = SchedulerHitTest.AppointmentContent Then
            AppointmentRightClick.Clicked = True
            Try
                AppointmentRightClick.SelectedAppointment = CType(hitInfo.ViewInfo, AppointmentViewInfo).Appointment
            Catch
                AppointmentRightClick.SelectedAppointment = Nothing
            End Try
        Else
            AppointmentRightClick.Clicked = False
            AppointmentRightClick.SelectedAppointment = Nothing
            SchedulerControl1.SelectedAppointments.Clear()
        End If

        '------------------------------------------------------------------------------------------------------------------------------------------------------
        'Checks if clicked item is an Appointment. Sets necessary AppointmentRightClick fields
        If isEditdable = True Then
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                SchedulerControl1_Click(Nothing, Nothing)
                If SchedulerControl1.SelectedAppointments(0).LabelId = LabelID.Onboard Then

                    SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None
                    SchedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.None
                    'disableLTPFields(True)
                Else
                    SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.Custom
                    SchedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.Custom
                    'disableLTPFields(False)
                End If
            Else
                clearDataFields()
            End If
        End If

    End Sub

    Private Sub SchedulerControl1_DoubleClick(sender As Object, e As System.EventArgs) Handles SchedulerControl1.DoubleClick
        ShowCrewList()
    End Sub

    Private Sub DoShowCrewList()
        SchedulerControl1.Focus()
        SchedulerControlClicked()       'Clicks on selected resource
        ShowCrewList()                  'Shows Crew List popup form
        FilterCrewListBySelectedRank()  'Filter Crew List with selected rank from selected resource
    End Sub

#Region "Crew List Popup Form"
    Private Sub ShowCrewList()
        If isEditdable And strFilterMode <> "" Then
            If frmCrewlist.Visible = False Then
                frmCrewlist.Show()
            Else
                frmCrewlist.WindowState = FormWindowState.Normal
            End If
            Try
                If strFilterMode = "Vessel" Then
                    frmCrewlist.setFocusRank(ResourcesTree1.FocusedNode.GetValue("Abbrv"), "RankName")
                Else
                    Dim strRankName As String = DB.DLookUp("Abbrv", "tblAdmRank", "", "PKey = '" & strCurrentRank & "'")
                    frmCrewlist.setFocusRank(strRankName, "RankName")
                End If
            Catch ex As NullReferenceException
                Exit Try
            Catch ex As SystemException
                LogErrors(" SchedulerControl1_DoubleClick: " & ex.Message)
                'MsgBox("MPS5 Error:" & ex.Message)
            End Try
        End If
    End Sub

    Private Sub HideCrewList()
        Try
            frmCrewlist.Hide()
        Catch
        End Try
    End Sub

    Private Sub SchedulerControlClicked()
        If SchedulerControl1.SelectedAppointments.Count > 0 Then
            strResourceId = SchedulerControl1.SelectedResource.Id 'Debug.Print(SchedulerControl1.SelectedResource.Id)
            Dim apt As Appointment = SchedulerControl1.SelectedAppointments(0)
            If strFilterMode = "Vessel" Then
                strCurrentRank = apt.CustomFields("FKeyRank")
            Else
                strCurrentVsl = apt.CustomFields("FKeyVessel")
            End If
            If SchedulerControl1.SelectedAppointments(0).Subject <> frmPopUp.txtCrewName.Text Then
                clearDataFields()
                frmPopUp.Hide()
            End If
        Else
            clearDataFields()
            frmPopUp.Hide()
        End If

        FilterCrewListBySelectedRank()
    End Sub

    Private Sub FilterCrewListBySelectedRank()
        If frmCrewlist.Visible = True And strFilterMode = "Vessel" And Not isRightClicked Then
            frmCrewlist.setFocusRank(SchedulerControl1.SelectedResource.Caption, "RankName")
        End If
    End Sub
#End Region

    Private Sub SchedulerControl1_AppointmentDrag(sender As Object, e As DevExpress.XtraScheduler.AppointmentDragEventArgs) Handles SchedulerControl1.AppointmentDrag
        Dim visibleIntCol As TimeIntervalCollection = SchedulerControl1.ActiveView.GetVisibleIntervals()
        SchedulerControl1.LimitInterval = New TimeInterval(visibleIntCol.Start, visibleIntCol.End)
    End Sub

    Private Sub SchedulerControl1_AppointmentResizing(sender As Object, e As DevExpress.XtraScheduler.AppointmentResizeEventArgs) Handles SchedulerControl1.AppointmentResizing
        Try
            If e.EditedAppointment.LabelId = LabelID.Onboard And e.ResizedSide <> ResizedSide.AtEndTime Then
                e.Handled = False
                e.Allow = False
                Exit Sub
            End If
            If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
                Dim mousePosition As Point = SchedulerControl1.PointToClient(Form.MousePosition)
                Dim shi As DevExpress.XtraScheduler.Drawing.SchedulerHitInfo = SchedulerControl1.ActiveView.ViewInfo.CalcHitInfo(mousePosition, True)
                Dim borderPos As Integer = If(e.ResizedSide = ResizedSide.AtStartTime, shi.ViewInfo.Bounds.X, shi.ViewInfo.Bounds.X + shi.ViewInfo.Bounds.Width)
                If Math.Abs(mousePosition.X - borderPos) > 1 Then
                    Dim perc As Double = CDbl(mousePosition.X - shi.ViewInfo.Bounds.X) / CDbl(shi.ViewInfo.Bounds.Width)
                    Dim timetoAdd As TimeSpan = TimeSpan.FromDays(e.HitInterval.Duration.TotalDays * perc)
                    If e.ResizedSide = ResizedSide.AtStartTime Then
                        e.EditedAppointment.Start = e.HitInterval.Start.AddDays(timetoAdd.Days)
                        e.EditedAppointment.[End] = e.SourceAppointment.[End]
                        frmPopUp.deStartDate.EditValue = e.EditedAppointment.Start
                        SchedulerControl1.ToolTipController.ShowHint(e.EditedAppointment.Start.ToString("dd-MMM-yyyy"), DevExpress.Utils.ToolTipLocation.RightBottom)
                    Else
                        e.EditedAppointment.Start = e.SourceAppointment.Start
                        e.EditedAppointment.[End] = e.HitInterval.Start.AddDays(timetoAdd.Days)
                        frmPopUp.deEndDate.EditValue = e.EditedAppointment.End
                        SchedulerControl1.ToolTipController.ShowHint(e.EditedAppointment.[End].ToString("dd-MMM-yyyy"), DevExpress.Utils.ToolTipLocation.RightBottom)
                    End If
                    e.Handled = True
                End If
            End If
        Catch ex As System.Exception
            'MsgBox("MPS5 Error:" & ex.Message)
        End Try
    End Sub

    Private Sub SchedulerControl1_AppointmentResized(sender As Object, e As AppointmentResizeEventArgs) Handles SchedulerControl1.AppointmentResized
        Try

            '//// Neil 20170814 crew conflict feature
            Dim dtres As New DataTable
            Dim apt As Appointment = e.EditedAppointment
            'dtres = clsConflict.CrewConflict_GetCrewWithConflict(apt.Description, dtAppointments, "CrewID", MPSDB.GetConnectionString)
            dtres = clsConflict.CrewConflict_GetCrewWithConflict(apt.Description, dtAppointments, "CrewID", "Start", "End", apt.Start, apt.End, MPSDB.GetConnectionString)

            If dtres.Rows.Count > 0 Then
                If MsgBox("Crew " & apt.Subject & " is conflict with crew " & dtres.Rows(0)("CConflictName") & ", do you want to continue?", vbExclamation + vbYesNo) = vbNo Then
                    e.Allow = False
                    e.Handled = True
                    Exit Sub
                End If
            End If
            '///////////

            If mUp = True Then
                If e.EditedAppointment.LabelId = LabelID.Onboard And e.ResizedSide <> ResizedSide.AtEndTime Then
                    e.Handled = False
                    e.Allow = False
                    Exit Sub
                End If

                Dim NewEndDate As Date
                Dim mousePosition As Point = SchedulerControl1.PointToClient(Form.MousePosition)
                Dim shi As DevExpress.XtraScheduler.Drawing.SchedulerHitInfo = SchedulerControl1.ActiveView.ViewInfo.CalcHitInfo(mousePosition, True)
                Dim borderPos As Integer = If(e.ResizedSide = ResizedSide.AtStartTime, shi.ViewInfo.Bounds.X, shi.ViewInfo.Bounds.X + shi.ViewInfo.Bounds.Width)
                Dim sql As String = ""
                If Math.Abs(mousePosition.X - borderPos) > 1 Then
                    Dim perc As Double = CDbl(mousePosition.X - shi.ViewInfo.Bounds.X) / CDbl(shi.ViewInfo.Bounds.Width)
                    Dim timetoAdd As TimeSpan = TimeSpan.FromDays(e.HitInterval.Duration.TotalDays * perc)

                    If e.ResizedSide = ResizedSide.AtStartTime Then
                        'isParentEndDateOverlapsWithDependentStartDate()
                        e.EditedAppointment.Start = e.HitInterval.Start.AddDays(timetoAdd.Days)
                        e.EditedAppointment.[End] = e.SourceAppointment.[End]
                    Else
                        NewEndDate = e.HitInterval.Start.AddDays(timetoAdd.Days)
                        e.EditedAppointment.Start = e.SourceAppointment.Start
                        e.EditedAppointment.[End] = NewEndDate
                        frmPopUp.deEndDate.EditValue = NewEndDate
                    End If

                    e.Handled = True
                    SchedulerControl1.ToolTipController.HideHint()
                End If
                mUp = False
            End If
        Catch ex As System.Exception
            'MsgBox("MPS5 Error:" & ex.Message)
        End Try
    End Sub

    Private Sub SchedulerControl1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SchedulerControl1.MouseUp
        mUp = True
    End Sub

    Private Sub schedulerControl1_MoreButtonClicked(sender As Object, e As DevExpress.XtraScheduler.MoreButtonClickedEventArgs) Handles SchedulerControl1.MoreButtonClicked
        ExpandActiveSchedulerView()
        e.Handled = True
    End Sub

    Private Sub SchedulerStorage1_AppointmentDependencyDeleting(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectCancelEventArgs) Handles SchedulerStorage1.AppointmentDependencyDeleting
        If allowDepDelete = False Then e.Cancel = True
    End Sub

    Private Sub SchedulerStorage1_AppointmentsChanged(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsChanged
        Try
            If Not SchedulerControl1.SelectedAppointments.Count > 0 Then Exit Sub
            UpdateStatusForCrewSelected(SchedulerControl1.SelectedAppointments(0))
            With SchedulerControl1.SelectedAppointments(0)
                If .LabelId = LabelID.Onboard Then Exit Sub
                'isOverlapping(.CustomFields("CrewID"), .Start, .End, .Subject, .CustomFields("PKey"), .Id)
                If isEditdable = True And isSaving = False Then
                    'If frmPopUp.txtValidationMsg.Text <> "" Or frmPopUp.txtValidationMsg2.Text <> "" Then
                    '    .LabelId = LabelID.WithError
                    'Else
                    '    .LabelId = LabelID.Edited
                    'End If
                    UpdateCrewApts(.Id, .CustomFields("CrewID"))
                End If
            End With

        Catch ex As System.Exception
            MsgBox("MPS5 Error:" & ex.Message)
            LogErrors(" SchedulerStorage1_AppointmentsChanged: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Others"

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            flag = True
            ALLOWNEXTS = flag
            SaveData() '
            'ElseIf res = MsgBoxResult.No Then
        ElseIf res = MsgBoxResult.No Then
            BRECORDUPDATEDs = False
            undoChanges()
        Else
            isEditdable = True
            EditCheck(Name, True)
            Return False
        End If
        BRECORDUPDATEDs = False
        flag = False
        ALLOWNEXTS = True
        Return flag
    End Function

    Private Sub ExpandActiveSchedulerView()
        SchedulerControl1.GanttView.ShowMoreButtons = True
        Dim view As SchedulerViewBase = SchedulerControl1.ActiveView
        view.ResourcesPerPage = (SchedulerControl1.Height - 100) / 30
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

    Private Sub SchedulerControl1_PopupMenuShowing(sender As Object, e As DevExpress.XtraScheduler.PopupMenuShowingEventArgs) Handles SchedulerControl1.PopupMenuShowing
        Dim menuItem As SchedulerMenuItem

        '=========================================================
        'SUPPOSED LAYOUT
        '=========================================================
        '(on an appointment and not editable)
        '
        '   View Information
        '   View/Add Comments
        '
        '=========================================================
        '(on an appointment and editable)
        '
        '   View/Edit Information
        '   View/Add Comments
        '   -----------------
        '   Assign a Reliever
        '   Align Dates
        '   Remove as Reliever of ....
        '   -----------------
        '   Copy
        '   Paste
        '   Delete
        '=========================================================
        '(on an empty space and not editable)
        '
        '   Go To Today
        '=========================================================
        '(on an empty space and editable)
        '
        '   Show Crew List
        '   Go To Today
        '=========================================================

        popUpMenu = e.Menu


        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Checks if right-clicked on an appointment to show the ff. options:
        '   View information
        '   View/Add Crew Comments
        Try
            Dim pos As New Point(Cursor.Position.X, Cursor.Position.Y)
            Dim viewInfo As SchedulerViewInfoBase = SchedulerControl1.ActiveView.ViewInfo
            Dim hitInfo As SchedulerHitInfo = viewInfo.CalcHitInfo(pos, False)

            If AppointmentRightClick.Clicked Then 'If hitInfo.HitTest = SchedulerHitTest.AppointmentContent Then
                '---------------------------------------------------------------------------------------------------------
                'View/Edit Information
                menuItem = New SchedulerMenuItem
                menuItem.BeginGroup = False
                menuItem.Caption = "View" & IIf(isEditdable, "/Edit", "") & " Information"
                AddHandler menuItem.Click, AddressOf doShowPopUpCrewData
                popUpMenu.Items.Add(menuItem)
                popUpMenu.MoveMenuItem(menuItem, 0)

                '---------------------------------------------------------------------------------------------------------
                'View/Add Comment
                menuItem = New SchedulerMenuItem
                menuItem.Caption = "View/Add Comments"
                AddHandler menuItem.Click, AddressOf viewCrewComments
                popUpMenu.Items.Add(menuItem)
                popUpMenu.MoveMenuItem(menuItem, 1)

            Else
                '---------------------------------------------------------------------------------------------------------
                'Show Crew Selection
                If isEditdable And Not IsNothing(SchedulerControl1.Storage.Resources.DataSource) And Not IsNothing(SchedulerControl1.Storage.Appointments.DataSource) Then
                    menuItem = New SchedulerMenuItem
                    If frmCrewlist.Visible Then
                        menuItem.Caption = "Hide Crew Selection List"
                        AddHandler menuItem.Click, AddressOf HideCrewList
                    Else
                        menuItem.Caption = "Show Crew Selection List"
                        AddHandler menuItem.Click, AddressOf DoShowCrewList
                    End If
                    popUpMenu.Items.Add(menuItem)
                    popUpMenu.MoveMenuItem(menuItem, 0)
                End If

            End If

            'If isEditdable = True Then
            '    'Remove items
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.OpenAppointment)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.DeleteAppointment)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.DeleteAppointmentDependency)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleVisible)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleEnable)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.SwitchViewMenu)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.AppointmentDependencyMenu)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.AppointmentDragMenu)
            '    popUpMenu.RemoveMenuItem(SchedulerMenuItemId.GotoDate)

            '    menuItem = New SchedulerMenuItem
            '    menuItem.BeginGroup = True
            '    menuItem.Caption = "Copy"
            '    AddHandler menuItem.Click, AddressOf doCopy
            '    popUpMenu.Items.Add(menuItem)

            '    menuItem = New SchedulerMenuItem
            '    menuItem.Caption = "Paste"
            '    menuItem.Enabled = Not (IsNothing(copiedApt) And IsNothing(copyAptData))
            '    AddHandler menuItem.Click, AddressOf doPaste
            '    popUpMenu.Items.Add(menuItem)
            '    '
            '    'Edit Caption
            '    popUpMenu.GetMenuItemById(SchedulerMenuItemId.AppointmentDependencyCreation).Caption = "Assign a Reliever"

            '    If SchedulerControl1.SelectedAppointments.Count > 0 Then
            '        'Add Items
            '        If SchedulerControl1.SelectedAppointments(0).LabelId = LabelID.Planned Or SchedulerControl1.SelectedAppointments(0).LabelId = LabelID.Edited Then popUpMenu.Items.Add(New SchedulerMenuItem("Align Dates", AddressOf AlignDates))
            '        If SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count > 0 Then
            '            For i As Integer = 0 To SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count - 1
            '                Try
            '                    Dim aptD As AppointmentDependency = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id)(i)
            '                    Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.ParentId)
            '                    Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.DependentId)
            '                    Dim strParent As Object = aptParent.Id
            '                    Dim strDependent As Object = aptDependent.Id

            '                    menuItem = New SchedulerMenuItem
            '                    menuItem.Caption = "Remove as reliever of " & aptParent.Subject
            '                    menuItem.Id = aptParent.Id
            '                    AddHandler menuItem.Click, AddressOf RemoveReliever
            '                    popUpMenu.Items.Add(menuItem)
            '                Catch ex As SystemException
            '                    Continue For
            '                End Try
            '            Next
            '        End If
            '    End If

            '    menuItem = New SchedulerMenuItem
            '    menuItem.Caption = "Add Crew Comment"
            '    menuItem.BeginGroup = True
            '    AddHandler menuItem.Click, AddressOf viewCrewComments
            '    popUpMenu.Items.Add(menuItem)


            '    If SchedulerControl1.SelectedAppointments(0).LabelId <> LabelID.Onboard Then
            '        menuItem = New SchedulerMenuItem
            '        menuItem.Caption = "Delete"
            '        menuItem.BeginGroup = True
            '        AddHandler menuItem.Click, AddressOf DeleteData
            '        popUpMenu.Items.Add(menuItem)
            '    End If

            'Else
            '    popUpMenu.Items.Clear()
            'End If


            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            'Remove menuitems not needed anymore
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.OpenAppointment)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.DeleteAppointment)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.DeleteAppointmentDependency)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleVisible)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleEnable)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.SwitchViewMenu)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.AppointmentDependencyMenu)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.AppointmentDragMenu)
            popUpMenu.RemoveMenuItem(SchedulerMenuItemId.GotoDate)

            If isEditdable = True Then

                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Reliever-related
                'Edit 'Created Dependency' Caption to 'Assign a Reliever'
                If Not popUpMenu.GetMenuItemById(SchedulerMenuItemId.AppointmentDependencyCreation) Is Nothing Then
                    popUpMenu.GetMenuItemById(SchedulerMenuItemId.AppointmentDependencyCreation).Caption = "Assign a Reliever"
                End If
                

                If SchedulerControl1.SelectedAppointments.Count > 0 Then
                    'Add Items
                    Dim menuItemAlignDates As SchedulerMenuItem = New SchedulerMenuItem("Align Dates", AddressOf AlignDates)
                    If SchedulerControl1.SelectedAppointments(0).LabelId = LabelID.Planned Or SchedulerControl1.SelectedAppointments(0).LabelId = LabelID.Edited Then popUpMenu.Items.Add(menuItemAlignDates)
                    If SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count > 0 Then
                        For i As Integer = 0 To SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count - 1
                            Try
                                Dim aptD As AppointmentDependency = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id)(i)
                                Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.ParentId)
                                Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.DependentId)
                                Dim strParent As Object = aptParent.Id
                                Dim strDependent As Object = aptDependent.Id

                                menuItem = New SchedulerMenuItem
                                menuItem.Caption = "Remove as reliever of " & aptParent.Subject
                                menuItem.Id = aptParent.Id
                                AddHandler menuItem.Click, AddressOf RemoveReliever
                                popUpMenu.Items.Add(menuItem)
                            Catch ex As SystemException
                                Continue For
                            End Try
                        Next
                    Else
                        menuItemAlignDates.Enabled = False
                    End If
                End If

                '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Copy, Paste, Delete
                If AppointmentRightClick.Clicked Then
                    menuItem = New SchedulerMenuItem
                    menuItem.BeginGroup = True
                    menuItem.Caption = "Copy"
                    AddHandler menuItem.Click, AddressOf doCopy
                    popUpMenu.Items.Add(menuItem)
                Else
                    If isCopying Or Not IsNothing(copiedApt) Then
                        menuItem = New SchedulerMenuItem
                        menuItem.BeginGroup = True
                        menuItem.Caption = "Paste"
                        menuItem.Enabled = Not (IsNothing(copiedApt) And IsNothing(copyAptData))
                        AddHandler menuItem.Click, AddressOf doPaste
                        popUpMenu.Items.Add(menuItem)
                    End If
                End If

                If SchedulerControl1.SelectedAppointments(0).LabelId <> LabelID.Onboard Then
                    menuItem = New SchedulerMenuItem
                    menuItem.Caption = "Delete"
                    AddHandler menuItem.Click, AddressOf DeleteData
                    popUpMenu.Items.Add(menuItem)

                End If

            Else
                popUpMenu.RemoveMenuItem(SchedulerMenuItemId.AppointmentDependencyCreation)
            End If

            'Else
            'popUpMenu.Items.Clear()
            'End If
        Catch ex As SystemException
            'MsgBox("MPS5 Error RemoveMsg:" & ex.Message)
        End Try
    End Sub

    Private Sub RemoveReliever(ByVal sender As Object, ByVal e As EventArgs)
        Dim obj As SchedulerMenuItem = TryCast(sender, SchedulerMenuItem)
        Dim rowsToDelete As New ArrayList

        Dim aptDependent As Appointment = SchedulerControl1.SelectedAppointments(0)
        If MessageBox.Show("Are you sure you want to " & obj.Caption.Replace("Remove", "Remove " & aptDependent.Subject) & "?" _
                          , "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            allowDepDelete = True
            For Each aptD As AppointmentDependency In SchedulerStorage1.AppointmentDependencies.Items
                If aptD.ParentId = obj.Id And aptD.DependentId = aptDependent.Id Then
                    SchedulerStorage1.AppointmentDependencies.Remove(aptD)

                    Dim foundrow() As DataRow = dtNewDependencies.Select("ParentID = " & aptD.ParentId)
                    If foundrow.Count > 0 Then
                        For i As Integer = 0 To foundrow.GetUpperBound(0)
                            rowsToDelete.Add(foundrow(i))
                        Next

                    End If
                    Exit For
                End If
            Next

            For i As Integer = 0 To rowsToDelete.Count - 1
                dtNewDependencies.Rows.Remove(rowsToDelete(i))
            Next

            Dim strUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "Update", 0, System.Environment.MachineName, "Remove as reliever.", Name, aptDependent.CustomFields("CrewID"))
            DB.RunSql("UPDATE tblPlanningEventCrew SET ToRelieveID = NULL, LastUpdatedBy = '" & strUpdatedBy & "' WHERE PKey = '" & aptDependent.CustomFields("PKey") & "'")
            allowDepDelete = False
        End If
    End Sub

    Private Sub doShowPopUpCrewData()
        'MsgBox("Test")
        'Dim pos As New Point(Cursor.Position.X, Cursor.Position.Y)
        'Dim viewInfo As SchedulerViewInfoBase = SchedulerControl1.ActiveView.ViewInfo
        'Dim hitInfo As SchedulerHitInfo = viewInfo.CalcHitInfo(pos, False)

        'Dim apt As Appointment = CType(hitInfo.ViewInfo, AppointmentViewInfo).Appointment
        'ShowPopUpCrewData(apt, Control.MousePosition)
        If AppointmentRightClick.Clicked And Not AppointmentRightClick.SelectedAppointment Is Nothing Then
            ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Gathering crew data ...")
            ShowPopUpCrewData(AppointmentRightClick.SelectedAppointment, Control.MousePosition)
            CloseCustomLoadScreen()
        End If
    End Sub
    Private Sub doCopy()
        Try
            isCopying = True
            Dim i As Integer = 0
            Dim apt As New Appointment
            apt.Subject = SchedulerControl1.SelectedAppointments(0).Subject
            apt.Description = SchedulerControl1.SelectedAppointments(0).CustomFields("CrewID")
            apt.LabelId = LabelID.Planned
            copyAptData = apt
            copiedApt = Nothing
        Catch ex As System.Exception
            MessageBox.Show("Please select a crew's service to copy.", "Graphical Planning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            isCopying = False
        End Try
    End Sub

    Private Sub doPaste()
        Dim newApt As Appointment
        Dim nDur As Integer = 0

        If IsNothing(copiedApt) = False Then
            newApt = copiedApt
            nDur = DateDiff(DateInterval.Day, newApt.Start, DateAdd(DateInterval.Month, 6, newApt.Start))
            newApt.Duration = TimeSpan.FromDays(nDur)
            SchedulerControl1.Storage.Appointments.Add(newApt)
            copiedApt = Nothing
            copyAptData = Nothing
        End If

        If isCopying Then
            If IsNothing(copyAptData) = False Then
                newApt = copyAptData
                nDur = DateDiff(DateInterval.Day, newApt.Start, DateAdd(DateInterval.Month, 6, newApt.Start))
                newApt.Duration = TimeSpan.FromDays(nDur)
                SchedulerControl1.Storage.Appointments.Add(newApt)
                copyAptData = Nothing
            End If
            isCopying = False
        End If
    End Sub

    Private Sub AlignDates()
        If SchedulerControl1.SelectedAppointments.Count > 0 Then
            If SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count > 0 Then
                Dim aptD As AppointmentDependency = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id)(0)
                Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.ParentId)
                Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.DependentId)
                Dim strParent As Object = aptParent.Id
                Dim strDependent As Object = aptDependent.Id
                SchedulerStorage1.Appointments.GetAppointmentById(strDependent).Start = SchedulerStorage1.Appointments.GetAppointmentById(strParent).End

            End If
        End If
    End Sub

    Private Sub schedulerEditMode(ByVal bol As Boolean)
        If bol = True Then
            SchedulerControl1.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.All
            'SchedulerControl1.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.All
            'SchedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.All
            SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.Custom
            SchedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.Custom
            SchedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.All

            disableLTPFields(False)
            AllowAddition(Name, True)
            AllowDeletion(Name, True)
        Else
            SchedulerControl1.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.None
            'SchedulerControl1.OptionsCustomization.AllowAppointmentCreate = UsedAppointmentType.None
            'SchedulerControl1.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None
            SchedulerControl1.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None
            SchedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None
            SchedulerControl1.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.None

            disableLTPFields(True)
            AllowAddition(Name, False)
            AllowDeletion(Name, False)
            AllowSaving(Name, False)
            EditCheck(Name, False)
            AllowUndoChanges(Name, False)
        End If
    End Sub

    Private Sub disableLTPFields(ByVal bol As Boolean)
        With frmPopUp
            '.lueRank.ReadOnly = bol
            '.lueVessel.ReadOnly = bol
            .lueWScale.ReadOnly = bol
            .deEndDate.ReadOnly = bol
            .deStartDate.ReadOnly = bol
            .txtLOC.ReadOnly = bol
            .txtLOCDays.ReadOnly = bol
            .txtRemarks.ReadOnly = bol

            MPS4Functions.AllowRepositoryBtnEdit(.deStartDate, Not bol)
            MPS4Functions.AllowRepositoryBtnEdit(.deEndDate, Not bol)

            .lueVessel.ReadOnly = True
            .lueRank.ReadOnly = True
        End With
    End Sub

    Private Sub clearDataFields()
        '_crewID = ""
        _popupDetail.Clear()
        With (frmPopUp)
            RemoveHandler .lueRank.EditValueChanged, AddressOf lueRank_EditValueChanged
            RemoveHandler .lueVessel.EditValueChanged, AddressOf lueVessel_EditValueChanged
            RemoveHandler .lueWScale.EditValueChanged, AddressOf lueWScale_CloseUp
            RemoveHandler .deStartDate.EditValueChanged, AddressOf deStartDate_EditValueChanged
            RemoveHandler .deEndDate.EditValueChanged, AddressOf deEndDate_EditValueChanged
            RemoveHandler .txtLOC.EditValueChanged, AddressOf txtLOC_EditValueChanged
            RemoveHandler .txtLOC.EditValueChanging, AddressOf txtLOC_EditValueChanging
            RemoveHandler .txtLOCDays.EditValueChanged, AddressOf txtLOCDays_EditValueChanged
            RemoveHandler .txtLOCDays.EditValueChanging, AddressOf txtLOCDays_EditValueChanging
            RemoveHandler .txtRemarks.EditValueChanged, AddressOf txtRemarks_EditValueChanged

            .txtCrewName.EditValue = Nothing
            .lueRank.EditValue = Nothing
            .lueVessel.EditValue = Nothing
            .lueWScale.EditValue = Nothing
            .deEndDate.EditValue = Nothing
            .deStartDate.EditValue = Nothing
            .txtLOC.EditValue = Nothing
            .txtLOCDays.EditValue = Nothing
            .txtRemarks.EditValue = Nothing
            .txtCompID.EditValue = Nothing
            .txtDOB.EditValue = Nothing
            .txtAge.EditValue = Nothing
            .txtAgent.EditValue = Nothing
            .txtReligion.EditValue = Nothing
            'gridComp.DataSource = Nothing
            .txtValidationMsg.Text = Nothing
            .txtValidationMsg2.Text = Nothing

            AddHandler .lueRank.EditValueChanged, AddressOf lueRank_EditValueChanged
            AddHandler .lueVessel.EditValueChanged, AddressOf lueVessel_EditValueChanged
            AddHandler .lueWScale.EditValueChanged, AddressOf lueWScale_CloseUp
            AddHandler .deStartDate.EditValueChanged, AddressOf deStartDate_EditValueChanged
            AddHandler .deEndDate.EditValueChanged, AddressOf deEndDate_EditValueChanged
            AddHandler .txtLOC.EditValueChanged, AddressOf txtLOC_EditValueChanged
            AddHandler .txtLOC.EditValueChanging, AddressOf txtLOC_EditValueChanging
            AddHandler .txtLOCDays.EditValueChanged, AddressOf txtLOCDays_EditValueChanged
            AddHandler .txtLOCDays.EditValueChanging, AddressOf txtLOCDays_EditValueChanging
            AddHandler .txtRemarks.EditValueChanged, AddressOf txtRemarks_EditValueChanged
        End With
    End Sub

#End Region

#Region "Triggered when Editing"

    Private Sub txtRemarks_EditValueChanged(sender As Object, e As System.EventArgs)
        If isEditdable = True Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                Dim apt As Appointment = SchedulerControl1.SelectedAppointments(0)
                If apt.LabelId = LabelID.Onboard Then Exit Sub
                SchedulerControl1.SelectedAppointments(0).CustomFields("Remarks") = frmPopUp.txtRemarks.EditValue
            End If
        End If
    End Sub

    Private Sub deEndDate_EditValueChanged(sender As Object, e As System.EventArgs)
        If isEditdable = True Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                Dim apt As Appointment = SchedulerControl1.SelectedAppointments(0)
                'If isOverlapping(apt.CustomFields("CrewID"), apt.Start, deEndDate.EditValue, apt.Subject, apt.CustomFields("PKey"), apt.Id) Then
                '    Exit Sub 'calvhin2017
                'End If
                isSupplying = True
                frmPopUp.txtLOC.EditValue = computeLOC(apt.Start, frmPopUp.deEndDate.EditValue, "LOC")
                frmPopUp.txtLOCDays.EditValue = computeLOC(apt.Start, frmPopUp.deEndDate.EditValue, "LOCDays")
                Dim nDur As Integer = 0
                nDur = DateDiff(DateInterval.Day, apt.Start, frmPopUp.deEndDate.EditValue)
                apt.Duration = TimeSpan.FromDays(nDur)
                updateCustomFields(frmPopUp.txtLOC.EditValue, "LOC")
                updateCustomFields(frmPopUp.txtLOCDays.EditValue, "LOCDays")
                isSupplying = False
            End If
        End If
    End Sub

    Private Sub deStartDate_EditValueChanged(sender As Object, e As System.EventArgs)
        If isEditdable = True Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                Dim apt As Appointment = SchedulerControl1.SelectedAppointments(0)
                If apt.LabelId = LabelID.Onboard Then Exit Sub
                'isOverlapping(apt.CustomFields("CrewID"), apt.Start, deStartDate.EditValue, apt.Subject, apt.CustomFields("PKey"), apt.Id) 'calvhin2017
                isSupplying = True
                frmPopUp.txtLOC.EditValue = computeLOC(apt.Start, frmPopUp.deEndDate.EditValue, "LOC")
                frmPopUp.txtLOCDays.EditValue = computeLOC(apt.Start, frmPopUp.deEndDate.EditValue, "LOCDays")
                updateCustomFields(frmPopUp.txtLOC.EditValue, "LOC")
                updateCustomFields(frmPopUp.txtLOCDays.EditValue, "LOCDays")
                isSupplying = False
                apt.Start = frmPopUp.deStartDate.EditValue
            End If
        End If
    End Sub

    Private Sub SchedulerStorage1_AppointmentChanging(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectCancelEventArgs) Handles SchedulerStorage1.AppointmentChanging
        Dim apt As Appointment = e.Object
        forSaving(apt.Id)
    End Sub

    Private Sub UpdateStatusForCrewSelected(appointment As Appointment)
        Dim crewId As String = appointment.CustomFields("CrewID").ToString()
        Dim crewRank As String = appointment.CustomFields("FKeyRank").ToString()
        Dim strFKeyComp As String = DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey = '" & appointment.CustomFields("FKeyVessel").ToString() & "'")
        Dim loc As String = computeLOC(appointment.Start, appointment.End, "LOC")
        Dim plannedSon As String = appointment.Start.ToString("dd-MMM-yyyy")

        Dim result As DataTable = DB.CreateTable("SELECT dbo.HasLacking_Graphical('" & crewId & "'" & _
                                                                                         ",'" & crewRank & "'" & _
                                                                                         ",'" & strFKeyComp & "'" & _
                                                                                         "," & loc & "," & _
                                                                                         "'" & plannedSon & "','') AS Result ")

        If result.Rows.Count > 0 Then
            For Each row As DataRow In result.Rows
                Dim index As Integer = IsCrewExistsForChecking(crewId, appointment.Id)
                If index <> -1 Then
                    With _listOfCrewIDs(index)
                        .CrewID = crewId & "-" & row(0).ToString()
                        .LackingResult = row(0).ToString()
                        .AppointmentID = appointment.Id
                    End With
                End If
            Next
        End If

    End Sub

    Private Function IsCrewExistsForChecking(CrewID As String, AppointmentID As Integer) As Integer
        'added by tony20170714
        Dim retVal As Integer = -1
        Dim tmp As CrewAppointmentData

        For i As Integer = 0 To _listOfCrewIDs.Count - 1
            tmp = _listOfCrewIDs(i)
            If CrewID.Equals(tmp.CrewID.ToString()) And AppointmentID.Equals(tmp.AppointmentID) Then
                Return i
            End If
        Next
        Return retVal
    End Function


    Private Sub SchedulerStorage1_AppointmentDependencyInserting(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectCancelEventArgs) Handles SchedulerStorage1.AppointmentDependencyInserting
        Dim aptDep As AppointmentDependency = e.Object
        Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptDep.ParentId)
        Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptDep.DependentId)
        If aptDependent.LabelId = LabelID.Onboard Then
            MsgBox("You can't assign an onboard crew as reliever.")
            e.Cancel = True
            Exit Sub
        End If
        'If strFilterMode = "Rank" Then 'I uncomment this to also apply this validation in vesse filter
        If aptDependent.ResourceId <> aptParent.ResourceId Then
            MsgBox("Please assign a reliever from the same row.")
            e.Cancel = True
            Exit Sub
        End If
        ' If

        For i As Integer = 0 To SchedulerStorage1.AppointmentDependencies.Count - 1
            If aptParent.Id = SchedulerStorage1.AppointmentDependencies(i).ParentId Then
                MsgBox("Please remove existing reliever before assigning to another reliever.")
                e.Cancel = True
                Exit Sub
                Exit For
            End If
        Next

        'As per sir ian, -calvhin 20161012
        'If aptDependent.Start < aptParent.End Then
        '    MsgBox("Start date of reliever cannot be earlier that the crew to relieve's End date.")
        '    e.Cancel = True
        'End If

        If aptDependent.Description = aptParent.Description Then
            MsgBox("Crew cannot relieve him/her self.")
            e.Cancel = True
            Exit Sub
        End If

    End Sub

    Private Sub SchedulerStorage1_AppointmentDependenciesInserted(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentDependenciesInserted
        Dim aptDep As AppointmentDependency = e.Objects(0)
        Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptDep.ParentId)
        Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptDep.DependentId)

        '<!-- edited by tony20170911:   clears selected appointment and sets focuses to the dependent (the one selected as a reliever)
        '                               this is done so the checking of overlapping activity date is on the focused appointment, which is the dependent
        SchedulerControl1.SelectedAppointments.Clear()
        SchedulerControl1.SelectedAppointments.Add(aptDependent)
        '-->

        SchedulerStorage1.Appointments.GetAppointmentById(aptDep.DependentId).Start = aptParent.End

        'If Not isOverlapping(aptDependent.CustomFields("CrewID"), aptDependent.Start, aptDependent.End, aptDependent.Subject, aptDependent.CustomFields("PKey"), aptDependent.Id) Then
        SchedulerStorage1.Appointments.GetAppointmentById(aptDependent.Id).LabelId = LabelID.Edited
        dtNewDependencies.Rows.Add(New Object() {aptParent.Id, aptDependent.Id})
        'End If

        AllowUndoChanges(Name, True)

    End Sub

    Private Sub SchedulerStorage1_AppointmentInserting(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectCancelEventArgs) Handles SchedulerStorage1.AppointmentInserting
        Dim nId As Int32 = 1
        Dim apt As Appointment = e.Object
        If isOverlapping(apt.Description, apt.Start, apt.End, apt.Subject, apt.CustomFields("PKey"), , True) = True Then
            'MsgBox(frmPopUp.txtValidationMsg.Text)
            frmPopUp.txtValidationMsg.Text = ""
            e.Cancel = True
            Exit Sub
        End If

        'comment out by fords 20170523
        ''check competence
        ''Dim dtCL As DataTable = checkCrewCheckList(strCurrentVsl, strCurrentRank, apt.CustomFields("CrewID"))
        'Dim dtCL As DataTable = CheckCrewCompetence(apt.CustomFields("CrewID"), strCurrentRank, strCurrentVsl, 6, apt.Start.ToString("dd-MMM-yyyy"))
        'gridComp.DataSource = dtCL
        'If Not IsNothing(dtCL) Then
        '    If dtCL.Rows.Count > 0 Then
        '        If dtCL.Select("Complied = 'No'").CopyToDataTable.Rows.Count > 0 Then
        '            If MessageBox.Show("Crew didn't meet vessel competence requirements, do you want to continue?", GetAppName() & " - LTP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
        '                Dim frm As New frmCheckList(dtCL)
        '                frm.ShowDialog()
        '                copyAptData = Nothing
        '                e.Cancel = True
        '                isCopying = False
        '                Exit Sub
        '            End If
        '        End If
        '    End If
        'End If

        '//// Neil 20170814 crew conflict feature
        Dim dtres As New DataTable
        'dtres = clsConflict.CrewConflict_GetCrewWithConflict(apt.Description, dtAppointments, "CrewID", MPSDB.GetConnectionString)
        dtres = clsConflict.CrewConflict_GetCrewWithConflict(apt.Description, dtAppointments, "CrewID", "Start", "End", apt.Start, apt.End, MPSDB.GetConnectionString)

        If dtres.Rows.Count > 0 Then
            If MsgBox("Crew " & apt.Subject & " is conflict with crew " & dtres.Rows(0)("CConflictName") & ", do you want to continue?", vbExclamation + vbYesNo) = vbNo Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        '///////////

        If dtAppointments.Rows.Count.ToString > 0 Then
            nId = Val(dtAppointments.Compute("MAX(Id)", "").ToString) + 1
        End If

        SchedulerStorage1.SetAppointmentId(apt, nId.ToString)
        With SchedulerStorage1.Appointments.GetAppointmentById(nId.ToString)
            Dim nDur As Integer = 0
            nDur = DateDiff(DateInterval.Day, apt.Start, DateAdd(DateInterval.Month, 6, apt.Start))
            apt.Duration = TimeSpan.FromDays(nDur)
            If isCopying Then
                .ResourceId = SchedulerControl1.SelectedResource.Id
            Else
                .ResourceId = strResourceId
            End If
            .PercentComplete = 0
            .CustomFields("CrewID") = apt.Description
            .CustomFields("FKeyVessel") = strCurrentVsl
            .CustomFields("FKeyRank") = strCurrentRank
            .CustomFields("FKeyWScaleRank") = "SYSWSRUNDEF"
            .CustomFields("LOC") = 6
            .CustomFields("LOCDays") = 0
            .CustomFields("RecType") = "Pln"
            .CustomFields("PKey") = ""
            .CustomFields("PlanningEvent") = ""
            .LabelId = LabelID.Edited
        End With
        forSaving(nId.ToString)
    End Sub

    Private Sub SchedulerControl1_AppointmentDrop(sender As Object, e As DevExpress.XtraScheduler.AppointmentDragEventArgs) Handles SchedulerControl1.AppointmentDrop
        If Not e.HitResource.Id Is Nothing Then
            strResourceId = e.HitResource.Id

            Dim dt As DataTable = CType(SchedulerStorage1.Resources.DataSource, DataTable).Copy
            Dim dr As DataRow = dt.Select("ResourceID='" & e.HitResource.Id & "'")(0)

            If strFilterMode = "Vessel" Then
                strCurrentRank = dr("AdmPKey").ToString
            Else
                strCurrentVsl = dr("AdmPKey").ToString
            End If

            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                If e.SourceAppointment.Id <> SchedulerControl1.SelectedAppointments(0).Id Then Exit Sub
                Dim selID As Object = SchedulerControl1.SelectedAppointments(0).Id
                If strFilterMode = "Vessel" Then
                    If isParentInDifferentRow(strResourceId, SchedulerControl1.SelectedAppointments(0), "rank") Then
                        'SchedulerStorage1.Appointments.GetAppointmentById(selID).CustomFields("FKeyRank") = frmPopUp.lueRank.EditValue
                        e.Allow = False
                        e.Handled = True
                        Exit Sub
                    End If
                    frmPopUp.lueRank.EditValue = strCurrentRank
                    e.EditedAppointment.CustomFields("FKeyRank") = strCurrentRank
                Else
                    If isParentInDifferentRow(strResourceId, SchedulerControl1.SelectedAppointments(0), "vessel") Then
                        'SchedulerStorage1.Appointments.GetAppointmentById(selID).CustomFields("FKeyVessel") = frmPopUp.lueVessel.EditValue
                        e.Allow = False
                        e.Handled = True
                        Exit Sub
                    End If
                    frmPopUp.lueRank.EditValue = strCurrentRank
                    frmPopUp.lueVessel.EditValue = strCurrentVsl
                    e.EditedAppointment.CustomFields("FKeyVessel") = strCurrentVsl
                End If
                SchedulerControl1.SelectedAppointments(0).ResourceId = strResourceId

            End If
            If e.EditedAppointment.Start < Today.Date.ToString Then
                MsgBox("You dropped on a date earlier than today.")
            End If
            AllowSaving(Name, True)
        End If

        SchedulerControl1.LimitInterval = New TimeInterval(_START, _END)
    End Sub

    Private Sub txtLOC_EditValueChanged(sender As Object, e As System.EventArgs)
        If isEditdable = True Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                Dim dateEnd As Date
                dateEnd = (SchedulerControl1.SelectedAppointments(0).Start.AddMonths(IfNull(frmPopUp.txtLOC.EditValue, 0))).AddDays(IfNull(frmPopUp.txtLOCDays.EditValue, 0))
                SchedulerControl1.SelectedAppointments(0).End = dateEnd
                updateCustomFields(frmPopUp.txtLOC.EditValue, "LOC")
                frmPopUp.deEndDate.EditValue = dateEnd
            End If
        End If
    End Sub

    Private Sub txtLOCDays_EditValueChanged(sender As Object, e As System.EventArgs)
        If isEditdable = True Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                Dim dateEnd As Date
                dateEnd = (SchedulerControl1.SelectedAppointments(0).Start.AddMonths(IfNull(frmPopUp.txtLOC.EditValue, 0))).AddDays(IfNull(frmPopUp.txtLOCDays.EditValue, 0))
                SchedulerControl1.SelectedAppointments(0).End = dateEnd
                updateCustomFields(frmPopUp.txtLOCDays.EditValue, "LOCDays")
                frmPopUp.deEndDate.EditValue = dateEnd
            End If
        End If
    End Sub

    Private Sub forSaving(ByVal strID As Object)
        If Not arrNewAndEdited.Contains(strID) Then
            arrNewAndEdited.Add(strID)
            BRECORDUPDATEDs = True
            AllowUndoChanges(Name, True)
        End If
    End Sub

    Private Sub lueRank_EditValueChanged(sender As Object, e As System.EventArgs)
        If SchedulerControl1.SelectedAppointments.Count > 0 Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                If strFilterMode = "Vessel" Then
                    SchedulerControl1.SelectedAppointments(0).ResourceId = frmPopUp.lueRank.EditValue
                End If
                updateCustomFields(strCurrentRank, "FKeyRank")
            End If
        End If
    End Sub

    Private Sub lueWScale_CloseUp(sender As Object, e As System.EventArgs)
        If isEditdable = True Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then
                SchedulerControl1.SelectedAppointments(0).CustomFields("FKeyWScaleRank") = frmPopUp.lueWScale.EditValue
                Dim dr() As System.Data.DataRow
                dr = dtWScaleRank.Select("PKey = '" & frmPopUp.lueWScale.EditValue & "'")
                frmPopUp.txtLOC.EditValue = dr(0)("LOC")
                frmPopUp.txtLOCDays.EditValue = dr(0)("LOCDays")
            End If
        End If
    End Sub

    Private Sub lueVessel_EditValueChanged(sender As Object, e As System.EventArgs)
        If isEditdable = True Then
            If isSupplying = True Then Exit Sub
            If SchedulerControl1.SelectedAppointments.Count > 0 Then SchedulerControl1.SelectedAppointments(0).CustomFields("FKeyVessel") = frmPopUp.lueVessel.EditValue
        End If
    End Sub

    Private Sub txtLOC_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If isSupplying = False Then
            If isEditdable = True Then
                If SchedulerControl1.SelectedAppointments.Count > 0 Then
                    If e.NewValue <= 0 Then
                        MsgBox("Please enter a number not less than or equal to 0.", MsgBoxStyle.Information)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtLOCDays_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If isSupplying = False Then
            If isEditdable = True Then
                If SchedulerControl1.SelectedAppointments.Count > 0 Then
                    If e.NewValue < 0 Then
                        MsgBox("Please enter a number not less than 0.", MsgBoxStyle.Information)
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SchedulerStorage1_AppointmentsInserted(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsInserted
        Dim apt As Appointment = e.Objects(0)
        Try
            SchedulerControl1.SelectedAppointments.Clear()
            SchedulerControl1.SelectedAppointments.Add(apt)
            SchedulerStorage1.Appointments.GetAppointmentById(apt.Id).CustomFields("RecType") = "Pln"
            SetupCompetenceForCrewWithIcon(Nothing, SchedulerStorage1.Appointments.GetAppointmentById(apt.Id))
            SupplyDataToControls(apt)
            disableLTPFields(False)
        Catch ex As InvalidOperationException
            'MsgBox("MPS5 Error:" & ex.Message)
        End Try
    End Sub

    Private Sub deStartDate_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If Not isEditdable Then e.Cancel = True
    End Sub

#End Region

#Region "Private Functions"

    Private Function isOverlapping(ByVal CrewID As String, ByVal dStartDate As Date, ByVal dEndDate As Date, ByVal CrewName As String, ByVal PKey As String, Optional ByVal id As Object = 0, Optional ByVal showMsg As Boolean = False) As Boolean ', ByVal field As String
        Dim res As Boolean = False
        Dim msg As String = ""
        Dim cnt As Integer = 0
        Dim dt As DataTable
        Dim aptDt As DataTable = Nothing
        Dim strPKeyFilter As String = ""
        Dim conflictVessel As String = ""
        Try
            If isEditdable = True Then
                'If isEditdable = True And bAddMode = False Then cnt = 1
                For i As Integer = 0 To arrNewAndEdited.Count - 1
                    strPKeyFilter = strPKeyFilter & "', '" & SchedulerStorage1.Appointments.GetAppointmentById(arrNewAndEdited(i)).CustomFields("PKey")
                Next

                If strPKeyFilter.Length > 0 Then
                    strPKeyFilter = strPKeyFilter.TrimEnd(", '")
                    strPKeyFilter = strPKeyFilter.Substring(2)
                    strPKeyFilter = " AND tblPlanningEventCrew.PKey NOT IN(" & strPKeyFilter & "')"
                End If

                If PKey = Nothing Then
                    dt = DB.CreateTable("SELECT PlannedDateSON, PlannedDateDue, FKeyVessel FROM tblPlanningEventCrew INNER JOIN tblPlanningEvent ON tblPlanningEvent.PKey = tblPlanningEventCrew.FKeyPlanningEvent WHERE CrewID = '" & CrewID & "'" & strPKeyFilter & " AND                                                  (FKeyActivity IS NULL OR FKeyActivity = '') AND ((" & ChangeToSQLDate(dStartDate) & "  BETWEEN PlannedDateSON AND PlannedDateDue OR " & ChangeToSQLDate(dEndDate) & " BETWEEN  PlannedDateSON AND PlannedDateDue) OR (PlannedDateSON BETWEEN " & ChangeToSQLDate(dStartDate) & " AND " & ChangeToSQLDate(dEndDate) & " AND PlannedDateDue BETWEEN " & ChangeToSQLDate(dStartDate) & " AND " & ChangeToSQLDate(dEndDate) & ")) ORDER BY PlannedDateDue DESC")
                Else
                    dt = DB.CreateTable("SELECT PlannedDateSON, PlannedDateDue, FKeyVessel FROM tblPlanningEventCrew INNER JOIN tblPlanningEvent ON tblPlanningEvent.PKey = tblPlanningEventCrew.FKeyPlanningEvent WHERE CrewID = '" & CrewID & "'" & strPKeyFilter & " AND tblPlanningEventCrew.PKey  <> '" & PKey & "' AND (FKeyActivity IS NULL OR FKeyActivity = '') AND ((" & ChangeToSQLDate(dStartDate) & "  BETWEEN PlannedDateSON AND PlannedDateDue OR " & ChangeToSQLDate(dEndDate) & " BETWEEN  PlannedDateSON AND PlannedDateDue) OR (PlannedDateSON BETWEEN " & ChangeToSQLDate(dStartDate) & " AND " & ChangeToSQLDate(dEndDate) & " AND PlannedDateDue BETWEEN " & ChangeToSQLDate(dStartDate) & " AND " & ChangeToSQLDate(dEndDate) & ")) ORDER BY PlannedDateDue DESC")
                End If

                If dt.Rows.Count > cnt Then
                    conflictVessel = dt.Rows(0).Item("FKeyVessel").ToString
                    msg = " - From " & CDate(dt.Rows(0).Item("PlannedDateSON")).ToString("dd-MMM-yyyy") & " To " & CDate(dt.Rows(0).Item("PlannedDateDue")).ToString("dd-MMM-yyyy")
                    res = True
                    GoTo Here
                End If

                For i As Integer = 0 To arrNewAndEdited.Count - 1
                    Dim apt As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(arrNewAndEdited(i))
                    If apt.CustomFields("CrewID") = CrewID And apt.Id <> id And (IfNull(PKey, "") <> apt.CustomFields("PKey") Or (PKey = "" And apt.CustomFields("PKey") = "")) Then
                        If (((apt.End >= dStartDate) And (dStartDate >= apt.Start)) Or ((apt.End >= dEndDate) And (dEndDate >= apt.Start))) _
                            Or ((dStartDate <= apt.Start) And (apt.End <= dEndDate)) Then
                            conflictVessel = apt.CustomFields("FKeyVessel").ToString
                            msg = " - From " & CDate(apt.Start).ToString("dd-MMM-yyyy") & " To " & CDate(apt.End).ToString("dd-MMM-yyyy")
                            res = True
                        End If
                    End If
                Next

            End If
Here:
            If res = True Then
                frmPopUp.txtValidationMsg.Text = "* An activity overlaps " & msg & " on " & DB.DLookUp("Name", "tblAdmVsl", "[VESSEL NOT EXIST]", "PKey = '" & conflictVessel & "'")
                If showMsg Then
                    MsgBox(frmPopUp.txtValidationMsg.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
                End If
            Else
                frmPopUp.txtValidationMsg.Text = ""
            End If
        Catch ex As System.Exception
            'MessageBox.Show("Saving canceled asdasd: " & ex.Message, "MPS5 - Planning")
            LogErrors(" isOverlapping: " & ex.Message)
        End Try
        Return res
    End Function

    Private Function isParentEndDateOverlapsWithDependentStartDate() As Boolean
        Dim res As Boolean = False
        For i As Integer = 0 To SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count - 1
            Dim aptD As AppointmentDependency = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id)(i)
            Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.ParentId)
            Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.DependentId)
            Dim strParent As Object = aptParent.Id
            Dim strDependent As Object = aptDependent.Id
            frmPopUp.txtValidationMsg2.Text = ""
            If aptDependent.Start < aptParent.End Then
                frmPopUp.txtValidationMsg2.Text = "* Start date of reliever cannot be earlier that the crew to relieve's End date."
                MsgBox(frmPopUp.txtValidationMsg2.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
                Return True
                Exit Function
            End If
        Next
        Return res
    End Function

    Private Function isParentInDifferentRow(ByVal strField As String, ByVal strCaption As String) As Boolean
        Dim res As Boolean = False
        For i As Integer = 0 To SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id).Count - 1
            Dim aptD As AppointmentDependency = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(SchedulerControl1.SelectedAppointments(0).Id)(i)
            Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.ParentId)
            Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.DependentId)
            Dim strParent As Object = aptParent.Id
            Dim strDependent As Object = aptDependent.Id

            If aptDependent.CustomFields(strField) <> aptParent.CustomFields(strField) Then
                MsgBox("This crew is assigned as a reliever in this " & strCaption & ", " & Environment.NewLine & " please remove assignment before moving to another " & strCaption & ".")
                Return True
                Exit Function
            End If
        Next
        Return res
    End Function

    Private Function IsParentInDifferentRow(ByVal hitSourceId As String, ByVal aptSelected As Appointment, ByVal strCaption As String) As Boolean
        Dim retVal As Boolean = False
        Dim dependenciesByDependent As Integer = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(aptSelected.Id).Count
        Dim mainCounter As Integer = dependenciesByDependent
        Dim aptD As AppointmentDependency

        If dependenciesByDependent <= 0 Then
            mainCounter = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByParentId(aptSelected.Id).Count
        End If

        For i As Integer = 0 To mainCounter - 1
            If dependenciesByDependent <= 0 Then
                aptD = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByParentId(aptSelected.Id)(i)
            Else
                aptD = SchedulerStorage1.AppointmentDependencies.Items.GetDependenciesByDependentId(aptSelected.Id)(i)
            End If

            Dim aptParent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.ParentId)
            Dim aptDependent As Appointment = SchedulerStorage1.Appointments.GetAppointmentById(aptD.DependentId)
            Dim strParentSourceId As Object = aptParent.ResourceId
            Dim strDependentSourceId As Object = aptDependent.ResourceId

            If strParentSourceId <> hitSourceId Or strDependentSourceId <> hitSourceId Then
                'tony20171228   MsgBox("This crew is assigned as a reliever in this " & strCaption & ", " & Environment.NewLine & " please remove assignment before moving to another " & strCaption & ".")
                MsgBox("This crew is assigned as a reliever of another crew." & Environment.NewLine & "Please remove reliever assignment before moving to another row level.")
                Return True
                Exit Function
            End If
        Next

        Return retVal
    End Function

    Private Sub updateCustomFields(ByVal val As Object, ByVal field As String)
        SchedulerControl1.SelectedAppointments(0).CustomFields(field) = val
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

#End Region

#Region "Export to Excel data from Graphical Planning"

    Public Overrides Sub ExecCustomFunction(param() As Object)
        MyBase.ExecCustomFunction(param)
        Try
            frmPopUp.Hide()
        Catch
            'do nothing
        End Try

        If IsNothing(SchedulerControl1.Storage.Appointments.DataSource) Then    'If no data on the main grid of Graphical planning
            Return
        ElseIf SchedulerControl1.Storage.Appointments.Count = 0 Then            'If there is a selection but no record/crew on that vessel/rank.
            Return
        Else                                                                    'Otherwise, process it.
            Dim tempData As DataTable = TryCast(SchedulerControl1.Storage.Resources.DataSource, DataTable)
            If tempData.Rows.Count = 0 Then Return
            If HasExcelInstalled() Then                                         'If there is a Microsoft Excel installed, proceed. 
                If DialogResult.Yes = MessageBox.Show("This will export the current state of Graphical Planning, proceed? ",
                                                      "Export Graphical Planning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Dim saveDialog As New System.Windows.Forms.SaveFileDialog()
                    saveDialog.Filter = "Excel Workbook (*.xls)|*.xls"
                    saveDialog.Title = "Select file location"
                    If saveDialog.ShowDialog() = DialogResult.OK Then
                        If Not saveDialog.FileName.Trim().Equals("") Then
                            GenerateExcel(saveDialog.FileName)
                        End If
                    End If
                End If
            Else
                MessageBox.Show("Your computer does not have a Microsoft Excel installed. The Graphical Planning export feature need the Excel to run properly. " & Environment.NewLine & _
                                "Please consult your System Administrator regarding this issue. Thank you.", "Export Graphical Planning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub

    Private Sub GenerateExcelHeaders(startDate As Date, diff As Integer, ByRef listOfDateRange As List(Of String), ByRef columnsToMerge As List(Of String), excelsheet As Excel.Worksheet)
        Dim months As New List(Of String)
        Dim years As New List(Of String)

        Dim colToMerge As Integer = 0
        Dim colCounter As Integer = 2

        Dim previousYear As String = startDate.Year.ToString()
        Dim hasChangedYear As Boolean = False
        'This loop will decide where to put months under a particular year, in this case, the startDate.
        For i As Integer = 1 To diff

            Dim monthName As String = startDate.ToString("MMM")
            Dim year As String = startDate.Year

            startDate = DateAdd(DateInterval.Month, 1, startDate)
            'If the current month belong to the same year, 
            If (year.Equals(previousYear)) Then
                colToMerge = colToMerge + 1         'Include that month on counting
            Else                                    'Otherwise, the year has change (possibly due to the last month is Dec, then adding another month will set the counting to Jan with a different year. 
                'These are the columns to merge.
                'hasChangedYear = True
                previousYear = year
                columnsToMerge.Add(colCounter & "," & colToMerge)
                colToMerge = 1
            End If

            colCounter = colCounter + 1

            months.Add(monthName)
            years.Add(year)
            listOfDateRange.Add(monthName & "," & year)
        Next
        columnsToMerge.Add(colCounter & "," & colToMerge)

        excelsheet.Range("C4").Resize(1, diff).Value = years.ToArray() 'Load years as header
        excelsheet.Range("C5").Resize(1, diff).Value = months.ToArray() 'Load Months as shown in the Graphical planning window. 

        excelsheet.Range("C4").Resize(1, diff).Interior.Color = Color.DeepSkyBlue
        excelsheet.Range("C5").Resize(1, diff).Interior.Color = Color.DeepSkyBlue

        DrawCellBorder(excelsheet.Range("C4"), True, 1, diff)
        DrawCellBorder(excelsheet.Range("C5"), True, 1, diff)
        DrawCellBorder(excelsheet, 5, diff)

        'added by tony20170804
        'Note:  ColumnWidth (inch) = Width (pixel)
        '       ColumnWidth = 8.11 ; Width = 48
        '       each column has 8.11. columns 1 and 2 must have a total of 16.22 therefore divided into 2 as below
        SetColumnWidth(excelsheet, 1, 1.89)     'default value should total to 16.22 - so the excelcolumnwidth multiplier is proportion for each month
        'SetColumnWidth(excelsheet, 2, 14.33)   'default value should total to 16.22 - so the excelcolumnwidth multiplier is proportion for each month
        SetColumnWidth(excelsheet, 2, 14.5)     'should be 14.33 but did not work out. adjusted to 14.5
        SetColumnWidth(excelsheet, 5, diff, ExcelColumnWidthInch)

    End Sub

    Private Sub DrawCellBorder(ByRef sheet As Excel.Worksheet, startCell As Integer, endCell As Integer)
        'Create a border for each month.
        For counter As Integer = startCell To endCell Step 1
            sheet.Range("C" & startCell).Borders().LineStyle = Excel.XlLineStyle.xlContinuous
        Next
    End Sub

    Private Sub DrawCellBorder(ByRef range As Excel.Range, isRange As Boolean, Optional startCell As Integer = 0, Optional endCell As Integer = 0)
        If isRange Then
            range.Resize(startCell, endCell).Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            range.Resize(startCell, endCell).HorizontalAlignment = Excel.Constants.xlCenter
        Else
            range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
        End If
    End Sub

    Private Sub SetColumnWidth(ByRef sheet As Excel.Worksheet, startcolumn As Integer, endcolumn As Integer, width As Double)
        For i As Integer = startcolumn To endcolumn
            SetColumnWidth(sheet, i, width)
        Next
    End Sub

    Private Sub SetColumnWidth(ByRef sheet As Excel.Worksheet, column As Integer, width As Double)
        Dim cColumn As String = NumToExcelCol(column)

        If Not IfNull(cColumn, "").Equals("") Then cColumn = cColumn & ":" & cColumn

        If Not IsNothing(sheet.Columns(cColumn)) Then
            sheet.Columns(cColumn).Columnwidth = width
        End If

    End Sub

    Public Sub GenerateExcel(fileName As String)
        Dim excelApp As New Excel.Application()
        Dim excelWBk As Excel.Workbook
        Dim excelSheet As Excel.Worksheet
        Dim excelRange As Excel.Range
        Dim nullValues As Object = Missing.Value

        Dim cols As Integer = 3
        Dim rows As Integer = 2

        Dim templateFileName As String = IfNull(MPSDB.GetConfig("TEMPLATE_FOLDER"), "") & "\GraphicalPlanning_Template.xlsx"

        ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Exporting Data ...")

        Try
            If Not File.Exists(templateFileName) Then
                MessageBox.Show("The exporting process cannot proceed because the excel template cannot be found. Please consult your Administrator regarding the setup of templates.", "Export Graphical Planning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                CloseCustomLoadScreen()
                Return
            End If

            excelApp.Visible = False
            excelApp.DisplayAlerts = False
            excelWBk = excelApp.Workbooks.Open(templateFileName)
            excelSheet = TryCast(excelWBk.ActiveSheet, Excel.Worksheet)
            Dim selectedName As String = IIf(strFilterMode.Equals("Vessel"), "Vessel : " & MPSDB.DLookUp("Name", "tblAdmVsl", "", "PKey='" & strCurrentVsl & "'").ToUpper(),
                                                                             "Rank : " & MPSDB.DLookUp("Name", "tblAdmRank", "", "PKey='" & strCurrentRank & "'").ToUpper())

            excelSheet.Name = TruncateName(selectedName.Substring(selectedName.IndexOf(":") + 1))                                       '--> This will be the vessel or rank name on sheet name.
            'Sheet name will onl be 30 characters long. This will truncate if the vessel/rank name is greater than 30 chars.
            excelSheet.Cells(2, 2) = selectedName                                                                                       '--> This will be the vessel or rank name in B2 cell.

            Dim crews As DataTable = TryCast(SchedulerControl1.Storage.Appointments.DataSource, DataTable)                              '---> Get all the crews as shown in the main list/scheduler window.
            PopulateGraphicalData(crews)
            Dim crewSelected As DataTable = ConvertToDataTable(listOfGraphicalData)
            'Get the oldest date in planning.
            Dim sDate = (From cr In crews Select cr Order By Convert.ToDateTime(cr("Start")) Ascending).FirstOrDefault()
            '//////////////// below added by tony20170724

            Dim eDate = (From cr In crews Select cr Order By DateAdd(DateInterval.Month, Convert.ToInt32(cr("LOC")), Convert.ToDateTime(cr("End"))) Descending).FirstOrDefault()
            'end tony ////////////////

            'Use the current date as the starting date if there is no result from the above query, otherwise use the date selected. 
            Dim startDate As Date = IIf(IsNothing(sDate), SchedulerControl1.Start, Convert.ToDateTime(sDate("Start").ToString()))
            '//////////////// below added by tony20170724
            Dim monthAllowanceAfterEndDate As Integer = 3
            Dim endDate As Date = IIf(IsNothing(eDate), SchedulerControl1.Start, DateAdd(DateInterval.Month, Convert.ToInt32(IfNull(eDate("LOC"), 0).ToString()) + monthAllowanceAfterEndDate, Convert.ToDateTime(eDate("Start").ToString())))
            'end tony ////////////////

            'Get the end date by adding 24 months from the start date (oldest date in the planning of selected vessel.)
            Dim diff As Integer = DateDiff(DateInterval.Month, startDate, endDate)   'DateDiff(DateInterval.Month, startDate, DateAdd(DateInterval.Month, 24, startDate))
            If diff < 24 Then diff = 24

            Dim columnsToMerge As New List(Of String)
            Dim listOfDateRange As New List(Of String)

            GenerateExcelHeaders(startDate, diff, listOfDateRange, columnsToMerge, excelSheet)                                          '--> Load Headers (Years and Months)
            MergeYears(columnsToMerge, excelSheet)                                                                                      '--> Merging header cells
            'These values are approximation based on the given template's layout. 
            Dim startRow As Integer = 6
            Dim startCol As Integer = 2
            Dim txtBoxPosX As Integer = 100
            Dim txtBoxPosY As Single = 77.1
            Dim barPosX As Integer = 100
            Dim barPosY As Single = 77.1
            Dim startPosOfFirstMonth As Integer = 100
            '------------------------------------------'

            Dim resourceTree As DataTable = TryCast(SchedulerControl1.Storage.Resources.DataSource, DataTable)
            Dim name As String = ""
            Dim startD As String = ""
            Dim endD As String = ""
            Dim percentOfLOC As String = ""
            Dim recType As String = ""

            For Each resourceRow As DataRow In resourceTree.Rows
                'Note: Start is in index 2, End is 3
                Dim resourceID As String = resourceRow("ResourceID").ToString()
                'LINQ - Query crews if the rank or vessel matched with the selection

                'Dim crew = From c In crewSelected.Rows Where c(IIf(strFilterMode.Equals("Vessel"), "FKeyRank", "FKeyVessel")).ToString().Equals(fkeyRank) And c("RecType").ToString().Equals("Pln") Select c

                Dim hash As DataTable = ConvertToDataTable(ArrangeGraphicalDataForExporting(listOfGraphicalData, resourceID))

                For Each crewRow As DataRow In hash.Rows

                    excelRange = excelSheet.Range(excelSheet.Cells(startRow, startCol), excelSheet.Cells(startRow, startCol))
                    excelRange.Font.Size = 10
                    excelRange.Interior.Color = Color.Aqua
                    DrawCellBorder(excelRange, False)                                                                                   '--> Draw border for the current cell.
                    excelSheet.Cells(startRow, startCol) = resourceRow("Name").ToString()                                                   '--> Rank Name.

                    name = crewRow("Subject").ToString()                                                                                '--> Name of Crew
                    startD = Convert.ToDateTime(crewRow("StartDate").ToString()).ToString("dd-MMM,yyyy")                                          '--> Start Planning Date
                    endD = Convert.ToDateTime(crewRow("EndDate").ToString()).ToString("dd-MMM,yyyy")                                            '--> End Planning Date
                    percentOfLOC = crewRow("Percent").ToString()                                                                        '--> Percentage of the planning
                    Dim startMonth As Single = GetStartPosition(listOfDateRange, Convert.ToDateTime(crewRow("StartDate")))                                                '--> Starting month of the planning for this crew
                    Dim lenOfContract As Single = DateDiff(DateInterval.Month, Convert.ToDateTime(startD), Convert.ToDateTime(endD))    '--> Lenght of contract as defined in planning
                    Dim byPercentage As Single = GetPlanPercentage(lenOfContract, percentOfLOC)                                         '--> Get the appropriate width of shape object to be drawn based on the percentage and loc.
                    Dim remaining As Single = GetPlanPercentage(lenOfContract, (100 - Convert.ToDouble(percentOfLOC)).ToString())       '--> Get the width of shape object for the remaining months to be drawn.

                    If crewRow("recType").ToString().Equals("Pln") Then '--> If the crew is reliever.
                        'Draw bar with color light blue.
                        'Dim img As Excel.Shape = excelSheet.Shapes.AddPicture(ImageCollection.Images(0).ToString(), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, startMonth, barPosY, 5, 5)

                        Dim relieveBar As Excel.Shape = excelSheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle, startMonth, barPosY, lenOfContract * 50, 15)
                        relieveBar.Fill.BackColor.RGB = RGB(0, 191, 255)
                        relieveBar.Fill.ForeColor.RGB = RGB(0, 191, 255)
                        relieveBar.Line.BackColor.RGB = RGB(255, 255, 255)
                        relieveBar.Line.ForeColor.RGB = RGB(255, 255, 255)

                        'gets parentid (crew to relieve)
                        Dim parentId = dtDependencies.Select("DependentId = " & crewRow("id"))

                        'Draw arrow that points to the bar above, from the bar of crew to be relieved, if any.
                        If Not IsNothing(parentId) And parentId.Count > 0 Then
                            Dim relieveTo As Excel.Shape = excelSheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeBentArrow, startMonth - 30, barPosY, 30, 35)
                            relieveTo.Line.BackColor.RGB = RGB(0, 0, 139)
                            relieveTo.Line.ForeColor.RGB = RGB(0, 0, 139)
                            relieveTo.Fill.BackColor.RGB = RGB(127, 255, 212)
                            relieveTo.Fill.ForeColor.RGB = RGB(127, 255, 212)
                            relieveTo.Line.Weight = 0.5
                        End If

                        'Draw textbox, and put it at most in the center of the bar above.
                        DrawIcon(crewRow("CrewID").ToString(), crewRow("ID").ToString(), excelSheet, startMonth, txtBoxPosY + 4, 8, 8)
                        DrawCrewName(name, excelSheet, startMonth, txtBoxPosY, name.Length * 7, 15, percentOfLOC)
                    ElseIf crewRow("recType").ToString().Equals("Onb") Then
                        'Draw bar with color green, for consumed days
                        Dim barStart As Excel.Shape = excelSheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle, startMonth, barPosY, byPercentage * 50, 15)
                        barStart.Fill.BackColor.RGB = RGB(3, 128, 36)
                        barStart.Fill.ForeColor.RGB = RGB(3, 128, 36)
                        barStart.Line.BackColor.RGB = RGB(255, 255, 255)
                        barStart.Line.ForeColor.RGB = RGB(255, 255, 255)
                        'Draw bar with color beige for remaining days
                        Dim barEnd As Excel.Shape = excelSheet.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeRectangle, (byPercentage * 50) + startMonth, barPosY, (remaining * 46), 15)
                        barEnd.Fill.BackColor.RGB = RGB(255, 222, 173)
                        barEnd.Fill.ForeColor.RGB = RGB(255, 222, 173)
                        barEnd.Line.BackColor.RGB = RGB(255, 255, 255)
                        barEnd.Line.ForeColor.RGB = RGB(255, 255, 255)

                        Dim textLocation As Single = AdjustTextLocation(startMonth, byPercentage, remaining) '--> Compute the middle of barStart and barEnd. 
                        'Draw the textbox in the middle of barStart and barEnd
                        DrawIcon(crewRow("CrewID").ToString(), crewRow("ID").ToString(), excelSheet, textLocation + 30, txtBoxPosY + 4, 8, 8)
                        DrawCrewName(name, excelSheet, textLocation, txtBoxPosY, name.Length * 10, 15, percentOfLOC)
                    End If
                    '--> Adjust the locations of bars and textbox accordingly. 
                    startRow = startRow + 1
                    txtBoxPosY = txtBoxPosY + 31.5
                    barPosY = barPosY + 31.5
                Next
                recType = ""
            Next
            excelRange = excelSheet.Range(excelSheet.Cells(startRow + 1, startCol), excelSheet.Cells(startRow + 1, startCol))
            excelRange.HorizontalAlignment = Excel.Constants.xlLeft
            excelRange.VerticalAlignment = Excel.Constants.xlCenter
            excelRange.Font.Size = 10
            excelSheet.Cells(startRow + 1, startCol) = "Date Generated : " & Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd-MMM-yyyy")
            excelWBk.SaveAs(fileName)
            GC.Collect()
        Catch ex As System.Exception
            CloseCustomLoadScreen()
            MessageBox.Show("The exporting process has been interrupted. Please provide a proper file name and then run again the export. " & ex.Message, "Export Graphical Planning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End Try

        CloseCustomLoadScreen()
        MessageBox.Show("Exporting process done! The file is saved on " & fileName, "Export Graphical Planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
        excelApp.Visible = True

    End Sub

    'Private Sub DrawIcon(id As String, ByRef sheet As Excel.Worksheet, left As Single, top As Single, w As Single, h As Single)
    '    Dim index As Integer = -1
    '    Dim imageName As String = ""

    '    Try

    '        If _currentCrewIDs.Count > 0 Then

    '            For Each row As String In _currentCrewIDs
    '                If id.Equals(row.Split("-")(0).ToString()) Then
    '                    Dim lackingResult As String = row.Split("-")(1).ToString()
    '                    If lackingResult.Equals("1") Then       'Lacking (x)
    '                        imageName = "Lacking.png"
    '                    ElseIf lackingResult.Equals("2") Then   'Has document but will expire within the contract (/!\)
    '                        imageName = "toexpire.png"
    '                    ElseIf lackingResult.Equals("3") Then   'Has document but will expire within contract (optional) (!)
    '                        imageName = "optional.png"
    '                    End If
    '                End If
    '            Next
    '        End If

    '        If Not imageName.Trim().Equals("") Then
    '            Dim fileName As String = Application.StartupPath & "\Resources\Icons\" & imageName & ""
    '            'Dim img As Image = Image.FromFile(Application.StartupPath & "\Resources\Icons\" & imageName & "")
    '            Dim icon As Excel.Shape = sheet.Shapes.AddPicture(fileName, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, left, top, w, h)
    '        End If
    '    Catch ex As System.Exception
    '        Return
    '    End Try


    'End Sub

    Private Sub DrawIcon(CrewID As String, AppointmentID As Integer, ByRef sheet As Excel.Worksheet, left As Single, top As Single, w As Single, h As Single)
        Dim index As Integer = -1
        Dim imageName As String = ""

        Try

            If _listOfCrewIDs.Count > 0 Then

                For Each row In _listOfCrewIDs
                    If CrewID.Equals(row.CrewID.ToString()) Then
                        Dim lackingResult As String = row.LackingResult.ToString()
                        If lackingResult.Equals("1") Then       'Lacking (x)
                            imageName = "Lacking.png"
                        ElseIf lackingResult.Equals("2") Then   'Has document but will expire within the contract (/!\)
                            imageName = "toexpire.png"
                        ElseIf lackingResult.Equals("3") Then   'Has document but will expire within contract (optional) (!)
                            imageName = "optional.png"
                        End If
                    End If
                Next
            End If

            If Not imageName.Trim().Equals("") Then
                Dim fileName As String = Application.StartupPath & "\Resources\Icons\" & imageName & ""
                'Dim img As Image = Image.FromFile(Application.StartupPath & "\Resources\Icons\" & imageName & "")
                Dim icon As Excel.Shape = sheet.Shapes.AddPicture(fileName, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, left, top, w, h)
            End If
        Catch ex As System.Exception
            Return
        End Try


    End Sub

    'This method will receive a list with a specified user-defined types (T) and convert it to DataTable. (HashSet version)
    Public Function ConvertToDataTable(Of T)(ByVal list As HashSet(Of T)) As DataTable
        Dim table As New DataTable()
        'Identify columns and fields
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

    Private Sub PopulateGraphicalData(ByVal data As DataTable)

        listOfGraphicalData.Clear()
        Try
            Dim table As DataTable = data
            For Each row As DataRow In table.Rows
                Dim graphData As New GraphicalData
                graphData.Id = Convert.ToInt32(row("Id"))
                graphData.PKey = row("PKey").ToString()
                graphData.StartDate = Convert.ToDateTime(row("Start").ToString())
                graphData.EndDate = Convert.ToDateTime(row("End").ToString())
                graphData.Location = row("Location").ToString()
                graphData.FKeyRank = row("FKeyRank").ToString()
                graphData.Subject = row("Subject").ToString()
                graphData.Percent = Convert.ToInt32(row("Percent").ToString())
                graphData.FKeyVesel = row("FKeyVessel").ToString()
                graphData.FKeyWScaleRank = row("FKeyWScaleRank").ToString()
                graphData.LOC = Convert.ToInt32(row("LOC").ToString())
                graphData.LocDays = Convert.ToInt32(row("LOCDays").ToString())
                graphData.CrewID = row("CrewID").ToString()
                graphData.Remarks = row("Remarks").ToString()
                graphData.RecType = row("RecType").ToString()
                graphData.PlanningEvent = row("PlanningEvent").ToString()
                graphData.ResourceID = row("ResourceID").ToString()
                listOfGraphicalData.Add(graphData)
            Next
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Function SortDataTable(table As DataTable, ParamArray columns As String()) As DataTable
        If columns.Length = 0 Then
            Return table
        End If

        Dim firstColumn = columns.First()
        Dim result = table.AsEnumerable().OrderBy(Function(r) r(firstColumn))

        For Each columnName As String In columns.Skip(1)
            Dim col = columnName
            result = result.ThenBy(Function(r) r(col))
        Next

        Return result.AsDataView().Table()

    End Function


    Private Sub DrawCrewName(crewName As String, ByRef excelSheet As Excel.Worksheet, left As Single, top As Single, width As Single, height As Single, percent As Single)
        Dim shape As Excel.Shape = excelSheet.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, left, top, width, height) '--> Excel Textbox
        shape.TextFrame.Characters.Text = crewName & " - " & percent & "%"
        shape.TextEffect.Alignment = Microsoft.Office.Core.MsoTextEffectAlignment.msoTextEffectAlignmentCentered
        shape.TextEffect.FontSize = 9
        shape.TextEffect.FontName = "Tahoma"
        shape.Fill.Transparency = 1
        shape.Line.Visible = False
    End Sub

    Private Sub MergeYears(columnsToMerge As List(Of String), ByRef excelSheet As Excel.Worksheet)
        Dim nRow As Integer = 4         '--> Starting row.
        Dim prevEndCol As Integer = 0   '--> This value will hold the previous month to monitor where the year has changed.
        For i As Integer = 0 To columnsToMerge.Count - 1
            Dim items As String() = columnsToMerge(i).Split(",")
            Dim endCol As Integer = Convert.ToInt32(items(0).ToString())
            Dim noOfCol As Integer = Convert.ToInt32(items(1).ToString())

            If (i = 0) Then 'If starting year. 
                excelSheet.Range(excelSheet.Cells(nRow, 3), excelSheet.Cells(nRow, endCol)).Merge() '--> Get the last cell based on the number of months in columnsToMerge list. 
                excelSheet.Range(excelSheet.Cells(nRow, endCol), excelSheet.Cells(nRow, noOfCol + endCol - 1)).HorizontalAlignment = Excel.Constants.xlCenter
                excelSheet.Range(excelSheet.Cells(nRow, endCol), excelSheet.Cells(nRow, noOfCol + endCol - 1)).Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            Else
                excelSheet.Range(excelSheet.Cells(nRow, prevEndCol + 1), excelSheet.Cells(nRow, endCol)).Merge() '--> Merged from the last cell that has changed the year + 1, until the last column. 
                excelSheet.Range(excelSheet.Cells(nRow, prevEndCol + 1), excelSheet.Cells(nRow, endCol)).HorizontalAlignment = Excel.Constants.xlCenter
                excelSheet.Range(excelSheet.Cells(nRow, prevEndCol + 1), excelSheet.Cells(nRow, endCol)).Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            End If
            prevEndCol = endCol
        Next
        'TODO#1
    End Sub

    Private Function AdjustTextLocation(startPos As Single, percentage As Single, remaining As Single) As Single
        Dim retVal As Single = 0
        Try
            'Compute the middle between a green bar and beige bar (consumed time and future time)
            retVal = (((percentage * 50) + (remaining * 46)) + startPos) \ 2
            'if the middle is less than the starting position of green bar. 
            If (retVal < startPos) Then
                retVal = retVal + 150   'Add an additional padding of 150.
            End If
            Return retVal
        Catch ex As System.Exception
            Return retVal 'Otherwise, just return 0.
        End Try
    End Function


    Private Function GetStartPosition(dateRange As List(Of String), dDate As String) As Integer
        Dim retVal As Integer = 0
        Dim counter As Integer = 1
        For Each d As String In dateRange
            counter = counter + 1                                        '--> This will serve as the counter for each month within the dateRange.
            If (d.Equals(dDate.Substring(dDate.IndexOf("-") + 1))) Then  '--> Look for the month that matched with the month of dDate parameter.
                retVal = Convert.ToInt32(dDate.Split("-")(0).ToString()) '--> Get the day under that month, and use it as an approximation for each of the cell width. 
                Exit For '--> We found it! Stop now.
            End If
        Next
        Return (counter * 50) + retVal     '--> I use 50 for approximation of the cell width, multiply by how many months(counter), plus the day captured (retVal) in the given starting dDate.
    End Function

    Private Function GetStartPosition(dateRange As List(Of String), dDate As Date) As Integer
        Dim retVal As Integer = 0
        Dim counter As Integer = 1
        Dim strDate As String = Convert.ToDateTime(dDate.ToString()).ToString("dd-MMM,yyyy")

        If Not IfNull(strDate, "").Equals("") Then
            For Each d As String In dateRange
                counter = counter + 1                                        '--> This will serve as the counter for each month within the dateRange.
                If (d.Equals(strDate.Substring(strDate.IndexOf("-") + 1))) Then  '--> Look for the month that matched with the month of dDate parameter.
                    retVal = Convert.ToInt32(strDate.Split("-")(0).ToString()) '--> Get the day under that month, and use it as an approximation for each of the cell width. 
                    Exit For '--> We found it! Stop now.
                End If
            Next
        End If

        'Return (counter * 50) + retVal     '--> I use 50 for approximation of the cell width, multiply by how many months(counter), plus the day captured (retVal) in the given starting dDate.
        'Return (counter * 48) + ((48 / DateTime.DaysInMonth(dDate.Year, dDate.Month)) * retVal)     '--> I use 50 for approximation of the cell width, multiply by how many months(counter), plus the day captured (retVal) in the given starting dDate.
        Return (counter * ExcelColumnWidthPixel) + ((ExcelColumnWidthPixel / DateTime.DaysInMonth(dDate.Year, dDate.Month)) * retVal)     '--> I use 50 for approximation of the cell width, multiply by how many months(counter), plus the day captured (retVal) in the given starting dDate.
    End Function

    Private Function HasExcelInstalled() As Boolean
        'Check the RegKey if there is an Excel application.
        Try
            Return IIf(Registry.ClassesRoot.OpenSubKey(name:="\Excel.Application\CurVer", writable:=False) Is Nothing, False, True)
        Catch ex As System.Exception
            Return False
        End Try

    End Function

    Private Function GetPlanPercentage(len As Integer, percentage As String) As Double
        Try
            'Get the planning percentage left. 
            'If percentage is 100%, just return the LOC, otherwise, compute the remaining percentage based on the LOC. 
            Return IIf(percentage.Equals("100"), len, len * Convert.ToDouble(IIf(percentage.Length = 1, "0.0" & percentage, "0." & percentage)))
        Catch ex As System.Exception
            Return 1
        End Try
    End Function

    Private Function TruncateName(selectedName As String) As String
        'This function will truncate the sheet name to 30, since the maximum name character is 30
        Dim nameLen As Integer = selectedName.Trim().Length
        Try
            If nameLen > 30 Then
                Return selectedName.Substring(0, 29)
            Else
                Return selectedName
            End If
        Catch ex As System.Exception
            Return selectedName
        End Try

    End Function

#End Region

#Region "PopUp Crew Details"

    Private Sub SchedulerControl1_Click(sender As Object, e As System.EventArgs) Handles SchedulerControl1.Click
        SchedulerControlClicked()
    End Sub

    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub SchedulerControl1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles SchedulerControl1.MouseMove
        Debug.Print(Format(DateTime.Now, "hh:mm:ss") & " - Mouse Move")
        Dim mousePoint As Point = Control.MousePosition
        Dim pos As New Point(e.X, e.Y)
        Dim viewInfo As SchedulerViewInfoBase = SchedulerControl1.ActiveView.ViewInfo
        Dim hitInfo As SchedulerHitInfo = viewInfo.CalcHitInfo(pos, False)
        _controlMousePoint = pos

        '<!-- tony20171228 - removed and transferred to right click menu
        'Dim tmr As New Stopwatch
        'tmr.Start()
        'Do
        '    tmr.Stop()
        '    If tmr.ElapsedMilliseconds >= 400 Then
        '        tmr.Reset()

        '        If hitInfo.HitTest = SchedulerHitTest.AppointmentContent And e.Button <> Windows.Forms.MouseButtons.Left And e.Button <> Windows.Forms.MouseButtons.Right Then
        '            If Not isAppointmentClicked And Not isRightClicked Then  'tony20170930: Changed OR to AND
        '                Dim apt As DevExpress.XtraScheduler.Appointment = CType(hitInfo.ViewInfo, DevExpress.XtraScheduler.Drawing.TimeLineAppointmentViewInfo).Appointment
        '                If Not _popupDetail.IsEqual(apt.CustomFields("CrewID").ToString, CLng(IfNull(apt.Id, -1))) Or (Not frmPopUp.Visible And Not isRightClicked) Then

        '                    SchedulerControl1.SelectedAppointments.Clear()
        '                    SchedulerControl1.SelectedAppointments.Add(apt)
        '                    Application.DoEvents()
        '                    ShowPopUpCrewData(apt, Control.MousePosition)
        '                    Application.DoEvents()
        '                End If

        '            Else
        '                frmPopUp.Hide()
        '                Application.DoEvents()
        '            End If

        '        End If

        '        Exit Do
        '    Else
        '        tmr.Start()
        '        Application.DoEvents()
        '    End If
        'Loop While mousePoint = Control.MousePosition
        '-->

        If hitInfo.HitTest <> SchedulerHitTest.AppointmentContent Then
            isRightClicked = False
        End If

here:
        'isRightClicked = False

        If isCopying Or IsNothing(copiedApt) = False Then
            Dim focusedDate As Date = CType(hitInfo.ViewInfo, SelectableIntervalViewInfo).Interval.Start

            If hitInfo.HitTest = SchedulerHitTest.AppointmentContent Then
                Dim apt As Appointment = CType(hitInfo.ViewInfo, AppointmentViewInfo).Appointment
                strResourceId = apt.ResourceId
                If strFilterMode = "Vessel" Then
                    strCurrentRank = apt.CustomFields("FKeyRank")
                Else
                    strCurrentVsl = apt.CustomFields("FKeyVessel")
                End If
                If IsNothing(copiedApt) = False Then copiedApt.Start = apt.End Else copyAptData.Start = apt.End
                If IsNothing(copiedApt) = False Then copiedApt.ResourceId = strResourceId Else copyAptData.ResourceId = strResourceId
            ElseIf (hitInfo.ViewInfo.HitTestType = SchedulerHitTest.Cell) Then
                strResourceId = hitInfo.ViewInfo.Resource.Id

                Dim dt As DataTable = CType(SchedulerStorage1.Resources.DataSource, DataTable).Copy
                Dim dr As DataRow = dt.Select("ResourceID='" & strResourceId & "'")(0)

                If strFilterMode = "Vessel" Then
                    strCurrentRank = dr("AdmPKey").ToString
                Else
                    strCurrentVsl = dr("AdmPKey").ToString
                End If

                If IsNothing(copiedApt) = False Then copiedApt.Start = hitInfo.ViewInfo.Interval.Start Else copyAptData.Start = hitInfo.ViewInfo.Interval.Start
                If IsNothing(copiedApt) = False Then copiedApt.ResourceId = strResourceId Else copyAptData.ResourceId = strResourceId
            End If
        End If

    End Sub

    Private Sub ShowPopUpCrewData(apt As DevExpress.XtraScheduler.Appointment, controlMousePointer As Point)
        clearDataFields()
        If Not IfNull(_popupDetail.CrewID.ToString, "").Equals(IfNull(apt.CustomFields("CrewID"), "")) Or _
            Not CLng(IfNull(_popupDetail.AppointmentID, -1)).Equals(CLng(IfNull(apt.Id, -1))) Then
            _popupDetail.CrewID = apt.CustomFields("CrewID")
            _popupDetail.AppointmentID = CLng(IfNull(apt.Id, -1))
            'fopMain.HidePopup(True)
            frmPopUp.Hide()
        End If

        SupplyDataToControls(apt)
        ConfigureView()

        'If Not fopMain.IsPopupOpen Then
        If Not frmPopUp.Visible Then
            frmPopUp.Show(Me)
            frmPopUp.picCrewPHoto.Focus()
            'commented out by tony20171228. center popup form instead of based on mouse location
            'frmPopUp.Location = PopUpLocation(controlMousePointer)
        End If
    End Sub

    Private Sub SchedulerControl1_AppointmentViewInfoCustomizing(sender As System.Object, e As DevExpress.XtraScheduler.AppointmentViewInfoCustomizingEventArgs) Handles SchedulerControl1.AppointmentViewInfoCustomizing
        'Dim loc As Integer = computeLOC(e.ViewInfo.Appointment.Start, e.ViewInfo.Appointment.End, "LOC")
        'Dim locDays As Integer = computeLOC(e.ViewInfo.Appointment.Start, e.ViewInfo.Appointment.End, "LOCDays")
        'e.ViewInfo.ToolTipText = loc & " Month/s " & locDays & " Day/s from " & Format(e.ViewInfo.Appointment.Start, "dd-MMM-yyyy") & " to " & Format(e.ViewInfo.Appointment.End, "dd-MMM-yyyy")
    End Sub

    Private Function PopUpLocation(controlMousePointer As Point) As Point
        Dim point As Point
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim mainCtrl_W As Integer = Me.ParentForm.Width
        Dim mainCtrl_H As Integer = Me.ParentForm.Height
        Dim ctrl_W As Integer = frmPopUp.Width
        Dim ctrl_H As Integer = frmPopUp.Height
        Dim ident As Integer = 10

        If controlMousePointer.X >= ctrl_W Then 'available space in left
            x = controlMousePointer.X - ctrl_W
        Else
            If mainCtrl_W - controlMousePointer.X < ctrl_W Then
                x = mainCtrl_W - ctrl_W 'show whole in right
            Else
                x = controlMousePointer.X + ident 'default
            End If
        End If

        If controlMousePointer.Y >= ctrl_H Then 'available space at top
            y = controlMousePointer.Y - ctrl_H
        Else
            If mainCtrl_H - controlMousePointer.Y < ctrl_H Then
                y = mainCtrl_H - ctrl_H 'show whole at bottom
            Else
                y = controlMousePointer.Y + ident 'default
            End If
        End If

        point = New Point(x, y)
        Return point
    End Function

    Private Sub frmPopUpCrew_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs)
        'If e.CloseReason = CloseReason.UserClosing Then 'neil
        'clearDataFields()
        e.Cancel = True
        sender.Hide()
        'End If
    End Sub

    Dim compGrid_H As Integer
    Private Sub locMain_GroupExpandChanged(sender As System.Object, e As DevExpress.XtraLayout.Utils.LayoutGroupEventArgs)
        Dim var_H As Integer
        With frmPopUp
            If Not .CompGridGroup.Expanded Then
                var_H = -1 * compGrid_H
            Else
                var_H = compGrid_H
                If IsNothing(.CompetenceDocsGrid.DataSource) Then
                    If SchedulerControl1.SelectedAppointments.Count > 0 Then
                        Dim aApt As Appointment = SchedulerControl1.SelectedAppointments(0)
                        Dim query As String = "SELECT * FROM Checklist('" & aApt.CustomFields("CrewID") & "'," & _
                                                                                        "'" & aApt.CustomFields("FKeyRank") & "'," & _
                                                                                        "'" & DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey ='" & aApt.CustomFields("FKeyVessel") & "'") & "'," & _
                                                                                        "" & computeLOC(aApt.Start, aApt.End, "LOC") & "," & _
                                                                                        "'" & aApt.Start.ToString("dd-MMM-yyyy") & "')" &
                                                                                        "  WHERE DocStatus NOT IN ('','InOrder')"
                        Dim data As DataTable = DB.CreateTable(query)
                        .CompetenceDocsGrid.DataSource = data
                    End If
                End If
            End If

            .Height += var_H
        End With
    End Sub

    Private Sub frmPopUpCrew_Resize(sender As System.Object, e As System.EventArgs)
        If Not frmPopUp.CompGridGroup.IsHidden Then
            compGrid_H = frmPopUp.CompetenceDocsGrid.Height
        End If
        With frmPopUp
            If Not .CompGridGroup.Expanded Then
                .FormBorderStyle = FormBorderStyle.FixedSingle
            Else
                .FormBorderStyle = FormBorderStyle.Sizable
            End If
        End With
    End Sub

#End Region

#Region "Popup Menu Events"

    Public Sub PopUpMenuCloseUp(sender As Object, e As System.EventArgs) Handles popUpMenu.CloseUp
        isRightClicked = False
    End Sub

#End Region

    Private Sub SupplyDataToControls(ByVal apt As DevExpress.XtraScheduler.Appointment)
        With frmPopUp
            Dim aApt As Appointment
            aApt = apt
            Dim photoPath As String = FOLDERDIRECTORY & "\" & aApt.CustomFields("CrewID") & "\" & aApt.CustomFields("PhotoPath")

            isSupplying = True
            .picCrewPHoto.Image = ImageFromStream(photoPath)
            .txtCrewName.EditValue = aApt.Subject & " - Id: " & aApt.Id
            .deStartDate.EditValue = aApt.Start
            .deEndDate.EditValue = aApt.End
            .lueRank.EditValue = aApt.CustomFields("FKeyRank")
            .lueVessel.EditValue = aApt.CustomFields("FKeyVessel")
            .lueWScale.EditValue = aApt.CustomFields("FKeyWScaleRank")
            .txtLOC.EditValue = computeLOC(aApt.Start, aApt.End, "LOC") 'SchedulerControl1.SelectedAppointments(0).CustomFields("LOC")
            .txtLOCDays.EditValue = computeLOC(aApt.Start, aApt.End, "LOCDays") 'SchedulerControl1.SelectedAppointments(0).CustomFields("LOCDays")
            .txtRemarks.EditValue = aApt.CustomFields("Remarks")
            .txtCompID.EditValue = aApt.CustomFields("CompID")
            If Not IsDBNull(aApt.CustomFields("DOB")) Then
                .txtDOB.EditValue = Format(CDate(aApt.CustomFields("DOB")), "dd-MMM-yyyy")
                .txtAge.EditValue = GetAge(CDate(aApt.CustomFields("DOB")))
            Else
                .txtDOB.EditValue = ""
                .txtAge.EditValue = ""
            End If
            .txtReligion.EditValue = aApt.CustomFields("Religion")
            .txtAgent.EditValue = aApt.CustomFields("AgentName")
            .txtValidationMsg.Text = ""
            .txtValidationMsg2.Text = ""
            '<!-- uncommented out by tony20170911: the overlapping activity check should initialize every time the crew popup details is opened up
            If SchedulerControl1.SelectedAppointments(0).LabelId <> LabelID.Onboard Then
                isOverlapping(SchedulerControl1.SelectedAppointments(0).CustomFields("CrewID"), SchedulerControl1.SelectedAppointments(0).Start, SchedulerControl1.SelectedAppointments(0).End, SchedulerControl1.SelectedAppointments(0).Subject, SchedulerControl1.SelectedAppointments(0).CustomFields("PKey"), SchedulerControl1.SelectedAppointments(0).Id)
            End If
            '-->
            If aApt.LabelId = LabelID.Onboard Then
                .Text = "Onboard Activity Details"
            Else
                .Text = "Planning Event : " & aApt.CustomFields("PlanningEvent")
            End If
            'isParentEndDateOverlapsWithDependentStartDate()
            .SimpleLabelItem1.Text = .txtLOC.EditValue & " Month/s " & .txtLOCDays.EditValue & " Day/s from " & .deStartDate.Text & " to " & .deEndDate.Text
            ''START - Checking of Competence Template'
            If .CompGridGroup.Expanded Then
                Dim query As String = "SELECT * FROM Checklist('" & aApt.CustomFields("CrewID") & "'," & _
                                                                                "'" & aApt.CustomFields("FKeyRank") & "'," & _
                                                                                "'" & DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey ='" & aApt.CustomFields("FKeyVessel") & "'") & "'," & _
                                                                                "" & computeLOC(aApt.Start, aApt.End, "LOC") & "," & _
                                                                                "'" & aApt.Start.ToString("dd-MMM-yyyy") & "')" &
                                                                                "  WHERE DocStatus NOT IN ('','InOrder')"
                Dim data As DataTable = DB.CreateTable(query)
                .CompetenceDocsGrid.DataSource = data
            Else
                .CompetenceDocsGrid.DataSource = Nothing
            End If
            isSupplying = False
        End With

        If isEditdable = True Then
            If apt.LabelId = LabelID.Onboard Then
                disableLTPFields(True)
            Else
                disableLTPFields(False)
            End If
        End If
    End Sub

    Private Sub ConfigureView()
        'Group the competence by Document Type
        With frmPopUp.CompetenceDocsView
            .BeginSort()
            Try
                .ClearGrouping()
                .Columns("DocType").GroupIndex = 0
                .Columns("Sorting").SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
                .Columns("Sorting").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Finally
                .EndSort()
            End Try
        End With
    End Sub

    'This function will arrange/sort the crew records accordingly, based on the Onboard->Reliever heirarchy. 
    Public Function ArrangeGraphicalDataForExporting(ByRef listofGraphData As HashSet(Of GraphicalData), resourceID As String) As HashSet(Of GraphicalData)

        Try
            Dim returnValue As New HashSet(Of GraphicalData)
            'Get the crew with this rank (fkeyRank)
            Dim list = From g In listofGraphData
                       Where g.ResourceID.Equals(resourceID)
                       Select g

            For Each record In list
                Dim id As String = record.Id
                If record.RecType.Equals("Pln") Then                                'If is it planned (a reliever) 
                    Dim parentId = dtDependencies.Select("DependentId = " & id)     'Check the crew to be relieved id.
                    If Not IsNothing(parentId) And parentId.Count > 0 Then          'Arrange accordingly. 
                        If Not IsAlreadyInList(returnValue, id) And Not IsAlreadyInList(returnValue, parentId(0).Item("Id").ToString()) Then
                            returnValue.Add(GetGraphicalData(id))
                            returnValue.Add(GetGraphicalData(parentId(0).Item("ParentId").ToString()))
                        End If
                    Else
                        returnValue.Add(GetGraphicalData(id))
                    End If
                ElseIf record.RecType.Equals("Onb") Then
                    Dim dependentId = dtDependencies.Select("ParentId = " & id)
                    If Not IsNothing(dependentId) And dependentId.Count > 0 Then
                        If Not IsAlreadyInList(returnValue, id) And Not IsAlreadyInList(returnValue, dependentId(0).Item("Id").ToString()) Then
                            returnValue.Add(GetGraphicalData(dependentId(0).Item("DependentId").ToString()))
                            returnValue.Add(GetGraphicalData(id))
                        End If
                    Else
                        returnValue.Add(GetGraphicalData(id))       'If the onboard crew does not have a reliever.
                    End If
                End If
            Next

            If returnValue.Count > 0 Then
                returnValue = RemoveEmptyData(returnValue)
            End If

            Return returnValue
        Catch ex As System.Exception
            MessageBox.Show(ex.Message)
        End Try

        Return Nothing

    End Function

    Public Function RemoveEmptyData(data As HashSet(Of GraphicalData)) As HashSet(Of GraphicalData)
        Dim retVal As New HashSet(Of GraphicalData)
        For Each d In data
            If d.Id <> 0 Then
                retVal.Add(d)
            End If
        Next
        Return retVal
    End Function

    Public Function IsAlreadyInList(data As HashSet(Of GraphicalData), id As Integer) As Boolean
        'Checking of data if id is already in the list.
        Dim list = From d In data
                   Where d.Id = id
                   Select d

        If IsNothing(list) Or list.Count = 0 Then
            Return False
        End If
        Return True
    End Function

    Public Function GetGraphicalData(id As String) As GraphicalData

        For Each graphData As GraphicalData In listOfGraphicalData
            If graphData.Id = id Then
                Return graphData    'Get GraphicalData object.
            End If
        Next
        Return Nothing
    End Function

    Private Sub LTP_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        frmPopUp.Dispose()
    End Sub

    Private Sub LTP_Leave(sender As System.Object, e As System.EventArgs) Handles MyBase.Leave
        frmPopUp.Hide()
    End Sub

    Private Function ConstructResourceDT(dtAppointments As DataTable) As DataTable
        Dim dtRetVal As DataTable
        dtRetVal = dtAppointments.Copy
        dtRetVal.Columns.Add(New DataColumn("ResourceID", System.Type.GetType("System.String")))
        dtRetVal.Columns.Add(New DataColumn("DateSOn", System.Type.GetType("System.DateTime")))
        dtRetVal.Columns.Add(New DataColumn("DateDue", System.Type.GetType("System.DateTime")))

        Dim CrewAct As String = ""
        Dim CrewToRelieveAct As String = ""
        Try
            For cntMain As Integer = 0 To dtRetVal.Rows.Count - 1
                CrewAct = dtRetVal(cntMain)("PKey").ToString
                CrewToRelieveAct = dtRetVal(cntMain)("CrewToRelieve").ToString

                If CrewToRelieveAct.Length = 0 Then 'primary appointment
                    If CrewAct.Length = 0 Then
                        dtRetVal(cntMain)("ResourceID") = cntMain.ToString
                    Else
                        dtRetVal(cntMain)("ResourceID") = CrewAct
                    End If

                Else 'not primary appointment
                    dtRetVal(cntMain)("ResourceID") = GetPrimaryResourceID(dtRetVal, CrewAct, CrewToRelieveAct)

                End If

                Dim row As DataRow() = dtRetVal.Select("PKey='" & dtRetVal(cntMain)("ResourceID") & "'")

                If row.Count > 0 Then
                    dtRetVal(cntMain)("DateSOn") = row(0)("Start")
                    dtRetVal(cntMain)("DateDue") = row(0)("End")

                End If
            Next
        Catch ex As System.Exception

        End Try

        Return dtRetVal
    End Function

    Private Function GetPrimaryResourceID(dtAppointments As DataTable, CrewAct As String, CrewToRelieveAct As String) As String
        Dim retVal As String = ""
        Dim ToRelieveAct As String = ""
        Dim foundRow As DataRow() = Nothing

        foundRow = dtAppointments.Select("PKey='" & CrewToRelieveAct & "'")

        If foundRow.Count <> 0 Then
            ToRelieveAct = foundRow(0).Item("CrewToRelieve").ToString

            If ToRelieveAct.Length <> 0 Then
                retVal = GetPrimaryResourceID(dtAppointments, CrewAct, ToRelieveAct)
            Else
                retVal = CrewToRelieveAct
            End If
        Else
            retVal = CrewAct
        End If

        Return retVal
    End Function

    Private Sub SchedulerControl1_MouseLeave(sender As Object, e As System.EventArgs) Handles SchedulerControl1.MouseLeave
        SchedulerControl1.LimitInterval = New TimeInterval(_START, _END)
    End Sub

    Private Sub SchedulerControl1_LostFocus(sender As Object, e As System.EventArgs) Handles SchedulerControl1.LostFocus
        SchedulerControl1.LimitInterval = New TimeInterval(_START, _END)
    End Sub

    Private Sub UpdateCrewApts(aptID As String, crewID As String)
        'Application.DoEvents()
        'Dim dtAllApts As DataTable = SchedulerControl1.Storage.Appointments.DataSource
        'Dim drCrewApts As DataRow() = dtAllApts.Select("CrewID = '" & crewID & "'")
        'Dim dtCrewApts As DataTable = drCrewApts.CopyToDataTable
        'Dim apt As New Appointment
        'Dim Id As Object

        'If dtCrewApts.Rows.Count <= 0 Then Exit Sub
        'Application.DoEvents()
        'For cnt As Integer = 0 To dtCrewApts.Rows.Count - 1
        '    Id = dtCrewApts(cnt)("Id")
        '    apt = SchedulerControl1.Storage.Appointments.GetAppointmentById(Id)
        '    If isOverlapping(apt.CustomFields("CrewID"), apt.Start, apt.End, apt.Subject, apt.CustomFields("PKey"), apt.Id, False) Then
        '        If apt.Id = aptID Then
        '            apt.LabelId = LabelID.WithError
        '        End If
        '    Else
        '        If apt.Id = aptID Or apt.LabelId = LabelID.WithError Then
        '            apt.LabelId = LabelID.Edited
        '        End If
        '    End If
        'Next

        For Each apt As Appointment In SchedulerControl1.Storage.Appointments.Items
            If crewID = IfNull(apt.CustomFields("CrewID"), "") Then
                If isOverlapping(apt.CustomFields("CrewID"), apt.Start, apt.End, apt.Subject, apt.CustomFields("PKey"), apt.Id, False) Then
                    If apt.Id = aptID Then
                        apt.LabelId = LabelID.WithError
                    End If
                Else
                    If apt.Id = aptID Or apt.LabelId = LabelID.WithError Then
                        apt.LabelId = LabelID.Edited
                    End If
                End If
            End If
        Next

    End Sub

    Public Overrides Function LTPShowVesselRankSelection(cMode As String) As Boolean
        'Dim currSelectionCriteria As SelectionCriteria
        Dim cCondition As String = ""

        InitializeSelectionForm(cMode)

        SelectionForm.ShowDialog()

        Return SelectionForm.ApplyFilter

        'With SelectionForm
        '    Select Case cMode
        '        Case "Vessel"
        '            .CurrentSelection = frmVesselRankSelection.SelectionMode.Vessel
        '            '.RefreshForm()
        '            .ShowDialog()

        '            Return .ApplyFilter

        '        Case "Rank"
        '            .CurrentSelection = frmVesselRankSelection.SelectionMode.Rank
        '            '.RefreshForm()
        '            .ShowDialog()
        '            Return .ApplyFilter

        '        Case Else
        '            .LoadData(frmSelection.SelectionMode.None)
        '            Return False
        '    End Select


        'cCondition = SelectionForm.Condition
        'currSelectionCriteria = ListOfSelectionCriteria.Find(Function(o As SelectionCriteria) o.Mode = cMode)
        'If IsNothing(currSelectionCriteria) Then
        '    currSelectionCriteria = New SelectionCriteria
        '    currSelectionCriteria.Mode = cMode
        '    currSelectionCriteria.Condition = cCondition

        '    ListOfSelectionCriteria.Add(currSelectionCriteria)

        'Else
        '    currSelectionCriteria.Condition = cCondition
        'End If


        'End With

    End Function


    'Private Function LTPGetVesselRankSelectionCriteria(cMode As String) As String
    '    'Try
    '    '    Dim currSelectionCriteria As SelectionCriteria
    '    '    currSelectionCriteria = ListOfSelectionCriteria.Find(Function(o As SelectionCriteria) o.Mode = cMode)

    '    '    If IsNothing(currSelectionCriteria) Then
    '    '        Return ""
    '    '    Else
    '    '        Return currSelectionCriteria.Condition
    '    '    End If
    '    'Catch ex As System.Exception
    '    '    Return ""
    '    'End Try
    '    Return SelectionForm.Condition


    'End Function

#Region "Scroll Events/Service"
    Public Class MyMouseHandlerService
        Inherits DevExpress.Services.MouseHandlerServiceWrapper
        Private provider As IServiceProvider

        Public Sub New(ByVal provider As IServiceProvider, ByVal service As DevExpress.Services.IMouseHandlerService)
            MyBase.New(service)
            Me.provider = provider
        End Sub

        Public Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
            If TypeOf provider Is SchedulerControl Then
                Dim scheduler As SchedulerControl = CType(provider, SchedulerControl)
                If scheduler.ActiveViewType = SchedulerViewType.Timeline Then
                    If scheduler.Services.ResourceNavigation Is Nothing Then
                        MyBase.OnMouseWheel(e)
                        Return
                    End If

                    If e.Delta > 0 Then
                        scheduler.Services.ResourceNavigation.NavigateBackward()
                    Else
                        scheduler.Services.ResourceNavigation.NavigateForward()
                    End If
                Else
                    If System.Windows.Forms.Control.ModifierKeys <> Keys.Control Then
                        MyBase.OnMouseWheel(e)
                    End If
                End If
            End If
        End Sub
        ' MyBase.OnMouseWheel(e)
    End Class

#End Region

End Class
