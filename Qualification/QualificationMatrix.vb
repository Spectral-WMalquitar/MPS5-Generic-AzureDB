Option Explicit On
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text
Imports System.Diagnostics
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Base
Imports System.Reflection
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid

Public Class QualificationMatrix

    Public Shared VesselName As String = ""
    Public Shared VesselType As String = ""
    Public Shared VesselFlag As String = ""
    Public Shared VesselCode As String = ""
    Public TabChanged As Boolean = False

    Dim _downHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
    Protected Mode As Integer = 0 'Mode Merge or Duplicate
    Private TabSelected As Integer

    Dim _onboardTabCrews As New ArrayList
    Dim _allCrewTabCrews As New ArrayList
    Dim _clsSec As New clsSecurity
    Dim _selectedReport1 As String = ""
    Dim _selectedReport2 As String = ""

    Dim _selectedVessel As String = ""
    Dim _onboarCrewsDataTable As DataTable
    Dim _userdatafilterstring As String

    Dim _crewRecordFrom As String = ""

#Region "Easy Edit"

    Private FormName As String = " Qualification Matrix  "
    'Private LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

#End Region

    Private Sub InitControls()
        LayoutControl1.AllowCustomization = False
        _clsSec.propSQLConnStr = MPSDB.GetConnectionString
        tbgcPrintingModes.SelectedTabPageIndex = 0
        AllowSaving(Name, False)
        Refresh()
    End Sub

    Public Overrides Sub Refresh()

        InitialOnboardCrewTab()
        InitializeAllCrewTab()
        InitializeDocumentMappingTab()
    End Sub

    Public Sub InitializeDocumentMappingTab()
        PopulateRepository("dbo.tblAdmDocument", "", RepCertificates)
        PopulateRepository("dbo.tblAdmCourse", "", RepCourses)
        CertCourseGrid.DataSource = DB.CreateTable("SELECT PKey, Name, FKeyDocument, FKeyCourse , CAST(0 as BIT) as Edited " & _
                                                      " FROM tbladmQualificationReportsForMapping ORDER BY Name")
    End Sub

    Public Sub InitialOnboardCrewTab()
        _userdatafilterstring = GetUserFilterString(, , "dbo.tbladmvsl.fkeyprincipal", "dbo.tbladmvsl.fkeyflt")
        _userdatafilterstring = IIf(_userdatafilterstring.Length > 0, "AND " & _userdatafilterstring & " ", "")
        VesselGrid.DataSource = DB.CreateTable("SELECT dbo.tblAdmVsl.PKey, dbo.tblAdmVsl.Name, dbo.tblAdmVslType.Name AS VslType " & _
                                                  "FROM   dbo.tblAdmVsl INNER JOIN dbo.tblAdmVslType ON dbo.tblAdmVsl.FKeyVslType = dbo.tblAdmVslType.PKey WHERE dbo.tblAdmVsl.VslStat = 1 " & _
                                                  _userdatafilterstring & "ORDER BY dbo.tblAdmVsl.Name ")                                 'Populate Vessel List.
        ReportGrid.DataSource = DB.CreateTable("SELECT PKey, Name as 'Name' FROM tblQualificationMatrixReport ORDER BY SortCode ASC")     'Populating Reports Format.
        ReportGrid2.DataSource = DB.CreateTable("SELECT PKey, Name as 'Name' FROM tblQualificationMatrixReport ORDER BY SortCode ASC")    'Populating Reports Format on the next tab.

        _userdatafilterstring = GetUserFilterString(, , "dbo.tbladmvsl.fkeyprincipal", "dbo.tbladmvsl.fkeyflt")
        _userdatafilterstring = IIf(_userdatafilterstring.Length > 0, "AND " & _userdatafilterstring & " ", "")
        PopulateLookUpEdit(cmbVesselName, "SELECT '000000000000000' AS PKey, '                   ' AS Name UNION " & _
                                          "SELECT PKey, Name  FROM dbo.tblAdmVsl WHERE dbo.tblAdmVsl.VslStat = 1 " & _
                                          _userdatafilterstring & " ORDER BY Name ASC")
    End Sub

    Public Sub InitializeAllCrewTab()
        _userdatafilterstring = GetUserFilterString(, "ca_fkeyagent", "ca_fkeyprin", "ca_fkeyflt")
        Dim onboardCrew As DataTable = DB.CreateTable("SELECT DISTINCT * FROM view_GetOnbOfficers " & _
                                                      IIf(_userdatafilterstring.Length > 0, "WHERE " & _userdatafilterstring & " ", "") & _
                                                      "ORDER BY SortCode ASC, FullName")

        OnBoardCrewGrid2.DataSource = onboardCrew
        SelectedCrewGrid.DataSource = DB.CreateTable("SELECT * FROM view_SelectedCrews ")

        _userdatafilterstring = GetUserFilterString(, "fkeyagentcode", "fkeyprincode", "fkeyflt")
        CrewAshoreCrew.DataSource = DB.CreateTable("SELECT DISTINCT PKey, IDNbr, FullName, RankName, SortCode  FROM view_AshoreCrew " & _
                                                   IIf(_userdatafilterstring.Length > 0, "WHERE " & _userdatafilterstring & " ", "") & _
                                                   "ORDER BY SortCode")
    End Sub

    Public Overrides Sub SaveData()
        MyBase.SaveData()
        Dim query As New ArrayList
        header.Focus()

        If MessageBox.Show(String.Format("Save changes in mapping?"),
                           String.Format("Qualification Matrix - Mapping"),
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            RefreshData()
            Return
        End If

        With CertCourseView
            .CloseEditForm()
            .UpdateCurrentRow()
            For i As Integer = 0 To .RowCount - 1
                'Preparing queries to update MPS4
                query.Add("UPDATE dbo.[tbladmQualificationReportsForMapping] " & _
                          " SET FKeyCourse ='" & .GetRowCellValue(i, "FKeyCourse") & "' ," & _
                          " FKeyDocument = '" & .GetRowCellValue(i, "FKeyDocument") & "'," & _
                          " LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                          " WHERE Pkey = '" & .GetRowCellValue(i, "PKey") & "'")
            Next

            If DB.RunTransaction(query) Then
                MessageBox.Show(GetMessage("Updated"), GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Information)
                BRECORDUPDATEDs = False
            End If

        End With
    End Sub

    'Validation Check
    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean
        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If CertCourseView.HasColumnErrors() Then
                ALLOWNEXTS = flag = False
            Else
                ALLOWNEXTS = flag = True
                SaveData()
            End If
        ElseIf res = MsgBoxResult.No Then
            RefreshData()
            flag = False
            ALLOWNEXTS = True
        End If
        Return flag
    End Function

    Public Sub PopulateRepository(nameOfTable As String, criteria As String, repository As RepositoryItemLookUpEdit)
        Dim query As New System.Text.StringBuilder("SELECT Name, PKey, SortCode FROM " & nameOfTable)
        'query.Append(IIf(criteria.Equals(""), "", " WHERE " & criteria) & " ORDER BY Name ASC ")
        repository.DataSource = DB.CreateTable(query.Append(IIf(criteria.Equals(""), "", " WHERE " & criteria) & " ORDER BY Name ASC ").ToString())
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

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()

        SetPreviewReportEnabled(Name, True)
        AllowPrintPreview(Name, True)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        PrintPreviewQualificationMatrixVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)

        SetGridReadOnlyProperties(OnBoardCrewView, True)
        SetGridReadOnlyProperties(ReportView, True)
        SetGridReadOnlyProperties(ReportView2, True)

        InitControls()

    End Sub

#Region "Populate LookUpEdit "
    'Populating Vessel Names
    Public Sub PopulateLookUpEdit(ByRef lookUp As LookUpEdit, query As String)
        Try
            lookUp.Properties.DataSource = DB.CreateTable(query)
        Catch ex As Exception
            LogErrors("--Error Generated in PopulateLookUpEdit() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in PopulateLookUpEdit() method in QualificationMatrix.vb - End--")

            MessageBox.Show(String.Format("There is an error generated: " & ex.Message))
        End Try
    End Sub

#End Region

#Region "Vessel Mode with Crew OnBoard Tab"

    Private Sub VesselView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles VesselView.FocusedRowChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        _selectedVessel = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "PKey")), "", view.GetRowCellValue(e.FocusedRowHandle, "PKey"))

        _userdatafilterstring = GetUserFilterString(, "ca_fkeyagent", "ca_fkeyprin", "ca_fkeyflt")
        _onboarCrewsDataTable = DB.CreateTable("SELECT DISTINCT * FROM view_GetOnbOfficers WHERE FKeyVslCode = '" & _selectedVessel & "' " & _
                                               IIf(_userdatafilterstring.Length > 0, "AND " & _userdatafilterstring & " ", "") & _
                                               "ORDER BY SortCode ASC, FullName")

        OnBoardCrewGrid.DataSource = _onboarCrewsDataTable
        GetOnboardCrewIDs(_onboardTabCrews, _onboarCrewsDataTable)

        SetVesselDetails(_selectedVessel)

    End Sub

    Private Sub SetVesselDetails(sVesselId As String)

        If (sVesselId.Equals("")) Then
            VesselName = ""
            VesselFlag = ""
            VesselType = ""
            VesselCode = ""
        Else
            VesselName = DB.DLookUp("Name", "tblAdmVsl", "", "PKey ='" & sVesselId & "'")
            VesselFlag = DB.DLookUp("Name", "tblAdmCntry", "", "PKey ='" & DB.DLookUp("Flag", "tblAdmVsl", "", "PKey ='" & sVesselId & "'") & "'")
            VesselType = DB.DLookUp("Name", "tblAdmVslType", "", "PKey ='" & DB.DLookUp("FKeyVslType", "tblAdmVsl", "", "PKey ='" & sVesselId & "'") & "'")
            VesselCode = _selectedVessel
        End If

    End Sub

    Private Sub VesselView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VesselView.Click

        bAddMode = False
        VesselView.RefreshRow(VesselView.FocusedRowHandle)

    End Sub

    Private Sub VesselView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles VesselView.RowCellStyle
        If e.RowHandle = VesselView.FocusedRowHandle And Not bAddMode Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub OnBoardView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles OnBoardCrewView.RowCellStyle
        SetRowCellStyle(OnBoardCrewView, sender, e)
    End Sub

    Private Sub ReportView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ReportView.RowCellStyle
        SetRowCellStyle(ReportView, sender, e)
    End Sub

    Private Sub SelectedCrewView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles SelectedCrewView.RowCellStyle
        SetRowCellStyle(SelectedCrewView, sender, e)
    End Sub

    Private Sub ReportView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles ReportView2.RowCellStyle
        SetRowCellStyle(ReportView2, sender, e)
    End Sub

#End Region

    'Get the Crew ID from a DataTable source to an ArrayList container. 
    Public Sub GetOnboardCrewIDs(ByRef localContainer As ArrayList, source As DataTable)

        localContainer.Clear()
        Try
            For Each row As DataRow In source.Rows
                Try
                    localContainer.Add(row("IDNbr"))
                Catch ex As Exception
                    Continue For
                    LogErrors("--Error Generated in GetOnboardCrewIDs() method in QualificationMatrix.vb - Start --")
                    LogErrors(ex.Message)
                    LogErrors("--Error Generated in GetOnboardCrewIDs() method in QualificationMatrix.vb - End--")

                End Try
            Next
        Catch ex As Exception
            LogErrors("--Error Generated in GetOnboardCrewIDs() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetOnboardCrewIDs() method in QualificationMatrix.vb - End--")

            Return
        End Try

    End Sub

    Public Sub GenerateReportByTabSelected(tabSelectedIndex As Integer)

        'Skip if no report has been selected. 
        If (_selectedReport1.Equals("") Or _selectedReport2.Equals("")) Then
            MessageBox.Show("There is no selected report.", "Qualification Matrix", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'Get the report name for opening in Print Preview. The name of the report is the same with the actual report file name. 
        Dim reportName As String

        'Get the source query to be feed to datasource of specified report name. 
        Dim reportSourceQuery As String

        Select Case tabSelectedIndex
            Case 0
                'If no crews onboard on a selected vessel. 
                If _onboarCrewsDataTable.Rows.Count = 0 Then
                    MessageBox.Show("There is no onboard crew on the selected vessel [" & DB.DLookUp("Name", "tblAdmVsl", "", "PKey='" & _selectedVessel & "'") & "].", "Qualification Matrix", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                reportName = DB.DLookUp("ReportFileName", "tblQualificationMatrixReport", "", "PKey ='" & _selectedReport1 & "'")
                reportSourceQuery = DB.DLookUp("SourceQuery", "tblQualificationMatrixReport", "", "PKey='" & _selectedReport1 & "'")
                SetVesselDetails(IIf(IsNothing(VesselView.GetFocusedRowCellValue("PKey")), "", VesselView.GetFocusedRowCellValue("PKey")))
                OpenReport(reportName, ConstructQueryForReport(_onboardTabCrews, reportSourceQuery))

            Case 1
                If SelectedCrewView.RowCount = 0 Then
                    MessageBox.Show("There is no selected crew. Please add a crew by dragging records from Crew Onboard and Crew Ashore lists.",
                                    "Qualification Matrix", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Return
                End If

                reportName = DB.DLookUp("ReportFileName", "tblQualificationMatrixReport", "", "PKey ='" & _selectedReport2 & "'")
                reportSourceQuery = DB.DLookUp("SourceQuery", "tblQualificationMatrixReport", "", "PKey='" & _selectedReport2 & "'")

                Dim selectedCrews As DataTable = SelectedCrewGrid.DataSource
                GetOnboardCrewIDs(_allCrewTabCrews, selectedCrews)
                SetVesselDetails(IIf(IsNothing(cmbVesselName.GetColumnValue("PKey")), "", cmbVesselName.GetColumnValue("PKey")))
                OpenReport(reportName, ConstructQueryForReport(_allCrewTabCrews, reportSourceQuery))

        End Select

    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)

        Select Case param(0)
            Case "Print"
                'Case for Printing.
            Case "PREVIEWREPORT"
                GenerateReportByTabSelected(tbgcPrintingModes.SelectedTabPageIndex)
        End Select

    End Sub

    Private Function ConstructQueryForReport(ByRef crewsSelected As ArrayList, sourceViewName As String) As String

        Dim returnQuery As New StringBuilder("")
        If crewsSelected.Count <> 0 Then
            Dim temp As New StringBuilder("'0',")
            'temp.Append("'0',")
            For Each i As String In crewsSelected
                temp.Append("'" & i & "',")
            Next
            returnQuery.Append("SELECT * FROM " + sourceViewName + " WHERE IDNbr IN (" & temp.ToString().Substring(0, temp.ToString().Length - 1) & ") ORDER BY RankSortCode")
        End If
        Return returnQuery.ToString()

    End Function

    Private Sub OpenReport(reportClassName As String, sourceQuery As String)

        Try
            'There is no report class or source query for the report is specified. 
            If (reportClassName.Equals("") Or sourceQuery.Equals("")) Then
                MessageBox.Show(String.Format("There is no report and/or no crew selected. Report processing will stop."), String.Format("Qualification Matrix Report"),
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            'This raise event will call the constructor of 'reportClassName', supplied with optional 'sourceQuery' for the report. 
            RaiseCustomEvent(Name, New Object() {"Preview", reportClassName, "QualificationMatrixReports", sourceQuery})
            'ExecCustomFunction(New Object() {"Preview", reportClassName, "QualificationMatrixReport", sourceQuery})

        Catch ex As TargetInvocationException
            LogErrors("--Error Generated in OpenReport() method in frmPopupMedHistory.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in OpenReport() method in frmPopupMedHistory.vb - End--")

            MessageBox.Show(ex.Message)
        Catch ex As Exception
            LogErrors("--Error Generated in GetOnboardCrewIDs() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in GetOnboardCrewIDs() method in QualificationMatrix.vb - End--")

            MessageBox.Show("Error encountered while generating the report: " & ex.Message)
        End Try

    End Sub

    Private Sub ReportView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ReportView.FocusedRowChanged

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            _selectedReport1 = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "PKey")),
                                        "", view.GetRowCellValue(e.FocusedRowHandle, "PKey"))
        Catch ex As Exception
            LogErrors("--Error Generated in ReportView_FocusedRowChanged() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in ReportView_FocusedRowChanged() method in QualificationMatrix.vb - End--")

            _selectedReport1 = ""
        End Try

    End Sub

    Private Sub ReportView2_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ReportView2.FocusedRowChanged

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            _selectedReport2 = IIf(IsDBNull(view.GetRowCellValue(e.FocusedRowHandle, "PKey")),
                                        "", view.GetRowCellValue(e.FocusedRowHandle, "PKey"))
            view.Focus()
        Catch ex As Exception
            LogErrors("--Error Generated in ReportView2_FocusedRowChanged() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in ReportView2_FocusedRowChanged() method in QualificationMatrix.vb - End--")

            _selectedReport2 = ""
        End Try
    End Sub

    Private Sub CertCourseView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles CertCourseView.CellValueChanging
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Try
            With view
                Dim gridName As DevExpress.XtraGrid.Columns.GridColumn = .FocusedColumn()

                Select Case gridName.ToString()
                    Case "Certificates"
                        If (Not .GetRowCellValue(.FocusedRowHandle, "FKeyCourse").Equals("")) Then
                            .SetRowCellValue(.FocusedRowHandle, "FKeyCourse", "")
                        End If
                    Case "Courses"
                        If (Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals("")) Then
                            .SetRowCellValue(.FocusedRowHandle, "FKeyDocument", "")
                        End If
                End Select
                .SetRowCellValue(.FocusedRowHandle, "Edited", True)
            End With
            view = Nothing
        Catch ex As Exception
            LogErrors("--Error Generated in CertCourseView_CellValueChanging() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in CertCourseView_CellValueChanging() method in QualificationMatrix.vb - End--")

            MessageBox.Show(String.Format("There is an error in Certificate Course View in Qualification Matrix. : " & ex.Message, ""))
        End Try
    End Sub

    Private Sub CertCourseView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles CertCourseView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub CertCourseView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CertCourseView.RowCellStyle
        SetRowCellStyle(CertCourseView, sender, e)
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
            LogErrors("--Error Generated in SetRowCellStyle() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in SetRowCellStyle() method in QualificationMatrix.vb - End--")

            Debug.WriteLine(ex.Message)
        End Try
    End Sub


    Private Sub tbgcPrintingModes_SelectedPageChanged(sender As System.Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles tbgcPrintingModes.SelectedPageChanged

        Dim hasSave As Integer = _clsSec.hasNoViewPermission("cmdSave", USER_ID, True, userPermDt)

        Select Case tbgcPrintingModes.SelectedTabPageIndex
            Case 0
                AllowSaving(Name, False)
                SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetVesselDetails(IIf(IsNothing(VesselView.GetFocusedRowCellValue("PKey")), "", VesselView.GetFocusedRowCellValue("PKey")))
                SetRibbonPageGroupVisibility(Name, "rpgPrintOption", True)
                'HideGroup(Name, "rpgPrintOption", True)
                TabSelected = 0

            Case 1
                AllowSaving(Name, False)
                SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                SetVesselDetails(IIf(IsNothing(cmbVesselName.GetColumnValue("PKey")), "", cmbVesselName.GetColumnValue("PKey")))
                SetRibbonPageGroupVisibility(Name, "rpgPrintOption", True)

                TabSelected = 1
            Case 2

                AllowSaving(Name, True)
                SetPreviewReportVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                If hasSave = 0 Then
                    SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
                    SetRibbonPageGroupVisibility(Name, "rpgPrintOption", False)
                Else
                    SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
                    SetRibbonPageGroupVisibility(Name, "rpgPrintOption", True)
                End If

                TabSelected = 2
        End Select

    End Sub



    Private Sub cmbVesselName_EditValueChanged(sender As System.Object, e As EventArgs) Handles cmbVesselName.EditValueChanged

        Dim v As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        Try
            _selectedVessel = v.GetColumnValue("PKey").ToString()
            _userdatafilterstring = GetUserFilterString(, "ca_fkeyagent", "ca_fkeyprin", "ca_fkeyflt")
            OnBoardCrewGrid2.DataSource = DB.CreateTable("SELECT DISTINCT * FROM view_GetOnbOfficers WHERE FKeyVslCode = '" & _selectedVessel & "' " & _
                                                         IIf(_userdatafilterstring.Length > 0, "AND " & _userdatafilterstring & " ", "") & _
                                                         "ORDER BY SortCode ASC, FullName")
            SelectedCrewGrid.DataSource = DB.CreateTable("SELECT * FROM view_SelectedCrews ")
        Catch ex As Exception
            LogErrors("--Error Generated in cmbVesselName_EditValueChanged() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in cmbVesselName_EditValueChanged() method in QualificationMatrix.vb - End--")

            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''''''''''''''''''''''''''''Testing - Drag and Drop - 20160203 ''''''''''''''''''''''''''''''''''''''''''''

#Region "All Crew Drag and Drop"
    Private Sub OnBoardCrewView2_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles OnBoardCrewView2.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        _downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not ModifierKeys = Keys.None Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            _downHitInfo = hitInfo
        End If
    End Sub

    Private Sub OnBoardCrewView2_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles OnBoardCrewView2.MouseMove
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not _downHitInfo Is Nothing Then
            Dim dragSize = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(_downHitInfo.HitPoint.X - dragSize.Width / 2, _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                _crewRecordFrom = view.Name
                Dim row As DataRow = view.GetDataRow(_downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                _downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub OnBoardCrewGrid2_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles OnBoardCrewGrid2.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            Select Case Mode
                Case 2 'Duplicate Mode
                    row.Delete()
                Case Else
                    If Not _crewRecordFrom.Equals("CrewAshoreView") Then
                        table.ImportRow(row)
                        row.Delete()
                    End If
            End Select
        End If

        'table.Select("", "Name ASC").CopyToDataTable()
    End Sub

    Private Sub OnBoardCrewGrid2_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles OnBoardCrewGrid2.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub OnBoardCrewView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles OnBoardCrewView2.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.GetRowCellValue(e.RowHandle, "Edited") Is DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") And view.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf view.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = OnBoardCrewView2.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    ''''''''''''''''''''''' Destination - Selected Crew View ''''''''''''''''''''''''''''''''''

    Private Sub SelectedCrewView_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles SelectedCrewView.MouseDown
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        _downHitInfo = Nothing

        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not ModifierKeys = Keys.None Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            _downHitInfo = hitInfo
        End If
    End Sub

    Private Sub SelectedCrewView_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles SelectedCrewView.MouseMove

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not _downHitInfo Is Nothing Then
            Dim dragSize = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(_downHitInfo.HitPoint.X - dragSize.Width / 2, _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                Dim row As DataRow = view.GetDataRow(_downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                _downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub SelectedCrewGrid_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles SelectedCrewGrid.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub SelectedCrewView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles SelectedCrewView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub SelectedCrewGrid_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles SelectedCrewGrid.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        'Dim nrow As DataRow = row.Table
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            table.ImportRow(row)
            row.Delete()
        End If
    End Sub

    ''''''''''''''''''''''' Ashore Crews - 20160203 '''''''''''''''''''''''''''''''''''
    Private Sub CrewAshoreView_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles CrewAshoreView.MouseDown
        Dim view As GridView = CType(sender, GridView)
        _downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not ModifierKeys = Keys.None Then
            Exit Sub
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            _downHitInfo = hitInfo
        End If
    End Sub

    Private Sub CrewAshoreView_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles CrewAshoreView.MouseMove

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not _downHitInfo Is Nothing Then
            Dim dragSize = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(_downHitInfo.HitPoint.X - dragSize.Width / 2, _downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                _crewRecordFrom = view.Name
                Dim row As DataRow = view.GetDataRow(_downHitInfo.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                _downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub CrewAshoreCrew_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles CrewAshoreCrew.DragDrop
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, DevExpress.XtraGrid.GridControl)
        Dim table As DataTable = CType(grid.DataSource, DataTable)
        Dim row As DataRow = CType(e.Data.GetData(GetType(DataRow)), DataRow)
        'Dim gridName As String = grid.Name
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            Select Case Mode
                Case 2 'Duplicate Mode
                    row.Delete()
                Case Else
                    If Not _crewRecordFrom.Equals("OnBoardCrewView2") Then
                        table.ImportRow(row)
                        row.Delete()
                    End If
            End Select
        End If
        'table.Select("", "Name ASC").CopyToDataTable()
    End Sub

    Private Sub CrewAshoreCrew_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles CrewAshoreCrew.DragOver

        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub CrewAshoreView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles CrewAshoreView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.RowHandle = CrewAshoreView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

#End Region

    Private Sub btnVessels_Click(sender As System.Object, e As EventArgs) Handles btnVessels.Click
        Try
            cmbVesselName.ItemIndex = 0
            InitializeAllCrewTab()
        Catch ex As Exception
            LogErrors("--Error Generated in btnVessels_Click() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in btnVessels_Click() method in QualificationMatrix.vb - End--")

            MessageBox.Show("An error has been encountered : " & ex.Message)
        End Try

    End Sub

    Private Sub btnClearCompetence_Click(sender As System.Object, e As EventArgs)
        Try
            InitializeAllCrewTab()
        Catch ex As Exception
            LogErrors("--Error Generated in btnClearCompetence_Click() method in QualificationMatrix.vb - Start --")
            LogErrors(ex.Message)
            LogErrors("--Error Generated in btnClearCompetence_Click() method in QualificationMatrix.vb - End--")

            MessageBox.Show("An error has been encountered : " & ex.Message)
        End Try
    End Sub

    Private Sub tbgcPrintingModes_SelectedPageChanging(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles tbgcPrintingModes.SelectedPageChanging

        If BRECORDUPDATEDs Then
            SaveData()
        End If

    End Sub

    Private Sub QualificationMatrix_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub
End Class
