Option Explicit On

Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraBars
Imports System.Diagnostics
Imports System.Drawing
Imports BaseControl
Imports Planning.PlanningList
Imports Crewing
Imports DevExpress.XtraSplashScreen
Imports MPS4.MPS4DataSources
Imports MPS4.MPS4Functions
Imports DevExpress.XtraBars.Ribbon
Imports System.Reflection
Imports System.Text

Public Class CrewChecklist


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

#End Region

    Dim _selectedCrewId As String
    Dim _selectedCrewRank As String
    Dim _competenceId As String
    Dim _selectedCrewLoc As String
    Dim _crewDueDate As String
    Dim _crewSignOnDate As String
    Dim _reportSourceQuery As String
    Dim _userdatafilterstring As String
    Dim _selectedCrewStatus As String
    Dim _competenceVslTypeQuery As String
    Dim clsAudit As New clsAudit
    Dim competenceSelected As String

    Public Shared CrewSelected As New SelectedCrew
    Public Shared IncludeColors As Boolean

    'Dim mainComp As New List(Of MainCompetence)
    Dim mainComp_Hash As New HashSet(Of MainCompetence)
    Dim vesselComp_Hash As New HashSet(Of VesselCompetence)
    'Dim vesselComp As New List(Of VesselCompetence)

#Region "Easy Edit"
    Private FormName As String = " Crew Checklist  "
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName)
#End Region
        
#Region "Population"

    Private Sub PopulateMainCompetence()
        Try
            'mainComp.Clear()
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
                'mainComp.Add(_mainComp)
                mainComp_Hash.Add(_mainComp)
            Next
            table.Dispose()
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateMainCompetence() method in CrewChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateMainCompetence() method in CrewChecklist.vb - End--")

            MessageBox.Show("An error has been encountered in Crew Check list PopulateMainCompetence() method : " & ex.Message)
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
            LogErrors("--Error Generated in PopulateVesselCompetence() method in CrewChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateVesselCompetence() method in CrewChecklist.vb - End--")
            MessageBox.Show("An error has been encountered in Crew Check list PopulateVesselCompetence() method : " & ex.Message)
        End Try

    End Sub
    'This method will receive a list with a specified user-defined types (T) and convert it to DataTable.
    Public Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
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

#End Region

    Private Sub InitControls()

        LayoutControl1.AllowCustomization = False
        ConfigureView()
        cboFKeyComp.Properties.DataSource = DB.CreateTable("SELECT v.PKey, (v.Name + ' - ( ' + c.Name + ' )') as 'Name' " & _
                                                           "FROM tblAdmComp c INNER JOIN tblAdmVsl v ON c.PKey = v.FKeyComp " & _
                                                           "ORDER BY v.Name ASC ")
        'cboFKeyComp.Properties.DataSource = DB.CreateTable("SELECT * FROM frmVesselCompetence ORDER BY Name ASC")
        Refresh()
    End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        AllowSaving(Name, True)

        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            InitControls()
            LoadSub()
            bLoaded = True
        End If
        If blList.GetID() <> "" Then
            LoadSub()
        End If

    End Sub

    Private Sub LoadSub()

        If Not strID.Trim().Equals("") Then
            _selectedCrewId = strID
            CompetenceDocsGrid.DataSource = Nothing
            VesselTypeGrid.DataSource = Nothing

            mainComp_Hash.Clear()
            vesselComp_Hash.Clear()

            _selectedCrewRank = IIf(IsNothing(cboFKeyRank.EditValue), IfNull(blList.GetFocusedRowData("FKeyRankCode"), ""), cboFKeyRank.EditValue)
            _competenceId = IIf(IsNothing(competenceSelected), "", competenceSelected)
            CrewSelected.SurName = IfNull(blList.GetFocusedRowData("LName"), "")
            CrewSelected.FirstName = IfNull(blList.GetFocusedRowData("FName"), "")
            CrewSelected.MiddleName = IfNull(blList.GetFocusedRowData("MName"), "")
            CrewSelected.RankName = IfNull(blList.GetFocusedRowData("RankName"), "")
            CrewSelected.Competence = IIf(IsNothing(cboFKeyComp.Text), "", cboFKeyComp.Text)
            CrewSelected.CompetenceRank = IIf(IsNothing(cboFKeyRank.Text), "", cboFKeyRank.Text)
            _selectedCrewStatus = IfNull(blList.GetFocusedRowData("StatName"), "")
            Dim locDays As String = DB.DLookUp("TextValue", "tblConfig", "", "Code='EXPIRY_BUFFER'")

            If (_selectedCrewStatus.ToLower().Contains("onboard")) Then
                _crewSignOnDate = IfNull(blList.GetFocusedRowData("DateSOn"), "")
                _crewDueDate = IfNull(blList.GetFocusedRowData("DueDate"), "")
            Else
                _crewSignOnDate = IIf(IsNothing(txtExpectedDateSignOn.EditValue), "", txtExpectedDateSignOn.EditValue)
                _crewDueDate = IIf(IsNothing(txtExpectedDateDue.EditValue), "", txtExpectedDateDue.EditValue)
            End If
            Try
                If (_crewSignOnDate.Trim.Length() > 0 And _crewDueDate.Trim().Length > 0) Then
                    _selectedCrewLoc = DateDiff(DateInterval.Month, Convert.ToDateTime(_crewSignOnDate), Convert.ToDateTime(_crewDueDate)).ToString()
                Else
                    _selectedCrewLoc = ""
                End If
            Catch ex As Exception
                LogErrors("--Error Generated in LoadSub() method in CrewChecklist.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in LoadSub() method in CrewChecklist.vb - End--")
                _selectedCrewLoc = ""
            End Try

            If _competenceId.Trim().Length > 0 Then
                PopulateCompetence(_selectedCrewId, _selectedCrewRank, _competenceId, _crewSignOnDate, IIf(_selectedCrewLoc = "", 0, _selectedCrewLoc))
                lcgCompetenceTemplate.Text = "Qualification Template " + IIf(CrewSelected.Competence.Length > 0, " : " + CrewSelected.Competence, " ") +
                     " | Rank : " + DB.DLookUp("Name", "tblAdmRank", "", "PKey'" + _selectedCrewRank + "'") + " " '+
                '(IIf(locDays.Length > 0, "- ( Length of Contract + " & locDays & " days. )", ""))
            End If
        End If

    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()

        If (CompetenceDocsView.DataRowCount = 0) Then
            Return
        Else
            If MessageBox.Show("Save comments?", "Crew Checklist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                SaveComments()
                LoadSub()
            End If
        End If
        
    End Sub

    Public Overrides Sub Refresh()

    End Sub

    Private Sub LookUpEdit_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyComp.ButtonClick,
                                                                                                                                     cboFKeyRank.ButtonClick,
                                                                                                                                     txtExpectedDateDue.ButtonClick,
                                                                                                                                     txtExpectedDateSignOn.ButtonClick
        ClearLookUpEdit(sender, e)
        LoadSub()
    End Sub

    Private Sub CompetenceDocsView_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles CompetenceDocsView.BeforeLeaveRow
        'header.Focus()
    End Sub

    Private Sub CompetenceDocsView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CompetenceDocsView.RowCellStyle
        Try
            SetRowCellStyle(CompetenceDocsView, sender, e)
            Dim sDocStatus As String = CompetenceDocsView.GetRowCellValue(e.RowHandle, "DocStatus")
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
        Catch ex As Exception
            'The doc status might be null.
        End Try
        
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
            LogErrors("--Error Generated in SetRowCellStyle() method in CrewChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetRowCellStyle() method in CrewChecklist.vb - End--")
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub PopulateCompetence(crewIdNbr As String, currentRank As String, competence As String, dateSon As String, Optional ByVal loc As Integer = 0)

        If dateSon.Trim.Length > 0 Then
            dateSon = CDate(dateSon).ToString("MM-dd-yyyy")
        End If

        _reportSourceQuery = "SELECT *, REPLACE(CONVERT(NVARCHAR, DateExpiry, 106), ' ','-') AS Expiry, REPLACE(CONVERT(NVARCHAR, DateIssue, 106),' ','-') AS Issue, CAST(0 as BIT) as Edited " & _
                             "FROM Checklist('" & crewIdNbr & "','" & currentRank & "','" & competence & "', " & loc & ",'" & dateSon & "') ORDER BY Sorting"
        _competenceVslTypeQuery = "SELECT * FROM GetCompetenceInVesselType('" & crewIdNbr & "','" & currentRank & "','" & competence & "') ORDER BY SortCode "

        Try
            competenceTemplateDataTable = DB.CreateTable(_reportSourceQuery)
            vesselTypeTemplateDataTable = DB.CreateTable(_competenceVslTypeQuery)

            CompetenceDocsGrid.DataSource = competenceTemplateDataTable
            VesselTypeGrid.DataSource = vesselTypeTemplateDataTable

            PopulateMainCompetence()
            PopulateVesselCompetence()

            If (CompetenceDocsGrid.DataSource.Rows.Count = 0) Then
                AllowSaving(Name, False)
            Else
                AllowSaving(Name, True)
            End If
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateCompetence() method in CrewChecklist.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateCompetence() method in CrewChecklist.vb - End--")
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
            Try
                'This raise event will call the constructor of 'reportClassName', supplied with optional 'sourceQuery' for the report. 
                'rptCrewChecklistReport._compSource = ConvertToDataTable(mainComp)
                rptCrewChecklistReport._compSource = ConvertToDataTable(mainComp_Hash)
                rptCrewChecklistReport._vesselSource = ConvertToDataTable(vesselComp_Hash)
                RaiseCustomEvent(Name, New Object() {"Preview", "rptCrewChecklistReport", "Checklist", _reportSourceQuery & "^" & _competenceVslTypeQuery})
            Catch ex As Exception
                LogErrors("--Error Generated in ExecCustomFunction() method in CrewChecklist.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in ExecCustomFunction() method in CrewChecklist.vb - End--")
                Debug.WriteLine("Error encountered while generating the report: " & ex.Message)
            End Try
        End If
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

    Private Sub CrewPlannedView_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        selectedID = _selectedCrewId
    End Sub

    Private Sub header_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles header.Paint

    End Sub

    Private Sub cboFKeyComp_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyComp.EditValueChanged

        competenceSelected = DB.DLookUp("FKeyComp", "tblAdmVsl", "", "PKey = '" & cboFKeyComp.EditValue & "'")
        cboFKeyRank.Properties.DataSource = Nothing
        cboFKeyRank.Properties.DataSource = DB.CreateTable("SELECT r.PKey, r.Name " & _
                                                           "FROM dbo.tblAdmRank r INNER JOIN dbo.tblAdmCompRank cr " & _
                                                           "ON r.PKey = cr.FKeyRank " & _
                                                           "WHERE cr.FKeyComp = '" & competenceSelected & "' " & _
                                                           "ORDER BY r.SortCode ASC")

        LoadSub()
    End Sub

    Private Sub cboFKeyRank_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyRank.EditValueChanged
        LoadSub()
    End Sub

    Private Sub txtExpectedDateSignOn_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtExpectedDateSignOn.EditValueChanged
        LoadSub()
    End Sub

    Private Sub txtExpectedDateDue_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtExpectedDateDue.EditValueChanged
        LoadSub()
    End Sub
End Class
