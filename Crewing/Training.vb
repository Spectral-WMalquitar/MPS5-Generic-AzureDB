Imports DevExpress.XtraEditors

Public Class Training
    'Dim is_clicked As Boolean = False, photo_changed As Boolean = False, photo_path As String
    Dim FormName As String = "Crew Training"
    'Dim LastUpdatedBy As String = GetUserName() & "<" & GetDesc() & "><" & FormName & ">"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Dim tabChanged As Boolean = False, PrevTab As String = ""
    Dim type As String = "", SubHasError = False
    Dim FileList As ArrayList
    Dim DocumentList As New List(Of Dictionary(Of Integer, String))()
    Dim crewGroupID As String = ""
    Dim crewCurrentRank As String = ""

    Dim clsgridflout As New clsGridFlyOut

    '<!-- added by tony20180115
    Dim _DueToRetakeInDays As Integer = 0
    Private Property DueToRetakeInDays As Integer

        Get
            If _DueToRetakeInDays = 0 Then  'if first loaded
                _DueToRetakeInDays = GetUserSetting("DueCourseToRetakeInDays", "0")
                If _DueToRetakeInDays = 0 Then  'if has no value from user settings, set to initial 30 days
                    SaveUserSetting("DueCourseToRetakeInDays", 30)
                    _DueToRetakeInDays = 30
                End If
            End If

            Return _DueToRetakeInDays
        End Get
        Set(value As Integer)
            _DueToRetakeInDays = value
        End Set
    End Property
    '-->

#Region "Base Items"

    Private Sub initControls()

        LayoutControl1.AllowCustomization = False
        TabControl.SelectedTabPageIndex = 0
        'crewGroupID = CrewList.SelectedGroupID
        'crewCurrentRank = CrewList.CrewCurrentRank
        'Training Repository
        Me.repTrainingCourse.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourse ORDER BY Name ASC")
        Me.repTrainingCntry.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCntry ORDER BY Name ASC")
        Me.repTrainingCourseStat.DataSource = getCouseStatus()
        Me.repTrainingCourseType.DataSource = getCourseType()
        Me.repTrainingCourseInst.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCourseInst ORDER BY Name ASC")
        Me.repTrainingDoc.DataSource = DB.CreateTable("SELECT * FROM dbo.frmCourseDocList")
        Me.repTrainingLimit.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmLimit ORDER BY Name ASC")
        RefreshCapacity()
        'Me.repTrainingCapacity.DataSource = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC, SortCode ASC")
        Me.repCurrency.DataSource = DB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmCurr ORDER BY Name ASC")
        AddUnboundColumn(Me.TrainingSub, TrainingGrid, "FileName", "File Name", False)

        ''Education
        'AddUnboundColumn(Me.EducView, EducGrid, "FileName", "File Name", False)

        clsAudit.propSQLConnStr = DB.GetConnectionString
    End Sub

    'Private Sub repositoryCtlButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
    '    Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

    '    If Not IsNothing(_view) Then
    '        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear And _view.GetFocusedRowCellValue().ToString.Length > 0 Then
    '            ClearLookUpEdit(sender, e)
    '            ClearSelectedFilter()
    '            SavedFilterOptionValues.SavedGridControlValues.Remove(IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.FKeyFilterOption), ""), _
    '                                                                  IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.RowSource), ""), _
    '                                                                  IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.RowSourceValueField), ""), _
    '                                                                  IfNull(GridFilterView.GetFocusedRowCellValue(FilterOptionFilterFields.Caption), ""))
    '        End If
    '    End If

    'End Sub

    Private Sub LoadSub()

        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "Educ" 'Education
                'Me.EducView.Focus()
                Me.EducGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_Educ WHERE FKeyIDNbr='" & strID & "' ORDER BY YrStart DESC")
            Case "Training" 'Training
                crewGroupID = CrewList.SelectedGroupID
                crewCurrentRank = CrewList.CrewCurrentRank
                'Me.TrainingView.Focus()
                CreateTrainingSubGrid()
                Me.TrainingGrid.ForceInitialize()
        End Select

        DueToRetakeInDays = 0 'added by tony20180115 - to reset the within days for a course to due taken from the user settings

    End Sub

    'Refresh
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        getSelectedView()
        Me.GroupControl1.Text = IIf(strDesc = "New Record", strDesc, "Training - " & strDesc)
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetPrintBiodataVisiblity(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetPrintListCaption(Name, "Print Biodata")
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetEditCaption(Name, "Add/Edit")
        crewGroupID = CrewList.SelectedGroupID
        crewCurrentRank = CrewList.CrewCurrentRank
        If IsNothing(focusedView) Then AllowDeletion(Name, False)
        If Not bLoaded Then 'Prevent lookup edit to reload data source 
            initControls()
            LoadSub()
            bLoaded = True
            PrevTab = Me.TabControl.SelectedTabPage.Tag
        End If

        If blList.GetID() = "" Then
            'commented out by tony20190716 : adding must be disabled if blList (crew list) does not have any record
            'AddData()
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        Else
            LoadSub()
            MakeReadOnlyListener(Me.LayoutControl1.Root)

            'Education
            EditSubAllowGrid(Me.EducView, False)
            AllowFilePathBtn(repBtnEditEduc, False)

            'Training
            EditSubAllowGrid(Me.TrainingView, False)
            EditSubAllowGrid(Me.TrainingSub, False) 'Training Sub
            AllowFilePathBtn(repTraingSubBtnEdit, False)

            BRECORDUPDATEDs = False
        End If
    End Sub

    'Edit
    Public Overrides Sub EditData()
        MyBase.EditData()
        MyBase.EditData()
        getSelectedView()
        GroupControl1.Focus()
        If isEditdable Then
            RemoveReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, True)
        Else
            ResetControlOnEdit()
            MakeReadOnlyListener(Me.LayoutControl1.Root)
            AllowDeletion(Name, False)
        End If

        'Education
        EditSubAllowGrid(Me.EducView, isEditdable)
        AllowFilePathBtn(repBtnEditEduc, isEditdable)
        'Training
        EditSubAllowGrid(Me.TrainingView, isEditdable)
        EditSubGrid(Me.TrainingSub, isEditdable) 'Training Sub
        AllowFilePathBtn(repTraingSubBtnEdit, isEditdable)

    End Sub

    'Save
    Public Overrides Sub SaveData()
        Me.GroupControl1.Focus()
        FileList = New ArrayList
        Dim CompanyID As String = Trim(IfNull(blList.GetFocusedRowData("COIDNo"), ""))
        Dim info As Boolean = False

        If ((Not HasError) And (Not Me.TrainingView.HasColumnErrors)) And (Not Me.EducView.HasColumnErrors) Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {}) Then
                Select Case IIf(tabChanged, PrevTab, Me.TabControl.SelectedTabPage.Tag)
                    Case "Educ" 'Education
                        info = DB.RunSqls(SaveEducation(strID))
                    Case "Training"
                        'info = DB.RunSqls(SaveTraining(strID))
                        info = SaveTraining(strID)
                End Select
                DocumentLink()
                tabChanged = False
                'info = DB.RunSqls(query)
                BRECORDUPDATEDs = False
                blList.RefreshData()
                If info Then
                    blList.SetSelection(strID)
                    RefreshData()
                    MsgBox(GetMessage("Saved", info), MsgBoxStyle.Information, GetAppName)
                End If
            End If
        Else
            MsgBox(GetMessage("SUB"), MsgBoxStyle.Critical, GetAppName())
        End If
    End Sub

    Public Overrides Function CheckValidateFields(Optional showMsg As Boolean = True) As Boolean

        Dim flag As Boolean = False
        ALLOWNEXTS = flag
        Dim res As MsgBoxResult = MsgBox("Would you like to save the changes you've made?", MsgBoxStyle.Question + vbYesNoCancel + vbDefaultButton3, GetAppName)
        If res = MsgBoxResult.Yes Then
            If TrainingView.HasColumnErrors Or TrainingSub.HasColumnErrors Or EducView.HasColumnErrors Then
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

    'Delete
    Public Overrides Sub DeleteData()
        If IsNothing(focusedView) Then
            'DeleteMain()
        Else
            DeleteSubTable()
        End If
    End Sub

    Private Sub DeleteSubTable()
        Dim GrdView As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim info As Boolean = False, FNames As New ArrayList
        Dim subDesc As String = "", subtblcount As Integer = 0
        Dim DelSQL As String = "", PKey As String = ""
        Dim SubDelSQL As String = "", nsubImgCount As Integer = 0
        Dim hasImgFile As Boolean = False, isTraining As Boolean = False

        Dim oLogDeletionSub As New LogDeletion 'added by tony20180922 : Log Deletion

        With focusedView
            Select Case .Name
                Case TrainingView.Name
                    isTraining = True
                    GrdView = focusedView
                    PKey = IfNull(GrdView.GetRowCellValue(GrdView.FocusedRowHandle, "PKey"), "")
                    subDesc = IfNull(GrdView.GetRowCellDisplayText(GrdView.FocusedRowHandle, "FKeyCourse"), "NewRecord")

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Training", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCourse").ToString.Replace("'", "''"), FormName, strID)

                    clsAudit.saveAuditPreDelDetails("tblcourse", PKey, LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblCourse", _
                        "PKey IN ('" & PKey & "')", _
                        "<< Delete Crew Data - " & FormName & " >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & ">", _
                        GetUserName())
                    '-->

                    DelSQL = "DELETE FROM dbo.tblCourse WHERE PKey='" & PKey & "'"

                    DB.BeginReader("SELECT tDoc.*," & _
                                   " (SELECT COUNT(PKey) FROM dbo.tblDocImage WHERE FKeyCrewDocumentID = tDoc.PKey AND FKeyIDNbr = tDoc.FKeyIDNbr AND FKeyCrewCourse = tdoc.FKeyCrewCourse) AS ImageCount " & _
                                   " FROM dbo.tblDocument tDoc" & _
                                   " WHERE FKeyCrewCourse ='" & PKey & "' AND FKeyIDNbr='" & strID & "'" & _
                                   " ORDER BY ImageCount DESC")
                    subtblcount = 0
                    While DB.Read()
                        hasImgFile = (CInt(IfNull(DB.ReaderItem("ImageCount"), "0")) > 0)
                        If hasImgFile Then
                            Exit While
                        End If
                        subtblcount = subtblcount + 1
                    End While
                    If subtblcount > 0 Then
                        '<!--added by tony20180922 : Log Deletion
                        oLogDeletion.Init()
                        oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                            FormName, _
                            "Crewing", _
                            "tblDocument", _
                            "FKeyCrewCourse IN ('" & PKey & "') AND FKeyIDNbr='" & strID & "'", _
                            "<< Delete Crew Data - " & FormName & " >>", _
                            LogDeletion.DeletionType.Manual, _
                            "Manually Deleted in <" & FormName & ">", _
                            GetUserName())
                        '-->
                        SubDelSQL = "DELETE FROM dbo.tblDocument WHERE FKeyCrewCourse='" & PKey & "' AND FKeyIDNbr='" & strID & "'"
                    End If
                    DB.CloseReader()

                Case TrainingSub.Name
                    isTraining = False
                    Dim _MainView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(TrainingView, DevExpress.XtraGrid.Views.Grid.GridView)
                    Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = _MainView.GetDetailView(_MainView.FocusedRowHandle, 0)
                    GrdView = vw
                    PKey = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "PKey"), "")
                    subDesc = IfNull(vw.GetRowCellDisplayText(vw.FocusedRowHandle, "FKeyDocument"), "NewRecord")

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Training Certificate", 0, System.Environment.MachineName, focusedView.GetRowCellDisplayText(focusedView.FocusedRowHandle, "FKeyDocument").ToString.Replace("'", "''") & " : " & subDesc, FormName, strID)

                    clsAudit.saveAuditPreDelDetails("tblDocument", PKey, LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblDocument", _
                        "PKey IN ('" & PKey & "')", _
                        "<< Delete Crew Data - " & FormName & " - Scanned Image >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Scanned Image>", _
                        GetUserName())
                    '-->

                    DelSQL = "DELETE FROM dbo.tblDocument WHERE PKey='" & PKey & "'"
                    DB.BeginReader("SELECT COUNT(PKey) AS ImageCount FROM dbo.tblDocImage where FKeyCrewDocumentID = '" & PKey & "'")
                    subtblcount = DB.RecordCount()
                    If subtblcount > 0 Then
                        While DB.Read()
                            hasImgFile = (CInt(IfNull(DB.ReaderItem("ImageCount"), "0")) > 0)
                            If hasImgFile Then
                                Exit While
                            End If
                        End While
                    End If
                    DB.CloseReader()
                    If Not PKey.Equals("") Then
                        If MsgBox("Are you sure want to delete the '" & subDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
                            With GrdView
                                If hasImgFile Then
                                    MsgBox("Unable to delete " & subDesc & ". Certificates contains Image File.", MsgBoxStyle.Information, GetAppName())
                                Else
                                    If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                                        If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then
                                            info = DB.RunSql(DelSQL)
                                            If info Then
                                                oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                            End If
                                            deleteDocument(GrdView)
                                        End If
                                    End If
                                    '.DeleteRow(.FocusedRowHandle)
                                    'If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                                End If
                            End With
                        End If
                    End If
                    RefreshData()
                    Exit Sub

                Case EducView.Name
                    isTraining = False
                    GrdView = focusedView
                    PKey = IfNull(GrdView.GetRowCellValue(GrdView.FocusedRowHandle, "PKey"), "")
                    subDesc = IfNull(GrdView.GetRowCellDisplayText(GrdView.FocusedRowHandle, "Degree"), "NewRecord")

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, subDesc, FormName, strID) 'neil	'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Education", 0, System.Environment.MachineName, CleanInput(IfNull(GrdView.GetRowCellValue(GrdView.FocusedRowHandle, "Degree"), "")).ToString.Replace("'", "''"), FormName, strID)

                    clsAudit.saveAuditPreDelDetails("tblEduc", PKey, LastUpdatedBy) 'neil
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblEduc", _
                        "PKey IN ('" & PKey & "')", _
                        "<< Delete Crew Data - " & FormName & " - Education >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & " - Education>", _
                        GetUserName())
                    '-->

                    DelSQL = "DELETE FROM dbo.tblEduc WHERE PKey='" & PKey & "'"


            End Select

            If Not GrdView.Name.Equals("") Then
                With GrdView
                    If MsgBox("Are you sure want to delete the '" & subDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then

                        If isTraining Then
                            If hasImgFile Then
                                MsgBox("Unable to delete " & subDesc & ". Certificates contains Image File.", MsgBoxStyle.Information, GetAppName())
                            Else
                                If subtblcount > 0 Then
                                    If MsgBox("The Training " & subDesc & " contains Crew Certificates. " & vbCrLf & " Do you wish to delete all the certificates under the " & subDesc & "?",
                                           MsgBoxStyle.Critical + MsgBoxStyle.YesNo + vbDefaultButton2, GetAppName()) = MsgBoxResult.Yes Then
                                        DB.RunSql(SubDelSQL) 'Delete Related Certificates
                                        oLogDeletionSub.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    End If
                                End If

                                'Delete MainTable
                                If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                                    If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then
                                        info = DB.RunSql(DelSQL)
                                        If info Then
                                            oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                        End If
                                        deleteDocument(GrdView)
                                    End If
                                End If
                                .DeleteRow(.FocusedRowHandle)
                                If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                            End If
                        Else
                            If Not .GetRowCellValue(.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
                                If Not Trim(IfNull(.GetRowCellValue(.FocusedRowHandle, "PKey"), "")).Equals("") Then
                                    info = DB.RunSql(DelSQL)
                                    If info Then
                                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                                    End If
                                    deleteDocument(GrdView)
                                End If
                            End If
                            .DeleteRow(.FocusedRowHandle)
                            If .RowCount = 0 Then RaiseCustomEvent(Name, New Object() {"DisableDeleteOther"})
                        End If


                    End If
                End With
            End If


        End With

    End Sub

#End Region

#Region "Base Functions"

    Private Sub getSelectedView()
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "Educ"
                'Me.EducView.Focus()
                SetDeleteCaption(Name, "Delete Education")
            Case "Training"
                'Me.TrainingView.Focus()
                SetDeleteCaption(Name, "Delete Training")
        End Select
    End Sub

    Private Sub ViewValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Dim _view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try

            With _view
                Dim AllowDup As Boolean = False
                If .FocusedColumn.FieldName.Equals("FKeyDocument") Then
                    AllowDup = CBool(DB.DLookUp("AllowDuplicate", "tblAdmDocument", "0", "PKey='" & e.Value & "'"))
                    If Not AllowDup Then
                        For i As Integer = 0 To .DataRowCount - 1
                            If i <> (.FocusedRowHandle) Then
                                If e.Value.Equals(.GetRowCellValue(i, .FocusedColumn)) Then
                                    e.Valid = False
                                    e.ErrorText = "Already in use."
                                    .SetColumnError(.FocusedColumn, e.ErrorText)
                                Else
                                    .SetColumnError(.FocusedColumn, "")
                                End If
                            End If
                        Next
                    End If
                Else
                    .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                End If

                If Not .HasColumnErrors Then
                    .SetFocusedRowCellValue(.FocusedColumn, e.Value)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentLink()
        Dim str1 As String = ""
        Dim str() As String
        Dim FileName() As String
        For index = 0 To DocumentList.Count - 1
            Dim SourcePath As String = ""
            Dim idnbr As String = ""
            Dim fTag As String = ""
            Dim DateIssue As String = ""
            str1 = DocumentList(index).Item(index + 1) 'original
            str = str1.Split("|") 'Split the Main String
            FileName = str(1).Split("_") 'Split the File Name
            SourcePath = str(0)
            idnbr = FileName(0)
            fTag = FileName(1)
            DateIssue = FileName(2) & "_" & FileName(3)
            LinkDocument(SourcePath, idnbr, fTag, DateIssue)
        Next
        DocumentList.Clear()

    End Sub

    Private Sub LinkDocument(_SourceFile As String, _IDNbr As String, _FileTag As String, _DateIssue As String)

        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""
        Dim fName As String = ""
        Try
            strDir = FOLDERDIRECTORY & "\" & _IDNbr & "\"
            fileExt = System.IO.Path.GetExtension(_SourceFile)
            fileName = _IDNbr & "_" & _FileTag & "_" & _DateIssue & fileExt
            fName = _IDNbr & "_" & _FileTag & "_" & _DateIssue

            If (Not System.IO.Directory.Exists(strDir)) Then
                System.IO.Directory.CreateDirectory(strDir)
            End If

            If (System.IO.File.Exists(strDir & "\" & fileName)) Then
                replaceCrewDoc(_SourceFile, fName)
            Else
                Dim fP As String = ""
                fP = GenerateCrewFilePath(fName)
                If System.IO.File.Exists(fP) Then
                    Kill(fP)
                End If
                ExportCrewDocToPdf(_SourceFile, _IDNbr, _FileTag, _DateIssue)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
        End Try
    End Sub

    Private Function CheckFileExist(ByVal sourcefile As String, ByVal fileName As String) As Boolean
        Dim files() As String
        Dim res As String = ""
        Dim returnName As String = ""
        Try
            files = System.IO.Directory.GetFiles(GetCrewDocsPath() & fileName.Split("_").GetValue(0).ToString)
            For i As Integer = 0 To files.Count - 1
                If files(i).Contains(fileName) Then
                    Kill(files(i))
                    returnName = CopyCrewDoc(sourcefile, fileName.Split("_").GetValue(0).ToString, fileName.Split("_").GetValue(1).ToString, fileName.Split("_").GetValue(2).ToString)
                    Return returnName
                    Exit Function
                End If
            Next
        Catch ex As System.IO.DirectoryNotFoundException
            res = ""
        End Try
        Return returnName
    End Function

    'Delete Document
    Private Sub deleteDocument(view As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim filePath As String = ""

        If Not IsNothing(view) Then
            Dim PView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
            If Not IsNothing(PView) Then
                Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = PView.GetDetailView(PView.FocusedRowHandle, 0)
                Dim fName As String = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "FilePath"), "")
                With vw
                    filePath = GenerateCrewFilePath(fName)
                End With
            End If

        End If
        'Kill the File, Delete the file
        If Not filePath.Equals("") Then
            Try
                Kill(filePath)
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Function GetFilePathFileName(xRowHandle As Integer, view As DevExpress.XtraGrid.Views.Grid.GridView) As String
        Dim retval As String = "NULL"
        Dim filePath As Object = "", FileName As String = "NULL"

        With view
            If Not .GetRowCellValue(xRowHandle, "FilePath").Equals(System.DBNull.Value) Then
                If Not Trim(.GetRowCellValue(xRowHandle, "FilePath")).Equals("") Then
                    filePath = Trim(.GetRowCellValue(xRowHandle, "FilePath"))
                    retval = "'" & Trim(.GetRowCellValue(xRowHandle, "FileName")) & "'"
                End If
            Else
                retval = "NULL"
            End If
        End With
        Return retval
    End Function

    'View Data
    Private Sub ViewData()
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "Educ" 'Education
                view = Me.EducView
            Case "Training"
                view = Me.TrainingSub

        End Select
        Dim filePath As String = ""

        If Not IsNothing(view) Then
            Dim vw As DevExpress.XtraGrid.Views.Grid.GridView = view.GetDetailView(view.FocusedRowHandle, 0)
            Dim fName As String = ""

            If Not IsNothing(vw) Then
                fName = IfNull(vw.GetRowCellValue(vw.FocusedRowHandle, "FilePath"), "")
            End If

            filePath = GenerateCrewFilePath(fName)


            'If view.Name.Equals("TrainingSub") Then
            '    With view
            '        Dim str As String = ""
            '        Try
            '            str = IfNull(TryCast(TrainingView.GetDetailView(TrainingView.FocusedRowHandle, TrainingView.GetRelationCount(TrainingView.FocusedRowHandle) - 1), DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(TryCast(TrainingView.GetDetailView(TrainingView.FocusedRowHandle, TrainingView.GetRelationCount(TrainingView.FocusedRowHandle) - 1), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle, "FileName"), "")
            '        Catch ex As Exception
            '            str = ""
            '        End Try
            '        If Not str.Equals("") Then
            '            filePath = GenerateCrewFilePath(str)
            '        Else
            '            'MsgBox("File Not Found.", MzsgBoxStyle.Information, GetAppName())
            '            filePath = ""
            '        End If
            '    End With
            'Else

        End If

        Try
            System.Diagnostics.Process.Start(filePath)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try
        'End If

    End Sub

    'Create Buttons for file add
    Private Sub CreateButtons()
        'Education Button
        Dim EducBtn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repBtnEditEduc
        With EducBtn
            .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                  "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                  Nothing, Nothing, Nothing, Nothing))
            '.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
            '                                                                  "Delete", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
            '                                                                  Nothing, Nothing, Nothing, Nothing))
            .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            AddHandler .ButtonPressed, AddressOf repButtonClick
        End With
        'Training Sub File Path
        Dim TraingSubrep As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = repTraingSubBtnEdit
        With TraingSubrep
            .Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
                                                                          "Browse", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
                                                                          Nothing, Nothing, Nothing, Nothing))
            '.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, _
            '                                                              "Delete", 80, True, True, False, DevExpress.Utils.HorzAlignment.Far, _
            '                                                              Nothing, Nothing, Nothing, Nothing))
            .ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            AddHandler .ButtonPressed, AddressOf repButtonClick
        End With

    End Sub

    'Repository Button Click Event
    Private Sub repButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim _Parentview As DevExpress.XtraGrid.Views.Grid.GridView = focusedView.ParentView
        Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim bIndex As Integer = btn.Properties.Buttons.IndexOf(e.Button)
        If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(System.DBNull.Value) Then
            If Not _Parentview.GetRowCellValue(_Parentview.FocusedRowHandle, "PKey").Equals(CStr(_Parentview.FocusedRowHandle)) Then
                Select Case bIndex
                    Case 0 'Browse Button
                        Dim odMain As New System.Windows.Forms.OpenFileDialog
                        'odMain.Filter = "Image File (*.jpg)|*.jpg"
                        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            btn.Text = odMain.SafeFileName
                            focusedView.SetFocusedRowCellValue("FilePath", odMain.FileName.ToString)
                            BRECORDUPDATEDs = True
                        End If
                End Select
            Else
                MsgBox("Save First the Record(s).", MsgBoxStyle.Information, GetAppName)
            End If
        End If


    End Sub

    Private Sub AllowFilePathBtn(ByVal btn As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, Optional ByVal value As Boolean = True)
        For i As Integer = 0 To btn.Buttons.Count - 1
            btn.Buttons(i).Enabled = value
        Next
        btn.ReadOnly = Not value
    End Sub

    Private Sub ReloadCapcity(_view As DevExpress.XtraGrid.Views.Grid.GridView)
        With _view
            If .FocusedColumn.FieldName.Equals("FKeyCertCapacity") And (TypeOf (.ActiveEditor) Is DevExpress.XtraEditors.LookUpEdit) Then
                Dim edit As DevExpress.XtraEditors.LookUpEdit = TryCast(.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                DataViewCapacity = New DataView(tblCapacityMap)
                DataViewCapacity.RowFilter = "FKeyDocument = '" & .GetRowCellValue(.FocusedRowHandle, "FKeyDocument") & "'"
                edit.Properties.DataSource = DataViewCapacity
                If DataViewCapacity.Count < 0 Then
                    .SetFocusedRowCellValue("FKeyCertCapacity", "")
                End If
            End If
        End With
    End Sub

    Private Function getFileTag(ByVal _id As String) As String
        Return DB.DLookUp("FileTag", "dbo.tblAdmDocument", "0", "PKey='" & _id & "'")
    End Function
#End Region

#Region "Training"

    Dim dtMain As New DataTable 'Main Table (Course)
    Dim dtSub As New DataTable 'Sub Table (LicCert)
    Dim tblCapacity As DataTable
    Dim tblCapacityMap As DataTable
    Dim DataViewCapacity As DataView


    'Create Sub Grid
    Private Sub CreateTrainingSubGrid()

        Dim ds2 As New DataSet
        '<!-- edited by tony20180115 - added RetakeCourse field function; removed getrepeattraining for now which data is taken from admin competence
        'dtMain = DB.CreateTable("SELECT *,dbo.GetRepeatTraining('" & strID & "','" & crewGroupID & "','" & crewCurrentRank & "', FKeyCourse) AS 'RepeatTraining' , CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_Training WHERE FKeyIDNbr='" & strID & "' ORDER BY Course ASC")
        dtMain = DB.CreateTable("SELECT *, CAST(0 AS BIT) AS Edited, dbo.GetRetakeCourseWithinDays(dbo.frmCrew_Training.FKeyCourse,dbo.frmCrew_Training.FKeyCntry,dbo.frmCrew_Training.CourseStatus,dbo.frmCrew_Training.DateExpiry) as RetakeCourseWithinDays, dbo.tblAdmCourseRetake.RetakeCourseYear, dbo.tblAdmCourseRetake.RetakeCourseMonth, CourseRetakeCntry.Name RetakeCourseCountry " & _
                                "FROM       dbo.frmCrew_Training LEFT OUTER JOIN " & _
                                "           dbo.tblAdmCourseRetake ON dbo.frmCrew_Training.FKeyCourse = dbo.tblAdmCourseRetake.FKeyCourse AND dbo.frmCrew_Training.FKeyCntry = dbo.tblAdmCourseRetake.FKeyCntry LEFT OUTER JOIN " & _
                                "           dbo.tbladmcntry CourseRetakeCntry ON CourseRetakeCntry.PKey = dbo.tblAdmCourseRetake.FKeyCntry " & _
                                "           WHERE FKeyIDNbr='" & strID & "' ORDER BY Course ASC")
        'end tony -->
        dtSub = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_Training_SubDoc WHERE FKeyIDNbr='" & strID & "'")

        ds2.Tables.Add(dtMain)
        ds2.Tables.Add(dtSub)

        ds2.Tables(0).TableName = "dtMain"
        ds2.Tables(1).TableName = "dtSub"

        If IsNothing(ds2.Relations("TrainingRel")) Then
            ds2.Relations.Add("TrainingRel", ds2.Tables("dtMain").Columns("PKey"), ds2.Tables("dtSub").Columns("FKeyCrewCourse"))
        End If

        Me.TrainingGrid.DataSource = ds2.Tables("dtMain")
        Me.TrainingGrid.ForceInitialize()
        Me.TrainingView.OptionsDetail.AllowExpandEmptyDetails = True

        Me.TrainingGrid.LevelTree.Nodes.Add("TrainingRel", Me.TrainingSub)
        Me.TrainingSub.ViewCaption = "Training Certificates"
        Me.TrainingSub.OptionsView.ShowGroupPanel = False
        Me.TrainingSub.OptionsCustomization.AllowFilter = False


    End Sub

    Public Function SaveTraining(FKeyIDNbr As String) As Boolean
        Dim retval As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString())
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing
        Dim isMainInserted As Boolean = False, insertMainType As Boolean = False
        Dim isSUbInserted As Boolean

        Try
            sqlConn.Open()
            sqlTrans = sqlConn.BeginTransaction

            With Me.TrainingView
                .CloseEditForm()
                .UpdateCurrentRow()

                For i As Integer = 0 To .RowCount - 1
                    Dim MainSql As String = "", MainID As String = ""
                    If .GetRowCellValue(i, "Edited") Then
                        isMainInserted = False
                        Dim dateIssued As String = ChangeToSQLDate(.GetRowCellValue(i, "DateIssue"))
                        Dim dateExpiry As String = ChangeToSQLDate(.GetRowCellValue(i, "DateExpiry"))
                        Dim PlannedDate As String = ChangeToSQLDate(.GetRowCellValue(i, "PlannedStart"))

                        'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCourse"), FormName, strID) 'neil 'tony20160719
                        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Training", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyCourse").ToString.Replace("'", "''"), FormName, strID)

                        If IfNull(.GetRowCellValue(i, "PKey"), "").Equals(CStr(i)) Then
                            insertMainType = True
                            MainSql = "INSERT INTO dbo.tblCourse(" & _
                                      "FKeyIDNbr" & _
                                      ",FKeyCourse" & _
                                      ",FKeyCourseInst" & _
                                      ",FKeyCurr" & _
                                      ",InstCost" & _
                                      ",ExRate" & _
                                      ",FKeyCntry" & _
                                      ",CourseCertNo" & _
                                      ",STCWRef" & _
                                      ",CourseStatus" & _
                                      ",CourseTypeCode" & _
                                      ",PlannedStart" & _
                                      ",Remarks" & _
                                      ",DateIssue" & _
                                      ",DateExpiry" & _
                                      ",LastUpdatedBy)" & _
                                      "VALUES(" & _
                                      "'" & FKeyIDNbr & "'" & _
                                      "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCourse"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCourse") & "'", "NULL") & "" & _
                                      "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCourseInst"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCourseInst") & "'", "NULL") & "" & _
                                      "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCurr"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "NULL") & "" & _
                                      ",'" & .GetRowCellValue(i, "InstCost") & "'" & _
                                      ",'" & .GetRowCellValue(i, "ExRate") & "'" & _
                                      "," & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & "" & _
                                      ",'" & .GetRowCellValue(i, "CourseCertNo") & "'" & _
                                      ",'" & .GetRowCellValue(i, "STCWRef") & "'" & _
                                      ",'" & .GetRowCellValue(i, "CourseStatus") & "'" & _
                                      ",'" & .GetRowCellValue(i, "CourseTypeCode") & "'" & _
                                      "," & PlannedDate & _
                                      ",'" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                                      "," & dateIssued & _
                                      "," & dateExpiry & _
                                      ",'" & Me.LastUpdatedBy & "')"
                        Else
                            insertMainType = False
                            MainID = .GetRowCellValue(i, "PKey")
                            MainSql = "UPDATE dbo.tblCourse SET " & _
                                      "FKeyCourse=" & IIf(IfNull(.GetRowCellValue(i, "FKeyCourse"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCourse") & "'", "NULL") & "" & _
                                      ",FKeyCourseInst=" & IIf(IfNull(.GetRowCellValue(i, "FKeyCourseInst"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCourseInst") & "'", "NULL") & "" & _
                                      ",FKeyCntry=" & IIf(IfNull(.GetRowCellValue(i, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCntry") & "'", "NULL") & _
                                      ",FKeyCurr=" & IIf(IfNull(.GetRowCellValue(i, "FKeyCurr"), "NULL") <> "NULL", "'" & .GetRowCellValue(i, "FKeyCurr") & "'", "NULL") & _
                                      ",InstCost='" & .GetRowCellValue(i, "InstCost") & "'" & _
                                      ",ExRate='" & .GetRowCellValue(i, "ExRate") & "'" & _
                                      ",CourseCertNo='" & .GetRowCellValue(i, "CourseCertNo") & "'" & _
                                      ",STCWRef='" & .GetRowCellValue(i, "STCWRef") & "'" & _
                                      ",CourseStatus='" & .GetRowCellValue(i, "CourseStatus") & "'" & _
                                      ",CourseTypeCode='" & .GetRowCellValue(i, "CourseTypeCode") & "'" & _
                                      ",PlannedStart=" & PlannedDate & _
                                      ",Remarks='" & CleanInput(.GetRowCellValue(i, "Remarks")) & "'" & _
                                      ",DateIssue=" & dateIssued & _
                                      ",DateExpiry=" & dateExpiry & _
                                      ",DateUpdated=(getdate())" & _
                                      ",LastUpdatedBy='" & Me.LastUpdatedBy & "'" & _
                                      " WHERE FKeyIDNbr='" & FKeyIDNbr & "' AND PKey='" & MainID & "'"
                        End If

                        'Insert\Update Main
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTrans
                            cmd.CommandText = MainSql
                            isMainInserted = (cmd.ExecuteNonQuery().Equals(1))
                        End Using

                        If insertMainType Then
                            'get the id of the Inserted Row
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.CommandText = "SELECT [PKey] FROM mps.dbo.tblCourse WHERE ID=IDENT_CURRENT('tblCourse')"
                                cmd.Transaction = sqlTrans
                                MainID = cmd.ExecuteScalar()
                            End Using
                            insertMainType = False
                        End If


                        If isMainInserted Then
                            '============= SUB View TRAINING SUB ====================================================
                            .BeginUpdate()
                            For x As Integer = 0 To .GetRelationCount(i) - 1
                                Dim SubSql As String = "", DocStr As String = ""
                                Dim wasExpanded As Boolean = .GetMasterRowExpandedEx(i, x)
                                If Not wasExpanded Then
                                    .SetMasterRowExpandedEx(i, x, True)
                                End If
                                Dim child As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(.GetDetailView(i, x), DevExpress.XtraGrid.Views.Grid.GridView)
                                With child
                                    .CloseEditForm()
                                    .UpdateCurrentRow()
                                    'If .RowCount > 0 Then
                                    Dim count As Integer = 0
                                    For childRH As Integer = 0 To .RowCount
                                        isSUbInserted = False
                                        If .GetRowCellValue(childRH, "Edited") Then
                                            Dim dateIssuedSub As String = ChangeToSQLDate(.GetRowCellValue(childRH, "DateIssue"))
                                            Dim dateExpirySub As String = ChangeToSQLDate(.GetRowCellValue(childRH, "DateExpiry"))

                                            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument"), FormName, strID) 'neil
                                            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Training Certificate", 0, System.Environment.MachineName, .GetRowCellDisplayText(.FocusedRowHandle, "FKeyDocument").ToString.Replace("'", "''"), FormName, strID)

                                            If IfNull(.GetRowCellValue(childRH, "PKey"), "") = "" Then
                                                SubSql = "INSERT INTO dbo.tblDocument(" & _
                                                           "FKeyIDNbr," & _
                                                           "FileTag, " & _
                                                           "FKeyDocument," & _
                                                           "Number," & _
                                                           "DateIssue," & _
                                                           "DateExpiry," & _
                                                           "IssuedBy," & _
                                                           "IssuedPlace," & _
                                                           "FKeyCntry," & _
                                                           "FKeyCertCapacity," & _
                                                           "CertRegulation," & _
                                                           "FKeyCertLimit," & _
                                                           "isActive," & _
                                                           "CertAuthority," & _
                                                           "FKeyCrewCourse," & _
                                                           "FilePath," & _
                                                           "Remarks," & _
                                                           "LastUpdatedBy)" & _
                                                            "VALUES(" & _
                                                            "'" & FKeyIDNbr & "'" & _
                                                            ",'" & .GetRowCellValue(childRH, "FileTag") & "'" & _
                                                            ",'" & .GetRowCellValue(childRH, "FKeyDocument") & "'" & _
                                                            ",'" & .GetRowCellValue(childRH, "Number") & "'" & _
                                                            "," & dateIssuedSub & _
                                                            "," & dateExpirySub & _
                                                            ",'" & .GetRowCellValue(childRH, "IssuedBy") & "'" & _
                                                            ",'" & .GetRowCellValue(childRH, "IssuedPlace") & "'" & _
                                                            "," & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCntry") & "'", "NULL") & "" & _
                                                            "," & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCertCapacity"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCertCapacity") & "'", "NULL") & "" & _
                                                            ",'" & .GetRowCellValue(childRH, "CertRegulation") & "'" & _
                                                            "," & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCertLimit"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCertLimit") & "'", "NULL") & "" & _
                                                            ",'" & CleanInput(.GetRowCellValue(childRH, "isActive")) & "'" & _
                                                            ",'" & CleanInput(.GetRowCellValue(childRH, "CertAuthority")) & "'" & _
                                                            ",'" & MainID & "'" & _
                                                            "," & GetFilePathFileName(childRH, child) & _
                                                            ",'" & CleanInput(.GetRowCellValue(childRH, "Remarks")) & "'" & _
                                                            ",'" & LastUpdatedBy & "')"
                                            Else
                                                'NEIL SubSql = "UPDATE dbo.tblDocument SET " & _
                                                '          "FileTag = '" & .GetRowCellValue(childRH, "FileTag") & "'" & _
                                                '          ",FKeyDocument = '" & .GetRowCellValue(childRH, "FKeyDocument") & "'" & _
                                                '          ",Number = '" & .GetRowCellValue(childRH, "Number") & "'" & _
                                                '          ",DateIssue = " & dateIssuedSub & _
                                                '          ",DateExpiry = " & dateExpirySub & _
                                                '          ",IssuedBy = '" & CleanInput(.GetRowCellValue(childRH, "IssuedBy")) & "'" & _
                                                '          ",IssuedPlace = '" & CleanInput(.GetRowCellValue(childRH, "IssuedPlace")) & "'" & _
                                                '          ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCntry") & "'", "NULL") & "" & _
                                                '          ",FKeyCertCapacity = " & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCertCapacity"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCertCapacity") & "'", "NULL") & "" & _
                                                '          ",CertRegulation = '" & .GetRowCellValue(childRH, "CertRegulation") & "'" & _
                                                '          ",FKeyCertLimit = " & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCertLimit"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCertLimit") & "'", "NULL") & "" & _
                                                '          ",isActive = '" & .GetRowCellValue(childRH, "isActive") & "'" & _
                                                '          ",CertAuthority = '" & CleanInput(.GetRowCellValue(childRH, "CertAuthority")) & "'" & _
                                                '          ",FilePath = " & GetFilePathFileName(childRH, child) & _
                                                '          ",Remarks = '" & .GetRowCellValue(childRH, "Remarks") & "'" & _
                                                '          ",DateUpdated = (getdate())" & _
                                                '          ",LastUpdatedBy = '" & .GetRowCellValue(childRH, "LastUpdatedBy") & "'" & _
                                                '          " WHERE FKeyIDNbr = '" & FKeyIDNbr & "' AND PKey='" & .GetRowCellValue(childRH, "PKey") & "' AND FKeyCrewCourse = '" & MainID & "'"

                                                SubSql = "UPDATE dbo.tblDocument SET " & _
                                                          "FileTag = '" & .GetRowCellValue(childRH, "FileTag") & "'" & _
                                                          ",FKeyDocument = '" & .GetRowCellValue(childRH, "FKeyDocument") & "'" & _
                                                          ",Number = '" & .GetRowCellValue(childRH, "Number") & "'" & _
                                                          ",DateIssue = " & dateIssuedSub & _
                                                          ",DateExpiry = " & dateExpirySub & _
                                                          ",IssuedBy = '" & CleanInput(.GetRowCellValue(childRH, "IssuedBy")) & "'" & _
                                                          ",IssuedPlace = '" & CleanInput(.GetRowCellValue(childRH, "IssuedPlace")) & "'" & _
                                                          ",FKeyCntry = " & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCntry"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCntry") & "'", "NULL") & "" & _
                                                          ",FKeyCertCapacity = " & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCertCapacity"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCertCapacity") & "'", "NULL") & "" & _
                                                          ",CertRegulation = '" & .GetRowCellValue(childRH, "CertRegulation") & "'" & _
                                                          ",FKeyCertLimit = " & IIf(IfNull(.GetRowCellValue(childRH, "FKeyCertLimit"), "NULL") <> "NULL", "'" & .GetRowCellValue(childRH, "FKeyCertLimit") & "'", "NULL") & "" & _
                                                          ",isActive = '" & .GetRowCellValue(childRH, "isActive") & "'" & _
                                                          ",CertAuthority = '" & CleanInput(.GetRowCellValue(childRH, "CertAuthority")) & "'" & _
                                                          ",FilePath = " & GetFilePathFileName(childRH, child) & _
                                                          ",Remarks = '" & .GetRowCellValue(childRH, "Remarks") & "'" & _
                                                          ",DateUpdated = (getdate())" & _
                                                          ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                                          " WHERE FKeyIDNbr = '" & FKeyIDNbr & "' AND PKey='" & .GetRowCellValue(childRH, "PKey") & "' AND FKeyCrewCourse = '" & MainID & "'"
                                            End If

                                            Using cmd As New SqlClient.SqlCommand
                                                cmd.Connection = sqlConn
                                                cmd.Transaction = sqlTrans
                                                'cmd.CommandText = CStr(SubSql(childRH))
                                                cmd.CommandText = SubSql
                                                isSUbInserted = (cmd.ExecuteNonQuery().Equals(1))
                                            End Using
                                        End If

                                    Next
                                    'insert Child
                                    'For nCount As Integer = 0 To SubSql.Count
                                    '    Using cmd As New SqlClient.SqlCommand
                                    '        cmd.Connection = sqlConn
                                    '        cmd.Transaction = sqlTrans
                                    '        cmd.CommandText = SubSql(nCount)
                                    '        isSUbInserted = (cmd.ExecuteNonQuery().Equals(1))
                                    '    End Using
                                    'Next
                                    'If .RowCount <= 0 Then
                                    '    isSUbInserted = True
                                    'End If
                                    'Else
                                    'isSUbInserted = True
                                    'End If
                                End With
                            Next
                            .EndUpdate()
                            '============= SUB View TRAINING SUB ====================================================
                        End If
                    End If
                Next
            End With

            'If isMainInserted And isSUbInserted Then
            sqlTrans.Commit()
            retval = True
            'End If
        Catch ex As Exception
            retval = False
            DocumentList.Clear()
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retval
    End Function

    Private Sub TrainingView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TrainingView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.TrainingView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub TrainingView_GotFocus(sender As Object, e As System.EventArgs) Handles TrainingView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Training")
        End If
    End Sub

    Private Sub TrainingView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles TrainingView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "PKey", View.RowCount)
        SubAddMode = True
    End Sub

    Private Sub TrainingView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles TrainingView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

    End Sub

    Private Sub TrainingView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TrainingView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.TrainingView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub TrainingView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TrainingView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ''Required FieldsNames
        Dim strRequiredFieldName As String = "FKeyCourse;CourseStatus;"
        ViewRowCellStyle(sender, e, strRequiredFieldName)
        'With view
        '    If InStr(1, strRequiredFieldName, e.Column.FieldName) > 0 Then
        '        e.Appearance.BackColor = REQUIRED_COLOR
        '        If .GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
        '            e.Appearance.BackColor = SEL_COLOR
        '        ElseIf .GetRowCellValue(e.RowHandle, "Edited") And .FocusedRowHandle = e.RowHandle Then
        '            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        '        ElseIf .GetRowCellValue(e.RowHandle, "Edited") Then
        '            e.Appearance.BackColor = EDITED_COLOR
        '        ElseIf e.RowHandle = .FocusedRowHandle Then
        '            e.Appearance.BackColor = SEL_COLOR
        '        End If
        '    ElseIf .IsRowSelected(e.RowHandle) Then
        '        e.Appearance.BackColor = SEL_COLOR
        '        e.Appearance.ForeColor = System.Drawing.Color.Black
        '    End If
        'End With
    End Sub

    Private Sub TrainingView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles TrainingView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub TrainingView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles TrainingView.ValidatingEditor
        If SubAddMode Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            With view
                If .FocusedColumn.FieldName.Equals("FKeyCourseInst") Then
                    Dim CourseID As String = IfNull(view.GetRowCellValue(view.FocusedRowHandle, "FKeyCourse"), "")
                    .SetRowCellValue(.FocusedRowHandle, .FocusedColumn, e.Value)
                    .SetRowCellValue(.FocusedRowHandle, "FKeyCntry", getCourseCountry(e.Value))
                    .SetRowCellValue(.FocusedRowHandle, "FKeyCurr", getCourseInstFKeyCurr(CourseID, e.Value))
                    .SetRowCellValue(.FocusedRowHandle, "InstCost", getCourseInstAmt(CourseID, e.Value))
                End If
                If .FocusedColumn.FieldName.Equals("FKeyCourse") Then
                    .SetRowCellValue(.FocusedRowHandle, "CourseTypeCode", getCourseTypeT(e.Value))
                    .SetRowCellValue(.FocusedRowHandle, .FocusedColumn, e.Value)
                    .SetRowCellValue(.FocusedRowHandle, "STCWRef", getSTCW(IfNull(.GetFocusedRowCellValue("FKeyCourse"), "")))
                End If
            End With

        End If
    End Sub

    Private Sub TrainingView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles TrainingView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Course As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCourse")
        Dim CourseStat As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("CourseStatus")
        Dim Cntry As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyCntry")
        'Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")

        With view

            'Validate Course
            If .GetRowCellValue(e.RowHandle, Course) IsNot System.DBNull.Value And .GetRowCellValue(e.RowHandle, Course) IsNot Nothing Then
                '.SetRowCellValue(e.RowHandle, Course, getFileTag(.GetRowCellValue(e.RowHandle, Course)))
            ElseIf .GetRowCellValue(e.RowHandle, Course) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Course) Is Nothing Then
                .SetColumnError(Course, "Please select Course.")
                e.Valid = False
            Else
                .SetColumnError(Course, "")
            End If

            'Validate Country
            If .GetRowCellValue(e.RowHandle, Cntry) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Cntry) Is Nothing Then
                .SetColumnError(Cntry, "Please select Country.")
                e.Valid = False
            Else
                .SetColumnError(Cntry, "")
            End If

            'Validate Course Status
            If .GetRowCellValue(e.RowHandle, CourseStat) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, CourseStat) Is Nothing Then
                .SetColumnError(CourseStat, "Please Select Course Status.")
                e.Valid = False
            Else
                '.ClearColumnErrors()
                .SetColumnError(CourseStat, "")
            End If

            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If

        End With

    End Sub

    Private Function getSTCW(ByVal _id As String) As String
        Return DB.DLookUp("STCWRef", "dbo.tblAdmCourse", "", "PKey='" & _id & "'")
    End Function

    Private Function getCourseTypeT(ByVal _id As String) As String
        Return DB.DLookUp("CourseTypeCode", "dbo.tblAdmCourse", "", "PKey='" & _id & "'")
    End Function

    Private Function getCourseCountry(_id As String) As String
        Return DB.DLookUp("FKeyCntry", "dbo.tblAdmCourseInst", "", "PKey='" & _id & "'")
    End Function

    Private Function getCourseInstFKeyCurr(CourseID As String, InstID As String) As String
        Return DB.DLookUp("FKeyCurrency", "dbo.tblAdmCourseInstDet", "", "FKeyCourseInst='" & InstID & "' AND FKeyCourse ='" & CourseID & "'")
    End Function

    Private Function getCourseInstAmt(CourseID As String, InstID As String) As String
        Return DB.DLookUp("Amt", "dbo.tblAdmCourseInstDet", 0, "FKeyCourseInst='" & InstID & "' AND FKeyCourse ='" & CourseID & "'")
    End Function


#Region "Training Sub"

    Private Sub TrainingSub_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TrainingSub.CellValueChanged
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'With view
        '    If e.Column.FieldName.ToString <> "Edited" Then
        '        'Marks Actitive the Document if newly Added
        '        .SetRowCellValue(e.RowHandle, "Edited", True)
        '        Me.TrainingView.SetRowCellValue(e.RowHandle, "Edited", True)
        '        If e.Column.FieldName.ToString <> "FilePath" Then
        '            If Not .GetRowCellValue(e.RowHandle, "FKeyDocument").Equals(System.DBNull.Value) And .GetRowCellValue(e.RowHandle, "isActive").Equals(System.DBNull.Value) Then
        '                If Not e.Column.FieldName.Equals("isActive") Then
        '                    .SetRowCellValue(e.RowHandle, "isActive", True)
        '                End If
        '            End If
        '        End If

        '    End If
        'End With
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If e.Column.FieldName.ToString <> "Edited" Then
                TryCast(view.ParentView, DevExpress.XtraGrid.Views.Grid.GridView).SetRowCellValue(view.SourceRowHandle, "Edited", True)
                .SetRowCellValue(e.RowHandle, "Edited", True)
                'Me.TrainingView.SetRowCellValue(e.RowHandle, "Edited", True)
                If e.Column.FieldName.ToString <> "FilePath" Then
                    If Not .GetRowCellValue(e.RowHandle, "FKeyDocument").Equals(System.DBNull.Value) And .GetRowCellValue(e.RowHandle, "isActive").Equals(System.DBNull.Value) Then
                        If Not e.Column.FieldName.Equals("isActive") Then
                            .SetRowCellValue(e.RowHandle, "isActive", True)
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub TrainingSub_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles TrainingSub.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim ft As String = ""
        Dim di As String = ""
        Dim fileName As String = ""
        With view
            If Not .GetListSourceRowCellValue(e.ListSourceRowIndex, "FileTag").Equals(System.DBNull.Value) Then
                ft = .GetListSourceRowCellValue(e.ListSourceRowIndex, "FileTag")
            Else
                ft = ""
            End If
            If Not .GetListSourceRowCellValue(e.ListSourceRowIndex, "DateIssue").Equals(System.DBNull.Value) Then
                di = CDate(.GetListSourceRowCellValue(e.ListSourceRowIndex, "DateIssue")).ToString("yyyyMMdd")
            Else
                di = ""
            End If

            If e.Column.FieldName = "FileName" AndAlso e.IsGetData Then
                e.Value = strID & "_" & ft & "_" & di
            End If
        End With
    End Sub

    Private Sub TrainingSub_GotFocus(sender As Object, e As System.EventArgs) Handles TrainingSub.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = TrainingSub
            SetDeleteCaption(Name, "Delete Training Certificate")
        End If

    End Sub

    Private Sub TrainingSub_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles TrainingSub.InitNewRow
        'Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        'View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        ''SubAddMode = True
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        Dim MView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(View.ParentView, DevExpress.XtraGrid.Views.Grid.GridView)
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "FKeyCrewDocumentID", MView.GetRowCellValue(MView.SourceRowHandle, "PKey")) 'Crew Document ID
        'SubAddMode = True

    End Sub

    Private Sub TrainingSub_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles TrainingSub.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
        HasError = True
    End Sub

    Private Sub TrainingSub_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TrainingSub.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.TrainingView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub TrainingSub_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles TrainingSub.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Required FieldsNames
        Dim strRequiredFieldName As String = ""
        strRequiredFieldName = "FKeyDocument;DateIssue;Number;"
        With view
            If InStr(1, strRequiredFieldName, e.Column.FieldName) > 0 Then
                e.Appearance.BackColor = REQUIRED_COLOR
                If .GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
                    e.Appearance.BackColor = SEL_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") And .FocusedRowHandle = e.RowHandle Then
                    e.Appearance.BackColor = EDITED_FOCUSED_COLOR
                ElseIf .GetRowCellValue(e.RowHandle, "Edited") Then
                    e.Appearance.BackColor = EDITED_COLOR
                ElseIf e.RowHandle = .FocusedRowHandle Then
                    e.Appearance.BackColor = SEL_COLOR
                End If
            ElseIf .IsRowSelected(e.RowHandle) Then
                e.Appearance.BackColor = SEL_COLOR
                e.Appearance.ForeColor = System.Drawing.Color.Black
            End If
        End With
    End Sub

    Private Sub TrainingSub_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles TrainingSub.RowUpdated
        BRECORDUPDATEDs = True
        'Me.TrainingView.SetRowCellValue(Me.TrainingView.FocusedRowHandle, "Edited", True)
    End Sub

    Private Sub TrainingSub_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles TrainingSub.ValidatingEditor
        SetCourseDateExpriry(sender, e)
    End Sub

    Private Sub TrainingSub_ShownEditor(sender As Object, e As System.EventArgs) Handles TrainingSub.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        With view
            If .FocusedColumn.FieldName.Equals("FKeyCertCapacity") Then
                ReloadCapcity(view)
            End If
        End With
    End Sub

    Private Sub TrainingSub_HiddenEditor(sender As Object, e As System.EventArgs) Handles TrainingSub.HiddenEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "FKeyCertCapacity" Then
            If Not DataViewCapacity Is Nothing Then
                DataViewCapacity.Dispose()
                DataViewCapacity = Nothing
            End If
        End If
    End Sub

    Private Sub TrainingSub_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles TrainingSub.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Course As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("FKeyDocument")
        Dim DateIssue As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("DateIssue")
        Dim tsNumber As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Number")
        With view
            'Validate LicCert
            If .GetRowCellValue(e.RowHandle, Course) IsNot System.DBNull.Value And .GetRowCellValue(e.RowHandle, Course) IsNot Nothing Then
                .SetRowCellValue(e.RowHandle, "FileTag", getFileTag(.GetRowCellValue(e.RowHandle, Course)))
            ElseIf .GetRowCellValue(e.RowHandle, Course) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Course) Is Nothing Then
                .SetColumnError(Course, "Please select Certificate.")
                e.Valid = False
            Else
                .SetColumnError(Course, "")
            End If

            'Validate DateIssue
            If .GetRowCellValue(e.RowHandle, DateIssue) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, DateIssue) Is Nothing Then
                .SetColumnError(DateIssue, "Please Enter Issued Date.")
                e.Valid = False
            Else
                .SetColumnError(DateIssue, "")
            End If

            If .GetRowCellValue(e.RowHandle, tsNumber) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, tsNumber) Is Nothing Then
                .SetColumnError(tsNumber, "Please Enter Number.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, tsNumber) = "" Then
                    .SetColumnError(tsNumber, "Please Enter Number.")
                    e.Valid = False
                Else
                    .SetColumnError(tsNumber, "")
                End If
            End If


            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
                HasError = False
            Else
                BRECORDUPDATEDs = True
            End If
        End With
    End Sub

    Private Sub SetCourseDateExpriry(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs)
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            With view

                If .FocusedColumn.FieldName = "FKeyDocument" Then
                    Dim Course As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCourse"), "NULL")
                    Dim DocCode As String = e.Value
                    'Dim DateIssue As Date = IfNull(.GetRowCellValue(.FocusedRowHandle, "DateIssue"), "")
                    If Not Course.Equals("NULL") And Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(System.DBNull.Value) Then
                        Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
                        .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetCourseExpiry(DocCode, DateIssue, Course))
                    End If
                End If

                If .FocusedColumn.FieldName = "DateIssue" Then
                    Dim Course As String = IfNull(.GetRowCellValue(.FocusedRowHandle, "FKeyCourse"), "NULL")
                    Dim DateIssue As Date = e.Value
                    If Not Course.Equals("NULL") And Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals(System.DBNull.Value) Then
                        Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
                        .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetCourseExpiry(DocCode, DateIssue, Course))
                    End If
                End If

                If .FocusedColumn.FieldName = "FKeyCourse" Then
                    Dim Course As String = e.Value
                    If Not .GetRowCellValue(.FocusedRowHandle, "FKeyDocument").Equals(System.DBNull.Value) And Not .GetRowCellValue(.FocusedRowHandle, "DateIssue").Equals(System.DBNull.Value) Then
                        Dim DocCode As String = .GetRowCellValue(.FocusedRowHandle, "FKeyDocument")
                        Dim DateIssue As Date = .GetRowCellValue(.FocusedRowHandle, "DateIssue")
                        .SetRowCellValue(.FocusedRowHandle, "DateExpiry", GetCourseExpiry(DocCode, DateIssue, Course))
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetCourseExpiry(DocumentCode As String, DateIssue As Date, Optional Course As String = "NULL")
        Dim retval As Object = System.DBNull.Value
        Dim strValidity() As String
        Dim xYear As Integer = 0
        Dim xMonth As Integer = 0
        Dim xWeek As Integer = 0
        Dim xDays As Integer = 0
        Dim val As String = 0

        val = MPSDB.DLookUp("Validity", "tblAdmCourseDoc_map", "", "FKeyCourse='" & Course & "' AND FKeyDocument='" & DocumentCode & "'")

        If Not Trim(val).Equals("") Then
            strValidity = val.Split(".")
            xYear = CInt(IIf(strValidity(0).Equals(""), "0", strValidity(0)))
            xMonth = CInt(IIf(strValidity(1).Equals(""), "0", strValidity(1)))
            xDays = CInt(IIf(strValidity(2).Equals(""), "0", strValidity(2)))
            DateIssue = DateIssue.AddYears(xYear)
            DateIssue = DateIssue.AddMonths(xMonth)
            DateIssue = DateIssue.AddDays(xDays)
            retval = DateIssue
        End If
        Return retval
    End Function

    Private Sub RefreshCapacity()
        tblCapacity = DB.CreateTable("SELECT * FROM dbo.tblAdmCapacity ORDER BY Name ASC")
        Me.repTrainingCapacity.DataSource = tblCapacity
        tblCapacityMap = DB.CreateTable("SELECT * FROM dbo.LicCertCap_Map")
    End Sub
#End Region

#End Region

#Region "Education"

    Private Function SaveEducation(ByVal _CompanyID As String) As ArrayList
        Dim query As New ArrayList
        Dim DocStr As String = ""
        With Me.EducView
            .CloseEditForm()
            .UpdateCurrentRow()
            Dim x As Integer = 0
            For i As Integer = 0 To .RowCount - 1
                If .GetRowCellValue(i, "Edited") Then
                    Dim dateIssued As String = CDate(.GetRowCellValue(i, "DateIssue")).ToString("yyyyMMdd")

                    'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, CleanInput(IfNull(.GetRowCellValue(i, "Degree"), "")), FormName, strID) 'neil   'tony20160719
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Education", 0, System.Environment.MachineName, CleanInput(IfNull(.GetRowCellValue(i, "Degree"), "")).ToString.Replace("'", "''"), FormName, strID)

                    If IfNull(.GetRowCellValue(i, "PKey"), "") = "" Then
                        query.Add("INSERT INTO dbo.tblEduc(" & _
                                  "FKeyIDNbr," & _
                                  "YrStart," & _
                                  "YrEnd," & _
                                  "School," & _
                                  "Degree," & _
                                  "FilePath," & _
                                  "LastUpdatedBy)" & _
                                   "VALUES(" & _
                                   "'" & strID & "'" & _
                                   ",'" & CleanInput(IfNull(.GetRowCellValue(i, "YrStart"), "")) & "'" & _
                                   ",'" & CleanInput(IfNull(.GetRowCellValue(i, "YrEnd"), "")) & "'" & _
                                   ",'" & CleanInput(IfNull(.GetRowCellValue(i, "School"), "")) & "'" & _
                                   ",'" & CleanInput(IfNull(.GetRowCellValue(i, "Degree"), "")) & "'" & _
                                   "," & GetFilePathFileName(i, EducView) & _
                                   ",'" & LastUpdatedBy & "')")
                    Else
                        'NEIL query.Add("UPDATE dbo.tblEduc SET " & _
                        '          "YrStart = '" & CleanInput(.GetRowCellValue(i, "YrStart")) & "'" & _
                        '          ",YrEnd = '" & CleanInput(.GetRowCellValue(i, "YrEnd")) & "'" & _
                        '          ",School = '" & CleanInput(.GetRowCellValue(i, "School")) & "'" & _
                        '          ",Degree = '" & CleanInput(.GetRowCellValue(i, "Degree")) & "'" & _
                        '          ",FilePath = " & GetFilePathFileName(i, EducView) & _
                        '          ",DateUpdated = (getdate())" & _
                        '          ",LastUpdatedBy = '" & .GetRowCellValue(i, "LastUpdatedBy") & "'" & _
                        '          "WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                        query.Add("UPDATE dbo.tblEduc SET " & _
                                  "YrStart = '" & CleanInput(.GetRowCellValue(i, "YrStart")) & "'" & _
                                  ",YrEnd = '" & CleanInput(.GetRowCellValue(i, "YrEnd")) & "'" & _
                                  ",School = '" & CleanInput(.GetRowCellValue(i, "School")) & "'" & _
                                  ",Degree = '" & CleanInput(.GetRowCellValue(i, "Degree")) & "'" & _
                                  ",FilePath = " & GetFilePathFileName(i, EducView) & _
                                  ",DateUpdated = (getdate())" & _
                                  ",LastUpdatedBy = '" & LastUpdatedBy & "'" & _
                                  "WHERE FKeyIDNbr = '" & strID & "' AND PKey='" & .GetRowCellValue(i, "PKey") & "'")
                    End If
                    If (Not IfNull(.GetRowCellValue(i, "FilePath"), "").ToString.Equals(IfNull(.GetRowCellValue(i, "FileName"), ""))) And Not IfNull(.GetRowCellValue(i, "FilePath"), "").ToString.Equals("") Then
                        DocStr = IfNull(.GetRowCellValue(i, "FilePath"), "") & "|" & _
                                 IfNull(.GetRowCellValue(i, "FileName"), "")
                        DocumentList.Add(New Dictionary(Of Integer, String)() From {{x, DocStr}})
                        x = x + 1
                    End If
                End If
            Next

        End With
        Return query
    End Function

    Private Sub EducView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles EducView.CellValueChanged
        If e.Column.FieldName.ToString <> "Edited" Then
            Me.EducView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub EducView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles EducView.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim ft As String = ""
        Dim di As String = ""
        Dim fileName As String = ""
        With view
            'If Not .GetListSourceRowCellValue(e.ListSourceRowIndex, "FileTag").Equals(System.DBNull.Value) Then
            'ft = .GetListSourceRowCellValue(e.ListSourceRowIndex, "FileTag")
            ft = "EDUC"
            'Else
            'ft = ""
            'End If

            If Not .GetListSourceRowCellValue(e.ListSourceRowIndex, "YrEnd").Equals(System.DBNull.Value) Then
                di = .GetListSourceRowCellValue(e.ListSourceRowIndex, "YrEnd").ToString
                'di = CDate(.GetListSourceRowCellValue(e.ListSourceRowIndex, "DateIssue")).ToString("yyyyMMdd")
            Else
                di = ""
            End If
            e.Value = strID & "_" & ft & "_" & di
        End With
    End Sub

    Private Sub EducView_GotFocus(sender As Object, e As System.EventArgs) Handles EducView.GotFocus
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If isEditdable Or bAddMode Then
            focusedView = view
            SetDeleteCaption(Name, "Delete Education")
        End If
    End Sub

    Private Sub EducView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EducView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, "Edited", True) 'Edited
        View.SetRowCellValue(e.RowHandle, "FKeyIDNbr", strID) 'Crew ID
        SubAddMode = True
    End Sub

    Private Sub EducView_InvalidRowException(sender As Object, e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles EducView.InvalidRowException
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction
    End Sub

    Private Sub EducView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles EducView.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.EducView.CancelUpdateCurrentRow()
        End If
    End Sub

    Private Sub EducView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles EducView.RowCellStyle
        If Me.EducView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf Me.EducView.GetRowCellValue(e.RowHandle, "Edited") And Me.EducView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf Me.EducView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = Me.EducView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub EducView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles EducView.RowUpdated
        BRECORDUPDATEDs = True
    End Sub

    Private Sub EducView_ShowingPopupEditForm(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs) Handles EducView.ShowingPopupEditForm
        e.EditForm.Location = New System.Drawing.Point((My.Computer.Screen.Bounds.Width - e.EditForm.Width) / 2, (My.Computer.Screen.Bounds.Height - e.EditForm.Height) / 2)
        e.EditForm.Text = "Crew Documents Education"
        e.EditForm.Height = e.EditForm.Height + 17
        e.EditForm.ControlBox = False
        e.EditForm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

        For Each cntrl As Windows.Forms.Control In e.EditForm.Controls
            If Not TypeOf cntrl Is DevExpress.XtraGrid.EditForm.Helpers.Controls.EditFormContainer Then
                Continue For
            End If
            For Each nctrl As Windows.Forms.Control In cntrl.Controls
                If Not (TypeOf nctrl Is DevExpress.XtraEditors.PanelControl) Then
                    Continue For
                Else
                    nctrl.Height = 70
                End If
                For Each btn As Windows.Forms.Control In nctrl.Controls
                    If TypeOf btn Is DevExpress.XtraEditors.SimpleButton Then
                        Dim sbtn = TryCast(btn, DevExpress.XtraEditors.SimpleButton)
                        'Update Button
                        If sbtn.Text = "Update" Or sbtn.Text = "Add" Or sbtn.Text = "Edit" Then
                            If SubAddMode Then
                                sbtn.Text = "Add"
                                sbtn.Image = ImageCollection.Images.Item(0)
                                sbtn.ImageIndex = 2
                            Else
                                sbtn.Text = "Edit"
                                sbtn.Image = ImageCollection.Images.Item(2)
                                sbtn.ImageIndex = 0
                            End If
                            SubAddMode = False
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) - sbtn.Size.Width - 3, 18)
                        End If
                        'Cancel Button
                        If sbtn.Text = "Cancel" Then
                            sbtn.Image = ImageCollection.Images.Item(1)
                            sbtn.ImageIndex = 0
                            sbtn.Size = New System.Drawing.Point(90, 38)
                            sbtn.Location = New System.Drawing.Point((e.EditForm.Width / 2) + 3, 18)
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub EducView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles EducView.ValidateRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim YearStart As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("YrStart")
        Dim YearEnd As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("YrStart")
        Dim Degree As DevExpress.XtraGrid.Columns.GridColumn = view.Columns("Degree")

        With view
            'Degree
            If .GetRowCellValue(e.RowHandle, Degree) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, Degree) Is Nothing Then
                .SetColumnError(Degree, "Please enter Degree.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, Degree) <> "" Then
                    .SetColumnError(Degree, "")
                Else
                    .SetColumnError(Degree, "Please enter Degree.")
                    e.Valid = False
                End If
            End If

            'Validate Year Start
            If .GetRowCellValue(e.RowHandle, YearStart) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, YearStart) Is Nothing Then
                .SetColumnError(YearStart, "Please enter Start Year.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, YearStart) <> "" Then
                    .SetColumnError(YearStart, "")
                Else
                    .SetColumnError(YearStart, "Please enter Start Year.")
                    e.Valid = False
                End If
            End If
            'Validate YearEnd
            If .GetRowCellValue(e.RowHandle, YearEnd) Is System.DBNull.Value Or .GetRowCellValue(e.RowHandle, YearEnd) Is Nothing Then
                .SetColumnError(YearEnd, "Please enter Start End.")
                e.Valid = False
            Else
                If .GetRowCellValue(e.RowHandle, YearEnd) <> "" Then
                    .SetColumnError(YearEnd, "")
                Else
                    .SetColumnError(YearEnd, "Please enter Start End.")
                    e.Valid = False
                End If
            End If
            'clear errors
            If Not .HasColumnErrors Then
                e.Valid = True
                .ClearColumnErrors()
            Else
                BRECORDUPDATEDs = True
            End If
        End With
    End Sub

#End Region

    Private Sub TabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabControl.SelectedPageChanged
        LoadSub()
        PrevTab = Me.TabControl.SelectedTabPage.Tag
    End Sub

    Private Sub TabControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangingEventArgs) Handles TabControl.SelectedPageChanging
        If BRECORDUPDATEDs Then
            Dim msgans As Integer
            msgans = MsgBox("Would you like to save the changes you made on " & e.PrevPage.Text & "?", MsgBoxStyle.YesNoCancel, strCaption)
            'If MsgBox("Would you like to save the changes you made on " & e.PrevPage.Text & "?", MsgBoxStyle.YesNoCancel, strCaption) = MsgBoxResult.Yes Then
            If msgans = MsgBoxResult.Yes Then
                tabChanged = True
                SaveData()
            ElseIf msgans = MsgBoxResult.No Then
                RefreshData()
                'ElseIf MsgBoxResult.Cancel Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub ResetControlOnEdit()
        ResetGridViewEdits(New DevExpress.XtraGrid.Views.Grid.GridView() {TrainingView, EducView})
        RefreshData()
    End Sub

    Private Sub RepositoryItemDateEdit1_Click(sender As Object, e As System.EventArgs) Handles RepositoryItemDateEdit1.Click

    End Sub

    Private Sub TrainingView_ShownEditor(sender As Object, e As System.EventArgs) Handles TrainingView.ShownEditor
        SetMinMaxDateValidation(sender, e, "DateIssue", "DateExpiry")
        stopnaba = True
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "SelectRecord"
                SelectRecord(param(1), param(2))
        End Select
    End Sub

    Private Sub SelectRecord(Group As String, PKey As String)
        Select Case Group
            Case "isCourse"
                TabControl.SelectedTabPage = TabControl.TabPages(0)
                With TrainingView
                    .FocusedRowHandle = .LocateByValue("PKey", PKey)
                End With
        End Select
    End Sub

    Dim stopnaba As Boolean = False

    Private Sub TrainingGrid_Click(sender As Object, e As System.EventArgs) Handles TrainingGrid.Click
        stopnaba = True
    End Sub

    Private Sub TrainingGrid_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TrainingGrid.MouseClick
        stopnaba = True
    End Sub

    Private Sub TrainingGrid_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TrainingGrid.MouseMove
        Application.DoEvents()
        Dim grid As DevExpress.XtraGrid.GridControl = sender
        If grid Is Nothing Then
            Return
        End If
        ' Get a View at the current point.
        Dim view As DevExpress.XtraGrid.Views.Base.BaseView = grid.GetViewAt(e.Location)
        ' Retrieve information on the current View element.
        Dim baseHI As DevExpress.XtraGrid.Views.Base.ViewInfo.BaseHitInfo = view.CalcHitInfo(e.Location)
        Dim gridHI As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = TryCast(baseHI, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)
        If Not gridHI Is Nothing Then

            If gridHI.HitTest <> DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
                'Debug.Print("MouseMove on Indicator")
                Call clsgridflout.addFlyout(sender, e, stopnaba)
                'Text = gridHI.HitTest.ToString()
            End If

        End If
        'Call clsgridflout.addFlyout(sender, e, stopnaba)
    End Sub

    Private Sub repTrainingCourse_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingCourse.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repTrainingCntry_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingCntry.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repTrainingCourseType_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingCourseType.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repTrainingCourseStat_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingCourseStat.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repTrainingCourseInst_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingCourseInst.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repTrainingCapacity_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingCapacity.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repTrainingDoc_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingDoc.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repTrainingLimit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTrainingLimit.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub repCurrency_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCurrency.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub RepositoryItemDateEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemDateEdit1.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub RepDateTime_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepDateTime.ButtonClick
        ClearLookUpEdit(sender, e)
    End Sub

    Private Sub TrainingView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles TrainingView.CustomDrawRowIndicator
        '<!-- added by tony20180115
        Dim RetakeCourseWithinDays As Integer = IfNull(TrainingView.GetRowCellValue(e.RowHandle, "RetakeCourseWithinDays"), 0)

        If RetakeCourseWithinDays <> 0 Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)
            If RetakeCourseWithinDays < 0 Then
                'Pass Due to be retaken/repeat
                e.Graphics.DrawImage(My.Resources.Course_Retake_Warning_Red, New System.Drawing.RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))

            ElseIf RetakeCourseWithinDays > 0 And _
                RetakeCourseWithinDays <= DueToRetakeInDays() Then
                'Due to be retaken/repeat within 30 days
                e.Graphics.DrawImage(My.Resources.Course_Retake_Warning_Orange, New System.Drawing.RectangleF(e.Bounds.X + 1, e.Bounds.Y + (e.Bounds.Height / 2 - 9), e.Bounds.Width - 2, 18))

            End If
            e.Handled = True
        End If
        '-->
    End Sub

    Private Sub ToolTipController_RepeatCourseTraining_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController_RepeatCourseTraining.GetActiveObjectInfo
        If Not e.SelectedControl Is TrainingGrid Then Return

        Dim info As DevExpress.Utils.ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TrainingGrid.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells
        If hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            'An object that uniquely identifies a row indicator cell
            Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
            Dim text As String = "" '"Row " + hi.RowHandle.ToString()

            Dim RetakeCourseWithinDays As Integer = IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseWithinDays"), 0)

            If RetakeCourseWithinDays <> 0 Then
                Dim cRetakeDesc As String = ""
                'Year
                If IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseYear"), 0) > 0 Then
                    cRetakeDesc = IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseYear"), 0) & " year" & IIf(IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseYear"), 0) > 1, "s", "")
                End If

                'Month
                If IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseMonth"), 0) > 0 Then
                    cRetakeDesc = IIf(IfNull(cRetakeDesc, "").Length > 0, "", " and ") & _
                                  IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseMonth"), 0) & " month" & IIf(IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseMonth"), 0) > 1, "s", "")
                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Arrange Description
                If IfNull(cRetakeDesc, "").Length > 0 Then
                    If Not IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseCountry"), "").Equals("") Then
                        cRetakeDesc = "Course [" & IfNull(view.GetRowCellDisplayText(hi.RowHandle, "FKeyCourse"), "") & "] taken from " & IfNull(view.GetRowCellValue(hi.RowHandle, "RetakeCourseCountry"), "") & " is set to be retaken every " & cRetakeDesc
                    Else
                        cRetakeDesc = "Course [" & IfNull(view.GetRowCellDisplayText(hi.RowHandle, "FKeyCourse"), "") & "] is set to be retaken every " & cRetakeDesc
                    End If

                    cRetakeDesc = cRetakeDesc & IIf(IfNull(cRetakeDesc, "").Length > 0, ".", "")
                End If

                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Check if is to be retaken 
                '   Construct the message to show in tooltip
                If RetakeCourseWithinDays < 0 Then
                    'Pass Due to be retake/repeat course
                    text = "Crew is pass due to repeat training for this course." & IIf(IfNull(cRetakeDesc, "").Length > 0, vbNewLine & vbNewLine & cRetakeDesc, "")

                ElseIf RetakeCourseWithinDays > 0 And RetakeCourseWithinDays <= DueToRetakeInDays() Then
                    text = "Crew must repeat training for this course within " & RetakeCourseWithinDays & " day" & IIf(RetakeCourseWithinDays > 1, "s", "") & "." & IIf(IfNull(cRetakeDesc, "").Length > 0, vbNewLine & vbNewLine & cRetakeDesc, "")

                End If

                If text.Length > 0 Then info = New DevExpress.Utils.ToolTipControlInfo(o, text)
                '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            End If


        End If
        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub
End Class
