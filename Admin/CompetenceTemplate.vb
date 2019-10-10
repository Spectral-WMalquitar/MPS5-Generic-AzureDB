Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base

Public Class CompetenceTemplate

    Private _rankGridData As DataTable
    Private _selectedRankId As String = ""
    Private _selectedRankName As String = ""
    Private _selectedCompetence As String = ""
    Private _selectedViews As SelectedView = SelectedView.Competence

    Private _hasMainRank As Boolean = True
    Private _hasLicCert As Boolean = True
    Private _hasCourse As Boolean = True
    Private _hasMedCert As Boolean = True
    Private _hasNatInfo As Boolean = True
    Private _hasTravDoc As Boolean = True
    Private _hasVslType As Boolean = True
    Private _hasRequiredTraining As Boolean = True

    Private _hasCompanyDefined As Boolean = True
    Private _hasYrOfService As Boolean = True
    Private _currentSelectedRank As Integer
    Private _savedSelectedRank As Integer
    Private _currEditingSub As String = ""

    Private FKeyRank_Duplicated As String = ""

    Private ReadOnly _listOfTables As String() = {"tblAdmCompLicCert", "tblAdmCompCourse", "tblAdmCompMedCert",
                                                  "tblAdmCompNatInfo", "tblAdmCompSServ", "tblAdmCompTravDoc",
                                                  "tblAdmCompVslType", "tblAdmCompCompanyDefined", "tblAdmCompRepeatTraining", "tblAdmCompAgeReq"}

    Enum SelectedView
        Competence = 0
        Rank = 1
        Certificate = 2
        Course = 3
        Travel = 4
        Medical = 5
        NationalInfo = 6
        VesselType = 7
        CompanyDefined = 8
        RequiredTraining = 9
        AgeRequirement = 10
    End Enum

#Region "Form and Last Updated By Information"
    Private FormName As String = "Admin Qualification Template"
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

#End Region

    'Overriden From Base Control
    'This method should be called after any changes (add, edit, delete) made on the selected competence. 
    Private Sub InitControls()
        'Populating Drop-down controls for all of the tabs.
        LayoutControl1.AllowCustomization = False
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        tbcgDocuments.SelectedTabPageIndex = 0
        PopulateRepository("dbo.tblAdmRank", "", RepRank, "Name Asc")
        PopulateRepository("dbo.tblAdmRank", "", RepSec, "Name Asc")
        PopulateRepository("dbo.tblAdmDocument", "FKeyDocGroup = 'SYSLICCERT'", RepCert)
        PopulateRepository("dbo.tblAdmCntry", "", RepCertCntry)
        PopulateRepository("dbo.tblAdmCapacity", "", RepCertCapacity)
        PopulateRepository("dbo.tblAdmCourse", "", RepCourse)
        PopulateRepository("dbo.tblAdmCntry", "", RepTravCntry)
        PopulateRepository("dbo.tblAdmDocument", "FKeyDocGroup = 'SYSTRAVELDOC'", RepTravType)
        PopulateRepository("dbo.tblAdmDocument", "FKeyDocGroup = 'SYSMEDCERT'", RepMedical)
        PopulateRepository("dbo.tblAdmDocument", "FKeyDocGroup = 'SYSNATINFO'", RepNatInfoType)
        PopulateRepository("dbo.tblAdmCntry", "", RepNatInfoCntry)
        PopulateRepository("dbo.tblAdmVslType", "", RepVslType)
        PopulateRepository("dbo.tblAdmRank", "", RepVslTypeRank)
        PopulateRepository("dbo.tblAdmDocument", "FKeyDocGroup = 'SYSCOMPDEF'", RepCompDefined)
        PopulateRepository("dbo.tblAdmRepeatTraining", "", RepRequiredTraining)
        PopulateSeverity(RepSeverity)
        PopulateSeverity(RepCourseSeverity)
        PopulateSeverity(RepTravelSeverity)
        PopulateSeverity(RepMedSeverity)
        PopulateSeverity(RepNatInfoSeverity)
        PopulateSeverity(RepVslTypeSeverity)
        PopulateSeverity(RepCompDefSeverity)
    End Sub

    Public Overrides Sub RefreshData()
        TableName = "tblAdmComp" 'Default table to be use on this window.
        MyBase.RefreshData()     'Reload the data.

        _hasMainRank = True
        _hasCourse = True
        _hasLicCert = True
        _hasMedCert = True
        _hasNatInfo = True
        _hasTravDoc = True
        _hasCompanyDefined = True
        _hasRequiredTraining = True

        If Not bLoaded Then
            InitControls()
            LoadSub()
            bLoaded = True
        End If

        SetDeleteCaption(Name, "Delete Qualification")
        _selectedViews = SelectedView.Competence
        If blList.GetID() = "" Then
            AddData()
        Else
            txtName.Text = Trim(IfNull(blList.GetFocusedRowData("Name"), ""))
            txtSortCode.Text = Trim(IfNull(blList.GetFocusedRowData("SortCode"), ""))
            txtCheckListName.Text = Trim(IfNull(blList.GetFocusedRowData("CheckListName"), ""))
            txtCareerPlanName.Text = Trim(IfNull(blList.GetFocusedRowData("CareerPlanName"), ""))
            _selectedCompetence = Trim(IfNull(blList.GetFocusedRowData("PKey"), ""))
            LoadSub()
            BRECORDUPDATEDs = False
            SetGridEnable(True)
        End If

        AddEditListener(LayoutControl1.Root)

        'for Sub-forms and data.
        MakeReadOnlyListener(LayoutControl1.Root)
        'Populate Listener for all controls as defined on each #Regions below
        'Disabling the editing features of each grid. 
        SetGridReadOnlyProperties(RankView, True)
        SetGridReadOnlyProperties(CertView, True)
        SetGridReadOnlyProperties(CourseView, True)
        SetGridReadOnlyProperties(TravelView, True)
        SetGridReadOnlyProperties(MedicalView, True)
        SetGridReadOnlyProperties(NatInfoView, True)
        SetGridReadOnlyProperties(VesselView, True)
        SetGridReadOnlyProperties(CompanyDefinedView, True)
        SetGridReadOnlyProperties(RequiredTrainingView, True)
        chkInclude.ReadOnly = True
        seMinAge.ReadOnly = True
        seMaxAge.ReadOnly = True
        PopulateGridWithDataSource()    'Get all the sub-data.
        RankView.FocusedRowHandle = IIf(_savedSelectedRank < 0, 0, _savedSelectedRank)

        EnableDuplicateRank(False)

    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}, showMsg) Then
                If bAddMode Then
                    If CheckDuplicate(TableName, New DevExpress.XtraEditors.TextEdit() {txtName}) Then
                        ALLOWNEXTS = flag = False
                    Else
                        ALLOWNEXTS = flag = True
                        SaveData() '
                    End If
                Else
                    If CheckDuplicate(TableName, New DevExpress.XtraEditors.TextEdit() {txtName}, "PKey<>'" & strID & "'") Then
                        ALLOWNEXTS = flag = False
                    Else
                        ALLOWNEXTS = flag = True
                        SaveData() '
                    End If
                End If
            Else
                ALLOWNEXTS = flag = False
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Overrides Sub AddData()
        MyBase.AddData()
        'Prepare DataTable for Ranks.
        SetGridReadOnlyProperties(RankView, False)
        RemoveReadOnlyListener(LayoutControl1.Root)
        EnableDuplicateRank(False)

        If Not bAddMode Then
            strID = ""
            _selectedCompetence = ""
            RankGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as bit) AS Edited , CAST(0 as bit) AS IsDelete FROM dbo.tblAdmCompRank WHERE FKeyComp = '" & strID & "'")
            strDesc = "New Record"
            bAddMode = True

            ClearFields(LayoutControl1.Root, False)
            AllowSaving(Name, True)      'Enable Save button 
            AllowDeletion(Name, True)   'Disable Delete button
            blList.HideSelection()
            txtName.Focus()
            txtName.BackColor = SEL_COLOR
            txtSortCode.EditValue = GetSortCode(DB, TableName)
            txtCheckListName.BackColor = SEL_COLOR
            txtCareerPlanName.BackColor = SEL_COLOR
            PopulateGridWithDataSource()
            BRECORDUPDATEDs = False
        End If
    End Sub

    Public Overrides Sub SaveData()
        Dim query As New ArrayList
        Dim type As String = ""
        Dim info As Boolean = False
        Dim id As String = ""
        header.Focus()

        Select Case False
            Case _hasMainRank
                MessageBox.Show("Please check the Rank.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasLicCert
                MessageBox.Show("Please check the License Certificate.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasCourse
                MessageBox.Show("Please check the Course.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasMedCert
                MessageBox.Show("Please check the Medical Cert.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasTravDoc
                MessageBox.Show("Please check the Travel Document.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasNatInfo
                MessageBox.Show("Please check the National Information.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasVslType
                MessageBox.Show("Please check the Vessel Type.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasCompanyDefined
                MessageBox.Show("Please check the Company Defined Type.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            Case _hasRequiredTraining
                MessageBox.Show("Please check the Required Repeat Training type.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
        End Select

        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, txtName.EditValue, FormName) 'neil  'tony20160719
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template", 10, System.Environment.MachineName, txtName.EditValue, FormName)
            If bAddMode Then
                DB.RunSql(GenerateInsertScript(LayoutControl1.Root, 3, TableName, "LastUpdatedBy, DateUpdatedBy", "'" & LastUpdatedBy & "', getdate()"))
                BRECORDUPDATEDs = False
                id = Trim(IfNull(DB.GetLastInsertedItem("PKey", TableName), ""))
                type = "Inserted"
            Else
                id = strID
                DB.RunSql(GenerateUpdateScript(LayoutControl1.Root, 3, TableName, "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated = getdate()", "PKey='" & id & "'"))
                BRECORDUPDATEDs = False
                type = "Updated"
            End If

            'Adding/Editing of Rank/s for a selected Competence
            _savedSelectedRank = _currentSelectedRank
            With RankView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Rank", 10, System.Environment.MachineName, txtName.EditValue & " : " & .GetRowCellDisplayText(i, "FKeyRank"), FormName) 'tony20160719
                    If .GetRowCellValue(i, "Edited") Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then
                        If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                            query.Add("INSERT INTO dbo.tblAdmCompRank (FKeyComp, FKeyRank, FKeySecRank, LastUpdatedBy, DateUpdated) " & _
                                      "VALUES ('" & id & "','" & .GetRowCellValue(i, "FKeyRank") & "','" & .GetRowCellValue(i, "FKeySecRank") & "', '" & LastUpdatedBy & "', getdate())")
                        Else
                            query.Add("UPDATE dbo.tblAdmCompRank SET FKeyRank ='" & .GetRowCellValue(i, "FKeyRank") & "' ," & _
                                                                   " FKeySecRank = '" & .GetRowCellValue(i, "FKeySecRank") & "'," & _
                                                                   " LastUpdatedBy = '" & LastUpdatedBy & "', " & _
                                                                   " DateUpdated = getdate() " & _
                                                                   " WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' AND FKeyComp = '" & id & "'")
                        End If
                    End If
                Next

                GetUpdatedCertificates(query)           'Save changes (update/delete) on certificates assigned to this Rank.
                GetUpdatedCourses(query)                'Save changes (update/delete) on courses assigned to this rank.
                GetUpdateTravelDocs(query)              'Save changes (update/delete) on travel docs assigned to this rank.
                GetUpdatedMedicalCertificates(query)    'Save changes (update/delete) on medical certificates assigned to this rank.
                GetUpdatedNationalInfo(query)           'Save changes (update/delete) on national information assigned to this rank. 
                GetUpdatedVesselType(query)             'Save changes (update/delete) on vessel types selected for this rank.
                GetUpdatedCompanyDefinedTypes(query)    'Save changes (update/delete) on company defined types selected for this ranks.
                GetUpdatedRequiredTraining(query)       'Save changes (update/delete) on required training types selected for this rank.
                SaveAgeRequirements(query)

            End With

            info = DB.RunTransaction(query) 'Execute all queries as one unit.
            blList.RefreshData()            'Refresh the main list.
            blList.SetSelection(id)         'Point to the newly-added competence.
            RefreshData()                   'Refresh all sub-data.
            PopulateGridWithDataSource()    'Re-query all of the updated data.

            If info Then
                MessageBox.Show(GetMessage(type), GetAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Public Overrides Sub DeleteData()
        Select Case _selectedViews
            Case SelectedView.Competence
                DeleteMain()
            Case SelectedView.Certificate
                DeleteCompSubRankRecords("dbo.tblAdmCompLicCert", CertView, "Certificates")
            Case SelectedView.CompanyDefined
                DeleteCompSubRankRecords("dbo.tblAdmCompCompanyDefined", CompanyDefinedView, "Company Defined")
            Case SelectedView.Course
                DeleteCompSubRankRecords("dbo.tblAdmCompCourse", CourseView, "Course")
            Case SelectedView.Medical
                DeleteCompSubRankRecords("dbo.tblAdmCompMedCert", MedicalView, "Medical")
            Case SelectedView.NationalInfo
                DeleteCompSubRankRecords("dbo.tblAdmCompNatInfo", NatInfoView, "National Info")
            Case SelectedView.Rank
                DeleteCompetenceRank()
            Case SelectedView.Travel
                DeleteCompSubRankRecords("dbo.tblAdmCompTravDoc", TravelView, "Travel")
            Case SelectedView.VesselType
                DeleteCompSubRankRecords("dbo.tblAdmCompVslType", VesselView, "Vessel Type")
            Case SelectedView.RequiredTraining
                DeleteCompSubRankRecords("dbo.tblAdmCompRepeatTraining", RequiredTrainingView, "Required Training")
        End Select
    End Sub

    Public Sub DeleteCompetenceRank()
        Dim info As Boolean = False
        Dim keyToDelete As String = ""

        Try
            If Not _selectedRankName.Equals("") Then
                _selectedRankName = DB.DLookUp("Name", "tblAdmRank", _selectedRankName, "PKey = '" & _selectedRankName & "'")
            End If

            If MessageBox.Show("Are you sure want to delete the  rank '" & _selectedRankName & "'?", "Delete Rank", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                keyToDelete = RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey").ToString()
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblAdmCompRank", _
                    "PKey IN ('" & keyToDelete & "')", _
                    "<< Delete Crew Data - " & FormName & " - Rank >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & "- Rank>", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM dbo.tblAdmCompRank WHERE PKey = '" & keyToDelete & "'")
                RefreshData()
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    MessageBox.Show("Rank successfully deleted.", GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in DeleteCompetenceRank() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in DeleteCompetenceRank() method in CompetenceTemplate.vb - End--")

            MessageBox.Show("There is no record to delete.", "Qualification Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    'Deleting a particular record manually in the tableName where the Pkey can be get from the view object.
    Public Sub DeleteCompSubRankRecords(ByVal tableName As String, ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal tabName As String)
        Dim info As Boolean = False
        Dim itemKey As String = ""

        If view.RowCount = 0 Then
            MessageBox.Show("There is no item to delete on " & tabName & ".", "Qualification Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            If MessageBox.Show("Are you sure want to delete the selected item in " & tabName & " tab?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                itemKey = view.GetRowCellValue(view.FocusedRowHandle, "PKey").ToString()
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    tableName, _
                    "PKey IN ('" & itemKey & "')", _
                    "<< Delete Crew Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                info = DB.RunSql("DELETE FROM " & tableName & " WHERE PKey = '" & itemKey & "'")
                RefreshData()
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    MessageBox.Show("Item successfully deleted.", GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RefreshData()
                    RankView.FocusedRowHandle = IIf(_savedSelectedRank < 0, 0, _savedSelectedRank)
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in DeleteCompSubRankRecords() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in DeleteCompSubRankRecords() method in CompetenceTemplate.vb - End--")

            MessageBox.Show("There is an error while deleting an item in " & tabName & " : " & ex.Message, "Qualification Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub DeleteMain()
        Dim info As Boolean = False
        Dim recordsToDelete As New ArrayList
        Try

            Dim result As String = DB.DLookUp("FKeyComp", "tblAdmVsl", "", "FKeyComp='" & strID & "'")

            If (result.Trim().Length <> 0) Then
                MessageBox.Show("This qualification template is being used in the vessel form, and cannot be deleted. To delete this record, please first change qualitication template for the affected vessel.", "Delete Qualification Template",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If MessageBox.Show("Are you sure want to delete the '" & strDesc & "'?", "Delete Qualification Template", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.listLogEntry.Add(New LogDeletion.RecordStructure( _
                    LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    TableName, _
                    "PKey IN ('" & strID & "')", _
                    "<< Delete Admin Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName()))
                '-->
                recordsToDelete.Add("DELETE FROM dbo." & Me.TableName & " WHERE PKey='" & strID & "'")
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.listLogEntry.Add(New LogDeletion.RecordStructure( _
                    LogDeletion.CallingApp.Admin,
                    FormName, _
                    "Admin", _
                    "tblAdmCompRank", _
                    "FKeyComp IN ('" & strID & "')", _
                    "<< Delete Admin Data - " & FormName & " - Ranks >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & "- Ranks>", _
                    LastUpdatedBy))
                '-->
                recordsToDelete.Add("DELETE FROM dbo.tblAdmCompRank WHERE FKeyComp = '" & strID & "'")

                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template", 10, System.Environment.MachineName, txtName.EditValue, FormName)
                clsAudit.saveAuditPreDelDetails(Me.TableName, strID, LastUpdatedBy) 'neil
                clsAudit.saveAuditPreDelDetails("tblAdmCompRank", strID, LastUpdatedBy) 'neil

                info = DB.RunSqls(recordsToDelete)
                If info Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    MessageBox.Show("Qualification template successfully deleted.", GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    blList.RefreshData()
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in DeleteMain() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in DeleteMain() method in CompetenceTemplate.vb - End--")

            MessageBox.Show("There is no qualification template to delete.", "Qualification Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub LoadSub() 'Required for method definition
        BRECORDUPDATEDs = False
        Dim ranks As String = "SELECT tblAdmCompRank.*, CAST(0 as BIT) as Edited, CAST(0 as bit) AS IsDelete " & _
                              "FROM tblAdmCompRank INNER JOIN tblAdmRank r ON r.PKey = tblAdmCompRank.FKeyRank " & _
                              "WHERE FKeyComp = '" & strID & "' ORDER BY r.SortCode "
        _rankGridData = DB.CreateTable(ranks)
        RankGrid.DataSource = _rankGridData
        _selectedRankId = ""
        _selectedRankId = IIf(IsDBNull(RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey")), "", RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey"))

        PopulateGridWithDataSource()
        'PopulateAgeRequirement()
    End Sub

    Public Overrides Sub EditData() 'Required for method definition
        MyBase.EditData()

        If isEditdable Then
            txtName.Focus()
            'AllowDeletionSub(Name, True)
            AllowDeletion(Name, True)
            RemoveReadOnlyListener(LayoutControl1.Root)
            'RankView Sub
            SetGridReadOnlyProperties(RankView, False)
            Me.RankView.Focus()

            If (_rankGridData.Rows.Count <> 0) Then
                
                'Select Case tbcgDocuments.SelectedTabPageIndex
                '    Case 0
                SetGridReadOnlyProperties(CertView, False)
                '        'Case 1
                SetGridReadOnlyProperties(CourseView, False)
                '    Case 1
                SetGridReadOnlyProperties(TravelView, False)
                '    Case 2
                SetGridReadOnlyProperties(MedicalView, False)
                '    Case 3
                SetGridReadOnlyProperties(NatInfoView, False)
                '    Case 4
                SetGridReadOnlyProperties(VesselView, False)
                '    Case 5
                SetGridReadOnlyProperties(CompanyDefinedView, False)
                '    Case 6
                '        'SetGridReadOnlyProperties(RequiredTrainingView, False)
                chkInclude.ReadOnly = False
                seMinAge.ReadOnly = False
                seMaxAge.ReadOnly = False
                '        'Case 7
                '        '    chkInclude.ReadOnly = False
                '        '    seMinAge.ReadOnly = False
                '        '    seMaxAge.ReadOnly = False
                'End Select
                PopulateGridWithDataSource()

                If IfNull(RankView.GetFocusedRowCellValue("PKey"), "").Equals("") Then
                    EnableDuplicateRank(False)
                Else
                    EnableDuplicateRank()
                End If
            End If
        Else
            txtName.Focus()
            SetGridReadOnlyProperties(RankView, True)
            SetGridReadOnlyProperties(CertView, True)
            SetGridReadOnlyProperties(CourseView, True)
            SetGridReadOnlyProperties(TravelView, True)
            SetGridReadOnlyProperties(MedicalView, True)
            SetGridReadOnlyProperties(NatInfoView, True)
            SetGridReadOnlyProperties(VesselView, True)
            SetGridReadOnlyProperties(CompanyDefinedView, True)
            SetGridReadOnlyProperties(RequiredTrainingView, True)
            EnableDuplicateRank(False)
            chkInclude.ReadOnly = True
            seMinAge.ReadOnly = True
            seMaxAge.ReadOnly = True
        End If
    End Sub

    'Event Handling for each competence tab details.
#Region "Competence Rank"

    Private Sub RankView_Click(sender As Object, e As System.EventArgs) Handles RankView.Click
        Dim view As GridView = TryCast(sender, GridView)
        view.RefreshRow(view.FocusedRowHandle)
        PopulateGridWithDataSource()
        PopulateAgeRequirement()
    End Sub

    Private Sub RankView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles RankView.FocusedRowChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        _selectedRankId = ""
        _selectedRankId = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "PKey")), "", view.GetRowCellValue(e.FocusedRowHandle, "PKey"))
        _selectedRankName = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "FKeyRank")), "", view.GetRowCellValue(e.FocusedRowHandle, "FKeyRank"))
        _currentSelectedRank = RankView.FocusedRowHandle
        PopulateGridWithDataSource()
        Try
            If _selectedRankId.Equals("") Then
                SetGridEnable(False)
            Else
                SetGridEnable(True)
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in RankView_FocusedRowChanged() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in RankView_FocusedRowChanged() method in CompetenceTemplate.vb - End--")

            Debug.WriteLine(ex.Message)
            SetGridEnable(False)
        End Try

        If IfNull(_selectedRankId, "") <> "" Then
            If isEditdable Or bAddMode Then
                EnableDuplicateRank()
            Else
                EnableDuplicateRank(False)
            End If
        Else
            EnableDuplicateRank(False)
        End If
    End Sub

    Private Sub RankView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RankView.CellValueChanged
        Dim view As GridView = TryCast(sender, GridView)

        If e.Column.FieldName.ToString <> "Edited" Then
            With RankView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If

        If e.Column.FieldName.ToString = "IsDelete" Then
            If (view.GetRowCellValue(view.FocusedRowHandle, "IsDelete") = True) Then
                SetGridEnable(False)
            Else
                SetGridEnable(True)
            End If
        End If
    End Sub

    Private Sub RankView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RankView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub RankView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RankView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("FKeyComp"), strID)
        SubAddMode = True
    End Sub

    Private Sub RankView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles RankView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasMainRank = False
    End Sub

    Private Sub RankView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles RankView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            RankView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub RankView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles RankView.RowCellStyle
        SetRowCellStyle(RankView, sender, e)
    End Sub

    Public Sub SetRowCellStyle(controlGrid As GridView, ByRef sender As Object, ByRef e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Try
            If controlGrid.GetRowCellValue(e.RowHandle, "Edited") Is DBNull.Value Then
                e.Appearance.BackColor = SEL_COLOR
                If controlGrid.GetRowCellValue(e.RowHandle, "IsDelete") = True Then
                    e.Appearance.BackColor = Color.LightCoral
                End If
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") And controlGrid.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = EDITED_FOCUSED_COLOR
                If controlGrid.GetRowCellValue(e.RowHandle, "IsDelete") = True Then
                    e.Appearance.BackColor = Color.LightCoral
                End If
            ElseIf controlGrid.GetRowCellValue(e.RowHandle, "Edited") Then
                e.Appearance.BackColor = EDITED_COLOR
                If controlGrid.GetRowCellValue(e.RowHandle, "IsDelete") = True Then
                    e.Appearance.BackColor = Color.LightCoral
                End If
            ElseIf e.RowHandle = controlGrid.FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
                If controlGrid.GetRowCellValue(e.RowHandle, "IsDelete") = True Then
                    e.Appearance.BackColor = Color.LightCoral
                End If
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in SetRowCellStyle() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetRowCellStyle() method in CompetenceTemplate.vb - End--")

            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub RankView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles RankView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub RankView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles RankView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyRank", "Please select a Rank", _hasMainRank)
        'RankValidation(sender, e)
        CheckDuplication(sender, e, "tblAdmCompRank", "FKeyRank", "The selected Rank already existed.")
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "DeleteOther"
                DeleteSubItem()
        End Select
    End Sub

    Private Sub DeleteSubItem()
        If MsgBox("Are you sure want to delete " & IIf(RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "Country") = "", "the Item", RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "Country")) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If IfNull(RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey"), "") <> "" Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template", 10, System.Environment.MachineName, txtName.EditValue, FormName)
                clsAudit.saveAuditPreDelDetails("tblAdmDocCntry", RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblAdmDocCntry", _
                    "PKey='" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'AND FKeyDocGroup='SYSTRAVELDOC'", _
                    "<< Delete Crew Data - " & FormName & " - Country >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & " - Country>", _
                    GetUserName())
                '-->
                DB.RunSql("DELETE FROM dbo.tblAdmDocCntry WHERE PKey='" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'AND FKeyDocGroup='SYSTRAVELDOC'")

                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
            End If
            RankView.DeleteRow(RankView.FocusedRowHandle)
            If RankView.RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
        End If
    End Sub

#End Region
#Region "Certificates"

    Private Sub CertView_FocusedRowObjectChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs) Handles CertView.FocusedRowObjectChanged

    End Sub

    Private Sub CertView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CertView.RowCellStyle
        SetRowCellStyle(CertView, sender, e)
    End Sub

    Private Sub CertView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CertView.CellValueChanged
        _currEditingSub = "Cert"
        If e.Column.FieldName.ToString().Equals("FKeyDocument") Then
            '_currEditingSub = "Cert"
        End If
        If e.Column.FieldName.ToString <> "Edited" Then
            With CertView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If

    End Sub

    Private Sub CertView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CertView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CertView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CertView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("SeverityLevel"), 3)
        view.SetRowCellValue(e.RowHandle, view.Columns("BufferDays"), 30)
        'View.SetRowCellValue(e.RowHandle, View.Columns("FKeyComp"), strID)
        SubAddMode = True
    End Sub

    Private Sub CertView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CertView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasLicCert = False
    End Sub

    Private Sub CertView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CertView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyDocument", "Please select a License Certificate", _hasLicCert)
        If _currEditingSub.Equals("Cert") Then
            'CheckDocuments(sender, e, "tblAdmCompLicCert", "FKeyDocument", "The Certificate selected is already existed in this rank.")

            Dim _view As GridView = sender
            Dim filter As String = String.Format("FKeyDocument='{0}' AND FKeyCntry='{1}' AND FKeyCapacity='{2}'",
                                                 _view.GetFocusedRowCellValue("FKeyDocument"),
                                                 _view.GetFocusedRowCellValue("FKeyCntry"),
                                                 _view.GetFocusedRowCellValue("FKeyCapacity"))
            If IsValidDocument(_view, filter) = False Then
                e.Valid = False
                _hasLicCert = False
                _view.SetColumnError(_view.Columns("FKeyDocument"), "The Certificate selected already exists in this rank.")
            Else
                e.Valid = True
                _hasLicCert = True
                _view.ClearColumnErrors()
            End If
        End If
    End Sub

    Private Sub CertView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles CertView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            CertView.CancelUpdateCurrentRow()
            _hasMainRank = False
        End If
    End Sub

#End Region
#Region "Courses"

    Private Sub CourseView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CourseView.RowCellStyle
        SetRowCellStyle(CourseView, sender, e)
    End Sub

    Private Sub CourseView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CourseView.CellValueChanged
        _currEditingSub = "Course"
        If e.Column.FieldName.ToString().Equals("FKeyCourse") Then
            '_currEditingSub = "Course"
        End If
        If e.Column.FieldName.ToString <> "Edited" Then
            CourseView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub CourseView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CourseView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CourseView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CourseView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("SeverityLevel"), 3)
        view.SetRowCellValue(e.RowHandle, view.Columns("BufferDays"), 30)
        view.SetRowCellValue(e.RowHandle, view.Columns("RepeatCourse"), 0)
        SubAddMode = True
    End Sub

    Private Sub CourseView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CourseView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasCourse = False
    End Sub

    Private Sub CourseView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles CourseView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            CourseView.CancelUpdateCurrentRow()
            _hasCourse = False
        End If
    End Sub

    Private Sub CourseView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CourseView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyCourse", "Please select a Course", _hasCourse)
        If _currEditingSub.Equals("Course") Then
            'CheckDocuments(sender, e, "tblAdmCompCourse", "FKeyCourse", "The Course selected is already existed in this rank.")

            Dim _view As GridView = sender
            Dim filter As String = String.Format("FKeyCourse='{0}'",
                                                 _view.GetFocusedRowCellValue("FKeyCourse"))
            If IsValidDocument(_view, filter) = False Then
                e.Valid = False
                _hasCourse = False
                _view.SetColumnError(_view.Columns("FKeyDocument"), "The Course selected already exists in this rank.")
            Else
                e.Valid = True
                _hasCourse = True
                _view.ClearColumnErrors()
            End If
        End If
    End Sub

#End Region
#Region "Travel Docs"

    Private Sub TravelView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TravelView.RowCellStyle
        SetRowCellStyle(TravelView, sender, e)
    End Sub

    Private Sub TravelView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TravelView.CellValueChanged
        _currEditingSub = "Travel"
        If e.Column.FieldName.ToString().Equals("FKeyDocument") Then
            '_currEditingSub = "Travel"
        End If
        If e.Column.FieldName.ToString <> "Edited" Then
            TravelView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If

    End Sub

    Private Sub TravelView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TravelView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub TravelView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles TravelView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("SeverityLevel"), 3)
        view.SetRowCellValue(e.RowHandle, view.Columns("BufferDays"), 30)
        SubAddMode = True
    End Sub

    Private Sub TravelView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles TravelView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasTravDoc = False
    End Sub

    Private Sub TravelView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles TravelView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            TravelView.CancelUpdateCurrentRow()
            _hasTravDoc = False
        End If
    End Sub
    Private Sub TravelView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles TravelView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyDocument", "Please select a Travel Document", _hasTravDoc)
        If _currEditingSub.Equals("Travel") Then
            'CheckDocuments(sender, e, "tblAdmCompTravDoc", "FKeyDocument", "The Travel Document selected is already existed in this rank.")

            Dim _view As GridView = sender
            Dim filter As String = String.Format("FKeyDocument='{0}' AND FKeyCntry='{1}'",
                                                 _view.GetFocusedRowCellValue("FKeyDocument"),
                                                 _view.GetFocusedRowCellValue("FKeyCntry"))
            If IsValidDocument(_view, filter) = False Then
                e.Valid = False
                _hasTravDoc = False
                _view.SetColumnError(_view.Columns("FKeyDocument"), "The Travel Document selected already exists in this rank.")
            Else
                e.Valid = True
                _hasTravDoc = True
                _view.ClearColumnErrors()
            End If
        End If
    End Sub

#End Region
#Region "Medical Certificates"

    Private Sub MedicalView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MedicalView.RowCellStyle
        SetRowCellStyle(MedicalView, sender, e)
    End Sub

    Private Sub MedicalView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MedicalView.CellValueChanged
        _currEditingSub = "Medical"
        If e.Column.FieldName.ToString().Equals("FKeyDocument") Then
            '_currEditingSub = "Medical"
        End If
        If e.Column.FieldName.ToString <> "Edited" Then
            MedicalView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub MedicalView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MedicalView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub MedicalView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MedicalView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("SeverityLevel"), 3)
        view.SetRowCellValue(e.RowHandle, view.Columns("BufferDays"), 30)
        SubAddMode = True
    End Sub

    Private Sub MedicalView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles MedicalView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasMedCert = False
    End Sub

    Private Sub MedicalView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles MedicalView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            MedicalView.CancelUpdateCurrentRow()
            _hasMedCert = False
        End If
    End Sub

    Private Sub MedicalView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles MedicalView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyDocument", "Please select a Medical Certificate", _hasMedCert)
        If _currEditingSub.Equals("Medical") Then
            'CheckDocuments(sender, e, "tblAdmCompMedCert", "FKeyDocument", "The Medical Certificate selected is already existed in this rank.")

            Dim _view As GridView = sender
            Dim filter As String = String.Format("FKeyDocument='{0}'",
                                                 _view.GetFocusedRowCellValue("FKeyDocument"))
            If IsValidDocument(_view, filter) = False Then
                e.Valid = False
                _hasMedCert = False
                _view.SetColumnError(_view.Columns("FKeyDocument"), "The Medical Certificate selected already exists in this rank.")
            Else
                e.Valid = True
                _hasMedCert = True
                _view.ClearColumnErrors()
            End If
        End If
    End Sub

#End Region
#Region "National Information"

    Private Sub NatInfoView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles NatInfoView.RowCellStyle
        SetRowCellStyle(NatInfoView, sender, e)
    End Sub

    Private Sub NatInfoView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles NatInfoView.CellValueChanged
        _currEditingSub = "NatInfo"
        If e.Column.FieldName.ToString().Equals("FKeyDocument") Then
            '_currEditingSub = "NatInfo"
        End If
        If e.Column.FieldName.ToString <> "Edited" Then
            With NatInfoView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub NatInfoView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles NatInfoView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub NatInfoView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles NatInfoView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("SeverityLevel"), 3)
        view.SetRowCellValue(e.RowHandle, view.Columns("BufferDays"), 30)
        'View.SetRowCellValue(e.RowHandle, View.Columns("FKeyComp"), strID)
        SubAddMode = True
    End Sub

    Private Sub NatInfoView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles NatInfoView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasNatInfo = False
    End Sub

    Private Sub NatInfoView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles NatInfoView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            NatInfoView.CancelUpdateCurrentRow()
            _hasNatInfo = False
        End If
    End Sub

    Private Sub NatInfoView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles NatInfoView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyDocument", "Please select a National Information", _hasNatInfo)
        If _currEditingSub.Equals("NatInfo") Then
            'CheckDocuments(sender, e, "tblAdmCompNatInfo", "FKeyDocument", "The National Information Document selected is already existed in this rank.")

            Dim _view As GridView = sender
            Dim filter As String = String.Format("FKeyDocument='{0}' AND FKeyCntry='{1}'",
                                                 _view.GetFocusedRowCellValue("FKeyDocument"),
                                                 _view.GetFocusedRowCellValue("FKeyCntry"))
            If IsValidDocument(_view, filter) = False Then
                e.Valid = False
                _hasNatInfo = False
                _view.SetColumnError(_view.Columns("FKeyDocument"), "The National Information selected already exists in this rank.")
            Else
                e.Valid = True
                _hasNatInfo = True
                _view.ClearColumnErrors()
            End If
        End If
    End Sub

#End Region
#Region "Vessel Type"

    Private Sub VesselView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles VesselView.RowCellStyle
        SetRowCellStyle(VesselView, sender, e)
    End Sub

    Private Sub VesselView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles VesselView.CellValueChanged
        _currEditingSub = "Vessel"
        If e.Column.FieldName.ToString().Equals("FKeyVslType") Then
            '_currEditingSub = "Vessel"
        End If
        If e.Column.FieldName.ToString <> "Edited" Then
            VesselView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub VesselView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles VesselView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub VesselView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles VesselView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("SeverityLevel"), 3)
        SubAddMode = True
    End Sub

    Private Sub VesselView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles VesselView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasVslType = False
    End Sub

    Private Sub VesselView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles VesselView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            VesselView.CancelUpdateCurrentRow()
            _hasVslType = False
        End If
    End Sub

    Private Sub VesselView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles VesselView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyVslType", "Please select a Vessel Type", _hasVslType)
        ValidateRequiredFields(sender, e, "YrOfService", "Please enter 'Year of Service'", _hasYrOfService)
        If _currEditingSub.Equals("Vessel") Then
            'CheckDocuments(sender, e, "tblAdmCompVslType", "[FKeyVslType]", "The selected Vessel Type is already existed in this rank.")

            Dim _view As GridView = sender
            Dim filter As String = String.Format("FKeyVslType='{0}'",
                                                 _view.GetFocusedRowCellValue("FKeyVslType"))
            If IsValidDocument(_view, filter) = False Then
                e.Valid = False
                _hasVslType = False
                _view.SetColumnError(_view.Columns("FKeyDocument"), "The selected Vessel Type already exists in this rank.")
            Else
                e.Valid = True
                _hasVslType = True
                _view.ClearColumnErrors()
            End If
        End If
    End Sub

#End Region
#Region "Company Defined Types"

    Private Sub CompanyDefinedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CompanyDefinedView.RowCellStyle
        SetRowCellStyle(CompanyDefinedView, sender, e)
    End Sub

    Private Sub CompanyDefinedView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CompanyDefinedView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With CompanyDefinedView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub CompanyDefinedView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CompanyDefinedView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CompanyDefinedView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CompanyDefinedView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        view.SetRowCellValue(e.RowHandle, view.Columns("SeverityLevel"), 3)
        view.SetRowCellValue(e.RowHandle, view.Columns("BufferDays"), 30)
        'View.SetRowCellValue(e.RowHandle, View.Columns("FKeyComp"), strID)
        SubAddMode = True
    End Sub

    Private Sub CompanyDefinedView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles CompanyDefinedView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasCompanyDefined = False
    End Sub

    Private Sub CompanyDefinedView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles CompanyDefinedView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            CompanyDefinedView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub CompanyDefinedView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles CompanyDefinedView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyCompanyDefined", "Please select a Company Defined Type", _hasCompanyDefined)
    End Sub

#End Region
#Region "Required Training"

    Private Sub RequiredTrainingView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles RequiredTrainingView.RowCellStyle
        SetRowCellStyle(RequiredTrainingView, sender, e)
    End Sub

    Private Sub RequiredTrainingView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RequiredTrainingView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            With CompanyDefinedView
                .SetRowCellValue(e.RowHandle, "Edited", True)
            End With
        End If
    End Sub

    Private Sub RequiredTrainingView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles RequiredTrainingView.CellValueChanging
        BRECORDUPDATEDs = True
    End Sub

    Private Sub RequiredTrainingView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles RequiredTrainingView.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        view.SetRowCellValue(e.RowHandle, view.Columns("Edited"), True)
        SubAddMode = True
    End Sub

    Private Sub RequiredTrainingView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles RequiredTrainingView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        _hasCompanyDefined = False
    End Sub

    Private Sub RequiredTrainingView_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles RequiredTrainingView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            RequiredTrainingView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub RequiredTrainingView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles RequiredTrainingView.ValidateRow
        ValidateRequiredFields(sender, e, "FKeyCompRepeatTraining", "Please select a Required Training Type", _hasRequiredTraining)
    End Sub

#End Region
#Region "Manual Deletion Events and Methods"

    Private Sub RankView_GotFocus(sender As Object, e As EventArgs) Handles RankView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Rank")
            _selectedViews = SelectedView.Rank
        End If
    End Sub

    Private Sub CertView_GotFocus(sender As Object, e As EventArgs) Handles CertView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Certificates")
            _selectedViews = SelectedView.Certificate
        End If
    End Sub

    Private Sub CourseView_GotFocus(sender As Object, e As EventArgs) Handles CourseView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Course")
            _selectedViews = SelectedView.Course
        End If
    End Sub

    Private Sub TravelView_GotFocus(sender As Object, e As EventArgs) Handles TravelView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Travel Docs")
            _selectedViews = SelectedView.Travel
        End If
    End Sub

    Private Sub MedicalView_GotFocus(sender As Object, e As EventArgs) Handles MedicalView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Medical Docs")
            _selectedViews = SelectedView.Medical
        End If
    End Sub

    Private Sub NatInfoView_GotFocus(sender As Object, e As EventArgs) Handles NatInfoView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete National Info")
            _selectedViews = SelectedView.NationalInfo
        End If
    End Sub

    Private Sub VesselView_GotFocus(sender As Object, e As EventArgs) Handles VesselView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Vessel")
            _selectedViews = SelectedView.VesselType
        End If
    End Sub

    Private Sub CompanyDefinedView_GotFocus(sender As Object, e As EventArgs) Handles CompanyDefinedView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Company Defined")
            _selectedViews = SelectedView.CompanyDefined
        End If
    End Sub

    Private Sub RequiredTrainingView_GotFocus(sender As Object, e As EventArgs) Handles RequiredTrainingView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Qualification")
            _selectedViews = SelectedView.Competence
        Else
            focusedView = Nothing
            SetDeleteCaption(Name, "Delete Required Training")
            _selectedViews = SelectedView.RequiredTraining
        End If
    End Sub

#End Region
#Region "User-Defined Methods"

    Public Sub ValidateRequiredFields(ByRef sender As Object, ByRef e As ValidateRowEventArgs, colName As String, errMessage As String, Optional ByRef hasTrue As Boolean = False)
        Dim view As GridView = TryCast(sender, GridView)
        Dim column As DevExpress.XtraGrid.Columns.GridColumn = view.Columns(colName)
        If view.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            If view.GetRowCellValue(e.RowHandle, column) Is DBNull.Value Or view.GetRowCellValue(e.RowHandle, column) Is Nothing Then
                e.Valid = False
                view.SetColumnError(column, errMessage)
                view.FocusedColumn = view.VisibleColumns(0)
                hasTrue = False
            Else
                e.Valid = True
                hasTrue = True
            End If
        End If
    End Sub

    Public Sub SetGridReadOnlyProperties(ByRef controlGrid As GridView, Optional isReadOnly As Boolean = True)
        With controlGrid
            Select Case isReadOnly
                Case True
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    .OptionsBehavior.ReadOnly = isReadOnly
                Case Else
                    .OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True
                    .OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True
                    .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    .OptionsBehavior.ReadOnly = isReadOnly
            End Select
        End With
    End Sub

    Public Sub SetGridEnable(Optional enabled As Boolean = True)
        CertGrid.Enabled = enabled
        CourseGrid.Enabled = enabled
        MedicalGrid.Enabled = enabled
        TravelGrid.Enabled = enabled
        NatInfoGrid.Enabled = enabled
        VesselGrid.Enabled = enabled
        CompanyDefinedGrid.Enabled = enabled
        RequiredTrainingGrid.Enabled = enabled
    End Sub

    Public Sub PopulateGridWithDataSource()

        CertGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                             "FROM tblAdmCompLicCert WHERE FKeyCompRank = '" & GetRankCode() & "'")

        CourseGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                               "FROM tblAdmCompCourse WHERE FKeyCompRank = '" & GetRankCode() & "'")

        TravelGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                               "FROM tblAdmCompTravDoc WHERE FKeyCompRank = '" & GetRankCode() & "'")

        MedicalGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                                "FROM tblAdmCompMedCert WHERE FKeyCompRank = '" & GetRankCode() & "'")

        NatInfoGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                                "FROM tblAdmCompNatInfo WHERE FKeyCompRank = '" & GetRankCode() & "'")

        VesselGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                               "FROM tblAdmCompVslType WHERE FKeyCompRank = '" & GetRankCode() & "'")

        CompanyDefinedGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                                       "FROM tblAdmCompCompanyDefined WHERE FKeyCompRank = '" & GetRankCode() & "'")

        RequiredTrainingGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 as BIT) as Edited, CAST(0 as BIT) as IsDelete " & _
                                                         "FROM tblAdmCompRepeatTraining WHERE FKeyCompRank = '" & GetRankCode() & "'")

        PopulateAgeRequirement()
    End Sub

    Public Sub GetItemsForDeletion(ByRef query As ArrayList, ByRef itemsToDelete As ArrayList, tableName As String)
        'Is there anything to delete?
        If itemsToDelete.Count <> 0 Then
            Dim message As String = ""
            If (tableName.Equals("dbo.tblAdmCompRank")) Then
                message = "You are about to delete rank/s. Clicking 'Yes' will also delete the related documents assigned to this rank, proceed?"
            Else
                message = "There are item/s that you marked for deletion. Proceed to delete?"
            End If
            'Yes there is, but are you sure?
            Dim dialogResult As DialogResult = MessageBox.Show(message, "Delete Record" & IIf(itemsToDelete.Count > 1, "s", ""), MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If (dialogResult = Windows.Forms.DialogResult.Yes) Then
                'Yes, we'll delete it one by one. 
                For counter As Integer = 0 To itemsToDelete.Count - 1
                    query.Add("DELETE FROM " & tableName & " WHERE PKey = '" & itemsToDelete(counter).ToString() & "'")
                    '...and also the related documents.
                    If (tableName.Equals("dbo.tblAdmCompRank")) Then
                        For Each table As String In _listOfTables
                            query.Add("DELETE FROM " & table & " WHERE FKeyCompRank ='" & itemsToDelete(counter).ToString() & "'")
                        Next
                    End If
                Next
            End If
            'Nevermind
        End If
    End Sub

    Public Sub GetUpdatedCourses(ByRef query As ArrayList)
        Dim coursesToDelete As New ArrayList
        With CourseView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then

                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyCourse")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Course", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object
                    Dim repeatCourseCycle As Integer = 0

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompCourse (FKeyCompRank," & _
                                                                    "FKeyCourse, " & _
                                                                    "RepeatCourse, " & _
                                                                    "SeverityLevel, " & _
                                                                    "IncludeCC, " & _
                                                                    "IncludeCheckList," & _
                                                                    "IncludeCareerPlan," & _
                                                                    "BufferDays," & _
                                                                    "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyCourse") & "'," & .GetRowCellValue(i, "RepeatCourse") & "," & .GetRowCellValue(i, "SeverityLevel") & "," & _
                                          " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & "," & .GetRowCellValue(i, "BufferDays") & ",'" & LastUpdatedBy & "')")
                    Else

                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompCourse SET FKeyCourse = '" & .GetRowCellValue(i, "FKeyCourse") & "'," & _
                                                                   "IncludeCC = " & includeCC & "," & _
                                                                   "IncludeCheckList = " & includeCheckList & "," & _
                                                                   "IncludeCareerPlan = " & includeCareerPlan & ", " & _
                                                                   "RepeatCourse=" & .GetRowCellValue(i, "RepeatCourse") & ", " & _
                                                                   "SeverityLevel=" & .GetRowCellValue(i, "SeverityLevel") & "," & _
                                                                   "BufferDays=" & .GetRowCellValue(i, "BufferDays") & "," & _
                                                                   "LastUpdatedBy='" & LastUpdatedBy & "' " & _
                                                                   "WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                   "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
                'Get all courses that are marked for deletion.
                Dim isSelectedForDeletion As Object = .GetRowCellValue(i, "IsDelete")
                If (Not IsDBNull(isSelectedForDeletion)) Then
                    If (isSelectedForDeletion = True) Then
                        coursesToDelete.Add(.GetRowCellValue(i, "PKey"))
                    End If
                End If
            Next
            GetItemsForDeletion(query, coursesToDelete, "dbo.tblAdmCompCourse") 'Get Courses that are marked for deletion.
        End With
    End Sub

    Public Sub GetUpdateTravelDocs(ByRef query As ArrayList)
        Dim travelDocsToDelete As New ArrayList
        With TravelView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyDocument")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Travel Document", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompTravDoc (FKeyCompRank," & _
                                                                     "FKeyDocument," & _
                                                                     "FKeyCntry," & _
                                                                     "SeverityLevel, " & _
                                                                     "BufferDays, " & _
                                                                     "IncludeCC," & _
                                                                     "IncludeCheckList," & _
                                                                     "IncludeCareerPlan, " & _
                                                                     "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "', " &
                                  "'" & .GetRowCellValue(i, "FKeyDocument") & "','" & .GetRowCellValue(i, "FKeyCntry") & "'," & .GetRowCellValue(i, "SeverityLevel") & "," & .GetRowCellValue(i, "BufferDays") & ", " & _
                                  " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ", '" & LastUpdatedBy & "')")
                    Else

                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompTravDoc SET FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'," & _
                                                                   "FKeyCntry = '" & .GetRowCellValue(i, "FKeyCntry") & "', " & _
                                                                   "SeverityLevel = " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                                                   "BufferDays = " & .GetRowCellValue(i, "BufferDays") & ", " & _
                                                                   "IncludeCC = " & includeCC & "," & _
                                                                   "IncludeCheckList = " & includeCheckList & "," & _
                                                                   "IncludeCareerPlan = " & includeCareerPlan & ", " & _
                                                                   "LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                                                   "WHERE PKey ='" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                   "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
                'Get all certificates that are marked for deletion.
                Dim isSelectedForDeletion As Object = .GetRowCellValue(i, "IsDelete")
                If (Not IsDBNull(isSelectedForDeletion)) Then
                    If (isSelectedForDeletion = True) Then
                        travelDocsToDelete.Add(.GetRowCellValue(i, "PKey"))
                    End If
                End If
            Next
            If travelDocsToDelete.Count <> 0 Then
                GetItemsForDeletion(query, travelDocsToDelete, "dbo.tblAdmCompTravDoc") 'Get Travel Docs that are marked for deletion.
            End If
        End With
    End Sub

    Public Sub GetUpdatedCertificates(ByRef query As ArrayList)
        With CertView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyDocument")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Certificate", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompLicCert (FKeyCompRank," & _
                                                                     "FKeyDocument," & _
                                                                     "FKeyCntry, " & _
                                                                     "FKeyCapacity," & _
                                                                     "SeverityLevel, " & _
                                                                     "BufferDays, " & _
                                                                     "IncludeCC," & _
                                                                     "IncludeCheckList," & _
                                                                     "IncludeCareerPlan, " & _
                                                                     "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyDocument") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyCntry") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyCapacity") & "'," & _
                                          " " & .GetRowCellValue(i, "SeverityLevel") & "," & _
                                          " " & .GetRowCellValue(i, "BufferDays") & "," & _
                                          " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')")
                    Else

                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompLicCert SET FKeyDocument ='" & .GetRowCellValue(i, "FKeyDocument") & "'," & _
                                                                   "FKeyCntry = '" & .GetRowCellValue(i, "FKeyCntry") & "'," & _
                                                                   "FKeyCapacity = '" & .GetRowCellValue(i, "FKeyCapacity") & "'," & _
                                                                   "IncludeCC = " & includeCC & "," & _
                                                                   "IncludeCheckList = " & includeCheckList & "," & _
                                                                   "IncludeCareerPlan = " & includeCareerPlan & ", " & _
                                                                   "SeverityLevel = " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                                                   "BufferDays = " & .GetRowCellValue(i, "BufferDays") & ", " & _
                                                                   "LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                                                   "WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                   "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
            Next
        End With
    End Sub

    Public Sub GetUpdatedMedicalCertificates(ByRef query As ArrayList)
        Dim medCertToDelete As New ArrayList
        With MedicalView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyDocument")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Medical Certificate", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompMedCert (FKeyCompRank, " & _
                                                                     "FKeyDocument, " & _
                                                                     "SeverityLevel, " & _
                                                                     "BufferDays, " & _
                                                                     "IncludeCC, " & _
                                                                     "IncludeCheckList, " & _
                                                                     "IncludeCareerPlan, " & _
                                                                     "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyDocument") & "', " & .GetRowCellValue(i, "SeverityLevel") & ", " & .GetRowCellValue(i, "BufferDays") & ", " & _
                                          " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')")
                    Else


                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompMedCert SET FKeyDocument ='" & .GetRowCellValue(i, "FKeyDocument") & "', " & _
                                                                   "SeverityLevel = " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                                                   "BufferDays = " & .GetRowCellValue(i, "BufferDays") & ", " & _
                                                                   "IncludeCC = " & includeCC & "," & _
                                                                   "IncludeCheckList = " & includeCheckList & "," & _
                                                                   "IncludeCareerPlan = " & includeCareerPlan & "," & _
                                                                   "LastUpdatedBy= '" & LastUpdatedBy & "' " & _
                                                                   "WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                   "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
            Next
        End With
    End Sub

    Public Sub GetUpdatedNationalInfo(ByRef query As ArrayList)
        With Me.NatInfoView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                Dim includeCC As Object
                Dim includeCheckList As Object
                Dim includeCareerPlan As Object

                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyDocument")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template National Information", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompNatInfo (FKeyCompRank, " & _
                                                                     "FKeyDocument, " & _
                                                                     "FKeyCntry, " & _
                                                                     "SeverityLevel, " & _
                                                                     "BufferDays, " & _
                                                                     "IncludeCC, " & _
                                                                     "IncludeCheckList, " & _
                                                                     "IncludeCareerPlan," & _
                                                                     "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyDocument") & "','" & .GetRowCellValue(i, "FKeyCntry") & "', " & .GetRowCellValue(i, "SeverityLevel") & ", " & .GetRowCellValue(i, "BufferDays") & " " & _
                                          "," & includeCC & "," & includeCheckList & "," & includeCareerPlan & ", '" & LastUpdatedBy & "')")
                    Else

                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompNatInfo SET FKeyDocument ='" & .GetRowCellValue(i, "FKeyDocument") & "', " & _
                                                                   "FKeyCntry ='" & .GetRowCellValue(i, "FKeyCntry") & "', " & _
                                                                   "SeverityLevel = " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                                                   "BufferDays = " & .GetRowCellValue(i, "BufferDays") & ", " & _
                                                                   "IncludeCC = " & includeCC & "," & _
                                                                   "IncludeCheckList = " & includeCheckList & "," & _
                                                                   "IncludeCareerPlan = " & includeCareerPlan & "," & _
                                                                   "LastUpdatedBy= '" & LastUpdatedBy & "'" & _
                                                                   "WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                   "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
            Next
        End With
    End Sub

    Public Sub GetUpdatedVesselType(ByRef query As ArrayList)
        With VesselView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyVslType")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Vessel Type", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompVslType (FKeyCompRank," & _
                                                                     "FKeyVslType, " & _
                                                                     "FKeyRank, " & _
                                                                     "YrOfService, " & _
                                                                     "SeverityLevel, " & _
                                                                     "IncludeCC, " & _
                                                                     "IncludeCheckList," & _
                                                                     "IncludeCareerPlan, " & _
                                                                     "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyVslType") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyRank") & "'," & _
                                          " " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                          "" & .GetRowCellValue(i, "YrOfService") & "," & _
                                          " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')")
                    Else

                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompVslType SET FKeyVslType = '" & .GetRowCellValue(i, "FKeyVslType") & "'," & _
                                                                   "FKeyRank = '" & .GetRowCellValue(i, "FKeyRank") & "'," & _
                                                                   "YrOfService = " & .GetRowCellValue(i, "YrOfService") & "," & _
                                                                   "SeverityLevel = " & .GetRowCellValue(i, "SeverityLevel") & "," & _
                                                                   "IncludeCC = " & includeCC & "," & _
                                                                   "IncludeCheckList = " & includeCheckList & "," & _
                                                                   "IncludeCareerPlan = " & includeCareerPlan & ", " & _
                                                                   "LastUpdatedBy ='" & LastUpdatedBy & "' " & _
                                                                   "WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                   "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
            Next
        End With
    End Sub

    Public Sub GetUpdatedCompanyDefinedTypes(ByRef query As ArrayList)
        With CompanyDefinedView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                Dim includeCC As Object
                Dim includeCheckList As Object
                Dim includeCareerPlan As Object

                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyCompanyDefined")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Company Defined", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompCompanyDefined (FKeyCompRank, " & _
                                                                            "FKeyCompanyDefined, " & _
                                                                            "SeverityLevel, " & _
                                                                            "BufferDays, " & _
                                                                            "IncludeCC, " & _
                                                                            "IncludeCheckList, " & _
                                                                            "IncludeCareerPlan, " & _
                                                                            "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyCompanyDefined") & "'" & _
                                          "," & .GetRowCellValue(i, "SeverityLevel") & " " & _
                                          "," & .GetRowCellValue(i, "BufferDays") & " " & _
                                          "," & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')")

                    Else
                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompCompanyDefined SET FKeyCompanyDefined ='" & .GetRowCellValue(i, "FKeyCompanyDefined") & "', " & _
                                                                   "SeverityLevel = " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                                                   "BufferDays = " & .GetRowCellValue(i, "BufferDays") & ", " & _
                                                                   "IncludeCC = " & includeCC & "," & _
                                                                   "IncludeCheckList = " & includeCheckList & "," & _
                                                                   "IncludeCareerPlan = " & includeCareerPlan & ", " & _
                                                                   "LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                                                   "WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                   "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
            Next
        End With
    End Sub

    Public Sub GetUpdatedRequiredTraining(ByRef query As ArrayList)

        With RequiredTrainingView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries for Update/Delete
                Dim includeCC As Object
                Dim includeCheckList As Object
                Dim includeCareerPlan As Object

                If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                    Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                    RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : " & _
                                                    .GetRowCellDisplayText(i, "FKeyCompRepeatTraining")
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Required Training", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Or IIf(IsDBNull(.GetRowCellValue(i, "IsDelete")), False, True) <> True Then

                        includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                        includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                        includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                        query.Add("INSERT INTO dbo.tblAdmCompRepeatTraining (FKeyCompRank, " & _
                                                                            "FKeyCompRepeatTraining, " & _
                                                                            "IncludeCC, " & _
                                                                            "IncludeCheckList, " & _
                                                                            "IncludeCareerPlan, " & _
                                                                            "LastUpdatedBy) " & _
                                  "VALUES ('" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyCompRepeatTraining") & "'" & _
                                          "," & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')")

                    Else
                        includeCC = IIf(.GetRowCellValue(i, "IncludeCC") = False, 0, 1)
                        includeCheckList = IIf(.GetRowCellValue(i, "IncludeCheckList") = False, 0, 1)
                        includeCareerPlan = IIf(.GetRowCellValue(i, "IncludeCareerPlan") = False, 0, 1)

                        query.Add("UPDATE dbo.tblAdmCompRepeatTraining SET FKeyCompRepeatTraining ='" & .GetRowCellValue(i, "FKeyCompRepeatTraining") & "', " & _
                                                                      "IncludeCC = " & includeCC & "," & _
                                                                      "IncludeCheckList = " & includeCheckList & "," & _
                                                                      "IncludeCareerPlan = " & includeCareerPlan & ", " & _
                                                                      "LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                                                                      "WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "' " & _
                                                                      "AND FKeyCompRank = '" & RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey") & "'")
                    End If
                End If
            Next
        End With
    End Sub

    Public Sub PopulateSeverity(repository As RepositoryItemLookUpEdit)
        Try
            repository.DataSource = DB.CreateTable("SELECT SeverityLevel, SeverityName FROM tblAdmQualificationSeverity ORDER BY SeverityLevel")
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateSeverity() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateSeverity() method in CompetenceTemplate.vb - End--")

            MessageBox.Show("There is an error populating the severity repository : " + ex.Message, GetAppName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            repository.DataSource = Nothing
        End Try

    End Sub

    Public Sub PopulateRepository(tableName As String, criteria As String, repository As RepositoryItemLookUpEdit, Optional OrderByString As String = "")
        Dim query As New System.Text.StringBuilder("SELECT Name, PKey FROM " & tableName)
        Try
            'Dim query As String = "SELECT Name, PKey FROM " & tableName
            query.Append(IIf(criteria.Equals(""), "", " WHERE " & criteria) & " ORDER BY SortCode, Name ASC ")
            repository.DataSource = DB.CreateTable(query.ToString())
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateRepository() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateRepository() method in CompetenceTemplate.vb - End--")

            MessageBox.Show("There is an error populating the repository : " + ex.Message, GetAppName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            repository.DataSource = Nothing
        Finally
            query = Nothing
        End Try

    End Sub


    Private Function GetRankCode() As String
        Try
            Return IIf(RankView.RowCount > 0, RankView.GetRowCellValue(RankView.FocusedRowHandle, "PKey"), "")
        Catch ex As Exception
            LogErrors("--Error Generated in GetRankCode() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetRankCode() method in CompetenceTemplate.vb - End--")

            Return ""
        End Try
    End Function

#End Region

    Private Sub Rep_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepRank.ButtonClick, RepSec.ButtonClick, RepCert.ButtonClick, RepCertCapacity.ButtonClick, RepCertCntry.ButtonClick, RepCourse.ButtonClick, RepTravType.ButtonClick, RepTravCntry.ButtonClick, RepMedical.ButtonClick, RepNatInfoType.ButtonClick, RepNatInfoCntry.ButtonClick, RepVslType.ButtonClick, RepVslTypeRank.ButtonClick, RepCompDefined.ButtonClick, RepRequiredTraining.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

#Region "Validation"

    'Private Sub RankValidation(sender As DevExpress.XtraGrid.Views.Grid.GridView, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs)
    '    Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    Dim _rank As DevExpress.XtraGrid.Columns.GridColumn = _view.Columns("FKeyRank")
    '    Try
    '        With _view
    '            If DB.HasDuplicate("tblAdmCompRank", "FKeyRank = '" & (IfNull(.GetRowCellValue(e.RowHandle, "FKeyRank"), "")) & "'") Then
    '                .SetColumnError(_rank, "Rank Already Exist")
    '                e.Valid = False
    '            End If
    '        End With
    '    Catch ex As Exception
    '        LogErrors("--Error Generated in RankValidation() method in CompetenceTemplate.vb - Start --")
    '        LogErrors(ex.Message)
    '        LogErrors("--Error Generated in RankValidation() method in CompetenceTemplate.vb - End--")

    '    End Try
    'End Sub

    Private Sub CheckDuplication(sender As DevExpress.XtraGrid.Views.Grid.GridView, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs, tableName As String, fieldToCheck As String, message As String)
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim _rank As DevExpress.XtraGrid.Columns.GridColumn = _view.Columns(fieldToCheck)
        Dim dt As DataTable = _view.GridControl.DataSource

        Try
            With _view
                'If DB.HasDuplicate(tableName, fieldToCheck & " = '" & (IfNull(.GetRowCellValue(e.RowHandle, fieldToCheck), "")) & "' AND FKeyComp = '" & _selectedCompetence & "'") Then
                If dt.Select(fieldToCheck & " = '" & (IfNull(.GetRowCellValue(e.RowHandle, fieldToCheck), "") & "'")).CopyToDataTable.Rows.Count <> 0 Then
                    dt = dt.Select(fieldToCheck & " = '" & (IfNull(.GetRowCellValue(e.RowHandle, fieldToCheck), "") & "'")).CopyToDataTable

                    If _view.IsNewItemRow(e.RowHandle) Then
                        .SetColumnError(_rank, message)
                        e.Valid = False
                    Else
                        _hasMainRank = True
                    End If
                Else
                    _hasMainRank = True
                End If

            End With
        Catch ex As Exception
            LogErrors("--Error Generated in CheckDuplication() method in CompetenceTemplate.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in CheckDuplication() method in CompetenceTemplate.vb - End--")

        End Try
    End Sub

    Private Function IsValidDocument(view As GridView, criteria As String)
        Dim dtTemp As DataView = view.DataSource
        Dim dr As DataRow() = dtTemp.ToTable.Select(criteria)
        If dr.Count > 1 Then
            Return False
        End If
        Return True
    End Function

    'Private Sub CheckDocuments(sender As DevExpress.XtraGrid.Views.Grid.GridView, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs, tableName As String, fieldToCheck As String, message As String)
    '    Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    Dim _rank As DevExpress.XtraGrid.Columns.GridColumn = _view.Columns(fieldToCheck)

    '    Try
    '        With _view

    '            If DB.HasDuplicate(tableName, fieldToCheck & " = '" & (IfNull(.GetRowCellValue(e.RowHandle, fieldToCheck), "")) & "' AND FKeyCompRank = '" & _selectedRankId & "'") And
    '                .GetRowCellValue(e.RowHandle, "PKey").ToString().Equals("") Then

    '                .SetColumnError(_rank, message)
    '                e.Valid = False
    '            End If
    '        End With
    '    Catch ex As Exception
    '        LogErrors("--Error Generated in CheckDocuments() method in CompetenceTemplate.vb - Start --")
    '        LogErrors(ex.Message)
    '        LogErrors("--Error Generated in CheckDocuments() method in CompetenceTemplate.vb - End--")

    '    End Try
    'End Sub

#End Region

    Private Sub RankView_DataManagerReset(sender As Object, e As System.EventArgs) Handles RankView.DataManagerReset

    End Sub

    Private Sub btnDuplicate_Click(sender As System.Object, e As System.EventArgs) Handles btnDuplicate.Click
        RankView.UpdateCurrentRow()

        If RankView.FocusedRowHandle >= 0 Then
            If MsgBox("This will duplicate the competence rank [" & RankView.GetFocusedRowCellDisplayText("FKeyRank") & "] and its associated requirements." & vbNewLine & vbNewLine & "Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = MsgBoxResult.Yes Then
                If DuplicateRankCompetence(RankView.FocusedRowHandle) Then
                    RefreshData()
                    Dim rowhandle As Integer = RankView.LocateByValue("PKey", FKeyRank_Duplicated)
                    If rowhandle >= 0 Then
                        RankView.FocusedRowHandle = rowhandle
                    End If
                End If
            End If
        Else
            MsgBox("Please select a valid rank.", MsgBoxStyle.Exclamation)
        End If
        
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub EnableDuplicateRank(Optional isEnable As Boolean = True)
        btnDuplicate.Enabled = isEnable
    End Sub

    Private Function DuplicateRankCompetence(ByVal rowhandle As Integer) As Boolean
        Dim cSQL As String
        Dim bSuccess As Boolean = False
        Dim query As New ArrayList
        Dim Type As String = "Saved"

        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template", 10, System.Environment.MachineName, "Duplicate Rank-" & RankView.GetRowCellDisplayText(rowhandle, "FKeyRank"), FormName)

        cSQL = "INSERT INTO dbo.tblAdmCompRank (FKeyComp, FKeyRank, FKeySecRank, LastUpdatedBy, DateUpdated) " & _
               "VALUES ('" & strID & "','" & RankView.GetRowCellValue(rowhandle, "FKeyRank") & "','" & RankView.GetRowCellValue(rowhandle, "FKeySecRank") & "', '" & LastUpdatedBy & "', getdate())"

        bSuccess = MPSDB.RunSql(cSQL)
        If bSuccess Then
            FKeyRank_Duplicated = MPSDB.GetLastInsertedItem("PKey", "tbladmcomprank")

            If IfNull(FKeyRank_Duplicated, "") <> "" Then
                Dim oDuplicateCompRank As New DuplicateCompRank(Me, FKeyRank_Duplicated)

                With oDuplicateCompRank
                    .GetSQLDuplicateCertificates(query)
                    .GetSQLDuplicateNationalInfo(query)
                    '.GetSQLDuplicateCourses(query)
                    .GetSQLDuplicateMedCert(query)
                    .GetSQLDuplicateTravelDocs(query)
                    .GetSQLDuplicateVesselType(query)
                    .GetSQLDuplicateRequiredTraining(query)
                    .GetSQLDuplicateCompanyDefinedTypes(query)
                End With

                If MPSDB.RunTransaction(query) Then
                    MessageBox.Show(GetMessage(Type), GetAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    MsgBox("The competence rank was successfully duplicated but couldn't duplicate the associated requirments. Please consult your system administrator for assistance.", MsgBoxStyle.Exclamation, GetAppName)

                End If

            Else
                MsgBox("There was a problem duplicating the competence rank. Please consult your system administrator for assistance.", MsgBoxStyle.Exclamation, GetAppName)
            End If
        Else
            MessageBox.Show(GetMessage(Type, False), GetAppName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        Return bSuccess
    End Function

    'Added by Tony20170725
    '#### Remarks: I created a separate class so the codes does not mix up with the main class.
    Private Class DuplicateCompRank
        Public oCompetenceTemplate As CompetenceTemplate
        Public LastUpdatedBy As String
        Public FKeyCompRank As String

        Public Sub New(_CompetenceTemplate As CompetenceTemplate, _FKeyCompRank As String)
            oCompetenceTemplate = _CompetenceTemplate
            FKeyCompRank = _FKeyCompRank
        End Sub

#Region "Property"
        Private ReadOnly Property txtName As DevExpress.XtraEditors.TextEdit
            Get
                Return oCompetenceTemplate.txtName
            End Get
        End Property

        Private ReadOnly Property RankView As DevExpress.XtraGrid.Views.Grid.GridView
            Get
                Return oCompetenceTemplate.RankView
            End Get
        End Property

        Private ReadOnly Property clsAudit As clsAudit
            Get
                Return oCompetenceTemplate.clsAudit
            End Get
        End Property

        Private ReadOnly Property FormName As String
            Get
                Return oCompetenceTemplate.FormName
            End Get
        End Property
#End Region

        Public Sub GetSQLDuplicateCertificates(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.CertView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                        If .GetRowCellDisplayText(i, "FKeyDocument") = "National Certificate Of Competency" Then Beep()
                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(oCompetenceTemplate.RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Certificate - " & .GetRowCellValue(i, "PKey")
                        'Mid(.GetRowCellDisplayText(i, "FKeyDocument").ToString, 1, 200 - cDataDescription.Length)

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                        Dim includeCC As Object
                        Dim includeCheckList As Object
                        Dim includeCareerPlan As Object

                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompLicCert (FKeyCompRank," & _
                                                                         "FKeyDocument," & _
                                                                         "FKeyCntry, " & _
                                                                         "FKeyCapacity," & _
                                                                         "SeverityLevel, " & _
                                                                         "IncludeCC," & _
                                                                         "IncludeCheckList," & _
                                                                         "IncludeCareerPlan, " & _
                                                                         "LastUpdatedBy) " & _
                                      "VALUES ('" & FKeyCompRank & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyDocument") & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyCntry") & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyCapacity") & "'," & _
                                              " " & .GetRowCellValue(i, "SeverityLevel") & "," & _
                                              " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')"

                            'query.Add("INSERT INTO dbo.tblAdmCompLicCert (FKeyCompRank," & _
                            '                                             "FKeyDocument," & _
                            '                                             "FKeyCntry, " & _
                            '                                             "FKeyCapacity," & _
                            '                                             "SeverityLevel, " & _
                            '                                             "IncludeCC," & _
                            '                                             "IncludeCheckList," & _
                            '                                             "IncludeCareerPlan, " & _
                            '                                             "LastUpdatedBy) " & _
                            '          "VALUES ('" & FKeyCompRank & "'," & _
                            '                  "'" & .GetRowCellValue(i, "FKeyDocument") & "'," & _
                            '                  "'" & .GetRowCellValue(i, "FKeyCntry") & "'," & _
                            '                  "'" & .GetRowCellValue(i, "FKeyCapacity") & "'," & _
                            '                  " " & .GetRowCellValue(i, "SeverityLevel") & "," & _
                            '                  " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')")
                            query.Add(cSQL)

                        End If
                    End If
                Next
            End With
        End Sub

        Public Sub GetSQLDuplicateCourses(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.CourseView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then

                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(oCompetenceTemplate.RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Course - " & .GetRowCellValue(i, "PKey")
                        'cDataDescription = cDataDescription & _
                        '    Mid(.GetRowCellDisplayText(i, "FKeyCourse").ToString, 1, 200 - cDataDescription.Length)

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Course", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                        Dim includeCC As Object
                        Dim includeCheckList As Object
                        Dim includeCareerPlan As Object
                        Dim repeatCourseCycle As Integer = .GetRowCellValue(i, "RepeatCourse")

                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompCourse (FKeyCompRank," & _
                                                                        "FKeyCourse, " & _
                                                                        "IncludeCC, " & _
                                                                        "RepeatCourse, " & _
                                                                        "SeverityLevel, " & _
                                                                        "IncludeCheckList," & _
                                                                        "IncludeCareerPlan," & _
                                                                        "LastUpdatedBy, " & _
                                                                        "DateUpdated) " & _
                                      "VALUES ('" & FKeyCompRank & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyCourse") & "'," & " " & includeCC & "," & .GetRowCellValue(i, "RepeatCourse") & "," & .GetRowCellValue(i, "SeverityLevel") & "," & _
                                              includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "', getdate())"

                            query.Add(cSQL)

                        End If
                    End If
                Next
            End With
        End Sub

        Public Sub GetSQLDuplicateTravelDocs(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.TravelView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(oCompetenceTemplate.RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Travel Doc - " & .GetRowCellValue(i, "PKey")
                        'cDataDescription = cDataDescription & _
                        '    Mid(.GetRowCellDisplayText(i, "FKeyDocument").ToString, 1, 200 - cDataDescription.Length)

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Travel Document", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                        Dim includeCC As Object
                        Dim includeCheckList As Object
                        Dim includeCareerPlan As Object

                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompTravDoc (FKeyCompRank," & _
                                                                         "FKeyDocument," & _
                                                                         "FKeyCntry," & _
                                                                         "SeverityLevel, " & _
                                                                         "IncludeCC," & _
                                                                         "IncludeCheckList," & _
                                                                         "IncludeCareerPlan, " & _
                                                                         "LastUpdatedBy, " & _
                                                                         "DateUpdated) " & _
                                      "VALUES ('" & FKeyCompRank & "', " &
                                      "'" & .GetRowCellValue(i, "FKeyDocument") & "','" & .GetRowCellValue(i, "FKeyCntry") & "'," & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                      " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ", '" & LastUpdatedBy & "', getdate())"

                            query.Add(cSQL)
                        End If
                    End If

                Next
            End With
        End Sub

        Public Sub GetSQLDuplicateMedCert(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.MedicalView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(oCompetenceTemplate.RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Medical Cert. - " & .GetRowCellValue(i, "PKey")
                        'cDataDescription = cDataDescription & _
                        '    Mid(.GetRowCellDisplayText(i, "FKeyDocument").ToString, 1, 200 - cDataDescription.Length)

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                        Dim includeCC As Object
                        Dim includeCheckList As Object
                        Dim includeCareerPlan As Object

                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompMedCert (FKeyCompRank, " & _
                                                                     "FKeyDocument, " & _
                                                                     "SeverityLevel, " & _
                                                                     "IncludeCC, " & _
                                                                     "IncludeCheckList, " & _
                                                                     "IncludeCareerPlan, " & _
                                                                     "LastUpdatedBy) " & _
                                  "VALUES ('" & FKeyCompRank & "'," & _
                                          "'" & .GetRowCellValue(i, "FKeyDocument") & "', " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                          " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "')"

                            query.Add(cSQL)
                        End If
                    End If

                Next
            End With
        End Sub

        Public Sub GetSQLDuplicateNationalInfo(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.NatInfoView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object

                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Natl Info - " & .GetRowCellValue(i, "PKey")
                        'cDataDescription = cDataDescription & _
                        '                            Mid(.GetRowCellDisplayText(i, "FKeyDocument").ToString, 1, 200 - cDataDescription.Length)

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template National Information", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompNatInfo (FKeyCompRank, " & _
                                                                         "FKeyDocument, " & _
                                                                         "FKeyCntry, " & _
                                                                         "SeverityLevel, " & _
                                                                         "IncludeCC, " & _
                                                                         "IncludeCheckList, " & _
                                                                         "IncludeCareerPlan," & _
                                                                         "LastUpdatedBy, " & _
                                                                         "DateUpdated) " & _
                                      "VALUES ('" & FKeyCompRank & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyDocument") & "','" & .GetRowCellValue(i, "FKeyCntry") & "', " & .GetRowCellValue(i, "SeverityLevel") & " " & _
                                              "," & includeCC & "," & includeCheckList & "," & includeCareerPlan & ", '" & LastUpdatedBy & "', getdate())"

                            query.Add(cSQL)
                        End If
                    End If
                Next
            End With
        End Sub

        Public Sub GetSQLDuplicateRequiredTraining(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.RequiredTrainingView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object

                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Req. Training - " & .GetRowCellValue(i, "PKey")
                        'cDataDescription = cDataDescription & _
                        '    Mid(.GetRowCellDisplayText(i, "FKeyCompRepeatTraining").ToString, 1, 200 - cDataDescription.Length)


                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Required Training", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompRepeatTraining (FKeyCompRank, " & _
                                                                                "FKeyCompRepeatTraining, " & _
                                                                                "IncludeCC, " & _
                                                                                "IncludeCheckList, " & _
                                                                                "IncludeCareerPlan, " & _
                                                                                "LastUpdatedBy, " & _
                                                                                "DateUpdated) " & _
                                      "VALUES ('" & FKeyCompRank & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyCompRepeatTraining") & "'" & _
                                              "," & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "', getdate())"

                            query.Add(cSQL)

                        End If
                    End If
                Next
            End With
        End Sub

        Public Sub GetSQLDuplicateVesselType(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.VesselView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then
                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Vessel Type - " & .GetRowCellValue(i, "PKey")
                        'cDataDescription = cDataDescription & _
                        '    Mid(.GetRowCellDisplayText(i, "FKeyVslType").ToString, 1, 200 - cDataDescription.Length)

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template Vessel Type", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719

                        Dim includeCC As Object
                        Dim includeCheckList As Object
                        Dim includeCareerPlan As Object

                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompVslType (FKeyCompRank," & _
                                                                         "FKeyVslType, " & _
                                                                         "FKeyRank, " & _
                                                                         "YrOfService, " & _
                                                                         "SeverityLevel, " & _
                                                                         "IncludeCC, " & _
                                                                         "IncludeCheckList," & _
                                                                         "IncludeCareerPlan, " & _
                                                                         "LastUpdatedBy, " & _
                                                                         "DateUpdated) " & _
                                      "VALUES ('" & FKeyCompRank & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyVslType") & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyRank") & "'," & _
                                              " " & .GetRowCellValue(i, "SeverityLevel") & ", " & _
                                              "" & .GetRowCellValue(i, "YrOfService") & "," & _
                                              " " & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "', getdate())"

                            query.Add(cSQL)
                        End If
                    End If
                Next
            End With
        End Sub

        Public Sub GetSQLDuplicateCompanyDefinedTypes(ByRef query As ArrayList)
            If IfNull(FKeyCompRank, "").Equals("") Then Exit Sub

            With oCompetenceTemplate.CompanyDefinedView
                .CloseEditForm()
                .UpdateCurrentRow()
                For i As Integer = 0 To .RowCount - 1
                    'Preparing queries for Update/Delete
                    Dim includeCC As Object
                    Dim includeCheckList As Object
                    Dim includeCareerPlan As Object

                    If Not IsDBNull(.GetRowCellValue(i, "Edited")) Then

                        Dim cDataDescription As String = txtName.EditValue & " : " & _
                                                        "Duplicate Rank-" & RankView.GetRowCellDisplayText(oCompetenceTemplate.RankView.FocusedRowHandle, "FKeyRank") & " : "

                        cDataDescription = cDataDescription & _
                                    "Company Defined - " & .GetRowCellValue(i, "PKey")
                        'cDataDescription = cDataDescription & _
                        '    Mid(.GetRowCellDisplayText(i, "FKeyCompanyDefined").ToString, 1, 200 - cDataDescription.Length)

                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Qualification Template", 10, System.Environment.MachineName, cDataDescription, FormName) 'tony20160719


                        If IfNull(.GetRowCellValue(i, "PKey"), "") <> "" Then

                            '<!-- edited by tony20170907
                            'includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, 1)
                            'includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, 1)
                            'includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, 1)

                            includeCC = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCC")), 0, IIf(.GetRowCellValue(i, "IncludeCC"), 1, 0))
                            includeCheckList = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCheckList")), 0, IIf(.GetRowCellValue(i, "IncludeCheckList"), 1, 0))
                            includeCareerPlan = IIf(IsDBNull(.GetRowCellValue(i, "IncludeCareerPlan")), 0, IIf(.GetRowCellValue(i, "IncludeCareerPlan"), 1, 0))
                            '-->

                            Dim cSQL As String
                            cSQL = "INSERT INTO dbo.tblAdmCompCompanyDefined (FKeyCompRank, " & _
                                                                                "FKeyCompanyDefined, " & _
                                                                                "SeverityLevel, " & _
                                                                                "IncludeCC, " & _
                                                                                "IncludeCheckList, " & _
                                                                                "IncludeCareerPlan, " & _
                                                                                "LastUpdatedBy, " & _
                                                                                "DateUpdated) " & _
                                      "VALUES ('" & FKeyCompRank & "'," & _
                                              "'" & .GetRowCellValue(i, "FKeyCompanyDefined") & "'" & _
                                              "," & .GetRowCellValue(i, "SeverityLevel") & " " & _
                                              "," & includeCC & "," & includeCheckList & "," & includeCareerPlan & ",'" & LastUpdatedBy & "', getdate())"

                            query.Add(cSQL)

                        End If
                    End If
                Next
            End With
        End Sub

    End Class

    Private Sub PopulateAgeRequirement()

        Dim query As String = "SELECT * FROM tblAdmCompAgeReq WHERE FKeyCompRank = '" & GetRankCode() & "'"
        Try
            chkInclude.EditValue = False
            seMinAge.EditValue = 0
            seMaxAge.EditValue = 0

            Dim data As DataTable = DB.CreateTable(query)
            If (Not IsNothing(data)) Then
                If data.Rows.Count > 0 Then
                    For Each d As DataRow In data.Rows
                        chkInclude.EditValue = Convert.ToBoolean(d("IncludeReq").ToString())
                        seMinAge.EditValue = Convert.ToInt32(d("MinAge").ToString())
                        seMaxAge.EditValue = Convert.ToInt32(d("MaxAge").ToString())
                        Return
                    Next
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SaveAgeRequirements(ByRef query As ArrayList)

        Try
            Dim rankCode As String = GetRankCode()

            Dim minAge As String = seMinAge.EditValue.ToString()
            Dim maxAge As String = seMaxAge.EditValue.ToString()
            Dim includeReq As Integer = Convert.ToInt32(chkInclude.EditValue)

            Dim result As String = DB.DLookUp("PKey", "tblAdmCompAgeReq", "", "FKeyCompRank = '" & rankCode & "'")
            If result.Trim().Equals("") Then
                'Need to insert new record for Age requirements.
                query.Add("INSERT INTO tblAdmCompAgeReq(MinAge, MaxAge, FKeyCompRank, IncludeReq, LastUpdatedBy) " & _
                          "VALUES(" & minAge & "," & maxAge & ",'" & rankCode & "'," & includeReq & ", '" & LastUpdatedBy & "') ")
            Else
                'Update the existing Age requirements.
                query.Add("UPDATE tblAdmCompAgeReq SET MinAge = " & minAge & ", " & _
                          "MaxAge = " & maxAge & ", IncludeReq = " & includeReq & ", " & _
                          "LastUpdatedBy = '" & LastUpdatedBy & "' " & _
                          "WHERE FKeyCompRank = '" & rankCode & "'")
            End If
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try

    End Sub

    Private Sub seMinAge_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles seMinAge.EditValueChanged
        Try
            seMaxAge.EditValue = Convert.ToInt32(seMinAge.EditValue) + 1
        Catch ex As Exception
            seMaxAge.EditValue = 0
        End Try
    End Sub

    Private Sub seMaxAge_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles seMaxAge.EditValueChanged
        Try
            Dim currVal As Integer = Convert.ToInt32(seMaxAge.EditValue)
            If (currVal <= Convert.ToInt32(seMinAge.EditValue)) Then
                seMaxAge.EditValue = Convert.ToInt32(seMinAge.EditValue) + 1
            End If
        Catch ex As Exception
            seMaxAge.EditValue = 0
        End Try
    End Sub
End Class
