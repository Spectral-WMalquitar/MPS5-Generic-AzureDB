Option Explicit On

Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports System.Diagnostics
Imports System.Drawing
Imports BaseControl
Imports Planning.PlanningList
Imports Crewing
Imports DevExpress.XtraSplashScreen
Imports System.Reflection

Public Class PlanChecklist

#Region "Structures"

    Private Structure MainCompetence
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
        Public VslType As String
        Public RankName As String
        Public YrOfService As String
        Public TotalYrsOfService As String
        Public Complied As String
    End Structure

    Private Structure PlanningEventDetails
        Public PKey As String
        Public PlanningEvent As String
        Public DateDep As String
        Public VslName As String
        Public VslFlag As String
        Public FKeyComp As String
        Public LackInDocument As Boolean
        Public PlannedPort As String
    End Structure

    Private Structure PlannedCrewDetails
        Public IDNbr As String
        Public CrewName As String
        Public Rank As String
        Public HasLackingDoc As Boolean
        Public DateSignOff As String
        Public PlanningEventKey As String
        Public CrewID As String
        Public FKeyRankCode As String
        Public LOC As String
        Public PlannedDateSOn As String
    End Structure


#End Region

#Region "Population"

    Private Sub PopulateMainCompetence()
        Try
            mainComp_Hash.Clear()
            Dim table As DataTable = competenceTemplateDataTable
            For Each row As DataRow In table.Rows
                Dim _mainComp As MainCompetence
                With _mainComp
                    .DocType = row("DocType").ToString()
                    .DocName = row("DocName").ToString()
                    .Number = row("Number").ToString()
                    .Issue = row("Issue").ToString()
                    .Expiry = row("Expiry").ToString()
                    .Country = row("Country").ToString()
                    .Capacity = row("Capacity").ToString()
                    .Complied = row("Complied").ToString()
                    .Comment = row("Comment").ToString()
                End With
                mainComp_Hash.Add(_mainComp)
            Next
            table.Dispose()
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateMainCompetence() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateMainCompetence() method in PlanChecklist.vb - End--")
        End Try
    End Sub

    Private Sub PopulateVesselCompetence()
        Try
            'vesselComp.Clear()
            vesselComp_Hash.Clear()
            Dim table As DataTable = vesselTypeTemplateDataTable
            For Each row As DataRow In table.Rows
                Dim _vslComp As VesselCompetence
                With _vslComp
                    .VslType = row("VslType").ToString()
                    .RankName = row("RankName").ToString()
                    .YrOfService = row("YrOfService").ToString()
                    .TotalYrsOfService = row("TotalYrsOfService").ToString()
                    .Complied = row("Complied").ToString()
                End With
                'vesselComp.Add(_vslComp)
                vesselComp_Hash.Add(_vslComp)
            Next
            table.Dispose()
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateVesselCompetence() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateVesselCompetence() method in PlanChecklist.vb - End--")
        End Try
    End Sub

#End Region


    Dim _selectedPlanningId As String
    Dim _selectedCrewId As String
    Dim _selectedCrewRank As String
    Dim _competenceId As String
    Dim _selectedCrewLoc As String
    Dim _selectedCrewSignOn As String
    Dim _reportSourceQuery As String
    Dim _selectedVessel As String
    Dim _flagRegistry As String
    Dim _plannedPort As String
    Dim _competenceVslTypeQuery As String
    Dim _userdatafilterstring As String
    Dim clsAudit As New clsAudit

    Public Shared CrewSelected As New SelectedCrew
    Public Shared IncludeColors As Boolean

    'Dim planningEvent As New List(Of PlanningEventDetails)
    'Dim plannedCrews As New List(Of PlannedCrewDetails)

    Dim planningEvent_Hash As New HashSet(Of PlanningEventDetails)
    Dim plannedCrews_Hash As New HashSet(Of PlannedCrewDetails)

    Dim mainComp_Hash As New HashSet(Of MainCompetence)
    Dim vesselComp_Hash As New HashSet(Of VesselCompetence)

    'Dim mainComp As New List(Of MainCompetence)
    'Dim vesselComp As New List(Of VesselCompetence)

#Region "Easy Edit"
    Private FormName As String = " Joining Checklist  "
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName)
#End Region

    Private Sub InitControls()

        LayoutControl1.AllowCustomization = False
        _userdatafilterstring = MPS4.GetUserFilterString(, , "fkeyprincode", "fkeyflt") 'Get the filtering, by Principal or Fleet

        ConfigureView()
        GenerateDocRecords()
        Refresh()
        SetGridReadOnlyProperties(PlanningView, True)
        SetGridReadOnlyProperties(CrewPlannedView, True)

    End Sub

    Public Overrides Sub RefreshPlanningList()
        MyBase.RefreshPlanningList()

        If HasShowFlaggedColorsInJoiningChecklist Then
            If MessageBox.Show("Refreshing the 'Joining Checklist' will take some time, but will get the latest data from your server. Do you want to continue?",
                                "Refreshing Joining Checklist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                IsPlanningChecklistFirstLoad = True
                GenerateDocRecords()
                Refresh()
            End If
        Else
            IsPlanningChecklistFirstLoad = True
            GenerateDocRecords()
            Refresh()
        End If
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        InitControls()
        AllowSaving(Name, True)
        bLoaded = True
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        If (CompetenceDocsView.DataRowCount = 0) Then
            Return
        Else
            If MessageBox.Show("Save comments?", "Crew Checklist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                SaveComments()
                LoadCompetenceForFirstRecord(CrewPlannedView.GetFocusedDataRow())
            End If
        End If
    End Sub

    'This method will receive a list with a specified user-defined types (T) and convert it to DataTable. (List version)
    Public Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
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

    Public Sub PopulatePlannedCrews()
        'plannedCrews.Clear()
        plannedCrews_Hash.Clear()
        Try
            Dim table As DataTable = DB.CreateTable("SELECT * FROM view_PlannedCrews")  'Get all planned crews.
            For Each row As DataRow In table.Rows
                Dim crews As PlannedCrewDetails
                crews.IDNbr = row("CrewID").ToString()
                crews.CrewName = row("CrewName").ToString()
                crews.Rank = row("Rank").ToString()
                'crews.HasLackingDoc = HasLackingDocument(row("FKeyPlanningEvent").ToString(), row("CrewID").ToString()) 'Identify if the crews has lacking documents.
                crews.HasLackingDoc = IIf(HasShowFlaggedColorsInJoiningChecklist, HasLackingDocument(row("FKeyPlanningEvent").ToString(), row("CrewID").ToString()), False) 'Identify if the crews has lacking documents.
                crews.DateSignOff = row("DateSignOff").ToString()
                crews.PlanningEventKey = row("FKeyPlanningEvent").ToString()
                crews.CrewID = row("CrewID").ToString()
                crews.LOC = row("LOC").ToString()
                crews.FKeyRankCode = row("FKeyRankCode").ToString()
                crews.PlannedDateSOn = row("PlannedDateSOn").ToString()
                plannedCrews_Hash.Add(crews) 'Store to list.
            Next
            table.Dispose()
        Catch ex As Exception
            LogErrors("--Error Generated in PopulatePlannedCrews() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulatePlannedCrews() method in PlanChecklist.vb - End--")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Query all crews under a specific planning event.
    Private Function GetPlannedCrew(planningID As String) As List(Of PlannedCrewDetails)

        'Get all the crews that matched the planning event id.
        Dim listOfCrews = From c In plannedCrews_Hash.AsEnumerable()
                          Where c.PlanningEventKey.Equals(planningID)
                          Select c
        Dim filteredCrew As New List(Of PlannedCrewDetails)
        Try
            For Each row In listOfCrews
                filteredCrew.Add(row)
            Next
        Catch ex As Exception
            LogErrors("--Error Generated in GetPlannedCrew() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetPlannedCrew() method in PlanChecklist.vb - End--")
            MessageBox.Show("Error in GetPlannedCrew() method : " + ex.Message)
        End Try

        Return filteredCrew

    End Function

    Public Sub PopulatePlanningEventList()

        'planningEvent.Clear()
        planningEvent_Hash.Clear()
        Try
            Dim table As DataTable = DB.CreateTable("SELECT * FROM view_ChecklistPlanningSource", 1000) 'Get all planning events.
            For Each row As DataRow In table.Rows
                Dim planEvent As PlanningEventDetails
                planEvent.PKey = row("PKey").ToString()
                planEvent.PlanningEvent = row("PlanningEvent").ToString()
                planEvent.DateDep = row("DateDep").ToString()
                planEvent.VslName = row("VslName").ToString()
                'planEvent.LackInDocument = HasLackingDocument(row("PKey").ToString(), "")  'Identify if there is a single crew who have a lacking documents.
                planEvent.LackInDocument = IIf(HasShowFlaggedColorsInJoiningChecklist, HasLackingDocument(row("PKey").ToString(), ""), False)      'Identify if there is a single crew who have a lacking documents.
                planEvent.PlannedPort = row("PlannedPort").ToString()
                planEvent.FKeyComp = row("FKeyComp").ToString()
                planEvent.VslFlag = row("VslFlag").ToString()
                'planningEvent.Add(planEvent)
                planningEvent_Hash.Add(planEvent)
            Next
            table.Dispose()
        Catch ex As Exception
            LogErrors("--Error Generated in PopulatePlanningEventList() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulatePlanningEventList() method in PlanChecklist.vb - End--")

            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function CheckingKeys(pkey As String, ckey As String, pVal As String, cVal As String) As Boolean

        If (cVal.Trim().Length = 0) Then
            If (pkey.Equals(pVal)) Then
                Return True
            Else
                Return False
            End If
        Else
            If (pkey.Equals(pVal) And ckey.Equals(cVal)) Then
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Public Function HasLackingDocument(pVal As String, cVal As String) As Boolean
        'Checking if there is a single documents that is lacking or about to expire.
        Dim retVal As Boolean = False
        Dim InOrderCount As Integer = 0
        Dim LackingCount As Integer = 0

        For Each row As DataRow In TempChecklistDocuments.Rows
            If CheckingKeys(row("PlanningEventKey").ToString(), row("CrewIDNbr").ToString(), pVal, cVal) Then
                If row("DocStatus").ToString().Equals("Opt") Or row("DocStatus").ToString().Equals("Lacking") Or row("DocStatus").ToString().Equals("DueToExpire") Then
                    LackingCount = LackingCount + 1
                ElseIf row("DocStatus").ToString().Equals("InOrder") Or row("Complied").ToString().Equals("Yes") Then
                    InOrderCount = InOrderCount + 1
                End If
            End If
        Next

        If LackingCount = 0 And InOrderCount = 0 Then       '--> If no documents that are lacking and in-order
            retVal = True
        ElseIf LackingCount > 0 And InOrderCount = 0 Then   '--> If has lacking document and no in-order documents
            retVal = True
        ElseIf LackingCount = 0 And InOrderCount > 0 Then   '--> If no lacking but have in-order documents
            retVal = False
        ElseIf LackingCount > 0 And InOrderCount > 0 Then   '--> If has lacking and in-order documents. 
            retVal = True
        End If

        Return retVal

    End Function

    Public Sub GenerateDocRecords()
        Try
            SplashScreenManager.ShowForm(GetType(Waitform))
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            SplashScreenManager.ShowForm(GetType(Waitform))
        End Try

        Try
            If (IsPlanningChecklistFirstLoad) Then
                PlanningGrid.DataSource = Nothing
                CrewPlannedGrid.DataSource = Nothing
                CompetenceDocsGrid.DataSource = Nothing
                VesselTypeGrid.DataSource = Nothing
                If (HasShowFlaggedColorsInJoiningChecklist) Then
                    Dim query As New ArrayList
                    query.Add("EXEC [dbo].[GenerateDataForChecklist] @currentUserID = " & USER_ID)
                    DB.RunTransaction(query)                                                                'Checking each document for each crew under each of the planning, then save to tbl_temp_checklist_documents
                    TempChecklistDocuments = DB.CreateTable("SELECT * FROM tbl_temp_checklist_documents")   'Retrieve data from tbl_temp_checklist_documents for caching and save it to local object TempChecklistDocuments. 
                    If (TempChecklistDocuments.Rows.Count > 0) Then
                        IsPlanningChecklistFirstLoad = False
                    End If
                    PopulatePlanningEventList()
                    PopulatePlannedCrews()
                Else
                    PopulatePlanningEventList() 'Retrieve the existing data for planning events. 
                    PopulatePlannedCrews()      'Retrieve the data for planned crews.
                End If
            Else
                PopulatePlanningEventList() 'Retrieve the existing data for planning events. 
                PopulatePlannedCrews()      'Retrieve the data for planned crews.
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in GenerateDocRecords() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GenerateDocRecords() method in PlanChecklist.vb - End--")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Overrides Sub ShowChecklistWithFlaggedColors()
        MyBase.ShowChecklistWithFlaggedColors()
        Try
            SaveUserOptionForNonCompliance()
            IsPlanningChecklistFirstLoad = True
            GenerateDocRecords()
            Refresh()
        Catch ex As Exception
            LogErrors("--Error Generated in ShowChecklistWithFlaggedColors() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in ShowChecklistWithFlaggedColors() method in PlanChecklist.vb - End--")

            MessageBox.Show("Error encountered while showing colors : " & ex.Message, "Joining Checklist", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SaveUserOptionForNonCompliance()

        Try
            Dim query As String = ""
            Dim status As String = DB.DLookUp("Value", "tblUserConfig", "NoRecord", "FKeyUserID = " & USER_ID & " AND Code = 'FlaggedColor'")
            If (status.Equals("NoRecord")) Then
                query = "INSERT INTO tblUserConfig(FKeyUserID, Value, Code) VALUES (" & USER_ID & ",'True','FlaggedColor') "
            Else
                query = "UPDATE tblUserConfig SET Value = '" & HasShowFlaggedColorsInJoiningChecklist.ToString() & "' WHERE FKeyUserID = " & USER_ID & " AND Code = 'FlaggedColor'"
            End If
            DB.RunSql(query)

        Catch ex As Exception
            LogErrors("--Error Generated in SaveUserOptionForNonCompliance() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SaveUserOptionForNonCompliance() method in PlanChecklist.vb - End--")

            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Overrides Sub Refresh()
        Try
            PlanningGrid.DataSource = ConvertToDataTable(planningEvent_Hash)

            SplashScreenManager.Default.SetWaitFormDescription("Successful.")
            SplashScreenManager.CloseForm()
            PlanningView.FocusedRowHandle = PKeySelected
        Catch ex As Exception
            LogErrors("--Error Generated in Refresh() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in Refresh() method in PlanChecklist.vb - End--")

            MessageBox.Show("An error has been encountered while loading the planning details : " & ex.Message, "MPS - Checklist ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            SplashScreenManager.CloseForm()
        End Try

    End Sub

    Private Sub PlanningView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles PlanningView.FocusedRowChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        _selectedPlanningId = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "PKey")), "", view.GetRowCellValue(e.FocusedRowHandle, "PKey"))
        _competenceId = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "FKeyComp")), "", view.GetRowCellValue(e.FocusedRowHandle, "FKeyComp"))
        _selectedVessel = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "VslName")), "", view.GetRowCellValue(e.FocusedRowHandle, "VslName"))
        _flagRegistry = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "VslFlag")), "", view.GetRowCellValue(e.FocusedRowHandle, "VslFlag"))
        _plannedPort = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "PlannedPort")), "", view.GetRowCellValue(e.FocusedRowHandle, "PlannedPort"))

        Dim competenceName As String = DB.DLookUp("Name", "tblAdmComp", "", "PKey ='" & _competenceId & "'")
        Dim locDays As String = DB.DLookUp("TextValue", "tblConfig", "", "Code='EXPIRY_BUFFER'")

        ChangedPkeySelected = PlanningView.FocusedRowHandle
        Try
            'CrewPlannedGrid.DataSource = Nothing
            'CompetenceDocsGrid.DataSource = Nothing
            'VesselTypeGrid.DataSource = Nothing
            'CrewPlannedView.FocusedRowHandle = ChangedPkeySelected
            CrewPlannedGrid.DataSource = ConvertToDataTable(GetPlannedCrew(_selectedPlanningId))
            lcgCompetenceTemplate.Text = "Qualification Template " + IIf(competenceName.Length > 0, " : " + competenceName, "") '+ (IIf(locDays.Length > 0, " - ( Length of Contract + " & locDays & " days. )", ""))

            LoadCompetenceForFirstRecord(CrewPlannedView.GetFocusedDataRow())

        Catch ex As Exception
            LogErrors("--Error Generated in PlanningView_FocusedRowChanged() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PlanningView_FocusedRowChanged() method in PlanChecklist.vb - End--")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadCompetenceForFirstRecord(row As DataRow)
        Try
            If IsNothing(row) Then Return

            _selectedCrewId = IIf(IsDBNull(row("CrewID").ToString()), "", row("CrewID").ToString())
            _selectedCrewRank = IIf(IsDBNull(row("FKeyRankCode").ToString()), "", row("FKeyRankCode").ToString())
            _selectedCrewLoc = IIf(IsDBNull(row("LOC").ToString()), "", row("LOC").ToString())
            _selectedCrewSignOn = IIf(IsDBNull(row("PlannedDateSOn").ToString()), "", Convert.ToDateTime(row("PlannedDateSOn")).ToString("MM/dd/yyyy"))

            CrewSelected.RankName = DB.DLookUp("Name", "tblAdmRank", "", "PKey='" & _selectedCrewRank & "'")
            CrewSelected.SurName = DB.DLookUp("LName", "tblCrewInfo", "", "PKey='" & _selectedCrewId & "'")
            CrewSelected.FirstName = DB.DLookUp("FName", "tblCrewInfo", "", "PKey='" & _selectedCrewId & "'")
            CrewSelected.MiddleName = DB.DLookUp("MName", "tblCrewInfo", "", "PKey='" & _selectedCrewId & "'")
            CrewSelected.VesselName = _selectedVessel
            CrewSelected.FlagRegistry = _flagRegistry
            CrewSelected.JoiningPort = _plannedPort
            CrewSelected.DepartureDate = _selectedCrewSignOn


            If IsNothing(_selectedCrewLoc) Then
                _selectedCrewId = "0"
            End If

            PopulateCompetence(_selectedCrewId, _selectedCrewRank, _competenceId, _selectedCrewSignOn, IIf(_selectedCrewLoc = "", 0, _selectedCrewLoc))
        Catch ex As Exception
            LogErrors("--Error Generated in LoadCompetenceForFirstRecord() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in LoadCompetenceForFirstRecord() method in PlanChecklist.vb - End--")

            MessageBox.Show("Error in LoadCompetenceForFirstRecord() method : " & ex.Message)
        End Try
    End Sub

    Private Sub CrewPlannedView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles CrewPlannedView.FocusedRowChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        LoadCompetenceForFirstRecord(view.GetFocusedDataRow())
    End Sub


    Private Sub PlanningView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles PlanningView.RowCellStyle
        SetRowCellStyle(PlanningView, sender, e)
        Dim bHasLackDocuments As Boolean = PlanningView.GetRowCellValue(e.RowHandle, "LackInDocument")
        If (bHasLackDocuments) Then
            e.Appearance.ForeColor = Color.Firebrick
        End If
    End Sub

    Private Sub CompetenceDocsView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles CompetenceDocsView.BeforeLeaveRow
        header.Focus()
    End Sub

    Private Sub CrewPlannedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewPlannedView.RowCellStyle
        SetRowCellStyle(CrewPlannedView, sender, e)
        Dim bHasLackingDocuments As Boolean = CrewPlannedView.GetRowCellValue(e.RowHandle, "HasLackingDoc")
        If (bHasLackingDocuments) Then
            e.Appearance.ForeColor = Color.Firebrick
        End If
    End Sub

    Private Sub CompetenceDocsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CompetenceDocsView.RowCellStyle
        SetRowCellStyle(CompetenceDocsView, sender, e)
        Dim sDocStatus As String = IfNull(CompetenceDocsView.GetRowCellValue(e.RowHandle, "DocStatus"), "")
        Select Case sDocStatus
            Case "InOrder"
                e.Appearance.BackColor = Color.White
                e.Appearance.ForeColor = Color.Black
            Case "Lacking"
                e.Appearance.BackColor = Color.Firebrick
                e.Appearance.ForeColor = Color.Wheat
            Case "DueToExpire"
                e.Appearance.BackColor = Color.Orange
                e.Appearance.ForeColor = Color.Black
            Case "Opt"
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.ForeColor = Color.Black
        End Select
    End Sub

    Private Sub VesselTypeView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles VesselTypeView.RowCellStyle
        SetRowCellStyle(VesselTypeView, sender, e)
        Dim sDocStatus As String = VesselTypeView.GetRowCellValue(e.RowHandle, "Complied")
        Select Case sDocStatus
            Case "Yes"
                e.Appearance.BackColor = Color.White
                e.Appearance.ForeColor = Color.Black
            Case "No"
                e.Appearance.BackColor = Color.Firebrick
                e.Appearance.ForeColor = Color.Wheat
        End Select
    End Sub

    Public Sub SetRowCellStyle(controlGrid As GridView, ByRef sender As Object, ByRef e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Try
            If controlGrid.GetRowCellValue(e.RowHandle, "Edited") Is DBNull.Value Then
                e.Appearance.BackColor = SEL_COLOR
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") And controlGrid.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") = True Then
                e.Appearance.BackColor = EDITED_COLOR
            ElseIf e.RowHandle = controlGrid.FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in SetRowCellStyle() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetRowCellStyle() method in PlanChecklist.vb - End--")
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub PopulateCompetence(crewIdNbr As String, currentRank As String, competence As String, dateSon As String, Optional ByVal loc As Integer = 0)

        _reportSourceQuery = "SELECT *, REPLACE(CONVERT(NVARCHAR, DateExpiry, 106), ' ','-') AS Expiry, REPLACE(CONVERT(NVARCHAR, DateIssue, 106),' ','-') AS Issue, CAST(0 as BIT) as Edited " & _
                             "FROM Checklist('" & crewIdNbr & "','" & currentRank & "','" & competence & "', " & loc & ",'" & dateSon & "') ORDER BY Sorting"

        _competenceVslTypeQuery = "SELECT * FROM GetCompetenceInVesselType('" & crewIdNbr & "','" & currentRank & "','" & competence & "') ORDER BY SortCode "

        Try
            mainComp_Hash.Clear()
            vesselComp_Hash.Clear()

            competenceTemplateDataTable = DB.CreateTable(_reportSourceQuery)
            vesselTypeTemplateDataTable = DB.CreateTable(_competenceVslTypeQuery)

            CompetenceDocsGrid.DataSource = competenceTemplateDataTable
            VesselTypeGrid.DataSource = vesselTypeTemplateDataTable

            PopulateMainCompetence()
            PopulateVesselCompetence()

            If competenceTemplateDataTable.Rows.Count > 0 Or vesselTypeTemplateDataTable.Rows.Count > 0 Then
                AllowSaving(Name, True)
            Else
                AllowSaving(Name, False)
                lcgCompetenceTemplate.Text = "NOTE: There are no documents set up for this competence [" & DB.DLookUp("Name", "tblAdmComp", "", "PKey='" & competence & "'") & "], therefore the planning will be considered lacking!"
            End If

        Catch ex As Exception
            LogErrors("--Error Generated in PopulateCompetence() method in PlanChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateCompetence() method in PlanChecklist.vb - End--")

            MessageBox.Show(String.Format("There is an error while generating the Qualification documents  : {0}", ex.Message))
        End Try
    End Sub

    Public Sub SaveComments()
        header.Focus()
        Dim dataToInsertUpdate As New ArrayList
        Dim insertQuery As String

        With CompetenceDocsView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                If Not IsDBNull(.GetRowCellValue(i, "Edited")) And .GetRowCellValue(i, "Edited") = True Then
                    'If no record yet on the table tblChecklistComments, insert the comment together with the crewid and docid.
                    Dim result As String = DB.DLookUp("IDNbr", "tblChecklistComments", "", "IDNbr ='" & .GetRowCellValue(i, "CrewIDNbr") & "' AND DocID ='" & .GetRowCellValue(i, "DocumentID") & "'")

                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Checklist - Comment", 0, System.Environment.MachineName, .GetRowCellDisplayText(i, "DocName") & " - " & .GetRowCellValue(i, "Comment"), "Crew Checklist", .GetRowCellValue(i, "CrewIDNbr")) 'neil

                    If result.Equals("") Then
                        insertQuery = "INSERT INTO tblChecklistComments (IDNbr, DocID, DocComment, LastUpdatedBy) " & _
                                      "VALUES ('" & .GetRowCellValue(i, "CrewIDNbr") & "','" & .GetRowCellValue(i, "DocumentID") & "','" & .GetRowCellValue(i, "Comment") & "', '" & LastUpdatedBy & "')"
                        dataToInsertUpdate.Add(insertQuery)
                    Else
                        'If there is a record, update the comment using the crewid and docid as the criteria.
                        insertQuery = "UPDATE tblChecklistComments SET IDNbr= '" & .GetRowCellValue(i, "CrewIDNbr") & "', DocID ='" & .GetRowCellValue(i, "DocumentID") & _
                                      "',DocComment='" & .GetRowCellValue(i, "Comment") & "', LastUpdatedBy ='" & LastUpdatedBy & "' " & _
                                      "WHERE IDNbr = '" & .GetRowCellValue(i, "CrewIDNbr") & "' AND DocID = '" & .GetRowCellValue(i, "DocumentID") & "'"
                        dataToInsertUpdate.Add(insertQuery)
                    End If
                End If
            Next

            Dim queryResult As Boolean = DB.RunTransaction(dataToInsertUpdate)

            If queryResult Then
                MessageBox.Show(String.Format("Comment successfully saved."), String.Format("Checklist Comments"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(String.Format("Saving comment failed. There is an error in your query."), String.Format("Checklist Comments"), MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            BRECORDUPDATEDs = False
        End With
    End Sub

    Private Sub ConfigureView()
        'Group the competence by Document Type
        With CompetenceDocsView
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

    Public Sub SetGridReadOnlyProperties(controlGrid As GridView, Optional isReadOnly As Boolean = True)
        With controlGrid
            Select Case isReadOnly
                Case True
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    .OptionsBehavior.ReadOnly = True
                Case Else
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    .OptionsBehavior.ReadOnly = False
            End Select
        End With
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        If param(0).ToString().Equals("PREVIEWREPORT") Then
            OpenReport("rptChecklistReport", _reportSourceQuery & " ^ " & _competenceVslTypeQuery)
        End If
    End Sub

    Private Sub OpenReport(reportClassName As String, sourceQuery As String)
        Try
            'This raise event will call the constructor of 'reportClassName', supplied with optional 'sourceQuery' for the report. 
            RptChecklistReport._compSource = ConvertToDataTable(mainComp_Hash)
            RptChecklistReport._vesselSource = ConvertToDataTable(vesselComp_Hash)
            RaiseCustomEvent(Name, New Object() {"Preview", reportClassName, "Checklist", sourceQuery})
        Catch ex As Exception
            Debug.WriteLine("Error encountered while generating the report: " & ex.Message)
        End Try
    End Sub

    Private Sub CompetenceDocsView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CompetenceDocsView.CellValueChanged
        If e.Column.FieldName.Equals("Comment") Then
            With CompetenceDocsView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub CompetenceDocsView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CompetenceDocsView.RowUpdated
        'BRECORDUPDATEDs = True
    End Sub

    Private Sub CrewPlannedView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles CrewPlannedView.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            rightClickMenu.ShowPopup(MousePosition)
        Else
            rightClickMenu.HidePopup()
        End If
    End Sub

    Private Sub rightClick_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarManager1.ItemClick
        If e.Item.Name <> "AddComment" And e.Item.Name <> "PrintBio" Then
            RaiseCustomEvent(Name, New Object() {"GoTo", e.Item.Name, "Crewing"})
        Else
            If e.Item.Name = "PrintBio" Then
                Try
                    Dim frmRptSel As New ReportSelectionInd(_selectedCrewId)
                    frmRptSel.ShowDialog(Me)
                Catch ex As Exception
                    MsgBox("There is no selected record(s) to preview. Please try again.", vbInformation)
                End Try
            Else
                Dim commentDT As New DataTable
                commentDT = DB.CreateTable("SELECT *, '' as Remarks FROM dbo.frmCrew_Comment WHERE FKeyIDNbr = '" & _selectedCrewId & "'")
                Dim cCrewName = AssembleName(CrewSelected.SurName, _
                                             CrewSelected.FirstName, _
                                             CrewSelected.MiddleName)

                Dim frm As New frmCrewComments(commentDT, _selectedCrewId, cCrewName)
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub CrewPlannedView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles CrewPlannedView.PopupMenuShowing
        selectedID = _selectedCrewId
    End Sub

    Private Sub CompetenceDocsView_CustomDrawEmptyForeground(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs) Handles CompetenceDocsView.CustomDrawEmptyForeground
        If bLoaded Then SetGridViewLabelEmptyCompetence(sender, e)
    End Sub

    Private Sub VesselTypeView_CustomDrawEmptyForeground(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs) Handles VesselTypeView.CustomDrawEmptyForeground
        If bLoaded Then SetGridViewLabelEmptyCompetence(sender, e)
    End Sub

    Private Sub SetGridViewLabelEmptyCompetence(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If VesselTypeView.RowCount = 0 And CompetenceDocsView.RowCount = 0 Then
            Dim drawFormat As New StringFormat()
            drawFormat.LineAlignment = StringAlignment.Center
            drawFormat.Alignment = drawFormat.LineAlignment
            Dim cCompetence As String = ""
            If view.Name = CompetenceDocsView.Name Then
                cCompetence = "documents"
            ElseIf view.Name = VesselTypeView.Name Then
                cCompetence = "vessel experience"
            Else
                cCompetence = "requirements"
            End If

            e.Graphics.DrawString("There are no " & cCompetence & " set up for this competence, therefore, is considered as lacking.", New Font(e.Appearance.Font.Style, 14), SystemBrushes.ControlDark, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat)
        End If
    End Sub
End Class
